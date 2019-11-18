//EventHandler handler = this.DropDown;
//if (handler != null)
//{
//    handler(this, e);
//}
//           this.DropDown?.Invoke(this, e);   

//================
//Класс предок ComboBoxEx.
/*public class ComboBoxFBA : System.Windows.Forms.ComboBox
{
    public string[] ValueArray;

    //Конструктор.
    public ComboBoxFBA() : base()
    {
        this.MouseDoubleClick += FilterInputText;
        this.KeyPress += ComboBoxKeyPress;
        if (!_ContextMenuEnabled)
        {
            ContextMenu = new ContextMenu();
            ContextMenuStrip = new ContextMenuStrip();
        }
    }

    //Добаялем свойство ReadOnly.
    public void ComboBoxKeyPress(object sender, KeyPressEventArgs e)
    {
        if (this.ReadOnly) e.KeyChar = (char)Keys.None;
        char number = e.KeyChar;
        if (number == (char)Keys.Back) return;

        if (this.IntegerOnly)
        {
            if (!Char.IsDigit(number)) e.Handled = true;
            return;
        }

        if (this.FloatOnly)
        {
            if (number == '.') return;
            if (!Char.IsDigit(number)) e.Handled = true;
        }
    }

    //Перехват вставки текста из буфера обмена.
    protected override void WndProc(ref Message m)
    {
        if (m.Msg != 0x302)  
        {
            base.WndProc(ref m);
            return;
        }
        if (!Clipboard.ContainsText()) 
        {
            base.WndProc(ref m);
            return;
        }






        const int WM_PASTE = 0x0302;
        if (m.Msg == WM_PASTE)
        {
            if ((!this.IntegerOnly) && (!this.FloatOnly))
            {
                base.WndProc(ref m);
                return;
            }
            string ClipboardText = Clipboard.GetText();
            int Len = ClipboardText.Length;
            if (Len > 20)
            {
                //base.WndProc(ref m);
                return;
            }
            if (this.IntegerOnly)
            {
                int NumberInt = 0;
                if (!sys.IsInteger(ClipboardText, out NumberInt)) return;
            }
            if (this.FloatOnly)
            {
                if (!sys.IsFloat(ClipboardText)) return;
            }
        }
        base.WndProc(ref m);
    }

    //Ввод списка значений при двойном клике на TextBox полоски фильтра.
    public void FilterInputText(object sender, MouseEventArgs e)
    {
        sys.InputListValues(sender);
    }

    //Если поставить False стандартное контекстное меню перестанет появляться. 
    bool _ContextMenuEnabled = true;
    [DisplayName("ContextMenuEnabled"), Description("If False, the standard context menu will no longer appear."), Category("FBA")]
    public bool ContextMenuEnabled
    {
        get { return _ContextMenuEnabled; }
        set { _ContextMenuEnabled = value; this.Refresh(); }
    }

    //Дополнительное поле с текстом. Для разных целей.
    [DisplayName("Text2"), Description("Text2"), Category("FBA")]
    public string Text2 { get; set; }

    [DisplayName("ValueHistoryInItems"), Description("Show history of previous values of items"), Category("FBA")]
    public bool ValueHistoryInItems { get; set; }

    [DisplayName("FloatOnly"), Description("Type only Digit and ."), Category("FBA")]
    public bool FloatOnly { get; set; }

    [DisplayName("IntegerOnly"), Description("Type only Digit. Point prohibited."), Category("FBA")]
    public bool IntegerOnly { get; set; }

    [DisplayName("SaveValueHistory"), Description("Save history of values in local DataBase"), Category("FBA")]
    public bool SaveValueHistory { get; set; }

    //Признак что значение компонента можно сохранять/загружать в настройках,
    //при выполнении команды SaveSettings/LoadSettings.                 
    [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
    public bool SaveParam { get; set; }

    //Атрибут для выбора через ObjectRef.         
    [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
    public string ObjectRef { get; set; }

    //Атрибут для выбора через ObjectRef.     
    [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
    public string AttrBrief { get; set; }

    //Указываем что сохранять свойство Text или SelectedIndex.          
    [DisplayName("AttrType"), Description("Type of Attribute. Only INDEX OR TEXT."), Category("FBA")]
    public string AttrType { get; set; }

    //Имена компонентов со свойством на форме родителе, 
    //которое влияет на свойство Enabled/Disabled данного компонента.         
    [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                 "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
    public string GroupEnabled { get; set; }

    //Атрибут для выбора через ObjectRef.      
    [DisplayName("AttrBriefLookup"), Description(""), Category("FBA")]
    public string AttrBriefLookup { get; set; }
    //ComboBox имеет свойство .      
    [DisplayName("ReadOnly"), Description(""), Category("FBA")]
    public bool ReadOnly { get; set; }
    //Требуем заполнение компонента значениями.     
    [DisplayName("ERRORIFNULL"), Description(""), Category("FBA")]
    public string ERRORIFNULL { get; set; }

    [DisplayName("Obj"), Description("ObjectRef"), Category("FBA")]
    public ObjectRef Obj { get; set; }
}

//=================================
//EditFBA2.ButtonEditVisible = checkBox2.Checked;
//EditFBA2.ButtonDeleteVisible = checkBox1.Checked;
//=================================
//Добавление таблицы в список таблиц.
private void AddTable(string EntPos,
                      string RefPos,
                      string QueryName,
                      string EntityBrief,
                      string EntityID,
                      string TableName,
                      string TableType,
                      string IDFieldName,
                      string Action,
                      string ObjectID,
                      string StateDate
                      )
{                
    if ((TableName == "") || (IDFieldName == "")) return;
    bool NeedAddTable = true;
    for (int i = 0; i < TblCount; i++)
        if ((Tbl[i, tTableName] == TableName) && (Tbl[i, tEnt] == EntPos)) NeedAddTable = false;

    if (!NeedAddTable) return;         
    Tbl[TblCount, tPos]         = TblCount.ToString();
    Tbl[TblCount, tEnt]         = EntPos;
    Tbl[TblCount, tRef]         = RefPos;
    Tbl[TblCount, tQueryName]   = QueryName;   
    Tbl[TblCount, tEntityBrief] = EntityBrief;
    Tbl[TblCount, tEntityID]    = EntityID;
    Tbl[TblCount, tTableName]   = TableName;
    Tbl[TblCount, tTableType]   = TableType;
    Tbl[TblCount, tIDFieldName] = IDFieldName;
    Tbl[TblCount, tAction]      = Action; 
    Tbl[TblCount, tObjectID]    = ObjectID;
    Tbl[TblCount, tStateDate]   = StateDate;
    Tbl[TblCount, tUpdate]      = "";
    Tbl[TblCount, tInsert]      = "";
    Tbl[TblCount, tDelete]      = "";
    TblCount++;                          
}
//=================================

//select distinct EnBrief1_TableName from fbaAttrParent where EnBrief2 = 'ДогСтрах'
//Сначала заносим в Tbl все таблицы, родительские и основную таблицу сущности, но кроме историчных.                   
for (int i = 0; i < EntCount; i++)
{                 
    if (Ent[i, nTypeAction] != "Entity") continue;
    string EntPos      = Ent[i, nPos];
    string EntityBrief = Ent[i, nEntityBrief];
    string QueryName   = Ent[i, nQueryName];

    for (int j = 0; j < ParserData.ArAttrParentY; j++)
    {                       
        if (ParserData.ArAttrParent[j, ParserData.aEnBrief2] != EntityBrief) continue;                                       
        string TableName = ParserData.ArAttrParent[j, ParserData.aTable_Name];

        //Если таблица уже есть в списке, то не добавляем.
        string TableNameCheck      = ";" + TableName + ";";
        if (TableAll.IndexOf(TableNameCheck, StringComparison.OrdinalIgnoreCase) > -1 )continue;   

        string TableType = ParserData.ArAttrParent[j, ParserData.aTable_Type];
        if (TableType == "Hist") continue;
        if (TableType == "2") continue;

        string AttrKind  = ParserData.ArAttrParent[j, ParserData.aAttr_Kind];
        if (AttrKind == "Calc")  continue;
        if (AttrKind == "3") continue;

        string AttrType  = ParserData.ArAttrParent[j, ParserData.aAttr_Type];                                         
        if (AttrType == "Array")  continue;
        if (AttrType == "4") continue;

        string EntityID        = ParserData.ArAttrParent[j, ParserData.aEnID];                              
        string IDFieldName     = ParserData.ArAttrParent[j, ParserData.aEnBrief1_TableIDFieldName];                            

        AddTable(EntPos,       //tEnt
                 "0",          //tRef
                 QueryName,
                 EntityBrief,  //tEntityBrief
                 EntityID,     //nEntityID
                 TableName,    //nTableName
                 "1",          //nTableType  //Родительские таблицы всегда с типом 1.                         
                 IDFieldName,  //nIDFieldName 
                 "Parent",
                 Ent[i, nObjectID],
                 Ent[i, nStateDate]
                 );                    
    }
}

//Затем добавляем в список все таблицы обновляемых атрибутов. Если таблица уже есть, то она не добавится второй раз.
//Важен порядок таблиц. Сначала таблицу самого верхнего родителя, затем более низкого уровня и т.д.
TblCount = 0;
for (int i = 0; i < RefCount; i++)
    AddTable(Ref[i, iEnt],
             Ref[i, iPos],
             Ref[i, iQueryName],
             Ref[i, iEntityBrief],
             Ref[i, iEntityID],
             Ref[i, iTableName],
             Ref[i, iTableType],                          
             Ref[i, iIDFieldName],
             "Attr",
             Ref[i, iObjectID],
             Ref[i, iStateDate]
             );
//=================================
//Заполнение свойств компонентов в массиве Ref значениями из DataTable.
private void SetControlsValue()
{
            //Цикл по таблицам локального запроса.
            for (int i = 0; i < DSLocal.Tables.Count; i++)
            {    
                //Цикл по массиву компонентов.
                for (int j = 0; j < RefCount; j++)
                {
                    if (Ref[j, iPosLocal] != i.ToString()) continue;
                    if (Ref[j, iEnt].IsEmpty()) continue;
                    if (Ref[j, iQueryName].IsEmpty()) continue;
                    if (Ref[j, iAttr].IsEmpty()) continue;

                    if (!Ref[j, iAttrLookup].IsEmpty()) Ref[j, iValueOld] = sys.DTValue(DSLocal.Tables[i], Ref[j, iAttrLookup]);
                    else if (!Ref[j, iAttr].IsEmpty()) Ref[j, iValueOld] = sys.DTValue(DSLocal.Tables[i], Ref[j, iAttr]);                    
                    Ref[j, iValueNew] = Ref[j, iValueOld];
                }
            }

            //Цикл по таблицам удаленного запроса.
            for (int i = 0; i < DSRemote.Tables.Count; i++)
            {    
                //Цикл по массиву компонентов.
                for (int j = 0; j < RefCount; j++)
                {
                    if (Ref[j, iPosRemote] != i.ToString()) continue;
                    if (Ref[j, iEnt].IsEmpty()) continue;
                    if (Ref[j, iQueryName].IsEmpty()) continue;
                    if (Ref[j, iAttr].IsEmpty()) continue;

                    if (!Ref[j, iAttrLookup].IsEmpty()) Ref[j, iValueOld] = sys.DTValue(DSRemote.Tables[i], Ref[j, iAttrLookup]);
                    else if (!Ref[j, iAttr].IsEmpty()) Ref[j, iValueOld] = sys.DTValue(DSRemote.Tables[i], Ref[j, iAttr]);
                    Ref[j, iValueNew] = Ref[j, iValueOld];
                }
            }
//=================================

//if (!Ref[j, iAttrLookup].IsEmpty()) Ref[j, iValueOld] = sys.DTValue(DSRemote.Tables[i], Ref[j, iAttrLookup]);
//else if (!Ref[j, iAttr].IsEmpty()) Ref[j, iValueOld] = sys.DTValue(DSRemote.Tables[i], Ref[j, iAttr]);
//Ref[j, iValueNew] = Ref[j, iValueOld];
//=================================
//Получение свойства ObjectID для определенного Attr.
public bool Get_ObjectID_AND_EntityBrief(string TagStr, out string EntityBrief, out string ObjectID)
{
    EntityBrief = "";
    ObjectID = "";
    string QueryName;
    string Attr;
    string AttrLookup;
    string Setting;
    sys.ParseTag(TagStr, out QueryName, out Attr, out AttrLookup, out Setting);                        
    for (int i = 0; i < EntCount; i++)
    {                
        if (Ent[i, nQueryName] == QueryName)
        {
            EntityBrief = Ent[i, nEntityBrief];
            ObjectID    = Ent[i, nObjectID];
            return true;
        }               
    }
    sys.SM("Запрос не найден: " + QueryName);
    return false;
}
//=================================
//private void splitContainerFilter_SplitterMoved(object sender, SplitterEventArgs e)
//{           
//tabControlFilter.Dock = DockStyle.None
//SplitContainer1.SplitterDistance = 30
//tabControlFilter.Dock = DockStyle.Fill;
//}

//private void splitContainerFilter_SplitterMoving(object sender, SplitterCancelEventArgs e)
//{
//tabControlFilter.Dock = DockStyle.None;
//SplitContainer1.SplitterDistance = 30
//tabControlFilter.Dock = DockStyle.Fill
//}

//private void button1_Click(object sender, EventArgs e)
//{
//tbStatic.Paint += OnPaint1;
//}
private void OnPaint1(PaintEventArgs e)
{
     base.OnPaint(e);

    // if (!StarShow) return;                
     TextFormatFlags flags = TextFormatFlags.NoPadding;             
     Size proposedSize = new Size(int.MaxValue, int.MaxValue);
     Size size = TextRenderer.MeasureText(
         e.Graphics,
         this.Text,
         this.Font, proposedSize, flags);
     int WidthText = size.Width;
     string StarText = "ff";
     Color StarColor = Color.Red;
     var StarFont = Var.font1;
     int StarOffsetX = 0;
     int StarOffsetY = 0;
     e.Graphics.DrawString(StarText,                   
          StarFont,            
          new SolidBrush(StarColor),   
          //Прямоугольник, куда вписываем строку                      
          new Rectangle(WidthText + StarOffsetX, StarOffsetY, this.Width - (WidthText + StarOffsetX), this.Height));

}

//void tabControlFilter_DrawItem(object sender, DrawItemEventArgs e)
//{
Graphics g = e.Graphics;
TabPage tp = tabControlFilter.TabPages[e.Index];

StringFormat sf = new StringFormat();
sf.Alignment = StringAlignment.Center;  //optional

//This is the rectangle to draw "over" the tabpage title
RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2,e.Bounds.Width, e.Bounds.Height - 2);

//This is the default colour to use for the non-selected tabs
SolidBrush sb = new SolidBrush(Color.AntiqueWhite);

//This changes the colour if we're trying to draw the selected tabpage
if (tabControlFilter.SelectedIndex == e.Index)
    sb.Color = Color.Aqua;

//Colour the header of the current tabpage based on what we did above
g.FillRectangle(sb, e.Bounds);

//Remember to redraw the text - I'm always using black for title text
g.DrawString(tp.Text, tabControlFilter.Font, new SolidBrush(Color.Black), headerRect, sf);

//}

//private void FormFilter_Resize(object sender, EventArgs e)
//{
//this.Update();
//}
//=================================

private void buttonFBA1_Click(object sender, EventArgs e)
{

    //[DisplayName("MaxDropDownItems"), Description("MaxDropDownItems"), Category("FBA")]
    //public int MaxDropDownItems
    //{
    //    get { return comboBox1.MaxDropDownItems; }
    //    set { comboBox1.MaxDropDownItems = value; }



    PropertyInfo[] myPropertyInfo;
    Type myType = typeof(System.Windows.Forms.ComboBox);
    // Get the type and fields of FieldInfoClass.
    myPropertyInfo = myType.GetProperties();
    //Console.WriteLine("\nThe property of " + "FieldInfoClass are \n");
    //string[] s = new string[myPropertyInfo.Length];

    for (int i = 0; i < myPropertyInfo.Length; i++)
    {
        //s[i] = myPropertyInfo[i].Name;
        string propname = myPropertyInfo[i].Name;
        string proptype = myPropertyInfo[i].PropertyType.ToString();
        string res = "[DisplayName(\"" + propname + "\"), Description(\"" + propname + "\"), Category(\"FBA\")]" + Var.CR +
                     "public " + proptype + " " + propname + Var.CR +
                     "{" + Var.CR +
                     "    get { return comboBox1." + propname + "; }" + Var.CR +
                     "    set { comboBox1." + propname + " = value; }" + Var.CR +
                     "}" + Var.CR + Var.CR;
        textBoxFBA4.AppendText(res);
        //Console.WriteLine(myPropertyInfo[i].Name);
        //textBoxFBA4


    }
    //string s2 = string.Join(",", s);
    //sys.SM(s2);

}
//=================================

        
            //Показ массива Tbl.
            //if (ArrayName == "Tbl")
            //{ 
            //    sys.ArrayView(ArrayName,
            //        "0.tPos;1.tEnt;2.tRef;3.tQueryName;4.tEntityBrief;5.tEntityID;6.tTableName;" + 
            //        "7.tTableType;8.tIDFieldName;9.tTableParent;10.tObjectID;11.tStateDate;12.tUpdate;13.tInsert;14.tDelete", Tbl);                              
            //} 
//=================================
  /*void button1_Click(object sender, EventArgs e)
        {
            //new FormUniEdit("Edit", "ДогСтрах", "2776312").Show();
            //var F1 = new frmSample03();
            //F1.Show();
            
            //string SQL = "SELECT 'aaa' AS ID, 1 AS DD UNION ALL SELECT 'bbb' AS ID, NULL AS DD";  
            //string SQL = "SELECT NULL AS ID";
            //string SQL = "SELECT Pos, ID, EntityID, Attr_EntityID, Attr_EntityBrief, Attr_Name, Attr_Brief, Attr_Type, Attr_Kind FROM fbaAttrParent";  
            //string SQL = "SELECT Pos FROM fbaAttrParent";  
          
            //string SQL = "SELECT  [Attr_Code]  FROM [dbo].[fbaAttrParent]    WHERE Pos = 3143";
            
             string SQL =
              "SELECT   Pos                  " +       //TOP 230
              "       ,[ID]                  " +
              "       ,[EntityID]            " +
              "       ,[Attr_EntityID]       " +
              "       ,[Attr_EntityBrief]    " +
              "       ,[Attr_Name]           " +
              "       ,[Attr_Brief]          " +
              "       ,[Attr_Type]           " +
              "       ,[Attr_Kind]           " +
              "       ,[Attr_Mask]           " +
              "       ,[Attr_Feature]        " +
              "       ,[Attr_NameOrder]      " +
              "       ,[Attr_Code]           " +
              "       ,[Attr_Comment]        " +
              "       ,[Table_ID]            " +
              "       ,[Table_Name]          " +
              "       ,[Table_Field]         " +
              "       ,[Table_Field2]        " +
              "       ,[Table_IDFieldName]   " +
              "       ,[Table_Type]          " +
              "       ,[Table_Feature]       " +
              "       ,[Ref_EntityID]        " +
              "       ,[Ref_AttrID]          " +
              "       ,[Ref_EntityBrief]     " +
              "       ,[Ref_AttrBrief]       " +
              "       ,[Ref_AttrName]        " +
              "       ,[ParentID]            " +
              "       ,[EnID]                " +
              "       ,[EnBrief1]            " +
              "       ,[EnBriefName1]        " +
              "       ,[EnBrief1_TableName]  " +
              "       ,[EnBrief1_TableIDFieldName]  " +
              "       ,[EnChildID]                  " +
              "       ,[EnBrief2]                   " +
              "       ,[EnBriefName2]               " +
              "       ,[EnBrief2_TableName]         " +
              "       ,[EnBrief2_TableIDFieldName]  " +
              "       ,[EnLevelNum]                 " +
              "       ,[EnLevelPart]                " +
              "       ,[EnLevelParent]              " +
              "       ,[EnLevelTop]                 " +
              "       ,[DATA_TYPE]                  " +
              "       ,[CHARACTER_MAXIMUM_LENGTH]   " +
              "       ,[NUMERIC_PRECISION]          " +
              "       ,[NUMERIC_PRECISION_RADIX]    " +
              "       ,[IS_NULLABLE]                " +
              "       ,[TABLE_SCHEMA]               " +
              "FROM [dbo].[fbaAttrParent]           ";
                              
            
            
            
            System.Data.DataTable DT;
            sys.SelectDT(DirectionQuery.Remote, SQL, out DT);
             // dataGridView1.DataSource = DT;
              //return;
            
            
            string Block5 = "";
            sys.DTToStr(DT, ref Block5);
            //sys.SM(Block5);
            
            int Offset = 0;                
            DT = sys.DTFromStr(ref Offset, ref Block5);   
                
                
            //dataGridView1.DataSource = DT;
            //public static bool DTToFile(this System.Data.DataTable DT, string TableName, string FileName, bool ErrorShow)
            
            //public static bool DTFromFile(out System.Data.DataTable DT, out string TableName, string FileName, bool ErrorShow)
            
        }*/
