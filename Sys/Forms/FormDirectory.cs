/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 16.11.2018
 * Время: 13:02
 */
 
using System;
using System.Linq;
using System.Windows.Forms;
using SourceGrid;
using System.Text;

namespace FBA
{      
	/// <summary>
	/// Форма справочника. Не привязана к какой-то определённой сущности.
	/// </summary>
	public partial class FormDirectory : FormFBA
    {        	
		/// <summary>
        /// Фильтр. Внутри этого объекта все даные фильтра.
        /// </summary>
		public FilterObj Filter = new FilterObj();
        
		/// <summary>
		/// Форма поиска.
		/// </summary>
		//public System.Data.DataTable DT = new System.Data.DataTable();
        private FormSearch FSearch;      
        
        /// <summary>
        /// Параметры открытия формы справочника. Описаны в DirectoryParams.
        /// </summary>
        public DirectoryParams ListParams;
        
        /// <summary>
        /// 
        /// </summary>
        public bool FilterSet = false;
                       
        /// <summary>
        /// Переменная, чтобы определить что при получени фокуса ввода компонентом cbFastSearch
        /// больше не нужно читать историю поиска, она уже была прочитана ранее.
        /// </summary>
        public bool WasSetHistorySearch = false; 
         
		/// <summary>
        /// Конструктор. Установка MdiParent. 
        /// </summary>      
        public FormDirectory()
        {
            InitializeComponent();
            this.MdiParent = Var.FormMainObj;           
        }

		/// <summary>
		/// Конструктор. 
		/// </summary>
		/// <param name="caption">Заголовок формы справочника</param>
		/// <param name="dirparams">Параметры открытия справочника. Тип DirectoryParams.</param>
        public FormDirectory(string caption, ref DirectoryParams dirparams)
        {
            InitializeComponent();
            this.ListParams = dirparams;                
            if (string.IsNullOrEmpty(caption))
            {            
            	if (dirparams.EntityBrief != "") caption = caption + dirparams.EntityBrief;
	            if (!sys.IsEmpty(dirparams.ObjectID)) caption = caption.AddRightSpace() + "Object: " + dirparams.ObjectID;
            }
            Text = caption;                                              
            int Check = 0;         
            if (dirparams.showMode == ShowMode.Filter)       Check = 1;
            if (dirparams.showMode == ShowMode.ExecMSQL)     Check = 1;
            if (dirparams.showMode == ShowMode.ExecSQL)      Check = 1;
            if (Check == 0)
            {
                sys.SM("Неверно указан указан режим отображения справочника!");
                return;
            }            
            tb_N1.Visible = dirparams.ButtonFilter;  //(dirparams.showMode == ShowMode.Filter) ;  //Filter
            tb_N2.Visible = dirparams.ButtonRefresh; //AllowUpdate; //Refresh
            tb_N3.Visible = dirparams.ButtonAdd;     //AllowUpdate; //New
            tb_N4.Visible = dirparams.ButtonEdit;    //AllowUpdate; //Edit
            tb_N5.Visible = dirparams.ButtonDelete;  //AllowUpdate; //Delete
			tb_N6.Visible = dirparams.ButtonSearch;  //AllowUpdate; //Delete
			
            btnCancel.Visible   = tb_N4.Visible; //Если доступно изменение, то кнопка Cancel видима.
            Filter.ListObjectID = dirparams.ListObjectID;
            Filter.EntityBrief  = dirparams.EntityBrief;
            Filter.ColumnWidth  = dirparams.ColumnWidth;
            
            if (dirparams.showMode == ShowMode.Filter) Action(CommandType.Filter);
            if (dirparams.showMode == ShowMode.ExecMSQL)
            {                
                FormFilter.FilterRead(ref Filter, false);
                if ((Filter.FullQuerySQL == "") || (Filter.AttrSelect == "")) Action(CommandType.Filter);             
            }
         
            if (dirparams.showMode == ShowMode.ExecSQL)  Action(CommandType.ExecSQL);             
            if (dirparams.showMode == ShowMode.ExecMSQL) Action(CommandType.ExecMSQL);    
            
            //var clickController = new CellClickEvent();
            //grid1.Controller.AddController(clickController);
            //grid1.EndEditingRowOnValidate = false;
           // grid1.AcceptsInputChar = false;          
        }            
        
