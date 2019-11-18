/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 15.02.2018
 * Время: 10:33
 */

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;
using SourceGrid.Selection;

namespace FBA
{   
    /// <summary>
    /// Форма поиска
    /// </summary>
	public partial class FormSearch : FormFBA
    {
        FBA.DataGridViewFBA DG;
        FBA.GridFBA SG;   
        string FormName = "";
     
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="formName">Имя формы с котрой вызывается поиск</param>
        /// <param name="GridDG"></param>
        /// <param name="GridSG"></param>
        public FormSearch(string formName, FBA.DataGridViewFBA GridDG, FBA.GridFBA GridSG) 
        {
            InitializeComponent();       
            this.DG = (FBA.DataGridViewFBA)GridDG;            
            this.SG = (FBA.GridFBA)GridSG;           
            this.DG = GridDG;
            this.SG = GridSG;
            this.FormName = formName;                     
        }
    
        /// <summary>
        /// Получить историю поисков и наполнить ей ComboBoxFBA. Статический метод.
        /// </summary>
        /// <param name="cb"></param>
        public static void GetHistorySearch(ComboBoxFBA cb)
        {
            const string SQL = "SELECT SearchText from fbaSearchText ORDER BY ID DESC";          
            cb.SetDataSourceSQL(DirectionQuery.Local, SQL);           
        }    
        
        /// <summary>
        /// Добавить строку в историю поисков. Статический метод.
        /// </summary>
        /// <param name="SearchText"></param>
        public static void SetHistorySearch(string SearchText)
        {
            if (SearchText.IndexOf('"') == -1)
            {
                string SQL = "INSERT INTO fbaSearchText(SearchText) " +
                             "SELECT '" + SearchText + "' WHERE '" + SearchText + "' NOT IN (SELECT SearchText FROM fbaSearchText) ";
                sys.Exec(DirectionQuery.Local, SQL);
            }
        }
   
        /// <summary>
        /// Удаление истории поиска. Статический метод.
        /// </summary>
        /// <param name="cb"></param>
        public static void DeleteSearchHistory(ComboBoxFBA cb)
        {
            if (!sys.SM("Delete search history?", MessageType.Question)) return;
            string SQL = "DELETE FROM fbaSearchText";
            if (sys.Exec(DirectionQuery.Local, SQL))
            {
                if (cb != null)
                {
                    cb.DataSource = null;
                    cb.Items.Clear();
                    cb.Text = "";
                }
                sys.SM("Search history deleted.", MessageType.Information);
            }
            else sys.SM("An error occurred while deleting search history.");
        }
      
        /// <summary>
        /// Метод СТАТИЧЕСКИЙ для вызова данной формы.
        /// </summary>
        /// <param name="formName">Имя формы</param>
        /// <param name="gridDG">Можно искать по гриду FBA.DataGridViewFBA</param>
        /// <param name="gridSG">Можно искать по гриду FBA.GridFBA</param>
        /// <returns></returns>
        public static FormSearch FormSearchShow(string formName, FBA.DataGridViewFBA gridDG, FBA.GridFBA gridSG) 
        {              
            if (Var.FormSearchParam.Contains(formName + ";")) return null;
            Var.FormSearchParam = Var.FormSearchParam + formName + ";";
            var F1 = new FormSearch(formName, gridDG, gridSG);
            
            //История поиска.
            GetHistorySearch(F1.EditFBA1.comboBox);

            int GridLeft = 0; //Чтобы высчитать координаты появления формы поиска на экране относительно грида.
            int GridTop  = 0; //Чтобы высчитать координаты появления формы поиска на экране относительно грида.

            //Установка местоположения появления формы.            
            if (gridDG != null)
            {
                GridLeft = gridDG.Left;
                GridTop = gridDG.Top;
            }
            if (gridSG != null)
            {               
                GridLeft = gridSG.Left;
                GridTop  = gridSG.Top;
            } 

            var p1 = new Point(GridLeft, GridTop);
            Point p2 = F1.PointToScreen(p1);
            F1.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            F1.Left = p2.X + 70;
            F1.Top  = p2.Y - 20;             
            F1.Show();           
            return F1;
        }
            
