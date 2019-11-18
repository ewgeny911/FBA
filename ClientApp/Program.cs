
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 17.12.2016
 * Время: 23:38
 */
 
using System;
//using System.Windows.Forms;  
//using System.Drawing;
using System.Windows.Forms;
//using System.ComponentModel;
//using System.ComponentModel.Design;    
//using System.Windows.Forms.Design;
//using System.Reflection;  //Для динам. подключения DLL           
//using System.CodeDom.Compiler;
//using Microsoft.CSharp;
//using System.Collections.Generic;
//using System.Data;
using System.Linq;
using System.Reflection;
using System.IO;
//using FastColoredTextBoxNS; 
//using @"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\sys.dll";
using System.Security.Permissions;
namespace FBA
{                 
	internal sealed class Program 
	{  
		[STAThread]
		//[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
		private static void Main(string[] args)  
		{					    		    		   	                   
		    Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            Var.SystemName = "ClientApp";            

            //Установка соединения с локальной базой SQLIte. Без неё не работаем.			  
            sys.ConnectLocal();
			//sys.ConnectLocal();
            //sys.ConnectRemote();		
			if (Var.Args.Length < 2) 
			{					
			     sys.ConnectRemote();			                        
			} else
			{
			    sys.ConnectParam();    			    		    		
			}
            //Если соединение с сервером приложений, то получаем локальный порт, и стартуем локальный сервер HTTP.
            if (!Var.con.ConnectionDirect)
            {
                Var.LocalServerPort = sys.GetServerLocalPort();
                ServerWork.ServerStart(Var.FormMainObj);
            }
           
            System.Windows.Forms.Application.Run(Var.FormMainObj);


            //Остановка локального сервера.
            if (!Var.con.ConnectionDirect)
            {
                sys.SendEventClientClose();
                ServerWork.ServerStop();
            }
        }        	
	}
}
