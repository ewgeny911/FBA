
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 03.06.2017
 * Время: 12:20
 */
 
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Data;  
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
//using Npgsql;
//using System.Data.SQLite;
using System.Drawing;
//using System.Runtime.Serialization.Json;
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
using FastColoredTextBoxNS; 
using System.Diagnostics;
//using SourceGrid;
//using Padeg;
namespace FBA             
{	       
    public partial class FormParser : Form
	{	  	   
    	//[DllImport(@"D:\Дизайнер C#\Дизайнер C#\Sys\bin\Debug\paged.dll", CallingConvention=CallingConvention.StdCall)] 
  		//public static extern bool SetDictionary(string FileName);
        //function SetDictionary(FileName: PChar): Boolean; stdcall; export;
                    
        //[DllImport(@"paged.dll",
        //           CallingConvention = CallingConvention.StdCall,
        //           CharSet = CharSet.Ansi)]
        //public static extern bool SetDictionary(string FileName);    	  
       
        //FormSearch FS;
        
        Parser parser;
                    
        /// <summary>
        /// Инициализация формы.
        /// </summary>
        public FormParser()
        {
            InitializeComponent();  
            Text = "ParserApp: " + System.Windows.Forms.Application.StartupPath;            
        }                                                                            
                             
        ///Сохранить текст MSSQL запроса.
        private void BtnSaveMSQLClick(object sender, EventArgs e)
        {      
            SaveMSQLText();
        }
        
        ///При закрытии формы сохраняем текст запроса.
        private void FormParser_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveMSQLText();
        }
        
        ///Сохранить текст MSSQL запроса.
        private void SaveMSQLText()
        {
            FBAFile.FileWriteTextObject(textQuery, FBAPath.PathSettings + "MSSQL.txt", false);
        }
        
        ///Загрузить текст MSSQL запроса.
        private void FormParserLoad(object sender, EventArgs e)
        {
            FBAFile.FileReadTextObject(textQuery,  FBAPath.PathSettings + "MSSQL.txt");             
            RefreshFiles();           
            sys.ConnectLocal();
            progressBarParser.Value = 0;
        }
        
        ///Парсинг запроса.
        private string Parse(string MSQL, bool Test)
        {                                
            string sql;
            if (!ParserData.IsInitial)
            {
            	sql = ParserData.GetSQLInitial();
	            var DS = new System.Data.DataSet();                                
	            string ErrorText;
	            const bool ErrorShow = true;
	            if (!sys.SelectDS(DirectionQuery.Remote, sql, out DS, out ErrorText, ErrorShow)) return "";
	            ParserData.ParserInitialFromDS(DS);
            }
            
            //Для тестирования. Показываем исходные таблицы.
            if (!Test) 
            {
                dgvEntity.DataSource     = ParserData.DTArEntity;
                dgvAttrParent.DataSource = ParserData.DTArAttrParent;
            }
            
            parser = new Parser();                                  
            sql = parser.ParseTest(MSQL, cbPsevdominEntity.Text, "Sys");  //Результат SQL. 
                               
            if (!Test) 
            {
                txTime.Text = parser.ParseTimeSQL.ToString();    //Для тестирования. Время выполнения процедур парсера.
                //Выходные данные.
                //Таблицы для парсинга, полученные при работе парсера.             
                System.Data.DataTable DTMain;      //Главная таблица, в которой весь запрос.                      
                System.Data.DataTable DTTable;     //Список таблиц, которые используются в выходном запросе SQL. 
                System.Data.DataTable DTEntity;    //Список сущностей, которые используются в исходном запросе MSQL.
                System.Data.DataTable DTUserStr;   //Список строк пользователя в исходном запросе MSQL. 
                System.Data.DataTable DTAttrTable;
                System.Data.DataTable DTStateDate;             
                parser.ReturnTestTable(out DTMain, out DTEntity, out DTTable, out DTUserStr, out DTAttrTable, out DTStateDate);
                               
                //Выходные данные.
                dgvString.DataSource     = DTMain;                                               
                dgvListEntity.DataSource = DTEntity;
                dgvListTable.DataSource  = DTTable;
                dgvUserString.DataSource = DTUserStr;                        
                dgvAttrTable.DataSource  = DTAttrTable; 
                dgvStateDate.DataSource  = DTStateDate; 
                
                dgvString.Columns[0].Width  = 43;
                dgvString.Columns[1].Width  = 111;
                dgvString.Columns[2].Width  = 50;
                dgvString.Columns[3].Width  = 55;
                dgvString.Columns[4].Width  = 58;
                dgvString.Columns[5].Width  = 50;
                dgvString.Columns[6].Width  = 57;
                dgvString.Columns[7].Width  = 101;
                dgvString.Columns[8].Width  = 73;
                dgvString.Columns[9].Width  = 100;
                dgvString.Columns[10].Width = 64;
                dgvString.Columns[11].Width = 50;
                dgvString.Columns[12].Width = 144;
                dgvString.Columns[13].Width = 118;
                dgvString.Columns[14].Width = 59;
                dgvString.Columns[15].Width = 52;
                dgvString.Columns[16].Width = 58;
                dgvString.Columns[17].Width = 57;
                dgvString.Columns[18].Width = 71;
                dgvString.Columns[19].Width = 72;
                dgvString.Columns[20].Width = 76;
                dgvString.Columns[21].Width = 65; 
            }
            return sql;
        }
        
