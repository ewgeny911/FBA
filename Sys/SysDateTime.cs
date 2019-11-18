/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 25.08.2017
 * Время: 23:22
 */
 
using System;
using System.Globalization;

namespace FBA
{
	/// <summary>
	/// Функции работы с датой и временем.
	/// </summary>
	public static partial class sys
	{		 
	    /// <summary>
	    /// Метод для теста показывает все преобразования, которые производят методы в этом модуле.
	    /// </summary>
	    public static void TestDateTimeMethods()
	    {
	         //DateTimeToSQLStr1=2017-11-06 33:53.041
             //SQLStrToDateTime=06.11.2017 0:33:53
             //DateTimeToSQLStr2=2017-11-06 33:53.041
             //GetDateTimeNow()=06.11.2017 10:33:53
             //GetDate4FileName=2017-11-06
             //DateTimeStrToMSSQL(DateTime.Now.ToString()=2017-11-06 10:33:53                                   
             string str = "";
             string s1 = sys.DateTimeToSQLStr(DateTime.Now);
             str = str + "DateTimeToSQLStr1=" + s1 + Var.CR;                
             DateTime dt1 = sys.StringToDateTime(s1);
             str = str + "SQLStrToDateTime=" + dt1.ToString() + Var.CR;           
             string s2 = sys.DateTimeToSQLStr(dt1);
             str = str + "DateTimeToSQLStr2=" + s2 + Var.CR;            
             string s3 = sys.GetDateTimeNow();
             str = str + "GetDateTimeNow=" + s3 + Var.CR;   
             string s4 = sys.GetDate4FileName(DateTime.Now);
             str = str + "GetDate4FileName=" + s4 + Var.CR;
             //string s5 = sys.DateTimeStrToMSSQL(DateTime.Now.ToString());
             //str = str + "DateTimeStrToMSSQL(DateTime.Now.ToString()=" + s5 + Var.CR;    
             sys.SM(str);
	    }
	          
        /// <summary>
        /// Получить строку с текущей датой и временем в формате "yyyy.dd.MM HH:mm:ss"
        /// </summary>
        /// <returns>Текущее дата-время на компьютере в формате "yyyy.dd.MM HH:mm:ss"</returns>
        public static string GetDateTimeNow()
        {             
            return DateTime.Now.ToString("G");
        }
    
        /// <summary>
        /// Получить строку с текущей датой и временем в формате "dd.MM.yyyy HH:mm:ss"
        /// Обычно используется для лога.
        /// </summary>
        /// <returns>Текущее дата-время на компьютере в формате "dd.MM.yyyy HH:mm:ss"</returns>
        public static string GetDateTimeLog()
        {
            return DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }     
        
        /// <summary>
        /// Получить строку с текущей датой и временем в формате yyyy-MM-dd HH:mm:ss.
        /// </summary>
        /// <param name="datetime">DateTime</param>
        /// <param name="addQuote">Добавлять кавычки</param>
        /// <returns>Возвращает в виде yyyy-MM-dd HH:mm:ss. Если addQuote=true, то добавляет кавычки 'yyyy-MM-dd HH:mm:ss'</returns>
        public static string DateTimeToSQLStr(DateTime datetime, bool addQuote = false)
        {
            //Пример:  return DateTimeToSQLStr(DateTime.Now);  
            //Вместо "yyyy-MM-dd HH:mm:ss.fff" используем "yyyy-MM-dd HH:mm:ss"
            string Quote = "";
            if (addQuote) Quote = "'";
            return Quote + datetime.ToString("yyyy-MM-dd HH:mm:ss") + Quote; //DateTime.Now.ToString("yyyy.dd.MM HH:mm:ss");
        }
	
