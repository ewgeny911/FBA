using System.IO;
using System.Diagnostics;
using System.Data;
using System;
using System.Linq;
using NPOI.HSSF.Util;
using Microsoft.Office.Interop.Excel;
using NPOI.SS.Formula;
using NPOI.SS.Formula.Functions;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using DataTable = System.Data.DataTable;
using IFont = NPOI.SS.UserModel.IFont;
using System.Threading;
//using Microsoft.Office.Interop.Word;

namespace FBA
{    
	// Ещё не реализовано:
    // ПАРАМЕТРЫ ФОРМАТИРОВАНИЯ ТАБЛИЦЫ В ЦЕЛОМ(параметр FormatTable при вызове PutTable):
    // AutoFirstBold:  Выделение жирным строк в таблице, начиная с самой первой,
    //                 до той в которой встретится цифра в любой колонке на месте первого символа.
    //                 Данная опция подойдет для большинства отчетов. Только 1 или 0. Например: {AutoFirstBold: 1;}
    // FirstRowsBold:  Выделить жирным первые строки. Одно число означает строк. Например  {FirstRowsBold: 2;}
    // LastRowsBold:   Выделить жирным последние строки. Одно число означает кол-во строк. Например {LastRowsBold: 1;}
    // FirstColsBold:  Выделить жирным первые столбцы. Одно число означает столбцов. Например {FirstColsBold: 1;}
    // LastColsBold:   Выделить жирным последние столбцы. Одно число означает столбцов. Например {LastColsBold: 2;}
    // AllRowsBold:    Выделить жирным всю таблицу.  Например: {AllRowsBold: 1;}
    // ColBoldTextContain: Выделить колонку жирным шрифтом, если в какой либо ячейке таблицы в этой колонке есть указанный текст. Кавычки не нужны.
    //                 Жирным шрифтом выделяется вся колонка, включая заголовок. Регистр символов значения не имеет. Например {ColBoldTextContain: Итого;}
    // RowBoldTextContain: Выделить строку жирным шрифтом, если в какой либо ячейке таблицы в этой строке есть указанный текст. Кавычки не нужны.
    //                 Жирным шрифтом выделяется вся строка. Регистр символов значения не имеет. Например {RowBoldTextContain: Итого;}
    // CapBold:        Выделить жирным шрифтом шапку таблицы. Например: {CapBold: 1;}
    // LastRowsBackColor: Выделить цветом последние строки таблицы, например: {LastRowsBackColor: 1, -603923969;}
    
    //26-Светло-бежевый.
	//cell.SetCellValue(indexcolor.ToString());
    //SetSampleStyle(cell, indexcolor);
    //if (indexcolor > 32766) indexcolor = 0;
    //indexcolor++;
                 
	
	/// <summary>
	/// Класс для печати отчетов Excel. А вот класса по печати в Word пока нет ещё, не сделан.
	/// </summary>
    /// <remarks>   
    /// Из текста, который указан в ячейке DataTable получаем формат.
    /// Пример в ячейке в DataTable есть такой текст: Петров А.С.{fontbold;fontcolor: 9;fontsize: 18}
    /// В отчете в ячейке напечатается только Петров А.С., а все что в фигурных скобках не напечатается,
    /// это информация для форматирования. Она перед выводом отчета будет удалена. Но формат ячеки будет изменён, согласно этой информации.
    /// Пробелы и регистр символов в самих параметрах не важны, например {Merge:1,0} и {Merge: 1, 0} и {MeRgE: 1,0} равнозначны.  
    /// Пример1:  Текст В Ячейке Таблицы{Merge: 1,0;ColWidth: 50;RowHeight: 100;}
    /// Пример2: Текст В Ячейке Таблицы{FontBold: 1; FontItalic: 1; FontUnderline: 2; StrikeThrough: 1; FontSize: 18}
    /// Пример3: Текст В Ячейке Таблицы{Merge: 1, 0; ColWidth: 50; RowHeight: 100; FontColor: 11; CellBold: 1}
    /// 
    /// Параметры форматирования отдельной ячейки в таблице:
    /// (Вставляется вместе с текстом в ячейку DataTable или параметр TableCaption при вызове PutTable):
    /// Значения параметров: 1 - означает включить, 0 - выключить.
    /// FontName:       Имя шрифта. Здесь один текстовый параметр - имя шрифта без кавычек. Например {fontname: Arial}
    /// FontSize:       Размер шрифта. Одно число.  Например {fontsize: 18}
    /// FontColor:      Цвет шрифта. Только 1 или 0.  Например {fontcolor: 9}
    /// FontBold:       Жирный шрифт. Только 1 или 0.  Например {fontbold: 1}
    /// FontItalic:     Наклонный шрифт. Только 1 или 0.  Например {fontitalic: 1}
    /// Strikethrough:  Зачеркнутый шрифт. Только 1 или 0.  Например {strikethrough: 1}
    /// FontUnderline:  Подчеркнутый шрифт. Только 1 или 0.  Например {fontunderline: 1}
    /// Для BorderLine одно из значений: Dashed, Dotted, Double, Hair, Medium, DashDot, MediumDashDot, MediumDashDotDot, MediumDashed, SlantedDashDot, Thick, Thin
    /// BorderLineBottom:   {BorderLineBottom: Thin;}
    /// BorderLineLeft:     {BHorizontalAligmentorderLineBottom: Thick}
    /// BorderLineRight:    {BorderLineBottom: Double}
    /// BorderLineTop:      {BorderLineBottom: Medium}
    /// VerticalAligment одно из значений: Bottom, Center, Distributed, Justify, Top
    /// VerticalAligment:   {VerticalAligment: Top}
    /// HorizontalAligment одно из значений: Center, CenterSelection, Left, Right, Distributed, Fill, General, Justify
    /// HorizontalAligment: {HorizontalAligment: Center}
    /// Для BorderColor число в формате short. Пример 24, 26, 298.
    /// BorderColorBottom: Например {BorderColorBottom: 24}
    /// BorderColorLeft:   Например {BorderColorLeft: 26}
    /// BorderColorRight:  Например {BorderColorRight: 298}
    /// BorderColorTop:    Например {BorderColorTop: 5}
    /// WrapText:          Перенос по словам 0 или 1, Например. {WrapText: 1}
    /// ShrinkToFit:       Уменьшение размера шрифта, чтобы весь текст уместился в ячейке {ShrinkToFit: 1}
    /// FillBackgroundColor:  Не работает. {FillBackgroundColor: 100}
    /// FillForegroundColor: Цвет фона ячейки. {FillForegroundColor: 26}
    /// Formula: Вставить формулу в ячейку. Пример {Formula: 1}
    /// Merge: Объединение ячеек.  {Merge: 1,4}
    ///       Здесь два параметра - координаты нижней правой ячейки до которой нужно объединить.
    ///       Можно указывать числа заведомо превышающие кол-во строк или столбцов в таблице,
    ///       в этом случае объединение будет выполнено до самомго последнего столбца или строки.
    ///       Например {Merge: 1000000, 1000000;} объединие всех ячеек от текущей до самой правой нижней.
    ///       В параметре Merge сначала указывается на сколько столбцов объединить вправо, затем
    ///       на сколько строк вниз от текущей. т.е. {Merge: Col, Row;}, где Col - столбец, Row - строка.
    ///       {Merge: 1, 0;} - объединение текущей ячейки с одной ячейкой, находящейся справа.
    ///       {Merge: 0, 1;} - объединение текущей ячейки с одной ячейкой, находящейся под ней.
    /// ColWidth:  Ширина колонки. Например {ColWidth: 1}
    /// RowHeight:  Высота строки. Например {RowHeight: 1}
    /// BorderCell:  Рамка вокруг ячейки. Это проще чем писать границе для всех сторон Right, Bottom, Left, Top. Например {BorderCell: Thin}
    /// Пример печати отчета:
    /// DataTable DT;
    /// sys.SelectDT(DirectionQuery.Remote, "SELECT TOP 50 FaceID, Name FROM FacePerson", out DT);
    /// SysReportXLSX rep = new SysReportXLSX("ОтчетПоДоговорам", "", "", DT.Rows.Count + 1);   
    /// rep.PutTextAtBookmark("Bookmark_TextPosition",   "Специалист", "", "Вывод должности");
    /// rep.PutTableAtBookmark("Bookmark_Table1", DT, "ID|Фамилия", true, "", true, "Застрахованные");                        
    /// rep.SaveBook("", true); 
	/// </remarks>
    public class SysReportXLSX
    {
        /// <summary>
        /// Сокращение отчета. 
        /// </summary>
    	public string ReportBrief; 
    	
