using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SourceGrid.Utils;
using System.Threading;
using NPOI.SS.Formula.Functions;
using NPOI.HSSF.Util;
using NPOI.XSSF.Util;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Office.Interop.Excel;
using NPOI.SS.Formula;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Windows;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.CodeDom.Compiler;
using System.Diagnostics.Eventing.Reader;
using Microsoft.CSharp;
using System.Net;
using NPOI.XSSF.UserModel;
using DataTable = System.Data.DataTable;
using IFont = NPOI.SS.UserModel.IFont;


//==============================================================================================================
//Колонки таблицы описания типа значения для загрузки бордеро:
//==============================================================================================================
//ImportType          - Тип файла импорта.
//ColumbNumber        - Порядковый номер колонки в бордеро.
//ColumnName          - Назание колонки.
//FieldName           - Название поля.
//FieldType           - Тип поля: int, varchar, date, datetime, time, float, numeric, currency, regexpr.
//                      А также: Birthday, FIO, LASTNAMEINITIALS, INITIALSLASTNAME, INN, KPP, POSTCODE, WorkDate, CURCODE, MOBILEPHONE, EMAIL, FILENAME, FULLFULENAME                   
//                      CURCODE - RUR, USD, EUR - проверка по справочнику кодов валют.
//                      FILENAME, FULLFULENAME - корректное имя файла с путём или без него.
//                      DATEUSER1 - дата только в будущем,
//                      DATEUSER2 - дата только в будущем, включая сегодняшний день.
//                      DATEUSER3 - дата только в прошлом,
//                      DATEUSER4 - дата только в прошлом, включая сегодняшний день.
//                      WORKDATEUSER - дата из рабочего календаря, проверка по таблице рабочих дней.              
//                      MOBILEPHONE - формат мобильного телефона. 
//                      PHONE - формат телефона.
//                      LASTNAMEINITIALS - Петров А.В.
//                      INITIALSLASTNAME - А.В Петров
//                      AGE - возраст.
//                      ORDERNUMBER - порядковый номер. Проверяется что все строки содержат увеличивающийся порядковый номер начиная с 1.
//FieldFormat         - Если varchar, то дина поля, или формат даты,
//                      даты-времени, времени пример: dd.mm.yyyy hh:mm:ss.sss, для numeric, пример: 5,7.
//                      Если EMAIL, или MOBILEPHONE, то здесь можно указать регулярное выражение. Иначе будет проверка по регулярному выражению по умолчанию.
//                      
//FieldObligatory     - Признак обязательности наличия поля в бордеро: 0 или 1.
//ValueObligatory     - 1 или 0. Если 1, то поле обязательно должно быть заполнено.
//DoubleParam1        - Проверка дублирования значения, допустимые значения: bordero, borderotable, borderoentity.                
//                      bordero - проверка на дубль внутри бордеро. 
//                      borderotable - проверка на дубль внутри бордеро в более ранних строках и в указанной таблице и поле. 
//                      borderoentity - проверка на дубль внутри бордеро в более ранних строках и в указанной сущности и атрибуте.
//DoubleParam2        - TableName.FieldName или Entity.Attr.
//DoubleParam3        - errorifexist, errorifnotexists. Генерим ошибку если дубль найден или наоборот, если не найден.
//CheckExistsParam1   - Простая проверка по наличию значения. Допустимые значения: table или entity, value 
//CheckExistsParam2   - TableName.FieldName или Entity.Attr. 
//CheckExistsParam3   - Допустимые значения: errorifexist, errorifnotexists. Генерим ошибку значение найдено или наоборот, если не найден.
//TryParse            - 1 или 0. Если 1, то если например дата неверного формата, делается попытка понять, что за формат даты введён.
//                      Попытка привести формат телефона к нужному.
//ListValidValues     - Список допустимых значений через запятую. Саму запятую в качестве значения использовать в этом случае нельзя. Пример: 0, 1, 2, 3.
//ListNotValidValues  - Список НЕ допустимых значений через запятую. Саму запятую в качестве значения использовать в этом случае нельзя. Пример: 0, 1, 2, 3.
//ListValidChars      - Список допустимых символов, без пробелов. Пример: afgsthb.
//ListNotValidChars   - Список НЕ допустимых символов, без пробелов. Пример: afgsthb.
//ListReplace         - Список пар значений, что менять и на что менять: aaa:bbb, 5:2, 124.54:8.434 точка и двоеточние - зарезервированне знаки, использовать в списке нельзя.
//RegExpr             - Регулярное выражение: regexpr, используется, если указано в колонке FieldFormat.
//DeleteNotValidChars - 1 или 0. Если 1, то из значения убираются все символы, которые указаны как недопустимые. 
//LeaveValidChars     - 1 или 0. Если 1, то из значения убираются все символы, которые не в списке допустимых. 
//SetCharCase         - Значения: Upper, Lower, FirstUpper. Если FirstUpper, то каждая первая буква слова преобразуется в верхний регистр
//MinValue            - Нижный предел значения, подходит для всех чисел, дат, времени, строк. Если строка меньше длиной, то ошибка, иначе пропускается.
//MaxValue            - Верхний предел значения, подходит для всех чисел, дат, времени, строк. Если длина строки выходит за пределы, то ошибка, иначе тихо обрезается, если тут ничего не указано.
//DefaultValue        - Если поле не заполнено, то не считаем ошибкой и тогда заполняем значением по умолчанию.
//SetNewValue         - Неважно, что заполнено в бордеро в этом поле, меняем на введённое значение.
//CheckMSQLQuery      - Запросы MSQL, посредством которых нужно проверить значение поля в колонке.
//CheckSQLQuery       - Запросы SQL, посредством которых нужно проверить значение поля в колонке.
//TableName           - Имя таблицы в БД, куда будет загружено бордеро, либо значение temp, тогда это будет динамически созданная временная таблица.
//Comment             - Описание поля(комментарий).



