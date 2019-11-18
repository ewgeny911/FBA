
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 30.09.2017
 * Время: 22:30
 * 
 
 */
namespace FBA
{
    public partial class FormText
    {
                      
        private System.ComponentModel.IContainer components;
        private FBA.LabelFBA lbCapText;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private FastColoredTextBoxNS.FastColoredTextBox tbText;
        private System.Windows.Forms.ContextMenuStrip cmText;
        private System.Windows.Forms.ToolStripMenuItem cmText_N1;
        private System.Windows.Forms.ToolStripMenuItem cmText_N2;
        private System.Windows.Forms.ToolStripMenuItem cmText_N3;
        private System.Windows.Forms.ToolStripMenuItem cmText_N4;
        private DataGridViewFBA dgvText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbRefresh;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private System.Windows.Forms.ToolStripButton tbTransform;
        
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
        	this.lbCapText = new FBA.LabelFBA();
        	this.tbName = new System.Windows.Forms.TextBox();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.dgvText = new FBA.DataGridViewFBA();
        	this.cmText = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmText_N1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmText_N2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmText_N3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmText_N4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.tbText = new FastColoredTextBoxNS.FastColoredTextBox();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.tbRefresh = new System.Windows.Forms.ToolStripButton();
        	this.tbSave = new System.Windows.Forms.ToolStripButton();
        	this.tbAdd = new System.Windows.Forms.ToolStripButton();
        	this.tbDelete = new System.Windows.Forms.ToolStripButton();
        	this.tbTransform = new System.Windows.Forms.ToolStripButton();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvText)).BeginInit();
        	this.cmText.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
        	this.panel2.SuspendLayout();
        	this.toolStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// lbCapText
        	// 
        	this.lbCapText.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbCapText.Location = new System.Drawing.Point(3, 7);
        	this.lbCapText.Name = "lbCapText";
        	this.lbCapText.Size = new System.Drawing.Size(121, 23);
        	this.lbCapText.StarColor = System.Drawing.Color.Crimson;
        	this.lbCapText.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbCapText.StarOffsetX = 2;
        	this.lbCapText.StarOffsetY = 0;
        	this.lbCapText.StarShow = false;
        	this.lbCapText.StarText = "*";
        	this.lbCapText.TabIndex = 0;
        	this.lbCapText.Text = "Name:";
        	// 
        	// tbName
        	// 
        	this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbName.Location = new System.Drawing.Point(139, 3);
        	this.tbName.Margin = new System.Windows.Forms.Padding(73, 5, 73, 5);
        	this.tbName.Name = "tbName";
        	this.tbName.Size = new System.Drawing.Size(298, 25);
        	this.tbName.TabIndex = 17;
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 25);
        	this.splitContainer1.Name = "splitContainer1";
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.dgvText);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.tbText);
        	this.splitContainer1.Panel2.Controls.Add(this.panel2);
        	this.splitContainer1.Size = new System.Drawing.Size(707, 365);
        	this.splitContainer1.SplitterDistance = 238;
        	this.splitContainer1.TabIndex = 18;
        	// 
        	// dgvText
        	// 
        	this.dgvText.AllowUserToAddRows = false;
        	this.dgvText.AllowUserToDeleteRows = false;
        	this.dgvText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvText.CommandAdd = false;
        	this.dgvText.CommandDel = false;
        	this.dgvText.CommandEdit = false;
        	this.dgvText.CommandExportToExcel = false;
        	this.dgvText.CommandFilter = false;
        	this.dgvText.CommandRefresh = false;
        	this.dgvText.CommandSaveASCSV = false;
        	this.dgvText.ContextMenuStrip = this.cmText;
        	this.dgvText.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvText.EnableHeadersVisualStyles = false;
        	this.dgvText.GroupEnabled = null;
        	this.dgvText.Location = new System.Drawing.Point(0, 0);
        	this.dgvText.Name = "dgvText";
        	this.dgvText.Obj = null;
        	this.dgvText.PassedSec = null;
        	this.dgvText.ReadOnly = true;
        	this.dgvText.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvText.Size = new System.Drawing.Size(238, 365);
        	this.dgvText.TabIndex = 0;
        	this.dgvText.DoubleClick += new System.EventHandler(this.DgvTextDoubleClick);
        	// 
        	// cmText
        	// 
        	this.cmText.Font = new System.Drawing.Font("Arial", 11.25F);
        	this.cmText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmText_N1,
			this.cmText_N2,
			this.cmText_N3,
			this.cmText_N4});
        	this.cmText.Name = "cmText";
        	this.cmText.Size = new System.Drawing.Size(129, 92);
        	// 
        	// cmText_N1
        	// 
        	this.cmText_N1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmText_N1.Image = global::FBA.Resource.Add_16;
        	this.cmText_N1.Name = "cmText_N1";
        	this.cmText_N1.Size = new System.Drawing.Size(128, 22);
        	this.cmText_N1.Text = "Add";
        	this.cmText_N1.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// cmText_N2
        	// 
        	this.cmText_N2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmText_N2.Image = global::FBA.Resource.Del_16;
        	this.cmText_N2.Name = "cmText_N2";
        	this.cmText_N2.Size = new System.Drawing.Size(128, 22);
        	this.cmText_N2.Text = "Delete";
        	this.cmText_N2.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// cmText_N3
        	// 
        	this.cmText_N3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmText_N3.Image = global::FBA.Resource.Save_16;
        	this.cmText_N3.Name = "cmText_N3";
        	this.cmText_N3.Size = new System.Drawing.Size(128, 22);
        	this.cmText_N3.Text = "Save";
        	this.cmText_N3.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// cmText_N4
        	// 
        	this.cmText_N4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmText_N4.Image = global::FBA.Resource.Refresh_16;
        	this.cmText_N4.Name = "cmText_N4";
        	this.cmText_N4.Size = new System.Drawing.Size(128, 22);
        	this.cmText_N4.Text = "Refresh";
        	this.cmText_N4.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// tbText
        	// 
        	this.tbText.AutoCompleteBracketsList = new char[] {
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
        	this.tbText.AutoIndentCharsPatterns = "";
        	this.tbText.AutoScrollMinSize = new System.Drawing.Size(33, 21);
        	this.tbText.BackBrush = null;
        	this.tbText.BookmarkColor = System.Drawing.Color.Red;
        	this.tbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.tbText.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
        	this.tbText.CharHeight = 21;
        	this.tbText.CharWidth = 11;
        	this.tbText.CommentPrefix = "--";
        	this.tbText.Cursor = System.Windows.Forms.Cursors.IBeam;
        	this.tbText.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
        	this.tbText.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tbText.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
        	this.tbText.Font = new System.Drawing.Font("Courier New", 14.25F);
        	this.tbText.IsReplaceMode = false;
        	this.tbText.Language = FastColoredTextBoxNS.Language.SQL;
        	this.tbText.LeftBracket = '(';
        	this.tbText.Location = new System.Drawing.Point(0, 38);
        	this.tbText.Name = "tbText";
        	this.tbText.Paddings = new System.Windows.Forms.Padding(0);
        	this.tbText.RightBracket = ')';
        	this.tbText.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
        	this.tbText.Size = new System.Drawing.Size(465, 327);
        	this.tbText.TabIndex = 16;
        	this.tbText.VirtualSpace = true;
        	this.tbText.Zoom = 100;
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.lbCapText);
        	this.panel2.Controls.Add(this.tbName);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel2.Location = new System.Drawing.Point(0, 0);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(465, 38);
        	this.panel2.TabIndex = 5;
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Font = new System.Drawing.Font("Arial", 11.25F);
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbRefresh,
			this.tbSave,
			this.tbAdd,
			this.tbDelete,
			this.tbTransform});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(707, 25);
        	this.toolStrip1.TabIndex = 19;
        	this.toolStrip1.Text = "toolStrip5";
        	// 
        	// tbRefresh
        	// 
        	this.tbRefresh.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRefresh.Image = global::FBA.Resource.Refresh_16;
        	this.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbRefresh.Name = "tbRefresh";
        	this.tbRefresh.Size = new System.Drawing.Size(80, 22);
        	this.tbRefresh.Text = "Refresh";
        	this.tbRefresh.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// tbSave
        	// 
        	this.tbSave.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbSave.Image = global::FBA.Resource.Save_16;
        	this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbSave.Name = "tbSave";
        	this.tbSave.Size = new System.Drawing.Size(61, 22);
        	this.tbSave.Text = "Save";
        	this.tbSave.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// tbAdd
        	// 
        	this.tbAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbAdd.Image = global::FBA.Resource.Add_16;
        	this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbAdd.Name = "tbAdd";
        	this.tbAdd.Size = new System.Drawing.Size(53, 22);
        	this.tbAdd.Text = "Add";
        	this.tbAdd.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// tbDelete
        	// 
        	this.tbDelete.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbDelete.Image = global::FBA.Resource.Del_16;
        	this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbDelete.Name = "tbDelete";
        	this.tbDelete.Size = new System.Drawing.Size(70, 22);
        	this.tbDelete.Text = "Delete";
        	this.tbDelete.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// tbTransform
        	// 
        	this.tbTransform.Image = global::FBA.Resource.method_2;
        	this.tbTransform.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbTransform.Name = "tbTransform";
        	this.tbTransform.Size = new System.Drawing.Size(95, 22);
        	this.tbTransform.Text = "Transform";
        	this.tbTransform.Click += new System.EventHandler(this.cmText_N1_Click);
        	// 
        	// FormText
        	// 
        	//this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
        	//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(707, 390);
        	this.Controls.Add(this.splitContainer1);
        	this.Controls.Add(this.toolStrip1);
        	this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        	this.Name = "FormText";
        	this.Text = "FormText";
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        	this.splitContainer1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvText)).EndInit();
        	this.cmText.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
        	this.panel2.ResumeLayout(false);
        	this.panel2.PerformLayout();
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
    }
}
