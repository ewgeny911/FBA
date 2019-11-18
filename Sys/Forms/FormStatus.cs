
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.01.2018
 * Время: 13:41
 */
 
using System;
using System.Data;
    
namespace FBA
{
	/// <summary>
	/// Форма на которой можно для каждой сущности (список Entity) 
    /// назначить список статусов, которые может иметь объект этой сущности (список Status),
    /// а также для каждого статуса сущности можно задать список статусов, 
    /// на которые пользователь может изменить выбранный статус (список Change).
    /// Привязок к ролям нет. 
	/// </summary>
    public partial class FormStatus : FormFBA
    {
        private DataTable DTEntity;  
        private DataTable DTParent;    
        private DataTable DTChange;
           
        /// <summary>
        /// Конструктор.
        /// </summary>
        public FormStatus()
        {            
            InitializeComponent();         
            this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;  
            LoadStatus();
        }                      
        
        /// <summary>
        /// Загрузка статусов.
        /// </summary>
        private void LoadStatus()
        {
            LoadStatusEntity();
            LoadStatusParent();
            LoadStatusChange();
        }
    
        /// <summary>
        /// Загрузка статусов. Сущности.
        /// </summary>
        private void LoadStatusEntity()
        {            
            const string sql = "SELECT t1.ID, t2.Brief FROM fbaStatusEntity t1 " +
                         "LEFT JOIN fbaEntity t2 ON t1.EntityRefID = t2.ID ORDER BY t2.Brief; ";
            sys.SelectDT(DirectionQuery.Remote, sql, out DTEntity);
            dgvEntity.DataSource = DTEntity;           
        }
             
        /// <summary>
        /// Загрузка статусов. Список возможных статусов.
        /// </summary>
        private void LoadStatusParent()
        {            
            string statusEntityID = dgvEntity.DataGridViewSelected("ID");
            if (statusEntityID == "") statusEntityID = "0";
            string sql = string.Format(
                "SELECT t1.ID, t2.Name FROM fbaStatusList t1 " +
                "LEFT JOIN fbaStatus t2 ON t1.StatusID = t2.ID " +                  
                "WHERE t1.StatusEntityID = '{0}' ORDER BY t2.Name;", statusEntityID);
            sys.SelectDT(DirectionQuery.Remote, sql, out DTParent);
            dgvParent.DataSource = DTParent;           
        }
              
        /// <summary>
        /// Загрузка статусов. Список возможных переходов, для каждого статуса сущности.
        /// </summary>
        private void LoadStatusChange()
        {                        
            string StatusListID = dgvParent.DataGridViewSelected("ID");
            if (StatusListID == "") StatusListID = "0";
            string sql = string.Format(
                "SELECT t1.ID, t2.Name FROM fbaStatusChange t1 " +
                "LEFT JOIN fbaStatus t2 ON t1.StatusID = t2.ID " +                 
                "WHERE StatusListID = {0} ORDER BY t2.Name; ", StatusListID);                            
            sys.SelectDT(DirectionQuery.Remote, sql, out DTChange);
            dgvChange.DataSource = DTChange;           
        }
              
        /// <summary>
        /// Все действия - события всех кнопок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts1_N1_Click(object sender, EventArgs e)
        {           
            if (sender == ts1_N1)  EntityAdd();
            if (sender == ts1_N2)  EntityDel();
        	if (sender == ts2_N1)  ParentAdd();
        	if (sender == ts2_N2)  ParentDel();
            if (sender == ts3_N1)  ChangeAdd();                     
            if (sender == ts3_N2)  ChangeDel();
        }
              
        /// <summary>
        /// Добавление сущности.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private bool EntityAdd()
        {           
            string entityID    = "";
            string entityBrief = "";
            string entityName  = "";
            if (!sys.InputEntity(false, ref entityID, ref entityBrief, ref entityName)) return false;           
            /*DataRow[] dt;
            dt = DTEntity.Select("Brief='" + EntityBrief + "'");
            if (dt.Length > 0)
            {
                sys.SM("Entity is already added!");
                return;
            }
            DataRow Row1 = DTEntity.NewRow();            
            Row1["Brief"] = EntityBrief; 
            DTEntity.Rows.Add(Row1);*/
            
            string sql = string.Format("INSERT INTO fbaStatusEntity (EntityID, EntityRefID) " +
                    "SELECT 233,{0} WHERE NOT EXISTS (SELECT EntityRefID FROM fbaStatusEntity WHERE EntityRefID = '{0}' LIMIT 1)", 
                    entityID);
            if (!sys.Exec(DirectionQuery.Local, sql)) return false;
            LoadStatus();
            return true;
        }
              
