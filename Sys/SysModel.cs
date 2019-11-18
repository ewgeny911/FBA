/*
 * Created by SharpDevelop.
 * User: Evgeniy.Travin
 * Date: 03.10.2019
 * Time: 9:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Net;
using System.Diagnostics;


namespace FBA
{
	/// <summary>
	/// Методы работы со словарной системой.
	/// </summary>
	public static partial class sys
    {	      
        ///Получить ИД Сущности по сокращению.
        public static string GetEntityID(string EntityBrief)
        {
            string EntityID = sys.GetValue(DirectionQuery.Remote, "SELECT ID FROM fbaEntity WHERE Brief = '" + EntityBrief + "';");
            if (EntityID == "")
            {
                sys.SM("Не найдена сущность с сокращением " + EntityBrief);
                return "0";
            }
            return EntityID;
        }

        ///Получить сокращение сущности по ИД.
        public static string GetEntityBrief(string EntityID)
        {
            if (!EntityID.IsIntegerStr()) return "";
            return sys.GetValue(DirectionQuery.Remote, "SELECT Brief FROM fbaEntity WHERE ID = '" + EntityID + "';");
        }

        ///Получить имя сущности по ИД или сокращению сущности.
        public static string GetEntityName(string EntityID = "", string EntityBrief = "")
        {
            //Получить имя сущности по ИД.
            if (EntityID.IsIntegerStr())
                return sys.GetValue(DirectionQuery.Remote, "SELECT Name FROM fbaEntity WHERE ID = '" + EntityID + "';");

            //Получить Имя Сущности по Сокращению.
            return sys.GetValue(DirectionQuery.Remote, "SELECT Name FROM fbaEntity WHERE Brief = '" + EntityBrief + "';");
        }

        ///Получить ИДОбъекта первого предка сущности.
        public static string GetFirstParentID(string EntityID = "", string EntityBrief = "")
        {
            //Получить имя сущности по ИД.
            if (EntityID.IsIntegerStr())
                return sys.GetValue(DirectionQuery.Remote, "SELECT ParentID FROM fbaEntity WHERE ID = '" + EntityID + "';");

            //Получить имя сущности по сокращению.
            return sys.GetValue(DirectionQuery.Remote, "SELECT ParentID FROM fbaEntity WHERE Brief = '" + EntityBrief + "';");
        }
        
        ///Получить ИД атрибута по сокращению.
        public static string GetAttrID(string EntityID, string AttrBrief)
        {
            if (!EntityID.IsIntegerStr()) return "";
            return sys.GetValue(DirectionQuery.Remote, "SELECT ID FROM fbaAttribute WHERE AttributeEntityID = " + EntityID + " AND Brief = '" + AttrBrief + "';");
        }

        ///Получить сокращение атрибута по ИД.
        public static string GetAttrBrief(string AttrID)
        {
            if (!AttrID.IsIntegerStr()) return "";
            return sys.GetValue(DirectionQuery.Remote, "SELECT Brief FROM fbaAttribute WHERE ID = '" + AttrID + "';");
        }

        ///Получить имя атрибута по ИД.
        public static string GetAttrName(string AttrID)
        {
            if (!AttrID.IsIntegerStr()) return "";
            return sys.GetValue(DirectionQuery.Remote, "SELECT Name FROM fbaAttribute WHERE ID = '" + AttrID + "';");
        }

        ///Получить ИД таблицы по Имени.
        public static string GetTableID(string TableName)
        {
            return sys.GetValue(DirectionQuery.Remote, "SELECT ID FROM fbaTable WHERE Name = '" + TableName + "';");
        }

        ///Получить имя таблицы по её ИД.
        public static string GetTableName(string TableID)
        {
            if (!TableID.IsIntegerStr()) return "";
            return sys.GetValue(DirectionQuery.Remote, "SELECT Name FROM fbaTable WHERE ID = '" + TableID + "';");
        }
		        
        ///Получить ИД статуса по его имени.
        public static string GetStatusID(string StatusName)
        {
            string StatusID = sys.GetValue(DirectionQuery.Remote, string.Format("SELECT ID FROM fbaStatus WHERE Name = '{0}'", StatusName));
            if (StatusID == "")
            {
                sys.SM("Не найден статус с именем " + StatusName);
                return "0";
            }
            return StatusID;
        }

        ///Получить имя главной таблицы сущности.
        /// string EntityID;
		///	string Table_Name;
		///	string IDFieldName;
		///	string Table_Type;
		///	string NumLevel;
		///	if (!sys.GetEntityTableMain(EntityBriefRel, out EntityID, out Table_Name, out IDFieldName, out Table_Type, out NumLevel)) return false;
        public static bool GetEntityTableMain(string EntityBrief, 
                                              out string EntityID, 
                                              out string Table_Name, 
                                              out string IDFieldName, 
                                              out string Table_Type, 
                                              out string NumLevel)
        {				                    	          
        	EntityID    = "";
        	Table_Name  = "";
			IDFieldName = "";
			Table_Type  = "";
			NumLevel    = "";
        	for (int j = 0; j < ParserData.ArAttrParentY; j++)
            {
                if (ParserData.ArAttrParent[j, ParserData.aEnBrief2] != EntityBrief) continue;
                EntityID    = ParserData.ArAttrParent[j, ParserData.aEntityID];
                IDFieldName = ParserData.ArAttrParent[j, ParserData.aTable_IDFieldName];
                Table_Name  = ParserData.ArAttrParent[j, ParserData.aTable_Name];
                Table_Type  = ParserData.ArAttrParent[j, ParserData.aTable_Type];
                NumLevel    = ParserData.ArAttrParent[j, ParserData.aNumLevel];
                return true;
            }
            return false;
        }
        
        ///Получить список полей таблицы TableName.
        public static bool GetTableFields(string TableName, out System.Data.DataTable DT)
        {
            DT = new System.Data.DataTable();
            string sql = "";
            if (Var.con.serverTypeRemote == ServerType.SQLite)
            {
                sql = "pragma table_info('" + TableName + "')";
                if (!sys.SelectDT(DirectionQuery.Remote, sql, out DT)) return false;
                //sys.DTView(DT, "DT1", "DT1");
                DT.Columns.RemoveAt(5);
                DT.Columns.RemoveAt(4);
                DT.Columns.RemoveAt(3);
                DT.Columns.RemoveAt(2);
                DT.Columns.RemoveAt(0);
                //sys.DTView(DT, "DT2", "DT2");
                var dataView = new DataView(DT);
                dataView.Sort = "Name ASC";
            }
            if (Var.con.serverTypeRemote == ServerType.MSSQL)
            {
                sql = "SELECT COLUMN_NAME AS Name FROM information_schema.columns WHERE table_name = '" + TableName + "'";
                if (!sys.SelectDT(DirectionQuery.Remote, sql, out DT)) return false;
            }

            if (Var.con.serverTypeRemote == ServerType.Postgre)
            {
                sql = "SELECT table_name, column_name from information_schema.columns WHERE table_schema = 'public' and table_name = '" + TableName + "'";
                if (!sys.SelectDT(DirectionQuery.Remote, sql, out DT)) return false;
            }
            return true;
        }

        ///Получить сокращение сущности, на которую ссылается атрибут Attr сущности EntityBrief.
        public static string GetEntityBriefLink(string EntityBrief, string Attr)
        {
            for (int j = 0; j < ParserData.ArAttrParentY; j++)
            {
                if (ParserData.ArAttrParent[j, ParserData.aEnBrief2] != EntityBrief) continue;
                if (ParserData.ArAttrParent[j, ParserData.aAttr_Brief] != Attr) continue;
                if (ParserData.ArAttrParent[j, ParserData.aTable_Type] == "2") continue;
                if (ParserData.ArAttrParent[j, ParserData.aAttr_Kind] == "3") continue;
                if (ParserData.ArAttrParent[j, ParserData.aAttr_Type] == "4") continue;
                return ParserData.ArAttrParent[j, ParserData.aRef_EntityBrief];
            }
            return "";
        }

        ///Получить наименование главной таблицы и наименование ключевого поля этой таблицы сущности EntityBrief.
        public static void GetMainTableNameByEnBrief(string EntityBrief, out string TableName, out string IDFieldName)
        {
            var DT = new System.Data.DataTable();
            string SQL = "SELECT t1.Name, t1.IDFieldName FROM fbaTable t1 INNER JOIN fbaEntity t2 ON t1.TableEntityID = t2.ID " +
                         "WHERE t2.Brief = '" + EntityBrief + "' AND t1.Type = 1";
            sys.SelectDT(DirectionQuery.Remote, SQL, out DT);
            TableName = DT.Value("Name");
            IDFieldName = DT.Value("IDFieldName");
        }

        ///Получить наименование главной таблицы и наименование ключевого поля этой таблицы сущности EntityBrief.
        public static void GetMainTableNameByEnID(string EntityID, out string TableName, out string IDFieldName)
        {
            var dt = new System.Data.DataTable();
            string sql = "SELECT t1.Name, t1.IDFieldName FROM fbaTable t1 INNER JOIN fbaEntity t2 ON t1.TableEntityID = t2.ID " +
                         "WHERE t2.ID = '" + EntityID + "' AND t1.Type = 1";
            sys.SelectDT(DirectionQuery.Remote, sql, out dt);
            TableName = dt.Value("Name");
            IDFieldName = dt.Value("IDFieldName");
        }   

		/// <summary>
        /// Создать таблицы парсера.
        /// Всего есть три таблицы модели данных: 
        /// fbaEntity - все сущности.
        /// fbaAttribute - все атрибуты всех сущностей.
        /// fbaEntity - все таблицы всех сущностей.
        /// Но для работы парсера не очень удобно использовать эти три таблицы. Было бы удобнее, если бы вся информация была собрана в одной, или двух таблицах.
        /// В этом случае снижается сложность парсера и увеличивается скорость работы. Поэтому процедура ниже берёт эти три таблицы и на основе них создает две других таблицы,
        /// которые были бы удобнее для парсера. Парсер работает на этих таблицах. Это таблицы: fbaAttrParent, fbaEntityParser.
        /// В таблице fbaAttrParent есть вся информация по атрибутам и по таблицам с учетом вложенности сущностей в друг друга.
        /// Количество строк больше чем в fbaAttribute.
        /// Таблица fbaEntityParser - это по сути та-же самая fbaEntity, но добавлены столбца в которых проставлено имя главной таблицы парсера и другая информация по главной таблице. Количество строк такое-же как и в fbaEntity.         
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public static bool CreateParserLocalTables()
        {        	        	       
        	string sql = "";
        	int lineCount = 0;
        	string fileName = "";        	
        	if (Var.con.serverTypeRemote == ServerType.MSSQL)  fileName = "ParserPrepareMSSQL.txt";
        	if (Var.con.serverTypeRemote == ServerType.SQLite) fileName = "ParserPrepareSQLite.txt";
        	if (fileName == "")
        	{
        		sys.SM("Тип сервера " + Var.con.serverTypeRemote.ToString() + " не поддерживается!", MessageType.Error);
        		return false;
        	}        	     
        	if (!FBAFile.FileReadText(FBAPath.PathSettings + fileName, true, out sql, out lineCount)) return false;         	        	             	        	                                         
            var DS = new System.Data.DataSet();
            if (!sys.SelectDS(DirectionQuery.Remote, sql, out DS)) return false;
            sys.SM("Таблицы для парсера MSQL созданы!", MessageType.Information);        
            return true; 
        }

        /// <summary>
        /// Преобразование кода MSQL в SQL.
        /// </summary>
        /// <param name="MSQL"></param>
        /// <returns>Код SQL</returns>
        public static string Parse(string MSQL)
        {        		        
        	//Инициализация парсера
        	if (!ParserData.IsInitial)
            {        		
        		string sql = ParserData.GetSQLInitial();
	            var DS = new System.Data.DataSet();                                
	            string ErrorText;
	            const bool ErrorShow = true;
	            if (!sys.SelectDS(DirectionQuery.Remote, sql, out DS, out ErrorText, ErrorShow)) return "";
	            ParserData.ParserInitialFromDS(DS); 
        	} 
        	var parser = new Parser();  
            return parser.Parse(MSQL, "Sys");            
        }
        
        ///Вызов 1. Вызвать метод MethodName с параметрами из DLL, Form, FormMain.
        ///На выходе Object.
        public static object CallO(string projectName, string MethodName, params Object[] ObjParams)
        {
            //Метод работает с объектми, как на вход, так и на выход.
            //Вызовы 1-4 - различные вариации вызова методов из модулей.  
            Assembly assembly = ProjectService.ProjectLoad(projectName, Var.enterMode);
            Type type = assembly.GetType("FBA." + projectName);
            Object obj = assembly.CreateInstance("FBA." + projectName);
            MethodInfo mi = type.GetMethod(MethodName);
            return mi.Invoke(obj, ObjParams);
        }

        ///Вызов 2. Вызвать метод MethodName с параметрами из DLL, Form, FormMain.
        ///На выходе Object.ToString();
        public static string CallS(string projectName, string MethodName, params Object[] ObjParams)
        {
            return CallO(projectName, MethodName, ObjParams).ToString();
        }

        ///Вызов 3. Вызвать метод MethodName с параметрами из DLL, Form, FormMain.
        public static object CallFO(Object form, string MethodName, params Object[] ObjParams)
        {
            Type type = form.GetType();
            MethodInfo mi = type.GetMethod(MethodName);
            return mi.Invoke(form, ObjParams);
        }

        ///Вызов 4. Вызвать метод MethodName с параметрами из DLL, Form, FormMain.
        public static string CallFS(Object form, string MethodName, params Object[] ObjParams)
        {
            return CallFO(form, MethodName, ObjParams).ToString();
        }      
                             
	}
}
