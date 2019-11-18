/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 28.04.2017
 * Время: 18:10
 * 
 
 */
namespace FBA
{
    partial class FormUpdate
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
        	this.components = new System.ComponentModel.Container();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.label1 = new System.Windows.Forms.Label();
        	this.progressBar1 = new System.Windows.Forms.ProgressBar();
        	this.timer1 = new System.Windows.Forms.Timer(this.components);
        	this.textBoxUpdate = new System.Windows.Forms.TextBox();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.label1);
        	this.panel1.Controls.Add(this.progressBar1);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(587, 63);
        	this.panel1.TabIndex = 1;
        	// 
        	// label1
        	// 
        	this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.label1.Location = new System.Drawing.Point(4, 3);
        	this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(576, 22);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Current file:";
        	// 
        	// progressBar1
        	// 
        	this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.progressBar1.Location = new System.Drawing.Point(4, 29);
        	this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
        	this.progressBar1.Name = "progressBar1";
        	this.progressBar1.Size = new System.Drawing.Size(576, 26);
        	this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this.progressBar1.TabIndex = 0;
        	this.progressBar1.Value = 58;
        	// 
        	// timer1
        	// 
        	this.timer1.Interval = 300;
        	this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
        	// 
        	// textBoxUpdate
        	// 
        	this.textBoxUpdate.BackColor = System.Drawing.SystemColors.Window;
        	this.textBoxUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBoxUpdate.Location = new System.Drawing.Point(0, 63);
        	this.textBoxUpdate.Multiline = true;
        	this.textBoxUpdate.Name = "textBoxUpdate";
        	this.textBoxUpdate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBoxUpdate.Size = new System.Drawing.Size(587, 227);
        	this.textBoxUpdate.TabIndex = 3;
        	this.textBoxUpdate.WordWrap = false;
        	// 
        	// FormUpdate
        	// 
        	this.ClientSize = new System.Drawing.Size(587, 290);
        	this.Controls.Add(this.textBoxUpdate);
        	this.Controls.Add(this.panel1);
        	this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormUpdate";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Updater";
        	this.panel1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxUpdate;
    }
}
