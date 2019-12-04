
  #region Region. DevExpress.XtraGrid.Views.Grid.GridView

        /* Отключено, так как сейчас DevExpress.XtraGrid не используется.
        
        //public static void GetCountRowsCols(DevExpress.XtraGrid.Views.Grid.GridView GV, out int RowsCount, out int ColsCount)
        //public static string GetValueByColumnName(DevExpress.XtraGrid.Views.Grid.GridView GV, string ColumnName, bool ShowError)
        //public static DevExpress.XtraGrid.Columns.GridColumn GetColumnByColumnIndex(DevExpress.XtraGrid.Views.Grid.GridView GV, int ColumnIndex)
        //public static DevExpress.XtraGrid.Columns.GridColumn GetColumnByColumnName(DevExpress.XtraGrid.Views.Grid.GridView GV, string ColumnName)        
        //public static string GetValueByColumnIndex(DevExpress.XtraGrid.Views.Grid.GridView GV, int ColumnIndex, bool ShowError)
        //public static string GetValueByColumnIndex(DevExpress.XtraGrid.GridControl DG, int ColumnIndex, bool ShowError)
        //public static string GetValueByColumnName(DevExpress.XtraGrid.GridControl DG, string ColumnName, bool ShowError)        
        //public static bool RefreshGrid_Thread(string Direction, DevExpress.XtraGrid.GridControl grid, FilterObj filter)
        //public static bool RefreshGrid(string Direction, DevExpress.XtraGrid.GridControl grid, FilterObj filter)

        //Работает. Получение количества строки столбцов таблицы.
        public static void GetCountRowsCols(DevExpress.XtraGrid.Views.Grid.GridView GV, out int RowsCount, out int ColsCount)
        {
            ColsCount = GV.Columns.Count;
            RowsCount = GV.RowCount; //int RowsCount = gridView1.DataRowCount;            
        }

        //Работает. Получение значения в колонке с названием ColumnName первый выделенной строки.
        public static string GetValueByColumnName(DevExpress.XtraGrid.Views.Grid.GridView GV, string ColumnName, bool ShowError)
        {
            int[] i = GV.GetSelectedRows();
            if (i.Count() == 0)
            {
                if (ShowError) sys.SM("No rows selected in the table");
                return "";
            }
            DevExpress.XtraGrid.Columns.GridColumn col = GV.Columns.ColumnByName("col" + ColumnName);
            if (col == null)
            {
                if (ShowError) sys.SM("Not found the column with the name: " + ColumnName);
                return "";
            }
            return GV.GetRowCellValue(i[0], col).ToString();


            int[] i = gridView1.GetSelectedRows();
            string FieldName0 = gridView1.Columns[0].FieldName;
            string FieldName1 = gridView1.Columns[1].FieldName;

            string ColumnName0 = gridView1.Columns[0].Name;
            string ColumnName1 = gridView1.Columns[1].Name;
            DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName(FieldName0);
            DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName(FieldName1);
            DevExpress.XtraGrid.Columns.GridColumn col3 = gridView1.Columns.ColumnByName(ColumnName0);
            DevExpress.XtraGrid.Columns.GridColumn col4 = gridView1.Columns.ColumnByName(ColumnName1);
            DevExpress.XtraGrid.Columns.GridColumn col5 = gridView1.Columns[1];

            string valuestr1 = gridView1.GetRowCellValue(i[0], col1).ToString();
            string valuestr2 = gridView1.GetRowCellValue(i[0], col2).ToString();
            string valuestr3 = gridView1.GetRowCellValue(i[0], col3).ToString();
            string valuestr4 = gridView1.GetRowCellValue(i[0], col4).ToString();
            string valuestr5 = gridView1.GetRowCellValue(i[0], col5).ToString();

            int dataRowCount1 = gridView1.DataRowCount;
            int dataColCount = gridView1.Columns.Count;
            int dataRowCount2 = gridView1.RowCount;
            int SelectedRowsCount = gridView1.SelectedRowsCount;
        }

        //Работает. Получение колонки таблицы в виде DevExpress.XtraGrid.Columns.GridColumn по её порядковому номеру.
        public static DevExpress.XtraGrid.Columns.GridColumn GetColumnByColumnIndex(DevExpress.XtraGrid.Views.Grid.GridView GV, int ColumnIndex)
        {
            if (GV.Columns.Count <= ColumnIndex)
            {
                return null;
            }
            string ColumnName = GV.Columns[ColumnIndex].Name;
            return GV.Columns.ColumnByName(ColumnName);
        }       

        //Работает. Получение значения в колонке с названием ColumnName первый выделенной строки.
        public static string GetValueByColumnName(DevExpress.XtraGrid.GridControl DG, string ColumnName, bool ShowError)
        {
            int[] i = ((DevExpress.XtraGrid.Views.Grid.GridView)DG.MainView).GetSelectedRows();
            if (i.Count() == 0)
            {
                if (ShowError) sys.SM("No rows selected in the table");
                return "";
            }
            DevExpress.XtraGrid.Columns.GridColumn col = ((DevExpress.XtraGrid.Views.Grid.GridView)DG.MainView).Columns.ColumnByName("col" + ColumnName);
            if (col == null)
            {
                if (ShowError) sys.SM("Not found the column with the name: " + ColumnName);
                return "";
            }
            return ((DevExpress.XtraGrid.Views.Grid.GridView)DG.MainView).GetRowCellValue(i[0], col).ToString();
        }

        //Работает. Получение значения в колонке с номером первый выделенной строки через GridControl.
        public static string GetValueByColumnIndex(DevExpress.XtraGrid.GridControl DG, int ColumnIndex, bool ShowError)
        {
            if ((ColumnIndex < 0) || (ColumnIndex > (((DevExpress.XtraGrid.Views.Grid.GridView)DG.MainView).Columns.Count - 1)))
            {
                if (ShowError) sys.SM("Invalid column index: " + ColumnIndex.ToString());
                return "";
            }
            string ColumnName = ((DevExpress.XtraGrid.Views.Grid.GridView)DG.MainView).Columns[ColumnIndex].Name;
            int[] i = ((DevExpress.XtraGrid.Views.Grid.GridView)DG.MainView).GetSelectedRows();
            if (i.Count() == 0)
            {
                if (ShowError) sys.SM("No rows selected in the table");
                return "";
            }
            DevExpress.XtraGrid.Columns.GridColumn col = ((DevExpress.XtraGrid.Views.Grid.GridView)DG.MainView).Columns.ColumnByName(ColumnName);
            return ((DevExpress.XtraGrid.Views.Grid.GridView)DG.MainView).GetRowCellValue(i[0], col).ToString();
        }

        //Работает. Получение значения в колонке с номером первый выделенной строки через GridView.
        public static string GetValueByColumnIndex(DevExpress.XtraGrid.Views.Grid.GridView GV, int ColumnIndex, bool ShowError)
        {        
            if ((ColumnIndex < 0) || (ColumnIndex > (GV.Columns.Count - 1)))
            {
                if (ShowError) sys.SM("Invalid column index: " + ColumnIndex.ToString());
                return "";
            }
            string ColumnName = GV.Columns[ColumnIndex].Name;
            int[] i = GV.GetSelectedRows();
            if (i.Count() == 0)
            {
                if (ShowError) sys.SM("No rows selected in the table");
                return "";
            }
            DevExpress.XtraGrid.Columns.GridColumn col = GV.Columns.ColumnByName(ColumnName);
            return GV.GetRowCellValue(i[0], col).ToString();
        }

        //Работает. Получение колонки таблицы в виде DevExpress.XtraGrid.Columns.GridColumn по её имени.
        public static DevExpress.XtraGrid.Columns.GridColumn GetColumnByColumnName(DevExpress.XtraGrid.Views.Grid.GridView GV, string ColumnName)
        {
            return GV.Columns.ColumnByName("col" + ColumnName);
        }
        
        //Работает. Функция получения данных для MSSQL, Postgre, SQLite для DevExpress.XtraGrid.
        public static bool RefreshGrid_Thread(string Direction, DevExpress.XtraGrid.GridControl grid, FilterObj filter)
        {           
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            var outer2 = Task.Factory.StartNew(() =>
            {
                string SQL = "";
                int[] ColumnWidth = null;
                if (filter != null)
                {
                    SQL = filter.FullQuerySQL;
                    ColumnWidth = filter.ColumnWidth;
                }
                System.Data.DataTable DT;
                if (!SelectDT(Direction, SQL, out DT)) return;                        
                grid.DataSource = DT;
          
            });               
            return true;                              
        }

        //Работает. Функция получения данных для MSSQL, Postgre, SQLite для DevExpress.XtraGrid.
        public static bool RefreshGrid(string Direction, DevExpress.XtraGrid.GridControl grid, FilterObj filter)
        {                     
            string SQL = filter.FullQuerySQL;
            System.Data.DataTable DT;
            if (!SelectDT(Direction, SQL, out DT)) return false;
            grid.DataSource = DT;
            //grid.RefreshDataSource();
            //grid.DataSource = DT;
            //grid.MainView.RefreshData();
            grid.MainView.PopulateColumns();
            //grid.MainView.
            //grid.Re
            return true;
        }*/

        #endregion Region. DevExpress.XtraGrid.Views.Grid.GridView


