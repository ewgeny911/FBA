
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 06.10.2017
 * Время: 17:16
 */
 
namespace FBA
{
    partial class CompAttrTreeFBA
    {         
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel pnlAttr;
        
        /// <summary>
        /// Сделано public для доступности из вызывающего класса.
        /// </summary>
        public System.Windows.Forms.TreeView treeViewAttr;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmAttr;
        private System.Windows.Forms.ToolStripMenuItem cmMenu_N1;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompAttrTreeFBA));
            this.pnlAttr = new System.Windows.Forms.Panel();
            this.treeViewAttr = new System.Windows.Forms.TreeView();
            this.cmAttr = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmMenu_N1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripAttr = new System.Windows.Forms.ToolStrip();
            this.tsAttr_N1 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAttr_N3 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N4 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N5 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAttr_N7 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N8 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAttr_N10 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAttr_N12 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N13 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N14 = new System.Windows.Forms.ToolStripButton();
            this.tsAttr_N15 = new System.Windows.Forms.ToolStripButton();
            this.pnlAttr.SuspendLayout();
            this.cmAttr.SuspendLayout();
            this.toolStripAttr.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAttr
            // 
            this.pnlAttr.Controls.Add(this.treeViewAttr);
            this.pnlAttr.Controls.Add(this.toolStripAttr);
            this.pnlAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttr.Location = new System.Drawing.Point(0, 0);
            this.pnlAttr.Name = "pnlAttr";
            this.pnlAttr.Size = new System.Drawing.Size(442, 265);
            this.pnlAttr.TabIndex = 11;
            // 
            // treeViewAttr
            // 
            this.treeViewAttr.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewAttr.ContextMenuStrip = this.cmAttr;
            this.treeViewAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewAttr.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewAttr.Location = new System.Drawing.Point(0, 25);
            this.treeViewAttr.Name = "treeViewAttr";
            this.treeViewAttr.PathSeparator = ".";
            this.treeViewAttr.ShowNodeToolTips = true;
            this.treeViewAttr.Size = new System.Drawing.Size(442, 240);
            this.treeViewAttr.TabIndex = 4;
            // 
            // cmAttr
            // 
            this.cmAttr.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmAttr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmMenu_N1});
            this.cmAttr.Name = "cmAttr";
            this.cmAttr.Size = new System.Drawing.Size(144, 26);
            // 
            // cmMenu_N1
            // 
            this.cmMenu_N1.Name = "cmMenu_N1";
            this.cmMenu_N1.Size = new System.Drawing.Size(143, 22);
            this.cmMenu_N1.Text = "Properties";
            this.cmMenu_N1.Click += new System.EventHandler(this.cmMenu_N1_Click);
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
            // toolStripAttr
            // 
            this.toolStripAttr.Font = new System.Drawing.Font("Arial", 11.25F);
            this.toolStripAttr.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripAttr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAttr_N1,
            this.tsAttr_N2,
            this.toolStripSeparator5,
            this.tsAttr_N3,
            this.tsAttr_N4,
            this.tsAttr_N5,
            this.tsAttr_N6,
            this.toolStripSeparator6,
            this.tsAttr_N7,
            this.tsAttr_N8,
            this.tsAttr_N9,
            this.toolStripSeparator7,
            this.tsAttr_N10,
            this.tsAttr_N11,
            this.toolStripSeparator8,
            this.tsAttr_N12,
            this.tsAttr_N13,
            this.tsAttr_N14,
            this.tsAttr_N15});
            this.toolStripAttr.Location = new System.Drawing.Point(0, 0);
            this.toolStripAttr.Name = "toolStripAttr";
            this.toolStripAttr.Size = new System.Drawing.Size(442, 25);
            this.toolStripAttr.TabIndex = 10;
            this.toolStripAttr.Text = "toolStrip2";
            // 
            // tsAttr_N1
            // 
            this.tsAttr_N1.Checked = true;
            this.tsAttr_N1.CheckOnClick = true;
            this.tsAttr_N1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N1.Image = global::FBA.Resource.attr_basic_16;
            this.tsAttr_N1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N1.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N1.Name = "tsAttr_N1";
            this.tsAttr_N1.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N1.Text = "toolStripButton1";
            this.tsAttr_N1.ToolTipText = "Показывать атрибуты - собственные ";
            this.tsAttr_N1.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N2
            // 
            this.tsAttr_N2.Checked = true;
            this.tsAttr_N2.CheckOnClick = true;
            this.tsAttr_N2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N2.Image = global::FBA.Resource.attr_parent_16;
            this.tsAttr_N2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N2.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N2.Name = "tsAttr_N2";
            this.tsAttr_N2.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N2.Text = "toolStripButton2";
            this.tsAttr_N2.ToolTipText = "Показывать атрибуты - унаследованные";
            this.tsAttr_N2.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAttr_N3
            // 
            this.tsAttr_N3.Checked = true;
            this.tsAttr_N3.CheckOnClick = true;
            this.tsAttr_N3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N3.Image = global::FBA.Resource.attr_usual_16;
            this.tsAttr_N3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N3.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N3.Name = "tsAttr_N3";
            this.tsAttr_N3.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N3.Text = "toolStripButton7";
            this.tsAttr_N3.ToolTipText = "Показывать атрибуты - поля";
            this.tsAttr_N3.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N4
            // 
            this.tsAttr_N4.Checked = true;
            this.tsAttr_N4.CheckOnClick = true;
            this.tsAttr_N4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N4.Image = global::FBA.Resource.attr_link_16;
            this.tsAttr_N4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N4.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N4.Name = "tsAttr_N4";
            this.tsAttr_N4.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N4.Text = "toolStripButton8";
            this.tsAttr_N4.ToolTipText = "Показывать атрибуты - ссылки";
            this.tsAttr_N4.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N5
            // 
            this.tsAttr_N5.Checked = true;
            this.tsAttr_N5.CheckOnClick = true;
            this.tsAttr_N5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N5.Image = global::FBA.Resource.attr_unilink2_16;
            this.tsAttr_N5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N5.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N5.Name = "tsAttr_N5";
            this.tsAttr_N5.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N5.Text = "toolStripButton9";
            this.tsAttr_N5.ToolTipText = "Показывать атрибуты - универсальные ссылки";
            this.tsAttr_N5.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N6
            // 
            this.tsAttr_N6.Checked = true;
            this.tsAttr_N6.CheckOnClick = true;
            this.tsAttr_N6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N6.Image = global::FBA.Resource.attr_array_16;
            this.tsAttr_N6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N6.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N6.Name = "tsAttr_N6";
            this.tsAttr_N6.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N6.Text = "toolStripButton10";
            this.tsAttr_N6.ToolTipText = "Показывать атрибуты - массивы связанных объектов";
            this.tsAttr_N6.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAttr_N7
            // 
            this.tsAttr_N7.Checked = true;
            this.tsAttr_N7.CheckOnClick = true;
            this.tsAttr_N7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N7.Image = global::FBA.Resource.arrt_base_16;
            this.tsAttr_N7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N7.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N7.Name = "tsAttr_N7";
            this.tsAttr_N7.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N7.Text = "toolStripButton11";
            this.tsAttr_N7.ToolTipText = "Показывать атрибуты - из базы данных";
            this.tsAttr_N7.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N8
            // 
            this.tsAttr_N8.Checked = true;
            this.tsAttr_N8.CheckOnClick = true;
            this.tsAttr_N8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N8.Image = global::FBA.Resource.attr_sys_16;
            this.tsAttr_N8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N8.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N8.Name = "tsAttr_N8";
            this.tsAttr_N8.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N8.Text = "toolStripButton12";
            this.tsAttr_N8.ToolTipText = "Показывать атрибуты - системные";
            this.tsAttr_N8.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N9
            // 
            this.tsAttr_N9.Checked = true;
            this.tsAttr_N9.CheckOnClick = true;
            this.tsAttr_N9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N9.Image = global::FBA.Resource.attr_calc_16;
            this.tsAttr_N9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N9.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N9.Name = "tsAttr_N9";
            this.tsAttr_N9.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N9.Text = "toolStripButton13";
            this.tsAttr_N9.ToolTipText = "Показывать атрибуты - вычисляемые на MSQL";
            this.tsAttr_N9.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAttr_N10
            // 
            this.tsAttr_N10.Checked = true;
            this.tsAttr_N10.CheckOnClick = true;
            this.tsAttr_N10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N10.Image = global::FBA.Resource.attr_not_hist_16;
            this.tsAttr_N10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N10.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N10.Name = "tsAttr_N10";
            this.tsAttr_N10.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N10.Text = "toolStripButton14";
            this.tsAttr_N10.ToolTipText = "Показывать атрибуты - неисторичные";
            this.tsAttr_N10.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N11
            // 
            this.tsAttr_N11.Checked = true;
            this.tsAttr_N11.CheckOnClick = true;
            this.tsAttr_N11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N11.Image = global::FBA.Resource.attr_hist_16;
            this.tsAttr_N11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N11.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N11.Name = "tsAttr_N11";
            this.tsAttr_N11.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N11.Text = "toolStripButton15";
            this.tsAttr_N11.ToolTipText = "Показывать атрибуты - историчные";
            this.tsAttr_N11.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAttr_N12
            // 
            this.tsAttr_N12.Checked = true;
            this.tsAttr_N12.CheckOnClick = true;
            this.tsAttr_N12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N12.Image = global::FBA.Resource.attr_in_name_16;
            this.tsAttr_N12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N12.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N12.Name = "tsAttr_N12";
            this.tsAttr_N12.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N12.Text = "toolStripButton16";
            this.tsAttr_N12.ToolTipText = "Показывать атрибуты - входящие в наименование объекта";
            this.tsAttr_N12.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N13
            // 
            this.tsAttr_N13.Checked = true;
            this.tsAttr_N13.CheckOnClick = true;
            this.tsAttr_N13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N13.Image = global::FBA.Resource.attr_key_16;
            this.tsAttr_N13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N13.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N13.Name = "tsAttr_N13";
            this.tsAttr_N13.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N13.Text = "toolStripButton17";
            this.tsAttr_N13.ToolTipText = "Показывать атрибуты - ключевые";
            this.tsAttr_N13.Visible = false;
            this.tsAttr_N13.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // tsAttr_N14
            // 
            this.tsAttr_N14.Checked = true;
            this.tsAttr_N14.CheckOnClick = true;
            this.tsAttr_N14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N14.Image = global::FBA.Resource.attr_this_16;
            this.tsAttr_N14.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N14.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N14.Name = "tsAttr_N14";
            this.tsAttr_N14.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N14.Text = "toolStripButton18";
            this.tsAttr_N14.ToolTipText = "Показывать атрибуты - обязательные";
            this.tsAttr_N14.Visible = false;
            // 
            // tsAttr_N15
            // 
            this.tsAttr_N15.Checked = true;
            this.tsAttr_N15.CheckOnClick = true;
            this.tsAttr_N15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsAttr_N15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAttr_N15.Image = global::FBA.Resource.block_16;
            this.tsAttr_N15.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAttr_N15.ImageTransparentColor = System.Drawing.Color.White;
            this.tsAttr_N15.Name = "tsAttr_N15";
            this.tsAttr_N15.Size = new System.Drawing.Size(23, 22);
            this.tsAttr_N15.Text = "toolStripButton19";
            this.tsAttr_N15.ToolTipText = "Показывать атрибуты - запрещенные к выводу в гибких таблицах";
            this.tsAttr_N15.Visible = false;
            this.tsAttr_N15.Click += new System.EventHandler(this.tsAttr_N1_Click);
            // 
            // CompAttrTreeFBA
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAttr);
            this.Name = "CompAttrTreeFBA";
            this.Size = new System.Drawing.Size(442, 265);
            this.pnlAttr.ResumeLayout(false);
            this.pnlAttr.PerformLayout();
            this.cmAttr.ResumeLayout(false);
            this.toolStripAttr.ResumeLayout(false);
            this.toolStripAttr.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ToolStrip toolStripAttr;
        private System.Windows.Forms.ToolStripButton tsAttr_N1;
        private System.Windows.Forms.ToolStripButton tsAttr_N2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsAttr_N3;
        private System.Windows.Forms.ToolStripButton tsAttr_N4;
        private System.Windows.Forms.ToolStripButton tsAttr_N5;
        private System.Windows.Forms.ToolStripButton tsAttr_N6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsAttr_N7;
        private System.Windows.Forms.ToolStripButton tsAttr_N8;
        private System.Windows.Forms.ToolStripButton tsAttr_N9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsAttr_N10;
        private System.Windows.Forms.ToolStripButton tsAttr_N11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsAttr_N12;
        private System.Windows.Forms.ToolStripButton tsAttr_N13;
        private System.Windows.Forms.ToolStripButton tsAttr_N14;
        private System.Windows.Forms.ToolStripButton tsAttr_N15;
    }
}