//=================================
//public static void Test1(string Direction, SourceGrid.Grid grid, FilterObj filter) //)
//{
/*string SQL = "";
int[] ColumnWidth = null;
if (filter != null)
{
     SQL         = filter.FullQuerySQL;
     ColumnWidth = filter.ColumnWidth;
}

System.Data.DataTable DT;
if (!SelectDT(Direction, SQL, out DT)) return;

DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkKhaki, 1);
DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

//Views
//Color.FromArgb(238, 238, 238), Color.White
//CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.FromArgb(186, 227, 243), Color.White);
CellBackColorAlternate viewNormal = new CellBackColorAlternate(ColorTableOdd1, ColorTableOdd2);

viewNormal.Border = cellBorder;
CheckBoxBackColorAlternate viewCheckBox = new CheckBoxBackColorAlternate(Color.Khaki, Color.DarkKhaki);
viewCheckBox.Border = cellBorder;

//ColumnHeader view
SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
backHeader.BackColor = Color.FromArgb(59, 87, 143);
backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
viewColumnHeader.Background = backHeader;
viewColumnHeader.ForeColor = Color.FromArgb(83, 135, 225);
viewColumnHeader.Font = new Font("Comic Sans MS", 10, FontStyle.Underline);

//Editors
SourceGrid.Cells.Editors.TextBox editorString = new SourceGrid.Cells.Editors.TextBox(typeof(string));
SourceGrid.Cells.Editors.TextBoxUITypeEditor editorDateTime = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(DateTime));


//Create the grid
grid.BorderStyle = BorderStyle.FixedSingle;

grid.ColumnsCount = 3;
grid.FixedRows = 1;
//grid.Rows.Insert(0);

SourceGrid.Cells.ColumnHeader columnHeader;

columnHeader = new SourceGrid.Cells.ColumnHeader("String");
columnHeader.View = viewColumnHeader;
grid[0,0] = columnHeader;

columnHeader = new SourceGrid.Cells.ColumnHeader("DateTime");
columnHeader.View = viewColumnHeader;
grid[0,1] = columnHeader;

columnHeader = new SourceGrid.Cells.ColumnHeader("CheckBox");
columnHeader.View = viewColumnHeader;
grid[0,2] = columnHeader;




for (int r = 1; r < 10; r++)
{
   grid.Rows.Insert(r);

    grid[r,0] = new SourceGrid.Cells.Cell("Hello " + r.ToString());
    grid[r,0].Editor = editorString;

    grid[r,1] = new SourceGrid.Cells.Cell(DateTime.Today);
    grid[r,1].Editor = editorDateTime;

    grid[r,2] = new SourceGrid.Cells.CheckBox(null, true);

    grid[r,0].View = viewNormal;
    grid[r,1].View = viewNormal;
    grid[r,2].View = viewCheckBox;
}

grid.AutoSizeCells();*/
//}

