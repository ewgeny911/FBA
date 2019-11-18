
﻿/* 
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 25.08.2017
 * Время: 23:49
*/    
 
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Data;  
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Npgsql;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Collections;
//using Microsoft.Office.Interop.Excel; //Для экспорта в Excel
using System.Runtime.InteropServices; //Для экспорта в Excel
using System.Deployment.Application;
using System.Text.RegularExpressions;
//using FastColoredTextBoxNS;
//using Npgsql.BulkCopy;
//using Npgsql.BulkCopy.Native;
//using Npgsql.BulkCopy.Native.Versions;      
using System.Net;
using System.Net.Sockets;
using FastColoredTextBoxNS; 
using System.Diagnostics;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

//using SourceGrid;
  
namespace FBA
{		         
    	
	///Класс соединения с БД.
    public class Connection
    {           
        #region Объявления
        
        List<System.Data.DataTable> dtRtn = new List<System.Data.DataTable>();
        
        /// <summary>
        /// ИД соединения. Это GUID.
        /// </summary>
        public string ConnectionID   = "";
        
         /// <summary>
        /// Признак активного соединения.
        /// </summary>
        public bool   ConnectionActive = false; 
        
        /// <summary>
        /// Работа с запросами через сервер прилоежений (false) или прямое подключение (true).    
        /// </summary>
        public bool   ConnectionDirect = false; 

		/// <summary>
        /// Текущий GUID, выданый сервером проложений по которому определяется Connection к БД.
        /// Это основой GUID сессии приложения, возвращенный сервером приложений. В рамках сессии выполняются транзакции.
        /// Для того чтобы выполнить новую транзакцию, пока не закончилась предыдущая, нужно получить от сервера приложений 
        /// новый GUID соединения с БД (т.е. новый Connection).
        /// </summary>        
        public string ConnectionGUID = "";      
                                                
        
        /// <summary>
        /// Имя данного объекта Connection. Используется для того чтобы разделить команды к серверу приложений.
        /// </summary>                                       
        public string Name           = ""; 
        
        /// <summary>
        /// Имя соединения в локальной базе SQLite.        
        /// </summary>
        public string ConnectionName = ""; 
        
        /// <summary>
        /// Имя сервера СУБД.
        /// </summary>
        public string ServerName     = ""; 
               
        /// <summary>
        /// Допустимые значения: MSSQL, Postgre, SQLite, ServerApp.
        /// </summary>
        public ServerType serverType;     
        
        //
        
        /// <summary>
        /// Это тип удаленного подключения, если соединение через сервер приложений.
        /// Если подключение к БД локальное, то ConnectionDirect = true и тогда в serverType что-то 
        /// одно из MSSQL, Postgre, SQLite. 
        /// </summary>
        public ServerType serverTypeRemote = ServerType.NotAssigned;
                
        /// <summary>
        /// База СУБД на сервере.
        /// </summary>
        public string DatabaseName   = ""; 
        
        /// <summary>
        /// База СУБД - логин. 
        /// </summary>
        public string DatabaseLogin  = ""; 
        
        /// <summary>
        /// База СУБД - пароль.   
        /// </summary>
        public string DatabasePass   = ""; 

		/// <summary>
        /// Имя формы для запуска.   
        /// </summary>        
        public string UserForm       = ""; 
        
        /// <summary>
        /// Логин пользователя в таблице fbaUser.   
        /// </summary>
        public string UserLogin      = ""; 
        
        /// <summary>
        /// Пароль пользователя в таблице fbaUser.  
        /// </summary>
        public string UserPass       = "";     

		/// <summary>
        /// IP сервера приложений.
        /// </summary>        
        public string ServerAppIP    = ""; 
        
        /// <summary>
        /// Имя сервера прилоежний.
        /// </summary>
        public string ServerAppName  = ""; 
        
        /// <summary>
        /// На каком порту обмениваемся сообщениями с сервером приложений. По умолчанию 7145.
        /// </summary>
        public int    ServerAppPort  = 0;  
        
        /// <summary>
        /// Признак что авторизация через логин Windows.
        /// </summary>
        public string WindowsLogin   = ""; 
        
        private string DatabaseLoginDecrypt      = "";
        private string DatabasePassDecrypt       = "";

        private string ConnectStringMSSQL        = "";
        private string ConnectStringPostgre     = "";
        private string ConnectStringSQLite       = ""; 
            
        /// <summary>
        /// Дата и время последнего  запроса.
        /// </summary>
        public DateTime LastQueryDateTime = DateTime.Now;
                              
