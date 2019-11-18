
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 06.11.2017
 * Время: 0:09
 */
 
namespace FBA
{
    partial class FormLicense
    {
        
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLicenseCreate;
        private System.Windows.Forms.TextBox tbServerInfo;
        private FBA.LabelFBA label1;
        private System.Windows.Forms.TextBox tbLicense;
        private FBA.LabelFBA label2;
        private System.Windows.Forms.TextBox tbLicenseCount1;
        private FBA.LabelFBA lbLicenseCount1;
        private FBA.LabelFBA lbDateStart1;
        private FBA.LabelFBA lbDateEnd1;
        private System.Windows.Forms.DateTimePicker dtDateStart1;
        private System.Windows.Forms.DateTimePicker dtDateEnd1;
        private System.Windows.Forms.Button btnCheckServerInfo;
        private FBA.LabelFBA lbDateCreate1;
        private FBA.LabelFBA lbMotherBoardID1;
        private FBA.LabelFBA lbProcessorID1;
        private System.Windows.Forms.DateTimePicker dtDateCreate1;
        private System.Windows.Forms.TextBox tbMotherBoardID1;
        private System.Windows.Forms.TextBox tbProcessorID1;
        private System.Windows.Forms.TextBox tbProcessorID2;
        private System.Windows.Forms.TextBox tbMotherBoardID2;
        private System.Windows.Forms.DateTimePicker dtDateCreate2;
        private FBA.LabelFBA lbProcessorID2;
        private FBA.LabelFBA lbMotherBoardID2;
        private FBA.LabelFBA lbDateCreate2;
        private System.Windows.Forms.DateTimePicker dtDateEnd2;
        private System.Windows.Forms.DateTimePicker dtDateStart2;
        private FBA.LabelFBA lbDateEnd2;
        private FBA.LabelFBA lbDateStart2;
        private FBA.LabelFBA lbLicenseCount2;
        private System.Windows.Forms.TextBox tbLicenseCount2;
        private System.Windows.Forms.Button btnTo2;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnHelp;