    	/// <summary>
    	/// Расширение шаблона. 
    	/// </summary>
        public string Format;   
		
        /// <summary>
        /// Тип отчета.
        /// </summary>
        public string ReportType;  
        
        /// <summary>
        /// ИД отчета.
        /// </summary>
        public string ReportID;    
        
        /// <summary>
        /// Наименование отчета.
        /// </summary>
        public string ReportName;  
              
        /// <summary>
        /// Имя файла шаблона отчета, без полного пути.
        /// </summary>
        public string ReportTemplateFileName; 
        
        /// <summary>
        /// Имя файла шаблона c полным путём.
        /// </summary>
        public string ReportTemplateFullFileName; 

        /// <summary>
        /// Имя файла XLS на выходе с полным путём.
        /// </summary>
        public string ReportOutputFullFileNameXLS; 

        /// <summary>
        /// Имя файла PDF на выходе с полным путём.
        /// </summary>
        public string ReportOutputFullFileNamePDF; 
        
        //Далее параметры отчета Excel        
        //Отчет XLS (или XLSX).
        
        /// <summary>
        /// Книга.
        /// </summary>
        public NPOI.XSSF.UserModel.XSSFWorkbook book = null; //
        
        /// <summary>
        /// Текущий лист.
        /// </summary>
        public NPOI.SS.UserModel.ISheet sheet = null; 

        /// <summary>
        /// Имя листа отчета Excel, куда печатаем.    
        /// </summary>
        public string CurrentSheetName; 
        
        private ICellStyle CellStyleCaption = null; //Стиль ячейки для заголовка по умолчанию.
        private ICellStyle CellStyleBody    = null; //Стиль ячейки для тела таблицы по умолчанию.
        private ICellStyle CellStyleBodyOdd = null; //Стиль ячейки для тела таблицы по c другим фоном, чтобы фон строк отличался через одну.
        private ICellStyle CellStyleUser    = null; //Стиль ячейки определенный в ячейке через строку.

        //private ICellStyle[] dd = new ICellStyle[100];
        
        private IFont fontCaption;
        private IFont fontBody;
        private IFont fontBodyOdd;

        private string CurrentBookmark = ""; //Для того чтобы вывести сообщение об ошибке.

        
        /// <summary>
        ///Массив для закладок в шаблоне Excel. 
        /// Сюда будет записываться все данные шаблона.  
        /// </summary>
        public string[,] Bookmarks = new string[10000, 5];
        private const int eNum    = 0;    //Порядковый номер.
        private const int eSheet  = 1;    //Имя листа.
        private const int eValue  = 2;    //Текст ячейки.
        private const int eRow    = 3;    //Номер строки.
        private const int eColumn = 4;    //Номер колонки.
        
        /// <summary>
        /// Количество заполненных строк в массиве.
        /// </summary>
        public int BookmarkCount  = 0;   
        
        /// <summary>
        /// Показывать или нет сообщения об ошибках.
        /// </summary>
        public bool ShowError     = true; 
        
        /// <summary>
        ///  Цвет текста через строку.
        ///  По умолчанию 220 - Светло-серый. 
        /// </summary>
        public short ForegroundColorOdd     = 220;   
        
        /// <summary>
        ///  Цвет текста шапки.
        ///  По умолчанию 298 - Светло-зелёный.. 
        /// </summary>
        public short ForegroundColorCaption = 298;   
        
        /// <summary>
        /// Цвет текста. По умолчанию 1 = Белый
        /// </summary>
        public short ForegroundColor        = 1;     
        
        /// <summary>
        /// Высота строки заголовка таблицы. По умолчанию 500.
        /// </summary>
        public short CaptionHeight          = 500;   
        
        /// <summary>
        /// Выводить строки таблицы разными цветами через одну. По умолчанию true.
        /// </summary>
        public bool FormatTableOdd          = true;  
        
        /// <summary>
        /// Количество ошибок.
        /// </summary>
        public int errorCount               = 0;     
        
        /// <summary>
        /// Тестовый режим. Замедляет вывод.
        /// </summary>
        public bool Test                    = false; 
        
        /// <summary>
        /// Форма прогресс бара.
        /// </summary>
        public FormProgress Progress        = null;  
                     
        /// <summary>
        /// Конструктор. Можно указывать либо Brief отчета, либо его ID.
        /// </summary>
        /// <param name="reportBrief">Сокращение отчета</param>
        /// <param name="progressFormCaption">Текста заголовка формы прогресс-бара при выводе отчета</param>
        /// <param name="progressLabelCaption">Текст в окне прогресс-бара</param>
        /// <param name="stepCount">Количество шагов прогресс-бара</param>
        public SysReportXLSX(string reportBrief, string progressFormCaption, string progressLabelCaption, int stepCount)
        {
        	if (!SearchReport(reportBrief)) return;
            if (sys.IsEmpty(progressFormCaption)) progressFormCaption = "Печать отчета";
            if (!sys.IsEmpty(ReportName)) progressLabelCaption = ReportName;
             Progress = new FormProgress(progressFormCaption, progressLabelCaption, stepCount); //4 - это количество выводов текста.
        }
            