        /// <summary>
        /// Конструктор без инициализацией подключения.
        /// </summary>
        public Connection()
        {
            //
        }
        
        ///Конструктор с инициализацией подключения.
        public Connection(ServerType serverType, string ServerName, string DatabaseLogin, string DatabasePass, string DatabaseName)
        {
            ConnectionInit(serverType, ServerName, DatabaseLogin, DatabasePass, DatabaseName);
        }

        #endregion

        #region Инициализация: InitConnection, CloseConnection               
               
        /// <summary>
        /// Установка соединения с SQLite;
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public bool ConnectionSetLocal()
        {              		      
            FBAFile.GetPathSQLite(out ServerName);
            //return ConnectionInit(ServerType.SQLite, ServerName, "", "", "");    
            serverType    = ServerType.SQLite;  
			ConnectionID = "0";            
            DatabaseLogin = "";
            DatabasePass  = "";
            DatabaseName  = "";  
            return ConnectionInitDataBase();
            //if  (Var.con != null) serverType = Var.con.serverTypeRemote;
        	//  else serverType = ServerType.Postgre;             
        }

		/// <summary>
		/// Соединение с БД
		/// </summary>
		/// <param name="serverType">ServerType: MSQL, Postrgre, SQLite</param>
		/// <param name="serverName">Имя сервера и порт, пример http://MyServer:9590</param>
		/// <param name="databaseLogin">Логин к БД</param>
		/// <param name="databasePass">Пароль к БД</param>
		/// <param name="databaseName">Имя БД</param>
		/// <returns>Если успешно, то true</returns>
        public bool ConnectionInit(ServerType serverType, string serverName, string databaseLogin, string databasePass, string databaseName)
        {
            if ((serverName == "") || (serverName == ".")) serverName = "localhost";
            
            //Разделяем имя сервера на имя и порт, если порт указан в имени серера через двоеточие. Пример: http://MyServer:9590
            //Если порта нет, то использует порт  по умолчанию 7100.
            //if ((serverType == ServerType.MSSQL) || (serverType == ServerType.Postgre)) 
            sys.GetServerAppPort(serverName, out ServerAppName, out ServerAppPort);
            
            if (((serverName == "localhost") || (serverName == "")) && (serverType == ServerType.SQLite)) 
            	FBAFile.GetPathSQLite(out serverName);
            
            this.serverType    = serverType;            
            this.ServerName    = serverName;
            this.DatabaseLogin = databaseLogin;
            this.DatabasePass  = databasePass;
            this.DatabaseName  = databaseName;            
            if (serverType == ServerType.ServerApp) 
            {            	
            	return ConnectionInitApp();
            }
            if ((serverType == ServerType.MSSQL) || (serverType == ServerType.Postgre) || (serverType == ServerType.SQLite)) return ConnectionInitDataBase();
            return false;
        }                      
       
        /// <summary>
        /// Функция инициализации подключения к базе данных.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private bool ConnectionInitDataBase()  
        {                       	                                                              
            //Далее только если подключение не через сервер приложений:
            this.DatabaseLoginDecrypt = Crypto.DecryptAES(DatabaseLogin);
            this.DatabasePassDecrypt  = Crypto.DecryptAES(DatabasePass);
                
        	try
            {
                if (serverType == ServerType.Postgre)
                {
                    ConnectStringPostgre = "Server=" + ServerName + ";User Id=" + DatabaseLoginDecrypt + ";Password=" + DatabasePassDecrypt + ";Database=" + DatabaseName + ";";            
                	Npgsql.NpgsqlConnection connection1 = null;
                    connection1 = new Npgsql.NpgsqlConnection(ConnectStringPostgre);
                    connection1.Open();
                }
            
                if (serverType == ServerType.MSSQL)
                {
                    if (DatabaseLogin == "") ConnectStringMSSQL = @"Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True";
                	  else ConnectStringMSSQL = "Server=" + ServerName + ";User Id=" + DatabaseLoginDecrypt + ";Password=" + DatabasePassDecrypt + ";Database=" + DatabaseName + ";"; //Connection Timeout=2;                                            
                System.Data.SqlClient.SqlConnection connection2;
                    connection2 = new System.Data.SqlClient.SqlConnection(ConnectStringMSSQL);
                    connection2.Open();
                }

                if (serverType == ServerType.SQLite)
                {                                                                                                                       	            
                	if ((sys.ErrorCheck(!File.Exists(ServerName), "Не найден файл базы данных."))) return false;                	                	
                    ConnectStringSQLite = @"Data Source=" + ServerName + @";New=False;Version=3;";
                    System.Data.SQLite.SQLiteConnection connection;
                    connection = new System.Data.SQLite.SQLiteConnection(ConnectStringSQLite);
                    connection.Open();
                    //connection3.BindFunction(CloseToSQLiteFunction.GetAttribute(), new CloseToSQLiteFunction());                              
                }
                serverTypeRemote = serverType;                                                                          
                ConnectionActive = true;
                ConnectionDirect = true;                 
                return true;
            }
            catch (Exception e)
            {  
            	sys.SM("Ошибка подключения: " + e.Message + " к серверу " + serverType.ToString());
            	ConnectionActive = false;
            	ConnectionDirect = false; 
                return false;
            }
        }		                                                                              
       
