
 
/*SourceGrid,
DevExpress Grid
Infragistics Grid 
Telerik GridView
*/
//======================================================================
/*SELECT 
DISTINCT
  Z1.ИДСущностиОбъекта,
  --Z2.ИДСущностиОбъекта, 
  --Z1.ДатаСостОбъекта,
  Z1.ДогСтрах,                        
  Z1.Операция,                        
  --Вариант.ВариантДогСтрах as 'Вариант.ВариантДогСтрах', 
  --Вариант.ДатаНачала as 'Вариант.ДатаНачала',             
  --Вариант.ДатаОкончания as 'Вариант.ДатаОкончания',    
  Z2.ДатаНачала DateBeg, 
  Z1.ДатаНачала DateBeg,  
  Z1.Основание as OSN,                         
  Z1.ОснованиеОткрепления
  --Z2.ИДОбъекта
  --Вариант.Основание as 'Вариант.Основание',
  --Вариант.ОснованиеОткрепления as 'Вариант.ОснованиеОткрепления'
  FROM Застрахованный  Z1
  LEFT JOIN Застрахованный  Z2 ON Z2.ИДОБъекта = Z1.ИДОБъекта
WHERE Z1.ДатаСостОбъекта = '02.01.2017'
  AND Z2.ИДОбъекта IN(111)
  --AND Z2.ИДОбъекта IN(222) 
*/
//======================================================================
/*
         //Получить список алиасов
        private void GetAllAliases()
        {   
            /*AliasCount = 0;
            for (int i = 0; i < WordCount; i++)
            {
                if (Words[i, Alias] != "") 
                {
                    AliasTable[AliasCount, 0] = i.ToString();
                    AliasTable[AliasCount, 1] = Words[i, Alias];
                    AliasTable[AliasCount, 2] = Words[i, Lex];
                    AliasTable[AliasCount, 3] = Words[i, LexType];
                    AliasTable[AliasCount, 4] = Words[i, Select];
                    Debug.WriteLine("N: {0}", AliasCount.ToString());
                    AliasCount++;
                }                
            }
            
        }
*/ 
 //======================================================================
/*
         //Массив преобразовать в грид.
        /*private void ArrayToGrid()
        {
            //System.Data.DataTable DT;
            //sys.ArrayToDataTable(TestTable, out DT, 0, 0);
                
            var DT = new System.Data.DataTable();
            for (int i = 0; i < WordX; i++) DT.Columns.Add(TestTable[i,0] + "." + TestTable[i,1]);      
            var word = new string[WordX];                                      
            for (int i = 0; i < WordCount; i++)
            {                
                for (int j = 0; j < WordX; j++) word[j] =  Words[i, j]; 
                DataRow row = DT.NewRow();
                row.ItemArray = word;
                DT.Rows.Add(row);
            }    
            dgvString.DataSource = DT;
            //grid2.
            //grid1.DataSource = DT;             
            //arrayGrid1.DataSource = Words;
            //arrayGrid1.
            //arrayGrid1.            
        }
*/
//======================================================================
/*
        
        
        /*private void FindTables(string attr)
        {                          
            string[] ar = attr.Split('.');
            var attrtable = new string[100, 2];  //Это строки в запросе.
                                       
          
            
            
             Select
                  EOT_16.VIPCuratorID "ВИПВрачКуратор"
                From
                  RelContFace EOT_1
                  Left Outer Join RelContFace_Hist_FaceVariant EOT_7
                    On (EOT_7.ID = EOT_1.ID) And (EOT_7.StateDate = (
                      Select
                        Max(StateDate)
                      From
                        RelContFace_Hist_FaceVariant
                      Where
                        (StateDate <= Convert(DateTime, '20170621 23:59:59', 112)) And (EOT_1.ID = ID)
                    ))
                  Left Outer Join FaceVariant     EOT_11 On EOT_11.ID = EOT_7.FaceVariant
                  Left Outer Join ContractVariant EOT_16 On EOT_16.ID = EOT_11.ContractVariantID
                Where
                  EOT_1.ID = 123443*/
            
            
                          
            
            
//            string[,] attrtable = {
//             {"1", "Num"},
//             {"2", "Lex"},
//             {"3", "Brace"},
//             {"4", "BraceLevel"},
//             {"5", "BraceNum"},
//             {"6", "BlockEnd"},
//             {"7", "Proc"},
//             {"8", "LexType"},
//             {"9", "Alias"}                      
//        };
               /*
            //select Застрахованный.ФЛ.НаФа from Застрахованный where ИДОбъекта = 123443  
            Select
              EOT_11.Name "НаФа"
            From
              RelContFace EOT_1
              Left Outer Join FacePerson EOT_11 On EOT_11.FaceID = EOT_1.FaceID
            Where
              EOT_1.ID = 123443
            / *
              //Z1.Вариант.ВариантДогСтрах.ВИПВрачКуратор
            //Застрахованный.Вариант.ВариантДогСтрах.ВИПВрачКуратор
            
             
            for (int i = 1; i < WordCount; i++)
            {
                //Поиск если стоит AS.
                if (Words[i, LexType] == "ENTITY")
                {                            
                    
                    //dgvQueryTables
                    //Words[i + 1, Proc]    = "ALIAS 1";
                    //Words[i + 1, LexType] = "ALIAS";
                    //continue;
                } 
                
              
            }
                                                                          
        }                
         
*/
 //======================================================================
/*
    
    public class DataTableView1: Form
    {        
        private FBA.DataGridViewFBA   dgv;
        private FBA.LabelFBA   label;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.Button  buttonOK;
        private System.Windows.Forms.Button  buttonCancel;
        
        private FormDGV(string Caption, string Text)
        {
            this.dgv = new FBA.DataGridViewFBA();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(500, 319);
            this.dataGridView1.TabIndex = 0;
            // 
            // FormDataTable
            // 
            this.ClientSize = new System.Drawing.Size(500, 319);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDataTable";
            this.Text = "FormDataTable";
            this.ResumeLayout(false);
            
           this.label = new FBA.LabelFBA();
            this.textValue = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(9, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(31, 13);
            this.label.TabIndex = 1;
            this.label.Text = Text;
            this.textValue.Location = new System.Drawing.Point(12, 31);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(245, 20);
            this.textValue.TabIndex = 2;
            this.textValue.WordWrap = false;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(57, 67);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(138, 67);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(270, 103);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textValue);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Caption;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
   
    
*/
//======================================================================
/*
     /*       string[] teams = {"Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона"};
            var selectedTeams = from t in teams // определяем каждый объект из teams как t
                    where 1=1 //t.ToUpper().StartsWith("Б") //фильтрация по критерию
                    orderby t  // упорядочиваем по возрастанию
                    select t; // выбираем объект
            
             // Query the SalesOrderHeader table for orders placed 
            // after August 8, 2001.
            IEnumerable<DataRow> query =
                from order in orders.AsEnumerable()
                where order.Field<DateTime>("OrderDate") > new DateTime(2001, 8, 1)
                select order;
                
            DataTable orders = ds.Tables["SalesOrderHeader"];
DataTable details = ds.Tables["SalesOrderDetail"];
var query =
    from order in orders.AsEnumerable()
    join detail in details.AsEnumerable()
    on order.Field<int>("SalesOrderID") equals
        detail.Field<int>("SalesOrderID")
    where order.Field<bool>("OnlineOrderFlag") == true
    && order.Field<DateTime>("OrderDate").Month == 8
    select new
    {
        SalesOrderID =
            order.Field<int>("SalesOrderID"),
        SalesOrderDetailID =
            detail.Field<int>("SalesOrderDetailID"),
        OrderDate =
            order.Field<DateTime>("OrderDate"),
        ProductID =
            detail.Field<int>("ProductID")
    };
*/
//======================================================================
/*
 //DataRow a = from r in DTAttr.Rows where  r["sd"] == "" select r;
            
            
           /* var match =
                from row in DTAttr.AsEnumerable()
                where row.Field<string>("Entity_Brief") == Entity &&  row.Field<string>("Attr_Brief") == Attr 
                select row;
            DataTable DT = match.CopyToDataTable<DataRow>();
            
            DataTableView.DTView("Поиск Entity_Brief и Attr_Brief", DT);
            */
            //DataRow[] r;
            //r[1].
            //query.
            //return true; 
//======================================================================
/*
 select 
  distinct                      
  ДогСтрах,                        
  Операция,                        
  Вариант.ВариантДогСтрах as 'Вариант.ВариантДогСтрах', 
  Вариант.ДатаНачала as 'Вариант.ДатаНачала',             
  Вариант.ДатаОкончания as ''Вариант.ДатаОкончания',    
  ДатаНачала,                     
  ДатаОкончания,                   
  Основание,                         
  ОснованиеОткрепления,            
  Вариант.Основание as 'Вариант.Основание',
  Вариант.ОснованиеОткрепления as 'Вариант.ОснованиеОткрепления'
  from Застрахованный              
  where ИДОбъекта in(35434)
*/
//======================================================================
/*
 SELECT TOP 121
    t1.Number              AS col1,
    t1.Curator             AS col6,
    123123.23343           number1,
    SUM(t1.SUMCurator)     AS col7
FROM
    (SELECT top 134
        Z1.ДогСтрах.СтрахПродукт         AS Product,
        Z1.Вариант.ВариантДогСтрах.Координатор.Наим                   AS Coordinator,
        Застрахованный.ФЛ.НаФа ФИО,
        (CASE WHEN Z1.Вариант.ВариантДогСтрах.ВИПВрачКуратор  IS NOT NULL THEN 1 ELSE 0 END ) AS SUMVIPCurator,
        ДатаНачала,
        Диагноз,
        FROM Застрахованный Z1
        JOIN  ФЛ ON 1=1
        LEFT  JOIN ФЛ  ON 1=1
        RIGHT JOIN ФЛ  ON 1=1
        FULL  JOIN ФЛ  ON 1=1
        INNER JOIN ФЛ  ON 1=1
        LEFT  OUTER JOIN ФЛ  ON 1=1
        RIGHT OUTER JOIN ФЛ  ON 1=1
        FULL  OUTER JOIN ФЛ  ON 1=1
        --CROSS JOIN ФЛ --ON 1=1
        LEFT JOIN ФЛ RIGHT JOIN ФЛ  ON 1=1  ON 1=1
    UNION SELECT 1,2,3 FROM Застрахованный Z2 WHERE 1=1
    UNION SELECT 1,2,3 FROM Застрахованный Z2 WHERE Z1.ДатаОкончания > GetDate() GROUP BY 1,2,3 ORDER BY  ff,33
    ) t1
  LEFT    JOIN ФЛ  ON 1=1
  GROUP BY
    t1.Product,
    t1.Filial
ORDER BY 1,2,3,4
UNION SELECT 1,2,3,4 FROM Застрахованный Z2 WHERE Z1.ДатаОкончания > GetDate() GROUP BY 1,2,3 ORDER BY  ff,33
UNION SELECT 1,2,3,4 FROM Застрахованный Z2 WHERE Z1.ДатаОкончания > GetDate() GROUP BY 1,2,3 ORDER BY  ff,33
//======================================================================
/*
            //string str = "ляляляля";
    //bool IsDigit = str.Length == str.Where(c => char.IsDigit(c)).Count();  
*/ 
//======================================================================
/*
           //for (int i = 0; i < WordY; i++) 
            //  for (int j = 0; j < WordX; j++) Words[i, j] = "";   
*/ 
 //======================================================================
/*
 //Массив преобразовать в DataTable. ColumnCaption - через точку с запятой. Max = 0, значит все. ShowNum - показывать порядковый номер строки.
        public static bool ArrayToDataTable(string[,] ar, string ColumnCaption, out System.Data.DataTable DT, int MaxX, int MaxY, bool ShowNum)
        {                                                                                         
            DT = new System.Data.DataTable();  
            if (MaxY < 1) MaxY = ar.GetLength(0);
            if (MaxX < 1) MaxX = ar.GetLength(1);
            string [] Cap = ColumnCaption.Split(';');            
                        
            for (int i = 0; i < Cap.Length; i++) DT.Columns.Add(Cap[i]);           
            int N = 0;
            if (ShowNum) N = 1;
            if (Cap.Length != MaxX + N) 
            {
                sys.SM("Количество колонок в ColumnCaption должно быть равно " + (MaxX + N).ToString() + "!");
                return false;
            }
            try
            {
                var word = new string[MaxX + N];             
                for (int i = 0; i < MaxY; i++)
                {                
                    if (ShowNum) word[0] = i.ToString();
                    for (int j = 0; j < MaxX; j++) word[j + N] = ar[i,j];
                    DataRow row = DT.NewRow();
                    row.ItemArray = word;
                    DT.Rows.Add(row);
                }   
                return true;
            } catch (Exception ex)
            {
                sys.SM(ex.Message);
                return false;
            }                                  
        }
*/
//======================================================================
/*
             
            /*var salmons = new List<string>();
            salmons.Add("chinook");
            salmons.Add("coho");
            salmons.Add("pink");
            salmons.Add("sockeye");
            
           
            // Iterate through the list. 
            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
            */
                
            //DataTable DT;
            //DT.Columns.
            //DT.Columns[1].
            /*string[] s = DT.Columns.Select(column => column.ColumnName).ToArray();
            try
            {               
                var lines = new List<string>();
                string[] columnNames = DT.Columns.Cast<DataColumn>().Select(column => column.ColumnName + ":" + column.DataType.ToString().Replace("System.", "")).ToArray();
                lines.Add(string.Join("|", columnNames));         
                lines.AddRange(DT.AsEnumerable().Select(row => string.Join(";", row.ItemArray)) );                                                                    
                string TableString = string.Join(Var.CR, lines.ToArray()); 
                //return true;
                
            } catch  
            {
            }
            */
            //DGV .
            //int[] a = { 1, 2, 3 };
            //string s = string.Join(",", a);
            //string[] s = DGV.Columns
                
                //string[] columnNames = DGV.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
                
             //string s = string.Join(";", DGV.Columns
            
 
 //======================================================================
/*
                  //string[] numbers = { "40", "2012", "176", "5" };
            //Преобразуем массив строк в массив типа int используя LINQ
            //int[] nums = numbers.Select(s1 => Int32.Parse(s1)).ToArray();            
            //foreach (int n in nums) Console.Write(n + " ");                       
            //DataTable DT;
            
            //string[] f1 = 
            //DataRow dt7;
            //string ff = dt7[1].ToString();
        
                     //dtt.
            //DT.Columns.
            //DT.Columns[1].
            //string[] s = DT.Columns.Select(column => column.ColumnName).ToArray();
            /*try
            {               
                var lines = new List<string>();
                string[] columnNames = DT.Columns.Cast<DataColumn>().Select(column => column.ColumnName + ":" + column.DataType.ToString().Replace("System.", "")).ToArray();
                lines.Add(string.Join("|", columnNames));         
                lines.AddRange(DT.AsEnumerable().Select(row => string.Join(";", row.ItemArray)) );                                                                    
                string TableString = string.Join(Var.CR, lines.ToArray()); 
                //return true;
                
            } catch  
            {
            }
            */
            
            //for (int i = 0; i < .Count; i++)
            //{
                //string sym = ";";
                //if (i == DGV.Columns.Count - 1) sym = "";
                // Result = Result + i.ToString() + "." + DGV.Columns[i].HeaderText + sym;
            //} 
 
