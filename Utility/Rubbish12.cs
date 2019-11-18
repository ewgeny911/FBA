/*public ICellStyle SetFormatCell(NPOI.SS.UserModel.ICell cell, string FormatCell)
{

    //Если нужно установить стиль по умолчанию.
    //По умолчанию определено два стиля Caption и Body.
    if ((FormatCell == "Header") || (FormatCell == "Body"))
    {
        if (FormatCell == "Header") return CellStyleHeader;
        if (FormatCell == "Body") return CellStyleBody;

        return null;
    }

    //Пример:
    //abc{ Merge: 1, 0; ColWidth: 50; RowHeight:100; FontColor:11; FontName:Arial; FontSize:11; FontBold:1; FontItalic:1; FontStrike:1; FontUnderline:1,1}
    string[] FormatArray = FormatCell.Split(';');

    for (int i = 0; i < FormatArray.Length; i++)
    {
        //FontName:       Имя шрифта ячейки.
        //FontSize:       Размер шрифта ячейки.
        //FontColor:      Цвет шрифта ячейки.
        //FontBold:       Жирный шрифт ячейки.
        //FontItalic:     Наклон шрифта ячейки.
        //FontStrike:     Перечеркнутый шрифт ячейки.
        //FontUnderline:  Подчеркнутый шрифт ячейки.

        string[,] Params = new string[18, 2];

        bool FontName = GetParam(FormatArray, "FontName", out Params[0, 1], out Params[0, 2]);
        bool FontSize = GetParam(FormatArray, "FontSize", out Params[1, 1], out Params[1, 2]);
        bool FontColor = GetParam(FormatArray, "FontColor", out Params[2, 1], out Params[2, 2]);
        bool FontBold = GetParam(FormatArray, "FontBold", out Params[3, 1], out Params[3, 2]);
        bool FontItalic = GetParam(FormatArray, "FontItalic", out Params[4, 1], out Params[4, 2]);
        bool FontStrike = GetParam(FormatArray, "FontStrike", out Params[5, 1], out Params[5, 2]);
        bool FontUnderline = GetParam(FormatArray, "FontUnderline", out Params[6, 1], out Params[6, 2]);
        bool FontAligment = GetParam(FormatArray, "FontAligment", out Params[7, 1], out Params[7, 2]);
        bool BorderBottomLine = GetParam(FormatArray, "BorderBottomLine", out Params[8, 1], out Params[8, 2]);
        bool BorderLeftLine = GetParam(FormatArray, "BorderLeftLine", out Params[9, 1], out Params[9, 2]);
        bool BorderRightLine = GetParam(FormatArray, "BorderRightLine", out Params[10, 1], out Params[10, 2]);
        bool BorderTopLine = GetParam(FormatArray, "BorderTopLine", out Params[11, 1], out Params[11, 2]);

        bool BorderBottomColor = GetParam(FormatArray, "BorderBottomColor", out Params[12, 1], out Params[12, 2]);
        bool BorderLeftColor = GetParam(FormatArray, "BorderLeftColor", out Params[13, 1], out Params[13, 2]);
        bool BorderRightColor = GetParam(FormatArray, "BorderRightColor", out Params[14, 1], out Params[14, 2]);
        bool BorderTopColor = GetParam(FormatArray, "BorderTopColor", out Params[15, 1], out Params[15, 2]);

        bool WrapText = GetParam(FormatArray, "WrapText", out Params[16, 1], out Params[16, 2]);
        bool VerticalAligment = GetParam(FormatArray, "VerticalAligment", out Params[17, 1], out Params[17, 2]);
        bool ShrinkToFit = GetParam(FormatArray, "ShrinkToFit", out Params[18, 1], out Params[18, 2]);

        if (FontName || FontSize || FontColor || FontBold || FontItalic || FontStrike || FontUnderline)
        {
            IFont font = book.CreateFont();

            if (FontName) font.FontName = Params[0, 1];
            if (FontSize)
                font.FontHeight = Params[1, 1].ToInt(); //font.FontHeightInPoints = 11?                    
            if (FontColor) font.Color = Params[2, 1].ToShort();
            if (FontBold)
            {
                font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                font.IsBold = Params[3, 1].ToBool();
            }

            if (FontItalic) font.IsItalic = Params[4, 1].ToBool();
            if (FontStrike) font.IsStrikeout = Params[5, 1].ToBool();
            if (FontUnderline)
            {
                if (Params[6, 1] == "0") font.Underline = FontUnderlineType.None;
                if (Params[6, 1] == "1")
                {
                    if (Params[6, 2] == "1") font.Underline = FontUnderlineType.Single;
                    if (Params[6, 2] == "2") font.Underline = FontUnderlineType.Double;
                }
            }
            CellStyleBody.SetFont(font);
        }

        if (FontAligment)
        {
            if (Params[7, 2] == "Center") CellStyleUser.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            if (Params[7, 2] == "CenterSelection") CellStyleUser.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CenterSelection;
            if (Params[7, 2] == "Left") CellStyleUser.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            if (Params[7, 2] == "Right") CellStyleUser.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            if (Params[7, 2] == "Distributed") CellStyleUser.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Distributed;
            if (Params[7, 2] == "Fill") CellStyleUser.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Fill;
            if (Params[7, 2] == "General") CellStyleUser.Alignment = NPOI.SS.UserModel.HorizontalAlignment.General;
            if (Params[7, 2] == "Justify") CellStyleUser.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Justify;
        }

        if (BorderBottomLine)
        {
            if (Params[8, 1] == "0") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            if (Params[8, 1] == "1")
            {
                if (Params[8, 2] == "Dashed") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.Dashed;
                if (Params[8, 2] == "Dotted") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.Dotted;
                if (Params[8, 2] == "Double") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.Double;
                if (Params[8, 2] == "Hair") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.Hair;
                if (Params[8, 2] == "Medium") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                if (Params[8, 2] == "DashDot") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.DashDot;
                if (Params[8, 2] == "MediumDashDot") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.MediumDashDot;
                if (Params[8, 2] == "MediumDashDotDot") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.MediumDashDotDot;
                if (Params[8, 2] == "MediumDashed") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.MediumDashed;
                if (Params[8, 2] == "SlantedDashDot") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.SlantedDashDot;
                if (Params[8, 2] == "Thick") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thick;
                if (Params[8, 2] == "Thin") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            }
        }

        if (BorderLeftLine)
        {
            if (Params[9, 1] == "0") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            if (Params[9, 1] == "1")
            {
                if (Params[9, 2] == "Dashed") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.Dashed;
                if (Params[9, 2] == "Dotted") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.Dotted;
                if (Params[9, 2] == "Double") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.Double;
                if (Params[9, 2] == "Hair") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.Hair;
                if (Params[9, 2] == "Medium") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                if (Params[9, 2] == "DashDot") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.DashDot;
                if (Params[8, 2] == "MediumDashDot") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.MediumDashDot;
                if (Params[8, 2] == "MediumDashDotDot") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.MediumDashDotDot;
                if (Params[8, 2] == "MediumDashed") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.MediumDashed;
                if (Params[8, 2] == "SlantedDashDot") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.SlantedDashDot;
                if (Params[8, 2] == "Thick") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thick;
                if (Params[8, 2] == "Thin") CellStyleUser.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            }
        }

        if (BorderRightLine)
        {
            if (Params[10, 1] == "0") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            if (Params[10, 1] == "1")
            {
                if (Params[10, 2] == "Dashed") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.Dashed;
                if (Params[10, 2] == "Dotted") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.Dotted;
                if (Params[10, 2] == "Double") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.Double;
                if (Params[10, 2] == "Hair") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.Hair;
                if (Params[10, 2] == "Medium") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                if (Params[10, 2] == "DashDot") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.DashDot;
                if (Params[10, 2] == "MediumDashDot") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.MediumDashDot;
                if (Params[10, 2] == "MediumDashDotDot") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.MediumDashDotDot;
                if (Params[10, 2] == "MediumDashed") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.MediumDashed;
                if (Params[10, 2] == "SlantedDashDot") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.SlantedDashDot;
                if (Params[10, 2] == "Thick") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.Thick;
                if (Params[10, 2] == "Thin") CellStyleUser.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            }
        }

        if (BorderTopLine)
        {
            if (Params[11, 1] == "0") CellStyleUser.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
            if (Params[11, 1] == "1")
            {
                if (Params[11, 2] == "Dashed") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.Dashed;
                if (Params[11, 2] == "Dotted") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.Dotted;
                if (Params[11, 2] == "Double") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.Double;
                if (Params[11, 2] == "Hair") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.Hair;
                if (Params[11, 2] == "Medium") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                if (Params[11, 2] == "DashDot") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.DashDot;
                if (Params[11, 2] == "MediumDashDot") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.MediumDashDot;
                if (Params[11, 2] == "MediumDashDotDot") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.MediumDashDotDot;
                if (Params[11, 2] == "MediumDashed") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.MediumDashed;
                if (Params[11, 2] == "SlantedDashDot") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.SlantedDashDot;
                if (Params[11, 2] == "Thick") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.Thick;
                if (Params[11, 2] == "Thin") CellStyleUser.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            }
        }

        if (WrapText) CellStyleUser.WrapText = Params[16, 1].ToBool();

        if (VerticalAligment)
        {
            if (Params[17, 2] == "Bottom") CellStyleUser.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Bottom;
            if (Params[17, 2] == "Center") CellStyleUser.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            if (Params[17, 2] == "Distributed") CellStyleUser.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Distributed;
            if (Params[17, 2] == "Justify") CellStyleUser.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Justify;
            if (Params[17, 2] == "Top") CellStyleUser.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Top;
        }
        CellStyleUser.ShrinkToFit = Params[18, 1].ToBool();
        Enum te = NPOI.SS.UserModel.VerticalAlignment.Top;

        //Enum.TryParse("Bottom", false, out te);

        CellStyleUser.VerticalAlignment = (NPOI.SS.UserModel.VerticalAlignment)Enum.Parse(typeof(NPOI.SS.UserModel.VerticalAlignment), "Top");
        if (CellStyleUser.VerticalAlignment == NPOI.SS.UserModel.VerticalAlignment.Top)
        {

        }

        /*enum PetType
        {
            None,
            Cat = 1,
            Dog = 2
        }

        static void Main()
        {
            // A.
            // Possible user input:
            string value = "Dog";

            // B.
            // Try to convert the string to an enum:
            PetType pet = (PetType)Enum.Parse(typeof(PetType), value);
             if (pet == PetType.Dog)
{
    Console.WriteLine("Equals dog.");
}
*/





