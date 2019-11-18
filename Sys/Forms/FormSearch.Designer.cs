
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 15.02.2018
 * Время: 10:33
 */
namespace FBA
{
    partial class FormSearch
    {        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbSerachText;
        private FBA.DataGridViewFBA DGResult;
        private System.Windows.Forms.CheckBox cbCaseSensitivity;
        private System.Windows.Forms.RadioButton rbPart1;
        private System.Windows.Forms.GroupBox gpPosition;
        private System.Windows.Forms.RadioButton rbPart4;
        private System.Windows.Forms.RadioButton rbPart3;
        private System.Windows.Forms.RadioButton rbPart2;
        private System.Windows.Forms.CheckBox cbHighlight;
        private System.Windows.Forms.CheckBox cbOnlyColumns;
        private System.Windows.Forms.RadioButton rbDown;
        private System.Windows.Forms.RadioButton rbUp;
        private System.Windows.Forms.GroupBox gpSettings;
        private System.Windows.Forms.GroupBox gbDirection;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Label lbResultCount;
         
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
        	this.panelButton = new System.Windows.Forms.Panel();
        	this.btnResult = new System.Windows.Forms.Button();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.cbHighlight = new System.Windows.Forms.CheckBox();
        	this.lbResultCount = new System.Windows.Forms.Label();
        	this.lbSerachText = new System.Windows.Forms.Label();
        	this.DGResult = new FBA.DataGridViewFBA();
        	this.cbCaseSensitivity = new System.Windows.Forms.CheckBox();
        	this.rbPart1 = new System.Windows.Forms.RadioButton();
        	this.gpPosition = new System.Windows.Forms.GroupBox();
        	this.rbPart4 = new System.Windows.Forms.RadioButton();
        	this.rbPart3 = new System.Windows.Forms.RadioButton();
        	this.rbPart2 = new System.Windows.Forms.RadioButton();
        	this.cbOnlyColumns = new System.Windows.Forms.CheckBox();
        	this.rbDown = new System.Windows.Forms.RadioButton();
        	this.rbUp = new System.Windows.Forms.RadioButton();
        	this.gpSettings = new System.Windows.Forms.GroupBox();
        	this.cbOnlyArea = new System.Windows.Forms.CheckBox();
        	this.cbOnlyRows = new System.Windows.Forms.CheckBox();
        	this.gbDirection = new System.Windows.Forms.GroupBox();
        	this.rbAll = new System.Windows.Forms.RadioButton();
        	this.EditFBA1 = new FBA.EditFBA();
        	this.panelButton.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.DGResult)).BeginInit();
        	this.gpPosition.SuspendLayout();
        	this.gpSettings.SuspendLayout();
        	this.gbDirection.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panelButton
        	// 
        	this.panelButton.Controls.Add(this.btnResult);
        	this.panelButton.Controls.Add(this.btnCancel);
        	this.panelButton.Controls.Add(this.btnOk);
        	this.panelButton.Controls.Add(this.cbHighlight);
        	this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panelButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.panelButton.Location = new System.Drawing.Point(0, 324);
        	this.panelButton.Name = "panelButton";
        	this.panelButton.Size = new System.Drawing.Size(531, 41);
        	this.panelButton.TabIndex = 5;
        	// 
        	// btnResult
        	// 
        	this.btnResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnResult.Image = global::FBA.Resource.Expand2_24;
        	this.btnResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnResult.Location = new System.Drawing.Point(167, 3);
        	this.btnResult.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.btnResult.Name = "btnResult";
        	this.btnResult.Size = new System.Drawing.Size(148, 33);
        	this.btnResult.TabIndex = 28;
        	this.btnResult.Text = "Show the results";
        	this.btnResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.btnResult.UseVisualStyleBackColor = true;
        	this.btnResult.Visible = false;
        	this.btnResult.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnCancel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnCancel.Image = global::FBA.Resource.Cancel_24;
        	this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnCancel.Location = new System.Drawing.Point(322, 3);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(99, 33);
        	this.btnCancel.TabIndex = 2;
        	this.btnCancel.Text = "    Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// btnOk
        	// 
        	this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOk.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnOk.Image = global::FBA.Resource.OK_24;
        	this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnOk.Location = new System.Drawing.Point(425, 3);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(99, 33);
        	this.btnOk.TabIndex = 0;
        	this.btnOk.Text = "   Search";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// cbHighlight
        	// 
        	this.cbHighlight.Checked = true;
        	this.cbHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.cbHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbHighlight.Location = new System.Drawing.Point(11, 9);
        	this.cbHighlight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.cbHighlight.Name = "cbHighlight";
        	this.cbHighlight.Size = new System.Drawing.Size(181, 22);
        	this.cbHighlight.TabIndex = 22;
        	this.cbHighlight.Text = "Select found strings";
        	this.cbHighlight.UseVisualStyleBackColor = true;
        	this.cbHighlight.Visible = false;
        	// 
        	// lbResultCount
        	// 
        	this.lbResultCount.AutoEllipsis = true;
        	this.lbResultCount.AutoSize = true;
        	this.lbResultCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbResultCount.ForeColor = System.Drawing.Color.MediumBlue;
        	this.lbResultCount.Location = new System.Drawing.Point(6, 160);
        	this.lbResultCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lbResultCount.Name = "lbResultCount";
        	this.lbResultCount.Size = new System.Drawing.Size(100, 18);
        	this.lbResultCount.TabIndex = 28;
        	this.lbResultCount.Text = "Found values:";
        	this.lbResultCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// lbSerachText
        	// 
        	this.lbSerachText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbSerachText.Location = new System.Drawing.Point(9, 2);
        	this.lbSerachText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lbSerachText.Name = "lbSerachText";
        	this.lbSerachText.Size = new System.Drawing.Size(96, 18);
        	this.lbSerachText.TabIndex = 6;
        	this.lbSerachText.Text = "Value search:";
        	// 
        	// DGResult
        	// 
        	this.DGResult.AllowUserToAddRows = false;
        	this.DGResult.AllowUserToDeleteRows = false;
        	this.DGResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.DGResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.DGResult.CommandAdd = false;
        	this.DGResult.CommandDel = false;
        	this.DGResult.CommandEdit = false;
        	this.DGResult.CommandExportToExcel = false;
        	this.DGResult.CommandFilter = false;
        	this.DGResult.CommandRefresh = false;
        	this.DGResult.CommandSaveASCSV = false;
        	this.DGResult.EnableHeadersVisualStyles = false;
        	this.DGResult.GroupEnabled = null;
        	this.DGResult.Location = new System.Drawing.Point(9, 180);
        	this.DGResult.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.DGResult.Name = "DGResult";
        	this.DGResult.Obj = null;
        	this.DGResult.PassedSec = null;
        	this.DGResult.ReadOnly = true;
        	this.DGResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.DGResult.Size = new System.Drawing.Size(512, 139);
        	this.DGResult.TabIndex = 16;
        	this.DGResult.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGResult_CellEnter);
        	// 
        	// cbCaseSensitivity
        	// 
        	this.cbCaseSensitivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbCaseSensitivity.Location = new System.Drawing.Point(11, 24);
        	this.cbCaseSensitivity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.cbCaseSensitivity.Name = "cbCaseSensitivity";
        	this.cbCaseSensitivity.Size = new System.Drawing.Size(180, 22);
        	this.cbCaseSensitivity.TabIndex = 17;
        	this.cbCaseSensitivity.Text = "Case sensitivity";
        	this.cbCaseSensitivity.UseVisualStyleBackColor = true;
        	// 
        	// rbPart1
        	// 
        	this.rbPart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.rbPart1.Location = new System.Drawing.Point(11, 22);
        	this.rbPart1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.rbPart1.Name = "rbPart1";
        	this.rbPart1.Size = new System.Drawing.Size(66, 20);
        	this.rbPart1.TabIndex = 19;
        	this.rbPart1.Text = "Exact match";
        	this.rbPart1.UseVisualStyleBackColor = true;
        	// 
        	// gpPosition
        	// 
        	this.gpPosition.Controls.Add(this.rbPart4);
        	this.gpPosition.Controls.Add(this.rbPart3);
        	this.gpPosition.Controls.Add(this.rbPart2);
        	this.gpPosition.Controls.Add(this.rbPart1);
        	this.gpPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.gpPosition.Location = new System.Drawing.Point(8, 49);
        	this.gpPosition.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.gpPosition.Name = "gpPosition";
        	this.gpPosition.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.gpPosition.Size = new System.Drawing.Size(109, 108);
        	this.gpPosition.TabIndex = 20;
        	this.gpPosition.TabStop = false;
        	this.gpPosition.Text = " Position ";
        	// 
        	// rbPart4
        	// 
        	this.rbPart4.Checked = true;
        	this.rbPart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.rbPart4.Location = new System.Drawing.Point(11, 79);
        	this.rbPart4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.rbPart4.Name = "rbPart4";
        	this.rbPart4.Size = new System.Drawing.Size(83, 20);
        	this.rbPart4.TabIndex = 22;
        	this.rbPart4.TabStop = true;
        	this.rbPart4.Text = "Contain text";
        	this.rbPart4.UseVisualStyleBackColor = true;
        	// 
        	// rbPart3
        	// 
        	this.rbPart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.rbPart3.Location = new System.Drawing.Point(11, 60);
        	this.rbPart3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.rbPart3.Name = "rbPart3";
        	this.rbPart3.Size = new System.Drawing.Size(91, 20);
        	this.rbPart3.TabIndex = 21;
        	this.rbPart3.Text = "Ends with text";
        	this.rbPart3.UseVisualStyleBackColor = true;
        	// 
        	// rbPart2
        	// 
        	this.rbPart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.rbPart2.Location = new System.Drawing.Point(11, 41);
        	this.rbPart2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.rbPart2.Name = "rbPart2";
        	this.rbPart2.Size = new System.Drawing.Size(96, 20);
        	this.rbPart2.TabIndex = 20;
        	this.rbPart2.Text = "Starts with text";
        	this.rbPart2.UseVisualStyleBackColor = true;
        	// 
        	// cbOnlyColumns
        	// 
        	this.cbOnlyColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbOnlyColumns.Location = new System.Drawing.Point(11, 43);
        	this.cbOnlyColumns.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.cbOnlyColumns.Name = "cbOnlyColumns";
        	this.cbOnlyColumns.Size = new System.Drawing.Size(212, 22);
        	this.cbOnlyColumns.TabIndex = 23;
        	this.cbOnlyColumns.Text = "Search in selected column";
        	this.cbOnlyColumns.UseVisualStyleBackColor = true;
        	// 
        	// rbDown
        	// 
        	this.rbDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.rbDown.Location = new System.Drawing.Point(11, 41);
        	this.rbDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.rbDown.Name = "rbDown";
        	this.rbDown.Size = new System.Drawing.Size(116, 22);
        	this.rbDown.TabIndex = 24;
        	this.rbDown.Text = "Search Down";
        	this.rbDown.UseVisualStyleBackColor = true;
        	// 
        	// rbUp
        	// 
        	this.rbUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.rbUp.Location = new System.Drawing.Point(11, 61);
        	this.rbUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.rbUp.Name = "rbUp";
        	this.rbUp.Size = new System.Drawing.Size(101, 22);
        	this.rbUp.TabIndex = 25;
        	this.rbUp.Text = "Search Up";
        	this.rbUp.UseVisualStyleBackColor = true;
        	// 
        	// gpSettings
        	// 
        	this.gpSettings.Controls.Add(this.cbOnlyArea);
        	this.gpSettings.Controls.Add(this.cbOnlyRows);
        	this.gpSettings.Controls.Add(this.cbCaseSensitivity);
        	this.gpSettings.Controls.Add(this.cbOnlyColumns);
        	this.gpSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.gpSettings.Location = new System.Drawing.Point(121, 49);
        	this.gpSettings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.gpSettings.Name = "gpSettings";
        	this.gpSettings.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.gpSettings.Size = new System.Drawing.Size(224, 108);
        	this.gpSettings.TabIndex = 26;
        	this.gpSettings.TabStop = false;
        	this.gpSettings.Text = "Settings ";
        	// 
        	// cbOnlyArea
        	// 
        	this.cbOnlyArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbOnlyArea.Location = new System.Drawing.Point(11, 81);
        	this.cbOnlyArea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.cbOnlyArea.Name = "cbOnlyArea";
        	this.cbOnlyArea.Size = new System.Drawing.Size(212, 22);
        	this.cbOnlyArea.TabIndex = 25;
        	this.cbOnlyArea.Text = "Search only in selected area";
        	this.cbOnlyArea.UseVisualStyleBackColor = true;
        	// 
        	// cbOnlyRows
        	// 
        	this.cbOnlyRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbOnlyRows.Location = new System.Drawing.Point(11, 62);
        	this.cbOnlyRows.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.cbOnlyRows.Name = "cbOnlyRows";
        	this.cbOnlyRows.Size = new System.Drawing.Size(212, 22);
        	this.cbOnlyRows.TabIndex = 24;
        	this.cbOnlyRows.Text = "Search in selected rows";
        	this.cbOnlyRows.UseVisualStyleBackColor = true;
        	// 
        	// gbDirection
        	// 
        	this.gbDirection.Controls.Add(this.rbAll);
        	this.gbDirection.Controls.Add(this.rbUp);
        	this.gbDirection.Controls.Add(this.rbDown);
        	this.gbDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.gbDirection.Location = new System.Drawing.Point(349, 49);
        	this.gbDirection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.gbDirection.Name = "gbDirection";
        	this.gbDirection.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.gbDirection.Size = new System.Drawing.Size(129, 107);
        	this.gbDirection.TabIndex = 27;
        	this.gbDirection.TabStop = false;
        	this.gbDirection.Text = "Direction";
        	// 
        	// rbAll
        	// 
        	this.rbAll.Checked = true;
        	this.rbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.rbAll.Location = new System.Drawing.Point(11, 22);
        	this.rbAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        	this.rbAll.Name = "rbAll";
        	this.rbAll.Size = new System.Drawing.Size(101, 22);
        	this.rbAll.TabIndex = 26;
        	this.rbAll.TabStop = true;
        	this.rbAll.Text = "Search All";
        	this.rbAll.UseVisualStyleBackColor = true;
        	// 
        	// EditFBA1
        	// 
        	this.EditFBA1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.EditFBA1.AttrBrief = "Main1.СтрахПродукт.Наим";
        	this.EditFBA1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        	this.EditFBA1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        	this.EditFBA1.ButtonDeleteVisible = true;
        	this.EditFBA1.ButtonEditVisible = false;
        	this.EditFBA1.ContextMenuEnabled = false;
        	this.EditFBA1.DataSource = null;
        	this.EditFBA1.DisplayMember = "";
        	this.EditFBA1.DockStyle = System.Windows.Forms.DockStyle.None;
        	this.EditFBA1.DrawMode = System.Windows.Forms.DrawMode.Normal;
        	this.EditFBA1.DropDownHeight = 106;
        	this.EditFBA1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        	this.EditFBA1.DropDownWidth = 315;
        	this.EditFBA1.DroppedDown = false;
        	this.EditFBA1.EditFormName = null;
        	this.EditFBA1.EntityBrief = "";
        	this.EditFBA1.ErrorIfNull = null;
        	this.EditFBA1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        	this.EditFBA1.FormatInfo = null;
        	this.EditFBA1.FormatString = "";
        	this.EditFBA1.FormattingEnabled = true;
        	this.EditFBA1.GroupEnabled = null;
        	this.EditFBA1.IntegralHeight = true;
        	this.EditFBA1.ItemHeight = 18;
        	this.EditFBA1.Location = new System.Drawing.Point(9, 22);
        	this.EditFBA1.Margin = new System.Windows.Forms.Padding(5);
        	this.EditFBA1.MaxDropDownItems = 50;
        	this.EditFBA1.MaxLength = 0;
        	this.EditFBA1.MSQL = "";
        	this.EditFBA1.Name = "EditFBA1";
        	this.EditFBA1.ObjectID = null;
        	this.EditFBA1.ObjectMaxCount = 5;
        	this.EditFBA1.ObjectOrderBy = null;
        	this.EditFBA1.ObjRef = null;
        	this.EditFBA1.OuterWHERE = null;
        	this.EditFBA1.ReadOnly = false;
        	this.EditFBA1.SaveParam = false;
        	this.EditFBA1.SaveType = null;
        	this.EditFBA1.SelectedItem = null;
        	this.EditFBA1.SelectedText = "";
        	this.EditFBA1.SelectedValue = null;
        	this.EditFBA1.SelectionLength = 0;
        	this.EditFBA1.SelectionStart = 0;
        	this.EditFBA1.Size = new System.Drawing.Size(513, 26);
        	this.EditFBA1.Sorted = false;
        	this.EditFBA1.SQL = "";
        	this.EditFBA1.TabIndex = 31;
        	this.EditFBA1.TextAdditional = null;
        	this.EditFBA1.ValueHistoryInItems = false;
        	this.EditFBA1.ValueMember = "";
        	this.EditFBA1.СustomQuery = null;
        	this.EditFBA1.DeleteClick += new System.EventHandler(this.EditFBA1_DeleteClick);
        	// 
        	// FormSearch
        	// 
        	this.ClientSize = new System.Drawing.Size(531, 365);
        	this.Controls.Add(this.EditFBA1);
        	this.Controls.Add(this.lbResultCount);
        	this.Controls.Add(this.gbDirection);
        	this.Controls.Add(this.gpSettings);
        	this.Controls.Add(this.gpPosition);
        	this.Controls.Add(this.lbSerachText);
        	this.Controls.Add(this.panelButton);
        	this.Controls.Add(this.DGResult);
        	this.Name = "FormSearch";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Search in the table";
        	this.TopMost = true;
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSearch_FormClosing);
        	this.panelButton.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.DGResult)).EndInit();
        	this.gpPosition.ResumeLayout(false);
        	this.gpSettings.ResumeLayout(false);
        	this.gbDirection.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        private EditFBA EditFBA1;
        private System.Windows.Forms.CheckBox cbOnlyArea;
        private System.Windows.Forms.CheckBox cbOnlyRows;
        private System.Windows.Forms.RadioButton rbAll;
    }
}
