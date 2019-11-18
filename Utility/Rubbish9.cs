
/*        
 *        
                             
            
            //bool ButtonFilter,
             //                bool ButtonUpdate,
            //                 bool ButtonAdd,
            //                 bool ButtonEdit,
            //                 bool ButtonDelete,
            //                 bool ButtonSearch,
            //                 bool ButtonCancel,
            //                 bool ButtonOk)        
 *        
 *        void Button6Click(object sender, EventArgs e)
       {   const string ServerNameIN         = "srvname1";
           const string DatabaseLoginDecrypt = "login";
           const string DatabasePassDecrypt  = "12345";
           const string DatabaseNameIN       = "dbtest1";

           string ConStr = "Server=" + ServerNameIN + ";User Id=" + DatabaseLoginDecrypt + ";Password=" + DatabasePassDecrypt + ";Database=" + DatabaseNameIN + ";";
           var connection2 = new System.Data.SqlClient.SqlConnection(ConStr); //Connection Timeout=2;          
           connection2.Open();

           var command = new SqlCommand("SELECT * FROM ServicesRendered;", connection2);

           SqlDataReader reader = command.ExecuteReader();
           if (reader.HasRows)
            {
               // выводим названия столбцов
               //string str1 = string.Format("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
               //var DT = new System.Data.DataTable();
               int NColCount = reader.FieldCount;
               for (int i = 0; i <= NColCount - 1; i++)                                       
               {
                   //DT.Columns.Add(reader.GetName(i));
                   string CName = reader.GetName(i);
                   dataGridView1.Columns.Add(CName, CName);                   
               }

                //foreach (string[] s in data)
                //dataGridView1.Rows.Add(s);
                //dataGridView1.Rows.Add(

               int NRowCount = 0;
                  //reader.GetString 
               //Console.WriteLine();
               //textBox1.Text
                 //List<string[]> data = new List<string[]>();
                     reader.ReadAsync(

               while (reader.Read()) // построчно считываем данные
               {     
                   //object[] ob1;
                   //int i = reader.GetValues(ob1);
                   //reader.

                   /*string word = textBox1.Text;
                   for(int i = 0; i < word.Length;)
                   {
                       object[] p = new object[5];
                       for(int j = 0; j < 5; j++)
                       {
                           if (i < word.Length)
                           {
                               p[j] = word[i];
                               i++;
                           }
                           else
                               break;
                       }
                       DataGridViewRow row = new DataGridViewRow();
                       row.CreateCells(dataGridView1, p);
                       dataGridView1.Rows.Add(row);
                   }*/

//data[data.Count - 1][0] = reader[0].ToString();
// data[data.Count - 1][1] = reader[1].ToString();
//data[data.Count - 1][2] = reader[2].ToString();
//int N = dataGridView1.Rows.Add(1);
//for (int i = 0; i <= NColCount - 1; i++)
// {
//   string s = reader.GetValue(i);
//    dataGridView1.Rows[N].Cells[NColCount].Value = 
//}

/*var p = new object[NColCount];
for (int i = 0; i <= NColCount - 1; i++) p[i] =  reader.GetValue(i);
var row = new DataGridViewRow();
row.CreateCells(dataGridView1, p);
dataGridView1.Rows.Add(row);
*/
//dataGridView1.Rows.Add(ob1);
//for (int i = 0; i <= FCount - 1; i++)
//{
//    string st1 = reader.GetString(i);

//}
//object id = reader.GetValue(0);
//object name = reader.GetValue(1);
//object age = reader.GetValue(2);

//Console.WriteLine("{0} \t{1} \t{2}", id, name, age);]

//Application.DoEvents();
//NRowCount++;
//if (NRowCount == 10) break;

//}
//}
//else
//{
//    sys.SM("No rows found.");
//}

//reader.Close();
// }  





/* Параллельное программирование.
 * IEnumerable<Data> yourData = GetYourData();
var result = yourData.AsParallel() // начинаем обрабатывать параллельно
.Select(d => ComputeMD5(d)) // Вычисляем параллельно
.Where(md5 => IsValid(md5))
.ToArray(); // Возврвщаемся к синхронной модели*/



//Сохранение строку в DataTable в .
/*public static System.Data.DataTable DataTableFromString2(string InputStr)
{                                                               
    string[] Values = InputStr.Split(Convert.ToChar(153));
    string[] mcn = Values[0].Split('|'); //Заголовок таблицы.
    var DT = new  System.Data.DataTable();
    int ColCount = mcn.Length;
    foreach (string header in mcn)
    {
        string[] HeaderAndType = header.Split(':');
        Type type = Type.GetType(HeaderAndType[1]);
        DT.Columns.Add(HeaderAndType[0], type);   
    }

    int RowCount = Values.Length;           
    if (RowCount == 1) return DT;

    var Line1 = new string[ColCount]; //Длины полей.
    var Line2 = new string[ColCount]; //Сами данные в записи.
    //Начинаем со второй строки, т.к. первая - это названия колонок и типы. 
    for (int i = 1; i <= RowCount - 1; i++)
    {
        string s1 = Values[i].Substring(0, Values[i].IndexOf(':')); //Это строка с длинами полей
        Line1 = s1.Split('|');  //Массив длин полей.
        int CapLength = s1.Length + 1;

        for (int j = 0; j <= ColCount - 1; j++)
        {
            int FLen = Line1[j].ToInt();                   
            Line2[j] = Values[i].Substring(CapLength + FLen, FLen);
        }
        DataRow row = DT.NewRow();                                        
        row.ItemArray = Line2;                                                                               
        DT.Rows.Add(row);               
    } 
    return DT;
}*/
/*
   //Сохранение строку в DataSet.
   public static System.Data.DataSet StringToDataSet3(string InputStr)
   {                           

       //103;;
       //002;03;358;;          //Весь DataSet
       //003;01;2;;            //Кол-во таблиц.          
       //004;03;337;           //Все Таблицы в DataSet. Шапки + Данные

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

       //-=Другая таблица=-
       //005;03;119;
       //006;01;1;
       //007;01;2;
       //008;02;86;
       //009;01;2;ID;
       //010;01;2;ID;
       //011;01;5;Int64;;
       //009;01;5;Brief;
       //010;01;5;Brief;
       //011;01;6;String;;;
       //012;02;22;
       //01;1;1;;01;8;Сущность;;;;


       string BlockCode;
       int BlockLen;          
       BlockCode = InputStr.Substring(0, 3); 
       if (BlockCode != "103") return null;

       int Offset      = 3;          
       int DateSetLen  = 0;
       int TablesCount = 0;
       int TablesLen   = 0;
       GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);             
       if (BlockCode != "002") return null;
       DateSetLen = BlockLen;

       GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
       if (BlockCode != "003") return null;
       TablesCount = BlockLen;

       GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
       if (BlockCode != "004") return null; 
       TablesLen = BlockLen; //

       var DS = new System.Data.DataSet();            
       for (int t = 0; t <= TablesCount - 1; t++)  
       {               
            System.Data.DataTable DT;
            DT = GetDataTable(ref Offset, ref InputStr);
            if (DT != null) DS.Tables.Add(DT);
       }

       return DS;

   }

   public static System.Data.DataTable GetDataTable(ref int Offset, ref string InputStr)
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


       string BlockCode;
       int BlockLen;
       var DT = new System.Data.DataTable();

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
       DataTableCap(ref DT, ref Offset, ref InputStr, CountCols);

       GetBlockLen(ref Offset, ref InputStr, out BlockCode, out BlockLen);
       if (BlockCode != "012") return null;
       int TableLen = BlockLen; //Длина таблицы.

       //Наполнение таблицы данными.
       DataTableFill(ref DT, ref Offset, ref InputStr, CountCols, CountRows);
       return DT;
   }

   //Метод создает шапку таблицы из строки Cap.
   public static void DataTableCap(ref System.Data.DataTable DT, ref int Offset, ref string InputStr, int CountCols)
   {

       //009;01;2;ID;          //Шапка. Наим
       //010;01;2;ID;          //Шапка. Поле
       //011;01;5;Int64;;      //Шапка. Тип

       //009;01;5;Brief;
       //010;01;5;Brief;
       //011;01;6;String;;;

       string BlockCode;
       int BlockLen;
       for (int t = 0; t <= CountCols - 1; t++)
       {
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
           DT.Columns.Add(CapField, tp);
           DT.Columns[DT.Columns.Count - 1].Caption = CapName;
       }
   }

   //Метод наполняет DataTable данными.
   public static void DataTableFill(ref System.Data.DataTable DT, ref int Offset, ref string InputStr, int CountCols, int CountRows)
   {
       //01;2;11;
       //;01;4;Сокр;;; //Данные таблицы.
       string[] LineArr = new string[CountCols];
       for (int r = 0; r <= CountRows - 1; r++)
       {
           for (int c = 0; c <= CountCols - 1; c++)
           {
               string d1 = InputStr.Substring(Offset, 2);
               Offset = Offset + 2;
               if (d1 == "00") 
               {
                   LineArr[c] = "";
                   continue;
               }
               if (d1 == "99") continue;
               int Len1 = d1.ToInt();
               int Len2  = InputStr.Substring(Offset, Len1).ToInt();
               Offset = Offset + Len1;
               LineArr[c] = InputStr.Substring(Offset, Len2);
               Offset = Offset + Len2;                    
           }
           DT.Rows.Add(LineArr);
       }
   }              

   //Получить длину параметра.
   public static void GetBlockLen(ref int Offset, 
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

   //Получить значение параметра.
   public static string GetBlockData(ref int Offset, int BlockLen, ref string InputStr)
   {            
       int LocalOffset = Offset;
       Offset = Offset + BlockLen;
       return InputStr.Substring(LocalOffset, BlockLen);           
   }

   //Получить значение параметра для просмотра. Для тестирования.
   public static string GetBlockDataView(ref int Offset, int BlockLen, ref string InputStr)
   {                        
       return InputStr.Substring(Offset, BlockLen);           
   }

   //Сохранение DataSet в строку.
   public static string DataSetToString3(System.Data.DataSet DS)
   {                          
       string sep  = "";
       string sep2 = "";
       //string sep  = ";";
       //string sep2 = "-=Другая таблица=-";

       string Block1 = "103" + sep;  //"Код операции" = 103
       string Block2 = ""; //"Длина DataSet". Описание ниже.

       int CountTables = DS.Tables.Count;
       string Block3 = "003" + sep + CountTables.ToString().Length.ToString("D2") + sep + CountTables.ToString() + sep;

       string Block4 = ""; //Все Таблицы. Шапка + Данные. Описание ниже.

       //Все таблицы в массиве TableArr. Одна страка массива - одна таблица.
       string[] TableArr = new string[CountTables];
       for (int t = 0; t <= CountTables - 1; t++)
       {
          //Block5 - Одна таблица. Шапка + Данные. Описание ниже.

          //Количество строк.
          int CountRows = DS.Tables[t].Rows.Count;                           
          string Block6 = "006" + sep + CountRows.ToString().Length.ToString("D2") + sep + CountRows.ToString() + sep;

          //Количество полей.
          int CountCols = DS.Tables[t].Columns.Count;
          string Block7 = "007" + sep + CountCols.ToString().Length.ToString("D2") + sep + CountCols.ToString() + sep;

          //Шапка таблицы.
          string CapTable = "";
          string[] FieldArr = new string[CountCols];
          for (int c = 0; c <= CountCols - 1; c++)
          {
              string CapName = DS.Tables[t].Columns[c].Caption;
              string ColName = DS.Tables[t].Columns[c].ColumnName;
              string ColType = DS.Tables[t].Columns[c].DataType.ToString().Replace("System.", "");

              string Block9 = "009" + sep + 
                    CapName.Length.ToString().Length.ToString("D2") + sep + CapName.Length + sep + CapName + sep;

              string Block10 = "010" + sep + 
                    ColName.Length.ToString().Length.ToString("D2") + sep + ColName.Length + sep +  ColName + sep;

              string Block11 = "011" + sep + 
                    ColType.Length.ToString().Length.ToString("D2") + sep + ColType.Length + sep +  ColType + sep;

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

          string[] DataArr = new string[CountRows];
          string[] LineArr = new string[CountCols];
          for (int r = 0; r <= CountRows - 1; r++)
          {                    
              for (int c = 0; c <= CountCols - 1; c++)
              {
                  int ValueLen = DS.Tables[t].Rows[r][c].ToString().Length;
                  if (ValueLen == 0) 
                  {
                      LineArr[c] = "00" + sep;
                      continue;
                  }   
                  if (r > 0) 
                  if (DS.Tables[t].Rows[r][c] == DS.Tables[t].Rows[r-1][c])
                  {
                      LineArr[c] = "99" + sep;
                      continue;
                  }                      
                      LineArr[c] = ValueLen.ToString().Length.ToString("D2") + sep + ValueLen + sep + DS.Tables[t].Rows[r][c] + sep;
              }
              DataArr[r] = string.Join(sep, LineArr);
          }

          //Таблица без шапки.
          string TableStr = string.Join(sep, DataArr); 

          //Таблица без шапки.
          string Block12 = "012" + sep + TableStr.Length.ToString().Length.ToString("D2") + sep + TableStr.Length + sep + TableStr + sep;
          int TableLen = TableStr.Length;
          int CapLen   = Block8.Length; 

          //Block2 - Длина DataSet.
          //Block4 - Все Таблицы. 
          //Block5 - Одна таблица (Шапка + Данные).

          string Block5 = "005" + sep + (CapLen + TableLen).ToString().Length.ToString("D2") + sep + (CapLen + TableLen).ToString() + sep + Block6 + Block7 + Block8 + sep + Block12 + sep;
          TableArr[t] = Block5;
       }                         

       if (TableArr.Count() > 1)
       {
           string TableAll = string.Join(sep2, TableArr);           
           Block4 = "004" + sep + TableAll.Length.ToString().Length.ToString("D2") + sep + TableAll.Length + sep + TableAll + sep;
           Block2 = "002"+ sep + (Block3.Length + Block4.Length).ToString().Length.ToString("D2") + sep +
           (Block3.Length + Block4.Length).ToString() + sep;
           return (Block1 + sep + Block2 + sep + Block3 + sep + Block4);
       }
       //Здесь мы избавляемся от JOIN, если таблица всего одна, что возможно даст некоторый выигрыш в скорости, если таблица большая.
       Block4 = "004" + sep + TableArr[0].Length.ToString().Length.ToString("D2") + sep + TableArr[0].Length + sep + TableArr[0] + sep;                       

       Block2 = "002"+ sep + (Block3.Length + Block4.Length).ToString().Length.ToString("D2") + sep + 
           (Block3.Length + Block4.Length).ToString() + sep;
       return (Block1 + sep + Block2 + sep + Block3 + sep + Block4);

       //Формат:
       //Вначале идет код операции - всегда 3 символа. Это означает что операций может быть не более 4096, если в 16-ти ричной системе.             
       //Далее идут блоки. Блок может состоять из трёх частей или из четырёх.
       //Первая часть - код блока.
       //Второая часть всегда две цифры - длина числа, описывающего длину третьей части.

       //Если блок стоит из из 3-х, то значит это какие то данные не более 99 символов в длину.
       //Пример для параметра кол-ва таблиц или числа колонок или числа записей в таблице.
       //Например 99 символов длина числа, описывающего кол-во записей в таблице - вполне достаточно.

       //Если блок состоит из 4-х частей, то 2-я часть - это длина числа, описывающего длину 4-ой части, 
       //3-я часть это длина 4-части, и 4-часть - сами данные.
       //Фактичести это означает, что длина 4-ой части может описываться числом, имеющим не более 99 знаков.
       //Например 1 террабайт - это 13 цифр, а 99 - это уже число галактических масштабов.

       //Одна ячейка таблицы описывается без использования блоков. см. ниже:

       //103   - Значение "Код операции" = 103. 103 Означает передачу DataSet.

       //Описание DataSet.       
       //002   - Тип Данных "Длина DataSet".
       //11    - Кол-во символов, которое занимает атрибут "Длина DataSet"
       //12345678901 - Значение "Длина DataSe".   

       //003   - Тип Данных "Кол-во таблиц".
       //01    - Кол-во символов, которое занимает атрибут "Кол-во таблиц"
       //3     - Значение "Кол-во таблиц".                     

       //004   - Тип Данных "Кол-во байт, которое занимают все таблицы".
       //05    - Кол-во байт, которое занимает атрибут "Кол-во байт, которое занимают все таблицы".                             
       //12345 - "Кол-во байт, которое занимают все таблицы".
       //Описание Таблицы.

       //005   - Тип Данных "Кол-во байт, которое занимает таблица".
       //05    - Кол-во байт, которое занимает атрибут "Кол-во байт, которое занимает таблица"                             
       //12345 - Кол-во байт, которое занимает таблица (вместе с шапкой).

       //006   - Тип Данных "Кол-ва записей в таблице".
       //03    - Кол-во символов, которое занимает атрибут "Кол-во записей в таблице"                      
       //768   - Значение "Кол-во записей в таблице".

       //007   - Тип Данных "Кол-ва полей в таблице".
       //02    - Кол-во байт, которое занимает атрибут "Кол-во полей в таблице"                      
       //10    - Значение "Кол-во полей в таблице".                      

       //008   - Тип Данных "Описание полей таблицы".                                  
       //04    - Кол-во байт, которое занимает атрибут "Описание полей таблицы".
       //1175  - Значение Кол-во байт"Описание полей таблицы".                                   

       //Описание полей таблицы (Название поля, Имя поля, Тип поля).

       //009   - Тип Данных "Длина названия поля".
       //01    - Кол-во байт, которое занимает атрибут "Длина названия поля"                      
       //9     - Значение "Длина названия поля".                      
       //ИДОбъекта - Значение "Название поля". 

       //010   - Тип Данных "Длина имени поля".
       //01    - Кол-во байт, которое занимает атрибут "Длина имени поля"                      
       //2     - Значение "Длина имени поля".                      
       //ID    - Значение "Имя поля".       

       //011   - Тип Данных "Тип поля".
       //01    - Кол-во байт, которое занимает атрибут "Тип поля"                      
       //3     - Значение "Длина типа поля".                      
       //INT   - Значение "Тип поля". 

       //Описание записей таблицы.
       //012   - Тип Данных "Таблицы без шапки".                                  
       //04    - Кол-во байт, которое занимает атрибут "Таблицы без шапки".
       //1175  - Значение "Таблицы без шапки".

       //Описание одной ячейки таблицы. У неё для экономии места нет типа данных.
       //01    - Кол-во байт, которое занимает атрибут "Длина значения ячейки таблицы".                    
       //4     - Значение "Длина значения ячейки таблицы".                  
       //AAAAA - Значение "Ячейки таблицы". 
       //Для экономии места:
       //Если 00, значит NULL или пустая строка, переходим к след. ячейке.  
       //Если 99, значит вставляем значение предыдущей записи этого же поля. 
       //(чтобы не повторять одни и теже данные, 
       //если они повторяются в данном поле в записях идущих подряд).
   }

*/


//Сохранение DataTable в строку.
/*public static string DataTableToString2(System.Data.DataTable DT)
{                                                 
    int ColCount = DT.Columns.Count;                                    
    var mcn = new string[ColCount];
    var md1 = new string[ColCount];
    var md2 = new string[ColCount];
    var rmd = new string[DT.Rows.Count + 1];
    //var sb  = new StringBuilder();

    for (int i = 0; i <= DT.Columns.Count - 1; i++)
        mcn[i] = DT.Columns[i].ColumnName + ":" + DT.Columns[i].DataType.ToString().Replace("System.", "");

    //Имена полей с типами.
    //sb.Append(string.Join("|", mcn));   
    rmd[0] = string.Join("|", mcn);
    int iRow = 1;
    foreach (DataRow dr in DT.Rows)                     
    {                   
        for (int i = 0; i < ColCount; i++)         
        {                                                                    
            md1[i] = dr[i].ToString().Length.ToString();
            md2[i] = dr[i].ToString();
        }               
        rmd[iRow] = string.Join("|", md1) + ":" + string.Join("", md2);
        iRow++;
    }            
    //string cf1 = ((char)65).ToString();
    string splitter = Convert.ToChar(153).ToString();
    //sys.SM("1:" + splitter[0]);
    return string.Join(splitter, rmd);
    //sys.SM("2");
    //return ss;
} */

/*        
//Загрузка DataTable из строки.
public static bool DataTableFromString(out System.Data.DataTable DT, string TableString, out string ErrorMes, bool ErrorShow)
{              
DT       = null;
ErrorMes = "";
try
{ 
    string[] tables  = TableString.Split('\n'); //Каждая таблица - одна строка.                
    string[] rows    = tables[0].Split('~');
    string[] headers = rows[0].Split('|');
    string[] fields  = null;                
    DT = new System.Data.DataTable();               
    var HeaderAndType = new string[2];                 
    foreach (string header in headers) 
    {
        HeaderAndType = header.Split(':');                  
        DT.Columns.Add(HeaderAndType[0]); //Тип поля, который указан здесь пока не используем: HeaderAndType[1]
    }

    for (int i = 1; i < rows.Length; i++)                     
    {
        fields = rows[i].Split('|');
        for (int i1 = 0; i1 < fields.Length; i1++)
        {
            fields[i1] = fields[i1].Replace("$$$", "|").Replace("%%%", Var.CR).Replace("^^^", "#").Replace("&&&", "~");
        }                                       
        DataRow row = DT.NewRow();                                        
        row.ItemArray = fields;                                                                               
        DT.Rows.Add(row);
    }
    return true;


} catch (Exception ex)
{
    ErrorMes  = "Ошибка при конвертировании строки в DataTable: " + Var.CR + ex.Message;
    if (ErrorShow) sys.SM(ErrorMes);
    return false;
}
} 

//Сохранение DataTable в строку.
public static bool DataTableToString(System.Data.DataTable DT, out string TableString, out string ErrorMes, bool ErrorShow)
{                              
string s;
string s2;
var lines = new List<string>();
int iColCount = DT.Columns.Count;               
string[] columnNames = DT.Columns.Cast<DataColumn>().Select(column => column.ColumnName + ":" + column.DataType.ToString().Replace("System.", "")).ToArray();
lines.Add(string.Join("|", columnNames)); 

foreach (DataRow dr in DT.Rows)                     
{
    s2 = "";
    for (int i = 0; i < iColCount; i++)         
    {                                               
        s = dr[i].ToString().Replace("|", "$$$").Replace(Var.CR, "%%%").Replace("#", "^^^").Replace("~", "&&&");
        s2 += s;
        if (i < iColCount - 1) s2 += "|";
    }
    lines.Add(s2);                   
}                               
ErrorMes = "";                
TableString = string.Join("~", lines.ToArray());   
return true;
}

*/



/*public static void Ftest(this string ValueStr, ref string ValueStr2)
{            
ValueStr2 = ValueStr + "WriteXLSX";
//return ValueStr2;
}

public static void aaa()
{
string asd = "kkk";
asd.Ftest(ref asd);
sys.SM(asd);

}*/


//Запись DataTable. В файл.   
/*public static bool DataTableToFile(this System.Data.DataTable DT, string TableName, string FileName, bool ErrorShow)
{                        
    if (File.Exists(FileName))
    {
        try
        {
            File.Delete(FileName);
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
        ndt.DT = DT;
        ndt.TableName = TableName;            
        var jsonFormatter = new DataContractJsonSerializer(typeof(NewDT)); 

        using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
        { 
            jsonFormatter.WriteObject(fs, ndt);
            if (fs != null) fs.Close();
            jsonFormatter = null;
        } 
        return true;                
    }
    catch (Exception e)
    {
        if (ErrorShow) sys.SM(e.Message);
        return false;
    }                                
}*/


//Послать построчно таблицу на клиент.
/*private bool DataSendToClient(string SQL, HttpListenerResponse response)
{               
    var command = new SqlCommand(SQL, connection2);             
    SqlDataReader reader;
    try
    {
        reader = command.ExecuteReader(); 

    } catch (Exception ex)
    {
        AppSendDataToClient("Error: " + ex.Message, response);
        return false;
    }

    int NColCount = reader.FieldCount;
    string FirstRow = "";

    //названия столбцов
    for (int i = 0; i <= NColCount - 1; i++) FirstRow = FirstRow + reader.GetName(i) + "|";                                                
    AppSendDataToClient(FirstRow, response);

    if (!reader.HasRows)
    {
        response.OutputStream.Close();
        reader.Close();
        return true;
    }

    //построчно считываем данные            
    while (reader.Read()) 
    {                                          
        var InsertText = new StringBuilder("", NColCount);
        for (int i = 0; i <= NColCount - 1; i++) InsertText.Append(reader.GetValue(i) + "|");
        AppSendDataToClient(InsertText.ToString(), response);                                           
    }           
    response.OutputStream.Close();         
    reader.Close();
    return true;
}*/