        /// <summary>
        /// Функция инициализации подключения к серверу приложений.
        /// Метод объявлен private чтобы не было возможности вызвать его из прикладного кода.
        /// Есть аналогичная процедура получения параметров подключения из БД SQLite.          
        /// Метод возвращает все настройки соединения по имени соединения.  
        /// Пример того что отсылаем:                   
        /// LocalIP=10.77.70.39;LocalHost=COM1389;ComputerName=ANDREY;ComputerUserName=ANDREY;          
        /// </summary>	
        /// <returns>Если успешно, то true</returns>
        private bool ConnectionInitApp()
        {                                                                                                                                                                                                
            try
            {                 
                string commandStr = "LocalIP=" + Var.LocalIP + ";LocalPort=" + Var.LocalServerPort + ";LocalHost=" + Var.LocalHost + ";ComputerName=" + Var.ComputerName + ";ComputerUserName=" + Var.ComputerUserName + ";";                
                string requestStr = sys.ServerAppSendHTTPMessage("Client", ServerAppName, ServerAppPort, CommandCode.C102, "", commandStr, "", 0);
                if (requestStr    == "") return false;              
                
            	string direct;
            	string serverTypeLocal = "";
            	ParseResponse(requestStr,
                              out ConnectionGUID,
                              out direct,
                              out ConnectionName,
                              out ServerName,
                              out serverTypeLocal,
                              out DatabaseName,
                              out DatabaseLogin,
                              out DatabasePass,   
                              out UserForm,
                              out UserLogin,
                              out UserPass);
                //sys.SM("GetParamConnectionApp.RequestStr: " + RequestStr);     	                	              
                if (direct        != "") ConnectionDirect = Convert.ToBoolean(direct);          
                if (serverTypeLocal == "MSSQL")   serverTypeRemote = ServerType.MSSQL;
                if (serverTypeLocal == "Postgre") serverTypeRemote = ServerType.Postgre;
                if (serverTypeLocal == "SQLite")  serverTypeRemote = ServerType.SQLite;
                if (!ConnectionDirect) 
                {
                	//Все запросы через сервер приложений.
                	serverType = ServerType.ServerApp;                	
                	ConnectionActive = true;
                	return true;
                }
              
               	//Подключение напрямую к БД. Сервер приложений далее не участвует в подключении. 
            	serverType = serverTypeRemote;
            	if (!ConnectionInitDataBase())  return false;
	                 
	            //Сервер приложений вернул настройки подключения напрямую к БД, и мы подключились нормально.	         	            
	            return true;                                        
            }
            catch (Exception ex)
            { 
                sys.SM("Ошибка обращения к серверу приложений " + ServerAppName + ":" + ServerAppPort.ToString() + ": " + ex.Message);
                /*ConnectionGUID            = "";
                ConnectionName  = "";
                ServerName      = "";
                ServerType      = "";
                DatabaseName    = "";
                DatabaseLogin   = "";
                DatabasePass    = "";
                UserForm        = "";
                UserLogin       = "";
                UserPass        = ""; */
                return false;
            }                                                                                        
        }
      
