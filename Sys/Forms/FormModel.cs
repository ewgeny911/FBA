
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 23.09.2017
 * Время: 10:25
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data; 
 /*
    Показывать атрибуты - собственные 
    Показывать атрибуты - унаследованные
    Показывать атрибуты - поля
    Показывать атрибуты - ссылки
    Показывать атрибуты - универсальные ссылки
    Показывать атрибуты - массивы связанных объектов
    Показывать атрибуты - из базы данных
    Показывать атрибуты - системные
    Показывать атрибуты - вычисляемые на MSQL
    Показывать атрибуты - неисторичные
    Показывать атрибуты - историчные
    Показывать атрибуты - входящие в наименование объекта
    Показывать атрибуты - ключевые
    Показывать атрибуты - обязательные
    Показывать атрибуты - запрещенные к выводу в гибких таблицах
    Системная                                   = 1 бит 1
    Объект учета                                = 2 бит 2
    Древовидная                                 = 3 бит 4
    Разделена по филиалам                       = 4 бит 8
    Использовать счетчик универсальных ссылок   = 5 бит 32
    Содержит протокольную информацию            = 6 бит 64
 
    Attr_Type = 1 - (Поле)        Поле
    Attr_Type = 2 - (Ссылка)      Ссылка
    Attr_Type = 3 - (УниСсылка)   Универсальная ссылка
    Attr_Type = 4 - (Массив)      Массив
    
    Attr_Kind = 1 - (Простой)     Атрибут из базы данных
    Attr_Kind = 2 - (Системный)   Системный
    Attr_Kind = 3 - (Вычисляемый) Вычисляемый
*/  
namespace FBA
{            
	/// <summary>
	/// Форма в которой можно менять модель данных
	/// </summary>
	public partial class FormModel : FormFBA
    {
        #region Region. Переменные и конструктор.
                 
        /// <summary>
    	/// Конструктор. Установка MdiParent, Icon, обновление дерева сущностей.
    	/// </summary>
        public FormModel()
        {            
            InitializeComponent();
            this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;            
            CompEntityTreeFBA1.LoadEntityTree(); 
            CompEntityTreeFBA1.SelectInOneClick = true;    
        } 
        
        #endregion Region. Переменные и конструктор.
        
