
/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 08.09.2017
 * Время: 18:05
*/
 
namespace FBA
{
    partial class FormMain
    {        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N1_1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N1_2;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3_1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3_2;
          
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        	this.MainMenu_N1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N1_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N1_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_5 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_6 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N3_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N3_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N3_3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.menuStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// menuStrip1
        	// 
        	resources.ApplyResources(this.menuStrip1, "menuStrip1");
        	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N1,
			this.MainMenu_N2,
			this.MainMenu_N3,
			this.toolStripMenuItem1,
			this.toolStripMenuItem2});
        	this.menuStrip1.Name = "menuStrip1";
        	// 
        	// MainMenu_N1
        	// 
        	this.MainMenu_N1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N1_1,
			this.MainMenu_N1_2});
        	this.MainMenu_N1.Name = "MainMenu_N1";
        	resources.ApplyResources(this.MainMenu_N1, "MainMenu_N1");
        	// 
        	// MainMenu_N1_1
        	// 
        	this.MainMenu_N1_1.Name = "MainMenu_N1_1";
        	resources.ApplyResources(this.MainMenu_N1_1, "MainMenu_N1_1");
        	this.MainMenu_N1_1.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N1_2
        	// 
        	this.MainMenu_N1_2.Name = "MainMenu_N1_2";
        	resources.ApplyResources(this.MainMenu_N1_2, "MainMenu_N1_2");
        	this.MainMenu_N1_2.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N2
        	// 
        	this.MainMenu_N2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N2_3,
			this.MainMenu_N2_1,
			this.MainMenu_N2_2,
			this.MainMenu_N2_4,
			this.MainMenu_N2_5,
			this.MainMenu_N2_6});
        	this.MainMenu_N2.Name = "MainMenu_N2";
        	resources.ApplyResources(this.MainMenu_N2, "MainMenu_N2");
        	// 
        	// MainMenu_N2_3
        	// 
        	this.MainMenu_N2_3.Name = "MainMenu_N2_3";
        	resources.ApplyResources(this.MainMenu_N2_3, "MainMenu_N2_3");
        	this.MainMenu_N2_3.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N2_1
        	// 
        	this.MainMenu_N2_1.Name = "MainMenu_N2_1";
        	resources.ApplyResources(this.MainMenu_N2_1, "MainMenu_N2_1");
        	this.MainMenu_N2_1.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N2_2
        	// 
        	this.MainMenu_N2_2.Name = "MainMenu_N2_2";
        	resources.ApplyResources(this.MainMenu_N2_2, "MainMenu_N2_2");
        	this.MainMenu_N2_2.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N2_4
        	// 
        	this.MainMenu_N2_4.Name = "MainMenu_N2_4";
        	resources.ApplyResources(this.MainMenu_N2_4, "MainMenu_N2_4");
        	this.MainMenu_N2_4.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N2_5
        	// 
        	this.MainMenu_N2_5.Name = "MainMenu_N2_5";
        	resources.ApplyResources(this.MainMenu_N2_5, "MainMenu_N2_5");
        	this.MainMenu_N2_5.Click += new System.EventHandler(this.MainMenu_N2_5_Click);
        	// 
        	// MainMenu_N2_6
        	// 
        	this.MainMenu_N2_6.Name = "MainMenu_N2_6";
        	resources.ApplyResources(this.MainMenu_N2_6, "MainMenu_N2_6");
        	this.MainMenu_N2_6.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N3
        	// 
        	this.MainMenu_N3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N3_1,
			this.MainMenu_N3_2,
			this.MainMenu_N3_3});
        	this.MainMenu_N3.Name = "MainMenu_N3";
        	resources.ApplyResources(this.MainMenu_N3, "MainMenu_N3");
        	// 
        	// MainMenu_N3_1
        	// 
        	this.MainMenu_N3_1.Name = "MainMenu_N3_1";
        	resources.ApplyResources(this.MainMenu_N3_1, "MainMenu_N3_1");
        	this.MainMenu_N3_1.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N3_2
        	// 
        	this.MainMenu_N3_2.Name = "MainMenu_N3_2";
        	resources.ApplyResources(this.MainMenu_N3_2, "MainMenu_N3_2");
        	this.MainMenu_N3_2.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// MainMenu_N3_3
        	// 
        	this.MainMenu_N3_3.Name = "MainMenu_N3_3";
        	resources.ApplyResources(this.MainMenu_N3_3, "MainMenu_N3_3");
        	this.MainMenu_N3_3.Click += new System.EventHandler(this.MainMenu_N1_1_Click);
        	// 
        	// toolStripMenuItem1
        	// 
        	this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        	resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
        	this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1Click);
        	// 
        	// toolStripMenuItem2
        	// 
        	this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        	resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
        	// 
        	// FormMain
        	// 
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        	this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        	resources.ApplyResources(this, "$this");
        	this.Controls.Add(this.menuStrip1);
        	this.IsMdiContainer = true;
        	this.MainMenuStrip = this.menuStrip1;
        	this.Name = "FormMain";
        	this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
        	this.Tag = "FormMainDMS";
        	this.Load += new System.EventHandler(this.FormMainDMS_Load);
        	this.Shown += new System.EventHandler(this.FormMainDMS_Shown);
        	this.menuStrip1.ResumeLayout(false);
        	this.menuStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_2;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_3;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_4;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_5;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3_3;
    }
}