//Сортировка при выводе....
//Проверка периода... как то сделать.
//Степень родства - degree of relationship

/*
    ID INTEGER PRIMARY KEY,
    ColumnNumber        INTEGER 
    ColumnName          TEXT       Сделано.
    ColumnObligatory    INTEGER    Сделано.   
    ColumnType          TEXT
                                     Тип поля: int, varchar, date, datetime, time, float, numeric, currency, regexpr.
                                                      А также: Birthday, FIO, LASTNAMEINITIALS, INITIALSLASTNAME, INN, KPP, POSTCODE, WorkDate, CURCODE, MOBILEPHONE, EMAIL, FILENAME, FULLFULENAME                   
                                                      CURCODE - RUR, USD, EUR - проверка по справочнику кодов валют.
                                                      FILENAME, FULLFULENAME - корректное имя файла с путём или без него.
                                                      DATEFUTURE - дата только в будущем,                           
                                                      DATELAST - дата только в прошлом,                 
                                                      DATEWORK - дата из рабочего календаря, проверка по таблице рабочих дней.              
                                                      MOBILEPHONE - формат мобильного телефона. 
                                                      PHONE - формат телефона.
                                                      LASTNAMEINITIALS - Петров А.В.
                                                      INITIALSLASTNAME - А.В Петров
                                                      AGE - возраст.
    ColumnFormat        TEXT   - Если varchar, то дина поля, или формат даты,
                                                      даты-времени, времени пример: dd.mm.yyyy hh:mm:ss.sss, для numeric, пример: 5,7.
                                                      Если EMAIL, или MOBILEPHONE, то здесь можно указать регулярное выражение. Иначе будет проверка по регулярному выражению по умолчанию.
                                                      
     
    FieldName           TEXT
    ValueObligatory     INTEGER
    DoubleCheck         INTEGER
    DoubleType          TEXT
    DoubleResult        TEXT
    
    ExistCheck          INTEGER    1 или 0. Проверять или нет наличие значения.
    ExistType           TEXT       Проверка по наличию значения. Допустимые значения: Table, Entity. Если Table - проверка по таблице в БД, Entity - по значению атрибута, Value - наличие значения в принципе.
    ExistParam          TEXT       Значения TableName.FieldName или Entity.Attr. 
    ExistResult         TEXT       Два варианта, ошибка если значение есть или ошибка если значения нет, константы: ERROREXIST, ERRORNOTEXIST
   
    TryParse            INTEGER
    ListValidStrings    TEXT,
    ListNotValidStrings TEXT,
    ListValidChars      TEXT,
    LisNotValidChars    TEXT,
    ListReplaceChars    TEXT,
    ListReplaceStrings  TEXT,
    RegExpr             TEXT,
    RegExprResult       TEXT,
    DeleteChars         TEXT,
    LeaveChars          TEXT,
    DeleteValues        TEXT,
    LeaveValues         TEXT,
    SetCharCase         TEXT,
    MinValue            TEXT,
    MaxValue            TEXT,
    DefaultValue        TEXT,     Сделано.
    SetValue            TEXT,     Сделано.
    CountRowsMax        INTEGER,  Сделано.
    CountRowsMin        INTEGER,  Сделано.
    MSQLQuery           TEXT,
    SQLQuery            TEXT,
    Comment             TEXT
*/



