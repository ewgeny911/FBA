
/*void button1_Click(object sender, EventArgs e)
       {
           /*int N2 = 2048;
           string Str1 = sys.IntConvertTo2(N2);
           N2 = sys.SetBit(N2, 0, true);
           N2 = sys.SetBit(N2, 1, true);
           N2 = sys.SetBit(N2, 3, true);
           string Str2 = sys.IntConvertTo2(N2);


           bool b1 = sys.GetBit(N2, 93);
           string BoolStr = b1.ToString();
           sys.SM(Str1 + Var.CR + Str2 + Var.CR + BoolStr);

       }
*/
//====================================
//Добавление колонки в DataGridView.
//public static string DGVColumnAdd(DataGridView DGV, string ColCap, string ColName)
//{
//    DataGridViewColumn column = new DataGridViewCheckBoxColumn();
//    column.DataPropertyName = ColName;
//    column.Name             = ColCap;                          
//    DGV.Columns.Add(column);
//}
//====================================
/*
 //Получаем значения компонентов формы (или другого компонента-контейнера Panel, TabControl) в виде строки.
        public static string GetComponentValues(Control.ControlCollection controls)
        {                   
            string  SettingText = "";
            foreach(Control control in controls)
            {                      
                SettingText = SettingText + GetComponentValues(control.Controls);                            
                if (control.Tag != null)
                {
                    //Пример формата строки в Tag: Main.СтрахПолис.Номер;Save                                       
                      
                    string TagStr = control.Tag.ToString();
                    string Setting = TagStr.StrBeforeStr(";");
                    string CompType = control.GetType().ToString();
                    if (CompType.IndexOf("FBA.", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        bool SaveParam = false;  
                        if (CompType      == "FBA.TextBoxFBA")     SaveParam = ((TextBoxFBA)control).SaveParam;
                        else if (CompType == "FBA.ComboBoxFBA")    SaveParam = ((ComboBoxFBA)control).SaveParam;
                        else if (CompType == "FBA.CheckBoxFBA")    SaveParam = ((CheckBoxFBA)control).SaveParam;
                        else if (CompType == "FBA.RadioButtonFBA") SaveParam = ((RadioButtonFBA)control).SaveParam;
                        else if (CompType == "FBA.TabControlFBA")  SaveParam = ((RadioButtonFBA)control).SaveParam;                 
                        //if (control.Tag.ToString() == "SAVE") SaveParam = true;
                        //if (!SaveParam) continue;
                        CompType = CompType.Replace("FBA.", "");
                        CompType = CompType.Replace("FBA", "");
                        //Setting = "SAVE";
                    }  else
                    //if (TagStr.ToUpper().Trim() == "SAVE")
                    {
                    //    Setting = "SAVE";
                        CompType = CompType.Replace("System.Windows.Forms.", "");
                    }//  else
                    //{
                        //string[] DotArray = TagStr.Split(';');               
                        //Setting = (DotArray.Count() > 1)?DotArray[1].ToUpper().Trim():"";
                        //CompType = CompType.Replace("System.Windows.Forms.", "");                       
                    //} 
                    
                    if (Setting == "SAVE") 
                    {                    
                        //string SettingStr = control.Name + ":" + control.Text.Replace(Var.CR, "<#*#>") + Var.CR;
                        string SettingStr = "";
                                                
                        if (CompType == "TextBox")
                        {
                             SettingStr = control.Name + ":" + control.Text.ToBase64() + Var.CR;
                        } else
                        if (CompType == "CheckBox")
                        {
                            SettingStr = control.Name + ":" + ((System.Windows.Forms.CheckBox)control).Checked + Var.CR;
                        } else
                        if (CompType == "ComboBox")
                        {
                             SettingStr = control.Name + ":" + control.Text.ToBase64() + Var.CR;
                        } else
                        if (CompType == "RadioButton")
                        {
                             SettingStr = control.Name + ":" + ((System.Windows.Forms.RadioButton)control).Checked + Var.CR;
                        } else    
                        if (CompType == "TabControl")
                        {
                             SettingStr = control.Name + ":" + ((System.Windows.Forms.TabControl)control).SelectedIndex + Var.CR;
                        } else
                        SettingStr = control.Name + ":" + control.Text.ToBase64() + Var.CR;
                        
                        SettingText += SettingStr;
                    }
                }               
            }
            return SettingText;            
        }
*/
//====================================
/*
         /*public static bool FilterShow(Object FormRef,
                                      Object FormStaticFilter,
                                      Panel PanelStatic,
                                      MethodInfo MethodFilterStatic,                                    
                                      ref FilterObj filter)
        { 
            if (filter.EntityID == "") return false;                                
            var F1 = new FormFilter();
            F1.FormRef = FormRef;
            F1.cmFilterListN6.Visible = Var.UserIsAdmin;
            F1.cmFilterListN8.Visible = Var.UserIsAdmin;
            F1.cmFilterLine2.Visible  = Var.UserIsAdmin;           
            F1.PanelStatic            = PanelStatic;
            F1.FormStaticFilter       = FormStaticFilter;
            F1.filter                 = filter;                   
            F1.MethodFilterStatic     = MethodFilterStatic; 
            
            //Установка Static фильтра.            
            if (PanelStatic != null)
            {                           
                Control pnl2 = F1.Controls.Find("panelFilterStatic", true).FirstOrDefault();            
                PanelStatic.Parent = pnl2;  
                F1.tabControlFilter.DoTabVisible(F1.tabControlFilter.TabPages[0], true);               
            } else
            {
                //Скрыть вкладку статического фильтра, если его нет (при tp == null).            
                F1.tabControlFilter.DoTabVisible(F1.tabControlFilter.TabPages[0], false);                  
            } 
             
            F1.FilterLoad();  
            F1.FilterListRefresh(filter.FilterID);            
            if (F1.ShowDialog() != DialogResult.OK) return false;                         
            F1.FilterGetString(); 
            filter = F1.filter;  
            if (filter == null) return false;             
            return true;
        }   
*/
//====================================
/*
 /*public static bool FilterShow(Object FormRef,
                                      Object FormStaticFilter,
                                      Panel PanelStatic,
                                      MethodInfo MethodFilterStatic,                                    
                                      ref FilterObj filter)
        { 
            if (filter.EntityID == "") return false;                                
            var F1 = new FormFilter();
            F1.FormRef = FormRef;
            F1.cmFilterListN6.Visible = Var.UserIsAdmin;
            F1.cmFilterListN8.Visible = Var.UserIsAdmin;
            F1.cmFilterLine2.Visible  = Var.UserIsAdmin;           
            F1.PanelStatic            = PanelStatic;
            F1.FormStaticFilter       = FormStaticFilter;
            F1.filter                 = filter;                   
            F1.MethodFilterStatic     = MethodFilterStatic; 
            
            //Установка Static фильтра.            
            if (PanelStatic != null)
            {                           
                Control pnl2 = F1.Controls.Find("panelFilterStatic", true).FirstOrDefault();            
                PanelStatic.Parent = pnl2;  
                F1.tabControlFilter.DoTabVisible(F1.tabControlFilter.TabPages[0], true);               
            } else
            {
                //Скрыть вкладку статического фильтра, если его нет (при tp == null).            
                F1.tabControlFilter.DoTabVisible(F1.tabControlFilter.TabPages[0], false);                  
            } 
             
            F1.FilterLoad();  
            F1.FilterListRefresh(filter.FilterID);            
            if (F1.ShowDialog() != DialogResult.OK) return false;                         
            F1.FilterGetString(); 
            filter = F1.filter;  
            if (filter == null) return false;             
            return true;
        }  
*/
//====================================
/*
//Показ фильтра: FormFilter.FilterShow(FormFilt, 1, 1);
        //Это СТАТИЧЕСКИЙ! метод, который показывает фильтр. Это главный метод вызова фильтра.                          
        public static bool Filter(Object FormRef,
                                    string EntityName,
                                    string FormStaticName, 
                                    string MethodStaticName,
                                    string PanelStaticName,
                                    ref FilterObj filter
                                    )
        {   
            Assembly asm;
            string projectName = ((Form)FormRef).Name;
            if (!sys.FindAssembly(projectName, out asm)) return false;
                       
            Object FormStatic = null;
            FormStatic = asm.CreateInstance("FBA." + FormStaticName);
            if (FormStatic == null) return false;
            Control pnl2 = ((Form)FormStatic).Controls.Find(PanelStaticName, true).FirstOrDefault();   
             
            //Type tp1 = asm.GetType("FormFilt");
            //Type tp2 = Type.GetType("FormFilt", false, true);
            Type tp = FormStatic.GetType();
            MethodInfo mi     = null;
            if (tp != null)
            {                               
                //Создание объекта формы Static фильтра.
                //System.Reflection.ConstructorInfo ci = tp.GetConstructor(new Type[] { });     
                //F2 = ci.Invoke(new object[] { });
                                                               
                //Метод
                //var ObjParams = new Object[2];
                //ObjParams[0]  = FormRef;
                //ObjParams[1]  = filter;                       
                mi = tp.GetMethod(MethodStaticName);                                               
            }
            filter.EntityID = sys.GetEntityID(EntityName);
            if (filter.EntityID == "") return false;                                
            var F1 = new FormFilter();
            F1.FormRef = FormRef;
            F1.cmFilterListN6.Visible = Var.UserIsAdmin;
            F1.cmFilterListN8.Visible = Var.UserIsAdmin;
            F1.cmFilterLine2.Visible  = Var.UserIsAdmin;           
            F1.PanelStatic            = (Panel)pnl2;
            F1.FormStaticFilter       = FormStatic;
            F1.filter                 = filter;                   
            F1.MethodFilterStatic     = mi; 
            
            //Установка Static фильтра.            
            if (pnl2 != null)
            {                           
                //Control pnl2 = F1.Controls.Find("panelFilterStatic", true).FirstOrDefault();            
                pnl2.Parent = F1.panelFilterStatic;  
                F1.tabControlFilter.DoTabVisible(F1.tabControlFilter.TabPages[0], true);               
            } else
            {
                //Скрыть вкладку статического фильтра, если его нет (при tp == null).            
                F1.tabControlFilter.DoTabVisible(F1.tabControlFilter.TabPages[0], false);                  
            } 
             
            F1.FilterLoad();  
            F1.FilterListRefresh(filter.FilterID);            
            if (F1.ShowDialog() != DialogResult.OK) return false;                         
            F1.FilterGetString(); 
            filter = F1.filter;  
            if (filter == null) return false;             
            return true;
              
                                   
            //Фильтр.
            /*var filter        = new FilterObj();
            filter.EntityID   = sys.GetEntityID(EntityName);
            
            
            Object F2         = null;
            Panel StaticPanel = null;
            MethodInfo mi     = null;
            
            string FilerStaticClassName = "FBA." + FormStaticName;
            Type tp = Type.GetType(FilerStaticClassName, false, true);
 
            //Если класс формы статического фильтра найден, то...
            if (tp != null)
            {                               
                //Создание объекта формы Static фильтра.
                System.Reflection.ConstructorInfo ci = tp.GetConstructor(new Type[] { });     
                F2 = ci.Invoke(new object[] { });
                                                               
                //Метод
                var ObjParams = new Object[2];
                ObjParams[0]  = FormRef;
                ObjParams[1]  = filter;                       
                mi = tp.GetMethod(MethodStaticName);     
                           
                //Панель       
                Control pnl2 = ((Form)F2).Controls.Find(PanelStaticName, true).FirstOrDefault();   
                StaticPanel = (Panel)pnl2;
            }
            
            //Вызов стандарной формы фильтра. 
            //Если статического фильтра нет, то форма фильтра 
            //все равно откроется, но вкладка статического фильтра будет скрыта.
            if (!FormFilter.FilterShow(FormRef,
                                       F2,
                                       StaticPanel, 
                                       mi,                                     
                                       ref filter)) return ""; 
            */
