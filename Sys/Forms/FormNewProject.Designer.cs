
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 09.09.2016
 * Время: 18:12
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace FBA
{
    partial class ProjectNew
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
        	this.label1 = new FBA.LabelFBA();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.label2 = new FBA.LabelFBA();
        	this.tbProjectName = new System.Windows.Forms.TextBox();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.listBoxTemplate = new System.Windows.Forms.ListBox();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(6, 60);
        	this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(456, 18);
        	this.label1.StarColor = System.Drawing.Color.Crimson;
        	this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label1.StarOffsetX = 2;
        	this.label1.StarOffsetY = 0;
        	this.label1.StarShow = false;
        	this.label1.StarText = "*";
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Select a template for the new form";
        	// 
        	// btnOk
        	// 
        	this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(293, 4);
        	this.btnOk.Margin = new System.Windows.Forms.Padding(4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 5;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// label2
        	// 
        	this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.Location = new System.Drawing.Point(5, 6);
        	this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(420, 18);
        	this.label2.StarColor = System.Drawing.Color.Crimson;
        	this.label2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label2.StarOffsetX = 2;
        	this.label2.StarOffsetY = 0;
        	this.label2.StarShow = false;
        	this.label2.StarText = "*";
        	this.label2.TabIndex = 6;
        	this.label2.Text = "Enter a name for the new form\r\n";
        	// 
        	// tbProjectName
        	// 
        	this.tbProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbProjectName.BackColor = System.Drawing.SystemColors.Info;
        	this.tbProjectName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbProjectName.Location = new System.Drawing.Point(6, 28);
        	this.tbProjectName.Margin = new System.Windows.Forms.Padding(4);
        	this.tbProjectName.Name = "tbProjectName";
        	this.tbProjectName.Size = new System.Drawing.Size(399, 25);
        	this.tbProjectName.TabIndex = 7;
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(178, 4);
        	this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(112, 33);
        	this.btnCancel.TabIndex = 4;
        	this.btnCancel.Text = "   Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.btnCancelClick);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnOk);
        	this.panel1.Controls.Add(this.btnCancel);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Location = new System.Drawing.Point(0, 201);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(414, 41);
        	this.panel1.TabIndex = 8;
        	// 
        	// listBoxTemplate
        	// 
        	this.listBoxTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.listBoxTemplate.BackColor = System.Drawing.SystemColors.Info;
        	this.listBoxTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.listBoxTemplate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.listBoxTemplate.FormattingEnabled = true;
        	this.listBoxTemplate.ItemHeight = 17;
        	this.listBoxTemplate.Location = new System.Drawing.Point(6, 82);
        	this.listBoxTemplate.Margin = new System.Windows.Forms.Padding(4);
        	this.listBoxTemplate.Name = "listBoxTemplate";
        	this.listBoxTemplate.Size = new System.Drawing.Size(399, 104);
        	this.listBoxTemplate.TabIndex = 9;
        	// 
        	// ProjectNew
        	// 
        	this.ClientSize = new System.Drawing.Size(414, 242);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.tbProjectName);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.listBoxTemplate);
        	this.Controls.Add(this.label1);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "ProjectNew";
        	this.Text = "New Form";
        	this.panel1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;       
        private FBA.LabelFBA label2;
        private System.Windows.Forms.Button btnOk;
        private FBA.LabelFBA label1;
        private System.Windows.Forms.ListBox listBoxTemplate;
        private System.Windows.Forms.TextBox tbProjectName;
    }
}