//=================
/* // <summary>
        // Запись всех значений компонентов в таблицу fbaParam.    
        // </summary>
        // <param name="direction">Запрос к локальной или удаленнённой базе данных.</param>
        // <param name="form">Форма</param>
        // <returns>Если запись успешная, то true</returns>
        public static bool FormComponentValuesSave(DirectionQuery direction, Form form)
        {
            var listParams = new string[1];
            listParams[0] = GetComponentValues(form.Controls); //Установка SettingText - глобальная переменная формы.     
            string ParamName   = form.Name;
            string FormName    = form.Name;
            const bool checkGlobal  = false;
            const string paramType = "Form";              
            return Param.Save(direction, Var.UserID , ParamName, checkGlobal, listParams, paramType, FormName, "");          
        }
*/   

//======================
 //Класс предок ToolStrip. Панелька с кнопками.
    /*public class ToolStripFBA : System.Windows.Forms.ToolStrip
    {
        public System.Windows.Forms.ToolStripButton tbN1;
        public System.Windows.Forms.ToolStripButton tbN4;
        public System.Windows.Forms.ToolStripButton tbN5;
        public System.Windows.Forms.ToolStripButton tbN6;
        public System.Windows.Forms.ToolStripButton tbN7;
        
        //В конструкторе наполняем пунктами меню.
        public ToolStripFBA()
        {
            tbN1 = new System.Windows.Forms.ToolStripButton();
            tbN4 = new System.Windows.Forms.ToolStripButton();
            tbN5 = new System.Windows.Forms.ToolStripButton();
            tbN6 = new System.Windows.Forms.ToolStripButton();
            tbN7 = new System.Windows.Forms.ToolStripButton();           
            // 
            // toolStripDGV
            //         
            Font = Var.font1;
            Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tbN1,
            tbN4,
            tbN5,
            tbN6,
            tbN7});
            Location = new System.Drawing.Point(25, 0);
            Name = "toolStripDGV";
            Size = new System.Drawing.Size(339, 25);
            TabIndex = 0;
            Text = "toolStrip1";
            // 
            // tbN1
            // 
            tbN1.Image = global::FBA.Resource.filter;
            tbN1.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbN1.Name = "tbN1";
            tbN1.Size = new System.Drawing.Size(60, 22);
            tbN1.Text = "Filter";
            // 
            // tbN4
            // 
            tbN4.Image = global::FBA.Resource.refresh;
            tbN4.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbN4.Name = "tbN4";
            tbN4.Size = new System.Drawing.Size(80, 22);
            tbN4.Text = "Ref";
            // 
            // tbN5
            // 
            tbN5.Image = global::FBA.Resource.add;
            tbN5.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbN5.Name = "tbN5";
            tbN5.Size = new System.Drawing.Size(53, 22);
            tbN5.Text = "Add";
            //tbN5.Click += new System.EventHandler(tbN5_Click);
            // 
            // tbN6
            // 
            tbN6.Image = global::FBA.Resource.del;
            tbN6.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbN6.Name = "tbN6";
            tbN6.Size = new System.Drawing.Size(50, 22);
            tbN6.Text = "Del";
            //tbN6.Click += new System.EventHandler(tbN6_Click);
            // 
            // tbN7
            // 
            tbN7.Image = global::FBA.Resource.edit;
            tbN7.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbN7.Name = "tbN7";
            tbN7.Size = new System.Drawing.Size(53, 22);
            tbN7.Text = "Edit";
            //tbN7.Click += new System.EventHandler(tbN7_Click);
        }
        
    } */

    //Класс предок ToolStrip. Панелька с кнопками.
    /*public class ToolStripFBA : System.Windows.Forms.ToolStrip
    {  
         //Конструктор.
        public ToolStripFBA(): base()
        {          
            var tb_N1 = new System.Windows.Forms.ToolStripButton();
            var tb_N2 = new System.Windows.Forms.ToolStripButton();
            var tb_N3 = new System.Windows.Forms.ToolStripButton();
            var tb_N4 = new System.Windows.Forms.ToolStripButton();
            var tb_N5 = new System.Windows.Forms.ToolStripButton();
            
            // 
            // tb_N1
            //                        
            tb_N1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tb_N1.Image = global::FBA.Resource.Filter_24; //((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            tb_N1.ImageTransparentColor = System.Drawing.Color.Magenta;
            tb_N1.Name = "tb_N1";
            tb_N1.Size = new System.Drawing.Size(28, 28);
            tb_N1.Text = "Filter";
            // 
            // tb_N2
            // 
            tb_N2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tb_N2.Image = global::FBA.Resource.Refresh_24;
            tb_N2.ImageTransparentColor = System.Drawing.Color.Magenta;
            tb_N2.Name = "tb_N2";
            tb_N2.Size = new System.Drawing.Size(28, 28);
            tb_N2.Text = "Refresh";
            // 
            // tb_N3
            // 
            tb_N3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tb_N3.Image = global::FBA.Resource.Add_24;
            tb_N3.ImageTransparentColor = System.Drawing.Color.Magenta;
            tb_N3.Name = "tb_N3";
            tb_N3.Size = new System.Drawing.Size(28, 28);
            tb_N3.Text = "Add";
            // 
            // tb_N4
            // 
            tb_N4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tb_N4.Image = global::FBA.Resource.Edit_24;
            tb_N4.ImageTransparentColor = System.Drawing.Color.Magenta;
            tb_N4.Name = "tb_N4";
            tb_N4.Size = new System.Drawing.Size(28, 28);
            tb_N4.Text = "Edit";
            // 
            // tb_N5
            // 
            tb_N5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tb_N5.Image = global::FBA.Resource.Del_24;
            tb_N5.ImageTransparentColor = System.Drawing.Color.Magenta;
            tb_N5.Name = "tb_N5";
            tb_N5.Size = new System.Drawing.Size(28, 28);
            tb_N5.Text = "Delete";
            
            Font = Var.font1;
            ImageScalingSize = new System.Drawing.Size(24, 24);
            Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tb_N1,
            tb_N2,
            tb_N3,
            tb_N4,
            tb_N5});
            Location = new System.Drawing.Point(0, 0);
            Name = "ToolStripFBA1";
            Size = new System.Drawing.Size(591, 31);
            TabIndex = 17;
            Text = "ToolStripFBA1"; 
        }          
    }*/

    /*
    //Класс предок ContextMenuStrip. Контекстное меню. 
    public class ContextMenuStripFBA : System.Windows.Forms.ContextMenuStrip
    { 
        public System.Windows.Forms.ToolStripMenuItem cmGridN1;
        public System.Windows.Forms.ToolStripMenuItem cmGridN2;
        public System.Windows.Forms.ToolStripMenuItem cmGridN3;              
        public System.Windows.Forms.ToolStripMenuItem cmGridN4;
        public System.Windows.Forms.ToolStripMenuItem cmGridN5;
        public System.Windows.Forms.ToolStripMenuItem cmGridN6;
        public System.Windows.Forms.ToolStripMenuItem cmGridN7;         
        public System.Windows.Forms.ToolStripSeparator cmGridSeparator1;
        
        //В конструкторе наполняем пунктами меню.
        public ContextMenuStripFBA(System.ComponentModel.IContainer container)
        {
            cmGridN1 = new System.Windows.Forms.ToolStripMenuItem();
            cmGridN2 = new System.Windows.Forms.ToolStripMenuItem();
            cmGridN3 = new System.Windows.Forms.ToolStripMenuItem();                        
            cmGridN4 = new System.Windows.Forms.ToolStripMenuItem();
            cmGridN5 = new System.Windows.Forms.ToolStripMenuItem(); 
            cmGridN6 = new System.Windows.Forms.ToolStripMenuItem();
            cmGridN7 = new System.Windows.Forms.ToolStripMenuItem();
             
            cmGridSeparator1 = new System.Windows.Forms.ToolStripSeparator();
             
            //
            // cmGrid
            // 
            Font = Var.font1;
            Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            cmGridN1,
            cmGridN2,
            cmGridN3,
            cmGridN4,
            cmGridN5,
            cmGridSeparator1,                            
            cmGridN6,
            cmGridN7});
            Name = "cmGrid";
            //Size = new System.Drawing.Size(175, 192);
            // 
            // cmGridN1
            // 
            cmGridN1.Image = global::FBA.Resource.Add_16;
            cmGridN1.Name = "cmGridN1";
            //cmGridN1.Size = new System.Drawing.Size(174, 22);
            cmGridN1.Text = "Add";
            // 
            // cmGridN2
            // 
            cmGridN2.Image = global::FBA.Resource.Edit_16;
            cmGridN2.Name = "cmGridN2";
            //cmGridN2.Size = new System.Drawing.Size(174, 22);
            cmGridN2.Text = "Edit";
            // 
            // cmGridN3
            // 
            cmGridN3.Image = global::FBA.Resource.Del_16;
            cmGridN3.Name = "cmGridN3";
            //cmGridN3.Size = new System.Drawing.Size(174, 22);
            cmGridN3.Text = "Del";
            // 
            // cmGridN4
            // 
            cmGridN4.Image = global::FBA.Resource.Refresh_16;
            cmGridN4.Name = "cmGridN1";
            //cmGridN4.Size = new System.Drawing.Size(174, 22);
            cmGridN4.Text = "Refresh";       
            // 
            // cmGridN5
            // 
            cmGridN5.Image = global::FBA.Resource.Filter_16;
            cmGridN5.Name = "cmGridN5";
            //cmGridN5.Size = new System.Drawing.Size(174, 22);
            cmGridN5.Text = "Filter";         
            // 
            // toolStripMenuItem1
            // 
            cmGridSeparator1.Name = "cmGridSeparator1";
            //cmGridSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // cmGridN6
            // 
            cmGridN6.Name = "cmGridN6";
            //cmGridN6.Size = new System.Drawing.Size(174, 22);
            cmGridN6.Text = "Export to Excel";
            // 
            // cmGridN7
            // 
            cmGridN7.Name = "cmGridN7";
            //cmGridN7.Size = new System.Drawing.Size(174, 22);
            cmGridN7.Text = "Save as CSV";           
        }              
    }*/