        /// <summary>
        /// Все возможные команды.
        /// </summary>
		private enum CommandType
		{
		    NotAssigned,
		    Add,
		    Edit,
		    Del, 
		    Refresh,
		    Filter,
		    ShowSQL,             
	        ShowMSQL, 
			Details,	        
	        ExportToExcel,
	        ExportToCSV,
	        Search,
	        Copy,
	        CopyAll,
	        CopyWithCaptions,
	        SelectAll,       
	        SelectRows,
	        SelectColumns, 
	        Ok,        
	        Cancel,
	        CopyDocumentLink,
	        ExecMSQL,
	        ExecSQL,	        
	        SelectionModeCell,
	        SelectionModeRow,
	        SelectionModeColumn
		} 
		      
        /// <summary>
        /// Перехват двойного клика на гриде.
        /// </summary>
        private class CellClickEvent : SourceGrid.Cells.Controllers.ControllerBase
        {            
        	public override void OnDoubleClick(SourceGrid.CellContext sender, EventArgs e)
            {
                base.OnDoubleClick(sender, e);
                //MessageBox.Show(sender.Grid, sender.DisplayText);      
                sender.EndEdit(true);
            }
        } 

        //Заполнение массива ArraySelectedID ИДОбъектам выбранных записей. Для DevExpress.XtraGrid.
        //Работает. Не удалять. Может ещё понадобится.
        /*private void FillArraySelected(int IndexColumnID)
        {                  
            //Массив с идентификаторами выделенных строк. Идентификаторы - это не ИДОбъекта, а внутренние идентификаторы грида.
            //int[] SelectedRows = gridView1.GetSelectedRows();
            Params.ReturnSelectedRowsCount = SelectedRows.Length; //Это равно gridView1.SelectedRowsCount;

            //В этом массиве будут все ИДОБъекта выделенных записей в таблице.
            Params.ReturnArraySelectedID = new string[Params.ReturnSelectedRowsCount];

            //DevExpress.XtraGrid.Columns.GridColumn col = sys.GetColumnByColumnIndex(gridView1, IndexColumnID);
            for (int i = 0; i < SelectedRows.Length; i++)
            {
                Params.ReturnArraySelectedID[i] = gridView1.GetRowCellValue(SelectedRows[i], col).ToString();
                if (i == 0)
                {
                    Params.ReturnObjectID = Params.ReturnArraySelectedID[i];
                    
                    //Еслир в FormDirectory передан NeedAttr, то нужно посмотреть отображается ли такой атрибут в таблице.
                    //Это для того, что не посылаьт ещё один запрос на получение значения NeedAttr по ИДОбъекта.
                    //NeedAttr передается, если FormDirectory показывается из компонента EditFBA. 
                    //И в поле EditFBA нужно отобразить тот атрибут сущности, который там указан в AttrBrief.
                    if (!Params.NeedAttr.IsEmpty())
                    {
                        DevExpress.XtraGrid.Columns.GridColumn colNeedAttr = sys.GetColumnByColumnName(gridView1, Params.NeedAttr);
                        if (colNeedAttr != null) Params.ReturnNeedAttr = gridView1.GetRowCellValue(SelectedRows[0], colNeedAttr).ToString();
                    }
                }
            }           
        }*/

