/* Пользователь: Travin
 * Дата: 13.01.2018
 * Время: 12:11
*/
 
using System; 
using System.Collections.Generic;    
//using System.Data;
//using System.Diagnostics; 
//using System.Linq;
//using System.Text;
//using System.Globalization;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;    
   
   
namespace FBA
{           
    #region Region. Типы атрибутов.
    
    //Attr_Type = 1 - (Поле,      Field)   Поле
    //Attr_Type = 2 - (Ссылка,    Link)    Ссылка
    //Attr_Type = 3 - (УниСсылка, UniLink) Универсальная ссылка
    //Attr_Type = 4 - (Массив,    Array)   Массив
    
    //Attr_Kind = 1 - (Простой,   Simple)  Атрибут из базы данных
    //Attr_Kind = 2 - (Системный, System)  Системный
    //Attr_Kind = 3 - (Вычисляемый, Calc)  Вычисляемый
    
    #endregion Region. Типы атрибутов.
    
    /// <summary>
 	/// Тип входа в систему
 	/// </summary>
	public enum ParserEnterMode
	{
	    /// <summary>
	    /// Рабочий режим. Все модули берутся из полей fbaProject которые относятся к рабочей версии 
	    /// </summary>
		Work,
		
		/// <summary>
	    /// Тестовый режим. Все модули берутся из полей fbaProject которые относятся к тестовой версии 
	    /// </summary>
	    Test,
	    
	    /// <summary>
	    /// Разработка. Все модули берутся только с локального компьютера, к БД обращений не происходит.
	    /// </summary>
	    Develop
	} 
    
    
    public static class ParserCon
    {                              
    	#region Region. Подключение из Assembly SQL сервера.
        
        ///Это в том случае, если подключение производится из сборки assembly в самом SQL сервере.
        ///Выполнение запроса SQL. Результат запросов на клиент не возвращается.
        public static void PipeExecute(string SQL)
        {
            using (var connection = new SqlConnection("context connection=true"))
            {        
                SqlCommand command = connection.CreateCommand();
                command.CommandText = SQL; //"SELECT * FROM Devices WHERE ShopId = @shopId;";               
                //SqlParameter parameter = new SqlParameter("@shopId", SqlDbType.Int);               
                //parameter.Value = shopId;
                //command.Parameters.Add(parameter);               
                connection.Open();
                SqlContext.Pipe.ExecuteAndSend(command);             
            }           
        }
        
        ///Это в том случае, если подключение производится из сборки assembly в самом SQL сервере.      
		///В результате выполнения на клиент вернётся массив таблиц.        
        [SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
        public static bool PipeSelectDS(string SQL, out System.Data.DataSet DS)
        {
            using (SqlConnection connection = new SqlConnection("context connection=true"))
            {                                  
                DS = new System.Data.DataSet();
                var da = new SqlDataAdapter(SQL, connection); 
                da.Fill(DS);                                              
            }
            return true;
        }
                    
        ///Это в том случае, если подключение производится из сборки assembly в самом SQL сервере.  
		///В результате выполнения на клиент вернётся одна таблица.                 
        [SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
        public static bool PipeSelectDT(string SQL, out System.Data.DataTable DT)
        {
            using (SqlConnection connection = new SqlConnection("context connection=true"))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = SQL;                             
                var DS = new System.Data.DataSet();
                var da = new SqlDataAdapter(SQL, connection); 
                da.Fill(DS);   
                DT = DS.Tables[0];                                  
            }
            return true;
        }  
       
        #endregion Region. Подключение из Assembly SQL сервера.
        
        #region Region. Подключение из внешней программы.
                
        ///Это в том случае, если подключение производится из другого приложения уже имеющего подключение к БД.
        //public static bool SelectDS(SqlConnection connection, string SQL, out System.Data.DataSet DS)
        //{                           
        //    DS = new System.Data.DataSet();              
        //    var da = new SqlDataAdapter(SQL, connection);             
        //    da.Fill(DS);                                                          
        //    return true;
        //}
       
        ///Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataSet. Возвращает несколько таблиц.               
        public static bool SelectDS(string SQL, out System.Data.DataSet DS, out string ErrorText, bool ErrorShow)
        {           
            DS = new System.Data.DataSet("DS");
            ErrorText = "";
            const string ServerName    = "Srv1";
            const string DatabaseLogin = "c1login";
            const string DatabasePass  = "gert6r5IM";
            const string DatabaseName  = "test1";                
            if ((SQL == "") || (SQL == "Empty")) return false;          
            try
            {                                
                System.Data.SqlClient.SqlConnection ConnectionParserRemote = null;
                ConnectionParserRemote = new System.Data.SqlClient.SqlConnection("Server=" + ServerName + ";User Id=" + DatabaseLogin + ";Password=" + DatabasePass + ";Database=" + DatabaseName + ";"); //Connection Timeout=2; 
                ConnectionParserRemote.Open();
                var da = new SqlDataAdapter(SQL, ConnectionParserRemote);
                da.Fill(DS);                                                   
                return true;               
            }
            catch (Exception e)
            {               
                ErrorText = "704. Ошибка выполнения запроса: " + ErrorText + ParserSys.CR + e.Message + ParserSys.CR + SQL; 
                if (ErrorShow) ParserSys.ParserSM(ErrorText);                      
                DS = null;
                return false;               
            }
        }    

        
        //Это в том случае, если подключение производится из другого приложения уже имеющего подключение к БД. 
        //public static bool SelectDT(SqlConnection connection, string SQL, out System.Data.DataTable DT)
        //{                                              
        //    var DS = new System.Data.DataSet();
        //    var da = new SqlDataAdapter(SQL, connection); 
        //    da.Fill(DS);                            
        //    DT = DS.Tables[0];                                              
        //    return true;
        //} 
                         
        #endregion Region. Подключение из внешней программы.        
    }
               
    ///Вспомогательные методы. Перенесены из sys.
    public static class ParserSys
    {
        public const string CR = "\r\n";    //Перенос строки
                     
        ///Количество символа chr в строке.
        public static int ParserCountChar(this string InputStr, char chr)
        {               
            return InputStr.Split(chr).Length - 1;   
        } 
        
        ///Возвращает строку, которая следует до строки BeginStr.
        ///Если BeginStr не найден, то возвращается исходная строка.         
        public static string ParserStrBeforeStr(this string InputStr, string BeginStr)
        {                          
            int N = InputStr.IndexOf(BeginStr, StringComparison.OrdinalIgnoreCase);
            if (N == -1) return InputStr;
            return InputStr.Substring(0, N);
        }
        
        ///Конвертирование одного формата даты-времени к другому. Работает, но не используем.
        ///Пример: string str2 = str1.DateTimeConvertStr("24.03.2017", "yyyy-MM-dd HH:mm:ss.fff");
        //public static string ParserDateTimeConvertStr(string Value, string FormatIN, string FormatOUT)
        //{                                           
        //    if (Value == "") return Value;
        //    if (FormatIN == "") return Value;         
        //    CultureInfo provider = CultureInfo.InvariantCulture;
        //    DateTime dt = DateTime.ParseExact(Value, FormatIN, provider);      //01/02/2014  //dd/MM/yyyy
        //    return dt.ToString(FormatOUT);                                             
        //} 
        
        ///Конвертирование одного формата даты-времени к другому.
        ///Пример: string str2 = str1.DateTimeConvertStr("24.03.2017", "yyyy-MM-dd HH:mm:ss.fff");
        public static string ParserDateTimeConvertStr(string Value, string FormatIN, bool EndDay)
        {                                           
            if (Value    == "") return Value;
            if (FormatIN == "") return Value;         
            string YearStr  = "";
            string MonthStr = "";
            string DayStr   = "";
   
            if ((FormatIN == "yyyy.MM.dd") || (FormatIN == "yyyy/MM/dd") || (FormatIN == "yyyy-MM-dd"))
            {
                YearStr  = Value.Substring(0, 4);
                MonthStr = Value.Substring(5, 2);
                DayStr   = Value.Substring(8, 2);
            } else
            if ((FormatIN == "dd.MM.yyyy") || (FormatIN == "dd/MM/yyyy") || (FormatIN == "dd-MM-yyyy"))
            {
                YearStr  = Value.Substring(6, 4);
                MonthStr = Value.Substring(3, 2);              
                DayStr   = Value.Substring(0, 2);
            }  else return Value;
            
            if (EndDay) return YearStr + "-" + MonthStr + "-" + DayStr + " 23:59:59";
            return YearStr + "-" + MonthStr + "-" + DayStr + " 00:00:00";           
        } 
        
        //Конвертирование форматов дат для запросов SQL: 
        //24.03.2017
        //24-03-2017
        //24/03/2017
        //2017-03-24
        //2017/03/24
        //2017.03.24          
        //Если AddQuote = true будут добавлены кавычки. Во входящей строке также кавычки могут быть, а могут и отсутствовать.
        public static string ParserConvertDate4Server10(this string Value, bool AddQuote, bool EndDay, out bool ResultConvert)
        {
            ResultConvert = false;           
            if (Value == "") return Value;
            if ((Value.Length > 12) || (Value.Length < 10)) return Value;                      
            string ValueNew;
            if ((Value.ParserLeft(1) == "'") && (Value.ParserRight(1) == "'")) 
                ValueNew = Value.Substring(1, Value.Length - 2);           
            else ValueNew = Value;
            if (ValueNew.Length != 10) return Value;                     
            string FormatIN = ParserGetFormatDate10(ValueNew);
            if (FormatIN == "") return Value;                 
            string Quote = "";
            if (AddQuote) Quote = "'";
            ResultConvert = true;
            return Quote + ParserDateTimeConvertStr(ValueNew, FormatIN, EndDay) + Quote;     
        }   
        
                                     
        ///Проверка на то что строка является датой.
        public static bool ParserIsDate(this string InputStr)
        {
            DateTime dt;          
            return DateTime.TryParse(InputStr, out dt);    
        }
        ///Получаем формат даты, если длина строки даты 10 символов.
        ///Формат один из: yyyy.MM.dd или dd.MM.yyyy.
        ///Вместо точки также может быть - или /.
        public static string ParserGetFormatDate10(string Value)
        {
            if (Value == "") return "";
            if (Value.Length != 10) return "";
            if (!Value.ParserIsDate()) return "";
            string FormatIN = "";
             
            if      ((Value[4] == '.') && (Value[7] == '.')) FormatIN = "yyyy.MM.dd";
            else if ((Value[4] == '/') && (Value[7] == '/')) FormatIN = "yyyy/MM/dd";            
            else if ((Value[4] == '-') && (Value[7] == '-')) FormatIN = "yyyy-MM-dd";
            
            else if ((Value[2] == '.') && (Value[5] == '.')) FormatIN = "dd.MM.yyyy";
            else if ((Value[2] == '/') && (Value[5] == '/')) FormatIN = "dd/MM/yyyy";
            else if ((Value[2] == '-') && (Value[5] == '-')) FormatIN = "dd-MM-yyyy";                                                            
            
            if (FormatIN == "") return "";  
            return FormatIN;
            
        }
        
        ///Для типа STRING. Функция заменяет в строке символ в позиции Index на ch. Не протестировано.
        //public static string ParserReplaceCharInString(this string InputStr, int Index, char ch)
        //{             
        //     var builder = new StringBuilder(InputStr); 
        //     builder[Index] = ch;
        //     return builder.ToString();
             //Вероятно это будет медленнее:
             //return InputStr.Remove(Index, 1).Insert(Index, ch.ToString());               
        //}
        
        ///Проверка, что строка является числом INT.
        public static bool ParserIsInteger(string NumberStr, out int NumberInt)
        {           
            if (!int.TryParse(NumberStr, out NumberInt)) return false;
            return true;
        } 
        
        ///Для типа STRING. Функции LEFT() до указанной подстроки.
        public static string ParserLeft(this string InputStr, string BeginStr)
        {          
            int k = InputStr.IndexOf(BeginStr, StringComparison.OrdinalIgnoreCase);
            if (k > -1) return InputStr.Substring(0, k);
                else return "";
        }
        
        ///Для типа STRING. Аналог функции LEFT() в SQL.
        public static string ParserLeft(this string InputStr, int MaxLength)
        {
            //Вызывать можно так: string ss = ss.Left(10); (во всех сборках, где подключен sys). 
            if (string.IsNullOrEmpty(InputStr)) return InputStr;
            MaxLength = Math.Abs(MaxLength);   
            return (InputStr.Length <= MaxLength ? InputStr : InputStr.Substring(0, MaxLength));            
        }
        
        ///Для типа STRING. Последние CountChar символов.
        public static string ParserRight(this string InputStr, int CountChar)
        {      
            int N = InputStr.Length;
            if (CountChar > N) CountChar = N;
            return InputStr.Substring(N - CountChar);  
        }
        
        ///Для типа STRING. Замена подстроки без учета регистра. Работает, но ОЧЕНЬ медленно.
        public static string ParserReplaceIgnoreCase(this string InputStr, string OldStr, string NewStr)
        {                         
            int i = InputStr.IndexOf(OldStr, StringComparison.OrdinalIgnoreCase);
            if (i == -1) return InputStr;
            int N = OldStr.Length;         
            while (i > -1) 
            {
                InputStr = InputStr.Remove(i, N);
                InputStr = InputStr.Insert(i, NewStr);
                i = InputStr.IndexOf(OldStr, StringComparison.OrdinalIgnoreCase);
            }
            return InputStr;             
        } 
        
        //Добавить перенос строки справа, если строка не пустая.
        public static void ParserAddRightCR(ref string InputStr)
        {
            if (InputStr == null) return;
            if (InputStr == "") return;
            InputStr = InputStr + ParserSys.CR;
        }
                  
        ///Для типа STRING. Функции ToInt(). 
        public static int ParserToInt(this string InputStr)
        {          
            int num;
            if (!int.TryParse(InputStr, out num)) return 0;
            return num;                      
        }          
        
        ///двумернЫЙ массив. Массив преобразовать в DataTable. ColumnCaption - через точку с запятой. Max = 0, значит все. ShowNum - показывать порядковый номер строки.  
        public static bool ParserArrayToDT(string[,] ar2, string ColumnsCaption, out System.Data.DataTable DT, int MaxX, int MaxY, bool ShowNum)
        {                                                                                         
            DT = new System.Data.DataTable();  
            if (MaxY < 1) MaxY = ar2.GetLength(0);
            if (MaxX < 1) MaxX = ar2.GetLength(1);
            if (ColumnsCaption.Length == 0)
            {
                for (int i = 0; i < MaxX; i++) DT.Columns.Add("Column" + (i + 1));
            } else
            {                    
                string [] Cap = ColumnsCaption.Split(';');                                               
                for (int i = 0; i < MaxX; i++) 
                {
                    string ColCap = "";
                    if (Cap.Length > i) ColCap = Cap[i]; else ColCap =  "Column" + i.ToString();
                    //if (ColCap == "") sys.SM("Error - Column " + i.ToString());
                    DT.Columns.Add(ColCap);
                }
            }
            int N = 0;
            if (ShowNum) N = 1;                
            try
            {
                var word = new string[MaxX + N];             
                for (int i = 0; i < MaxY; i++)
                {                
                    if (ShowNum) word[0] = i.ToString();
                    for (int j = 0; j < MaxX; j++) word[j + N] = ar2[i,j];
                    System.Data.DataRow row = DT.NewRow();
                    row.ItemArray = word;
                    DT.Rows.Add(row);
                }   
                return true;
            } catch (Exception ex)
            {
                ParserSys.ParserSM(ex.Message);
                return false;
            }                                  
        }
        
        ///Сохранение DataTable, DataGridView в двумерный массив строк.
        public static bool ParserArrayFromDT(System.Data.DataTable DT, out string[,] ar)
        {                 
            ar = new string[DT.Rows.Count, DT.Columns.Count];  
            for (int i = 0; i < DT.Rows.Count; i++)
                for (int j = 0; j < DT.Columns.Count; j++)         
                { 
                   ar[i, j] = DT.Rows[i][j].ToString();
                }                     
            return true;            
        }          
        
        ///Метод возврвщает конец текущего дня. Пример: 20170811 23:59:59
        public static string ParserGetDateEndDay()
        {
            DateTime LocalDate = DateTime.Now;
            return LocalDate.Year.ToString() + "-" + LocalDate.Month.ToString("D2") + "-" + LocalDate.Day.ToString("D2") + " 23:59:59";
        }
               
        ///Повторить строку count раз.  
        public static string ParserRepeatString (this string InputStr, int count)
        {
            if (count == 0) return "";           
            string InputStrNew = InputStr;
            for (int i = 1; i < count; i++)
            {
                InputStrNew = InputStrNew + InputStr;
            }
            return InputStrNew;         
        } 
               
        ///Если исходная строка содержится в Value, возвращает true.
        public static bool ParserInStr(this string InputStr, string Value)
        {            
            if (Value == "") return true;
            return Value.IndexOf(InputStr, StringComparison.OrdinalIgnoreCase) > -1;
        }   
        
        ///Если Value содержится в исходной строке, возвращает true.
        public static bool ParserIndexOfBool(this string InputStr, string Value)
        {            
            return (InputStr.IndexOf(Value, StringComparison.OrdinalIgnoreCase) > -1);
        }
               
        ///Получить номер последней строки (нумерация от нуля), в которой заполен первый столбец двумерного массива.
        public static int ParserGetNextEmptyRow(string[,] Arr)
        {
            int Arr_Y = Arr.GetLength(0);
            for (int i = 0; i < Arr_Y; i++)
                if  ((Arr[i, 0] == "") || (Arr[i, 0] == null)) return i;
            return Arr_Y;
        }
        
        ///Добавление двумерного массива ArrSource[Y, X] к двумерному массиву Arr1[Y, X], результат в новом массиве ArrResult. Оба массива должны иметь один размер по X.
        ///ArrSource_MaxRows = -1 значит все. 0 (по умолчанию) значит автоматически определить сколько строк заполенно по первому столбцу.
        public static bool ParserArrayAdd(string[,] ArrSource, string[,] Arr, int ArrSource_MaxRows = 0)
        {                              
            int ArrSource_X = ArrSource.GetLength(1);
            int ArrSource_Y = ArrSource_MaxRows;
            if (ArrSource_Y == -1) ArrSource.GetLength(0);
            if (ArrSource_Y == 0) ArrSource_Y = ParserGetNextEmptyRow(ArrSource);
            int Arr_X = Arr.GetLength(1);  
            int Arr_Y = ParserGetNextEmptyRow(Arr);            
            if (ArrSource_X != Arr_X) return false;
                                                       
            //Добавляем второй массив в результат.
            int N = Arr_Y;
            for (int i = 0; i < ArrSource_Y; i++)
            {
                for (int j = 0; j < ArrSource_X; j++) 
                    Arr[N, j] = ArrSource[i, j];
                N++;
            }
            return true;
        }                
        
        ///Если Value содержится в исходной строке, возвращает true.
        public static int ParserIndexOfEx(this string InputStr, string Value)
        {            
            return InputStr.IndexOf(Value, StringComparison.OrdinalIgnoreCase);                    
        }  
        
        ///Для типа STRING. Нормальный SubString, как в Delphi, можно указывать Length, превышающую длину InputStr.
        public static string ParserSubStringEnd(this string InputStr, int FirstChar, int Length = 0)
        {
            //Вызывать можно так: string ss = ss.SubStringEnd(1, 100000);
            //if (InputStr == null) return "";
            if (FirstChar >= InputStr.Length) return "";
            if (Length == 0) Length = InputStr.Length - FirstChar;
            else if ((FirstChar + Length) > InputStr.Length) Length = InputStr.Length - FirstChar;
            return InputStr.Substring(FirstChar, Length);                         
        }                      
        
        ///Показ сообщения.
        public static void ParserSM(string Mes)
        {
            //sys.SM(Mes);
        }
        
        //Показ сообщения.
        //public static void ParserSM2(string Mes)
        //{
        //    sys.SM(Mes);
        //}
        
    }         
    
    ///Статический класс. Константы парсера.
    public static class ParserData
    {                                                                   
        #region Region. Константы и переменные. 
  
        //Входные таблицы:
        //Константы для массива arEntity.
        public const int nPos                 = 0;
        public const int nID                  = 1;
        public const int nEntityID            = 2;
        public const int nName                = 3;
        public const int nBrief               = 4;
        public const int nParentID            = 5;
        //public const int nClassKey            = 6;
        public const int nFeature             = 7;
        public const int nDescription         = 8;
        //public const int nSecurityDataClassId = 9;
        public const int nTable_ID            = 10;
        public const int nTable_Name          = 11;
        public const int nTable_IDFieldName   = 12;                       
        
