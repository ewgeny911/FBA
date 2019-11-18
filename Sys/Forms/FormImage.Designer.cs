
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 12.11.2017
 * Время: 15:45
 */
 
namespace FBA
{
    partial class FormImage
    {         
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbImageRefresh;
        private System.Windows.Forms.ToolStripButton tbImageAddFile;
        private System.Windows.Forms.ToolStripButton tbImageDel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FBA.PictureBoxFBA pictureBox1;
        private FBA.DataGridViewFBA dgvImage;
        private System.Windows.Forms.Panel panel1;
        private FBA.LabelFBA lbFileName;
        private System.Windows.Forms.TextBox tbID;
        private FBA.LabelFBA lbID;
        private System.Windows.Forms.TextBox tbFormat;
        private FBA.LabelFBA lbFormat;
        private System.Windows.Forms.TextBox tbSize;
        private FBA.LabelFBA lbSize;
        private System.Windows.Forms.TextBox tbFileNameFull;
        private FBA.LabelFBA lbFileNameFull;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnImagePath;
        private System.Windows.Forms.ToolStripButton tbImageAddDir;
        private System.Windows.Forms.Panel panelAutoScroll;
        private System.Windows.Forms.CheckBox checkBoxSize;
       
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbImageRefresh = new System.Windows.Forms.ToolStripButton();
            this.tbImageAddFile = new System.Windows.Forms.ToolStripButton();
            this.tbImageAddDir = new System.Windows.Forms.ToolStripButton();
            this.tbImageDel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelAutoScroll = new System.Windows.Forms.Panel();
            this.pictureBox1 = new FBA.PictureBoxFBA();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxSize = new System.Windows.Forms.CheckBox();
            this.btnImagePath = new System.Windows.Forms.Button();
            this.tbFormat = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tbFileNameFull = new System.Windows.Forms.TextBox();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.dgvImage = new FBA.DataGridViewFBA();
            this.dataGridViewFBA1 = new FBA.DataGridViewFBA();
            this.lbFormat = new FBA.LabelFBA();
            this.lbSize = new FBA.LabelFBA();
            this.lbFileNameFull = new FBA.LabelFBA();
            this.lbFileName = new FBA.LabelFBA();
            this.lbID = new FBA.LabelFBA();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelAutoScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFBA1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 11.25F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbImageRefresh,
            this.tbImageAddFile,
            this.tbImageAddDir,
            this.tbImageDel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(701, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip5";
            // 
            // tbImageRefresh
            // 
            this.tbImageRefresh.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbImageRefresh.Image = global::FBA.Resource.Refresh_16;
            this.tbImageRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImageRefresh.Name = "tbImageRefresh";
            this.tbImageRefresh.Size = new System.Drawing.Size(80, 22);
            this.tbImageRefresh.Text = "Refresh";
            this.tbImageRefresh.Click += new System.EventHandler(this.tbImageRefresh_Click);
            // 
            // tbImageAddFile
            // 
            this.tbImageAddFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbImageAddFile.Image = global::FBA.Resource.Add_16;
            this.tbImageAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImageAddFile.Name = "tbImageAddFile";
            this.tbImageAddFile.Size = new System.Drawing.Size(75, 22);
            this.tbImageAddFile.Text = "Add file";
            this.tbImageAddFile.Click += new System.EventHandler(this.tbImageRefresh_Click);
            // 
            // tbImageAddDir
            // 
            this.tbImageAddDir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbImageAddDir.Image = global::FBA.Resource.folder_add_16;
            this.tbImageAddDir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImageAddDir.Name = "tbImageAddDir";
            this.tbImageAddDir.Size = new System.Drawing.Size(73, 22);
            this.tbImageAddDir.Text = "Add dir";
            this.tbImageAddDir.Click += new System.EventHandler(this.tbImageRefresh_Click);
            // 
            // tbImageDel
            // 
            this.tbImageDel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbImageDel.Image = global::FBA.Resource.Del_16;
            this.tbImageDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImageDel.Name = "tbImageDel";
            this.tbImageDel.Size = new System.Drawing.Size(70, 22);
            this.tbImageDel.Text = "Delete";
            this.tbImageDel.Click += new System.EventHandler(this.tbImageRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelAutoScroll);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(701, 399);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 16;
            // 
            // panelAutoScroll
            // 
            this.panelAutoScroll.AutoScroll = true;
            this.panelAutoScroll.AutoSize = true;
            this.panelAutoScroll.Controls.Add(this.pictureBox1);
            this.panelAutoScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAutoScroll.Location = new System.Drawing.Point(0, 135);
            this.panelAutoScroll.Name = "panelAutoScroll";
            this.panelAutoScroll.Size = new System.Drawing.Size(466, 264);
            this.panelAutoScroll.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::FBA.Resource.no_foto_1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(466, 264);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewFBA1);
            this.panel1.Controls.Add(this.checkBoxSize);
            this.panel1.Controls.Add(this.btnImagePath);
            this.panel1.Controls.Add(this.tbFormat);
            this.panel1.Controls.Add(this.lbFormat);
            this.panel1.Controls.Add(this.tbSize);
            this.panel1.Controls.Add(this.lbSize);
            this.panel1.Controls.Add(this.tbFileNameFull);
            this.panel1.Controls.Add(this.lbFileNameFull);
            this.panel1.Controls.Add(this.tbFileName);
            this.panel1.Controls.Add(this.lbFileName);
            this.panel1.Controls.Add(this.tbID);
            this.panel1.Controls.Add(this.lbID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 135);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxSize
            // 
            this.checkBoxSize.Location = new System.Drawing.Point(5, 102);
            this.checkBoxSize.Name = "checkBoxSize";
            this.checkBoxSize.Size = new System.Drawing.Size(192, 24);
            this.checkBoxSize.TabIndex = 11;
            this.checkBoxSize.Text = "Show full size image";
            this.checkBoxSize.UseVisualStyleBackColor = true;
            this.checkBoxSize.CheckedChanged += new System.EventHandler(this.checkBoxSize_CheckedChanged);
            // 
            // btnImagePath
            // 
            this.btnImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImagePath.Image = global::FBA.Resource.Folder_24;
            this.btnImagePath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImagePath.Location = new System.Drawing.Point(300, 98);
            this.btnImagePath.Name = "btnImagePath";
            this.btnImagePath.Size = new System.Drawing.Size(157, 33);
            this.btnImagePath.TabIndex = 10;
            this.btnImagePath.Text = "Open image path";
            this.btnImagePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImagePath.UseVisualStyleBackColor = true;
            this.btnImagePath.Click += new System.EventHandler(this.tbImageRefresh_Click);
            // 
            // tbFormat
            // 
            this.tbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFormat.BackColor = System.Drawing.SystemColors.Info;
            this.tbFormat.Location = new System.Drawing.Point(405, 4);
            this.tbFormat.Margin = new System.Windows.Forms.Padding(4);
            this.tbFormat.Name = "tbFormat";
            this.tbFormat.Size = new System.Drawing.Size(52, 25);
            this.tbFormat.TabIndex = 9;
            // 
            // tbSize
            // 
            this.tbSize.BackColor = System.Drawing.SystemColors.Info;
            this.tbSize.Location = new System.Drawing.Point(225, 4);
            this.tbSize.Margin = new System.Windows.Forms.Padding(4);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(110, 25);
            this.tbSize.TabIndex = 7;
            // 
            // tbFileNameFull
            // 
            this.tbFileNameFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileNameFull.BackColor = System.Drawing.SystemColors.Info;
            this.tbFileNameFull.Location = new System.Drawing.Point(117, 66);
            this.tbFileNameFull.Margin = new System.Windows.Forms.Padding(4);
            this.tbFileNameFull.Name = "tbFileNameFull";
            this.tbFileNameFull.Size = new System.Drawing.Size(340, 25);
            this.tbFileNameFull.TabIndex = 5;
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.BackColor = System.Drawing.SystemColors.Info;
            this.tbFileName.Location = new System.Drawing.Point(117, 35);
            this.tbFileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(340, 25);
            this.tbFileName.TabIndex = 3;
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.SystemColors.Info;
            this.tbID.Location = new System.Drawing.Point(117, 5);
            this.tbID.Margin = new System.Windows.Forms.Padding(4);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(61, 25);
            this.tbID.TabIndex = 1;
            // 
            // dgvImage
            // 
            this.dgvImage.AllowUserToAddRows = false;
            this.dgvImage.AllowUserToDeleteRows = false;
            this.dgvImage.AllowUserToOrderColumns = true;
            this.dgvImage.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvImage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvImage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvImage.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvImage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImage.CommandAdd = false;
            this.dgvImage.CommandDel = false;
            this.dgvImage.CommandEdit = false;
            this.dgvImage.CommandExportToExcel = false;
            this.dgvImage.CommandFilter = false;
            this.dgvImage.CommandRefresh = false;
            this.dgvImage.CommandSaveASCSV = false;
            this.dgvImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvImage.EnableHeadersVisualStyles = false;
            this.dgvImage.GroupEnabled = null;
            this.dgvImage.Location = new System.Drawing.Point(0, 0);
            this.dgvImage.Margin = new System.Windows.Forms.Padding(1);
            this.dgvImage.MultiSelect = false;
            this.dgvImage.Name = "dgvImage";
            this.dgvImage.Obj = null;
            this.dgvImage.PassedSec = null;
            this.dgvImage.ReadOnly = true;
            this.dgvImage.RowHeadersVisible = false;
            this.dgvImage.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImage.Size = new System.Drawing.Size(230, 399);
            this.dgvImage.TabIndex = 15;
            this.dgvImage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImage_CellClick);
            // 
            // dataGridViewFBA1
            // 
            this.dataGridViewFBA1.AllowUserToAddRows = false;
            this.dataGridViewFBA1.AllowUserToDeleteRows = false;
            this.dataGridViewFBA1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFBA1.CommandAdd = false;
            this.dataGridViewFBA1.CommandDel = false;
            this.dataGridViewFBA1.CommandEdit = false;
            this.dataGridViewFBA1.CommandExportToExcel = false;
            this.dataGridViewFBA1.CommandFilter = false;
            this.dataGridViewFBA1.CommandRefresh = false;
            this.dataGridViewFBA1.CommandSaveASCSV = false;
            this.dataGridViewFBA1.EnableHeadersVisualStyles = false;
            this.dataGridViewFBA1.GroupEnabled = null;
            this.dataGridViewFBA1.Location = new System.Drawing.Point(142, 135);
            this.dataGridViewFBA1.Name = "dataGridViewFBA1";
            this.dataGridViewFBA1.Obj = null;
            this.dataGridViewFBA1.PassedSec = null;
            this.dataGridViewFBA1.ReadOnly = true;
            this.dataGridViewFBA1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFBA1.Size = new System.Drawing.Size(240, 113);
            this.dataGridViewFBA1.TabIndex = 12;
            // 
            // lbFormat
            // 
            this.lbFormat.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFormat.Location = new System.Drawing.Point(340, 7);
            this.lbFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(55, 19);
            this.lbFormat.StarColor = System.Drawing.Color.Crimson;
            this.lbFormat.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbFormat.StarOffsetX = 2;
            this.lbFormat.StarOffsetY = 0;
            this.lbFormat.StarShow = false;
            this.lbFormat.StarText = "*";
            this.lbFormat.TabIndex = 8;
            this.lbFormat.Text = "Format:";
            // 
            // lbSize
            // 
            this.lbSize.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSize.Location = new System.Drawing.Point(186, 8);
            this.lbSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(46, 19);
            this.lbSize.StarColor = System.Drawing.Color.Crimson;
            this.lbSize.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbSize.StarOffsetX = 2;
            this.lbSize.StarOffsetY = 0;
            this.lbSize.StarShow = false;
            this.lbSize.StarText = "*";
            this.lbSize.TabIndex = 6;
            this.lbSize.Text = "Size:";
            // 
            // lbFileNameFull
            // 
            this.lbFileNameFull.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFileNameFull.Location = new System.Drawing.Point(5, 69);
            this.lbFileNameFull.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFileNameFull.Name = "lbFileNameFull";
            this.lbFileNameFull.Size = new System.Drawing.Size(104, 19);
            this.lbFileNameFull.StarColor = System.Drawing.Color.Crimson;
            this.lbFileNameFull.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbFileNameFull.StarOffsetX = 2;
            this.lbFileNameFull.StarOffsetY = 0;
            this.lbFileNameFull.StarShow = false;
            this.lbFileNameFull.StarText = "*";
            this.lbFileNameFull.TabIndex = 4;
            this.lbFileNameFull.Text = "FileNameFull:";
            // 
            // lbFileName
            // 
            this.lbFileName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFileName.Location = new System.Drawing.Point(5, 38);
            this.lbFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(85, 19);
            this.lbFileName.StarColor = System.Drawing.Color.Crimson;
            this.lbFileName.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbFileName.StarOffsetX = 2;
            this.lbFileName.StarOffsetY = 0;
            this.lbFileName.StarShow = false;
            this.lbFileName.StarText = "*";
            this.lbFileName.TabIndex = 2;
            this.lbFileName.Text = "FileName:";
            // 
            // lbID
            // 
            this.lbID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbID.Location = new System.Drawing.Point(5, 8);
            this.lbID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(35, 19);
            this.lbID.StarColor = System.Drawing.Color.Crimson;
            this.lbID.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbID.StarOffsetX = 2;
            this.lbID.StarOffsetY = 0;
            this.lbID.StarShow = false;
            this.lbID.StarText = "*";
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID:";
            // 
            // FormImage
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 424);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelAutoScroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFBA1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridViewFBA dataGridViewFBA1;
    }
}
