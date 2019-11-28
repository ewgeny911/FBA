
/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 11.11.2017
 * Время: 19:19"
 */
 
//Директива условной компиляции. Если на компе не установлен Excel, то не скомпилируется.
#define CompileWithExcel //Компилирвать если подключены библиотеки Office 
 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;   
using SourceGrid.Selection;
using ContentAlignment = DevAge.Drawing.ContentAlignment;
using System.Collections.Generic;
using System.IO;

#if CompileWithExcel
using Microsoft.Office.Interop.Excel; //Для экспорта в Excel
using System.Runtime.InteropServices; //Для экспорта в Excel
#endif

//Расширение свойств компонентов. 
namespace FBA
{    
	
	/// <summary>
    /// Класс для перерисовки SourceGrid. Нужно для того чтобы выводить строки разным цветом через одну.
    /// </summary>
    public class CellBackColorAlternate: SourceGrid.Cells.Views.Cell
    {
        /// <summary>
        /// Первый цвет.
        /// </summary>
    	public DevAge.Drawing.VisualElements.IVisualElement FirstBackground;
    	
    	/// <summary>
        /// Второй цвет.
        /// </summary>
        public DevAge.Drawing.VisualElements.IVisualElement SecondBackground;
        
        /// <summary>
        /// Установка цветов.
        /// </summary>
        /// <param name="firstColor">Первый цвет.</param>
        /// <param name="secondColor">Второй цвет.</param>
        public CellBackColorAlternate(Color firstColor, Color secondColor)
        {
            FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
            SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        }  
        
