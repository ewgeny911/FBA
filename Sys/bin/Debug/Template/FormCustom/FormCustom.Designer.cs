
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.11.2017
 * Время: 17:49
 */
 
namespace FBA
{
    partial class FormCustom
    {          
        private System.ComponentModel.IContainer components = null;
                 
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
            this.SuspendLayout();
            // 
            // FormCustom
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 205);
            this.FormMDIParent = "MainFormDMS";
            this.Name = "FormCustom";
            this.Text = "FormCustom";
            this.Shown += new System.EventHandler(this.FormCustom_Shown);
            this.ResumeLayout(false);
        }
    }
}