/*
  //Функции получения данных для MSSQL, Postgre, SQLite. Результат в DataGridView.  
        public void SelectAsync(string SQL, DataGridView Grid)
        {
            Query_MSSQL_GV_Async(SQL, Grid).GetAwaiter();        
            
        }
               
        //Функции получения данных для MSSQL, Postgre, SQLite. Результат в DataGridView.  
        public async Task Query_MSSQL_GV_Async(string SQL, DataGridView Grid)
        {                        
            var con2 = new System.Data.SqlClient.SqlConnection(connection2.ConnectionString);                      
            await con2.OpenAsync();
            var command = new SqlCommand(SQL, con2);
            SqlDataReader reader = await command.ExecuteReaderAsync();
                    
            if (reader.HasRows)
            {
                //выводим названия столбцов            
                int NColCount = reader.FieldCount;
                int NRowCount = 0;
                for (int i = 0; i <= NColCount - 1; i++)                                       
                {                                        
                    //var cl = new DataGridViewColumn();
                    //cl.ValueType = Date, DateTime, String, INT, Float
                    //Grid.Columns.Add(cl);
                    string CName = reader.GetName(i);
                    Grid.Columns.Add(CName, CName);                      
                }
            
                while (await reader.ReadAsync())
                {                         
                    var p = new object[NColCount];
                    for (int i = 0; i <= NColCount - 1; i++) p[i] =  reader.GetValue(i);
                    var row = new DataGridViewRow();
                    row.CreateCells(Grid, p);
                    Grid.Rows.Add(row);                 
                    Application.DoEvents();
                    NRowCount++;
                    //Grid.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                }
            
            
            }
            
            reader.Close();
            
        }
        
   //Функции получения данных для MSSQL, Postgre, SQLite. Результат в DataGridView.  
        //public bool SelectGV(string SQL, DataGridView Grid, out System.Data.DataTable DT, ref string ErrorText, bool ErrorShow)
        //{            
        //    bool flag = SelectDT1(SQL, out DT, out ErrorText, ErrorShow);
        //    if (!flag) return false;              
        //    Grid.DataSource = DT;                          
        //    return flag;
        //}
        
 //Сейчас не используется. Запись файла в БД в виде BLOB. 
        public bool SaveBLOBFileToDataBase(string FileName, string TableName, string FieldName, ref string id, ref string ErrorText, bool ErrorShow)
        {
            //Пример использования: 
            //Connection conn = new Connection("SQLite", @"C:\000_Travin\Projects C#\Проба дизайнер С#\111 - перед откатом\bin\Debug\sys1.db3", "", "", "");            
            //String ErrorText;
            //bool flag = true;
            //bool ErrorShow = true;
            //string id = "";
            //conn.SaveFileToDataBase("123.txt", "MyTable", "file", out id, out ErrorText, ErrorShow);
            //
            try
            {
                FileStream fs = null;
                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);  //открываем файл
                var fileBuffer = new byte[fs.Length];
                fs.Read(fileBuffer, 0, (int)fs.Length);        //читаем в бинарный буфер
                fs.Close();
                string SQL = "";
                if ((id == "") || (id == null))         
                {
                    SQL = "INSERT INTO " + TableName + "(" + FieldName + ") VALUES(@file); SELECT last_insert_rowid() AS id; ";
                }
                else
                {
                    SQL = "UPDATE " + TableName + " SET " + FieldName + " = @file WHERE id = " + id +"; ";
                }
                var command3 = new SQLiteCommand(SQL);
                command3.Connection = connection3;
                command3.Parameters.Add("@file", System.Data.DbType.Binary).Value = fileBuffer;
                //Запись файла в БД. Чтение поля id вставленной записи
                SQLiteDataReader dr = command3.ExecuteReader();
                dr.Read();
                if (dr.HasRows) id = dr[0].ToString();                
                dr.Close();
                return true;
            }
            catch (Exception e)
            {
                if (ErrorShow) sys.SM(e.Message
                 ErrorText = ErrorText + Var.CR + e.Message;
                id = "";
                return false;
            }
        }
        
        //Сейчас не используется. Чтение файла из БД из BLOB.  
        public bool ReadBLOBFileFromDataBase(string FileName, string TableName, string FieldName, string Where, ref string ErrorText, bool ErrorShow)
        {   //Пример использования:
            //String ErrorText;
           // bool flag = true;
           //bool ErrorShow = true;
            //Connection conn = new Connection("SQLite", @"C:\000_Travin\Projects C#\Проба дизайнер С#\111 - перед откатом\bin\Debug\sys1.db3", "", "", "");
            //flag = conn.ReadFileFromDataBase("124.txt", "MyTable", "file", " id = 9", out ErrorText, ErrorShow);
            //
            try
            {                  
                string SQL = "SELECT " + FieldName + " FROM " + TableName + " WHERE " + Where + " LIMIT 1; ";
                var command3 = new SQLiteCommand(SQL);
                command3.Connection = connection3;                                         
                //извлекаем файл
                var ms = new MemoryStream((byte[])command3.ExecuteScalar(), false);  // читаем файл
                var fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                ms.WriteTo(fs);
                fs.Close();
                ms.Close();                
                return true;
            }
            catch (Exception e)
            {
                if (ErrorShow) sys.SM(e.Message);
                ErrorText = ErrorText + Var.CR + e.Message;
                return false;
            }
        }
            #region Работа с файлами. Запись/чтение из БД.              
        
        //Сейчас не используется. Чтение файла из БД из кодировки Base64.
        public bool ReadFileFromDataBase64(string FileName, string TableName, string FieldName, string Where)
        {                                                     
            string SQL = "SELECT " + FieldName + " FROM " + TableName + " WHERE " + Where;  
            string FileData = GetValue(SQL);    
            string ErrorMes;
            const bool ShowMes = true;
            return sys.FileWriteFromBase64(FileData, FileName, out ErrorMes, ShowMes);  
        }                                
        
        //Сейчас не используется. Запись файла в БД в кодировке Base64.          
        public bool SaveFileToDataBase64(string FileName, string TableName, string FieldName, ref string ID)
        {                                                 
            string FileData;
            string ErrorMes;
            const bool ShowMes = true;
            if (!sys.FileReadToBase64(FileName, out FileData,  out ErrorMes, ShowMes)) return false;              
            string SQL = "";
            if ((ID == "") || (ID == null) || (ID == "0"))
                SQL = "INSERT INTO " + TableName + " (" + FieldName + ") VALUES('" + FileData + "'); ";                                    
            else               
                SQL = "UPDATE " + TableName + " SET " + FieldName + " = '" + FileData + "' WHERE id = " + ID + "; ";
           
            return Exec(SQL, out ID);                  
        }                                               
          
        #endregion  Работа с файлами. Запись/чтение из БД.
          
     
        //SELECT Version, NumberUpdate FROM fbaUpdate WHERE UserUpdate = 1 AND Version = (SELECT CurrentVersion FROM fbaUpdate LIMIT 1) LIMIT 1;
        //Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataTable. Возвращает только одну таблицу.             
        public bool SelectDT(string SQL, out System.Data.DataTable DT, out string ErrorText, bool ErrorShow)
        {         
           System.Data.DataSet DS;
           bool result;
           result = SelectDS(SQL, out DS, out ErrorText, ErrorShow);  //dtRtn1.Count
           if ((DS == null) || (DS.Tables.Count == 0))
           {              
               DT = null;
               return false;
           }
           DT = DS.Tables[0];
           return result;
        }
        
        //Функция получения данных для MSSQL, Postgre, SQLite для SourceGrid.
        public bool SelectSG(string SQL, FBA.GridFBA DG, out System.Data.DataTable DT)
        {    
            bool Result = SelectDT(SQL, out DT);
            if (!Result) return false;
            var bd = new DevAge.ComponentModel.BoundDataView(DT.DefaultView);           
            DG.DeleteQuestionMessage = null;            
            DG.FixedRows     = 1;
            DG.FixedColumns  = 1;             
            DG.SelectionMode = SourceGrid.GridSelectionMode.Row;                  
            DG.SpecialKeys   = SourceGrid.GridSpecialKeys.Default;
            DG.Selection.EnableMultiSelection = true;
            DG.DataSource    = bd;
            return true;
        }     
        
//Из XML в DataSet.     
            //var settings = new XmlReaderSettings {ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = true, IgnoreComments = true};
            //var xmlReader = XmlReader.Create(new StringReader(Request), settings);
            //xmlReader.Read();  
            //DS = new System.Data.DataSet();
            //DS.ReadXml(xmlReader);  
           
  //Выполнить запрос SQL (INSERT, UPDATE)
        public bool Exec(string SQL, out string ID)
        {   
            if (ServerType == "Postgre") SQL += " RETURNING id; ";                     
            if (ServerType == "MSSQL")    SQL += " select @@IDENTITY AS id";                     
            
           
            if (ServerType == "SQLite")
            {   
                if (SQL.IndexOf("INSERT", StringComparison.OrdinalIgnoreCase) == 0)
                    SQL += "; SELECT last_insert_rowid() AS id; ";
            }                      
            
            ID = "";
            try
            {
                if ((ConnectionDirect) && (ServerType == "Postgre"))
                {                  
                    var command1 = new NpgsqlCommand(SQL);
                    command1.Connection = connection1;                
                    command1.CommandText = SQL;
                    ID = command1.ExecuteNonQuery().ToString();                   
                }
                
                if ((ConnectionDirect) && (ServerType == "MSSQL"))
                {                    
                    var command2 = new SqlCommand(SQL);
                    command2.Connection = connection2;                   
                    command2.CommandText = SQL;
                    ID = command2.ExecuteNonQuery().ToString();                   
                }
                
                if ((ConnectionDirect) && (ServerType == "SQLite"))
                {                     
                    //command3 = new SQLiteCommand(SQL);
                    //command3.Connection = connection3;                   
                    //command3.CommandText = SQL;
                    //ID = command3.ExecuteNonQuery().ToString();  
                    ID = GetValue(SQL);
                }  
                if (!ConnectionDirect)
                {
                    System.Data.DataSet DS;
                    string ErrorMes;
                    if (!AppExec(SQL, out DS, out ErrorMes)) return false; 
                    ID = "0";  
                }    
                return true;
            }
            catch (Exception e)
            {
                string ErrorText = "Ошибка выполнения запроса:" + Var.CR + e.Message + Var.CR + SQL; 
                sys.SM(ErrorText);
                return false;               
            }
        }       
*/
//Это событие возникает когда нужно загрузить новый DLL и его нет в текущей папке.
//Добавить в Program.cs   
//AppDomain currentDomain = AppDomain.CurrentDomain;
//currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);                    
/*private static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
        {
            //Здесь подставляется путь, где искать sys.
            string PathDLL = "";
            string FileName = new AssemblyName(args.Name).Name + ".dll";
            
            //if (sys.Mode)  PathDLL = sys.PathTest + FileName;
            //  else PathDLL = sys.PathWork + FileName; 
            
            PathDLL = sys.PathMain + FileName; 
            if (!File.Exists(PathDLL))
            { 
                sys.SM("Не найден файл DLL: " + PathDLL);
                return null;
            }
            Assembly assembly = Assembly.LoadFrom(PathDLL);
            return assembly;
        }*/


//Удаление выделенного значения из DataGridView.
/*       public static void DGVDelete(DataGridView DGV)
       {   
           //Пример: if (DT2.Rows.Count > 0) DT2.Rows[dgvForm2.SelectedRows[0].Index].Delete();            
           //Удаление из DataTable с поиском:
           //foreach (DataRow r in currdev.Select("Модель='"+listView1.SelectedItems[0].SubItems[1].Text+"'"))
           //    currdev.Rows.Remove(r);
           //dgvForm2.Rows.RemoveAt(dgvForm2.SelectedRows[0].Index); //по индексу строки удаляем
           //dgvForm2.Rows.Remove(DataGridViewRow row) //удаляем по известной строке
           if (DGV.Rows.Count > 0)
           {
               (DGV.DataSource as System.Data.DataTable).Rows[DGV.SelectedRows[0].Index].Delete();
               (DGV.DataSource as System.Data.DataTable).AcceptChanges();
           }
       }  */
/*
  /*public class FormApp
    {
        #region Вся реализация класса FormApp
            
        public string   Name;       //Имя модуля (Формы или DLL)
        public Assembly Asm;        //Сборка
        public Object   Obj;        //Массив всех созданных модулей (форм и DLL) решения.
        public int      FormNumber; //Номер объекта формы, если их несколько. Нумерация с 1.
        
        //Конструктор класса.
        public FormApp(string Name, Assembly Asm, Object Obj, int FormNumber)
        {                                                                                                                               
            this.Name       = Name;
            this.Asm        = Asm;
            this.Obj        = Obj;
            this.FormNumber = FormNumber;
        }
        
        #endregion
    }*/


//public static FormApp[] AsmList;
//public static  List<FormApp> ModuleList = new List<FormApp>{ };

//Поиск загруженной формы. Метод возвращает объект формы. FormNumber экземпляр объекта формы. Нумерация с 1.
//Если FormNumber == 0, то возвращаем первую найденную форму с именем FormName.
/*public static bool FindForm(string FormName, ref int FormNumber, out Object obj)
{                                  
    foreach (FormApp formapp in ModuleList)
    {                
        if ((formapp.Name == FormName) && ((formapp.FormNumber == FormNumber) || (FormNumber == 0)))
        {   
            FormNumber = formapp.FormNumber;
            obj        = formapp.Obj;    
            //asm      = formapp.Asm;                
            return true;                    
        }
    } 
    FormNumber = 0;
    obj = null;
    //asm = null;
    return false;
}

void TextSQL1PaintLine(object sender, PaintLineEventArgs e)
{   //DrawString(string s, Font font, Brush brush, float x, float y);
    //Font font;// = new Font();
    //font = ((FastColoredTextBoxNS.FastColoredTextBox)sender).Font;
    //Brush brush;
    //string txt = ((FastColoredTextBoxNS.FastColoredTextBox)sender).Lines[4];

    //brush = ((FastColoredTextBoxNS.FastColoredTextBox)sender).BackBrush;
    //if (e.LineIndex == 4) e.Graphics.DrawString("dfdf", null, null, 0, 0);


}


private string GetTextCode(string FormName)
{

    //return text.Contains("ERROR") ? LineKind.Error : LineKind.Default;
    //if (Var.enterMode == "Work")
    //FormName = Var.con.GetValue("");

    //Words.
    return "";


                //TextBoxCode.Navigate(ErrorLines[0]);
    //var ErrorLines = new List<int>();
    //ErrorLines = TextBoxError.FindLines(".cs:", );
    //if (ErrorLines.Count > -1) ShowCodeText(ErrorLine
} */



/*
 * void Button6Click(object sender, EventArgs e)
        {   const string ServerNameIN         = "srvtest1";
            const string DatabaseLoginDecrypt = "admin";
            const string DatabasePassDecrypt  = "12345";
            const string DatabaseNameIN       = "dbtest1";
            
            string ConStr = "Server=" + ServerNameIN + ";User Id=" + DatabaseLoginDecrypt + ";Password=" + DatabasePassDecrypt + ";Database=" + DatabaseNameIN + ";";
            var connection2 = new System.Data.SqlClient.SqlConnection(ConStr); //Connection Timeout=2;          
            connection2.Open();
            
            var command = new SqlCommand("SELECT * FROM ServicesRendered;", connection2);
              
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
             {
                // выводим названия столбцов
                //string str1 = string.Format("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                //var DT = new System.Data.DataTable();
                int NColCount = reader.FieldCount;
                for (int i = 0; i <= NColCount - 1; i++)                                       
                {
                    //DT.Columns.Add(reader.GetName(i));
                    string CName = reader.GetName(i);
                    dataGridView1.Columns.Add(CName, CName);                   
                }
                
                 //foreach (string[] s in data)
                 //dataGridView1.Rows.Add(s);
                 //dataGridView1.Rows.Add(
                 //StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt");
                     
                          //outputFile.
                int NRowCount = 0;
                //reader.GetString 
                //Console.WriteLine();
                //textBox1.Text
                //List<string[]> data = new List<string[]>();
                //reader.ReadAsync(
                      
                while (reader.Read()) // построчно считываем данные
                {     
                    //object[] ob1;
                    //int i = reader.GetValues(ob1);
                    //reader.
                    
                    //string word = textBox1.Text;
                    //for(int i = 0; i < word.Length;)
                    //{
                    //    object[] p = new object[5];
                    //    for(int j = 0; j < 5; j++)
                    //    {
                    //        if (i < word.Length)
                    //        {
                    //            p[j] = word[i];
                    //            i++;
                    //        }
                    //        else
                    //            break;
                    //    }
                    //    DataGridViewRow row = new DataGridViewRow();
                    //    row.CreateCells(dataGridView1, p);
                    //    dataGridView1.Rows.Add(row);
                    //}
                                    
                    //data[data.Count - 1][0] = reader[0].ToString();
                    // data[data.Count - 1][1] = reader[1].ToString();
                    //data[data.Count - 1][2] = reader[2].ToString();
                    //int N = dataGridView1.Rows.Add(1);
                    //for (int i = 0; i <= NColCount - 1; i++)
                   // {
                    //   string s = reader.GetValue(i);
                    //    dataGridView1.Rows[N].Cells[NColCount].Value = 
                    //}
                    
                    var p = new object[NColCount];
                    for (int i = 0; i <= NColCount - 1; i++) p[i] =  reader.GetValue(i);
                    var row = new DataGridViewRow();
                    row.CreateCells(dataGridView1, p);
                    dataGridView1.Rows.Add(row);
                    
                    //dataGridView1.Rows.Add(ob1);
                    //for (int i = 0; i <= FCount - 1; i++)
                    //{
                    //    string st1 = reader.GetString(i);
                        
                    //}
                    //object id = reader.GetValue(0);
                    //object name = reader.GetValue(1);
                    //object age = reader.GetValue(2);    
                    //Console.WriteLine("{0} \t{1} \t{2}", id, name, age);]
                    
                    //Application.DoEvents();
                    NRowCount++;
                    //if (NRowCount == 10) break;
                     
                }
            }
            else
            {
                sys.SM("No rows found.");
            }
            
            reader.Close();
        }  */

//    void MyQueryAsync()
//{
//    ReadDataAsync().GetAwaiter();  
//
//}


//ReadDataAsync().GetAwaiter(); 
/*  //MyQueryAsync();
 *  private async Task ReadDataAsync()
{
    //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";        
    const string ServerNameIN         = "srvtest1";
    const string DatabaseLoginDecrypt = "admin";
    const string DatabasePassDecrypt  = "12345";
    const string DatabaseNameIN       = "dbtest1";           
    const string connectionString = "Server=" + ServerNameIN + ";User Id=" + DatabaseLoginDecrypt + ";Password=" + DatabasePassDecrypt + ";Database=" + DatabaseNameIN + ";";                      
    const string sqlExpression = "SELECT * FROM ServicesRendered;";


    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        await connection.OpenAsync();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        if (reader.HasRows)
        {
            // выводим названия столбцов            
            int NColCount = reader.FieldCount;
            int NRowCount = 0;
            for (int i = 0; i <= NColCount - 1; i++)                                       
            {                     
                string CName = reader.GetName(i);
                dataGridView1.Columns.Add(CName, CName);                   
            }

            while (await reader.ReadAsync())
            {                         
                var p = new object[NColCount];
                for (int i = 0; i <= NColCount - 1; i++) p[i] =  reader.GetValue(i);
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView1, p);
                dataGridView1.Rows.Add(row);                 
                Application.DoEvents();
                NRowCount++;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }


        }

        reader.Close();
    }
}*/




/*
 * 
 * 
void Button9Click(object sender, EventArgs e)
{
    //System.Data.DataTable DT1;
    //System.Data.DataTable DT2;
    System.Data.DataSet DS1;
    System.Data.DataSet DS2;
    //Var.conLite.SelectDT1("SELECT * FROM fbaAttr", out DT1);
    //string sq = sys.DataTableToString2(DT1);

    Var.conLite.SelectDS("select * from fbaAttr; select * from fbaEntity; ", out DS1);
    //Var.conLite.SelectDS("select * from fbaAttr; ", out DS1); 
    //Var.conLite.SelectDS("select ID, Brief from fbaAttr WHERE ID = 11 LIMIT 1 ", out DS);              
    //Var.conLite.SelectDS("select ID, Brief from fbaAttr WHERE ID = 11 LIMIT 1 ", out DS1);              
    //Var.conLite.SelectDS("select * from fbaAttr ", out DS1);              

    string sq = sys.DSToStr(DS1);            
    sys.SM(sq);
    //return;
    DS2 = sys.StrToDS(sq);
    dataGridView1.DataSource = DS2.Tables[0];
    dataGridView2.DataSource = DS2.Tables[1];

}


void Button10Click(object sender, EventArgs e)
{
    System.Data.DataTable DT1;
    Var.conLite.SelectDT("select * from fbaAttr ", out DT1); 
    string Block5 = "";
    sys.DTToStr(DT1, ref Block5);

    int Offset = 0;
    DT1 = sys.StrToDT(ref Offset, ref Block5);
    dataGridView1.DataSource = DT1;
    //int Offset = 0;
    //string InputStr = "0080286";
    //string BlockCode = "";
    //int BlockLen = 0;
    //sys.GetBlockLen(ref Offset, 
    //                             ref InputStr, 
    //                             out BlockCode, 
    //                             out BlockLen);
    //sys.SM("BlockCode = " + BlockCode + Var.CR + 
    //       "BlockLen = " + BlockLen);
}
void Button11Click(object sender, EventArgs e)
{
    System.Data.DataTable DT1;
    Var.conLite.SelectDT("select * from fbaAttr ", out DT1);
    string TableName = "111";
    string FileName  = "dt1.txt";
    bool ErrorShow  = true;

    DT1.DTToFile( TableName,  FileName,  ErrorShow);
}
void Button12Click(object sender, EventArgs e)
{
    var DT = new System.Data.DataTable();
    string TableName;
    string FileName = "dt1.txt";
    bool ErrorShow = true;
    sys.DTFromFile(out DT, out TableName, FileName, ErrorShow);
    dataGridView1.DataSource = DT;
}
void Button13Click(object sender, EventArgs e)
{
    System.Data.DataTable DT1;
    Var.conLite.SelectDT("select * from fbaAttr ", out DT1);
    string Block5 = "";
    sys.DTToStr(DT1, ref Block5);
    Block5.SaveToFile("dt2.txt");
}
void Button14Click(object sender, EventArgs e)
{
    //sys.aaa();
}
void FormUtilityShown(object sender, EventArgs e)
{
   // Npgsql.NpgsqlConnection connection45 = new Npgsql.NpgsqlConnection("Server=10.77.70.27;User Id=Postgre;Password=asdzxc;Database=MyProject111111;");
    //connection45.Open();
}
void Button6Click(object sender, EventArgs e)
{

}         * 
 */


/*
 * void Button3Click(object sender, EventArgs e)
{
    //Main23423();
    //XmlSerializer xsSubmit = new XmlSerializer(typeof(System.Windows.Forms.Button));
    //var btn1 = new System.Windows.Forms.Button();
    / var xml = "";

    // using(var sww = new StringWriter())
    // {
    //     using(XmlWriter writer = XmlWriter.Create(sww))
    //     {
    //         xsSubmit.Serialize(writer, btn1);
    //         xml = sww.ToString(); // Your XML
    //     }
    // }
     //sys.SM(xml); 
}*/


/*
  void BtnArrayToStringClick(object sender, EventArgs e)
        {           
            //System.Data.DataTable DT;     //Список сущностей в словарной системе.
            //string[,] ArEntity;            
            //Var.con.SelectDT1("SELECT * FROM fbaEntityParser", out DT);
            //Var.con.SelectDT1("SELECT ID, EntityID, Brief FROM fbaEntityParser", out DT);
            //DT.View("fbaEntityParser", "fbaEntityParser");
            //sys.DataTableToArray(DT, out ArEntity);
            //textBox1.Text = ArEntity.ArrayToString();                       
        }
* /
* 
* 
* /*
* 
*  static void Main23423()
        {
            // объект для сериализации
            Person person = new Person("Tom", 29);
            Console.WriteLine("Объект создан");
    
            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
    
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
               formatter.Serialize(fs, person);
    
               sys.SM("Объект сериализован");
            }
    
            // десериализация
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);
    
                sys.SM("Объект десериализован" + Var.CR + 
                       "Имя: " + newPerson.Name + " + Возраст: " + newPerson.Age);
            }
                
        }
* */
/*
 *  // класс и его члены объявлены как public
        [Serializable]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
     
            // стандартный конструктор без параметров
            public Person()
            { }
     
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        } 
 */
/*
      //HashTest, GUIDTest, FormDLLTest, QueryTest
  if (Operation == "CopyWorkToTest")
       SQL = "UPDATE fbaProject SET " +
        "DateCreateTest   = (CASE WHEN DateCreateTest IS NULL THEN " + sys.DateTimeCurrent() + " ELSE DateCreateTest END), " +
        "UserCreateTestID = (CASE WHEN UserCreateTestID IS NULL THEN " + UserID + " ELSE UserCreateTestID END), " +
        "DateChangeTest   = " + sys.DateTimeCurrent() + ", " +
        "UserChangeTestID = " + UserID + ", " +
        "FormXMLTest      = FormXML,   " +
        "FormCodeTest     = FormCode,  " +
        "CountRowsTest    = CountRows, " +
        "HashTest         = Hash,      " +                    
        "FormDLLTest      = FormDLL,   " +                  
        "TextCodeTest     = TextCode WHERE ID = " + FormID;


   if (Operation == "CopyAsNew")
  {   
      System.Data.DataTable DT1;
      SQL = "SELECT FormXMLTest, FormCodeTest, Name, (select Max(ID) FROM Form) as MaxID FROM fbaProject WHERE ID = " + FormID;                                
      SelectDT(SQL, out DT1);
      string FormXMLTest  = DT1.Rows[0][0].ToString();
      string FormCodeTest = DT1.Rows[0][1].ToString();
      string FormName     = DT1.Rows[0][2].ToString();
      string MaxID        = DT1.Rows[0][3].ToString();
      string NewFormName = FormName + "Copy" + MaxID; 

      FormXMLTest  = FormXMLTest.Replace(">" + FormName + "<", ">" + NewFormName + "<");  
      FormXMLTest  = FormXMLTest.Replace("\"" + FormName + "\"", "\"" + NewFormName + "\"");  
      FormCodeTest = FormCodeTest.Replace("public class " + FormName + " :", "public class " + NewFormName + " :");
      FormCodeTest = FormCodeTest.Replace("public " + FormName + "()", "public " + NewFormName + "()");               
      FormXMLTest  = FormXMLTest.QueryQuote();
      FormCodeTest = FormCodeTest.QueryQuote();

      SQL = "INSERT INTO fbaProject (EntityID, Name, Type, DEL, Block," + 
        "DateCreateTest, DateChangeTest, UserCreateTestID, UserChangeTestID, " + 
        "FormXMLTest, FormCodeTest, TextCodeTest, CountRowsTest, HashTest, FormDLLTest) " + 
        "SELECT EntityID, '" + NewFormName + "', Type, DEL, Block, " + 
        sys.DateTimeCurrent() + ", " + sys.DateTimeCurrent() + ", " + UserID + ", " + UserID + 
        ", '" + FormXMLTest + "', '" + FormCodeTest + "', TextCodeTest, CountRowsTest, HashTest, FormDLLTest FROM fbaProject WHERE ID = " + FormID;
  }*/


