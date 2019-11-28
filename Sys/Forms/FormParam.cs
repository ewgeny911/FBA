
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 07.10.2017
 * Время: 16:21
 */
 
using System;    
using System.Windows.Forms;
namespace FBA
{   
    ///Форма для работы с параметрами приложения.
    public partial class FormParam : FormFBA
    {              
        string OldFilter   = "";
        string Filter      = "";       
        string FilterName  = "";
        string FilterValue = "";
        
        ///Конструктор.
        public FormParam()
        {              
            InitializeComponent();                       
            this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;
            RefreshUser();
        }
        
        ///Обновить таблицу пользователей.
        private bool RefreshUser()
        {
            const string SQL = "SELECT 0 AS ID, 'Global' AS Login UNION ALL SELECT ID, Login FROM fbaUser ORDER BY Login";
            if (!sys.SelectGV(DirectionQuery.Remote, SQL, dgvUser)) return false;    
            return true;   
        }
        
        ///Обновить таблицу параметров текущего пользователя.
        private bool RefreshParam(string UserID)
        {           
            string SQL = "";
            if (UserID == "") return false;
            string substr = sys.GetSubString();
            if (UserID == "0")
                SQL = "SELECT t1.ID, t1.Global, t1.Name, t1.Comment, t1.DateCreate, t2.Login AS UserCreate, t1.DateChange, t3.Login AS UserChange, " +
            		  substr + "(t1.Value1, 1, 50) AS Value1, " +
                      substr + "(t1.Value2, 1, 50) AS Value2, " +
                      substr + "(t1.Value3, 1, 50) AS Value3, " +
                      substr + "(t1.Value4, 1, 50) AS Value4, " +
                      substr + "(t1.Value5, 1, 50) AS Value5, " +
                      substr + "(t1.Value6, 1, 50) AS Value6, " +
                      substr + "(t1.Value7, 1, 50) AS Value7, " +
                      substr + "(t1.Value8, 1, 50) AS Value8, " +
                      substr + "(t1.Value9, 1, 50) AS Value9, " +
                      substr + "(t1.Value10,1, 50) AS Value10 " +
                      "FROM fbaParam t1 " +
                      "LEFT JOIN fbaUser t2 ON t1.UserID = t2.ID " +
                      "LEFT JOIN fbaUser t3 ON t1.UserID = t3.ID " +
                      "WHERE t1.Global = 1 " + this.Filter + " ORDER BY t1.Name";
            else
                SQL = "SELECT t1.ID, t1.Global, t1.Name, t1.Comment, t1.DateCreate, t2.Login AS UserCreate, " +
                      substr + "(t1.Value1, 1, 50) AS Value1, " +
                      substr + "(t1.Value2, 1, 50) AS Value2, " +
                      substr + "(t1.Value3, 1, 50) AS Value3, " +
                      substr + "(t1.Value4, 1, 50) AS Value4, " +
                      substr + "(t1.Value5, 1, 50) AS Value5, " +
                      substr + "(t1.Value6, 1, 50) AS Value6, " +
                      substr + "(t1.Value7, 1, 50) AS Value7, " +
                      substr + "(t1.Value8, 1, 50) AS Value8, " +
                      substr + "(t1.Value9, 1, 50) AS Value9, " +
                      substr + "(t1.Value10,1, 50) AS Value10 " +
                      "FROM fbaParam t1 " +
                      "LEFT JOIN fbaUser t2 ON t1.UserID = t2.ID " +                                                             
                      "WHERE t1.UserID = " + UserID + " " + this.Filter + " ORDER BY t1.Name";
            if (!sys.SelectGV(DirectionQuery.Remote, SQL, dgvParam)) return false;
            return true;                
        }
    
        ///Добавить параметр пользователя.
        private bool ParamAdd (string UserID)
        {                                       
            if (UserID == "") return false;                   
            string ParamName    = "";
            string ParamComment = "";
            string[] values = new string[10]; 
            var frm = new FormParamValue("0", ParamName, ParamComment, values);           
            if (frm.ShowDialog() != DialogResult.OK) return false;                                                                  
            ParamName    = frm.ParamName;
            ParamComment = frm.ParamComment;
            values       = frm.values; 
            
            string globalstr = "1";
            string userIDStr = "NULL";
            if (UserID != "0") 
            {
            	globalstr = "0";
            	userIDStr = "'" + UserID + "'";
            }
            string SQL = "";             
            SQL = "INSERT INTO fbaParam (EntityID, Global, UserID, Type, Name, Comment, DateCreate, " +
                  "Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9, Value10) " +
            "VALUES (235, " + globalstr + ", " + userIDStr + ", 'User', '" + ParamName + "','" + ParamComment + "'," + sys.DateTimeCurrent() 
            + ",'" + values[0] + "'"
            + ",'" + values[1] + "'"
            + ",'" + values[2] + "'"
            + ",'" + values[3] + "'"
            + ",'" + values[4] + "'"
            + ",'" + values[5] + "'"
            + ",'" + values[6] + "'"
            + ",'" + values[7] + "'"
            + ",'" + values[8] + "'"
            + ",'" + values[9] + "'"          
            +")";                        
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;
            RefreshParam(UserID);
            return true;
        }
        
