namespace FBA
{
    partial class FormImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new FBA.TabControlFBA();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DG1 = new FBA.GridFBA(); //FBA.GridFBA();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DG2 = new FBA.GridFBA(); //FBA.GridFBA();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DG3 = new FBA.GridFBA();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.DG4 = new FBA.GridFBA();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbLog = new FBA.TextBoxFBA();
            this.panelFBA1 = new FBA.PanelFBA();
            this.btnStop = new FBA.ButtonFBA();
            this.panelFBA2 = new FBA.PanelFBA();
            this.labelFBA1 = new FBA.LabelFBA();
            this.tbFileName = new FBA.TextBoxFBA();
            this.buttonFBA1 = new FBA.ButtonFBA();
            this.progressBarFBA1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panelFBA1.SuspendLayout();
            this.panelFBA2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AttrBrief = null;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.GroupEnabled = null;
            this.tabControl1.HideTabs = false;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Obj = null;
            this.tabControl1.SaveParam = false;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectTabBackColor = System.Drawing.Color.LightCyan;
            this.tabControl1.SelectTabFontColor = System.Drawing.Color.Blue;
            this.tabControl1.SetSelectTabBackColor = true;
            this.tabControl1.Size = new System.Drawing.Size(656, 244);
            this.tabControl1.StarColor = System.Drawing.Color.Crimson;
            this.tabControl1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.tabControl1.StarOffsetX = 2;
            this.tabControl1.StarOffsetY = -4;
            this.tabControl1.StarPageIndex = -2;
            this.tabControl1.StarShow = false;
            this.tabControl1.StarText = "*";
            this.tabControl1.TabFontColor = System.Drawing.Color.Black;
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(648, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Params";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.DG1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(648, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Source data";
            // 
            // DG1
            // 
            this.DG1.BackColor = System.Drawing.Color.LightGray;
            this.DG1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DG1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DG1.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
            this.DG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG1.EnableSort = false;
            this.DG1.FixedRows = 1;
            this.DG1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DG1.Location = new System.Drawing.Point(3, 3);
            this.DG1.Name = "DG1";
            this.DG1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.DG1.Size = new System.Drawing.Size(642, 208);
            this.DG1.TabIndex = 29;
            this.DG1.TabStop = true;
            this.DG1.ToolTipText = "";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.DG2);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(648, 214);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Error data";
            // 
            // DG2
            // 
            this.DG2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DG2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DG2.DefaultWidth = 20;
            this.DG2.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
            this.DG2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG2.EnableSort = false;
            this.DG2.FixedRows = 1;
            this.DG2.Location = new System.Drawing.Point(3, 3);
            this.DG2.Name = "DG2";
            this.DG2.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.DG2.Size = new System.Drawing.Size(642, 208);
            this.DG2.TabIndex = 16;
            this.DG2.TabStop = true;
            this.DG2.ToolTipText = "";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.DG3);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(648, 214);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Data for load ";
            // 
            // DG3
            // 
            this.DG3.BackColor = System.Drawing.Color.LightGray;
            this.DG3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DG3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DG3.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
            this.DG3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG3.EnableSort = false;
            this.DG3.FixedRows = 1;
            this.DG3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DG3.Location = new System.Drawing.Point(3, 3);
            this.DG3.Name = "DG3";
            this.DG3.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.DG3.Size = new System.Drawing.Size(642, 208);
            this.DG3.TabIndex = 29;
            this.DG3.TabStop = true;
            this.DG3.ToolTipText = "";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.DG4);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(648, 214);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Download data ";
            // 
            // DG4
            // 
            this.DG4.BackColor = System.Drawing.Color.LightGray;
            this.DG4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DG4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DG4.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
            this.DG4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG4.EnableSort = false;
            this.DG4.FixedRows = 1;
            this.DG4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DG4.Location = new System.Drawing.Point(3, 3);
            this.DG4.Name = "DG4";
            this.DG4.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.DG4.Size = new System.Drawing.Size(642, 208);
            this.DG4.TabIndex = 29;
            this.DG4.TabStop = true;
            this.DG4.ToolTipText = "";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.tbLog);
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(648, 214);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Log";
            // 
            // tbLog
            // 
            this.tbLog.AttrBrief = null;
            this.tbLog.AttrBriefLookup = null;
            this.tbLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.ErrorIfNull = null;
            this.tbLog.GroupEnabled = null;
            this.tbLog.ListInvalidChars = null;
            this.tbLog.ListValidChars = null;
            this.tbLog.Location = new System.Drawing.Point(3, 3);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ObjectRef = null;
            this.tbLog.RegExChars = null;
            this.tbLog.SaveParam = false;
            this.tbLog.SaveValueHistory = false;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(642, 208);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text2 = null;
            // 
            // panelFBA1
            // 
            this.panelFBA1.AttrBrief = null;
            this.panelFBA1.Controls.Add(this.progressBarFBA1);
            this.panelFBA1.Controls.Add(this.btnStop);
            this.panelFBA1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFBA1.GroupEnabled = null;
            this.panelFBA1.Location = new System.Drawing.Point(0, 280);
            this.panelFBA1.Name = "panelFBA1";
            this.panelFBA1.Obj = null;
            this.panelFBA1.ObjectRef = null;
            this.panelFBA1.SaveParam = false;
            this.panelFBA1.Size = new System.Drawing.Size(656, 43);
            this.panelFBA1.TabIndex = 3;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.AttrBrief = null;
            this.btnStop.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.GroupEnabled = null;
            this.btnStop.Location = new System.Drawing.Point(574, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Obj = null;
            this.btnStop.ObjectRef = null;
            this.btnStop.SaveParam = false;
            this.btnStop.Size = new System.Drawing.Size(78, 33);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // panelFBA2
            // 
            this.panelFBA2.AttrBrief = null;
            this.panelFBA2.Controls.Add(this.labelFBA1);
            this.panelFBA2.Controls.Add(this.tbFileName);
            this.panelFBA2.Controls.Add(this.buttonFBA1);
            this.panelFBA2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFBA2.GroupEnabled = null;
            this.panelFBA2.Location = new System.Drawing.Point(0, 0);
            this.panelFBA2.Name = "panelFBA2";
            this.panelFBA2.Obj = null;
            this.panelFBA2.ObjectRef = null;
            this.panelFBA2.SaveParam = false;
            this.panelFBA2.Size = new System.Drawing.Size(656, 36);
            this.panelFBA2.TabIndex = 5;
            // 
            // labelFBA1
            // 
            this.labelFBA1.AutoSize = true;
            this.labelFBA1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFBA1.Location = new System.Drawing.Point(12, 9);
            this.labelFBA1.Name = "labelFBA1";
            this.labelFBA1.Size = new System.Drawing.Size(31, 17);
            this.labelFBA1.StarColor = System.Drawing.Color.Crimson;
            this.labelFBA1.StarFont = new System.Drawing.Font("Arial", 20F);
            this.labelFBA1.StarOffsetX = 2;
            this.labelFBA1.StarOffsetY = -4;
            this.labelFBA1.StarShow = false;
            this.labelFBA1.StarText = "*";
            this.labelFBA1.TabIndex = 2;
            this.labelFBA1.Text = "File";
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.AttrBrief = null;
            this.tbFileName.AttrBriefLookup = null;
            this.tbFileName.ErrorIfNull = null;
            this.tbFileName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFileName.GroupEnabled = null;
            this.tbFileName.ListInvalidChars = null;
            this.tbFileName.ListValidChars = null;
            this.tbFileName.Location = new System.Drawing.Point(50, 5);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ObjectRef = null;
            this.tbFileName.RegExChars = null;
            this.tbFileName.SaveParam = false;
            this.tbFileName.SaveValueHistory = false;
            this.tbFileName.Size = new System.Drawing.Size(560, 25);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.Text2 = null;
            // 
            // buttonFBA1
            // 
            this.buttonFBA1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFBA1.AttrBrief = null;
            this.buttonFBA1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFBA1.GroupEnabled = null;
            this.buttonFBA1.Location = new System.Drawing.Point(616, 5);
            this.buttonFBA1.Name = "buttonFBA1";
            this.buttonFBA1.Obj = null;
            this.buttonFBA1.ObjectRef = null;
            this.buttonFBA1.SaveParam = false;
            this.buttonFBA1.Size = new System.Drawing.Size(36, 25);
            this.buttonFBA1.TabIndex = 0;
            this.buttonFBA1.Text = "...";
            this.buttonFBA1.UseVisualStyleBackColor = true;
            this.buttonFBA1.Click += new System.EventHandler(this.buttonFBA1_Click);
            // 
            // progressBarFBA1
            // 
            this.progressBarFBA1.Location = new System.Drawing.Point(13, 6);
            this.progressBarFBA1.Name = "progressBarFBA1";
            this.progressBarFBA1.Size = new System.Drawing.Size(555, 30);
            this.progressBarFBA1.TabIndex = 2;
            // 
            // FormImport
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 323);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelFBA1);
            this.Controls.Add(this.panelFBA2);
            this.Name = "FormImport";
            this.Text = "Universal Import Data";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.panelFBA1.ResumeLayout(false);
            this.panelFBA2.ResumeLayout(false);
            this.panelFBA2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonFBA buttonFBA1;
        private TextBoxFBA tbFileName;
        private PanelFBA panelFBA1;
        private TabControlFBA tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private PanelFBA panelFBA2;
        //private FBA.ProgressBarFBA progressBar1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private LabelFBA labelFBA1;
        private FBA.GridFBA DG1;
        private FBA.GridFBA DG3;
        private FBA.GridFBA DG4;
        private ButtonFBA btnStop;
        private FBA.GridFBA DG2;
        private System.Windows.Forms.TabPage tabPage6;
        private TextBoxFBA tbLog;
        private System.Windows.Forms.ProgressBar progressBarFBA1;
    }
}