
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 18.12.2017
 * Время: 18:53
 */
namespace FBA
{
    
	/// <summary>
	/// Компонент для отображения дерева сущностей с возможностью поиска по нему.
	/// </summary>
	partial class CompEntityTreeFBA
    {      
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.TreeView treeViewEntity;
        private FBA.DataGridViewFBA dgvFind;
        private System.Windows.Forms.ContextMenuStrip cmModel1;
        private System.Windows.Forms.ToolStripMenuItem cmModel_N1;
        private System.Windows.Forms.ToolStripMenuItem cmModel_N2;
        private System.Windows.Forms.ToolStripMenuItem cmModel_N3;
        private System.Windows.Forms.ToolStripMenuItem cmModel_N4;
        private System.Windows.Forms.ToolStripMenuItem cmModel_N5;
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
        	var resources = new System.ComponentModel.ComponentResourceManager(typeof(CompEntityTreeFBA));
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnFind = new System.Windows.Forms.Button();
        	this.tbFind = new System.Windows.Forms.TextBox();
        	this.treeViewEntity = new System.Windows.Forms.TreeView();
        	this.cmModel1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmModel_N1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmModel_N2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmModel_N3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmModel_N4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmModel_N5 = new System.Windows.Forms.ToolStripMenuItem();
        	this.dgvFind = new FBA.DataGridViewFBA();
        	this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        	this.panel1.SuspendLayout();
        	this.cmModel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvFind)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnFind);
        	this.panel1.Controls.Add(this.tbFind);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(267, 25);
        	this.panel1.TabIndex = 8;
        	// 
        	// btnFind
        	// 
        	this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnFind.Image = global::FBA.Resource.Find_16;
        	this.btnFind.Location = new System.Drawing.Point(219, 0);
        	this.btnFind.Margin = new System.Windows.Forms.Padding(4);
        	this.btnFind.Name = "btnFind";
        	this.btnFind.Size = new System.Drawing.Size(49, 26);
        	this.btnFind.TabIndex = 1;
        	this.btnFind.UseVisualStyleBackColor = true;
        	this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
        	// 
        	// tbFind
        	// 
        	this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbFind.BackColor = System.Drawing.SystemColors.Info;
        	this.tbFind.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbFind.Location = new System.Drawing.Point(0, 0);
        	this.tbFind.Margin = new System.Windows.Forms.Padding(4);
        	this.tbFind.Name = "tbFind";
        	this.tbFind.Size = new System.Drawing.Size(220, 25);
        	this.tbFind.TabIndex = 0;
        	this.tbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFind_KeyDown);
        	// 
        	// treeViewEntity
        	// 
        	this.treeViewEntity.BackColor = System.Drawing.Color.AliceBlue;
        	this.treeViewEntity.ContextMenuStrip = this.cmModel1;
        	this.treeViewEntity.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.treeViewEntity.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.treeViewEntity.Location = new System.Drawing.Point(0, 25);
        	this.treeViewEntity.Margin = new System.Windows.Forms.Padding(5);
        	this.treeViewEntity.Name = "treeViewEntity";
        	this.treeViewEntity.Size = new System.Drawing.Size(267, 339);
        	this.treeViewEntity.TabIndex = 9;
        	this.treeViewEntity.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewEntity_AfterSelect);
        	this.treeViewEntity.DoubleClick += new System.EventHandler(this.TreeViewEntity_DoubleClick);
        	// 
        	// cmModel1
        	// 
        	this.cmModel1.Font = new System.Drawing.Font("Arial", 11.25F);
        	this.cmModel1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmModel_N1,
			this.cmModel_N2,
			this.cmModel_N3,
			this.cmModel_N4,
			this.cmModel_N5});
        	this.cmModel1.Name = "contextMenuStrip1";
        	this.cmModel1.Size = new System.Drawing.Size(136, 114);
        	// 
        	// cmModel_N1
        	// 
        	this.cmModel_N1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmModel_N1.Image = global::FBA.Resource.Add_16;
        	this.cmModel_N1.Name = "cmModel_N1";
        	this.cmModel_N1.Size = new System.Drawing.Size(135, 22);
        	this.cmModel_N1.Text = "Add";
        	this.cmModel_N1.Click += new System.EventHandler(this.cmModel_N1_Click);
        	// 
        	// cmModel_N2
        	// 
        	this.cmModel_N2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmModel_N2.Image = global::FBA.Resource.Add_16;
        	this.cmModel_N2.Name = "cmModel_N2";
        	this.cmModel_N2.Size = new System.Drawing.Size(135, 22);
        	this.cmModel_N2.Text = "Add child";
        	this.cmModel_N2.Click += new System.EventHandler(this.cmModel_N1_Click);
        	// 
        	// cmModel_N3
        	// 
        	this.cmModel_N3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmModel_N3.Image = global::FBA.Resource.Edit_16;
        	this.cmModel_N3.Name = "cmModel_N3";
        	this.cmModel_N3.Size = new System.Drawing.Size(135, 22);
        	this.cmModel_N3.Text = "Edit";
        	this.cmModel_N3.Click += new System.EventHandler(this.cmModel_N1_Click);
        	// 
        	// cmModel_N4
        	// 
        	this.cmModel_N4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmModel_N4.Image = global::FBA.Resource.Del_16;
        	this.cmModel_N4.Name = "cmModel_N4";
        	this.cmModel_N4.Size = new System.Drawing.Size(135, 22);
        	this.cmModel_N4.Text = "Delete";
        	this.cmModel_N4.Click += new System.EventHandler(this.cmModel_N1_Click);
        	// 
        	// cmModel_N5
        	// 
        	this.cmModel_N5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmModel_N5.Image = global::FBA.Resource.Refresh_16;
        	this.cmModel_N5.Name = "cmModel_N5";
        	this.cmModel_N5.Size = new System.Drawing.Size(135, 22);
        	this.cmModel_N5.Text = "Refresh";
        	this.cmModel_N5.Click += new System.EventHandler(this.cmModel_N1_Click);
        	// 
        	// dgvFind
        	// 
        	this.dgvFind.AllowUserToAddRows = false;
        	this.dgvFind.AllowUserToDeleteRows = false;
        	this.dgvFind.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        	this.dgvFind.BackgroundColor = System.Drawing.SystemColors.Info;
        	this.dgvFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvFind.CommandAdd = false;
        	this.dgvFind.CommandDel = false;
        	this.dgvFind.CommandEdit = false;
        	this.dgvFind.CommandExportToExcel = false;
        	this.dgvFind.CommandFilter = false;
        	this.dgvFind.CommandRefresh = false;
        	this.dgvFind.CommandSaveASCSV = false;
        	this.dgvFind.Dock = System.Windows.Forms.DockStyle.Top;
        	this.dgvFind.EnableHeadersVisualStyles = false;
        	this.dgvFind.GroupEnabled = null;
        	this.dgvFind.Location = new System.Drawing.Point(0, 25);
        	this.dgvFind.Margin = new System.Windows.Forms.Padding(5);
        	this.dgvFind.MultiSelect = false;
        	this.dgvFind.Name = "dgvFind";
        	this.dgvFind.Obj = null;
        	this.dgvFind.PassedSec = null;
        	this.dgvFind.ReadOnly = true;
        	this.dgvFind.RowHeadersVisible = false;
        	this.dgvFind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvFind.Size = new System.Drawing.Size(267, 288);
        	this.dgvFind.TabIndex = 10;
        	this.dgvFind.Visible = false;
        	this.dgvFind.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFind_CellClick);
        	// 
        	// imageList1
        	// 
        	this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
        	this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        	this.imageList1.Images.SetKeyName(0, "orange_16.png");
        	this.imageList1.Images.SetKeyName(1, "red_16.png");
        	this.imageList1.Images.SetKeyName(2, "green_16.png");
        	// 
        	// CompEntityTreeFBA
        	// 
        	//this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
        	//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.dgvFind);
        	this.Controls.Add(this.treeViewEntity);
        	this.Controls.Add(this.panel1);
        	this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "CompEntityTreeFBA";
        	this.Size = new System.Drawing.Size(267, 364);
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	this.cmModel1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvFind)).EndInit();
        	this.ResumeLayout(false);
        }
    }
}