        private string GetSQLCode(string typeQuery)
        {	                
        	string sqlAttr =
				"--Таблица #EntityParent с деревом сущностей. " + Var.CR +                            
				";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS   " + Var.CR +
				"      (                                                                   " + Var.CR +
				"        SELECT                                                            " + Var.CR +
				"          ID AS EnChildID,                                                " + Var.CR +
				"          Brief AS EnBrief2,                                              " + Var.CR +
				"          ID as EnID,                                                     " + Var.CR +
				"          Brief as EnBrief1,                                              " + Var.CR +
				"          ParentID,                                                       " + Var.CR +
				"          Name as EnBriefName2,                                           " + Var.CR +
				"          Name as EnBriefName1                                            " + Var.CR +
				"        FROM fbaEntity                                                    " + Var.CR +
				"        UNION ALL                                                         " + Var.CR +
				"        SELECT                                                            " + Var.CR +
				"          EnChildID,                                                      " + Var.CR +
				"          EnBrief2,                                                       " + Var.CR +
				"          e.ID as EnID,                                                   " + Var.CR +
				"          e.Brief as EnBrief1,                                            " + Var.CR +
				"          e.ParentID,                                                     " + Var.CR +
				"          p.EnBriefName2 as EnBriefName2,                                 " + Var.CR +
				"          e.Name as EnBriefName1                                          " + Var.CR +
				"        FROM fbaEntity e INNER JOIN Parents p ON p.ParentID = e.ID        " + Var.CR +
				"      ) SELECT                                                            " + Var.CR +
				"        --t1.*, t2.*, t3.Name as TableName, t4.Brief as 'Attr Link'       " + Var.CR + 
				"        t2.ID     AS 'ID',   											   " + Var.CR +
				"        t2.Name   AS 'Name',                                              " + Var.CR +
				"        t2.Brief  AS 'Brief',                                             " + Var.CR +
				"        (CASE WHEN t2.Type = 1 THEN 'Field'                               " + Var.CR +
				"              WHEN t2.Type = 2 THEN 'Link'                                " + Var.CR +
				"              WHEN t2.Type = 3 THEN 'UniLink'                             " + Var.CR +
				"              WHEN t2.Type = 4 THEN 'Array'                               " + Var.CR + 
				"              ELSE 'Unknown' END) AS 'Attr Type',                         " + Var.CR +
				"        (CASE WHEN t2.Kind = 1 THEN 'DataBase'                            " + Var.CR +
				"              WHEN t2.Kind = 2 THEN 'Sys'                                 " + Var.CR +
				"              WHEN t2.Kind = 3 THEN 'Calc'                                " + Var.CR +
				"               ELSE 'Unknown' END) AS 'Attr Kind',                        " + Var.CR +
				"        t2.Mask   AS 'Mask',                                              " + Var.CR +
				"        t4.Brief  AS 'Link',                                              " + Var.CR +
				"        t3.Name   AS 'Table',                                             " + Var.CR +
				"        t2.FieldName  AS 'Field1',                                        " + Var.CR +
				"        t2.FieldName2 AS 'Field2',                                        " + Var.CR +
				"        (CASE WHEN t3.Type = 1 THEN 'Main'                                " + Var.CR +
				"              WHEN t3.Type = 2 THEN 'Hist'                                " + Var.CR +
				"        ELSE 'Unknown' END) AS 'Table Type',                              " + Var.CR +        
				"        t1.EnBriefName1 AS 'Entity',                                      " + Var.CR +
				"        t2.ObjectNameOrder AS 'Order in name'                             " + Var.CR +
				"FROM Parents t1                                                           " + Var.CR +
				"        LEFT JOIN fbaAttribute   t2 ON t1.EnID    = t2.AttributeEntityID  " + Var.CR +
				"        LEFT JOIN fbaEntity t4 ON t4.ID = t2.RefEntityID                  " + Var.CR + 
				"         LEFT JOIN fbaTable  t3 ON t3.ID = t2.TableID                     " + Var.CR +
				"        WHERE t1.EnChildID = 1694 AND 1=1                                 " + Var.CR +
				"        AND t2.ID IS NOT NULL                                             " + Var.CR +
					"ORDER BY EnBrief2, EnBrief1;                                          " + Var.CR;
        
		
				string sqlTable =
			    "--Таблица в которой собраны все таблицы сущности, в том числе и предков.   " + Var.CR +
				";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS " + Var.CR +   
				"      (                                                                   " + Var.CR +                                                                   
				"        SELECT                                                            " + Var.CR +  
				"          ID AS EnChildID,                                                " + Var.CR +                                                
				"          Brief AS EnBrief2,                                              " + Var.CR +                                              
				"          ID as EnID,                                                     " + Var.CR +                                                     
				"          Brief as EnBrief1,                                              " + Var.CR +                                             
				"          ParentID,                                                       " + Var.CR +                                         
				"          Name as EnBriefName2,                                           " + Var.CR + 
				"          Name as EnBriefName1                                            " + Var.CR + 
				"        FROM fbaEntity                                                    " + Var.CR + 
				"        UNION ALL                                                         " + Var.CR + 
				"        SELECT                                                            " + Var.CR + 
				"          EnChildID,                                                      " + Var.CR + 
				"          EnBrief2,                                                       " + Var.CR + 
				"          e.ID as EnID,                                                   " + Var.CR + 
				"          e.Brief as EnBrief1,                                            " + Var.CR + 
				"          e.ParentID,                                                     " + Var.CR + 
				"          p.EnBriefName2 as EnBriefName2,                                 " + Var.CR + 
				"          e.Name as EnBriefName1                                          " + Var.CR + 
				"        FROM fbaEntity e INNER JOIN Parents p ON p.ParentID = e.ID        " + Var.CR + 
				"      ) SELECT                                                            " + Var.CR + 
				"        t2.ID AS 'ID',                                                    " + Var.CR + 
				"        t2.Name   AS 'Name',                                              " + Var.CR +     
				"        (CASE WHEN t2.Type = 1 THEN 'Main' ELSE 'Hist' END) AS 'Type',    " + Var.CR + 
				"        t2.IDFieldName AS 'Field ID',                                     " + Var.CR + 
				"        t1.EnBriefName1 AS 'Entity'                                       " + Var.CR + 
				"FROM Parents t1                                                           " + Var.CR + 
				"        LEFT JOIN fbaTable  t2 ON t2.TableEntityID = t1.EnID              " + Var.CR + 
				"        WHERE t1.EnChildID = 1694 AND 1=1                                 " + Var.CR + 
				"        AND t2.ID IS NOT NULL                                             " + Var.CR + 
		        "ORDER BY EnBrief2, EnBrief1;                                              ";
				if (typeQuery == "sqlAttr") return sqlAttr;
				if (typeQuery == "sqlTable") return sqlTable;
				return "";
        }						                      
        