//Enum

// }

//Type tp = Type.GetType();
// CellStyleUser.VerticalAlignment = (NPOI.SS.UserModel.VerticalAlignment)tp;

//typeof(NPOI.SS.UserModel.HorizontalAlignment)


// return null;
//}*/

//=========================================================================================

/*//Класс для печати отчетов Excel.
public class ReportXLSX
{
    public NPOI.XSSF.UserModel.XSSFWorkbook book;
    public NPOI.SS.UserModel.ISheet sheet;


    //Пример чтение.
    public void ReadXLSX()
    {
        //Книга Excel
        XSSFWorkbook xssfwb;

        //Открываем файл
        using (FileStream file = new FileStream(@"E:\Мусор\SaveFile.xlsx", FileMode.Open, FileAccess.Read))
        {
            xssfwb = new XSSFWorkbook(file);
        }

        //Получаем первый лист книги
        ISheet sheet = xssfwb.GetSheetAt(0);

        //запускаем цикл по строкам
        for (int row = 0; row <= sheet.LastRowNum; row++)
        {
            //получаем строку
            var currentRow = sheet.GetRow(row);
            if (currentRow != null) //null когда строка содержит только пустые ячейки
            {
                //запускаем цикл по столбцам
                for (int column = 0; column < 3; column++)
                {
                    //получаем значение яейки
                    var stringCellValue = currentRow.GetCell(column).StringCellValue;
                    //Выводим сообщение
                    //MessageBox.Show();
                    sys.SM(string.Format("Ячейка {0}-{1} значение:{2}", row, column, stringCellValue));
                }
            }
        }
    }

    //Пример запись.
    public void WriteXLSX()
    {

        NPOI.XSSF.UserModel.XSSFWorkbook wb;

        //Лист в книге Excel



        wb = new NPOI.XSSF.UserModel.XSSFWorkbook();


        //Создаём лист в книге
        //XSSFSheet sh;
        //sh2 = (NPOI.XSSF.UserModel.XSSFSheet) wb.CreateSheet("Лист 1");

        //Либо берём лист по индексу.
        ISheet sh = wb.GetSheetAt(0);


        //Количество заполняемых строк
        int countRow = 3;
        //Количество заполняемых столбцов
        int countColumn = 3;

        //Запускаем цикл по строкам
        for (int i = 0; i < countRow; i++)
        {
            //Создаем строку
            var currentRow = sh.CreateRow(i);

            //Запускаем цикл по столбцам
            for (int j = 0; j < countColumn; j++)
            {
                //в строке создаём ячеёку с указанием столбца
                var currentCell = currentRow.CreateCell(j);

                //в ячейку запишем информацию о текущем столбце и строке
                currentCell.SetCellValue("Строка - " + (i + 1).ToString() + "Столбец - " + (j + 1).ToString());
                //Выравним размер столбца по содержимому
                sh.AutoSizeColumn(j);
            }

        }

        // Удалим файл если он есть уже
        if (!File.Exists(@"E:\Мусор\SaveFile.xlsx"))
        {
            File.Delete(@"E:\Мусор\SaveFile.Text");
        }

        //запишем всё в файл
        using (var fs = new FileStream(@"E:\Мусор\SaveFile.xlsx", FileMode.Create, FileAccess.Write))
        {
            wb.Write(fs);
        }

        //Откроем файл
        Process.Start(@"E:\Мусор\SaveFile.xlsx");
    }

    /*#region Get data from Excel file
    protected object[,] getExcelData(string path, int firstRow = 0, int firstColumn = 0, int lastRow = 0, int lastColumn = 0, uint sheetNum = 1)
    {
        object[,] data = null;
        Workbook book = null;
        Worksheet sheet = null;
        Range range = null;
        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        try
        {
            book = app.Workbooks.Open(path,
                0,              // не обновлять ссылок
                true,           // открыть только для чтения
                5,              // не задавать разделитель
                Type.Missing,   // без пароля
                Type.Missing,   // без пароля
                true,           // не показывать сообщение "только для чтения"
                Type.Missing,   // не нужен
                Type.Missing,   // не нужен
                Type.Missing,   // не нужен
                Type.Missing,   // не нужен
                Type.Missing,   // не нужен
                Type.Missing,   // не нужен
                Type.Missing,   // не нужен
                Type.Missing);  // не нужен
            sheet = (Worksheet)book.Worksheets[sheetNum];
            if (firstRow == 0) firstRow = sheet.UsedRange[1, 1].RowIndex;
            if (firstColumn == 0) firstColumn = sheet.UsedRange[1, 1].ColumnIndex;
            int rowsCount = sheet.UsedRange.Rows.Count;
            int columnsCount = sheet.UsedRange.Columns.Count;
            if (lastRow == 0) lastRow = sheet.UsedRange[rowsCount, columnsCount].RowIndex;
            if (lastColumn == 0) lastColumn = sheet.UsedRange[rowsCount, columnsCount].ColumnIndex;
            range = sheet.Range[sheet.Cells[firstRow, firstColumn], sheet.Cells[lastRow, lastColumn]];
            data = range.get_Value(Type.Missing);
        }
        finally
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (range != null) Marshal.FinalReleaseComObject(range);
            if (sheet != null) Marshal.FinalReleaseComObject(sheet);
            if (book != null)
            {
                book.Close(false, Type.Missing, Type.Missing);
                Marshal.FinalReleaseComObject(book);
            }
            app.Quit();
            Marshal.FinalReleaseComObject(app);
        }
        return data;
    }
    #endregion
    */

