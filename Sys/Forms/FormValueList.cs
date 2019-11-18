
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 22.11.2017
 * Время: 17:43
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
namespace FBA
{      
    ///Форма для выбора одного изи нескольких строк из таблицы, которая получается после выполенния запроса SQL.
    ///MultiSelect - Допускается выбор одной строки или нескольких.
    public partial class FormValueList : FormSim
    {        
        /// <summary>
        /// Список выбранных значений.
        /// </summary>
    	public string[,] SelectedValue;
        
        ///Два перегруженных конструктора.
        public FormValueList(string SQL, bool multiSelect)
        {             
        	Constructor();
            //Заполнение таблицы.                
            if (!sys.RefreshGrid(DirectionQuery.Remote, dgList, SQL)) return;       
        }
               
        /// <summary>
        /// Перегруженый конструктора
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="multiSelect">Множественный выбор</param>
        public FormValueList(System.Data.DataTable dt, bool multiSelect)
        {             
        	Constructor();         			
            dgList.SetDataSource(dt);         
        }
         
        /// <summary>
        /// Конструктор.
        /// </summary>
        public void Constructor()
        {
        	InitializeComponent();
            if (this.Owner != null) this.Icon = this.Owner.Icon;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult     = System.Windows.Forms.DialogResult.OK;                        
        }
        
        ///Очистить всеь массив выбранных значений.
        private void SetEmpty()
        {
            SelectedValue.ArrayClear();          
        }
        
        ///Заполнить массив выбранными значениями.
        private void SelectValue()
        {                 
            var DT = new System.Data.DataTable();
            //DT = sys.FirstColumnSelectedRowsToDataTable(dgList);
            DT = dgList.SelectedRowsToDataTable(false);
            Arr.DataTableToArray(DT, out SelectedValue);
       }
             
        ///Отмена выбора.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEmpty();
            Close();
        }   
        
        ///Выбор значений и закрытие формы по кнопке Ок.
        private void btnOk_Click(object sender, EventArgs e)
        {
           SelectValue(); 
           Close();
        }
  
        ///Выбор значений и закрытие формы по двойному клику на гриде.
        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
           this.DialogResult = DialogResult.OK;
           SelectValue();
           Close();
        }
    }
}
