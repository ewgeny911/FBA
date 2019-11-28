
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 30.09.2017
 * Время: 22:30
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
namespace FBA
{      
    
	/// <summary>
	/// Форма для сохранения больших текстов на сервере
	/// </summary>
	public partial class FormText : FormFBA
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
		public FormText()
        {            
            InitializeComponent();             
            this.MdiParent = Var.FormMainObj; 
            this.Icon = this.MdiParent.Icon;  
            TextRefresh();               
            /*System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.GradientActiveCaption; //Control;
            dataGridViewCellStyle21.Font      = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));          
            dataGridViewCellStyle21.WrapMode  = System.Windows.Forms.DataGridViewTriState.True;                
            this.dgvText.DefaultCellStyle     =  dataGridViewCellStyle21;
            this.dgvText.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvText.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;*/             
        }
        
        /*public void tbTextRefresh_Click(object sender, EventArgs e)
        {
            string SenderName = sys.GetSenderName(sender);
            string TextID   = sys.DGSelected(dgvText, "ID"); 
            
            //Обновить таблицу с текстами.
            if (SenderName == "tbTextRefresh") TextRefresh();
            
            //Добавить текст.
            if (SenderName == "tbTextAdd") TextAdd();
            
            //Удалить текст.
            if (SenderName == "tbTextDel") TextDel(TextID);
            
            //Сохранить текст.
            if (SenderName == "tbTextSave") TextSave(TextID);
        } */
        
        ///Добавить текст.
        public bool TextAdd()
        {           
            string NameText  = ""; 
            string ValueText = "";                   
            if (!sys.InputValue2("Введите текст", "Название:", "Текст:", ref NameText, ref ValueText)) return false;       
            string SQL = "INSERT INTO fbaText (" +
                         "UserCreateID, DateCreate, Name, Value) VALUES (" + 
                         Var.UserID  + ", " + sys.DateTimeCurrent() + ",'" + NameText + "','" + ValueText + "')" ;
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false; 
            TextRefresh();
            SelectText();
            sys.SM("Текст добавлен!", MessageType.Information);
            return true;
        }
        
        ///Удалить текст.
        public bool TextDel(string TextID)
        {
            if (TextID == "") return false;
            string SQL = "DELETE FROM fbaText WHERE ID = " + TextID;
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false; 
            TextRefresh();         
            tbName.Text = "";
            tbText.Text = "";
            SelectText();
            sys.SM("Текст удален!", MessageType.Information);
            return true;
        }
        
        ///Сохранить текст.
        public bool TextSave(string TextID)
        {
            if (TextID == "") return false;
            string SQL = "UPDATE fbaText SET " +
                "UserChangeID = " + Var.UserID  +
                ", DateChange = " + sys.DateTimeCurrent() +
                ", Name  = '" + tbName.Text + "'" +
                ", Value = '" + tbText.Text + "'" +
                " WHERE ID = " + TextID;
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false; 
            TextRefresh();
            sys.SM("Текст сохранён!", MessageType.Information);
            return true;                
        }
        
        ///Показ текста.
        public bool TextRefresh()
        {              
        	string SQL =
                    "SELECT ID, " +
                    "Name, " +                                        
        		    sys.GetSubString() + "(Value, 1, 100) AS Text, " +
                    "UserChangeID, " +
                    "UserCreateID, " +
                    "DateChange, " +
                    "DateCreate " +                                   
                    "FROM fbaText";            
               if (!sys.SelectGV(DirectionQuery.Remote, SQL, dgvText)) return false;
               return true;
        }
        
        ///Показ текста.
        private bool SelectText()
        {
            string TextID   = dgvText.Value("ID");             
            if (TextID == "") return false;
            string FileData;
            string TextName;         
            string SQL = "SELECT Value, Name FROM fbaText WHERE ID = " + TextID;
            if (!sys.GetValue(DirectionQuery.Remote, SQL, 
                               out FileData, 
                               out TextName)) return false;
            if (FileData == "") 
            {
                sys.SM("Не найден текст в таблице текстов!");
                return false;
            }            
            tbName.Text = TextName;
            tbText.Text = FileData;  
            return true;
        }
        
               
        //Кнопки контекстного меню на таблице текстов.
        private void cmText_N1_Click(object sender, EventArgs e)
        {
           
            string TextID   = dgvText.Value("ID"); 
                           
            //Добавить текст.
            if ((sender == cmText_N1) || (sender == tbAdd)) TextAdd();
            
            //Удалить текст.
            if ((sender == cmText_N2) || (sender == tbDelete)) TextDel(TextID);
            
            //Сохранить текст.
            if ((sender == cmText_N3) || (sender == tbSave)) TextSave(TextID);
            
            //Обновить таблицу с текстами.
            if ((sender == cmText_N4) || (sender == tbRefresh)) TextRefresh();

			//Преобразовать текст.
            if ((sender == tbTransform)) tbText.Text = sys.TextTransform(tbText.Text, true);             
        }
        
        ///При выборе текста в таблице показываем его. 
		private void DgvTextDoubleClick(object sender, EventArgs e)
		{
	 		SelectText();
		}    
    } 
}