//Пример запись2.
/*   private void toExcelButton_Click()
   {

       DataTable _order = new DataTable();

       FolderBrowserDialog fbd = new FolderBrowserDialog();
       fbd.ShowNewFolderButton = true;
       fbd.SelectedPath = @"D:\";
       DialogResult res = fbd.ShowDialog();
       if (res == System.Windows.Forms.DialogResult.OK)
       {
           string path = fbd.SelectedPath + @"\Заявка.xls";
           XSSFWorkbook book = new XSSFWorkbook();
           ISheet sheet = book.CreateSheet("Sheet1");
           ICellStyle blackBorder = book.CreateCellStyle();
           blackBorder.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
           blackBorder.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
           blackBorder.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
           blackBorder.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;

           blackBorder.BottomBorderColor = HSSFColor.Black.Index;
           blackBorder.LeftBorderColor = HSSFColor.Black.Index;
           blackBorder.RightBorderColor = HSSFColor.Black.Index;
           blackBorder.TopBorderColor = HSSFColor.Black.Index;



           Color cl = new Color();
           cl = Color.Aqua;


           blackBorder.RightBorderColor = 0;
           blackBorder.TopBorderColor = 0;


           IFont font1 = book.CreateFont();
           font1.Boldweight = (short) NPOI.SS.UserModel.FontBoldWeight.Bold;
           font1.FontName = "Calibri";
           font1.FontHeightInPoints = 11;

           IFont font2 = book.CreateFont();
           font2.FontName = "Calibri";
           font2.FontHeightInPoints = 11;

           ICellStyle header = book.CreateCellStyle();
           header.CloneStyleFrom(blackBorder);
           header.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
           header.SetFont(font1);

           ICellStyle cs = book.CreateCellStyle();
           cs.CloneStyleFrom(blackBorder);
           cs.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
           cs.SetFont(font2);

           // заголовок
           IRow row = sheet.CreateRow(0);
           ICell cell = row.CreateCell(0);
           cell.CellStyle = header;
           cell.SetCellValue("Код");
           cell = row.CreateCell(1);
           cell.CellStyle = header;
           cell.SetCellValue("Артикул");
           cell = row.CreateCell(2);
           cell.CellStyle = header;
           cell.SetCellValue("Название");
           cell = row.CreateCell(3);
           cell.CellStyle = header;
           cell.SetCellValue("Производитель");
           cell = row.CreateCell(4);
           cell.CellStyle = header;
           cell.SetCellValue("Ед. изм.");
           cell = row.CreateCell(5);
           cell.CellStyle = header;
           cell.SetCellValue("Цена");
           cell = row.CreateCell(6);
           cell.CellStyle = header;
           cell.SetCellValue("Количество");


           for (int i = 0; i < _order.Rows.Count; i++)
           {
               DataRow r = _order.Rows[i];
               row = sheet.CreateRow(i + 1);
               cell = row.CreateCell(0);
               cell.CellStyle = cs;
               cell.SetCellValue(r["goods_id"].ToString());
               cell = row.CreateCell(1);
               cell.CellStyle = cs;
               cell.SetCellValue(r["article"].ToString());
               cell = row.CreateCell(2);
               cell.CellStyle = cs;
               cell.SetCellValue(r["name"].ToString());
               cell = row.CreateCell(3);
               cell.CellStyle = cs;
               cell.SetCellValue(r["unit_name"].ToString());
               cell = row.CreateCell(4);
               cell.CellStyle = cs;
               cell.SetCellValue(r["producer_name"].ToString());
               cell = row.CreateCell(5);
               cell.CellStyle = cs;
               cell.SetCellValue(r["price"].ToString());
               cell = row.CreateCell(6);
               cell.CellStyle = cs;
               cell.SetCellValue(r["count"].ToString());
           }

           for (int i = 0; i < 7; i++)
               sheet.AutoSizeColumn(i);

           FileStream file = new FileStream(path, FileMode.Create);
           book.Write(file);
           file.Close();
       }
   }


   public void PutTextAtBookmark(NPOI.XSSF.UserModel.XSSFWorkbook book,
       NPOI.SS.UserModel.ISheet sheet,
       string bookmark_text,
       string text,
       string formattext)
   {

   }

   public void PutTableAtBookmark(NPOI.XSSF.UserModel.XSSFWorkbook book,
       NPOI.SS.UserModel.ISheet sheet,
       string bookmark_text,
       DataTable DT)
   {

   }

   public void PutTextAtPosition(NPOI.XSSF.UserModel.XSSFWorkbook book,
       NPOI.SS.UserModel.ISheet sheet,
       int rowindex,
       int colindex,
       string text,
       string formattext)
   {
       int t = book.Count;
       int y = book.NumberOfSheets;
       sheet = book.GetSheet("dsd");
       int y7 = book.GetNameIndex("dsd");
   }

   public void PutTableAtPosition(NPOI.XSSF.UserModel.XSSFWorkbook book,
       NPOI.SS.UserModel.ISheet sheet,
       int rowindex,
       int colindex,
       DataTable DT)
   {

   }
}*/
//=========================================================================================
//Команда установки текущего листа по индексу листа. 
/*public bool SetCurrentSheet(NPOI.XSSF.UserModel.XSSFWorkbook book, 
                            int SheetIndex, 
                            bool ShowError, 
                            out NPOI.SS.UserModel.ISheet sheet, 
                            out string ErrorMes)
{
    ErrorMes = "";
    sheet = null;
    if (book == null)
    {
        ErrorMes = "Книга не создана!";
        if (ShowError) sys.SM(ErrorMes);
        return false;
    }
    if (SheetIndex > book.NumberOfSheets)
    {
        ErrorMes = "Указан неверный порядковый номер листа: " + SheetIndex.ToString() +
                   ". Количество листов в книге всего: " + book.NumberOfSheets.ToString();                             
        if (ShowError) sys.SM(ErrorMes);
        return false;
    }
    sheet = book.GetSheetAt(SheetIndex);          
    return true;
}*/
//=========================================================================================