//return "";//filter.FullQuery;
//}  

//====================================
/*
       //Присвоедине значений компонентам формы
        /*private void SetValueComponent(Form fm)
        {
            
            
            //var ctrl = new ArrayList();
            GetAllControls(fm.Controls, ref ctrl);
            sys.SM(ctrl.ToString());
            
            var SQLStr = new StringBuilder();
            SQLStr.Append("SELECT ");
       
            for (int i = 0; i < ctrl.Count; i++)               
            {            
                string s = ctrl[i].ToString();
                int N1 = s.IndexOf(':');
                int N2 = s.IndexOf(" text:"); 
                
                  //comboBox1:fbaAttr.Type text:000
                
                string ControlName = s.Substring(0, N1);
                string ControlTag  = s.Substring(N1 + 1, N2 - N1 - 1);
                string ControlText = s.Substring(N2 + 6);
                
                sys.SM("ControlName = <" + ControlName + ">" + Var.CR + 
                       "ControlTag = <"  + ControlTag  + ">" + Var.CR + 
                       "ControlText = <" + ControlText  + ">" + Var.CR);
                
            }
            //string SQL = "SELECT AttributeID, Type, Brief, Name, Kind FROM fbaAttr WHERE AttributeID = 545";
        }  
*/
//====================================
/*
 //Загрузить дерево сущностей.
        private void LoadEntityTree()
        {             
            //sys.LoadTreeFromDataTable(treeViewAttr, DTEnt, "ID", "ParentID", "Name", true);                                                 
            //TreeNode argentinaNode = new TreeNode { Text = "Аргентина", ImageIndex=0, SelectedImageIndex=0 };
            //treeView1.Nodes.Add(argentinaNode);
            dgvAttr.DataSource = null;
            dgvTable.DataSource = null;
            
            System.Data.DataTable DTEnt;  
            string WHERE = "";
            if (tbFind.Text != "")  WHERE = " WHERE (Brief LIKE '%" + tbFind.Text + "%') ";
                      
            Var.conLite.SelectDT("SELECT DISTINCT * FROM fbaAttrParent " + WHERE, out DTEnt);
            treeViewAttr.Nodes.Clear();
            
            foreach (DataRow dr in DTEnt.Select("ParentID = 0"))
            {
                var node = new TreeNode();
                node.Text = (string)dr["Name"];
                node.Tag = dr["ID"];
                string Feature = dr["Feature"].ToString();              
                if      (Feature == "1")  node.ImageIndex = 0;
                else if (Feature == "5")  node.ImageIndex = 0;
                else if (Feature == "2")  node.ImageIndex = 2;
                else if (Feature == "4")  node.ImageIndex = 2;
                else if (Feature == "34") node.ImageIndex = 2;
                else node.ImageIndex = 1;
                node.SelectedImageIndex = node.ImageIndex;
                              
                treeViewAttr.Nodes.Add(node);
                AddNodes(DTEnt, node);
            }
            treeViewAttr.Sort();
        }
        
        //Добавление узла дерева сущностей.
        private void AddNodes(System.Data.DataTable DTEnt, TreeNode node)
        {    
            foreach (DataRow dr in DTEnt.Select("ParentID = " + node.Tag.ToString()))
            {
                var node1 = new TreeNode();
                node1.Text = (string)dr["Name"];
                node1.Tag = dr["ID"];
                string Feature = dr["Feature"].ToString();              
                if      (Feature == "1")  node1.ImageIndex = 0;
                else if (Feature == "5")  node1.ImageIndex = 0;
                else if (Feature == "2")  node1.ImageIndex = 2;
                else if (Feature == "4")  node1.ImageIndex = 2;
                else if (Feature == "34") node1.ImageIndex = 2;
                else node1.ImageIndex = 1;
                node1.SelectedImageIndex = node1.ImageIndex;
                node.Nodes.Add(node1);
                AddNodes(DTEnt, node1);
             }
        } 
*/
//====================================
/*
     /*}  catch (Exception ex)
            {
                if (Var.ComputerName != "COMP2879")
                {
                    sys.SM("Ошибка: " + ex.Message);
                    return false;
                }  
                
                Var.UserID     = "1";
                sys.UserName  = "admin";
                sys.RoleBrief = "admin";
                sys.RoleID    = "1";
                
            } 
*/
//====================================
/*
 //Загрузить дерево сущностей.
        private void LoadEntityTree()
        {             
            //sys.LoadTreeFromDataTable(treeViewAttr, DTEnt, "ID", "ParentID", "Name", true);                                                 
            //TreeNode argentinaNode = new TreeNode { Text = "Аргентина", ImageIndex=0, SelectedImageIndex=0 };
            //treeView1.Nodes.Add(argentinaNode);
            dgvAttr.DataSource  = null;
            dgvTable.DataSource = null; 
            treeViewAttr.Nodes.Clear();
            System.Data.DataTable DT;  
            
            string WHERE = "";
            if (tbFind.Text != "")  WHERE = " AND (EnBrief2 LIKE '%" + tbFind.Text + "%') ";  
            treeViewAttr .
            
            string SQL = "SELECT DISTINCT t1.EnChildID, t1.EnBrief2, t1.EnBriefName2, t1.ParentID, t2.Feature FROM fbaAttrParent t1 " + Var.CR +
                "LEFT JOIN fbaEntity t2 ON t2.ID = t1.EnChildID WHERE 1=1 " + WHERE + " AND EnChildID > 0 AND Feature is not null ";   // ORDER BY t2.Feature 
            Var.conLite.SelectDT(SQL, out DT);
                                     
            foreach (DataRow dr in DT.Select("ParentID = 0")) //" ParentID = '' "))
            {
                var node  = new TreeNode();
                node.Text      = dr["EnBriefName2"].ToString(); //sys.DTValue(DT, i, "EnBriefName2");//
                node.Tag       = dr["EnChildID"];               //sys.DTValue(DT, i, "EnChildID");
                string Feature = dr["Feature"].ToString();      //sys.DTValue(DT, i, "Feature");
                if      (Feature == "1")  node.ImageIndex = 0;
                else if (Feature == "5")  node.ImageIndex = 0;
                else if (Feature == "2")  node.ImageIndex = 2;
                else if (Feature == "4")  node.ImageIndex = 2;
                else if (Feature == "34") node.ImageIndex = 2;
                else node.ImageIndex = 1;
                node.SelectedImageIndex = node.ImageIndex;
                              
                treeViewAttr.Nodes.Add(node);
                AddNodes(DT, node);
            }
            treeViewAttr.Sort();
        }
        
        //Добавление узла дерева сущностей.
        private void AddNodes(System.Data.DataTable DT, TreeNode node)
        {    
            foreach (DataRow dr in DT.Select("ParentID = " + node.Tag.ToString()))
            {
                var node1 = new TreeNode();
                node1.Text     = dr["EnBriefName2"].ToString();
                node1.Tag      = dr["EnChildID"];
                string Feature = dr["Feature"].ToString();              
                if      (Feature == "1")  node1.ImageIndex = 0;
                else if (Feature == "5")  node1.ImageIndex = 0;
                else if (Feature == "2")  node1.ImageIndex = 2;
                else if (Feature == "4")  node1.ImageIndex = 2;
                else if (Feature == "34") node1.ImageIndex = 2;
                else node1.ImageIndex = 1;
                node1.SelectedImageIndex = node1.ImageIndex;
                node.Nodes.Add(node1);
                AddNodes(DT, node1);
             }
        }  
*/
//====================================
/*
   /*public static TreeNode SearchNode2(string SearchText, TreeNode StartNode)
        {             
            if (StartNode.Text.ToLower().Contains(SearchText.ToLower())) return StartNode;
            for (int i = 0; i < StartNode.Nodes.Count; i++) 
            {               
                if (SearchNode(SearchText, StartNode.Nodes[i]) != null) return StartNode.Nodes[i];
            }
        } 
*/
//====================================
/*
           //TreeNode[] findTreeNodes = treeViewAttr.Nodes.Find(tbFind.Text, true);
            //if (findTreeNodes.Length > 0) treeViewAttr.SelectedNode = findTreeNodes[0];
             //string WHERE = "";
            //if (tbFind.Text != "")  WHERE = " WHERE (Brief LIKE '%" + tbFind.Text + "%') ";
            //foreach (DataRow dr in DTEnt.Select(" Brief LIKE '%ДогСтр%' "))    
            //TreeNode[] findTreeNodes = treeViewAttr.Nodes.Find(SelName, true);   
*/
//====================================
/*
  //SetDoubleBuffered(tbView);             
        //Resize += FormFilter_Resize;
        //this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

        //Способ 1. Возможно так форма будет прорисовываться быстрее.
        /*public static void SetDoubleBuffered(Control control)
        {
          // set instance non-public property with name "DoubleBuffered" to true
          typeof(Control).InvokeMember("DoubleBuffered",
              BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
              null, control, new object[] { true });
        }*/


