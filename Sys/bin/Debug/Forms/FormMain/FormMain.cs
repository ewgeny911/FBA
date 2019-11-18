
/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 08.09.2017
 * Время: 18:05
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlTypes;
using System.CodeDom.Compiler;
using Microsoft.CSharp; 
using System.Reflection;  
using System.IO;
using System.Data;  
using System.Security.Cryptography;
using System.Text; 
using System.Data.SqlClient;
//using System.Runtime.Serialization.Json; 
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
//using System.Drawing;
//using System.Windows.Forms;
//using System.Collections;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using FBA;
//using Akka;
//using Akka.Actor;

namespace FBA
{   
    /// <summary>
    /// Description of MainForm.    
    /// </summary>
    public partial class FormMain : FormFBA
    {             
        public FormMain()
        {            
            InitializeComponent();
           // this.FormNumber = 0;
            //sys.ConnectLocal();
            //sys.ConnectRemote();
            Var.FormMainObj = this; 
            //this.Icon = global::FBA.Resource1.DMS2;
           
        }
        private void MainMenu_N2_4_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_N1_1_Click(object sender, EventArgs e)
        {                                                                      
            if (sender == MainMenu_N1_1) sys.ChangeUserPass();
            if (sender == MainMenu_N1_2) Environment.Exit(0);
            
            if (sender == MainMenu_N2_1) sys.ShowDirectorySimple("Contract", "FormContract", "FormContractCard", null, null, null, null);
            if (sender == MainMenu_N2_2) sys.ShowDirectorySimple("Face", null, null, null, null, null, null);
            if (sender == MainMenu_N2_3)
            { 
            	 
                //int FormNumberLocal = 0;
                //object[] ParamArray = null; //new object[1];
                //ParamArray[0] = 0;
                //ProjectService.FormShow("FormCallCenter", "FormCallCenter", out FormNumberLocal, ParamArray);
                
                 var arrvp = new ValueParam[4];				 	
				 
                 //Вариант 1 установки DataSet для ComboBox. Запрос MSQL.	
                 arrvp[0].captionValue = "Выберите сущность"; 
				 arrvp[0].isComboBox = true;				
				 arrvp[0].value = "Сущности"; 				 							
				 arrvp[0].msql  = "SELECT Brief FROM fbaEntity";
				 				 
				 //Вариант 1 установки DataSet для ComboBox. Запрос MSQL.
				 arrvp[1].captionValue = "Выберите таблицу";
				 arrvp[1].isComboBox = true;				 
				 arrvp[1].value = ""; 				 				
				 arrvp[1].sql  = "SELECT Name FROM fbaTable";
				
				 arrvp[2].captionValue = "Выберите атрибут";
				 arrvp[2].value = "Атрибуты";				 
				 arrvp[2].isComboBox = true;
								 			
				 //Это TextBox
				 arrvp[3].captionValue = "Комментарий"; 
				 arrvp[3].isComboBox = false;
				 arrvp[3].value = "";
				 arrvp[3].height = 100;
				 arrvp[3].scrolls = System.Windows.Forms.ScrollBars.Both;
				 arrvp[3].wordwrap = true;				 			
				 				 					
				 var frm = new FormValue("Введите номер и серию договора", arrvp);				 
				 //Все созданые ComboBox и TextBox доступны через массивы comboBoxArray и textBoxArray.
				 frm.comboBoxArray[2].SetDataSourceMSQL("SELECT Name FROM fbaAttribute");
				 				 
				 if (frm.ShowDialog() != DialogResult.OK) return;
		         string valueText1 = frm.GetValue(0);
		         string valueText2 = frm.GetValue(1);
		         string valueText3 = frm.GetValue(2);
		         string valueText4 = frm.GetValue(3);
		         sys.SM("valueText1=" + valueText1 + Var.CR + 
		                "valueText2=" + valueText2 + Var.CR + 
		                "valueText3=" + valueText3 + Var.CR + 
		                "valueText4=" + valueText4 + Var.CR
		               );
                
            }

            //Report XLSX Sample .
            if (sender == MainMenu_N2_4)
            {
                int FormNumberLocal = 0;
                object[] ParamArray = null; //new object[1];
                ProjectService.FormShow("FormReportSample", "FormReportSample", out FormNumberLocal, ParamArray);
            }

            //Открыть документы по ссылке.
            if (sender == MainMenu_N2_6)
            {
                string ValueText = "";
                                 
                if (!sys.InputValue("List of values", "Input links:", SizeMode.Large, ValueType.String, ref ValueText)) return;
                string[] ListObjectID = ValueText.Split('\n');
                sys.ShowDirectorySimple("ДогСтрах", "FormContract", "FormContractCard", null, ListObjectID, null, null);
            }
            
            //Открыть справку
            if (sender == MainMenu_N3_1) sys.ShowHelp();
            
            if (sender == MainMenu_N3_2) new FormAbout().Show();
             
            //Открыть документы по ссылке.
            if (sender == MainMenu_N3_3) sys.ShowDocumentation();
                      
        }