//======================    
/*
 *  /// <summary>
        /// Создание альтернативного подключения.
        /// </summary>
        /// <param name="connectionName">Имя соединения</param>
        /// <param name="conAlt"></param>
        /// <returns></returns>
        public static bool EnterAlt(string connectionName, ref Connection conAlt)
        {
            if (connectionName == "")
            {
                SM("Не задано имя подключения!");
                return false;
            }

            string connectionID;
            string conServerType;
            string conServerName;
            string conDatabaseName;
            string conDatabaseLogin;
            string conDatabasePass;
            string conUserForm;
            string conUserLogin;
            string conUserPass;
            string conWindowsLogin;
            if (Var.conLite.ConnectionGetParamName(
                                             connectionName,
                                             out connectionID,
                                             out conServerType,
                                             out conServerName,
                                             out conDatabaseName,
                                             out conDatabaseLogin,
                                             out conDatabasePass,
                                             out conUserForm,
                                             out conUserLogin,
                                             out conUserPass,
                                             out conWindowsLogin) == false) return false;

            //Серверу приложений нельзя подключаться через другой сервер приложений.
            if ((Var.SystemName == "ServerApp") && (conServerType == "ServerApp"))
            {
                SM("Ошибка: Серверу приложений нельзя подключаться через другой сервер приложений!");
                return false;
            }

            conAlt.ConnectionID = connectionID;
            conAlt.ConnectionName = connectionName;
            conAlt.UserForm = conUserForm;
            conAlt.UserLogin = conUserLogin;
            conAlt.UserPass = conUserPass;
            conAlt.WindowsLogin = conWindowsLogin;

            ServerType serverType = ServerType.Auto;
            if (conServerType == "MSSQL")    serverType = ServerType.MSSQL;
            if (conServerType == "SQLite")   serverType = ServerType.SQLite;
            if (conServerType == "Postgre")  serverType = ServerType.Postgre;
            
            
            if (!conAlt.ConnectionInit(serverType,
                                       conServerName,
                                       conDatabaseLogin,
                                       conDatabasePass,
                                       conDatabaseName)) return false;
            return true;
        }
        */