//private void FormCopy2(string Operation,  string UserID, string FormID)
//{
//    if (Var.conSys.FormCopyTestToWork(Operation, UserID, FormID) == false) return;
//FormListGridRefresh();
//    //FormHistRefresh();
//}



//Запуск клиента, с указанием стартовой формы.
//private void ClientRun(string FormTypeLocal, string FormName, bool TestMode)
//{
//if (sys.ErrorCheck((FormTypeLocal != "Main"), "Данная форма не являетя главной формой запуска подсистемы!")) return;                                                  
//ConnectionID=21;TestMode=True;FormName=Form9 
//string FileName = "";
//if (!(sys.GetPathClient(out FileName))) return; 
//string Params = @"ConnectionID=" + Var.con.ConnectionID + @";FormName=" + FormName + @";TestMode=" + TestMode.ToString() + ";";
//sys.FileRun(out run, FileName, Params);
//}        



//=====================================

//public static void DoPDF()
//{
//iTextSharp.awt.geom.
//iTextSharp.text.pdf.
//iTextSharp.text.
/*var document = new iTextSharp.text.Document();
using (var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("result.pdf", FileMode.Create)))
{
    document.Open();            
    // do some work here            
    document.Close();
    writer.Close();
}*/

/*var doc = new Document();
//doc.
//var  s = new FileStream(Application.StartupPath + @"\Document.pdf", FileMode.Create, FileAccess.Write);
//PdfWriter.GetInstance(doc, s);
// doc.Open();

Document document = new Document();
PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("result.pdf", FileMode.Create));
//iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/images.jpg");
//jpg.Alignment = Element.ALIGN_CENTER;
//doc.Add(jpg);
PdfPTable table = new PdfPTable(3);
PdfPCell cell = new PdfPCell(new Phrase("Simple table",
 new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
 iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));
cell.BackgroundColor = new BaseColor(Color.Wheat);
cell.Padding = 5;
cell.Colspan = 3;
cell.HorizontalAlignment = Element.ALIGN_CENTER;
table.AddCell(cell);
table.AddCell("Col 1 Row 1");
table.AddCell("Col 2 Row 1");
table.AddCell("Col 3 Row 1");
table.AddCell("Col 1 Row 2");
table.AddCell("Col 2 Row 2");
table.AddCell("Col 3 Row 2");
//jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/left.jpg");
//cell = new PdfPCell(jpg);
cell.Padding = 5;
cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
table.AddCell(cell);
cell = new PdfPCell(new Phrase("Col 2 Row 3"));
cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
table.AddCell(cell);
//jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/right.jpg");
//cell = new PdfPCell(jpg);
cell.Padding = 5;
cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
table.AddCell(cell);
doc.Add(table);
doc.Close();
*/
//}    
//===================        
/*      //Обновить список форм.
      private void RefreshFormList()
      {        
          string SQL = string.Join(Var.CR, this.QueryText);
          System.Data.DataTable DT;
          sys.SelectDT(DirectionQuery.Remote, SQL, out DT);
          //DT.Columns.Add("Path", typeof(string));
          string[] Forms1 = Directory.GetDirectories(sys.PathForms);
          for (int i = 0; i < Forms1.Count(); i++)
          {               
              string FormNameDir = Path.GetFileNameWithoutExtension(Forms1[i]);                   
              bool FindFormIn = false;
              for (int j = 0; j <  DT.Rows.Count; j++)
              {
                  string FormNameDB = sys.DTValue(DT, j, "Name");                
                  if (FormNameDir == FormNameDB)
                  {
                      FindFormIn = true;
                      DT.Rows[j]["ProjectPath"] =  Forms1[i];
                  }
              }
              if (!FindFormIn) 
              {
                  var r1 = new string[DT.Columns.Count]; 
                  r1[1] = FormNameDir;
                  r1[2] = Forms1[i];

                  DT.Rows.Add(r1);
              }

          }    
          dgvForm.DataSource = DT;
          return;
          //DT.Columns.
          //string[] FormsList = null;
          //if (cbShowAllForm.Checked)
          //{
          //    string[] Forms1 = Directory.GetDirectories(sys.PathForms);
          //    FormsList = Forms1;
          //   
          //} else
          //{
          //     string[] Forms2 = {tbFormName.Text};
          //     FormsList = Forms2;
          //}
          //
          //
          // 
          //sys.ArrayToDT(FormsList, "Name", out DT, 0, 0, false);
          //dgvForm.DataSource = DT;
          //dgvForm.Columns[0].Width  = 900;

      }*/
//============================
//Point ptL;
//ptL = new Point(this.Left, this.Top);
//pt.X = 100;
//pt.Y = 100;
//ptS = PointToScreen(ptL);
//============================            

//Событие. Сворачивание формы в трей, при сворачивании формы.
/*protected override void WndProc( ref Message m )
{
    if( m.Msg == 0x0112 ) // WM_SYSCOMMAND
    {
        if( m.WParam == new IntPtr(0xF020)) // SC_MINIMIZE
        {
            if (WindowState != FormWindowState.Minimized) return;
            ShowInTaskbar       = false; 
            notifyIcon1.Visible = true; 
            FormShow    = false;
            Var.ShowMes = false;
        }
        m.Result = new IntPtr(0);
    } 
    base.WndProc( ref m );
}*/
//============================          
//Закрытие соединения.
//private bool ConnectionClose(Connection conLocal)
//{
//    if (conLocal != null)
//     {
//        return conLocal.CloseConnection();
//    }  
//    return true;
//}
//============================  
/* 
        //Процедура для показа сообщения MessageBox.Show(), TypeMessage: Error, Question, Information, или E, Q, I
        //Пример: if (sys.SM("Этот форма уже открыта! Переоткрыть?", MessageType.Question) == false) return;            
        public static bool SM(string MessageStr, 
                              string MessageType = "Error", 
                              string Caption = "",
                              [System.Runtime.CompilerServices.CallerMemberName] string MemberName       = "",
                              [System.Runtime.CompilerServices.CallerFilePath]   string FilePath   = "",
                              [System.Runtime.CompilerServices.CallerLineNumber] int    LineNumber = 0
            )
        {               
            //Если глобальная переменная запрещает вывод сообщений, то выходим.
            if (!Var.ShowMes) return false;
            
            //Если вопрос, то два варианта Yes, No. Результат соответтвенно bool: true, false;
             
            
            if (MessageType == "E") MessageType == "Error";
            if (MessageType == MessageType.Information) MessageType == MessageType.Information;
            if (MessageType == MessageType.Question) MessageType == MessageType.Question;
            
            //MessageBoxIcon   MBI = MessageBoxIcon.Error;
            //MessageBoxButtons MB = MessageBoxButtons.OK;          
            //if ((TypeMessage == "Error")       || (TypeMessage == "E")) MBI = MessageBoxIcon.Error;                  
            //if ((TypeMessage == MessageType.Information) || (TypeMessage == MessageType.Information)) MBI = MessageBoxIcon.Information;
            //if ((TypeMessage == MessageType.Question)    || (TypeMessage == MessageType.Question))
            //{
            //    MBI = MessageBoxIcon.Question;
            //    MB = MessageBoxButtons.YesNo; 
            //}
            if (Caption == "") Caption = MessageType;
            Caption = SystemName + ": " + Caption;
            
            if (MessageType == "Error")
            {
                string FileCS = Path.GetFileName(FilePath);                           
                MessageStr += Var.CR + MemberName + ": " + LineNumber + " File: " + FileCS; 
            }
            
            //if (Str.Length > 100)
            //{
                var FormSM1 = new FormSM(MessageStr, MessageType, Caption);
                FormSM1.ShowDialog();
                return FormSM1.Result;               
            //}
            //else
            //{
           //  MessageBox.Show(
           // "Ошибка!", 
           // "Ошибка", 
           // MessageBoxButtons.OK, 
            //MessageBoxIcon.Warning, 
           // MessageBoxDefaultButton.Button1, 
           // MessageBoxOptions.ServiceNotification);
           
            
            
                //var result = MessageBox.Show(Str, Caption, MB, MBI, MessageBoxDefaultButton.Button1);   //, MessageBoxOptions.ServiceNotification          
                //return (result == DialogResult.Yes);               
            //}
            //MessageBox.Show(Str, Caption, MessageBoxButtons.OK,  MessageBoxIcon.Error);    
            //MessageBoxDefaultButton.Button1, 
            //MessageBoxOptions.DefaultDesktopOnly); 
 
        }
     */
//============================   


//Функция получения данных для MSSQL, Postgre, SQLite. Результат в DataSet. Возвращает несколько таблиц. 
//public static bool SelectDS(string Direction, string SQL, out DataSet DS)
//{
//    string ErrorText = "";
//    const bool ErrorShow = true;
//    return SelectDS(Direction, SQL, out DS, out ErrorText, ErrorShow);
//}
//============================ 
//Запрос к БД. Если нет авторизации, то запрашивается. На выходе одна (первая) таблица.
//public static bool SelectDT(string Direction, string SQL, out System.Data.DataTable DT)
//{
//    System.Data.DataSet DS;
//    DT = null;
//    if (!SelectDS(Direction, SQL, out DS)) return false;
//    DT = DS.Tables[0];
//    return true;
//}

//============================ 
//Обновить данные в гриде.
//public static bool RefreshGrid(string Direction, string SQL, FBA.GridFBA Grid)   
//{                 
//    return SelectSG(Direction, SQL, Grid);
//}
//============================
/* public bool Seertert(string SQL, FBA.GridFBA Grid)
   {
       //Grid.Columns[0,1].View = new SourceGrid.Cells.Views.Cell();
       //SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
      // view.BackColor = Color.Red;
       //потом пройтись по строке с условием и 
     //Grid.GetCell(0,1).View = view;
     //Grid.Selection.
     //((SelectionBase)Grid.Selection).BackColor = Color.FromArgb(50, 174, 201, 251);
       //

       return true;
   }
       */
//============================ 
//Сделать активной форму по FormTag
//private void FormSetActive(string FormTag)
//{                     
//    for (int i = 0; i < Application.OpenForms.Count; i++) 
//    {
//        if (Application.OpenForms[i].Tag == null) continue;
//        if (Application.OpenForms[i].Tag.ToString() != FormTag) continue;
//        Application.OpenForms[i].Show();
//        Application.OpenForms[i].BringToFront();
//    }                
//}                   

//============================ 
//Действие с формой по FormTag: Active, Close, Hide.
/*private void FormSetAction(string FormTag, string ActionName)
{                     
    FormFBA form;
    if (!FormListObjFind(FormTag, out form)) return;
    if (ActionName == "Active")
    {
         form.Show();
         form.BringToFront();
    }
    if (ActionName == "Close")  form.Close();
    if (ActionName == "Hide")  form.Hide();

   */
/*for (int i = 0; i < Application.OpenForms.Count; i++)
{
    if (Application.OpenForms[i].Tag == null) continue;
    if (Application.OpenForms[i].Tag.ToString() != FormTag) continue;

    if (ActionName == "Active") 
    {
        Application.OpenForms[i].Show();
        Application.OpenForms[i].BringToFront();
        return;
    }
    if (ActionName == "Close") 
    {
        Application.OpenForms[i].Close();                   
        return;
    }
    if (ActionName == "Hide") 
    {
        Application.OpenForms[i].Hide();                   
        return;
    }
}*/
// }       
//============================ 
/*  void Button2Click(object sender, EventArgs e)
       {

           //Protector.GetUserConfigurationInfo();
           //sys.SM(Protector.FullMachineInfo);
           //string tx1=Protector.GetMotherBoard_ID();
           //string tx2=Protector.GetProcessor_ID();
           //textBox1.Text = tx1 + Var.CR + tx2;
           //sys.SM(Protector.GetMotherBoard_ID());
           //sys.SM(Protector.GetProcessor_ID());

           //string SQL = "SELECT Version, NumberUpdate FROM fbaUpdate WHERE UserUpdate = 1 AND Version = (SELECT CurrentVersion FROM fbaUpdate LIMIT 1) LIMIT 1;";

           //string SQL = "select Name from fbaRight";
           //System.Data.DataSet DS = new System.Data.DataSet();
           //Var.con.SelectDS(SQL, out DS);
           //dataGridView1.DataSource = DS.Tables[0];
           //string XM = DS.GetXml();
           //sys.SM(XM);

           //System.Data.Common.DbDataAdapter db;

       }


//============================         


       */
/*    
void Button3Click(object sender, EventArgs e)
     {

          //DateTimeToSQLStr1=2017-11-06 33:53.041
          //SQLStrToDateTime=06.11.2017 0:33:53
          //DateTimeToSQLStr2=2017-11-06 33:53.041
          //GetDateTimeNow()=06.11.2017 10:33:53
          //GetDate4FileName=2017-11-06
          //DateTimeStrToMSSQL(DateTime.Now.ToString()=2017-11-06 10:33:53

          /*string str = "";
          string s1 = sys.DateTimeToSQLStr(DateTime.Now);
          str = str + "DateTimeToSQLStr1=" + s1 + Var.CR;                
          DateTime dt1 = sys.SQLStrToDateTime(s1);
          str = str + "SQLStrToDateTime=" + dt1.ToString() + Var.CR;           
          string s2 = sys.DateTimeToSQLStr(dt1);
          str = str + "DateTimeToSQLStr2=" + s2 + Var.CR;            
          string s3 = sys.GetDateTimeNow();
          str = str + "GetDateTimeNow()=" + s3 + Var.CR;   
          string s4 = sys.GetDate4FileName(DateTime.Now);
          str = str + "GetDate4FileName=" + s4 + Var.CR;
          string s5 = sys.DateTimeStrToMSSQL(DateTime.Now.ToString());
          str = str + "DateTimeStrToMSSQL(DateTime.Now.ToString()=" + s5 + Var.CR;    
          sys.SM(str);
         */
//DateTime LimitDateTime = DateTime.Now.AddMinutes(-15);
//sys.SM(LimitDateTime.ToString());
// create compiler
/*CodeDomProvider provider = CSharpCodeProvider.CreateProvider("C#");
CompilerParameters options = new CompilerParameters();
// add more references if needed
options.ReferencedAssemblies.Add("system.dll");
options.GenerateExecutable = false;
options.GenerateInMemory = true;
// compile the code
string source = "using System;namespace Bla {public class Blabla { public static int Test { return 123; }}}";
CompilerResults result = provider.CompileAssemblyFromSource(options, source);
if (!result.Errors.HasErrors)
{
    Assembly assembly = result.CompiledAssembly;
    // instance can be saved and then reused whenever you need to run the code
    var instance = assembly.CreateInstance("Bla.Blabla");
    // running some method
    MethodInfo method = instance.GetType().GetMethod("Test");
    int result2 = (int)method.Invoke("", new object[] {});
    sys.SM(result2.ToString());

} */

//============================
/*
    public static string GetTime()
    {                  
        byte[] ipByte = { 10,77,70,27 };
        IPAddress ip = new IPAddress(ipByte);
        IPEndPoint ep = new IPEndPoint(ip, 13);
        TcpClient tc = new TcpClient();
        tc.Connect(ep);
        Stream st = tc.GetStream();
        StreamReader rdr = new StreamReader(st);
        return rdr.ReadToEnd();
    }

     public static string GetTime2()
    {
        StreamReader rdr = new StreamReader(new TcpClient("10.77.70.27", 13).GetStream());
        return rdr.ReadToEnd();
    }
*/
//============================ 
/*public static string GetNetworkTime()
      {
          const string ntpServer = "ntp.mobatime.ru";   //ntp.mobatime.ru   //pool.ntp.org
          // NTP message size - 16 bytes of the digest (RFC 2030)
          var ntpData = new byte[48];

          //Setting the Leap Indicator, Version Number and Mode values
          ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

          var addresses = Dns.GetHostEntry(ntpServer).AddressList;

          //The UDP port number assigned to NTP is 123
          var ipEndPoint = new IPEndPoint(addresses[0], 123);
          //NTP uses UDP
          using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
          {
              socket.Connect(ipEndPoint);

              //Stops code hang if NTP is blocked
              socket.ReceiveTimeout = 3000;

              socket.Send(ntpData);
              socket.Receive(ntpData);
          }

          //Offset to get to the "Transmit Timestamp" field (time at which the reply 
          //departed the server for the client, in 64-bit timestamp format."
          const byte serverReplyTime = 40;

          //Get the seconds part
          ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

          //Get the seconds fraction
          ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

          //Convert From big-endian to little-endian
          intPart = SwapEndianness(intPart);
          fractPart = SwapEndianness(fractPart);

          var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

          //**UTC** time
          var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

          return networkDateTime.ToLocalTime().ToString();
      }

      // stackoverflow.com/a/3294698/162671
      static uint SwapEndianness(ulong x)
      {
          return (uint)(((x & 0x000000ff) << 24) +
                         ((x & 0x0000ff00) << 8) +
                         ((x & 0x00ff0000) >> 8) +
                         ((x & 0xff000000) >> 24));
      } 

      public static void GetIP(string myHost)
      {
          //IPAddress[] addrs = Dns.GetHostAddresses(Dns.GetHostName("ff"));
          // имя хоста

          //string myHost = System.Net.Dns.GetHostName();
          // IP по имени хоста, выдает список, можно обойти в цикле весь, здесь берется первый адрес
          string compIP = System.Net.Dns.GetHostEntry(myHost).AddressList[0].ToString();

          string userNameWin = System.Environment.UserName;
          string compName = System.Environment.ComputerName;
          sys.SM(compIP);
      }
      void Button4Click(object sender, EventArgs e)  
      {   
        
         // sys.SM(GetTime2());
         sys.SM(GetNetworkTime());
          //https://stackoverflow.com/questions/963760/dataset-getxml-not-returning-null-results/
          /*sys.ConnectLocal();
          var DS1 = new System.Data.DataSet();
          var DS2 = new System.Data.DataSet();
           //DS1.SchemaSerializationMode 
           //DS1.
          string SQL = "select Name from fbaRight ";

          Var.conLite.SelectDS(SQL, out DS1);
          dataGridView1.DataSource = DS1.Tables[0];
          //RecordSet hh;
          SqlDataReader dr = new SqlDataReader();
                    //dr.
          return;
          //DS.
          //DS.GetXml();DataSet selected = debugDisplay.SelectedDataSet;
            //string ds1 = selected.GetXml();
            //CostingDataSet tempDS = new CostingDataSet();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(1000);
            DS1.WriteXml(ms);
            ms.Position = 0;

            DS2.ReadXml(ms);
             dataGridView1.DataSource = DS2.Tables[0];

            var command2 = new SqlCommand(SQL);
                  //command2.Connection = connection2;
                 var da = new SqlDataAdapter(command2);
                 //da  .
                 */
//============================ 
/*string requestUrl = "";
           string username = ""; 
           string password = ""; 
           string requestXml = "";
           //UserDefinedFunctions ws = new UserDefinedFunctions();
           UserDefinedFunctions.fn_ws_call(requestUrl,
                      username, 
                      password, 
                      requestXml);
          */

//============================ 
//if ((ConnectionDirect) && (ServerType == "Postgre"))
//                {                      
//                    command1 = new NpgsqlCommand(SQL);
//                    command1.Connection = connection1;            
//                    var da = new NpgsqlDataAdapter(command1);
//                    da.Fill(DS);            
//                }
//
//                if ((ConnectionDirect) && (ServerType == "MSSQL"))
//                {                             
//                    command2 = new SqlCommand(SQL);
//                    command2.Connection = connection2;
//                    var da = new SqlDataAdapter(command2);           
//                    da.Fill(DS);                                   
//                }
//
//                if ((ConnectionDirect) && (ServerType == "SQLite"))
//                {
//                    dtRtn.Clear();
//                    command3 = new SQLiteCommand(SQL);
//                    command3.Connection = connection3; 
//                    var da = new SQLiteDataAdapter(command3);                  
//                    da.Fill(DS);              
//                }
//                
//============================ 
//[DisplayName("FormType"), Description("Form type (Main, DLL, Report)"), Category("FBA")]
//public sys.FormTypeList FormType 
//{        
//    get { return _FormType; }
//    set { _FormType = value; }           
//} 

//============================ 
/* 
 //Общее меню для нескольких проектов. 

 */
//============================ 
//public FormFBA()
//{
/*if (Var.conSys == null)
{

   //Установка соединения с локальной базой SQLIte. Без неё не работаем.
   if  (Var.conLite == null)
   {
       Var.conLite = new Connection(); 
       if (Var.conLite.SetConnectionLocal() == false) return;
   }

   //Форма входа
   if  (Var.conSys == null)
   {
       var FormEnter1 = new FormEnter();
       FormEnter1.ShowDialog();
       FormEnter1.Dispose();  
       //if (FormName == "") FormName = Var.con.UserForm;                         
       //Application.Run(new FormUtility());
   }
}*/
//}
//============================ 
//Когда форма сворачивается, то
//    private void FormFBAResize(object sender, EventArgs e)
//     {
//test = test + Name + ".Resize" + Var.CR;
//            if (!HideEnabled) return;
//            test = test + Name + ".ResizeChanged" + Var.CR;
//            if (this.IsMdiContainer == true) return;
//            if (Var.FormMainObj     == null) return;
//            if (FormGUID == null)            return;
//            if (FormGUID == "")              return;
//            bool FormMinimize = (this.WindowState == FormWindowState.Minimized);
//            if (FormMinimize) 
//            {               
//                if (NumHide % 2 == 0)                   
//                {
//                    this.Hide();
//                    
//                }
//                NumHide++;                 
//            }        
//   }
//============================ 
//Добавить изображение. 
/*private void ImageAddFile()
{                      
    const string Title = "Выбор изображения";
    const string Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла;
    string FileNameFull = "";
    if (!sys.OpenFileName(Title, Filter, ref FileNameFull)) return;

    string FileData     = "";
    string ErrorMes = "";
    string ImageWidth   = "";
    string ImageHeight  = "";                               
    const bool ShowMes = true;
    if (!sys.FileReadToBase64(FileNameFull, out FileData, out ErrorMes, ShowMes)) return;
    string ImageName     = Path.GetFileNameWithoutExtension(FileNameFull);  
    string ImageFileName = Path.GetFileName(FileNameFull); 
    string Format        = Path.GetExtension(ImageFileName);
    try
    {
        var pictureBoxTemp = new FBA.PictureBoxFBA();
        pictureBoxTemp.Load(FileNameFull);
        ImageWidth  = pictureBoxTemp.Image.Width.ToString();
        ImageHeight = pictureBoxTemp.Image.Height.ToString();
        pictureBoxTemp.Image = global::FBA.Resource.no_foto_1;
    } catch (Exception ex)
    {
        sys.SM("Ошибка при открытии изображения: " + FileNameFull + Var.CR + ex.Message);
        return;
    }

    string SQL = "INSERT INTO fbaImage (" +
                 "UserCreateID, DateCreate, Name, " +
                 "FileName, FileNameFull, Image, " +
                 "Width, Height, Format) " +
                 "VALUES (" + Var.UserID  + ", " + sys.DateTimeCurrent() + ",'" + ImageName + "'," +
                 "'" + ImageFileName + "','" + FileNameFull +"','" + FileData +"'," +
                 "'" + ImageWidth + "','" + ImageHeight + "','" + Format + "')";
    if (!sys.Exec(DirectionQuery.Remote, SQL)) return;
    ImageRefresh();
    sys.SM("Изображение успешно загружено!", MessageType.Information);
}*/

//============================ 

/*using (MailMessage message = new MailMessage("admin@yandex.ru", "user@yandex.ru"))
{
    message.Subject = "Новостная рассылка";
    message.Body = "Новости сайта: бла бла бла";
    using (SmtpClient client = new SmtpClient
    {
        EnableSsl = true,
        Host = "smtp.yandex.ru",
        Port = 25,
        Credentials = new NetworkCredential("admin@yandex.ru", "password")
    })
    {
        client.Send(message);
    }
} */
//============================ 

/*public void SendEmail1()
{

    //SendEmailAsync().GetAwaiter();

    SendEmailAsync(this.Body).Start();
}

private static async Task SendEmailAsync(string Body)
{
    MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
    MailAddress to   = new MailAddress("somemail@yandex.ru");
    MailMessage m    = new MailMessage(from, to);
    m.Subject        = "Тест";
    m.IsBodyHtml     = false;
    m.Body           = Body; //"Письмо-тест 2 работы smtp-клиента";
    SmtpClient smtp  = new SmtpClient("smtp.gmail.com", 587);
    smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
    smtp.EnableSsl   = true;              
    m.Attachments.Add(new Attachment("D://temlog.txt"));
    //Var.con.Exec("");
    await smtp.SendMailAsync(m);
    Console.WriteLine("Письмо отправлено");
}
*/
//============================ 
//Работает!
/*void button1_Click(object sender, EventArgs e)
        {
            using (MailMessage message = new MailMessage("A9113311401@yandex.ru", "A9113311401@yandex.ru"))
            {
                message.Subject = "Новостная рассылка";
                message.Body = "Новости сайта: бла бла бла";
                using (SmtpClient client = new SmtpClient
                {
                    EnableSsl = true,
                    Host = "smtp.yandex.ru",
                    Port = 25,
                    Credentials = new NetworkCredential("A9113311401@yandex.ru", "Aa33164633")
                })
                {
                    client.Send(message);
                }
            }
        }
 */
//============================ 