        //Константы для массива arAttrParent.
        public const int aPos                 = 0;
        public const int aNumLevel            = 1;
        public const int aID                  = 2;
        public const int aEntityID            = 3;  
        public const int aAttr_EntityID       = 4;  
        public const int aAttr_Name           = 5;  
        public const int aAttr_Brief          = 6;
        public const int aAttr_Type           = 7;
        public const int aAttr_Kind           = 8;
        public const int aAttr_Mask           = 9;
        public const int aAttr_Feature        = 10;
        public const int aAttr_NameOrder      = 11;
        public const int aAttr_Code           = 12;
        public const int aAttr_Comment        = 13;
        public const int aTable_ID            = 14;
        public const int aTable_Field         = 15;
        public const int aTable_Field2        = 16;
        public const int aRef_EntityID        = 17;
        public const int aRef_AttrID          = 18;
        public const int aTable_Name          = 19;
        public const int aTable_IDFieldName   = 20;
        public const int aTable_Type          = 21;
        public const int aTable_Feature       = 22;
        public const int aRef_EntityBrief     = 23;
        public const int aRef_AttrBrief       = 24;
        public const int aRef_AttrName        = 25;
        public const int aAttr_EntityBrief    = 26;
        public const int aEnChildID           = 27;
        public const int aEnBrief2            = 28;
        public const int aEnID                = 29;
        public const int aEnBrief1            = 30;
        public const int aParentID            = 31;       
        public const int EnBriefName2         = 32;
        public const int EnBriefName1         = 33;       
        public const int aEnBrief2_TableName        = 33;
        public const int aEnBrief2_TableIDFieldName = 35;
        public const int aEnBrief1_TableName        = 36;
        public const int aEnBrief1_TableIDFieldName = 37;                
        
        //Таблицы для парсинга:
        //Константы для массива Words.               
        public const int wPos                 = 0;        
        public const int wLex                 = 1;  //Слово.
        public const int wDOCR                = 2;  //Перенос строк. Место, где переносить на следующую строку готовый запрос. 
        public const int wReadySQL            = 3;  //Готовая строка SQL для сборки полного текста SQL.        
        public const int wBrace               = 4;  //Скобка.
        public const int wBraceLevel          = 5;  //Уровень вложенности скобки.
        public const int wBraceNum            = 6;  //Номер вложенности скобкок.    
        public const int wSelect              = 7;  //Номер вложенности скобкок.
        public const int wBlockEnd            = 8;  //Конец блока (SELECT, TOP, FROM, WHERE, ORDER BY, GROUP BY.
        public const int wBlockWhere          = 9;  //Если 1 то мы в блоке WHERE. Определяется чтобы алиасы не добавлять в блоке WHERE.
        public const int wBlockFunc           = 10; //Если 1 то мы в блоке FROM.       
        public const int wBlockCase           = 11; //Если 1 то мы в блоке CASE.       
        public const int wProc                = 12; //Колонка только для разработки и отладки. Позже нужно удалить.
        public const int wLexType             = 13; //Тип лексемы.    
        public const int wAlias               = 14; //Алиас для атрибута или сущности.         
        public const int wEntity              = 15; //Первая сущность составного атрибута. 
        public const int wEntityAlias         = 16; //Это алиас сущности к которой отнсится первый атрибут. 
        public const int wEntityID            = 17; //
        public const int wTableName           = 18; //Таблица для сущности (главная) или таблица одиночного атрибута.
        public const int wTableField          = 19; //Поле в таблице для атрибута. 
        public const int wTableField2         = 20; //Поле2 в таблице для атрибута.           
        public const int wTableFieldID        = 21; //Поле ID в таблице Table. 
        public const int wTableType           = 22; //Тип таблицы.
        public const int wTableAlias          = 23; //Алиас таблицы. 
        public const int wFirstAttrType       = 24; //C чего начинается атрибут. 0 - не определено (ошибка), 1 - начинается с алиаса, 2 начинается с сокращения сущности.
        public const int wAttrComplex         = 25; //Является реально составным атрибутом (т.е. есть одна точка и более, и она не для отделения алиаса от атрибута). 
        public const int wAttrFirst           = 26; //Первая часть составного атрибута, нужна чтобы иметь точку начала разбора состанвного атрибута (с чего начать).
        public const int wAttrFull            = 27; //Полный составной атрибут, без алиса.        
        public const int wAttrType            = 28; //Тип атрибута
        public const int wAttrKind            = 29; //Вид атрибута
        public const int wAttrCode            = 30; //Код вычисляемого атрибута.        
        public const int wUserString          = 31; //Пользовательская стрка в исходном запросе.
        public const int wStateDate           = 32; //Дата состояния для сущности.
        public const int wRef_EntityBrief     = 33; //На что ссылается первый атрибут в сосоавном атрибуте.
        public const int wCompareDotLevel     = 34; //Точка в составном атрибуте, начиная с которой, составной атрибут начинается отличаться от предыдущего составного атрибута.
        public const int wCompareDotNum       = 35; //Не используется.

        
        //Ключевые слова.
 		public static class KeyBrief
        {            
            public static string ObjectID        = "ObjectID";
            public static string EntityID        = "EntityID";
            public static string EntityBrief     = "EntityBrief";
            public static string EntityName      = "EntityName";
            public static string ObjectStateDate = "ObjectStateDate";
            public static string ObjectName      = "ObjectName";
            public static string EntityAlias     = "EntityAlias";       
            public static string AttrStateDate   = "AttrStateDate";            
        };

        //Ключевые слова.
        public static class KeyBriefUpper
        {
            public static string ObjectID      = "OBJECTID";
            public static string EntityID      = "ENTITYID";
            public static string EntityBrief   = "ENTITYBRIEF";
            public static string EntityName    = "ENTITYNAME";
            public static string StateDate     = "STATEDATE";
            public static string ObjectName    = "OBJECTNAME";
            public static string EntityAlias   = "ENTITYALIAS";         
            public static string AttrStateDate = "ATTRSTATEDATE";
        };

        //Ключевые слова.
        public static class KeyName
        {
            public static string ObjectID      = "Object ID";
            public static string EntityID      = "Entity ID";
            public static string EntityBrief   = "Entity Brief";
            public static string EntityName    = "Entity Name";
            public static string StateDate     = "State Date";
            public static string ObjectName    = "Object Name";
            public static string EntityAlias   = "Entity Alias";            
            public static string AttrStateDate = "Attr State Date";
        };

        //Таблица лексем.                     
        public static string[,] LexTable =       
        {
            {"1",  "SELECT",            "ВЫБРАТЬ",          "KEY"},
            {"2",  "FROM",              "ИЗ",               "KEY"},
            {"3",  "WHERE",             "ГДЕ",              "KEY"},
            {"4",  "GROUP BY",          "ГРУПП",            "KEY"},
            {"5",  "ORDER BY",          "УПОРЯД",           "KEY"},
            {"6",  "ASC",               "ВОЗР",             "KEY"},
            {"7",  "DESC",              "УБЫВ",             "KEY"},
            {"8",  "FOR",               "ДЛЯ",              "KEY"},
            {"9",  "LIKE",              "ПОДОБНО",          "KEY"},
            {"10", "AND",               "",                 "KEY"},
            {"11", "BETWEEN",           "МЕЖДУ",            "KEY"},
            {"12", "UNION",             "ОБЪЕДИНИТЬ",       "UNION"},
            {"13", "UNION ALL",         "ОБЪЕДИНИТЬ ВСЕ",   "UNION"},
            {"14", "HAVING",            "",                 "KEY"},
            {"16", "OVER",              "",                 "KEY"},
            {"17", "INTO",              "",                 "KEY"},             
            {"18", "TOP",               "ПЕРВЫЕ",           "KEY"},
            {"19", "WITH",              "ВМЕСТЕ",           "KEY"},
            {"20", "DROP TABLE",        "DROP TABLE",       "KEY"},
            //{"20", "SUM",               "СУММА",            "KEY"},    
            {"21", "MAX",               "МАКС",             "KEY"},
            {"22", "MIN",               "МИН",              "KEY"},
            {"23", "IN",                "",                 "KEY"},
            {"24", "LEFT",              "ЛЕВОЕ",            "KEY"},
            {"25", "RIGHT",             "ПРАВОЕ",           "KEY"},
            {"26", "ON",                "",                 "KEY"},
            {"27", "INNER JOIN",        "INNER JOIN",       "JOIN"},
            {"28", "LEFT OUTER JOIN",   "LEFT OUTER JOIN",  "JOIN"},
            {"29", "RIGHT OUTER JOIN",  "RIGHT OUTER JOIN", "JOIN"},
            {"30", "FULL OUTER JOIN",   "FULL OUTER JOIN",  "JOIN"},
            {"31", "CROSS JOIN",        "CROSS JOIN",       "JOIN"},
            {"32", "MERGE",             "",                 "KEY"},
            {"33", "LOOP",              "",                 "KEY"},
            {"34", "HASH",              "",                 "KEY"},
            {"35", "INNER",             "",                 "KEY"},
            {"36", "XML",               "",                 "KEY"},
            {"37", "PATH",              "",                 "KEY"},
            {"38", "CASE",              "СЛУЧАЙ",           "KEY"},
            {"39", "WHEN",              "КОГДА",            "KEY"},
            {"40", "THEN",              "ТОГДА",            "KEY"},
            {"41", "ELSE",              "ИНАЧЕ",            "KEY"},
            {"42", "END",               "КОНЕЦ",            "KEY"},
            {"43", "IS",                "",                 "KEY"},
            {"44", "NOT",               "",                 "KEY"},
            //{"45", "NULL",              "",                 "KEY"},
            {"46", "AS",                "КАК",              "KEY"},
            {"47", "ISNULL",            "",                 "KEY"},
            {"48", "DISTINCT",          "",                 "KEY"},                
            {"49", ",",                 "",                 "SIGN"},
            {"50", "=",                 "",                 "SIGN"},
            {"51", "(",                 "",                 "SIGN"},
            {"52", ")",                 "",                 "SIGN"},
            {"53", "+",                 "",                 "SIGN"},
            {"54", "-",                 "",                 "SIGN"},
            {"55", "*",                 "",                 "SIGN"},
            {"56", "/",                 "",                 "SIGN"},
            {"57", "<",                 "",                 "SIGN"},
            {"58", ">",                 "",                 "SIGN"},
            {"59", ";",                 "",                 "SIGN"},    
            {"60", "?",                 "",                 "SIGN"},
            {"61", "@",                 "",                 "SIGN"},
            {"62", "!",                 "",                 "SIGN"},
            {"63", "%",                 "",                 "SIGN"},
            {"64", "OR",                "",                 "KEY"},
            {"65", "WITH (NOLOCK)",     "",                 "HINT"},           
            {"66", "PARTITION BY",      "",                 "KEY"},
            {"67", "BY",                "",                 "KEY"}, 
            {"68", "ROW_NUMBER",        "",                 "FUNC"},
            {"69", "IS NULL",           "",                 "KEY"},
            {"70", "IS NOT NULL",       "",                 "KEY"},
            {"67", "BY",                "",                 "KEY"},   
            {"68", ">=",                "",                 "SIGN"},
            {"69", "<=",                "",                 "SIGN"}, 
            {"70", "<>",                "",                 "SIGN"},  
            {"71", "COUNT",             "",                 "KEY"},  
			{"72", "LIMIT",             "ПЕРВЫЕ",           "KEY"},            
            //{"65", "OID",               "ИД",               "4"},
            //{"66", "EID",               "ИДСУЩ",            "4"},
            //{"67", "EBRIEF",            "СОКРСУЩ",          "4"},
            //{"68", "ENAME",             "ИМЯСУЩ",           "4"},
            //{"69", "ADATE",             "ДАТААТР",          "4"},
            //{"70", "ODATE",             "ДАТАОБЪЕКТА",      "4"},
            //{"71", "ALLHIST",           "ВСЯИСТОРИЯ",       "4"},
            //{"72", "ADATEHIST",         "ДАТАИСТ",          "4"},
            //{"73", "SYSTYPE",           "СИСТИП",           "4"},
            //{"74", "LIMIT",             "ЛИМИТ",            "2"},
            //{"75", "OFFSET",            "СДВИГ",            "2"},
            //{"76", "ENTITYALIAS",       "ПСЕВДОНИМСУЩНОСТИ", "2"},           
            //{"77", "ACTUAL",            "АКТУАЛЬНЫЕ",       "2"},
            //{"78", "ARCHIVE",           "АРХИВНЫЕ",         "2"},
            //{"79", "DELETED",           "УДАЛЕННЫЕ",        "2"},
            //{"80", "TEST",              "ТЕСТОВЫЕ",         "2"},
            //{"81", "ONAME",             "ИМЯОБЪЕКТА",       "4"}, 
            {"81", "ObjectID",            KeyBrief.ObjectID,    "ATTR"}, 
            {"82", "EntityID",            KeyBrief.EntityID,    "ATTR"}, 
            {"83", "EntityBrief",         KeyBrief.EntityBrief, "ATTR"},
            {"84", "EntityName",          KeyBrief.EntityName,  "ATTR"}, 
            {"85", "StateDate",           KeyBrief.ObjectStateDate,   "ATTR"}, 
            {"86", "ObjectName",          KeyBrief.ObjectName,  "ATTR"}                                                         
        };       
                        
        //Переменные статического класса парсера.
        //Для того чтобы парсер работал, нужно ОБЯЗАТЕЛЬНО заполнить эти массивы.
        //Это все входные данные:        
        public static string[,] ArAttrParent; //1. Массив атрибутов - массив строк, в котором находятся все атрибуты всех сущностей.                          //
        public static string[,] ArEntity;     //2. Массив сущностей - массив строк, в котором находятся все сущности.  
        public static int ArEntityY;          //Количество строк в массиве   ArEntity.
        public static int ArEntityX;          //Количество колонок в массиве ArEntity.
        public static int ArAttrParentY;      //Количество строк в массиве   ArAttrParent.
        public static int ArAttrParentX;      //Количество колонок в массиве ArAttrParent.                                  
        public static System.Data.DataTable DTArEntity;     //Список сущностей в словарной системе.    
        public static System.Data.DataTable DTArAttrParent; //Список атрибутов в словарной системе.            
        public static bool IsInitial = false; //Признак того что данные для начала парсинга подготовлены.                
        public static int ParseCount        = 0; //Счетчик распарсенных запросов. За все время с момента запуска программы.
        
        //Эти переменные не должны быть статическими. Так как относятся к парсингу одного запроса. 
        public static int TestDeep          = 0; //Глубина вложенности, для того чтобы остановить парсинг вычисляемых атрибутов на заданной глубине вложенности.
        public static int PsevdonimSubQuery = 1; //Здесь начальный номер Алиаса для вложенных вычисляемых атрибутов. Начинаем с 1.
        public static int SelectNumber      = 1; //Количество select-ов в запросе, включая вложеныке.
        public static int TestON            = 0; //Это если мы тестируем. Нужно чтобы включать сообщения.
        
        #endregion Region. Константы и переменные.
        
        #region Region. Методы инициализации парсера.
               
        ///Запросы для инициализации парсера.
        public static string GetSQLInitial()
        {
             return "SELECT * FROM fbaEntityParser ; " + ParserSys.CR +
                    "SELECT " +
                    "Pos, NumLevel, ID, EntityID, Attr_EntityID, Attr_Name, Attr_Brief, " + ParserSys.CR +  
                    "(case when Attr_Type = 1 then 'Field' " + ParserSys.CR +  
                    "      when Attr_Type = 2 then 'Link'  " + ParserSys.CR +  
                    "      when Attr_Type = 3 then 'UniLink' " + ParserSys.CR +  
                    "      when Attr_Type = 4 then 'Array' " + ParserSys.CR +  
                    "      else CAST(Attr_Type AS VARCHAR(100))  " + ParserSys.CR +  
                    "  end) Attr_Type,      " + ParserSys.CR +             
                    "(case when Attr_Kind = 1 then 'Simple' " + ParserSys.CR +  
                    "      when Attr_Kind = 2 then 'System' " + ParserSys.CR +  
                    "      when Attr_Kind = 3 then 'Calc'   " + ParserSys.CR +  
                    "      else CAST(Attr_Kind AS VARCHAR(100))   " + ParserSys.CR +  
                    "  end) Attr_Kind,      " + ParserSys.CR +  
                    "Attr_Mask, Attr_Feature, Attr_NameOrder, Attr_Code, Attr_Comment, Table_ID, Table_Field, Table_Field2, " + ParserSys.CR +  
                    "Ref_EntityID, Ref_AttrID, Table_Name, Table_IDFieldName, " + ParserSys.CR +                     
                    "(case when Table_Type = 1 then 'Main' " + ParserSys.CR +  
                    "      when Table_Type = 2 then 'Hist'  " + ParserSys.CR +                                  
                    "      else CAST(Table_Type AS VARCHAR(100))   " + ParserSys.CR +  
                    "  end) Table_Type,      " + ParserSys.CR +                                                    
                    "Table_Feature,                    " + ParserSys.CR +  
                    "Ref_EntityBrief, Ref_AttrBrief, Ref_AttrName, Attr_EntityBrief, EnChildID, EnBrief2, EnID, " + ParserSys.CR +  
                    "EnBrief1, ParentID, EnBriefName2, EnBriefName1, EnBrief2_TableName, " + ParserSys.CR +  
             	"EnBrief2_TAbleIDFieldName, EnBrief1_TableName, EnBrief1_TAbleIDFieldName " + ParserSys.CR +  
                    "FROM fbaAttrParent ORDER BY EnBrief2, NumLevel desc, Table_Type"; 
        }
        
        ///Заполнение массивов данными из DataTable.       
        public static void ParserInitial(string ServerType)            
        {
            if (!ParserData.IsInitial) 
            {          
            	string SQL = GetSQLInitial();
	            var DS = new System.Data.DataSet();                                	        
	            ParserCon.PipeSelectDS(SQL, out DS);
	            ParserInitialFromDS(DS); 
            }
        }          
             
        ///Заполнение массивов данными из DataTable.
        public static void ParserInitialFromDS(System.Data.DataSet DS)          
        {                                                                                                                     
            //Инициализация если таблицы в SQLite:
            //string SQL = GetSQLInitial(); DS.Tables.Count() DTArEntity.Rows.Count   DTArAttrParent.Rows.Count
            //...
            //
            
            DTArEntity     = DS.Tables[0];
            DTArAttrParent = DS.Tables[1];           
            ParserSys.ParserArrayFromDT(DTArEntity, out ArEntity);
            ParserSys.ParserArrayFromDT(DTArAttrParent, out ArAttrParent);
            ArEntityY      = ArEntity.GetLength(0);
            ArEntityX      = ArEntity.GetLength(1);
            ArAttrParentY  = ArAttrParent.GetLength(0); 
            ArAttrParentX  = ArAttrParent.GetLength(1);           
            IsInitial = true;            
        }
                   
        #endregion Region. Методы инициализации парсера.
                             
        #region Region. Методы статического класса парсера. 
                    
        ///Показать информацию по атрибутам сущности.
        public static string GetSQLAttr(string EntityBrief)
        {                                          
            string SQL = "--Таблица #EntityParent с деревом сущностей.                              " + ParserSys.CR +
            ";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS   " + ParserSys.CR +
            "      (                                                                   " + ParserSys.CR +
            "        SELECT                                                            " + ParserSys.CR +
            "          ID AS EnChildID,                                                " + ParserSys.CR +
            "          Brief AS EnBrief2,                                              " + ParserSys.CR +
            "          ID as EnID,                                                     " + ParserSys.CR +
            "          Brief as EnBrief1,                                              " + ParserSys.CR +
            "          ParentID,                                                       " + ParserSys.CR +
            "          Name as EnBriefName2,                                           " + ParserSys.CR +
            "          Name as EnBriefName1                                            " + ParserSys.CR +
            "        FROM enEntity                                                     " + ParserSys.CR +
            "        UNION ALL                                                         " + ParserSys.CR +
            "        SELECT                                                            " + ParserSys.CR +
            "          EnChildID,                                                      " + ParserSys.CR +
            "          EnBrief2,                                                       " + ParserSys.CR +
            "          e.ID as EnID,                                                   " + ParserSys.CR +
            "          e.Brief as EnBrief1,                                            " + ParserSys.CR +
            "          e.ParentID,                                                     " + ParserSys.CR +
            "          p.EnBriefName2 as EnBriefName2,                                 " + ParserSys.CR +
            "          e.Name as EnBriefName1                                          " + ParserSys.CR +
            "        FROM enEntity e INNER JOIN Parents p ON p.ParentID = e.ID     " + ParserSys.CR +
            "      ) SELECT " + ParserSys.CR +
            "        --t1.*, t2.*, t3.Name as TableName, t4.Brief as 'Attr Link'" + ParserSys.CR +
            "        t1.EnChildID as 'Entity ID'," + ParserSys.CR +
            "        t1.EnBrief2 as 'Entity Brief'," + ParserSys.CR +
            "        t1.EnBriefName2 as 'Entity Name'," + ParserSys.CR +
            "        t1.EnID as 'Attr Entity ID', " + ParserSys.CR +
            "        t1.EnBriefName1 AS 'Attr Entity Name'," + ParserSys.CR +
            "        t1.EnBrief1 as 'Attr Entity Brief'," + ParserSys.CR +
            "        " + ParserSys.CR +
            "         " + ParserSys.CR +
            "        t2.ID     AS 'Attr ID', " + ParserSys.CR +
            "        t2.Name   AS 'Attr Name'," + ParserSys.CR +
            "        t2.Brief  AS 'Attr Brief'," + ParserSys.CR +
            "        (CASE WHEN t2.Type = 1 THEN 'Field' " + ParserSys.CR +
            "              WHEN t2.Type = 2 THEN 'Link' " + ParserSys.CR +
            "              WHEN t2.Type = 3 THEN 'UniLink' " + ParserSys.CR +
            "              WHEN t2.Type = 4 THEN 'Array'  " + ParserSys.CR +
            "              ELSE 'Unknown' END) AS 'Attr Type',        " + ParserSys.CR +
            "        (CASE WHEN t2.Kind = 1 THEN 'DataBase'" + ParserSys.CR +
            "              WHEN t2.Kind = 2 THEN 'Sys' " + ParserSys.CR +
            "              WHEN t2.Kind = 3 THEN 'Calc'" + ParserSys.CR +
            "               ELSE 'Unknown' END) AS 'Attr Kind',        " + ParserSys.CR +
            "        t2.Mask   AS 'Mask'," + ParserSys.CR +
            "        t4.Brief  AS 'Link'," + ParserSys.CR +
            "        t3.Name   AS 'Table'," + ParserSys.CR +
            "        (CASE WHEN t3.Type = 1 THEN 'Main'" + ParserSys.CR +
            "              WHEN t3.Type = 2 THEN 'Hist'" + ParserSys.CR +
            "        ELSE 'Unknown' END) AS 'Table Type',                " + ParserSys.CR +
            "        t2.ObjectNameOrder AS 'Order in Name'        " + ParserSys.CR +
            "FROM Parents t1 " + ParserSys.CR +
            "        LEFT JOIN enAttribute   t2 ON t1.EnID    = t2.AttributeEntityID" + ParserSys.CR +
            "        LEFT JOIN enEntity t4 ON t4.ID      = t2.RefEntityID  " + ParserSys.CR +
            "        LEFT JOIN enTable  t3 ON t3.ID = t2.ID " + ParserSys.CR +
            "        WHERE " + ParserSys.CR +
            "        --t1.EnChildID = 1694 " + ParserSys.CR +
            "        --t1.EnBriefName1 = 'Договор страхования'" + ParserSys.CR +
            "        t1.EnBrief2= '" + EntityBrief + "'" + ParserSys.CR +
            "        AND 1=1 " + ParserSys.CR +
            "        ORDER BY EnBrief2, EnBrief1; ";
            return SQL;
            //System.Data.DataTable DT = new DataTable();
            //sys.SelectDT(DirectionQuery.Remote, SQL, out DT);
            //sys.DTView(DT, "Entity Attributes", "Attributes");
        }
               
