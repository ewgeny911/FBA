/*
 * Created by SharpDevelop.
 * User: Evgeniy.Travin
 * Date: 18.11.2019
 * Time: 14:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Net;
using System.Diagnostics;

namespace FBA
{
	/// <summary>
	/// Description of SysEnter.
	/// </summary>
	public partial class sys
	{		 
        #region Region. Вход в систему.
  
		/// <summary>
		/// Установка соединения с локальной SQLite.	 
		/// </summary>
        public static void ConnectLocal()
        {
            if (Var.IsDesignMode) return;
            if (Var.conLite != null) return;
            //SQLiteFunction.RegisterFunction(typeof(SQLiteCaseInsensitiveCollation));                                       
            Var.conLite = new Connection();
            if (!Var.conLite.ConnectionSetLocal()) Environment.Exit(0);       
            Var.ServerAppPortDefault = GetServerAppPortDefault();
        }  
        
         /// <summary>
        /// Установка соединения с удаленной БД.
        /// </summary>
        public static void ConnectRemote()
        {
            if (Var.IsDesignMode) return;
            //Форма входа
            if (Var.con != null) return;
            var formEnter1 = new FormEnter();
            formEnter1.ShowDialog();
            formEnter1.Dispose();
        }  
        
        /// <summary>
        /// Получить порт сервера приложений из настроек.
        /// </summary>
        /// <returns>Порт сервера приложений</returns>
        public static int GetServerAppPortDefault()
        {          
            string serverAppPort = Param.GetSysParam("ServerAppPortDefault");
            if (serverAppPort == "")
            {
                sys.SM("Ошибка получения порта сервера приложений из локальной таблицы fbaSysParam (параметр ServerAppPortDefault)! ");
                return 0;
            }
            return serverAppPort.ToInt();
        }
                         
        /// <summary>
        /// Подключение без поднятия формы входа.
        /// </summary>
        /// <param name="connectionName">Имя соединения</param>
        /// <param name="enterMode">Тип входа в систему EnterMode</param>
        /// <param name="loginIN">Логин пользователя прикладной</param>
        /// <param name="passIN">Пароль пользователя прикладной</param>
        /// <returns>Если успешно, то true</returns>
        public static bool ConnectRemoteSilent(string connectionName, EnterMode enterMode, string loginIN = "", string passIN = "")
        {
            if (Var.con != null) return true;
            Var.enterMode = enterMode;
            if (!sys.Enter(connectionName, enterMode, loginIN, passIN))
            {
                return false;
            }
            return true;
        }
             
        /// <summary>
        /// Установка соединения. Параметры подключения в командной строке.
        /// Пример: ConnectionID=21;EnterMode=Work;
        /// </summary>
        public static void ConnectParam()
        {
            string paramStr = "";

            if (Var.Args.Length > 1) paramStr += Var.Args[1] + " ";
            if (Var.Args.Length > 2) paramStr += Var.Args[2] + " ";
            if (Var.Args.Length > 3) paramStr += Var.Args[3] + " ";

            string connectionID = sys.StrBetweenStr(paramStr, "ConnectionID=", ";");
            
            string enterModestr = sys.StrBetweenStr(paramStr, "EnterMode=", ";");
            if (enterModestr == "Work")     Var.enterMode = EnterMode.Work;
            if (enterModestr == "Test")     Var.enterMode = EnterMode.Test;
            if (enterModestr == "Develop")  Var.enterMode = EnterMode.Develop;
            
            if (connectionID == "")
            {
                sys.SM("В строке параметров не указано ID соединения с БД!" + Var.CR +
                       "Пример строки параметров: ConnectionID=21;EnterMode=Work;");
                Environment.Exit(0);
            }

            string connectionName = Var.conLite.GetValue("SELECT ConnectionName FROM fbaConList WHERE ID = " + connectionID);
            if (connectionName == "")
            {
                sys.SM("Неверно указано ID подключения!");
                Environment.Exit(0);
            }

            /*string Mes1 = 
                "Program1 Var.connectionID="    + Var.connectionID         + Var.CR +
                "Program1 sys.UserForm="        + sys.UserForm             + Var.CR + 
                "Program1 Var.enterMode="       + Var.enterMode.ToString() + Var.CR;
            sys.SM(Mes1);*/

            if (!(sys.Enter(connectionName, Var.enterMode, "", ""))) Environment.Exit(0); ;
        }
                   
        /// <summary>
        /// Получить зашифрованный пароль пользователя.
        /// </summary>
        /// <param name="userLoginIN">Логин пользователя</param>
        /// <param name="userPassIN">Пароль пользователя</param>
        /// <returns>Зашифрованный пароль пользователя</returns>
        public static string GetUserPassCrypt(string userLoginIN, string userPassIN)
        {
            //return (UserLoginIN + "L" + UserPassIN.Reverse()).MD5();
            return userPassIN;
        }
    
        /// <summary>
        /// Сменить пароль пользвоателя.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public static bool ChangeUserPass()
        {
            string valueText1 = "";
            string valueText2 = "";
            if (!sys.InputValue2("Change user password",
                                 "Old password",
                                 "New password",
                                 ref valueText1,
                                 ref valueText2)) return false;
            if (Var.UserPass != valueText1)
            {
                sys.SM("Не совпадает введеный старый пароль!");
                return false;
            }
            string userPassNew = sys.GetUserPassCrypt(Var.UserLogin, valueText2);
            string sql = string.Format("UPDATE fbaUser SET UserPass = '{0}' WHERE ID = {1};", userPassNew, Var.UserID ) + Var.CR +
                         string.Format("UPDATE fbaConList SET UserPass = '{0}' WHERE ID = {1};" + Var.CR, userPassNew, Var.con.ConnectionID);

            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            Var.UserPass = userPassNew;
            sys.SM("Пароль изменён!", MessageType.Information);
            return true;
        }       
        
        /// <summary>
        /// Получить IP локальный IP адрес при AddressList[0]. 
        /// Может быть такой адрес IPv6 fe80::d82a:ce0f:4d01:7cb1%11
        /// Ищем IPv4.        
        /// </summary>
        /// <param name="hostName">Это параметр System.Net.Dns.GetHostName()</param>
        /// <returns>Получаем IPv4. IPv6 игноритуем</returns>
        public static string GetLocalIPv4(string hostName)
        {        	
        	int i = 0;
        	IPAddress[] iplist = System.Net.Dns.GetHostEntry(hostName).AddressList;
        	Var.LocalIP = iplist[0].ToString();
        	while ((Var.LocalIP.IndexOf(':') > -1) && (iplist.Count() > i))
        	{
        		i++;
        		Var.LocalIP = iplist[i].ToString();        		
        	}
        	if (Var.LocalIP.IndexOf(':') == -1) return Var.LocalIP;
        	return iplist[0].ToString();
        }             
       
             
        ///Вход в систему. Основной метод входа в систему. Для всех приложений ServerApp, ClientApp.
        public static bool Enter(string connectionName,
                                 EnterMode enterModeIN,
                                 string userLoginIN,
                                 string userPassIN)
        {                     
            
        	//Проверка наличия всех папок системы.
        	FBAPath.CheckPath();
        	
        	if (connectionName == "")
            {
                SM("Не задано имя подключения!");
                return false;
            }

            //Имя последнего подключения. Сохраняется на локальной БД, если это не проверка соединения. 
            sys.AddEnterLast(connectionName, Var.SystemName, enterModeIN);

            string connectionID;
            string conServerType;
            string conServerName;
            string conDatabaseName;
            string conDatabaseLogin;
            string conDatabasePass;
            string conUserForm;
            string conUserLogin;
            string conUserPass;
            string conWindowsLogin;
            if (Var.conLite.ConnectionGetParamName(
                                             connectionName,
                                             out connectionID,
                                             out conServerType,
                                             out conServerName,
                                             out conDatabaseName,
                                             out conDatabaseLogin,
                                             out conDatabasePass,
                                             out conUserForm,
                                             out conUserLogin,
                                             out conUserPass,
                                             out conWindowsLogin) == false) return false;

            //Серверу приложений нельзя подключаться через другой сервер приложений.
            if ((Var.SystemName == "ServerApp") && (conServerType == "ServerApp"))
            {
                SM("Ошибка: Серверу приложений нельзя подключаться через другой сервер приложений!");
                return false;
            }
            if ((Var.SystemName != "ServerApp") && (Var.SystemName != "ParserApp") && (conUserForm == ""))
            {
                SM("Не указана форма для запуска!");
                return false;
            }
            
            //Вход может быть не с теми UserLogin и UserPass, которые указаны в ConnectionList.
            //Но остальные данные берутся по ID соединения.            
            if ((userLoginIN != "") && (userPassIN != ""))
            {
                conUserLogin = userLoginIN;
                conUserPass  = userPassIN;   //sys.GetUserPassCrypt(UserLoginIN,    
            }
    
            Var.con = new Connection();
            Var.con.ConnectionID   = connectionID;
            Var.con.ConnectionName = connectionName;
            Var.con.UserForm       = conUserForm;
            Var.con.UserLogin      = conUserLogin;
            Var.con.UserPass       = conUserPass;
            Var.con.WindowsLogin   = conWindowsLogin;

            ServerType serverType = ServerType.NotAssigned;
            if (conServerType == "MSSQL")     serverType = ServerType.MSSQL;
            if (conServerType == "SQLite")    serverType = ServerType.SQLite;
            if (conServerType == "Postgre")  serverType = ServerType.Postgre;
            if (conServerType == "ServerApp") serverType = ServerType.ServerApp;
            
            //Что-то непонятное. Тип сервера неизвестен.
            if (serverType == ServerType.NotAssigned) return false;
            
            if (!Var.con.ConnectionInit(serverType,
                                    conServerName,
                                    conDatabaseLogin,
                                    conDatabasePass,
                                    conDatabaseName)) return false;

        
            string sql = "";
            
            //Если авторизация Windows.
            if (Var.con.WindowsLogin == "1")
            {
                sql = string.Format("SELECT t1.ID AS UserID, t1.Name AS UserName, t2.Brief AS RoleBrief, t2.ID AS RoleID FROM fbaUser t1 " +
               "LEFT JOIN fbaRole t2 ON t1.RoleID = t2.ID " +
               "WHERE  Upper(t1.Login) = '{0}'", Environment.UserName.ToUpper());
            }
            else sql = string.Format("SELECT t1.ID AS UserID, t1.Name AS UserName, t2.Brief AS RoleBrief, t2.ID AS RoleID FROM fbaUser t1 " +
                "LEFT JOIN fbaRole t2 ON t1.RoleID = t2.ID " +
                "WHERE Upper(t1.Login) = '{0}' AND t1.Pass = '{1}'", conUserLogin.ToUpper(), conUserPass);
            sys.GetValue(DirectionQuery.Remote, sql, out Var.UserID , out Var.UserName, out Var.RoleBrief, out Var.RoleID);
            if (Var.UserID  == "")
            {
                sys.SM("Подключение к базе данных выполнено успешно, но логин или пароль системы указан неверно!");
                return false;
            }
           

            Var.UserIsAdmin  = (Var.RoleBrief.ToUpper() == "ADMIN");
            Var.enterMode    = enterModeIN;            
            Var.ProjectMainName = conUserForm; //con.UserForm;

            if (!Var.UserIsAdmin)
                if ((";Utility;ServerApp;ParserApp;").IndexOf(Var.SystemName, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    sys.SM("У Вас нет прав на запуск данного функционала!");
                    return false;
                }
            if (enterModeIN == EnterMode.Develop) return true;


            //Авторизацию прошли.
            if (conWindowsLogin == "1")
            {
                Var.UserLogin = Environment.UserName;
                Var.UserPass = "";
            }
            else
            {
                Var.UserLogin = conUserLogin;
                Var.UserPass  = conUserPass;
            }

            //Вошли в систему, сохраняем историю. История входов сохраняется на удаленной БД.
            if (Var.SystemName != "Utility")
            {                
                    AddEnterHist(connectionName,
                                 Var.ComputerName,
                                 Var.ComputerUserName,
                                 Var.ProjectMainName,
                                 Var.UserID ,
                                 Var.SystemName,
                                 Var.enterMode);
            }

            //Установка соединения для доступа к системным таблицам.
            //SetSystemConnection();
            //Включаем процесс охранения ошибок на сервере.
            //sys.Error.SaveError = false;  
            return true;
        }
        
        /// <summary>
        /// Добавление в историю входов. Функция только для SQLite.    
        /// </summary>
        /// <param name="connectionNameIN">Имя соединения с БД или сервером приложений</param>
        /// <param name="systemNameIN">Имя прикладной подсистемы</param>
        /// <param name="enterModeIN">Тип входа в программу</param>
        /// <returns></returns>
        public static bool AddEnterLast(string connectionNameIN, string systemNameIN, EnterMode enterModeIN)
        {
            const string localdate = "datetime('now', 'localtime')";            
            string sql = "INSERT INTO fbaEnterLast (EntityID, ConnectionName, SystemName, EnterDate, EnterMode) VALUES (0, '" + connectionNameIN + "', '" + systemNameIN + "'," + localdate + ", '" + enterModeIN.ToString() + "');";
            return Exec(DirectionQuery.Local, sql);
        }     
        
        /// <summary>
        /// Добавление в историю входов. Функция только для Postgre и MSSQL.
        /// </summary>
        /// <param name="connectionNameIN">Имя соединения с БД или сервером приложений</param>
        /// <param name="computerNameIN">Имя компьютера пользователя</param>
        /// <param name="computerUserNameIN">Имя пользователя системы</param>
        /// <param name="userProjectIN">Имя </param>
        /// <param name="userIDIN"></param>
        /// <param name="systemNameIN">Какой Exe клиент подключается. ClientApp, Utility и др.</param>
        /// <param name="enterModeIN">Тип входа: Work, Test, Develop</param>
        /// <returns>Если успешно, то true</returns>
        public static bool AddEnterHist(string connectionNameIN,
                                        string computerNameIN,
                                        string computerUserNameIN,
                                        string userProjectIN,
                                        string userIDIN,
                                        string systemNameIN,
                                        EnterMode enterModeIN)
        {
            string sql = "INSERT INTO fbaEnterHist (EntityID, ConnectionName, ComputerName, ComputerUserName, UserForm, UserID, SystemName, EnterDate, EnterMode) VALUES (" +
            	//sys.GetEntityID("EnterHist") + 
            	"0, '" + connectionNameIN + "','" + computerNameIN + "','" + computerUserNameIN + "','" + userProjectIN + "'," + userIDIN + ",'" + systemNameIN + "', " + sys.DateTimeCurrent() + ",'" + enterModeIN.ToString() + "');";
            return Exec(DirectionQuery.Remote, sql);
        }
         
        #endregion Region. Вход в систему. 

	}
}