        /// <summary>
        /// Добавление статуса к сущности.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private bool ParentAdd()
        {           
            string sql = "SELECT Name FROM fbaStatus ORDER BY Name";
            string[,] values;
            if (!sys.InputValues(sql, true, false, out values)) return false;            
            string statusEntityID = dgvEntity.DataGridViewSelected("ID");            
            int maxY = values.GetLength(0);
            int maxX = values.GetLength(1); 
            const string EntityID = "234";
            for (int i = 0; i < maxY; i++)
            {
                string statusName  = values[i, 0];
                string statusID    = sys.GetStatusID(statusName); 
                sql = string.Format("INSERT INTO fbaStatusList (EntityID, StatusEntityID, StatusID) " +
                    "VALUES ({0},{1},{2});", EntityID, statusEntityID, statusID);
                sys.Exec(DirectionQuery.Remote, sql);
            }
            LoadStatusParent();
            LoadStatusChange();
            return true;                      
        }            
        
        /// <summary>
        /// Добавление статуса, на который может меняться выбранный статус сущности.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private bool ChangeAdd()
        {                               
        	string statusEntityID    = dgvEntity.DataGridViewSelected("ID");   
            string StatusListID    = dgvEntity.DataGridViewSelected("ID");  
			string statusCurrentName = dgvChange.DataGridViewSelected("Name");             
        	string sql = "SELECT * FROM fbaStatus WHERE ID IN (SELECT StatusID FROM fbaStatusList WHERE StatusEntityID = " + statusEntityID + ")" + Var.CR +
        		" AND ID NOT IN (SELECT StatusID FROM fbaStatusChange WHERE StatusEntityID = " + statusEntityID + " AND StatusListID = " + StatusListID + ")" + Var.CR +         	        	        	        	     
        		" AND Name <> '" + statusCurrentName + "'";
        	string[,] values;
            if (!sys.InputValues(sql, true, false, out values)) return false;                                   
            const string entityID = "235";
            int MaxY = values.GetLength(0);
            int MaxX = values.GetLength(1);            
            for (int i = 0; i < MaxY; i++)
            {                               
            	string statusID = values[i, 0];          
                if (statusID == "") continue;
                sql =  string.Format("INSERT INTO fbaStatusChange (EntityID, StatusEntityID,  StatusListID, StatusID) " +
                    "VALUES ({0},{1},{2},{3});", entityID, statusEntityID, StatusListID, statusID);
                sys.Exec(DirectionQuery.Remote, sql);
                                          
            }
            LoadStatusChange();
            return true;                      
        }                           
        
        /// <summary>
        /// Удаление всех статусов сущности.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private bool EntityDel()
        {           
            string statusEntityID =  dgvEntity.DataGridViewSelected("ID");
            string sql = string.Format(
                "DELETE FROM fbaStatusChange WHERE StatusEntityID = {0};" + Var.CR +
                "DELETE FROM fbaStatusList WHERE StatusEntityID = {0};" + Var.CR +
                "DELETE FROM fbaStatusEntity WHERE ID = {0};", statusEntityID);               
            if (!sys.Exec(DirectionQuery.Local, sql)) return false;
            LoadStatus();
            return true;
        }             
        
        /// <summary>
        /// Удаление одного статуса сущности.
        /// </summary>
        /// <returns></returns>
        private bool ParentDel()
        {           
            string StatusListID =  dgvParent.DataGridViewSelected("ID");
            string sql = string.Format(
                "DELETE FROM fbaStatusChange WHERE StatusListID = {0};" + Var.CR +
                "DELETE FROM fbaStatusList WHERE ID = {0};", StatusListID);               
            if (!sys.Exec(DirectionQuery.Local, sql)) return false;
            LoadStatusParent();
            LoadStatusChange();
            return true;
        }
            
        /// <summary>
        /// Удаление статуса на который может ссылаться выбранный статсус сущности.
        /// </summary>
        /// <returns></returns>
        private bool ChangeDel()
        {           
            string statusChangeID =  dgvChange.DataGridViewSelected("ID");
            string sql = string.Format(
                "DELETE FROM fbaStatusChange WHERE ID = {0};", statusChangeID);                      
            if (!sys.Exec(DirectionQuery.Local, sql)) return false;
            LoadStatusChange();
            return true;
        }             
        
        /// <summary>
        /// Контекстное меню с пунктом Refresh.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmMenu1_N1_Click(object sender, EventArgs e)
        {
            string dgvName = sys.GetControlNameByMenuStripItem(sender);
            if (dgvName == "dgvEntity") LoadStatus();
            if (dgvName == "dgvParent") 
            {
                LoadStatusParent();
                LoadStatusChange();
            }
            if (dgvName == "dgvParent") LoadStatusChange();             
        }             

		/// <summary>
		/// Событие изменения выделенной строки dgvEntity.  
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvEntityDoubleClick(object sender, EventArgs e)
		{
	        //LoadStatusParent();
            //LoadStatusChange();
		}		

		/// <summary>
		/// Событие изменения выделенной строки dgvParent. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvParentDoubleClick(object sender, EventArgs e)
		{
			//LoadStatusChange();
		}
		
		/// <summary>
		/// Событие изменения выделенной строки dgvEntity.  
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvEntitySelectionChanged(object sender, EventArgs e)
		{
			LoadStatusParent();
            LoadStatusChange();
		}
		
		/// <summary>
		/// Событие изменения выделенной строки dgvParent. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvParentSelectionChanged(object sender, EventArgs e)
		{
			LoadStatusChange();
		}              
    }
}