        ///Парсинг запроса.
        private void BtnParseClick(object sender, EventArgs e)
        {                                                       
            string Query = textQuery.SelectedText;
            if (Query == "") Query = textQuery.Text; 
            TexBoxResult.Text = Parse(Query, false);
            tabControlResult.SelectedIndex = 0;
        }
        
        ///Список SQL запросов.
        private void BtnSQL1Click(object sender, EventArgs e)
        {
                       
            //Добавить.
            if (sender == btnSQL1)
            {
                string FileName = "";              
                if (!sys.InputValue("Название запроса", "Введите название запроса:", SizeMode.Small, ValueType.String, ref FileName)) return; 
                ListBox1.Items.Add(FileName);                                           
                ListSQL.Text = "";
                ListBox1.SelectedIndex = ListBox1.Items.Count - 1;
            }
            
            //Удалить.
            if (sender == btnSQL2) 
            {
                string FileName = ListBox1.Items[ListBox1.SelectedIndex].ToString();
                string ErrorMes = "";
                if (!FBAFile.FileDelete(FBAPath.PathSettings + FileName + ".txt", out ErrorMes, true)) return;
                FBAFile.FileDelete(FBAPath.PathSettings + FileName + "_Result.txt", out ErrorMes, true);
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex);               
            }
            
            //Сохранить.
            if (sender == btnSQL3) 
            {
                if (ListBox1.SelectedIndex == -1) 
                {
                    sys.SM("Выберите запрос!");
                    return;
                }
                string FileName = ListBox1.Items[ListBox1.SelectedIndex].ToString();                   
                FBAFile.FileWriteTextObject(ListSQL, FBAPath.PathSettings + FileName + ".txt", false);
                FBAFile.FileWriteTextObject(ListResult, FBAPath.PathSettings + FileName + "_Result.txt", false);                 
            }
            
            //Использовать.
            if (sender == btnSQL4) 
            {
                textQuery.Text = ListSQL.Text;
                tabControl1.SelectedIndex = 1;
            }
            
            //Тест только парсинг.
            if (sender == btnSQL5) RunTest(false, "Test");
                        
            //Тест парсинг и выполнение.
            if (sender == btnSQL6) RunTest(true, "Test");
           
            //Тест парсинг и выполнение.
            if (sender == btnSQL9) RunTest(true, "WORK");
            