        ///Показать информацию по таблицам сущности.
        public static string GetSQLEntity(string EntityBrief)
        {                                          
            string SQL = "--Таблица #EntityParent с деревом сущностей.               " + ParserSys.CR +          
            "--Таблица в которой собраны все таблицы сущности, в том числе и предков." + ParserSys.CR +
            ";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS   " + ParserSys.CR +
            "      (                                                                   " + ParserSys.CR +
            "        SELECT                                                            " + ParserSys.CR +
            "          ID AS EnChildID,                                                " + ParserSys.CR +
            "          Brief AS EnBrief2,                                              " + ParserSys.CR +
            "          ID as EnID,                                                     " + ParserSys.CR +
            "          Brief as EnBrief1,                                              " + ParserSys.CR +
            "          ParentID,                                                       " + ParserSys.CR +
            "          Name as EnBriefName2,                                           " + ParserSys.CR +
            "          Name as EnBriefName1                                            " + ParserSys.CR +
            "        FROM enEntity                                                 " + ParserSys.CR +
            "        UNION ALL                                                         " + ParserSys.CR +
            "        SELECT                                                            " + ParserSys.CR +
            "          EnChildID,                                                      " + ParserSys.CR +
            "          EnBrief2,                                                       " + ParserSys.CR +
            "          e.ID as EnID,                                                   " + ParserSys.CR +
            "          e.Brief as EnBrief1,                                            " + ParserSys.CR +
            "          e.ParentID,                                                     " + ParserSys.CR +
            "          p.EnBriefName2 as EnBriefName2,                                 " + ParserSys.CR +
            "          e.Name as EnBriefName1                                          " + ParserSys.CR +
            "        FROM enEntity e INNER JOIN Parents p ON p.ParentID = e.ID     " + ParserSys.CR +
            "      ) SELECT" + ParserSys.CR +
            "        t1.EnChildID AS 'Entity ID'," + ParserSys.CR +
            "        t1.EnBriefName2 AS 'Entity Name'," + ParserSys.CR +
            "        t1.EnBrief2 AS 'Entity Brief'," + ParserSys.CR +
            "        t1.EnID AS 'Parent Entity ID'," + ParserSys.CR +
            "        t1.EnBriefName1 AS 'Parent Entity Name'," + ParserSys.CR +
            "        t1.EnBrief1 AS 'Parent Entity Brief',    " + ParserSys.CR +
            "        t2.ID AS 'ID'," + ParserSys.CR +
            "        t2.Name   AS 'Name'," + ParserSys.CR +
            "        (CASE WHEN t2.Type = 1 THEN 'Main' ELSE 'Hist' END) AS 'Type'," + ParserSys.CR +
            "        t2.IDFieldName AS 'Field ID'                                  " + ParserSys.CR +
            "FROM Parents t1   " + ParserSys.CR +
            "        LEFT JOIN enTable  t2 ON t2.TableEntityID = t1.EnID" + ParserSys.CR +
            "        WHERE t1.EnBrief2 = '" + EntityBrief + "' ORDER BY EnBrief2, EnBrief1; ";
            return SQL;
        }
        
        ///Выделить из составного атрибута 2 части, начиная с Level. Level начинается с 1.
        public static void GetAttrByLevel(int Level, string AttrInput, out string Str1, out string Str2)
        {                                    
            string[] DotArray = AttrInput.Split('.');
            Str1 = "";
            Str2 = "";
            //if (DotArray.Count() > Level - 1) Str1 = DotArray[Level - 1];
            if (DotArray.Length > Level - 1) Str1 = DotArray[Level - 1];
            //if (DotArray.Count() > Level)     Str2 = DotArray[Level];
            if (DotArray.Length > Level)     Str2 = DotArray[Level];
            //return Str1;
        }
        
        ///Выделить из составного количество частей равное Level. Level начинается с 1.
        public static string GetAttrPart(int Level, string AttrInput)
        {                       
            //ДогСтрах.КаналПродаж.Код
            string[] DotArray = AttrInput.Split('.');           
            string Result = "";
            for (int i = 0; ((i < Level) && (i < DotArray.Length)) ; i++)
            {                  
                if (Result != "") Result += ".";
                Result += DotArray[i];
            }
            return Result;          
        } 
        
        ///Сравнить два атрибута. Метод только для FindLastDot(). Возвращает номер точки, до которой совпадают атрибуты.
        ///Не используется.
        public static int CompareTwoAttr(string Attr1, string Attr2)
        {
            //Attr1 - атрибут, который проверяем.
            //Attr2 - атрибут, по которому проверяем.
            //ДогСтрах.КаналПродаж.Код, ДогСтрах.ВидДок.Наим.rty.tyty.yt.yty
            string[] DotArray1 = Attr1.Split('.');
            string[] DotArray2 = Attr2.Split('.');
            int DotNumber = 0;
            for (int i = 0; i < DotArray1.Length; i++)
            {
                if (DotArray2.Length <= i) return DotNumber;
                if (DotArray1[i] != DotArray2[i]) return DotNumber;
                DotNumber++;                  
            }
            return DotNumber;
        }  
                  
        ///Получение данных по одному атрибуту. Поиск по AttrParent.
        public static void GetAttrData(string EntityBrief,
                                       string Attr,                                     
                                       out string EntityID,
                                       out string Ref_EntityBrief,                                     
                                       out string AttrType,
                                       out string AttrKind, 
                                       out string AttrCode,                                      
                                       out string TableName,
                                       out string TableType,                                         
                                       out string TableField,
                                       out string TableField2,
                                       out string TableFieldID)
        {
        
            EntityID        = "";
            Ref_EntityBrief = "";                                     
            AttrType        = "";
            AttrKind        = ""; 
            AttrCode        = "";                                      
            TableName       = "";
            TableType       = "Main";
            TableFieldID    = "";
            TableField      = "";
            TableField2     = "";
            
            string AttrUpper = Attr.ToUpper();
            string EntityUpper = EntityBrief.ToUpper();
                                                              
            if ((AttrUpper == KeyBriefUpper.ObjectID) || 
                (AttrUpper == KeyBriefUpper.EntityID) || 
                (AttrUpper == KeyBriefUpper.ObjectName)) 
            {                           
                for (int i = 0; i < ParserData.ArEntityY; i++)
                {
                    if (ParserData.ArEntity[i, nBrief].ToUpper() != EntityUpper) continue;
                    EntityID     = ParserData.ArEntity[i, nID];
                    AttrType     = "Field";
                    AttrKind     = "System";
                    TableName    = ParserData.ArEntity[i, nTable_Name];
                    TableType    = "Main";
                    TableFieldID = ParserData.ArEntity[i, nTable_IDFieldName];
                    if (AttrUpper == KeyBriefUpper.ObjectID) TableField = ParserData.ArEntity[i, nTable_IDFieldName]; 
                    if (AttrUpper == KeyBriefUpper.EntityID) TableField = "EntityID";                     
                    return;                    
                }                
            }
                          
            //Тут нужно джойниить enEntity.            
            if ((AttrUpper == KeyBriefUpper.EntityBrief) || 
                (AttrUpper == KeyBriefUpper.EntityName))    
            {                                           
                EntityID     = "1";
                AttrType     = "Field";
                AttrKind     = "System";
                TableName    = "enEntity";
                TableType    = "Main";
                TableFieldID = "ID";
                if (AttrUpper == KeyBriefUpper.EntityBrief) TableField = "Brief";
                if (AttrUpper == KeyBriefUpper.EntityName) TableField = "Name"; 
                //if (AttrUpper == "СОКРСУЩНОСТИ") TableField = "Brief";
                //if (AttrUpper == "НАИМСУЩНОСТИ") TableField = "Name";                 
                return;
            }                         
            
            //Поиск только по атрибутам сущности EntityBrief.
            for (int i = 0; i < ParserData.ArAttrParentY; i++)
            {
                if ((ParserData.ArAttrParent[i, aEnBrief1].ToUpper()   == EntityUpper) &&
                    (ParserData.ArAttrParent[i, aEnBrief2].ToUpper()   == EntityUpper) &&
                    (ParserData.ArAttrParent[i, aAttr_Brief].ToUpper() == AttrUpper))
                {                   
                    EntityID = ParserData.ArAttrParent[i, aAttr_EntityID];
                    Ref_EntityBrief = ParserData.ArAttrParent[i, aRef_EntityBrief];                   
                    AttrType     = ParserData.ArAttrParent[i, aAttr_Type];
                    AttrKind     = ParserData.ArAttrParent[i, aAttr_Kind];
                    AttrCode     = ParserData.ArAttrParent[i, aAttr_Code];
                    TableName    = ParserData.ArAttrParent[i, aTable_Name];
                    TableType    = ParserData.ArAttrParent[i, aTable_Type];
                    TableFieldID = ParserData.ArAttrParent[i, aTable_IDFieldName]; 
                    TableField   = ParserData.ArAttrParent[i, aTable_Field]; 
                    TableField2  = ParserData.ArAttrParent[i, aTable_Field2];                                                       
                    return;
                }                    
            }
            
            //Поиск по атрибутам предков сущности EntityBrief.
            //Нельзя поискать сразу по предкам сущности и текущей сущности, 
            //так как атрибут может быть переопределен. 
            //Т.е. один и тот же атрибут и у самой сущности и у её предка(предков).
            //Восходящий поиск не реализован - здесь возьмется первая попавшаяся 
            //сущность предка если она содержит искомый атрибут. 
            //Выходит что переопределить атрибут можно только один раз.
            for (int i = 0; i < ParserData.ArAttrParentY; i++)
            {
               if ((ParserData.ArAttrParent[i, aEnBrief2].ToUpper()   == EntityUpper) && 
                   (ParserData.ArAttrParent[i, aAttr_Brief].ToUpper() == AttrUpper))
                {                   
                    EntityID = ParserData.ArAttrParent[i, aAttr_EntityID];
                    Ref_EntityBrief = ParserData.ArAttrParent[i, aRef_EntityBrief];                   
                    AttrType     = ParserData.ArAttrParent[i, aAttr_Type];
                    AttrKind     = ParserData.ArAttrParent[i, aAttr_Kind];
                    AttrCode     = ParserData.ArAttrParent[i, aAttr_Code];
                    TableName    = ParserData.ArAttrParent[i, aTable_Name];
                    TableType    = ParserData.ArAttrParent[i, aTable_Type];
                    TableFieldID = ParserData.ArAttrParent[i, aTable_IDFieldName]; 
                    TableField   = ParserData.ArAttrParent[i, aTable_Field]; 
                    TableField2  = ParserData.ArAttrParent[i, aTable_Field2];                                         
                    return;
                }                    
            }           
            //Поиск по атрибутам потомков не произодится.
        }
        
        ///Получение данных по сущности. Поиск главной таблицы сущности по сокращению сущности.
        public static void GetEntityData(string EntityBrief,                                                                         
                                      out string EntityID,
                                      out string TableName, 
                                      out string TableType, 
                                      out string TableFieldID)
        {           
            EntityID        = "";                                            
            TableName       = "";
            TableType       = "Main";
            TableFieldID    = "";
               
            string EntityUpper = EntityBrief.ToUpper();            
            for (int i = 0; i < ArEntityY; i++)
            {
                //if (ParserData.ArEntity[i, nBrief].Equals(EntityBrief, StringComparison.OrdinalIgnoreCase))
                if (ParserData.ArEntity[i, nBrief].ToUpper() == EntityUpper)
                {                   
                    EntityID     = ParserData.ArEntity[i, nID];                         
                    TableName    = ParserData.ArEntity[i, nTable_Name];                    
                    TableFieldID = ParserData.ArEntity[i, nTable_IDFieldName];                                            
                    return;
                }                    
            }
            //ParserData.ArEntity[i, nBrief].
        }
        
        ///Найти первую сущность для атрибута, с которой он начинается. Процедура только для FindFirstAttr
        public static bool ExistsAttrInEntity(string Entity, string Attr, bool SearchInParentEntities)
        {           
            string AttrUpper = Attr.ToUpper();
            string EntityUpper = Entity.ToUpper();
            //Это системные атрибуты, их нет в таблице атрибутов, поэтому просто выходим и не ищем.
            if (AttrUpper == KeyBriefUpper.ObjectID)    return true;
            if (AttrUpper == KeyBriefUpper.EntityID)    return true; 
            if (AttrUpper == KeyBriefUpper.EntityBrief) return true; 
            if (AttrUpper == KeyBriefUpper.EntityName)  return true; 
            if (AttrUpper == KeyBriefUpper.StateDate)   return true; 
            if (AttrUpper == KeyBriefUpper.ObjectName)  return true;
            for (int j = 0; j < ParserData.ArAttrParentY; j++)
            {
                //Если свой атрибут или атрибут предка то поиск по aEnBrief2.
                //Если только конкретно свой атрибут, то поиск по aEnBrief2 и по aEnBrief1.
                if (SearchInParentEntities)
                {
                    //Поиск своего атрибута или атрибута предка. 
                    if ((ParserData.ArAttrParent[j, ParserData.aEnBrief2].ToUpper() == EntityUpper) &&
                        (ParserData.ArAttrParent[j, ParserData.aAttr_Brief].ToUpper() == AttrUpper)) return true;
                    } else
                {
                    //Поиск только своего атрибута.
                    if ((ParserData.ArAttrParent[j, ParserData.aEnBrief1].ToUpper() == EntityUpper) &&
                        (ParserData.ArAttrParent[j, ParserData.aEnBrief2].ToUpper() == EntityUpper) && 
                        (ParserData.ArAttrParent[j, ParserData.aAttr_Brief].ToUpper() == AttrUpper)) return true;
                }
            }
            return false;       
        } 
        
          
        public static string GetIDFieldName(string TableName)
        {              
            //Инициализация статических данных для парсера.
            //ParserData.ParserInitial(null);  
            for (int i = 0; i < ParserData.ArAttrParentY; i++)
            {                                       
                if (ParserData.ArAttrParent[i, ParserData.aTable_Name] == TableName) return ParserData.ArAttrParent[i, ParserData.aTable_IDFieldName];
            } 
            return "";
        }
        
       
        
         
        //Показать информацию по таблицам сущности.
        /*public static string GetListAttr(string EntityBrief)
        {                                          
            string SQL = "--Таблица #EntityParent с деревом сущностей.               " + Var.CR +          
            "--Таблица в которой собраны все таблицы сущности, в том числе и предков." + Var.CR +
            ";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS   " + Var.CR +
            "      (                                                                   " + Var.CR +
            "        SELECT                                                            " + Var.CR +
            "          ID AS EnChildID,                                                " + Var.CR +
            "          Brief AS EnBrief2,                                              " + Var.CR +
            "          ID as EnID,                                                     " + Var.CR +
            "          Brief as EnBrief1,                                              " + Var.CR +
            "          ParentID,                                                       " + Var.CR +
            "          Name as EnBriefName2,                                           " + Var.CR +
            "          Name as EnBriefName1                                            " + Var.CR +
            "        FROM enEntity                                                 " + Var.CR +
            "        UNION ALL                                                         " + Var.CR +
            "        SELECT                                                            " + Var.CR +
            "          EnChildID,                                                      " + Var.CR +
            "          EnBrief2,                                                       " + Var.CR +
            "          e.ID as EnID,                                                   " + Var.CR +
            "          e.Brief as EnBrief1,                                            " + Var.CR +
            "          e.ParentID,                                                     " + Var.CR +
            "          p.EnBriefName2 as EnBriefName2,                                 " + Var.CR +
            "          e.Name as EnBriefName1                                          " + Var.CR +
            "        FROM enEntity e INNER JOIN Parents p ON p.ParentID = e.ID     " + Var.CR +
            "      ) SELECT" + Var.CR +
            "        t1.EnChildID AS 'Entity ID'," + Var.CR +
            "        t1.EnBriefName2 AS 'Entity Name'," + Var.CR +
            "        t1.EnBrief2 AS 'Entity Brief'," + Var.CR +
            "        t1.EnID AS 'Parent Entity ID'," + Var.CR +
            "        t1.EnBriefName1 AS 'Parent Entity Name'," + Var.CR +
            "        t1.EnBrief1 AS 'Parent Entity Brief',    " + Var.CR +
            "        t2.TableID AS 'ID'," + Var.CR +
            "        t2.Name   AS 'Name'," + Var.CR +
            "        (CASE WHEN t2.Type = 1 THEN 'Main' ELSE 'Hist' END) AS 'Type'," + Var.CR +
            "        t2.IDFieldName AS 'Field ID'                                  " + Var.CR +
            "FROM Parents t1   " + Var.CR +
            "        LEFT JOIN enTable  t2 ON t2.TableEntityID = t1.EnID" + Var.CR +
            "        WHERE t1.EnBrief2 = '" + EntityBrief + "' ORDER BY EnBrief2, EnBrief1; ";
            return SQL;
        } */
       
        #endregion Region. Методы статического класса парсера.     
     
    }    
    
    //Часть методов парсера.
    public partial class Parser
    {                                   
        //TODO: CROSS JOIN
        //TODO: Звёздочка
        //TODO: Ошибка если запрос оканчивается на скобку             
        
        #region Region. Константы для массивов и переменные.
       
        //Первые пуквы массивов констант: n,a,w,s,e,t,v,d
        //Входные таблицы:
                
        //Константы для массива arEntity.
        const int nPos                 		 = 0;
        const int nID                  		 = 1;
        const int nEntityID            		 = 2;
        const int nName                		 = 3;
        const int nBrief               		 = 4;
        const int nParentID            		 = 5;
        //const int nClassKey          	  = 6;
        const int nFeature             		 = 7;
        const int nDescription         		 = 8;
        //const int nSecurityDataClassId = 9;
        const int nTable_ID            		 = 10;
        const int nTable_Name          		 = 11;
        const int nTable_IDFieldName   		 = 12;    
                 
        //Константы для массива arAttrParent.
        const int aPos                		  = 0;
        const int aID                 		  = 1;
        const int aEntityID           		  = 2;  
        const int aAttr_EntityID      		  = 3;  
        const int aAttr_Name           		 = 4;  
        const int aAttr_Brief          		 = 5;
        const int aAttr_Type           		 = 6;
        const int aAttr_Kind           		 = 7;
        const int aAttr_Mask           		 = 8;
        const int aAttr_Feature        		 = 9;
        const int aAttr_NameOrder      		 = 10;
        const int aAttr_Code           		 = 11;
        const int aAttr_Comment        		 = 12;
        const int aTable_ID            		 = 13;
        const int aTable_Field         		 = 14;
        const int aTable_Field2        		 = 15;
        const int aRef_EntityID        		 = 16;
        const int aRef_AttrID          		 = 17;
        const int aTable_Name          		 = 18;
        const int aTable_IDFieldName   		 = 19;
        const int aTable_Type          		 = 20;
        const int aTable_Feature       		 = 21;
        const int aRef_EntityBrief     		 = 22;
        const int aRef_AttrBrief       		 = 23;
        const int aRef_AttrName        		 = 24;
        const int aAttr_EntityBrief    		 = 25;
        const int aEnChildID           		 = 26;
        const int aEnBrief2            		 = 27;
        const int aEnID                		 = 28;
        const int aEnBrief1            		 = 29;
        const int aParentID            		 = 30;       
        const int aEnBriefName2        		 = 31;
        const int aEnBriefName1        		 = 32;       
        const int aEnBrief2_TableName        = 33;
        const int aEnBrief2_TableIDFieldName = 34;
        const int aEnBrief1_TableName        = 35;
        const int aEnBrief1_TableIDFieldName = 36;
                    
