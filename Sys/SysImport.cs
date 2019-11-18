using NPOI.SS.UserModel;
using System;
using System.Linq;
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
//CheckExistsParam1   - Простая проверка по наличию значения. Допустимые значения: table или entity. 
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
    /// <summary>
    /// Класс для всех импортов файлов. От него можно наследоваться и создаать свои индивидуальные импорты.
    /// </summary>
    public class SysImport
    {        
        /// <summary>
        /// Количество ошибок
        /// </summary>
    	public int ErrorCount = 0;     
    	
    	/// <summary>
    	/// Тестовый режим. Замедляет вывод.
    	/// </summary>
        public bool Test                    = false; 
        
        /// <summary>
        /// Форма прогресс бара
        /// </summary>
        public FormProgress Progress        = null;  
        
        /// <summary>
        /// Количество заполненных строк в массиве
        /// </summary>
        public int BookmarkCount = 0;    
        
        /// <summary>
        /// Показывать или нет сообщения об ошибках
        /// </summary>
        public bool ShowError = true; 
        
        //Далее параметры  Excel          

		/// <summary>
        /// Книга
        /// </summary>       
        public NPOI.XSSF.UserModel.XSSFWorkbook book = null; 
        
        /// <summary>
        /// Текущий лист
        /// </summary>
        public NPOI.SS.UserModel.ISheet         sheet = null; 
        
        /// <summary>
        /// Имя листа Excel, откуда импортируем
        /// </summary>
        public string CurrentSheetName;    
     
        /// <summary>
        /// Конструктор. 
        /// </summary>
        public SysImport()
        {
           
        }

        ///Поиск местоположения закладок во всей книге.
        private bool ParseTemplate(out int BookmarkCount)
        {
            BookmarkCount = 0;
            for (int nSheet = 0; nSheet < book.NumberOfSheets; nSheet++)
            {
                if (!SetCurrentSheet(nSheet)) return false;
                //запускаем цикл по строкам
                for (int row = 0; row <= sheet.LastRowNum; row++)
                {
                    //получаем строку
                    var currentRow = sheet.GetRow(row);
                    if (currentRow == null) continue; //null когда строка содержит только пустые ячейки

                    //запускаем цикл по столбцам
                    for (int col = currentRow.FirstCellNum; col < currentRow.LastCellNum; col++)
                    {
                        //получаем значение яейки
                        var currentCell = currentRow.GetCell(col);
                        if (currentCell == null) continue;
                        NPOI.SS.UserModel.CellType ctype = currentCell.CellType;
                        if (ctype != CellType.String) continue;
                        string Value = currentCell.StringCellValue.ToString();
                        if (Value.IndexOf("Bookmark_") != 0) continue;
                        //Bookmarks[BookmarkCount, 0] = BookmarkCount.ToString();
                        //Bookmarks[BookmarkCount, 1] = sheet.SheetName;
                        //Bookmarks[BookmarkCount, 2] = Value;
                        //Bookmarks[BookmarkCount, 3] = row.ToString();
                        //Bookmarks[BookmarkCount, 4] = col.ToString();
                        BookmarkCount++;
                    }
                }
            }

            //sys.ArrayView("Bookmarks", "Value", Bookmarks);
            return true;
        }        
        
        #region Region. Вспомогательные функции.
            
        /// <summary>
        /// Команда установки текущего листа по индексу листа.
        /// </summary>
        /// <param name="SheetIndex">Индекс листа</param>
        /// <returns>Успешно, если true</returns>
        public bool SetCurrentSheet(int SheetIndex)
        {
            string ErrorMes = "";
            if (SheetIndex > book.NumberOfSheets)
                ErrorMes = "Указан неверный порядковый номер листа: " + SheetIndex.ToString() +
                           ". Количество листов в книге всего: " + book.NumberOfSheets.ToString();
            if (book == null)
                ErrorMes = "Книга не создана!";

            if (ErrorMes != "")
            {
                ErrorCount++;
                if (ShowError) sys.SM(ErrorMes);
                return false;
            }
            sheet = book.GetSheetAt(SheetIndex);
            CurrentSheetName = sheet.SheetName;
            return true;
        }
              
        /// <summary>
        /// Команда установки текущего листа по имени листа
        /// </summary>
        /// <param name="SheetName">Имя листа</param>
        /// <returns></returns>
        public bool SetCurrentSheet(string SheetName)
        {
            string ErrorMes = "";
            if (book == null)
                ErrorMes = ErrorMes = "Книга не создана!";
            if (ErrorMes != "")
            {
                ErrorCount++;
                if (ShowError) sys.SM(ErrorMes);
                return false;
            }
            sheet = book.GetSheet(SheetName);
            if (sheet == null)
            {
                ErrorCount++;
                if (ShowError) sys.SM("Указано неверное имя листа: " + SheetName);
                return false;
            }
            CurrentSheetName = sheet.SheetName;
            return true;
        }     

        #endregion Region. Вспомогательные функции. 
    }
}
