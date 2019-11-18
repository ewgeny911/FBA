
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 28.09.2017
 * Время: 17:52
*/ 
 
using System;  
using System.Linq;        
using System.Windows.Forms.VisualStyles;
using FastColoredTextBoxNS;       
using System.Windows.Forms;
using System.IO;
using System.Data;     
using System.Collections.Generic;  
namespace FBA
{     
	/// <summary>
	/// Форма операция со скриптами создания таблиц
	/// </summary>
	public partial class FormDDL : FormFBA
	{
		
		/// <summary>
		/// Форма операция со скриптами создания таблиц
		/// </summary>
		public FormDDL()
		{			
			InitializeComponent();			 	
			this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;            		
		}
			
        #region Вкладка Create DDL.                                
             
        ///Загрузить все.
        private void LoadAll()
        {                                       
            FBAFile.FileReadTextObject(tbTextSQLite, FBAPath.PathAdditional + "NewDatabase_SQLite.sql");
            FBAFile.FileReadTextObject(tbTextPostgre, FBAPath.PathAdditional + "NewDatabase_Postgre.sql");
            FBAFile.FileReadTextObject(tbTextMSSQL, FBAPath.PathAdditional + "NewDatabase_MSSQL.sql");              
        }
        
        ///Сохранить все.
        private void SaveAll()
        {
            if (tbTextSQLite.Text   == "") return;
            if (tbTextPostgre.Text == "") return;
            if (tbTextMSSQL.Text    == "") return;              
            File.WriteAllText(FBAPath.PathAdditional + "NewDatabase_SQLite.sql",   tbTextSQLite.Text, System.Text.Encoding.Default);
            File.WriteAllText(FBAPath.PathAdditional + "NewDatabase_Postgre.sql", tbTextPostgre.Text, System.Text.Encoding.Default);
            File.WriteAllText(FBAPath.PathAdditional + "NewDatabase_MSSQL.sql",    tbTextMSSQL.Text, System.Text.Encoding.Default);             
        }
        
        ///Конвертация скрипта SQL создания базы данных из кода SQLite в код Postgre.
        private void ConvertToPostgre()
        {    
           //при конвертировании DLL скриптов создания таблиц из SQLite в Postgre нужно заменить.
           //INTEGER PRIMARY KEY AUTOINCREMENT заменить на serial NOT NULL
           //DATETIME на timestamp without time zone
           //добавить в конец каждой табицы ,CONSTRAINT "pk_Form_ID" PRIMARY KEY (ID)         
           tbTextPostgre.Text = tbTextSQLite.Text;
            
           int p1 = tbTextPostgre.Text.IndexOf("CREATE TABLE");
           int p2 = -1;
           string s1 = "";
           string s2 = "";
           string tableName = "";
           while (p1 > -1)
           {
               p2 = tbTextPostgre.Text.IndexOf(");", p1);
               if ((p1 > -1) && (p2 > 0))
               {
                   s1 = tbTextPostgre.Text.Substring(p1, p2 - p1 + 2);
                   tableName = sys.StrBetweenStr(s1, "CREATE TABLE", "(").Trim();
                   s2 = s1.Replace("INTEGER PRIMARY KEY AUTOINCREMENT", "serial NOT NULL");
                   s2 = s2.Replace("DATETIME", "timestamp without time zone");               
                   s2 = s2.Replace(");", ", CONSTRAINT \"pk_" + tableName + "_ID\" PRIMARY KEY (ID));");
                   tbTextPostgre.Text = tbTextPostgre.Text.Replace(s1, s2);
               } 
               if (p2 > 0) p1 = tbTextPostgre.Text.IndexOf("CREATE TABLE", p2); else p1 = -1;
           }                          
        }
                 