        ///Заполнение массива ArraySelectedID ИДОбъектам выбранных записей.
        private void FillArraySelected(int IndexColumnID)
        {                           
        	//Массив с идентификаторами выделенных строк. Идентификаторы - это не ИДОбъекта, а внутренние идентификаторы грида.
            int[] SelectedRows =  grid1.Selection.GetSelectionRegion().GetRowsIndex();
            ListParams.ReturnSelectedRowsCount = SelectedRows.Length; //Это равно gridView1.SelectedRowsCount;
            
            //В этом массиве будут все ИДОБъекта выделенных записей в таблице.
            ListParams.ReturnArraySelectedID = new string[ListParams.ReturnSelectedRowsCount];      
            for (int iRow = 0; iRow < SelectedRows.Length; iRow++)
            {                
                ListParams.ReturnArraySelectedID[iRow] = grid1.Value(SelectedRows[iRow], 0);                
            }
            if (SelectedRows.Length > 0)
            {
                ListParams.ReturnObjectID = ListParams.ReturnArraySelectedID[0];
                //Если в FormDirectory передан NeedAttr, то нужно посмотреть отображается ли такой атрибут в таблице.
                //Это для того, что не посылаьт ещё один запрос на получение значения NeedAttr по ИДОбъекта.
                //NeedAttr передается в эту форму (FormDirectory), если эта форма показывается из компонента EditFBA. 
                //И в поле EditFBA нужно отобразить тот атрибут сущности, который там указан в AttrBrief.
                if (!sys.IsEmpty(ListParams.ReturnAttrBrief))
                {
                    string Value = grid1.Value(0, ListParams.ReturnAttrBrief);
                    if (Value != null) ListParams.ReturnAttrValue = Value;
                    //Если Value будет равно NULL, то в компоненте EditFBA выполнится запрос поиска значения атрибута по переданному отсюда Params.ReturnObjectID .
                }
            }
        }
       
        ///Показ таблицы.
        private void RefreshGridForm(DirectionQuery direction, FBA.GridFBA dg, FilterObj filter)
        {       
            sys.RefreshGrid(direction, dg, filter, tbGridInformation);
        }
        
        ///Установка SetSelectionMode
        private void SetSelectionMode(SourceGrid.GridSelectionMode sm)
        {        	
        	grid1.SelectionMode = sm;	
			grid1.Selection.EnableMultiSelection = true;        	
        }
        
