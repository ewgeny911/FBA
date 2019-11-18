/*
 * Created by SharpDevelop.
 * User: Evgeniy.Travin
 * Date: 05.07.2019
 * Time: 13:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FBA
{
	partial class FormMethod
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tbRefresh;
		private System.Windows.Forms.ToolStripButton tbAdd;
		private System.Windows.Forms.ToolStripButton tbDelete;
		private FBA.DataGridViewFBA dgvMethod;
		private System.Windows.Forms.ToolStripButton tbEdit;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tbRefresh = new System.Windows.Forms.ToolStripButton();
			this.tbAdd = new System.Windows.Forms.ToolStripButton();
			this.tbEdit = new System.Windows.Forms.ToolStripButton();
			this.tbDelete = new System.Windows.Forms.ToolStripButton();
			this.dgvMethod = new FBA.DataGridViewFBA();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMethod)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Arial", 11.25F);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbRefresh,
			this.tbAdd,
			this.tbEdit,
			this.tbDelete});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(507, 25);
			this.toolStrip1.TabIndex = 20;
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
			this.tbRefresh.Click += new System.EventHandler(this.TbRefreshClick);
			// 
			// tbAdd
			// 
			this.tbAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbAdd.Image = global::FBA.Resource.Add_16;
			this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbAdd.Name = "tbAdd";
			this.tbAdd.Size = new System.Drawing.Size(53, 22);
			this.tbAdd.Text = "Add";
			this.tbAdd.Click += new System.EventHandler(this.TbRefreshClick);
			// 
			// tbEdit
			// 
			this.tbEdit.Image = global::FBA.Resource.Edit_16;
			this.tbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbEdit.Name = "tbEdit";
			this.tbEdit.Size = new System.Drawing.Size(53, 22);
			this.tbEdit.Text = "Edit";
			this.tbEdit.Click += new System.EventHandler(this.TbRefreshClick);
			// 
			// tbDelete
			// 
			this.tbDelete.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDelete.Image = global::FBA.Resource.Del_16;
			this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDelete.Name = "tbDelete";
			this.tbDelete.Size = new System.Drawing.Size(70, 22);
			this.tbDelete.Text = "Delete";
			this.tbDelete.Click += new System.EventHandler(this.TbRefreshClick);
			// 
			// dgvMethod
			// 
			this.dgvMethod.AllowUserToAddRows = false;
			this.dgvMethod.AllowUserToDeleteRows = false;
			this.dgvMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMethod.CommandAdd = false;
			this.dgvMethod.CommandDel = false;
			this.dgvMethod.CommandEdit = false;
			this.dgvMethod.CommandExportToExcel = false;
			this.dgvMethod.CommandFilter = false;
			this.dgvMethod.CommandRefresh = false;
			this.dgvMethod.CommandSaveASCSV = false;
			this.dgvMethod.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMethod.EnableHeadersVisualStyles = false;
			this.dgvMethod.GroupEnabled = null;
			this.dgvMethod.Location = new System.Drawing.Point(0, 25);
			this.dgvMethod.Name = "dgvMethod";
			this.dgvMethod.Obj = null;
			this.dgvMethod.PassedSec = null;
			this.dgvMethod.ReadOnly = true;
			this.dgvMethod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvMethod.Size = new System.Drawing.Size(507, 289);
			this.dgvMethod.TabIndex = 21;
			// 
			// FormMethod
			// 
			//this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(507, 314);
			this.Controls.Add(this.dgvMethod);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormMethod";
			this.Text = "FormMethod";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMethod)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
