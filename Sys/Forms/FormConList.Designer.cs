
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 12.01.2017
 * Время: 16:31
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace FBA
{
	partial class FormConList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnConnectionTest = new System.Windows.Forms.Button();
			this.tbDatabaseName = new System.Windows.Forms.TextBox();
			this.lbDatabaseName = new FBA.LabelFBA();
			this.tbServerName = new System.Windows.Forms.TextBox();
			this.lbServerName = new FBA.LabelFBA();
			this.cbType = new FBA.ComboBoxFBA();
			this.lbServerType = new FBA.LabelFBA();
			this.tbDatabasePass = new System.Windows.Forms.TextBox();
			this.tbDatabaseLogin = new System.Windows.Forms.TextBox();
			this.lbDatabasePass = new FBA.LabelFBA();
			this.lbDatabaseLogin = new FBA.LabelFBA();
			this.dgvConnectionList = new FBA.DataGridViewFBA();
			this.label1 = new FBA.LabelFBA();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.tbConnectionName = new System.Windows.Forms.TextBox();
			this.lbConnectionName = new FBA.LabelFBA();
			this.tbUserForm = new System.Windows.Forms.TextBox();
			this.lbUserForm = new FBA.LabelFBA();
			this.btnExample = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.lbUserLogin = new FBA.LabelFBA();
			this.tbUserLogin = new System.Windows.Forms.TextBox();
			this.tbUserPass = new System.Windows.Forms.TextBox();
			this.lbUserPass = new FBA.LabelFBA();
			this.cbWindowsLogin = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvConnectionList)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnConnectionTest
			// 
			this.btnConnectionTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConnectionTest.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnConnectionTest.Image = global::FBA.Resource.Test_24;
			this.btnConnectionTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnConnectionTest.Location = new System.Drawing.Point(435, 225);
			this.btnConnectionTest.Margin = new System.Windows.Forms.Padding(4);
			this.btnConnectionTest.Name = "btnConnectionTest";
			this.btnConnectionTest.Size = new System.Drawing.Size(161, 33);
			this.btnConnectionTest.TabIndex = 34;
			this.btnConnectionTest.Text = "Test connection  ";
			this.btnConnectionTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnConnectionTest.UseVisualStyleBackColor = true;
			this.btnConnectionTest.Click += new System.EventHandler(this.BtnConnectionTestClick);
			// 
			// tbDatabaseName
			// 
			this.tbDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbDatabaseName.BackColor = System.Drawing.SystemColors.Info;
			this.tbDatabaseName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDatabaseName.Location = new System.Drawing.Point(157, 313);
			this.tbDatabaseName.Margin = new System.Windows.Forms.Padding(4);
			this.tbDatabaseName.Name = "tbDatabaseName";
			this.tbDatabaseName.Size = new System.Drawing.Size(268, 25);
			this.tbDatabaseName.TabIndex = 33;
			// 
			// lbDatabaseName
			// 
			this.lbDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbDatabaseName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbDatabaseName.Location = new System.Drawing.Point(6, 316);
			this.lbDatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbDatabaseName.Name = "lbDatabaseName";
			this.lbDatabaseName.Size = new System.Drawing.Size(140, 17);
			this.lbDatabaseName.StarColor = System.Drawing.Color.Crimson;
			this.lbDatabaseName.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbDatabaseName.StarOffsetX = 2;
			this.lbDatabaseName.StarOffsetY = 0;
			this.lbDatabaseName.StarShow = false;
			this.lbDatabaseName.StarText = "*";
			this.lbDatabaseName.TabIndex = 32;
			this.lbDatabaseName.Text = "Database name:";
			// 
			// tbServerName
			// 
			this.tbServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbServerName.BackColor = System.Drawing.SystemColors.Info;
			this.tbServerName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbServerName.Location = new System.Drawing.Point(158, 252);
			this.tbServerName.Margin = new System.Windows.Forms.Padding(4);
			this.tbServerName.Name = "tbServerName";
			this.tbServerName.Size = new System.Drawing.Size(268, 25);
			this.tbServerName.TabIndex = 31;
			// 
			// lbServerName
			// 
			this.lbServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbServerName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbServerName.Location = new System.Drawing.Point(6, 255);
			this.lbServerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbServerName.Name = "lbServerName";
			this.lbServerName.Size = new System.Drawing.Size(150, 17);
			this.lbServerName.StarColor = System.Drawing.Color.Crimson;
			this.lbServerName.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbServerName.StarOffsetX = 2;
			this.lbServerName.StarOffsetY = 0;
			this.lbServerName.StarShow = true;
			this.lbServerName.StarText = "*";
			this.lbServerName.TabIndex = 30;
			this.lbServerName.Text = "Server Name or IP:";
			// 
			// cbType
			// 
			this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.cbType.AttrBrief = null;
			this.cbType.AttrBriefLookup = null;
			this.cbType.BackColor = System.Drawing.SystemColors.Info;
			this.cbType.ContextMenuEnabled = true;
			this.cbType.DefaultTextGrayFont = null;
			this.cbType.DisplayMember = "Name";
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.ErrorIfNull = null;
			this.cbType.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbType.FormattingEnabled = true;
			this.cbType.GroupEnabled = null;
			this.cbType.IntegralHeight = false;
			this.cbType.Items.AddRange(new object[] {
			"Postgre",
			"MSSQL",
			"SQLite",
			"ServerApp"});
			this.cbType.ListInvalidChars = null;
			this.cbType.ListValidChars = null;
			this.cbType.Location = new System.Drawing.Point(158, 193);
			this.cbType.Margin = new System.Windows.Forms.Padding(4);
			this.cbType.MaxDropDownItems = 10;
			this.cbType.Name = "cbType";
			this.cbType.Obj = null;
			this.cbType.ObjectID = "";
			this.cbType.ObjectRef = null;
			this.cbType.ObjRef = null;
			this.cbType.ReadOnly = false;
			this.cbType.RegExChars = null;
			this.cbType.SaveParam = false;
			this.cbType.SaveType = null;
			this.cbType.SaveValueHistory = false;
			this.cbType.Size = new System.Drawing.Size(269, 25);
			this.cbType.TabIndex = 29;
			this.cbType.Text2 = null;
			this.cbType.ValueHistoryInItems = false;
			this.cbType.ValueMember = "Name";
			this.cbType.SelectedIndexChanged += new System.EventHandler(this.CbTypeSelectedIndexChanged);
			// 
			// lbServerType
			// 
			this.lbServerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbServerType.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbServerType.Location = new System.Drawing.Point(6, 196);
			this.lbServerType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbServerType.Name = "lbServerType";
			this.lbServerType.Size = new System.Drawing.Size(113, 17);
			this.lbServerType.StarColor = System.Drawing.Color.Crimson;
			this.lbServerType.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbServerType.StarOffsetX = 2;
			this.lbServerType.StarOffsetY = 0;
			this.lbServerType.StarShow = true;
			this.lbServerType.StarText = "*";
			this.lbServerType.TabIndex = 28;
			this.lbServerType.Text = "Server type:";
			// 
			// tbDatabasePass
			// 
			this.tbDatabasePass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbDatabasePass.BackColor = System.Drawing.SystemColors.Info;
			this.tbDatabasePass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDatabasePass.Location = new System.Drawing.Point(157, 373);
			this.tbDatabasePass.Margin = new System.Windows.Forms.Padding(4);
			this.tbDatabasePass.Name = "tbDatabasePass";
			this.tbDatabasePass.PasswordChar = '*';
			this.tbDatabasePass.Size = new System.Drawing.Size(268, 25);
			this.tbDatabasePass.TabIndex = 25;
			// 
			// tbDatabaseLogin
			// 
			this.tbDatabaseLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbDatabaseLogin.BackColor = System.Drawing.SystemColors.Info;
			this.tbDatabaseLogin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbDatabaseLogin.Location = new System.Drawing.Point(157, 343);
			this.tbDatabaseLogin.Margin = new System.Windows.Forms.Padding(4);
			this.tbDatabaseLogin.Name = "tbDatabaseLogin";
			this.tbDatabaseLogin.PasswordChar = '*';
			this.tbDatabaseLogin.Size = new System.Drawing.Size(268, 25);
			this.tbDatabaseLogin.TabIndex = 24;
			// 
			// lbDatabasePass
			// 
			this.lbDatabasePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbDatabasePass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbDatabasePass.Location = new System.Drawing.Point(6, 376);
			this.lbDatabasePass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbDatabasePass.Name = "lbDatabasePass";
			this.lbDatabasePass.Size = new System.Drawing.Size(142, 17);
			this.lbDatabasePass.StarColor = System.Drawing.Color.Crimson;
			this.lbDatabasePass.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbDatabasePass.StarOffsetX = 2;
			this.lbDatabasePass.StarOffsetY = 0;
			this.lbDatabasePass.StarShow = false;
			this.lbDatabasePass.StarText = "*";
			this.lbDatabasePass.TabIndex = 23;
			this.lbDatabasePass.Text = "Database password:";
			// 
			// lbDatabaseLogin
			// 
			this.lbDatabaseLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbDatabaseLogin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbDatabaseLogin.Location = new System.Drawing.Point(6, 346);
			this.lbDatabaseLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbDatabaseLogin.Name = "lbDatabaseLogin";
			this.lbDatabaseLogin.Size = new System.Drawing.Size(123, 17);
			this.lbDatabaseLogin.StarColor = System.Drawing.Color.Crimson;
			this.lbDatabaseLogin.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbDatabaseLogin.StarOffsetX = 2;
			this.lbDatabaseLogin.StarOffsetY = 0;
			this.lbDatabaseLogin.StarShow = false;
			this.lbDatabaseLogin.StarText = "*";
			this.lbDatabaseLogin.TabIndex = 22;
			this.lbDatabaseLogin.Text = "Database login:";
			// 
			// dgvConnectionList
			// 
			this.dgvConnectionList.AllowUserToAddRows = false;
			this.dgvConnectionList.AllowUserToDeleteRows = false;
			this.dgvConnectionList.AllowUserToOrderColumns = true;
			this.dgvConnectionList.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvConnectionList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvConnectionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvConnectionList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvConnectionList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgvConnectionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvConnectionList.CommandAdd = false;
			this.dgvConnectionList.CommandDel = false;
			this.dgvConnectionList.CommandEdit = false;
			this.dgvConnectionList.CommandExportToExcel = false;
			this.dgvConnectionList.CommandFilter = false;
			this.dgvConnectionList.CommandRefresh = false;
			this.dgvConnectionList.CommandSaveASCSV = false;
			this.dgvConnectionList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvConnectionList.EnableHeadersVisualStyles = false;
			this.dgvConnectionList.GroupEnabled = null;
			this.dgvConnectionList.Location = new System.Drawing.Point(10, 25);
			this.dgvConnectionList.Margin = new System.Windows.Forms.Padding(1);
			this.dgvConnectionList.MultiSelect = false;
			this.dgvConnectionList.Name = "dgvConnectionList";
			this.dgvConnectionList.Obj = null;
			this.dgvConnectionList.PassedSec = null;
			this.dgvConnectionList.ReadOnly = true;
			this.dgvConnectionList.RowHeadersVisible = false;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dgvConnectionList.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvConnectionList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dgvConnectionList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvConnectionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvConnectionList.Size = new System.Drawing.Size(587, 158);
			this.dgvConnectionList.TabIndex = 27;
			this.dgvConnectionList.SelectionChanged += new System.EventHandler(this.DgvConnectionListSelectionChanged);
			this.dgvConnectionList.DoubleClick += new System.EventHandler(this.dgvConnectionList_DoubleClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(6, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(245, 17);
			this.label1.StarColor = System.Drawing.Color.Crimson;
			this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
			this.label1.StarOffsetX = 2;
			this.label1.StarOffsetY = 0;
			this.label1.StarShow = false;
			this.label1.StarText = "*";
			this.label1.TabIndex = 35;
			this.label1.Text = "Connection list:";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnOk);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 468);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(607, 41);
			this.panel1.TabIndex = 36;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnOk.Image = global::FBA.Resource.OK_24;
			this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOk.Location = new System.Drawing.Point(483, 4);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(112, 33);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "  Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnAdd.Image = global::FBA.Resource.Add_24;
			this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAdd.Location = new System.Drawing.Point(435, 259);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(161, 33);
			this.btnAdd.TabIndex = 37;
			this.btnAdd.Text = "Add connection  ";
			this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnDel.Image = global::FBA.Resource.Delete_24;
			this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDel.Location = new System.Drawing.Point(435, 293);
			this.btnDel.Margin = new System.Windows.Forms.Padding(4);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(161, 33);
			this.btnDel.TabIndex = 38;
			this.btnDel.Text = "Delete connection";
			this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.BtnDelClick);
			// 
			// tbConnectionName
			// 
			this.tbConnectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbConnectionName.BackColor = System.Drawing.SystemColors.Info;
			this.tbConnectionName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbConnectionName.Location = new System.Drawing.Point(158, 222);
			this.tbConnectionName.Margin = new System.Windows.Forms.Padding(4);
			this.tbConnectionName.Name = "tbConnectionName";
			this.tbConnectionName.Size = new System.Drawing.Size(269, 25);
			this.tbConnectionName.TabIndex = 40;
			// 
			// lbConnectionName
			// 
			this.lbConnectionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbConnectionName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbConnectionName.Location = new System.Drawing.Point(6, 225);
			this.lbConnectionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbConnectionName.Name = "lbConnectionName";
			this.lbConnectionName.Size = new System.Drawing.Size(145, 17);
			this.lbConnectionName.StarColor = System.Drawing.Color.Crimson;
			this.lbConnectionName.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbConnectionName.StarOffsetX = 2;
			this.lbConnectionName.StarOffsetY = 0;
			this.lbConnectionName.StarShow = true;
			this.lbConnectionName.StarText = "*";
			this.lbConnectionName.TabIndex = 39;
			this.lbConnectionName.Text = "Connection name:";
			// 
			// tbUserForm
			// 
			this.tbUserForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbUserForm.BackColor = System.Drawing.SystemColors.Info;
			this.tbUserForm.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUserForm.Location = new System.Drawing.Point(158, 282);
			this.tbUserForm.Margin = new System.Windows.Forms.Padding(4);
			this.tbUserForm.Name = "tbUserForm";
			this.tbUserForm.Size = new System.Drawing.Size(268, 25);
			this.tbUserForm.TabIndex = 42;
			// 
			// lbUserForm
			// 
			this.lbUserForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbUserForm.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbUserForm.Location = new System.Drawing.Point(6, 285);
			this.lbUserForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbUserForm.Name = "lbUserForm";
			this.lbUserForm.Size = new System.Drawing.Size(137, 17);
			this.lbUserForm.StarColor = System.Drawing.Color.Crimson;
			this.lbUserForm.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbUserForm.StarOffsetX = 2;
			this.lbUserForm.StarOffsetY = 0;
			this.lbUserForm.StarShow = true;
			this.lbUserForm.StarText = "*";
			this.lbUserForm.TabIndex = 41;
			this.lbUserForm.Text = "Start form:";
			// 
			// btnExample
			// 
			this.btnExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExample.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnExample.Image = global::FBA.Resource.Example_24;
			this.btnExample.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnExample.Location = new System.Drawing.Point(435, 191);
			this.btnExample.Margin = new System.Windows.Forms.Padding(4);
			this.btnExample.Name = "btnExample";
			this.btnExample.Size = new System.Drawing.Size(161, 33);
			this.btnExample.TabIndex = 43;
			this.btnExample.Text = "Example";
			this.btnExample.UseVisualStyleBackColor = true;
			this.btnExample.Click += new System.EventHandler(this.BtnExampleClick);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnSave.Image = global::FBA.Resource.Save_24;
			this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.Location = new System.Drawing.Point(435, 327);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(161, 33);
			this.btnSave.TabIndex = 44;
			this.btnSave.Text = "Save connection ";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// lbUserLogin
			// 
			this.lbUserLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbUserLogin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbUserLogin.Location = new System.Drawing.Point(6, 406);
			this.lbUserLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbUserLogin.Name = "lbUserLogin";
			this.lbUserLogin.Size = new System.Drawing.Size(97, 17);
			this.lbUserLogin.StarColor = System.Drawing.Color.Crimson;
			this.lbUserLogin.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbUserLogin.StarOffsetX = 2;
			this.lbUserLogin.StarOffsetY = 0;
			this.lbUserLogin.StarShow = false;
			this.lbUserLogin.StarText = "*";
			this.lbUserLogin.TabIndex = 45;
			this.lbUserLogin.Text = "User login:";
			// 
			// tbUserLogin
			// 
			this.tbUserLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbUserLogin.BackColor = System.Drawing.SystemColors.Info;
			this.tbUserLogin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUserLogin.Location = new System.Drawing.Point(158, 403);
			this.tbUserLogin.Margin = new System.Windows.Forms.Padding(4);
			this.tbUserLogin.Name = "tbUserLogin";
			this.tbUserLogin.Size = new System.Drawing.Size(267, 25);
			this.tbUserLogin.TabIndex = 46;
			// 
			// tbUserPass
			// 
			this.tbUserPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbUserPass.BackColor = System.Drawing.SystemColors.Info;
			this.tbUserPass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUserPass.Location = new System.Drawing.Point(157, 433);
			this.tbUserPass.Margin = new System.Windows.Forms.Padding(4);
			this.tbUserPass.Name = "tbUserPass";
			this.tbUserPass.PasswordChar = '*';
			this.tbUserPass.Size = new System.Drawing.Size(269, 25);
			this.tbUserPass.TabIndex = 48;
			// 
			// lbUserPass
			// 
			this.lbUserPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbUserPass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbUserPass.Location = new System.Drawing.Point(6, 436);
			this.lbUserPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbUserPass.Name = "lbUserPass";
			this.lbUserPass.Size = new System.Drawing.Size(130, 17);
			this.lbUserPass.StarColor = System.Drawing.Color.Crimson;
			this.lbUserPass.StarFont = new System.Drawing.Font("Arial", 20F);
			this.lbUserPass.StarOffsetX = 2;
			this.lbUserPass.StarOffsetY = 0;
			this.lbUserPass.StarShow = false;
			this.lbUserPass.StarText = "*";
			this.lbUserPass.TabIndex = 47;
			this.lbUserPass.Text = "User password:";
			// 
			// cbWindowsLogin
			// 
			this.cbWindowsLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cbWindowsLogin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbWindowsLogin.Location = new System.Drawing.Point(435, 435);
			this.cbWindowsLogin.Margin = new System.Windows.Forms.Padding(4);
			this.cbWindowsLogin.Name = "cbWindowsLogin";
			this.cbWindowsLogin.Size = new System.Drawing.Size(158, 21);
			this.cbWindowsLogin.TabIndex = 50;
			this.cbWindowsLogin.Text = "Use Windows Login";
			this.cbWindowsLogin.UseVisualStyleBackColor = true;
			this.cbWindowsLogin.CheckedChanged += new System.EventHandler(this.CbWindowsLogin_CheckedChanged);
			// 
			// FormConList
			// 
			this.ClientSize = new System.Drawing.Size(607, 509);
			this.Controls.Add(this.cbWindowsLogin);
			this.Controls.Add(this.tbUserPass);
			this.Controls.Add(this.lbUserPass);
			this.Controls.Add(this.tbUserLogin);
			this.Controls.Add(this.lbUserLogin);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnExample);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.tbUserForm);
			this.Controls.Add(this.lbUserForm);
			this.Controls.Add(this.tbConnectionName);
			this.Controls.Add(this.lbConnectionName);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnConnectionTest);
			this.Controls.Add(this.tbDatabaseName);
			this.Controls.Add(this.lbDatabaseName);
			this.Controls.Add(this.tbServerName);
			this.Controls.Add(this.lbServerName);
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.lbServerType);
			this.Controls.Add(this.tbDatabasePass);
			this.Controls.Add(this.tbDatabaseLogin);
			this.Controls.Add(this.lbDatabasePass);
			this.Controls.Add(this.lbDatabaseLogin);
			this.Controls.Add(this.dgvConnectionList);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimizeBox = false;
			this.Name = "FormConList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Connection list";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.dgvConnectionList)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnExample;
		private FBA.LabelFBA lbUserForm;
		private System.Windows.Forms.TextBox tbUserForm;
		private FBA.LabelFBA lbConnectionName;
		private System.Windows.Forms.TextBox tbConnectionName;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel panel1;
		private FBA.LabelFBA label1;
		private FBA.DataGridViewFBA dgvConnectionList;
		private FBA.LabelFBA lbDatabaseLogin;
		private FBA.LabelFBA lbDatabasePass;
		private System.Windows.Forms.TextBox tbDatabaseLogin;
		private System.Windows.Forms.TextBox tbDatabasePass;
		private FBA.LabelFBA lbServerType;
		private FBA.ComboBoxFBA cbType;
		private FBA.LabelFBA lbServerName;
		private System.Windows.Forms.TextBox tbServerName;
		private FBA.LabelFBA lbDatabaseName;
		private System.Windows.Forms.TextBox tbDatabaseName;
		private System.Windows.Forms.Button btnConnectionTest;
		private FBA.LabelFBA lbUserLogin;
		private System.Windows.Forms.TextBox tbUserLogin;
		private System.Windows.Forms.TextBox tbUserPass;
		private FBA.LabelFBA lbUserPass;
		private System.Windows.Forms.CheckBox cbWindowsLogin;
	}
}
