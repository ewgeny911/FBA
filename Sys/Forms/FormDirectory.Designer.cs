/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 16.11.2018
 * Время: 13:02
 */
namespace FBA
{
    partial class FormDirectory
    {            
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tb_N1;
        private System.Windows.Forms.ToolStripButton tb_N2;
        private System.Windows.Forms.ToolStripButton tb_N3;
        private System.Windows.Forms.ToolStripButton tb_N4;
        private System.Windows.Forms.ToolStripButton tb_N5;
        private System.Windows.Forms.ToolStripButton tb_N6;
        private System.Windows.Forms.ContextMenuStrip contextMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem cm_N1;
        private System.Windows.Forms.ToolStripMenuItem cm_N2;
        private System.Windows.Forms.ToolStripMenuItem cm_N3;
        private System.Windows.Forms.ToolStripMenuItem cm_N4;
        private System.Windows.Forms.ToolStripMenuItem cm_N5;
        private System.Windows.Forms.ToolStripMenuItem cm_N7;
        private System.Windows.Forms.ToolStripMenuItem cm_N9;
        private System.Windows.Forms.ToolStripMenuItem cm_N11;
        private System.Windows.Forms.ToolStripMenuItem cm_N6;

        //public DevExpress.XtraGrid.GridControl DG1;
        //public DevExpress.XtraEditors.Repository.RepositoryItemTokenEdit repositoryItemTokenEdit1;
        //public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;

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
        	this.contextMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cm_N1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N5 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N6 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N7 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N7_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N7_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N9 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N9_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N9_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N13 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N13_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N13_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N13_3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
        	this.cm_N13_4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N13_5 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N13_6 = new System.Windows.Forms.ToolStripMenuItem();
        	this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N16_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N16_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N16_3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N16_4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm_N11 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.tb_N1 = new System.Windows.Forms.ToolStripButton();
        	this.tb_N2 = new System.Windows.Forms.ToolStripButton();
        	this.tb_N3 = new System.Windows.Forms.ToolStripButton();
        	this.tb_N4 = new System.Windows.Forms.ToolStripButton();
        	this.tb_N5 = new System.Windows.Forms.ToolStripButton();
        	this.tb_N6 = new System.Windows.Forms.ToolStripButton();
        	this.pnlResult = new System.Windows.Forms.Panel();
        	this.tbGridInformation = new FBA.TextBoxFBA();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.grid1 = new FBA.GridFBA();
        	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        	this.pnlFastSearch = new System.Windows.Forms.Panel();
        	this.cbFastSearch = new FBA.ComboBoxFBA();
        	this.contextMenuFastSearch = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.deleteHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.btnFastSearch = new System.Windows.Forms.Button();
        	this.contextMenuGrid.SuspendLayout();
        	this.toolStrip1.SuspendLayout();
        	this.pnlResult.SuspendLayout();
        	this.pnlFastSearch.SuspendLayout();
        	this.contextMenuFastSearch.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// contextMenuGrid
        	// 
        	this.contextMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cm_N1,
			this.cm_N2,
			this.cm_N3,
			this.cm_N4,
			this.cm_N5,
			this.cm_N6,
			this.cm_N7,
			this.cm_N9,
			this.cm_N13,
			this.copyToolStripMenuItem,
			this.cm_N11});
        	this.contextMenuGrid.Name = "contextMenuStrip1";
        	this.contextMenuGrid.Size = new System.Drawing.Size(128, 246);
        	// 
        	// cm_N1
        	// 
        	this.cm_N1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N1.Image = global::FBA.Resource.Filter_16;
        	this.cm_N1.Name = "cm_N1";
        	this.cm_N1.Size = new System.Drawing.Size(127, 22);
        	this.cm_N1.Text = "Filter";
        	this.cm_N1.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N2
        	// 
        	this.cm_N2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N2.Image = global::FBA.Resource.Refresh_16;
        	this.cm_N2.Name = "cm_N2";
        	this.cm_N2.Size = new System.Drawing.Size(127, 22);
        	this.cm_N2.Text = "Refresh";
        	this.cm_N2.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N3
        	// 
        	this.cm_N3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N3.Image = global::FBA.Resource.Add_16;
        	this.cm_N3.Name = "cm_N3";
        	this.cm_N3.Size = new System.Drawing.Size(127, 22);
        	this.cm_N3.Text = "Add";
        	this.cm_N3.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N4
        	// 
        	this.cm_N4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N4.Image = global::FBA.Resource.Edit_16;
        	this.cm_N4.Name = "cm_N4";
        	this.cm_N4.Size = new System.Drawing.Size(127, 22);
        	this.cm_N4.Text = "Edit";
        	this.cm_N4.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N5
        	// 
        	this.cm_N5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N5.Image = global::FBA.Resource.Del_16;
        	this.cm_N5.Name = "cm_N5";
        	this.cm_N5.Size = new System.Drawing.Size(127, 22);
        	this.cm_N5.Text = "Delete";
        	this.cm_N5.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N6
        	// 
        	this.cm_N6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N6.Image = global::FBA.Resource.Search_16;
        	this.cm_N6.Name = "cm_N6";
        	this.cm_N6.Size = new System.Drawing.Size(127, 22);
        	this.cm_N6.Text = "Search";
        	this.cm_N6.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N7
        	// 
        	this.cm_N7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cm_N7_1,
			this.cm_N7_2});
        	this.cm_N7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N7.Image = global::FBA.Resource.ExportExcel_16;
        	this.cm_N7.Name = "cm_N7";
        	this.cm_N7.Size = new System.Drawing.Size(127, 22);
        	this.cm_N7.Text = "Export";
        	// 
        	// cm_N7_1
        	// 
        	this.cm_N7_1.Image = global::FBA.Resource.ExportExcel_16;
        	this.cm_N7_1.Name = "cm_N7_1";
        	this.cm_N7_1.Size = new System.Drawing.Size(174, 22);
        	this.cm_N7_1.Text = "Export to Excel";
        	this.cm_N7_1.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N7_2
        	// 
        	this.cm_N7_2.Image = global::FBA.Resource.SaveCSV_16;
        	this.cm_N7_2.Name = "cm_N7_2";
        	this.cm_N7_2.Size = new System.Drawing.Size(174, 22);
        	this.cm_N7_2.Text = "Export to CSV";
        	this.cm_N7_2.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N9
        	// 
        	this.cm_N9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cm_N9_1,
			this.cm_N9_2});
        	this.cm_N9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N9.Name = "cm_N9";
        	this.cm_N9.Size = new System.Drawing.Size(127, 22);
        	this.cm_N9.Text = "SQL";
        	// 
        	// cm_N9_1
        	// 
        	this.cm_N9_1.Name = "cm_N9_1";
        	this.cm_N9_1.Size = new System.Drawing.Size(158, 22);
        	this.cm_N9_1.Text = "Show SQL";
        	this.cm_N9_1.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N9_2
        	// 
        	this.cm_N9_2.Name = "cm_N9_2";
        	this.cm_N9_2.Size = new System.Drawing.Size(158, 22);
        	this.cm_N9_2.Text = "Show MSQL";
        	this.cm_N9_2.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N13
        	// 
        	this.cm_N13.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cm_N13_1,
			this.cm_N13_2,
			this.cm_N13_3,
			this.toolStripMenuItem1,
			this.cm_N13_4,
			this.cm_N13_5,
			this.cm_N13_6});
        	this.cm_N13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N13.Image = global::FBA.Resource.method_5;
        	this.cm_N13.Name = "cm_N13";
        	this.cm_N13.Size = new System.Drawing.Size(127, 22);
        	this.cm_N13.Text = "Select";
        	// 
        	// cm_N13_1
        	// 
        	this.cm_N13_1.Image = global::FBA.Resource.method_5;
        	this.cm_N13_1.Name = "cm_N13_1";
        	this.cm_N13_1.Size = new System.Drawing.Size(241, 22);
        	this.cm_N13_1.Text = "Select all";
        	this.cm_N13_1.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N13_2
        	// 
        	this.cm_N13_2.Image = global::FBA.Resource.method_5;
        	this.cm_N13_2.Name = "cm_N13_2";
        	this.cm_N13_2.Size = new System.Drawing.Size(241, 22);
        	this.cm_N13_2.Text = "Select rows";
        	this.cm_N13_2.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N13_3
        	// 
        	this.cm_N13_3.Image = global::FBA.Resource.method_5;
        	this.cm_N13_3.Name = "cm_N13_3";
        	this.cm_N13_3.Size = new System.Drawing.Size(241, 22);
        	this.cm_N13_3.Text = "Select columns";
        	this.cm_N13_3.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// toolStripMenuItem1
        	// 
        	this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        	this.toolStripMenuItem1.Size = new System.Drawing.Size(238, 6);
        	// 
        	// cm_N13_4
        	// 
        	this.cm_N13_4.Name = "cm_N13_4";
        	this.cm_N13_4.Size = new System.Drawing.Size(241, 22);
        	this.cm_N13_4.Text = "Selection mode - Cell";
        	this.cm_N13_4.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N13_5
        	// 
        	this.cm_N13_5.Name = "cm_N13_5";
        	this.cm_N13_5.Size = new System.Drawing.Size(241, 22);
        	this.cm_N13_5.Text = "Selection mode - Row";
        	this.cm_N13_5.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N13_6
        	// 
        	this.cm_N13_6.Name = "cm_N13_6";
        	this.cm_N13_6.Size = new System.Drawing.Size(241, 22);
        	this.cm_N13_6.Text = "Selection mode - Column";
        	this.cm_N13_6.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// copyToolStripMenuItem
        	// 
        	this.copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cm_N16_1,
			this.cm_N16_2,
			this.cm_N16_3,
			this.cm_N16_4});
        	this.copyToolStripMenuItem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.copyToolStripMenuItem.Image = global::FBA.Resource.forms_16;
        	this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        	this.copyToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.copyToolStripMenuItem.Text = "Copy";
        	// 
        	// cm_N16_1
        	// 
        	this.cm_N16_1.Image = global::FBA.Resource.forms_16;
        	this.cm_N16_1.Name = "cm_N16_1";
        	this.cm_N16_1.Size = new System.Drawing.Size(204, 22);
        	this.cm_N16_1.Text = "Copy";
        	this.cm_N16_1.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N16_2
        	// 
        	this.cm_N16_2.Image = global::FBA.Resource.forms_16;
        	this.cm_N16_2.Name = "cm_N16_2";
        	this.cm_N16_2.Size = new System.Drawing.Size(204, 22);
        	this.cm_N16_2.Text = "Copy all";
        	this.cm_N16_2.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N16_3
        	// 
        	this.cm_N16_3.Image = global::FBA.Resource.forms_16;
        	this.cm_N16_3.Name = "cm_N16_3";
        	this.cm_N16_3.Size = new System.Drawing.Size(204, 22);
        	this.cm_N16_3.Text = "Copy with captions";
        	this.cm_N16_3.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N16_4
        	// 
        	this.cm_N16_4.Image = global::FBA.Resource.forms_16;
        	this.cm_N16_4.Name = "cm_N16_4";
        	this.cm_N16_4.Size = new System.Drawing.Size(204, 22);
        	this.cm_N16_4.Text = "Copy document link";
        	this.cm_N16_4.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// cm_N11
        	// 
        	this.cm_N11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cm_N11.Image = global::FBA.Resource.hist_16;
        	this.cm_N11.Name = "cm_N11";
        	this.cm_N11.Size = new System.Drawing.Size(127, 22);
        	this.cm_N11.Text = "Details";
        	this.cm_N11.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tb_N1,
			this.tb_N2,
			this.tb_N3,
			this.tb_N4,
			this.tb_N5,
			this.tb_N6});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(723, 31);
        	this.toolStrip1.TabIndex = 23;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// tb_N1
        	// 
        	this.tb_N1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.tb_N1.Image = global::FBA.Resource.Filter_24;
        	this.tb_N1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tb_N1.Name = "tb_N1";
        	this.tb_N1.Size = new System.Drawing.Size(28, 28);
        	this.tb_N1.Text = "Filter (F2)";
        	this.tb_N1.ToolTipText = "Filter (F2)";
        	this.tb_N1.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// tb_N2
        	// 
        	this.tb_N2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.tb_N2.Image = global::FBA.Resource.Refresh_24;
        	this.tb_N2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tb_N2.Name = "tb_N2";
        	this.tb_N2.Size = new System.Drawing.Size(28, 28);
        	this.tb_N2.Text = "Refresh (F5)";
        	this.tb_N2.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// tb_N3
        	// 
        	this.tb_N3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.tb_N3.Image = global::FBA.Resource.Add_24;
        	this.tb_N3.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tb_N3.Name = "tb_N3";
        	this.tb_N3.Size = new System.Drawing.Size(28, 28);
        	this.tb_N3.Text = "Add (Insert)";
        	this.tb_N3.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// tb_N4
        	// 
        	this.tb_N4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.tb_N4.Image = global::FBA.Resource.Edit_24;
        	this.tb_N4.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tb_N4.Name = "tb_N4";
        	this.tb_N4.Size = new System.Drawing.Size(28, 28);
        	this.tb_N4.Text = "Edit (F4)";
        	this.tb_N4.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// tb_N5
        	// 
        	this.tb_N5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.tb_N5.Image = global::FBA.Resource.Del_24;
        	this.tb_N5.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tb_N5.Name = "tb_N5";
        	this.tb_N5.Size = new System.Drawing.Size(28, 28);
        	this.tb_N5.Text = "Delete (Del)";
        	this.tb_N5.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// tb_N6
        	// 
        	this.tb_N6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.tb_N6.Image = global::FBA.Resource.Search_24;
        	this.tb_N6.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tb_N6.Name = "tb_N6";
        	this.tb_N6.Size = new System.Drawing.Size(28, 28);
        	this.tb_N6.Text = "Search (F3)";
        	this.tb_N6.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// pnlResult
        	// 
        	this.pnlResult.Controls.Add(this.tbGridInformation);
        	this.pnlResult.Controls.Add(this.btnCancel);
        	this.pnlResult.Controls.Add(this.btnOk);
        	this.pnlResult.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.pnlResult.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.pnlResult.Location = new System.Drawing.Point(0, 332);
        	this.pnlResult.Margin = new System.Windows.Forms.Padding(4);
        	this.pnlResult.Name = "pnlResult";
        	this.pnlResult.Size = new System.Drawing.Size(723, 41);
        	this.pnlResult.TabIndex = 27;
        	// 
        	// tbGridInformation
        	// 
        	this.tbGridInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbGridInformation.AttrBrief = null;
        	this.tbGridInformation.AttrBriefLookup = null;
        	this.tbGridInformation.BackColor = System.Drawing.SystemColors.Control;
        	this.tbGridInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.tbGridInformation.DefaultTextGray = null;
        	this.tbGridInformation.DefaultTextGrayColor = System.Drawing.Color.Gray;
        	this.tbGridInformation.ErrorIfNull = null;
        	this.tbGridInformation.ForeColor = System.Drawing.Color.Red;
        	this.tbGridInformation.GroupEnabled = null;
        	this.tbGridInformation.ListInvalidChars = null;
        	this.tbGridInformation.ListValidChars = null;
        	this.tbGridInformation.Location = new System.Drawing.Point(12, 12);
        	this.tbGridInformation.Name = "tbGridInformation";
        	this.tbGridInformation.ObjectRef = null;
        	this.tbGridInformation.ReadOnly = true;
        	this.tbGridInformation.RegExChars = null;
        	this.tbGridInformation.SaveParam = false;
        	this.tbGridInformation.SaveValueHistory = false;
        	this.tbGridInformation.Size = new System.Drawing.Size(468, 18);
        	this.tbGridInformation.TabIndex = 3;
        	this.tbGridInformation.Text2 = null;
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(487, 4);
        	this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(112, 33);
        	this.btnCancel.TabIndex = 2;
        	this.btnCancel.Text = "   Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// btnOk
        	// 
        	this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(605, 4);
        	this.btnOk.Margin = new System.Windows.Forms.Padding(4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 0;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// grid1
        	// 
        	this.grid1.BackColor = System.Drawing.Color.LightGray;
        	this.grid1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        	this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.grid1.ClipboardMode = SourceGrid.ClipboardMode.Copy;
        	this.grid1.ContextMenuStrip = this.contextMenuGrid;
        	this.grid1.DefaultWidth = 150;
        	this.grid1.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
        	this.grid1.DeleteRowsWithDeleteKey = false;
        	this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.grid1.EnableSort = false;
        	this.grid1.FixedRows = 1;
        	this.grid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.grid1.Location = new System.Drawing.Point(0, 31);
        	this.grid1.Name = "grid1";
        	this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
        	this.grid1.Size = new System.Drawing.Size(723, 301);
        	this.grid1.TabIndex = 28;
        	this.grid1.TabStop = true;
        	this.grid1.ToolTipText = "";
        	this.grid1.DoubleClick += new System.EventHandler(this.Tb_N1_Click);
        	// 
        	// pnlFastSearch
        	// 
        	this.pnlFastSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.pnlFastSearch.BackColor = System.Drawing.SystemColors.Menu;
        	this.pnlFastSearch.Controls.Add(this.cbFastSearch);
        	this.pnlFastSearch.Controls.Add(this.btnFastSearch);
        	this.pnlFastSearch.Location = new System.Drawing.Point(527, 1);
        	this.pnlFastSearch.Name = "pnlFastSearch";
        	this.pnlFastSearch.Size = new System.Drawing.Size(190, 28);
        	this.pnlFastSearch.TabIndex = 29;
        	// 
        	// cbFastSearch
        	// 
        	this.cbFastSearch.AttrBrief = null;
        	this.cbFastSearch.AttrBriefLookup = null;
        	this.cbFastSearch.BackColor = System.Drawing.SystemColors.Window;
        	this.cbFastSearch.ContextMenuEnabled = true;
        	this.cbFastSearch.ContextMenuStrip = this.contextMenuFastSearch;
        	this.cbFastSearch.DefaultTextGrayFont = null;
        	this.cbFastSearch.ErrorIfNull = null;
        	this.cbFastSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbFastSearch.FormattingEnabled = true;
        	this.cbFastSearch.GroupEnabled = null;
        	this.cbFastSearch.ListInvalidChars = null;
        	this.cbFastSearch.ListValidChars = null;
        	this.cbFastSearch.Location = new System.Drawing.Point(2, 1);
        	this.cbFastSearch.Name = "cbFastSearch";
        	this.cbFastSearch.Obj = null;
        	this.cbFastSearch.ObjectID = "";
        	this.cbFastSearch.ObjectRef = null;
        	this.cbFastSearch.ObjRef = null;
        	this.cbFastSearch.ReadOnly = false;
        	this.cbFastSearch.RegExChars = null;
        	this.cbFastSearch.SaveParam = false;
        	this.cbFastSearch.SaveType = null;
        	this.cbFastSearch.SaveValueHistory = false;
        	this.cbFastSearch.Size = new System.Drawing.Size(151, 24);
        	this.cbFastSearch.TabIndex = 3;
        	this.cbFastSearch.Text2 = null;
        	this.cbFastSearch.ValueHistoryInItems = false;
        	this.cbFastSearch.Enter += new System.EventHandler(this.cbFastSearch_Enter);
        	// 
        	// contextMenuFastSearch
        	// 
        	this.contextMenuFastSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.deleteHistoryToolStripMenuItem});
        	this.contextMenuFastSearch.Name = "contextMenuFastSearch";
        	this.contextMenuFastSearch.Size = new System.Drawing.Size(214, 26);
        	// 
        	// deleteHistoryToolStripMenuItem
        	// 
        	this.deleteHistoryToolStripMenuItem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.deleteHistoryToolStripMenuItem.Name = "deleteHistoryToolStripMenuItem";
        	this.deleteHistoryToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
        	this.deleteHistoryToolStripMenuItem.Text = "Delete search history";
        	this.deleteHistoryToolStripMenuItem.Click += new System.EventHandler(this.deleteHistoryToolStripMenuItem_Click);
        	// 
        	// btnFastSearch
        	// 
        	this.btnFastSearch.Image = global::FBA.Resource.Find_16;
        	this.btnFastSearch.Location = new System.Drawing.Point(156, 0);
        	this.btnFastSearch.Name = "btnFastSearch";
        	this.btnFastSearch.Size = new System.Drawing.Size(30, 27);
        	this.btnFastSearch.TabIndex = 1;
        	this.btnFastSearch.UseVisualStyleBackColor = true;
        	this.btnFastSearch.Click += new System.EventHandler(this.btnFastSearch_Click);
        	// 
        	// FormDirectory
        	// 
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        	this.ClientSize = new System.Drawing.Size(723, 373);
        	this.Controls.Add(this.pnlFastSearch);
        	this.Controls.Add(this.grid1);
        	this.Controls.Add(this.pnlResult);
        	this.Controls.Add(this.toolStrip1);
        	this.DoubleBuffered = true;
        	this.Name = "FormDirectory";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "FormDirectory";
        	this.Load += new System.EventHandler(this.FormDirectory_Load);
        	this.contextMenuGrid.ResumeLayout(false);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.pnlResult.ResumeLayout(false);
        	this.pnlResult.PerformLayout();
        	this.pnlFastSearch.ResumeLayout(false);
        	this.contextMenuFastSearch.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        private System.ComponentModel.IContainer components;
        private FBA.GridFBA grid1; //FBA.GridFBA grid1;
        private System.Windows.Forms.ToolTip toolTip1;
        private TextBoxFBA tbGridInformation;
        private System.Windows.Forms.Panel pnlFastSearch;
        private System.Windows.Forms.Button btnFastSearch;
        private ComboBoxFBA cbFastSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuFastSearch;
        private System.Windows.Forms.ToolStripMenuItem deleteHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cm_N7_1;
        private System.Windows.Forms.ToolStripMenuItem cm_N7_2;
        private System.Windows.Forms.ToolStripMenuItem cm_N9_1;
        private System.Windows.Forms.ToolStripMenuItem cm_N9_2;
        private System.Windows.Forms.ToolStripMenuItem cm_N13;
        private System.Windows.Forms.ToolStripMenuItem cm_N13_1;
        private System.Windows.Forms.ToolStripMenuItem cm_N13_2;
        private System.Windows.Forms.ToolStripMenuItem cm_N13_3;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cm_N16_1;
        private System.Windows.Forms.ToolStripMenuItem cm_N16_2;
        private System.Windows.Forms.ToolStripMenuItem cm_N16_3;
        private System.Windows.Forms.ToolStripMenuItem cm_N16_4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cm_N13_4;
        private System.Windows.Forms.ToolStripMenuItem cm_N13_5;
        private System.Windows.Forms.ToolStripMenuItem cm_N13_6;
    }
}