        /// <summary>
        /// При выборе вкладки, чтобы не загружать все данные. Для ускорения показа данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void TabControlAttrSelectedIndexChanged(object sender, EventArgs e)
		{
			ShowData();
		}		
		
	    /// <summary>
		/// При выборе сущности в дереве сущностей.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void CompEntityTreeFBA1_SelectedEntity(object sender, SelectEntityEventArgs e)
        {
        	ShowData();
        }        
                     
        /// <summary>
        /// Показ даных в зависимости от выбранной вкладки.
        /// </summary>
        private void ShowData()
        {
        	tbEntity.Text = "ID: " + CompEntityTreeFBA1.EntityID + ", Name: " + CompEntityTreeFBA1.EntityName + ", Brief: " + sys.GetEntityBrief(CompEntityTreeFBA1.EntityID);
        	if (tabControlAttr.SelectedIndex == 0) LoadAttrList(CompEntityTreeFBA1.EntityID);
            if (tabControlAttr.SelectedIndex == 1) LoadTableList(CompEntityTreeFBA1.EntityID);          
            if (tabControlAttr.SelectedIndex == 2) LoadMethodList(CompEntityTreeFBA1.EntityID);
        }
     
        /// <summary>
        /// Контекстное меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClick(object sender, EventArgs e)
        {        	
        	Operation operation = Operation.NotAssigned;   
        	if (sender == cmModel_N1) operation = Operation.Add;                                                                                                         
            if (sender == cmModel_N2) operation = Operation.Edit;
            if (sender == cmModel_N3) operation = Operation.Del; 
            if (sender == cmModel_N4) operation = Operation.Refresh; 
            //Обновить таблицы парсера.
            if (sender == cmModel_N5) 
            {
            	sys.CreateParserLocalTables();
            	return;
            }
            
            if (operation == Operation.NotAssigned) return;
                                              
            //Компонент на котором повешено контекстное меню.
            string componentStrip = sys.GetControlNameByMenuStripItem(sender);                                                                         
            string objID;                                                       
            string entityID = CompEntityTreeFBA1.EntityID;           
            string entityBrief = sys.GetEntityBrief(entityID);
            if (operation == Operation.Refresh)
            {
                if (componentStrip == "dgvAttr")   LoadAttrList(CompEntityTreeFBA1.EntityID);
             	if (componentStrip == "dgvTable")  LoadTableList(CompEntityTreeFBA1.EntityID);
             	if (componentStrip == "dgvMethod") LoadMethodList(CompEntityTreeFBA1.EntityID);
             	return;
            }                      
            
            //Атрибут.
            if (componentStrip == "dgvAttr")
            {                            
            	objID            = dgvAttr.Value("ID");
                string AttrBrief = dgvAttr.Value("Brief");
                string AttrName  = dgvAttr.Value("Name");              
                if (sender == cmModel_N4) LoadAttrList(entityID);                            
                var f1 = new FormAttr(operation, entityID, objID, AttrBrief, AttrName);
                f1.Icon = this.Icon;
                if (f1.ShowDialog() ==  DialogResult.OK) 
                {
                	LoadAttrList(entityID);
                }
            }
            
            //Таблица.
            if (componentStrip == "dgvTable")
            {                                
                objID           = dgvTable.Value("ID");      
                string objName  = dgvTable.Value("Name");                                     
                if (sender == cmModel_N4) LoadTableList(entityID);                                                       
                var f1 = new FormTable(operation, objID, objName, entityID);
                f1.Icon = this.Icon; 
                if (f1.ShowDialog() ==  DialogResult.OK) LoadTableList(entityID);
            }
            
            //Метод.
            if (componentStrip == "dgvMethod")
            {                                
                string methodID    = dgvMethod.Value("ID"); 		
				string action      = dgvMethod.Value("Action"); 
				string methodBrief = dgvMethod.Value("Brief"); 
				string methodValue = dgvMethod.Value("Value"); 
				string comment     = dgvMethod.Value("Comment"); 	
				string sql = "";
            	if (operation == Operation.Del)				
            	{	if (methodID == "") return;
		            sql = "DELETE FROM fbaMethod WHERE ID = " + methodID;
		            if (!sys.Exec(DirectionQuery.Remote, sql)) return; 
		            LoadMethodList(entityID);                               
		            sys.SM("Метод удален!", MessageType.Information);
		            return;
            	}
            	            	            	
				string capForm = "";
				if (operation == Operation.Add)  capForm = "Add Entity Method";
				if (operation == Operation.Edit) capForm = "Edit Entity Method";
				if (operation == Operation.Del)  capForm = "Delete Entity Method";	

				string[] actionArr = {"INSERT", "DELETE", "UPDATE"};
				/*var frm = new FormValue5(cap,
				                         "Entity", "Action", "Brief", "Value", "Comment", 			                         			                   
				                         entityBrief, action, methodBrief, methodValue, comment,			                         			                        
				                         null, actionArr);   	
				frm.tbText1.ReadOnly = true;
				frm.tbText2.ReadOnly = true;
				if (frm.ShowDialog() != DialogResult.OK) return;
						
				entityBrief = frm.tbText1.Text;
				action      = frm.tbText2.Text;
				methodBrief = frm.tbText3.Text; 
				methodValue = frm.tbText4.Text;	
				comment     = frm.tbText5.Text;
				*/
				
				var arrvp = new ValueParam[5];  
				arrvp[0].captionValue = "Entity";
	        	arrvp[0].componentType = ComponentType.ComboBox;	
	        	arrvp[0].values       = null;
	        	arrvp[0].value        = entityBrief;
	        	arrvp[0].readOnly     = true;
	            	
	        	arrvp[1].captionValue = "Action";
				arrvp[1].componentType = ComponentType.ComboBox;	
	        	arrvp[1].values       = actionArr;
	        	arrvp[1].value        = action;
	        	arrvp[1].readOnly     = true;
	        	
	        	arrvp[2].captionValue = "Brief";
	        	arrvp[2].value        = methodBrief;
	        	
	        	arrvp[3].captionValue = "Value";
	        	arrvp[3].value        = methodValue;
	        	
	        	arrvp[4].captionValue = "Comment";
	        	arrvp[4].value        = comment;
	        	        		
	        	var frm = new FormValue(capForm, arrvp);
	            if (frm.ShowDialog() != DialogResult.OK) return;
	            entityBrief = frm.GetValue(0);
	            action      = frm.GetValue(1);
	            methodBrief = frm.GetValue(2);
	            methodValue = frm.GetValue(3);
	            comment     = frm.GetValue(4);          
					
				
				if (operation == Operation.Add)
				{
					sql = "INSERT INTO fbaMethod (" +
	                         "UserCreateID, DateCreate, EntityRef, Action, Brief, Value, Comment) VALUES (" + 
	                         Var.UserID  + ", " + sys.DateTimeCurrent() + "," + entityID + ",'" + action + "', '" + methodBrief + "', '" + methodValue + "', '" + comment + "')" ;
	            	if (!sys.Exec(DirectionQuery.Remote, sql)) return; 
	            	sys.SM("Метод добавлен!", MessageType.Information);
				}
	            if (operation == Operation.Edit)
				{
	            	sql = "UPDATE fbaMethod SET " +
	            		  "UserChangeID = " + Var.UserID  + 
	            		  ",DateChange  = " + sys.DateTimeCurrent() +
	            	      ",EntityRef   = " + entityID +
	            	      ",Action      = '" + action + "'" +
	            	      ",Brief       = '" + methodBrief + "'" +
	            	      ",Value       = '" + methodValue + "'" +
	            	      ",Comment     = '" + comment + "'" +
	            		  " WHERE ID = " + methodID;
	            	if (!sys.Exec(DirectionQuery.Remote, sql)) return; 
	            	sys.SM("Метод изменён!", MessageType.Information);
	            }
	            LoadMethodList(entityID);                      	          
            }                               
        }
                            
