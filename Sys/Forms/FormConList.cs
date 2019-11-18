
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 12.01.2017
 * Время: 16:31
*/
using System;
using System.Windows.Forms;  
namespace FBA
{	
	/// <summary>
	/// Форма для создания подключения к БД или серверу приложений.
	/// </summary>
    public partial class FormConList : FormSim 
	{            
		bool DoNotUpdateText;
		
		/// <summary>
		/// Имя выбранного подключения
		/// </summary>
		public string SelectConnectionName = "";
		
        //Это для того чтобы количество звездочек при показе пароля было больше,
        //и нельзя было понять какая длина пароля на самом деле.
        const string AddTextPass = "$---5634---$";
		
        /// <summary>
        /// Список подключений к базе данных и серверам приложений
        /// </summary>
        public FormConList()
		{
            InitializeComponent();                     	    
			ConnectionListRefresh(); 
            DialogResult = DialogResult.Cancel;			
		}
		
		///Закрытие формы.
		private void BtnOkClick(object sender, EventArgs e)
		{
		    SelectConnectionName = tbConnectionName.Text;
		    DialogResult = DialogResult.OK;
		    Close();
		}
		
        ///Обновление списка подключений в гриде.		
		private void ConnectionListRefresh()
		{		
			DoNotUpdateText = true;		
			const string sql = "SELECT ID, ConnectionName, ServerName, ServerType, DatabaseName, " + 
				  	  "(CASE WHEN DatabaseLogin <> '' THEN '**********' ELSE DatabaseLogin END) AS DatabaseLogin, " + 				     	
				      "(CASE WHEN DatabasePass <> '' THEN '**********' ELSE DatabasePass END) AS DatabasePass, " + 				     
			          "UserForm, UserLogin, " +
				      "(CASE WHEN UserPass <> '' THEN '**********' ELSE UserPass END) AS UserPass " +		  
  				      "FROM fbaConList ORDER BY ConnectionName; ";		
			Var.conLite.SelectGV(sql, dgvConnectionList);				
			DoNotUpdateText = false;
		}
		
		///Событие. Кнопка добавления подключения.
		private void BtnAddClick(object sender, EventArgs e)
		{				
			ConnectionAdd();     			
		}
		
		///Добавление подключения.
		private void ConnectionAdd()
		{    
		    string connectionName    = tbConnectionName.Text;
			string serverType        = cbType.Text;
			string serverName        = tbServerName.Text;			 
			string databaseName      = tbDatabaseName.Text;
			string databaseLogin     = Crypto.EncryptAES(tbDatabaseLogin.Text.Replace(AddTextPass, ""));
			string databasePass      = Crypto.EncryptAES(tbDatabasePass.Text.Replace(AddTextPass, ""));
			string userForm          = tbUserForm.Text;
			string userLogin         = tbUserLogin.Text;
			string userPass          = sys.GetUserPassCrypt(tbUserLogin.Text, tbUserPass.Text);    				
			string windowsLogin      = cbWindowsLogin.Checked.ToInt().ToString();
            string sql = "INSERT INTO fbaConList (ConnectionName, ServerType, ServerName, DatabaseName, DatabaseLogin, DatabasePass, UserForm, UserLogin, UserPass, WindowsLogin) VALUES (" +
				  "'" + connectionName + "'," +
				  "'" + serverType     + "'," +
				  "'" + serverName     + "'," +				   
				  "'" + databaseName   + "'," +
            	  "'" + databaseLogin  + "'," +
            	  "'" + databasePass   + "'," +
                  "'" + userForm       + "'," +
            	  "'" + userLogin      + "'," +
            	  "'" + userPass       + "'," +
                  "'" + windowsLogin   + "'" +
				  ")";		
			Var.conLite.Exec(sql);
            ConnectionListRefresh();	
		}
		  
		///Тест подключения.
		private void BtnConnectionTestClick(object sender, EventArgs e)
	    {			           
		    //Crypto.EncryptAES(tbUserPass.Text.Replace(AddTextPass, ""));                
            if (!sys.Enter(tbConnectionName.Text, EnterMode.Test, tbUserLogin.Text, tbUserPass.Text)) return;                                
		    sys.SM("Подключение выполнено успешно!", MessageType.Information, "Подключение к базе данных");      	
		}
		
