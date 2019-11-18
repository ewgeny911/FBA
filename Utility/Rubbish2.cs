
 //                    
                //Разбор сообщения.
                //DataTable DT;                                              
                //sys.DataTableFromString(out DT, StrOUT, out ErrorMes, ErrorShow);   
                
                //ConnectionID  = sys.DTValue(DT, "ConnectionID");
                //ServerName    = sys.DTValue(DT, "ServerName");
                //ServerType    = sys.DTValue(DT, "ServerType");
                //DatabaseName  = sys.DTValue(DT, "DatabaseName");
                //DatabaseLogin = sys.DTValue(DT, "DatabaseLogin");
                //DatabasePass  = sys.DTValue(DT, "DatabasePass");
                //UserForm      = sys.DTValue(DT, "UserForm");
                //UserLogin     = sys.DTValue(DT, "UserLogin");
                //UserPass      = sys.DTValue(DT, "UserPass");
                //string StrIN = "101;" + Var.LocalIP + ";" + Var.LocalHost + ";" + Var.ComputerName + ";" + Var.ComputerUserName;                            
                //string StrOUT = "";
                //string ErrorMes = "";
                //const bool ErrorShow = true;
                //public static string ServerAppHTTPMessage(string CommandCode, string GUID, string CommandText, string FileName, int WaitTimeout = 0)
                
                //if (!sys.ServerAppHTTPMessage('', StrIN, out StrOUT, ErrorMes, ErrorShow)) return false;
                //sys.SM(StrOUT);                                       ServerApp       sys.ServerAppPort                
//======================================================================
            //foreach(var par in ParamStr.Split(' '))
            //{
                //par.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                //if (par.Split('=')[0] == "FormName")     FormName     = par.Split('=')[1].Trim();
            //    if (par.Split('=')[0].ToLower() == "connectionid") ConnectionID = par.Split('=')[1].Trim();
            //    if (par.Split('=')[0].ToLower() == "Mode")     Mode     = (par.Split('=')[1].ToLower() == "true");
            //}
                
            /*string Mes = 
                    "sys.GetParamEnter ConnectionID="    + ConnectionID        + Var.CR + 
                    //"sys.GetParamEnter FormName="        + FormName            + Var.CR + 
                    "sys.GetParamEnter Mode="        + Mode.ToString() + Var.CR;
            sys.SM(Mes);*/    
//======================================================================
        //Установка соединения с Удаленной БД. Возвращаем ID пользователя, заведенного в прикладной табличке fbaUser
        /*public bool SetConnectionRemote(string ServerType, string ServerName, string DatabaseLogin, string DatabasePass, string DatabaseName, string UserForm, string UserLogin, string UserPass, string SystemName, out string UserID)
        {            
            UserID = "";
            //Если в качестве удаленной базой у нас тестовая локальная, то соединяемся с ней.
            //У нас будут conLite и con подключены к одной и той-же базе local.db3.
            if ((ServerType == "SQLite") && (ServerName == "localhost"))
            {                               
                if (sys.GetPathSQLite(out ServerName) == false) return false;
            }
                    
            if (InitConnection(ServerType, ServerName, DatabaseLogin, DatabasePass, DatabaseName) == false) return false;
            
            //Не проверяем наличие пользователя в БД, форм, если это подключение сервера приложения.
            if (SystemName == "ApplicationServer") return true;
            //Если нет в списке соединения соединения с локальной БД, то создаем его.
            if (!Var.CReateConnectionTest(Var.con)) return false;
            
            UserID = GetUserID(UserLogin, UserPass);
            if (UserID == "") return false;        
            if ((SystemName ==  "Client") && (FormExists(UserForm) == false)) return false;
            if ((SystemName ==  "Designer") && (IsAdmin(UserLogin) == false)) return false;                               
            return true;
        }*/    
//======================================================================
//Функции выполнения UPDATE, INSERT и др.... для MSSQL, Postgre, SQLite     
        /*public bool Exec(string SQL, ref string ErrorText, bool ErrorShow, out string ID)
        {               
            ID = "";
            try
            {
                if (SQL.IndexOf("INSERT") == 0) SQL += "; SELECT last_insert_rowid() AS ID; ";                               
                if (DatabaseType == "SQLite")
                {
                    if (command3 == null)
                    {
                        command3 = new SQLiteCommand(SQL);
                        command3.Connection = connection3;
                    }
                    command3.CommandText = SQL;                                                         
                    SQLiteDataReader dr = command3.ExecuteReader();
                    dr.Read();                    
                    if (dr.HasRows) ID = dr[0].ToString();               
                }               
                return true;
            }
            catch (Exception e)
            {
                if (ErrorShow) sys.SM(e.Message
                ErrorText = ErrorText + Var.CR + e.Message;          
                return false;               
            }
        }*/
        
//======================================================================
  /*      
        #region Не используется
        
        //Функция получения данных для PostgreQL из refcursor'a
        public List<System.Data.DataTable> GetRefCursorData(string SQL, List<object> Parameters, out bool ErrorOccured)
        {
            try
            {
                dtRtn.Clear();
                transaction = connection1.BeginTransaction();
                command1 = new NpgsqlCommand();
                command1.Connection = connection1;
                command1.CommandText = SQL;
                command1.Transaction = transaction;
                var myDRString = new List<String>();
                if (Parameters != null)
                {
                    foreach (object item in Parameters)
                    {
                        var parameter = new NpgsqlParameter();
                        parameter.Direction = ParameterDirection.Input;
                        parameter.Value = item;
                        command1.Parameters.Add(parameter);
                    }
                }
                NpgsqlDataReader dr = command1.ExecuteReader();
                while (dr.Read())
                {
                    myDRString.Add(dr[0].ToString());
                }
                dr.Close();
                foreach (string my_DR_String in myDRString)
                {
                    var dt = new System.Data.DataTable();
                    command1 = new NpgsqlCommand("FETCH ALL FROM " + my_DR_String + "; ", connection1);
                    var da = new NpgsqlDataAdapter(command1);
                    da.Fill(dt);
                    dtRtn.Add(dt);
                }
                ErrorOccured = false;
                transaction.Commit();
            }
            catch
            {
                ErrorOccured = true;
                if (transaction != null) transaction.Rollback();
            }
            return dtRtn;
        }
        
        //Функция загрузки данных в таблицу в базе данных (плохой вариант)       
        public bool InsertDT(string TableName, System.Data.DataTable DT, string[] DataColumnsName = null)
        {
            bool ErrorOccured = false;
            try
            {              
                DataColumnCollection dcc = new System.Data.DataTable().Columns;
                string Names = "";
                if (DataColumnsName == null)
                {
                    foreach (DataColumn col in DT.Columns)
                    {
                        dcc.Add(col);
                         Names += "," + col.ColumnName;
                    }
                }  else{
                    foreach (string name in DataColumnsName)
                    {
                        Names = "," + name;
                        if (DT.Columns.Contains(name))
                                dcc.Add(DT.Columns[DT.Columns.IndexOf(name)]);
                    }
                }
                Names = Names.Remove(0, 1);
                string SQL = "";
                foreach (DataRow row in DT.Rows) {
                   string rowvalues = "";
                   foreach (DataColumn col in dcc)
                    {
                        rowvalues = ",'" + row[col].ToString() + "'";
                    }
                    rowvalues = rowvalues.Remove(0, 1);
                    SQL += "insert into " + TableName + " (" + Names + ") values " + rowvalues + "\n";
                }
                if (DatabaseType == "Postgre") {
                    command1 = new NpgsqlCommand(SQL);
                    command1.Connection = connection1;
                    ErrorOccured = command1.ExecuteNonQuery() == 0 ? false : true;
                };
                if (DatabaseType == "MSSQL")
                {
                    command2 = new SqlCommand(SQL);
                    command2.Connection = connection2;
                    ErrorOccured = command2.ExecuteNonQuery() == 0 ? false : true;
                };
                if (DatabaseType == "SQLite")
                {
                    command3 = new SQLiteCommand(SQL);
                    command3.Connection = connection3;
                    ErrorOccured = command3.ExecuteNonQuery() == 0 ? false : true;
                };
                return true;
            }
            catch
            {
                return false;
            }        
        }
                 
        #endregion
    */
//======================================================================
 /*  if (!GetParamConnectionApp(ServerAppName_Local,
                                           ServerAppPort_Local, 
                                           out ConnectionGUID_Local,
                                           out ConnectionName_Local,                                                         
                                           out ServerName_Local,
                                           out ServerType_Local ,
                                           out DatabaseName_Local,
                                           out DatabaseLogin_Local,
                                           out DatabasePass_Local,
                                           out UserForm_Local,
                                           out UserLogin_Local,
                                           out UserPass_Local)) return false; 
 * /
/*
//======================================================================
 //public static string ServerType      = "";
        //public static string ServerName      = "";   
        //public static string DatabaseName    = "";
        //public static string DatabaseLogin = "";
        //public static string DatabasePass  = "";
//======================================================================
//Создаем подключение в случае прямого подключения.           
            if ((ServerType    = "serverapp") &&
                (ServerName    != "") &&
                (DatabaseLogin != "") &&
                (DatabasePass  != "") &&
                (DatabaseName  != ""))
            {                                                                                                              
                if (Var.conSys.InitConnectionDB(ServerType, 
                                           ServerName,
                                           DatabaseLogin, 
                                           DatabasePass, 
                                           DatabaseName)) DirectConnection_Local = true; }
 */          
//======================================================================
/*static void MyServer()
        {           
            try           
            {                   
                ThreadPool.SetMaxThreads(Var.MaxThreadsCount, Var.MaxThreadsCount);                  
                ThreadPool.SetMinThreads(2, 2);                 
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                ListenerTCP = new TcpListener(localAddr, Var.ServerAppPortDefault);   //9595
                //Запускаем TcpListener и начинаем слушать.
                ListenerTCP.Start();
                 
                while (true)
                {
                    ThreadPool.QueueUserWorkItem(ServerMessage, server.AcceptTcpClient());                   
                }
            }
            catch (Exception ex)
            {                     
                if (ex.Message.IndexOf("одно использование адреса сокета") = 0)
                  MessageBox.Show("Модуль ServerWork. Ошибка локального сервера приложений : " + ex.Message);
            }
            
            finally
            {
                //Останавливаем TcpListener.
                ListenerTCP.Stop();
            }
        }*/
        
        
        
        //Прием сообщения от сервера приложений.
        /*static void ServerMessage(object client_obj)
        {                    
            //Буфер для принимаемых данных.
            var bytes = new Byte[256];
            string data = null;                                               
            var client = client_obj as TcpClient;
                                    
            //Получаем информацию от клиента
            NetworkStream stream = client.GetStream();
            int i;
            //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                //Преобразуем данные в ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                byte[] msg;
                if (data == "close")
                {
                    msg = System.Text.Encoding.ASCII.GetBytes("СloseSuccessfully");              
                    stream.Write(msg, 0, msg.Length);
                    Environment.Exit(0);
                    return;
                }
                MessageBox.Show(data);                                                              
                //Отправляем ответ обратно серверу приложений.
                msg = System.Text.Encoding.ASCII.GetBytes("MessageBoxSuccessfully");              
                stream.Write(msg, 0, msg.Length);               
            }
            //Закрываем соединение.
            client.Close();
        }*/
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
//======================================================================
        
        //Сохранение DataTable в CSV.
        /*public static bool DataTableToCSV(System.Data.DataTable DT, String FileName)
        {  
            try
            {
                var lines = new List<string>();
                string[] columnNames = DT.Columns.Cast<DataColumn>().Select(column => column.ColumnName + ":" + column.DataType).ToArray();                
                lines.Add(string.Join(";", columnNames));         
                lines.AddRange(DT.AsEnumerable().Select(row => string.Join(";", row.ItemArray)) );                           
                File.WriteAllLines(FileName, lines);
                return true;  
            } catch (Exception ex)
            {
                sys.SM("Ошибка при создании файла CSV: " + FileName + Var.CR + ex.Message);                  
                return false; 
            }
        }*/ 
         
        //Загрузка DataTable из CSV.
        /*public static bool DataTableFromCSV(ref System.Data.DataTable DT, string FileName, bool ErrorShow)
        {              
            try
            { 
                string[] csvRows = System.IO.File.ReadAllLines(FileName);
                string[] headers = csvRows[0].Split(';');
                DT = new System.Data.DataTable();
                foreach (string header in headers) DT.Columns.Add(header);                              
                string[] fields = null;    
                for (int i = 1; i < csvRows.Length; i++)                     
                {
                    fields = csvRows[i].Split(';');
                    DataRow row = DT.NewRow();
                    row.ItemArray = fields;
                    DT.Rows.Add(row);
                }
                return true;
            } catch (Exception ex)
            {
                if (ErrorShow) sys.SM("Ошибка при конвертировании DataTable в строку: " + Var.CR + ex.Message);              
                return false;
            }
        }*/ 
        
        
//Сохранение DataTable в строку.
        /*public static bool DataTableToStringOld(System.Data.DataTable DT, out string TableString, out string ErrorMes, bool ErrorShow)
        {
            TableString = "";
            ErrorMes    = "";
            try
            {               
                var lines = new List<string>();
                string[] columnNames = DT.Columns.Cast<DataColumn>().Select(column => column.ColumnName + ":" + column.DataType.ToString().Replace("System.", "")).ToArray();
                lines.Add(string.Join("|", columnNames));         
                lines.AddRange(DT.AsEnumerable().Select(row => string.Join(";", row.ItemArray)) );                                                                    
                TableString = string.Join(Var.CR, lines.ToArray()); 
                return true;
                
            } catch (Exception ex)
            {
                ErrorMes = "Ошибка при конвертировании DataTable в строку: " + Var.CR + ex.Message;   
                if (ErrorShow) sys.SM(ErrorMes);                                  
                return false;
            }
        }*/      
        
        //Загрузка DataTable из строки.
        /*public static bool DataTableFromStringOld(out System.Data.DataTable DT, string TableString, out string ErrorMes, bool ErrorShow)
        {              
            DT       = null;
            ErrorMes = "";
            try
            { 
                string[] csvRows = TableString.Split('\n');
                string[] headers = csvRows[0].Split('|');
                var HeaderAndType = new string[2];           
                DT = new System.Data.DataTable();
                foreach (string header in headers) 
                {
                    HeaderAndType = header.Split(':');
                    //Тип поля, который указан здесь пока не используем: HeaderAndType[1]
                    DT.Columns.Add(HeaderAndType[0]);
                }
                string[] fields = null;    
                for (int i = 1; i < csvRows.Length; i++)                     
                {
                    fields = csvRows[i].Split('|');
                    DataRow row = DT.NewRow();
                    row.ItemArray = fields;
                    DT.Rows.Add(row);
                }
                return true;
            } catch (Exception ex)
            {
                ErrorMes  = "Ошибка при конвертировании DataTable в строку: " + Var.CR + ex.Message;
                if (ErrorShow) sys.SM(ErrorMes);
                return false;
            }
        }*/         
        
        //Console.WriteLine("{0} KB", file.Length / 1024);
//Console.WriteLine("{0} MB", file.Length / 1024 / 1024);
//Console.WriteLine("{0} GB", file.Length / 1024 / 1024 / 1024);
//return files;
            
            
            // DT = new System.Data.DataTable();
            //var lstFilesFound = new List<string>();
            /*try
            {
                foreach (string d in Directory.GetDirectories(sDir)) 
                {
                    foreach (string f in Directory.GetFiles(d, "*.*", SearchOption.AllDirectories)) 
                    {
                       lstFilesFound.Add(f);
                    }
                    FindFiles(d);
                }
            }
            catch (System.Exception excpt) 
            {
                Console.WriteLine(excpt.Message);
            }*/
    //======================================================================
