
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 28.09.2017
 * Время: 17:22
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace FBA
{
	partial class FormSQL
	{	    
		private System.ComponentModel.IContainer components = null;
			
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSQL));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStripSQL = new System.Windows.Forms.ToolStrip();
			this.tbSQL1 = new System.Windows.Forms.ToolStripButton();
			this.tbSQL7 = new System.Windows.Forms.ToolStripButton();
			this.tbSQL6 = new System.Windows.Forms.ToolStripButton();
			this.tbSQL2 = new System.Windows.Forms.ToolStripButton();
			this.tbSQL3 = new System.Windows.Forms.ToolStripButton();
			this.tbSQL4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbSQL5 = new System.Windows.Forms.ToolStripComboBox();
			this.tabControlSQL1 = new System.Windows.Forms.TabControl();
			this.tabSQL1 = new System.Windows.Forms.TabPage();
			this.splitContainerSQL1 = new System.Windows.Forms.SplitContainer();
			this.textSQL1 = new FastColoredTextBoxNS.FastColoredTextBox();
			this.cmGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmGrid_N1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cmGrid_N2 = new System.Windows.Forms.ToolStripMenuItem();
			this.cmGrid_N3 = new System.Windows.Forms.ToolStripMenuItem();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.tabControlResult1 = new System.Windows.Forms.TabControl();
			this.tabPageData1 = new System.Windows.Forms.TabPage();
			this.dgvSQL1 = new FBA.DataGridViewFBA();
			this.cmResult = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cm1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cm2 = new System.Windows.Forms.ToolStripMenuItem();
			this.cm3 = new System.Windows.Forms.ToolStripMenuItem();
			this.cm4 = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageSQL1 = new System.Windows.Forms.TabPage();
			this.fastColoredTextBoxSQL1 = new FastColoredTextBoxNS.FastColoredTextBox();
			this.pnlResultSQL1 = new System.Windows.Forms.Panel();
			this.tbSQLResult1 = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgvTableList = new FBA.DataGridViewFBA();
			this.cb_MSQL_SQL = new FBA.CheckBoxFBA();
			this.toolStripSQL.SuspendLayout();
			this.tabControlSQL1.SuspendLayout();
			this.tabSQL1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSQL1)).BeginInit();
			this.splitContainerSQL1.Panel1.SuspendLayout();
			this.splitContainerSQL1.Panel2.SuspendLayout();
			this.splitContainerSQL1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textSQL1)).BeginInit();
			this.cmGrid.SuspendLayout();
			this.tabControlResult1.SuspendLayout();
			this.tabPageData1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSQL1)).BeginInit();
			this.cmResult.SuspendLayout();
			this.tabPageSQL1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxSQL1)).BeginInit();
			this.pnlResultSQL1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTableList)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStripSQL
			// 
			this.toolStripSQL.AutoSize = false;
			this.toolStripSQL.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.toolStripSQL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbSQL1,
			this.tbSQL7,
			this.tbSQL6,
			this.tbSQL2,
			this.tbSQL3,
			this.tbSQL4,
			this.toolStripSeparator2,
			this.tbSQL5});
			this.toolStripSQL.Location = new System.Drawing.Point(0, 0);
			this.toolStripSQL.Name = "toolStripSQL";
			this.toolStripSQL.Size = new System.Drawing.Size(685, 26);
			this.toolStripSQL.TabIndex = 1;
			this.toolStripSQL.Text = "toolStrip1";
			// 
			// tbSQL1
			// 
			this.tbSQL1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbSQL1.Image = ((System.Drawing.Image)(resources.GetObject("tbSQL1.Image")));
			this.tbSQL1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbSQL1.Name = "tbSQL1";
			this.tbSQL1.Size = new System.Drawing.Size(81, 23);
			this.tbSQL1.Text = "Execute";
			this.tbSQL1.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// tbSQL7
			// 
			this.tbSQL7.Image = global::FBA.Resource.method_5;
			this.tbSQL7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbSQL7.Name = "tbSQL7";
			this.tbSQL7.Size = new System.Drawing.Size(67, 23);
			this.tbSQL7.Text = "Parse";
			this.tbSQL7.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// tbSQL6
			// 
			this.tbSQL6.Image = global::FBA.Resource.Save_16;
			this.tbSQL6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbSQL6.Name = "tbSQL6";
			this.tbSQL6.Size = new System.Drawing.Size(61, 23);
			this.tbSQL6.Text = "Save";
			this.tbSQL6.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// tbSQL2
			// 
			this.tbSQL2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbSQL2.Image = ((System.Drawing.Image)(resources.GetObject("tbSQL2.Image")));
			this.tbSQL2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbSQL2.Name = "tbSQL2";
			this.tbSQL2.Size = new System.Drawing.Size(63, 23);
			this.tbSQL2.Text = "Clear";
			this.tbSQL2.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// tbSQL3
			// 
			this.tbSQL3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbSQL3.Image = ((System.Drawing.Image)(resources.GetObject("tbSQL3.Image")));
			this.tbSQL3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbSQL3.Name = "tbSQL3";
			this.tbSQL3.Size = new System.Drawing.Size(77, 23);
			this.tbSQL3.Text = "Add tab";
			this.tbSQL3.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// tbSQL4
			// 
			this.tbSQL4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbSQL4.Image = ((System.Drawing.Image)(resources.GetObject("tbSQL4.Image")));
			this.tbSQL4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbSQL4.Name = "tbSQL4";
			this.tbSQL4.Size = new System.Drawing.Size(107, 23);
			this.tbSQL4.Text = "Remove tab";
			this.tbSQL4.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
			// 
			// tbSQL5
			// 
			this.tbSQL5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tbSQL5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tbSQL5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbSQL5.Items.AddRange(new object[] {
			"Remote",
			"Local"});
			this.tbSQL5.Name = "tbSQL5";
			this.tbSQL5.Size = new System.Drawing.Size(121, 26);
			this.tbSQL5.Text = "Remote";
			this.tbSQL5.TextChanged += new System.EventHandler(this.tbSQL5_TextChanged);
			// 
			// tabControlSQL1
			// 
			this.tabControlSQL1.Controls.Add(this.tabSQL1);
			this.tabControlSQL1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlSQL1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabControlSQL1.Location = new System.Drawing.Point(0, 0);
			this.tabControlSQL1.Name = "tabControlSQL1";
			this.tabControlSQL1.SelectedIndex = 0;
			this.tabControlSQL1.Size = new System.Drawing.Size(525, 337);
			this.tabControlSQL1.TabIndex = 19;
			// 
			// tabSQL1
			// 
			this.tabSQL1.Controls.Add(this.splitContainerSQL1);
			this.tabSQL1.Location = new System.Drawing.Point(4, 26);
			this.tabSQL1.Name = "tabSQL1";
			this.tabSQL1.Size = new System.Drawing.Size(517, 307);
			this.tabSQL1.TabIndex = 0;
			this.tabSQL1.Tag = "1";
			this.tabSQL1.Text = "Query1";
			// 
			// splitContainerSQL1
			// 
			this.splitContainerSQL1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainerSQL1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerSQL1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerSQL1.Name = "splitContainerSQL1";
			this.splitContainerSQL1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerSQL1.Panel1
			// 
			this.splitContainerSQL1.Panel1.Controls.Add(this.textSQL1);
			this.splitContainerSQL1.Panel1.Controls.Add(this.webBrowser1);
			// 
			// splitContainerSQL1.Panel2
			// 
			this.splitContainerSQL1.Panel2.Controls.Add(this.tabControlResult1);
			this.splitContainerSQL1.Panel2.Controls.Add(this.pnlResultSQL1);
			this.splitContainerSQL1.Size = new System.Drawing.Size(517, 307);
			this.splitContainerSQL1.SplitterDistance = 182;
			this.splitContainerSQL1.TabIndex = 2;
			// 
			// textSQL1
			// 
			this.textSQL1.AutoCompleteBracketsList = new char[] {
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
			this.textSQL1.AutoIndentCharsPatterns = "";
			this.textSQL1.AutoScrollMinSize = new System.Drawing.Size(253, 21);
			this.textSQL1.BackBrush = null;
			this.textSQL1.BookmarkColor = System.Drawing.Color.Red;
			this.textSQL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textSQL1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.textSQL1.CharHeight = 21;
			this.textSQL1.CharWidth = 11;
			this.textSQL1.CommentPrefix = "--";
			this.textSQL1.ContextMenuStrip = this.cmGrid;
			this.textSQL1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textSQL1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.textSQL1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textSQL1.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.textSQL1.Font = new System.Drawing.Font("Courier New", 14.25F);
			this.textSQL1.IsReplaceMode = false;
			this.textSQL1.Language = FastColoredTextBoxNS.Language.SQL;
			this.textSQL1.LeftBracket = '(';
			this.textSQL1.Location = new System.Drawing.Point(0, 0);
			this.textSQL1.Name = "textSQL1";
			this.textSQL1.Paddings = new System.Windows.Forms.Padding(0);
			this.textSQL1.RightBracket = ')';
			this.textSQL1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.textSQL1.Size = new System.Drawing.Size(517, 182);
			this.textSQL1.TabIndex = 15;
			this.textSQL1.Text = "SELECT * FROM Entity";
			this.textSQL1.VirtualSpace = true;
			this.textSQL1.Zoom = 100;
			this.textSQL1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextSQL1KeyDown);
			// 
			// cmGrid
			// 
			this.cmGrid.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cmGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmGrid_N1,
			this.cmGrid_N2,
			this.cmGrid_N3});
			this.cmGrid.Name = "cmGrid";
			this.cmGrid.Size = new System.Drawing.Size(246, 70);
			// 
			// cmGrid_N1
			// 
			this.cmGrid_N1.Name = "cmGrid_N1";
			this.cmGrid_N1.Size = new System.Drawing.Size(245, 22);
			this.cmGrid_N1.Text = "Set Quote";
			this.cmGrid_N1.Click += new System.EventHandler(this.cmGrid_N1_Click);
			// 
			// cmGrid_N2
			// 
			this.cmGrid_N2.Name = "cmGrid_N2";
			this.cmGrid_N2.Size = new System.Drawing.Size(245, 22);
			this.cmGrid_N2.Text = "Clear";
			this.cmGrid_N2.Click += new System.EventHandler(this.cmGrid_N1_Click);
			// 
			// cmGrid_N3
			// 
			this.cmGrid_N3.Name = "cmGrid_N3";
			this.cmGrid_N3.Size = new System.Drawing.Size(245, 22);
			this.cmGrid_N3.Text = "Paste INSERT from Excel";
			this.cmGrid_N3.Click += new System.EventHandler(this.cmGrid_N1_Click);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(517, 182);
			this.webBrowser1.TabIndex = 16;
			// 
			// tabControlResult1
			// 
			this.tabControlResult1.Controls.Add(this.tabPageData1);
			this.tabControlResult1.Controls.Add(this.tabPageSQL1);
			this.tabControlResult1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlResult1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabControlResult1.Location = new System.Drawing.Point(0, 21);
			this.tabControlResult1.Name = "tabControlResult1";
			this.tabControlResult1.SelectedIndex = 0;
			this.tabControlResult1.Size = new System.Drawing.Size(517, 100);
			this.tabControlResult1.TabIndex = 5;
			// 
			// tabPageData1
			// 
			this.tabPageData1.Controls.Add(this.dgvSQL1);
			this.tabPageData1.Location = new System.Drawing.Point(4, 26);
			this.tabPageData1.Name = "tabPageData1";
			this.tabPageData1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageData1.Size = new System.Drawing.Size(509, 70);
			this.tabPageData1.TabIndex = 0;
			this.tabPageData1.Text = "Data";
			this.tabPageData1.UseVisualStyleBackColor = true;
			// 
			// dgvSQL1
			// 
			this.dgvSQL1.AllowUserToAddRows = false;
			this.dgvSQL1.AllowUserToDeleteRows = false;
			this.dgvSQL1.AllowUserToOrderColumns = true;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvSQL1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvSQL1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.dgvSQL1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvSQL1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvSQL1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSQL1.CommandAdd = false;
			this.dgvSQL1.CommandDel = false;
			this.dgvSQL1.CommandEdit = false;
			this.dgvSQL1.CommandExportToExcel = false;
			this.dgvSQL1.CommandFilter = false;
			this.dgvSQL1.CommandRefresh = false;
			this.dgvSQL1.CommandSaveASCSV = false;
			this.dgvSQL1.ContextMenuStrip = this.cmResult;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvSQL1.DefaultCellStyle = dataGridViewCellStyle6;
			this.dgvSQL1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSQL1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvSQL1.EnableHeadersVisualStyles = false;
			this.dgvSQL1.GroupEnabled = null;
			this.dgvSQL1.Location = new System.Drawing.Point(3, 3);
			this.dgvSQL1.Margin = new System.Windows.Forms.Padding(1);
			this.dgvSQL1.Name = "dgvSQL1";
			this.dgvSQL1.Obj = null;
			this.dgvSQL1.PassedSec = null;
			this.dgvSQL1.ReadOnly = true;
			this.dgvSQL1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dgvSQL1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvSQL1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSQL1.Size = new System.Drawing.Size(503, 64);
			this.dgvSQL1.TabIndex = 4;
			// 
			// cmResult
			// 
			this.cmResult.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cmResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cm1,
			this.cm2,
			this.cm3,
			this.cm4});
			this.cmResult.Name = "contextMenuStrip1";
			this.cmResult.Size = new System.Drawing.Size(250, 92);
			this.cmResult.Text = "Copy to database";
			// 
			// cm1
			// 
			this.cm1.Name = "cm1";
			this.cm1.Size = new System.Drawing.Size(249, 22);
			this.cm1.Text = "Copy to Remote Database";
			this.cm1.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// cm2
			// 
			this.cm2.Name = "cm2";
			this.cm2.Size = new System.Drawing.Size(249, 22);
			this.cm2.Text = "Copy to Local Database";
			this.cm2.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// cm3
			// 
			this.cm3.Name = "cm3";
			this.cm3.Size = new System.Drawing.Size(249, 22);
			this.cm3.Text = "Export to CSV";
			this.cm3.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// cm4
			// 
			this.cm4.Name = "cm4";
			this.cm4.Size = new System.Drawing.Size(249, 22);
			this.cm4.Text = "Export to XLS";
			this.cm4.Click += new System.EventHandler(this.TbSQL1Click);
			// 
			// tabPageSQL1
			// 
			this.tabPageSQL1.Controls.Add(this.fastColoredTextBoxSQL1);
			this.tabPageSQL1.Location = new System.Drawing.Point(4, 26);
			this.tabPageSQL1.Name = "tabPageSQL1";
			this.tabPageSQL1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSQL1.Size = new System.Drawing.Size(509, 70);
			this.tabPageSQL1.TabIndex = 1;
			this.tabPageSQL1.Text = "SQL";
			this.tabPageSQL1.UseVisualStyleBackColor = true;
			// 
			// fastColoredTextBoxSQL1
			// 
			this.fastColoredTextBoxSQL1.AutoCompleteBracketsList = new char[] {
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
			this.fastColoredTextBoxSQL1.AutoIndentCharsPatterns = "";
			this.fastColoredTextBoxSQL1.AutoScrollMinSize = new System.Drawing.Size(33, 21);
			this.fastColoredTextBoxSQL1.BackBrush = null;
			this.fastColoredTextBoxSQL1.BookmarkColor = System.Drawing.Color.Red;
			this.fastColoredTextBoxSQL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.fastColoredTextBoxSQL1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.fastColoredTextBoxSQL1.CharHeight = 21;
			this.fastColoredTextBoxSQL1.CharWidth = 11;
			this.fastColoredTextBoxSQL1.CommentPrefix = "--";
			this.fastColoredTextBoxSQL1.ContextMenuStrip = this.cmGrid;
			this.fastColoredTextBoxSQL1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.fastColoredTextBoxSQL1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.fastColoredTextBoxSQL1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fastColoredTextBoxSQL1.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.fastColoredTextBoxSQL1.Font = new System.Drawing.Font("Courier New", 14.25F);
			this.fastColoredTextBoxSQL1.IsReplaceMode = false;
			this.fastColoredTextBoxSQL1.Language = FastColoredTextBoxNS.Language.SQL;
			this.fastColoredTextBoxSQL1.LeftBracket = '(';
			this.fastColoredTextBoxSQL1.Location = new System.Drawing.Point(3, 3);
			this.fastColoredTextBoxSQL1.Name = "fastColoredTextBoxSQL1";
			this.fastColoredTextBoxSQL1.Paddings = new System.Windows.Forms.Padding(0);
			this.fastColoredTextBoxSQL1.RightBracket = ')';
			this.fastColoredTextBoxSQL1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.fastColoredTextBoxSQL1.Size = new System.Drawing.Size(503, 64);
			this.fastColoredTextBoxSQL1.TabIndex = 16;
			this.fastColoredTextBoxSQL1.VirtualSpace = true;
			this.fastColoredTextBoxSQL1.Zoom = 100;
			// 
			// pnlResultSQL1
			// 
			this.pnlResultSQL1.BackColor = System.Drawing.Color.CornflowerBlue;
			this.pnlResultSQL1.Controls.Add(this.tbSQLResult1);
			this.pnlResultSQL1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlResultSQL1.Location = new System.Drawing.Point(0, 0);
			this.pnlResultSQL1.Name = "pnlResultSQL1";
			this.pnlResultSQL1.Size = new System.Drawing.Size(517, 21);
			this.pnlResultSQL1.TabIndex = 18;
			// 
			// tbSQLResult1
			// 
			this.tbSQLResult1.BackColor = System.Drawing.Color.CornflowerBlue;
			this.tbSQLResult1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbSQLResult1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSQLResult1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbSQLResult1.ForeColor = System.Drawing.SystemColors.Window;
			this.tbSQLResult1.Location = new System.Drawing.Point(0, 0);
			this.tbSQLResult1.Name = "tbSQLResult1";
			this.tbSQLResult1.Size = new System.Drawing.Size(517, 18);
			this.tbSQLResult1.TabIndex = 0;
			this.tbSQLResult1.Text = " Result";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 26);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dgvTableList);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControlSQL1);
			this.splitContainer1.Size = new System.Drawing.Size(685, 337);
			this.splitContainer1.SplitterDistance = 157;
			this.splitContainer1.SplitterWidth = 3;
			this.splitContainer1.TabIndex = 20;
			// 
			// dgvTableList
			// 
			this.dgvTableList.AllowUserToAddRows = false;
			this.dgvTableList.AllowUserToDeleteRows = false;
			this.dgvTableList.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvTableList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvTableList.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.dgvTableList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvTableList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvTableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTableList.CommandAdd = false;
			this.dgvTableList.CommandDel = false;
			this.dgvTableList.CommandEdit = false;
			this.dgvTableList.CommandExportToExcel = false;
			this.dgvTableList.CommandFilter = false;
			this.dgvTableList.CommandRefresh = false;
			this.dgvTableList.CommandSaveASCSV = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvTableList.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvTableList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTableList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvTableList.EnableHeadersVisualStyles = false;
			this.dgvTableList.GroupEnabled = null;
			this.dgvTableList.Location = new System.Drawing.Point(0, 0);
			this.dgvTableList.Margin = new System.Windows.Forms.Padding(1);
			this.dgvTableList.Name = "dgvTableList";
			this.dgvTableList.Obj = null;
			this.dgvTableList.PassedSec = null;
			this.dgvTableList.ReadOnly = true;
			this.dgvTableList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dgvTableList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvTableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTableList.Size = new System.Drawing.Size(157, 337);
			this.dgvTableList.TabIndex = 21;
			// 
			// cb_MSQL_SQL
			// 
			this.cb_MSQL_SQL.Appearance = System.Windows.Forms.Appearance.Button;
			this.cb_MSQL_SQL.AttrBrief = null;
			this.cb_MSQL_SQL.AutoSize = true;
			this.cb_MSQL_SQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.cb_MSQL_SQL.Checked = true;
			this.cb_MSQL_SQL.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cb_MSQL_SQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_MSQL_SQL.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_MSQL_SQL.GroupEnabled = null;
			this.cb_MSQL_SQL.Location = new System.Drawing.Point(603, 0);
			this.cb_MSQL_SQL.Margin = new System.Windows.Forms.Padding(2);
			this.cb_MSQL_SQL.Name = "cb_MSQL_SQL";
			this.cb_MSQL_SQL.Obj = null;
			this.cb_MSQL_SQL.ObjectRef = null;
			this.cb_MSQL_SQL.SaveParam = false;
			this.cb_MSQL_SQL.Size = new System.Drawing.Size(59, 27);
			this.cb_MSQL_SQL.TabIndex = 21;
			this.cb_MSQL_SQL.Text = "MSQL";
			this.cb_MSQL_SQL.UseVisualStyleBackColor = false;
			this.cb_MSQL_SQL.CheckedChanged += new System.EventHandler(this.cb_MSQL_SQL_CheckedChanged);
			// 
			// FormSQL
			// 
			this.ClientSize = new System.Drawing.Size(685, 363);
			this.Controls.Add(this.cb_MSQL_SQL);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStripSQL);
			this.Name = "FormSQL";
			this.Text = "FormSQL";
			this.Shown += new System.EventHandler(this.FormSQL_Shown);
			this.toolStripSQL.ResumeLayout(false);
			this.toolStripSQL.PerformLayout();
			this.tabControlSQL1.ResumeLayout(false);
			this.tabSQL1.ResumeLayout(false);
			this.splitContainerSQL1.Panel1.ResumeLayout(false);
			this.splitContainerSQL1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSQL1)).EndInit();
			this.splitContainerSQL1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textSQL1)).EndInit();
			this.cmGrid.ResumeLayout(false);
			this.tabControlResult1.ResumeLayout(false);
			this.tabPageData1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSQL1)).EndInit();
			this.cmResult.ResumeLayout(false);
			this.tabPageSQL1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxSQL1)).EndInit();
			this.pnlResultSQL1.ResumeLayout(false);
			this.pnlResultSQL1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTableList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
			private System.Windows.Forms.TabPage tabPageSQL1;
			private System.Windows.Forms.TabPage tabPageData1;	
			private System.Windows.Forms.ToolStripMenuItem cm4;			
			private System.Windows.Forms.ToolStripMenuItem cm3;
			private System.Windows.Forms.ToolStripMenuItem cm2;
			private System.Windows.Forms.ToolStripMenuItem cm1;
			private System.Windows.Forms.ContextMenuStrip cmResult;
			private System.Windows.Forms.TextBox tbSQLResult1;
			private System.Windows.Forms.Panel pnlResultSQL1;
			private FBA.DataGridViewFBA dgvSQL1;
			private FastColoredTextBoxNS.FastColoredTextBox textSQL1;			
			private System.Windows.Forms.TabPage tabSQL1;
			private System.Windows.Forms.ToolStripComboBox tbSQL5;
			private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
			private System.Windows.Forms.ToolStripButton tbSQL4;
			private System.Windows.Forms.ToolStripButton tbSQL3;
			private System.Windows.Forms.ToolStripButton tbSQL2;
			private System.Windows.Forms.ToolStripButton tbSQL7;
			private System.Windows.Forms.ToolStripButton tbSQL1;
			private System.Windows.Forms.ToolStrip toolStripSQL;
			private System.Windows.Forms.WebBrowser webBrowser1;
			private System.Windows.Forms.ContextMenuStrip cmGrid;
			private System.Windows.Forms.ToolStripMenuItem cmGrid_N1;
			private System.Windows.Forms.ToolStripMenuItem cmGrid_N2;
			private System.Windows.Forms.ToolStripMenuItem cmGrid_N3;
			private System.Windows.Forms.ToolStripButton tbSQL6;
			private System.Windows.Forms.SplitContainer splitContainer1;
			private FBA.DataGridViewFBA dgvTableList;
	        private CheckBoxFBA cb_MSQL_SQL;	                  
	        private System.Windows.Forms.SplitContainer splitContainerSQL1;
	        private System.Windows.Forms.TabControl tabControlResult1;	
			private System.Windows.Forms.TabControl tabControlSQL1;	        
	        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBoxSQL1;	     	  	     	   
    }
}
