/*
* Создано в SharpDevelop.
* Пользователь: Travin
* Дата: 24.10.2017
* Время: 12:02
*/

using System;     
using System.Drawing;
using System.Windows.Forms; 
using System.Linq;   
using System.IO;
using System.Data;      
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using SourceGrid.Selection;
using System.Threading.Tasks;
using SourceGrid;
using ContentAlignment = DevAge.Drawing.ContentAlignment;
using DataTable = System.Data.DataTable;
using TextBox = System.Windows.Forms.TextBox;


namespace FBA
{       
	/// <summary>
	/// Класс для сериализации/десериализации DataTable. 
	/// </summary>
	/// <remarks>
	/// Этот класс нужен для того, чтобы сохранить строку DataTable в файл.
    /// Используется в функциях ExportDataTabletoFile и ImportDataTableFromFile. 
    /// Лучше сериализовать свой класс, а не чистый Datatable так как в класс можно
    /// добавить свои поля, например TableName. 	
	/// </remarks>
    [Serializable]
    public class NewDT
    {            
        /// <summary>
        /// Сама таблица в виде строки.
        /// </summary>           
        public string DataTableStr;
        
        /// <summary>
        /// Имя таблицы
        /// </summary>
        public string TableName;                    
    }

    /// <summary>
    /// Здесь собраны все методы для обращения к данным. Для компонентов работы с даными.
    /// </summary>
    public static partial class sys
    {    
        #region Region. Запросы к БД.                      
        
        /// <summary>
        /// Запрос SELECT к БД. Результат в текстовом одномерном массиве.
        /// </summary>
        /// <param name="direction">Direction = Local, Remote</param>
        /// <param name="sql">Запрос SQL. В селекте может быть только одна колонка для выбора</param>
        /// <returns>Возвращается одномерный массив - одна колонка</returns>
        public static string[] SQLToArray(DirectionQuery direction, string sql)
        {
        	System.Data.DataTable dt;
        	if (!SelectDT(direction, sql, out dt)) return null;
        	string[] ar;        	
        	Arr.DataTableToArray(dt, out ar);
        	return ar;        	
        }                      
                    
        /// <summary>
        /// Запрос EXEC к БД. Если нет авторизации, то запрашивается.
        /// Direction = Local, Remote
        /// </summary>
        /// <param name="direction">Direction = Local, Remote</param>
        /// <param name="sql">Запрос SQL</param>
        /// <returns>Если успешно, то true</returns>
        public static bool Exec(DirectionQuery direction, string sql)
        {
            string id;
            return Exec(direction, false, sql, out id);
        }
          
        /// <summary>
        /// Запрос EXEC к БД. Если нет авторизации, то запрашивается. 
        /// На выходе ID вставленной (обновленной) записи, если она одна.
        /// Direction = Local, Remote
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="addInsertID">если true, то добавляется код для возврата значений.    
        /// Postgre: RETURNING id; ";
        /// MSSQL:   SELECT @@IDENTITY AS id; ";                                          
        /// SQLite:  SELECT last_insert_rowid() AS id; "; </param>
        /// <param name="sql">Код который нужно выполнить на сервере</param>
        /// <param name="id">ИД записи после Insert</param>
        /// <returns>Если успешно, то true</returns>
        public static bool Exec(DirectionQuery direction, bool addInsertID, string sql, out string id)
        {
            id = "";
            if (direction == DirectionQuery.Local)
            {
                if (Var.conLite == null) sys.ConnectLocal();
                if (!Var.conLite.Exec(sql, addInsertID, out id)) return false;
            }
            if (direction == DirectionQuery.Remote)
            {
                if (Var.con == null) sys.ConnectRemote();
                if (!Var.con.Exec(sql, addInsertID, out id)) return false;
            }
            return true;
        }       
        
        /// <summary>
        /// Получение одного значения.
        /// </summary>      
        public static string GetValue(DirectionQuery direction, string sql)
        {
            string s1;
            string s2;
            string s3;
            string s4;
            string s5;
            string s6;
            string s7;
            string s8;
            string s9;
            string s10;
            bool Result = GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                                    out s6, out s7, out s8, out s9, out s10);
            if (Result) return s1;
            return "";
        }
        
