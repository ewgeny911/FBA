
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 03.06.2017
 * Время: 12:20  
 */
 
namespace FBA
{
	partial class FormParser
	{		  
		private System.ComponentModel.IContainer components = null;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParser));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnParse = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbTest = new System.Windows.Forms.CheckBox();
			this.cbPsevdominEntity = new FBA.ComboBoxFBA();
			this.label2 = new FBA.LabelFBA();
			this.cbOnTop = new System.Windows.Forms.CheckBox();
			this.btnSaveMSQL = new System.Windows.Forms.Button();
			this.btnParserCreateTable = new System.Windows.Forms.Button();
			this.btnShowColumns = new System.Windows.Forms.Button();
			this.btnHideColumns = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbListSQL = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.ListBox1 = new System.Windows.Forms.ListBox();
			this.cmTestList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmTestList_N1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cmTestList_N2 = new System.Windows.Forms.ToolStripMenuItem();
			this.ListSQL = new FastColoredTextBoxNS.FastColoredTextBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.ListResult = new FastColoredTextBoxNS.FastColoredTextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.btnSQL9 = new System.Windows.Forms.Button();
			this.lbResultRun = new System.Windows.Forms.Label();
			this.btnSQL8 = new System.Windows.Forms.Button();
			this.btnSQL7 = new System.Windows.Forms.Button();
			this.btnSQL6 = new System.Windows.Forms.Button();
			this.btnSQL5 = new System.Windows.Forms.Button();
			this.progressBarParser = new System.Windows.Forms.ProgressBar();
			this.btnSQL4 = new System.Windows.Forms.Button();
			this.btnSQL3 = new System.Windows.Forms.Button();
			this.btnSQL2 = new System.Windows.Forms.Button();
			this.btnSQL1 = new System.Windows.Forms.Button();
			this.tbQuery = new System.Windows.Forms.TabPage();
			this.line1 = new DevAge.Windows.Forms.Line();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.textQuery = new FastColoredTextBoxNS.FastColoredTextBox();
			this.tabControlResult = new System.Windows.Forms.TabControl();
			this.tbText = new System.Windows.Forms.TabPage();
			this.TexBoxResult = new FastColoredTextBoxNS.FastColoredTextBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnSyntax = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnExecute = new System.Windows.Forms.Button();
			this.tbResult = new System.Windows.Forms.TabPage();
			this.dgvResult = new FBA.DataGridViewFBA();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbTime = new FBA.LabelFBA();
			this.tbWords = new System.Windows.Forms.TabPage();
			this.dgvString = new FBA.DataGridViewFBA();
			this.cmWords = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmWords_N1 = new System.Windows.Forms.ToolStripMenuItem();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tbTime = new System.Windows.Forms.TabPage();
			this.txTime = new System.Windows.Forms.TextBox();
			this.tbEntity = new System.Windows.Forms.TabPage();
			this.dgvEntity = new FBA.DataGridViewFBA();
			this.tbAttrParent = new System.Windows.Forms.TabPage();
			this.dgvAttrParent = new FBA.DataGridViewFBA();
			this.tbListEntity = new System.Windows.Forms.TabPage();
			this.dgvListEntity = new FBA.DataGridViewFBA();
			this.tbListTable = new System.Windows.Forms.TabPage();
			this.dgvListTable = new FBA.DataGridViewFBA();
			this.tbUserString = new System.Windows.Forms.TabPage();
			this.dgvUserString = new FBA.DataGridViewFBA();
			this.tbAttrTable = new System.Windows.Forms.TabPage();
			this.dgvAttrTable = new FBA.DataGridViewFBA();
			this.tbStateDate = new System.Windows.Forms.TabPage();
			this.dgvStateDate = new FBA.DataGridViewFBA();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.TextResult = new System.Windows.Forms.TextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.componentLight1 = new DevAge.ComponentModel.ComponentLight();
			this.imageListAttr = new System.Windows.Forms.ImageList(this.components);
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tbListSQL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.cmTestList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ListSQL)).BeginInit();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ListResult)).BeginInit();
			this.panel7.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tbQuery.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textQuery)).BeginInit();
			this.tabControlResult.SuspendLayout();
			this.tbText.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TexBoxResult)).BeginInit();
			this.panel6.SuspendLayout();
			this.tbResult.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
			this.panel4.SuspendLayout();
			this.tbWords.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvString)).BeginInit();
			this.cmWords.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tbTime.SuspendLayout();
			this.tbEntity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).BeginInit();
			this.tbAttrParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAttrParent)).BeginInit();
			this.tbListEntity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListEntity)).BeginInit();
			this.tbListTable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListTable)).BeginInit();
			this.tbUserString.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUserString)).BeginInit();
			this.tbAttrTable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAttrTable)).BeginInit();
			this.tbStateDate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStateDate)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnParse
			// 
			this.btnParse.Location = new System.Drawing.Point(7, 3);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(101, 32);
			this.btnParse.TabIndex = 0;
			this.btnParse.Text = "Parse";
			this.btnParse.UseVisualStyleBackColor = true;
			this.btnParse.Click += new System.EventHandler(this.BtnParseClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbTest);
			this.panel1.Controls.Add(this.cbPsevdominEntity);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cbOnTop);
			this.panel1.Controls.Add(this.btnParse);
			this.panel1.Controls.Add(this.btnSaveMSQL);
			this.panel1.Controls.Add(this.btnParserCreateTable);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1346, 37);
			this.panel1.TabIndex = 1;
			// 
			// cbTest
			// 
			this.cbTest.Location = new System.Drawing.Point(474, 7);
			this.cbTest.Name = "cbTest";
			this.cbTest.Size = new System.Drawing.Size(140, 24);
			this.cbTest.TabIndex = 7;
			this.cbTest.Text = "Show message";
			this.cbTest.UseVisualStyleBackColor = true;
			this.cbTest.CheckedChanged += new System.EventHandler(this.cbTest_CheckedChanged);
			// 
			// cbPsevdominEntity
			// 
			this.cbPsevdominEntity.FormattingEnabled = true;
			this.cbPsevdominEntity.Items.AddRange(new object[] {
			"",
			"ФЛ",
			"ЮЛ",
			"Лицо",
			"Агент",
			"ДогСтрах",
			"Застрахованный",
			"ВариантЗастрахованный",
			"ВариантДогСтрах"});
			this.cbPsevdominEntity.Location = new System.Drawing.Point(790, 7);
			this.cbPsevdominEntity.Name = "cbPsevdominEntity";
			this.cbPsevdominEntity.Size = new System.Drawing.Size(226, 26);
			this.cbPsevdominEntity.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(621, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(166, 23);
			this.label2.StarColor = System.Drawing.Color.Crimson;
			this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
			this.label2.StarOffsetX = 2;
			this.label2.StarOffsetY = 0;
			this.label2.StarShow = false;
			this.label2.StarText = "*";
			this.label2.TabIndex = 5;
			this.label2.Text = "ПсевдонимСущности";
			// 
			// cbOnTop
			// 
			this.cbOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbOnTop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbOnTop.Location = new System.Drawing.Point(1220, 8);
			this.cbOnTop.Name = "cbOnTop";
			this.cbOnTop.Size = new System.Drawing.Size(115, 20);
			this.cbOnTop.TabIndex = 6;
			this.cbOnTop.Text = "Always on top";
			this.cbOnTop.UseVisualStyleBackColor = true;
			this.cbOnTop.CheckedChanged += new System.EventHandler(this.CbOnTopCheckedChanged);
			this.cbOnTop.Click += new System.EventHandler(this.CbOnTopClick);
			// 
			// btnSaveMSQL
			// 
			this.btnSaveMSQL.Location = new System.Drawing.Point(114, 3);
			this.btnSaveMSQL.Name = "btnSaveMSQL";
			this.btnSaveMSQL.Size = new System.Drawing.Size(132, 32);
			this.btnSaveMSQL.TabIndex = 3;
			this.btnSaveMSQL.Text = "Save MSQL";
			this.btnSaveMSQL.UseVisualStyleBackColor = true;
			this.btnSaveMSQL.Click += new System.EventHandler(this.BtnSaveMSQLClick);
			// 
			// btnParserCreateTable
			// 
			this.btnParserCreateTable.Location = new System.Drawing.Point(252, 3);
			this.btnParserCreateTable.Name = "btnParserCreateTable";
			this.btnParserCreateTable.Size = new System.Drawing.Size(216, 32);
			this.btnParserCreateTable.TabIndex = 4;
			this.btnParserCreateTable.Text = "Refresh tables for parser";
			this.btnParserCreateTable.UseVisualStyleBackColor = true;
			this.btnParserCreateTable.Click += new System.EventHandler(this.BtnParserCreateTableClick);
			// 
			// btnShowColumns
			// 
			this.btnShowColumns.Location = new System.Drawing.Point(161, 3);
			this.btnShowColumns.Name = "btnShowColumns";
			this.btnShowColumns.Size = new System.Drawing.Size(166, 32);
			this.btnShowColumns.TabIndex = 7;
			this.btnShowColumns.Text = "Show columns";
			this.btnShowColumns.UseVisualStyleBackColor = true;
			this.btnShowColumns.Click += new System.EventHandler(this.BtnShowColumnsClick);
			// 
			// btnHideColumns
			// 
			this.btnHideColumns.Location = new System.Drawing.Point(5, 3);
			this.btnHideColumns.Name = "btnHideColumns";
			this.btnHideColumns.Size = new System.Drawing.Size(150, 32);
			this.btnHideColumns.TabIndex = 4;
			this.btnHideColumns.Text = "Hide columns";
			this.btnHideColumns.UseVisualStyleBackColor = true;
			this.btnHideColumns.Click += new System.EventHandler(this.BtnHideColumnsClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbListSQL);
			this.tabControl1.Controls.Add(this.tbQuery);
			this.tabControl1.Controls.Add(this.tbWords);
			this.tabControl1.Controls.Add(this.tbTime);
			this.tabControl1.Controls.Add(this.tbEntity);
			this.tabControl1.Controls.Add(this.tbAttrParent);
			this.tabControl1.Controls.Add(this.tbListEntity);
			this.tabControl1.Controls.Add(this.tbListTable);
			this.tabControl1.Controls.Add(this.tbUserString);
			this.tabControl1.Controls.Add(this.tbAttrTable);
			this.tabControl1.Controls.Add(this.tbStateDate);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabControl1.Location = new System.Drawing.Point(0, 37);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1346, 516);
			this.tabControl1.TabIndex = 3;
			// 
			// tbListSQL
			// 
			this.tbListSQL.Controls.Add(this.splitContainer2);
			this.tbListSQL.Controls.Add(this.panel2);
			this.tbListSQL.Location = new System.Drawing.Point(4, 26);
			this.tbListSQL.Name = "tbListSQL";
			this.tbListSQL.Padding = new System.Windows.Forms.Padding(3);
			this.tbListSQL.Size = new System.Drawing.Size(1338, 486);
			this.tbListSQL.TabIndex = 12;
			this.tbListSQL.Text = "List SQL";
			this.tbListSQL.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 42);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.ListBox1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.ListSQL);
			this.splitContainer2.Panel2.Controls.Add(this.panel5);
			this.splitContainer2.Size = new System.Drawing.Size(1332, 441);
			this.splitContainer2.SplitterDistance = 442;
			this.splitContainer2.TabIndex = 0;
			// 
			// ListBox1
			// 
			this.ListBox1.BackColor = System.Drawing.SystemColors.Info;
			this.ListBox1.ContextMenuStrip = this.cmTestList;
			this.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.ItemHeight = 17;
			this.ListBox1.Location = new System.Drawing.Point(0, 0);
			this.ListBox1.Name = "ListBox1";
			this.ListBox1.Size = new System.Drawing.Size(442, 441);
			this.ListBox1.TabIndex = 0;
			this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
			// 
			// cmTestList
			// 
			this.cmTestList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmTestList_N1,
			this.cmTestList_N2});
			this.cmTestList.Name = "cmTestList";
			this.cmTestList.Size = new System.Drawing.Size(217, 48);
			// 
			// cmTestList_N1
			// 
			this.cmTestList_N1.Name = "cmTestList_N1";
			this.cmTestList_N1.Size = new System.Drawing.Size(216, 22);
			this.cmTestList_N1.Text = "Unit Test";
			this.cmTestList_N1.Click += new System.EventHandler(this.cmTestList_N1_Click);
			// 
			// cmTestList_N2
			// 
			this.cmTestList_N2.Name = "cmTestList_N2";
			this.cmTestList_N2.Size = new System.Drawing.Size(216, 22);
			this.cmTestList_N2.Text = "Check syntax parsed Query";
			this.cmTestList_N2.Click += new System.EventHandler(this.cmTestList_N1_Click);
			// 
			// ListSQL
			// 
			this.ListSQL.AutoCompleteBracketsList = new char[] {
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
			this.ListSQL.AutoIndentCharsPatterns = "";
			this.ListSQL.AutoScrollMinSize = new System.Drawing.Size(770, 315);
			this.ListSQL.BackBrush = null;
			this.ListSQL.BookmarkColor = System.Drawing.Color.Red;
			this.ListSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ListSQL.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.ListSQL.CharHeight = 21;
			this.ListSQL.CharWidth = 11;
			this.ListSQL.CommentPrefix = "--";
			this.ListSQL.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ListSQL.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.ListSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListSQL.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.ListSQL.Font = new System.Drawing.Font("Courier New", 14.25F);
			this.ListSQL.IsReplaceMode = false;
			this.ListSQL.Language = FastColoredTextBoxNS.Language.SQL;
			this.ListSQL.LeftBracket = '(';
			this.ListSQL.Location = new System.Drawing.Point(0, 0);
			this.ListSQL.Name = "ListSQL";
			this.ListSQL.Paddings = new System.Windows.Forms.Padding(0);
			this.ListSQL.RightBracket = ')';
			this.ListSQL.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.ListSQL.Size = new System.Drawing.Size(886, 341);
			this.ListSQL.TabIndex = 18;
			this.ListSQL.Text = resources.GetString("ListSQL.Text");
			this.ListSQL.VirtualSpace = true;
			this.ListSQL.Zoom = 100;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.ListResult);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(0, 341);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(886, 100);
			this.panel5.TabIndex = 19;
			// 
			// ListResult
			// 
			this.ListResult.AutoCompleteBracketsList = new char[] {
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
			this.ListResult.AutoIndentCharsPatterns = "";
			this.ListResult.AutoScrollMinSize = new System.Drawing.Size(33, 42);
			this.ListResult.BackBrush = null;
			this.ListResult.BookmarkColor = System.Drawing.Color.Red;
			this.ListResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ListResult.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.ListResult.CharHeight = 21;
			this.ListResult.CharWidth = 11;
			this.ListResult.CommentPrefix = "--";
			this.ListResult.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ListResult.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.ListResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListResult.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.ListResult.Font = new System.Drawing.Font("Courier New", 14.25F);
			this.ListResult.IsReplaceMode = false;
			this.ListResult.Language = FastColoredTextBoxNS.Language.SQL;
			this.ListResult.LeftBracket = '(';
			this.ListResult.Location = new System.Drawing.Point(0, 24);
			this.ListResult.Name = "ListResult";
			this.ListResult.Paddings = new System.Windows.Forms.Padding(0);
			this.ListResult.RightBracket = ')';
			this.ListResult.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.ListResult.Size = new System.Drawing.Size(886, 76);
			this.ListResult.TabIndex = 19;
			this.ListResult.Text = "\r\n";
			this.ListResult.VirtualSpace = true;
			this.ListResult.Zoom = 100;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.label3);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(886, 24);
			this.panel7.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(192, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Должен быть результат";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.btnSQL9);
			this.panel2.Controls.Add(this.lbResultRun);
			this.panel2.Controls.Add(this.btnSQL8);
			this.panel2.Controls.Add(this.btnSQL7);
			this.panel2.Controls.Add(this.btnSQL6);
			this.panel2.Controls.Add(this.btnSQL5);
			this.panel2.Controls.Add(this.progressBarParser);
			this.panel2.Controls.Add(this.btnSQL4);
			this.panel2.Controls.Add(this.btnSQL3);
			this.panel2.Controls.Add(this.btnSQL2);
			this.panel2.Controls.Add(this.btnSQL1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1332, 39);
			this.panel2.TabIndex = 1;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1229, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 12;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// btnSQL9
			// 
			this.btnSQL9.Location = new System.Drawing.Point(648, 3);
			this.btnSQL9.Name = "btnSQL9";
			this.btnSQL9.Size = new System.Drawing.Size(83, 32);
			this.btnSQL9.TabIndex = 11;
			this.btnSQL9.Text = "Test Work";
			this.btnSQL9.UseVisualStyleBackColor = true;
			this.btnSQL9.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// lbResultRun
			// 
			this.lbResultRun.Location = new System.Drawing.Point(974, 11);
			this.lbResultRun.Name = "lbResultRun";
			this.lbResultRun.Size = new System.Drawing.Size(300, 23);
			this.lbResultRun.TabIndex = 10;
			this.lbResultRun.Text = "Результат проверки:";
			// 
			// btnSQL8
			// 
			this.btnSQL8.Location = new System.Drawing.Point(395, 3);
			this.btnSQL8.Name = "btnSQL8";
			this.btnSQL8.Size = new System.Drawing.Size(75, 32);
			this.btnSQL8.TabIndex = 9;
			this.btnSQL8.Text = "Refresh";
			this.btnSQL8.UseVisualStyleBackColor = true;
			this.btnSQL8.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// btnSQL7
			// 
			this.btnSQL7.Location = new System.Drawing.Point(317, 3);
			this.btnSQL7.Name = "btnSQL7";
			this.btnSQL7.Size = new System.Drawing.Size(75, 32);
			this.btnSQL7.TabIndex = 8;
			this.btnSQL7.Text = "Rename";
			this.btnSQL7.UseVisualStyleBackColor = true;
			this.btnSQL7.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// btnSQL6
			// 
			this.btnSQL6.Location = new System.Drawing.Point(737, 4);
			this.btnSQL6.Name = "btnSQL6";
			this.btnSQL6.Size = new System.Drawing.Size(83, 32);
			this.btnSQL6.TabIndex = 7;
			this.btnSQL6.Text = "Test Exec";
			this.btnSQL6.UseVisualStyleBackColor = true;
			this.btnSQL6.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// btnSQL5
			// 
			this.btnSQL5.Location = new System.Drawing.Point(489, 3);
			this.btnSQL5.Name = "btnSQL5";
			this.btnSQL5.Size = new System.Drawing.Size(93, 32);
			this.btnSQL5.TabIndex = 6;
			this.btnSQL5.Text = "Test Parse";
			this.btnSQL5.UseVisualStyleBackColor = true;
			this.btnSQL5.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// progressBarParser
			// 
			this.progressBarParser.Location = new System.Drawing.Point(826, 10);
			this.progressBarParser.Maximum = 4;
			this.progressBarParser.Name = "progressBarParser";
			this.progressBarParser.Size = new System.Drawing.Size(133, 23);
			this.progressBarParser.TabIndex = 5;
			this.progressBarParser.Value = 3;
			// 
			// btnSQL4
			// 
			this.btnSQL4.Location = new System.Drawing.Point(239, 3);
			this.btnSQL4.Name = "btnSQL4";
			this.btnSQL4.Size = new System.Drawing.Size(75, 32);
			this.btnSQL4.TabIndex = 3;
			this.btnSQL4.Text = "Use";
			this.btnSQL4.UseVisualStyleBackColor = true;
			this.btnSQL4.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// btnSQL3
			// 
			this.btnSQL3.Location = new System.Drawing.Point(161, 3);
			this.btnSQL3.Name = "btnSQL3";
			this.btnSQL3.Size = new System.Drawing.Size(75, 32);
			this.btnSQL3.TabIndex = 2;
			this.btnSQL3.Text = "Save";
			this.btnSQL3.UseVisualStyleBackColor = true;
			this.btnSQL3.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// btnSQL2
			// 
			this.btnSQL2.Location = new System.Drawing.Point(83, 3);
			this.btnSQL2.Name = "btnSQL2";
			this.btnSQL2.Size = new System.Drawing.Size(75, 32);
			this.btnSQL2.TabIndex = 1;
			this.btnSQL2.Text = "Delete";
			this.btnSQL2.UseVisualStyleBackColor = true;
			this.btnSQL2.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// btnSQL1
			// 
			this.btnSQL1.Location = new System.Drawing.Point(5, 3);
			this.btnSQL1.Name = "btnSQL1";
			this.btnSQL1.Size = new System.Drawing.Size(75, 32);
			this.btnSQL1.TabIndex = 0;
			this.btnSQL1.Text = "Add";
			this.btnSQL1.UseVisualStyleBackColor = true;
			this.btnSQL1.Click += new System.EventHandler(this.BtnSQL1Click);
			// 
			// tbQuery
			// 
			this.tbQuery.Controls.Add(this.line1);
			this.tbQuery.Controls.Add(this.splitContainer1);
			this.tbQuery.Location = new System.Drawing.Point(4, 26);
			this.tbQuery.Name = "tbQuery";
			this.tbQuery.Padding = new System.Windows.Forms.Padding(3);
			this.tbQuery.Size = new System.Drawing.Size(1338, 486);
			this.tbQuery.TabIndex = 0;
			this.tbQuery.Text = "Query";
			this.tbQuery.UseVisualStyleBackColor = true;
			// 
			// line1
			// 
			this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.line1.FirstColor = System.Drawing.SystemColors.ControlDark;
			this.line1.LineStyle = DevAge.Windows.Forms.LineStyle.Horizontal;
			this.line1.Location = new System.Drawing.Point(8, 45);
			this.line1.Name = "line1";
			this.line1.SecondColor = System.Drawing.SystemColors.ControlLightLight;
			this.line1.Size = new System.Drawing.Size(140, 2);
			this.line1.TabIndex = 3;
			this.line1.TabStop = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.textQuery);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControlResult);
			this.splitContainer1.Size = new System.Drawing.Size(1332, 480);
			this.splitContainer1.SplitterDistance = 294;
			this.splitContainer1.TabIndex = 2;
			// 
			// textQuery
			// 
			this.textQuery.AutoCompleteBracketsList = new char[] {
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
			this.textQuery.AutoIndentCharsPatterns = "";
			this.textQuery.AutoScrollMinSize = new System.Drawing.Size(728, 315);
			this.textQuery.BackBrush = null;
			this.textQuery.BookmarkColor = System.Drawing.Color.Red;
			this.textQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textQuery.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.textQuery.CharHeight = 21;
			this.textQuery.CharWidth = 11;
			this.textQuery.CommentPrefix = "--";
			this.textQuery.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textQuery.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.textQuery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textQuery.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.textQuery.Font = new System.Drawing.Font("Courier New", 14.25F);
			this.textQuery.IsReplaceMode = false;
			this.textQuery.Language = FastColoredTextBoxNS.Language.SQL;
			this.textQuery.LeftBracket = '(';
			this.textQuery.Location = new System.Drawing.Point(0, 0);
			this.textQuery.Name = "textQuery";
			this.textQuery.Paddings = new System.Windows.Forms.Padding(0);
			this.textQuery.RightBracket = ')';
			this.textQuery.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.textQuery.Size = new System.Drawing.Size(1332, 294);
			this.textQuery.TabIndex = 17;
			this.textQuery.Text = resources.GetString("textQuery.Text");
			this.textQuery.VirtualSpace = true;
			this.textQuery.Zoom = 100;
			// 
			// tabControlResult
			// 
			this.tabControlResult.Controls.Add(this.tbText);
			this.tabControlResult.Controls.Add(this.tbResult);
			this.tabControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlResult.Location = new System.Drawing.Point(0, 0);
			this.tabControlResult.Name = "tabControlResult";
			this.tabControlResult.SelectedIndex = 0;
			this.tabControlResult.Size = new System.Drawing.Size(1332, 182);
			this.tabControlResult.TabIndex = 19;
			// 
			// tbText
			// 
			this.tbText.Controls.Add(this.TexBoxResult);
			this.tbText.Controls.Add(this.panel6);
			this.tbText.Location = new System.Drawing.Point(4, 26);
			this.tbText.Name = "tbText";
			this.tbText.Padding = new System.Windows.Forms.Padding(3);
			this.tbText.Size = new System.Drawing.Size(1324, 152);
			this.tbText.TabIndex = 0;
			this.tbText.Text = "Query text";
			this.tbText.UseVisualStyleBackColor = true;
			// 
			// TexBoxResult
			// 
			this.TexBoxResult.AutoCompleteBracketsList = new char[] {
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
			this.TexBoxResult.AutoIndentCharsPatterns = "";
			this.TexBoxResult.AutoScrollMinSize = new System.Drawing.Size(2, 16);
			this.TexBoxResult.BackBrush = null;
			this.TexBoxResult.BackColor = System.Drawing.Color.Gainsboro;
			this.TexBoxResult.BookmarkColor = System.Drawing.Color.Red;
			this.TexBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TexBoxResult.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.TexBoxResult.CharHeight = 16;
			this.TexBoxResult.CharWidth = 9;
			this.TexBoxResult.CommentPrefix = "--";
			this.TexBoxResult.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.TexBoxResult.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.TexBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TexBoxResult.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.TexBoxResult.Font = new System.Drawing.Font("Courier New", 11.25F);
			this.TexBoxResult.IsReplaceMode = false;
			this.TexBoxResult.Language = FastColoredTextBoxNS.Language.SQL;
			this.TexBoxResult.LeftBracket = '(';
			this.TexBoxResult.Location = new System.Drawing.Point(3, 31);
			this.TexBoxResult.Name = "TexBoxResult";
			this.TexBoxResult.Paddings = new System.Windows.Forms.Padding(0);
			this.TexBoxResult.RightBracket = ')';
			this.TexBoxResult.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.TexBoxResult.Size = new System.Drawing.Size(1318, 118);
			this.TexBoxResult.TabIndex = 18;
			this.TexBoxResult.VirtualSpace = true;
			this.TexBoxResult.Zoom = 100;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btnSyntax);
			this.panel6.Controls.Add(this.btnCopy);
			this.panel6.Controls.Add(this.btnExecute);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(3, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(1318, 28);
			this.panel6.TabIndex = 19;
			// 
			// btnSyntax
			// 
			this.btnSyntax.Location = new System.Drawing.Point(239, 1);
			this.btnSyntax.Name = "btnSyntax";
			this.btnSyntax.Size = new System.Drawing.Size(159, 26);
			this.btnSyntax.TabIndex = 2;
			this.btnSyntax.Text = "Check syntax query";
			this.btnSyntax.UseVisualStyleBackColor = true;
			this.btnSyntax.Click += new System.EventHandler(this.btnSyntax_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(78, 1);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(159, 26);
			this.btnCopy.TabIndex = 1;
			this.btnCopy.Text = "Copy to clipboard";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(1, 1);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(75, 26);
			this.btnExecute.TabIndex = 0;
			this.btnExecute.Text = "Execute";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// tbResult
			// 
			this.tbResult.Controls.Add(this.dgvResult);
			this.tbResult.Controls.Add(this.panel4);
			this.tbResult.Location = new System.Drawing.Point(4, 26);
			this.tbResult.Name = "tbResult";
			this.tbResult.Padding = new System.Windows.Forms.Padding(3);
			this.tbResult.Size = new System.Drawing.Size(1324, 152);
			this.tbResult.TabIndex = 1;
			this.tbResult.Text = "Result";
			this.tbResult.UseVisualStyleBackColor = true;
			// 
			// dgvResult
			// 
			this.dgvResult.AllowUserToAddRows = false;
			this.dgvResult.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResult.CommandAdd = false;
			this.dgvResult.CommandDel = false;
			this.dgvResult.CommandEdit = false;
			this.dgvResult.CommandExportToExcel = false;
			this.dgvResult.CommandFilter = false;
			this.dgvResult.CommandRefresh = false;
			this.dgvResult.CommandSaveASCSV = false;
			this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvResult.EnableHeadersVisualStyles = false;
			this.dgvResult.GroupEnabled = null;
			this.dgvResult.Location = new System.Drawing.Point(3, 31);
			this.dgvResult.Name = "dgvResult";
			this.dgvResult.Obj = null;
			this.dgvResult.PassedSec = null;
			this.dgvResult.ReadOnly = true;
			this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvResult.Size = new System.Drawing.Size(1318, 118);
			this.dgvResult.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbTime);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(1318, 28);
			this.panel4.TabIndex = 0;
			// 
			// lbTime
			// 
			this.lbTime.Location = new System.Drawing.Point(3, 5);
			this.lbTime.Name = "lbTime";
			this.lbTime.Size = new System.Drawing.Size(797, 18);
			this.lbTime.StarColor = System.Drawing.Color.Crimson;
			this.lbTime.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbTime.StarOffsetX = 2;
			this.lbTime.StarOffsetY = 0;
			this.lbTime.StarShow = false;
			this.lbTime.StarText = "*";
			this.lbTime.TabIndex = 0;
			this.lbTime.Text = "Time:";
			// 
			// tbWords
			// 
			this.tbWords.Controls.Add(this.dgvString);
			this.tbWords.Controls.Add(this.panel3);
			this.tbWords.Location = new System.Drawing.Point(4, 26);
			this.tbWords.Name = "tbWords";
			this.tbWords.Padding = new System.Windows.Forms.Padding(3);
			this.tbWords.Size = new System.Drawing.Size(1338, 486);
			this.tbWords.TabIndex = 1;
			this.tbWords.Text = "Words";
			this.tbWords.UseVisualStyleBackColor = true;
			// 
			// dgvString
			// 
			this.dgvString.AllowUserToAddRows = false;
			this.dgvString.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvString.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvString.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvString.CommandAdd = false;
			this.dgvString.CommandDel = false;
			this.dgvString.CommandEdit = false;
			this.dgvString.CommandExportToExcel = false;
			this.dgvString.CommandFilter = false;
			this.dgvString.CommandRefresh = false;
			this.dgvString.CommandSaveASCSV = false;
			this.dgvString.ContextMenuStrip = this.cmWords;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvString.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvString.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvString.EnableHeadersVisualStyles = false;
			this.dgvString.GroupEnabled = null;
			this.dgvString.Location = new System.Drawing.Point(3, 42);
			this.dgvString.Name = "dgvString";
			this.dgvString.Obj = null;
			this.dgvString.PassedSec = null;
			this.dgvString.ReadOnly = true;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvString.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvString.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvString.Size = new System.Drawing.Size(1332, 441);
			this.dgvString.TabIndex = 0;
			this.dgvString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvString_KeyDown);
			// 
			// cmWords
			// 
			this.cmWords.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmWords_N1});
			this.cmWords.Name = "cmWords";
			this.cmWords.Size = new System.Drawing.Size(110, 26);
			// 
			// cmWords_N1
			// 
			this.cmWords_N1.Name = "cmWords_N1";
			this.cmWords_N1.Size = new System.Drawing.Size(109, 22);
			this.cmWords_N1.Text = "Search";
			this.cmWords_N1.Click += new System.EventHandler(this.cmWords_N1_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnShowColumns);
			this.panel3.Controls.Add(this.btnHideColumns);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1332, 39);
			this.panel3.TabIndex = 1;
			// 
			// tbTime
			// 
			this.tbTime.Controls.Add(this.txTime);
			this.tbTime.Location = new System.Drawing.Point(4, 26);
			this.tbTime.Name = "tbTime";
			this.tbTime.Padding = new System.Windows.Forms.Padding(3);
			this.tbTime.Size = new System.Drawing.Size(1338, 486);
			this.tbTime.TabIndex = 2;
			this.tbTime.Text = "Time";
			this.tbTime.UseVisualStyleBackColor = true;
			// 
			// txTime
			// 
			this.txTime.BackColor = System.Drawing.SystemColors.Info;
			this.txTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txTime.Location = new System.Drawing.Point(3, 3);
			this.txTime.Multiline = true;
			this.txTime.Name = "txTime";
			this.txTime.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txTime.Size = new System.Drawing.Size(1332, 480);
			this.txTime.TabIndex = 0;
			// 
			// tbEntity
			// 
			this.tbEntity.Controls.Add(this.dgvEntity);
			this.tbEntity.Location = new System.Drawing.Point(4, 26);
			this.tbEntity.Name = "tbEntity";
			this.tbEntity.Padding = new System.Windows.Forms.Padding(3);
			this.tbEntity.Size = new System.Drawing.Size(1338, 486);
			this.tbEntity.TabIndex = 3;
			this.tbEntity.Text = "Entity";
			this.tbEntity.UseVisualStyleBackColor = true;
			// 
			// dgvEntity
			// 
			this.dgvEntity.AllowUserToAddRows = false;
			this.dgvEntity.AllowUserToDeleteRows = false;
			this.dgvEntity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEntity.CommandAdd = false;
			this.dgvEntity.CommandDel = false;
			this.dgvEntity.CommandEdit = false;
			this.dgvEntity.CommandExportToExcel = false;
			this.dgvEntity.CommandFilter = false;
			this.dgvEntity.CommandRefresh = false;
			this.dgvEntity.CommandSaveASCSV = false;
			this.dgvEntity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvEntity.EnableHeadersVisualStyles = false;
			this.dgvEntity.GroupEnabled = null;
			this.dgvEntity.Location = new System.Drawing.Point(3, 3);
			this.dgvEntity.Name = "dgvEntity";
			this.dgvEntity.Obj = null;
			this.dgvEntity.PassedSec = null;
			this.dgvEntity.ReadOnly = true;
			this.dgvEntity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvEntity.Size = new System.Drawing.Size(1332, 480);
			this.dgvEntity.TabIndex = 1;
			// 
			// tbAttrParent
			// 
			this.tbAttrParent.Controls.Add(this.dgvAttrParent);
			this.tbAttrParent.Location = new System.Drawing.Point(4, 26);
			this.tbAttrParent.Name = "tbAttrParent";
			this.tbAttrParent.Padding = new System.Windows.Forms.Padding(3);
			this.tbAttrParent.Size = new System.Drawing.Size(1338, 486);
			this.tbAttrParent.TabIndex = 14;
			this.tbAttrParent.Text = "AttrParent";
			this.tbAttrParent.UseVisualStyleBackColor = true;
			// 
			// dgvAttrParent
			// 
			this.dgvAttrParent.AllowUserToAddRows = false;
			this.dgvAttrParent.AllowUserToDeleteRows = false;
			this.dgvAttrParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAttrParent.CommandAdd = false;
			this.dgvAttrParent.CommandDel = false;
			this.dgvAttrParent.CommandEdit = false;
			this.dgvAttrParent.CommandExportToExcel = false;
			this.dgvAttrParent.CommandFilter = false;
			this.dgvAttrParent.CommandRefresh = false;
			this.dgvAttrParent.CommandSaveASCSV = false;
			this.dgvAttrParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAttrParent.EnableHeadersVisualStyles = false;
			this.dgvAttrParent.GroupEnabled = null;
			this.dgvAttrParent.Location = new System.Drawing.Point(3, 3);
			this.dgvAttrParent.Name = "dgvAttrParent";
			this.dgvAttrParent.Obj = null;
			this.dgvAttrParent.PassedSec = null;
			this.dgvAttrParent.ReadOnly = true;
			this.dgvAttrParent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAttrParent.Size = new System.Drawing.Size(1332, 480);
			this.dgvAttrParent.TabIndex = 5;
			// 
			// tbListEntity
			// 
			this.tbListEntity.Controls.Add(this.dgvListEntity);
			this.tbListEntity.Location = new System.Drawing.Point(4, 26);
			this.tbListEntity.Name = "tbListEntity";
			this.tbListEntity.Padding = new System.Windows.Forms.Padding(3);
			this.tbListEntity.Size = new System.Drawing.Size(1338, 486);
			this.tbListEntity.TabIndex = 9;
			this.tbListEntity.Text = "ListEntity";
			this.tbListEntity.UseVisualStyleBackColor = true;
			// 
			// dgvListEntity
			// 
			this.dgvListEntity.AllowUserToAddRows = false;
			this.dgvListEntity.AllowUserToDeleteRows = false;
			this.dgvListEntity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvListEntity.CommandAdd = false;
			this.dgvListEntity.CommandDel = false;
			this.dgvListEntity.CommandEdit = false;
			this.dgvListEntity.CommandExportToExcel = false;
			this.dgvListEntity.CommandFilter = false;
			this.dgvListEntity.CommandRefresh = false;
			this.dgvListEntity.CommandSaveASCSV = false;
			this.dgvListEntity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvListEntity.EnableHeadersVisualStyles = false;
			this.dgvListEntity.GroupEnabled = null;
			this.dgvListEntity.Location = new System.Drawing.Point(3, 3);
			this.dgvListEntity.Name = "dgvListEntity";
			this.dgvListEntity.Obj = null;
			this.dgvListEntity.PassedSec = null;
			this.dgvListEntity.ReadOnly = true;
			this.dgvListEntity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListEntity.Size = new System.Drawing.Size(1332, 480);
			this.dgvListEntity.TabIndex = 4;
			// 
			// tbListTable
			// 
			this.tbListTable.Controls.Add(this.dgvListTable);
			this.tbListTable.Location = new System.Drawing.Point(4, 26);
			this.tbListTable.Name = "tbListTable";
			this.tbListTable.Padding = new System.Windows.Forms.Padding(3);
			this.tbListTable.Size = new System.Drawing.Size(1338, 486);
			this.tbListTable.TabIndex = 10;
			this.tbListTable.Text = "ListTable";
			this.tbListTable.UseVisualStyleBackColor = true;
			// 
			// dgvListTable
			// 
			this.dgvListTable.AllowUserToAddRows = false;
			this.dgvListTable.AllowUserToDeleteRows = false;
			this.dgvListTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvListTable.CommandAdd = false;
			this.dgvListTable.CommandDel = false;
			this.dgvListTable.CommandEdit = false;
			this.dgvListTable.CommandExportToExcel = false;
			this.dgvListTable.CommandFilter = false;
			this.dgvListTable.CommandRefresh = false;
			this.dgvListTable.CommandSaveASCSV = false;
			this.dgvListTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvListTable.EnableHeadersVisualStyles = false;
			this.dgvListTable.GroupEnabled = null;
			this.dgvListTable.Location = new System.Drawing.Point(3, 3);
			this.dgvListTable.Name = "dgvListTable";
			this.dgvListTable.Obj = null;
			this.dgvListTable.PassedSec = null;
			this.dgvListTable.ReadOnly = true;
			this.dgvListTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListTable.Size = new System.Drawing.Size(1332, 480);
			this.dgvListTable.TabIndex = 5;
			// 
			// tbUserString
			// 
			this.tbUserString.Controls.Add(this.dgvUserString);
			this.tbUserString.Location = new System.Drawing.Point(4, 26);
			this.tbUserString.Name = "tbUserString";
			this.tbUserString.Padding = new System.Windows.Forms.Padding(3);
			this.tbUserString.Size = new System.Drawing.Size(1338, 486);
			this.tbUserString.TabIndex = 11;
			this.tbUserString.Text = "UserString";
			this.tbUserString.UseVisualStyleBackColor = true;
			// 
			// dgvUserString
			// 
			this.dgvUserString.AllowUserToAddRows = false;
			this.dgvUserString.AllowUserToDeleteRows = false;
			this.dgvUserString.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUserString.CommandAdd = false;
			this.dgvUserString.CommandDel = false;
			this.dgvUserString.CommandEdit = false;
			this.dgvUserString.CommandExportToExcel = false;
			this.dgvUserString.CommandFilter = false;
			this.dgvUserString.CommandRefresh = false;
			this.dgvUserString.CommandSaveASCSV = false;
			this.dgvUserString.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvUserString.EnableHeadersVisualStyles = false;
			this.dgvUserString.GroupEnabled = null;
			this.dgvUserString.Location = new System.Drawing.Point(3, 3);
			this.dgvUserString.Name = "dgvUserString";
			this.dgvUserString.Obj = null;
			this.dgvUserString.PassedSec = null;
			this.dgvUserString.ReadOnly = true;
			this.dgvUserString.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvUserString.Size = new System.Drawing.Size(1332, 480);
			this.dgvUserString.TabIndex = 6;
			// 
			// tbAttrTable
			// 
			this.tbAttrTable.Controls.Add(this.dgvAttrTable);
			this.tbAttrTable.Location = new System.Drawing.Point(4, 26);
			this.tbAttrTable.Name = "tbAttrTable";
			this.tbAttrTable.Padding = new System.Windows.Forms.Padding(3);
			this.tbAttrTable.Size = new System.Drawing.Size(1338, 486);
			this.tbAttrTable.TabIndex = 15;
			this.tbAttrTable.Text = "AttrTable";
			this.tbAttrTable.UseVisualStyleBackColor = true;
			// 
			// dgvAttrTable
			// 
			this.dgvAttrTable.AllowUserToAddRows = false;
			this.dgvAttrTable.AllowUserToDeleteRows = false;
			this.dgvAttrTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAttrTable.CommandAdd = false;
			this.dgvAttrTable.CommandDel = false;
			this.dgvAttrTable.CommandEdit = false;
			this.dgvAttrTable.CommandExportToExcel = false;
			this.dgvAttrTable.CommandFilter = false;
			this.dgvAttrTable.CommandRefresh = false;
			this.dgvAttrTable.CommandSaveASCSV = false;
			this.dgvAttrTable.ContextMenuStrip = this.cmWords;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvAttrTable.DefaultCellStyle = dataGridViewCellStyle5;
			this.dgvAttrTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAttrTable.EnableHeadersVisualStyles = false;
			this.dgvAttrTable.GroupEnabled = null;
			this.dgvAttrTable.Location = new System.Drawing.Point(3, 3);
			this.dgvAttrTable.Name = "dgvAttrTable";
			this.dgvAttrTable.Obj = null;
			this.dgvAttrTable.PassedSec = null;
			this.dgvAttrTable.ReadOnly = true;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvAttrTable.RowsDefaultCellStyle = dataGridViewCellStyle6;
			this.dgvAttrTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAttrTable.Size = new System.Drawing.Size(1332, 480);
			this.dgvAttrTable.TabIndex = 6;
			this.dgvAttrTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvString_KeyDown);
			// 
			// tbStateDate
			// 
			this.tbStateDate.Controls.Add(this.dgvStateDate);
			this.tbStateDate.Location = new System.Drawing.Point(4, 26);
			this.tbStateDate.Name = "tbStateDate";
			this.tbStateDate.Padding = new System.Windows.Forms.Padding(3);
			this.tbStateDate.Size = new System.Drawing.Size(1338, 486);
			this.tbStateDate.TabIndex = 16;
			this.tbStateDate.Text = "StateDate";
			this.tbStateDate.UseVisualStyleBackColor = true;
			// 
			// dgvStateDate
			// 
			this.dgvStateDate.AllowUserToAddRows = false;
			this.dgvStateDate.AllowUserToDeleteRows = false;
			this.dgvStateDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStateDate.CommandAdd = false;
			this.dgvStateDate.CommandDel = false;
			this.dgvStateDate.CommandEdit = false;
			this.dgvStateDate.CommandExportToExcel = false;
			this.dgvStateDate.CommandFilter = false;
			this.dgvStateDate.CommandRefresh = false;
			this.dgvStateDate.CommandSaveASCSV = false;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvStateDate.DefaultCellStyle = dataGridViewCellStyle7;
			this.dgvStateDate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvStateDate.EnableHeadersVisualStyles = false;
			this.dgvStateDate.GroupEnabled = null;
			this.dgvStateDate.Location = new System.Drawing.Point(3, 3);
			this.dgvStateDate.Name = "dgvStateDate";
			this.dgvStateDate.Obj = null;
			this.dgvStateDate.PassedSec = null;
			this.dgvStateDate.ReadOnly = true;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvStateDate.RowsDefaultCellStyle = dataGridViewCellStyle8;
			this.dgvStateDate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvStateDate.Size = new System.Drawing.Size(1332, 480);
			this.dgvStateDate.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.TextResult);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1338, 486);
			this.tabPage1.TabIndex = 17;
			this.tabPage1.Text = "Test result";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// TextResult
			// 
			this.TextResult.BackColor = System.Drawing.SystemColors.Info;
			this.TextResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextResult.Location = new System.Drawing.Point(3, 3);
			this.TextResult.Multiline = true;
			this.TextResult.Name = "TextResult";
			this.TextResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TextResult.Size = new System.Drawing.Size(1332, 480);
			this.TextResult.TabIndex = 1;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "1.png");
			this.imageList1.Images.SetKeyName(1, "2.png");
			this.imageList1.Images.SetKeyName(2, "3.png");
			// 
			// imageListAttr
			// 
			this.imageListAttr.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageListAttr.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListAttr.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// FormParser
			// 
			//this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1346, 553);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Name = "FormParser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ParserApp";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormParser_FormClosing);
			this.Load += new System.EventHandler(this.FormParserLoad);
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tbListSQL.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.cmTestList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ListSQL)).EndInit();
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ListResult)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tbQuery.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textQuery)).EndInit();
			this.tabControlResult.ResumeLayout(false);
			this.tbText.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TexBoxResult)).EndInit();
			this.panel6.ResumeLayout(false);
			this.tbResult.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
			this.panel4.ResumeLayout(false);
			this.tbWords.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvString)).EndInit();
			this.cmWords.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tbTime.ResumeLayout(false);
			this.tbTime.PerformLayout();
			this.tbEntity.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).EndInit();
			this.tbAttrParent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvAttrParent)).EndInit();
			this.tbListEntity.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListEntity)).EndInit();
			this.tbListTable.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListTable)).EndInit();
			this.tbUserString.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvUserString)).EndInit();
			this.tbAttrTable.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvAttrTable)).EndInit();
			this.tbStateDate.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvStateDate)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

		}
		//private System.Windows.Forms.DataGrid DGSelecteding;
		private System.Windows.Forms.TabPage tbWords;
		private System.Windows.Forms.TabPage tbQuery;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnParse;
		private System.Windows.Forms.TabPage tbTime;
		private System.Windows.Forms.TextBox txTime;		
		private DevAge.ComponentModel.ComponentLight componentLight1;
		private FBA.DataGridViewFBA dgvString;
		private System.Windows.Forms.TabPage tbEntity;
		private FBA.DataGridViewFBA dgvEntity;
		public FastColoredTextBoxNS.FastColoredTextBox textQuery;
		private System.Windows.Forms.TabPage tbListEntity;
		private FBA.DataGridViewFBA dgvListEntity;
		private System.Windows.Forms.TabPage tbListTable;
		private FBA.DataGridViewFBA dgvListTable;
		private System.Windows.Forms.TabPage tbUserString;
		private FBA.DataGridViewFBA dgvUserString;
		public FastColoredTextBoxNS.FastColoredTextBox TexBoxResult;
		private System.Windows.Forms.Button btnSaveMSQL;
		private System.Windows.Forms.TabPage tbListSQL;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox ListBox1;
		public FastColoredTextBoxNS.FastColoredTextBox ListSQL;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnSQL4;
		private System.Windows.Forms.Button btnSQL3;
		private System.Windows.Forms.Button btnSQL2;
		private System.Windows.Forms.Button btnSQL1;
		private System.Windows.Forms.TabPage tbAttrParent;
		private FBA.DataGridViewFBA dgvAttrParent;
		private System.Windows.Forms.Button btnHideColumns;
		private System.Windows.Forms.CheckBox cbOnTop;
		private System.Windows.Forms.Button btnShowColumns;
		private System.Windows.Forms.Button btnParserCreateTable;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ImageList imageListAttr;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ProgressBar progressBarParser;
		private System.Windows.Forms.TabControl tabControlResult;
		private System.Windows.Forms.TabPage tbText;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.TabPage tbResult;
		private FBA.DataGridViewFBA dgvResult;
		private System.Windows.Forms.Panel panel4;
		private FBA.LabelFBA lbTime;
		private System.Windows.Forms.TabPage tbAttrTable;
		private FBA.DataGridViewFBA dgvAttrTable;
		private System.Windows.Forms.TabPage tbStateDate;
		private FBA.DataGridViewFBA dgvStateDate;
		private System.Windows.Forms.Button btnSQL7;
		private System.Windows.Forms.Button btnCopy;
		private FBA.LabelFBA label2;
		private FBA.ComboBoxFBA cbPsevdominEntity;
		private System.Windows.Forms.Button btnSyntax;
		private System.Windows.Forms.Panel panel5;
		public FastColoredTextBoxNS.FastColoredTextBox ListResult;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSQL5;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox TextResult;
		private System.Windows.Forms.Button btnSQL6;
		private System.Windows.Forms.Button btnSQL8;
		private System.Windows.Forms.Label lbResultRun;
		private System.Windows.Forms.CheckBox cbTest;
		private System.Windows.Forms.ContextMenuStrip cmTestList;
		private System.Windows.Forms.ToolStripMenuItem cmTestList_N1;
		private System.Windows.Forms.Button btnSQL9;
		private System.Windows.Forms.ToolStripMenuItem cmTestList_N2;
		private System.Windows.Forms.Button button3;
		private DevAge.Windows.Forms.Line line1;
		private System.Windows.Forms.ContextMenuStrip cmWords;
		private System.Windows.Forms.ToolStripMenuItem cmWords_N1;
		//private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		//private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		//private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		//private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
	}
}