//Способ 2. Возможно так форма будет прорисовываться быстрее. 
/*protected override CreateParams CreateParams       
{       
    get           
    {       
        CreateParams cp = base.CreateParams;           
        cp.ExStyle |= 0x02000000;           
        return cp;       
    }       
}*/

//====================================
/*
   
            //string SQL;
            //SQL = "SELECT DISTINCT EnID, EnBrief1, ParentID, Table_ID, Table_IDFieldName, Table_Name, NumLevel, Table_Type " + Var.CR +
            //       "FROM dbo.fbaAttrParent WHERE Attr_Type <> 4 AND Attr_Kind <> 3 AND Table_Name IS NOT NUL" + Var.CR +
            //       "AND EnBrief2 = '" + EntityBrief + "' " + Var.CR + 
            //       "ORDER BY NumLevel desc, Table_Type " + Var.CR;
           
             //var DT = new System.Data.DataTable(); 
             //if (!sys.SelectDT(DirectionQuery.Remote, RemoteSQL, out DT)) return false;

             string UpdateValues = "";
             string InsertValues = "";
             string InsertFields = "";
             
             //Если сущность наследована
             if (DT.Rows.Count > 1)
             {
                 //Если сущность не верхнего уровня или есть историчные таблицы, или и то и другое вместе, то:
                 string TablePrev = "";
                 //Цикл по таблицам. В DT уже строки отсортированы в таком порядке:
                 //Например три уровня вложенности: 
                 //1. таблица предка самого верхнего уровня
                 //2. историчные самого верхего предка
                 //3. таблица среднего предка
                 //4. историчные среднего предка
                 //5. Основная таблица обновляемой сущности
                 //6. Историчные обновляемой сущности.
                 for (int i = 0; i < DT.Rows.Count - 1; i++)
                 {                                      
                     string TableName         = sys.DTValue(DT, "Table_Name");
                     string Table_IDFieldName = sys.DTValue(DT, "Table_IDFieldName");
                     string Table_Type        = sys.DTValue(DT, "Table_Type");
                     string EnID              = sys.DTValue(DT, "EnID");
                     //string QueryInsert       = "";  
                     
                     //Иногда так бывает, что атрибут заведен на потомке, а таблица в которой он находится в предке.
                     //Это бред конечно, но такая систуация встречается, поэтому вот проверяем:
                     if (TablePrev == TableName) continue; 
                                                         
                     //Если ничего не найдено, то все равно вставить нужно для предков.
                     //if ((UpdateValues == "") && (InsertValues == ""))
                     //{
                     //    if (i == 0) QueryInsert = "INSERT INTO " + TableName + " (EntityID) VALUES (" + EnID + "); SELECT @@IDENTITY";
                     //}
                     
                     
                     
                     TablePrev =  TableName;
                 }
             } else
             {
                 //Если сущность верхнего уровня и историчных таблиц нет, то все проще:
                 string TableName         = sys.DTValue(DT, "Table_Name");
                 string Table_IDFieldName = sys.DTValue(DT, "Table_IDFieldName");
                 string Table_Type        = sys.DTValue(DT, "Table_Type");
                 string EnID              = sys.DTValue(DT, "EnID");
                 Entity_SQLINSERT_UPDATE_DELETE_GetTable(QueryName, ObjectID, UpdateValues, InsertValues, InsertFields,                                                  
                                                   TableName, Table_IDFieldName, Table_Type, EnID, StateDate,  
                                                   out QueryINSERT, out QueryUPDATE, out QueryDELETE);                
                 return true;
*/
//====================================
/*
        //Парсим Tag контрола. 
        //Пример: ParseTag("Main1.Страхователь.ИНН;SAVE", out QueryName, out Attr, out Setting);
        //На выходе: QueryName = Main1, Attr = Name, AttrLokkup = ИНН, Setting = SAVE
        /*public static void ParseTag(string TagStr, out string QueryName, out string Attr, out string AttrLookup, out string Setting)
        {
           

            QueryName  = "";
            Attr       = "";
            AttrLookup = "";
            Setting   = "";           
            string[] DotArray1 = TagStr.Split(';');               
            Setting = (DotArray1.Count() > 1)?DotArray1[1].ToUpper().Trim():"";           
            string[] DotArray2 = DotArray1[0].Split('.');   
            if (DotArray2.Length > -1) QueryName = DotArray2[0];
            if (DotArray2.Length > 0)  QueryName = DotArray2[1];
            if (DotArray2.Length > 1)  QueryName = DotArray2[2];                  
        }*/