        /// <summary>
        /// Получение 2-х значений.
        /// </summary>      
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2)
        {
            string s3;
            string s4;
            string s5;
            string s6;
            string s7;
            string s8;
            string s9;
            string s10;
            return GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                              out s6, out s7, out s8, out s9, out s10);
        }

        /// <summary>
        /// Получение 3-х значений.
        /// </summary>       
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2, out string s3)
        {
            string s4;
            string s5;
            string s6;
            string s7;
            string s8;
            string s9;
            string s10;
            return GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                              out s6, out s7, out s8, out s9, out s10);
        }
          
        /// <summary>
        /// Получение 4-х значений.
        /// </summary>       
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2, out string s3, out string s4)
        {
            string s5;
            string s6;
            string s7;
            string s8;
            string s9;
            string s10;
            return GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                              out s6, out s7, out s8, out s9, out s10);
        }   
        
        /// <summary>
        /// Получение 5-х значений.
        /// </summary> 
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2, out string s3, out string s4, out string s5)
        {
            string s6;
            string s7;
            string s8;
            string s9;
            string s10;
            return GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                out s6, out s7, out s8, out s9, out s10);
        }
             
        /// <summary>
        /// Получение 6-х значений.
        /// </summary>
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6)
        {
            string s7;
            string s8;
            string s9;
            string s10;
            return GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                out s6, out s7, out s8, out s9, out s10);
        }       
        
        /// <summary>
        /// /Получение 7-х значений.
        /// </summary>      
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7)
        {
            string s8;
            string s9;
            string s10;
            return GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                              out s6, out s7, out s8, out s9, out s10);
        }
      
        /// <summary>
        /// Получение 8-х значений. 
        /// </summary>      
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7, out string s8)
        {
            string s9;
            string s10;
            return GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                              out s6, out s7, out s8, out s9, out s10);
        }
       
        /// <summary>
        /// Получение 9-х значений. 
        /// </summary>
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7, out string s8, out string s9)
        {
            string s10;
            return GetValue(direction, sql, out s1, out s2, out s3, out s4, out s5,
                              out s6, out s7, out s8, out s9, out s10);
        }
       
        /// <summary>
        /// Получение 10-ти значений. 
        /// </summary>
        public static bool GetValue(DirectionQuery direction, string sql, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7, out string s8, out string s9, out string s10)
        {
            s1 = "";
            s2 = "";
            s3 = "";
            s4 = "";
            s5 = "";
            s6 = "";
            s7 = "";
            s8 = "";
            s9 = "";
            s10 = "";
            if (direction == DirectionQuery.Local)
            {
                if (Var.conLite == null) sys.ConnectLocal();
                if (!Var.conLite.GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10)) return false; 
                return true;
            }
            if (direction == DirectionQuery.Remote)
            {
                if (Var.con == null) sys.ConnectRemote();
                if (!Var.con.GetValue10(sql, out s1, out s2, out s3, out s4, out s5, out s6, out s7, out s8, out s9, out s10)) return false; 
                return true;
            }
            return false;
        }
       
        /// <summary>
        /// Получение больше 10-ти значений. В массиве строк arr.
        /// </summary>
        /// <param name="direction">Локальная или удалённая БД</param>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="arr">Масив, в который будут присвоены все полученные после запроса значения всех колонок</param>
        /// <returns>Если успешно, то true</returns>
        public static bool GetValueArr(DirectionQuery direction, string sql, ref string[] arr)
        {
            if (direction == DirectionQuery.Local)
            {
                if (Var.conLite == null) sys.ConnectLocal();
                if (!Var.conLite.GetValueArr(sql, ref arr)) return false; 
                return true;
            } else
            if (direction == DirectionQuery.Remote)
            {
                if (Var.con == null) sys.ConnectRemote();
                if (!Var.con.GetValueArr(sql, ref arr)) return false; 
                return true;
            } else 
            return false;
        }        
		
		/// <summary>
		/// Функции получения данных для MSSQL, Postgre, SQLite. Результат в DataGridView. 
		/// </summary>
		/// <param name="direction">Локальная или удалённая БД</param>
		/// <param name="sql">Запрос Select</param>
		/// <param name="grid">DataGridView</param>
		/// <returns>Если успешно, то true</returns>
        public static bool SelectGV(DirectionQuery direction, string sql, DataGridView grid)
        {
            System.Data.DataTable DT;
            bool flag = SelectDT(direction, sql, out DT);
            if (!flag) return false;
            grid.DataSource = DT;
            return true;
        }

        ///Функции получения данных для MSSQL, Postgre, SQLite. Результат в DataGridView.  
        public static bool SelectGV2(DirectionQuery direction, string SQL, DataGridViewFBA Grid)
        {
            DateTime dt1 = DateTime.Now;
            System.Data.DataTable DT;
            bool flag = SelectDT(direction, SQL, out DT);
            if (!flag) return false;
            Grid.DataSource = DT;
            DateTime dt2 = DateTime.Now;
            Grid.PassedSec = sys.GetTimeDiff(dt1, dt2);
            return true;
        }

        ///Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataTable. Возвращает только одну таблицу.             
        public static bool SelectDT(DirectionQuery direction, string SQL, out System.Data.DataTable DT)
        {       
        	DT = null;
            System.Data.DataSet DS;
            if (!SelectDS(direction, SQL, out DS)) return false;
            if ((DS == null) || (DS.Tables.Count == 0)) return false;         
            DT = DS.Tables[0];
            return true;
        }

        ///Запрос к БД. Если нет авторизации, то запрашивается. На выходе массив таблиц.
        public static bool SelectDS(DirectionQuery direction, string SQL, out System.Data.DataSet DS)
        {
            DS = null;
            if (direction == DirectionQuery.Local)
            {
                if (Var.conLite == null) sys.ConnectLocal();
                if (!Var.conLite.SelectDS(SQL, out DS)) return false;
                return true;
            }
            if (direction == DirectionQuery.Remote)
            {
                if (Var.con == null) sys.ConnectRemote();
                if (!Var.con.SelectDS(SQL, out DS)) return false;
                return true;
            }
            return false;
        }

        ///Запрос к БД. Если нет авторизации, то запрашивается. На выходе массив таблиц.
        public static bool SelectDS(DirectionQuery direction, string SQL, out System.Data.DataSet DS, out string ErrorText, bool ErrorShow)
        {
            DS = null;
            ErrorText = "";
            if (direction == DirectionQuery.Local)
            {
                if (Var.conLite == null) sys.ConnectLocal();
                if (!Var.conLite.SelectDS(SQL, out DS, out ErrorText, ErrorShow)) return false;
                return true;
            }
            if (direction == DirectionQuery.Remote)
            {
                if (Var.con == null) sys.ConnectRemote();
                if (!Var.con.SelectDS(SQL, out DS, out ErrorText, ErrorShow)) return false;
                return true;
            }
            return false;
        }
   
        /// <summary>
        /// Проверка синтаксиса запроса.
        /// </summary>
        /// <param name="direction">Локальная или удалённая БД</param>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="errorText">Текст ошибки, если есть</param>
        /// <param name="errorShow">Если true, то показываетс оконо сообщения об ошибке</param>
        /// <returns>Если запрос корректный, то true</returns>
        public static bool CheckSyntaxQuery(DirectionQuery direction, string sql, out string errorText, bool errorShow)
        {
            //string SQLLocal =  "SET NOEXEC ON " + SQL + "SET NOEXEC OFF " + Var.CR;         
            string sqlLocal = "SET PARSEONLY ON " + sql + Var.CR;
            System.Data.DataSet ds;
            if (!sys.SelectDS(direction, sqlLocal, out ds, out errorText, errorShow)) return false;
            string errorText2;
            if (!sys.SelectDS(direction, "SET PARSEONLY OFF", out ds, out errorText2, false)) return false;
            if (errorShow) SM("Запрос корректный", MessageType.Information);
            return true;
        }

        /// <summary>
        /// Функции получения данных для MSSQL, Postgre, SQLite. Результат в ComboBox. 
        /// </summary>
        /// <param name="direction">Локальная или удалённая БД</param>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="cb">ComboBox</param>
        /// <returns>Если успешно, то true</returns>
        public static bool SelectComboBox(DirectionQuery direction, string sql, ComboBox cb)
        {
            if (cb.DataSource != null) return true;
            System.Data.DataTable dt;
            if (!SelectDT(direction, sql, out dt)) return false;
            cb.DataSource = dt;
            //sys.DTView(DT, "DT", "DT");
            if (dt.Columns.Count == 1)
            {
                cb.DisplayMember = dt.Columns[0].Caption;
                cb.ValueMember = dt.Columns[0].Caption;
            }
            else
            {
                cb.DisplayMember = dt.Columns[1].Caption;
                cb.ValueMember = dt.Columns[0].Caption;
            }
            return true;
        }
      
        /// <summary>
        /// Запрос к БД. Получение кол-ва записей, которое возвращает запрос.
        /// </summary>
        /// <param name="direction">Локальная или удалённая БД</param>
        /// <param name="sql">Запрос SQL</param>
        /// <returns>Если успешно, то true</returns>
        public static int SelectCount(DirectionQuery direction, string sql)
        {
            if (direction == DirectionQuery.Local) return Var.conLite.SelectCount(sql);
            if (direction == DirectionQuery.Remote) return Var.con.SelectCount(sql);
            return -1;
        }

        #endregion Region. Запросы к БД.
    	
        #region Region. Сохранение/чтение DataSet, DataTable, Array[,] в/из строку. (Сериализация)

        /// <summary>
        /// Сериализовать DataSet в строку.
        /// Преимущества этой сериализации:
        /// Компактный размер при больших таблицах, так как повторяющиеся данные не сохраняются.
        /// В заголовке указан размер, поэтому можно сразу узнать сколько строк и столбцов.
        /// Описание формата:
        /// Вначале идет код операции - всегда 3 символа. Это означает что операций может быть не более 4096, если в 16-ти ричной системе.             
        /// Далее идут блоки. Блок может состоять из трёх частей или из четырёх.
        /// Первая часть - код блока.
        /// Второая часть всегда две цифры - длина числа, описывающего длину третьей части.
        ///
        /// Если блок стоит из из 3-х, то значит это какие то данные не более 99 символов в длину.
        /// Пример для параметра кол-ва таблиц или числа колонок или числа записей в таблице.
        /// Например 99 символов длина числа, описывающего кол-во записей в таблице - вполне достаточно.
        ///
        /// Если блок состоит из 4-х частей, то 2-я часть - это длина числа, описывающего длину 4-ой части, 
        /// 3-я часть это длина 4-части, и 4-часть - сами данные.
        /// Фактичести это означает, что длина 4-ой части может описываться числом, имеющим не более 99 знаков.
        /// Например 1 террабайт - это 13 цифр, а 99 - это уже число галактических масштабов.
        ///
        /// Одна ячейка таблицы описывается без использования блоков. см. ниже:
        ///
        /// 103   - Значение "Код операции" = 103. 103 Означает передачу DataSet.
        ///
        /// Описание DataSet.       
        /// 002   - Тип Данных "Длина DataSet".
        /// 11    - Кол-во символов, которое занимает атрибут "Длина DataSet"
        /// 12345678901 - Значение "Длина DataSe".   
        ///
        /// 003   - Тип Данных "Кол-во таблиц".
        /// 01    - Кол-во символов, которое занимает атрибут "Кол-во таблиц"
        /// 3     - Значение "Кол-во таблиц".                     
        ///
        /// 004   - Тип Данных "Кол-во байт, которое занимают все таблицы".
        /// 05    - Кол-во байт, которое занимает атрибут "Кол-во байт, которое занимают все таблицы".                             
        /// 12345 - "Кол-во байт, которое занимают все таблицы".
        /// Описание Таблицы.
        ///
        /// 005   - Тип Данных "Кол-во байт, которое занимает таблица".
        /// 05    - Кол-во байт, которое занимает атрибут "Кол-во байт, которое занимает таблица"                             
        /// 12345 - Кол-во байт, которое занимает таблица (вместе с шапкой).
        ///
        /// 006   - Тип Данных "Кол-ва записей в таблице".
        /// 03    - Кол-во символов, которое занимает атрибут "Кол-во записей в таблице"                      
        /// 768   - Значение "Кол-во записей в таблице".
        ///
        /// 007   - Тип Данных "Кол-ва полей в таблице".
        /// 02    - Кол-во байт, которое занимает атрибут "Кол-во полей в таблице"                      
        /// 10    - Значение "Кол-во полей в таблице".                      
        ///
        /// 008   - Тип Данных "Описание полей таблицы".                                  
        /// 04    - Кол-во байт, которое занимает атрибут "Описание полей таблицы".
        /// 1175  - Значение Кол-во байт"Описание полей таблицы".                                   
        ///
        /// Описание полей таблицы (Название поля, Имя поля, Тип поля).
        ///
        /// 009   - Тип Данных "Длина названия поля".
        /// 01    - Кол-во байт, которое занимает атрибут "Длина названия поля"                      
        /// 9     - Значение "Длина названия поля".                      
        /// ИДОбъекта - Значение "Название поля". 
        ///
        /// 010   - Тип Данных "Длина имени поля".
        /// 01    - Кол-во байт, которое занимает атрибут "Длина имени поля"                      
        /// 2     - Значение "Длина имени поля".                      
        /// ID    - Значение "Имя поля".       
        ///
        /// 011   - Тип Данных "Тип поля".
        /// 01    - Кол-во байт, которое занимает атрибут "Тип поля"                      
        /// 3     - Значение "Длина типа поля".                      
        /// INT   - Значение "Тип поля". 
        ///
        /// Описание записей таблицы.
        /// 012   - Тип Данных "Таблицы без шапки".                                  
        /// 04    - Кол-во байт, которое занимает атрибут "Таблицы без шапки".
        /// 1175  - Значение "Таблицы без шапки".
        ///
        /// Описание одной ячейки таблицы. У неё для экономии места нет типа данных.
        /// 01    - Кол-во байт, которое занимает атрибут "Длина значения ячейки таблицы".                    
        /// 4     - Значение "Длина значения ячейки таблицы".                  
        /// AAAAA - Значение "Ячейки таблицы". 
        /// Для экономии места:
        /// Если 00, значит NULL или пустая строка, переходим к след. ячейке.  
        /// Если 99, значит вставляем значение предыдущей записи этого же поля. 
        /// (чтобы не повторять одни и теже данные, 
        /// если они повторяются в данном поле в записях идущих подряд).
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataSetToStr(System.Data.DataSet ds)
        {                      
            int CountTables = ds.Tables.Count;
            if (CountTables == 0) return "";
            const string sep = "";
            const string sep2 = "";      
            const string Block1 = "103" + sep;  //"Код операции" = 103
            string Block2 = ""; //"Длина DataSet". Описание ниже.           
            string Block3 = "003" + sep + CountTables.ToString().Length.ToString("D2") + sep + CountTables.ToString() + sep;
            string Block4 = ""; //Все Таблицы. Шапка + Данные. Описание ниже.

            //Все таблицы в массиве TableArr. Одна страка массива - одна таблица.
            var TableArr = new string[CountTables];
            for (int t = 0; t <= CountTables - 1; t++)
            {
                string Block5 = "";
                DataTableToStr(ds.Tables[t], ref Block5);
                TableArr[t] = Block5;
            }

            if (TableArr.Count() > 1)
            {
                string TableAll = string.Join(sep2, TableArr);
                Block4 = "004" + sep + TableAll.Length.ToString().Length.ToString("D2") + sep + TableAll.Length + sep + TableAll + sep;
                Block2 = "002" + sep + (Block3.Length + Block4.Length).ToString().Length.ToString("D2") + sep +
                (Block3.Length + Block4.Length).ToString() + sep;
                return (Block1 + sep + Block2 + sep + Block3 + sep + Block4);
            }
            //Здесь мы избавляемся от JOIN, если таблица всего одна, что возможно даст некоторый выигрыш в скорости, если таблица большая.
            Block4 = "004" + sep + TableArr[0].Length.ToString().Length.ToString("D2") + sep + TableArr[0].Length + sep + TableArr[0] + sep;

            Block2 = "002" + sep + (Block3.Length + Block4.Length).ToString().Length.ToString("D2") + sep +
                (Block3.Length + Block4.Length).ToString() + sep;
            return (Block1 + sep + Block2 + sep + Block3 + sep + Block4);
        }      
        
        /// <summary>
        /// Получить DataSet из строки.
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns>на выходе System.Data.DataSet полученный из строки inputStr</returns>
        public static System.Data.DataSet StrToDataSet(string inputStr)
        {
            /*
            103;;
            002;03;358;;          //Весь DataSet
            003;01;2;;            //Кол-во таблиц.          
            004;03;337;           //Все Таблицы в DataSet. Шапки + Данные
            
            005;03;116;           //Одна таблица (Шапка + Данные)
            006;01;1;             //Кол-во строк
            007;01;2;             //Кол-во столбцов.
            008;02;86;            //Вся шапка таблицы.
            
            009;01;2;ID;          //Шапка. Наим
            010;01;2;ID;          //Шапка. Поле
            011;01;5;Int64;;      //Шапка. Тип
            
            009;01;5;Brief;
            010;01;5;Brief;
            011;01;6;String;;;
            
            012;02;19;            //Таблица без шапки.
            01;2;11;;01;4;Сокр;;; //Данные таблицы.
            
            -=Другая таблица=-
            005;03;119;
            006;01;1;
            007;01;2;
            008;02;86;
            009;01;2;ID;
            010;01;2;ID;
            011;01;5;Int64;;
            009;01;5;Brief;
            010;01;5;Brief;
            011;01;6;String;;;
            012;02;22;
            01;1;1;;01;8;Сущность;;;;
            */

            string BlockCode;
            // int BlockLen;          
            BlockCode = inputStr.Substring(0, 3);
            if (BlockCode != "103") return null;

            int Offset = 3;
            int DateSetLen = 0;
            int TablesCount = 0;
            int TablesLen = 0;
            int BlockLen;
            GetBlockLen(ref Offset, ref inputStr, out BlockCode, out BlockLen);
            if (BlockCode != "002") return null;
            DateSetLen = BlockLen;

            GetBlockLen(ref Offset, ref inputStr, out BlockCode, out BlockLen);
            if (BlockCode != "003") return null;
            TablesCount = BlockLen;

            GetBlockLen(ref Offset, ref inputStr, out BlockCode, out BlockLen);
            if (BlockCode != "004") return null;
            TablesLen = BlockLen; //

            var DS = new System.Data.DataSet();
            for (int t = 0; t <= TablesCount - 1; t++)
            {
                System.Data.DataTable DT = StrToDataTable(ref Offset, ref inputStr);
                if (DT != null) DS.Tables.Add(DT);
            }

            return DS;

        }
             
        /// <summary>
        /// Сериализовать DataTable в строку.
        /// </summary>
        /// <param name="dt">DataTable для преобразования в строку</param>
        /// <param name="block5">Таблица в виде строки</param>
        public static void DataTableToStr(System.Data.DataTable dt, ref string block5)
        {
            const string sep = "";
            //Block5 - Одна таблица. Шапка + Данные. Описание ниже.

            //Количество строк.
            int CountRows = dt.Rows.Count;
            string Block6 = "006" + sep + CountRows.ToString().Length.ToString("D2") + sep + CountRows.ToString() + sep;

            //Количество полей.
            int CountCols = dt.Columns.Count;
            string Block7 = "007" + sep + CountCols.ToString().Length.ToString("D2") + sep + CountCols.ToString() + sep;

            //Шапка таблицы.
            string CapTable = "";
            var FieldArr = new string[CountCols];
            for (int c = 0; c <= CountCols - 1; c++)
            {
                string CapName = dt.Columns[c].Caption;
                string ColName = dt.Columns[c].ColumnName;
                string ColType = dt.Columns[c].DataType.ToString().Replace("System.", "");

                string Block9 = "009" + sep +
                      CapName.Length.ToString().Length.ToString("D2") + sep + CapName.Length + sep + CapName + sep;

                string Block10 = "010" + sep +
                      ColName.Length.ToString().Length.ToString("D2") + sep + ColName.Length + sep + ColName + sep;

                string Block11 = "011" + sep +
                      ColType.Length.ToString().Length.ToString("D2") + sep + ColType.Length + sep + ColType + sep;

                FieldArr[c] = Block9 + Block10 + Block11;
            }
            CapTable = string.Join(sep, FieldArr);
            string Block8 = "008" + sep + CapTable.Length.ToString().Length.ToString("D2") + sep + CapTable.Length + sep + CapTable + sep;

            //Данные таблицы.
            //Описание записей таблицы.
            //01    - Кол-во байт, которое занимает атрибут "Длина значения ячейки таблицы".                    
            //4     - Значение "Длина значения ячейки таблицы".                  
            //AAAA  - Значение "Ячейки таблицы". 
            //014AAAA
            //Если 00, значит NULL, переходим к след. ячейке.
            //Если 99, значит вставляем значение предыдущей записи этого же поля.   
            //System.Data.DataTable DT = DS.Tables[t];

            var DataArr = new string[CountRows];
            var LineArr = new string[CountCols];

            //Type tp = typeof(System.DBNull);
            for (int r = 0; r < CountRows; r++)
            {
                for (int c = 0; c < CountCols; c++)
                {
                    int ValueLen = dt.Rows[r][c].ToString().Length;

                    if (ValueLen == 0)
                        if (dt.Rows[r][c].GetType().ToString() == "System.DBNull")
                        //if (DT.Rows[r][c] == tp)
                        {
                            LineArr[c] = "98" + sep;
                            continue;
                        }

                    if (ValueLen == 0)
                    {
                        LineArr[c] = "00" + sep;
                        continue;
                    }
                    if (r > 0)
                        if (dt.Rows[r][c] == dt.Rows[r - 1][c])
                        {
                            LineArr[c] = "99" + sep;
                            continue;
                        }
                    LineArr[c] = ValueLen.ToString().Length.ToString("D2") + sep + ValueLen + sep + dt.Rows[r][c] + sep;
                }
                DataArr[r] = string.Join(sep, LineArr);
            }

            //Таблица без шапки.
            string TableStr = string.Join(sep, DataArr);

            //Таблица без шапки.
            string Block12 = "012" + sep + TableStr.Length.ToString().Length.ToString("D2") + sep + TableStr.Length + sep + TableStr + sep;
            int TableLen = TableStr.Length;
            int CapLen = Block8.Length;

            //Block5 = DTStr - Одна таблица (Шапка + Данные).               
            block5 = "005" + sep + (CapLen + TableLen).ToString().Length.ToString("D2") + sep + (CapLen + TableLen).ToString() + sep + Block6 + Block7 + Block8 + sep + Block12 + sep;
        }

        ///Получить DataTable из строки.
        public static System.Data.DataTable StrToDataTable(ref int Offset, ref string InputStr)
        {
            //005;03;116;           //Одна таблица (Шапка + Данные)
            //006;01;1;             //Кол-во строк
            //007;01;2;             //Кол-во столбцов.
            //008;02;86;            //Вся шапка таблицы.

            //009;01;2;ID;          //Шапка. Наим
            //010;01;2;ID;          //Шапка. Поле
            //011;01;5;Int64;;      //Шапка. Тип

            //009;01;5;Brief;
            //010;01;5;Brief;
            //011;01;6;String;;;

            //012;02;19;            //Таблица без шапки.
            //01;2;11;;01;4;Сокр;;; //Данные таблицы. 

            //string BlockCode;
            //int BlockLen;
            var DT = new System.Data.DataTable();
            string BlockCode;
            int BlockLen;
            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "005") return null;

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "006") return null;
            int CountRows = BlockLen;

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "007") return null;
            int CountCols = BlockLen;

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "008") return null;
            int CapLen = BlockLen;
            string Cap = GetBlockDataView(ref Offset, BlockLen, ref InputStr);

            //Наполнение таблицы шапкой - колонками.
            DataTableCaption(ref DT, ref Offset, ref InputStr, CountCols);

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "012") return null;
            int TableLen = BlockLen; //Длина таблицы.

            //Наполнение таблицы данными.
            DataTableFill(ref DT, ref Offset, ref InputStr, CountCols, CountRows);
            return DT;
        }
       
        ///Сериализовать DataGridView в строку.
        public static void DataGridViewToStr(FBA.DataGridViewFBA DG, ref string Block5)
        {
            const string sep = "";
            //Block5 - Одна таблица. Шапка + Данные. Описание ниже.
            if (DG == null) return;

            DG.AllowUserToAddRows = false;

            //Количество строк.
            int CountRows = DG.Rows.Count;
            string Block6 = "006" + sep + CountRows.ToString().Length.ToString("D2") + sep + CountRows.ToString() + sep;

            //Количество полей.
            int CountCols = DG.Columns.Count;
            string Block7 = "007" + sep + CountCols.ToString().Length.ToString("D2") + sep + CountCols.ToString() + sep;

            //Шапка таблицы.
            string CapTable = "";
            var FieldArr = new string[CountCols];
            for (int c = 0; c <= CountCols - 1; c++)
            {
                string CapName = DG.Columns[c].HeaderText;
                string ColName = DG.Columns[c].Name;
                const string ColType = ""; //DGV.Columns[c].CellType.ToString().Replace("System.", "");

                string Block9 = "009" + sep +
                      CapName.Length.ToString().Length.ToString("D2") + sep + CapName.Length + sep + CapName + sep;

                string Block10 = "010" + sep +
                      ColName.Length.ToString().Length.ToString("D2") + sep + ColName.Length + sep + ColName + sep;

                string Block11 = "011" + sep +
                      ColType.Length.ToString().Length.ToString("D2") + sep + ColType.Length + sep + ColType + sep;

                FieldArr[c] = Block9 + Block10 + Block11;
            }
            CapTable = string.Join(sep, FieldArr);
            string Block8 = "008" + sep + CapTable.Length.ToString().Length.ToString("D2") + sep + CapTable.Length + sep + CapTable + sep;

            //Данные таблицы.
            //Описание записей таблицы.
            //01    - Кол-во байт, которое занимает атрибут "Длина значения ячейки таблицы".                    
            //4     - Значение "Длина значения ячейки таблицы".                  
            //AAAAA - Значение "Ячейки таблицы". 
            //014brief
            //Если 00, значит NULL, переходим к след. ячейке.
            //Если 99, значит вставляем значение предыдущей записи этого же поля.   
            //System.Data.DataTable DT = DS.Tables[t];

            var DataArr = new string[CountRows];
            var LineArr = new string[CountCols];
            for (int r = 0; r < CountRows; r++)
            {
                for (int c = 0; c < CountCols; c++)
                {
                    int ValueLen = DG.ValueByRowIndex(r, c).Length; //DGV.Rows[r][c].ToString().Length;

                    if (ValueLen == 0)
                        //if (DG.DGRowInt(r,c).GetType().ToString() == "System.DBNull")
                        //if (DG.Rows[RowIndex].Cells[ColumnIndex].GetType().ToString() == "System.DBNull")                       
                        //{
                        //    LineArr[c] = "98" + sep;
                        //    continue;
                        //}     

                        if (ValueLen == 0)
                        {
                            LineArr[c] = "00" + sep;
                            continue;
                        }
                    if (r > 0)
                        if (DG.ValueByRowIndex(r, c) == DG.ValueByRowIndex(r - 1, c))  //Так не катит:  DG[r,c] == DG[r-1,c]
                        {
                            LineArr[c] = "99" + sep;
                            continue;
                        }
                    LineArr[c] = ValueLen.ToString().Length.ToString("D2") + sep + ValueLen + sep + DG.ValueByRowIndex(r, c) + sep;
                }
                DataArr[r] = string.Join(sep, LineArr);
            }

            //Таблица без шапки.
            string TableStr = string.Join(sep, DataArr);

            //Таблица без шапки.
            string Block12 = "012" + sep + TableStr.Length.ToString().Length.ToString("D2") + sep + TableStr.Length + sep + TableStr + sep;
            int TableLen = TableStr.Length;
            int CapLen = Block8.Length;

            //Block5 = DTStr - Одна таблица (Шапка + Данные).               
            Block5 = "005" + sep + (CapLen + TableLen).ToString().Length.ToString("D2") + sep + (CapLen + TableLen).ToString() + sep + Block6 + Block7 + Block8 + sep + Block12 + sep;

        }

        ///Получить DataGridView из строки.
        public static void StrToDataGridView(ref FBA.DataGridViewFBA DG, ref int Offset, ref string InputStr)
        {
            //005;03;116;           //Одна таблица (Шапка + Данные)
            //006;01;1;             //Кол-во строк
            //007;01;2;             //Кол-во столбцов.
            //008;02;86;            //Вся шапка таблицы.

            //009;01;2;ID;          //Шапка. Наим
            //010;01;2;ID;          //Шапка. Поле
            //011;01;5;Int64;;      //Шапка. Тип

            //009;01;5;Brief;
            //010;01;5;Brief;
            //011;01;6;String;;;

            //012;02;19;            //Таблица без шапки.
            //01;2;11;;01;4;Сокр;;; //Данные таблицы. 
            if (string.IsNullOrEmpty(InputStr)) return;
                      
            DG.DataSource = null;
            DG.Rows.Clear();
            DG.Columns.Clear();
            //string BlockCode;
            //int BlockLen;
            //var DGV = new FBA.DataGridViewFBA();
            string BlockCode;
            int BlockLen;
            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "005") return; //null;

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "006") return; //null;
            int CountRows = BlockLen;

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "007") return; //null;
            int CountCols = BlockLen;

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "008") return; //null;
            int CapLen = BlockLen;
            string Cap = GetBlockDataView(ref Offset, BlockLen, ref InputStr);

            //Наполнение таблицы шапкой - колонками.
            DataGridViewCap(ref DG, ref Offset, ref InputStr, CountCols);

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "012") return; //null;
            int TableLen = BlockLen; //Длина таблицы.

            //Наполнение таблицы данными.
            DataGridViewFill(ref DG, ref Offset, ref InputStr, CountCols, CountRows);
            //return DGV;
        }
                
        ///Сериализовать Array[,] в строку.
        public static void ArrayToStr(string[,] Arr, ref string Block5, int CountRows = 0)
        {
            const string sep = "";
            //Block5 - Одна таблица. Шапка + Данные. Описание ниже.

            if (Arr == null) return;

            //Количество строк.
            if (CountRows == 0)
                CountRows = Arr.GetLength(0); //Arr.Rows.Count;

            string Block6 = "006" + sep + CountRows.ToString().Length.ToString("D2") + sep + CountRows.ToString() + sep;

            //Количество полей.
            int CountCols = Arr.GetLength(1); //Arr.Columns.Count;
            string Block7 = "007" + sep + CountCols.ToString().Length.ToString("D2") + sep + CountCols.ToString() + sep;

            //Данные таблицы.
            //Описание записей таблицы.
            //01    - Кол-во байт, которое занимает атрибут "Длина значения ячейки таблицы".                    
            //4     - Значение "Длина значения ячейки таблицы".                  
            //AAAAA - Значение "Ячейки таблицы". 
            //014brief
            //Если 00, значит NULL, переходим к след. ячейке.
            //Если 99, значит вставляем значение предыдущей записи этого же поля.   
            //System.Data.DataTable DT = DS.Tables[t];

            //Заполняем пустыми значениями массив, иначе при оюращении к ячейке ошибка.
            for (int r = 0; r < CountRows; r++)
                for (int c = 0; c < CountCols; c++)
                    if (Arr[r, c] == null) Arr[r, c] = "";          //sys.ArrayView("","", Arr)

            var DataArr = new string[CountRows];
            var LineArr = new string[CountCols];
            for (int r = 0; r < CountRows; r++)
            {
                for (int c = 0; c < CountCols; c++)
                {
                    int ValueLen = Arr[r, c].Length; //DGV.Rows[r][c].ToString().Length;
                    if (ValueLen == 0)
                    {
                        LineArr[c] = "00" + sep;
                        continue;
                    }
                    if (r > 0)
                        if (Arr[r, c] == Arr[r - 1, c])
                        {
                            LineArr[c] = "99" + sep;
                            continue;
                        }
                    LineArr[c] = ValueLen.ToString().Length.ToString("D2") + sep + ValueLen + sep + Arr[r, c] + sep;
                }
                DataArr[r] = string.Join(sep, LineArr);
            }

            //Таблица без шапки.
            string TableStr = string.Join(sep, DataArr);

            //Таблица без шапки.
            string Block12 = "012" + sep + TableStr.Length.ToString().Length.ToString("D2") + sep + TableStr.Length + sep + TableStr + sep;
            int TableLen = TableStr.Length;

            //Block5 = DTStr - Одна таблица (Шапка + Данные).               
            Block5 = "005" + sep + TableLen.ToString().Length.ToString("D2") + sep + TableLen + sep + Block6 + Block7 + sep + Block12 + sep;
        }

        ///Получить Array[,] из строки.
        public static void StrToArray(ref string[,] Arr, ref int Offset, ref string InputStr)
        {
            //005;03;116;           //Одна таблица (Шапка + Данные)
            //006;01;1;             //Кол-во строк
            //007;01;2;             //Кол-во столбцов.
            //008;02;86;            //Вся шапка таблицы.

            //009;01;2;ID;          //Шапка. Наим
            //010;01;2;ID;          //Шапка. Поле
            //011;01;5;Int64;;      //Шапка. Тип

            //009;01;5;Brief;
            //010;01;5;Brief;
            //011;01;6;String;;;

            //012;02;19;            //Таблица без шапки.
            //01;2;11;;01;4;Сокр;;; //Данные таблицы. 
            if (InputStr == "") return;

            //string BlockCode;
            //int BlockLen;            
            string BlockCode;
            int BlockLen;
            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "005") return; //null;

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "006") return; //null;
            int CountRows = BlockLen;

            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "007") return; //null;
            int CountCols = BlockLen;


            GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
            if (BlockCode != "012") return; //null;
            int TableLen = BlockLen; //Длина таблицы.

            Arr = new string[CountRows, CountCols];
            //Наполнение таблицы данными.
            ArrayFill(ref Arr, ref Offset, ref InputStr, CountCols, CountRows);
        }

               
        ///Метод создает шапку таблицы из строки. Метод для GetDataTable.
        private static void DataTableCaption(ref System.Data.DataTable DT, ref int Offset, ref string InputStr, int CountCols)
        {
            /*
            009;01;2;ID;          //Шапка. Наим
            010;01;2;ID;          //Шапка. Поле
            011;01;5;Int64;;      //Шапка. Тип
            
            009;01;5;Brief;
            010;01;5;Brief;
            011;01;6;String;;;
            */
            //string BlockCode;
            //int BlockLen;
            for (int t = 0; t <= CountCols - 1; t++)
            {
                string BlockCode;
                int BlockLen;
                GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
                if (BlockCode != "009") return;
                string CapName = GetBlockData(ref Offset, BlockLen, ref InputStr);

                GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
                if (BlockCode != "010") return;
                string CapField = GetBlockData(ref Offset, BlockLen, ref InputStr);

                GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
                if (BlockCode != "011") return;
                string CapType = "System." + GetBlockData(ref Offset, BlockLen, ref InputStr);
                Type tp = Type.GetType(CapType);

                //Type tp = typeof(string);  
                DT.Columns.Add(CapField, tp);
                DT.Columns[DT.Columns.Count - 1].Caption = CapName;
            }
        }

        //Метод наполняет DataTable данными. Метод для GetDataTable.
        private static void DataTableFill(ref System.Data.DataTable DT, ref int Offset, ref string InputStr, int CountCols, int CountRows)
        {
            //01;2;11;
            //;01;4;Сокр;;; //Данные таблицы.
            string[] LineArr = new string[CountCols];
            for (int r = 0; r < CountRows; r++)
            {
                for (int c = 0; c < CountCols; c++)
                {
                    string d1 = InputStr.Substring(Offset, 2);
                    Offset = Offset + 2;
                    if (d1 == "98")
                    {
                        LineArr[c] = null;
                        continue;
                    }

                    if (d1 == "00")
                    {
                        LineArr[c] = "";
                        continue;
                    }
                    if (d1 == "99") continue;
                    int Len1 = d1.ToInt();
                    int Len2 = InputStr.Substring(Offset, Len1).ToInt();
                    Offset = Offset + Len1;
                    LineArr[c] = InputStr.Substring(Offset, Len2);
                    Offset = Offset + Len2;
                }
                DT.Rows.Add(LineArr);
            }
        }

        ///Получить длину параметра.
        private static void GetBlockLen(ref int Offset,
                                        ref string InputStr,
                                        out string BlockCode,
                                        out int BlockLen)
        {
            //008;02;86;
            BlockCode = InputStr.Substring(Offset, 3);
            Offset = Offset + 3;
            int Len = InputStr.Substring(Offset, 2).ToInt();
            Offset = Offset + 2;
            BlockLen = InputStr.Substring(Offset, Len).ToInt();
            Offset = Offset + Len;
        }

        ///Получить значение параметра.
        private static string GetBlockData(ref int Offset, int BlockLen, ref string InputStr)
        {
            int LocalOffset = Offset;
            Offset = Offset + BlockLen;
            return InputStr.Substring(LocalOffset, BlockLen);
        }

        ///Получить значение параметра для просмотра. Для тестирования.
        private static string GetBlockDataView(ref int Offset, int BlockLen, ref string InputStr)
        {
            return InputStr.Substring(Offset, BlockLen);
        }
       
        ///Метод создает шапку таблицы из строки. Метод для GetDataGridView.
        private static void DataGridViewCap(ref FBA.DataGridViewFBA DG, ref int Offset, ref string InputStr, int CountCols)
        {
            /*
            009;01;2;ID;          //Шапка. Наим
            010;01;2;ID;          //Шапка. Поле
            011;01;5;Int64;;      //Шапка. Тип
            
            009;01;5;Brief;
            010;01;5;Brief;
            011;01;6;String;;;
            */
            //string BlockCode;
            //int BlockLen;
            for (int t = 0; t < CountCols; t++)
            {
                string BlockCode;
                int BlockLen;
                GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
                if (BlockCode != "009") return;
                string CapName = GetBlockData(ref Offset, BlockLen, ref InputStr);

                GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
                if (BlockCode != "010") return;
                string CapField = GetBlockData(ref Offset, BlockLen, ref InputStr);

                GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
                if (BlockCode != "011") return;
                string CapType = "System." + GetBlockData(ref Offset, BlockLen, ref InputStr);
                //Type tp = Type.GetType(CapType);               
                DG.Columns.Add(CapField, CapName);
            }
        }

        //Метод наполняет DataGridView данными. Метод для GetDataGridView.
        private static void DataGridViewFill(ref FBA.DataGridViewFBA DG, ref int Offset, ref string InputStr, int CountCols, int CountRows)
        {
            //01;2;11;
            //;01;4;Сокр;;; //Данные таблицы.
            string[] LineArr = new string[CountCols];
            for (int r = 0; r < CountRows; r++)
            {
                for (int c = 0; c < CountCols; c++)
                {
                    string d1 = InputStr.Substring(Offset, 2);
                    Offset = Offset + 2;
                    //if (d1 == "98") 
                    //{
                    //    LineArr[c] = null;
                    //    continue;
                    //}
                    if (d1 == "00")
                    {
                        LineArr[c] = "";
                        continue;
                    }
                    if (d1 == "99") continue;
                    int Len1 = d1.ToInt();
                    int Len2 = InputStr.Substring(Offset, Len1).ToInt();
                    Offset = Offset + Len1;
                    LineArr[c] = InputStr.Substring(Offset, Len2);
                    Offset = Offset + Len2;
                }
                DG.Rows.Add(LineArr);
            }
        }

        //Метод наполняет Array[,] данными.
        private static void ArrayFill(ref string[,] Arr, ref int Offset, ref string InputStr, int CountCols, int CountRows)
        {
            //01;2;11;                            //00502530060120070150120253014True015RRRRR015BEGIN012110099015HHHHH013END0122200
            //;01;4;Сокр;;; //Данные таблицы.
            //string[] LineArr = new string[CountCols];
            for (int r = 0; r < CountRows; r++)
            {
                for (int c = 0; c < CountCols; c++)
                {
                    string d1 = InputStr.Substring(Offset, 2);
                    Offset = Offset + 2;
                    if (d1 == "00")
                    {
                        Arr[r, c] = "";//LineArr[c] = "";
                        continue;
                    }
                    if (d1 == "99")
                    {
                        Arr[r, c] = Arr[r - 1, c];
                        continue;
                    }
                    int Len1 = d1.ToInt();
                    int Len2 = InputStr.Substring(Offset, Len1).ToInt();
                    Offset = Offset + Len1;
                    //LineArr[c] = InputStr.Substring(Offset, Len2);
                    Arr[r, c] = InputStr.Substring(Offset, Len2);
                    Offset = Offset + Len2;
                }
            }
        }

        #endregion Region. Сохранение/чтение DataSet, DataTable, DataGridView в/из строку. (Сериализация)

        #region Region. Сохранение/чтение DataTable в/из CSV.

        ///Сохранение DataTable в CSV.
        public static bool DataTableToCSV(System.Data.DataTable DT, string FileName, bool OpenAferCreate)
        {
            string InitialDirectory = "";
            if (FileName == "")
                if (!FBAFile.OpenFileName("Выбор имени файла для сохранения", "", InitialDirectory, ref FileName)) return false;

            /*string s;
            string s2;
            var lines = new List<string>();
            int ColCount = DT.Columns.Count;
            //string[] columnNames = DT.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            //string[] columnNames =  sys.DGCaptionWithComma
            string columnNames = "";
            for (int i = 0; i < ColCount; i++)
            {
                if (i < (ColCount - 1)) columnNames = columnNames + DT.Columns[i].ColumnName + ";";
                else columnNames = columnNames + DT.Columns[i].ColumnName;
            }
            //lines.Add(string.Join(";", columnNames));
            lines.Add(columnNames);
            foreach (DataRow dr in DT.Rows)
            {
                s2 = "";
                for (int i = 0; i < ColCount; i++)
                {
                    s = dr[i].ToString().Replace(";", "$$$").Replace(Var.CR, " ");
                    s2 += s;
                    if (i < ColCount - 1) s2 += ";";
                }
                lines.Add(s2);
            }*/

            var lines = new List<string>();
            lines = DT.GetDataTableAsText(";", true);

            File.WriteAllLines(FileName, lines, System.Text.Encoding.Default);
            if (OpenAferCreate)
            {
                System.Diagnostics.Process run;
                FBAFile.FileRun(out run, FileName, "");
            }
            return true;
        }

        ///Загрузка DataTable из CSV.
        public static bool CSVToDataTable(out System.Data.DataTable DT, string FileName, out string ErrorMes, bool ErrorShow)
        {
            //Здесь переносы строк заменяются на пробел
            DT = null;
            ErrorMes = "";
            try
            {
                var f = new FileInfo(FileName);
                FileStream fs = f.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var sr = new StreamReader(fs, Encoding.UTF8);
                string[] rows = sr.ReadToEnd().Split('\n');
                string[] headers = rows[0].Split(';');
                string[] fields = null;
                DT = new System.Data.DataTable();
                var HeaderAndType = new string[2];
                foreach (string header in headers)
                {
                    HeaderAndType = header.Split(':');
                    DT.Columns.Add(HeaderAndType[0]); //Тип поля, который указан здесь пока не используем: HeaderAndType[1]
                }

                for (int i = 1; i < rows.Length; i++)
                {
                    fields = rows[i].Split(';');
                    for (int i1 = 0; i1 < fields.Length; i1++)
                    {
                        fields[i1] = fields[i1].Replace("$$$", ";");
                    }
                    DataRow row = DT.NewRow();
                    row.ItemArray = fields;
                    DT.Rows.Add(row);
                }
                return true;
            } catch (Exception ex)
            {
                ErrorMes = "Ошибка при конвертировании CSV в DataTable: " + Var.CR + ex.Message;
                if (ErrorShow) sys.SM(ErrorMes);
                return false;
            }
        }

        ///Загрузка DataTable из CSV. Второй вариант.
        public static bool CSVToDataTable2(System.Data.DataTable DT, string FileName, out string ErrorMes, bool ErrorShow)
        {
            DT = null;
            ErrorMes = "";
            if (sys.IsEmpty(FileName)) return false;
            DateTime DateTime1 = DateTime.Now;                    
            DT.Rows.Clear();
            DT.Columns.Clear();            
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            int ColumnsCount = 0;
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1251));
            string line;
            int LineNumber = 0;
            string[] ArrLine;
                                
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                ArrLine = line.Split(';'); //массив строк
                if (ColumnsCount == 0) ColumnsCount = ArrLine.Length;
                else if (ColumnsCount != ArrLine.Length)
                {
                    ErrorMes = "Ошибка. Не совпадает количество точек с запятой в строке " + LineNumber.ToString();                    
                    return false;
                }

                if (LineNumber == 0)
                {
                    for (int i = 0; i < ArrLine.Length; i++)
                        DT.Columns.Add(ArrLine[i], typeof(string));

                    LineNumber++;
                    continue;
                }
                DT.Rows.Add(ArrLine);
                LineNumber++;                  
            }
            sr.Close();
            fs.Close();
            return true;
        }

        ///Сохранение DataGridView в CSV.
        public static bool DataGridViewToCSV(this DataGridView dg, string fileName)
        {
            const string InitialDirectory = "";
            if (fileName == "")
                if (!FBAFile.SaveFileName("Выбор имени файла для сохранения", "CSV Files|*.csv|Excel Files|*.xls;*.xlsx;|All Files|*.*", InitialDirectory, 0, ref fileName)) return false;
            fileName = fileName + ".csv";
            int ColCount = dg.ColumnCount;
            int RowCount = dg.RowCount;
            string[] output;
            int SelRows = dg.SelectedRows.Count;
            int N = 1;
            if (SelRows > 1) output = new string[SelRows + 1];
            else output = new string[dg.RowCount + 1];
            var headers = dg.Columns.Cast<DataGridViewColumn>();
            output[0] += string.Join(";", headers.Select(e => e.HeaderText).ToArray());
            string sep = "";
            for (int i = 0; i < RowCount; i++)
            {
                if ((SelRows > 1) && (!dg.Rows[i].Selected)) continue;
                for (int j = 0; j < ColCount; j++)
                {
                    if (j < (ColCount - 1)) sep = ";"; else sep = "";
                    output[N] += dg.Rows[i].Cells[j].Value.ToString().Replace(Var.CR, " ").Replace(";", ",") + sep;
                }
                N++;
            }
            System.IO.File.WriteAllLines(fileName, output, System.Text.Encoding.UTF8);
            sys.SM("Таблица сохранена в файл CSV: " + fileName, MessageType.Information);
            return true;
        }      

        #endregion Region. Сохранение/чтение в/из CSV.                        

        #region Region. Сохранение DataTable, SourceGrid в Excel.      
       
        /// <summary>
        /// Открыть в Excel таблицу, открытую в DataTable.
        /// </summary>
        /// <param name="dt">DataTable</param>       
        /// <returns>Если успешно, то true</returns>            
        public static bool DataTableToExcel(this System.Data.DataTable dt)
        {
            //return true;
            //Процедура рабочая! Если не установлен Office, то компилироваться не будет.
            try
            {
                var ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 25;

                //Row, Col
                for (int i = 0; i < dt.Columns.Count; i++)
                    ExcelApp.Cells[1, i + 1] = dt.Columns[i].Caption;

                for (int i = 0; i < dt.Columns.Count; i++)
                    for (int j = 0; j < dt.Rows.Count; j++)
                        ExcelApp.Cells[j + 2, i + 1] = dt.Rows[j][i].ToString();

                ExcelApp.Visible = true;
                return true;
            } catch (Exception ex)
            {
                sys.SM(ex.Message);
                return false;
            }
        }
     
        /// <summary>
        /// Команда установки текущего листа по порядковому номеру или имени листа.
        /// </summary>
        /// <param name="book"></param>
		/// <param name="sheetNameOrIndex"></param>  
		/// <param name="showMes">Показывать ошибки или нет</param>  
		/// <param name="sheet"></param>
		/// <param name="errorMes"></param>  		
        /// <returns>Если успешно, то true</returns> 
        public static bool SetCurrentSheet<T>(NPOI.XSSF.UserModel.XSSFWorkbook book,
            T sheetNameOrIndex,
            bool showMes,
            out NPOI.SS.UserModel.ISheet sheet,
            out string errorMes)
        {
            errorMes = "";
            sheet = null;
            if (book == null)
            {
                errorMes = "Книга не создана!";
                if (showMes) sys.SM(errorMes);
                return false;
            }

            int sheetIndex = -1;
            string sheetName = "";
            if (sheetNameOrIndex.GetType().ToString() == "System.Int32")
                sheetIndex += (int)(object)sheetNameOrIndex;
            else
            if (sheetNameOrIndex.GetType().ToString() == "System.String")
                sheetName = (sheetNameOrIndex as System.String);
            else
            {
                errorMes = "Указан неверный номер листа или неверное имя листа";
                if (showMes) sys.SM(errorMes);
                return false;
            }

            if (sheetIndex > -1) sheet = book.GetSheetAt(sheetIndex);
            if (sheetName != "") sheet = book.GetSheet(sheetName);
            if (sheet == null)
            {
                errorMes = "Указано неверное имя листа: " + sheetName;
                if (showMes) sys.SM(errorMes);
                return false;
            }
            return true;
        }

        ///Загрузка одного листа Excel файла в DataTable. Если лист не указан, то берётся первый.
        ///Пример вызова:
        ///System.Data.DataTable DT;
        ///string ErrorMes;
        ///ExcelToDT(@"E:\Мусор\Отчет1_129.xlsx", out DT, out ErrorMes, true, 1);
        public static bool ExcelToDataTable<T>(string fileName,
                                          out System.Data.DataTable dt,
                                          out string errorMes,
                                          bool showMes,
                                          T sheetNameOrIndex
                                          )
        {
            dt = new System.Data.DataTable();
            errorMes = "";
            NPOI.XSSF.UserModel.XSSFWorkbook book = null; //Книга.
            NPOI.SS.UserModel.ISheet sheet = null;        //Лист.

            if (!File.Exists(fileName))
            {
                errorMes = "Не найден файл: " + fileName;
                if (showMes) sys.SM(errorMes);
                return false;
            }
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                book = new NPOI.XSSF.UserModel.XSSFWorkbook(file);
                if (file != null) file.Close();
            }
            catch (Exception ex)
            {
                errorMes = "Ошибка открытия файла шаблона: " + ex.Message;
                if (showMes) sys.SM(errorMes);
                return false;
            }

            //Устанавливаем текущий лист.
            if (!sys.SetCurrentSheet(book, sheetNameOrIndex, showMes, out sheet, out errorMes)) return false;

            string[] arrLine = null;  //= new string[sheet.LastCellNum + 1];          
            int columnsCount = 0;
            //запускаем цикл по строкам
            for (int row = sheet.FirstRowNum; row <= sheet.LastRowNum; row++)
            {
                //получаем строку
                var currentRow = sheet.GetRow(row);
                if (currentRow == null) continue; //null когда строка содержит только пустые ячейки

                //запускаем цикл по столбцам              
                if (arrLine == null)
                {
                    columnsCount = currentRow.LastCellNum;
                    arrLine = new string[currentRow.LastCellNum];
                }
                for (int col = 0; col < columnsCount; col++)
                {
                    //получаем значение ячейки
                    string value = "";
                    var currentCell = currentRow.GetCell(col);
                    if (currentCell == null)
                    {
                        arrLine[col] = value;
                        continue;
                    }
                    NPOI.SS.UserModel.CellType ctype = currentCell.CellType;

                    if (ctype == NPOI.SS.UserModel.CellType.String) value = currentCell.StringCellValue;
                    else if (ctype == NPOI.SS.UserModel.CellType.Boolean) value = currentCell.BooleanCellValue.ToString();
                    else if (ctype == NPOI.SS.UserModel.CellType.Formula) value = currentCell.CellFormula;
                    else if (ctype == NPOI.SS.UserModel.CellType.Numeric) value = currentCell.NumericCellValue.ToString();
                    else if (ctype == NPOI.SS.UserModel.CellType.Error) value = currentCell.ErrorCellValue.ToString();
                    arrLine[col] = value;
                }

                if (row == 0)
                {
                    for (int i = 0; i < arrLine.Length; i++)
                        dt.Columns.Add(arrLine[i], typeof(string));
                }
                else dt.Rows.Add(arrLine);
            }
            return true;
        }

        #endregion Region. Сохранение DataGridView, DataTable в Excel и чтение из Excel.

        #region Region. Сохранение/чтение DataTable в/из файла.

		/// <summary>
		/// Запись DataTable. В файл. Формат файла реализован в FBA, бинарный. 
		/// </summary>
		/// <param name="dt">Исходная таблица, которую сохраняем в файл</param>
		/// <param name="tableName">Произвольное название таблицы</param>
		/// <param name="fileName">Имя файла куда сохраняем таблицу</param>
		/// <param name="errorShow">Показывать ошибки, если возникнут</param>
		/// <returns>Если успрешно, то true</returns>
        public static bool DataTableToFile(this System.Data.DataTable dt, string tableName, string fileName, bool errorShow)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception e)
                {
                    sys.SM(e.Message);
                    return false;
                }
            }
            try
            {
                var ndt = new NewDT();
                string block5 = "";
                DataTableToStr(dt, ref block5);
                ndt.DataTableStr = block5;
                ndt.TableName = tableName;
                var jsonFormatter = new DataContractJsonSerializer(typeof(NewDT));

                using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, ndt);
                    if (fs != null) fs.Close();
                    jsonFormatter = null;
                }
                return true;
            }
            catch (Exception e)
            {
                if (errorShow) sys.SM(e.Message);
                return false;
            }
        }
 
		/// <summary>
		/// Чтение сохранённого DataTable. Из файла. Процедура обратная DataTableToFile.
		/// </summary>
		/// <param name="dt">Полученный DataTable.</param>
		/// <param name="tableName">Прочитанное название таблицы</param>
		/// <param name="fileName">Имя файла куда сохраняем таблицу</param>
		/// <param name="errorShow">Показывать ошибки, если возникнут</param>
		/// <returns>Если успрешно, то true</returns>
        public static bool FileToDataTable(out System.Data.DataTable dt, out string tableName, string fileName, bool errorShow)
        {
            try
            {
                var ndt = new NewDT();
                var fs = new FileStream(fileName, FileMode.OpenOrCreate);
                var jsonFormatter = new DataContractJsonSerializer(typeof(NewDT));
                ndt = (NewDT)jsonFormatter.ReadObject(fs);
                if (fs != null) fs.Close();
                jsonFormatter = null;
                int offset = 0;
                dt = StrToDataTable(ref offset, ref ndt.DataTableStr);
                tableName = ndt.TableName;
                return true;
            }
            catch (Exception e)
            {
                var dt1 = new System.Data.DataTable();
                dt = dt1;
                tableName = "";
                if (errorShow) sys.SM(e.Message);
                return false;
            }
        }

        #endregion Region. Сохранение/чтение DataTable в/из файла.

        #region Region. DataTable.

        //Копирование таблицы в локальную БД.
        /*public static bool DTCopyToLocalBase(System.Data.DataTable DT, string TableName)
        {                                 
            string SQL = sys.GetTextTableToDatabase("SQLite", TableName, DT, true);                
            return Var.conLite.Exec(SQL);   
        }          
        
        ///Копирование таблицы в удаленную БД.
        public static bool DTCopyToRemoteBase(System.Data.DataTable DT, string TableName)
        {                                 
            string SQL = sys.GetTextTableToDatabase(Var.con.ServerType, TableName, DT, true);                
            return Var.con.Exec(SQL);   
        }*/
         
        /// <summary>
        /// Получить DataTable с названиями столбцов в виде списка строк.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ch"></param>
        /// <param name="withCaptions"></param>
        /// <returns></returns>
        public static List<string> GetDataTableAsText(this System.Data.DataTable dt, string ch, bool withCaptions)
        {
            string s;
            string s2;
            var lines = new List<string>();
            int ColCount = dt.Columns.Count;
            //string[] columnNames = DT.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            //string[] columnNames =  sys.DGCaptionWithComma
            if (withCaptions)
            {          
                string columnNames = "";
                for (int i = 0; i < ColCount; i++)
                {
                    if (i < (ColCount - 1)) columnNames = columnNames + dt.Columns[i].ColumnName + ch; // ";";
                    else columnNames = columnNames + dt.Columns[i].ColumnName;
                }

                //lines.Add(string.Join(";", columnNames));
                lines.Add(columnNames);
            }
        foreach (DataRow dr in dt.Rows)
            {
                s2 = "";
                for (int i = 0; i < ColCount; i++)
                {
                    s = dr[i].ToString().Replace(ch, "$$$").Replace(Var.CR, " ");
                    s2 += s;
                    if (i < ColCount - 1) s2 += ch;
                }
                lines.Add(s2);
            }
            return lines;
        }
        
        /// <summary>
        /// Получение списка колонок DT через точку с запятой. 
        /// </summary>
        /// <param name="dt">System.Data.DataTable</param>
        /// <param name="separator">Символ разделитель между колонками, напрмиер точка с запятой</param>
        /// <returns>Строка, содержащая все колонки разделённые символом разделителем</returns>
        public static string DataTableCaptionWithSeparator(this System.Data.DataTable dt, string separator)
        {
            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(col => col.Caption).ToArray();
            return string.Join(separator, columnNames);
        }
            
        /// <summary>
        /// Изменить порядок столбцов DataTable Пример: DT.SetColumnsOrder("Qty", "Unit", "Id");
        /// </summary>
        /// <param name="dt">System.Data.DataTable</param>
        /// <param name="columnNames">Имена колонок в строковом массиве</param>
        public static void SetColumnsOrder(this DataTable dt, params string[] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                dt.Columns[columnName].SetOrdinal(columnIndex);
                columnIndex++;
            }
        }
        
        /// <summary>
        /// Получить значение поля из DataTable из первой строки. так как это часто нужно.
        /// </summary>
        /// <param name="dt">System.Data.DataTable</param>
        /// <param name="fieldName">Поле, значение которого нужно получить</param>
        /// <returns>Значение поля</returns>
        public static string Value(this System.Data.DataTable dt, string fieldName)
        {
        	if (dt == null) return "";
        	if (dt.Rows.Count > 0) return dt.Rows[0][fieldName].ToString();
            return "";
        }        
                
        /// <summary>
        /// Получить значение поля из DataTable из строки с индексом RowIndex и полем FieldName.
        /// </summary>
        /// <param name="dt">System.Data.DataTable</param>
        /// <param name="rowIndex">Индекс строки</param>
        /// <param name="fieldName">Имя поля</param>
        /// <returns>Значение из ячейки в виде текста</returns>
        public static string Value(this System.Data.DataTable dt, int rowIndex, string fieldName)
        {            
        	if (dt.Rows.Count > 0) return dt.Rows[rowIndex][fieldName].ToString();
            return "";
        }               
        
        /// <summary>
        /// Получить значение поля из DataTable.
        /// </summary>
        /// <param name="dt">Таблица с которой получаем значение</param>
        /// <param name="rowIndex">Номер строки, начиная с 0</param>
        /// <param name="columnIndex">Номер колонки, начиная с 0.</param>
        /// <returns>Значение из ячейки в виде текста</returns> 
        public static string Value(this System.Data.DataTable dt, int rowIndex, int columnIndex)
        {
            if (dt.Rows.Count > 0) return dt.Rows[rowIndex][columnIndex].ToString();
            return "";
        }
                                 
        /// <summary>
        /// Заменяем кавычки на двойные для того чтобы сохранить содержимое DataTable 
        /// SQL запросом в базе данных.
        /// </summary>
        /// <param name="dt">DataTable</param>
        public static void DataTableReplaceQuote(ref System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                    dt.Rows[i][j] = dt.Rows[i][j].ToString().QueryQuote();
        }
       
        /// <summary>
        /// Показ на форме таблицы DT. Пример: sys.ViewDataTable("Шапка формы", "Текст на форме", DT);
        /// </summary>
        /// <param name="dt">System.Data.DataTable</param>
        /// <param name="capForm">Шапка формы</param>
        /// <param name="capText">Подпись таблицы на форме</param>
        public static void DataTableView(this System.Data.DataTable dt, string capForm, string capText)
        {
            var dtv = new FormViewTable(capForm, capText, dt);
            dtv.Show();
        }
      
        /// <summary>
        /// Установка ширины колонок грида.
        /// </summary>
        /// <param name="dg">DataGridViewFBA</param>
        /// <param name="columnWidthComma">Ширина колонок через запятую. Пример: 100,150,600</param>
        public static void DataGridViewSetColumnWidth(FBA.DataGridViewFBA dg, string columnWidthComma)
        {
            string[] arrwidth = columnWidthComma.Split(',');
            for (int i = 0; i < arrwidth.Count(); i++) dg.Columns[i].Width = arrwidth[i].Trim().ToInt();

        }
       
        /// <summary>
        /// Чтение из БД и запись строки DataTable в файл.
        /// Чтение происходит так: SELECT * FROM tableName WHERE ID = id
        /// В таблице должна быть колонка ID!
        /// </summary>
        /// <param name="direction">Из локальной или удалённой БД</param>
        /// <param name="id">ИД строки</param>
        /// <param name="tableName">имя таблицы, откуда читаем строку</param>
        /// <param name="fileName">Имя файла куда записываем</param>
        /// <returns>Если успешно, то true</returns>
        public static bool RecordSaveToFile(DirectionQuery direction, string id, string tableName, string fileName = "")
        {
            if (fileName == "")
            {
                fileName = tableName + "." + id;
                const string initialDirectory = "";
                if (!FBAFile.SaveFileName("Export object", "json Files|*.json|All Files|*.*", initialDirectory, 0, ref fileName)) return false;
            }
            string sql = "SELECT * FROM " + tableName + " WHERE ID = " + id + "; ";
            System.Data.DataTable dt;
            SelectDT(direction, sql, out dt);
            return sys.DataTableToFile(dt, tableName, fileName, true);
        }

        ///Чтение строки DataTable из файла и запись в БД.
        public static bool RecordLoadFromFile(DirectionQuery direction, string fileName, bool askRecordExists, out string id)
        {
            //IFRecExists - здесь 3 варианта. ASK, UPDATE, INSERT. Это значит: если ASK, то если мы записываем в БД
            //такой же объект, который есть уже, то спрашиваем пользователя.
            //Если UPDATE - то объект переписываем, если INSERT, то вставляем как новый, соответственно при вставке объект        
            //добавится как новый. с новым ID.            
            id = "";
            var dt = new System.Data.DataTable();
            string tableName = "";
            //sys.DataTableFromFile(out DT, out TableName, FileName, true);
            sys.FileToDataTable(out dt, out tableName, fileName, true);

            if (!((dt.Columns[0].ColumnName == "ID") && (dt.Columns[1].ColumnName == "EntityID") && (tableName != "")))
            {
            	if (askRecordExists)
                    sys.SM("Файл не содержит объекта для записи в БД. \r\n Первые две колонки должны быть ID и EntityID!");
                return false;
            }

            try
            {
                bool objExt = false;
                string operationL = "INSERT";
                id = dt.Rows[0]["ID"].ToString();
                string dateStr = "";

                if (SelectCount(direction, "SELECT ID FROM " + tableName + " WHERE ID = " + id) > 0) objExt = true;
                if (objExt == true) operationL = "UPDATE";

                if ((objExt == true) && (askRecordExists))
                    if (sys.SM("Объект существует. Переписать?", MessageType.Question, "Объект существует") == true)
                        operationL = "UPDATE"; else operationL = "INSERT";

                string sql = "";
                if (operationL == "UPDATE")
                {
                    sql = "UPDATE " + tableName + " SET ";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ColumnName == "ID") continue;
                        if (dt.Columns[i].ColumnName == "EnityID") continue;
                        if (dt.Columns[i].DataType.ToString() == "System.DateTime")
                        {
                            dateStr = ((DateTime)dt.Rows[0][i]).ToString("yyyy-MM-dd hh:mm:ss");
                        }
                        else dateStr = dt.Rows[0][i].ToString();

                        dateStr = dateStr.QueryQuote();
                        sql += dt.Columns[i].ColumnName + " = '" + dateStr + "'";
                        if (i != dt.Columns.Count - 1) sql += ", ";
                    }
                    sql += " WHERE ID = " + id;
                }
                else
                {
                    string val1 = "";
                    string val2 = "";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ColumnName == "ID") continue;
                        val1 += dt.Columns[i].ColumnName;
                        if (i != dt.Columns.Count - 1) val1 += ", ";
                        val2 = dt.Rows[0][i].ToString();
                        val2 = "'" + dateStr.QueryQuote() + "'";
                        if (i != dt.Columns.Count - 1) val2 += ", ";
                    }
                    sql = "INSERT INTO " + tableName + " (" + val1 + ") values (" + val2 + ")";
                }
                dt.Dispose();                
                //sys.SM(SQL, MessageType.Information,"Пример запроса");          
                if (operationL == "INSERT") Exec(direction, true, sql, out id); 
                if (operationL == "UPDATE") Exec(direction, sql);       
                return true;
            }
            catch (Exception ex)
            {
                sys.SM("Чтение строки DataTable из файла и запись в БД" + Var.CR + ex.Message);
                tableName = "";
                dt = null;
                return false;
            }
        }

        ///Копирование области из DataTable в другой DataTable.
        public static System.Data.DataTable DataTable_Area_To_DataTable(DataTable dt, int areaLeft, int areaTop, int areaRight, int areaBottom, bool insertFirstColumn)
        {
            if (dt == null) return null;
            System.Data.DataTable dtClone = dt.Clone();

            //Копирование выделенных строк в другой DataTable.
            for (int iRow = areaTop; iRow <= areaBottom; iRow++)
            {
                System.Data.DataRow row;
                row = dt.Rows[iRow];
                dtClone.ImportRow(row);
            }
            int firstColumn;
            if (insertFirstColumn) firstColumn = 0; else firstColumn = -1;
            for (int iCol = dt.Columns.Count - 1; iCol > firstColumn; iCol--)
            {
                if ((iCol > areaRight) || (iCol < areaLeft))
                    dtClone.Columns.RemoveAt(iCol);               
            }
            return dtClone;
        }

        /// <summary>
        /// Копирование DataTable в другую DataTable, включая формат колонок и все содержимое всех столбцов и строк.
        /// </summary>
        /// <param name="dtsource">DataTable которую копируем.</param>
        /// <returns></returns>
        public static System.Data.DataTable DataTable_To_DataTable(DataTable dtsource)
        {
            DataTable dataTable2 = dtsource.Copy();
            return dataTable2;
        }

        #endregion Region. DataTable.           
       
        #region Regon. FBA.GridFBA
                     
        
       
        /// <summary>
        /// Многопоточная функция. Для получения данных для MSSQL, Postgre, SQLite для SourceGrid.
        /// Для очистки SourceGrid.DataGrid нужно передать пустой запрос (sql = "")
        /// </summary>
        /// <param name="direction">Запрос к локальной или удалённой БД</param>
        /// <param name="dg">SourceGrid.DataGrid</param>
        /// <param name="filter">Объект с настройками фильтра</param>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="tbStatus">Если не null, то в этом TextBoxFBA отображается дополнительная информация</param>
        /// <returns>Если успешно, то true</returns>
        public static bool RefreshGrid_SourceGrid_MultiThread(DirectionQuery direction, 
                                                              SourceGrid.DataGrid dg, //FBA.GridFBA dg, 
                                                              FilterObj filter,
                                                              string sql,
                                                              TextBoxFBA tbStatus)
        {                         
        	
        	if (string.IsNullOrEmpty(sql))
            {            
        		dg.DataSource = null;
        		dg.BackgroundImage = global::FBA.Resource.no_data;
                return true;
            }
            
            //Код выполняется в отдельном потоке
            var task1 = Task.Factory.StartNew(() =>
            {
                System.Data.DataTable DT;
                bool flag1 = SelectDT(direction, sql, out DT);                                            
                if (DT == null)
                {
                    dg.BackgroundImage = global::FBA.Resource.no_data;
                    return null;
                }               
                return DT;
            });

            //После завершения обновляем GUI компаненты.
            var task2 = task1.ContinueWith((previous) =>
            {

                //Доступ к UI контролам   
                //FBA.GridFBA DG1 = (FBA.GridFBA)task1.Result;
                //DG.DataSource = DG1.DataSource;
                var DT = (System.Data.DataTable)task1.Result;
                if (DT == null) return false;            
                var bd = new DevAge.ComponentModel.BoundDataView(DT.DefaultView);
                //if (DG.DataSource != null) ((DevAge.ComponentModel.BoundDataView) DG.DataSource).DataTable.Clear();
                //if (DG.DataSource != null) ((System.Data.DataTable)DG.DataSource).Clear();
                //DG.DataSource = null;
                dg.Columns.Clear();
                dg.DataSource = bd;
                dg.Rows.HeaderHeight = 60;
                
                Color Color3 = Color.FromArgb(243, 243, 243);
                //SourceGrid.Cells.Views.ColumnHeader view3 = new SourceGrid.Cells.Views.ColumnHeader();
                //SourceGrid.Cells.Views.Header view3 = new SourceGrid.Cells.Views.ColumnHeader();
				SourceGrid.Cells.Views.Header view3 = new SourceGrid.Cells.Views.RowHeader();
				
                //view3.BackColor = Color.FromArgb(187, 205, 251);
                //view3.TextAlignment = ContentAlignment.MiddleCenter;
                
                //view3.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);                
                //view3.TrimmingMode = TrimmingMode.Word;
                //view3.WordWrap = true;
                //view3.ForeColor = Color.FromArgb(1, 11, 182);
                //view3.BackColor = Color.FromArgb(142, 142, 255);
                
                //DevAge.Drawing.VisualElements.IHeader gg;
            
                //view3.Background = gg;
                //DG.BackColor = Color.FromArgb(142, 142, 255);                                
                
                
                var captionModel = new SourceGrid.Cells.Views.Cell();
                //captionModel.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);     
                //captionModel.ForeColor = Color.FromArgb(1, 11, 182);
                captionModel.BackColor = Color.FromArgb(50, Color.FromArgb(252, 254, 167)); // Color.FromArgb(187, 205, 251); //Color.FromArgb(50, Color.FromArgb(239, 245, 107)); //Color.FromArgb(142, 142, 255);
                
                //DevAge.Drawing.VisualElements.IColumnHeader ff;
                //DevAge.Drawing.VisualElements
                
                //DevAge.Drawing.VisualElements.HeaderSortStyle
                DevAge.Drawing.VisualElements.SortIndicator dd = new DevAge.Drawing.VisualElements.SortIndicator();
                dd.SortStyle = DevAge.Drawing.HeaderSortStyle.Ascending;                	
                //captionModel.ElementSort = dd;
                
                //captionModel.Background = ff;
                //captionModel.WordWrap = true;
                //captionModel.TextAlignment = ContentAlignment.MiddleCenter;  
				
                //var ff = new DevAge.Drawing.AnchorArea();
                //ff.
                //captionModel.AnchorArea = ff; // = DevAge.Drawing.VisualElements.;
                //DevAge.Drawing.VisualElements.IImage gfg;
                //gfg.Value = Image.FromFile("");
                //captionModel.ElementImage = gfg;

				
                int i = 0;
                int[] ColumnWidth = null;
                ColumnWidth = filter.ColumnWidth;
                  	                               
                foreach (SourceGrid.DataGridColumn col in dg.Columns)
                {
                	//AlternateColor. Это цвет чередующихся строк.
                    SourceGrid.Conditions.ICondition condition = SourceGrid.Conditions.ConditionBuilder.AlternateView(col.DataCell.View, Color3, Color.Black);
                    col.Conditions.Add(condition);

                    //Header
                    col.HeaderCell.View = captionModel;
                    
                    //Установка ширины колонок из фильтра.
                    if ((filter.ColumnWidth != null) && (i < dg.Columns.Count)) col.Width = filter.ColumnWidth[i];
                    else col.AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize; 
                    //SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;  
                    i++;
                }
              
                if (tbStatus != null)
                {
                    string StatusText = "Rows: " + DT.Rows.Count.ToString() + " Columns: " + DT.Columns.Count.ToString();
                    if ((filter.MaxRecords > 0) && (DT.Rows.Count == filter.MaxRecords))
                    {
                        StatusText = StatusText + " not all rows are shown!";
                        tbStatus.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
                        tbStatus.ForeColor = Color.Red;
                        tbStatus.Text = StatusText;
                    }
                    else
                    {
                        tbStatus.ForeColor = Color.Black;
                        tbStatus.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
                        tbStatus.Text = StatusText;
                    }
                }

                return true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return true;
        }

        ///Функция в основном потоке для получения данных для MSSQL, Postgre, SQLite для SourceGrid.
        public static bool RefreshGrid_SourceGrid_OneThread(DirectionQuery direction, 
                                                            GridFBA DG, //FBA.GridFBA DG, 
                                                            FilterObj filter, 
                                                            TextBoxFBA tbStatus)
        {
            string sql = "";
            int[] ColumnWidth = null;
            if (filter != null)
            {
                sql = filter.FullQuerySQL;
                ColumnWidth = filter.ColumnWidth;
            }

            DG.Columns.Clear();
            if (DG.DataSource == null)
            {
                //Возможность выделять несколько строк.
                DG.SelectionMode = GridSelectionMode.Cell; //Включение возможности выделения отдельных ячеек.
                DG.Selection.EnableMultiSelection = true;

                //Selection BorderColor
                var Selection = DG.Selection as SelectionBase;
                DevAge.Drawing.RectangleBorder border = Selection.Border;
                border.SetColor(Color.FromArgb(6, 1, 214));
                Selection.Border = border;

                //Selection BackColor
                //Selection.BackColor = Color.FromArgb(50, Color.FromArgb(252, 254, 167)); //Светло желтый
                //Selection.BackColor = Color.FromArgb(50, Color.FromArgb(239, 245, 107)); //Желтый
                Selection.BackColor = Color.FromArgb(50, Color.FromArgb(142, 142, 255));   //Сиреневый
                                                                                           //Selection BorderWidth
                DevAge.Drawing.RectangleBorder b = Selection.Border;
                b.SetWidth(1);
                Selection.Border = b;

                //Selection FocusBackColor
                Selection.FocusBackColor = Color.FromArgb(50, Color.FromArgb(226, 254, 118));

                DG.ClipboardMode = SourceGrid.ClipboardMode.Copy;
                //DG.AutoStretchColumnsToFitWidth = true;
                //DG.AutoStretchRowsToFitHeight = false;
                //DG.AutoSizeCells();
                //DG.Rows.HeaderHeight = 40;
                //DG.BackgroundImage = null;
            }           
         
            System.Data.DataTable DT;
            bool flag1 = SelectDT(direction, sql, out DT);
            if (DT == null)
            {
                DG.BackgroundImage = global::FBA.Resource.no_data;
                return false;
            }
                 
            //После завершения обновляем GUI компаненты.           
            if (DT == null) return false;
            var bd = new DevAge.ComponentModel.BoundDataView(DT.DefaultView);        
            DG.DataSource = bd;
            DG.Rows.HeaderHeight = 60;


            Color Color3 = Color.FromArgb(243, 243, 243);  
            SourceGrid.Cells.Views.Header view3 = new SourceGrid.Cells.Views.ColumnHeader();   
            view3.TextAlignment = ContentAlignment.MiddleCenter;
            view3.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            view3.WordWrap = true;
            view3.ForeColor = Color.FromArgb(1, 11, 182);  

            int i = 0;
            if (DG.Columns.Count == filter.ColumnWidth.Length)
                foreach (SourceGrid.DataGridColumn col in DG.Columns)
                {
                    //AlternateColor
                    SourceGrid.Conditions.ICondition condition = SourceGrid.Conditions.ConditionBuilder.AlternateView(col.DataCell.View, Color3, Color.Black);
                    col.Conditions.Add(condition);

                    //Header
                    col.HeaderCell.View = view3;

                    //Установка ширины колонок из фильтра.
                    col.Width = filter.ColumnWidth[i];
                    i++;
                }

            string StatusText = "Rows: " + DT.Rows.Count.ToString() + " Columns: " + DT.Columns.Count.ToString();
            if ((filter.MaxRecords > 0) && (DT.Rows.Count == filter.MaxRecords))
            {
                StatusText = StatusText + " not all rows are shown!";
                tbStatus.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
                tbStatus.ForeColor = Color.Red;
                tbStatus.Text = StatusText;
            }
            else
            {
                tbStatus.ForeColor = Color.Black;
                tbStatus.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
                tbStatus.Text = StatusText;
            }
            return true;                
        }
       
        //Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
        ///filter - это FilterObj или string в котором SQL запрос. (Не MSQL!)
        public static bool RefreshGrid<T>(DirectionQuery direction, T dg, string sql, TextBoxFBA tbStatus = null)
        {
            var filter = new FilterObj();
            filter.FullQuerySQL = sql;
            if (dg.GetType().ToString() == "FBA.GridFBA") 
            	RefreshGrid_SourceGrid_MultiThread(direction, dg as GridFBA, filter, sql, tbStatus);
            if (dg.GetType().ToString() == "System.Windows.Forms.DataGridView") 
            	(dg as FBA.DataGridViewFBA).RefreshGrid(direction, sql);
            if (dg.GetType().ToString() == "FBA.DataGridViewFBA") 
            	(dg as FBA.DataGridViewFBA).RefreshGrid(direction, sql);
            if (dg.GetType().ToString() == "SourceGrid.DataGrid")
                return RefreshGrid_SourceGrid_MultiThread(direction, dg as SourceGrid.DataGrid, filter as FilterObj, sql, tbStatus);
            return true;
        }

        ///Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
        ///Общая для нескольких типов.
        ///DG - это System.Windows.Forms.DataGridView, FBA.GridFBA       
        public static bool RefreshGrid<T>(DirectionQuery direction, T dg, FilterObj filter, TextBoxFBA tbStatus = null)
        {
            string sql = "";
            string msql = "";
            if (filter.GetType().ToString() == "FBA.FilterObj")
            {
                sql  = (filter as FilterObj).FullQuerySQL;
                msql = (filter as FilterObj).FullQueryMSQL;
            }
            if ((sys.IsEmpty(sql)) && (!sys.IsEmpty(msql))) sql = sys.Parse(msql);   

            if (dg.GetType().ToString() == "FBA.GridFBA") 
            	RefreshGrid_SourceGrid_MultiThread(direction, dg as GridFBA, filter, sql, tbStatus);
            if (dg.GetType().ToString() == "System.Windows.Forms.DataGridView") 
            	(dg as FBA.DataGridViewFBA).RefreshGrid(direction, sql);
            if (dg.GetType().ToString() == "FBA.DataGridViewFBA") 
            	(dg as FBA.DataGridViewFBA).RefreshGrid(direction, sql);
            if (dg.GetType().ToString() == "SourceGrid.DataGrid")
                return RefreshGrid_SourceGrid_MultiThread(direction, dg as SourceGrid.DataGrid, filter as FilterObj, sql, tbStatus);
                     
            return false;
        }

        
        #endregion Region. FBA.GridFBA 

        #region Region. MenuStrip.

        ///Вставка пункта меню в ContextMenuStrip.
        public static void InsertMenuContext(System.Windows.Forms.ContextMenuStrip cmGrid, 
                                             System.Windows.Forms.ToolStripItem cm,                                    
                                             System.Drawing.Image img, 
                                             string cmName,                                      
                                             string cmText, 
                                             ref int Index)
        {
            cmGrid.Items.Insert(Index, cm);
            cm.Image = img;
            cm.Name  = cmName;                  
            cm.Text  = cmText;
            Index++;
        }
        
        //Вставка кнопки в панель кнопок.
        /*public static void InserMenuStrip(System.Windows.Forms.ToolStrip tsm,
                                          System.Windows.Forms.ToolStripButton tb,                                           
                                          System.Drawing.Image img, 
                                          string tbName,
                                          string tbText,
                                          ref int Index)
        {
            tsm.Items.Insert(Index, tb);
            tb.Image = img;
            tb.Name  = tbName;                  
            tb.Text  = tbText;
            Index++;
        }
        
        ///Создание пунктов контекстного меню.
        public static void CreateFilterMenu(FBA.DataGridViewFBA DG,
                                            System.Windows.Forms.ToolStrip tsm,
                                            bool CommandAdd, 
                                            bool CommandEdit,
                                            bool CommandDel,
                                            bool CommandFilter,
                                            bool CommandRefresh,
                                            bool CommandExportToExcel,
                                            bool CommandSaveASCSV)
        {              
            string Prefix = DG.Name;
            
            //Контекстное меню.
            int Index = 0;
            ContextMenuStrip cmGrid = DG.ContextMenuStrip;
            if (cmGrid == null) return;
            cmGrid.Font = Var.font1;
            cmGrid.Name = Prefix + "cmGrid";
                         
            var cmGridN1 = new System.Windows.Forms.ToolStripMenuItem(); //Add
            var cmGridN2 = new System.Windows.Forms.ToolStripMenuItem(); //Edit
            var cmGridN3 = new System.Windows.Forms.ToolStripMenuItem(); //Del          
            var cmGridN4 = new System.Windows.Forms.ToolStripMenuItem(); //Filter 
            var cmGridN5 = new System.Windows.Forms.ToolStripMenuItem(); //Ref           
            var cmSep1   = new System.Windows.Forms.ToolStripSeparator();
            var cmGridN6 = new System.Windows.Forms.ToolStripMenuItem(); //Excel
            var cmGridN7 = new System.Windows.Forms.ToolStripMenuItem(); //CSV
            var cmSep2   = new System.Windows.Forms.ToolStripSeparator();                                
             
            if (CommandAdd)      InsertMenuContext(cmGrid, cmGridN1, global::FBA.Resource.Add,     Prefix + "cmGridN1", "Add",     ref Index);
            if (CommandEdit)     InsertMenuContext(cmGrid, cmGridN2, global::FBA.Resource.Edit,    Prefix + "cmGridN2", "Edit",    ref Index);
            if (CommandDel)      InsertMenuContext(cmGrid, cmGridN3, global::FBA.Resource.Del,     Prefix + "cmGridN3", "Del",     ref Index);
            if (CommandFilter)   InsertMenuContext(cmGrid, cmGridN4, global::FBA.Resource.Filter,  Prefix + "cmGridN4", "Filter",  ref Index);
            if (CommandRefresh)  InsertMenuContext(cmGrid, cmGridN5, global::FBA.Resource.Refresh, Prefix + "cmGridN5", "Refresh", ref Index);                     
            if (CommandExportToExcel || CommandSaveASCSV)
            {      
                InsertMenuContext(cmGrid, cmSep1, null, Prefix + "cmSep1", "cmSep1", ref Index);             
                if (CommandExportToExcel) InsertMenuContext(cmGrid, cmGridN6, null, Prefix + "cmGridN6", "Export to Excel", ref Index);
                if (CommandSaveASCSV)     InsertMenuContext(cmGrid, cmGridN7, null, Prefix + "cmGridN7", "Save as CSV", ref Index);
            }                         
            if (cmGrid.Items.Count > 8) InsertMenuContext(cmGrid, cmSep2, null,  Prefix + "cmSep2", "cmSep2", ref Index);
            //Панель с кнопками.
            Index = 0;
            var tbN1 = new System.Windows.Forms.ToolStripButton();
            var tbN2 = new System.Windows.Forms.ToolStripButton();
            var tbN3 = new System.Windows.Forms.ToolStripButton();
            var tbN4 = new System.Windows.Forms.ToolStripButton();
            var tbN5 = new System.Windows.Forms.ToolStripButton();
           
            tsm.Font = Var.font1;
            tsm.Name = "tsm";   
            tsm.Text = "tsm";
                
            if (CommandAdd)      InserMenuStrip(tsm, tbN1, global::FBA.Resource.Add,     Prefix + "tbN1", "Add",     ref Index);
            if (CommandEdit)     InserMenuStrip(tsm, tbN2, global::FBA.Resource.Edit,    Prefix + "tbN2", "Edit",    ref Index);
            if (CommandDel)      InserMenuStrip(tsm, tbN3, global::FBA.Resource.Del,     Prefix + "tbN3", "Del",     ref Index);
            if (CommandFilter)   InserMenuStrip(tsm, tbN4, global::FBA.Resource.Filter,  Prefix + "tbN4", "Filter",  ref Index);
            if (CommandRefresh)  InserMenuStrip(tsm, tbN5, global::FBA.Resource.Refresh, Prefix + "tbN5", "Refresh", ref Index);                                 
        }*/
               
        /// <summary>
        /// Получить имя компонента переданного в обработчик события как object.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>Имя sender</returns>
        public static string GetSenderName(object sender)
        {    
            return sender.GetType().GetProperty("Name").GetValue(sender).ToString(); 
            //return ((Control)sender).Name;
        } 
               
        /// <summary>
        /// Возвращает имя компонента, на котором повешено контекстное меню. 
        /// </summary>
        /// <param name="sender">object</param>
        /// <returns>Имя компонента, на котором повешено контекстное меню</returns>
        public static string GetControlNameByMenuStripItem(object sender)
        {    
            string CompType = sender.GetType().ToString();
            if (CompType == "System.Windows.Forms.ToolStripMenuItem") return ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Name;
            if (CompType == "System.Windows.Forms.ContextMenuStrip")  return ((ContextMenuStrip)sender).SourceControl.Name;
            return "";    
        }         
        
        /// <summary>
        /// Возвращает компонент, на котором повешено контекстное меню. 
        /// </summary>
        /// <param name="sender">object</param>
        /// <returns>object - компонент</returns>
        public static object GetControlByMenuStripItem(object sender)
        {    
            string CompType = sender.GetType().ToString();
            if (CompType == "System.Windows.Forms.ToolStripMenuItem") return ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            if (CompType == "System.Windows.Forms.ContextMenuStrip")  return ((ContextMenuStrip)sender).SourceControl;
            return null;    
        }
        
        #endregion Region. MenuStrip.            
      
        #region Region. TreeView.            
        
        /// <summary>
        /// Загрузить дерево из DataTable в TreeView. В таблице DT поля ID, ParentID, Name.
        /// </summary>
        /// <param name="tv">System.Windows.Forms.TreeView</param>
        /// <param name="dt">System.Data.DataTable</param>
        /// <param name="fieldID">ID</param>
        /// <param name="fieldParentID">ParentID</param>
        /// <param name="fieldName">Значение этого поля - название узла дерева</param>
        /// <param name="sort">Если true, то сортировать дерево</param>
        public static void LoadTreeFromDataTable(this System.Windows.Forms.TreeView tv, 
                                                 System.Data.DataTable dt,
                                                 string fieldID, 
                                                 string fieldParentID, 
                                                 string fieldName,
                                                 bool sort)
        {                                
            foreach (DataRow dr in dt.Select(fieldParentID + " = 0 OR " + fieldParentID + " IS NULL"))
            {
                var node = new TreeNode();
                node.Text = (string)dr[fieldName];
                node.Tag = dr[fieldID];
                  
                tv.Nodes.Add(node);
                AddNodes(dt, fieldID, fieldParentID, fieldName, node);
            }
            if (sort) tv.Sort();
        }
        
        ///Метод только для LoadTreeFromDataTable.
        private static void AddNodes(System.Data.DataTable DTEnt, 
                                     string FieldID,
                                     string FieldParantID, 
                                     string FieldName,
                                     TreeNode node)
        {    
            foreach (DataRow dr in DTEnt.Select(FieldParantID + " = " + node.Tag.ToString()))
            {
                var node1 = new TreeNode();
                node1.Text = (string)dr[FieldName];
                node1.Tag = dr[FieldID];
                node.Nodes.Add(node1);
                AddNodes(DTEnt, FieldID, FieldParantID, FieldName, node1);
             }
        }
                     
        /// <summary>
        /// Запрос, который позволяет отстортировать список с ID и ParentID сущность fbaEntity.
        /// по порядку, как например в оглавлении книги. 
        /// </summary>
        /// <returns>Запрос для сортировки fbaEntity</returns>
        public static string GetSQLTreeOrder()
        {
            return 
            ";WITH SortedList (Id, ParentId, Brief, Level)" + Var.CR +
            "AS                                           " + Var.CR +
            "(SELECT                                      " + Var.CR +
            "    Id,                                      " + Var.CR +
            "    ParentId,                                " + Var.CR +
            "    Brief,                                   " + Var.CR +
            "    CAST(Id AS VARCHAR(max)) as Level        " + Var.CR +
            "  FROM fbaEntity                             " + Var.CR +
            "  WHERE ParentId IS NULL                     " + Var.CR +
            "  UNION ALL                                  " + Var.CR +
            "  SELECT ll.Id, ll.ParentId, ll.Brief, (s.Level + '.' + (CAST(ll.Id AS VARCHAR(max)))) as Level " + Var.CR +
            "    FROM fbaEntity ll                        " + Var.CR +
            "   INNER JOIN SortedList as s                " + Var.CR +
            "      ON ll.ParentId = s.Id)                 " + Var.CR +
            "SELECT Id, ParentId, Brief, Level FROM SortedList ORDER BY Level" + Var.CR;
        }               
        
        /// <summary>
        /// Поиск текста в дереве.
        /// Использование:     
        /// TreeNode SelectedNode = sys.SearchNode(tbFind.Text, treeViewAttr.Nodes[0]);//пытаемся найти в поле Text
        ///    if (SelectedNode != null)
        ///    {
        ///        //нашли, выделяем...
        ///        treeViewAttr.SelectedNode = SelectedNode;
        ///        treeViewAttr.SelectedNode.Expand();
        ///        treeViewAttr.Select();
        ///    };
        /// </summary>
        /// <param name="searchText">Искомый текст</param>
        /// <param name="startNode">Узел, с которого начинать поиск</param>
        /// <param name="seachParam">Настройки поиска: NotAssigned, Exact, Contains, Begin, End</param>
        /// <param name="ignoreCase">Игнорировать регистр символов</param>
        /// <returns></returns>
        public static TreeNode SearchNode(string searchText, TreeNode startNode, SearchParam seachParam, bool ignoreCase)
        {
            TreeNode node = null;
            while (startNode != null)
            {
                bool Find = false;
                string Str1 = startNode.Text;
                string Str2 = searchText;
                if (ignoreCase) 
                {
                    Str1 = Str1.ToUpper();
                    Str2 = Str1.ToUpper();
                }
                //if (StartNode.Text.ToLower().Contains(SearchText.ToLower()))
                if ((seachParam == SearchParam.Exact)    && (Str1 == Str2))         Find = true;
                if ((seachParam == SearchParam.Contains) && (Str1.Contains(Str2))) Find = true;
                if ((seachParam == SearchParam.Begin)    && (Str1.IndexOf(Str2, StringComparison.Ordinal) == 0)) Find = true;
                if ((seachParam == SearchParam.End)      && (Str1.Reverse().IndexOf(Str2.Reverse(), StringComparison.Ordinal) == 0)) Find = true;
                
                if (Find)
                {
                    node = startNode; //чето нашли, выходим
                    break;                   
                }
                if (startNode.Nodes.Count != 0) //у узла есть дочерние элементы
                {
                    node = SearchNode(searchText, startNode.Nodes[0], seachParam, ignoreCase);//ищем рекурсивно в дочерних
                    if (node != null) break; //чето нашли                   
                }
                startNode = startNode.NextNode;
            }
            return node; //вернули результат поиска
        }
        
        #endregion Region. TreeView.                 
    }
    
}