        /// <summary>
        /// Поиск ID отчета, наименования отчета и имени файла шаблона по сокращению шаблона, или по его ID.  
        /// </summary>
        /// <param name="reportBrief">Сокращение отчета</param>
        /// <returns>Если отчет найден, то true</returns>
        private bool SearchReport(string reportBrief)
        {
            //Общая процедура для Excel и Word отчетов.
            this.ReportBrief = reportBrief;            
            if (sys.IsEmpty(reportBrief) && sys.IsEmpty(ReportID))
            {
                errorCount++;
                if (ShowError) sys.SM("Не указано сокращение отчета");               
                return false;
            }

   
        	// Файла шаблона в виде Base64.   
        	string ReportTemplateData;
                
            string sql = "SELECT ID, Brief, FileData, FileName, Name, Format, ReportType FROM fbaReport WHERE Brief = '" + reportBrief + "'";           
            sys.GetValue(DirectionQuery.Remote, sql,
                out this.ReportID,
                out this.ReportBrief,
                out ReportTemplateData,
                out this.ReportTemplateFileName,
                out this.ReportName,
                out this.Format,
                out this.ReportType);

            if (ReportID == "")
            {
                errorCount++;
                if (ShowError) sys.SM("Отчет с сокращением " + reportBrief + " не найден!");
                return false;
            }

            if (ReportType != "Excel")
            {
                errorCount++;
                if (ShowError) sys.SM("Отчет не является отчетом Excel!");
                return false;
            }

            //Если имя шаблона есть, то записываем файл в темповую папку.
            if (!sys.IsEmpty(ReportTemplateFileName))
            {
                string errorMes;
                string reportFileNameTemp = FBAPath.PathTemp + ReportTemplateFileName;
                
                //Получить имя файла, которого ещё не существует.              
                if (!FBAFile.GetNewFileName(reportFileNameTemp, true, out ReportTemplateFullFileName)) return false;
                if (!FBAFile.FileWriteFromBase64(ReportTemplateData, ReportTemplateFullFileName, out errorMes, true))
                {
                    errorCount++;
                    if (ShowError) sys.SM("Ошибка сохранения файла шаблона на диск: " + ReportTemplateFullFileName);
                    return false;
                }
            }            
            return ReportPrepare();        
        }
              
        /// <summary>
        /// Подготовка отчета XLS.
        /// </summary>
        /// <returns>Если успешно, то true.</returns>
        public bool ReportPrepare()
        {    
            //Книги ещё нет, создаем.                         
            //Если есть шаблон отчета, то открываем файл
            if (!sys.IsEmpty(ReportTemplateFullFileName))
            {
                if (!File.Exists(ReportTemplateFullFileName))
                {
                    errorCount++;
                    if (ShowError) sys.SM("Не найден файл шаблона: " + ReportTemplateFullFileName);
                    return false;
                }
                try
                {
                    //ReportTemplateFullFileName = @"E:\Мусор\SaveFile.xlsx";
                    using (var file = new FileStream(ReportTemplateFullFileName, FileMode.Open, FileAccess.Read))
                    {

                        book = new XSSFWorkbook(file);
                        if (!ParseTemplate(out BookmarkCount)) return false;
                    }
                }
                catch (Exception ex)
                {
                    errorCount++;
                    if (ShowError) sys.SM("Ошибка открытия файла шаблона: " + ex.Message);
                    return false;
                }
            }
            else
            {
                //Иначе создаем пустую книгу.
                book = new NPOI.XSSF.UserModel.XSSFWorkbook();
            }

            //Проверка создания книги Excel.
            if (book == null)
            {
                errorCount++;
                if (ShowError) sys.SM("Ошибка создания книги Excel!");
                return false;
            }

            //По умолчанию первый лист. Далее пользователь может переопределить.
            SetCurrentSheet(0);

            return true;
        }                
              
