
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 24.11.2017
 * Время: 10:02
 */
 
using System;

using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Linq;   
using System.IO;
using System.Reflection;
using ContentAlignment = DevAge.Drawing.ContentAlignment;
using DataTable = System.Data.DataTable;
using TextBox = System.Windows.Forms.TextBox;

/*using SourceGrid;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using Microsoft.Office.Interop.Excel; //Для экспорта в Excel
using System.Runtime.InteropServices; //Для экспорта в Excel
using System.Data;      
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Json;
using SourceGrid.Selection;
using System.Threading.Tasks;
using SourceGrid.Cells.Controllers;
*/

//Здесь собраны классы различного назначения.
namespace FBA
{      
	#region Region. Глобальные переменные. 
            	    
	/// <summary>
	/// Статический класс. Переменные для всего решения, в том числе и для прикладного кода.
	/// </summary>
	public static class Var
	{
        /// <summary>
        /// Имя системы с помощью которой вошли. ClientApp, ServerApp, Unility
        /// </summary>
        public static string SystemName = ""; //Path.GetFileNameWithoutExtension(Path.GetFileName(System.Windows.Forms.Application.ExecutablePath));
        
        /// <summary>
        /// /Показывать сообщения sys.SM.
        /// </summary>
        public static bool ShowMes = true;    
        
        /// <summary>
        /// Версия сборки sys. пределяется как Assembly.GetExecutingAssembly().GetName().Version.ToString()
        /// </summary>
        public static readonly string ApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
        
        /// <summary>
        /// Параметры, переданные в EXE файл при запуске.
        /// </summary>
        public static readonly string[] Args = Environment.GetCommandLineArgs();    
        
        /// <summary>
        /// Соединение для локальной SQLite.  
        /// </summary>
        public static Connection conLite;           
        
        /// <summary>
        /// Соединение для запросов к пользовательским данным. Это основное соединение.		             
        /// </summary>
        public static Connection con;               
        
        /// <summary>
        /// ИД текущего пользователя. Данные с которыми был выполнен вход.   
        /// </summary>
        public static string UserID    = "0";       
        
        /// <summary>
        /// Логин текущего пользователя. Данные с которыми был выполнен вход. 
        /// </summary>
        public static string UserLogin = "";        
        
        /// <summary>
        /// Имя текущего пользователя. Данные с которыми был выполнен вход.
        /// </summary>
        public static string UserName  = "";        

		/// <summary>
        /// Пароль текущего пользователя. Данные с которыми был выполнен вход.  
        /// </summary>        
        public static string UserPass  = "";        
        
        /// <summary>
        /// ИД роли пользователя. Множественные роли пользователя не поддерживаются.
        /// </summary>
        public static string RoleID    = "0";       
        
        /// <summary>
        /// Сокращение роли пользователя. Данные с которыми был выполнен вход.  
        /// </summary>
        public static string RoleBrief = "";        
        
        /// <summary>
        /// /Признак того что пользователь является администратором.
        /// </summary>
        public static bool UserIsAdmin = false;     
        
        /// <summary>
        /// Тестовый режим (Test, рабочий режим работы Work, разработка Dev. Выбор: тестовые модули кода или рабочие. 
        /// Если разработка, то запуск без проверки версии модулей.
        /// </summary>
        public static EnterMode enterMode = EnterMode.Work; 
        
        /// <summary>
        /// Перенос строки \r\n;
        /// </summary>
        public const string CR         = "\r\n";    
        
        /// <summary>
        /// Табуляция \t 
        /// </summary>
        public const string TAB        = "\t";                 

		/// <summary>
		/// ComputerName = Environment.MachineName;
		/// </summary>
        public static readonly string ComputerName = Environment.MachineName;
        
        /// <summary>
        /// ComputerUserName = SystemInformation.UserName
        /// </summary>
        public static readonly string ComputerUserName = SystemInformation.UserName;
        
        /// <summary>
        /// LocalHost = System.Net.Dns.GetHostName(); 
        /// </summary>
        public static readonly string LocalHost = System.Net.Dns.GetHostName(); 
        
        /// <summary>
        /// LocalIP = GetLocalIPv4(System.Net.Dns.GetHostName())
        /// </summary>
        public static string LocalIP = sys.GetLocalIPv4(LocalHost); //System.Net.Dns.GetHostEntry(LocalHost).AddressList[0].ToString();
        
