
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.01.2018
 * Время: 13:41
 */
namespace FBA
{
    partial class FormStatus
    {  
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ts1_N1;
        private System.Windows.Forms.ToolStripButton ts1_N2;
        private FBA.DataGridViewFBA dgvEntity;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private FBA.DataGridViewFBA dgvParent;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton ts2_N1;
        private System.Windows.Forms.ToolStripButton ts2_N2;
        private FBA.DataGridViewFBA dgvChange;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton ts3_N1;
        private System.Windows.Forms.ToolStripButton ts3_N2;
        private System.Windows.Forms.ContextMenuStrip cmMenu1;
        private System.Windows.Forms.ToolStripMenuItem cmMenu1_N1;
         
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
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.dgvEntity = new FBA.DataGridViewFBA();
        	this.cmMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmMenu1_N1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.ts1_N1 = new System.Windows.Forms.ToolStripButton();
        	this.ts1_N2 = new System.Windows.Forms.ToolStripButton();
        	this.splitContainer2 = new System.Windows.Forms.SplitContainer();
        	this.dgvParent = new FBA.DataGridViewFBA();
        	this.toolStrip2 = new System.Windows.Forms.ToolStrip();
        	this.ts2_N1 = new System.Windows.Forms.ToolStripButton();
        	this.ts2_N2 = new System.Windows.Forms.ToolStripButton();
        	this.dgvChange = new FBA.DataGridViewFBA();
        	this.toolStrip3 = new System.Windows.Forms.ToolStrip();
        	this.ts3_N1 = new System.Windows.Forms.ToolStripButton();
        	this.ts3_N2 = new System.Windows.Forms.ToolStripButton();
        	this.panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).BeginInit();
        	this.cmMenu1.SuspendLayout();
        	this.toolStrip1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
        	this.splitContainer2.Panel1.SuspendLayout();
        	this.splitContainer2.Panel2.SuspendLayout();
        	this.splitContainer2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvParent)).BeginInit();
        	this.toolStrip2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvChange)).BeginInit();
        	this.toolStrip3.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.splitContainer1);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(745, 400);
        	this.panel1.TabIndex = 0;
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
        	this.splitContainer1.Name = "splitContainer1";
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.dgvEntity);
        	this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
        	this.splitContainer1.Size = new System.Drawing.Size(745, 400);
        	this.splitContainer1.SplitterDistance = 235;
        	this.splitContainer1.SplitterWidth = 5;
        	this.splitContainer1.TabIndex = 1;
        	// 
        	// dgvEntity
        	// 
        	this.dgvEntity.AllowUserToAddRows = false;
        	this.dgvEntity.AllowUserToDeleteRows = false;
        	this.dgvEntity.AllowUserToOrderColumns = true;
        	this.dgvEntity.AllowUserToResizeRows = false;
        	dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvEntity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        	this.dgvEntity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        	this.dgvEntity.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvEntity.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
        	this.dgvEntity.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvEntity.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvEntity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvEntity.CommandAdd = false;
        	this.dgvEntity.CommandDel = false;
        	this.dgvEntity.CommandEdit = false;
        	this.dgvEntity.CommandExportToExcel = false;
        	this.dgvEntity.CommandFilter = false;
        	this.dgvEntity.CommandRefresh = false;
        	this.dgvEntity.CommandSaveASCSV = false;
        	this.dgvEntity.ContextMenuStrip = this.cmMenu1;
        	dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
        	dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
        	dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
        	dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        	this.dgvEntity.DefaultCellStyle = dataGridViewCellStyle2;
        	this.dgvEntity.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvEntity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        	this.dgvEntity.EnableHeadersVisualStyles = false;
        	this.dgvEntity.GroupEnabled = null;
        	this.dgvEntity.Location = new System.Drawing.Point(0, 25);
        	this.dgvEntity.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvEntity.MultiSelect = false;
        	this.dgvEntity.Name = "dgvEntity";
        	this.dgvEntity.Obj = null;
        	this.dgvEntity.PassedSec = null;
        	this.dgvEntity.ReadOnly = true;
        	this.dgvEntity.RowHeadersVisible = false;
        	this.dgvEntity.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvEntity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvEntity.Size = new System.Drawing.Size(235, 375);
        	this.dgvEntity.TabIndex = 2;
        	this.dgvEntity.SelectionChanged += new System.EventHandler(this.DgvEntitySelectionChanged);
        	this.dgvEntity.DoubleClick += new System.EventHandler(this.DgvEntityDoubleClick);
        	// 
        	// cmMenu1
        	// 
        	this.cmMenu1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmMenu1_N1});
        	this.cmMenu1.Name = "cmMenu1";
        	this.cmMenu1.Size = new System.Drawing.Size(129, 26);
        	// 
        	// cmMenu1_N1
        	// 
        	this.cmMenu1_N1.Name = "cmMenu1_N1";
        	this.cmMenu1_N1.Size = new System.Drawing.Size(128, 22);
        	this.cmMenu1_N1.Text = "Refresh";
        	this.cmMenu1_N1.Click += new System.EventHandler(this.cmMenu1_N1_Click);
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts1_N1,
			this.ts1_N2});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(235, 25);
        	this.toolStrip1.TabIndex = 1;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// ts1_N1
        	// 
        	this.ts1_N1.Image = global::FBA.Resource.Add_16;
        	this.ts1_N1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.ts1_N1.Name = "ts1_N1";
        	this.ts1_N1.Size = new System.Drawing.Size(91, 22);
        	this.ts1_N1.Text = "Add entity";
        	this.ts1_N1.Click += new System.EventHandler(this.ts1_N1_Click);
        	// 
        	// ts1_N2
        	// 
        	this.ts1_N2.Image = global::FBA.Resource.Del_16;
        	this.ts1_N2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.ts1_N2.Name = "ts1_N2";
        	this.ts1_N2.Size = new System.Drawing.Size(88, 22);
        	this.ts1_N2.Text = "Del entity";
        	this.ts1_N2.Click += new System.EventHandler(this.ts1_N1_Click);
        	// 
        	// splitContainer2
        	// 
        	this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer2.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer2.Name = "splitContainer2";
        	// 
        	// splitContainer2.Panel1
        	// 
        	this.splitContainer2.Panel1.Controls.Add(this.dgvParent);
        	this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
        	// 
        	// splitContainer2.Panel2
        	// 
        	this.splitContainer2.Panel2.Controls.Add(this.dgvChange);
        	this.splitContainer2.Panel2.Controls.Add(this.toolStrip3);
        	this.splitContainer2.Size = new System.Drawing.Size(505, 400);
        	this.splitContainer2.SplitterDistance = 260;
        	this.splitContainer2.TabIndex = 0;
        	// 
        	// dgvParent
        	// 
        	this.dgvParent.AllowUserToAddRows = false;
        	this.dgvParent.AllowUserToDeleteRows = false;
        	this.dgvParent.AllowUserToOrderColumns = true;
        	this.dgvParent.AllowUserToResizeRows = false;
        	dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvParent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
        	this.dgvParent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        	this.dgvParent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvParent.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
        	this.dgvParent.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvParent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvParent.CommandAdd = false;
        	this.dgvParent.CommandDel = false;
        	this.dgvParent.CommandEdit = false;
        	this.dgvParent.CommandExportToExcel = false;
        	this.dgvParent.CommandFilter = false;
        	this.dgvParent.CommandRefresh = false;
        	this.dgvParent.CommandSaveASCSV = false;
        	this.dgvParent.ContextMenuStrip = this.cmMenu1;
        	dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
        	dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
        	dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
        	dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        	this.dgvParent.DefaultCellStyle = dataGridViewCellStyle4;
        	this.dgvParent.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvParent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        	this.dgvParent.EnableHeadersVisualStyles = false;
        	this.dgvParent.GroupEnabled = null;
        	this.dgvParent.Location = new System.Drawing.Point(0, 25);
        	this.dgvParent.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvParent.MultiSelect = false;
        	this.dgvParent.Name = "dgvParent";
        	this.dgvParent.Obj = null;
        	this.dgvParent.PassedSec = null;
        	this.dgvParent.ReadOnly = true;
        	this.dgvParent.RowHeadersVisible = false;
        	this.dgvParent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvParent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvParent.Size = new System.Drawing.Size(260, 375);
        	this.dgvParent.TabIndex = 3;
        	this.dgvParent.SelectionChanged += new System.EventHandler(this.DgvParentSelectionChanged);
        	this.dgvParent.DoubleClick += new System.EventHandler(this.DgvParentDoubleClick);
        	// 
        	// toolStrip2
        	// 
        	this.toolStrip2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts2_N1,
			this.ts2_N2});
        	this.toolStrip2.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip2.Name = "toolStrip2";
        	this.toolStrip2.Size = new System.Drawing.Size(260, 25);
        	this.toolStrip2.TabIndex = 2;
        	this.toolStrip2.Text = "toolStrip2";
        	// 
        	// ts2_N1
        	// 
        	this.ts2_N1.Image = global::FBA.Resource.Add_16;
        	this.ts2_N1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.ts2_N1.Name = "ts2_N1";
        	this.ts2_N1.Size = new System.Drawing.Size(97, 22);
        	this.ts2_N1.Text = "Add status";
        	this.ts2_N1.Click += new System.EventHandler(this.ts1_N1_Click);
        	// 
        	// ts2_N2
        	// 
        	this.ts2_N2.Image = global::FBA.Resource.Del_16;
        	this.ts2_N2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.ts2_N2.Name = "ts2_N2";
        	this.ts2_N2.Size = new System.Drawing.Size(94, 22);
        	this.ts2_N2.Text = "Del status";
        	this.ts2_N2.Click += new System.EventHandler(this.ts1_N1_Click);
        	// 
        	// dgvChange
        	// 
        	this.dgvChange.AllowUserToAddRows = false;
        	this.dgvChange.AllowUserToDeleteRows = false;
        	this.dgvChange.AllowUserToOrderColumns = true;
        	this.dgvChange.AllowUserToResizeRows = false;
        	dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvChange.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
        	this.dgvChange.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        	this.dgvChange.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvChange.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
        	this.dgvChange.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvChange.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvChange.CommandAdd = false;
        	this.dgvChange.CommandDel = false;
        	this.dgvChange.CommandEdit = false;
        	this.dgvChange.CommandExportToExcel = false;
        	this.dgvChange.CommandFilter = false;
        	this.dgvChange.CommandRefresh = false;
        	this.dgvChange.CommandSaveASCSV = false;
        	this.dgvChange.ContextMenuStrip = this.cmMenu1;
        	dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
        	dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
        	dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Blue;
        	dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        	this.dgvChange.DefaultCellStyle = dataGridViewCellStyle6;
        	this.dgvChange.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvChange.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        	this.dgvChange.EnableHeadersVisualStyles = false;
        	this.dgvChange.GroupEnabled = null;
        	this.dgvChange.Location = new System.Drawing.Point(0, 25);
        	this.dgvChange.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvChange.MultiSelect = false;
        	this.dgvChange.Name = "dgvChange";
        	this.dgvChange.Obj = null;
        	this.dgvChange.PassedSec = null;
        	this.dgvChange.ReadOnly = true;
        	this.dgvChange.RowHeadersVisible = false;
        	this.dgvChange.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvChange.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvChange.Size = new System.Drawing.Size(241, 375);
        	this.dgvChange.TabIndex = 3;
        	// 
        	// toolStrip3
        	// 
        	this.toolStrip3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts3_N1,
			this.ts3_N2});
        	this.toolStrip3.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip3.Name = "toolStrip3";
        	this.toolStrip3.Size = new System.Drawing.Size(241, 25);
        	this.toolStrip3.TabIndex = 2;
        	this.toolStrip3.Text = "toolStrip3";
        	// 
        	// ts3_N1
        	// 
        	this.ts3_N1.Image = global::FBA.Resource.Add_16;
        	this.ts3_N1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.ts3_N1.Name = "ts3_N1";
        	this.ts3_N1.Size = new System.Drawing.Size(105, 22);
        	this.ts3_N1.Text = "Add change";
        	this.ts3_N1.Click += new System.EventHandler(this.ts1_N1_Click);
        	// 
        	// ts3_N2
        	// 
        	this.ts3_N2.Image = global::FBA.Resource.Del_16;
        	this.ts3_N2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.ts3_N2.Name = "ts3_N2";
        	this.ts3_N2.Size = new System.Drawing.Size(102, 22);
        	this.ts3_N2.Text = "Del change";
        	this.ts3_N2.Click += new System.EventHandler(this.ts1_N1_Click);
        	// 
        	// FormStatus
        	// 
        	this.ClientSize = new System.Drawing.Size(745, 400);
        	this.Controls.Add(this.panel1);
        	this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormStatus";
        	this.Text = "Status";
        	this.panel1.ResumeLayout(false);
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel1.PerformLayout();
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        	this.splitContainer1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).EndInit();
        	this.cmMenu1.ResumeLayout(false);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.splitContainer2.Panel1.ResumeLayout(false);
        	this.splitContainer2.Panel1.PerformLayout();
        	this.splitContainer2.Panel2.ResumeLayout(false);
        	this.splitContainer2.Panel2.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
        	this.splitContainer2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvParent)).EndInit();
        	this.toolStrip2.ResumeLayout(false);
        	this.toolStrip2.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvChange)).EndInit();
        	this.toolStrip3.ResumeLayout(false);
        	this.toolStrip3.PerformLayout();
        	this.ResumeLayout(false);

        }
    }
}
