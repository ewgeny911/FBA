
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.01.2018
 * Время: 13:47
 */
 
namespace FBA
{
    partial class FormGetEntity
    {        
        private System.ComponentModel.IContainer components = null;
        private CompEntityTreeFBA CompEntityTreeFBA1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        
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
            this.CompEntityTreeFBA1 = new FBA.CompEntityTreeFBA();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompEntityTreeFBA1
            // 
            this.CompEntityTreeFBA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompEntityTreeFBA1.Editable = true;
            this.CompEntityTreeFBA1.EntityID = null;
            this.CompEntityTreeFBA1.EntityName = null;
            this.CompEntityTreeFBA1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompEntityTreeFBA1.Location = new System.Drawing.Point(0, 0);
            this.CompEntityTreeFBA1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CompEntityTreeFBA1.Name = "CompEntityTreeFBA1";
            this.CompEntityTreeFBA1.SelectInOneClick = false;
            this.CompEntityTreeFBA1.Size = new System.Drawing.Size(364, 367);
            this.CompEntityTreeFBA1.TabIndex = 1;
            this.CompEntityTreeFBA1.SelectedEntity += new FBA.EntityEventHandler(this.EntityTree_SelectedEntity);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 367);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 41);
            this.panel2.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Image = global::FBA.Resource.Cancel_24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(128, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "   Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Image = global::FBA.Resource.OK_24;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(248, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 33);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "  Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // FormGetEntity
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 408);
            this.Controls.Add(this.CompEntityTreeFBA1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormGetEntity";
            this.Text = "Entity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGetEntity_FormClosing);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