        /// <summary>
        /// Порт для обмена сообщениями по умолчанию при посылке запросов от клиента серверу По умолчанию ServerAppPortDefault = 7145.
        /// </summary>
        public static int ServerAppPortDefault = 7145; 
        
        /// <summary>
        /// Порт для обмена сообщениями по умолчанию при посылке от удаленного сервера App этому клиенту. По умолчанию LocalServerPort = 7145.           
        /// </summary>
        public static int LocalServerPort      = 7101; 
        
        /// <summary>
        /// Количество потоков по 4 на каждый процессор. MaxThreadsCount = Environment.ProcessorCount * 4
        /// </summary>
        public static readonly int MaxThreadsCount = Environment.ProcessorCount * 4; //Количество потоков по 4 на каждый процессор.
        
        /// <summary>
        /// Минимальное Количество потоков. MinThreadsCount = 2    
        /// </summary>
        public static readonly int MinThreadsCount = 2; 
         		
        /// <summary>
        /// Название проекста, котрый стартует.   
        /// </summary>        
        public static string ProjectMainName = "";
        
        /// <summary>
        /// Ссылка на первую форму-контейнер MDI. 
        /// </summary>
        public static FormFBA FormMainObj = null;
        
        /// <summary>
        /// Время когда запущен клиент.
        /// </summary>
        public static readonly DateTime DateTimeStart = DateTime.Now;  

		/// <summary>
        /// Настройка времени выполнения запросов. Максимальное время. Если превышает, то ошибка.
        /// </summary>        
        public static int QueryTimeout = 5 * 60 * 1000; //5 минут. максимальное время ожидания запроса.
        
        /// <summary>
        /// Шрифт первый, общесистемный
        /// </summary>
        public static System.Drawing.Font font1 = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        
        /// <summary>
        /// Шрифт второй, общесистемный
        /// </summary>
        public static System.Drawing.Font font2 = new System.Drawing.Font("Courier New", 14.25F);
        
        /// <summary>
        /// Шрифт заголовков таблицы.
        /// </summary>
        public static System.Drawing.Font FontTableHeader = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
        //public static Icon ico1 = global::FBA.Resource.DMS2;
        
        /// <summary>
        /// По умолчанию первая дата.
        /// </summary>
        public static DateTime MinStateDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        
        /// <summary>
        /// По умолчанию дата для SQL запросов.
        /// </summary>
        public static string MinStateDateSQL = "1900-01-01 00:00:00.000";
        
        /// <summary>
        /// Количество строк для отображения в таблицах по умолчанию. В настрйоках гибких таблиц перекрывается.
        /// </summary>
        public static string DefaultRowCount = "0";
        
        /// <summary>
        /// Текстовая переменная в которой через ; перечислены все поднятые в настоящий момент формы поиска.
        /// </summary>
        public static string FormSearchParam = ""; 
        
        //Переменная для запрета запуска нескольких копий формы поиска.
        //Переменная для запрета запуска нескольких копий формы поиска.
        //Цвета в таблице (чередующиеся)
        /*public static Color ColorTableOdd1 = Color.FromArgb(238, 237, 240);
        public static Color ColorTableOdd2 = Color.White;

        //Цвет бордюра.
        public static Color ColorTableBorder = Color.FromArgb(4, 33, 51);

        //Цвет шапки таблицы.
        public static Color ColorTableHeaderBack = Color.FromArgb(175, 224, 244); 
        public static Color ColorTableHeaderFont = Color.FromArgb(0, 33, 76);

        //View для шапки таблицы.
        public static SourceGrid.Cells.Views.ColumnHeader viewHeader  = new SourceGrid.Cells.Views.ColumnHeader();

        //View для строк таблицы.
        public static CellBackColorAlternate viewRows          = new CellBackColorAlternate(ColorTableOdd1, ColorTableOdd2);

        //Задний фон шапки таблицы.      
        public static DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();

        //Бордюр таблицы.
        public static DevAge.Drawing.BorderLine      border      = new DevAge.Drawing.BorderLine(ColorTableBorder);
        public static DevAge.Drawing.RectangleBorder cellBorder  = new DevAge.Drawing.RectangleBorder(border, border);
        */
     
        /// <summary>
        /// Определяем, что мы в режиме конструктора.
        /// </summary>
        public static bool IsDesignMode = (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime);
        
