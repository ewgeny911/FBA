
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 15.02.2017
 * Время: 18:11  
 */
 
namespace FBA
{
	partial class FormAbout
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textAbout;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnOk;
		private FBA.LabelFBA label1;
		private FBA.LabelFBA label2;
		private FBA.PictureBoxFBA pictureBox1;
				
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
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.textAbout = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new FBA.LabelFBA();
            this.label2 = new FBA.LabelFBA();
            this.pictureBox1 = new FBA.PictureBoxFBA();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textAbout
            // 
            this.textAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAbout.BackColor = System.Drawing.SystemColors.Window;
            this.textAbout.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textAbout.Location = new System.Drawing.Point(10, 62);
            this.textAbout.Multiline = true;
            this.textAbout.Name = "textAbout";
            this.textAbout.ReadOnly = true;
            this.textAbout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textAbout.Size = new System.Drawing.Size(476, 270);
            this.textAbout.TabIndex = 0;
            this.textAbout.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 338);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 41);
            this.panel1.TabIndex = 11;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Image = global::FBA.Resource.OK_24;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(374, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 33);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(71, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 22);
            this.label1.StarColor = System.Drawing.Color.Crimson;
            this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label1.StarOffsetX = 2;
            this.label1.StarOffsetY = 0;
            this.label1.StarShow = false;
            this.label1.StarText = "*";
            this.label1.TabIndex = 12;
            this.label1.Text = "The system of execution of client business applications";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(71, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 30);
            this.label2.StarColor = System.Drawing.Color.Crimson;
            this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label2.StarOffsetX = 2;
            this.label2.StarOffsetY = 0;
            this.label2.StarShow = false;
            this.label2.StarText = "*";
            this.label2.TabIndex = 13;
            this.label2.Text = "Business application forms";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FBA.Resource.ruby_48;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormAbout
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 379);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textAbout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About FBA";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
