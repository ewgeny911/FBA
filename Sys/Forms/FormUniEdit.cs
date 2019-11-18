/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 22.02.2018
 * Время: 10:38
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Permissions;
using DevAge.Windows.Forms;

namespace FBA
{  
    //Attr_Type = 1 - (Поле,      Field)   Поле
    //Attr_Type = 2 - (Ссылка,    Link)    Ссылка
    //Attr_Type = 3 - (УниСсылка, UniLink) Универсальная ссылка
    //Attr_Type = 4 - (Массив,    Array)   Массив
    
    //Attr_Kind = 1 - (Простой,   Simple)  Атрибут из базы данных
    //Attr_Kind = 2 - (Системный, System)  Системный
    //Attr_Kind = 3 - (Вычисляемый, Calc)  Вычисляемый
    // 
    
    ///Класс формы универсального редактирования объектов.
    public partial class FormUniEdit : FormSim
    {       
        int AttrCount = 0;
        int ChangeCount = 0;
        string EntityBrief;
        string ObjectID;
        System.Data.DataTable DTAttr = null;
        System.Data.DataTable DTData = null;
        System.Data.DataTable DTHist = null;     
        
        string SQLAttrHist  = "";
        string SQLAttrData  = "";
        string SQLStateData = "";       
        string Operation    = ""; 
        string StateDate    = "";
        
        ///Operation: INSERT, DELETE, UPDATE
        public FormUniEdit(string Operation, string EntityBrief, string ObjectID, string StateDate = "")
        {          
            InitializeComponent();           
            this.Operation   = Operation;
            this.EntityBrief = EntityBrief;
            this.ObjectID    = ObjectID; 
            if (StateDate == "") StateDate = Var.MinStateDateSQL;
            this.StateDate   = StateDate;
        }
       
        ///Хм... благодаря этому коду форма при измениии размеров перерисовывается значительно быстрее. Взято отсюда:
        ///https://social.msdn.microsoft.com/Forums/windows/en-US/c27693d2-9b4e-4395-9e90-402a6af96307/splitcontainer-flickering-issue-while-resizing-it?forum=winforms
        protected override CreateParams CreateParams       
        {       
            get           
            {       
                CreateParams cp = base.CreateParams;           
                cp.ExStyle |= 0x02000000;           
                return cp;       
            }       
        }
                        
        ///Действия, которые выполняются только один раз при старте формы.
        private void FormUniEdit_Load(object sender, EventArgs e)
        {
            LoadUniForm();                      
            AddAttrToForm();
        }
        