        /// <summary>
        /// При выводе грида, раскраска двумя цветами.
        /// </summary>
        /// <param name="context"></param>
        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);
            if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                Background = FirstBackground;
            else
                Background = SecondBackground;
        }
    }
   
    /// <summary>
    /// Класс для перерисовки SourceGrid. Нужно для того чтобы выводить строки разным цветом через одну. 
    /// Это тоже самое что CellBackColorAlternate, но для ячеек типа CheckBox.
    /// </summary>   
    public class CheckBoxBackColorAlternate: SourceGrid.Cells.Views.CheckBox
    {
        /// <summary>
        /// Установка цветов.
        /// </summary>
        /// <param name="firstColor">Первый цвет.</param>
        /// <param name="secondColor">Второй цвет.</param>
    	public CheckBoxBackColorAlternate(Color firstColor, Color secondColor)
        {
            FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
            SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        }
        private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
       
        /// <summary>
        /// Первый цвет.
        /// </summary>
        public  DevAge.Drawing.VisualElements.IVisualElement FirstBackground
        {
            get
            {
                return mFirstBackground;
            }
            set
            {
                mFirstBackground = value;
            }
        }
        private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
        
        /// <summary>
        /// Второй цвет.
        /// </summary>
        public  DevAge.Drawing.VisualElements.IVisualElement SecondBackground
        {
            get { return mSecondBackground; }
            set { mSecondBackground = value; }
        }
        
        /// <summary>
        /// При выводе грида, раскраска двумя цветами.
        /// </summary>
        /// <param name="context"></param>
        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);
            if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                Background = FirstBackground;
            else
                Background = SecondBackground;
        }
    }  
    
    /// <summary>
    /// Класс потомок SourceGrid.DataGrid.
    /// </summary>
    public class GridFBA : SourceGrid.DataGrid
    {
		/// <summary>
        /// Конструктор.
        /// </summary>
        public GridFBA() : base()
        {
        	//Возможность выделять несколько строк.
            //dg.SelectionMode = GridSelectionMode.Cell; //Включение возможности выделения отдельных ячеек.
            this.Selection.EnableMultiSelection = true;

            //Selection BorderColor
            var Selection1 = this.Selection as SelectionBase;
            DevAge.Drawing.RectangleBorder border = Selection1.Border;
            border.SetColor(Color.FromArgb(6, 1, 214));
            Selection1.Border = border;
           
            //252, 254, 167 - Светло желтый
            //239, 245, 107 - Желтый
            //142, 142, 255 - Сиреневый
            Selection1.BackColor = Color.FromArgb(50, Color.FromArgb(142, 142, 255)); 
            
            //Selection BorderWidth
            DevAge.Drawing.RectangleBorder b = Selection1.Border;
            b.SetWidth(1);
            Selection1.Border = b;

            //Selection FocusBackColor
            Selection1.FocusBackColor = Color.FromArgb(50, Color.FromArgb(226, 254, 118));                               

            this.ClipboardMode = SourceGrid.ClipboardMode.Copy;
            //DG.AutoStretchColumnsToFitWidth = true;
            //DG.AutoStretchRowsToFitHeight = false;
            //DG.AutoSizeCells();
            //DG.Rows.HeaderHeight = 40;
            //DG.BackgroundImage = null;
            
            PreviewKeyDown += PreviewKeyDown1; 
        }
             
        /// <summary>
        /// Копировать выделенную облать из FBA.GridFBA в буфер обмена с названиями столбцов.
        /// </summary>
        /// <param name="copyWithCaptions">Если true, то в результат попадает шапка таблицы</param>
        /// <param name="copyAll">Если false берётся для копирования выделенная область, иначе вся таблица.</param>
        /// <returns>Если успешно, то true</returns>
        public bool CopyRegion(bool copyWithCaptions, bool copyAll)
        {
            if (DataSource == null) return false;
            System.Data.DataTable dt;

            if (!copyAll)
            {
                int[] rows = Selection.GetSelectionRegion().GetRowsIndex();
                int[] cows = Selection.GetSelectionRegion().GetColumnsIndex();
                if ((rows.Length > 0) && (cows.Length > 0)) dt = SelectedRowsToDataTable(false);
                else dt = GetDataSource();
            } else dt = GetDataSource();

            var lines = new List<string>();
            lines = dt.GetDataTableAsText(Var.TAB, copyWithCaptions); //"\t" - Таблуляция

            //lines.

            string result = String.Join(Var.CR, lines);
            result.CopyToClipboard(); //
            //Clipboard.SetText(result, TextDataFormat.UnicodeText);

            return true;

            //System.Data.DataTable DT = DG.GetDataTable();
            //File.WriteAllLines(FileName, lines, System.Text.Encoding.Default);
            /*
            StringBuilder builder = new StringBuilder("");
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    builder.Append(grid[j, i].Value.ToString());
                    builder.Append(";");
                }
                builder.Replace(";", "|", builder.Length - 1, 1);
            }
            builder.Remove(builder.Length - 1, 1);
            string data = builder.ToString();
            data = data.Replace("|", "\n");
            Clipboard.SetText(data, TextDataFormat.CommaSeparatedValue);*/
        }
      
        /// <summary>
        /// Выделить всю таблицу.
        /// </summary>
        /// <returns></returns>
        public void SelectAll()
        {
            //SourceGrid.GridSelectionMode smold = DG.SelectionMode;  
            for (int iCol = 0; iCol < Columns.Count; iCol++) Selection.SelectColumn(iCol, true);                                
        }
     
        /// <summary>
        /// Открыть в Excel таблицу, открытую в FBA.GridFBA.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public bool SourceGridToExcel()
        {
            if (DataSource == null) return false;            
            System.Data.DataTable dt;
            int[] rows = Selection.GetSelectionRegion().GetRowsIndex();
            int[] cows = Selection.GetSelectionRegion().GetColumnsIndex();
            if ((rows.Length > 1) || (cows.Length > 1)) dt = SelectedRowsToDataTable(false);         
            else dt = GetDataSource();                  
            if (dt == null) return false;
            return sys.DataTableToExcel(dt);
        }
         
        /// <summary>
        /// Открыть в Excel таблицу, открытую в FBA.GridFBA.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public bool SourceGridToCSV()
        {                     
            System.Data.DataTable dt;
            int[] rows = Selection.GetSelectionRegion().GetRowsIndex();
            int[] cows = Selection.GetSelectionRegion().GetColumnsIndex();
            if ((rows.Length > 1) || (cows.Length > 1)) dt = SelectedRowsToDataTable(false);
            else dt = GetDataSource();
            string fileName = "temp.csv";
            if (!FBAFile.SaveFileName("Сохранение в CSV", "CSV Files|*.csv|Excel Files|*.xls;*.xlsx;|All Files|*.*", "", 0, ref fileName)) return false;
            bool resultSave = sys.DataTableToCSV(dt, fileName, false);
            if (!resultSave) return resultSave;
            if (sys.SM("The file is saved. To open the file?", MessageType.Question)) FBAFile.FileRunSimple(fileName, "");           
            return resultSave;
        }
     
        /// <summary>
        /// Получение номера колонки по её имени
        /// </summary>
        /// <param name="columnName">Имя колонки</param>
        /// <returns>Номер полонки</returns>
        public int GetColumnIndex(string columnName)
        {
         	for (int iCol = 0; iCol < Columns.Count; iCol++)
            {
                if (Columns[iCol].PropertyName == columnName) return iCol;
            }
            return -1;
        }
        
        /// <summary>
        /// Получить текстовое значение ячейки FBA.GridFBA по номеру строки и номеру колонки.
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="iCol"></param>
        /// <returns>Текстовое значение ячейки</returns>
        public string Value(int iRow, int iCol)
        {        	        	      
        	SourceGrid.Position posCell = new SourceGrid.Position(iRow, iCol);        	        
            SourceGrid.Cells.ICellVirtual cell = GetCell(iRow, iCol);
            SourceGrid.CellContext cellContext = new SourceGrid.CellContext(this, posCell, cell);
            if (cellContext.Value == null) return "";
            return cellContext.Value.ToString();
        }
      
        /// <summary>
        /// Получить текстовое значение ячейки FBA.GridFBA по номеру строки и названию колонки.
        /// </summary>
        /// <param name="iRow">Номер строки</param>
        /// <param name="columnName">Название колонки</param>
        /// <returns>Текстовое значение ячейки</returns>
        public string Value(int iRow, string columnName)
        {                        
        	return Value(iRow, GetColumnIndex(columnName));
        } 
              
        /// <summary>
        /// Получение значения в колонке с именем первой выделенной строки. 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="showError">Показывать ошибки, если false и возникнет ошибка, то вернёт null</param>
        /// <returns>Текстовое значение ячейки</returns>
        public string Value(string columnName, bool showError = true)
        {        	
        	return Value(GetColumnIndex(columnName), showError);
        }
                
		/// <summary>
        /// Получение значения в колонке с номером первой выделенной строки. 
        /// </summary>
        /// <param name="columnIndex">Если ColumnIndex ==-1 берём значение из первой выделенной колонки</param>
        /// <param name="showError">Показывать ошибки, если false и возникнет ошибка, то вернёт null</param>
        /// <returns>Текстовое значение ячейки</returns>
        public string Value(int columnIndex, bool showError = true)
        {
            if ((columnIndex < -1) || (columnIndex > (Columns.Count - 1)))
            {
                if (showError) sys.SM("Invalid column index: " + columnIndex.ToString() + " Range: 0.." + (Columns.Count - 1).ToString());
                return "";
            }

            //DG.GetCellsAtRow(
            //DG.Selection.
            //DG.GetCell()
            //object[] rows = DG.SelectedDataRows;
            //object[] cels = DG.GetCellsAtRow(rows[0]);
            
            if (columnIndex == -1)
            {
                int[] cows = Selection.GetSelectionRegion().GetColumnsIndex();
                columnIndex = cows[0];
            }
            int[] rowsSel = Selection.GetSelectionRegion().GetRowsIndex();
            if (rowsSel        == null) return "";
            if (rowsSel.Length == 0)    return "";        
            var posCell = new SourceGrid.Position(rowsSel[0], columnIndex);
            SourceGrid.Cells.ICellVirtual cell = GetCell(rowsSel[0], columnIndex);

            var cellContext = new SourceGrid.CellContext(this, posCell, cell);     
            if (cellContext.Value == null) return "";
            return cellContext.Value.ToString();
        }        
        
        /// <summary>
        /// Получение координат выделенной области из FBA.GridFBA.
        /// </summary>
        /// <param name="areaLeft">Left</param>
        /// <param name="areaTop">Top</param>
        /// <param name="areaRight">Right</param>
        /// <param name="areaBottom">Bottom</param>
        public void GetSelectedArea(out int areaLeft, out int areaTop, out int areaRight, out int areaBottom)
        {
            areaLeft   = 0;
            areaTop    = 0;
            areaRight  = 0;
            areaBottom = 0;
            SourceGrid.RangeRegion rg = Selection.GetSelectionRegion();
            int[] rows = rg.GetRowsIndex();
            int[] cows = rg.GetColumnsIndex();
            areaLeft  = cows[0];
            areaTop   = rows[0];
            areaRight  = cows[cows.Length - 1];            
            areaBottom = rows[rows.Length - 1];
        }
       
       
        /// <summary>
        /// Копирование выделенные строки из FBA.GridFBA в DataTable. 
        /// </summary>
        /// <param name="onlyFirstColumn">Если OnlyFirstColumn = true, то возвращается только первая колонка, иначе все колонки.</param>
        /// <returns>System.Data.DataTable</returns>
        public System.Data.DataTable SelectedRowsToDataTable(bool onlyFirstColumn)
        {
            System.Data.DataTable dt = ((DevAge.ComponentModel.BoundDataView)DataSource).DataTable;                        
            if (dt == null) return null;
            System.Data.DataTable dtClone;
            dtClone = dt.Clone();
            int[] rows = Selection.GetSelectionRegion().GetRowsIndex();
            
            //Копирование выделенных строк в другой DataTable.
            for (int iRow = 0; iRow < rows.Length; iRow++)
            {
                System.Data.DataRow row;
                int n = rows[iRow] - 1;
                if ((n > -1) && (n < dt.Rows.Count))
                {
                    row = dt.Rows[rows[iRow] - 1];
                    dtClone.ImportRow(row);                   
                }
            }
            if (!onlyFirstColumn) return dtClone;
            
			for (int iCol = dt.Columns.Count - 1; iCol > 0; iCol--)
			{
				dtClone.Columns.RemoveAt(iCol);
			}				
            return dtClone;
        }
                                            
        /// <summary>
        /// Получение массива значений всех выделенных строк в колонке с индексом ColumnIndex.
        /// </summary>
        /// <param name="columnIndex">Номер колонки</param>
        /// <param name="showError">Показывать ошибки</param>
        /// <returns>Список значений колонки в массиве saring[]</returns>
        public string[] GetSelectedValues(int columnIndex, bool showError)
        {
            if ((columnIndex < 0) || (columnIndex > (Columns.Count - 1)))
            {
                if (showError) sys.SM("Invalid column index: " + columnIndex.ToString() + " Range: 0.." + (Columns.Count - 1).ToString());
                return null;
            }
    
            int[] rows = Selection.GetSelectionRegion().GetRowsIndex();
            int selectedCount = rows.Count();
    
            var res = new string[selectedCount];                     
            for (int i = 0; i < selectedCount; i++)
            {
                var posCell = new SourceGrid.Position(rows[i], columnIndex);
                SourceGrid.Cells.ICellVirtual cell = GetCell(rows[i], columnIndex);
                var cellContext = new SourceGrid.CellContext(this, posCell, cell);
                if (cellContext.Value != null) res[i] = cellContext.Value.ToString();
            }
            return res;
        }                        
        
        /// <summary>
        /// Функция присвоения SourceGrid.DataSource = DataTable.
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetDataSource(System.Data.DataTable dt)
        {          
            const int columnWidth = 100;
            Columns.Clear();
            if (dt == null)
            {
                BackgroundImage = global::FBA.Resource.no_data;
                return false;
            }                     
            if (DataSource == null)
            {
                //Возможность выделять несколько строк.
                this.SelectionMode = SourceGrid.GridSelectionMode.Cell; //Включение возможности выделения отдельных ячеек.
                this.Selection.EnableMultiSelection = true;            
                var selection = Selection as SelectionBase;
                DevAge.Drawing.RectangleBorder border = selection.Border;
                border.SetColor(Color.FromArgb(6, 1, 214));
                selection.Border = border;   
                selection.BackColor = Color.FromArgb(50, Color.FromArgb(142, 142, 255));   //Сиреневый                                                                                          
                DevAge.Drawing.RectangleBorder b = selection.Border;
                b.SetWidth(1);
                selection.Border = b;        
                selection.FocusBackColor = Color.FromArgb(50, Color.FromArgb(226, 254, 118));
                ClipboardMode = SourceGrid.ClipboardMode.Copy;             
            }           
                                                            
            var bd = new DevAge.ComponentModel.BoundDataView(dt.DefaultView);        
            DataSource = bd;
            Rows.HeaderHeight = 60;

            Color color3 = Color.FromArgb(243, 243, 243);  
            SourceGrid.Cells.Views.Header view3 = new SourceGrid.Cells.Views.ColumnHeader();   
            view3.TextAlignment = ContentAlignment.MiddleCenter;
            view3.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            view3.WordWrap = true;
            view3.ForeColor = Color.FromArgb(1, 11, 182);  
			view3.BackColor = Color.FromArgb(50, Color.FromArgb(239, 245, 107)); //Желтый
		
            int i = 0;        
            foreach (SourceGrid.DataGridColumn col in Columns)
            {
                //AlternateColor
                SourceGrid.Conditions.ICondition condition = SourceGrid.Conditions.ConditionBuilder.AlternateView(col.DataCell.View, color3, Color.Black);
                col.Conditions.Add(condition);

                //Header
                col.HeaderCell.View = view3;

                //Установка ширины колонок из фильтра.
                col.Width = columnWidth;
                i++;
            }         
            return true;                
        }                              
        
        /// <summary>
        /// Получение DataTable из FBA.GridFBA.
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataSource()
        {          
            return((DevAge.ComponentModel.BoundDataView)DataSource).DataTable;
        }
          
        /// <summary>
        /// Атрибут     
        /// </summary>		
        //[DisplayName("DataSourse"), Description("DataSourse"), Category("FBA")]
        //public System.Data.DataTable DataSourse { 
        //	
        //	get { return GetDataSource(); }
        //	set { SetDataSource(value); this.Refresh(); }        
        //}               
        
        /// <summary>
        /// В зависимости от типа выделения (строка, столбец или ячейка) выделяем цветом по индексу столбца и строки.
        /// Два отдельных цвета - для выделения и для выбора.
        /// </summary>
        /// <param name="iRow">Номер строки</param>
        /// <param name="iColumn">Номер колонки</param>
        /// <param name="navigate">Выделять отдельным цветом выбора (выбирать) строку, колонку или область.</param>
        public void SelectColumnRowCell(int iRow, int iColumn, bool navigate)
        {
            Selection.ResetSelection(false);
            //Row
            if (SelectionMode == SourceGrid.GridSelectionMode.Row)
            {
                Selection.SelectRow(iRow, true);
                if (navigate) Selection.FocusRow(iRow);//Перемещаяемся
            }
            else 
            //Column
            if (SelectionMode == SourceGrid.GridSelectionMode.Column)
            {
                Selection.SelectColumn(iColumn, true);
                if (navigate) Selection.FocusColumn(iColumn);
            }
            else
            //Cell
            if (SelectionMode == SourceGrid.GridSelectionMode.Cell)
            {
                var p = new SourceGrid.Position(iRow, iColumn);                
                Selection.SelectCell(p, true);
                if (navigate) Selection.Focus(p, true);
            }             
        }
                
        /// <summary>
        /// По CTRL+L выводим форму с инфой по таблице.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PreviewKeyDown1(object sender, PreviewKeyDownEventArgs e)
		{
	 		//e.IsInputKey = true; 
            if ((e.Control) && (e.KeyCode == Keys.L)) GridInformation();                     
		}
                              
       /// <summary>
        /// Показать информацию о таблице.
        /// </summary>        
        public void GridInformation()
        {                            
        	SourceGrid.RangeRegion rg = Selection.GetSelectionRegion();               
        	string columnWidth = "";
            for (int i = 0; i < Columns.Count; i++) 
            {
            	columnWidth = columnWidth + "Column" + i.ToString() + ".Width: " + Columns[1].Width.ToString() + Var.CR;
            }                                	              
            int[] rows = rg.GetRowsIndex();
            int[] cols = rg.GetColumnsIndex();
            System.Data.DataTable dt = GetDataSource();
            string infoText = "Rows count: " + dt.Rows.Count + Var.CR +
                       "Columns count: " + dt.Columns.Count + Var.CR +
                       "Selected Rows: " + rows.Length.ToString() + Var.CR +
                       "Selected Columns: " + cols.Length.ToString() + Var.CR + 
            		   columnWidth;                 
            sys.SM(infoText, MessageType.Information);
        }                     
    
    
  
    
    }

    //============================================
    // ProgressBar
    //============================================
    /// <summary>
    /// Способ отображения полосы в прогрес-баре.
    /// </summary>
    public enum ProgressBarDisplayText
    {
        /// <summary>
        /// Только проценты
        /// </summary>
    	Percentage,
    	
    	/// <summary>
    	/// Только произвольный текст
    	/// </summary>
        CustomText,
        
        /// <summary>
        /// Проценты и произвольный текст
        /// </summary>
        PercentText        
    }
  
    /// <summary>
    /// Класс потомок System.Windows.Forms.ProgressBar.
    /// </summary>
    public class ProgressBarFBA : System.Windows.Forms.ProgressBar
    {
        private String _TextValue;               
        private ProgressBarDisplayText _TextStyle;//Тип печатаемого текста.
        private System.Drawing.Font  _DisplayFont; //Шрифт вывода текста на прогресс бар.
        private Color _TextColor;   //Цвет текста.

        ///Конструктор.
        public ProgressBarFBA()
        {
            //Изменение флагов ControlStyles
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            DisplayFont = new System.Drawing.Font(FontFamily.GenericSerif, 10);
            _TextColor = Color.Blue; 
        }
        
        /// <summary>
        /// Шрифт для вывода произвольного текста.
        /// </summary>
        public System.Drawing.Font DisplayFont
        {
            get
            {
                return this._DisplayFont;
            }
            set
            {
                _DisplayFont = value;
                Refresh();
            }
        }                    
      
        /// <summary>
        /// Цвет шрифта.
        /// </summary>
        public Color TextColor
        {
            get
            {
                return _TextColor; //Color.FromName(this._TextColor.ToString());
            }
            set
            {
                //value.ToString();
                _TextColor = value; //new SolidBrush(value);
                Refresh();
            }
        }
        
        /// <summary>
        /// Вывод или процентов или произвольного текста.
        /// </summary>
        public ProgressBarDisplayText TextStyle
        {          
            get
            {
                return this._TextStyle;
            }
            set
            {
                _TextStyle = value;
                Refresh();
            }
        }        
      
        /// <summary>
        /// Установка произвольного текста.
        /// </summary>
        public string TextValue
        {
            get
            {
                return this._TextValue;
            }
            set
            {
                _TextValue = value;
                Refresh();
            }
        }
        
        /// <summary>
        /// Вывод процентов и произвольного текста на прогрес-бар.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Rectangle rect = ClientRectangle;
            Graphics g = e.Graphics;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-3, -3);

            int ParamRect = 0;
            if (this.Maximum != 0) ParamRect = (int)Math.Round(((float)Value / this.Maximum) * rect.Width);
            if (Value > 0) 
            {
                //Поскольку мы делаем это сами, нам нужно нарисовать текст на индикаторе прогресса
                System.Drawing.Rectangle clip = new System.Drawing.Rectangle(rect.X, rect.Y, ParamRect, rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }                                  
            //10 - 100 всего интервал 100-10=90
            //значение 50. Значит от начала 50 - 10 = 40. Это в процентах
            //90 == 100%
            //40 -- х?
            //x = (40 * 100) div 90.
            //Итого формула: x = ((this.Value - this.Minimum) * 100) div (this.Maximum - this.Minimum);
            int сurrentValue = this.Value - this.Minimum;
            int сountValue   = this.Maximum - this.Minimum;
            int prc = 0;
            if (сountValue != 0) prc = (сurrentValue * 100) / сountValue;
            string text = "";
            if (_TextStyle == ProgressBarDisplayText.Percentage)  text = prc.ToString() + "%";
            if (_TextStyle == ProgressBarDisplayText.CustomText)  text = _TextValue;
            if (_TextStyle == ProgressBarDisplayText.PercentText) text = prc.ToString() + "%" + " (" + сurrentValue.ToString() + @"/" + сountValue.ToString() + ")";
          
            SizeF len = g.MeasureString(text, DisplayFont);
            
            //Вычислить расположение текста (середина индикатора выполнения)
            System.Drawing.Point location = new System.Drawing.Point(Convert.ToInt32((Width / 2) - len.Width / 2), Convert.ToInt32((Height / 2) - len.Height / 2));

            //Вывод произвольного текста                
            Brush br = Brushes.Blue;
            try
            {
                br = new SolidBrush(_TextColor);
            }
            catch {}
            g.DrawString(text, DisplayFont, br, location);      
        }
    }  
      
    /// <summary>
    /// Класс потомок System.Windows.Forms.GroupBox.
    /// </summary>
    public class GroupBoxFBA : System.Windows.Forms.GroupBox
    {
        string _starText = "*";       
		/// <summary>
		/// Текст - звёздочка. Показывает обязательность заполнения поля. 
		/// Можно вместо звёздочки вывести другой текст.
		/// </summary>
        [DisplayName("StarText"), Description("StarText"), Category("FBA")]
        public string StarText
        {
            get { return _starText; }
            set { _starText = value; this.Refresh(); }
        }

        System.Drawing.Font _starFont = new System.Drawing.Font("Arial", 20);        
        /// <summary>
        /// Шрифт звёздочки.
        /// </summary>
        [DisplayName("StarFont"), Description("StarFont"), Category("FBA")]
        public System.Drawing.Font StarFont
        {
            get { return _starFont; }
            set { _starFont = value; this.Refresh(); }
        }

        int _starOffsetY = -4;        
        /// <summary>
        /// Смещение в пикселях вверх от основного текста по оси Y
        /// </summary>
        [DisplayName("StarOffsetY"), Description("StarOffsetY"), Category("FBA")]
        public int StarOffsetY
        {
            get { return _starOffsetY; }
            set { _starOffsetY = value; this.Refresh(); }
        }

        int _starOffsetX = 2;        
        /// <summary>
        /// Смещение в пикселях вверх от основного текста по оси X
        /// </summary>
        [DisplayName("StarOffsetX"), Description("StarOffsetX"), Category("FBA")]
        public int StarOffsetX
        {
            get { return _starOffsetX; }
            set { _starOffsetX = value; this.Refresh(); }
        }

        Color _StartColor = Color.Crimson;
        /// <summary>
        /// Цвет звёздочки
        /// </summary>
        [DisplayName("StarColor"), Description("StarColor"), Category("FBA")]
        public Color StarColor
        {
            get { return _StartColor; }
            set { _StartColor = value; this.Refresh(); }
        }

        bool _starShow = false;        
        /// <summary>
        /// Показывать или нет звёздочку.
        /// </summary>
        [DisplayName("ShowStar"), Description("Show the star if the attribute is mandatory"), Category("FBA")]
        public bool StarShow
        {
            get { return _starShow; }
            set { _starShow = value; this.Refresh(); }
        }            
    }
    
    /// <summary>
    /// Класс потомок System.Windows.Forms.Label.
    /// </summary>
    public class LabelFBA : System.Windows.Forms.Label
    {
        string _StarText = "*";
        /// <summary>
        /// Текст - звёздочка. Показывает обязательность заполнения поля. 
		/// Можно вместо звёздочки вывести другой текст.
        /// </summary>
        [DisplayName("StarText"), Description("StarText"), Category("FBA")]
        public string StarText
        {
            get { return _StarText; }
            set { _StarText = value; this.Refresh(); }
        }

        System.Drawing.Font _StarFont = new System.Drawing.Font("Arial", 20);
        /// <summary>
        /// Шрифт звёздочки.
        /// </summary>
        [DisplayName("StarFont"), Description("StarFont"), Category("FBA")]
        public System.Drawing.Font StarFont
        {
            get { return _StarFont; }
            set { _StarFont = value; this.Refresh(); }
        }

        int _StarOffsetY = -2;
        /// <summary>
        /// Смещение в пикселях вверх от основного текста по оси Y
        /// </summary>
        [DisplayName("StarOffsetY"), Description("StarOffsetY"), Category("FBA")]
        public int StarOffsetY
        {
            get { return _StarOffsetY; }
            set { _StarOffsetY = value; this.Refresh(); }
        }

        int _StarOffsetX = 2;
        /// <summary>
        /// Смещение в пикселях вверх от основного текста по оси X
        /// </summary>
        [DisplayName("StarOffsetX"), Description("StarOffsetX"), Category("FBA")]
        public int StarOffsetX
        {
            get { return _StarOffsetX; }
            set { _StarOffsetX = value; this.Refresh(); }
        }

        Color _StartColor = Color.Crimson;
        /// <summary>
        /// Цвет звёздочки
        /// </summary>
        [DisplayName("StarColor"), Description("StarColor"), Category("FBA")]
        public Color StarColor
        {
            get { return _StartColor; }
            set { _StartColor = value; this.Refresh(); }
        }

        bool _StarShow = false;
        /// <summary>
        /// Показывать или нет звёздочку.
        /// </summary>
        [DisplayName("ShowStar"), Description("Show the star if the attribute is mandatory"), Category("FBA")]
        public bool StarShow
        {
            get { return _StarShow; }
            set { _StarShow = value; this.Refresh(); }
        }
           
        /// <summary>
        /// Переопределение события Paint.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(e);

            if (!StarShow) return;
            TextFormatFlags flags = TextFormatFlags.NoPadding;
            var proposedSize = new Size(int.MaxValue, int.MaxValue);
            Size size = TextRenderer.MeasureText(
                e.Graphics,
                this.Text,
                this.Font, proposedSize, flags);
            int WidthText = size.Width;

            e.Graphics.DrawString(StarText,
                 StarFont,
                 new SolidBrush(StarColor),
                 //Прямоугольник, куда вписываем строку                      
                 new System.Drawing.Rectangle(WidthText + StarOffsetX, StarOffsetY - 4, this.Width - (WidthText + StarOffsetX), this.Height));
        }
    }
    
    /// <summary>
    /// Класс потомок System.Windows.Forms.TextBox.    
    /// </summary>
    /// <remarks>
    /// Дополнительные возможности TextBox:
    /// Цвет фона компонента меняется, если Enabled = false.
    /// Возможность указать список допустимых символов, свойство: ListValidChars
    /// Возможность указать список допустимых символов, свойство: ListInvalidChars
    /// Возможность указать регулярное выражение для проверки соответствия, свойство: RegExChars
    /// Вместо списка  допустиымых и недопустимых  символов можно указать следующие константы:
    /// DIG: 1234567890
    /// UPPERENG: QWERTYUIOPASDFGHJKLZXCVBNM
    /// LOWERENG: qwertyuiopasdfghjklzxcbnm
    /// ENG: QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm
    /// ENGDIG: 1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm
    /// FLOATDOT: 1234567890.
    /// FLOATCOMMA: 1234567890,
    /// ENGRUSDIG: 1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnmЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё
    /// RUS: ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё
    /// Возможность ввести список значений по двойному клику
    /// </remarks>
    public class TextBoxFBA : System.Windows.Forms.TextBox
    {
    	/// <summary>
    	/// История введённых значений.
    	/// </summary>
        public string[] ValueArray;
        //int WM_KEYDOWN = 0x0100;
        const int WM_PASTE = 0x0302;
        //private System.Drawing.Font userFont;
        //private System.Drawing.Font grayFont;
        
        private Color userFontColor;   
        	
        /// <summary>
        /// Конструктор.
        /// </summary>
        public TextBoxFBA(): base()
        {              
        	Constructor(null);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public TextBoxFBA(string DefaultText): base()
        {              
        	Constructor(DefaultText);
        }
        
        private void Constructor(string DefaultText)
        {
        	this.MouseDoubleClick += FilterInputText;
            this.KeyPress         += TextBoxKeyPress;
            this.EnabledChanged   += EnabledChangedMethod;
            this.Enter            += TextBoxEnter;
            this.Leave            += TextBoxLeave;
            this.DefaultTextGrayColor = Color.Gray;
            if (!string.IsNullOrEmpty(DefaultText)) 
            {
            	userFontColor = this.ForeColor ; 
            	Text = DefaultText;
            	this.ForeColor = Color.Gray;
            }                                 
        }
         
        /// <summary>
        /// Меняем цвет компонента, если Enabled = false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnabledChangedMethod(object sender, EventArgs e)
        {
            if (!Enabled) BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Window);
        }

        private string GetCharStringByNameCharList(string NameCharList)
        {
            if (NameCharList.ToUpper() == "DIG") return "1234567890";
            if (NameCharList.ToUpper() == "UPPERENG") return "QWERTYUIOPASDFGHJKLZXCVBNM";
            if (NameCharList.ToUpper() == "LOWERENG") return "qwertyuiopasdfghjklzxcbnm";
            if (NameCharList.ToUpper() == "ENG") return "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm";
            if (NameCharList.ToUpper() == "ENGDIG") return "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm";
            if (NameCharList.ToUpper() == "FLOATDOT") return "1234567890.";
            if (NameCharList.ToUpper() == "FLOATCOMMA") return "1234567890,";
            if (NameCharList.ToUpper() == "ENGRUSDIG") return "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё";
            if (NameCharList.ToUpper() == "RUS") return "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё";
            return NameCharList;
        }
      
        
        ///Проверяем можно ли вставить данные.
        private bool CanInput(char key, string BufferText)  //Keys keys
        {
            if (this.ReadOnly) return false; // && ModifierKeys != Keys.Shift;    

            if (key.ToString() == "") return true; //CAN непечатный символ - команда CTRL+X
            if (key.ToString() == "") return true; //SYN непечатный символ - команда CTRL+V    
            if (key.ToString() == "") return true; //ETX непечатный символ - команда CTRL+C
            if (key.ToString() == "\b") return true; //Backspace       

            if (sys.IsEmptyID(ListValidChars) && sys.IsEmptyID(ListInvalidChars) && sys.IsEmptyID(RegExChars)) return true;
            if (ListValidChars == null) ListValidChars = "";
            if (ListInvalidChars == null) ListInvalidChars = "";
            if (RegExChars == null) RegExChars = "";

            //Проверка выражения по списку допустимых символов.
            if (ListValidChars != "")
            {
                ListValidChars = GetCharStringByNameCharList(ListValidChars);
                if (BufferText == "")
                {
                    if (ListValidChars.IndexOfEx(key.ToString()) == -1) return false;  //&& (keys != System.Windows.Forms.Keys.Back)                            
                }
                else
                {
                    for (int i = 0; i < BufferText.Length; i++)
                    {
                        string Letter1 = BufferText[i].ToString();
                        if ((ListValidChars.IndexOfEx(Letter1.ToString()) == -1)) return false;
                    }
                }
                return true;
            }

            //Проверка выражения по списку НЕ допустимых символов.
            if (ListInvalidChars != "")
            {
                ListInvalidChars = GetCharStringByNameCharList(ListInvalidChars);
                if (BufferText == "")
                {
                    if (ListInvalidChars.IndexOfEx(key.ToString()) == -1) return true;
                }
                else
                {
                    bool FindNotValidChar = false;
                    for (int i = 0; i < BufferText.Length; i++)
                    {
                        string Letter1 = BufferText[i].ToString();
                        if ((ListInvalidChars.IndexOfEx(Letter1.ToString()) == -1)) FindNotValidChar = true;
                    }
                    if (FindNotValidChar) return false;
                }
                return true;
            }

            //Проверка выражения по регулярному выражению.
            if (RegExChars != "")
            {
                return sys.CheckRegEx(RegExChars, this.Text);
            }
            return true;
        }
   
		/// <summary>
		/// Обработка вставки текста из буфера обмена. 
		/// </summary>
		/// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                IDataObject obj = Clipboard.GetDataObject();
                string BufferText = (string)obj.GetData(typeof(string));
                const char ch = 'x';
                if (!CanInput(ch, BufferText)) return; //ch=NULL недопустим здесь                        
            }
            base.WndProc(ref m);
        }
        
        /// <summary>
        /// Для того чтобы можно было вставить свойство текст "Введите значение" которое появляется, если в компоненте свойство текст не заполнено.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    		
        private void TextBoxEnter(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(DefaultTextGray))
			{
				if (Text == DefaultTextGray) Text = "";
				ForeColor = userFontColor; 
			}			
		}
		
        /// <summary>
        /// Для того чтобы можно было вставить свойство текст "Введите значение" которое появляется, если в компоненте свойство текст не заполнено.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void TextBoxLeave(object sender, EventArgs e)
		{						
			if ((string.IsNullOrEmpty(Text) && (!string.IsNullOrEmpty(DefaultTextGray))))
			{		      
		        ForeColor = DefaultTextGrayColor;
		        Text = DefaultTextGray;
			}							
		}
				       
        /// <summary>
        /// Добавляем свойство KeyPress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {        	        	 
        	e.Handled = !CanInput(e.KeyChar, "");           
        }
               
        ///Ввод списка значений при двойном клике на TextBox полоски фильтра.
        public void FilterInputText(object sender, MouseEventArgs e)
        {
            sys.InputListValues(sender);
        }

        //=============
        //public void KeyDown1(object sender, KeyEventArgs e)
        //{                  
        //    char ch = (char)e.KeyValue;
        //    sys.SM(ch.ToString());
        //}

        //protected override bool ProcessKeyMessage(ref Message m)
        //{
        //    if ((m.Msg == 0x102) || (m.Msg == 0x106)) // this is special - don't remove
        //    {
        //        char c = (char) m.WParam; // here is your char for OnKeyDown event ;)
        //    }
        //    return base.ProcessKeyMessage(ref m);
        //}
        //==================
        
        /// <summary>
        /// Текст, который будет выводиться серым цветом при первоначальном вводе.
        /// Если текст не введён.
        /// </summary>
        [DisplayName("DefaultTextGray"), Description("Text that will be grayed out when you first type."), Category("FBA")]
        public string DefaultTextGray { get; set; }
        
        /// <summary>
        /// Текст, который будет выводиться серым цветом при первоначальном вводе.
        /// Если текст не введён.
        /// </summary>
        [DisplayName("DefaultTextGrayColor"), Description("Font for text that will be grayed out when you first type."), Category("FBA")]
        public Color DefaultTextGrayColor { get; set; }
        
        
        /// <summary>
        /// Дополнительное поле с текстом. Для разных целей.
        /// </summary>
        [DisplayName("Text2"), Description("Text2"), Category("FBA")]
        public string Text2 { get; set; }

        /// <summary>
        /// Регулярное выражение для проверки валидности текста в свойстве Text.
        /// </summary>
        [DisplayName("RegExChars"), Description("Regular expression for valid characters"), Category("FBA")]
        public string RegExChars { get; set; }

        /// <summary>
        /// Список НЕ допустимых значений
        /// </summary>
        [DisplayName("ListInvalidChars"), Description("List of invalid characters"), Category("FBA")]
        public string ListInvalidChars { get; set; }

        /// <summary>
        /// Список допустимых значений
        /// </summary>
        [DisplayName("ListValidChars"), Description("Type only characters in list. you can use the following constants: " +
           "DIG - 1234567890" + Var.CR +
           "UPPERENG   - QWERTYUIOPASDFGHJKLZXCVBNM" + Var.CR +
           "LOWERENG   - qwertyuiopasdfghjklzxcbnm" + Var.CR +
           "ENG        - QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + Var.CR +
           "ENGDIG     - 1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + Var.CR +
           "FLOATDOT   - 1234567890." + Var.CR +
           "FLOATCOMMA - 1234567890," + Var.CR +
           "ENGRUSDIG  - 1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё" + Var.CR +
           "ENGRUSDIG  - QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё" + Var.CR +
           "RUS        - ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё" + Var.CR
           ), Category("FBA")]
        public string ListValidChars { get; set; }

        /// <summary>
        /// Записывать в локальную базу данных историю введённых значений
        /// </summary>
        [DisplayName("SaveValueHistory"), Description("Save history of values in local DataBase"), Category("FBA")]
        public bool SaveValueHistory { get; set; }
        
		/// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках,
        /// при выполнении команды SaveSettings/LoadSettings.  
        /// </summary>        
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
        
		/// <summary>
        /// Атрибут для выбора через ObjectRef
        /// </summary>      
        [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
        public string ObjectRef { get; set; }    

        /// <summary>
        /// Атрибут для выбора через ObjectRef
        /// </summary>     
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }
        
		/// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента.
        /// </summary>        
        [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }

         /// <summary>
        /// Атрибут для выбора через ObjectRef
        /// </summary>       
        [DisplayName("AttrBriefLookup"), Description(""), Category("FBA")]
        public string AttrBriefLookup { get; set; }
   
        /// <summary>
        /// Требуем заполнение компонента значениями.  
        /// </summary>
        [DisplayName("ErrorIfNull"), Description(""), Category("FBA")]
        public string ErrorIfNull { get; set; }
    }
   
    /// <summary>
    /// Класс потомок ComboBoxEx.
    /// </summary>
    public class ComboBoxFBA : System.Windows.Forms.ComboBox
    {
        /// <summary>
        /// Список строк для раскрывающегося списка.
        /// </summary>
    	public string[] ValueArray;
        //int WM_KEYDOWN = 0x0100;
        const int WM_PASTE = 0x0302;
        //SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted);
        private string _ObjectID = "";
        
        private Color userFontColor;
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ComboBoxFBA(): base()
        {              
        	Constructor(null);
        }
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ComboBoxFBA(string DefaultText): base()
        {              
        	Constructor(DefaultText);
        }
        
		/// <summary>
        /// Конструктор.
        /// </summary>
        private void Constructor(string DefaultText)
        {                	      
            this.MouseDoubleClick         += FilterInputText;
            this.KeyPress                 += TextBoxKeyPress;
            this.EnabledChanged           += EnabledChangedMethod;
            this.SelectionChangeCommitted += SelectionChangeCommitted2;
            
            if (!_ContextMenuEnabled)
            {
                ContextMenu = new ContextMenu();
                ContextMenuStrip = new ContextMenuStrip();
            }
            if (!string.IsNullOrEmpty(DefaultText)) 
            {
            	userFontColor = this.ForeColor ; 
            	Text = DefaultText;
            	this.ForeColor = Color.Gray;
            }  
        }              
        
        private void SelectionChangeCommitted2(object sender, EventArgs e)
        {                      
            if (ObjRef != null)
            {
                this.ObjectID = this.SelectedIndex.ToString();
                ObjRef[AttrBrief] = this.SelectedIndex.ToString();
            }
        }

        /// <summary>
        /// Для того чтобы можно было вставить свойство текст "Введите значение" которое появляется, если в компоненте свойство текст не заполнено.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    		
        private void ComboBoxEnter(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(DefaultTextGrayFont))
			{
				if (Text == DefaultTextGrayFont) Text = "";
				Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			}			
		}
		
        /// <summary>
        /// Для того чтобы можно было вставить свойство текст "Введите значение" которое появляется, если в компоненте свойство текст не заполнено.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ComboBoxLeave(object sender, EventArgs e)
		{						
			if ((string.IsNullOrEmpty(Text) && (!string.IsNullOrEmpty(DefaultTextGrayFont))))
			{
		        Font = new System.Drawing.Font("Courier New", 25.25F);
		        Text = DefaultTextGrayFont;
			}							
		} 
        
        /// <summary>
        /// Текст, который будет выводиться серым цветом при первоначальном вводе.
        /// Если текст не введён.
        /// </summary>
        [DisplayName("DefaultTextGrayFont"), Description("Text that will be grayed out when you first type."), Category("FBA")]
        public string DefaultTextGrayFont { get; set; }
        
		
        /// <summary>
        /// Привязанный ИД объект.
        /// </summary>
        [DisplayName("ObjectID"), Description("ObjectID"), Category("FBA")]
        public string ObjectID
        {
            get { return _ObjectID; }
            set { _ObjectID = value; }
        }
        
        /// <summary>
        /// Ссылка на ObjectRef
        /// </summary>
        [DisplayName("ObjRef"), Description("ObjectRef"), Category("FBA")]
        public ObjectRef ObjRef { get; set; }
     
        /// <summary>
        /// Меняем цвет компонента, если Enabled = false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnabledChangedMethod(object sender, EventArgs e)
        {
            if (!Enabled) BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Window);
        }

        private string GetCharStringByNameCharList(string NameCharList)
        {
            if (NameCharList.ToUpper() == "DIG") return "1234567890";
            if (NameCharList.ToUpper() == "UPPERENG") return "QWERTYUIOPASDFGHJKLZXCVBNM";
            if (NameCharList.ToUpper() == "LOWERENG") return "qwertyuiopasdfghjklzxcbnm";
            if (NameCharList.ToUpper() == "ENG") return "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm";
            if (NameCharList.ToUpper() == "ENGDIG") return "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm";
            if (NameCharList.ToUpper() == "FLOATDOT") return "1234567890.";
            if (NameCharList.ToUpper() == "FLOATCOMMA") return "1234567890,";
            if (NameCharList.ToUpper() == "ENGRUSDIG") return "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё";
            if (NameCharList.ToUpper() == "RUS") return "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё";
            return NameCharList;
        }
   
        /// <summary>
        /// Проверяем можно ли вставить данные.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="BufferText"></param>
        /// <returns></returns>
        private bool CanInput(char key, string BufferText)  //Keys keys
        {
            if (this.ReadOnly) return false; // && ModifierKeys != Keys.Shift;    

            if (key.ToString() == "") return true; //CAN непечатный символ - команда CTRL+X
            if (key.ToString() == "") return true; //SYN непечатный символ - команда CTRL+V    
            if (key.ToString() == "") return true; //ETX непечатный символ - команда CTRL+C
            if (key.ToString() == "\b") return true; //Backspace       

            if (sys.IsEmptyID(ListValidChars) && sys.IsEmptyID(ListInvalidChars) && sys.IsEmptyID(RegExChars)) return true;
            if (ListValidChars == null) ListValidChars = "";
            if (ListInvalidChars == null) ListInvalidChars = "";
            if (RegExChars == null) RegExChars = "";

            //Проверка выражения по списку допустимых символов.
            if (ListValidChars != "")
            {
                ListValidChars = GetCharStringByNameCharList(ListValidChars);
                if (BufferText == "")
                {
                    if (ListValidChars.IndexOfEx(key.ToString()) == -1) return false;  //&& (keys != System.Windows.Forms.Keys.Back)                            
                }
                else
                {
                    for (int i = 0; i < BufferText.Length; i++)
                    {
                        string Letter1 = BufferText[i].ToString();
                        if ((ListValidChars.IndexOfEx(Letter1.ToString()) == -1)) return false;
                    }
                }
                return true;
            }

            //Проверка выражения по списку НЕ допустимых символов.
            if (ListInvalidChars != "")
            {
                ListInvalidChars = GetCharStringByNameCharList(ListInvalidChars);
                if (BufferText == "")
                {
                    if (ListInvalidChars.IndexOfEx(key.ToString()) == -1) return true;
                }
                else
                {
                    bool FindNotValidChar = false;
                    for (int i = 0; i < BufferText.Length; i++)
                    {
                        string Letter1 = BufferText[i].ToString();
                        if ((ListInvalidChars.IndexOfEx(Letter1.ToString()) == -1)) FindNotValidChar = true;
                    }
                    if (FindNotValidChar) return false;
                }
                return true;
            }

            //Проверка выражения по регулярному выражению.
            if (RegExChars != "")
            {
                return sys.CheckRegEx(RegExChars, this.Text);
            }
            return true;
        }

        ///Обработка вставки текста из буфера обмена.        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                IDataObject obj = Clipboard.GetDataObject();
                string BufferText = (string)obj.GetData(typeof(string));
                const char ch = 'x';
                if (!CanInput(ch, BufferText)) return; //ch=NULL недопустим здесь                        
            }
            base.WndProc(ref m);
        }   
        
        /// <summary>
        /// Добавляем свойство ReadOnly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ReadOnly) e.Handled = true; //e.KeyChar = (char)Keys.None;
            else e.Handled = !CanInput(e.KeyChar, "");
        }
       
        /// <summary>
        /// Ввод списка значений при двойном клике на TextBox полоски фильтра.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FilterInputText(object sender, MouseEventArgs e)
        {
            sys.InputListValues(sender);
        }
      
        /// <summary>
        /// Дополнительное поле с текстом. Для разных целей.
        /// </summary>
        [DisplayName("Text2"), Description("Text2"), Category("FBA")]
        public string Text2 { get; set; }

        /// <summary>
        /// Регулярное выражение для проверки текста свойстве Text.
        /// </summary>
        [DisplayName("RegExChars"), Description("Regular expression for valid characters"), Category("FBA")]
        public string RegExChars { get; set; }

        /// <summary>
        /// Список НЕ допустимых значений
        /// </summary>
        [DisplayName("ListInvalidChars"), Description("List of invalid characters"), Category("FBA")]
        public string ListInvalidChars { get; set; }

        /// <summary>
        /// Список допустимых значений. Также допустимы сокращения: DIG, UPPERENG, LOWERENG, ENG, ENGDIG, FLOATDOT, FLOATCOMMA, ENGRUSDIG, ENGRUSDIG, RUS
        /// DIG - 1234567890
        /// UPPERENG   - QWERTYUIOPASDFGHJKLZXCVBNM
        /// LOWERENG   - qwertyuiopasdfghjklzxcbnm
        /// ENG        - QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm
        /// ENGDIG     - 1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm
        /// FLOATDOT   - 1234567890.
        /// FLOATCOMMA - 1234567890,
        /// ENGRUSDIG  - 1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё
        /// ENGRUSDIG  - QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё
        /// RUS        - ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё 
        /// </summary>
        [DisplayName("ListValidChars"), Description("Type only characters in list. you can use the following constants: " +
           "DIG - 1234567890" + Var.CR +
           "UPPERENG   - QWERTYUIOPASDFGHJKLZXCVBNM" + Var.CR +
           "LOWERENG   - qwertyuiopasdfghjklzxcbnm" + Var.CR +
           "ENG        - QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + Var.CR +
           "ENGDIG     - 1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + Var.CR +
           "FLOATDOT   - 1234567890." + Var.CR +
           "FLOATCOMMA - 1234567890," + Var.CR +
           "ENGRUSDIG  - 1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё" + Var.CR +
           "ENGRUSDIG  - QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcbnm" + "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё" + Var.CR +
           "RUS        - ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁйцукенгшщзхъфывапролджэячсмитьбюё" + Var.CR
           ), Category("FBA")]
        public string ListValidChars { get; set; }
 
        
      
        // Свойства:      
        // Свойство bool SaveValueHistory. Сохранять или не сохранять историю введённых вручную значений. 
        // Свойство bool SaveParam. Признак что значение компонента можно сохранять/загружать в настройках, при выполнении команды SaveSettings/LoadSettings. 
        // Свойство string ObjectRef. Атрибут для выбора через ObjectRef. 
        // Свойство string AttrBrief. Атрибут для выбора через ObjectRef. 
        // Это свойство string . Имена компонентов со свойством на форме родителе, которое влияет на свойство Enabled/Disabled данного компонента. 
        // Оно нужно для того чтобы пакетно устанавливать компоненты на форме в Enabled = false или true. Пример: cb_ID;!cb_Number;cb_Type." +
        // Это означает что контрол будет Enable = true при следующих условиях: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked.
        // Свойство stirng ERRORIFNUL. Требовать заполнение компонента значением. 
        // Свойство ContextMenuEnabledЕсли поставить False стандартное контекстное меню перестанет появляться. 
        // Свойство ValueHistoryInItems. Показывать историю предыдущих введённых значений.
        // Свойство SaveType.Для того чтобы определить что сохранять при включенном свойстве SaveValueHistory: свойство Text или свойство SelectedIndex.     
                          
        //Методы: 
        //Присвоить ComboBox свойство DataSourse. Только первую колонку.
        //public void SetDataSourse(System.Data.DataTable dt)
        	
        // Присвоить ComboBox свойство DataSourse из запроса SQL. SQL должен возвращать одну колонку.
        //public void SetDataSourceSQL(DirectionQuery direction, string sql)

        	        	
        /// <summary>
        /// Сохранять или не сохранять историю введённых вручную значений. 
        /// </summary>
        [DisplayName("SaveValueHistory"), Description("Save history of values in local DataBase"), Category("FBA")]
        public bool SaveValueHistory { get; set; }
          
		/// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках,
        /// при выполнении команды SaveSettings/LoadSettings. 
        /// </summary>       
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
    
		/// <summary>
        /// Атрибут для выбора через ObjectRef. 
        /// </summary>         
        [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
        public string ObjectRef { get; set; }

        /// <summary>
        /// Атрибут для выбора через ObjectRef. 
        /// </summary>           
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }
       
		/// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента. 
        /// </summary>            
        [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }

        /// <summary>
        /// Атрибут для выбора через ObjectRef. 
        /// </summary>      
        [DisplayName("AttrBriefLookup"), Description(""), Category("FBA")]
        public string AttrBriefLookup { get; set; }
        
		/// <summary>
        /// Требуем заполнение компонента значениями.   
        /// </summary>              
        [DisplayName("ErrorIfNull"), Description(""), Category("FBA")]
        public string ErrorIfNull { get; set; }

        
        /// <summary>
        /// Ссылка на ObjectRef.
        /// </summary>
        [DisplayName("Obj"), Description("ObjectRef"), Category("FBA")]
        public ObjectRef Obj { get; set; }
        
		/// <summary>
        /// Добавляем свойство "Только для чтения"
        /// </summary>          
        [DisplayName("ReadOnly"), Description(""), Category("FBA")]
        public bool ReadOnly { get; set; }
        
        /// <summary>
        /// Показывать историю предыдущих введённых значений.
        /// </summary>
        [DisplayName("ValueHistoryInItems"), Description("Show history of previous values of items"), Category("FBA")]
        public bool ValueHistoryInItems { get; set; }
   
		/// <summary>
        /// Указываем что сохранять свойство Text или SelectedIndex.     
        /// </summary>       
        [DisplayName("SaveType"), Description("Type of Attribute: INDEX, TEXT, LOOKUP"), Category("FBA")]
        public string SaveType { get; set; }
     
        bool _ContextMenuEnabled = true;
	    /// <summary>
        /// Если поставить False стандартное контекстное меню перестанет появляться. 
        /// </summary>
        [DisplayName("ContextMenuEnabled"), Description("If False, the standard context menu will no longer appear."), Category("FBA")]
        public bool ContextMenuEnabled
        {
            get { return _ContextMenuEnabled; }
            set { _ContextMenuEnabled = value; this.Refresh(); }
        }   

        /// <summary>
        /// Присвоить ComboBox свойство DataSourse. Только первую колонку.
        /// </summary>      
        /// <param name="dt">System.Data.DataTable</param>
        public void SetDataSourse(System.Data.DataTable dt)
        {
            if (dt == null) return;
            ValueMember   = dt.Columns[0].Caption;
            DisplayMember = ValueMember;
            DataSource    = dt;            
        }                         
                  
        /// <summary>
        /// Присвоить ComboBox свойство DataSourse из запроса SQL. SQL должен возвращать одну колонку.
        /// </summary>
        /// <param name="direction">Запрос к локальной или удалённой БД</param>      
        /// <param name="sql">Запрос SQL</param>
        public void SetDataSourceSQL(DirectionQuery direction, string sql)
        {      
            System.Data.DataTable DT;
            sys.SelectDT(direction, sql, out DT);
            SetDataSourse(DT);                
        }
        
        /// <summary>
        /// Присвоить ComboBox свойство DataSourse из запроса SQL. SQL должен возвращать одну колонку.
        /// </summary>         
        /// <param name="msql">Запрос MSQL</param>
        public void SetDataSourceMSQL(string msql)
        {      
            System.Data.DataTable DT;
            string sql = sys.Parse(msql);            
            sys.SelectDT(DirectionQuery.Remote, sql, out DT);
            SetDataSourse(DT);                
        }
        
        /// <summary>
        /// Выделить строку в ComboBox. Если такое значение найдено, изменится SelectedIndex.
        /// </summary>       
        /// <param name="str">Строка, которую ищем в ComboBox</param>
        public void SelectStr(string str)
        {
            int index = FindStringExact(str);
            if (index > -1) SelectedIndex = index;            
        }
        
        /// <summary>
        /// Получение выбранного значения в ComboBox.
        /// </summary>       
        /// <returns>Выбранное значение в cb</returns>
        public string ComboBoxStr()
        {   
            if (Items.Count == 0)   return "";
            if (DataSource == null) return SelectedValue.ToString();
               else return ((System.Data.DataTable)DataSource).Rows[SelectedIndex][0].ToString();
        }                         
        
       
    }
  
    /// <summary>
    /// Класс потомок System.Windows.Forms.CheckBox.
    /// </summary>
    public class CheckBoxFBA : System.Windows.Forms.CheckBox
    {
        /// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках, 
        /// при выполнении команды SaveSettings/LoadSettings.     
        /// </summary>
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
      
		/// <summary>
        /// Атрибут для выбора через ObjectRef.     
        /// </summary>		
        [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
        public string ObjectRef { get; set; }

		/// <summary>
        /// Атрибут для выбора через ObjectRef.    
        /// </summary>	        
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }

        /// <summary>
        /// Привязанный компонент ObjectRef
        /// </summary>
        [DisplayName("Obj"), Description("ObjectRef"), Category("FBA")]
        public ObjectRef Obj { get; set; }
      
		/// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента. 
        /// </summary>       
        [DisplayName("GroupEnabled"),
        Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }

        /*bool _StarShow = false;
        [DisplayName("ShowStar"), Description("Show the star if the attribute is mandatory"), Category("FBA")]
        public bool StarShow 
        {
            get { return _StarShow; }
            set { _StarShow = value; this.Refresh(); }
        }
               
        string _StarText = "*";
        [DisplayName("StarText"), Description("StarText"), Category("FBA")]         
        public string StarText
        {
            get { return _StarText; }
            set { _StarText = value; this.Refresh(); }
        } 
        
        Font _StarFont = new Font("Arial", 20);
        [DisplayName("StarFont"), Description("StarFont"), Category("FBA")]      
        public Font StarFont
        {
            get { return _StarFont; }
            set { _StarFont = value; this.Refresh(); }
        }              
        
        int _StarOffsetY = -4;
        [DisplayName("StarOffsetY"), Description("StarOffsetY"), Category("FBA")]      
        public int StarOffsetY
        {
            get { return _StarOffsetY; }
            set { _StarOffsetY = value; this.Refresh(); }
        } 
        
        int _StarOffsetX = 2;
        [DisplayName("StarOffsetX"), Description("StarOffsetX"), Category("FBA")]      
        public int StarOffsetX
        {
            get { return _StarOffsetX; }
            set { _StarOffsetX = value; this.Refresh(); }
        }
        
        Color _StarColor = Color.Crimson;
        [DisplayName("StarColor"), Description("StarColor"), Category("FBA")]             
        public Color StarColor 
        {
            get { return _StarColor; }
            set { _StarColor = value; this.Refresh(); }
        }*/

        //Вывод дополнительного текста. 
        /*protected override void OnDrawItem(DrawItemEventArgs e)
        {      
            string TabText = this.Text;                          
            Size sz1 = TabText.Trim().GetTextLength(this.Font);
            Size sz2 = _StarText.GetTextLength(_StarFont);
            
            //Если нужно выделить цветом активную вкладку.
            //if ((this.SelectedIndex == e.Index) && (_SetSelectTabBackColor))
            //{
            //    Graphics g = e.Graphics;
            //    SolidBrush sb = new SolidBrush(_SelectTabBackColor);
            //    g.FillRectangle(sb, e.Bounds);
            //}
            
            //Color color1 = _TabFontColor;
            //if (this.SelectedIndex == e.Index) 
            //{
            //    color1 = _SelectTabFontColor;
            //    //TabFontColor = _SelectTabFontColor; //Color.BlueViolet;
            //}
                       
            //Прямоугольник, куда вписываем строку              
            e.Graphics.DrawString(TabText,                         
            this.Font,            
            new SolidBrush(this.BackColor),                                   
            new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 3, e.Bounds.Width + 2, e.Bounds.Height));          
                           
            //if (e.Index != _StarPageIndex) return;
            if (!_StarShow) return;
            e.Graphics.DrawString(_StarText,                   
            _StarFont,            
            new SolidBrush(_StarColor),                           
            new Rectangle(e.Bounds.X  + 2 + sz1.Width + _StarOffsetX, e.Bounds.Y + 3 + _StarOffsetY, sz2.Width + 10, e.Bounds.Height));        
        } */
    }
 
    /// <summary>
    /// Класс потомок System.Windows.Forms.RadioButton.
    /// </summary>
    public class RadioButtonFBA : System.Windows.Forms.RadioButton
    {         
        /// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках, 
        /// при выполнении команды SaveSettings/LoadSettings. 
        /// </summary>
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
        
		/// <summary>
        /// Атрибут для выбора через ObjectRef.  
        /// </summary>       
        [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
        public string ObjectRef { get; set; }

        /// <summary>
        /// Атрибут для выбора через ObjectRef.  
        /// </summary>   
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }       
		
        /// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента. 
        /// </summary>          
        [DisplayName("Grou pEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }

        /// <summary>
        /// Привязанный объект ObjectRef.
        /// </summary>
        [DisplayName("Obj"), Description("ObjectRef"), Category("FBA")]
        public ObjectRef Obj { get; set; }
    }
 
    /// <summary>
    /// Класс потомок System.Windows.Forms.Panel.
    /// </summary>
    public class PanelFBA : System.Windows.Forms.Panel
    {        
		/// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках, 
        /// при выполнении команды SaveSettings/LoadSettings.  
        /// </summary>	        
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
       
		/// <summary>
        /// Атрибут для выбора через ObjectRef.     
        /// </summary>	       
        [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
        public string ObjectRef { get; set; }
           
		/// <summary>
        /// Атрибут для выбора через ObjectRef.     
        /// </summary>		
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }
                        
        /// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента.    
        /// </summary>
        [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }

        /// <summary>
        /// Привязанный объект ObjectRef.
        /// </summary>
        [DisplayName("Obj"), Description("ObjectRef"), Category("FBA")]
        public ObjectRef Obj { get; set; }
    }
   
    /// <summary>
    /// Класс потомок System.Windows.Forms.Button.
    /// </summary>
    public class ButtonFBA : System.Windows.Forms.Button
    {                
		/// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках, 
        /// при выполнении команды SaveSettings/LoadSettings.      
        /// </summary>
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
        
		/// <summary>
        /// Атрибут для выбора через ObjectRef.    
        /// </summary>       
        [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
        public string ObjectRef { get; set; }

        /// <summary>
        /// Атрибут для выбора через ObjectRef.    
        /// </summary>        
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }       

		/// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента.  
        /// </summary>    
        [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }

        /// <summary>
        /// Привязанный компонент ObjectRef.
        /// </summary>
        [DisplayName("Obj"), Description("ObjectRef"), Category("FBA")]
        public ObjectRef Obj { get; set; }
    }
 
    /// <summary>
    /// Класс потомок System.Windows.Forms.TabControl.
    /// </summary>
    public class TabControlFBA : System.Windows.Forms.TabControl
    {       
    	/// <summary>
    	/// Конструктор.
    	/// </summary>
    	public TabControlFBA()
        {
            this.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
        }
       
        /// <summary>
        /// Атрибут для выбора через ObjectRef.
        /// </summary>
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }
       
		/// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках,
        /// при выполнении команды SaveSettings/LoadSettings.
        /// </summary>        
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
       
		/// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента. 
        /// </summary>         
        [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }
       
        /// <summary>
        /// Скрывать или нет вкладки.
        /// </summary> 
        [DisplayName("HideTabs"), Category("FBA")]
        public bool HideTabs { get; set; }

        int _StarPageIndex = -2;        
        /// <summary>
        /// Вкладка на которой отображается звёздочка в ярлыке.
        /// </summary>
        [DisplayName("StarPageIndex"), Description("StarPageIndex"), Category("FBA")]
        public int StarPageIndex
        {
            get { return _StarPageIndex; }
            set { _StarPageIndex = value; this.Refresh(); }
        }

        bool _StarShow = false;        
        /// <summary>
        /// Показывать или нет звёздочку.
        /// </summary>
        [DisplayName("ShowStar"), Description("Show the star if the attribute is mandatory"), Category("FBA")]
        public bool StarShow
        {
            get { return _StarShow; }
            set { _StarShow = value; this.Refresh(); }
        }

        string _StarText = "*";        
        /// <summary>
        /// Текст звёздочки по умолчанию. Можно изменить.
        /// </summary>
        [DisplayName("StarText"), Description("StarText"), Category("FBA")]
        public string StarText
        {
            get { return _StarText; }
            set { _StarText = value; this.Refresh(); }
        }

        System.Drawing.Font _StarFont = new System.Drawing.Font("Arial", 20);        
        /// <summary>
        /// Шрифт звёздочки.
        /// </summary>
        [DisplayName("StarFont"), Description("StarFont"), Category("FBA")]
        public System.Drawing.Font StarFont
        {
            get { return _StarFont; }
            set { _StarFont = value; this.Refresh(); }
        }

        int _StarOffsetY = -4;        
        /// <summary>
        /// Смещение по Y текста звёздочки.
        /// </summary>
        [DisplayName("StarOffsetY"), Description("StarOffsetY"), Category("FBA")]
        public int StarOffsetY
        {
            get { return _StarOffsetY; }
            set { _StarOffsetY = value; this.Refresh(); }
        }

        int _StarOffsetX = 2;        
        /// <summary>
        /// Смещение по X текста звёздочки.
        /// </summary>
        [DisplayName("StarOffsetX"), Description("StarOffsetX"), Category("FBA")]
        public int StarOffsetX
        {
            get { return _StarOffsetX; }
            set { _StarOffsetX = value; this.Refresh(); }
        }

        Color _StarColor = Color.Crimson;
        /// <summary>
        /// Цвет звёздочки.
        /// </summary>
        [DisplayName("StarColor"), Description("StarColor"), Category("FBA")]
        public Color StarColor
        {
            get { return _StarColor; }
            set { _StarColor = value; this.Refresh(); }
        }

        bool _SetSelectTabBackColor = false;
        /// <summary>
        /// Отмечать цветом фона ярлык выбранной вкладки.
        /// </summary>
        [DisplayName("SetSelectTabBackColor"), Description("SetSelectTabBackColor"), Category("FBA")]
        public bool SetSelectTabBackColor
        {
            get { return _SetSelectTabBackColor; }
            set { _SetSelectTabBackColor = value; this.Refresh(); }
        }

        Color _SelectTabBackColor = Color.Aqua;
        /// <summary>
        /// Цвет фона ярлык выбранной вкладки.
        /// </summary>
        [DisplayName("SelectTabBackColor"), Description("SelectTabBackColor"), Category("FBA")]
        public Color SelectTabBackColor
        {
            get { return _SelectTabBackColor; }
            set { _SelectTabBackColor = value; this.Refresh(); }
        }

        Color _SelectTabFontColor = Color.Black;
        /// <summary>
        /// Цвет шрифта ярлыка выбранной вкладки.
        /// </summary>
        [DisplayName("SelectTabFontColor"), Description("SelectTabFontColor"), Category("FBA")]
        public Color SelectTabFontColor
        {
            get { return _SelectTabFontColor; }
            set { _SelectTabFontColor = value; this.Refresh(); }
        }

        Color _TabFontColor = Color.Black;
        /// <summary>
        /// Цвет ярлыков НЕ выбранных вкладок.
        /// </summary>
        [DisplayName("TabFontColor"), Description("TabFontColor"), Category("FBA")]
        public Color TabFontColor
        {
            get { return _TabFontColor; }
            set { _TabFontColor = value; this.Refresh(); }
        }

        /// <summary>
        /// Привязанный объект ObjectRef.
        /// </summary>
        [DisplayName("Obj"), Description("ObjectRef"), Category("FBA")]
        public ObjectRef Obj { get; set; }     
        
        /// <summary>
        /// Скрыть/показать вкладке TabPage в TabControl.
        /// </summary>       
        /// <param name="tb">TabPage</param>
        /// <param name="tabVisible">true-показать вкладку, false-скрыть</param>
        public void DoTabVisible(TabPage tb, bool tabVisible)
        {             
            //Скрыть вкладку 
            //tabControlValue.TabPages[2].Parent = null;     
            //tabControlValue.TabPages[1].Parent = null;     
            //tabControlValue.TabPages[1].Parent = tabControlValue;
            
            //Appearance ставим во FlatButtons (можно просто Buttons, но тогда немного мусора в Design Mode будет видно).
            //2. ItemSize ставим в (0; 1) (это собственно размер кнопки — сделать высоту 0 мы не можем, но при режиме FlatButtons и так нормально).
            //3. SizeMode ставим в Fixed (без этого нулевая ширина кнопок-закладок не будет сказываться на их внешнем виде).
            //4. TabStop ставим в False (иначе по табуляции пользователь будет уходить в закладки).   
            if (tabVisible == false)
            {
                //tb.Tag = tc.TabPages.IndexOf(tb).ToString();                 
                tb.Parent = null;
            } else TabPages.Insert(0, tb); //tc.TabPages.Insert(Convert.ToInt32(tb.Tag), tb);                         
        }
        //static int TCM_ADJUSTRECT = 0x1328;
        // Hide tabs by trapping the TCM_ADJUSTRECT message
        //if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;

        /*
        Создайте новый UserControl, назовите его, например TabControlWithoutHeader, и измените унаследованный UserControl на TabControl и добавьте некоторый код. Код результата должен выглядеть так:
        public partial class TabControlWithoutHeader: TabControl
        {
            public TabControlWithoutHeader()
            {
                InitializeComponent();
            }
        
            protected override void WndProc(ref Message m)
            {
            if (m.Msg == 0x1328 && !DesignMode)
                m.Result = (IntPtr)1;
            else
                base.WndProc(ref m);
            }
        }*/
    
        /// <summary>
        /// Свойство скрыть вкладки. 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x1328) && (!DesignMode) && (HideTabs)) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }

		/// <summary>
		/// Вывод дополнительного текста.
		/// </summary>
		/// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            string TabText = this.TabPages[e.Index].Text;
            Size sz1 = TabText.Trim().GetTextLength(this.Font);
            Size sz2 = _StarText.GetTextLength(_StarFont);

            //Если нужно выделить цветом активную вкладку.
            if ((this.SelectedIndex == e.Index) && (_SetSelectTabBackColor))
            {
                Graphics g = e.Graphics;
                SolidBrush sb = new SolidBrush(_SelectTabBackColor);
                g.FillRectangle(sb, e.Bounds);
            }

            Color color1 = _TabFontColor;
            if (this.SelectedIndex == e.Index)
            {
                color1 = _SelectTabFontColor;
                //TabFontColor = _SelectTabFontColor; //Color.BlueViolet;
            }

            //Прямоугольник, куда вписываем строку              
            e.Graphics.DrawString(TabText,
            this.Font,
            new SolidBrush(color1),
            new System.Drawing.Rectangle(e.Bounds.X + 2, e.Bounds.Y + 3, e.Bounds.Width + 2, e.Bounds.Height));

            if (e.Index != _StarPageIndex) return;
            if (!_StarShow) return;
            e.Graphics.DrawString(_StarText,
            _StarFont,
            new SolidBrush(_StarColor),
            new System.Drawing.Rectangle(e.Bounds.X + 2 + sz1.Width + _StarOffsetX, e.Bounds.Y + 3 + _StarOffsetY, sz2.Width + 10, e.Bounds.Height));
        }
    }
    
    /// <summary>
    /// Класс потомок System.Windows.Forms.DataGridView.
    /// </summary>
    public class DataGridViewFBA : System.Windows.Forms.DataGridView
    {       
		/// <summary>
	    /// При создании грида, наполняем пунктами меню, связнное с ним контекстное меню. 
	    /// </summary>       
        public DataGridViewFBA() : base()
        {

            //CreateFilterMenu();
            /*System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font      = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font      = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));          
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            */
            //DefaultCellStyle                = dataGridViewCellStyle1;
            //AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;          
            //ColumnHeadersDefaultCellStyle   = dataGridViewCellStyle2;


            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReadOnly = true;
            SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            EnableHeadersVisualStyles = false;
            var dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle21.WrapMode  = System.Windows.Forms.DataGridViewTriState.True;                            
            //!!!dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.GradientActiveCaption; //Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            //DefaultCellStyle    =  dataGridViewCellStyle21;
            //ColumnHeadersDefaultCellStyle =  dataGridViewCellStyle21;
            //ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));       
            //RowHeadersDefaultCellStyle =  dataGridViewCellStyle21;                     
        }

        //Признак что значение компонента можно сохранять/загружать в настройках,
        //при выполнении команды SaveSettings/LoadSettings.                 
        //[DisplayName("SaveParam")]
        //[Description("Save the value of control in Settings")]
        //[Category("FBA")]
        //public bool SaveParam { get; set; }               

        /// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента. 
        /// </summary>
        [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }

        /// <summary>
        /// Показывать команду в контекстном меню грида Add
        /// </summary>
        [DisplayName("CommandAdd"), Description("View command Add"), Category("FBA")]
        public bool CommandAdd { get; set; }

        /// <summary>
        /// Показывать команду в контекстном меню грида Del
        /// </summary>
        [DisplayName("CommandDel"), Description("View command Del"), Category("FBA")]
        public bool CommandDel { get; set; }

        /// <summary>
        /// Показывать команду в контекстном меню грида Edit
        /// </summary>
        [DisplayName("CommandEdit"), Description("View command Edit"), Category("FBA")]
        public bool CommandEdit { get; set; }

        /// <summary>
        /// Показывать команду в контекстном меню грида Filter
        /// </summary>
        [DisplayName("CommandFilter"), Description("View command show Filter"), Category("FBA")]
        public bool CommandFilter { get; set; }

        /// <summary>
        /// Показывать команду в контекстном меню грида Refresh
        /// </summary>
        [DisplayName("CommandRefresh"), Description("View command Refresh grid"), Category("FBA")]
        public bool CommandRefresh { get; set; }

        /// <summary>
        /// Показывать команду в контекстном меню грида "Export to Excel"
        /// </summary>
        [DisplayName("CommandExportToExcel"), Description("View command ExportToExcel"), Category("FBA")]
        public bool CommandExportToExcel { get; set; }
        
        /// <summary>
        /// Показывать команду в контекстном меню грида "Save as CSV"
        /// </summary>
        [DisplayName("CommandSaveASCSV"), Description("View command SaveToCSV"), Category("FBA")]
        public bool CommandSaveASCSV { get; set; }

        /// <summary>
        /// Время, за котрое выполнился запрос, результаты котрого отображаются в гриде.
        /// </summary>
        [DisplayName("PassedSec"), Description("PassedSec"), Category("FBA")]
        public string PassedSec { get; set; }

        /// <summary>
        /// Привязанный объект ObjectRef.
        /// </summary>
        [DisplayName("Obj"), Description("ObjectRef"), Category("FBA")]
        public ObjectRef Obj { get; set; }

        
        /// <summary>
        /// Получение списка колонок DataGridViewFBA через точку с запятой. 
        /// </summary>      
        /// <returns>Список колонок через точку с запятой</returns>
        public string CaptionWithComma()
        {
            string[] columnNames = Columns.Cast<DataGridViewColumn>().Select(col => col.HeaderText).ToArray();
            return string.Join(";", columnNames);
        }
        
        /// <summary>
        /// Опустить в DataGridView строку с индексом RowIndex вниз.
        /// </summary>       
        /// <param name="rowIndex">Строка, которую нужно опустить вниз</param>
        /// <returns>Если успешно, то true</returns>
        public bool RowDown(int rowIndex)
        {
            if (rowIndex == -1) return false;
            if (rowIndex == Rows.Count - 1) return false;
            DataGridViewRow temprow = Rows[rowIndex + 1];
            Rows.Remove(Rows[rowIndex + 1]);
            Rows.Insert(rowIndex, temprow);
            return true;
        }
       
        /// <summary>
        /// Поднять в DataGridView строку с индексом RowIndex вверх.
        /// </summary>        
        /// <param name="rowIndex">Строка, которую нужно поднять вверх</param>
        /// <returns>Если успешно, то true</returns>
        public bool RowUp(int rowIndex)
        {
            if (rowIndex < 1) return false;
            DataGridViewRow temprow = Rows[rowIndex - 1];
            Rows.Remove(Rows[rowIndex - 1]);
            Rows.Insert(rowIndex, temprow);
            return true;
        }
             
        /// <summary>
        /// Метод выделяет найденные строки в DataGridView, возвращает индекс первой найденной строки.
        /// Если selectAllRows = false, то искать только одну первую строку. 
        /// </summary>        
        /// <param name="value">Значение для поиска</param>
        /// <param name="colIndex">В какой колонке ищем</param>
        /// <param name="selectAllRows">Если false, то после первого нахождения выходим</param>
        /// <returns>Индекс первой найденной строки</returns>
        public int SelectFind(string value, int colIndex, bool selectAllRows)
        {
            ClearSelection();
            //DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < RowCount; i++)
            {
                if (Rows[i].Cells[colIndex].Value == null) continue;
                if (Rows[i].Cells[colIndex].Value.ToString() == value)
                {
                    Rows[i].Selected = true;
                    if (!selectAllRows) return i;
                }
            }
            return -1;
        }
                                
        /// <summary>
        /// Заменяем кавычки на двойные для того чтобы сохранить содержимое DataGridView 
        /// SQL запросом в базе данных. Внутри каждой ячейки обрамляющие кавычки.
        /// </summary>       
        public void ReplaceQuote()
        {
            for (int i = 0; i < Rows.Count; i++)
                for (int j = 0; j < Columns.Count; j++)
            		Rows[i].Cells[j].Value = Rows[i].Cells[j].Value.ToString().Replace("'", "''").QueryQuote();
        }        
      
        /// <summary>
        /// Удаление всех строк в DataGridView.
        /// </summary>       
        /// <returns>Ничего не возвращает.</returns>
        public void DeleteAll()
        {            
        	//foreach (DataGridViewRow row in dg.Rows)
        	//	while
            //    dg.Rows.Remove(RemoveAt(row.Index);        			              
            while (Rows.Count > 0)
            {
           		Rows.RemoveAt(0);
            }
        }
         
		/// <summary>
        /// Удаление всех выделенных строк в DataGridView.
        /// </summary>       
        /// <returns>Ничего не возвращает.</returns>
        public void SelectedDeleteAll()
        {
            foreach (DataGridViewRow row in SelectedRows)
                Rows.RemoveAt(row.Index);
        }
              
        /// <summary>
        /// Удаление первой выделенной строки из DataGridView.
        /// </summary>      
        /// <returns>Ничего не возвращает.</returns>
        public void SelectedDeleteFirst()
        {
            if (Rows.Count > 0)
            {
                (DataSource as System.Data.DataTable).Rows[SelectedRows[0].Index].Delete();
                (DataSource as System.Data.DataTable).AcceptChanges();
            }
        }
    
        /// <summary> //RowInt
        /// Получение значения в DataGridView по индексу строки и названию столбца.
        /// </summary>       
		/// <param name="rowIndex">Индекс строки из котрой выбираем</param>   
		/// <param name="columnName">Название колонки, из которой выбираем</param>   
        /// <returns></returns>
        public string ValueByRowIndex(int rowIndex, string columnName)
        {
            return Rows[rowIndex].Cells[columnName].Value.ToString();
        }
     
        /// <summary>
        /// Получение значения в DataGridView по индексу строки и индексу столбца.
        /// </summary>       
        /// <param name="rowIndex">Номер строки</param> 
		/// <param name="columnIndex">Номер колонки</param>			
        /// <returns></returns>
        public string ValueByRowIndex(int rowIndex, int columnIndex)
        {
            //return (DGV.DataSource as System.Data.DataTable).Rows[RowIndex][ColumnIndex].ToString();
            //if (DG.Rows[RowIndex].Cells[ColumnIndex].Value == null) return "";
            return Rows[rowIndex].Cells[columnIndex].Value.ToString();
        }
                     
        /// <summary>
        /// Получение выбранного значения в DataGridView по объекту строки row.
        /// </summary>       
		/// <param name="row">Строка тип DataGridViewRow</param>   
		/// <param name="columnName">Название колонки, из которой выбираем</param>   
        /// <returns>Выбранное значение в dg</returns>
        public string ValueByRow(DataGridViewRow row, string columnName)
        {
            if (DataSource == null) return "";
            if (((System.Data.DataTable)DataSource).Rows.Count == 0) return "";
            return row.Cells[columnName].Value.ToString();
        }
 
         /// <summary>
        /// Получение index первого выбранного значения в FBA.DataGridViewFBA.
        /// </summary>        
        /// <returns>index первого выбранного значения в FBA.DataGridViewFBA</returns>
        public int SelectIndex()
        {                
        	if (Rows == null) return -1;
            if (Rows.Count == 0) return -1;
            if (SelectedRows.Count == 0) return -1;
            if (SelectedRows[0] == null) return -1;
            return SelectedRows[0].Index;
        }
      
        /// <summary>
        /// Получение выбранного значения в DataGridView по имени столбца.
        /// </summary>     
        /// <param name="columnName">Имя колонки из которой взять значение</param>
        /// <returns>Значение из ячейки</returns>
        public string Value(string columnName)
        {            
            if (Rows == null) return "";
            if (Rows.Count == 0) return "";
            if (SelectedRows.Count == 0) return "";
            if (SelectedRows[0] == null) return "";
            return SelectedRows[0].Cells[columnName].Value.ToString();
        }
  
        /// <summary>
        /// Получение выбранного значения в DataGridView по индексу поля.
        /// </summary>     
        /// <param name="columnindex">Имя колонки из которой взять значение</param>
        /// <returns>Значение из ячейки</returns>
        public string Value(int columnindex)
        {            
            if (Rows == null) return "";
            if (Rows.Count == 0) return "";
            if (SelectedRows.Count == 0) return "";
            if (SelectedRows[0] == null) return "";
            return SelectedRows[0].Cells[columnindex].Value.ToString();
        }
          
        /// <summary>
        /// Скроллирование FBA.DataGridViewFBA на строку с номером navigateRow
        /// </summary>        
        /// <param name="navigateRow">Номер строки, на которую переходим</param>
        /// <returns>Нет</returns>
        public void ScrollTo(int navigateRow)
        {
            int halfWay = (DisplayedRowCount(false) / 2);
            if (FirstDisplayedScrollingRowIndex + halfWay > SelectedRows[0].Index ||
                (FirstDisplayedScrollingRowIndex + DisplayedRowCount(false) - halfWay) <= SelectedRows[0].Index)
            {
                int targetRow = SelectedRows[0].Index;
                if (navigateRow > -1) targetRow = navigateRow;

                targetRow = Math.Max(targetRow - halfWay, 0);
                FirstDisplayedScrollingRowIndex = targetRow;
            }          
        }
         
		     /// <summary>
        /// Копирование всех данных в другой DataGridView.
        /// Если CopyRows = false, то копируется только структура(названия колонок).
        /// Если CopyRows = true, то копируются также все строки. 
        /// </summary>      
        /// <param name="dgDest">В какой DataGridView копируем</param>
        /// <param name="copyRows">Если true, то копируется и содержимое, иначе - только структура колонок</param>
        public void CopyToDataGridView(FBA.DataGridViewFBA dgDest, bool copyRows)
        {

            foreach (DataGridViewColumn Col in Columns)
                dgDest.Columns.Add((DataGridViewColumn)Col.Clone());

            if (!copyRows) return;
            foreach (DataGridViewRow Row in Rows)
            {
                dgDest.Rows.Add((DataGridViewRow)Row.Clone());
                for (int i = 0; i < Columns.Count; i++)
                    dgDest.Rows[Row.Index].Cells[i].Value = Row.Cells[i].Value;
            }
        }
             
        /// <summary>
        /// Показать информацию о таблице.
        /// </summary>      
        public void GridInformation()
        {  
            string InfoText = "";                  
            InfoText = "Rows count: " + Rows.Count + Var.CR +
                    "Columns count: " + Columns.Count + Var.CR +
                    "Selected rows: " + SelectedRows.Count + Var.CR +
                    "Selected cols: " + SelectedColumns.Count + Var.CR;
          
            sys.SM(InfoText, MessageType.Information);
        }
         	
		/// <summary>
		/// Открыть в Excel таблицу, открытую в DataGridView.
		/// </summary>
		/// <returns></returns>
        public bool ExportToExcel()
        {
            //Если не установле Office, то не скомпилируется.                                            
#if CompileWithExcel
            try
            {
                var ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 25;

                //Row, Col
                for (int i = 0; i < ColumnCount; i++)
                    ExcelApp.Cells[1, i + 1] = Columns[i].HeaderText;

                int SelRows = SelectedRows.Count;
                int N = 0;
                for (int i = 0; i < RowCount; i++)
                {
                    if ((SelRows > 1) && (!Rows[i].Selected)) continue;
                    for (int j = 0; j < ColumnCount; j++)                   
                    	ExcelApp.Cells[N + 2, j + 1] = Rows[j].Cells[i].Value.ToString();                   
                    N++;
                }
                ExcelApp.Visible = true;
            } catch (Exception ex)
            {
                sys.SM(ex.Message);
                return false;
            }

#endif
            return true;
        }
        
        /// <summary>
        /// Экспортирвать DataTable в шаблон Excel.
        /// </summary>
        /// <param name="TemplatePath">Полный путь к файлу Excel куда выгрузить таблицу</param>
        /// <returns>Если успешно, то true</returns>
        public bool ExportToExcelTemplate(string TemplatePath)
        {
            //Если не установле Office, то не скомпилируется.       
#if CompileWithExcel
            var Excel = new ApplicationClass();
            XlReferenceStyle RefStyle = Excel.ReferenceStyle;
            Excel.Visible = true;
            Workbook wb = null;
            try
            {
                wb = Excel.Workbooks.Add(TemplatePath); // !!! 
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось загрузить шаблон для экспорта " + TemplatePath + "\n" + ex.Message);
            }
            var ws = wb.Worksheets.get_Item(1) as Worksheet;
            for (int j = 0; j < Columns.Count; ++j)
            {
                (ws.Cells[1, j + 1] as Microsoft.Office.Interop.Excel.Range).Value2 = Columns[j].HeaderText;
                for (int i = 0; i < Rows.Count; ++i)
                {
                    object Val = Rows[i].Cells[j].Value;
                    if (Val != null)
                        (ws.Cells[i + 2, j + 1] as Microsoft.Office.Interop.Excel.Range).Value2 = Val.ToString();
                }
            }
            ws.Columns.EntireColumn.AutoFit();
            Excel.ReferenceStyle = RefStyle;
            //ReleaseExcel(Excel as Object);
            Marshal.ReleaseComObject(Excel);
            GC.GetTotalMemory(true);
#endif

            return true;
        }
        
        ///Обновить данные в гриде DataGridView.
        public bool RefreshGrid(DirectionQuery direction, string sql)
        {                       
            string idCur = "";
            if (Columns.Count > 0)
            {
                if ((Columns[0].HeaderText == "ID") && (CurrentRow != null))
                {                      
                    if (CurrentRow.Index > 0) idCur = Rows[CurrentRow.Index].Cells[0].Value.ToString();
                }
              
            }
         
            if (!sys.SelectGV(direction, sql, this)) return false;            
        
            foreach (DataGridViewColumn column in Columns)
            {
                if (column.Width > 400) column.Width = 400;
            }

            if (idCur == "") return true;
            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].Cells[0].Value != null)
                    if (idCur == Rows[i].Cells[0].Value.ToString())
                    {                            
                        Rows[i].Selected = true;                          
                        return true;
                    }
            }
            return true;
            
        }
        
        /*static BackgroundWorker bw = new BackgroundWorker();    
        public static bool RefreshGrid_Thread88(string Direction, FBA.GridFBA DG, FilterObj filter, TextBoxFBA tbStatus)
        {
            {

                //bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += bw_DoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                bw.RunWorkerCompleted += bw_RunWork

                bw.DoWork += bw_DoWork;
                bw.RunWorkerAsync("Message to worker");
                Console.ReadLine();
            }

            return true;
        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Это будет вызвано рабочим потоком
            Console.WriteLine(e.Argument); // напечатает "Message to worker"
            // Выполняем длительную операцию...
        }
        */
       
       
        //DataGridView в строку.
        /*public static string DGVToStr(FBA.DataGridViewFBA DGV, bool CaptionToStr)
        {           
            //Первая строка массива - это шапка.
            int HeaderInt = 0;
            if (CaptionToStr) HeaderInt = 1;
            var ArrAttr = new string[DGV.Rows.Count + HeaderInt, DGV.Columns.Count];

            if (CaptionToStr)
                for (int i = 0; i < DGV.Columns.Count; i++)
                    ArrAttr[0, i] = DGV.Columns[i].HeaderText;

            for (int i = 0; i < DGV.Rows.Count; i++)
                for (int j = 0; j < DGV.Columns.Count; j++)
                    ArrAttr[i + HeaderInt, j] = DGVRowInt(DGV, i, j);                           

            string Result = ArrAttr.ArrayToStr2();
            return Result;
        }*/

        //DataGridView из строки.
        /*public static void DGVFromStr(FBA.DataGridViewFBA DGV, string ArrayDTStr, bool CaptionToStr)
        {                        
            if (ArrayDTStr == "") return;
            string[,] ArrDT = sys.ArrayFromStr2(ArrayDTStr);
            int N = ArrDT.GetLength(0);
            int M = ArrDT.GetLength(1);
            int HeaderInt = 0;            
            if (CaptionToStr) HeaderInt = 1;
            DGV.RowCount    = N - HeaderInt;
            DGV.ColumnCount = M;
            if (CaptionToStr)
                for(int i = 0; i < M; ++i) DGV.Columns[i].HeaderText = ArrDT[0, i];

            for(int i = (0 + HeaderInt); i < N; ++i)
                for(int j = 0; j < M; ++j)
                    DGV.Rows[i - HeaderInt].Cells[j].Value = ArrDT[i, j];           
        }*/
        
        //[DisplayName("ToolStripMenuName")]
        //[Description("ToolStripMenuName")]
        //[Category("FBA")]
        //public System.Windows.Forms.ToolStrip ToolStripMenuName { get; set; }                 
    }
  
    /// <summary>
    /// Класс потомок FastColoredTextBoxNS.FastColoredTextBox.
    /// </summary>
    public class FastColoredTextBoxFBA : FastColoredTextBoxNS.FastColoredTextBox
    {           		
        /// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках,
        /// при выполнении команды SaveSettings/LoadSettings. 
        /// </summary>
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
    
		/// <summary>
        /// Атрибут для выбора через ObjectRef.  
        /// </summary>       
        [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
        public string ObjectRef { get; set; }
        
		/// <summary>
        /// Атрибут для выбора через ObjectRef.
        /// </summary>        
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }
        
		/// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента.   
        /// </summary>        
        [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }
    
		/// <summary>
        /// Атрибут для выбора через ObjectRef.  
        /// </summary>        
        [DisplayName("AttrBriefLookup"), Description("AttrBriefLookup"), Category("FBA")]
        public string AttrBriefLookup { get; set; }
     
		/// <summary>
        /// Требуем заполнение компонента значениями.
        /// </summary>        
        [DisplayName("ErrorIfNull"), Description("ErrorIfNull"), Category("FBA")]
        public string ErrorIfNull { get; set; }
    
        /// <summary>
        /// Дополнительное поле с текстом. Для разных целей.
        /// </summary>
        [DisplayName("Text2"), Description("Text2"), Category("FBA")]
        public string Text2 { get; set; }

        //Маска для ввода в компонент.
        //[DisplayName("Mask"), Description("Mask of entry. Regular expression. Example: [^a-zA-Z]"), Category("FBA")]          
        //public string Mask { get; set; }
    } 
    
    /// <summary>
    /// Вывод DateTimePicker, позволяющий изменять цвет фона.
    /// </summary>
    public class DateTimePickerFBA : System.Windows.Forms.DateTimePicker
    {               
        /// <summary>
        /// Color _backDisabledColor;
        /// </summary>
        public DateTimePickerFBA() : base()
        {

            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.MaxDate = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
            this.Value = this.MinDate;
            //this.SetStyle(ControlStyles.UserPaint, true);
            //_backDisabledColor = Color.FromKnownColor(KnownColor.Control);
        }        

        /// <summary>
        /// Сохранять историю введённых значений в локальной базе данных
        /// </summary>
        [DisplayName("SaveValueHistory"), Description("Save history of values in local DataBase"), Category("FBA")]
        public bool SaveValueHistory { get; set; }
         
		/// <summary>
        /// Признак что значение компонента можно сохранять/загружать в настройках,
        /// при выполнении команды SaveSettings/LoadSettings.
        /// </summary>       
        [DisplayName("SaveParam"), Description("Save the value of control in Settings"), Category("FBA")]
        public bool SaveParam { get; set; }
       
		/// <summary>
        /// Атрибут для выбора через ObjectRef.  
        /// </summary>       
        [DisplayName("ObjectRef"), Description("Example: Main1"), Category("FBA")]
        public string ObjectRef { get; set; }
       
		/// <summary>
        /// Атрибут для выбора через ObjectRef.   
        /// </summary>        
        [DisplayName("AttrBrief"), Description("Attribute of the ObjectRef. Example: Birthday"), Category("FBA")]
        public string AttrBrief { get; set; }
        
		/// <summary>
        /// Имена компонентов со свойством на форме родителе, 
        /// которое влияет на свойство Enabled/Disabled данного компонента.     
        /// </summary>         
        [DisplayName("GroupEnabled"), Description("Enable group. Example, three group: cb_ID;!cb_Number;cb_Type." +
                     "this is: Control.Enabled = cb_ID.Checked && !cb_Number.Checked && cb_Type.Checked"), Category("FBA")]
        public string GroupEnabled { get; set; }
      
        /// <summary>
        /// Атрибут для выбора через ObjectRef.            
        /// </summary>    
        [DisplayName("AttrBriefLookup"), Description(""), Category("FBA")]
        public string AttrBriefLookup { get; set; }
       
 		/// <summary>
        /// Требуем заполнение компонента значениями.  
        /// </summary>         
        [DisplayName("ErrorIfNull"), Description(""), Category("FBA")]
        public string ErrorIfNull { get; set; }


        /*
        ///Gets or sets the background color of the control 
        [Browsable(true)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
     
        ///Gets or sets the background color of the control when disabled           
        [Category("Appearance"), Description("The background color of the component when disabled")]
        [Browsable(true)]
        public Color BackDisabledColor
        {
            get { return _backDisabledColor; }
            set { _backDisabledColor = value; }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //Graphics g = e.Graphics;
            
            //The dropDownRectangle defines position and size of dropdownbutton block, 
            //the width is fixed to 17 and height to 16. The dropdownbutton is aligned to right
            Rectangle dropDownRectangle = new Rectangle(ClientRectangle.Width - 17, 0, 17, 16);
            Brush bkgBrush;
            ComboBoxState visualState;

            //When the control is enabled the brush is set to Backcolor, 
            //otherwise to color stored in _backDisabledColor
            if (this.Enabled) {
                 bkgBrush = new SolidBrush(this.BackColor);
                 visualState = ComboBoxState.Normal;
            }
            else {
                bkgBrush = new SolidBrush(this._backDisabledColor);
                visualState = ComboBoxState.Disabled;
            }

            // Painting...in action

            //Filling the background
            g.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            
            //Drawing the datetime text
            g.DrawString(this.Text, this.Font, Brushes.Black, 0, 2);

            //Drawing the dropdownbutton using ComboBoxRenderer
            ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, visualState);

            g.Dispose();
            bkgBrush.Dispose();
        }*/
    }
   
    /// <summary>
    /// Класс потомок FlowLayoutPanel.
    /// </summary>
    public class CustomFlowLayoutPanel : FlowLayoutPanel
    {
        /// <summary>
        /// FlowLayoutPanel с доп. свойствами.
        /// </summary>
    	public CustomFlowLayoutPanel(): base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
		
    	/// <summary>
    	/// Прокрутка панели мышкой.
    	/// </summary>
    	/// <param name="se"></param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();

            base.OnScroll(se);
        }
        
        /// <summary>
        /// Необходимо для возмодности прокрутки панели мышкой.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_CLIPCHILDREN
                return cp;
            }
        }
    }

    /// <summary>
    /// Наследник System.Windows.Forms.SplitContainer
   	/// </summary>
    public class SplitContainerFBA : System.Windows.Forms.SplitContainer
    {
        /*protected override CreateParams CreateParams       
        {       
            get           
            {       
                CreateParams cp = base.CreateParams;           
                cp.ExStyle |= 0x02000000;           
                return cp;       
            }       
        }*/
    }
       
    /// <summary>
    /// Класс потомок System.Windows.Forms.PictureBox.
    /// </summary>
    public class PictureBoxFBA : System.Windows.Forms.PictureBox
    {		             
        /// <summary>
        /// Загрузить картинку в PictureBox из файла с именем fileName.
        /// </summary>        
        /// <param name="fileName">Имя файла с картинкой</param>
        /// <param name="showMes">Показывать сообщения об ошибках</param>
        /// <returns>Если успешно, то true</returns>
        public bool PictureBoxLoadFile(string fileName, bool showMes = true)
        {
            try
            {
                using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Inheritable))
                {
                    Image = Image.FromStream(file);
                }
            }
            catch (Exception ex)
            {
                if (showMes) sys.SM("Ошибка при загрузки изображения: " + fileName + Var.CR + ex.Message);
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Загрузить картинку с именем ImageName в PictureBox из базы данных.
        /// </summary>       
        /// <param name="imageName">Имя картинки (поле Name) в таблице fbaImage</param>
        /// <param name="showMes">Показывать сообщения об ошибках</param>
        /// <returns>Если успешно, то true</returns>
        public bool PictureBoxLoadDB(string imageName, bool showMes)
        {
            if (imageName == "") return false;
            string fileData;
            string fileName;
            string fileNameFull;
            string format;
            string imageWidth;
            string imageHeight;
            string sql = "SELECT Image FROM fbaImage WHERE Name = " + imageName;
            if (!sys.GetValue(DirectionQuery.Remote, sql,
                               out fileData,
                               out imageName,
                               out fileName,
                               out fileNameFull,
                               out format,
                               out imageWidth,
                               out imageHeight)) return false;
            if (fileData == "")
            {
                if (showMes) sys.SM("Не найдено изображение в таблице изображений!");
                return false;
            }
            string errorMes;
            string fileNameTemp = FBAPath.PathTemp + fileName;
            if (!FBAFile.FileWriteFromBase64(fileData, fileNameTemp, out errorMes, true)) return false;
            if (!File.Exists(fileNameTemp))
            {
                if (showMes) sys.SM("Не найдено изображение на диске. Имя файла: " + fileNameTemp);
                return false;
            }
            try
            {
                if (!PictureBoxLoadFile(fileNameTemp, showMes)) return false;
            }
            catch (Exception ex)
            {
                if (showMes) sys.SM("Ошибка при открытии изображения: " + fileNameTemp + Var.CR + ex.Message);
                return false;
            }
            return true;
        }
    }
        	
   

}