//string ErrorMes;
//string FileNameTemp = sys.PathTemp + FileName;


//if (!sys.FileWriteFromBase64(FileData, FileNameTemp, out ErrorMes, true)) return;
//if (!File.Exists(FileNameTemp))
//{
//    sys.SM("Не найдено изображение на диске. Имя файла: " + FileNameTemp);
//    return;
//}
//tbID.Text = ImageID;
// tbSize.Text = ImageWidth + "x" + ImageHeight;
//tbFormat.Text = Format;          
//   //return imageStr;
//var image = Image.FromStream(stream);
//pictureBox1.PictureBoxLoadFile(FileNameTemp);
//pictureBox1.Pic
//MemoryStream Memostr = new MemoryStream();
//Image Img = Image.FromFile(filename);
//Img.Save(Memostr, Img.RawFormat);
//printscreen.Save(@"E:\Мусор\file21.jpeg", ImageCodecInfo.GetImageEncoders()[1], enc_param1);
//printscreen.Save(@"E:\Мусор\file3.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
//printscreen.Save(@"E:\Мусор\file1.png", System.Drawing.Imaging.ImageFormat.Png); //Сохранить
//return;
//FileStream file = new FileStream(@"E:\Мусор\file3.jpeg", FileMode.Create, FileAccess.Write);
//ms.WriteTo(file);
//file.Close();
//ms.Close();

//Bitmap bp = Screen.CaptureWindow(Status.hwnd);




//return;


//
//string screenShot 
//Bitmap BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

//EncoderParameters enc_param = new EncoderParameters()
//{
//    Param = new EncoderParameter[]
//            {
//                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L - 51)
//           }
//};
//using (Bitmap bmp = new Bitmap(FileName))
//{
//   BM.Save(@"E:\Мусор\file2.jpeg", ImageCodecInfo.GetImageEncoders()[1], enc_param);
//}


/*MemoryStream ms = new MemoryStream();
BM.Save(ms, ImageFormat.Jpeg);

//MemoryStream ms = new MemoryStream();
//using (FileStream file = new FileStream(@"E:\Мусор\file1.jpeg", FileMode.Open, FileAccess.Read))
//    file.CopyTo(ms);

//string memString = "Memory test string !!";
// convert string to stream
//byte[] buffer = Encoding.ASCII.GetBytes(memString);
//MemoryStream ms = new MemoryStream(buffer);
//write to file
FileStream file = new FileStream(@"E:\Мусор\file1.jpeg", FileMode.Create, FileAccess.Write);
ms.WriteTo(file);
file.Close();
ms.Close();
*/


