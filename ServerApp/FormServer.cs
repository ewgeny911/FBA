
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 11.03.2017
 * Время: 21:30
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data;
using System.Xml;
    
namespace FBA
{         
	///Сервер приложений.
	public partial class FormServer : FormFBA
	{		   
		#region Region. Объявления переменных и конструктор класса по умолчанию.
		
	    //TcpListener  ListenerTCP;
		HttpListener ListenerHTTP;	
		Thread       threadserver;
		 
		int  ClientCount         = 0;      //Количество подключенных клиентов в данный момент.
		bool DatabaseConnected   = false;  //Признак подключения к удаленной БД.
		bool ServerAppConnected  = false;  //Признак, что сервер приложений запущен.			
		bool Allow102            = true;   //Подключаться минуя сервер приложений.
		bool FormShow            = true;   //Признак для определения того, развернута форма или нет.        
		int QueryCount           = 0;      //Счетчик запросов от клиента.
	    string ConNameServerApp  = "";     //Имя соедиения с удаленной БД, для сервера приложений.       
		const string SRVAppType  = "HTTP"; //Тип сервера TCP или HTTP. TCP пока не работает.
        
		//Лицензии
		string LicenseCount      = "";     //Максимальное кол-во лицензий.
		string LicenseDateStart  = "";     //Дата начала действия лицензии.
		string LicenseDateEnd    = "";     //Дата окончания действия лицензии.
		string LicenseKey        = "";     //Предыдущий лицензионный ключ.				  		 	
		
		//Список подключений пользователей к БД.
		Dictionary<string, Connection> ListCon = new Dictionary<string, Connection>();        
		
		//Конструктор.
		public FormServer()
		{			
			InitializeComponent();
            Var.FormMainObj = this;

          
			dgClientCurrent.Columns.Add("ClientMessage", "ClientMessage");
           
            DataGridViewColumn column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "UserCheck";
            column.Name = "UserCheck";             
            dgClientCurrent.Columns.Add(column);          
            
            cbTimeout.Text = Var.QueryTimeout.ToString();
            notifyIcon1.Visible = false;
            Var.enterMode = EnterMode.Work;
            
            //Соединение с локальной БД.           
            sys.ConnectLocal();
            comboBoxPort.Text = Var.ServerAppPortDefault.ToString();
            string AppPortDefault = sys.GetServerAppPortDefault().ToString();
            if (AppPortDefault != "0") comboBoxPort.Text = AppPortDefault;

            //Обновляем список подключений
            ConnectionListRefresh();   
            
			//var chk = new DataGridViewCheckBoxColumn();
            //dgClientCurrent.Columns.Add(chk);
            //chk.HeaderText = "UserCheck";
            //chk.Name = "UserCheck";
            //chk.ValueType = typeof(bool);
            //return (DGV.DataSource as System.Data.DataTable).Rows[RowIndex][ColumnName].ToString(); 
            //dgClientCurrent.Rows[2].Cells[3].Value = true;
			
		}
		                    	
		#endregion Region. Объявления переменных и конструктор класса по умолчанию.
		
        #region Region. Соединение с БД.
        
		///Добавление в колекцию подключений к БД, если такого ещё нет, то создается.
        private Connection ConnectionUserCreate(ref string ConnectionGUID, string LocalIP, string LocalPort, string LocalHost, string ComputerName, string ComputerUserName)
        {                                                       
            //Если соединение найдено, то возвращается
            if (ListCon.ContainsKey(ConnectionGUID))
            {      
                return ListCon[ConnectionGUID];
            }          
            else
            {                                 
                var con = new Connection(Var.con.serverType, Var.con.ServerName, Var.con.DatabaseLogin, Var.con.DatabasePass, Var.con.DatabaseName);
                ConnectionGUID = Guid.NewGuid().ToString();
                ListCon.Add(ConnectionGUID, con);               
                ClientAdd(LocalIP, LocalPort, LocalHost, ComputerName, ComputerUserName, ConnectionGUID); //string LocalIP, string LocalHost, string ComputerName, string ComputerUserName, string ConnectionGUID)
                return con;
            }                     
        }
       
        ///Поиск Соединения, но без его создания, в отличие от GetUserConnection.
        private bool ConnectionUserFind(string ConnectionGUID, out Connection conUser)
        {           
            if (ListCon.ContainsKey(ConnectionGUID) == true)
            {      
                conUser = ListCon[ConnectionGUID];
                return true;
                  
            } else 
            {
                conUser = null;
                return false;
            }
        }
        
        ///Закрытие подключения к БД по имени подключения.
        private void ConnectionUserClose(string ConnectionGUID)
        { 
            if (ConnectionGUID == "AllClient")
            {
                foreach (KeyValuePair<string, Connection> kvp in ListCon)
                {                                      
                     kvp.Value.ConnectionClose();
                     ListCon.Remove(ConnectionGUID);
                }
            } else
            {
                Connection conUser;
                if (ConnectionUserFind(ConnectionGUID, out conUser)) 
                {
                    conUser.ConnectionClose();
                    ListCon.Remove(ConnectionGUID);
                }
            }           
        }
                
        ///Из локальной базы загружаем список настроек соединения.    
        private void ConnectionListRefresh()
        {                    
            cbConnection.SetDataSourceSQL(DirectionQuery.Local, "SELECT ConnectionName FROM fbaConList ORDER BY ConnectionName");
            string ConnectionName = Var.conLite.GetValue("SELECT ConnectionName FROM fbaEnterLast WHERE SystemName = '" + Var.SystemName + "' ORDER BY EnterDate DESC LIMIT 1;");
            cbConnection.SelectStr(ConnectionName);         
        }
        
        ///Соединение с БД - основное для сервера приложений.
        private bool Database_Connect()
        {                 
            if (DatabaseConnected) return true;
                         
            string ConnectionName = cbConnection.ComboBoxStr(); 
            if (sys.Enter(ConnectionName, EnterMode.Work, "", ""))
            {
                DatabaseConnected = true;
                lbDatabaseStatus2.ForeColor = Color.Green;
                lbDatabaseStatus2.Text = "Connected";                              
                ConNameServerApp = ConnectionName;
                AddLogServer("Database is connected");                
            } else
            {
                DatabaseConnected = false;
                lbDatabaseStatus2.ForeColor = Color.Red; 
                lbDatabaseStatus2.Text = "Not connected";               
                AddLogServer("Database is disconnected");               
            }  
              
            ClientDelCurrent();
            RefreshClient();
            EnabledOrDisabled();
            return DatabaseConnected;
        }
    
        #endregion Region. Соединение с БД.
        
		#region Region. Сервер приложения на основе TCP соединения. 
       
		///Очередь TCP сервера. 
        private void ServerQueueTCP()
        {                       
            /*try
            {
                //Принимаем клиентов в бесконечном цикле.
                //и ри появлении клиента добавляем в очередь потоков его обработку.
                while (ServerAppConnected)
                {                                                                        
                   
                    ThreadPool.QueueUserWorkItem(ServerProcessTCP, ListenerTCP.AcceptTcpClient());                                                                             
                    Counter++; //Общее количество запросов серверу приложений.   
                    
                    //Action action = () => lbQuery2.Text = Counter.ToString();
                    //lbQuery2.Invoke(action);
                }
            }
            catch (ThreadAbortException ex) 
            {
                //Эту ошибку не обрабатываем, так как эта ошибка - остановка потока и не является ошибкой.
                string s = ex.Message;
            }
            catch (Exception ex) //(SocketException ex)
            {
                //В случае другой ошибки, выводим что это за ошибка.                  
                AddLogServer(ex.Message);  
            }*/    
        }          
		