        ///Вместо button1.PerformClick();
        private void Action(CommandType commandType)
        {       
        	if (commandType == CommandType.Ok) Close();
                       
        	if (commandType == CommandType.Filter)
            {
                if (!FormFilter.Filter(
                    this,
                    ListParams.EntityBrief,
                    grid1.Left,
                    grid1.Top,
                    ref Filter,
                    ListParams.OuterWHERE
                ))
                {
                    FilterSet = false;
                    return;
                }
                FilterSet = true;
                RefreshGridForm(DirectionQuery.Remote, grid1, Filter);         
            }  
            
        	if (commandType == CommandType.ExecSQL)
            {
                
                FilterSet = false;
                Filter.FullQuerySQL = ListParams.СustomSQLQuery;
                RefreshGridForm(DirectionQuery.Remote, grid1, Filter);         
            }  
        	
        	if (commandType == CommandType.ExecMSQL)
            {                
                FilterSet = false;
                Filter.FullQuerySQL = sys.Parse(ListParams.СustomMSQLQuery);
                RefreshGridForm(DirectionQuery.Remote, grid1, Filter);         
            } 
        	
            if (commandType == CommandType.Refresh)
            {
                RefreshGridForm(DirectionQuery.Remote, grid1, Filter);                
            }
            
            if (commandType == CommandType.Add)
            {
                EditObject("");
            }  
            
            if (commandType == CommandType.Edit)
            {
                this.ListParams.ObjectID = grid1.Value(0, true);
                if (ListParams.DoubleClickReturn) Close();

                //показываем форму свойств выбранного объекта.  
                EditObject(this.ListParams.ObjectID);             
            }  
            
            if (commandType == CommandType.Del)
            {
                int CountDeleted = 0;
                string ObjectCaption = "";
            	string[] ArrID = grid1.GetSelectedValues(0, true);
                if (ArrID == null) return;
                if (ArrID.Length == 0) return;
                string EntityName = sys.GetEntityName("", ListParams.EntityBrief);
                
                if (EntityName != "") ObjectCaption = EntityName;
                if (ArrID.Length == 1) ObjectCaption = ObjectCaption + " ИД Объекта " + ArrID[0];
                else ObjectCaption = ObjectCaption = ObjectCaption + " Всего объектов " + ArrID.Length.ToString();

                if (!sys.SM("Вы действительно ходите удалить " + ObjectCaption, MessageType.Question)) return;
                
                
                if (ArrID.Length == 1)
                {
                    ObjectCaption = "'" + EntityName + "'. ИД Объекта " + ArrID[0];                   
            		var Obj = new FBA.ObjectRef(); 
            		if (!Obj.DeleteObject(DirectionQuery.Remote, "Contract", ArrID[0])) return;
                    CountDeleted = 1;
                    sys.SM(ObjectCaption + " удален", MessageType.Information);
                }

                if (ArrID.Length > 1)
                {
                    var Progress1 = new FormProgress("Удаление", "Удаление объектов" + EntityName, ArrID.Length);
                    for (int i = 0; i < ArrID.Length; i++)
                    {
                        ObjectCaption = "'" + EntityName + "'. ИД Объекта " + ArrID[i];
                        var Obj = new FBA.ObjectRef(); 
                        if (!Obj.DeleteObject(DirectionQuery.Remote, "Contract", ArrID[i])) return;
                        CountDeleted++;                                             
                        Progress1.Inc();
                    }
                    Progress1.Dispose();

                    if (CountDeleted == ArrID.Length)
                    {
                        ObjectCaption = "Все объекты " + EntityName + " удалены. Всего: " + CountDeleted;
                        sys.SM(ObjectCaption, MessageType.Information);
                    }
                    if (CountDeleted < ArrID.Length)
                    {
                        ObjectCaption = "Объекты " + EntityName + " удалены. Всего: " + CountDeleted + " из " + ArrID.Length.ToString();
                        sys.SM(ObjectCaption, MessageType.Warning);
                    }
                    if (CountDeleted == 0)
                    {
                        ObjectCaption = "Объекты " + EntityName + " удалены не были.";
                        sys.SM(ObjectCaption);
                    }
                    
                    if (CountDeleted > 0)
                        if (sys.SM("Обновить содержимое справочника " + EntityName + "?", MessageType.Question)) RefreshGridForm(DirectionQuery.Remote, grid1, Filter); ;
                }
            }
            if (commandType == CommandType.ShowSQL)          sys.SM(Filter.FullQuerySQL, MessageType.Information);               
            if (commandType == CommandType.ShowMSQL)         sys.SM(Filter.FullQueryMSQL, MessageType.Information);             
            if (commandType == CommandType.Details)          grid1.GridInformation();
            if (commandType == CommandType.ExportToExcel)    grid1.SourceGridToExcel();
            if (commandType == CommandType.ExportToCSV)      grid1.SourceGridToCSV();
            if (commandType == CommandType.Search)           FSearch = FormSearch.FormSearchShow(this.Name,  null, grid1);

            if (commandType == CommandType.Copy)             grid1.CopyRegion(false, false);
            if (commandType == CommandType.CopyAll)          grid1.CopyRegion(true, true); 
            if (commandType == CommandType.CopyWithCaptions) grid1.CopyRegion(true, false);

            //if (Operation == "Copy")
            //{
            //    string Value = sys.GetValueByColumnIndex(DG2, -1, true);
            //    Value.CopyToClipboard();
            //}

            if (commandType == CommandType.SelectAll)        SourceGridSelectAll(grid1); //DG2.SelectAll());
            if (commandType == CommandType.SelectRows)       SourceGridSelectRows(grid1);
            if (commandType == CommandType.SelectColumns)    SourceGridSelectColumns(grid1);       

            if (commandType == CommandType.SelectionModeCell)    SetSelectionMode(SourceGrid.GridSelectionMode.Cell); 
			if (commandType == CommandType.SelectionModeRow)     SetSelectionMode(SourceGrid.GridSelectionMode.Row); 
			if (commandType == CommandType.SelectionModeColumn)  SetSelectionMode(SourceGrid.GridSelectionMode.Column); 

            if (commandType == CommandType.Cancel)
            {
                this.ListParams.ObjectID = "";
                this.Close();
            }
     
            //Копирование ссылок на выделенные документы.
            if (commandType == CommandType.CopyDocumentLink)
            {
                var links = new StringBuilder();
                string[] ArrID = grid1.GetSelectedValues(0, true);
                if (ArrID.Length == 0) return;
                for (int i = 0; i < ArrID.Length; i++)
                {
                    links.Append("FBALink.Entity:" + ListParams.EntityBrief + ",ObjectID:" + ArrID[i] + Var.CR);
                }
                links.ToString().CopyToClipboard();
            }
        }
   
