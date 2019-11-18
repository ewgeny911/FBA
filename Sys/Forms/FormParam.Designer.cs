
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 07.10.2017
 * Время: 16:21
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace FBA
{
    partial class FormParam
    {
        private System.ComponentModel.IContainer components = null;            
        private System.Windows.Forms.TabPage tbGlobal;
        private System.Windows.Forms.TabPage tbUser;
        private FBA.DataGridViewFBA dgvUser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private FBA.DataGridViewFBA dgvParam;
        private FBA.LabelFBA label1;
        private FBA.LabelFBA label2;
        private System.Windows.Forms.ContextMenuStrip cmParam;
        private System.Windows.Forms.ToolStripMenuItem tbParamN1;
        private System.Windows.Forms.ToolStripMenuItem tbParamN2;
        private System.Windows.Forms.ToolStripMenuItem tbParamN3;
        private System.Windows.Forms.ToolStripMenuItem tbParamN4;
        private System.Windows.Forms.ContextMenuStrip cmUser;
        private System.Windows.Forms.ToolStripMenuItem tbUserN1;
        private System.Windows.Forms.ToolStripMenuItem tbParamN5;
        private System.Windows.Forms.CheckBox cbParamFilter;            
        
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
            this.tbGlobal = new System.Windows.Forms.TabPage();
            this.tbUser = new System.Windows.Forms.TabPage();
            this.dgvUser = new FBA.DataGridViewFBA();
            this.cmUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbUserN1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new FBA.LabelFBA();
            this.dgvParam = new FBA.DataGridViewFBA();
            this.cmParam = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbParamN1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbParamN2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbParamN3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbParamN4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbParamN5 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbParamFilter = new System.Windows.Forms.CheckBox();
            this.label2 = new FBA.LabelFBA();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.cmUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParam)).BeginInit();
            this.cmParam.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbGlobal
            // 
            this.tbGlobal.Location = new System.Drawing.Point(4, 27);
            this.tbGlobal.Name = "tbGlobal";
            this.tbGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tbGlobal.Size = new System.Drawing.Size(466, 343);
            this.tbGlobal.TabIndex = 0;
            this.tbGlobal.Text = "Global";
            this.tbGlobal.UseVisualStyleBackColor = true;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(4, 27);
            this.tbUser.Name = "tbUser";
            this.tbUser.Padding = new System.Windows.Forms.Padding(3);
            this.tbUser.Size = new System.Drawing.Size(237, 169);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = "User";
            this.tbUser.UseVisualStyleBackColor = true;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.AllowUserToResizeRows = false;
            this.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.CommandAdd = false;
            this.dgvUser.CommandDel = false;
            this.dgvUser.CommandEdit = false;
            this.dgvUser.CommandExportToExcel = false;
            this.dgvUser.CommandFilter = false;
            this.dgvUser.CommandRefresh = false;
            this.dgvUser.CommandSaveASCSV = false;
            this.dgvUser.ContextMenuStrip = this.cmUser;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.GroupEnabled = null;
            this.dgvUser.Location = new System.Drawing.Point(0, 25);
            this.dgvUser.Margin = new System.Windows.Forms.Padding(1);
            this.dgvUser.MultiSelect = false;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.Obj = null;
            this.dgvUser.PassedSec = null;
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(196, 417);
            this.dgvUser.TabIndex = 17;      
            this.dgvUser.DoubleClick += new System.EventHandler(this.tbParamN1_Click);
            // 
            // cmUser
            // 
            this.cmUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbUserN1});
            this.cmUser.Name = "cmUser";
            this.cmUser.Size = new System.Drawing.Size(128, 26);
            // 
            // tbUserN1
            // 
            this.tbUserN1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUserN1.Image = global::FBA.Resource.Refresh_16;
            this.tbUserN1.Name = "tbUserN1";
            this.tbUserN1.Size = new System.Drawing.Size(127, 22);
            this.tbUserN1.Text = "Refresh";
            this.tbUserN1.Click += new System.EventHandler(this.tbParamN1_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvUser);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvParam);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1011, 442);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 25);
            this.panel2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.StarColor = System.Drawing.Color.Crimson;
            this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label1.StarOffsetX = 2;
            this.label1.StarOffsetY = 0;
            this.label1.StarShow = false;
            this.label1.StarText = "*";
            this.label1.TabIndex = 0;
            this.label1.Text = "User";
            // 
            // dgvParam
            // 
            this.dgvParam.AllowUserToAddRows = false;
            this.dgvParam.AllowUserToDeleteRows = false;
            this.dgvParam.AllowUserToOrderColumns = true;
            this.dgvParam.AllowUserToResizeRows = false;
            this.dgvParam.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvParam.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvParam.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParam.CommandAdd = false;
            this.dgvParam.CommandDel = false;
            this.dgvParam.CommandEdit = false;
            this.dgvParam.CommandExportToExcel = false;
            this.dgvParam.CommandFilter = false;
            this.dgvParam.CommandRefresh = false;
            this.dgvParam.CommandSaveASCSV = false;
            this.dgvParam.ContextMenuStrip = this.cmParam;
            this.dgvParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParam.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvParam.EnableHeadersVisualStyles = false;
            this.dgvParam.GroupEnabled = null;
            this.dgvParam.Location = new System.Drawing.Point(0, 26);
            this.dgvParam.Margin = new System.Windows.Forms.Padding(1);
            this.dgvParam.MultiSelect = false;
            this.dgvParam.Name = "dgvParam";
            this.dgvParam.Obj = null;
            this.dgvParam.PassedSec = null;
            this.dgvParam.ReadOnly = true;
            this.dgvParam.RowHeadersVisible = false;
            this.dgvParam.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParam.Size = new System.Drawing.Size(810, 416);
            this.dgvParam.TabIndex = 19;
            // 
            // cmParam
            // 
            this.cmParam.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmParam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbParamN1,
            this.tbParamN2,
            this.tbParamN3,
            this.tbParamN4,
            this.tbParamN5});
            this.cmParam.Name = "cmParam";
            this.cmParam.Size = new System.Drawing.Size(129, 114);
            // 
            // tbParamN1
            // 
            this.tbParamN1.Image = global::FBA.Resource.Add_16;
            this.tbParamN1.Name = "tbParamN1";
            this.tbParamN1.Size = new System.Drawing.Size(128, 22);
            this.tbParamN1.Text = "Add";
            this.tbParamN1.Click += new System.EventHandler(this.tbParamN1_Click);
            // 
            // tbParamN2
            // 
            this.tbParamN2.Image = global::FBA.Resource.Edit_16;
            this.tbParamN2.Name = "tbParamN2";
            this.tbParamN2.Size = new System.Drawing.Size(128, 22);
            this.tbParamN2.Text = "Edit";
            this.tbParamN2.Click += new System.EventHandler(this.tbParamN1_Click);
            // 
            // tbParamN3
            // 
            this.tbParamN3.Image = global::FBA.Resource.Del_16;
            this.tbParamN3.Name = "tbParamN3";
            this.tbParamN3.Size = new System.Drawing.Size(128, 22);
            this.tbParamN3.Text = "Del";
            this.tbParamN3.Click += new System.EventHandler(this.tbParamN1_Click);
            // 
            // tbParamN4
            // 
            this.tbParamN4.Image = global::FBA.Resource.Search_16;
            this.tbParamN4.Name = "tbParamN4";
            this.tbParamN4.Size = new System.Drawing.Size(128, 22);
            this.tbParamN4.Text = "Find";
            this.tbParamN4.Click += new System.EventHandler(this.tbParamN1_Click);
            // 
            // tbParamN5
            // 
            this.tbParamN5.Image = global::FBA.Resource.Refresh_16;
            this.tbParamN5.Name = "tbParamN5";
            this.tbParamN5.Size = new System.Drawing.Size(128, 22);
            this.tbParamN5.Text = "Refresh";
            this.tbParamN5.Click += new System.EventHandler(this.tbParamN1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbParamFilter);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(810, 26);
            this.panel3.TabIndex = 20;
            // 
            // cbParamFilter
            // 
            this.cbParamFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbParamFilter.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbParamFilter.Location = new System.Drawing.Point(720, 2);
            this.cbParamFilter.Margin = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.cbParamFilter.Name = "cbParamFilter";
            this.cbParamFilter.Size = new System.Drawing.Size(74, 20);
            this.cbParamFilter.TabIndex = 1;
            this.cbParamFilter.Text = "Filter";
            this.cbParamFilter.UseVisualStyleBackColor = true;
            this.cbParamFilter.CheckedChanged += new System.EventHandler(this.cbParamFilter_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.StarColor = System.Drawing.Color.Crimson;
            this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label2.StarOffsetX = 2;
            this.label2.StarOffsetY = 0;
            this.label2.StarShow = false;
            this.label2.StarText = "*";
            this.label2.TabIndex = 0;
            this.label2.Text = "Param";
            // 
            // FormParam
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 442);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormParam";
            this.Text = "Param";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.cmUser.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParam)).EndInit();
            this.cmParam.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
