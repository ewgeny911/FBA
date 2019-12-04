
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 15.09.2017
 * Время: 16:08
 * 
 
 */
namespace FBA
{
    partial class ProjectService
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
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.dgvProject = new FBA.DataGridViewFBA();
        	this.cmProject = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmProjectN27 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN28 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN31 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
        	this.cmProjectN24 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN23 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN22 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN13 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN21 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN21_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN21_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN21_3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN20 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN20_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN20_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN20_3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN20_4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN30 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
        	this.cmProjectN19 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN18 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
        	this.cmProjectN17 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectN16 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
        	this.cmProjectN29 = new System.Windows.Forms.ToolStripMenuItem();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.tbProjectName = new System.Windows.Forms.TextBox();
        	this.label2 = new FBA.LabelFBA();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tbProject = new System.Windows.Forms.TabPage();
        	this.tbHist = new System.Windows.Forms.TabPage();
        	this.dgvHist = new FBA.GridFBA();
        	this.cmProjectHist = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmProjectHistN2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectHistN3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmProjectHistN4 = new System.Windows.Forms.ToolStripMenuItem();
        	((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
        	this.cmProject.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.tabControl1.SuspendLayout();
        	this.tbProject.SuspendLayout();
        	this.tbHist.SuspendLayout();
        	this.cmProjectHist.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// dgvProject
        	// 
        	this.dgvProject.AllowUserToAddRows = false;
        	this.dgvProject.AllowUserToDeleteRows = false;
        	this.dgvProject.AllowUserToOrderColumns = true;
        	this.dgvProject.AllowUserToResizeRows = false;
        	dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvProject.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        	this.dgvProject.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvProject.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
        	this.dgvProject.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvProject.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvProject.CommandAdd = false;
        	this.dgvProject.CommandDel = false;
        	this.dgvProject.CommandEdit = false;
        	this.dgvProject.CommandExportToExcel = false;
        	this.dgvProject.CommandFilter = false;
        	this.dgvProject.CommandRefresh = false;
        	this.dgvProject.CommandSaveASCSV = false;
        	this.dgvProject.ContextMenuStrip = this.cmProject;
        	this.dgvProject.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvProject.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        	this.dgvProject.EnableHeadersVisualStyles = false;
        	this.dgvProject.GroupEnabled = null;
        	this.dgvProject.Location = new System.Drawing.Point(4, 4);
        	this.dgvProject.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvProject.MultiSelect = false;
        	this.dgvProject.Name = "dgvProject";
        	this.dgvProject.Obj = null;
        	this.dgvProject.PassedSec = null;
        	this.dgvProject.ReadOnly = true;
        	this.dgvProject.RowHeadersVisible = false;
        	this.dgvProject.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvProject.Size = new System.Drawing.Size(584, 320);
        	this.dgvProject.TabIndex = 15;
        	// 
        	// cmProject
        	// 
        	this.cmProject.Font = new System.Drawing.Font("Arial", 11.25F);
        	this.cmProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmProjectN27,
			this.cmProjectN28,
			this.cmProjectN31,
			this.toolStripMenuItem4,
			this.cmProjectN24,
			this.cmProjectN23,
			this.cmProjectN22,
			this.cmProjectN13,
			this.cmProjectN21,
			this.cmProjectN20,
			this.cmProjectN30,
			this.toolStripMenuItem1,
			this.cmProjectN19,
			this.cmProjectN18,
			this.toolStripMenuItem2,
			this.cmProjectN17,
			this.cmProjectN16,
			this.toolStripMenuItem6,
			this.cmProjectN29});
        	this.cmProject.Name = "cmForm";
        	this.cmProject.Size = new System.Drawing.Size(230, 380);
        	this.cmProject.Text = "Show code work";
        	// 
        	// cmProjectN27
        	// 
        	this.cmProjectN27.Name = "cmProjectN27";
        	this.cmProjectN27.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN27.Text = "Save project to Test";
        	this.cmProjectN27.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN28
        	// 
        	this.cmProjectN28.Name = "cmProjectN28";
        	this.cmProjectN28.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN28.Text = "Load project from Work";
        	this.cmProjectN28.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN31
        	// 
        	this.cmProjectN31.Name = "cmProjectN31";
        	this.cmProjectN31.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN31.Text = "Load project from Test";
        	// 
        	// toolStripMenuItem4
        	// 
        	this.toolStripMenuItem4.Name = "toolStripMenuItem4";
        	this.toolStripMenuItem4.Size = new System.Drawing.Size(226, 6);
        	// 
        	// cmProjectN24
        	// 
        	this.cmProjectN24.Name = "cmProjectN24";
        	this.cmProjectN24.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN24.Text = "New";
        	this.cmProjectN24.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN23
        	// 
        	this.cmProjectN23.Name = "cmProjectN23";
        	this.cmProjectN23.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN23.Text = "Rename";
        	this.cmProjectN23.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN22
        	// 
        	this.cmProjectN22.Name = "cmProjectN22";
        	this.cmProjectN22.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN22.Text = "Copy Test To Work";
        	this.cmProjectN22.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN13
        	// 
        	this.cmProjectN13.Name = "cmProjectN13";
        	this.cmProjectN13.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN13.Text = "Copy Test as New";
        	this.cmProjectN13.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN21
        	// 
        	this.cmProjectN21.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmProjectN21_1,
			this.cmProjectN21_2,
			this.cmProjectN21_3});
        	this.cmProjectN21.Name = "cmProjectN21";
        	this.cmProjectN21.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN21.Text = "Set type project";
        	// 
        	// cmProjectN21_1
        	// 
        	this.cmProjectN21_1.Name = "cmProjectN21_1";
        	this.cmProjectN21_1.Size = new System.Drawing.Size(106, 22);
        	this.cmProjectN21_1.Text = "Main";
        	this.cmProjectN21_1.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN21_2
        	// 
        	this.cmProjectN21_2.Name = "cmProjectN21_2";
        	this.cmProjectN21_2.Size = new System.Drawing.Size(106, 22);
        	this.cmProjectN21_2.Text = "App";
        	this.cmProjectN21_2.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN21_3
        	// 
        	this.cmProjectN21_3.Name = "cmProjectN21_3";
        	this.cmProjectN21_3.Size = new System.Drawing.Size(106, 22);
        	this.cmProjectN21_3.Text = "Dll";
        	this.cmProjectN21_3.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN20
        	// 
        	this.cmProjectN20.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmProjectN20_1,
			this.cmProjectN20_2,
			this.cmProjectN20_3,
			this.cmProjectN20_4});
        	this.cmProjectN20.Name = "cmProjectN20";
        	this.cmProjectN20.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN20.Text = "Delete";
        	// 
        	// cmProjectN20_1
        	// 
        	this.cmProjectN20_1.Name = "cmProjectN20_1";
        	this.cmProjectN20_1.Size = new System.Drawing.Size(357, 22);
        	this.cmProjectN20_1.Text = "Delete from Database";
        	this.cmProjectN20_1.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN20_2
        	// 
        	this.cmProjectN20_2.Name = "cmProjectN20_2";
        	this.cmProjectN20_2.Size = new System.Drawing.Size(357, 22);
        	this.cmProjectN20_2.Text = "Delete from Disk";
        	this.cmProjectN20_2.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN20_3
        	// 
        	this.cmProjectN20_3.Name = "cmProjectN20_3";
        	this.cmProjectN20_3.Size = new System.Drawing.Size(357, 22);
        	this.cmProjectN20_3.Text = "Delete from Database and Disk";
        	this.cmProjectN20_3.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN20_4
        	// 
        	this.cmProjectN20_4.Name = "cmProjectN20_4";
        	this.cmProjectN20_4.Size = new System.Drawing.Size(357, 22);
        	this.cmProjectN20_4.Text = "Delete from Database and Disk and History";
        	this.cmProjectN20_4.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN30
        	// 
        	this.cmProjectN30.Name = "cmProjectN30";
        	this.cmProjectN30.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN30.Text = "Find";
        	this.cmProjectN30.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// toolStripMenuItem1
        	// 
        	this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        	this.toolStripMenuItem1.Size = new System.Drawing.Size(226, 6);
        	// 
        	// cmProjectN19
        	// 
        	this.cmProjectN19.Name = "cmProjectN19";
        	this.cmProjectN19.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN19.Text = "Export";
        	this.cmProjectN19.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN18
        	// 
        	this.cmProjectN18.Name = "cmProjectN18";
        	this.cmProjectN18.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN18.Text = "Import";
        	this.cmProjectN18.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// toolStripMenuItem2
        	// 
        	this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        	this.toolStripMenuItem2.Size = new System.Drawing.Size(226, 6);
        	// 
        	// cmProjectN17
        	// 
        	this.cmProjectN17.Name = "cmProjectN17";
        	this.cmProjectN17.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN17.Text = "Set Active";
        	this.cmProjectN17.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// cmProjectN16
        	// 
        	this.cmProjectN16.Name = "cmProjectN16";
        	this.cmProjectN16.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN16.Text = "Set Deleted";
        	this.cmProjectN16.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// toolStripMenuItem6
        	// 
        	this.toolStripMenuItem6.Name = "toolStripMenuItem6";
        	this.toolStripMenuItem6.Size = new System.Drawing.Size(226, 6);
        	// 
        	// cmProjectN29
        	// 
        	this.cmProjectN29.Name = "cmProjectN29";
        	this.cmProjectN29.Size = new System.Drawing.Size(229, 22);
        	this.cmProjectN29.Text = "Refresh";
        	this.cmProjectN29.Click += new System.EventHandler(this.CmFormN14Click);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.tbProjectName);
        	this.panel1.Controls.Add(this.label2);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(600, 34);
        	this.panel1.TabIndex = 16;
        	// 
        	// tbProjectName
        	// 
        	this.tbProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbProjectName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbProjectName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbProjectName.Location = new System.Drawing.Point(165, 5);
        	this.tbProjectName.Margin = new System.Windows.Forms.Padding(4);
        	this.tbProjectName.Name = "tbProjectName";
        	this.tbProjectName.Size = new System.Drawing.Size(426, 25);
        	this.tbProjectName.TabIndex = 6;
        	// 
        	// label2
        	// 
        	this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.Location = new System.Drawing.Point(7, 8);
        	this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(150, 19);
        	this.label2.StarColor = System.Drawing.Color.Crimson;
        	this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label2.StarOffsetX = 2;
        	this.label2.StarOffsetY = 0;
        	this.label2.StarShow = false;
        	this.label2.StarText = "*";
        	this.label2.TabIndex = 5;
        	this.label2.Text = "Current project name:";
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tbProject);
        	this.tabControl1.Controls.Add(this.tbHist);
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabControl1.Location = new System.Drawing.Point(0, 34);
        	this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(600, 358);
        	this.tabControl1.TabIndex = 18;
        	this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
        	// 
        	// tbProject
        	// 
        	this.tbProject.Controls.Add(this.dgvProject);
        	this.tbProject.Location = new System.Drawing.Point(4, 26);
        	this.tbProject.Margin = new System.Windows.Forms.Padding(4);
        	this.tbProject.Name = "tbProject";
        	this.tbProject.Padding = new System.Windows.Forms.Padding(4);
        	this.tbProject.Size = new System.Drawing.Size(592, 328);
        	this.tbProject.TabIndex = 0;
        	this.tbProject.Text = "Projects";
        	this.tbProject.UseVisualStyleBackColor = true;
        	// 
        	// tbHist
        	// 
        	this.tbHist.Controls.Add(this.dgvHist);
        	this.tbHist.Location = new System.Drawing.Point(4, 26);
        	this.tbHist.Margin = new System.Windows.Forms.Padding(4);
        	this.tbHist.Name = "tbHist";
        	this.tbHist.Padding = new System.Windows.Forms.Padding(4);
        	this.tbHist.Size = new System.Drawing.Size(592, 328);
        	this.tbHist.TabIndex = 2;
        	this.tbHist.Text = "Hist";
        	this.tbHist.UseVisualStyleBackColor = true;
        	// 
        	// dgvHist
        	// 
        	this.dgvHist.ClipboardMode = SourceGrid.ClipboardMode.Copy;
        	this.dgvHist.ContextMenuStrip = this.cmProjectHist;
        	this.dgvHist.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
        	this.dgvHist.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvHist.EnableSort = false;
        	this.dgvHist.FixedRows = 1;
        	this.dgvHist.Location = new System.Drawing.Point(4, 4);
        	this.dgvHist.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvHist.Name = "dgvHist";
        	this.dgvHist.SelectionMode = SourceGrid.GridSelectionMode.Row;
        	this.dgvHist.Size = new System.Drawing.Size(584, 320);
        	this.dgvHist.TabIndex = 16;
        	this.dgvHist.TabStop = true;
        	this.dgvHist.ToolTipText = "";
        	// 
        	// cmProjectHist
        	// 
        	this.cmProjectHist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmProjectHistN2,
			this.cmProjectHistN3,
			this.cmProjectHistN4});
        	this.cmProjectHist.Name = "cmFormHist";
        	this.cmProjectHist.Size = new System.Drawing.Size(163, 70);
        	// 
        	// cmProjectHistN2
        	// 
        	this.cmProjectHistN2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmProjectHistN2.Name = "cmProjectHistN2";
        	this.cmProjectHistN2.Size = new System.Drawing.Size(162, 22);
        	this.cmProjectHistN2.Text = "Restore";
        	this.cmProjectHistN2.Click += new System.EventHandler(this.CmProjectHistN1Click);
        	// 
        	// cmProjectHistN3
        	// 
        	this.cmProjectHistN3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmProjectHistN3.Name = "cmProjectHistN3";
        	this.cmProjectHistN3.Size = new System.Drawing.Size(162, 22);
        	this.cmProjectHistN3.Text = "Delete";
        	this.cmProjectHistN3.Click += new System.EventHandler(this.CmProjectHistN1Click);
        	// 
        	// cmProjectHistN4
        	// 
        	this.cmProjectHistN4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmProjectHistN4.Name = "cmProjectHistN4";
        	this.cmProjectHistN4.Size = new System.Drawing.Size(162, 22);
        	this.cmProjectHistN4.Text = "Copy as New";
        	this.cmProjectHistN4.Click += new System.EventHandler(this.CmProjectHistN1Click);
        	// 
        	// ProjectService
        	// 
        	this.ClientSize = new System.Drawing.Size(600, 392);
        	this.Controls.Add(this.tabControl1);
        	this.Controls.Add(this.panel1);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "ProjectService";
        	this.Text = "Operation with forms";
        	((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
        	this.cmProject.ResumeLayout(false);
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	this.tabControl1.ResumeLayout(false);
        	this.tbProject.ResumeLayout(false);
        	this.tbHist.ResumeLayout(false);
        	this.cmProjectHist.ResumeLayout(false);
        	this.ResumeLayout(false);

        }
        private FBA.LabelFBA label2;
        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.Panel panel1;
        private FBA.DataGridViewFBA dgvProject;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbProject;
        private System.Windows.Forms.ContextMenuStrip cmProject;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN24;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN23;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN22;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN18;
        private System.Windows.Forms.TabPage tbHist;
        private FBA.GridFBA dgvHist;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN20;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN21;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN21_1;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN21_2;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN21_3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN19;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN17;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN16;
        private System.Windows.Forms.ContextMenuStrip cmProjectHist;
        private System.Windows.Forms.ToolStripMenuItem cmProjectHistN2;
        private System.Windows.Forms.ToolStripMenuItem cmProjectHistN3;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN13;
        private System.Windows.Forms.ToolStripMenuItem cmProjectHistN4;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN27;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN28;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN29;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN30;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN20_1;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN20_2;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN20_3;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN20_4;
        private System.Windows.Forms.ToolStripMenuItem cmProjectN31;
    }
}
