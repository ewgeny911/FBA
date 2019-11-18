
/*
* Создано в SharpDevelop.
* Пользователь: Травин
* Дата: 11.03.2017
* Время: 21:30
*/

namespace FBA
{
    partial class FormServer
    {

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbLogServer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox cbAllowDirectConnection;
        private System.Windows.Forms.DataGridView dgClientAll;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabControl tabControlClient;

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private FBA.LabelFBA lbClientCount1;
        private FBA.LabelFBA lbAppStatus1;
        private System.Windows.Forms.TabPage tabPage2;
        private FBA.LabelFBA lbLog;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControlServer;

        private FBA.LabelFBA lbAppStatus2;
        private FBA.LabelFBA lbQuery2;
        private FBA.LabelFBA lbQuery1;
        private FBA.LabelFBA lbClientCount2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBoxSummary;
        private System.Windows.Forms.GroupBox groupBoxApp;
        private System.Windows.Forms.GroupBox groupBoxDatabase;
        private FBA.LabelFBA label5;
        private FBA.ComboBoxFBA cbConnection;
        private FBA.LabelFBA lbDatabaseStatus2;
        private FBA.LabelFBA lbDatabaseStatus1;
        private System.Windows.Forms.TabPage tabPage4;
        private FBA.LabelFBA lbLogQuery;
        private System.Windows.Forms.TextBox tbLogQuery;
        private System.Windows.Forms.Button btnDatabaseConnect;
        private System.Windows.Forms.Button btnConnectionList;
        private System.Windows.Forms.Button btnDatabaseDisconnect;
        private System.Windows.Forms.GroupBox groupBoxApp1;
        private System.Windows.Forms.Button btnOpenDirLog;
        private System.Windows.Forms.Button btnServerAppLogClear;
        private System.Windows.Forms.Button btnServerQueryLogClear;
        private System.Windows.Forms.Button btnStartAll;
        private FBA.ComboBoxFBA comboBoxPort;
        private FBA.LabelFBA lbPort;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.TabPage tabPage7;
        private FBA.LabelFBA lbLicenseCount2;
        private FBA.LabelFBA lbLicenseCount1;
        private System.Windows.Forms.Timer timerLicenseCount;
        private System.Windows.Forms.TabPage tabPage5;
        private FBA.DataGridViewFBA dgvLicense;
        private System.Windows.Forms.ToolStrip toolStripSQL;
        private System.Windows.Forms.ToolStripButton tbLicense1;
        private System.Windows.Forms.ToolStripButton tbLicense2;
        private System.Windows.Forms.ToolStripButton tbLicense3;
        private System.Windows.Forms.ToolStripButton tbLicense4;
        private System.Windows.Forms.ToolStripButton tbLicense5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbClient1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton tbClient2;
        private System.Windows.Forms.ToolStripButton tbClient3;
        private System.Windows.Forms.ToolStripButton tbClient5;
        private System.Windows.Forms.ToolStripButton tbClient6;
        private FBA.ComboBoxFBA cbTimeout;
        private FBA.LabelFBA label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
        	this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
        	this.cmServer = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cmServer1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmServer2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.tabPage4 = new System.Windows.Forms.TabPage();
        	this.btnServerQueryLogClear = new System.Windows.Forms.Button();
        	this.lbLogQuery = new FBA.LabelFBA();
        	this.tbLogQuery = new System.Windows.Forms.TextBox();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.btnOpenDirLog = new System.Windows.Forms.Button();
        	this.btnServerAppLogClear = new System.Windows.Forms.Button();
        	this.lbLog = new FBA.LabelFBA();
        	this.tbLogServer = new System.Windows.Forms.TextBox();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.tabControlClient = new System.Windows.Forms.TabControl();
        	this.tabPage7 = new System.Windows.Forms.TabPage();
        	this.dgClientCurrent = new System.Windows.Forms.DataGridView();
        	this.tabPage6 = new System.Windows.Forms.TabPage();
        	this.dgClientAll = new System.Windows.Forms.DataGridView();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.tbClient1 = new System.Windows.Forms.ToolStripButton();
        	this.tbClient2 = new System.Windows.Forms.ToolStripButton();
        	this.tbClient3 = new System.Windows.Forms.ToolStripButton();
        	this.tbClient5 = new System.Windows.Forms.ToolStripButton();
        	this.tbClient6 = new System.Windows.Forms.ToolStripButton();
        	this.tabPage3 = new System.Windows.Forms.TabPage();
        	this.groupBoxApp1 = new System.Windows.Forms.GroupBox();
        	this.btnStopAll = new System.Windows.Forms.Button();
        	this.btnStartAll = new System.Windows.Forms.Button();
        	this.groupBoxSummary = new System.Windows.Forms.GroupBox();
        	this.lbLicenseCount2 = new FBA.LabelFBA();
        	this.lbLicenseCount1 = new FBA.LabelFBA();
        	this.lbDatabaseStatus2 = new FBA.LabelFBA();
        	this.lbDatabaseStatus1 = new FBA.LabelFBA();
        	this.lbAppStatus2 = new FBA.LabelFBA();
        	this.lbAppStatus1 = new FBA.LabelFBA();
        	this.lbClientCount1 = new FBA.LabelFBA();
        	this.lbQuery2 = new FBA.LabelFBA();
        	this.lbClientCount2 = new FBA.LabelFBA();
        	this.lbQuery1 = new FBA.LabelFBA();
        	this.groupBoxApp = new System.Windows.Forms.GroupBox();
        	this.cbTimeout = new FBA.ComboBoxFBA();
        	this.label1 = new FBA.LabelFBA();
        	this.cbAllowDirectConnection = new System.Windows.Forms.CheckBox();
        	this.btnStop = new System.Windows.Forms.Button();
        	this.comboBoxPort = new FBA.ComboBoxFBA();
        	this.lbPort = new FBA.LabelFBA();
        	this.btnStart = new System.Windows.Forms.Button();
        	this.groupBoxDatabase = new System.Windows.Forms.GroupBox();
        	this.btnDatabaseDisconnect = new System.Windows.Forms.Button();
        	this.btnDatabaseConnect = new System.Windows.Forms.Button();
        	this.btnConnectionList = new System.Windows.Forms.Button();
        	this.label5 = new FBA.LabelFBA();
        	this.cbConnection = new FBA.ComboBoxFBA();
        	this.tabControlServer = new System.Windows.Forms.TabControl();
        	this.tabPage5 = new System.Windows.Forms.TabPage();
        	this.dgvLicense = new FBA.DataGridViewFBA();
        	this.toolStripSQL = new System.Windows.Forms.ToolStrip();
        	this.tbLicense1 = new System.Windows.Forms.ToolStripButton();
        	this.tbLicense2 = new System.Windows.Forms.ToolStripButton();
        	this.tbLicense3 = new System.Windows.Forms.ToolStripButton();
        	this.tbLicense4 = new System.Windows.Forms.ToolStripButton();
        	this.tbLicense5 = new System.Windows.Forms.ToolStripButton();
        	this.timerLicenseCount = new System.Windows.Forms.Timer(this.components);
        	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        	this.MainMenuN1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenuN1_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenuN2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.MainMenuN2_1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmServer.SuspendLayout();
        	this.tabPage4.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	this.tabControlClient.SuspendLayout();
        	this.tabPage7.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgClientCurrent)).BeginInit();
        	this.tabPage6.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgClientAll)).BeginInit();
        	this.toolStrip1.SuspendLayout();
        	this.tabPage3.SuspendLayout();
        	this.groupBoxApp1.SuspendLayout();
        	this.groupBoxSummary.SuspendLayout();
        	this.groupBoxApp.SuspendLayout();
        	this.groupBoxDatabase.SuspendLayout();
        	this.tabControlServer.SuspendLayout();
        	this.tabPage5.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvLicense)).BeginInit();
        	this.toolStripSQL.SuspendLayout();
        	this.menuStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// notifyIcon1
        	// 
        	this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
        	this.notifyIcon1.BalloonTipText = "Server App FBA\r\n";
        	this.notifyIcon1.BalloonTipTitle = "Server App FBA";
        	this.notifyIcon1.ContextMenuStrip = this.cmServer;
        	this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
        	this.notifyIcon1.Text = "Server App FBA";
        	this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
        	// 
        	// cmServer
        	// 
        	this.cmServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmServer1,
			this.cmServer2});
        	this.cmServer.Name = "cmServer";
        	this.cmServer.Size = new System.Drawing.Size(104, 48);
        	// 
        	// cmServer1
        	// 
        	this.cmServer1.Name = "cmServer1";
        	this.cmServer1.Size = new System.Drawing.Size(103, 22);
        	this.cmServer1.Text = "Show";
        	// 
        	// cmServer2
        	// 
        	this.cmServer2.Name = "cmServer2";
        	this.cmServer2.Size = new System.Drawing.Size(103, 22);
        	this.cmServer2.Text = "Exit";
        	// 
        	// tabPage4
        	// 
        	this.tabPage4.Controls.Add(this.btnServerQueryLogClear);
        	this.tabPage4.Controls.Add(this.lbLogQuery);
        	this.tabPage4.Controls.Add(this.tbLogQuery);
        	this.tabPage4.Location = new System.Drawing.Point(4, 26);
        	this.tabPage4.Name = "tabPage4";
        	this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage4.Size = new System.Drawing.Size(802, 443);
        	this.tabPage4.TabIndex = 3;
        	this.tabPage4.Text = "Queries Log";
        	this.tabPage4.UseVisualStyleBackColor = true;
        	// 
        	// btnServerQueryLogClear
        	// 
        	this.btnServerQueryLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnServerQueryLogClear.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnServerQueryLogClear.Location = new System.Drawing.Point(693, 5);
        	this.btnServerQueryLogClear.Name = "btnServerQueryLogClear";
        	this.btnServerQueryLogClear.Size = new System.Drawing.Size(99, 30);
        	this.btnServerQueryLogClear.TabIndex = 15;
        	this.btnServerQueryLogClear.Text = "Clear";
        	this.btnServerQueryLogClear.UseVisualStyleBackColor = true;
        	this.btnServerQueryLogClear.Click += new System.EventHandler(this.btnServerAppLogClear_Click);
        	// 
        	// lbLogQuery
        	// 
        	this.lbLogQuery.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbLogQuery.Location = new System.Drawing.Point(12, 10);
        	this.lbLogQuery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbLogQuery.Name = "lbLogQuery";
        	this.lbLogQuery.Size = new System.Drawing.Size(196, 22);
        	this.lbLogQuery.StarColor = System.Drawing.Color.Crimson;
        	this.lbLogQuery.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbLogQuery.StarOffsetX = 2;
        	this.lbLogQuery.StarOffsetY = 0;
        	this.lbLogQuery.StarShow = false;
        	this.lbLogQuery.StarText = "*";
        	this.lbLogQuery.TabIndex = 14;
        	this.lbLogQuery.Text = "Log queries of users";
        	// 
        	// tbLogQuery
        	// 
        	this.tbLogQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbLogQuery.BackColor = System.Drawing.SystemColors.Info;
        	this.tbLogQuery.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbLogQuery.Location = new System.Drawing.Point(11, 37);
        	this.tbLogQuery.Margin = new System.Windows.Forms.Padding(4);
        	this.tbLogQuery.Multiline = true;
        	this.tbLogQuery.Name = "tbLogQuery";
        	this.tbLogQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.tbLogQuery.Size = new System.Drawing.Size(781, 397);
        	this.tbLogQuery.TabIndex = 11;
        	this.tbLogQuery.WordWrap = false;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.btnOpenDirLog);
        	this.tabPage1.Controls.Add(this.btnServerAppLogClear);
        	this.tabPage1.Controls.Add(this.lbLog);
        	this.tabPage1.Controls.Add(this.tbLogServer);
        	this.tabPage1.Location = new System.Drawing.Point(4, 26);
        	this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
        	this.tabPage1.Size = new System.Drawing.Size(802, 443);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "App Server Log";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// btnOpenDirLog
        	// 
        	this.btnOpenDirLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnOpenDirLog.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnOpenDirLog.Location = new System.Drawing.Point(536, 5);
        	this.btnOpenDirLog.Name = "btnOpenDirLog";
        	this.btnOpenDirLog.Size = new System.Drawing.Size(151, 30);
        	this.btnOpenDirLog.TabIndex = 50;
        	this.btnOpenDirLog.Text = "Open Log Directory";
        	this.btnOpenDirLog.UseVisualStyleBackColor = true;
        	this.btnOpenDirLog.Click += new System.EventHandler(this.btnOpenDirLog_Click);
        	// 
        	// btnServerAppLogClear
        	// 
        	this.btnServerAppLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnServerAppLogClear.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnServerAppLogClear.Location = new System.Drawing.Point(693, 5);
        	this.btnServerAppLogClear.Name = "btnServerAppLogClear";
        	this.btnServerAppLogClear.Size = new System.Drawing.Size(99, 30);
        	this.btnServerAppLogClear.TabIndex = 14;
        	this.btnServerAppLogClear.Text = "Clear";
        	this.btnServerAppLogClear.UseVisualStyleBackColor = true;
        	this.btnServerAppLogClear.Click += new System.EventHandler(this.btnServerAppLogClear_Click);
        	// 
        	// lbLog
        	// 
        	this.lbLog.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbLog.Location = new System.Drawing.Point(12, 10);
        	this.lbLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbLog.Name = "lbLog";
        	this.lbLog.Size = new System.Drawing.Size(241, 24);
        	this.lbLog.StarColor = System.Drawing.Color.Crimson;
        	this.lbLog.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbLog.StarOffsetX = 2;
        	this.lbLog.StarOffsetY = 0;
        	this.lbLog.StarShow = false;
        	this.lbLog.StarText = "*";
        	this.lbLog.TabIndex = 13;
        	this.lbLog.Text = "Application Server Log";
        	// 
        	// tbLogServer
        	// 
        	this.tbLogServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbLogServer.BackColor = System.Drawing.SystemColors.Info;
        	this.tbLogServer.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbLogServer.Location = new System.Drawing.Point(11, 37);
        	this.tbLogServer.Margin = new System.Windows.Forms.Padding(4);
        	this.tbLogServer.Multiline = true;
        	this.tbLogServer.Name = "tbLogServer";
        	this.tbLogServer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.tbLogServer.Size = new System.Drawing.Size(781, 397);
        	this.tbLogServer.TabIndex = 10;
        	this.tbLogServer.WordWrap = false;
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.tabControlClient);
        	this.tabPage2.Controls.Add(this.toolStrip1);
        	this.tabPage2.Location = new System.Drawing.Point(4, 26);
        	this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
        	this.tabPage2.Size = new System.Drawing.Size(802, 443);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "Client list";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// tabControlClient
        	// 
        	this.tabControlClient.Controls.Add(this.tabPage7);
        	this.tabControlClient.Controls.Add(this.tabPage6);
        	this.tabControlClient.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControlClient.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabControlClient.Location = new System.Drawing.Point(4, 30);
        	this.tabControlClient.Name = "tabControlClient";
        	this.tabControlClient.SelectedIndex = 0;
        	this.tabControlClient.Size = new System.Drawing.Size(794, 409);
        	this.tabControlClient.TabIndex = 13;
        	// 
        	// tabPage7
        	// 
        	this.tabPage7.Controls.Add(this.dgClientCurrent);
        	this.tabPage7.Location = new System.Drawing.Point(4, 26);
        	this.tabPage7.Name = "tabPage7";
        	this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage7.Size = new System.Drawing.Size(786, 379);
        	this.tabPage7.TabIndex = 2;
        	this.tabPage7.Text = "Current clients";
        	this.tabPage7.UseVisualStyleBackColor = true;
        	// 
        	// dgClientCurrent
        	// 
        	this.dgClientCurrent.AllowUserToAddRows = false;
        	this.dgClientCurrent.AllowUserToDeleteRows = false;
        	this.dgClientCurrent.AllowUserToOrderColumns = true;
        	this.dgClientCurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgClientCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgClientCurrent.EnableHeadersVisualStyles = false;
        	this.dgClientCurrent.Location = new System.Drawing.Point(3, 3);
        	this.dgClientCurrent.Margin = new System.Windows.Forms.Padding(4);
        	this.dgClientCurrent.Name = "dgClientCurrent";
        	this.dgClientCurrent.ReadOnly = true;
        	this.dgClientCurrent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgClientCurrent.Size = new System.Drawing.Size(780, 373);
        	this.dgClientCurrent.TabIndex = 13;
        	// 
        	// tabPage6
        	// 
        	this.tabPage6.Controls.Add(this.dgClientAll);
        	this.tabPage6.Location = new System.Drawing.Point(4, 26);
        	this.tabPage6.Name = "tabPage6";
        	this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage6.Size = new System.Drawing.Size(786, 379);
        	this.tabPage6.TabIndex = 1;
        	this.tabPage6.Text = "    All clients    ";
        	this.tabPage6.UseVisualStyleBackColor = true;
        	// 
        	// dgClientAll
        	// 
        	this.dgClientAll.AllowUserToAddRows = false;
        	this.dgClientAll.AllowUserToDeleteRows = false;
        	this.dgClientAll.AllowUserToOrderColumns = true;
        	this.dgClientAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgClientAll.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgClientAll.EnableHeadersVisualStyles = false;
        	this.dgClientAll.Location = new System.Drawing.Point(3, 3);
        	this.dgClientAll.Margin = new System.Windows.Forms.Padding(4);
        	this.dgClientAll.Name = "dgClientAll";
        	this.dgClientAll.ReadOnly = true;
        	this.dgClientAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgClientAll.Size = new System.Drawing.Size(780, 373);
        	this.dgClientAll.TabIndex = 12;
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.AutoSize = false;
        	this.toolStrip1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbClient1,
			this.tbClient2,
			this.tbClient3,
			this.tbClient5,
			this.tbClient6});
        	this.toolStrip1.Location = new System.Drawing.Point(4, 4);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(794, 26);
        	this.toolStrip1.TabIndex = 17;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// tbClient1
        	// 
        	this.tbClient1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbClient1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbClient1.Name = "tbClient1";
        	this.tbClient1.Size = new System.Drawing.Size(64, 23);
        	this.tbClient1.Text = "Refresh";
        	this.tbClient1.ToolTipText = "Refresh table of licenses";
        	this.tbClient1.Click += new System.EventHandler(this.TbClient1Click);
        	// 
        	// tbClient2
        	// 
        	this.tbClient2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbClient2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbClient2.Name = "tbClient2";
        	this.tbClient2.Size = new System.Drawing.Size(111, 23);
        	this.tbClient2.Text = "Send message";
        	this.tbClient2.Click += new System.EventHandler(this.TbClient1Click);
        	// 
        	// tbClient3
        	// 
        	this.tbClient3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbClient3.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbClient3.Name = "tbClient3";
        	this.tbClient3.Size = new System.Drawing.Size(88, 23);
        	this.tbClient3.Text = "Close client";
        	this.tbClient3.Click += new System.EventHandler(this.TbClient1Click);
        	// 
        	// tbClient5
        	// 
        	this.tbClient5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbClient5.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbClient5.Name = "tbClient5";
        	this.tbClient5.Size = new System.Drawing.Size(43, 23);
        	this.tbClient5.Text = "Mark";
        	this.tbClient5.Click += new System.EventHandler(this.TbClient1Click);
        	// 
        	// tbClient6
        	// 
        	this.tbClient6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbClient6.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbClient6.Name = "tbClient6";
        	this.tbClient6.Size = new System.Drawing.Size(61, 23);
        	this.tbClient6.Text = "UnMark";
        	this.tbClient6.Click += new System.EventHandler(this.TbClient1Click);
        	// 
        	// tabPage3
        	// 
        	this.tabPage3.Controls.Add(this.groupBoxApp1);
        	this.tabPage3.Controls.Add(this.groupBoxSummary);
        	this.tabPage3.Controls.Add(this.groupBoxApp);
        	this.tabPage3.Controls.Add(this.groupBoxDatabase);
        	this.tabPage3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabPage3.Location = new System.Drawing.Point(4, 26);
        	this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
        	this.tabPage3.Name = "tabPage3";
        	this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
        	this.tabPage3.Size = new System.Drawing.Size(802, 443);
        	this.tabPage3.TabIndex = 2;
        	this.tabPage3.Text = "Connection";
        	this.tabPage3.UseVisualStyleBackColor = true;
        	// 
        	// groupBoxApp1
        	// 
        	this.groupBoxApp1.Controls.Add(this.btnStopAll);
        	this.groupBoxApp1.Controls.Add(this.btnStartAll);
        	this.groupBoxApp1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.groupBoxApp1.Location = new System.Drawing.Point(548, 4);
        	this.groupBoxApp1.Name = "groupBoxApp1";
        	this.groupBoxApp1.Size = new System.Drawing.Size(241, 431);
        	this.groupBoxApp1.TabIndex = 50;
        	this.groupBoxApp1.TabStop = false;
        	this.groupBoxApp1.Text = " Database / App ";
        	// 
        	// btnStopAll
        	// 
        	this.btnStopAll.Enabled = false;
        	this.btnStopAll.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnStopAll.ForeColor = System.Drawing.Color.Red;
        	this.btnStopAll.Location = new System.Drawing.Point(11, 91);
        	this.btnStopAll.Name = "btnStopAll";
        	this.btnStopAll.Size = new System.Drawing.Size(206, 60);
        	this.btnStopAll.TabIndex = 52;
        	this.btnStopAll.Text = "Stop all";
        	this.btnStopAll.UseVisualStyleBackColor = true;
        	this.btnStopAll.Click += new System.EventHandler(this.BtnStartAllClick);
        	// 
        	// btnStartAll
        	// 
        	this.btnStartAll.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnStartAll.ForeColor = System.Drawing.Color.ForestGreen;
        	this.btnStartAll.Location = new System.Drawing.Point(11, 23);
        	this.btnStartAll.Name = "btnStartAll";
        	this.btnStartAll.Size = new System.Drawing.Size(206, 60);
        	this.btnStartAll.TabIndex = 51;
        	this.btnStartAll.Text = "Start all";
        	this.btnStartAll.UseVisualStyleBackColor = true;
        	this.btnStartAll.Click += new System.EventHandler(this.BtnStartAllClick);
        	// 
        	// groupBoxSummary
        	// 
        	this.groupBoxSummary.Controls.Add(this.lbLicenseCount2);
        	this.groupBoxSummary.Controls.Add(this.lbLicenseCount1);
        	this.groupBoxSummary.Controls.Add(this.lbDatabaseStatus2);
        	this.groupBoxSummary.Controls.Add(this.lbDatabaseStatus1);
        	this.groupBoxSummary.Controls.Add(this.lbAppStatus2);
        	this.groupBoxSummary.Controls.Add(this.lbAppStatus1);
        	this.groupBoxSummary.Controls.Add(this.lbClientCount1);
        	this.groupBoxSummary.Controls.Add(this.lbQuery2);
        	this.groupBoxSummary.Controls.Add(this.lbClientCount2);
        	this.groupBoxSummary.Controls.Add(this.lbQuery1);
        	this.groupBoxSummary.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.groupBoxSummary.Location = new System.Drawing.Point(11, 273);
        	this.groupBoxSummary.Name = "groupBoxSummary";
        	this.groupBoxSummary.Size = new System.Drawing.Size(527, 162);
        	this.groupBoxSummary.TabIndex = 48;
        	this.groupBoxSummary.TabStop = false;
        	this.groupBoxSummary.Text = " Summary ";
        	// 
        	// lbLicenseCount2
        	// 
        	this.lbLicenseCount2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbLicenseCount2.ForeColor = System.Drawing.Color.Black;
        	this.lbLicenseCount2.Location = new System.Drawing.Point(158, 130);
        	this.lbLicenseCount2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbLicenseCount2.Name = "lbLicenseCount2";
        	this.lbLicenseCount2.Size = new System.Drawing.Size(227, 21);
        	this.lbLicenseCount2.StarColor = System.Drawing.Color.Crimson;
        	this.lbLicenseCount2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbLicenseCount2.StarOffsetX = 2;
        	this.lbLicenseCount2.StarOffsetY = 0;
        	this.lbLicenseCount2.StarShow = false;
        	this.lbLicenseCount2.StarText = "*";
        	this.lbLicenseCount2.TabIndex = 49;
        	this.lbLicenseCount2.Text = "0";
        	// 
        	// lbLicenseCount1
        	// 
        	this.lbLicenseCount1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbLicenseCount1.ForeColor = System.Drawing.Color.Black;
        	this.lbLicenseCount1.Location = new System.Drawing.Point(8, 130);
        	this.lbLicenseCount1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbLicenseCount1.Name = "lbLicenseCount1";
        	this.lbLicenseCount1.Size = new System.Drawing.Size(122, 20);
        	this.lbLicenseCount1.StarColor = System.Drawing.Color.Crimson;
        	this.lbLicenseCount1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbLicenseCount1.StarOffsetX = 2;
        	this.lbLicenseCount1.StarOffsetY = 0;
        	this.lbLicenseCount1.StarShow = false;
        	this.lbLicenseCount1.StarText = "*";
        	this.lbLicenseCount1.TabIndex = 48;
        	this.lbLicenseCount1.Text = "License count:";
        	// 
        	// lbDatabaseStatus2
        	// 
        	this.lbDatabaseStatus2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbDatabaseStatus2.ForeColor = System.Drawing.Color.Red;
        	this.lbDatabaseStatus2.Location = new System.Drawing.Point(158, 30);
        	this.lbDatabaseStatus2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbDatabaseStatus2.Name = "lbDatabaseStatus2";
        	this.lbDatabaseStatus2.Size = new System.Drawing.Size(150, 22);
        	this.lbDatabaseStatus2.StarColor = System.Drawing.Color.Crimson;
        	this.lbDatabaseStatus2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbDatabaseStatus2.StarOffsetX = 2;
        	this.lbDatabaseStatus2.StarOffsetY = 0;
        	this.lbDatabaseStatus2.StarShow = false;
        	this.lbDatabaseStatus2.StarText = "*";
        	this.lbDatabaseStatus2.TabIndex = 47;
        	this.lbDatabaseStatus2.Text = "Not connected";
        	// 
        	// lbDatabaseStatus1
        	// 
        	this.lbDatabaseStatus1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbDatabaseStatus1.ForeColor = System.Drawing.Color.Black;
        	this.lbDatabaseStatus1.Location = new System.Drawing.Point(8, 30);
        	this.lbDatabaseStatus1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbDatabaseStatus1.Name = "lbDatabaseStatus1";
        	this.lbDatabaseStatus1.Size = new System.Drawing.Size(136, 20);
        	this.lbDatabaseStatus1.StarColor = System.Drawing.Color.Crimson;
        	this.lbDatabaseStatus1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbDatabaseStatus1.StarOffsetX = 2;
        	this.lbDatabaseStatus1.StarOffsetY = 0;
        	this.lbDatabaseStatus1.StarShow = false;
        	this.lbDatabaseStatus1.StarText = "*";
        	this.lbDatabaseStatus1.TabIndex = 46;
        	this.lbDatabaseStatus1.Text = "Database status:";
        	// 
        	// lbAppStatus2
        	// 
        	this.lbAppStatus2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbAppStatus2.ForeColor = System.Drawing.Color.Red;
        	this.lbAppStatus2.Location = new System.Drawing.Point(158, 55);
        	this.lbAppStatus2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbAppStatus2.Name = "lbAppStatus2";
        	this.lbAppStatus2.Size = new System.Drawing.Size(150, 22);
        	this.lbAppStatus2.StarColor = System.Drawing.Color.Crimson;
        	this.lbAppStatus2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbAppStatus2.StarOffsetX = 2;
        	this.lbAppStatus2.StarOffsetY = 0;
        	this.lbAppStatus2.StarShow = false;
        	this.lbAppStatus2.StarText = "*";
        	this.lbAppStatus2.TabIndex = 42;
        	this.lbAppStatus2.Text = "Stopped";
        	// 
        	// lbAppStatus1
        	// 
        	this.lbAppStatus1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbAppStatus1.ForeColor = System.Drawing.Color.Black;
        	this.lbAppStatus1.Location = new System.Drawing.Point(8, 55);
        	this.lbAppStatus1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbAppStatus1.Name = "lbAppStatus1";
        	this.lbAppStatus1.Size = new System.Drawing.Size(136, 20);
        	this.lbAppStatus1.StarColor = System.Drawing.Color.Crimson;
        	this.lbAppStatus1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbAppStatus1.StarOffsetX = 2;
        	this.lbAppStatus1.StarOffsetY = 0;
        	this.lbAppStatus1.StarShow = false;
        	this.lbAppStatus1.StarText = "*";
        	this.lbAppStatus1.TabIndex = 40;
        	this.lbAppStatus1.Text = "App Server status:";
        	// 
        	// lbClientCount1
        	// 
        	this.lbClientCount1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbClientCount1.ForeColor = System.Drawing.Color.Black;
        	this.lbClientCount1.Location = new System.Drawing.Point(8, 80);
        	this.lbClientCount1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbClientCount1.Name = "lbClientCount1";
        	this.lbClientCount1.Size = new System.Drawing.Size(136, 20);
        	this.lbClientCount1.StarColor = System.Drawing.Color.Crimson;
        	this.lbClientCount1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbClientCount1.StarOffsetX = 2;
        	this.lbClientCount1.StarOffsetY = 0;
        	this.lbClientCount1.StarShow = false;
        	this.lbClientCount1.StarText = "*";
        	this.lbClientCount1.TabIndex = 41;
        	this.lbClientCount1.Text = "Number of Clients:";
        	// 
        	// lbQuery2
        	// 
        	this.lbQuery2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbQuery2.ForeColor = System.Drawing.Color.Black;
        	this.lbQuery2.Location = new System.Drawing.Point(158, 105);
        	this.lbQuery2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbQuery2.Name = "lbQuery2";
        	this.lbQuery2.Size = new System.Drawing.Size(182, 21);
        	this.lbQuery2.StarColor = System.Drawing.Color.Crimson;
        	this.lbQuery2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbQuery2.StarOffsetX = 2;
        	this.lbQuery2.StarOffsetY = 0;
        	this.lbQuery2.StarShow = false;
        	this.lbQuery2.StarText = "*";
        	this.lbQuery2.TabIndex = 45;
        	this.lbQuery2.Text = "0";
        	// 
        	// lbClientCount2
        	// 
        	this.lbClientCount2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbClientCount2.Location = new System.Drawing.Point(158, 80);
        	this.lbClientCount2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbClientCount2.Name = "lbClientCount2";
        	this.lbClientCount2.Size = new System.Drawing.Size(150, 23);
        	this.lbClientCount2.StarColor = System.Drawing.Color.Crimson;
        	this.lbClientCount2.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbClientCount2.StarOffsetX = 2;
        	this.lbClientCount2.StarOffsetY = 0;
        	this.lbClientCount2.StarShow = false;
        	this.lbClientCount2.StarText = "*";
        	this.lbClientCount2.TabIndex = 43;
        	this.lbClientCount2.Text = "0";
        	// 
        	// lbQuery1
        	// 
        	this.lbQuery1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbQuery1.ForeColor = System.Drawing.Color.Black;
        	this.lbQuery1.Location = new System.Drawing.Point(8, 105);
        	this.lbQuery1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lbQuery1.Name = "lbQuery1";
        	this.lbQuery1.Size = new System.Drawing.Size(122, 20);
        	this.lbQuery1.StarColor = System.Drawing.Color.Crimson;
        	this.lbQuery1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbQuery1.StarOffsetX = 2;
        	this.lbQuery1.StarOffsetY = 0;
        	this.lbQuery1.StarShow = false;
        	this.lbQuery1.StarText = "*";
        	this.lbQuery1.TabIndex = 44;
        	this.lbQuery1.Text = "Query count:";
        	// 
        	// groupBoxApp
        	// 
        	this.groupBoxApp.Controls.Add(this.cbTimeout);
        	this.groupBoxApp.Controls.Add(this.label1);
        	this.groupBoxApp.Controls.Add(this.cbAllowDirectConnection);
        	this.groupBoxApp.Controls.Add(this.btnStop);
        	this.groupBoxApp.Controls.Add(this.comboBoxPort);
        	this.groupBoxApp.Controls.Add(this.lbPort);
        	this.groupBoxApp.Controls.Add(this.btnStart);
        	this.groupBoxApp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.groupBoxApp.Location = new System.Drawing.Point(11, 106);
        	this.groupBoxApp.Margin = new System.Windows.Forms.Padding(4);
        	this.groupBoxApp.Name = "groupBoxApp";
        	this.groupBoxApp.Padding = new System.Windows.Forms.Padding(4);
        	this.groupBoxApp.Size = new System.Drawing.Size(525, 165);
        	this.groupBoxApp.TabIndex = 47;
        	this.groupBoxApp.TabStop = false;
        	this.groupBoxApp.Text = " Application Server";
        	// 
        	// cbTimeout
        	// 
        	this.cbTimeout.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbTimeout.FormatString = "0000";
        	this.cbTimeout.FormattingEnabled = true;
        	this.cbTimeout.Items.AddRange(new object[] {
			"7100",
			"7300",
			"7400",
			"7500",
			""});
        	this.cbTimeout.Location = new System.Drawing.Point(219, 59);
        	this.cbTimeout.Name = "cbTimeout";
        	this.cbTimeout.Size = new System.Drawing.Size(121, 25);
        	this.cbTimeout.TabIndex = 61;
        	this.cbTimeout.Text = "300";
        	// 
        	// label1
        	// 
        	this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(8, 62);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(174, 23);
        	this.label1.StarColor = System.Drawing.Color.Crimson;
        	this.label1.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label1.StarOffsetX = 2;
        	this.label1.StarOffsetY = 0;
        	this.label1.StarShow = false;
        	this.label1.StarText = "*";
        	this.label1.TabIndex = 60;
        	this.label1.Text = "Timeout (sec):";
        	// 
        	// cbAllowDirectConnection
        	// 
        	this.cbAllowDirectConnection.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbAllowDirectConnection.Location = new System.Drawing.Point(6, 91);
        	this.cbAllowDirectConnection.Name = "cbAllowDirectConnection";
        	this.cbAllowDirectConnection.Size = new System.Drawing.Size(509, 24);
        	this.cbAllowDirectConnection.TabIndex = 59;
        	this.cbAllowDirectConnection.Text = "Allow direct connection to the database without Application Server\r\n\r\n";
        	this.cbAllowDirectConnection.UseVisualStyleBackColor = true;
        	// 
        	// btnStop
        	// 
        	this.btnStop.Enabled = false;
        	this.btnStop.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnStop.Location = new System.Drawing.Point(149, 123);
        	this.btnStop.Margin = new System.Windows.Forms.Padding(4);
        	this.btnStop.Name = "btnStop";
        	this.btnStop.Size = new System.Drawing.Size(180, 30);
        	this.btnStop.TabIndex = 42;
        	this.btnStop.Text = "Stop App Server";
        	this.btnStop.UseVisualStyleBackColor = true;
        	this.btnStop.Click += new System.EventHandler(this.BtnStartAllClick);
        	// 
        	// comboBoxPort
        	// 
        	this.comboBoxPort.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.comboBoxPort.FormatString = "0000";
        	this.comboBoxPort.FormattingEnabled = true;
        	this.comboBoxPort.Items.AddRange(new object[] {
			"7100",
			"7300",
			"7400",
			"7500",
			""});
        	this.comboBoxPort.Location = new System.Drawing.Point(219, 27);
        	this.comboBoxPort.Name = "comboBoxPort";
        	this.comboBoxPort.Size = new System.Drawing.Size(121, 25);
        	this.comboBoxPort.TabIndex = 57;
        	// 
        	// lbPort
        	// 
        	this.lbPort.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbPort.Location = new System.Drawing.Point(7, 30);
        	this.lbPort.Name = "lbPort";
        	this.lbPort.Size = new System.Drawing.Size(210, 23);
        	this.lbPort.StarColor = System.Drawing.Color.Crimson;
        	this.lbPort.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.lbPort.StarOffsetX = 2;
        	this.lbPort.StarOffsetY = 0;
        	this.lbPort.StarShow = false;
        	this.lbPort.StarText = "*";
        	this.lbPort.TabIndex = 58;
        	this.lbPort.Text = "Port of the application server:";
        	// 
        	// btnStart
        	// 
        	this.btnStart.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnStart.Location = new System.Drawing.Point(337, 123);
        	this.btnStart.Margin = new System.Windows.Forms.Padding(4);
        	this.btnStart.Name = "btnStart";
        	this.btnStart.Size = new System.Drawing.Size(180, 30);
        	this.btnStart.TabIndex = 40;
        	this.btnStart.Text = "Start App Server";
        	this.btnStart.UseVisualStyleBackColor = true;
        	this.btnStart.Click += new System.EventHandler(this.BtnStartAllClick);
        	// 
        	// groupBoxDatabase
        	// 
        	this.groupBoxDatabase.Controls.Add(this.btnDatabaseDisconnect);
        	this.groupBoxDatabase.Controls.Add(this.btnDatabaseConnect);
        	this.groupBoxDatabase.Controls.Add(this.btnConnectionList);
        	this.groupBoxDatabase.Controls.Add(this.label5);
        	this.groupBoxDatabase.Controls.Add(this.cbConnection);
        	this.groupBoxDatabase.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.groupBoxDatabase.Location = new System.Drawing.Point(9, 4);
        	this.groupBoxDatabase.Margin = new System.Windows.Forms.Padding(4);
        	this.groupBoxDatabase.Name = "groupBoxDatabase";
        	this.groupBoxDatabase.Padding = new System.Windows.Forms.Padding(4);
        	this.groupBoxDatabase.Size = new System.Drawing.Size(527, 100);
        	this.groupBoxDatabase.TabIndex = 46;
        	this.groupBoxDatabase.TabStop = false;
        	this.groupBoxDatabase.Text = " Database ";
        	// 
        	// btnDatabaseDisconnect
        	// 
        	this.btnDatabaseDisconnect.Enabled = false;
        	this.btnDatabaseDisconnect.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnDatabaseDisconnect.Location = new System.Drawing.Point(421, 59);
        	this.btnDatabaseDisconnect.Margin = new System.Windows.Forms.Padding(4);
        	this.btnDatabaseDisconnect.Name = "btnDatabaseDisconnect";
        	this.btnDatabaseDisconnect.Size = new System.Drawing.Size(98, 30);
        	this.btnDatabaseDisconnect.TabIndex = 43;
        	this.btnDatabaseDisconnect.Text = "Disconnect";
        	this.btnDatabaseDisconnect.UseVisualStyleBackColor = true;
        	this.btnDatabaseDisconnect.Click += new System.EventHandler(this.BtnStartAllClick);
        	// 
        	// btnDatabaseConnect
        	// 
        	this.btnDatabaseConnect.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnDatabaseConnect.Location = new System.Drawing.Point(324, 59);
        	this.btnDatabaseConnect.Margin = new System.Windows.Forms.Padding(4);
        	this.btnDatabaseConnect.Name = "btnDatabaseConnect";
        	this.btnDatabaseConnect.Size = new System.Drawing.Size(91, 30);
        	this.btnDatabaseConnect.TabIndex = 42;
        	this.btnDatabaseConnect.Text = "Connect";
        	this.btnDatabaseConnect.UseVisualStyleBackColor = true;
        	this.btnDatabaseConnect.Click += new System.EventHandler(this.BtnStartAllClick);
        	// 
        	// btnConnectionList
        	// 
        	this.btnConnectionList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.btnConnectionList.Location = new System.Drawing.Point(152, 59);
        	this.btnConnectionList.Margin = new System.Windows.Forms.Padding(4);
        	this.btnConnectionList.Name = "btnConnectionList";
        	this.btnConnectionList.Size = new System.Drawing.Size(166, 30);
        	this.btnConnectionList.TabIndex = 41;
        	this.btnConnectionList.Text = "Change list connection";
        	this.btnConnectionList.UseVisualStyleBackColor = true;
        	this.btnConnectionList.Click += new System.EventHandler(this.BtnStartAllClick);
        	// 
        	// label5
        	// 
        	this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label5.Location = new System.Drawing.Point(8, 30);
        	this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(136, 32);
        	this.label5.StarColor = System.Drawing.Color.Crimson;
        	this.label5.StarFont = new System.Drawing.Font("Arial", 20F);
        	this.label5.StarOffsetX = 2;
        	this.label5.StarOffsetY = 0;
        	this.label5.StarShow = false;
        	this.label5.StarText = "*";
        	this.label5.TabIndex = 33;
        	this.label5.Text = "Connection name:";
        	// 
        	// cbConnection
        	// 
        	this.cbConnection.BackColor = System.Drawing.SystemColors.Info;
        	this.cbConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cbConnection.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.cbConnection.FormattingEnabled = true;
        	this.cbConnection.IntegralHeight = false;
        	this.cbConnection.Location = new System.Drawing.Point(152, 25);
        	this.cbConnection.Margin = new System.Windows.Forms.Padding(4);
        	this.cbConnection.MaxDropDownItems = 10;
        	this.cbConnection.Name = "cbConnection";
        	this.cbConnection.Size = new System.Drawing.Size(367, 25);
        	this.cbConnection.TabIndex = 34;
        	// 
        	// tabControlServer
        	// 
        	this.tabControlServer.Controls.Add(this.tabPage3);
        	this.tabControlServer.Controls.Add(this.tabPage2);
        	this.tabControlServer.Controls.Add(this.tabPage1);
        	this.tabControlServer.Controls.Add(this.tabPage4);
        	this.tabControlServer.Controls.Add(this.tabPage5);
        	this.tabControlServer.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControlServer.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tabControlServer.Location = new System.Drawing.Point(0, 25);
        	this.tabControlServer.Margin = new System.Windows.Forms.Padding(4);
        	this.tabControlServer.Name = "tabControlServer";
        	this.tabControlServer.SelectedIndex = 0;
        	this.tabControlServer.Size = new System.Drawing.Size(810, 473);
        	this.tabControlServer.TabIndex = 7;
        	// 
        	// tabPage5
        	// 
        	this.tabPage5.Controls.Add(this.dgvLicense);
        	this.tabPage5.Controls.Add(this.toolStripSQL);
        	this.tabPage5.Location = new System.Drawing.Point(4, 26);
        	this.tabPage5.Name = "tabPage5";
        	this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage5.Size = new System.Drawing.Size(802, 443);
        	this.tabPage5.TabIndex = 4;
        	this.tabPage5.Text = "License keys";
        	this.tabPage5.UseVisualStyleBackColor = true;
        	// 
        	// dgvLicense
        	// 
        	this.dgvLicense.AllowUserToAddRows = false;
        	this.dgvLicense.AllowUserToDeleteRows = false;
        	this.dgvLicense.AllowUserToOrderColumns = true;
        	this.dgvLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvLicense.CommandAdd = false;
        	this.dgvLicense.CommandDel = false;
        	this.dgvLicense.CommandEdit = false;
        	this.dgvLicense.CommandExportToExcel = false;
        	this.dgvLicense.CommandFilter = false;
        	this.dgvLicense.CommandRefresh = false;
        	this.dgvLicense.CommandSaveASCSV = false;
        	this.dgvLicense.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvLicense.EnableHeadersVisualStyles = false;
        	this.dgvLicense.GroupEnabled = null;
        	this.dgvLicense.Location = new System.Drawing.Point(3, 29);
        	this.dgvLicense.Margin = new System.Windows.Forms.Padding(4);
        	this.dgvLicense.Name = "dgvLicense";
        	this.dgvLicense.Obj = null;
        	this.dgvLicense.PassedSec = null;
        	this.dgvLicense.ReadOnly = true;
        	this.dgvLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvLicense.Size = new System.Drawing.Size(796, 411);
        	this.dgvLicense.TabIndex = 13;
        	// 
        	// toolStripSQL
        	// 
        	this.toolStripSQL.AutoSize = false;
        	this.toolStripSQL.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.toolStripSQL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbLicense1,
			this.tbLicense2,
			this.tbLicense3,
			this.tbLicense4,
			this.tbLicense5});
        	this.toolStripSQL.Location = new System.Drawing.Point(3, 3);
        	this.toolStripSQL.Name = "toolStripSQL";
        	this.toolStripSQL.Size = new System.Drawing.Size(796, 26);
        	this.toolStripSQL.TabIndex = 15;
        	this.toolStripSQL.Text = "toolStrip1";
        	// 
        	// tbLicense1
        	// 
        	this.tbLicense1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbLicense1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbLicense1.Name = "tbLicense1";
        	this.tbLicense1.Size = new System.Drawing.Size(64, 23);
        	this.tbLicense1.Text = "Refresh";
        	this.tbLicense1.ToolTipText = "Refresh table of licenses";
        	this.tbLicense1.Click += new System.EventHandler(this.TbLicense1Click);
        	// 
        	// tbLicense2
        	// 
        	this.tbLicense2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbLicense2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbLicense2.Name = "tbLicense2";
        	this.tbLicense2.Size = new System.Drawing.Size(104, 23);
        	this.tbLicense2.Text = "Check license";
        	this.tbLicense2.Click += new System.EventHandler(this.TbLicense1Click);
        	// 
        	// tbLicense3
        	// 
        	this.tbLicense3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbLicense3.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbLicense3.Name = "tbLicense3";
        	this.tbLicense3.Size = new System.Drawing.Size(87, 23);
        	this.tbLicense3.Text = "Add license";
        	this.tbLicense3.Click += new System.EventHandler(this.TbLicense1Click);
        	// 
        	// tbLicense4
        	// 
        	this.tbLicense4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbLicense4.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbLicense4.Name = "tbLicense4";
        	this.tbLicense4.Size = new System.Drawing.Size(104, 23);
        	this.tbLicense4.Text = "Delete license";
        	this.tbLicense4.Click += new System.EventHandler(this.TbLicense1Click);
        	// 
        	// tbLicense5
        	// 
        	this.tbLicense5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.tbLicense5.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tbLicense5.Name = "tbLicense5";
        	this.tbLicense5.Size = new System.Drawing.Size(82, 23);
        	this.tbLicense5.Text = "Server info";
        	this.tbLicense5.Click += new System.EventHandler(this.TbLicense1Click);
        	// 
        	// timerLicenseCount
        	// 
        	this.timerLicenseCount.Interval = 5000;
        	// 
        	// menuStrip1
        	// 
        	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenuN1,
			this.MainMenuN2});
        	this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        	this.menuStrip1.Name = "menuStrip1";
        	this.menuStrip1.Size = new System.Drawing.Size(810, 25);
        	this.menuStrip1.TabIndex = 8;
        	this.menuStrip1.Text = "menuStrip1";
        	// 
        	// MainMenuN1
        	// 
        	this.MainMenuN1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenuN1_1});
        	this.MainMenuN1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenuN1.Name = "MainMenuN1";
        	this.MainMenuN1.Size = new System.Drawing.Size(43, 21);
        	this.MainMenuN1.Text = "File";
        	// 
        	// MainMenuN1_1
        	// 
        	this.MainMenuN1_1.Name = "MainMenuN1_1";
        	this.MainMenuN1_1.Size = new System.Drawing.Size(100, 22);
        	this.MainMenuN1_1.Text = "Exit";
        	this.MainMenuN1_1.Click += new System.EventHandler(this.MainMenuN1_1_Click_1);
        	// 
        	// MainMenuN2
        	// 
        	this.MainMenuN2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.MainMenuN2_1});
        	this.MainMenuN2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.MainMenuN2.Name = "MainMenuN2";
        	this.MainMenuN2.Size = new System.Drawing.Size(49, 21);
        	this.MainMenuN2.Text = "Help";
        	// 
        	// MainMenuN2_1
        	// 
        	this.MainMenuN2_1.Name = "MainMenuN2_1";
        	this.MainMenuN2_1.Size = new System.Drawing.Size(113, 22);
        	this.MainMenuN2_1.Text = "About";
        	this.MainMenuN2_1.Click += new System.EventHandler(this.MainMenuN1_1_Click_1);
        	// 
        	// FormServer
        	// 
        	//this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
        	//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(810, 498);
        	this.Controls.Add(this.tabControlServer);
        	this.Controls.Add(this.menuStrip1);
        	this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MainMenuStrip = this.menuStrip1;
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "FormServer";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Application Server";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
        	this.Resize += new System.EventHandler(this.FormServerResize);
        	this.cmServer.ResumeLayout(false);
        	this.tabPage4.ResumeLayout(false);
        	this.tabPage4.PerformLayout();
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage1.PerformLayout();
        	this.tabPage2.ResumeLayout(false);
        	this.tabControlClient.ResumeLayout(false);
        	this.tabPage7.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgClientCurrent)).EndInit();
        	this.tabPage6.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgClientAll)).EndInit();
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.tabPage3.ResumeLayout(false);
        	this.groupBoxApp1.ResumeLayout(false);
        	this.groupBoxSummary.ResumeLayout(false);
        	this.groupBoxApp.ResumeLayout(false);
        	this.groupBoxDatabase.ResumeLayout(false);
        	this.tabControlServer.ResumeLayout(false);
        	this.tabPage5.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvLicense)).EndInit();
        	this.toolStripSQL.ResumeLayout(false);
        	this.toolStripSQL.PerformLayout();
        	this.menuStrip1.ResumeLayout(false);
        	this.menuStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuN1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuN1_1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuN2;
        private System.Windows.Forms.ToolStripMenuItem MainMenuN2_1;
        private System.Windows.Forms.DataGridView dgClientCurrent;
        private System.Windows.Forms.ContextMenuStrip cmServer;
        private System.Windows.Forms.ToolStripMenuItem cmServer1;
        private System.Windows.Forms.ToolStripMenuItem cmServer2;
    }
}
