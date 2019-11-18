
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 26.12.2016
 * Время: 14:11    
 */ 
   
using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using FastColoredTextBoxNS; 

namespace FBA
{    		  	
 	/// <summary>
 	/// Форма для показа сообщения.
 	/// </summary>
    public partial class FormSM : FormSim
    {
        
    	//int[][] a = new int[n][];
        //a[0] = new int[k]{20,6,12,-5,7};
        //a[1] = new int[l]{1,2,9};
        //a[2] = new int[m]{2,11,0,-4};
    	
    	/// <summary>
        /// Если нажата кнопка Ok, то true, Cancel = false
        /// </summary>
    	public bool Result = true;
                             
        /// <summary>
        /// Записать текст ошибки.
        /// </summary>
        /// <param name="ErrorMes"></param>
        private void SetErrorText(string ErrorMes)
        {
        	string UserError;
            string SystemError;
            ParseTextError(ErrorMes, out UserError, out SystemError);
            TextBoxMes.Text  = UserError;
            TextBoxCode.Text = SystemError;
            tabPage1.Text    = "System information";
        	splitContainer1.Panel2Collapsed = false;
        }                     
        
        /// <summary>
        /// Распарсить текст ошибки. Отделить пользовательское от системеного.
        /// </summary>
        /// <param name="ErrorMes"></param>
        /// <param name="UserError"></param>
        /// <param name="SystemError"></param>
        private void ParseTextError(string ErrorMes, out string UserError, out string SystemError)
        {
        	UserError = ErrorMes.StrBeforeStr("Member:");
        	SystemError = "Member:" + ErrorMes.StrAfterStr("Member:");
        }
                  
