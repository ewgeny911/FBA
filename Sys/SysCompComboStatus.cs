
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 02.01.2018
 * Время: 20:07
 */
 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace FBA
{
    ///ComboBox для изменения статуса объекта.
    public partial class SysComboStatus : UserControl
    {
        string EntityBrief; //Сокращение сущности объекта.
        string ObjectID;    //ИД Объекта.
        string StatusName;  //Текущий статус объекта с ИД ObjectID.     
               
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SysComboStatus()
        {
            InitializeComponent();                    
        }
                  
        /// <summary>
        /// Загрузить в ComboBox список доступных статусов для объекта сущности EntityBrief,
        /// который находится в статусе StatusName.
        /// </summary>
        /// <param name="entityBrief">Сокращение сущности, для которой нужно загрузить список доступных статусов</param>
        /// <param name="objectID">ИД Объекта</param>
        /// <param name="statusName">Имя статуса, которое будет показано в компоненте</param>
        public void LoadStatusList(string entityBrief, string objectID, string statusName)
        {
            this.EntityBrief = entityBrief;
            this.ObjectID    = objectID;
            this.StatusName  = statusName; 
            string sql =
                string.Format("SELECT t2.Name FROM fbaStatusChange t1 " + 
                "  LEFT JOIN fbaStatus       t2 ON t1.StatusID       = t2.ID " + 
                "  LEFT JOIN fbaStatusList t3 ON t1.StatusListID = t3.ID " + 
                "  LEFT JOIN fbaStatus       t4 ON t3.StatusID       = t4.ID " + 
                "  LEFT JOIN fbaStatusEntity t5 ON t3.StatusEntityID = t5.ID " + 
                "  LEFT JOIN fbaEntity       t6 ON t5.EntityRefID    = t6.ID " + 
                "WHERE t6.Brief = '{0}' AND t4.Name = '{1}' " +
                "ORDER BY t2.Name; ", entityBrief, statusName);
                //Авизо    //Архив
                var dt = new System.Data.DataTable();
                if (!sys.SelectDT(DirectionQuery.Remote, sql, out dt)) return;                        
                cbStatus.SetDataSourse(dt);
                cbStatus.Text = statusName;
        }
        
        ///Кнопка - показать историю изменения статуса объекта.
        private void btnHistory_Click(object sender, EventArgs e)
        {
            //var f1 = new FormViewEntity(EntityBrief);
            //f1.ShowDialog();
        }
    }
}