        /// <summary>
        /// Расширить выделенный диапазон на все столбцы. Выделяет все столбцы выбранного диапазона строк.
        /// т.е. если выбрана одна колонка из строки, то выделяет все колонки строк. 
        /// </summary>
        /// <param name="sg">FBA.GridFBA</param>
        private void SourceGridSelectAll(FBA.GridFBA sg)
        {        
        	sg.Selection.ResetSelection(false);
            var range = new SourceGrid.Range(0, 0, sg.Rows.Count - 1, sg.Columns.Count - 1);
            sg.Selection.SelectRange(range, true);
        }

        
        /// <summary>
        /// Расширить выделенный диапазон на все столбцы.
        /// </summary>
        /// <param name="sg">FBA.GridFBA</param>
        private void SourceGridSelectRows(FBA.GridFBA sg)
        {                	
        	int[] selectedRows = sg.Selection.GetSelectionRegion().GetRowsIndex();
            sg.Selection.ResetSelection(false);
            int rowFirst = selectedRows[0];
            int rowLast  = selectedRows[selectedRows.Length - 1];
            var range = new SourceGrid.Range(rowFirst, 0, rowLast, sg.Columns.Count - 1);
            sg.Selection.SelectRange(range, true);            
        }
        
        /// <summary>
        /// Расширить выделенный диапазон на все столбцы.
        /// </summary>
        /// <param name="sg">FBA.GridFBA</param>
        private void SourceGridSelectColumns(FBA.GridFBA sg)
        {               
        	int[] SelectedColumns = sg.Selection.GetSelectionRegion().GetColumnsIndex();
            sg.Selection.ResetSelection(false);
            int columnFirst = SelectedColumns[0];
            int columnLast = SelectedColumns[SelectedColumns.Length - 1];
            var range = new SourceGrid.Range(0, columnFirst, sg.Rows.Count - 1, columnLast);
            sg.Selection.SelectRange(range, true);
        }
    