        ///Обработка запроса от клиента TCP.
        private void ServerProcessTCP(object client_obj)
        {
            /*try
            {              
                string data_OUT      = "";                                                               
                NetworkStream stream;
                var bytes  = new Byte[214748364]; //256
                var client = client_obj as TcpClient;    
                int i;  
                
                //Буфер для принимаемых данных. 
                //Получаем информацию от клиента
                stream = client.GetStream();         
                string data_IN_all = "";
                
                //Принимаем данные от клиента в цикле пока не дойдём до конца.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    //Преобразуем данные в UTF8 string.
                    string data_IN =  System.Text.Encoding.UTF8.GetString(bytes, 0, i); //Default   //System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    string Command = data_IN.Substring(0, 3);                           //Первые три символа - команда серверу приложения.         
                    string Params  = data_IN.Substring(4, data_IN.Length - 4);          //Остальная часть сообщения.                
                     
                    data_IN_all = data_IN_all + data_IN;
                    //sys.SM("data_IN=" + data_IN);
                    //sys.SM("data_IN_all=" + data_IN_all); 
                    
                    //Не работает! Зависает!
                    //Action action = () => tbLogQuery.AppendText(sys.GetDateTimeNow() + " IN: " + data_IN + " OUT: " + data_OUT);
                    //tbLogServer.Invoke(action);
                    
                    data_OUT = data_IN_all;
                    //Преобразуем полученную строку в массив Байт.
                    byte[] msg = System.Text.Encoding.UTF8.GetBytes(data_OUT); //Default    System.Text.Encoding.ASCII.GetBytes(data_OUT);
        
                    //Отправляем данные обратно клиенту (ответ).
                    stream.Write(msg, 0, msg.Length);                                             
                }               
                //Закрываем соединение.
                client.Close();  
            } catch (Exception ex)
            {
                //sys.SM("Ошибка сервера: " + ex.Message);
                string s = ex.Message;
            }*/
        }        
        
        #endregion Region. Сервер приложения на основе TCP соединения.     
        
        #region Region. Сервер приложения на основе HTTP соединения. 
          
        ///Очередь HTTP сервера. 
        private void ServerQueueHTTP()
        {                    
            try    
            {
                
            	//Принимаем клиентов в бесконечном цикле.
                while (true)
                {                                                                                           
                    ThreadPool.QueueUserWorkItem(ServerProcessHTTP, ListenerHTTP.GetContext());                                      
                    QueryCount++; 
                    if (FormShow)
                    {
                        Action action = () => lbQuery2.Text = QueryCount.ToString();                   
                        lbQuery2.Invoke(action);
                    }
                }
            }
            catch (ThreadAbortException ex) 
            {
                //Эту ошибку не обрабатываем, так как эта ошибка - остановка потока и не является ошибкой.
                string s = ex.Message;
            }
            catch (Exception ex) //(SocketException ex)
            {
                //В случае другой ошибки, выводим что это за ошибка.                  
                AddLogServer(ex.Message); 
            }     
        }           
                            
        ///Обработка запроса от клиента HTTP.  
        private void ServerProcessHTTP(object o)   
        {                                                                                      
            //Var.ShowMes = true;
            //sys.SM("request.RawUrl:1"); 
            //return;
            
            
        	var context = o as HttpListenerContext;
            HttpListenerRequest  request  = context.Request;                                                 
            HttpListenerResponse response = context.Response;                                 
            //Var.ShowMes = true;
            //sys.SM("request.RawUrl:" + request.RawUrl); 
            CommandCode    commandCode;
            string ConnectionGUID = ""; 
            string FileName       = "";
            string RequestStrLog  = ""; 
            
            if (!sys.GetComandCode(request.RawUrl, out commandCode, ref ConnectionGUID, ref FileName)) return;
            
            //RequestStr - это тело запроса от клиента.
            string RequestStr = sys.GetRequestString2(context.Request.ContentEncoding, sys.GetBoundary(context.Request.ContentType), context.Request.InputStream);                                                 
           
            //Если клиент прислал файл, то сохраняем в темповой папке.
            //if (FileName != "") CommandCode = "101";
            //return;                                                                
            if (FormShow)
            {
            	RequestStrLog = sys.GetDateTimeNow() + " (" + commandCode.ToString() + "): " + RequestStr.Left(200) + "..."  + Var.CR;
                RequestStrLog = RequestStrLog.Replace(Var.CR, "") + Var.CR;
                Action action = () => tbLogQuery.AppendText(RequestStrLog);
                tbLogServer.Invoke(action);
            }

            //CommandCode - Команда от клиента, список возможных команд:    
            //101. Запись в темповую папку файла, присланного от клиента.  
            //102. Добавить в список клиентов LocalIP, LocalHost, ComputerName, ComputerUserName и вернуть GUID для клиента и настройки подключения.
            //103. Выполнить запрос SELECT и вернуть таблицу результата.
            //104. Выполнить запрос EXEC и вернуть ID последней.
            //105. Выполнить процедуру произвольного проекта и вернуть результат.
            //106. Клиент извещает сервер приложений, о том что он закрывается.    
            //107. Клиент запрашивает доступный порт для запуска локального сервера  HTTP.   
            
            if (commandCode == CommandCode.C101) GetServerResponse_101(ConnectionGUID, RequestStr, request, response); else
            if (commandCode == CommandCode.C102) GetServerResponse_102(ConnectionGUID, RequestStr, response); else  
            if (commandCode == CommandCode.C103) GetServerResponse_103(ConnectionGUID, RequestStr, response); else  
            if (commandCode == CommandCode.C104) GetServerResponse_104(ConnectionGUID, RequestStr, response); else  
            if (commandCode == CommandCode.C105) GetServerResponse_105(ConnectionGUID, RequestStr, response); else  
            if (commandCode == CommandCode.C106) GetServerResponse_106(ConnectionGUID, RequestStr, response); else  
            if (commandCode == CommandCode.C107) GetServerResponse_107(ConnectionGUID, RequestStr, response);  
            //ResponseStr = GetServerResponse(CommandCode, ConnectionGUID, RequestStr);
            //string ResponseStr = "asd123нгшщзхъzxc";//Convert.ToBase64String(fileBuffer);  

            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(ResponseStr); //UTF8 //Default         
            //response.ContentLength64 = buffer.Length;              
            //System.IO.Stream output = response.OutputStream;
            //output.Write(buffer, 0, buffer.Length);                
            //output.Close();           
        }                                                 
                
        #endregion Region. Сервер приложения на основе HTTP соединения. 
               
        #region Region. Обработка сообщения от клиента.
                
        ///Послать в поток на клиент данные.
        private static void AppSendDataToClient(string ResponseStr, HttpListenerResponse response)
        {                       
            byte[] buffer1 = System.Text.Encoding.UTF8.GetBytes(ResponseStr); //UTF8 //Default
            response.ContentLength64 = response.ContentLength64 + buffer1.Length;                       
            response.OutputStream.Write(buffer1, 0, buffer1.Length);
            response.OutputStream.Close();             
        } 
               