/*
//Сохранить все файлы программы на сервере.
        private bool SaveUpdateToServer()
        {
        	//string Initialpath = "";//@"..\..\..\sys\";
			//string Path;
			//if (!sys.ChooseFolder(Initialpath, out Path)) return;						 
			//System.Data.DataTable DT;
			//sys.FindFiles(sys.PathMain, out DT);
			//dgvFile.DataSource = DT;
			
			//Directory.SetCurrentDirectory(Path);
			//Папки:
			//System.IO.Directory.CreateDirectory(Path + @"\Additional");
			//System.IO.Directory.CreateDirectory(Path + @"\FormTest");
			//System.IO.Directory.CreateDirectory(Path + @"\FormWork");
			//System.IO.Directory.CreateDirectory(Path + @"\Log");
			//System.IO.Directory.CreateDirectory(Path + @"\Temp");
			
			//Файлы:			
			/*
            sys.FileCopy(sys.PathAdditional + @"ASCII.html",               Path + @"\Additional\ASCII.html",                "Overwrite");
			sys.FileCopy(sys.PathAdditional + @"ColorTable.html",          Path + @"\Additional\ColorTable.html",           "Overwrite");
			sys.FileCopy(sys.PathAdditional + @"DataTimeFormat.html",      Path + @"\Additional\DataTimeFormat.html",       "Overwrite");
			sys.FileCopy(sys.PathAdditional + @"NewDatabase_Postgre.sql", Path + @"\Additional\NewDatabase_Postgre.sql",  "Overwrite");
			sys.FileCopy(sys.PathAdditional + @"NewDatabase_SQLite.sql",   Path + @"\Additional\NewDatabase_SQLite.sql", 				"Overwrite");
            sys.FileCopy(sys.PathAdditional + @"RegularTest.exe", 		   Path + @"\Additional\RegularTest.exe", 						"Overwrite");
            sys.FileCopy(sys.PathAdditional + @"RegularTest.rar",          Path + @"\Additional\RegularTest.rar", 						"Overwrite");
            sys.FileCopy(sys.PathMain       + @"ClientApp.exe",            Path + @"\ClientApp.exe", 						"Overwrite");
            sys.FileCopy(sys.PathMain       + @"DesignerApp.exe",          Path + @"\DesignerApp.exe", 						"Overwrite");
            sys.FileCopy(sys.PathMain       + @"ServerApp.exe",            Path + @"\ServerApp.exe", 						"Overwrite");
            sys.FileCopy(sys.PathMain       + @"Updater.exe",              Path + @"\Updater.exe", 							"Overwrite");
            sys.FileCopy(sys.PathMain       + @"Utility.exe",              Path + @"\Utility.exe", 							"Overwrite");
            sys.FileCopy(sys.PathMain       + @"FastColoredTextBox.dll",   Path + @"\FastColoredTextBox.dll", 				"Overwrite");
            sys.FileCopy(sys.PathMain       + @"local.db3",                Path + @"\local.db3", 							"Overwrite");
            sys.FileCopy(sys.PathMain       + @"Mono.Security.dll",        Path + @"\Mono.Security.dll", 					"Overwrite");
            sys.FileCopy(sys.PathMain       + @"Npgsql.dll",               Path + @"\Npgsql.dll", 							"Overwrite");
            sys.FileCopy(sys.PathMain       + @"sys.dll",                  Path + @"\sys.dll", 								"Overwrite");
            sys.FileCopy(sys.PathMain       + @"System.Data.SQLite.dll",   Path + @"\System.Data.SQLite.dll", 				"Overwrite");
            */
            
           
            //CREATE TABLE fbaUpdate(ID INTEGER PRIMARY KEY AUTOINCREMENT, 
            //EntityID INTEGER DEFAULT (112), 
            //Version TEXT, 
            //CurrentVersion TEXT, 
            //FullName TEXT, 
            //Name TEXT, 
            //Extension TEXT, 
            //CreationTime timestamp without time zone, 
            //LastWriteTime timestamp without time zone, 
            //LastAccessTime timestamp without time zone, 
            //Size INTEGER,
            //MD5 TEXT, 
            //FileData TEXT);
            //string ID = "";
            //Var.conSys.SaveFileToDataBase64(sys.PathAdditional + @"ASCII.html", 
            //                         "fbaUpdate", "FileData", ref ID);
            
            //string[] Files = new string[5];
            
            /*var Files = new List<string>();
            //Files.Add();
            Files.Add(sys.PathAdditional + @"ASCII.html"); 
			Files.Add(sys.PathAdditional + @"ColorTable.html");   
			Files.Add(sys.PathAdditional + @"DataTimeFormat.html");
			Files.Add(sys.PathAdditional + @"NewDatabase_Postgre.sql");       
			Files.Add(sys.PathAdditional + @"NewDatabase_SQLite.sql");
            Files.Add(sys.PathAdditional + @"RegularTest.exe"); 
            Files.Add(sys.PathAdditional + @"RegularTest.rar");
            Files.Add(sys.PathMain       + @"ClientApp.exe");  
            Files.Add(sys.PathMain       + @"DesignerApp.exe");
            Files.Add(sys.PathMain       + @"ServerApp.exe");
            Files.Add(sys.PathMain       + @"Updater.exe");
            Files.Add(sys.PathMain       + @"Utility.exe");
            Files.Add(sys.PathMain       + @"FastColoredTextBox.dll");
            Files.Add(sys.PathMain       + @"local.db3");
            Files.Add(sys.PathMain       + @"Mono.Security.dll"); 
            Files.Add(sys.PathMain       + @"Npgsql.dll");
            Files.Add(sys.PathMain       + @"sys.dll");
            Files.Add(sys.PathMain       + @"System.Data.SQLite.dll");
            
            string FileName;
            string SQL = "";
            string Version;
            string FullName;
            string Path;
            string Name;
            string Extension;
            string CreationTime;
            string LastWriteTime;
            string LastAccessTime; 
            string Size; 
            string MD5;
            string FileData;
            string DateRecord;
			string NeedUpdate;
						
            for (int i = 0; i < Files.Count; i++)
            {
                FileName = Files[i];
                var file = new FileInfo(FileName);
            	Version        = Var.ApplicationVersion;
            	FullName       = FileName;
            	Path           = file.DirectoryName;            	           
            	Name           = file.Name;
                Extension      = file.Extension;               
                CreationTime   = file.CreationTime.ToString();
                LastWriteTime  = file.LastWriteTime.ToString();
                LastAccessTime = file.LastAccessTime.ToString();                      
                Size           = file.Length.ToString(); 
 				MD5            = Crypto.FileMD5(FileName);
 				if (!sys.FileReadBase64(FileName, out FileData)) return false;
 				DateRecord     = sys.DateTimeCurrent();
 				NeedUpdate     = "false";
 				
 				SQL += @"INSERT INTO fbaUpdate (" + 
 					    "Version, " +
 					    "FullName, " +
 					    "Name, " +
 					    "Path, " +
 					    "Extension, " +
 					    "CreationTime, " +
 					    "LastWriteTime, " +
 					    "LastAccessTime, " +
 					    "Size, " +
 					    "MD5, " +
 					    "FileData, " +
 				        "DateRecord, " +
 					    "NeedUpdate) " +
            	        "VALUES (" +
 						"'" + Version        + "'," +  
 					    "'" + FullName       + "'," + 
 					    "'" + Path           + "'," +
 					    "'" + Name           + "'," +
 					    "'" + Extension      + "'," +
 					    "'" + CreationTime   + "'," +
 					    "'" + LastWriteTime  + "'," +
 					    "'" + LastAccessTime + "'," +
 					          Size           + ", " +
 					    "'" + MD5            + "'," + 
 					    "'" + FileData       + "'," + 
 					    "'" + DateRecord     + "'," +
 					    "'" + NeedUpdate     + "'); " +	Var.CR; 			
            } 
            sys.SM(SQL);
            return true;           
        }*/
//======================================================================
/*
   //Сохранить все файлы программы на сервере.
        private bool UploadProgramFiles(bool Upload)
        {        	    
            if (!ServerConnected) ConnectToDatabase();            
            var Files   = new List<string>(); 
              
            Files.Add(sys.PathAdditional + @"ASCII.html"); 
			Files.Add(sys.PathAdditional + @"ColorTable.html");   
			Files.Add(sys.PathAdditional + @"DataTimeFormat.html");
			Files.Add(sys.PathAdditional + @"NewDatabase_Postgre.sql");       
			Files.Add(sys.PathAdditional + @"NewDatabase_SQLite.sql");
            Files.Add(sys.PathAdditional + @"RegularTest.exe"); 
            Files.Add(sys.PathAdditional + @"RegularTest.rar");
            Files.Add(sys.PathMain       + @"ClientApp.exe");  
            Files.Add(sys.PathMain       + @"DesignerApp.exe");
            Files.Add(sys.PathMain       + @"ServerApp.exe");
            Files.Add(sys.PathMain       + @"Updater.exe");
            Files.Add(sys.PathMain       + @"Utility.exe");
            Files.Add(sys.PathMain       + @"FastColoredTextBox.dll");
            Files.Add(sys.PathMain       + @"local.db3");
            Files.Add(sys.PathMain       + @"Mono.Security.dll"); 
            Files.Add(sys.PathMain       + @"Npgsql.dll");
            Files.Add(sys.PathMain       + @"sys.dll");
            Files.Add(sys.PathMain       + @"System.Data.SQLite.dll");  
            
              
            //var SQLList = new string[Files.Count + 2];
            string FileName;
            string SQL = "";
            string Version = Var.ApplicationVersion;;
            string FullName;
            string Path;
            string Name;
            string Extension;
            string CreationTime;
            string LastWriteTime;
            string LastAccessTime; 
            string Size; 
            string MD5;
            string FileData;
            string DateRecord = sys.DateTimeCurrent();;
			string NeedUpdate "false";
			 
			System.Data.DataTable DT = new System.Data.DataTable();
			DT.Columns.Add("Number");
 			DT.Columns.Add("Version");
            DT.Columns.Add("FullName");
            DT.Columns.Add("Path");
            DT.Columns.Add("Name");
           	DT.Columns.Add("Extension");
            DT.Columns.Add("CreationTime");
            DT.Columns.Add("LastWriteTime");
            DT.Columns.Add("LastAccessTime");
            DT.Columns.Add("Size");   
            DT.Columns.Add("MD5"); 
 			                                
			var fileprop = new string[11];			
            for (int i = 0; i < Files.Count; i++)
            {                 
                FileName       = Files[i];
            	var file       = new FileInfo(FileName);                   
            	FullName       = FileName;
            	Path           = file.DirectoryName;            	           
            	Name           = file.Name;
                Extension      = file.Extension;               
                CreationTime   = file.CreationTime.ToString();
                LastWriteTime  = file.LastWriteTime.ToString();
                LastAccessTime = file.LastAccessTime.ToString();                      
                Size           = file.Length.ToString(); 
 				MD5            = Crypto.FileMD5(FileName);
 				  				 				 				
 				fileprop[0]  = (i+1).ToString();
 				fileprop[1]  = Version;
 				fileprop[2]  = FullName;
 				fileprop[3]  = Path;
 				fileprop[4]  = Name;
 				fileprop[5]  = Extension;
 				fileprop[6]  = CreationTime;
 				fileprop[7]  = LastWriteTime;
 				fileprop[8]  = LastAccessTime;
 				fileprop[9]  = Size;
 				fileprop[10] = MD5; 							
 					
 				DataRow row = DT.NewRow();                                        
                row.ItemArray = fileprop;
                DT.Rows.Add(row);                                
            }
            //sys.SM(SQL);            
            dgvRealize.DataSource = DT;
            
            SQL = "DELETE FROM fbaUpdate WHERE Version = '" + Version + "'; " + Var.CR;
            if (!Var.conSys.Exec(SQL)) return false;
                       
            if (Upload) 
            {
            	progressBar1.Maximum = SQLList.Length;
            	for (int i = 0; i < SQLList.Length; i++)
            	{
            		//SQL = SQLList[i];
            		//if (!sys.FileReadBase64(FileName, out FileData)) return false;
            		  
            		SQL = @"INSERT INTO fbaUpdate (Version, FullName, Name, Path, Extension, " +
 					         "CreationTime, LastWriteTime, LastAccessTime, Size, MD5, " +
 					         "FileData, DateRecord, NeedUpdate) " +
            	             "VALUES (" +
 						     "'" + Version + "','" + FullName + "','" + Path + "','" + Name + "','" + Extension + "'," +
 					         "'" + CreationTime + "','" + LastWriteTime + "','" + LastAccessTime + "'," + Size + ", '" + MD5 + "'," + 
 					         "'" + FileData   + "'," + DateRecord + ",'" + NeedUpdate + "'); " + Var.CR;
            		
            		//if (!sys.FileReadBase64(FileName, out FileData)) return false;
            		//if (!Var.conSys.Exec(SQL)) return false;
            		progressBar1.Value = i + 1;
            	}
            }
            SQL = @"UPDATE fbaUpdate SET CurrentVersion = '" + Version + "'; " + Var.CR;
            if (!Var.conSys.Exec(SQL)) return false;
            
            progressBar1.Value = 0;
            return true;           
        } 
 */
//======================================================================
/*
 *  void BtnGetFilesClick(object sender, EventArgs e)
        {
            System.Data.DataTable DT;
            sys.FindFiles(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#", out DT);
            dataGridView2.DataSource = DT;   
        } 
*/
//======================================================================
//Процедура работает! не удалять!
        //Поиск всех файлов в папке и вывод их в таблице.
        /*public static void FindFiles(string Dir, out System.Data.DataTable DT)
        {                                              
            string[] s = Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories);                                            
            DT = new System.Data.DataTable();              
            DT.Columns.Add("Name");
            DT.Columns.Add("FullName");
            DT.Columns.Add("Extension");
            DT.Columns.Add("CreationTime");
            DT.Columns.Add("LastWriteTime");
            DT.Columns.Add("LastAccessTime");
            DT.Columns.Add("Size");   
            DT.Columns.Add("MD5");  
              
            var fileprop = new string[8];
            for (int i = 0; i < s.Length; i++)
            { 
                var file = new FileInfo(s[i]);                
                fileprop[0] = s[i];
                fileprop[1] = Path.GetFileName(s[i]);
                fileprop[2] = Path.GetExtension(s[i]);               
                fileprop[3] = File.GetCreationTime(s[i]).ToString();
                fileprop[4] = File.GetLastWriteTime(s[i]).ToString();
                fileprop[5] = File.GetLastAccessTime(s[i]).ToString();                      
                fileprop[6] = file.Length.ToString(); 
                fileprop[7] = Crypto.FileMD5(s[i]);                
                
                DataRow row = DT.NewRow();                                        
                row.ItemArray = fileprop.ToArray();
                DT.Rows.Add(row);                  
            } 
        }
        */
//======================================================================
/*
//Сохранить все файлы программы на сервере.
        private bool UploadProgramFiles(bool Upload)
        {                
            if (!ServerConnected) ConnectToDatabase();
            //Папки
            var Directories = new List<string>(); 
            Directories.Add(@"Additional");
            Directories.Add(@"FormTest");
            Directories.Add(@"FormWork");
            Directories.Add(@"Log");
            Directories.Add(@"Temp");
            Directories.Add(@"Update");
            //Файлы
            var Files = new List<string>();              
            Files.Add(sys.PathAdditional + @"ASCII.html"); 
            Files.Add(sys.PathAdditional + @"ColorTable.html");   
            Files.Add(sys.PathAdditional + @"DataTimeFormat.html");
            Files.Add(sys.PathAdditional + @"NewDatabase_Postgre.sql");       
            Files.Add(sys.PathAdditional + @"NewDatabase_SQLite.sql");
            Files.Add(sys.PathAdditional + @"RegularTest.exe"); 
            Files.Add(sys.PathAdditional + @"RegularTest.rar");
            Files.Add(sys.PathMain       + @"ClientApp.exe");  
            Files.Add(sys.PathMain       + @"DesignerApp.exe");
            Files.Add(sys.PathMain       + @"ServerApp.exe");
            Files.Add(sys.PathMain       + @"Updater.exe");
            Files.Add(sys.PathMain       + @"Utility.exe");
            Files.Add(sys.PathMain       + @"FastColoredTextBox.dll");
            if (Var.conSys.ServerType != "SQLite")
                Files.Add(sys.PathMain       + @"local.db3");
            Files.Add(sys.PathMain       + @"Mono.Security.dll"); 
            Files.Add(sys.PathMain       + @"Npgsql.dll");
            Files.Add(sys.PathMain       + @"sys.dll");
            Files.Add(sys.PathMain       + @"System.Data.SQLite.dll");  
              
            string FileName;
            string SQL = "";
            string Version = Var.ApplicationVersion;;
            string FullName;
            string Path;
            string Name;
            string Extension;
            string CreationTime;
            string LastWriteTime;
            string LastAccessTime; 
            string Size; 
            string MD5;
            string FileData   = "";
            string DateRecord = sys.DateTimeCurrent();;
            string NeedUpdate = "false";
            string NumberFile;
            string NumberVersion;
            System.Data.DataTable DT = new System.Data.DataTable();
            DT.Columns.Add("Number");
             DT.Columns.Add("Version");
            DT.Columns.Add("FullName");
            DT.Columns.Add("Path");
            DT.Columns.Add("Name");
               DT.Columns.Add("Extension");
            DT.Columns.Add("CreationTime");
            DT.Columns.Add("LastWriteTime");
            DT.Columns.Add("LastAccessTime");
            DT.Columns.Add("Size");   
            DT.Columns.Add("MD5"); 
             DT.Columns.Add("ContentType"); //1-папка, 2-файл 
             DT.Columns.Add("Operation");   //1-создать, 2-удалить. 
             
            var fileprop = new string[11];                
            var Progress1 = new FormProgress("Загрузка файлов на сервер", "Получение параметров файлов", Files.Count);
            Progress1.Show();                      
            for (int i = 0; i < Files.Count; i++)
            {                 
                FileName     = Files[i];
                var file     = new FileInfo(FileName);                                                                                            
                 fileprop[0]  = (i+1).ToString();
                 fileprop[1]  = Version;                        //Version
                 fileprop[2]  = FileName;                        //FullName;
                 fileprop[3]  = sys.PathMain;                     //Path;
                 fileprop[4]  = file.Name;                      //Name;
                 fileprop[5]  = file.Extension;                 //Extension;
                 fileprop[6]  = file.CreationTime.ToString();   //CreationTime;
                 fileprop[7]  = file.LastWriteTime.ToString();  //LastWriteTime;
                 fileprop[8]  = file.LastAccessTime.ToString(); //LastAccessTime;
                 fileprop[9]  = file.Length.ToString();          //Size;
                 fileprop[10] = Crypto.FileMD5(FileName);        //MD5;                                                  
                 DataRow row = DT.NewRow();                                        
                row.ItemArray = fileprop;
                DT.Rows.Add(row);                    
                Progress1.Inc();
            }           
            //sys.SM(SQL);            
            dgvRealize.DataSource = DT;                                               
            Progress1.Dispose();
            
            
            
            SQL = "DELETE FROM fbaUpdate WHERE Version = '" + Version + "'; ";
            if (!Var.conSys.Exec(SQL)) return false;             
            Application.DoEvents();    
            
            SQL = "SELECT MAX(NumberVersion) AS NumberVersion FROM fbaUpdate; ";
            NumberVersion = Var.conSys.GetValue(SQL); //Последняя версия в таблице обновлений.
                       
            //Загрузка на сервер.
            if (Upload)
            {   
                Progress1 = new FormProgress("Загрузка файлов на сервер", "Получение параметров файлов", Files.Count);
                Progress1.Show(); 
                for (int i = 0; i < DT.Rows.Count; i++)
                {      
                    FullName       = DT.Rows[i]["FullName"].ToString();                    
                    Path           = DT.Rows[i]["Path"].ToString();
                    Name           = DT.Rows[i]["Name"].ToString();
                    Extension      = DT.Rows[i]["Extension"].ToString();
                    CreationTime   = DT.Rows[i]["CreationTime"].ToString();
                    LastWriteTime  = DT.Rows[i]["LastWriteTime"].ToString();
                    LastAccessTime = DT.Rows[i]["LastAccessTime"].ToString();
                    Size           = DT.Rows[i]["Size"].ToString();
                    MD5            = DT.Rows[i]["MD5"].ToString();
                    NumberFile    = (i + 1).ToString();
                      
                     if (!sys.FileReadBase64(FullName, out FileData)) return false;
                     
                    SQL = @"INSERT INTO fbaUpdate (NumberFile, NumberVersion, Version, FullName, Path, Name, Extension, " +
                              "CreationTime, LastWriteTime, LastAccessTime, Size, MD5, " +
                              "FileData, DateRecord, NeedUpdate, ) " +
                             "VALUES (" +
                             "'" + NumberFile + "','" + NumberVersion + "','" +
                              "'" + Version + "','" + FullName + "','" + Path + "','" + Name + "','" + Extension + "'," +
                              "'" + CreationTime + "','" + LastWriteTime + "','" + LastAccessTime + "'," + Size + ", '" + MD5 + "'," + 
                              "'" + FileData + "'," + DateRecord + ",'" + NeedUpdate + "'); " + Var.CR;                        
                    if (!Var.conSys.Exec(SQL)) return false;      
                    Progress1.Inc();               
                }              
            }            
            SQL = @"UPDATE fbaUpdate SET CurrentVersion = '" + Version + "'; " + Var.CR;
            if (!Var.conSys.Exec(SQL)) return false; 
            Progress1.Dispose();            
            return true;           
        }        */
