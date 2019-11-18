
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 07.10.2017
 * Время: 21:41
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace FBA
{
    partial class FormParamValue
    {  
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel2;               
        private FBA.LabelFBA lbCap1;
        private System.Windows.Forms.TextBox tbComment;
        private FBA.LabelFBA label3;
        private System.Windows.Forms.TextBox tbName;
           
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
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.tbComment = new System.Windows.Forms.TextBox();
        	this.tbName = new System.Windows.Forms.TextBox();
        	this.label3 = new FBA.LabelFBA();
        	this.lbCap1 = new FBA.LabelFBA();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.tabControlFBA1 = new FBA.TabControlFBA();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.tabPage3 = new System.Windows.Forms.TabPage();
        	this.textBox3 = new System.Windows.Forms.TextBox();
        	this.tabPage4 = new System.Windows.Forms.TabPage();
        	this.textBox4 = new System.Windows.Forms.TextBox();
        	this.tabPage5 = new System.Windows.Forms.TabPage();
        	this.textBox5 = new System.Windows.Forms.TextBox();
        	this.tabPage6 = new System.Windows.Forms.TabPage();
        	this.textBox6 = new System.Windows.Forms.TextBox();
        	this.tabPage7 = new System.Windows.Forms.TabPage();
        	this.textBox7 = new System.Windows.Forms.TextBox();
        	this.tabPage8 = new System.Windows.Forms.TabPage();
        	this.textBox8 = new System.Windows.Forms.TextBox();
        	this.tabPage9 = new System.Windows.Forms.TabPage();
        	this.textBox9 = new System.Windows.Forms.TextBox();
        	this.tabPage10 = new System.Windows.Forms.TabPage();
        	this.textBox10 = new System.Windows.Forms.TextBox();
        	this.panel1.SuspendLayout();
        	this.panel2.SuspendLayout();
        	this.tabControlFBA1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	this.tabPage3.SuspendLayout();
        	this.tabPage4.SuspendLayout();
        	this.tabPage5.SuspendLayout();
        	this.tabPage6.SuspendLayout();
        	this.tabPage7.SuspendLayout();
        	this.tabPage8.SuspendLayout();
        	this.tabPage9.SuspendLayout();
        	this.tabPage10.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnCancel);
        	this.panel1.Controls.Add(this.btnOk);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.panel1.Location = new System.Drawing.Point(0, 338);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(672, 47);
        	this.panel1.TabIndex = 7;
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(427, 8);
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
        	this.btnOk.Location = new System.Drawing.Point(547, 8);
        	this.btnOk.Margin = new System.Windows.Forms.Padding(4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 0;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	// 
        	// tbComment
        	// 
        	this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbComment.BackColor = System.Drawing.SystemColors.Info;
        	this.tbComment.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbComment.Location = new System.Drawing.Point(9, 61);
        	this.tbComment.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.tbComment.Multiline = true;
        	this.tbComment.Name = "tbComment";
        	this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.tbComment.Size = new System.Drawing.Size(655, 88);
        	this.tbComment.TabIndex = 11;
        	this.tbComment.Tag = "Main1.Комментарий";
        	this.tbComment.WordWrap = false;
        	// 
        	// tbName
        	// 
        	this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbName.Location = new System.Drawing.Point(99, 4);
        	this.tbName.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.tbName.Name = "tbName";
        	this.tbName.Size = new System.Drawing.Size(565, 25);
        	this.tbName.TabIndex = 7;
        	this.tbName.Tag = "Main1.Имя";
        	// 
        	// label3
        	// 
        	this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.Location = new System.Drawing.Point(6, 39);
        	this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(88, 18);
        	this.label3.StarColor = System.Drawing.Color.Crimson;
        	this.label3.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label3.StarOffsetX = 2;
        	this.label3.StarOffsetY = 0;
        	this.label3.StarShow = false;
        	this.label3.StarText = "*";
        	this.label3.TabIndex = 13;
        	this.label3.Text = "Comment:";
        	// 
        	// lbCap1
        	// 
        	this.lbCap1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbCap1.Location = new System.Drawing.Point(4, 4);
        	this.lbCap1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbCap1.Name = "lbCap1";
        	this.lbCap1.Size = new System.Drawing.Size(66, 27);
        	this.lbCap1.StarColor = System.Drawing.Color.Crimson;
        	this.lbCap1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbCap1.StarOffsetX = 2;
        	this.lbCap1.StarOffsetY = 0;
        	this.lbCap1.StarShow = true;
        	this.lbCap1.StarText = "*";
        	this.lbCap1.TabIndex = 0;
        	this.lbCap1.Text = "Name:";
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.tabControlFBA1);
        	this.panel2.Controls.Add(this.lbCap1);
        	this.panel2.Controls.Add(this.label3);
        	this.panel2.Controls.Add(this.tbComment);
        	this.panel2.Controls.Add(this.tbName);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel2.Location = new System.Drawing.Point(0, 0);
        	this.panel2.Margin = new System.Windows.Forms.Padding(4);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(672, 338);
        	this.panel2.TabIndex = 9;
        	// 
        	// tabControlFBA1
        	// 
        	this.tabControlFBA1.AttrBrief = null;
        	this.tabControlFBA1.Controls.Add(this.tabPage1);
        	this.tabControlFBA1.Controls.Add(this.tabPage2);
        	this.tabControlFBA1.Controls.Add(this.tabPage3);
        	this.tabControlFBA1.Controls.Add(this.tabPage4);
        	this.tabControlFBA1.Controls.Add(this.tabPage5);
        	this.tabControlFBA1.Controls.Add(this.tabPage6);
        	this.tabControlFBA1.Controls.Add(this.tabPage7);
        	this.tabControlFBA1.Controls.Add(this.tabPage8);
        	this.tabControlFBA1.Controls.Add(this.tabPage9);
        	this.tabControlFBA1.Controls.Add(this.tabPage10);
        	this.tabControlFBA1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
        	this.tabControlFBA1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabControlFBA1.GroupEnabled = null;
        	this.tabControlFBA1.HideTabs = false;
        	this.tabControlFBA1.Location = new System.Drawing.Point(14, 155);
        	this.tabControlFBA1.Name = "tabControlFBA1";
        	this.tabControlFBA1.Obj = null;
        	this.tabControlFBA1.SaveParam = false;
        	this.tabControlFBA1.SelectedIndex = 0;
        	this.tabControlFBA1.SelectTabBackColor = System.Drawing.Color.Aqua;
        	this.tabControlFBA1.SelectTabFontColor = System.Drawing.Color.Black;
        	this.tabControlFBA1.SetSelectTabBackColor = false;
        	this.tabControlFBA1.Size = new System.Drawing.Size(650, 174);
        	this.tabControlFBA1.StarColor = System.Drawing.Color.Crimson;
        	this.tabControlFBA1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.tabControlFBA1.StarOffsetX = 2;
        	this.tabControlFBA1.StarOffsetY = 0;
        	this.tabControlFBA1.StarPageIndex = 0;
        	this.tabControlFBA1.StarShow = true;
        	this.tabControlFBA1.StarText = "*";
        	this.tabControlFBA1.TabFontColor = System.Drawing.Color.Black;
        	this.tabControlFBA1.TabIndex = 14;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.textBox1);
        	this.tabPage1.Location = new System.Drawing.Point(4, 22);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(642, 148);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Value1    ";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// textBox1
        	// 
        	this.textBox1.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox1.Location = new System.Drawing.Point(3, 3);
        	this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox1.Multiline = true;
        	this.textBox1.Name = "textBox1";
        	this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox1.Size = new System.Drawing.Size(636, 142);
        	this.textBox1.TabIndex = 8;
        	this.textBox1.Tag = "Main1.Значение";
        	this.textBox1.WordWrap = false;
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.textBox2);
        	this.tabPage2.Location = new System.Drawing.Point(4, 22);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(642, 148);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "Value2";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// textBox2
        	// 
        	this.textBox2.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox2.Location = new System.Drawing.Point(3, 3);
        	this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox2.Multiline = true;
        	this.textBox2.Name = "textBox2";
        	this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox2.Size = new System.Drawing.Size(636, 142);
        	this.textBox2.TabIndex = 9;
        	this.textBox2.Tag = "Main1.Значение";
        	this.textBox2.WordWrap = false;
        	// 
        	// tabPage3
        	// 
        	this.tabPage3.Controls.Add(this.textBox3);
        	this.tabPage3.Location = new System.Drawing.Point(4, 22);
        	this.tabPage3.Name = "tabPage3";
        	this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage3.Size = new System.Drawing.Size(642, 148);
        	this.tabPage3.TabIndex = 2;
        	this.tabPage3.Text = "Value3";
        	this.tabPage3.UseVisualStyleBackColor = true;
        	// 
        	// textBox3
        	// 
        	this.textBox3.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox3.Location = new System.Drawing.Point(3, 3);
        	this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox3.Multiline = true;
        	this.textBox3.Name = "textBox3";
        	this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox3.Size = new System.Drawing.Size(636, 142);
        	this.textBox3.TabIndex = 9;
        	this.textBox3.Tag = "Main1.Значение";
        	this.textBox3.WordWrap = false;
        	// 
        	// tabPage4
        	// 
        	this.tabPage4.Controls.Add(this.textBox4);
        	this.tabPage4.Location = new System.Drawing.Point(4, 22);
        	this.tabPage4.Name = "tabPage4";
        	this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage4.Size = new System.Drawing.Size(642, 148);
        	this.tabPage4.TabIndex = 3;
        	this.tabPage4.Text = "Value4";
        	this.tabPage4.UseVisualStyleBackColor = true;
        	// 
        	// textBox4
        	// 
        	this.textBox4.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox4.Location = new System.Drawing.Point(3, 3);
        	this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox4.Multiline = true;
        	this.textBox4.Name = "textBox4";
        	this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox4.Size = new System.Drawing.Size(636, 142);
        	this.textBox4.TabIndex = 9;
        	this.textBox4.Tag = "Main1.Значение";
        	this.textBox4.WordWrap = false;
        	// 
        	// tabPage5
        	// 
        	this.tabPage5.Controls.Add(this.textBox5);
        	this.tabPage5.Location = new System.Drawing.Point(4, 22);
        	this.tabPage5.Name = "tabPage5";
        	this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage5.Size = new System.Drawing.Size(642, 148);
        	this.tabPage5.TabIndex = 4;
        	this.tabPage5.Text = "Value5";
        	this.tabPage5.UseVisualStyleBackColor = true;
        	// 
        	// textBox5
        	// 
        	this.textBox5.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox5.Location = new System.Drawing.Point(3, 3);
        	this.textBox5.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox5.Multiline = true;
        	this.textBox5.Name = "textBox5";
        	this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox5.Size = new System.Drawing.Size(636, 142);
        	this.textBox5.TabIndex = 9;
        	this.textBox5.Tag = "Main1.Значение";
        	this.textBox5.WordWrap = false;
        	// 
        	// tabPage6
        	// 
        	this.tabPage6.Controls.Add(this.textBox6);
        	this.tabPage6.Location = new System.Drawing.Point(4, 22);
        	this.tabPage6.Name = "tabPage6";
        	this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage6.Size = new System.Drawing.Size(642, 148);
        	this.tabPage6.TabIndex = 5;
        	this.tabPage6.Text = "Value6";
        	this.tabPage6.UseVisualStyleBackColor = true;
        	// 
        	// textBox6
        	// 
        	this.textBox6.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox6.Location = new System.Drawing.Point(3, 3);
        	this.textBox6.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox6.Multiline = true;
        	this.textBox6.Name = "textBox6";
        	this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox6.Size = new System.Drawing.Size(636, 142);
        	this.textBox6.TabIndex = 9;
        	this.textBox6.Tag = "Main1.Значение";
        	this.textBox6.WordWrap = false;
        	// 
        	// tabPage7
        	// 
        	this.tabPage7.Controls.Add(this.textBox7);
        	this.tabPage7.Location = new System.Drawing.Point(4, 22);
        	this.tabPage7.Name = "tabPage7";
        	this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage7.Size = new System.Drawing.Size(642, 148);
        	this.tabPage7.TabIndex = 6;
        	this.tabPage7.Text = "Value7";
        	this.tabPage7.UseVisualStyleBackColor = true;
        	// 
        	// textBox7
        	// 
        	this.textBox7.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox7.Location = new System.Drawing.Point(3, 3);
        	this.textBox7.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox7.Multiline = true;
        	this.textBox7.Name = "textBox7";
        	this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox7.Size = new System.Drawing.Size(636, 142);
        	this.textBox7.TabIndex = 9;
        	this.textBox7.Tag = "Main1.Значение";
        	this.textBox7.WordWrap = false;
        	// 
        	// tabPage8
        	// 
        	this.tabPage8.Controls.Add(this.textBox8);
        	this.tabPage8.Location = new System.Drawing.Point(4, 22);
        	this.tabPage8.Name = "tabPage8";
        	this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage8.Size = new System.Drawing.Size(642, 148);
        	this.tabPage8.TabIndex = 7;
        	this.tabPage8.Text = "Value8";
        	this.tabPage8.UseVisualStyleBackColor = true;
        	// 
        	// textBox8
        	// 
        	this.textBox8.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox8.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox8.Location = new System.Drawing.Point(3, 3);
        	this.textBox8.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox8.Multiline = true;
        	this.textBox8.Name = "textBox8";
        	this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox8.Size = new System.Drawing.Size(636, 142);
        	this.textBox8.TabIndex = 9;
        	this.textBox8.Tag = "Main1.Значение";
        	this.textBox8.WordWrap = false;
        	// 
        	// tabPage9
        	// 
        	this.tabPage9.Controls.Add(this.textBox9);
        	this.tabPage9.Location = new System.Drawing.Point(4, 22);
        	this.tabPage9.Name = "tabPage9";
        	this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage9.Size = new System.Drawing.Size(642, 148);
        	this.tabPage9.TabIndex = 8;
        	this.tabPage9.Text = "Value9";
        	this.tabPage9.UseVisualStyleBackColor = true;
        	// 
        	// textBox9
        	// 
        	this.textBox9.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox9.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox9.Location = new System.Drawing.Point(3, 3);
        	this.textBox9.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox9.Multiline = true;
        	this.textBox9.Name = "textBox9";
        	this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox9.Size = new System.Drawing.Size(636, 142);
        	this.textBox9.TabIndex = 9;
        	this.textBox9.Tag = "Main1.Значение";
        	this.textBox9.WordWrap = false;
        	// 
        	// tabPage10
        	// 
        	this.tabPage10.Controls.Add(this.textBox10);
        	this.tabPage10.Location = new System.Drawing.Point(4, 26);
        	this.tabPage10.Name = "tabPage10";
        	this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage10.Size = new System.Drawing.Size(642, 144);
        	this.tabPage10.TabIndex = 9;
        	this.tabPage10.Text = "Value10";
        	this.tabPage10.UseVisualStyleBackColor = true;
        	// 
        	// textBox10
        	// 
        	this.textBox10.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox10.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox10.Location = new System.Drawing.Point(3, 3);
        	this.textBox10.Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
        	this.textBox10.Multiline = true;
        	this.textBox10.Name = "textBox10";
        	this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox10.Size = new System.Drawing.Size(636, 138);
        	this.textBox10.TabIndex = 9;
        	this.textBox10.Tag = "Main1.Значение";
        	this.textBox10.WordWrap = false;
        	// 
        	// FormParamValue
        	// 
        	this.ClientSize = new System.Drawing.Size(672, 385);
        	this.Controls.Add(this.panel2);
        	this.Controls.Add(this.panel1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormParamValue";
        	this.Text = "Param property";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormParamValueFormClosing);
        	this.panel1.ResumeLayout(false);
        	this.panel2.ResumeLayout(false);
        	this.panel2.PerformLayout();
        	this.tabControlFBA1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage1.PerformLayout();
        	this.tabPage2.ResumeLayout(false);
        	this.tabPage2.PerformLayout();
        	this.tabPage3.ResumeLayout(false);
        	this.tabPage3.PerformLayout();
        	this.tabPage4.ResumeLayout(false);
        	this.tabPage4.PerformLayout();
        	this.tabPage5.ResumeLayout(false);
        	this.tabPage5.PerformLayout();
        	this.tabPage6.ResumeLayout(false);
        	this.tabPage6.PerformLayout();
        	this.tabPage7.ResumeLayout(false);
        	this.tabPage7.PerformLayout();
        	this.tabPage8.ResumeLayout(false);
        	this.tabPage8.PerformLayout();
        	this.tabPage9.ResumeLayout(false);
        	this.tabPage9.PerformLayout();
        	this.tabPage10.ResumeLayout(false);
        	this.tabPage10.PerformLayout();
        	this.ResumeLayout(false);

        }

        private TabControlFBA tabControlFBA1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TextBox textBox10;
    }
}