        /// <summary>
        /// Получение фильтра для отображения атрибутов.
        /// </summary>
        /// <returns>Фильтр для отображения атрибутов</returns>
        private string GetAttrWHERE()
        {
        	/*
            Показывать атрибуты - собственные                (EnChildID = EnID)
            Показывать атрибуты - унаследованные             (EnChildID != EnID)
            
            Показывать атрибуты - поля                       (Attr_Type = 1)
            Показывать атрибуты - ссылки                     (Attr_Type = 2)
            Показывать атрибуты - универсальные ссылки       (Attr_Type = 3)
            Показывать атрибуты - массивы связанных объектов (Attr_Type = 4)
            
            Показывать атрибуты - из базы данных             (Attr_Kind = 1)
            Показывать атрибуты - системные                  (Attr_Kind = 2)
            Показывать атрибуты - вычисляемые на MSQL        (Attr_Kind = 3)
            
            Показывать атрибуты - неисторичные               (Table_Type = 1)
            Показывать атрибуты - историчные                 (Table_Type = 2)
            
            Показывать атрибуты - входящие в наименование объекта (Attr_NameOrder <> '')
            Показывать атрибуты - ключевые
            Показывать атрибуты - обязательные
            Показывать атрибуты - запрещенные к выводу в гибких таблицах
            */
            string whereStr = "1=1 ";          
            if (!tsAttr_N1.Checked)  whereStr = whereStr + "AND NOT (EnChildID = EnID) ";
            if (!tsAttr_N2.Checked)  whereStr = whereStr + "AND NOT (EnChildID <> EnID) ";
            if (!tsAttr_N3.Checked)  whereStr = whereStr + "AND NOT (t2.Type = 1) ";                   
            if (!tsAttr_N4.Checked)  whereStr = whereStr + "AND NOT (t2.Type = 2) ";          
            if (!tsAttr_N5.Checked)  whereStr = whereStr + "AND NOT (t2.Type = 3) ";           
            if (!tsAttr_N6.Checked)  whereStr = whereStr + "AND NOT (t2.Type = 4) ";          
            if (!tsAttr_N7.Checked)  whereStr = whereStr + "AND NOT (t2.Kind = 1) ";           
            if (!tsAttr_N8.Checked)  whereStr = whereStr + "AND NOT (t2.Kind = 2) "; 
            if (!tsAttr_N9.Checked)  whereStr = whereStr + "AND NOT (t2.Kind = 3) ";           
            if (!tsAttr_N10.Checked) whereStr = whereStr + "AND NOT (t3.Type = 1) ";           
            if (!tsAttr_N11.Checked) whereStr = whereStr + "AND NOT (t3.Type = 2) "; 
            if (!tsAttr_N12.Checked) whereStr = whereStr + "AND NOT (t2.ObjectNameOrder <> '') ";
            return whereStr;
        }
              