        /// <summary>
        /// Список форм. Проблема в том, что если форма скрывается (Hide, Visible = False), 
        /// то её потом нельзя найти в списке Application.OpenForms.
        /// Поэтому приходится вести учет открытых форм самостоятельно.
        /// </summary>
        public static Dictionary<string, FormFBA> ListForm = new Dictionary<string, FormFBA>();

        //public enum FormTypeList {Main, DLL, Report};
        //public static Form    FormParentMDI           = null;

        //Это данные с которыми был выполнен вход
        //private static string EnterUserLogin = "";
        //private static string EnterUserPass  = "";
        
        /// <summary>
        /// Переменная SystemSysLocal, говорит о том что все системные таблицы
        /// (те, которые нужны для работы сервера приложений, такие как fbaUser, Role, Form, и др.)
        /// находятся в базе SQLite сервера приложений, а не в БД, в которой храняться все пользовательские данные.
        /// Для доступа к системным таблицам всегда нужно использовать соединение Var.conSys.   
        /// </summary>
        public static bool SystemSysLocal = false;
        	        
        /// <summary>
        /// Прямоуголник рабочей области основного экрана приложения
        /// </summary>
        public static Rectangle scrteenWorkingArea = Screen.PrimaryScreen.WorkingArea; 
		
        /// <summary>
        /// Ширина рабочей области основного экрана приложения
        /// </summary>
        public static int scrteenWorkingWidth = scrteenWorkingArea.Width;
        
        /// <summary>
        /// Высота рабочей области основного экрана приложения
        /// </summary>
		public static int scrteenWorkingHeight = scrteenWorkingArea.Height; 
		
	}
	
	
    /// <summary>
    /// Статический класс. Необходим для описания глобальных переменных по работе с ошибками.        
    /// </summary>
    public static class Error
    {                                
        /// <summary>
        /// Дата-время когда была послана последняя ошибка на сервер. Если просто более 1 мин. то можно посылать заново. Иначе слишком много ошибок можно нечаянно послать.            
        /// </summary>
        public static DateTime LastDateTimeSendError = DateTime.Now;
        
        /// <summary>
        /// Сохранять в принципе ошибку на сервере или нет. Включаем только в момент соединения с удаленным сервером.
        /// </summary>
        public static bool SaveError      = false;  
        
        /// <summary>
        /// Сохранять скриншот ошибки на сервере или нет.
        /// </summary>
        public static bool SaveScreenshot = true;   
        
        /// <summary>
        /// Степень сжатия скриншота ошибки. 1 - самое низкое, 100 - самое высокое.
        /// </summary>
        public static int  CompressRatio   = 3;  

		/// <summary>
        /// /Количество отправленных ошибок на сервер с момента старта программы.
        /// </summary>		
        public static int  ErrorsSentCount = 0;     
        
        /// <summary>
        /// /Количество возникших в программе ошибок с момента старта программы. 
        /// </summary>
        public static int  ErrorsCount     = 0;     
                  
        /// <summary>
        /// Количество секунд между ошибками, которые нужно посылать на сервер. Потому что если посылать все ошибки подряд - это будет много, если они например возникают в цикле.
        /// </summary>
        public static int  SecBetweenSendError = 0;
        