        ///Получить параметры, переданные клиентом в запросе серверу.
        private static void ParseRequest(string RequestStr, 
                                     out string LocalIP,
                                     out string LocalPort,
                                     out string LocalHost,
                                     out string ComputerName,
                                     out string ComputerUserName)
        {           
            //Сообщение может выглядеть так:
            //LocalIP=10.77.70.39;LocalHost=COM1389;ComputerName=ANDREY;ComputerUserName=ANDREY;            
            LocalIP          = sys.StringBetween(RequestStr, "LocalIP=",         ";");
            LocalPort        = sys.StringBetween(RequestStr, "LocalPort=",       ";");
            LocalHost        = sys.StringBetween(RequestStr, "LocalHost=",       ";");
            ComputerName     = sys.StringBetween(RequestStr, "ComputerName=",     ";");
            ComputerUserName = sys.StringBetween(RequestStr, "ComputerUserName=", ";");
        }
        
        //Если клиент прислал файл, то сохраняем в темповой папке.
        private string GetServerResponse_101(string ConnectionGUID, string RequestStr, HttpListenerRequest request, HttpListenerResponse response)
        {               
            const string FileName = "temp.dat";
            sys.GetRequestFile(request.ContentEncoding, sys.GetBoundary(request.ContentType), request.InputStream, FileName);
                     
            if (FormShow)
            {
                string RequestStrLog = sys.GetDateTimeNow() + ": Запись файла: " + FileName + Var.CR;      
                Action action = () => tbLogQuery.AppendText(RequestStrLog);
                tbLogServer.Invoke(action);
            }
            
            AppSendDataToClient("Success", response);
            return "";
        } 
                                        
        ///Команда серверу приложений от клиента. Вернуть настройки для прямого подключения клиента и СУБД.
        ///RequestStr  - Запрос от клиента.     
        private void GetServerResponse_102(string ConnectionGUID, string RequestStr, HttpListenerResponse response)
        {                                                                              
            System.Data.DataTable DT;          
            string sql             = ""; 
            string LocalIP         = "";
            string LocalPort       = "";
            string LocalHost       = "";
            string ComputerName     = "";
            string ComputerUserName = "";           
            string ResponseStr = "";
            
        	sql = "SELECT * FROM fbaConList where ConnectionName = '" + ConNameServerApp + "'";
            if (!Var.conLite.SelectDT(sql, out DT)) 
            {
            	ResponseStr = "Ошибка " + ErrorCode.S503.ToString() + ". Ошибка авторизации: " + sql;
                AppSendDataToClient(ResponseStr, response);              
                return;
            }
            string ConnectionName = DT.Value("ConnectionName");
            string ServerName     = DT.Value("ServerName");
            string ServerType     = DT.Value("ServerType");
            string DatabaseName   = DT.Value("DatabaseName");
            string DatabaseLogin  = DT.Value("DatabaseLogin");
            string DatabasePass   = DT.Value("DatabasePass");
            string UserForm       = DT.Value("UserForm");
            string UserLogin      = DT.Value("UserLogin");
            string UserPass       = DT.Value("UserPass");                                           
            ParseRequest(RequestStr, out LocalIP, out LocalPort, out LocalHost, out ComputerName, out ComputerUserName);
            
            Connection conUser;
            ConnectionGUID  = "";
            conUser = ConnectionUserCreate(ref ConnectionGUID, LocalIP, LocalPort, LocalHost, ComputerName, ComputerUserName);
            
            //Вернуть полные настройки подключения, чтобы клиент мог подключиться к БД без сервера приложений.           
            if (Allow102)  //"Command 102 is prohibited on the application server";
            {
                ResponseStr = CommandCode.S209.ToString() + ". ConnectionGUID="  + ConnectionGUID + ";" + 
                       "ConnectionName="  + DT.Value("ConnectionName") + ";" + 
                       "ServerName="      + DT.Value("ServerName")     + ";" + 
                       "ServerType="      + DT.Value("ServerType")     + ";" +                                                
                       "DatabaseName="    + DT.Value("DatabaseName")   + ";" + 
                       "DatabaseLogin="   + DT.Value("DatabaseLogin")  + ";" + 
                       "DatabasePass="    + DT.Value("DatabasePass")   + ";" + 
                       "UserForm="        + DT.Value("UserForm")       + ";" + 
                       "UserLogin="       + DT.Value("UserLogin")      + ";" + 
                       "UserPass="        + DT.Value("UserPass")       + ";" +
                       "ConnectionDirect=true;";
                 AppSendDataToClient(ResponseStr, response);
                 return;
            }
            
            //Если 102 запрещена, то возвращаем только GUID соединения и тип СУБД.
            //Получается так: что если сервер приложений возвращает 
            //настройки подключения к БД, то клиент работает напрямую с базой, 
            //если не возвращает, то клиент работает через сервер приложений.
            ResponseStr = CommandCode.S210.ToString() + ". ConnectionGUID=" + ConnectionGUID + ";ServerType=" + ServerType + ";ServerSys=" + Var.con.serverType + ";ConnectionDirect=false;";
            AppSendDataToClient(ResponseStr, response);               
        }
                 
        ///Команда серверу приложений от клиента SELECT.
        private void GetServerResponse_103(string ConnectionGUID, string RequestStr, HttpListenerResponse response)
        {            
            //Выполнить запрос, который указан в RequestStr и вернуть таблицу результата.
            string ResponseStr = "";
            Connection conUser;
            if (!ConnectionUserFind(ConnectionGUID, out conUser)) 
            {
                ResponseStr = "Ошибка " + ErrorCode.S501.ToString() + ". Сессия с сервером не найдена!";
                AppSendDataToClient(ResponseStr, response);               
                return;
            }
            
            System.Data.DataSet DS;
            string ErrorText = "";
            const bool ErrorShow = false;
            if (!conUser.SelectDS(RequestStr, out DS, out ErrorText, ErrorShow)) 
            {
                ResponseStr = "Ошибка " + ErrorCode.S502.ToString() + " выполнения запроса: " + Var.CR + ErrorText + Var.CR + RequestStr;
                AppSendDataToClient(ResponseStr, response);               
                return;
            }
             
            AppSendDataToClient(sys.DataSetToStr(DS), response);                          
        }
        
        ///Команда серверу приложений от клиента.
        private void GetServerResponse_104(string ConnectionGUID, string RequestStr, HttpListenerResponse response)
        {
            GetServerResponse_103(ConnectionGUID, RequestStr, response);
        }
        
        //Выполнить процедуру произвольного проекта и вернуть результат.
        private void GetServerResponse_105(string ConnectionGUID, string RequestStr, HttpListenerResponse response)
        {        
            try
            {
                //Первые два параметра - это Имя проекта и Имя метода, остальные - это параметры метода.
                //Поэтому первые два параметра убираем.
                string[] arrstr = RequestStr.Split(';');
                var arr2 = new string[arrstr.Count() - 2];
                for (int i = 0; i < arrstr.Count() - 2; i++)
                    arr2[i] = arrstr[i + 2];                     
                string resultstr = sys.CallS(arrstr[0], arrstr[1], arr2);
                AppSendDataToClient(resultstr, response);
                response.OutputStream.Close();                 
            }   catch (Exception ex)
            {
                 AppSendDataToClient("Ошибка " + ErrorCode.S504.ToString() + "при выполнении кода на сервере: " + ex.Message, response);
                 response.OutputStream.Close();  
            }                                                              
        }
        
