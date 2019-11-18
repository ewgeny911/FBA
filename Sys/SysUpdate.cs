/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 25.08.2017
 * Время: 23:58
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;     

namespace FBA
{     
    /// <summary>
    /// Статический класс. Класс для обновления программы.
    /// </summary>
    public static class SysUpdate
    {        
        /// <summary>
        /// Обновление программы. Главный метод запуска обновления.
        /// </summary>
        /// <param name="showMes">Показыват сообщения об ошибках</param>
        /// <param name="resultMessage">Собщение пользователю после завершения обновления</param>
        /// <returns></returns>
        public static bool UpdateProgram(bool showMes, out string resultMessage)
        {
            try
            {
                string version; 	 //возвращает номер новой версии, на которую нужно обновиться.
                string numberUpdate; //возвращает порядковый номер обновления.  
               
                if (!UpdateCheck(out version, out numberUpdate, out resultMessage, showMes)) return true;
                            
                if (showMes && resultMessage != "")
                {
                    resultMessage += Var.CR + "Обновить программу?";
                    if (!sys.SM(resultMessage, MessageType.Question, "Проверка обновления")) return true;
                }
 				bool needUpdate; 	
                if (!UpdateDownload(version, numberUpdate, out resultMessage, out needUpdate, showMes)) return false;
                return UpdateRun(); //Запуск обновления.      
            }
            catch (Exception ex)
            {
                resultMessage = "Ошибка при обновлении програмы: " + ex.Message;
                if (showMes) sys.SM(resultMessage);
                return false;
            }
        }
              
        /// <summary>
        /// Запуск EXE файла, который копирует файлы обновления, после того как они были загружены с сервера.
        /// После скачивания обновления текущей программой (это может быть ClientApp, Utility)
        /// запускается эта процедура, которая запускает обновляльщик (Update.exe) и завершает текущую программу.
        /// Обновляльщик ждет некоторое время, если запущены какие либо exe файлы, 
        /// то пытается остановить их работу и если все успешно, то копирует файлы обновления
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public static bool UpdateRun()
        {         
            var fileName = FBAPath.PathMain + "Updater.exe";
            Process run;
            if (!FBAFile.FileRunEXE(out run, fileName, Var.SystemName)) return false;
            Environment.Exit(0);
            return true;
        }
             
        /// <summary>
        /// Проверка на то что нужно обновить программу.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="numberUpdate"></param>
        /// <param name="resultMessage"></param>  
        /// <param name="showMes">Показывать сообщения об ошибках</param>
        /// <returns></returns>
        public static bool UpdateCheck(out string version, 
                                       out string numberUpdate, 
                                       out string resultMessage,            				
            						   bool showMes)
        {
            version = "";
            numberUpdate = "";
            resultMessage = "";           
            try
            {
                var sql = "";
                if (Var.con.serverTypeRemote == ServerType.MSSQL)
                    sql = "SELECT TOP 1 Version, NumberUpdate FROM fbaUpdate " +
                          "WHERE UserUpdate = 1 AND Version = (SELECT TOP 1 CurrentVersion FROM fbaUpdate);";
                else 
                	if ((Var.con.serverTypeRemote == ServerType.SQLite) || (Var.con.serverTypeRemote == ServerType.Postgre))
                    sql = "SELECT Version, NumberUpdate FROM fbaUpdate " +
                          "WHERE UserUpdate = 1 AND Version = (SELECT CurrentVersion FROM fbaUpdate LIMIT 1) LIMIT 1;";
                if (sql == "") return false;
                sys.GetValue(DirectionQuery.Remote, sql, out version, out numberUpdate);
                if (version == "")
                {
                    resultMessage = "Ошибка при проверке обновления: Нет информации об актуальной версии приложения!";
                    if (showMes) sys.SM(resultMessage, MessageType.Information);
                    return false;
                }
                bool needUpdate = version != Var.ApplicationVersion;
                if (needUpdate)
                    resultMessage = "Требуется обновление." + Var.CR + "Новая версия программы: " + version + Var.CR +
                                    "Номер обновления: " + numberUpdate + Var.CR + "Текущая версия программы: " +
                                    Var.ApplicationVersion;
                else resultMessage = "Обновление не требуется. У Вас уже установлена самая последня версия: " + version + ", номер обновления: " + numberUpdate;
                if (showMes) sys.SM(resultMessage, MessageType.Information);
                return needUpdate;
            }
            catch (Exception ex)
            {
                resultMessage = "Ошибка при проверке обновления: " + ex.Message;
                if (showMes) sys.SM(resultMessage, MessageType.Information);
                return false;
            }
        }
      