        /// <summary>
        /// Послать ошибку на сервер.
        /// </summary>
        /// <param name="errorMes">Текст ошибки</param>
        /// <param name="additionalInfo">Дополнительная информация</param>
        public static bool SendErrorToServer(string errorMes, string additionalInfo)
        {
            //Выходим, если делать ничего не нужно.
            if (!SaveError) return false;

            //Это для того чтобы если во время работы этого кода возникнет ошибка, не было зацикливания.        
            SaveError = false;
   
            try
            {               
                //Если чтение параметра неудачное, то ничего не делаем.
                var Params = new string[10];

                //Получаем только при первой ошибке.
                if (ErrorsCount == 0)
                {                    
                    if (Param.Load(DirectionQuery.Remote, Var.UserID, "SaveError", true, "User", out Params))
                    {
                        if (!Params[0].Replace("SaveError=", "").ToBool()) return false;
                        SaveScreenshot      = Params[1].Replace("SaveScreenshot=", "").ToBool();
                        CompressRatio       = Params[2].Replace("CompressRatio=", "").ToInt();
                        SecBetweenSendError = Params[3].Replace("SecBetweenSendError=", "").ToInt();
                    }
                }

                //sys.Error.SaveError true/false: Сохранять ошибку на сервере или нет. Пример: SaveError=true
                //sys.Error.SaveScreenshot true/false: Сохранять текст ошибки на сервере или нет. Пример: SaveScreenshot=true
                //sys.Error.CompressRatio int:  находится значение степени сжатия скриншота. По умолчанию формат JPEG, степень сжатия 90. Пример: CompressRatio=90        
                //sys.Error.SecBetweenSendError int: - количество секунд между ошибками.
                //sys.Error.LastDateTimeSendError datetime: Время последней ошибки.

                if (sys.GetSecDiff(LastDateTimeSendError, DateTime.Now) < SecBetweenSendError)
                {
                    SaveError = true;
                    return false;
                }

                string imagebase64      = "";
                string screenshoFormat  = "";
                string screenshotWidth  = "";
                string screenshotHeight = "";
                string screenshotSize   = "";

                if (SaveScreenshot)
                {                 
                    //Получение скриншота
                    screenshoFormat = "WEBP";
                    screenshotWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
                    screenshotHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
                    Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Graphics graphics = Graphics.FromImage(printscreen as Image);
                    graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);                          
                    byte[] webpImageData;           
                    WebP.EncodeLossly(printscreen, CompressRatio, out webpImageData);
                    imagebase64 = Convert.ToBase64String(webpImageData);
                    screenshotSize = FBAFile.GetFileSizeStr(webpImageData.Length, true, false);
                }
                additionalInfo = sys.AddRightCR(additionalInfo);
                additionalInfo += GetSystemInfo();
                string sql = "INSERT INTO fbaError (EntityID, UserID, ErrorTime, ErrorText, ScreenshotFormat, ScreenshotWidth, ScreenshotHeight, ScreenshotSize, " +
                             "CompressRatio, AdditionalInfo, ScreenshotData) VALUES (" + Var.CR +
                             "123, " + Var.UserID + "," + sys.DateTimeCurrent() + ",'" + errorMes + "','" + screenshoFormat + "','" + screenshotWidth + "','" + screenshotHeight + "'," + screenshotSize + ",'" + Error.CompressRatio.ToString() + "','" + additionalInfo + "','" + imagebase64 + "')";

                sys.Exec(DirectionQuery.Remote, sql);
                LastDateTimeSendError = DateTime.Now;
            }
            catch
            {
                //Ошибку не выдаем.
            }

            SaveError = true; 
            return true;
        }
        