//=================================
//Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
//public static bool RefreshGridOld3(string Direction, SourceGrid.Grid grid, FilterObj filter) //)
//{
//Test1(Direction, grid, filter); //)
//return true;                     
//   string SQL = "";
//    int[] ColumnWidth = null;
//    if (filter != null)
//    {
//        SQL = filter.FullQuerySQL;
//       ColumnWidth = filter.ColumnWidth;
//    }
//    System.Data.DataTable DT;
//    if (!SelectDT(Direction, SQL, out DT)) return false;

//Border
/*DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(ColorTableBorder); //Color.FromArgb(4, 33, 51), 1);
DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

//Views         
CellBackColorAlternate viewNormal = new CellBackColorAlternate(ColorTableOdd1, ColorTableOdd2);
viewNormal.Border = cellBorder;

//ColumnHeader view
SourceGrid.Cells.Views.ColumnHeader viewColumnHeader  = new SourceGrid.Cells.Views.ColumnHeader();
DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();            
backHeader.BackColor = ColorTableHeaderBack; //Color.FromArgb(175, 224, 244);
DevAge.Drawing.BorderLine borderH = new DevAge.Drawing.BorderLine(ColorTableBorder); //Color.FromArgb(4, 33, 51), 1);
DevAge.Drawing.RectangleBorder cellBorderH = new DevAge.Drawing.RectangleBorder(borderH, borderH);           
viewColumnHeader.Border     = cellBorderH;
viewColumnHeader.Background = backHeader;           
viewColumnHeader.ForeColor  = ColorTableHeaderFont; //Color.FromArgb(0, 33, 76);
viewColumnHeader.Font       = FontTableHeader; //new Font("Arial", 11, FontStyle.Bold);
viewColumnHeader.WordWrap   = true;
*/

/*grid.Redim(DT.Rows.Count + 1, DT.Columns.Count);              
grid.FixedRows = 1;
//Документация: https://googledrive.com/host/0B3lO_t8-k4ikN1BxNW9NZGNYQ1k/SourceGrid_EN.html

grid.Rows[0].Height = 40;          
for (int i = 0; i < DT.Columns.Count; i++)
{                                                                                 
    SourceGrid.Cells.ColumnHeader header = new SourceGrid.Cells.ColumnHeader(DT.Columns[i].Caption);
    header.View = viewHeader;                   
    grid[0, i]  = header;
    grid.Columns[i].Width = filter.ColumnWidth[i];               
}

for (int r = 0; r < DT.Rows.Count; r++) 
{                
    for (int c = 0; c < DT.Columns.Count; c++)
    {                   
        grid[r + 1, c] = new SourceGrid.Cells.Cell(DT.Rows[r][c], typeof(String));
        grid[r + 1, c].View = viewRows;
    }
} */
//   return true;
//}
//=================================
//Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
/*public static bool RefreshGrid2(string Direction, FBA.GridFBA DG, FilterObj filter) //)
{
    string SQL = "";
    int[] ColumnWidth = null;
    if (filter != null)
    {
        SQL = filter.FullQuerySQL;
        ColumnWidth = filter.ColumnWidth;
    }
    System.Data.DataTable DT;
    bool flag = SelectDT(Direction, SQL, out DT);
    if (!flag) return false;
    var bd = new DevAge.ComponentModel.BoundDataView(DT.DefaultView);

    DG.Rows.HeaderHeight = 30;
    DG.DataSource = bd;
    var view4 = new SourceGrid.Cells.Views.Cell();
    view4.BackColor = Color.Brown;
    DG.GetCell(1, 1).View = view4;
    return true;
    */
//Grid.DeleteQuestionMessage = null;            
//DG.FixedRows     = 1;
//DG.FixedColumns  = 1;             
//Grid.SelectionMode = SourceGrid.GridSelectionMode.Row;                  
//Grid.SpecialKeys   = SourceGrid.GridSpecialKeys.Default;
//Grid.Selection.EnableMultiSelection = true;
//Grid.Selection. 
/*
//Border
//DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkKhaki, 1);
//DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);
//Views
CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.FromArgb(238, 238, 238), Color.White);
//viewNormal.Border = cellBorder;
//CheckBoxBackColorAlternate viewCheckBox = new CheckBoxBackColorAlternate(Color.Khaki, Color.DarkKhaki);
//viewCheckBox.Border = cellBorder;
//ColumnHeader view
SourceGrid.Cells.Views.ColumnHeader viewHeader = new SourceGrid.Cells.Views.ColumnHeader();
DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
backHeader.BackColor = Color.Maroon;
backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
viewHeader.Background = backHeader;
viewHeader.ForeColor = Color.White;
viewHeader.Font = new Font("Comic Sans MS", 20, FontStyle.Underline);
//viewHeader.
//Editors
SourceGrid.Cells.Editors.TextBox editorString = new SourceGrid.Cells.Editors.TextBox(typeof(string));
SourceGrid.Cells.Editors.TextBoxUITypeEditor editorDateTime = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(DateTime));
*/
//Grid


