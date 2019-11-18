
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 28.09.2017
 * Время: 17:22
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
using Npgsql;
//using System.Data.SQLite;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Collections;
//using Microsoft.Office.Interop.Excel; //Для экспорта в Excel
using System.Runtime.InteropServices; //Для экспорта в Excel
using System.Deployment.Application;
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
//using Padeg.dll;
//using iTextSharp;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Security.Permissions;
    
namespace FBA
{	  
	///Форма для выполнения кода SQL при запросах к локальной или удаленной БД.	
	public partial class FormSQL : FormFBA
	{		
		private int TabIndexSQL = 1;
			
		/// <summary>
		/// Форма для выполнения MSQL или SQL.
		/// </summary>
		public FormSQL()
		{		  
			InitializeComponent();			
            this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;
            this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };


            //this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

        } 
		
		#region Вкладка Database.
        
		
	
				
		/// <summary>
		/// Добавление новой вкладки для редактора запросов.
		/// 	
		///tabControSQL
		///splitContainerSQL
		///панель 1
	   	///	textSQL1
		///панель 2
	    ///    tbSQLResult1
		///pnlResultSQL1
		///tabControlResult
		///	tabPageData - Страница 1		
		///		dgvSQL1
		///	tabPageSQL - Страница 2
		///		fastColoredTextBoxSQL	
		/// </summary>
		/// <param name="tabControSQL"></param>
		/// <param name="splitContainerExample"></param>
		/// <param name="textSQLExample"></param>
		/// <param name="pnlResultSQLExample"></param>
		/// <param name="tbSQLResultExample"></param>
		/// <param name="dgvSQLExample"></param>
		/// <param name="GridContextMenu"></param>
		/// <param name="TabIndexSQL"></param>
        public static void TabControlPageAdd(TabControl tabControSQL, 
                                             SplitContainer     splitContainerExample, 
                                             FastColoredTextBox textSQLExample,
                                             Panel              pnlResultSQLExample,
                                             System.Windows.Forms.TextBox  tbSQLResultExample,
                                             FBA.DataGridViewFBA dgvSQLExample,
                                             ContextMenuStrip GridContextMenu,
                                             ref int TabIndexSQL)
        {                      
            TabIndexSQL += 1;
            string newindexstr = TabIndexSQL.ToString();   
            tabControSQL.TabPages.Add("Query" + TabIndexSQL.ToString());                                
            tabControSQL.TabPages[tabControSQL.TabPages.Count-1].Tag = TabIndexSQL;               
            
            var splitContainerSQL1 = new SplitContainer();
            tabControSQL.TabPages[tabControSQL.TabPages.Count-1].Controls.Add(splitContainerSQL1);
            splitContainerSQL1.Dock = DockStyle.Fill;
            splitContainerSQL1.Orientation      = System.Windows.Forms.Orientation.Horizontal;
            splitContainerSQL1.SplitterDistance = splitContainerExample.SplitterDistance;
            splitContainerSQL1.BackColor        = splitContainerExample.BackColor;          
            
            var textSQL1 = new FastColoredTextBox();
            splitContainerSQL1.Panel1.Controls.Add(textSQL1);
            textSQL1.Dock                          = textSQLExample.Dock;
            textSQL1.AutoCompleteBrackets          = textSQLExample.AutoCompleteBrackets;
            textSQL1.AutoScrollMinSize             = textSQLExample.AutoScrollMinSize;
            textSQL1.BookmarkColor                 = textSQLExample.BookmarkColor;
            textSQL1.BracketsHighlightStrategy     = textSQLExample.BracketsHighlightStrategy;
            textSQL1.Cursor                        = textSQLExample.Cursor;
            textSQL1.DisabledColor                 = textSQLExample.DisabledColor;
            textSQL1.FindEndOfFoldingBlockStrategy = textSQLExample.FindEndOfFoldingBlockStrategy;
            textSQL1.Font                          = textSQLExample.Font;
            textSQL1.Language                      = textSQLExample.Language;
            textSQL1.LeftBracket                   = textSQLExample.LeftBracket;
            textSQL1.RightBracket                  = textSQLExample.RightBracket;
            //textSQL1.Padding                       = textSQLExample.Padding;                
            textSQL1.SelectionColor                = textSQLExample.SelectionColor;
            textSQL1.VirtualSpace                  = textSQLExample.VirtualSpace;
            textSQL1.Name = "textSQL" + newindexstr;
            textSQL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;           
            if (GridContextMenu != null) textSQL1.ContextMenuStrip = GridContextMenu;
            
            var pnlResultSQL1 = new Panel();            
            pnlResultSQL1.Dock      = DockStyle.Top;
            pnlResultSQL1.Height    = pnlResultSQLExample.Height;
            pnlResultSQL1.BackColor = System.Drawing.Color.CornflowerBlue;
                 
			//pnlResultSQL1.BackColor = System.Drawing.Color.CornflowerBlue;
			//pnlResultSQL1.Controls.Add(this.tbSQLResult1);
			//pnlResultSQL1.Dock = System.Windows.Forms.DockStyle.Top;
			//pnlResultSQL1.Location = new System.Drawing.Point(0, 0);		
			//pnlResultSQL1.Size = new System.Drawing.Size(685, 21);     	
            
            var tbSQLResult1 = new System.Windows.Forms.TextBox();
            tbSQLResult1.Font        = tbSQLResultExample.Font;
            tbSQLResult1.Location    = tbSQLResultExample.Location;
            tbSQLResult1.ForeColor   = tbSQLResultExample.ForeColor;
            tbSQLResult1.Text        = " Result";
            tbSQLResult1.BorderStyle = tbSQLResultExample.BorderStyle; 
            tbSQLResult1.BackColor   = tbSQLResultExample.BackColor;
            tbSQLResult1.Width       = tbSQLResultExample.Width;           
            tbSQLResult1.Name        = "tbSQLResult" + newindexstr;                
            pnlResultSQL1.Controls.Add(tbSQLResult1);
                       
			//Теперь страница 2. нижняя.
			
			//TabControl
			var tabControlResult1 = new System.Windows.Forms.TabControl();            
			tabControlResult1.Dock = System.Windows.Forms.DockStyle.Fill;
			tabControlResult1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			tabControlResult1.Location = new System.Drawing.Point(0, 21);
			tabControlResult1.Name = "tabControlResult";
			tabControlResult1.SelectedIndex = 0;
			tabControlResult1.Size = new System.Drawing.Size(685, 140);
			tabControlResult1.TabIndex = 5;							
			splitContainerSQL1.Panel2.Controls.Add(tabControlResult1);
			splitContainerSQL1.Panel2.Controls.Add(pnlResultSQL1);					
			
            //TabControl - Страница 1
            var tabPageData1 = new System.Windows.Forms.TabPage();			
			tabPageData1.Location = new System.Drawing.Point(4, 26);
			tabPageData1.Name = "tabPageData1";
			tabPageData1.Padding = new System.Windows.Forms.Padding(3);
			tabPageData1.Size = new System.Drawing.Size(677, 110);
			tabPageData1.TabIndex = 0;
			tabPageData1.Text = "Data";
			tabPageData1.UseVisualStyleBackColor = true;
			tabControlResult1.Controls.Add(tabPageData1);
						
			//TabControl - Страница 2            
			var tabPageSQL1 = new System.Windows.Forms.TabPage();			
			tabPageSQL1.Location = new System.Drawing.Point(4, 26);
			tabPageSQL1.Name = "tabPageSQL1";
			tabPageSQL1.Padding = new System.Windows.Forms.Padding(3);
			tabPageSQL1.Size = new System.Drawing.Size(677, 110);
			tabPageSQL1.TabIndex = 1;
			tabPageSQL1.Text = "SQL";
			tabPageSQL1.UseVisualStyleBackColor = true;
			tabControlResult1.Controls.Add(tabPageSQL1);
			tabControSQL.SelectedIndex = tabControSQL.TabPages.Count-1;  
			
            //Грид на странице 1
			var dgvSQL1 = new DataGridViewFBA();  			       
            dgvSQL1.Dock = DockStyle.Fill;
            dgvSQL1.AllowUserToAddRows              = dgvSQLExample.AllowUserToAddRows;
            dgvSQL1.AllowUserToDeleteRows           = dgvSQLExample.AllowUserToDeleteRows;
            dgvSQL1.AllowUserToOrderColumns         = dgvSQLExample.AllowUserToOrderColumns;
            dgvSQL1.AlternatingRowsDefaultCellStyle = dgvSQLExample.AlternatingRowsDefaultCellStyle;
            dgvSQL1.AutoSizeColumnsMode             = dgvSQLExample.AutoSizeColumnsMode;
            dgvSQL1.BackgroundColor                 = dgvSQLExample.BackgroundColor;
            dgvSQL1.ClipboardCopyMode               = dgvSQLExample.ClipboardCopyMode;               
            dgvSQL1.ColumnHeadersBorderStyle        = dgvSQLExample.ColumnHeadersBorderStyle;
            dgvSQL1.ColumnHeadersHeightSizeMode     = dgvSQLExample.ColumnHeadersHeightSizeMode;
            dgvSQL1.ContextMenuStrip                = dgvSQLExample.ContextMenuStrip;
            dgvSQL1.DefaultCellStyle                = dgvSQLExample.DefaultCellStyle;                    
            dgvSQL1.EditMode                        = dgvSQLExample.EditMode;                             
            dgvSQL1.Margin                          = dgvSQLExample.Margin;                    
            dgvSQL1.ReadOnly                        = dgvSQLExample.ReadOnly;                
            dgvSQL1.RowHeadersVisible               = dgvSQLExample.RowHeadersVisible;
            dgvSQL1.RowsDefaultCellStyle            = dgvSQLExample.RowsDefaultCellStyle;
            dgvSQL1.RowTemplate                     = dgvSQLExample.RowTemplate; 
            dgvSQL1.BringToFront();
            dgvSQL1.Name                            = "dgvSQL" + newindexstr; 
            tabPageData1.Controls.Add(dgvSQL1);   
												
			//Текст на странице 2.
			var fastColoredTextBoxSQL1 = new FastColoredTextBoxNS.FastColoredTextBox();			
			fastColoredTextBoxSQL1.AutoCompleteBracketsList = new char[] {
			'(',')','{','}','[',']','\"','\"','\'','\''};
			fastColoredTextBoxSQL1.AutoIndentCharsPatterns = "";
			fastColoredTextBoxSQL1.AutoScrollMinSize = new System.Drawing.Size(33, 21);
			fastColoredTextBoxSQL1.BackBrush = null;
			fastColoredTextBoxSQL1.BookmarkColor = System.Drawing.Color.Red;
			fastColoredTextBoxSQL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			fastColoredTextBoxSQL1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			fastColoredTextBoxSQL1.CharHeight = 21;
			fastColoredTextBoxSQL1.CharWidth = 11;
			fastColoredTextBoxSQL1.CommentPrefix = "--";			
			fastColoredTextBoxSQL1.Cursor = System.Windows.Forms.Cursors.IBeam;
			fastColoredTextBoxSQL1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			fastColoredTextBoxSQL1.Dock = System.Windows.Forms.DockStyle.Fill;
			fastColoredTextBoxSQL1.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			fastColoredTextBoxSQL1.Font = new System.Drawing.Font("Courier New", 14.25F);
			fastColoredTextBoxSQL1.IsReplaceMode = false;
			fastColoredTextBoxSQL1.Language = FastColoredTextBoxNS.Language.SQL;
			fastColoredTextBoxSQL1.LeftBracket = '(';
			fastColoredTextBoxSQL1.Location = new System.Drawing.Point(3, 3);
			fastColoredTextBoxSQL1.Name = "fastColoredTextBoxSQL" + newindexstr;
			fastColoredTextBoxSQL1.Paddings = new System.Windows.Forms.Padding(0);
			fastColoredTextBoxSQL1.RightBracket = ')';
			fastColoredTextBoxSQL1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			fastColoredTextBoxSQL1.Size = new System.Drawing.Size(671, 104);
			fastColoredTextBoxSQL1.TabIndex = 16;
			fastColoredTextBoxSQL1.VirtualSpace = true;
			fastColoredTextBoxSQL1.Zoom = 100;
			tabPageSQL1.Controls.Add(fastColoredTextBoxSQL1);			
        }	
					
