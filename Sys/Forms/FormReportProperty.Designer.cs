namespace FBA
{
    partial class FormReportProperty
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
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.lbComment = new FBA.LabelFBA();
        	this.lbName = new FBA.LabelFBA();
        	this.lbBrief = new FBA.LabelFBA();
        	this.lbFileName = new FBA.LabelFBA();
        	this.tbFileName = new FBA.EditFBA();
        	this.tbFormat = new FBA.ComboBoxFBA();
        	this.labelFBA1 = new FBA.LabelFBA();
        	this.tbComment = new FBA.TextBoxFBA();
        	this.tbName = new FBA.TextBoxFBA();
        	this.tbBrief = new FBA.TextBoxFBA();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnCancel);
        	this.panel1.Controls.Add(this.btnOk);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.panel1.Location = new System.Drawing.Point(0, 286);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(466, 41);
        	this.panel1.TabIndex = 18;
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(227, 4);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(112, 33);
        	this.btnCancel.TabIndex = 2;
        	this.btnCancel.Text = "   Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        	// 
        	// btnOk
        	// 
        	this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(345, 4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 0;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// lbComment
        	// 
        	this.lbComment.AutoSize = true;
        	this.lbComment.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbComment.Location = new System.Drawing.Point(6, 176);
        	this.lbComment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbComment.Name = "lbComment";
        	this.lbComment.Size = new System.Drawing.Size(73, 17);
        	this.lbComment.StarColor = System.Drawing.Color.Crimson;
        	this.lbComment.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbComment.StarOffsetX = 2;
        	this.lbComment.StarOffsetY = 0;
        	this.lbComment.StarShow = false;
        	this.lbComment.StarText = "*";
        	this.lbComment.TabIndex = 17;
        	this.lbComment.Text = "Comment";
        	// 
        	// lbName
        	// 
        	this.lbName.AutoSize = true;
        	this.lbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbName.Location = new System.Drawing.Point(6, 2);
        	this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbName.Name = "lbName";
        	this.lbName.Size = new System.Drawing.Size(47, 17);
        	this.lbName.StarColor = System.Drawing.Color.Crimson;
        	this.lbName.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbName.StarOffsetX = 2;
        	this.lbName.StarOffsetY = 0;
        	this.lbName.StarShow = false;
        	this.lbName.StarText = "*";
        	this.lbName.TabIndex = 14;
        	this.lbName.Text = "Name";
        	// 
        	// lbBrief
        	// 
        	this.lbBrief.AutoSize = true;
        	this.lbBrief.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbBrief.Location = new System.Drawing.Point(6, 59);
        	this.lbBrief.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbBrief.Name = "lbBrief";
        	this.lbBrief.Size = new System.Drawing.Size(38, 17);
        	this.lbBrief.StarColor = System.Drawing.Color.Crimson;
        	this.lbBrief.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbBrief.StarOffsetX = 2;
        	this.lbBrief.StarOffsetY = 0;
        	this.lbBrief.StarShow = false;
        	this.lbBrief.StarText = "*";
        	this.lbBrief.TabIndex = 19;
        	this.lbBrief.Text = "Brief";
        	// 
        	// lbFileName
        	// 
        	this.lbFileName.AutoSize = true;
        	this.lbFileName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbFileName.Location = new System.Drawing.Point(6, 118);
        	this.lbFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbFileName.Name = "lbFileName";
        	this.lbFileName.Size = new System.Drawing.Size(72, 17);
        	this.lbFileName.StarColor = System.Drawing.Color.Crimson;
        	this.lbFileName.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbFileName.StarOffsetX = 2;
        	this.lbFileName.StarOffsetY = 0;
        	this.lbFileName.StarShow = false;
        	this.lbFileName.StarText = "*";
        	this.lbFileName.TabIndex = 21;
        	this.lbFileName.Text = "File name";
        	// 
        	// tbFileName
        	// 
        	this.tbFileName.AttrBrief = "Main1.ПолноеИмяФайла";
        	this.tbFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        	this.tbFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        	this.tbFileName.ButtonDeleteVisible = true;
        	this.tbFileName.ButtonEditVisible = true;
        	this.tbFileName.ContextMenuEnabled = true;
        	this.tbFileName.DataSource = null;
        	this.tbFileName.DisplayMember = "";
        	this.tbFileName.DockStyle = System.Windows.Forms.DockStyle.None;
        	this.tbFileName.DrawMode = System.Windows.Forms.DrawMode.Normal;
        	this.tbFileName.DropDownHeight = 106;
        	this.tbFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
        	this.tbFileName.DropDownWidth = 315;
        	this.tbFileName.DroppedDown = true;
        	this.tbFileName.EditFormName = null;
        	this.tbFileName.EntityBrief = "";
        	this.tbFileName.ErrorIfNull = null;
        	this.tbFileName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        	this.tbFileName.FormatInfo = null;
        	this.tbFileName.FormatString = "";
        	this.tbFileName.FormattingEnabled = true;
        	this.tbFileName.GroupEnabled = null;
        	this.tbFileName.IntegralHeight = true;
        	this.tbFileName.ItemHeight = 18;
        	this.tbFileName.Location = new System.Drawing.Point(9, 147);
        	this.tbFileName.MaxDropDownItems = 50;
        	this.tbFileName.MaxLength = 0;
        	this.tbFileName.MSQL = "";
        	this.tbFileName.Name = "tbFileName";
        	this.tbFileName.ObjectID = "";
        	this.tbFileName.ObjectMaxCount = 0;
        	this.tbFileName.ObjectOrderBy = "";
        	this.tbFileName.ObjRef = null;
        	this.tbFileName.OuterWHERE = null;
        	this.tbFileName.ReadOnly = false;
        	this.tbFileName.SaveParam = false;
        	this.tbFileName.SaveType = null;        
        	this.tbFileName.SelectedItem = null;
        	this.tbFileName.SelectedText = "";
        	this.tbFileName.SelectedValue = null;
        	this.tbFileName.SelectionLength = 0;
        	this.tbFileName.SelectionStart = 0;
        	this.tbFileName.Size = new System.Drawing.Size(448, 26);
        	this.tbFileName.Sorted = false;
        	this.tbFileName.SQL = "";
        	this.tbFileName.TabIndex = 24;
        	this.tbFileName.TextAdditional = null;
        	this.tbFileName.ValueHistoryInItems = false;
        	this.tbFileName.ValueMember = "";
        	this.tbFileName.СustomQuery = "";
        	this.tbFileName.DeleteClick += new System.EventHandler(this.tbFileName_DeleteClick);
        	this.tbFileName.EditClick += new System.EventHandler(this.tbFileName_EditClick);
        	// 
        	// tbFormat
        	// 
        	this.tbFormat.AttrBrief = null;
        	this.tbFormat.AttrBriefLookup = null;
        	this.tbFormat.BackColor = System.Drawing.SystemColors.Info;
        	this.tbFormat.ContextMenuEnabled = true;
        	this.tbFormat.ErrorIfNull = null;
        	this.tbFormat.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbFormat.FormattingEnabled = true;
        	this.tbFormat.GroupEnabled = null;
        	this.tbFormat.Items.AddRange(new object[] {
			"XLS",
			"XLSX",
			"DOC",
			"DOCX"});
        	this.tbFormat.ListInvalidChars = null;
        	this.tbFormat.ListValidChars = null;
        	this.tbFormat.Location = new System.Drawing.Point(287, 80);
        	this.tbFormat.Name = "tbFormat";
        	this.tbFormat.Obj = null;
        	this.tbFormat.ObjectID = "";
        	this.tbFormat.ObjectRef = null;
        	this.tbFormat.ObjRef = null;
        	this.tbFormat.ReadOnly = true;
        	this.tbFormat.RegExChars = null;
        	this.tbFormat.SaveParam = false;
        	this.tbFormat.SaveType = null;
        	this.tbFormat.SaveValueHistory = false;
        	this.tbFormat.Size = new System.Drawing.Size(167, 25);
        	this.tbFormat.TabIndex = 25;
        	this.tbFormat.Text2 = null;
        	this.tbFormat.ValueHistoryInItems = false;
        	// 
        	// labelFBA1
        	// 
        	this.labelFBA1.AutoSize = true;
        	this.labelFBA1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.labelFBA1.Location = new System.Drawing.Point(284, 59);
        	this.labelFBA1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.labelFBA1.Name = "labelFBA1";
        	this.labelFBA1.Size = new System.Drawing.Size(55, 17);
        	this.labelFBA1.StarColor = System.Drawing.Color.Crimson;
        	this.labelFBA1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.labelFBA1.StarOffsetX = 2;
        	this.labelFBA1.StarOffsetY = 0;
        	this.labelFBA1.StarShow = false;
        	this.labelFBA1.StarText = "*";
        	this.labelFBA1.TabIndex = 26;
        	this.labelFBA1.Text = "Format";
        	// 
        	// tbComment
        	// 
        	this.tbComment.AttrBrief = "Main1.Комментарий";
        	this.tbComment.AttrBriefLookup = null;
        	this.tbComment.BackColor = System.Drawing.SystemColors.Info;
        	this.tbComment.ErrorIfNull = null;
        	this.tbComment.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbComment.GroupEnabled = null;
        	this.tbComment.ListInvalidChars = null;
        	this.tbComment.ListValidChars = null;
        	this.tbComment.Location = new System.Drawing.Point(9, 196);
        	this.tbComment.Multiline = true;
        	this.tbComment.Name = "tbComment";
        	this.tbComment.ObjectRef = null;
        	this.tbComment.RegExChars = null;
        	this.tbComment.SaveParam = false;
        	this.tbComment.SaveValueHistory = false;
        	this.tbComment.Size = new System.Drawing.Size(448, 84);
        	this.tbComment.TabIndex = 39;
        	this.tbComment.Text2 = null;
        	this.tbComment.WordWrap = false;
        	// 
        	// tbName
        	// 
        	this.tbName.AttrBrief = "Main1.Имя";
        	this.tbName.AttrBriefLookup = null;
        	this.tbName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbName.ErrorIfNull = null;
        	this.tbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbName.GroupEnabled = null;
        	this.tbName.ListInvalidChars = null;
        	this.tbName.ListValidChars = null;
        	this.tbName.Location = new System.Drawing.Point(12, 22);
        	this.tbName.Name = "tbName";
        	this.tbName.ObjectRef = null;
        	this.tbName.RegExChars = null;
        	this.tbName.SaveParam = false;
        	this.tbName.SaveValueHistory = false;
        	this.tbName.Size = new System.Drawing.Size(442, 25);
        	this.tbName.TabIndex = 40;
        	this.tbName.Text2 = null;
        	this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
        	// 
        	// tbBrief
        	// 
        	this.tbBrief.AttrBrief = "Main1.Сокр";
        	this.tbBrief.AttrBriefLookup = null;
        	this.tbBrief.BackColor = System.Drawing.SystemColors.Info;
        	this.tbBrief.ErrorIfNull = null;
        	this.tbBrief.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbBrief.GroupEnabled = null;
        	this.tbBrief.ListInvalidChars = null;
        	this.tbBrief.ListValidChars = null;
        	this.tbBrief.Location = new System.Drawing.Point(9, 79);
        	this.tbBrief.Name = "tbBrief";
        	this.tbBrief.ObjectRef = null;
        	this.tbBrief.RegExChars = null;
        	this.tbBrief.SaveParam = false;
        	this.tbBrief.SaveValueHistory = false;
        	this.tbBrief.Size = new System.Drawing.Size(269, 25);
        	this.tbBrief.TabIndex = 41;
        	this.tbBrief.Text2 = null;
        	// 
        	// FormReportProperty
        	// 
        	//this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(466, 327);
        	this.Controls.Add(this.tbBrief);
        	this.Controls.Add(this.tbName);
        	this.Controls.Add(this.tbComment);
        	this.Controls.Add(this.labelFBA1);
        	this.Controls.Add(this.tbFormat);
        	this.Controls.Add(this.tbFileName);
        	this.Controls.Add(this.lbFileName);
        	this.Controls.Add(this.lbBrief);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.lbComment);
        	this.Controls.Add(this.lbName);
        	this.Name = "FormReportProperty";
        	this.Text = "Report property";
        	this.panel1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private LabelFBA lbComment;
        private LabelFBA lbName;
        private LabelFBA lbBrief;
        private LabelFBA lbFileName;
        private EditFBA tbFileName;
        private ComboBoxFBA tbFormat;
        private LabelFBA labelFBA1;
        private TextBoxFBA tbComment;
        private TextBoxFBA tbName;
        private TextBoxFBA tbBrief;
    }
}