		/// <summary>
		/// Получаем формат даты и времени. Попытка понять какой формат даты и/или времени передан на вход. 
		/// </summary>
		/// <param name="value">дата-время в виде строки в каком либо формате</param>
		/// <param name="tryFixError">Попытаться исправить ошибки в дате или времени</param>
		/// <returns>Формат даты-времени, который был определён</returns>
        public static string GetFormatDateTime(string value, bool tryFixError = true)
        {
            if (value == "") return "";
            int len = value.Length;
            string FormatIN = "";
            if (len == 10)
            {
                if ((value[4] == '.') && (value[7] == '.')) FormatIN = "yyyy.MM.dd";
                else if ((value[4] == '/') && (value[7] == '/')) FormatIN = "yyyy/MM/dd";
                else if ((value[4] == '-') && (value[7] == '-')) FormatIN = "yyyy-MM-dd";

                else if ((value[2] == '.') && (value[5] == '.')) FormatIN = "dd.MM.yyyy";
                else if ((value[2] == '/') && (value[5] == '/')) FormatIN = "dd/MM/yyyy";
                else if ((value[2] == '-') && (value[5] == '-')) FormatIN = "dd-MM-yyyy";

                if (FormatIN == "") return "";

                //Попытка исправить ошибки
                if (tryFixError)
                { 
                    if (FormatIN[0] == 'y')
                    {
                        value = value.ReplaceCharInString(4, '0');
                        value = value.ReplaceCharInString(7, '0');
                    }
                    else
                    if (FormatIN[0] == 'd')
                    {
                        value = value.ReplaceCharInString(2, '0');
                        value = value.ReplaceCharInString(5, '0');
                    }
                }

                int Num = 0;
                if (!sys.IsInteger(value, out Num)) return "";
                return FormatIN;
            }
            if (len == 18)
            {
                if ((value[4] == '-') && (value[7] == '-') && (value[10] == ' ') && (value[13] == ':') && (value[16] == ':')) FormatIN = "yyyy-MM-dd HH:mm:ss"; //01-01-1900 0:00:00
                if ((value[4] == '.') && (value[7] == '.') && (value[10] == ' ') && (value[13] == ':') && (value[16] == ':')) FormatIN = "yyyy.MM.dd H:mm:ss";//01.01.1900 0:00:00
                return FormatIN;
            }
            if (len == 19)
            {
                if ((value[4] == '-') && (value[7] == '-') && (value[10] == ' ') && (value[13] == ':') && (value[16] == ':')) FormatIN = "yyyy-MM-dd HH:mm:ss";
                if ((value[4] == '.') && (value[7] == '.') && (value[10] == ' ') && (value[13] == ':') && (value[16] == ':')) FormatIN = "yyyy.MM.dd HH:mm:ss";
                return FormatIN;
            }
            
            //Дата может быть выражена также длиной 8 символов.
            if ((len == 8) && (value.IsIntegerStr()))
            {
            	     if ((value[1] == '2') && (value[2] == '0')) FormatIN = "yyyyMMdd"; //20100915
            	else if ((value[1] == '1') && (value[2] == '9')) FormatIN = "yyyyMMdd"; //19800915
            	else if ((value[5] == '2') && (value[6] == '0')) FormatIN = "ddMMyyyy"; //01012011
            	else if ((value[5] == '1') && (value[6] == '9')) FormatIN = "ddMMyyyy"; //01011980
            	return FormatIN;
            }
            
            //Это только время.
            if ((len == 4) || (len == 5) || (len == 7) || (len == 8))
            {
            	//9:12     - Lenght = 4 
	            //12:34    - Lenght = 5 
	            //8:56:12  - Lenght = 7 
	            //10:24:34 - Lenght = 8  

	            string hour = "";
	            string min  = "";
	            string sec  = "";
	            if (value.Length == 4)
	            {
	                if (value[2] == ':') FormatIN = @"h:mm";
	                if (value[2] == '/') FormatIN = @"h/mm";
	                hour = value.Substring(0, 1);
	                min  = value.Substring(2, 2);
	            }
	            if (value.Length == 5)
	            {
	                if (value[3] == ':') FormatIN = @"hh:mm";
	                if (value[3] == '/') FormatIN = @"hh/mm";
	                hour = value.Substring(0, 2);
	                min = value.Substring(3, 2);
	            }
	            if (value.Length == 7)
	            {
	                if ((value[2] == ':') && (value[5] == ':')) FormatIN = @"h:mm:ss";
	                if ((value[2] == '/') && (value[5] == '/')) FormatIN = @"h/mm/ss";
	                hour = value.Substring(0, 1);
	                min = value.Substring(2, 2);
	                sec = value.Substring(5, 2);
	              
	            }
	            if (value.Length == 8)
	            {
	                if ((value[3] == ':') && (value[6] == ':')) FormatIN = @"hh:mm:ss";
	                if ((value[3] == ':') && (value[6] == ':')) FormatIN = @"hh/mm/ss";
	                hour = value.Substring(0, 2);
	                min = value.Substring(3, 2);
	                sec = value.Substring(6, 2);
	            }
	            int hourint = 0;
	            int minint  = 0;
	            int secint  = 0;
	            if (!sys.IsInteger(hour, out hourint)) return "";
	            if (!sys.IsInteger(sec,  out minint))  return "";
	            if (!sys.IsInteger(hour, out secint))  return "";
	            if (hourint > 24) return "";
	            if (minint > 60)  return "";
	            if (secint > 60)  return "";
	            return FormatIN;
            }            
            return "";
        }       