        ///Клиент изещает сервер приложений о том, что он закрывается.
        private void GetServerResponse_106(string ConnectionGUID, string RequestStr, HttpListenerResponse response)
        {
            ConnectionUserClose(ConnectionGUID);  //Удаление GUID из массива гуидов.            
            DeleteClient(ConnectionGUID);         //Удаление клиента из таблицы в БД.                         
            DeleteClientFromGrid(ConnectionGUID); //Удаление клиента из таблицы в приложении.  
            ClientCount--;  //Уменьшаем счетчик клиентов.
            AppSendDataToClient("goodby", response);
            response.OutputStream.Close();
            if (FormShow)
            {                 
                Action action = () => lbClientCount2.Text = ClientCount.ToString();
                lbClientCount2.Invoke(action); 
            }
        }

        ///107. Клиент запрашивает доступный порт для запуска локального сервера  HTTP.
        private void GetServerResponse_107(string ConnectionGUID, string RequestStr, HttpListenerResponse response)
        {
            string sql = "UPDATE fbaClientCurrent set LocalPort = " + Var.CR +
                         "(SELECT MAX(LocalPort) + 1 AS LocalPort FROM fbaClientCurrent " + Var.CR +
                         "WHERE LocalIP = (SELECT LocalIP FROM fbaClientCurrent WHERE ConnectionGUID = '" +
                         ConnectionGUID + "'))" + Var.CR +
                         "WHERE ConnectionGUID = '" + ConnectionGUID + "';" + Var.CR +
                         "SELECT LocalPort FROM fbaClientCurrent   WHERE ConnectionGUID = '" + ConnectionGUID + "'";
            string LocalIP = sys.GetValue(DirectionQuery.Remote, sql);
            AppSendDataToClient(LocalIP, response);
            response.OutputStream.Close();
        }

        #endregion Region. Обработка сообщения от клиента.

        #region Region. Старт и остановка сервера приложений и соединения с БД.

        ///Старт сервера приложений.
        private bool ListenerStart()
        {
            if (!DatabaseConnected)
            {
                sys.SM("Database Server is not connected!");
                return false;
            }
            
            if (ServerAppConnected) return true;
            
            //Максимальное и минимальное количество рабочих потоков
            ThreadPool.SetMaxThreads(Var.MaxThreadsCount, Var.MaxThreadsCount);
            ThreadPool.SetMinThreads(Var.MinThreadsCount, Var.MinThreadsCount);                                                       
            
            Var.QueryTimeout = cbTimeout.Text.ToInt();
            int Port = comboBoxPort.Text.ToInt(); //Convert.ToInt32(
            
            //Запускаем Listener и начинаем слушать клиентов.               
            if (SRVAppType == "HTTP")
            {
                try
                {                   
                    string adr = "";
                    //Пример:
                    //string arrIPv4 = @"http://" + Var.LocalIP + @":" + Port + @"/";
                    //string arrIPv6 = @"http://" + @"[fe80:0:0:0:d82a:ce0f:4d01:7cb1]:7145/";
                    //if (Var.LocalIP.IndexOf(':') > -1) adr = @"http://" + @"[" + Var.LocalIP + @"]:" + Port + @"/";
                    //else 
                    adr = @"http://" + Var.LocalIP + @":" + Port + @"/";
                    //adr = @"http://*:" + Port + @"/";
                	ListenerHTTP = new HttpListener();
                	ListenerHTTP.IgnoreWriteExceptions = true;
                    ListenerHTTP.Prefixes.Add(adr);
                    ListenerHTTP.Start();  
                    threadserver = new Thread(ServerQueueHTTP);  
                  
                } catch (Exception ex)
                {
                    sys.SM(ex.Message);
                    return false;
                }                            
            } 
            //if (SRVAppType == "TCP")
            //{                
            //    try
            //    {
            //        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            //        ListenerTCP = new TcpListener(localAddr, Port);
            //        ListenerTCP.Start();
            //        threadserver = new Thread(ServerQueueTCP);       
            //    } catch (Exception ex)
            //    {
            //        sys.SM(ex.Message);
            //        return false;
            //    }                        
            //}
                
            ServerAppConnected = true;
            lbAppStatus2.ForeColor = Color.Green; 
            lbAppStatus2.Text      = "Running";                                                     
            threadserver.Start();
               
            AddLogServer("Application Server is running"); 
            return true;
        }       
   
        ///Остановка сервера приложений.
        private void ListenerStop()
        {                       
            if ((ListenerHTTP != null) && (ListenerHTTP.IsListening)) 
            {                  
                try
                {
                    ListenerHTTP.Stop();                   
                    ServerAppConnected = false;
                    lbAppStatus2.ForeColor = Color.Red;
                    lbAppStatus2.Text      = "Stopped";    
                    threadserver.Abort();                    
                    AddLogServer("Application Server is stopped");                
                } catch (Exception ex)
                {
                    sys.SM(ex.Message);
                }
            }
            
            //if (SRVAppType == "TCP")
            //{                                 
            //    if ((ListenerTCP != null) && (ListenerTCP.Server.Connected)) 
            //    {
            //        ListenerTCP.Stop();
            //        //StopServerApp();
            //    }
            //}           
                                                                                       
        }          
               
        ///Остановка сервера приложений и разрыв соединения с БД.
        private bool ConnectionCloseAll()
        {          
            Database_Disconnect();
            //if (threadserver != null)
            //{
            //    threadserver.Abort();
            //    //threadserver.Join();   
            //}                      
            AddLogServer("Application Server App is closed");                         
            return true;
        }
        
        ///Закрытие сервера приложений.
        private bool ProgramClose()
        {            
            bool Res;
            Res = sys.SM("Close Applivation Server?", MessageType.Question);
            if (Res == false) return false;           
            ConnectionCloseAll();
            notifyIcon1.Visible    = false;           
            return true;
        } 
        
        ///Разрыв соединения с БД.
        private void Database_Disconnect()
        { 
            ListenerStop();
            ConnectionUserClose("AllClient");  
            if (Var.con != null) Var.con.ConnectionClose();                        
            DatabaseConnected = false;
            lbDatabaseStatus2.Text = "Not connected";
            lbDatabaseStatus2.ForeColor = Color.Red;
            AddLogServer("Database is disconnected");
            EnabledOrDisabled();
        }
               
        #endregion Region. Старт и остановка сервера приложений и соединения с БД.
        
		#region Region. Работа со списком клиентов. 
		
        ///Удалить все записи из таблицы текущих клиентов.
        private void ClientDelCurrent()
        {   
            //Вызывать при запуске приложении и остановке App сервера. 
            if (!DatabaseConnected) return;     
            Var.con.Exec("DELETE FROM fbaClientCurrent");
        }