//=============================================
/*/// <summary>
        /// Возвращает полный путь к клиенту ClientApp.exe.
        /// </summary>
        /// <param name="fileName">Полный путь к клиенту ClientApp.exe</param>
        /// <returns>Если файл БД наден, то true</returns>
        public static bool GetPathClient(out string fileName)
        {
            string applicationDirectory = System.Windows.Forms.Application.StartupPath;
            fileName = applicationDirectory + @"\ClientApp.exe";
            if (!File.Exists(fileName)) fileName = @"..\..\..\ClientApp\bin\Debug\ClientApp.exe";
            if (!File.Exists(fileName))
            {
                sys.SM("File not found ClientApp.exe", MessageType.Information, "Entering to system");
                return false;
            }

            //Функция GetFullPath возвращает полный путь относительно текущей папки.
            Directory.SetCurrentDirectory(applicationDirectory);
            string fileNameFull = System.IO.Path.GetFullPath(fileName);
            if (!File.Exists(fileNameFull))
            {
                sys.SM("File not found ClientApp.exe:" + fileNameFull, MessageType.Information, "Entering to system");
                return false;
            }
            fileName = fileNameFull;
            return true;
        }*/
//=============================================
        	      // <summary>
        // Получить имя текущей выделенной формы из истории.
        // </summary>
        // <returns></returns>
        //private string GetCurrentProjectHistID()
        //{                    
        //    if (dgvHist.Rows.Count == 0) return "0";
        //    return dgvHist.Value("ID");                                             
        //}   
//=============================================
//=============================================
//=============================================
//=============================================