        /// <summary>
        /// Создаем формат ячейки, согласно указанному в переменной FormatCell.
        /// </summary>
        /// <param name="cell">Ячейка. Тип NPOI.SS.UserModel.ICell.</param>
        /// <param name="formatCell">Формат ячейки. Описание формата в заголовке класса.</param>
        private void SetFormatCell(NPOI.SS.UserModel.ICell cell, string formatCell)
        {
            if (formatCell == "") return;

            //Если нужно установить стиль по умолчанию.
            //По умолчанию определены стили CellStyleCaption, CellStyleBody, CellStyleBodyOdd, CellStyleUser.
            if ((formatCell == "Caption") || (formatCell == "Body") || (formatCell == "User") || (formatCell == "BodyOdd"))
            {
                if (formatCell      == "Caption") cell.CellStyle = CellStyleCaption;
                else if (formatCell == "Body")    cell.CellStyle = CellStyleBody;                
                else if (formatCell == "BodyOdd") cell.CellStyle = CellStyleBodyOdd;               
                else if (formatCell == "User")    cell.CellStyle = CellStyleUser;               
                return;
            }

            //Если формат пользовательский, то разбираем строку формата FormatCell.
            //Пример:
            //ПроизвольныйТектВЯчейке{Merge: 1, 0; ColWidth: 50; RowHeight:100; FontColor:11; FontName:Arial; FontSize:11; FontBold:1; FontItalic:1; FontStrike:1; FontUnderline:1,1}            
            string[] formatArray = formatCell.Split(';');
            var listParams = new string[26, 2];
              
            bool fontName            = GetParam(formatArray, "FontName",            out listParams[0, 0],  out listParams[0, 1]);
            bool fontSize            = GetParam(formatArray, "FontSize",            out listParams[1, 0],  out listParams[1, 1]);
            bool fontColor           = GetParam(formatArray, "FontColor",           out listParams[2, 0],  out listParams[2, 1]);
            bool fontBold            = GetParam(formatArray, "FontBold",            out listParams[3, 0],  out listParams[3, 1]);
            bool fontItalic          = GetParam(formatArray, "FontItalic",          out listParams[4, 0],  out listParams[4, 1]);
            bool fontStrike          = GetParam(formatArray, "FontStrike",          out listParams[5, 0],  out listParams[5, 1]);
            bool fontUnderline       = GetParam(formatArray, "FontUnderline",       out listParams[6, 0],  out listParams[6, 1]);

            bool horizontalAligment  = GetParam(formatArray, "HorizontalAligment",  out listParams[7, 0],  out listParams[7, 1]);
            bool verticalAligment    = GetParam(formatArray, "VerticalAligment",    out listParams[8, 0],  out listParams[8, 1]);

            bool borderLineBottom    = GetParam(formatArray, "BorderLineBottom",    out listParams[9, 0],  out listParams[9, 1]);
            bool borderLineLeft      = GetParam(formatArray, "BorderLineLeft",      out listParams[10, 0], out listParams[10, 1]);
            bool BorderLineRight     = GetParam(formatArray, "BorderLineRight",     out listParams[11, 0], out listParams[11, 1]);
            bool borderLineTop       = GetParam(formatArray, "BorderLineTop",       out listParams[12, 0], out listParams[12, 1]);

            bool borderColorBottom   = GetParam(formatArray, "BorderColorBottom",   out listParams[13, 0], out listParams[13, 1]);
            bool borderColorLeft     = GetParam(formatArray, "BorderColorLeft",     out listParams[14, 0], out listParams[14, 1]);
            bool borderColorRight    = GetParam(formatArray, "BorderColorRight",    out listParams[15, 0], out listParams[15, 1]);
            bool borderColorTop      = GetParam(formatArray, "BorderColorTop",      out listParams[16, 0], out listParams[16, 1]);

            bool wrapText            = GetParam(formatArray, "WrapText",            out listParams[17, 0], out listParams[17, 1]);
            bool shrinkToFit         = GetParam(formatArray, "ShrinkToFit",         out listParams[18, 0], out listParams[18, 1]);
            bool fillBackgroundColor = GetParam(formatArray, "FillBackgroundColor", out listParams[19, 0], out listParams[19, 1]);
            bool fillForegroundColor = GetParam(formatArray, "FillForegroundColor", out listParams[20, 0], out listParams[20, 1]);
            bool formula             = GetParam(formatArray, "Formula",             out listParams[21, 0], out listParams[21, 1]);
            bool merge               = GetParam(formatArray, "Merge",      out listParams[22, 0], out listParams[22, 1]);
            bool colWidth            = GetParam(formatArray, "ColWidth",   out listParams[23, 0], out listParams[23, 1]);
            bool rowHeight           = GetParam(formatArray, "RowHeight",  out listParams[24, 0], out listParams[24, 1]);
            bool borderCell          = GetParam(formatArray, "BorderCell", out listParams[25, 0], out listParams[25, 1]);

            if (fontName || fontSize || fontColor || fontBold || fontItalic || fontStrike || fontUnderline)
            {
                IFont font = book.CreateFont();

                if (fontName) font.FontName = listParams[0, 0];
                if (fontSize)
                    font.FontHeight = listParams[1, 0].ToInt(); //font.FontHeightInPoints = 11?                    
                if (fontColor) font.Color = listParams[2, 0].ToShort();
                if (fontBold)
                {
                    font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                    font.IsBold = listParams[3, 0].ToBool();
                }

                if (fontItalic) font.IsItalic = listParams[4, 0].ToBool();
                if (fontStrike) font.IsStrikeout = listParams[5, 0].ToBool();
                if (fontUnderline)
                {
                    if (listParams[6, 0] == "0") font.Underline = FontUnderlineType.None;
                    if (listParams[6, 0] == "1")
                    {
                        if (listParams[6, 1] == "1") font.Underline = FontUnderlineType.Single;
                        if (listParams[6, 1] == "2") font.Underline = FontUnderlineType.Double;
                    }
                }
                CellStyleUser.SetFont(font);
            }
            
            if (horizontalAligment)
            {
                NPOI.SS.UserModel.HorizontalAlignment en;
                if (Enum.TryParse(listParams[7, 0], out en)) CellStyleUser.Alignment = en;
            }
            
            if (verticalAligment)
            {
                NPOI.SS.UserModel.VerticalAlignment en;
                if (Enum.TryParse(listParams[8, 0], out en)) CellStyleUser.VerticalAlignment = en;
            }

            if (borderLineBottom)
            {
                if (listParams[9, 0] == "0") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
                if (listParams[9, 0] == "1")
                {
                    NPOI.SS.UserModel.BorderStyle en;
                    if (Enum.TryParse(listParams[9, 1], out en)) CellStyleUser.BorderBottom = en;
                }
            }

            if (borderLineLeft)
            {
                if (listParams[10, 0] == "0") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.None;
                if (listParams[10, 0] == "1")
                {
                    NPOI.SS.UserModel.BorderStyle en;
                    if (Enum.TryParse(listParams[10, 1], out en)) CellStyleUser.BorderLeft = en;
                }
            }

            if (BorderLineRight)
            {
                if (listParams[11, 0] == "0") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
                if (listParams[11, 0] == "1")
                {
                    NPOI.SS.UserModel.BorderStyle en;
                    if (Enum.TryParse(listParams[11, 1], out en)) CellStyleUser.BorderRight = en;
                }
            }

            if (borderLineTop)
            {
                if (listParams[12, 0] == "0") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.None;
                if (listParams[12, 0] == "1")
                {
                    NPOI.SS.UserModel.BorderStyle en;
                    if (Enum.TryParse(listParams[12, 1], out en)) CellStyleUser.BorderTop = en;
                }
            }

            if (borderCell)
            {
                NPOI.SS.UserModel.BorderStyle en;
                if (Enum.TryParse(listParams[25, 0], out en))
                {
                    CellStyleUser.BorderBottom = en;
                    CellStyleUser.BorderRight = en;
                    CellStyleUser.BorderLeft = en;
                    CellStyleUser.BorderTop = en;
                }
            }

            //Color
            if (borderColorBottom) CellStyleUser.BottomBorderColor  = listParams[13, 0].ToShort();
            if (borderColorLeft) CellStyleUser.LeftBorderColor 		= listParams[14, 0].ToShort();
            if (borderColorRight) CellStyleUser.RightBorderColor    = listParams[15, 0].ToShort();
            if (borderColorTop) CellStyleUser.TopBorderColor        = listParams[16, 0].ToShort();

            if (wrapText) CellStyleUser.WrapText       = listParams[17, 0].ToBool();
            if (shrinkToFit) CellStyleUser.ShrinkToFit = listParams[18, 0].ToBool();
            if (fillBackgroundColor)
            {
                CellStyleUser.FillBackgroundColor = listParams[19, 0].ToShort();
                CellStyleUser.FillPattern = FillPattern.SolidForeground;
            }

            if (fillForegroundColor)
            {
                CellStyleUser.FillForegroundColor = listParams[20, 0].ToShort();
                CellStyleUser.FillPattern = FillPattern.SolidForeground;
            }

            //Формаула ячейки
            if (formula) cell.CellFormula = listParams[21, 0].ToString();

            if (colWidth) cell.Sheet.SetColumnWidth(cell.ColumnIndex, listParams[23, 0].ToInt());
            if (rowHeight) cell.Row.Height = listParams[24, 0].ToShort();

            //Применение стиля к ячейке.
            cell.CellStyle = CellStyleUser;

            //Объединение ячеек.
            if (merge)
            {
                int firstRow = cell.RowIndex;
                int lastRow = cell.RowIndex + listParams[22, 0].ToInt();
                int firstCol = cell.ColumnIndex;
                int lastCol = cell.ColumnIndex + listParams[22, 1].ToInt();
                var rangemegge = new CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
                sheet.AddMergedRegion(rangemegge);
            }
        }
        
