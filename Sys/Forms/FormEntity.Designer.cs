
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 16.08.2017
 * Время: 16:30
 * 
 
 */
namespace FBA
{
    partial class FormEntity
    {        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private FBA.PictureBoxFBA pictureBox1;
        private FBA.LabelFBA label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private FBA.LabelFBA groupBox2;         
        private FBA.LabelFBA label3;          
        private FBA.LabelFBA label2;
        private FBA.TextBoxFBA tbID;
        private FBA.TextBoxFBA tbName;
        private FBA.TextBoxFBA tbBrief;
        private FBA.TextBoxFBA textBox6;        
        private FBA.LabelFBA label4;
        private FBA.CheckBoxFBA cbSystem;
        private FBA.CheckBoxFBA cbAccObj;
        private FBA.CheckBoxFBA cbTree;
        private FBA.CheckBoxFBA cbDiv;
        private FBA.CheckBoxFBA cbCounter;
        private FBA.CheckBoxFBA cbProtocol;
        
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntity));
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.pictureBox1 = new FBA.PictureBoxFBA();
        	this.label1 = new FBA.LabelFBA();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.groupBox2 = new FBA.LabelFBA();
        	this.textBox6 = new FBA.TextBoxFBA();
        	this.label3 = new FBA.LabelFBA();
        	this.label2 = new FBA.LabelFBA();
        	this.label4 = new FBA.LabelFBA();
        	this.tbID = new FBA.TextBoxFBA();
        	this.tbBrief = new FBA.TextBoxFBA();
        	this.tbName = new FBA.TextBoxFBA();
        	this.cbSystem = new FBA.CheckBoxFBA();
        	this.cbAccObj = new FBA.CheckBoxFBA();
        	this.cbTree = new FBA.CheckBoxFBA();
        	this.cbDiv = new FBA.CheckBoxFBA();
        	this.cbCounter = new FBA.CheckBoxFBA();
        	this.cbProtocol = new FBA.CheckBoxFBA();
        	this.panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.panel2.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.pictureBox1);
        	this.panel1.Controls.Add(this.label1);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(439, 38);
        	this.panel1.TabIndex = 0;
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        	this.pictureBox1.Location = new System.Drawing.Point(12, 4);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(39, 31);
        	this.pictureBox1.TabIndex = 1;
        	this.pictureBox1.TabStop = false;
        	// 
        	// label1
        	// 
        	this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(57, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(135, 23);
        	this.label1.StarColor = System.Drawing.Color.Crimson;
        	this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label1.StarOffsetX = 2;
        	this.label1.StarOffsetY = 0;
        	this.label1.StarShow = false;
        	this.label1.StarText = "*";
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Entity";
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.btnCancel);
        	this.panel2.Controls.Add(this.btnOk);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel2.Location = new System.Drawing.Point(0, 430);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(439, 41);
        	this.panel2.TabIndex = 3;
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(202, 4);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(112, 33);
        	this.btnCancel.TabIndex = 2;
        	this.btnCancel.Text = "    Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        	// 
        	// btnOk
        	// 
        	this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(320, 4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 1;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.groupBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.groupBox2.Location = new System.Drawing.Point(0, 324);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(447, 59);
        	this.groupBox2.StarColor = System.Drawing.Color.Crimson;
        	this.groupBox2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.groupBox2.StarOffsetX = 2;
        	this.groupBox2.StarOffsetY = 0;
        	this.groupBox2.StarShow = true;
        	this.groupBox2.StarText = "*";
        	this.groupBox2.TabIndex = 20;
        	this.groupBox2.Text = " Comment ";
        	this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
        	// 
        	// textBox6
        	// 
        	this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBox6.AttrBrief = "Main1.Comment";
        	this.textBox6.AttrBriefLookup = null;
        	this.textBox6.BackColor = System.Drawing.SystemColors.Info;
        	this.textBox6.ErrorIfNull = "Поле \"Comment\" не заполнено!";
        	this.textBox6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.textBox6.GroupEnabled = null;
        	this.textBox6.ListInvalidChars = null;
        	this.textBox6.ListValidChars = null;
        	this.textBox6.Location = new System.Drawing.Point(8, 347);
        	this.textBox6.Multiline = true;
        	this.textBox6.Name = "textBox6";
        	this.textBox6.ObjectRef = null;
        	this.textBox6.RegExChars = null;
        	this.textBox6.SaveParam = false;
        	this.textBox6.SaveValueHistory = false;
        	this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.textBox6.Size = new System.Drawing.Size(424, 75);
        	this.textBox6.TabIndex = 0;
        	this.textBox6.Text2 = null;
        	// 
        	// label3
        	// 
        	this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.Location = new System.Drawing.Point(13, 79);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(100, 23);
        	this.label3.StarColor = System.Drawing.Color.Crimson;
        	this.label3.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label3.StarOffsetX = 2;
        	this.label3.StarOffsetY = 0;
        	this.label3.StarShow = true;
        	this.label3.StarText = "*";
        	this.label3.TabIndex = 23;
        	this.label3.Text = "Name";
        	// 
        	// label2
        	// 
        	this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.Location = new System.Drawing.Point(13, 47);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(47, 23);
        	this.label2.StarColor = System.Drawing.Color.Crimson;
        	this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label2.StarOffsetX = 2;
        	this.label2.StarOffsetY = 0;
        	this.label2.StarShow = false;
        	this.label2.StarText = "*";
        	this.label2.TabIndex = 21;
        	this.label2.Text = "ID";
        	// 
        	// label4
        	// 
        	this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label4.Location = new System.Drawing.Point(13, 114);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(100, 23);
        	this.label4.StarColor = System.Drawing.Color.Crimson;
        	this.label4.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label4.StarOffsetX = 2;
        	this.label4.StarOffsetY = 0;
        	this.label4.StarShow = true;
        	this.label4.StarText = "*";
        	this.label4.TabIndex = 25;
        	this.label4.Text = "Brief";
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
        	this.tbID.ListValidChars = "DIGITS";
        	this.tbID.Location = new System.Drawing.Point(116, 47);
        	this.tbID.Name = "tbID";
        	this.tbID.ObjectRef = null;
        	this.tbID.RegExChars = null;
        	this.tbID.SaveParam = false;
        	this.tbID.SaveValueHistory = false;
        	this.tbID.Size = new System.Drawing.Size(100, 25);
        	this.tbID.TabIndex = 22;
        	this.tbID.Text2 = null;
        	// 
        	// tbBrief
        	// 
        	this.tbBrief.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbBrief.AttrBrief = "Main1.Brief";
        	this.tbBrief.AttrBriefLookup = null;
        	this.tbBrief.BackColor = System.Drawing.SystemColors.Info;
        	this.tbBrief.ErrorIfNull = "Поле \"Brief\" не заполнено!";
        	this.tbBrief.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbBrief.GroupEnabled = null;
        	this.tbBrief.ListInvalidChars = null;
        	this.tbBrief.ListValidChars = null;
        	this.tbBrief.Location = new System.Drawing.Point(116, 111);
        	this.tbBrief.Name = "tbBrief";
        	this.tbBrief.ObjectRef = null;
        	this.tbBrief.RegExChars = null;
        	this.tbBrief.SaveParam = false;
        	this.tbBrief.SaveValueHistory = false;
        	this.tbBrief.Size = new System.Drawing.Size(315, 25);
        	this.tbBrief.TabIndex = 26;
        	this.tbBrief.Text2 = null;
        	this.tbBrief.Enter += new System.EventHandler(this.TbBrief_Enter);
        	// 
        	// tbName
        	// 
        	this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbName.AttrBrief = "Main1.Name";
        	this.tbName.AttrBriefLookup = null;
        	this.tbName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbName.ErrorIfNull = "Поле \"Name\" не заполнено!";
        	this.tbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbName.GroupEnabled = null;
        	this.tbName.ListInvalidChars = null;
        	this.tbName.ListValidChars = "";
        	this.tbName.Location = new System.Drawing.Point(116, 79);
        	this.tbName.Name = "tbName";
        	this.tbName.ObjectRef = null;
        	this.tbName.RegExChars = null;
        	this.tbName.SaveParam = false;
        	this.tbName.SaveValueHistory = false;
        	this.tbName.Size = new System.Drawing.Size(315, 25);
        	this.tbName.TabIndex = 24;
        	this.tbName.Text2 = null;
        	// 
        	// cbSystem
        	// 
        	this.cbSystem.AttrBrief = null;
        	this.cbSystem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbSystem.GroupEnabled = null;
        	this.cbSystem.Location = new System.Drawing.Point(12, 146);
        	this.cbSystem.Name = "cbSystem";
        	this.cbSystem.Obj = null;
        	this.cbSystem.ObjectRef = null;
        	this.cbSystem.SaveParam = false;
        	this.cbSystem.Size = new System.Drawing.Size(125, 24);
        	this.cbSystem.TabIndex = 27;
        	this.cbSystem.Text = "System";
        	this.cbSystem.UseVisualStyleBackColor = true;
        	this.cbSystem.CheckedChanged += new System.EventHandler(this.cbSystem_CheckedChanged);
        	// 
        	// cbAccObj
        	// 
        	this.cbAccObj.AttrBrief = null;
        	this.cbAccObj.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbAccObj.GroupEnabled = null;
        	this.cbAccObj.Location = new System.Drawing.Point(12, 174);
        	this.cbAccObj.Name = "cbAccObj";
        	this.cbAccObj.Obj = null;
        	this.cbAccObj.ObjectRef = null;
        	this.cbAccObj.SaveParam = false;
        	this.cbAccObj.Size = new System.Drawing.Size(161, 24);
        	this.cbAccObj.TabIndex = 28;
        	this.cbAccObj.Text = "Accounting object";
        	this.cbAccObj.UseVisualStyleBackColor = true;
        	this.cbAccObj.CheckedChanged += new System.EventHandler(this.cbSystem_CheckedChanged);
        	// 
        	// cbTree
        	// 
        	this.cbTree.AttrBrief = null;
        	this.cbTree.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbTree.GroupEnabled = null;
        	this.cbTree.Location = new System.Drawing.Point(12, 201);
        	this.cbTree.Name = "cbTree";
        	this.cbTree.Obj = null;
        	this.cbTree.ObjectRef = null;
        	this.cbTree.SaveParam = false;
        	this.cbTree.Size = new System.Drawing.Size(180, 24);
        	this.cbTree.TabIndex = 29;
        	this.cbTree.Text = "Tree";
        	this.cbTree.UseVisualStyleBackColor = true;
        	this.cbTree.CheckedChanged += new System.EventHandler(this.cbSystem_CheckedChanged);
        	// 
        	// cbDiv
        	// 
        	this.cbDiv.AttrBrief = null;
        	this.cbDiv.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbDiv.GroupEnabled = null;
        	this.cbDiv.Location = new System.Drawing.Point(12, 228);
        	this.cbDiv.Name = "cbDiv";
        	this.cbDiv.Obj = null;
        	this.cbDiv.ObjectRef = null;
        	this.cbDiv.SaveParam = false;
        	this.cbDiv.Size = new System.Drawing.Size(204, 24);
        	this.cbDiv.TabIndex = 30;
        	this.cbDiv.Text = "Divided into branches";
        	this.cbDiv.UseVisualStyleBackColor = true;
        	this.cbDiv.CheckedChanged += new System.EventHandler(this.cbSystem_CheckedChanged);
        	// 
        	// cbCounter
        	// 
        	this.cbCounter.AttrBrief = null;
        	this.cbCounter.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbCounter.GroupEnabled = null;
        	this.cbCounter.Location = new System.Drawing.Point(12, 256);
        	this.cbCounter.Name = "cbCounter";
        	this.cbCounter.Obj = null;
        	this.cbCounter.ObjectRef = null;
        	this.cbCounter.SaveParam = false;
        	this.cbCounter.Size = new System.Drawing.Size(228, 24);
        	this.cbCounter.TabIndex = 31;
        	this.cbCounter.Text = "Use the counter generic link";
        	this.cbCounter.UseVisualStyleBackColor = true;
        	this.cbCounter.CheckedChanged += new System.EventHandler(this.cbSystem_CheckedChanged);
        	// 
        	// cbProtocol
        	// 
        	this.cbProtocol.AttrBrief = null;
        	this.cbProtocol.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbProtocol.GroupEnabled = null;
        	this.cbProtocol.Location = new System.Drawing.Point(12, 286);
        	this.cbProtocol.Name = "cbProtocol";
        	this.cbProtocol.Obj = null;
        	this.cbProtocol.ObjectRef = null;
        	this.cbProtocol.SaveParam = false;
        	this.cbProtocol.Size = new System.Drawing.Size(248, 24);
        	this.cbProtocol.TabIndex = 32;
        	this.cbProtocol.Text = "Contains Protocol information";
        	this.cbProtocol.UseVisualStyleBackColor = true;
        	this.cbProtocol.CheckedChanged += new System.EventHandler(this.cbSystem_CheckedChanged);
        	// 
        	// FormEntity
        	// 
        	//this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(439, 471);
        	this.Controls.Add(this.textBox6);
        	this.Controls.Add(this.cbProtocol);
        	this.Controls.Add(this.cbCounter);
        	this.Controls.Add(this.cbDiv);
        	this.Controls.Add(this.cbTree);
        	this.Controls.Add(this.cbAccObj);
        	this.Controls.Add(this.cbSystem);
        	this.Controls.Add(this.tbBrief);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.tbName);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.tbID);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.groupBox2);
        	this.Controls.Add(this.panel2);
        	this.Controls.Add(this.panel1);
        	this.FormUsual = true;
        	this.Name = "FormEntity";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Entity";       
        	this.panel1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.panel2.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
    }
}
