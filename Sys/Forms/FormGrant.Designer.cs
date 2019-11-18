
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 29.09.2017
 * Время: 14:45
 * 
 
 */
namespace FBA
{
    partial class FormGrant
    {        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tbUser;
        private FBA.DataGridViewFBA dgvUser;
        private System.Windows.Forms.ToolStrip toolStripUser;
        private System.Windows.Forms.ToolStripButton tbUser1;
        private System.Windows.Forms.ToolStripButton tbUser2;
        private System.Windows.Forms.ToolStripButton tbUser3;
        private System.Windows.Forms.ToolStripButton tbUser4;
        private System.Windows.Forms.ToolStripButton tbUser5;
        private System.Windows.Forms.ToolStripButton tbUser6;
        private System.Windows.Forms.TabPage tbRole;
        private FBA.DataGridViewFBA dgvRole;
        private System.Windows.Forms.ToolStrip toolStripRole;
        private System.Windows.Forms.ToolStripButton tbRole1;
        private System.Windows.Forms.ToolStripButton tbRole2;
        private System.Windows.Forms.ToolStripButton tbRole3;
        private System.Windows.Forms.ToolStripButton tbRole4;
        private System.Windows.Forms.TabPage tbRight;
        private FBA.DataGridViewFBA dgvRight;
        private System.Windows.Forms.ToolStrip toolStripRight;
        private System.Windows.Forms.ToolStripButton tbRight4;
        private System.Windows.Forms.ToolStripButton tbRight1;
        private System.Windows.Forms.ToolStripButton tbRight2;
        private System.Windows.Forms.ToolStripButton tbRight3;
        private System.Windows.Forms.ImageList imageList1;
         
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
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGrant));
        	this.tabControlMain = new System.Windows.Forms.TabControl();
        	this.tbUser = new System.Windows.Forms.TabPage();
        	this.dgvUser = new FBA.DataGridViewFBA();
        	this.toolStripUser = new System.Windows.Forms.ToolStrip();
        	this.tbUser4 = new System.Windows.Forms.ToolStripButton();
        	this.tbUser1 = new System.Windows.Forms.ToolStripButton();
        	this.tbUser2 = new System.Windows.Forms.ToolStripButton();
        	this.tbUser3 = new System.Windows.Forms.ToolStripButton();
        	this.tbUser5 = new System.Windows.Forms.ToolStripButton();
        	this.tbUser6 = new System.Windows.Forms.ToolStripButton();
        	this.tbRole = new System.Windows.Forms.TabPage();
        	this.dgvRole = new FBA.DataGridViewFBA();
        	this.toolStripRole = new System.Windows.Forms.ToolStrip();
        	this.tbRole4 = new System.Windows.Forms.ToolStripButton();
        	this.tbRole1 = new System.Windows.Forms.ToolStripButton();
        	this.tbRole3 = new System.Windows.Forms.ToolStripButton();
        	this.tbRole2 = new System.Windows.Forms.ToolStripButton();
        	this.tbRight = new System.Windows.Forms.TabPage();
        	this.dgvRight = new FBA.DataGridViewFBA();
        	this.toolStripRight = new System.Windows.Forms.ToolStrip();
        	this.tbRight4 = new System.Windows.Forms.ToolStripButton();
        	this.tbRight1 = new System.Windows.Forms.ToolStripButton();
        	this.tbRight3 = new System.Windows.Forms.ToolStripButton();
        	this.tbRight2 = new System.Windows.Forms.ToolStripButton();
        	this.tbUserHist = new System.Windows.Forms.TabPage();
        	this.sgHist = new FBA.GridFBA();
        	this.toolStripHist = new System.Windows.Forms.ToolStrip();
        	this.tbHist1 = new System.Windows.Forms.ToolStripButton();
        	this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        	this.tabControlMain.SuspendLayout();
        	this.tbUser.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
        	this.toolStripUser.SuspendLayout();
        	this.tbRole.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvRole)).BeginInit();
        	this.toolStripRole.SuspendLayout();
        	this.tbRight.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvRight)).BeginInit();
        	this.toolStripRight.SuspendLayout();
        	this.tbUserHist.SuspendLayout();
        	this.toolStripHist.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tabControlMain
        	// 
        	this.tabControlMain.Controls.Add(this.tbUser);
        	this.tabControlMain.Controls.Add(this.tbRole);
        	this.tabControlMain.Controls.Add(this.tbRight);
        	this.tabControlMain.Controls.Add(this.tbUserHist);
        	this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControlMain.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabControlMain.ImageList = this.imageList1;
        	this.tabControlMain.Location = new System.Drawing.Point(0, 0);
        	this.tabControlMain.Name = "tabControlMain";
        	this.tabControlMain.SelectedIndex = 0;
        	this.tabControlMain.Size = new System.Drawing.Size(512, 354);
        	this.tabControlMain.TabIndex = 49;
        	this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMainSelectedIndexChanged);
        	// 
        	// tbUser
        	// 
        	this.tbUser.Controls.Add(this.dgvUser);
        	this.tbUser.Controls.Add(this.toolStripUser);
        	this.tbUser.ImageIndex = 0;
        	this.tbUser.Location = new System.Drawing.Point(4, 26);
        	this.tbUser.Name = "tbUser";
        	this.tbUser.Padding = new System.Windows.Forms.Padding(3);
        	this.tbUser.Size = new System.Drawing.Size(504, 324);
        	this.tbUser.TabIndex = 6;
        	this.tbUser.Text = "User";
        	this.tbUser.UseVisualStyleBackColor = true;
        	// 
        	// dgvUser
        	// 
        	this.dgvUser.AllowUserToAddRows = false;
        	this.dgvUser.AllowUserToDeleteRows = false;
        	this.dgvUser.AllowUserToOrderColumns = true;
        	this.dgvUser.AllowUserToResizeRows = false;
        	dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        	this.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvUser.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
        	this.dgvUser.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvUser.CommandAdd = false;
        	this.dgvUser.CommandDel = false;
        	this.dgvUser.CommandEdit = false;
        	this.dgvUser.CommandExportToExcel = false;
        	this.dgvUser.CommandFilter = false;
        	this.dgvUser.CommandRefresh = false;
        	this.dgvUser.CommandSaveASCSV = false;
        	this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        	this.dgvUser.EnableHeadersVisualStyles = false;
        	this.dgvUser.GroupEnabled = null;
        	this.dgvUser.Location = new System.Drawing.Point(3, 28);
        	this.dgvUser.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvUser.MultiSelect = false;
        	this.dgvUser.Name = "dgvUser";
        	this.dgvUser.Obj = null;
        	this.dgvUser.PassedSec = null;
        	this.dgvUser.ReadOnly = true;
        	this.dgvUser.RowHeadersVisible = false;
        	this.dgvUser.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvUser.Size = new System.Drawing.Size(498, 293);
        	this.dgvUser.TabIndex = 2;
        	this.dgvUser.DoubleClick += new System.EventHandler(this.DgvUserDoubleClick);
        	// 
        	// toolStripUser
        	// 
        	this.toolStripUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbUser4,
			this.tbUser1,
			this.tbUser2,
			this.tbUser3,
			this.tbUser5,
			this.tbUser6});
        	this.toolStripUser.Location = new System.Drawing.Point(3, 3);
        	this.toolStripUser.Name = "toolStripUser";
        	this.toolStripUser.Size = new System.Drawing.Size(498, 25);
        	this.toolStripUser.TabIndex = 12;
        	this.toolStripUser.Text = "toolStrip4";
        	// 
        	// tbUser4
        	// 
        	this.tbUser4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUser4.Image = global::FBA.Resource.Refresh_16;
        	this.tbUser4.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUser4.Name = "tbUser4";
        	this.tbUser4.Size = new System.Drawing.Size(80, 22);
        	this.tbUser4.Text = "Refresh";
        	this.tbUser4.Click += new System.EventHandler(this.TbUser1Click);
        	// 
        	// tbUser1
        	// 
        	this.tbUser1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUser1.Image = global::FBA.Resource.Add_16;
        	this.tbUser1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUser1.Name = "tbUser1";
        	this.tbUser1.Size = new System.Drawing.Size(53, 22);
        	this.tbUser1.Text = "Add";
        	this.tbUser1.Click += new System.EventHandler(this.TbUser1Click);
        	// 
        	// tbUser2
        	// 
        	this.tbUser2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUser2.Image = global::FBA.Resource.Del_16;
        	this.tbUser2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUser2.Name = "tbUser2";
        	this.tbUser2.Size = new System.Drawing.Size(50, 22);
        	this.tbUser2.Text = "Del";
        	this.tbUser2.Click += new System.EventHandler(this.TbUser1Click);
        	// 
        	// tbUser3
        	// 
        	this.tbUser3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUser3.Image = global::FBA.Resource.Edit_16;
        	this.tbUser3.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUser3.Name = "tbUser3";
        	this.tbUser3.Size = new System.Drawing.Size(53, 22);
        	this.tbUser3.Text = "Edit";
        	this.tbUser3.Click += new System.EventHandler(this.TbUser1Click);
        	// 
        	// tbUser5
        	// 
        	this.tbUser5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUser5.Image = global::FBA.Resource.block_16;
        	this.tbUser5.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUser5.Name = "tbUser5";
        	this.tbUser5.Size = new System.Drawing.Size(64, 22);
        	this.tbUser5.Text = "Block";
        	this.tbUser5.Click += new System.EventHandler(this.TbUser1Click);
        	// 
        	// tbUser6
        	// 
        	this.tbUser6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUser6.Image = global::FBA.Resource.unblock_16;
        	this.tbUser6.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUser6.Name = "tbUser6";
        	this.tbUser6.Size = new System.Drawing.Size(80, 22);
        	this.tbUser6.Text = "Unblock";
        	this.tbUser6.Click += new System.EventHandler(this.TbUser1Click);
        	// 
        	// tbRole
        	// 
        	this.tbRole.Controls.Add(this.dgvRole);
        	this.tbRole.Controls.Add(this.toolStripRole);
        	this.tbRole.ImageIndex = 1;
        	this.tbRole.Location = new System.Drawing.Point(4, 26);
        	this.tbRole.Name = "tbRole";
        	this.tbRole.Padding = new System.Windows.Forms.Padding(3);
        	this.tbRole.Size = new System.Drawing.Size(504, 324);
        	this.tbRole.TabIndex = 7;
        	this.tbRole.Text = "Role";
        	this.tbRole.UseVisualStyleBackColor = true;
        	// 
        	// dgvRole
        	// 
        	this.dgvRole.AllowUserToAddRows = false;
        	this.dgvRole.AllowUserToDeleteRows = false;
        	this.dgvRole.AllowUserToOrderColumns = true;
        	this.dgvRole.AllowUserToResizeRows = false;
        	dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvRole.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
        	this.dgvRole.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvRole.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
        	this.dgvRole.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvRole.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvRole.CommandAdd = false;
        	this.dgvRole.CommandDel = false;
        	this.dgvRole.CommandEdit = false;
        	this.dgvRole.CommandExportToExcel = false;
        	this.dgvRole.CommandFilter = false;
        	this.dgvRole.CommandRefresh = false;
        	this.dgvRole.CommandSaveASCSV = false;
        	this.dgvRole.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvRole.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        	this.dgvRole.EnableHeadersVisualStyles = false;
        	this.dgvRole.GroupEnabled = null;
        	this.dgvRole.Location = new System.Drawing.Point(3, 28);
        	this.dgvRole.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvRole.MultiSelect = false;
        	this.dgvRole.Name = "dgvRole";
        	this.dgvRole.Obj = null;
        	this.dgvRole.PassedSec = null;
        	this.dgvRole.ReadOnly = true;
        	this.dgvRole.RowHeadersVisible = false;
        	this.dgvRole.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvRole.Size = new System.Drawing.Size(498, 293);
        	this.dgvRole.TabIndex = 5;
        	this.dgvRole.DoubleClick += new System.EventHandler(this.DgvRoleDoubleClick);
        	// 
        	// toolStripRole
        	// 
        	this.toolStripRole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbRole4,
			this.tbRole1,
			this.tbRole3,
			this.tbRole2});
        	this.toolStripRole.Location = new System.Drawing.Point(3, 3);
        	this.toolStripRole.Name = "toolStripRole";
        	this.toolStripRole.Size = new System.Drawing.Size(498, 25);
        	this.toolStripRole.TabIndex = 12;
        	this.toolStripRole.Text = "toolStrip5";
        	// 
        	// tbRole4
        	// 
        	this.tbRole4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRole4.Image = global::FBA.Resource.Refresh_16;
        	this.tbRole4.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRole4.Name = "tbRole4";
        	this.tbRole4.Size = new System.Drawing.Size(80, 22);
        	this.tbRole4.Text = "Refresh";
        	this.tbRole4.Click += new System.EventHandler(this.TbRole1Click);
        	// 
        	// tbRole1
        	// 
        	this.tbRole1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRole1.Image = global::FBA.Resource.Add_16;
        	this.tbRole1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRole1.Name = "tbRole1";
        	this.tbRole1.Size = new System.Drawing.Size(53, 22);
        	this.tbRole1.Text = "Add";
        	this.tbRole1.Click += new System.EventHandler(this.TbRole1Click);
        	// 
        	// tbRole3
        	// 
        	this.tbRole3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRole3.Image = global::FBA.Resource.Edit_16;
        	this.tbRole3.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRole3.Name = "tbRole3";
        	this.tbRole3.Size = new System.Drawing.Size(53, 22);
        	this.tbRole3.Text = "Edit";
        	this.tbRole3.Click += new System.EventHandler(this.TbRole1Click);
        	// 
        	// tbRole2
        	// 
        	this.tbRole2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRole2.Image = global::FBA.Resource.Del_16;
        	this.tbRole2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRole2.Name = "tbRole2";
        	this.tbRole2.Size = new System.Drawing.Size(50, 22);
        	this.tbRole2.Text = "Del";
        	this.tbRole2.Click += new System.EventHandler(this.TbRole1Click);
        	// 
        	// tbRight
        	// 
        	this.tbRight.Controls.Add(this.dgvRight);
        	this.tbRight.Controls.Add(this.toolStripRight);
        	this.tbRight.ImageIndex = 2;
        	this.tbRight.Location = new System.Drawing.Point(4, 26);
        	this.tbRight.Name = "tbRight";
        	this.tbRight.Padding = new System.Windows.Forms.Padding(3);
        	this.tbRight.Size = new System.Drawing.Size(504, 324);
        	this.tbRight.TabIndex = 8;
        	this.tbRight.Text = "Right";
        	this.tbRight.UseVisualStyleBackColor = true;
        	// 
        	// dgvRight
        	// 
        	this.dgvRight.AllowUserToAddRows = false;
        	this.dgvRight.AllowUserToDeleteRows = false;
        	this.dgvRight.AllowUserToOrderColumns = true;
        	this.dgvRight.AllowUserToResizeRows = false;
        	dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvRight.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
        	this.dgvRight.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvRight.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
        	this.dgvRight.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvRight.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvRight.CommandAdd = false;
        	this.dgvRight.CommandDel = false;
        	this.dgvRight.CommandEdit = false;
        	this.dgvRight.CommandExportToExcel = false;
        	this.dgvRight.CommandFilter = false;
        	this.dgvRight.CommandRefresh = false;
        	this.dgvRight.CommandSaveASCSV = false;
        	this.dgvRight.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvRight.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        	this.dgvRight.EnableHeadersVisualStyles = false;
        	this.dgvRight.GroupEnabled = null;
        	this.dgvRight.Location = new System.Drawing.Point(3, 28);
        	this.dgvRight.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvRight.MultiSelect = false;
        	this.dgvRight.Name = "dgvRight";
        	this.dgvRight.Obj = null;
        	this.dgvRight.PassedSec = null;
        	this.dgvRight.ReadOnly = true;
        	this.dgvRight.RowHeadersVisible = false;
        	this.dgvRight.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvRight.Size = new System.Drawing.Size(498, 293);
        	this.dgvRight.TabIndex = 14;
        	this.dgvRight.DoubleClick += new System.EventHandler(this.DgvRightDoubleClick);
        	// 
        	// toolStripRight
        	// 
        	this.toolStripRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbRight4,
			this.tbRight1,
			this.tbRight3,
			this.tbRight2});
        	this.toolStripRight.Location = new System.Drawing.Point(3, 3);
        	this.toolStripRight.Name = "toolStripRight";
        	this.toolStripRight.Size = new System.Drawing.Size(498, 25);
        	this.toolStripRight.TabIndex = 13;
        	this.toolStripRight.Text = "toolStrip4";
        	// 
        	// tbRight4
        	// 
        	this.tbRight4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRight4.Image = global::FBA.Resource.Refresh_16;
        	this.tbRight4.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRight4.Name = "tbRight4";
        	this.tbRight4.Size = new System.Drawing.Size(80, 22);
        	this.tbRight4.Text = "Refresh";
        	this.tbRight4.Click += new System.EventHandler(this.TbRight1Click);
        	// 
        	// tbRight1
        	// 
        	this.tbRight1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRight1.Image = global::FBA.Resource.Add_16;
        	this.tbRight1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRight1.Name = "tbRight1";
        	this.tbRight1.Size = new System.Drawing.Size(53, 22);
        	this.tbRight1.Text = "Add";
        	this.tbRight1.Click += new System.EventHandler(this.TbRight1Click);
        	// 
        	// tbRight3
        	// 
        	this.tbRight3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRight3.Image = global::FBA.Resource.Edit_16;
        	this.tbRight3.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRight3.Name = "tbRight3";
        	this.tbRight3.Size = new System.Drawing.Size(53, 22);
        	this.tbRight3.Text = "Edit";
        	this.tbRight3.Click += new System.EventHandler(this.TbRight1Click);
        	// 
        	// tbRight2
        	// 
        	this.tbRight2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRight2.Image = global::FBA.Resource.Del_16;
        	this.tbRight2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRight2.Name = "tbRight2";
        	this.tbRight2.Size = new System.Drawing.Size(50, 22);
        	this.tbRight2.Text = "Del";
        	this.tbRight2.Click += new System.EventHandler(this.TbRight1Click);
        	// 
        	// tbUserHist
        	// 
        	this.tbUserHist.BackColor = System.Drawing.Color.WhiteSmoke;
        	this.tbUserHist.Controls.Add(this.sgHist);
        	this.tbUserHist.Controls.Add(this.toolStripHist);
        	this.tbUserHist.ImageIndex = 3;
        	this.tbUserHist.Location = new System.Drawing.Point(4, 26);
        	this.tbUserHist.Name = "tbUserHist";
        	this.tbUserHist.Padding = new System.Windows.Forms.Padding(3);
        	this.tbUserHist.Size = new System.Drawing.Size(504, 324);
        	this.tbUserHist.TabIndex = 9;
        	this.tbUserHist.Text = "Logons history";
        	// 
        	// sgHist
        	// 
        	this.sgHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.sgHist.DefaultWidth = 20;
        	this.sgHist.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
        	this.sgHist.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.sgHist.EnableSort = false;
        	this.sgHist.FixedRows = 1;
        	this.sgHist.Location = new System.Drawing.Point(3, 28);
        	this.sgHist.Name = "sgHist";
        	this.sgHist.SelectionMode = SourceGrid.GridSelectionMode.Cell;
        	this.sgHist.Size = new System.Drawing.Size(498, 293);
        	this.sgHist.TabIndex = 15;
        	this.sgHist.TabStop = true;
        	this.sgHist.ToolTipText = "";
        	// 
        	// toolStripHist
        	// 
        	this.toolStripHist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbHist1});
        	this.toolStripHist.Location = new System.Drawing.Point(3, 3);
        	this.toolStripHist.Name = "toolStripHist";
        	this.toolStripHist.Size = new System.Drawing.Size(498, 25);
        	this.toolStripHist.TabIndex = 14;
        	this.toolStripHist.Text = "toolStrip4";
        	// 
        	// tbHist1
        	// 
        	this.tbHist1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbHist1.Image = global::FBA.Resource.Refresh_16;
        	this.tbHist1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbHist1.Name = "tbHist1";
        	this.tbHist1.Size = new System.Drawing.Size(80, 22);
        	this.tbHist1.Text = "Refresh";
        	this.tbHist1.Click += new System.EventHandler(this.TbHist1Click);
        	// 
        	// imageList1
        	// 
        	this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
        	this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        	this.imageList1.Images.SetKeyName(0, "user_16.png");
        	this.imageList1.Images.SetKeyName(1, "role_16.png");
        	this.imageList1.Images.SetKeyName(2, "right_16.png");
        	this.imageList1.Images.SetKeyName(3, "hist_16.png");
        	// 
        	// FormGrant
        	// 
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        	this.ClientSize = new System.Drawing.Size(512, 354);
        	this.Controls.Add(this.tabControlMain);
        	this.DoubleBuffered = true;
        	this.Name = "FormGrant";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Grant";
        	this.Load += new System.EventHandler(this.FormGrantLoad);
        	this.tabControlMain.ResumeLayout(false);
        	this.tbUser.ResumeLayout(false);
        	this.tbUser.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
        	this.toolStripUser.ResumeLayout(false);
        	this.toolStripUser.PerformLayout();
        	this.tbRole.ResumeLayout(false);
        	this.tbRole.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvRole)).EndInit();
        	this.toolStripRole.ResumeLayout(false);
        	this.toolStripRole.PerformLayout();
        	this.tbRight.ResumeLayout(false);
        	this.tbRight.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvRight)).EndInit();
        	this.toolStripRight.ResumeLayout(false);
        	this.toolStripRight.PerformLayout();
        	this.tbUserHist.ResumeLayout(false);
        	this.tbUserHist.PerformLayout();
        	this.toolStripHist.ResumeLayout(false);
        	this.toolStripHist.PerformLayout();
        	this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabPage tbUserHist;
        private FBA.GridFBA sgHist;
        private System.Windows.Forms.ToolStrip toolStripHist;
        private System.Windows.Forms.ToolStripButton tbHist1;
    }
}