        ///Событие. Кнопки редактора запросов        
        private void TbSQL1Click(object sender, EventArgs e)
        {                                  
            string indexstr = tabControlSQL1.SelectedTab.Tag.ToString(); 
            //FastColoredTextBox f;
            //var textSQL11 = tabControSQL.Controls.Find("sdF").
            var textSQL = (FastColoredTextBox)tabControlSQL1.Controls.Find("textSQL" + indexstr, true).First();                
            var dgvSQL  = (DataGridViewFBA)tabControlSQL1.Controls.Find("dgvSQL" + indexstr, true).First(); //textSQL1
            var fastColoredTextBoxSQL = (FastColoredTextBoxNS.FastColoredTextBox)tabControlSQL1.Controls.Find("fastColoredTextBoxSQL" + indexstr, true).First();
            	
            if ((sender == textSQL) && (textSQL.Text == "")) textSQL.AppendText("SELECT * FROM fbaEnterHist");
            
            //Выполнить запрос.
            if (sender == tbSQL1)
            {                                    
            	var tbSQLResult = (TextBox)tabControlSQL1.Controls.Find("tbSQLResult" + indexstr, true).First();
                string SQL = textSQL.SelectedText;
                if (SQL == "") SQL = textSQL.Text;

                string ExecTextSQL = SQL;             
                if (cb_MSQL_SQL.Checked) ExecTextSQL = sys.Parse(SQL);
                DateTime DateTime1 = DateTime.Now;
                sys.RefreshGrid(GetDirection(), dgvSQL, ExecTextSQL);                                                         
                tbSQLResult.Text = " Rows: " + dgvSQL.RowCount + "    Execute time: " + sys.GetTimeDiff(DateTime1, DateTime.Now);
            }
            
            //Распарсить запрос.
            if (sender == tbSQL7)
            {                     
                var tbSQLResult = (TextBox)tabControlSQL1.Controls.Find("tbSQLResult" + indexstr, true).First();                                                                    
                string SQL = textSQL.SelectedText;
                if (SQL == "") SQL = textSQL.Text;

                string ExecTextSQL = SQL;
				DateTime DateTime1 = DateTime.Now;                
                if (cb_MSQL_SQL.Checked) ExecTextSQL = sys.Parse(SQL);
                fastColoredTextBoxSQL.Text = ExecTextSQL;
                tbSQLResult.Text = " Execute time: " + sys.GetTimeDiff(DateTime1, DateTime.Now);
            }            
            
            //Очистка редактора запросов
            if (sender == tbSQL2) textSQL.Clear();                               
                                 
            //Export to Excel
            if (sender == cm4) dgvSQL.ExportToExcel();
            
            //Новая вкладка.
            //В процедуру передаются компоненты с перовой вкладки (которая никогда не удаляется)
            //чтобы на их примере сделать новую вкладку.
            //Можно было бы и без них - но тогда пришлось бы каждый раз в коде изменять свойства компонентов.
            if (sender == tbSQL3)                           
                TabControlPageAdd(tabControlSQL1, splitContainerSQL1, textSQL, pnlResultSQL1, tbSQLResult1, dgvSQL1, cmGrid, ref TabIndexSQL);
                          
            //Удалить вкладку
            if ((sender == tbSQL4) && (tabControlSQL1.TabPages.Count > 1)) tabControlSQL1.SelectedTab.Dispose(); 
           
            //Открыть из CSV.
            if (sender == tbSQL5)
            {
                string FileName = "";
                string ErrorMes = "";
                const bool ErrorShow = true;
                const string InitialDirectory = "";
                if (!FBAFile.OpenFileName("", "CSV Files|*.csv|All Files|*.*", InitialDirectory, ref FileName)) return;
                System.Data.DataTable DT;
                sys.CSVToDataTable(out DT, FileName, out ErrorMes, ErrorShow);
                dgvSQL.DataSource = DT;
            }
            
            //Сохранить текст запроса.
            if (sender == tbSQL6)
            {                 
                string FileName = "";             
                if (!FBAFile.SaveFileName("Save SQL", "SQL Files|*.sql|All Files|*.*", "", 0, ref FileName)) return;
                FBAFile.FileWriteTextObject(textSQL, FileName, true);
            }
                       
            //Copy to Remote Database
            if (sender == cm1)
            {
                string SQL;
                string ServerTableName = "MyTableName";
                //if (Var.con.serverTypeRemote == ServerType.MSSQL) ServerTableName = "dbo.MyTableName";                                
                if (!sys.InputValue("Имя таблицы на сервере", "Имя таблицы", SizeMode.Small, ValueType.String, ref ServerTableName)) return; 
                var DT = (DataTable)dgvSQL.DataSource;                                
                if (Var.con.serverTypeRemote == ServerType.MSSQL)
                {                        
                    //Способ Var.con.MSSQLCopyTableToServer работает быстрее для MSSQL, чем sys.GetTextTableToDatabase.
                    Var.con.MSSQLCopyTableToServer(DT, ServerTableName);
                } 
                if (Var.con.serverTypeRemote == ServerType.Postgre)
                {
                    SQL = sys.GetTextTableToDatabase(Var.con.serverTypeRemote, ServerTableName, DT, true);                
                    sys.Exec(DirectionQuery.Remote, SQL); 
                }                 
                sys.SM("Таблица " + ServerTableName + " загружена на сервер " + Var.con.serverType, MessageType.Information);    
            } 
            
            //Copy to Local Database
            if (sender == cm2)
            {
                string ServerTableName = "MyTableName";                                  
                if (!sys.InputValue("Имя таблицы на сервере", "Имя таблицы", SizeMode.Small, ValueType.String, ref ServerTableName)) return; 
                var DT = (DataTable)dgvSQL.DataSource;                           
                string SQL = sys.GetTextTableToDatabase(ServerType.SQLite, ServerTableName, DT, true);                
                Var.conLite.Exec(SQL);   
                sys.SM("Таблица " + ServerTableName + " сохранена в локальной базе данных SQLite", MessageType.Information);                
            } 
            
            //Export to CSV
            if (sender == cm3)
            {
                string FileName = "Table_" + sys.GetDate4FileName(DateTime.Now) + ".csv";
                var DT = (DataTable)dgvSQL.DataSource;       
                const string InitialDirectory = "";
                if (!FBAFile.SaveFileName("Import object", "XLS Files|*.xls|All Files|*.*", InitialDirectory, 0, ref FileName)) return;
                if (!sys.DataTableToCSV(DT, FileName, true)) return;
                //sys.SM("Таблица сохранена в файл: " + FileName, MessageType.Information);  
                //sys.FileRunSimple(FileName);
                FBAFile.FileRunNotebook(FileName);                     
            }
            
            //Export to XLS            
            if (sender == cm4)
            {                  
                var DT = (DataTable)dgvSQL.DataSource;                      
                if (!sys.DataTableToExcel(DT)) return;
                sys.SM("Таблица выгружена в файл XLS", MessageType.Information);  
            }                           
        }
        
             
         