//======================================================================
/*
 *  //Загрузить список файлов и папок для создания или удаления при обновлении.
        private void ContentLoad(bool Newload)
        {           
            sys.FileTextBoxLoad(tbContentUpdate, sys.PathUpdate + "ContentAdd.txt", Newload); 
            
            sys.FileTextBoxLoad(tbText1, sys.PathAdditional + "NewDatabase_SQLite.txt", true); 
            sys.FileTextBoxLoad(tbText2, sys.PathAdditional + "NewDatabase_Postgre.txt", true);
              
        }
        
        //Сохранить список файлов и папок для создания или удаления при обновлении.
        private void ContentSave()
        {
            sys.FileTextBoxSave(tbContentUpdate, sys.PathUpdate + "ContentAdd.txt");          
        }
        
        void TabControl1SelectedIndexChanged(object sender, EventArgs e)
        {         
           if (tabControl1.SelectedTab == tabPageUpdate) ContentLoad(false);
           
           sys.FileTextBoxSave(tbText1, sys.PathAdditional + "NewDatabase_SQLite.txt");   
           sys.FileTextBoxSave(tbText2, sys.PathAdditional + "NewDatabase_Postgre.txt"); 
            
           File.WriteAllText(sys.PathAdditional + "NewDatabase_SQLite.sql",   tbText1.Text, System.Text.Encoding.Default);
           File.WriteAllText(sys.PathAdditional + "NewDatabase_Postgre.sql", tbText2.Text, System.Text.Encoding.Default);
        }
        */
//======================================================================
/*INSERT INTO fbaUpdate (NumberFile, NumberUpdate, DateRecord, UserUpdate, 
                        ContentType, Operation, Version, CurrentVersion, 
                        FullName, Path, Name, Extension, CreationTime, 
                        LastWriteTime, LastAccessTime, Size, MD5, FileData) 
	VALUES ('1','1',current_timestamp,'False','DIR','ADD','1.0.6335.33483',
	        '1.0.6335.33483','Additional',
	        'D:Дизайнер CДизайнер C 2017.05.05\Дизайнер Csys\bin\Debug',
	        '','','','','',0, '','');
*/
//======================================================================
/*
 * //Обновление программы.
		public static bool UpdateProgram(out string ResultUpdate, string Version = "")
		{
			string SQL;
			string MD5Update;
			string MD5Local;
			string FileData;
			string FullName;
			string FileName;
			string Path;
			string LocalFileName;
			System.Data.DataTable DT1;
			System.Data.DataTable DT2;
			//Этот вызов CheckUpdateProgram можно убрать, он сделан для обновления по тихому. ShowMessage не выдается.
			if (Version == "") 
			    if (!CheckUpdateProgram(out Version)) 
			{
				ResultUpdate = "Обновление не требуется." + Var.CR +            
			                   "У Вас уже установлена самая последня версия: " + Version;
				return true;
			}
			
			SQL = "select ID, Name from fbaUpdate WHERE Version = '" + Version + "'; ";				
			Var.conSys.SelectDT1(SQL, out DT1);
 
			var Progress = new FormProgress("Обновление программы", "Получение файлов для обновления", DT1.Rows.Count);
            Progress.Show(); 
            for (int i = 0; i < DT1.Rows.Count; i++)
            {
                SQL = "SELECT MD5, FullName, Path, FileData FROM fbaUpdate WHERE ID = " + DT1.Rows[i]["ID"].ToString(); 
                Var.conSys.SelectDT1(SQL, out  DT2);
                MD5Update = DTValue(DT2, "MD5");
                FullName  = DTValue(DT2, "FullName");
                Path      = DTValue(DT2, "Path");
                FileData  = DTValue(DT2, "FileData");
                LocalFileName = FullName.Replace(Path, sys.PathMain);                            
                MD5Local = Crypto.FileMD5(LocalFileName); //MD5 локального файла.     
                //Если MD5 не совпадает между локальным файлом и файлом 
                //для обновления, то обновляем файл.
                if (MD5Update != MD5Local) 
                {
                    FileName = LocalFileName.Replace(".", "_update.");
                    FileWriteBase64(FileData, FileName);
                }               
                Progress.Inc();               
            }
            Progress.Dispose();
            ResultUpdate = "Файлы для обновления скачаны." + Var.CR + 
                           "Обновление готово для установки.";
            return true;
		}  
 */ 
//======================================================================
/*
 * //Новая вкладка
            if (SenderName == "tbSQL3")
            {
                
            	Var.TABControlPageAdd(tabControSQL, 
		                              splitContainer1, 
		                              textSQL1,
		                              pnlResultSQL1,
		                              tbSQLResult1,
		                              dgvSQL1,
		                              ref TabIndexSQL);
            	/*TabIndexSQL += 1;
                string newindexstr = TabIndexSQL.ToString(); //tabControSQL.TabPages.Count.ToString()
                tabControSQL.TabPages.Add("Query" + TabIndexSQL.ToString());                                
                tabControSQL.TabPages[tabControSQL.TabPages.Count-1].Tag = TabIndexSQL;               
                var sc1 = new SplitContainer();
                tabControSQL.TabPages[tabControSQL.TabPages.Count-1].Controls.Add(sc1);
                sc1.Dock = DockStyle.Fill;
                sc1.Orientation      = System.Windows.Forms.Orientation.Horizontal;
                sc1.SplitterDistance = splitContainer1.SplitterDistance;
                sc1.BackColor        = splitContainer1.BackColor;          
                
                var fctb1 = new FastColoredTextBox();
                sc1.Panel1.Controls.Add(fctb1);
                fctb1.Dock                          = textSQL1.Dock;
                fctb1.AutoCompleteBrackets          = textSQL1.AutoCompleteBrackets;
                fctb1.AutoScrollMinSize             = textSQL1.AutoScrollMinSize;
                fctb1.BookmarkColor                 = textSQL1.BookmarkColor;
                fctb1.BracketsHighlightStrategy     = textSQL1.BracketsHighlightStrategy;
                fctb1.Cursor                        = textSQL1.Cursor;
                fctb1.DisabledColor                 = textSQL1.DisabledColor;
                fctb1.FindEndOfFoldingBlockStrategy = textSQL1.FindEndOfFoldingBlockStrategy;
                fctb1.Font                          = textSQL1.Font;
                fctb1.Language                      = textSQL1.Language;
                fctb1.LeftBracket                   = textSQL1.LeftBracket;
                fctb1.RightBracket                  = textSQL1.RightBracket;
                //fctb1.Padding                       = textSQL1.Padding;                
                fctb1.SelectionColor                = textSQL1.SelectionColor;
                fctb1.VirtualSpace                  = textSQL1.VirtualSpace;
                fctb1.Name = "textSQL" + newindexstr;
                
                var pnl = new Panel();
                sc1.Panel2.Controls.Add(pnl);
                pnl.Dock      = DockStyle.Top;
                pnl.Height    = pnlResultSQL1.Height;
                pnl.BackColor = Color.Blue;
                
                var tb1 = new TextBox();
                tb1.Font        = tbSQLResult1.Font;
                tb1.Location    = tbSQLResult1.Location;
                tb1.ForeColor   = tbSQLResult1.ForeColor;
                tb1.Text        = "Результат";
                tb1.BorderStyle = tbSQLResult1.BorderStyle; 
                tb1.BackColor   = tbSQLResult1.BackColor;
                tb1.Width       = tbSQLResult1.Width;
                
                tb1.Name        = "tbSQLResult" + newindexstr;                
                pnl.Controls.Add(tb1);
                  
                var dgv1 = new DataGridView();                
                sc1.Panel2.Controls.Add(dgv1);                 
                dgv1.Dock = DockStyle.Fill;
                dgv1.AllowUserToAddRows              = dgvSQL1.AllowUserToAddRows;
                dgv1.AllowUserToDeleteRows           = dgvSQL1.AllowUserToDeleteRows;
                dgv1.AllowUserToOrderColumns         = dgvSQL1.AllowUserToOrderColumns;
                dgv1.AlternatingRowsDefaultCellStyle = dgvSQL1.AlternatingRowsDefaultCellStyle;
                dgv1.AutoSizeColumnsMode             = dgvSQL1.AutoSizeColumnsMode;
                dgv1.BackgroundColor                 = dgvSQL1.BackgroundColor;
                dgv1.ClipboardCopyMode               = dgvSQL1.ClipboardCopyMode;               
                dgv1.ColumnHeadersBorderStyle        = dgvSQL1.ColumnHeadersBorderStyle;
                dgv1.ColumnHeadersHeightSizeMode     = dgvSQL1.ColumnHeadersHeightSizeMode;
                dgv1.ContextMenuStrip                = dgvSQL1.ContextMenuStrip;
                dgv1.DefaultCellStyle                = dgvSQL1.DefaultCellStyle;                    
                dgv1.EditMode                        = dgvSQL1.EditMode;                             
                dgv1.Margin                          = dgvSQL1.Margin;                    
                dgv1.ReadOnly                        = dgvSQL1.ReadOnly;                
                dgv1.RowHeadersVisible               = dgvSQL1.RowHeadersVisible;
                dgv1.RowsDefaultCellStyle            = dgvSQL1.RowsDefaultCellStyle;
                dgv1.RowTemplate                     = dgvSQL1.RowTemplate; 
                dgv1.BringToFront();
                dgv1.Name                            = "dgvSQL" + newindexstr;  
                //tabControSQL.TabPages[tabControSQL.TabPages.Count-1].Tag = TabIndexSQL;
				tabControSQL.SelectedIndex = tabControSQL.TabPages.Count-1;  
				*/              
             
//======================================================================
/*
 ExportDataTableToString(System.Data.DataTable DT, string TableName, bool ErrorShow, out string DataTableString)
            string DataTableString;
            sys.ExportDataTableToString((DataTable)dgvSQL1.DataSource, "TableMy", true, out DataTableString);
            sys.SM(DataTableString);           
            DataTable DT;
            string TableName;
            sys.ImportDataTableFromString(out DT, out TableName, DataTableString, true);
            dgvUser.DataSource = DT;                                               
            //sys.ExportDataTableToCSV2((DataTable)dgvSQL1.DataSource, "TableMy2.csv");                       
            DataTable DT;            
            //sys.ImportDataTableFromCSV2(ref DT, "TableMy2.csv");
            //dgvUser.DataSource = DT; 
            DT = new System.Data.DataTable();           
            string TableString;
            string ErrorMes = "";
            sys.DataTableToString((DataTable)dgvSQL1.DataSource, out TableString, out ErrorMes, true);
            sys.SM(TableString);                     
            sys.DataTableFromString(out DT, TableString, out ErrorMes, true);
            dgvUser.DataSource = DT;
*/             	
//======================================================================
/*
 * //Обновление программы.
		public static bool UpdateProgram(out string ResultUpdate, string Version = "")
		{
			string SQL;
			string MD5Update;
			string MD5Local;
			string FileData;
			string FullName;
			string FileName;
			string Path;
			string LocalFileName;
			System.Data.DataTable DT1;
			System.Data.DataTable DT2;
			//Этот вызов CheckUpdateProgram можно убрать, он сделан для обновления по тихому. ShowMessage не выдается.
			if (Version == "") 
			    if (!CheckUpdateProgram(out Version)) 
			{
				ResultUpdate = "Обновление не требуется." + Var.CR +            
			                   "У Вас уже установлена самая последня версия: " + Version;
				return true;
			}
			
			SQL = "select ID, Name from fbaUpdate WHERE Version = '" + Version + "'; ";				
			Var.conSys.SelectDT1(SQL, out DT1);
 
			var Progress = new FormProgress("Обновление программы", "Получение файлов для обновления", DT1.Rows.Count);
            Progress.Show(); 
            for (int i = 0; i < DT1.Rows.Count; i++)
            {
                SQL = "SELECT MD5, FullName, Path, FileData FROM fbaUpdate WHERE ID = " + DT1.Rows[i]["ID"].ToString(); 
                Var.conSys.SelectDT1(SQL, out  DT2);
                MD5Update = DTValue(DT2, "MD5");
                FullName  = DTValue(DT2, "FullName");
                Path      = DTValue(DT2, "Path");
                FileData  = DTValue(DT2, "FileData");
                LocalFileName = FullName.Replace(Path, sys.PathMain);                            
                MD5Local = Crypto.FileMD5(LocalFileName); //MD5 локального файла.     
                //Если MD5 не совпадает между локальным файлом и файлом 
                //для обновления, то обновляем файл.
                if (MD5Update != MD5Local) 
                {
                    FileName = LocalFileName.Replace(".", "_update.");
                    FileWriteBase64(FileData, FileName);
                }               
                Progress.Inc();               
            }
            Progress.Dispose();
            ResultUpdate = "Файлы для обновления скачаны." + Var.CR + 
                           "Обновление готово для установки.";
            return true;
		}  
*/
//======================================================================
/*
//DirectoryInfo[] directories = 
        //    di.GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);
       // FileInfo[] files = 
       //     di.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
        		
        		//DirectoryInfo   dir = new DirectoryInfo(Folder);
        		 //string[] s = Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories);  
*/ 
//======================================================================
/*
//string cities = string.Join(Var.CR, ListError.Select(s => s.ToString()).ToArray()); 
*/ 
 //======================================================================
