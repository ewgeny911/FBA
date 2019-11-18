
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 28.09.2017
 * Время: 17:52
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace FBA
{
	partial class FormDDL
	{			
		private System.ComponentModel.IContainer components = null;		     
		
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
			this.components = new System.ComponentModel.Container();
			this.toolStripDDL = new System.Windows.Forms.ToolStrip();
			this.tbDDL1 = new System.Windows.Forms.ToolStripButton();
			this.tbDDL2 = new System.Windows.Forms.ToolStripButton();
			this.tbDDL3 = new System.Windows.Forms.ToolStripButton();
			this.tbDDL4 = new System.Windows.Forms.ToolStripButton();
			this.tbDDL5 = new System.Windows.Forms.ToolStripButton();
			this.tbDDL6 = new System.Windows.Forms.ToolStripButton();
			this.tbDDL7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.cmMenuN_1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cmMenuN_2 = new System.Windows.Forms.ToolStripMenuItem();
			this.cmMenuN_3 = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.tbTextMSSQL = new FastColoredTextBoxNS.FastColoredTextBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.tbTextPostgre = new FastColoredTextBoxNS.FastColoredTextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tbTextSQLite = new FastColoredTextBoxNS.FastColoredTextBox();
			this.tabControlDDL = new System.Windows.Forms.TabControl();
			this.toolStripDDL.SuspendLayout();
			this.tabPage7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbTextMSSQL)).BeginInit();
			this.tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbTextPostgre)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbTextSQLite)).BeginInit();
			this.tabControlDDL.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripDDL
			// 
			this.toolStripDDL.AutoSize = false;
			this.toolStripDDL.Font = new System.Drawing.Font("Arial", 11.25F);
			this.toolStripDDL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbDDL1,
			this.tbDDL2,
			this.tbDDL3,
			this.tbDDL4,
			this.tbDDL5,
			this.tbDDL6,
			this.tbDDL7,
			this.toolStripDropDownButton1});
			this.toolStripDDL.Location = new System.Drawing.Point(0, 0);
			this.toolStripDDL.Name = "toolStripDDL";
			this.toolStripDDL.Size = new System.Drawing.Size(1028, 34);
			this.toolStripDDL.TabIndex = 9;
			this.toolStripDDL.Text = "toolStrip2";
			// 
			// tbDDL1
			// 
			this.tbDDL1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDDL1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDDL1.Name = "tbDDL1";
			this.tbDDL1.Size = new System.Drawing.Size(62, 31);
			this.tbDDL1.Text = "Load all";
			this.tbDDL1.Click += new System.EventHandler(this.TbDDL1Click);
			// 
			// tbDDL2
			// 
			this.tbDDL2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDDL2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDDL2.Name = "tbDDL2";
			this.tbDDL2.Size = new System.Drawing.Size(63, 31);
			this.tbDDL2.Text = "Save all";
			this.tbDDL2.Click += new System.EventHandler(this.TbDDL1Click);
			// 
			// tbDDL3
			// 
			this.tbDDL3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDDL3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDDL3.Name = "tbDDL3";
			this.tbDDL3.Size = new System.Drawing.Size(63, 31);
			this.tbDDL3.Text = "Convert";
			this.tbDDL3.Click += new System.EventHandler(this.TbDDL1Click);
			// 
			// tbDDL4
			// 
			this.tbDDL4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDDL4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDDL4.Name = "tbDDL4";
			this.tbDDL4.Size = new System.Drawing.Size(108, 31);
			this.tbDDL4.Text = "New Database";
			this.tbDDL4.Click += new System.EventHandler(this.TbDDL1Click);
			// 
			// tbDDL5
			// 
			this.tbDDL5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDDL5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDDL5.Name = "tbDDL5";
			this.tbDDL5.Size = new System.Drawing.Size(94, 31);
			this.tbDDL5.Text = "Exec SQLite";
			this.tbDDL5.Click += new System.EventHandler(this.TbDDL1Click);
			// 
			// tbDDL6
			// 
			this.tbDDL6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDDL6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDDL6.Name = "tbDDL6";
			this.tbDDL6.Size = new System.Drawing.Size(108, 31);
			this.tbDDL6.Text = "Exec Postgre";
			this.tbDDL6.Click += new System.EventHandler(this.TbDDL1Click);
			// 
			// tbDDL7
			// 
			this.tbDDL7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDDL7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDDL7.Name = "tbDDL7";
			this.tbDDL7.Size = new System.Drawing.Size(100, 31);
			this.tbDDL7.Text = "Exec MSSQL";
			this.tbDDL7.Click += new System.EventHandler(this.TbDDL1Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmMenuN_1,
			this.cmMenuN_2,
			this.cmMenuN_3});
			this.toolStripDropDownButton1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(98, 31);
			this.toolStripDropDownButton1.Text = "Copy tables";
			// 
			// cmMenuN_1
			// 
			this.cmMenuN_1.Name = "cmMenuN_1";
			this.cmMenuN_1.Size = new System.Drawing.Size(329, 22);
			this.cmMenuN_1.Text = "Create parser tables";
			this.cmMenuN_1.Click += new System.EventHandler(this.cmMenuN_1_Click);
			// 
			// cmMenuN_2
			// 
			this.cmMenuN_2.Name = "cmMenuN_2";
			this.cmMenuN_2.Size = new System.Drawing.Size(329, 22);
			this.cmMenuN_2.Text = "Copy parser tables to remote database";
			this.cmMenuN_2.Click += new System.EventHandler(this.cmMenuN_2_Click);
			// 
			// cmMenuN_3
			// 
			this.cmMenuN_3.Name = "cmMenuN_3";
			this.cmMenuN_3.Size = new System.Drawing.Size(329, 22);
			this.cmMenuN_3.Text = "Copy all tables to remote database";
			this.cmMenuN_3.Click += new System.EventHandler(this.cmMenuN_3_Click);
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.tbTextMSSQL);
			this.tabPage7.Location = new System.Drawing.Point(4, 26);
			this.tabPage7.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage7.Size = new System.Drawing.Size(1020, 344);
			this.tabPage7.TabIndex = 2;
			this.tabPage7.Text = "MSSQL";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// tbTextMSSQL
			// 
			this.tbTextMSSQL.AutoCompleteBracketsList = new char[] {
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
			this.tbTextMSSQL.AutoIndentCharsPatterns = "";
			this.tbTextMSSQL.AutoScrollMinSize = new System.Drawing.Size(2, 21);
			this.tbTextMSSQL.BackBrush = null;
			this.tbTextMSSQL.BookmarkColor = System.Drawing.Color.Red;
			this.tbTextMSSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbTextMSSQL.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.tbTextMSSQL.CharHeight = 21;
			this.tbTextMSSQL.CharWidth = 11;
			this.tbTextMSSQL.CommentPrefix = "--";
			this.tbTextMSSQL.CurrentLineColor = System.Drawing.Color.DarkGray;
			this.tbTextMSSQL.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tbTextMSSQL.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.tbTextMSSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbTextMSSQL.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.tbTextMSSQL.Font = new System.Drawing.Font("Courier New", 14.25F);
			this.tbTextMSSQL.IsReplaceMode = false;
			this.tbTextMSSQL.Language = FastColoredTextBoxNS.Language.SQL;
			this.tbTextMSSQL.LeftBracket = '(';
			this.tbTextMSSQL.Location = new System.Drawing.Point(4, 4);
			this.tbTextMSSQL.Margin = new System.Windows.Forms.Padding(4);
			this.tbTextMSSQL.Name = "tbTextMSSQL";
			this.tbTextMSSQL.Paddings = new System.Windows.Forms.Padding(0);
			this.tbTextMSSQL.RightBracket = ')';
			this.tbTextMSSQL.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.tbTextMSSQL.Size = new System.Drawing.Size(1012, 336);
			this.tbTextMSSQL.TabIndex = 18;
			this.tbTextMSSQL.VirtualSpace = true;
			this.tbTextMSSQL.Zoom = 100;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.tbTextPostgre);
			this.tabPage6.Location = new System.Drawing.Point(4, 26);
			this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage6.Size = new System.Drawing.Size(1020, 344);
			this.tabPage6.TabIndex = 1;
			this.tabPage6.Text = "Postgre";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// tbTextPostgre
			// 
			this.tbTextPostgre.AutoCompleteBracketsList = new char[] {
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
			this.tbTextPostgre.AutoIndentCharsPatterns = "";
			this.tbTextPostgre.AutoScrollMinSize = new System.Drawing.Size(2, 21);
			this.tbTextPostgre.BackBrush = null;
			this.tbTextPostgre.BookmarkColor = System.Drawing.Color.Red;
			this.tbTextPostgre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbTextPostgre.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.tbTextPostgre.CharHeight = 21;
			this.tbTextPostgre.CharWidth = 11;
			this.tbTextPostgre.CommentPrefix = "--";
			this.tbTextPostgre.CurrentLineColor = System.Drawing.Color.DarkGray;
			this.tbTextPostgre.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tbTextPostgre.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.tbTextPostgre.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbTextPostgre.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.tbTextPostgre.Font = new System.Drawing.Font("Courier New", 14.25F);
			this.tbTextPostgre.IsReplaceMode = false;
			this.tbTextPostgre.Language = FastColoredTextBoxNS.Language.SQL;
			this.tbTextPostgre.LeftBracket = '(';
			this.tbTextPostgre.Location = new System.Drawing.Point(4, 4);
			this.tbTextPostgre.Margin = new System.Windows.Forms.Padding(4);
			this.tbTextPostgre.Name = "tbTextPostgre";
			this.tbTextPostgre.Paddings = new System.Windows.Forms.Padding(0);
			this.tbTextPostgre.RightBracket = ')';
			this.tbTextPostgre.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.tbTextPostgre.Size = new System.Drawing.Size(1012, 336);
			this.tbTextPostgre.TabIndex = 17;
			this.tbTextPostgre.VirtualSpace = true;
			this.tbTextPostgre.Zoom = 100;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.tbTextSQLite);
			this.tabPage4.Location = new System.Drawing.Point(4, 26);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage4.Size = new System.Drawing.Size(1020, 344);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "SQLite";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tbTextSQLite
			// 
			this.tbTextSQLite.AutoCompleteBracketsList = new char[] {
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
			this.tbTextSQLite.AutoIndentCharsPatterns = "";
			this.tbTextSQLite.AutoScrollMinSize = new System.Drawing.Size(33, 21);
			this.tbTextSQLite.BackBrush = null;
			this.tbTextSQLite.BookmarkColor = System.Drawing.Color.Red;
			this.tbTextSQLite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbTextSQLite.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.tbTextSQLite.CharHeight = 21;
			this.tbTextSQLite.CharWidth = 11;
			this.tbTextSQLite.CommentPrefix = "--";
			this.tbTextSQLite.CurrentLineColor = System.Drawing.Color.DarkGray;
			this.tbTextSQLite.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tbTextSQLite.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.tbTextSQLite.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbTextSQLite.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
			this.tbTextSQLite.Font = new System.Drawing.Font("Courier New", 14.25F);
			this.tbTextSQLite.IsReplaceMode = false;
			this.tbTextSQLite.Language = FastColoredTextBoxNS.Language.SQL;
			this.tbTextSQLite.LeftBracket = '(';
			this.tbTextSQLite.Location = new System.Drawing.Point(4, 4);
			this.tbTextSQLite.Margin = new System.Windows.Forms.Padding(4);
			this.tbTextSQLite.Name = "tbTextSQLite";
			this.tbTextSQLite.Paddings = new System.Windows.Forms.Padding(0);
			this.tbTextSQLite.RightBracket = ')';
			this.tbTextSQLite.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.tbTextSQLite.Size = new System.Drawing.Size(1012, 336);
			this.tbTextSQLite.TabIndex = 16;
			this.tbTextSQLite.VirtualSpace = true;
			this.tbTextSQLite.Zoom = 100;
			// 
			// tabControlDDL
			// 
			this.tabControlDDL.Controls.Add(this.tabPage4);
			this.tabControlDDL.Controls.Add(this.tabPage6);
			this.tabControlDDL.Controls.Add(this.tabPage7);
			this.tabControlDDL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlDDL.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabControlDDL.Location = new System.Drawing.Point(0, 34);
			this.tabControlDDL.Margin = new System.Windows.Forms.Padding(4);
			this.tabControlDDL.Name = "tabControlDDL";
			this.tabControlDDL.SelectedIndex = 0;
			this.tabControlDDL.Size = new System.Drawing.Size(1028, 374);
			this.tabControlDDL.TabIndex = 13;
			// 
			// FormDDL
			// 
			//this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1028, 408);
			this.Controls.Add(this.tabControlDDL);
			this.Controls.Add(this.toolStripDDL);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormDDL";
			this.Text = "DDL";
			this.toolStripDDL.ResumeLayout(false);
			this.toolStripDDL.PerformLayout();
			this.tabPage7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbTextMSSQL)).EndInit();
			this.tabPage6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbTextPostgre)).EndInit();
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbTextSQLite)).EndInit();
			this.tabControlDDL.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		
		/// <summary>
		/// tbTextMSSQL
		/// </summary>
		public FastColoredTextBoxNS.FastColoredTextBox tbTextMSSQL;
		private System.Windows.Forms.TabPage tabPage7;
		
		/// <summary>
		/// tbTextPostgre
		/// </summary>
		public FastColoredTextBoxNS.FastColoredTextBox tbTextPostgre;
		private System.Windows.Forms.TabPage tabPage6;
		
		/// <summary>
		/// tbTextSQLite
		/// </summary>
		public FastColoredTextBoxNS.FastColoredTextBox tbTextSQLite;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabControl tabControlDDL;
		private System.Windows.Forms.ToolStripButton tbDDL7;
		private System.Windows.Forms.ToolStripButton tbDDL6;
		private System.Windows.Forms.ToolStripButton tbDDL5;
		private System.Windows.Forms.ToolStripButton tbDDL4;
		private System.Windows.Forms.ToolStripButton tbDDL3;
		private System.Windows.Forms.ToolStripButton tbDDL2;
		private System.Windows.Forms.ToolStripButton tbDDL1;
		private System.Windows.Forms.ToolStrip toolStripDDL;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem cmMenuN_1;
		private System.Windows.Forms.ToolStripMenuItem cmMenuN_2;
		private System.Windows.Forms.ToolStripMenuItem cmMenuN_3;
	}
}
