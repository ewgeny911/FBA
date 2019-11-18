
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 07.10.2017
 * Время: 21:06
 * 
 
 */
namespace FBA
{
    partial class FormFilterAttr
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private FBA.LabelFBA label3;
        private FBA.LabelFBA label2;
        private FBA.LabelFBA label4;
        private System.Windows.Forms.CheckBox cbUniversalWordWrap;
        private FBA.LabelFBA label5;
        private FBA.LabelFBA labelFBA1;
        
        /// <summary>
        /// Ширина колонки в гриде при показе значений атрибута
        /// </summary>
        public System.Windows.Forms.NumericUpDown udWidth;
              
        /// <summary>
        /// Имя атрибута
        /// </summary>
        public System.Windows.Forms.TextBox tbName;
          
        /// <summary>
        /// Маска атрибута
        /// </summary>
        public FBA.ComboBoxFBA cbMask;
        
    
        /// <summary>
        /// Текст вычисляемого запроса
        /// </summary>
        public FastColoredTextBoxNS.FastColoredTextBox tbBrief;
        
        /// <summary>
        /// Признак сортировки по атрибуту
        /// </summary>
        public FBA.ComboBoxFBA cbSort;
       
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbMask = new FBA.ComboBoxFBA();
            this.label4 = new FBA.LabelFBA();
            this.udWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new FBA.LabelFBA();
            this.label2 = new FBA.LabelFBA();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbUniversalWordWrap = new System.Windows.Forms.CheckBox();
            this.label5 = new FBA.LabelFBA();
            this.tbBrief = new FastColoredTextBoxNS.FastColoredTextBox();
            this.cbSort = new FBA.ComboBoxFBA();
            this.labelFBA1 = new FBA.LabelFBA();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrief)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 317);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 40);
            this.panel1.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::FBA.Resource.Cancel_24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(251, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "   Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Image = global::FBA.Resource.OK_24;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(368, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 33);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "  Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // cbMask
            // 
            this.cbMask.BackColor = System.Drawing.SystemColors.Info;
            this.cbMask.FormattingEnabled = true;
            this.cbMask.Items.AddRange(new object[] {
            "Default",
            "Date",
            "Money",
            "String"});
            this.cbMask.Location = new System.Drawing.Point(76, 39);
            this.cbMask.Margin = new System.Windows.Forms.Padding(4);
            this.cbMask.Name = "cbMask";
            this.cbMask.Size = new System.Drawing.Size(160, 25);
            this.cbMask.TabIndex = 8;
            this.cbMask.Text = "Default";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 22);
            this.label4.StarColor = System.Drawing.Color.Crimson;
            this.label4.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label4.StarOffsetX = 2;
            this.label4.StarOffsetY = 0;
            this.label4.StarShow = true;
            this.label4.StarText = "*";
            this.label4.TabIndex = 7;
            this.label4.Text = "Mask:";
            // 
            // udWidth
            // 
            this.udWidth.BackColor = System.Drawing.SystemColors.Info;
            this.udWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.udWidth.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udWidth.ForeColor = System.Drawing.SystemColors.WindowText;
            this.udWidth.Location = new System.Drawing.Point(75, 105);
            this.udWidth.Margin = new System.Windows.Forms.Padding(4);
            this.udWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udWidth.Name = "udWidth";
            this.udWidth.Size = new System.Drawing.Size(89, 25);
            this.udWidth.TabIndex = 6;
            this.udWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.StarColor = System.Drawing.Color.Crimson;
            this.label3.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label3.StarOffsetX = 2;
            this.label3.StarOffsetY = 0;
            this.label3.StarShow = true;
            this.label3.StarText = "*";
            this.label3.TabIndex = 4;
            this.label3.Text = "Width:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.StarColor = System.Drawing.Color.Crimson;
            this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label2.StarOffsetX = 2;
            this.label2.StarOffsetY = 0;
            this.label2.StarShow = true;
            this.label2.StarText = "*";
            this.label2.TabIndex = 2;
            this.label2.Text = "Attr:";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.BackColor = System.Drawing.SystemColors.Info;
            this.tbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(76, 9);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(399, 25);
            this.tbName.TabIndex = 1;
            // 
            // cbUniversalWordWrap
            // 
            this.cbUniversalWordWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUniversalWordWrap.Location = new System.Drawing.Point(380, 294);
            this.cbUniversalWordWrap.Margin = new System.Windows.Forms.Padding(4);
            this.cbUniversalWordWrap.Name = "cbUniversalWordWrap";
            this.cbUniversalWordWrap.Size = new System.Drawing.Size(100, 21);
            this.cbUniversalWordWrap.TabIndex = 11;
            this.cbUniversalWordWrap.Tag = "SAVE";
            this.cbUniversalWordWrap.Text = "WordWrap";
            this.cbUniversalWordWrap.UseVisualStyleBackColor = true;
            this.cbUniversalWordWrap.CheckedChanged += new System.EventHandler(this.cbUniversalWordWrap_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 24);
            this.label5.StarColor = System.Drawing.Color.Crimson;
            this.label5.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label5.StarOffsetX = 2;
            this.label5.StarOffsetY = 0;
            this.label5.StarShow = true;
            this.label5.StarText = "*";
            this.label5.TabIndex = 0;
            this.label5.Text = "Name:";
            // 
            // tbBrief
            // 
            this.tbBrief.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBrief.AutoCompleteBracketsList = new char[] {
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
            this.tbBrief.AutoIndentCharsPatterns = "";
            this.tbBrief.AutoScrollMinSize = new System.Drawing.Size(2, 21);
            this.tbBrief.BackBrush = null;
            this.tbBrief.BackColor = System.Drawing.SystemColors.Info;
            this.tbBrief.BookmarkColor = System.Drawing.Color.Red;
            this.tbBrief.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBrief.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.tbBrief.CharHeight = 21;
            this.tbBrief.CharWidth = 11;
            this.tbBrief.CommentPrefix = "--";
            this.tbBrief.CurrentLineColor = System.Drawing.Color.DarkGray;
            this.tbBrief.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbBrief.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbBrief.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
            this.tbBrief.Font = new System.Drawing.Font("Courier New", 14.25F);
            this.tbBrief.IsReplaceMode = false;
            this.tbBrief.Language = FastColoredTextBoxNS.Language.SQL;
            this.tbBrief.LeftBracket = '(';
            this.tbBrief.Location = new System.Drawing.Point(76, 138);
            this.tbBrief.Margin = new System.Windows.Forms.Padding(4);
            this.tbBrief.Name = "tbBrief";
            this.tbBrief.Paddings = new System.Windows.Forms.Padding(0);
            this.tbBrief.RightBracket = ')';
            this.tbBrief.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tbBrief.ShowLineNumbers = false;
            this.tbBrief.Size = new System.Drawing.Size(397, 153);
            this.tbBrief.TabIndex = 20;
            this.tbBrief.Tag = "";
            this.tbBrief.VirtualSpace = true;
            this.tbBrief.Zoom = 100;
            // 
            // cbSort
            // 
            this.cbSort.AttrBrief = null;
            this.cbSort.AttrBriefLookup = null;    
            this.cbSort.BackColor = System.Drawing.SystemColors.Info;
            this.cbSort.ContextMenuEnabled = true;
            this.cbSort.ErrorIfNull = null;          
            this.cbSort.FormattingEnabled = true;
            this.cbSort.GroupEnabled = null;         
            this.cbSort.Items.AddRange(new object[] {
            "No",
            "Up",
            "Down"});
            this.cbSort.Location = new System.Drawing.Point(76, 72);
            this.cbSort.Margin = new System.Windows.Forms.Padding(4);
            this.cbSort.Name = "cbSort";
            this.cbSort.ObjectRef = null;
            this.cbSort.ReadOnly = true;
            this.cbSort.SaveParam = false;
            this.cbSort.SaveValueHistory = false;
            this.cbSort.Size = new System.Drawing.Size(160, 25);
            this.cbSort.TabIndex = 22;
            this.cbSort.Text = "No";
            this.cbSort.Text2 = null;
            this.cbSort.ValueHistoryInItems = false;
            // 
            // labelFBA1
            // 
            this.labelFBA1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFBA1.Location = new System.Drawing.Point(6, 75);
            this.labelFBA1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFBA1.Name = "labelFBA1";
            this.labelFBA1.Size = new System.Drawing.Size(56, 22);
            this.labelFBA1.StarColor = System.Drawing.Color.Crimson;
            this.labelFBA1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.labelFBA1.StarOffsetX = 2;
            this.labelFBA1.StarOffsetY = 0;
            this.labelFBA1.StarShow = true;
            this.labelFBA1.StarText = "*";
            this.labelFBA1.TabIndex = 21;
            this.labelFBA1.Text = "Sort:";
            // 
            // FormFilterAttr
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 357);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.labelFBA1);
            this.Controls.Add(this.tbBrief);
            this.Controls.Add(this.cbUniversalWordWrap);
            this.Controls.Add(this.udWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormFilterAttr";
            this.Text = "Attribute property";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrief)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