        /// <summary>
        /// Показ окна сообщения.
        /// </summary>
        /// <param name="Mes">Текст сообщения</param>
        /// <param name="typeMes">Тип сообщения. Один из Error, SystemError, ErrorQuestion, Stop, Information, Warning, Question</param>
        /// <param name="Caption">Заголовок формы сообщения</param>
        public FormSM(string Mes, MessageType typeMes, string Caption)
        {
            TopMost = true;
            InitializeComponent();            
            splitContainer1.Panel2Collapsed = true;
               
            if ((typeMes == MessageType.SystemError))
            {
                if (Caption != "") Text = Caption; else Text = "Error!";                  
                TextBoxMes.BackColor    = Color.AntiqueWhite;
                pictureBox1.Image       = global::FBA.Resource.Error_32;
                button1.Image           = global::FBA.Resource.Danger_24;
                button1.Text            = "  Ok";
                SetErrorText(Mes);
                //ShowCodeText();
                ShowCodeFile();
                //Mes = Mes + Var.CR + GetStackCalls(ex);
            } else 
            if (typeMes == MessageType.Error) 
            {
                if (Caption != "") Text = Caption; else Text = "Error!";                  
                TextBoxMes.BackColor    = Color.AntiqueWhite;
                pictureBox1.Image       = global::FBA.Resource.Error_32;
                button1.Image           = global::FBA.Resource.Danger_24;
                button1.Text            = "  Ok";               
                TextBoxMes.Text         = Mes;                 
            } else 
            if (typeMes == MessageType.ErrorQuestion)
            {
                if (Caption != "") Text = Caption; else Text = "Question!";       
                TextBoxMes.BackColor = Color.AntiqueWhite;
                button2.Visible = true;
                button1.Text = "  Yes";
                button2.Text = "  No";
                pictureBox1.Image = global::FBA.Resource.Error_32;
                button1.Image = global::FBA.Resource.Danger_24;
                SetErrorText(Mes);           
            } else
            if (typeMes == MessageType.Stop) 
            {
                if (Caption != "") Text = Caption; else Text = "Stop!";                  
                TextBoxMes.BackColor    = Color.AntiqueWhite;
                pictureBox1.Image       = global::FBA.Resource.Stop_32;
                button1.Image           = global::FBA.Resource.Danger_24;
                button1.Text            = "  Ok";
                TextBoxMes.Text         = Mes;
            } else           
            if (typeMes == MessageType.Information) 
            {
                if (Caption != "") Text = Caption; else Text = "Information!";                            
                TextBoxMes.BackColor    = Color.FromArgb(255, 255, 192); 
                pictureBox1.Image       = global::FBA.Resource.Information_32;
                button1.Image           = global::FBA.Resource.OK_24;
                button1.Text            = "  Ok";
                TextBoxMes.Text         = Mes;              
            } else                        
            if (typeMes == MessageType.Warning) 
            {
                if (Caption != "") Text = Caption; else Text = "Warning!";                  
                TextBoxMes.BackColor    = Color.LightYellow;
                pictureBox1.Image       = global::FBA.Resource.Warning_32; 
                button1.Image           = global::FBA.Resource.OK_24;
                button1.Text            = "  Ok";
                TextBoxMes.Text         = Mes;
            } else           
            if (typeMes == MessageType.Question) 
            {
                if (Caption != "") Text = Caption; else Text = "Question!";  
                //Color myRgbColor = new Color(); 
                //myRgbColor = Color.FromRgb(0, 255, 0); 
                TextBoxMes.BackColor    = Color.FromArgb(223, 255, 223); //Светло зеленый. Color.LightGreen;               
                button2.Visible         = true;
                button1.Text            = "  Yes";
                button2.Text            = "  No";                 
                pictureBox1.Image       = global::FBA.Resource.Question_32; 
                button1.Image           = global::FBA.Resource.OK_24; 
				TextBoxMes.Text         = Mes;                
            }
            

            pictureBox1.Invalidate();                                    

            if (!this.splitContainer1.Panel2Collapsed) this.Height = 400;
            else if (Mes.Length < 100) this.Height = 200;
            int PosTop;
            int PosLeft;
            if (GetPositionWindowMessage(out PosTop, out PosLeft))
            {
                this.Top = PosTop;
                this.Left = PosLeft;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }
   
        /// <summary>
        /// Получить позицию в которую выводить окно сообщения.
        /// </summary>
        /// <param name="posTop">Позиция слева</param>
        /// <param name="posLeft">Позиция сверху</param>
        /// <returns></returns>
        private bool GetPositionWindowMessage(out int posTop, out int posLeft)
        {
            if (Var.FormMainObj == null)
            {
                posTop = 0;
                posLeft = 0;
                return false;
            }
            //Получаем точку цента главного окна приложения.
            int CenterMainLeft = Var.FormMainObj.Left + (Var.FormMainObj.Width / 2);
            int CenterMainTop  = Var.FormMainObj.Top + (Var.FormMainObj.Height / 2);

            //Пытаемся вывести окно сообщения с центром в этой точке.
            posLeft = CenterMainLeft - (this.Width  / 2);
            posTop  = CenterMainTop  - (this.Height / 2);
            if (posLeft < 0) posLeft = 0;
            if (posTop  < 0) posTop  = 0;
            return true;
        }     
        
        // <summary>
        // Показ вкладки c модулями, в которых произошли ошибки.
        // </summary>
        /*private void ShowCodeText()
        {   
            var Errors = new string[10, 5];
            int Index = 0;
            string Forms = "'aaa'";         
            string FileName;
            for (int i = 0; i <= TextBoxMes.Lines.Count() - 1; i++)
            {
                string s = TextBoxMes.Lines[i];
                int N2 = s.LastIndexOf(@".cs:",    StringComparison.OrdinalIgnoreCase);                
                if (N2 == -1) continue;
                int N3 = s.LastIndexOf(@"строка ", StringComparison.OrdinalIgnoreCase);
                if (N3 == -1) continue;
                int N1 = s.LastIndexOf(@"\",       StringComparison.OrdinalIgnoreCase);
                
                //"\FormEnter.cs:строка 57"
                if (N2 > N1) 
                {
                    FileName  = s.Substring(N1 + 1, N2 - N1 - 1); 
                    Errors[Index, 0] = Index.ToString();     //Порядковый номер, начиная с 0.
                    Errors[Index, 1] = FileName;             //Имя файла.
                    Errors[Index, 2] = s.Substring(N3 + 7).Trim();  //Номер строки с ошибкой.
                    Errors[Index, 3] = i.ToString();         //Номер строки в TextBoxError.
                    Forms += ",'" + FileName + "'";          //Все имена файлов.
                }
                Index++;
                if (Index == 10) break;
            }
            if (Index == 0) return;                                  
            //string FieldCodeText = "TextCodeTest";
            //if (Var.enterMode == EnterMode.Work) FieldCodeText = "TextCode";
            string SQL = "SELECT ID, Name FROM fbaProject WHERE Name IN (" + Forms + ")";            
            System.Data.DataTable DT;
            sys.SelectDT(DirectionQuery.Local, SQL, out DT);
            if (DT.Rows.Count == 0) return;                                                                 
            FileName         = DT.Value(0, "Name");                                    
            tabPage1.Text    = FileName;
            splitContainer1.Panel2Collapsed = false;         
            int N = 0;
            for (int i = 0; i <= Index - 1; i++)
            {
                N = Errors[i, 2].ToInt();
                if (N == 0) continue;
                if (Errors[i, 1] != FileName) continue;                               
                TextBoxCode.BookmarkLine(N-1);                           
            }
            if (N > 0) TextBoxCode.Navigate(N-1);
            
            for (int i = 1; i <= DT.Rows.Count - 1; i++)
            {               
                FileName    = DT.Value(i, "Name");                       
                TabControlPageAdd(tabControl1, TextBoxCode, FileName, "", Errors, Index);
            }                                                                              
            //if (Var.UserIsAdmin) btnSave.Visible = true;                          
            //TextBoxCode.CurrentLineColor = Color.Blue;                       
        }*/          
	
		/// <summary>
		/// Показ вкладки c модулями, в которых произошли ошибки.
		/// </summary>
        private void ShowCodeFile()
        {   
            var Errors = new string[10, 5];
            int Index = 0;
            string Forms = "'aaa'";                              
            for (int i = 0; i <= TextBoxMes.Lines.Count() - 1; i++)
            {
                string s = TextBoxMes.Lines[i];
                int N0 = s.LastIndexOf(@"FBA.", StringComparison.OrdinalIgnoreCase);                
                if (N0 == -1) continue;
                int N1 = s.LastIndexOf(@") в ", StringComparison.OrdinalIgnoreCase);
                if (N1 == -1) continue;
                int N2 = s.LastIndexOf(@".cs:", StringComparison.OrdinalIgnoreCase);
                if (N2 == -1) continue;
                                               
               
                if (N2 > N1) 
                {
                    string FileNameFull  = s.Substring(N1 + 4, N2 - N1 + 3 - 4); 
                    Errors[Index, 0] = Index.ToString();                //Порядковый номер, начиная с 0.
                    Errors[Index, 1] = Path.GetFileName(FileNameFull);  //Имя файла без пути.               
                    Errors[Index, 2] = s.Substring(N2 + 11).Trim();     //Номер строки с ошибкой.
                    Errors[Index, 3] = i.ToString();                    //Номер строки в TextBoxError.
                    Errors[Index, 4] = FileNameFull; 				    //Имя файл c путём.
                    Forms += ",'" + FileNameFull + "'";                 //Все имена файлов.
                }
                Index++;
                if (Index == 10) break;
            }
            if (Index == 0) return;
    
            TextBoxCode.SelectionHighlightingForLineBreaksEnabled = true;
          
            for (int i = 0; i <= Index; i++)
            {                               
                string ResultText;
                int LinesCount;
                string FileNameFull = Errors[i, 4];
                if (FileNameFull == null) continue;
                string FileName     = Errors[i, 1];
                if (FBAFile.FileReadText(FileNameFull, true, out ResultText, out LinesCount))
                	TabControlPageAdd(tabControl1, TextBoxCode, FileName, ResultText, Errors, i + 1); //потому что одна вкладка есть по умолчанию. Поэтому +1.
            }                                                                                                 
        }		
              
        /// <summary>
        /// Добавление новой вкладки для редактора запросов.
        /// </summary>
        /// <param name="tabControlCode"></param>
        /// <param name="textSQLExample"></param>
        /// <param name="FileName"></param>
        /// <param name="Code"></param>
        /// <param name="Errors"></param>
        /// <param name="indexPage"></param>
        public void TabControlPageAdd(TabControl tabControlCode,                                              
                                      FastColoredTextBox textSQLExample,                                                                                     
                                      string FileName,
                                      string Code,
                                      string[,] Errors,
                                      int indexPage)
        {                                           
            FastColoredTextBox fctb1 = null;  
            System.Windows.Forms.TabPage tb = null; 
            int findTab = -1;
        	for (int i = 1; i < tabControlCode.TabPages.Count; i++)
        	{
        		if (tabControlCode.TabPages[i].Text.IndexOfEx(FileName) == 0)
        		{        			
        			       			
        			fctb1 = (FastColoredTextBox) this.Controls.Find("textCode" + i, true).FirstOrDefault();
        			if (fctb1 != null) 
        			{
        				findTab = i;
        				tb = tabControlCode.TabPages[i];
        			}
        			
        		}
        	}
        	
        	if (findTab == -1)
        	{
	        	tabControlCode.TabPages.Add(FileName);
	            fctb1 = new FastColoredTextBox();     
	            tb = tabControlCode.TabPages[tabControlCode.TabPages.Count - 1];
	            tb.Controls.Add(fctb1);
	             
        	}        	
        	
        	if (tb.Tag == null) tb.Tag = 0;
        	tb.Tag = ((int)tb.Tag) + 1;
        	tb.Text = FileName + " (" + tb.Tag + ")";
           
        	fctb1.Dock                          = textSQLExample.Dock;
            fctb1.AutoCompleteBrackets          = textSQLExample.AutoCompleteBrackets;
            fctb1.AutoScrollMinSize             = textSQLExample.AutoScrollMinSize;
            fctb1.BookmarkColor                 = textSQLExample.BookmarkColor;
            fctb1.BracketsHighlightStrategy     = textSQLExample.BracketsHighlightStrategy;
            fctb1.Cursor                        = textSQLExample.Cursor;
            fctb1.DisabledColor                 = textSQLExample.DisabledColor;
            fctb1.FindEndOfFoldingBlockStrategy = textSQLExample.FindEndOfFoldingBlockStrategy;
            fctb1.Font                          = textSQLExample.Font;
            fctb1.Language                      = textSQLExample.Language;
            fctb1.LeftBracket                   = textSQLExample.LeftBracket;
            fctb1.RightBracket                  = textSQLExample.RightBracket;
            //fctb1.Padding                       = textSQLExample.Padding;                
            fctb1.SelectionColor                = Color.Red;//textSQLExample.SelectionColor;
            fctb1.VirtualSpace                  = textSQLExample.VirtualSpace;
            fctb1.Text                          = Code;
            fctb1.Name                          = "textCode" + indexPage;
            fctb1.BackColor                     = textSQLExample.BackColor;
            fctb1.CurrentLineColor              = textSQLExample.CurrentLineColor;
            fctb1.VirtualSpace                  = textSQLExample.VirtualSpace;
            fctb1.BorderStyle                   = textSQLExample.BorderStyle;
            fctb1.ReadOnly                      = true;
            int firstbookmark  = 0;
            for (int i = 0; i <= indexPage - 1; i++)
            {
                if (Errors[i, 1] != FileName) continue;
                int N = Errors[i, 2].ToInt(false);
                if (N > 0) 
                {
                	fctb1.BookmarkLine(N - 1);
                	//fctb1.LineNumberColor = Color.Beige;
                	//fctb1.Navigate(N - 1); 
                	//fctb1.SelectionStart = 1;
                	//fctb1.SelectionLength = (fctb1.GetLineLength(N));
                	//fctb1.SelectionColor = Color.Red;
                	//fctb1.CurrentLineColor = Color.Red;
                	if (firstbookmark == 0) firstbookmark = N - 1;
                }
            }
            if (firstbookmark > 0) fctb1.Navigate(firstbookmark); 
        }
              
		/// <summary>
		/// Кнопка Ok.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void Button1Click(object sender, EventArgs e)
        {
            this.Result = true;
            this.Close();
        }              
        
        /// <summary>
        /// Кнопка Cancel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button2Click(object sender, EventArgs e)
        {
            this.Result = false;
            this.Close();                      
        }
        
        private void FormSMLoad(object sender, EventArgs e)
        {
             //splitContainer1.Panel2Collapsed = true; 
        }
           
        /// <summary>
        /// Галка WordWrap на форме.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CbWordWrapCheckedChanged(object sender, EventArgs e)
        {
            TextBoxMes.WordWrap = cbWordWrap.Checked;
        }      
        
        /// <summary>
        /// Контекстное меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cmMenu_N1_Click(object sender, EventArgs e)
        {
            string ControlName = sys.GetControlNameByMenuStripItem(sender);
            if (ControlName == "TextBoxMes")  TextBoxMes.Text.CopyToClipboard();
            if (ControlName == "TextBoxCode") TextBoxCode.Text.CopyToClipboard();
        
        }
		void Button3Click(object sender, EventArgs e)
		{
			TextBoxCode.Navigate(15);
		}                          
    }
}
