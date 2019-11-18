
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 11.03.2017
 * Время: 21:30
 
 */
 
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;

namespace FBA
{
	///Сервер приложений.
	internal sealed class Program
	{
		///Сервер приложений.
		[STAThread]
		private static void Main(string[] args)
		{							
			WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
 			
            //Попытка запуститься с правами администратора.
            if (hasAdministrativeRight == false)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(); //создаем новый процесс
                processInfo.Verb = "runas"; //в данном случае указываем, что процесс должен быть запущен с правами администратора
                processInfo.FileName = Application.ExecutablePath; //указываем исполняемый файл для запуска
                try
                {
                    Process.Start(processInfo); //пытаемся запустить процесс
                }
                catch (Win32Exception)
                {
                    //возможно, нажал кнопку "Нет" в ответ на вопрос о запуске программы 
                    //в окне предупреждения UAC (для Windows 7)
                    //Но мы все равно запускаемся, даже без админских прав.                    
	                RunServer();
                }                         
            }
            else //имеем права администратора, стартуем
            {                	
               	RunServer();
            }		
		}
		
		private static void RunServer()
		{
			Var.SystemName = "ServerApp";
        	Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormServer());	
		}
		
	}
}