//BM.Save()
//Graphics GH = Graphics.FromImage(BM as Image);


//GH.CopyFromScreen(0, 0, 0, 0, BM.Size);
//GH.Save()
//ScreenShot SI = new ScreenShot();

//SI.ShowDialog(); ;



/*//Преобразование изображения в строку
public string ImgToStr(string filename)
{
MemoryStream Memostr = new MemoryStream();
Image Img = Image.FromFile(filename);
Img.Save(Memostr, Img.RawFormat);
byte[] arrayimg = Memostr.ToArray();
return Convert.ToBase64String(arrayimg);
}

//Преобразование строки в изображение
public Image StrToImg(string StrImg)
{
byte[] arrayimg = Convert.FromBase64String(StrImg);
Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
return imageStr;
}*/

//=========================================================================================
/*public static void SendErrorToServer2(string errorMes, string additionalInfo)
{
    try
    {
        string paramValue1 = "";
        string paramValue2 = "";
        string paramValue3 = "";

        //Если чтение параметра неудачное, то ничего не делаем.
        if (!sys.ParamLoad("Remote", Var.UserID , "SaveError", true, "User", out paramValue1, out paramValue2, out paramValue3)) return;
        paramValue1 = paramValue1.Replace("SaveError=", "");
        paramValue2 = paramValue2.Replace("SaveScreenshot=", "");
        paramValue3 = paramValue3.Replace("CompressRatio=", "");
        //В ParamValue1 находится значение true/false: Сохранять ошибку на сервере или нет. Пример: SaveError=true
        //В ParamValue2 находится значение true/false: Сохранять текст ошибки на сервере или нет. Пример: SaveScreenshot=true
        //В ParamValue3 находится значение степени сжатия скриншота. По умолчанию формат JPEG, степень сжатия 90. Пример: CompressRatio=90        
        if (!paramValue1.ToBool()) return;
        int compressRatio = paramValue3.ToInt();
        string imagebase64 = "";
        string screenshoFormat = "";
        string screenshotWidth = "";
        string screenshotHeight = "";
        if (paramValue2.ToBool())
        {
            //Настройки сжатия                
            EncoderParameters enc_param1 = new EncoderParameters()
            {
                Param = new EncoderParameter[]
                   {
                                    new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L - compressRatio)
                   }
            };

            //Получение скриншота
            screenshoFormat = "JPEG";
            screenshotWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            screenshotHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            printscreen.Save(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6.jpeg", ImageCodecInfo.GetImageEncoders()[1], enc_param1);


            MemoryStream ms = new MemoryStream();
            printscreen.Save(ms, ImageCodecInfo.GetImageEncoders()[1], enc_param1);
            byte[] arrayimg = ms.ToArray();

            //Test JPG to WebP in lossly mode. Using encode in memory
            byte[] webpImageData2;
            //Bitmap bmp4 = new Bitmap("test.jpg");
            WebP.EncodeLossly(printscreen, 3, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-3.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 5, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-5.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 10, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-10.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 15, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-15.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 20, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-20.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 30, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-30.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 40, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-40.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 50, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-50.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 60, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-60.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 70, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-70.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 80, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-80.webp", webpImageData2);

            WebP.EncodeLossly(printscreen, 90, out webpImageData2);
            File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-90.webp", webpImageData2);

            //imagebase64 = Convert.ToBase64String(arrayimg);

        }

        additionalInfo = sys.AddRightCR(additionalInfo);
        additionalInfo += GetSystemInfo();
        string sql = "INSERT INTO fbaError (EntityID, UserID, ErrorTime, ErrorText, ScreenshotFormat, ScreenshotWidth, ScreenshotHeight, CompressRatio, AdditionalInfo, ScreenshotData) VALUES (" + Var.CR +
                     "123, " + Var.UserID  + "," + sys.DateTimeCurrent() + ",'" + errorMes + "','" + screenshoFormat + "','" + screenshotWidth + "','" + screenshotHeight + "','" + compressRatio.ToString() + "','" + additionalInfo + "','" + imagebase64 + "')";

        sys.Exec(DirectionQuery.Remote, sql);
    }
    catch
    {
        //Ошибку не выдаем.
    }
}*/
//=========================================================================================
/*

// Послать ошибку на сервер.
// </summary>
// <param name="errorMes">Текст ошибки</param>
// <param name="additionalInfo">Дополнительная информация</param>
public static void SendErrorToServer(string errorMes, string additionalInfo)
{
    try
    {
        string paramValue1 = "";
        string paramValue2 = "";
        string paramValue3 = "";

        //Если чтение параметра неудачное, то ничего не делаем.
        if (!sys.ParamLoad("Remote", Var.UserID , "SaveError", true, "User", out paramValue1, out paramValue2, out paramValue3)) return;
        paramValue1 = paramValue1.Replace("SaveError=", "");
        paramValue2 = paramValue2.Replace("SaveScreenshot=", "");
        paramValue3 = paramValue3.Replace("CompressRatio=", "");
        //В ParamValue1 находится значение true/false: Сохранять ошибку на сервере или нет. Пример: SaveError=true
        //В ParamValue2 находится значение true/false: Сохранять текст ошибки на сервере или нет. Пример: SaveScreenshot=true
        //В ParamValue3 находится значение степени сжатия скриншота. По умолчанию формат JPEG, степень сжатия 90. Пример: CompressRatio=90        
        if (!paramValue1.ToBool()) return;
        int compressRatio = paramValue3.ToInt();
        string imagebase64 = "";
        string screenshoFormat = "";
        string screenshotWidth = "";
        string screenshotHeight = "";
        if (paramValue2.ToBool())
        {
            //Настройки сжатия                
            EncoderParameters enc_param1 = new EncoderParameters()
            {
                Param = new EncoderParameter[]
                   {
                                    new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L - compressRatio)
                   }
            };

            //Получение скриншота
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            MemoryStream ms = new MemoryStream();
            printscreen.Save(ms, ImageCodecInfo.GetImageEncoders()[1], enc_param1);
            byte[] arrayimg = ms.ToArray();
            imagebase64 = Convert.ToBase64String(arrayimg);
            screenshoFormat = "JPEG";
            screenshotWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            screenshotHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
        }

        additionalInfo = sys.AddRightCR(additionalInfo);
        additionalInfo += GetSystemInfo();
        string sql = "INSERT INTO fbaError (EntityID, UserID, ErrorTime, ErrorText, ScreenshotFormat, ScreenshotWidth, ScreenshotHeight, CompressRatio, AdditionalInfo, ScreenshotData) VALUES (" + Var.CR +
                     "123, " + Var.UserID  + "," + sys.DateTimeCurrent() + ",'" + errorMes + "','" + screenshoFormat + "','" + screenshotWidth + "','" + screenshotHeight + "','" + compressRatio.ToString() + "','" + additionalInfo + "','" + imagebase64 + "')";

        sys.Exec(DirectionQuery.Remote, sql);
    }
    catch
    {
        //Ошибку не выдаем.
    }
}
*/
//=========================================================================================
/*
  // <summary>
        // Послать ошибку на сервер.
        // </summary>
        // <param name="errorMes">Текст ошибки</param>
        // <param name="additionalInfo">Дополнительная информация</param>
        public static void SendErrorToServer(string errorMes, string additionalInfo)
        {
            try
            {
                string paramValue1 = "";
                string paramValue2 = "";
                string paramValue3 = "";

                //Если чтение параметра неудачное, то ничего не делаем.
                if (!sys.ParamLoad("Remote", Var.UserID , "SaveError", true, "User", out paramValue1, out paramValue2, out paramValue3)) return;
                paramValue1 = paramValue1.Replace("SaveError=", "");
                paramValue2 = paramValue2.Replace("SaveScreenshot=", "");
                paramValue3 = paramValue3.Replace("CompressRatio=", "");
                //В ParamValue1 находится значение true/false: Сохранять ошибку на сервере или нет. Пример: SaveError=true
                //В ParamValue2 находится значение true/false: Сохранять текст ошибки на сервере или нет. Пример: SaveScreenshot=true
                //В ParamValue3 находится значение степени сжатия скриншота. По умолчанию формат JPEG, степень сжатия 90. Пример: CompressRatio=90        
                if (!paramValue1.ToBool()) return;
                int compressRatio = paramValue3.ToInt();
                string imagebase64 = "";
                string screenshoFormat = "";
                string screenshotWidth = "";
                string screenshotHeight = "";
                if (paramValue2.ToBool())
                {                 
                    //Получение скриншота
                    screenshoFormat = "JPEG";
                    screenshotWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
                    screenshotHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
                    Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Graphics graphics = Graphics.FromImage(printscreen as Image);
                    graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

                    //printscreen.Save(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6.jpeg", ImageCodecInfo.GetImageEncoders()[1], enc_param1);

                    //MemoryStream ms = new MemoryStream();
                    //printscreen.Save(ms, ImageCodecInfo.GetImageEncoders()[1], enc_param1);
                    //byte[] arrayimg = ms.ToArray();

                    //Test JPG to WebP in lossly mode. Using encode in memory
                    byte[] webpImageData;
                    //Bitmap bmp4 = new Bitmap("test.jpg");
                    WebP.EncodeLossly(printscreen, 3, out webpImageData);
                    imagebase64 = Convert.ToBase64String(webpImageData);
                    //File.WriteAllBytes(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Дизайнер C# SD\sys\bin\Debug\Bin\file6-3.webp", webpImageData2);
                    //imagebase64 = Convert.ToBase64String(arrayimg);

                }

                additionalInfo = sys.AddRightCR(additionalInfo);
                additionalInfo += GetSystemInfo();
                string sql = "INSERT INTO fbaError (EntityID, UserID, ErrorTime, ErrorText, ScreenshotFormat, ScreenshotWidth, ScreenshotHeight, CompressRatio, AdditionalInfo, ScreenshotData) VALUES (" + Var.CR +
                             "123, " + Var.UserID  + "," + sys.DateTimeCurrent() + ",'" + errorMes + "','" + screenshoFormat + "','" + screenshotWidth + "','" + screenshotHeight + "','" + compressRatio.ToString() + "','" + additionalInfo + "','" + imagebase64 + "')";

                sys.Exec(DirectionQuery.Remote, sql);
            }
            catch
            {
                //Ошибку не выдаем.
            }
        }
 */