//Запрос ввода строки. Пример вызова: string str = ""; if (!sys.InputText("List", "Input", ref str)) return;
//public static bool InputText(string CapForm, string CapText, ref string ValueText)
//{
//    var frm = new FormText(CapForm, CapText, ValueText);           
//    if (frm.ShowDialog() != DialogResult.OK) return false;
//    ValueText = frm.tbText.Text;
//    return true;
//}
//============================ 
//Кнопки вкладки работы с формами.
/*   private void TbFormRefreshClick(object sender, EventArgs e)
   {                     
       string SenderName = sys.GetSenderName(sender);
       if (SenderName == "tbFormRefresh")
       {
           RefreshFormList();
           return;                
       }                         
       string FileName = sys.DGVSelected(dgvForm, "ProjectPath");           
       string FormName = Path.GetFileNameWithoutExtension(FileName);


       if (FormName == "") FormName = tbFormName.Text;
       if (FormName == "") 
       {
           sys.SM("Не найдена форма для сохраенения!");
           return;
       }
       //Сохранение             
       if ((SenderName == "tbFormSaveAll")     || 
           (SenderName == "tbFormSaveProject") ||
           (SenderName == "tbFormSaveDLL"))
       {   
           //Сохранить все
           if (SenderName == "tbFormSaveAll") 
           {
               SaveProjectAndDLL(FormName);
           }

           //Сохранить проект.
           if (SenderName == "tbFormSaveProject")
           {                            
               if (!sys.ProjectWriteToDataBase(FormName)) return;
               sys.SM("Проект сохранен в базу данных!", MessageType.Information, "Сохранение в БД");
               return;
           }

           //Сохранить sys.
           if (SenderName == "tbFormSaveDLL")
           {                 
               if (!sys.FormWriteToDataBase(FormName)) return;
               sys.SM("Форма сохранена в базу данных!", MessageType.Information, "Сохранение в БД");
               return;
           }  
       }

       //Загрузка
       if ((SenderName == "tbFormLoadAll") ||
           (SenderName == "tbFormLoadProject") ||
           (SenderName == "tbFormLoadDLL"))
       {

           //Загрузка проекта и sys.
           if (SenderName == "tbFormLoadAll")
           {                    
               sys.ProjectReadFromDataBase(FormName, FormName, "", false);
               const bool ForceLoad = true;
               const string EnterMode = "";            
               if (!sys.FormReadFromDataBase(FormName, EnterMode, ForceLoad, out FileName)) return;
               return;
           }

           //Загрузка проекта.
           if (SenderName == "tbFormLoadProject")
           {                      
               sys.ProjectReadFromDataBase(FormName, FormName, "", false);
               return;
           }

           //Загрузка sys.
           if (SenderName == "tbFormLoadDLL")
           {
               const bool ForceLoad = true;
               const string EnterMode = "";            
               if (!sys.FormReadFromDataBase(FormName, EnterMode, ForceLoad, out FileName)) return;
               return;
           }            
       }

   }*/

//============================ 
//Вход в систему. Проверка входа.
/*  public static bool EnterTest(bool WindowsLogin,
                               string ConnectionName,
                               string ServerType, 
                               string ServerName,                                     
                               string DatabaseName,
                               string DatabaseLogin,
                               string DatabasePass,
                               string UserForm,
                               string UserLogin,
                               string UserPass)
  {                                          
      string ErrorMes = "";
      if (ConnectionName == "") ErrorMes = "Не задано имя подключения!";
      if (UserForm       == "") ErrorMes = "Не указана форма для запуска!";
      if (UserLogin      == "") ErrorMes = "Не указан пользователь системы!";
      if ((ServerType == "MSSQL") || (ServerType != "Postgre"))
      {
          if (DatabaseName  == "")  ErrorMes = "Имя базы данных указано неверно!";
          if (DatabaseLogin  == "") ErrorMes = "Логин пользователя базы данных указан неверно!";
      }

      if (ErrorMes != "")
      {
          SM(ErrorMes);
          return false; 
      }

      var conTest    = new Connection();
      var conSysTest = new Connection();
      if (!conTest.ConnectionInit(ServerType, 
                              ServerName,
                              DatabaseLogin, 
                              DatabasePass, 
                              DatabaseName)) return false;                                                        

      //Если подключение напрямую.
      if (conTest.ConnectionDirect)
      {                
          //Если системные таблицы в базе SQLite, то...
          //conSys.ServerType присваивать не нужно.
          if (sys.SystemSysLocal) conSysTest = conLite;
          else conSysTest = conTest;                                                            
      } else
      {
          //Если подключение через сервер приложений.
          conSysTest = conTest;
          if (sys.SystemSysLocal) conSysTest.ServerType = conTest.ServerSys;
      }          

      string UserIDTest = GetUserID(UserLogin, UserPass);
      if (UserIDTest == "") return false;  
      string FormID;
      if (FormExists(UserForm, true, out FormID) == false) return false;

      return true;
  }                
*/
//============================ 
//Не проверяем наличие пользователя в БД, форм, если это подключение сервера приложения.
//SystemName может быть: Client, ServerApp, Utility.
//Не проверяем наличие пользователя в БД, форм, если это подключение ServerApp, Utility.

/*if (SystemName == "ClientApp" || SystemName == "Utility")
{                                            
    UserID = conSys.GetUserID(UserLogin, UserPass);
    if (UserID == "") return false;  
}*/
//UserID = "0";
//if ((SystemName != "Utility") && (conVar.connectionDirect)) UserID = "1";
//if (SystemName  == "ServerApp") UserID = "1";            
//if (UserID == "0") 
//
//if (UserID == "") return false;  
//string FormID;

//if ((SystemName == "ClientApp") && (conSys.FormExists(UserForm, true, out FormID) == false)) return false;                       
//if ((SystemName == "Utility") && (!conVar.connectionDirect) && (!UserIsAdmin)) return false;
//if (UserID == "0") 
//   UserID = GetUserID(UserLogin, UserPass);
//UserIsAdmin = IsAdmin(UserLogin);

//============================ 
/*
 //Тест подключения.
        private void BtnConnectionTestClick(object sender, EventArgs e)
        {                       
            string ConnectionName = tbConnectionName.Text; 
            //string ServerType     = cbType.Text;
            //string ServerName     = tbServerName.Text;             
            //string DatabaseName   = tbDatabaseName.Text;
            //string DatabaseLogin  = Crypto.EncryptAES(tbDatabaseLogin.Text.Replace(AddTextPass, ""));
            //string DatabasePass   = Crypto.EncryptAES(tbDatabasePass.Text.Replace(AddTextPass, ""));
            //string UserForm       = tbUserForm.Text;
            string UserLogin      = tbUserLogin.Text;
            string UserPass       = tbUserPass.Text; //Crypto.EncryptAES(tbUserPass.Text.Replace(AddTextPass, ""));
            //bool   WindowsLogin   = cbWindowsLogin.Checked;*/
//Var.enterMode = "Test";
//if (!sys.Enter(ConnectionName, "TRY", "", UserLogin, UserPass)) return;

/*if (!sys.EnterTest(WindowsLogin,
                   ConnectionName,
                   ServerType, 
                   ServerName,                                     
                   DatabaseName,
                   DatabaseLogin,
                   DatabasePass,
                   UserForm,
                   UserLogin,
                   UserPass                              
                   )) return;
 */
//Environment.UserDomainName                       
// sys.SM("Подключение выполнено успешно!", MessageType.Information, "Подключение к базе данных");          
// }  //
// */ 
//============================ 
/*
 * 
Доброго времени суток!!!
Как проверить, существует-ли пользователь в ActivDirectory?
Добавлено через 20 минут
Разобрался, как получить информацию о пользователе (а там уже всё остальное):
C#Выделить код
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
       string principal = "%username%";

       string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "user", principal);
       string domain = "test.local";
       string[] properties = new string[] { "fullname" };

       DirectoryEntry adRoot = new DirectoryEntry("LDAP://" + domain, @"TEST\admin", "password", AuthenticationTypes.Secure);
       DirectorySearcher searcher = new DirectorySearcher(adRoot);
       searcher.SearchScope = SearchScope.Subtree;
       searcher.ReferralChasing = ReferralChasingOption.All;
       searcher.PropertiesToLoad.AddRange(properties);
       searcher.Filter = filter;

       SearchResult result = searcher.FindOne();
       DirectoryEntry directoryEntry = result.GetDirectoryEntry();

       string displayName = directoryEntry.Properties["displayName"][0].ToString();
       string firstName = directoryEntry.Properties["givenName"][0].ToString();
       string lastName = directoryEntry.Properties["sn"][0].ToString();
       string email = directoryEntry.Properties["mail"][0].ToString();
Добавлено через 19 минут
Теперь появился вопрос: как проверить совпадаю ли введённые логин/пароль в программе с логином/паролем в ActiveDirectory?
Добавлено через 16 минут
Проблему проверки логина/пароля тоже решил:
Необходимо подключить референс System.DirectoryServices.AccountManagement;
C#Выделить код
1
2
3
4
5
       public bool isValidAuth(String Username, String Password)
       {
           PrincipalContext p = new PrincipalContext(ContextType.Domain, Domain);
           return p.ValidateCredentials(Username, Password);
       }
 */
//============================ 
/*    
    public class FilterLineCustom : System.Windows.Forms.TableLayoutPanel
    {                  
        //FilterCount++;
        //FilterCountPnl++;            
        //System.Windows.Forms.TableLayoutPanel Lp = new System.Windows.Forms.TableLayoutPanel();
        System.Windows.Forms.CheckBox cb1 = new System.Windows.Forms.CheckBox();  
        System.Windows.Forms.TextBox  cb2 = new System.Windows.Forms.TextBox();
        FBA.ComboBoxFBAcb3 = new System.Windows.Forms.ComboBox();
        System.Windows.Forms.TextBox  cb4 = new System.Windows.Forms.TextBox();                        
        System.Windows.Forms.Button  btn1 = new System.Windows.Forms.Button();                
        string EntityBrief;
        readonly bool Check;
        
        //Инициализация формы.
        public FilterLineCustom(System.Windows.Forms.Panel pnlFilterCustom, 
                                 int FilterCount,
                                 string EntityBrief,
                                 bool Check,
                                 string param1,
                                 string param2,
                                 string param3,
                                 string param4
                                )
        {             
             pnlFilterCustom.Controls.Add(this);
             this.EntityBrief = EntityBrief;
             this.Check       = Check;
            // 
            // Lp_N1
            // 
            this.ColumnCount = 5;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.Controls.Add(btn1, 4, 0);
            this.Controls.Add(cb4,  3, 0);
            this.Controls.Add(cb3,  2, 0);
            this.Controls.Add(cb2,  1, 0);
            this.Controls.Add(cb1,  0, 0);
            //Lp.Location = new System.Drawing.Point(30, 299);
            //Lp.Location = new System.Drawing.Point(1, FilterHeight);           
            this.Name = "LpN" + FilterCount.ToString();
            this.RowCount = 1;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Size = new System.Drawing.Size(pnlFilterCustom.Width - 10, 34);
            //Lp.TabIndex = 18;
            //this.Dock = System.Windows.Forms.DockStyle.Bottom;
            //Lp.Dock = System.Windows.Forms.DockStyle.Top;
            
            //FilterHeight = Lp.Location.Y + 34;
            // 
            // btn1
            // 
            btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            //btn_N1.Location = new System.Drawing.Point(780, 3);
            btn1.Name = "btnN" + FilterCount.ToString();;
            //btn1.Size = new System.Drawing.Size(25, 28);
            //btn1.TabIndex = 23;
            btn1.Text = "X";
            //btn1.UseVisualStyleBackColor = true;
            btn1.Click += new System.EventHandler(FilterDelete);  
            // 
            // cb4
            // 
            cb4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb4.FormattingEnabled = true;
            //cb4.Location = new System.Drawing.Point(386, 3);
            cb4.Name = "cb4N" + FilterCount.ToString();
            //cb4.Size = new System.Drawing.Size(387, 26);
            //cb4.TabIndex = 26;
            cb4.MouseDoubleClick += FilterInputText;
            cb4.BackColor = System.Drawing.SystemColors.Info;
            if (param4 != "") cb4.Text = param4;
            // 
            // cb3
            // 
            cb3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb3.FormattingEnabled = true;
            //cb3.Location = new System.Drawing.Point(286, 3);
            cb3.Name = "cb3N" + FilterCount.ToString();;
            //cb3.Size = new System.Drawing.Size(94, 26);
            //cb3.TabIndex = 26;               
            cb3.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "<>",
            "IN",
            "NOT IN",
            "BEGIN",
            "END",
            "CONTAIN",
            "NULL",
            "NOT NULL"});
            cb3.SelectedIndex = 0;
            if (param3 != "") cb3.Text = param3;
            cb3.BackColor = System.Drawing.SystemColors.Info;           
            //if (param3 != "") cb3.SelectedIndex = param3.ToInt();
            cb3.TextChanged += cbConditionTextChanged;
            // 
            // cb2
            // 
            cb2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb2.FormattingEnabled = true;
            //cb2.Location = new System.Drawing.Point(24, 3);
            cb2.Name = "cb2N" + FilterCount.ToString();;
            //cb2.Size = new System.Drawing.Size(256, 26);
            //cb2.TabIndex = 26;
            cb2.BackColor = System.Drawing.SystemColors.Info;
            cb2.MouseDoubleClick += FilterInputAttr;
            if (param2 != "") cb2.Text = param2;
            // 
            // cb1
            // 
            cb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            //cb1.Location = new System.Drawing.Point(3, 5);
            cb1.Name = "cb1N" + FilterCount.ToString();;
            //cb1.Size = new System.Drawing.Size(15, 24);
            //cb1.TabIndex = 27;
            cb1.Text = "";
            //cb1.UseVisualStyleBackColor = true;
            cb1.Checked = true;           
            if (param1 != "") cb1.Checked = param1.ToBool();  
            cb1.CheckedChanged += new System.EventHandler(FilterEnabled);                            
        }
        
        //Событие для CheckBox на полоске фильтра.
        private void FilterEnabled(object sender, EventArgs e)
        {            
            string ComponentName = ((System.Windows.Forms.CheckBox)sender).Name;
            //bool cbCheck = ((System.Windows.Forms.CheckBox)sender).Checked;
            string NumLine = ComponentName.Replace("cb1N", ""); //Пример имени: cb1N9 
            EnabledOrDisabledFilterLine(NumLine);                           
        }
        
        //Ввод списка значений при двойном клике на TextBox полоски фильтра.
        private void FilterInputText(object sender, MouseEventArgs e)
        {        
            string Values = ((System.Windows.Forms.TextBox)sender).Text.Replace("'", "").Replace(", ", "");
            if (!sys.InputText("List of values", "Input values", ref Values)) return;
            ((System.Windows.Forms.TextBox)sender).Text = TransformValue(Values);
        }
        
        //Если NULL или NOT NULL, то компонент для ввода значения недоступен.        
        private void cbConditionTextChanged(object sender, EventArgs e)
        {                     
            string ConditionText = ((System.Windows.Forms.ComboBox)sender).Text;
            string NumLine = ((System.Windows.Forms.ComboBox)sender).Name.Replace("cb3N", "");
            EnabledOrDisabledFilterLine(NumLine);             
        }
        
        //Удаление полоски фильтра.
        private void FilterDelete(object sender, EventArgs e)
        {
            string ComponentName = ((System.Windows.Forms.Button)sender).Name;            
            string Num = ComponentName.Replace("btnN", ""); //Пример имени: btnN9
            Control control = this.Controls.Find("LpN" + Num, true).FirstOrDefault();
            control.Dispose();
            //FilterCountPnl--;
        }
        
        //При вводе списка значений добавляются кавычки и запятые.
        private string TransformValue(string Value)
        {
            string[] Values = Value.Split('\n');
            for (int i = 0; i < Values.Count(); i++)
            {                
                if (i < (Values.Count() - 1))
                     Values[i] = "'" + Values[i].Trim() + "', ";
                else Values[i] = "'" + Values[i].Trim() + "'";                 
            }
            return string.Join(Var.CR, Values); 
        }
        //Вставка атрибута.
        private void FilterInputAttr(object sender, MouseEventArgs e)
        {                             
            string AttrBrief = "";
            if (!sys.InputAttr(EntityBrief, ref AttrBrief)) return;
            ((System.Windows.Forms.TextBox)sender).Text = AttrBrief;
        }
        
        //Включить-выключить полоску фильтра.
        private void EnabledOrDisabledFilterLine(string NumLine)
        {                    
            Control control1 = this.Controls.Find("cb1N" + NumLine, true).FirstOrDefault();
            Control control2 = this.Controls.Find("cb2N" + NumLine, true).FirstOrDefault();
            Control control3 = this.Controls.Find("cb3N" + NumLine, true).FirstOrDefault();
            Control control4 = this.Controls.Find("cb4N" + NumLine, true).FirstOrDefault();          
            Control control5 = this.Controls.Find("btnN" + NumLine, true).FirstOrDefault();          
             
            bool Check2 = ((System.Windows.Forms.CheckBox)control1).Checked;            
            control2.Enabled = (Check && Check2);
            control3.Enabled = (Check && Check2);
            
            bool Check3 = true;
            string ConditionText = ((System.Windows.Forms.ComboBox)control3).Text;                                   
            if ((ConditionText == "NULL") || (ConditionText == "NOT NULL")) Check3 = false;
            if (Check && Check2 && Check3) control4.BackColor = System.Drawing.SystemColors.Info;
            else control4.BackColor = System.Drawing.SystemColors.Menu;
            if (Check && Check2) control2.BackColor = System.Drawing.SystemColors.Info;
            else control2.BackColor = System.Drawing.SystemColors.Menu;
            control4.Enabled = (Check && Check2 && Check3);
            control5.Enabled = Check;      
        }               
    }
    */
//============================ 
//Собрать Custom фильтр, в MSQL WHERE.
/*private string GetFilterCustomString()
{                                                
    var Settings  = new string[100, 4];           
    const int NumLine = 0;
    const string SettingCustom = "";
    for (int i = FilterCount; i > 0; i--)
    {
        string N = i.ToString();
        //string SettingLine = "";
        Control control = pnlFilterCustom.Controls.Find("LpN" + N, true).FirstOrDefault();
        if (control == null) continue;
        Control control1 = pnlFilterCustom.Controls.Find("cb1N" + N, true).FirstOrDefault();                                                            
        Control control2 = pnlFilterCustom.Controls.Find("cb2N" + N, true).FirstOrDefault();
        Control control3 = pnlFilterCustom.Controls.Find("cb3N" + N, true).FirstOrDefault();
        Control control4 = pnlFilterCustom.Controls.Find("cb4N" + N, true).FirstOrDefault(); 
        Settings[NumLine, 0] = ((System.Windows.Forms.CheckBox)control1).Checked.ToString();
        Settings[NumLine, 1] = ((System.Windows.Forms.TextBox)control2).Text;
        Settings[NumLine, 2] = ((System.Windows.Forms.ComboBox)control3).Text;
        Settings[NumLine, 3] = ((System.Windows.Forms.TextBox)control4).Text;                         
    }             
    return SettingCustom;
} */
//============================ 
//Lp.ColumnStyles[0].SizeType = SizeType.Absolute; Lp.ColumnStyles[0].Width = 21;  //CheckBox.             
//Lp.ColumnStyles[1].SizeType = SizeType.Percent;  Lp.ColumnStyles[0].Width = 40;  //Param.
//Lp.ColumnStyles[2].SizeType = SizeType.Absolute; Lp.ColumnStyles[0].Width = 100; //Условие.
//Lp.ColumnStyles[3].SizeType = SizeType.Percent;  Lp.ColumnStyles[0].Width = 30;  //Значение 1.
//Lp.ColumnStyles[4].SizeType = SizeType.Absolute; Lp.ColumnStyles[0].Width = 43;  //AND.
//Lp.ColumnStyles[5].SizeType = SizeType.Percent;  Lp.ColumnStyles[0].Width = 30;  //Значение 2.
//Lp.ColumnStyles[6].SizeType = SizeType.Percent;  Lp.ColumnStyles[0].Width = 34;  //Кнопка удалить.

//============================ 
//Table.Controls.Add(new ComboBox { Dock = DockStyle.Fill }, 0, 1);

//============================ 
/*private void FilterAdd2(string param1, string param2, string param3, string param4, string param5)
        {           
            
            //param1 - ChecbBox
            //param2 - Attr
            //param3 - ComboBox Условие: > = < IN ...
            //param4 - Значение 1
            //AND
            //param5 - Значение 2
            //X
            
            FilterCount++;
            FilterCountPnl++;            
            System.Windows.Forms.TableLayoutPanel Lp = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.CheckBox cb1 = new System.Windows.Forms.CheckBox();  
            System.Windows.Forms.TextBox  cb2 = new System.Windows.Forms.TextBox();
            FBA.ComboBoxFBAcb3 = new System.Windows.Forms.ComboBox();
            System.Windows.Forms.TextBox  cb4 = new System.Windows.Forms.TextBox();                        
            System.Windows.Forms.TextBox  cb5 = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Button  btn1 = new System.Windows.Forms.Button();
                         
            // 
            // Lp_N1
            // 
            Lp.ColumnCount = 5;
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            //Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            //Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            Lp.Controls.Add(btn1, 4, 0);
            Lp.Controls.Add(cb4,  3, 0);
            Lp.Controls.Add(cb3,  2, 0);
            Lp.Controls.Add(cb2,  1, 0);
            Lp.Controls.Add(cb1,  0, 0);
            //Lp.Location = new System.Drawing.Point(30, 299);
            //Lp.Location = new System.Drawing.Point(1, FilterHeight);           
            Lp.Name = "LpN" + FilterCount.ToString();
            Lp.RowCount = 1;
            Lp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            Lp.Size = new System.Drawing.Size(panelFilterCustom.Width - 2, 30);
            //Lp.TabIndex = 18;
            Lp.Dock = System.Windows.Forms.DockStyle.Bottom;
            //Lp.Dock = System.Windows.Forms.DockStyle.Top;
            
            //FilterHeight = Lp.Location.Y + 34;
            // 
            // btn1
            // 
            btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            //btn_N1.Location = new System.Drawing.Point(780, 3);
            btn1.Name = "btnN" + FilterCount.ToString();;
            //btn1.Size = new System.Drawing.Size(25, 28);
            //btn1.TabIndex = 23;
            btn1.Text = "X";
            //btn1.UseVisualStyleBackColor = true;
            btn1.Click += new System.EventHandler(FilterDelete);  
            // 
            // cb4
            // 
            cb4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb4.FormattingEnabled = true;
            //cb4.Location = new System.Drawing.Point(386, 3);
            cb4.Name = "cb4N" + FilterCount.ToString();
            //cb4.Size = new System.Drawing.Size(387, 26);
            //cb4.TabIndex = 26;
            cb4.MouseDoubleClick += FilterInputText;
            cb4.BackColor = System.Drawing.SystemColors.Info;
            if (param4 != "") cb4.Text = param4;
            // 
            // cb3
            // 
            cb3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb3.FormattingEnabled = true;
            //cb3.Location = new System.Drawing.Point(286, 3);
            cb3.Name = "cb3N" + FilterCount.ToString();;
            //cb3.Size = new System.Drawing.Size(94, 26);
            //cb3.TabIndex = 26;               
            cb3.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "<>",
            "IN",
            "NOT IN",
            "BEGIN",
            "END",
            "CONTAIN",
            "NULL",
            "NOT NULL"});
            cb3.SelectedIndex = 0;
            if (param3 != "") cb3.Text = param3;
            cb3.BackColor = System.Drawing.SystemColors.Info;           
            //if (param3 != "") cb3.SelectedIndex = param3.ToInt();
            cb3.TextChanged += cbConditionTextChanged;
            // 
            // cb2
            // 
            cb2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb2.FormattingEnabled = true;
            //cb2.Location = new System.Drawing.Point(24, 3);
            cb2.Name = "cb2N" + FilterCount.ToString();;
            //cb2.Size = new System.Drawing.Size(256, 26);
            //cb2.TabIndex = 26;
            cb2.BackColor = System.Drawing.SystemColors.Info;
            cb2.MouseDoubleClick += FilterInputAttr;
            if (param2 != "") cb2.Text = param2;
            // 
            // cb1
            // 
            cb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            //cb1.Location = new System.Drawing.Point(3, 5);
            cb1.Name = "cb1N" + FilterCount.ToString();;
            //cb1.Size = new System.Drawing.Size(15, 24);
            //cb1.TabIndex = 27;
            cb1.Text = "";
            //cb1.UseVisualStyleBackColor = true;
            cb1.Checked = true;           
            if (param1 != "") cb1.Checked = param1.ToBool();  
            cb1.CheckedChanged += new System.EventHandler(FilterEnabled);
            Lp.Parent = panelFilterCustom;
            //pnlFilterCustom.Controls.Add(Lp);
        }*/
//============================ 
//Если NULL или NOT NULL, то компонент для ввода значения недоступен.        
/*        private void cbConditionTextChanged(object sender, EventArgs e)
        {                     
            string ConditionText = ((System.Windows.Forms.ComboBox)sender).Text;
            string NumLine = ((System.Windows.Forms.ComboBox)sender).Name.Replace("cb3N", "");
            EnabledOrDisabledFilterLine(NumLine, cbCustom.Checked);             
        }*/