		/// <summary>
		/// Удаление подключения.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDelClick(object sender, EventArgs e)
		{
			 string id = dgvConnectionList.DataGridViewSelected("ID");
			 string sql = "DELETE FROM fbaConList WHERE ID = " + id;	
			 Var.conLite.Exec(sql);
             ConnectionListRefresh();     			 
		}
		
		///Пример значений полей ввода для подключения.
		private void BtnExampleClick(object sender, EventArgs e)
		{		    		    		   
			const string example =
			    "Connection Name:" + "\t\t" + "Current"      + Var.CR +
			    "Server Name or IP: " + "\t\t" + "10.77.177.10" + Var.CR +			 
			    "Database Name:  " + "\t\t" + "dbtest"       + Var.CR +
			    "Database Login: " + "\t\t" + "ivanov"       + Var.CR +
			    "Database Pass:  " + "\t\t" + "935642"       + Var.CR +
			    "User Form:      " + "\t\t" + "Form1"        + Var.CR +
			    "User Login:     " + "\t\t" + "Иванов"       + Var.CR +
			    "User Pass:      " + "\t\t" + "554774";
			 sys.SM(example, MessageType.Information);
		}
 
		///При навигации по таблице списку подключений показываем значения параметров.
		private void UpdateFormText()
		{			  
			string id   = dgvConnectionList.DataGridViewSelected("ID");
			if (id  == "") return;
		    string sql;
		    string connectionName;
			string serverType;
			string serverName;
			string databaseLogin;
			string databasePass;
			string databaseName;
			string userLogin;
			string userPass;
			string userForm;
			string windowsLogin;
			sql = "SELECT ConnectionName, ServerType, ServerName, DatabaseLogin, DatabasePass, " +
				  "DatabaseName, UserLogin, UserPass, UserForm, WindowsLogin " + 
				  "FROM fbaConList WHERE ID = " + id;
			
            Var.conLite.GetValue10(sql, out connectionName,
			                            out serverType,
			                            out serverName, 
			                            out databaseLogin,
			                            out databasePass, 
			                            out databaseName, 
			                            out userLogin,
			                            out userPass,
			                            out userForm,
			                            out windowsLogin);
				
			tbConnectionName.Text  = connectionName;
			tbServerName.Text      = serverName;			 
			tbDatabaseName.Text    = databaseName;
			tbDatabaseLogin.Text   = Crypto.DecryptAES(databaseLogin) + AddTextPass;
			tbDatabasePass.Text    = Crypto.DecryptAES(databasePass) + AddTextPass;
			tbUserForm.Text        = userForm;	
			tbUserLogin.Text       = userLogin;	
			tbUserPass.Text        = userPass; //Crypto.DecryptAES(UserPass) + AddTextPass;
			cbWindowsLogin.Checked = windowsLogin.ToBool(); //Crypto.DecryptAES(UserPass) + AddTextPass;.Text       = UserPass; //Crypto.DecryptAES(UserPass) + AddTextPass;
		    cbType.SelectStr(serverType);
		    EnableOrDisable();
		}
		
		///При навигации по таблице списку подключений показываем значения параметров.
		private void DgvConnectionListSelectionChanged(object sender, EventArgs e)
		{
			if (DoNotUpdateText == false) UpdateFormText();
		}
		
