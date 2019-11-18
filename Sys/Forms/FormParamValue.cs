
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 07.10.2017
 * Время: 21:41
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
namespace FBA
{
    ///Свойства параметра приложения.
    public partial class FormParamValue : FormFBA
    {
        /// <summary>
        /// ИД параметра
        /// </summary>
    	public string ParamID      = "";
    	
    	/// <summary>
    	/// Имя параметра
    	/// </summary>
        public string ParamName    = "";
        
        /// <summary>
        /// Комментарий параметра
        /// </summary>
        public string ParamComment = ""; 
        
        /// <summary>
        /// Значения параметра. Всего может быть 10 значений у параметра. Все текстовые.
        /// </summary>
        public string[] values;        
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ParamID"></param>
        /// <param name="ParamName"></param>
        /// <param name="ParamComment"></param>
        /// <param name="values"></param>
        public FormParamValue(string ParamID, string ParamName, string ParamComment, string[] values)
        {            
            InitializeComponent(); 
            this.ParamID      = ParamID;
            this.ParamName    = ParamName;
            this.ParamComment = ParamComment;
            this.values       = values;
            
            tbName.Text       = ParamName;
            tbComment.Text    = ParamComment;
            textBox1.Text     = values[0];
            textBox2.Text     = values[1];
            textBox3.Text     = values[2];
            textBox4.Text     = values[3];
            textBox5.Text     = values[4];
            textBox6.Text     = values[5];
            textBox7.Text     = values[6];
            textBox8.Text     = values[7];
            textBox9.Text     = values[8];
            textBox10.Text    = values[9];

            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;         
        }
        
        ///Закрытие формы.
        private void FormParamValueFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK) return;        
            ParamName    = tbName.Text;
            ParamComment = tbComment.Text;
            values[0]  = textBox1.Text;
            values[1]  = textBox2.Text;
            values[2]  = textBox3.Text;
            values[3]  = textBox4.Text;
            values[4]  = textBox5.Text;
            values[5]  = textBox6.Text;
            values[6]  = textBox7.Text;
            values[7]  = textBox8.Text;
            values[8]  = textBox9.Text;
            values[9]  = textBox10.Text;          
        }
    }
}