/*
//Удаление всех файлов и папок в указанной папке.
        /*public static bool FolderClean(string Folder)
        {
            try
            {  
                DirectoryInfo di = new DirectoryInfo(Folder);                  
                DirectoryInfo[] diA = di.GetDirectories("*.*", SearchOption.AllDirectories)); //Создаём массив дочерних вложенных директорий директории di              
                FileInfo[] fi = di.GetFiles();             //Создаём массив дочерних файлов директории di
                
                //В цикле пробегаемся по всем файлам директории di и удаляем их
                foreach (FileInfo f in fi)
                {
                    f.Delete();
                }
                //В цикле пробегаемся по всем вложенным директориям директории di 
                foreach (DirectoryInfo df in diA)
                {
                    //Как раз пошла рекурсия
                    deleteFolder(df.FullName);
                    //Если в папке нет больше вложенных папок и файлов - удаляем её,
                    if (df.GetDirectories().Length == 0 && df.GetFiles().Length == 0) df.Delete();
                }
            }
            
            //Начинаем перехватывать ошибки
            //DirectoryNotFoundException - директория не найдена
            catch (DirectoryNotFoundException ex)
            {
                //"Директория не найдена"    
            }
            //UnauthorizedAccessException - отсутствует доступ к файлу или папке
            catch (UnauthorizedAccessException ex)
            {
                SM("Отсутствует доступ. Ошибка: " + ex.Message);
            }
            //Во всех остальных случаях
            catch (Exception ex)
            {
                SM("Ошибка при удалении файла или папки: " + ex.Message);
            }
        }
        */
        //Удалить все файлы в папке, можно фильтровать по имени и расширению.
        /*public static string FilesDelete(string DirectoryName, string FilterNameDelete = "", string FilterNameNotDelete = "", string FilterExtension = "")
        {
            //var dirInfo = new DirectoryInfo(DirectoryName);
            bool NeedDelete = true;
            string NotDeletedFiles = "";
            
            string[] ListFiles = FileFind(DirectoryName, string FileName)
            
            //foreach (FileInfo file in dirInfo.GetFiles())
            foreach (string file in ListFiles)
            {   
                NeedDelete = true;
                if (FilterNameDelete    != "")    NeedDelete = (file.Name.IndexOf(FilterNameDelete) > -1);
                if (FilterExtension     != "")     NeedDelete = (file.Extension.ToLower() == FilterExtension);
                if (FilterNameNotDelete != "") 
                {
                    if (file.Name.IndexOf(FilterNameNotDelete) > -1) NeedDelete = false;
                }
                
                if (NeedDelete)
                {    try
                    {
                        file.Delete();
                    }
                    catch 
                    {
                        NotDeletedFiles += file.Name + Var.CR;
                    }                     
                }            
            }
            return NotDeletedFiles;
        }
         
*/
//======================================================================
/*
//Обновление программы.
		public static bool NeedUpdateProgram()
		{			 
			string Version; 
		    string NumberUpdate; 		     
		    if (sys.CheckUserUpdateProgram(out Version, out NumberUpdate)) //, out SizeSum, out AddFileCount
            {
                if (!sys.SM("Требуется обновление." + Var.CR +
                            "Необходимо установить обновление. " + Var.CR +                           
                            "Порядковый номер обновления: " + NumberUpdate + Var.CR + 
                            "Версия: " + Version + Var.CR +
                            //"Размер обновления: " + SizeSum + Var.CR + 
                            //"Количество файлов: " + AddFileCount + Var.CR +
                            "Текущая версия программы: " + Var.ApplicationVersion + Var.CR +
                            "Обновить программу?", MessageType.Question, "Проверка обновления")) return true;             
            }
            else 
            {
            	sys.SM("Обновление не требуется." + Var.CR +            
			           "У Вас уже установлена самая последня версия: " + Version, MessageType.Information); 
            	return true;
            }               
            
            string ResultUpdate;
            if (sys.UpdateProgram(out ResultUpdate, Version)) 
            {
            	sys.SM(ResultUpdate, MessageType.Information);
            	return true;
            }
            else 
            {
               	sys.SM(ResultUpdate
               	return false; 
            }            			           
		} 
*/
 //======================================================================
/*
          
        //Убиваем процесс.              
        /*private bool KillProcess(string process)
        {
        	while (Process.GetProcessesByName(process).Length > 0)
            {               
        		Process[] processlist = Process.GetProcessesByName(process);
                //if (Kill)
                //{
                    for (int i = 1; i < processlist.Length; i++) {processlist[i].Kill();}				
				    Application.DoEvents();
                    Thread.Sleep(300);
               // }
            } 
        	return true;
        }*/
          
//======================================================================
/*
//Из строки.
        private void Button1Click(object sender, EventArgs e)
        {
            //System.Data.DataTable DT2;
            //string ErrorMes;
            //sys.DataTableFromString(out DT2, textBox1.Text, out ErrorMes, true);
            //dataGridView2.DataSource = DT2;
            //sys.SM("aass");
            var Form1 = new FormProgress();
            Form1.Show();
            
        }
        
        //В CSV.
        private void DTDToCSVClick(object sender, EventArgs e)
        {
            FileName = "";
            if (!ServerConnected) ConnectToDatabase();
            var sd = new SaveFileDialog();
            sd.Title = "Export object";
            sd.FileName = "Form";
            sd.Filter =  "json Files|*.json|All Files|*.*";
            if (sd.ShowDialog() == DialogResult.OK) FileName = sd.FileName;  
                             
            System.Data.DataTable DT;        
            string SQL = "SELECT * FROM Form";                     
            Var.conSys.SelectDT1(SQL, out DT);
            sys.DataTableToCSV(DT, FileName);                                                 
        }
        
        //Из CSV.
        private void BtnCSVToDTClick(object sender, EventArgs e)
        {
            System.Data.DataTable DT2;
            string ErrorMes;
            //DataTableFromCSV(out System.Data.DataTable DT, string FileName, out string ErrorMes, bool ErrorShow)
            sys.DataTableFromCSV(out DT2, FileName, out ErrorMes, true);
            dataGridView2.DataSource = DT2;                      
        }        
*/
//======================================================================
/*
//System.Drawing.Image myImg = global::sys.Properties.Resources.ImageName;
            
            //ResourceManager rm = new ResourceManager("myResources", Assembly.GetExecutingAssembly());
            //PictureBox p = new PictureBox();
            //Bitmap b = (Bitmap)rm.GetObject("название картинке в файле ресурса");
            //p.Image = (Image)b;
           
            //Assembly assembly;
            //Stream soundStream;
            //Image sp;
            //assembly = Assembly.GetExecutingAssembly();
            //sp = new SoundPlayer(assembly.GetManifestResourceStream("Yournamespace.Dreamer.wav"));
            //sp = new (assembly.GetManifestResourceStream("Yournamespace.Dreamer.wav"));
                       
            //Bitmap bmp = global::sys111.sys.error; //Properties.Resources.Lama_Alpaka_Trekking_Welschnofen_Carezza_05;
            //Bitmap bmp = sysres.error; //Properties.Resources.Lama_Alpaka_Trekking_Welschnofen_Carezza_05;
            
            //this.Properties.Resources.
            //pictureBox1.Image = Properties.SysApp.error; //sysresource.sys.error; //Properties.Resources.картинка; 
*/
//======================================================================
/*
//int ProcessCount = StopProcess("ClientApp");
            //ProcessCount = ProcessCount + StopProcess("DesignerApp");
            //ProcessCount = ProcessCount + StopProcess("ServerApp");
            //ProcessCount = ProcessCount + StopProcess("Utility");
            
   /*
        //(Работает. Не удалять, возможно понадобится)
        private int StopProcess(string NameProc)
        {              
            //NameProc должен быть без расширения файла, например: notepad
            Process[] proclist = Process.GetProcesses();
            foreach (Process proc in proclist)
            {
                string ProcessName     = proc.ProcessName;
                string ProcessFileName = "";
                try 
                {
                    ProcessFileName = proc.MainModule.FileName;
                }
                catch (Win32Exception) {}
                if (ProcessName == NameProc) //без && для удобства отладки.
                {
                    if  (ProcessFileName == (PathMain + NameProc + @".exe"))
                    {
                        proc.Kill();
                        return 1; 
                    }
                }
            }
            return 0; 
        }*/ 
    
     //foreach (var process in Process.GetProcesses())
            //{
             //   try
              //  {
              //      Console.WriteLine("PID: {process.Id}; cmd: {process.GetCommandLine()}");
              //  }
                // Catch and ignore "access denied" exceptions.
              //  catch (Win32Exception ex) when (ex.HResult == -2147467259) {}
                // Catch and ignore "Cannot process request because the process (<pid>) has
                // exited." exceptions.
                // These can happen if a process was initially included in 
                // Process.GetProcesses(), but has terminated before it can be
                // examined below.
                //catch (InvalidOperationException ex) when (ex.HResult == -2146233079) {}
        /*private static string GetCommandLine(this Process process)
        {
            string cmdLine = null;
            using (var searcher = new ManagementObjectSearcher(
              $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}"))
            {
                // By definition, the query returns at most 1 match, because the process 
                // is looked up by ID (which is unique by definition).
                var matchEnum = searcher.Get().GetEnumerator();
                if (matchEnum.MoveNext()) // Move to the 1st item.
                {
                    cmdLine = matchEnum.Current["CommandLine"]?.ToString();
                }
            }
            if (cmdLine == null)
            {
                // Not having found a command line implies 1 of 2 exceptions, which the
                // WMI query masked:
                // An "Access denied" exception due to lack of privileges.
                // A "Cannot process request because the process (<pid>) has exited."
                // exception due to the process having terminated.
                // We provoke the same exception again simply by accessing process.MainModule.
                var dummy = process.MainModule; // Provoke exception.
            }
            return cmdLine;
        }
         */
        
              
            //string FileNameLocal  = FullName.Replace(PathValue, sys.PathMain);
            //string FileNameUpdate = FullName.Replace(PathValue, sys.PathUpdate); 
                
            //if(File.Exits(args[1])){ File.Delete(args[1]); }
            
            //File.Move(args[1], args[0]);
            
            //Console.WriteLine("Starting "+args[1]);
            //Process.Start(args[1]);        
        
    /*Process[] processlist = Process.GetProcessesByName(process);  
            if (processlist.Length > 0)
            {                                          
                for (int i = 1; i < processlist.Length; i++) {
                    processlist[i].Kill();}
                return 1;                             
            } 
            return 0;*/
            //listBoxUpdate.Items.Add(process.ProcessName);
                //process.StartInfo.FileName
//= args[1].Replace(".exe", "");
//static Thread threadserver;
//threadserver = new Thread(ServerQueueHTTP);
//private static void ServerQueueHTTP()    {}
//Application.DoEvents(); 
//KillProcess("ClientApp.exe");    
//KillProcess("DesignerApp.exe");
//KillProcess("ServerApp.exe");
//KillProcess("Utility.exe"); 
//======================================================================
/*
        //Проверка на то что нужно обновить программу. Но с выводим текста сообщения.
        /*public static void CheckUpdate()
        {
            string ResultUpdate;          
            string Version;
            string NumberUpdate;  
            if (!sys.CheckUserUpdateProgram(out Version, out NumberUpdate))
            ResultUpdate = "Обновление не требуется. У Вас уже установлена самая последня версия: " + Version; 
            else ResultUpdate = "Требуется обновление." + Var.CR + 
                                "Новая версия программы: " + Version + Var.CR + 
                                " Номер обновления: " + NumberUpdate + Var.CR +
                                "Текущая версия программы: " + Var.ApplicationVersion;           
            sys.SM(ResultUpdate, MessageType.Information);  
        }*/                 
//======================================================================
/*
private  void Button3Click(object sender, EventArgs e)
        {
            
      
            MessageBoxIcon   MBI = MessageBoxIcon.Error;
            MessageBoxButtons MB = MessageBoxButtons.OK;  
            //
            //MBI = MessageBoxIcon.Error;            
            MBI = MessageBoxIcon.Information;                    
            //MBI = MessageBoxIcon.Question;
            //MB = MessageBoxButtons.YesNo; 
           
            //var result = MessageBox.Show("textBox1.Text", "Caption", MB, MBI);             
            //return (result == DialogResult.Yes);               
            sys.SM(textBox1.Text, "Error - Caption");
            sys.SM(textBox1.Text, MessageType.Information, "Information - Caption");
            if (sys.SM(textBox1.Text, MessageType.Question, "Question - Caption")) MessageBox.Show("true", "Caption", MB, MBI);    
            else MessageBox.Show("false", "Caption", MB, MBI); 
        }  
*/ 
//======================================================================
/*
            //string ResultUpdate;
            //sys.NeedUpdateProgram(out ResultUpdate, false, false);
            //string Version;
            //string NumberUpdate;
            //string Mes = "";
            //bool Silent = false;
            //if (!sys.UpdateCheck(out Version, out NumberUpdate, out Mes, Silent))
            //ResultUpdate = "Обновление не требуется. У Вас уже установлена самая последня версия: " + Version; 
            //else ResultUpdate = "Требуется обновление."              + Var.CR + 
            //                    "Новая версия программы: " + Version + Var.CR + 
            //                    "Номер обновления: " + NumberUpdate  + Var.CR +
            //                    "Текущая версия программы: " + Var.ApplicationVersion;           
            //sys.SM(ResultUpdate, MessageType.Information); 
 
*/ 
 //======================================================================
/*
 * Об этом хорошо рассказано в книге Павла Агурова "C# Сборник рецептов" 
* (СПб, изд-во "БХВ-Петербург", 2007). Если необходимо дождаться завершения 
* работы внешней программы, то запуск внешней программы он рекомендует делать так:
using System;
namespace CreateNewProcess
{
   class Class1
   {
       [STAThread]
       static void Main(string[] args)
       {
          // Создать новый процесс
          System.Diagnostics.Process proc = new System.Diagnostics.Process();
          // Приложение, которое будем запускать
          proc.StartInfo.FileName = "Notepad.exe";
          proc.EnableRaisingEvents = true;
          proc.Exited += new EventHandler(proc_Exited);
          proc.Start();
          Console.ReadLine();
       }
   // Будет вызываться при завершении работы Notepad.exe
      private static void proc_Exited(object Sender, EventArgs e)
      {
         Console.WriteLine("proc_Exited");
      }
   }
} 
*/
//======================================================================
/*
string ProcessFileName = @"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Sys\bin\Debug\Utility.exe";
            
            //ProcessFileName- E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Sys\bin\Debug\Utility.exe
             //PathMain-       E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\ 
             int i1 = ProcessFileName.IndexOf(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Sys\bin\Debug\");
             int i2 = ProcessFileName.IndexOf(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Sys\bin\Debug\");
             //int i = PathMain.IndexOf(ProcessFileName);
             SM(i1.ToString());
             SM(i2.ToString()); 
*/
 //======================================================================
/*
//public static readonly string ApplicationVersion = System.Windows.Forms.Application.ProductVersion;               
//public static string asv2 = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ToString();
         
*/
//======================================================================
/*
 //DataTable DT;
            //string SQL = "select ID From From ";
            //sys.GetNewConnectionGUID("Comp2879");
            //sys.AppSelect(SQL, out DT);
            //dataGridView1.DataSource = DT;
                
            string ConnectionID  = "";
            string ServerName    = "";
            string ServerType    = "";
            string DatabaseName  = "";
            string DatabaseLogin = "";
            string DatabasePass  = "";
            string UserForm      = "";
            string UserLogin     = "";
            string UserPass      = "";
           
            string serverapp = "";
            /*sys.GetParamConnectionApp(serverapp,
                                           out ConnectionID,
                                           out ServerName,
                                           out ServerType ,
                                           out DatabaseName,
                                           out DatabaseLogin,
                                              out DatabasePass,
                                           out UserForm,
                                           out UserLogin,
                                              out UserPass);   
        
*/   
//======================================================================
/*
        //Послать запрос SQL на сервер приложений.
        /*public bool AppSelect(string SQL, out DataTable DT, out string ErrorMes)
        {               
            DT = null;
            ErrorMes = "";
            if ((ConnectionGUID == "") || (ServerAppName == ""))
            {   ErrorMes = "Ошибка. соединение с сервером приложений не установлено!"; //GetNewConnectionGUID();  
                return false;
            }                          
            string Request = ServerAppHTTPMessage("103", ConnectionGUID, SQL, "", 0);
            if (Request == "Сессия с сервером не найдена!") 
            {
                sys.SM(Request);
                return false;
            }
            sys.DataTableFromString(out DT, Request, out ErrorMes, true);
            return true;       
        }
         
        //Послать запрос SQL на сервер приложений.
        public bool AppExec(string SQL, out DataTable DT, out string ErrorMes)
        {               
            DT = null;
            ErrorMes = "";
            if ((ConnectionGUID == "") || (ServerAppName == ""))
            {   ErrorMes = "Ошибка. соединение с сервером приложений не установлено!"; //GetNewConnectionGUID();  
                return false;
            }                          
            string Request = ServerAppHTTPMessage("104", ConnectionGUID, SQL, "", 0);
            if (Request == "Сессия с сервером не найдена!") 
            {
                sys.SM(Request);
                return false;
            }
            //sys.DataTableFromString(out DT, Request, out ErrorMes, true);
            return true;       
        } 
*/
//======================================================================
/*
 /*var context2 = o as HttpListenerContext;
            HttpListenerResponse response = context2.Response;  
            string RequestStr1 = GetRequestString3(context2.Request.ContentEncoding, GetBoundary(context2.Request.ContentType), context2.Request.InputStream);
            File.AppendAllText(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Sys\bin\Debug.log", RequestStr1);   
            //MessageBox.Show(RequestStr1, "ServerProcessHTTP", MessageBoxButtons.OK,  MessageBoxIcon.Error);
            
            string ResponseStr2 = "d1-d1-d1";
            byte[] buffer = System.Text.Encoding.Default.GetBytes(ResponseStr2); //UTF8          
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer,0,buffer.Length);                
            output.Close();
            MessageBox.Show("aaa", "Caption", MessageBoxButtons.OK,  MessageBoxIcon.Error);   
            //if (CommandCode == "201")
            //{
            //    ServerWork.ServerStop();
            //    Environment.Exit(0);
            //}
            //if (CommandCode == "202") sys.SM(RequestStr);   
            return;
            */
            
  
//======================================================================
/*
            int CountApp = sys.GetCountRunApp("ClientApp");
            sys.SM(CountApp.ToString());
            
            
            //Project proj = Project.GetInstance(AppName);
            //if (proj.CheckQuantityLaunchedCopyOfApps())
            //    Console.WriteLine("Запущено копий: {0}", proj.QuantityLaunchedProgram);
            
            // Ограничить максиум тремя копиями
            //using (var sem = new Semaphore(3, 3, "MyApplication"))
            //{
            //   if (sem.WaitOne(TimeSpan.FromSeconds(3)))
            //      Application.Run(new Form());
            //   else
            //      MessageBox.Show("Sorry, maximum allowed number of copies are running.");
            //}
            
            // Ограничить максиум тремя копиями
            //var sem = new Semaphore(2, 2, "MyApplication");         
            //if (!sem.WaitOne(TimeSpan.FromSeconds(1)))
                 //Application.Run(new Form());
            //else
            //    MessageBox.Show("Sorry, maximum allowed number of copies are running.");
            
*/
//======================================================================
/*
//Вызвать метод MethodName с параметрами Objects[] из DLL или Form или FormMain.
        public static object Call(string projectName, string MethodName, Object[] ObjParams)
        {         
            Assembly assembly = ModuleLoad(projectName, sys.Mode);                           
            Type type = assembly.GetType("FBA." + projectName);
            Object obj = assembly.CreateInstance("FBA." + projectName);                 
            MethodInfo mi = type.GetMethod(MethodName);            
            return mi.Invoke(obj, ObjParams); 
            //Object obj;
            //Assembly asm;
            //if (!FindForm(FormName, ref FormTag, out obj))
            //{
           //     sys.SM("Не найдена форма: " + FormName);
           //     return null;
           // }    
        //}    
*/ 
//======================================================================
/*
        //Чтобы не объвлять Object в вызывающем коде.
        //public static string Call2(string projectName, string MethodName, Object[] ObjParams)
        //{                      
        //    return CallObj(projectName, MethodName, ObjParams).ToString();
        //}
         
*/ 
 //======================================================================
