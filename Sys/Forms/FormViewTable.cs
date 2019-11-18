
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 04.10.2017
 * Время: 11:53
 */
  
using System;
namespace FBA
{          
    /// <summary>
    /// Показ формы с таблицей DataTable  
    /// </summary>
    public partial class FormViewTable : FormSim 
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="capForm">Шапка формы</param>
        /// <param name="capText">Подпись на форме</param>
        /// <param name="dt">Таблица DataTable</param>
    	public FormViewTable(string capForm, string capText, System.Data.DataTable dt)
        {           
            InitializeComponent();                
            if (capForm   != "") Text           = capForm;
            if (capText   != "") lbCapText.Text = capText;
            dgv1.DataSource = dt;
        }         
    }
}