        ///Конвертация скрипта SQL создания базы данных из кода SQLite в код Postgre.
        private void ConvertToMSSQL()
        {   
           //при конвертировании DLL скриптов создания таблиц из SQLite в Postgre нужно заменить.
           //INTEGER PRIMARY KEY AUTOINCREMENT заменить на serial NOT NULL
           //DATETIME на timestamp without time zone
           //добавить в конец каждой табицы ,CONSTRAINT "pk_Form_ID" PRIMARY KEY (ID)         
           tbTextMSSQL.Text = tbTextSQLite.Text;
            
           int p1 = tbTextMSSQL.Text.IndexOf("CREATE TABLE");
           int p2 = -1;
           string s1 = "";
           string s2 = "";
           string tableName = "";
           while (p1 > -1)
           {
               p2 = tbTextMSSQL.Text.IndexOf(");", p1);
               if ((p1 > -1) && (p2 > 0))
               {
                   s1 = tbTextMSSQL.Text.Substring(p1, p2 - p1 + 2);
                   tableName = sys.StrBetweenStr(s1, "CREATE TABLE", "(").Trim();
                   s2 = s1.Replace("PRIMARY KEY AUTOINCREMENT", "IDENTITY(1,1) NOT NULL");                    
                   s2 = s2.Replace(");", " CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED ([ID] ASC));");
                   s2 = s2.Replace(" timestamp without time zone", " DATETIME ");
                   s2 = s2.Replace(" current_timestamp", " DATETIME ");                  
                   s2 = s2.Replace(" BOOLEAN", " INT");
                   s2 = s2.Replace(" BOOL", " INT");
                   s2 = s2.Replace(" TEXT,", " VARCHAR(MAX),");
                   s2 = s2.Replace(" TEXT)", " VARCHAR(MAX))");              
                   
                   tbTextMSSQL.Text = tbTextMSSQL.Text.Replace(s1, s2);
               } 
               if (p2 > 0) p1 = tbTextMSSQL.Text.IndexOf("CREATE TABLE", p2); else p1 = -1;
           }                       
        }
        
        ///Выполнить скрипт SQLite или Postgres.
        private void ExecuteScript(FastColoredTextBoxNS.FastColoredTextBox tb, Connection conLocal)
        {          
            string sql = tb.SelectedText;
            if (sql == "") sql = tb.Text;              
            if (conLocal.Exec(sql)) sys.SM("Выполнено!", MessageType.Information);
        }
        
        ///Создание необходимых таблиц для работы Дизайнера и клиента в базе данных.
        private void CreateTables()
        {                             
            if (sys.ErrorCheck(!Var.con.ConnectionActive,  "В настоящее время нет соединения с базой!")) return;
            string fileName = FBAPath.PathMain + "newdatabase_" + Var.con.serverTypeRemote + ".sql";
            if (sys.ErrorCheck(!(System.IO.File.Exists(fileName)), "Не найден файл:" + fileName)) return;                   
            if (!(sys.SM("Текущее соединение с базой " + Var.con.serverTypeRemote + ". Создать новую базу данных?", MessageType.Question))) return;
            string sql = System.IO.File.ReadAllText(fileName, System.Text.Encoding.Default);
            if (sys.Exec(DirectionQuery.Remote, sql) == false) return;
            sys.SM("Таблицы в базе данных созданы!", MessageType.Information);
        }
        
        //Кнопки комманд DDL
        private void TbDDL1Click(object sender, EventArgs e)
        {                       
            if (sender == tbDDL1) LoadAll();
            if (sender == tbDDL2) SaveAll();
            
            //Конвертация скрипта SQL в код Postgre и MSSQL.
            if (sender == tbDDL3)
            {
                ConvertToPostgre();
                ConvertToMSSQL();
            }
            
            //Новая база данных. 
            if (sender == tbDDL4) CreateTables();
            //Выполнить скрипт SQLite.
            if (sender == tbDDL5) ExecuteScript(tbTextSQLite, Var.conLite);   
            //Выполнить скрипт Postgres. 
            if (sender == tbDDL6) ExecuteScript(tbTextPostgre, Var.conLite);
            //Выполнить скрипт MSSQL.            
            if (sender == tbDDL7) ExecuteScript(tbTextMSSQL, Var.conLite);                        
        }          
        