        /// <summary>
        /// Получение фильтра для отображения таблиц.
        /// </summary>
        /// <returns>Фильтра для отображения таблиц</returns>
        private string GetTableWHERE()
        {
            /*
            Показывать собственные таблицы (EnChildID = EnID)
            Показывать унаследованные таблицы (EnChildID != EnID)
            Показывать обычные таблицы (Table_Type = 1)
            Показывать историчные таблицы (Table_Type = 2) 
            */
            string whereStr = "1=1 ";            
            if (!tsTable_N1.Checked)  whereStr = whereStr + "AND NOT (EnChildID = EnID) ";
            if (!tsTable_N2.Checked)  whereStr = whereStr + "AND NOT (EnChildID <> EnID) ";
            if (!tsTable_N3.Checked)  whereStr = whereStr + "AND NOT (t2.Type = 1) ";                   
            if (!tsTable_N4.Checked)  whereStr = whereStr + "AND NOT (t2.Type = 2) ";   
            return whereStr;
        }
        
        ///Загрузить список атрибутов.
        private void LoadAttrList(string entityRefID)
        {                        
            if (entityRefID == "") return;                       
            var dt = new System.Data.DataTable();                       
            string sql = GetSQLCode("sqlAttr");    
            sql = sql.Replace("1694", entityRefID);
            sql = sql.Replace("1=1", GetAttrWHERE());
            sys.SelectDT(DirectionQuery.Remote, sql, out dt);
            dgvAttr.DataSource = dt;
        }
               
