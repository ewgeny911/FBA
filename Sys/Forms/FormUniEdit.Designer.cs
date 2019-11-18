/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 22.02.2018
 * Время: 10:38
 */
namespace FBA
{
    partial class FormUniEdit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbField;
        CustomFlowLayoutPanel pnlField;
        private System.Windows.Forms.TabPage tbLink;
        private System.Windows.Forms.TabPage tbUniLink;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
              
        private System.Windows.Forms.FlowLayoutPanel pnlLink;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tbHist;
        private FBA.DataGridViewFBA dgvStateDate;
        private FBA.DataGridViewFBA dgvHistAttr;
        private System.Windows.Forms.FlowLayoutPanel pnlUniLink;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabPage tabPage1;
        private SourceGrid.Grid grid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grid = new SourceGrid.Grid();
            this.tbField = new System.Windows.Forms.TabPage();
            this.pnlField = new FBA.CustomFlowLayoutPanel();
            this.tbHist = new System.Windows.Forms.TabPage();
            this.dgvHistAttr = new FBA.DataGridViewFBA();
            this.tbLink = new System.Windows.Forms.TabPage();
            this.pnlLink = new System.Windows.Forms.FlowLayoutPanel();
            this.tbUniLink = new System.Windows.Forms.TabPage();
            this.pnlUniLink = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvStateDate = new FBA.DataGridViewFBA();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.panelButton = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbField.SuspendLayout();
            this.tbHist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistAttr)).BeginInit();
            this.tbLink.SuspendLayout();
            this.tbUniLink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStateDate)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tbField);
            this.tabControl1.Controls.Add(this.tbHist);
            this.tabControl1.Controls.Add(this.tbLink);
            this.tabControl1.Controls.Add(this.tbUniLink);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(987, 488);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grid);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(979, 458);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.EnableSort = true;
            this.grid.Location = new System.Drawing.Point(33, 20);
            this.grid.Name = "grid";
            this.grid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid.Size = new System.Drawing.Size(595, 392);
            this.grid.TabIndex = 1;
            this.grid.TabStop = true;
            this.grid.ToolTipText = "";
            // 
            // tbField
            // 
            this.tbField.Controls.Add(this.pnlField);
            this.tbField.Location = new System.Drawing.Point(4, 26);
            this.tbField.Margin = new System.Windows.Forms.Padding(0);
            this.tbField.Name = "tbField";
            this.tbField.Size = new System.Drawing.Size(979, 458);
            this.tbField.TabIndex = 1;
            this.tbField.Text = "Fields";
            // 
            // pnlField
            // 
            this.pnlField.AutoScroll = true;
            this.pnlField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlField.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlField.Location = new System.Drawing.Point(0, 0);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(979, 458);
            this.pnlField.TabIndex = 1;
            // 
            // tbHist
            // 
            this.tbHist.Controls.Add(this.dgvHistAttr);
            this.tbHist.Location = new System.Drawing.Point(4, 26);
            this.tbHist.Name = "tbHist";
            this.tbHist.Size = new System.Drawing.Size(979, 458);
            this.tbHist.TabIndex = 5;
            this.tbHist.Text = "History";
            this.tbHist.UseVisualStyleBackColor = true;
            // 
            // dgvHistAttr
            // 
            this.dgvHistAttr.AllowUserToAddRows = false;
            this.dgvHistAttr.AllowUserToDeleteRows = false;
            this.dgvHistAttr.AllowUserToOrderColumns = true;
            this.dgvHistAttr.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvHistAttr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistAttr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistAttr.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvHistAttr.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvHistAttr.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHistAttr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistAttr.CommandAdd = false;
            this.dgvHistAttr.CommandDel = false;
            this.dgvHistAttr.CommandEdit = false;
            this.dgvHistAttr.CommandExportToExcel = false;
            this.dgvHistAttr.CommandFilter = false;
            this.dgvHistAttr.CommandRefresh = false;
            this.dgvHistAttr.CommandSaveASCSV = false;
            this.dgvHistAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistAttr.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvHistAttr.EnableHeadersVisualStyles = false;
            this.dgvHistAttr.GroupEnabled = null;
            this.dgvHistAttr.Location = new System.Drawing.Point(0, 0);
            this.dgvHistAttr.Margin = new System.Windows.Forms.Padding(1);
            this.dgvHistAttr.Name = "dgvHistAttr";
            this.dgvHistAttr.ReadOnly = true;
            this.dgvHistAttr.RowHeadersVisible = false;
            this.dgvHistAttr.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistAttr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistAttr.Size = new System.Drawing.Size(979, 458);
            this.dgvHistAttr.TabIndex = 16;
            // 
            // tbLink
            // 
            this.tbLink.Controls.Add(this.pnlLink);
            this.tbLink.Location = new System.Drawing.Point(4, 26);
            this.tbLink.Name = "tbLink";
            this.tbLink.Size = new System.Drawing.Size(979, 458);
            this.tbLink.TabIndex = 2;
            this.tbLink.Text = "Links";
            this.tbLink.UseVisualStyleBackColor = true;
            // 
            // pnlLink
            // 
            this.pnlLink.AutoScroll = true;
            this.pnlLink.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.pnlLink.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLink.Location = new System.Drawing.Point(0, 0);
            this.pnlLink.Name = "pnlLink";
            this.pnlLink.Size = new System.Drawing.Size(979, 458);
            this.pnlLink.TabIndex = 2;
            // 
            // tbUniLink
            // 
            this.tbUniLink.Controls.Add(this.pnlUniLink);
            this.tbUniLink.Location = new System.Drawing.Point(4, 26);
            this.tbUniLink.Name = "tbUniLink";
            this.tbUniLink.Size = new System.Drawing.Size(979, 458);
            this.tbUniLink.TabIndex = 3;
            this.tbUniLink.Text = "Universal Links";
            this.tbUniLink.UseVisualStyleBackColor = true;
            // 
            // pnlUniLink
            // 
            this.pnlUniLink.AutoScroll = true;
            this.pnlUniLink.AutoScrollMargin = new System.Drawing.Size(40, 0);
            this.pnlUniLink.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlUniLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUniLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUniLink.Location = new System.Drawing.Point(0, 0);
            this.pnlUniLink.Name = "pnlUniLink";
            this.pnlUniLink.Size = new System.Drawing.Size(979, 458);
            this.pnlUniLink.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbValue);
            this.splitContainer2.Size = new System.Drawing.Size(1111, 559);
            this.splitContainer2.SplitterDistance = 488;
            this.splitContainer2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvStateDate);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1111, 488);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvStateDate
            // 
            this.dgvStateDate.AllowUserToAddRows = false;
            this.dgvStateDate.AllowUserToDeleteRows = false;
            this.dgvStateDate.AllowUserToOrderColumns = true;
            this.dgvStateDate.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvStateDate.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStateDate.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStateDate.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvStateDate.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvStateDate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvStateDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStateDate.ColumnHeadersVisible = false;
            this.dgvStateDate.CommandAdd = false;
            this.dgvStateDate.CommandDel = false;
            this.dgvStateDate.CommandEdit = false;
            this.dgvStateDate.CommandExportToExcel = false;
            this.dgvStateDate.CommandFilter = false;
            this.dgvStateDate.CommandRefresh = false;
            this.dgvStateDate.CommandSaveASCSV = false;
            this.dgvStateDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStateDate.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStateDate.EnableHeadersVisualStyles = false;
            this.dgvStateDate.GroupEnabled = null;
            this.dgvStateDate.Location = new System.Drawing.Point(0, 27);
            this.dgvStateDate.Margin = new System.Windows.Forms.Padding(1);
            this.dgvStateDate.MultiSelect = false;
            this.dgvStateDate.Name = "dgvStateDate";
            this.dgvStateDate.ReadOnly = true;
            this.dgvStateDate.RowHeadersVisible = false;
            this.dgvStateDate.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStateDate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStateDate.Size = new System.Drawing.Size(120, 461);
            this.dgvStateDate.TabIndex = 17;
            this.dgvStateDate.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStateDate_CellMouseDoubleClick);
            this.dgvStateDate.DoubleClick += new System.EventHandler(this.dgvStateDate_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 27);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "StateDate";
            // 
            // tbValue
            // 
            this.tbValue.BackColor = System.Drawing.SystemColors.Info;
            this.tbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValue.Location = new System.Drawing.Point(0, 0);
            this.tbValue.Multiline = true;
            this.tbValue.Name = "tbValue";
            this.tbValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbValue.Size = new System.Drawing.Size(1111, 67);
            this.tbValue.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.textBox1);
            this.panelButton.Controls.Add(this.button2);
            this.panelButton.Controls.Add(this.dateTimePicker1);
            this.panelButton.Controls.Add(this.button1);
            this.panelButton.Controls.Add(this.btnCancel);
            this.panelButton.Controls.Add(this.btnOk);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelButton.Location = new System.Drawing.Point(0, 559);
            this.panelButton.Margin = new System.Windows.Forms.Padding(4);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1111, 41);
            this.panelButton.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(545, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(275, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Image = global::FBA.Resource.Cancel_24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(875, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "    Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Image = global::FBA.Resource.Save_24;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(991, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 33);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "   Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormUniEdit
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 600);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panelButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormUniEdit";
            this.Text = "Universal object editing";
            this.Load += new System.EventHandler(this.FormUniEdit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tbField.ResumeLayout(false);
            this.tbHist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistAttr)).EndInit();
            this.tbLink.ResumeLayout(false);
            this.tbUniLink.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStateDate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.ResumeLayout(false);

        }              
    }
}