        ////Кнопка - Cancel. Закрытие формы, без применения изменений.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        ///Кнопка - OK. Применить изменения.
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ChangeCount == 0) 
            {
                Close();
                return;               
            }
            string SQL = CollectChange();
            if (sys.SM(SQL, MessageType.Question)) sys.Exec(DirectionQuery.Remote, SQL);
            Close();             
        }
        
        ///Двойной клик на таблице StateDate. Перейти на другую дату состояния.
        private void dgvStateDate_DoubleClick(object sender, EventArgs e)
        {
            //EntityBrief = "ДогСтрах";
            //ObjectID = "2776312";
            //sys.DGValue()dgvStateDate.           
            //string StateDate = dgvStateDate.SelectedRows[0].Cells["StateDate"].Value.ToString(); 
            string StateDate = dgvStateDate.DataGridViewSelected("StateDate");
            string StateDateSQL = sys.ConvertDate4Server(StateDate);
            AddAttrToForm();
        }  
       
        ///Отмечаем ручное изменение. 
        private void AttrValueChanged(object sender, EventArgs e)
        {
            string TagStr = ((Control)sender).Tag.ToString();             
            if ((TagStr == "") || (TagStr == "-1")) return; //DTData.Field(i + 1, "Attr_Brief")
            int i = TagStr.ToInt();  
            ChangeCount++;
            
            //Признак изменения.
            DTData.Rows[i]["ValueNew"] = "1";
            
            if ((DTData.Value(i, "Attr_Type") == "2") && (sender.GetType().ToString() == "FBA.EditFBA"))
                DTData.Rows[i]["AttrValueNew1"] = ((EditFBA)sender).Text;
            
            if ((DTData.Value(i, "Attr_Type") == "1") && (sender.GetType().ToString() == "System.Windows.Forms.TextBox"))
                DTData.Rows[i]["AttrValueNew1"] = ((TextBox)sender).Text;           
        }
        
        ///Собрать все ручные изменения. 
        private string CollectChange()
        {
            string SQL = "EXEC spen_SaveObject3 '" + Operation + "'," + ObjectID + ",'" + EntityBrief + "'";
            for (int i = 0; i < DTData.Rows.Count; i++)
            {                                             
                if (DTData.Value(i, "ValueNew") != "1") continue;   
                
                string AttrValueNew1 = DTData.Value(i, "AttrValueNew1");
                string Attr_Value1   = DTData.Value(i, "Attr_Value1");              
                if (AttrValueNew1 == Attr_Value1) continue;
                
                string AttrValueNew2 = DTData.Value(i, "AttrValueNew2");   
                string Attr_Value2   = DTData.Value(i, "Attr_Value2");
                if (AttrValueNew2 == Attr_Value2) continue;
                
                string Attr_Brief    = DTData.Value(i, "Attr_Brief");
                string Attr_Type     = DTData.Value(i, "Attr_Type");
                Attr_Value1 = Attr_Value1.QueryQuote();
                SQL = SQL + ", '" + Attr_Brief + "','" + Attr_Value1 + "'";                                   
            }
            return SQL;
        }
        
        ///Действия, которые выполняются только один раз при старте формы.
        private void LoadUniForm()
        {
            //Получаем все данные по атрибутам. Заполняем таблицу DTAttr.
            //В качестве StateDate будет @SD, чтобы получить данные на нужную дату нужно заменить @SD на нужный StateDate.
            SQLAttrData = GetSQL_AttrData(out DTAttr, "");
            
            //Заполнение таблицы историчных состояний объекта.
            SQLStateData = GetSQL_StateDate(DTAttr);
            sys.SelectGV(DirectionQuery.Remote, SQLStateData, dgvStateDate);          
        }
        
        ///Собрать запрос SQLAttrData и DTAttr для получении информации по атрибутам.
        private string GetSQL_AttrData(out System.Data.DataTable DTAttrList, string StateDate = "")
        {                
            //Получение информации по атрибутам.
            string SQL = "SELECT Attr_Brief, Attr_Mask, Attr_Type, Attr_Kind, Table_Type, Table_Name, Table_IDFieldName, " +
                "Table_Field, Table_Field2," +
                "DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, TABLE_SCHEMA " +
                "FROM fbaAttrParent WHERE DATA_TYPE <> 'image' AND Attr_Kind = 1 AND EnBrief2 = '" + EntityBrief + "' ORDER BY Attr_Brief "; // + "' AND Table_Type = 2 ";
            sys.SelectDT(DirectionQuery.Local, SQL, out DTAttrList);   
                                                             
            //Собрать запрос для получения значений всех атрибутов.  
            var str =  new StringBuilder();
            for (int i = 0; i < DTAttrList.Rows.Count; i++)
            {                                             
                string Attr_Brief        = DTAttrList.Value(i, "Attr_Brief");
                string Attr_Mask         = DTAttrList.Value(i, "Attr_Mask");
                string Attr_Type         = DTAttrList.Value(i, "Attr_Type");
                string Attr_Kind         = DTAttrList.Value(i, "Attr_Kind");
                string Table_Type        = DTAttrList.Value(i, "Table_Type");
                string Table_IDFieldName = DTAttrList.Value(i, "Table_IDFieldName");
                string Table_Name        = DTAttrList.Value(i, "Table_Name");
                string Table_Field       = DTAttrList.Value(i, "Table_Field");
                string Table_Field2      = DTAttrList.Value(i, "Table_Field2");
                string DATA_TYPE         = DTAttrList.Value(i, "DATA_TYPE"); 
                string CHARACTER_MAXIMUM_LENGTH = DTAttrList.Value(i, "CHARACTER_MAXIMUM_LENGTH"); 
                string IS_NULLABLE       = DTAttrList.Value(i, "IS_NULLABLE"); 
                string TABLE_SCHEMA      = DTAttrList.Value(i, "TABLE_SCHEMA"); 
                SQL = "SELECT " + 
                             "'" + Attr_Brief        + "' AS Attr_Brief, " +
                             "'" + Attr_Mask         + "' AS Attr_Mask,  " +
                             "'" + Attr_Type         + "' AS Attr_Type,  " +
                             "'" + Attr_Kind         + "' AS Attr_Kind,  " +
                             "'" + Table_Type        + "' AS Table_Type, " +
                             "'" + Table_IDFieldName + "' AS Table_IDFieldName, " + 
                             "'" + Table_Name        + "' AS Table_Name, " +
                             "'" + Table_Field       + "' AS Table_Field, " +
                             "'" + DATA_TYPE         + "' AS DATA_TYPE, " +
                             "'" + CHARACTER_MAXIMUM_LENGTH + "' AS CHARACTER_MAXIMUM_LENGTH, " +
                             "'" + IS_NULLABLE       + "' AS IS_NULLABLE, " +
                             "'" + TABLE_SCHEMA      + "' AS TABLE_SCHEMA, ";               
                string Attr_Value1 = "";
                string Attr_Value2 = "";
                string ConvertStr  = "ISNULL(CONVERT(varchar, " + Table_Field + ", 121), 'NULL')";
                if (DATA_TYPE == "varchar") ConvertStr = Table_Field;
                
                if (Table_Type == "2")
                {                   
                    Attr_Value1 = "(SELECT TOP 1 " + ConvertStr + " FROM " + Table_Name + " WHERE " + Table_IDFieldName + " = " + ObjectID + " AND StateDate = '" + StateDate + "') AS Attr_Value1, ";
                    if (Attr_Type == "3")
                        Attr_Value2 = "(SELECT TOP 1 " + ConvertStr + " FROM " + Table_Name + " WHERE " + Table_IDFieldName + " = " + ObjectID + " AND StateDate = '" + StateDate + "') AS Attr_Value2 ";
                    else 
                        Attr_Value2 = "'' AS Attr_Value2 ";
                }
                else 
                {
                    Attr_Value1 = "(SELECT TOP 1 " + ConvertStr + " FROM " + Table_Name + " WHERE " + Table_IDFieldName + " = " + ObjectID + ") AS Attr_Value1, ";
                    if (Attr_Type == "3")
                        Attr_Value2 = "(SELECT TOP 1 ISNULL(CONVERT(varchar, " + Table_Field2 + ", 121), 'NULL') FROM " + Table_Name + " WHERE " + Table_IDFieldName + " = " + ObjectID + ") AS Attr_Value2 ";
                    else 
                        Attr_Value2 = "'' AS Attr_Value2 ";
                }
                SQL = SQL + Attr_Value1 + Attr_Value2;               
                if (i < (DTAttrList.Rows.Count - 1)) SQL = SQL + "UNION ALL " + Var.CR;
                str.Append(SQL);
            }
            return str.ToString();                              
        }                                
        
        ///Собрать запрос SQLAttrHist, который вернёт таблицу со всеми историчными атрибутами и данными атрибутов.
        private string GetSQL_HistData(System.Data.DataTable DTAttrList)
        {                                                    
            var str1 = new StringBuilder();
            var str2 = new StringBuilder();
            var str3 = new StringBuilder();                                    
            for (int i = 0; i < DTAttrList.Rows.Count; i++)
            {
                if (DTAttrList.Value(i, "Table_Type") != "2") continue;
                string Alias = "t" + i.ToString();
                string s1 = Alias + ".Значение '" +  DTAttrList.Value(i, "Attr_Brief") + "'";                              
                if (str1.Length > 0) str1.Append("," + Var.CR);
                str1.Append(s1); 

                string s2 = "SELECT StateDate ДатаСостАтрибута FROM " + DTAttrList.Value(i, "Table_Name") + " WHERE " + DTAttrList.Value(i, "Table_IDFieldName") + " = " + ObjectID;
                if (str2.Length > 0) str2.Append(" UNION " + Var.CR);
                str2.Append(s2);
                
                string s3 = "FULL JOIN (SELECT StateDate ДатаСостАтрибута, ISNULL(CONVERT(varchar, " +  DTAttrList.Value(i, "Table_Field") + ", 121), '<Пустое>') Значение FROM " + DTAttrList.Value(i, "Table_Name") + " WHERE " + DTAttr.Value(i, "Table_IDFieldName") + " = " + ObjectID + ") " + Alias + " ON " + Alias+ ".ДатаСостАтрибута = tt.ДатаСостАтрибута" + Var.CR;
                str3.Append(s3); 
            } 
            return "SELECT" + Var.CR + "tt.ДатаСостАтрибута 'ДатаСостАтрибута', " + Var.CR + 
                          str1.ToString() + Var.CR + "FROM" + Var.CR + "(" + Var.CR +
                          str2.ToString() + Var.CR + ") tt" + Var.CR +
                          str3.ToString();                      
        }
        
        ///Собрать запрос SQLStateData, который вернёт таблицу со всеми историчными атрибутами, только StateDate, без данных.
        private string GetSQL_StateDate(System.Data.DataTable DTAttrList)
        {                                               
            var str1 = new StringBuilder();
            for (int i = 0; i < DTAttrList.Rows.Count; i++)
            {
                if (DTAttrList.Value(i, "Attr_Type")  != "1") continue;
                if (DTAttrList.Value(i, "Table_Type") != "2") continue;
                string s = "SELECT StateDate FROM " + DTAttrList.Value(i, "Table_Name") + " WHERE " + DTAttrList.Value(i, "Table_IDFieldName") + " = " + ObjectID;
                if (str1.Length > 0) str1.Append(" UNION " + Var.CR);
                str1.Append(s);
            }
            return str1.ToString();             
        }
        
        ///Выбор вкладки таблицы историчных значений.
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //Заполнение таблицы историчных состояний объекта.
            if (tabControl1.SelectedIndex != 1) return;
            if (DTAttr == null) return;
            if (DTHist != null) return;
            if (SQLAttrHist == "") SQLAttrHist = GetSQL_HistData(DTAttr);
            sys.SelectGV(DirectionQuery.Remote, SQLAttrHist, dgvHistAttr); 
            //dgvHistAttr.DataSource = DTHist;
        }              
        
        ///Заполнение формы атрибутами.
        private void AddAttrToForm()
        {                                                                        
            //Очищаем все панели от созданных компонентов.
            pnlField.Controls.Clear();
            pnlLink.Controls.Clear();
            pnlUniLink.Controls.Clear();
           
            //Получаем значения атрибутов на дату Statedate.
            string SQL = SQLAttrData.Replace("@SD", StateDate);                        
            sys.SelectDT(DirectionQuery.Remote, SQL, out DTData); 
            if (DTData.Rows.Count == 0) return;
                                  
            DTData.Columns.Add("ValueNew", typeof(string)); //Признак что измменение было. 1 или пусто.
            DTData.Columns.Add("AttrValueNew1", typeof(string));
            DTData.Columns.Add("AttrValueNew2", typeof(string));
            
            //datetime
            //int
            //varchar
            //numeric
                
            //Заполнение таблицы атрибутов.             
            UniEditFieldAdd(pnlField, "EntityBrief", EntityBrief, "TextBox", -1);
            UniEditFieldAdd(pnlField, "ObjectID", ObjectID, "TextBox", -1);           
            for (int i = 0; i < DTData.Rows.Count; i++)
            {                               
                string Attr_Brief        = DTData.Value(i, "Attr_Brief");
                string Attr_Mask         = DTData.Value(i, "Attr_Mask");
                string Attr_Type         = DTData.Value(i, "Attr_Type");
                string Attr_Kind         = DTData.Value(i, "Attr_Kind");
                string Table_Type        = DTData.Value(i, "Table_Type");
                string Table_IDFieldName = DTData.Value(i, "Table_IDFieldName");
                string Table_Name        = DTData.Value(i, "Table_Name");
                string Attr_Value1       = DTData.Value(i, "Attr_Value1");
                string Attr_Value2       = DTData.Value(i, "Attr_Value2");
                string DATA_TYPE         = DTData.Value(i, "DATA_TYPE");
                string CHARACTER_MAXIMUM_LENGTH = DTData.Value(i, "CHARACTER_MAXIMUM_LENGTH");
                string TypeComponent = "TextBox";
                if (DATA_TYPE == "varchar") 
                { 
                    if ((CHARACTER_MAXIMUM_LENGTH.ToInt() > 200) || (CHARACTER_MAXIMUM_LENGTH.ToInt() < 0)) TypeComponent = "Memo";
                }
                //if (DATA_TYPE == "datetime") 
                //{
                //    TypeComponent = "DateTime";
                //    if (Attr_Type == "1") UniEditFieldAdd(pnlField, Attr_Brief, Attr_Value1, TypeComponent, ref AttrIndex);                    
                //}
                if (Attr_Type == "1") UniEditFieldAdd(pnlField, Attr_Brief, Attr_Value1, TypeComponent, i);
                //if (Attr_Type == "2") UniEditFieldAdd(pnlLink,  Attr_Brief, Attr_Value1, "TextBoxDB", i);                
            }                                                                                                                                     
        }
                      
        ///Добавление нового атрибута.
        ///Type можкт быть: DateTime, Memo, TextBox.
        private void UniEditFieldAdd(FlowLayoutPanel pnl, string param1, string param2, string Type, int AttrIndex)
        {                                   
            int ParamWHeight = 27;
            var Lp  = new System.Windows.Forms.TableLayoutPanel();
            var cb1 = new System.Windows.Forms.Label();      
            object cb2 = null;
            if (Type == "TextBox") cb2 = new System.Windows.Forms.TextBox(); 
            //if (Type == "TextBoxDB") 
            //{
            //    cb2 = new FBA.EditFBA();
                //((FBA.TextBoxDB)cb2).BorderStyleTextBox =  System.Windows.Forms.BorderStyle.None;
            //}
            //if (Type == "DateTime") 
            //{                                                                                            
            //    cb2 = new System.Windows.Forms.DateTimePicker();         
            //    //((DateTimePicker)cb2).CustomFormat = "dd.MM.yyyy HH:mm:ss";
            //    ((DateTimePicker)cb2).CustomFormat = "yyyy-MM-dd HH:mm:ss";   
            //    param2 = param2.Replace(".000", "");
            //    param2 = param2.Replace("NULL", "");
            //    ((DateTimePicker)cb2).Format = System.Windows.Forms.DateTimePickerFormat.Custom;               
            //}
            
            if (Type == "Memo")    
            {
                cb2 = new FBA.FastColoredTextBoxFBA();
                ((FastColoredTextBoxFBA)cb2).Font = Var.font2;
                ParamWHeight = 100;
            }
                      
            Lp.ColumnCount = 3;           
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));              
            //Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));                               
            Lp.Controls.Add((Control)cb1, 0, 0);  
            Lp.Controls.Add((Control)cb2, 1, 0);
            Lp.Margin = new System.Windows.Forms.Padding(1);  
            
            //if (Type != "DateTime")
            //{            
            //    Lp.SetColumnSpan((Control)cb2, 2);               
            //}            
            
            if (Type == "TextBox")
            {                                 
                ((TextBox)cb2).Multiline = true;
                ((TextBox)cb2).WordWrap  = false;
                ((TextBox)cb2).BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
                                   
            Lp.Name = "LpN" + AttrCount.ToString();
            AttrCount++;
            Lp.RowCount = 1;
            Lp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            Lp.Size = new System.Drawing.Size(pnl.Width - 26, ParamWHeight);             
            Lp.Parent = pnl; //pnlField;
            Lp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            
            ((Control)cb1).Dock = DockStyle.Fill;             
            ((Control)cb1).Name = "cb1N" + AttrCount.ToString();
            ((Control)cb1).Text = param1;
                         
            ((Control)cb2).Margin = new System.Windows.Forms.Padding(0);           
            ((Control)cb2).Name = "cb2N" + AttrCount.ToString();;
            ((Control)cb2).BackColor = System.Drawing.SystemColors.Info;             
            ((Control)cb2).Dock = DockStyle.Fill;
            ((Control)cb2).Left = 0;
            ((Control)cb2).Top  = 0; 
            ((Control)cb2).Tag = AttrIndex;
            
            //if (Type == "TextBoxDB") 
            //{
             //   ((EditFBA)cb2).Text = param2; 
                 
                //((TextBoxDB)cb2).TextChanged1 += new System.EventHandler(AttrValueChanged);                
            //} else
            //{
            //    ((Control)cb2).Text = param2; 
            //    ((Control)cb2).TextChanged += AttrValueChanged;             
            //}                  
        }           
           
        private void AddDataSourceGrid()
        {
            
            grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                     | System.Windows.Forms.AnchorStyles.Left)
                                                                     | System.Windows.Forms.AnchorStyles.Right)));
            grid.AutoStretchColumnsToFitWidth = false;
            grid.AutoStretchRowsToFitHeight = false;
            //grid.Rows.
            grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            grid.CustomSort = false;
            //grid.Location = new System.Drawing.Point(12, 12);
           // grid.Name = "grid";
            //grid.Size = new System.Drawing.Size(516, 368);
            grid.SpecialKeys = SourceGrid.GridSpecialKeys.Default;
            grid.TabIndex = 0;
                        
            grid.Redim(10, 3);
            int currentRow = 0;
            SourceGrid.Cells.Views.Cell titleModel = new SourceGrid.Cells.Views.Cell();
            titleModel.BackColor = Color.SteelBlue;
            titleModel.ForeColor = Color.White;
            titleModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            SourceGrid.Cells.Views.Cell captionModel = new SourceGrid.Cells.Views.Cell();
            //captionModel.
            captionModel.BackColor = grid.BackColor;
                                    
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Control Cell1");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("");
            ProgressBar tb1 = new ProgressBar();
            tb1.Value = 50;
            grid.LinkedControls.Add(new SourceGrid.LinkedControlValue(tb1, new SourceGrid.Position(currentRow, 1))); 
            currentRow ++;                 
        
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Control Cell2");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("");                              
            var tb2 = new SysComboStatus();
            grid.LinkedControls.Add(new SourceGrid.LinkedControlValue(tb2, new SourceGrid.Position(currentRow, 1))); 
            currentRow ++;
            
            
            //grid[currentRow, 0] = new SourceGrid.Cells.Cell("Control Cell3");
            //grid[currentRow, 0].View = captionModel;
            //grid[currentRow, 1] = new SourceGrid.Cells.Cell("");                     
            //var tb3 = new TextBoxFBA();
            //grid.LinkedControls.Add(new SourceGrid.LinkedControlValue(tb3, new SourceGrid.Position(currentRow, 1))); 
            //currentRow ++;     
                                                                   
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Control Cell4");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("");                              
            var tb4 = new CheckBox();
            grid.LinkedControls.Add(new SourceGrid.LinkedControlValue(tb4, new SourceGrid.Position(currentRow, 1))); 
            currentRow ++; 
            
            
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Control Cell5");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("");                              
            var tb5 = new EditFBA();
            grid.LinkedControls.Add(new SourceGrid.LinkedControlValue(tb5, new SourceGrid.Position(currentRow, 1))); 
            currentRow ++;
           
            
            grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            //grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.Default;
            grid.Columns[0].Width = 100;
            grid.Columns[1].Width = 200;
            grid.Columns[2].Width = 300;
            grid.MinimumWidth  = 50;
            //grid.MinimumHeight = 50;
            //grid.AutoSizeCells();
            //grid.AutoStretchColumnsToFitWidth = true;
            //grid.Columns.StretchToFit();
            
       }
        
        private void button1_Click(object sender, EventArgs e)
        {              
           
           

            
            
            //AddAttrToForm();
            /*int AttrIndex = 0;
            UniEditFieldAdd(pnlField, "Lp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));", "dfgfdgdfgdfg fgdfgd dfg d", "TextBox", ref AttrIndex);
            UniEditFieldAdd(pnlField, "TextBox", "1234567890", "TextBox", ref AttrIndex);
            UniEditFieldAdd(pnlField, "Lp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));", "1234567890", "Memo", ref AttrIndex);
            UniEditFieldAdd(pnlField, "Memo", "1234567890", "Memo", ref AttrIndex);
            UniEditFieldAdd(pnlField, "DateTime", "22.02.2002 11:44:45", "DateTime", ref AttrIndex);
            UniEditFieldAdd(pnlField, "DateTime", "01.02.2007 12:11:09", "DateTime", ref AttrIndex);
            UniEditFieldAdd(pnlField, "TextBox", "56456rtyrtydf werw er67890", "TextBox", ref AttrIndex);
                
            UniEditFieldAdd(pnlField, "TextBox", "356434dfdsffsdf werw er67890", "TextBox", ref AttrIndex);
            
            UniEditFieldAdd(pnlLink, "TextBoxDB", "56456rtyrtydf werw er67890", "TextBoxDB", ref AttrIndex);
            UniEditFieldAdd(pnlLink, "TextBoxDB", "4535345ydf0", "TextBoxDB", ref AttrIndex);
            */
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            //AddDataSourceGrid();
            //sys.VewViewDT
            DTData.DataTableView("DTData", "DTData");
        }
        void dgvStateDate_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }
                            
                         
    }
    
    
    
    /// <summary>
    /// не сделано
    /// </summary>
    public class frmSample03 : System.Windows.Forms.Form
    {
        private SourceGrid.Grid grid;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
	    /// не сделано
	    /// </summary>
        public frmSample03()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new SourceGrid.Grid();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                      | System.Windows.Forms.AnchorStyles.Left)
                                                                     | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoStretchColumnsToFitWidth = false;
            this.grid.AutoStretchRowsToFitHeight = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.CustomSort = false;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(516, 368);
            this.grid.SpecialKeys = SourceGrid.GridSpecialKeys.Default;
            this.grid.TabIndex = 0;
            // 
            // frmSample3
            // 
            //this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            //this.ClientSize = new System.Drawing.Size(540, 391);
            this.Controls.Add(this.grid);
            //this.Name = "frmSample3";
            //this.Text = "Cell Editors, Specials Cells, Formatting and Image";
            //this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// При загрузке формы
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            grid.Redim(62, 3);

            SourceGrid.Cells.Views.Cell titleModel = new SourceGrid.Cells.Views.Cell();
            titleModel.BackColor = Color.SteelBlue;
            titleModel.ForeColor = Color.White;
            titleModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            SourceGrid.Cells.Views.Cell captionModel = new SourceGrid.Cells.Views.Cell();
            captionModel.BackColor = grid.BackColor;

            int currentRow = 0;

            #region Base Types
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Base Types");
            grid[currentRow, 0].View = titleModel;
            grid[currentRow, 0].ColumnSpan = 3;
            currentRow++;

            //string
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("String");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("String Value", typeof(string));

            currentRow++;

            //double
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Double");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(1.5, typeof(double));

            currentRow++;

            //int
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Int");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(5, typeof(int));

            currentRow++;

            //DateTime
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("DateTime");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(DateTime.Now, typeof(DateTime));

            currentRow++;

            //Boolean
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Boolean");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(true, typeof(Boolean));

            currentRow++;
            #endregion

            #region Complex Types
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Complex Types");
            grid[currentRow, 0].View = titleModel;
            grid[currentRow, 0].ColumnSpan = 3;
            currentRow++;

            //Font
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Font");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(this.Font, typeof(Font));

            currentRow++;

            //Cursor
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Cursor");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(Cursors.Arrow, typeof(Cursor));

            currentRow++;

            //Point
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Point");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(new Point(2, 3), typeof(Point));

            currentRow++;

            //Rectangle
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Rectangle");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(new Rectangle(100, 100, 200, 200), typeof(Rectangle));

            currentRow++;

            //Image
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Image");
            grid[currentRow, 0].View = captionModel;
            //grid[currentRow, 1] = new SourceGrid.Cells.Image(Properties.Resources.CalcioSmall);

            currentRow++;

            //Enum AnchorStyle
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("AnchorStyle");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(AnchorStyles.Bottom, typeof(AnchorStyles));

            currentRow++;

            //Enum
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Enum");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(System.Windows.Forms.BorderStyle.Fixed3D, typeof(System.Windows.Forms.BorderStyle));

            currentRow++;

            //String[]
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("String Array");
            grid[currentRow, 0].View = captionModel;
            string[] strArray = new string[] { "Value 1", "Value 2" };
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(strArray, typeof(string[]));

            currentRow++;

            //Double[]
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Double Array");
            grid[currentRow, 0].View = captionModel;
            double[] dblArray = new double[] { 1, 0.5, 0.1 };
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(dblArray, typeof(double[]));

            currentRow++;
            #endregion

            #region Special Editors
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Special Editors");
            grid[currentRow, 0].View = titleModel;
            grid[currentRow, 0].ColumnSpan = 3;
            currentRow++;

            //Time
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Time");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(DateTime.Now);
            grid[currentRow, 1].Editor = new SourceGrid.Cells.Editors.TimePicker();

            currentRow++;

            //Double Chars Validation
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Double Chars Validation");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.TextBoxNumeric numericEditor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(double));
            numericEditor.KeyPress += delegate(object sender, KeyPressEventArgs keyArgs)
            {
                bool isValid = char.IsNumber(keyArgs.KeyChar) ||
                    keyArgs.KeyChar == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

                keyArgs.Handled = !isValid;
            };
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(0.5);
            grid[currentRow, 1].Editor = numericEditor;

            currentRow++;

            //String Chars (ABC)
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Chars Validation(only ABC)");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.TextBox stringEditor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            stringEditor.KeyPress += delegate(object sender, KeyPressEventArgs keyArgs)
            {
                keyArgs.KeyChar = char.ToUpper(keyArgs.KeyChar);
                bool isValid = keyArgs.KeyChar == 'A' || keyArgs.KeyChar == 'B' || keyArgs.KeyChar == 'C';

                keyArgs.Handled = !isValid;
            };
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("AABB");
            grid[currentRow, 1].Editor = stringEditor;

            currentRow++;

            //String Validating
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("String validating(min 6 chars)");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.TextBox stringEditorValidating = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            stringEditorValidating.Control.Validating += delegate(object sender, System.ComponentModel.CancelEventArgs cancelEvent)
            {
                string val = ((TextBox)sender).Text;
                if (val == null || val.Length < 6)
                    cancelEvent.Cancel = true;
            };
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("test string");
            grid[currentRow, 1].Editor = stringEditorValidating;

            currentRow++;

            //Int 0-100 or null
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Int 0-100 or null");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.TextBoxNumeric numericEditor0_100 = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(int));
            numericEditor0_100.MinimumValue = 0;
            numericEditor0_100.MaximumValue = 100;
            numericEditor0_100.AllowNull = true;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(7);
            grid[currentRow, 1].Editor = numericEditor0_100;

            currentRow++;

            //Double Custom Conversion
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Dbl custom conversion");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.TextBox dblCustomConversion = new SourceGrid.Cells.Editors.TextBox(typeof(double));
            dblCustomConversion.ConvertingObjectToValue += delegate(object sender,
                                                                    DevAge.ComponentModel.ConvertingObjectEventArgs conv)
            {
                if (conv.Value is string)
                {
                    //Here you can add any custom code
                    double val;
                    if (double.TryParse((string)conv.Value, out val))
                    {
                        conv.Value = val;
                        conv.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                    }
                }
            };
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(73.839);
            grid[currentRow, 1].Editor = dblCustomConversion;

            currentRow++;

            //Enum Custom Display
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Enum Custom Display");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.ComboBox keysCombo = new SourceGrid.Cells.Editors.ComboBox(typeof(Keys));
            keysCombo.Control.FormattingEnabled = true;
            keysCombo.ConvertingValueToDisplayString += delegate(object sender, DevAge.ComponentModel.ConvertingObjectEventArgs convArgs)
            {
                if (convArgs.Value is Keys)
                    convArgs.Value = (int)((Keys)convArgs.Value) + " - " + convArgs.Value.ToString();
            };
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(Keys.Enter);
            grid[currentRow, 1].Editor = keysCombo;

            currentRow++;

            string[] arraySample = new string[] { "Value 1", "Value 2", "Value 3" };
            //ComboBox 1
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("ComboBox String");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.ComboBox comboStandard = new SourceGrid.Cells.Editors.ComboBox(typeof(string), arraySample, false);
            comboStandard.Control.MaxLength = 10;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(arraySample[0], comboStandard);

            currentRow++;

            //ComboBox exclusive
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("ComboBox String Exclusive");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.ComboBox comboExclusive = new SourceGrid.Cells.Editors.ComboBox(typeof(string), arraySample, true);
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(arraySample[0], comboExclusive);

            currentRow++;

            //ComboBox AutoComplete
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("ComboBox AutoComplete");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.ComboBox comboAutoComplete =
                new SourceGrid.Cells.Editors.ComboBox(typeof(string),
                                                      new string[] { "AAA", "ABC", "AZA", "BAA", "ZAA" },
                                                      true);
            comboAutoComplete.Control.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAutoComplete.Control.AutoCompleteMode = AutoCompleteMode.Append;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("AAA", comboAutoComplete);

            currentRow++;

            //ComboBox DropDownList
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("ComboBox DropDownList");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.ComboBox comboNoText = new SourceGrid.Cells.Editors.ComboBox(typeof(string), arraySample, true);
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(arraySample[0]);
            grid[currentRow, 1].Editor = comboNoText;
            comboNoText.Control.DropDownStyle = ComboBoxStyle.DropDownList;

            currentRow++;

            //ComboBox DateTime Editable
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("ComboBox DateTime");
            grid[currentRow, 0].View = captionModel;
            DateTime[] arrayDt = new DateTime[] { new DateTime(1981, 10, 6), new DateTime(1991, 10, 6), new DateTime(2001, 10, 6) };
            SourceGrid.Cells.Editors.ComboBox comboDateTime = new SourceGrid.Cells.Editors.ComboBox(typeof(DateTime), arrayDt, false);
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(arrayDt[0], comboDateTime);

            currentRow++;

            //ComboBox Custom Display (create a datamodel that has a custom display string)
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("ComboBox Custom Display");
            grid[currentRow, 0].View = captionModel;
            int[] arrInt = new int[] { 0, 1, 2, 3, 4 };
            string[] arrStr = new string[] { "0 - Zero", "1 - One", "2 - Two", "3 - Three", "4- Four" };
            SourceGrid.Cells.Editors.ComboBox editorComboCustomDisplay = new SourceGrid.Cells.Editors.ComboBox(typeof(int), arrInt, true);
            editorComboCustomDisplay.Control.FormattingEnabled = true;
            DevAge.ComponentModel.Validator.ValueMapping comboMapping = new DevAge.ComponentModel.Validator.ValueMapping();
            comboMapping.DisplayStringList = arrStr;
            comboMapping.ValueList = arrInt;
            comboMapping.SpecialList = arrStr;
            comboMapping.SpecialType = typeof(string);
            comboMapping.BindValidator(editorComboCustomDisplay);
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(0);
            grid[currentRow, 1].Editor = editorComboCustomDisplay;

            SourceGrid.Cells.Cell l_CellComboRealValue = new SourceGrid.Cells.Cell(grid[currentRow, 1].Value);
            l_CellComboRealValue.View = captionModel;
            SourceGrid.Cells.Controllers.BindProperty l_ComboBindProperty = new SourceGrid.Cells.Controllers.BindProperty(typeof(SourceGrid.Cells.Cell).GetProperty("Value"), l_CellComboRealValue);
            grid[currentRow, 1].AddController(l_ComboBindProperty);
            grid[currentRow, 2] = l_CellComboRealValue;

            currentRow++;

            //ComboBox with inline View
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("ComboBox Inline View");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.ComboBox cbInline = new SourceGrid.Cells.Editors.ComboBox(typeof(string), arraySample, false);
            cbInline.EditableMode = SourceGrid.EditableMode.Default | SourceGrid.EditableMode.Focus;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(arraySample[0], cbInline);
            grid[currentRow, 1].View = SourceGrid.Cells.Views.ComboBox.Default;

            currentRow++;

            //Numeric Up Down Editor
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("NumericUpDown");
            grid[currentRow, 0].View = captionModel;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell(0);
            SourceGrid.Cells.Editors.NumericUpDown l_NumericUpDownEditor = new SourceGrid.Cells.Editors.NumericUpDown(typeof(int), 50, -50, 1);
            grid[currentRow, 1].Editor = l_NumericUpDownEditor;

            currentRow++;

            //Multiline Textbox
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Multiline Textbox");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 0].ColumnSpan = 1;
            grid[currentRow, 0].RowSpan = 2;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell("Hello\r\nWorld");
            SourceGrid.Cells.Editors.TextBox l_MultilineEditor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            l_MultilineEditor.Control.Multiline = true;
            grid[currentRow, 1].Editor = l_MultilineEditor;
            grid[currentRow, 1].RowSpan = 2;

            currentRow++;
            currentRow++;

            //Boolean (CheckBox)
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Boolean (CheckBox)");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.CheckBox(null, true);
            grid[currentRow, 1].FindController<SourceGrid.Cells.Controllers.CheckBox>().CheckedChanged += InvertDisabledCheckBox(currentRow);
            

            SourceGrid.Cells.CheckBox l_DisabledCheckBox = new SourceGrid.Cells.CheckBox("Disabled Checkbox", true);
            l_DisabledCheckBox.Editor.EnableEdit = false;
            grid[currentRow, 2] = l_DisabledCheckBox;

            currentRow++;

            //DateTime with DateTimePicker Editor
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("DateTimePicker");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.DateTimePicker editorDtPicker = new SourceGrid.Cells.Editors.DateTimePicker();
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(DateTime.Today);
            grid[currentRow, 1].Editor = editorDtPicker;

            currentRow++;

            //DateTime with DateTimePicker nullable Editor
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("DateTimePicker nullable");
            grid[currentRow, 0].View = captionModel;
            SourceGrid.Cells.Editors.DateTimePicker editorDtPickerNull = new SourceGrid.Cells.Editors.DateTimePicker();
            editorDtPickerNull.AllowNull = true;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(null);
            grid[currentRow, 1].Editor = editorDtPickerNull;

            currentRow++;

            //File editor
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("File editor");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("c:\\windows\\System32\\user32.dll", new EditorFileDialog());

            currentRow++;
            
            // Richtext box
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("RichTextBox editor");
            grid[currentRow, 0].View = captionModel;
            string rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0" +
                    "Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Only a \\b " +
                    "Test\\b0.\\par\r\n}\r\n";
            var richTextBox = new SourceGrid.Cells.RichTextBox(new RichText(rtf));
            grid[currentRow, 1] = richTextBox;

            currentRow++;

            #endregion

            #region Special Cells
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Special Cells");
            grid[currentRow, 0].View = titleModel;
            grid[currentRow, 0].ColumnSpan = 3;
            currentRow++;

            //Cell Button
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Cell Button");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Button("CellButton");
            //grid[currentRow, 1].Image = Properties.Resources.FACE02.ToBitmap();
            SourceGrid.Cells.Controllers.Button buttonClickEvent = new SourceGrid.Cells.Controllers.Button();
            buttonClickEvent.Executed += new EventHandler(CellButton_Click);
            grid[currentRow, 1].Controller.AddController(buttonClickEvent);

            currentRow++;

            //Cell Link
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Cell Link");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Link("CellLink");
            SourceGrid.Cells.Controllers.Button linkClickEvent = new SourceGrid.Cells.Controllers.Button();
            linkClickEvent.Executed += new EventHandler(CellLink_Click);
            grid[currentRow, 1].Controller.AddController(linkClickEvent);

            currentRow++;

            //Custom draw cell
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Custom draw cell");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("CustomView");
            grid[currentRow, 1].View = new RoundView();

            currentRow++;

            //Control Cell
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Control Cell");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("control cell");
            ProgressBar progressBar = new ProgressBar();
            progressBar.Value = 50;
            grid.LinkedControls.Add(new SourceGrid.LinkedControlValue(progressBar, new SourceGrid.Position(currentRow, 1)));

            currentRow++;

            //Custom Border Cell
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Custom Border");
            grid[currentRow, 0].View = captionModel;

            SourceGrid.Cells.Views.Cell viewCustomBorder = new SourceGrid.Cells.Views.Cell();
            viewCustomBorder.Border = new DevAge.Drawing.RectangleBorder(new DevAge.Drawing.BorderLine(Color.Red, 1),
                                                                         new DevAge.Drawing.BorderLine(Color.Blue, 1),
                                                                         new DevAge.Drawing.BorderLine(Color.Violet, 1),
                                                                         new DevAge.Drawing.BorderLine(Color.Green, 1));
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("Custom Border");
            grid[currentRow, 1].View = viewCustomBorder;

            currentRow++;
            #endregion

            #region Custom Formatting
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Custom Formatting");
            grid[currentRow, 0].View = titleModel;
            grid[currentRow, 0].ColumnSpan = 3;
            currentRow++;

            //Format
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Default Format");
            grid[currentRow, 0].View = captionModel;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell(88.5246);
            SourceGrid.Cells.Editors.TextBox editorCustom = new SourceGrid.Cells.Editors.TextBox(typeof(double));
            editorCustom.TypeConverter = new DevAge.ComponentModel.Converter.CurrencyTypeConverter(typeof(double));
            DevAge.ComponentModel.Converter.NumberTypeConverter numberFormatCustom = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(double));
            editorCustom.TypeConverter = numberFormatCustom;
            grid[currentRow, 1].Editor = editorCustom;

            currentRow++;

            //Percent Editor
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Percent Format");
            grid[currentRow, 0].View = captionModel;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell(88.5246);
            SourceGrid.Cells.Editors.TextBox l_PercentEditor = new SourceGrid.Cells.Editors.TextBox(typeof(double));
            l_PercentEditor.TypeConverter = new DevAge.ComponentModel.Converter.PercentTypeConverter(typeof(double));
            grid[currentRow, 1].Editor = l_PercentEditor;

            currentRow++;

            //Currency Editor
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Currency Format");
            grid[currentRow, 0].View = captionModel;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell(88.5246M);
            SourceGrid.Cells.Editors.TextBox l_CurrencyEditor = new SourceGrid.Cells.Editors.TextBox(typeof(decimal));
            l_CurrencyEditor.TypeConverter = new DevAge.ComponentModel.Converter.CurrencyTypeConverter(typeof(decimal));
            grid[currentRow, 1].Editor = l_CurrencyEditor;

            currentRow++;

            //Format (#.00)
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Format #.00");
            grid[currentRow, 0].View = captionModel;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell(88.5246);
            editorCustom = new SourceGrid.Cells.Editors.TextBox(typeof(double));
            numberFormatCustom = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(double));
            numberFormatCustom.Format = "#.00";
            editorCustom.TypeConverter = numberFormatCustom;
            grid[currentRow, 1].Editor = editorCustom;

            currentRow++;

            //Format ("0000.0000")
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Format 0000.0000");
            grid[currentRow, 0].View = captionModel;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell(88.5246);
            editorCustom = new SourceGrid.Cells.Editors.TextBox(typeof(double));
            numberFormatCustom = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(double));
            numberFormatCustom.Format = "0000.0000";
            editorCustom.TypeConverter = numberFormatCustom;
            grid[currentRow, 1].Editor = editorCustom;

            currentRow++;

            //Format ("Scientific (exponential)")
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Format Scientific");
            grid[currentRow, 0].View = captionModel;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell(0.0006);
            SourceGrid.Cells.Editors.TextBoxNumeric editorExponential = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(double));
            DevAge.ComponentModel.Converter.NumberTypeConverter exponentialConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(double), "e");
            exponentialConverter.NumberStyles = System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowExponent;
            editorExponential.TypeConverter = exponentialConverter;
            grid[currentRow, 1].Editor = editorExponential;

            currentRow++;

            //DateTime 2 (using custom formatting)
            string dtFormat2 = "yyyy MM dd";
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Date(" + dtFormat2 + ")");
            grid[currentRow, 0].View = captionModel;

            string[] dtParseFormats = new string[] { dtFormat2 };
            System.Globalization.DateTimeStyles dtStyles = System.Globalization.DateTimeStyles.AllowInnerWhite | System.Globalization.DateTimeStyles.AllowLeadingWhite | System.Globalization.DateTimeStyles.AllowTrailingWhite | System.Globalization.DateTimeStyles.AllowWhiteSpaces;
            System.ComponentModel.TypeConverter dtConverter = new DevAge.ComponentModel.Converter.DateTimeTypeConverter(dtFormat2, dtParseFormats, dtStyles);
            SourceGrid.Cells.Editors.TextBoxUITypeEditor editorDt2 = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(DateTime));
            editorDt2.TypeConverter = dtConverter;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell(DateTime.Today);
            grid[currentRow, 1].Editor = editorDt2;

            currentRow++;


            //Text Ellipses
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Text Ellipses");
            grid[currentRow, 0].View = captionModel;

            grid[currentRow, 1] = new SourceGrid.Cells.Cell("This text is very very long and shows how to trim and add ellipses", typeof(string));
            SourceGrid.Cells.Views.Cell ellipsesView = new SourceGrid.Cells.Views.Cell();
            ellipsesView.TrimmingMode = SourceGrid.TrimmingMode.Word;
            grid[currentRow, 1].View = ellipsesView;

            currentRow++;

            #endregion

            #region Image And Text Properties
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Image And Text Properties");
            grid[currentRow, 0].View = titleModel;
            grid[currentRow, 0].ColumnSpan = 3;
            currentRow++;

            //Cell Image
            SourceGrid.Cells.Cell cellImage1 = new SourceGrid.Cells.Cell("Single Image");
            SourceGrid.Cells.Views.Cell viewImage = new SourceGrid.Cells.Views.Cell(captionModel);
            cellImage1.View = viewImage;
            grid[currentRow, 2] = cellImage1;
            cellImage1.RowSpan = 4;
            //cellImage1.Image = Properties.Resources.FACE02.ToBitmap();

            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Image Alignment");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(viewImage.ImageAlignment, typeof(DevAge.Drawing.ContentAlignment));
            grid[currentRow, 1].AddController(new SourceGrid.Cells.Controllers.BindProperty(typeof(SourceGrid.Cells.Views.Cell).GetProperty("ImageAlignment"), viewImage));

            currentRow++;

            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Stretch Image");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(viewImage.ImageStretch, typeof(bool));
            grid[currentRow, 1].AddController(new SourceGrid.Cells.Controllers.BindProperty(typeof(SourceGrid.Cells.Views.Cell).GetProperty("ImageStretch"), viewImage));

            currentRow++;

            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Text Alignment");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(viewImage.TextAlignment, typeof(DevAge.Drawing.ContentAlignment));
            grid[currentRow, 1].AddController(new SourceGrid.Cells.Controllers.BindProperty(typeof(SourceGrid.Cells.Views.Cell).GetProperty("TextAlignment"), viewImage));

            currentRow++;

            grid[currentRow, 0] = new SourceGrid.Cells.Cell("DrawMode");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell(viewImage.ElementsDrawMode, typeof(DevAge.Drawing.ElementsDrawMode));
            grid[currentRow, 1].AddController(new SourceGrid.Cells.Controllers.BindProperty(typeof(SourceGrid.Cells.Views.Cell).GetProperty("ElementsDrawMode"), viewImage));

            currentRow++;


            // Cell VisualModelMultiImages
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("Multi Images");
            SourceGrid.Cells.Views.MultiImages modelMultiImages = new SourceGrid.Cells.Views.MultiImages();
            //modelMultiImages.SubImages.Add(new DevAge.Drawing.VisualElements.Image(Properties.Resources.FACE00.ToBitmap()));
            //modelMultiImages.SubImages.Add(new DevAge.Drawing.VisualElements.Image(Properties.Resources.FACE01.ToBitmap()));
            //modelMultiImages.SubImages.Add(new DevAge.Drawing.VisualElements.Image(Properties.Resources.FACE02.ToBitmap()));
            //modelMultiImages.SubImages.Add(new DevAge.Drawing.VisualElements.Image(Properties.Resources.FACE04.ToBitmap()));
            //modelMultiImages.SubImages[0].AnchorArea = new DevAge.Drawing.AnchorArea(DevAge.Drawing.ContentAlignment.TopLeft, false);
            //modelMultiImages.SubImages[1].AnchorArea = new DevAge.Drawing.AnchorArea(DevAge.Drawing.ContentAlignment.TopRight, false);
            //modelMultiImages.SubImages[2].AnchorArea = new DevAge.Drawing.AnchorArea(DevAge.Drawing.ContentAlignment.BottomLeft, false);
            //modelMultiImages.SubImages[3].AnchorArea = new DevAge.Drawing.AnchorArea(DevAge.Drawing.ContentAlignment.BottomRight, false);
            modelMultiImages.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            grid[currentRow, 1].View = captionModel; //modelMultiImages;
            grid.Rows[currentRow].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize;
            grid.Rows[currentRow].Height = 50;

            currentRow++;


            // Cell Rotated Text
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("Rotated by angle");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("Rotated Text", typeof(string));
            SourceGrid.Cells.Views.Cell rotateView = new SourceGrid.Cells.Views.Cell();
            rotateView.ElementText = new RotatedText(45);
            grid[currentRow, 1].View = rotateView;
            grid.Rows[currentRow].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize;
            grid.Rows[currentRow].Height = 50;

            currentRow++;

            // GDI+ Text
            grid[currentRow, 0] = new SourceGrid.Cells.Cell("GDI+ Text");
            grid[currentRow, 0].View = captionModel;
            grid[currentRow, 1] = new SourceGrid.Cells.Cell("Hello from GDI+", typeof(string));
            GDITextView gdiTextView = new GDITextView();
            gdiTextView.FormatFlags = StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap;
            grid[currentRow, 1].View = gdiTextView;

            currentRow++;
            #endregion


            grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            grid.MinimumWidth = 50;
            grid.AutoSizeCells();
            grid.AutoStretchColumnsToFitWidth = true;
            grid.Columns.StretchToFit();
        }

        private EventHandler InvertDisabledCheckBox(int row)
        {
            return delegate
            {
                grid[row, 2].Value = !(((bool)grid[row, 2].Value)) ;
            };
        }
        
        private void CellButton_Click(object sender, EventArgs e)
        {
            SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
            SourceGrid.Cells.Button btnCell = (SourceGrid.Cells.Button)context.Cell;
            btnCell.Value = DateTime.Now.TimeOfDay.ToString();
        }

        private void CellLink_Click(object sender, EventArgs e)
        {
            SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
            SourceGrid.Cells.Link btnCell = (SourceGrid.Cells.Link)context.Cell;
            btnCell.Value = DateTime.Now.TimeOfDay.ToString();
        }


        /// <summary>
        /// Customized View to draw a rounded background
        /// </summary>
        private class RoundView : SourceGrid.Cells.Views.Cell
        {
            public RoundView()
            {
                TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                base.Background = mBackground;
                Border = DevAge.Drawing.RectangleBorder.NoBorder;
            }

            public double Round
            {
                get { return mBackground.Round; }
                set { mBackground.Round = value; }
            }

            private BackVisualElement mBackground = new BackVisualElement();
            
            private class BackVisualElement : DevAge.Drawing.VisualElements.VisualElementBase
            {
                #region Constuctor
                /// <summary>
                /// Default constructor
                /// </summary>
                public BackVisualElement()
                {
                }

                /// <summary>
                /// Copy constructor
                /// </summary>
                /// <param name="other"></param>
                public BackVisualElement(BackVisualElement other)
                    : base(other)
                {
                    Round = other.Round;
                }
                #endregion
                /// <summary>
                /// Clone
                /// </summary>
                /// <returns></returns>
                public override object Clone()
                {
                    return new BackVisualElement(this);
                }

                private double mRound = 0.5;
                public double Round
                {
                    get { return mRound; }
                    set { mRound = value; }
                }

                protected override void OnDraw(DevAge.Drawing.GraphicsCache graphics, RectangleF area)
                {
                    DevAge.Drawing.RoundedRectangle rounded = new DevAge.Drawing.RoundedRectangle(Rectangle.Round(area), Round);
                    using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(area, Color.RoyalBlue, Color.WhiteSmoke, System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                    {
                        graphics.Graphics.FillRegion(brush, new Region(rounded.ToGraphicsPath()));
                    }


                    //Border
                    DevAge.Drawing.Utilities.DrawRoundedRectangle(graphics.Graphics, rounded, Pens.RoyalBlue);

                }

                protected override SizeF OnMeasureContent(DevAge.Drawing.MeasureHelper measure, SizeF maxSize)
                {
                    return SizeF.Empty;
                }
            }
        }

        private class RotatedText : DevAge.Drawing.VisualElements.TextGDI
        {
            public RotatedText(float angle)
            {
                Angle = angle;
            }

            public float Angle = 0;

            protected override void OnDraw(DevAge.Drawing.GraphicsCache graphics, RectangleF area)
            {
                System.Drawing.Drawing2D.GraphicsState state = graphics.Graphics.Save();
                try
                {
                    float width2 = area.Width / 2;
                    float height2 = area.Height / 2;

                    //For a better drawing use the clear type rendering
                    graphics.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    //Move the origin to the center of the cell (for a more easy rotation)
                    graphics.Graphics.TranslateTransform(area.X + width2, area.Y + height2);

                    graphics.Graphics.RotateTransform(Angle);

                    StringFormat.Alignment = StringAlignment.Center;
                    StringFormat.LineAlignment = StringAlignment.Center;
                    graphics.Graphics.DrawString(Value, Font, graphics.BrushsCache.GetBrush(ForeColor), 0, 0, StringFormat);
                }
                finally
                {
                    graphics.Graphics.Restore(state);
                }
            }

            //TODO Implement Clone and MeasureContent
            //Here I should also implement MeasureContent (think also for a solution to allow rotated text with any kind of allignment)
        }

        /// <summary>
        /// Customized View to directly use GDI+ StringFormat features.
        /// </summary>
        private class GDITextView : SourceGrid.Cells.Views.Cell
        {
            public GDITextView()
            {
                ElementText = new DevAge.Drawing.VisualElements.TextGDI();
            }

            private System.Drawing.StringFormatFlags mFormatFlags = StringFormatFlags.NoWrap;
            public System.Drawing.StringFormatFlags FormatFlags
            {
                get { return mFormatFlags; }
                set { mFormatFlags = value; }
            }

            protected override void PrepareVisualElementText(SourceGrid.CellContext context)
            {
                base.PrepareVisualElementText(context);

                ((DevAge.Drawing.VisualElements.TextGDI)ElementText).StringFormat.FormatFlags = FormatFlags;
            }

            protected override SizeF OnMeasureContent(DevAge.Drawing.MeasureHelper measure, SizeF maxSize)
            {
                //TODO Here I must add some fixed pixels because seems that there are some little
                // difference from the measured content and the actual drawing surface (probably this is a little bug ... I must check)
                SizeF result = base.OnMeasureContent(measure, maxSize);
                return new SizeF(result.Width + 1, result.Height + 1);
            }
        }

        private class EditorFileDialog : SourceGrid.Cells.Editors.TextBoxButton
        {
            public EditorFileDialog()
                : base(typeof(string))
            {
                Control.DialogOpen += new EventHandler(Control_DialogOpen);
            }

            void Control_DialogOpen(object sender, EventArgs e)
            {
                using (OpenFileDialog dg = new OpenFileDialog())
                {
                    dg.FileName = (string)Control.Value;

                    if (dg.ShowDialog(EditCellContext.Grid) == DialogResult.OK)
                    {
                        Control.Value = dg.FileName;
                    }
                }
            }
        }
    }                 
}

 