            //Переименование.
            if (sender == btnSQL7) 
            {
                string fileName = ListBox1.Items[ListBox1.SelectedIndex].ToString();          
                string fileSource1      = FBAPath.PathSettings + fileName + ".txt";
                string fileSource2      = FBAPath.PathSettings + fileName + "_Result.txt";
                const bool showMes      = true;
                string errorMes     = "";                          
                if (!sys.InputValue("Новое название запроса", "Введите новое название запроса:", SizeMode.Small, ValueType.String, ref fileName)) return;                 
                string fileDestination1 = FBAPath.PathSettings + fileName + ".txt"; 
                string fileDestination2 = FBAPath.PathSettings + fileName + "_Result.txt";                               
                //Переименование файла. FileExists = (Overwrite, Skip, Ask)
                if (File.Exists(fileSource1))
                    if (!FBAFile.FileRename(fileSource1, fileDestination1, FileOverwrite.Ask, showMes, out errorMes)) return;
                if (File.Exists(fileSource2))
                    if (!FBAFile.FileRename(fileSource2, fileDestination2, FileOverwrite.Ask, showMes, out errorMes)) return;
                sys.SM("Запрос переименован!", MessageType.Information);
            }
            
            //Кнопка "Обновить список MSQL запросов".
            if (sender == btnSQL8) 
            {              
                RefreshFiles();
            }
        }
       
        //Обновить список MSQL запросов. 
        private void RefreshFiles()
        {
            ListBox1.Items.Clear();
            FBAFile.ListBoxLoadFiles(ListBox1, FBAPath.PathSettings, "*.*", "", "Result;SQL", false, false, false); 
            if (ListBox1.Items.Count > 0) ListBox1.SelectedIndex = 0;       
        }
        
        
        ///Запуск одного юнит теста.
        private void cmTestList_N1_Click(object sender, EventArgs e)
        {                      
            string TestName = ListBox1.Items[ListBox1.SelectedIndex].ToString();
            
            //Проверка выполнения
            if (sender == cmTestList_N1)
            {               
                //sys.SM(TestName);
                bool Result = RunOneTest(TestName, true);
                if (Result) sys.SM("Успешно", MessageType.Information);
                else sys.SM("Ошибка!");
            }
            
            //Проверка синтаксиса
            if (sender == cmTestList_N2)
            {
                LoadFileSQL(TestName);
                string MSQL = ListSQL.Text;
                string sql  = Parse(MSQL, true);
                string ErrorMes;
                bool ErrorShow = true;   
                sys.CheckSyntaxQuery(DirectionQuery.Remote, sql, out ErrorMes, ErrorShow);
            }
        }
                     
        ///Запуск одного теста.
        private bool RunOneTest(string TestName, bool Run)
        {
            bool ResultStatus = false;                 
            LoadFileSQL(TestName);
            string MSQL = ListSQL.Text;
            string sql  = Parse(MSQL, true);
            if (Run) 
            {           
                if (!sys.ConnectRemoteSilent("test1", EnterMode.Test)) return false;                                              
                try
                {                        
                    string ErrorText = "";
                    const bool ErrorShow = false;
                    var DS = new System.Data.DataSet();
                    if (Var.con.SelectDS(sql, out DS, out ErrorText, ErrorShow))                                     
                    {                            
                        if (ListResult.Text == "")  ResultStatus = true;
                        else
                        {             
                            string Result = DS.Tables[0].Rows[0][0].ToString();
                            if (ListResult.Text == Result) ResultStatus = true;
                            else ResultStatus = false; 
                        }                                             
                    } else 
                    {                       
                        ResultStatus = false;
                    }
                }
                catch 
                {                   
                    ResultStatus = false;     
                }                                                                                                                        
            }
            return ResultStatus;
        }

        ///Запуск всех тестов.
        private void RunTest(bool Run, string TestWord)
        {           
            int ErrorCount = 0; 
            int TestCount  = 0;
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                string TestName = ListBox1.Items[i].ToString() + ".txt";
                if (TestName.IndexOf("Test", StringComparison.OrdinalIgnoreCase) == -1) continue;
                if (TestName.IndexOf("Test", StringComparison.OrdinalIgnoreCase) > -1) TestCount++;
            }   
            
            TextResult.Text = "";
            progressBarParser.Value = 0;
            progressBarParser.Maximum = TestCount;
            
            ParserData.TestON = 0;
            cbTest.Checked = false;           
            if (TestCount == 0) return;                       
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {                     
                string TestName = ListBox1.Items[i].ToString();
                if (TestName.IndexOf(TestWord, StringComparison.OrdinalIgnoreCase) != 0) continue;
                
                DateTime D1 = System.DateTime.Now;                 
                string Result = "";
                if (!RunOneTest(TestName, Run))
                {
                    ErrorCount++;
                    Result = "Ошибка: " + TestName ;
                } else
                {
                    Result = "Успешно: " + TestName;
                }
                DateTime D2 = System.DateTime.Now;
                string DateDiff = sys.GetMSecDiff(D1, D2);               
                TextResult.AppendText(Result + " Время: " + DateDiff + ParserSys.CR);                              
                progressBarParser.Value++; 
                                 
                if (ErrorCount > 0) 
                {
                    lbResultRun.Text = "Результат проверки: ошибок " + ErrorCount + " из " + TestCount;
                    lbResultRun.ForeColor = Color.Red;
                }  else
                {
                    lbResultRun.Text = "Результат проверки: Успешно! Всего тестов " + TestCount;
                    lbResultRun.ForeColor = Color.Green;
                }                   
            }
            progressBarParser.Value = 0;
        }
      
        ///Загрузка файла с запросом.
        private void LoadFileSQL(string TestName) 
        {
            if (TestName == "") return;          
            string FileName = TestName + ".txt";
            if (!FBAFile.FileReadTextObject(ListSQL, FBAPath.PathSettings + FileName)) ListSQL.Text = "";
            
            FileName = TestName + "_Result.txt";
            if (!FBAFile.FileReadTextObject(ListResult, FBAPath.PathSettings + FileName)) ListResult.Text = "";
        }
        
        ///При клике на другой записи в ListBox загружаем запрос.
        private void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex < 0) return;
            string TestName = ListBox1.Items[ListBox1.SelectedIndex].ToString();
            LoadFileSQL(TestName);
        }                                                             
        
        ///Обновить таблицы для парсера. Если таблиц, ещё нет, то будут созданы.
        private void BtnParserCreateTableClick(object sender, EventArgs e)
        {                                                
            sys.ConnectRemote();
            sys.CreateParserLocalTables();
        } 
        
        ///Галка - поверх всех окон: Always on top.
        private void CbOnTopClick(object sender, EventArgs e)
        {
            TopMost = cbOnTop.Checked;
        }                                                         
        
        ///Скрыть часть колонок.
        private void BtnHideColumnsClick(object sender, EventArgs e)
        {           
            for (int i = 4; i < 25; i++)
            {               
                if (i < dgvString.Columns.Count-1) dgvString.Columns[i].Visible = false;
            }                        
        }
        
        ///Показать все колонки.
        private void BtnShowColumnsClick(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvString.Columns.Count; i++)
            {               
                dgvString.Columns[i].Visible = true;
            }  
        }
        
        ///Кнопка выполнить распарсенный MSQL.
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!sys.ConnectRemoteSilent("test1", EnterMode.Test)) return;
            DateTime dt1 = DateTime.Now;           
            string Query = TexBoxResult.SelectedText;
            if (Query == "") Query = TexBoxResult.Text;                          
            if (!sys.SelectGV(DirectionQuery.Remote, Query, dgvResult)) return;
            tabControlResult.SelectedIndex = 1;
            DateTime dt2 = DateTime.Now;
            string DateDiff = sys.GetTimeDiff(dt1, dt2);
            lbTime.Text = "Время: " + DateDiff + " Строк: " + dgvResult.Rows.Count;
        }              
                       
        ///Кнопка проверки синтаксиса.
        private void btnSyntax_Click(object sender, EventArgs e)
        {         
            if (!sys.ConnectRemoteSilent("test1", EnterMode.Test)) return;
            string ErrorMes;
            const bool ErrorShow = true;                                          
            DateTime dt1 = DateTime.Now;   
            string Query = TexBoxResult.SelectedText;
            if (Query == "") Query = TexBoxResult.Text;                       
            sys.CheckSyntaxQuery(DirectionQuery.Remote, Query, out ErrorMes, ErrorShow);
            DateTime dt2 = DateTime.Now;
            string DateDiff = sys.GetTimeDiff(dt1, dt2);           
            //tabControlResult.SelectedIndex = 1;
            lbTime.Text = "Время проверки: " + DateDiff;
        }
                       
        ///Копирование в буфер обмена результата распарсенного запроса.
        private void btnCopy_Click(object sender, EventArgs e)
        {
            TexBoxResult.Text.CopyToClipboard();
        }     
        
        private void cbTest_CheckedChanged(object sender, EventArgs e)
        {
            ParserData.TestON = cbTest.Checked.ToInt();
        }
                          
        private void button3_Click(object sender, EventArgs e)
        {
            //string s = ListResult.Text;      
            //for (int i = 0; i < s.Length; i++) 
            //{       
            //    string CodeStr = ((int)s[i]).ToString();
            //    sys.SM("+" + s[i].ToString() + "+" + CodeStr);
            //}
            //string TagStr     = "Main1.Страхователь.ИНН.JIU.9943;SAVE";
            //string TagStr     = "Main1.Страхователь";
            //string TagStr     = "Main1.Страхователь.ИНН";
            //string QueryName  = ""; 
            //string Attr       = "";
            //string AttrLookup = "";
            //string Setting    = "";
            //sys.ParseTag(TagStr, out QueryName, out Attr, out AttrLookup, out Setting);
        }
        
        ///Контекстное меню поиска по гриду.
        private void cmWords_N1_Click(object sender, EventArgs e)
        {    
            //Возвращает компонент, на котором повешено контекстное меню. 
            object Obj = sys.GetControlByMenuStripItem(sender);                          
            ShowFormSearch((DataGridViewFBA)Obj);
        }
        
        ///Показ формы поиска.
        private void ShowFormSearch(DataGridViewFBA DGV)
        {
            FormSearch.FormSearchShow(this.Name, DGV, null);
        }
        
        ///Перехват CTRL+F на гриде dgvString.
        private void dgvString_KeyDown(object sender, KeyEventArgs e)
        {                                                         
            if (e.Control && e.KeyCode == Keys.F) 
            {    
                ShowFormSearch((DataGridViewFBA)sender);
            } 
            
        }
		void CbOnTopCheckedChanged(object sender, EventArgs e)
		{
	
		}
		void Button2Click(object sender, EventArgs e)
		{
	
		}
     
                           
        /*public void  label1_Paint(object sender, PaintEventArgs e)
        {
             Label a = (Label)sender;
             string measureString = a.Text;         
             SizeF stringSize = new SizeF();
             stringSize = e.Graphics.MeasureString(measureString, a.Font, a.Width);  
             int WidthText = Convert.ToInt32(stringSize.Width) - 5;
                                                           
             e.Graphics.DrawString("*",                   
                      a.Font, //new Font("Arial", 11),            
                      new SolidBrush(Color.Red), 
                      //Прямоугольник, куда вписываем строку                      
                      new Rectangle(WidthText, 0, a.Width - WidthText, a.Height));                      
                                                                                                                         
        }*/
    }
    
   
}
        
     