//======================================================================
/*
  //Определение данных по атрибуту.
        /*private void FindAttrData()
        {                                               
            for (int i = 0; i < WordCount; i++)
            {
                if (Words[i, Entity] != "") CreateTableAttr(i, Words[i, Entity] , Words[i, Lex]);
                if (Words[i, LexType] == "ENTITY") 
                {                      
                    int Pos = GetTable(Words[i, Lex]);
                    if (Pos > -1)
                    {
                        Words[i, TableName]   = sys.DTValue(DTUnion, Pos, "TableName");
                        Words[i, IDFieldName] = sys.DTValue(DTUnion, Pos, "IDFieldName");
                    }                   
                }
            }
        }
        
        //Составление таблицы, в которой будет инормация по составному атрибуту.
        private void CreateTableAttr(int Pos, string Entity, string Attr)
        {
            //Entity - это первая сущность, с которой начинается атрибут.
            string[] mattr = Attr.Split('.');
            //Различные ситуации:
            //Атрибут из базы данных (т.е. есть какое-либо поле в таблице в БД):
            //1. Атрибут одинарный (не составной), НЕ историчный. НЕ ссылка.
            //2. Атрибут одинарный (не составной), НЕ историчный. Является ссылкой.
            //3. Атрибут одинарный (не составной), историчный. НЕ ссылка.
            //4. Атрибут одинарный (не составной), историчный. Является ссылкой.
            //5. Атрибут одинарный (не составной), является универсальной ссылкой.
            //6. Атрибут одинарный (не составной), является массивом.
            
            //Атрибут не из базы данных.
            //7. Атрибут одинарный (не составной), является системным.
            //8. Атрибут одинарный (не составной), является вычисляемым.
            
            //Застрахованный - Entity
            //ФЛ
            //QueryCount = 0;
            for (int i = 0; i < DTAttr.Rows.Count; i++)
            {
                if ((DTAttr.Rows[i]["Entity_Brief"].ToString() == Entity) && (DTAttr.Rows[i]["Attr_Brief"].ToString() == mattr[0]))
                {
                    //Добавляем в ListQuery: 
                    ListQuery[QueryCount, 0]                  = QueryCount.ToString();                     
                    ListQuery[QueryCount, Entity_ID]          = DTAttr.Rows[i][Entity_ID].ToString();
                    ListQuery[QueryCount, Entity_Brief]       = DTAttr.Rows[i][Entity_Brief].ToString();
                    ListQuery[QueryCount, Entity_Name]        = DTAttr.Rows[i][Entity_Name].ToString();
                    ListQuery[QueryCount, Entity_Feature]     = DTAttr.Rows[i][Entity_Feature].ToString();
                    ListQuery[QueryCount, Entity_TableCount]  = DTAttr.Rows[i][Entity_TableCount].ToString();
                    ListQuery[QueryCount, Entity_parentBrief] = DTAttr.Rows[i][Entity_parentBrief].ToString();
                    ListQuery[QueryCount, Entity_Comment]     = DTAttr.Rows[i][Entity_Comment].ToString();
                    ListQuery[QueryCount, Table_ID]           = DTAttr.Rows[i][Table_ID].ToString();
                    ListQuery[QueryCount, Table_Name]         = DTAttr.Rows[i][Table_Name].ToString();
                    ListQuery[QueryCount, Table_Field]        = DTAttr.Rows[i][Table_Field].ToString();
                    ListQuery[QueryCount, Table_Type]         = DTAttr.Rows[i][Table_Type].ToString();
                    ListQuery[QueryCount, Table_Feature]      = DTAttr.Rows[i][Table_Feature].ToString();
                    ListQuery[QueryCount, Attr_ID]            = DTAttr.Rows[i][Attr_ID].ToString();
                    ListQuery[QueryCount, Attr_Brief]         = DTAttr.Rows[i][Attr_Brief].ToString();
                    ListQuery[QueryCount, Attr_Name]          = DTAttr.Rows[i][Attr_Name].ToString();
                    ListQuery[QueryCount, Attr_Type]          = DTAttr.Rows[i][Attr_Type].ToString();
                    ListQuery[QueryCount, Attr_View]          = DTAttr.Rows[i][Attr_View].ToString();
                    ListQuery[QueryCount, Attr_Code]          = DTAttr.Rows[i][Attr_Code].ToString();                  
                    ListQuery[QueryCount, Attr_Feature]       = DTAttr.Rows[i][Attr_Feature].ToString();
                    ListQuery[QueryCount, Attr_Mask]          = DTAttr.Rows[i][Attr_Mask].ToString();
                    ListQuery[QueryCount, Attr_LinkEntity]    = DTAttr.Rows[i][Attr_LinkEntity].ToString();
                    ListQuery[QueryCount, Attr_LinkAttr]      = DTAttr.Rows[i][Attr_LinkAttr].ToString();
                    ListQuery[QueryCount, Attr_Field2]        = DTAttr.Rows[i][Attr_Field2].ToString();
                    ListQuery[QueryCount, Attr_Comment]       = DTAttr.Rows[i][Attr_Comment].ToString();
                    
                    ListQuery[QueryCount, Attr_Comment + 1]                = i.ToString();   
                    ListQuery[QueryCount, Attr_Comment + 2]                = Attr;                     
                     
                    
                    QueryCount ++;
                    break;
                }                     
            }
        }        
*/
//======================================================================
/*
         //Определение данных по простому атрибуту.
        /*private void FindAttrData()
        {                                               
            for (int i = 0; i < WordCount; i++)
            {
                if (Words[i, Entity] != "") CreateTableAttr(i, Words[i, Entity] , Words[i, Lex]);
                if (Words[i, LexType] == "ENTITY") 
                {                      
                    int Pos = GetTable(Words[i, Lex]);
                    if (Pos > -1)
                    {
                        Words[i, TableName]   = sys.DTValue(DTUnion, Pos, "TableName");
                        Words[i, IDFieldName] = sys.DTValue(DTUnion, Pos, "IDFieldName");
                    }                   
                }
            }
        }
        
        //Составление таблицы, в которой будет инормация по составному атрибуту.
        private void CreateTableAttr(int Pos, string Entity, string Attr)
        {
            //Entity - это первая сущность, с которой начинается атрибут.
            string[] mattr = Attr.Split('.');
            //Различные ситуации:
            //Атрибут из базы данных (т.е. есть какое-либо поле в таблице в БД):
            //1. Атрибут одинарный (не составной), НЕ историчный. НЕ ссылка.
            //2. Атрибут одинарный (не составной), НЕ историчный. Является ссылкой.
            //3. Атрибут одинарный (не составной), историчный. НЕ ссылка.
            //4. Атрибут одинарный (не составной), историчный. Является ссылкой.
            //5. Атрибут одинарный (не составной), является универсальной ссылкой.
            //6. Атрибут одинарный (не составной), является массивом.
            
            //Атрибут не из базы данных.
            //7. Атрибут одинарный (не составной), является системным.
            //8. Атрибут одинарный (не составной), является вычисляемым.
            
            //Застрахованный - Entity
            //ФЛ
            //QueryCount = 0;
            for (int i = 0; i < DTAttr.Rows.Count; i++)
            {
                if ((DTAttr.Rows[i]["Entity_Brief"].ToString() == Entity) && (DTAttr.Rows[i]["Attr_Brief"].ToString() == mattr[0]))
                {
                    //Добавляем в ListQuery: 
                    ListQuery[QueryCount, 0]                  = QueryCount.ToString();                     
                    ListQuery[QueryCount, Entity_ID]          = DTAttr.Rows[i][Entity_ID].ToString();
                    ListQuery[QueryCount, Entity_Brief]       = DTAttr.Rows[i][Entity_Brief].ToString();
                    ListQuery[QueryCount, Entity_Name]        = DTAttr.Rows[i][Entity_Name].ToString();
                    ListQuery[QueryCount, Entity_Feature]     = DTAttr.Rows[i][Entity_Feature].ToString();
                    ListQuery[QueryCount, Entity_TableCount]  = DTAttr.Rows[i][Entity_TableCount].ToString();
                    ListQuery[QueryCount, Entity_parentBrief] = DTAttr.Rows[i][Entity_parentBrief].ToString();
                    ListQuery[QueryCount, Entity_Comment]     = DTAttr.Rows[i][Entity_Comment].ToString();
                    ListQuery[QueryCount, Table_ID]           = DTAttr.Rows[i][Table_ID].ToString();
                    ListQuery[QueryCount, Table_Name]         = DTAttr.Rows[i][Table_Name].ToString();
                    ListQuery[QueryCount, Table_Field]        = DTAttr.Rows[i][Table_Field].ToString();
                    ListQuery[QueryCount, Table_Type]         = DTAttr.Rows[i][Table_Type].ToString();
                    ListQuery[QueryCount, Table_Feature]      = DTAttr.Rows[i][Table_Feature].ToString();
                    ListQuery[QueryCount, Attr_ID]            = DTAttr.Rows[i][Attr_ID].ToString();
                    ListQuery[QueryCount, Attr_Brief]         = DTAttr.Rows[i][Attr_Brief].ToString();
                    ListQuery[QueryCount, Attr_Name]          = DTAttr.Rows[i][Attr_Name].ToString();
                    ListQuery[QueryCount, Attr_Type]          = DTAttr.Rows[i][Attr_Type].ToString();
                    ListQuery[QueryCount, Attr_View]          = DTAttr.Rows[i][Attr_View].ToString();
                    ListQuery[QueryCount, Attr_Code]          = DTAttr.Rows[i][Attr_Code].ToString();                  
                    ListQuery[QueryCount, Attr_Feature]       = DTAttr.Rows[i][Attr_Feature].ToString();
                    ListQuery[QueryCount, Attr_Mask]          = DTAttr.Rows[i][Attr_Mask].ToString();
                    ListQuery[QueryCount, Attr_LinkEntity]    = DTAttr.Rows[i][Attr_LinkEntity].ToString();
                    ListQuery[QueryCount, Attr_LinkAttr]      = DTAttr.Rows[i][Attr_LinkAttr].ToString();
                    ListQuery[QueryCount, Attr_Field2]        = DTAttr.Rows[i][Attr_Field2].ToString();
                    ListQuery[QueryCount, Attr_Comment]       = DTAttr.Rows[i][Attr_Comment].ToString();
                    
                    ListQuery[QueryCount, Attr_Comment + 1]                = i.ToString();   
                    ListQuery[QueryCount, Attr_Comment + 2]                = Attr;                     
                     
                    
                    QueryCount ++;
                    break;
                }                     
            }
        } */        
        
        
        
       
 
//======================================================================
/*
  
Выбрать
  Сущность.ИДОбъекта 'Entity_ID',
  Сущность.Сокр      'Entity_Brief',
  Сущность.Наим      'Entity_Name',
  Сущность.Признаки  'Entity_Feature',
  Сущность.Таблицы.КоличОбъектовМассива 'Entity_TableCount',
  Сущность.Родитель.Сокр 'Entity_ParentBrief',
  Сущность.Комментарий   'Entity_Comment',
  Таблица.ИДОбъекта     'Table_ID',
  Таблица.Наим          'Table_Name',
  Поле                  'Table_Field',
  Таблица.ПолеИДОбъекта 'Table_IDFieldName',
  Таблица.Тип           'Table_Type',
  Таблица.Признаки      'Table_Feature',
  ИДОбъекта             'Attr_ID',
  Сокр                  'Attr_Brief',
  Наим                  'Attr_Name',
  Тип.Наим              'Attr_Type',
  Вид.Наим              'Attr_View',
  Код                   'Attr_Code',
  Признаки              'Attr_Feature',
  Маска                 'Attr_Mask',
  СсылкаНаСущность.Сокр 'Attr_LinkBrief',
  СсылкаНаАтрибут.Сокр  'Attr_LinkAttr',
  Поле2                 'Attr_Field2',
  Комментарий           'Attr_Comment'
Из
  АтрибутСущности
Упоряд По
  Сущность.Сокр, Сокр
  
  
  
  
  
Select
  EOT_2.ID "Entity_ID",
  EOT_2.Brief "Entity_Brief",
  EOT_2.Name "Entity_Name",
  EOT_2.Feature "Entity_Feature",
  EOT_3.N "Entity_TableCount",
  EOT_5.Brief "Entity_ParentBrief",
  EOT_2.Description "Entity_Comment",
  EOT_6.TableID "Table_ID",
  EOT_6.Name "Table_Name",
  EOT_1.FieldName "Table_Field",
  EOT_6.IDFieldName "Table_IDFieldName",
  EOT_6.Type "Table_Type",
  EOT_6.Feature "Table_Feature",
  EOT_1.AttributeID "Attr_ID",
  EOT_1.Brief "Attr_Brief",
  EOT_1.Name "Attr_Name",
  EOT_7.Name "Attr_Type",
  EOT_8.Name "Attr_View",
  EOT_1.Code "Attr_Code",
  EOT_1.Feature "Attr_Feature",
  EOT_1.Mask "Attr_Mask",
  EOT_9.Brief "Attr_LinkBrief",
  EOT_10.Brief "Attr_LinkAttr",
  EOT_1.FieldName2 "Attr_Field2",
  EOT_1.Description "Attr_Comment"
From
  fbaAttribute EOT_1
  Left Outer Join fbaAttribute EOT_10
    On EOT_10.AttributeID = EOT_1.RefAttributeID
  Left Outer Join fbaEntity EOT_9
    On EOT_9.ID = EOT_1.RefEntityID
  Left Outer Join fbaAttributeKind EOT_8
    On EOT_8.AttributeKindID = EOT_1.Kind
  Left Outer Join fbaAttributeType EOT_7
    On EOT_7.AttributeTypeID = EOT_1.Type
  Left Outer Join fbaTable EOT_6
    On EOT_6.TableID = EOT_1.TableID
  Left Outer Join fbaEntity EOT_2
    On EOT_2.ID = EOT_1.AttributeEntityID
  Left Outer Join fbaEntity EOT_5
    On EOT_5.ID = EOT_2.ParentID
  Left Outer Join (
    Select
      EOT_4.TableEntityID F,
      Count(*)
      N
    From
      fbaTable EOT_4
    Group By
      EOT_4.TableEntityID
  ) EOT_3
    On EOT_3.F = EOT_2.ID
Order By
  EOT_2.Brief , EOT_1.Brief  
*/ 
 
//======================================================================
/*
        //Поиск имени таблицы и поля для простого атрибута. Метод только для FindSimpleAttrData. 
        /*private void GetAttrData(string Entity, string Attr, out string FTableName, out string FTableField, out string FIDFieldName)
        {
            FTableName   = "";
            FTableField  = "";
            FIDFieldName = "";
            DataRow[] rows1 = DTAttr.Select("Entity_Brief = '" + Entity + "' and Attr_Brief = '" + Attr + "'");
            if (!rows1.Any()) return;                         
            FTableName   = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Name")].ToString(); 
            FTableField  = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Field")].ToString();    
            FIDFieldName = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_IDFieldName")].ToString();               
        }  
*/
//======================================================================
/*
        
        //Ищем имя таблицы в DataTable DTUnion, для сущности EntityBrief с типом 1. Только для FindTablesForEntity.
        /*private int GetTableByEntityBrief(string EntityBrief)
        {                                                         
           DataRow[] rows1 = DTUnion.Select("TableType = '1' and EnBrief2 = '" + EntityBrief + "'");
            if (!rows1.Any()) return -1;                         
            string PosTable = rows1[0].ItemArray[DTUnion.Columns.IndexOf("Pos")].ToString();             
            return Convert.ToInt32(PosTable);   
        }  
*/ 
/*
//Определение таблицы (основной) для сущности. Поля TableName, IDFieldName. 
        private void FindTablesForEntity()
        {   //DTEntity                                            
            //Попробовал через LINQ, медленнее. Здесь 2 против 50 через LINQ.
            for (int i = 0; i < WordCount; i++)
            {                
                if (Words[i, LexType] != "ENTITY") continue;
                for (int j = 0; j < DTUnion.Rows.Count; j++)
                {
                    if ((DTUnion.Rows[j]["TableType"].ToString() == "1") && (DTUnion.Rows[j]["EnBrief2"].ToString() == Words[i, Lex]))
                    {
                        Words[i, TableName]    = DTUnion.Rows[j]["TableName"].ToString();  
                        Words[i, TableFieldID] = DTUnion.Rows[j]["IDFieldName"].ToString();   
                        Words[i, TableType]    = "1";
                        break;
                    }
                }
            }
        }
  */
