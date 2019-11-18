
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 02.01.2018
 * Время: 20:52
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
namespace FBA
{
    ///Форма для показа справочника.
    public partial class FormViewEntity : FormFBA
    {
        /// <summary>
        /// Сокращение сущности
        /// </summary>
    	public string EntityBrief;
    	
    	/// <summary>
    	/// Фильтр.
    	/// </summary>
        public FilterObj filter = new FilterObj();
        
        /// <summary>
        /// Таблица которая выводится на форму
        /// </summary>
        public System.Data.DataTable dt = new System.Data.DataTable();
        
        /// <summary>
        /// Форма поиска значений в таблице.
        /// </summary>
        public FormSearch fs;
        
        ///Конструктор.
        public FormViewEntity(string EntityBrief)
        {            
            InitializeComponent();           
            this.EntityBrief = EntityBrief;
            Text             = EntityBrief;
            var dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment   = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor   = System.Drawing.SystemColors.GradientActiveCaption; 
            dataGridViewCellStyle2.Font        = Var.font1;
            dataGridViewCellStyle2.WrapMode    = System.Windows.Forms.DataGridViewTriState.True;                
            DGV1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.FormClosing += FormViewClose;
        }
        
        ///Закрытие формы. Уничтожаем фильтр, если он существует.
        private void FormViewClose(object sender, FormClosingEventArgs e)
        {
            if (fs != null) fs.Close();
        } 
        
        ///Все управляющие кноки справочника.
        private void tb_N1_Click(object sender, EventArgs e)
        {                                  
            //Filter.
            if ((sender == tb_N1) || (sender == cm_N1))
            {                                            
                if (!FormFilter.Filter(this, EntityBrief, DGV1.Left, DGV1.Top, ref filter)) return;                
                //sys.SM(filter.FullQuery);                                                            
                Var.con.SelectDT(filter.FullQuerySQL, out dt);
                DGV1.DataSource = dt;                            
            }
            
            //Refresh.            
            if ((sender == tb_N2) || (sender == cm_N2))
            {                
                Var.con.SelectDT(filter.FullQuerySQL, out dt);
                DGV1.DataSource = dt; 
            }
            
            //ShowSQL.            
            if (sender == cm_N8) sys.SM(filter.FullQuerySQL, MessageType.Information);
            
            //ShowMSQL.
            if (sender == cm_N9) sys.SM(filter.FullQueryMSQL, MessageType.Information);
            
            //Sum of the values
            //if (sender == cm_N10) sys.SM("Функционал пока не работает!");
            
            //Details
            if (sender == cm_N8) DGV1.GridInformation();
            
            //Export to Excel
            if (sender == cm_N6) DGV1.ExportToExcel();
            
            //Save to CSV
            if (sender == cm_N7) DGV1.DataGridViewToCSV("");
            
            //Форма поиска.
            if ((sender == tb_N6) || (sender == cm_N9))                            
            {                
                fs = FormSearch.FormSearchShow(this.Name, DGV1, null);                                 
            }
        }        
    }
}