//============================ 
//Включить-выключить полоску фильтра.
/*     private void EnabledOrDisabledFilterLine(string NumLine, bool Check)
     {                    
         Control control1 = panelFilterCustom.Controls.Find("cb1N" + NumLine, true).FirstOrDefault();
         Control control2 = panelFilterCustom.Controls.Find("cb2N" + NumLine, true).FirstOrDefault();
         Control control3 = panelFilterCustom.Controls.Find("cb3N" + NumLine, true).FirstOrDefault();
         Control control4 = panelFilterCustom.Controls.Find("cb4N" + NumLine, true).FirstOrDefault();          
         Control control5 = panelFilterCustom.Controls.Find("btnN" + NumLine, true).FirstOrDefault();          

         bool Check2 = ((System.Windows.Forms.CheckBox)control1).Checked;            
         control2.Enabled = (Check && Check2);
         control3.Enabled = (Check && Check2);

         bool Check3 = true;
         string ConditionText = ((System.Windows.Forms.ComboBox)control3).Text;                                   
         if ((ConditionText == "NULL") || (ConditionText == "NOT NULL")) Check3 = false;
         if (Check && Check2 && Check3) control4.BackColor = System.Drawing.SystemColors.Info;
         else control4.BackColor = System.Drawing.SystemColors.Menu;
         if (Check && Check2) control2.BackColor = System.Drawing.SystemColors.Info;
         else control2.BackColor = System.Drawing.SystemColors.Menu;
         control4.Enabled = (Check && Check2 && Check3);
         control5.Enabled = Check;      
     }*/
//============================ 
/*
 //Добавление нового фильтра.
        private void FilterAdd(string param1, string param2, string param3, string param4)
        {           
            FilterCount++;
            FilterCountPnl++;            
            System.Windows.Forms.TableLayoutPanel Lp = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.CheckBox cb1 = new System.Windows.Forms.CheckBox();  
            System.Windows.Forms.TextBox  cb2 = new System.Windows.Forms.TextBox();
            FBA.ComboBoxFBAcb3 = new System.Windows.Forms.ComboBox();
            System.Windows.Forms.TextBox  cb4 = new System.Windows.Forms.TextBox();                        
            System.Windows.Forms.Button  btn1 = new System.Windows.Forms.Button();                
                         
            // 
            // Lp_N1
            // 
            Lp.ColumnCount = 5;
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            //Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            //Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            Lp.Controls.Add(btn1, 4, 0);
            Lp.Controls.Add(cb4,  3, 0);
            Lp.Controls.Add(cb3,  2, 0);
            Lp.Controls.Add(cb2,  1, 0);
            Lp.Controls.Add(cb1,  0, 0);
            //Lp.Location = new System.Drawing.Point(30, 299);
            //Lp.Location = new System.Drawing.Point(1, FilterHeight);           
            Lp.Name = "LpN" + FilterCount.ToString();
            Lp.RowCount = 1;
            Lp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            Lp.Size = new System.Drawing.Size(panelFilterCustom.Width - 2, 30);
            //Lp.TabIndex = 18;
            Lp.Dock = System.Windows.Forms.DockStyle.Bottom;
            //Lp.Dock = System.Windows.Forms.DockStyle.Top;
            
            //FilterHeight = Lp.Location.Y + 34;
            // 
            // btn1
            // 
            btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            //btn_N1.Location = new System.Drawing.Point(780, 3);
            btn1.Name = "btnN" + FilterCount.ToString();;
            //btn1.Size = new System.Drawing.Size(25, 28);
            //btn1.TabIndex = 23;
            btn1.Text = "X";
            //btn1.UseVisualStyleBackColor = true;
            btn1.Click += new System.EventHandler(FilterDelete);  
            // 
            // cb4
            // 
            cb4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb4.FormattingEnabled = true;
            //cb4.Location = new System.Drawing.Point(386, 3);
            cb4.Name = "cb4N" + FilterCount.ToString();
            //cb4.Size = new System.Drawing.Size(387, 26);
            //cb4.TabIndex = 26;
            cb4.MouseDoubleClick += FilterInputText;
            cb4.BackColor = System.Drawing.SystemColors.Info;
            if (param4 != "") cb4.Text = param4;
            // 
            // cb3
            // 
            cb3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb3.FormattingEnabled = true;
            //cb3.Location = new System.Drawing.Point(286, 3);
            cb3.Name = "cb3N" + FilterCount.ToString();;
            //cb3.Size = new System.Drawing.Size(94, 26);
            //cb3.TabIndex = 26;               
            cb3.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "<>",
            "IN",
            "NOT IN",
            "BEGIN",
            "END",
            "CONTAIN",
            "NULL",
            "NOT NULL"});
            cb3.SelectedIndex = 0;
            if (param3 != "") cb3.Text = param3;
            cb3.BackColor = System.Drawing.SystemColors.Info;           
            //if (param3 != "") cb3.SelectedIndex = param3.ToInt();
            cb3.TextChanged += cbConditionTextChanged;
            // 
            // cb2
            // 
            cb2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //cb2.FormattingEnabled = true;
            //cb2.Location = new System.Drawing.Point(24, 3);
            cb2.Name = "cb2N" + FilterCount.ToString();;
            //cb2.Size = new System.Drawing.Size(256, 26);
            //cb2.TabIndex = 26;
            cb2.BackColor = System.Drawing.SystemColors.Info;
            cb2.MouseDoubleClick += FilterInputAttr;
            if (param2 != "") cb2.Text = param2;
            // 
            // cb1
            // 
            cb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            //cb1.Location = new System.Drawing.Point(3, 5);
            cb1.Name = "cb1N" + FilterCount.ToString();;
            //cb1.Size = new System.Drawing.Size(15, 24);
            //cb1.TabIndex = 27;
            cb1.Text = "";
            //cb1.UseVisualStyleBackColor = true;
            cb1.Checked = true;           
            if (param1 != "") cb1.Checked = param1.ToBool();  
            cb1.CheckedChanged += new System.EventHandler(FilterEnabled);
            Lp.Parent = panelFilterCustom;
            //pnlFilterCustom.Controls.Add(Lp);
        }
 //Удаление полоски фильтра.
        private void FilterDelete(object sender, EventArgs e)
        {
            string ComponentName = ((System.Windows.Forms.Button)sender).Name;            
            string Num = ComponentName.Replace("btnN", ""); //Пример имени: btnN9
            Control control = panelFilterCustom.Controls.Find("LpN" + Num, true).FirstOrDefault();
            control.Dispose();
            FilterCountPnl--;
        }
/*
 * //Собрать Custom фильтр, в MSQL WHERE.
        private string FilterCustomWHERE()
        {
            if (!cbCustom.Checked) return "";
            string FilterResult = "";           
            string FilterCustomType = " AND ";
            if (cbFilterCustomCondition.SelectedIndex == 1) FilterCustomType = " OR ";
            int FilterNum = 0;
            for (int i = 1; i <= FilterCount; i++)
            {
                string N = i.ToString();
                Control control = panelFilterCustom.Controls.Find("LpN" + N, true).FirstOrDefault();
                if (control == null) continue;
                Control control1 = panelFilterCustom.Controls.Find("cb1N" + N, true).FirstOrDefault();               
                bool Check2 = ((System.Windows.Forms.CheckBox)control1).Checked;
                if (!Check2) continue;
                 
                Control control2 = panelFilterCustom.Controls.Find("cb2N" + N, true).FirstOrDefault();
                Control control3 = panelFilterCustom.Controls.Find("cb3N" + N, true).FirstOrDefault();
                Control control4 = panelFilterCustom.Controls.Find("cb4N" + N, true).FirstOrDefault();          
                string control2Text = ((System.Windows.Forms.TextBox)control2).Text;
                string control3Text = ((System.Windows.Forms.ComboBox)control3).Text;
                string control4Text = ((System.Windows.Forms.TextBox)control4).Text;               
                string FilterLine = "";
                if (control2Text == "") continue;
                FilterNum++;                
                if (control3Text == "IN")
                {                    
                    FilterLine = control2Text + " IN (" + control4Text + ")";
                } else  
                if (control3Text == "NOT IN")
                {                    
                    FilterLine = control2Text + "NOT IN (" + control4Text + ")";
                } else                     
                if (control3Text == "BEGIN")
                {
                    control4Text = control4Text.Replace("'", "");
                    FilterLine = control2Text + " LIKE ('" + control4Text + "%')";
                } else               
                if (control3Text == "END")
                {
                    control4Text = control4Text.Replace("'", "");
                    FilterLine = control2Text + " LIKE ('%" + control4Text + "')";
                } else                
                if (control3Text == "CONTAIN")
                {
                    control4Text = control4Text.Replace("'", "");
                    FilterLine = control2Text + " LIKE ('%" + control4Text + "%')";
                } else                                  
                if (control3Text == "NULL")
                {
                    control4Text = control4Text.Replace("'", "");
                    FilterLine = control2Text + " IS NULL";
                } else                   
                if (control3Text == "NOT NULL")
                {
                    control4Text = control4Text.Replace("'", "");
                    FilterLine = control2Text + " IS NOT NULL";
                } else                    
                {
                   control4Text = control4Text.Replace("'", "");
                   FilterLine = control2Text + " " + control3Text + " " + "'" + control4Text + "'";                   
                }
                
                if (FilterNum == 1) FilterResult = FilterResult + FilterLine; 
                else FilterResult = FilterResult + FilterCustomType + FilterLine;                
            }
            FilterResult = FilterResult + Var.CR;
            return FilterResult;
        }        
        
 */


/*
       //Получение списка запросов для обновления признака Default Setting.
       //private string GetSQLFlextListDefault()
       //{
           //string SQL = string.Format("DELETE FROM fbaFlexUserDefault WHERE FlexListID = {0} AND UserID = {1}", FlexListID, Var.UserID ) +
           //             string.Format("INSERT INTO fbaFlexUserDefault " +
          //                    "(EntityID, FlexListID, UserID) VALUES " +
          //                    "({0},{1},{2})",
          //                    "212", FlexListID, Var.UserID );  
          // return SQL;
       //}

//Создание невидимого компонента, куда будет заприсываться строка фильтра Custom.
       private void FormFilterLoad(object sender, EventArgs e)
       {
           //В этот компонент помемещается весь фильтр Custom. после сохраняется.          
           cbFilterCustom.Name = "cbFilter";
           cbFilterCustom.Visible = false;
           cbFilterCustom.Tag = "SAVE";
           cbFilterCustom.Parent = this;
       }
          //Получение списка запросов для сохранения 
       //таблицы выбранных атрибутов гибкой таблицы.
       private string GetSQLAttrInsert()
       {
           string SQL = "DELETE FROM fbaFlex WHERE FlexListID =" + FlexListID + ";";
           if (dgvFlex.Rows.Count == 0) return SQL;
           var Arr = new string[dgvFlex.Rows.Count];
           for (int i = 0; i < dgvFlex.Rows.Count; i++)
           {
               string AttrName  = sys.DGVRowInt(dgvFlex, i, "AttrName");
               string AttrBrief = sys.DGVRowInt(dgvFlex, i, "AttrBrief");             
               string AttrWidth = sys.DGVRowInt(dgvFlex, i, "AttrWidth"); 
               string AttrMask  = sys.DGVRowInt(dgvFlex, i, "AttrMask"); 
               Arr[i] = string.Format("INSERT INTO fbaFlex (EntityID, FlexListID, " +
                                      "AttrName, AtrBrief, AttrWidth, AttrMask) VALUES (" +
                                      "345, {0},'{1}','{2}','3}','{4}');", 
                                      FlexListID, AttrName, AttrBrief, AttrWidth, AttrMask);
           }
           return SQL + Var.CR + string.Join(Var.CR, Arr);           
       }

 //Список выбранных атрибутов преобразовать
       //в строку для сохранения в таблицу в БД.
       private string GetAttrViewString()
       {
           var ArrAttr = new string[dgvFlex.Rows.Count, 4];
           for (int i = 0; i < dgvFlex.Rows.Count; i++)
           {
               ArrAttr[i, 0] = sys.DGVRowInt(dgvFlex, i, "AttrName");
               ArrAttr[i, 0] = sys.DGVRowInt(dgvFlex, i, "AttrBrief");
               ArrAttr[i, 0] = sys.DGVRowInt(dgvFlex, i, "AttrWidth");
               ArrAttr[i, 0] = sys.DGVRowInt(dgvFlex, i, "AttrMask");               
           }        
           return ArrAttr.ArrayToStr();
       }

private string RestoreAttrVie(string ArrAttrView)
       {
           //string[,] ArrAttr = ArrAttrView.ArrayFromStr();
           //for (int i = 0; i < dgvFlex.Rows.Count; i++)
           //{


           //}
           return "";
       }
//Поднять атрибут вверх в таблице выбранных атрибутов.
       /*private bool AttrUp(int RowIndex)
       {         
           if (RowIndex < 1) return false;           
           DataGridViewRow temprow = dgvFlex.Rows[RowIndex - 1];
           dgvFlex.Rows.Remove(dgvFlex.Rows[RowIndex - 1]);         
           dgvFlex.Rows.Insert(RowIndex, temprow);  
           return true;
       }
       //Опустить атрибут вниз в таблице выбранных атрибутов.
       private bool AttrDown(int RowIndex)
       {
           if (RowIndex == -1) return false;   
           if (RowIndex == dgvFlex.Rows.Count-1) return false;
           DataGridViewRow temprow = dgvFlex.Rows[RowIndex + 1];
           dgvFlex.Rows.Remove(dgvFlex.Rows[RowIndex + 1]);         
           dgvFlex.Rows.Insert(RowIndex, temprow); 
           return true;
       }
//Удаление атрибута.
       /*private bool AttrDel()
       {
           if (dgvFlex.SelectedRows.Count == 0) return false;                      
           var rowsToRemove = new List <object>();
           for (int i = 0; i < dgvFlex.SelectedRows.Count; i++)
               rowsToRemove.Add(dgvFlex.Rows[i]);                     

           foreach(var row in rowsToRemove)
               dgvFlex.Rows.Remove((DataGridViewRow)row);

           return true;  

           //for (int i = 0; i < dgvFlex.SelectedRows; i++) 
           //{
           //    dgvFlex.Rows.Remove(dgvFlex.Rows[i]);
           //}
            //if (DGV.SelectedRows.Count == 0) return -1;      
           //return DGV.SelectedRows[0].Index;   


           //dgvFlex.Rows.Remove(dgvFlex.Rows[RowIndex]);

       }*/
//Удаление всех атрибутов.
//private bool AttrDelAll()
//{                         
//    dgvFlex.Rows.Clear();
//    return true;
//}

//Собрать Static фильтр в строку.
//private string GetFilterStatic()
//{
//    return sys.GetComponentValues(panelFilterStatic.Controls);
//}
//Собрать Static фильтр в строку.
//private string GetFilterUniversal()
//{
//     
//}  
/* if (FlexListIDIN == 0)
    {
        string FilterCustom = GetFilterCustomString();
        string SQLFlex      = GetSQLAttrInsert();
        string SQLFlexListDefault = GetSQLFlextListDefault();
        string ComponentValues = sys.GetComponentValues(this.Controls);
    }

    GetFilterCustomString();
    sys.FormComponentValuesSave("Remote", this);*/

/*sys.FormComponentValuesLoad("Remote", this);
  SetSettingsCustom();
  SetStar();  */


/*
  //Возвращаем весь фильтр.
        private void GetFilterAll(out string FilterStatic, 
                                    out string FilterCustom, 
                                    out string FilterCustomWHERE,
                                    out string FilterUniversal,
                                    out int CheckedStatic,
                                    out int CheckedCustom,
                                    out int CheckedUniversal,                                    
                                    out int CheckedDefault,
                                    out int FilterCustomCondition,
                                    out int FilteUniversalWordWrap,
                                    out string Attr)
        {           
            FilterStatic      = sys.GetComponentValues(panelFilterStatic.Controls);//GetFilterStatic();
            FilterCustom      = GetFilterCustom();
            FilterCustomWHERE = GetFilterCustomWHERE();
            FilterUniversal   = tbTextMSSQL.Text;           
            CheckedStatic     = cbStatic.Checked.ToInt();
            CheckedCustom     = cbCustom.Checked.ToInt();
            CheckedUniversal  = cbUniversal.Checked.ToInt();
            FilterCustomCondition = cbFilterCustomCondition.SelectedIndex; 
            CheckedDefault    = cbDefault.Checked.ToInt(); 
            Attr              = sys.DGVToStr(dgvFlex, false);
            FilteUniversalWordWrap = 0;
        } 
*/
/*
 *          Value1 = "";
             Value2 = "";
             Value3 = "";
             Value4 = "";
             Value5 = "";
             Value6 = "";
             Value7 = "";
             Value8 = "";
             Value9 = "";
             Value10 = "";    
 *              /*if (dgvList.SelectedRows.Count > 0) Value1  = dgvList.SelectedRows[0].Cells[0].Value.ToString();
             if (dgvList.SelectedRows.Count > 1) Value2  = dgvList.SelectedRows[0].Cells[1].Value.ToString();
             if (dgvList.SelectedRows.Count > 2) Value3  = dgvList.SelectedRows[0].Cells[2].Value.ToString();
             if (dgvList.SelectedRows.Count > 3) Value4  = dgvList.SelectedRows[0].Cells[3].Value.ToString();
             if (dgvList.SelectedRows.Count > 4) Value5  = dgvList.SelectedRows[0].Cells[4].Value.ToString();
             if (dgvList.SelectedRows.Count > 5) Value6  = dgvList.SelectedRows[0].Cells[5].Value.ToString();
             if (dgvList.SelectedRows.Count > 6) Value7  = dgvList.SelectedRows[0].Cells[6].Value.ToString();
             if (dgvList.SelectedRows.Count > 7) Value8  = dgvList.SelectedRows[0].Cells[7].Value.ToString();
             if (dgvList.SelectedRows.Count > 8) Value9  = dgvList.SelectedRows[0].Cells[8].Value.ToString();
             if (dgvList.SelectedRows.Count > 9) Value10 = dgvList.SelectedRows[0].Cells[9].Value.ToString();     
             */


/*
 * string someOuterVar = "someClass1";
            var myType = typeof(someClass);
            var n = myType.Namespace;
            string assemblyName = typeof(someClass).Assembly.GetName().Name;
 
 
            Type type = Type.GetType(n+"."+someOuterVar+", " + assemblyName);
            someClass someObject = Activator.CreateInstance(type) as someClass;
 //=============
            /* Работает!
            string someOuterVar = "FormFilt";
            var myType = typeof(FormFilt);
            var n = myType.Namespace;
            string assemblyName = typeof(FormFilt).Assembly.GetName().Name; 
            string test1 = n + "."+ someOuterVar + ", " + assemblyName;
            sys.SM(test1);
            Type type = Type.GetType(n + "."+ someOuterVar + ", " + assemblyName);
            FormFilt someObject = Activator.CreateInstance(type) as FormFilt;
            
            
           
          
            //Работает
            //Form filt = Activator.CreateInstance(tp) as Form;           
 
 
 ================
 //sys.SM(pnl.Name);
            
            //FilterList.MdiParent = Var.FormMainObj;          
           // if (FilterList.ShowDialog() != DialogResult.OK) return;  
            //var ib = new FormGetAttr(EntityBrief);
            //ib.pnlAttr.Parent = splitContainer1.Panel1;
            //if (ib.ShowDialog() != DialogResult.OK) return false;
================            
 
 
 */

/*=============
 *  void button1_Click(object sender, EventArgs e)
       {

           Type tp = typeof(Form10);
           Object form = null;
           //var filt = Activator.CreateInstance(tp) as Form;
           //form = assembly.CreateInstance("FBA." + FormName);

           //Type type =  form.GetType();
           string MethodName = "GetFormCustomFilter";
           //Object[] ObjParams;
           Object[] ObjParams = new Object[1];
           ObjParams[0] = dataGridViewEx1.filter;
           MethodInfo mi = tp.GetMethod(MethodName);            
           mi.Invoke(form, ObjParams);
         */

//======================
//Переименовать фильтр.
/*private bool FilterRename(string FilterID, string FilterName, int FilterGlobal)
{          
    if ((!Var.UserIsAdmin) && (FilterGlobal == 1))
    {
        sys.SM("Нет прав на переименование фильтра!");
        return false;
    }
    if (!sys.InputValue("Переименование фильтра", "Новое имя фильтра", "TEXT1", ref FilterName)) return false;
    string SQL = "UPDATE fbaFilter WHERE SET Name = '" + FilterName + "' WHERE ID = '" + FilterID + "'";
    if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;
    FilterListRefresh();
    return true;
} */
//=======================        
//Показать форму настройки фильтра.
/*private void FilterShow(string FilterID, bool ShowOnly)
{                                        
    Form FFilter = new FormFilter(FilterID, CurrentEntityRefID);
    FFilter.MdiParent = Var.FormMainObj;  
    if (ShowOnly) FormFBA.FormSetShowOnly(FFilter.Controls);              
    if (!FormFilter.FilterShow(FormStaticFilter, PanelStatic, MethodFilterStatic, SelectedFilterID, CurrentEntityRefID, ref filter)) return;
}*/
//=======================         
//Удаляем все компоненты с панели.
//foreach(Control control in panelFilterCustom.Controls)
//{                      
//    control.Dispose();                                   
//}         
//=======================   
/*
 *   //Метод для показа списка фильтров.
        public void ShowFilterList()
        {
            var FList = new FormFilterList(EntityRefID, FilterID);
            FList.MdiParent = Var.FormMainObj;          
            if (FList.ShowDialog() != DialogResult.OK) return; 
            FilterID     = FList.SelectedFilterID;  
            
            //Обновить filter по новому FilterID. 
            filter.FilterID = FilterID;
            FormFilter.FilterUpdate(ref filter);   
            
            //Вызываем событие обновления фильтра, чтобы в вызывающей форме собрать Static фильтр.
            OnFilterList(null);
                  
        }*/
//=======================   
/*private void tbN1_Click(object sender, EventArgs e)
      {                                           
          string SenderName = sys.GetSenderName(sender);
          sys.SM("SenderName=" + SenderName);

          //Filter list.
          if (SenderName == "tbN1") OnFilterList(e); 

          //Filter current.
          if (SenderName == "tbN2") OnFilterCurrent(e); 

          //Filter list.
          /*if (SenderName == "tbN1") FilterListShow();
          //Current filter.
          if (SenderName == "tbN2") FilterShow();
          //Enable filter.
          //if (SenderName == "tbN3") UseFilter = tbN3.Checked;
          //Refresh.
          if (SenderName == "tbN4") RefreshGrid();
          //Refresh.
          if (SenderName == "cmGridN1") RefreshGrid();

          //Export to Excel.
          //if (SenderName == "cmGridN2")
          //Save as CSV.
          //if (SenderName == "cmGridN3")             

      }*/
//======================= 
//Кнопка показать фильтр MSQL WHERE.
//            if (SenderName == "btnFilterCustomShow") sys.SM(FilterCustomGetWHERE(), MessageType.Information, "Filter");

//======================= 


//Класс предок для RadioButtonEx.
/*public class DataGridViewEx : System.Windows.Forms.DataGridView
{              
    string _SQL;               
    [DisplayName("SQL;")]
    [Description("Text SQL query")]
    public string SQL
    {
        get { return _SQL; }
        set { _SQL = value; }
    } 
    string _MSQL;
    [DisplayName("MSQL;")]
    [Description("Text MSQL query")]
    public string MSQL
    {
        get { return _MSQL; }
        set { _MSQL = value; }
    }  

    //private System.Windows.Forms.ContextMenuStrip contextMenuDataGridViewEx;
    //contextMenuDataGridViewEx = new System.Windows.Forms.ContextMenuStrip(this.components);

}*/

//======================= 
//public string GetCompGroup(string CompName)
//{
//    return CompName.StrBetweenStr2("_");
//}

//cb_ID/!cb_Number/cb_num1



/*private void FilterEnableDisable(Control pnlFilter, Control.ControlCollection controls)
{
    foreach(Control control in controls)
    {                      
        FilterEnableDisable(pnlFilter, control.Controls);                
        string CompGroup = control.Name.StrBetweenStr2("_");
        if (CompGroup == "") continue;
        if (control.Name == "cbEnabled_" + CompGroup) continue;                
        Control CheckBoxEnable = pnlFilter.Controls.Find("cbEnabled_" + CompGroup, true).FirstOrDefault();   
        if (CheckBoxEnable == null) continue;                
        string CheckBoxEnableType = CheckBoxEnable.GetType().ToString();
        if (CheckBoxEnableType != "System.Windows.Forms.CheckBox") continue;               
        control.Enabled = ((System.Windows.Forms.CheckBox)CheckBoxEnable).Checked;                                                                                                             
    }           
}*/
//======================= 
//Создание пунктов контекстного меню.
/*public void CreateFilterMenu()
{              
    ContextMenuStrip cmGrid = this.ContextMenuStrip;
    ContextMenu cmGridcc = this.ContextMenu;
    if (cmGrid == null) return;
    cmGrid.Font = Var.font1;
    cmGrid.Name = "cmGrid";
    cmGrid.Size = new System.Drawing.Size(175, 192);


    var cmGridN1 = new System.Windows.Forms.ToolStripMenuItem(); //Add
    var cmGridN2 = new System.Windows.Forms.ToolStripMenuItem(); //Edit
    var cmGridN3 = new System.Windows.Forms.ToolStripMenuItem(); //Del          
    var cmGridN4 = new System.Windows.Forms.ToolStripMenuItem(); //Filter 
    var cmGridN5 = new System.Windows.Forms.ToolStripMenuItem(); //Ref           
    var cmGridSeparator1 = new System.Windows.Forms.ToolStripSeparator();
    var cmGridN6 = new System.Windows.Forms.ToolStripMenuItem(); //Excel
    var cmGridN7 = new System.Windows.Forms.ToolStripMenuItem(); //CSV

    if (this.CommandAdd)
    {                 
        cmGrid.Items.Insert(0, cmGridN1);
        cmGridN1.Image = global::FBA.Resource.add;
        cmGridN1.Name = "cmGridN1";
        //cmGridN1.Size = new System.Drawing.Size(174, 22);
        cmGridN1.Text = "Add";

    }

    if (this.CommandEdit)
    {
        //cmGrid.Items.Add(cmGridN2); 
        cmGrid.Items.Insert(1, cmGridN2);
        cmGridN2.Image = global::FBA.Resource.edit;
        cmGridN2.Name = "cmGridN2";
        //cmGridN2.Size = new System.Drawing.Size(174, 22);
        cmGridN2.Text = "Edit";
    }

    if (this.CommandDel)
    {            
        //cmGrid.Items.Add(cmGridN3); 
        cmGrid.Items.Insert(2, cmGridN3);
        cmGridN3.Image = global::FBA.Resource.del;
        cmGridN3.Name = "cmGridN3";
        //cmGridN3.Size = new System.Drawing.Size(174, 22);
        cmGridN3.Text = "Del";
    }
    if (this.CommandFilter)
    { 
        //cmGrid.Items.Add(cmGridN4); 
        cmGrid.Items.Insert(3, cmGridN4);
        cmGridN4.Image = global::FBA.Resource.filter;
        cmGridN4.Name = "cmGrid4";
        //cmGridN4.Size = new System.Drawing.Size(174, 22);
        cmGridN4.Text = "Filter";         
    }

    if (this.CommandRefresh)
    {             
        //cmGrid.Items.Add(cmGridN5); 
        cmGrid.Items.Insert(4, cmGridN5);
        cmGridN5.Image = global::FBA.Resource.arrow_refresh;
        cmGridN5.Name = "cmGridN5";
        //cmGridN5.Size = new System.Drawing.Size(174, 22);
        cmGridN5.Text = "Ref";       
    }                     

    if (this.CommandExportToExcel || this.CommandSaveASCSV)
    { 
        //cmGrid.Items.Add(cmGridSeparator1); 
        cmGrid.Items.Insert(5, cmGridSeparator1);
        cmGridSeparator1.Name = "toolStripMenuItem1";
        cmGridSeparator1.Size = new System.Drawing.Size(171, 6);
    }

    if (this.CommandExportToExcel)
    {
        //cmGrid.Items.Add(cmGridN6); 
        cmGrid.Items.Insert(6, cmGridN6);
        cmGridN6.Name = "cmGridN6";
        //cmGridN6.Size = new System.Drawing.Size(174, 22);
        cmGri
dN6.Text = "Export to Excel";
    }
     if (this.CommandSaveASCSV)
    {
        //cmGrid.Items.Add(cmGridN7);
        cmGrid.Items.Insert(7, cmGridN7);                
        cmGridN7.Name = "cmGridN7";
        //cmGridN7.Size = new System.Drawing.Size(174, 22);
        cmGridN7.Text = "Save as CSV";           
    }

}*/
//======================= 