//======================================================================
/*
--Создание таблицы, в которой будут собраны все атрибуты, сущности, 
--и таблицы и имя главного поля в таблице.                       
--Вложенность сущностей

DROP TABLE #EntityParent
DROP TABLE #AttrParent
DROP TABLE #AttrChild
DROP TABLE #Attr
DROP TABLE dbo.A_Attr
DROP TABLE dbo.A_EntityParent
DROP TABLE dbo.A_AttrParent
DROP TABLE dbo.A_AttrChild
--Вложенность сущностей
;WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID) AS
      (
        SELECT ID AS EnChildID, Brief AS EnBrief2, ID as EnID, Brief as EnBrief1, ParentID from fbaEntity
        --where ID = 1717
        UNION ALL
        SELECT EnChildID, EnBrief2, e.ID as EnID, e.Brief as EnBrief1, e.ParentID 
        FROM fbaEntity e INNER JOIN Parents p ON p.ParentID = e.ID
      ) SELECT * INTO #EntityParent FROM Parents ORDER BY EnBrief2, EnBrief1      
 
--Добавляем все таблицы, соединяя по ID
--SELECT t1.TableID, t1.Name as TableName, t1.IDFieldName, t1.Type as TableType, t1.Feature, 
--       t2.EnChildID, t2.EnBrief2, t2.EnID, t2.EnBrief1, t2.ParentID INTO dbo.A_mtEntity
--FROM #Tabl2 t2 
--  LEFT JOIN fbaTable t1 ON t1.TableEntityID = t2.EnID ORDER BY t2.EnBrief1 
      
--Подготовка таблицы с атрибутами
SELECT 
  AttributeID       AS ID,
  EntityID          AS EntityID,
  AttributeEntityID AS Attr_EntityID,
  Name              AS Attr_Name, 
  Brief             AS Attr_Brief,
  Type              AS Attr_Type,
  Kind              AS Attr_Kind,                             
  Mask                AS Attr_Mask,
  Feature            AS Attr_Feature,
  ObjectNameOrder   AS Attr_NameOrder,
  Code                AS Attr_Code,
  Description       AS Attr_Comment,
  TableID           AS Table_ID,
  FieldName         AS Table_Field,
  FieldName2        AS Table_Field2,
  RefEntityID        AS Ref_EntityID,
  RefAttributeID    AS Ref_AttrID
INTO #Attr     
FROM fbaAttribute 
     
ALTER TABLE #Attr ADD Table_Name varchar(100);            --Данные по таблице, в которой находится атрибут. Имя таблицы.
ALTER TABLE #Attr ADD Table_IDFieldName varchar(100);   --Данные по таблице, в которой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа)
ALTER TABLE #Attr ADD Table_Type int;                    --Тип таблицы (Главная или Историчная)
ALTER TABLE #Attr ADD Table_Feature int;                --Свойства таблицы.
ALTER TABLE #Attr ADD Ref_EntityBrief varchar(100);        --Сокращение сущности для атрибута Ссылки или Массива
ALTER TABLE #Attr ADD Ref_AttrBrief varchar(100);        --Сокращение атрибута сущности для атрибута Ссылки или Массива
ALTER TABLE #Attr ADD Ref_AttrName varchar(100);        --Наименование атрибута сущности для атрибута Ссылки или Массива
ALTER TABLE #Attr ADD Attr_EntityBrief varchar(100);    --Сокращение сущности, к которой относится атрибут.
--Данные по таблице атрибута
UPDATE #Attr set 
  #Attr.Table_Name        = t2.Name, 
  #Attr.Table_IDFieldName = t2.IDFieldName,
  #Attr.Table_Feature     = t2.Feature,
  #Attr.Table_Type        = t2.Type
FROM fbaTable t2 
WHERE #Attr.Table_ID = t2.TableID
--Данные для атрибута Ссылки или Массива.
UPDATE #Attr SET Ref_EntityBrief = t2.Brief FROM fbaEntity t2 WHERE #Attr.Ref_EntityID = t2.ID 
UPDATE #Attr SET Ref_AttrBrief   = t2.Brief, 
                 Ref_AttrName    = t2.Name 
FROM fbaAttribute t2 
WHERE #Attr.Ref_AttrID = t2.AttributeID and #Attr.Ref_EntityID = t2.AttributeEntityID
--Сущность атрибута 
UPDATE #Attr SET Attr_EntityBrief = t2.Brief FROM fbaEntity t2 WHERE #Attr.Attr_EntityID = t2.ID 
--Для каждой сущности весь полный список атрибутов, включая предков.
SELECT t1.*, t2.* INTO #AttrParent FROM #Attr t1 LEFT JOIN #EntityParent t2 ON t2.EnID = t1.Attr_EntityID 
--where t2.EnChildID = 1694       and Brief = 'Номер' --Выбор по определенной сущности по ИД.
--where t2.EnBrief2  = 'ДогСтрах' and Brief = 'Номер' --Выбор по определенной сущности по Сокращению.
SELECT t1.*, t2.* INTO #AttrChild
FROM #Attr t1 
 RIGHT JOIN #EntityParent t2 ON t2.EnChildID = t1.Attr_EntityID AND t1.Attr_Brief IS NOT NULL --1716 Расчетный документ                                                    
--WHERE t2.EnID = 1716 and t2.EnChildID <> 1716 order by AttrEntityBrief                            --Выбор по определенной сущности по ИД. Здесь только потомки.
--WHERE t2.EnBrief1 = 'РасчетныйДок' and t2.EnBrief2 <> 'РасчетныйДок' order by AttrEntityBrief  --Выбор по определенной сущности по Сокращению. Здесь только потомки.
SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos,        * INTO dbo.A_Attr         FROM #Attr          ORDER BY ID
SELECT ROW_NUMBER() OVER(ORDER BY EnChildID) Pos, * INTO dbo.A_EntityParent FROM #EntityParent    ORDER BY EnChildID
SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos,        * INTO dbo.A_AttrParent FROM #AttrParent        ORDER BY ID
SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos,        * INTO dbo.A_AttrChild FROM #AttrChild        ORDER BY ID
SELECT * FROM #EntityParent     where EnBrief2 = 'ДогСтрах'
SELECT * FROM #EntityParent     where EnBrief2 = 'ЗаявкаСМП'
SELECT * FROM #EntityParent     where EnBrief1 = 'ЗаявкаСМП'
SELECT * FROM #Attr        
SELECT * FROM #AttrParent   
SELECT * FROM #AttrChild
SELECT * FROM fbaTable
SELECT * FROM fbaAttribute
SELECT * FROM dbo.A_Attr
SELECT * FROM #EntityParent
SELECT * FROM fbaEntity where Brief = 'ПростойСправочник'
SELECT * FROM fbaEntity where Brief = 'ВидПлатежа'
SELECT * FROM fbaTable  where Name  = 'SimpleRefBook'
SELECT * INTO #Entity FROM fbaEntity
ALTER TABLE #Entity ADD Table_ID varchar(100);
ALTER TABLE #Entity ADD Table_Name varchar(100);
ALTER TABLE #Entity ADD Table_IDFieldName varchar(100);
UPDATE #Entity SET Table_ID          = t2.TableID,
                   Table_Name        = t2.Name,
                   Table_IDFieldName = t2.IDFieldName
FROM fbaTable t2 WHERE t2.TableEntityID = #Entity.ID    AND t2.Type = 1
UPDATE #Entity SET Table_ID          = NULL,
                   Table_Name        = NULL,
                   Table_IDFieldName = NULL
SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos,        * INTO dbo.A_Entity FROM #Entity
 */
 //======================================================================
/*
        
        /*string[,] TestTable = {
             {"1",  "Num"},
             {"2",  "Lex"},
             {"3",  "Brace"},
             {"4",  "BraceLevel"},
             {"5",  "BraceNum"},
             {"6",  "Select"}, 
             {"7",  "BlockEnd"},
             {"8",  "Proc"},
             {"9",  "LexType"},
             {"10", "Alias"}, 
             {"11", "Entity"} 
                          
        };
        
*/
//======================================================================
/*
  Select
Distinct
EOT_1.ContractID "ДогСтрах",
EOT_3.OperationType "Операция",
EOT_8.StartDate "ДатаНачала",
EOT_10.EndDate "ДатаОкончания",
EOT_1.ReasonDoc "Основание",
EOT_1.ReasonDocOFF "ОснованиеОткрепления"
From
RelContFace EOT_1
Left Outer Join RelContFace_Hist_OperationType EOT_3 On (EOT_3.ID = EOT_1.ID) And (EOT_3.StateDate = (Select Max (StateDate) From RelContFace_Hist_OperationType Where (StateDate <= Convert(DateTime, '20170703 23:59:59', 112)) And (EOT_1.ID = ID)))
Left Outer Join RelContFace_Hist_StartDate EOT_8 On (EOT_8.ID = EOT_1.ID) And (EOT_8.StateDate = (Select Max (StateDate) From RelContFace_Hist_StartDate Where (StateDate <= Convert(DateTime, '20170703 23:59:59', 112)) And (EOT_1.ID = ID)))
Left Outer Join RelContFace_Hist_EndDate EOT_10 On (EOT_10.ID = EOT_1.ID) And (EOT_10.StateDate = (Select Max (StateDate) From RelContFace_Hist_EndDate Where (StateDate <= Convert(DateTime, '20170703 23:59:59', 112)) And (EOT_1.ID = ID)))
Where
EOT_1.ID
in
(
35434)
*/
 //======================================================================
/*
  //Поиск конца блока SELECT.
        private void SetSelect(int Pos)
        {
            string BraceNumLocal = Words[Pos, BraceNum];
            int SelectCount = 0;
            for (int i = Pos; i < WordCount; i++) if (Words[i, Lex] == "SELECT") SelectCount++;
            if (SelectCount == 1) 
            {
                for (int i = Pos; i < WordCount; i++) Words[i, Select] = "1";
                return;
            }
                           
            //Поиск UNION, идущего после SELECT, на том же уровне.          
            for (int i = (Pos + 1); i <  WordCount; i++)
            if ((Words[i, Lex] == "UNION") && (Words[i, BraceNum] == BraceNumLocal)) 
            {
                Words[Pos, BlockEnd] = (i - 1).ToString();
                //Words[Pos, Proc] = "SELECT 1";
                        
                for (int j = Pos; j < i; j++) 
                {
                    Words[j, Select] = SelectMax.ToString();
                    //Words[j, Proc] = "SELBLOCK1";
                }
                SelectMax++;
                return;                              
            }
            
            //Поиск закрывающей скобки, если весь SELECT лежит в скобках, а UNION внутри скобок нет.          
            if (Pos > 0)
            if  ((Words[Pos - 1, Lex] == "("))
            {
                int N1 = Convert.ToInt32(Words[Pos - 1, Brace]) - 1;
                Words[Pos, BlockEnd] = N1.ToString(); //StringAdd(Words[Pos - 1, Brace], -1) ;
                //Words[Pos, Proc] = "SELECT 2";
                for (int j = Pos; j <= N1; j++) 
                {
                    Words[j, Select] = SelectMax.ToString();
                    //Words[j, Proc] = "SELBLOCK2";
                }
                SelectMax++;
                return;  
            }
            
            //UNION не нашли, продолжаем поиск.
            //Поиск последнего указанного BraceNum - это и будет конец SELECT.
            int i1 = FindLastBaraceNum(BraceNumLocal);
            int N2;
            if (Words[i1, Lex] == ")") N2 = i1 - 1; else N2 = i1;               
            Words[Pos, BlockEnd] = N2.ToString();  
            //Words[Pos, Proc] = "SELECT 3";             
            for (int j = Pos; j <= N2; j++) 
                
            {
                Words[j, Select] = SelectMax.ToString();
                //Words[j, Proc] = "SELBLOCK3";
            }
            SelectMax++;    
        }
*/
//======================================================================
/*
      select aaa, ttt,
      (select bb) as df,
      (select cc union select dd) ds,
      union 
      select ss where ff in (1,2,3)
      
      
      
      
        
*/
//======================================================================
/*
  /*
        //Поиск конца блока SELECT.
        private void FindSelect(int Pos)
        {            
            SelectCount++;
            int N = GetEndSelect(Pos);
            for (int i = Pos; i <= N; i++)  Words[i, Select] = SelectCount.ToString();                       
        }
        
        //Поиск конца блока SELECT.
        private int GetEndSelect(int Pos)
        {         
            //Поиск UNION, идущего после SELECT, на том же уровне.          
            for (int i = (Pos + 1); i <  WordCount; i++)
            if ((Words[i, Lex] == "UNION") && (Words[i, BraceNum] == Words[Pos, BraceNum])) return i - 1;           
            if ((Pos > 0) && (Words[Pos - 1, Lex] == "(")) return Convert.ToInt32(Words[Pos - 1, Brace]) - 1;
            return WordCount;
        }
          
*/
//======================================================================
/*
//Поиск конца блоков.
        private void FindBlock(int Pos, string BlockName)
        {
            //return;
            
            if (BlockName == "TOP")
            {   
                //Если после TOP идут скобки, то поиск конца скобки.
                //Иначе просто следующее значение.
                if (Words[Pos + 1, Lex] == "(") 
                {
                    Words[Pos, BlockEnd] = Words[Pos + 1, Brace];
                    //Words[Pos + 1, Proc] = "TOP 1";               
                }
                else 
                {
                    Words[Pos, BlockEnd] = Words[Pos + 1, Pos];
                    //Words[Pos + 1, Proc] = "TOP 2";
                }
                return;
            }
            
            //Поиск до GROUP BY или ORDER BY или до конца запроса.
            string SelectLocal = Words[Pos, Select];
            for (int i = (Pos + 1); i <  WordCount; i++)
            if (Words[i, Select] == SelectLocal) 
            {                              
                string Lexem = Words[i, Lex];
                
                //Поиск конца FROM.
                //Если после FROM скобка, то поиск закрывающей скобки.
                if (BlockName == "FROM")
                {   
                    //if (Words[Pos + 1, Lex] == "(") 
                    //{
                        //Words[Pos, BlockEnd] = Words[Pos + 1, Brace];
                        //Words[Pos, Proc] = "FROM 1";
                    //    return;
                    //}
                    
                    if ((Lexem == "WHERE") || (Lexem == "UNION") || (Words[i, LexType] == "5")) //Все JOIN имеют LexType = 5.
                    {
                        //Words[Pos, BlockEnd] = (i - 1).ToString();
                        //Words[Pos, Proc] = "FROM 2";
                        SetEntityAttr(Pos + 1, i, "ENTITY");
                        return;
                    }                             
                }
                
                //Поиск конца JOIN.
                if (BlockName == "JOIN")
                {                   
                    //if (Words[Pos + 1, Lex] == "(")
                    //{
                        //Words[Pos, BlockEnd] = Words[Pos + 1, Brace];
                        //Words[Pos, Proc] = "JOIN 1";
                        //return; 
                    //}
                    
                    if ((Words[Pos + 2, Lex] == "ON") || (Words[Pos + 2, LexType] == "5"))
                    {
                        //Words[Pos, BlockEnd] = (Pos + 1).ToString();
                        Words[Pos + 1, LexType] = "ENTITY";  
                        //Words[Pos, Proc] = "JOIN 2";
                        return; 
                    }
                    return; 
                }                       
                
                //Поиск конца ON.
                /*if (BlockName == "ON")
                if ((Lexem == "WHERE") || (Lexem == "UNION") || (Lexem == "ON") || (Words[i, LexType] == "5"))
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    //Words[Pos, Proc] = "ON 1";
                    return;
                }             
                
                //Поиск конца WHERE.
                if (BlockName == "WHERE")
                if ((Lexem == "GROUP BY") || (Lexem == "ORDER BY") || (Lexem == "UNION"))
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    //Words[Pos, Proc] = "WHERE 1";
                    return;
                }        
                
                //Поиск конца GROUP BY.
                if (BlockName == "GROUP BY")
                if ((Lexem == "ORDER BY") || (Lexem == "UNION") || (Lexem == "HAVING"))
                    {
                        Words[Pos, BlockEnd] = (i - 1).ToString();
                        //Words[Pos, Proc] = "GROUP 1";
                        return;
                    }
                
                //Поиск конца ORDER BY.
                if (BlockName == "ORDER BY")
                if (Lexem == "UNION")
                {
                    Words[Pos, BlockEnd] = (i - 1).ToString();
                    //Words[Pos, Proc] = "ORDER 1";
                    return;
                }                             
            } 
             
            //int i1 = FindLastSelect(SelectLocal);
           // if (Words[i1, Lex] == ")") Words[Pos, BlockEnd] = (i1 - 1).ToString();
           //     else Words[Pos, BlockEnd] = i1.ToString();
            //Words[Pos, Proc] = BlockName + " 10"; 
            //
      //  }                         
//======================================================================
/*
                    
        //Определение таблицы (основной) для сущности.
        /*private void FindTablesForEntity()
        {                                               
            for (int i = 0; i < WordCount; i++)
            {                
                if (Words[i, LexType] != "ENTITY") continue;
                                                        
                DataRow[] rows1 = DTUnion.Select("TableType = '1' and EnBrief2 = '" + Words[i, Lex] + "'");
                if (rows1.Any()) 
                {
                    string PosTable = rows1[0].ItemArray[DTUnion.Columns.IndexOf("Pos")].ToString(); 
                    int Pos = Convert.ToInt32(PosTable); 
                    if (Pos > -1)
                    {
                        Words[i, TableName]    = sys.DTValue(DTUnion, Pos, "TableName");
                        Words[i, TableFieldID] = sys.DTValue(DTUnion, Pos, "IDFieldName");
                        //Здесь вставка в таблицу ListQuery
                    }                       
                }                                 
            }
        }
        
        
*/
//======================================================================
/*
 //Проставление данных по простому атрибуту.
        private void FindSimpleAttrData()
        {                                               
            for (int i = 0; i < WordCount; i++)
            {               
                DataRow[] rows1 = DTAttr.Select("Entity_Brief = '" + Words[i, Entity] + "' and Attr_Brief = '" + Words[i, AttrFirst] + "'");
                if (rows1.Any()) 
                {
                    Words[i, TableName]    = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Name")].ToString(); 
                    Words[i, TableField]   = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Field")].ToString();    
                    Words[i, TableFieldID] = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_IDFieldName")].ToString(); 
                    Words[i, TableType]    = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Type")].ToString(); 
                    Words[i, AttrType]     = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Attr_Type")].ToString();                        
                }                                                              
            }
        }  
*/ 
//======================================================================
/*
 //Проставление данных по простому атрибуту. Работает. Почему то разницы по времени с простым циклом нет.
        /*private void FindSimpleAttrData()
        {                                               
            for (int i = 0; i < WordCount; i++)
            {               
                DataRow[] rows1 = DTAttr.Select("Entity_Brief = '" + Words[i, Entity] + "' and Attr_Brief = '" + Words[i, AttrFirst] + "'");
                if (rows1.Any()) 
                {
                    Words[i, TableName]    = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Name")].ToString(); 
                    Words[i, TableField]   = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Field")].ToString();    
                    Words[i, TableFieldID] = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_IDFieldName")].ToString(); 
                    Words[i, TableType]    = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Type")].ToString(); 
                    Words[i, AttrType]     = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Attr_Type")].ToString();                        
                }                                                              
            }
        }*/
        
        
 
 //======================================================================
