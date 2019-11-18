
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 09.09.2016
 * Время: 18:12
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;     
using System.Collections.Generic;    
namespace FBA
{      
    /// <summary>
    /// Новая прикладная форма.
    /// </summary>
    public partial class ProjectNew : FormSim
    {
        /// <summary>
        /// Статус закрытия формы
        /// </summary>
    	public int    StatusClose = 0;
        
        /// <summary>
        /// Имя новой формы в решении
        /// </summary>
        public string projectName       = "";
        
        /// <summary>
        /// Выбранный тип формы
        /// </summary>
        public string ProjectTemplate = "";
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProjectNew()
        {
            InitializeComponent();               
            foreach (var ProjectName in Directory.GetDirectories(FBAPath.PathTemplate, "*", SearchOption.TopDirectoryOnly)) 
            {
                listBoxTemplate.Items.Add(Path.GetFileNameWithoutExtension(ProjectName));
            }            
         }                    
                            
        private void BtnOkClick(object sender, EventArgs e)
        {
            if (listBoxTemplate.SelectedIndex == -1)
            {
                sys.SM("Введите шаблон для формы!");
                return;
            }
             
            projectName = tbProjectName.Text;
            if (projectName == "") 
            {
                sys.SM("Введите имя формы!");
                return;
            }
             
            StatusClose = 1;                      
            ProjectTemplate = listBoxTemplate.Items[listBoxTemplate.SelectedIndex].ToString();                   
            Close();
        }
        
        private void btnCancelClick(object sender, EventArgs e)
        {
            StatusClose = 2;
            projectName = "";
            ProjectTemplate = "";
            Close();
        }
                            
    }
}
