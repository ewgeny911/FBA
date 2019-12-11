/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 04.02.2018
 * Время: 23:20
 */
 
namespace FBA
{
    partial class FormContract
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private FBA.LabelFBA label3;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
               
        private void InitializeComponent()
        {
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.button1 = new System.Windows.Forms.Button();
        	this.label1 = new FBA.LabelFBA();
        	this.textBoxFBA5 = new FBA.TextBoxFBA();
        	this.label23 = new FBA.LabelFBA();
        	this.EditFBA9 = new FBA.EditFBA();
        	this.EditFBA7 = new FBA.EditFBA();
        	this.label10 = new FBA.LabelFBA();
        	this.EditFBA5 = new FBA.EditFBA();
        	this.dateTimePickerFBA4 = new FBA.DateTimePickerFBA();
        	this.labelFBA1 = new FBA.LabelFBA();
        	this.label7 = new FBA.LabelFBA();
        	this.dateTimePickerFBA3 = new FBA.DateTimePickerFBA();
        	this.label5 = new FBA.LabelFBA();
        	this.textBoxFBA1 = new FBA.TextBoxFBA();
        	this.btnSave = new System.Windows.Forms.Button();
        	this.label3 = new FBA.LabelFBA();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.textBoxFBA4 = new FBA.TextBoxFBA();
        	this.tabControl1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Controls.Add(this.tabPage2);
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabControl1.Location = new System.Drawing.Point(0, 0);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(597, 269);
        	this.tabControl1.TabIndex = 0;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
        	this.tabPage1.Controls.Add(this.button1);
        	this.tabPage1.Controls.Add(this.label1);
        	this.tabPage1.Controls.Add(this.textBoxFBA5);
        	this.tabPage1.Controls.Add(this.label23);
        	this.tabPage1.Controls.Add(this.EditFBA9);
        	this.tabPage1.Controls.Add(this.EditFBA7);
        	this.tabPage1.Controls.Add(this.label10);
        	this.tabPage1.Controls.Add(this.EditFBA5);
        	this.tabPage1.Controls.Add(this.dateTimePickerFBA4);
        	this.tabPage1.Controls.Add(this.labelFBA1);
        	this.tabPage1.Controls.Add(this.label7);
        	this.tabPage1.Controls.Add(this.dateTimePickerFBA3);
        	this.tabPage1.Controls.Add(this.label5);
        	this.tabPage1.Controls.Add(this.textBoxFBA1);
        	this.tabPage1.Controls.Add(this.btnSave);
        	this.tabPage1.Controls.Add(this.label3);
        	this.tabPage1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabPage1.Location = new System.Drawing.Point(4, 26);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(589, 239);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Property";
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(92, 208);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(75, 23);
        	this.button1.TabIndex = 75;
        	this.button1.Text = "button1";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// label1
        	// 
        	this.label1.Location = new System.Drawing.Point(14, 123);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(122, 25);
        	this.label1.StarColor = System.Drawing.Color.Crimson;
        	this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label1.StarOffsetX = 2;
        	this.label1.StarOffsetY = 0;
        	this.label1.StarShow = true;
        	this.label1.StarText = "*";
        	this.label1.TabIndex = 74;
        	this.label1.Text = "Document Type";
        	// 
        	// textBoxFBA5
        	// 
        	this.textBoxFBA5.AttrBrief = "Main1.ObjectID";
        	this.textBoxFBA5.AttrBriefLookup = null;
        	this.textBoxFBA5.BackColor = System.Drawing.SystemColors.Info;
        	this.textBoxFBA5.DefaultTextGray = null;
        	this.textBoxFBA5.DefaultTextGrayColor = System.Drawing.Color.Gray;
        	this.textBoxFBA5.ErrorIfNull = null;
        	this.textBoxFBA5.GroupEnabled = null;
        	this.textBoxFBA5.ListInvalidChars = null;
        	this.textBoxFBA5.ListValidChars = null;
        	this.textBoxFBA5.Location = new System.Drawing.Point(160, 13);
        	this.textBoxFBA5.Name = "textBoxFBA5";
        	this.textBoxFBA5.ObjectRef = null;
        	this.textBoxFBA5.RegExChars = null;
        	this.textBoxFBA5.SaveParam = false;
        	this.textBoxFBA5.SaveValueHistory = false;
        	this.textBoxFBA5.Size = new System.Drawing.Size(142, 25);
        	this.textBoxFBA5.TabIndex = 73;
        	this.textBoxFBA5.Text2 = null;
        	this.textBoxFBA5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxFBA5KeyDown);
        	// 
        	// label23
        	// 
        	this.label23.Location = new System.Drawing.Point(8, 11);
        	this.label23.Name = "label23";
        	this.label23.Size = new System.Drawing.Size(119, 19);
        	this.label23.StarColor = System.Drawing.Color.Crimson;
        	this.label23.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label23.StarOffsetX = 2;
        	this.label23.StarOffsetY = 0;
        	this.label23.StarShow = false;
        	this.label23.StarText = "*";
        	this.label23.TabIndex = 72;
        	this.label23.Text = "ID";
        	// 
        	// EditFBA9
        	// 
        	this.EditFBA9.AttrBrief = "Main1.Контрагент.Name";
        	this.EditFBA9.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        	this.EditFBA9.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        	this.EditFBA9.ButtonDeleteVisible = true;
        	this.EditFBA9.ButtonEditVisible = true;
        	this.EditFBA9.ContextMenuEnabled = true;
        	this.EditFBA9.DataSource = null;
        	this.EditFBA9.DisplayMember = "";
        	this.EditFBA9.DockStyle = System.Windows.Forms.DockStyle.None;
        	this.EditFBA9.DrawMode = System.Windows.Forms.DrawMode.Normal;
        	this.EditFBA9.DropDownHeight = 106;
        	this.EditFBA9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        	this.EditFBA9.DropDownWidth = 315;
        	this.EditFBA9.DroppedDown = false;
        	this.EditFBA9.EditFormName = null;
        	this.EditFBA9.EntityBrief = "";
        	this.EditFBA9.ErrorIfNull = null;
        	this.EditFBA9.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        	this.EditFBA9.FormatInfo = null;
        	this.EditFBA9.FormatString = "";
        	this.EditFBA9.FormattingEnabled = true;
        	this.EditFBA9.GroupEnabled = null;
        	this.EditFBA9.IntegralHeight = true;
        	this.EditFBA9.ItemHeight = 18;
        	this.EditFBA9.Location = new System.Drawing.Point(160, 93);
        	this.EditFBA9.Margin = new System.Windows.Forms.Padding(16);
        	this.EditFBA9.MaxDropDownItems = 50;
        	this.EditFBA9.MaxLength = 0;
        	this.EditFBA9.MSQL = "";
        	this.EditFBA9.Name = "EditFBA9";
        	this.EditFBA9.ObjectID = null;
        	this.EditFBA9.ObjectMaxCount = 50;
        	this.EditFBA9.ObjectOrderBy = null;
        	this.EditFBA9.ObjRef = null;
        	this.EditFBA9.OuterWHERE = null;
        	this.EditFBA9.ReadOnly = false;
        	this.EditFBA9.SaveParam = false;
        	this.EditFBA9.SaveType = null;
        	this.EditFBA9.SelectedItem = null;
        	this.EditFBA9.SelectedText = "";
        	this.EditFBA9.SelectedValue = null;
        	this.EditFBA9.SelectionLength = 0;
        	this.EditFBA9.SelectionStart = 0;
        	this.EditFBA9.Size = new System.Drawing.Size(417, 26);
        	this.EditFBA9.Sorted = false;
        	this.EditFBA9.SQL = "";
        	this.EditFBA9.TabIndex = 47;
        	this.EditFBA9.TextAdditional = null;
        	this.EditFBA9.ValueHistoryInItems = false;
        	this.EditFBA9.ValueMember = "";
        	this.EditFBA9.СustomQuery = null;
        	// 
        	// EditFBA7
        	// 
        	this.EditFBA7.AttrBrief = "Main1.ТипДокумента.Name";
        	this.EditFBA7.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        	this.EditFBA7.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        	this.EditFBA7.ButtonDeleteVisible = true;
        	this.EditFBA7.ButtonEditVisible = true;
        	this.EditFBA7.ContextMenuEnabled = true;
        	this.EditFBA7.DataSource = null;
        	this.EditFBA7.DisplayMember = "";
        	this.EditFBA7.DockStyle = System.Windows.Forms.DockStyle.None;
        	this.EditFBA7.DrawMode = System.Windows.Forms.DrawMode.Normal;
        	this.EditFBA7.DropDownHeight = 106;
        	this.EditFBA7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        	this.EditFBA7.DropDownWidth = 315;
        	this.EditFBA7.DroppedDown = false;
        	this.EditFBA7.EditFormName = null;
        	this.EditFBA7.EntityBrief = "";
        	this.EditFBA7.ErrorIfNull = null;
        	this.EditFBA7.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        	this.EditFBA7.FormatInfo = null;
        	this.EditFBA7.FormatString = "";
        	this.EditFBA7.FormattingEnabled = true;
        	this.EditFBA7.GroupEnabled = null;
        	this.EditFBA7.IntegralHeight = true;
        	this.EditFBA7.ItemHeight = 18;
        	this.EditFBA7.Location = new System.Drawing.Point(160, 122);
        	this.EditFBA7.Margin = new System.Windows.Forms.Padding(16);
        	this.EditFBA7.MaxDropDownItems = 50;
        	this.EditFBA7.MaxLength = 0;
        	this.EditFBA7.MSQL = "";
        	this.EditFBA7.Name = "EditFBA7";
        	this.EditFBA7.ObjectID = null;
        	this.EditFBA7.ObjectMaxCount = 5;
        	this.EditFBA7.ObjectOrderBy = null;
        	this.EditFBA7.ObjRef = null;
        	this.EditFBA7.OuterWHERE = null;
        	this.EditFBA7.ReadOnly = false;
        	this.EditFBA7.SaveParam = false;
        	this.EditFBA7.SaveType = null;
        	this.EditFBA7.SelectedItem = null;
        	this.EditFBA7.SelectedText = "";
        	this.EditFBA7.SelectedValue = null;
        	this.EditFBA7.SelectionLength = 0;
        	this.EditFBA7.SelectionStart = 0;
        	this.EditFBA7.Size = new System.Drawing.Size(417, 26);
        	this.EditFBA7.Sorted = false;
        	this.EditFBA7.SQL = "";
        	this.EditFBA7.TabIndex = 43;
        	this.EditFBA7.TextAdditional = null;
        	this.EditFBA7.ValueHistoryInItems = false;
        	this.EditFBA7.ValueMember = "";
        	this.EditFBA7.СustomQuery = null;
        	// 
        	// label10
        	// 
        	this.label10.Location = new System.Drawing.Point(14, 153);
        	this.label10.Name = "label10";
        	this.label10.Size = new System.Drawing.Size(119, 21);
        	this.label10.StarColor = System.Drawing.Color.Crimson;
        	this.label10.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label10.StarOffsetX = 2;
        	this.label10.StarOffsetY = 0;
        	this.label10.StarShow = true;
        	this.label10.StarText = "*";
        	this.label10.TabIndex = 42;
        	this.label10.Text = "Filial";
        	// 
        	// EditFBA5
        	// 
        	this.EditFBA5.AttrBrief = "Main1.Филиал.Name";
        	this.EditFBA5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        	this.EditFBA5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        	this.EditFBA5.ButtonDeleteVisible = true;
        	this.EditFBA5.ButtonEditVisible = true;
        	this.EditFBA5.ContextMenuEnabled = true;
        	this.EditFBA5.DataSource = null;
        	this.EditFBA5.DisplayMember = "";
        	this.EditFBA5.DockStyle = System.Windows.Forms.DockStyle.None;
        	this.EditFBA5.DrawMode = System.Windows.Forms.DrawMode.Normal;
        	this.EditFBA5.DropDownHeight = 106;
        	this.EditFBA5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        	this.EditFBA5.DropDownWidth = 315;
        	this.EditFBA5.DroppedDown = false;
        	this.EditFBA5.EditFormName = null;
        	this.EditFBA5.EntityBrief = "";
        	this.EditFBA5.ErrorIfNull = null;
        	this.EditFBA5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        	this.EditFBA5.FormatInfo = null;
        	this.EditFBA5.FormatString = "";
        	this.EditFBA5.FormattingEnabled = true;
        	this.EditFBA5.GroupEnabled = null;
        	this.EditFBA5.IntegralHeight = true;
        	this.EditFBA5.ItemHeight = 18;
        	this.EditFBA5.Location = new System.Drawing.Point(160, 152);
        	this.EditFBA5.Margin = new System.Windows.Forms.Padding(9);
        	this.EditFBA5.MaxDropDownItems = 50;
        	this.EditFBA5.MaxLength = 0;
        	this.EditFBA5.MSQL = "";
        	this.EditFBA5.Name = "EditFBA5";
        	this.EditFBA5.ObjectID = null;
        	this.EditFBA5.ObjectMaxCount = 5;
        	this.EditFBA5.ObjectOrderBy = null;
        	this.EditFBA5.ObjRef = null;
        	this.EditFBA5.OuterWHERE = null;
        	this.EditFBA5.ReadOnly = false;
        	this.EditFBA5.SaveParam = false;
        	this.EditFBA5.SaveType = null;
        	this.EditFBA5.SelectedItem = null;
        	this.EditFBA5.SelectedText = "";
        	this.EditFBA5.SelectedValue = null;
        	this.EditFBA5.SelectionLength = 0;
        	this.EditFBA5.SelectionStart = 0;
        	this.EditFBA5.Size = new System.Drawing.Size(417, 26);
        	this.EditFBA5.Sorted = false;
        	this.EditFBA5.SQL = "";
        	this.EditFBA5.TabIndex = 39;
        	this.EditFBA5.TextAdditional = null;
        	this.EditFBA5.ValueHistoryInItems = false;
        	this.EditFBA5.ValueMember = "";
        	this.EditFBA5.СustomQuery = null;
        	// 
        	// dateTimePickerFBA4
        	// 
        	this.dateTimePickerFBA4.AttrBrief = "Main1.DateEnd";
        	this.dateTimePickerFBA4.AttrBriefLookup = null;
        	this.dateTimePickerFBA4.CalendarMonthBackground = System.Drawing.SystemColors.Info;
        	this.dateTimePickerFBA4.CustomFormat = "dd.MM.yyyy";
        	this.dateTimePickerFBA4.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
        	this.dateTimePickerFBA4.ErrorIfNull = null;
        	this.dateTimePickerFBA4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.dateTimePickerFBA4.GroupEnabled = null;
        	this.dateTimePickerFBA4.Location = new System.Drawing.Point(443, 40);
        	this.dateTimePickerFBA4.MaxDate = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
        	this.dateTimePickerFBA4.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        	this.dateTimePickerFBA4.Name = "dateTimePickerFBA4";
        	this.dateTimePickerFBA4.ObjectRef = null;
        	this.dateTimePickerFBA4.SaveParam = false;
        	this.dateTimePickerFBA4.SaveValueHistory = false;
        	this.dateTimePickerFBA4.Size = new System.Drawing.Size(134, 25);
        	this.dateTimePickerFBA4.TabIndex = 35;
        	this.dateTimePickerFBA4.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        	// 
        	// labelFBA1
        	// 
        	this.labelFBA1.Location = new System.Drawing.Point(338, 13);
        	this.labelFBA1.Name = "labelFBA1";
        	this.labelFBA1.Size = new System.Drawing.Size(87, 21);
        	this.labelFBA1.StarColor = System.Drawing.Color.Crimson;
        	this.labelFBA1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.labelFBA1.StarOffsetX = 2;
        	this.labelFBA1.StarOffsetY = 0;
        	this.labelFBA1.StarShow = false;
        	this.labelFBA1.StarText = "*";
        	this.labelFBA1.TabIndex = 34;
        	this.labelFBA1.Text = "Date start";
        	// 
        	// label7
        	// 
        	this.label7.Location = new System.Drawing.Point(338, 40);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(122, 25);
        	this.label7.StarColor = System.Drawing.Color.Crimson;
        	this.label7.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label7.StarOffsetX = 2;
        	this.label7.StarOffsetY = 0;
        	this.label7.StarShow = false;
        	this.label7.StarText = "*";
        	this.label7.TabIndex = 33;
        	this.label7.Text = "Date end";
        	// 
        	// dateTimePickerFBA3
        	// 
        	this.dateTimePickerFBA3.AttrBrief = "Main1.DateStart";
        	this.dateTimePickerFBA3.AttrBriefLookup = null;
        	this.dateTimePickerFBA3.CalendarMonthBackground = System.Drawing.SystemColors.Info;
        	this.dateTimePickerFBA3.CustomFormat = "dd.MM.yyyy";
        	this.dateTimePickerFBA3.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
        	this.dateTimePickerFBA3.ErrorIfNull = null;
        	this.dateTimePickerFBA3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.dateTimePickerFBA3.GroupEnabled = null;
        	this.dateTimePickerFBA3.Location = new System.Drawing.Point(443, 12);
        	this.dateTimePickerFBA3.MaxDate = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
        	this.dateTimePickerFBA3.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        	this.dateTimePickerFBA3.Name = "dateTimePickerFBA3";
        	this.dateTimePickerFBA3.ObjectRef = null;
        	this.dateTimePickerFBA3.SaveParam = false;
        	this.dateTimePickerFBA3.SaveValueHistory = false;
        	this.dateTimePickerFBA3.Size = new System.Drawing.Size(134, 25);
        	this.dateTimePickerFBA3.TabIndex = 32;
        	this.dateTimePickerFBA3.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        	// 
        	// label5
        	// 
        	this.label5.Location = new System.Drawing.Point(14, 93);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(122, 25);
        	this.label5.StarColor = System.Drawing.Color.Crimson;
        	this.label5.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label5.StarOffsetX = 2;
        	this.label5.StarOffsetY = 0;
        	this.label5.StarShow = true;
        	this.label5.StarText = "*";
        	this.label5.TabIndex = 19;
        	this.label5.Text = "Contractor";
        	// 
        	// textBoxFBA1
        	// 
        	this.textBoxFBA1.AttrBrief = "Main1.Number";
        	this.textBoxFBA1.AttrBriefLookup = null;
        	this.textBoxFBA1.BackColor = System.Drawing.SystemColors.Info;
        	this.textBoxFBA1.DefaultTextGray = null;
        	this.textBoxFBA1.DefaultTextGrayColor = System.Drawing.Color.Gray;
        	this.textBoxFBA1.ErrorIfNull = null;
        	this.textBoxFBA1.GroupEnabled = null;
        	this.textBoxFBA1.ListInvalidChars = null;
        	this.textBoxFBA1.ListValidChars = null;
        	this.textBoxFBA1.Location = new System.Drawing.Point(160, 45);
        	this.textBoxFBA1.Name = "textBoxFBA1";
        	this.textBoxFBA1.ObjectRef = null;
        	this.textBoxFBA1.RegExChars = null;
        	this.textBoxFBA1.SaveParam = false;
        	this.textBoxFBA1.SaveValueHistory = false;
        	this.textBoxFBA1.Size = new System.Drawing.Size(142, 25);
        	this.textBoxFBA1.TabIndex = 18;
        	this.textBoxFBA1.Text2 = null;
        	// 
        	// btnSave
        	// 
        	this.btnSave.Location = new System.Drawing.Point(492, 189);
        	this.btnSave.Margin = new System.Windows.Forms.Padding(2);
        	this.btnSave.Name = "btnSave";
        	this.btnSave.Size = new System.Drawing.Size(85, 33);
        	this.btnSave.TabIndex = 6;
        	this.btnSave.Text = "Save";
        	this.btnSave.UseVisualStyleBackColor = true;
        	this.btnSave.Click += new System.EventHandler(this.Button1_Click);
        	// 
        	// label3
        	// 
        	this.label3.Location = new System.Drawing.Point(8, 40);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(78, 19);
        	this.label3.StarColor = System.Drawing.Color.Crimson;
        	this.label3.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label3.StarOffsetX = 2;
        	this.label3.StarOffsetY = 0;
        	this.label3.StarShow = true;
        	this.label3.StarText = "*";
        	this.label3.TabIndex = 3;
        	this.label3.Text = "Number";
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.textBoxFBA4);
        	this.tabPage2.Location = new System.Drawing.Point(4, 26);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(589, 239);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "Comment";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// textBoxFBA4
        	// 
        	this.textBoxFBA4.AttrBrief = "Main1.Comment";
        	this.textBoxFBA4.AttrBriefLookup = null;
        	this.textBoxFBA4.DefaultTextGray = null;
        	this.textBoxFBA4.DefaultTextGrayColor = System.Drawing.Color.Gray;
        	this.textBoxFBA4.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBoxFBA4.ErrorIfNull = null;
        	this.textBoxFBA4.GroupEnabled = null;
        	this.textBoxFBA4.ListInvalidChars = null;
        	this.textBoxFBA4.ListValidChars = null;
        	this.textBoxFBA4.Location = new System.Drawing.Point(3, 3);
        	this.textBoxFBA4.Multiline = true;
        	this.textBoxFBA4.Name = "textBoxFBA4";
        	this.textBoxFBA4.ObjectRef = null;
        	this.textBoxFBA4.RegExChars = null;
        	this.textBoxFBA4.SaveParam = false;
        	this.textBoxFBA4.SaveValueHistory = false;
        	this.textBoxFBA4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBoxFBA4.Size = new System.Drawing.Size(583, 233);
        	this.textBoxFBA4.TabIndex = 0;
        	this.textBoxFBA4.Text2 = null;
        	this.textBoxFBA4.WordWrap = false;
        	// 
        	// FormContract
        	// 
        	this.ClientSize = new System.Drawing.Size(597, 269);
        	this.Controls.Add(this.tabControl1);
        	this.DoubleBuffered = true;
        	this.FormSavePosition = true;
        	this.Name = "FormContract";
        	this.ShowInTaskbar = false;
        	this.Text = "FormContract";
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage1.PerformLayout();
        	this.tabPage2.ResumeLayout(false);
        	this.tabPage2.PerformLayout();
        	this.ResumeLayout(false);

            this.DoubleBuffered = true;
        	this.FormSavePosition = true;
        	this.Name = "FormContract";
        	this.ShowInTaskbar = false;
        	this.Text = "FormContract";
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage1.PerformLayout();
        	this.tabPage2.ResumeLayout(false);
        	this.tabPage2.PerformLayout();
        	this.ResumeLayout(false);

            this.DoubleBuffered = true;
        	this.FormSavePosition = true;
        	this.Name = "FormContract";
        	this.ShowInTaskbar = false;
        	this.Text = "FormContract";        	
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage1.PerformLayout();
        	this.tabPage2.ResumeLayout(false);
        	this.tabPage2.PerformLayout();
        	this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnSave;
        private TextBoxFBA textBoxFBA1;
        private FBA.LabelFBA label5;
        private EditFBA EditFBA9;  
        private System.Windows.Forms.Button button1;
        private EditFBA EditFBA7;
        private FBA.LabelFBA label10;    
        private EditFBA EditFBA5;
        private LabelFBA labelFBA1;
        private LabelFBA label7;
        private System.Windows.Forms.TabPage tabPage2;
        private TextBoxFBA textBoxFBA4;
        private FBA.DateTimePickerFBA dateTimePickerFBA4;
        private FBA.DateTimePickerFBA dateTimePickerFBA3;
        private TextBoxFBA textBoxFBA5;
        private FBA.LabelFBA label23;
        private FBA.LabelFBA label1;       
    }
}