/*
         //Получение хеша MD5.
        //public string MD5(string instr)
        //{
        //    return instr;
        //string strHash = string.Empty;
        //foreach (byte b in new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(instr)))
        //    strHash += b.ToString("X2");
        //return strHash;
        //}
*/
//======================================================================
/*
            //string UserID_Local = "";
            //string ConnectionGUID = "";
            //string ServerAppName;
            //int ServerAppPort_Local;
            //bool DirectConnection_Local = false;
            //if ((DirectConnection_Local == false) && (ConnectionGUID == ""))
            //{
            //    sys.SM("Не получен идентификатор подключения от сервера приложений!");
            //    return false;
            //}
                  
*/
 //======================================================================
/*
 //Если нет в локальной БД тестового подключения, то создаем.
        public bool CreateConnectionTest(Connection Connect)
        {
            //Роль
            string SQL = 
                "INSERT INTO fbaRole (Name, Brief, DateCreate, DateChange) " +
                "SELECT 'admin', 'admin', " + sys.DateTimeCurrent() + ", " + sys.DateTimeCurrent() + " " + 
                "WHERE not exists(select 1 FROM fbaRole WHERE Name = 'admin' AND Brief = 'admin'); " + Var.CR;
            
            //Пользователь    
            SQL += "INSERT INTO fbaUser (Login, Name, Pass, RoleID, Block, DateCreate, DateChange) " + 
                   "SELECT 'admin', 'admin', '', (SELECT ID FROM fbaRole Where Brief = 'admin' LIMIT 1), 0, " + sys.DateTimeCurrent() + ", " + sys.DateTimeCurrent() + " " + 
                   "WHERE  not exists(SELECT 1 FROM fbaUser WHERE Login = 'admin' AND Name = 'admin'); " + Var.CR;
            //Подключение    
            SQL += "INSERT INTO fbaConList (ConnectionName, ServerName, ServerType, DatabaseName, " +
                   "DatabaseLogin, DatabasePass, UserForm, UserLogin, UserPass) " + 
                   "SELECT 'Test', 'localhost', 'SQLite', '', '', '', 'FormMain1', 'admin', '' " +
                   "WHERE NOT EXISTS(SELECT 1 FROM fbaConList WHERE " +
                   "ConnectionName = 'Test' AND ServerName = 'localhost' AND ServerType = 'SQLite' AND UserLogin = 'admin'); " + Var.CR; 
            
            //const string datesql = "datetime('now', 'localtime')";
            //if (Connect.ServerType == "SQLite") SQL = SQL.Replace("current_timestamp", datesql);
            
            if (!Exec(SQL)) return false;
            return true;                    
        }
 
*/
//======================================================================
/*
   //Установка соединения для доступа к системым таблицам.
        //public static void SetSystemConnection()
        //{
            //Для того чтобы была возможность переключать место хранения таблиц, необходимых для работы данной платформы.
            //Для того чтобы была возможность хранить системные таблицы, как в базе с банными (что правильнее), 
            //так и в базе SQLite сервера приложений. 
            //return sys.SystemLocal ? conLite : Var.con; 
           // if ((sys.SystemLocal) && sys.
            //conSys = (sys.SystemLocal && sys.) ? conLite : con;
        
        //}           
        
        
        //Получить параметры, переданные клиентом в запросе серверу.
        //public static string[] ParseMethodCall(string MethodCallStr)
        // {           
            //Сообщение может выглядеть так:
            //LocalHost=COM1389;ComputerName=ANDREY;ComputerUserName=ANDREY;            
        //    return MethodCallStr.Split()
        //}
        
            /*if (!sys.SystemSysLocal)
            {
               conSys = con;
               conSys.ServerType = conSys.ServerType;
            } else
            {
               conSys =  
            }
            conSys = ((sys.SystemSysLocal) && ServerType != "ServerApp") ? conLite : con;
            
            //SetSystemConnection();
     //conSys = new Connection();
            //conVar.connectionID   = "0";
            //conVar.connectionName = "Postgre";
            //conSys.UserForm       = "";
            
            //if (!conSys.InitConnection("Postgre",
            //                           "10.77.70.27",
            //                           "EAAAAEA3mH0CBY+toixxSZY9NMB4KmwzSxCfZD3OEvg3Kkb0", 
            //                           "EAAAAIJ3cwjDpjaPZVrLx4so4+NoF11JuHGOAuhnjib3YawZ", 
            //                           "FBA")) return false; 
            
            
            /*string Mes =
                    "SystemEnter Var.connectionID="    + Var.connectionID        + Var.CR +
                    "SystemEnter Var.connectionName="  + Var.connectionName      + Var.CR + 
                    "SystemEnter sys.UserForm="        + sys.UserForm            + Var.CR + 
                    "SystemEnter sys.Mode="        + sys.Mode.ToString() + Var.CR;
            sys.SM(Mes);
             
*/
//======================================================================
/*
            
            //if (cbType.SelectedIndex == 2)
            //{
                /*Var.connectionName = tbConnectionName.Text;
                sys.ServerType     = cbType.Text;
                sys.ServerName     = tbServerName.Text;             
                sys.DatabaseName   = tbDatabaseName.Text;
                sys.DatabaseLogin  = tbDatabaseLogin.Text;            
                sys.UserForm       = tbUserForm.Text;
                Var.UserLogin      = tbUserLogin.Text;        
                Var.UserPass       = tbUserPass.Text;
                sys.DatabasePass   = tbDatabasePass.Text;
                
                tbConnectionName.Text = Var.connectionName;
                tbServerName.Text     = sys.ServerName;             
                tbDatabaseName.Text   = sys.DatabaseName;
                tbDatabaseLogin.Text  = sys.DatabaseLogin;
                tbDatabasePass.Text   = sys.DatabasePass;                
                tbUserForm.Text       = sys.UserForm;    
                tbUserLogin.Text      = Var.UserLogin;    
                tbUserPass.Text       = Var.UserPass; */
            //} 
//======================================================================
/*
            
            //Поиск формы в БД.
            //if (Var.conSys.FormExists(UserForm) == false) 
            //{
            //    con1.CloseConnection(); 
            //    return;
            //}
                
            //Поиск пользователя в БД.
            //if (Var.conSys.GetUserID(UserLogin, UserPass) == "") 
            //{
            //    con1.CloseConnection(); 
            //    return;
            //}
             
*/
//======================================================================
/*           
            //Это нужно для одиночного запуска формы из Дизайнера - нам нужно передавать в параметрах ClientApp ID соединения.           
            //conLite.ConnectionID   = ConnectionID;
            //conLite.ConnectionName = ConnectionName;
            //conLite.UserForm       = UserForm; 
*/
//======================================================================
/*
    //if (sys.Enter(ConnectionName, false, ""))
          
            
            var con1 = new Connection();
            try
            {
                con1.InitConnection(ServerType, ServerName, DatabaseLogin, DatabasePass, DatabaseName);                
                if (con1.ConnectionActive) sys.SM("Подключение выполнено успешно!", MessageType.Information, "Подключение к базе данных");
                else return;
            }  catch 
            {
                sys.SM("Ошибка подключения!");
                return;
            } 
            
            //Поиск формы в БД.
            bool Success = Var.conSys.FormExists(UserForm);
            
            //Поиск пользователя в БД.
            if (Success) Success = (Var.conSys.GetUserID(UserLogin, UserPass) != "");
         
            if (con1.ConnectionActive       == true) con1.CloseConnection();
            if (Var.con.ConnectionActive    == true) Var.con.CloseConnection();             
            if (Var.conVar.connectionActive == true) Var.conSys.CloseConnection();
            */   
 
//======================================================================
/*
            //tbText1.Text = File.ReadAllText(sys.PathAdditional + "NewDatabase_SQLite.sql",   System.Text.Encoding.Default);
            //tbText2.Text = File.ReadAllText(sys.PathAdditional + "NewDatabase_Postgre.sql", System.Text.Encoding.Default);
            //tbText3.Text = File.ReadAllText(sys.PathAdditional + "NewDatabase_MSSQL.sql",    System.Text.Encoding.Default); 
*/ 
 //======================================================================
/*
 /*
    //Класс в отдельно потоке, позволяющий принимать сообщения от сервера приложений.
    //Этот код на клиенте - запускается сервер HTTP. Это нужно для того, чтобы 
    //принимать периодические сообщения от сервера приложений.
    public static class ServerWork
    {      
        static HttpListener ListenerHTTP1;
        static Thread threadserver1; 
        
        //Запуск сервера на клиенте.
        public static void ServerStart()
        {                    
             int MaxThreadsCount2    = Environment.ProcessorCount * 4; //Количество потоков по 4 на каждый процессор.
             int MinThreadsCount2    = 2; //Минимальное Количество потоков.                                            
        
        
            ThreadPool.SetMaxThreads(MaxThreadsCount2, MaxThreadsCount2);
            ThreadPool.SetMinThreads(MinThreadsCount2, MinThreadsCount2);                           
            ListenerHTTP1 = new HttpListener();
            //ListenerHTTP.Prefixes.Add(@"http://" + Var.LocalIP + @":" + sys.ClientAppPortDefault + @"/");
            ListenerHTTP1.Prefixes.Add(@"http://10.77.70.13:9596/");
            ListenerHTTP1.Start();  
            //ServerQueueHTTP();
            threadserver1 = new Thread(ServerQueueHTTP);  
            threadserver1.Start();
        }
        
        //Остановка сервера на клиенте.
        public static void ServerStop()
        {            
            if (ListenerHTTP1 != null) ListenerHTTP1.Stop();                             
            //try
            //{
            //    threadserver1.Abort();
            //    threadserver1.Join(); 
            //} catch {}                                                             
        }
                      
        //Очередь HTTP сервера. 
        private static void ServerQueueHTTP()
        {                    
            try    
            {
                //Принимаем клиентов в бесконечном цикле.
                while (true)
                {                                                                                           
                    ThreadPool.QueueUserWorkItem(ServerProcessHTTP, ListenerHTTP1.GetContext());                                                                                                      
                }
            }
            catch (ThreadAbortException ex) 
            {
                //Эту ошибку не обрабатываем, так как эта ошибка - остановка потока и не является ошибкой.
            }
            catch (Exception ex) //(SocketException ex)
            {
                //В случае другой ошибки, выводим что это за ошибка.                  
                MessageBox.Show("Модуль ServerWork. Ошибка локального сервера приложений : " + ex.Message);
            }     
        }        
        
        //Обработка запроса от клиента HTTP.В Данном случае у нас сервер приложений является клиентом.
        //Так как на каждом клиенте запускается сервер HTTP.        
        private static void ServerProcessHTTP(object o)   
        {                                                                                      
            var context2 = o as HttpListenerContext;
            HttpListenerResponse response = context2.Response;  
            string RequestStr1 = GetRequestString3(context2.Request.ContentEncoding, GetBoundary(context2.Request.ContentType), context2.Request.InputStream);
            File.AppendAllText(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Sys\bin\Debug.log", RequestStr1);   
            //MessageBox.Show(RequestStr1, "ServerProcessHTTP", MessageBoxButtons.OK,  MessageBoxIcon.Error);
            
            string ResponseStr2 = "WriteXLSX";
            byte[] buffer = System.Text.Encoding.Default.GetBytes(ResponseStr2); //UTF8          
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);                
            output.Close();
            
            //if (CommandCode == "201")
            //{
            //    ServerWork.ServerStop();
            //    Environment.Exit(0);
            //}
            //if (CommandCode == "202") sys.SM(RequestStr);   
            return;
            
            
            
            /*var context = o as HttpListenerContext;
            HttpListenerRequest  request  = context.Request;                                                 
            HttpListenerResponse response = context.Response;    
                   
            string CommandCode    = "";
            string ConnectionGUID = ""; 
            string FileName       = "";
            string RequestStrLog  = "";
            string ResponseStr    = "";
            string RequestStr     = "";           
            sys.GetComandCode(request.RawUrl, out CommandCode, ref ConnectionGUID, ref FileName);
            
            //Если сервер прислал файл, то сохраняем в темповой папке.
            if (FileName != "") 
            {               
                sys.GetRequestFile(context.Request.ContentEncoding, sys.GetBoundary(context.Request.ContentType), context.Request.InputStream, FileName);
                RequestStrLog = sys.GetDateTimeNow() + ": Запись файла: " + FileName + Var.CR;            
                //action = () => tbLogQuery.AppendText(RequestStrLog);
                //tbLogServer.Invoke(action); 
                ResponseStr = "Success";
            } else
            {           
                //RequestStr - это тело запроса от клиента.                
                RequestStr = sys.GetRequestString2(context.Request.ContentEncoding, sys.GetBoundary(context.Request.ContentType), context.Request.InputStream);                                                 
                RequestStrLog = sys.GetDateTimeNow() + ": " + RequestStr.Left(100) + "..."  + Var.CR;
                RequestStrLog = RequestStrLog.Replace(Var.CR, "") + Var.CR;                                                              
                ResponseStr = "Success"; //GetServerResponse(CommandCode, RequestStr);
                //string ResponseStr = "asd123нгшщзхъzxc";//Convert.ToBase64String(fileBuffer);  
            }
            byte[] buffer = System.Text.Encoding.Default.GetBytes(ResponseStr); //UTF8          
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer,0,buffer.Length);                
            output.Close();
            
            if (CommandCode == "201")
            {
                ServerWork.ServerStop();
                Environment.Exit(0);
            }
            if (CommandCode == "202") sys.SM(RequestStr); 
           
        }
        
        
        //Получить текст сообщения от клиента. Здесь текст, но без служеной информации.
        public static string GetRequestString3(System.Text.Encoding enc, string boundary, Stream input)
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
        }
        
        //Для разбора сообщения от клиента.
        public static String GetBoundary(String ctype)
        {
            return "--" + ctype.Split(';')[1].Split('=')[1];
        }
        
        //Для разбора сообщения от клиента.
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
    */
    
//StopExeProcessInPathMain();
//UpdateProgram();
//StopProcess("ServerApp");
//timer1.Start(); 
//*/
//======================================================================
/*
               
//string ErrorText = "";
            //Var.conSys.SelectGV("SELECT * FROM fbaClientCurrent", dataGridView1, ref ErrorText, true);
            //Var.conSys.SelectGV("SELECT * FROM fbaConList", dataGridView1, ref ErrorText, true); 
*/
 //======================================================================
/*
 //В строку.
        private void Button2Click(object sender, EventArgs e)
        {
            //string Mes     = "Привет клиент!";
            //string LocalIP = "10.77.70.13"; 
            ///int LocalPort  = 9596;
            //string ResClient = ServerAppHTTPMessage2(LocalIP, LocalPort, "202", "", Mes, "", 0);
            //sys.SM(ResClient);
            //sys.SM(sys.GetDateTimeNow2());
            //sys.SM("sys.asv1= " + sys.asv1 + Var.CR +
            //"sys.asv1= " + sys.asv1 + Var.CR + 
            //"Var.ApplicationVersion=" + Var.ApplicationVersion);
            
            /*if (!ServerConnected) ConnectToDatabase();
            //string SQL = "SELECT id, entityid, Name FROM Form;";
            string SQL = "SELECT * FROM Form;";
            System.Data.DataTable DT;
            Var.conSys.SelectDT1(SQL, out DT);
            dataGridView1.DataSource = DT;
            string TableString;
            string ErrorMes;
            sys.DataTableToString(DT, out TableString, out ErrorMes, true);             
            textBox1.Text = TableString;
            */
            //Directory.CreateDirectory(@"D:\test2\test4\test5");                  
            //string ErrorMes;
            //if (!sys.FolderClean(@"D:\test2", out ErrorMes, true)) sys.SM("Ошибка " + Var.CR + ErrorMes);                 
         
 
//======================================================================
/*
//Из строки.
        private void Button1Click(object sender, EventArgs e)
        {
            //System.Data.DataTable DT2;
            //string ErrorMes;
            //sys.DataTableFromString(out DT2, textBox1.Text, out ErrorMes, true);
            //dataGridView2.DataSource = DT2;
            //sys.SM("aass");
            var Form1 = new FormProgress();
            Form1.Show();
            
        } 
*/
//======================================================================
/*
 
        //В CSV.
        /*private void DTDToCSVClick(object sender, EventArgs e)
        {
            FileName = "";
            if (!ServerConnected) ConnectToDatabase();
            if (!ServerConnected) return;
            var sd = new SaveFileDialog();
            sd.Title = "Export object";
            sd.FileName = "Form";
            sd.Filter =  "json Files|*.json|All Files|*.*";
            if (sd.ShowDialog() == DialogResult.OK) FileName = sd.FileName;  
                             
            System.Data.DataTable DT;        
            string SQL = "SELECT * FROM Form";                     
            Var.conSys.SelectDT1(SQL, out DT);
            sys.DataTableToCSV(DT, FileName);                                                 
        }*/
        
        /*//Из CSV.
        private void BtnCSVToDTClick(object sender, EventArgs e)
        {
            System.Data.DataTable DT2;
            string ErrorMes;
            //DataTableFromCSV(out System.Data.DataTable DT, string FileName, out string ErrorMes, bool ErrorShow)
            sys.DataTableFromCSV(out DT2, FileName, out ErrorMes, true);
            dataGridView2.DataSource = DT2;                      
        }*/    
         
 