//SGGrid.DataBindings.

/*SourceGrid.Cells.Views.ColumnHeader viewColumn = new SourceGrid.Cells.Views.ColumnHeader();
viewColumn.Padding = new DevAge.Drawing.Padding(10,10,10,10);
viewColumn.Font = new Font("Arial", 11, FontStyle.Bold);
viewColumn.WordWrap = true;
viewColumn.BackColor = Color.FromArgb(50, 174, 201, 251); 
*/


//SGGrid.Rows.AutoSize(true);
//var  am = new SourceGrid.AutoSizeMode();

//SGGrid.Columns[1].AutoSizeMode = true;
//SourceGrid.Cells.Views.Header dd = new SourceGrid.Cells.Views.Header();
//dd.

//SourceGrid.Cells.Views.RowHeader fg = new SourceGrid.Cells.Views.RowHeader();
//f/g.
// viewColumn.Padding = new Padding(); 
//viewColumn.BackColor = Color.Red;
//view.       
//var columnHeader = new SourceGrid.Cells.ColumnHeader();
//columnHeader.View = viewColumnHeader;         

//Установка ширины колонок.
/*if (ColumnWidth != null)
{
    for (int i = 0; i < SGGrid.Columns.Count; i++)
    {
        if (i < ColumnWidth.Count()) SGGrid.Columns[1].Width = ColumnWidth[i];
    }
}*/

//for (int i = 0; i < SGGrid.Columns.Count; i++)
// {
//    SGGrid.GetCell(0, i).View = viewColumn;                    
//} 

//SourceGrid.Cells.Views.Cell view1 = new SourceGrid.Cells.Views.Cell();
//view1.BackColor = Color.Red;

//SourceGrid.Cells.Views.Cell view2 = new SourceGrid.Cells.Views.Cell();
//view2.BackColor = Color.Brown;

//SourceGrid.Cells.Views.Cell view3 = new SourceGrid.Cells.Views.Cell();
//view3.BackColor = Color.Aqua;

//object objRow = SGGrid.Rows.IndexToDataSourceRow(4);

//SourceGrid.Cells.
//SourceGrid.Cells.ICellVirtual cell = SGGrid.GetCell(1,2);
//SGGrid[1,2].

//SGGrid.GetCellsAtRow()

//SourceGrid.Cells.ICellVirtual[] cells = SGGrid.GetCellsAtRow(2);
//foreach (SourceGrid.Cells.Cell cl in cells) 
//{
//    cl.View = view4;
//}

/*for (int r = 1; r < SGGrid.Rows.Count; r=r+2)
    for (int c = 0; c < SGGrid.Columns.Count; c++)
    {  
        SGGrid.GetCell(r, c).View = view4;
    }



//SourceGrid.Position posCell = new SourceGrid.Position(1, 2);
//SourceGrid.CellContext cellContext = new SourceGrid.CellContext(SGGrid, posCell, cell);
//cellContext.Cell.View.BackColor = Color.Aqua;


//SourceGrid.Cells.ICellVirtual ff;
//SourceGrid.Cells.ICellVirtual[] cells = SGGrid.GetCellsAtRow(2);

//SourceGrid.Cells.ICellVirtual[] cells = SGGrid.GetCellsAtColumn(2);
//SourceGrid.Cells.ICellVirtual[] cells1 = SGGrid.GetCellsAtRow(10);
//cells1[1].View  = view1;

//SourceGrid.Cells.ICellVirtual[] cells2 = SGGrid.GetCellsAtRow(9);
//cells2[1].View  = view2;

//SGGrid.GetCell(1, 1).View = view3;

//SGGrid.Rows.ShowRow




//                 SGGrid.GetCell(1, 1).Model.ToString()
//cells2[1].Model.ToString()
//if (index < cells.Length)
//{
//   Cell cell = (Cell)cells[index];
//
//   if (cell == null)
//      return null; 
//
//   return new GridRowCellAccessibleObject(cell, this);
//   
//}




return true;




return true;            

//for (int i = 1; i < SGGrid.Rows.Count-1; i++)
//{
    //for (int j = 0; j < Grid.Columns.Count; j++)
      //  Grid.GetCell(i, j).View = viewNormal;
//}
//grid1[r,0].View = viewNormal;


//SGGrid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
SGGrid.SelectionMode = SourceGrid.GridSelectionMode.Row;
//SGGrid.SelectionMode = SourceGrid.GridSelectionMode.Column;

SGGrid.Selection.EnableMultiSelection = true; 
(SGGrid.Selection as SelectionBase).BackColor = Color.FromArgb(50, 174, 201, 251); //работает.

DevAge.Drawing.RectangleBorder b = (SGGrid.Selection as SelectionBase).Border;
b.SetWidth(1);  //Ширина границы
 (SGGrid.Selection as SelectionBase).Border = b; 
 */
//}
//=================================
//Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
//public static bool RefreshGrid3(string Direction, SourceGrid.Grid grid, FilterObj filter)
//{

/*var outer = Task.Factory.StartNew(() =>      // внешняя задача
{
    Console.WriteLine("Outer task starting...");
    var inner = Task.Factory.StartNew(() =>  // вложенная задача
    {
        Console.WriteLine("Inner task starting...");
        Thread.Sleep(2000);
        Console.WriteLine("Inner task finished.");
    });
});
outer.Wait(); // ожидаем выполнения внешней задачи
Console.WriteLine("End of Main");

Console.ReadLine();
*/

/*System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

var outer2 = Task.Factory.StartNew(() =>      
{   
    string SQL = "";
    int[] ColumnWidth = null;
    if (filter != null)
    {
         SQL         = filter.FullQuerySQL;
         ColumnWidth = filter.ColumnWidth;
    }                   
    System.Data.DataTable DT;                           
    SelectDT(Direction, SQL, out DT);                        
    grid.Redim(DT.Rows.Count + 1, DT.Columns.Count);              
    grid.FixedRows = 1;                               
    grid.Rows[0].Height = 40;          
    for (int i = 0; i < DT.Columns.Count; i++)
    {                                                                                 
        SourceGrid.Cells.ColumnHeader header = new SourceGrid.Cells.ColumnHeader(DT.Columns[i].Caption);
        header.View = viewHeader;                   
        grid[0, i]  = header;
        grid.Columns[i].Width = filter.ColumnWidth[i];               
    }

    for (int r = 0; r < DT.Rows.Count; r++) 
    {                
        for (int c = 0; c < DT.Columns.Count; c++)
        {                   
            grid[r + 1, c] = new SourceGrid.Cells.Cell(DT.Rows[r][c], typeof(String));
            grid[r + 1, c].View = viewRows;
        }
    }
    if (DT.Rows.Count > 0) grid.BackgroundImage = null;
    else grid.BackgroundImage = global::FBA.Resource.no_data;
 }); 
//outer2.Wait(); // ожидаем выполнения внешней задачи */
//    return true;
//}
//=================================
//Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
//public static bool RefreshGrid_Thread(string Direction, SourceGrid.Grid grid, FilterObj filter) 
//{  
//  new Thread(RefreshThreadGrid4).Start();
//}

//=================================
/*private void button1_Click(object sender, EventArgs e)
{
    int RowCount = dgvSQL1.Rows.Count;
    const string FolderName = @"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C#\Sys\bin\Debug\Settings\TestSave\";
    progressBar1.Maximum = RowCount;
    for (int i = 0; i < RowCount; i++)
    {
        string SQL = dgvSQL1.Rows[i].Cells["SQL"].Value.ToString();
        string MSQL = dgvSQL1.Rows[i].Cells["MSQL"].Value.ToString();
        string NameQuery = dgvSQL1.Rows[i].Cells["Name"].Value.ToString();
        NameQuery = NameQuery.Replace(@"/", "-").Replace(@"\", "-");
        string FileName1 = FolderName + NameQuery + ".txt";
        string FileName2 = FolderName + NameQuery + "_SQL.txt";
        if (!sys.FileWriteText(MSQL, FileName1, false)) return;
        if (!sys.FileWriteText(SQL, FileName2, false)) return;
        progressBar1.Value = i;
    }
    progressBar1.Value = 0;
}*/
//=================================

//SourceGrid.Cells.Views.Cell viewSelected = new SourceGrid.Cells.Views.Cell();
//viewSelected.BackColor = Color.Red;

//SourceGrid.CellContext ctx = new SourceGrid.CellContext(DGSearch, 2, 2);
//ctx.Cell.View = viewSelected;


//SourceGrid.Position posCell = new SourceGrid.Position(2, 2);
//SourceGrid.Cells.ICellVirtual cell = DGSearch.GetCell(2, 2);
//SourceGrid.CellContext cellContext = new SourceGrid.CellContext(DGSearch, posCell, cell);
//cellContext.Cell.View = viewSelected;

//return true;


//SourceGrid.Cells.ICellVirtual cell = DGSearch.GetCell(i, j);
//string g = cell.Model.ValueModel.GetValue();// .ToString();
//SourceGrid.GridRows


//SourceGrid.Conditions.ConditionView selectedConditionBold = new SourceGrid.Conditions.ConditionView(viewSelected);
//selectedConditionBold.EvaluateFunction = delegate (FBA.GridFBAColumn column, int gridRow, object itemRow)
//{
//    System.Data.DataRowView row = (System.Data.DataRowView)itemRow;
//    //return row[1] is bool;
//(bool)row[2] == true;
//};

//DGSearch.Columns[1].Conditions.Add(selectedConditionBold);

//return true;
//DGSearch.Columns[1].Width = 100;

// SourceGrid.Position p = new SourceGrid.Position(2, 2);
//DGSearch.Selection.SelectCell(p, true);
//((SelectionBase)DGSearch.Selection).BackColor = Color.Yellow;  //Color.FromArgb(50, 174, 201, 251);
//return true;

