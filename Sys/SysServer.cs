
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 11.03.2017
 * Время: 23:57
*/
using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Diagnostics;


namespace FBA
{    
	#region Region. Сервер приложений.
	
	///Методы связанные с сервером приложений.
	public static partial class sys
    {
		  
        ///Извещаем сервер приложений о том, что клиент закрывается. Для того чтобы освободить лицензию.    
        public static void SendEventClientClose()
        {             //Var.con.ConnectionDirect
            //if (Var.con.ConnectionGUID == "") return;
            if (Var.con.ConnectionDirect) return;
            const string CommandStr = "Client is closed";
            try
            {
                string RequestStr = sys.ServerAppSendHTTPMessage("Client", Var.con.ServerAppName, Var.con.ServerAppPort, CommandCode.C106,
                Var.con.ConnectionGUID, CommandStr, "", 0);
                //sys.SM(RequestStr);
            }
            catch
            {
                //Если клиент закрывается не выдаем ошибку.
            }
        }

        ///Если в имени сервера указан порт, то используетм его.
        public static void GetServerAppPort(string ServerName, out string Name, out int Port)
        {
            int i = ServerName.IndexOf(':');
            if (i > -1)
            {
                Name = ServerName.Left(i);
                //В ServerName может быть как имя файла базы SQLite с путём, так и IP
                //примеры: 
                //192.168.10.15:71145
                //C:\000_Тravin\Дизайнер SD\sys\bin\Debug\Bin\local.db3   
                string portStr =  ServerName.SubStringEnd(i + 1, 5);                
                Port = portStr.ToInt(false);
            }
            else
            {
                Name = ServerName;
                Port = Var.ServerAppPortDefault;
            }
        }

        
        /// <summary>
        /// Получить количество запущенных копий приложения с именем appName.
        /// </summary>
        /// <param name="appName"></param>
        /// <returns>Количество запущенных копий в Windows с именем appName</returns>
        public static int GetCountRunApp(string appName)
        {
            //Возможно цикл по процессам надежнее использования семафоров?
            int сountApp = 0;
            Process[] proclist = Process.GetProcesses();
            foreach (Process proc in proclist)
            {
                if (proc.ProcessName == appName) сountApp++;
            }
            return сountApp;
        }
        
        ///Получить номер порта для локального сервера приложений.
        public static int GetServerLocalPort()
        {
            //Проблема в том, что сервер приложений на локальном компьютере 
            //в каждой копии программы ClientApp должен быть на своём уникальном порту.
            //т.к. порт сервера 7100, то если одна копия программы, 
            //то result будет 7101, если две, то 7102 и т.д.  
            //int Port = sys.GetCountRunApp(Var.SystemName) + ServerAppPortDefault;
            //if ((Port == 0) || (Port == Var.ServerAppPortDefault)) Port = ServerAppPortDefault + 1;

            int Port = sys.GetCountRunApp(Var.SystemName) + Var.ServerAppPortDefault; //Var.LocalServerPort;
            //Локальный доступный порт нужно получать от сервера приложений.
            string RequestStr = sys.ServerAppSendHTTPMessage("Client", 
                Var.con.ServerAppName, 
                Var.con.ServerAppPort, CommandCode.C107,
                Var.con.ConnectionGUID, "GetLocalPort", "", 0);
            if (RequestStr != "") Port = RequestStr.ToInt();
            return Port;
        }

