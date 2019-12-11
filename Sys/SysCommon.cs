
/* Сделано в SharpDevelop.
* Пользователь: Травин
* Дата: 06.01.2017
*Время: 0:04
*/

using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Net;
using System.Diagnostics;

namespace FBA
{
   
    #region Region. Перечисляемые типы, коды команд, коды ошибок.
	
    //TODO Сделать простое создание справочника
    	
	
	#endregion Region. Перечисляемые типы, коды команд, коды ошибок. 
     
    /// <summary>
    /// Основной статический класс, в котором собраны различные простые методы.
    /// Общий статический класс для всех проектов: Клиента (ClientApp), Сервера приложений (ServerApp), Utilites, Updater.
    /// Здесь собраны методы общего назначения для работы системы. Это главный класс.
    /// </summary>
    public static partial class sys
    {        
        /// <summary>
        /// Конструктор статического класса.
        /// </summary>
        static sys()
        {          
            #region Глобальный обработчик ошибок всех EXE, использующих sys.sys. (ClientApp, Utility и др.)

            //Обработчик для обработки исключения, вызванного основными потоками.
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            //Обработчик для обработки исключения, вызванного дополнительными потоками
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            #endregion
        }                             	       		
        
        
        /// <summary>
        /// Все исключения, выданные основным потоком, обрабатываются этим методом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            sys.SM(e.Exception.ToString(), MessageType.SystemError);            
        }
        