        /// <summary>
        /// Загрузить список таблиц.
        /// </summary>
        /// <param name="EntityRefID"></param>
        private void LoadTableList(string EntityRefID)
        {
            if (EntityRefID == "") return;        
        	var dt = new System.Data.DataTable();
            string sql =  GetSQLCode("sqlTable"); //string.Join(Var.CR, this.QueryText);
            //string SQL = sys.GetSection(QueryTextStr, "Table");
            sql = sql.Replace("1694", EntityRefID);
            sql = sql.Replace("1=1", GetTableWHERE());
            sys.SelectDT(DirectionQuery.Remote, sql, out dt);
            dgvTable.DataSource = dt;
        }             
             
        /// <summary>
        /// Показ методов.
        /// </summary>
        /// <param name="entityRefID"></param>
        public bool LoadMethodList(string entityRefID)
        {              
        	if (string.IsNullOrEmpty(entityRefID)) return false;
        	string sql =
                    "SELECT t1.ID, " +
        		    "t2.Brief AS Entity," +
					"t1.Action," +         		
                    "t1.Brief, " +                                        
        		    "t1.Value, " +  
					"t1.Comment, " +         		
                    "t1.UserCreateID, " +                            	
                    "t1.DateCreate, " + 
					"t1.UserChangeID, " + 
					"t1.DateChange " +        		
                    "FROM fbaMethod t1 LEFT JOIN fbaEntity t2 ON t1.EntityRef = t2.ID AND t1.EntityRef = " + entityRefID;            
               if (!sys.SelectGV(DirectionQuery.Remote, sql, dgvMethod)) return false;
               return true;
        }
        
        ///При выборе кнопки фильтра в таблице атрибутов.
        private void TsAttr_N1_Click(object sender, EventArgs e)
        {
            LoadAttrList(CompEntityTreeFBA1.EntityID);
        }
        
        ///При выборе кнопки фильтра в таблице таблиц сущности.
        private void TsTable_N1_Click(object sender, EventArgs e)
        {
            LoadTableList(CompEntityTreeFBA1.EntityID); 
        }                       

        private void dgvTable_DoubleClick(object sender, EventArgs e)
        {
            string objID      = dgvTable.Value("ID");           
            string tableName  = dgvTable.Value("Name");
            var f1 = new FormTable(Operation.Edit, CompEntityTreeFBA1.EntityID, objID,  tableName);
            f1.Icon = this.Icon;
            if (f1.ShowDialog() == DialogResult.OK) LoadAttrList(CompEntityTreeFBA1.EntityID);
        }
        
        private void DgvAttr_DoubleClick(object sender, EventArgs e)
        {                                                   
            string objID     = dgvAttr.Value("ID");
            string attrBrief = dgvAttr.Value("Brief");
            string attrName  = dgvAttr.Value("Name");              
            var f1 = new FormAttr(Operation.Edit, CompEntityTreeFBA1.EntityID, objID, attrBrief, attrName);
            f1.Icon = this.Icon;
            if (f1.ShowDialog() ==  DialogResult.OK) LoadAttrList(CompEntityTreeFBA1.EntityID);                       
        }
        
        ///При выборе текста в таблице показываем его. 
		private void DgvMethodDoubleClick(object sender, EventArgs e)
		{
			AddClick(cmModel_N3, null);
		}
		
		//Установка ширины столбцов.
		private void SetWidthColumn()
		{
			//
		}
		
		private void CmModel_N5Click(object sender, EventArgs e)
		{
	
		}               
    }              
}