        /// <summary>
        /// Проверка, что время находится между временем.
        /// </summary>
        /// <param name="time">Проверяемое время</param>
        /// <param name="startTime">Начало диапазона времени</param>
        /// <param name="endTime">Конец диапазона времени</param>
        /// <returns>Если время между временем, то true.</returns>
        static public bool IsBetween(this TimeSpan time, TimeSpan startTime, TimeSpan endTime)
        {
            if (endTime == startTime) return true;            
            if (endTime<startTime)
            {
                return time <= endTime || time >= startTime;
            } 
            return time >= startTime && time <= endTime;
        }
            
        /// <summary>
        /// Проверка на то что строка является датой. Способ через TryParse.
        /// </summary>
        /// <param name="value">Проверка на то, что значение является датой или временем</param>
        /// <returns>Если это дата-время, то true</returns>
        public static bool IsDate(this string value)
        {
            DateTime dt;
            return DateTime.TryParse(value, out dt);
        }
               
        /// <summary>
        /// Конвертирование форматов дат для запросов SQL: 
        /// 24.03.2017
        /// 24-03-2017
        /// 24/03/2017
        /// 2017-03-24
        /// 2017/03/24
        /// 2017.03.24       
        /// yyyy-MM-dd HH:mm:ss
        /// yyyy/MM/dd HH:mm:ss
        /// yyyy.MM.dd HH:mm:ss
        /// yyyy.MM.dd HH:mm:ss.fff
        /// Если AddQuote = true будут добавлены кавычки. Во входящей строке также кавычки могут быть, а могут и отсутствовать.
        /// </summary>
        /// <param name="value">Строка дата-время</param>
        /// <param name="addQuote">Добавлять кавычки или нет</param>
        /// <returns>Строка дата-время в виде yyyy-MM-dd HH:mm:ss</returns>
        public static string ConvertDate4Server(string value, bool addQuote = false)
        {
            if (value == "") return value;
            if ((value.Length > 12) || (value.Length < 10)) return value;
            string ValueNew;
            if ((value.Left(1) == "'") && (value.Right(1) == "'")) 
                ValueNew = value.Substring(1, value.Length - 2);           
            else ValueNew = value;
            if (ValueNew.Length != 10) return value;
            string FormatIN = GetFormatDateTime(ValueNew, true);
            if (FormatIN == "") return value; 
            FormatIN = FormatIN + " HH:mm:ss";
            ValueNew = ValueNew + " 23:59:59";                      
            string Quote = "";
            if (addQuote) Quote = "'";        
            if (!sys.DateTimeConvertStr(ref value, FormatIN, "yyyy-MM-dd HH:mm:ss")) return "";
            return Quote + value + Quote;             
        }                              
              