/*
  //Получить алиас таблицы по имени таблицы. Только для CreateSimpleSQL.
        private string SetTableAlias(string TableName1, string Select1)
        {
            if (TableName1 == "") return "";
            for (int i = 0; i < TableCount; i++)
            {
                if ((ListTable[i, 2] == TableName1) && (ListTable[i, 5] == Select1)) return ListTable[i, 4];
            }
            return "";
        }
*/
//======================================================================
/*RelContFace Z1 
   
LEFT OUTER JOIN RelContFace_Hist_OperationType AT1 ON (AT1.ID = Z1.ID) AND (AT1.StateDate = (SELECT MAX(StateDate) FROM RelContFace_Hist_OperationType WHERE (StateDate <= CONVERT(DateTime, '20170706 23:59:59', 112)) AND (Z1.ID = ID)))
LEFT OUTER JOIN RelContFace_Hist_StartDate     AT2 ON (AT2.ID = Z1.ID) AND (AT2.StateDate = (SELECT MAX(StateDate) FROM RelContFace_Hist_StartDate     WHERE (StateDate <= CONVERT(DateTime, '20170706 23:59:59', 112)) AND (Z1.ID = ID)))
LEFT OUTER JOIN RelContFace_Hist_EndDate       AT3 ON (AT3.ID = Z1.ID) AND (AT3.StateDate = (SELECT MAX(StateDate) FROM RelContFace_Hist_EndDate       WHERE (StateDate <= CONVERT(DateTime, '20170706 23:59:59', 112)) AND (Z1.ID = ID)))
*/
 //======================================================================
/*
        //Присвоение для ячеек массивов пустой строки.
        private void ArraySetEmpty()
        {
            //Это нужно делать когда уже известен WordCount.
            /*for (int i = 0; i < WordCount; i++) 
            {
                Words[i, LexType]    = ""; //Тип лексемы.
                Words[i, Alias]      = ""; //Алиас для атрибута или сущности. 
                Words[i, Entity]     = ""; //Первая сущность для состовного атрибута. 
                Words[i, TableName]  = ""; //Таблица атрибута.
                Words[i, TableField] = ""; //Имя поля в таблице для атрибута.
                Words[i, TableAlias] = ""; //Алиас атрибута.
                Words[i, UserString] = ""; 
                //Words[i, TableType] = ""; //Тип таблицы (историчная или нет).                  
                
            }
             
*/
//======================================================================
/*
         //Проставить строки пользвоателя
        /*private void SetUserStr()
        {               
            for (int i = 0; i < WordCount; i++)
            { 
                //if ((Words[i, Lex]).IndexOf("USERSTR") > -1)
                if (Words[i, LexType] = "STR")
                {                     
                    //Words[i, LexType] = "STR";
                    //if ((Words[i, Lex]).IndexOf("USERSTR") > -1)   Words[i, UserString] = GetStrUserByUserStr(Words[i, Lex]);
                    //if ((Words[i, Alias]).IndexOf("USERSTR") > -1) Words[i, UserString] = GetStrUserByUserStr(Words[i, Alias]);
                    Words[i, UserString] = GetStrUserByUserStr(Words[i, Lex]);
                    Words[i, UserString] = GetStrUserByUserStr(Words[i, Alias]);
                 }
            }                      
        } 
*/
//======================================================================
/*
         //Числовое значение в виде строки, вычесть или добавить Diff.
        //private string StringAdd(string Number, int Diff)
        //{
        //    return (Convert.ToInt32(Number) + Diff).ToString();
        //}
        
        //Числовое значение в виде строки, вычесть или добавить Diff.
        //private int IntAdd(string Number, int Diff)
        //{
        //    return Convert.ToInt32(Number) + Diff;
        //}
*/
//======================================================================
/*
         
                    
                         
                    
                    /*for (int i = 0; i < WordCount; i++)
                    if (Words[i - 1, Lex]  == "AND") Words[i - 1, LexType] = "NOTUSE"; //AND ДатаСостОбъекта = ...
                    Words[i,     LexType]  =  "NOTUSE"; //ДатаСостОбъекта = ...
                    Words[i + 1, LexType]  =  "NOTUSE"; //= ...
                    
                    
                    if (Words[i + 2, Lex]  != "(") Words[i + 2, LexType]  =  "SD"; //01.01.2017
                       else for (int j = i + 3; j < Words[i, Brace].ToInt() - 1; j++) Words[j, LexType] = "SD"; //ДатаСостОбъекта = (ааа) 
                                                                                                   
                    //AND (ДатаСостОбъекта = '01.01.2017')
                    if ((Words[i - 2, Lex] == "AND") && (Words[i - 1, Lex] == "("))
                    {
                        Words[i - 2, LexType] = "NOTUSE"; //AND
                        Words[i - 1, LexType] = "NOTUSE"; //(
                        for (int j = i + 1; j < Words[i - 1, Brace].ToInt() - 1; j++) Words[j, LexType] = "SD"; //До закрывающей скобки.
                    }
                    */
                        
                   
                    
                        //i = i + 2; 
                        //continue;
                    
                    
                    /*if (Words[i - 1, Lex] == "WHERE") 
                    {                                                                              
                        //if 
                        Words[Lex - 1, Lex] = Str + " = " + WordList[i + 2].ToUpper();
                        Words[Lex - 1, LexType] = "SD";
                        i = i + 2; 
                        continue;
                    } 
                    else
                    {
                        Words[WordCount, Lex] = Str + " = " + WordList[i + 2].ToUpper();
                        Words[WordCount, LexType] = "SD";
                        if (WordList[i + 3].ToUpper() == "AND") i = i + 3;  
                        else i = i + 2; 
                        WordCount++;
                        continue;
                    }                     
                     */
                    
                    
                    
                    //Words[i, LexType] = "NOTUSE";
                    // for (int j = 0; j < EntityCount; j++)
                    // {
                    //     if ((ListEntity[i, 2] == Words[i, AttrFirst]) && (ListEntity[i, 2] == Words[i, AttrFirst])) ListEntity[i, 5] = Words[i, Lex];
                    // }
                    
                    //if (Words[i - 1, Lex] == "AND")  Words[i - 1, LexType] = "NOTUSE";
 
//======================================================================
/*
  //From
//RelContFace EOT_1
//Left Outer Join RelContFace_Hist_OperationType EOT_3 On (EOT_3.ID = EOT_1.ID) And (EOT_3.StateDate = (Select Max (StateDate) From RelContFace_Hist_OperationType Where (StateDate <= Convert(DateTime, '20170706 23:59:59', 112)) And (EOT_1.ID = ID)))
//Left Outer Join RelContFace_Hist_StartDate EOT_8 On (EOT_8.ID = EOT_1.ID) And (EOT_8.StateDate = (Select Max (StateDate) From RelContFace_Hist_StartDate Where (StateDate <= Convert(DateTime, '20170706 23:59:59', 112)) And (EOT_1.ID = ID)))
//Where
*/
//======================================================================
/*
 //Попытка №1 собрать простой SQL запрос.
        private string CreateSimpleSQL()
        {               
            //Перед самой сборкой запроса добавляем пробелы, чтобы слова не слипались. Только для CreateSimpleSQL.
            //string Space1 = ""; 
            //string Space2 = "";
            //for (int i = 0; i < WordCount-1; i++)
             //   if ((Words[i, LexType] == "8") || (Words[i, LexType] == "SIGN"))
            //{
            //    //Words[i, Lex] = " " + Words[i, Lex] + " ";
            //    Space1 = " ";
            //    Space2 = " "; 
            //}
                                          
            //string[,] ListTable   = new string[100, 30];
            string SQL = "";
            for (int i = 0; i < WordCount - 1; i++)
            {                                                 
                if (i > 0)
                  if (Words[i - 1, LexType] == "ENTITY") continue;
                
                string iLex = Words[i, Lex];
                if (iLex.IndexOf("USERSTR", StringComparison.OrdinalIgnoreCase) > -1) iLex = Words[i, UserString];
                iLex = Space1 + iLex + Space2;
                
                if (Words[i, LexType] == "ATTR")
                {                                      
                    if (Words[i, TableAlias] != "") SQL += Words[i, TableAlias] + "." + Words[i, TableField] + " " + Words[i, Alias];
                    else if (Words[i, TableField] != "") SQL += Words[i, TableField] + " " + Words[i, Alias];
                    else SQL += iLex + " " + Words[i, Alias];
                    
                    if ((Words[i + 1, Lex] != "IN")        &&
                        (Words[i + 1, LexType] != "ALIAS") && 
                        (Words[i + 1, Lex] != "AS")) SQL += Var.CR;  
                    continue;
                }
                                                    
                if (Words[i, LexType] == "ENTITY")
                {
                    SQL += GetBlockFrom();                 
                    continue;
                }  
                
                if (Words[i, LexType] == "ALIAS")
                {  
                    SQL += iLex + Var.CR;
                    continue;
                }  
                
                SQL += iLex;
                bool DoCR = false;
                if  (Words[i, LexType] == "9") DoCR = true;                     
                if (DoCR) SQL += Var.CR;    
            }
            return SQL;
        }
             
        private string GetBlockFrom()
        {
            string SQL = "";
            string MainAlias   = "";
            string MainFieldID = "";
//            /string DateHist    = sys.
            for (int i = 0; i < TableCount; i++)
            {
                if (ListTable[i, 6] == "1") 
                {
                    SQL += ListTable[i, 2] + " " + ListTable[i, 4] + " " + Var.CR;
                    MainFieldID = ListTable[i, 3];
                    MainAlias   = ListTable[i, 4];                    
                }
                else 
                {
                    SQL += "LEFT OUTER JOIN " + ListTable[i, 2] + " " + ListTable[i, 4] + " ON (" + ListTable[i, 4] + "." + ListTable[i, 3] + " = " + MainAlias + "." + MainFieldID + ") AND (" + ListTable[i, 4] + ".StateDate = (SELECT MAX(StateDate) FROM " + ListTable[i, 2] + " WHERE (StateDate <= CONVERT(DateTime, '20170706 23:59:59', 112)) AND (" + MainAlias + "." + MainFieldID + " = " + ListTable[i, 3] + ")))" + " " + Var.CR;;
                }                
            }
            
            return SQL;                   
        }
         
*/ 
//======================================================================
/*
         //private void SetNotUse()
        //{
        //    for (int i = 0; i < WordCount; i++)
        //   {
        //        if ((Words[i, LexType] == "ALIAS") && (Words[i - 1, LexType] == "ENTITY")) Words[i, SQL] = "NOTUSE";
        //    }
        //}
            
*/ 
 //======================================================================
/*
  /*private void FindSimpleAttrData()
        {                                               
            for (int i = 0; i < WordCount; i++)
            {               
                DataRow[] rows1 = DTAttr.Select("Entity_Brief = '" + Words[i, Entity] + "' and Attr_Brief = '" + Words[i, AttrFirst] + "'");
                if (rows1.Any()) 
                {
                    Words[i, TableName]    = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Name")].ToString(); 
                    Words[i, TableField]   = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Field")].ToString();    
                    Words[i, TableFieldID] = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_IDFieldName")].ToString(); 
                    Words[i, TableType]    = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Table_Type")].ToString(); 
                    Words[i, AttrType]     = rows1[0].ItemArray[DTAttr.Columns.IndexOf("Attr_Type")].ToString();                        
                }                                                              
            }
        }*/  
        
        
          /*if (BlockName == "SD")
                {                                                                                                               
                    //Могут быть варианты:
                    //AND (ДатаСостОбъекта = ааа)
                    //AND ДатаСостОбъекта = (ааа)
                    //AND ДатаСостОбъекта = ааа AND
                    //AND ДатаСостОбъекта = ааа;
                    //AND ДатаСостОбъекта = ааа GROUP BY...
                    //AND ДатаСостОбъекта = ааа ORDER BY...
                    //AND ДатаСостОбъекта = GetDate() ORDER BY...
                    //AND ДатаСостОбъекта = GetDate() ORDER BY...
                    //AND ДатаСостОбъекта = (SELECT ДатаНачала FROM bbb WHERE...) ORDER BY...
                    //Если перед ДатаСостОбъекта идет WHERE, а после нет условий через AND, то WHERE нужно убирать.
                    
                    if (Words[Pos - 1, Lex]  == "AND") Words[i - 1, LexType] = "NOTUSE"; //AND ДатаСостОбъекта = ...
                    Words[Pos,     LexType]  =  "NOTUSE"; //ДатаСостОбъекта = ...
                    Words[Pos + 1, LexType]  =  "NOTUSE"; //= ...
                    
                    
                    if (Words[i + 2, Lex]  != "(") Words[i + 2, LexType]  =  "SD"; //01.01.2017
                       else for (int j = i + 3; j < Words[i, Brace].ToInt() - 1; j++) Words[j, LexType] = "SD"; //ДатаСостОбъекта = (ааа) 
                                                                                                   
                    //AND (ДатаСостОбъекта = '01.01.2017')
                    if ((Words[i - 2, Lex] == "AND") && (Words[i - 1, Lex] == "("))
                    {
                        Words[i - 2, LexType] = "NOTUSE"; //AND
                        Words[i - 1, LexType] = "NOTUSE"; //(
                        for (int j = i + 1; j < Words[i - 1, Brace].ToInt() - 1; j++) Words[j, LexType] = "SD"; //До закрывающей скобки.
                    }     
                }
         
*/
//======================================================================
/*
   
                /*int N = UpperStr.IndexOf("ДАТАСОСТОБЪЕКТА", StringComparison.OrdinalIgnoreCase);
                if (N > -1) 
                {
                    if (Words[WordCount - 1, Lex].ToUpper() == "AND") //if (WordList[i - 1] == "AND")
                    {                                                                              
                        Words[WordCount - 1, Lex] = Str + " = " + WordList[i + 2].ToUpper();
                        Words[WordCount - 1, LexType] = "SD";
                        i = i + 2; 
                        continue;
                    } else
                    if (Words[WordCount - 1, Lex].ToUpper() == "WHERE") //if (WordList[i - 1] == "AND")
                    {                                                                              
                        if 
                        Words[WordCount - 1, Lex] = Str + " = " + WordList[i + 2].ToUpper();
                        Words[WordCount - 1, LexType] = "SD";
                        i = i + 2; 
                        continue;
                    } 
                    else
                    {
                        Words[WordCount, Lex] = Str + " = " + WordList[i + 2].ToUpper();
                        Words[WordCount, LexType] = "SD";
                        if (WordList[i + 3].ToUpper() == "AND") i = i + 3;  
                        else i = i + 2; 
                        WordCount++;
                        continue;
                    }                   
                } else           
                
*/
 //======================================================================