        /// <summary>
        /// Все кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_N1_Click(object sender, EventArgs e)
        {                                        
        	if (sender == tb_N1)     Action(CommandType.Filter);
            if (sender == tb_N2)     Action(CommandType.Refresh);
            if (sender == tb_N3)     Action(CommandType.Add);
            if (sender == tb_N4)     Action(CommandType.Edit);
            if (sender == tb_N5)     Action(CommandType.Del);
            if (sender == tb_N6)     Action(CommandType.Search);
          
            if (sender == cm_N1)     Action(CommandType.Filter);
            if (sender == cm_N2)     Action(CommandType.Refresh);
            if (sender == cm_N3)     Action(CommandType.Add);
            if (sender == cm_N4)     Action(CommandType.Edit);
            if (sender == cm_N5)     Action(CommandType.Del);
            if (sender == cm_N6)     Action(CommandType.Search);
            if (sender == cm_N7_1)   Action(CommandType.ExportToExcel);
            if (sender == cm_N7_2)   Action(CommandType.ExportToCSV);
            if (sender == cm_N9_1)   Action(CommandType.ShowSQL);
            if (sender == cm_N9_2)   Action(CommandType.ShowMSQL);
            if (sender == cm_N11)    Action(CommandType.Details);            
            if (sender == cm_N13_1)  Action(CommandType.SelectAll);
            if (sender == cm_N13_2)  Action(CommandType.SelectRows);
			if (sender == cm_N13_3)  Action(CommandType.SelectColumns);      
			if (sender == cm_N13_4)  Action(CommandType.SelectionModeCell);     
			if (sender == cm_N13_5)  Action(CommandType.SelectionModeRow);     
			if (sender == cm_N13_6)  Action(CommandType.SelectionModeColumn);     
			
            if (sender == cm_N16_1)  Action(CommandType.Copy);
            if (sender == cm_N16_2)  Action(CommandType.CopyAll);
            if (sender == cm_N16_3)  Action(CommandType.CopyWithCaptions);
            if (sender == cm_N16_4)  Action(CommandType.CopyDocumentLink);

            if (sender == btnOk)     Action(CommandType.Edit);
            if (sender == btnCancel) Action(CommandType.Cancel);                    
            if (sender == grid1)     Action(CommandType.Edit);           
        }

    
        
        /// <summary>
        /// При загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDirectory_Load(object sender, EventArgs e)
        {                	
        	if (!this.Modal) this.MdiParent = Var.FormMainObj;
        }

        
        /// <summary>
        /// Если форма свойств объекта не указана, то по двойному клику закрываем форму справочника.
        /// Закрываем форму - это когда нужен выбор объекта из справочника.
        /// Иначе показываем форму свойств выбранного объекта.
        /// </summary>
        /// <param name="id">ИД Объекта, форму свойств которого показываем</param>
        private void EditObject(string id)
        {                
        	if (string.IsNullOrEmpty(id)) return;
            if ((ListParams.FormProject == "") || (ListParams.FormName == ""))
            {
                FillArraySelected(0);
                if (ListParams.CloseAfterSelect) this.Close();
            }
            else
            {   //показываем форму свойств выбранного объекта.               
                int formNumber = 0;
                var obj = new object[1];
                obj[0] = id;
                ProjectService.FormShow(ListParams.FormProject, ListParams.FormName, out formNumber, obj);         
            }
        }  
        
        /// <summary>
        /// Перехват нажатий кнопок, когда форма в фокусе.
        /// </summary>
        /// <param name="msg">Сообщение операционной системы о нажатых клавишах</param>
        /// <param name="keyData">Нажатые клавиши</param>
        /// <returns>return false; означает разрешение дальнейшей обработки нажатой клавиши.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {           
        	//return false; означает разрешение дальнейшей обработки нажатой клавиши.
            if (Var.IsDesignMode) return false;
            if (this.FormUsual)   return false; 
            if (cbFastSearch.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    FastSearch();
                    cbFastSearch.Focus();
                    return true;
                }                
                return false;
            }