        internal static XmlReader ToXmlReader(string value)
        {
            var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = true, IgnoreComments = true };
            var xmlReader = XmlReader.Create(new StringReader(value), settings);
            xmlReader.Read();
            return xmlReader;
        }
        
        ///События контекстного меню на гриде.
        private void cmGrid_N1_Click(object sender, EventArgs e)
        {
            string SenderName = sys.GetSenderName(sender);
            string indexstr = tabControlSQL1.SelectedTab.Tag.ToString(); 
            
            var textSQL = (FastColoredTextBox)tabControlSQL1.Controls.Find("textSQL" + indexstr, true).First();                
            //var dgvSQL  = (DataGridView)tabControSQL.Controls.Find("dgvSQL" + indexstr, true).First();
            
            //Обрамление кавычками.
            if (sender == cmGrid_N1)
            {
                var TempText = new StringBuilder();
                for (int i = 0; i < textSQL.Lines.Count(); i++) 
                {
                    if (i < (textSQL.Lines.Count() - 1))
                        TempText.Append("\"" + textSQL.Lines[i] + "\" + Var.CR +" + Var.CR);
                    else
                        TempText.Append("\"" + textSQL.Lines[i] + "\";");                
                }
                textSQL.Text = TempText.ToString();
            }
            
            //Очистка текста.
            if (sender == cmGrid_N2) textSQL.Text = "";
            
            //Преобразовать в Insert.
            if (sender == cmGrid_N3)
            {               
                TextBox tb1 = new TextBox();
                tb1.Text = Clipboard.GetText();   
                if (tb1.Text == "") return;
                StringBuilder TempText = new StringBuilder();
                TempText.Append("SELECT * INTO #TempTable" + Var.CR + "FROM (" + Var.CR);
                     
                for (int i = 0; i < tb1.Lines.Count(); i++) 
                {                   
                    string TempS = tb1.Lines[i];
                    if (TempS == "") continue;
                    string Columns = "";
                    if (i == 0) Columns = GetColumnNames(TempS, true);
                    else Columns = GetColumnNames(TempS, false); 
                    if (i < (tb1.Lines.Count() - 2)) 
                    {
                        if (tb1.Lines[i + 1] != "")
                        Columns = Columns + " UNION ALL";
                    }
                    TempText.Append(Columns + Var.CR);
                } 
                TempText.Append(") t" + Var.CR + "SELECT * FROM #TempTable");
                textSQL.Text = TempText.ToString();
            }            
        }
        
        ///Получить строку с названиями колонок Column1, Column2, Column3...
        private string GetColumnNames(string InputStr, bool AddColumns)
        {             
            int N = InputStr.IndexOf((char)9);
            if (N == -1) return InputStr;           
            int ColumnCount = 1;
            while (N > -1)
            {
                InputStr = InputStr.Remove(N, 1);
                if (AddColumns) 
                    InputStr = InputStr.Insert(N, "' AS Column" + ColumnCount.ToString() + ", '");
                else
                    InputStr = InputStr.Insert(N, "', '"); 
                ColumnCount++;
                N = InputStr.IndexOf((char)9);
            } 
            if (AddColumns) InputStr = "SELECT '" + InputStr + "' AS Column" + ColumnCount.ToString();
            else InputStr = "SELECT '" + InputStr + "'";
            return InputStr;
        }
        
            
        ///При переключении базы.
        private void tbSQL5_TextChanged(object sender, EventArgs e)
        {
            GetListTable(GetDirection());
        }
        
        ///Получить список таблиц из бызы.
        private void GetListTable(DirectionQuery direction)
        {
            string SQL = "";                              
            switch (Var.con.serverTypeRemote)
            {
                case ServerType.Postgre : SQL = "select (TABLE_SCHEMA + '.' + TABLE_NAME) AS 'Table name' from INFORMATION_SCHEMA.TABLES order by 1"; break;
                case ServerType.SQLite   : SQL = "select Name AS 'Table name' from sqlite_master where type = 'table'"; break;
                case ServerType.MSSQL    : SQL = "select (TABLE_SCHEMA + '.' + TABLE_NAME) AS 'Table name' from INFORMATION_SCHEMA.TABLES order by 1"; break;
            }

            if (SQL == "") return;
            sys.RefreshGrid(direction, dgvTableList, SQL);  
            dgvTableList.Columns[0].Width  = 200;
          
        }
        
        ///При показе формы.
        private void FormSQL_Shown(object sender, EventArgs e)
        {           
        	GetListTable(GetDirection());
        }

        private DirectionQuery GetDirection()
        {
        	if (tbSQL5.Text == "Remote") return DirectionQuery.Remote;
        	return DirectionQuery.Local;
        }


        #endregion

        private void cb_MSQL_SQL_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_MSQL_SQL.Checked) 
            {
            	cb_MSQL_SQL.Text = "MSQL";  
            	cb_MSQL_SQL.BackColor =  Color.FromArgb(255, 128, 0); 
            }	else 
            {
            	cb_MSQL_SQL.Text = "SQL"; 
            	cb_MSQL_SQL.BackColor =  Color.FromArgb(192, 192, 255); 
            }
        }
        
        ///Выполнение кода по кнопке F5.
		private void TextSQL1KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5) 
            {    
				TbSQL1Click(sender, null);
            } 
		} 

		///Перехват нажатий кнопок, когда форма в фокусе.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {            
            const int WM_KEYDOWN    = 0x100;
            const int WM_SYSKEYDOWN = 0x104;            
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {            
            	if (keyData == Keys.F5)
            	{            		
            		TbSQL1Click(tbSQL1, null);
            		//return true;
            	}
            }
            return false;
        }
    }
}