        /// <summary>
        /// Все исключения, выданные дополнительными потоками, обрабатываются в этом методе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            sys.SM((e.ExceptionObject as Exception).ToString(), MessageType.SystemError);
            //Suspend the current thread for now to stop the exception from throwing.
            //Thread.CurrentThread.Suspend();
        }
        
        #region Region. Поднятие форм из других модулей, вызов методов.   
        
        /// <summary>
        /// Проверка на то, что пользователья является администртором БД.
        /// </summary>        /// <param name="login">Логоин системы FBA</param>
        /// <returns>Если роль = Admin, то true</returns>
        public static bool IsAdmin(string login)
        {
            string sql = "SELECT t2.Brief from fbaUser t1 LEFT JOIN fbaRole t2 ON t1.RoleID = t2.ID  WHERE t1.Login = '" + login + "'";
            string roleBriefIN = GetValue(DirectionQuery.Remote, sql);
            if (roleBriefIN != "admin")
            {
                sys.SM("Пользователь не является администратором!", MessageType.Information, "Поиск пользователя");
                return false;
            }
            return true;
        }
     
        /// <summary>
        /// Заводим пользователя admin, если его ещё нет в базе.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private static string AddAdmin()
        {
            //Роль
            string sql =
                "INSERT INTO fbaRole (Name, Brief, DateCreate, DateChange) " +
                "SELECT 'Admin', 'Admin', " + sys.DateTimeCurrent() + ", " + sys.DateTimeCurrent() + " " +
                "WHERE not exists(select 1 FROM fbaRole WHERE Name = 'Admin' AND Brief = 'Admin'); " + Var.CR;

            //Пользователь               
            sql += "INSERT INTO fbaUser (Login, Name, Pass, RoleID, Block, DateCreate, DateChange) " +
                   "SELECT 'Admin', 'Admin', '', (SELECT ID FROM fbaRole Where Brief = 'admin' AND ID = (SELECT MAX(ID) FROM fbaRole Where Brief = 'Admin')), 0, " + sys.DateTimeCurrent() + ", " + sys.DateTimeCurrent() + " " +
                   "WHERE  not exists(SELECT 1 FROM fbaUser WHERE Login = 'Admin' AND Name = 'Admin'); " + Var.CR;

            //Возвращаем ИД
            sql += "SELECT ID FROM fbaUser WHERE Login = 'Admin';" + Var.CR;
            return GetValue(DirectionQuery.Remote, sql);
        }
       
        /// <summary>
        /// Проверяем наличие пользователя в удаленной базе.
        /// </summary>
        /// <param name="login">Логин системы FBA</param>
        /// <param name="pass">Пароль системы FBA</param>
        /// <returns></returns>
        public static string GetUserID(string login, string pass)
        {
            //Если пользователь admin и админа в базе нет совсем, то создаем с пустым паролем.
            //После пароль можно бужет изменить через функционал дизайнера.
            string sql = "SELECT ID, Pass FROM fbaUser WHERE Login = '" + login + "';";
            string id;
            string userPassLocal;
            if (!GetValue(DirectionQuery.Remote, sql, out id, out userPassLocal)) return "";
            if ((id == "") && (login == "admin")) id = AddAdmin();

            if (id == "")
            {
                sys.SM("Логин или пароль или указан неверно!", MessageType.Information, "Вход в систему");
                return id;
            }
            if (userPassLocal != pass)
            {
                sys.SM("Логин или пароль или указан неверно!", MessageType.Information, "Вход в систему");
                return "";
            }
            return id;
        }
      
        /// <summary>
        /// Проверка наличия права у Пользователя.
        /// </summary>
        /// <param name="rightBrief"></param>
        /// <returns>Если право есть, то true</returns>
        public static bool UserRight(string rightBrief)
        {
            string sql = "SELECT t2.ID FROM fbaRelRoleRight t1 " +
                         "LEFT JOIN fbaRight t2 ON t1.RightID = t2.ID " +
                         "WHERE t1.RoleID = " + Var.RoleID + " AND t2.Brief = '" + rightBrief + "'" +
            			 " UNION ALL " + 
            		     "SELECT t2.ID FROM fbaRelUserRight t1 " +
                         "LEFT JOIN fbaRight t2 ON t1.RightID = t2.ID " +
            		     "WHERE t1.UserID = " + Var.UserID  + " AND t2.Brief = '" + rightBrief + "'";
            string rightID = sys.GetValue(DirectionQuery.Remote, sql);
            return (rightID != "");
        }
        
        /// <summary>
        /// Проверка прав на проект у пользователя.
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        /// <returns></returns>
        public static bool IsUserProjectGrant(string projectName)
        {                    	                     
        	string sql = "SELECT t3.ID FROM fbaRelRoleProject t1 " +
                "LEFT JOIN fbaUser t2 ON t1.RoleID = t2.RoleID " +
                "LEFT JOIN fbaProject t3 ON t1.ProjectID = t3.ID " +
                "WHERE t2.ID = " + Var.UserID  + " AND t3.Name = '" + projectName + "'";
            string projectID = sys.GetValue(DirectionQuery.Remote, sql);
            if (projectID != "") return true;     

			sql = "SELECT ID FROM fbaProject WHERE Name = '" + projectName + "'";
            projectID = sys.GetValue(DirectionQuery.Remote, sql); 
		    if (projectID == "") 
		    {
		    	sys.SM("Проект '" + projectName + "' не найден!");
		    	return false;
		    }                 
            sys.SM("У пользователя '" + Var.UserName + "' нет прав на запуск формы проекта: " + projectName);
            return false;
        }     
  
        /// <summary>
        /// Простой показ справочника, остальные параметры по умолчанию.      
        /// </summary>
        /// <param name="entityBrief">Cущность,которую показываем.</param>
        /// <param name="formProject">Это имя DLL, где находится форма свойств с именем FormName. Форма свойств появляется при двойном клике на строке грида.</param>
        /// <param name="formName">Имя самой формы свойства объекта. Если в DLL всего одна форма, то formProject и formName совпадают.</param>
        /// <param name="objectID">ИД объекта, которые будет выделено по умолчанию</param>
        /// <param name="listObjectID">Список ИД объектов, которые показываем</param>
        /// <param name="customSQL">Произвольный текст запроса SQL</param>
        /// <param name="customMSQL">Произвольный текст запроса MSQL</param>
        /// <returns>Форма справочника тип FormFBA</returns>
        public static FormFBA ShowDirectorySimple(string entityBrief, 
                                                  string formProject, 
                                                  string formName,  
                                                  string objectID, 
                                                  string[] listObjectID,
                                                  string customSQL,
                                                  string customMSQL)
        {
            //FBALink.Entity:ДогСтрах,ObjectID:41297
            //FBALink.Entity:ДогСтрах,ObjectID:63600
            //FBALink.Entity:ДогСтрах,ObjectID:2459
            string[] ids = null; 
            if (listObjectID != null)
            {
                //ids = new string[ListObjectID.Length];
                entityBrief = StrBetweenStr(listObjectID[0], "FBALink.Entity:", ",ObjectID");
                int p = listObjectID[0].IndexOfEx("ObjectID:");
                var sb = new StringBuilder();

                for (int i = 0; i < listObjectID.Length; i++)
                {
                    string id = listObjectID[i].SubStringEnd(p + 9);
                    if ((id != "") && (id != Var.CR)) sb.Append(id) ;

                }
                ids = sb.ToString().Split('\r');
            }

            var listParams = new DirectoryParams();
            listParams.EntityBrief  = entityBrief;
            listParams.ObjectID     = objectID;
            listParams.Multiselect  = true;                       
            listParams.showMode     = ShowMode.Filter;
            listParams.FormProject  = formProject;
            listParams.FormName     = formName;
            listParams.ListObjectID = ids;
            listParams.СustomMSQLQuery = customMSQL;
            listParams.СustomSQLQuery  = customSQL;
            if (!string.IsNullOrEmpty(customMSQL)) listParams.showMode = ShowMode.ExecMSQL;
            if (!string.IsNullOrEmpty(customSQL)) listParams.showMode = ShowMode.ExecSQL;
            
            if ((!string.IsNullOrEmpty(customMSQL)) || (!string.IsNullOrEmpty(customSQL)))
            {
            	listParams.ButtonFilter = false;
            	listParams.ButtonAdd    = false;
            	listParams.ButtonEdit   = false;
            	listParams.ButtonDelete = false;            
            }

            var fObj = new FormDirectory(entityBrief, ref listParams);
            fObj.Show();
            return fObj;
        }
      
        #endregion Region. Поднятие форм из других модулей, вызов методов.

        #region Region. Проверка на условие.															  

        /// <summary>
        /// Для сокращения строк кода. Проверка на условие. Пример: 
        /// if (ErrorCheck(!File.Exists(fileName), "File not found: " + fileName)) return false;
        /// </summary>
        /// <param name="condition">Условие</param>
        /// <param name="errorMes">Сообщение об ошибке</param>
        /// <returns></returns>
        public static bool ErrorCheck(bool condition, string errorMes)
        {
            if (condition)
            {
                sys.SM(errorMes);
                return true;
            }
            return false;
        }

        #endregion Region. Проверка на условие.        		         
                                               
        #region Region. Копирование таблицы на сервер.      
        
        /// <summary>
        /// Получение текста DROP TABLE, CREATE TABLE, INSERT для копирования таблицы DT на сервер. DatabaseType: MSSQL, Postgre, SQLite. 
        /// </summary>
        /// <param name="serverType">Тип сервера: SQLite, MSSQL, Postgre</param>
        /// <param name="tableName">Имя таблицы на сервере</param>
        /// <param name="dt">DataTable которая будет копироваться</param>
        /// <param name="createTable">Если true, то добавится код удаления таблицы, если такая уже есть</param>
        /// <returns>Код SQL создания таблицы на сервере и INSERTы для всех записей из DataTable</returns>
        public static string GetTextTableToDatabase(ServerType serverType, string tableName, System.Data.DataTable dt, bool createTable)
        {
            string textDropCreateTable = "";
            if (createTable) textDropCreateTable = sys.GetTextDropTable(serverType, tableName) + Var.CR + sys.GetTextCreateTable(serverType, tableName, dt);
            return textDropCreateTable + sys.GetTextInsertTable(serverType, tableName, dt);
        }
        
        /// <summary>
        /// Копирование таблицы DT в локальную БД SQLite в таблицу с именем TableName. 
        /// </summary>
        /// <param name="tableName">Имя таблицы в базе SQLite</param>
        /// <param name="dt">DataTable которая будет копироваться</param>
        /// <param name="createTable">Если true, то добавится код удаления таблицы, если такая уже есть</param>
        /// <returns>Код SQL создания таблицы в базе SQLite и INSERTы для всех записей из DataTable</returns>
        public static bool CopyDataTableToLocalTable(string tableName, System.Data.DataTable dt, bool createTable)
        {
            string sql = Var.CR + sys.GetTextTableToDatabase(ServerType.SQLite, tableName, dt, createTable);
            return Var.conLite.Exec(sql);
        }       
        
        /// <summary>
        /// Получение текста DROP TABLE. DatabaseType: MSSQL, Postgre, SQLite.
        /// </summary>
        /// <param name="serverType">Тип сервера: SQLite, MSSQL, Postgre</param>
        /// <param name="tableName">Имя таблицы на сервере, которую нужно удалить, если такая уже есть</param>
        /// <returns>Запрос SQL для удаления таблицы, если есть</returns>
        public static string GetTextDropTable(ServerType serverType, string tableName)
        {
            if (serverType == ServerType.MSSQL) return "BEGIN TRY DROP TABLE '" + tableName + "' END TRY BEGIN CATCH END CATCH; " + Var.CR;
            return "DROP TABLE IF EXISTS " + tableName + ";" + Var.CR;
        }
       
        /// <summary>
        /// Получение текста CREATE TABLE. DatabaseType: MSSQL, Postgre, SQLite.
        /// </summary>
        /// <param name="serverType">Тип сервера: SQLite, MSSQL, Postgre</param>
        /// <param name="tableName">Имя таблицы на сервере, которую нужно создать</param>
        /// <param name="dt">DataTable которая будет копироваться</param>
        /// <returns>Получение CREATE TABLE и INSERT для копирования таблицы DT на сервер.</returns>
        public static string GetTextCreateTable(ServerType serverType, string tableName, System.Data.DataTable dt)
        {
            var result = new StringBuilder("", 300);
            result.Append("CREATE TABLE " + tableName + Var.CR + "(");
            string textFieldType = " TEXT";
            if (serverType == ServerType.MSSQL) textFieldType = " VARCHAR(MAX)";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                result.Append(dt.Columns[i].ColumnName);
                string TypeName = dt.Columns[i].DataType.Name;
                switch (TypeName)
                {   //Int32, String, DateTime
                    case "Int32": result.Append(" INTEGER"); break;
                    case "DateTime": result.Append(" " + DateTimeFieldType(serverType)); break;
                    default: result.Append(textFieldType); break;
                }
                if (i < dt.Columns.Count - 1) result.Append("," + Var.CR);
            }
            result.Append("); " + Var.CR);
            return result.ToString();
        }
     
        /// <summary>
        /// Получение текста INSERT для вставки записей в таблицу в БД из таблицы DT.
        /// </summary>
 		/// <param name="serverType">Тип сервера: SQLite, MSSQL, Postgre</param>
        /// <param name="tableName">Имя таблицы на сервере, которую нужно создать</param>
        /// <param name="dt">DataTable которая будет копироваться</param>
        /// <returns>Получение INSERT для копирования таблицы DT на сервер.</returns>
        public static string GetTextInsertTable(ServerType serverType, string tableName, System.Data.DataTable dt)
        {
            string textBeginTran = "";
            var insertText = new StringBuilder("", 10000);
            if (serverType == ServerType.MSSQL)   textBeginTran = "BEGIN TRANSACTION SET IDENTITY_INSERT " + tableName + " ON " + Var.CR;
            if (serverType == ServerType.SQLite)  textBeginTran = "BEGIN TRANSACTION;" + Var.CR;
            if (serverType == ServerType.Postgre) textBeginTran = "BEGIN TRANSACTION;" + Var.CR;
            insertText.Append(textBeginTran);
            var insertBeg = new StringBuilder("INSERT INTO " + tableName + " (", 1000);
            int iColumnCount = dt.Columns.Count;
            bool Is19 = false; //Для того чтобы конвертировать дату.
            for (int i = 0; i < iColumnCount; i++)
            {
                insertBeg.Append(dt.Columns[i].ColumnName);
                if (i < iColumnCount - 1) insertBeg.Append(",");
                if (dt.Rows.Count > 0)
                    Is19 = (dt.Rows[0][i].ToString().Length == 19);
            }
            string insertBegStr = insertBeg.ToString() + ") SELECT * FROM (" + Var.CR;
            insertText.Append(insertBegStr.ToString());
            var insertStr = new StringBuilder("", 1000);
            string value;
            if (Is19)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    insertStr.Clear();
                    for (int j = 0; j < iColumnCount; j++)
                    {
                        value = dt.Rows[i][j].ToString().DateTimeStrToMSSQL().Replace("'", "''");
                        //Value = DT.Rows[i][j].ToString().DateTimeConvertStr(string FormatIN, string FormatOUT).Replace("'","''");
                        insertStr.Append("'" + value + "'");
                        if (j < iColumnCount - 1) insertStr.Append(",");
                    }
                    if (i == dt.Rows.Count - 1)
                        insertText.Append("SELECT " + insertStr.ToString() + Var.CR);
                    else
                        insertText.Append("SELECT " + insertStr.ToString() + " UNION ALL " + Var.CR);
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    insertStr.Clear();
                    for (int j = 0; j < iColumnCount - 1; j++)
                    {
                        value = dt.Rows[i][j].ToString().Replace("'", "''");
                        insertStr.Append("'" + value + "',");
                    }
                    value = dt.Rows[i][iColumnCount - 1].ToString().Replace("'", "''");
                    insertStr.Append("'" + value + "'");
                    if (i == dt.Rows.Count - 1)
                        insertText.Append("SELECT " + insertStr.ToString() + Var.CR);
                    else
                        insertText.Append("SELECT " + insertStr.ToString() + " UNION ALL " + Var.CR);
                    //InsertText.Append(InsertBegStr + InsertStr.ToString() + ");" + Var.CR);
                }
            }
            insertText.Append("); " + Var.CR);
            string TextEndTran = "";
            if (serverType == ServerType.MSSQL)    TextEndTran = "SET IDENTITY_INSERT " + tableName + " OFF " + Var.CR + "COMMIT TRANSACTION; " + Var.CR;
            if (serverType == ServerType.SQLite)   TextEndTran = Var.CR + " COMMIT TRANSACTION; " + Var.CR;
            if (serverType == ServerType.Postgre) TextEndTran = Var.CR + " COMMIT TRANSACTION; " + Var.CR;

            insertText.Append(TextEndTran);
            string s = insertText.ToString();
            return insertText.ToString();
        }
       
        #endregion Region. Копирование таблицы на сервер.                                                                

        #region Region. Параметры приложения и настройки.
    
        /// <summary>
        /// Получение значения по умолчанию - количество строк для отображения.
        /// </summary>
        /// <param name="rowCount">Количество строк для отображения</param>
        /// <returns>Если удалось получить, то true</returns>
        public static bool GetDefaultRowCount(out string rowCount)
        {
            rowCount = "";
            if (Var.DefaultRowCount == "0")
            {               
                var par = new string[1];     
                Param.Load(DirectionQuery.Remote, Var.UserID , "DefaultRowCount", true, "User", out par);
                rowCount = par[0];
                return true;
            } else
            {
                rowCount = Var.DefaultRowCount;
                return true;
            }                          
        }

        #endregion Region. Параметры приложения и настройки.

        #region Region. Парсер.                     
      
        /// <summary>
        /// Метод для установки Enable/Disable компонента - разбор свойства компонента GroupEnabled.      
        /// Пример вызова: Var.controlEnableDisable(PanelFilter);
        /// </summary>
        /// <param name="form">Начальный контрол, на котором нужно проводить поиск всех компонентов.</param>
        public static void ControlEnableDisable(Control form)
        {
            sys.ControlEnableDisable2(form, form.Controls);
        }     
        
        /// <summary>
        /// Метод исключительно для ControlEnableDisable.
        /// для установки Enable/Disable компонента - разбор свойства компонента GroupEnabled.
        /// </summary>
        /// <param name="form">Форма, на которой нужно изменить Enable/Disable для компонентов</param>
        /// <param name="controls">Набор контролов</param>
        private static void ControlEnableDisable2(Control form, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                ControlEnableDisable2(form, control.Controls);
                string compType = control.GetType().ToString();
                //CompType = sys.TruncateType(CompType);                
                bool typeFBA = false;
                if ((compType == "FBA.TextBoxFBA") ||
                   (compType == "FBA.ComboBoxFBA") ||
                   (compType == "FBA.CheckBoxFBA") ||
                   (compType == "FBA.RadioButtonFBA") ||
                   (compType == "FBA.PanelFBA") ||
                   (compType == "FBA.ButtonFBA")) typeFBA = true;
                if (!typeFBA) continue;
                string groupText = "";
                if (compType      == "FBA.TextBoxFBA")     groupText = ((TextBoxFBA)control).GroupEnabled;
                else if (compType == "FBA.ComboBoxFBA")    groupText = ((ComboBoxFBA)control).GroupEnabled;
                else if (compType == "FBA.CheckBoxFBA")    groupText = ((CheckBoxFBA)control).GroupEnabled;
                else if (compType == "FBA.RadioButtonFBA") groupText = ((RadioButtonFBA)control).GroupEnabled;
                else if (compType == "FBA.PanelFBA")       groupText = ((PanelFBA)control).GroupEnabled;
                else if (compType == "FBA.ButtonFBA")      groupText = ((ButtonFBA)control).GroupEnabled;
                if (groupText == null) continue;
                if (groupText == "") continue;

                string[] listGroup = groupText.Split(';');
                int enableFBA = 0;
                for (int i = 0; i < listGroup.Count(); i++)
                {
                    Control contolFBA = form.Controls.Find(listGroup[i], true).FirstOrDefault();
                    if (contolFBA == null) continue;
                    string contolFBAType = contolFBA.GetType().ToString();
                    bool contolFBAEnabled = false;
                    if (contolFBAType == "System.Windows.Forms.CheckBox") contolFBAEnabled = ((System.Windows.Forms.CheckBox)contolFBA).Checked;
                    if (contolFBAType == "FBA.CheckBoxFBA") contolFBAEnabled = ((CheckBoxFBA)contolFBA).Checked;
                    if (contolFBAType == "System.Windows.Forms.RadioButton") contolFBAEnabled = ((System.Windows.Forms.RadioButton)contolFBA).Checked;
                    if (contolFBAType == "FBA.RadioButtonFBA") contolFBAEnabled = ((RadioButtonFBA)contolFBA).Checked;
                    if (contolFBAEnabled) enableFBA++;
                }
                control.Enabled = (enableFBA == listGroup.Count());
             }
        }     
        
        /// <summary>
        /// Получить код для получения ID вставленной/изменённой записи.
        /// Postgre: ; RETURNING id;                     
        /// MSSQL: ; SELECT @@IDENTITY AS id;                                         
        /// SQLite: ; SELECT last_insert_rowid() AS id;
        /// </summary>
        /// <param name="direction">Локальная или удалённая БД</param>
        /// <returns>Код SQL</returns>
        public static string GetInsertID(DirectionQuery direction)
        {
            if (direction == DirectionQuery.Local) return Var.conLite.GetInsertID();
            if (direction == DirectionQuery.Remote) return Var.con.GetInsertID();
            return "";
        }      
        
        /// <summary>
        /// Парсим Tag контрола. 
        /// Пример: ParseTag("Main1.Страхователь.ИНН;SAVE", out QueryName, out Attr, out Setting);
        /// На выходе: QueryName = Main1, Attr = Name, AttrLokkup = ИНН, Setting = SAVE
        /// </summary>
        /// <param name="tagStr"></param>
        /// <param name="queryName"></param>
        /// <param name="attr"></param>
        /// <param name="attrLookup"></param>
        /// <param name="setting"></param>
        public static void ParseTag(string tagStr,
                                    out string queryName,
                                    out string attr,
                                    out string attrLookup,
                                    out string setting)
        {           
            queryName = "";
            attr = "";
            attrLookup = "";
            setting = "";
            if (tagStr == null) return;
            if (tagStr == "") return;
            string[] dotArray1 = tagStr.Split(';');
            setting = (dotArray1.Count() > 1) ? dotArray1[1].ToUpper().Trim() : "";
            string[] dotArray2 = dotArray1[0].Split('.');
            if (dotArray2.Length > -1) queryName = dotArray2[0];
            if (dotArray2.Length > 1) attr = dotArray2[1];
            for (int i = 2; i < dotArray2.Length; i++)
            {
                if (attrLookup != "") attrLookup = attrLookup + ".";
                attrLookup = attrLookup + dotArray2[i];
            }            
        }
         
        #endregion Region. Парсер.
    }
}