//==============================================================================================================

//==============================================================================================================
//Колонки таблицы куда будет загружено бордеро, это дополнительные колонки, которые будут
//присутствовать дополнительно тем колонкам, которые уже есть в бордеро:
//==============================================================================================================
//OrderNumber         - Порядковый номер строки при загрузке.
//ResultStr           - Результат проверки запросами. Текстовое описание проверок.
//ResultCode          - Список кодов проверки. Результат проверки запросами. Коды проверок.
//ErrorMark           - 1 или 0. Есть ошибка или нет. Если есть, то описание ошибки в поле Result.
//ErrorCount          - Количество найденных ошибок.
//GUID                - Уникальный гуид текущей проверки бордеро. Так как по этой таблице может идти загрузка и проверка другими пользователями.
//Нужно иметь возможность посмотреть список ошибок по каждому значению, или хотя бы посто корректно или нет. 
//Нужна универсальная, настраиваемая форма загрузки.
//==============================================================================================================

namespace FBA
{
    
	///Класс для импорта всех бордеро - файлов Excel, CSV. Это универсальный загрузчик.
	public partial class FormImport : FormFBA
    {
        private string fileType = "";              
        private System.Data.DataTable dt;
        private System.Data.DataTable importDT;
        bool loadStop = false;        
        string[] arrColumnType = new string[29];
       
	    /// <summary>
    	/// Конструктор.
    	/// </summary>
        public FormImport()
        {
            InitializeComponent();
            dt = new System.Data.DataTable("ImportSCV");
            this.btnStop.Click += delegate
            {
                loadStop = true;
            };
        }

        //Фалы для загрузки
        //E:\Мусор\Мусор Архив\Мусор 20\Не верный тип договора

        ///Добавление в лог.
        private void Log(string Mes)
        {
            tbLog.AppendText(sys.GetDateTimeLog() + ": " + Mes + Var.CR);
        }
        
        private void buttonFBA1_Click(object sender, EventArgs e)
        {
            ImportFile();
        }

        /// <summary>
        /// Загрузка файла.
        /// </summary>
        /// <returns>Возвращает успешность или нет загрузки файла.</returns>
        private bool ImportFile()
        {
            //Выбор файла загрузки.
            string fileName = tbFileName.Text;              
            if (!FBAFile.OpenFileName("Выбор файла для загрузки", "CSV Files|*.csv|Excel Files|*.xlsx|All Files|*.*", "", ref fileName)) return false;
            tbFileName.Text = fileName;
            //Загрузка возможно из двух типов файлов xlsx и csv.
            string EXT = System.IO.Path.GetExtension(fileName).ToUpper();
            if (EXT == ".XLSX")     fileType = "Excel";
            else if (EXT == ".CSV") fileType = "CSV";
            else
            {
                sys.SM("Импорт из этого типа файла не поддерживается!");
                return false; 
            }

            //Начать асинхронное добавление строк
            if (sys.IsEmpty(fileName)) return false;
          
            //HACK - для того чтобы не было ошибки вызова обновления прогресс бара. т.к. компанент создан не в том потоке.
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
           
            if (fileType == "CSV")   LoadCSV(fileName);
            if (fileType == "Excel") LoadXLSX(fileName);
         
            return true;
        }

        /// <summary>
        /// Действия, которые нужно совершить перед загрузкой CSV или Excel.
        /// </summary>
        private void BeginOfLoad()
        {
            Log("Начало загрузки.");
            dt.Rows.Clear();
            dt.Columns.Clear();
            DG1.DataSource = null;
            DG1.Columns.Clear();
            DG1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            DG1.Selection.EnableMultiSelection = true;           
            DG1.ClipboardMode = SourceGrid.ClipboardMode.All;            
            DG1.SuspendLayout();
            progressBarFBA1.Maximum = 10000;
            loadStop = false;
        }

