
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 20.03.2017
 * Время: 14:36
 * 
 
 */
using System;
using System.Windows.Forms;
namespace FBA
{       
    internal sealed class Program
    {  
        [STAThread]
        private static void Main(string[] args)
        {                                            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);                                                        
           
            //Установка соединения с локальной базой SQLIte. Без неё не работаем.             
            Var.SystemName = "Utility";
            sys.ConnectLocal();
            sys.ConnectRemote();
            //sys.ConnectRemoteSilent("test1", "TRY");
                               
            Application.Run(new FormUtility());
        }
        
    }
}
