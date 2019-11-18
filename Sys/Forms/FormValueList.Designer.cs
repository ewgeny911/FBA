
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 22.11.2017
 * Время: 17:43
 */
namespace FBA
{
    partial class FormValueList
    {
        
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private FBA.GridFBA dgList;
         
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
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.dgList = new FBA.GridFBA();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnCancel);
        	this.panel1.Controls.Add(this.btnOk);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.panel1.Location = new System.Drawing.Point(0, 282);
        	this.panel1.Margin = new System.Windows.Forms.Padding(4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(529, 41);
        	this.panel1.TabIndex = 5;
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(293, 4);
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
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(411, 4);
        	this.btnOk.Margin = new System.Windows.Forms.Padding(4);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(112, 33);
        	this.btnOk.TabIndex = 0;
        	this.btnOk.Text = "  Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// dgList
        	// 
        	this.dgList.BackColor = System.Drawing.Color.LightGray;
        	this.dgList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        	this.dgList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.dgList.DefaultWidth = 150;
        	this.dgList.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
        	this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgList.EnableSort = false;
        	this.dgList.FixedRows = 1;
        	this.dgList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.dgList.Location = new System.Drawing.Point(0, 0);
        	this.dgList.Name = "dgList";
        	this.dgList.SelectionMode = SourceGrid.GridSelectionMode.Row;
        	this.dgList.Size = new System.Drawing.Size(529, 282);
        	this.dgList.TabIndex = 29;
        	this.dgList.TabStop = true;
        	this.dgList.ToolTipText = "";
        	// 
        	// FormValueList
        	// 
        	this.ClientSize = new System.Drawing.Size(529, 323);
        	this.Controls.Add(this.dgList);
        	this.Controls.Add(this.panel1);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormValueList";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Value list";
        	this.panel1.ResumeLayout(false);
        	this.ResumeLayout(false);

        }
    }
}
