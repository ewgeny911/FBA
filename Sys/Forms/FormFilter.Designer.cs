
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 17.09.2017
 * Время: 18:01
 * 
 
 */
namespace FBA
{
    partial class FormFilter
    {        
        private System.ComponentModel.IContainer components = null;
       // public FBA.TabControlFBA tabControlFilter;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private FastColoredTextBoxNS.FastColoredTextBox tbTextUniversal;
        private System.Windows.Forms.Panel panelFilterStatic2;
        private System.Windows.Forms.Panel panelFilterUniversal2;
        private FBA.ComboBoxFBA cbExample;
        private System.Windows.Forms.CheckBox cbUniversal;
        private System.Windows.Forms.CheckBox cbStatic;
        private System.Windows.Forms.Panel panelFilterStatic;       
        private System.Windows.Forms.Button btnFilterCustomAdd;
        private FBA.ComboBoxFBA cbFilterCustomCondition;
        private FBA.ComboBoxFBA comboBox4;
        private FBA.ComboBoxFBA comboBox3;                    
        private FBA.ComboBoxFBA comboBox1;
        private FBA.ComboBoxFBA comboBox2;
        private System.Windows.Forms.Panel panelFilterCustom2;
        private System.Windows.Forms.CheckBox cbCustom;
        //private System.Windows.Forms.SplitContainer splitContainerAttr;
        private FBA.SplitContainerFBA splitContainerAttr;
        private System.Windows.Forms.Panel panelAttrListUp;
        private CompAttrTreeFBA cmtAttrList;
        private FBA.DataGridViewFBA dgvAttr;
        private System.Windows.Forms.Panel panelFilterName;
        private System.Windows.Forms.TextBox tbFilterName;
        private FBA.LabelFBA lbFilterName;
        private System.Windows.Forms.CheckBox cbUniversalWordWrap;
        private System.Windows.Forms.Panel panelAttrList;
        private System.Windows.Forms.Panel panelFormSplitter;
        private System.Windows.Forms.Button btnAttrDelAll;
        private System.Windows.Forms.Button btnAttrDel;
        private System.Windows.Forms.Button btnAttrAdd;
        private FBA.LabelFBA lbAttrList;
        private System.Windows.Forms.Button btnAttrUp;
        private System.Windows.Forms.Button btnAttrDown;
        private System.Windows.Forms.ContextMenuStrip cmAttr;
        private System.Windows.Forms.ToolStripMenuItem cmAttrN1;
        private System.Windows.Forms.ToolStripMenuItem cmAttrN2;
        private System.Windows.Forms.ToolStripMenuItem cmAttrN3;
        private System.Windows.Forms.ToolTip toolTip1;                     
          
