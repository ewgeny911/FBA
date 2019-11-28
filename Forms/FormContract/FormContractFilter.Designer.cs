
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 23.11.2017
 * Время: 17:35
 */
 
namespace FBA
{
    partial class FormContractFilter
    {
       private System.ComponentModel.IContainer components;
        public CheckBoxFBA cbID;
        public System.Windows.Forms.Panel PanelFilter;
        public CheckBoxFBA cbNumber;
        public CheckBoxFBA cbType;
        public TextBoxFBA tbNumber;
        public TextBoxFBA tbID;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        public ComboBoxFBA tbType;
        
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
        	this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.cbNumber = new FBA.CheckBoxFBA();
        	this.cbID = new FBA.CheckBoxFBA();
        	this.tbID = new FBA.TextBoxFBA();
        	this.tbNumber = new FBA.TextBoxFBA();
        	this.cbType = new FBA.CheckBoxFBA();
        	this.tbType = new FBA.ComboBoxFBA();
        	this.PanelFilter = new System.Windows.Forms.Panel();
        	this.contextMenuStrip1.SuspendLayout();
        	this.PanelFilter.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// contextMenuStrip1
        	// 
        	this.contextMenuStrip1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.clearToolStripMenuItem});
        	this.contextMenuStrip1.Name = "contextMenuStrip1";
        	this.contextMenuStrip1.Size = new System.Drawing.Size(112, 26);
        	// 
        	// clearToolStripMenuItem
        	// 
        	this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
        	this.clearToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
        	this.clearToolStripMenuItem.Text = "Clear";
        	// 
        	// cbNumber
        	// 
        	this.cbNumber.AttrBrief = null;
        	this.cbNumber.GroupEnabled = "";
        	this.cbNumber.Location = new System.Drawing.Point(13, 43);
        	this.cbNumber.Margin = new System.Windows.Forms.Padding(4);
        	this.cbNumber.Name = "cbNumber";
        	this.cbNumber.Obj = null;
        	this.cbNumber.ObjectRef = null;
        	this.cbNumber.SaveParam = true;
        	this.cbNumber.Size = new System.Drawing.Size(85, 25);
        	this.cbNumber.TabIndex = 0;
        	this.cbNumber.Tag = "SAVE";
        	this.cbNumber.Text = "Number";
        	this.cbNumber.UseVisualStyleBackColor = true;
        	this.cbNumber.CheckedChanged += new System.EventHandler(this.cbID_CheckedChanged);
        	// 
        	// cbID
        	// 
        	this.cbID.AttrBrief = null;
        	this.cbID.GroupEnabled = null;
        	this.cbID.Location = new System.Drawing.Point(13, 14);
        	this.cbID.Margin = new System.Windows.Forms.Padding(4);
        	this.cbID.Name = "cbID";
        	this.cbID.Obj = null;
        	this.cbID.ObjectRef = null;
        	this.cbID.SaveParam = true;
        	this.cbID.Size = new System.Drawing.Size(109, 23);
        	this.cbID.TabIndex = 0;
        	this.cbID.Tag = "SAVE";
        	this.cbID.Text = "ID";
        	this.cbID.UseVisualStyleBackColor = true;
        	this.cbID.CheckedChanged += new System.EventHandler(this.cbID_CheckedChanged);
        	// 
        	// tbID
        	// 
        	this.tbID.AttrBrief = null;
        	this.tbID.AttrBriefLookup = null;
        	this.tbID.ContextMenuStrip = this.contextMenuStrip1;
        	this.tbID.Enabled = false;
        	this.tbID.ErrorIfNull = null;
        	this.tbID.GroupEnabled = "cbID";
        	this.tbID.ListInvalidChars = null;
        	this.tbID.ListValidChars = null;
        	this.tbID.Location = new System.Drawing.Point(133, 13);
        	this.tbID.Margin = new System.Windows.Forms.Padding(4);
        	this.tbID.Name = "tbID";
        	this.tbID.ObjectRef = null;
        	this.tbID.RegExChars = null;
        	this.tbID.SaveParam = true;
        	this.tbID.SaveValueHistory = false;
        	this.tbID.Size = new System.Drawing.Size(89, 25);
        	this.tbID.TabIndex = 4;
        	this.tbID.Tag = "SAVE";
        	this.tbID.Text2 = null;
        	// 
        	// tbNumber
        	// 
        	this.tbNumber.AttrBrief = null;
        	this.tbNumber.AttrBriefLookup = null;
        	this.tbNumber.ContextMenuStrip = this.contextMenuStrip1;
        	this.tbNumber.Enabled = false;
        	this.tbNumber.ErrorIfNull = null;
        	this.tbNumber.GroupEnabled = "cbNumber";
        	this.tbNumber.ListInvalidChars = null;
        	this.tbNumber.ListValidChars = null;
        	this.tbNumber.Location = new System.Drawing.Point(133, 43);
        	this.tbNumber.Margin = new System.Windows.Forms.Padding(4);
        	this.tbNumber.Name = "tbNumber";
        	this.tbNumber.ObjectRef = null;
        	this.tbNumber.RegExChars = null;
        	this.tbNumber.SaveParam = true;
        	this.tbNumber.SaveValueHistory = false;
        	this.tbNumber.Size = new System.Drawing.Size(292, 25);
        	this.tbNumber.TabIndex = 5;
        	this.tbNumber.Tag = "SAVE";
        	this.tbNumber.Text2 = null;
        	// 
        	// cbType
        	// 
        	this.cbType.AttrBrief = null;
        	this.cbType.GroupEnabled = "";
        	this.cbType.Location = new System.Drawing.Point(13, 73);
        	this.cbType.Margin = new System.Windows.Forms.Padding(4);
        	this.cbType.Name = "cbType";
        	this.cbType.Obj = null;
        	this.cbType.ObjectRef = null;
        	this.cbType.SaveParam = true;
        	this.cbType.Size = new System.Drawing.Size(121, 25);
        	this.cbType.TabIndex = 6;
        	this.cbType.Tag = "SAVE";
        	this.cbType.Text = "Contract type";
        	this.cbType.UseVisualStyleBackColor = true;
        	this.cbType.CheckedChanged += new System.EventHandler(this.cbID_CheckedChanged);
        	// 
        	// tbType
        	// 
        	this.tbType.AttrBrief = null;
        	this.tbType.AttrBriefLookup = null;
        	this.tbType.ContextMenuEnabled = true;
        	this.tbType.ContextMenuStrip = this.contextMenuStrip1;
        	this.tbType.Enabled = false;
        	this.tbType.ErrorIfNull = null;
        	this.tbType.FormattingEnabled = true;
        	this.tbType.GroupEnabled = "cbType";
        	this.tbType.ListInvalidChars = null;
        	this.tbType.ListValidChars = null;
        	this.tbType.Location = new System.Drawing.Point(133, 73);
        	this.tbType.Name = "tbType";
        	this.tbType.Obj = null;
        	this.tbType.ObjectID = "";
        	this.tbType.ObjectRef = null;
        	this.tbType.ObjRef = null;
        	this.tbType.ReadOnly = false;
        	this.tbType.RegExChars = null;
        	this.tbType.SaveParam = true;
        	this.tbType.SaveType = null;
        	this.tbType.SaveValueHistory = false;
        	this.tbType.Size = new System.Drawing.Size(292, 25);
        	this.tbType.TabIndex = 22;
        	this.tbType.Tag = "SAVE";
        	this.tbType.Text2 = null;
        	this.tbType.ValueHistoryInItems = false;
        	// 
        	// PanelFilter
        	// 
        	this.PanelFilter.ContextMenuStrip = this.contextMenuStrip1;
        	this.PanelFilter.Controls.Add(this.tbType);
        	this.PanelFilter.Controls.Add(this.cbType);
        	this.PanelFilter.Controls.Add(this.tbNumber);
        	this.PanelFilter.Controls.Add(this.tbID);
        	this.PanelFilter.Controls.Add(this.cbID);
        	this.PanelFilter.Controls.Add(this.cbNumber);
        	this.PanelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.PanelFilter.Location = new System.Drawing.Point(0, 0);
        	this.PanelFilter.Margin = new System.Windows.Forms.Padding(4);
        	this.PanelFilter.Name = "PanelFilter";
        	this.PanelFilter.Size = new System.Drawing.Size(440, 131);
        	this.PanelFilter.TabIndex = 13;
        	// 
        	// FormContractFilter
        	// 
        	//this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
        	//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(440, 131);
        	this.Controls.Add(this.PanelFilter);
        	this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormContractFilter";
        	this.Text = "FormFilt";
        	this.contextMenuStrip1.ResumeLayout(false);
        	this.PanelFilter.ResumeLayout(false);
        	this.PanelFilter.PerformLayout();
        	this.ResumeLayout(false);

        }
        
    }
}
