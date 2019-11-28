
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.11.2017
 * Время: 17:47
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace FBA
{      
    /// <summary>
    /// Шаблон формы. Необходим для создания новых прикладных форм в проекте. 
    /// </summary>
    public partial class FormCustom : FormFBA
    {
        public FormCustom()
        {                
            InitializeComponent();
            //sys.ConnectLocal();
            //sys.ConnectRemote();
        }
        void FormCustom_Shown(object sender, EventArgs e)
        {
          
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
            Application.Run(new FormCustom());
        }
        
    }
}