//=========================================================================================

//public static Image StringToImage(string imagebase64)
//{
//    byte[] arrayimg = Convert.FromBase64String(imagebase64);
//    Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
//    return imageStr;
//}

//=========================================================================================

// <summary>
// Сохранение файла BMP в файл JPEG. Не используется.
// </summary>
// <param name="FileName">Имя файла BMP</param>
// <param name="FileNameNew">Имя файла JPEG куда будет записано изображение</param>
// <param name="CompressRatio">Степень сжатия 1..100</param>
/*static void ImageCompressToJPEG(string FileName, string FileNameNew, long CompressRatio = 80)
{
EncoderParameters enc_param = new EncoderParameters()
    {
        Param = new EncoderParameter[]
        {
            new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L - 51)
        }
    };
    using (Bitmap bmp = new Bitmap(FileName))
{
    bmp.Save(FileNameNew, ImageCodecInfo.GetImageEncoders()[1], enc_param);
}
//var Img_old = new Bitmap("pic.jpg");
//Img_old.Save("pic.png", ImageFormat.Jpeg);
}*/
//=========================================================================================
  //Views         
            /*viewRows.Border = cellBorder;
                         
            //ColumnHeader view
            backHeader.BackColor = ColorTableHeaderBack; 
                 
            viewHeader.Border     = cellBorder;
            viewHeader.Background = backHeader;           
            viewHeader.ForeColor  = ColorTableHeaderFont;      
            viewHeader.Font       = FontTableHeader; 
            viewHeader.WordWrap   = true;
            */