/*for (int i = 0; i < dataGridView1.ContextMenuStrip.Items.Count; i++)               
{
    if (dataGridView1.ContextMenuStrip.Items[i].Name.IndexOf(Prefix, StringComparison.OrdinalIgnoreCase) = 0)
    {
        dataGridView1.ContextMenuStrip.Items[i].Click += OperationClick; 
        toolStrip1.Items[i].Click += OperationClick; 
    }
}*/
//======================= 
//Копировать фильтр как новый - с новым именем.
/* private bool FilterCopyAsNew(string FilterID, string FilterName)
 {           
     if (!sys.InputValue("Название фильтра", "Введите название фильтра:", "TEXT1", ref FilterName)) return false;
     FilterID = FilterCopyToUser(FilterID, FilterName, sys.UserName, Var.UserID );
     int N = sys.DGVSelectFind(dgvList, FilterID, 0, false);
     return (N > -1);
 }  */
//======================= 
/*string SQL = "";
            if (Var.con.ServerType == "SQLite")  
                SQL = "SELECT Name FROM sqlite_master WHERE type = 'table' AND Name NOT IN (SELECT Name FROM fbaTable) ORDER BY Name";
                       
            if (Var.con.ServerType == "MSSQL") 
                SQL = "SELECT Table_Name AS Name FROM information_schema.tables WHERE Name NOT IN (SELECT Name FROM fbaTable) Order by Table_Name ";
            */
//=======================            
/*void button1_Click(object sender, EventArgs e)
        {
            //string str = "";
            //if (!sys.InputValue("CapForm", "Перевести договор страхвоания в статус Действет?" + Var.CR + "При необходимости введите комментарий:" , "TEXT", ref str)) return;
            //sys.SM(str);
            
            string EntityID    = "";
            string EntityBrief = "";
            string EntityName  = "Договор страхования";
            if (!sys.InputEntity(false, false, ref EntityID, ref EntityBrief, ref EntityName)) return;
            sys.SM("EntityID = " + EntityID + Var.CR + 
                   "EntityBrief = " + EntityBrief + Var.CR +
                   "EntityName = " + EntityName + Var.CR);
        }            
*/
//======================= 
/*void MainMenu_N2_22_Click(object sender, EventArgs e)
       {
           string SQL = "--===================================================================== " + Var.CR +
           "--Подготовка таблиц для парсера.
           "BEGIN TRY DROP TABLE EntityParent END TRY BEGIN CATCH END CATCH 
           "BEGIN TRY DROP TABLE #EntityParser END TRY BEGIN CATCH END CATCH 
           "BEGIN TRY DROP TABLE #AttrParent END TRY BEGIN CATCH END CATCH 
           "BEGIN TRY DROP TABLE #AttrChild END TRY BEGIN CATCH END CATCH 
           "BEGIN TRY DROP TABLE #Entity END TRY BEGIN CATCH END CATCH
           "BEGIN TRY DROP TABLE #Attr END TRY BEGIN CATCH END CATCH  
           "BEGIN TRY DROP TABLE #Attribute END TRY BEGIN CATCH END CATCH  
           "--=====================================================================
           " 
           "--=====================================================================
           "--Таблица #EntityParser с сущностями.           
           "SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos, * 
           "  INTO #EntityParser FROM dbo.fbaEntity
           "ALTER TABLE #EntityParser ADD Table_ID varchar(100)
           "ALTER TABLE #EntityParser ADD Table_Name varchar(100)
           "ALTER TABLE #EntityParser ADD Table_IDFieldName varchar(100)
           "UPDATE #EntityParser SET Table_ID    = t2.TableID,
           "                   Table_Name        = t2.Name,
           "                   Table_IDFieldName = t2.IDFieldName                  
           "FROM dbo.fbaTable t2 WHERE t2.TableEntityID = #EntityParser.ID AND t2.Type = 1
           "UPDATE #EntityParser SET Pos = Pos - 1
           "--===================================================================== 
           "   
           "--=====================================================================                     
           "--Таблица #EntityParent с деревом сущностей.
           ";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS
           "      (
           "        SELECT 
           "          ID AS EnChildID, 
           "          Brief AS EnBrief2, 
           "          ID as EnID, 
           "          Brief as EnBrief1, 
           "          ParentID, 
           "          Name as EnBriefName2, 
           "          Name as EnBriefName1        
           "        FROM dbo.fbaEntity
           "        UNION ALL
           "        SELECT 
           "          EnChildID, 
           "          EnBrief2, 
           "          e.ID as EnID, 
           "          e.Brief as EnBrief1, 
           "          e.ParentID, 
           "          p.EnBriefName2 as EnBriefName2, 
           "          e.Name as EnBriefName1          
           "        FROM dbo.fbaEntity e INNER JOIN Parents p ON p.ParentID = e.ID
           "      ) SELECT * INTO #EntityParent FROM Parents ORDER BY EnBrief2, EnBrief1; 

           "ALTER TABLE #EntityParent ADD EnBrief2_TableName varchar(100);         --Главная таблица сущности EnBrief2.
           "ALTER TABLE #EntityParent ADD EnBrief2_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief2.
           "ALTER TABLE #EntityParent ADD EnBrief1_TableName varchar(100);         --Главная таблица сущности EnBrief1.
           "ALTER TABLE #EntityParent ADD EnBrief1_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief1.      
           "
           "--Данные по таблице для сущности EnBrief2
           "UPDATE #EntityParent SET 
           "  #EntityParent.EnBrief2_TableName        = t1.Table_Name, 
           "  #EntityParent.EnBrief2_TableIDFieldName = t1.Table_IDFieldName
           "FROM #EntityParser t1 WHERE #EntityParent.EnBrief2 = t1.Brief
           "
           "--Данные по таблице для сущности EnBrief1
           "UPDATE #EntityParent SET 
           "  #EntityParent.EnBrief1_TableName        = t1.Table_Name, 
           "  #EntityParent.EnBrief1_TableIDFieldName = t1.Table_IDFieldName
           "FROM #EntityParser t1 WHERE #EntityParent.EnBrief1 = t1.Brief            
           "--=====================================================================  
           " 
           "--=====================================================================       
           "--Таблица #AttrParser с атрибутами
           "SELECT 
           "  AttributeID       AS ID,
           "  EntityID          AS EntityID,
           "  AttributeEntityID AS Attr_EntityID,
           "  Name              AS Attr_Name, 
           "  Brief             AS Attr_Brief,
           "  Type              AS Attr_Type,
           "  Kind              AS Attr_Kind,                             
           "  Mask              AS Attr_Mask,
           "  Feature           AS Attr_Feature,
           "  ObjectNameOrder   AS Attr_NameOrder,
           "  Code              AS Attr_Code,
           "  Description       AS Attr_Comment,
           "  TableID           AS Table_ID,
           "  FieldName         AS Table_Field,
           "  FieldName2        AS Table_Field2,
           "  RefEntityID       AS Ref_EntityID,
           "  RefAttributeID    AS Ref_AttrID
           "INTO #AttrParser     
           "FROM dbo.fbaAttribute 
           "     
           "ALTER TABLE #AttrParser ADD Table_Name varchar(100);          --Данные по таблице, в которой находится атрибут. Имя таблицы.
           "ALTER TABLE #AttrParser ADD Table_IDFieldName varchar(100);   --Данные по таблице, в которой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа)
           "ALTER TABLE #AttrParser ADD Table_Type int;                   --Тип таблицы (Главная или Историчная)
           "ALTER TABLE #AttrParser ADD Table_Feature int;                --Свойства таблицы.
           "ALTER TABLE #AttrParser ADD Ref_EntityBrief varchar(100);     --Сокращение сущности для атрибута Ссылки или Массива
           "ALTER TABLE #AttrParser ADD Ref_AttrBrief varchar(100);       --Сокращение атрибута сущности для атрибута Ссылки или Массива
           "ALTER TABLE #AttrParser ADD Ref_AttrName varchar(100);        --Наименование атрибута сущности для атрибута Ссылки или Массива
           "ALTER TABLE #AttrParser ADD Attr_EntityBrief varchar(100);    --Сокращение сущности, к которой относится атрибут.
           "
           "--Данные по таблице атрибута
           "UPDATE #AttrParser SET 
           "  #AttrParser.Table_Name        = t1.Name, 
           "  #AttrParser.Table_IDFieldName = t1.IDFieldName,
           "  #AttrParser.Table_Feature     = t1.Feature,
           "  #AttrParser.Table_Type        = t1.Type
           "FROM dbo.fbaTable t1 
           "WHERE #AttrParser.Table_ID = t1.TableID
           "
           "--Данные для атрибута Ссылки или Массива.
           "UPDATE #AttrParser SET Ref_EntityBrief = t1.Brief FROM dbo.fbaEntity t1 WHERE #AttrParser.Ref_EntityID = t1.ID 
           "UPDATE #AttrParser SET Ref_AttrBrief   = t1.Brief, 
           "                 Ref_AttrName    = t1.Name 
           "FROM dbo.fbaAttribute t1 
           "WHERE #AttrParser.Ref_AttrID = t1.AttributeID and #AttrParser.Ref_EntityID = t1.AttributeEntityID
           "--Сущность атрибута 
           "UPDATE #AttrParser SET Attr_EntityBrief = t1.Brief FROM dbo.fbaEntity t1 WHERE #AttrParser.Attr_EntityID = t1.ID 
           "--=====================================================================   
           "
           "--=====================================================================       
           "--Таблица #AttrParent с атрибутами. Для каждой сущности весь полный список атрибутов, включая предков.
           "SELECT ROW_NUMBER() OVER(ORDER BY EnBrief2) Pos, t1.*, t2.* 
           "  INTO #AttrParent FROM #AttrParser t1 
           "  LEFT JOIN #EntityParent t2 ON t2.EnID = t1.Attr_EntityID
           "UPDATE #AttrParent   SET Pos = Pos - 1 
           "--=====================================================================   
           "
           "--=====================================================================       
           "--Таблица #AttrChild с атрибутами. Для каждой сущности список атрибутов потомков.
           "--Работает, но пока отключено.
           "--SELECT ROW_NUMBER() OVER(ORDER BY Attr_EntityID, Attr_Brief) Pos, t1.*, t2.* 
           "--  INTO #AttrChild FROM #AttrParser t1 
           "--  RIGHT JOIN #EntityParent t2 ON t2.EnChildID = t1.Attr_EntityID AND t1.Attr_Brief IS NOT NULL --1716 Расчетный документ  
           "--UPDATE #AttrChild SET Pos = Pos - 1                                                  
           "--=====================================================================   
           "
           "--=====================================================================
           "--Результат 5 таблиц. #AttrParser не используем, поэтому 4.   
           "SELECT * FROM #EntityParser ORDER BY Pos
           "SELECT * FROM #AttrParent   ORDER BY Pos
           "SELECT * FROM dbo.fbaEntity      ORDER BY ID  
           "SELECT * FROM dbo.fbaAttribute   ORDER BY AttributeID  
           "SELECT * FROM dbo.fbaTable       ORDER BY TableID          
           "--=====================================================================   

       }
*/
//======================= 
//Загрузка статусов.
/*private void LoadStatus()
{
    string SQL = "SELECT t2.Brief FROM fbaStatusCard t1 " +
                 "LEFT JOIN fbaEntity t2 ON t1.EntityRefID = t2.ID ORDER BY t2.Brief; ";
    sys.SelectDT(DirectionQuery.Remote, SQL, out DTEntity);
    dgvEntity.DataSource = DTEntity;

    string EntityBrief = sys.DGSelected(dgvEntity, "Brief");
    if (EntityBrief == "") return;
    SQL = string.Format("SELECT t2.Name FROM fbaStatusCard t1 " + 
          "LEFT JOIN fbaStatus t2 ON t1.StatusID = t2.ID " + 
          "LEFT JOIN fbaEntity t3 ON t1.EntityRefID = t3.ID " + 
          "WHERE t3.Brief = '{0}' ORDER BY t2.Name;", EntityBrief);
    sys.SelectDT(DirectionQuery.Remote, SQL, out DTStatus);
    dgvStatus.DataSource = DTStatus;

    string StatusName = sys.DGSelected(dgvStatus, "Name");
    SQL = string.Format("SELECT t4.Name FROM fbaStatusCard t1 " + 
          "LEFT JOIN fbaStatus t2 ON t1.StatusID = t2.ID " + 
          "LEFT JOIN fbaEntity t3 ON t1.EntityRefID = t3.ID " + 
          "LEFT JOIN fbaStatus t4 ON t1.StatusChangeID = t4.ID " + 
          "WHERE t3.Brief = '{0}' AND t2.Name = '{1}' ORDER BY t4.Name; ", EntityBrief, StatusName);                            
    sys.SelectDT(DirectionQuery.Remote, SQL, out DTChange);
    dgvChange.DataSource = DTChange;           
}
*/
//======================= 
/*
 * public partial class Form10 : FormFBA
   {
       //FilterObj filtermain;

       public Form10()
       {               
           InitializeComponent();
           //sys.ConnectLocal();
           //sys.ConnectRemote();

           //Присвоение ссылки на форму стстического фильтра.
           //dataGridViewEx1.FilterID    = "";
           //dataGridViewEx1.EntityRefID = "";
           //dataGridViewEx1.EntityBrief = "ДогСтрах";
           //dataGridViewEx1.FullQuery   = "";
           //dataGridViewEx1.filter      = null;                      
           //dataGridViewEx1.MyNameMethod1 = new sys.MyName(MyNameMethod2);
           //dataGridViewEx1.typeformfilter = typeof(FormFilt);           
           //Type tp =  this.GetType();               
           //MethodInfo mi = tp.GetMethod("GetFormCustomFilter"); 
          // dataGridViewEx1.MethodFilterStatic = this.GetType().GetMethod("GetFormCustomFilter");
           //RefreshTable1();
       }

       public string MyNameMethod2(string str1)
       {
           return "sdfsdf";
       }      

       private void RefreshTable1()
       {               
            //FilterObj filter = dataGridViewEx1.filter;
            //if (filter == null) return;
            //string FullQuery = filter.FullQuery;
            //string SQL = GetFormStaticFilter(filter);
            //FullQuery = FullQuery + SQL;
            //dataGridViewEx1.RefreshFilter("Remote", SQL);
       }

       void dataGridViewEx1_FilterRefresh(object sender, EventArgs e)
       {                            
           //sys.SM("dataGridViewEx1_FilterRefresh");
           //RefreshTable1();
       }        

       public void FilterShow(FBA.DataGridViewFBA DBG)
       {

       }

       void button2_Click(object sender, EventArgs e)
       {
           //FilterShow();
       }

       void Form10_FormClosed(object sender, FormClosedEventArgs e)
       {
           //FormFilter.FilterSave(ref filter);
       }

       void Form10_Load(object sender, EventArgs e)
       {

           Var.CReateFilterMenu(DBG1,toolStrip1, true,true,true,true,true,true,true);       
           for (int i = 0; i < DBG2.ContextMenuStrip.Items.Count; i++) DBG2.ContextMenuStrip.Items[i].Click += OperationClick;             
           for (int i = 0; i < toolStrip1.Items.Count; i++) toolStrip1.Items[i].Click += OperationClick; 


            Var.CReateFilterMenu(DBG2, toolStrip2, true,true,true,true,true,true,true);           
            for (int i = 0; i < DBG2.ContextMenuStrip.Items.Count; i++) DBG2.ContextMenuStrip.Items[i].Click += OperationClick; 
            for (int i = 0; i < toolStrip2.Items.Count; i++) toolStrip2.Items[i].Click += OperationClick;                      
       }

       /*public string Filter(Object FormRef,
                             string EntityName,
                             string FormStaticName, 
                             string MethodStaticName = "FormStaticFilter",
                             string PanelStaticName = "PanelFilter"
                             )
       {                        
           //Фильтр
           var filter  = new FilterObj();
           filter.EntityID   = sys.GetEntityID(EntityName);
           Object F2         = null;
           Panel StaticPanel = null;
           MethodInfo mi     = null;

           string FilerStaticClassName = "FBA." + FormStaticName;
           Type tp = Type.GetType(FilerStaticClassName, false, true);

           //Если класс формы статического фильтра найден, то...
           if (tp != null)
           {                                        
               //Создание объекта формы Static фильтра.
               System.Reflection.ConstructorInfo ci = tp.GetConstructor(new Type[] { });     
               F2 = ci.Invoke(new Object[] { });
               //((FormFilt)F2).FormDirectory = this;

               //Метод
               var ObjParams = new Object[1];
               ObjParams[0]  = filter;                       
               mi = tp.GetMethod(MethodStaticName);     

               //Панель       
               Control pnl2 = ((Form)F2).Controls.Find(PanelStaticName, true).FirstOrDefault();   
               StaticPanel = (Panel)pnl2;
           }

           //Вызов стандарной формы фильтра. 
           //Если статического фильтра нет, то форма фильтра 
           //все равно откроется, но вкладка статического фильтра будет скрыта.
           if (!FormFilter.FilterShow(FormRef,
                                      F2,
                                      StaticPanel, 
                                      mi,                                     
                                      ref filter)) return ""; 

           sys.SM(filter.FullQuery);
           return filter.FullQuery; 
       }*/

/*public string Filter222(string EntityName, 
                     string FormStaticName, 
                     string MethodStaticName,
                     string PanelStaticName
                     )
{                        
    Type tp = Type.GetType("FBA.FormFilt", false, true);

    //если класс не найден
    if (tp == null)
    {
        //sys.SM(string.Format("Класс {0} не найден", FilerStaticClassName));
        //return "";
    }

    //получаем конструктор
    System.Reflection.ConstructorInfo ci = tp.GetConstructor(new Type[] { });     
    object F2 = ci.Invoke(new object[] { });
    //((FormFilt)F2).FormDirectory = this;
    filtermain  = new FilterObj();
    Object[] ObjParams = new Object[1];
    ObjParams[0]  = filtermain;                       
    MethodInfo mi = tp.GetMethod("FormStaticFilter");     
    Object ObjResult = mi.Invoke(F2, ObjParams);                 

    Control pnl2 = ((FormFilt)F2).Controls.Find("PanelFilter", true).FirstOrDefault();   
    Panel StaticPanel = (Panel)pnl2;
    filtermain.EntityID = sys.GetEntityID("ДогСтрах");
    if (!FormFilter.FilterShow(this,
                               F2,
                               StaticPanel, //((FormFilt)F2).PanelFilter,
                               mi,                                     
                               ref filtermain)) return ""; 

    sys.SM(filtermain.FullQuery);
    return filtermain.FullQuery; 
}*/