        /// <summary>
        /// Действия, которые нужно совершить после загрузкой CSV или Excel.
        /// </summary>
        /// <param name="DateTime1"></param>
        private void EndOfLoad(DateTime DateTime1)
        {
            DG1.DataSource = new DevAge.ComponentModel.BoundDataView(dt.DefaultView);
            DG1.DataSource.AllowSort = false;
            DG1.ResumeLayout(); //DG1.RecalcCustomScrollBars(); 

            //Просто так для красоты, чтобы визуально весь прогресс бар заполнился.
            if (progressBarFBA1.Value < progressBarFBA1.Maximum - 1000)
            {
                progressBarFBA1.Value = progressBarFBA1.Maximum - 10;
                Thread.Sleep(100);
                progressBarFBA1.Value = progressBarFBA1.Maximum;
                Thread.Sleep(100);
            }

            progressBarFBA1.Value = 0;            
            DateTime dateTime2 = DateTime.Now;
            string timeDiff = sys.GetTimeDiff(DateTime1, dateTime2);
            Log("Окончание загрузки. Время загрузки: " + timeDiff + ". Строк: " + dt.Rows.Count.ToString() + " Колонок: " + dt.Columns.Count.ToString());
            if (loadStop) Log("Загрузка прервана пользователем.");
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = true;
            tabControl1.SelectedIndex = 1;
            DG1.Columns.AutoSizeView();
            for (int i = 0; i < DG1.Columns.Count; i++)
            {
                if (DG1.Columns[i].Width < 100) DG1.Columns[i].Width = 100;
            }
            //DG1.Columns.AutoSize(false);
        }