        ///Обновить таблицы клиентов, после входа нового клиента.        
        private void RefreshClient()
        {       
            if (!DatabaseConnected) 
            {                 
                dgClientCurrent.DataSource = null;                                      
                return;
            }
            try
            {
                Var.con.SelectGV("SELECT Number, EnterDate, LocalIP, LocalPort, LocalHost, ComputerName, ComputerUserName, ConnectionGUID FROM fbaClientCurrent", dgClientCurrent);
                Var.con.SelectGV("SELECT Number, EnterDate, LocalIP, LocalPort, LocalHost, ComputerName, ComputerUserName, ConnectionGUID FROM fbaClientAll",     dgClientAll);                                                                       
                for (int i = 0; i < dgClientCurrent.Rows.Count; i++)                             
                {                     
                    dgClientCurrent.Rows[i].Cells["UserCheck"].Value = "False";
                    dgClientCurrent.Rows[i].Cells["ClientMessage"].Value = "";
                }
            }  catch
            {
                //string s = ex.Message;
                //sys.SM(ex.Message); //Возникает ошибка попытка использования компонента, соданного не из этого потока.
            }           
        }

        ///Проверка существующих клиентов.
        private void CheckClientExists()
        {
            RefreshClient();
            if (dgClientCurrent.RowCount == 0) return;
            MarkClients(true);
            Var.ShowMes = false; //Отключаем вывод всех ошибок. Если клиент недоступен будет ошибка - невозможно соединиться с сервером.
            ClientSendMessage(CommandCode.S205); //Проверка существования клиентов.  
            Var.ShowMes = true;
            int n = 0;
            while (n < dgClientCurrent.RowCount)
            {
                if (dgClientCurrent.Rows[n].Cells["ClientMessage"].Value.ToString() != "GUID Ok.")
                {
                    string ConnectionGUID = dgClientCurrent.Rows[n].Cells["ConnectionGUID"].Value.ToString();
                    DeleteClient(ConnectionGUID);
                    dgClientCurrent.Rows.RemoveAt(n); //Удаление из таблице в локальной БД.
                }
                else n++;
            }
            MarkClients(false);
        }

        ///Удаление клиента из таблицы в БД.
        private void DeleteClient(string connectionGUID)
        {
            string sql = "DELETE FROM fbaClientCurrent WHERE ConnectionGUID = '" + connectionGUID + "'";
            Var.con.Exec(sql);

        }

        ///Удаление клиента из таблицы в приложении.
        ///Можно было конечно через селект таблицу обновить, но ладно. Может так быстрее будет.
        private void DeleteClientFromGrid(string ConnectionGUID)
        {
            int n = 0;
            while (n < dgClientCurrent.RowCount)
            {
                if (dgClientCurrent.Rows[n].Cells["ConnectionGUID"].Value.ToString() == ConnectionGUID)
                {                   
                    dgClientCurrent.Rows.RemoveAt(n); //Удаление из таблице в локальной БД.
                    return;
                }
                n++;
            }
        }

        ///Добавление нового клиента к списку.
        private void ClientAdd(string LocalIP, string LocalPort,  string LocalHost, string ComputerName, string ComputerUserName, string ConnectionGUID)
        {                         
            string sql = 
            "INSERT INTO fbaClientAll      (EntityID, Number, EnterDate, LocalIP, LocalPort, LocalHost, ComputerName, ComputerUserName, ConnectionGUID) " +
                "SELECT 110 AS EntityID, " + ClientCount.ToString() + ", " + sys.DateTimeCurrent() + " AS EnterDate, " +
            "'" + LocalIP + "','" + LocalPort + "','" + LocalHost + "','" + ComputerName + "','" + ComputerUserName + "','" + ConnectionGUID + "' WHERE '" + LocalIP + "' NOT IN (SELECT LocalIP FROM fbaClientAll);" + Var.CR +
                    
            "INSERT INTO fbaClientCurrent (EntityID, Number, EnterDate, LocalIP, LocalPort, LocalHost, ComputerName, ComputerUserName, ConnectionGUID) " +
            "SELECT 111 AS EntityID, " + ClientCount.ToString() + ", " + sys.DateTimeCurrent() + " AS EnterDate, " +
            "'" + LocalIP + "','" + LocalPort + "','" + LocalHost + "','" + ComputerName + "','" + ComputerUserName + "','" + ConnectionGUID + "';";
                
            if (!Var.con.Exec(sql)) return;
            ClientCount++;  //Увеличиваем счетчик клиентов. 
            if (FormShow)
            {                
                Action action = () => lbClientCount2.Text = ClientCount.ToString();
                lbClientCount2.Invoke(action); 
                RefreshClient();
            }
        }                               
                          
        ///Послать сообщение клиентам.
        private void ClientSendMessage(CommandCode commandCode)
        {                                  
            try
            {                
                dgClientCurrent.EndEdit();
                string Mes = "";
                if (commandCode == CommandCode.S201) Mes = "Close";
                if ((commandCode == CommandCode.S202) || (commandCode == CommandCode.S203) || (commandCode == CommandCode.S204))
                {
                    string ValueText = "Внимание! Вам необходимо завершить работу с программой для установки обновления!";
                    if (!sys.InputValue("Сообщение клиенту", "Сообщение:", SizeMode.Large, ValueType.String, ref ValueText)) return;
                    Mes = ValueText;
                }
                if (dgClientCurrent == null) return;
                if (dgClientCurrent.Rows == null) return;
                
                //foreach (DataGridViewRow row in dgClientCurrent.Rows)
                for (int i = 0; i < dgClientCurrent.Rows.Count; i++)                             
                {                                //(dgClientCurrent.DataSource as System.Data.DataTable).Rows[0]["UserCheck"].ToString();
                    int Port = Var.ServerAppPortDefault + 1;
                    
                    //Ошибка возникает Ссылка не указывает на экземпляр объекта, т.к. CheckBox не существует, поэтому так:
                    string UserCheck = "False";
                    if (dgClientCurrent.Rows[i].Cells["UserCheck"].Value != null)
                        //UserCheck         = sys.DGRowInt(dgClientCurrent, i, "UserCheck");
                        UserCheck = dgClientCurrent.Rows[i].Cells["UserCheck"].Value.ToString();
                    //string LocalIP        = sys.DGRowInt(dgClientCurrent, i, "LocalIP");
                    //string LocalPort      = sys.DGRowInt(dgClientCurrent, i, "LocalPort");                    
                    //string ConnectionGUID = sys.DGRowInt(dgClientCurrent, i, "ConnectionGUID");

                    string LocalIP        = dgClientCurrent.Rows[i].Cells["LocalIP"].Value.ToString();
                    string LocalPort      = dgClientCurrent.Rows[i].Cells["LocalPort"].Value.ToString();
                    string ConnectionGUID = dgClientCurrent.Rows[i].Cells["ConnectionGUID"].Value.ToString();


                    if (LocalPort != "") Port = LocalPort.ToInt();
                    if ((UserCheck == "True") && (LocalIP != ""))
                    {                                                                  
                        //ClientWork.SendMessageToClientHTTP(LocalIP, Mes); //sys.SM(row.Cells["ID"].Value.ToString());
                        //public static string ServerAppHTTPMessage(string ServerAppName, int ServerAppPort, string CommandCode, string GUID, string CommandText, string FileName, int WaitTimeout = 0)
                        if (commandCode == CommandCode.S205) Mes = ConnectionGUID; 
                        string ResClient = sys.ServerAppSendHTTPMessage("Server", LocalIP, Port, commandCode, "", Mes, "", 2000);
                       
                        //Сообщение от клиента.                    
                        dgClientCurrent["ClientMessage", i].Value = ResClient;  //row.Cells["ClientMessage"].Value = ResClient;                        
                    }
                } 
                   
            }  catch (Exception ex) 
            {
                sys.SM("Ошибка " + ErrorCode.S505.ToString() + " отправки сообщения клиенту: " + ex.Message);
            }
        }                                                              
            
