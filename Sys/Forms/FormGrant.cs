
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 29.09.2017
 * Время: 14:45
 */
 
using System;

namespace FBA
{
    ///Форма по управлению ролями пользователей, а также правами на формы и произвольными правами. 
    public partial class FormGrant : FormFBA
    {
        /// <summary>
    	/// Конструктор. Установка MdiParent, Icon.
    	/// </summary>
    	public FormGrant()
        {           
            InitializeComponent();
            this.MdiParent = Var.FormMainObj; 
            this.Icon = this.MdiParent.Icon;                      
        }
        
        #region Region.  Вкладка Users.                    
        
        /// <summary>
        /// Показ списка пользователей.
        /// </summary>
        private void UserListRefresh()
        {   
            const string sql = "SELECT t1.ID, t1.Login, t1.Name, t1.Pass, t2.ID AS 'RoleID', t2.Name AS 'RoleName', t1.Block, t1.DateCreate, t1.DateChange FROM fbaUser t1 LEFT JOIN fbaRole t2 ON t2.ID = t1.RoleID ORDER BY t1.ID " ;            
            sys.RefreshGrid(DirectionQuery.Remote, dgvUser, sql);          
        }                     
                                            
        /// <summary>
        /// Удаление пользователя.
        /// </summary>
        /// <param name="userID">ИД пользователя</param>
        /// <returns></returns>
        public bool UserDelete(string userID)       
        {
            if (sys.SM("Вы хотите действительно удалить пользователя?", MessageType.Question, "Удаление пользователя") == false) return false;
            try                            
            {
                sys.Exec(DirectionQuery.Remote, "DELETE FROM fbaUser WHERE ID = " + userID);
                return true;
            }
            catch (Exception e)
            {                
                sys.SM(e.Message);
                return false;
            }
        }         
        
        /// <summary>
        /// Блокирование пользователя.
        /// </summary>
        /// <param name="userID">ИД пользвоателя</param>
        /// <param name="block">Если true, то блокируем пользователя</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetUserBlock(string userID, bool block)
        {   
            if (sys.SM("Вы хотите действительно блокировать пользователя?", MessageType.Question, "Блокирование пользователя") == false) return false;                
            sys.Exec(DirectionQuery.Remote, "UPDATE fbaUser SET Block = " + block.ToInt() + " WHERE ID = " + userID);
            UserListRefresh();  
            return true;
        }        
        
        ///Добавление/Удаление/Изменение пользователя.
        private void UserEdit(Operation operation, string userID, string userLogin, string userName, string userPass, string userRole, string userBlock)
        {
            if ((operation == Operation.Add) || (operation == Operation.Edit))
            {      
                var f1 = new FormUser(operation, userID, userLogin, userName, userPass, userRole, userBlock);
                f1.Owner = this;
                f1.ShowDialog();
                int StatusClose = f1.StatusClose;                   
                if (StatusClose == 2) return;
                UserListRefresh();                     
            }           
            if (operation == Operation.Del) 
                if (UserDelete(userID)) UserListRefresh();
                 
        }
        
        ///Событие. Кнопки добавления/удаления/изменения пользователя: Add, Del, Edit, Block, UnBlock, Refresh
        private void TbUser1Click(object sender, EventArgs e)
        { 
            string userID     = ""; 
            string userLogin  = "";             
            string userName   = "";
            string userPass   = "";         
            string roleID     = "";
			string roleName   = "";              
            string userBlock = ""; 
                 
            if (dgvUser.RowCount > 0) 
            {
                userID    = dgvUser.SelectedRows[0].Cells["ID"].Value.ToString();
                userName  = dgvUser.SelectedRows[0].Cells["Name"].Value.ToString();
                userLogin = dgvUser.SelectedRows[0].Cells["Login"].Value.ToString();
                userPass  = dgvUser.SelectedRows[0].Cells["Pass"].Value.ToString();                
                roleID    = dgvUser.SelectedRows[0].Cells["RoleID"].Value.ToString();
                roleName  = dgvUser.SelectedRows[0].Cells["RoleName"].Value.ToString();
                userBlock = dgvUser.SelectedRows[0].Cells["Block"].Value.ToString();
            }
             
            if (sender == tbUser1) {UserEdit(Operation.Add,  userID, userLogin, userName, userPass, roleName, userBlock);};                        
            if (sender == tbUser2) {UserEdit(Operation.Del,  userID, userLogin, userName, userPass, roleName, userBlock);};
            if (sender == tbUser3) {UserEdit(Operation.Edit, userID, userLogin, userName, userPass, roleName, userBlock);};             
            if (sender == tbUser4) {UserListRefresh();};
            if (sender == tbUser5) {SetUserBlock(userID, true);};
            if (sender == tbUser6) {SetUserBlock(userID, false);};
        }                   
        