//SourceGrid.Cells.ICellVirtual d = DGSearch.GetCell(1, 1);
//SourceGrid.CellContext ctx = new SourceGrid.CellContext(DGSearch, p, d);
//ctx.
//cell.View = viewfind;
//SourceGrid.Cells.Views.Cell viewfind = new SourceGrid.Cells.Views.Cell();
//viewfind.BackColor = Color.Red;

//foreach (FBA.GridFBAColumn col in DGSearch.Columns)
//{
//AlternateColor
//SourceGrid.Conditions.ICondition condition = SourceGrid.Conditions.ConditionBuilder.AlternateView(col.DataCell.View, Color2, Color.Black);
//col.Conditions.Add(condition);

//Header BackColor
//col.HeaderCell.View = view2;
//    col.GetDataCell(2).View = viewfind;

//if (col.Width < 80) col.Width = 80;
//}

//return true;

//SourceGrid.Cells.ICellVirtual cell1 = DGSearch.GetCell(i, j);
//cell1. = viewfind;

//SourceGrid.Cells.Views.Cell transparentView = new SourceGrid.Cells.Views.Cell();
//transparentView.BackColor = Color.Transparent;
//SourceGrid.Cells.Cell l_Cell = new SourceGrid.Cells.Cell("Transparent");
//l_Cell.View = transparentView;


//grid1[r, c] = l_Cell;






//Сбрасываем найденное.




//SourceGrid.Cells.Views.Cell view1 = new SourceGrid.Cells.Views.Cell();
//view1.BackColor = Color.White;



//DGSearch.SuspendLayout();
/*for (int i = 0; i < DGSearch.Rows.Count; i++)
{
    for (int j = 0; j < DGSearch.Columns.Count; j++)
    {
        SourceGrid.Cells.ICellVirtual cell = DGSearch.GetCell(i, j);
        cell.View = view1;

    }
}*/


//Grid.Columns[0,1].View = new SourceGrid.Cells.Views.Cell();
//SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
// view.BackColor = Color.Red;
//потом пройтись по строке с условием и 
//Grid.GetCell(0,1).View = view;
//Grid.Selection.
//((SelectionBase)Grid.Selection).BackColor = Color.FromArgb(50, 174, 201, 251);


//Header BackColor
//SourceGrid.Cells.Views.Cell view2 = new SourceGrid.Cells.Views.Cell();
//view2.BackColor = Color.FromArgb(187, 205, 251);
//view2.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
//view2.WordWrap = true;
//Color Color2 = Color.FromArgb(243, 243, 243);
//foreach (FBA.GridFBAColumn col in DGSearch.Columns)
//{
//AlternateColor
//SourceGrid.Conditions.ICondition condition = SourceGrid.Conditions.ConditionBuilder.AlternateView(col.DataCell.View, Color2, Color.Black);
//col.Conditions.Add(condition);
//col.Conditions.
//Header BackColor
//    col.HeaderCell.View = view2;
//}

//DGSearch.ResumeLayout();
//DGSearch.PerformLayout();


//Header BackColor
//SourceGrid.Cells.Views.Cell view2 = new SourceGrid.Cells.Views.Cell();
//view2.BackColor = Color.FromArgb(187, 205, 251);
//view2.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
//view2.WordWrap = true;


//foreach (FBA.GridFBAColumn col in DGSearch.Columns)
//{
//AlternateColor
//    SourceGrid.Conditions.ICondition condition = SourceGrid.Conditions.ConditionBuilder.AlternateView(col.DataCell.View, Color2, Color.Black);
//    col.Conditions.Add(condition);

//Header BackColor
// col.HeaderCell.View = view2;
//}

//SourceGrid.Cells.Views.Cell viewfind = new SourceGrid.Cells.Views.Cell();
//viewfind.BackColor = Color.Yellow;
//viewfind.Font = new System.Drawing.Font("Arial", 11, FontStyle.Regular);


//SourceGrid.Cells.ICellVirtual cell = DGSearch.GetCell(1, 1);
//cell.View = viewfind;


//DGSearch.Refresh();
//===================================================================
//DataGridViewColumn col = new DataGridViewColumn();
//if (DGSearch.Columns[j].GetType().ToString() == "Sytem.String")
//col.ValueType = DGSearch.Columns[j].GetType();
//col.Name = ColumnName;
//col.HeaderText = ColumnHeader;
//DGResult.Columns.Add(col);
//DGResult.Columns.Add(ColumnName, ColumnHeader);
//{
//    var dgwc = new DataGridViewTextBoxColumn();
//    dgwc.Name = ColumnName;
//    dgwc.HeaderText = ColumnHeader;
//    DGResult.Columns.Add(dgwc);
//}
//===================================================================
//{
//    var dgwc = new DataGridViewTextBoxColumn();
//    dgwc.Name = ColumnName;
//    dgwc.HeaderText = ColumnHeader;
//    DGResult.Columns.Add(dgwc);
//}



//dgwc.ValueType = typeof(string);

//DGResult.Columns.Add(DGSearch.Columns[j].PropertyName, DGSearch.Columns[j].PropertyName);

//DGResult.Columns[0].Width = DGSearch.Columns[j].Width / 2;

//typeof DGSearch.Columns[j].GetType()

//DGResult.Columns.Add(DGSearch.Columns[j].PropertyName, DGSearch.Columns[j].PropertyName);
//DGSearch.Columns[j].
//var FirstColumn        = new DataGridViewColumn();
//FirstColumn.Name       = "OrderNumber";
//FirstColumn.Frozen     = true;
//FirstColumn.HeaderText = "№";
//FirstColumn.Width      = 20;
//DGResult.Columns.Insert(0, FirstColumn);
//===================================================================
//private void Form1_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.F1 && e.Alt)
//    {
//        button1.PerformClick();// имитируем нажатие button1
//    }
//}
//===================================================================
//Перехват нажатия клавиш
//private void FormDirectory_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
//{
//    //F3 - поиск
//    var key = e.;
//    if (key == Key.A)
//        e.Handled = true;
//}
//===================================================================
//DG2.
//DG2[1,2] = 
//IController ff;
//this.DG1.MainView
/*if (view == null || view.SelectedRowsC
 * 
 * ount == 0) return;
DataRow[] rows = new DataRow[view.SelectedRowsCount];
for (int i = 0; i < view.SelectedRowsCount; i++)
    rows[i] = view.GetDataRow(view.GetSelectedRows()[i]);
view.BeginSort();
try
{
    foreach (DataRow row in rows)
        row.Delete();
}
finally
{
    view.EndSort();
}*/


//if (gridView1 == null || gridView1.SelectedRowsCount == 0) return "";
//
// gridView1.SelectCell.
// DataRow[] rows = new DataRow[gridView1.SelectedRowsCount];
// for (int i = 0; i < gridView1.SelectedRowsCount; i++)
//     rows[i] = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
//  gridView1.BeginSort();



//int N = gridView1.SelectedRowsCount;
//public string[,] Words = new string[WordsY, WordsX]; //Это запрос, разбитый по словам.



//i//f (FormType == FormDirectoryType.FilterMultiselect)


//this.ButtonFilter = ButtonFilter;
//this.ButtonUpdate = ButtonUpdate;
//this.ButtonAdd    = ButtonAdd;
//this.ButtonEdit   = ButtonEdit;
// this.ButtonDelete = ButtonDelete;
//this.ButtonSearch = ButtonSearch;

//tb_N1.Visible = ButtonFilter;
//tb_N2.Visible = ButtonUpdate;
//tb_N3.Visible = ButtonAdd;
//tb_N4.Visible = ButtonEdit;
//tb_N5.Visible = ButtonDelete;
//tb_N6.Visible = ButtonSearch;

//btnCancel.Visible = ButtonCancel;
//btnOk.Visible     = ButtonOk;
//if ((!ButtonCancel) && (!ButtonOk)) pnlResult.Visible = false;
//===================================================================
//Открыть в Excel таблицу, открытую в FBA.GridFBA.
/*public static bool SourceGridToExcel(this FBA.GridFBA DG)
{
    //Если не установле Office, то не скомпилируется.                                            
    #if CompileWithExcel
    try
    {                          
        var ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        ExcelApp.Application.Workbooks.Add(Type.Missing);
        ExcelApp.Columns.ColumnWidth = 25;

        //Row, Col
        //for (int i = 0; i < DG.Columns.Count; i++)
        //    ExcelApp.Cells[1, i + 1] = DG.Columns[i].HeaderCell.HeaderText;

        //int SelRows = DG.SelectedRows.Count;
        int N = 0;
        for (int i = 0; i < DG.Rows.Count; i++)
        {

            //DG
            //if ((SelRows > 1) && (!DG.Rows[i].Selected)) continue;
            //if (!DG.Selection.IsSelectedRow(i)) continue;
            //for (int j = 0; j < DG.Columns.Count; j++)
            //    ExcelApp.Cells[N + 2, j + 1] = DG[j, i].DisplayText;
            N++;
        }
        ExcelApp.Visible = true;               
    } catch (Exception ex)
    {
        sys.SM(ex.Message);
        return false;
    } 

    #endif
    return true;
}*/
//===================================================================


/*
* Создано в SharpDevelop.
* Пользователь: Travin
* Дата: 05.09.2017
* Время: 13:40
*/


//E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Sys\bin\Debug\Bin
//E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Template
//sys.SM(@"\..\..\..\..\Template\");
//string FromDir = sys.PathTemplate + "DLLCustom";
//string ToDir   = sys.PathForms + "DLLCustom";
//sys.DirCopy(FromDir, ToDir);






//Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
/*public bool RefreshGridSG2(string Direction, string SQL, FBA.GridFBA SGGrid)
{


    System.Data.DataTable DT;
    if (!sys.SelectDT(Direction, SQL, out DT)) return false;

    //var bd = new DevAge.ComponentModel.BoundDataView(DT.DefaultView); 
    //SGGrid.DataSource = bd;

    //Border
    //DevAge.Drawing.BorderLine      BorderLine1     = new DevAge.Drawing.BorderLine(Color.DarkKhaki, 4);
    //DevAge.Drawing.RectangleBorder BorderCell1 = new DevAge.Drawing.RectangleBorder(BorderLine1, BorderLine1);
    //Views
    CellBackColorAlternate ViewCell = new CellBackColorAlternate(Color.White, Color.LightGray);
    //ViewCell.Border = BorderCell1;

    //CheckBoxBackColorAlternate viewCheckBox = new CheckBoxBackColorAlternate(Color.Khaki, Color.DarkKhaki);
    //viewCheckBox.Border = cellBorder;
    //ColumnHeader view
    SourceGrid.Cells.Views.ColumnHeader ViewHeader = new SourceGrid.Cells.Views.ColumnHeader();


    DevAge.Drawing.VisualElements.ColumnHeader BackHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
    BackHeader.BackColor = Color.Maroon;                      
    //backHeader.Border = BorderCell1; //DevAge.Drawing.RectangleBorder.NoBorder;           

    ViewHeader.Background = BackHeader;
    ViewHeader.ForeColor = Color.White;
    //viewColumnHeader.Font = new Font("Comic Sans MS", 20, FontStyle.Underline);
    ViewHeader.Font = new Font("Arial", 11, FontStyle.Bold);

    //Editors
    SourceGrid.Cells.Editors.TextBox editorString = new SourceGrid.Cells.Editors.TextBox(typeof(string));
    SourceGrid.Cells.Editors.TextBoxUITypeEditor editorDateTime = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(DateTime));
    //Create the grid
    //SGGrid.BorderStyle = BorderStyle.FixedSingle;
    //SGGrid.ColumnsCount = 3;

    //SourceGrid.Cells.Views.RowHeader ViewCell2 = new SourceGrid.Cells.Views.RowHeader();
    SourceGrid.Cells.Views.Cell ViewCell3 = new SourceGrid.Cells.Views.Cell();
    ViewCell3.Font =  new Font("Arial", 14, FontStyle.Bold);




    SGGrid.FixedRows = 1;       
    // SGGrid.Rows.Insert(0);
    //viewColumnHeader.Padding = new DevAge.Drawing.Padding(10, 10, 10, 10);
    //viewColumnHeader.Border  = 

    //SGGrid.SelectionMode   = SourceGrid.GridSelectionMode.Row;
    //((SourceGrid.Grid)SGGrid).Rows[0].Height = 100;
    //for (int i = 0; i < SGGrid.Columns.Count; i++)
    //    SGGrid.GetCell(0, i).View = ViewHeader;                    


    //for (int i = 0; i < SGGrid.Columns.Count; i++)
    //    for (int j = 1; j < SGGrid.Rows.Count; j++)
    //        SGGrid.GetCell(j, i).View = ViewCell3;



    grid1.Redim(DT.Rows.Count + 1, DT.Columns.Count);
    for (int j = 0; j < DT.Columns.Count; j++)
        grid1[0, j] =  new SourceGrid.Cells.Cell(DT.Columns[j].Caption);

    for (int i = 0; i < DT.Rows.Count; i++)
        for (int j = 0; j < DT.Columns.Count; j++)
            grid1[i + 1, j] = new SourceGrid.Cells.Cell(DT.Rows[i][j].ToString());


    //SourceGrid.Cells.ColumnHeader columnHeader;
    //SourceGrid.Cells.ColumnHeader columnHeader = new SourceGrid.Cells.ColumnHeader("String");
    //columnHeader.View = viewColumnHeader;
    //SGGrid[0,0] = columnHeader;
    //columnHeader = new SourceGrid.Cells.ColumnHeader("DateTime");
    //columnHeader.View = viewColumnHeader;
    //SGGrid[0,1] = columnHeader;
    //columnHeader = new SourceGrid.Cells.ColumnHeader("CheckBox");
    //columnHeader.View = viewColumnHeader;
    //SGGrid[0,2] = columnHeader;


    //Grid.DeleteQuestionMessage = null;            
    //DG.FixedRows     = 1;
    //DG.FixedColumns  = 1;             
    //Grid.SelectionMode = SourceGrid.GridSelectionMode.Row;                  
    //Grid.SpecialKeys   = SourceGrid.GridSpecialKeys.Default;
    //Grid.Selection.EnableMultiSelection = true;
    //Grid.Selection. 
    /*
    //Border
    //DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkKhaki, 1);
    //DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);
    //Views
    CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.FromArgb(238, 238, 238), Color.White);
    //viewNormal.Border = cellBorder;
    //CheckBoxBackColorAlternate viewCheckBox = new CheckBoxBackColorAlternate(Color.Khaki, Color.DarkKhaki);
    //viewCheckBox.Border = cellBorder;
    //ColumnHeader view
    SourceGrid.Cells.Views.ColumnHeader viewHeader = new SourceGrid.Cells.Views.ColumnHeader();
    DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
    backHeader.BackColor = Color.Maroon;
    backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
    viewHeader.Background = backHeader;
    viewHeader.ForeColor = Color.White;
    viewHeader.Font = new Font("Comic Sans MS", 20, FontStyle.Underline);
    //viewHeader.
    //Editors
    SourceGrid.Cells.Editors.TextBox editorString = new SourceGrid.Cells.Editors.TextBox(typeof(string));
    SourceGrid.Cells.Editors.TextBoxUITypeEditor editorDateTime = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(DateTime));
    */
//Grid


//SGGrid.DataBindings.

/*SourceGrid.Cells.Views.ColumnHeader viewColumn = new SourceGrid.Cells.Views.ColumnHeader();
viewColumn.Padding = new DevAge.Drawing.Padding(10,10,10,10);
viewColumn.Font = new Font("Arial", 20, FontStyle.Underline);
// viewColumn.Padding = new Padding(); 
//viewColumn.BackColor = Color.Red;
//view.       
//var columnHeader = new SourceGrid.Cells.ColumnHeader();
//columnHeader.View = viewColumnHeader;         

for (int i = 0; i < SGGrid.Columns.Count; i++)
{
    SGGrid.GetCell(0, i).View = viewColumn;                    
} 

for (int i = 1; i < SGGrid.Rows.Count-1; i++)
{
    //for (int j = 0; j < Grid.Columns.Count; j++)
      //  Grid.GetCell(i, j).View = viewNormal;
}
//grid1[r,0].View = viewNormal;


//SGGrid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
SGGrid.SelectionMode   = SourceGrid.GridSelectionMode.Row;
//SGGrid.SelectionMode = SourceGrid.GridSelectionMode.Column;

SGGrid.Selection.EnableMultiSelection = true; 
(SGGrid.Selection as SelectionBase).BackColor = Color.FromArgb(50, 174, 201, 251); //работает.

DevAge.Drawing.RectangleBorder b = (SGGrid.Selection as SelectionBase).Border;
b.SetWidth(1);  //Ширина границы
 (SGGrid.Selection as SelectionBase).Border = b;

return true;
}*/

//private void SetGrid()
//{
/*string SQL = "SELECT * FROM fbaAttrParent";
System.Data.DataTable DT;
if (!sys.SelectDT(DirectionQuery.Remote, SQL, out DT)) return;
dataGridView1.DataSource = DT;

//grid1[i + 1, j].

return;

//Border
DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkKhaki, 1);
DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);
//Views
CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.Khaki, Color.DarkKhaki);
viewNormal.Border = cellBorder;
CheckBoxBackColorAlternate viewCheckBox = new CheckBoxBackColorAlternate(Color.Khaki, Color.DarkKhaki);
viewCheckBox.Border = cellBorder;
//ColumnHeader view
SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
backHeader.BackColor = Color.Maroon;
backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
viewColumnHeader.Background = backHeader;
viewColumnHeader.ForeColor = Color.White;
//viewColumnHeader.Font = new Font("Comic Sans MS", 20, FontStyle.Underline);
viewColumnHeader.Font = new Font("Arial", 20, FontStyle.Underline);

//Editors
SourceGrid.Cells.Editors.TextBox editorString = new SourceGrid.Cells.Editors.TextBox(typeof(string));
SourceGrid.Cells.Editors.TextBoxUITypeEditor editorDateTime = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(DateTime));
//Create the grid
grid1.BorderStyle = BorderStyle.FixedSingle;
grid1.Redim(DT.Rows.Count + 1, DT.Columns.Count);
grid1.FixedRows = 1;
SourceGrid.Cells.ColumnHeader columnHeader = new SourceGrid.Cells.ColumnHeader("String");
columnHeader.View = viewColumnHeader;  


grid1.Rows[0].Height = 100;
for (int j = 0; j < DT.Columns.Count; j++)
{                                            
    //grid1[0, j] = columnHeader;               
    grid1[0, j] = new SourceGrid.Cells.Cell(DT.Columns[j].Caption);             
}

for (int i = 0; i < DT.Rows.Count; i++)
    for (int j = 0; j < DT.Columns.Count; j++)
{

    grid1[i + 1, j] = new SourceGrid.Cells.Cell(DT.Rows[i][j].ToString());
    //grid1[i + 1, j].View = viewNormal;                
}
grid1.AutoSizeCells();            


//grid1.ColumnsCount = 3;

//grid1.Rows.Insert(0);
//grid1.Rows[0].Height = 100;
//SourceGrid.Cells.ColumnHeader columnHeader;
//columnHeader = new SourceGrid.Cells.ColumnHeader("String");
//columnHeader.View = viewColumnHeader;             
//grid1[0,0] = columnHeader;
//columnHeader = new SourceGrid.Cells.ColumnHeader("DateTime");
//columnHeader.View = viewColumnHeader;
//grid1[0,1] = columnHeader;
//columnHeader = new SourceGrid.Cells.ColumnHeader("CheckBox");
//columnHeader.View = viewColumnHeader;
//grid1[0,2] = columnHeader;
//for (int r = 1; r < 10; r++)
//{
//    grid1.Rows.Insert(r);
//    grid1[r,0] = new SourceGrid.Cells.Cell("Hello " + r.ToString());
//     grid1[r,0].Editor = editorString;
//    grid1[r,1] = new SourceGrid.Cells.Cell(DateTime.Today);
//    grid1[r,1].Editor = editorDateTime;
//    grid1[r,2] = new SourceGrid.Cells.CheckBox(null, true);
//    grid1[r,0].View = viewNormal;
//    grid1[r,1].View = viewNormal;
//    grid1[r,2].View = viewCheckBox;
//}
//grid1.AutoSizeCells();*/
//}
//void button4_Click(object sender, EventArgs e)
//{
//    string ss = sys.GetComponentValues(this.Controls);