        /// <summary>
        /// Здесь собраны действия всех кнопок.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {                                
            //Поиск с закрытием формы поиска.
            if (sender == btnOk) 
            {
                GoSearsh(EditFBA1.comboBox.Text, false);             
            }
                      
            //Выход.
            if (sender == btnCancel) Close();                                                 
        }
     
        /// <summary>
        /// Запуск поиска.
        /// </summary>
        /// <param name="searchText">Текст для поиска</param>
        /// <param name="showResult">Показывать таблицу в форме поиска с найденными значениями</param>
        public void GoSearsh(string searchText, bool showResult)
        {           
            DGResult.Rows.Clear();
            DGResult.Columns.Clear();
            int SearchPart = -1;
            int SearchDirection = -1;
            int FindCount = 0;                                           

            if (rbPart1.Checked) SearchPart = 1;
            if (rbPart2.Checked) SearchPart = 2;
            if (rbPart3.Checked) SearchPart = 3;
            if (rbPart4.Checked) SearchPart = 4;

            if (rbAll.Checked)  SearchDirection = 1;
            if (rbDown.Checked) SearchDirection = 2;
            if (rbUp.Checked)   SearchDirection = 3;            

            if (DG != null) 
            {
                int SelectedColumn = 0;
                int SelectedRow = 0;
                if (DG.SelectedCells.Count > 0)
                {

                    SelectedColumn = DG.SelectedCells[0].ColumnIndex;
                    SelectedRow = DG.SelectedCells[0].RowIndex;
                }
                if (!cbOnlyColumns.Checked) SelectedColumn = -1;

                SerchTextDataGridView(DG,
                    DGResult,
                    searchText,
                    showResult,
                    cbCaseSensitivity.Checked,
                    true,
                    cbHighlight.Checked,
                    rbDown.Checked,
                    SelectedColumn,
                    SelectedRow,
                    SearchPart,
                    ref FindCount);
            }

            if (SG != null) 
            {
                int[] SelectedRows = SG.Selection.GetSelectionRegion().GetRowsIndex();
                int[] SelectedColumns = SG.Selection.GetSelectionRegion().GetColumnsIndex();

                SerchTextSourceGrid(SG,
                DGResult,
                searchText,
                0,
                cbCaseSensitivity.Checked,
                cbOnlyColumns.Checked,
                cbOnlyRows.Checked,
                cbOnlyArea.Checked,
                SearchDirection,
                SearchPart,
                SelectedRows,
                SelectedColumns,
                ref FindCount);
            }      
            SetHistorySearch(EditFBA1.comboBox.Text);
            lbResultCount.Text = "Found values: " + FindCount; 
        }
                        
        
        
        
        /// <summary>
        /// Для того чтобы повторно не открывать форму поиска, если она уже полнята.
        /// При закрытии формы поиска убирается информация из перенной FormSearchParam, что форма поиска поднята.
        /// FormSearchParam - текстовая переменная в которой через ; перечислены все поднятые в настоящий момент формы поиска.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Var.FormSearchParam = Var.FormSearchParam.Replace(FormName + ";", "");
        }                       

        private void DGResult_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string NumberStr = DGResult.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (DG != null)
            {
                DG.ScrollTo(NumberStr.ToInt() + 1);
            }
            if (SG != null)
            {
                SourceGrid.Position p = new SourceGrid.Position(NumberStr.ToInt() + 1, 0);
                SG.SelectColumnRowCell(p.Row, p.Column, true);                
            }
            this.Focus();
        }

        ///Удаление истории поиска.
        private void EditFBA1_DeleteClick(object sender, EventArgs e)
        {
            DeleteSearchHistory(EditFBA1.comboBox);
        }       
    
        /// <summary>
        /// Поиск текста по гриду.
        /// </summary>
        /// <param name="DGSearch"></param>
        /// <param name="DGResult"></param>
        /// <param name="SearchText"></param>
        /// <param name="FirstRow"></param>
        /// <param name="CaseSensitivity"></param>
        /// <param name="OnlySelectedColumns"></param>
        /// <param name="OnlySelectedRows"></param>
        /// <param name="OnlySelectedArea"></param>
        /// <param name="SearchDirection"></param>
        /// <param name="SearchPart"></param>
        /// <param name="SelectedRows"></param>
        /// <param name="SelectedColumns"></param>
        /// <param name="FindCount"></param>
        /// <returns></returns>
        public static bool SerchTextSourceGrid(FBA.GridFBA DGSearch,
                                       System.Windows.Forms.DataGridView DGResult,
                                       string SearchText,
                                       int FirstRow,
                                       bool CaseSensitivity,
                                       bool OnlySelectedColumns,
                                       bool OnlySelectedRows,
                                       bool OnlySelectedArea,
                                       int SearchDirection,
                                       int SearchPart,
                                       int[] SelectedRows,
                                       int[] SelectedColumns,
                                       ref int FindCount)

        {
            //SearchPart = 1 - Exact match.
            //SearchPart = 2 - Starts with text.
            //SearchPart = 3 - Ends with text.
            //SearchPart = 4 - Contain text.    

            //SearchDirection = 1 - All.
            //SearchDirection = 2 - Down.
            //SearchDirection = 3 - Up.

            //SearchDirection = 0
            if (SearchText.IsNullOrEmpty()) return false;

            //Чувствительность к регистру. Если true, то регистрозависимый поиск.
            if (!CaseSensitivity) SearchText = SearchText.ToLower();

            //Если поиск Ends with text.
            if (SearchPart == 3) SearchText = SearchText.Reverse();

            if (DGResult != null)
            {
                //Копируем структуру. Только названия полей.
                DGResult.Columns.Add("Num", "Num");
                for (int j = 0; j < DGSearch.Columns.Count; j++)
                {
                    string ColumnName = DGSearch.Columns[j].PropertyName;
                    string ColumnHeader = DGSearch.Columns[j].PropertyName;
                    DGResult.Columns.Add(ColumnName, ColumnHeader);
                }
            }

            string Value = "";
            int CountFind = 0;

            //Ищем по всему гриду или только вниз.
            if ((SearchDirection == 1) || (SearchDirection == 2))
            {
                for (int iRow = FirstRow; iRow < DGSearch.Rows.Count; iRow++)
                {
                    //Если поиск по выделенным строкам
                    if ((OnlySelectedArea) || (OnlySelectedRows))
                    {
                        if (!SelectedRows.Contains(iRow)) continue;
                    }

                    bool FindRow = false;
                    for (int iColumn = 0; iColumn < DGSearch.Columns.Count; iColumn++)
                    {
                        //Если поиск по выделенным колонкам
                        if ((OnlySelectedArea) || (OnlySelectedColumns))
                        {
                            if (!SelectedColumns.Contains(iColumn)) continue;
                        }

                        bool FindCell = false;
                        if (!CaseSensitivity) Value = DGSearch.Value(iRow, iColumn).ToLower();
                        else Value = DGSearch.Value(iRow, iColumn);

                        if ((SearchPart == 1) && (Value == SearchText)) FindCell = true;
                        if ((SearchPart == 2) && (Value.IndexOf(SearchText, StringComparison.CurrentCulture) == 0)) FindCell = true;
                        if ((SearchPart == 3) && (Value.Reverse().IndexOf(SearchText, StringComparison.CurrentCulture) == 0)) FindCell = true;
                        if ((SearchPart == 4) && (Value.IndexOf(SearchText, StringComparison.CurrentCulture) > -1)) FindCell = true;
                        if (!FindCell) continue;
                        CountFind++;
                        if (CountFind == 1) DGSearch.SelectColumnRowCell(iRow, iColumn, true); //В sysData.                         
                        FindRow = true;
                        FindCount++;
                    }

                    //Если нашли строку:
                    if (FindRow)
                    {
                        var rowstr = new string[DGSearch.Columns.Count + 1];
                        rowstr[0] = (iRow - 1).ToString();
                        for (int N = 0; N < DGSearch.Columns.Count; N++) rowstr[N + 1] = DGSearch.Value(iRow, N);
                        if (DGResult != null) DGResult.Rows.Add(rowstr);

                        //Если ищем только до первой найденной строки, то выходим. Direction Search = Down.
                        if (SearchDirection == 2) return true;
                    }
                }
            }

            if (SearchDirection == 3)
                for (int iRow = DGSearch.Rows.Count - 1; iRow >= 0; iRow--)
                {
                    //Если поиск по выделенным строкам
                    if ((OnlySelectedArea) || (OnlySelectedRows))
                    {
                        if (!SelectedRows.Contains(iRow)) continue;
                    }

                    bool FindRow = false;
                    for (int iColumn = 0; iColumn < DGSearch.Columns.Count; iColumn++)
                    {
                        //Если поиск по выделенным колонкам
                        if ((OnlySelectedArea) || (OnlySelectedColumns))
                        {
                            if (!SelectedColumns.Contains(iColumn)) continue;
                        }

                        bool FindCell = false;
                        if (!CaseSensitivity) Value = DGSearch.Value(iRow, iColumn).ToLower();
                        else Value = DGSearch.Value(iRow, iColumn);

                        if ((SearchPart == 1) && (Value == SearchText)) FindCell = true;
                        if ((SearchPart == 2) && (Value.IndexOf(SearchText, StringComparison.CurrentCulture) == 0)) FindCell = true;
                        if ((SearchPart == 3) && (Value.Reverse().IndexOf(SearchText, StringComparison.CurrentCulture) == 0)) FindCell = true;
                        if ((SearchPart == 4) && (Value.IndexOf(SearchText, StringComparison.CurrentCulture) > -1)) FindCell = true;
                        if (!FindCell) continue;
                        CountFind++;
                        if (CountFind == 1) DGSearch.SelectColumnRowCell(iRow, iColumn, true); //В sysData.                         
                        FindRow = true;
                        FindCount++;
                    }

                    //Если нашли строку:
                    if (FindRow)
                    {
                        var rowstr = new string[DGSearch.Columns.Count + 1];
                        rowstr[0] = (iRow - 1).ToString();
                        for (int N = 0; N < DGSearch.Columns.Count; N++) rowstr[N + 1] = DGSearch.Value(iRow, N);
                        DGResult.Rows.Add(rowstr);

                        //Если ищем только до первой найденной строки, то выходим. Direction Search = Up.
                        return true;
                    }
                }
            return (FindCount > 0);
        }
               
        /// <summary>
        /// Поиск текста по гриду.
        /// </summary>
        /// <param name="DGSearch"></param>
        /// <param name="DGResult"></param>
        /// <param name="SearchText"></param>
        /// <param name="ShowResult"></param>
        /// <param name="CaseSensitivity"></param>
        /// <param name="SearchAll"></param>
        /// <param name="Highlight"></param>
        /// <param name="DirectionDown"></param>
        /// <param name="SelectedColumn"></param>
        /// <param name="SelectedRow"></param>
        /// <param name="SearchPart"></param>
        /// <param name="FindCount"></param>
        /// <returns></returns>
        public static bool SerchTextDataGridView(FBA.DataGridViewFBA DGSearch,
                                       FBA.DataGridViewFBA DGResult,
                                       string SearchText,
                                       bool ShowResult,
                                       bool CaseSensitivity,
                                       bool SearchAll,
                                       bool Highlight,
                                       bool DirectionDown,
                                       int SelectedColumn,
                                       int SelectedRow,
                                       int SearchPart,
                                       ref int FindCount)
        {

            //SearchPart = 1 - Exact match.
            //SearchPart = 2 - Starts with text.
            //SearchPart = 3 - Ends with text.
            //SearchPart = 4 - Contain text.          
            if (SearchText.IsNullOrEmpty()) return false;
            
            for (int i = 0; i < DGSearch.RowCount; i++)
                for (int j = 0; j < DGSearch.ColumnCount; j++)
                {
                    DGSearch.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                    if (Highlight) DGSearch.Rows[i].Selected = false;
                }
            DGSearch.Refresh();
            //Чувствительность к регистру. Если true, то регистрозависимый поиск.
            if (!CaseSensitivity) SearchText = SearchText.ToLower();

            //Если поиск Ends with text.
            if (SearchPart == 3) SearchText = SearchText.Reverse();

            //Поиск только по выбранной колонке.
            int ColBeg = 0;
            int ColEnd = DGSearch.Columns.Count - 1;
            if (SelectedColumn > -1)
            {
                ColBeg = SelectedColumn;
                ColEnd = SelectedColumn;
            }

            //Направление поиска.
            int RowBeg = 0;
            int RowEnd = DGSearch.Rows.Count - 1;
            if (SearchAll) DirectionDown = true;
            else
            {
                //Поиск вверх.
                if (DirectionDown) RowBeg = SelectedRow;
                else RowEnd = SelectedRow;
            }

            if (ShowResult)
            {
                //Копируем структуру. Только названия полей.
                DGSearch.CopyToDataGridView(DGResult, false);

                var FirstColumn = new DataGridViewColumn();
                FirstColumn.Name = "OrderNumber";
                FirstColumn.Frozen = false;
                FirstColumn.HeaderText = "№";
                FirstColumn.Width = 20;
                DGResult.Columns.Insert(0, FirstColumn);
            }

            string Value = "";
            if (DirectionDown)
                for (int i = RowBeg; i <= RowEnd; i++)
                {
                    bool FindRow = false;
                    for (int j = ColBeg; j <= ColEnd; j++)
                    {
                        bool FindCell = false;
                        if (!CaseSensitivity) Value = DGSearch.Rows[i].Cells[j].Value.ToString().ToLower();
                        else Value = DGSearch.Rows[i].Cells[j].Value.ToString();
                        if ((SearchPart == 1) && (Value == SearchText)) FindCell = true;
                        if ((SearchPart == 2) && (Value.IndexOf(SearchText, StringComparison.CurrentCulture) == 0)) FindCell = true;
                        if ((SearchPart == 3) && (Value.Reverse().IndexOf(SearchText, StringComparison.CurrentCulture) == 0)) FindCell = true;
                        if ((SearchPart == 4) && (Value.IndexOf(SearchText, StringComparison.CurrentCulture) > -1)) FindCell = true;
                        if (!FindCell) continue;
                        //if (Highlight) DG.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;                     
                        DGSearch.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Yellow;
                        FindRow = true;
                        FindCount++;
                    }

                    //Если ищем только до первой найденной строки, то выходим.                    
                    if (FindRow)
                    {
                        if (Highlight) DGSearch.Rows[i].Selected = true;
                        if (!SearchAll) return true;
                        if (ShowResult)
                        {
                            DGResult.Rows.Add();
                            for (int N = 0; N < DGResult.Columns.Count; N++)
                            {
                                if (N == 0) DGResult.Rows[DGResult.Rows.Count - 1].Cells[N].Value = i.ToString();
                                else DGResult.Rows[DGResult.Rows.Count - 1].Cells[N].Value = DGSearch.Rows[i].Cells[N - 1].Value;
                            }
                        }
                    }
                }

            if (!DirectionDown)
                for (int i = RowEnd; i >= RowBeg; i--)
                {
                    bool FindRow = false;
                    for (int j = ColEnd; j >= ColBeg; j--)
                    {
                        bool FindCell = false;
                        if (!CaseSensitivity) Value = DGSearch.Rows[i].Cells[j].Value.ToString().ToLower();
                        else Value = DGSearch.Rows[i].Cells[j].Value.ToString();
                        if ((SearchPart == 1) && (Value == SearchText)) FindCell = true;
                        if ((SearchPart == 2) && (Value.IndexOf(SearchText, StringComparison.CurrentCulture) == 0)) FindCell = true;
                        if ((SearchPart == 3) && (Value.Reverse().IndexOf(SearchText, StringComparison.CurrentCulture) == 0)) FindCell = true;
                        if ((SearchPart == 4) && (Value.IndexOf(SearchText, StringComparison.CurrentCulture) > -1)) FindCell = true;
                        if (!FindCell) continue;
                        DGSearch.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Yellow;
                        FindRow = true;
                        FindCount++;
                        if (!SearchAll) return true;
                    }

                    //Если ищем только до первой найденной строки, то выходим.
                    if (FindRow)
                    {
                        if (Highlight) DGSearch.Rows[i].Selected = true;
                        if (!SearchAll) return true;
                        if (ShowResult)
                        {
                            DGResult.Rows.Add();
                            for (int N = 0; N < DGResult.Columns.Count; N++)
                            {
                                if (N == 0) DGResult.Rows[DGResult.Rows.Count - 1].Cells[N].Value = i.ToString();
                                else DGResult.Rows[DGResult.Rows.Count - 1].Cells[N].Value = DGSearch.Rows[i].Cells[N - 1].Value;
                            }
                        }
                    }         
                }
            return (FindCount > 0);
        }
    }
}