        #endregion Region.  Вкладка Users.
       
        #region Region.  Вкладка Роли.     
        
        /// <summary>
        /// Показ списка ролей
        /// </summary>
        private void RoleListRefresh()
        {
           const string sql = "SELECT ID, Name, Brief, DateCreate, DateChange FROM fbaRole ORDER BY ID " ;
           sys.RefreshGrid(DirectionQuery.Remote, dgvRole, sql); 
        }               
               
        /// <summary>
        /// Добавление/Удаление/Изменение роли
        /// </summary>
        /// <param name="operation">Операция: Add, Del, Edit</param>
        /// <param name="roleID">ИД роли</param>
        /// <param name="roleName">Имя роли</param>
        /// <param name="roleBrief">Сокращение роли</param>
        private void RoleEdit(Operation operation, string roleID, string roleName, string roleBrief)
        {
            if ((operation == Operation.Add) || (operation == Operation.Edit))
            {      
                var f1 = new FormRole(operation, roleID, roleName, roleBrief);
                f1.Owner = this;
                f1.ShowDialog();
                int StatusClose = f1.StatusClose;                   
                if (StatusClose == 2) return;
                RoleListRefresh();
            }           
            if (operation == Operation.Del) 
                if (RoleDelete(roleID)) RoleListRefresh();                                  
        }
            
        /// <summary>
        /// Удаление роли.
        /// </summary>
        /// <param name="roleID">ИД роли</param>
        /// <returns>Если успешно, то true</returns>
        private bool RoleDelete(string roleID)
        {
            if (sys.SM("Вы хотите действительно удалить роль?", MessageType.Question, "Удаление роли") == false) return false;                
            return sys.Exec(DirectionQuery.Remote, "DELETE FROM fbaRole WHERE ID = " + roleID);            
        }
        
        ///Событие. Кнопки редактирования ролей: Add, Del, Edit, Refresh
        private void TbRole1Click(object sender, EventArgs e)
        {   
            string roleID     = ""; 
            string roleName   = "";             
            string roleBrief  = "";            
            if (dgvRole.RowCount > 0) 
            {
                roleID = dgvRole.SelectedRows[0].Cells["ID"].Value.ToString();
                roleName   = dgvRole.SelectedRows[0].Cells["Name"].Value.ToString();
                roleBrief  = dgvRole.SelectedRows[0].Cells["Brief"].Value.ToString();                
            }
               
            if (sender == tbRole1) {RoleEdit(Operation.Add,  roleID, roleName, roleBrief);};
            if (sender == tbRole2) {RoleEdit(Operation.Del,  roleID, roleName, roleBrief);};
            if (sender == tbRole3) {RoleEdit(Operation.Edit, roleID, roleName, roleBrief);};
            if (sender == tbRole4) {RoleListRefresh();};            
        }
               
        /// <summary>
        /// Событие. Показываем список пользователей и ролей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGrantLoad(object sender, EventArgs e)
        {
            UserListRefresh();
            RoleListRefresh();
            RightListRefresh();
            HistRefresh();
        }
        
        #endregion Region. Вкладка Роли.
       
        #region Region. Вкладка Права.                                  
        
