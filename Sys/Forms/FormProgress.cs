
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 01.05.2017
 * Время: 22:50
*/
using System;
using System.Windows.Forms;

namespace FBA
{   	
	/// <summary>
	/// Универсальная форма прогреса. 
	/// </summary>
	public partial class FormProgress : FormFBA
	{
		/// <summary>
		/// Для остановки прогреса из другой формы.
		/// </summary>
		public bool PressCancel;
		//public int Value = 0;
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="FormCaption">Шапка формы</param>
		/// <param name="LabelProgress">Текст в окне</param>
		/// <param name="StepCount">Всего сколько шагов</param>
		public FormProgress(string FormCaption, string LabelProgress, int StepCount)
		{			
			InitializeComponent();			  
			Text                 = FormCaption;
			lblProgress.Text     = LabelProgress;
			progressBar1.Maximum = StepCount;
			PressCancel          = false;			
		}
				
		/// <summary>
		/// Конструктор.
		/// </summary>
		public FormProgress()
		{			
			InitializeComponent();
            this.MdiParent = Var.FormMainObj;			
		}
			
     	/// <summary>
        ///  Установка значения уровня прогреса.
        /// </summary>
        public int Progress
        {
            get
            {
                return progressBar1.Value; //Color.FromName(this._TextColor.ToString());
            }
            set
            {                
                progressBar1.Value = value; //new SolidBrush(value);
                Refresh();
            }
        }
		
		// <summary>
		// Установка значения уровня прогреса.
		// </summary>
		// <param name="i"></param>
		//public void Progress(int i)
		//{
		//	progressBar1.Value = i;	
		//	this.Value = progressBar1.Value;
		//}
		
		/// <summary>
		/// Добавление на 1.
		/// </summary>
		public void Inc()
		{
			Application.DoEvents();
			if (progressBar1.Value < progressBar1.Maximum)
		    	progressBar1.Value = progressBar1.Value + 1;			
			
		}
		
		/// <summary>
		/// уменьшение на 1.
		/// </summary>
		public void Dec()
		{
			Application.DoEvents();
			if (progressBar1.Value > progressBar1.Minimum)
		    	progressBar1.Value = progressBar1.Value - 1;		
		}
		
		/// <summary>
		/// Установка прогреса на 0.
		/// </summary>
		public void Clear()
		{
			Application.DoEvents();
		    progressBar1.Value = 0;		   
		}
        
		/// <summary>
		/// Установка текста в окне прогреса.
		/// </summary>
        public string ProgressText
        {
            get { return lblProgress.Text; }
            set { lblProgress.Text = value; }
        }

        private void BtnCancelClick(object sender, EventArgs e)
		{
			PressCancel = true;
			Close();
		}
		
		private void FormProgressFormClosing(object sender, FormClosingEventArgs e)
		{
		    if (!PressCancel) return;
		    if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = (DialogResult.Yes != MessageBox.Show("Вы действительно хотите выйти?", "Внимание",
		                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question));
		    PressCancel = e.Cancel;
		}			
	}
}