        /// <summary>
        /// Создаем формат ячейки, согласно указанному в переменной FormatCell.
        /// </summary>
        private void SetDefaultStyle()
        {
            //Формат ячеек для шапки таблицы.
            if (CellStyleCaption == null)
            {
                CellStyleCaption = book.CreateCellStyle();
                fontCaption = book.CreateFont();
                fontCaption.FontName = "Calibri";
                fontCaption.FontHeightInPoints = 12;
                fontCaption.Boldweight = (short) NPOI.SS.UserModel.FontBoldWeight.Bold;
                fontCaption.Color = IndexedColors.Black.Index;
                CellStyleCaption.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleCaption.BorderLeft   = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleCaption.BorderRight  = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleCaption.BorderTop    = NPOI.SS.UserModel.BorderStyle.Thin;

                CellStyleCaption.BottomBorderColor = HSSFColor.Black.Index;
                CellStyleCaption.LeftBorderColor   = HSSFColor.Black.Index;
                CellStyleCaption.RightBorderColor  = HSSFColor.Black.Index;
                CellStyleCaption.TopBorderColor    = HSSFColor.Black.Index;

                CellStyleCaption.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                CellStyleCaption.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            
                CellStyleCaption.SetFont(fontCaption);
                //CellStyleCaption.FillBackgroundColor = IndexedColors.Blue.Index; //не работает!
                CellStyleCaption.ShrinkToFit = false;
                CellStyleCaption.WrapText = true;               
                CellStyleCaption.FillForegroundColor = ForegroundColorCaption; 
                CellStyleCaption.FillPattern = FillPattern.SolidForeground;                           
            }

            //Формат ячеек для тела таблицы.
            if (CellStyleBody == null)
            {
                CellStyleBody = book.CreateCellStyle();
                fontBody = book.CreateFont();
                fontBody.FontName = "Calibri";
                fontBody.FontHeightInPoints = 11;
                fontBody.Boldweight = (short) NPOI.SS.UserModel.FontBoldWeight.None;
                fontBody.Color = IndexedColors.Black.Index;

                CellStyleBody.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleBody.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleBody.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleBody.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;

                CellStyleBody.BottomBorderColor = HSSFColor.Black.Index;
                CellStyleBody.LeftBorderColor   = HSSFColor.Black.Index;
                CellStyleBody.RightBorderColor  = HSSFColor.Black.Index;
                CellStyleBody.TopBorderColor    = HSSFColor.Black.Index;
                CellStyleBody.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
                CellStyleBody.SetFont(fontBody);
                CellStyleBody.ShrinkToFit = false;
                if (ForegroundColor > -1)
                {
                    CellStyleBody.FillForegroundColor = ForegroundColor; //IndexedColors.BlueGrey.Index; 
                    CellStyleBody.FillPattern = FillPattern.SolidForeground;
                }
                
            }

            //Формат ячеек для тела таблицы с цветом, для вывода с разным фоном строки через одну.
            if (CellStyleBodyOdd == null)
            {
                CellStyleBodyOdd = book.CreateCellStyle();
                fontBodyOdd = book.CreateFont();
                fontBodyOdd.FontName = "Calibri";
                fontBodyOdd.FontHeightInPoints = 11;
                fontBodyOdd.Boldweight = (short) NPOI.SS.UserModel.FontBoldWeight.None;
                fontBodyOdd.Color = IndexedColors.Black.Index;

                CellStyleBodyOdd.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleBodyOdd.BorderLeft   = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleBodyOdd.BorderRight  = NPOI.SS.UserModel.BorderStyle.Thin;
                CellStyleBodyOdd.BorderTop    = NPOI.SS.UserModel.BorderStyle.Thin;

                CellStyleBodyOdd.BottomBorderColor = HSSFColor.Black.Index;
                CellStyleBodyOdd.LeftBorderColor   = HSSFColor.Black.Index;
                CellStyleBodyOdd.RightBorderColor  = HSSFColor.Black.Index;
                CellStyleBodyOdd.TopBorderColor    = HSSFColor.Black.Index;
                CellStyleBodyOdd.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
                CellStyleBodyOdd.SetFont(fontBodyOdd);
                CellStyleBodyOdd.ShrinkToFit = false;
                CellStyleBodyOdd.FillForegroundColor = ForegroundColorOdd;
                CellStyleBodyOdd.FillPattern = FillPattern.SolidForeground;
            }

            //Формат ячеек пользовательский.
            if (CellStyleUser == null)
            {
                CellStyleUser = book.CreateCellStyle();
                CellStyleUser.CloneStyleFrom(CellStyleBody);
            }
        } 
        
        /// <summary>
        /// Для разработки. Проверка цветов типа short для NPOI.
        /// </summary>
        /// <param name="cell">Ячейка. Тип NPOI.SS.UserModel.ICell. </param>
        /// <param name="indexcolor">Цвет ячейки.</param>
        private void SetSampleStyle(NPOI.SS.UserModel.ICell cell, short indexcolor)
        {
            //Формат ячеек для тела таблицы.
            ICellStyle CellStyleUser1 = book.CreateCellStyle();  
            CellStyleUser1.FillForegroundColor = indexcolor;
            CellStyleUser1.FillPattern = FillPattern.SolidForeground;
            cell.CellStyle = CellStyleUser1;
        }
   
        /// <summary>
        /// Поиск местоположения закладки.
        /// </summary>
        /// <param name="bookmark">Закладка</param>
        /// <param name="rowIndex">Индекс строки</param>
        /// <param name="columnIndex">Индекст колонки</param>
        /// <returns>Если закладка найдена, то true</returns>
        private bool GetBookmarkPoint(string bookmark, out int rowIndex, out int columnIndex)
        {
            rowIndex = 0;
            columnIndex = 0;
            for (int i = 0; i < BookmarkCount; i++)
            {
                if (Bookmarks[i, eSheet] != CurrentSheetName) continue;
                if (Bookmarks[i, eValue].IndexOf(bookmark) == -1) continue;
                rowIndex = Bookmarks[i, eRow].ToInt();
                columnIndex = Bookmarks[i, eColumn].ToInt();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Поиск местоположения закладок во всей книге.
        /// </summary>
        /// <param name="bookmarkCount">Количество найденных закладок.</param>
        /// <returns>Если закладки найдены, то true</returns>
        private bool ParseTemplate(out int bookmarkCount)
        {
            bookmarkCount = 0;
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
                        Bookmarks[bookmarkCount, 0] = bookmarkCount.ToString();
                        Bookmarks[bookmarkCount, 1] = sheet.SheetName;
                        Bookmarks[bookmarkCount, 2] = Value;
                        Bookmarks[bookmarkCount, 3] = row.ToString();
                        Bookmarks[bookmarkCount, 4] = col.ToString();
                        bookmarkCount++;
                    }
                }
            }