/*private void OperationClick(object sender, EventArgs e)
{


    //if (SenderName == "DBG1tbN4")  //Filter


}
void button1_Click(object sender, EventArgs e)
{           
    FilterObj filter = new FilterObj();
    FormFilter.Filter(this,
                    "ДогСтрах",
                    "FormFilt", 
                    "MethodStaticFilter",
                    "PanelFilter",
                    ref filter
                    );
    sys.SM(filter.FullQuery);          

} 

void btnOpen_Click(object sender, EventArgs e)
{
    //string SQL = "select ID, Name from fbaEntity WHERE ID = 1 LIMIT 3;";
    string SQL = "select * from fbaEntity";

    DBG1.DataSource = null;
    DBG1.Rows.Clear();
    DBG1.Columns.Clear();
    DBG1.AllowUserToAddRows = false;
    sys.SelectGV(DirectionQuery.Local, SQL, DBG1);                      
    //sys.SM(DBG1.Rows.Count.ToString());                       
    var DataSource = DBG1.DataSource;
    DataTable DT = (DataTable)DataSource;
    sys.SM(DT.Rows.Count.ToString());
}
void btnClose_Click(object sender, EventArgs e)
{
    DBG1.DataSource = null;
}        
void btnDGVToStr_Click(object sender, EventArgs e)
{           
    string Block5 = "";
    sys.DGToStr(DBG1, ref Block5);
    textBox1.Text = Block5;
}
void btnGRVFromStr_Click(object sender, EventArgs e)
{

    //(ref int Offset, ref string InputStr)
    string result = textBox1.Text;
    int Offset = 0;
    sys.DGFromStr(ref DBG1, ref Offset, ref result);
}
void btnArrayToStr_Click(object sender, EventArgs e)
{
    int N = 0;
    var Arr = new string[10,20];
    for (int i = 0; i < 10; i++) 
        for (int j = 0; j < 20; j++) 
        {
            N++;
            Arr[i,j] = N.ToString();
        }
    string Block5 = "";
    sys.ArrayToStr(Arr, ref Block5);
    textBox1.Text = Block5;
    sys.ArrayView("Array1", "", Arr);
}

void btnArrayFromStr_Click(object sender, EventArgs e)
{
    string[,] Arr = null; 
    int Offset = 0;
    string InputStr = textBox1.Text;
    sys.ArrayFromStr(ref Arr, ref Offset, ref InputStr);
    sys.ArrayView("Array2", "", Arr);
}
void button3_Click(object sender, EventArgs e)
{
    // Create a new DateTimePicker.
    //DateTimePicker dateTimePicker1 = new DateTimePicker();
    Controls.AddRange(new Control[] {dateTimePicker1}); 
    dateTimePicker1.CalendarFont = new Font("Arial", 11F, FontStyle.Italic, GraphicsUnit.Point, ((Byte)(0)));
}



}

internal sealed class Program
{         
[STAThread]
private static void Main(string[] args)
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);            
    Application.Run(new Form10());
}

}

*/
//======================= 
/*string SQL = "--=====================================================================
            "--Подготовка таблиц для парсера.
            "BEGIN TRY DROP TABLE EntityParent END TRY BEGIN CATCH END CATCH 
            "BEGIN TRY DROP TABLE #EntityParser END TRY BEGIN CATCH END CATCH 
            "BEGIN TRY DROP TABLE #AttrParent END TRY BEGIN CATCH END CATCH 
            "BEGIN TRY DROP TABLE #AttrChild END TRY BEGIN CATCH END CATCH 
            "BEGIN TRY DROP TABLE #Entity END TRY BEGIN CATCH END CATCH
            "BEGIN TRY DROP TABLE #Attr END TRY BEGIN CATCH END CATCH  
            "BEGIN TRY DROP TABLE #Attribute END TRY BEGIN CATCH END CATCH  
            "--=====================================================================
            " 
            "--=====================================================================
            "--Таблица #EntityParser с сущностями.           
            "SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos, * 
            "  INTO #EntityParser FROM dbo.fbaEntity
            "ALTER TABLE #EntityParser ADD Table_ID varchar(100)
            "ALTER TABLE #EntityParser ADD Table_Name varchar(100)
            "ALTER TABLE #EntityParser ADD Table_IDFieldName varchar(100)
            "UPDATE #EntityParser SET Table_ID    = t2.TableID,
            "                   Table_Name        = t2.Name,
            "                   Table_IDFieldName = t2.IDFieldName                  
            "FROM dbo.fbaTable t2 WHERE t2.TableEntityID = #EntityParser.ID AND t2.Type = 1
            "UPDATE #EntityParser SET Pos = Pos - 1
            "--===================================================================== 
            "   
            "--=====================================================================                     
            "--Таблица #EntityParent с деревом сущностей.
            ";WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS
            "      (
            "        SELECT 
            "          ID AS EnChildID, 
            "          Brief AS EnBrief2, 
            "          ID as EnID, 
            "          Brief as EnBrief1, 
            "          ParentID, 
            "          Name as EnBriefName2, 
            "          Name as EnBriefName1        
            "        FROM dbo.fbaEntity
            "        UNION ALL
            "        SELECT 
            "          EnChildID, 
            "          EnBrief2, 
            "          e.ID as EnID, 
            "          e.Brief as EnBrief1, 
            "          e.ParentID, 
            "          p.EnBriefName2 as EnBriefName2, 
            "          e.Name as EnBriefName1          
            "        FROM dbo.fbaEntity e INNER JOIN Parents p ON p.ParentID = e.ID
            "      ) SELECT * INTO #EntityParent FROM Parents ORDER BY EnBrief2, EnBrief1; 
      
            "ALTER TABLE #EntityParent ADD EnBrief2_TableName varchar(100);         --Главная таблица сущности EnBrief2.
            "ALTER TABLE #EntityParent ADD EnBrief2_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief2.
            "ALTER TABLE #EntityParent ADD EnBrief1_TableName varchar(100);         --Главная таблица сущности EnBrief1.
            "ALTER TABLE #EntityParent ADD EnBrief1_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief1.      
            "
            "--Данные по таблице для сущности EnBrief2
            "UPDATE #EntityParent SET 
            "  #EntityParent.EnBrief2_TableName        = t1.Table_Name, 
            "  #EntityParent.EnBrief2_TableIDFieldName = t1.Table_IDFieldName
            "FROM #EntityParser t1 WHERE #EntityParent.EnBrief2 = t1.Brief
            "
            "--Данные по таблице для сущности EnBrief1
            "UPDATE #EntityParent SET 
            "  #EntityParent.EnBrief1_TableName        = t1.Table_Name, 
            "  #EntityParent.EnBrief1_TableIDFieldName = t1.Table_IDFieldName
            "FROM #EntityParser t1 WHERE #EntityParent.EnBrief1 = t1.Brief            
            "--=====================================================================  
            " 
            "--=====================================================================       
            "--Таблица #AttrParser с атрибутами
            "SELECT 
            "  AttributeID       AS ID,
            "  EntityID          AS EntityID,
            "  AttributeEntityID AS Attr_EntityID,
            "  Name              AS Attr_Name, 
            "  Brief             AS Attr_Brief,
            "  Type              AS Attr_Type,
            "  Kind              AS Attr_Kind,                             
            "  Mask              AS Attr_Mask,
            "  Feature           AS Attr_Feature,
            "  ObjectNameOrder   AS Attr_NameOrder,
            "  Code              AS Attr_Code,
            "  Description       AS Attr_Comment,
            "  TableID           AS Table_ID,
            "  FieldName         AS Table_Field,
            "  FieldName2        AS Table_Field2,
            "  RefEntityID       AS Ref_EntityID,
            "  RefAttributeID    AS Ref_AttrID
            "INTO #AttrParser     
            "FROM dbo.fbaAttribute 
            "     
            "ALTER TABLE #AttrParser ADD Table_Name varchar(100);          --Данные по таблице, в которой находится атрибут. Имя таблицы.
            "ALTER TABLE #AttrParser ADD Table_IDFieldName varchar(100);   --Данные по таблице, в которой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа)
            "ALTER TABLE #AttrParser ADD Table_Type int;                   --Тип таблицы (Главная или Историчная)
            "ALTER TABLE #AttrParser ADD Table_Feature int;                --Свойства таблицы.
            "ALTER TABLE #AttrParser ADD Ref_EntityBrief varchar(100);     --Сокращение сущности для атрибута Ссылки или Массива
            "ALTER TABLE #AttrParser ADD Ref_AttrBrief varchar(100);       --Сокращение атрибута сущности для атрибута Ссылки или Массива
            "ALTER TABLE #AttrParser ADD Ref_AttrName varchar(100);        --Наименование атрибута сущности для атрибута Ссылки или Массива
            "ALTER TABLE #AttrParser ADD Attr_EntityBrief varchar(100);    --Сокращение сущности, к которой относится атрибут.
            "
            "--Данные по таблице атрибута
            "UPDATE #AttrParser SET 
            "  #AttrParser.Table_Name        = t1.Name, 
            "  #AttrParser.Table_IDFieldName = t1.IDFieldName,
            "  #AttrParser.Table_Feature     = t1.Feature,
            "  #AttrParser.Table_Type        = t1.Type
            "FROM dbo.fbaTable t1 
            "WHERE #AttrParser.Table_ID = t1.TableID
            "
            "--Данные для атрибута Ссылки или Массива.
            "UPDATE #AttrParser SET Ref_EntityBrief = t1.Brief FROM dbo.fbaEntity t1 WHERE #AttrParser.Ref_EntityID = t1.ID 
            "UPDATE #AttrParser SET Ref_AttrBrief   = t1.Brief, 
            "                 Ref_AttrName    = t1.Name 
            "FROM dbo.fbaAttribute t1 
            "WHERE #AttrParser.Ref_AttrID = t1.AttributeID and #AttrParser.Ref_EntityID = t1.AttributeEntityID
            "--Сущность атрибута 
            "UPDATE #AttrParser SET Attr_EntityBrief = t1.Brief FROM dbo.fbaEntity t1 WHERE #AttrParser.Attr_EntityID = t1.ID 
            "--=====================================================================   
            "
            "--=====================================================================       
            "--Таблица #AttrParent с атрибутами. Для каждой сущности весь полный список атрибутов, включая предков.
            "SELECT ROW_NUMBER() OVER(ORDER BY EnBrief2) Pos, t1.*, t2.* 
            "  INTO #AttrParent FROM #AttrParser t1 
            "  LEFT JOIN #EntityParent t2 ON t2.EnID = t1.Attr_EntityID
            "UPDATE #AttrParent   SET Pos = Pos - 1 
            "--=====================================================================   
            "
            "--=====================================================================       
            "--Таблица #AttrChild с атрибутами. Для каждой сущности список атрибутов потомков.
            "--Работает, но пока отключено.
            "--SELECT ROW_NUMBER() OVER(ORDER BY Attr_EntityID, Attr_Brief) Pos, t1.*, t2.* 
            "--  INTO #AttrChild FROM #AttrParser t1 
            "--  RIGHT JOIN #EntityParent t2 ON t2.EnChildID = t1.Attr_EntityID AND t1.Attr_Brief IS NOT NULL --1716 Расчетный документ  
            "--UPDATE #AttrChild SET Pos = Pos - 1                                                  
            "--=====================================================================   
            "
            "--=====================================================================
            "--Результат 5 таблиц. #AttrParser не используем, поэтому 4.   
            "SELECT * FROM #EntityParser ORDER BY Pos
            "SELECT * FROM #AttrParent   ORDER BY Pos
            "SELECT * FROM dbo.fbaEntity      ORDER BY ID  
            "SELECT * FROM dbo.fbaAttribute   ORDER BY AttributeID  
            "SELECT * FROM dbo.fbaTable       ORDER BY TableID          
            "--=====================================================================   
            
               */
//======================= 
//string s = "aaaa1111fskfsdljnmkdsj11243";
//          Dictionary<char, double> counts = s.GroupBy(ch => ch).ToDictionary(g => g.Key, g => (g.Count() * 100.0) / (double)s.Length);

//======================= 

//Замена комментариев. Таких: /*Комментарий*/
//private void ParseUserComment0()
//{
//    int ReplaceCount = 0;             
//    int i1 = MSQL.IndexOf(@"/*", StringComparison.OrdinalIgnoreCase);
//            if (i1 == -1) return;
//            int i2 = MSQL.IndexOf(@"*/", i1 + 2, StringComparison.OrdinalIgnoreCase);                
//            while ((i1 > -1) && (i2 > i1))
//            {
//                ReplaceCount ++;
//                MSQL = MSQL.Remove(i1, i2 - i1 + 2);               
//                i1 = MSQL.IndexOf(@"/*", StringComparison.OrdinalIgnoreCase);
//                i2 = MSQL.IndexOf(@"*/", i1 + 2, StringComparison.OrdinalIgnoreCase);  
//            } 
//        }



//Замена комментариев. Таких: --Комментарий
/*private void ParseUserComment2()
{
    int ReplaceCount = 0;             
    int i1 = MSQL.IndexOf(@"--", StringComparison.OrdinalIgnoreCase);
    if (i1 == -1) return;
    int i2 = MSQL.IndexOf(Var.CR, i1 + 2, StringComparison.OrdinalIgnoreCase);   
    if (i2 == -1) i2 = MSQL.Length;
    while ((i1 > -1) && (i2 > i1))
    {
        ReplaceCount ++;
        MSQL = MSQL.Remove(i1, i2 - i1);
        i1 = MSQL.IndexOf(@"--", StringComparison.OrdinalIgnoreCase);
        if (i1 == -1) return;
        i2 = MSQL.IndexOf(Var.CR, i1 + 2, StringComparison.OrdinalIgnoreCase);   
        if (i2 == -1) i2 = MSQL.Length;
    }           
}
//Заменяем пользовательские строки на UserStr1, UserStr2 и .т.д.
/*private void ParseUserStr()
{
    UserStrCount = 0;             
    int i1 = MSQL.IndexOf("'", StringComparison.OrdinalIgnoreCase);
    if (i1 == -1) return;
    int i2 = MSQL.IndexOf("'", i1 + 1, StringComparison.OrdinalIgnoreCase);                
    while ((i1 > 0) && (i2 > i1))
    {              
        ListUserStr[UserStrCount, sPos] = UserStrCount.ToString();
        ListUserStr[UserStrCount, sRealString] = MSQL.Substring(i1, i2 - i1 + 1);
        ListUserStr[UserStrCount, sRealStringParse] = Var.convertDate4Server(ListUserStr[UserStrCount, sRealString], true);
        ListUserStr[UserStrCount, sUserString] = "USERSTR" + UserStrCount;                  
        MSQL = MSQL.Remove(i1, i2 - i1 + 1);   
        MSQL = MSQL.Insert(i1, "USERSTR" + UserStrCount);
        i1 = MSQL.IndexOf("'", StringComparison.OrdinalIgnoreCase);
        i2 = MSQL.IndexOf("'", i1 + 1, StringComparison.OrdinalIgnoreCase);
        UserStrCount ++;
    }           
}*/

//=======================
/*   >
    // Класс-наследник TextBox, отключающий звук на Enter
    
    public class ExtTextBox : TextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs arg = new KeyEventArgs(keyData);
            if (keyData == Keys.Enter)
            {
                OnKeyDown(arg);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }*/
//=======================
/*           Hmm, this achieves the desired effect but I'm still not happy - any further ideas most welcome!
         Regex allowableChars = new Regex("^[a-z]*$");
         string textBefore = null;
         int selectionStart = 0;
         int selectionLength = 0;
         textInput.KeyDown += (sender, e) =>
            {
               textBefore = textInput.Text;
               selectionStart = textInput.SelectionStart;
               selectionLength = textInput.SelectionLength;               
            };
         textInput.TextChanged += (sender, e) =>
            {
               if (!allowableChars.IsMatch(textInput.Text))
               {
                  textInput.Text = textBefore;
                  textInput.SelectionStart = selectionStart;
                  textInput.SelectionLength = selectionLength;
               }
            };
    
*/
//=======================
//sys.Main11();
/*           sys.SM(sys.GetFormatDate("10.12.2017"));
           sys.SM(sys.GetFormatDate("10-12-2017"));
           sys.SM(sys.GetFormatDate("10/12/2017"));             
           sys.SM(sys.GetFormatDate("2017.10.12"));
           sys.SM(sys.GetFormatDate("2017-10-12"));
           sys.SM(sys.GetFormatDate("2017/10/12"));

           sys.SM(sys.GetFormatDate("100120201"));
           sys.SM(sys.GetFormatDate("1001202017"));
           sys.SM(sys.GetFormatDate("10012020177"));
           sys.SM(sys.GetFormatDate("10'01'2017"));
           sys.SM(sys.GetFormatDate("19.01.2k17"));   



void textBox1_TextChanged(object sender, EventArgs e)
       {
            //textBox1.Text = System.Text.RegularExpressions.Regex.Replace(textBox1.Text,@"[^a-zA-Z]","");
       }
       void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
       {
           //sys.SM(e.KeyValue.ToString());
           //sys.SM(e.KeyData.ToString());
           char ch = (char)e.KeyValue;
           sys.SM(ch.ToString());
       }  */
//=======================

/*private void GreateTableForAttr1()
{                                                                                                                                          
    for (int i = 0; i < AttrTableCount; i++)
    {                                           
        string EntityBrief = AttrTable[i, vEntity];
        string TableType;
        ParserData.GetEntityData1(EntityBrief,                                                                         
                                  out AttrTable[i, vEntityID],
                                  out AttrTable[i, vEntityTableMain],
                                  out TableType,                                                                                                                
                                  out AttrTable[i, vEntityTableFieldID]);
    }                        
}*/
//=======================
//this = parserLocal;
//Остановка после первого уровня вложенности вычисляемого атрибута.            
//if (ParserData.TestDeep == 1) 
//{
//    sys.SM("Остановка после первого уровня вложенности вычисляемого атрибута");
//    return;
//}
//=======================
//Кнопка Test.
//     private void BtnTestClick(object sender, EventArgs e)
//    {
//sys.SM(GetTableByEntityBrief("ДогСтрах11"));
//for (int i = 0; i < dgvString.Columns.Count; i++)
//{
//    textBox2.AppendText(@"dgvString.Columns[" + i.ToString() + "].Width = " + dgvString.Columns[i].Width.ToString() + ";" + Var.CR);
//}
//string s = GetBlockFrom();
//sys.SM(s);
/*string s = "";
for (int i = 0; i < WordCount; i++)
{
    if (Words[i, Lex].IndexOf("ДАТАСОСТОБЪЕКТА", StringComparison.OrdinalIgnoreCase) > -1)
    {                 
        int N = GetEndStateDate(i);
        s = s + "i=" + i + " end: " + N + Var.CR;
        Words[i, BlockEnd] = N.ToString();
    }           
}
sys.SM(s, MessageType.Information);
WordsToMainTable();*/
//     } 
//=======================
/*private void Button1Click(object sender, EventArgs e)
       {                      
           //Из DataSet в XML. Работает.
           DataSet DataSetAdmin;

           Var.conLite.SelectDS("select * from fbaAttr", out DataSetAdmin);
           string s = DataSetAdmin.GetXml();                    

            sys.SM("Объект сериализован");

           //Из XML в DataSet.

           var settings = new XmlReaderSettings {ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = true, IgnoreComments = true};
           var xm1 = XmlReader.Create(new StringReader(s), settings);
           xm1.Read();

           DataSet DataSetAdmin2 = new DataSet();
           DataSetAdmin2.ReadXml(xm1);
           DataTable dt55 = DataSetAdmin.Tables[0];
           dgvSQL1.DataSource = dt55;
           return;
           //==

           /*long size = 0;
           //object obj = new object();
           using (Stream stream = new MemoryStream()) {
               var formatter = new BinaryFormatter();
               formatter.Serialize(stream, DataSetAdmin);
               size = stream.Length; 


               //DataSet DataSetAdmin3 = new DataSet();
               //stream.Seek(0);
               //object obj = new object();
               //obj = formatter.Deserialize(stream);

           } */


//==
//В FileStreem и обратно. Работает.
/*BinaryFormatter formatter2 = new BinaryFormatter();
using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
{
    // сериализуем весь массив people
    formatter2.Serialize(fs, DataSetAdmin);

    sys.SM("Объект сериализован");
}

// десериализация
using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
{
    DataSet deserilizePeople = (DataSet)formatter2.Deserialize(fs);
    DataTable dt1 = DataSetAdmin.Tables[0];
    dgvSQL1.DataSource = dt1;              
}
*/


//DataTable DT = null;
//DT.BeginLoadData();
//DT.EndLoadData();
//DT.Dat
//DataTableReader dt143 = DT.CreateDataReader();
//DataSetAdmin.


// var DataSetAdmin1 = new DataSet("DataSetAdmin");
//DataSetAdmin1,
//XmlReader xm = new DataSet("xmlreader");
//        ToXmlReader(string value)
//DataSetAdmin1.ReadXml(



//DataSet DataSetAdmin1;
//var DataSetAdmin1 = new DataSet("DataSetAdmin");

//DataSetAdmin1.                               

//XmlReader xml1;
//   xml1.
//= new XmlReader();                
//} 
//===============================================            
//Собрать запрос, который вернёт таблицу со всеми историчными атрибутами.
/*private string GetAllHistTableAttr1()
{                         
    string SQL = "SELECT * FROM fbaAttrParent WHERE EnBrief2 = '" + EntityBrief + "' AND Table_Type = 2 ";              
    sys.SelectDT(DirectionQuery.Local, SQL, out DT);           

    StringBuilder str = new StringBuilder();
    str.Append("SELECT" + Var.CR);
    str.Append("tt.ДатаСостАтрибута 'ДатаСостАтрибута', " + Var.CR);
    for (int i = 0; i < DT.Rows.Count; i++)
    {
        string s = "t" + i + ".Значение '" +  DT.Field(i, "Attr_Brief") + "'";
        if (i < (DT.Rows.Count - 1)) s = s + "," + Var.CR;
        str.Append(s);           
    }           
    str.Append(Var.CR + "FROM" + Var.CR);
    str.Append("(" + Var.CR);  
    for (int i = 0; i < DT.Rows.Count; i++)
    {
        string s = "SELECT StateDate ДатаСостАтрибута FROM " + DT.Field(i, "Table_Name") + " WHERE " + DT.Field(i, "Table_IDFieldName") + " = " + ObjectID;
        if (i < (DT.Rows.Count - 1)) s = s + " UNION " + Var.CR;
        str.Append(s);           
    }             
    str.Append(Var.CR + ") tt" + Var.CR);
    for (int i = 0; i < DT.Rows.Count; i++)
    {
        string Alias = "t" + i.ToString();
        string s = "FULL JOIN (SELECT StateDate ДатаСостАтрибута, ISNULL(CONVERT(varchar, " +  DT.Field(i, "Table_Field") + ", 121), '<Пустое>') Значение FROM " + DT.Field(i, "Table_Name") + " WHERE " + DT.Field(i, "Table_IDFieldName") + " = " + ObjectID + ") " + Alias + " ON " + Alias+ ".ДатаСостАтрибута = tt.ДатаСостАтрибута" + Var.CR;
        str.Append(s);           
    }
    return str.ToString();
}/*
*/
//===============================================
//Добавление нового атрибута.
//Type можкт быть: DateTime, Memo, TextBox.
/*private void UniEditLinkAdd(string param1, string param2, string Type)
{                                   
    int ParamWHeight = 27;
    var Lp  = new System.Windows.Forms.TableLayoutPanel();
    var cb1 = new System.Windows.Forms.Label();
    // cb1.
    object cb2 = null;
    if (Type == "TextBox")  cb2 = new System.Windows.Forms.TextBox(); 
    if (Type == "DateTime") 
    {
        cb2 = new System.Windows.Forms.DateTimePicker();
        ((DateTimePicker)cb2).Margin = new System.Windows.Forms.Padding(0);   
        ((DateTimePicker)cb2).CustomFormat = "dd.MM.yyyy HH:mm:ss";                  
        ((DateTimePicker)cb2).Format = System.Windows.Forms.DateTimePickerFormat.Custom;

        //ParamWHeight = 27;
    }
    if (Type == "Memo")    
    {
        cb2 = new FBA.FastColoredTextBoxFBA();
        ((FastColoredTextBoxFBA)cb2).Font = sys.font2;
        ParamWHeight = 100;
    }

    //var Anchor1 = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right| System.Windows.Forms.AnchorStyles.Top);


    //if (Type == "DateTime")
    //{
    //    Lp.ColumnCount = 3;           
    //    Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));              
    //    Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
    //    Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));                            
    //} else
    //{
        Lp.ColumnCount = 3;           
        Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));              
        Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
        Lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));

    //}     

    Lp.Controls.Add(cb1, 0, 0);  
    Lp.Controls.Add((Control)cb2, 1, 0);

    if (Type != "DateTime")
    {            
        Lp.SetColumnSpan((Control)cb2, 2);
        ((Control)cb2).Dock = DockStyle.Fill;
    }
    if (Type == "Memo")
    {
       ((Control)cb2).Dock = DockStyle.Fill;
    }

    if (Type == "TextBox")
    {
        //((Control)cb2).Anchor = Anchor1;
        ((Control)cb2).Dock = DockStyle.Fill;
        ((TextBox)cb2).Multiline = true;
        ((TextBox)cb2).WordWrap  = false;
        ((TextBox)cb2).BorderStyle = System.Windows.Forms.BorderStyle.None;
    }

    ((Control)cb2).Left = 0;
    ((Control)cb2).Top = 0;

    Lp.Name = "LpN" + AttrCount.ToString();
    Lp.RowCount = 1;
    Lp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
    Lp.Size = new System.Drawing.Size(pnlField.Width - 26, ParamWHeight);             
    //Lp.Dock = System.Windows.Forms.DockStyle.Top;
    //Lp.Anchor = Anchor1;   
    //Lp.Width = pnlField.Width - 16;

    //cb1.Anchor = Anchor1;  
    ((Label)cb1).Dock = DockStyle.Fill;             
    cb1.Name = "cb1N" + AttrCount.ToString();              
    cb1.Text = param1;              

    Lp.Parent = pnlField;
    //Lp.Dock = System.Windows.Forms.DockStyle.Bottom;
    Lp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

    //cb2        
    //((Control)cb2).Anchor = Anchor1;
    //((Control)cb2).
    ((Control)cb2).Margin = new System.Windows.Forms.Padding(0);           
    ((Control)cb2).Name = "cb2N" + AttrCount.ToString();;
    ((Control)cb2).BackColor = System.Drawing.SystemColors.Info;
    ((Control)cb2).Text = param2;
    //if (Type == "DateTime")
    //{
    //    ((Control)cb2).Invalidate();
    //}                    
    AttrCount++;     
}*/
//===============================================



/*string s = "SELECT " +  
           "'" + Attr_Brief        + "' AS Attr_Brief, " +
           "'" + Attr_Mask         + "' AS Attr_Mask,  " +
           "'" + Attr_Type         + "' AS Attr_Type,  " +
           "'" + Attr_Kind         + "' AS Attr_Kind,  " +
           "'" + Table_Type        + "' AS Table_Type, " +
           "'" + Table_IDFieldName + "' AS Table_IDFieldName, " + 
           "'" + Table_Name        + "' AS Table_Name, " +
           "'" + Table_Field       + "' AS Table_Field, " +
           "(SELECT TOP 1 DATA_TYPE FROM information_schema.COLUMNS WHERE TABLE_NAME = '" + Table_Name + "' AND COLUMN_NAME = '" + Table_Field + "') AS Column_Type, " +
           //DTAttr.Field(i, "Table_Field") + " AS Attr_Value" + 
           "ISNULL(CONVERT(varchar, " +  Table_Field + ", 121), 'NULL')  AS Attr_Value " +                                      
           " FROM " + DTAttr.Field(i, "Table_Name") + 
           " WHERE " + DTAttr.Field(i, "Table_IDFieldName") + " = " + ObjectID;
if (i < (DTAttr.Rows.Count - 1)) s = s + " UNION ALL " + Var.CR;                                                                                                
str.Append(s);
*/
//===============================================    
/*private void GetSQL_AttrData(string StateDate = "")
{
    //Получение информации по атрибутам.
    string SQL = "SELECT DISTINCT Table_Type, Table_Name, Table_IDFieldName, Table_Field " + sys. CR +
                 "FROM fbaAttrParent " + Var.CR + 
                 "WHERE Attr_Kind = 1 " +
                 "AND Attr_Mask <> '@IMAGE' " +
                 "AND Attr_Type <> '@IMAGE' " +
                 "AND EnBrief2 = '" + EntityBrief + "'";
    sys.SelectDT(DirectionQuery.Local, SQL, out DTAttr);   
    if (StateDate == "") StateDate = "@SD";
    var str =  new StringBuilder();
    for (int i = 0; i < DTAttr.Rows.Count; i++)               
    {  
        SQL = "";
    }
}*/
//===============================================
//Для масштабирования формы.
//private void timer1_Tick(object sender, EventArgs e)
//{
//timer1.Enabled = false;
//for (int i = 0; i < AttrCount; i++) 
//{
//if (ArrObj[i] == null) continue;
//ArrObj[i].Width = pnlField.Width - 26;
//}

//for (int i = 0; i < AttrCount; i++)
//{
//    string N = i.ToString();
//    Control control = pnlField.Controls.Find("LpN" + N, true).FirstOrDefault();
//    if (control != null)              
//        control.Width = pnlField.Width - 26; // = new System.Drawing.Size(pnlField.Width - 16, control.Size.Height);
//}
//}                      


//Изменение размеров панели на которой лежат все полоски.
//private void pnlField_Resize(object sender, EventArgs e)
//{
//    timer1.Enabled = true;
//    return;  
//}

//===============================================

//Собрать запрос для получения значений всех атрибутов.  
/*var str =  new StringBuilder();
str.Append("SELECT t2.*, t1.DATA_TYPE, t1.CHARACTER_MAXIMUM_LENGTH, t1.IS_NULLABLE, t1.TABLE_SCHEMA FROM information_schema.COLUMNS t1 RIGHT JOIN (" + Var.CR);                    
if (StateDate == "") StateDate = "@SD";
for (int i = 0; i < DTAttr.Rows.Count; i++)
{                                        
    string Attr_Brief        = DTAttr.Field(i, "Attr_Brief");
    string Attr_Mask         = DTAttr.Field(i, "Attr_Mask");
    string Attr_Type         = DTAttr.Field(i, "Attr_Type");
    string Attr_Kind         = DTAttr.Field(i, "Attr_Kind");
    string Table_Type        = DTAttr.Field(i, "Table_Type");
    string Table_IDFieldName = DTAttr.Field(i, "Table_IDFieldName");
    string Table_Name        = DTAttr.Field(i, "Table_Name");
    string Table_Field       = DTAttr.Field(i, "Table_Field");
    string Table_Field2      = DTAttr.Field(i, "Table_Field2");                
    SQL = "SELECT " + 
                 "'" + Attr_Brief        + "' AS Attr_Brief, " +
                 "'" + Attr_Mask         + "' AS Attr_Mask,  " +
                 "'" + Attr_Type         + "' AS Attr_Type,  " +
                 "'" + Attr_Kind         + "' AS Attr_Kind,  " +
                 "'" + Table_Type        + "' AS Table_Type, " +
                 "'" + Table_IDFieldName + "' AS Table_IDFieldName, " + 
                 "'" + Table_Name        + "' AS Table_Name, " +
                 "'" + Table_Field       + "' AS Table_Field, " +
                 "'" + Table_Field2      + "' AS Table_Field2 ";                                                                 
    if (i < (DTAttr.Rows.Count - 1)) SQL = SQL + "UNION ALL " + Var.CR;                
    str.Append(SQL);
}
str.Append(Var.CR + ") t2 ON t1.TABLE_NAME = t2.Table_Name AND t1.COLUMN_NAME = t2.Table_Field WHERE t1.DATA_TYPE <> 'image' ORDER BY t2.Attr_Brief ");                           
System.Data.DataTable DTTemp;             
SQL = str.ToString();
sys.SelectDT(DirectionQuery.Remote, SQL, out DTTemp);
*/
//===============================================