        private System.Windows.Forms.FlowLayoutPanel panelFilterCustom;
        private System.Windows.Forms.Button btnStaticToUniversal;
        private System.Windows.Forms.Button btnCustomToUniversal;
        private FBA.DataGridViewFBA dgvList;
        private System.Windows.Forms.ContextMenuStrip cmFilterList;
        private System.Windows.Forms.ToolStripMenuItem cmFilterListN7;
        private System.Windows.Forms.ToolStripMenuItem cmFilterListN1;
        private System.Windows.Forms.ToolStripMenuItem cmFilterListN2;
        private System.Windows.Forms.ToolStripSeparator cmFilterLine1;
        private System.Windows.Forms.ToolStripMenuItem cmFilterListN4;
        private System.Windows.Forms.ToolStripMenuItem cmFilterListN9;
        private System.Windows.Forms.ToolStripSeparator cmFilterLine2;
        private System.Windows.Forms.ToolStripMenuItem cmFilterListN6;
        private System.Windows.Forms.ToolStripMenuItem cmFilterListN8;
        private System.Windows.Forms.Panel panel2;
        private FBA.LabelFBA label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbFilter1;
        private System.Windows.Forms.Timer timer1;
        private FBA.LabelFBA label2;
        private FBA.ComboBoxFBA cbMax;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;     
        private System.Windows.Forms.Panel panelFilterView_Base;
        private System.Windows.Forms.Panel panelFilterUniversal_Base;
        private System.Windows.Forms.Panel panelFilterCustom_Base;
        private System.Windows.Forms.Panel panelFilterStatic_Base;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.CheckBox btnViewSet;
        private System.Windows.Forms.CheckBox btnUniversalSet;
        private System.Windows.Forms.CheckBox btnCustomSet;
        //private System.Windows.Forms.CheckBox btnStaticSet;
        private FBA.CheckBoxFBA btnStaticSet;
        private System.Windows.Forms.Panel pnlFilters;
        
        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
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
        	this.components = new System.ComponentModel.Container();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.splitContainerAttr = new FBA.SplitContainerFBA();
        	this.cmtAttrList = new FBA.CompAttrTreeFBA();
        	this.panelAttrList = new System.Windows.Forms.Panel();
        	this.dgvAttr = new FBA.DataGridViewFBA();
        	this.cmAttr = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmAttrN1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmAttrN2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmAttrN3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.panelFormSplitter = new System.Windows.Forms.Panel();
        	this.btnAttrUp = new System.Windows.Forms.Button();
        	this.btnAttrDown = new System.Windows.Forms.Button();
        	this.btnAttrDelAll = new System.Windows.Forms.Button();
        	this.btnAttrDel = new System.Windows.Forms.Button();
        	this.btnAttrAdd = new System.Windows.Forms.Button();
        	this.panelAttrListUp = new System.Windows.Forms.Panel();
        	this.lbAttrList = new FBA.LabelFBA();
        	this.panelFilterStatic = new System.Windows.Forms.Panel();
        	this.panelFilterStatic2 = new System.Windows.Forms.Panel();
        	this.btnStaticToUniversal = new System.Windows.Forms.Button();
        	this.cbStatic = new System.Windows.Forms.CheckBox();
        	this.panelFilterCustom = new System.Windows.Forms.FlowLayoutPanel();
        	this.panelFilterCustom2 = new System.Windows.Forms.Panel();
        	this.btnCustomToUniversal = new System.Windows.Forms.Button();
        	this.btnFilterCustomAdd = new System.Windows.Forms.Button();
        	this.cbFilterCustomCondition = new FBA.ComboBoxFBA();
        	this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cbCustom = new System.Windows.Forms.CheckBox();
        	this.tbTextUniversal = new FastColoredTextBoxNS.FastColoredTextBox();
        	this.cbUniversalWordWrap = new System.Windows.Forms.CheckBox();
        	this.panelFilterUniversal2 = new System.Windows.Forms.Panel();
        	this.cbExample = new FBA.ComboBoxFBA();
        	this.cbUniversal = new System.Windows.Forms.CheckBox();
        	this.panelButton = new System.Windows.Forms.Panel();
        	this.tbFilter3 = new System.Windows.Forms.Button();
        	this.tbFilter2 = new System.Windows.Forms.Button();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.comboBox1 = new FBA.ComboBoxFBA();
        	this.comboBox2 = new FBA.ComboBoxFBA();
        	this.comboBox3 = new FBA.ComboBoxFBA();
        	this.comboBox4 = new FBA.ComboBoxFBA();
        	this.panelFilterName = new System.Windows.Forms.Panel();
        	this.cbMax = new FBA.ComboBoxFBA();
        	this.label2 = new FBA.LabelFBA();
        	this.tbFilterName = new System.Windows.Forms.TextBox();
        	this.lbFilterName = new FBA.LabelFBA();
        	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        	this.dgvList = new FBA.DataGridViewFBA();
        	this.cmFilterList = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmFilterListN7 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmFilterListN1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmFilterListN2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmFilterListN9 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmFilterLine1 = new System.Windows.Forms.ToolStripSeparator();
        	this.cmFilterListN4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmFilterLine2 = new System.Windows.Forms.ToolStripSeparator();
        	this.cmFilterListN6 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmFilterListN8 = new System.Windows.Forms.ToolStripMenuItem();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.label1 = new FBA.LabelFBA();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.tbFilter1 = new System.Windows.Forms.ToolStripButton();
        	this.timer1 = new System.Windows.Forms.Timer(this.components);
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.splitter1 = new System.Windows.Forms.Splitter();
        	this.panel4 = new System.Windows.Forms.Panel();
        	this.panelFilterView_Base = new System.Windows.Forms.Panel();
        	this.panelFilterUniversal_Base = new System.Windows.Forms.Panel();
        	this.panelFilterCustom_Base = new System.Windows.Forms.Panel();
        	this.panelFilterStatic_Base = new System.Windows.Forms.Panel();
        	this.pnlTab = new System.Windows.Forms.Panel();
        	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        	this.btnViewSet = new System.Windows.Forms.CheckBox();
        	this.btnUniversalSet = new System.Windows.Forms.CheckBox();
        	this.btnCustomSet = new System.Windows.Forms.CheckBox();
        	this.btnStaticSet = new FBA.CheckBoxFBA();
        	this.pnlFilters = new System.Windows.Forms.Panel();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainerAttr)).BeginInit();
        	this.splitContainerAttr.Panel1.SuspendLayout();
        	this.splitContainerAttr.Panel2.SuspendLayout();
        	this.splitContainerAttr.SuspendLayout();
        	this.panelAttrList.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvAttr)).BeginInit();
        	this.cmAttr.SuspendLayout();
        	this.panelFormSplitter.SuspendLayout();
        	this.panelAttrListUp.SuspendLayout();
        	this.panelFilterStatic2.SuspendLayout();
        	this.panelFilterCustom2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.tbTextUniversal)).BeginInit();
        	this.panelFilterUniversal2.SuspendLayout();
        	this.panelButton.SuspendLayout();
        	this.panelFilterName.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
        	this.cmFilterList.SuspendLayout();
        	this.panel2.SuspendLayout();
        	this.toolStrip1.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.panel4.SuspendLayout();
        	this.panelFilterView_Base.SuspendLayout();
        	this.panelFilterUniversal_Base.SuspendLayout();
        	this.panelFilterCustom_Base.SuspendLayout();
        	this.panelFilterStatic_Base.SuspendLayout();
        	this.pnlTab.SuspendLayout();
        	this.pnlFilters.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// splitContainerAttr
        	// 
        	this.splitContainerAttr.BackColor = System.Drawing.Color.Gainsboro;
        	this.splitContainerAttr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.splitContainerAttr.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainerAttr.Location = new System.Drawing.Point(0, 0);
        	this.splitContainerAttr.Margin = new System.Windows.Forms.Padding(4);
        	this.splitContainerAttr.Name = "splitContainerAttr";
        	// 
        	// splitContainerAttr.Panel1
        	// 
        	this.splitContainerAttr.Panel1.Controls.Add(this.cmtAttrList);
        	// 
        	// splitContainerAttr.Panel2
        	// 
        	this.splitContainerAttr.Panel2.BackColor = System.Drawing.Color.Transparent;
        	this.splitContainerAttr.Panel2.Controls.Add(this.panelAttrList);
        	this.splitContainerAttr.Panel2.Controls.Add(this.panelAttrListUp);
        	this.splitContainerAttr.Size = new System.Drawing.Size(413, 104);
        	this.splitContainerAttr.SplitterDistance = 143;
        	this.splitContainerAttr.TabIndex = 16;
        	// 
        	// cmtAttrList
        	// 
        	this.cmtAttrList.BackColor = System.Drawing.SystemColors.ButtonFace;
        	this.cmtAttrList.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.cmtAttrList.Location = new System.Drawing.Point(0, 0);
        	this.cmtAttrList.Margin = new System.Windows.Forms.Padding(4);
        	this.cmtAttrList.Name = "cmtAttrList";
        	this.cmtAttrList.Size = new System.Drawing.Size(141, 102);
        	this.cmtAttrList.TabIndex = 0;
        	this.cmtAttrList.SelectedAttr += new FBA.AttrEventHandler(this.CmtAttrList_SelectedAttr);
        	// 
        	// panelAttrList
        	// 
        	this.panelAttrList.Controls.Add(this.dgvAttr);
        	this.panelAttrList.Controls.Add(this.panelFormSplitter);
        	this.panelAttrList.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panelAttrList.Location = new System.Drawing.Point(0, 25);
        	this.panelAttrList.Name = "panelAttrList";
        	this.panelAttrList.Size = new System.Drawing.Size(264, 77);
        	this.panelAttrList.TabIndex = 18;
        	// 
        	// dgvAttr
        	// 
        	this.dgvAttr.AllowUserToAddRows = false;
        	this.dgvAttr.AllowUserToDeleteRows = false;
        	this.dgvAttr.AllowUserToOrderColumns = true;
        	this.dgvAttr.AllowUserToResizeRows = false;
        	dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvAttr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        	this.dgvAttr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvAttr.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.dgvAttr.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvAttr.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvAttr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvAttr.CommandAdd = false;
        	this.dgvAttr.CommandDel = false;
        	this.dgvAttr.CommandEdit = false;
        	this.dgvAttr.CommandExportToExcel = false;
        	this.dgvAttr.CommandFilter = false;
        	this.dgvAttr.CommandRefresh = false;
        	this.dgvAttr.CommandSaveASCSV = false;
        	this.dgvAttr.ContextMenuStrip = this.cmAttr;
        	this.dgvAttr.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvAttr.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        	this.dgvAttr.EnableHeadersVisualStyles = false;
        	this.dgvAttr.GroupEnabled = null;
        	this.dgvAttr.Location = new System.Drawing.Point(46, 0);
        	this.dgvAttr.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvAttr.Name = "dgvAttr";
        	this.dgvAttr.Obj = null;
        	this.dgvAttr.PassedSec = null;
        	this.dgvAttr.ReadOnly = true;
        	this.dgvAttr.RowHeadersVisible = false;
        	this.dgvAttr.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvAttr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvAttr.Size = new System.Drawing.Size(218, 77);
        	this.dgvAttr.TabIndex = 15;
        	this.dgvAttr.DoubleClick += new System.EventHandler(this.DgvAttr_DoubleClick);
        	this.dgvAttr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvAttr_KeyDown);
        	// 
        	// cmAttr
        	// 
        	this.cmAttr.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmAttr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmAttrN1,
			this.cmAttrN2,
			this.cmAttrN3});
        	this.cmAttr.Name = "cmAttr";
        	this.cmAttr.Size = new System.Drawing.Size(144, 70);
        	// 
        	// cmAttrN1
        	// 
        	this.cmAttrN1.Image = global::FBA.Resource.Up_16;
        	this.cmAttrN1.Name = "cmAttrN1";
        	this.cmAttrN1.Size = new System.Drawing.Size(143, 22);
        	this.cmAttrN1.Text = "Up";
        	this.cmAttrN1.Click += new System.EventHandler(this.BtnAttrAdd_Click);
        	// 
        	// cmAttrN2
        	// 
        	this.cmAttrN2.Image = global::FBA.Resource.Down_16;
        	this.cmAttrN2.Name = "cmAttrN2";
        	this.cmAttrN2.Size = new System.Drawing.Size(143, 22);
        	this.cmAttrN2.Text = "Down";
        	this.cmAttrN2.Click += new System.EventHandler(this.BtnAttrAdd_Click);
        	// 
        	// cmAttrN3
        	// 
        	this.cmAttrN3.Image = global::FBA.Resource.Properties_16;
        	this.cmAttrN3.Name = "cmAttrN3";
        	this.cmAttrN3.Size = new System.Drawing.Size(143, 22);
        	this.cmAttrN3.Text = "Properties";
        	this.cmAttrN3.Click += new System.EventHandler(this.BtnAttrAdd_Click);
        	// 
        	// panelFormSplitter
        	// 
        	this.panelFormSplitter.BackColor = System.Drawing.SystemColors.ButtonFace;
        	this.panelFormSplitter.Controls.Add(this.btnAttrUp);
        	this.panelFormSplitter.Controls.Add(this.btnAttrDown);
        	this.panelFormSplitter.Controls.Add(this.btnAttrDelAll);
        	this.panelFormSplitter.Controls.Add(this.btnAttrDel);
        	this.panelFormSplitter.Controls.Add(this.btnAttrAdd);
        	this.panelFormSplitter.Dock = System.Windows.Forms.DockStyle.Left;
        	this.panelFormSplitter.Location = new System.Drawing.Point(0, 0);
        	this.panelFormSplitter.Name = "panelFormSplitter";
        	this.panelFormSplitter.Size = new System.Drawing.Size(46, 77);
        	this.panelFormSplitter.TabIndex = 18;
        	// 
        	// btnAttrUp
        	// 
        	this.btnAttrUp.Image = global::FBA.Resource.Up_24;
        	this.btnAttrUp.Location = new System.Drawing.Point(4, 106);
        	this.btnAttrUp.Name = "btnAttrUp";
        	this.btnAttrUp.Size = new System.Drawing.Size(38, 33);
        	this.btnAttrUp.TabIndex = 5;
        	this.toolTip1.SetToolTip(this.btnAttrUp, "Hotkey: Ctrl+Up");
        	this.btnAttrUp.UseVisualStyleBackColor = true;
        	this.btnAttrUp.Click += new System.EventHandler(this.BtnAttrAdd_Click);
        	// 
        	// btnAttrDown
        	// 
        	this.btnAttrDown.Image = global::FBA.Resource.Down_24;
        	this.btnAttrDown.Location = new System.Drawing.Point(4, 140);
        	this.btnAttrDown.Name = "btnAttrDown";
        	this.btnAttrDown.Size = new System.Drawing.Size(38, 33);
        	this.btnAttrDown.TabIndex = 4;
        	this.toolTip1.SetToolTip(this.btnAttrDown, "Hotkey: Ctrl+Down");
        	this.btnAttrDown.UseVisualStyleBackColor = true;
        	this.btnAttrDown.Click += new System.EventHandler(this.BtnAttrAdd_Click);
        	// 
        	// btnAttrDelAll
        	// 
        	this.btnAttrDelAll.Image = global::FBA.Resource.Delete_24;
        	this.btnAttrDelAll.Location = new System.Drawing.Point(4, 72);
        	this.btnAttrDelAll.Name = "btnAttrDelAll";
        	this.btnAttrDelAll.Size = new System.Drawing.Size(38, 33);
        	this.btnAttrDelAll.TabIndex = 3;
        	this.toolTip1.SetToolTip(this.btnAttrDelAll, "Delete all atributes");
        	this.btnAttrDelAll.UseVisualStyleBackColor = true;
        	this.btnAttrDelAll.Click += new System.EventHandler(this.BtnAttrAdd_Click);
        	// 
        	// btnAttrDel
        	// 
        	this.btnAttrDel.Image = global::FBA.Resource.Back_24;
        	this.btnAttrDel.Location = new System.Drawing.Point(4, 38);
        	this.btnAttrDel.Name = "btnAttrDel";
        	this.btnAttrDel.Size = new System.Drawing.Size(38, 33);
        	this.btnAttrDel.TabIndex = 2;
        	this.toolTip1.SetToolTip(this.btnAttrDel, "Delete attribute");
        	this.btnAttrDel.UseVisualStyleBackColor = true;
        	this.btnAttrDel.Click += new System.EventHandler(this.BtnAttrAdd_Click);
        	// 
        	// btnAttrAdd
        	// 
        	this.btnAttrAdd.Image = global::FBA.Resource.Forward_24;
        	this.btnAttrAdd.Location = new System.Drawing.Point(4, 4);
        	this.btnAttrAdd.Name = "btnAttrAdd";
        	this.btnAttrAdd.Size = new System.Drawing.Size(38, 33);
        	this.btnAttrAdd.TabIndex = 0;
        	this.toolTip1.SetToolTip(this.btnAttrAdd, "Add attribute");
        	this.btnAttrAdd.UseVisualStyleBackColor = true;
        	this.btnAttrAdd.Click += new System.EventHandler(this.BtnAttrAdd_Click);
        	// 
        	// panelAttrListUp
        	// 
        	this.panelAttrListUp.BackColor = System.Drawing.SystemColors.ButtonFace;
        	this.panelAttrListUp.Controls.Add(this.lbAttrList);
        	this.panelAttrListUp.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panelAttrListUp.Location = new System.Drawing.Point(0, 0);
        	this.panelAttrListUp.Margin = new System.Windows.Forms.Padding(4);
        	this.panelAttrListUp.Name = "panelAttrListUp";
        	this.panelAttrListUp.Size = new System.Drawing.Size(264, 25);
        	this.panelAttrListUp.TabIndex = 16;
        	// 
        	// lbAttrList
        	// 
        	this.lbAttrList.BackColor = System.Drawing.Color.Transparent;
        	this.lbAttrList.ForeColor = System.Drawing.Color.DarkBlue;
        	this.lbAttrList.Location = new System.Drawing.Point(6, 4);
        	this.lbAttrList.Name = "lbAttrList";
        	this.lbAttrList.Size = new System.Drawing.Size(327, 18);
        	this.lbAttrList.StarColor = System.Drawing.Color.Crimson;
        	this.lbAttrList.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbAttrList.StarOffsetX = 2;
        	this.lbAttrList.StarOffsetY = 0;
        	this.lbAttrList.StarShow = false;
        	this.lbAttrList.StarText = "*";
        	this.lbAttrList.TabIndex = 0;
        	this.lbAttrList.Text = "Attribute list. Change order: Ctrl+Up, Ctrl+Down";
        	// 
        	// panelFilterStatic
        	// 
        	this.panelFilterStatic.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panelFilterStatic.Enabled = false;
        	this.panelFilterStatic.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.panelFilterStatic.Location = new System.Drawing.Point(0, 37);
        	this.panelFilterStatic.Margin = new System.Windows.Forms.Padding(4);
        	this.panelFilterStatic.Name = "panelFilterStatic";
        	this.panelFilterStatic.Size = new System.Drawing.Size(597, 51);
        	this.panelFilterStatic.TabIndex = 23;
        	// 
        	// panelFilterStatic2
        	// 
        	this.panelFilterStatic2.Controls.Add(this.btnStaticToUniversal);
        	this.panelFilterStatic2.Controls.Add(this.cbStatic);
        	this.panelFilterStatic2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panelFilterStatic2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.panelFilterStatic2.Location = new System.Drawing.Point(0, 0);
        	this.panelFilterStatic2.Margin = new System.Windows.Forms.Padding(4);
        	this.panelFilterStatic2.Name = "panelFilterStatic2";
        	this.panelFilterStatic2.Size = new System.Drawing.Size(597, 37);
        	this.panelFilterStatic2.TabIndex = 22;
        	// 
        	// btnStaticToUniversal
        	// 
        	this.btnStaticToUniversal.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnStaticToUniversal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnStaticToUniversal.Location = new System.Drawing.Point(290, 5);
        	this.btnStaticToUniversal.Margin = new System.Windows.Forms.Padding(4);
        	this.btnStaticToUniversal.Name = "btnStaticToUniversal";
        	this.btnStaticToUniversal.Size = new System.Drawing.Size(118, 25);
        	this.btnStaticToUniversal.TabIndex = 18;
        	this.btnStaticToUniversal.Text = "To Universal";
        	this.btnStaticToUniversal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.btnStaticToUniversal.UseVisualStyleBackColor = true;
        	this.btnStaticToUniversal.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// cbStatic
        	// 
        	this.cbStatic.BackColor = System.Drawing.Color.Transparent;
        	this.cbStatic.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbStatic.Location = new System.Drawing.Point(12, 7);
        	this.cbStatic.Margin = new System.Windows.Forms.Padding(4);
        	this.cbStatic.Name = "cbStatic";
        	this.cbStatic.Size = new System.Drawing.Size(155, 23);
        	this.cbStatic.TabIndex = 10;
        	this.cbStatic.Tag = "SAVE";
        	this.cbStatic.Text = "Use the static filter";
        	this.cbStatic.UseVisualStyleBackColor = false;
        	this.cbStatic.CheckedChanged += new System.EventHandler(this.CbCustomCheckedChanged);
        	// 
        	// panelFilterCustom
        	// 
        	this.panelFilterCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.panelFilterCustom.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.panelFilterCustom.Location = new System.Drawing.Point(11, 38);
        	this.panelFilterCustom.Margin = new System.Windows.Forms.Padding(1);
        	this.panelFilterCustom.Name = "panelFilterCustom";
        	this.panelFilterCustom.Size = new System.Drawing.Size(581, 52);
        	this.panelFilterCustom.TabIndex = 26;
        	this.panelFilterCustom.Resize += new System.EventHandler(this.PanelFilterCustomResize);
        	// 
        	// panelFilterCustom2
        	// 
        	this.panelFilterCustom2.Controls.Add(this.btnCustomToUniversal);
        	this.panelFilterCustom2.Controls.Add(this.btnFilterCustomAdd);
        	this.panelFilterCustom2.Controls.Add(this.cbFilterCustomCondition);
        	this.panelFilterCustom2.Controls.Add(this.cbCustom);
        	this.panelFilterCustom2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panelFilterCustom2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.panelFilterCustom2.Location = new System.Drawing.Point(0, 0);
        	this.panelFilterCustom2.Margin = new System.Windows.Forms.Padding(4);
        	this.panelFilterCustom2.Name = "panelFilterCustom2";
        	this.panelFilterCustom2.Size = new System.Drawing.Size(597, 37);
        	this.panelFilterCustom2.TabIndex = 25;
        	// 
        	// btnCustomToUniversal
        	// 
        	this.btnCustomToUniversal.Enabled = false;
        	this.btnCustomToUniversal.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnCustomToUniversal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCustomToUniversal.Location = new System.Drawing.Point(472, 6);
        	this.btnCustomToUniversal.Margin = new System.Windows.Forms.Padding(4);
        	this.btnCustomToUniversal.Name = "btnCustomToUniversal";
        	this.btnCustomToUniversal.Size = new System.Drawing.Size(116, 25);
        	this.btnCustomToUniversal.TabIndex = 17;
        	this.btnCustomToUniversal.Text = "To Universal";
        	this.btnCustomToUniversal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.btnCustomToUniversal.UseVisualStyleBackColor = true;
        	this.btnCustomToUniversal.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// btnFilterCustomAdd
        	// 
        	this.btnFilterCustomAdd.Enabled = false;
        	this.btnFilterCustomAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnFilterCustomAdd.Image = global::FBA.Resource.Add_16;
        	this.btnFilterCustomAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnFilterCustomAdd.Location = new System.Drawing.Point(358, 6);
        	this.btnFilterCustomAdd.Margin = new System.Windows.Forms.Padding(4);
        	this.btnFilterCustomAdd.Name = "btnFilterCustomAdd";
        	this.btnFilterCustomAdd.Size = new System.Drawing.Size(112, 25);
        	this.btnFilterCustomAdd.TabIndex = 15;
        	this.btnFilterCustomAdd.Text = "Add filter ";
        	this.btnFilterCustomAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.btnFilterCustomAdd.UseVisualStyleBackColor = true;
        	this.btnFilterCustomAdd.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// cbFilterCustomCondition
        	// 
        	this.cbFilterCustomCondition.AttrBrief = null;
        	this.cbFilterCustomCondition.AttrBriefLookup = null;
        	this.cbFilterCustomCondition.BackColor = System.Drawing.SystemColors.Info;
        	this.cbFilterCustomCondition.ContextMenuEnabled = false;
        	this.cbFilterCustomCondition.ContextMenuStrip = this.contextMenuStrip1;
        	this.cbFilterCustomCondition.Enabled = false;
        	this.cbFilterCustomCondition.ErrorIfNull = null;
        	this.cbFilterCustomCondition.FormattingEnabled = true;
        	this.cbFilterCustomCondition.GroupEnabled = null;
        	this.cbFilterCustomCondition.Items.AddRange(new object[] {
			"All conditions (AND)",
			"Any condition (OR)"});
        	this.cbFilterCustomCondition.ListInvalidChars = null;
        	this.cbFilterCustomCondition.ListValidChars = null;
        	this.cbFilterCustomCondition.Location = new System.Drawing.Point(175, 7);
        	this.cbFilterCustomCondition.Margin = new System.Windows.Forms.Padding(4);
        	this.cbFilterCustomCondition.Name = "cbFilterCustomCondition";
        	this.cbFilterCustomCondition.Obj = null;
        	this.cbFilterCustomCondition.ObjectID = "";
        	this.cbFilterCustomCondition.ObjectRef = null;
        	this.cbFilterCustomCondition.ObjRef = null;
        	this.cbFilterCustomCondition.ReadOnly = true;
        	this.cbFilterCustomCondition.RegExChars = null;
        	this.cbFilterCustomCondition.SaveParam = false;
        	this.cbFilterCustomCondition.SaveType = null;
        	this.cbFilterCustomCondition.SaveValueHistory = false;
        	this.cbFilterCustomCondition.Size = new System.Drawing.Size(178, 25);
        	this.cbFilterCustomCondition.TabIndex = 12;
        	this.cbFilterCustomCondition.Tag = "SAVE";
        	this.cbFilterCustomCondition.Text = "All conditions (AND)";
        	this.cbFilterCustomCondition.Text2 = null;
        	this.cbFilterCustomCondition.ValueHistoryInItems = false;
        	// 
        	// contextMenuStrip1
        	// 
        	this.contextMenuStrip1.Name = "contextMenuStrip1";
        	this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
        	// 
        	// cbCustom
        	// 
        	this.cbCustom.Location = new System.Drawing.Point(12, 7);
        	this.cbCustom.Margin = new System.Windows.Forms.Padding(4);
        	this.cbCustom.Name = "cbCustom";
        	this.cbCustom.Size = new System.Drawing.Size(161, 23);
        	this.cbCustom.TabIndex = 10;
        	this.cbCustom.Tag = "SAVE";
        	this.cbCustom.Text = "Use the custom filter";
        	this.cbCustom.UseVisualStyleBackColor = true;
        	this.cbCustom.CheckedChanged += new System.EventHandler(this.CbCustomCheckedChanged);
        	// 
        	// tbTextUniversal
        	// 
        	this.tbTextUniversal.AutoCompleteBracketsList = new char[] {
		'(',
		')',
		'{',
		'}',
		'[',
		']',
		'\"',
		'\"',
		'\'',
		'\''};
        	this.tbTextUniversal.AutoIndentCharsPatterns = "";
        	this.tbTextUniversal.AutoScrollMinSize = new System.Drawing.Size(33, 21);
        	this.tbTextUniversal.BackBrush = null;
        	this.tbTextUniversal.BackColor = System.Drawing.SystemColors.Info;
        	this.tbTextUniversal.BookmarkColor = System.Drawing.Color.Red;
        	this.tbTextUniversal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.tbTextUniversal.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
        	this.tbTextUniversal.CharHeight = 21;
        	this.tbTextUniversal.CharWidth = 11;
        	this.tbTextUniversal.CommentPrefix = "--";
        	this.tbTextUniversal.CurrentLineColor = System.Drawing.Color.DarkGray;
        	this.tbTextUniversal.Cursor = System.Windows.Forms.Cursors.IBeam;
        	this.tbTextUniversal.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
        	this.tbTextUniversal.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tbTextUniversal.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
        	this.tbTextUniversal.Font = new System.Drawing.Font("Courier New", 14.25F);
        	this.tbTextUniversal.IsReplaceMode = false;
        	this.tbTextUniversal.Language = FastColoredTextBoxNS.Language.SQL;
        	this.tbTextUniversal.LeftBracket = '(';
        	this.tbTextUniversal.Location = new System.Drawing.Point(0, 31);
        	this.tbTextUniversal.Margin = new System.Windows.Forms.Padding(4);
        	this.tbTextUniversal.Name = "tbTextUniversal";
        	this.tbTextUniversal.Paddings = new System.Windows.Forms.Padding(0);
        	this.tbTextUniversal.RightBracket = ')';
        	this.tbTextUniversal.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
        	this.tbTextUniversal.Size = new System.Drawing.Size(413, 69);
        	this.tbTextUniversal.TabIndex = 19;
        	this.tbTextUniversal.Tag = "SAVE";
        	this.tbTextUniversal.VirtualSpace = true;
        	this.tbTextUniversal.Zoom = 100;
        	// 
        	// cbUniversalWordWrap
        	// 
        	this.cbUniversalWordWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.cbUniversalWordWrap.Location = new System.Drawing.Point(124, 7);
        	this.cbUniversalWordWrap.Margin = new System.Windows.Forms.Padding(4);
        	this.cbUniversalWordWrap.Name = "cbUniversalWordWrap";
        	this.cbUniversalWordWrap.Size = new System.Drawing.Size(99, 22);
        	this.cbUniversalWordWrap.TabIndex = 10;
        	this.cbUniversalWordWrap.Tag = "SAVE";
        	this.cbUniversalWordWrap.Text = "WordWrap";
        	this.cbUniversalWordWrap.UseVisualStyleBackColor = true;
        	this.cbUniversalWordWrap.CheckedChanged += new System.EventHandler(this.CbUniversalWordWrap_CheckedChanged);
        	// 
        	// panelFilterUniversal2
        	// 
        	this.panelFilterUniversal2.Controls.Add(this.cbUniversalWordWrap);
        	this.panelFilterUniversal2.Controls.Add(this.cbExample);
        	this.panelFilterUniversal2.Controls.Add(this.cbUniversal);
        	this.panelFilterUniversal2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panelFilterUniversal2.Location = new System.Drawing.Point(0, 0);
        	this.panelFilterUniversal2.Margin = new System.Windows.Forms.Padding(4);
        	this.panelFilterUniversal2.Name = "panelFilterUniversal2";
        	this.panelFilterUniversal2.Size = new System.Drawing.Size(413, 31);
        	this.panelFilterUniversal2.TabIndex = 21;
        	// 
        	// cbExample
        	// 
        	this.cbExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.cbExample.BackColor = System.Drawing.SystemColors.Menu;
        	this.cbExample.Enabled = false;
        	this.cbExample.FormattingEnabled = true;
        	this.cbExample.Items.AddRange(new object[] {
			"Example1",
			"Example2",
			"Example3",
			"Example4",
			"Example5"});
        	this.cbExample.Location = new System.Drawing.Point(226, 5);
        	this.cbExample.Margin = new System.Windows.Forms.Padding(4);
        	this.cbExample.Name = "cbExample";
        	this.cbExample.Size = new System.Drawing.Size(179, 21);
        	this.cbExample.TabIndex = 9;
        	this.cbExample.Text = "Example1";
        	this.cbExample.SelectedIndexChanged += new System.EventHandler(this.CbExampleSelectedIndexChanged);
        	// 
        	// cbUniversal
        	// 
        	this.cbUniversal.Location = new System.Drawing.Point(12, 7);
        	this.cbUniversal.Margin = new System.Windows.Forms.Padding(4);
        	this.cbUniversal.Name = "cbUniversal";
        	this.cbUniversal.Size = new System.Drawing.Size(214, 23);
        	this.cbUniversal.TabIndex = 8;
        	this.cbUniversal.Tag = "SAVE";
        	this.cbUniversal.Text = "Use the universal filter";
        	this.cbUniversal.UseVisualStyleBackColor = true;
        	this.cbUniversal.CheckedChanged += new System.EventHandler(this.CbCustomCheckedChanged);
        	// 
        	// panelButton
        	// 
        	this.panelButton.Controls.Add(this.tbFilter3);
        	this.panelButton.Controls.Add(this.tbFilter2);
        	this.panelButton.Controls.Add(this.btnCancel);
        	this.panelButton.Controls.Add(this.btnOk);
        	this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panelButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.panelButton.Location = new System.Drawing.Point(0, 518);
        	this.panelButton.Margin = new System.Windows.Forms.Padding(4);
        	this.panelButton.Name = "panelButton";
        	this.panelButton.Size = new System.Drawing.Size(845, 41);
        	this.panelButton.TabIndex = 2;
        	// 
        	// tbFilter3
        	// 
        	this.tbFilter3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.tbFilter3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbFilter3.Image = global::FBA.Resource.SaveAs_24;
        	this.tbFilter3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.tbFilter3.Location = new System.Drawing.Point(493, 4);
        	this.tbFilter3.Margin = new System.Windows.Forms.Padding(4);
        	this.tbFilter3.Name = "tbFilter3";
        	this.tbFilter3.Size = new System.Drawing.Size(112, 33);
        	this.tbFilter3.TabIndex = 5;
        	this.tbFilter3.Text = "   Save as...";
        	this.tbFilter3.UseVisualStyleBackColor = true;
        	this.tbFilter3.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// tbFilter2
        	// 
        	this.tbFilter2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.tbFilter2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbFilter2.Image = global::FBA.Resource.Save_24;
        	this.tbFilter2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.tbFilter2.Location = new System.Drawing.Point(377, 4);
        	this.tbFilter2.Margin = new System.Windows.Forms.Padding(4);
        	this.tbFilter2.Name = "tbFilter2";
        	this.tbFilter2.Size = new System.Drawing.Size(112, 33);
        	this.tbFilter2.TabIndex = 4;
        	this.tbFilter2.Text = "   Save";
        	this.tbFilter2.UseVisualStyleBackColor = true;
        	this.tbFilter2.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(609, 4);
        	this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(112, 33);
        	this.btnCancel.TabIndex = 2;
        	this.btnCancel.Text = "    Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// btnOk
        	// 
        	this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(725, 4);
        	this.btnOk.Margin = new System.Windows.Forms.Padding(4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 0;
        	this.btnOk.Text = "   Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// comboBox1
        	// 
        	this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
        	this.comboBox1.FormattingEnabled = true;
        	this.comboBox1.Location = new System.Drawing.Point(286, 3);
        	this.comboBox1.Name = "comboBox1";
        	this.comboBox1.Size = new System.Drawing.Size(94, 21);
        	this.comboBox1.TabIndex = 22;
        	// 
        	// comboBox2
        	// 
        	this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBox2.FormattingEnabled = true;
        	this.comboBox2.Location = new System.Drawing.Point(386, 3);
        	this.comboBox2.Name = "comboBox2";
        	this.comboBox2.Size = new System.Drawing.Size(180, 21);
        	this.comboBox2.TabIndex = 23;
        	// 
        	// comboBox3
        	// 
        	this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBox3.FormattingEnabled = true;
        	this.comboBox3.Location = new System.Drawing.Point(592, 3);
        	this.comboBox3.Name = "comboBox3";
        	this.comboBox3.Size = new System.Drawing.Size(180, 21);
        	this.comboBox3.TabIndex = 24;
        	// 
        	// comboBox4
        	// 
        	this.comboBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBox4.FormattingEnabled = true;
        	this.comboBox4.Location = new System.Drawing.Point(24, 3);
        	this.comboBox4.Name = "comboBox4";
        	this.comboBox4.Size = new System.Drawing.Size(256, 21);
        	this.comboBox4.TabIndex = 25;
        	// 
        	// panelFilterName
        	// 
        	this.panelFilterName.Controls.Add(this.cbMax);
        	this.panelFilterName.Controls.Add(this.label2);
        	this.panelFilterName.Controls.Add(this.tbFilterName);
        	this.panelFilterName.Controls.Add(this.lbFilterName);
        	this.panelFilterName.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panelFilterName.Location = new System.Drawing.Point(0, 0);
        	this.panelFilterName.Margin = new System.Windows.Forms.Padding(4);
        	this.panelFilterName.Name = "panelFilterName";
        	this.panelFilterName.Size = new System.Drawing.Size(624, 29);
        	this.panelFilterName.TabIndex = 4;
        	// 
        	// cbMax
        	// 
        	this.cbMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.cbMax.AttrBrief = null;
        	this.cbMax.AttrBriefLookup = null;
        	this.cbMax.BackColor = System.Drawing.SystemColors.Info;
        	this.cbMax.ContextMenuEnabled = true;
        	this.cbMax.ErrorIfNull = null;
        	this.cbMax.FormattingEnabled = true;
        	this.cbMax.GroupEnabled = null;
        	this.cbMax.Items.AddRange(new object[] {
			"1",
			"10",
			"50",
			"100",
			"500",
			"1000",
			"5000",
			"10000",
			"50000",
			"100000",
			"Unlimited"});
        	this.cbMax.ListInvalidChars = null;
        	this.cbMax.ListValidChars = null;
        	this.cbMax.Location = new System.Drawing.Point(518, 2);
        	this.cbMax.Name = "cbMax";
        	this.cbMax.Obj = null;
        	this.cbMax.ObjectID = "";
        	this.cbMax.ObjectRef = null;
        	this.cbMax.ObjRef = null;
        	this.cbMax.ReadOnly = false;
        	this.cbMax.RegExChars = null;
        	this.cbMax.SaveParam = false;
        	this.cbMax.SaveType = null;
        	this.cbMax.SaveValueHistory = false;
        	this.cbMax.Size = new System.Drawing.Size(97, 21);
        	this.cbMax.TabIndex = 4;
        	this.cbMax.Text = "50";
        	this.cbMax.Text2 = null;
        	this.cbMax.ValueHistoryInItems = false;
        	// 
        	// label2
        	// 
        	this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
        	this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.label2.Location = new System.Drawing.Point(428, 5);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(92, 20);
        	this.label2.StarColor = System.Drawing.Color.Crimson;
        	this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label2.StarOffsetX = 2;
        	this.label2.StarOffsetY = 0;
        	this.label2.StarShow = false;
        	this.label2.StarText = "*";
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Max records:";
        	// 
        	// tbFilterName
        	// 
        	this.tbFilterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbFilterName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbFilterName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbFilterName.Location = new System.Drawing.Point(111, 2);
        	this.tbFilterName.Margin = new System.Windows.Forms.Padding(4);
        	this.tbFilterName.Name = "tbFilterName";
        	this.tbFilterName.Size = new System.Drawing.Size(312, 25);
        	this.tbFilterName.TabIndex = 1;
        	this.tbFilterName.Tag = "";
        	// 
        	// lbFilterName
        	// 
        	this.lbFilterName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbFilterName.Location = new System.Drawing.Point(8, 6);
        	this.lbFilterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbFilterName.Name = "lbFilterName";
        	this.lbFilterName.Size = new System.Drawing.Size(86, 17);
        	this.lbFilterName.StarColor = System.Drawing.Color.Crimson;
        	this.lbFilterName.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbFilterName.StarOffsetX = 2;
        	this.lbFilterName.StarOffsetY = 0;
        	this.lbFilterName.StarShow = false;
        	this.lbFilterName.StarText = "*";
        	this.lbFilterName.TabIndex = 0;
        	this.lbFilterName.Text = "Filter";
        	// 
        	// dgvList
        	// 
        	this.dgvList.AllowUserToAddRows = false;
        	this.dgvList.AllowUserToDeleteRows = false;
        	this.dgvList.AllowUserToOrderColumns = true;
        	this.dgvList.AllowUserToResizeRows = false;
        	dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
        	this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvList.CommandAdd = false;
        	this.dgvList.CommandDel = false;
        	this.dgvList.CommandEdit = false;
        	this.dgvList.CommandExportToExcel = false;
        	this.dgvList.CommandFilter = false;
        	this.dgvList.CommandRefresh = false;
        	this.dgvList.CommandSaveASCSV = false;
        	this.dgvList.ContextMenuStrip = this.cmFilterList;
        	this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        	this.dgvList.EnableHeadersVisualStyles = false;
        	this.dgvList.GroupEnabled = null;
        	this.dgvList.Location = new System.Drawing.Point(0, 29);
        	this.dgvList.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvList.MultiSelect = false;
        	this.dgvList.Name = "dgvList";
        	this.dgvList.Obj = null;
        	this.dgvList.PassedSec = null;
        	this.dgvList.ReadOnly = true;
        	this.dgvList.RowHeadersVisible = false;
        	this.dgvList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvList.Size = new System.Drawing.Size(221, 458);
        	this.dgvList.TabIndex = 17;
        	this.dgvList.DoubleClick += new System.EventHandler(this.DgvList_DoubleClick);
        	// 
        	// cmFilterList
        	// 
        	this.cmFilterList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmFilterList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmFilterListN7,
			this.cmFilterListN1,
			this.cmFilterListN2,
			this.cmFilterListN9,
			this.cmFilterLine1,
			this.cmFilterListN4,
			this.cmFilterLine2,
			this.cmFilterListN6,
			this.cmFilterListN8});
        	this.cmFilterList.Name = "contextMenuStrip1";
        	this.cmFilterList.Size = new System.Drawing.Size(182, 170);
        	this.cmFilterList.Text = "contextMenuStrip1";
        	// 
        	// cmFilterListN7
        	// 
        	this.cmFilterListN7.Image = global::FBA.Resource.Use_16;
        	this.cmFilterListN7.Name = "cmFilterListN7";
        	this.cmFilterListN7.Size = new System.Drawing.Size(181, 22);
        	this.cmFilterListN7.Text = "Use";
        	this.cmFilterListN7.Click += new System.EventHandler(this.CmFilterListN1_Click);
        	// 
        	// cmFilterListN1
        	// 
        	this.cmFilterListN1.Image = global::FBA.Resource.New_16;
        	this.cmFilterListN1.Name = "cmFilterListN1";
        	this.cmFilterListN1.Size = new System.Drawing.Size(181, 22);
        	this.cmFilterListN1.Text = "New";
        	this.cmFilterListN1.Click += new System.EventHandler(this.CmFilterListN1_Click);
        	// 
        	// cmFilterListN2
        	// 
        	this.cmFilterListN2.Image = global::FBA.Resource.Del_16;
        	this.cmFilterListN2.Name = "cmFilterListN2";
        	this.cmFilterListN2.Size = new System.Drawing.Size(181, 22);
        	this.cmFilterListN2.Text = "Delete";
        	this.cmFilterListN2.Click += new System.EventHandler(this.CmFilterListN1_Click);
        	// 
        	// cmFilterListN9
        	// 
        	this.cmFilterListN9.Image = global::FBA.Resource.Refresh_16;
        	this.cmFilterListN9.Name = "cmFilterListN9";
        	this.cmFilterListN9.Size = new System.Drawing.Size(181, 22);
        	this.cmFilterListN9.Text = "Refresh";
        	this.cmFilterListN9.Click += new System.EventHandler(this.CmFilterListN1_Click);
        	// 
        	// cmFilterLine1
        	// 
        	this.cmFilterLine1.Name = "cmFilterLine1";
        	this.cmFilterLine1.Size = new System.Drawing.Size(178, 6);
        	// 
        	// cmFilterListN4
        	// 
        	this.cmFilterListN4.Image = global::FBA.Resource.CopyToUser_16;
        	this.cmFilterListN4.Name = "cmFilterListN4";
        	this.cmFilterListN4.Size = new System.Drawing.Size(181, 22);
        	this.cmFilterListN4.Text = "Copy to User";
        	this.cmFilterListN4.Click += new System.EventHandler(this.CmFilterListN1_Click);
        	// 
        	// cmFilterLine2
        	// 
        	this.cmFilterLine2.Name = "cmFilterLine2";
        	this.cmFilterLine2.Size = new System.Drawing.Size(178, 6);
        	// 
        	// cmFilterListN6
        	// 
        	this.cmFilterListN6.Image = global::FBA.Resource.SetGlobal_16;
        	this.cmFilterListN6.Name = "cmFilterListN6";
        	this.cmFilterListN6.Size = new System.Drawing.Size(181, 22);
        	this.cmFilterListN6.Text = "Set as Global";
        	this.cmFilterListN6.Click += new System.EventHandler(this.CmFilterListN1_Click);
        	// 
        	// cmFilterListN8
        	// 
        	this.cmFilterListN8.Image = global::FBA.Resource.UnSetGlobal_16;
        	this.cmFilterListN8.Name = "cmFilterListN8";
        	this.cmFilterListN8.Size = new System.Drawing.Size(181, 22);
        	this.cmFilterListN8.Text = "UnSet as Global";
        	this.cmFilterListN8.Click += new System.EventHandler(this.CmFilterListN1_Click);
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.label1);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel2.Location = new System.Drawing.Point(0, 0);
        	this.panel2.Margin = new System.Windows.Forms.Padding(4);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(221, 29);
        	this.panel2.TabIndex = 18;
        	// 
        	// label1
        	// 
        	this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(4, 6);
        	this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(89, 17);
        	this.label1.StarColor = System.Drawing.Color.Crimson;
        	this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label1.StarOffsetX = 2;
        	this.label1.StarOffsetY = 0;
        	this.label1.StarShow = false;
        	this.label1.StarText = "*";
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Filters:";
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbFilter1});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(845, 31);
        	this.toolStrip1.TabIndex = 8;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// tbFilter1
        	// 
        	this.tbFilter1.Checked = true;
        	this.tbFilter1.CheckOnClick = true;
        	this.tbFilter1.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.tbFilter1.Image = global::FBA.Resource.Prev_24;
        	this.tbFilter1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbFilter1.Name = "tbFilter1";
        	this.tbFilter1.Size = new System.Drawing.Size(59, 28);
        	this.tbFilter1.Text = "List";
        	this.tbFilter1.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// timer1
        	// 
        	this.timer1.Interval = 500;
        	this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.splitter1);
        	this.panel1.Controls.Add(this.panel4);
        	this.panel1.Controls.Add(this.pnlFilters);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel1.Location = new System.Drawing.Point(0, 31);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(845, 487);
        	this.panel1.TabIndex = 9;
        	// 
        	// splitter1
        	// 
        	this.splitter1.BackColor = System.Drawing.Color.LightSkyBlue;
        	this.splitter1.Location = new System.Drawing.Point(221, 0);
        	this.splitter1.Name = "splitter1";
        	this.splitter1.Size = new System.Drawing.Size(5, 487);
        	this.splitter1.TabIndex = 0;
        	this.splitter1.TabStop = false;
        	// 
        	// panel4
        	// 
        	this.panel4.Controls.Add(this.panelFilterView_Base);
        	this.panel4.Controls.Add(this.panelFilterUniversal_Base);
        	this.panel4.Controls.Add(this.panelFilterCustom_Base);
        	this.panel4.Controls.Add(this.panelFilterStatic_Base);
        	this.panel4.Controls.Add(this.pnlTab);
        	this.panel4.Controls.Add(this.panelFilterName);
        	this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel4.Location = new System.Drawing.Point(221, 0);
        	this.panel4.Name = "panel4";
        	this.panel4.Size = new System.Drawing.Size(624, 487);
        	this.panel4.TabIndex = 10;
        	// 
        	// panelFilterView_Base
        	// 
        	this.panelFilterView_Base.Controls.Add(this.splitContainerAttr);
        	this.panelFilterView_Base.Location = new System.Drawing.Point(18, 377);
        	this.panelFilterView_Base.Name = "panelFilterView_Base";
        	this.panelFilterView_Base.Size = new System.Drawing.Size(413, 104);
        	this.panelFilterView_Base.TabIndex = 27;
        	// 
        	// panelFilterUniversal_Base
        	// 
        	this.panelFilterUniversal_Base.Controls.Add(this.tbTextUniversal);
        	this.panelFilterUniversal_Base.Controls.Add(this.panelFilterUniversal2);
        	this.panelFilterUniversal_Base.Location = new System.Drawing.Point(19, 271);
        	this.panelFilterUniversal_Base.Name = "panelFilterUniversal_Base";
        	this.panelFilterUniversal_Base.Size = new System.Drawing.Size(413, 100);
        	this.panelFilterUniversal_Base.TabIndex = 26;
        	// 
        	// panelFilterCustom_Base
        	// 
        	this.panelFilterCustom_Base.Controls.Add(this.panelFilterCustom);
        	this.panelFilterCustom_Base.Controls.Add(this.panelFilterCustom2);
        	this.panelFilterCustom_Base.Location = new System.Drawing.Point(19, 172);
        	this.panelFilterCustom_Base.Name = "panelFilterCustom_Base";
        	this.panelFilterCustom_Base.Size = new System.Drawing.Size(597, 93);
        	this.panelFilterCustom_Base.TabIndex = 25;
        	// 
        	// panelFilterStatic_Base
        	// 
        	this.panelFilterStatic_Base.Controls.Add(this.panelFilterStatic);
        	this.panelFilterStatic_Base.Controls.Add(this.panelFilterStatic2);
        	this.panelFilterStatic_Base.Location = new System.Drawing.Point(19, 78);
        	this.panelFilterStatic_Base.Name = "panelFilterStatic_Base";
        	this.panelFilterStatic_Base.Size = new System.Drawing.Size(597, 88);
        	this.panelFilterStatic_Base.TabIndex = 24;
        	// 
        	// pnlTab
        	// 
        	this.pnlTab.Controls.Add(this.tableLayoutPanel1);
        	this.pnlTab.Controls.Add(this.btnViewSet);
        	this.pnlTab.Controls.Add(this.btnUniversalSet);
        	this.pnlTab.Controls.Add(this.btnCustomSet);
        	this.pnlTab.Controls.Add(this.btnStaticSet);
        	this.pnlTab.Dock = System.Windows.Forms.DockStyle.Top;
        	this.pnlTab.Location = new System.Drawing.Point(0, 29);
        	this.pnlTab.Name = "pnlTab";
        	this.pnlTab.Size = new System.Drawing.Size(624, 40);
        	this.pnlTab.TabIndex = 28;
        	// 
        	// tableLayoutPanel1
        	// 
        	this.tableLayoutPanel1.ColumnCount = 2;
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.tableLayoutPanel1.Location = new System.Drawing.Point(500, 5);
        	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        	this.tableLayoutPanel1.RowCount = 1;
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 31);
        	this.tableLayoutPanel1.TabIndex = 8;
        	// 
        	// btnViewSet
        	// 
        	this.btnViewSet.Appearance = System.Windows.Forms.Appearance.Button;
        	this.btnViewSet.BackColor = System.Drawing.SystemColors.Control;
        	this.btnViewSet.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnViewSet.ForeColor = System.Drawing.Color.Maroon;
        	this.btnViewSet.Location = new System.Drawing.Point(373, 3);
        	this.btnViewSet.Name = "btnViewSet";
        	this.btnViewSet.Size = new System.Drawing.Size(120, 33);
        	this.btnViewSet.TabIndex = 7;
        	this.btnViewSet.Text = "View";
        	this.btnViewSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	this.btnViewSet.UseVisualStyleBackColor = true;
        	this.btnViewSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnStaticSet_Click);
        	// 
        	// btnUniversalSet
        	// 
        	this.btnUniversalSet.Appearance = System.Windows.Forms.Appearance.Button;
        	this.btnUniversalSet.ForeColor = System.Drawing.Color.Navy;
        	this.btnUniversalSet.Location = new System.Drawing.Point(252, 3);
        	this.btnUniversalSet.Name = "btnUniversalSet";
        	this.btnUniversalSet.Size = new System.Drawing.Size(120, 33);
        	this.btnUniversalSet.TabIndex = 6;
        	this.btnUniversalSet.Text = "Universal";
        	this.btnUniversalSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	this.btnUniversalSet.UseVisualStyleBackColor = true;
        	this.btnUniversalSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnStaticSet_Click);
        	// 
        	// btnCustomSet
        	// 
        	this.btnCustomSet.Appearance = System.Windows.Forms.Appearance.Button;
        	this.btnCustomSet.ForeColor = System.Drawing.Color.Navy;
        	this.btnCustomSet.Location = new System.Drawing.Point(130, 3);
        	this.btnCustomSet.Name = "btnCustomSet";
        	this.btnCustomSet.Size = new System.Drawing.Size(120, 33);
        	this.btnCustomSet.TabIndex = 5;
        	this.btnCustomSet.Text = "Custom";
        	this.btnCustomSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	this.btnCustomSet.UseVisualStyleBackColor = true;
        	this.btnCustomSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnStaticSet_Click);
        	// 
        	// btnStaticSet
        	// 
        	this.btnStaticSet.Appearance = System.Windows.Forms.Appearance.Button;
        	this.btnStaticSet.AttrBrief = null;
        	this.btnStaticSet.ForeColor = System.Drawing.Color.Navy;
        	this.btnStaticSet.GroupEnabled = null;
        	this.btnStaticSet.Location = new System.Drawing.Point(8, 3);
        	this.btnStaticSet.Name = "btnStaticSet";
        	this.btnStaticSet.Obj = null;
        	this.btnStaticSet.ObjectRef = null;
        	this.btnStaticSet.SaveParam = false;
        	this.btnStaticSet.Size = new System.Drawing.Size(120, 33);
        	this.btnStaticSet.TabIndex = 4;
        	this.btnStaticSet.Text = "Static";
        	this.btnStaticSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	this.btnStaticSet.UseVisualStyleBackColor = true;
        	this.btnStaticSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnStaticSet_Click);
        	// 
        	// pnlFilters
        	// 
        	this.pnlFilters.Controls.Add(this.dgvList);
        	this.pnlFilters.Controls.Add(this.panel2);
        	this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
        	this.pnlFilters.Location = new System.Drawing.Point(0, 0);
        	this.pnlFilters.Name = "pnlFilters";
        	this.pnlFilters.Size = new System.Drawing.Size(221, 487);
        	this.pnlFilters.TabIndex = 19;
        	// 
        	// FormFilter
        	// 
        	this.ClientSize = new System.Drawing.Size(845, 559);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.panelButton);
        	this.Controls.Add(this.toolStrip1);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormFilter";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Filter";
        	this.Shown += new System.EventHandler(this.FormFilter_Shown);
        	this.splitContainerAttr.Panel1.ResumeLayout(false);
        	this.splitContainerAttr.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainerAttr)).EndInit();
        	this.splitContainerAttr.ResumeLayout(false);
        	this.panelAttrList.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvAttr)).EndInit();
        	this.cmAttr.ResumeLayout(false);
        	this.panelFormSplitter.ResumeLayout(false);
        	this.panelAttrListUp.ResumeLayout(false);
        	this.panelFilterStatic2.ResumeLayout(false);
        	this.panelFilterCustom2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.tbTextUniversal)).EndInit();
        	this.panelFilterUniversal2.ResumeLayout(false);
        	this.panelButton.ResumeLayout(false);
        	this.panelFilterName.ResumeLayout(false);
        	this.panelFilterName.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
        	this.cmFilterList.ResumeLayout(false);
        	this.panel2.ResumeLayout(false);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.panel1.ResumeLayout(false);
        	this.panel4.ResumeLayout(false);
        	this.panelFilterView_Base.ResumeLayout(false);
        	this.panelFilterUniversal_Base.ResumeLayout(false);
        	this.panelFilterCustom_Base.ResumeLayout(false);
        	this.panelFilterStatic_Base.ResumeLayout(false);
        	this.pnlTab.ResumeLayout(false);
        	this.pnlFilters.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button tbFilter3;
        private System.Windows.Forms.Button tbFilter2;
    }
}