            //sys.ArrayView("Bookmarks", "Value", Bookmarks);
            return (bookmarkCount > 0);
        }

        #region Region. Вывод текста и таблиц.
     
        /// <summary>
        /// Печать текста в место с кординатами int row, int col.
        /// </summary>
        /// <param name="rowIndex">Индекс строки</param>
        /// <param name="columnIndex">Индекс колонки</param>
        /// <param name="textCell">Текст в ячейке</param>
        /// <param name="formatCell">Формат ячейки. Описание формата в заголовке класса</param>
        /// <param name="progressText">Текст, выводимый в прогресс-баре</param>
        /// <returns>Если ошибок нет при выводе, то true</returns>
        public bool PutTextAtPoint(int rowIndex, int columnIndex, string textCell, string formatCell, string progressText)
        {
            //Подготовка отчета Excel - создание книги, листа.           
            //NPOI.SS.UserModel.IRow row = sheet.CreateRow(RowIndex);  
            
            //Создаем стили по умолчанию.
            SetDefaultStyle();
            if (Progress != null)
            {
                if (Progress.PressCancel) return true;
                if (!Progress.Visible) Progress.Show();
            }

            try
            {
                if (Progress != null) Progress.ProgressText = progressText;

                NPOI.SS.UserModel.IRow row;
                row = sheet.GetRow(rowIndex);                
                if (row == null) row = sheet.CreateRow(rowIndex);
                NPOI.SS.UserModel.ICell cell;
                cell = row.GetCell(columnIndex);
                if (cell == null) cell = row.CreateCell(columnIndex);
                SetFormatCell(cell, formatCell);
                cell.SetCellValue(textCell);

                //Если есть форма прогресса, то увеличиваем счетчик
                if (Progress != null)
                {
                    if (Progress.PressCancel) return true;
                    if (Test) Thread.Sleep(20);
                    Progress.Inc();
                }

            }
            catch (Exception ex)
            {
                if (ShowError)
                {
                    errorCount++;
                    string errorMes = "Ошибка вывода текста: " + progressText + Var.CR +
                                      ex.Message + Var.CR + "Координаты вывода: " + rowIndex.ToString() + ":" + columnIndex.ToString();
                    if (CurrentBookmark != "") errorMes = errorMes + Var.CR + "Закладка: " + CurrentBookmark;
                    sys.SM(errorMes);
                }
                return false;
            }


            return true;
        }
    
        /// <summary>
        /// Печать текста в место, на которое указывает текст в ячейке.
        /// </summary>
        /// <param name="bookmark">Закладка</param>
        /// <param name="textCell">Текст в ячейке.</param>
        /// <param name="formatCell">Формат ячейки. Описание формата в заголовке класса</param>
        /// <param name="progressText">Текст, выводимый в прогресс-баре</param>
        /// <returns>Если ошибок нет при выводе, то true</returns>
        public bool PutTextAtBookmark(string bookmark, string textCell, string formatCell, string progressText)
        {
            CurrentBookmark = bookmark;
            int rowIndex;
            int columnIndex;
            if (!GetBookmarkPoint(bookmark, out rowIndex, out columnIndex)) return false;
            return PutTextAtPoint(rowIndex, columnIndex, textCell, formatCell, progressText);
        }
       
		/// <summary>
		/// Печать таблицы DT в место с кординатами int row, int col.    
        /// ПроизвольныйТектВЯчейке{Merge: 1, 0; ColWidth: 50; RowHeight:100; FontColor:11; FontName:Arial; FontSize:11; FontBold:1; FontItalic:1; FontStrike:1; FontUnderline:1,1}
        /// Где ПроизвольныйТектВЯчейке - это то что должно отображаться в ячейке в excel.
        /// Выражение в фигурных скобках - это пример форматирования ячеки.        
		/// </summary>
		/// <param name="rowIndex"></param>
		/// <param name="columnIndex"></param>
		/// <param name="dt"></param>
		/// <param name="tableCaption"></param>
		/// <param name="defaultFormat">Первая строка жирная</param>
		/// <param name="formatTable">Строка с описанием формата</param>
		/// <param name="shiftRows">Сдвигать строки при выводе таблицы, или заменять</param>
		/// <param name="progressText">Текст, выводимый в прогресс-баре</param>
		/// <returns>Если ошибок нет при выводе, то true</returns>
        public bool PutTableAtPoint(int rowIndex, int columnIndex, System.Data.DataTable dt, string tableCaption,
            bool defaultFormat, string formatTable, bool shiftRows, string progressText)
        {
            //Создаем стили по умолчанию.
            SetDefaultStyle();
            if (Progress != null)
            {
                if (Progress.PressCancel) return true;
                if (!Progress.Visible) Progress.Show();
            }
        
            try
            {
                //Подготовка отчета Excel - создание книги, листа.
                //DefaultFormat означает, что первая строка жирным шрифтом, остальные нет.  
                if (Progress != null) Progress.ProgressText = progressText;
                if (dt == null) return false;
                NPOI.SS.UserModel.IRow row;
                NPOI.SS.UserModel.ICell cell;
                string formatCellPrev = "";
                string formatCell = "";
                string textCell;
                int CaptionNumRow = 0;
                if (tableCaption != "") CaptionNumRow = 1;
                if (shiftRows) sheet.ShiftRows(rowIndex + 1, sheet.LastRowNum, dt.Rows.Count - 1 + CaptionNumRow);

                if (tableCaption == "") tableCaption = dt.DataTableCaptionWithSeparator("|");
                if (tableCaption != "")
                {
                    string[] cap = tableCaption.Split('|');
                    row = sheet.GetRow(rowIndex);
                    if (row == null) row = sheet.CreateRow(rowIndex);

                    row.Height = CaptionHeight;

                    for (int j = 0; j < cap.Length; j++)
                    {
                        cell = row.GetCell(columnIndex + j);
                        if (cell == null) cell = row.CreateCell(columnIndex + j);

                        //Изначально в Value может быть такой текст:
                        GetFormatCellString(cap[j], out textCell, out formatCell);
                        cell.SetCellValue(textCell);
                        if (formatCell == "")
                        {
                            cell.SetCellValue(cap[j]);
                            
                            SetFormatCell(cell, "Caption"); 
                        }
                        else
                        {
                            //Если в ячейке формат изменился, то создаем новый формат.                        
                            SetFormatCell(cell, formatCell);
                            formatCellPrev = formatCell;   
                        }

                        //Если есть форма прогресса, то увеличиваем счетчик
                        if (Progress != null)
                        {
                            if (Test) Thread.Sleep(100);
                            if (Progress.PressCancel) return true;
                            Progress.Inc();
                        }
                    }
                    rowIndex++;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = sheet.GetRow(rowIndex + i);
                    if (row == null) row = sheet.CreateRow(rowIndex + i);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string value = dt.Rows[i][j].ToString();
                        cell = row.GetCell(columnIndex + j);
                        if (cell == null) cell = row.CreateCell(columnIndex + j);

                        //Если формат стиля ячеек по умолчанию, то возвращаем заранее определённый.
                        if (defaultFormat)
                        {
                            cell.SetCellValue(value);
                            if ((i == 0) && (tableCaption == "")) SetFormatCell(cell, "Caption"); 
                            else
                            {
                                if (FormatTableOdd)
                                {
                                    //if (i.IsEven())  cell.CellStyle = CellStyleBody;
                                    //else cell.CellStyle = CellStyleBodyOdd;  
                                    if (i.IsEven()) SetFormatCell(cell, "Body");
                                    else SetFormatCell(cell, "BodyOdd");
                                }
                            }
                        }
                        else
                        {
                            //Изначально в Value может быть такой текст:
                            GetFormatCellString(value, out textCell, out formatCell);
                            cell.SetCellValue(textCell);

                            //Если в ячейке формат изменился, то создаем новый формат.
                            if (formatCell != "")
                            {
                                SetFormatCell(cell, formatCell);
                                formatCellPrev = formatCell;
                            }
                            else SetFormatCell(cell, formatCellPrev);
                        }
                    }

                    //Если есть форма прогресса, то увеличиваем счетчик
                    if (Progress != null)
                    {
                        if (Test) Thread.Sleep(100);
                        if (Progress.PressCancel) return true;
                        //if (Progress.Progress < Progress.Max)
                        Progress.Inc();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ShowError)
                {
                    errorCount++;
                    string errorMes = "Ошибка вывода таблицы: " + progressText + Var.CR +
                                      ex.Message + Var.CR + "Координаты вывода: " + rowIndex.ToString() + ":" + columnIndex.ToString();
                    if (CurrentBookmark != "") errorMes = errorMes + Var.CR + "Закладка: " + CurrentBookmark;
                    sys.SM(errorMes);
                }
                return false;
            }            
        }
                      