        /// <summary>
        /// Загрузка из CSV.
        /// </summary>
        /// <param name="FileName">Имя файла с полным путем к CSV файлу</param>
        private void LoadCSV(string FileName)
        {
            BeginOfLoad();
            DateTime dateTime1 = DateTime.Now;           
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);            
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1251));
            int columnsCount = 0; //Всего колонок в файле.
            string line;
            int lineNumber = 0;
            string[] arrLine;            
            
            //Код выполняется в отдельном потоке
            var task1 = Task.Factory.StartNew(() =>
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    arrLine = line.Split(';'); //массив строк
                    if (columnsCount == 0) columnsCount = arrLine.Length;                 
                    //Прерываем процесс загрузки, если пользователь нажал кнопку Stop.
                    if (loadStop) return;

                    if (lineNumber == 0)
                    {
                        for (int i = 0; i < arrLine.Length; i++)
                            if (arrLine[i] == "") arrLine[i] = "Column";                      
                        Arr.SetUniqValue(arrLine);
                        for (int i = 0; i < columnsCount; i++)
                        {                           
                            dt.Columns.Add(arrLine[i], typeof(string));
                        }
                        lineNumber++;
                        continue;
                    }

                    if (arrLine.Length != dt.Columns.Count) Array.Resize(ref arrLine, dt.Columns.Count);
                    dt.Rows.Add(arrLine);
                    lineNumber++;
                    if (lineNumber > 10000)
                    {
                        this.progressBarFBA1.Value = 0;
                    }
                    else progressBarFBA1.Value = lineNumber;
                    //Thread.Sleep(1000); //для теста.
                }
                sr.Close();
                fs.Close();
            });

            //После завершения обновляем GUI компаненты.
            var task2 = task1.ContinueWith((previous) =>
            {                
                EndOfLoad(dateTime1);
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return;
        }

        /// <summary>
        /// Загрузка из XSLX.  
        /// </summary>
        /// <param name="FileName">Имя файла с полным путем к XLSX файлу</param>
        private void LoadXLSX(string FileName)
        {
            BeginOfLoad();
            DateTime dateTime1 = DateTime.Now;
                        
            NPOI.XSSF.UserModel.XSSFWorkbook book = null; //Книга.
            NPOI.SS.UserModel.ISheet sheet = null;        //Лист.
            
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);            
                book = new NPOI.XSSF.UserModel.XSSFWorkbook(fs);
                if (fs != null) fs.Close();
            }
            catch (Exception ex)
            {
                sys.SM("Ошибка открытия файла шаблона: " + ex.Message);              
                return;
            }

            //Устанавливаем текущий лист.
            string errorMes = "";
            if (!sys.SetCurrentSheet(book, 1, true, out sheet, out errorMes)) return;

            string[] arrLine = null;  //= new string[sheet.LastCellNum + 1];          
            int columnsCount = 0;

            //Код выполняется в отдельном потоке
            var task1 = Task.Factory.StartNew(() =>
            {
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
                        if (loadStop) return;
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

                    if (row == sheet.FirstRowNum)
                    {
                        for (int i = 0; i < arrLine.Length; i++)
                            if (arrLine[i] == "") arrLine[i] = "Column";
                        Arr.SetUniqValue(arrLine); //Меняем название колонок, если они дублируются.
                        //Потому чтонельзя добавлять в dt колонки с одинаковым именем.
                        for (int i = 0; i < arrLine.Length; i++)
                        {                          
                            dt.Columns.Add(arrLine[i], typeof(string)); 
                        }
                    }
                    else dt.Rows.Add(arrLine);
                }
            });

            //После завершения обновляем GUI компаненты.
            var task2 = task1.ContinueWith((previous) =>
            {
                EndOfLoad(dateTime1);
            }, TaskScheduler.FromCurrentSynchronizationContext());
           
            return;
        }

        /// <summary>
        /// Проверка по всем условиям входящей загруженной DataTable - DT.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="importType"></param>
        /// <returns></returns>
        private bool CheckImport(System.Data.DataTable dt, string importType)
        {
            string sql = "SELECT * FROM fbaImport WHERE ImportType = '" + importType + "'";        
            sys.SelectDT(DirectionQuery.Remote, sql, out importDT);
            string errorMes = "";

            arrColumnType[0]  = "int";
            arrColumnType[1]  = "varchar";
            arrColumnType[2]  = "date";
            arrColumnType[3]  = "datetime";
            arrColumnType[4]  = "time";
            arrColumnType[5]  = "float";
            arrColumnType[6]  = "numeric";
            arrColumnType[7]  = "currency";
            arrColumnType[8]  = "regexpr";
            arrColumnType[9]  = "birthday";
            arrColumnType[10] = "fullname";
            arrColumnType[11] = "lastNameini";
            arrColumnType[12] = "inilastname";
            arrColumnType[13] = "inn";
            arrColumnType[14] = "kpp";
            arrColumnType[15] = "postcode";
            arrColumnType[16] = "mobilephone";
            arrColumnType[17] = "email";
            arrColumnType[18] = "filename";
            arrColumnType[19] = "fullfilename";
            arrColumnType[20] = "currncycode";
            arrColumnType[21] = "filename";
            arrColumnType[22] = "fullname";
            arrColumnType[23] = "dateinfuture";
            arrColumnType[24] = "dateinpast";
            arrColumnType[25] = "datework";
            arrColumnType[26] = "mobilephone";
            arrColumnType[27] = "phone";
            arrColumnType[28] = "age"; 

            if (!CheckColumns(out errorMes)) return false; //Это проверка набора колонок.
            if (!CheckRows(out errorMes)) return false; //Это проверка количестова строк.


            return true;
        }

        /// <summary>
        /// Проверка наличия колонок.
        /// </summary>
        /// <param name="errorMes">Список найденных ошибки</param>
        /// <returns>Если ошибок нет, то результат true</returns>
        private bool CheckColumns(out string errorMes)
        {
            errorMes = "";
            for (int i = 0; i < importDT.Rows.Count; i++)
            {
                string importColumnName       = importDT.Value("ColumnName");
                string importColumnObligatory = importDT.Value("ColumnObligatory");
                
                //Проверка на обязательность наличия колонки.
                if ((importColumnObligatory.ToInt() == 1) && (i >= dt.Columns.Count))
                {
                    errorMes = errorMes + "Ошибка. Отсутствует обязательная колонка " + importColumnName + Var.CR;
                    continue;
                }

                //Проверка на название колонки.
                string columnName = dt.Columns[i].Caption;
                if (columnName != importColumnName)
                {
                    errorMes = errorMes + "Ошибка. Колонка с номером " + i.ToString() + " должна иметь название " + importColumnName + Var.CR;
                    continue;
                }               
            }
            return (errorMes == "");
        }

        /// <summary>
        /// Получаем параметр. Он может быть в любой строке настроечной таблицы fbaImport, поэтому поиск повсем строкам.
        /// </summary>
        /// <param name="columnName">Имя колонки в настроечной таблице, в которой ищем значение</param>
        /// <param name="param">Значение параметра. Если не найдено, то пустая строка.</param>
        /// <returns>Если что-то найдено, то true</returns>
        private bool GetParam(string columnName, out string param)
        {
            param = "";
            for (int i = 0; i < importDT.Rows.Count; i++)
            {
                if (param == "") param = importDT.Value(columnName);
                if (param != "") break;
            }
            return (param != "");
        }


        /// <summary>
        /// Проверка на количество строк в загружаемом файле, максимальное и минимальное.
        /// </summary>
        /// <param name="errorMes">Список найденных ошибки</param>
        /// <returns>Если ошибок нет, то результат true</returns>
        private bool CheckRows(out string errorMes)
        {
            errorMes = "";
            string CountRowsMax = "";
            if (GetParam("CountRowsMax", out CountRowsMax))
            {
                if (CountRowsMax.ToInt() > dt.Rows.Count)
                {
                    errorMes = errorMes + "Ошибка. Количество строк в загружаемом файле не должно быть больше " + CountRowsMax + Var.CR;
                }
            }

            string countRowsMin = "";
            if (GetParam("CountRowsMin", out countRowsMin))
            {
                if (countRowsMin.ToInt() > dt.Rows.Count)
                {
                    errorMes = errorMes + "Ошибка. Количество строк в загружаемом файле не должно быть меньше " + countRowsMin + Var.CR;
                }
            }
            return (errorMes == "");
        }


        /// <summary>
        /// Проверка формата колонок.
        /// </summary>
        /// <param name="errorMes">Список найденных ошибки</param>
        /// <returns>Если ошибок нет, то результат true</returns>
        private bool CheckFormatColumns(out string errorMes)
        {
            //Копируем DataTable. Все операции будем производить с копией.
            System.Data.DataTable dt2 = sys.DataTable_To_DataTable(dt);

            errorMes = "";
            int columnCount = dt.Columns.Count;

            string[,] arrErrors = new string[dt.Rows.Count, dt.Columns.Count];


            for (int i = 0; i < importDT.Rows.Count; i++)
            {
                string columnType   = importDT.Value("ColumnType");
                string columnFormat = importDT.Value("ColumnFormat");
                string defaultValue = importDT.Value("DefaultValue");
                string tryParse     = importDT.Value("TryParse");
                string setValue     = importDT.Value("SetValue");
                string setCharCase  = importDT.Value("SetCharCase");
                string minValue     = importDT.Value("MinValue");
                string maxValue     = importDT.Value("MaxValue");
                string deleteChars  = importDT.Value("DeleteChars");
                string leaveChars   = importDT.Value("LeaveChars");

                //Это для ускорения работы, чтобы каждый раз не переводить minValue в дату для стравнения в цикле.
                DateTime minValueDate = DateTime.Now; //Это по умолчанию
                DateTime maxValueDate = DateTime.Now; //Это по умолчанию
                TimeSpan minValueTime = DateTime.Now.TimeOfDay; //Это по умолчанию
                TimeSpan maxValueTime = DateTime.Now.TimeOfDay; //Это по умолчанию

                if ((minValue != "") )
                {
                    if (columnFormat == "date") minValueDate = DateTime.ParseExact(minValue, "dd.MM.yyyy", null);
                    if (columnFormat == "time") minValueTime = TimeSpan.ParseExact(minValue, "hh:mm:ss", null);
                }

                if ((maxValue != "") )
                {
                    if (columnFormat == "date") maxValueDate = DateTime.ParseExact(maxValue, "dd.MM.yyyy", null);
                    if (columnFormat == "time") maxValueTime = TimeSpan.ParseExact(maxValue, "hh:mm:ss", null);
                }

                if (i >= columnCount) break;
               
                //Выходим, если в настроечной таблице, колонок больше, чем в проверяемой. например есть необязательные колонки.
                //Их нет, поэтому проверять нечего.
                if ((dt2.Columns.Count - 1) < i) break;
                
                //Одна колонка importDT соответствует одной колонке dt. Поэтому идем по значениям колонки dt.
                for (int j = 0; j < dt2.Rows.Count; j++)
                {                    
                    string value = dt2.Value(j, i);
                    string newvalue = "";
                    arrErrors[j, i] = CheckFormatValue(columnType, 
                                                      columnFormat,
                                                      defaultValue,
                                                      tryParse,
                                                      setValue,
                                                      setCharCase,
                                                      minValue,
                                                      maxValue,
                                                      minValueDate,
                                                      maxValueDate,
                                                      minValueTime,
                                                      maxValueTime,
                                                      deleteChars,
                                                      leaveChars,
                                                      value,
                                                      out newvalue);
                    if (newvalue != "") dt.Rows[j][i] = newvalue;
                }

            }
           
             return (errorMes == "");
        }
              
        /// <summary>
        /// Проверка формата значения в ячейке таблицы.
        /// </summary>
        /// <param name="сolumnType">Тип колонки</param>
        /// <param name="columnFormat">Детальная информация по формату колонки</param>
        /// <param name="defaultValue"></param>
        /// <param name="tryParse"></param>
        /// <param name="setValue"></param>
        /// <param name="setCharCase"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="minValueDate"></param>
        /// <param name="maxValueDate"></param>
        /// <param name="minValueTime"></param>
        /// <param name="maxValueTime"></param>
        /// <param name="deleteChars"></param>
        /// <param name="leaveChars"></param>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="newvalue"></param>
        /// <returns>Если ошибок нет, то возвращается пустая строка</returns>
        private string CheckFormatValue (string сolumnType, 
                                         string columnFormat,
                                         string defaultValue,
                                         string tryParse,
                                         string setValue,
                                         string setCharCase,
                                         string minValue,
                                         string maxValue,
                                         DateTime minValueDate,
                                         DateTime maxValueDate,
                                         TimeSpan minValueTime,
                                         TimeSpan maxValueTime,
                                         string deleteChars,
                                         string leaveChars,
                                         string value,
                                         out string newvalue)
        {
            
            newvalue = "";

            //Удалить символы из списка символов в deleteChars
            if (deleteChars != "")
            {
                //newvalue = sys.ReplaceCharInString
                value = newvalue;
            }
            //Удалить символы все символы в value, оставив только те, которые указаны в leaveChars.
            if (leaveChars != "")
            {

            }


            //Установка безусловного значения.
            if (setValue != "")
            {
                newvalue = setValue;
                value = newvalue;
            }

            //Установка значения по умолчанию.
            if ((value == "") && (defaultValue != ""))
            {
                newvalue = defaultValue;
                value = newvalue;
            }

            if (setCharCase != "")
            {
                if (setCharCase.ToUpper() == "UPPER") 
                {
                    newvalue = value.ToUpper();
                    value = newvalue;
                }
                if (setCharCase.ToUpper() == "LOWER")
                {
                    newvalue = value.ToLower();
                    value = newvalue;
                }
                if (setCharCase.ToUpper() == "FIRSTUPPER")
                {
                    newvalue = value.FirstCharsUpperOtherLower();
                    value = newvalue;
                }                
            }

            if ((сolumnType == "int") && (сolumnType == "age"))
            {
                int valueint;
                if (!int.TryParse(value, out valueint)) return "Ошибка. Должно быть целое число.";

                if (сolumnType == "age")
                {
                    if (valueint < 0)   return "Ошибка. Возраст не может быть отрицательным числом.";
                    if (valueint > 140) return "Ошибка. Возраст не может быть больше 140 лет.";
                    else if (valueint > 110) return "Предупреждение. Возраст больше 110 лет?";
                   
                }

                if (minValue != "")
                {
                    if (valueint < minValue.ToInt()) return "Ошибка. Значение меньше допустимого " + minValue;
                }

                if (maxValue != "")
                {
                    if (valueint > maxValue.ToInt()) return "Ошибка. Значение больше допустимого " + maxValue;
                }                            
            }

            if (сolumnType == "varchar")
            {        
                if (value.Length > columnFormat.ToInt()) return "Ошибка. Должно быть не более " + columnFormat + " символов";
            }

            if ((сolumnType == "date") || (сolumnType == "birthday"))
            {          
                string formatDate = sys.GetFormatDateTime(value, false);
                if (formatDate == "") return "Ошибка. Формат даты не определён";
                if ((formatDate != columnFormat) && (!tryParse.ToBool())) return "Ошибка. Неверный формат даты";

                if (formatDate != columnFormat)
                {
                    string newdate = value;
                    if (!sys.DateTimeConvertStr(ref newdate, formatDate, columnFormat))
                        return "Ошибка. Попытка преобразования формата даты не удалась";                   
                    newvalue = newdate;
                    value = newvalue;
                }

                if (minValue != "")
                {
                    if (сolumnType == "date")
                        if (DateTime.ParseExact(value, columnFormat, null) < minValueDate) return "Ошибка. Дата меньше допустимой " + minValue;
                    if (сolumnType == "birthday")
                        if (DateTime.ParseExact(value, columnFormat, null) < minValueDate) return "Ошибка. Дата рождения меньше допустимой " + minValue;

                }

                if (maxValue != "")
                {
                    if (сolumnType == "date")
                        if (DateTime.ParseExact(value, columnFormat, null) > maxValueDate) return "Ошибка. Дата больше допустимой " + maxValue;
                    if (сolumnType == "birthday")
                        if (DateTime.ParseExact(value, columnFormat, null) > maxValueDate) return "Ошибка. Дата рождения больше допустимой " + maxValue;

                }

                if (сolumnType == "birthday")
                {
                    DateTime dt1 = DateTime.ParseExact(value, columnFormat, null);
                    if (dt1 > DateTime.Now) return "Ошибка. Дата раждения не может быть в будущем";
                    if (dt1 < (DateTime.Now.AddYears(-110))) return "Предупреждение. Дата рождения более 110 лет назад";
                    if (dt1 < (DateTime.Now.AddYears(-140))) return "Ошибка. Дата рождения более 140 лет назад";
                }
            }

            if (сolumnType == "time")
            {
                string formatTime = sys.GetFormatDateTime(value);
                if (formatTime == "") return "Ошибка. Формат времени не определён";
                if (formatTime != columnFormat)
                {
                    string newdate = value;
                    if (!sys.TimeConvertStr(ref newdate, formatTime, columnFormat))
                        return "Ошибка. Попытка преобразования формата даты не удалась";
                    newvalue = newdate;
                    value = newvalue;
                }
               
                if (minValue != "")
                {
                    if (TimeSpan.ParseExact(value, columnFormat, null) < minValueTime) return "Ошибка. Время меньше допустимого " + minValue;
                }

                if (maxValue != "")
                {
                    if (TimeSpan.ParseExact(value, columnFormat, null) > maxValueTime) return "Ошибка. Время больше допустимого " + maxValue;
                }
            }
            

                
                return "";
        }


        //UpdateTotalRowCount(counter);
        //ar St = new StreamReader("file.txt", Encoding.GetEncoding(1251));
        //private bool AddStringToGrid(string[] ArrLine, int LineNumber)
        //{
        //Если это первая строка, то вставляем шапку в таблицу.
        //   if (LineNumber == 0)
        //   {
        //DG2.ColumnsCount = ArrLine.Length;
        //DG2.Rows.Insert(0);
        //      //DG2[0, i] = new SourceGrid.Cells.ColumnHeader(ArrLine[i]);
        //       for (int i = 0; i < ArrLine.Length; i++)
        //      {                    
        //           DT.Columns.Add(ArrLine[i], typeof(string));
        //       }
        //       return true;
        //   }

        // ensure that thread is aborted, when we exit the form before 
        // the thread exits

        // disable sorting before the data is loaded
        // start asynchronous row addition
        /*DG2.Rows.Insert(LineNumber);
        for (int i = 0; i < DG2.ColumnsCount; i++)
        {
            DG2[LineNumber, i] = new SourceGrid.Cells.Cell(ArrLine[i]);
        }*/
        //DG2.Rows.Add(ArrLine);



        //    return true;
        //}
        /*private static string ReadLine()
        {
            Stream inputStream = Console.OpenStandardInput(READLINE_BUFFER_SIZE);
            byte[] bytes = new byte[READLINE_BUFFER_SIZE];
            int outputLength = inputStream.Read(bytes, 0, READLINE_BUFFER_SIZE);
            //Console.WriteLine(outputLength);
            //char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
            //return new string(chars);
            //}
            //string input;
            //input.Split(';');//получили массив строк

            return "";
        }


        public virtual String ReadLine2()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                int ch = Read();
                if (ch == -1) break;
                if (ch == '\r' || ch == '\n')
                {
                    if (ch == '\r' && Peek() == '\n') Read();
                    return sb.ToString();
                } sb.Append((char)ch);
            }

            if (sb.Length > 0) return sb.ToString();
            return null;

        }*/




    }
}


