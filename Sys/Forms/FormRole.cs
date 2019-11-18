
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 16.12.2016
 * Время: 14:37
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
namespace FBA
{    
	/// <summary>
	/// Форма редактирования роли пользоватлея.
	/// </summary>
    public partial class FormRole : FormFBA
    {               
        /// <summary>
        /// Результат закрытия формы.
        /// </summary>
        public int StatusClose   = 0;
        
        private Operation Operation = Operation.NotAssigned;
        private string roleID = "0";   
        private DataTable DTForm1;  
        private DataTable DTForm2;    
        private DataTable DTRight1;  
        private DataTable DTRight2;
        private string sql  = "";
        /// <summary>
        /// Rkycnhernjh
        /// </summary>
        /// <param name="operation">Операция. Add, Del, Edit</param>
        /// <param name="roleID">ИД роли</param>
        /// <param name="roleName">Имя роли</param>
        /// <param name="roleBrief">Сокращение роли</param>
        public FormRole(Operation operation, string roleID, string roleName, string roleBrief)  //FormDesigner MF, 
        {
            InitializeComponent();           
            this.Operation = operation;
            this.roleID    = roleID;
            DTForm1  = new DataTable();
            DTForm2  = new DataTable(); 
            DTRight1 = new DataTable();
            DTRight2 = new DataTable();            
          
            if (operation != Operation.Add)
            {
                tbID.Text      = roleID;
                tbName.Text    = roleName;           
                tbBrief.Text   = roleBrief; 
            }                   
        }
        
        private void BtnOkClick(object sender, EventArgs e)
        {           
        	StatusClose = 1;
            if (Operation == Operation.Add)
            {               
            	sql = "INSERT INTO fbaRole (EntityID, Name, Brief, DateCreate, DateChange) VALUES (103, '" + tbName.Text + "', '" + tbBrief.Text + "', " + sys.DateTimeCurrent() + ", " + sys.DateTimeCurrent() + ");"; 
                sys.Exec(DirectionQuery.Remote, true, sql, out roleID);
            }
            if (Operation == Operation.Edit)
            {                             
                sql = "UPDATE fbaRole SET " +
                      "Name  = '" + tbName.Text + "'," + 
                      "Brief = '" + tbBrief.Text  + "'," +
                      "UserChangeID = '" + Var.UserID   + "'," +                     
                      "DateChange = " + sys.DateTimeCurrent() + " " +
                      "WHERE ID = " + roleID + ";" + Var.CR; 
               sys.Exec(DirectionQuery.Remote, sql);               
            }                   
            string sqlinsert = "";
            string projectID    = ""; 
            string rightID   = "";             
            sql = "DELETE FROM fbaRelRoleProject WHERE RoleID = " + roleID + "; " + Var.CR +
                  "DELETE FROM fbaRelRoleRight WHERE RoleID = " + roleID + ";";
            for (int i = 0; i < DTForm2.Rows.Count; i++)
            {        	 	 
        	 	projectID = dgvForm2.RowInt(i, "ID");   
        	 	sqlinsert += "INSERT INTO fbaRelRoleProject (EntityID, ProjectID, RoleID, UserCreateID, DateCreate) " + 
        	 		"VALUES (" + sys.GetEntityID("RelRoleProject") + ", " + projectID + ", " + roleID + ", " + Var.UserID  + ", " + sys.DateTimeCurrent() + "); \r\n";
            }
            for (int i = 0; i < DTRight2.Rows.Count; i++)
            {                  
                 rightID = dgvRight2.RowInt(i, "ID");   
                 sqlinsert += "INSERT INTO fbaRelRoleRight (EntityID, RightID, RoleID, UserCreateID, DateCreate) " + 
                     "VALUES (" + sys.GetEntityID("RelRoleProject") + ", " + rightID + ", " + roleID + ", " + Var.UserID  + ", " + sys.DateTimeCurrent() + "); \r\n";                      
            }
            
            sql += sqlinsert;
            sys.Exec(DirectionQuery.Remote, sql);
            Close();        
        }    
        	 	
        private void BtnCancelClick(object sender, EventArgs e)
        {
            StatusClose = 2;
            Close();
        }
        
        private void FormRoleResize(object sender, EventArgs e)
        {
        	pnlForm1.Width  = (pnlForm.Width  - pnlFormSplitter.Width)  / 2;
            pnlRight1.Width = (pnlRight.Width - pnlRightSplitter.Width) / 2;        	
        }
            