        ///Редактировать параметр текущего пользователя.
        private bool ParamEdit (string UserID, string ParamID)
        {
            if (UserID  == "") return false;
            if (ParamID == "") return false;                      
            
            string[] Values = new string[13];
            string[] Params = new string[10];
            string SQL = "SELECT  " +
                         "Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9, Value10, ID, Name, Comment FROM fbaParam WHERE ID = " + ParamID;

            if (!sys.GetValueArr(DirectionQuery.Remote, SQL, ref Values)) return false;
            for (int i = 0; i < 9; i++) Params[i] = Values[i];
            string ParamName    = Values[11];
            string ParamComment = Values[12];
            var frm = new FormParamValue(ParamID, ParamName, ParamComment, Params);           
            if (frm.ShowDialog() != DialogResult.OK) return false;                                                                      
            ParamName    = frm.ParamName;
            ParamComment = frm.ParamComment;
            Params       = frm.values;               
            SQL = "UPDATE fbaParam SET " +                              
                  " Name    = '" + ParamName    + "'" +
                  ",Comment = '" + ParamComment + "'" +
                  ",Value1   = '" + Params[0]   + "'" +
                  ",Value2   = '" + Params[1] + "'" +
                  ",Value3   = '" + Params[2] + "'" +
                  ",Value4   = '" + Params[3] + "'" +
                  ",Value5   = '" + Params[4] + "'" +
                  ",Value6   = '" + Params[5] + "'" +
                  ",Value7   = '" + Params[6] + "'" +
                  ",Value8   = '" + Params[7] + "'" +
                  ",Value9   = '" + Params[8] + "'" +
                  ",Value10  = '" + Params[9] + "'" +
                  ",DateChange   = " + sys.DateTimeCurrent() +
                  ",UserChangeID = " + Var.UserID  +  
                  " WHERE ID = " + ParamID;
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;           
            RefreshParam(UserID);
            return true;         
        }
        
        ///Удалить параметр текущего пользователя.
        private bool ParamDel (string UserID, string ParamID)
        {
            if (UserID  == "") return false;
            if (ParamID == "") return false;
            string SQL = "DELETE FROM fbaParam WHERE ID = " + ParamID;
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;
            RefreshParam(UserID);
            return true;             
        }
        
        ///Поиск параметра.
        private bool ParamFind (string UserID)
        {            
            if (!sys.InputValue2("Search parameter", "Parameter name:", "Parameter value:", ref FilterName, ref FilterValue)) return false;
            if ((FilterName  == "") && (FilterValue == "")) return true;               
            Filter = "";
            cbParamFilter.Checked = true;
            if (FilterName  != "") Filter = Filter + " AND t1.Name  LIKE '%" + FilterName  + "%' ";
            if (FilterValue != "") 
            {
            	Filter = Filter + " AND (" + 
            		"t1.Value1 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value2 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value3 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value4 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value5 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value6 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value7 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value8 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value9 LIKE '%" + FilterValue + "%' OR " +
            		"t1.Value10 LIKE '%" + FilterValue + "%')";
            		
            		                       
            }
            
            
            
            RefreshParam(UserID);
            return true;
        }       
              
        /// <summary>
        /// Контекстное меню таблицы параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbParamN1_Click(object sender, EventArgs e)
        {           
            string UserID     = dgvUser.Value("ID"); 
            string ParamID    = dgvParam.Value("ID"); 
            
            //Add.
            if (sender == tbParamN1) ParamAdd(UserID);
                      
            //Edit.
            if (sender == tbParamN2) ParamEdit(UserID, ParamID);
                                     
            //Del.
            if (sender == tbParamN3) ParamDel(UserID, ParamID);
                                                 
            //Find.
            if (sender == tbParamN4)  ParamFind (UserID);
            
                //Refresh - обновить список параметров.
            if (sender == tbParamN5)  RefreshParam(UserID);
            
            //DoubleClick на dgvUser - обновить список параметров.
            if (sender == dgvUser) RefreshParam(UserID); 
            
            //Refresh UserList - обновить список пользователей.
            if (sender == tbUserN1) RefreshUser();           
        }
        
        ///Галка применить фильтр. 
        private void cbParamFilter_CheckedChanged(object sender, EventArgs e)
        {
            string UserID   = dgvUser.Value("ID"); 
            if (UserID == "") return;
            if (cbParamFilter.Checked)
            {
                if (Filter != OldFilter)
                {
                    Filter = OldFilter;
                    RefreshParam(UserID);
                }
            } else
            {
                OldFilter = Filter;
                Filter = "";
                RefreshParam(UserID);
            }                 
        }                                                                 
    }
}
             