            const int WM_KEYDOWN    = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {            
                switch (keyData)
                {                  
                    case Keys.F3:
                        Action(CommandType.Search);
                        break; 
                    case Keys.Control | Keys.F:
                        Action(CommandType.Search);
                        break;
                    case Keys.Control | Keys.C:
                        Action(CommandType.Copy);
                        break;
                    case Keys.F2:
                        Action(CommandType.Filter);
                        break;
                    case Keys.F4:
                        Action(CommandType.Edit);
                        break;
                    case Keys.F5:
                        Action(CommandType.Refresh);
                        break;
                    case Keys.Delete:
                        Action(CommandType.Del);
                        break;
                    case Keys.Insert:
                        Action(CommandType.Add);
                        break;                    
                }                                 
            }
            return true;
        }      
    
  
		/// <summary>
		/// Метод. Быстрый поиск. 
		/// </summary>
        private void FastSearch()
        {           
        	int[] selectedRows = grid1.Selection.GetSelectionRegion().GetRowsIndex();
            int[] selectedColumns = grid1.Selection.GetSelectionRegion().GetColumnsIndex();
            if (selectedColumns.Length == 0)
            {
                sys.SM("Выделите колонку, в которой нужно производить поиск");
                return;
            }
            int firstRow = 0;
            int findCount = 0;
            if (selectedRows.Length > 0) firstRow = selectedRows[0] + 1;
            if (firstRow == grid1.Rows.Count) firstRow = 0;
            FormSearch.SerchTextSourceGrid(grid1,
                null,               //System.Windows.Forms.DataGridView DGResult,
                cbFastSearch.Text,  //string SearchText,
                firstRow,           //int FirstRow,
                false,              //bool CaseSensitivity,
                true,               //bool OnlySelectedColumns,
                false,              //bool OnlySelectedRows,
                false,              //bool OnlySelectedArea,
                2,                  //int SearchDirection,
                4,                  //int SearchPart,
                selectedRows,
                selectedColumns,
                ref findCount);           
            FormSearch.SetHistorySearch(cbFastSearch.Text);
        }
   
		/// <summary>
		/// Кнопка. Быстрый поиск.  
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnFastSearch_Click(object sender, EventArgs e)
        {           
            FastSearch();
        }
        
        /// <summary>
        /// Получение фокуса ввода 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFastSearch_Enter(object sender, EventArgs e)
        {      
        	if (WasSetHistorySearch) return;
            FormSearch.GetHistorySearch(cbFastSearch);
            WasSetHistorySearch = true;
        }

        /// <summary>
        /// Удалить историю поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {            
        	FormSearch.DeleteSearchHistory(cbFastSearch);
        }
		void Cm_N13_1Click(object sender, EventArgs e)
		{
	
		}
		void Cm_N16_3Click(object sender, EventArgs e)
		{
	
		}
		void Cm_N13_4Click(object sender, EventArgs e)
		{
	
		}
		void Cm_N13Click(object sender, EventArgs e)
		{
	
		}
        
        
	
    }

    /// <summary>    
	/// Если NotAssigned - форма поднимается, но все пусто и фильтр нужно нажимать самостоятельно. (Не рекомендуется для использования)
    /// Если Filter      - форма поднимается, но сразу показывается фильтр. (Рекомендуется) 
    /// Если ExecMSQL    - форма поднимается, фильтр не показывается, но сразу применяется и выполняется запрос MSQL. (Рекомендуется для небольших справочников)
    /// Если ExecSQL     - форма поднимается, фильтр не показывается, но сразу применяется и выполняется запрос SQL. (Рекомендуется для небольших справочников)	
    /// </summary>
    public enum ShowMode
	{
    	/// <summary>
    	/// Показаьт фильтр
    	/// </summary>
        Filter,
        
        /// <summary>
        /// Выполнить код MSQL без показа фильтра
        /// </summary>
        ExecMSQL,
        
        /// <summary>
        /// Выполнить код SQL без показа фильтра
        /// </summary>
        ExecSQL
	}		
	
    ///Класс для передачи всего фильтра в вызывающую форму.
    public class DirectoryParams
    {        
    	/// <summary>
    	/// Сокращение сущности, которую показываем.
    	/// </summary>
    	public string EntityBrief = "";     
    	
    	/// <summary>
    	/// ИДОбъекта на который нужно спозиционировать курсор, если объект есть в таблице.
    	/// </summary>
        public string ObjectID = "";      
        
        /// <summary>
        /// Множественный выбор строк.
        /// </summary>
        public bool   Multiselect = false;   
        
        /// <summary>
        /// Кнопка фильтра.
        /// </summary>
        public bool   ButtonFilter = true;    
                
        /// <summary>
        /// Кнопка Refresh.
        /// </summary>
        public bool   ButtonRefresh = true;    
        
        /// <summary>
        /// Кнопка Add.
        /// </summary>
        public bool   ButtonAdd = true;    
        
        /// <summary>
        /// Кнопка Edit.
        /// </summary>
        public bool   ButtonEdit = true;    
        
        /// <summary>
        /// Кнопка Delete.
        /// </summary>
        public bool   ButtonDelete = true;    
        
        /// <summary>
        /// Кнопка Search.
        /// </summary>
        public bool   ButtonSearch = true;    
                
        /// <summary>
        /// Форма свойств выбранного объекта
        /// </summary>
        public string FormName = "";      
        
        /// <summary>
        /// Проекта в котором находится форма свойств объекта.
        /// </summary>
        public string FormProject = "";      
        
        /// <summary>
        /// Способ показа формы (см. выше)
        /// </summary>
        public ShowMode showMode = ShowMode.Filter; 
        
        /// <summary>
        /// Внешний фильтр на MSQL
        /// </summary>                
        public string OuterWHERE = "";      
        
        /// <summary>
        /// Произвольный запрос на MSQL.
        /// </summary>
        public string СustomMSQLQuery = "";      
        
        /// <summary>
        /// Произвольный запрос на SQL
        /// </summary>
        public string СustomSQLQuery     = "";      
        
        /// <summary>
        /// Сокращение Атрибута,значение которого нужно вернуть, если форма справочника поднимается для выбора объекта
        /// </summary>
        public string ReturnAttrBrief           = "";      
        
        /// <summary>
        /// Если true, то при двойном клике форма закрывается  и происходит выбор объекта 
        /// </summary>
        public bool DoubleClickReturn    = false;   
        
        /// <summary>
        /// Воззврат списка выбранных объектов
        /// </summary>
        public string[] ReturnArraySelectedID = null;
        
        /// <summary>
        /// Количество выбранных объектов
        /// </summary>
        public int ReturnSelectedRowsCount = 0;
        
        /// <summary>
        /// ИД первого выбранного объекта
        /// </summary>
        public string ReturnObjectID = "";
        
        /// <summary>
        /// Атрибут, который нужно вернуть из таблицы
        /// </summary>
        public string ReturnAttrValue = "";
        
        /// <summary>
        /// Список ИДОбъектов которые должны попасть в выборку.
        /// </summary>
        public string[] ListObjectID = null;  

		/// <summary>
        /// Массив всех размеров по ширине колонок. Далее этот массив применяется к гриду.
        /// </summary>
        public int[]  ColumnWidth; 

		/// <summary>
        /// Закрывать форму после выбора объекта
        /// </summary>
        public bool CloseAfterSelect = false;        
    }
}

        //Тестовая кнопка.
        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{		
            //grid1.Selection.FocusRow(30);            
            //return;
            //System.Data.DataTable DTClone;
            //DTClone = sys.SelectedRowsToDataTable(DG2, false);
            //DTClone.DTView("CapForm - DTClone", "CapText - DTClone");
            //int AreaLeft;
            //int AreaTop;
            //int AreaRight;
            //int AreaBottom;

            //DG2.GetSelectedArea(out AreaLeft, out AreaTop, out AreaRight, out AreaBottom);
            //sys.SM("AreaLeft: "   + AreaLeft.ToString()  + Var.CR + 
            //       "AreaTop: "    + AreaTop.ToString()   + Var.CR + 
            //       "AreaRight: "  + AreaRight.ToString() + Var.CR + 
            //       "AreaBottom: " + AreaBottom.ToString());
            //System.Data.DataTable DTClone;
            //DTClone = sys.DataTable_Area_To_DataTable(DG2.GetDataTable(), AreaLeft, AreaTop - 1, AreaRight, AreaBottom - 1, true);
            //DTClone.DTView("CapForm - DTClone", "CapText - DTClone");
        //}