        /// <summary>
        /// Получить параметры, переданные клиентом в запросе серверу.
        /// </summary>
        /// <param name="requestStr"></param>
        /// <param name="guid"></param>
        /// <param name="connectionDirect"></param>
        /// <param name="connectionName"></param>
        /// <param name="serverName"></param>
        /// <param name="serverTypeL"></param>
        /// <param name="databaseName"></param>
        /// <param name="databaseLogin"></param>
        /// <param name="databasePass"></param>
        /// <param name="userForm"></param>
        /// <param name="userLogin"></param>
        /// <param name="userPass"></param>
        private void ParseResponse(string requestStr, 
                                            out string guid,
                                            out string connectionDirect,    
                                            out string connectionName,
                                            out string serverName,
                                            out string serverTypeL,
                                            out string databaseName,
                                            out string databaseLogin,
                                            out string databasePass,   
                                            out string userForm,
                                            out string userLogin,
                                            out string userPass)                       
        {                                                                      
            guid             = sys.StrBetweenStr(requestStr, "GUID=",           ";");
            connectionDirect = sys.StrBetweenStr(requestStr, "ConnectionDirect=", ";");
            connectionName   = sys.StrBetweenStr(requestStr, "ConnectionName=", ";");
            serverName       = sys.StrBetweenStr(requestStr, "ServerName=",     ";");
            serverTypeL      = sys.StrBetweenStr(requestStr, "ServerType=",     ";");            
            databaseName     = sys.StrBetweenStr(requestStr, "DatabaseName=",   ";");
            databaseLogin    = sys.StrBetweenStr(requestStr, "DatabaseLogin=",  ";");
            databasePass     = sys.StrBetweenStr(requestStr, "DatabasePass=",   ";");
            userForm         = sys.StrBetweenStr(requestStr, "UserForm=",       ";");
            userLogin        = sys.StrBetweenStr(requestStr, "UserLogin=",      ";");
            userPass         = sys.StrBetweenStr(requestStr, "UserPass=",       ";");
        }
                                 
		/// <summary>
		/// Метод возвращает все настройки соединения по имени соединения из табицы ConnectionList.	
		/// </summary>
		/// <param name="connectionName"></param>
		/// <param name="connectionID"></param>
		/// <param name="serverType"></param>
		/// <param name="serverName"></param>
		/// <param name="databaseName"></param>
		/// <param name="databaseLogin"></param>
		/// <param name="databasePass"></param>
		/// <param name="userForm"></param>
		/// <param name="userLogin"></param>
		/// <param name="userPass"></param>
		/// <param name="windowsLogin"></param>
		/// <returns></returns>
		public bool ConnectionGetParamName(                                     
                                     string connectionName, 
                                     out string connectionID,
                                     out string serverType, 
                                     out string serverName,                                     
    								 out string databaseName,
    								 out string databaseLogin,
    								 out string databasePass,
    								 out string userForm,
    		                         out string userLogin,
    		                         out string userPass,
    		                         out string windowsLogin
    		                         )
		{				        	           		      
		    connectionID  = "";
		    serverType    = ""; 
            serverName    = "";           
    		databaseName  = "";
    		databaseLogin = "";
    		databasePass  = "";
    		userForm      = "";
    		userLogin     = "";
    		userPass      = "";
    		windowsLogin  = "";
    		if (sys.ErrorCheck(connectionName == "", "Cоединение не выбрано!")) return false;         
            string sql = "SELECT ID, ServerType, ServerName, DatabaseName, DatabaseLogin, DatabasePass, UserForm, UserLogin, UserPass, WindowsLogin FROM fbaConList WHERE ConnectionName = '" + connectionName + "' "; 
            GetValue10(sql, out connectionID,  out serverType, out serverName, out databaseName, out databaseLogin, out databasePass, out userForm, out userLogin, out userPass, out windowsLogin);                                                                  
            return true;
        }   
				
		/// <summary>
        /// Функция закрытия соединения с БД.   
        /// </summary>	
        /// <returns>Если успешно, то true</returns>
        public bool ConnectionClose()
        {
            try
            {               
                if ((serverType == ServerType.Postgre))
                {          
                    Npgsql.NpgsqlConnection.ClearAllPools();
                    ConnectionActive = false;
                    return true;
                }
                if ((serverType == ServerType.MSSQL))
                {         
                    System.Data.SqlClient.SqlConnection.ClearAllPools();
                    ConnectionActive = false;
                    return true;
                }
                if ((serverType == ServerType.SQLite))
                {             
                    System.Data.SQLite.SQLiteConnection.ClearAllPools();
                    ConnectionActive = false;
                    return true;
                }
                ConnectionActive = false;
                return true;
            }
            catch (Exception e)
            {
            	sys.SM("Ошибка закрытия соединения с БД: " + e.Message);
                return false;
            }
        }     
		       
        #endregion
       
        #region Получение данных: GetValue, InsertDT, SelectDT, GetRefCursorData, SaveFileToDataBase, ReadFileFromDataBase                                        
        
        /// <summary>
        /// Получение одного значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <returns>Одно значение полученных запросом. Запрос должен возвращать одну строку</returns>
        public string GetValue(string sql)
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
        	bool Result = GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
        	if (Result) return s1;
        	return "";
        }
        
