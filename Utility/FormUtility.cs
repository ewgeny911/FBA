
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 20.03.2017
 * Время: 14:36
 */
 
using System;  
using System.Linq;        
using System.Windows.Forms.VisualStyles;
      
using System.Windows.Forms;
using System.IO;
using System.Data;     
using System.Collections.Generic;   
using System.Xml.Serialization;
using System.Xml;
//using System;
//using System.Linq;
using System.Reflection;
//using System.Windows.Forms;
//using System.IO;
//using System.Data;  
using System.Security.Cryptography;
using System.Text;
//using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing; 
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Collections;
//using Microsoft.Office.Interop.Excel; //Для экспорта в Excel
using System.Runtime.InteropServices; //Для экспорта в Excel
//using System.Deployment.Application;
using System.Text.RegularExpressions;
//using FastColoredTextBoxNS;
//using Npgsql.BulkCopy;
//using Npgsql.BulkCopy.Native;
//using Npgsql.BulkCopy.Native.Versions;      
using System.Net;
using System.Net.Sockets;
//using FastColoredTextBoxNS; 
using System.Diagnostics;
//using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
namespace FBA
{         
    public partial class FormUtility : FormFBA
    {
        #region Глобальные переменные. Конструктор, инициализация, главное меню.
        
        public bool ServerConnected = false;
                             
        ///Конструктор.
        public FormUtility()
        {     
            InitializeComponent();
            Var.FormMainObj = this;
        }
                                                            
        #endregion
         
        ///Событие. Главное меню.
        private void MainMenu_N1_1Click(object sender, EventArgs e)
        {                         
            if (sender == MainMenu_N1_1)  Environment.Exit(0); 
            if (sender == MainMenu_N2_3)  System.Diagnostics.Process.Start(FBAPath.PathAdditional + @"ColorTable.html");
            if (sender == MainMenu_N2_4)  new FormReg().Show(); 
            if (sender == MainMenu_N2_5)  System.Diagnostics.Process.Start(FBAPath.PathAdditional + @"ASCII.html");
            if (sender == MainMenu_N2_6)  System.Diagnostics.Process.Start(FBAPath.PathAdditional + @"DataTimeFormat.html");           
                       
            if (sender == MainMenu_N2_8)  FBAFile.FileRunEXESimple(FBAPath.PathMain + @"Updater.exe");                  
            if (sender == MainMenu_N2_9)  FBAFile.FileRunEXESimple(FBAPath.PathMain + @"ServerApp.exe");         
            if (sender == MainMenu_N2_10) FBAFile.FileRunEXESimple(FBAPath.PathMain + @"ClientApp.exe");              
          
            if (sender == MainMenu_N4_2)  new FormAbout().Show();              
            if (sender == MainMenu_N2_13) new FormGrant().Show();                 
            if (sender == MainMenu_N2_15) new FormDDL().Show();              
            if (sender == MainMenu_N2_16) new FormModel().Show();              
            if (sender == MainMenu_N2_17) new FormSQL().Show();                 
            if (sender == MainMenu_N2_18) new FormUpdate().Show();                 
            if (sender == MainMenu_N2_19) new FormImage().Show();                 
            if (sender == MainMenu_N2_20) new FormText().Show();                                               
            if (sender == MainMenu_N2_21) new FormParam().Show();                                              
            if (sender == MainMenu_N2_22) new FormStatus().Show();               
            if (sender == MainMenu_N3_1)  new FormConList().Show();
            if (sender == MainMenu_N2_23) new ProjectService("").Show();            
           
            //Выбор шрифт всех форм.
            if (sender == MainMenu_N3_2) 
            {                     
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    Var.font1 = fontDialog1.Font;
                }
            }
            if (sender == MainMenu_N3_3) 
            {                                 
                string Path = "";                  
                if (!FBAFile.DirChoose(Application.StartupPath, out Path)) return;
                sys.ShowSolutionStringCodeCount(Path);
            }
            
            //Сущности.
            if (sender == MainMenu_N2_24)
            {                                       
                sys.ShowDirectorySimple("Entity", "", "", "", null, "SELECT * FROM fbaEntity", "");                
            }
            
            //Атрибуты.
            if (sender == MainMenu_N2_25)
            {                          
                sys.ShowDirectorySimple("Attribute", "", "", "", null, "SELECT * FROM fbaAttribute", "");              
            }
                        
            //Таблицы.
            if (sender == MainMenu_N2_26)
            {      
                sys.ShowDirectorySimple("Table", "", "", "", null, "SELECT * FROM fbaTable", ""); 
            }

            //Шаблоны отчетов.
            if (sender == MainMenu_N2_27) new FormReport().Show();
          
            if (sender == MainMenu_N2_7)  System.Diagnostics.Process.Start(@"https://docs.microsoft.com/ru-ru/dotnet/api/system.windows.media.brushes?view=netcore-3.0");          

            //Ошибки пользователей.
            if (sender == MainMenu_N2_28) new FormError().Show();
           
            //Справка
            if (sender == MainMenu_N4_1) sys.ShowHelp();
            	//Help.ShowHelp(this, sys.PathHelp);
            
            //Форма для добавления методов сущностей.
            if (sender == MainMenu_N2_29) new FormMethod().Show();
        }                         
                     
        //void FormFilterToolStripMenuItemClick(object sender, EventArgs e)
        //{
            //new FormTest1().Show();
            //string[] s = sys.FilesInFolder(@"E:\Мусор\", "*.*", "", "", true, true, true);
            //public static string[,] ArrayView(string CapForm, string CapArray, string[] Arr)
            //sys.ArrayView("", "", s);

        //}
        //private void formtest2ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
            //new FormTest2().Show();
            //string[] s = sys.GetDirs(@"E:\Мусор\");
            //sys.ArrayView("", "", s);
        //}

        void FormUtilityLoad(object sender, EventArgs e)
        {
             //Npgsql.NpgsqlConnection connection45 = new Npgsql.NpgsqlConnection("Server=10.77.70.27;User Id=Postgre;Password=asdzxc;Database=MyProject111111;");
             //onnection45.Open();        
        }              
        
        void textBox1_AfterValueAdd(object sender, EventArgs e)
        {
              //sys.SM("After");
        }
        
        void textBox1_BeforeValueAdd(object sender, EventArgs e)
        {
               //sys.SM("Before");
        }
        
        void textBox1_TextChanged(object sender, EventArgs e)
        {
            //sys.SM("TextChanged");
        }

        
    }      
}
