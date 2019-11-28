
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.11.2017
 * Время: 16:29
 */
 
namespace FBA
{
    partial class FormMain
    {        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N1_1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N1_2;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N4;
          
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MainMenu_N1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_N1_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_N1_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_N3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_N4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_N1,
            this.MainMenu_N3,
            this.MainMenu_N4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.MainMenu_N1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_N1_1,
            this.MainMenu_N1_2});
            this.MainMenu_N1.Name = "fileToolStripMenuItem";
            this.MainMenu_N1.Size = new System.Drawing.Size(37, 20);
            this.MainMenu_N1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.MainMenu_N1_1.Name = "openToolStripMenuItem";
            this.MainMenu_N1_1.Size = new System.Drawing.Size(103, 22);
            this.MainMenu_N1_1.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.MainMenu_N1_2.Name = "saveToolStripMenuItem";
            this.MainMenu_N1_2.Size = new System.Drawing.Size(103, 22);
            this.MainMenu_N1_2.Text = "Save";
            // 
            // helpToolStripMenuItem
            // 
            this.MainMenu_N3.Name = "helpToolStripMenuItem";
            this.MainMenu_N3.Size = new System.Drawing.Size(44, 20);
            this.MainMenu_N3.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.MainMenu_N4.Name = "aboutToolStripMenuItem";
            this.MainMenu_N4.Size = new System.Drawing.Size(52, 20);
            this.MainMenu_N4.Text = "About";
            this.MainMenu_N4.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // MainForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 246);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