/*
 * grid1.BorderStyle = BorderStyle.FixedSingle;

			grid1.ColumnsCount = 4;
			grid1.FixedRows = 1;
			grid1.Rows.Insert(0);

            SourceGrid.Cells.Editors.ComboBox cbEditor = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            cbEditor.StandardValues = new string[]{"Value 1", "Value 2", "Value 3"};
            cbEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick | SourceGrid.EditableMode.AnyKey;

			grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("String");
			grid1[0, 1] = new SourceGrid.Cells.ColumnHeader("DateTime");
			grid1[0, 2] = new SourceGrid.Cells.ColumnHeader("CheckBox");
            grid1[0, 3] = new SourceGrid.Cells.ColumnHeader("ComboBox");
            for (int r = 1; r < 10; r++)
			{
				grid1.Rows.Insert(r);
				grid1[r, 0] = new SourceGrid.Cells.Cell("Hello " + r.ToString(), typeof(string));
				grid1[r, 1] = new SourceGrid.Cells.Cell(DateTime.Today, typeof(DateTime));
				grid1[r, 2] = new SourceGrid.Cells.CheckBox(null, true);
                grid1[r, 3] = new SourceGrid.Cells.Cell("Value 1", cbEditor);
                grid1[r, 3].View = SourceGrid.Cells.Views.ComboBox.Default;
            }

            grid1.AutoSizeCells();
 */
