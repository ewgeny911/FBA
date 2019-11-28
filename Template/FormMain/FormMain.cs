
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.11.2017
 * Время: 16:29
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FBA
{  
	
	/// <summary>
	/// Главная форма подсистемы.
	/// </summary>
    public partial class FormMain : FormFBA
    {
        public FormMain()
        {              
            InitializeComponent();
            //sys.ConnectLocal();
            //sys.ConnectRemote();
            Var.FormMainObj = this;
        }
        
        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
             new FormAbout().Show();
        }
    }
    
    internal sealed class Program
    {       
        [STAThread]
        private static void Main(string[] args)
        {
            //Этот метод не вызывается, если проект подключается как DLL.
        	//Иными словами, если сюда попадаем, то это значит мы запустили как EXE, а значит мы в режиме разработки.
        	Var.IsDesignMode = true;
        	Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }        
    }
    
}