//====================================
/*
      //Парсим AttrBrief контрола.
        /*private void ParseAttrBrief(string AttrBrief, out string QueryName, out string Attr)
        {
            QueryName = "";
            Attr      = "";    
            if (AttrBrief == null) return;
            if (AttrBrief.IndexOf('.') == -1) return;
            string[] DotArray = AttrBrief.Split('.');
            if  (DotArray.Length == 0) return;
            QueryName = DotArray[0];
            Attr      = DotArray[1];
        }*/

//====================================
/*
          //Получить или установить значение атрибута (поля таблицы)на которое указывает QueryName и Attr.
        //Пример чтения: string MyValue = Obj.Value("Main1.ContractName");    
        //Пример записи: string MyValue = Obj.Value("Main1.ContractName");  
        //public string Value(string TagStr)
        //{
        //    return GetValue(TagStr);
        //}
        
        //Получить или установить значение атрибута (поля таблицы)на которое указывает QueryName и Attr.
        //Пример чтения: string MyValue = Obj.Value("Main1.ContractName");    
        //Пример записи: string MyValue = Obj.Value("Main1.ContractName");  
        
        //public bool Value(string TagStr, string ValueStr)
        //{
        //    return SetValue(TagStr, ValueStr);            
        //}
        
*/
//====================================
/*
         //Проставление запросов для обновления каждой таблицы.
        //private void EntityUpdate(string QueryName)
        //{       
        /*for (int i = 0; i < TblCount; i++)
        {                                                       
            if (Tbl[i, tQueryName] != QueryName) continue;

            string TableName    = Tbl[i, tTableName];
            string TableType    = Tbl[i, tTableType];
            string IDFieldName  = Tbl[i, tIDFieldName];
            string EntityID     = Tbl[i, tEntityID];

            if (TableName   == "") continue;
            if (TableType   == "") continue;
            if (IDFieldName == "") continue; 
            if (EntityID    == "") continue; 

            string ObjectID     = Tbl[i, tObjectID];
            string StateDate    = Tbl[i, tStateDate];  

            string UpdateValues = "";
            string InsertFields = "";
            string InsertValues = "";
            EntityQuery_INSERT_UPDATE_GetFields(QueryName, TableName, out UpdateValues, out InsertValues, out InsertFields);

            string QueryUPDATE  = "";
            string QueryINSERT  = "";                 
            string QueryDELETE  = "";

            //Обычная.
            if (TableType == "1")
            {
                QueryDELETE  = "DELETE FROM " + TableName + " WHERE EntityID = " + EntityID + " AND " + IDFieldName + " = " + ObjectID + Var.CR;                                                                        
                QueryUPDATE  = "UPDATE " + TableName + " SET " + UpdateValues + " WHERE EntityID = " + EntityID + " AND " + IDFieldName + " = " + ObjectID + Var.CR;                               
                InsertFields = "EntityID, " + InsertFields;
                InsertValues = EntityID + ", " + InsertValues;
                QueryINSERT  = "INSERT INTO " + TableName + " (" + InsertFields + ") VALUES (" + InsertValues + ")" + Var.CR;

           }                      
            //Историчная.
            if (TableType == "2") 
            {
                QueryDELETE  = "DELETE FROM " + TableName + " WHERE EntityID = " + EntityID + " AND " + IDFieldName + " = " + ObjectID + " AND StateDate = " + StateDate + Var.CR;
                QueryUPDATE  = "UPDATE " + TableName + " SET " + UpdateValues + " WHERE EntityID = " + EntityID + " AND " + IDFieldName + " = " + ObjectID + " AND StateDate = " + StateDate + Var.CR;
                InsertFields = "EntityID, StateDate, " + InsertFields;
                InsertValues = EntityID + ", " + StateDate + ", " + InsertValues;
                QueryINSERT  = "INSERT INTO " + TableName + " (" + InsertFields + ") VALUES (" + InsertValues + ")" + Var.CR; 
            }

            if (UpdateValues != "") Tbl[i, tUpdate] = QueryUPDATE = "";
            if ((InsertFields != "") || (InsertValues != "")) Tbl[i, tInsert] = QueryINSERT;                         
            Tbl[i, tDelete] = QueryDELETE;                          
        } */
