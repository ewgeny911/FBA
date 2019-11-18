
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 26.12.2016
 * Время: 14:11
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace FBA
{
    partial class FormSM
    {       
        ///Designer variable used to keep track of non-visual components.   
        private System.ComponentModel.IContainer components = null;
                      
        /// <summary>
        /// Disposes resources used by the form.
        /// true if managed resources should be disposed; otherwise, false.
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
        
         
        ///This method is required for Windows Forms designer support.
        ///Do not change the method contents inside the source code editor. The Forms designer might
        ///not be able to load this method if it was changed manually.        
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.cbWordWrap = new System.Windows.Forms.CheckBox();
        	this.button2 = new System.Windows.Forms.Button();
        	this.button1 = new System.Windows.Forms.Button();
        	this.pictureBox1 = new FBA.PictureBoxFBA();
        	this.TextBoxCode = new FastColoredTextBoxNS.FastColoredTextBox();
        	this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmMenu_N1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.btnNext = new System.Windows.Forms.Button();
        	this.btnPrev = new System.Windows.Forms.Button();
        	this.panel3 = new System.Windows.Forms.Panel();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.TextBoxMes = new System.Windows.Forms.TextBox();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.TextBoxCode)).BeginInit();
        	this.cmMenu.SuspendLayout();
        	this.panel2.SuspendLayout();
        	this.panel3.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	this.tabControl1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
        	this.panel1.Controls.Add(this.cbWordWrap);
        	this.panel1.Controls.Add(this.button2);
        	this.panel1.Controls.Add(this.button1);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Location = new System.Drawing.Point(0, 301);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(712, 41);
        	this.panel1.TabIndex = 0;
        	// 
        	// cbWordWrap
        	// 
        	this.cbWordWrap.Checked = true;
        	this.cbWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.cbWordWrap.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbWordWrap.Location = new System.Drawing.Point(12, 9);
        	this.cbWordWrap.Margin = new System.Windows.Forms.Padding(4);
        	this.cbWordWrap.Name = "cbWordWrap";
        	this.cbWordWrap.Size = new System.Drawing.Size(101, 20);
        	this.cbWordWrap.TabIndex = 4;
        	this.cbWordWrap.Text = "Word wrap";
        	this.cbWordWrap.UseVisualStyleBackColor = true;
        	this.cbWordWrap.CheckedChanged += new System.EventHandler(this.CbWordWrapCheckedChanged);
        	// 
        	// button2
        	// 
        	this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.button2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.button2.Image = global::FBA.Resource.Cancel_24;
        	this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.button2.Location = new System.Drawing.Point(476, 4);
        	this.button2.Margin = new System.Windows.Forms.Padding(4);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(112, 33);
        	this.button2.TabIndex = 1;
        	this.button2.Text = "   Cancel";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Visible = false;
        	this.button2.Click += new System.EventHandler(this.Button2Click);
        	// 
        	// button1
        	// 
        	this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.button1.Image = global::FBA.Resource.OK_24;
        	this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.button1.Location = new System.Drawing.Point(593, 4);
        	this.button1.Margin = new System.Windows.Forms.Padding(4);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(112, 33);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "  Ok";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
        	this.pictureBox1.Location = new System.Drawing.Point(3, 3);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(32, 32);
        	this.pictureBox1.TabIndex = 6;
        	this.pictureBox1.TabStop = false;
        	// 
        	// TextBoxCode
        	// 
        	this.TextBoxCode.AutoCompleteBracketsList = new char[] {
		'(',
		')',
		'{',
		'}',
		'[',
		']',
		'\"',
		'\"',
		'\'',
		'\''};
        	this.TextBoxCode.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
	"*(?<range>:)\\s*(?<range>[^;]+);\r\n";
        	this.TextBoxCode.AutoScrollMinSize = new System.Drawing.Size(31, 18);
        	this.TextBoxCode.BackBrush = null;
        	this.TextBoxCode.BackColor = System.Drawing.Color.AntiqueWhite;
        	this.TextBoxCode.BookmarkColor = System.Drawing.Color.Red;
        	this.TextBoxCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.TextBoxCode.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
        	this.TextBoxCode.CharHeight = 18;
        	this.TextBoxCode.CharWidth = 10;
        	this.TextBoxCode.ContextMenuStrip = this.cmMenu;
        	this.TextBoxCode.CurrentLineColor = System.Drawing.Color.MediumAquamarine;
        	this.TextBoxCode.Cursor = System.Windows.Forms.Cursors.IBeam;
        	this.TextBoxCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
        	this.TextBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.TextBoxCode.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
        	this.TextBoxCode.Font = new System.Drawing.Font("Courier New", 12F);
        	this.TextBoxCode.IsReplaceMode = false;
        	this.TextBoxCode.Language = FastColoredTextBoxNS.Language.CSharp;
        	this.TextBoxCode.LeftBracket = '(';
        	this.TextBoxCode.LeftBracket2 = '{';
        	this.TextBoxCode.Location = new System.Drawing.Point(4, 4);
        	this.TextBoxCode.Margin = new System.Windows.Forms.Padding(4);
        	this.TextBoxCode.Name = "TextBoxCode";
        	this.TextBoxCode.Paddings = new System.Windows.Forms.Padding(0);
        	this.TextBoxCode.RightBracket = ')';
        	this.TextBoxCode.RightBracket2 = '}';
        	this.TextBoxCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
        	this.TextBoxCode.Size = new System.Drawing.Size(657, 116);
        	this.TextBoxCode.TabIndex = 16;
        	this.TextBoxCode.VirtualSpace = true;
        	this.TextBoxCode.Zoom = 100;
        	// 
        	// cmMenu
        	// 
        	this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmMenu_N1});
        	this.cmMenu.Name = "cmMenu";
        	this.cmMenu.Size = new System.Drawing.Size(110, 26);
        	// 
        	// cmMenu_N1
        	// 
        	this.cmMenu_N1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cmMenu_N1.Name = "cmMenu_N1";
        	this.cmMenu_N1.Size = new System.Drawing.Size(109, 22);
        	this.cmMenu_N1.Text = "Copy";
        	this.cmMenu_N1.Click += new System.EventHandler(this.cmMenu_N1_Click);
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.btnNext);
        	this.panel2.Controls.Add(this.pictureBox1);
        	this.panel2.Controls.Add(this.btnPrev);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
        	this.panel2.Location = new System.Drawing.Point(0, 0);
        	this.panel2.Margin = new System.Windows.Forms.Padding(4);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(39, 301);
        	this.panel2.TabIndex = 17;
        	// 
        	// btnNext
        	// 
        	this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.btnNext.Image = global::FBA.Resource.Down_16;
        	this.btnNext.Location = new System.Drawing.Point(6, 268);
        	this.btnNext.Name = "btnNext";
        	this.btnNext.Size = new System.Drawing.Size(28, 28);
        	this.btnNext.TabIndex = 6;
        	this.btnNext.UseVisualStyleBackColor = true;
        	// 
        	// btnPrev
        	// 
        	this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.btnPrev.Image = global::FBA.Resource.Up_16;
        	this.btnPrev.Location = new System.Drawing.Point(6, 235);
        	this.btnPrev.Name = "btnPrev";
        	this.btnPrev.Size = new System.Drawing.Size(28, 28);
        	this.btnPrev.TabIndex = 5;
        	this.btnPrev.UseVisualStyleBackColor = true;
        	// 
        	// panel3
        	// 
        	this.panel3.Controls.Add(this.splitContainer1);
        	this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel3.Location = new System.Drawing.Point(39, 0);
        	this.panel3.Margin = new System.Windows.Forms.Padding(4);
        	this.panel3.Name = "panel3";
        	this.panel3.Size = new System.Drawing.Size(673, 301);
        	this.panel3.TabIndex = 18;
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
        	this.splitContainer1.Name = "splitContainer1";
        	this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.TextBoxMes);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
        	this.splitContainer1.Size = new System.Drawing.Size(673, 301);
        	this.splitContainer1.SplitterDistance = 142;
        	this.splitContainer1.SplitterWidth = 5;
        	this.splitContainer1.TabIndex = 18;
        	// 
        	// TextBoxMes
        	// 
        	this.TextBoxMes.BackColor = System.Drawing.SystemColors.Info;
        	this.TextBoxMes.ContextMenuStrip = this.cmMenu;
        	this.TextBoxMes.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.TextBoxMes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.TextBoxMes.Location = new System.Drawing.Point(0, 0);
        	this.TextBoxMes.Margin = new System.Windows.Forms.Padding(4);
        	this.TextBoxMes.Multiline = true;
        	this.TextBoxMes.Name = "TextBoxMes";
        	this.TextBoxMes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.TextBoxMes.Size = new System.Drawing.Size(673, 142);
        	this.TextBoxMes.TabIndex = 0;
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabControl1.Location = new System.Drawing.Point(0, 0);
        	this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(673, 154);
        	this.tabControl1.TabIndex = 17;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.TextBoxCode);
        	this.tabPage1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabPage1.Location = new System.Drawing.Point(4, 26);
        	this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
        	this.tabPage1.Size = new System.Drawing.Size(665, 124);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Tag = "";
        	this.tabPage1.Text = "tabPage1";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// FormSM
        	// 
        	this.BackColor = System.Drawing.SystemColors.Window;
        	this.ClientSize = new System.Drawing.Size(712, 342);
        	this.Controls.Add(this.panel3);
        	this.Controls.Add(this.panel2);
        	this.Controls.Add(this.panel1);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormSM";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        	this.Text = "Warning!";
        	this.TopMost = true;
        	this.Load += new System.EventHandler(this.FormSMLoad);
        	this.panel1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.TextBoxCode)).EndInit();
        	this.cmMenu.ResumeLayout(false);
        	this.panel2.ResumeLayout(false);
        	this.panel3.ResumeLayout(false);
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel1.PerformLayout();
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        	this.splitContainer1.ResumeLayout(false);
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private FastColoredTextBoxNS.FastColoredTextBox TextBoxCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cbWordWrap;
        private System.Windows.Forms.TextBox TextBoxMes;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem cmMenu_N1;
        private FBA.PictureBoxFBA pictureBox1;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}
