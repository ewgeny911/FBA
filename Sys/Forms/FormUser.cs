
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 14.12.2016
 * Время: 11:20
*/ 
 
using System;   
using System.Windows.Forms;
 
namespace FBA
{ 
	/// <summary>
	/// Форма для управления пользователями.
	/// </summary>
	public partial class FormUser : FormFBA
	{  
		private Operation operation = Operation.NotAssigned;
		private string UserID     = "0";
		private string UserLogin  = "";
		private string UserPass   = "";
		private string UserRole   = "";
		private string sql = "";
		
		/// <summary>
		/// Статус закгрытия формы
		/// </summary>
		public int StatusClose = 0;
                      
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="operation">Операция: Add, Del, Edit</param>
		/// <param name="userID">ИД пользователя</param>
		/// <param name="userLogin">Логин</param>
		/// <param name="userName">Имя</param>
		/// <param name="userPass">Пароль</param>
		/// <param name="userRole">Роль пользователя</param>
		/// <param name="userBlock">Устанавливает галку - пользователь блокирован</param>
		public FormUser(Operation operation, string userID, string userLogin, string userName, string userPass, string userRole, string userBlock)
		{            
			InitializeComponent();
			this.operation = operation;
			this.UserID      = userID;
			this.UserLogin   = userLogin;
			this.UserPass    = userPass;
			this.UserRole    = userRole;
			if (operation != Operation.Add) {
				tbID.Text = userID; 
				tbLogin.Text = userLogin;
				tbName.Text  = userName;           
				tbPass.Text  = userPass;
				tbRole.Text  = userRole;
			}
			sql = "SELECT * FROM fbaRole";
			sys.SelectGV(DirectionQuery.Remote, sql, dgvRole);                     
			if (userBlock == "1") cbBlock.Checked = true; 		

			const string sql1 = "SELECT ID, Name FROM fbaRight";
			string sql2 = "SELECT RightID AS ID, t2.Name FROM fbaRelUserRight t1 INNER JOIN fbaRight t2 ON t2.ID = t1.RightID AND t1.UserID = " + userID;
			ObjAdd.Open(sql1, sql2);			
		}
        
		private void BtnOkClick(object sender, EventArgs e)
		{            
			StatusClose = 1;
			string blockStr = "0";
			string roleID   = dgvRole.Value("ID"); 
			if (cbBlock.Checked) blockStr = "1";
			string userPassNew = sys.GetUserPassCrypt(tbLogin.Text, tbPass.Text); 
			sql = "";
			if (operation == Operation.Add) 					
				sql = "INSERT INTO fbaUser (EntityID, Login, Name, Pass, RoleID, Block, DateCreate, DateChange) VALUES (102, '" + tbLogin.Text + "', '" + tbName.Text + "', '" + userPassNew + "', " + roleID + ", '" + blockStr + "', " + sys.DateTimeCurrent() + ", " + sys.DateTimeCurrent() + ") ";			    
			           
			if (operation == Operation.Edit) 
			{			   
				sql = "UPDATE fbaUser SET " +
				"Login  = '" + tbLogin.Text + "'," +
				"Name   = '" + tbName.Text + "'," +
				"Pass   = '" + userPassNew + "'," +
				"RoleID = " + roleID + "," +
				"Block  = '" + blockStr + "'," +
				"DateChange = " + sys.DateTimeCurrent() + " " +
				"WHERE ID = " + UserID;			  
			}
			if (sql != "") sys.Exec(DirectionQuery.Remote, sql);
			
			ObjAdd.SaveChanges("fbaRelUserRight", 		                          		                       
		                        "UserID",
		                        "RightID",		                        
		                        UserID,
		                        null,
		                        null);
			
			Close();        
		}
        
		private void BtnCancelClick(object sender, EventArgs e)
		{
			StatusClose = 2;
			Close();
		}
		
		               
	}
}