        /// <summary>
        /// Печать таблицы DT в место, на которое указывает текст Bookmark в какой либо ячейке шаблона.             
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="dt">DataTable - таблица для вывода в отчет</param>
        /// <param name="tableCaption"></param>
        /// <param name="defaultFormat">Первая строка жирная</param>
        /// <param name="formatTable">Строка с описанием формата</param>
        /// <param name="shiftRows">Сдвигать строки при выводе таблицы, или заменять. </param>
		/// <param name="progressText">Текст, выводимый в прогресс-баре</param>
		/// <returns>Если ошибок нет при выводе, то true</returns>
        public bool PutTableAtBookmark(string bookmark, DataTable dt, string tableCaption, bool defaultFormat,
            string formatTable, bool shiftRows, string progressText)
        {
            CurrentBookmark = bookmark;
            if (sys.IsEmpty(progressText)) progressText = "Вывод таблицы";
            if (dt == null) return false;
            int rowIndex;
            int columnIndex;
            if (!GetBookmarkPoint(bookmark, out rowIndex, out columnIndex)) return false;
            return PutTableAtPoint(rowIndex, columnIndex, dt, tableCaption, defaultFormat, formatTable, shiftRows, progressText);
        }

        #endregion Region. Вывод текста и таблиц.
        
        #region Region. Вспомогательные функции.      
		
		/// <summary>
		/// Возвращение параметров из массива параметров FormatArray. Для разбора строки формата.  
		/// Всего может быть две части параметра
		/// </summary>
		/// <param name="formatArray">Весь массив параметров</param>
		/// <param name="paramIN">Искомый параметр</param>
		/// <param name="param1">Часть параметра 1</param>
		/// <param name="param2">Часть параметра 2</param>
		/// <returns></returns>
        private bool GetParam(string[] formatArray, string paramIN, out string param1, out string param2)
        {
            //GetParam - какой параметр проверяем. Например если GetParam = Merge, то если исходный параметр Merge:1,3
            //то Param1 будет равно 1, Param2 будет равно 3.   
            param1 = "";
            param2 = "";
            if (sys.IsEmpty(paramIN)) return false;
            for (int i = 0; i < formatArray.Length; i++)
            {
                if (formatArray[i].IndexOfBool(paramIN))
                {
                    string[] s1 = formatArray[i].Split(':');
                    if (s1.Length < 1) return false;
                    string[] s2 = s1[1].Split(',');
                    if (s2.Length > 0) param1 = s2[0].Trim();
                    if (s2.Length > 1) param2 = s2[1].Trim();
                    return true;
                }
            }
            return false;
        }

		/// <summary>
		/// Разделение на две части: сама строка и строка с массивом параметров. 
		/// Пример Value = abc{ Merge: 1, 0; ColWidth: 50; RowHeight: 100; FontColor: 11; CellBold: 1; }, то:
        /// TextCell = abc
        /// FormatCell = Merge: 1, 0; ColWidth: 50; RowHeight: 100; FontColor: 11; CellBold: 1;		
		/// </summary>
		/// <param name="value">Значение в ячейке</param>
		/// <param name="textCell">Текст значения</param>
		/// <param name="formatCell">Формат текста значения</param>
        private void GetFormatCellString(string value, out string textCell, out string formatCell)
        {
            
            int n1 = value.IndexOf('{');
            int n2 = value.LastIndexOf('}');
            if ((n1 == -1) || (n2 == -1))
            {
                textCell = value;
                formatCell = "";
                return;
            }
            textCell = value.Substring(0, n1);
            formatCell = value.StrBetweenStr4("{", "}");
        }         
        
        /// <summary>
        /// Команда установки текущего листа по индексу листа.
        /// </summary>
        /// <param name="sheetIndex">Индекс листа в книге</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetCurrentSheet(int sheetIndex)
        {
            string errorMes = "";
            if (sheetIndex > book.NumberOfSheets)
                errorMes = "Указан неверный порядковый номер листа: " + sheetIndex.ToString() +
                           ". Количество листов в книге всего: " + book.NumberOfSheets.ToString();
            if (book == null)
                errorMes = "Книга не создана!";

            if (errorMes != "")
            {
                errorCount++;
                if (ShowError) sys.SM(errorMes);
                return false;
            }
            sheet = book.GetSheetAt(sheetIndex);
            CurrentSheetName = sheet.SheetName;
            return true;
        }     
        
        /// <summary>
        /// Команда установки текущего листа по имени листа.
        /// </summary>
        /// <param name="sheetName">Имя личта в книге</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetCurrentSheet(string sheetName)
        {
            string errorMes = "";
            if (book == null)
                errorMes = errorMes = "Книга не создана!";
            if (errorMes != "")
            {
                errorCount++;
                if (ShowError) sys.SM(errorMes);
                return false;
            }
            sheet = book.GetSheet(sheetName);
            if (sheet == null)
            {
                errorCount++;
                if (ShowError) sys.SM("Указано неверное имя листа: " + sheetName);
                return false;
            }
            CurrentSheetName = sheet.SheetName;
            return true;
        }      

