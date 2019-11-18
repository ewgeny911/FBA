/*
 * Created by SharpDevelop.
 * User: Evgeniy.Travin
 * Date: 15.08.2019
 * Time: 17:25
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
namespace FBA
{	
	/// <summary>
    /// Статический класс. Здесь собраны все методы для обращения к данным. Для компонентов работы с даными.
    /// </summary>
    public static class Arr
    {                 
        /// <summary>
        /// Сортировка двумерного массива. На выходе отсортированный массив.
        /// </summary>
        /// <param name="arr">Входной массив</param>
        /// <param name="columnsCaption">Названия колонок, по которым нужно устанавливать фильтр и сортировку
        /// Если columnsCaption="", то по умолчанию колонкам выставляются имена: Column1, Column2 и т.д.</param>
        /// <param name="maxColumns">Количество столбцов, которые нужно поместить в выходной отсортированный массив. 0-все столбцы.</param>
        /// <param name="MaxRows">Количество строк, которые нужно поместить в выходной отсортированный массив. 0-все столбцы.  </param>
        /// <param name="filter">Пример фильтра WHERE (как в SQL): Column1 = 100 AND (Column16 = 'FF' OR Column17 не равно Column10) </param>
        /// <param name="sort">Пример сортировки (как в SQL): Column1 ASC, Column16 DESC, Column17 ASC </param>
        /// <returns>Возвращается отсортированный массив</returns>
        public static string[,] SortTwoDimensionalArray(string[,] arr, string columnsCaption, int maxColumns, int MaxRows, string filter, string sort)
        {
        	var dt = new DataTable();
        	ArrayToDataTable(arr, columnsCaption, out dt, maxColumns, MaxRows, false);         	        	        
        	DataRow[] sortedrows = dt.Select(filter, sort);
        	DataTable dt1 = sortedrows.CopyToDataTable();	              	
        	string[,] res;
        	Arr.DataTableToArray(dt1, out res);        	        
        	return res;
        }          
             
        /// <summary>
        /// Получить из двумерного массива список уникальных значений в колонке с номером columnIndex, не меняя сортировки.
        /// columnsNames = "Column1", "Column2" ...
        /// </summary>
        /// <param name="arr">Входной массив</param>
        /// <param name="columnsNames">Названия колонок</param>
        /// <returns>Другой массив, в котром будут только колоки, указанные в columnsNames</returns>
        public static string[,] GetDistinctValues(string[,] arr, string columnsNames)
        {
        	var dt = new DataTable();
        	ArrayToDataTable(arr, "", out dt, 0, 0, false);  			
        	var view = new DataView(dt);
			DataTable distinctValues = view.ToTable(true, columnsNames);
			string[,] res;
        	Arr.DataTableToArray(distinctValues, out res);        	        
        	return res;
			//table.AsEnumerable().GroupBy(row => row.Field<int>("mo")).Select(group => group.First()).CopyToDataTable()
        }             
        
        /// <summary>
        /// Сохранение DataTable в двумерный массив строк.
        /// </summary>
        /// <param name="dt">Исходная DataTable</param>
        /// <param name="ar">Выходной двумерный массив</param>
        /// <returns>Если успешно, то true</returns>
        public static bool DataTableToArray(System.Data.DataTable dt, out string[,] ar)
        {
            ar = new string[dt.Rows.Count, dt.Columns.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ar[i, j] = dt.Rows[i][j].ToString();
                }
            return true;
        }
       
        /// <summary>
        /// Сохранение DataTable в одномерный массив строк.
        /// </summary>
        /// <param name="dt">Исходная DataTable</param>
        /// <param name="ar">Выходной одномерный массив</param>
        /// <returns>Если успешно, то true</returns>
        public static bool DataTableToArray(System.Data.DataTable dt, out string[] ar)
        {
            ar = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            	ar[i] = dt.Rows[i][0].ToString();               
            return true;
        }
          
        /// <summary>
        /// ДВУМЕРНЫЙ массив. Массив преобразовать в DataTable. ColumnCaption - через точку с запятой. 
        /// </summary>
        /// <param name="ar">Исходный массив</param>
        /// <param name="columnsCaption"></param>
        /// <param name="dt">Выходная DataTable</param>
        /// <param name="countColumns">Количество первых колонок, 0 - значит все.</param>
        /// <param name="countRows">Количество первых строк, 0 - значит все.</param>
        /// <param name="showNum">Добавить порядковый номер строки первой колонкой</param>
        /// <returns>Если успешно, то true</returns>
        public static bool ArrayToDataTable(string[,] ar, string columnsCaption, out System.Data.DataTable dt, int countColumns, int countRows, bool showNum)
        {
        	return ArrayToDataTable(ar, columnsCaption, out dt, 0, 0, countColumns, countRows, showNum);       
        }              
        
        /// <summary>
        ///  ДВУМЕРНЫЙ массив. Массив преобразовать в DataTable. ColumnCaption - через точку с запятой.
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="columnsName">Названия колонок через точку с запятой. Если их нет, названия будут Column1, Column2 и т.д.</param>
        /// <param name="dt">Выходная DataTable</param>
        /// <param name="beginColumnIndex">Начиная с какой колонки копировать в DataTable.</param>
        /// <param name="beginRowIndex">Начиная с какой строки копировать в DataTable.</param>
        /// <param name="countColumns">Количество колонок, которые нужно взять из входного массива. 0, значит все.</param>
        /// <param name="countRows">Количество строк, которые нужно взять из входного массива. 0, значит все.         </param>
        /// <param name="showNum">добавить первой колонкой порядковый номер строки.</param>
        /// <returns>Если успешно, то true</returns>
        public static bool ArrayToDataTable(string[,] ar, string columnsName, out System.Data.DataTable dt, int beginColumnIndex, int beginRowIndex, int countColumns, int countRows, bool showNum)
        {
            dt = new System.Data.DataTable();
            if (countRows < 1) countRows = ar.GetLength(0);
            if (countColumns < 1) countColumns = ar.GetLength(1);
            if (columnsName.Length == 0)
            {
                for (int i = beginColumnIndex; i < countColumns; i++) dt.Columns.Add("Column" + (i + 1));
            } else
            {
                string[] Cap = columnsName.Split(';');
                for (int i = beginColumnIndex; i < countColumns; i++)
                {
                    string ColCap = "";
                    if (Cap.Length > i) ColCap = Cap[i]; else ColCap = "Column" + i.ToString();
                    //if (ColCap == "") sys.SM("Error - Column " + i.ToString());
                    dt.Columns.Add(ColCap);
                }
            }
            int N = 0;
            if (showNum) N = 1;
            try
            {
                var word = new string[countColumns + N];
                for (int i = beginRowIndex; i < countRows; i++)
                {
                    if (showNum) word[0] = i.ToString();
                    for (int j = beginColumnIndex; j < countColumns; j++) word[j + N] = ar[i, j];
                    DataRow row = dt.NewRow();
                    row.ItemArray = word;
                    dt.Rows.Add(row);
                }
                return true;
            } catch (Exception ex)
            {
                sys.SM(ex.Message);
                return false;
            }
        }        
        
        /// <summary>
        /// ОДНОМЕРНЫЙ массив. Массив преобразовать в DataTable. 
        /// Max = 0, значит все. ShowNum - показывать порядковый номер строки.
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="columnsCaption">Колонки через точку с запятой. </param>
        /// <param name="dt">Выходная DataTable</param>    
        /// <param name="countRows">Кодичество строк для показа</param>
        /// <param name="showNum"></param>
        /// <returns></returns>
        public static bool ArrayToDataTable(string[] ar, string columnsCaption, out System.Data.DataTable dt, int countRows, bool showNum)
        {
            if (countRows == 0) countRows = ar.Length;
            var ar2 = new string[countRows, 1];
            for (int i = 0; i < countRows; i++) ar2[i, 0] = ar[i];
             return ArrayToDataTable(ar2, columnsCaption, out dt, 0, countRows, showNum);
        }      
        
        /// <summary>
        /// Сохранение DataTable в двумерный массив строк.
        /// </summary>
        /// <param name="dg">FBA.DataGridViewFB</param>
        /// <param name="ar">Выходной массив</param>
        /// <returns>Если успешно, то true</returns>
        public static bool DataGridViewToArray(FBA.DataGridViewFBA dg, out string[,] ar)
        {
            ar = new string[dg.Rows.Count, dg.Columns.Count];
            for (int i = 0; i < dg.Rows.Count; i++)
                for (int j = 0; j < dg.Columns.Count; j++)
                    ar[i, j] = dg.Rows[i].Cells[j].Value.ToString();
            return true;
        }     
    
        /// <summary>
        /// Поиск значения в двумерном массиве, по примеру Dictionary. Массив: arr[rows, cols].
        /// Поиск производится по колонке с индексом indexSearch. Значение возвращается из колонки с индексом indexReturnValue.
        /// </summary>
        /// <param name="arr">Массив, в котором производится поиск.</param>
        /// <param name="searchString">Строка, которую ищем</param>
        /// <param name="indexSearch">Индекс колонки, в котрой ищем.</param>
        /// <param name="indexReturnValue">Индекс колонки, из которой возвращаем значение</param>
        /// <param name="returnValue">Возвращаемое значение</param>
        /// <returns>true, если поиск успешен.</returns>
        public static bool ArrayFindValue(string[,] arr, string searchString, int indexSearch, int indexReturnValue, out string returnValue)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, indexSearch] != searchString) continue;
                returnValue = arr[i, indexReturnValue];
                return true;
            }
            returnValue = null;
            return false;
        }

        /// <summary>
        /// Показ на форме значений массива двумерного Arr. Пример: sys.ViewArray("0. Num;1. Lex; 2. Brace;", MySquareStringArray);
        /// </summary>
        /// <param name="capForm">Заголовок формы, на котрой будет показан массив</param>
        /// <param name="сapArray">Название массива</param>
        /// <param name="arr">Массив, который показываем</param>
        /// <returns>Возврат массива, выбранных строк в массиве.</returns>
        public static string[,] ArrayView(string capForm, string сapArray, string[,] arr)
        {
            if (arr == null) return null;
            System.Data.DataTable dt;
            ArrayToDataTable(arr, сapArray, out dt, 0, 0, false);
            var formList = new FormValueList(dt, false);
            //FList.MdiParent = Var.FormMainObj;
            formList.Text = capForm;
            if (formList.ShowDialog() != DialogResult.OK) return null;
            return formList.SelectedValue;
            //var dtv = new FormViewDT(CapForm, CapForm, DT);
            //dtv.Show();             
            //return true;
        }

        /// <summary>
        /// Показ на форме значений массива одномерного Arr. Пример: sys.ViewArray("History of entered values", "Value", Arr);
        /// </summary>
        /// <param name="capForm">Заголовок формы, на котрой будет показан массив</param>
        /// <param name="capArray">Название массива</param>
        /// <param name="arr">Массив, который показываем</param>
        /// <returns>Возвращает массив выбранных значений после показа на форме массива Arr.</returns>
        public static string[,] ArrayView(string capForm, string capArray, string[] arr)
        {
            if (arr == null) return null;
            System.Data.DataTable dt;
            ArrayToDataTable(arr, capArray, out dt, 0, false);
            var formList = new FormValueList(dt, false);            
            formList.Text = capForm;
            if (formList.ShowDialog() != DialogResult.OK) return null;
            return formList.SelectedValue;           
        }

        /// <summary>
        /// Очистка двумерного массива.
        /// </summary>
        /// <param name="arr">Массив, который очищаем</param>
        public static void ArrayClear(this string[,] arr)
        {
            if (arr == null) return;
            int maxY = arr.GetLength(0);
            int maxX = arr.GetLength(1);
            for (int i = 0; i < maxY; i++)
                for (int j = 0; j < maxX; j++)
                    arr[i, j] = "";
        }

        /// <summary>
        /// Получить номер последней строки (нумерация от нуля), в которой заполен первый столбец двумерного массива.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Номер последней строки, в которой заполен первый столбец двумерного массива</returns>
        public static int GetNextEmptyRow(string[,] arr)
        {
            int arr_Y = arr.GetLength(0);
            for (int i = 0; i < arr_Y; i++)
                if ((arr[i, 0] == "") || (arr[i, 0] == null)) return i;
            return arr_Y;
        }

        /// <summary>
        /// Добавление двумерного массива arrSource2[Y, X] к двумерному массиву arrSource1[Y, X], результат в новом массиве arrResult. Оба массива должны иметь один размер по X.
        /// arrSource1_MaxRows и arrSource2_MaxRows сколько строк брать из каждого массива для объединения. 
        /// arrSource1_MaxRows = -1 значит все. 0 (по умолчанию) значит автоматически определить сколько строк заполенно по первому столбцу.
        /// Тоже самое для arrSource2_MaxRows.     
        /// </summary>
        /// <param name="arrSource1">Первый массив</param>
        /// <param name="arrSource2">Первый массив</param>
        /// <param name="arrResult">Результирующий массив</param>
        /// <param name="arrSource1_MaxRows">Сколько строк брать из каждого массива для объединения из массива arrSource1</param>
        /// <param name="arrSource2_MaxRows">Сколько строк брать из каждого массива для объединения из массива arrSource2</param>
        /// <returns></returns>
        public static bool ArrayConcat(string[,] arrSource1, string[,] arrSource2, out string[,] arrResult, int arrSource1_MaxRows = 0, int arrSource2_MaxRows = 0)
        {
            if ((arrSource1 == null) && (arrSource2 != null))
            {
                arrResult = arrSource2;
                return true;
            }

            if ((arrSource1 != null) && (arrSource2 == null))
            {
                arrResult = arrSource1;
                return true;
            }

            int arr1_X = arrSource1.GetLength(1);
            int arr1_Y = arrSource1_MaxRows;
            if (arr1_Y == -1) arrSource1.GetLength(0);
            if (arr1_Y == 0) arr1_Y = GetNextEmptyRow(arrSource1);

            int arr2_X = arrSource2.GetLength(1);
            int arr2_Y = arrSource2_MaxRows;
            if (arr2_Y == -1) arrSource2.GetLength(0);
            if (arr2_Y == 0) arr2_Y = GetNextEmptyRow(arrSource2);

            arrResult = new string[arr1_Y + arr2_Y, arr1_X];
            if (arr1_X != arr2_X) return false;

            //Добавляем первый массив в результат.
            for (int i = 0; i < arr1_Y; i++)
                for (int j = 0; j < arr1_X; j++)
                    arrResult[i, j] = arrSource1[i, j];

            //Добавляем второй массив в результат.
            int n = arr1_Y;
            for (int i = 0; i < arr2_Y; i++)
            {
                for (int j = 0; j < arr2_X; j++)
                    arrResult[n, j] = arrSource2[i, j];
                n++;
            }
            return true;
        }

        /// <summary>
        /// Добавление двумерного массива arrSource[Y, X] к двумерному массиву arr[Y, X], результат в массиве arr. Оба массива должны иметь один размер по X.
        /// arrSource_MaxRows = -1 значит все. 0 (по умолчанию) значит автоматически определить сколько строк заполенно по первому столбцу. 
        /// Добавление будет происходить с первой незаполннеой строки массива, в который добавяем.
        /// </summary>
        /// <param name="arrSource">Массив, который добавляем</param>
        /// <param name="arr">Массив, в который добавляем</param>
        /// <param name="arrSource_MaxRows"></param>
        /// <returns></returns>
        public static bool ArrayAdd(string[,] arrSource, string[,] arr, int arrSource_MaxRows = 0)
        {
            int arrSource_X = arrSource.GetLength(1);
            int arrSource_Y = arrSource_MaxRows;
            if (arrSource_Y == -1) arrSource.GetLength(0);
            if (arrSource_Y == 0) arrSource_Y = GetNextEmptyRow(arrSource);
            int arr_X = arr.GetLength(1);
            int arr_Y = GetNextEmptyRow(arr);
            if (arrSource_X != arr_X) return false;

            //Добавляем второй массив в результат.
            int n = arr_Y;
            for (int i = 0; i < arrSource_Y; i++)
            {
                for (int j = 0; j < arrSource_X; j++)
                    arr[n, j] = arrSource[i, j];
                n++;
            }
            return true;
        }


        /// <summary>
        /// Сдвиг содержимого двумерного массива, по вертикали, начиная со строки OffsetFirst, 
        /// и количество строк сколько нужно сдвинуть. Можно таким образом удалять строки, если указать OffsetRowCount меньше 0.
        /// Пример вызова: sys.ArrayRowOffset(Words, 3, -2, ref WordCount, out ErrorMes);     
        /// </summary>
        /// <param name="arr">Массив, в котором сдвигаем строки</param>
        /// <param name="offsetFirstRow">Индекс первой строки, с которой происходит сдвиг.</param>
        /// <param name="offsetRowCount">На сколько строк нужно сдвинуть</param>
        /// <param name="arrRowCount">Количество сдвигаемых строк</param>
        /// <param name="errorMes">Сообщение об ошибке</param>
        /// <returns>Если сдвиг произошёл успешно, то true</returns>
        public static bool ArrayRowOffset(string[,] arr, int offsetFirstRow, int offsetRowCount, ref int arrRowCount, out string errorMes)
        {
            errorMes = "";
            int rowCount = arr.GetLength(0);
            int colCount = arr.GetLength(1);
            if ((offsetFirstRow + offsetRowCount) >= rowCount)
            {
                errorMes = "Не хватает размерности массива строк.";
                return false;
            }

            //Если сдвиг вниз. 
            if (offsetRowCount > 0)
            {
                //Перемещение данных
                for (int i = (arrRowCount - 1); i >= offsetFirstRow; i--)
                    for (int j = 0; j < colCount; j++) arr[i + offsetRowCount, j] = arr[i, j];


                //Очистка массива
                for (int i = offsetFirstRow; i < (offsetFirstRow + offsetRowCount); i++)
                    for (int j = 0; j < colCount; j++) arr[i, j] = "";

                arrRowCount = arrRowCount + offsetRowCount;
            }

            //Если сдвиг вверх (т.е. удаление строк). 
            if (offsetRowCount < 0)
            {
                offsetRowCount = offsetRowCount * -1;

                //Перемещение данных
                for (int i = (offsetFirstRow + offsetRowCount); i < arrRowCount; i++)
                    for (int j = 0; j < colCount; j++) arr[i - offsetRowCount, j] = arr[i, j];

                //Очистка массива
                for (int i = arrRowCount - offsetRowCount; i > arrRowCount; i++)
                    for (int j = 0; j < colCount; j++) arr[i, j] = "";

                arrRowCount = arrRowCount - offsetRowCount;
            }
            return true;
        }
        
        /// <summary>
        /// Найти все совпадающие строки в массиве arr и добавить к ним строку "_1", "_2" и т.д.
        /// Для того чтобы получились уникальные значения.
        /// </summary>
        /// <param name="arr">Массив, в котором меняем значения</param>
        /// <returns>Количество изменений элементов массива</returns>
        public static int SetUniqValue(string[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int num = 1;
                string value = arr[i];
                string aluesearch = value;
                int countFound = CountValueInArray(arr, aluesearch);
                while (countFound > 1)
                {
                    aluesearch = value + "_" + num.ToString();
                    num++;
                    result++;
                    countFound = CountValueInArray(arr, aluesearch) + 1;
                }
                arr[i] = aluesearch;                
            }
            return result;
        }

        /// <summary>
        /// Поиск количества одинаковых значений в одномерном строковом массиве, без учета регистра.
        /// </summary>
        /// <param name="arr">Массив, в котором ищем</param>
        /// <param name="value">Значение, которое ищем</param>
        /// <param name="startIndex">Начиная с какого индекса ищем.</param>
        /// <returns>Количество найденных значений</returns>
        public static int CountValueInArray(string[] arr, string value, int startIndex = 0)
        {
            string valueLower = value.ToLower();
            int countValue = 0;
            for (int i = startIndex; i < arr.Length; i++)
            {
                if (arr[i].ToLower() == valueLower) countValue++;
            } 
            return countValue;
        } 
    }
}