        #endregion 
       
          
        /*private string GetSQLCreateFBA()
        {
            const string SQL = "--===================================================================== " + Var.CR +
            "--Подготовка таблиц для парсера.                                                     " + Var.CR +
            "BEGIN TRY DROP TABLE EntityParent END TRY BEGIN CATCH END CATCH                      " + Var.CR +
            "BEGIN TRY DROP TABLE #EntityParser END TRY BEGIN CATCH END CATCH                     " + Var.CR +
            "BEGIN TRY DROP TABLE #AttrParent END TRY BEGIN CATCH END CATCH                       " + Var.CR +
            "BEGIN TRY DROP TABLE #AttrChild END TRY BEGIN CATCH END CATCH                        " + Var.CR +
            "BEGIN TRY DROP TABLE #Entity END TRY BEGIN CATCH END CATCH                           " + Var.CR +
            "BEGIN TRY DROP TABLE #Attr END TRY BEGIN CATCH END CATCH                             " + Var.CR +
            "BEGIN TRY DROP TABLE #Attribute END TRY BEGIN CATCH END CATCH                        " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "                                                                                     " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "--Таблица #EntityParser с сущностями.                                                " + Var.CR +
            "SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos, *                                         " + Var.CR +
            "  INTO #EntityParser FROM dbo.fbaEntity                                               " + Var.CR +
            "                                                                                     " + Var.CR +
            "ALTER TABLE #EntityParser ADD Table_ID varchar(100)                                  " + Var.CR +
            "ALTER TABLE #EntityParser ADD Table_Name varchar(100)                                " + Var.CR +
            "ALTER TABLE #EntityParser ADD Table_IDFieldName varchar(100)                         " + Var.CR +
            "                                                                                     " + Var.CR +
            "UPDATE #EntityParser SET Table_ID    = t2.ID,                                   " + Var.CR +
            "                   Table_Name        = t2.Name,                                      " + Var.CR +
            "                   Table_IDFieldName = t2.IDFieldName                                " + Var.CR +
            "FROM dbo.fbaTable t2 WHERE t2.TableEntityID = #EntityParser.ID AND t2.Type = 1        " + Var.CR +
            "UPDATE #EntityParser SET Pos = Pos - 1                                               " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "                                                                                     " + Var.CR +
            "--=====================================================================              " + Var.CR +       
            "--Таблица #EntityParent с деревом сущностей.                                         " + Var.CR +
            ";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS  " + Var.CR +
            "      (                                                                              " + Var.CR +
            "        SELECT                                                                       " + Var.CR +
            "          ID AS EnChildID,                                                           " + Var.CR +
            "          Brief AS EnBrief2,                                                         " + Var.CR +
            "          ID as EnID,                                                                " + Var.CR +
            "          Brief as EnBrief1,                                                         " + Var.CR +
            "          ParentID,                                                                  " + Var.CR +
            "          Name as EnBriefName2,                                                      " + Var.CR +
            "          Name as EnBriefName1                                                       " + Var.CR +
            "        FROM dbo.fbaEntity                                                            " + Var.CR +
            "        UNION ALL                                                                    " + Var.CR +
            "        SELECT                                                                       " + Var.CR +
            "          EnChildID,                                                                 " + Var.CR +
            "          EnBrief2,                                                                  " + Var.CR +
            "          e.ID as EnID,                                                              " + Var.CR +
            "          e.Brief as EnBrief1,                                                       " + Var.CR +
            "          e.ParentID,                                                                " + Var.CR +
            "          p.EnBriefName2 as EnBriefName2,                                            " + Var.CR +
            "          e.Name as EnBriefName1                                                     " + Var.CR +
            "        FROM dbo.fbaEntity e INNER JOIN Parents p ON p.ParentID = e.ID                " + Var.CR +
            "      ) SELECT * INTO #EntityParent FROM Parents ORDER BY EnBrief2, EnBrief1;        " + Var.CR +
            "                                                                                     " + Var.CR +
            "ALTER TABLE #EntityParent ADD EnBrief2_TableName varchar(100);         --Главная таблица сущности EnBrief2.                " + Var.CR +
            "ALTER TABLE #EntityParent ADD EnBrief2_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief2. " + Var.CR +
            "ALTER TABLE #EntityParent ADD EnBrief1_TableName varchar(100);         --Главная таблица сущности EnBrief1.                " + Var.CR +
            "ALTER TABLE #EntityParent ADD EnBrief1_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief1. " + Var.CR +     
            "                                                                                     " + Var.CR +
            "--Данные по таблице для сущности EnBrief2                                            " + Var.CR +
            "UPDATE #EntityParent SET                                                             " + Var.CR +
            "  #EntityParent.EnBrief2_TableName        = t1.Table_Name,                           " + Var.CR +
            "  #EntityParent.EnBrief2_TableIDFieldName = t1.Table_IDFieldName                     " + Var.CR +
            "FROM #EntityParser t1 WHERE #EntityParent.EnBrief2 = t1.Brief                        " + Var.CR +
            "                                                                                     " + Var.CR +
            "--Данные по таблице для сущности EnBrief1                                            " + Var.CR +
            "UPDATE #EntityParent SET                                                             " + Var.CR +
            "  #EntityParent.EnBrief1_TableName        = t1.Table_Name,                           " + Var.CR +
            "  #EntityParent.EnBrief1_TableIDFieldName = t1.Table_IDFieldName                     " + Var.CR +
            "FROM #EntityParser t1 WHERE #EntityParent.EnBrief1 = t1.Brief                        " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "                                                                                     " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "--Таблица #AttrParser с атрибутами                                                   " + Var.CR +
            "SELECT                                                                               " + Var.CR +
            "  ID                AS ID,                                                           " + Var.CR +
            "  EntityID          AS EntityID,                                                     " + Var.CR +
            "  AttributeEntityID AS Attr_EntityID,                                                " + Var.CR +
            "  Name              AS Attr_Name,                                                    " + Var.CR +
            "  Brief             AS Attr_Brief,                                                   " + Var.CR +
            "  Type              AS Attr_Type,                                                    " + Var.CR +
            "  Kind              AS Attr_Kind,                                                    " + Var.CR +
            "  Mask              AS Attr_Mask,                                                    " + Var.CR +
            "  Feature           AS Attr_Feature,                                                 " + Var.CR +
            "  ObjectNameOrder   AS Attr_NameOrder,                                               " + Var.CR +
            "  Code              AS Attr_Code,                                                    " + Var.CR +
            "  Description       AS Attr_Comment,                                                 " + Var.CR +
            "  ID                AS Table_ID,                                                     " + Var.CR +
            "  FieldName         AS Table_Field,                                                  " + Var.CR +
            "  FieldName2        AS Table_Field2,                                                 " + Var.CR +
            "  RefEntityID       AS Ref_EntityID,                                                 " + Var.CR +
            "  RefAttributeID    AS Ref_AttrID                                                    " + Var.CR +
            "INTO #AttrParser                                                                     " + Var.CR +
            "FROM dbo.fbaAttribute                                                                 " + Var.CR +
            "                                                                                     " + Var.CR +
            "ALTER TABLE #AttrParser ADD Table_Name varchar(100);          --Данные по таблице, в которой находится атрибут. Имя таблицы.    " + Var.CR +
            "ALTER TABLE #AttrParser ADD Table_IDFieldName varchar(100);   --Данные по таблице, в которой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа) " + Var.CR +
            "ALTER TABLE #AttrParser ADD Table_Type int;                   --Тип таблицы (Главная или Историчная)                           " + Var.CR +
            "ALTER TABLE #AttrParser ADD Table_Feature int;                --Свойства таблицы.                                              " + Var.CR +
            "ALTER TABLE #AttrParser ADD Ref_EntityBrief varchar(100);     --Сокращение сущности для атрибута Ссылки или Массива            " + Var.CR +
            "ALTER TABLE #AttrParser ADD Ref_AttrBrief varchar(100);       --Сокращение атрибута сущности для атрибута Ссылки или Массива   " + Var.CR +
            "ALTER TABLE #AttrParser ADD Ref_AttrName varchar(100);        --Наименование атрибута сущности для атрибута Ссылки или Массива " + Var.CR +
            "ALTER TABLE #AttrParser ADD Attr_EntityBrief varchar(100);    --Сокращение сущности, к которой относится атрибут.               " + Var.CR +
            "                                                                                     " + Var.CR +
            "--Данные по таблице атрибута                                                         " + Var.CR +
            "UPDATE #AttrParser SET                                                               " + Var.CR +
            "  #AttrParser.Table_Name        = t1.Name,                                           " + Var.CR +
            "  #AttrParser.Table_IDFieldName = t1.IDFieldName,                                    " + Var.CR +
            "  #AttrParser.Table_Feature     = t1.Feature,                                        " + Var.CR +
            "  #AttrParser.Table_Type        = t1.Type                                            " + Var.CR +
            "FROM dbo.fbaTable t1                                                                  " + Var.CR +
            "WHERE #AttrParser.Table_ID = t1.ID                                              " + Var.CR +
            "                                                                                     " + Var.CR +
            "--Данные для атрибута Ссылки или Массива.                                            " + Var.CR +
            "UPDATE #AttrParser SET Ref_EntityBrief = t1.Brief FROM dbo.fbaEntity t1 WHERE #AttrParser.Ref_EntityID = t1.ID  " + Var.CR +
            "UPDATE #AttrParser SET Ref_AttrBrief   = t1.Brief,                                   " + Var.CR +
            "                 Ref_AttrName    = t1.Name                                           " + Var.CR +
            "FROM dbo.fbaAttribute t1                                                              " + Var.CR +
            "WHERE #AttrParser.Ref_AttrID = t1.ID and #AttrParser.Ref_EntityID = t1.AttributeEntityID " + Var.CR +
            "                                                                                      " + Var.CR +
            "--Сущность атрибута                                                                  " + Var.CR +
            "UPDATE #AttrParser SET Attr_EntityBrief = t1.Brief FROM dbo.fbaEntity t1 WHERE #AttrParser.Attr_EntityID = t1.ID " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "                                                                                     " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "--Таблица #AttrParent с атрибутами. Для каждой сущности весь полный список атрибутов, включая предков. " + Var.CR +
            "SELECT ROW_NUMBER() OVER(ORDER BY EnBrief2) Pos, t1.*, t2.*                          " + Var.CR +
            "  INTO #AttrParent FROM #AttrParser t1                                               " + Var.CR +
            "  LEFT JOIN #EntityParent t2 ON t2.EnID = t1.Attr_EntityID                           " + Var.CR +
            "UPDATE #AttrParent   SET Pos = Pos - 1                                               " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "                                                                                     " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "--Таблица #AttrChild с атрибутами. Для каждой сущности список атрибутов потомков.    " + Var.CR +
            "--Работает, но пока отключено.                                                       " + Var.CR +
            "--SELECT ROW_NUMBER() OVER(ORDER BY Attr_EntityID, Attr_Brief) Pos, t1.*, t2.*       " + Var.CR +
            "--  INTO #AttrChild FROM #AttrParser t1                                              " + Var.CR +
            "--  RIGHT JOIN #EntityParent t2 ON t2.EnChildID = t1.Attr_EntityID AND t1.Attr_Brief IS NOT NULL --1716 Расчетный документ " + Var.CR + 
            "--UPDATE #AttrChild SET Pos = Pos - 1                                                " + Var.CR +   
            "--=====================================================================              " + Var.CR +
            "                                                                                     " + Var.CR +
            "--=====================================================================              " + Var.CR +
            "--Результат 5 таблиц. #AttrParser не используем, поэтому 4.                          " + Var.CR +
            "SELECT * FROM #EntityParser     ORDER BY Pos                                         " + Var.CR +
            "SELECT * FROM #AttrParent       ORDER BY Pos                                         " + Var.CR +
            "SELECT * FROM dbo.fbaEntity      ORDER BY ID                                         " + Var.CR +
            "SELECT * FROM dbo.fbaAttribute   ORDER BY ID                                         " + Var.CR +
            "SELECT * FROM dbo.fbaTable       ORDER BY ID                                         " + Var.CR +
            "--=====================================================================              " + Var.CR;
            return SQL;
                        
            /*   
            con.SelectDT("SELECT * FROM fbaEntityParser", out DTArEntity);
                
            const string SQL = "SELECT " +
                "Pos, ID, EntityID, Attr_EntityID, Attr_Name, Attr_Brief, " +   
                "(case when Attr_Type = 1 then 'Field' " +
                "      when Attr_Type = 2 then 'Link'  " +
                "      when Attr_Type = 3 then 'UniLink' " +
                "      when Attr_Type = 4 then 'Array' " +
                "      else Attr_Type   " +
                "  end) Attr_Type,      " +           
                "(case when Attr_Kind = 1 then 'Simple' " +
                "      when Attr_Kind = 2 then 'System' " +
                "      when Attr_Kind = 3 then 'Calc'   " +
                "      else Attr_Kind   " +
                "  end) Attr_Kind,      " +
                "Attr_Mask, Attr_Feature, Attr_NameOrder, Attr_Code, Attr_Comment, Table_ID, Table_Field, Table_Field2, " +
                "Ref_EntityID, Ref_AttrID, Table_Name, Table_IDFieldName, " +                   
                "(case when Table_Type = 1 then 'Main' " +
                "      when Table_Type = 2 then 'Hist'  " +                                
                "      else Table_Type   " +
                "  end) Table_Type,      " +                                                  
                "Table_Feature,                    " +
                "Ref_EntityBrief, Ref_AttrBrief, Ref_AttrName, Attr_EntityBrief, EnChildID, EnBrief2, EnID,             " +
                "EnBrief1, ParentID, EnBriefName2, EnBriefName1, EnBrief2_TableName, EnBrief2_TAbleIDFieldName, EnBrief1_TableName, EnBrief1_TAbleIDFieldName " +
                "FROM fbaAttrParent";
               */
        //}
        