/*
         
        //Установка типа блока. Атрибут или Сущность.
        //private void SetEntityAttr(int iBeg, int iEnd, string LexTypeStr) 
        //{
        //    for (int i = iBeg; i <= iEnd; i++) 
        //    {                                                           
        //        if (Words[i, LexType] == "") Words[i, LexType] = LexTypeStr;                  
        //    }
        //}
*/
//======================================================================
/*
//Определение первой сущности у атрибута.
        private void FindFirstAttr()
        {                          
            //for (int i = 0; i < WordCount; i++)
            //{     
            //     if (Words[i, LexType] == "ENTITY") && continue;
            //}
            
            //1.LF - Составной атрибут может начинаться с пользовательского алиаса.
            //2.EF - Составной атрибут может начинаться с сущности, повторяющей  сущность с которой выбираем.    
            //3.AF - Составной атрибут может начинаться с атрибута.                              
            //Будем проверять в таком же порядке: 1,2,3.
               
            for (int i = 0; i < WordCount; i++)
            {                                               
                if (Words[i, LexType] != "ATTR") continue;
                                
                //bool DotPresent = false;  //Признак составного атрибута.               
                //if  (Words[i, Lex].IndexOf(".", StringComparison.OrdinalIgnoreCase) > -1) DotPresent = true;
                string FirstWord; //Первая часть до первой точки.
                string[] DotArray = Words[i, Lex].Split('.');
                if (DotArray.Any()) FirstWord = DotArray[0]; else FirstWord = Words[i, Lex];
                                             
                //1.Составной атрибут может начинаться с алиаса.
                if  (DotArray.Any())
                for (int j = 0; j < EntityCount; j++)
                {           
                    //Если первая чась составного атрибута совпадает с алиасом в списке сущностей, то это алиас.
                    if ((FirstWord == ListEntity[j, iAlias]) && (ListEntity[j, iSelect] == Words[i, Select]))
                    {
                        //Words[i, Proc]        = "GET_ENT1";
                        Words[i, Entity]      = ListEntity[j, iLex];
                        Words[i, EntityAlias] = ListEntity[j, iAlias];
                        //Если точка всего одна и первая часть алиас, значит это не составной атррибут.                           
                        Words[i, FirstAttrType] = "LF"; //аЛиас First - начинается с алиаса.
                        Words[i,  AttrFirst]  = DotArray[1];
                        if (DotArray.Count() == 2) Words[i, AttrComplex] = "0"; else 
                        {
                            Words[i, AttrComplex] = "1";
                            QueryComplex = 1;
                        }
                        break;
                    }                      
                } 
                                 
                //2.Составной атрибут может начинаться с сущности, повторяющей  сущность с которой выбираем.                                                 
                for (int j = 0; j < EntityCount; j++)
                {                                           
                    //Если первая чась составного атрибута совпадает с сокращением сущности в списке сущностей, значит это есть сокращение сущности.
                    if ((FirstWord == ListEntity[j, iLex]) && (ListEntity[j, iSelect] == Words[i, Select]))
                    {
                        //Words[i, Proc]        = "GET_ENT2";
                        Words[i, Entity]      = ListEntity[j, iLex];
                        Words[i, EntityAlias] = ListEntity[j, iAlias];
                        Words[i, FirstAttrType] = "EF"; //Entity First - начинается с сущности.
                        Words[i, AttrFirst]  = DotArray[1];
                        if (DotArray.Count() == 2)Words[i, AttrComplex] = "0"; else 
                        {
                            Words[i, AttrComplex] = "1";
                            QueryComplex = 1;
                        }
                        break;
                    }
                } 
                
                //3.Составной атрибут может начинаться с атрибута сущности.
                //Самый распрастранённый вариант - первая часть составного атрибута - это атрибут сущности.
                if  (Words[i, Entity] != "") continue;  
                for (int j = 0; j < EntityCount; j++)
                {
                    //int N = Convert.ToInt32(ListEntity[j, 0]);                       
                    if (ListEntity[j, iSelect] == Words[i, Select])
                    {
                        if (ExistsAttrInEntity(ListEntity[j, iLex], FirstWord) || Words[i, LexType] == "SYS")
                        {
                            //Words[i, Proc]      = "GET_ENT3";
                            Words[i, Entity]      = ListEntity[j, iLex];  
                            Words[i, EntityAlias] = ListEntity[j, iAlias]; 
                            Words[i, FirstAttrType] = "AF"; //Attr First - начинается с сущности.
                            Words[i,  AttrFirst]  = DotArray[0];
                            if (DotArray.Count() == 1) Words[i, AttrComplex] = "0"; else 
                            {
                                Words[i, AttrComplex] = "1";
                                QueryComplex = 1;
                            }
                            break;
                        }                          
                    }
                }                                
            }
        } 
*/
//======================================================================
 //Получить список сущностей
        /*private void GetListEntityAlias()
        {   
            AliasCount  = 0;
            EntityCount = 0;
            for (int i = 0; i < WordCount; i++)
            {
                if (Words[i, LexType] == "ALIAS") 
                {
                    ListAlias[AliasCount, iPos]    = AliasCount.ToString();
                    ListAlias[AliasCount, iNum]    = Words[i, Pos];
                    ListAlias[AliasCount, iLex]    = Words[i, Lex];
                    ListAlias[AliasCount, iSelect] = Words[i, Select];
                    ListAlias[AliasCount, iAlias]  = Words[i, Alias];
                    //Debug.WriteLine("N: {0}", AliasCount.ToString());
                    AliasCount++;
                }
                 */               
                /*if (Words[i, LexType] == "ENTITY") 
                {
                    ListEntity[EntityCount, iPos]    = EntityCount.ToString();
                    ListEntity[EntityCount, iNum]    = Words[i, Pos];
                    ListEntity[EntityCount, iLex]    = Words[i, Lex];
                    ListEntity[EntityCount, iSelect] = Words[i, Select];
                    if (Words[i, Alias] != "") ListEntity[EntityCount, iAlias]  = Words[i, Alias];
                    else ListEntity[EntityCount, iAlias]  = "EN" + EntityCount;
                         
                    //Debug.WriteLine("N: {0}", EntityCount.ToString());
                    EntityCount++;
                } */              
            //}          
        //}           
  
//======================================================================
/*
 
                /*if ((Words[i, LexType] == "SIGN")  ||
                    (Words[i, LexType] == "KEY")   || 
                    (Words[i, LexType] == "ALIAS") ||
                    (Words[i, LexType] == "JOIN")  ||
                    (Words[i, LexType] == "UNION") || 
                    (Words[i, LexType] == "STR")   ||
                    (Words[i, LexType] == "NUM"))  Words[i, SQL] = Words[i, Lex];
                
*/
//======================================================================
/*
  /*sSqlCommand = @"
                        Select Top 500 
                        [LINK], [nNumber], [cFileName], [dDateBegin], [dDateEnd]
                        From chel.repl_pak_out Order By nNumber Desc";
                    oComm = new SqlCommand(sSqlCommand);
                    oConn = new SqlConnection(this.sConnStr);
                    oConn.Open();
                    oComm.Connection = oConn;
                    dataSet = new DataSet("Pakets");
                    sqlDataAdapter = new SqlDataAdapter(oComm);
                    sqlDataAdapter.Fill(dataSet, "Pakets");  
          */
                                                    //DTAttrParent.DefaultView
            //var bd = new DevAge.ComponentModel.BoundDataView(dataSet.Tables["Pakets"].DefaultView);
            /*var bd = new DevAge.ComponentModel.BoundDataView(DTAttrParent.DefaultView);
            //bd.AllowDelete = false;
            //bd.AllowNew = false;
             //SourceGrid.GridVirtual.SelectionMode d;
             FBA.GridFBA DG;
            dataGrid1.DeleteQuestionMessage = null;
            //dataGrid1.SelectionMode = GridSelectionMode.Row;
            dataGrid1.FixedRows = 1;
            dataGrid1.FixedColumns = 1;
            //dataGrid1.SpecialKeys = GridSpecialKeys.Default;
            dataGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;// GridSelectionMode.Row;
            //dataGrid1.SelectionBorderMode = SourceGrid.SelectionBorderMode.FocusRange;
            dataGrid1.SpecialKeys   =   SourceGrid.GridSpecialKeys.Default;
            dataGrid1.DataSource = bd;
                    
*/
//======================================================================
/*
 //Вернуть все таблицы, которые нужно приджойнить к главной таблице сущности EntityAlias. Только для SetSQL1.      
        private string CollectTables(string EntityBrief1, string EntityAlias1)
        {
            //return "";
             
            string SQLLocal = "";
            string MainFieldID = "";
            for (int i = 0; i < TableCount; i++)
            {
                if (ListTable[i, 8] != EntityBrief1) continue;
                if (ListTable[i, 9] != EntityAlias1) continue;
                if ((ListTable[i, 6] == "1") && (MainFieldID == ""))
                {
                    SQLLocal    = ListTable[i, 2] + " " + ListTable[i, 4];
                    MainFieldID = ListTable[i, 3];
                    continue;
                }
                if (ListTable[i, 6] == "2") 
                {
                    //Историчная таблица.
                    SQLLocal += Var.CR + "LEFT OUTER JOIN " + ListTable[i, 2] + " " + ListTable[i, 4] + " ON (" + ListTable[i, 4] + "." + ListTable[i, 3] + " = " + ListTable[i, 9] + "." + MainFieldID + ") AND (" + ListTable[i, 4] + ".StateDate = (SELECT MAX(StateDate) FROM " + ListTable[i, 2] + " WHERE (StateDate <= CONVERT(DateTime, " + ListTable[i, 10] + ", 112)) AND (" + ListTable[i, 9] + "." + MainFieldID + " = " + ListTable[i, 3] + ")))" + " ";               
                     continue;
                }
                if (ListTable[i, 6] == "1") 
                {
                    //Таблица предка. //Inner Join Document EOT_9 On EOT_9.DocumentID = EOT_1.CID
                    SQLLocal += Var.CR + "INNER JOIN " + ListTable[i, 2] + " " + ListTable[i, 4] + " ON (" + ListTable[i, 4] + "." + ListTable[i, 3] + " = " + ListTable[i, 9] + "." + MainFieldID + ")" ;               
                    continue;
                }               
            }            
            return SQLLocal;
        } 
*/ 
//======================================================================
/*
          //Определение таблицы (основной) для сущности. Поля TableName, IDFieldName. 
        private void FindTablesForEntity()
        {   //DTEntity                                            
            //Попробовал через LINQ, медленнее. Здесь 2 против 50 через LINQ.
            for (int i = 0; i < WordCount; i++)
            {                
                if (Words[i, LexType] != "ENTITY") continue;
                for (int j = 0; j < DTUnion.Rows.Count; j++)
                {
                    if ((DTUnion.Rows[j]["TableType"].ToString() == "1") && (DTUnion.Rows[j]["EnBrief2"].ToString() == Words[i, Lex]))
                    {
                        Words[i, TableName]    = DTUnion.Rows[j]["TableName"].ToString();  
                        Words[i, TableFieldID] = DTUnion.Rows[j]["IDFieldName"].ToString();   
                        Words[i, TableType]    = "1";
                        break;
                    }
                }
            }
        }
        
*/ 
 //======================================================================
/*
 //Определение таблицы (основной) для сущности. Поля TableName, IDFieldName. 
        private static void FindTablesForEntity()
        {                                              
            //Попробовал через LINQ, медленнее. Здесь 2 против 50 через LINQ.
            for (int i = 0; i < WordCount; i++)
            {                
                if (Words[i, LexType] != "ENTITY") continue;
                for (int j = 0; j < DTEntity.Rows.Count; j++)
                {
                    if (DTEntity.Rows[j]["Brief"].ToString() == Words[i, Lex])
                    {
                        Words[i, TableName]    = DTEntity.Rows[j]["Table_Name"].ToString();  
                        Words[i, TableFieldID] = DTEntity.Rows[j]["Table_IDFieldName"].ToString();   
                        Words[i, TableType]    = "1";
                        break;
                    }
                }
            }
        } 
*/
//======================================================================
/*
  //Найти все таблицы по ссылке.
        private static string AddTableLink(int Level,
                                    int Pos1,
                                    string Select1, 
                                    string AttrFull1, 
                                    string Entity1, 
                                    string EntityAlias1, 
                                    string AttrComplex1,
                                    string JoinTableName,
                                    string JoinTableAlias,
                                    string JoinFieldName)                                      
        {
            //==================Разбор 1 ==================
            //Select
            //  EOT_11.KodCanalSale 
            //From
            //  Payment EOT_1
            //  Left Outer Join ContractIns EOT_2
            //    On EOT_2.CID = EOT_1.ContractID
            //  Left Outer Join CanalSale EOT_11
            //    On EOT_11.CanalSaleID = EOT_2.CanalSaleID
            
            //ДогСтрах.КаналПродаж.Код
            //ContractIns.ContractID - ДогСтрах
            //CanalSale.CanalSaleID  - КаналПродаж
            //CanalSale.KodCanalSale - Код                       
            //Платеж ссылается на ДогСтрах       - 1 проход Платеж.ДогСтрах
            //ДогСтрах ссылается на КаналаПродаж - 2 проход ДогСтрах.КаналПродаж
            //КаналПродаж ссылается на Код.      - 3 проход КаналПродаж.Код                      
            //Платеж       Payment.ContactID
            //ДогСтрах     ContractIns.CanalSale 
            //КаналПродаж  CanalSale.CanalSaleID                                            
            //==================Разбор=================
            
            //==================Разбор2 ==================
            //ДогСтрах.ВидДок.Наим                
            //Select
            //EOT_12.Name 
            //From
            //Payment EOT_1
            //Left Outer Join ContractIns EOT_2 Inner Join Document EOT_10
            //On EOT_10.DocumentID = EOT_2.CID
            //On EOT_2.CID = EOT_1.ContractID
            //Left Outer Join KindDocument EOT_11 Inner Join KindObject EOT_12
            //On EOT_12.ID = EOT_11.ID
            //On EOT_11.ID = EOT_10.KindDocument
            
            //==================Разбор=================
            
            string Str1 = "";
            string Str2 = "";
            string AliasLast = "";
                     
            //Сначала нужно добавить основую таблицу сущности, на которую происходит ссылка.           
            for (int j = 0; j < DTEntity.Rows.Count; j++)
            { 
                if ((DTEntity.Rows[j]["Brief"].ToString() == Entity1) && 
                    (!TableExists(DTEntity.Rows[j]["Table_Name"].ToString(), EntityAlias1)))
                {
                    ListTable[TableCount, 0]  = TableCount.ToString();                            //Pos
                    ListTable[TableCount, 1]  = Words[Pos1, Pos];                                 //Num
                    ListTable[TableCount, 2]  = DTEntity.Rows[j]["Table_Name"].ToString();        //Tablename
                    ListTable[TableCount, 3]  = DTEntity.Rows[j]["Table_IDFieldName"].ToString(); //TableFieldID 
                    ListTable[TableCount, 4]  = "AT" + TableCount;                                //Alias                         
                    ListTable[TableCount, 5]  = Select1;                                          //Select
                    ListTable[TableCount, 6]  = "1"; //Основная                                   //TableType
                    ListTable[TableCount, 7]  = "ATTR";                                           //LexType
                    ListTable[TableCount, 8]  = Entity1;                                          //Entity
                    ListTable[TableCount, 9]  = EntityAlias1;                                     //EntityAlias
                    ListTable[TableCount, 10] = "GetDate()";                                      //SD
                    ListTable[TableCount, 11] = AttrFull1;                                        //AttrFull 
                    ListTable[TableCount, 12] = "3";                                              //TypeAdd
                    
                    string MainAlias;
                    string MainField;
                    string ChildAlias;
                    string ChildField;
                    
                    if (JoinTableAlias == "")
                    GetTableAlias(DTEntity.Rows[j]["Table_Name"].ToString(), 
                                  EntityAlias1,
                                  out MainAlias, 
                                  out MainField,
                                  out ChildAlias, 
                                  out ChildField);
                        
                    ListTable[TableCount, 13] = ListTable[TableCount, 2];                         //JoinTableName
                    //ListTable[TableCount, 14] = GetTableAlias(JoinTableName, EntityAlias1);       //JoinTableAlias
                    ListTable[TableCount, 15] = ListTable[TableCount, 3];                         //JoinFieldName
                                       
                    JoinTableName  = ListTable[TableCount, 13];
                    JoinTableAlias = ListTable[TableCount, 14] ;                     
                    JoinFieldName  = ListTable[TableCount, 15];  
                    
                    AliasLast   = JoinTableAlias;
                    TableCount++;                    
                }                    
            }     
*/
 //======================================================================
