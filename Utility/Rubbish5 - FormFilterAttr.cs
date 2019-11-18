
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 01.10.2017
 * Время: 21:06
 * 
 
 */
/*using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data; 
namespace FBA
{
    // Description of FormGetAttr.
    
    public partial class FormGetAttr : Form
    {
        /*System.Data.DataTable DT; 
        public string FilterEntityBrief;
        public string FilterAttrBrief;
        public FormGetAttr(string EntityBrief)
        {   
            InitializeComponent();
            //MdiParent = Var.FormMainObj;
            FilterEntityBrief = EntityBrief;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            //sys.ConnectLocal();
            //LoadTreeAttr(FilterEntityBrief);
        }        
        
               
        //Разделяем параметр на несколько, по разделютелю точка с запятой.
        private void GetParam(string Param, 
                              out string Attr_EntityID,
                              out string Attr_Type,
                              out string Attr_Kind,
                              out string Table_Type,
                              out string Ref_EntityID)
        {
            Attr_EntityID = Param.StrBeweenStr("Attr_EntityID=", ";");
            Attr_Type     = Param.StrBeweenStr("Attr_Type=",     ";");
            Attr_Kind     = Param.StrBeweenStr("Attr_Kind=",     ";");
            Table_Type    = Param.StrBeweenStr("Table_Type=",    ";");
            Ref_EntityID  = Param.StrBeweenStr("Ref_EntityID=",  ";");             
        }
        
        
        //Определяем картинку для узла.
        private int GetImageIndex(string Attr_Type, string Attr_Kind, string Table_Type)
        {
            
            //Attr_Type = 1 - (Поле)        Поле
            //Attr_Type = 2 - (Ссылка)      Ссылка
            //Attr_Type = 3 - (УниСсылка)   Универсальная ссылка
            //Attr_Type = 4 - (Массив)      Массив
            
            //Attr_Kind = 1 - (Простой)     Атрибут из базы данных
            //Attr_Kind = 2 - (Системный)   Системный
            //Attr_Kind = 3 - (Вычисляемый) Вычисляемый            
    
            //Иконки:
            //0 - Системный 
            //1 - Поле
            //2 - Ссылка
            //3 - УниСсылка
            //4 - Массив
            //5 - Вычисляемый
            //6 - Вычисляемая ссылка
            //7 - Сущность
            //8 - Какая-то ошибка.
            
            if (Attr_Kind == "1") 
            {
                if (Attr_Type == "1") 
                {
                    if (Table_Type == "2") return 9;
                    return 1;
                }
                if (Attr_Type == "2") return 2;
                if (Attr_Type == "3") return 3;
                if (Attr_Type == "4") return 4;
                return 8;                 
             }
             if (Attr_Kind == "3") 
             {
                if (Attr_Type == "1") return 5;
                if (Attr_Type == "2") return 6;              
                return 8;                 
             }
             return 8;
        }
        
        //Добавление элемента в дерево.
        private void AddSysAttrOne(TreeNode node, string Attr)
        {           
            var node1  = new TreeNode();
            node1.Text = Attr; 
            node1.Tag  = "0";                      
            node1.ImageIndex = 0;
            node1.SelectedImageIndex = node1.ImageIndex;
            node.Nodes.Add(node1);
        }
        
        //Добавление системных атрибутов в каждую сущность. 
        private void AddSysAttrList(TreeNode node)
        {
            AddSysAttrOne(node, "ИДОбъекта");
            AddSysAttrOne(node, "НаимОбъекта");
            AddSysAttrOne(node, "ИДСущностиОбъекта");
            AddSysAttrOne(node, "СокрСущностиОбъекта");
            AddSysAttrOne(node, "НаимСущностиОбъекта");                        
            AddSysAttrOne(node, "ОбъектЗакрыт");             
        }               
         
        //Для ускорения загрузки дерева, отключаем/включаем прорисовку.
        private void TreeViewAttrAfterExpand(object sender, TreeViewEventArgs e)
        {
            treeViewAttr.EndUpdate();
        }
        
        //Для ускорения загрузки дерева, отключаем/включаем прорисовку.
        private void TreeViewAttrMouseMove(object sender, MouseEventArgs e)
        {
           treeViewAttr.EndUpdate();
        }
        
        //Наполнение узла происходит только в момент раскрытия узла по крестику.
        private void TreeViewAttrBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeViewAttr.BeginUpdate();             
            TreeNode FNode = e.Node.FirstNode;
            if (FNode.Text != "Expanding...") return; 
            FNode.Remove();                
            string NodeTag = e.Node.Tag.ToString();
            string Attr_EntityID;
            string Attr_Type;
            string Attr_Kind;
            string Table_Type;
            string Ref_EntityID;
            GetParam(NodeTag, 
                   out Attr_EntityID,
                   out Attr_Type,
                   out Attr_Kind,
                   out Table_Type,
                   out Ref_EntityID);
              
            if (Attr_EntityID == "0") return;
            if ((Attr_Type     != "2") && (Attr_Type != "4")) return;
            DataRow[] ArrdDr = DT.Select("Attr_EntityID = " + Ref_EntityID);
            AddSysAttrList(e.Node); 
            foreach (DataRow dr in ArrdDr)
            {
                var node1  = new TreeNode();
                node1.Text    = dr["Attr_Brief"].ToString();
                Attr_EntityID = dr["Attr_EntityID"].ToString();
                Attr_Type     = dr["Attr_Type"].ToString();
                Attr_Kind     = dr["Attr_Kind"].ToString();
                Table_Type    = dr["Table_Type"].ToString();
                Ref_EntityID  = dr["Ref_EntityID"].ToString();
                NodeTag       = "Attr_EntityID=" + Attr_EntityID + ";" + 
                                "Attr_Type=" + Attr_Type + ";" +
                                "Attr_Kind=" + Attr_Kind + ";" +
                                "Ref_EntityID=" + Ref_EntityID + ";";
                node1.Tag = NodeTag;
                node1.ImageIndex = GetImageIndex(Attr_Type, Attr_Kind, Table_Type);
                node1.SelectedImageIndex = node1.ImageIndex; 
                e.Node.Nodes.Add(node1);
                
                if ((Attr_Type == "2") || (Attr_Type == "4"))  //2 - ссылка, 4 - массив.
                {
                    var node2 = new TreeNode();
                    node2.Text = "Expanding...";
                    node2.Tag  = "0";
                    node1.Nodes.Add(node2);
                }                                                               
            }             
        }
    
        //Двойной клик - выбор элеменат дерева (атрибута)
        private void TreeViewAttrDoubleClick(object sender, EventArgs e)
        {
            //if (treeViewAttr.SelectedNode == null) sys.SM("Пусто");
            //sys.SM(treeViewAttr.SelectedNode.FullPath);
            this.DialogResult = DialogResult.OK;
            Close();      
        }        
        //Загрузить дерево сущностей.
        public void LoadTreeAttr(string EntityBrief)
        {             
            Var.conLite.SelectDT1("SELECT DISTINCT " + 
                "Attr_EntityID,    " + 
                "Attr_EntityBrief, " +
                //"EnBriefName1,     " +
                "Attr_Brief,       " +
                //"Attr_Name,        " +
                "Attr_Type,        " +
                "Attr_Kind,        " +
                "Table_Type,       " +
                "Ref_EntityID,     " +
                "Ref_EntityBrief  " +
                //"Ref_AttrBrief     " +
                "FROM fbaAttrParent ORDER BY Attr_Brief", out DT);
            treeViewAttr.Nodes.Clear();
             
            DataRow[] ArrdDr = DT.Select("Attr_EntityBrief = '" + EntityBrief + "'");
            DataRow dr1 = ArrdDr[0];
            var node  = new TreeNode();               
            node.Text =  EntityBrief; 
            node.Tag  = "0";                      
            node.ImageIndex = 7;
            node.SelectedImageIndex = node.ImageIndex;
            
            treeViewAttr.Nodes.Add(node);            
            treeViewAttr.BeginUpdate();
            AddSysAttrList(node);
            foreach (DataRow dr in ArrdDr)
            {
                var node1  = new TreeNode();
                node1.Text           = dr["Attr_Brief"].ToString();
                string Attr_EntityID = dr["Attr_EntityID"].ToString();
                string Attr_Type     = dr["Attr_Type"].ToString();
                string Attr_Kind     = dr["Attr_Kind"].ToString();
                string Table_Type    = dr["Table_Type"].ToString();
                string Ref_EntityID  = dr["Ref_EntityID"].ToString();
                string NodeTag = "Attr_EntityID=" + Attr_EntityID + ";" + 
                                 "Attr_Type=" + Attr_Type + ";" +
                                 "Attr_Kind=" + Attr_Kind + ";" +
                                 "Table_Type=" + Table_Type + ";" +
                                 "Ref_EntityID=" + Ref_EntityID + ";";
                node1.Tag = NodeTag;
                node1.ImageIndex = GetImageIndex(Attr_Type, Attr_Kind, Table_Type);
                node1.SelectedImageIndex = node1.ImageIndex;               
                node.Nodes.Add(node1);
                
                if ((Attr_Type == "2") || (Attr_Type == "4")) //2 - ссылка, 4 - массив.
                {
                    var node2 = new TreeNode();
                    node2.Text = "Expanding...";
                    node2.Tag  = "0";
                    node1.Nodes.Add(node2);
                }                                              
            }
            node.Expand();
            treeViewAttr.EndUpdate();                       
        }                                     
        
         
        
        //Показ дерева сущностей и атрибутов в момент показа формы.
        private void FormGetAttrLoad(object sender, EventArgs e)
        {
             panelUser.LoadTreeAttr(FilterEntityBrief);
             this.LoadTreeAttr(FilterEntityBrief);
        }
               
        //При закрытии формы и выборе атрибута определем путь к атрибуту.
        private void FormGetAttrFormClosing(object sender, FormClosingEventArgs e)
        {                       
            if (treeViewAttr.SelectedNode == null) FilterAttrBrief = "";
              //else FilterAttrBrief = treeViewAttr.SelectedNode.FullPath.Replace(@"\", ".");
              else FilterAttrBrief = treeViewAttr.SelectedNode.FullPath;
            FilterAttrBrief = FilterAttrBrief.StrAfterStr(".");                
        }
        
        void PanelUserMouseDoubleClick(object sender, MouseEventArgs e)
        {
            sys.SM("UserMouseDoubleClick:" + panelUser.EntityBrief);
        }
        
        void PanelUserSelectedAttr(object sender, SelectAttrEventArgs e)
        {
            sys.SM("UserSelectedAttr:" + panelUser.EntityBrief + Var.CR +
                   "e.NewAtt:" + e.NewAttr);
        }
         
                                                                             
    }
}
*/
  