//=========================================================================================
       //var prop = GetType().GetProperties();

                //string set = "Objects";
                //C1 obj = new C1();
                //obj.Init();



                //PropertyInfo prop = obj.GetType().GetProperty(set);
                //Object obg = prop.GetValue(obj, null);
                //на следующей строке сплывает ошибка при работе (Индекс находился вне границ массива.)
                //String idx = ((DefaultMemberAttribute)obg.GetType().GetCustomAttributes(typeof(DefaultMemberAttribute), true)[0]).MemberName;
                //PropertyInfo pi2 = obg.GetType().GetProperty(idx);
                //Object value = pi2.GetValue(obg, new Object[] { 0 });

                //this.Controls["textBox" +i].Text = ""какое-то твоё выражение";

                //Type t = GetType();
                

                //var p = prop.FirstOrDefault(x => x.Name == "Obj");
                //if (p == null) sys.SM("Не найдено!");
                //else
                //{
                //    Object obj = p.GetValue(this, null);
                //    sys.SM(obj.GetType().ToString());
                //}
                //if (p == null)
                //    return null;
                //return p.GetValue(this, null);
//=========================================================================================
 /*private void button1_Click(object sender, EventArgs e)
        {
            
            var Arr1 = new string[2,10];
            var Arr2 = new string[3,10];
                                   
            //Добавляем первый массив в результат.
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 10; j++)
                    Arr1[i, j] = "A_" +(i.ToString() + "_" + j.ToString());
            
            //Добавляем первый массив в результат.
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 10; j++)
                    Arr2[i, j] = "B_" +(i.ToString() + "_" + j.ToString());
            
            
            string[,] ArrResult;
            sys.ArrayView("AttrTable", "Value", Arr1);
                                              
            sys.ArrayConcat(Arr1, Arr2, out ArrResult);
            sys.ArrayView("AttrTable", "Value", ArrResult);                                                                           
        }
*/
//=========================================================================================
/*	 private void button2_Click(object sender, EventArgs e)
        {
            string s = "'30.09.2015'";
            bool ResultConvert;
            string s2 = s.ParserConvertDate4Server10(true, false, out ResultConvert);
        }
        */
 //========================================================================================
 /*
using System.Collections.Generic;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using Npgsql;
using System.Data.SQLite;

using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Collections;
//using Microsoft.Office.Interop.Excel; //Для экспорта в Excel
using System.Runtime.InteropServices; //Для экспорта в Excel
using System.Text.RegularExpressions;
//using FastColoredTextBoxNS;
//using Npgsql.BulkCopy;
//using Npgsql.BulkCopy.Native;
//using Npgsql.BulkCopy.Native.Versions;      
using System.Net;
using System.Net.Sockets;
using FastColoredTextBoxNS;
using System.Diagnostics;
//using SourceGrid;  
using Ionic.Zip;

class Program
{
    private static void Main(string[] args)
    {
        //int x = 7;
        //int y = 25;
        //Swap<int>(ref x, ref y);
        //Console.WriteLine($"x={x}    y={y}");   // x=25   y=7

        //string s1 = "hello";
        //string s2 = "bye";
        //Swap<string>(ref s1, ref s2);
        //Console.WriteLine($"s1={s1}    s2={s2}"); // s1=bye   s2=hello

        //Console.Read();
    }
    public static void Swap<T>(ref T x)
    {
        //T temp = x;
        //x = y;
        //y = temp;
        //(temp as int).ToString();
        //type T = temp.GetType();

        //Type tp1 = x.GetType();
        //if (tp1.Name == "TextBox") (x as System.Windows.Forms.TextBox).Text = "yuiouio"; //File.ReadAllText(FileName, System.Text.Encoding.Default);
        //if (tp1.Name == "FastColoredTextBox") (x as FastColoredTextBoxNS.FastColoredTextBox).Text = "yuiouio"; //File.ReadAllText(FileName, System.Text.Encoding.Default);
        //if (tp1.Name == "ListBox")
        //Type tp2 = (System.Windows.Forms.TextBox)x.GetType();
        //(x as FastColoredTextBoxNS.FastColoredTextBox).

    }

   
    public class GenericList<T>
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        // constructor
        public GenericList()
        {
            head = null;
        }

        // T as method parameter type:
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
} 
 
 */	
 //========================================================================================
/* Переделка модулей для Согласия.  Согласие.
	private void Button1Click(object sender, EventArgs e)
		{
			int n = 23 - 23;
			int i = 23 / n;
			//sys.SM("test");
			string folder1 = @"D:\000_Тravin\Объекты БД\Модули";
			string folder2 = @"D:\000_Тravin\Объекты БД\Модули переделанные\";
			string [] fileEntries = Directory.GetFiles(folder1);   // получаешь список файлов в каталоге targetDirectory
			progressBar1.Maximum = fileEntries.Count();
			int pos = 0;
			foreach(string fileName in fileEntries)
	        {
				try
				{
					// здесь открываешь и считываешь файл fileName
					//Загрузка текстового файла в ResultText. В LinesCount количество строк в файле. 
					string resultText;
					int linesCount;
					if (!sys.FileReadText(fileName, true, out resultText, out linesCount)) continue;
					int p = resultText.IndexOf("{$DEFINE NEWSCRIPTMODE}");
					if (p > -1) continue;
					p = resultText.IndexOf("unit");
					string resultText2 = resultText.Insert(p, @"{$DEFINE NEWSCRIPTMODE} " + Var.CR);							
					string fileNamesave = folder2 + Path.GetFileName(fileName);
					resultText2.SaveToFile(fileNamesave, true);
				} catch
				{
					
				}
				
				pos++;
				progressBar1.Value = pos;
				
			}
			progressBar1.Value = 0;
			sys.SM("Готово!", MessageType.Information);
		}
		*/
 //========================================================================================