        ///Скопировать таблицу из локальной базы на сервер.
        private bool CopyTableToLocal(System.Data.DataTable dt, string tableName, ref string resultInfo, ref int countTables)
        {
            sys.DataTableView(dt, tableName, tableName);
            string sql = sys.GetTextTableToDatabase(ServerType.SQLite, tableName, dt, true);             
            if (!Var.conLite.Exec(sql)) return false;
            resultInfo = resultInfo + "Таблица " + tableName + " сохранена в локальной базе данных SQLite" + Var.CR;
            countTables++;
            return true;
        }
        
        //Создать таблицы парсера
        //private bool CreateParserLocalTables()
        //{        	        	       
        //	string sql = "";
        //	int lineCount = 0;
        //	if (Var.con.serverTypeRemote == ServerType.MSSQL)
        //	{
        //		if (!sys.FileReadText(sys.PathSettings + "ParserPrepareMSSQL.txt", true, out sql, out lineCount)) return false;         	
        //	}
        //	
        //	if (Var.con.serverTypeRemote == ServerType.SQLite)
        //	{
        //		if (!sys.FileReadText(sys.PathSettings + "ParserPrepareSQLite.txt", true, out sql, out lineCount)) return false;         	
        //	}        	        	                   
                         
         //   var DS = new System.Data.DataSet();
         //   if (!sys.SelectDS(DirectionQuery.Remote, sql, out DS)) return false;
         //   sys.SM("Таблицы для парсера MSQL созданы!", MessageType.Information);
            //Скопировать таблицы из локальной базы на сервер.
            //if (Var.con.serverTypeRemote == ServerType.MSSQL)
        	//{
            //    string ResultInfo = "";
	        //    int CountTables = 0;               
	        //    if (!CopyTableToLocal(DS.Tables[0], "fbaEntityParser", ref ResultInfo, ref CountTables)) return false;
	        //    if (!CopyTableToLocal(DS.Tables[1], "fbaAttrParent",   ref ResultInfo, ref CountTables)) return false;                                                                    
	            //if (CountTables != 5)              
	            //    sys.SM("При копировании таблиц возникли ошибки:" + Var.CR + ResultInfo);
	            //else sys.SM("Копирование таблиц успешно завершено:" + Var.CR + ResultInfo, MessageType.Information);
            //}
       //     return true; //(CountTables == 5);
       // }
        
