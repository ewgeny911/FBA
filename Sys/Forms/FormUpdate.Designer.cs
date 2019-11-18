
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 28.09.2017
 * Время: 18:31
 * 
 
 */
namespace FBA
{
    partial class FormUpdate
    {
        
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStripUpdate;
        private System.Windows.Forms.ToolStripButton tbUpdate1;
        private System.Windows.Forms.ToolStripButton tbUpdate2;
        private System.Windows.Forms.ToolStripButton tbUpdate3;
        private System.Windows.Forms.ToolStripButton tbUpdate4;
        private System.Windows.Forms.ToolStripButton tbUpdate5;
        private System.Windows.Forms.ToolStripButton tbUpdate6;
        private System.Windows.Forms.ToolStripButton tbUpdate7;
        private System.Windows.Forms.ToolStripButton tbUpdate8;
        private FBA.GridFBA dgvUpdate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private FBA.GridFBA dgvFiles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlbShowUpdate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FBA.GridFBA dgNewFiles;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tlbNewFiles;
        private System.Windows.Forms.ToolStripButton tlbNewUpload;
        private System.Windows.Forms.ToolStripButton tlbDeleteUpdate;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tlbDeleteFile;
        private System.Windows.Forms.ToolStripButton tlbCheck;
        private System.Windows.Forms.ToolStripButton tlbUnCheck;
       
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
        	this.toolStripUpdate = new System.Windows.Forms.ToolStrip();
        	this.tbUpdate1 = new System.Windows.Forms.ToolStripButton();
        	this.tbUpdate2 = new System.Windows.Forms.ToolStripButton();
        	this.tbUpdate3 = new System.Windows.Forms.ToolStripButton();
        	this.tbUpdate4 = new System.Windows.Forms.ToolStripButton();
        	this.tbUpdate5 = new System.Windows.Forms.ToolStripButton();
        	this.tbUpdate6 = new System.Windows.Forms.ToolStripButton();
        	this.tbUpdate7 = new System.Windows.Forms.ToolStripButton();
        	this.tbUpdate8 = new System.Windows.Forms.ToolStripButton();
        	this.dgvUpdate = new FBA.GridFBA();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.tlbShowUpdate = new System.Windows.Forms.ToolStripButton();
        	this.tlbDeleteUpdate = new System.Windows.Forms.ToolStripButton();
        	this.dgvFiles = new FBA.GridFBA();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.toolStrip3 = new System.Windows.Forms.ToolStrip();
        	this.tlbDeleteFile = new System.Windows.Forms.ToolStripButton();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.dgNewFiles = new FBA.GridFBA();
        	this.toolStrip2 = new System.Windows.Forms.ToolStrip();
        	this.tlbNewFiles = new System.Windows.Forms.ToolStripButton();
        	this.tlbNewUpload = new System.Windows.Forms.ToolStripButton();
        	this.tlbCheck = new System.Windows.Forms.ToolStripButton();
        	this.tlbUnCheck = new System.Windows.Forms.ToolStripButton();
        	this.toolStripUpdate.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.toolStrip1.SuspendLayout();
        	this.panel2.SuspendLayout();
        	this.toolStrip3.SuspendLayout();
        	this.tabControl1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	this.toolStrip2.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// toolStripUpdate
        	// 
        	this.toolStripUpdate.Font = new System.Drawing.Font("Arial", 11.25F);
        	this.toolStripUpdate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbUpdate1,
			this.tbUpdate2,
			this.tbUpdate3,
			this.tbUpdate4,
			this.tbUpdate5,
			this.tbUpdate6,
			this.tbUpdate7,
			this.tbUpdate8});
        	this.toolStripUpdate.Location = new System.Drawing.Point(0, 0);
        	this.toolStripUpdate.Name = "toolStripUpdate";
        	this.toolStripUpdate.Size = new System.Drawing.Size(841, 25);
        	this.toolStripUpdate.TabIndex = 12;
        	this.toolStripUpdate.Text = "toolStrip3";
        	// 
        	// tbUpdate1
        	// 
        	this.tbUpdate1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUpdate1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUpdate1.Name = "tbUpdate1";
        	this.tbUpdate1.Size = new System.Drawing.Size(54, 22);
        	this.tbUpdate1.Text = "Check";
        	// 
        	// tbUpdate2
        	// 
        	this.tbUpdate2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUpdate2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUpdate2.Name = "tbUpdate2";
        	this.tbUpdate2.Size = new System.Drawing.Size(105, 22);
        	this.tbUpdate2.Text = "Show updates";
        	// 
        	// tbUpdate3
        	// 
        	this.tbUpdate3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUpdate3.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUpdate3.Name = "tbUpdate3";
        	this.tbUpdate3.Size = new System.Drawing.Size(99, 22);
        	this.tbUpdate3.Text = "Show current";
        	// 
        	// tbUpdate4
        	// 
        	this.tbUpdate4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUpdate4.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUpdate4.Name = "tbUpdate4";
        	this.tbUpdate4.Size = new System.Drawing.Size(54, 22);
        	this.tbUpdate4.Text = "Delete";
        	// 
        	// tbUpdate5
        	// 
        	this.tbUpdate5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUpdate5.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUpdate5.Name = "tbUpdate5";
        	this.tbUpdate5.Size = new System.Drawing.Size(77, 22);
        	this.tbUpdate5.Text = "Download";
        	// 
        	// tbUpdate6
        	// 
        	this.tbUpdate6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUpdate6.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUpdate6.Name = "tbUpdate6";
        	this.tbUpdate6.Size = new System.Drawing.Size(57, 22);
        	this.tbUpdate6.Text = "Upload";
        	// 
        	// tbUpdate7
        	// 
        	this.tbUpdate7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUpdate7.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUpdate7.Name = "tbUpdate7";
        	this.tbUpdate7.Size = new System.Drawing.Size(58, 22);
        	this.tbUpdate7.Text = "Update";
        	// 
        	// tbUpdate8
        	// 
        	this.tbUpdate8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbUpdate8.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbUpdate8.Name = "tbUpdate8";
        	this.tbUpdate8.Size = new System.Drawing.Size(79, 22);
        	this.tbUpdate8.Text = "Show files";
        	// 
        	// dgvUpdate
        	// 
        	this.dgvUpdate.BackColor = System.Drawing.Color.LightGray;
        	this.dgvUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        	this.dgvUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.dgvUpdate.ClipboardMode = SourceGrid.ClipboardMode.Copy;
        	this.dgvUpdate.DefaultWidth = 150;
        	this.dgvUpdate.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
        	this.dgvUpdate.DeleteRowsWithDeleteKey = false;
        	this.dgvUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvUpdate.EnableSort = false;
        	this.dgvUpdate.FixedRows = 1;
        	this.dgvUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.dgvUpdate.Location = new System.Drawing.Point(0, 30);
        	this.dgvUpdate.Name = "dgvUpdate";
        	this.dgvUpdate.SelectionMode = SourceGrid.GridSelectionMode.Row;
        	this.dgvUpdate.Size = new System.Drawing.Size(383, 323);
        	this.dgvUpdate.TabIndex = 29;
        	this.dgvUpdate.TabStop = true;
        	this.dgvUpdate.ToolTipText = "";
        	this.dgvUpdate.Click += new System.EventHandler(this.DgvUpdateClick);
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(3, 3);
        	this.splitContainer1.Name = "splitContainer1";
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.dgvUpdate);
        	this.splitContainer1.Panel1.Controls.Add(this.panel1);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.dgvFiles);
        	this.splitContainer1.Panel2.Controls.Add(this.panel2);
        	this.splitContainer1.Size = new System.Drawing.Size(827, 353);
        	this.splitContainer1.SplitterDistance = 383;
        	this.splitContainer1.TabIndex = 30;
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.toolStrip1);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(383, 30);
        	this.panel1.TabIndex = 31;
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tlbShowUpdate,
			this.tlbDeleteUpdate});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(383, 25);
        	this.toolStrip1.TabIndex = 0;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// tlbShowUpdate
        	// 
        	this.tlbShowUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tlbShowUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tlbShowUpdate.Name = "tlbShowUpdate";
        	this.tlbShowUpdate.Size = new System.Drawing.Size(123, 22);
        	this.tlbShowUpdate.Text = "Show all updates";
        	this.tlbShowUpdate.Click += new System.EventHandler(this.TlbNewFilesClick);
        	// 
        	// tlbDeleteUpdate
        	// 
        	this.tlbDeleteUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tlbDeleteUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tlbDeleteUpdate.Name = "tlbDeleteUpdate";
        	this.tlbDeleteUpdate.Size = new System.Drawing.Size(101, 22);
        	this.tlbDeleteUpdate.Text = "Delele update";
        	this.tlbDeleteUpdate.Click += new System.EventHandler(this.TlbNewFilesClick);
        	// 
        	// dgvFiles
        	// 
        	this.dgvFiles.BackColor = System.Drawing.Color.LightGray;
        	this.dgvFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        	this.dgvFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.dgvFiles.ClipboardMode = SourceGrid.ClipboardMode.Copy;
        	this.dgvFiles.DefaultWidth = 150;
        	this.dgvFiles.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
        	this.dgvFiles.DeleteRowsWithDeleteKey = false;
        	this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvFiles.EnableSort = false;
        	this.dgvFiles.FixedRows = 1;
        	this.dgvFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.dgvFiles.Location = new System.Drawing.Point(0, 30);
        	this.dgvFiles.Name = "dgvFiles";
        	this.dgvFiles.SelectionMode = SourceGrid.GridSelectionMode.Row;
        	this.dgvFiles.Size = new System.Drawing.Size(440, 323);
        	this.dgvFiles.TabIndex = 30;
        	this.dgvFiles.TabStop = true;
        	this.dgvFiles.ToolTipText = "";
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.toolStrip3);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel2.Location = new System.Drawing.Point(0, 0);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(440, 30);
        	this.panel2.TabIndex = 32;
        	// 
        	// toolStrip3
        	// 
        	this.toolStrip3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tlbDeleteFile});
        	this.toolStrip3.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip3.Name = "toolStrip3";
        	this.toolStrip3.Size = new System.Drawing.Size(440, 25);
        	this.toolStrip3.TabIndex = 1;
        	this.toolStrip3.Text = "toolStrip2";
        	// 
        	// tlbDeleteFile
        	// 
        	this.tlbDeleteFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tlbDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tlbDeleteFile.Name = "tlbDeleteFile";
        	this.tlbDeleteFile.Size = new System.Drawing.Size(76, 22);
        	this.tlbDeleteFile.Text = "Delete file";
        	this.tlbDeleteFile.Click += new System.EventHandler(this.TlbNewFilesClick);
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Controls.Add(this.tabPage2);
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl1.Location = new System.Drawing.Point(0, 25);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(841, 389);
        	this.tabControl1.TabIndex = 31;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.splitContainer1);
        	this.tabPage1.Location = new System.Drawing.Point(4, 26);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(833, 359);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Updates";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.dgNewFiles);
        	this.tabPage2.Controls.Add(this.toolStrip2);
        	this.tabPage2.Location = new System.Drawing.Point(4, 26);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(833, 359);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "New update";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// dgNewFiles
        	// 
        	this.dgNewFiles.BackColor = System.Drawing.Color.LightGray;
        	this.dgNewFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        	this.dgNewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.dgNewFiles.ClipboardMode = SourceGrid.ClipboardMode.Copy;
        	this.dgNewFiles.DefaultWidth = 150;
        	this.dgNewFiles.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
        	this.dgNewFiles.DeleteRowsWithDeleteKey = false;
        	this.dgNewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgNewFiles.EnableSort = false;
        	this.dgNewFiles.FixedRows = 1;
        	this.dgNewFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.dgNewFiles.Location = new System.Drawing.Point(3, 28);
        	this.dgNewFiles.Name = "dgNewFiles";
        	this.dgNewFiles.SelectionMode = SourceGrid.GridSelectionMode.Row;
        	this.dgNewFiles.Size = new System.Drawing.Size(827, 328);
        	this.dgNewFiles.TabIndex = 30;
        	this.dgNewFiles.TabStop = true;
        	this.dgNewFiles.ToolTipText = "";
        	// 
        	// toolStrip2
        	// 
        	this.toolStrip2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tlbNewFiles,
			this.tlbNewUpload,
			this.tlbCheck,
			this.tlbUnCheck});
        	this.toolStrip2.Location = new System.Drawing.Point(3, 3);
        	this.toolStrip2.Name = "toolStrip2";
        	this.toolStrip2.Size = new System.Drawing.Size(827, 25);
        	this.toolStrip2.TabIndex = 1;
        	this.toolStrip2.Text = "toolStrip3";
        	// 
        	// tlbNewFiles
        	// 
        	this.tlbNewFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tlbNewFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tlbNewFiles.Name = "tlbNewFiles";
        	this.tlbNewFiles.Size = new System.Drawing.Size(91, 22);
        	this.tlbNewFiles.Text = "Current files";
        	this.tlbNewFiles.Click += new System.EventHandler(this.TlbNewFilesClick);
        	// 
        	// tlbNewUpload
        	// 
        	this.tlbNewUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tlbNewUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tlbNewUpload.Name = "tlbNewUpload";
        	this.tlbNewUpload.Size = new System.Drawing.Size(87, 22);
        	this.tlbNewUpload.Text = "Upload files";
        	this.tlbNewUpload.Click += new System.EventHandler(this.TlbNewFilesClick);
        	// 
        	// tlbCheck
        	// 
        	this.tlbCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tlbCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tlbCheck.Name = "tlbCheck";
        	this.tlbCheck.Size = new System.Drawing.Size(72, 22);
        	this.tlbCheck.Text = "Check all";
        	this.tlbCheck.Click += new System.EventHandler(this.TlbNewFilesClick);
        	// 
        	// tlbUnCheck
        	// 
        	this.tlbUnCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tlbUnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tlbUnCheck.Name = "tlbUnCheck";
        	this.tlbUnCheck.Size = new System.Drawing.Size(90, 22);
        	this.tlbUnCheck.Text = "UnCheck all";
        	this.tlbUnCheck.Click += new System.EventHandler(this.TlbNewFilesClick);
        	// 
        	// FormUpdate
        	// 
        	this.ClientSize = new System.Drawing.Size(841, 414);
        	this.Controls.Add(this.tabControl1);
        	this.Controls.Add(this.toolStripUpdate);
        	this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormUpdate";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "FormUpdate";
        	this.toolStripUpdate.ResumeLayout(false);
        	this.toolStripUpdate.PerformLayout();
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        	this.splitContainer1.ResumeLayout(false);
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.panel2.ResumeLayout(false);
        	this.panel2.PerformLayout();
        	this.toolStrip3.ResumeLayout(false);
        	this.toolStrip3.PerformLayout();
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage2.ResumeLayout(false);
        	this.tabPage2.PerformLayout();
        	this.toolStrip2.ResumeLayout(false);
        	this.toolStrip2.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
    }
}
