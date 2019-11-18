
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 14.10.2017
 * Время: 11:39
 * 
 
 */
namespace FBA
{
    partial class FormRight
    {
        
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbID;
        private FBA.LabelFBA lbID;
        private System.Windows.Forms.TextBox tbBrief;
        private System.Windows.Forms.TextBox tbName;
        private FBA.LabelFBA lbName;
        private FBA.LabelFBA lbBrief;
          
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
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.tbID = new System.Windows.Forms.TextBox();
        	this.lbID = new FBA.LabelFBA();
        	this.tbBrief = new System.Windows.Forms.TextBox();
        	this.tbName = new System.Windows.Forms.TextBox();
        	this.lbName = new FBA.LabelFBA();
        	this.lbBrief = new FBA.LabelFBA();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnOk);
        	this.panel1.Controls.Add(this.btnCancel);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Location = new System.Drawing.Point(0, 118);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(482, 41);
        	this.panel1.TabIndex = 11;
        	// 
        	// btnOk
        	// 
        	this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(355, 4);
        	this.btnOk.Margin = new System.Windows.Forms.Padding(4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 5;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(235, 4);
        	this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(112, 33);
        	this.btnCancel.TabIndex = 4;
        	this.btnCancel.Text = "   Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
        	// 
        	// tbID
        	// 
        	this.tbID.BackColor = System.Drawing.SystemColors.InactiveBorder;
        	this.tbID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbID.Location = new System.Drawing.Point(101, 12);
        	this.tbID.Margin = new System.Windows.Forms.Padding(4);
        	this.tbID.Name = "tbID";
        	this.tbID.ReadOnly = true;
        	this.tbID.Size = new System.Drawing.Size(123, 25);
        	this.tbID.TabIndex = 30;
        	// 
        	// lbID
        	// 
        	this.lbID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbID.Location = new System.Drawing.Point(8, 12);
        	this.lbID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbID.Name = "lbID";
        	this.lbID.Size = new System.Drawing.Size(60, 30);
        	this.lbID.StarColor = System.Drawing.Color.Crimson;
        	this.lbID.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbID.StarOffsetX = 2;
        	this.lbID.StarOffsetY = 0;
        	this.lbID.StarShow = false;
        	this.lbID.StarText = "*";
        	this.lbID.TabIndex = 31;
        	this.lbID.Text = "ID:";
        	// 
        	// tbBrief
        	// 
        	this.tbBrief.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbBrief.BackColor = System.Drawing.SystemColors.Info;
        	this.tbBrief.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbBrief.Location = new System.Drawing.Point(102, 78);
        	this.tbBrief.Margin = new System.Windows.Forms.Padding(4);
        	this.tbBrief.Name = "tbBrief";
        	this.tbBrief.Size = new System.Drawing.Size(365, 25);
        	this.tbBrief.TabIndex = 29;
        	// 
        	// tbName
        	// 
        	this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbName.Location = new System.Drawing.Point(101, 45);
        	this.tbName.Margin = new System.Windows.Forms.Padding(4);
        	this.tbName.Name = "tbName";
        	this.tbName.Size = new System.Drawing.Size(366, 25);
        	this.tbName.TabIndex = 28;
        	// 
        	// lbName
        	// 
        	this.lbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbName.Location = new System.Drawing.Point(8, 41);
        	this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbName.Name = "lbName";
        	this.lbName.Size = new System.Drawing.Size(80, 30);
        	this.lbName.StarColor = System.Drawing.Color.Crimson;
        	this.lbName.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbName.StarOffsetX = 2;
        	this.lbName.StarOffsetY = 0;
        	this.lbName.StarShow = true;
        	this.lbName.StarText = "*";
        	this.lbName.TabIndex = 27;
        	this.lbName.Text = "Name:";
        	// 
        	// lbBrief
        	// 
        	this.lbBrief.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbBrief.Location = new System.Drawing.Point(8, 73);
        	this.lbBrief.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbBrief.Name = "lbBrief";
        	this.lbBrief.Size = new System.Drawing.Size(80, 30);
        	this.lbBrief.StarColor = System.Drawing.Color.Crimson;
        	this.lbBrief.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbBrief.StarOffsetX = 2;
        	this.lbBrief.StarOffsetY = 0;
        	this.lbBrief.StarShow = true;
        	this.lbBrief.StarText = "*";
        	this.lbBrief.TabIndex = 26;
        	this.lbBrief.Text = "Brief:";
        	// 
        	// FormRight
        	// 
        	this.ClientSize = new System.Drawing.Size(482, 159);
        	this.Controls.Add(this.tbID);
        	this.Controls.Add(this.lbID);
        	this.Controls.Add(this.tbBrief);
        	this.Controls.Add(this.tbName);
        	this.Controls.Add(this.lbName);
        	this.Controls.Add(this.lbBrief);
        	this.Controls.Add(this.panel1);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormRight";
        	this.Text = "Right";
        	this.panel1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
    }
}
