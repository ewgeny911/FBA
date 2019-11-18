
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 01.10.2017
 * Время: 21:06
 * 
 
 */
namespace FBA
{
    partial class FormGetAttr
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ImageList imageList1;              
        private System.Windows.Forms.Panel pnlAttr;
        private CompAttrTreeFBA cmtAttrList;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGetAttr));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlAttr = new System.Windows.Forms.Panel();
            this.cmtAttrList = new FBA.CompAttrTreeFBA();
            this.panel1.SuspendLayout();
            this.pnlAttr.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 367);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 41);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::FBA.Resource.Cancel_24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(127, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "   Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Image = global::FBA.Resource.OK_24;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(244, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 33);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "  Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "at8.png");
            this.imageList1.Images.SetKeyName(1, "at3.png");
            this.imageList1.Images.SetKeyName(2, "at4.png");
            this.imageList1.Images.SetKeyName(3, "at5.png");
            this.imageList1.Images.SetKeyName(4, "at6.png");
            this.imageList1.Images.SetKeyName(5, "at18.png");
            this.imageList1.Images.SetKeyName(6, "at19.png");
            this.imageList1.Images.SetKeyName(7, "1.png");
            this.imageList1.Images.SetKeyName(8, "at20.png");
            this.imageList1.Images.SetKeyName(9, "at11.png");
            // 
            // pnlAttr
            // 
            this.pnlAttr.Controls.Add(this.cmtAttrList);
            this.pnlAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttr.Location = new System.Drawing.Point(0, 0);
            this.pnlAttr.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAttr.Name = "pnlAttr";
            this.pnlAttr.Size = new System.Drawing.Size(364, 367);
            this.pnlAttr.TabIndex = 10;
            // 
            // cmtAttrList
            // 
            this.cmtAttrList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmtAttrList.Location = new System.Drawing.Point(0, 0);
            this.cmtAttrList.Margin = new System.Windows.Forms.Padding(4);
            this.cmtAttrList.Name = "cmtAttrList";
            this.cmtAttrList.Size = new System.Drawing.Size(364, 367);
            this.cmtAttrList.TabIndex = 0;
            this.cmtAttrList.SelectedAttr += new FBA.AttrEventHandler(this.PanelUserSelectedAttr);
            // 
            // FormGetAttr
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 408);
            this.Controls.Add(this.pnlAttr);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGetAttr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attribute";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGetAttrFormClosing);
            this.panel1.ResumeLayout(false);
            this.pnlAttr.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
