/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 06.03.2018
 * Время: 14:55
 */
 
namespace FBA
{
    partial class EditFBA
    {
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Кнопка Delete, public чтобы был доступ с вызывающего класса.
        /// </summary>
        public System.Windows.Forms.Button btnDelete;
        
        /// <summary>
        /// Кнопка Edit, public чтобы был доступ с вызывающего класса.
        /// </summary>
        public System.Windows.Forms.Button btnEdit;
        
        /// <summary>
        /// Компонент FBA.ComboBoxFBA, public чтобы был доступ с вызывающего класса.
        /// </summary>
        public FBA.ComboBoxFBA comboBox;
        
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
        	this.comboBox = new FBA.ComboBoxFBA();
        	this.btnDelete = new System.Windows.Forms.Button();
        	this.btnEdit = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// comboBox
        	// 
        	this.comboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.comboBox.AttrBrief = null;
        	this.comboBox.AttrBriefLookup = null;
        	this.comboBox.BackColor = System.Drawing.SystemColors.Info;
        	this.comboBox.ContextMenuEnabled = true;
        	this.comboBox.DropDownWidth = 315;
        	this.comboBox.ErrorIfNull = null;
        	this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.comboBox.FormattingEnabled = true;
        	this.comboBox.GroupEnabled = null;
        	this.comboBox.ItemHeight = 18;
        	this.comboBox.ListInvalidChars = null;
        	this.comboBox.ListValidChars = null;
        	this.comboBox.Location = new System.Drawing.Point(0, 0);
        	this.comboBox.MaxDropDownItems = 50;
        	this.comboBox.Name = "comboBox";
        	this.comboBox.Obj = null;
        	this.comboBox.ObjectID = "";
        	this.comboBox.ObjectRef = null;
        	this.comboBox.ObjRef = null;
        	this.comboBox.ReadOnly = false;
        	this.comboBox.RegExChars = null;
        	this.comboBox.SaveParam = false;
        	this.comboBox.SaveType = null;
        	this.comboBox.SaveValueHistory = false;
        	this.comboBox.Size = new System.Drawing.Size(109, 26);
        	this.comboBox.TabIndex = 4;
        	this.comboBox.Text2 = null;
        	this.comboBox.ValueHistoryInItems = false;
        	this.comboBox.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
        	// 
        	// btnDelete
        	// 
        	this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.btnDelete.Image = global::FBA.Resource.Del_16;
        	this.btnDelete.Location = new System.Drawing.Point(110, 0);
        	this.btnDelete.Name = "btnDelete";
        	this.btnDelete.Size = new System.Drawing.Size(26, 26);
        	this.btnDelete.TabIndex = 2;
        	this.btnDelete.UseVisualStyleBackColor = true;
        	// 
        	// btnEdit
        	// 
        	this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.btnEdit.Image = global::FBA.Resource.prop_16_2;
        	this.btnEdit.Location = new System.Drawing.Point(136, 0);
        	this.btnEdit.Name = "btnEdit";
        	this.btnEdit.Size = new System.Drawing.Size(26, 26);
        	this.btnEdit.TabIndex = 1;
        	this.btnEdit.UseVisualStyleBackColor = true;
        	// 
        	// EditFBA
        	// 
        	this.Controls.Add(this.comboBox);
        	this.Controls.Add(this.btnDelete);
        	this.Controls.Add(this.btnEdit);
        	this.Name = "EditFBA";
        	this.Size = new System.Drawing.Size(161, 26);
        	this.Load += new System.EventHandler(this.EditFBA_Load);
        	this.ResumeLayout(false);

        }
    }
}