        ///Послать сообщение на сервер приложений.
        public static string ServerAppSendHTTPMessage(string Source, string ServerAppName, int ServerAppPort, CommandCode commandCode, string GUID, string CommandText, string FileName, int WaitTimeout = 0)
        {
            string url = @"http://" + ServerAppName + @":" + ServerAppPort.ToString() + @"/" + commandCode + ";" + GUID + ";";            
        	string ErrorText =
                "CommandText: " + CommandText + Var.CR +
                "Source: " + Source + Var.CR +
                "ServerAppName: " + ServerAppName + Var.CR +
                "ServerAppPort: " + ServerAppPort + Var.CR +
            	"CommandCode: " + commandCode.ToString() + Var.CR +
                "GUID: " + GUID + Var.CR +
                "FileName: " + FileName + Var.CR +
                "WaitTimeout: " + WaitTimeout + Var.CR +
        		"url: " + url;

            //if (GUID != "") url += GUID + ";";
            string contentType = "text/html";
            if (FileName != "") contentType = "image/jpeg";
            if (CommandText == "") CommandText = "Empty";
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n"); //ASCII  //Default                    
            const string formdataTemplate = "Content-Disposition: form-data; name=file; filename=\"{0}\";\r\nContent-Type: {1}\r\n\r\n";
            string formitem = string.Format(formdataTemplate, Path.GetFileName(FileName), contentType);
            byte[] formBytes = System.Text.Encoding.UTF8.GetBytes(formitem);  //UTF8                   //Default 
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.SendChunked = true;
            if (WaitTimeout == 0) WaitTimeout = Var.QueryTimeout; //300000 - 5 минут.
            request.Timeout = WaitTimeout;

            //Посылаем либо текст из CommandText, либо текст из файла.
            if (FileName != "")
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    var fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    requestStream.Write(formBytes, 0, formBytes.Length);
                    var buffer = new byte[1024 * 4];
                    int bytesLeft;
                    while ((bytesLeft = fileStream.Read(buffer, 0, buffer.Length)) > 0) requestStream.Write(buffer, 0, bytesLeft);
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                }
            }