        /// <summary>
        /// Получение 2-х значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>2 значения полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue2(string sql, out string s1, out string s2)
        {
        	string s3;
        	string s4;
        	string s5;
        	string s6;
        	string s7;
        	string s8;
        	string s9;
        	string s10;
        	return GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
        }
        
        /// <summary>
        /// Получение 3-х значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns>3 значения полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue3(string sql, out string s1, out string s2, out string s3)
        {
        	string s4;
        	string s5;
        	string s6;
        	string s7;
        	string s8;
        	string s9;
        	string s10;
        	return GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
        }        
        
        /// <summary>
        /// Получение 4-ми значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        /// <returns>4 значений полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue4(string sql, out string s1, out string s2, out string s3, out string s4)
        {
        	string s5;
        	string s6;
        	string s7;
        	string s8;
        	string s9;
        	string s10;
        	return GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
        } 
        
        /// <summary>
        /// Получение 5-ми значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        /// <param name="s5"></param>
        /// <returns>5 значений полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue5(string sql, out string s1, out string s2, out string s3, out string s4, out string s5)
        {
        	string s6;
        	string s7;
        	string s8;
        	string s9;
        	string s10;
        	return GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
       } 
        
        /// <summary>
        /// Получение 6-ми значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        /// <param name="s5"></param>
        /// <param name="s6"></param>
        /// <returns>6 значений полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue6(string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6)
        {
        	string s7;
        	string s8;
        	string s9;
        	string s10;
        	return GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
        }
        
        /// <summary>
        /// Получение 7-ми значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        /// <param name="s5"></param>
        /// <param name="s6"></param>
        /// <param name="s7"></param>
        /// <returns>7 значений полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue7(string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7)
        {
        	string s8;
        	string s9;
        	string s10;
        	return GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
        }  
        
        /// <summary>
        /// Получение 8-ми значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        /// <param name="s5"></param>
        /// <param name="s6"></param>
        /// <param name="s7"></param>
        /// <param name="s8"></param>   
        /// <returns>8 значений полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue8(string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7, out string s8)
        {
        	string s9;
        	string s10;
        	return GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
        }        
                    
