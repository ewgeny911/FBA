
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 04.10.2017
 * Время: 11:53
 * 
 
 */
namespace FBA
{
    partial class FormViewTable
    {
                
        private System.ComponentModel.IContainer components = null;
        private FBA.DataGridViewFBA dgv1;
        private System.Windows.Forms.Panel panel2;
        private FBA.LabelFBA lbCapText;
        
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
            this.dgv1 = new FBA.DataGridViewFBA();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbCapText = new FBA.LabelFBA();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.CommandAdd = false;
            this.dgv1.CommandDel = false;
            this.dgv1.CommandEdit = false;
            this.dgv1.CommandExportToExcel = false;
            this.dgv1.CommandFilter = false;
            this.dgv1.CommandRefresh = false;
            this.dgv1.CommandSaveASCSV = false;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.GroupEnabled = null;
            this.dgv1.Location = new System.Drawing.Point(0, 25);
            this.dgv1.Margin = new System.Windows.Forms.Padding(4);
            this.dgv1.Name = "dgv1";
            this.dgv1.Obj = null;
            this.dgv1.PassedSec = null;
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(436, 267);
            this.dgv1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbCapText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 25);
            this.panel2.TabIndex = 7;
            // 
            // lbCapText
            // 
            this.lbCapText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCapText.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCapText.Location = new System.Drawing.Point(5, 2);
            this.lbCapText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCapText.Name = "lbCapText";
            this.lbCapText.Size = new System.Drawing.Size(419, 14);
            this.lbCapText.StarColor = System.Drawing.Color.Crimson;
            this.lbCapText.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbCapText.StarOffsetX = 2;
            this.lbCapText.StarOffsetY = 0;
            this.lbCapText.StarShow = false;
            this.lbCapText.StarText = "*";
            this.lbCapText.TabIndex = 0;
            this.lbCapText.Text = "Comment";
            // 
            // FormViewTable
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 292);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormViewTable";
            this.Text = "View table";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
