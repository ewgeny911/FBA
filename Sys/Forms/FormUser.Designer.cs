
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 14.12.2016
 * Время: 11:20
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace FBA
{
    partial class FormUser
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
        	this.label1 = new FBA.LabelFBA();
        	this.label3 = new FBA.LabelFBA();
        	this.tbName = new System.Windows.Forms.TextBox();
        	this.tbLogin = new System.Windows.Forms.TextBox();
        	this.cbBlock = new System.Windows.Forms.CheckBox();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.tbID = new System.Windows.Forms.TextBox();
        	this.label5 = new FBA.LabelFBA();
        	this.tbPass = new System.Windows.Forms.TextBox();
        	this.label2 = new FBA.LabelFBA();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.dgvRole = new FBA.DataGridViewFBA();
        	this.label7 = new System.Windows.Forms.Label();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.ObjAdd = new FBA.SysObjAdd();
        	this.labelFBA1 = new FBA.LabelFBA();
        	this.tbRole = new System.Windows.Forms.TextBox();
        	this.panel1.SuspendLayout();
        	this.tabControl1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvRole)).BeginInit();
        	this.tabPage2.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(6, 77);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(88, 23);
        	this.label1.StarColor = System.Drawing.Color.Crimson;
        	this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label1.StarOffsetX = 2;
        	this.label1.StarOffsetY = 0;
        	this.label1.StarShow = true;
        	this.label1.StarText = "*";
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Login:";
        	// 
        	// label3
        	// 
        	this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.Location = new System.Drawing.Point(6, 46);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(88, 23);
        	this.label3.StarColor = System.Drawing.Color.Crimson;
        	this.label3.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label3.StarOffsetX = 2;
        	this.label3.StarOffsetY = 0;
        	this.label3.StarShow = true;
        	this.label3.StarText = "*";
        	this.label3.TabIndex = 2;
        	this.label3.Text = "Name:";
        	// 
        	// tbName
        	// 
        	this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbName.Location = new System.Drawing.Point(107, 43);
        	this.tbName.Name = "tbName";
        	this.tbName.Size = new System.Drawing.Size(432, 25);
        	this.tbName.TabIndex = 4;
        	// 
        	// tbLogin
        	// 
        	this.tbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbLogin.BackColor = System.Drawing.SystemColors.Info;
        	this.tbLogin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbLogin.Location = new System.Drawing.Point(107, 74);
        	this.tbLogin.Name = "tbLogin";
        	this.tbLogin.Size = new System.Drawing.Size(432, 25);
        	this.tbLogin.TabIndex = 5;
        	// 
        	// cbBlock
        	// 
        	this.cbBlock.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbBlock.Location = new System.Drawing.Point(216, 12);
        	this.cbBlock.Name = "cbBlock";
        	this.cbBlock.Size = new System.Drawing.Size(178, 24);
        	this.cbBlock.TabIndex = 9;
        	this.cbBlock.Text = "The user is blocked";
        	this.cbBlock.UseVisualStyleBackColor = true;
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnOk);
        	this.panel1.Controls.Add(this.btnCancel);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Location = new System.Drawing.Point(0, 400);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(551, 41);
        	this.panel1.TabIndex = 10;
        	// 
        	// btnOk
        	// 
        	this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(430, 4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 5;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(312, 4);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(112, 33);
        	this.btnCancel.TabIndex = 4;
        	this.btnCancel.Text = "   Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
        	// 
        	// tbID
        	// 
        	this.tbID.BackColor = System.Drawing.SystemColors.InactiveBorder;
        	this.tbID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbID.Location = new System.Drawing.Point(107, 12);
        	this.tbID.Name = "tbID";
        	this.tbID.ReadOnly = true;
        	this.tbID.Size = new System.Drawing.Size(93, 25);
        	this.tbID.TabIndex = 12;
        	// 
        	// label5
        	// 
        	this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label5.Location = new System.Drawing.Point(7, 14);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(100, 23);
        	this.label5.StarColor = System.Drawing.Color.Crimson;
        	this.label5.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label5.StarOffsetX = 2;
        	this.label5.StarOffsetY = 0;
        	this.label5.StarShow = false;
        	this.label5.StarText = "*";
        	this.label5.TabIndex = 13;
        	this.label5.Text = "ID:";
        	// 
        	// tbPass
        	// 
        	this.tbPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbPass.BackColor = System.Drawing.SystemColors.Info;
        	this.tbPass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbPass.Location = new System.Drawing.Point(107, 105);
        	this.tbPass.Name = "tbPass";
        	this.tbPass.Size = new System.Drawing.Size(432, 25);
        	this.tbPass.TabIndex = 16;
        	// 
        	// label2
        	// 
        	this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.Location = new System.Drawing.Point(6, 108);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(95, 23);
        	this.label2.StarColor = System.Drawing.Color.Crimson;
        	this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label2.StarOffsetX = 2;
        	this.label2.StarOffsetY = 0;
        	this.label2.StarShow = true;
        	this.label2.StarText = "*";
        	this.label2.TabIndex = 15;
        	this.label2.Text = "Password:";
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Controls.Add(this.tabPage2);
        	this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabControl1.Location = new System.Drawing.Point(0, 185);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(551, 215);
        	this.tabControl1.TabIndex = 17;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.dgvRole);
        	this.tabPage1.Controls.Add(this.label7);
        	this.tabPage1.Location = new System.Drawing.Point(4, 26);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(543, 185);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Role";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// dgvRole
        	// 
        	this.dgvRole.AllowUserToAddRows = false;
        	this.dgvRole.AllowUserToDeleteRows = false;
        	this.dgvRole.AllowUserToOrderColumns = true;
        	this.dgvRole.AllowUserToResizeRows = false;
        	dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.dgvRole.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        	this.dgvRole.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        	this.dgvRole.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        	this.dgvRole.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        	this.dgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvRole.CommandAdd = false;
        	this.dgvRole.CommandDel = false;
        	this.dgvRole.CommandEdit = false;
        	this.dgvRole.CommandExportToExcel = false;
        	this.dgvRole.CommandFilter = false;
        	this.dgvRole.CommandRefresh = false;
        	this.dgvRole.CommandSaveASCSV = false;
        	this.dgvRole.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvRole.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        	this.dgvRole.EnableHeadersVisualStyles = false;
        	this.dgvRole.GroupEnabled = null;
        	this.dgvRole.Location = new System.Drawing.Point(3, 26);
        	this.dgvRole.Margin = new System.Windows.Forms.Padding(1);
        	this.dgvRole.MultiSelect = false;
        	this.dgvRole.Name = "dgvRole";
        	this.dgvRole.Obj = null;
        	this.dgvRole.PassedSec = null;
        	this.dgvRole.ReadOnly = true;
        	this.dgvRole.RowHeadersVisible = false;
        	this.dgvRole.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvRole.Size = new System.Drawing.Size(537, 156);
        	this.dgvRole.TabIndex = 15;
        	// 
        	// label7
        	// 
        	this.label7.Dock = System.Windows.Forms.DockStyle.Top;
        	this.label7.Location = new System.Drawing.Point(3, 3);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(537, 23);
        	this.label7.TabIndex = 16;
        	this.label7.Text = "Select only one role";
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.ObjAdd);
        	this.tabPage2.Location = new System.Drawing.Point(4, 26);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(543, 185);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "Right";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// ObjAdd
        	// 
        	this.ObjAdd.BackColor = System.Drawing.SystemColors.Control;
        	this.ObjAdd.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.ObjAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        	this.ObjAdd.Location = new System.Drawing.Point(3, 3);
        	this.ObjAdd.Name = "ObjAdd";
        	this.ObjAdd.Size = new System.Drawing.Size(537, 179);
        	this.ObjAdd.TabIndex = 0;
        	// 
        	// labelFBA1
        	// 
        	this.labelFBA1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.labelFBA1.Location = new System.Drawing.Point(6, 139);
        	this.labelFBA1.Name = "labelFBA1";
        	this.labelFBA1.Size = new System.Drawing.Size(95, 19);
        	this.labelFBA1.StarColor = System.Drawing.Color.Crimson;
        	this.labelFBA1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.labelFBA1.StarOffsetX = 2;
        	this.labelFBA1.StarOffsetY = 0;
        	this.labelFBA1.StarShow = false;
        	this.labelFBA1.StarText = "*";
        	this.labelFBA1.TabIndex = 18;
        	this.labelFBA1.Text = "Role:";
        	// 
        	// tbRole
        	// 
        	this.tbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbRole.BackColor = System.Drawing.SystemColors.Info;
        	this.tbRole.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbRole.Location = new System.Drawing.Point(107, 136);
        	this.tbRole.Name = "tbRole";
        	this.tbRole.Size = new System.Drawing.Size(432, 25);
        	this.tbRole.TabIndex = 19;
        	// 
        	// FormUser
        	// 
        	this.ClientSize = new System.Drawing.Size(551, 441);
        	this.Controls.Add(this.tabControl1);
        	this.Controls.Add(this.tbRole);
        	this.Controls.Add(this.labelFBA1);
        	this.Controls.Add(this.tbPass);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.tbID);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.cbBlock);
        	this.Controls.Add(this.tbLogin);
        	this.Controls.Add(this.tbName);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label1);
        	this.FormNumber = 1;
        	this.FormSavePosition = true;
        	this.Name = "FormUser";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "User";
        	this.panel1.ResumeLayout(false);
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvRole)).EndInit();
        	this.tabPage2.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
     
        private FBA.DataGridViewFBA dgvRole;
        private FBA.LabelFBA label5;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.CheckBox cbBlock;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private FBA.LabelFBA label3;
        private FBA.LabelFBA label1;
        private System.Windows.Forms.TextBox tbPass;
        private FBA.LabelFBA label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private FBA.SysObjAdd ObjAdd;
        private FBA.LabelFBA labelFBA1;
        private System.Windows.Forms.TextBox tbRole;
    }
}