        //Таблицы для парсинга:
        //Константы для массива Words.    
        //var WordCap = new StringBuilder();            
        const int wPos                 = 0;  //WordCap.Append("wPos");
        const int wLex                 = 1;  //Слово.       
        const int wDOCR                = 2;  //Перенос строк в готовом тексте SQL. DOCR должен быть последним полем в массиве.        
        const int wReadySQL            = 3;  //Готовая строка SQL для сборки полного текста SQL.
        const int wBrace               = 4;  //Скобка.
        const int wBraceLevel          = 5;  //Уровень вложенности скобки.
        const int wBraceNum            = 6;  //Номер вложенности скобкок.    
        const int wSelect              = 7;  //Номер вложенности скобкок.
        const int wBlockEnd            = 8;  //Конец блока (SELECT, TOP, FROM, WHERE, ORDER BY, GROUP BY.
        const int wBlockWhere          = 9;  //Если 1 то мы в блоке WHERE.
        const int wBlockFunc           = 10; //Если 1 то мы в блоке FROM.       
        const int wBlockCase           = 11; //Если 1 то мы в блоке FROM.       
        const int wProc                = 12; //Колонка только для разработки и отладки. Позже нужно удалить.
        const int wLexType             = 13; //Тип лексемы.    
        const int wAlias               = 14; //Алиас для атрибута или сущности.         
        const int wEntity              = 15; //Первая сущностьсоставного атрибута. 
        const int wEntityAlias         = 16; //Это алиас сущности к которой отнсится первый атрибут. 
        const int wEntityID            = 17; // 
        const int wTableName           = 18; //Таблица для сущности (главная) или таблица одиночного атрибута.
        const int wTableField          = 19; //Поле в таблице для атрибута. 
        const int wTableField2         = 20; //Поле в таблице для атрибута.           
        const int wTableFieldID        = 21; //Поле ID в таблице Table. 
        const int wTableType           = 22; //Тип таблицы.
        const int wTableAlias          = 23; //Алиас таблицы. 
        const int wFirstAttrType       = 24; //C чего начинается атрибут. 0 - не определено (ошибка), 1 - начинается с алиаса, 2 начинается с сокращения сущности.
        const int wAttrComplex         = 25; //Является реально составным атрибутом (т.е. есть одна точка и более, и она не для отделения алиаса от атрибута). 
        const int wAttrFirst           = 26; //Первая часть составного атрибута, нужна чтобы иметь точку начала разбора состанвного атрибута (с чего начать).
        const int wAttrFull            = 27; //Полный составной атрибут, без алиса.        
        const int wAttrType            = 28; //Тип атрибута
        const int wAttrKind            = 29; //Вид атрибута
        const int wAttrCode            = 30; //Код вычисляемого атрибута.        
        const int wUserString          = 31; //Пользовательская стрка в исходном запросе.
        const int wStateDate           = 32; //Дата состяония для сущности.
        const int wRef_EntityBrief     = 33; //На что ссылается первый атрибут в сосоавном атрибуте.
        const int wCompareDotLevel     = 34; //Точка в составном атрибуте, начиная с которой, составной атрибут начинается отличаться от предыдущего составного атрибута.
        const int wCompareDotNum       = 35; //Не используется.
                                                           
        //Константы для массива ListUserStr.
        const int sPos                 = 0;
        const int sNum                 = 1;
        const int sRealString          = 2; 
        const int sRealStringParse     = 3;
        const int sUserString          = 4;
          
        //Константы для массива ListEntity.          
        const int ePos                 = 0;
        const int eNum                 = 1;
        const int eLex                 = 2;
        const int eSelect              = 3;
        const int eAlias               = 4;
        //const int eBraceNum            = 5;
        const int eStateDate           = 5;              
              
        //Константы для массива ListTable.          
        const int tPos                 = 0;
        const int tNum                 = 1;
        const int tTableName           = 2;
        const int tTableFieldID        = 3;
        const int tAlias               = 4;
        const int tSelect              = 5;
        const int tTableType           = 6;
        const int tLexType             = 7;
        const int tEntity              = 8;
        const int tEntityAlias         = 9;
        const int tStateDate           = 10;
        const int tAttrFull            = 11;
        const int tProc                = 12;
        const int tLevel               = 13;
        const int tCompareDotLevel     = 14;
        const int tCompareDotNum       = 15;
        const int tAttrPart            = 16;
        const int tJoinTableName       = 17;
        const int tJoinTableAlias      = 18;
        const int tJoinTableField      = 19;    
             
        //Константы для массива AttrTable.
        const int vPos                 = 0;
        const int vNum                 = 1;       
        const int vAlias               = 2;
        const int vSelect              = 3; 
        const int vNumPart             = 4;
        const int vLastPart            = 5; //Это значит последнгий атрибут в составном атрибуте.  
        const int vPsevdonim           = 6; //
        const int vEntity              = 7;
        const int vEntityAlias         = 8;
        const int vEntityID            = 9;
        const int vEntityTableMain     = 10;
        const int vEntityTableFieldID  = 11;       
        const int vRef_EntityBrief     = 12;        
        const int vAttrFull            = 13;
        const int vAttrPartFull        = 14;
        //vAttrPartNoLast - Это тот же AttrPartFull , но без последнего атрибута (после точки).
        //Нужен чтобы исключить некоторые (повторяющиеся) таблицы из JOIN.
        const int vAttrPartNoLast      = 15; 
        const int vAttrPart            = 16;
        const int vAttrType            = 17;
        const int vAttrKind            = 18;                                                                                                                                                                    
        const int vAttrCode            = 19;                                                                     
        const int vTableName           = 20;
        const int vTableType           = 21;
        const int vTableField          = 22;
        const int vTableField2         = 23;       
        const int vTableFieldID        = 24; 
        const int vTableAlias          = 25;
        const int vTableAliasReplace   = 26; //Это для того чтобы повторно не джойнить таблицы, которые уже приджойнены. Подменяем алиас на уже существующий.       
        const int vStateDate           = 27; //Дата состояния для историчных таблиц.       
               
        const int vJoinTableName       = 28; //Имя такбдицы, которую джойним.
        const int vJoinTableAlias      = 29; //Алиас таблицы, которую джойним.
        const int vJoinTableFieldID    = 30; //Поле ID таблицы, которую джойним.          
        //const int vAttrPsevdonim     = 30; //0 или 1. Если 1, то значит полный атрибут начинается на слово ПсевдонимСущности.       
        //Если весь запрос является вычисляемым атрибутом, то, здесь то, что нужно джойнить к главной сущности, 
        //из которой был вызван данный вычисляемый атрибут(К сущности после FROM в вызывающем запросе).
        //К полю vJoinSQL добавляется vSubJoinSQL. Это в том случае если у нас в нашем вычисляемом атрибуте есть ещё вычисляемый атрибут.
        const int vJoinSQL             = 31;              
        const int vAttrSQL             = 32; //То, что будет вместо атрибута в готовом запросе. Это поле будет вставлено в поле ReadySQL в Words.                     
        const int vSubJoinSQL          = 33; //Темповое поле. Результат после парсинга вычисляемого атрибута. Что нужно приджойнить к вызывающей сущности. (на которой вычисляемый атрибут)
        const int vSubSQL              = 34; //Темповое поле. Результат после парсинга вычисляемого атрибута. Что должно быть на месте вычисляемого атрибута.
        const int vNumSub              = 35; //Номер вычисляемого атрибута. Счетчик всегда увеличивается, независимо от того вложены они друг в друга или нет. Прям как автоинкремент.      
        const int vPosSub              = 36;   
        const int vBlockWhere          = 37; 
        
        //Массив для содержания ДатаСостояния атрибутов - ListStateDate.       
        const int dPos                 = 0;
        const int dNum                 = 1;
        const int dSelect              = 2;
        const int dEntityBrief         = 3;
        const int dEntityAlias         = 4;
        const int dStateDate           = 5;
        const int dStateDateBeg        = 6;
        const int dStateDateEnd        = 7;
        const int dStateDateCode       = 8;
        
        public string PsevdonimEntityBrief  = ""; //Сокращение сущности которой псевдоним.
        public string PsevdonimAlias        = ""; //Собственно сам псевдоним.          
        public string PsevdonimStateDate    = "";
        
        //Для того чтобы прервать рекурсивный вызов парсинга, если произошла ошибка и зациклилось выполнение. Ограничение 10 вызовов.
        public int PsevdonimCountRecursion  = 0;         
        
        // string a = "ABCDEFАБВГДЕ";
        //byte[] b = Encoding.Default.GetBytes(a);
        //public string Psevdonim  string c = ((char)67).ToString();
        //public string PsevdonimTableName    = "";
        //public string PsevdonimTableFieldID = ""; 
        
        //Для тестирования. Для вычисления времени выполнения методов парсера. В основном для отладки.
        DateTime LocalStart;          //Для вычисления времени выполнения всех методов парсинга.
        DateTime TotalStart;          //Для вычисления сумарного времени выполнения парсинга.
        public ParserEnterMode enterMode = ParserEnterMode.Work; //Если Test, то выполнянется вычисление скорости работы методов + подготовка DataTable на выходе.
        //public StringBuilder ParseTimeSQL;   //Время выполнения всех методов парсинга. 
        public string ParseTimeSQL = "";   //Время выполнения всех методов парсинга. 
        
        string[,] AttrTablePrev;      //Это AttrTable которая посылается в парсер, если он вызывается рекурсивно, при разборе вычисляемого атрибута.
        public int AttrTablePrevCount = 0;
        public string MSQL;             //Входящий запрос на MSQL.
        
        public int BraceLevelCount = 0; //Уровень вложенности скобок.
        public int BraceNumCount   = 0; //Порядковый номер вложенности скобок.
        public int SelectCount     = 0; //Номер запроса SELECT в исходном запросе.
        public int AliasCount      = 0; //Количество Алиасов в исходном запросе.
        public int EntityCount     = 0; //Количество сущностей в исходном запросе.
        public int QueryCount      = 0; //Количество SELECT в исходном запросе.
        public int TableCount      = 0; //Количество таблице в запросе.       
        
        
        public int AttrTableCountAll = 0; //В одну таблицу сваливаются все атрибуты, по всем вычисляемым атрибутам.
         //AttrTableCountAll -это общее кол-во строк в таблице.
        public int StateDateCount  = 0; //Количество ДатаСостОбъекта указанных в запросе.
        public int ColumnNum       = 1; //Переменная для формирования алиасов, чтобы формировать колонки с названиями Column1, Column2... 
        //Размер массива Words. Устанавливаем с запасом, 
        //так как после создания размер массива в C# измениить нельзя.
        //Циклы пробегать все 10000 не будут, а только до конца данных.
        public const int WordsY = 10000;    //Количество строк главной таблицы.
        public const int WordsX = wCompareDotNum + 1; //Количество полей главной таблицы.         

        public int WordsCount = 0; //Общее количество лексем, для того чтобы не гнать по всему массиву до конца.
        public string[,] Words         = new string[WordsY, WordsX]; //Это запрос, разбитый по словам.

        public int ListUserStrCount = 0; //Количество пользовательских строк.
        public string[,] ListUserStr   = new string[10000, sUserString + 1];       //Это строки в запросе.                           

        public string[,] ListEntity    = new string[100, nTable_IDFieldName + 1];  //Список всех сущностей.  
        public string[,] ListTable     = new string[100, tJoinTableField + 1];     //Список всех таблиц.                               

        public int AttrTableCount = 0; //Количество строк в таблице атрибутов.
        public string[,] AttrTable     = new string[1000, vBlockWhere + 1];
        public string[,] ListStateDate = new string[100, dStateDateCode + 1];
   
        //Готовый результат SQL. Собирается из таблицы Words. 
        public string SQL; 
        
        //JoinSQL - Код SQL с джойнами, который нужно вставить после главной сущности,
        //к которой относится код вычисляемого атрибута, в которомуом есть слово ПсевдонимСущности.
        //JoinSQL непустой когда есть что джойнить, например вот так: ПсевдонимСущности.Организация.ГлавноеЮЛ 
        //Если вот так: ПсевдонимСущности.Организация (то джойнить нечего - тут просто Сущность.Атрибут)
        //Иными словами JoinSQL нужно приджойнить к сущности на которую указывает ПсевдонимСущности.
        //JoinSQL Собирается из таблицы AttrTable. 
        public string JoinSQL;
        
        //Дата историчного атрибута по умолчанию - текущий день.
        public string LocalDate = "'" + ParserSys.ParserGetDateEndDay() + "'";
        
        #endregion Region. Константы для массивов и переменные.     
        
        #region Region. Инициализаци и подготовка к работе, вычисление времени.
        
        ///Парсинг. Только для теста. На выходе распарсенный запрос SourceMSQL.
        public string ParseTest(string MSQL, string PsevdonimEntity, string ServerType)   //SqlConnection connection
        {          
            //ParserData.ParserInitial(ServerType);    
            //Это буква С. Вместо номеров будем использовать код символы.
            //Всего букв 26, используем с третьей. 65-A.
            //Поэтому максимально 23 уровня вложенности вычисляемых атрибутов.
            //К подзапросам это не относится, так как они все парсятся скопом.
            string ResultSQL;
            string ResultJoinSQL;
            const int PsevdonimCountRecursionIN = 0;
            ParserData.TestDeep = 0;
            ParserData.PsevdonimSubQuery     = 1; 
            ParserData.SelectNumber          = 1;           
            ParseLocal(
                  MSQL,
                  ParserEnterMode.Test,
                 "C",
                  "EOT_1", 
                  PsevdonimEntity,
                  "01.02.2014",
                  PsevdonimCountRecursionIN,
                  null,
                  0,
                  out ResultSQL,
                  out ResultJoinSQL);
            return ResultSQL;
        }
        
        ///Парсинг. Главный метод. На выходе распарсенный запрос SourceMSQL.
        public string Parse(string MSQL, string ServerType)     //SqlConnection connection
        {                               
            //Инициализация констант для парсера. Это таблица сущностей и таблица атрибутов. Входные данные.
            //ParserData.ParserInitial(ServerType);
            string ResultSQL;
            string ResultJoinSQL;             
            ParserData.TestDeep = 0;
            ParserData.PsevdonimSubQuery     = 1; 
            ParserData.SelectNumber          = 1;            
            ParseLocal(MSQL, enterMode, "C", "", "", "", 0, null, 0, out ResultSQL, out ResultJoinSQL);
            return ResultSQL;
        }  
                      