//string[,] arr = sys.ArrayFromStr2(ss, ':');
//sys.ArrayView("CapForm", "", arr);
// sys.SM(ss);
//}   


//Два класса Private для работы с SourceGrid.
/*private class CellBackColorAlternate : SourceGrid.Cells.Views.Cell
{
    public CellBackColorAlternate(Color firstColor, Color secondColor)
    {
        FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
        SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
    }
    private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
    public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
    {
        get { return mFirstBackground; }
        set { mFirstBackground = value; }
    }
    private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
    public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
    {
        get { return mSecondBackground; }
        set { mSecondBackground = value; }
    }
    protected override void PrepareView(SourceGrid.CellContext context)
    {
        base.PrepareView(context);
        if (Math.IEEERemainder(context.Position.Row, 2) == 0)
            Background = FirstBackground;
        else
            Background = SecondBackground;
    }
}

private class CheckBoxBackColorAlternate : SourceGrid.Cells.Views.CheckBox
{
    public CheckBoxBackColorAlternate(Color firstColor, Color secondColor)
    {
        FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
        SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
    }
    private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
    public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
    {
        get { return mFirstBackground; }
        set { mFirstBackground = value; }
    }
    private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
    public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
    {
        get { return mSecondBackground; }
        set { mSecondBackground = value; }
    }
    protected override void PrepareView(SourceGrid.CellContext context)
    {
        base.PrepareView(context);
        if (Math.IEEERemainder(context.Position.Row, 2) == 0)
            Background = FirstBackground;
        else
            Background = SecondBackground;
    }
}*/

//Обновить данные в гриде.
/*public static bool RefreshGrid(string Direction, string SQL, DataGridView Grid)   
{                   
    try
    {                
        string IDCur = "";       
        if (Grid.Columns.Count > 0)
        {
            if ((Grid.Columns[0].HeaderText == "ID") && (Grid.CurrentRow != null))
            {
                //if (Grid.SelectedRows.Count > 0)
                if (Grid.CurrentRow.Index > 0)
                    //IDCur = Grid.SelectedRows[0].Cells["ID"].Value.ToString();
                    IDCur = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();

            }                
            //Grid.Rows[Grid.SelectedRows[0].Index][0].ToString
        }       
        //if (TypeGrid == "DataGridView")  
            sys.SelectGV(Direction, SQL, Grid);
        //   else  SelectSG(SQL, Grid);    

        foreach (DataGridViewColumn column in Grid.Columns) 
        {
            if (column.Width > 400) column.Width = 400;
        }

        if (IDCur == "") return true;               
        for (int i = 0; i < Grid.Rows.Count; i++)
        {   
            if (Grid.Rows[i].Cells[0].Value != null)
            if (IDCur == Grid.Rows[i].Cells[0].Value.ToString())
            {
                //Grid.CurrentRow.Selected = false; 
                Grid.Rows[i].Selected = true;
                //Grid.CurrentRow.Index = i;
                //(((System.Data.DataTable)Grid.DataSource).Rows[0].
                return true;
            }                                             
        }                            
        return true;
    }
    catch (Exception ex)
    {
        sys.SM("Ошибка запроса: " + Var.CR + ex.Message);
        return false;
    }      
}*/
//}
//}


//=================

//return true;
//System.Data.DataTable DT;
//bool flag = false;
//var task1 = Task.Factory.StartNew(() =>
//{
//RefreshGrid(Direction, DG, filter);
//System.Data.DataTable DTTask;
//    flag = SelectDT(Direction, SQL, out DTTask);
//    return DTTask;
//
//});


//var F1 = Task.Factory.StartNew(dd);                      
//((FormFBA)F1.Result).Show();

//task1.Wait();
// var dd = task1.Result;

//System.Data.DataTable DT = (System.Data.DataTable)dd;

//=================
//bool flag = true;




//DG.AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;

//Правильно получать позицию: 
//SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
//MessageBox.Show(this, context.Position.ToString());
//DG.AutoSize = true;

//View.WordWrap = true;

//SourceGrid.ClipboardMode
//SourceGrid.Cells.Cell s;

//ак в SourceGrid закрасить строку в зависимости от данных?
//SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
//view.BackColor = Color.Red;

//потом пройтись по строке с условием и
//oGrid_1[r, c].View = view;
//=================

//if (DG[i, j].Value.ToString() == SearchText)
//{
// DG.CurrentCell = DG[i, j];
//findrow = Table0.CurrentRow.Index + 1;
//DG.Rows[i].Selected = true;


//return;
//}

//if (Value.ToLower().Contains(textBox1.Text.ToLower()));


/*private void search1( )
{
    DataGridView dataGridView;

    if (!newFind)
    {
        dataGridView.Rows[lastFindRow].Cells[lastFindCell].Style.BackColor = oldBackColor;
        dataGridView.Rows[lastFindRow].Cells[lastFindCell].Style.SelectionBackColor = oldBackColor;
        dataGridView.Rows[lastFindRow].Cells[lastFindCell].Style.ForeColor = oldForeColor;
        dataGridView.Rows[lastFindRow].Cells[lastFindCell].Style.SelectionForeColor = oldForeColor;
    }
    if (searchTextBox.Text != null && searchTextBox.Text != String.Empty)
    {
        bool finded = false;
        int n = lastFindRow;
        lastFindCell--;
        for (int i = lastFindRow; i >= 0; i--)
        {
            if (dataGridView.Rows[i].Visible)
            {
                if (i != lastFindRow)
                    lastFindCell = dataGridView.Rows[i].Cells.Count - 1;
                finded = false;
                for (int k = lastFindCell; k >= 0; k--)
                {
                    if (dataGridView.Rows[i].Cells[k].Value != null && dataGridView.Rows[i].Cells[k].Visible)
                    {
                        if (dataGridView.Rows[i].Cells[k].Value.ToString().IndexOf( searchTextBox.Text, StringComparison.OrdinalIgnoreCase ) >= 0)
                        {
                            lastFindCell = k;
                            oldBackColor = dataGridView.Rows[i].Cells[k].Style.BackColor;
                            oldForeColor = dataGridView.Rows[i].Cells[k].Style.ForeColor;
                            finded = true;
                            break;
                        }
                    }
                }
                if (finded)
                {
                    dataGridView.Rows[i].Cells[lastFindCell].Style.SelectionBackColor = Color.Lime;
                    dataGridView.Rows[i].Cells[lastFindCell].Style.SelectionForeColor = Color.Black;
                    dataGridView.CurrentCell = dataGridView.Rows[i].Cells[lastFindCell];
                    newFind = false;
                    lastFindRow = i;
                    break;
                }
                n = i;
            }
        }
        if (!finded)
        {
            newFind = true;
            lastFindRow = dataGridView.Rows.Count - 1;
            if (dataGridView.Rows.Count > 0)
                lastFindCell = dataGridView.Rows[0].Cells.Count - 1;

            if (n <= 0)
            {
                if (MessageBox.Show( "Поиск достиг начала таблицы! Начать поиск заново с конца?", "Информация!", MessageBoxButtons.YesNo, MessageBoxIcon.Information ) == DialogResult.Yes)
                {
                    searchUpBtn.PerformClick();
                }
            }
            else
                MessageBox.Show( "Искомый текст не найден!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }
}*/