        ///Событие. Как только пользователь вносит изменение в запись (ставит галку UserCheck) изменения применяются.
        private void DgClientCurrentCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).EndEdit();
        }
                 
        ///Отметить/снять отметку с клиентов.
        private void MarkClients(bool Mark)
        {
           try
            {               
                if (dgClientCurrent == null) return;
                if (dgClientCurrent.Rows == null) return;                                        
                for (int i = 0; i < dgClientCurrent.Rows.Count; i++)               
                    dgClientCurrent[1, i].Value = Mark;
                                                
            }  catch (Exception ex) 
            {
                sys.SM("Ошибка " + ErrorCode.S506.ToString() + " отправки сообщения клиенту: " + ex.Message);
            } 
        }
               
        private void TbClient1Click(object sender, EventArgs e)
        {                       
            //Обновление списка клиентов.
            if (sender == tbClient1)
            {
                RefreshClient();
                CheckClientExists();
            }
            
            //203 - Команда показать сообщение Information.  
            if (sender == tbClient2) ClientSendMessage(CommandCode.S203);
            
            //201 - это команда закрытия клиенту.
            if (sender == tbClient3) ClientSendMessage(CommandCode.S201);                                   
                             
            //Отметить клиентов.
            if (sender == tbClient5)  MarkClients(true);
            
            //Cнять отметку с клиентов.
            if (sender == tbClient6)  MarkClients(false);
        }
        
		#endregion Region. Работа со списком клиентов. 			        	        
        
        #region Region. Контекстное меню, события при старте и при сворачивании формы.  						           
        	        		 
        ///Событие. Закрытие сервера приложений крестиком.        
        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ProgramClose();       //Чтобы отменить закрытые, то e.Cancel = true       
        }

        ///При сворачивании-разворачивании формы.
        private void FormServerResize(object sender, EventArgs e)
        {
            bool FormMinimize  = (this.WindowState == FormWindowState.Minimized);           
            FormShow            = !FormMinimize;
            Var.ShowMes         = !FormMinimize;
            ShowInTaskbar       = !FormMinimize; 
            notifyIcon1.Visible = FormMinimize; 
            FormShow            = !FormMinimize;                                                    
        }                     
                
		#endregion Region. Контекстное меню, события при старте и при сворачивании формы.
		
		#region Region. Логирование.
		
		///Добавление строки в лог работы сервера.
        private void AddLogServer(string mes)
        {                      
            mes = sys.GetDate4FileName(DateTime.Now) + " - " + mes + Var.CR;
            Directory.SetCurrentDirectory(FBAPath.PathLog);
            string DateStr = sys.GetDate4FileName(DateTime.Now);
            try
            {                
                File.AppendAllText(FBAPath.PathLog + "FBAServerApp" + DateStr + ".log", mes);   
            } catch (Exception ex)
            {
                string s = ex.Message;
            }
            if (FormShow)
            {
                Action action = () => tbLogServer.AppendText(mes);
                tbLogServer.Invoke(action);
            }
        }         
         	
        ///Событие. Кнопка открытия папки с логами.               
        private void btnOpenDirLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(FBAPath.PathLog);
        }
                       
        ///Событие. Очистка окна лога. Сам файл лога на диске не очищается.
        private void btnServerAppLogClear_Click(object sender, EventArgs e)
        {            
            if (sender == btnServerAppLogClear) tbLogServer.Clear();
            if (sender == btnServerQueryLogClear) tbLogQuery.Clear();
        }

        ///Событие. Логируем все запросы. Если количество текста более 100 строк, то очищаем лог, чтобы не расходывать память.    
        private void TbLogQueryTextChanged(object sender, EventArgs e)
        {
            //Лог на диск не сохраняем.
            if (tbLogQuery.Lines.Length > 100)
            {                 
                tbLogQuery.Clear();
                tbLogQuery.AppendText(sys.GetDateTimeNow() + " Очистка текста лога." + Var.CR);
                tbLogQuery.AppendText(sys.GetDateTimeNow() + " ================================." + Var.CR);
            }
        }
        
        #endregion Region. Логирование.	
        
        #region Region. Кнопки сервера приложений.
               	   						 								
		///Все кнопки.
		private void BtnStartAllClick(object sender, EventArgs e)
        {		   		   
		    //Событие. Установить переменную, которая разрешает подключаться клиентам 
			//к серверу СУБД, минуя сервер приложений. Так как неодобно обращаться к
			//визульному компоненту из другого потока.
			Allow102 = cbAllowDirectConnection.Checked; 
		
			//Запустить все.
		    if (sender == btnStartAll)
		    {
		        if (!Database_Connect()) return;
                if (!ListenerStart()) return;
                EnabledOrDisabled();
		    }
		    
		    //Остановить все.
		    if (sender == btnStopAll)
            {
		         ConnectionCloseAll();
		         EnabledOrDisabled();
		    }
		    
		    //Редактирование списка подключений.  
            if (sender == btnConnectionList)
            {
                new FormConList().ShowDialog();            
                ConnectionListRefresh();  
            }
            
		    //Соединение с СУБД (MSSQL, Postgre, SQLite).
            if (sender == btnDatabaseConnect) Database_Connect();          
                        
            //Событие. Кнопка разрыва соединения с СУБД (MSSQL, Postgre, SQLite).
            if (sender == btnDatabaseDisconnect) Database_Disconnect();                     
            
            //Контекстное меню 1. Разворачивание формы из трея при клике.
            if (sender == cmServer1)
            {
                if (WindowState    != FormWindowState.Minimized) return;                 
                this.WindowState    = FormWindowState.Normal;
                this.Show();
            }
            
            //Контекстное меню 2. Выход из программы.
            if (sender == cmServer2) 
            {
                Var.ShowMes         = true;
                if (ProgramClose()) Environment.Exit(0);
                Var.ShowMes         = false;
            }
                       
            //Кнопка Старт сервера приложений.
            if (sender == btnStart)
            {
                ListenerStart();
                EnabledOrDisabled();   
            }

            //Остановка сервера приложений.
            if (sender == btnStop)
            {
                ListenerStop();
                EnabledOrDisabled();  
            }            
        }						             				      

        ///Событие. Клик на иконке сервера приложений в трее.
        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState != FormWindowState.Minimized) return;
                this.WindowState = FormWindowState.Normal;
            }
            else notifyIcon1.ContextMenuStrip.Show();
        }

        ///Доступность компонентов. Одна процедура на все действия.
		private void EnabledOrDisabled()
		{		     		  
	        btnConnectionList.Enabled       = !DatabaseConnected;
            cbConnection.Enabled            = !DatabaseConnected;
            btnDatabaseConnect.Enabled      = !DatabaseConnected; 
            btnDatabaseDisconnect.Enabled   = DatabaseConnected;
            btnStart.Enabled                = !ServerAppConnected && DatabaseConnected;
		    btnStop.Enabled                 = ServerAppConnected;
		    comboBoxPort.Enabled            = !ServerAppConnected;
		    cbTimeout.Enabled               = !ServerAppConnected;
		    cbAllowDirectConnection.Enabled = !ServerAppConnected;		        
		    btnStartAll.Enabled             = !DatabaseConnected || !ServerAppConnected;
		    btnStopAll.Enabled              = DatabaseConnected || ServerAppConnected;                	
		}
		
        //Разворчивание прогпраммы по клику на иконке в трее.
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            this.WindowState = FormWindowState.Normal;
        }

        #endregion Region. Кнопки сервера приложений.

        #region Region. Действия с лицензиями.
     
        /// <summary>
        /// Подсчет количества работающих клиентов.
        /// </summary>
        /// <returns>Количество работающих клиентов</returns>
        private int GetLicenseCount()
        {                                 
            //Если последний запрос от клиента был больше, чем 15 минут назад, 
            //считаем клиента отключенным. Но соединение не удаляем.
            DateTime LimitDateTime = DateTime.Now.AddMinutes(-15);
            int LicenseCountIN = 0;
            foreach (Connection conUser in ListCon.Values)
            {
                if (conUser.LastQueryDateTime > LimitDateTime) LicenseCountIN++;
            }
            return LicenseCountIN;
        }       
        
        ///Раз в 5 сек. обновляем количество свободных/занятых лицензий.
        private void TimerLicenseCountTick(object sender, EventArgs e)
        {
        	lbLicenseCount2.Text = GetLicenseCount().ToString();
        }
           
        /// <summary>
        /// Проверка количества лицензий.
        /// </summary>
        private void GetLicense()
        {              
            const string sql = 
                "SELECT LicenseCount, DateStart, DateEnd, LicenseKey " +
                "FROM fbaLicense WHERE " + 
                "DateCreate = (SELECT MAX(DateCreate) " +
                "FROM fbaLicense WHERE DateStart <= datetime(CURRENT_TIMESTAMP, 'localtime'))";
            System.Data.DataTable DT;
            if (!Var.conLite.SelectDT(sql, out DT)) 
            {
                sys.SM("Ошибка " + ErrorCode.S507.ToString() + "проверки количества лицензий.");
                Environment.Exit(0);
            }
               
            LicenseCount     = DT.Value("LicenseCount");           
            LicenseDateStart = DT.Value("DateStart");
            LicenseDateEnd   = DT.Value("DateEnd");
            LicenseKey       = DT.Value("LicenseKey");           
            if (LicenseCount     == "") LicenseCount     = "0";
            if (LicenseDateStart == "") LicenseDateStart = Var.MinStateDateSQL;                      
            if (LicenseDateEnd   == "") LicenseDateEnd   = Var.MinStateDateSQL;            
            
            //Добавление лицензий.
            //Высылается инфа сформированная через кнопку ServerInfo,
            //На основании этой инфы, формируетя ключ, в котором зашито:
            //1. Инфа сервера
            //2. Количество лицензий
            //3. Дата формирования ключа
            //4. Дата начала
            //5. Дата окончания
            
            //При установке лицензии ключ и все расшифрованные данные из ключа записываются Чтобы установить кол-во лицензий, в таблицу fbaLicense.
            //При старте сервера приложений выбирается последний ключ, и проверяется его корректность,
            //Сравниваются данные по серверу с тем что в ключе, если все верно, то используется те параметры, которые были в расшифрованном ключе.
            //Также проверяется соответствие того, что в таблице fbaLicense, если не совпадает с параметрами из расшифрованного ключа, то ошибка.                                 
        }
      
        /// <summary>
        /// Получить инфу о сервере.
        /// </summary>
        private void GetServerInfo()
        {
            GetLicense();
            string ProcessorID   = Protector.GetProcessor_ID();
            string MotherBoardID = Protector.GetMotherBoard_ID();
            string DateCreate = sys.DateTimeToSQLStr(DateTime.Now);  //"yyyy-MM-dd mm:ss.fff"
            string Tmp = "PrID=" + ProcessorID       + ";" + 
                         "MBID=" + MotherBoardID     + ";" + 
                         "LCnt=" + LicenseCount      + ";" +  
                         "DCr="  + sys.DateTimeToSQLStr(DateTime.Now) + ";" +                               
                         "DSt="  + LicenseDateStart  + ";" +
                         "DEn="  + LicenseDateEnd    + ";" + 
                         "LK="   + LicenseKey        + ";";
            string ServerInfo = "<License>" + Tmp.EncryptAES("ServerInfo") + "</License>";                              
            sys.SM(ServerInfo, MessageType.Information, "ServerInfo");
        }       
        
        ///Разделяем параметр на несколько, по разделютелю точка с запятой.
        private void GetServernfo(string KeyStr, 
                              out string ProcessorID,
                              out string MotherBoardID,                            
                              out string LicenseCountIN,
                              out string DateCreate,
                              out string DateStart,
                              out string DateEnd,
                              out string LicenseKeyIN)
        {                       
            ProcessorID    = KeyStr.StringBetween("PrID=", ";");
            MotherBoardID  = KeyStr.StringBetween("MBID=", ";");           
            LicenseCountIN = KeyStr.StringBetween("LCnt=", ";"); 
            DateCreate     = KeyStr.StringBetween("DCr=",  ";"); 
            DateStart      = KeyStr.StringBetween("DSt=",  ";"); 
            DateEnd        = KeyStr.StringBetween("DEn=",  ";"); 
            LicenseKeyIN   = KeyStr.StringBetween("LK=",   ";");   
        }    
               
        ///Проверка лицензии.    
        private bool LicenseCheck1(string License,                                  
                                  out string LicenseCountIN, 
                                  out string LicenseDateCreateIN,
                                  out string LicenseDateStartIN,
                                  out string LicenseDateEndIN,
                                  out string LicenseKeyIN)
        {
               
            LicenseCountIN      = "";
            LicenseDateCreateIN = "";
            LicenseDateStartIN  = "";
            LicenseDateEndIN    = "";            
            LicenseKeyIN        = "";
            
            //Расшифровываем ServerInfo
            string ServerInfo;
            try
            {
                ServerInfo = License.Replace("<License>", "").Replace("</License>", "").DecryptAES("ServerInfo");
              
            } catch 
            {
                sys.SM("Ошибка " + ErrorCode.S508.ToString() + " проверки лицензии!");
                return false;
            }
             
            string ProcessorID    = "";
            string MotherBoardID  = "";           
            LicenseCountIN      = "";
            LicenseDateCreateIN = "";
            LicenseDateStartIN  = "";
            LicenseDateEndIN    = "";            
            LicenseKeyIN        = "";
            
            GetServernfo(ServerInfo, 
                         out ProcessorID,
                         out MotherBoardID,                       
                         out LicenseCountIN,
                         out LicenseDateCreateIN,
                         out LicenseDateStartIN,
                         out LicenseDateEndIN,
                         out LicenseKeyIN);
            string Errors = ErrorCode.S601.ToString();
            if (ProcessorID         == "") Errors = Errors + "," + ErrorCode.S602.ToString();                         
            if (MotherBoardID       == "") Errors = Errors + "," + ErrorCode.S603.ToString();                              
            if ((LicenseCountIN     == "") || (LicenseCountIN == "0")) Errors = Errors + ",60" + ErrorCode.S604.ToString();                             
            if (LicenseDateCreateIN == "") Errors = Errors + "," + ErrorCode.S605.ToString();                      
            if (LicenseDateStartIN  == "") Errors = Errors + "," + ErrorCode.S606.ToString();                          
            if (LicenseDateEndIN    == "") Errors = Errors + "," + ErrorCode.S607.ToString();                             
            if (LicenseKeyIN        != "") Errors = Errors + "," + ErrorCode.S608.ToString();                                                                  
            
            if (sys.StringToDateTime(LicenseDateCreateIN) > DateTime.Now) Errors = Errors + "," + ErrorCode.S609.ToString();     
            if (sys.StringToDateTime(LicenseDateCreateIN) <= DateTime.Now.AddDays(-366)) Errors = Errors + "," + ErrorCode.S610.ToString();     
       
            if (!sys.DateTimeConvertStr(ref LicenseDateCreateIN, "dd.MM.yyyy", "yyyy-MM-dd HH:mm:ss.fff")) sys.SM("Ошибка " + ErrorCode.S509 + "преробразования даты");
            if (!sys.DateTimeConvertStr(ref LicenseDateStartIN,  "dd.MM.yyyy", "yyyy-MM-dd HH:mm:ss.fff")) sys.SM("Ошибка " + ErrorCode.S510 + "преробразования даты");
            if (!sys.DateTimeConvertStr(ref LicenseDateEndIN,    "dd.MM.yyyy", "yyyy-MM-dd HH:mm:ss.fff")) sys.SM("Ошибка " + ErrorCode.S511 + "преробразования даты");        

            //Проверяем, что у нас те же самые ProcessorID и MotherBoardID, что и в устанавливаемой лицензии.         
            int ChangeCount       = 0; 
            string ProcessorID2   = Protector.GetProcessor_ID();
            string MotherBoardID2 = Protector.GetMotherBoard_ID();            
            if (ProcessorID   != ProcessorID2)   ChangeCount++;                                                
            if (MotherBoardID != MotherBoardID2) ChangeCount++;                                                               
            if (ChangeCount > 1) Errors = Errors + "," + ErrorCode.S611.ToString();                                          
            if (Errors != "S601")
            {
                sys.SM("При проверке лицензии возникли ошибки: " + Var.CR + Errors);
                return false;
            }
            return true;
        }
                   
        /// <summary>
        /// Проверка лицензии.
        /// </summary>
        /// <param name="License"></param>
        private void LicenseCheck2(string License)
        {          
            string LicenseCountIN;
            string LicenseDateCreateIN;
            string LicenseDateStartIN;
            string LicenseDateEndIN;
            string LicenseKeyIN;
                                                     
            if (!LicenseCheck1(License,                               
                             out LicenseCountIN, 
                             out LicenseDateCreateIN,
                             out LicenseDateStartIN,
                             out LicenseDateEndIN,
                             out LicenseKeyIN)) return;
            string Mes = "Проверка прошла успешно: " + 
                "Количество лицензий:     " + LicenseCountIN + Var.CR +
                "Дата создания ключа:     " + LicenseDateCreateIN + Var.CR + 
                "Дата начала действия:    " + LicenseDateStartIN + Var.CR +
                "Дата окончания действия: " + LicenseDateEndIN;
            sys.SM(Mes, MessageType.Information);                         
        }
         
        /// <summary>
        /// Добавление лицензии.
        /// </summary>
        /// <param name="License"></param>
        private void AddLicense(string License)
        {             
            string LicenseCountIN;
            string LicenseDateCreateIN;
            string LicenseDateStartIN;
            string LicenseDateEndIN;
            string LicenseKeyIN;                                                    
            if (!LicenseCheck1(License,                               
                          out LicenseCountIN, 
                          out LicenseDateCreateIN,
                          out LicenseDateStartIN,
                          out LicenseDateEndIN,
                          out LicenseKeyIN)) return;                 
            string sql = string.Format("INSERT INTO fbaLicense " +
            "(EntityID, LicenseKey, LicenseCount, DateCreate, DateStart, DateEnd) " +
            " VALUES ({0},'{1}',{2},'{3}','{4}','{5}')", 
            "123", License, LicenseCountIN, LicenseDateCreateIN, LicenseDateStartIN, LicenseDateEndIN);
            if (!Var.con.Exec(sql)) return;   //2017-09-12 15:21:46        
            RefreshLicense();
            string Mes = "Лицензия успешно добавлена:" + Var.CR +
                "Количество лицензий:     " + LicenseCountIN + Var.CR +
                "Дата создания ключа:     " + LicenseDateCreateIN + Var.CR + 
                "Дата начала действия:    " + LicenseDateStartIN + Var.CR +
                "Дата окончания действия: " + LicenseDateEndIN;
            sys.SM(Mes, MessageType.Information);                                  
        }     
          
        /// <summary>
        /// Удаление лицензии.
        /// </summary>
        private void LicenseDelete()
        {
            if (Var.con == null) 
            {
                sys.SM("Нет подключения к БД!");
                return;
            }
            string LicenseID   = dgvLicense.DataGridViewSelected("ID");
            if (LicenseID == "") return;
            string sql = "DELETE FROM fbaLicense WHERE ID = " + LicenseID;
            if (!Var.con.Exec(sql)) return;
            sys.SM("Лицензия удалена!", MessageType.Information); 
            RefreshLicense();
        }
              
        /// <summary>
        /// Обновление таблицы лицензий.
        /// </summary>
        private void RefreshLicense()
        {
            const string sql = "SELECT ID, LicenseCount, DateCreate, DateStart, DateEnd FROM fbaLicense ORDER BY DateStart";
            if (Var.con == null) 
            {
                sys.SM("Нет подключения к БД!");
                return;
            }
            Var.con.SelectGV(sql, dgvLicense);
        }               
          
        /// <summary>
        /// Кнопки действий с лицезиями.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbLicense1Click(object sender, EventArgs e)
        {                      
            //Обновление таблицы лицензий.
            if (sender == tbLicense1) RefreshLicense();
            
            //Проверка лицензии.
            if (sender == tbLicense2) 
            {               
                string ValueText = "";
                if (!sys.InputValue("Лицензия", "Ключ:", SizeMode.Large, ValueType.String, ref ValueText)) return;           
                LicenseCheck2(ValueText);
            }
            
            //Добавление лицензии.
            if (sender == tbLicense3) {
                string ValueText = "";
                if (!sys.InputValue("Лицензия", "Ключ:", SizeMode.Large, ValueType.String, ref ValueText)) return;           
                AddLicense(ValueText);
            }
            
            //Удаление лицензии.
            if (sender == tbLicense4) LicenseDelete();
            
            //Информация о сервере для того чтобы сформировать лицензию.
            if (sender == tbLicense5) GetServerInfo();
        }

        #endregion Region. Действия с лицензиями.                      
        
        /// <summary>
        /// Кнопки главного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuN1_1_Click_1(object sender, EventArgs e)
        {            
            //Закрыть сервер приложений
            if (sender == MainMenuN1_1)
            {
                Var.ShowMes = true;
                if (ProgramClose()) Environment.Exit(0);
                Var.ShowMes = false;
            }

            //Форма About
            if (sender == MainMenuN2_1)
            {
                new FormAbout().Show();
            }
        }
        
		/*void Button1Click(object sender, EventArgs e)
		{
			CommandCode commandCode;
		
			string RawUrl = @"/C102;;"; 
			string ConnectionGUID = "";
			string FileName = "";
				
			sys.GetComandCode(RawUrl, out commandCode, ref ConnectionGUID, ref FileName);
		}*/

        
    }
}