        ///Эта функция для вызова из кода SQL.
        ///Получение кода SQL из кода MSQL.
        [SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
        public static SqlString ParsePipe(SqlString MSQL)
        {                                                       
            /*
            --Код рабочий, не удалять!:
            --Установка сборки Assembly на сервере:
            
            DROP FUNCTION dbo.fn_ParserMSQL;
            DROP PROCEDURE dbo.spen_ExecMSQL;
            DROP PROCEDURE dbo.spen_ParserRefresh;
            DROP ASSEMBLY [ParserDLL];
            CREATE ASSEMBLY ParserDLL FROM 'D:\Travin\ParserDLL.dll' WITH PERMISSION_SET = UNSAFE; --EXTERNAL_ACCESS
            
            GO
            --Функция парсинг MSQL --> SQL. На выходе текст SQL.
            CREATE FUNCTION dbo.fn_ParserMSQL(@MSQL NVARCHAR(1000))
            RETURNS  NVARCHAR(max)
            AS
            EXTERNAL NAME ParserDLL.[FBA.Parser].ParsePipe;
            GO
            
            
            --Процедура. парсинг MSQL --> SQL. И выполнение SQL. На выходе одна или несколько таблиц.
            CREATE PROCEDURE dbo.spen_ExecMSQL (@MSQL VARCHAR(MAX)) 
            AS 
            BEGIN
              --Пример: EXEC dbo.spen_ExecMSQL 'select top 10 * from ДокНаВхОплату'
              DECLARE @SQL VARCHAR(MAX) 
              SELECT @SQL = dbo.fn_ParserMSQL(@MSQL) 
              EXEC (@SQL)
            END;
            GO
            
            --Процедура обновления таблиц парсера, которомуую нужно запускать после обновления в структуре словарной таблицы.
            CREATE PROCEDURE dbo.spen_ParserRefresh
            AS EXTERNAL NAME ParserDLL.[FBA.Parser].ParserRefresh;
            
            --Проверка:
            SELECT dbo.fn_ParserMSQL('select top 10 * from ДокНаВхОплату')
            EXEC dbo.spen_ExecMSQL 'select top 10, (select top 1 CID from ContractIns) as fff from ДокНаВхОплату ' 
            */
           
            //Инициализация констант для парсера. Это таблица сущностей и таблица атрибутов. Входные данные.
            ParserData.ParserInitial("Pipe");                       
            string MSQL2 = Convert.ToString(MSQL);           
            var parser = new Parser();  
            string SQL = parser.ParseTest(MSQL2, "", "Pipe");  
            return SQL;         
        }                  
        
        ///Обновление таблиц парсера после внесения изменений в словарную систему.
        public static SqlInt32 ParserRefresh_test()
        {
            var DT = new System.Data.DataTable();
            const string SQL = "INSERT INTO [A_test] (id, num) VALUES (0, 100); SELECT count(*) as cnt FROM [A_test] ";
            ParserCon.PipeSelectDT(SQL, out DT);   
            if (DT.Rows.Count > 0) 
            {
                string cntstr = DT.Rows[0]["cnt"].ToString();
                int cntint = cntstr.ParserToInt();
                return cntint;
            }
            return 0;
        }
           
        ///Обновление таблиц парсера после внесения изменений в словарную систему.
        /*public static SqlInt32 ParserRefresh()
        {                                                                         
            const string SQL = "--===================================================================== " + ParserSys.CR +
                "--Подготовка таблиц для парсера.                                                       " + ParserSys.CR +
                
                "IF OBJECT_ID(N'tempdb..#EntityParent') IS NOT NULL DROP TABLE [dbo].[#EntityParent]    " + ParserSys.CR +
                "IF OBJECT_ID(N'tempdb..#EntityParser') IS NOT NULL DROP TABLE [dbo].[#EntityParser]    " + ParserSys.CR +
                "IF OBJECT_ID(N'tempdb..#AttrParent')   IS NOT NULL DROP TABLE [dbo].[#AttrParent]      " + ParserSys.CR +
                "IF OBJECT_ID(N'tempdb..#AttrParser')   IS NOT NULL DROP TABLE [dbo].[#AttrParser]      " + ParserSys.CR +
                "IF OBJECT_ID(N'tempdb..#AttrChild')    IS NOT NULL DROP TABLE [dbo].[#AttrChild]       " + ParserSys.CR +
                "IF OBJECT_ID(N'tempdb..#Entity')       IS NOT NULL DROP TABLE [dbo].[#Entity]          " + ParserSys.CR +
                "IF OBJECT_ID(N'tempdb..#Attr')         IS NOT NULL DROP TABLE [dbo].[#Attr]            " + ParserSys.CR +
                "IF OBJECT_ID(N'tempdb..#Attribute')    IS NOT NULL DROP TABLE [dbo].[#Attribute]       " + ParserSys.CR +
                
                "if exists (select * from dbo.sysobjects where id = object_id(N'[fbaEntityParser]'))    " + ParserSys.CR +
                "drop table [fbaEntityParser]                                                           " + ParserSys.CR +
                
                "if exists (select * from dbo.sysobjects where id = object_id(N'[fbaAttrParent]'))      " + ParserSys.CR +
                "drop table [fbaAttrParent]                                                             " + ParserSys.CR +                                                    
                "--=====================================================================                " + ParserSys.CR +
                 
                "--=====================================================================                " + ParserSys.CR +
                "--Таблица #EntityParser с сущностями.                                                  " + ParserSys.CR +
                "SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos, * INTO #EntityParser FROM enEntity          " + ParserSys.CR +
                "--=====================================================================                " + ParserSys.CR +   
                "ALTER TABLE #EntityParser ADD Table_ID varchar(100)                                    " + ParserSys.CR +
                "ALTER TABLE #EntityParser ADD Table_Name varchar(100)                                  " + ParserSys.CR +
                "ALTER TABLE #EntityParser ADD Table_IDFieldName varchar(100)                           " + ParserSys.CR +
                 "--=====================================================================               " + ParserSys.CR +                                                                                         
                "UPDATE #EntityParser SET Table_ID    = t2.ID,                                     " + ParserSys.CR +
                "                   Table_Name        = t2.Name,                                        " + ParserSys.CR +
                "                   Table_IDFieldName = t2.IDFieldName                                  " + ParserSys.CR +
                "FROM enTable t2 WHERE t2.TableEntityID = #EntityParser.ID AND t2.Type = 1              " + ParserSys.CR +
                "UPDATE #EntityParser SET Pos = Pos - 1                                                 " + ParserSys.CR +
                "--=====================================================================                " + ParserSys.CR +
                   
                "--=====================================================================                " + ParserSys.CR +     
                "--Таблица #EntityParent с деревом сущностей.                                           " + ParserSys.CR +
                ";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1, NumLevel) AS  " + ParserSys.CR +
                "      (                                                                                " + ParserSys.CR +
                "        SELECT                                                                         " + ParserSys.CR +
                "          ID AS EnChildID,                                                             " + ParserSys.CR +
                "          Brief AS EnBrief2,                                                           " + ParserSys.CR +
                "          ID as EnID,                                                                  " + ParserSys.CR +
                "          Brief as EnBrief1,                                                           " + ParserSys.CR +
                "          ParentID,                                                                    " + ParserSys.CR +
                "          Name as EnBriefName2,                                                        " + ParserSys.CR +
                "          Name as EnBriefName1,                                                        " + ParserSys.CR +
                "          0 as NumLevel                                                                " + ParserSys.CR +
                "        FROM enEntity                                                                  " + ParserSys.CR +
                "        UNION ALL                                                                      " + ParserSys.CR +
                "        SELECT                                                                         " + ParserSys.CR +
                "          EnChildID,                                                                   " + ParserSys.CR +
                "          EnBrief2,                                                                    " + ParserSys.CR +
                "          e.ID as EnID,                                                                " + ParserSys.CR +
                "          e.Brief as EnBrief1,                                                         " + ParserSys.CR +
                "          e.ParentID,                                                                  " + ParserSys.CR +
                "          p.EnBriefName2 as EnBriefName2,                                              " + ParserSys.CR +
                "          e.Name as EnBriefName1,                                                      " + ParserSys.CR +
                "          (p.NumLevel + 1) as NumLevel                                                 " + ParserSys.CR +
                "        FROM enEntity e INNER JOIN Parents p ON p.ParentID = e.ID                      " + ParserSys.CR +
                "      ) SELECT * INTO #EntityParent FROM Parents ORDER BY EnBrief2, EnBrief1;          " + ParserSys.CR +
                "--=====================================================================                " + ParserSys.CR +
                
                "ALTER TABLE #EntityParent ADD EnBrief2_TableName varchar(100);         --Главная таблица сущности EnBrief2.                  " + ParserSys.CR +
                "ALTER TABLE #EntityParent ADD EnBrief2_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief2.   " + ParserSys.CR +
                "ALTER TABLE #EntityParent ADD EnBrief1_TableName varchar(100);         --Главная таблица сущности EnBrief1.                  " + ParserSys.CR +
                "ALTER TABLE #EntityParent ADD EnBrief1_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief1.   " + ParserSys.CR +    
                "--=====================================================================                " + ParserSys.CR +
                
                "--Данные по таблице для сущности EnBrief2                                              " + ParserSys.CR +
                "UPDATE #EntityParent SET                                                               " + ParserSys.CR +
                "  #EntityParent.EnBrief2_TableName        = t1.Table_Name,                             " + ParserSys.CR +
                "  #EntityParent.EnBrief2_TableIDFieldName = t1.Table_IDFieldName                       " + ParserSys.CR +
                "FROM #EntityParser t1 WHERE #EntityParent.EnBrief2 = t1.Brief                          " + ParserSys.CR +
                "                                                                                       " + ParserSys.CR +
                "--Данные по таблице для сущности EnBrief1                                              " + ParserSys.CR +
                "UPDATE #EntityParent SET                                                               " + ParserSys.CR +
                "  #EntityParent.EnBrief1_TableName        = t1.Table_Name,                             " + ParserSys.CR +
                "  #EntityParent.EnBrief1_TableIDFieldName = t1.Table_IDFieldName                       " + ParserSys.CR +
                "FROM #EntityParser t1 WHERE #EntityParent.EnBrief1 = t1.Brief                          " + ParserSys.CR +
                "--=====================================================================                " + ParserSys.CR +
                
                "--=====================================================================                " + ParserSys.CR +
                "--Таблица #AttrParser с атрибутами                                                     " + ParserSys.CR +
                "SELECT                                                                                 " + ParserSys.CR +
                "  ID                AS ID,                                                             " + ParserSys.CR +
                "  EntityID          AS EntityID,                                                       " + ParserSys.CR +
                "  AttributeEntityID AS Attr_EntityID,                                                  " + ParserSys.CR +
                "  Name              AS Attr_Name,                                                      " + ParserSys.CR +
                "  Brief             AS Attr_Brief,                                                     " + ParserSys.CR +
                "  Type              AS Attr_Type,                                                      " + ParserSys.CR +
                "  Kind              AS Attr_Kind,                                                      " + ParserSys.CR +
                "  Mask              AS Attr_Mask,                                                      " + ParserSys.CR +
                "  Feature           AS Attr_Feature,                                                   " + ParserSys.CR +
                "  ObjectNameOrder   AS Attr_NameOrder,                                                 " + ParserSys.CR +
                "  Code              AS Attr_Code,                                                      " + ParserSys.CR +
                "  Description       AS Attr_Comment,                                                   " + ParserSys.CR +
                "  ID                AS Table_ID,                                                       " + ParserSys.CR +
                "  FieldName         AS Table_Field,                                                    " + ParserSys.CR +
                "  FieldName2        AS Table_Field2,                                                   " + ParserSys.CR +
                "  RefEntityID       AS Ref_EntityID,                                                   " + ParserSys.CR +
                "  RefAttributeID    AS Ref_AttrID                                                      " + ParserSys.CR +
                "INTO #AttrParser                                                                       " + ParserSys.CR +
                "FROM enAttribute                                                                       " + ParserSys.CR +
                     
                "ALTER TABLE #AttrParser ADD Table_Name varchar(100);          --Данные по таблице, в которой находится атрибут. Имя таблицы.   " + ParserSys.CR +
                "ALTER TABLE #AttrParser ADD Table_IDFieldName varchar(100);   --Данные по таблице, в которой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа)" + ParserSys.CR +
                "ALTER TABLE #AttrParser ADD Table_Type int;                   --Тип таблицы (Главная или Историчная)                           " + ParserSys.CR +
                "ALTER TABLE #AttrParser ADD Table_Feature int;                --Свойства таблицы.                                              " + ParserSys.CR +
                "ALTER TABLE #AttrParser ADD Ref_EntityBrief varchar(100);     --Сокращение сущности для атрибута Ссылки или Массива            " + ParserSys.CR +
                "ALTER TABLE #AttrParser ADD Ref_AttrBrief varchar(100);       --Сокращение атрибута сущности для атрибута Ссылки или Массива   " + ParserSys.CR +
                "ALTER TABLE #AttrParser ADD Ref_AttrName varchar(100);        --Наименование атрибута сущности для атрибута Ссылки или Массива " + ParserSys.CR +
                "ALTER TABLE #AttrParser ADD Attr_EntityBrief varchar(100);    --Сокращение сущности, к которой относится атрибут.              " + ParserSys.CR +
                
                                                                                                      
                "--Данные по таблице атрибута                                                           " + ParserSys.CR +
                "UPDATE #AttrParser SET                                                                 " + ParserSys.CR +
                "  #AttrParser.Table_Name        = t1.Name,                                             " + ParserSys.CR +
                "  #AttrParser.Table_IDFieldName = t1.IDFieldName,                                      " + ParserSys.CR +
                "  #AttrParser.Table_Feature     = t1.Feature,                                          " + ParserSys.CR +
                "  #AttrParser.Table_Type        = t1.Type                                              " + ParserSys.CR +
                "FROM enTable t1                                                                        " + ParserSys.CR +
                "WHERE #AttrParser.Table_ID = t1.ID                                                     " + ParserSys.CR +
                                                                                                        
                "--Данные для атрибута Ссылки или Массива.                                              " + ParserSys.CR +
                "UPDATE #AttrParser SET Ref_EntityBrief = t1.Brief FROM enEntity t1 WHERE #AttrParser.Ref_EntityID = t1.ID " + ParserSys.CR +
                "UPDATE #AttrParser SET Ref_AttrBrief   = t1.Brief,                                     " + ParserSys.CR +
                "                       Ref_AttrName    = t1.Name                                       " + ParserSys.CR +
                "FROM enAttribute t1                                                                    " + ParserSys.CR +
                "WHERE #AttrParser.Ref_AttrID = t1.ID and #AttrParser.Ref_EntityID = t1.AttributeEntityID         " + ParserSys.CR +
                
                "--Сущность атрибута                                                                    " + ParserSys.CR +
                "UPDATE #AttrParser SET Attr_EntityBrief = t1.Brief FROM enEntity t1 WHERE #AttrParser.Attr_EntityID = t1.ID " + ParserSys.CR +
                "--=====================================================================                " + ParserSys.CR +
                
                "--=====================================================================                " + ParserSys.CR +
                "--Таблица #AttrParent с атрибутами. Для каждой сущности весь полный список атрибутов, включая предков. " + ParserSys.CR +
                "SELECT ROW_NUMBER() OVER(ORDER BY EnBrief2) Pos, t1.*, t2.*                            " + ParserSys.CR +
                "  INTO #AttrParent FROM #AttrParser t1                                                 " + ParserSys.CR +
                "  LEFT JOIN #EntityParent t2 ON t2.EnID = t1.Attr_EntityID                             " + ParserSys.CR +
                "  ORDER BY EnBrief2, NumLevel desc, Table_Type, Table_Name, t1.Attr_Brief              " + ParserSys.CR +
                
                "UPDATE #AttrParent   SET Pos = Pos - 1                                                 " + ParserSys.CR +
                "--=====================================================================                " + ParserSys.CR +
                
                "--=====================================================================                " + ParserSys.CR +
                "--Таблица #AttrChild с атрибутами. Для каждой сущности список атрибутов потомков.      " + ParserSys.CR +
                "--Работает, но пока отключено.                                                         " + ParserSys.CR +
                "--SELECT ROW_NUMBER() OVER(ORDER BY Attr_EntityID, Attr_Brief) Pos, t1.*, t2.*         " + ParserSys.CR +
                "--  INTO #AttrChild FROM #AttrParser t1                                                " + ParserSys.CR +
                "--  RIGHT JOIN #EntityParent t2 ON t2.EnChildID = t1.Attr_EntityID AND t1.Attr_Brief IS NOT NULL --1716 Расчетный документ " + ParserSys.CR + 
                "--UPDATE #AttrChild SET Pos = Pos - 1                                                  " + ParserSys.CR +
                "--=====================================================================                " + ParserSys.CR +
                
                "--=====================================================================                " + ParserSys.CR +               
                "--Результат 2 таблицы.                                                                 " + ParserSys.CR + 
                "SELECT * INTO dbo.fbaEntityParser FROM #EntityParser                                   " + ParserSys.CR +
                "SELECT * INTO dbo.fbaAttrParent   FROM #AttrParent                                     " + ParserSys.CR +
                "SELECT 1                                                                               " + ParserSys.CR +                                                                                                     
                "--=====================================================================                " + ParserSys.CR;
               
            var DT = new System.Data.DataTable();
            ParserCon.PipeSelectDT(SQL, out DT);               
            return 0;               
         }*/                
        
        ///Парсинг. Главный метод. На выходе распарсенный запрос MSQLIN.
        private void ParseLocal(string MSQLIN,
                                ParserEnterMode enterModeIN, 
                                string PsevdonimSubQueryIN,                          
                                string PsevdonimAliasIN, 
                                string PsevdonimEntityBriefIN,
                                string PsevdonimStateDateIN,
                                int PsevdonimCountRecursionIN,
                                string[,] AttrTableIN,
                                int AttrTableCountIN,
                                out string ResultSQL,
                                out string ResultJoinSQL)
        {                                  
            ResultSQL = "";
            ResultJoinSQL = "";                                                
            if (PsevdonimCountRecursionIN > 10) return;
           
            this.MSQL                 = MSQLIN;
            this.enterMode            = enterModeIN;
            this.AttrTablePrev        = AttrTableIN;
            this.AttrTablePrevCount   = AttrTableCountIN;
            //this.PsevdonimSubQuery    = PsevdonimSubQueryIN;
            this.PsevdonimAlias       = PsevdonimAliasIN;
            this.PsevdonimEntityBrief = PsevdonimEntityBriefIN;
            this.PsevdonimStateDate   = PsevdonimStateDateIN;
            this.PsevdonimCountRecursion = PsevdonimCountRecursionIN + 1;
            if (enterMode == ParserEnterMode.Test) 
            {
                //ParseTimeSQL = new StringBuilder("", 255); //Время выполнения всех методов парсинга. 
                ParseTimeSQL = "";
                LocalStart = DateTime.Now; //Старт (Записываем время)
                TotalStart = DateTime.Now; //Старт (Записываем время)  
            }
                                 
            //1 часть.                                     
            ParseUserComment();          TimeElapsed("ParseUserComment1"); 
            if (CheckCommand()) 
            {
                ResultSQL = SQL;
                ResultJoinSQL = "";
                return;
            }
            
            ParseReplaceSymbol();        TimeElapsed("ParseReplaceSymbol");           
            ParseWords();                TimeElapsed("ParseWords");                             
            
            //2 часть.
            ArraySetEmpty();             TimeElapsed("ArraySetEmpty");               
            ParseBrace();                TimeElapsed("ParseBrace");
            SetLexType1();               TimeElapsed("SetLexType1");                               
            SetBraceNum();               TimeElapsed("SetBraceNum");            
            FindBlocks();                TimeElapsed("FindBlocks"); 
            FindAlias();                 TimeElapsed("FindAlias");            
            SetLexType2();               TimeElapsed("SetLexType2");              
            FindTablesForEntity();       TimeElapsed("FindTablesForEntity");
            GetListEntityAlias();        TimeElapsed("GetListEntityAlias");                           
            FindFirstAttr();             TimeElapsed("FindFirstAttr");     
            CorrectSelect();             TimeElapsed("CorrectSelect");     
            RestoreUserString();         TimeElapsed("RestoreUserString");
            SetStateDate();              TimeElapsed("SetStateDate");                   
            GetListTable();              TimeElapsed("GetListTable");   
   
            
            if (enterMode == ParserEnterMode.Test) 
            {
                DateTime TotalStop  = DateTime.Now;       //Elapsed = new TimeSpan();
                TimeSpan Elapsed = TotalStop.Subtract(TotalStart);
                //ParseTimeSQL.Append(Convert.ToString(Elapsed.TotalMilliseconds) + " - Общее время. " + ParserSys.CR); 
                ParseTimeSQL = ParseTimeSQL + Convert.ToString(Elapsed.TotalMilliseconds) + " - Общее время. " + ParserSys.CR;
            }
            ParserData.ParseCount++; //Счетчик распарсенных запросов. Просто так. 
            ResultSQL     = SQL;
            ResultJoinSQL = JoinSQL;
        }
                   
        
        public void ReturnTestTable(out System.Data.DataTable DTMain,
                                    out System.Data.DataTable DTEntity,
                                    out System.Data.DataTable DTTable,
                                    out System.Data.DataTable DTUserStr,
                                    out System.Data.DataTable DTAttrTable,
                                    out System.Data.DataTable DTStateDate)
        {                                                                                                                   
            //Главная таблица, в которой весь запрос.
            ParserSys.ParserArrayToDT(Words, 
                "wPos;" +
                "wLex;" + 
                "wDOCR;" + 
                "wReadySQL;" +                 
                "wBrace;" +             
                "wBraceLevel;" +       
                "wBraceNum;" +            
                "wSelect;" +            
                "wBlockEnd;" +           
                "wBlockWhere;" +         
                "wBlockFunc;" +   
                "wBlockCase;" +              
                "wProc;" +              
                "wLexType;" +                               
                "wAlias;" +                     
                "wEntity;" +              
                "wEntityAlias;" +       
                "wEntityID;" +                                                                 
                "wTableName;" +         
                "wTableField;" +         
                "wTableField2;" +                
                "wTableFieldID;" +       
                "wTableType;" +               
                "wTableAlias;" +        
                "wFirstAttrType;" +     
                "wAttrComplex;" +      
                "wAttrFirst;" +        
                "wAttrFull;" +                
                "wAttrType;" +           
                "wAttrKind;" +            
                "wAttrCode;" +                  
                "wUserString;" +              
                "wStateDate;" +          
                "wRef_EntityBrief;" +   
                "wCompareDotLevel;" +    
                "wCompareDotNum;"     
                 , out DTMain, 0, WordsCount, false);          
        
            //Список всех сущностей в запросе.  
            ParserSys.ParserArrayToDT(ListEntity, 
                "0.ePos;" +
                "1.eNum;" +
                "2.eLex;" +
                "3.eSelect;" +
                "4.eAlias;" +
                //"5.eBraceNum;" +
                "5.eStateDate", out DTEntity, 0, EntityCount, false);
            
            //Список таблиц, которые используются в запросе SQL.  
            ParserSys.ParserArrayToDT(ListTable, 
                "0.tPos;" +
                "1.Num;" +
                "2.TableName;" +
                "3.TableFieldID;" +
                "4.Alias;" +
                "5.Select;" +
                "6.Table Type;" +
                "7.LexType;" +
                "8.Entity;" +
                "9.EntityAlias;" +
                "10.StateDate;" +
                "11.AttrFull;" +
                "12.Proc;" +
                "13.Level;" +
                "14.CompareDotLevel;" +
                "15.CompareDotNum;" +
                "16.AttrPart;" +
                "17.JoinTableName;" +
                "18.JoinTableAlias;" +
                "19.JoinTableField", out DTTable, 0, TableCount, false);
    
            //Список строк пользователя в запросе.            
            ParserSys.ParserArrayToDT(ListUserStr, 
                "0.Pos;" +
                "1.Num;" +
                "2.RealString;" +
                "3.RealStringParse;" +
                "4.UserString", out DTUserStr, 0, ListUserStrCount, false);
        
              
            //Константы для массива AttrTable.                 
            ParserSys.ParserArrayToDT(AttrTable,
                "0.vPos;" +
                "1.vNum;" +
                "2.vAlias;" + 
                "3.vSelect;" +
                "4.vNumPart;" +
                "5.vLastPart;" +
                "6.vPsevdonim;" +
                "7.vEntity;" +
                "8.vEntityAlias;" +
                "9.vEntityID;" +
                "10.vEntityTableMain;" +
                "11.vEntityTableFieldID;" +
                "12.vRef_EntityBrief;" +
                "13.vAttrFull;" +
                "14.vAttrPartFull;" +
                "15.vAttrPartNoLast;" + 
                "16.vAttrPart;" +
                "17.vAttrType;" +
                "18.vAttrKind;" +
                "19.vAttrCode;" +
                "20.vTableName;" +
                "21.vTableType;" +
                "22.vTableField;" +
                "23.vTableField2;" +
                "24.vTableFieldID;" +
                "25.vTableAlias;" +
                "26.vTableAliasReplace;" +
                "27.vStateDate;" +                               
                "28.vJoinTableName;" +
                "29.vJoinTableAlias;" +
                "30.vJoinTableFieldID;" +                                                    
                "31.vJoinSQL;" +                            
                "32.vAttrSQL;" +
                "33.vSubJoinSQL;" +
                "34.vSubSQL;" + 
                "35.vNumSub;" + 
                "36.vPosSub;" +
                "37.vBlockWhere", out DTAttrTable, 0, AttrTableCount + 20, false);
            
            //Список ListSateDate.
            ParserSys.ParserArrayToDT(ListStateDate, 
                 "0.dPos;" +
                 "1.dNum;" +
                 "2.dSelect;" +
                 "3.dEntityBrief;" +
                 "4.dEntityAlias;" +
                 "5.dStateDate1;" +
                 "6.dStateDateBeg;" + 
                 "7.dStateDateEnd;" +
                 "8.dStateDateCode",
                 out DTStateDate, 0, StateDateCount, false);
        }
       
        ///Вычисление времени выполнения метода.  
        private void TimeElapsed(string Operation = "")
        {         
            if (enterMode != ParserEnterMode.Test) return;
            TimeSpan Elapsed = DateTime.Now.Subtract(LocalStart);
            LocalStart  = DateTime.Now; 
            //ParseTimeSQL.Append(Convert.ToString(Elapsed.TotalMilliseconds) + " - " + Operation + ParserSys.CR);  
            ParseTimeSQL = ParseTimeSQL + Convert.ToString(Elapsed.TotalMilliseconds) + " - " + Operation + ParserSys.CR;
        }
        
        #endregion Region. Инициализаци и подготовка к работе, вычисление времени. 
        
        #region Region. Работа со строкой.
                       
        ///Замена комментариев. Таких: /*Комментарий*/
        private bool ParseUserComment()
        {                   
            try
            {                              
                //Строка с одинарными кавычками 'aaa'.
                bool InStr1   = false;
                int StrBegin1  = -1; 
                int StrEnd1    = -1;            
                
                //Строка с двойными кавычками "aaa".
                bool InStr2   = false;
                int StrBegin2  = -1; 
                int StrEnd2    = -1; 
                
                //№1. Такой коментарий: --Комментарий
                bool InCom1   = false; 
                int ComBegin1 = -1;
                int ComEnd1   = -1;
               
                //№2. Такой коментарий: /*Комментарий*/ 
                bool InCom2   = false;             
                int ComBegin2 = -1;
                int ComEnd2   = -1;
                                                    
                int[] StackInt = new int[100]; 
                int StackIntI = 0;         
                MSQL = MSQL + " ";
                for (int i = 0; i < MSQL.Length - 1; i++) 
                {
                    char ch1 = MSQL[i];
                    char ch2 = MSQL[i + 1];                          
                    int b0 = (int)ch1;
                    int b1 = (int)ch2;
                    
                    //Если в тексте после 
                    if ((b0 != 13) && (b1 == 10))
                    {                    
                        MSQL = MSQL.Insert(i + 1, ((char)13).ToString());
                        if (i > 0) i--;
                        continue;                   
                    }
                    
                    //Если перенос строки и до этого мы были в комментарии №1, то удаляем этот комментарий.
                    if ((b0 == 13) && (b1 == 10))
                    {
                        if (InCom1)
                        {
                            ComEnd1 = i;
                            MSQL = MSQL.Remove(ComBegin1, ComEnd1 - ComBegin1);
                            i = ComBegin1 - 1; 
                            InCom1 = false;
                            continue;
                        }
                    }                               
                    
                    //Если внутри строки, то двойные кавычки пропускаем.
                    if ((ch1 == '\'') && (ch2 == '\'') && (InStr1))
                    {
                        i = i + 1;
                        continue;                  
                    }            
                    
                    //Если внутри строки, то двойные кавычки пропускаем.
                    if ((ch1 == '"') && (ch2 == '"') && (InStr2))
                    {
                        i = i + 1;
                        continue;                  
                    }                                                    
                    
                    //Если кавычка одна (текущий знак), 
                    //или следующий знак кавычка, и следующий знак - это последний символ в тексте.
                    if (ch1 == '\'') // && (i == (MSQL.Length - 2))))
                    {                                                        
                        //Если внутри комментриев, то любое кол-во кавычек пропускаем.
                        if (InCom1) continue;
                        if (InCom2) continue;                                      
                        if (InStr2) continue; 
                        
                        InStr1 = !InStr1;
                        //Если кавычка одна, то если не встроке, то считаем что теперь мы в строке.
                        if (InStr1)  
                        {
                            StrBegin1 = i;
                            continue;
                        }
                                                              
                        //Если строка закрылась, то переносим в массив строк.
                        //тесты: 
                        //= 'Дке'
                        StrEnd1 = i;                   
                        ListUserStr[ListUserStrCount, sPos] = ListUserStrCount.ToString("D3");
                        ListUserStr[ListUserStrCount, sRealString] = MSQL.Substring(StrBegin1, StrEnd1 - StrBegin1 + 1);
                        ListUserStr[ListUserStrCount, sUserString] = "USERSTR" + ListUserStrCount.ToString("D6");
                        MSQL = MSQL.Remove(StrBegin1, StrEnd1 - StrBegin1 + 1);
                        MSQL = MSQL.Insert(StrBegin1, "USERSTR" + ListUserStrCount.ToString("D6"));
                        i = (i - (StrEnd1 - StrBegin1 + 1));
                        ListUserStrCount ++;
                        continue;
                    }                 
                    
                    //Если кавычка одна (текущий знак), 
                    //или следующий знак кавычка, и следующий знак - это последний символ в тексте.
                    if (ch1 == '"') // || ((ch2 == '"') && (i == (MSQL.Length - 2))))
                    {                                                        
                        //Если внутри комментриев, то любое кол-во кавычек пропускаем.
                        if (InCom1) continue;
                        if (InCom2) continue;                                      
                        if (InStr1) continue; 
                        
                        InStr2 = !InStr2;
                        //Если кавычка одна, то если не встроке, то считаем что теперь мы в строке.
                        if (InStr2)  
                        {
                            StrBegin2 = i;
                            continue;
                        }
                                                              
                        //Если строка закрылась, то переносим в массив строк.
                        StrEnd2 = i;                     
                        ListUserStr[ListUserStrCount, sPos] = ListUserStrCount.ToString("D3");
                        ListUserStr[ListUserStrCount, sRealString] = MSQL.Substring(StrBegin2, StrEnd2 - StrBegin2 + 1);
                        ListUserStr[ListUserStrCount, sUserString] = "USERSTR" + ListUserStrCount.ToString("D6");                  
                        MSQL = MSQL.Remove(StrBegin2, StrEnd2 - StrBegin2 + 1);
                        MSQL = MSQL.Insert(StrBegin2, "USERSTR" + ListUserStrCount.ToString("D6")); 
                        i = (i - (StrEnd2 - StrBegin2 + 1));
                        ListUserStrCount ++;
                        continue;
                    }
                    
                    //Если два минуса подряд, и мы не в любом из двух комментариев, то зачит теперь мы в комментарии №1.
                    if ((ch1 == '-') && (ch2 == '-'))
                    { 
                        if ((InCom1) || (InCom2) || (InStr1) || (InStr2)) continue;
                        InCom1 = true;
                        ComBegin1 = i;                                                                
                        continue;                         
                    }
                    
                    if ((ch1 == '/') && (ch2 == '*'))
                    { 
                        if ((InCom1) || (InStr1) || (InStr2)) continue;
                        InCom2 = true;  
                        StackIntI = StackIntI + 1;                        
                        StackInt[StackIntI] = i;                                              
                        i = i + 1;                     
                    }
                    
                    if ((ch1 == '*') && (ch2 == '/'))
                    {                                          
                        if ((InCom1) || (InStr1) || (InStr2))            
                        {                                    
                             i = i + 1;
                             continue;
                        } 
                              
                        if (StackIntI == 0)
                        {
                            ParserSys.ParserSM("Ошибка: закрытие многострочного комментария без его открытия");
                            return false; 
                        }                         
                                                 
                        ComBegin2  = StackInt[StackIntI];
                        StackIntI = StackIntI - 1;
                        ComEnd2 = i;
                        MSQL = MSQL.Remove(ComBegin2, ComEnd2 - ComBegin2 + 2);
                        i = ComBegin2 - 1;                                        
                        if (StackIntI == 0) InCom2 = false; 
                        continue;
                    }                             
                }
                
                if (InCom1) 
                {
                     ComEnd1 = MSQL.Length;
                     MSQL = MSQL.Remove(ComBegin1, ComEnd1 - ComBegin1); 
                     InCom1 = false;
                }
                
                if (InCom2) 
                {
                     ComEnd2 = MSQL.Length;
                     MSQL = MSQL.Remove(ComBegin2, ComEnd2 - ComBegin2); 
                     InCom2 = false;
                }  
                
                //if (MyStack.Count > 0)
                if (StackIntI == 0)
                {
                    ParserSys.ParserSM("Ошибка: не закрыт многострочный комментарий /* ");
                    return false;
                }
                                       
                MSQL = MSQL.Trim();
                ParserSys.ParserSM(MSQL);
                return true;
            }
            catch (Exception ex)
            {
                //ParserSys.ParserSM("Ошибка разбора кавычек: " + ex.Message);
                ParserSys.ParserSM("Ошибка разбора кавычек: " + ex.Message);
                return false;
            }
            
            //string a = "ABCDEFАБВГДЕ";
            //byte[] b = Encoding.Default.GetBytes(a);
            //public string Psevdonim  string c = ((char)67).ToString();            
        }
        
        ///Проверка на некоторые команды для отладки.
        private bool CheckCommand()
        {
            int FindAttr = MSQL.IndexOf(".Атрибуты", StringComparison.OrdinalIgnoreCase);
            int FindInfo = MSQL.IndexOf(".Инфо", StringComparison.OrdinalIgnoreCase);
            if ((FindAttr == -1) && (FindInfo == -1)) return false;                      
            if (MSQL.ParserCountChar('.') != 1) return false;           
            string EntityBrief = MSQL.ParserStrBeforeStr(".");
            if (FindAttr > -1) 
            {
                SQL = ParserData.GetSQLAttr(EntityBrief);
                return true;
            }
            if (FindInfo > -1) 
            {
                SQL = ParserData.GetSQLEntity(EntityBrief);
                return true;
            }
            return false;
        }
        
        ///Отделяем все знаки друг от друга, чтобы определить ключевые слова.
        private void ParseReplaceSymbol()
        {               
            //sys.SM(MSQL);
            //return;
            //Например если стоит вот так 1+(select, то после будет 1 + ( select
            //Это нужно чтобы разделить на отдельные слова.               
            MSQL = MSQL.Replace(ParserSys.CR, " ")
                               .Replace("\t", "")
                               .Replace(@"=", @" = ")
                               .Replace(@"*", @" * ")
                               .Replace(@"-", @" - ")
                               .Replace(@"+", @" + ")
                               .Replace(@"/", @" / ")
                               .Replace(@"\", @" \ ")
                               .Replace(@"(", @" ( ")
                               .Replace(@")", @" ) ")
                               .Replace(@",", @" , ")
                               .Replace(">",  @" > ")
                               .Replace("<",  @" < ")
                               .Replace(";",  @" ; ");
            //Меняем обратно если * означает выбор атрибутов.
            MSQL = MSQL.Replace(". *", ".*") + " ";      
        }
       
        ///Разделяем на слова.
        private void ParseWords()
        {                                                                                               
            //В следующией строке удаляются все пробелы
            string[] WordList = MSQL.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            WordsCount = 0;
            Array.Clear(Words, 0, Words.Length);//очищаем

            for (int i = 0; i < WordList.Length; i++)
            {              
                string Str = WordList[i]; 
                Words[WordsCount, wPos] = WordsCount.ToString("D4");
                //Все варианты JOIN:
                //JOIN             A ON b=c
                //LEFT  JOIN       A ON b=c 
                //RIGHT JOIN       A ON b=c 
                //FULL  JOIN       A ON b=c 
                //INNER JOIN       A ON b=c   
                //LEFT  OUTER JOIN A ON b=c
                //RIGHT OUTER JOIN A ON b=c
                //FULL  OUTER JOIN A ON b=c
                //CROSS       JOIN A ON b=c
                             
                string UpperStr1 = Str.ToUpper();
                string UpperStr2 = "";
                string UpperStr3 = "";
                string UpperStr4 = "";                           
                if (i < (WordList.Length - 1)) UpperStr2 = WordList[i + 1].ToUpper();
                if (i < (WordList.Length - 2)) UpperStr3 = WordList[i + 2].ToUpper(); 
                if (i < (WordList.Length - 3)) UpperStr4 = WordList[i + 3].ToUpper(); 
                
                if ((UpperStr1 == "UNION") && (UpperStr2 == "ALL"))
                {                                                                 
                    Str = "UNION ALL";
                    i++;                    
                } else
                if (UpperStr1 == "GROUP")
                {
                    Str = "GROUP BY";
                    i++;
                } else
                if (UpperStr1 == "ORDER")
                {
                    Str = "ORDER BY";
                    i++;
                } else                                 
                if (UpperStr1 == "LEFT")
                {     
                    if (UpperStr2 == "JOIN")
                    {
                        Str = "LEFT OUTER JOIN";
                        i++; 
                    }
                    if ((UpperStr2 == "OUTER") && (UpperStr3 == "JOIN"))
                    {
                        Str = "LEFT OUTER JOIN";
                        i = i + 2; 
                    }                     
                } else
                if (UpperStr1 == "RIGHT")
                {                   
                    if (UpperStr2 == "JOIN")
                    {
                        Str = "RIGHT OUTER JOIN";
                        i++; 
                    }
                    if ((UpperStr2 == "OUTER") && (UpperStr3 == "JOIN"))
                    {
                        Str = "RIGHT OUTER JOIN";
                        i = i + 2; 
                    }                     
                } else  
                if (UpperStr1 == "FULL")
                {               
                    if (UpperStr2 == "JOIN")
                    {
                        Str = "FULL OUTER JOIN";
                        i++; 
                    }
                    if ((UpperStr2 == "OUTER") && (UpperStr3 == "JOIN"))
                    {
                        Str = "FULL OUTER JOIN";
                        i = i + 2; 
                    }                     
                } else
                if (UpperStr1 == "JOIN")
                {
                    Str = "INNER JOIN";                                                                              
                } else   
                if ((UpperStr1 == "INNER") && (UpperStr2 == "JOIN"))
                {                                     
                    Str = "INNER JOIN";
                    i++;                                                         
                } else  
                if ((UpperStr1 == "CROSS") && (UpperStr2 == "JOIN"))
                {                                                         
                    Str = "CROSS JOIN";
                    i++;                                                           
                } else
                if ((UpperStr1 == "WITH") && (UpperStr2 == "(") && (UpperStr3 == "NOLOCK") && (UpperStr4 == ")")) 
                {                                                      
                    Str = "WITH (NOLOCK)";  
                    i = i + 3;                                                                           
                } else
                if ((UpperStr1 == "DROP") && (UpperStr2 == "TABLE"))
                {                                                             
                    Str = "DROP TABLE";
                    i++;                   
                } else              
                if ((UpperStr1 == "IS") && (UpperStr2 == "NULL"))
                {                                                                              
                    Str = "IS NULL";
                    i++;                    
                } else              
                if ((UpperStr1 == "IS") && (UpperStr2 == "NOT") && (UpperStr3 == "NULL"))
                {                                                                               
                    Str = "IS NOT NULL";
                    i = i + 2;                  
                } else
                if ((UpperStr1 == ">") && (UpperStr2 == "="))
                {                                                                               
                    Str = ">=";
                    i++;                  
                } else
                if ((UpperStr1 == "<") && (UpperStr2 == "="))
                {                                                                               
                    Str = "<=";
                    i++;                  
                } else
                if ((UpperStr1 == "<") && (UpperStr2 == ">"))
                {                                                                               
                    Str = "<>";
                    i++;                  
                } else
                if ((UpperStr1 == "PARTITION") && (UpperStr2 == "BY"))
                {                                                                               
                    Str = "PARTITION BY";
                    i++;                  
                } 
                     
                
                Words[WordsCount, wLex] = Str;              
                WordsCount++;
            }                                          
        }
       
        ///Присвоение для ячеек массивов пустой строки.
        private void ArraySetEmpty()
        {
            //Это нужно делать когда уже известен WordCount.    
            for (int i = 0; i < WordsCount; i++)
                for (int j = 3; j < WordsX; j++) Words[i, j] = "";
        }
        
        #endregion Region. Работа со строкой.                
        
        #region Region. Вспомогательные процедуры работы с массивом Words общего назначения. 
               
        ///Поиск последнего значения BraceNum в таблице.
        private int FindLastBraceNum(string BraceNum)
        {
            for (int i = WordsCount - 1; i > -1 ; i--)
            if (Words[i, wBraceNum] == BraceNum) return i;
            return -1;
        }
        
        ///Поиск последнего значения BraceNum в таблице.
        private int FindLastSelect(string SelectLocal)
        {
            for (int i = WordsCount - 1; i > -1 ; i--)
            if (Words[i, wSelect] == SelectLocal) return i;
            return -1;
        }
                    
        #endregion Region. Вспомогательные процедуры работы с массивом Words общего назначения. 
               
        #region Region. Разбор запроса: Тип лексемы, Установка номера скобок. 
        
        //Чтобы несколько значений в ячейке wProc.
        ///Этот метод нужен для отладки кода, в реальной работе лучше раскомментировать return.        
        private void SetwProc(int Pos, string ValueProc)
        {
            //return
            if (Words[Pos, wProc] != "") Words[Pos, wProc] = Words[Pos, wProc] + "," + ValueProc;
            else Words[Pos, wProc] = ValueProc;
        }
        
        ///Тип лексемы. Проставление по таблице лексем.                          
        private void SetLexType1()
        {                    
            for (int i = 0; i < WordsCount; i++)
            {
                Words[i, wLexType] = "";
                for (int j = 0; j < ParserData.LexTable.GetLength(0); j++)
                {                                 
                    //Debug.WriteLine("hhg: {0}", i.ToString());
                    if ((Words[i, wLex].ToUpper() == ParserData.LexTable[j, 1]) ||
                        (Words[i, wLex].ToUpper() == ParserData.LexTable[j, 2]))
                    {
                        SetwProc(i, "KEY");
                        Words[i, wLex]     = ParserData.LexTable[j, 1];
                        Words[i, wLexType] = ParserData.LexTable[j, 3]; //Тип лексемы.
                        break;
                    }                  
                }                
               
                //Ставим признак числа 
                decimal ires;                 
                if (Decimal.TryParse(Words[i, wLex].Replace(".", ","), out ires)) Words[i, wLexType] = "NUM";
            }         
        }
                       
        ///Поиск скобок.
        private void ParseBrace()
        {             
            //Тест: select ((((1+2)+3)+((4+5)))+(6+(7+8)+(9)))
            //var MyStack = new Stack<int>();
            int[] StackInt = new int[1000]; //Всего 1000 пар скобок
            int StackIntI = 0;  
            
            int N;
            int Level = 1;                                                
            for (int i = 0; i < WordsCount; i++)
            {                                  
                if (Words[i, wLex] == "(") 
                {
                    //MyStack.Push(i);
                    StackIntI = StackIntI + 1;
                    StackInt[StackIntI] = i;                   
                    Level++;                        
                    Words[i, wBraceLevel] = Level.ToString();
                    Words[i, wBraceNum]   = Level.ToString();
                    BraceLevelCount++;    //Максимальный уровень вложенности.                   
                }  else
                if (Words[i, wLex] == ")") 
                {
                    //if (MyStack.Count > 0)
                    if (StackIntI > 0)
                    {
                        //N = MyStack.Pop();
                        N = StackInt[StackIntI];
                        StackIntI = StackIntI - 1;
                        Words[i, wBrace] = N.ToString();
                        Words[N, wBrace] = i.ToString();
                        Words[i, wBraceLevel] = Level.ToString();
                        Words[i, wBraceNum]   = Level.ToString();
                        Level--;                        
                    }                     
                     
                } else
                {
                    Words[i, wBraceLevel] = Level.ToString();
                    Words[i, wBraceNum]   = Level.ToString(); 
                }
            }                                    
        }
        
        ///Замена значения BraceNum. Метод используется только в SetBraceNum.
        private void ReplaceBraceNum(int iBeg, int iEnd, string OldValue, string NewValue)
        {
            for (int i = iBeg; i <= iEnd; i++)
              if (Words[i, wBraceNum] == OldValue) Words[i, wBraceNum] = NewValue;                                      
        }
        
        ///Установка номера скобок. Это не уровень вложенности, а номер вложенности.              
        private void SetBraceNum()
        {                                              
            //return;
            //Пример: (111(222)111(222)111((333)222)111) - это BraceLevel.
            //Пример: (111(222)111(333)111((444)555)111) - это BraceNum.
            //BraceNum - нужен для того чтобы определить: если два слова находятся в одном BraceNum - то это ТОЧНО части одного SELECT.
            //BraceLevel - не дает ответа на этот вопрос (какие части относятся к данному SELECT), потому что внутри одно SELECT могут быть вложенные SELECT,
            //а BraceLevel у двух вложенных SELECT будут ОДИНАКОВЫЕ, на примере это 222.           
            BraceNumCount = 2;            
            for (int i = 0; i < WordsCount; i++)
            {              
                if (Words[i, wLex] == "(")
                {                                     
                    ReplaceBraceNum(i, Words[i, wBrace].ParserToInt(), Words[i, wBraceNum], BraceNumCount.ToString());
                    //Замена значения BraceNum.                     
                    //for (int j = i; j <= N; j++)
                    //{
                    //    if (Words[j, BraceNum] == Words[i, BraceNum]) Words[j, BraceNum] = BraceNumMax.ToString();    
                    //}                                        
                    BraceNumCount++;
                }
            }             
        } 
        
        #endregion Region. Разбор запроса: Тип лексемы, Установка номера скобок. 
        
        #region Region. Поиск конца блоков, Поиск Алиасов, Проставление ENTITY, ATTR.       
              
        ///Проставляем номера SELECT.
        /*private void FindSelect(int Pos)
        {                         
            string BraceNumLocal = Words[Pos, wBraceNum];          
            int StopPosition = WordCount;
            if ((Pos > 1) && (Words[Pos - 1, wLex] == "(")) StopPosition = Words[Pos - 1, wBrace].ParserToInt();
            for (int i = Pos; i < StopPosition; i++)
            {
                if ((Words[i, wLexType] == "UNION") && (Words[Pos, wBraceNum] == BraceNumLocal)) break;               
                if ((i < (StopPosition - 1)) && (Words[i, wLex] == "(") && (Words[i + 1, wLex] == "SELECT")) 
                {
                    Words[i, wSelect] = ParserData.SelectNumber.ToString();
                    int i2 = Words[i, wBrace].ParserToInt() -  1;   
                    if ((i2 > 0) && (i2 < StopPosition)) i = i2;
                    continue;
                }               
                Words[i, wSelect] = ParserData.SelectNumber.ToString();
            }                                            
            ParserData.SelectNumber++;                                                                         
        }*/
        
        ///Проставляем номера SELECT.
        private void FindSelect()
        {                                          
            int StopPosition;           
            for (int i = 0; i < WordsCount; i++)
            {
                if (Words[i, wLex] != "SELECT") continue;                
                int LevelSelect = Words[i, wBraceLevel].ParserToInt();
                if ((i > 1) && (Words[i - 1, wLex] == "(")) StopPosition = Words[i - 1, wBrace].ParserToInt();
                else StopPosition = WordsCount;
                for (int i1 = i; i1 < StopPosition; i1++)
                {
                    int LevelCurrent = Words[i1, wBraceLevel].ParserToInt();
                    if (LevelCurrent < LevelSelect) continue;
                    if (Words[i, wLexType] == "UNION") break;
                    Words[i1, wSelect] = ParserData.SelectNumber.ToString();
                }
                ParserData.SelectNumber++;
            }                                                                                                                                
        }
      
        ///Поиск конца блоков.
        private void FindBlock(int Pos, string BlockName)
        {                              
            int InCase = 0;                        
            string SelectLocal = Words[Pos, wSelect];
            for (int i = (Pos + 1); i < WordsCount; i++)           
            {                                                
                if (Words[i, wSelect] != SelectLocal) continue;
                string Lex     = Words[i, wLex];
                string LexType = Words[i, wLexType];
                                
                //Поиск конца JOIN.
                if (BlockName == "JOIN")
                {                                         
                    if (Words[Pos + 1, wLex] != "(")
                    {
                        Words[Pos + 1, wLexType] = "ENTITY";
                        SetwProc(Pos + 1, "JOIN1");
                        Words[Pos + 1, wEntity]  = Words[Pos + 1, wLex];
                        
                        if (Words[Pos + 3, wLex] == "ON")
                        {
                            SetwProc(Pos + 2, "ALIAS29");
                            Words[Pos + 2, wLexType] = "ALIAS";
                        }
                        
                    }                    
                    return;                                 
                }         
                
                //Поиск конца CASE.
                if (BlockName == "CASE")
                {                                         
                    if (Words[i - 1, wLex] == "CASE") InCase++;
                    if (Words[i - 1, wLex] == "END")  InCase--; 
                    
                    if (InCase > 0) 
                    {
                        Words[i - 1, wBlockCase] = "1";
                        continue;
                    }
                    return;                                                 
                }        
                
                //Поиск конца FROM.               
                if (BlockName == "FROM")
                {                                                               
                    if (LexType == "KEY")
                    {
                        Words[Pos, wBlockEnd] = (i - 1).ToString();
                        return;
                    }
                    
                    //Если после FROM скобка, то поиск закрывающей скобки.
                    if (Lex == "(")
                    {
                        Words[Pos + 1, wBlockEnd] = Words[i, wBrace];
                        int iBrace = Words[i, wBrace].ParserToInt() + 1;
                        if ((iBrace > Pos) && (iBrace < WordsCount)) i = iBrace;
                        SetwProc(i, "ALIAS30");
                        Words[i, wLexType] = "ALIAS";
                        continue;                         
                    }
                                        
                    if (LexType == "")
                    {
                        //После ENTITY может следовать только Алиас, 
                        //запятая или одно из ключевых слов WHERE, UNION, JOIN.
                        SetwProc(i, "ENTITY2");
                        Words[i, wLexType] = "ENTITY";
                        Words[i, wEntity]  = Words[i, wLex];                                    
                        if (Words[i + 1, wLexType] == "KEY") return;
                        if (Words[i + 1, wLexType] == "JOIN") return;                         
                        if (Words[i + 1, wLexType] != "SIGN")
                        {
                            Words[i + 1, wLexType] = "ALIAS";                           
                            i++; //Чтобы пропустить следующую лексему.
                        }                                                                      
                    }                       
                }
                                                                          
                //Поиск конца WHERE.
                if (BlockName == "WHERE")
                {
                    //Words[i, wBlockWhere] = "1";
                    if ((Lex == "GROUP BY") || (Lex == "ORDER BY") || (Lex == "UNION"))
                    {
                        Words[Pos, wBlockEnd]   = (i - 1).ToString();                
                        return;
                    }        
                }                                              
            } 
             
            int i1 = FindLastSelect(SelectLocal);
            if (Words[i1, wLex] == ")") Words[Pos, wBlockEnd] = (i1 - 1).ToString();
                else Words[Pos, wBlockEnd] = i1.ToString();           
        }                          
               
        ///Установка конца блоков.
        private void FindBlocks()
        { 
               
            //for (int i = 0; i < WordCount; i++)
            //    if (Words[i, wLex] == "SELECT") FindSelect(i);                           
            FindSelect();
            //Чтобы определить где проставлять алиасы для атрибутов, а где не нужно.            
            bool InSelect = false;
            for (int i = 0; i < WordsCount; i++)
            {
                if (Words[i, wLex]      == "SELECT") InSelect = true;                   
                
                if ((Words[i, wLex]     == "FROM")     ||
                    (Words[i, wLexType] == "JOIN")     ||
                    (Words[i, wLex]     == "ON")       ||
                    (Words[i, wLex]     == "WHERE")    ||
                    (Words[i, wLex]     == "GROUP BY") ||
                    (Words[i, wLex]     == "ORDER BY")) InSelect = false; 
                if (!InSelect) Words[i, wBlockWhere] = "1";
            }
            
            //Поиск блоков.
            for (int i = 0; i < WordsCount; i++)
            {                              
                if (Words[i, wLexType] == "JOIN") FindBlock(i, "JOIN"); //Все виды JOIN
                //if (Words[i, Lex] == "TOP")      FindBlock(i, "TOP");
                //if (Words[i, Lex].IndexOf("ДАТАСОСТОБЪЕКТА", StringComparison.OrdinalIgnoreCase) > -1) FindBlock(i, "StateDate");
                if (Words[i, wLex] == "FROM")     FindBlock(i, "FROM");  
                if (Words[i, wLex] == "CASE")     FindBlock(i, "CASE");  
                //if (Words[i, Lex] == "ON")       FindBlock(i, "ON");                     
                if (Words[i, wLex] == "WHERE")    FindBlock(i, "WHERE");     
                //if (Words[i, Lex] == "GROUP BY") FindBlock(i, "GROUP BY");
                //if (Words[i, Lex] == "ORDER BY") FindBlock(i, "ORDER BY");                 
            }            
        }       
        
        ///Поиск Алиасов.
        private void FindAlias()
        {                                     
            for (int i = 0; i < WordsCount; i++)  Words[i, wAlias] = "";
            for (int i = 2; i < WordsCount; i++)
            {
                //Поиск если стоит AS.                 
                //Words[i + 1, wLex] != "(" - Это нужно если у нас чистый SQL, там бывает ситуация с WITH и используется AS.                              
                if ((Words[i, wLex] == "AS") && (Words[i + 1, wLex] != "(")) //!!!
                {                                                                                          
                    SetwProc(i, "ALIAS1");
                    Words[i, wLexType]     = "NOTUSE";
                   
                    SetwProc(i + 1, "ALIAS2");  
                    Words[i + 1, wLexType] = "NOTUSE";
                    
                    if (Words[i - 1, wLex] == "(") continue; //Это нужно если у нас чистый SQL, там бывает ситуация с WITH и используется AS.
                    SetwProc(i - 1, "ALIAS3");
                    Words[i - 1, wAlias]   = Words[i + 1, wLex];
                    continue;
                } 
                
                //Поиск после FROM.
                if ((Words[i, wLex] == "(") && (Words[i - 1, wLex] == "FROM"))
                {                  
                    //Words[IntAdd(Words[i, Brace], 1), Proc]    = "ALIAS 2";
                    //Words[IntAdd(Words[i, Brace], 1), LexType] = "ALIAS";
                    int Pos = Words[i, wBrace].ParserToInt() + 1;
                    SetwProc(Pos, "ALIAS4");
                    Words[Pos, wLexType] = "ALIAS";
                    continue;
                }
                
                if ((Words[i - 1, wLexType] == "ENTITY") && (Words[i, wLexType] == "ALIAS")) 
                {
                    SetwProc(i, "NOTUSE1.1");
                    SetwProc(i - 1, "NOTUSE1.2"); 
                    Words[i - 1, wAlias]       = Words[i, wLex];
                    Words[i - 1, wEntityAlias] = Words[i, wLex];                                         
                    Words[i, wLexType] = "NOTUSE"; 
                    continue;
                }
                                                  
                //Если два элемена подряд не имеют LexType, то второй элемент - это Алиас первого.
                if ((Words[i,      wLexType] == "")    && 
                    (Words[i - 2,  wLex]     != "TOP") && 
                    ((Words[i - 1, wLexType] == "") || (Words[i - 1, wLexType] == "NUM") || (Words[i - 1, wLex] == ")") ))
                {                                              
                    SetwProc(i, "NOTUSE3.1");  
                    SetwProc(i, "NOTUSE3.2");                     
                    Words[i - 1, wAlias] = Words[i,  wLex];                            
                    Words[i, wLexType]   = "NOTUSE";                       
                    continue;     
                }
            }   
        }             
              
        ///Проставление LexType
        private void SetLexType2()
        {                                      
            for (int i = 0; i < WordsCount; i++)
            {   
                //Строки пользователя.                
                if (Words[i, wLexType] != "NOTUSE")
                if (Words[i, wLex].IndexOf("USERSTR", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    SetwProc(i, "USERSTR20");
                    Words[i, wLexType] = "USERSTR";
                }
                                
                //Находим атрибуты.            
                if ((Words[i, wLexType] == "") && (Words[i + 1, wLex] != "("))
                {                   
                    SetwProc(i, "ATTR1");
                    Words[i, wLexType] = "ATTR";
                    continue;
                }                                         
            } 
            
            for (int i = 1; i < WordsCount; i++)
            {
                //Определить что это функция.
                //if (((Words[i, wLexType] == "ATTR") && (Words[i + 1, wLex] == "(")) || (Words[i, wLexType] == "FUNC"))
                //{
                    //SetwProc(i, "FUNC1"); 
                    //Words[i, wLexType] =  "FUNC";
                    //int FuncEnd = Words[i + 1, wBrace].ParserToInt();                              
                    //for (int j = i; j <= FuncEnd; j++) Words[j, wBlockFunc] = "1";
                    
                    //if ((Words[FuncEnd, wAlias] == "") && (Words[FuncEnd + 1, wLexType] != "KEY") && (Words[FuncEnd + 1, wLexType] != "SIGN"))
                    //{
                    //    Words[FuncEnd, wAlias] = "Column" + ColumnNum;
                    //    ColumnNum++;
                    //}                                       
                //}
                
                //Определить что это функция.
                if ((Words[i, wLex] == "(") && (Words[i + 1, wLex] != "SELECT"))
                {
                    int FuncEnd = Words[i, wBrace].ParserToInt();     
                    for (int j = i; j <= FuncEnd; j++)
                    {
                        Words[j, wBlockFunc] = "1";
                        SetwProc(j, "FUNC1");
                    }
                    //Words[i, wLexType] =  "FUNC";
                    //int FuncEnd = Words[i + 1, wBrace].ParserToInt();                              
                    //for (int j = i; j <= FuncEnd; j++) Words[j, wBlockFunc] = "1";
                    
                    //if ((Words[FuncEnd, wAlias] == "") && (Words[FuncEnd + 1, wLexType] != "KEY") && (Words[FuncEnd + 1, wLexType] != "SIGN"))
                    //{
                    //    Words[FuncEnd, wAlias] = "Column" + ColumnNum;
                    //    ColumnNum++;
                    //}                                       
                }
                
                bool ISNULL = false;
                if ((i > 1) && (Words[i - 2, wLex] == "ISNULL")) ISNULL = true;
                
                
                if ((Words[i, wLexType]     == "ATTR")    &&
                    (Words[i + 1, wLexType] != "ALIAS")   &&
                    //(Words[i + 1, wLexType] != "KEY")     &&
                    (Words[i, wAlias]       == "")        &&
                    (Words[i + 1, wLex]     != "AS")      &&                 
                    (Words[i, wBlockWhere]  != "1")       &&
                    (Words[i, wBlockFunc]   != "1")       &&
                    (Words[i, wBlockCase]   != "1")       &&
                    (Words[i - 1, wLex]     != "ON")      &&
                    (Words[i - 1, wLex]     != "WHEN")    &&
                    (Words[i + 1, wLex]     != "+")       &&
                    (Words[i + 1, wLex]     != "-")       &&
                    (Words[i + 1, wLex]     != "/")       &&
                    (Words[i + 1, wLex]     != "*")       &&
                    (Words[i,     wLex]     != "*")       &&
                    (Words[i - 1, wLex]     != "INTO")    &&
                    (Words[i - 1, wLex]     != "END")     &&                   
                    (Words[i - 1, wLex]     != "PARTITION BY") &&
                    
                    ISNULL == false
                   ) 
                {
                    SetwProc(i, "ALIAS8"); 
                    Words[i, wAlias] = GetAliasByAttrName(Words[i, wLex]);
                }          
            }
        }
               
        ///Получить алиас для атрибута, если его нет. Берём последнее слово составного атрибута. Только для SetLexType2().
        private string GetAliasByAttrName(string AttrName)
        {            
            int p = AttrName.LastIndexOf('.');           
            if (p > -1) 
            {
                string Alias = "";
                Alias = AttrName.Substring(p + 1);
                if (Alias != "*") return "'" + Alias + "'";
                return "";
            }
            if (AttrName != "*") return "'" + AttrName + "'";
            return "";
        } 
        
        ///Определение таблицы (основной) для сущности. Поля TableName, IDFieldName. 
        private void FindTablesForEntity()
        {                                                          
            for (int i = 0; i < WordsCount; i++)
            {                
                if (Words[i, wLexType] != "ENTITY") continue;
                bool FindEntity = false;
                for (int j = 0; j < ParserData.ArEntityY; j++)
                {
                    if (ParserData.ArEntity[j, nBrief] == Words[i, wLex])
                    {
                        FindEntity = true;
                        Words[i, wTableName]    = ParserData.ArEntity[j, nTable_Name];
                        //Words[i, wTableFieldID] = ParserData.ArEntity[j, nTable_IDFieldName];   
                        Words[i, wTableType]    = "Main";
                        break;
                    }
                }
                if (!FindEntity) 
                {
                    Words[i, wTableName] = Words[i, wLex];
                }
            }
        }
        
        ///Получить список сущностей
        private void GetListEntityAlias()
        {   
            AliasCount  = 0;
            EntityCount = 0;
            for (int i = 0; i < WordsCount; i++)
            {                                          
                if (Words[i, wLexType]   != "ENTITY") continue;
                if (Words[i, wTableType] != "Main")   continue;
                      
                ListEntity[EntityCount, ePos]      = EntityCount.ToString("D3");
                ListEntity[EntityCount, eNum]      = Words[i, wPos];
                ListEntity[EntityCount, eLex]      = Words[i, wLex];
                //ListEntity[EntityCount, eBraceNum] = Words[i, wBraceNum];
                ListEntity[EntityCount, eSelect]   = Words[i, wSelect];
                
                if (Words[i, wAlias] != "") ListEntity[EntityCount, eAlias]  = Words[i, wAlias];
                else 
                {            
                    string LetterAlias = "E";
                    if  (PsevdonimAlias == AttrTable[i, vEntityAlias]) LetterAlias = "M"; 
                    ListEntity[EntityCount, eAlias]  = LetterAlias + ParserData.PsevdonimSubQuery.ToString();                   
                    ParserData.PsevdonimSubQuery++;
                }
                ListEntity[EntityCount, eStateDate] = LocalDate;
                //Debug.WriteLine("N: {0}", EntityCount.ToString());
                EntityCount++;
                             
            }          
        }             
                       
        #endregion Region. Поиск конца блоков, Поиск Алиасов, Проставление ENTITY, ATTR.
        
        #region Region. Подготовка к построению запросов.
                                          
        //Нужны колокни в ListQuery:
        //Num может повторяться.
        //Pos, Num, Lex, LexType, Alias, TableName, IDFieldName, TableType,  
        
        ///Определение первой сущности у атрибута.
        private void FindFirstAttr()
        {                                               
            try
            {                         
                //Если у сущности нет алиаса, то проставляем его из таблицы сущностей.
                for (int i = 0; i < WordsCount; i++)
                {     
                    if (Words[i, wLexType] != "ENTITY") continue;
                    if (Words[i, wEntityAlias] != "") continue;
                    for (int j = 0; j < EntityCount; j++)
                    { 
                        if (ListEntity[j, eSelect] != Words[i, wSelect]) continue;
                        if (Words[i, wLex] == ListEntity[j, eLex]) 
                        {
                            SetwProc(i, "ENTAL1"); 
                            Words[i, wAlias]       = ListEntity[j, eAlias];
                            Words[i, wEntityAlias] = ListEntity[j, eAlias];                           
                        }
                    }                    
                }
                
                //1.LF - Составной атрибут может начинаться с пользовательского алиаса.
                //2.EF - Составной атрибут может начинаться с сущности, повторяющей  сущность с которой выбираем.    
                //3.AF - Составной атрибут может начинаться с атрибута. 
                //4.PE - Составной атрибут может начинаться с ключевого слова "ПсевдонимСущности".
                //Будем проверять в таком же порядке: 1,2,3,4.              
                for (int i = 0; i < WordsCount; i++)
                {                                               
                    if (Words[i, wLexType] != "ATTR") continue;           
                    bool IsFind = false;                
                    //bool DotPresent = false;  //Признак составного атрибута.               
                    //if  (Words[i, Lex].IndexOf(".", StringComparison.OrdinalIgnoreCase) > -1) DotPresent = true;
                    string FirstWord; //Первая часть до первой точки.
                    string[] DotArray = Words[i, wLex].Split('.');
                    //if (DotArray.Any()) FirstWord = DotArray[0]; else FirstWord = Words[i, wLex];
                    if (DotArray.Length > 0) FirstWord = DotArray[0]; else FirstWord = Words[i, wLex];                             
                    //1.Составной атрибут может начинаться с алиаса.
                    //if  (DotArray.Any())
                    if  (DotArray.Length > 0)
                        for (int j = 0; j < EntityCount; j++)
                    {           
                        int LexLength = Words[i, wLex].Length;
                        
                        //Если первая чась составного атрибута совпадает с алиасом в списке сущностей, то это алиас.
                        if ((FirstWord == ListEntity[j, eAlias]) && (LexLength > FirstWord.Length))
                        {                            
                            SetwProc(i, "GETENT1");
                            Words[i, wEntity]      = ListEntity[j, eLex];
                            Words[i, wEntityAlias] = ListEntity[j, eAlias];
                            //Если точка всего одна и первая часть алиас, значит это не составной атррибут.                           
                            //Words[i, wFirstAttrType] = "LF"; //аЛиас First - начинается с алиаса.
                            //Words[i,  wAttrFirst]  = DotArray[1];
                            Words[i,  wAttrFull]   = Words[i, wLex].Substring(FirstWord.Length + 1);                                                                     
                            IsFind = true;
                            break;
                        }                      
                    } 
                                              
                    //2.0. Составной атрибут может начинаться с сущности, повторяющей  сущность с которой выбираем. Внутри того-же подзапроса.                                                
                    if (IsFind) continue; //Если было найдено на предыдущем шаге, то не ищем.  
                    for (int j = 0; j < EntityCount; j++)
                    {                                           
                        //Если первая чась составного атрибута совпадает с сокращением сущности в списке сущностей, значит это есть сокращение сущности.
                        //Сначала ищем только среди того-же подзапроса.
                        //if DotArray.Length
                        //if ((FirstWord == ListEntity[j, eLex]) && (DotArray.Count() > 1) && (ListEntity[j, eSelect] == Words[i, wSelect]))
                        if ((FirstWord == ListEntity[j, eLex]) && (DotArray.Length > 1) && (ListEntity[j, eSelect] == Words[i, wSelect]))
                        
                        {
                            SetwProc(i, "GETENT2");
                            Words[i, wEntity]        = ListEntity[j, eLex];           
                            Words[i, wEntityAlias]   = ListEntity[j, eAlias];                            
                            Words[i, wAttrFull]      = Words[i, wLex].Substring(FirstWord.Length + 1);                         
                            IsFind = true;
                            break;
                        }                      
                    } 
                    
                    //2.1. Составной атрибут может начинаться с сущности, повторяющей  сущность с которой выбираем. Среди всех запросов.
                    //Тоже самое что на предыдущем шаге, но без условия ListEntity[j, eSelect] == Words[i, wSelect].
                    if (IsFind) continue; //Если было найдено на предыдущем шаге, то не ищем.
                    for (int j = 0; j < EntityCount; j++)
                    {                                           
                        //Если первая чась составного атрибута совпадает с сокращением сущности в списке сущностей, значит это есть сокращение сущности.
                        //Сначала ищем только среди того-же подзапроса.
                        //if ((FirstWord == ListEntity[j, eLex]) && (DotArray.Count() > 1))
                        if ((FirstWord == ListEntity[j, eLex]) && (DotArray.Length > 1))
                        {
                            SetwProc(i, "GETENT3");
                            Words[i, wEntity]        = ListEntity[j, eLex];           
                            Words[i, wEntityAlias]   = ListEntity[j, eAlias];                            
                            Words[i, wAttrFull]      = Words[i, wLex].Substring(FirstWord.Length + 1);                         
                            IsFind = true;
                            break;
                        }                      
                    } 

                   
                    //3.Составной атрибут может начинаться с атрибута сущности.
                    //Самый распространённый вариант - первая часть составного атрибута - это атрибут сущности.
                    if (IsFind) continue;
                    if  (Words[i, wEntity] == "")
                    for (int j = 0; j < EntityCount; j++)
                    {                            
                        if (ListEntity[j, eSelect] == Words[i, wSelect])         
                        {
                            if (ParserData.ExistsAttrInEntity(ListEntity[j, eLex], FirstWord, true) || Words[i, wLexType] == "SYS")
                            {                                 
                                SetwProc(i, "GETENT4");
                                Words[i, wEntity]      = ListEntity[j, eLex];  
                                Words[i, wEntityAlias] = ListEntity[j, eAlias];                                 
                                Words[i, wAttrFull]   = Words[i, wLex];                                                                                      
                                IsFind = true;  
                                break;
                            }                                                            
                        }
                    }                               
                    
                    //4.Атрибут может принадлежать другой сущности - не той в select которой он находится.
                    //Пример 1: SELECT aaa, bbb FROM E1 LEFT JOIN E2 ON... Здесь не указано к которой сущности относятся aaa и bbb. 
                    //Пример 2: SELECT aaa, (SELECT aaa, bbb FROM E2) FROM E1... Здесь не указано к которой сущности относятся aaa и bbb. 
                    //Допустимо что aaa принадлежит сущности E1 и в E2 такого атрибута нет.
                    //Этот вариант почти то же самое что предыдущий, но нам нужно соблюсти приоритет - сначала поиск по текущей сущности, а затем по сущностям с уровнем select ниже.
                    //Такой способ може привести к проблемам так как атрибут с таким сокращением может быть в двух разных сущностях,
                    //А при таком способе ошибки не будет - и это плохо. 
                    //SQL Server, например, в такой ситуации выдает ошибку о неоднозначности принадлежности поля.
                    //А у нас возьмется из сущности первой по уровню. Но пока временно так.
                    if (IsFind) continue;
                    if  (Words[i, wEntity] == "")
                    {                        
                        int SelectLevel = Words[i, wSelect].ParserToInt();
                        for (int j = 0; j < EntityCount; j++) 
                        {
                            //Поиск по сущностям уровень Select, которых меньше чем текущий.
                            if (ListEntity[j, eSelect].ParserToInt() >= SelectLevel) continue;                             
                            if (ParserData.ExistsAttrInEntity(ListEntity[j, eLex], FirstWord, true))
                            {                              
                                SetwProc(i, "GETENT5");
                                Words[i, wEntity]      = ListEntity[j, eLex];
                                Words[i, wEntityAlias] = ListEntity[j, eAlias];                                    
                                Words[i, wAttrFull]    = Words[i, wLex];
                                IsFind = true;  
                                break;
                            }  
                        }
                        
                    }
                    
                    //Если ничего не нашлось, просто копируем.
                    if (IsFind) continue;
                    //Words[i,  wAttrFirst] = Words[i,  wLex];
                    Words[i,  wAttrFull]  = Words[i,  wLex];                 
                }
                
            } catch (Exception ex)
            {
                ParserSys.ParserSM(ex.Message);
            }
        }                               
        
        ///Для атрибутов, после нахождения номеров SELECT и списка сущностей, корректируем значения 
        ///номера SELECT для атрибутов.
        ///Здесь перебор всех селектов по убыванию номера и поиск к какому селекту относится алиас атрибута.
        private void CorrectSelect()
        {                                                              
            for (int i = 0; i < WordsCount; i++)
            {
                if (Words[i, wLexType] != "ATTR") continue;                       
                string WordsEntityAlias    = Words[i, wEntityAlias];                                                                                          
                bool Find = false;             
                for (int WordsSelect = Words[i, wSelect].ParserToInt(); WordsSelect > 0; WordsSelect--)
                {                 
                    for (int i2 = 0; i2 < EntityCount; i2++)
                    {                                                                   
                        string ListEntitySelect   = ListEntity[i2, eSelect];              
                        if (ListEntitySelect != WordsSelect.ToString()) continue;                                    
                     
                        if ((WordsEntityAlias == ListEntity[i2, eAlias]) && (Words[i, wSelect] != ListEntity[i2, eSelect]))
                        {
                            SetwProc(i, "CORCEL" + Words[i, wSelect] + ";"); 
                            Words[i, wSelect] = ListEntity[i2, eSelect];
                            Find = true;
                            break;
                        }                        
                    } 
                    if (Find) break;
                }
            }                                                                                                                                
        }
     
        //Если не найдено, то ищем по всем.
        /*if (!FindBraceNum)
        {
            for (int i1 = 0; i1 < EntityCount; i1++)
            {                   
                string ListEntitySelect = ListEntity[i1, eSelect];              
                string ListEntityAlias  = ListEntity[i1, eAlias];                                        
                if ((WordsEntityAlias == ListEntityAlias) && (WordsSelect != ListEntitySelect))
                {
                    SetwProc(i, "CORCEL" + Words[i, wSelect] + ";"); 
                    Words[i, wSelect] = ListEntitySelect;                       
                    break;
                }
            }
        }*/
                     
        
        
        ///Восстанавливаем пользовательские строки обратно в колонку Lex. 
        private void RestoreUserString()
        {    
            for (int i = 0; i < WordsCount; i++)
            {                  
                ReplaceUserByUserStr(wLex,   i);
                ReplaceUserByUserStr(wAlias, i);                       
            }                       
        }
        
        ///Поиск строки по массиву UserStr строк пользователя. В качестве параметра используется USERSTR*. 
        private bool ReplaceUserByUserStr(int FieldIndex, int Pos)
        {
            string Value = Words[Pos, FieldIndex];
            if (Value == null) return false;
            if (Value.IndexOf("USERSTR", StringComparison.OrdinalIgnoreCase) == -1) return false;
            
            for (int i = 0; i < ListUserStrCount; i++)
            {
                string RealString = ListUserStr[i, sRealString];
                string UserString = ListUserStr[i, sUserString];
                int N = Value.IndexOf(UserString, StringComparison.OrdinalIgnoreCase);
                if (N == -1) continue;         
                Value = Value.Remove(N, UserString.Length);
                Value = Value.Insert(N, RealString);
                Words[Pos, FieldIndex] = Value;
                return true;  
            }
            return false;
        }   
                      
        ///Получить конец выражения ДатаСостОбъекта. Только для SetStateDate.
        ///Pos - текущая позиция в запросе где есть 
        private int GetStateDateEnd(int Pos)
        {                     
            //Могут быть варианты:
            //AND (ДатаСостОбъекта = ааа)
            //AND ДатаСостОбъекта = (ааа)
            //AND ДатаСостОбъекта = ааа AND
            //AND ДатаСостОбъекта = ааа
            //AND ДатаСостОбъекта = ааа GROUP BY...
            //AND ДатаСостОбъекта = ааа ORDER BY...
            //AND ДатаСостОбъекта = GetDate() GROUP BY...
            //AND ДатаСостОбъекта = GetDate() ORDER BY...
            //AND ДатаСостОбъекта = (SELECT ДатаНачала FROM bbb WHERE...) GROUP BY...
            //AND ДатаСостОбъекта = (SELECT ДатаНачала FROM bbb WHERE...) ORDER BY...
            //AND ДатаОкончания > ПсевдонимСущности.ДатаСостОбъекта AND ISNULL(ФЛ.SuperVIP, 0) > 0
            //AND D3.ДатаСостОбъекта = '20170411 00:00:00') AS
            //AND D3.ДатаСостОбъекта = "20170411 00:00:00") AS
            
            if ((Pos < (WordsCount - 1)) && (Words[Pos + 1, wLex]  != "=")) return (Pos - 1);
            
            //Если перед ДатаСостОбъекта идет WHERE, а после нет условий через AND, то WHERE нужно убирать.
            //if ((Words[Pos + 1, wLex]  == ")") ||
            //    (Words[Pos + 1, wLex]  == "AND")  ||     
            //    (Words[Pos + 1, wLex]  == "OR")  
            //) return Pos;
            
            //Ситуация: ... (ДатаСостОбъекта = ааа) ...
            if ((Pos > 0) && (Words[Pos - 1, wLex]  == "(")) return Words[Pos - 1, wBrace].ParserToInt() - 1;   
            
            //Ситуация: ... ДатаСостОбъекта = (ааа) ...
            if ((Pos < (WordsCount-2)) && (Words[Pos + 2, wLex]  == "(")) return Words[Pos + 2, wBrace].ParserToInt();
            
            //Ситуация: ... ДатаСостОбъекта = GetDate(ааа, bbb) ...
            if ((Pos < (WordsCount-3)) && (Words[Pos + 3, wLex]  == "(")) return Words[Pos + 3, wBrace].ParserToInt();     
            
            //Иначе ищем конец выражения:
            string SelectLocal   = Words[Pos, wSelect];
            string BraceNumLocal = Words[Pos, wBraceNum];                              
            for (int i = Pos + 1; i < WordsCount; i++)
            {
                if (Words[i, wSelect]   != SelectLocal)   return i - 1;
                if (Words[i, wBraceNum] != BraceNumLocal) continue;
                string Lexem = Words[i, wLex];
                
                if ((Lexem == "AND")      ||
                    (Lexem == "OR")       ||
                    (Lexem == "ORDER BY") ||
                    (Lexem == "GROUP BY") ||
                    (Lexem == "FROM")     ||
                    (Lexem == "WHERE")    ||                    
                    (Lexem == ",")        ||
                    (Lexem == ")")        ||
                    (Lexem == ";")        ||
                    (Words[i, wLexType] == "UNION") ||
                    (Words[i, wLexType] == "JOIN")  ||
                    (Words[i, wLexType] == "ALIAS"))
                    return i - 1;
            }
            return WordsCount - 1;
        }                
        
        ///Получаем все выражение StateDate. Только для SetStateDate.
        private string GetPartQuery(int iBeg, int iEnd)
        {
            string StateDate = "";
            for (int i = iBeg; i <= iEnd; i++) StateDate += Words[i, wLex];
            if (StateDate == "") StateDate = LocalDate;
            return StateDate;
        }   
                       
        ///Проставить дату состояния для каждой сущности.
        private void SetStateDate()
        { 
            //Могут быть варианты:
            //AND (ДатаСостОбъекта = ааа)
            //AND ДатаСостОбъекта = (ааа)
            //AND атаСостОбъекта = ааа AND
            //AND ДатаСостОбъекта = ааа;
            //AND ДатаСостОбъекта = ааа GROUP BY...
            //AND ДатаСостОбъекта = ааа ORDER BY...
            //AND ДатаСостОбъекта = GetDate() ORDER BY...
            //AND ДатаСостОбъекта = GetDate() ORDER BY...
            //AND ДатаСостОбъекта = (SELECT ДатаНачала FROM bbb WHERE...) ORDER BY...
            //Если перед ДатаСостОбъекта идет WHERE, а после нет условий через AND, то WHERE нужно убирать.
            for (int i = 0; i < WordsCount; i++)
            {
                
                if (Words[i, wLex].IndexOf(ParserData.KeyBriefUpper.StateDate, StringComparison.OrdinalIgnoreCase) == -1) continue;                                 
                int N = GetStateDateEnd(i);
                         
                Words[i, wBlockEnd] = N.ToString();
                
                //Проставляем Дату состояния для каждой сущности. !Убрано. 
                ListStateDate[StateDateCount, dPos]          = StateDateCount.ToString("D3");
                ListStateDate[StateDateCount, dNum]          = i.ToString();
                ListStateDate[StateDateCount, dSelect]       = Words[i, wSelect];
                ListStateDate[StateDateCount, dEntityBrief]  = Words[i, wEntity];
                ListStateDate[StateDateCount, dEntityAlias]  = Words[i, wEntityAlias];
                ListStateDate[StateDateCount, dStateDate]    = Words[i, wAttrFull];                               
                ListStateDate[StateDateCount, dStateDateBeg] = (i + 2).ToString();
                ListStateDate[StateDateCount, dStateDateEnd] = N.ToString();                                                        
                                
                string StateDate = GetPartQuery(i + 2, N);
                if (StateDate.ToUpper() == ParserData.KeyBriefUpper.EntityAlias + "." + ParserData.KeyBriefUpper.StateDate) StateDate = "'" + PsevdonimStateDate + "'"; 

                ListStateDate[StateDateCount, dStateDateCode] = "dStateDateCode" + ListStateDate[StateDateCount, dPos];                
                bool ResultConvert;
               
                string Result = ParserSys.ParserConvertDate4Server10(StateDate, true, false, out ResultConvert);
                if (ResultConvert) ListStateDate[StateDateCount, dStateDateCode]  = Result;
                            
                StateDateCount++;
                
                //Нужно проставить для всех ДатаСостОбъекта тип NOTUSE.
                //Если кроме ДатаСостОбъекта в фильтре WHERE ничего нет, то из конечного запроса убираем и WHERE. 
                //При проверке условия (i > 0) остальные условия в IF не проверяются, поэтому так можно писать.
                //if ((i > 0) && ((N + 1) < WordCount) && (Words[i - 1, wLex] == "WHERE")) //&& (Words[N + 1, wLex]) == ";")
                if ((Words[i - 1, wLex] == "WHERE") &&                   
                     (
                        (((i + 3) >= WordsCount) || (GetLexNext(i, 3) == ";"))                       
                     )
                   ) 
                {
                    SetwProc(i - 1, "NOTUSE2");                    
                    Words[i - 1, wLexType] = "NOTUSE";
                }
                
                if ((i > 0) && (Words[i - 1, wLex] == "WHERE") && (Words[N + 1, wLex]) == "AND") 
                {
                    SetwProc(i, "NOTUSE3");
                    if ((N + 1) < WordsCount) Words[N + 1, wLexType] = "NOTUSE";
                }  
                
                if ((i > 0) && (Words[i - 1, wLex]  == "AND"))
                {
                    SetwProc(i - 1, "NOTUSE4");   
                    Words[i - 1, wLexType] = "NOTUSE"; //AND ДатаСостОбъекта = ...
                } 
               
                if ((i > 1) && (Words[i - 2, wLex] == "AND") && (Words[i - 1, wLex] == "("))
                {
                    SetwProc(i - 2, "NOTUSE5");
                    Words[i - 2, wLexType] = "NOTUSE";
                    
                    SetwProc(i - 1, "NOTUSE6");    
                    Words[i - 1, wLexType] = "NOTUSE";                                        
                 
                    SetwProc(i - 1, "NOTUSE7");
                    Words[Words[i - 1, wBrace].ParserToInt(), wLexType] = "NOTUSE"; //)   или так Words[N + 1, LexType] = "NOTUSE";
                }
                
                //Чтобы выставить Датасостояния в пределах одного SELECT.
                for (int j = i; j <= N; j++)
                {
                    if (j < (i + 2)) Words[j, wStateDate] = "1";
                    else Words[j, wStateDate] = "2";                                 
                    SetwProc(j, "SD8");                                     
                }               
            }           
        }              
               
        #endregion Region. Подготовка к построению запросов.  
        
        ///Показать все таблицы в подзапросе.       
        private void ShowSubQuery(string MSQLLocal)
        { 
            return;
            //Выходные данные.
            //Таблицы для парсинга, полученные при работе парсера.             
            /*
            System.Data.DataTable DTMain;    //Главная таблица, в которой весь запрос.                      
            System.Data.DataTable DTTable;   //Список таблиц, которые используются в выходном запросе SQL. 
            System.Data.DataTable DTEntity;  //Список сущностей, которые используются в исходном запросе MSQL.
            System.Data.DataTable DTUserStr; //Список строк пользователя в исходном запросе MSQL. 
            System.Data.DataTable DTAttrTable;
            System.Data.DataTable DTStateDate;             
            ReturnTestTable(out DTMain, out DTEntity, out DTTable, out DTUserStr, out DTAttrTable, out DTStateDate);
            */
            //FormParser2 F1 = new FormParser2();
            //F1.ListSQL.Text = MSQLLocal;
            //F1.dgvWords.DataSource = DTMain;
            //F1.dgvUserString.DataSource = DTUserStr;
            //F1.dgvAttrTable.DataSource = DTAttrTable;
            //F1.ShowDialog();             
        }
                
        ///Получить следующую лексему через NextCount лексем. 
        ///NextCount = 1, означает следующую, NextCount = 2 - через одну и т.д.
        ///N - текущая позиция.
        public string GetLexNext(int N, int NextCount)
        {
            if ((N + NextCount) > (WordsCount - 1)) return "";
            return Words[N + NextCount, wLex];
        }
        
        ///Получить предыдущую лексему. Аналогично GetLexNext.
        ///PrevCount = 1, означает следующую, PrevCount = 2 - через одну и т.д.
        ///N - текущая позиция.
        public string GetLexPrev(int i, int PrevCount)
        {
            if ((i - PrevCount) < 0) return "";
            return Words[i - PrevCount, wLex];
        }
        
        ///Получить следующую лексему без учета NOTUSE.
        public string GetLexNextNU(int i)
        {
            if (i > (WordsCount - 2)) return "";
            for (int N = i + 1; N < WordsCount; N++)
            {                                           
                if (Words[N, wLexType] == "NOTUSE") continue;
                return Words[N, wLex];
            }
            return "";
        }
        
        ///Получить предыдущую лексему без учета NOTUSE.
        public string GetLexPrevNU(int i)
        {
            if (i < 1) return "";
            for (int N = i - 1; N > -1; N--)
            {                                           
                if (Words[N, wLexType] == "NOTUSE") continue;
                return Words[N, wLex];
            }
            return "";
        }
        
        ///Установить знак переноса на следующую строку, иначе сложно читать запрос, когда каждая запятая на новой строке.
        private void SetDOCR()
        {
            for (int i = 0; i < WordsCount; i++)
            {                                           
                if (Words[i, wLexType] == "NOTUSE") continue;
                
                int Space   = 0;
                string DOCR = "UN";  //UNKNOWN  
                
                //string LexPrev = GetLexPrevNU(i);
                string LexCur  = Words[i, wLex];
                string LexNext = GetLexNextNU(i);                                
                
                //Если текущая лексема
                if ((LexCur  == "SELECT")     ||
                    (LexCur  == "FROM")       ||
                    (LexCur  == "WHERE")      ||
                    (LexCur  == "GROUP BY")   ||
                    (LexCur  == "ORDER BY")   || 
                    (LexCur  == "UNION")      ||
                    (LexCur  == "UNION ALL")  ||
                    (LexCur  == "HAVING")     ||     
                    (LexCur  == "DISTINCT")   ||
                    (LexCur  == "INTO")       ||
                    (LexCur  == "INNER JOIN") ||
                    
                    //Если следующая лексема
                    (LexNext  == "SELECT")    ||
                    (LexNext  == "FROM")      ||
                    (LexNext  == "WHERE")     ||
                    (LexNext  == "GROUP BY")  ||
                    (LexNext  == "ORDER BY")  || 
                    (LexNext  == "UNION")     ||
                    (LexNext  == "UNION ALL") ||
                    (LexNext  == "HAVING")    ||     
                    (LexNext  == "DISTINCT")  ||
                    (LexNext  == "WHEN")      || 
                    (LexNext  == "INTO")                                               
                    )
                {
                    DOCR = "CR";
                }   
                            //between 1 and 2  
                  
                if ((LexNext  == "AND") && (GetLexPrev(i, 1)  != "BETWEEN")) DOCR = "CR";                 
                
                //Если находимся в функции, то ничего не переносим, все одной строкой.
                if (Words[i, wBlockFunc] == "1") DOCR = "NO"; 
                
                //Если следующая запятая, то переноса нет.
                if (LexNext == ",") DOCR  = "NO";
                                   
                //Если запятая, то добавляем пробел, а если не в блоке функции, то переносим.
                if (LexCur == ",") 
                {
                    if (Words[i, wBlockFunc] != "1") DOCR = "CR"; 
                      else Space = Space + 1;
                }                                                              
                
                if ((DOCR     != "CR") && 
                    (Space    == 0)    && 
                    (LexNext  != ",")  && 
                    (LexCur   != "(")  &&
                    (LexNext  != ")")  
                   )
                Space = 1;
                                             
                Words[i, wDOCR] = DOCR + Space.ToString("D2");
                        
            }
        }
        
        ///Получить строку с переносами и пробелами, путем разбора значения DOCR.
        private string GetDOCR(string DOCR)
        {
            if (DOCR == "") return "";
            if (DOCR == null) return "";
            const string Tab = " ";                      
            string CRText     = DOCR.ParserSubStringEnd(0, 2);
            string SpaceCount = DOCR.ParserSubStringEnd(2, 2);
            string Result = "";
            if (CRText   == "CR") Result = Result + ParserSys.CR;
            if (SpaceCount != "") Result = Result + Tab.ParserRepeatString(SpaceCount.ParserToInt());  
            return Result;
        }
        
     }
       

        
        ///Проставить дату состояния атроибута.
        /*private void SetAttrDate()
        {                    
            for (int i = 0; i < WordCount; i++)
            {
                 int PosDate = Words[i, wLex].IndexOf("ДАТАСОСТАТРИБУТА", StringComparison.OrdinalIgnoreCase);
                 if (PosDate == -1)  continue;
                 int N = GetStateDateEnd(i);                        
                 Words[i, wBlockEnd] = N.ToString();               
                 string AttrDate = GetPartQuery(i + 2, N);
                 bool ResultConvert;
                 string Result = ParserSys.ParserConvertDate4Server(AttrDate, true, false, out ResultConvert); 
                 if (ResultConvert) 
                     Words[i + 2, wLex] = Result;                
            }
        }*/    
     
}        