        /// <summary>
        /// Показ списка прав.
        /// </summary>
        private void RightListRefresh()
        {
           const string sql = "SELECT ID, Name, Brief, DateCreate, DateChange FROM fbaRight ORDER BY ID " ;
           sys.RefreshGrid(DirectionQuery.Remote, dgvRight, sql); 
        }
          
        /// <summary>
        /// Добавление/Удаление/Изменение права.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="rightID"></param>
        /// <param name="rightName"></param>
        /// <param name="rightBrief"></param>
        private void RightEdit(Operation operation, string rightID, string rightName, string rightBrief)
        {
            if ((operation == Operation.Add) || (operation == Operation.Edit))
            {      
                var f1 = new FormRight(operation, rightID, rightName, rightBrief);                
                f1.Icon = this.Icon; 
                f1.ShowDialog();               
                int StatusClose = f1.StatusClose;                   
                if (StatusClose == 2) return;
                RightListRefresh();
            }           
            if (operation == Operation.Del) 
                if (RightDelete(rightID)) RightListRefresh();                                  
        }
               
        /// <summary>
        /// Удаление права.
        /// </summary>
        /// <param name="rightID">ИД права</param>
        /// <returns>Если успешно, то true</returns>
        private bool RightDelete(string rightID)
        {
            if (sys.SM("Вы хотите действительно удалить право?", MessageType.Question, "Удаление права") == false) return false;                
            return sys.Exec(DirectionQuery.Remote, "DELETE FROM fbaRight WHERE ID = " + rightID);            
        } 
        
        private void TbRight1Click(object sender, EventArgs e)
        {
            string rightID    = ""; 
            string rightName   = "";             
            string rightBrief  = ""; 
           
            if (dgvRight.RowCount > 0) 
            {
                rightID     = dgvRight.SelectedRows[0].Cells["ID"].Value.ToString();
                rightName   = dgvRight.SelectedRows[0].Cells["Name"].Value.ToString();
                rightBrief  = dgvRight.SelectedRows[0].Cells["Brief"].Value.ToString();                
            }
               
            if (sender == tbRight1) {RightEdit(Operation.Add,  rightID, rightName, rightBrief);};
            if (sender == tbRight2) {RightEdit(Operation.Del,  rightID, rightName, rightBrief);};
            if (sender == tbRight3) {RightEdit(Operation.Edit, rightID, rightName, rightBrief);};
            if (sender == tbRight4) {RightListRefresh();};
        }
                 
        #endregion Region. Вкладка Права.
        
        #region Region. Вкладка История входов пользователя в систему.
            
        /// <summary>
        /// Обновить историю входов пользователя в систему.
        /// </summary>
        private void HistRefresh()
        {
            if (dgvUser.Rows.Count == 0) return;      
            string userID = dgvUser.SelectedRows[0].Cells["ID"].Value.ToString();
            string sql = "SELECT ID, EntityID, ConnectionName, ComputerName, " +
                         " ComputerUserName, UserForm, UserID, SystemName, EnterDate " + 
                         "FROM fbaEnterHist WHERE UserID = " + userID;
            var filter = new FilterObj();
            filter.FullQuerySQL = sql;        
            sys.RefreshGrid(DirectionQuery.Remote, sgHist, filter);
        }          
        
        /// <summary>
        /// Обновить историю входов пользователя в систему.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbHist1Click(object sender, EventArgs e)
        {
            HistRefresh();
        }     
        
        /// <summary>
        /// При переключении вкладки на другую вкладку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlMainSelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 3) HistRefresh();
        }              
        
        /// <summary>
        /// Двойной клик на таблице пользоватлей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void DgvUserDoubleClick(object sender, EventArgs e)
		{			
			TbUser1Click(tbUser3, e);                              
		}		
		
		/// <summary>
		/// Двойной клик на таблице ролей.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvRoleDoubleClick(object sender, EventArgs e)
		{
			TbRole1Click(tbRole3, e);
		}
			
		/// <summary>
		/// Двойной клик на таблице прав.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvRightDoubleClick(object sender, EventArgs e)
		{
			TbRight1Click(tbRight3, e);
		}
        
        #endregion Region. Вкладка История входов пользователя в систему.
       
    }
}