//======================================================================
/*
 // #region Вкладка Test.
                 
       
       
        //Послать сообщение на сервер приложений.
        /*public static string ServerAppHTTPMessage2(string ServerAppName, int ServerAppPort, string CommandCode, string GUID, string CommandText, string FileName, int WaitTimeout = 0)
        {                                                                 
            string uri = @"http://" + ServerAppName + @":" + ServerAppPort.ToString() + @"/" + CommandCode + ";" + GUID + ";";
            string contentType =  "text/html";            
            if (FileName != "") contentType = "image/jpeg";
            if (CommandText == "") CommandText = "Empty";
            string boundary          = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes     = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n"); //ASCII  //Default                    
            const string formdataTemplate = "Content-Disposition: form-data; name=file; filename=\"{0}\";\r\nContent-Type: {1}\r\n\r\n";           
            //if (FileName == "") FileName = "FileName";
            string formitem         = string.Format(formdataTemplate, Path.GetFileName(FileName), contentType);            
            byte[] formBytes        = System.Text.Encoding.UTF8.GetBytes(formitem);  //UTF8                   //Default 
            var request  = (HttpWebRequest) WebRequest.Create(uri);            
            request.KeepAlive       = true;
            request.Method          = "POST";
            request.ContentType     = "multipart/form-data; boundary=" + boundary;
            request.SendChunked     = true;
            if (WaitTimeout == 0) WaitTimeout = 300000; //300000 - 5 минут.
            request.Timeout         = WaitTimeout; 
            
            //Либо текст из CommandText, либо текст из файла.
            if (FileName != "")
            {
                using (var fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read))           
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    requestStream.Write(formBytes, 0, formBytes.Length);   
                    var buffer = new byte[1024*4];
                    int bytesLeft;   
                    while ((bytesLeft = fileStream.Read(buffer, 0, buffer.Length)) > 0) requestStream.Write(buffer, 0, bytesLeft);   
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                }  
            }
          
            if (CommandText != "")
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                requestStream.Write(formBytes, 0, formBytes.Length);                                                        
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(CommandText);
                requestStream.Write(buffer, 0, buffer.Length);                
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            }
   
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
                return sb.ToString();               
            }                 
        } */
        
       
        
//       #endregion 
 
//======================================================================
/*
           
        #region Вкладка Connect. Соединение с базой данных         
        
        //Из локальной базы загружаем список настроек соединения.    
        private void ConnectionListRefresh()
        {                    
            Var.conLite.SetComboBoxDataSourseSQL(cbConnection, "SELECT ConnectionName FROM fbaConList ORDER BY ConnectionName");
        }
        
        //Соединение с СУБД (MSSQL, Postgre, SQLite).
        private void ConnectToDatabase()
        {
            string ConnectionName = sys.ComboBoxStr(cbConnection);                               
            if (sys.EnterSimple(ConnectionName))
            {
                ServerConnected = true;
                lbDatabaseStatus2.ForeColor = Color.Green;
                lbDatabaseStatus2.Text = "Connected";                
               
            } else
            {
                ServerConnected = false;
                lbDatabaseStatus2.ForeColor = Color.Red; 
                lbDatabaseStatus2.Text = "Not connected";                                    
            }                    
        }
        
        //Событие. Кнопка разрыва соединения с СУБД (MSSQL, Postgre, SQLite).
        private void BtnDatabaseDisconnectClick(object sender, EventArgs e)
        {             
            if (Var.con != null)
                if (!Var.conSys.CloseConnection()) return;
             
            ServerConnected = false;
            lbDatabaseStatus2.Text = "Not connected";
            lbDatabaseStatus2.ForeColor = Color.Red;            
        }
        
        //Событие. Кнопка формы редактирования списка подключений.
        private void CbConnectionListClick(object sender, EventArgs e)
        {
            new FormConnectionList(Var.conLite).ShowDialog();            
            ConnectionListRefresh(); 
        }
        
        //Событие. Кнопка соединение с СУБД (MSSQL, Postgre, SQLite).
        private void BtnDatabaseConnectClick(object sender, EventArgs e)
        {                                      
            ConnectToDatabase();
        }                             
        
        #endregion  
                  
*/
//======================================================================
/*
        //Простое одключение к БД только для Utilites. Не используется сервером приложений клиентом и дизайнером.
        /*public static bool EnterSimple(string ConnectionName)
        {               
            if (ConnectionName == "") 
            {
                SM("Не задано имя подключения!");
                Environment.Exit(0);                
            }
            
            string ConnectionID;
            string ServerType;
            string ServerName;            
            string DatabaseName;
            string DatabaseLogin;
            string DatabasePass;
            string UserForm;
            string UserLogin;
            string UserPass;      
            
            if (conLite.GetParamConnectionName(
                                         ConnectionName,
                                     out ConnectionID,
                                     out ServerType,
                                     out ServerName,                                      
                                     out DatabaseName,
                                     out DatabaseLogin,
                                     out DatabasePass,
                                     out UserForm,
                                     out UserLogin,
                                     out UserPass) == false) return false;
            
            con = new Connection(); 
            con.ConnectionDirect = true;
            con.ConnectionID = ConnectionID;
            con.ConnectionName = ConnectionName;
            if (con.InitConnection(ServerType, ServerName, DatabaseLogin, DatabasePass, DatabaseName) == false) return false;
            SetSystemConnection();
            return true;
        }*/  
 
//======================================================================
/*
            //Если нет в списке соединения соединения с локальной БД, то создаем его.
            //if (!Var.CReateConnectionTest(Var.con)) return false; 
*/ 
 //======================================================================
/*
       
 /*
        //Событие. Кнопки редактора запросов
        private void TbSQL1Click(object sender, EventArgs e)
        {             
            string SenderName = sys.GetSenderName(sender);
            
            //FastColoredTextBox f;
            //f.Controls.Find().F
                
            string indexstr = tabControSQL.SelectedTab.Tag.ToString(); 
            var textSQL = (FastColoredTextBox)tabControSQL.Controls.Find("textSQL" + indexstr, true).First();                
            var dgvSQL  = (DataGridView)tabControSQL.Controls.Find("dgvSQL" + indexstr, true).First();
            if (SenderName == "tbSQL1") 
            {                     
                var tbSQLResult = (TextBox)tabControSQL.Controls.Find("tbSQLResult" + indexstr, true).First();                                                                    
                string SQL = textSQL.SelectedText;
                if (SQL == "") SQL = textSQL.Text; 
                DateTime DateTime1 = DateTime.Now;
                if (tbSQL5.Text == "remote") Var.conSys.RefreshGrid(SQL, dgvSQL);
                if (tbSQL5.Text == "local")  Var.conLite.RefreshGrid(SQL, dgvSQL);                                               
                tbSQLResult.Text = "Rows: " + dgvSQL.RowCount + "    Execute time: " + sys.GetDateTimeDiff(DateTime1, DateTime.Now);
            }
            
            //Очистка редактора запросов
            if (SenderName == "tbSQL2") textSQL.Clear();                               
                                 
            //Export to Excel
            if (SenderName == "cmSQLN1") sys.DataTableToExcel(dgvSQL);
            
            //Новая вкладка.
            //В процедуру передаются комплненты с перовй вкладки (которая никогда не удаляется)
            //чтобы на их примере сделать новую вкладку.
            //Можно было бы и без них - но тогда пришлось бы каждый раз в коде изменять свойства компонентов.
             if (SenderName == "tbSQL3")                           
                Var.TABControlPageAdd(tabControSQL, splitContainer1, textSQL1, pnlResultSQL1, tbSQLResult1, dgvSQL1, ref TabIndexSQL);
                          
            //Удалить вкладку
            if ((SenderName == "tbSQL4") && (tabControSQL.TabPages.Count > 1)) tabControSQL.SelectedTab.Dispose();
        }
        //Событие. Для того чтобы DataGridView не выдавал ошибок.
        private void DgvSQLDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        
        //Событие. Значение по умолчанию для тестового редактора запросов.
        private void TextSQLDoubleClick(object sender, EventArgs e)
        {
            if (textSQL1.Text == "") textSQL1.Text = "select ID, Name from Form";
        }
        */
         
 
//======================================================================
/*
 /*MyStack.Push('A');
            MyStack.Push('N');
            MyStack.Push('X');
            Console.WriteLine("Исходный стек: ");
            foreach (char s in MyStack)
            {
                //Console.Write(s);
                txTime.AppendText(s + Var.CR);
            }
            //Console.WriteLine("\n");
            while (MyStack.Count > 0)
            {
                //Console.WriteLine("Pop -> {0}", MyStack.Pop());
                char aa1s = MyStack.Pop();
                txTime.AppendText("Pop -> {0}" + aa1s + Var.CR);
            }
            if (MyStack.Count == 0)
                //Console.WriteLine("\nСтек пуст!");
                txTime.AppendText("\nСтек пуст!");
            //Console.ReadLine();
             
*/
 //======================================================================
/*
        //Разделяем на слова 2 вариант реализации
        /*private bool ParseWords2()
        {                                    
            DT = new System.Data.DataTable();
            DT.Columns.Add("Num");     //Порядковый номер файла или папки в обновлении
            DT.Columns.Add("Word");   //Порядковый номер обновления.
            DT.Columns.Add("Column3");     //Текущая дата.
            var word = new string[3]; 
                         
            string[] WordList = ParseStr.Split(' ');
            for (int i = 0; i < WordList.Length; i++)
            {
                if (WordList[i] == "") continue;                                                
                word[0] =  i.ToString();
                word[1] =  WordList[i];
                              
                DataRow row = DT.NewRow();
                row.ItemArray = word;
                DT.Rows.Add(row);
            }
            
            DGSelecteding.DataSource = DT;
            return true;               
        }
        
*/
//======================================================================
/*
   //Предыдущие и следующие значения..
        /*private bool LexNextPrev()
        {                            
            for (int i = 0; i < WordCount; i++)
            {
                //Предыдущие значения.
                if (i > 0)
                {
                    Words[i, 6]  = Words[i-1, 1];
                    Words[i, 8]  = Words[i-1, 4];
                    Words[i, 10] = Words[i-1, 5];
                }
                
                //Следующие значения.
                if (i < WordY-1)  
                {
                    Words[i, 7]  = Words[i+1, 1];
                    Words[i, 9]  = Words[i+1, 4];
                    Words[i, 11] = Words[i+1, 5];
                }
            }
            return true;
        } 
*/
//======================================================================
/*
 SELECT TOP (select 43254 + 45)
    t1.Number              AS col1,
    t1.Remarka             AS col2,
    t1.Insurer             AS col3,
    t1.DateBeg             AS col4,
    t1.DateEnd             AS col5,
    t1.Curator             AS col6,
    SUM(t1.SUMCurator)     AS col7,
    t1.VIPCurator          AS col8,
    SUM(t1.SUMVIPCurator)  AS col9,
    t1.Coordinator         AS col10,
    SUM(t1.SUMCoordinator) AS col11,
    t1.Filial              AS col12,
    t1.Product             AS col13
  FROM
    (SELECT top 134
      Z1.ДогСтрах.СтрахПродукт         AS Product,
      Z1.ДогСтрах.Организация.Наим     AS Filial,
      Z1.ДогСтрах.Страхователь.Наим    AS Insurer,
      ISNULL(Z1.ДогСтрах.Ремарка, ' ') + ' ' AS Remarka,
      Z1.ДогСтрах.Номер                AS Number,
      Z1.ДогСтрах.ДатаНачала           AS DateBeg,
      Z1.ДогСтрах.ДатаОкончания        AS DateEnd,
      Z1.Вариант.ВариантДогСтрах.Куратор.ФИОПолные                  AS Curator,
      Z1.Вариант.ВариантДогСтрах.ВИПВрачКуратор.ФИОПолные           AS VIPCurator,
      Z1.Вариант.ВариантДогСтрах.Координатор.Наим                   AS Coordinator,
      (CASE WHEN Z1.Вариант.ВариантДогСтрах.Куратор         IS NOT NULL THEN 1 ELSE 0 END)  AS SUMCurator,
      (CASE WHEN Z1.Вариант.ВариантДогСтрах.ВИПВрачКуратор  IS NOT NULL THEN 1 ELSE 0 END ) AS SUMVIPCurator,
      (CASE WHEN Z1.Вариант.ВариантДогСтрах.Координатор     IS NOT NULL THEN 1 ELSE 0 END ) AS SUMCoordinator
    FROM Застрахованный Z1
    WHERE
      (Z1.ДатаОкончания > GetDate())
      --Условия
      AND ((Z1.ДогСтрах.Организация = 111)                      OR (1=1))
      AND ((Z1.Вариант.ВариантДогСтрах.Куратор = 222)           OR (2=2))
      AND ((Z1.Вариант.ВариантДогСтрах.Координатор = 333)       OR (3=3))
      AND ((Z1.ДогСтрах.Страхователь.ИДСущностиОбъекта IN (444)) OR (4=4))
     --Конец условий
      AND (Z1.ДогСтрах.ТипДогСтрах in (1,2,29))
      AND (
              (Z1.Вариант.ВариантДогСтрах.Куратор IS NOT NULL)
           OR (Z1.Вариант.ВариантДогСтрах.ВИПВрачКуратор IS NOT NULL)
           OR (Z1.Вариант.ВариантДогСтрах.Координатор IS NOT NULL)
           )
    ) t1
  GROUP BY
    t1.Product,
    t1.Filial,
    t1.Insurer,
    t1.Remarka,
    t1.Number,
    t1.DateBeg,
    t1.DateEnd,
    t1.Curator,
    t1.VIPCurator,
    t1.Coordinator
*/
//======================================================================
/*
  //Получить Индекс поля по имени поля.
        private int GetIndex(string FieldName)
        {             
            switch(FieldName)   
            {  
                case "Num":           return 0;  //Порядковый номер слова.
                case "Word":          return 1;  //Слово.               
                case "Brace":         return 2;  //Скобка.
                case "BraceLevel":    return 3;  //Уровень вложенности скобки.
                case "LexID":         return 4;  //Вид лексемы.
                case "LexType":       return 5;  //Тип лексемы. 
                case "WordPrev":      return 6;  //Пред. слово.
                case "WordNext":      return 7;  //След. слово.
                case "LexIDPrev":     return 8;  //Пред. ID лексемы.
                case "LexIDNext":     return 9;  //След. ID лексемы.
                case "LexTypeIDPrev": return 10; //Пред. Type лексемы.
                case "LexTypeIDNext": return 11; //След. Type лексемы.
                case "BraceNum":    return 12; //Номер вложенности скобкок. 
                case "BlockEnd":      return 13; //Конец блока. 
                default:              return -1;
                                                          
            } 
        }
        
        //Получить имя поля по индексу поля.        
        private string GetName(int i)
        {          
            switch(i)   
            {  
                    case 0:  return "Num";           //Порядковый номер слова.
                    case 1:  return "Word";          //Слово.
                    case 2:  return "Brace";         //Скобка.
                    case 3:  return "BraceLevel";    //Уровень вложенности скобки.
                    case 4:  return "LexID";         //Вид лексемы.
                    case 5:  return "LexType";       //Тип лексемы.
                    case 6:  return "WordPrev";      //Пред. слово.
                    case 7:  return "WordNext";      //След. слово.
                    case 8:  return "LexIDPrev";     //Пред. ID лексемы.
                    case 9:  return "LexIDNext";     //След. ID лексемы.
                    case 10: return "LexTypeIDPrev"; //Пред. Type лексемы.
                    case 11: return "LexTypeIDNext"; //След. Type лексемы.
                    case 12: return "BraceNum";    //Номер вложенности скобкок.
                    case 13: return "BlockEnd";      //Конец блока. 
                    default: return "";
                                                          
            }
        }
        
*/
//======================================================================
/*
        const int WordPrev   = 7;     //Пред. слово.
        const int WordNext   = 8;     //След. слово.
        const int LexIDPrev  = 9;    //Пред. ID лексемы.
        const int LexIDNext  = 10;    //След. ID лексемы.
        const int LexTypeIDPrev = 11; //Пред. Type лексемы.
        const int LexTypeIDNext = 12; //След. Type лексемы. 
*/
//======================================================================
/*
  
            /*{"1", "Select", "SELECT", "Выбрать", "ВЫБРАТЬ", "2"},
                {"2", "From", "FROM", "Из", "ИЗ", "2"},
                {"3", "Where", "WHERE", "Где", "ГДЕ", "2"},
                {"4", "Group by", "GROUP BY", "Групп", "ГРУПП", "2"},
                {"5", "Order by", "ORDER BY", "Упоряд", "УПОРЯД", "2"},
                {"6", "Asc", "ASC", "Возр", "ВОЗР", "2"},
                {"7", "Desc", "DESC", "Убыв", "УБЫВ", "2"},
                {"8", "For", "FOR", "Для", "ДЛЯ", "2"},
                {"9", "Like", "LIKE", "Подобно", "ПОДОБНО", "2"},
                {"10", "And", "AND", "NULL", "NULL", "2"},
                {"11", "Between", "BETWEEN", "Между", "МЕЖДУ", "2"},
                {"12", "Union", "UNION", "Объединить", "ОБЪЕДИНИТЬ", "2"},
                {"13", "Having", "HAVING", "NULL", "NULL", "2"},
                {"14", ",", ",", "NULL", "NULL", "1"},
                {"15", "Over", "OVER", "NULL", "NULL", "8"},
                {"16", "Into", "INTO", "NULL", "NULL", "2"},
                {"17", "(", "(", "NULL", "NULL", "1"},
                {"18", ")", ")", "NULL", "NULL", "1"},
                {"19", "+", "+", "NULL", "NULL", "1"},
                {"20", "-", "-", "NULL", "NULL", "1"},
                {"21", "*", "*", "NULL", "NULL", "1"},
                {"22", "/", "/", "NULL", "NULL", "1"},
                {"23", "<", "<", "NULL", "NULL", "1"},
                {"24", ">", ">", "NULL", "NULL", "1"},
                {"25", "or", "OR", "NULL", "NULL", "2"},
                {"26", "?", "?", "NULL", "NULL", "1"},
                {"27", "@", "@", "NULL", "NULL", "2"},
                {"28", "Top", "TOP", "Первые", "ПЕРВЫЕ", "2"},
                {"29", "With", "WITH", "Вместе", "ВМЕСТЕ", "2"},
                {"30", "=", "=", "NULL", "NULL", "1"},
                {"31", "Max", "MAX", "Макс", "МАКС", "8"},
                {"32", "Min", "MIN", "Мин", "МИН", "8"},
                //{"33", "by", "BY", "по", "ПО", "2"},
                {"34", "in", "IN", "NULL", "NULL", "2"},
                {"35", "all", "ALL", "все", "ВСЕ", "2"},
                {"36", "Full", "FULL", "NULL", "NULL", "2"},
                {"37", "left", "LEFT", "Левое", "ЛЕВОЕ", "2"},
                {"38", "right", "RIGHT", "Правое", "ПРАВОЕ", "2"},
                {"39", "outer", "OUTER", "Внеш", "ВНЕШ", "2"},
                {"40", "On", "ON", "NULL", "NULL", "2"},
                
                {"41", "Merge", "MERGE", "NULL", "NULL", "2"},
                {"42", "Loop", "LOOP", "NULL", "NULL", "2"},
                {"43", "Hash", "HASH", "NULL", "NULL", "2"},
                {"44", "Inner", "INNER", "NULL", "NULL", "2"},
                {"45", "join", "JOIN", "Соед", "СОЕД", "2"},
                {"46", "XML", "XML", "NULL", "NULL", "2"},
                {"47", "Path", "PATH", "NULL", "NULL", "8"},
                {"48", "Case", "CASE", "Случай", "СЛУЧАЙ", "2"},
                {"49", "When", "WHEN", "Когда", "КОГДА", "2"},
                {"50", "Then", "THEN", "Тогда", "ТОГДА", "2"},
                {"51", "Else", "ELSE", "Иначе", "ИНАЧЕ", "2"},
                {"52", "End", "END", "Конец", "КОНЕЦ", "2"},
                {"53", "is", "IS", "NULL", "NULL", "2"},
                {"54", "not", "NOT", "NULL", "NULL", "2"},
                {"55", "NULL", "NULL", "NULL", "NULL", "2"},
                {"56", "As", "AS", "Как", "КАК", "2"},
                {"57", "Cross", "CROSS", "NULL", "NULL", "2"},
                {"58", "Distinct", "DISTINCT", "NULL", "NULL", "2"},
                {"59", "OID", "OID", "ИД", "ИД", "4"},
                {"60", "EID", "EID", "ИДСущ", "ИДСУЩ", "4"},
                {"61", "EBrief", "EBRIEF", "СокрСущ", "СОКРСУЩ", "4"},
                {"62", "EName", "ENAME", "ИмяСущ", "ИМЯСУЩ", "4"},
                {"63", "ADate", "ADATE", "ДатаАтр", "ДАТААТР", "4"},
                {"64", "ODate", "ODATE", "ДатаСостОбъекта", "ДАТАСОСТОБЪЕКТА", "4"},
                {"65", "AllHist", "ALLHIST", "ВсяИстория", "ВСЯИСТОРИЯ", "4"},
                {"66", "ADateHist", "ADATEHIST", "ДатаАтрИст", "ДАТААТРИСТ", "4"},
                {"67", "SysType", "SYSTYPE", "СистемныйТип", "СИСТЕМНЫЙТИП", "4"},
                {"68", "Limit", "LIMIT", "Лимит", "ЛИМИТ", "2"},
                {"69", "Offset", "OFFSET", "Сдвиг", "СДВИГ", "2"},
                {"70", "EntityAlias", "ENTITYALIAS", "ПсевдонимСущности", "ПСЕВДОНИМСУЩНОСТИ", "2"},
                {"71", "!", "!", "NULL", "NULL", "1"},
                {"72", "%", "%", "NULL", "NULL", "1"},
                {"73", "Actual", "ACTUAL", "Актуальные", "АКТУАЛЬНЫЕ", "2"},
                {"74", "Archive", "ARCHIVE", "Архивные", "АРХИВНЫЕ", "2"},
                {"75", "Deleted", "DELETED", "Удаленные", "УДАЛЕННЫЕ", "2"},
                {"76", "Test", "TEST", "Тестовые", "ТЕСТОВЫЕ", "2"},
                {"77", "OName", "ONAME", "ИмяОбъекта", "ИМЯОБЪЕКТА", "4"}
                */ 
 
