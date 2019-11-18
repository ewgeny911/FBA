
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 01.10.2017
 * Время: 21:06
 */
 
using System;
using System.Windows.Forms;

namespace FBA
{        
    /// <summary>
    /// Выбор атрибута.
    /// </summary>
    public partial class FormGetAttr : FormSim
    {       
        /// <summary>
        /// Сокращение сущности
        /// </summary>
    	public string EntityBrief;
    	
    	/// <summary>
    	/// ИД сущности
    	/// </summary>
        public string EntityID;
        
        /// <summary>
        /// Сокращение атрибута
        /// </summary>
        public string AttrBrief;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="entityID">ИД сущности</param>
        public FormGetAttr(string entityID)
        {   
            InitializeComponent();                   
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;             
            cmtAttrList.LoadAttrTree(entityID);
            this.EntityBrief = cmtAttrList.EntityBrief;
        }        
        
        private void PanelUserSelectedAttr(object sender, SelectAttrEventArgs e)
        {               
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            AttrBrief = e.NewAttr;
            Close();
        }
          
        /// <summary>
        /// Закрытие формы выбора атрибута.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGetAttrFormClosing(object sender, FormClosingEventArgs e)
        {
            AttrBrief   = cmtAttrList.AttrBrief;     
        }                                                                  
    }
}