        private void FormRoleLoad(object sender, EventArgs e)
        {
        	//Формы
            sql = "SELECT ID, Name FROM fbaProject WHERE DEL = 0 OR DEL IS NULL";
        	sys.SelectDT(DirectionQuery.Remote, sql, out DTForm1);
        	dgvForm1.DataSource = DTForm1;
        	
        	sql = "SELECT t2.ID, t2.Name FROM fbaRelRoleProject t1 LEFT JOIN fbaProject t2 ON t2.ID = t1.ProjectID WHERE t1.RoleID = " + roleID;    
        	sys.SelectDT(DirectionQuery.Remote, sql, out DTForm2);
        	dgvForm2.DataSource = DTForm2;
        	
        	//Права
            sql = "SELECT ID, Name FROM fbaRight";    
            sys.SelectDT(DirectionQuery.Remote, sql, out DTRight1);
            dgvRight1.DataSource = DTRight1;
            
            sql = "SELECT t2.ID, t2.Name FROM fbaRelRoleRight t1 LEFT JOIN fbaRight t2 ON t2.ID = t1.RightID WHERE t1.RoleID = " + roleID;    
            sys.SelectDT(DirectionQuery.Remote, sql, out DTRight2);
            dgvRight2.DataSource = DTRight2;        	
        }
        
        #region Регион. Формы.
                       
        /// <summary>
        /// Добавление одной формы
        /// </summary>
        private void AddForm()
        {
        	string RowID   = dgvForm1.DataGridViewSelected("ID");
        	string RowName = dgvForm1.DataGridViewSelected("Name"); 
        	DataRow[] dt;
        	dt = DTForm2.Select("Name='" + RowName + "'");
        	if (dt.Length > 0)
        	{
        		sys.SM("Форма уже добавлена!", MessageType.Information);
        	    return;
        	}
        	DataRow Row1 = DTForm2.NewRow();
        	Row1["ID"]   = RowID;
        	Row1["Name"] = RowName; 
        	DTForm2.Rows.Add(Row1);
        }           
        
        /// <summary>
        /// Добавление/удаление форм.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClick(object sender, EventArgs e)
        {        	            			  		     		                    	
        	if (sender == btnFormAdd) AddForm();
        	if (sender == dgvForm1)   AddForm();
        	 
        	//Добавление всех форм.
        	if (sender == btnFormAddAll)
        	{
        	    DTForm2.Rows.Clear();
                for (int i = 0; i < DTForm1.Rows.Count; i++)
                {
                    DataRow Row1 = DTForm2.NewRow(); 
                    Row1["ID"]   = dgvForm1.RowInt(i, "ID");
                    Row1["Name"] = dgvForm1.RowInt(i, "Name");            
                    DTForm2.Rows.Add(Row1);                         
                }                                              
        	}
        	
        	//Удаление одной формы.
        	if (sender == btnFormDel)  dgvForm2.SelectedDeleteFirst();//  sys.DGVDelete(dgvForm2);
        	
        	//Удаление всех форм.
            if (sender == btnFormDelAll)  DTForm2.Rows.Clear();           
        }
        
        #endregion Регион. Формы.
        
        #region Регион. Права.
                 
        /// <summary>
        /// Добавление одного права.
        /// </summary>
        private void AddRight()
        {
            string RowID   = dgvRight1.DataGridViewSelected("ID");
            string RowName = dgvRight1.DataGridViewSelected("Name"); 
            DataRow[] dt;
            dt = DTRight2.Select("Name='" + RowName + "'");
            if (dt.Length > 0)
            {
                sys.SM("Право уже добавлено!");
                return;
            }
            DataRow Row1 = DTRight2.NewRow();
            Row1["ID"]   = RowID;
            Row1["Name"] = RowName; 
            DTRight2.Rows.Add(Row1);
        }
                 
        /// <summary>
        /// /Добавление/удаление прав.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRightAddClick(object sender, EventArgs e)
        {                                                                                   
            if (sender == btnRightAdd) AddRight();
            if (sender == dgvRight1)   AddRight();
                
                    
            //Добавление всех форм.
            if (sender == btnRightAddAll)
            {
                DTRight2.Rows.Clear();
                for (int i = 0; i < DTRight1.Rows.Count; i++)
                {
                    DataRow Row1 = DTRight2.NewRow(); 
                    Row1["ID"]   = dgvRight1.RowInt(i, "ID");
                    Row1["Name"] = dgvRight1.RowInt(i, "Name");            
                    DTRight2.Rows.Add(Row1);                         
                }                                              
            }
            
            //Удаление одного права.
            if (sender == btnRightDel)  dgvRight2.SelectedDeleteFirst();  //sys.DGVDelete(dgvRight2);
            
            //Удаление всех прав.
            if (sender == btnRightDelAll)  DTRight2.Rows.Clear();           
        }
              
        #endregion Регион. Права.
		  
    }
}
    