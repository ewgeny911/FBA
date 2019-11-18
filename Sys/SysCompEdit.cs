/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 06.03.2018
 * Время: 14:55
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FBA
{	
	/// <summary>
	/// Компонент для выбора атрибута из БД и показа значения на форме.
	/// </summary>
    public partial class EditFBA : UserControl
    {
        private bool wasShow = false;
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        public EditFBA()
        {
            InitializeComponent();                    
            comboBox.DropDown += this.HandleDropDown;
            btnDelete.Click   += this.HandleDeleteClick;
            btnEdit.Click     += this.HandleEditClick;
            btnEdit.Enabled   =  this.Enabled;
            btnDelete.Enabled =  this.Enabled;
            comboBox.Enabled  =  this.Enabled;
        }

        private void EditFBA_Load(object sender, EventArgs e)
        {
            if (wasShow) return; //Для ускорения, чтобы этот конд не проходил повторно,
                                 //при событии Form.Show, если перед этим было сделано Form.Hide.
            this.btnEdit.Anchor   = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox.Anchor = System.Windows.Forms.AnchorStyles.None;

            this.comboBox.Size = new System.Drawing.Size(this.Size.Width - 26 - 26 - 3, 26);
            this.btnDelete.Size = new System.Drawing.Size(26, 26);
            this.btnEdit.Size = new System.Drawing.Size(26, 26);

            this.comboBox.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Location = new System.Drawing.Point(this.Size.Width - 26 - 26 - 1, 0);
            this.btnEdit.Location = new System.Drawing.Point(this.Size.Width - 26, 0);

            GetWidthComboBox1();
            wasShow = true;
        }

        private void GetWidthComboBox1()
        {
            //Для ускорения, чтобы этот конд не проходил повторно,
            //при событии Form.Show, если перед этим было сделано Form.Hide.
        	if (wasShow) return;
                                         
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox.Anchor = System.Windows.Forms.AnchorStyles.None;

            if (this.btnEdit.Visible) this.btnDelete.Left = this.Width - this.btnEdit.Width - this.btnDelete.Width;
            else this.btnDelete.Left = this.Width - this.btnDelete.Width;

            if ((this.btnEdit.Visible) && (this.btnDelete.Visible)) comboBox.Width = this.Width - this.btnEdit.Width - this.btnDelete.Width - 2;
            if ((!this.btnEdit.Visible) && (!this.btnDelete.Visible)) comboBox.Width = this.Width;
            if ((!this.btnEdit.Visible) && (this.btnDelete.Visible)) comboBox.Width = this.Width - btnEdit.Width - 2;
            if ((this.btnEdit.Visible) && (!this.btnDelete.Visible)) comboBox.Width = this.Width - btnDelete.Width - 2;

            this.btnEdit.Anchor   = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right; //System.Windows.Forms.AnchorStyles.Bottom | 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right; // System.Windows.Forms.AnchorStyles.Bottom | 
            this.comboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right; //System.Windows.Forms.AnchorStyles.Bottom |
        }  
                
        private string _EntityBrief = "";
        /// <summary>
        /// Сокращение сущности
        /// </summary>
        [DisplayName("EntityBrief"), Description("Сокращение сущности."), Category("FBA")]
        public string EntityBrief
        {
            get { return _EntityBrief; }
            set { _EntityBrief = value; }
        }

        private string _ObjectID = "";        
        /// <summary>
        /// ИД объекта
        /// </summary>
        [DisplayName("ObjectID"), Description("ИД объекта"), Category("FBA")]
        public string ObjectID
        {
            get { return _ObjectID; }
            set { _ObjectID = value; }
        }

        private string _AttrBrief = "";        
        /// <summary>
        /// Сокращение атрибута
        /// </summary>
        [DisplayName("AttrBrief"), Description("Сокращение атрибута"), Category("FBA")]
        public string AttrBrief
        {
            get { return _AttrBrief; }
            set { _AttrBrief = value; }
        }

        private string _SQL = "";
        /// <summary>
        /// Запрос SQL
        /// </summary>
        [DisplayName("SQL"), Description("Запрос SQL"), Category("FBA")]
        public string SQL
        {
            get { return _SQL; }
            set { _SQL = value; }
        }

        private string _MSQL = "";        
        /// <summary>
        /// Запрос MSQL
        /// </summary>
        [DisplayName("MSQL"), Description("Запрос MSQL"), Category("FBA")]
        public string MSQL
        {
            get { return _MSQL; }
            set { _MSQL = value; }
        }
        
        /// <summary>
        /// Указываем что сохранять свойство Text или SelectedIndex. INDEX, TEXT, LOOKUP.   
        /// </summary>
        [DisplayName("SaveType"), Description("Type of Attribute: INDEX, TEXT, LOOKUP"), Category("FBA")]
        public string SaveType { get; set; }

        /// <summary>
        /// Свойство видимость кнопки Delete
        /// </summary>
        [DisplayName("ButtonDeleteVisible"), Description("Свойство видимость кнопки Delete"), Category("FBA")]
        public bool ButtonDeleteVisible
        {
            get { return this.btnDelete.Visible; }
            set
            {
                this.btnDelete.Visible = value;
                GetWidthComboBox1();
            }
        }

        /// <summary>
        /// Свойство видимость кнопки Edit
        /// </summary>
        [DisplayName("ButtonEditVisible"), Description("Свойство видимость кнопки Edit"), Category("FBA")]
        public bool ButtonEditVisible
        {
            get { return this.btnEdit.Visible; }
            set
            {
                this.btnEdit.Visible = value;
                GetWidthComboBox1();
            }
        }

        /// <summary>
        /// Свойство comboBox.BackColor
        /// </summary>
        [DisplayName("BackColor"), Description("Свойство comboBox.BackColor"), Category("FBA")]
        public override Color BackColor
        {
            get { return comboBox.BackColor; }
            set { comboBox.BackColor = value; }
        }

        /// <summary>
        /// Свойство DockStyle
        /// </summary>
        [DisplayName("DockStyle"), Description("Свойство DockStyle"), Category("FBA")]
        public DockStyle DockStyle
        {
            get { return this.Dock; }
            set { this.Dock = value; }
        }

        /// <summary>
        /// Свойство comboBox.Text
        /// </summary>
        [DisplayName("Text"), Description("Свойство comboBox.Text"), Category("FBA")]
        public override string Text
        {
            get { return comboBox.Text; }
            set { comboBox.Text = value; }
        }

        /// <summary>
        /// Внешнее условие WHERE. Добавляется при получении выпадающего списка.
        /// </summary>
        [DisplayName("OuterWHERE"), Description("Внешнее условие WHERE. Добавляется при получении выпадающего списка"), Category("FBA")]
        public string OuterWHERE { get; set; }

        /// <summary>
        /// Количество объектов для выбора в выпадающий список.
        /// </summary>
        [DisplayName("ObjectMaxCount"), Description("Количество объектов для выбора в выпадающий список."), Category("FBA")]
        public int ObjectMaxCount { get; set; }

        
        private string _ObjectOrderBy = "";
        /// <summary>
        /// Order By, если нужен.
        /// </summary>
        [DisplayName("ObjectOrderBy"), Description("Order By, если нужен."), Category("FBA")]
        public string ObjectOrderBy
        {
            get { return _ObjectOrderBy; }
            set { _ObjectOrderBy = value; }
        }

        private string _СustomQuery = "";
        /// <summary>
        /// Произвольный запрос. Если введен, то используется он. OuterWHERE в этом случае не используется.
        /// </summary>
        [DisplayName("СustomQuery"), Description("Произвольный запрос. Если введен, то используется он. OuterWHERE в этом случае не используется."), Category("FBA")]
        public string СustomQuery
        {
            get { return _СustomQuery; }
            set { _СustomQuery = value; }
        }
        
        /// <summary>
        /// Ссылка на ObjectRef.
        /// </summary>
        [DisplayName("ObjRef"), Description("Ссылка на ObjectRef."), Category("FBA")]
        public ObjectRef ObjRef { get; set; }
        
        /// <summary>
        /// Форма редактирования объекта. Название.
        /// </summary>
        [DisplayName("EditFormName"), Description("Форма редактирования объекта. Название."), Category("FBA")]
        public string EditFormName { get; set; }

        //Конструктор.
        /*public ComboBoxFBA(): base()
        {
            this.MouseDoubleClick += FilterInputText;
            this.KeyPress += ComboBoxKeyPress;
            if (!_ContextMenuEnabled) 
            {
                ContextMenu = new ContextMenu();
                ContextMenuStrip = new ContextMenuStrip();
            }
        }*/

        //Добавляем свойство ReadOnly.
        /*public void ComboBoxKeyPress(object sender, KeyPressEventArgs e)
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
        }*/

        //Перехват вставки текста из буфера обмена.
        /* protected override void WndProc(ref Message m) 
         {                   

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
                     int NumberInt;
                     if (!sys.IsInteger(ClipboardText, out NumberInt)) return;
                 }
                 if (this.FloatOnly)  
                 {
                     if (!sys.IsFloat(ClipboardText)) return;
                 }                 
             }
             base.WndProc(ref m);                            
         } */

        //Ввод списка значений при двойном клике на comboBox полоски фильтра.
        //public void FilterInputText(object sender, MouseEventArgs e)
        //{        
        //    sys.InputListValues(sender);
        //} 
        
        bool _ContextMenuEnabled = true;
        /// <summary>
        /// Если поставить False стандартное контекстное меню перестанет появляться. 
        /// </summary>        
        [DisplayName("ContextMenuEnabled"), Description("If False, the standard context menu will no longer appear."), Category("FBA")]
        public bool ContextMenuEnabled
        {
            get { return _ContextMenuEnabled; }
            set { _ContextMenuEnabled = value; this.Refresh(); }
        }
    
        /// <summary>
        /// Дополнительное поле с текстом. Для разных целей.
        /// </summary>
        [DisplayName("TextAdditional"), Description("Additional text field. For different purposes."), Category("FBA")]
        public string TextAdditional { get; set; }

        /// <summary>
        /// Показывать историю введённых значений.
        /// </summary>
        [DisplayName("ValueHistoryInItems"), Description("Show history of previous values of items"), Category("FBA")]
        public bool ValueHistoryInItems { get; set; }

        //[DisplayName("SaveValueHistory"), Description("Save history of values in local DataBase"), Category("FBA")]
        //public bool SaveValueHistory { get; set; }        
       
		/// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках,
        /// при выполнении команды SysCommon.FormComponentValuesSave/SysCommon.FormComponentValuesLoad. 
        /// </summary>        
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
        
	    /// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента. Работает через Var.controlEnableDisable.   
        /// </summary>         
        [DisplayName("GroupEnabled"),
        Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                    "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }

        /// <summary>
        /// Свойство comboBox1.ReadOnly
        /// </summary>  
        [DisplayName("ReadOnly"), Description(""), Category("FBA")]
        public bool ReadOnly
        {
            get { return comboBox.ReadOnly; }
            set
            {
                comboBox.ReadOnly = value;
                btnDelete.Enabled = !value;
                this.Refresh();
            }
        }

  		/// <summary>
        /// Требуем заполнение компонента значениями. Проверка в SysForm.ErrorIfNull 
        /// </summary>        
        [DisplayName("ErrorIfNull"), Description(""), Category("FBA")]      
        public string ErrorIfNull { get; set; }

        /// <summary>
        /// Свойство comboBox1.MaxDropDownItems.
        /// </summary>
        [DisplayName("MaxDropDownItems"), Description("MaxDropDownItems"), Category("FBA")]
        public int MaxDropDownItems
        {
            get { return comboBox.MaxDropDownItems; }
            set { comboBox.MaxDropDownItems = value; }
        }
     
        /// <summary>
        /// Свойство comboBox1.AutoCompleteMode.
        /// </summary> 
        [DisplayName("AutoCompleteMode"), Description("AutoCompleteMode"), Category("FBA")]
        public System.Windows.Forms.AutoCompleteMode AutoCompleteMode
        {
            get { return comboBox.AutoCompleteMode; }
            set { comboBox.AutoCompleteMode = value; }
        }

        /// <summary>
        /// Свойство comboBox1.AutoCompleteSource.
        /// </summary> 
        [DisplayName("AutoCompleteSource"), Description("AutoCompleteSource"), Category("FBA")]
        public System.Windows.Forms.AutoCompleteSource AutoCompleteSource
        {
            get { return comboBox.AutoCompleteSource; }
            set { comboBox.AutoCompleteSource = value; }
        }

        /// <summary>
        /// Свойство comboBox1.AutoCompleteCustomSource.
        /// </summary> 
        [DisplayName("AutoCompleteCustomSource"), Description("AutoCompleteCustomSource"), Category("FBA")]
        public System.Windows.Forms.AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return comboBox.AutoCompleteCustomSource; }
            set { comboBox.AutoCompleteCustomSource = value; }
        }

        /// <summary>
        /// Свойство comboBox1.DataSource.
        /// </summary>  
        [DisplayName("DataSource"), Description("DataSource"), Category("FBA")]
        public System.Object DataSource
        {
            get { return comboBox.DataSource; }
            set { comboBox.DataSource = value; }
        }

        /// <summary>
        /// Свойство comboBox1.DrawMode.
        /// </summary>        
        [DisplayName("DrawMode"), Description("DrawMode"), Category("FBA")]
        public System.Windows.Forms.DrawMode DrawMode
        {
            get { return comboBox.DrawMode; }
            set { comboBox.DrawMode = value; }
        }

        /// <summary>
        /// Свойство comboBox1.DropDownWidth.
        /// </summary>
        [DisplayName("DropDownWidth"), Description("DropDownWidth"), Category("FBA")]
        public System.Int32 DropDownWidth
        {
            get { return comboBox.DropDownWidth; }
            set { comboBox.DropDownWidth = value; }
        }

        /// <summary>
        /// Свойство comboBox1.DropDownHeight.
        /// </summary>
        [DisplayName("DropDownHeight"), Description("DropDownHeight"), Category("FBA")]
        public System.Int32 DropDownHeight
        {
            get { return comboBox.DropDownHeight; }
            set { comboBox.DropDownHeight = value; }
        }

        /// <summary>
        /// Свойство comboBox1.DroppedDown.
        /// </summary>
        [DisplayName("DroppedDown"), Description("DroppedDown"), Category("FBA")]
        public System.Boolean DroppedDown
        {
            get { return comboBox.DroppedDown; }
            set { comboBox.DroppedDown = value; }
        }

        /// <summary>
        /// Свойство comboBox1.FlatStyle.
        /// </summary>
        [DisplayName("FlatStyle"), Description("FlatStyle"), Category("FBA")]
        public System.Windows.Forms.FlatStyle FlatStyle
        {
            get { return comboBox.FlatStyle; }
            set { comboBox.FlatStyle = value; }
        }

        /// <summary>
        /// Свойство comboBox1.IntegralHeight.
        /// </summary>
        [DisplayName("IntegralHeight"), Description("IntegralHeight"), Category("FBA")]
        public System.Boolean IntegralHeight
        {
            get { return comboBox.IntegralHeight; }
            set { comboBox.IntegralHeight = value; }
        }

        /// <summary>
        /// Свойство comboBox1.ItemHeight.
        /// </summary>
        [DisplayName("ItemHeight"), Description("ItemHeight"), Category("FBA")]
        public System.Int32 ItemHeight
        {
            get { return comboBox.ItemHeight; }
            set { comboBox.ItemHeight = value; }
        }

        /// <summary>
        /// Свойство comboBox1.Items.
        /// </summary>
        [DisplayName("Items"), Description("Items"), Category("FBA")]
        public System.Windows.Forms.ComboBox.ObjectCollection Items
        {
            get { return comboBox.Items; }
        }

        /// <summary>
        /// Свойство comboBox1.MaxLength.
        /// </summary>
        [DisplayName("MaxLength"), Description("MaxLength"), Category("FBA")]
        public System.Int32 MaxLength
        {
            get { return comboBox.MaxLength; }
            set { comboBox.MaxLength = value; }
        }

        /// <summary>
        /// Свойство comboBox1.PreferredHeight.
        /// </summary>
        [DisplayName("PreferredHeight"), Description("PreferredHeight"), Category("FBA")]
        public System.Int32 PreferredHeight
        {
            get { return comboBox.PreferredHeight; }
        }

        /// <summary>
        /// Свойство comboBox1.SelectedIndex.
        /// </summary>
        [DisplayName("Index"), Description("Index"), Category("FBA"), DefaultValue (-1)]
        public System.Int32 Index
        {
            get { return comboBox.SelectedIndex; }
            set { comboBox.SelectedIndex = value; }
        }

        /// <summary>
        /// Свойство comboBox1.SelectedItem.
        /// </summary>
        [DisplayName("SelectedItem"), Description("SelectedItem"), Category("FBA")]
        public System.Object SelectedItem
        {
            get { return comboBox.SelectedItem; }
            set { comboBox.SelectedItem = value; }
        }

        /// <summary>
        /// Свойство comboBox1.SelectedText.
        /// </summary>
        [DisplayName("SelectedText"), Description("SelectedText"), Category("FBA")]
        public System.String SelectedText
        {
            get { return comboBox.SelectedText; }
            set { comboBox.SelectedText = value; }
        }

        /// <summary>
        /// Свойство comboBox1.SelectionLength.
        /// </summary>
        [DisplayName("SelectionLength"), Description("SelectionLength"), Category("FBA")]
        public System.Int32 SelectionLength
        {
            get { return comboBox.SelectionLength; }
            set { comboBox.SelectionLength = value; }
        }

        /// <summary>
        /// Свойство comboBox1.SelectionStart.
        /// </summary>
        [DisplayName("SelectionStart"), Description("SelectionStart"), Category("FBA")]
        public System.Int32 SelectionStart
        {
            get { return comboBox.SelectionStart; }
            set { comboBox.SelectionStart = value; }
        }

        /// <summary>
        /// Свойство comboBox1.Sorted.
        /// </summary>
        [DisplayName("Sorted"), Description("Sorted"), Category("FBA")]
        public System.Boolean Sorted
        {
            get { return comboBox.Sorted; }
            set { comboBox.Sorted = value; }
        }

        /// <summary>
        /// Свойство comboBox1.DropDownStyle.
        /// </summary>
        [DisplayName("DropDownStyle"), Description("DropDownStyle"), Category("FBA")]
        public System.Windows.Forms.ComboBoxStyle DropDownStyle
        {
            get { return comboBox.DropDownStyle; }
            set { comboBox.DropDownStyle = value; }
        }

        /// <summary>
        /// Свойство comboBox1.DisplayMember.
        /// </summary>
        [DisplayName("DisplayMember"), Description("DisplayMember"), Category("FBA")]
        public System.String DisplayMember
        {
            get { return comboBox.DisplayMember; }
            set { comboBox.DisplayMember = value; }
        }

        /// <summary>
        /// Свойство comboBox1.FormatInfo.
        /// </summary>
        [DisplayName("FormatInfo"), Description("FormatInfo"), Category("FBA")]
        public System.IFormatProvider FormatInfo
        {
            get { return comboBox.FormatInfo; }
            set { comboBox.FormatInfo = value; }
        }

        /// <summary>
        /// Свойство comboBox1.FormatString.
        /// </summary>
        [DisplayName("FormatString"), Description("FormatString"), Category("FBA")]
        public System.String FormatString
        {
            get { return comboBox.FormatString; }
            set { comboBox.FormatString = value; }
        }

        /// <summary>
        /// Свойство comboBox1.FormattingEnabled.
        /// </summary>
        [DisplayName("FormattingEnabled"), Description("FormattingEnabled"), Category("FBA")]
        public System.Boolean FormattingEnabled
        {
            get { return comboBox.FormattingEnabled; }
            set { comboBox.FormattingEnabled = value; }
        }

        /// <summary>
        /// Свойство comboBox1.ValueMember.
        /// </summary>
        [DisplayName("ValueMember"), Description("ValueMember"), Category("FBA")]
        public System.String ValueMember
        {
            get { return comboBox.ValueMember; }
            set { comboBox.ValueMember = value; }
        }

        /// <summary>
        /// Свойство comboBox1.SelectedValue.
        /// </summary>
        [DisplayName("SelectedValue"), Description("SelectedValue"), Category("FBA")]
        public System.Object SelectedValue
        {
            get { return comboBox.SelectedValue; }
            set { comboBox.SelectedValue = value; }
        }

        //============================================================================
        //События
        //============================================================================
        #region Region. Cобытие DropDown.
      
        /// <summary>
        /// Cобытие DropDown.
        /// </summary>
        [DisplayName("DropDown"), Description("DropDown"), Category("FBA")]
        public event EventHandler DropDown;
		
		/// <summary>
		/// Cобытие DropDown.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void HandleDropDown(object sender, EventArgs e)
        {
            LoadDataDropDown();  //Загрузка данных.
            this.OnDropDown(e);  //EventArgs.Empty - Пользовательское собыие вызываем после загрузки данных.
        }
     
        /// <summary>
        /// Cобытие DropDown. 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDropDown(EventArgs e)
        {
            EventHandler handler = this.DropDown;
            if (handler != null)
            {
                handler(this, e);
            }
            //this.DropDown?.Invoke(this, e);      
        }

        private bool GetLookupSQL(out string sql)
        {
            sql = "";
            if (!sys.IsEmpty(СustomQuery)) sql = СustomQuery;
            else if (ObjRef != null) sql = ObjRef.GetSelectSQLForEditFBA(this);
            else
            {
                if ((!sys.IsEmpty(EntityBrief)) && (!sys.IsEmpty(AttrBrief)))
                {
                    string queryName;
                    string attr;
                    string attrLookup;
                    string setting;
                    sys.ParseTag(AttrBrief, out queryName, out attr, out attrLookup, out setting);                                                       
                    string maxRecords1 = "";
                    string maxRecords2 = "";
                    if (ObjectMaxCount > 0)
					{
						if (Var.con.serverTypeRemote == ServerType.MSSQL) 
							maxRecords1 = " TOP " + ObjectMaxCount.ToString();	          
						if ((Var.con.serverTypeRemote == ServerType.SQLite) || (Var.con.serverTypeRemote == ServerType.Postgre))	             
			            	maxRecords2 = Var.CR + " LIMIT " + ObjectMaxCount.ToString();	           
					} 				     	
                    sql = "SELECT " + maxRecords1  + " " + attrLookup + " FROM " + EntityBrief;                                                          
                    if (!sys.IsEmpty(OuterWHERE)) sql = sql + " WHERE " + OuterWHERE;
                    sql = sql + maxRecords2;
                    if (!sys.IsEmpty(ObjectOrderBy)) sql = sql + " ORDER BY " + ObjectOrderBy;
                }
            }
            if (sql == "") return false;
            return true;
        }
    
        /// <summary>
        /// Загрузка данных в компонент.
        /// </summary>
        public void LoadDataDropDown()
        {
            string sql;
            if (!GetLookupSQL(out sql)) return;
            sys.SelectComboBox(DirectionQuery.Remote, sql, comboBox);
        }

        #endregion Region. Cобытие DropDown.

        #region Region. Cобытие Нажатия на кнопку удалить.
                
        /// <summary>
        /// Cобытие DeleteClick.
        /// </summary>
        [DisplayName("DeleteClick"), Description("Cобытие DeleteClick."), Category("FBA")]
        public event EventHandler DeleteClick;

		/// <summary>
		/// Cобытие DeleteClick.  
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void HandleDeleteClick(object sender, EventArgs e)
        {
            if (ObjRef != null)
            {
                comboBox.Text = "";
                this.ObjectID = "NULL";
                ObjRef[AttrBrief] = "NULL";
            }
            //Cобытие DeleteClick. 
            EventHandler handler = this.DeleteClick;
            if (handler != null)
            {
                handler(this, e);  //Пользовательское событие показа формы справочника.
            }
        }

        #endregion Region. Cобытие Нажатия на кнопку удалить.

        #region Region. Cобытие Нажатия на кнопку - показать форму выбора.
        
        /// <summary>
        /// Cобытие EditClick.
        /// </summary>
        [DisplayName("EditClick"), Description("Cобытие EditClick."), Category("FBA")]
        public event EventHandler EditClick;

		/// <summary>
		/// Cобытие EditClick.  
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void HandleEditClick(object sender, EventArgs e)
        {
            if (sys.IsEmpty(EditFormName))
            {
                if (ObjRef != null)
                {
                    string EntityBriefLocal;
                    string EntityBriefLink;
                    string NeedAttr;
                    if (!ObjRef.GetLinkEntityBrief(AttrBrief, out EntityBriefLocal, out EntityBriefLink, out NeedAttr)) return;
                    if (EntityBriefLink == "") return;
                    if (NeedAttr == "") return;

                    var Params = new DirectoryParams();
                    Params.EntityBrief = EntityBriefLink;
                    Params.ObjectID = ObjectID;
                    Params.Multiselect = false;                    
                    Params.showMode = ShowMode.ExecMSQL;
                    Params.OuterWHERE = OuterWHERE;
                    Params.СustomMSQLQuery = СustomQuery;
                    Params.ReturnAttrBrief = NeedAttr;
                    //EntityBriefLink, ObjectID, false, true, "Exec", OuterWHERE, СustomQuery, NeedAttr
                    //var F = new FormDirectory(EntityBriefLink, ObjectID, false, true, "Exec", OuterWHERE, СustomQuery, NeedAttr);
                    var F = new FormDirectory(EntityBriefLink, ref Params);
                    if (!F.FilterSet) return;                  
                    F.ShowDialog();
                    if (Params.ReturnObjectID != "")
                    {
                        //Форма закрылась по кнопке Ок.
                        this.ObjectID = Params.ReturnObjectID;
                        if (Params.ReturnAttrValue == "")
                        {
                            string msqlLocal = "SELECT " + NeedAttr + " FROM " + EntityBriefLink + " WHERE " + ParserData.KeyBrief.ObjectID + " = " + Params.ReturnObjectID;
                            string sqlLocal = sys.Parse(msqlLocal);
                            this.Text = sys.GetValue(DirectionQuery.Remote, sqlLocal);
                        }
                        else this.Text = Params.ReturnAttrValue;
                    }
                }
            }
            this.OnEditClick(e); //Пользовательское событие показа формы справочника.
        }       
     
        /// <summary>
        /// Cобытие EditClick. 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEditClick(EventArgs e)
        {
            EventHandler handler = this.EditClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Region. Cобытие Нажатия на кнопку - показать форму выбора.      
        
        /// <summary>
        /// Событие происходит при закрытии выпадающего списка, после выбоар пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //comboBox1.SelectedValue
            //object ob = comboBox1.SelectedItem;
            //sys.SM(ob.ToString());
            //(System.Data.DataRowView)ob
            //ob.GetType()comboBox1.Text
            //System.Data.DataRowView
            //((System.Data.DataTable)comboBox1.DataSource).
            //sys.SM(comboBox1.SelectedValue.ToString());
            if (comboBox.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (ObjRef != null)
            {
                this.ObjectID = comboBox.SelectedValue.ToString();
                ObjRef[AttrBrief] = comboBox.SelectedValue.ToString();
            }
        }

        //Cобытие до выбора.
        /*[DisplayName("BeforeValueAdd"), Description("BeforeValueAdd"), Category("FBA")]       
        public event EventHandler BeforeValueAdd;
        
        ///Cобытие до выбора.
        [DisplayName("BeforeValueAdd"), Description("BeforeValueAdd"), Category("FBA")]           
        protected virtual void OnBeforeValueAdd(EventArgs e)
        {            
            if (this.BeforeValueAdd != null) this.BeforeValueAdd(this, e);             
        }       
        
        ///Cобытие после выбора.
        [DisplayName("AfterValueAdd"), Description("AfterValueAdd"), Category("FBA")]       
        public event EventHandler AfterValueAdd;
        
        ///Cобытие после выбора.
        [DisplayName("BeforeValueAdd"), Description("AfterValueAdd"), Category("FBA")]           
        protected virtual void OnAfterValueAdd(EventArgs e)
        {            
            if (this.AfterValueAdd != null) this.AfterValueAdd(this, e);        
        }              
        
        private void ValueAddMethod(object sender, EventArgs e)
        {           
            this.OnBeforeValueAdd(EventArgs.Empty);
            ShowFormAdd();
            this.OnAfterValueAdd(EventArgs.Empty);
        }
          
        public void ShowFormAdd()
        {
            sys.SM("Add");
        }*/

        //void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //  
        //}

        //Cобытие очистки.
        //[DisplayName("ValueDel"), Description("ValueDel"), Category("FBA")]       
        //public event EventHandler ValueDel;

        //Cобытие очистки.
        //[DisplayName("ValueProp"), Description("ValueProp"), Category("FBA")]       
        //public event EventHandler ValueProp;

        //((TextBox)cb2).BorderStyle = System.Windows.Forms.BorderStyle.None;
        
             //благодаря этому коду форма при измениии размеров перерисовывается значительно быстрее. Взято отсюда:
        //https://social.msdn.microsoft.com/Forums/windows/en-US/c27693d2-9b4e-4395-9e90-402a6af96307/splitcontainer-flickering-issue-while-resizing-it?forum=winforms
        //protected override CreateParams CreateParams       
        //{       
        //    get           
        //    {       
        //        CreateParams cp = base.CreateParams;           
        //        cp.ExStyle |= 0x02000000;           
        //        return cp;       
        //    }       
        //}             

        //============================================================================
        //Свойства
        //============================================================================
        			
        //this.AutoSize = false;
		//btnLookup.Click += this.ValueAddMethod;
        //Dock = DockStyle.Fill;  
        //this.btnDelete.Height = 26; // Size = new System.Drawing.Size(22, 26);
        //this.btnEdit.Height = 26; // Size   = new System.Drawing.Size(22, 26);
  		//this.Width = 327 
        //btnEditWidth = 35
        //comboBox1.Width = 365 

		   //AutoCompleteMode,
        //AutoCompleteSource,
        //AutoCompleteCustomSource,
        //BackColor,
        //BackgroundImage,
        //BackgroundImageLayout,DataSource,DrawMode,DropDownWidth,DropDownHeight,DroppedDown,FlatStyle,Focused,ForeColor,IntegralHeight,ItemHeight,Items,MaxDropDownItems,MaximumSize,MinimumSize,MaxLength,Padding,PreferredHeight,SelectedIndex,SelectedItem,SelectedText,SelectionLength,SelectionStart,Sorted,DropDownStyle,Text,DisplayMember,FormatInfo,FormatString,FormattingEnabled,ValueMember,SelectedValue,AccessibilityObject,AccessibleDefaultActionDescription,AccessibleDescription,AccessibleName,AccessibleRole,AllowDrop,Anchor,AutoSize,AutoScrollOffset,LayoutEngine,BindingContext,Bottom,Bounds,CanFocus,CanSelect,Capture,CausesValidation,ClientRectangle,ClientSize,CompanyName,ContainsFocus,ContextMenu,ContextMenuStrip,Controls,Created,Cursor,DataBindings,DeviceDpi,DisplayRectangle,IsDisposed,Disposing,Dock,Enabled,Font,Handle,HasChildren,Height,IsHandleCreated,InvokeRequired,IsAccessible,IsMirrored,Left,Location,Margin,Name,Parent,ProductName,ProductVersion,RecreatingHandle,Region,Right,RightToLeft,Site,Size,TabIndex,TabStop,Tag,Top,TopLevelControl,UseWaitCursor,Visible,Width,WindowTarget,PreferredSize,ImeMode,Container
        
        
    }
}