        /// <summary>
        /// Конвертация строки в формат DateTime. Если формат даты или времени не определён, возвращается Var.MinStateDate.
        /// </summary>
        /// <param name="value">Строка дата-время в каком либо формате</param>
        /// <returns>Значение типа DateTime</returns>
        public static System.DateTime StringToDateTime(string value)
        {                                                                   
        	if (value == null) return Var.MinStateDate;
        	string formatIN = GetFormatDateTime(value, true);
        	if (formatIN != "") return DateTime.ParseExact(value, formatIN, null);                   
        	return Var.MinStateDate; //DateTime.ParseExact("01.01.1900", "dd.MM.yyyy", null);        	
        }               
      
        /// <summary>
        /// Получить строку с датой. Используется в именах файлов. Возвращает в формате "yyyy-MM-dd".
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>Возвращает в формате "yyyy-MM-dd"</returns>
        public static string GetDate4FileName(DateTime dt)
        {          
            return dt.ToString("yyyy-MM-dd");
        }
             
        /// <summary>
        /// Получить строку с датой. Обычно используется для отчетов. Возвращает в формате "dd.MM.yyyy".
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>Возвращает в формате "dd.MM.yyyy"</returns>
        public static string GetDate4Report(DateTime dt)
        {
            return dt.ToString("dd.MM.yyyy");
        }
                
        /// <summary>
        /// Конвертирование одного формата даты-времени к другому. 
        /// Пример: bool result = sys.DateTimeConvertStr(str1, "24.03.2017", "yyyy-MM-dd HH:mm:ss.fff", str2);
        /// Если входной формат указан ошибочный, то делается попытка определить формат самостоятельно.  
        /// </summary>
        /// <param name="dateTime">dateTime в виде строки. Возвращает Строка дата-время в формате formatOUT</param>
        /// <param name="formatIN">Формат строки в первом параметре dateTime</param>
        /// <param name="formatOUT">Формат строки даты времени, в который нужно преобразовать</param>
        /// <returns>Если успешно, то true. Ошибок не выдает.</returns>
        public static bool DateTimeConvertStr(ref string dateTime, string formatIN, string formatOUT)
        {
            if (dateTime     == "") return false;
            if (formatIN  == "") return false;
            if (formatOUT == "") return false;  
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            { 
                DateTime dt = DateTime.ParseExact(dateTime, formatIN, provider);      //01/02/2014  //dd/MM/yyyy
                dateTime = dt.ToString(formatOUT);
                return true;
            } catch
            {
            	
            }
            
			//Возможно входной формат указан ошибочный, поэтому пытаемся определить самостоятельно.            
   			try
            { 
	            formatIN = GetFormatDateTime(dateTime, true);
	    		DateTime dt = DateTime.ParseExact(dateTime, formatIN, provider);      //01/02/2014  //dd/MM/yyyy
	        	dateTime = dt.ToString(formatOUT);
	        	return true;
	        } catch
            {
            	return false;
            }                                                                                       
        }

        /// <summary>
        /// Конвертирование времени из одного формата  другой.
        /// </summary>
        /// <param name="value">Время в виде строки. переменная ref. Возвращается время в виде строки в новом формате.</param>
        /// <param name="formatIN">Входной формат времени</param>
        /// <param name="formatOUT">Выходной формат времени</param>
        /// <returns></returns>
        public static bool TimeConvertStr(ref string value, string formatIN, string formatOUT)
        {
            if (value     == "") return false;
            if (formatIN  == "") return false;
            if (formatOUT == "") return false;
            try
            {
                TimeSpan time2;
                if (TimeSpan.TryParseExact(value, formatIN, CultureInfo.CurrentCulture, out time2))
                {
                    value = time2.ToString(formatOUT);                   
                }
                else return false;
            } catch
            {
                return false;
            }
            return true;                       
        }
           