/*
      //Очистка массивов.
        /*private void ParserClear()
        {            
            Array.Clear(ListUserStr, 0, ListUserStr.Length);
            Array.Clear(Words,       0, Words.Length);                 
            Array.Clear(ListEntity,  0, ListEntity.Length);   
            WordCount       = 0; 
            BraceLevelCount   = 0;  
            BraceNumCount     = 0; 
            SelectCount     = 0; 
            AliasCount      = 0;
            EntityCount     = 0;            
        }                       
                
*/
//======================================================================
/*
 //string s = ParserData.GetAttrPart(0, "aaa.bbb.ccc.WriteXLSX");
            //sys.SM(s);
            //dgvString.Columns.Count
            
            
            
            
            
            
            //return DotNumber.ToString();
                             
            //sys.SM(CompareTwoAttr("ДогСтрах.Агенты", "ДогСтрах.КаналПродаж.Код"));
            
            /*sSqlCommand = @"
                        Select Top 500 
                        [LINK], [nNumber], [cFileName], [dDateBegin], [dDateEnd]
                        From chel.repl_pak_out Order By nNumber Desc";
                    oComm = new SqlCommand(sSqlCommand);
                    oConn = new SqlConnection(this.sConnStr);
                    oConn.Open();
                    oComm.Connection = oConn;
                    dataSet = new DataSet("Pakets");
                    sqlDataAdapter = new SqlDataAdapter(oComm);
                    sqlDataAdapter.Fill(dataSet, "Pakets");  
          */
                                                    //DTAttrParent.DefaultView
            //var bd = new DevAge.ComponentModel.BoundDataView(dataSet.Tables["Pakets"].DefaultView);
            /*var bd = new DevAge.ComponentModel.BoundDataView(DTAttrParent.DefaultView);
            //bd.AllowDelete = false;
            //bd.AllowNew = false;
             //SourceGrid.GridVirtual.SelectionMode d;
             FBA.GridFBA DG;
            dataGrid1.DeleteQuestionMessage = null;
            //dataGrid1.SelectionMode = GridSelectionMode.Row;
            dataGrid1.FixedRows = 1;
            dataGrid1.FixedColumns = 1;
            //dataGrid1.SpecialKeys = GridSpecialKeys.Default;
            dataGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;// GridSelectionMode.Row;
            //dataGrid1.SelectionBorderMode = SourceGrid.SelectionBorderMode.FocusRange;
            dataGrid1.SpecialKeys   =   SourceGrid.GridSpecialKeys.Default;
            dataGrid1.DataSource = bd;
                     
*/
//======================================================================
/*
                      
            //Сначала нужно добавить основную таблицу сущности, на которую происходит ссылка.
            //string MainTable = "";
            /*for (int j = 0; j < ParserData.ArEntityY; j++)
            { 
                if ((ParserData.ArEntity[j, nBrief] == Entity1) &&
                    (ParserData.ArEntity[j, nTable_Name] != JoinTableName))
                    //(!TableExists(ParserData.ArEntity[j, nTable_Name], EntityAlias1)))
                {                         
                    ListTable[TableCount, tPos]             = TableCount.ToString();
                    ListTable[TableCount, tNum]             = Words[Pos1, Pos];                                
                    ListTable[TableCount, tTableName]       = ParserData.ArEntity[j, nTable_Name];        
                    ListTable[TableCount, tTableFieldID]    = ParserData.ArEntity[j, nTable_IDFieldName];   
                    ListTable[TableCount, tAlias]           = "AT" + TableCount;                                                       
                    ListTable[TableCount, tSelect]          = Select1;                                         
                    ListTable[TableCount, tTableType]       = "1"; //Основная                                   
                    ListTable[TableCount, tLexType]         = "ATTR";                                           
                    ListTable[TableCount, tEntity]          = Entity1;                                          
                    ListTable[TableCount, tEntityAlias]     = EntityAlias1;                                     
                    ListTable[TableCount, tSD]              = "GetDate()";                                       
                    ListTable[TableCount, tAttrFull]        = AttrFull1;                     
                    ListTable[TableCount, tProc]            = "TABLEMAIN";                                              
                    ListTable[TableCount, tLevel]           = "1";
                    ListTable[TableCount, tCompareDotLevel] = Words[Pos1, CompareDotLevel];
                    ListTable[TableCount, tCompareDotNum]   = Words[Pos1, CompareDotNum];
                    ListTable[TableCount, tAttrPart]        = ParserData.GetAttrPart(1, AttrFull1);                                                        
                    ListTable[TableCount, tJoinTableName]   = JoinTableName;                                        
                    ListTable[TableCount, tJoinTableAlias]  = JoinTableAlias;                                        
                    ListTable[TableCount, tJoinTableField]  = JoinTableField;                                       
                    
                    JoinTableName  = ListTable[TableCount, tTableName];
                    JoinTableAlias = ListTable[TableCount, tAlias];
                    JoinTableField = ListTable[TableCount, tTableFieldID];
                    AliasLast      = JoinTableAlias;
                                  
                    TableCount++;
                }                    
            }
            
*/
//======================================================================
/*
  //Выделить из составного атрибута две части, начиная с Level. Level начинается с 1.
        public static void GetAttrByLevel(int Level, string AttrInput, out string Str1, out string Str2)
        {                                    
            string[] DotArray = AttrInput.Split('.');
            Str1 = "";
            Str2 = "";
            if (DotArray.Count() > Level - 1) Str1 = DotArray[Level - 1];
            if (DotArray.Count() > Level)     Str2 = DotArray[Level];
        }
*/
//======================================================================
/*
 --Вложенность сущностей

--DROP TABLE #EntityParent
--DROP TABLE #AttrParent
--DROP TABLE #AttrChild
--DROP TABLE #Attr
--DROP TABLE dbo.A_Attr
--DROP TABLE dbo.A_EntityParent
--DROP TABLE dbo.A_AttrParent
--DROP TABLE dbo.A_AttrChild
--Вложенность сущностей
;WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID) AS
      (
        SELECT ID AS EnChildID, Brief AS EnBrief2, ID as EnID, Brief as EnBrief1, ParentID from fbaEntity
        --where ID = 1717
        UNION ALL
        SELECT EnChildID, EnBrief2, e.ID as EnID, e.Brief as EnBrief1, e.ParentID 
        FROM fbaEntity e INNER JOIN Parents p ON p.ParentID = e.ID
      ) SELECT * INTO #EntityParent FROM Parents ORDER BY EnBrief2, EnBrief1      
 
--Добавляем все таблицы, соединяя по ID
--SELECT t1.TableID, t1.Name as TableName, t1.IDFieldName, t1.Type as TableType, t1.Feature, 
--       t2.EnChildID, t2.EnBrief2, t2.EnID, t2.EnBrief1, t2.ParentID INTO dbo.A_mtEntity
--FROM #Tabl2 t2 
--  LEFT JOIN fbaTable t1 ON t1.TableEntityID = t2.EnID ORDER BY t2.EnBrief1 
      
--Подготовка таблицы с атрибутами
SELECT 
  AttributeID       AS ID,
  EntityID          AS EntityID,
  AttributeEntityID AS Attr_EntityID,
  Name              AS Attr_Name, 
  Brief             AS Attr_Brief,
  Type              AS Attr_Type,
  Kind              AS Attr_Kind,                             
  Mask                AS Attr_Mask,
  Feature            AS Attr_Feature,
  ObjectNameOrder   AS Attr_NameOrder,
  Code                AS Attr_Code,
  Description       AS Attr_Comment,
  TableID           AS Table_ID,
  FieldName         AS Table_Field,
  FieldName2        AS Table_Field2,
  RefEntityID        AS Ref_EntityID,
  RefAttributeID    AS Ref_AttrID
INTO #Attr     
FROM fbaAttribute 
     
ALTER TABLE #Attr ADD Table_Name varchar(100);            --Данные по таблице, в которой находится атрибут. Имя таблицы.
ALTER TABLE #Attr ADD Table_IDFieldName varchar(100);   --Данные по таблице, в которой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа)
ALTER TABLE #Attr ADD Table_Type int;                    --Тип таблицы (Главная или Историчная)
ALTER TABLE #Attr ADD Table_Feature int;                --Свойства таблицы.
ALTER TABLE #Attr ADD Ref_EntityBrief varchar(100);        --Сокращение сущности для атрибута Ссылки или Массива
ALTER TABLE #Attr ADD Ref_AttrBrief varchar(100);        --Сокращение атрибута сущности для атрибута Ссылки или Массива
ALTER TABLE #Attr ADD Ref_AttrName varchar(100);        --Наименование атрибута сущности для атрибута Ссылки или Массива
ALTER TABLE #Attr ADD Attr_EntityBrief varchar(100);    --Сокращение сущности, к которой относится атрибут.
--Данные по таблице атрибута
UPDATE #Attr set 
  #Attr.Table_Name        = t2.Name, 
  #Attr.Table_IDFieldName = t2.IDFieldName,
  #Attr.Table_Feature     = t2.Feature,
  #Attr.Table_Type        = t2.Type
FROM fbaTable t2 
WHERE #Attr.Table_ID = t2.TableID
--Данные для атрибута Ссылки или Массива.
UPDATE #Attr SET Ref_EntityBrief = t2.Brief FROM fbaEntity t2 WHERE #Attr.Ref_EntityID = t2.ID 
UPDATE #Attr SET Ref_AttrBrief   = t2.Brief, 
                 Ref_AttrName    = t2.Name 
FROM fbaAttribute t2 
WHERE #Attr.Ref_AttrID = t2.AttributeID and #Attr.Ref_EntityID = t2.AttributeEntityID
--Сущность атрибута 
UPDATE #Attr SET Attr_EntityBrief = t2.Brief FROM fbaEntity t2 WHERE #Attr.Attr_EntityID = t2.ID 
--Для каждой сущности весь полный список атрибутов, включая предков.
SELECT t1.*, t2.* INTO #AttrParent FROM #Attr t1 LEFT JOIN #EntityParent t2 ON t2.EnID = t1.Attr_EntityID 
--where t2.EnChildID = 1694       and Brief = 'Номер' --Выбор по определенной сущности по ИД.
--where t2.EnBrief2  = 'ДогСтрах' and Brief = 'Номер' --Выбор по определенной сущности по Сокращению.
SELECT t1.*, t2.* INTO #AttrChild
FROM #Attr t1 
 RIGHT JOIN #EntityParent t2 ON t2.EnChildID = t1.Attr_EntityID AND t1.Attr_Brief IS NOT NULL --1716 Расчетный документ                                                    
--WHERE t2.EnID = 1716 and t2.EnChildID <> 1716 order by AttrEntityBrief                            --Выбор по определенной сущности по ИД. Здесь только потомки.
--WHERE t2.EnBrief1 = 'РасчетныйДок' and t2.EnBrief2 <> 'РасчетныйДок' order by AttrEntityBrief  --Выбор по определенной сущности по Сокращению. Здесь только потомки.
--SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos,        * INTO dbo.A_Attr         FROM #Attr          ORDER BY ID
--SELECT ROW_NUMBER() OVER(ORDER BY EnChildID) Pos, * INTO dbo.A_EntityParent FROM #EntityParent  ORDER BY EnChildID
--SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos,        * INTO dbo.A_AttrParent   FROM #AttrParent    ORDER BY ID
--SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos,        * INTO dbo.A_AttrChild    FROM #AttrChild     ORDER BY ID
--SELECT * FROM #EntityParent     where EnBrief2 = 'ДогСтрах'
--SELECT * FROM #EntityParent     where EnBrief2 = 'ЗаявкаСМП'
--SELECT * FROM #EntityParent     where EnBrief1 = 'ЗаявкаСМП'
--SELECT * FROM #Attr        
--SELECT * FROM #AttrParent   
--SELECT * FROM #AttrChild
--SELECT * FROM fbaTable
--SELECT * FROM fbaAttribute
--SELECT * FROM dbo.A_Attr
--SELECT * FROM #EntityParent
--SELECT * FROM fbaEntity where Brief = 'ПростойСправочник'
--SELECT * FROM fbaEntity where Brief = 'ВидПлатежа'
--SELECT * FROM fbaTable  where Name  = 'SimpleRefBook'
SELECT * INTO #Entity FROM fbaEntity
ALTER TABLE #Entity ADD Table_ID varchar(100)
ALTER TABLE #Entity ADD Table_Name varchar(100)
ALTER TABLE #Entity ADD Table_IDFieldName varchar(100)
UPDATE #Entity SET Table_ID          = t2.TableID,
                   Table_Name        = t2.Name,
                   Table_IDFieldName = t2.IDFieldName                   
FROM fbaTable t2 WHERE t2.TableEntityID = #Entity.ID AND t2.Type = 1
--UPDATE #Entity SET Table_ID          = NULL,
--                   Table_Name        = NULL,
 --                  Table_IDFieldName = NULL
--SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos,        * INTO dbo.A_Entity FROM #Entity
*/
//======================================================================
/*
  //Получение текста INSERT для вставки записей в таблицу в БД из таблицы DT.
        public static string GetTextInsertTable_old(string ServerType, string TableName, System.Data.DataTable DT)
        {               
            string TextBeginTran = "";                                             
            var InsertText = new StringBuilder("", 10000);
            if (ServerType == "MSSQL")    TextBeginTran = "BEGIN TRANSACTION SET IDENTITY_INSERT " + TableName + " ON " + Var.CR;
            if (ServerType == "SQLite")   TextBeginTran = "BEGIN TRANSACTION;" + Var.CR;
            if (ServerType == "Postgre") TextBeginTran = "BEGIN TRANSACTION;" + Var.CR;             
            InsertText.Append(TextBeginTran);               
            var InsertBeg = new StringBuilder("INSERT INTO " + TableName + " (", 1000);
            int iColumnCount = DT.Columns.Count;
            bool Is19 = false; //Для того чтобы конвертировать дату.
            for (int i = 0; i < iColumnCount ; i++) 
            {
                InsertBeg.Append(DT.Columns[i].ColumnName);
                if (i < iColumnCount - 1) InsertBeg.Append(",");
                if (DT.Rows.Count > 0)
                  if (DT.Rows[0][i].ToString().Length == 19) Is19 = true;                            
            }                                      
            string InsertBegStr = InsertBeg.ToString() + ") VALUES (";
            var InsertStr = new StringBuilder("", 1000);  
            string Value;               
            if (Is19)
            {                
                for (int i = 0; i < DT.Rows.Count; i++)
                {             
                    InsertStr.Clear();
                    for (int j = 0; j < iColumnCount; j++)
                    {                      
                        Value = DT.Rows[i][j].ToString().DateTimeStrToMSSQL().Replace("'","''");
                        InsertStr.Append("'" + Value + "'"); 
                        if (j < iColumnCount - 1) InsertStr.Append(",");                        
                    }                               
                    InsertText.Append(InsertBegStr + InsertStr.ToString() + ");" + Var.CR);
                }  
            } else
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {             
                    InsertStr.Clear();                    
                    for (int j = 0; j < iColumnCount - 1; j++) 
                    {
                        Value = DT.Rows[i][j].ToString().Replace("'","''");
                        InsertStr.Append("'" + Value + "',");
                    }
                    Value = DT.Rows[i][iColumnCount- 1].ToString().Replace("'","''");
                    InsertStr.Append("'" + Value + "'");                     
                    InsertText.Append(InsertBegStr + InsertStr.ToString() + ");" + Var.CR);
                }      
            }           
            string TextEndTran = "";
            if (ServerType == "MSSQL")    TextEndTran = "SET IDENTITY_INSERT " + TableName + " OFF " + Var.CR + "COMMIT TRANSACTION; " + Var.CR;
            if (ServerType == "SQLite")   TextEndTran = Var.CR + " COMMIT TRANSACTION; " + Var.CR;
            if (ServerType == "Postgre") TextEndTran = Var.CR + " COMMIT TRANSACTION; " + Var.CR;             
            InsertText.Append(TextEndTran);
            return InsertText.ToString();  
        }             
   
*/ 
//======================================================================
/*
         //Обновить таблицы для парсера. Если таблиц, ещё нет, тобудут созданы.
        private void BtnParserCreateTableClick(object sender, EventArgs e)
        {
            //ParserData.CreateParserTable();
            //Установка соединения с локальной базой SQLIte. Без неё не работаем.
            Var.conLite = new Connection(); 
            if (Var.conLite.SetConnectionLocal() == false) return;
            
            var FormEnter1 = new FormEnter(false);
            FormEnter1.ShowDialog();
            FormEnter1.Dispose();  
            List<System.Data.DataTable> dtRtn1;
            string ErrorText ="";
            bool ErrorShow = false;
            string SQL = ListPrepare.Text; //"select 1 as a1; " + Var.CR + "select 2 as a2; " +  Var.CR + "select 3 as a3; ";
            Var.conSys.SelectDT(SQL, out dtRtn1, ref ErrorText, ErrorShow);
           
            
            string ParseTimeSQL1 = "";
            
            DateTime TotalStart1  = DateTime.Now;
                                                                                    
            SQL = sys.GetTextTableToDatabase2("SQLite", "fbaEntityParent",          dtRtn1[0], true);            
            DateTime TotalStop  = DateTime.Now;      
            TimeSpan Elapsed = TotalStop.Subtract(TotalStart1);
            TotalStart1 = TotalStop;
            ParseTimeSQL1 += Convert.ToString(Elapsed.TotalMilliseconds) + " - GetTextTableToDatabase2. " + Var.CR;    
             
            Var.conLite.Exec(SQL);
            TotalStop  = DateTime.Now;         
            Elapsed = TotalStop.Subtract(TotalStart1);
            TotalStart1 = TotalStop;
            ParseTimeSQL1 += Convert.ToString(Elapsed.TotalMilliseconds) + " - Exec GetTextTableToDatabase2. " + Var.CR;
            
            SQL = sys.GetTextTableToDatabase("SQLite", "fbaEntityParent",          dtRtn1[0], true);            
            TotalStop  = DateTime.Now;       
            Elapsed = TotalStop.Subtract(TotalStart1);
            TotalStart1 = TotalStop;
            ParseTimeSQL1 += Convert.ToString(Elapsed.TotalMilliseconds) + " - GetTextTableToDatabase. " + Var.CR;
             
            Var.conLite.Exec(SQL);
            TotalStop  = DateTime.Now;        
            Elapsed = TotalStop.Subtract(TotalStart1);
            TotalStart1 = TotalStop;
            ParseTimeSQL1 += Convert.ToString(Elapsed.TotalMilliseconds) + " - Exec GetTextTableToDatabase. " + Var.CR + 
                "===========" + Var.CR;
            
            
            txTime.Text += ParseTimeSQL1;
            //SQL = Var.CR + sys.GetTextTableToDatabase("SQLite", "fbaEntity",       dtRtn1[1], true);
            //Var.conLite.Exec(SQL);  
            
            //SQL = Var.CR + sys.GetTextTableToDatabase("SQLite", "fbaAttrParent",   dtRtn1[2], true);
            //Var.conLite.Exec(SQL);  
            
            //SQL = Var.CR + sys.GetTextTableToDatabase("SQLite", "fbaAttrChild",    dtRtn1[3], true);
            //Var.conLite.Exec(SQL);  
            
            sys.SM("Выполнено!", MessageType.Information);
        }       
    }
*/ 
 //======================================================================
