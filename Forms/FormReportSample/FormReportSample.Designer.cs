
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.11.2017
 * Время: 17:49
 */
 
namespace FBA
{
    partial class FormReportSample
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
        	this.buttonFBA1 = new FBA.ButtonFBA();
        	this.buttonFBA2 = new FBA.ButtonFBA();
        	this.button1 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// buttonFBA1
        	// 
        	this.buttonFBA1.AttrBrief = null;
        	this.buttonFBA1.GroupEnabled = null;
        	this.buttonFBA1.Location = new System.Drawing.Point(12, 49);
        	this.buttonFBA1.Name = "buttonFBA1";
        	this.buttonFBA1.Obj = null;
        	this.buttonFBA1.ObjectRef = null;
        	this.buttonFBA1.SaveParam = false;
        	this.buttonFBA1.Size = new System.Drawing.Size(121, 52);
        	this.buttonFBA1.TabIndex = 3;
        	this.buttonFBA1.Text = "Print";
        	this.buttonFBA1.UseVisualStyleBackColor = true;
        	this.buttonFBA1.Click += new System.EventHandler(this.buttonFBA1_Click);
        	// 
        	// buttonFBA2
        	// 
        	this.buttonFBA2.AttrBrief = null;
        	this.buttonFBA2.GroupEnabled = null;
        	this.buttonFBA2.Location = new System.Drawing.Point(139, 49);
        	this.buttonFBA2.Name = "buttonFBA2";
        	this.buttonFBA2.Obj = null;
        	this.buttonFBA2.ObjectRef = null;
        	this.buttonFBA2.SaveParam = false;
        	this.buttonFBA2.Size = new System.Drawing.Size(111, 52);
        	this.buttonFBA2.TabIndex = 4;
        	this.buttonFBA2.Text = "Cancel";
        	this.buttonFBA2.UseVisualStyleBackColor = true;
        	this.buttonFBA2.Click += new System.EventHandler(this.buttonFBA2_Click);
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(256, 49);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(121, 52);
        	this.button1.TabIndex = 5;
        	this.button1.Text = "TO PDF";
        	this.button1.UseVisualStyleBackColor = true;
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(40, 13);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(75, 23);
        	this.button2.TabIndex = 6;
        	this.button2.Text = "button2";
        	this.button2.UseVisualStyleBackColor = true;
        	// 
        	// FormReportSample
        	// 
        	this.ClientSize = new System.Drawing.Size(389, 140);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.buttonFBA2);
        	this.Controls.Add(this.buttonFBA1);
        	this.FormMDIParent = "MainForm";
        	this.FormSavePosition = true;
        	this.Name = "FormReportSample";
        	this.Text = "Report";
        	this.ResumeLayout(false);

        }
        private ButtonFBA buttonFBA1;
        private ButtonFBA buttonFBA2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