/*
 SELECT 
  Attr_EntityID, 
  Attr_EntityBrief,
  EnBriefName1,  
  Attr_Brief,
  Attr_Name,
  Attr_Type,
  Ref_EntityID,
  Ref_EntityBrief,
  Ref_AttrBrief 
FROM fbaAttrParent where Attr_EntityBrief = 'ДогСтрах'
*/ 
 /*
  
            //=================================
            //Из DataSet в XML. Работает.
            DataSet DataSetAdmin;
               
            Var.conLite.SelectDS("select * from fbaAttr limit 50", out DataSetAdmin);
            string s = DataSetAdmin.GetXml();                    
            
            sys.SM(s);
            
            //Из XML в DataSet.
            XmlReader xm1;
            xm1 = ToXmlReader(s);
            DataSet DataSetAdmin2 = new DataSet();
            DataSetAdmin2.ReadXml(xm1);
            DataTable dt1 = DataSetAdmin.Tables[0];
            dgvSQL1.DataSource = dt1;
            //==================================
*/           
     //Из строки XML получить объекта XmlReader.
        /*public static XmlReader ToXmlReader(string value)
        {
            var settings = new XmlReaderSettings {ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = true, IgnoreComments = true};
            var xmlReader = XmlReader.Create(new StringReader(value), settings);
            xmlReader.Read();
            return xmlReader;
        }*/
        
        
        
               
        //Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataTable. Возвращает несколько таблиц.               
        /*public bool SelectDT(string SQL, out System.Data.DataSet DS, ref string ErrorText, bool ErrorShow)
        {           
            if ((SQL == "") || (SQL == "Empty"))
            {
                dtRtn1 = dtRtn;
                return false;
            }
                                  
            try
            {
                dtRtn.Clear();
                if ((ConnectionDirect) && (ServerType == "Postgre"))
                {
//                    command1 = new NpgsqlCommand(QueryText);
//                    command1.Connection = connection1;
//                    DataTable dt = new DataTable();
//                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command1);
//                    da.Fill(dt);
//                    dtRtn.Add(dt);
                    
                    command1 = new NpgsqlCommand(SQL);
                    command1.Connection = connection1;
                    var DS = new DataSet("DS");
                    var da = new NpgsqlDataAdapter(command1);
                    da.Fill(DS);
                    //for (int i = 0; i < DataSetAdmin.Tables.Count; i++)
                    //{
                    //    dtRtn.Add(DataSetAdmin.Tables[i]);
                    //}
                }
                if ((ConnectionDirect) && (ServerType == "MSSQL"))
                {                  
                    //Если передавать значение Parameters в параментрах функции
                    //List<object> Parameters
                    //if (Parameters != null)
                    //{
                    //    foreach (object item in Parameters)
//                        {
//                            SqlParameter parameter = new SqlParameter(); или new NpgsqlParameter();
//                            parameter.Direction = ParameterDirection.Input;
//                            parameter.Value = item;
//                            command2.Parameters.Add(parameter);
//                        }
//                    }
                    
                    command2 = new SqlCommand(SQL);
                    command2.Connection = connection2;
                    var da = new SqlDataAdapter(command2);
                    var DataSetAdmin = new DataSet("DataSetAdmin");
                    da.Fill(DataSetAdmin);
                    for (int i = 0; i < DataSetAdmin.Tables.Count; i++)
                    {
                        dtRtn.Add(DataSetAdmin.Tables[i]);
                    }                                       
                }
                if ((ConnectionDirect) && (ServerType == "SQLite"))
                {
                    dtRtn.Clear();
                    command3 = new SQLiteCommand(SQL);
                    command3.Connection = connection3; 
                    var da = new SQLiteDataAdapter(command3);
                    var DataSetAdmin = new DataSet("DataSetAdmin");
                    da.Fill(DataSetAdmin);
                    
                    //string s = DataSetAdmin.GetXml();                    
                    //sys.SM(s);
                    
                    for (int i = 0; i < DataSetAdmin.Tables.Count; i++)                    
                        dtRtn.Add(DataSetAdmin.Tables[i]);
                                                      
                }
                
                if (!ConnectionDirect) 
                {                    
                    System.Data.DataSet DS;
                    string ErrorMes;
                    if (AppSelect(SQL, out DS, out ErrorMes)) 
                    {
                        dtRtn.Clear();
                        dtRtn.Add(DT);
                    }
                } 
                
                dtRtn1 = dtRtn;
                return true;               
            }
            catch (Exception e)
            {               
                ErrorText = "Ошибка выполнения запроса:" + ErrorText + Var.CR + e.Message + Var.CR + SQL; 
                if (ErrorShow) sys.SM(ErrorText);                      
                dtRtn1 = null;
                return false;               
            }
        }*/           
        
        
        //Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataTable. Возвращает несколько таблиц.         
        //public bool SelectDT(string SQL, out List<System.Data.DataTable> dtRtn1)
        //{
        //   string ErrorText = "";
        //   const bool ErrorShow = true;
        //   return SelectDT(SQL, out dtRtn1, ref ErrorText, ErrorShow);
        //}          
        
        
        
    //Функции получения данных для MSSQL, Postgre, SQLite. Результат в DataGridView.  
       /* public bool SelectGV(string SQL, DataGridView Grid, ref string ErrorText, bool ErrorShow)
        {
            System.Data.DataTable DT;
            bool flag = SelectDT1(SQL, out DT, ref ErrorText, ErrorShow);
            if (!flag) return false;              
            Grid.DataSource = DT;                
            //Grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11.25F, FontStyle.Bold); //ForeColor = Color.Red;           
            //Grid.RowsDefaultCellStyle.SelectionBackColor = Color.Blue; 
            //Grid.AutoResizeColumns();
            return flag;
        }*/        
       
       
       
      //Послать запрос SQL на сервер приложений.
        /*public bool AppQuery(string TypeQuery, int NumQuery, string SQL, out System.Data.DataTable DT, out string ErrorMes)
        {               
            DT = null;
            ErrorMes = "";
            if ((ConnectionGUID == "") || (ServerAppName == ""))
            {   ErrorMes = "Ошибка. соединение с сервером приложений не установлено!"; 
                return false;
            }  
            
            string QueryCode = "";
            if (TypeQuery == "EXEC") QueryCode = "104"; else QueryCode = "103"; 
                  
            string Request = sys.ServerAppHTTPMessage(ServerAppName, ServerAppPort, QueryCode, ConnectionGUID, SQL, "", 0);
            if (Request == "Сессия с сервером не найдена!") 
            {
                if (NumQuery < 2)  //Переподключаемся только 1 раз, чтобы не зацикливаться.
                {                       
                    if (!(sys.Enter(this.ConnectionName, Var.enterMode, "")))
                    {
                        sys.SM(Request + Var.CR + "Ошибка повторного входа в систему!");
                        return false;
                    }
                    NumQuery = NumQuery + 1;
                    //this.ConnectionGUID = NextConnectionGUID;
                    //Здесь важно именно писать Var.conSys.AppQuery, а не просто AppQuery, 
                    //для того, чтобы AppQuery выполнился в другом созданном con, 
                    //для того чтобы использовался ConnectionGUID уже другого con.
                    //то что SystemEnter возвращает ConnectionGUID ничего не меняет.
                    //Можно убрать возврат ConnectionGUID из SystemEnter - это ничего не изменит.
                    Var.conSys.AppQuery(TypeQuery, NumQuery, SQL, out DT, out ErrorMes);
                    return true;
                } else
                {
                    sys.SM(Request + Var.CR + "Ошибка подключения к серверу приложений!");
                    return false;
                }
            }
            sys.DataTableFromString(out DT, Request, out ErrorMes, true);
            return true;       
        }*/       