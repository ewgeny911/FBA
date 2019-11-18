
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 17.12.2017
 * Время: 3:01
 */
 
using System;
using System.Windows.Forms;
namespace FBA
{                 
    /// <summary>
    /// Редактирование списка таблиц сущности.
    /// </summary>
    public partial class FormTable : FormFBA
    {
        /// <summary>
        /// Статус закрытия формы
        /// </summary>
    	public int StatusClose    = 0;
        private string TableEntityID;
        private Operation operation;
        private string ObjID;     
        private string ObjName;   
        private FBA.ObjectRef Obj;   
        
        /// <summary>
        /// Конструктор. Добавление таблицы к сущности
        /// </summary>
        /// <param name="operation">Add, Del, Edit</param>
        /// <param name="ObjID">ИД таблицы</param>
        /// <param name="ObjName">Наименование таблицы в БД</param>
        /// <param name="TableEntityID">ИД сущности, к которой относится таблица</param>
        public FormTable(Operation operation, string ObjID, string ObjName, string TableEntityID)
        {             
            InitializeComponent();                           
            this.TableEntityID = TableEntityID;      
            this.operation = operation; 
            if (operation == Operation.Add) ObjID = "0";             
            this.ObjID     = ObjID;       
            this.ObjName   = ObjName;                                                                                            
            if (operation == Operation.Del) SetShowOnly();             
            SetTextButtonOk(operation, btnOk);                      
          
        }       
               
        /// <summary>
        /// Заполнение свойств компонентов значениями.
        /// </summary>
        private void FillData()
        {                     
            Obj = new FBA.ObjectRef();            
            Obj.SetQueryTable(this, "Main1", "fbaTable", ObjID, "ID", "", DirectionQuery.Remote);          
            Obj.AddAttr("Main1.EntityID", "2");
            Obj.AddAttr("Main1.TableEntityID", TableEntityID); //Добавляем сразу значение.  
            Obj.AddAttr("Main1.Type");                                      
            Obj.Read();             
            if (Obj["Main1.Type"] != "") tbTypeStr.SelectedIndex = Obj["Main1.Type"].ToInt() - 1;
            else tbTypeStr.Text = "";                          
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            StatusClose = 2;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {          
            if (ErrorIfNullExists()) return;
            if (tbTypeStr.Text != "") Obj["Main1.Type"] = (tbTypeStr.SelectedIndex + 1).ToString();
            bool Result = false;
            if (operation == Operation.Del)      Result = OperationDelete();
            if (operation == Operation.Add)      Result = Obj.Write();           
            if (operation == Operation.Edit)     Result = Obj.Write();
            if (Result)
            {
                DialogResult = DialogResult.OK;
                StatusClose = 1;
            } else           
            {
                DialogResult = DialogResult.Cancel;
                StatusClose = 2;            
            }
            Close();
        }
                  
        /// <summary>
        /// Проверка возможности удаления таблицы из БД.
        /// </summary>
        /// <returns></returns>
        private bool CheckDeleteTable()
        {                           
            //Проверка на атрибутам.
            string SQL = "SELECT Count(*) AS cnt FROM fbaAttribute WHERE ID = " + ObjID;           
            string AttrCount = sys.GetValue(DirectionQuery.Remote, SQL);
            if (AttrCount != "0") 
            {
                sys.SM("Ошибка. У таблицы есть атрибуты. Удаление невозможно.");
                return false;
            }
            if (Var.con.serverTypeRemote != ServerType.MSSQL) return true;
            
            //Проверка по таблицам в базе.
            var DT = new System.Data.DataTable();               
            string TableName = tbName.Text;                               
            string QueryTextStr = string.Join(Var.CR, this.QueryText);
            SQL = sys.GetSection(QueryTextStr, "TableDelete");
            SQL = SQL.Replace("TableNameAtt",  TableName);            
            sys.SelectDT(DirectionQuery.Remote, SQL, out DT);
            if (DT.Rows.Count != 0) 
            {
                sys.SM("Ошибка. На данную таблицу есть внешние ключи из других таблиц. Удаление невозможно.");
                sys.DataTableView(DT, "Список таблиц и полей, которые ссылаются на данную таблицу",  "Cсылающиеся таблицы и поля");
                return false;
            }
            return true;
        }
     
        /// <summary>
        /// Удаление таблицы.
        /// </summary>
        /// <returns></returns>
        private bool OperationDelete()
        {
            if (!sys.SM("Вы хотите действительно удалить таблицу?", MessageType.Question, "Удаление таблицу")) return false;            
            if (!CheckDeleteTable()) return false;   
            return Obj.DeleteObject("Main1");         
        }
                               
        /// <summary>
        /// Получить список таблиц для выбора.
        /// </summary>
        /// <returns></returns>
        private bool GetTableList()
        {
            string sql = "";            
            if (Var.con.serverTypeRemote == ServerType.SQLite)
                sql = "SELECT Name FROM sqlite_master WHERE type = 'table' AND Name NOT IN (SELECT Name FROM fbaTable) " +
            		  " AND Name NOT LIKE 'sqlite%' " + //Name NOT LIKE 'fba%' AND 
            		  "ORDER BY Name";
                       
            if (Var.con.serverTypeRemote == ServerType.MSSQL) 
                sql = "SELECT Table_Name AS Name FROM information_schema.tables WHERE Table_Name NOT IN (SELECT Name FROM fbaTable) " +
            		  //"AND Name NOT LIKE 'fba%' " +
            		  "ORDER BY Table_Name ";
            
            var dt = new System.Data.DataTable();
            if (!sys.SelectDT(DirectionQuery.Remote, sql, out dt)) return false; 
            string TempStr = tbName.Text;             
            tbName.SetDataSourse(dt);
            tbName.Text = TempStr;           
            return true;           
        }
               
        /// <summary>
        /// Список полей таблицы.
        /// </summary>
        private void FieldsForTable()
        {
            System.Data.DataTable dt;
            sys.GetTableFields(tbName.Text, out dt);
            string TempStr = tbIDFieldName.Text;                                
            tbIDFieldName.SetDataSourse(dt);                       
            tbIDFieldName.Text = TempStr;
        }                     
                   
        /// <summary>
        /// Интересно, если повесить FillData на конструктор, то текст (свойство текст) в 
        /// комбобоксах переписывается почему-то.. а на Shown нет. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTable_Shown(object sender, EventArgs e)
        {
            FillData(); 
            GetTableList();
            FieldsForTable();
        }
        
        /// <summary>
        /// Список полей таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void TbNameLeave(object sender, EventArgs e)
		{
			FieldsForTable();
		}
                
    }
}