//}

//Запись значений в БД.
//public bool UpdateObj(string QueryName = "")
//{
//    PrepareQuery(QueryName);
//    return SendQuery(QueryName, "UPDATE");  
//}

//Запись значений в БД.
//public bool InsertObj(string QueryName = "")
//{
//    PrepareQuery(QueryName);
//    return SendQuery(QueryName, "INSERT");  
//}                
//Событие изменения значения Text компонента.
/*private void ControlValueChanged(object sender, EventArgs e)
{        
    string ControlName  = ((Control)sender).Name;  
    string ControlValue = ((Control)sender).Text;           
    //Обновление значения компонента в массиве Ref.
    for (int i = 0; i < RefCount; i++)
    { 
        if (Ref[i, iName] == ControlName)
            Ref[i, iValueNew] = ControlValue;
    }                     
}*/

//Заполнение массива ValueNew в массиве Ref из свойства Text компонентов. 
//private void FillRefValueNew()
//{                                    
//    for (int i = 0; i < RefCount; i++)
//    {            
//        Ref[i, iValueNew] = form.Controls.Find(Ref[i, iName], true).FirstOrDefault().Text;                  
//    }          
//}  

//Сборка запросов по списку таблиц.
//private void EntityUpdate_GetQuery(string QueryName, out string UpdateSQL, out string InsertSQL, out string DeleteSQL)
//{
//UpdateSQL = "";
//InsertSQL = "";
//DeleteSQL = "";
/*                      
string UpdateSQL1 = "";
string UpdateSQL2 = "";
string UpdateSQL3 = "";

string InsertSQL1 = "";
string InsertSQL2 = "";
string InsertSQL3 = "";

string DeleteSQL1 = "";
string DeleteSQL2 = "";
string DeleteSQL3 = "";

for (int i = 0; i < TblCount; i++)
{                                                       
    if (Tbl[i, tQueryName] != QueryName) continue;
    if (Tbl[i, tAction] != "Parent") continue;  //родительские таблицы
    UpdateSQL1 = UpdateSQL1 + Tbl[i, tUpdate] + Var.CR;
    InsertSQL1 = InsertSQL1 + Tbl[i, tInsert] + Var.CR;
    DeleteSQL1 = DeleteSQL1 + Tbl[i, tDelete] + Var.CR;
}

for (int i = 0; i < TblCount; i++)
{                                                       
    if (Tbl[i, tQueryName] != QueryName) continue;
    if (Tbl[i, tAction] != "Attr") continue;  //таблицы объекта
    if (Tbl[i, tTableType] != "1") continue;  //Главная таблица объекта
    UpdateSQL2 = UpdateSQL2 + Tbl[i, tUpdate] + Var.CR;
    InsertSQL2 = InsertSQL2 + Tbl[i, tInsert] + Var.CR;
    DeleteSQL2 = DeleteSQL2 + Tbl[i, tDelete] + Var.CR;
}

for (int i = 0; i < TblCount; i++)
{                                                       
    if (Tbl[i, tQueryName] != QueryName) continue;
    if (Tbl[i, tAction] != "Attr") continue;  //таблицы объекта
    if (Tbl[i, tTableType] != "2") continue;  //Историчные таблицы объекта
    UpdateSQL3 = UpdateSQL3 + Tbl[i, tUpdate] + Var.CR;
    InsertSQL3 = InsertSQL3 + Tbl[i, tInsert] + Var.CR;
    DeleteSQL3 = DeleteSQL3 + Tbl[i, tDelete] + Var.CR;
}
//Для сборки UPDATE. Сначала родительские таблицы, затем главная объекта, затем историчные таблицы объекта.
UpdateSQL = UpdateSQL1 + UpdateSQL2 + UpdateSQL3;

//Для сборки INSERT. Сначала родительские таблицы, затем главная объекта, затем историчные таблицы объекта.              
InsertSQL = InsertSQL1 + InsertSQL2 + InsertSQL3;

//Для сборки DELETE. Сначала историчные таблицы объекта, затем главная объекта, затем родительские таблицы.
DeleteSQL = DeleteSQL1 + DeleteSQL2 + DeleteSQL3;*/
//}