/*
 *          private void buttonFBA1_Click(object sender, EventArgs e)
         {
             //DataTable DT;
             // string SQL = "SELECT dfghdfg dfg dgf dgf";
             //sys.SelectDT(DirectionQuery.Remote, SQL, out DT);
             //var rep1 = new SysReportXLSX("");
             //rep1.WriteXLSX();
         }

         private void buttonFBA2_Click(object sender, EventArgs e)
         {
             //var rep1 = new SysReportXLSX("");
             //rep1.ReadXLSX();
         }

         private void button1_Click(object sender, EventArgs e)
         {
             //{ Merge: 1, 0; ColWidth: 50; RowHeight: 100; FontColor: 11; CellBold: 1; }



             //var rep1 = new SysReportXLSX("");
             //string Value = "asdfghj{ Merge: 1, 0; ColWidth: 50; RowHeight: 100; FontColor: 11; CellBold: 1;}";
             //string TextCell;
             //string FormatCell;
             //rep1.GetFormatCellString(Value, out TextCell, out FormatCell);
             //string[] FormatArray = FormatCell.Split(';');

             //Возвращение параметров 
             //string Param1;
             //string Param2;
             //rep1.GetParam(FormatArray, "Merge", out Param1, out Param2);
             //sys.SM("Merge. Param1:" + Param1 + Var.CR + "Param2:" + Param2);

             //rep1.GetParam(FormatArray, "RowHeight", out Param1, out Param2);
             //sys.SM("RowHeight. Param1:" + Param1 + Var.CR + "Param2:" + Param2);
 */ 
 //========================================================================================
/*
 * //Способ, если процедура сохранения объекта БД. Это способ, если есть процедура сохранения
		//объекта в БД в виде хранимой процедуры spen_save_Object.
		//Процедура spen_save_Object в данный момент сделана только для базы MSSQL.		
        private bool EntityQuery_INSERT_UPDATE_DELETE_DataBase(string Action, string QueryName)
        {                       
            //ShowArray("Ref");
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nTypeAction] != "Entity")  continue;
                if (Ent[i, nQueryName]  != QueryName) continue;
                if (Ent[i, nNeedSave]   == "0")       continue;

                string EntityBrief = Ent[i, nEntityBrief];
                string ObjectID = Ent[i, nObjectID];
                string StateDate = Ent[i, nStateDate];

                string SQL = "";
                int CountAttrDirty = 0;
                for (int j = 0; j < RefCount; j++)
                {
                    if (Ref[j, iQueryName] != QueryName)        continue;
                    if (Ref[j, iEntityBrief] != EntityBrief)    continue;
                    string ValueNew = "";

                    if (Ref[j, iTypeControl] == "ComboBoxFBA")
                    {
                        if (Ref[j, iSaveType] == "LOOKUP")
                        {
                            if (Ref[j, iValueNewID] == "NULL") ValueNew = "'" + Ref[j, iValueNewID] + "'";
                            else if (!sys.IsEmpty(Ref[j, iValueNewID])) ValueNew = Ref[j, iValueNewID];
                            if (Ref[j, iValueOld] == Ref[j, iValueNewID]) continue;
                        }
                        else
                        if (Ref[j, iSaveType] == "INDEX")
                        {
                            if (!sys.IsEmpty(Ref[j, iValueNewID])) ValueNew = Ref[j, iValueNewID];
                            if (Ref[j, iValueOld] == Ref[j, iValueNewID]) continue;
                        }
                        else
                        {
                            ValueNew = "'" + Ref[j, iValueNew] + "'";
                            if (Ref[j, iValueOld] == Ref[j, iValueNew]) continue;
                        }
                    } else
                    if (Ref[j, iTypeControl] == "EditFBA")
                    {
                        if (Ref[j, iSaveType] == "LOOKUP")
                        {
                            if (Ref[j, iValueNewID] == "NULL") ValueNew = "'NULL'";
                            else if (!sys.IsEmpty(Ref[j, iValueNewID])) ValueNew = Ref[j, iValueNewID];
                            else continue;
                            //if (Ref[j, iValueOld] == Ref[j, iValueNewID]) continue;
                        }
                        else
                        if (Ref[j, iSaveType] == "INDEX")
                        {
                            if (!sys.IsEmpty(Ref[j, iValueNewID])) ValueNew = Ref[j, iValueNewID];
                            if (Ref[j, iValueOld] == Ref[j, iValueNewID]) continue;
                        }
                        else
                        {
                            ValueNew = "'" + Ref[j, iValueNew] + "'";
                            if (Ref[j, iValueOld] == Ref[j, iValueNew]) continue;
                        }
                    } else if (Ref[j, iValueOld] == Ref[j, iValueNew]) continue;                      
                    else ValueNew = "'" + Ref[j, iValueNew] + "'";

                    if ((ValueNew != "") && (Ref[j, iNeedSave] == "1"))
                    {
                        SQL = SQL + ",'" + Ref[j, iAttr] + "'," + ValueNew;
                        CountAttrDirty++;
                    }
                }
                if (CountAttrDirty != 0)
                {
                    Ent[i, nUpdate] = "EXEC spen_SaveObject 0, 'UPDATE', " + ObjectID + ",'" + EntityBrief + "','" + StateDate + "'" + SQL;
                    Ent[i, nInsert] = "EXEC spen_SaveObject 0, 'INSERT', " + ObjectID + ",'" + EntityBrief + "','" + StateDate + "'" + SQL;
                    Ent[i, nDelete] = "EXEC spen_SaveObject 0, 'DELETE', " + ObjectID + ",'" + EntityBrief + "'";
                }
            }
            return true;
        }
 * */	
 //========================================================================================	
	              
        /*public static System.Data.DataTable SortArrayTwoDimensions2(string[,] arr, int MaxX, int MaxY, string conditions)
        {
        	//sys.DTView(dt1, "CapForm", "capText");   
			//sys.DTView(dt, "CapForm", "capText");   
			var dt = new DataTable();
        	sys.ArrayToDT(arr, "", out dt, MaxX, MaxY, false);         	
        	//sys.DTView(dt, "CapForm", "capText");
        	conditions = "Column11, Column1 DESC";
        	DataRow[] sortedrows = dt.Select("", conditions);
        	DataTable dt1 = sortedrows.CopyToDataTable();	 
        	return dt1;        
        }*/
	
//========================================================================================	
