
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 17.12.2017
 * Время: 3:01
 */
namespace FBA
{
    partial class FormTable
    {       
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private FBA.PictureBoxFBA pictureBox1;
        private FBA.LabelFBA label1;
        private FBA.LabelFBA label3;
        private FBA.TextBoxFBA tbID;
        private FBA.LabelFBA label2;
        private FBA.ComboBoxFBA tbIDFieldName;
        private FBA.LabelFBA label4;
        private FBA.ComboBoxFBA tbTypeStr;
        private FBA.LabelFBA label5;
        private FBA.ComboBoxFBA tbName;
         
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTable));
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.pictureBox1 = new FBA.PictureBoxFBA();
        	this.label1 = new FBA.LabelFBA();
        	this.label3 = new FBA.LabelFBA();
        	this.tbID = new FBA.TextBoxFBA();
        	this.label2 = new FBA.LabelFBA();
        	this.tbIDFieldName = new FBA.ComboBoxFBA();
        	this.label4 = new FBA.LabelFBA();
        	this.tbTypeStr = new FBA.ComboBoxFBA();
        	this.label5 = new FBA.LabelFBA();
        	this.tbName = new FBA.ComboBoxFBA();
        	this.panel2.SuspendLayout();
        	this.panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.btnCancel);
        	this.panel2.Controls.Add(this.btnOk);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel2.Location = new System.Drawing.Point(0, 181);
        	this.panel2.Margin = new System.Windows.Forms.Padding(4);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(393, 42);
        	this.panel2.TabIndex = 4;
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(158, 5);
        	this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
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
        	this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(275, 5);
        	this.btnOk.Margin = new System.Windows.Forms.Padding(4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 1;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.pictureBox1);
        	this.panel1.Controls.Add(this.label1);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(393, 38);
        	this.panel1.TabIndex = 5;
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.ErrorImage = null;
        	this.pictureBox1.Image = global::FBA.Resource.Grid_32;
        	this.pictureBox1.InitialImage = null;
        	this.pictureBox1.Location = new System.Drawing.Point(7, 4);
        	this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(32, 32);
        	this.pictureBox1.TabIndex = 1;
        	this.pictureBox1.TabStop = false;
        	// 
        	// label1
        	// 
        	this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(46, 7);
        	this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(75, 23);
        	this.label1.StarColor = System.Drawing.Color.Crimson;
        	this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label1.StarOffsetX = 2;
        	this.label1.StarOffsetY = 0;
        	this.label1.StarShow = false;
        	this.label1.StarText = "*";
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Table";
        	// 
        	// label3
        	// 
        	this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.Location = new System.Drawing.Point(6, 77);
        	this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(72, 28);
        	this.label3.StarColor = System.Drawing.Color.Crimson;
        	this.label3.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label3.StarOffsetX = 2;
        	this.label3.StarOffsetY = 0;
        	this.label3.StarShow = true;
        	this.label3.StarText = "*";
        	this.label3.TabIndex = 27;
        	this.label3.Text = "Name";
        	// 
        	// tbID
        	// 
        	this.tbID.AttrBrief = "Main1.ID";
        	this.tbID.AttrBriefLookup = null;
        	this.tbID.BackColor = System.Drawing.SystemColors.Info;
        	this.tbID.Enabled = false;
        	this.tbID.ErrorIfNull = null;
        	this.tbID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbID.GroupEnabled = null;
        	this.tbID.ListInvalidChars = null;
        	this.tbID.ListValidChars = "";
        	this.tbID.Location = new System.Drawing.Point(86, 42);
        	this.tbID.Margin = new System.Windows.Forms.Padding(4);
        	this.tbID.Name = "tbID";
        	this.tbID.ObjectRef = null;
        	this.tbID.RegExChars = null;
        	this.tbID.SaveParam = false;
        	this.tbID.SaveValueHistory = false;
        	this.tbID.Size = new System.Drawing.Size(100, 25);
        	this.tbID.TabIndex = 26;
        	this.tbID.Text2 = null;
        	// 
        	// label2
        	// 
        	this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.Location = new System.Drawing.Point(6, 48);
        	this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(48, 23);
        	this.label2.StarColor = System.Drawing.Color.Crimson;
        	this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label2.StarOffsetX = 2;
        	this.label2.StarOffsetY = 0;
        	this.label2.StarShow = false;
        	this.label2.StarText = "*";
        	this.label2.TabIndex = 25;
        	this.label2.Text = "ID";
        	// 
        	// tbIDFieldName
        	// 
        	this.tbIDFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbIDFieldName.AttrBrief = "Main1.IDFieldName";
        	this.tbIDFieldName.AttrBriefLookup = null;
        	this.tbIDFieldName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbIDFieldName.ContextMenuEnabled = true;
        	this.tbIDFieldName.ErrorIfNull = "Поле \"Field ID\" не заполнено!";
        	this.tbIDFieldName.FormattingEnabled = true;
        	this.tbIDFieldName.GroupEnabled = null;
        	this.tbIDFieldName.ListInvalidChars = null;
        	this.tbIDFieldName.ListValidChars = null;
        	this.tbIDFieldName.Location = new System.Drawing.Point(86, 104);
        	this.tbIDFieldName.Margin = new System.Windows.Forms.Padding(4);
        	this.tbIDFieldName.Name = "tbIDFieldName";
        	this.tbIDFieldName.Obj = null;
        	this.tbIDFieldName.ObjectID = "";
        	this.tbIDFieldName.ObjectRef = null;
        	this.tbIDFieldName.ObjRef = null;
        	this.tbIDFieldName.ReadOnly = false;
        	this.tbIDFieldName.RegExChars = null;
        	this.tbIDFieldName.SaveParam = false;
        	this.tbIDFieldName.SaveType = null;
        	this.tbIDFieldName.SaveValueHistory = false;
        	this.tbIDFieldName.Size = new System.Drawing.Size(299, 25);
        	this.tbIDFieldName.TabIndex = 29;
        	this.tbIDFieldName.Text2 = null;
        	this.tbIDFieldName.ValueHistoryInItems = false;
        	// 
        	// label4
        	// 
        	this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label4.Location = new System.Drawing.Point(6, 108);
        	this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(72, 28);
        	this.label4.StarColor = System.Drawing.Color.Crimson;
        	this.label4.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label4.StarOffsetX = 2;
        	this.label4.StarOffsetY = 0;
        	this.label4.StarShow = true;
        	this.label4.StarText = "*";
        	this.label4.TabIndex = 30;
        	this.label4.Text = "Field ID";
        	// 
        	// tbTypeStr
        	// 
        	this.tbTypeStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbTypeStr.AttrBrief = null;
        	this.tbTypeStr.AttrBriefLookup = null;
        	this.tbTypeStr.BackColor = System.Drawing.SystemColors.Info;
        	this.tbTypeStr.ContextMenuEnabled = true;
        	this.tbTypeStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.tbTypeStr.ErrorIfNull = "Поле \"Type\" не заполнено!";
        	this.tbTypeStr.FormattingEnabled = true;
        	this.tbTypeStr.GroupEnabled = null;
        	this.tbTypeStr.Items.AddRange(new object[] {
			"Main",
			"Historical"});
        	this.tbTypeStr.ListInvalidChars = null;
        	this.tbTypeStr.ListValidChars = null;
        	this.tbTypeStr.Location = new System.Drawing.Point(86, 135);
        	this.tbTypeStr.Margin = new System.Windows.Forms.Padding(4);
        	this.tbTypeStr.Name = "tbTypeStr";
        	this.tbTypeStr.Obj = null;
        	this.tbTypeStr.ObjectID = "";
        	this.tbTypeStr.ObjectRef = null;
        	this.tbTypeStr.ObjRef = null;
        	this.tbTypeStr.ReadOnly = false;
        	this.tbTypeStr.RegExChars = null;
        	this.tbTypeStr.SaveParam = false;
        	this.tbTypeStr.SaveType = null;
        	this.tbTypeStr.SaveValueHistory = false;
        	this.tbTypeStr.Size = new System.Drawing.Size(299, 25);
        	this.tbTypeStr.TabIndex = 31;
        	this.tbTypeStr.Text2 = null;
        	this.tbTypeStr.ValueHistoryInItems = false;
        	// 
        	// label5
        	// 
        	this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label5.Location = new System.Drawing.Point(6, 137);
        	this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(72, 28);
        	this.label5.StarColor = System.Drawing.Color.Crimson;
        	this.label5.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label5.StarOffsetX = 2;
        	this.label5.StarOffsetY = 0;
        	this.label5.StarShow = true;
        	this.label5.StarText = "*";
        	this.label5.TabIndex = 32;
        	this.label5.Text = "Type";
        	// 
        	// tbName
        	// 
        	this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbName.AttrBrief = "Main1.Name";
        	this.tbName.AttrBriefLookup = null;
        	this.tbName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbName.ContextMenuEnabled = true;
        	this.tbName.ErrorIfNull = "Поле \"Name\" не заполнено!";
        	this.tbName.FormattingEnabled = true;
        	this.tbName.GroupEnabled = null;
        	this.tbName.ListInvalidChars = null;
        	this.tbName.ListValidChars = null;
        	this.tbName.Location = new System.Drawing.Point(86, 73);
        	this.tbName.Margin = new System.Windows.Forms.Padding(4);
        	this.tbName.Name = "tbName";
        	this.tbName.Obj = null;
        	this.tbName.ObjectID = "";
        	this.tbName.ObjectRef = null;
        	this.tbName.ObjRef = null;
        	this.tbName.ReadOnly = false;
        	this.tbName.RegExChars = null;
        	this.tbName.SaveParam = false;
        	this.tbName.SaveType = null;
        	this.tbName.SaveValueHistory = false;
        	this.tbName.Size = new System.Drawing.Size(299, 25);
        	this.tbName.TabIndex = 39;
        	this.tbName.Text2 = null;
        	this.tbName.ValueHistoryInItems = false;
        	this.tbName.Leave += new System.EventHandler(this.TbNameLeave);
        	// 
        	// FormTable
        	// 
        	//this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
        	//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(393, 223);
        	this.Controls.Add(this.tbName);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.tbTypeStr);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.tbIDFieldName);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.tbID);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.panel2);
        	this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.FormNumber = 1;
        	this.FormUsual = true;
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormTable";
        	this.QueryText = new string[] {
		"--(SectionBegin TableDelete) ",
		"",
		"   SELECT ",
		"    --FK.CONSTRAINT_NAME as ForeignKey, ",
		"      --FK.TABLE_CATALOG as FROM_TABLE_CATALOG,",
		"      --FK.TABLE_SCHEMA  as FROM_TABLE_SCHEMA,",
		"      FK.TABLE_NAME    as FROM_TABLE_NAME,",
		"      FK.COLUMN_NAME   as FROM_COLUMN_NAME,",
		"      --PK.TABLE_CATALOG as TO_TABLE_CATALOG,",
		"      --PK.TABLE_SCHEMA  as TO_TABLE_SCHEMA,",
		"      PK.TABLE_NAME    as TO_TABLE_NAME,",
		"      PK.COLUMN_NAME   as TO_COLUMN_NAME",
		"     -- INTO #Tabl1",
		"    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE PK",
		resources.GetString("$this.QueryText"),
		resources.GetString("$this.QueryText1"),
		"    WHERE PK.TABLE_NAME = \'TableNameAttr\'",
		"    ORDER BY FK.CONSTRAINT_NAME, PK.ORDINAL_POSITION",
		"  ",
		"--(SectionEnd TableDelete) "};
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Table";
        	this.Shown += new System.EventHandler(this.FormTable_Shown);
        	this.panel2.ResumeLayout(false);
        	this.panel1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
    }
}