		///Сохранение текущего подключения.
		private void BtnSaveClick(object sender, EventArgs e)
		{			
			string id = dgvConnectionList.DataGridViewSelected("ID");
			if (id == "") 
			{
				ConnectionAdd();
				return;
			}
			if (sys.SM("Подключение будет перезаписано. Продолжить?", MessageType.Question, "Сохранение подключения") == false) return;
						
			string connectionName = tbConnectionName.Text;
			string serverType     = cbType.Text;
			string serverName     = tbServerName.Text;			 
			string databaseName   = tbDatabaseName.Text;
			string databaseLogin  = Crypto.EncryptAES(tbDatabaseLogin.Text.Replace(AddTextPass, ""));
			string databasePass   = Crypto.EncryptAES(tbDatabasePass.Text.Replace(AddTextPass, ""));
			string userForm       = tbUserForm.Text;
			string userLogin      = tbUserLogin.Text;		
			string userPass       = sys.GetUserPassCrypt(tbUserLogin.Text, tbUserPass.Text);     						 		
			string windowsLogin   = cbWindowsLogin.Checked.ToInt().ToString();
            string sql = "UPDATE fbaConList SET " +
				  "ConnectionName = '" + connectionName + "'," +
				  "ServerType     = '" + serverType     + "'," +
				  "ServerName     = '" + serverName     + "'," +				   
				  "DatabaseName   = '" + databaseName   + "'," +
            	  "DatabaseLogin  = '" + databaseLogin  + "'," +
            	  "DatabasePass   = '" + databasePass   + "'," +
                  "UserForm       = '" + userForm       + "'," +
                  "UserLogin      = '" + userLogin      + "'," +             	
            	  "UserPass       = '" + userPass       + "',"  +
                  "WindowsLogin   = '" + windowsLogin   + "'"  +
            	  " WHERE ID = " + id;
			Var.conLite.Exec(sql);
            ConnectionListRefresh();
		}
 
		///Выбор типа подключения из выпадающего списка.
		private void CbTypeSelectedIndexChanged(object sender, EventArgs e)
		{                   
		    EnableOrDisable();
		}
		
		///Доступные или недоступны компоненты.
		private void EnableOrDisable()
		{
		    bool fenable = (cbType.SelectedIndex != 3);
		    lbDatabaseName.Enabled  = fenable;
            lbDatabaseLogin.Enabled = fenable;
            lbDatabasePass.Enabled  = fenable;
            lbUserLogin.Enabled     = !cbWindowsLogin.Checked;
            lbUserPass.Enabled      = !cbWindowsLogin.Checked;            
		    tbDatabaseName.Enabled  = fenable;            
            tbDatabaseLogin.Enabled = fenable;
            tbDatabasePass.Enabled  = fenable;                                    
            tbUserLogin.Enabled     = !cbWindowsLogin.Checked;
            tbUserPass.Enabled      = !cbWindowsLogin.Checked;                                                                        
            if (!tbDatabaseName.Enabled)  
            {
                tbDatabaseName.Text          = ""; 
                tbDatabaseName.BackColor     = System.Drawing.SystemColors.Control;
            } else  tbDatabaseName.BackColor = System.Drawing.SystemColors.Info;
            
            if (!tbDatabaseLogin.Enabled)
            {
                tbDatabaseLogin.Text          = "";
                tbDatabaseLogin.BackColor     = System.Drawing.SystemColors.Control;
            } else  tbDatabaseLogin.BackColor = System.Drawing.SystemColors.Info;
            
            if (!tbDatabasePass.Enabled)
            {
                tbDatabasePass.Text          = "";
                tbDatabasePass.BackColor     = System.Drawing.SystemColors.Control;
            } else  tbDatabasePass.BackColor = System.Drawing.SystemColors.Info;
            
            if (!tbUserLogin.Enabled)
            {              
                tbUserLogin.Text          =  Environment.UserDomainName + @"\" + Environment.UserName;
                tbUserLogin.BackColor     = System.Drawing.SystemColors.Control;
            } else  tbUserLogin.BackColor = System.Drawing.SystemColors.Info;
            
            if (!tbUserPass.Enabled)
            {              
                tbUserPass.Text = "";
                tbUserPass.BackColor     = System.Drawing.SystemColors.Control;
            } else  tbUserPass.BackColor = System.Drawing.SystemColors.Info;
		}
		
		///Галка - Windows авторизация.
        private void CbWindowsLogin_CheckedChanged(object sender, EventArgs e)
        {
            EnableOrDisable();
        }
        
        ///Закрытие формы по двойному клику на таблице подключений.
        private void dgvConnectionList_DoubleClick(object sender, EventArgs e)
        {
            BtnOkClick(sender, e);                 
        }
	}
}