          /// <summary>
        /// Сохранение напечатанного отчета на диск в формате XLSX.
        /// </summary>
        /// <param name="fileName">Имя файла, куда сохраняем.</param>
        /// <param name="openAfterSave">Открыть после сохранения</param>
        /// <returns></returns>
        public bool SaveToExcel(string fileName, bool openAfterSave)
        {
            if (Progress != null)
            {
                if (Progress.PressCancel) return true;               
            }

            if (errorCount > 0)
            {
                if (ShowError) sys.SM("При печати отчета произошли ошибки: " + errorCount.ToString());             
            }

            if (sys.IsEmpty(fileName))
            {
                if (!sys.IsEmpty(ReportTemplateFileName)) fileName = FBAPath.PathTemp + ReportTemplateFileName;
                else fileName = FBAPath.PathTemp + ReportBrief + ".xlsx";
            }

            string ext = "";
            if (fileName.ToUpper().EndsWith(".XLS"))
            {
                string ch = fileName.Right(1);
                if (ch == "S") fileName = fileName + "X";
                else fileName = fileName + "x";
            }
            if (fileName.ToUpper().EndsWith(".XLSX")) ext = ".XLSX";
            if (ext == "") fileName = fileName + ".xlsx";

            string fileNameFullNew = "";
            //Получить имя файла, которого ещё не существует.
            if (!FBAFile.GetNewFileName(fileName, true, out fileNameFullNew)) return false;

            //запишем всё в файл
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileNameFullNew, FileMode.Create, FileAccess.Write);
            }
            catch (Exception ex)
            {
                errorCount++;
                if (ShowError) sys.SM("Ошибка сохранения файла Excel: " + fileNameFullNew + Var.CR + ex.Message);
                return false;
            }
            
            //В переменную класса.
            ReportOutputFullFileNameXLS = fileNameFullNew;
            
            //Запись книги отчета на диск.
            book.Write(fs);            
            if (fs != null) fs.Close();

            //Если форма прогресса ещё не закрыта, то закроем.
             if (Progress != null) Progress.Close();

            //Откроем файл
            if (openAfterSave) Process.Start(fileNameFullNew);
            return true;
        }
        
        /// <summary>
        /// Конвертация Excel в PDF.
        /// </summary>
        /// <param name="fileNameXLS">Путь к файлу Excel</param>
        /// <param name="fileNamePDF">Путь к файлу PDF</param>
        /// <param name="openAfterSave">Открыть PDF в программе по умолчанию после формирования</param>
        /// <returns>Если успешно, то true</returns>
        public bool ExportToPDF(string fileNameXLS, string fileNamePDF, bool openAfterSave)
		{		 		            	
        	if (string.IsNullOrEmpty(fileNameXLS)) 
        	{        		
        		if (string.IsNullOrEmpty(ReportOutputFullFileNameXLS)) SaveToExcel("", false);
        		fileNameXLS = ReportOutputFullFileNameXLS;     
        	}
        			       	
        	if (string.IsNullOrEmpty(fileNamePDF)) fileNamePDF = Path.ChangeExtension(fileNameXLS, "pdf");
            this.ReportOutputFullFileNamePDF = fileNamePDF;
        	if (string.IsNullOrEmpty(fileNameXLS) || string.IsNullOrEmpty(fileNamePDF))
		    {
		        return false;
		    }
			
		    Microsoft.Office.Interop.Excel.Application excelApplication;
		    Microsoft.Office.Interop.Excel.Workbook excelWorkbook;
		    excelApplication = new Microsoft.Office.Interop.Excel.Application();	
		    excelApplication.ScreenUpdating = false; //Скрываем Excel			
		    excelApplication.DisplayAlerts = false;				
		    excelWorkbook = excelApplication.Workbooks.Open(fileNameXLS);			
		    if (excelWorkbook == null)
		    {
		        excelApplication.Quit();		
		        excelApplication = null;
		        excelWorkbook    = null;		
		        return false;
		    }		
		    var exportSuccessful = true;
		    try
		    {
		       //Вызов собственной функции экспорта Excel (действует в Office 2007 и Office 2010, AFAIK)
		        excelWorkbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, fileNamePDF);
		    }
		    catch (System.Exception ex)
		    {
		    	exportSuccessful = false;
		    	sys.SM(ex.Message);		    			        				     
		    }
		    finally
		    {		       
		        excelWorkbook.Close();
		        excelApplication.Quit();		
		        excelApplication = null;
		        excelWorkbook = null;
		    }
		
		    if (!System.IO.File.Exists(fileNamePDF))
		    {
		    	exportSuccessful = false;
		    	sys.SM("Файл PDF не найден: " + fileNamePDF);	
				return exportSuccessful;		    	
		    }
		    // You can use the following method to automatically open the PDF after export if you wish
		    // Make sure that the file actually exists first...
		    if (openAfterSave)
		    {
		        System.Diagnostics.Process.Start(fileNamePDF);
		    }		
		    return exportSuccessful;
		}
        
        //public bool SaveAsPDF()
        //{
        	
        	//string path = @"D:\texts\"; // прописываем путь к папке с файлами для удобства
            //Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application(); // создаём экземпляр приложения Word
            //Document file = word.Documents.Open(path + "info.docx"); // создаём экземпляр документа и открываем word файл
            //file.ExportAsFixedFormat(path + "info_pdf.pdf", WdExportFormat.wdExportFormatPDF); // преобразование файла в PDF формат
            //file.ExportAsFixedFormat(path + "info_xps.xps", WdExportFormat.wdExportFormatXPS); // преобразование файла в XPS формат
            //word.Quit(); // закрываем Word
            
            
            //string path = @"D:\texts\"; // прописываем путь к папке с файлами для удобства
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // создаём экземпляр приложения Word
            //Document file = excel.Open(path + "info.docx"); // создаём экземпляр документа и открываем word файл
            //file.ExportAsFixedFormat(path + "info_pdf.pdf", WdExportFormat.wdExportFormatPDF); // преобразование файла в PDF формат
            //file.ExportAsFixedFormat(path + "info_xps.xps", WdExportFormat.wdExportFormatXPS); // преобразование файла в XPS формат
            //excel.Quit(); // закрываем Word
            
        //}
	        //Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
	       // wordDocument = appWord.Documents.Open(@"D:\desktop\xxxxxx.docx");
	        //wordDocument.ExportAsFixedFormat(@"D:\desktop\DocTo.pdf", WdExportFormat.wdExportFormatPDF);
        //}
        
        #endregion Region. Вспомогательные функции. 
    }
}
