/*
* Сделано в SharpDevelop.
* Пользователь: Травин
* Дата: 25.08.2017
* Время: 23:30 
*/

using System;
using System.Collections.Generic;  
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FBA
{       
    /// <summary>
    /// Текстовые и числовые методы.
    /// </summary>
    public static partial class sys
	{		   	                        	       
        /// <summary>
        /// Процедура для показа сообщения MessageBox.Show() 
	    /// TypeMessage: Error, Information, Question, Warning, Stop, Tech или E, I, Q, W, S, T.
        /// Пример: if (sys.SM("Этот форма уже открыта! Переоткрыть?", MessageType.Question) == false) return; 
        /// </summary> 
		/// <param name="messageStr"></param>
		/// <param name="mesType"></param>
		/// <param name="caption"></param>
		/// <param name="memberName"></param>
		/// <param name="filePath"></param>
		/// <param name="lineNumber"></param>
        /// <returns></returns>
        public static bool SM(string messageStr, 
                              MessageType mesType = MessageType.Error, 
                              string caption = "",                  
                              [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                              [System.Runtime.CompilerServices.CallerFilePath]   string filePath   = "",
                              [System.Runtime.CompilerServices.CallerLineNumber] int    lineNumber = 0
            )
        {                                
            //Если глобальная переменная запрещает вывод сообщений, то выходим.
            if (!Var.ShowMes) return false;                                                           
            if (caption == "") caption = mesType.ToString();
            if (Var.SystemName != "") caption = Var.SystemName + ": " + caption;
            
            if (mesType == MessageType.SystemError)
            {
                string fileCS = Path.GetFileName(filePath);                   
                messageStr = messageStr + Var.CR + "Member: " + memberName + ", Line" + lineNumber + ", File: " + fileCS + Var.CR + "Stack: " + Var.CR + GetStackCalls();                
            }

            try
            {
                if (Var.FormMainObj != null)
                    WinAPI.SetForegroundWindow(Var.FormMainObj.Handle.ToInt32());
            }
            catch
            {
            }
        
            var formSM1 = new FormSM(messageStr, mesType, caption);
            WinAPI.SetForegroundWindow(formSM1.Handle.ToInt32()); //Пытаемя вывести окно перед всеми окнами.
            formSM1.ShowDialog();

            if (mesType == MessageType.Error)
            {                
                Error.SendErrorToServer(messageStr, "");
                Error.ErrorsCount++;
            }

            return formSM1.Result;                                          
        }
       
        /// <summary>
        /// Получить информацию по стеку вызовов методов.
        /// </summary>        
        /// <returns>Нет</returns>
        private static string GetStackCalls()
        {                      
            string res = "";
            var stack = new StackTrace(true);
            foreach (StackFrame frame in stack.GetFrames())
            {
                //Console.WriteLine(frame.GetMethod());
                string method = "";
                if (frame.GetMethod() != null) method = frame.GetMethod().ToString();

                string fileLineNumber = frame.GetFileLineNumber().ToString();

                string fileName = "";
                if (frame.GetFileName() != null) fileName = frame.GetFileName().ToString();

                string column = "";
                if (frame.GetMethod() != null) column = frame.GetFileColumnNumber().ToString();

                res = res + "Method: " + method +
                            " FileName: " + fileName +
                            " Position: " + fileLineNumber + @":" + column + Var.CR;
            }
            return res;
        }
     
        /// <summary>
        /// Копирование любого текста в буфер обмена.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <returns>Нет</returns>
        public static void CopyToClipboard(this string inputStr)
        { 
            Clipboard.SetText(inputStr);            
        }                 
           
        /// <summary>
        /// Сохранить текстовую переменную в файл.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
		/// <param name="fileName">Полное имя файла с расширением куда сохраняем текст в переменной inputStr</param>
		/// <param name="showMes">Показывать ошибку записи на диск или нет</param> 		
        /// <returns>true-успешная запись в файл, false-ошибка при записи на диск</returns>
        public static bool SaveToFile(this string inputStr, string fileName, bool showMes = true)
        {
            try
            {
                File.WriteAllText(fileName, inputStr, System.Text.Encoding.Default);
                return true;
            } catch (Exception ex)
            {
            	if (showMes) sys.SM(ex.Message);
                return false;
            }
        }        
         
        /// <summary>
        /// Добавить перенос строки слева, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>       
        /// <returns>Возвращает inputStr c переносом строки вначале, если строка не пустая, и "" если строка inputStr пустая</returns>
        public static string AddLeftCR(ref string inputStr)
        {    
            return AddLeftString(inputStr, Var.CR);
        }
      
        /// <summary>
        /// Добавить строку слева, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
		/// <param name="value">Строка, которую нужно добавить.</param>            
        /// <returns>Возвращает inputStr cо строкой value вначале, если строка не пустая, и "" если строка inputStr пустая</returns>
        public static string AddLeftString(this string inputStr, string value)
        {
            //можно писать через ref. public static void AddLeftCR(ref string inputStr)
            return AddString(inputStr, value, false);
        }
        
        /// <summary>
        /// Добавить пробел слева, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>       
        /// <returns>Возвращает inputStr c ведущим пробелом, если строка не пустая, и "" если строка inputStr пустая</returns>
        public static string AddLeftSpace(this string inputStr)
        {     
            return AddString(inputStr, " ", false);
        }
      
        /// <summary>
        /// Добавить запятую, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>       
        /// <returns>Возвращает inputStr c запятой в конце, если строка не пустая, и "" если строка inputStr пустая</returns>
        public static string AddRightComma(this string inputStr)
        {     
            return AddString(inputStr, ",", true);
        }
        
        /// <summary>
        /// Добавить перенос строки справа, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>       
        /// <returns>Возвращает inputStr c переносом строки в конце, если строка не пустая, и "" если строка inputStr пустая</returns>
        public static string AddRightCR(string inputStr)
        {         
            return AddString(inputStr, Var.CR, true);
        }
    
        /// <summary>
        /// Добавить пробел, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>       
        /// <returns>Возвращает inputStr c пробелом в конце, если строка не пустая, и "" если строка inputStr пустая</returns>
        public static string AddRightSpace(this string inputStr)
        {         
            return AddString(inputStr, " ", true);
        }
    
        /// <summary>
        /// Добавить AND, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>       
        /// <returns>Возвращает inputStr AND, если строка не пустая, и "" если строка inputStr пустая</returns>
        public static string AddRightAND(this string inputStr)
        {          
            return AddString(inputStr, " AND ", true);
        }

        /// <summary>
        /// Добавить OR, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>       
        /// <returns>Возвращает inputStr OR, если строка не пустая, и "" если строка inputStr пустая</returns>
        public static string AddRightOR(this string inputStr)
        {      
            return AddString(inputStr, " OR ", true);
        }

        /// <summary>
        /// Добавить справа или слева произвольную строку, если строка не пустая.
        /// </summary>
        /// <param name="inputStr">Входная строка в которой проверяем наличие подстроки value</param>
        /// <param name="value">Строка которую добавляем</param>
        /// <param name="addRight">Если true, то добавляем справа, иначе слева</param>
        /// <returns>Возврат inputStr после добавления справа или слева value</returns>
        public static string AddString(this string inputStr, string value, bool addRight)
        {            
            if (inputStr == "") return inputStr;
            if (addRight) return inputStr + value;
            else return value + inputStr;          
        }
     
        /// <summary>
        /// Количество символа chr в строке.
        /// </summary>
        /// <param name="inputStr">Входная строка в которой проверяем наличие подстроки value</param>
        /// <param name="chr">символ, которорый считаем</param>
        /// <returns>Количество символов chr в строке inputStr</returns>
        public static int CountChar(this string inputStr, char chr)
        {               
            return inputStr.Split(chr).Length - 1;   
        }            
                
        /// <summary>
        /// Если исходная строка содержится в value, возвращает true.
        /// </summary>
        /// <param name="inputStr">Входная строка в которой проверяем наличие подстроки value</param>
        /// <param name="value">Подстрока, которую ищем в inputStr</param>
        /// <returns>true - строка содержит inputStr, false-не содержит</returns>
        public static bool InStr(this string inputStr, string value)
        {            
            if (value == "") return true;
            return value.IndexOf(inputStr, StringComparison.OrdinalIgnoreCase) > -1;
        }               
               
        /// <summary>
        /// Если исходная строка пустая или содержит 0, то возвращаем true.
        /// </summary>
        /// <param name="inputStr">Проверка на то что строка не null</param>
        /// <returns>true - строка null или пустая, false-содержит выражение</returns>
        public static bool IsEmptyID(string inputStr)
        {            
            if (inputStr == null) return true;           
            if (inputStr == "")   return true;
            if (inputStr == "0")  return true;
            return false;
        }
 
        /// <summary>
        /// Если исходная строка пустая, то возвращаем true.
        /// </summary>
        /// <param name="inputStr">Проверка на то что строка не null</param>
        /// <returns>true - строка null или пустая, false-содержит выражение</returns>
        public static bool IsEmpty(string inputStr)
        {                        
        	return String.IsNullOrEmpty(inputStr);      
        }
     
        /// <summary>
        /// Проверка, что строка является числом INT.
        /// </summary>
        /// <param name="numberStr">Строка в которой число или произвольное выращение</param>
        /// <returns>true - Содержимое строки является числом, false - не является</returns>
        public static bool IsIntegerStr(this string numberStr)
        {
            //1. Способ:
            //if (!int.TryParse(NumberStr, out NumberInt)) return false; //Работает.

            //2. Способ:        
            if (String.IsNullOrEmpty(numberStr)) return false;
            char symb;
            bool digitCheck = true;
            for (int i = 0; i < numberStr.Length; i++)
            {
                symb = numberStr[i];
                 if (('0' > symb) || ('9' < symb)) digitCheck = false;                
            }
            return digitCheck;            
        }

        /// <summary>
        /// Проверка, что строка является числом Float.
        /// </summary>
        /// <param name="floatStr">Входное число в виде текста</param>
        /// <returns>Если число вформате float, то true, иначе false.</returns>
        public static bool IsFloatStr(this string floatStr)
        {
            //1. Способ:
            //ValidationExpression = "^\d+$" — делает проверку на числовые значения
            //return System.Text.RegularExpressions.Regex.IsMatch(text, "[^0-9.-]+"); //"[0-9]*" Работает.
            //if (!int.TryParse(NumberStr, out NumberInt)) return false; //Работает.
            
            //2. Способ:
            char symb;
            bool digitCheck = true;
            for (int i = 0; i < floatStr.Length; i++)
            {
                symb = floatStr[i];
                 if ((('0' > symb) || ('9' < symb)) && (symb != '.')) digitCheck = false;       
            }
            return digitCheck;                
        }

        /// <summary>        
        /// Если value содержится в исходной строке, возвращает true. Поиск производится с настройкой StringComparison.OrdinalIgnoreCase.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="value">Подстрока, которую нужно проверить на вхождение.</param>
        /// <returns>Номер символа, ск которого найдено вхождение, если не найдено, то -1.</returns>
        public static int IndexOfEx(this string inputStr, string value)
        {            
            return inputStr.IndexOf(value, StringComparison.OrdinalIgnoreCase);                    
        }              
        
        /// <summary>
        /// Узнать содержится ли подстрока в другой строке.
        /// Поиск с применением настройки StringComparison.OrdinalIgnoreCase.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="value">Входная строка</param>
        /// <returns>
		/// Если value содержится в исходной строке, возвращает true.       
        /// </returns>
        public static bool IndexOfBool(this string inputStr, string value)
        {            
            return (inputStr.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1);
        }        
            
        /// <summary>
        /// Возвращает строку, которая находится между двух строк. 
        /// beginStr ищется как первое вхождение.
        /// Если endStr не найден, то возвращает пустую строку. 
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="beginStr">Начальная подстрока</param>
        /// <param name="endStr">Конечная подстрока</param>
        /// <returns>Строка между начальной и конечной подстроками</returns>       
        public static string StrBetweenStr(string inputStr, string beginStr, string endStr)
        {
            if (inputStr.Length < 1) return "";
            if (beginStr.Length < 1) return "";
            if (endStr.Length < 1)   return "";           
            int i1 = inputStr.IndexOf(beginStr, StringComparison.OrdinalIgnoreCase);
            if (i1 < 0) return "";
            i1 += beginStr.Length;
        	if (i1 >= inputStr.Length) return "";        
            int i2 = inputStr.IndexOf(endStr, i1, StringComparison.OrdinalIgnoreCase);
            if (i2 < 0) return "";
            if (i2 <= i1) return "";
            return inputStr.Substring(i1, i2 - i1);                 
        }                     
                     
        /// <summary>
        /// Возвращает строку, которая находится между двух строк.
        /// beginStr ищется как первое вхождение.
        /// Если endStr не найден, то возвращает пустую строку.  
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="beginStr">Начальная подстрока</param>
        /// <param name="endStr">Конечная подстрока</param>
        /// <returns>Строка между начальной и конечной подстроками</returns>      
        public static string StringBetween(this string inputStr, string beginStr, string endStr)
        {           
            return StrBetweenStr(inputStr, beginStr, endStr);
        }
                    
		/// <summary>
		/// Возвращает строку, которая находится между двух строк.
        /// beginStr ищется как первое вхождение.
        /// Если endStr не найден, то возвращает до конца строки.  
		/// </summary>
		/// <param name="inputStr">Входная строка</param>
        /// <param name="beginStr">Начальная подстрока</param>
        /// <param name="endStr">Конечная подстрока</param>
        /// <returns>Строка между начальной и конечной подстроками</returns>      
        public static string StrBetweenStr2(this string inputStr, string beginStr, string endStr = "")
        {
            if (inputStr == "") return "";
            if (beginStr == "") return "";                      
            int i1 = inputStr.IndexOf(beginStr, StringComparison.OrdinalIgnoreCase);
            if (i1 < 0) return "";
            i1 = i1 + beginStr.Length;
            if (i1 >= inputStr.Length) return "";
            int i2 = inputStr.Length;
            if (endStr != "") 
                i2 = inputStr.IndexOf(endStr, i1, StringComparison.OrdinalIgnoreCase);    
            return inputStr.Substring(i1, i2 - i1);                 
        }            
             
        /// <summary>
        /// Возвращает строку, которая находится между двух строк.
        /// beginStr ищется как последнее вхождение.
        /// Если endStr не найден, то возвращает пустую строку. 
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="beginStr">Начальная подстрока</param>
        /// <param name="endStr">Конечная подстрока</param>
        /// <returns>Строка между начальной и конечной подстроками</returns>     
        public static string StrBeweenStr3(string inputStr, string beginStr, string endStr)
        {                                                                         
            if (inputStr.Length < 1) return "";
            if (beginStr.Length < 1) return "";
            if (endStr.Length   < 1) return ""; 
            //xxxBBB1xxxBBB2xxxEEE1xxxEEE2xxx
            int i1 = inputStr.LastIndexOf(endStr, StringComparison.OrdinalIgnoreCase);
            
            //xxxBBB1xxxBBB2xxxEEE1xxx
            int len = inputStr.Substring(0, i1).Reverse().IndexOf(beginStr, 0, StringComparison.OrdinalIgnoreCase);
            return inputStr.Substring(i1 - len, len);
            //111BBB222EEE333BBB444EEE555               
        }

		/// <summary>
		/// Возвращает строку, которая находится между двух строк, beginStr и endStr не возвращаются.
        /// beginStr ищется как первое вхождение.
        /// Если endStr не найден, то возвращает до конца строки.
		/// </summary>
		/// <param name="inputStr">Входная строка</param>
        /// <param name="beginStr">Начальная подстрока</param>
        /// <param name="endStr">Конечная подстрока</param>
        /// <returns>Строка между начальной и конечной подстроками</returns>  
        public static string StrBetweenStr4(this string inputStr, string beginStr, string endStr = "")
        {
            if (inputStr == "") return "";
            if (beginStr == "") return "";

            int i1 = inputStr.IndexOf(beginStr, StringComparison.OrdinalIgnoreCase);
            if (i1 < 0)
                return inputStr;

            i1 = i1 + beginStr.Length;
            if (i1 >= inputStr.Length)
                return inputStr;

            int i2 = inputStr.Length;
            if (endStr != "")
            {
                i2 = inputStr.LastIndexOf(endStr, StringComparison.OrdinalIgnoreCase);
                //i2 = i2 - endStr.Length;
                if ((i2 < 0) || (i2 <= i1)) return inputStr;
            }
            return inputStr.Substring(i1, i2 - i1);
        }       
      
		/// <summary>
		/// Возвращает строку, которая следует после строки beginStr.
        /// Если beginStr не найден, то возвращается исходная строка.    
		/// </summary>
		/// <param name="inputStr">Входная строка</param>
        /// <param name="beginStr">Начальная подстрока</param>   
        /// <returns>Строка между начальной и конечной подстроками</returns>  
        public static string StrAfterStr(this string inputStr, string beginStr)
        {                          
            int N = inputStr.IndexOf(beginStr, StringComparison.OrdinalIgnoreCase);
            if (N == -1) return inputStr;
            return inputStr.Substring(N + beginStr.Length);
        }                   
        
        /// <summary>
        /// Строка между строк. 
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="beginStr">Начальная подстрока</param>
        /// <returns>
        /// Возвращает строку, которая следует до строки beginStr.
        /// Если beginStr не найден, то возвращается исходная строка.
        /// </returns>
        public static string StrBeforeStr(this string inputStr, string beginStr)
        {                          
            int N = inputStr.IndexOf(beginStr, StringComparison.OrdinalIgnoreCase);
            if (N == -1) return inputStr;
            return inputStr.Substring(0, N);
        }
              
        /// <summary>
        /// Для типа bool. Функции ToInt(). 
        /// </summary>
        /// <param name="inputBool">Входная строка</param>
        /// <returns>Число, в которое преобразован переменная bool</returns>  
        public static int ToInt(this bool inputBool)
        {          
            return inputBool ? 1 : 0;
        }   
        
        /// <summary>
        /// Для типа string. Функции ToInt(). 
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="showError">Показывать ошибку или нет</param>
        /// <returns>Число, в которое преобразована строка</returns>        
        public static int ToInt(this string inputStr, bool showError = true)
        {                     
            int num = 0;
            //return Convert.ToInt32(inputChar);           
            if (inputStr == "") return 0;
            if (inputStr.ToUpper() == "NULL") return 0;
            if (!int.TryParse(inputStr, out num))
            {
                if (showError) sys.SM("Ошибка преобразования string в int");
                return 0;
            }
            return num;                    
        }
        		
		/// <summary>
        /// Для типа char. Функции ToInt().
        /// </summary>
        /// <param name="inputChar">Входной символ</param>
        /// <returns>Возвращает Convert.ToInt32(inputChar)</returns>
        public static int ToInt(this char inputChar)
        {
            return Convert.ToInt32(inputChar); //Для char нет TryParse.    
        }
      
        /// <summary>
        /// Для типа string. Функции ToShort(). 
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <returns>Возвращает short.TryParse(inputStr, out num))</returns>
        public static short ToShort(this string inputStr)
        {
            short num;
            if (!short.TryParse(inputStr, out num)) return 0;
            return num;         
        }
               
        /// <summary>
        ///Для типа char. Функции ToShort(). 
        /// </summary>
        /// <param name="inputChar">Входной символ</param>
        /// <returns>Возвращает Convert.ToInt16(inputChar)</returns>
        public static short ToShort(this char inputChar)
        {
            return Convert.ToInt16(inputChar); //Для char нет TryParse.
        }

        /// <summary>
        /// Для типа string. Преобразование значения в bool. 
        /// Пустая строка, значение "0" или значение "false" возвращает false.
        /// Если "1" или "true", то результат true.
        /// Если проозвольное строковое значение, то попытка преобразования неуспешна - выдает ошибку.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <returns>Если преобразование успешно, то результат преобрахования, если не успешно, выдает сообщение об ошибке.</returns>
        public static bool ToBool(this string inputStr)
        {       
            if (inputStr == "") return false; 
            if (inputStr == "true") return true;
            if (inputStr == "false") return false;
            if (inputStr == "1") return true;
            if (inputStr == "0") return false;
            if (inputStr.ToLower() == "true") return true;
            if (inputStr.ToLower() == "false") return false;
            sys.SM("Ошибка преобразования string в bool (ToBool)");
            return false;
        }

        /// <summary>
        /// Для типа string. Преобразование значения в bool.
        /// </summary>
        /// <param name="inputvalue">Входная строка</param>
        /// <returns>Если число больше 0, то true иначе false. Ошибок не выдает.</returns>
        public static bool ToBool(this int inputvalue)
        {       
            if (inputvalue > 0) return true;
            return false;            
        }
        
        ///Для типа STRING. Функции LEFT() до указанной подстроки.
        public static string Left(this string inputStr, string beginStr)
        {          
            int k = inputStr.IndexOf(beginStr, StringComparison.OrdinalIgnoreCase);
            if (k > -1) return inputStr.Substring(0, k);
            	else return "";
        }               
        
        /// <summary>
        /// Для типа string. Аналог функции LEFT() в SQL.
        /// </summary>
        /// <param name="inputStr">Входная строк</param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Left(this string inputStr, int maxLength)
        {
            //Вызывать можно так: string ss = ss.Left(10); (во всех сборках, где подключен sys). 
            if (string.IsNullOrEmpty(inputStr)) return inputStr;
            maxLength = Math.Abs(maxLength);   
            return (inputStr.Length <= maxLength ? inputStr : inputStr.Substring(0, maxLength));            
        }
        
        ///Для типа string. Последние CountChar символов.
        public static string Right(this string inputStr, int countChar)
        {      
			
            int N = inputStr.Length;
			if (countChar > N) countChar = N;
			return inputStr.Substring(N - countChar);  
        }

        /// <summary>
        /// Для типа string. Возвращает CountChar символ с конца. 
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="countChar">Количество символов</param>
        /// <returns></returns>
        public static string RightChar(this string inputStr, int countChar)
        {      
			
            int N = inputStr.Length;
			if (countChar > N) countChar = N;
			return inputStr.Substring(N - countChar, 1);  			  
        }

        /// <summary>
        /// Для типа string. Нормальный SubString, как в Delphi, можно указывать Length, превышающую длину inputStr.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="firstChar">Номер символа, с которого возвращать подстроку</param>
        /// <param name="length">Кодичество символов</param>
        /// <returns>Возвращает подстроку</returns>
        public static string SubStringEnd(this string inputStr, int firstChar, int length = 0)
        {
            //Вызывать можно так: string ss = ss.SubStringEnd(1, 100000);
            //if (inputStr == null) return "";
            if (firstChar >= inputStr.Length) return "";
            if (length == 0) length = inputStr.Length - firstChar;
            else if ((firstChar + length) > inputStr.Length) length = inputStr.Length - firstChar;
            return inputStr.Substring(firstChar, length);                         
        }

        /// <summary>
        /// Для типа string. Замена подстроки без учета регистра. Работает, но ОЧЕНЬ медленно.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="oldStr">Строка, которую нужно заменить</param>
        /// <param name="newStr">Строка, на которую нужно заменить</param>
        /// <param name="countReplace">Количество замен. Если 0, то без ограничения.</param>
        /// <returns>Строку поде замены</returns>
        public static string ReplaceIgnoreCase(this string inputStr, string oldStr, string newStr, int countReplace)
        {                         
            int i = inputStr.IndexOf(oldStr, StringComparison.OrdinalIgnoreCase);
            if (i == -1) return inputStr;
            int N = oldStr.Length;  
            if (countReplace < 0) return inputStr;
            if (countReplace == 0)
            while (i > -1) 
            {
                inputStr = inputStr.Remove(i, N);
                inputStr = inputStr.Insert(i, newStr);
                i = inputStr.IndexOf(oldStr, StringComparison.OrdinalIgnoreCase);
            } 
            int countReplaceN = 0;
            if (countReplace > 0)
            {
            	while ((i > -1) && (countReplaceN <= countReplace))
	            {
	                inputStr = inputStr.Remove(i, N);
	                inputStr = inputStr.Insert(i, newStr);
	                i = inputStr.IndexOf(oldStr, StringComparison.OrdinalIgnoreCase);
	                countReplaceN++;
	            }
            }
            return inputStr;
            //return Regex.Replace(inputStr, OldStr, NewStr, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Для типа string. Замена повторений символа в строке. Например, можно заменить повторяющиеся пробелы на один.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="ch">Cимвол, на который будет произведена замена</param>
        /// <returns></returns>
        public static string ReplaceRepeatChars(this string inputStr, char ch)
        {                          
            return string.Join(ch.ToString(), inputStr.Split(new char[] {ch}, StringSplitOptions.RemoveEmptyEntries));                     
        }

        /// <summary>
        /// Для типа string. Функция заменяет в строке символ в позиции Index на ch. Не протестировано.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="index">В какой позиции заменить символ</param>
        /// <param name="ch">Cимвол, на который будет произведена замена</param>
        /// <returns></returns>
        public static string ReplaceCharInString(this string inputStr, int index, char ch)
        {             
             var builder = new StringBuilder(inputStr); 
             builder[index] = ch;
             return builder.ToString();
             //Вероятно это будет медленнее:
             //return inputStr.Remove(Index, 1).Insert(Index, ch.ToString());               
        }

        /// <summary>
        /// Возвращает строку, в которой все символы, которые в строке chars удалены.
        /// В параметре chars строка с символами для замены без разделителей, например abcvfwgs
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="chars">Список символов без разделителе, например abcvfwgs</param>
        /// <returns></returns>
        public static string DeleteCharsInString(this string inputStr, string chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                string stold = chars[i].ToString();
                inputStr = inputStr.Replace(stold, "");
            }
            return inputStr;
        }

        /// <summary>
        /// Возвращает строку, в которой удалены все строки, которые находятся в строке words.
        /// В параметре words строки, разделёнными символом  ch.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="words">Список строк, разделённых символом ch</param>
        /// <param name="ch">Символ разделитель слов в words</param>
        /// <returns></returns>
        public static string DeleteWordsInString(this string inputStr, string words, char ch)
        {
            //string[] arr = words.Split(ch);
            //for (int i = 0; i < arr.Length; i++)
            // {
            //    string stold = arr[i];
            //    inputStr = inputStr.Replace(stold, "");
            // }
            //return inputStr;
            string[] arrinputStr = inputStr.Split(' ');
            string[] arrCh = words.Split(ch);
            for (int i = 0; i < arrinputStr.Length; i++)
            {
                for (int j = 0; j < arrCh.Length; j++)
                {
                    if (arrinputStr[i] == arrCh[j]) arrinputStr[i] = "";
                }
            }
            return String.Join(" ", arrinputStr);
        }

        /// <summary>
        /// Возвращает строку, в которой удалены все подстроки, которые находятся в строке strings.
        /// В параметре strings строки, разделёнными символом  ch.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="words">Список строк, разделённых символом ch</param>
        /// <param name="ch">Символ разделитель слов в words</param>
        /// <returns></returns>
        public static string DeleteStringsInString(this string inputStr, string words, char ch)
        {

            string[] arr = words.Split(ch);
            for (int i = 0; i < arr.Length; i++)
             {
                string stold = arr[i];
                inputStr = inputStr.Replace(stold, "");
             }
            return inputStr;
        }

        /// <summary>
        /// Возвращает строку, в которой все символы, которые в не находятся строке chars удалены.
        /// В параметре chars строка с символами, например abcvfwgs
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="chars">Список символов без разделителей, например abcvfwgs</param>
        /// <returns></returns>
        public static string LeaveCharsInString(this string inputStr, string chars)
        {        
            StringBuilder outPuth = new StringBuilder();
            foreach (char item in inputStr)
                if (chars.IndexOf(item) != -1)
                    outPuth.Append(item);
            return outPuth.ToString();    
        }

        /// <summary>
        /// Для типа STRING. Первую букву слова перевести в верхний регистр. Не протестировано.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <returns>преобразует перов к Петров</returns>
        public static string FirstCharUpper(this string inputStr)
        {
			if (inputStr.Length < 2) return inputStr.ToUpper();
            return System.Char.ToUpper(inputStr[0]) + inputStr.Substring(1);                        
        }

        /// <summary>
        /// Для типа string. Первую буква всех слов перевести в верхний регистр.
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns>преобразует пероВ ИЛЬЯ вЛаДимирович к Петров Илья Владимирович</returns>
        public static string FirstCharsUpperOtherLower(this string inputStr)              
        {
            //Второй вариант реализации.
            //Функция преобразует строку aString, состоящую из слов,
            //разделенных пробелами, к виду: "Abcde Abcde Abcde"
            //Не протестировано.
            /*public static string NameCase(string inputStr)
            {
                string Result = "";
                string sTemp = inputStr.ToLower().Trim();
                while (sTemp.Length > 0)
                {
                    string s = ChooseWord(sTemp, 1);
                    Result = Result + " " + s.FirstCharUpper() + s.Substring(1);
                    sTemp = sTemp.Right(sTemp.Length - s.Length).Trim();
                }
                return Result;
            }*/


            inputStr = inputStr.ToLower();
            string[] s = inputStr.Split(' ');
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > 1)
                    s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1);
                else s[i] = s[i].ToUpper();
            }
            return string.Join(" ", s);
        }      
   
        ///Реверс строки. Не протестировано.
        public static string Reverse(this string inputStr)
	    {
	        return new string(inputStr.ToCharArray().Reverse().ToArray());
	    }

        /// <summary>
        /// Повторить строку count раз.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="count">Сколько раз повторять строку</param>
        /// <returns></returns>
        public static string RepeatString (this string inputStr, int count)
        {
            if (count == 0) return "";
            string inputStrOld = inputStr;
            for (int i = 0; i <= count; i++)
            {
                inputStr = inputStr + inputStrOld;
            }
            return inputStr;
        }

        /// <summary>
        /// Текстовая константа. Это Сборки по умолчанию, которые добавляются при создании новой формы.
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultAssemblies()
        {
        	return "System.dll" +  Var.CR +
        		   "System.Core.dll" + Var.CR +
				   "System.Data.dll" + Var.CR + 
				   "System.Data.DataSetExtensions.dll" + Var.CR + 
				   "System.Deployment.dll" + Var.CR + 
				   "System.Drawing.dll" + Var.CR + 
				   "System.Windows.Forms.dll" + Var.CR + 
				   "System.Xml.dll" + Var.CR + 
                   "System.Xml.Linq.dll";  
        }

        /// <summary>
        /// Текстовые константы. Это Пространства имен по умолчанию, которые добавляются при создании новой формы.
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultUsing()
        {
   			return  "System" + Var.CR +	
					"System.ComponentModel" + Var.CR +	
					"System.Collections" + Var.CR +	
					"System.Diagnostics" + Var.CR +	
					"System.Globalization" + Var.CR +	
					"System.IO" + Var.CR +	
					"System.Reflection" + Var.CR +	
					"System.Runtime.Serialization.Formatters.Binary" + Var.CR +	
					"System.Text" + Var.CR +	
					"System.Windows.Forms" + Var.CR +	
   				    "System.Xml";       	
        }

        /// <summary>
        /// Текстовые константы. 
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultProject()
        {
            return  "namespace FBA                                       " + Var.CR +
            "{                                                              " + Var.CR +
            "    using System;                                              " + Var.CR +
            "    using System.ComponentModel;                               " + Var.CR +
            "    using System.Collections;                                  " + Var.CR +
            "    using System.Diagnostics;                                  " + Var.CR +
            "    using System.Globalization;                                " + Var.CR +
            "    using System.IO;                                           " + Var.CR +
            "    using System.Reflection;                                   " + Var.CR +
            "    using System.Runtime.Serialization.Formatters.Binary;      " + Var.CR +
            "    using System.Text;                                         " + Var.CR +
            "    using System.Windows.Forms;                                " + Var.CR +
            "    using System.Xml;                                          " + Var.CR +
            "                                                               " + Var.CR +
            "    public static class Query {public static string q1 = @'';} " + Var.CR +
            "                                                               " + Var.CR +
            "    public class FormMain1 : System.Windows.Forms.Form         " + Var.CR +
            "    {                                                          " + Var.CR +
            "                                                               " + Var.CR +
            "        private System.Windows.Forms.Button button1;           " + Var.CR +
            "                                                               " + Var.CR +
            "        public FormMain1()                                     " + Var.CR +
            "        {                                                      " + Var.CR +
            "            this.InitializeComponent();                        " + Var.CR +
            "        }                                                      " + Var.CR +
            "                                                               " + Var.CR +
            "        private void InitializeComponent()                     " + Var.CR +
            "        {                                                      " + Var.CR +
            "            this.button1 = new System.Windows.Forms.Button();  " + Var.CR +
            "            this.SuspendLayout();                              " + Var.CR +
            "            //                                                 " + Var.CR +
            "            // button1                                         " + Var.CR +
            "            //                                                 " + Var.CR +
            "            this.button1.Location = new System.Drawing.Point(21, 12); " + Var.CR +
            "            this.button1.Name = 'button1';                            " + Var.CR +
            "            this.button1.Size = new System.Drawing.Size(127, 43);     " + Var.CR +
            "            this.button1.TabIndex = 0;                         " + Var.CR +
            "            this.button1.Text = 'TEST';                        " + Var.CR +
            "            this.button1.UseVisualStyleBackColor = true;       " + Var.CR +
            "            this.button1.Click += new System.EventHandler(this.handler_button1_Click); " + Var.CR +
            "            //                                                 " + Var.CR +
            "            // FormMain1                                       " + Var.CR +
            "            //                                                 " + Var.CR +
            "            this.ClientSize = new System.Drawing.Size(160, 67);" + Var.CR +
            "            this.Controls.Add(this.button1);                   " + Var.CR +
            "            this.Name = 'FormMain1';                           " + Var.CR +
            "            this.Text = 'FormMain1';                           " + Var.CR +
            "            this.ResumeLayout(false);                          " + Var.CR +
            "        }                                                      " + Var.CR +
            "                                                               " + Var.CR +
            "        [System.STAThreadAttribute()]                          " + Var.CR +
            "        public static void Main()                              " + Var.CR +
            "        {                                                      " + Var.CR +
            "            System.Windows.Forms.Application.Run(new FormMain1());  " + Var.CR +
            "        }                                                      " + Var.CR +
            "                                                               " + Var.CR +          
            "        private void handler_button1_Click(Object sender, EventArgs e)  " + Var.CR +
            "        {                                                      " + Var.CR +
            "            //ExampleCode                                      " + Var.CR +
            "        }                                                      " + Var.CR +
            "    }                                                          " + Var.CR +
            "}                                                              " ;                                                                   
        }

        /// <summary>
        /// Шаблон простого класса
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultClass()
        {        	                    
	            return "//Произвольный класс              " + Var.CR +
	            "public class MyClass                     " + Var.CR +
	            "{                                        " + Var.CR +	
		        "    private string LocalField;           " + Var.CR +					
		        "    public string GetString(string Param)" + Var.CR +
		        "    {			                          " + Var.CR +
		        " 	    return Param;                     " + Var.CR +
		        "    }                                    " + Var.CR +
	            "}";
        }

        /// <summary>
        /// Для того чтобы можно было строку посылать в качестве параметров запросов на сервер.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <returns></returns>
        public static string QueryQuote(this string inputStr)
        {
            return inputStr.Replace("'", "''");
        }

        /// <summary>
        /// Транслитерация символа в латиницу.
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        public static string SymbolCyr2Lat(this char inputChar)
        {
            string resultChar = "";
            char ch = inputChar;
            bool isLower = false;
            if (char.IsLower(inputChar)) 
            {               
                ch = char.ToUpper(inputChar);
                isLower = true;
            }                                            
            switch (ch)
            {
                case 'А': resultChar = "A";   break;
                case 'Б': resultChar = "B";   break;
                case 'В': resultChar = "V";   break;
                case 'Г': resultChar = "G";   break;
                case 'Д': resultChar = "D";   break;
                case 'Е': resultChar = "E";   break;
                case 'Ё': resultChar = "JE";  break;
                case 'Ж': resultChar = "ZH";  break;
                case 'З': resultChar = "Z";   break;
                case 'И': resultChar = "I";   break;
                case 'Й': resultChar = "Y";   break;
                case 'К': resultChar = "K";   break;
                case 'Л': resultChar = "L";   break;
                case 'М': resultChar = "M";   break;
                case 'Н': resultChar = "N";   break;
                case 'О': resultChar = "O";   break;
                case 'П': resultChar = "P";   break;
                case 'Р': resultChar = "R";   break;
                case 'С': resultChar = "S";   break;
                case 'Т': resultChar = "T";   break;
                case 'У': resultChar = "U";   break;
                case 'Ф': resultChar = "F";   break;
                case 'Х': resultChar = "KH";  break;
                case 'Ц': resultChar = "C";   break;
                case 'Ч': resultChar = "CH";  break;
                case 'Ш': resultChar = "SH";  break;
                case 'Щ': resultChar = "JSH"; break;
                case 'Ъ': resultChar = "HH";  break;
                case 'Ы': resultChar = "IH";  break;
                case 'Ь': resultChar = "JH";  break;
                case 'Э': resultChar = "EH";  break;
                case 'Ю': resultChar = "JU";  break;
                case 'Я': resultChar = "JA";  break;
                default: resultChar = ch.ToString().ToUpper();break;
            }
            if (isLower) resultChar = resultChar.ToLower();
            return  resultChar;
        }

        /// <summary>
        /// Транслитерация строки в латиницу.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <returns></returns>
        public static string StringCyr2Lat(this string inputStr)
        {
            string result = "";
            for (int i= 0; i < inputStr.Length; i++)
            {
                result = result + SymbolCyr2Lat(inputStr[i]);
            }
            return result;               
        }

        /// <summary>
        /// Транслитерация латиницы в строку.
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string StringLat2Cyr(this string inputStr)
        {
            //https://habrahabr.ru/post/265455/
            string s = inputStr.ToUpper();
            string sb = "";
            bool isLower = false;
            int i = 0;
            while(i < s.Length)
            {   //идем по строке слева направо.  
                char ch = s[i];
                string sym = "";
                isLower = (char.IsLower(inputStr[i]));
                if(ch == 'J')
                {   //префиксная нотация вначале                   
                    i++; //преходим ко второму символу сочетания
                    ch = s[i];
                    switch (ch)
                    {
                        case 'E': sym = "Ё"; break;
                        case 'S':
                            sym = "Щ";
                            i++; //преходим к третьему символу сочетания
                            if(s[i] != 'H') throw new Exception("Illegal transliterated symbol at position " + i); //вариант третьего символа только один
                            break;
                        case 'H': sym = "Ь"; break;
                        case 'U': sym = "Ю"; break;
                        case 'A': sym = "Я"; break;
                        default: throw new Exception("Illegal transliterated symbol at position " + i);
                    }
                }else if(i + 1 < s.Length && s[i + 1] == 'H' && !(i + 2 < s.Length && s[i+2] == 'H'))
                {   //постфиксная нотация, требует информации о двух следующих символах. Для потока придется сделать обертку с очередью из трех символов.
                    switch (ch){
                        case 'Z': sym = "Ж"; break;
                        case 'K': sym = "Х"; break;
                        case 'C': sym = "Ч"; break;
                        case 'S': sym = "Ш"; break;
                        case 'E': sym = "Э"; break;
                        case 'H': sym = "Ъ"; break;
                        case 'I': sym = "Ы"; break;
                        default: throw new Exception("Illegal transliterated symbol at position "+i);
                    }
                    i++; //пропускаем постфикс
                }else{ //одиночные символы
                    switch (ch){
                        case 'A': sym = "А"; break;
                        case 'B': sym = "Б"; break;
                        case 'V': sym = "В"; break;
                        case 'G': sym = "Г"; break;
                        case 'D': sym = "Д"; break;
                        case 'E': sym = "Е"; break;
                        case 'Z': sym = "З"; break;
                        case 'I': sym = "И"; break;
                        case 'Y': sym = "Й"; break;
                        case 'K': sym = "К"; break;
                        case 'L': sym = "Л"; break;
                        case 'M': sym = "М"; break;
                        case 'N': sym = "Н"; break;
                        case 'O': sym = "О"; break;
                        case 'P': sym = "П"; break;
                        case 'R': sym = "Р"; break;
                        case 'S': sym = "С"; break;
                        case 'T': sym = "Т"; break;
                        case 'U': sym = "У"; break;
                        case 'F': sym = "Ф"; break;
                        case 'C': sym = "Ц"; break;
                        default: sym = ch.ToString(); break;
                    }
                }
                if (isLower) sb = sb + sym.ToLower();
                  else sb = sb + sym;
                i++; //переходим к следующему символу
            }
            return sb;
        }  
        
        /// <summary>
        /// Преобразовать строку в Base64.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <returns>Возвращает строку, преобразованную в формат Base64</returns>
        public static string StringToBase64(this string inputStr)
        {            
            if (inputStr == null) return "";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(inputStr);
            return Convert.ToBase64String(buffer);  
        }

        /// <summary>
        /// Получить нормальную строку из строки Bas64. 
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns>Возвращает строку, преобразованную из строки формата Base64</returns>
        public static string Base64ToString(this string inputStr)
        {            
            byte[] buffer = Convert.FromBase64String(inputStr);
            return System.Text.Encoding.UTF8.GetString(buffer); 
        }

        /// <summary>
        /// Число прописью (числительное мужского рода). Не протестировано.
        /// </summary>
        /// <param name="number">Число int</param>
        /// <returns></returns>
        public static string NumberSpelled(int number)
		{
			switch (number)
			{
		    	case 1  : return "Первый";
		    	case 2  : return "Второй";  
		    	case 3  : return "Третий"; 
		    	case 4  : return "Четвертый";   
		    	case 5  : return "Пятый";  
		    	case 6  : return "Шестой";  
		    	case 7  : return "Седьмой"; 
		    	case 8  : return "Восьмой"; 
		    	case 9  : return "Девятый"; 
		    	case 10 : return "Десятый"; 
		    	case 11 : return "Одиннадцатый";
		    	case 12 : return "Двенадцатый"; 
		    	case 13 : return "Тринадцатый"; 
		    	case 14 : return "Четырнадцатый";
		    	case 15 : return "Пятнадцатый";  
		    	case 16 : return "Шестнадцатый"; 
		    	default :return "<НЕИЗВЕСТНОЕ ЧИСЛО>";  
			}
		 
		}
				
		/// <summary>
        /// Функция возвращает строку, состоящую из заданного количества одинаковых символов.		  
		/// Пример вызова: s := StringOfChar('...', 3). 
		/// Не протестировано.
        /// </summary>
        /// <param name="ch">Символ, котрый нужно повторить</param>
        /// <param name="count">Количество повторений</param>
        /// <returns>Строку, состаящую из сивола ch длиной count символов</returns>
		public static string StringOfChar (string ch, int count) 
		{
		  string result = "";
		  for (int i = 1; i <= count; i++) result += ch;
		  return result;
		}
				
		/// <summary>
        /// Функция меняет ФИО на ИОФ. Т.е. просто меняет слова местами.
		/// Пример: ReverseFIO('Антонец Сергей Владимирович'); 
		/// Не протестировано.
        /// </summary>
        /// <param name="personName">ФИО</param>
        /// <returns>ИОФ - меняет слова местами</returns>
		public static string ReverseName(string personName)
		{
			int p1 = personName.IndexOf(' '); 
			return personName.Substring(p1 + 1).Trim() + " " + personName.Substring(1, p1).Trim();			
		}
				 
		
		/// <summary>
        /// Меняем одинаковые по начертанию.
		/// Если ToEnglish = True то приводим к английской раскладке, иначе к русской.
		/// Пример использования: string MKBCode = SymbolRusEnglish("K02.1", true); 
		/// Не протестировано.
        /// </summary>
        /// <param name="inputStr">Строка в котрой нужно заменить символы одинаковые по начертанию</param>
        /// <param name="toEnglish">Английский или Русский язык</param>
        /// <returns>Строка, приведённая к указанному языку</returns>
		public static string SymbolRusEnglish(string inputStr, bool toEnglish)    
		{
		  int m = 0;
		  int n = 0;
		  char[,] ar = new char[3, 20];
		  //1 - Английские, 2 - Русские
		  ar[1, 1]  = 'E'; ar[2, 1]  = 'Е';
		  ar[1, 2]  = 'T'; ar[2, 2]  = 'Т';
		  ar[1, 3]  = 'O'; ar[2, 3]  = 'О';
		  ar[1, 4]  = 'P'; ar[2, 4]  = 'Р';
		  ar[1, 5]  = 'A'; ar[2, 5]  = 'А';
		  ar[1, 6]  = 'H'; ar[2, 6]  = 'Н';
		  ar[1, 7]  = 'K'; ar[2, 7]  = 'К';
		  ar[1, 8]  = 'X'; ar[2, 8]  = 'Х';
		  ar[1, 9]  = 'C'; ar[2, 9]  = 'С';
		  ar[1, 10] = 'B'; ar[2, 10] = 'В';
		  ar[1, 11] = 'M'; ar[2, 11] = 'М';	
		  ar[1, 12] = 'e'; ar[2, 12] = 'е';
		  ar[1, 13] = 'o'; ar[2, 13] = 'о';
		  ar[1, 14] = 'p'; ar[2, 14] = 'р';
		  ar[1, 15] = 'a'; ar[2, 15] = 'а';
		  ar[1, 16] = 'k'; ar[2, 16] = 'к';
		  ar[1, 17] = 'x'; ar[2, 17] = 'х';
		  ar[1, 18] = 'c'; ar[2, 18] = 'с';
		  ar[1, 19] = 'm'; ar[2, 19] = 'м';
		
		  if (toEnglish) 
		  {
		     n = 2;
		     m = 1;
		  } else
		  {
		     n = 1;
		     m = 2;
		  }
		
		  for (int i = 1; i <= inputStr.Length; i++)
		  	for (int j = 1; j <= 19; j++)
		   
		  		if (inputStr[i] == ar[n, j]) inputStr.ReplaceCharInString(i, ar[m, j]);  //s.Replace(s[i] = Ar[m, j];
		
		  return inputStr;
		}
      
		
		/// <summary>
        /// Транслитерация. Меняем раскладку с английской на русскую и обратно
		/// Если ToEnglish = True то приводим к английской раскладке, иначе к русской.
		/// Пример использования: MKBCode := StrUtilsSU.KeyboardSymbRusEnglish('фыв', True);
		/// Не протестировано. 
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="toEnglish">Английский или Русский язык.</param>    
        /// <returns>Текст транслит.</returns>
	  	public static string KeyboardSymbRusEnglish(string inputStr, bool toEnglish)	     
		{   int n = 0;
			int m = 0;
			char[,] ar = new char[3, 53];
			//1 - Английские, 2 - Русские
			ar[1, 1]  = 'Q'; ar[2, 1]  = 'Й';
			ar[1, 2]  = 'W'; ar[2, 2]  = 'Ц';
			ar[1, 3]  = 'E'; ar[2, 3]  = 'У';
			ar[1, 4]  = 'R'; ar[2, 4]  = 'К';
			ar[1, 5]  = 'T'; ar[2, 5]  = 'Е';
			ar[1, 6]  = 'Y'; ar[2, 6]  = 'Н';
			ar[1, 7]  = 'U'; ar[2, 7]  = 'Г';
			ar[1, 8]  = 'I'; ar[2, 8]  = 'Ш';
			ar[1, 9]  = 'O'; ar[2, 9]  = 'Щ';
			ar[1, 10] = 'P'; ar[2, 10] = 'З';
			ar[1, 11] = 'A'; ar[2, 11] = 'Ф';
			ar[1, 12] = 'S'; ar[2, 12] = 'Ы';
			ar[1, 13] = 'D'; ar[2, 13] = 'В';
			ar[1, 14] = 'F'; ar[2, 14] = 'А';
			ar[1, 15] = 'G'; ar[2, 15] = 'П';
			ar[1, 16] = 'H'; ar[2, 16] = 'Р';
			ar[1, 17] = 'J'; ar[2, 17] = 'О';
			ar[1, 18] = 'K'; ar[2, 18] = 'Л';
			ar[1, 19] = 'L'; ar[2, 19] = 'Д';
			ar[1, 20] = 'Z'; ar[2, 20] = 'Я';
			ar[1, 21] = 'X'; ar[2, 21] = 'Ч';
			ar[1, 22] = 'C'; ar[2, 22] = 'С';
			ar[1, 23] = 'V'; ar[2, 23] = 'М';
			ar[1, 24] = 'B'; ar[2, 24] = 'И';
			ar[1, 25] = 'N'; ar[2, 25] = 'Т';
			ar[1, 26] = 'M'; ar[2, 26] = 'Ь';
			
			ar[1, 27] = 'q'; ar[2, 27] = 'й';
			ar[1, 28] = 'w'; ar[2, 28] = 'ц';
			ar[1, 29] = 'e'; ar[2, 29] = 'у';
			ar[1, 30] = 'r'; ar[2, 30] = 'к';
			ar[1, 31] = 't'; ar[2, 31] = 'е';
			ar[1, 32] = 'y'; ar[2, 32] = 'н';
			ar[1, 33] = 'u'; ar[2, 33] = 'г';
			ar[1, 34] = 'i'; ar[2, 34] = 'ш';
			ar[1, 35] = 'o'; ar[2, 35] = 'щ';
			ar[1, 36] = 'p'; ar[2, 36] = 'з';
			ar[1, 37] = 'a'; ar[2, 37] = 'ф';
			ar[1, 38] = 's'; ar[2, 38] = 'ы';
			ar[1, 39] = 'd'; ar[2, 39] = 'в';
			ar[1, 40] = 'f'; ar[2, 40] = 'а';
			ar[1, 41] = 'g'; ar[2, 41] = 'п';
			ar[1, 42] = 'h'; ar[2, 42] = 'р';
			ar[1, 43] = 'j'; ar[2, 43] = 'о';
			ar[1, 44] = 'k'; ar[2, 44] = 'л';
			ar[1, 45] = 'l'; ar[2, 45] = 'д';
			ar[1, 46] = 'z'; ar[2, 46] = 'я';
			ar[1, 47] = 'x'; ar[2, 47] = 'ч';
			ar[1, 48] = 'c'; ar[2, 48] = 'с';
			ar[1, 49] = 'v'; ar[2, 49] = 'м';
			ar[1, 50] = 'b'; ar[2, 50] = 'и';
			ar[1, 51] = 'n'; ar[2, 51] = 'т';
			ar[1, 52] = 'm'; ar[2, 52] = 'ь';
			
			if (toEnglish) 
			{
			 n = 2;
			 m = 1;
			} else
			{
			 n = 1;
			 m = 2;
			}
						  
			for (int i = 1; i <= inputStr.Length; i++)
				for (int j = 1; j <= 52; j++) 				
					if (inputStr[i] == ar[n, j]) inputStr = inputStr.ReplaceCharInString(i, ar[m, j]);			     
			
			return inputStr;
		}
		  	  	
		/// <summary>
        /// Из Иванов Петр Васильевич, получается Иванов П.В. 
		/// Не протестировано.
        /// </summary>
        /// <param name="LastName">Фамилия</param>
        /// <param name="FirstName">Имя</param>
        /// <param name="SecondName">Отчество</param>
        /// <returns>Возвращает Иванов П.В.</returns>
	  	public static string PersonShortName(string LastName, string FirstName,string SecondName)
		{		      
			string result = FirstCharUpper(LastName);		    
		  	string letter = FirstName.Substring(1, 1);
		  	if (letter != "")
		  	{
		  		result = result + " " + letter.ToUpper() + ".";		         
		    	letter = SecondName.Substring(1, 1);
		    	if (letter != "")
		      		result = result + letter.ToUpper() + ".";
		  	}
		  	return result;
		}
         
		/// <summary>
		/// Функция удаляет все ненужные символы(например пробелы) из строки
        /// и следующую после удаленного символа переводит в верхний регистр
        /// Получается преобразование из наименования в сокращение.	
		/// </summary>
		/// <param name="inputStr">Входная строка</param>
		/// <returns>Сокращеное наименования для модели данных</returns>
        public static string NameToBrief(this string inputStr)
		{			  
			char symb;
			bool ndUpper;					 
			string tmpstr = "";
			ndUpper = true;
			for (int i = 0; i < inputStr.Length; i++)
			{
				symb = inputStr[i];
				if ((('0' <= symb) && ('9' >= symb)) ||
					(('A' <= symb) && ('Z' >= symb)) ||
					(('a' <= symb) && ('z' >= symb)) ||
					(('А' <= symb) && ('я' >= symb)))
				{
					if (ndUpper) symb = System.Char.ToUpper(symb);
					tmpstr = tmpstr + symb;
					ndUpper = false;
				}
		    	else ndUpper = true;
			}			
			return tmpstr;	  
		}

        /// <summary>
        /// Проверка КПП по регулярному выражению
        /// </summary>
        /// <param name="kpp">Значение КПП например </param>
        /// <returns>true - если проходит проверку, false - если не проходит проверку</returns>
        public static bool CheckKPP(string kpp)		  		
		{		
			//Regex regex = new Regex("^([0-9]{4})([A-Z]{2}|[0-9]{2})([0-9]{3})$");		
			//Match match = regex.Match(kpp);
			//return (match.Success);
            return new Regex(@"\d{4}[\dA-Z][\dA-Z]\d{3}").IsMatch(kpp);
        }

        /// <summary>
        /// Функция вычисляет контрольное число ИНН
        /// Возвращает True если ИНН
        /// введен правильно или False в противном случае
        /// В качестве параметра передается проверяемый ИНН
        /// Для справки: структура ИНН
        ///              10-ти разрядный ИНН - NNNNXXXXXC
        ///              12-ти разрядный ИНН - NNNNXXXXXXCC
        ///              где: NNNN - номер налоговой инспекции
        ///                   XXXXX, XXXXXX - порядковый номер налогоплательщика (номер записи в госреестре)
        ///                   C - контрольное число в 10-ти разрядном ИНН
        ///                   CC - контрольное число в 12-ти разрядном ИНН
        ///                        (фактически, идущие подряд две контрольные цифры)
        /// </summary>
        /// <param name="iNNstring">ИНН для проверки</param>
        /// <returns>true - если проходит проверку, false - если не проходит проверку</returns>
        public static bool CheckINN(string iNNstring)
        {
        /* //Второй вариант реализации проверки ИНН.
        public static bool CheckINN2(string iNNstring)
        {
            byte[] factor1 = new byte[9] { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            byte[] factor2 = new byte[10] { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            byte[] factor3 = new byte[11] { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            bool Result = false;
            int sum;
            int sum2;
            try
            {
                if (iNNstring.Length == 10)
                {
                    sum = 0;
                    for (int i = 0; i <= 8; i++)
                        sum = sum + iNNstring[i + 1].ToInt() * factor1[i];
                    sum = sum % 11;
                    sum = sum % 10;
                    Result = (iNNstring[10].ToInt() == sum);
                }
                else if (iNNstring.Length == 12)
                {
                    sum = 0;
                    for (int i = 0; i <= 9; i++)
                        sum = sum + iNNstring[i + 1].ToInt() * factor2[i];
                    sum = sum % 11;
                    sum = sum % 10;
                    sum2 = 0;
                    for (int i = 0; i <= 10; i++)
                        sum2 = sum2 + iNNstring[i + 1].ToInt() * factor3[i];
                    sum2 = sum2 % 11;
                    sum2 = sum2 % 10;
                    Result = (iNNstring[11].ToInt() == sum) && (iNNstring[12].ToInt() == sum2);
                    return Result;
                }
            }
            catch
            {
                return false;
            }
            return Result;
        }*/                        
            
            // является ли вообще числом
            try { Int64.Parse(iNNstring); } catch { return false; }

            // проверка на 10 и 12 цифр
            if (iNNstring.Length != 10 && iNNstring.Length != 12) { return false; }

            // проверка по контрольным цифрам
            if (iNNstring.Length == 10) // для юридического лица
            {
                int dgt10 = 0;
                try
                {
                    dgt10 = (((2 * Int32.Parse(iNNstring.Substring(0, 1))
                        + 4 * Int32.Parse(iNNstring.Substring(1, 1))
                        + 10 * Int32.Parse(iNNstring.Substring(2, 1))
                        + 3 * Int32.Parse(iNNstring.Substring(3, 1))
                        + 5 * Int32.Parse(iNNstring.Substring(4, 1))
                        + 9 * Int32.Parse(iNNstring.Substring(5, 1))
                        + 4 * Int32.Parse(iNNstring.Substring(6, 1))
                        + 6 * Int32.Parse(iNNstring.Substring(7, 1))
                        + 8 * Int32.Parse(iNNstring.Substring(8, 1))) % 11) % 10);
                }
                catch { return false; }

                if (Int32.Parse(iNNstring.Substring(9, 1)) == dgt10) { return true; }
                else { return false; }
            }
            else // для физического лица
            {
                int dgt11 = 0, dgt12 = 0;
                try
                {
                    dgt11 = (((
                        7 * Int32.Parse(iNNstring.Substring(0, 1))
                        + 2 * Int32.Parse(iNNstring.Substring(1, 1))
                        + 4 * Int32.Parse(iNNstring.Substring(2, 1))
                        + 10 * Int32.Parse(iNNstring.Substring(3, 1))
                        + 3 * Int32.Parse(iNNstring.Substring(4, 1))
                        + 5 * Int32.Parse(iNNstring.Substring(5, 1))
                        + 9 * Int32.Parse(iNNstring.Substring(6, 1))
                        + 4 * Int32.Parse(iNNstring.Substring(7, 1))
                        + 6 * Int32.Parse(iNNstring.Substring(8, 1))
                        + 8 * Int32.Parse(iNNstring.Substring(9, 1))) % 11) % 10);
                    dgt12 = (((
                        3 * Int32.Parse(iNNstring.Substring(0, 1))
                        + 7 * Int32.Parse(iNNstring.Substring(1, 1))
                        + 2 * Int32.Parse(iNNstring.Substring(2, 1))
                        + 4 * Int32.Parse(iNNstring.Substring(3, 1))
                        + 10 * Int32.Parse(iNNstring.Substring(4, 1))
                        + 3 * Int32.Parse(iNNstring.Substring(5, 1))
                        + 5 * Int32.Parse(iNNstring.Substring(6, 1))
                        + 9 * Int32.Parse(iNNstring.Substring(7, 1))
                        + 4 * Int32.Parse(iNNstring.Substring(8, 1))
                        + 6 * Int32.Parse(iNNstring.Substring(9, 1))
                        + 8 * Int32.Parse(iNNstring.Substring(10, 1))) % 11) % 10);
                }
                catch { return false; }
                if (Int32.Parse(iNNstring.Substring(10, 1)) == dgt11
                    && Int32.Parse(iNNstring.Substring(11, 1)) == dgt12) { return true; }
                else { return false; }
            }
        }

        /// <summary>
        /// Проверка ОГРН по контрольной цифре
        /// </summary>
        /// <param name="oGRNstring">ОГРН для проверки</param>
        /// <returns>true - если проходит проверку, false - если не проходит проверку</returns>
        public static bool CheckOGRN(string oGRNstring)
        {
            // является ли вообще числом
            long number = 0;
            try { number = Int64.Parse(oGRNstring); }
            catch { return false; }

            // проверка на 13 и 15 цифр
            if (oGRNstring.Length != 13 && oGRNstring.Length != 15) { return false; }

            // проверка по контрольным цифрам
            if (oGRNstring.Length == 13) // для юридического лица
            {
                // остаток от деления
                int num12 = (int)Math.Floor(((double)number / 10) % 11);
                int dgt13 = -1;
                // если остаток равен 10, то берём 0, если нет, то берём его самого
                if (num12 == 10) { dgt13 = 0; } else { dgt13 = num12; }
                // ну и теперь сравниваем с контрольной цифрой
                if (Int32.Parse(oGRNstring.Substring(12, 1)) == dgt13) { return true; }
                else { return false; }
            }
            else // для индивидуального предпринимателя
            {
                // остаток от деления
                int num14 = (int)Math.Floor(((double)number / 10) % 13);
                int dgt15 = num14 % 10;
                // ну и теперь сравниваем с контрольной цифрой
                if (Int32.Parse(oGRNstring.Substring(14, 1)) == dgt15) { return true; }
                else { return false; }
            }
        }

		/// <summary>
		/// Функция возвращает iNum-е слово из строки aString,
        /// или пустую строку, если такого слова нет.      
		/// </summary>
		/// <param name="inputStr">Строка, в котрой искать слово</param>
		/// <param name="iNum">Порядковый номер слова</param>
		/// <returns>Найденное слово</returns>
        public static string ChooseWord(string inputStr, int iNum)
		{		   
			int iPos;			   
			string sTemp = inputStr.Trim();
			for (int i = 1; i <= (iNum - 1); i++)
			{		   
				iPos = sTemp.IndexOf(' ');
				if (iPos == 0) iPos = sTemp.Length;			   
				sTemp = sTemp.Right(sTemp.Length - iPos).Trim(); 
			}
			iPos = sTemp.IndexOf(' ');
			if (iPos == 0) iPos = sTemp.Length;			
			return sTemp.Left(iPos).Trim();
		}				
				  	
		/// <summary>
		/// Удаление последних символов, если оно равены сomma
		/// Пример использвания: s = DeleteLastComma('456456..', '.');
		/// Результат: 456456
		/// </summary>
		/// <param name="inputStr">Входная стркоа</param>
		/// <param name="comma">Символ-разделитель, например точка с запятой</param>
		/// <returns>Строка после удаления символов в конце</returns>
		public static string DeleteLastComma(string inputStr, string comma)	   
		{
			int len = inputStr.Length;
			string s = inputStr.Right(1);
			while (s == comma) 
			{
				inputStr = inputStr.Substring(1, len - 1); 
				len = inputStr.Length;
				s = inputStr.Right(1);
			}
			return inputStr;
		}

        /// <summary>
        /// Замена в запросе LIMIT на TOP.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Возвращает строку, в которой слово LIMIT заменено на TOP</returns>
        public static string ConverLimitToMSSQL(string sql)
        {
            if (sql.IndexOf("LIMIT", StringComparison.OrdinalIgnoreCase) == -1) return sql;
            if (sql.IndexOf("SELECT", StringComparison.OrdinalIgnoreCase) != 0) return sql;
            string limit = sql.StrAfterStr("LIMIT");           
            sql = sql.StrBeforeStr("LIMIT");
            string limitDigit = limit.StrBeforeStr(";");           
            sql = sql.Insert(6, " TOP " + limitDigit);           
            return sql;               
        }
		
        /// <summary>
        /// Добавление в запрос LIMIT или TOP.
        /// </summary>
        /// <param name="sql">Запрос SQL</param>
        /// <param name="limitRows">Количество строк</param>
        /// <returns>Возвращает строку, в которой слово LIMIT заменено на TOP</returns>
        public static string QueryAddLimit(string sql, int limitRows)
        {
        	if (Var.con.serverType == ServerType.MSSQL)
        	{
        		if (sql.IndexOf(" TOP ", StringComparison.OrdinalIgnoreCase) > 0) return sql;
        		sql = sql.ReplaceIgnoreCase("SELECT", "SELECT " + limitRows.ToString(), 1);        		
        	}  else 
        	if ((Var.con.serverType == ServerType.SQLite) || (Var.con.serverType == ServerType.Postgre))
        	{
        		if (sql.IndexOf("LIMIT", StringComparison.OrdinalIgnoreCase) > 0) return sql;
        		sql = sql + "LIMIT " + limitRows.ToString();
        	}        	            
            return sql;         
        }

		#region Запрос на ввод текста, числа, атрибута...
	            
        /// <summary>
        /// Запрос ввода одной строки. 
        /// Пример вызова: 
        /// string str = "";
        /// if (!sys.Inputvalue("CapForm", "CapText", "TEXT", ref str)) return;
        /// </summary>
        /// <param name="capForm">Заголовок формы</param>
        /// <param name="capText">Подпись над текстом</param>
        /// <param name="sizetext">Размер текстового поля: Small или Large</param>
        /// <param name="valueType">Integer или String</param>
        /// <param name="valueText">Отображаемый текст</param>
        /// <returns>Если значение введено, то true</returns>
        public static bool InputValue(string capForm, string capText, SizeMode sizetext, ValueType valueType, ref string valueText)
        {                              
        	        	
        	var arrvp = new ValueParam[1];
        	arrvp[0].isComboBox = false;
		    arrvp[0].value = valueText; 		  
		    arrvp[0].captionValue = capText; 
		    arrvp[0].defaultTextGray = "ttyuyui";
		    arrvp[0].defaultTextGrayColor = Color.LightGray;
		    arrvp[0].height = 200;
		    arrvp[0].valueType = valueType;
		    arrvp[0].wordwrap = false;  
		    arrvp[0].scrolls = System.Windows.Forms.ScrollBars.Both;		                               
        	var frm = new FormValue(capForm, arrvp);
            if (frm.ShowDialog() != DialogResult.OK) return false;
            valueText = frm.GetValue(0);
            return true;
        }
           
        /// <summary>
        /// Упрощённый запрос ввода двух строк.  
        /// string NameText  = ""; 
        /// string valueText = "";                   
        /// if (!sys.Inputvalue2("ВВедите текст", "Название:", "Текст:", ref NameText, ref valueText)) return false;
        /// </summary>
        /// <param name="capForm"></param>
        /// <param name="capText1">Подпись над текстом 1</param>
        /// <param name="capText2">Подпись над текстом 2</param>
        /// <param name="valueText1">Тип текста 1: Integer или String</param>
        /// <param name="valueText2">Тип текста 2: Integer или String</param>
        /// <returns>Если значение введено, то true</returns>
        public static bool InputValue2(string capForm, 
                                       string capText1,
                                       string capText2, 
                                       ref string valueText1,
                                       ref string valueText2)
        {                       
            var arrvp = new ValueParam[2];                     
        	arrvp[0].isComboBox = false;	
			arrvp[0].wordwrap   = false;  
            arrvp[0].CopyTo(arrvp[1]);			
            arrvp[0].captionValue = capText1;	    		  		   	
			arrvp[1].scrolls    = System.Windows.Forms.ScrollBars.Both;	   
		    arrvp[1].height     = 200;	
		    arrvp[1].captionValue = capText2;	
        	var frm = new FormValue(capForm, arrvp);
            if (frm.ShowDialog() != DialogResult.OK) return false;
            valueText1 = frm.GetValue(0);
            valueText2 = frm.GetValue(1);
            return true;                      
        }
                            
        /// <summary>
        /// Получить выбранное значение из списка.
        /// Пример вызова: 
        /// const string SQL = "SELECT ID, Name FROM fbaUser ORDER BY Name";
        /// string[,] values;
        /// if (!sys.Inputvalues(SQL, out values)) return false;  
        /// </summary>
        /// <param name="sql">Код запроса получения списка даных</param>
        /// <param name="multiSelect">Возможность множественного выбора строк</param>
        /// <param name="mdi">Если true, то форма выбора значений будет в режиме MDI</param>
        /// <param name="values">Выбранные строки</param>
        /// <returns>Если что-то выбрано, то true</returns>
        public static bool InputValues(string sql, bool multiSelect, bool mdi, out string[,] values)
        {           
            values = null;
            var fList = new FormValueList(sql, multiSelect);
            if (mdi) fList.MdiParent = Var.FormMainObj;
            if (fList.ShowDialog() != DialogResult.OK) return false;  
            values = fList.SelectedValue;
            if (values.GetLength(0) == 0) return false;
            return true;                     
        }
                       
        /// <summary>
        /// Запрос ввода строки. Пример вызова: string str = ""; if (!sys.InputAttr("List",  ref str)) return;
        /// </summary>
        /// <param name="entityID">ИД сущности</param>
        /// <param name="attrBrief">Сокращение атрибута</param>
        /// <returns>Если что-то введено, то true</returns>
        public static bool InputAttr(string entityID, out string attrBrief)
        {
            attrBrief = "";
            var frm = new FormGetAttr(entityID);
            if (frm.ShowDialog() != DialogResult.OK) return false;
            attrBrief = frm.AttrBrief;
            return true;
        }         
                             
        /// <summary>
        /// Запрос ввода строки. 
        /// Пример вызова: 
        /// string entityID    = "";
        /// string entityBrief = "";
        /// string entityName  = "";
        /// if (!sys.InputEntity(false, false, "Договор страхования", out entityID, out EntityBrief, out EntityName)) return;          
        /// <param name="selectInOneClick"></param>		
        /// <param name="entityID"></param>		
        /// <param name="entityBrief"></param>		
        /// <param name="entityName"></param>		
		/// </summary>		
        /// <returns></returns>
        public static bool InputEntity(bool selectInOneClick,
                                       ref string entityID,
                                       ref string entityBrief, 
                                       ref string entityName)
        {             
            var frm = new FormGetEntity( selectInOneClick, entityID, entityBrief, entityName);
            if (frm.ShowDialog() != DialogResult.OK) return false;
            if (String.IsNullOrEmpty(frm.EntityID)) return false;
            if (String.IsNullOrEmpty(frm.EntityBrief)) return false;
            if (String.IsNullOrEmpty(frm.EntityName)) return false;            
            entityID    = frm.EntityID;
            entityBrief = frm.EntityBrief;
            entityName  = frm.EntityName;
            return true;
        }            
          
        /// <summary>
        /// Метод, чтобы можно было писать вместо string.IsNullOrEmpty так: if (MyString1.IsNullOrEmpty()) ...
        /// Полный аналог  string.IsNullOrEmpty(value).
        /// <param name="value">Входная строка</param>		
		/// </summary>		
        /// <returns>true, если строка null или ""</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }       
               
        /// <summary>
        /// При вводе списка значений добавляются кавычки и запятые.
        /// Это нужно для ввода на компонетах TextBox, ComboBox.
        /// <param name="value">Входная строка</param>		
		/// </summary>		
        /// <returns>Строка с кавычками и запятыми</returns>
        public static string TransformValue(this string value)
        {
            if (value == null) return "";
            string[] values = value.Split('\n');
            for (int i = 0; i < values.Count(); i++)
            {                
                if (i < (values.Count() - 1))
                     values[i] = "'" + values[i].Trim() + "',";
                else values[i] = "'" + values[i].Trim() + "'";                 
            }
            return string.Join(Var.CR, values); 
        }
              
        /// <summary>
        /// Получение типа. Вспомогательная функция. Из названия типа убирает строки "FBA." и "System.Windows.Forms."
        /// <param name="typeStr"></param>
		/// <param name="fullTruncate">Если true, то убираем и "FBA"</param>  
		/// </summary>		
        /// <returns>Строка, после исключения значений</returns>
        public static string TruncateType(string typeStr, bool fullTruncate = true)
        {
            typeStr = typeStr.Replace("FBA.", "");
            if (fullTruncate) typeStr = typeStr.Replace("FBA", "");
            typeStr = typeStr.Replace("System.Windows.Forms.", "");
            return typeStr;
        }
           
        /// <summary>
        /// Ввод списка значений в компоненты TextBox, ComboBox, TextBoxFBA, ComboBoxFBA.
        /// Поднимается форма, в котрую нужно ввести значения
        /// </summary>
        /// <param name="tb">Компонент, куда вводим значения</param>        
        /// <returns>Нет</returns>
        public static void InputListValues(Object tb)
        {
            string compType = tb.GetType().ToString();
            compType = sys.TruncateType(compType, false);
            string valueText = "";
           if (compType == "TextBox")
            {
                 valueText = ((System.Windows.Forms.TextBox)tb).Text; //((System.Windows.Forms.TextBox)tb).Text.Replace("'", "").Replace(", ", "");
                 if (!sys.InputValue("List of values", "Input values:", SizeMode.Large, ValueType.String, ref valueText)) return;           
                 ((System.Windows.Forms.TextBox)tb).Text = valueText; //sys.Transformvalue(valueText);
            }
            if (compType == "ComboBox")
            {
                valueText = ((System.Windows.Forms.ComboBox)tb).Text; //.Replace("'", "").Replace(", ", "");
                if (!sys.InputValue("List of values", "Input values:", SizeMode.Large, ValueType.String, ref valueText)) return;           
                ((System.Windows.Forms.ComboBox)tb).Text = valueText; //sys.Transformvalue(valueText);
            }
            if (compType == "TextBoxFBA")
            {
                if (((FBA.TextBoxFBA)tb).Text2.IsNullOrEmpty()) valueText = ((FBA.TextBoxFBA)tb).Text;
                else  valueText = ((FBA.TextBoxFBA)tb).Text2;
                //valueText = ((FBA.TextBoxFBA)tb).Text2; //((FBA.TextBoxFBA)tb).Text.Replace("'", "").Replace(", ", "");               
                if (!sys.InputValue("List of values", "Input values:", SizeMode.Large, ValueType.String, ref valueText)) return;           
                ((FBA.TextBoxFBA)tb).Text2 = valueText;
                ((FBA.TextBoxFBA)tb).Text  = valueText.SubStringEnd(0, 100);//sys.Transformvalue(valueText);
            }
            if (compType == "ComboBoxFBA")
            {
                if (((FBA.ComboBoxFBA)tb).Text2.IsNullOrEmpty()) valueText = ((FBA.ComboBoxFBA)tb).Text;
                else  valueText = ((FBA.ComboBoxFBA)tb).Text2;
                //valueText = ((FBA.ComboBoxFBA)tb).Text2; //((FBA.ComboBoxFBA)tb).Text.Replace("'", "").Replace(", ", "");               
                if (!sys.InputValue("List of values", "Input values:", SizeMode.Large, ValueType.String, ref valueText)) return;           
                ((FBA.ComboBoxFBA)tb).Text2 = valueText;
                ((FBA.ComboBoxFBA)tb).Text  = valueText.SubStringEnd(0, 100);//sys.Transformvalue(valueText);     
            }
            if (compType == "FastColoredTextBoxFBA")
            {
                valueText = ((FBA.FastColoredTextBoxFBA)tb).Text; //.Replace("'", "").Replace(", ", "");
                if (!sys.InputValue("List of values", "Input values:", SizeMode.Large, ValueType.String, ref valueText)) return;           
                
                //((FBA.FastColoredTextBoxFBA)tb).Text2 = sys.Transformvalue(valueText);
                ((FBA.FastColoredTextBoxFBA)tb).Text = valueText; //sys.Transformvalue(valueText);;
            }     
        }
                
        /// <summary>
        /// Преобразовать двумерный массив в Dictionary.  
        /// </summary>
        /// <param name="arr">Входящий двумерный массив</param>        
        /// <returns>Объект Dictionary</returns>
        public static Dictionary<string, string> DictionaryFill(string[,] arr)
        {
            var dic = new Dictionary<string, string>(); 
            for (int i = 0; i < arr.GetLength(0); i++)
                dic.Add(arr[i,0], arr[i, 1]);                          
            return dic;
        }

        #endregion Запрос на ввод текста, числа, атрибута... 

        /// <summary>
        /// Получение текста блока секции. 
        /// Метод возвращает текст между текстом  --(SectionBegin какая_то_секция) и --(SectionEnd какая_то_секция)
        /// Начало секции --(SectionBegin какая_то_секция)
        /// Конец секции --(SectionEnd какая_то_секция)
        /// Возвращает секцию. Если не найдено, то возвращает пустую строку. Ошибок не выдает.
        /// </summary>
        /// <param name="inputStr">Входная строка, в котром нужно найти блок текста</param>
        /// <param name="section">Название секции, в данном случае какая_то_секция</param>
        /// <returns>Текст секции</returns>
        public static string GetSection(string inputStr, string section)
        {          
          string beginStr = "--(SectionBegin " + section + ")";
          string endStr   = "--(SectionEnd "   + section + ")";
          return StrBetweenStr(inputStr, beginStr, endStr);
        }
       
        /// <summary>
        /// Получение текста блока секции. 
        /// Метод возвращает текст между текстом  --(SectionBegin какая_то_секция) и --(SectionEnd какая_то_секция)
        /// В отличие от метода  GetSection(string inputStr, string section), здесь входной параметр - это массив строк.
		/// Результат такой-же.        
        /// Начало секции --(SectionBegin какая_то_секция)
        /// Конец секции --(SectionEnd какая_то_секция)
        /// Возвращает секцию. Если не найдено, то возвращает пустую строку. Ошибок не выдает.
        /// </summary>
        /// <param name="inputStr">Входная строка, в котром нужно найти блок текста</param>
        /// <param name="section">Название секции, в данном случае какая_то_секция</param>
        /// <returns>Текст секции</returns>
        public static string GetSection(string[] inputStr, string section)
        {          
          string beginStr = "--(SectionBegin " + section.Trim() + ")";
          string endStr   = "--(SectionEnd "   + section.Trim() + ")";
          beginStr = beginStr.ToUpper();
          endStr   = endStr.ToUpper();
          int iBeg = 0, iEnd = inputStr.Length - 1;
          for (int i = 0; i < inputStr.Length; i++) 
          {
              if (inputStr[i].Trim().ToUpper() == beginStr) iBeg = i;
              if (inputStr[i].Trim().ToUpper() == endStr)   iEnd = i;
          }
          if ((iBeg > -1) && (iBeg < iEnd))
          {
              var outputStr = new string[iEnd - iBeg + 1];
              int Index = 0;
              for (int i = iBeg; i <= iEnd; i++)
              {
                  outputStr[Index] = inputStr[i];
                  Index++;
              }
              return string.Join(Var.CR, outputStr);                 
          }
          return "";
        }
                
        ///<summary>
        /// Вычисление размера текста. Шрифт (по умолчанию Arial 11), определен в sys.Common.            
        /// </summary>
        /// <param name="inputStr">Входная строка</param>
        /// <param name="fnt">Шрифт</param>
        /// <returns>Длина текста в вшрифте fnt</returns>
        public static Size GetTextLength(this string inputStr, Font fnt)
        {
            var lb1 = new Label();
            var gR = lb1.CreateGraphics();                              
            TextFormatFlags flags = TextFormatFlags.NoPadding;
            var proposedSize = new Size(int.MaxValue, int.MaxValue);
            Size size = TextRenderer.MeasureText(gR, inputStr, fnt, proposedSize, flags);
            lb1.Dispose();
            return size;                     
        }
        
        ///<summary>
        /// Проверка выражения Expression соответствия регулярному выражению Reg.               
        /// </summary>
        /// <param name="reg">Регулярное выражение</param>
        /// <param name="expression">Проверяемое выражение</param>
        /// <returns>true - соответствует, false - не соответствует</returns>
        public static bool CheckRegEx(string reg, string expression)
        {
            var regex = new Regex(reg);
            Match match = regex.Match(expression);
            return match.Success;    
        }                                     
               
        ///<summary>
        /// Показать список файлов в решении и количество строк кода в каждом файле и общее кол-во строк кода.
        /// </summary>
        /// <param name="folderSolution">Полный пусть к папке с решением</param>      
        /// <returns>Вызывает ShowMessage c результатом</returns>
        public static void ShowSolutionStringCodeCount(string folderSolution)
        {
            int fileCount = 0;
            int stringCount = 0;
            var fileList = new StringBuilder();
            sys.GetSolutionFilesInfo(folderSolution, ref fileCount, ref stringCount, ref fileList);
            sys.SM("Количество файлов: " + fileCount + Var.CR + 
                   "Строк кода всего: " + stringCount  + Var.CR + Var.CR +
                   fileList.ToString(), MessageType.Information);
        
        }
              
        ///<summary>
        /// Получение информации о папке  файлами *.cs
        /// </summary>
        /// <param name="folderSolution">Полный пусть к папке с решением</param>  
		/// <param name="fileCount">Возвращает количество файлов в решении</param>  
		/// <param name="stringCount">Возвращает количество строк кода в решении</param>  
		/// <param name="fileList">Возвращает список файлов</param>  
        /// <returns>Сам метод значений не возвращает</returns>        
        public static void GetSolutionFilesInfo(string folderSolution, 
                                        ref int fileCount, 
                                        ref int stringCount,
                                        ref StringBuilder fileList)
        {
            var di = new DirectoryInfo(folderSolution);
            FileInfo[] fi = di.GetFiles("*.*");
            //FileInfo[] fi = di.GetFiles("*.cs");
            int tmp;
            foreach (FileInfo fiTemp in fi)
            {                           
                if ((!fiTemp.Extension.Contains("cs")) &&
                    (!fiTemp.Extension.Contains("txt"))) continue;
                if (fiTemp.Name.Contains(".Designer.")) continue;
                if (fiTemp.Name.Contains("AssemblyInfo")) continue;
                if (fiTemp.Name.Contains(".csproj")) continue;
                if (fiTemp.Name.Contains("Rubbish")) continue;
                if (fiTemp.Name.Contains("TemporaryGeneratedFile")) continue;
                if (fiTemp.Name.Contains("WsCall.")) continue;                                
                fileCount++;
                //tmp = GetStringCount(FolderPath + @"\" + fiTemp.Name);
                tmp = GetStringCount(fiTemp.DirectoryName + @"\" + fiTemp.Name);
                
                stringCount += tmp;
                fileList.Append(fiTemp.DirectoryName + @"\" + fiTemp.Name + " Строк кода: " + Convert.ToString(tmp) + "\r\n");
            }             
            string[] dirs = Directory.GetDirectories(folderSolution);
            if(dirs!=null && dirs.Length>0)
            {
                foreach (string dir in dirs) 
                    GetSolutionFilesInfo(dir, ref fileCount, ref stringCount, ref fileList);                
            }             
        }
        
        ///<summary>
        /// Получение количества строк в текстовом файле
        /// </summary>
        /// <param name="filePath">Полный пусть к файлу</param>  
        /// <returns>Возвращает количество строк в файле</returns> 
        private static int GetStringCount(string filePath)
        {
            if(filePath == String.Empty) return 0;
            int stringCount = 0;
            try
            {
                using (StreamReader sr = new StreamReader(filePath)) 
                {
                    while (sr.ReadLine() != null)  
                    {
                        stringCount++;
                    }
                }
            }
            catch
            {
                return 0;
            }
            return stringCount;
        }
                           
		/// <summary>
        /// Строка команды SUBSTRING, в зависимости от типа сервера. Возвращает например SUBSTRING или SUBSTR.
        /// </summary>
        /// <param name="serverType">Тип сервера</param>	     
        /// <returns>Возвращает одно из значений SUBSTRING или SUBSTR в зависимости от типа сервера</returns>         
        public static string GetSubString(ServerType serverType = ServerType.Auto)
        {
        	if (serverType == ServerType.Auto)
        	{
              if  (Var.con != null) serverType = Var.con.serverTypeRemote;
        	  else serverType = ServerType.Postgre; 
        	}
        	string dTStr = "";
            if (serverType == ServerType.Postgre) dTStr = @"SUBSTRING"; //по умолчанию как Postgre.        	
        	if (serverType == ServerType.MSSQL)    dTStr = @"SUBSTRING";        
        	if (serverType == ServerType.SQLite)   dTStr = @"SUBSTR";
        	return dTStr;        
        }
                
        /// <summary>
        /// Получить строку ISNULL в зависимости от типа сервера
        /// </summary>
        /// <param name="serverType">Тип сервера</param>	     
        /// <returns>Возвращает одно из значений ISNULL или COALESCE или IFNULL в зависимости от типа сервера</returns>        
        public static string GetISNULL(ServerType serverType = ServerType.Auto)
        {        
			if (serverType == ServerType.Auto)
        	{
              if  (Var.con != null) serverType = Var.con.serverTypeRemote;
        	  else serverType = ServerType.Postgre; 
        	}			
        	if (Var.con.serverTypeRemote == ServerType.MSSQL)      return "ISNULL";    //MSSQL
            if (Var.con.serverTypeRemote == ServerType.Postgre)   return "COALESCE";  //Postgre
            if (Var.con.serverTypeRemote == ServerType.SQLite)     return "IFNULL";    //SQLITE
            return "IFNULL";
        }
            
		/// <summary>
        /// Для разработки. Каждую строку текста обрамить кавычками.
        /// </summary>
        /// <param name="inputStr">Входная строка</param>	
		/// <param name="AddCR">Добавлять или нет в конце Var.CR. true - добавлять.</param>	           
        /// <returns>Каждая строка обрамляется кавычками</returns>    
        public static string TextTransform(string inputStr, bool AddCR = false)
        {        	
        	string[] arrstr  = inputStr.Split('\n');
        	var arrstr2 = new string[arrstr.Length];        	
        	int maxLen = 0;
        	for (int i = 0; i < arrstr.Length; i++) 
        	{
        		if (arrstr[i].Length > maxLen) maxLen = arrstr[i].TrimEnd().Length;
        	} 	
        	for (int i = 0; i < arrstr.Length; i++) 
        	{
        		int charCountAdd = maxLen - arrstr[i].Length;
        		arrstr2[i] = "\"" +  arrstr[i] + StringOfChar(" ", charCountAdd) + "\"";
        		if (AddCR) arrstr2[i] = arrstr2[i] + " + Var.CR";
        		if (i == (arrstr.Length - 1))
        		{
        			arrstr2[i] = arrstr2[i]  + ";";
        		} else
        		{
        			arrstr2[i] = arrstr2[i]  + " + ";
        		}
        	} 
        	return string.Join(Var.CR, arrstr2);
        }                        
	}	
}