        /// <summary>
        /// Проверить неоходимость обновления и скачать обновление программы.
        /// Обновление работает так:
        /// Для того чтобы скачать обновление и обновиться нужно обновление закачать на сервер.
        /// Обновление exe файлов и других файлов клиента возможно только из рабочей базы данных.
        /// Обновление из файловой шары или из ресурса в интернете не сделано.
        /// Закачивает обновление на сервер программа Utility.exe. 
        /// В её коде присаны все файлы, папки, которые нужно закачать на сервер.
        /// Там же указывается список папок или файлов, котороые подлежат удалению.
        /// Все файлы закачиваются на сервер в табличку fbaUpdate. В обновлении участвует только одна табличка.
        /// После этого при запуске Клиент обращается к этой табличку и смотрит, есть ли обновление (проверка по полю Version и CurrentVersion)
        /// Сравниваеся с текущей версии EXE файла. Если обновить нужно, то все файлы скачиваются клиентом в папку Update, предназначенную для этого.
        /// Перед скачиванием папка Update очищается полностью.
        /// Далее клиент запускает файл Updater.exe передавая в параметрах свое имя файла, а сам завершает работу.
        /// Updater.exe полностью независимый EXE, он независит от других файлов программы. Updater.exe заменяет файлы программы файлами из папки Update,
        /// Если при копировании происходит ошибка, то он пытается вернуть прежние версии файлов. После копирования он запускает EXE файл, 
        /// имя которого было передано в параметрах, а сам завершает работу.
        /// Download      - true - скачать файлы обновления, false - только получить данные об обновлении.                 
        /// ResultUpdate  - описание выполненых действий.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="numberUpdate"></param>
        /// <param name="resultMessage"></param>
        /// <param name="needUpdate"></param>
        /// <param name="showMes">false - тихий режим, сообщений пользователю не выдаем.  </param>
        /// <returns>Результат - true - требуется обновить, false - обновление не требуется.</returns>
        public static bool UpdateDownload(string version, string numberUpdate, out string resultMessage, out bool needUpdate, bool showMes)
        {                  
            resultMessage = "";
            DataTable dT1;
            DataTable dT2;
            string sqlLocal;
            long fileSize = 0;
            var fileCount = 0;
            var listDelete = new List<string>();
            string[] listNotDeleted;
            //Очищаем полность папку sys.PathUpdate.       
            if (!FBAFile.DirClean(FBAPath.PathUpdate, out listNotDeleted, true))
            {
                needUpdate = false;
                return false;
            }

            sqlLocal = "select ID, MD5, Path, FullName, ContentType, Operation, Size from fbaUpdate WHERE Version = '" + version + "' ORDER BY Numberupdate, Numberfile; ";
            sys.SelectDT(DirectionQuery.Remote, sqlLocal, out dT1);
            if (dT1.Rows.Count == 0)
            {
                resultMessage = ""; //Ошибка обновления. Не удается найти последниюю версию приложения!";
                needUpdate = false;
                return false;
            }

            var progress = new FormProgress("Обновление программы", "Получение файлов для обновления", dT1.Rows.Count);
            if (showMes) progress.Show();
            for (var i = 0; i < dT1.Rows.Count; i++)
            {
                var id             = dT1.Value(i, "ID");
                var md5Update      = dT1.Value(i, "MD5");
                var pathValue      = dT1.Value(i, "Path");
                var fullName       = dT1.Value(i, "FullName");
                var contentType    = dT1.Value(i, "ContentType");
                var operationL     = dT1.Value(i, "Operation");
                var size           = dT1.Value(i, "Size");
                var fileNameLocal  = fullName.Replace(pathValue, FBAPath.PathMain);
                var FileNameUpdate = fullName.Replace(pathValue, FBAPath.PathUpdate);
                if (operationL == "DELFILE" || operationL == "DELDIR") listDelete.Add(operationL + ": " + fullName);
                if (operationL == "ADDDIR") Directory.CreateDirectory(Path.GetDirectoryName(FileNameUpdate));
                if (operationL == "ADDFILE")
                {
                    var MD5Local = Crypto.FileHashMD5Calc(fileNameLocal); //MD5 локального файла. 
                    var MD5Download = Crypto.FileHashMD5Calc(FileNameUpdate); //MD5 уже скаченного ранее файла.

                    //Если рабочий файл не совпадает с обновлением:
                    if (md5Update != MD5Local)
                    {
                        fileSize = fileSize + Convert.ToInt64(size);
                        fileCount = fileCount + 1;

                        //Если MD5 не совпадает между локальным файлом и файлом для обновления, то скачиваем файл.
                        sqlLocal = "SELECT FileData FROM fbaUpdate WHERE ID = " + id;
                        sys.SelectDT(DirectionQuery.Remote, sqlLocal, out dT2);
                        var FileData = dT2.Value("FileData");
                        Directory.CreateDirectory(Path.GetDirectoryName(FileNameUpdate));
                        if (!FBAFile.FileWriteFromBase64(FileData, FileNameUpdate, out resultMessage, showMes))
                        {
                            resultMessage = "Ошибка обновления. Не удается найти последниюю версию приложения!" +
                                            Var.CR + resultMessage;
                            needUpdate = false;
                            return false;
                        }
                    }
                }
                if (listDelete.Count > 0)
                {
                    //Просто сохраняем в список то, что нужно удалить.
                    var fileName = FBAPath.PathUpdate + "ListDelete.txt";
                    var listStr = string.Join(Var.CR, listDelete.ToArray());
                    File.WriteAllText(fileName, listStr, Encoding.Default);
                }
                if (showMes) progress.Inc();
            }

            progress.Dispose();
            if (fileCount == 0 && listDelete.Count == 0)
            {
                resultMessage = "Обновление не требуется. Все текущие версии файлов совпадают с файлами обновления " +
                                version;
                needUpdate = false;
                return true;
            }

            //Если нужно только удалить папки или файлы, то ставим размер обновления 1 кб, 
            //чтобы не пугать пользователя.            
            if (fileSize == 0) fileSize = 1024;
            var ResStr = "Порядковый номер обновления: " + numberUpdate + Var.CR + "Версия: " + version + Var.CR +
                         "Размер обновления: " + FBAFile.GetFileSizeStr(fileSize, true, true) + Var.CR +
                         "Количество файлов и папок: " + (fileCount + listDelete.Count) + Var.CR +
                         "Текущая версия программы: " + Var.ApplicationVersion;
            resultMessage = "Файлы для обновления скачаны и готовы для установки." + Var.CR + ResStr;
            needUpdate = true;
            return true; //true - обновлять нужно, false - обновление не требуется.
        }
    }
}