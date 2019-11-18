
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 03.06.2017
 * Время: 12:20
*/
 
using System;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Threading;
          
namespace FBA
{	  
	internal sealed class Program
	{		  
		[STAThread]
		//[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
		private static void Main(string[] args)
		{					    		  		    		  
		    Var.SystemName = "ParserApp";
		    Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormParser());													
		}				           
	}
} 
