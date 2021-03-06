
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 17.12.2016
 * Время: 23:38
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace FBA
{
	partial class FormEnter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnter));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnOk = new System.Windows.Forms.Button();
			this.cbConnectionList = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lbCapsLock = new FBA.LabelFBA();
			this.lbConName = new FBA.LabelFBA();
			this.cbConnection = new FBA.ComboBoxFBA();
			this.tbUserLogin = new System.Windows.Forms.TextBox();
			this.lbUserLogin = new FBA.LabelFBA();
			this.tbUserPass = new System.Windows.Forms.TextBox();
			this.lbUserPass = new FBA.LabelFBA();
			this.label3 = new FBA.LabelFBA();
			this.pictureBox1 = new FBA.PictureBoxFBA();
			this.cbEnterMode = new FBA.ComboBoxFBA();
			this.lbEnterMode = new FBA.LabelFBA();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnOk);
			this.panel1.Controls.Add(this.cbConnectionList);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 217);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(392, 41);
			this.panel1.TabIndex = 3;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnOk.Image = global::FBA.Resource.OK_24;
			this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOk.Location = new System.Drawing.Point(276, 4);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(112, 33);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "  Ок";
			this.btnOk.UseVisualStyleBackColor = false;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// cbConnectionList
			// 
			this.cbConnectionList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbConnectionList.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbConnectionList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cbConnectionList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbConnectionList.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cbConnectionList.Image = global::FBA.Resource.Connection_24;
			this.cbConnectionList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cbConnectionList.Location = new System.Drawing.Point(26, 4);
			this.cbConnectionList.Margin = new System.Windows.Forms.Padding(4);
			this.cbConnectionList.Name = "cbConnectionList";
			this.cbConnectionList.Size = new System.Drawing.Size(132, 33);
			this.cbConnectionList.TabIndex = 14;
			this.cbConnectionList.Text = "Connections";
			this.cbConnectionList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbConnectionList.UseVisualStyleBackColor = false;
			this.cbConnectionList.CheckedChanged += new System.EventHandler(this.CbConnectionListCheckedChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCancel.Image = global::FBA.Resource.Cancel_24;
			this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new System.Drawing.Point(161, 4);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 33);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel    ";
			this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// lbCapsLock
			// 
			this.lbCapsLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbCapsLock.BackColor = System.Drawing.Color.Transparent;
			this.lbCapsLock.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbCapsLock.ForeColor = System.Drawing.Color.SeaShell;
			this.lbCapsLock.Location = new System.Drawing.Point(205, 194);
			this.lbCapsLock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbCapsLock.Name = "lbCapsLock";
			this.lbCapsLock.Size = new System.Drawing.Size(183, 17);
			this.lbCapsLock.StarColor = System.Drawing.Color.Crimson;
			this.lbCapsLock.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbCapsLock.StarOffsetX = 2;
			this.lbCapsLock.StarOffsetY = 0;
			this.lbCapsLock.StarShow = false;
			this.lbCapsLock.StarText = "*";
			this.lbCapsLock.TabIndex = 2;
			this.lbCapsLock.Text = "Caps Lock off";
			this.lbCapsLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbConName
			// 
			this.lbConName.BackColor = System.Drawing.Color.Transparent;
			this.lbConName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbConName.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbConName.Location = new System.Drawing.Point(8, 80);
			this.lbConName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbConName.Name = "lbConName";
			this.lbConName.Size = new System.Drawing.Size(195, 30);
			this.lbConName.StarColor = System.Drawing.Color.Crimson;
			this.lbConName.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbConName.StarOffsetX = 2;
			this.lbConName.StarOffsetY = 0;
			this.lbConName.StarShow = false;
			this.lbConName.StarText = "*";
			this.lbConName.TabIndex = 9;
			this.lbConName.Text = "Connection name:";
			// 
			// cbConnection
			// 
			this.cbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.cbConnection.AttrBrief = null;
			this.cbConnection.AttrBriefLookup = null;
			this.cbConnection.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cbConnection.ContextMenuEnabled = true;
			this.cbConnection.DefaultTextGrayFont = null;
			this.cbConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbConnection.ErrorIfNull = null;
			this.cbConnection.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbConnection.FormattingEnabled = true;
			this.cbConnection.GroupEnabled = null;
			this.cbConnection.IntegralHeight = false;
			this.cbConnection.ListInvalidChars = null;
			this.cbConnection.ListValidChars = null;
			this.cbConnection.Location = new System.Drawing.Point(151, 77);
			this.cbConnection.Margin = new System.Windows.Forms.Padding(4);
			this.cbConnection.MaxDropDownItems = 10;
			this.cbConnection.Name = "cbConnection";
			this.cbConnection.Obj = null;
			this.cbConnection.ObjectID = "";
			this.cbConnection.ObjectRef = null;
			this.cbConnection.ObjRef = null;
			this.cbConnection.ReadOnly = false;
			this.cbConnection.RegExChars = null;
			this.cbConnection.SaveParam = false;
			this.cbConnection.SaveType = null;
			this.cbConnection.SaveValueHistory = false;
			this.cbConnection.Size = new System.Drawing.Size(237, 25);
			this.cbConnection.TabIndex = 12;
			this.cbConnection.Text2 = null;
			this.cbConnection.ValueHistoryInItems = false;
			this.cbConnection.SelectedIndexChanged += new System.EventHandler(this.CbConnectionSelectedIndexChanged);
			// 
			// tbUserLogin
			// 
			this.tbUserLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbUserLogin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tbUserLogin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUserLogin.Location = new System.Drawing.Point(151, 135);
			this.tbUserLogin.Margin = new System.Windows.Forms.Padding(4);
			this.tbUserLogin.Name = "tbUserLogin";
			this.tbUserLogin.Size = new System.Drawing.Size(237, 25);
			this.tbUserLogin.TabIndex = 25;
			// 
			// lbUserLogin
			// 
			this.lbUserLogin.BackColor = System.Drawing.Color.Transparent;
			this.lbUserLogin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbUserLogin.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbUserLogin.Location = new System.Drawing.Point(8, 138);
			this.lbUserLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbUserLogin.Name = "lbUserLogin";
			this.lbUserLogin.Size = new System.Drawing.Size(106, 30);
			this.lbUserLogin.StarColor = System.Drawing.Color.Crimson;
			this.lbUserLogin.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbUserLogin.StarOffsetX = 2;
			this.lbUserLogin.StarOffsetY = 0;
			this.lbUserLogin.StarShow = false;
			this.lbUserLogin.StarText = "*";
			this.lbUserLogin.TabIndex = 23;
			this.lbUserLogin.Text = "User login:";
			// 
			// tbUserPass
			// 
			this.tbUserPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbUserPass.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tbUserPass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUserPass.Location = new System.Drawing.Point(151, 165);
			this.tbUserPass.Margin = new System.Windows.Forms.Padding(4);
			this.tbUserPass.Name = "tbUserPass";
			this.tbUserPass.PasswordChar = '*';
			this.tbUserPass.Size = new System.Drawing.Size(237, 25);
			this.tbUserPass.TabIndex = 30;
			// 
			// lbUserPass
			// 
			this.lbUserPass.BackColor = System.Drawing.Color.Transparent;
			this.lbUserPass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbUserPass.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbUserPass.Location = new System.Drawing.Point(8, 165);
			this.lbUserPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbUserPass.Name = "lbUserPass";
			this.lbUserPass.Size = new System.Drawing.Size(106, 30);
			this.lbUserPass.StarColor = System.Drawing.Color.Crimson;
			this.lbUserPass.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbUserPass.StarOffsetX = 2;
			this.lbUserPass.StarOffsetY = 0;
			this.lbUserPass.StarShow = false;
			this.lbUserPass.StarText = "*";
			this.lbUserPass.TabIndex = 29;
			this.lbUserPass.Text = "User pass:";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.DarkBlue;
			this.label3.Location = new System.Drawing.Point(97, 18);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(291, 35);
			this.label3.StarColor = System.Drawing.Color.Crimson;
			this.label3.StarFont = new System.Drawing.Font("Arial", 20F);
			this.label3.StarOffsetX = 2;
			this.label3.StarOffsetY = 0;
			this.label3.StarShow = false;
			this.label3.StarText = "*";
			this.label3.TabIndex = 31;
			this.label3.Text = "Business application forms";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.ErrorImage = null;
			this.pictureBox1.Image = global::FBA.Resource.ruby_48;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 63);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 32;
			this.pictureBox1.TabStop = false;
			// 
			// cbEnterMode
			// 
			this.cbEnterMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.cbEnterMode.AttrBrief = null;
			this.cbEnterMode.AttrBriefLookup = null;
			this.cbEnterMode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cbEnterMode.ContextMenuEnabled = true;
			this.cbEnterMode.DefaultTextGrayFont = null;
			this.cbEnterMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEnterMode.ErrorIfNull = null;
			this.cbEnterMode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbEnterMode.FormattingEnabled = true;
			this.cbEnterMode.GroupEnabled = null;
			this.cbEnterMode.IntegralHeight = false;
			this.cbEnterMode.Items.AddRange(new object[] {
			"Work program mode",
			"Test program mode",
			"Develop program mode"});
			this.cbEnterMode.ListInvalidChars = null;
			this.cbEnterMode.ListValidChars = null;
			this.cbEnterMode.Location = new System.Drawing.Point(151, 106);
			this.cbEnterMode.Margin = new System.Windows.Forms.Padding(4);
			this.cbEnterMode.MaxDropDownItems = 10;
			this.cbEnterMode.Name = "cbEnterMode";
			this.cbEnterMode.Obj = null;
			this.cbEnterMode.ObjectID = "";
			this.cbEnterMode.ObjectRef = null;
			this.cbEnterMode.ObjRef = null;
			this.cbEnterMode.ReadOnly = false;
			this.cbEnterMode.RegExChars = null;
			this.cbEnterMode.SaveParam = false;
			this.cbEnterMode.SaveType = null;
			this.cbEnterMode.SaveValueHistory = false;
			this.cbEnterMode.Size = new System.Drawing.Size(237, 25);
			this.cbEnterMode.TabIndex = 36;
			this.cbEnterMode.Text2 = null;
			this.cbEnterMode.ValueHistoryInItems = false;
			// 
			// lbEnterMode
			// 
			this.lbEnterMode.BackColor = System.Drawing.Color.Transparent;
			this.lbEnterMode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbEnterMode.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbEnterMode.Location = new System.Drawing.Point(8, 109);
			this.lbEnterMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbEnterMode.Name = "lbEnterMode";
			this.lbEnterMode.Size = new System.Drawing.Size(96, 30);
			this.lbEnterMode.StarColor = System.Drawing.Color.Crimson;
			this.lbEnterMode.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbEnterMode.StarOffsetX = 2;
			this.lbEnterMode.StarOffsetY = 0;
			this.lbEnterMode.StarShow = false;
			this.lbEnterMode.StarText = "*";
			this.lbEnterMode.TabIndex = 35;
			this.lbEnterMode.Text = "Enter mode:";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// FormEnter
			// 
			this.BackColor = System.Drawing.SystemColors.Highlight;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(392, 258);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lbEnterMode);
			this.Controls.Add(this.lbUserLogin);
			this.Controls.Add(this.lbCapsLock);
			this.Controls.Add(this.cbConnection);
			this.Controls.Add(this.cbEnterMode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbUserPass);
			this.Controls.Add(this.lbUserPass);
			this.Controls.Add(this.tbUserLogin);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lbConName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEnter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FBA System";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEnterFormClosing);
			this.Shown += new System.EventHandler(this.FormEnter_Shown);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}		 
		
		private FBA.LabelFBA lbUserPass;
		private System.Windows.Forms.TextBox tbUserPass;
		private FBA.LabelFBA lbUserLogin;
		private System.Windows.Forms.TextBox tbUserLogin;
		private System.Windows.Forms.CheckBox cbConnectionList;
		private FBA.ComboBoxFBA cbConnection;
		private FBA.LabelFBA lbConName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel panel1;		
		private FBA.LabelFBA label3;
		private FBA.PictureBoxFBA pictureBox1;
		private FBA.ComboBoxFBA cbEnterMode;
		private FBA.LabelFBA lbEnterMode;
		private System.Windows.Forms.Timer timer1;
		private FBA.LabelFBA lbCapsLock;
	}
}