        /// <summary>
        /// Процедура устарела. нужно в вызовах заменить её на DateTimeConvertStr. Оставлена для совместимости.
        /// Приведение строки даты-времени к формату: 30.05.2017 16:49:33
        /// </summary>
        /// <param name="value">Строка с латой и временем</param>
        /// <returns></returns>
        public static string DateTimeStrToMSSQL(this string value)
        {                   
            if (value.Length != 19) return value;
            if (value[2]  != '.') return value;
            if (value[5]  != '.') return value;            
            if (value[10] != ' ') return value;
            if (value[13] != ':') return value;
            if (value[16] != ':') return value;
            return value.Substring(6, 4) + "-" + value.Substring(3, 2) + "-" + value.Substring(0, 2) + value.Substring(10, 9);                                               
        }
              
        /// <summary>
        /// Строка текущего времени, в зависимости от типа сервера. Возвращает:
        /// Postgre = current_timestamp     	
        /// MSSQL   = GetDate()        
        /// SQLite  = datetime(CURRENT_TIMESTAMP, 'localtime')
        /// </summary>
        /// <param name="serverType">ServerType: Postgre, MSSQL, SQLite</param>
        /// <returns>Одно из трёх текстовых значений</returns>
        public static string DateTimeCurrent(ServerType serverType = ServerType.Auto)
        {
        	if (serverType == ServerType.Auto)
        	{
              if  (Var.con != null) serverType = Var.con.serverTypeRemote;
        	  else serverType = ServerType.Postgre; 
        	}
        	string dtstr = "";
            if (serverType == ServerType.Postgre)  dtstr = @"current_timestamp"; //по умолчанию как Postgre.        	
        	if (serverType == ServerType.MSSQL)    dtstr = @"GetDate()";        
        	if (serverType == ServerType.SQLite)   dtstr = @"datetime(CURRENT_TIMESTAMP, 'localtime')";
        	return dtstr;        
        }
    
        /// <summary>
        /// Получить SQL для получения текущей даты на сервере.
        /// Postgre = SELECT current_timestamp AS CurrentDateTime   	
        /// MSSQL   = SELECT datetime('now', 'localtime') AS CurrentDateTime       
        /// SQLite  = SELECT GetDate() AS CurrentDateTime
        /// </summary>
        /// <param name="serverType">ServerType: Postgre, MSSQL, SQLite</param>
        /// <returns>Одно из трёх текстовых значений</returns>
        public static string SelectCurrentDateTime(ServerType serverType = ServerType.Auto)
        {    
            if (serverType == ServerType.Auto)
        	{
              if  (Var.con != null) serverType = Var.con.serverTypeRemote;
        	  else serverType = ServerType.Postgre; 
        	}    
            string sql = "";
            switch (serverType)
            {
                case ServerType.Postgre  : sql = "SELECT current_timestamp AS CurrentDateTime ";  break;
                case ServerType.SQLite   : sql = "SELECT datetime('now', 'localtime') AS CurrentDateTime "; break;
                case ServerType.MSSQL    : sql = "SELECT GetDate() AS CurrentDateTime "; break;                  
            }                
            return sql;
        }
           
        /// <summary>
        /// Получить тип поля при создании таблицы для каждого типа сервера.
        /// Postgre =timestamp without time zone   	
        /// MSSQL   = DATETIME    
        /// SQLite  = DATETIME
        /// </summary>
        /// <param name="serverType">ServerType: Postgre, MSSQL, SQLite</param>
        /// <returns>Одно из трёх текстовых значений</returns>
        public static string DateTimeFieldType(ServerType serverType = ServerType.Auto)
        {                         
            if (serverType == ServerType.Auto)
        	{
              if  (Var.con != null) serverType = Var.con.serverTypeRemote;
        	  else serverType = ServerType.Postgre; 
        	} 
            string sql = "";
        	switch (serverType)
            {
                case ServerType.Postgre  : sql = "timestamp without time zone "; break; 
                case ServerType.SQLite   : sql = "DATETIME"; break;
                case ServerType.MSSQL    : sql = "DATETIME"; break;               
            } 
			return sql;        	
        }                          
        