//Сборка UPDATE для типа запроса из атрибутов сущности.        
//private void GetUpdateEntity()
//{                                                                                                   
/*for (int i = 0; i < EntCount; i++)
{               
    if (Ent[i, nTypeAction] != "Entity") continue;
    EntityUpdate(Ent[i, nQueryName]);
}

for (int i = 0; i < EntCount; i++)
{
    if (Ent[i, nTypeAction] != "Entity") continue;
    string UpdateSQL = "";
    string InsertSQL = "";
    string DeleteSQL = "";
    EntityUpdate_GetQuery(Ent[i, nQueryName], out UpdateSQL, out InsertSQL, out DeleteSQL);
    Ent[i, nUpdate] = UpdateSQL;
    Ent[i, nInsert] = InsertSQL;
    Ent[i, nDelete] = DeleteSQL;                              
}*/
//}  

//====================================
/*
              /*  Ent[EntCount, nPos]         = EntCount.ToString();
            Ent[EntCount, nTypeAction]  = "Table";
            Ent[EntCount, nDirection]   = Direction;           
            Ent[EntCount, nEntityBrief] = "";
            Ent[EntCount, nQueryName]   = QueryName;
            Ent[EntCount, nTableName]   = TableName;            
            Ent[EntCount, nIDFieldName] = IDFieldName;
            Ent[EntCount, nLanguage]    = "SQL"; 
            Ent[EntCount, nDirect]      = "0";
            Ent[EntCount, nNeedSave]    = "1"; 
            Ent[EntCount, nObjectID]    = ObjectID;
            Ent[EntCount, nStateDate]   = StateDate;           
            Ent[EntCount, nPosLocal]    = "";
            Ent[EntCount, nPosRemote]   = "";
            Ent[EntCount, nSelect]      = "";
            Ent[EntCount, nUpdate]      = ""; 
            Ent[EntCount, nInsert]      = "";
            Ent[EntCount, nDelete]      = "";*/

