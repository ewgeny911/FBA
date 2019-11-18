
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 15.02.2017
 * Время: 18:11
*/
 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace FBA
{
	/// <summary>
	/// Форма о программе.
	/// </summary>
	public partial class FormAbout : FormSim
	{
		/// <summary>
		/// Форма о программе.
		/// </summary>
		public FormAbout()
		{
			InitializeComponent();					 
			this.MdiParent = Var.FormMainObj; 
			//this.Icon = this.MdiParent.Icon;
            //ProcessorArchitecture: MSIL          
            //PathDesigner: не заполнено!  
                           
            string connectionDirect = "Not available";
            string connectionID     = "Not available";
            string connectionName   = "Not available";
            string serverName       = "Not available";
            string serverType       = "Not available";
            string serverTypeRemote = "Not available";
            string databaseName     = "Not available";
            string userForm         = "Not available";
            string userLogin        = "Not available";
            string version          = "Not available";
            string numberUpdate     = "Not available";
            string needUpdateStr       = "Not available";
            string connectionGUID   = "Not available";                                      
            string timePassed       = sys.GetDateDiff(Var.DateTimeStart, DateTime.Now);
                              
            if (Var.con != null)
            {
                connectionDirect = Var.con.ConnectionDirect.ToString();
                connectionID     = Var.con.ConnectionID;
                connectionName   = Var.con.ConnectionName;
                serverName       = Var.con.ServerName;
                serverType       = Var.con.serverType.ToString();
                serverTypeRemote = Var.con.serverTypeRemote.ToString();
                databaseName     = Var.con.DatabaseName;
                userForm         = Var.con.UserForm;
                userLogin        = Var.con.UserLogin;
                connectionGUID   = Var.con.ConnectionGUID;
                string Mes       = "";    
                bool needUpdate = SysUpdate.UpdateCheck(out version, out numberUpdate, out Mes, true);
                if (needUpdate) needUpdateStr = "True";
                  else needUpdateStr = "False";
            }                                                          
            
            textAbout.Clear();
            textAbout.AppendText("SystemName:            " + Var.SystemName         + Var.CR +
                                 "ConnectionGUID:        " + connectionGUID         + Var.CR +
                                 "ConnectionDirect:      " + connectionDirect       + Var.CR +
                                 "ConnectionID:          " + connectionID           + Var.CR +
                                 "ConnectionName:        " + connectionName         + Var.CR +
                                 "LocalPort:             " + Var.LocalServerPort + Var.CR +
                                 "LocalHost:             " + Var.LocalHost + Var.CR +
                                 "LocalIP:               " + Var.LocalIP + Var.CR +
                                 "ServerAppPort:         " + Var.ServerAppPortDefault + Var.CR +
                                 "ServerType:            " + serverType             + Var.CR +
                                 "ServerTypeRemote:      " + serverTypeRemote       + Var.CR +
                                 "ServerName:            " + serverName             + Var.CR +
                                 "DatabaseName:          " + databaseName           + Var.CR +
                                 "UserID:                " + Var.UserID              + Var.CR +    
                                 "UserForm:              " + userForm               + Var.CR +
                                 "UserLogin:             " + userLogin              + Var.CR +                                      
                                 "ApplicationVersion:    " + Var.ApplicationVersion + Var.CR +  //Пример: 1.0.6256.25762
                                 "Update required:       " + needUpdateStr             + Var.CR +
                                 "Latest version:        " + version                + Var.CR +
                                 "Latest number update:  " + numberUpdate           + Var.CR +                                                               	                            	    	    	   	    	    	    	    	    	                  
                                 "PathMain:              " + FBAPath.PathMain           + Var.CR +                                
                                 "PathAdditional:        " + FBAPath.PathAdditional     + Var.CR +
                                 "PathLog:               " + FBAPath.PathLog            + Var.CR +
                                 "PathTemp:              " + FBAPath.PathTemp           + Var.CR +
                                 "PathApp:               " + FBAPath.PathApp            + Var.CR +
                                 "PathUpdate:            " + FBAPath.PathUpdate         + Var.CR +
                                 "PathRollback:          " + FBAPath.PathRollback       + Var.CR +	    	                    	    	                 
                                 "EnterMode:             " + Var.enterMode.ToString() + Var.CR +
	    	                     "ComputerName:          " + Var.ComputerName        + Var.CR +
	    	                     "ComputerUserName:      " + Var.ComputerUserName    + Var.CR + 
	    	                     "System start:          " + Var.DateTimeStart      + Var.CR +  
 	    	                     "Time passed:           " + timePassed             + Var.CR);
		}       
		
		/// <summary>
		/// Событие. Закрытие формы.	
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnOkClick(object sender, EventArgs e)
		{
			Close();
		}					
			
		/// <summary>
		/// Событие. Удаление файлов кэша.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDeleteDLLClick(object sender, EventArgs e)
		{		     
			string[] listNotDeleted;
			FBAFile.DirClean(FBAPath.PathApp, out listNotDeleted, true);						 
		}
	}
}