        /// <summary>
		/// Dispose
		/// </summary>      
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
            this.btnLicenseCreate = new System.Windows.Forms.Button();
            this.tbServerInfo = new System.Windows.Forms.TextBox();
            this.label1 = new FBA.LabelFBA();
            this.tbLicense = new System.Windows.Forms.TextBox();
            this.label2 = new FBA.LabelFBA();
            this.tbLicenseCount1 = new System.Windows.Forms.TextBox();
            this.lbLicenseCount1 = new FBA.LabelFBA();
            this.lbDateStart1 = new FBA.LabelFBA();
            this.lbDateEnd1 = new FBA.LabelFBA();
            this.dtDateStart1 = new System.Windows.Forms.DateTimePicker();
            this.dtDateEnd1 = new System.Windows.Forms.DateTimePicker();
            this.btnCheckServerInfo = new System.Windows.Forms.Button();
            this.lbDateCreate1 = new FBA.LabelFBA();
            this.lbMotherBoardID1 = new FBA.LabelFBA();
            this.lbProcessorID1 = new FBA.LabelFBA();
            this.dtDateCreate1 = new System.Windows.Forms.DateTimePicker();
            this.tbMotherBoardID1 = new System.Windows.Forms.TextBox();
            this.tbProcessorID1 = new System.Windows.Forms.TextBox();
            this.tbProcessorID2 = new System.Windows.Forms.TextBox();
            this.tbMotherBoardID2 = new System.Windows.Forms.TextBox();
            this.dtDateCreate2 = new System.Windows.Forms.DateTimePicker();
            this.lbProcessorID2 = new FBA.LabelFBA();
            this.lbMotherBoardID2 = new FBA.LabelFBA();
            this.lbDateCreate2 = new FBA.LabelFBA();
            this.dtDateEnd2 = new System.Windows.Forms.DateTimePicker();
            this.dtDateStart2 = new System.Windows.Forms.DateTimePicker();
            this.lbDateEnd2 = new FBA.LabelFBA();
            this.lbDateStart2 = new FBA.LabelFBA();
            this.lbLicenseCount2 = new FBA.LabelFBA();
            this.tbLicenseCount2 = new System.Windows.Forms.TextBox();
            this.btnTo2 = new System.Windows.Forms.Button();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLicenseCreate
            // 
            this.btnLicenseCreate.Font = Var.font1;
            this.btnLicenseCreate.Location = new System.Drawing.Point(370, 464);
            this.btnLicenseCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnLicenseCreate.Name = "btnLicenseCreate";
            this.btnLicenseCreate.Size = new System.Drawing.Size(160, 33);
            this.btnLicenseCreate.TabIndex = 0;
            this.btnLicenseCreate.Text = "Create license";
            this.btnLicenseCreate.UseVisualStyleBackColor = true;
            this.btnLicenseCreate.Click += new System.EventHandler(this.BtnLicenseCreateClick);
            // 
            // tbServerInfo
            // 
            this.tbServerInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tbServerInfo.Font = Var.font1;
            this.tbServerInfo.Location = new System.Drawing.Point(8, 25);
            this.tbServerInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tbServerInfo.Multiline = true;
            this.tbServerInfo.Name = "tbServerInfo";
            this.tbServerInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbServerInfo.Size = new System.Drawing.Size(358, 243);
            this.tbServerInfo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = Var.font1;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.StarColor = System.Drawing.Color.Crimson;
            this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label1.StarOffsetX = 2;
            this.label1.StarOffsetY = -4;
            this.label1.StarShow = false;
            this.label1.StarText = "*";
            this.label1.TabIndex = 2;
            this.label1.Text = "Server info";
            // 
            // tbLicense
            // 
            this.tbLicense.BackColor = System.Drawing.SystemColors.Info;
            this.tbLicense.Font = Var.font1;
            this.tbLicense.Location = new System.Drawing.Point(374, 25);
            this.tbLicense.Margin = new System.Windows.Forms.Padding(4);
            this.tbLicense.Multiline = true;
            this.tbLicense.Name = "tbLicense";
            this.tbLicense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLicense.Size = new System.Drawing.Size(358, 243);
            this.tbLicense.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = Var.font1;
            this.label2.Location = new System.Drawing.Point(374, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 16);
            this.label2.StarColor = System.Drawing.Color.Crimson;
            this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.label2.StarOffsetX = 2;
            this.label2.StarOffsetY = -4;
            this.label2.StarShow = false;
            this.label2.StarText = "*";
            this.label2.TabIndex = 6;
            this.label2.Text = "New license key";
            // 
            // tbLicenseCount1
            // 
            this.tbLicenseCount1.BackColor = System.Drawing.SystemColors.Info;
            this.tbLicenseCount1.Font = Var.font1;
            this.tbLicenseCount1.Location = new System.Drawing.Point(119, 340);
            this.tbLicenseCount1.Margin = new System.Windows.Forms.Padding(4);
            this.tbLicenseCount1.Name = "tbLicenseCount1";
            this.tbLicenseCount1.Size = new System.Drawing.Size(132, 25);
            this.tbLicenseCount1.TabIndex = 7;
            // 
            // lbLicenseCount1
            // 
            this.lbLicenseCount1.Font = Var.font1;
            this.lbLicenseCount1.Location = new System.Drawing.Point(1, 343);
            this.lbLicenseCount1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLicenseCount1.Name = "lbLicenseCount1";
            this.lbLicenseCount1.Size = new System.Drawing.Size(107, 22);
            this.lbLicenseCount1.StarColor = System.Drawing.Color.Crimson;
            this.lbLicenseCount1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbLicenseCount1.StarOffsetX = 2;
            this.lbLicenseCount1.StarOffsetY = -4;
            this.lbLicenseCount1.StarShow = false;
            this.lbLicenseCount1.StarText = "*";
            this.lbLicenseCount1.TabIndex = 8;
            this.lbLicenseCount1.Text = "License count:";
            // 
            // lbDateStart1
            // 
            this.lbDateStart1.Font = Var.font1;
            this.lbDateStart1.Location = new System.Drawing.Point(4, 401);
            this.lbDateStart1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDateStart1.Name = "lbDateStart1";
            this.lbDateStart1.Size = new System.Drawing.Size(83, 22);
            this.lbDateStart1.StarColor = System.Drawing.Color.Crimson;
            this.lbDateStart1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbDateStart1.StarOffsetX = 2;
            this.lbDateStart1.StarOffsetY = -4;
            this.lbDateStart1.StarShow = false;
            this.lbDateStart1.StarText = "*";
            this.lbDateStart1.TabIndex = 9;
            this.lbDateStart1.Text = "Date start:";
            // 
            // lbDateEnd1
            // 
            this.lbDateEnd1.Font = Var.font1;
            this.lbDateEnd1.Location = new System.Drawing.Point(4, 431);
            this.lbDateEnd1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDateEnd1.Name = "lbDateEnd1";
            this.lbDateEnd1.Size = new System.Drawing.Size(83, 22);
            this.lbDateEnd1.StarColor = System.Drawing.Color.Crimson;
            this.lbDateEnd1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbDateEnd1.StarOffsetX = 2;
            this.lbDateEnd1.StarOffsetY = -4;
            this.lbDateEnd1.StarShow = false;
            this.lbDateEnd1.StarText = "*";
            this.lbDateEnd1.TabIndex = 10;
            this.lbDateEnd1.Text = "Date end:";
            // 
            // dtDateStart1
            // 
            this.dtDateStart1.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dtDateStart1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateStart1.Location = new System.Drawing.Point(119, 398);
            this.dtDateStart1.Name = "dtDateStart1";
            this.dtDateStart1.Size = new System.Drawing.Size(132, 25);
            this.dtDateStart1.TabIndex = 11;
            this.dtDateStart1.Value = Var.MinStateDate;            
            // 
            // dtDateEnd1
            // 
            this.dtDateEnd1.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dtDateEnd1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateEnd1.Location = new System.Drawing.Point(119, 427);
            this.dtDateEnd1.Name = "dtDateEnd1";
            this.dtDateEnd1.Size = new System.Drawing.Size(132, 25);
            this.dtDateEnd1.TabIndex = 12;
            this.dtDateEnd1.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // btnCheckServerInfo
            // 
            this.btnCheckServerInfo.Font = Var.font1;
            this.btnCheckServerInfo.Location = new System.Drawing.Point(9, 464);
            this.btnCheckServerInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckServerInfo.Name = "btnCheckServerInfo";
            this.btnCheckServerInfo.Size = new System.Drawing.Size(160, 33);
            this.btnCheckServerInfo.TabIndex = 13;
            this.btnCheckServerInfo.Text = "Check server info";
            this.btnCheckServerInfo.UseVisualStyleBackColor = true;
            this.btnCheckServerInfo.Click += new System.EventHandler(this.BtnCheckServerInfoClick);
            // 
            // lbDateCreate1
            // 
            this.lbDateCreate1.Font = Var.font1;
            this.lbDateCreate1.Location = new System.Drawing.Point(4, 372);
            this.lbDateCreate1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDateCreate1.Name = "lbDateCreate1";
            this.lbDateCreate1.Size = new System.Drawing.Size(92, 22);
            this.lbDateCreate1.StarColor = System.Drawing.Color.Crimson;
            this.lbDateCreate1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbDateCreate1.StarOffsetX = 2;
            this.lbDateCreate1.StarOffsetY = -4;
            this.lbDateCreate1.StarShow = false;
            this.lbDateCreate1.StarText = "*";
            this.lbDateCreate1.TabIndex = 14;
            this.lbDateCreate1.Text = "Date create:";
            // 
            // lbMotherBoardID1
            // 
            this.lbMotherBoardID1.Font = Var.font1;
            this.lbMotherBoardID1.Location = new System.Drawing.Point(4, 313);
            this.lbMotherBoardID1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMotherBoardID1.Name = "lbMotherBoardID1";
            this.lbMotherBoardID1.Size = new System.Drawing.Size(107, 22);
            this.lbMotherBoardID1.StarColor = System.Drawing.Color.Crimson;
            this.lbMotherBoardID1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbMotherBoardID1.StarOffsetX = 2;
            this.lbMotherBoardID1.StarOffsetY = -4;
            this.lbMotherBoardID1.StarShow = false;
            this.lbMotherBoardID1.StarText = "*";
            this.lbMotherBoardID1.TabIndex = 15;
            this.lbMotherBoardID1.Text = "MotherBoardID:";
            // 
            // lbProcessorID1
            // 
            this.lbProcessorID1.Font = Var.font1;
            this.lbProcessorID1.Location = new System.Drawing.Point(4, 283);
            this.lbProcessorID1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProcessorID1.Name = "lbProcessorID1";
            this.lbProcessorID1.Size = new System.Drawing.Size(107, 22);
            this.lbProcessorID1.StarColor = System.Drawing.Color.Crimson;
            this.lbProcessorID1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbProcessorID1.StarOffsetX = 2;
            this.lbProcessorID1.StarOffsetY = -4;
            this.lbProcessorID1.StarShow = false;
            this.lbProcessorID1.StarText = "*";
            this.lbProcessorID1.TabIndex = 16;
            this.lbProcessorID1.Text = "ProcessorID:";
            // 
            // dtDateCreate1
            // 
            this.dtDateCreate1.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dtDateCreate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateCreate1.Location = new System.Drawing.Point(119, 369);
            this.dtDateCreate1.Name = "dtDateCreate1";
            this.dtDateCreate1.Size = new System.Drawing.Size(132, 25);
            this.dtDateCreate1.TabIndex = 17;
            this.dtDateCreate1.Value = Var.MinStateDate;  
            // 
            // tbMotherBoardID1
            // 
            this.tbMotherBoardID1.BackColor = System.Drawing.SystemColors.Info;
            this.tbMotherBoardID1.Font = Var.font1;
            this.tbMotherBoardID1.Location = new System.Drawing.Point(119, 310);
            this.tbMotherBoardID1.Margin = new System.Windows.Forms.Padding(4);
            this.tbMotherBoardID1.Name = "tbMotherBoardID1";
            this.tbMotherBoardID1.Size = new System.Drawing.Size(243, 25);
            this.tbMotherBoardID1.TabIndex = 18;
            // 
            // tbProcessorID1
            // 
            this.tbProcessorID1.BackColor = System.Drawing.SystemColors.Info;
            this.tbProcessorID1.Font = Var.font1;
            this.tbProcessorID1.Location = new System.Drawing.Point(119, 280);
            this.tbProcessorID1.Margin = new System.Windows.Forms.Padding(4);
            this.tbProcessorID1.Name = "tbProcessorID1";
            this.tbProcessorID1.Size = new System.Drawing.Size(243, 25);
            this.tbProcessorID1.TabIndex = 19;
            // 
            // tbProcessorID2
            // 
            this.tbProcessorID2.BackColor = System.Drawing.SystemColors.Info;
            this.tbProcessorID2.Font = Var.font1;
            this.tbProcessorID2.Location = new System.Drawing.Point(488, 276);
            this.tbProcessorID2.Margin = new System.Windows.Forms.Padding(4);
            this.tbProcessorID2.Name = "tbProcessorID2";
            this.tbProcessorID2.Size = new System.Drawing.Size(244, 25);
            this.tbProcessorID2.TabIndex = 31;
            this.tbProcessorID2.Text = "10";
            // 
            // tbMotherBoardID2
            // 
            this.tbMotherBoardID2.BackColor = System.Drawing.SystemColors.Info;
            this.tbMotherBoardID2.Font = Var.font1;
            this.tbMotherBoardID2.Location = new System.Drawing.Point(488, 306);
            this.tbMotherBoardID2.Margin = new System.Windows.Forms.Padding(4);
            this.tbMotherBoardID2.Name = "tbMotherBoardID2";
            this.tbMotherBoardID2.Size = new System.Drawing.Size(244, 25);
            this.tbMotherBoardID2.TabIndex = 30;
            this.tbMotherBoardID2.Text = "10";
            // 
            // dtDateCreate2
            // 
            this.dtDateCreate2.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dtDateCreate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateCreate2.Location = new System.Drawing.Point(488, 365);
            this.dtDateCreate2.Name = "dtDateCreate2";
            this.dtDateCreate2.Size = new System.Drawing.Size(132, 25);
            this.dtDateCreate2.TabIndex = 29;
            // 
            // lbProcessorID2
            // 
            this.lbProcessorID2.Font = Var.font1;
            this.lbProcessorID2.Location = new System.Drawing.Point(373, 279);
            this.lbProcessorID2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProcessorID2.Name = "lbProcessorID2";
            this.lbProcessorID2.Size = new System.Drawing.Size(107, 22);
            this.lbProcessorID2.StarColor = System.Drawing.Color.Crimson;
            this.lbProcessorID2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbProcessorID2.StarOffsetX = 2;
            this.lbProcessorID2.StarOffsetY = -4;
            this.lbProcessorID2.StarShow = false;
            this.lbProcessorID2.StarText = "*";
            this.lbProcessorID2.TabIndex = 28;
            this.lbProcessorID2.Text = "ProcessorID:";
            // 
            // lbMotherBoardID2
            // 
            this.lbMotherBoardID2.Font = Var.font1;
            this.lbMotherBoardID2.Location = new System.Drawing.Point(373, 309);
            this.lbMotherBoardID2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMotherBoardID2.Name = "lbMotherBoardID2";
            this.lbMotherBoardID2.Size = new System.Drawing.Size(107, 22);
            this.lbMotherBoardID2.StarColor = System.Drawing.Color.Crimson;
            this.lbMotherBoardID2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbMotherBoardID2.StarOffsetX = 2;
            this.lbMotherBoardID2.StarOffsetY = -4;
            this.lbMotherBoardID2.StarShow = false;
            this.lbMotherBoardID2.StarText = "*";
            this.lbMotherBoardID2.TabIndex = 27;
            this.lbMotherBoardID2.Text = "MotherBoardID:";
            // 
            // lbDateCreate2
            // 
            this.lbDateCreate2.Font = Var.font1;
            this.lbDateCreate2.Location = new System.Drawing.Point(373, 368);
            this.lbDateCreate2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDateCreate2.Name = "lbDateCreate2";
            this.lbDateCreate2.Size = new System.Drawing.Size(92, 22);
            this.lbDateCreate2.StarColor = System.Drawing.Color.Crimson;
            this.lbDateCreate2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbDateCreate2.StarOffsetX = 2;
            this.lbDateCreate2.StarOffsetY = -4;
            this.lbDateCreate2.StarShow = false;
            this.lbDateCreate2.StarText = "*";
            this.lbDateCreate2.TabIndex = 26;
            this.lbDateCreate2.Text = "Date create:";
            // 
            // dtDateEnd2
            // 
            this.dtDateEnd2.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dtDateEnd2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateEnd2.Location = new System.Drawing.Point(488, 423);
            this.dtDateEnd2.Name = "dtDateEnd2";
            this.dtDateEnd2.Size = new System.Drawing.Size(132, 25);
            this.dtDateEnd2.TabIndex = 25;
            this.dtDateEnd2.Value = new System.DateTime(2057, 12, 1, 0, 0, 0, 0);
            // 
            // dtDateStart2
            // 
            this.dtDateStart2.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dtDateStart2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateStart2.Location = new System.Drawing.Point(488, 394);
            this.dtDateStart2.Name = "dtDateStart2";
            this.dtDateStart2.Size = new System.Drawing.Size(132, 25);
            this.dtDateStart2.TabIndex = 24;
            // 
            // lbDateEnd2
            // 
            this.lbDateEnd2.Font = Var.font1;
            this.lbDateEnd2.Location = new System.Drawing.Point(373, 427);
            this.lbDateEnd2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDateEnd2.Name = "lbDateEnd2";
            this.lbDateEnd2.Size = new System.Drawing.Size(83, 22);
            this.lbDateEnd2.StarColor = System.Drawing.Color.Crimson;
            this.lbDateEnd2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbDateEnd2.StarOffsetX = 2;
            this.lbDateEnd2.StarOffsetY = -4;
            this.lbDateEnd2.StarShow = false;
            this.lbDateEnd2.StarText = "*";
            this.lbDateEnd2.TabIndex = 23;
            this.lbDateEnd2.Text = "Date end:";
            // 
            // lbDateStart2
            // 
            this.lbDateStart2.Font = Var.font1;
            this.lbDateStart2.Location = new System.Drawing.Point(373, 398);
            this.lbDateStart2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDateStart2.Name = "lbDateStart2";
            this.lbDateStart2.Size = new System.Drawing.Size(83, 22);
            this.lbDateStart2.StarColor = System.Drawing.Color.Crimson;
            this.lbDateStart2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbDateStart2.StarOffsetX = 2;
            this.lbDateStart2.StarOffsetY = -4;
            this.lbDateStart2.StarShow = false;
            this.lbDateStart2.StarText = "*";
            this.lbDateStart2.TabIndex = 22;
            this.lbDateStart2.Text = "Date start:";
            // 
            // lbLicenseCount2
            // 
            this.lbLicenseCount2.Font = Var.font1;
            this.lbLicenseCount2.Location = new System.Drawing.Point(370, 339);
            this.lbLicenseCount2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLicenseCount2.Name = "lbLicenseCount2";
            this.lbLicenseCount2.Size = new System.Drawing.Size(107, 22);
            this.lbLicenseCount2.StarColor = System.Drawing.Color.Crimson;
            this.lbLicenseCount2.StarFont = new System.Drawing.Font("Arial", 20F);
            this.lbLicenseCount2.StarOffsetX = 2;
            this.lbLicenseCount2.StarOffsetY = -4;
            this.lbLicenseCount2.StarShow = false;
            this.lbLicenseCount2.StarText = "*";
            this.lbLicenseCount2.TabIndex = 21;
            this.lbLicenseCount2.Text = "License count:";
            // 
            // tbLicenseCount2
            // 
            this.tbLicenseCount2.BackColor = System.Drawing.SystemColors.Info;
            this.tbLicenseCount2.Font = Var.font1;
            this.tbLicenseCount2.Location = new System.Drawing.Point(488, 336);
            this.tbLicenseCount2.Margin = new System.Windows.Forms.Padding(4);
            this.tbLicenseCount2.Name = "tbLicenseCount2";
            this.tbLicenseCount2.Size = new System.Drawing.Size(132, 25);
            this.tbLicenseCount2.TabIndex = 20;
            this.tbLicenseCount2.Text = "10";
            // 
            // btnTo2
            // 
            this.btnTo2.Font = Var.font1;
            this.btnTo2.Location = new System.Drawing.Point(299, 464);
            this.btnTo2.Margin = new System.Windows.Forms.Padding(4);
            this.btnTo2.Name = "btnTo2";
            this.btnTo2.Size = new System.Drawing.Size(59, 33);
            this.btnTo2.TabIndex = 32;
            this.btnTo2.Text = ">>>";
            this.btnTo2.UseVisualStyleBackColor = true;
            this.btnTo2.Click += new System.EventHandler(this.BtnTo2Click);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Font = Var.font1;
            this.btnCopyToClipboard.Location = new System.Drawing.Point(538, 464);
            this.btnCopyToClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(160, 33);
            this.btnCopyToClipboard.TabIndex = 33;
            this.btnCopyToClipboard.Text = "Copy to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.BtnCopyToClipboardClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = Var.font1;
            this.btnHelp.Location = new System.Drawing.Point(177, 464);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(114, 33);
            this.btnHelp.TabIndex = 34;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelpClick);
            // 
            // FormLicense
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 507);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.btnTo2);
            this.Controls.Add(this.tbProcessorID2);
            this.Controls.Add(this.btnLicenseCreate);
            this.Controls.Add(this.tbMotherBoardID2);
            this.Controls.Add(this.dtDateCreate2);
            this.Controls.Add(this.lbProcessorID2);
            this.Controls.Add(this.lbMotherBoardID2);
            this.Controls.Add(this.lbDateCreate2);
            this.Controls.Add(this.dtDateEnd2);
            this.Controls.Add(this.dtDateStart2);
            this.Controls.Add(this.lbDateEnd2);
            this.Controls.Add(this.lbDateStart2);
            this.Controls.Add(this.lbLicenseCount2);
            this.Controls.Add(this.tbLicenseCount2);
            this.Controls.Add(this.tbProcessorID1);
            this.Controls.Add(this.tbMotherBoardID1);
            this.Controls.Add(this.dtDateCreate1);
            this.Controls.Add(this.lbProcessorID1);
            this.Controls.Add(this.lbMotherBoardID1);
            this.Controls.Add(this.lbDateCreate1);
            this.Controls.Add(this.btnCheckServerInfo);
            this.Controls.Add(this.dtDateEnd1);
            this.Controls.Add(this.dtDateStart1);
            this.Controls.Add(this.lbDateEnd1);
            this.Controls.Add(this.lbDateStart1);
            this.Controls.Add(this.lbLicenseCount1);
            this.Controls.Add(this.tbLicenseCount1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbServerInfo);
            this.Font = Var.font1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLicense";
            this.Text = "License creator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