//======================================================================
/*
            //ParseStr = ParseStr.Replace("  ", " ");
            //ParseStr = ParseStr.ReplaceIgnoreCase("  ", " ");
            //ParseStr = ParseStr.ReplaceStr("     ", " ");
            //ParseStr = ParseStr.ReplaceStr("    ", " ");
            //ParseStr = ParseStr.ReplaceStr("   ", " ");
            //ParseStr = ParseStr.ReplaceStr("  ", " ");
           
            //string line = "jsd sdsdj sd   sjd s sd jsd s d    jj";
            //ParseStr = string.Join(" ", ParseStr.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries));
            //char pr = ' ';
            //ParseStr = string.Join(pr.ToString(), ParseStr.Split(new char[] {pr}, StringSplitOptions.RemoveEmptyEntries));
            
            //ParseStr = sys.ReplaceSpace(ParseStr);
            //var regex = new Regex(ParseStr, RegexOptions.IgnoreCase );
            //ParseStr = Regex.Replace(ParseStr, "GROUP BY ", "GROUPBY ", RegexOptions.IgnoreCase);
                       
            //ParseStr = ParseStr.ReplaceIgnoreCase("GROUP BY ", "GROUPBY ").ReplaceIgnoreCase("ORDER BY ", "ORDERBY ");      
*/ 
 //======================================================================
/*
          
        //Копирование значений колонки в другую колонку .
        //private void CopyColumn(int ColumnSrc, int ColumnDest)
        //{
        //    for (int i = 0; i < WordCount; i++) Words[i, ColumnDest] = Words[i, ColumnSrc];                                                               
        //} 
*/
//======================================================================
/*
         //Поиск конца блока ORDER.
        /*private void FindOrder(int Pos)
        {
            //Поиск до GROUP BY или ORDER BY или до конца запроса.
            string BraceNumLocal = Words[Pos, BraceNum];
            for (int i = (Pos + 1); i <  WordCount; i++)
            if (Words[i, BraceNum] == BraceNumLocal) 
            {              
                if (Words[i, Lex] == "UNION")
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    Words[Pos, Proc] = "ORDER 1";
                    return;
                }              
            } 
            
            int i1 = FindLastBaraceNum(BraceNumLocal);
            if (Words[i1, Lex] == ")") Words[Pos, BlockEnd] = (i1 - 1).ToString();
                else Words[Pos, BlockEnd] = i1.ToString();
            Words[Pos, Proc] = "ORDER 2";                                                     
        }
*/
 //======================================================================
/*
         //Поиск конца блока ON.
        /*private void FindOn(int Pos)
        {
            //Поиск WHERE, UNION, один из Джойнов на том же уровне что и FROM.
            string BraceNumLocal = Words[Pos, BraceNum];
            for (int i = (Pos + 1); i <  WordCount; i++) //for (int i = WordCount; i > -1 ; i--)
            if (Words[i, BraceNum] == BraceNumLocal) 
            {              
                if ((Words[i, Lex] == "WHERE") || 
                    (Words[i, Lex] == "UNION") ||
                    (Words[i, Lex] == "ON")    ||
                    (Words[i, LexType] == "5") //Все JOIN имеют LexType = 5.
                   )
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    Words[Pos, Proc] = "ON 1";
                    return;
                }              
            } 
           
            //Если дошло до этого места, значит после FROM ничего нет и нужно взять конец запроса.    
            int i1 = FindLastBaraceNum(BraceNumLocal);
            if (Words[i1, Lex] == ")") Words[Pos, BlockEnd] = (i1 - 1).ToString();
                else Words[Pos, BlockEnd] = i1.ToString();
            Words[Pos, Proc] = "ON 2";                                                   
        }*/ 
                
        //Поиск конца блока WHERE.
        /*private void FindWhere(int Pos)
        {
            //Поиск до GROUP BY или ORDER BY или до конца запроса.
            string BraceNumLocal = Words[Pos, BraceNum];
            for (int i = (Pos + 1); i <  WordCount; i++) //for (int i = WordCount; i > -1 ; i--)
            if (Words[i, BraceNum] == BraceNumLocal) 
            {              
                if ((Words[i, Lex] == "GROUP BY") || 
                    (Words[i, Lex] == "ORDER BY") ||
                    (Words[i, Lex] == "UNION"))
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    Words[Pos, Proc] = "WHERE 1";
                    return;
                }              
            } 
            
            int i1 = FindLastBaraceNum(BraceNumLocal);
            if (Words[i1, Lex] == ")") Words[Pos, BlockEnd] = (i1 - 1).ToString();
                else Words[Pos, BlockEnd] = i1.ToString();
            Words[Pos, Proc] = "WHERE 2";                                                     
        }
*/
//======================================================================
/*
         //Поиск конца блока JOIN.
        /*private void FindJoin(int Pos)
        {
            //Поиск ON
            string BraceNumLocal = Words[Pos, BraceNum];
            for (int i = (Pos + 1); i <  WordCount; i++)
            if (Words[i, BraceNum] == BraceNumLocal) 
            {              
                if ((Words[i, Lex] == "ON") ||                     
                    (Words[i, LexType] == "5") //Все JOIN имеют LexType = 5.
                   )
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    Words[Pos, Proc] = "JOIN 1";
                    SetEntityAttr(Pos + 1, i, "ENTITY");  
                    return;
                }              
            } 
           
            //Если дошло до этого места, значит после FROM ничего нет и нужно взять конец запроса.    
            int i1 = FindLastBaraceNum(BraceNumLocal);
            if (Words[i1, Lex] == ")") i1--;  
            Words[Pos, BlockEnd] = i1.ToString();
            Words[Pos, Proc] = "JOIN 2";
            SetEntityAttr(Pos + 1, i1, "ENTITY"); 
        } 
*/
//======================================================================
/*
               
        //Поиск конца блока FROM.
        /*private void FindFrom(int Pos)
        {
            //Если после FROM скобка, то поиск закрывающей скобки.
            if (Words[Pos + 1, Lex] == "(") 
            {
                Words[Pos, BlockEnd] = Words[Pos + 1, Brace];
                Words[Pos, Proc] = "FROM 1";
                return;
            }
            
            string BraceNumLocal = Words[Pos, BraceNum];
            
            //Поиск WHERE, UNION, один из Джойнов на том же уровне что и FROM.
            for (int i = (Pos + 1); i <  WordCount; i++) //for (int i = WordCount; i > -1 ; i--)
            if (Words[i, BraceNum] == BraceNumLocal) 
            {              
                if ((Words[i, Lex] == "WHERE") || 
                    (Words[i, Lex] == "UNION") ||
                    (Words[i, LexType] == "5") //Все JOIN имеют LexType = 5.
                   )
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    Words[Pos, Proc] = "FROM 2";
                    SetEntityAttr(Pos + 1, i, "ENTITY");
                    return;
                }              
            } 
           
            //Если дошло до этого места, значит после FROM ничего нет и нужно взять конец запроса.       
            int i1 = FindLastBaraceNum(BraceNumLocal);
            if (Words[i1, Lex] == ")") i1--;                 
            Words[Pos, BlockEnd] = i1.ToString();                   
            Words[Pos, Proc] = "FROM 3";
            SetEntityAttr(Pos + 1, i1, "ENTITY");                                        
        }
                            
*/
//======================================================================
/*   ///string[] rows = System.IO.File.ReadAllLines(FileName); 
 // MessageBox.Show(sr.ReadToEnd());
                
                //FileStream fs = System.IO.File.OpenRead("sdf");                  
                //FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);             
                //byte[] data = Encoding.UTF8.GetBytes("Kbyte.Ru");              
                //fs.Write(data, 0, data.Length);              
                //fs.Close(); 
*/
//======================================================================
/*
         
        //TODO: Транслитерация латиницы в строку. Код на JAVA переписать потом.
        public static string Lat2Cyr(string ValueStr)
        {
            //https://habrahabr.ru/post/265455/
            string s = ValueStr.ToUpper();
            string sb = "";
            
            int i = 0;
            while(i < s.Length)
            {   //идем по строке слева направо. В принципе, подходит для обработки потока
                char ch = s[i];
                string sym = "";
                if(ch == 'J')
                {   //префиксная нотация вначале
                    i++; //преходим ко второму символу сочетания
                    ch = s[i];
                    switch (ch){
                            case 'E': sym = "Ё"; break;
                        case 'S':
                            sym = "Щ";
                            i++; //преходим к третьему символу сочетания
                            if(s[i] != 'H') throw new Exception("Illegal transliterated symbol at position " +i); //вариант третьего символа только один
                            break;
                        case 'H': sb = sb + 'Ь"; break;
                        case 'U': sb = sb + 'Ю"; break;
                        case 'A': sb = sb + 'Я"; break;
                        default: throw new Exception("Illegal transliterated symbol at position " +i);
                    }
                }else if(i+1 < s.Length && s[i+1] == 'H' && !(i+2 < s.Length && s[i+2] == 'H'))
                {   //постфиксная нотация, требует информации о двух следующих символах. Для потока придется сделать обертку с очередью из трех символов.
                    switch (ch){
                        case 'Z': sb = sb + 'Ж"; break;
                        case 'K': sb = sb + 'Х"; break;
                        case 'C': sb = sb + 'Ч"; break;
                        case 'S': sb = sb + 'Ш"; break;
                        case 'E': sb = sb + 'Э"; break;
                        case 'H': sb = sb + 'Ъ"; break;
                        case 'I': sb = sb + 'Ы"; break;
                        default: throw new Exception("Illegal transliterated symbol at position "+i);
                    }
                    i++; //пропускаем постфикс
                }else{ //одиночные символы
                    switch (ch){
                        case 'A': sb = sb + 'А"; break;
                        case 'B': sb = sb + 'Б"; break;
                        case 'V': sb = sb + 'В"; break;
                        case 'G': sb = sb + 'Г"; break;
                        case 'D': sb = sb + 'Д"; break;
                        case 'E': sb = sb + 'Е"; break;
                        case 'Z': sb = sb + 'З"; break;
                        case 'I': sb = sb + 'И"; break;
                        case 'Y': sb = sb + 'Й"; break;
                        case 'K': sb = sb + 'К"; break;
                        case 'L': sb = sb + 'Л"; break;
                        case 'M': sb = sb + 'М"; break;
                        case 'N': sb = sb + 'Н"; break;
                        case 'O': sb = sb + 'О"; break;
                        case 'P': sb = sb + 'П"; break;
                        case 'R': sb = sb + 'Р"; break;
                        case 'S': sb = sb + 'С"; break;
                        case 'T': sb = sb + 'Т"; break;
                        case 'U': sb = sb + 'У"; break;
                        case 'F': sb = sb + 'Ф"; break;
                        case 'C': sb = sb + 'Ц"; break;
                        default: sb = sb + ch; break;
                    }
                }
    
                i++; //переходим к следующему символу
            }
            return sb;
        }
        
*/
//======================================================================
/*
 //Функция для создания запроса INSERT для вставки записей в таблицу в БД.
        public static string GetTextInsert(System.Data.DataTable DT, string TableName)
        {   
            /*
             * INSERT INTO TableName (ID,INSERT INTO TableName (EntityID,INSERT INTO TableName (ConnectionName,INSERT INTO TableName (ComputerName,INSERT INTO TableName (ComputerUserName,INSERT INTO TableName (UserForm,INSERT INTO TableName (UserID,INSERT INTO TableName (SystemName,INSERT INTO TableName (EnterDate) VALUES ('1','107','Прямое подключение 2','COMP2879','Travin','Form7','1','DesignerApp','30.05.2017 16:48:52');
INSERT INTO TableName (ID,INSERT INTO TableName (EntityID,INSERT INTO TableName (ConnectionName,INSERT INTO TableName (ComputerName,INSERT INTO TableName (ComputerUserName,INSERT INTO TableName (UserForm,INSERT INTO TableName (UserID,INSERT INTO TableName (SystemName,INSERT INTO TableName (EnterDate) VALUES ('2','107','Прямое подключение test2','COMP2879','Travin','FormMain1','1','ClientApp','30.05.2017 16:49:33');
INSERT INTO TableName (ID,INSERT INTO TableName (EntityID,INSERT INTO TableName (ConnectionName,INSERT INTO TableName (ComputerName,INSERT INTO TableName (ComputerUserName,INSERT INTO TableName (UserForm,INSERT INTO TableName (UserID,INSERT INTO TableName (SystemName,INSERT INTO TableName (EnterDate) VALUES ('3','107','Прямое подключение test2','COMP2879','Travin','FormMain1','1','ClientApp','30.05.2017 16:50:19');
INSERT INTO TableName                       InsertText.ToString()
             */
            
            //begin tran
            //set identity_insert [fbaEnterHist] on
            
            
            /*var InsertText = new StringBuilder("", 10000); 
            var InsertBeg = new StringBuilder("INSERT INTO " + TableName + " (", 1000);  
            int iColumnCount = DT.Columns.Count;
            
            for (int i = 0; i < iColumnCount ; i++) 
            {
                InsertBeg.Append(DT.Columns[i].ColumnName);
                if DT.Columns[i].
                if (i < iColumnCount - 1) InsertBeg.Append(",");
            }            
            InsertBeg.Append(") VALUES (");
             
            string InsertBegStr = InsertBeg.ToString();
            var InsertStr = new StringBuilder("", 1000);           
            for (int i = 0; i < DT.Rows.Count; i++)
            {             
                InsertStr.Clear();
                for (int j = 0; j < iColumnCount - 1; j++) 
                    InsertStr.Append("'" + DT.Rows[i][j] + "',");
                InsertStr.Append("'" + DT.Rows[i][iColumnCount - 1] + "')");                                    
                InsertText.Append(InsertBegStr + InsertStr.ToString() + ";" + Var.CR);
            }
            return InsertText.ToString();
            
            //set identity_insert [fbaEnterHist] off
            //commit tran
        } */ 
 