/*
    //Получение текста DROP TABLE, CREATE TABLE, INSERT для копирования таблицы DT на сервер. DatabaseType: MSSQL, Postgre, SQLite. 
        public static string GetTextTableToDatabase2(string ServerType, string TableName, System.Data.DataTable DT, bool CreateTable)
        {                              
            string TextDropCreateTable = "";           
            if (CreateTable) TextDropCreateTable = sys.GetTextDropTable(ServerType, TableName) + Var.CR + sys.GetTextCreateTable(ServerType, TableName, DT);    
            return TextDropCreateTable + sys.GetTextInsertTable2(ServerType, TableName, DT);
        }
*/
//======================================================================
/*
 //Получить имя компонента переданного в обработчик события как object.
        public static string GetSenderName(object sender)
        {    
            return sender.GetType().GetProperty("Name").GetValue(sender).ToString();
            
            //string SenderName = "";   
            //return (sender as Control).Name;             sender.Name           
            /*switch (sender.GetType().ToString())
            {                                              sender as 
                case ("System.Windows.Forms.Button"):
                    SenderName = (sender as System.Windows.Forms.Button).Name.ToString();
                    break;
                case ("System.Windows.Forms.ToolStripButton"):
                    SenderName = (sender as ToolStripButton).Name.ToString();
                    break;
                case ("System.Windows.Forms.ToolStripMenuItem"):
                    SenderName = (sender as ToolStripMenuItem).Name.ToString();
                    break;
                case ("System.Windows.Forms.ToolStripDropDownButton"):
                    SenderName = (sender as ToolStripDropDownButton).Name.ToString();
                    break;                
            }*/
            //return SenderName;
        //}        
 //======================================================================
/*
    
            //По составным атрибутам.  
            /*for (int i = 0; i < WordCount; i++)
            {                                                         
                if (Words[i, wLexType] != "ATTR") continue;       
                if (Words[i, wAttrComplex] == "0")  continue;   
                
                //if (TableExists(Words[i, TableName], Words[i, EntityAlias])) continue; 
                string JoinTableName  = "";
                string JoinTableAlias = "";
                string JoinTableField = ""; 
                //string EntityRef      = "";
                
                GetTableByAlias(Words[i, wEntityAlias], Words[i, wSelect], 
                                out JoinTableName,
                                out JoinTableAlias, 
                                out JoinTableField);
                 
                //for (int j = 0; j < ParserData.ArAttrParentY; j++)
                //{                              
                //    if ((ParserData.ArAttrParent[j, iEnBrief2]   == Words[i, Entity]) &&
                //        (ParserData.ArAttrParent[j, iAttr_Brief] == Words[i, AttrFirst]))                      
                //      EntityRef = ParserData.ArAttrParent[j, iRef_EntityBrief];                                           
                //}
                
                AddTableLink(1,                         //Level, 
                             i,                         //Pos
                             Words[i, wSelect],          //Select1, 
                             Words[i, wAttrFull],        //AttrFull1, 
                             Words[i, wRef_EntityBrief], //Entity1, 
                             Words[i, wEntityAlias],     //EntityAlias1, 
                             Words[i, wAttrComplex],     //AttrComplex1
                             JoinTableName,
                             JoinTableAlias,
                             JoinTableField);                                                     
            }      
*/
//======================================================================
/*
    //Label lb = (Label)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
*/
//======================================================================
/*
   private void GetAllControls(Control.ControlCollection controls, ref string s)
        {
            
            
         /*   try
        {
            // Get the Type object corresponding to MyClass.
            Type myType=typeof(MyClass);       
            // Get the PropertyInfo object by passing the property name.
            PropertyInfo myPropInfo = myType.GetProperty("MyProperty");
            // Display the property name.
            Console.WriteLine("The {0} property exists in MyClass.", myPropInfo.Name);
        }
        catch(NullReferenceException e)
        {
            Console.WriteLine("The property does not exist in MyClass." + e.Message);
        }
          (*/  
            //string s = "";
            //foreach(Control control in controls)
            //{                
                //Type myType = control.GetType();
                //PropertyInfo myPropInfo = myType.GetProperty("Controls");
                //if (myPropInfo != null) 
                // GetAllControls(control.Controls, ref s);
                
              
                    //TextBox tb = control as TextBox;
                    //CheckBox ch = control as CheckBox;
                    //if (tb != null && ch != null)
                    //{
                    //    ch.Text = tb.Text;
                    //}
                    //if control.Tag
                       
                 // s = s + control.Name + Var.CR;
               
               
            
                //Type myType = typeof(control.GetType());
                //if control.
                //try
                //{
                    //MyTextboxOperation((TextBox)control);
                //}
                //catch (InvalidCastException)
                //{
                    //ClassifiedControls(control.Controls);
                //}
            
            //sys.SM(s);
           
        
//======================================================================
/*
        
        /*public FormAttr(string Operation, string ID)
        {   
            InitializeComponent(); 
            this.Operation = Operation;
            this.ID        = ID;
            DT1 = new System.Data.DataTable();
            
          
            if (Operation != "Add")
            {
                //tbID.Text      = RoleID;
                //tbName.Text    = Name;           
                //tbBrief.Text   = Brief; 
            }                           
        }*/
        
        /*
         * private void ClassifiedControls(Control.ControlCollection controls)
{
    foreach(Control control in controls)
    {
        try
        {
            MyTextboxOperation((TextBox)control);
        }
        catch (InvalidCastException)
        {
            ClassifiedControls(control.Controls);
        }
    }
}*/
        //Перебор всех контролов на форме.      
        /*private void GetAllControls(Control.ControlCollection controls, ref ArrayList ctrl)
        {    
            foreach(Control control in controls)
            {                      
                 GetAllControls(control.Controls, ref ctrl);                            
                 if (control.Tag != null)
                     ctrl.Add(control.Name + ":" + control.Tag + " text:" + control.Text.Replace(Var.CR, "<#>"));
            }                    
        }*/
         
 
//======================================================================
/*
   /*
         *  //2. Возможность показать значение в компоненте на форме из атрибута сущности.
        public void SetQueryEntity(string EntityBrief, string ObejctID)
        {    
            //Если параметров 2 или четное количество, то значит в параметрах передаются сущности (таблицы) и
            //Пример вызова: 
            //SetEntityArray("Застрахванный(1)", ""
            if (L % 2 == 0)
            for (int i = 0; i < fbaAttr.Length; i++)
            {
                //Ent[EntCount, nPos]      = EntCount.ToString();
                //Ent[EntCount, nDirect]   = "0";
                //Ent[EntCount, nNeedSave] = "1";                     
               
                string s = fbaAttr[i];
                string[] DotArray = s.Split('.');                
                Ent[EntCount, nBrief] = DotArray[0];
                if (DotArray.Length > 0) Ent[EntCount, nBrief] = DotArray[1];
                 else Ent[EntCount, nBrief] = "";
                
                Ent[EntCount, nPos]         = EntCount.ToString();
                Ent[EntCount, nName]        = "";
                Ent[EntCount, nBrief]       = "";
                Ent[EntCount, nIDFieldName] = "";
                Ent[EntCount, nLanguage]    = Lang; 
                Ent[EntCount, nDirect]      = "1";
                Ent[EntCount, nNeedSave]    = "0"; 
                Ent[EntCount, nID]          = "";            
                Ent[EntCount, nSQL]         = Query;       
                
                
                
                
                    
                i++;
                 //Ent[EntCount, nID]    = fbaAttr[i];
                 EntCount++;     
            }            
        }
        */
       
       
  
//======================================================================
/*
   //Создаем запросы SELECT для чтения всех значений из БД.
        public void CreateSelect()
        {        
            
   
            
            
            for (int i = 0; i < EntCount; i++)
            {
                string Entity      = Ent[i, nBrief];
                string IDFieldName = Ent[i, nIDFieldName];
                string ID          = Ent[i, nID];
                string IDS = "ИДОбъекта";
                 string SQL = "SELECT ";
                 
                 int AttrCount = 0;
                 for (int j = 0; j < RefCount; j++)
                 {                     
                     if (Ref[j, iEntity] != Entity) continue;                 
                     if (AttrCount > 0) SQL += ", ";
                     SQL += Ref[j, iAttr];
                     AttrCount++;                 
                 }             
                 if (IDFieldName != "") IDS = IDFieldName;
                 else
                 {                     
                     if (Entity.IndexOf("fba") == 0) IDS = "ID";
                 }                                             
                 SQL += " FROM " + Entity + " WHERE " + IDS + " = " + ID; 
                 Ent[i, nSQL] = SQL.Replace("(1)", "").Replace("(2)", "").Replace("(3)", "").Replace("(4)", "").Replace("(5)", "");
            }
        }
  
*/ 
//======================================================================
/*
 //Создаем запросы SELECT для чтения всех значений из БД.
        public void CreateSelect()
        {                                                                    
            for (int i = 0; i < EntCount; i++)
            {
                string TypeQuery = Ent[i, nType];
                
                //1. Возможность показать значение в компоненте на форме из таблицы в БД.
                if (TypeQuery == "1")
                {
                    string TableName   = Ent[i, nTableName];
                    string IDFieldName = Ent[i, nIDFieldName];
                    string ObjectID    = Ent[i, nObjectID];
                    string Attr = "";
                    string SQL  = "";
                    for (int j = 0; j < RefCount; j++)
                    {                     
                         if (Ref[j, iEntity] != TableName) continue;                 
                         if (Attr != "") Attr += ", ";
                         Attr += Ref[j, iAttr];                                        
                    }                                    
                    TableName = TableName.Replace("(1)", "").Replace("(2)", "").Replace("(3)", "").Replace("(4)", "").Replace("(5)", "");                                      
                    SQL = "SELECT " + Attr + " FROM " + TableName + " WHERE " + IDFieldName + " = " + ObjectID; 
                    Ent[i, nSQL] = SQL;                        
                }
                
                //2. Возможность показать значение в компоненте на форме из атрибута сущности.
                if (TypeQuery == "2")
                {
                    string EntityBrief = Ent[i, nEntityBrief];                    
                    string ObjectID    = Ent[i, nObjectID];
                    string Attr = "";
                    string SQL  = "";
                    for (int j = 0; j < RefCount; j++)
                    {                     
                         if (Ref[j, iEntity] != EntityBrief) continue;                 
                         if (Attr != "") Attr += ", ";
                         Attr += Ref[j, iAttr];                                
                    }                                    
                    EntityBrief = EntityBrief.Replace("(1)", "").Replace("(2)", "").Replace("(3)", "").Replace("(4)", "").Replace("(5)", "");                                      
                    SQL = "SELECT " + Attr + " FROM " + EntityBrief + " WHERE ИДОбъекта = " + ObjectID; 
                    Ent[i, nSQL] = SQL;                        
                }
                
                //3. Возможность показать значение в компоненте на форме из результата прямого запроса.
                if (TypeQuery == "3")
                {                                     
                    //Если запрос уже есть, то ничего делать больше не нужно.
                    continue;
                }           
            }
        }
*/ 
 //======================================================================
/*
          //Обновить данные в гриде.
        public bool RefreshGrid(string SQL, DataGridView Grid)   //
        {        
            try
            {
               //Grid .
               // int IDCur1 = -1;
                //int IDCur2 = -1;  
                //int i = -1;
                string IDCur = "";
                //string IDCur2 = "";
                //if 
                //if (Grid.RowCount > 0)
                //foreach (DataGridViewColumn column in Grid.Columns)            
                //if (column.HeaderText == "ID") 
                //{
                    //IDCur1 = Convert.ToInt32(Grid.CurrentRow.Cells["ID"].Value);
                //    IDCur1 = Convert.ToInt32(Grid.SelectedRows[0].Cells["ID"].Value);
                //    break;
                //}     
                //if (Grid.Rows.Count > 0) return Grid.Rows[0][FieldName].ToString();  
                if (Grid.Columns.Count > 0)//
                {
                    if (Grid.Columns[0].HeaderText == "ID")
                    {
                        //if (Grid.SelectedRows.Count > 0)
                        if (Grid.CurrentRow.Index > 0)
                            //IDCur = Grid.SelectedRows[0].Cells["ID"].Value.ToString();
                            IDCur = Grid.Rows[Grid.CurrentRow.Index].Cells[0].Value.ToString();
                            
                    }                
                    //Grid.Rows[Grid.SelectedRows[0].Index][0].ToString
                }
                                         
                SelectGV(SQL, Grid);
                
                foreach (DataGridViewColumn column in Grid.Columns) 
                {
                    if (column.Width > 400) column.Width = 400;
                }
                
                if (IDCur == "") return true;
                
                for (int i = 0; i < Grid.Rows.Count; i++)
                {   
                    if (Grid.Rows[i].Cells[0].Value != null)
                    if (IDCur == Grid.Rows[i].Cells[0].Value.ToString())
                    {
                        //Grid.CurrentRow.Selected = false; 
                        Grid.Rows[i].Selected = true;
                        //Grid.CurrentRow.Index = i;
                        //(((System.Data.DataTable)Grid.DataSource).Rows[0].
                        return true;
                    }                                             
                }
                 //dataGridView1.FirstDisplayedCell = dataGridView1.Rows[x].Cells[0];
                /*if ((Grid.RowCount > 0) && (IDCur1 > -1))
                    foreach(DataGridViewRow row in Grid.Rows)
                    {   
                        IDCur2 = Convert.ToInt32(row.Cells["ID"].Value);
                        i += 1;                    
                        if (IDCur1 == IDCur2) 
                        {
                            //Grid.CurrentRow.Selected = false; 
                            Grid.Rows[row.Index].Selected = true;
                            //Grid.CurrentRow.Index = i;
                            return true;
                        }
                    } */
                
          /*      return true;
            }
            catch (Exception ex)
            {
                sys.SM("Ошибка запроса: " + Var.CR + ex.Message);
                return false;
            }      
        }  */
