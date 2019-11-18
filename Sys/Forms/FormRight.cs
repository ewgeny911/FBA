
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 14.10.2017
 * Время: 11:39
 */
	
using System;

namespace FBA
{             
    /// <summary>
    /// Форма редактирвоания права пользовальвателя или роли.
    /// </summary>
	public partial class FormRight : FormSim
    {                     
        /// <summary>
        /// Результат закрытия формы.
        /// </summary>
        public int StatusClose     = 0;
        
        private Operation operation = Operation.NotAssigned;
        private string RightID    = "0";
        private string RightName  = "";
        private string RightBrief = ""; 
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="operation">Операция</param>
        /// <param name="rightID">ИД права</param>
        /// <param name="rightName">Имя права</param>
        /// <param name="rightBrief">Сокращение права</param>
        public FormRight(Operation operation, string rightID, string rightName, string rightBrief)
        {                   	
            InitializeComponent();                    
            this.operation = operation;
            this.RightID     = rightID;
            this.RightName   = rightName;
            this.RightBrief  = rightBrief;
            if (operation != Operation.Add) {
                tbID.Text     = rightID;               
                tbName.Text   = rightName;           
                tbBrief.Text  = rightBrief;
            }                        
        }
        
        private void BtnOkClick(object sender, EventArgs e)
        {
            StatusClose = 1;             
            string SQL = "";
            if (operation == Operation.Add)                     
                SQL = "INSERT INTO fbaRight (EntityID, Name, Brief, DateCreate, DateChange) VALUES (102, '" + tbName.Text + "', '" + tbBrief.Text + "', " + sys.DateTimeCurrent() + ", " + sys.DateTimeCurrent() + ") ";                
                       
            if (operation == Operation.Edit) 
            {               
                SQL = "UPDATE fbaRight SET " +
                "Name   = '" + tbName.Text + "'," +
                "Brief  = '" + tbBrief.Text + "'," +             
                "DateChange = " + sys.DateTimeCurrent() + " " +
                "WHERE ID = " + RightID;              
            }
            if (SQL != "") sys.Exec(DirectionQuery.Remote, SQL);
            Close();
        }
        
        private void BtnCancelClick(object sender, EventArgs e)
        {
          StatusClose = 2;
            Close();
        }
    }
}
