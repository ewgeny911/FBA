
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 17.12.2016
 * Время: 23:38
 */
 
using System;
using System.Linq;
using System.Windows.Forms;  
  
namespace FBA
{ 
	/// <summary>
	/// /Форма входа в систему. Также возможна авторизация через командную строку.
	/// </summary>
    public partial class FormEnter : FormSim
	{	
		/// <summary>
		/// Статус закрытия формы входа.
		/// </summary>
    	public int StatusClose = 0;
		
		/// <summary>
		/// Если стоит true, то при закрыти формы входа закрываем ВСЮ ПРОГРАММУ, если не авторизовались.	
		/// </summary>
		public bool CloseDefault = true;
				
		/// <summary>
		/// Конструктор	
		/// </summary>
		/// <param name="CloseDefault"></param>
		public FormEnter(bool CloseDefault = true)
		{                                   									 	          						   			  		  		    	 
		    this.CloseDefault = CloseDefault;
		    InitializeComponent();
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;      
			
            //Обновляем список подключений
		    ConnectionListRefresh();		   
		}
  		
		/// <summary>
		/// Из локальной базы загружаем список настроек соединения.	 
		/// </summary>
		private void ConnectionListRefresh()
		{					
			cbConnection.SetDataSourceSQL(DirectionQuery.Local, "SELECT ConnectionName FROM fbaConList ORDER BY ConnectionName");		    		  
		    string connectionName;   
		    string enterModeStr = "";
            sys.GetValue(DirectionQuery.Local, "SELECT ConnectionName, EnterMode FROM fbaEnterLast WHERE SystemName = '" + Var.SystemName + "' ORDER BY EnterDate DESC LIMIT 1;", out connectionName, out enterModeStr);                
            cbConnection.SelectStr(connectionName);           
            if (enterModeStr == EnterMode.Work.ToString())     
            {
            	cbEnterMode.SelectedIndex = 0;
            	Var.enterMode = EnterMode.Work;
            }
            if (enterModeStr == EnterMode.Test.ToString())                 	
            {
            	cbEnterMode.SelectedIndex = 1;
            	Var.enterMode = EnterMode.Test;
            }
            if (enterModeStr == EnterMode.Develop.ToString())              
            {
            	cbEnterMode.SelectedIndex = 2;
            	Var.enterMode = EnterMode.Develop;
            }
            
		}				   					
		
		/// <summary>
		/// Кнопки Ok и Cancel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOkClick(object sender, EventArgs e)
	    {				        			                		    		                       		  
            if (sender == btnCancel) 
            {
                if (CloseDefault) Environment.Exit(0);
                else Close();
            }
            EnterSystem();
		}             
			
		/// <summary>
		/// Вход в систему.
		/// </summary>
		/// <returns>Если вход успешный, то true</returns>
		private bool EnterSystem()
		{		             
            string connectionName = cbConnection.ComboBoxStr();           
            if (cbEnterMode.SelectedIndex == 0) Var.enterMode = EnterMode.Work;
            if (cbEnterMode.SelectedIndex == 1) Var.enterMode = EnterMode.Test;
            if (cbEnterMode.SelectedIndex == 2) Var.enterMode = EnterMode.Develop;                        
            
            //Вход в систему - главный метод.
            if (!sys.Enter(connectionName, Var.enterMode, tbUserLogin.Text, tbUserPass.Text)) 
            {               
                DialogResult = DialogResult.None; 
                return false;
            }                               
            
            /*string Mes2 = 
                    "Program2 Var.connectionID="    + Var.connectionID        + Var.CR +
                    "Program2 Var.connectionName="  + Var.connectionName      + Var.CR + 
                    "Program2 sys.UserForm="        + sys.UserForm            + Var.CR + 
                    "Program2 sys.Mode="        + sys.Mode.ToString() + Var.CR;
            sys.SM(Mes2); */
            
            if (Var.SystemName == "ClientApp") 
            {
                //string ResultMessage = "";               
                //UpdateApp.UpdateProgram(false, out ResultMessage);

                //Запуск формы, переменная sys.UserForm устанавливается в SystemEnter. 
                int formNumber = 0;              
                Form form =  ProjectService.FormGet(Var.ProjectMainName, Var.ProjectMainName, out formNumber, null); 
                if (form == null) return false;                            
                if (form.GetType().GetProperty("FormNumber") != null)
                    Var.FormMainObj = (FormFBA)form;
                
                if (Var.FormMainObj == null)
                {
                    DialogResult = DialogResult.None; 
                    return false;
                }
                //Форма главная, если в имени есть слово Main.
                if (Var.FormMainObj.Name.IndexOf("Main", StringComparison.Ordinal) == -1) //!= sys.FormTypeList.Main)
                {
                    DialogResult = DialogResult.None; 
                    sys.SM("Форма не является главной форма запуска подсистемы!");
                    return false;
                }                                         
            }
            
            StatusClose = 1; //1 - успешно.
            return true;
		}
		
		/// <summary>
		/// Показ формы редактирования списка подключений. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CbConnectionListCheckedChanged(object sender, EventArgs e)
		{
		    var form = new FormConList();
		    if (form.ShowDialog() !=  DialogResult.OK) return;		
		    ConnectionListRefresh();
            cbConnection.SelectStr(form.SelectConnectionName);
		}
		
		///Выбор подключения из выпадающего CompboBox.
		private void CbConnectionSelectedIndexChanged(object sender, EventArgs e)
		{
		    string sql = "SELECT UserLogin, UserPass FROM fbaConList WHERE ConnectionName = '" + cbConnection.ComboBoxStr() + "';";		  
			string userLogin;
			string userPass;
		    Var.conLite.GetValue2(sql, out userLogin, out userPass);		               		    
		    tbUserLogin.Text = userLogin;
		    tbUserPass.Text  = userPass;		    
		}					
		 
		/// <summary>
		/// Если пользователь нажал крестик на форме входа, то закрываем всю программу.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormEnterFormClosing(object sender, FormClosingEventArgs e)
		{	 	  
		    if ((StatusClose == 0) && (CloseDefault)) Environment.Exit(0);		    
		}
		
		///Подсвечиваем CapsLock.
        private void Timer1Tick(object sender, EventArgs e)
        {                                         
           bool capsLockIsOn = Control.IsKeyLocked(Keys.CapsLock);
           if (capsLockIsOn)
           {
               lbCapsLock.Text = "Caps Lock ON";
               lbCapsLock.ForeColor = System.Drawing.Color.Red;
               lbCapsLock.Visible = true;
           } else
           {                
               lbCapsLock.Visible = false;
           }
        }
        
        /// <summary>
        /// Используется при разработке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEnter_Shown(object sender, EventArgs e)
        {
            return;
            /*if ((Var.ComputerName == "COMP2879") || (Var.ComputerName == "PC"))
            {
                if (!EnterSystem()) return;               
                DialogResult = DialogResult.OK; 
                Close();                
            }*/
        }
		
    }
}
   