        /// <summary>
        /// Слово "день" с правильным окончанием.
        /// </summary>
        /// <param name="value">Количество дней</param>
        /// <returns>дней или дня или день</returns>
		public static string DaysCorrectEnding(int value)
		{  
		  string Result = "дней"; 
		  string s = value.ToString();
		  int LastNum = s.Right(1).ToInt();
		  int PreLastNum = 0;
		  if (s.Length >= 2) PreLastNum = s.RightChar(2).ToInt();
		  
		  if (LastNum == 0) //пример: 0 дней, 10 дней, 100 дней, 230 дней
		    Result = "дней";
		
		  if ((LastNum == 1) && (PreLastNum != 1)) //пример: 1 день, 21 день, 1961 день
		    Result = "день";
		  
		  if ((LastNum == 1) && (PreLastNum == 1)) //пример: 11 дней, 311 дней
		    Result = "дней";
		
		  if ((LastNum >= 2) && (LastNum <= 4) && (PreLastNum != 1)) //пример: 2 дня, 33 дня, 1034 дня
		    Result = "дня";
		  
		  if ((LastNum >= 2) && (LastNum <= 4) && (PreLastNum == 1)) //пример: 12 дней, 113 дней
		    Result = "дней";
		
		  if ((LastNum >= 5) && (LastNum <= 9)) //пример: 15 дней, 288 дней, 29 дней
		    Result = "дней";
		   return Result;
		}		
     	
		
		#region Region. Разница во времени, днях, неделях и т.д.
			
		/// <summary>
		/// Получить разницу во времени между DateTime1 и DateTime2 в виде 12:09:343
		/// </summary>
		/// <param name="dateTime1">Время раннее</param>
        /// <param name="dateTime2">Время позднее</param>
        /// <returns>Разница во времени в виде 12:09:343</returns>
        public static string GetTimeDiff(DateTime dateTime1, DateTime dateTime2)
        {         
            TimeSpan rez = dateTime2 - dateTime1;             
            return string.Format("{0}:{1}:{2}", rez.Minutes.ToString("D2"), rez.Seconds.ToString("D2"), rez.Milliseconds.ToString("D3"));
        }
               
        /// <summary>
        /// Получить разницу во времени между DateTime1 и DateTime2 в виде: 1 Days, 2 Hours, 3 Minutes, 4 Seconds   
        /// </summary>
        /// <param name="dateTime1">Время раннее</param>
        /// <param name="dateTime2">Время позднее</param>
        /// <returns>Разница во времени в виде: 1 Days, 2 Hours, 3 Minutes, 4 Seconds  </returns>
        public static string GetDateDiff(DateTime dateTime1, DateTime dateTime2)
        {         
            TimeSpan rez = dateTime2 - dateTime1;                                           
            return string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds", rez.Days, rez.Hours, rez.Minutes, rez.Seconds);             
        }                           
        
        /// <summary>
        /// Получить разницу во времени в секундах между DateTime1 и DateTime2 в виде 7343
        /// </summary>
        /// <param name="dateTime1">Время раннее</param>
        /// <param name="dateTime2">Время позднее</param>
        /// <returns>Разница во времени в виде целого числа секунд</returns>
        public static int GetSecDiff(DateTime dateTime1, DateTime dateTime2)
        {         
            TimeSpan rez = dateTime2 - dateTime1;
            return ((rez.Days * 86400) + (rez.Hours * 3600) + (rez.Minutes * 60) + rez.Seconds);
        }
                      
        /// <summary>
        /// Получить разницу во времени в милисекундах между DateTime1 и DateTime2 в виде 7343
        /// </summary>
        /// <param name="dateTime1">Время раннее</param>
        /// <param name="dateTime2">Время позднее</param>
        /// <returns>Разница во времени в милисекундах</returns>
        public static string GetMSecDiff(DateTime dateTime1, DateTime dateTime2)
        {         
            TimeSpan rez = dateTime2 - dateTime1;  
            return ((((rez.Days * 86400) + (rez.Hours * 3600) + (rez.Minutes * 60) + rez.Seconds) * 1000) + rez.Milliseconds).ToString();
        }
		
        #endregion Region. Разница во времени, днях, неделях и т.д.
   
}
	
}
		
		
		
		
		
		
		
		
		
	  
 