//======================================================================
/*
    /*
   * var selectedTeams = new List<string>();
foreach(string s in teams)
{
    if (s.ToUpper().StartsWith("Б"))
        selectedTeams.Add(s);
}
selectedTeams.Sort();
 
foreach (string s in selectedTeams)
    Console.WriteLine(s);
    *
*/
 //======================================================================
/*
             
        //Получить значние с номером N из строки, которая содержит разделители в виде точки.
        /*private string GetElementN(string Attr, int N)
        {
            string[] DotArray = Attr.Split('.');
            if (DotArray.Length < N) return "";
            return DotArray[N];            
        }
        
        //Получить значение атрибута после первой точки.
        private string GetElementL(string Attr)
        {
            int N = Attr.IndexOf('.');
            return Attr.Substring(N + 1);             
        }
                 
*/
//======================================================================
/*
            
        //Конструктор формы.
        //Вызов формы var FormFBA = new FormFBA(EntityBrief1, ID1, EntityBrief2, ...);
        //public FormFBA(params string[] fbaAttr)
        //{   
        //    SetEntitArray();
        //}
        
        //public FormFBA()
        //{  
            
        //}
*/
//======================================================================
/*
         //Заполнение свойств компонентов из массива Ref. 
        //private void SetComponentValue()
        //{                      
        //    FillValueOld();
        //    for (int i = 0; i < RefCount; i++)
        //    {
        //        string ControlName = Ref[i, iName];             
        //        this.Controls.Find(Ref[i, iName], false).FirstOrDefault().Text = Ref[i, iValueOld];                
        //    }          
        //}  
        
*/
//======================================================================
/*
  //Посылка запросов к БД.
        private bool SendSelect()
        {
            LocalSQL  = CollectSelect("Local");
            RemoteSQL = CollectSelect("Remote");                     
            string ErrorText = "";
            const bool ErrorShow = true;
            
            /*if (LocalSQL != "")
            {                 
                if (Var.conSys == null)
                {
                     Var.conLite = new Connection();
                     if (Var.conLite.SetConnectionLocal() == false) return false;
                }                      
                if (!Var.conLite.SelectDT(LocalSQL,  out dtRtnLocal,  ref ErrorText, ErrorShow)) return false;
            }
            if (RemoteSQL != "")
            {                 
                if (Var.conSys == null)
                {
                    var FormEnter1 = new FormEnter(true);
                    FormEnter1.ShowDialog();
                    FormEnter1.Dispose(); 
                }
                if (!Var.conSys.SelectDT(RemoteSQL, out dtRtnRemote, ref ErrorText, ErrorShow)) return false;
            }         */
            
          //  return true;           
        //}
//======================================================================
/*
         
        //Составляем список настроек.
        /*private string GetSettings()
        {              
           
            for (int j = 0; j < RefCount; j++)
            {                     
                if (Ref[j, iQueryName].ToUpper() != "SAVE") continue;                
                string s = Ref[RefCount, iName] + ":" + Ref[RefCount, iValueNew];
                s = s.Replace(Var.CR, "<#*#>");
                ArrValue.Add(s);                             
            } 
            return ArrValue.ToString();                 
        }*/
         
 
//======================================================================
/*
   
        //Установка вручную свойства компонента.
        public bool SetValueRef(string ComponentName, string ComponentValue)
        {
            bool Setted = false; //Действительно найден и компнент и атрибут, на который он указывает.
            for (int i = 0; i < RefCount; i++)
            { 
                if ((Ref[i, iName] == ComponentName))
                {                    
                    Control control = this.Controls.Find(ComponentName, false).FirstOrDefault();
                    if (control != null) 
                    {
                        Ref[i, iValueOld] = ComponentValue;
                        Ref[i, iValueNew] = ComponentValue;
                        control.Text = ComponentValue; //При этом присвоении вызовется ControlValueChanged автоматически.
                        Setted = true;
                    }                   
                }
            } 
            return Setted;
        }
*/ 
 //======================================================================
/*//Установка свойства компонента.
        public bool SetValueRef(string ComponentName, string ComponentValue)
        {
            
            
            bool Setted = false; //Действительно найден и компнент и атрибут, на который он указывает.
            for (int i = 0; i < RefCount; i++)
            { 
                if ((Ref[i, iName] == ComponentName))
                {                    
                    Control control = this.Controls.Find(ComponentName, true).FirstOrDefault();
                    if (control != null) 
                    {
                        Ref[i, iValueOld] = ComponentValue;
                        Ref[i, iValueNew] = ComponentValue;
                        control.Text = ComponentValue; //При этом присвоении вызовется ControlValueChanged автоматически.
                        Setted = true;
                    }                   
                }
            } 
            return Setted;
        }
 
*/
//======================================================================
/*
    //Установка свойства компонента.
        public bool SetValueRef(string ComponentName, string ComponentValue)
        {                                         
            Control control = this.Controls.Find(ComponentName, true).FirstOrDefault();
            if (control != null) 
            {                      
                control.Text = ComponentValue; //При этом присвоении вызовется ControlValueChanged автоматически.
                return true;
            }                                              
            return false;
        }
*/
 //======================================================================
/*
        
        //Составляем список настроек.
        /*private string GetSettings()
        {              
            string Value = "";
            for (int i = 0; i < RefCount; i++)
            {                     
                if (Ref[i, iSetting].ToUpper() != "SAVE") continue;                
                string s = Ref[i, iName] + ":" + Ref[i, iValueNew];
                s = s.Replace(Var.CR, "<#*#>");
                Value += s + Var.CR;                             
            } 
            return Value;                 
        }
*/
//======================================================================
/*
      //Установка значения компонента из fbaSetting.
        /*public bool SetValueRef(string ControlName, string ControlValue)
        {               
            for (int i = 0; i < RefCount; i++)
            { 
                if ((Ref[i, iName] == ControlName))
                {                                                         
                    Ref[i, iValueOld] = ControlValue;
                    Ref[i, iValueNew] = ControlValue;
                    return true;
                }
            } 
            Control control = this.Controls.Find(ControlName, false).FirstOrDefault();
            return false;
        }*/
        
        
        
               //if (control != null) 
               // control.Text = ControlValue; //При этом присвоении вызовется ControlValueChanged автоматически.
               //     {
              //Control control = this.Controls.Find(ControlName, false).FirstOrDefault();
          //for (int j = 0; j < RefCount; j++)
         //       {
         //           if (Ref[j, iEnt] != i.ToString()) continue;
         //           if (Ref[j, iValueOld] == Ref[j, iValueNew]) continue; 
                    
        
        
        //Установка компонентов из fbaSetting.
  
        //Перебор всех контролов на форме, и запись в массив Ref.     
        /*private void GetControlsValue(Control.ControlCollection controls)
        {    
            foreach(Control control in controls)
            {                      
                GetControlsValue(control.Controls);                            
                if (control.Tag != null)
                {
                    //Пример формата строки в Tag: Main.СтрахПолис.Номер;Save
                    //Где Main - это запись в Ent (Objectref)
                    //СтрахПолис.Номер - атрибут
                    //Save - признак, что этот компонент нужно сохранять/загружать в настройках. Настройки - таблица fbaSetting.
                    //Save может отсутствовать, как и знак ; перед ним.
                    
                    string QueryName = "";
                    string Attr      = "";
                    string Setting   = "";
                    string TagStr = control.Tag.ToString();
                    if (TagStr.ToUpper().Trim() == "SAVE")
                    {
                        Setting = "SAVE";
                    }  else
                    {
                       string[] DotArray = TagStr.Split(';');               
                       Setting = (DotArray.Count() > 1)?DotArray[1].ToUpper().Trim():"";
                       int N = DotArray[0].IndexOf('.');
                       QueryName = DotArray[0].Substring(0, N).Trim();
                       Attr      = DotArray[0].Substring(N + 1).Trim();
                    }                                                                           
                    
                    Ref[RefCount, iPos]         = RefCount.ToString();
                    Ref[RefCount, iTypeAction]  = "";
                     Ref[RefCount, iName]        = control.Name;                      
                     Ref[RefCount, iTypeControl] = control.GetType().ToString();
                     Ref[RefCount, iTag]         = TagStr; 
                     Ref[RefCount, iQueryName]   = QueryName;
                     Ref[RefCount, iAttr]        = Attr;
                     Ref[RefCount, iEnt]         = ""; //На этот момент Ent ещё не известен. 
                     Ref[RefCount, iEntityBrief] = ""; 
                    Ref[RefCount, iTableName]   = "";  
                    Ref[RefCount, iFieldName]   = ""; 
                    Ref[RefCount, iIDFieldName] = "";                             
                     Ref[RefCount, iPosLocal]    = ""; //На этот момент PosLocal ещё не известен.  
                     Ref[RefCount, iPosRemote]   = ""; //На этот момент PosRemote ещё не известен. 
                     Ref[RefCount, iSetting]     = Setting; //На этот момент PosRemote ещё не известен.
                     Ref[RefCount, iValueOld]    = control.Text;
                     Ref[RefCount, iValueNew]    = control.Text;                        
                    RefCount++;
                }                   
            }                    
        }
        
        
        
        
        
        
       
        
*/
//======================================================================
/*
  //Сборка всех запросов UPDATE.
        private string CollectUpdate(string Direction)
        {                        
            string TotalSQL = "";
            string SQL = "";
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nDirection] != Direction) continue;
                if (Ent[i, nTypeAction] != "Table") continue;                               
                SQL = Ent[i, nUpdate];
           //     TotalSQL += "/*" + i + "*/ //" + SQL + "; " + Var.CR;                
           // } 
    //        
            
            
            
            
    //        return TotalSQL;
    //    }  
        
        //Посылка запросов к БД.
   /*     private bool SendUpdate()
        {
            LocalSQL  = CollectUpdate("Local");
            RemoteSQL = CollectUpdate("Remote");                                                     
            if (LocalSQL != "")     
                // public static bool Exec(string Direction, string SQL, out string ID)
                
                if (!sys.Exec(DirectionQuery.Local, LocalSQL)) return false;
            if (RemoteSQL != "")  
                if (!sys.Exec(DirectionQuery.Remote, RemoteSQL)) return false;
            return true;             
        } 
*/
//======================================================================
/*
          //Посылка запросов к БД.
        private bool SendUpdate()
        {
            LocalSQL  = CollectUpdate("Local");
            RemoteSQL = CollectUpdate("Remote");                                                     
            if (LocalSQL != "")     
                // public static bool Exec(string Direction, string SQL, out string ID)
                
                if (!sys.Exec(DirectionQuery.Local, LocalSQL)) return false;
            if (RemoteSQL != "")  
                if (!sys.Exec(DirectionQuery.Remote, RemoteSQL)) return false;
            return true;             
        }
*/
//======================================================================
/*
        // ============================================================================= Слово "день" с правильным окончанием
public string DaysCorrectEnding(float Value) : String;
var
  S : String;
  LastNum, PrelastNum : Integer;
  Num : Integer;
begin
  Result := 'дней';
  S := IntToStr( Trunc(Value) );
  LastNum := StrToInt( Copy(S, Length(S), 1) );
  PreLastNum := 0;
  if Length(S) >= 2 then
    PreLastNum := StrToInt( Copy(S, Length(S)-1, 1) );
  if (LastNum = 0) then // пример: 0 дней, 10 дней, 100 дней, 230 дней
    Result := 'дней';
  if (LastNum = 1) and (PreLastNum <> 1) then // пример: 1 день, 21 день, 1961 день
    Result := 'день';
  if (LastNum = 1) and (PreLastNum = 1) then // пример: 11 дней, 311 дней
    Result := 'дней';
  if (LastNum >= 2) and (LastNum <= 4) and (PreLastNum <> 1) then // пример: 2 дня, 33 дня, 1034 дня
    Result := 'дня';
  if (LastNum >= 2) and (LastNum <= 4) and (PreLastNum = 1) then // пример: 12 дней, 113 дней
    Result := 'дней';
  if (LastNum >= 5) and (LastNum <= 9) then // пример: 15 дней, 288 дней, 29 дней
    Result := 'дней';
end;
	}
}
*/
//======================================================================
/*
 //Сборка UPDATE для типа запроса из атрибутов сущности.        
        private void GetUpdateEntity()
        {                                                                                                   
            for (int i = 0; i < TblCount; i++)
            {                                 
                string UpdateValues    = "";
                string InsertFields    = "";
                string InsertValues    = "";
                string TableName   = Tbl[i, tTableName];
                string IDFieldName = Tbl[i, tIDFieldName];
                int EntPos         = Tbl[i, tEnt].ToInt();
                
                for (int j = 0; j < RefCount; j++)
                {
                    if (Ref[j, iTableName] != TableName) continue;
                    if (Ref[j, iTypeAction] != "Entity") continue; 
                    
                    //Для UPDATE.
                    if (UpdateValues != "") UpdateValues += ", ";
                    UpdateValues = UpdateValues + Ref[j, iFieldName] + " = '" + Ref[j, iValueNew] + "'";
                     
                    //Для INSERT.
                    if (InsertFields != "") InsertFields += ", ";
                    if (InsertValues != "") InsertValues += ", ";
                    InsertFields = InsertFields + Ref[j, iFieldName];
                    InsertValues = InsertValues + "'" + Ref[j, iValueNew] + "'";
                }   
                                 
                if (UpdateValues != "") Ent[EntPos, nUpdate] += "UPDATE " + TableName + " SET " + UpdateValues + " WHERE " + IDFieldName + " = " + Ent[EntPos, nObjectID] + Var.CR;
                if (InsertFields != "") Ent[EntPos, nInsert] += "INSERT INTO " + TableName + " (" + InsertFields + ") VALUES (" + InsertValues + ")" + Var.CR;  
            }                      
        }  
*/ 
//======================================================================
/*
     
        /*
         *  if (Ent[i, nTypeAction] != "Entity") continue;
                if ((QueryName != "") && (Ent[i, nQueryName] != QueryName)) 
                {
                    Ent[i, nUpdate] = "";
                    Ent[i, nInsert] = "";
                    Ent[i, nDelete] = "";
                    continue;
                }
                string EntPos         = Ent[i, nPos];
                string ObjectID       = Ent[i, nObjectID];
                string QueryNameLocal = Ent[i, nQueryName]; 
                                
         */ 
        //Сделать удаление из таблицы и объекта сущности
        //Сборка UPDATE для типа запроса из атрибутов сущности.        
        /*private void GetUpdateEntity()
        {                                                                                                   
            for (int i = 0; i < TblCount; i++)
            {                                 
                /*string UpdateValues    = "";
                string InsertFields    = "";
                string InsertValues    = "";
                string TableName   = Tbl[i, tTableName];
                string IDFieldName = Tbl[i, tIDFieldName];
                int EntPos         = Tbl[i, tEnt].ToInt();
                
                for (int j = 0; j < RefCount; j++)
                {
                    if (Ref[j, iTableName] != TableName) continue;
                    if (Ref[j, iTypeAction] != "Entity") continue; 
                    
                    //Для UPDATE.
                    if (UpdateValues != "") UpdateValues += ", ";
                    UpdateValues = UpdateValues + Ref[j, iFieldName] + " = '" + Ref[j, iValueNew] + "'";
                     
                    //Для INSERT.
                    if (InsertFields != "") InsertFields += ", ";
                    if (InsertValues != "") InsertValues += ", ";
                    InsertFields = InsertFields + Ref[j, iFieldName];
                    InsertValues = InsertValues + "'" + Ref[j, iValueNew] + "'";
                }   
                                 
                if (UpdateValues != "") Ent[EntPos, nUpdate] += "UPDATE " + TableName + " SET " + UpdateValues + " WHERE " + IDFieldName + " = " + Ent[EntPos, nObjectID] + Var.CR;
                if (InsertFields != "") Ent[EntPos, nInsert] += "INSERT INTO " + TableName + " (" + InsertFields + ") VALUES (" + InsertValues + ")" + Var.CR;  
                
            }
        }
        
*/ 
    //======================================================================
/*
                
            /*string QueryName = "";
            string Attr      = "";
            string Setting   = "";
            const string TagStr    = " Main.aaa.bbb.ccc "; //control.Tag.ToString();
            if (TagStr.ToUpper().Trim() == "SAVE")
            {
                Setting = "SAVE";
            }  else
            {
               string[] DotArray = TagStr.Split(';');               
               Setting = (DotArray.Count() > 1)?DotArray[1].ToUpper().Trim():"";
               int N = DotArray[0].IndexOf('.');
               QueryName = DotArray[0].Substring(0, N).Trim();
               Attr      = DotArray[0].Substring(N + 1).Trim();
            }   
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/