//======================================================================
/*
         //Получение одного значения INTEGER.
        /*public bool GetInt(string SQL, out int Value)
        {
            string s1;
            string s2;
            string s3;
            string s4;
            string s5;
            string s6;
            string s7;
            string s8;
            string s9;
            string s10;
            bool Result = GetValue10(SQL, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
            Value = 0;
            if (!Result) return false;
            if (s1 == "") return false;
            Value = Convert.ToInt32(s1);  
            return true;
        }
*/ 
 //======================================================================
/*         //Получить новый GUID соединения с БД.
        //public static string GetNewConnectionGUID(string AppName)
        //{
            
        //}
 
*/
//======================================================================
/*
      /*public static Delegate CSharpCompilate(Type DelegateType, string Expression)
        {
            // Получаем образ компилируемого метода для информации о параметрах(число, типы, имена)
            MethodInfo InvokeInfo = DelegateType.GetMethod("Invoke");
            if (InvokeInfo == null) 
                throw new NotSupportedException(string.Concat("Type \"", DelegateType.ToString(), "\" must be is delegate"));
            else
            {
                // строка коспиляции С# кода
                StringBuilder compileString = new StringBuilder(128);
                // Обявляем класс со статическим методом "Invoke"
                compileString.Append("class _My{public static ").Append(InvokeInfo.ReturnType == typeof(void)?"void":InvokeInfo.ReturnType.FullName).Append(" ").Append("Invoke(");
                // Получаем информацию обо всех параметрах функции
                // И заносим их в строку-компиляции
                foreach (var Param in InvokeInfo.GetParameters())
                {
                    // Если параметр имет тип ref или out
                    if (Param.ParameterType.IsByRef) compileString.Append("ref ").Append(Param.ParameterType.FullName.Replace('+', '.').TrimEnd('&')).Append(" ").Append(Param.Name).Append(",");
                    // Иначе
                    else compileString.Append(Param.ParameterType.FullName.Replace('+','.')).Append(" ").Append(Param.Name).Append(",");
                }
                compileString[compileString.Length - 1] = ')';
                // Добавляем вместо тела функции наше выражение
                compileString.Append("{").Append(Expression).Append(";}}");
         
                //Объявляем провайдер кода С#
                CSharpCodeProvider prov = new CSharpCodeProvider();
                // В параметрах компидяции - подключаем все сборки "родительского" приложения(чтоб не мучиться)
                
                CompilerParameters cp = new CompilerParameters(Array.ConvertAll<Assembly, string>(AppDomain.CurrentDomain.GetAssemblies(), x => x.Location));
                // Помечаем сборку, как временную
                cp.GenerateInMemory = true;
                // Обрабатываем CSC компилятором
                CompilerResults results = prov.CompileAssemblyFromSource(cp, compileString.ToString());
                // Если есть ошибки - собираем их и выдаем исключение
                if (results.Errors.Count > 0)
                {
                    StringBuilder ErrorMesing = new StringBuilder("Error of C# Compilation CS");
                    ErrorMesing.AppendLine("Number of Errors: " + results.Errors.Count);
                    foreach (CompilerError err in results.Errors)
                        ErrorMesing.AppendLine(err.ErrorText);
                    throw new NotSupportedException(ErrorMesing.ToString());
                }
                // Если ошибок нет, то с помощью отражения достаем из временной сборки нашу функцию
                else return Delegate.CreateDelegate(DelegateType, results.CompiledAssembly.GetType("_My").GetMethod("Invoke"));
            }
        }
                
        
        
        //Выполнить код C#
        public static Delegate CSharpCodeDelegate(Type DelegateType, string Expression)
        {
            
            //Как это использовать?
            //Для математической фунцкции, например z=x+y/c?             
            /*public delegate void MyFunc(out double z, double x, double y, double c);
            //unsafe static void Main(string[] args)
            //{
            //    var F = CSharpCompilate(typeof(MyFunc), "z=x+y/c") as MyFunc;
            //    double z;
            //    F(out z, 6, 4, 3);
            //    Console.WriteLine(z);
            //}
            
            //Для работы с NET типами, которых нет в базовых NET библиотеках?
            //public class My{ public void Print(){ Console.WriteLine("Remander"); }}
            //public delegate void MyFunc(My my);
            //unsafe static void Main(string[] args)
            //{
            //    var F = CSharpCompilate(typeof(MyFunc), "my.Print();") as MyFunc;
            //    F(new My());
            //}
            //            
                               
            // Получаем образ компилируемого метода для информации о параметрах(число, типы, имена)
            MethodInfo InvokeInfo = DelegateType.GetMethod("Invoke");
            if (InvokeInfo == null) 
                throw new NotSupportedException(string.Concat("Type \"", DelegateType.ToString(), "\" must be is delegate"));
            else
            {
                // строка коспиляции С# кода
                var compileString = new StringBuilder(128);
                // Обявляем класс со статическим методом "Invoke"
                compileString.Append("class _My{public static ").Append(InvokeInfo.ReturnType == typeof(void)?"void":InvokeInfo.ReturnType.FullName).Append(" ").Append("Invoke(");
                // Получаем информацию обо всех параметрах функции
                // И заносим их в строку-компиляции
                foreach (var Param in InvokeInfo.GetParameters())
                {
                    // Если параметр имет тип ref или out
                    if (Param.ParameterType.IsByRef) compileString.Append("ref ").Append(Param.ParameterType.FullName.Replace('+', '.').TrimEnd('&')).Append(" ").Append(Param.Name).Append(",");
                    // Иначе
                    else compileString.Append(Param.ParameterType.FullName.Replace('+','.')).Append(" ").Append(Param.Name).Append(",");
                }
                compileString[compileString.Length - 1] = ')';
                // Добавляем вместо тела функции наше выражение
                compileString.Append("{").Append(Expression).Append(";}}");
         
                //Объявляем провайдер кода С#
                var prov = new CSharpCodeProvider();
                // В параметрах компидяции - подключаем все сборки "родительского" приложения(чтоб не мучиться)
                
                var cp = new CompilerParameters(Array.ConvertAll<Assembly, string>(AppDomain.CurrentDomain.GetAssemblies(), x => x.Location));
                // Помечаем сборку, как временную
                cp.GenerateInMemory = true;
                // Обрабатываем CSC компилятором
                CompilerResults results = prov.CompileAssemblyFromSource(cp, compileString.ToString());
                // Если есть ошибки - собираем их и выдаем исключение
                if (results.Errors.Count > 0)
                {
                    var ErrorMesing = new StringBuilder("Error of C# Compilation CS");
                    ErrorMesing.AppendLine("Number of Errors: " + results.Errors.Count);
                    foreach (CompilerError err in results.Errors)
                        ErrorMesing.AppendLine(err.ErrorText);
                    throw new NotSupportedException(ErrorMesing.ToString());
                }
                // Если ошибок нет, то с помощью отражения достаем из временной сборки нашу функцию
                else return Delegate.CreateDelegate(DelegateType, results.CompiledAssembly.GetType("_My").GetMethod("Invoke"));
            }
        }
                
*/
 //======================================================================
/*
           
        //Установка типа блока. Атрибут или Сущность.
        /*private void CheckNullLex()
        {
            for (int i = 0; i <= WordCount; i++) 
            {   
                 if (Words[i, LexType] == null)
                 {
                     sys.SM("Ошибка CheckNullLex " + i.ToString());
                 }
                         
            }
        }
*/
//======================================================================
/*
 //Установка номера скобок. Это не уровень вложенности, а номер вложенности.              
        private void SetBraceNum()
        {                                              
            //return;
            //Пример: (111(222)111(222)111((333)222)111) - это BraceLevel.
            //Пример: (111(222)111(333)111((444)555)111) - это BraceNum.
            //BraceNum - нужен для того чтобы определить: если два слова находятся в одном BraceNum - то это ТОЧНО части одного SELECT.
            //BraceLevel - не дает ответа на этот вопрос (какие части относятся к данному SELECT), потому что внутри одно SELECT могут быть вложенные SELECT,
            //а BraceLevel у двух вложенных SELECT будут ОДИНАКОВЫЕ, на примере это 222.           
            BraceNumMax = 2;            
            for (int i = 0; i < WordCount; i++)
            {              
                if (Words[i, Lex] == "(")
                {
                    int N = Convert.ToInt32(Words[i, Brace]);
                    ReplaceBraceNum(i, N, Words[i, BraceNum], BraceNumMax.ToString());                    
                    //Замена значения BraceNum.                     
                    //for (int j = i; j <= N; j++)
                    //{
                    //    if (Words[j, BraceNum] == Words[i, BraceNum]) Words[j, BraceNum] = BraceNumMax.ToString();    
                    //}                                        
                    BraceNumMax++;
                }
            }             
        } 
*/
//======================================================================
/*
         //Поиск конца блока SELECT.
        /*private void FindSelect(int Pos)
        {
            string BraceNumLocal = Words[Pos, BraceNum];
            
            //Поиск UNION, идущего после SELECT, на том же уровне.          
            for (int i = (Pos + 1); i <  WordCount; i++)
            if ((Words[i, Lex] == "UNION") && (Words[i, BraceNum] == BraceNumLocal)) 
            {
                Words[Pos, BlockEnd] = (i - 1).ToString();
                Words[Pos, Proc] = "SELECT 1";
                return;
            }
            
            //Поиск закрывающей скобки, если весь SELECT лежит в скобках, а UNION внутри скобок нет.          
            if (Pos > 0)
            if  ((Words[Pos - 1, Lex] == "("))
            {
                Words[Pos, BlockEnd] = StringAdd(Words[Pos - 1, Brace], -1) ;
                Words[Pos, Proc] = "SELECT 2";
                return;  
            }
            
            //UNION не нашли, продолжаем поиск.
            //Поиск последнего указанного BraceNum - это и будет конец SELECT.
            int i1 = FindLastBaraceNum(BraceNumLocal);
            if (Words[i1, Lex] == ")") Words[Pos, BlockEnd] = (i1 - 1).ToString();
                else Words[Pos, BlockEnd] = i1.ToString();
            Words[Pos, Proc] = "SELECT 3";     
        }*/
        
        //Поиск конца блока TOP.
        /*private void FindTop(int Pos)
        {
            //Если после TOP идут скобки, то поиск конца скобки.
            //Иначе просто следующее значение.
            if (Words[Pos + 1, Lex] == "(") 
            {
                Words[Pos, BlockEnd] = Words[Pos + 1, Brace];
                Words[Pos + 1, Proc] = "TOP 1";               
            }
            else 
            {
                Words[Pos, BlockEnd] = Words[Pos + 1, Num];
                Words[Pos + 1, Proc] = "TOP 2";
            }
        }
*/
//======================================================================
/*
     //Поиск конца блока GROUP.
        private void FindBlock(int Pos, string BlockName)
        {
            
            if (BlockName == "TOP")
            {   
                //Если после TOP идут скобки, то поиск конца скобки.
                //Иначе просто следующее значение.
                if (Words[Pos + 1, Lex] == "(") 
                {
                    Words[Pos, BlockEnd] = Words[Pos + 1, Brace];
                    Words[Pos + 1, Proc] = "TOP 1";               
                }
                else 
                {
                    Words[Pos, BlockEnd] = Words[Pos + 1, Num];
                    Words[Pos + 1, Proc] = "TOP 2";
                }
                return;
            }
            
            //Поиск до GROUP BY или ORDER BY или до конца запроса.
            string BraceNumLocal = Words[Pos, BraceNum];
            for (int i = (Pos + 1); i <  WordCount; i++)
            if (Words[i, BraceNum] == BraceNumLocal) 
            {                              
                string Lexem = Words[i, Lex];
                
                //Поиск конца FROM.
                //Если после FROM скобка, то поиск закрывающей скобки.
                if (BlockName == "FROM")
                {   
                    if (Words[Pos + 1, Lex] == "(") 
                    {
                        Words[Pos, BlockEnd] = Words[Pos + 1, Brace];
                        Words[Pos, Proc] = "FROM 1";
                        return;
                    }
                    
                    if ((Lexem == "WHERE") || (Lexem == "UNION") || (Words[i, LexType] == "5")) //Все JOIN имеют LexType = 5.
                    {
                        Words[Pos, BlockEnd] = (i - 1).ToString();
                        Words[Pos, Proc] = "FROM 2";
                        SetEntityAttr(Pos + 1, i, "ENTITY");
                        return;
                    }                             
                }
                
                //Поиск конца JOIN.
                if (BlockName == "JOIN")
                {                   
                    if (Words[Pos + 1, Lex] == "(")
                    {
                        Words[Pos, BlockEnd] = Words[Pos + 1, Brace];
                        Words[Pos, Proc] = "JOIN 1";
                        return; 
                    }
                    
                    if ((Words[Pos + 2, Lex] == "ON") || (Words[Pos + 2, LexType] == "5"))
                    {
                        Words[Pos, BlockEnd] = (Pos + 1).ToString();
                        Words[Pos + 1, LexType] = "ENTITY";  
                        Words[Pos, Proc] = "JOIN 2";
                        return; 
                    }
                    return; 
                }                       
                
                //Поиск конца ON.
                if (BlockName == "ON")
                if ((Lexem == "WHERE") || (Lexem == "UNION") || (Lexem == "ON") || (Words[i, LexType] == "5"))
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    Words[Pos, Proc] = "ON 1";
                    return;
                }             
                
                //Поиск конца WHERE.
                if (BlockName == "WHERE")
                if ((Lexem == "GROUP BY") || (Lexem == "ORDER BY") || (Lexem == "UNION"))
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    Words[Pos, Proc] = "WHERE 1";
                    return;
                }        
                
                //Поиск конца GROUP BY.
                if (BlockName == "GROUP BY")
                if ((Lexem == "ORDER BY") || (Lexem == "UNION") || (Lexem == "HAVING"))
                    {
                        Words[Pos, BlockEnd] = (i - 1).ToString();
                        Words[Pos, Proc] = "GROUP 1";
                        return;
                    }
                
                //Поиск конца ORDER BY.
                if (BlockName == "ORDER BY")
                if (Lexem == "UNION")
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    Words[Pos, Proc] = "ORDER 1";
                    return;
                }                             
            } 
             
            int i1 = FindLastBaraceNum(BraceNumLocal);
            if (Words[i1, Lex] == ")") Words[Pos, BlockEnd] = (i1 - 1).ToString();
                else Words[Pos, BlockEnd] = i1.ToString();
            Words[Pos, Proc] = BlockName + " 10";              
        }            
*/
//======================================================================
/*
 //string[] columnNames = DGV.Columns.AsEnumerable().Select(col => col.ColumnName).ToArray();
            //return string.Join(";", columnNames);
            //string Result = "";
            //for (int i = 0; i < DGV.Columns.Count; i++) 
            //{
            //    string sym = ";";
            //    if (i == DGV.Columns.Count - 1) sym = "";
            //    Result = Result + i.ToString() + "." + DGV.Columns[i].HeaderText + sym;
            //} 
            //return Result;     
*/
//======================================================================
/*
  Работает!
   var TableRows2 =  
                DTUnion.AsEnumerable().Where(p => p["EnBrief2"].ToString()  == EntityBrief &&
                                            p["TableType"].ToString() == "1");
          
          if (TableRows2.Any()) return -1;
          DataRow rtu = TableRows2.First();
          
          
Работает!
 DataRow[] TableRows = DTUnion.Select("TableType = '1' and EnBrief2 = '" + EntityBrief + "'");//.Rows[0]["Pos"].ToString();
            if (TableRows.Any()) return -1;
            return TableRows[0].Field<int>("Pos");          
          
*/ 
//======================================================================
/*
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/