        /// <summary>
        /// Информация о системе
        /// </summary>
        /// <returns>Список строк с информацией о систеиме.</returns>
        public static string GetSystemInfo()
        {
            StringBuilder systemInfo = new StringBuilder();
            systemInfo.AppendLine("Операционная система (номер версии): " + Environment.OSVersion);
            systemInfo.AppendLine("Разрядность процессора: " + Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
            systemInfo.AppendLine("Модель процессора: " + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
            systemInfo.AppendLine("Путь к системному каталогу: " + Environment.SystemDirectory);
            systemInfo.AppendLine("Число процессоров: " + Environment.ProcessorCount);
            systemInfo.AppendLine("Имя пользователя: " + Environment.UserName);
            
            //Локальные диски
            /*Console.WriteLine("Локальные диски: ");
            foreach (DriveInfo dI in DriveInfo.GetDrives())
            {
                systemInfo.AppendLine(
                      "Диск: " + dI.Name + ", " + "Формат: " + dI.DriveFormat.ToString() +
                      "Размер, ГБ: " + ((double)dI.TotalSize / 1024 / 1024 / 1024).ToString() +
                      "Доступно, ГБ: " + ((double)dI.AvailableFreeSpace / 1024 / 1024 / 1024).ToString());
            }*/

            //Информация о системе с использованием WMI.     
            /*ManagementClass manageClass = new ManagementClass("Win32_OperatingSystem");
            //Получаем все экземпляры класса
            ManagementObjectCollection manageObjects = manageClass.GetInstances();
            //Получаем набор свойств класса
            PropertyDataCollection properties = manageClass.Properties;
            foreach (ManagementObject obj in manageObjects)
            {
                foreach (PropertyData property in properties)
                {
                    try
                    {
                        var val = obj.Properties[property.Name].Value;
                        if (val != null)
                            systemInfo.AppendLine(property.Name + ": " + obj.Properties[property.Name].Value.ToString());
                    }
                    catch { }
                }
                systemInfo.AppendLine();
            }*/
            return systemInfo.ToString();
        }
    }

    #endregion Region. Глобальные переменные. 
    
    /// <summary>
	/// Статический класс. Все служебные папки всей системы. 
	/// </summary>
	public static class FBAPath
	{	
        /// <summary>
        /// Папка для файлов платформы
        /// </summary>
        public static readonly string PathMain = System.Windows.Forms.Application.StartupPath + "\\";   
        
        /// <summary>
        /// Path.GetDirectoryName(Path.GetDirectoryName(PathMain))
        /// </summary>
        public static readonly string PathRoot = Path.GetDirectoryName(Path.GetDirectoryName(PathMain)); 
        
        /// <summary>
        /// Папка для прикладных форм. PathApp = PathRoot + @"\App\"
        /// </summary>
        public static readonly string PathApp = PathRoot + @"\App\";  //Папка для прикладных форм.
        
        /// <summary>
        /// PathAdditional = PathRoot + @"\Additional\"
        /// </summary>
        public static readonly string PathAdditional = PathRoot + @"\Additional\";
        
        /// <summary>
        /// PathLog = PathRoot + @"\Log\"
        /// </summary>
        public static readonly string PathLog = PathRoot + @"\Log\";
                
        /// <summary>
        /// PathTemp = PathRoot + @"\Temp\"
        /// </summary>
        public static readonly string PathTemp = PathRoot + @"\Temp\";
        
        /// <summary>
        /// PathUpdate = PathRoot + @"\Update\"
        /// </summary>
        public static readonly string PathUpdate = PathRoot + @"\Update\";
        
        /// <summary>
        /// PathRollback = PathRoot + @"\Rollback\"
        /// </summary>
        public static readonly string PathRollback = PathRoot + @"\Rollback\";
        
        /// <summary>
        /// PathSettings = PathRoot + @"\Settings\"
        /// </summary>
        public static readonly string PathSettings = PathRoot + @"\Settings\";
        
        /// <summary>
        /// PathSQL = PathRoot + @"\SQL\"
        /// </summary>
        public static readonly string PathSQL = PathRoot + @"\SQL\";
        
        /// <summary>
        /// PathForms = PathRoot + @"\Forms\"
        /// </summary>
        public static readonly string PathForms = PathRoot + @"\Forms\";
        
        /// <summary>
        ///  PathDevelop = @"..\..\..\..\"
        /// </summary>
        public static readonly string PathDevelop = @"..\..\..\..\";
        
        /// <summary>
        /// PathTemplate = PathRoot + @"\Template\"
        /// </summary>
        public static readonly string PathTemplate = PathRoot + @"\Template\";
        
        /// <summary>
        /// Папка проекта Debug. PathDebug = @"..\..\"; 
        /// </summary>
        public static readonly string PathDebug = @"..\..\"; 
        
        /// <summary>
        /// Файл справки. PathHelp = PathRoot + @"\Help\chm\"
        /// </summary>
		public static readonly string FileHelp = PathRoot + @"\Help\chm\FBA.chm"; 
		
		/// <summary>
        /// Файл описаний классов платформы.
        /// </summary>
		public static readonly string FileDocumentation = PathRoot + @"\Help\html\index.html"; 
		
		/// <summary>
        /// Проверка наличия путей. При запуске клиента.
        /// </summary>
        /// <returns></returns>
        public static bool CheckPath()
        {        	       
        	if (!FBAFile.DirExists(FBAPath.PathApp, true)) return false;               
        	if (!FBAFile.DirExists(FBAPath.PathAdditional, true)) return false;                  
         	if (!FBAFile.DirExists(FBAPath.PathLog, true)) return false;                         
        	if (!FBAFile.DirExists(FBAPath.PathTemp, true)) return false;                  
         	if (!FBAFile.DirExists(FBAPath.PathUpdate, true)) return false;                  
         	if (!FBAFile.DirExists(FBAPath.PathRollback, true)) return false;                  
         	if (!FBAFile.DirExists(FBAPath.PathSettings, true)) return false;                  
         	if (!FBAFile.DirExists(FBAPath.PathSQL, true)) return false;                  
         	if (!FBAFile.DirExists(FBAPath.PathForms, true)) return false;                             
        	if (!FBAFile.DirExists(FBAPath.PathTemplate, true)) return false; 
        	return true;
        }
	}
	   
    /// <summary>
	/// Команды от клиента серверу приложений, список возможных команд:
	/// Все возможные типы сообщений между сервером и клиентом.
	/// Список кодов сообщений. CommandCode - Команда от клиента, список возможных команд:
	/// Команда начинающиеся на C - это команда клиента серверу.
	/// Команда начинающиеся на S - Команды от сервера приложений к клиенту.
	/// </summary>
	public enum CommandCode
	{	          
	    /// <summary>
	    /// Не определено
	    /// </summary>
		NotAssigned,
		
		/// <summary>
		/// Запись в темповую папку файла, присланного от клиента.  
		/// </summary>
        C101, 
        
        /// <summary>
        /// Добавить в список клиентов LocalIP, LocalHost, ComputerName, ComputerUserName и вернуть GUID для клиента и настройки подключения.
        /// 102. Запрос подключения. Добавить в список клиентов LocalIP, LocalHost, ComputerName, ComputerUserName и вернуть GUID для клиента и настройки подключения.
        /// </summary>
        C102, 
    
        /// <summary>
        /// Выполнить запрос SELECT и вернуть таблицу результата.
        /// </summary>
        C103, 
        
        /// <summary>
        /// Выполнить запрос EXEC и вернуть ID последней изменённой записи.
        /// </summary>
        C104, 
        
        /// <summary>
        /// Выполнить процедуру произвольного модуля и вернуть результат.
        /// </summary>
        C105, 
        
        /// <summary>
        /// Клиент извещает сервер приложений, о том что он закрывается.   
        /// </summary>
        C106, 
        
        /// <summary>
        /// Клиент запрашивает доступный порт для запуска локального сервера  HTTP.
        /// </summary>
        C107, 
                       
        /// <summary>
        /// Закрытие клиента. Без всяких вопросов. 201. Команда клиенту закрыться.  
        /// </summary>
	    S201, 
	    
	    /// <summary>
	    /// MessageType.Error Сообщение от администратора"	    
	    /// </summary>
		S202, 
		
		/// <summary>
		/// MessageType.Information Сообщение от администратора" Команда клиенту показать сообщение Information.   
		/// </summary>
        S203, 
        
        /// <summary>
        /// MessageType.Question Вопрос от администратора" пока не работает.
        /// </summary>
	    S204, 
	    
	    /// <summary>
	    /// Проверка гуида клиента. Верное ли значение на сервере приложений.
	    /// Команда клиенту вернуть гуид. Для проверки - верное ли значение на сервере приложений. (команда проверки существования клиента. Клиент должен ответить.
	    /// </summary>
	    S205, 
	    
        /// <summary>
	    /// Команда клиенту вернуть гуид. Для проверки - верное ли значение на сервере приложений. (команда проверки существования клиента. Клиент должен ответить.
	    /// </summary>	    
	    S209, 
	    
	    /// <summary>
	    /// Возвращаем только GUID соединения и тип СУБД.
	    /// </summary>
        S210           
	}		
	
	/// <summary>
	/// Все возможные типы ошибок.
	/// C - что это ошибка на клиенте. S - на сервере
	/// </summary>
	public enum ErrorCode
	{
		/// <summary>
		/// Ошибка запуска локального сервера HTTP
		/// </summary>
	    C115, 
	    
	    /// <summary>
	    /// Ошибка запуска локального сервера HTTP
	    /// </summary>
        C116, 
        
        /// <summary>
        /// Остановка локального сервера
        /// </summary>
        C117, 
        
        /// <summary>
        /// Ошибка при получении сообщения локальным сервером
        /// </summary>
        C118, 
        
        /// <summary>
        /// Ошибка локального сервера
        /// </summary>
        C119, 
        
        /// <summary>
        /// Ошибка. Сессия с сервером не найдена!
        /// </summary>
        S501, 
        
        /// <summary>
        /// Ошибка выполнения запроса       
        /// </summary>
        S502, 
        
        /// <summary>
        /// Ошибка авторизации
        /// </summary>
        S503, 
        
        /// <summary>
        /// Ошибка при выполнении кода на сервере
        /// </summary>
        S504, 
        
        /// <summary>
        /// Ошибка отправки сообщения клиенту
        /// </summary>
		S505, 
		
		/// <summary>
		/// Ошибка отправки сообщения клиенту  
		/// </summary>
		S506, 
		
		/// <summary>
		/// Ошибка проверки количества лицензий
		/// </summary>
		S507, 
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S508, 
		
		/// <summary>
		/// Ошибка преробразования даты
		/// </summary>
		S509, 
		
		/// <summary>
		/// Ошибка преробразования даты
		/// </summary>
		S510, 
		
		/// <summary>
		/// Ошибка преробразования даты		     
		/// </summary>
		S511, 
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S601, 
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S602, 
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S603,
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S604,
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S605,

		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>		
		S606,
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S607, 
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S608, 
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S609,
		
		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>
		S610,

		/// <summary>
		/// Ошибка проверки лицензии
		/// </summary>		
		S611 		
	}	
	
	/// <summary>
	/// Все возможные типы сообщений.
	/// </summary>
	public enum MessageType
	{
	    /// <summary>
	    /// Ошибка
	    /// </summary>
		Error,
		
		/// <summary>
		/// Системная ошибка. В этом случае к выводимому сообщению добавляется дополнительная информация.
		/// </summary>
	    SystemError,	
	    
	    /// <summary>
	    /// Ошибка и нужно ответить на вопрос
	    /// </summary>
	    ErrorQuestion,	   

		/// <summary>
	    /// Другой Значок, чем у сообщения Ошибка и системная ошибка
	    /// </summary>	    
	    Stop,
	    
	    /// <summary>
	    /// Выаод информации, не требует от пользователя принятия решения.
	    /// </summary>
	    Information,
	    
	    /// <summary>
	    /// Значок восклицательный знак
	    /// </summary>
	    Warning,
	    
	    /// <summary>
	    /// Вопрос пользователю
	    /// </summary>
	    Question
	} 			
	
    /// <summary>
    /// Все поддерживаемые сервера: NotAssigned, MSSQL, Postgre, SQLite, ServerApp, Auto
    /// </summary>
 	public enum ServerType
	{
	    /// <summary>
	    /// Не определено
	    /// </summary>
 		NotAssigned,
 		
 		/// <summary>
 		/// MS SQL Server
 		/// </summary>
		MSSQL,
		
		/// <summary>
		/// PostgreQL
		/// </summary>
	    Postgre,
	    
	    /// <summary>
	    /// SQLite
	    /// </summary>
	    SQLite,	  

		/// <summary>
	    /// Если  подключение производится к серверу приложений.
	    /// Притом, если подключение будет осуществляться напрямую, то сервер приложений сообщит тип используемого серовера клиенту.
	    /// </summary>	    
	    ServerApp,
	    
	    /// <summary>
	    /// Если Auto, то тип сервера брать с глобальной переменной sys.ServerType
	    /// </summary>
	    Auto
	}
	 	 
 	/// <summary>
 	/// Тип запроса к серверу приложений: NotAssigned, SELECT, EXEC
 	/// </summary>
 	public enum TypeQuery
	{ 		 	
 		/// <summary>
 		/// Сервер что-то возвращает
 		/// </summary>
 		SELECT,
 		
 		/// <summary>
 		/// Выполнение запроса без возвращаемого результата
 		/// </summary>
 		EXEC	
 	} 	 
 	
 	/// <summary>
 	/// Тип операции с объектом:
 	/// NotAssigned, Refresh, Add, AddChild, Edit, Del
 	/// </summary>
 	public enum Operation
	{
 		/// <summary>
 		/// Не определено
 		/// </summary>
 		NotAssigned,
 		
 		/// <summary>
 		/// Обновить таблицу
 		/// </summary>
 		Refresh,
 		
 		/// <summary>
 		/// Добавить новую запись
 		/// </summary>
 		Add,
 		
 		/// <summary>
 		/// Добавить новую вложенную запись
 		/// </summary>
 		AddChild,
 		
 		/// <summary>
 		/// Редактирвать
 		/// </summary>
 		Edit,
 		
 		/// <summary>
 		/// Удалить
 		/// </summary>
		Del			
 	}
 	 	 
 	/// <summary>
 	/// Тип операции в БД: NotAssigned, Auto, Update, Insert, Delete
 	/// </summary>
 	public enum SQLCommand
	{ 	 	
 		/// <summary>
 		/// Определять автоматически по наличию ИД объекта. Если ИД есть, то Update, иначе Insert. Delete вызывается отдельно и Auto не определяется.
 		/// </summary>
 		Auto,
 		
 		/// <summary>
 		/// Обновить. ИД объекта уже должен быть.
 		/// </summary>
 		Update,
 		
 		/// <summary>
 		/// Вставить новую запись. ИД объекта не должно быть.
 		/// </summary>
 		Insert,
 		
 		/// <summary>
 		/// Удалить. ИД объекта уже должен быть.
 		/// </summary>
 		Delete, 					
 	}
  
 	/// <summary>
 	/// Тип языка: MSQL, SQL
 	/// </summary>
 	public enum SQLLang
	{ 		
 		/// <summary>
 		/// Язык модели данных
 		/// </summary>
 		MSQL,
 		
 		/// <summary>
 		/// Чистый SQL к любому из серверов MSQL, Postgre, SQLite.
 		/// </summary>
 		SQL 		
 	} 	
 	 	
 	/// <summary>
 	/// Тип поиска: NotAssigned, Exact, Contains, Begin, End 
 	/// </summary>
 	public enum SearchParam
	{		
 		/// <summary>
 		/// Точное совпадение
 		/// </summary>
 		Exact,
 		
 		/// <summary>
 		/// Подстрока содержится в строке с любого места
 		/// </summary>
        Contains,
        
        /// <summary>
        /// Стрка начинается со подстроки
        /// </summary>
        Begin,
        
        /// <summary>
        /// Стрка заканчивается на подстроку
        /// </summary>
        End 		
 	}
 	  
 	/// <summary>
 	/// Способ вызова метода созданиия формы: NotAssigned, None, Show, ShowDialog
 	/// </summary>
	public enum FormAction
	{ 	 	   	  
 	   /// <summary>
 	   /// Формау не показывать
 	   /// </summary>
	   None,
	   
	   /// <summary>
	   /// Показать не немодальную.
	   /// </summary>
       Show,
       
       /// <summary>
       /// Показать не модальную.
       /// </summary>
       ShowDialog
	}
 	
 	/// <summary>
 	/// Направить запрос к локальной БД или удалённой: NotAssigned, Remote, Local
 	/// </summary>
	public enum DirectionQuery
	{ 	 	  
	   /// <summary>
	   /// Запрос к удалённой БД
	   /// </summary>
	   Remote,
	   
	   /// <summary>
	   /// Запрос к локальной БД
	   /// </summary>
       Local
    }	
	
	/// <summary>
	/// Время, после или до. Чтобы определить время до или после события.
	/// Используется в методах сущности: Before, After
	/// </summary>
 	public enum TimeAction
	{
 		/// <summary>
 		/// До
 		/// </summary>
 		Before,
 		
 		/// <summary>
 		/// После
 		/// </summary>
 		After 			
 	}
 	 	 	
 	/// <summary>
 	/// Тип входа в систему: Work, Test, Develop
 	/// </summary>
	public enum EnterMode
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

	/// <summary>
 	/// Размер. Всего два значения: Small, Large. Используется в FormValue1
 	/// </summary>
	public enum SizeMode
	{
	    /// <summary>
	    /// Маленький 
	    /// </summary>
		Small,
		
		/// <summary>
	    /// Большой
	    /// </summary>
	    Large	    	
	} 
	
	/// <summary>
	/// Тип значения: Integer, String. Используется для FormValue1.
	/// </summary>
	public enum ValueType
	{
		/// <summary>
		/// Integer
		/// </summary>
		Integer,
		
		/// <summary>
		/// String
		/// </summary>
		String 		
	}
	
	/// <summary>
	/// Тип проекта: NotAssigned, Main, App, Dll 
	/// </summary>
	public enum ProjectType
	{
		/// <summary>
		/// Значение не определено
		/// </summary>
		NotAssigned,
		
		/// <summary>
		/// Главная форма запуска прикладной подсистемы
		/// </summary>
		Main,
		
		/// <summary>
		/// Проект приложения с формами
		/// </summary>
		App,
		
		/// <summary>
		/// Только DLL. Визуальных форм нет.
		/// </summary>
		Dll			
	}
	
}
