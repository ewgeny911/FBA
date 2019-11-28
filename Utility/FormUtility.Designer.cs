
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 20.03.2017
 * Время: 14:36
 */
 
namespace FBA
{
    partial class FormUtility
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUtility));
        	this.cmCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cm1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cm4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        	this.MainMenu = new System.Windows.Forms.MenuStrip();
        	this.MainMenu_N1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N1_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N5 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_16 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_24 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_25 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_26 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_29 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_11 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_10 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_9 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_8 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_12 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_7 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_5 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_6 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N1_1_2 = new System.Windows.Forms.ToolStripSeparator();
        	this.MainMenu_N2_13 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_15 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_17 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_18 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_19 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_20 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_21 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_22 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_23 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_27 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_28 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N2_30 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N3_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N3_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N3_3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N4_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenu_N4_2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.fontDialog1 = new System.Windows.Forms.FontDialog();
        	this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
        	this.cmCopy.SuspendLayout();
        	this.MainMenu.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// cmCopy
        	// 
        	this.cmCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cm1,
			this.cm2,
			this.cm3,
			this.cm4});
        	this.cmCopy.Name = "contextMenuStrip1";
        	this.cmCopy.Size = new System.Drawing.Size(212, 92);
        	this.cmCopy.Text = "Copy to database";
        	// 
        	// cm1
        	// 
        	this.cm1.Name = "cm1";
        	this.cm1.Size = new System.Drawing.Size(211, 22);
        	this.cm1.Text = "Copy to Remote Database";
        	// 
        	// cm2
        	// 
        	this.cm2.Name = "cm2";
        	this.cm2.Size = new System.Drawing.Size(211, 22);
        	this.cm2.Text = "Copy to Local Database";
        	// 
        	// cm3
        	// 
        	this.cm3.Name = "cm3";
        	this.cm3.Size = new System.Drawing.Size(211, 22);
        	this.cm3.Text = "Export to CSV";
        	// 
        	// cm4
        	// 
        	this.cm4.Name = "cm4";
        	this.cm4.Size = new System.Drawing.Size(211, 22);
        	this.cm4.Text = "Export to XLS";
        	// 
        	// MainMenu
        	// 
        	this.MainMenu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
        	this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N1,
			this.MainMenu_N5,
			this.MainMenu_N2,
			this.MainMenu_N3,
			this.MainMenu_N4});
        	this.MainMenu.Location = new System.Drawing.Point(0, 0);
        	this.MainMenu.Name = "MainMenu";
        	this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
        	this.MainMenu.Size = new System.Drawing.Size(790, 27);
        	this.MainMenu.TabIndex = 49;
        	this.MainMenu.Text = "MainMenu";
        	// 
        	// MainMenu_N1
        	// 
        	this.MainMenu_N1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N1_1});
        	this.MainMenu_N1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N1.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N1.Image")));
        	this.MainMenu_N1.Name = "MainMenu_N1";
        	this.MainMenu_N1.Size = new System.Drawing.Size(59, 21);
        	this.MainMenu_N1.Text = "File";
        	// 
        	// MainMenu_N1_1
        	// 
        	this.MainMenu_N1_1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N1_1.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N1_1.Image")));
        	this.MainMenu_N1_1.Name = "MainMenu_N1_1";
        	this.MainMenu_N1_1.Size = new System.Drawing.Size(100, 22);
        	this.MainMenu_N1_1.Text = "Exit";
        	this.MainMenu_N1_1.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N5
        	// 
        	this.MainMenu_N5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N2_16,
			this.MainMenu_N2_24,
			this.MainMenu_N2_25,
			this.MainMenu_N2_26,
			this.MainMenu_N2_29});
        	this.MainMenu_N5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N5.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N5.Image")));
        	this.MainMenu_N5.Name = "MainMenu_N5";
        	this.MainMenu_N5.Size = new System.Drawing.Size(74, 21);
        	this.MainMenu_N5.Text = "Model";
        	// 
        	// MainMenu_N2_16
        	// 
        	this.MainMenu_N2_16.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_16.Image")));
        	this.MainMenu_N2_16.Name = "MainMenu_N2_16";
        	this.MainMenu_N2_16.Size = new System.Drawing.Size(129, 22);
        	this.MainMenu_N2_16.Text = "Model";
        	this.MainMenu_N2_16.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_24
        	// 
        	this.MainMenu_N2_24.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_24.Image")));
        	this.MainMenu_N2_24.Name = "MainMenu_N2_24";
        	this.MainMenu_N2_24.Size = new System.Drawing.Size(129, 22);
        	this.MainMenu_N2_24.Text = "Entity";
        	this.MainMenu_N2_24.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_25
        	// 
        	this.MainMenu_N2_25.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_25.Image")));
        	this.MainMenu_N2_25.Name = "MainMenu_N2_25";
        	this.MainMenu_N2_25.Size = new System.Drawing.Size(129, 22);
        	this.MainMenu_N2_25.Text = "Attribute";
        	this.MainMenu_N2_25.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_26
        	// 
        	this.MainMenu_N2_26.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_26.Image")));
        	this.MainMenu_N2_26.Name = "MainMenu_N2_26";
        	this.MainMenu_N2_26.Size = new System.Drawing.Size(129, 22);
        	this.MainMenu_N2_26.Text = "Table";
        	this.MainMenu_N2_26.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_29
        	// 
        	this.MainMenu_N2_29.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_29.Image")));
        	this.MainMenu_N2_29.Name = "MainMenu_N2_29";
        	this.MainMenu_N2_29.Size = new System.Drawing.Size(129, 22);
        	this.MainMenu_N2_29.Text = "Method";
        	this.MainMenu_N2_29.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2
        	// 
        	this.MainMenu_N2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N1_1_2,
			this.MainMenu_N2_23,
			this.MainMenu_N2_13,
			this.MainMenu_N2_15,
			this.MainMenu_N2_17,
			this.MainMenu_N2_18,
			this.MainMenu_N2_19,
			this.MainMenu_N2_20,
			this.MainMenu_N2_21,
			this.MainMenu_N2_22,
			this.MainMenu_N2_27,
			this.MainMenu_N2_28,
			this.MainMenu_N2_30,
			this.toolStripMenuItem1,
			this.MainMenu_N2_12,
			this.MainMenu_N2_11});
        	this.MainMenu_N2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2.Image")));
        	this.MainMenu_N2.Name = "MainMenu_N2";
        	this.MainMenu_N2.Size = new System.Drawing.Size(70, 21);
        	this.MainMenu_N2.Text = "Tools";
        	// 
        	// MainMenu_N2_11
        	// 
        	this.MainMenu_N2_11.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N2_10,
			this.MainMenu_N2_9,
			this.MainMenu_N2_8});
        	this.MainMenu_N2_11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_11.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_11.Image")));
        	this.MainMenu_N2_11.Name = "MainMenu_N2_11";
        	this.MainMenu_N2_11.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_11.Text = "Program";
        	// 
        	// MainMenu_N2_10
        	// 
        	this.MainMenu_N2_10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_10.Name = "MainMenu_N2_10";
        	this.MainMenu_N2_10.Size = new System.Drawing.Size(152, 22);
        	this.MainMenu_N2_10.Text = "Client";
        	this.MainMenu_N2_10.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_9
        	// 
        	this.MainMenu_N2_9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_9.Name = "MainMenu_N2_9";
        	this.MainMenu_N2_9.Size = new System.Drawing.Size(152, 22);
        	this.MainMenu_N2_9.Text = "Server";
        	this.MainMenu_N2_9.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_8
        	// 
        	this.MainMenu_N2_8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_8.Name = "MainMenu_N2_8";
        	this.MainMenu_N2_8.Size = new System.Drawing.Size(152, 22);
        	this.MainMenu_N2_8.Text = "Updater";
        	this.MainMenu_N2_8.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_12
        	// 
        	this.MainMenu_N2_12.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N2_3,
			this.MainMenu_N2_7,
			this.MainMenu_N2_4,
			this.MainMenu_N2_5,
			this.MainMenu_N2_6});
        	this.MainMenu_N2_12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_12.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_12.Image")));
        	this.MainMenu_N2_12.Name = "MainMenu_N2_12";
        	this.MainMenu_N2_12.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_12.Text = "Programming";
        	// 
        	// MainMenu_N2_3
        	// 
        	this.MainMenu_N2_3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_3.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_3.Image")));
        	this.MainMenu_N2_3.Name = "MainMenu_N2_3";
        	this.MainMenu_N2_3.Size = new System.Drawing.Size(204, 22);
        	this.MainMenu_N2_3.Text = "Color table 1";
        	this.MainMenu_N2_3.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_7
        	// 
        	this.MainMenu_N2_7.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_7.Image")));
        	this.MainMenu_N2_7.Name = "MainMenu_N2_7";
        	this.MainMenu_N2_7.Size = new System.Drawing.Size(204, 22);
        	this.MainMenu_N2_7.Text = "Color table 2";
        	this.MainMenu_N2_7.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_4
        	// 
        	this.MainMenu_N2_4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_4.Name = "MainMenu_N2_4";
        	this.MainMenu_N2_4.Size = new System.Drawing.Size(204, 22);
        	this.MainMenu_N2_4.Text = "Regular Expression";
        	this.MainMenu_N2_4.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_5
        	// 
        	this.MainMenu_N2_5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_5.Name = "MainMenu_N2_5";
        	this.MainMenu_N2_5.Size = new System.Drawing.Size(204, 22);
        	this.MainMenu_N2_5.Text = "Table ASC II";
        	this.MainMenu_N2_5.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_6
        	// 
        	this.MainMenu_N2_6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_6.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_6.Image")));
        	this.MainMenu_N2_6.Name = "MainMenu_N2_6";
        	this.MainMenu_N2_6.Size = new System.Drawing.Size(204, 22);
        	this.MainMenu_N2_6.Text = "Date Time Format";
        	this.MainMenu_N2_6.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N1_1_2
        	// 
        	this.MainMenu_N1_1_2.Name = "MainMenu_N1_1_2";
        	this.MainMenu_N1_1_2.Size = new System.Drawing.Size(162, 6);
        	// 
        	// MainMenu_N2_13
        	// 
        	this.MainMenu_N2_13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_13.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_13.Image")));
        	this.MainMenu_N2_13.Name = "MainMenu_N2_13";
        	this.MainMenu_N2_13.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_13.Text = "Grant";
        	this.MainMenu_N2_13.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_15
        	// 
        	this.MainMenu_N2_15.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_15.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_15.Image")));
        	this.MainMenu_N2_15.Name = "MainMenu_N2_15";
        	this.MainMenu_N2_15.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_15.Text = "DDL";
        	this.MainMenu_N2_15.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_17
        	// 
        	this.MainMenu_N2_17.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_17.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_17.Image")));
        	this.MainMenu_N2_17.Name = "MainMenu_N2_17";
        	this.MainMenu_N2_17.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_17.Text = "SQL";
        	this.MainMenu_N2_17.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_18
        	// 
        	this.MainMenu_N2_18.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_18.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_18.Image")));
        	this.MainMenu_N2_18.Name = "MainMenu_N2_18";
        	this.MainMenu_N2_18.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_18.Text = "Update";
        	this.MainMenu_N2_18.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_19
        	// 
        	this.MainMenu_N2_19.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_19.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_19.Image")));
        	this.MainMenu_N2_19.Name = "MainMenu_N2_19";
        	this.MainMenu_N2_19.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_19.Text = "Image";
        	this.MainMenu_N2_19.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_20
        	// 
        	this.MainMenu_N2_20.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_20.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_20.Image")));
        	this.MainMenu_N2_20.Name = "MainMenu_N2_20";
        	this.MainMenu_N2_20.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_20.Text = "Text";
        	this.MainMenu_N2_20.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_21
        	// 
        	this.MainMenu_N2_21.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N2_21.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_21.Image")));
        	this.MainMenu_N2_21.Name = "MainMenu_N2_21";
        	this.MainMenu_N2_21.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_21.Text = "Param";
        	this.MainMenu_N2_21.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_22
        	// 
        	this.MainMenu_N2_22.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_22.Image")));
        	this.MainMenu_N2_22.Name = "MainMenu_N2_22";
        	this.MainMenu_N2_22.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_22.Text = "Status";
        	this.MainMenu_N2_22.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_23
        	// 
        	this.MainMenu_N2_23.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_23.Image")));
        	this.MainMenu_N2_23.Name = "MainMenu_N2_23";
        	this.MainMenu_N2_23.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_23.Text = "Form service";
        	this.MainMenu_N2_23.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_27
        	// 
        	this.MainMenu_N2_27.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_27.Image")));
        	this.MainMenu_N2_27.Name = "MainMenu_N2_27";
        	this.MainMenu_N2_27.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_27.Text = "Report";
        	this.MainMenu_N2_27.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_28
        	// 
        	this.MainMenu_N2_28.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N2_28.Image")));
        	this.MainMenu_N2_28.Name = "MainMenu_N2_28";
        	this.MainMenu_N2_28.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_28.Text = "Error";
        	this.MainMenu_N2_28.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N2_30
        	// 
        	this.MainMenu_N2_30.Name = "MainMenu_N2_30";
        	this.MainMenu_N2_30.Size = new System.Drawing.Size(165, 22);
        	this.MainMenu_N2_30.Text = "Filter";
        	this.MainMenu_N2_30.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N3
        	// 
        	this.MainMenu_N3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N3_1,
			this.MainMenu_N3_2,
			this.MainMenu_N3_3});
        	this.MainMenu_N3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N3.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N3.Image")));
        	this.MainMenu_N3.Name = "MainMenu_N3";
        	this.MainMenu_N3.Size = new System.Drawing.Size(89, 21);
        	this.MainMenu_N3.Text = "Settings";
        	// 
        	// MainMenu_N3_1
        	// 
        	this.MainMenu_N3_1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N3_1.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N3_1.Image")));
        	this.MainMenu_N3_1.Name = "MainMenu_N3_1";
        	this.MainMenu_N3_1.Size = new System.Drawing.Size(208, 22);
        	this.MainMenu_N3_1.Text = "Connection list";
        	this.MainMenu_N3_1.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N3_2
        	// 
        	this.MainMenu_N3_2.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N3_2.Image")));
        	this.MainMenu_N3_2.Name = "MainMenu_N3_2";
        	this.MainMenu_N3_2.Size = new System.Drawing.Size(208, 22);
        	this.MainMenu_N3_2.Text = "Global Font";
        	this.MainMenu_N3_2.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N3_3
        	// 
        	this.MainMenu_N3_3.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N3_3.Image")));
        	this.MainMenu_N3_3.Name = "MainMenu_N3_3";
        	this.MainMenu_N3_3.Size = new System.Drawing.Size(208, 22);
        	this.MainMenu_N3_3.Text = "Solution string count";
        	this.MainMenu_N3_3.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N4
        	// 
        	this.MainMenu_N4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenu_N4_1,
			this.MainMenu_N4_2});
        	this.MainMenu_N4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N4.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N4.Image")));
        	this.MainMenu_N4.Name = "MainMenu_N4";
        	this.MainMenu_N4.Size = new System.Drawing.Size(65, 21);
        	this.MainMenu_N4.Text = "Help";
        	// 
        	// MainMenu_N4_1
        	// 
        	this.MainMenu_N4_1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N4_1.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N4_1.Image")));
        	this.MainMenu_N4_1.Name = "MainMenu_N4_1";
        	this.MainMenu_N4_1.Size = new System.Drawing.Size(113, 22);
        	this.MainMenu_N4_1.Text = "Help";
        	this.MainMenu_N4_1.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// MainMenu_N4_2
        	// 
        	this.MainMenu_N4_2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenu_N4_2.Image = ((System.Drawing.Image)(resources.GetObject("MainMenu_N4_2.Image")));
        	this.MainMenu_N4_2.Name = "MainMenu_N4_2";
        	this.MainMenu_N4_2.Size = new System.Drawing.Size(113, 22);
        	this.MainMenu_N4_2.Text = "About";
        	this.MainMenu_N4_2.Click += new System.EventHandler(this.MainMenu_N1_1Click);
        	// 
        	// fontDialog1
        	// 
        	this.fontDialog1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.fontDialog1.FontMustExist = true;
        	this.fontDialog1.ShowApply = true;
        	// 
        	// toolStripMenuItem1
        	// 
        	this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        	this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
        	// 
        	// FormUtility
        	// 
        	this.ClientSize = new System.Drawing.Size(790, 382);
        	this.Controls.Add(this.MainMenu);
        	this.Font = new System.Drawing.Font("Arial", 11.25F);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.IsMdiContainer = true;
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormUtility";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Utilites";
        	this.Load += new System.EventHandler(this.FormUtilityLoad);
        	this.cmCopy.ResumeLayout(false);
        	this.MainMenu.ResumeLayout(false);
        	this.MainMenu.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        
        //private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N1_1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2;
        private System.Windows.Forms.ToolStripSeparator MainMenu_N1_1_2;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_3;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3_1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N4;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N4_1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N4_2;
        private System.Windows.Forms.ContextMenuStrip cmCopy;
        private System.Windows.Forms.ToolStripMenuItem cm2;
        private System.Windows.Forms.ToolStripMenuItem cm1;
        private System.Windows.Forms.ToolStripMenuItem cm3;
        private System.Windows.Forms.ToolStripMenuItem cm4;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_11;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_10;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_9;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_8;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_12;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_4;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_5;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_6;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_13;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_15;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_17;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_18;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_19;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_20;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_21;
             
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_22;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3_2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N3_3;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_23;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_27;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_7;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_28;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N5;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_16;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_24;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_25;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_26;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_29;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_N2_30;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}