//if (sys.SM("Ошибка. Внешний ключ уже существует, но таблица и поле, на которые происходит ссылка другие: " + Var.CR + 
//                   "Таблица: " + TableNameTo2 + Var.CR + 
//                  "Поле: " + FieldNameTo2 + Var.CR +
//                  "Удалить внешний ключ?", MessageType.Question))                 
//               //Удаление внешнего ключа. 
//               SQLForeignKey = SQLForeignKey + "ALTER TABLE " + TableNameFrom + " DROP CONSTRAINT " + ForeignKeyName + ";" + Var.CR;
//           else return false;
//
//===============================================
// void Button5Click(object sender, EventArgs e)
//{
//this.SetValue("Main2.Сокр", "Вид8");
//string s = this.GetValue("Main2.Сокр");    
//this.Write();

//System.Data.DataTable DTArray;
//string ErrorText = ErrorIfNull(Controls, out DTArray);
//sys.DTView(DTArray, "DTArray", "DTArray");
//sys.SM(ErrorText);             
//}               
//===============================================
//Создание внешнего ключа.
/*private bool ForeignKey(out string SQLForeignKey)
{                                                                   
    // Алгоритм действий:

    //1.  Проверить что нет ссылки с старой таблицы и старого поля этого атрибута.
    //2.  НАЙДЕНА ССЫЛКА:
    //3.    Если старая таблица = новой таблице и старое поле = новому полю то:
    //4.      Если создание ключа, то:
    //5.        Если ссылка на новую таблицу, то ничего не делаем.
    //6.        Если ссылка на другую таблицу то удаляем ключ.
    //7.      Если удаление ключа, то удаляем ключ.
    //8.    Если старая таблица <> новой таблице или старое поле <> новому полю то:
    //9.      Если создание ключа, то удаляем ключ.
    //10.     Если удаление ключа, то удаляем ключ.
    //11. НЕ НАЙДЕНА ССЫЛКА: 
    //12.    Ничего не делаем.           
    //13. ===Далее если только создание ссылки, если удаление, то выходим.             
    //14. ===Проверить что нет ссылки с новой таблицы и нового поля этого атрибута.
    //15. НАЙДЕНА ССЫЛКА:
    //16.   Если ссылка указывает на правильную таблицу, то ничего не делаем.
    //17.   Если ссылка указывает на другую таблицу, то удаляем ключ.
    //18. НЕ НАЙДЕНА ССЫЛКА:
    //19.   Создаем новый ключ.

    SQLForeignKey = "";
    string ForeignKeyName = "";
    string ErrorMes = "";
    string SQL = "";

    //Сначала некоторомуоые проверки
    if (Operation == "Add")
    {                              
        //Пока только для MSSQL.
        if (Var.con.ServerType != "MSSQL")  ErrorMes = "Тип сервера " + Var.con.ServerType + " не поддерживается";
        if (tbTypeStr.Text     != "Ссылка") ErrorMes = "Тип атрибута не ссылка"; 

        if (tbTableStr.Text    == "")   ErrorMes = "Ошибка. Не указана таблица атрибута!";
        if (tbField1.Text    == "")   ErrorMes = "Ошибка. Не указано поле таблицы!";
        if (tbLinkToStr.Text == "") ErrorMes = "Ошибка. Не указана сущность на которую происходит ссылка!"; 
        if (ErrorMes != "") 
        {
            sys.SM(ErrorMes);
            return false;
        }
    }

    //Новые данные:
    string NewTableName      = tbTableStr.Text;                    //Новая таблица имя, откуда.
    string NewFieldName      = tbField1.Text;                      //Новое поле, откуда.
    string NewEntityBriefRef = tbLinkToStr.Text;                   //Новая ссылка на указаную сущность сокращение, куда.               
    string NewTableNameRef;                                        //Новая таблица имя, куда.
    string NewIDFieldNameRef;                                      //Новая таблица поле, куда.                                    
    sys.GetMainTableNameByEnBrief(NewEntityBriefRef, out NewTableNameRef, out NewIDFieldNameRef);

    //Старые данные:
    //Имена старых таблиц нужно определить по ID так как имени нет.            
    string OldTableID        = Obj["Main1.TableID"];               //Старая таблица ID, откуда.             
    string OldTableName      = sys.GetTableName(OldTableID);       //Старая таблица имя, откуда.    
    string OldFieldName      = Obj["Main1.FieldName"];             //Старое поле, откуда.                 
    string OldEntityIDRef    = Obj["Main1.RefEntityID"];           //Старая ссылка на указаную сущность ID, куда.          
    string OldTableNameRef;                                        //Старая таблица, куда.
    string OldIDFieldNameRef;                                      //Старая поле таблицы, куда.
    sys.GetMainTableNameByEnID(OldEntityIDRef, out OldTableNameRef, out OldIDFieldNameRef);

    var DT = new System.Data.DataTable();           
    const string SQLTemplate =
    "SELECT                    " + Var.CR +
    "FK.CONSTRAINT_NAME as ForeignKey,       " + Var.CR +
    "  FK.TABLE_NAME    as FROM_TABLE_NAME,  " + Var.CR +
    "  FK.COLUMN_NAME   as FROM_COLUMN_NAME, " + Var.CR +
    "  PK.TABLE_NAME    as TO_TABLE_NAME,    " + Var.CR +
    "  PK.COLUMN_NAME   as TO_COLUMN_NAME    " + Var.CR +
    "FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE PK " + Var.CR +
    "  JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C ON PK.CONSTRAINT_CATALOG=C.UNIQUE_CONSTRAINT_CATALOG AND PK.CONSTRAINT_SCHEMA=C.UNIQUE_CONSTRAINT_SCHEMA AND PK.CONSTRAINT_NAME=C.UNIQUE_CONSTRAINT_NAME " + Var.CR +
    "  JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE FK ON C.CONSTRAINT_CATALOG=PK.CONSTRAINT_CATALOG AND C.CONSTRAINT_SCHEMA=FK.CONSTRAINT_SCHEMA AND C.CONSTRAINT_NAME=FK.CONSTRAINT_NAME AND PK.ORDINAL_POSITION=FK.ORDINAL_POSITION " + Var.CR +
    "WHERE                                   " + Var.CR +
    "      FK.TABLE_NAME  = '{0}'  " + Var.CR + 
    "  AND FK.COLUMN_NAME = '{1}'  " + Var.CR +      
    "ORDER BY FK.CONSTRAINT_NAME, PK.ORDINAL_POSITION ";

    //По старым данным
    SQL = string.Format(SQLTemplate + "", OldTableName, OldFieldName);             
    if (!sys.SelectDT(DirectionQuery.Remote, SQL, out DT)) return false; 

    if (DT.Rows.Count != 0)
    {
        ForeignKeyName = sys.DTValue(DT, "ForeignKey"); 
        if (Operation == "Del")
        {
            SQLForeignKey = SQLForeignKey + "ALTER TABLE " + OldTableName + " DROP CONSTRAINT " + ForeignKeyName + ";" + Var.CR;
            return true;
        }
        if (Operation == "Add")
        {
            string TO_TABLE_NAME = sys.DTValue(DT, "TO_TABLE_NAME"); 
            if ((OldTableName == NewTableName) && (OldFieldName = NewFieldName) && (OldTableNameRef = TO_TABLE_NAME)) SQLForeignKey = "";
            else SQLForeignKey = SQLForeignKey + "ALTER TABLE " + OldTableName + " DROP CONSTRAINT " + ForeignKeyName + ";" + Var.CR;
        }
    }

    if (Operation != "Add") return false;

    //По новым данным
    if ((OldTableName != NewTableName) || (OldFieldName != NewFieldName))
    {
        SQL = string.Format(SQLTemplate + "", NewTableName, NewFieldName);          
        if (!sys.SelectDT(DirectionQuery.Remote, SQL, out DT)) return false;                      
    }

    //Проверяем что внешний ключ уже есть, но может быть он на другую таблицу.
    if (DT.Rows.Count != 0)
    {                              
        string NewTableNameTo = sys.DTValue(DT, "TO_TABLE_NAME");
        string NewFieldNameTo = sys.DTValue(DT, "TO_COLUMN_NAME"); 
        ForeignKeyName        = sys.DTValue(DT, "ForeignKey"); 
        if ((NewTableNameTo != NewTableNameRef) || (NewFieldNameTo != NewIDFieldNameRef))
        { 
           SQLForeignKey = SQLForeignKey + "ALTER TABLE " + OldTableName + " DROP CONSTRAINT " + ForeignKeyName + ";" + Var.CR; 
        }                                             
    }  

    //ALTER TABLE [dbo].[Filial]  WITH NOCHECK ADD  CONSTRAINT [FK_Filial_FaceJuridical] FOREIGN KEY([MainFaceJuridical]) REFERENCES [dbo].[FaceJuridical] ([FaceID])                                
    ForeignKeyName = "FK_" + NewTableName + "_" + NewFieldName;
    SQLForeignKey = SQLForeignKey + string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY({2}) REFERENCES {3}({4});", NewTableName, ForeignKeyName, NewFieldName, NewTableNameRef, NewIDFieldNameRef);                

    return true;
}*/
//=============================================== 
//Перехват вставки текста из буфера обмена.
//protected override void WndProc(ref Message m) 
//{                   
/*if (m.Msg != 0x302)  
{
    base.WndProc(ref m);
    return;
}
if (!Clipboard.ContainsText()) 
{
    base.WndProc(ref m);
    return;
}*/

//f (e.Control && e.KeyCode == Keys.F) 

//  var hkey = new HotKey(Keys.D, KeyModifiers.Alt);
//  hkey.Pressed += (o, d) => { Form2 f = new Form2(); //создаем
//  f.Show(); ; d.Handled = true; };
//   hkey.Register(this);
//                                   
//  const int WM_PASTE = 0x0302;
//   if (m.Msg == WM_PASTE)
//  {           
//if ((!this.IntegerOnly) && (!this.FloatOnly))
//{
//    base.WndProc(ref m);
//    return;
//} 

//     string ClipboardText = Clipboard.GetText();
//     if (!CanInput((char)Keys.Back, ClipboardText)) return;


/*int Len = ClipboardText.Length;
if (Len > 20)
{
    //base.WndProc(ref m);
    return;
}   
if (this.IntegerOnly)  
{
    int NumberInt = 0;                
    if (!sys.IsInteger(ClipboardText, out NumberInt)) return;
}
if (this.FloatOnly)  
{
    if (!sys.IsFloat(ClipboardText)) return;
}*/

//  }
//   base.WndProc(ref m);                            
//}       

//=============================================== 
//public override bool PreProcessMessage(ref Message msg) 
//{
/*if(msg.Msg == WM_KEYDOWN) 
{
    Keys keys = (Keys)msg.WParam.ToInt32();

    //bool numbers = ((keys >= Keys.D0 && keys <= Keys.D9)
    //               || (keys >= Keys.NumPad0 && keys <= Keys.NumPad9)) && ModifierKeys != Keys.Shift;

    bool AllowInput = CanInput(keys, "");

    bool ctrl   = (keys == Keys.Control);
    bool del    = (keys == Keys.Delete);
    bool bksp   = (keys == Keys.Back); 
    bool khome  = (keys == Keys.Home);
    bool kend   = (keys == Keys.End);                     
    bool ctrlZ  = (keys == Keys.Z) && (ModifierKeys == Keys.Control);
    bool ctrlX  = (keys == Keys.X) && (ModifierKeys == Keys.Control);
    bool ctrlC  = (keys == Keys.C) && (ModifierKeys == Keys.Control);
    bool ctrlV  = (keys == Keys.V) && (ModifierKeys == Keys.Control);                        
    bool arrows = (keys == Keys.Up) | (keys == Keys.Down) | (keys == Keys.Left) | (keys == Keys.Right);

    if (AllowInput | ctrl | del | bksp | arrows | ctrlC | ctrlX | ctrlZ | khome | kend) return false;

    if (ctrlV)
    {
       IDataObject obj = Clipboard.GetDataObject();
       string BufferText = (string)obj.GetData(typeof(string));
       if (!CanInput(keys, BufferText)) return true;
       //foreach(char c in BufferText) 
       //{
       //    if(!char.IsDigit(c)) return true;
       //}
       return false;
   } 
   return true;
}        21       
return base.PreProcessMessage(ref msg);
*/
//}    
//=============================================== 
//Если делаем !Enabled то ставим фон Window.
//[Browsable(true)]
//public bool Enabled
//{
//    get { return base.Enabled; }
//    set 
//    {
//        base.Enabled = value;
//        base.BackColor =  System.Drawing.Color.FromKnownColor(KnownColor.Window);
//    }
//}  
//=============================================== 
//char key = Convert.ToChar(keys);   
//=============================================== 
/* var selection = grid.Selection as SelectionBase;

            //columnHeader = new SourceGrid.Cells.ColumnHeader("String");
//SourceGrid.Cells.ColumnHeader columnHeader = new SourceGrid.Cells.ColumnHeader("String");
//columnHeader.View = viewColumnHeader;
   //grid[0,0] = columnHeader;
    //header.AutomaticSortEnabled = false; 
    //header.= grid.DefaultHeight * 2;
    //header.ColumnSelectorEnabled = true;
    //header.ColumnFocusEnabled = true;

cPickSelBackColor.SelectedColor = Color.FromArgb(selection.BackColor.R, selection.BackColor.G, selection.BackColor.B);
cPckBorderColor.SelectedColor = selection.Border.Top.Color;
trackSelectionAlpha.Value = (int)selection.BackColor.A;
trackBorderWidth.Value = (int)selection.Border.Top.Width;

cPickFocusBackColor.SelectedColor = Color.FromArgb(selection.FocusBackColor.R, selection.FocusBackColor.G, selection.FocusBackColor.B);
trackFocusBackColorTrans.Value = selection.FocusBackColor.A;


this.cPickSelBackColor.SelectedColorChanged += new System.EventHandler(this.cPickSelBackColor_SelectedColorChanged);
this.cPckBorderColor.SelectedColorChanged += new System.EventHandler(this.cPckBorderColor_SelectedColorChanged);
this.trackSelectionAlpha.ValueChanged += new System.EventHandler(this.trackSelectionAlpha_ValueChanged);
this.trackBorderWidth.ValueChanged += new System.EventHandler(this.trackBorderWidth_ValueChanged);
this.trackFocusBackColorTrans.ValueChanged += new System.EventHandler(this.trackFocusBackColorTrans_ValueChanged);
this.cPickFocusBackColor.SelectedColorChanged += new System.EventHandler(this.cPickFocusBackColor_SelectedColorChanged);

cbDashStyle.Validator = new DevAge.ComponentModel.Validator.ValidatorTypeConverter(typeof(System.Drawing.Drawing2D.DashStyle));
cbDashStyle.Value = selection.Border.Top.DashStyle;
*/

//=============================================== 
//Класс для перерисовки SourceGrid.
/*public class CellBackColorAlternate: SourceGrid.Cells.Views.Cell
{
    public CellBackColorAlternate(Color firstColor, Color secondColor)
    {
        FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
        SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
    }
    private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
    public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
    {
        get { return mFirstBackground; }
        set { mFirstBackground = value; }
    }
    private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
    public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
    {
        get { return mSecondBackground; }
        set { mSecondBackground = value; }
    }
    protected override void PrepareView(SourceGrid.CellContext context)
    {
        base.PrepareView(context);
        if (Math.IEEERemainder(context.Position.Row, 2) == 0)
            Background = FirstBackground;
        else
            Background = SecondBackground;
    }
}*/

//=============================================== 

//Получение 10-ти значений.
/*public bool GetValue10_old(string SQL, out string s1, out string s2, out string s3, out string s4, out string s5, out string s6, out string s7, out string s8, out string s9, out string s10)
{                               
    s1  = "";
    s2  = "";
    s3  = "";
    s4  = "";
    s5  = "";
    s6  = "";
    s7  = "";
    s8  = "";
    s9  = "";
    s10 = "";

    try
    {                

        if ((ConnectionDirect) && (ServerType == "Postgre"))
        {
            var command1 = new NpgsqlCommand(SQL);
            command1.Connection = connection1;

            NpgsqlDataReader dr = command1.ExecuteReader();
            dr.Read();   
            if (dr.HasRows) 
            {   
                if (dr.FieldCount > 0) s1  = dr[0].ToString();
                if (dr.FieldCount > 1) s2  = dr[1].ToString();
                if (dr.FieldCount > 2) s3  = dr[2].ToString();
                if (dr.FieldCount > 3) s4  = dr[3].ToString();
                if (dr.FieldCount > 4) s5  = dr[4].ToString();
                if (dr.FieldCount > 5) s6  = dr[5].ToString();
                if (dr.FieldCount > 6) s7  = dr[6].ToString();
                if (dr.FieldCount > 7) s8  = dr[7].ToString();
                if (dr.FieldCount > 8) s9  = dr[8].ToString();
                if (dr.FieldCount > 9) s10 = dr[9].ToString();
            }
            dr.Close();                   
        }
        if ((ConnectionDirect) && (ServerType == "MSSQL"))
        {
            var command2 = new SqlCommand(SQL);
            command2.Connection = connection2;
            SqlDataReader dr = command2.ExecuteReader();
            dr.Read();
            if (dr.HasRows) 
            {           
                if (dr.FieldCount > 0) s1  = dr[0].ToString();
                if (dr.FieldCount > 1) s2  = dr[1].ToString();
                if (dr.FieldCount > 2) s3  = dr[2].ToString();
                if (dr.FieldCount > 3) s4  = dr[3].ToString();
                if (dr.FieldCount > 4) s5  = dr[4].ToString();
                if (dr.FieldCount > 5) s6  = dr[5].ToString();
                if (dr.FieldCount > 6) s7  = dr[6].ToString();
                if (dr.FieldCount > 7) s8  = dr[7].ToString();
                if (dr.FieldCount > 8) s9  = dr[8].ToString();
                if (dr.FieldCount > 9) s10 = dr[9].ToString();
            }
            dr.Close();                      
        }
        if (((ConnectionDirect) && ServerType == "SQLite"))
        {        	      
            var command3 = new SQLiteCommand(SQL);
            command3.Connection = connection3; 
            //SQL = "select ID FROM fbaEntity WHERE ID IN (:par1)";
            //command3.Parameters.Add(new SQLiteParameter(){ParameterName = "par1", Value = 1});  //:par1                                  
            SQLiteDataReader dr = command3.ExecuteReader();
            dr.Read();
            if (dr.HasRows) 
            {   
                if (dr.FieldCount > 0) s1  = dr[0].ToString();
                if (dr.FieldCount > 1) s2  = dr[1].ToString();
                if (dr.FieldCount > 2) s3  = dr[2].ToString();
                if (dr.FieldCount > 3) s4  = dr[3].ToString();
                if (dr.FieldCount > 4) s5  = dr[4].ToString();
                if (dr.FieldCount > 5) s6  = dr[5].ToString();
                if (dr.FieldCount > 6) s7  = dr[6].ToString();
                if (dr.FieldCount > 7) s8  = dr[7].ToString();
                if (dr.FieldCount > 8) s9  = dr[8].ToString();
                if (dr.FieldCount > 9) s10 = dr[9].ToString();
            }
            dr.Close();                      
        } 
        if (!ConnectionDirect) 
        {
            System.Data.DataTable DT;                    
            if (!AppSelectDT(SQL, out DT)) return false;
            if (DT.Rows.Count > 0) 
            {   
                if (DT.Columns.Count > 0) s1  = DT.Rows[0][0].ToString();
                if (DT.Columns.Count > 1) s2  = DT.Rows[0][1].ToString();
                if (DT.Columns.Count > 2) s3  = DT.Rows[0][2].ToString();
                if (DT.Columns.Count > 3) s4  = DT.Rows[0][3].ToString();
                if (DT.Columns.Count > 4) s5  = DT.Rows[0][4].ToString();
                if (DT.Columns.Count > 5) s6  = DT.Rows[0][5].ToString();
                if (DT.Columns.Count > 6) s7  = DT.Rows[0][6].ToString();
                if (DT.Columns.Count > 7) s8  = DT.Rows[0][7].ToString();
                if (DT.Columns.Count > 8) s9  = DT.Rows[0][8].ToString();
                if (DT.Columns.Count > 9) s10 = DT.Rows[0][9].ToString();
            }
        }                
        return true;
    }
    catch (Exception e)
    {  
        sys.SM("701. Ошибка выполнения запроса: " + e.Message + Var.CR + SQL);           
        return false;
    }
}*/

//===============================================     

//gridView1.GetRowHandle(0)

/*if (view == null || view.SelectedRowsC
 * 
 * ount == 0) return;
DataRow[] rows = new DataRow[view.SelectedRowsCount];
for (int i = 0; i < view.SelectedRowsCount; i++)
    rows[i] = view.GetDataRow(view.GetSelectedRows()[i]);
view.BeginSort();
try
{
    foreach (DataRow row in rows)
        row.Delete();
}
finally
{
    view.EndSort();
}*/

//if (gridView1 == null || gridView1.SelectedRowsCount == 0) return "";
//
// gridView1.SelectCell.
// DataRow[] rows = new DataRow[gridView1.SelectedRowsCount];
// for (int i = 0; i < gridView1.SelectedRowsCount; i++)
//     rows[i] = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
//  gridView1.BeginSort();


// Obtain the Price column.  
//DevExpress.XtraGrid.Columns.GridColumn col = gridView1.Columns.ColumnByFieldName("Price");

//if (col == null) return;
/*gridView1.BeginSort();
try
{
    // Obtain the number of data rows.  
    int dataRowCount = gridView1.DataRowCount;
    // Traverse data rows and change the Price field values.  
    for (int i = 0; i < dataRowCount; i++)
    {
        object cellValue = gridView1.GetRowCellValue(i, col);
        double newValue = Convert.ToDouble(cellValue) * 0.9;
        gridView1.SetRowCellValue(i, col, newValue);
    }
}
finally { gridView1.EndSort(); }
*/


//DevExpress.XtraGrid.
/* object sdsd = gridView1.GetSelectedCells();

 try
   {
     foreach (DataRow row in rows)
     {
         //row.Delete();
         //DataRow. fi = row.Field("sdfdf");
         //string sd = row.Field("fgg").ToString();
         //DataRowExtensions.fsd =
         //row.RowState

         int jj = gridView1.GetRowHandle(0);
         bool _mark = (bool)gridView1.GetRowCellValue(456, "Mark");

         int i = 0;
         string idstr = (string)gridView1.GetRowCellValue(gridView1.GetRowHandle(i), "Mark");

     }
   }
   finally
   {
     gridView1.EndSort();
   }*/


//}

//===============================================     
//Point p1 = new Point(DGV1.Left, DGV1.Top);
//Point p2 = DGV1.PointToScreen(p1);
// sys.SM("X1 = " + p1.X + Var.CR + "Y1 = " + p1.Y + Var.CR + 
//       "X2 = " + p2.X + Var.CR + "Y2 = " + p2.Y);

//Point ScreenPoint = ((Control)sender).PointToScreen(((Control)sender).Location);
//Point FormPoint = this.PointToClient(ScreenPoint); //this is the Form object

//===============================================     
//gridView1.GetRowCellDisplayText(
//gridView1.GetRowCellDisplayText(
//DG1.Views[0].ExportToPdf
//DG1.Views[0].
//DG1.DefaultView.
//gridView1.
//===============================================     

//Var.con.ConnectionDirect = true;

//Var.CReateFilterMenu(DBG1,toolStrip1, true,true,true,true,true,true,true);       
//for (int i = 0; i < DBG2.ContextMenuStrip.Items.Count; i++) DBG2.ContextMenuStrip.Items[i].Click += OperationClick;             
//for (int i = 0; i < toolStrip1.Items.Count; i++) toolStrip1.Items[i].Click += OperationClick; 


//Var.CReateFilterMenu(DBG2, toolStrip2, true,true,true,true,true,true,true);           
//for (int i = 0; i < DBG2.ContextMenuStrip.Items.Count; i++) DBG2.ContextMenuStrip.Items[i].Click += OperationClick; 
//for (int i = 0; i < toolStrip2.Items.Count; i++) toolStrip2.Items[i].Click += OperationClick;     
//===============================================     
/*string EntityBriefLocal = "";
                string ObjectIDLocal;             
                if (this.Obj != null)
                {
                    Obj.Get_ObjectID_AND_EntityBrief(AttrBrief, out EntityBriefLocal, out ObjectIDLocal);
                    this.EntityBrief = EntityBriefLocal;
                    this.ObjectID = ObjectIDLocal;
                }
                else
                {
                    if (!this.EntityBrief.IsEmpty()) EntityBriefLocal = this.EntityBrief;
                }
                var F = new FormDirectory(EntityBriefLocal, ObjectID, true, true);
                F.ShowDialog();
                this.ObjectID = F.ObjectID;
                */
//===============================================     


//===============================================     