/*private void searchDownBtn_Click( object sender, EventArgs e )
{
    if (!newFind)
    {
        dataGridView.Rows[lastFindRow].Cells[lastFindCell].Style.BackColor = oldBackColor;
        dataGridView.Rows[lastFindRow].Cells[lastFindCell].Style.SelectionBackColor = oldBackColor;
        dataGridView.Rows[lastFindRow].Cells[lastFindCell].Style.ForeColor = oldForeColor;
        dataGridView.Rows[lastFindRow].Cells[lastFindCell].Style.SelectionForeColor = oldForeColor;
    }
    if (searchTextBox.Text != null && searchTextBox.Text != String.Empty)
    {
        bool finded = false;
        int n = lastFindRow;
        lastFindCell++;
        for (int i = lastFindRow; i < dataGridView.Rows.Count; i++)
        {
            if (dataGridView.Rows[i].Visible)
            {
                if (i != lastFindRow)
                    lastFindCell = 0;
                finded = false;
                for (int k = lastFindCell; k < dataGridView.Rows[i].Cells.Count; k++)
                {
                    if (dataGridView.Rows[i].Cells[k].Value != null && dataGridView.Rows[i].Cells[k].Visible)
                    {
                        if (dataGridView.Rows[i].Cells[k].Value.ToString().IndexOf( searchTextBox.Text, StringComparison.OrdinalIgnoreCase ) >= 0)
                        {
                            lastFindCell = k;
                            oldBackColor = dataGridView.Rows[i].Cells[k].Style.BackColor;
                            oldForeColor = dataGridView.Rows[i].Cells[k].Style.ForeColor;
                            finded = true;
                            break;
                        }
                    }
                }
                if (finded)
                {
                    dataGridView.Rows[i].Cells[lastFindCell].Style.SelectionBackColor = Color.Lime;
                    dataGridView.Rows[i].Cells[lastFindCell].Style.SelectionForeColor = Color.Black;
                    dataGridView.CurrentCell = dataGridView.Rows[i].Cells[lastFindCell];
                    newFind = false;
                    lastFindRow = i;
                    break;
                }
                n = i;
            }
        }
        if (!finded)
        {
            newFind = true;
            lastFindRow = 0;
            lastFindCell = 0;
            if (n + 1 >= dataGridView.Rows.Count)
            {
                if (MessageBox.Show( "Поиск достиг конца таблицы! Начать поиск заново сначала?", "Информация!", MessageBoxButtons.YesNo, MessageBoxIcon.Information ) == DialogResult.Yes)
                {
                    searchDownBtn.PerformClick();
                }
            }
            else
                MessageBox.Show( "Искомый текст не найден!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }
} */

//===================================================================
//Поиск с показом результатов поиска.
//if (SenderName == "btnResult")
//{
//GoSearsh(EditFBA1.comboBox1.Text, true); 
//this.Height = 500;
//if (TextSearchPrev == tbSearchText.Text)
//{
//    Collapsed = !Collapsed;
//    if (Collapsed) this.Height = 261;
//    else this.Height = 500;
//} else
//{
//    Collapsed = false;
//    this.Height = 500;
//}
//}

//if (!Collapsed) this.btnResult.Image = global::FBA.Resource.Collapse2_24;
//else this.btnResult.Image = global::FBA.Resource.Expand2_24;   
//===================================================================
//if (!Collapsed) this.btnResult.Image = global::FBA.Resource.Collapse2_24;
//else this.btnResult.Image = global::FBA.Resource.Expand2_24;  
//===================================================================
//SourceGrid.Cells.Controllers.CustomEvents clickEvent = new SourceGrid.Cells.Controllers.CustomEvents();
//clickEvent.Click += new EventHandler(clickEvent_Click);
//var eventsController = new SourceGrid.Cells.Controllers.CustomEvents.CustomEvents();
//DG2.Rows.
//IController

//===================================================================


//Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
/*public static bool RefreshGrid(string Direction, FBA.GridFBA DG, FilterObj filter)
{
    string SQL = "";
    int[] ColumnWidth = null;
    if (filter != null)
    {
        SQL = filter.FullQuerySQL;
        ColumnWidth = filter.ColumnWidth;
    }

    //Код выполняется в отдельном потоке
    var task1 = Task.Factory.StartNew(() =>
    {
        System.Data.DataTable DT;
        bool flag1 = SelectDT(Direction, SQL, out DT);
        //return DT;

        //Доступ к UI контролам            
        //System.Data.DataTable DT = (System.Data.DataTable)task1.Result;

        if (DT == null)
        {
            DG.BackgroundImage = global::FBA.Resource.no_data;
            return null;
        }

        //самое главное - установка DataSource.
        var bd = new DevAge.ComponentModel.BoundDataView(DT.DefaultView);

        FBA.GridFBA DG1 = new FBA.GridFBA();
        DG1.DataSource = bd;

        //return false;

        //Возможность выделять несколько строк.
        DG1.SelectionMode = GridSelectionMode.Cell; //Включение возможности выделения отдельных ячеек.
        DG1.Selection.EnableMultiSelection = true;

        //Selection BorderColor
        SelectionBase Selection = DG1.Selection as SelectionBase;
        DevAge.Drawing.RectangleBorder border = Selection.Border;
        border.SetColor(Color.FromArgb(6, 1, 214));
        Selection.Border = border;

        //Selection BackColor
        //Selection.BackColor = Color.FromArgb(50, Color.FromArgb(252, 254, 167)); //Светло желтый
        //Selection.BackColor = Color.FromArgb(50, Color.FromArgb(239, 245, 107)); //Желтый
        Selection.BackColor = Color.FromArgb(50, Color.FromArgb(142, 142, 255));   //Сиреневый
                                                                                   //Selection BorderWidth
        DevAge.Drawing.RectangleBorder b = Selection.Border;
        b.SetWidth(1);
        Selection.Border = b;

        //Selection FocusBackColor
        Selection.FocusBackColor = Color.FromArgb(50, Color.FromArgb(226, 254, 118));

        //Header BackColor
        Color Color2 = Color.FromArgb(243, 243, 243);

        //Header BackColor
        //SourceGrid.Cells.Views.Cell view2 = new SourceGrid.Cells.Views.Cell();
        SourceGrid.Cells.Views.ColumnHeader view3 = new SourceGrid.Cells.Views.ColumnHeader();
        view3.BackColor = Color.FromArgb(187, 205, 251);
        view3.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
        view3.WordWrap = true;




        //SourceGrid.Cells.Views. view3 = new SourceGrid.Cells.Views.ColumnHeader();
        //DG.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize;
        //DG.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
        //DG.Columns[0].Width = 20;
        //DG.Columns.AutoSizeView();      
        //var bd = new DevAge.ComponentModel.BoundDataView(DT.DefaultView);
        //DG.DataSource = bd;
        DG1.ClipboardMode = SourceGrid.ClipboardMode.Copy;
        DG1.AutoStretchColumnsToFitWidth = true;
        DG1.AutoStretchRowsToFitHeight = false;
        DG1.AutoSizeCells();
        //DG1.Rows.HeaderHeight = 40;
        DG1.BackgroundImage = null;

        //return true;

        foreach (FBA.GridFBAColumn col in DG1.Columns)
        {
            //AlternateColor
            SourceGrid.Conditions.ICondition condition = SourceGrid.Conditions.ConditionBuilder.AlternateView(col.DataCell.View, Color2, Color.Black);
            col.Conditions.Add(condition);

            //Header BackColor
            col.HeaderCell.View = view3;
            if (col.Width < 80) col.Width = 80;
        }

        return DG1;

    });

    //После завершения отновляем GUI компаненты.
    var task2 = task1.ContinueWith((previous) =>
    {


        FBA.GridFBA DG1 = (FBA.GridFBA)task1.Result;
        //System.Data.DataTable DT = (System.Data.DataTable)task1.Result;
        //DG.DataSource = DG1.DataSource;


    }, TaskScheduler.FromCurrentSynchronizationContext());
    return true;


}
*/
//===================================================================
/*
  //Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
        public static bool RefreshGrid2_2(string Direction, FBA.GridFBA DG) //)
        {
            //string SQL = "";
            //int[] ColumnWidth = null;
            //if (filter != null)
            //{
            //    SQL = filter.FullQuerySQL;
            //    ColumnWidth = filter.ColumnWidth;
            //}
            //System.Data.DataTable DT;
            //bool flag = sys.SelectDT(Direction, SQL, out DT);
            //if (!flag) return false;

            //var bd = new DevAge.ComponentModel.BoundDataView(DT.DefaultView);


            //DG.DataSource = bd;

            /*DG.Selection.EnableMultiSelection = true;
            DG.Rows.HeaderHeight = 30;    

            //Header BackColor
            SourceGrid.Cells.Views.Cell view2 = new SourceGrid.Cells.Views.Cell();
            view2.BackColor = Color.FromArgb(187, 205, 251);
            view2.Font = new Font("Arial", 11, FontStyle.Bold);

            //Selection BorderColor
            SelectionBase Selection = DG.Selection as SelectionBase;
            DevAge.Drawing.RectangleBorder border = Selection.Border;
            border.SetColor(Color.FromArgb(6, 1, 214));
            Selection.Border = border;

            //Selection BackColor
            Selection.BackColor = Color.FromArgb(50, Color.FromArgb(252, 254, 167));

            //Selection BorderWidth
            DevAge.Drawing.RectangleBorder b = Selection.Border;
            b.SetWidth(1);
            Selection.Border = b;

            //Selection FocusBackColor
            Selection.FocusBackColor = Color.FromArgb(50, Color.FromArgb(226, 254, 118));
           
            //Header BackColor
            Color Color2 = Color.FromArgb(243, 243, 243);

            foreach (FBA.GridFBAColumn col in DG.Columns)
            {
                //AlternateColor
                SourceGrid.Conditions.ICondition condition = SourceGrid.Conditions.ConditionBuilder.AlternateView(col.DataCell.View, Color2, Color.Black);            
                col.Conditions.Add(condition);
                
                //Header BackColor
                col.HeaderCell.View = view2;
            }

            DG.ClipboardMode = SourceGrid.ClipboardMode.Copy;
           
            //DG.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize;
            //DG.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            //DG.Columns[0].Width = 20;

            //DG.Columns.AutoSizeView();
            //this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //                        | System.Windows.Forms.AnchorStyles.Left)
            //                        | System.Windows.Forms.AnchorStyles.Right)));

            
            return true;
        }
 */
//===================================================================
//if (filter.GetType().ToString() == "System.String")
//{
//    FilterObj filter = new FilterObj();
//}

//FBA.GridFBA DG;

//var F1 = Task.Factory.StartNew(dd);                      
//((FormFBA)F1.Result).Show();

//System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

//var outer2 = Task.Factory.StartNew(() =>
//{
//RefreshGrid22(Direction, DG, filter, tbStatus);

//});
//===================================================================