            if (CommandText != "")
            {
                try
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                        requestStream.Write(formBytes, 0, formBytes.Length);
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(CommandText);
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    }
                }
                catch (Exception ex)
                {                                   	                	        
                	sys.SM("Ошибка по отправке сообщения серверу приложений: " + Var.CR + ex.Message + Var.CR + ErrorText);
                    //throw new GlobalException(ErrorText + Var.CR + "Ошибка по отправке сообщения серверу приложений: " + ex.Message);
                    return "";

                    //var stack = new StackTrace(ex);
                    //stack.GetFrame().GetFileLineNumber()
                    //foreach (StackFrame frame in stack.GetFrames())
                    //{
                    //    Console.WriteLine(frame.GetMethod());
                    //}
                }
            }
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    Stream receiveStream = response.GetResponseStream();

                    // Pipes the stream to a higher level stream reader with the required encoding format. 
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                    //Console.WriteLine ("Response stream received.");
                    //Console.WriteLine (readStream.ReadToEnd ());
                    //string st1 = readStream.ReadToEnd ();
                    //return st1;
                    return readStream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {             
            	sys.SM(ErrorText + Var.CR + "Ошибка: " + ex.Message);
                return "";
                //throw new GlobalException(ErrorText + Var.CR + "Ошибка получения сообщения от сервера приложений: " + ex.Message);
            }


            //sys.SM("dfgdf");

            /*try
            {
                //Ответ от сервера приложений.
                using (var response = (HttpWebResponse) request.GetResponse())
                {               
                    Stream resStream = response.GetResponseStream();        
                    var buf = new byte[8192];
                    var sb = new StringBuilder();
                    int count = 0;
                    do
                    {
                        count = resStream.Read(buf, 0, buf.Length);
                        if (count != 0)
                        {                
                            sb.Append(Encoding.UTF8.GetString(buf, 0, count));  //Default
                        }
                    }
                    while (count > 0);
                    return sb.ToString().Replace(Var.CR, "");
                }              
            } catch (Exception ex)
            {
                sys.SM("Ошибка: " + ex.Message);
                return "";
            } */





    }

    ///Код команды и GUID посылаются в строке URL, длина URL всегда фиксирована.
    public static bool GetComandCode(string RawUrl, out CommandCode commandCode, ref string ConnectionGUID, ref string FileName)
        {
            //Содержимое (например SQL запросы), передаются в контексте запроса HTTP.
            //101;99FE5A67-CC86-4409-8B1F-9296A985533A;Report.txt";
            //Все остальные данные в контексте сообщения - RequestStr. 
            commandCode = CommandCode.NotAssigned;
            if (RawUrl == null) return false;
            if (RawUrl.Length < 5) return false;  //  Пример того что может быть в RawUrl:   /C102;;          
            string CommandCodeString = RawUrl.Substring(1, 4);   //Команда всегда 4 символа.
            CommandCode testCommandCode = CommandCode.NotAssigned;
            commandCode = testCommandCode;
            if (Enum.TryParse(CommandCodeString, out testCommandCode)) commandCode = testCommandCode;
            else 
            {
            	sys.SM("Неизвестная команда " + CommandCodeString);
            	return false;
            }                              
            if (RawUrl.Length > 6) ConnectionGUID = RawUrl.SubStringEnd(6, 36);  //GUID имеет фиксированную длину в 36 символов.            
            if (ConnectionGUID.Length < 36) ConnectionGUID = "";
            if (RawUrl.Length > 42) FileName = RawUrl.SubStringEnd(43, 1000);
            return true;
        }

        ///Сохранить текст сообщения от клиента в файл. Сейчас не используется.
        public static string GetRequestFile(Encoding enc, string boundary, Stream input, string FileName)
        {
            Byte[] boundaryBytes = enc.GetBytes(boundary);
            Int32 boundaryLen = boundaryBytes.Length;
            string TempPath;
            if (!FBAFile.GetPathTemp(out TempPath)) return "error creating temporary directory: " + TempPath;
            string FullFileName = TempPath + FileName;
            using (var output = new FileStream(FullFileName, FileMode.Create, FileAccess.Write))
            {
                var buffer = new Byte[1024];
                Int32 len = input.Read(buffer, 0, 1024);
                Int32 startPos = -1;

                //Find start boundary
                while (true)
                {
                    if (len == 0)
                    {
                        return "Start Boundaray Not Found";
                    }

                    startPos = IndexOf(buffer, len, boundaryBytes);
                    if (startPos >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                        len = input.Read(buffer, boundaryLen, 1024 - boundaryLen);
                    }
                }

                //Skip four lines (Boundary, Content-Disposition, Content-Type, and a blank)
                for (Int32 i = 0; i < 4; i++)
                {
                    while (true)
                    {
                        if (len == 0)
                        {
                            return "Preamble not Found.";
                        }

                        startPos = Array.IndexOf(buffer, enc.GetBytes("\n")[0], startPos);
                        if (startPos >= 0)
                        {
                            startPos++;
                            break;
                        }
                        else
                        {
                            len = input.Read(buffer, 0, 1024);
                        }
                    }
                }

                Array.Copy(buffer, startPos, buffer, 0, len - startPos);
                len = len - startPos;

                while (true)
                {
                    Int32 endPos = IndexOf(buffer, len, boundaryBytes);
                    if (endPos >= 0)
                    {
                        if (endPos > 0) output.Write(buffer, 0, endPos - 2);
                        break;
                    }
                    else if (len <= boundaryLen)
                    {
                        return "End Boundaray Not Found";
                    }
                    else
                    {
                        output.Write(buffer, 0, len - boundaryLen);
                        Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                        len = input.Read(buffer, boundaryLen, 1024 - boundaryLen) + boundaryLen;
                    }
                }
            }
            return "Success";
        }

        ///Получить текст сообщения от клиента. Здесь полный текст, вместе со служебной информацией. Сейчас не используется.
        public static string GetRequestString1(HttpListenerRequest request)
        {
            if (!request.HasEntityBody)
            {
                return null;
            }
            using (System.IO.Stream body = request.InputStream) // here we have data
            {
                using (var reader = new System.IO.StreamReader(body, Encoding.UTF8)) //request.ContentEncoding /
                {
                    return reader.ReadToEnd();
                }
            }
        }

        ///Получить текст сообщения от клиента. Здесь текст, но без служеной информации.
        public static string GetRequestString2(Encoding enc, string boundary, Stream input)
        {
            Byte[] boundaryBytes = System.Text.Encoding.UTF8.GetBytes(boundary); //enc.GetBytes(boundary);           
            Int32 boundaryLen = boundaryBytes.Length;
            var output = new MemoryStream();
            var buffer = new Byte[1024];
            Int32 len = input.Read(buffer, 0, 1024);
            Int32 startPos = -1;

            //Find start boundary
            while (true)
            {
                if (len == 0)
                {
                    return "Start Boundaray Not Found";
                }

                startPos = IndexOf(buffer, len, boundaryBytes);
                if (startPos >= 0)
                {
                    break;
                }
                else
                {
                    Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                    len = input.Read(buffer, boundaryLen, 1024 - boundaryLen);
                }
            }

            //Skip four lines (Boundary, Content-Disposition, Content-Type, and a blank)
            for (Int32 i = 0; i < 4; i++)
            {
                while (true)
                {
                    if (len == 0)
                    {
                        return "Preamble not Found.";
                    }

                    //startPos = Array.IndexOf(buffer, enc.GetBytes("\n")[0], startPos);
                    startPos = Array.IndexOf(buffer, System.Text.Encoding.UTF8.GetBytes("\n")[0], startPos); //Default!!!


                    if (startPos >= 0)
                    {
                        startPos++;
                        break;
                    }
                    else
                    {
                        len = input.Read(buffer, 0, 1024);
                    }
                }
            }

            Array.Copy(buffer, startPos, buffer, 0, len - startPos);
            len = len - startPos;

            while (true)
            {
                Int32 endPos = IndexOf(buffer, len, boundaryBytes);
                if (endPos >= 0)
                {
                    if (endPos > 0) output.Write(buffer, 0, endPos - 2);
                    break;
                }
                else if (len <= boundaryLen)
                {
                    return "End Boundaray Not Found";
                }
                else
                {
                    output.Write(buffer, 0, len - boundaryLen);
                    Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                    len = input.Read(buffer, boundaryLen, 1024 - boundaryLen) + boundaryLen;
                }
            }
            string result = Encoding.UTF8.GetString(output.ToArray()); //enc.GetString     
            return result;
        }

        ///Для разбора сообщения от клиента.
        public static String GetBoundary(string ctype)
        {
        	if (ctype ==  null) return "";
        	return "--" + ctype.Split(';')[1].Split('=')[1];
        }

        ///Для разбора сообщения от клиента.
        private static Int32 IndexOf(Byte[] buffer, Int32 len, Byte[] boundaryBytes)
        {
            for (Int32 i = 0; i <= len - boundaryBytes.Length; i++)
            {
                Boolean match = true;
                for (Int32 j = 0; j < boundaryBytes.Length && match; j++)
                {
                    match = buffer[i + j] == boundaryBytes[j];
                }

                if (match)
                {
                    return i;
                }
            }

            return -1;
        }      
	
	}
	
	#endregion Region. Сервер приложений.
	
	
	#region Region. Локальный сервер HTTP для того чтобы принимать сообщение от сервера приложений.
	
	///Класс в отдельном потоке, позволяющий принимать сообщения от сервера приложений.
    ///Этот код на клиенте - запускается сервер HTTP. Это нужно для того, чтобы 
    ///принимать периодические сообщения от сервера приложений.
    ///Этот класс можно было бы разместить в Program.cs, но вынесен в отдельный файл для удобства.
    public static class ServerWork
    {      
        private static HttpListener ListenerHTTP;
        private static Thread threadserver;
        private static bool ServerStopInProcess = false;
        private static Form FormMainLocal;
        ///Запуск сервера на клиенте.
        public static void ServerStart(Form FormMain)
        {                                            
            FormMainLocal = FormMain;
            try
            {
                ThreadPool.SetMaxThreads(Var.MaxThreadsCount, Var.MaxThreadsCount);
                ThreadPool.SetMinThreads(Var.MinThreadsCount, Var.MinThreadsCount);                    
                ListenerHTTP = new HttpListener();
                ListenerHTTP.Prefixes.Add(@"http://" + Var.LocalIP + @":" + Var.LocalServerPort + @"/");
                //ListenerHTTP.Prefixes.Add(@"http://10.77.70.13:9596/");
                ListenerHTTP.Start();
            }
            catch (Exception ex)
            {
                sys.SM("Ошибка " + ErrorCode.C115 + " запуска локального сервера HTTP: " + ex.Message);
                ListenerHTTP.Stop();
                Environment.Exit(0); //При ошибку локального сервера приложений, работу не продолжаем!
            }

            try
            {
                //ServerQueueHTTP();
                threadserver = new Thread(ServerQueueHTTP);
                threadserver.Start();
            }
            catch (Exception ex)
            {
                sys.SM("Ошибка " + ErrorCode.C116 + " запуска локального сервера HTTP: " + ex.Message);
                ListenerHTTP.Stop();
                Environment.Exit(0); //При ошибку локального сервера приложений, работу не продолжаем!
            }
        }
        
        ///Остановка сервера на клиенте.
        public static void ServerStop()
        {            
            ServerStopInProcess = true;
            if (ListenerHTTP != null) ListenerHTTP.Stop();
            try
            {
                threadserver.Abort();
                threadserver.Join(); 
            } catch (Exception ex)
            {
                sys.SM("Ошибка " + ErrorCode.C117 + " остановки локального сервера: " + ex.Message);
                //Environment.Exit(0); //работу не продолжаем!
            }
        }
                      
        ///Очередь HTTP сервера. 
        private static void ServerQueueHTTP()
        {                    
            try    
            {
                //Принимаем клиентов в бесконечном цикле.
                while (true)
                {                                                                                           
                    ThreadPool.QueueUserWorkItem(ServerProcessHTTP, ListenerHTTP.GetContext());                                                                                                      
                }
            }
            catch (ThreadAbortException ex) 
            {
                //Эту ошибку не обрабатываем, так как эта ошибка - остановка потока и не является ошибкой.
                string err = ex.Message;
            }
            catch (Exception ex) //(SocketException ex)
            {
                //В случае другой ошибки, выводим что это за ошибка.                  
                if (!ServerStopInProcess) sys.SM("Ошибка " + ErrorCode.C118 + " при получении сообщения локальным сервером: " + ex.Message);
                Environment.Exit(0); //работу не продолжаем!
            }     
        }        
        
        ///Обработка запроса от клиента HTTP.В Данном случае у нас сервер приложений является клиентом.
        ///Так как на каждом клиенте запускается сервер HTTP.        
        private static void ServerProcessHTTP(object o)   
        {                                                                                                              
            try
            {
                var context = o as HttpListenerContext;
                HttpListenerRequest  request  = context.Request;                                                 
                HttpListenerResponse response = context.Response;    
                       
                CommandCode commandCode;
                string ConnectionGUID = ""; 
                string FileName       = "";
                string RequestStrLog  = "";
                string ResponseStr    = "";
                string RequestStr     = "";           
                if (!sys.GetComandCode(request.RawUrl, out commandCode, ref ConnectionGUID, ref FileName)) return;
                
                ResponseStr = "Success";
                //Если сервер прислал файл, то сохраняем в темповой папке.
                if (FileName != "") 
                {               
                    sys.GetRequestFile(context.Request.ContentEncoding, sys.GetBoundary(context.Request.ContentType), context.Request.InputStream, FileName);
                    RequestStrLog = sys.GetDateTimeNow() + ": Запись файла: " + FileName + Var.CR;            
                    //action = () => tbLogQuery.AppendText(RequestStrLog);
                    //tbLogServer.Invoke(action);                 
                } else
                {           
                    //RequestStr - это тело запроса от клиента.                
                    RequestStr = sys.GetRequestString2(context.Request.ContentEncoding, sys.GetBoundary(context.Request.ContentType), context.Request.InputStream);                                                 
                    RequestStrLog = sys.GetDateTimeNow() + ": " + RequestStr.Left(200) + "..."  + Var.CR;
                    RequestStrLog = RequestStrLog.Replace(Var.CR, "") + Var.CR;                                                              
                    //ResponseStr = "Success"; //GetServerResponse(CommandCode, RequestStr);
                    //string ResponseStr = "asd123нгшщзхъzxc";//Convert.ToBase64String(fileBuffer);  
                }
                
                //Проверка гуида клиента. Верное ли значение на сервере приложений.
                if (commandCode == CommandCode.S205) 
                    ResponseStr = (Var.con.ConnectionGUID == RequestStr) ? "GUID Ok." : "GUID mismatch.";                                   
                
                byte[] buffer = System.Text.Encoding.Default.GetBytes(ResponseStr); //UTF8          
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output  = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);                
                output.Close();
                
                if (commandCode == CommandCode.S201)
                {
                    ServerWork.ServerStop();
                    Environment.Exit(0);
                }
                
                //FormMainLocal.TopMost = true;
                if (commandCode == CommandCode.S202) sys.SM(RequestStr, MessageType.Error, "Сообщение от администратора");
                if (commandCode == CommandCode.S203) sys.SM(RequestStr, MessageType.Information, "Сообщение от администратора");   
                //if (commandCode == CommandCode.S204) sys.SM(RequestStr, MessageType.Question, "Вопрос от администратора");  //Пока не работает.
                 
            } catch (Exception ex) 
            {
                //В случае другой ошибки, выводим что это за ошибка.                  
                sys.SM("Ошибка " + ErrorCode.C119 + " локального сервера: " + ex.Message);
                //Environment.Exit(0); //работу не продолжаем!
            }                        
        }
        
        #endregion Region. Локальный сервер HTTP для того чтобы принимать сообщение от сервера приложений.
        
        //Получить текст сообщения от клиента. Здесь текст, но без служеной информации.
        /*public static string GetRequestString3(System.Text.Encoding enc, string boundary, Stream input)
        { 
            Byte[] boundaryBytes = System.Text.Encoding.UTF8.GetBytes(boundary); //enc.GetBytes(boundary);           
            Int32 boundaryLen = boundaryBytes.Length;             
            var output = new MemoryStream();
            var buffer = new Byte[1024];
            Int32 len = input.Read(buffer, 0, 1024);
            Int32 startPos = -1;
    
            //Find start boundary
            while (true)
            {
                if (len == 0)
                {                  
                    return "Start Boundaray Not Found";
                }
    
                startPos = IndexOf(buffer, len, boundaryBytes);
                if (startPos >= 0)
                {
                    break;
                }
                else
                {
                    Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                    len = input.Read(buffer, boundaryLen, 1024 - boundaryLen);
                }
            }
    
            //Skip four lines (Boundary, Content-Disposition, Content-Type, and a blank)
            for (Int32 i = 0; i < 4; i++)
            {
                while (true)
                {
                    if (len == 0)
                    {                       
                        return "Preamble not Found.";
                    }
    
                    //startPos = Array.IndexOf(buffer, enc.GetBytes("\n")[0], startPos);
                    startPos = Array.IndexOf(buffer, System.Text.Encoding.UTF8.GetBytes("\n")[0], startPos); //Default!!!
                    
                    
                    if (startPos >= 0)
                    {
                        startPos++;
                        break;
                    }
                    else
                    {
                        len = input.Read(buffer, 0, 1024);
                    }
                }
            }
    
            Array.Copy(buffer, startPos, buffer, 0, len - startPos);
            len = len - startPos;
    
            while (true)
            {
                Int32 endPos = IndexOf(buffer, len, boundaryBytes);
                if (endPos >= 0)
                {
                    if (endPos > 0) output.Write(buffer, 0, endPos-2);
                    break;
                }
                else if (len <= boundaryLen)
                {                         
                    return "End Boundaray Not Found";                    
                }
                else
                {
                    output.Write(buffer, 0, len - boundaryLen);
                    Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                    len = input.Read(buffer, boundaryLen, 1024 - boundaryLen) + boundaryLen;
                }
            }               
            string result = Encoding.UTF8.GetString(output.ToArray()); //enc.GetString     
            return result;           
        }*/
        
        //Для разбора сообщения от клиента.
        //public static String GetBoundary(String ctype)
        //{
        //    return "--" + ctype.Split(';')[1].Split('=')[1];             
        //}
        
        //Для разбора сообщения от клиента.
        //private static Int32 IndexOf(Byte[] buffer, Int32 len, Byte[] boundaryBytes)
        //{
        //    for (Int32 i = 0; i <= len - boundaryBytes.Length; i++)
        //    {
        //        Boolean match = true;
        //        for (Int32 j = 0; j < boundaryBytes.Length && match; j++)
        //        {
        //            match = buffer[i + j] == boundaryBytes[j];
        //        }
        //
        //        if (match)
        //        {
        //            return i;
        //        }
        //    }
        //
        //    return -1;
        //}               
    }
}