        ///Копирование таблиц на удаленный сервер.
        private void CopyTableToRemoteServer(bool onlyParser = false)
        {               
            string sql = "SELECT Name FROM sqlite_master WHERE type = 'table' ";
            if (onlyParser) sql = sql + " and Name in ('fbaEntityParser','fbaAttrParent') ";
            System.Data.DataTable dt;
            sys.SelectDT(DirectionQuery.Local, sql, out dt);
            int CountTables = 0;
            string ResultInfo = "";
            for (int i = 0; i < dt.Rows.Count; i++) 
            {               
                string tableName = dt.Value(i, "Name");
                sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[" + tableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) " + Var.CR +
                      "drop table [dbo].[" + tableName + "] ";
                                       
                if (!sys.Exec(DirectionQuery.Remote, sql)) return;                               
                System.Data.DataTable dt2;
                sql = "SELECT * FROM " + tableName;
                sys.SelectDT(DirectionQuery.Local, sql, out dt2);
               
                //Способ Var.con.MSSQLCopyTableToServer работает быстрее для MSSQL, чем sys.GetTextTableToDatabase.
                if (Var.con.MSSQLCopyTableToServer(dt2, tableName)) 
                {
                    ResultInfo = ResultInfo + "Таблица " + tableName + " сохранена в удаленной базе данных" + Var.CR;
                    CountTables++;
                }
            }
            if (CountTables != dt.Rows.Count)              
                sys.SM("При копировании таблиц возникли ошибки:" + Var.CR + ResultInfo);
            else sys.SM("Копирование таблиц успешно завершено:" + Var.CR + ResultInfo, MessageType.Information);          
       }     
        ///Создание таблиц для парсера.
        private void cmMenuN_1_Click(object sender, EventArgs e)
        {
             sys.CreateParserLocalTables();
        }
                        
        ///Копирование таблиц парсера из локальной БД на на удаленную БД.
        private void cmMenuN_2_Click(object sender, EventArgs e)
        {
            CopyTableToRemoteServer(true);
        }
        
        ///Копирование ВСЕХ таблиц с локальной БД на на удаленную БД.
        private void cmMenuN_3_Click(object sender, EventArgs e)
        {
           CopyTableToRemoteServer(false);
        }                      
	}
}