        /// <summary>
        /// Получение 9-х значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        /// <param name="s5"></param>
        /// <param name="s6"></param>
        /// <param name="s7"></param>
        /// <param name="s8"></param>
        /// <param name="s9"></param>      
        /// <returns>9 значений полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue9(string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7, out string s8, out string s9)
        {
        	string s10;
        	return GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10);
        }
        
        /// <summary>
        /// Получение 10-ти значений.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        /// <param name="s5"></param>
        /// <param name="s6"></param>
        /// <param name="s7"></param>
        /// <param name="s8"></param>
        /// <param name="s9"></param>
        /// <param name="s10"></param>
        /// <returns>10 значений полученных запросом. Запрос должен возвращать одну строку</returns>
        public bool GetValue10(string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7, out string s8, out string s9, out string s10)
        {                    
            s1  = "";
            s2  = "";
            s3  = "";
            s4  = "";
            s5  = "";
            s6  = "";
            s7  = "";
            s8  = "";
            s9  = "";
            s10 = "";
            if ((sql == "") || (sql == "Empty")) return false;
            
            var dt = new System.Data.DataTable();
            SelectDT(sql, out dt);
            
            try
            {                                                                                                
                //LastQueryDateTime = DateTime.Now; 
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns.Count > 0) s1  = dt.Rows[0][0].ToString();
                    if (dt.Columns.Count > 1) s2  = dt.Rows[0][1].ToString();
                    if (dt.Columns.Count > 2) s3  = dt.Rows[0][2].ToString();
                    if (dt.Columns.Count > 3) s4  = dt.Rows[0][3].ToString();
                    if (dt.Columns.Count > 4) s5  = dt.Rows[0][4].ToString();
                    if (dt.Columns.Count > 5) s6  = dt.Rows[0][5].ToString();
                    if (dt.Columns.Count > 6) s7  = dt.Rows[0][6].ToString();
                    if (dt.Columns.Count > 7) s8  = dt.Rows[0][7].ToString();
                    if (dt.Columns.Count > 8) s9  = dt.Rows[0][8].ToString();
                    if (dt.Columns.Count > 9) s10 = dt.Rows[0][9].ToString();
                    return true;  
                }
                return false;                            
            }
            catch (Exception e)
            {               
                string errorMes = "702. Ошибка выполнения запроса: " + Var.CR + e.Message + Var.CR + sql; 
                //if (ErrorShow) 
                sys.SM(errorMes);
                dt = null;
                return false;               
            }
        }
         
        /// <summary>
        /// Получение больше 10-ти значений. В массиве строк.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="arr">Возвращает список значений в виде массива</param>
        /// <returns></returns>
        public bool GetValueArr(string sql, ref string[] arr)
        {  
            if ((sql == "") || (sql == "Empty")) return false;
            var dt = new System.Data.DataTable();
            SelectDT(sql, out dt);
            try
            {             
                if (dt.Rows.Count == 0) return false;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i < arr.Length) arr[i] = dt.Rows[0][i].ToString();
                }    
                return true;                             
            }
            catch (Exception e)
            {
                string errorMes = "7031. Ошибка выполнения запроса: " + Var.CR + e.Message + Var.CR + sql;               
                sys.SM(errorMes);
                dt = null;
                return false;
            }
        }    
        
        /// <summary>
        /// Функции получения данных для MSSQL, Postgre, SQLite. Результат в DataGridView.  
        /// </summary>
        /// <param name="sql">Запрос любой, select, update, delete, ddl</param>
        /// <param name="grid">DataGridView</param>
        /// <returns></returns>
        public bool SelectGV(string sql, DataGridView grid)
        {                    
            System.Data.DataTable dt;                    
            if (!SelectDT(sql, out dt)) return false;
            grid.DataSource = dt;                          
            return true;           
        }                             

		/// <summary>
		/// Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataTable. Возвращает только одну таблицу. 	
		/// </summary>
		/// <param name="sql">Запрос любой, select, update, delete, ddl</param>
		/// <param name="dt"></param>
		/// <returns>Если успешно, то true</returns>
        public bool SelectDT(string sql, out System.Data.DataTable dt)
        {
            string errorMes = "";
            const bool errorShow = true;
            System.Data.DataSet ds;
            bool result;
            result = SelectDS(sql, out ds, out errorMes, errorShow);  
            if ((ds != null) && (ds.Tables.Count > 0))
            {              
                dt = ds.Tables[0];                              
            } else  dt = null;                              
            return result;           
        }   
    
        /// <summary>
        /// Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataSet. Возвращает несколько таблиц. 
        /// </summary>
        /// <param name="sql">Запрос любой, select, update, delete, ddl</param>
        /// <param name="ds">DataSet - набор таблиц</param>
        /// <returns>Если успешно, то true</returns>
        public bool SelectDS(string sql, out DataSet ds)
        {
            string errorMes = "";
            const bool errorShow = true;
            return SelectDS(sql, out ds, out errorMes, errorShow);
        }

		/// <summary>
		/// Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataSet. Возвращает несколько таблиц. 
		/// </summary>
		/// <param name="sql">Запрос любой, select, update, delete, ddl</param>
        /// <param name="ds">DataSet - набор таблиц</param>
		/// <param name="errorMes">Сообщение об ошибке</param>
		/// <param name="errorShow">Показывать или нет ошибки</param>
		 /// <returns>Если успешно, то true</returns>
        public bool SelectDS(string sql, out DataSet ds, out string errorMes, bool errorShow)
        {           
            ds = new DataSet("DS");
            errorMes = "";
            if ((sys.IsEmpty(sql)) || (sql == "Empty")) return false;           
            try
            {
                if (ConnectionDirect)
                {
                    if (serverType == ServerType.Postgre)
                    {
                        Npgsql.NpgsqlConnection connection = null; //Postgres
                        connection = new Npgsql.NpgsqlConnection(ConnectStringSQLite);
                        connection.Open();
                        var da = new NpgsqlDataAdapter(sql, connection);
                        da.Fill(ds);
                        connection.Close();
                    }

                    if (serverType ==  ServerType.MSSQL)
                    {
                        var connection = new System.Data.SqlClient.SqlConnection(ConnectStringMSSQL);
                        connection.Open();
                        var da = new SqlDataAdapter(sql, connection);
                        da.Fill(ds);
                        connection.Close();
                    }
                }
               
                if (serverType ==  ServerType.SQLite)
                {                                      
                    var connection = new System.Data.SQLite.SQLiteConnection(ConnectStringSQLite);
                    connection.Open();
                    var da = new SQLiteDataAdapter(sql, connection);
                    da.Fill(ds);
                    connection.Close();
                    //connection.BindFunction(CloseToSQLiteFunction.GetAttribute(), new CloseToSQLiteFunction());                              
                }

                if (!ConnectionDirect)
                {
                    if (!AppSelectDS(sql, out ds)) return false;
                }

                LastQueryDateTime = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {               
                errorMes = "703. Ошибка выполнения запроса: " + errorMes + Var.CR + e.Message + Var.CR + sql; 
                if (errorShow) sys.SM(errorMes);                      
                ds = null;
                return false;               
            }
        }                                                        
                
        /// <summary>
        /// Получить код для получения ID вставленной/изменённой записи.
        /// Postgre: "; RETURNING id; ";                     
        /// MSSQL:   "; SELECT @@IDENTITY AS id; ";                                          
        /// SQLite:  "; SELECT last_insert_rowid() AS id; "; 
        /// </summary>
        /// <returns>Одно из трёх текстовых значений</returns>
        public string GetInsertID()
        {   
            if (serverTypeRemote ==  ServerType.Postgre) return "; RETURNING id; ";                     
            if (serverTypeRemote ==  ServerType.MSSQL)   return "; SELECT @@IDENTITY AS id; ";                                          
            if (serverTypeRemote ==  ServerType.SQLite)  return "; SELECT last_insert_rowid() AS id; "; 
            return "";
        }
      
        /// <summary>
        /// Выполнить запрос SQL.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <returns>Если успешно, то true</returns>
        public bool Exec(string sql)
        {
            string ID;
            return Exec(sql, false, out ID);
        }                             
        
        /// <summary>
        /// Выполнить запрос SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="addInsertID">Если true, то добавляется код для получения ИД последней изменённой записи
        /// Postgre: "; RETURNING id; ";                     
        /// MSSQL:   "; SELECT @@IDENTITY AS id; ";                                          
        /// SQLite:  "; SELECT last_insert_rowid() AS id; "; 
        /// </param>
        /// <param name="id">ИД последней изменённой записи</param>
        /// <returns>Если успешно, то true</returns>
        public bool Exec(string sql, bool addInsertID, out string id)
        {   
            id = "";
            if (addInsertID) sql += GetInsertID();
            System.Data.DataTable dt;
            if (!SelectDT(sql, out dt)) return false;
            if (dt != null) id = dt.Value("id");
            return true;
        }                     
                         
        #endregion	           
               
        #region Работа с сервером приложений.
             
        /// <summary>
        /// Послать SQL запрос SELECT на сервер приложений.
        /// </summary>
        /// <param name="sql">Запрос любой, select, update, delete, ddl</param>
        /// <param name="ds">DataSet</param>
        /// <returns>Если успешно, то true</returns>
        private bool AppSelectDS(string sql, out System.Data.DataSet ds)
        {   
            return AppQuery(TypeQuery.SELECT, 1, sql, out ds);
        }
               
        /// <summary>
        /// Послать SQL запрос SELECT на сервер приложений. Получить таблицу DataTable.
        /// </summary>
        /// <param name="sql">Запрос любой, select, update, delete, ddl</param>
        /// <param name="dt">System.Data.DataTable</param>
        /// <returns>Если успешно, то true</returns>                             
        private bool AppSelectDT(string sql, out System.Data.DataTable dt)
        {   
            System.Data.DataSet ds;           
            bool ResultQuery = AppQuery(TypeQuery.SELECT, 1, sql, out ds);
            if (ds.Tables.Count == 0) 
            {
                dt = null;
                return ResultQuery;
            }
            dt = ds.Tables[0];
            return ResultQuery;
        }
                 
        /// <summary>
        /// Послать запрос SQL на сервер приложений.
        /// </summary>
        /// <param name="typeQuery">TypeQuery: Select или Exec</param>
        /// <param name="numQuery">Счётчик запросов. Если подключения нет, то устанавливаем автоматически. 
        /// Этот счётчик, чтобы не зациклиться, если соединение не удалось. Так как процедура вызывается рекурсивно.</param>
        /// <param name="sql">Запрос любой, select, update, delete, ddl</param>
        /// <param name="ds">System.Data.DataSet</param>
        /// <returns>Если успешно, то true</returns>         
        private bool AppQuery(TypeQuery typeQuery, int numQuery, string sql, out System.Data.DataSet ds)
        {               
            ds = null;         
            if ((ConnectionGUID == "") || (ServerAppName == ""))
            {    
                sys.SM("Ошибка. соединение с сервером приложений не установлено!");
                return false;
            }  
            
            CommandCode commandCode = CommandCode.C103;
            if (typeQuery == TypeQuery.EXEC) commandCode = CommandCode.C104; 
                        
            string requestStr = sys.ServerAppSendHTTPMessage("Client", ServerAppName, ServerAppPort, commandCode, ConnectionGUID, sql, "", 0);
            if (requestStr == "") return true;
            if (requestStr.Left(3) == ErrorCode.S501.ToString()) //"501. Ошибка. Сессия с сервером не найдена!")
            {
                if (numQuery < 2) //Переподключаемся только 1 раз, чтобы не зацикливаться.
                {                       
                    if (!(sys.Enter(this.ConnectionName, Var.enterMode, Var.UserLogin, Var.UserPass)))
                    {
                        sys.SM(requestStr + Var.CR + "Ошибка повторного входа в систему!");
                        return false;
                    }
                    numQuery = numQuery + 1;
                    //this.ConnectionGUID = NextConnectionGUID;
                    //Здесь важно именно писать Var.con.AppQuery, а не просто AppQuery, 
                    //для того, чтобы AppQuery выполнился в другом созданном con, 
                    //для того чтобы использовался ConnectionGUID уже другого con.
                    //то что SystemEnter возвращает ConnectionGUID ничего не меняет.
                    //Можно убрать возврат ConnectionGUID из SystemEnter - это ничего не изменит.
                    Var.con.AppQuery(typeQuery, numQuery, sql, out ds);
                    return true;
                }               
                sys.SM(requestStr + Var.CR + "Ошибка подключения к серверу приложений!");
                return false;               
            }
            
            if (requestStr.Substring(0,1) == "5")
            {
                //Все ошибки начинаются на 5:
                sys.SM(requestStr);
                return false;
            }
            ds = sys.StrToDataSet(requestStr); 
            //LastQueryDateTime = DateTime.Now;            
            return true;       
        }
                
        #endregion       
         
        #region Методы проверки и получения различных данных из БД.                             
                                             
		/// <summary>
		/// Возвращает количество записей, которые получаются после выполнения запроса SQL. 
		/// </summary>
		/// <param name="sql">Запрос любой, select, update, delete, ddl</param>
		/// <returns>Если успешно, то true</returns>   
        public int SelectCount(string sql)
        {                                 
           System.Data.DataTable dt;           
           if (!SelectDT(sql, out dt)) return -1;
           return dt.Rows.Count;          
        }               
        
        /// <summary>
        /// Функции получения данных для MSSQL, Postgre, SQLite. Результат в ComboBox. 
        /// </summary>
        /// <param name="sql">Запрос любой, select, update, delete, ddl</param>
        /// <param name="cb">ComboBox</param>
        /// <returns>Если успешно, то true</returns>   
        public bool SelectCB(string sql, ComboBox cb)
        {
            System.Data.DataTable dt;
            bool flag = SelectDT(sql, out dt);
            cb.DataSource = dt;
            return flag;
        }         
     
        /// <summary>
        /// Текущая дата на сервере.
        /// Postgre = SELECT current_timestamp AS CurrentDateTime   	
        /// MSSQL   = SELECT datetime('now', 'localtime') AS CurrentDateTime       
        /// SQLite  = SELECT GetDate() AS CurrentDateTime
        /// </summary>
        /// <returns>Дата на сервере</returns>
        public string GetServerDate()
        {      
            string sql = sys.SelectCurrentDateTime(serverType);
            return GetValue(sql);
        }
        
        #endregion
        
        #region Region. Экспорт и импорт строки DataTable в файл/из файла. 
                          
        /// <summary>
        /// Копирование таблицы DataTable на сервер MSSQL. Для SQLite и Postrgres нужно действовать через создание INSERT.
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="tableName">В какую таблицу на сервере копируем</param>
        /// <returns>Если успешно, то true</returns>   
        public bool MSSQLCopyTableToServer(System.Data.DataTable dt, string tableName)
        {                           
            if (serverType != ServerType.MSSQL) return false;
            try
            {
                string sql = sys.GetTextCreateTable(serverType, tableName, dt);
                Exec(sql);
                var connection = new System.Data.SqlClient.SqlConnection(ConnectStringMSSQL);
                connection.Open();
                var copy = new SqlBulkCopy(connection);
                copy.DestinationTableName = tableName;            
                copy.WriteToServer(dt); 
                return true;
            } catch (Exception ex)
            {                               
                sys.SM(ex.Message);                     
                return false;   
            }                       
        }  
             
        #endregion Region. Экспорт и импорт строки DataTable в файл/из файла.                  
    }
}
//public override int System.Data.Common.DbDataAdapter.Fill(DataSet dataSet);