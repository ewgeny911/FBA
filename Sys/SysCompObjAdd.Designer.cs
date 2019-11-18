/*
 * Created by SharpDevelop.
 * User: Evgeniy.Travin
 * Date: 20.08.2019
 * Time: 11:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FBA
{
	partial class SysObjAdd
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel pnlObj2;
		private FBA.DataGridViewFBA dgvObj1;
		private FBA.DataGridViewFBA dgvObj2;
		private System.Windows.Forms.Panel pnlText2;
		private System.Windows.Forms.Label lbText2;
		private System.Windows.Forms.Panel pnlObjSplitter;
		private System.Windows.Forms.Button btnObjDelAll;
		private System.Windows.Forms.Button btnObjDel;
		private System.Windows.Forms.Button btnObjAddAll;
		private System.Windows.Forms.Button btnObjAdd;		
		private System.Windows.Forms.Panel pnlText1;
		private System.Windows.Forms.Label lbText1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel pnlObj1;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pnlObj1 = new System.Windows.Forms.Panel();
			this.dgvObj1 = new FBA.DataGridViewFBA();
			this.pnlText1 = new System.Windows.Forms.Panel();
			this.lbText1 = new System.Windows.Forms.Label();
			this.pnlObjSplitter = new System.Windows.Forms.Panel();
			this.btnObjDelAll = new System.Windows.Forms.Button();
			this.btnObjDel = new System.Windows.Forms.Button();
			this.btnObjAddAll = new System.Windows.Forms.Button();
			this.btnObjAdd = new System.Windows.Forms.Button();
			this.pnlObj2 = new System.Windows.Forms.Panel();
			this.dgvObj2 = new FBA.DataGridViewFBA();
			this.pnlText2 = new System.Windows.Forms.Panel();
			this.lbText2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.pnlObj1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvObj1)).BeginInit();
			this.pnlText1.SuspendLayout();
			this.pnlObjSplitter.SuspendLayout();
			this.pnlObj2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvObj2)).BeginInit();
			this.pnlText2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.pnlObj1);
			this.splitContainer1.Panel1.Controls.Add(this.pnlObjSplitter);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pnlObj2);
			this.splitContainer1.Size = new System.Drawing.Size(348, 216);
			this.splitContainer1.SplitterDistance = 195;
			this.splitContainer1.SplitterWidth = 3;
			this.splitContainer1.TabIndex = 31;
			// 
			// pnlObj1
			// 
			this.pnlObj1.Controls.Add(this.dgvObj1);
			this.pnlObj1.Controls.Add(this.pnlText1);
			this.pnlObj1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlObj1.Location = new System.Drawing.Point(0, 0);
			this.pnlObj1.Name = "pnlObj1";
			this.pnlObj1.Size = new System.Drawing.Size(151, 216);
			this.pnlObj1.TabIndex = 3;
			// 
			// dgvObj1
			// 
			this.dgvObj1.AllowUserToAddRows = false;
			this.dgvObj1.AllowUserToDeleteRows = false;
			this.dgvObj1.AllowUserToOrderColumns = true;
			this.dgvObj1.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvObj1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvObj1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvObj1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvObj1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvObj1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvObj1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvObj1.CommandAdd = false;
			this.dgvObj1.CommandDel = false;
			this.dgvObj1.CommandEdit = false;
			this.dgvObj1.CommandExportToExcel = false;
			this.dgvObj1.CommandFilter = false;
			this.dgvObj1.CommandRefresh = false;
			this.dgvObj1.CommandSaveASCSV = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvObj1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvObj1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvObj1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvObj1.EnableHeadersVisualStyles = false;
			this.dgvObj1.GroupEnabled = null;
			this.dgvObj1.Location = new System.Drawing.Point(0, 29);
			this.dgvObj1.Margin = new System.Windows.Forms.Padding(1);
			this.dgvObj1.MultiSelect = false;
			this.dgvObj1.Name = "dgvObj1";
			this.dgvObj1.Obj = null;
			this.dgvObj1.PassedSec = null;
			this.dgvObj1.ReadOnly = true;
			this.dgvObj1.RowHeadersVisible = false;
			this.dgvObj1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvObj1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvObj1.Size = new System.Drawing.Size(151, 187);
			this.dgvObj1.TabIndex = 4;
			// 
			// pnlText1
			// 
			this.pnlText1.BackColor = System.Drawing.SystemColors.Menu;
			this.pnlText1.Controls.Add(this.lbText1);
			this.pnlText1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlText1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.pnlText1.Location = new System.Drawing.Point(0, 0);
			this.pnlText1.Name = "pnlText1";
			this.pnlText1.Size = new System.Drawing.Size(151, 29);
			this.pnlText1.TabIndex = 3;
			// 
			// lbText1
			// 
			this.lbText1.Location = new System.Drawing.Point(4, 4);
			this.lbText1.Name = "lbText1";
			this.lbText1.Size = new System.Drawing.Size(100, 23);
			this.lbText1.TabIndex = 0;
			this.lbText1.Text = "Available";
			// 
			// pnlObjSplitter
			// 
			this.pnlObjSplitter.Controls.Add(this.btnObjDelAll);
			this.pnlObjSplitter.Controls.Add(this.btnObjDel);
			this.pnlObjSplitter.Controls.Add(this.btnObjAddAll);
			this.pnlObjSplitter.Controls.Add(this.btnObjAdd);
			this.pnlObjSplitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlObjSplitter.Location = new System.Drawing.Point(151, 0);
			this.pnlObjSplitter.Margin = new System.Windows.Forms.Padding(4);
			this.pnlObjSplitter.Name = "pnlObjSplitter";
			this.pnlObjSplitter.Size = new System.Drawing.Size(44, 216);
			this.pnlObjSplitter.TabIndex = 3;
			// 
			// btnObjDelAll
			// 
			this.btnObjDelAll.Image = global::FBA.Resource.Delete_24;
			this.btnObjDelAll.Location = new System.Drawing.Point(4, 118);
			this.btnObjDelAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnObjDelAll.Name = "btnObjDelAll";
			this.btnObjDelAll.Size = new System.Drawing.Size(38, 34);
			this.btnObjDelAll.TabIndex = 3;
			this.btnObjDelAll.UseVisualStyleBackColor = true;
			this.btnObjDelAll.Click += new System.EventHandler(this.BtnObjAddClick);
			// 
			// btnObjDel
			// 
			this.btnObjDel.Image = global::FBA.Resource.Back_24;
			this.btnObjDel.Location = new System.Drawing.Point(4, 42);
			this.btnObjDel.Margin = new System.Windows.Forms.Padding(4);
			this.btnObjDel.Name = "btnObjDel";
			this.btnObjDel.Size = new System.Drawing.Size(38, 34);
			this.btnObjDel.TabIndex = 2;
			this.btnObjDel.UseVisualStyleBackColor = true;
			this.btnObjDel.Click += new System.EventHandler(this.BtnObjAddClick);
			// 
			// btnObjAddAll
			// 
			this.btnObjAddAll.Image = global::FBA.Resource.Yes_24;
			this.btnObjAddAll.Location = new System.Drawing.Point(4, 80);
			this.btnObjAddAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnObjAddAll.Name = "btnObjAddAll";
			this.btnObjAddAll.Size = new System.Drawing.Size(38, 34);
			this.btnObjAddAll.TabIndex = 1;
			this.btnObjAddAll.UseVisualStyleBackColor = true;
			this.btnObjAddAll.Click += new System.EventHandler(this.BtnObjAddClick);
			// 
			// btnObjAdd
			// 
			this.btnObjAdd.Image = global::FBA.Resource.Forward_24;
			this.btnObjAdd.Location = new System.Drawing.Point(4, 4);
			this.btnObjAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnObjAdd.Name = "btnObjAdd";
			this.btnObjAdd.Size = new System.Drawing.Size(38, 34);
			this.btnObjAdd.TabIndex = 0;
			this.btnObjAdd.UseVisualStyleBackColor = true;
			this.btnObjAdd.Click += new System.EventHandler(this.BtnObjAddClick);
			// 
			// pnlObj2
			// 
			this.pnlObj2.Controls.Add(this.dgvObj2);
			this.pnlObj2.Controls.Add(this.pnlText2);
			this.pnlObj2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlObj2.Location = new System.Drawing.Point(0, 0);
			this.pnlObj2.Margin = new System.Windows.Forms.Padding(4);
			this.pnlObj2.Name = "pnlObj2";
			this.pnlObj2.Size = new System.Drawing.Size(150, 216);
			this.pnlObj2.TabIndex = 3;
			// 
			// dgvObj2
			// 
			this.dgvObj2.AllowUserToAddRows = false;
			this.dgvObj2.AllowUserToDeleteRows = false;
			this.dgvObj2.AllowUserToOrderColumns = true;
			this.dgvObj2.AllowUserToResizeRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvObj2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvObj2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvObj2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvObj2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvObj2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvObj2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvObj2.CommandAdd = false;
			this.dgvObj2.CommandDel = false;
			this.dgvObj2.CommandEdit = false;
			this.dgvObj2.CommandExportToExcel = false;
			this.dgvObj2.CommandFilter = false;
			this.dgvObj2.CommandRefresh = false;
			this.dgvObj2.CommandSaveASCSV = false;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvObj2.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvObj2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvObj2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvObj2.EnableHeadersVisualStyles = false;
			this.dgvObj2.GroupEnabled = null;
			this.dgvObj2.Location = new System.Drawing.Point(0, 29);
			this.dgvObj2.Margin = new System.Windows.Forms.Padding(1);
			this.dgvObj2.MultiSelect = false;
			this.dgvObj2.Name = "dgvObj2";
			this.dgvObj2.Obj = null;
			this.dgvObj2.PassedSec = null;
			this.dgvObj2.ReadOnly = true;
			this.dgvObj2.RowHeadersVisible = false;
			this.dgvObj2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvObj2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvObj2.Size = new System.Drawing.Size(150, 187);
			this.dgvObj2.TabIndex = 1;
			// 
			// pnlText2
			// 
			this.pnlText2.BackColor = System.Drawing.SystemColors.Menu;
			this.pnlText2.Controls.Add(this.lbText2);
			this.pnlText2.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlText2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.pnlText2.Location = new System.Drawing.Point(0, 0);
			this.pnlText2.Name = "pnlText2";
			this.pnlText2.Size = new System.Drawing.Size(150, 29);
			this.pnlText2.TabIndex = 3;
			// 
			// lbText2
			// 
			this.lbText2.Location = new System.Drawing.Point(3, 4);
			this.lbText2.Name = "lbText2";
			this.lbText2.Size = new System.Drawing.Size(100, 23);
			this.lbText2.TabIndex = 1;
			this.lbText2.Text = "Selected";
			// 
			// SysObjAdd
			// 
			this.Controls.Add(this.splitContainer1);
			this.Name = "SysObjAdd";
			this.Size = new System.Drawing.Size(348, 216);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.pnlObj1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvObj1)).EndInit();
			this.pnlText1.ResumeLayout(false);
			this.pnlObjSplitter.ResumeLayout(false);
			this.pnlObj2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvObj2)).EndInit();
			this.pnlText2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
