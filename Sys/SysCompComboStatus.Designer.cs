
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 02.01.2018
 * Время: 20:07
 */
namespace FBA
{
    partial class SysComboStatus
    {        
        private System.ComponentModel.IContainer components = null;
        private FBA.ComboBoxFBA cbStatus;
        private System.Windows.Forms.Button btnHistory;
        private FBA.LabelFBA lbStatus;
        
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
        	this.cbStatus = new FBA.ComboBoxFBA();
        	this.btnHistory = new System.Windows.Forms.Button();
        	this.lbStatus = new FBA.LabelFBA();
        	this.SuspendLayout();
        	// 
        	// cbStatus
        	// 
        	this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.cbStatus.BackColor = System.Drawing.SystemColors.Info;
        	this.cbStatus.FormattingEnabled = true;
        	this.cbStatus.Location = new System.Drawing.Point(59, 0);
        	this.cbStatus.Margin = new System.Windows.Forms.Padding(4);
        	this.cbStatus.Name = "cbStatus";
        	this.cbStatus.Size = new System.Drawing.Size(183, 25);
        	this.cbStatus.TabIndex = 1;
        	// 
        	// btnHistory
        	// 
        	this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnHistory.Image = global::FBA.Resource.ExportExcel_16;
        	this.btnHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnHistory.Location = new System.Drawing.Point(245, 0);
        	this.btnHistory.Name = "btnHistory";
        	this.btnHistory.Size = new System.Drawing.Size(85, 26);
        	this.btnHistory.TabIndex = 2;
        	this.btnHistory.Text = "History";
        	this.btnHistory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.btnHistory.UseVisualStyleBackColor = true;
        	this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
        	// 
        	// lbStatus
        	// 
        	this.lbStatus.Location = new System.Drawing.Point(0, 4);
        	this.lbStatus.Name = "lbStatus";
        	this.lbStatus.Size = new System.Drawing.Size(55, 18);
        	this.lbStatus.StarColor = System.Drawing.Color.Crimson;
        	this.lbStatus.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbStatus.StarOffsetX = 2;
        	this.lbStatus.StarOffsetY = 0;
        	this.lbStatus.StarShow = false;
        	this.lbStatus.StarText = "*";
        	this.lbStatus.TabIndex = 3;
        	this.lbStatus.Text = "Status:";
        	// 
        	// SysComboStatus
        	// 
        	this.Controls.Add(this.lbStatus);
        	this.Controls.Add(this.btnHistory);
        	this.Controls.Add(this.cbStatus);
        	this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "SysComboStatus";
        	this.Size = new System.Drawing.Size(330, 25);
        	this.ResumeLayout(false);

        }
    }
}
