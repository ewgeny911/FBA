
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 07.10.2017
 * Время: 21:06
 */
 
using System;
namespace FBA
{   
    /// <summary>
    /// Свойства колонки настройки атрибута.
    /// </summary>
    public partial class FormFilterAttr : FormSim
    {                         
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="attrName">Имя атрибута</param>
        /// <param name="attrBrief">Сокращение атрибута</param>
        /// <param name="attrWidth">Ширина колонки в которой будет отображаться атрибут</param>
        /// <param name="attrMask">Маска отображения значения атрибута</param>
        /// <param name="attrSort">Способ сортировки</param>
        public FormFilterAttr(string attrName, string attrBrief, string attrWidth, string attrMask, string attrSort)
        {              
            InitializeComponent();           
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.tbName.Text  = attrName;
            this.tbBrief.Text = attrBrief;
            this.udWidth.Text = attrWidth;
            this.cbMask.Text  = attrMask;
            if (attrSort == "") this.cbSort.Text = "No"; else this.cbSort.Text = attrSort;            
        }
        
        private void cbUniversalWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            tbBrief.WordWrap = cbUniversalWordWrap.Checked;
        }
        
    }
}