//====================================
/*
   //Сборка части запросов.
        private bool Entity_SQLINSERT_UPDATE_DELETE_GetTable(
                                                   string QueryName,
                                                   string ObjectID,
                                                   
                                                   string UpdateValues, 
                                                   string InsertValues, 
                                                   string InsertFields,
                                                   
                                                   string TableName,
                                                   string Table_IDFieldName,
                                                   string Table_Type,
                                                   string EnID,  
                                                   string StateDate, 
                                                   
                                                   out string QueryINSERT,
                                                   out string QueryUPDATE,
                                                   out string QueryDELETE)
        {       
            
                                                         int CountFields;
            EntityQuery_INSERT_UPDATE_GetFields(QueryName, 
                                                TableName, 
                                                //"",
                                                //"",                                               
                                                EnID,
                                                //"",
                                                "",
                                                out UpdateValues, 
                                                out InsertValues, 
                                                out InsertFields, 
                                                out CountFields);
            
            QueryINSERT = "";
            QueryUPDATE = "";
            QueryDELETE = "";  
                
            if (CountFields == 0) return false;
            
            QueryDELETE  = "DELETE FROM " + TableName + " WHERE " + Table_IDFieldName + " = " + ObjectID;  
            if (Table_Type == "1") //Обычная таблица.
            {
                QueryUPDATE  = "UPDATE " + TableName + " SET " + UpdateValues + " WHERE EntityID = " + EnID + " AND " + Table_IDFieldName + " = " + ObjectID;
                QueryINSERT  = "INSERT INTO " + TableName + " (" + InsertFields + ") VALUES (" + InsertFields + "); SELECT @@IDENTITY";
            }
            if (Table_Type == "2") //Историчная таблица.
            {
                QueryUPDATE  = "UPDATE " + TableName + " SET " + UpdateValues + " WHERE EntityID = " + EnID + " AND " + Table_IDFieldName + " = " + ObjectID + " AND StateDate = '" + StateDate + "'";
                QueryINSERT  = "INSERT INTO " + TableName + " (" + InsertFields + ") VALUES (" + InsertFields + "); SELECT @@IDENTITY";
            }
            return true;
        }

        //Получить части для сборки запросов UPDATE, INSERT. Пример:
        //UPDATE SomeTable SET UpdateValues
        //INSERT INTO SomeTable (InsertFields) VALUES (InsertValues)
        //На выходе части запросов INSERT, UPDATE для вставки нового объекта и обновления существующего. 
        private void EntityQuery_INSERT_UPDATE_GetFields(string QueryName, 
                                                         string TableName,
                                                         //string Table_IDFieldName,
                                                         //string Table_Type,
                                                         string EnID,  
                                                         //string StateDate,
                                                         string ObjectID,
                                                                                                                                                                          
                                                         out string UpdateValues, 
                                                         out string InsertValues, 
                                                         out string InsertFields,
                                                         out int CountFields)
        {
            UpdateValues = "";
            InsertValues = "EntityID";
            InsertFields = EnID;
            CountFields  = 0;
            int i = 10000;
            if (ObjectID != "") 
            {
                if (InsertFields != "") InsertFields += ", ";
                if (InsertValues != "") InsertValues += ", "; 
                InsertFields = InsertFields + Ref[i, iFieldName];
                InsertValues = InsertValues + "'" + Ref[i, iValueNew] + "'";
            }
            
            for (int m = 0; m < RefCount; m++)
            {                      
                if (Ref[m, iQueryName]  != QueryName) continue;  
                if (Ref[m, iTableName]  != TableName) continue;
                if (Ref[m, iTypeAction] != "Entity") continue;                         
                if (Ref[m, iTableName]  == "") continue;
                if (Ref[m, iTableType]  == "") continue;       
                if (Ref[m, iValueOld]   == Ref[m, iValueNew]) continue;   
                
                //string StateDate,
                //string EnID, 
                
                //Для UPDATE.
                if (UpdateValues != "") UpdateValues += ", ";
                UpdateValues = UpdateValues + Ref[m, iFieldName] + " = '" + Ref[m, iValueNew] + "'";
                 
                //Для INSERT.
                if (InsertFields != "") InsertFields += ", ";
                if (InsertValues != "") InsertValues += ", ";
                InsertFields = InsertFields + Ref[m, iFieldName];
                InsertValues = InsertValues + "'" + Ref[m, iValueNew] + "'";
                
                CountFields = CountFields + 1;
            }                       
        }

*/
//====================================
/*
  
*/
//====================================
/*
  
*/
//====================================
/*
  
*/
//====================================
/*
  
*/
//====================================
/*
  
*/
//====================================
/*
  
*/ 