
﻿namespace FBA
{
    partial class FormReg
    {        
        private System.ComponentModel.IContainer components = null;
                
        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>		
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReg));
        	this.richTextBox1 = new System.Windows.Forms.RichTextBox();
        	this.label1 = new FBA.LabelFBA();
        	this.label2 = new FBA.LabelFBA();
        	this.richTextBox2 = new System.Windows.Forms.RichTextBox();
        	this.richTextBox3 = new System.Windows.Forms.RichTextBox();
        	this.label3 = new FBA.LabelFBA();
        	this.label4 = new FBA.LabelFBA();
        	this.richTextBox4 = new System.Windows.Forms.RichTextBox();
        	this.SuspendLayout();
        	// 
        	// richTextBox1
        	// 
        	this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.richTextBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.richTextBox1.Location = new System.Drawing.Point(0, 19);
        	this.richTextBox1.Name = "richTextBox1";
        	this.richTextBox1.Size = new System.Drawing.Size(456, 37);
        	this.richTextBox1.TabIndex = 4;
        	this.richTextBox1.Text = "";
        	this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
        	// 
        	// label1
        	// 
        	this.label1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.ForeColor = System.Drawing.Color.Black;
        	this.label1.Location = new System.Drawing.Point(0, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(456, 19);
        	this.label1.StarColor = System.Drawing.Color.Crimson;
        	this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label1.StarOffsetX = 2;
        	this.label1.StarOffsetY = 0;
        	this.label1.StarShow = false;
        	this.label1.StarText = "*";
        	this.label1.TabIndex = 5;
        	this.label1.Text = "Regular expression";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.ForeColor = System.Drawing.Color.Black;
        	this.label2.Location = new System.Drawing.Point(0, 56);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(82, 17);
        	this.label2.StarColor = System.Drawing.Color.Crimson;
        	this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label2.StarOffsetX = 2;
        	this.label2.StarOffsetY = 0;
        	this.label2.StarShow = false;
        	this.label2.StarText = "*";
        	this.label2.TabIndex = 6;
        	this.label2.Text = "Text string :";
        	// 
        	// richTextBox2
        	// 
        	this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.richTextBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.richTextBox2.Location = new System.Drawing.Point(0, 73);
        	this.richTextBox2.Name = "richTextBox2";
        	this.richTextBox2.Size = new System.Drawing.Size(456, 44);
        	this.richTextBox2.TabIndex = 0;
        	this.richTextBox2.Text = "";
        	this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
        	// 
        	// richTextBox3
        	// 
        	this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Top;
        	this.richTextBox3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.richTextBox3.Location = new System.Drawing.Point(0, 134);
        	this.richTextBox3.Name = "richTextBox3";
        	this.richTextBox3.ReadOnly = true;
        	this.richTextBox3.Size = new System.Drawing.Size(456, 47);
        	this.richTextBox3.TabIndex = 0;
        	this.richTextBox3.Text = "";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Dock = System.Windows.Forms.DockStyle.Top;
        	this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.ForeColor = System.Drawing.Color.Black;
        	this.label3.Location = new System.Drawing.Point(0, 117);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(133, 17);
        	this.label3.StarColor = System.Drawing.Color.Crimson;
        	this.label3.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label3.StarOffsetX = 2;
        	this.label3.StarOffsetY = 0;
        	this.label3.StarShow = false;
        	this.label3.StarText = "*";
        	this.label3.TabIndex = 9;
        	this.label3.Text = "Result (first match)";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Dock = System.Windows.Forms.DockStyle.Top;
        	this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label4.ForeColor = System.Drawing.Color.Black;
        	this.label4.Location = new System.Drawing.Point(0, 181);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(147, 17);
        	this.label4.StarColor = System.Drawing.Color.Crimson;
        	this.label4.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label4.StarOffsetX = 2;
        	this.label4.StarOffsetY = 0;
        	this.label4.StarShow = false;
        	this.label4.StarText = "*";
        	this.label4.TabIndex = 10;
        	this.label4.Text = "Results (all matches)";
        	// 
        	// richTextBox4
        	// 
        	this.richTextBox4.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.richTextBox4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.richTextBox4.Location = new System.Drawing.Point(0, 198);
        	this.richTextBox4.Name = "richTextBox4";
        	this.richTextBox4.ReadOnly = true;
        	this.richTextBox4.Size = new System.Drawing.Size(456, 56);
        	this.richTextBox4.TabIndex = 0;
        	this.richTextBox4.Text = "";
        	// 
        	// FormReg
        	// 
        	this.ClientSize = new System.Drawing.Size(456, 254);
        	this.Controls.Add(this.richTextBox4);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.richTextBox3);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.richTextBox2);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.richTextBox1);
        	this.Controls.Add(this.label1);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "FormReg";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Test regular expressions";
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        #endregion
        private FBA.LabelFBA label1;
        private FBA.LabelFBA label2;
        private FBA.LabelFBA label3;
        private FBA.LabelFBA label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
    }
}