        private void AddMenuItems()
        {
            //Add to main menu
            //MenuItem newMenuItem1 = new MenuItem();
            //newMenuItem1.Header = "Test 123";
           // this.MainMenu.Items.Add(newMenuItem1);

            //Add to a sub item
            //MenuItem newMenuItem2 = new MenuItem();
            //MenuItem newExistMenuItem = (MenuItem)this.MainMenu.Items[0];
            //newMenuItem2.Header = "Test 456";
            //newExistMenuItem.Items.Add(newMenuItem2);


            //ToolStripMenuItem it  = new ToolStripMenuItem();
            //ToolStripMenuItem it2 = new ToolStripMenuItem();
            //it.Text = "1212";
            //it2.Text = "!!!!";

            //menuStrip1.Items.Add(it);
            //menuStrip1.Items.Add(it2);


        }

        //private void ShowContracts()
        //{/    
        //    sys.ShowDirectorySimple("ДогСтрах", "FormContract", "FormContractCard");         
        //}
        
        private void FormMainDMS_Load(object sender, EventArgs e)
        {
            
            /*Bitmap image1 = new Bitmap(@"E:\Мусор\picture.bmp", true);
                    Graphics g1 = panel1.CreateGraphics();
                    g1.DrawImage(image1, new Point(5, 5));
            
             */
            //foreach (Control ctl in this.Controls)
            //{
             //   if (ctl.GetType().ToString() == "System.Windows.Forms.MdiClient")
             //   {
                    //((MdiClient)ctl).BackColor = this.BackColor;
                    
                    //Bitmap image = new Bitmap(@"E:\Мусор\picture.bmp", true);
                    //Graphics g = ((MdiClient)ctl).CreateGraphics();
                    //g.DrawImage(image, new Point(5, 5));
            //    }
            //}
        }
        
        /*private void PaintBackground(Graphics g)
        {
            //Create a brush
            Rectangle rect = this.ClientRectangle;
            rect.Inflate(2,2);// to completely fill the client area
            const int Angle = 60;
            LinearGradientBrush filler = new LinearGradientBrush(
                rect, 
                Color.DarkGray,
                Color.DimGray,
                
                Angle);
                //this._backColor1, 
                //this._backColor2, 
                //this._angle);
            //Fill the client area
            g.FillRectangle(filler,rect);
            //Draw image centered, 
            //We use here forms "BackgroundImage" property. Nothing special...
            if( this.BackgroundImage != null)
            {
                //Make it transparent if you like!!!
                //((Bitmap)this.BackgroundImage).MakeTransparent();
                int x= (this.ClientRectangle.Width/2)  - (this.BackgroundImage.Width/2);
                int y= (this.ClientRectangle.Height/2) - (this.BackgroundImage.Height/2);
                g.DrawImageUnscaled(this.BackgroundImage, x, y);    
            }
            filler.Dispose();
        }*/
        
        void FormMainDMS_Shown(object sender, EventArgs e)
        {
             //Bitmap image1 = new Bitmap(@"E:\Мусор\picture.bmp", true);
             //       Graphics g1 = panel1.CreateGraphics();
             //       g1.DrawImage(image1, new Point(5, 5));
             //      foreach (Control ctl in this.Controls)
            /*{
                if (ctl.GetType().ToString() == "System.Windows.Forms.MdiClient")
                {
                    //Работает! ((MdiClient)ctl).BackColor = this.BackColor;
                    
                    Bitmap image = new Bitmap(@"E:\Мусор\picture.bmp", true);
                    Graphics g = ((MdiClient)ctl).CreateGraphics();
                    g.DrawImage(image, new Point(5, 5));
                }
            }*/
        }

        private void MainMenu_N2_5_Click(object sender, EventArgs e)
        {
            FormFBA F1 = new FormImport();
            F1.Show();
        }
        
				
		
		void ToolStripMenuItem1Click(object sender, EventArgs e)
		{
		 	ValueParam[] arrvp = new ValueParam[2];
			//arrvp[0].type = FBA.TextBoxFBA; 
			arrvp[0].value = "Номер договора"; 	
			//arrvp[1]
			arrvp[1].value = "Серия договора"; 
			var frm = new FormValue("Введите номер и серию договора", arrvp);
			if (frm.ShowDialog() != DialogResult.OK) return ;
	        string valueText1 = frm.GetValue(0);
	        string valueText2 = frm.GetValue(1);
		}
		
		
		/*void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
	
		}
		
		void TextBox1Leave(object sender, EventArgs e)
		{
			 if (string.IsNullOrEmpty(textBox1.Text))
			 {
		         textBox1.Font = new System.Drawing.Font("Courier New", 25.25F);
		         textBox1.Text = "Введите текст";
			 }
		}
		
		void TextBox1Enter(object sender, EventArgs e)
		{
			if (textBox1.Text == "Введите текст") textBox1.Text = "";
		    textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
		}
		
		void TextBox1MouseDown(object sender, MouseEventArgs e)
		{
		    //if (textBox1.Text == "Введите текст") textBox1.Text = "";
		    //textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
		}
		*/
		




        //Form FormContract = new Form();
        //FormContract.MdiParent = this;
        //FormContract.Show();

        //new FormAbout().Show();
        // 


        //FormFBA FormFilter = new FormFilter1();           
        //Form Form1 = new FormMainFilter();           
        //Control pnlFilter1 = Form1.Controls.Find("pnlFilter", true).FirstOrDefault();
        // Control pnlFilter2  = FormFilter.Controls.Find("pnlFilter", true).FirstOrDefault();;
        //pnlFilter1.Parent  = pnlFilter2;
        //FormFilter.Show();     

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
