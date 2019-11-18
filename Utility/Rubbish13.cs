/*
//ДВУМЕРНЫЙ массив. Массив преобразовать в DataTable. ColumnCaption - через точку с запятой. 
        //maxColumns - количество колонок, которые нужно взять из входного массива. 0, значит все.
		//maxRows    - количество строк, которые нужно взять из входного массива. 0, значит все.         
        //ShowNum    - добавить порядковый номер строки.
        public static bool ArrayToDataTable(string[,] ar2, string ColumnsCaption, out System.Data.DataTable DT, int maxColumns, int maxRows, bool ShowNum)
        {
            return ArrayToDataTable(ar2, ColumnsCaption, out DT, 0, 0, maxColumns, maxRows, ShowNum)
        	/*DT = new System.Data.DataTable();
            if (maxRows < 1) maxRows = ar2.GetLength(0);
            if (maxColumns < 1) maxColumns = ar2.GetLength(1);
            if (ColumnsCaption.Length == 0)
            {
                for (int i = 0; i < maxColumns; i++) DT.Columns.Add("Column" + (i + 1));
            } else
            {
                string[] Cap = ColumnsCaption.Split(';');
                for (int i = 0; i < maxColumns; i++)
                {
                    string ColCap = "";
                    if (Cap.Length > i) ColCap = Cap[i]; else ColCap = "Column" + i.ToString();
                    //if (ColCap == "") sys.SM("Error - Column " + i.ToString());
                    DT.Columns.Add(ColCap);
                }
            }
            int N = 0;
            if (ShowNum) N = 1;
            try
            {
                var word = new string[maxColumns + N];
                for (int i = 0; i < maxRows; i++)
                {
                    if (ShowNum) word[0] = i.ToString();
                    for (int j = 0; j < maxColumns; j++) word[j + N] = ar2[i, j];
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
       
        
        //Запись новых значений компонентов,перед записью в БД. После буде сравниваться значения Ref[i, iValueNew] и Ref[i, iValue], и если они не равны, то должна производиться запись в БД.
        /*private void CheckControlValueChanged(Control.ControlCollection controls)
        {    
            
            //string text1 = form.Controls.Find("tbComment", true).FirstOrDefault().Text;   
            //Цикл по массиву компонентов.
            foreach(Control control in controls)
            {                                                                                                                          
                CheckControlValueChanged(control.Controls);                  
                for (int i = 0; i < RefCount; i++)
                {
                    
                    if (Ref[i, iName] != control.Name) continue;
                    Ref[i, iValueNew] = control.Text;                   
                }                                    
            }  

            //for (int i = 0; i < RefCount; i++)
            //{            
            //   Ref[i, iValueNew] = form.Controls.Find(Ref[i, iName], true).FirstOrDefault().Text;                  
            //}      
            
        }*/
        #region Region. Save_Object.
        
        
         //Для Delete прямой проход по массиву. = ""; 					                			        
                //for (int j = maxLevel; j > -1; j--)
                //{
                //	string sqlUpdate = "";
                //	string sqlInsert = ""; 
				//	string sqlDelete = ""; 
                //	GetQuery_UPDATE_INSERT_SaveObject(QueryName, EntityBrief, 2, maxLevel, out sqlUpdate, out sqlInsert, out sqlDelete);
                //	sqlDeleteAll = sqlDeleteAll + Var.CR + sqlDelete;
                //}                
                //Ent[i, nUpdate] = sqlUpdateAll;
                //E//nt[i, nInsert] = sqlInsertAll;
                //E
                
                //Update
                // string[,] arr = sys.SortTwoDimensionalArray(Ref, "", 0, RefCount, "Column10='" + EntityBrief + "'", "Column27 DESC");
               				
				/*var dt = new DataTable();
	        	sys.ArrayToDataTable(Ref, "", out dt, 0, 0, false);         	        	        
	        	DataRow[] sortedrows = dt.Select("Column10='" + EntityBrief + "'", "Column27 DESC");
	        	DataTable dt1 = sortedrows.CopyToDataTable();	              	
	        	//string[,] res;
	        	//sys.DataTableToArray(dt1, out res);
 				var view = new DataView(dt1);
				DataTable distinctValues = view.ToTable(true, "Column10", "Column2" ...);
				
                //string SQL = "";
                //int CountAttrDirty = 0;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (Ref[j, iQueryName]   != QueryName)      continue;
                    if (Ref[j, iEntityBrief] != EntityBrief)    continue;
                    if (Ref[j, iNeedSave] != "1") 				continue;
                    
                    string Value = Ref[j, iValueSave];
                    

                    System.Data.DataTable dt;
                    //sys.ArrayToDataTable(Ref, "", out dt, int beginColumnIndex, int beginRowIndex, int countColumns, int CountRows, bool ShowNum)
                    	
                    //GetInsertID()*/
               // }
        
        /*string SQL =         
        "SELECT AttrID, AttrName, EntityBrief, EntityID, TableName, TableType, IDO, FieldName " + Var.CR +
		" FROM " + Var.CR +
		" ("  + Var.CR +
		" SELECT" + Var.CR +
		"  Distinct " + Var.CR +
		"  EOT_1.ID          'AttrID',    " + Var.CR +
		"  EOT_1.Brief       'AttrName',  " + Var.CR +
		"  EOT_4.Brief       'EntityBrief', " + Var.CR +
		"  EOT_4.ID          'EntityID',  " + Var.CR +
		"  EOT_5.Name        'TableName', " + Var.CR +
		"  EOT_5.Type        'TableType', " + Var.CR +
		"  EOT_5.IDFieldName 'IDO',       " + Var.CR +
		"  EOT_1.FieldName   'FieldName'  " + Var.CR +
		" FROM                            " + Var.CR +
		"  fbaAttribute EOT_1 " + Var.CR +
		"  Left Outer Join fbaTable EOT_5 " + Var.CR +
		"    On EOT_5.ID = EOT_1.TableID " + Var.CR +
		"  Left Outer Join fbaEntity EOT_4 " + Var.CR +
		"    On EOT_4.ID = EOT_1.AttributeEntityID " + Var.CR +
		" WHERE " + Var.CR +
		"  EOT_4.Brief = '@EnName' " + Var.CR +
		"  and EOT_1.Brief = '@attrlist' " + Var.CR +
        " and EOT_1.Type IN (1 , 2) " + Var.CR +
		" Union  " + Var.CR +
		" SELECT " + Var.CR +
		"  Distinct " + Var.CR +
		"  EOT_8.ID           'AttrID', " + Var.CR +
		"  EOT_8.Brief        'AttrName' " + Var.CR +
		"  EOT_9.Brief        'EntityBrief', " + Var.CR +
		"  EOT_9.ID           'EntityID', " + Var.CR +
		"  EOT_10.Name        'TableName', " + Var.CR +
		"  EOT_10.Type        'TableType', " + Var.CR +
		"  EOT_10.IDFieldName 'IDO', " + Var.CR +
		"  EOT_8.FieldName    'FieldName' " + Var.CR +
		" FROM " + Var.CR +
		"  fbaAttribute EOT_2 " + Var.CR +
		"  Left Outer Join fbaEntity EOT_6 " + Var.CR +
		"    On EOT_6.ID = EOT_2.AttributeEntityID " + Var.CR +
		"  Left Outer Join fbaEntity EOT_7 " + Var.CR +
		"    On EOT_7.ID = EOT_6.ParentID " + Var.CR +
		"  Left Outer Join fbaAttribute EOT_8 " + Var.CR +
		"    On EOT_8.AttributeEntityID = EOT_7.ID " + Var.CR +
		"  Left Outer Join fbaTable EOT_10 " + Var.CR +
		"    On EOT_10.ID = EOT_8.TableID " + Var.CR +
		"  Left Outer Join fbaEntity EOT_9 " + Var.CR +
		"    On EOT_9.ID = EOT_8.AttributeEntityID " + Var.CR +
		" WHERE " + Var.CR +
		"  EOT_6.Brief = '@EnName'  " + Var.CR +
		"  and EOT_7.ID is not null and EOT_8.Brief IN ('@brieflist')  " + Var.CR +
        " and EOT_8.Type IN (1 , 2)  " + Var.CR +
		" Union " + Var.CR +
		" SELECT " + Var.CR +
		"  Distinct " + Var.CR +
		"  EOT_14.ID          'AttrID', " + Var.CR +
		"  EOT_14.Brief       'AttrName', " + Var.CR +
		"  EOT_15.Brief       'EntityBrief', " + Var.CR +
		"  EOT_15.ID          'EntityID', " + Var.CR +
		"  EOT_16.Name        'TableName', " + Var.CR +
		"  EOT_16.Type        'TableType', " + Var.CR +
		"  EOT_16.IDFieldName 'IDO', " + Var.CR +
		"  EOT_14.FieldName   'FieldName' " + Var.CR +
		" FROM " + Var.CR +
		"  fbaAttribute EOT_3 " + Var.CR +
		"  Left Outer Join fbaEntity EOT_11 " + Var.CR +
		"    On EOT_11.ID = EOT_3.AttributeEntityID " + Var.CR +
		"  Left Outer Join fbaEntity EOT_12 " + Var.CR +
		"    On EOT_12.ID = EOT_11.ParentID " + Var.CR +
		"  Left Outer Join fbaEntity EOT_13 " + Var.CR +
		"    On EOT_13.ID = EOT_12.ParentID " + Var.CR +
		"  Left Outer Join fbaAttribute EOT_14 " + Var.CR +
		"    On EOT_14.AttributeEntityID = EOT_13.ID " + Var.CR +
		"  Left Outer Join fbaTable EOT_16 " + Var.CR +
		"    On EOT_16.ID = EOT_14.TableID " + Var.CR +
		"  Left Outer Join fbaEntity EOT_15 " + Var.CR +
		"    On EOT_15.ID = EOT_14.AttributeEntityID " + Var.CR +
		" WHERE " + Var.CR +
		"  EOT_11.Brief = '@brief' " + Var.CR +
		"    and EOT_13.ID is not null and EOT_14.Brief IN ('@brieflist') and EOT_14.Type IN (1 , 2)  " + Var.CR +
        	" ) t1 ";
        
        */
       
       
       
        //columnsNumber - пример: 1,6,7
        /*public string[,] SortArrayTwoDimensions(string[,] arr, string columnsNumber, string AscOrDesc)
        {
        	DataTable dt = new DataTable();
        	sys.ArrayToDataTable(arr, "", out dt, 0, 0, false);
        	string conditions = columnsNumber + " " + AscOrDesc;
        	DataRow[] sortedrows = dt.Select("", conditions);
        	DataTable dt1 = sortedrows.CopyToDataTable();	
        	string[,] res;
        	sys.DataTableToArray(dt1, out res);
        	return res;
        }
         
    //=============================Мусор
                    //SByte a;
					//unchecked { a = (SByte)255; };
					//uint dsd = 345345;
					//unsigned char unsigned_value = 0xff; /* Значение в десятичной системе 255 */
					//char signed_value = 0xff; /* значение в десятичной системе -1 */
					//Console.WriteLine($"max: {max}; min: {min}; maxI: {maxI}; maxJ: {maxJ}; minI: {minI}; minJ: {minJ}");
                    
					
					//Array.Sort(Ref);
                    //TableAll = TableAll + ";" + Ref[i, iTableName] + ";";   


					//var a = new Int32[4][];
	 
		            //var random = new Random();
		            //for (int im = 0; im < a.Length; i++)
		            //{
		                //a[im] = new Int32[5];
		                //for (var jm = 0; jm < a[im].Length; jm++)
		               // {
		                    //a[im][jm] = random.Next(100);
		                //}
		            //}
		            //Print(a);
		 
		            //GetStatistic(a);
		 
		            /*Console.WriteLine("---");
		            //сортируем
		            //foreach (string[] t in Ref)
		            //    Array.Sort(t, (  (im, i1) => i1.CompareTo(i)  )    );
		            //Print(a);
		            //GetStatistic(a);
		            Console.Read();
            
		          
		            
		            var list = new List<string>
		            {
		                "43, Nikolay",
		                "31, Roman",
		                "42, Ivan",
		                "21, Petr"
		            };
		            
		           //list.O
		           
		            foreach (var i1 in list.OrderBy(p=>Convert.ToInt32(new string(p.TakeWhile(System.Char.IsDigit).ToArray()))))
		            {
		                Console.WriteLine(i1);
		            }
            
		            
		            
		            
		            
		            int[] numbers = { 3, 12, 4, 10, 34, 20, 55, -66, 77, 88, 4 };
					var orderedNumbers = from i11 in numbers
					                     orderby i11
					                     select i11;
					*/
					//orderedNumbers[1] = 66;
					//foreach (int i11 in orderedNumbers)
					 //   Console.WriteLine(i11);
		            
		            
		            //var result = list.OrderBy (n => n.Name). ToArray ();
		            
					//string[,] t = new string[5,8];
		            
					
		            /*List<User> users = new List<User>()
					{
					    new User { Name = "Tom", Age = 33 },
					    new User { Name = "Bob", Age = 30 },
					    new User { Name = "Tom", Age = 21 },
					    new User { Name = "Sam", Age = 43 }
					};
					var result = from user in users
					             orderby user.Name, user.Age
					             select user;
					foreach (User u in result)
					    Console.WriteLine("{0} - {1}", u.Name, u.Age);
							            
		            //var myArray = new[] { "abc", "123", "zyx" };
    				//List<string> myList = myArray.ToList();
		            */
    				
		            //var myArray = new[] { "abc", "123", "zyx" };
    				//List<string, string> myList = Ref.ToList();    				
    				
    				
					//=============================Мусор

					// assumes stringdata[row, col] is your 2D string array
					/*DataTable dt = new DataTable();
					// assumes first row contains column names:
					for (int col = 0; col < Ref.GetLength(1); col++)
					{
					    dt.Columns.Add(Ref[0, col]);
					}
					// load data from string array to data table:
					for (int rowindex = 1; rowindex < Ref.GetLength(0); rowindex++)
					{
					    DataRow row = dt.NewRow();
					    for (int col = 0; col < Ref.GetLength(1); col++)
					    {
					        row[col] = Ref[rowindex, col];
					    }
					    dt.Rows.Add(row);
					}
					// sort by third column:
					DataRow[] sortedrows;// = dt.Select("", "3");
					// sort by column name, descending:
					sortedrows = dt.Select("", "COLUMN3 DESC");
					
					foreach (DataRow row in sortedrows) {
					   dt.ImportRow(row);
					}
					
					DataTable dt = new DataTable();
					DataRow[] dr = dt.Select("Your string");
					DataTable dt1 = dr.CopyToDataTable();					
					
					
					       
         
         
         */
         //Получение списка таблиц.
        /*private void GetListTables()
        {
        	
        }
                
        //Цикл по таблицам с учетом iNumLevel. Этот метод возврвщает собирает запросы по определённому уровню вложенности. 
 		private void GetQuery_UPDATE_INSERT_SaveObject1(string queryName, string numLevel, out string sqlUpdateAll, out string sqlInsertAll, out string sqlDeleteAll)
        {   			 			 		         	
 			 			
           int TblCount = 0; //Максимальное количество таблиц, которые участвуют в запросах UPDATE и INSERT - 100.    
           var Tbl = new string[100,  tNumLevel  + 1]; //Массив таблиц, которые используются в запросах UPDATE и INSERT.
        
 			//Получение списка таблиц.
      
        	string tableNameOld = "";
        	TblCount = 0;
 			for (int i = 0; i < RefCount; i++)
            {                                                                                               
 				if (Ref[i, iQueryName] != queryName) continue;
        		if (Ref[i, iNumLevel]  != numLevel) continue;
        		 				
                if (Ref[i, iTableName] != tableNameOld)
                {             
                	Tbl[TblCount, tPos]         = TblCount.ToString();
                	Tbl[TblCount, tEnt]         = Ref[i, iEnt]; 		//Ссылка на таблицу Ent.
                    Tbl[TblCount, tRef]         = Ref[i, iPos]; 		//Ссылка на таблицу Ref.
                    Tbl[TblCount, tQueryName]   = Ref[i, iQueryName];
                    Tbl[TblCount, tEntityBrief] = Ref[i, iEntityBrief];
                    Tbl[TblCount, tEntityID]    = Ref[i, iEntityID];
                    Tbl[TblCount, tTableName]   = Ref[i, iTableName];   //Имя таблицы, которая используется в запросах UPDATE и INSERT.
                    Tbl[TblCount, tTableType]   = Ref[i, iTableType];   //Тип таблицы, которая используется в запросах UPDATE и INSERT.
                    Tbl[TblCount, tIDFieldName] = Ref[i, iIDFieldName]; //Ключевое поле таблицы, которая используется в запросах UPDATE и INSERT.
                    Tbl[TblCount, tObjectID]    = Ref[i, iObjectID];    //ИД объекта сущности.
                    Tbl[TblCount, tStateDate]   = Ref[i, iStateDate];   //Историчная дата.
                    Tbl[TblCount, tNumLevel]    = Ref[i, iNumLevel];
                    TblCount++;
                	tableNameOld = Ref[i, iTableName];
                }
 			}
 			
 			sys.ArrayView("Tbl",
		        "0.tPos;1.tEnt;2.tRef;3.tQueryName;4.tEntityBrief;5.tEntityID;6.tTableName;" + 
		        "7.tTableType;8.tIDFieldName;9.tTableParent;10.tObjectID;11.tStateDate;12.tUpdate;13.tInsert;14.tDelete", Tbl);      
 			
 			sqlUpdateAll = "";
 			sqlInsertAll = ""; 
 			sqlDeleteAll = "";
 			for (int i = 0; i < TblCount; i++)
            {
        		//if (Tbl[TblCount, tQueryName] != queryName) continue;
        		//if (Tbl[TblCount, tNumLevel]  != numLevel) continue;
        		
        		string tableName   = Tbl[i, tTableName]; 
        		string tableType   = Tbl[i, tTableType];
				string IDFieldName = Tbl[i, tIDFieldName];
				string entityBrief = Tbl[i, tEntityBrief]; 				
				string objectID    = Tbl[i, tObjectID];
				string stateDate   = Tbl[i, tStateDate]; 
				string sqlUpdate   = "";
	 			string sqlInsert   = "";
	            string sqlDelete   = "";
				GetQuery_UPDATE_INSERT_SaveObject2
	 				 (queryName,		
		         	 entityBrief, 
				     tableName, 
					 tableType,				     
				     objectID,
				     IDFieldName,
				     stateDate,													   
		             numLevel, 
		             out sqlUpdate, 
		             out sqlInsert,
		             out sqlDelete);
				 sqlUpdateAll = sqlUpdateAll + Var.CR + sqlUpdate; 
                 sqlInsertAll = sqlInsertAll + Var.CR + sqlInsert;
                 sqlDeleteAll = sqlDeleteAll + Var.CR + sqlDeleteAll;				
        	}
       }*/
        
        
		#endregion Region. Save_Object.  
#region Region. Сборка запросов. Entity - UPDATE_INSERT_DELETE.
#endregion Region. Сборка запросов. Entity - UPDATE_INSERT_DELETE.
		
        //Проверка на дубль атрибута. Если такой уже есть, чтобы не вставлять два раза один и 
        /*private void CheckDoubleAttr(string QueryName)
        {
            //ShowArray("Ref");
            for (int i = 0; i < EntCount; i++)
            {
                string EntityBrief = Ent[i, nEntityBrief];
                for (int j = 0; j < RefCount; j++)
                {
                    if (Ref[j, iQueryName] != QueryName) continue;
                    if (Ref[j, iEntityBrief] != EntityBrief) continue;
                    string Attr = Ref[j, iAttr];
                    for (int j1 = 0; j1 < j; j1++)
                    {
                        if (Ref[j1, iQueryName] != QueryName) continue;
                        if (Ref[j1, iEntityBrief] != EntityBrief) continue;
                        if (Ref[j1, iAttr] == Attr) Ref[j1, iNeedSave] = "0";
                    }
                }
            }
        }*/
        //{
            //	SetDirty(QueryName, true);
            //for (int i = 0; i < RefCount; i++)
            //{
            // 	if ((QueryName != "") && (Ref[i, iQueryName] != QueryName)) continue;
            // 	Ref[i, iStateDate] = stateDate;  
			//	findRef = true;            	
			//}
            //if ((findEnt) && (findRef))
            //{
            //	SetDirty(QueryName, true);
            //	return true;
            //}                 		
//=================================================================	


/*
        
             
        //Получаем значения компонентов формы (или другого компонента-контейнера Panel, TabControl) в виде строки.
        public static bool ReadArrayHist(Form form)
        {                              
            string FormName = form.Name;           
            string SQL = string.Format("SELECT t1.CompName, t1.Value, t1.DataValue, t2.CNT " + Var.CR +
                "FROM fbaValueHist t1  " + Var.CR +
                "LEFT JOIN             " + Var.CR +
                "(SELECT CompName, Count(Value) AS CNT FROM fbaValueHist       " + Var.CR +
                "  WHERE FormName = '{0}' AND UserID = '{1}' GROUP BY CompName " + Var.CR +
                ") t2 ON t1.CompName = t2.CompName                             " + Var.CR +
                "WHERE t1.FormName = '{0}' AND t1.UserID = '{1}'               " + Var.CR +
                "ORDER BY t1.CompName, t1.DataValue DESC                       " + Var.CR, FormName, Var.UserID );            
            //string SQL = string.Format("SELECT CompName, Value, DataValue FROM fbaValueHist WHERE FormName = '{0}' AND UserID = {1} ORDER BY CompName, DataValue DESC ", FormName, Var.UserID );
            System.Data.DataTable DT;
            if (!sys.SelectDT(DirectionQuery.Local, SQL, out DT)) return false;
            string CompNameCurrent = "";
            string[] Arr = null;
            int IndexRow = 0;                     
            for (int i = 0; i < DT.Rows.Count; i++)
            {              
                string CompName  = sys.DTValue(DT, i, "CompName");
                string Value     = sys.DTValue(DT, i, "Value");
                string DataValue = sys.DTValue(DT, i, "DataValue");
                string CNT       = sys.DTValue(DT, i, "CNT");
            
                if (CompNameCurrent != CompName) 
                {
                    if (CompNameCurrent != "")
                    {
                        if (!ReadArrayHistData(form, CompNameCurrent, Arr)) continue;                        
                    }
                      
                    Arr = new string[CNT.ToInt()];
                    CompNameCurrent = CompName;
                    IndexRow = 0;                   
                }
                
                if (Arr == null) continue;
                Arr[IndexRow] = Value;
                IndexRow++;
                
                if (i == (DT.Rows.Count - 1))
                {
                    if (!ReadArrayHistData(form, CompNameCurrent, Arr)) continue;                                                                                    
                }                                            
            }   
            return true;
        }              
        
        //Присваиваем значение массива компоненту. Если это ComboBox, то и свойству Items.
        //Метод только для ReadArrayHist.
        private static bool ReadArrayHistData(Form form, string CompName, string[] Arr)
        {
            Control cn = form.Controls.Find(CompName, true).FirstOrDefault();
            if (cn == null) return false;                     
            string CompType = cn.GetType().ToString();
            CompType = sys.TruncateType(CompType, 0);
            if (CompType == "TextBoxFBA")  ((TextBoxFBA)cn).ValueArray = Arr;
            if (CompType == "ComboBoxFBA") 
            {
                ((ComboBoxFBA)cn).ValueArray = Arr;
                //Если свойство ValueHistoryInItems = true, 
                //которое указывает на то, что всю историю значений нужно запихать в Items, то запихиваем
                if (((ComboBoxFBA)cn).ValueHistoryInItems) 
                {
                    ((ComboBoxFBA)cn).Items.Clear();
                    for (int N = 0; N < Arr.Length; N++)
                        ((ComboBoxFBA)cn).Items.Add(Arr[N]);                                                                  
                }
            } 
            return true;
        }
        
        //Получаем значения компонентов формы (или другого компонента-контейнера Panel, TabControl) в виде строки.
        public static bool WriteArrayHist(Form form)
        {
            string SQl = "INSERT INTO fbaValueHist (EntityID, UserID, FormName, CompName, Value, DataValue) " + Var.CR +                             
                         WriteArrayHistData(form.Name, form.Controls);
            SQl = SQl.Substring(0, SQl.Length - 12) + ";";
            return sys.Exec(DirectionQuery.Local, SQl);
        }
        
        //Получаем значения компонентов формы (или другого компонента-контейнера Panel, TabControl) в виде строки.
        //Метод только для WriteArrayHist.
        private static string WriteArrayHistData(string FormName, Control.ControlCollection controls)
        {                             
            if (controls.Count == 0) return ""; 
            string  SQL = "";
             
            foreach(Control control in controls)
            {                      
                SQL = SQL + WriteArrayHistData(FormName, control.Controls);                            
                if (control.Tag != null)
                {                                                                           
                    string CompType = control.GetType().ToString();
                    string CompName = control.Name;
                    CompType = sys.TruncateType(CompType, 0);
                    string Value = "";
                    string[] Arr;
                    if (CompType == "TextBoxFBA")   
                    {
                        Arr   = ((TextBoxFBA)control).ValueArray;
                        Value = ((TextBoxFBA)control).Text;
                    }
                    else if (CompType == "ComboBoxFBA")
                    {
                        Arr = ((ComboBoxFBA)control).ValueArray;
                        Value = ((ComboBoxFBA)control).Text;
                    } else continue;
                     
                    if (Arr != null)
                    if (Array.IndexOf(Arr, Value) > -1) continue;
                    if (Value.Length > 250) continue;
                    if (Value == "") continue;
                    SQL = SQL + string .Format("SELECT 4, {0},'{1}','{2}','{3}',{4}",  
                                          Var.UserID , FormName, CompName, Value, sys.DateTimeCurrent("SQLite"))
                                          + " UNION ALL" + Var.CR;
                    
                }               
            }
            return SQL;            
        }
        
       
        */
 // <summary>
        // Запись глобального значения из таблицы настроек fbaParam.  
        // </summary>
        // <param name="Direction">Remote или Local</param>
        // <param name="ParamName">Имя параметра</param>
        // <param name="ParamValue1">Параметр. Значение 1</param>
        //<param name="ParamValue2">Параметр. Значение 2</param>
        // <param name="ParamValue3">Параметр. Значение 3</param>
        // <param name="Comment">Произвольный комментарий</param>
        // <returns></returns>
        //public static bool ParamSaveGlobal(string Direction, string ParamName, string[] ParamValue, string Comment)
        //{
        //  bool Global      = true;
        //  string ParamType = "User";
        //  string FormName  = "";
        //  string[] ParamValue = new string[3];
        //  ParamValue[0] = ParamValue1;
        //  ParamValue[1] = ParamValue2;
        //  ParamValue[2] = ParamValue3;
        //  return sys.ParamSave(Direction, Var.UserID , ParamName, true, ParamValue, "User", "", Comment);
        //}

        // <summary>
        // Запись пользовательского значения из таблицы настроек fbaParam.  
        // </summary>
        // <param name="Direction">Remote или Local</param>
        // <param name="ParamName">Имя параметра</param>
        // <param name="ParamValue1">Параметр. Значение 1</param>
        // <param name="ParamValue2">Параметр. Значение 2</param>
        // <param name="ParamValue3">Параметр. Значение 3</param>
        // <param name="Comment">Произвольный комментарий</param>
        // <returns></returns>
        //public static bool ParamSaveUser(string Direction, string ParamName, string ParamValue1, string ParamValue2, string ParamValue3, string Comment)
        //{
        //    bool Global      = false;
        //    string ParamType = "User";
        //    string FormName  = "";
        //    return sys.ParamSave(Direction, Var.UserID , ParamName,  Global, ParamValue1, ParamValue2, ParamValue3, ParamType, FormName, Comment);
        //}

        // <summary>
        // Чтение глобального значения из таблицы настроек fbaParam.  
        // </summary>
        // <param name="Direction">Remote или Local</param>
        // <param name="ParamName">Имя параметра</param>
        // <param name="ParamValue1">Параметр. Значение 1</param>
        // <param name="ParamValue2">Параметр. Значение 2</param>
        // <param name="ParamValue3">Параметр. Значение 3</param>
        // <returns></returns>
        //public static bool ParamLoadGlobal(string Direction, string ParamName, out string ParamValue1, out string ParamValue2, out string ParamValue3)
        //{                             
        //     bool Global      = true; 
        //     string ParamType = "User";             
        //     ParamValue1      = "";
        //     ParamValue2      = "";
        //     ParamValue3      = "";
        //     return sys.ParamLoad(Direction, Var.UserID , ParamName, Global, ParamType, out ParamValue1, out ParamValue2, out ParamValue3);
        //}

        // <summary>
        // Чтение пользовательского значения из таблицы настроек fbaParam. Можно записывать три значения за раз. 
        // Все три значения считаются одном параметром.  
        // </summary>
        // <param name="Direction">Remote или Local</param>
        // <param name="ParamName">Имя параметра</param>
        // <param name="ParamValue1">Параметр. Значение 1</param>
        // <param name="ParamValue2">Параметр. Значение 2</param>
        // <param name="ParamValue3">Параметр. Значение 3</param>
        // <returns></returns>
        //public static bool ParamLoadUser(string Direction, string ParamName, out string ParamValue1, out string ParamValue2, out string ParamValue3)
        //{                             
        //    bool Global      = false;          
        //    string ParamType = "User";
        //    ParamValue1 = "";
        //    ParamValue2 = "";
        //    ParamValue3 = "";
        //    return sys.ParamLoad(Direction, Var.UserID , ParamName, Global, ParamType, out ParamValue1, out ParamValue2, out ParamValue3);
        //}
        
          
        //Чтение значений компонентов из fbaParam.
        //public static bool FormComponentValuesLoad(string Direction, Form form)
        //{                                    
        //    string ParamName       = form.Name;                                         
        //    string ParamValue1     = "";
        //    string ParamValue2 = "";
        //    string ParamValue3 = "";
        //    const string ParamType = "Form"; 
        //    const bool Global      = false;              
        //    if (!sys.ParamLoad(Direction, Var.UserID , ParamName, Global, ParamType, out ParamValue1, out ParamValue2, out ParamValue3)) return false;                                       
        //    SetComponentValues(ParamValue1, form.Controls);
        //    return true;                                     
        //}
        
        
//=================================================================	

        //Получить сущность по QueryName.
       // private void GetEntityBriefAndObjectID(string QueryName, out string EntityBrief, out string EntityID, out string ObjectID, out int IndexEnt)
       // {			       
        
       // }
        
	//Определить, какая все таки команда, если она не указана.        
        //private SQLCommand GetTypeCommand(string QueryName)
        //{
        //	string objectID = GetObjectID(QueryName);
        //	if ((objectID == "") || (objectID == "0")) return SQLCommand.Insert;
        //	return SQLCommand.Update;
        //}
        
	//Показ массива Tbl.
            //if (ArrayName == "Ref")
           // {                                                                                                           
            //    sys.ArrayView(ArrayName,
            //        "0.tPos;1.tEnt;2.tRef;3.tQueryName;4.tEntityBrief;5.tEntityID;6.tTableName;" + 
            //        "7.tTableType;8.tIDFieldName;9.tObjectID;10.tStateDate;11.tNumLevel;", Tbl);   //tUpdate;13.tInsert;14.tDelete", Tbl);                              
            //}  
            
            
//=================================================================	
   //int FormLinesCount = 0;
            //int TextLinesCount = 0;
            //string FormCode1;
            //string TextCode1;
            //if (!sys.FileReadText(FormCodePath, true, out FormCode1, out FormLinesCount)) return false;
            //if (!sys.FileReadText(TextCodePath, true, out TextCode1, out TextLinesCount)) return false;
            //string FormCode2  = FormCode1.Replace("'",  "''");            
            //string TextCode2  = TextCode1.Replace("'",  "''");        
//=================================================================	
  /*private static int CountNumberOfLinesInCSFilesOfDirectory(string dirPath)
        {
            FileInfo[] csFiles = new DirectoryInfo(dirPath.Trim())
                                        .GetFiles("*.cs", SearchOption.AllDirectories);
        
            int totalNumberOfLines = 0;
            Parallel.ForEach(csFiles, fo =>
            {
                Interlocked.Add(ref totalNumberOfLines, CountNumberOfLine(fo));
            });
            return totalNumberOfLines;
        }
        
        private static int CountNumberOfLine(Object tc)
        {
            FileInfo fo = (FileInfo)tc;
            int count = 0;
            int inComment = 0;
            using (StreamReader sr = fo.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (IsRealCode(line.Trim(), ref inComment))
                        count++;
                }
            }
            return count;
        }*/                
        
        //public static string GetNewName(string TemplateName)
        //{
            
        //}
        
        //Запрос ввода настройки гибкой таблицы. Пример вызова: string str = ""; if (!sys.InputFlex("List", "Input", ref str)) return;
        //public static bool InputFlex(string EntityBrief, 
        //                              ref string FlexName)
        //{
           // var frm = new FormFlexList(EntityBrief);           
            //if (frm.ShowDialog() != DialogResult.OK) return false;
            //FlexName = frm.FlexName;
            //return true;
        //}
        
             //unsafe void NormalizeString(string str)
        //{
        //    fixed (char* pBase = str)
        //   {
        //       char prev = '\0';
        //       for (char* ptr = pBase; ptr < pBase + str.Length; prev = *ptr++)
        //           if (char.IsLetter(*ptr))
        //               *ptr = char.IsLetter(prev) ? char.ToLower(*ptr) : char.ToUpper(*ptr);
        //   }
        //} 
        
        
                //private static void button1_Click(object sender, EventArgs e)
        //{            
        //    folderBrowserDialog.ShowDialog();
        //    Text = FolderPath = folderBrowserDialog.SelectedPath;
        //}
        /*private static void button2_Click(object sender, EventArgs e)
        {
            FileCount = 0;
            StringCount = 0;
            textBox3.Text = "";
            if(textBox1.Text == String.Empty) textBox1.Text="*.*";
            try
            {
                GetFilesInfo(FolderPath);
                textBox3.Text += "\r\nВсего файлов: " + FileCount.ToString();
                textBox3.Text += "\r\nВсего строк: " + StringCount.ToString();
            }
            catch(Exception ex)
            {
                textBox3.Text = "Ошибка: "+ex.Message;
            }
        }*/
//=================================================================	
        
        // <summary>
        // Копируем проект в БД.
        // Архивируется папка проекта в ZIP и записывается в БД в виде Base64.
        // </summary>
        // <param name="projectName">Имя проекта - это имя папки с проектом, но без пути</param>
        // <returns>Если успешно, то true</returns>
        /*public static bool ProjectWriteToDataBase(string projectName)
        {
            //Проект архивируется в файл ZIP. Далее файл ZIP записывается в БД в виде Base64.
            string projectPath = sys.PathForms + projectName;
            string fileName = sys.PathTemp + projectName + ".zip";
            if (!sys.DirZIP(true, projectPath, fileName)) return false;
            const bool saveHashToEndFile = false;
            string fileData;
            string hashMD5;
            if (!sys.FileGetBase64WithHashMD5(fileName, saveHashToEndFile, out fileData, out hashMD5)) return false;
            string sql = "UPDATE fbaProject SET ProjectZip = '" + fileData + "' WHERE Name = '" + projectName + "'";
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            return true;
        }*/  
//=================================================================	

        //Получить текст *.cs модуля формы.
        /*public static bool GetProjectCode(string projectID, string projectHistID, string Mode, out string projectName, out string CodeText)
        {
            projectName = "";
            CodeText = "";
            string SQL = "";
            if ((projectID == "") && (projectHistID == "")) return false;
            if (projectID != "")
            {
                string FieldCodeText = "TextCodeTest";
                if (Mode == "Work") FieldCodeText = "TextCode";
                SQL = "SELECT Name, " + FieldCodeText + " FROM fbaProject WHERE ID = " + projectID;

            }
            if (projectHistID != "")
            {
                SQL = "SELECT Name, TextCode FROM fbaProjectHist WHERE ID = " + projectHistID;
            }
            if (!sys.GetValue(DirectionQuery.Remote, SQL, out projectName, out CodeText)) return false;
            //System.Data.DataTable DT;
            //sys.SelectDT(DirectionQuery.Local, SQL, out DT);
            //if (DT.Rows.Count == 0) return false;                             
            //CodeText = sys.DTValue(DT, FieldCodeText);
            return true;
        }*/          
//=================================================================
   
        //Хм... благодаря этому коду форма при измениии размеров перерисовывается значительно быстрее. Взято отсюда:
		//Обновлено. Приводит к артефактам при перемещении формы!!!        
        //https://social.msdn.microsoft.com/Forums/windows/en-US/c27693d2-9b4e-4395-9e90-402a6af96307/splitcontainer-flickering-issue-while-resizing-it?forum=winforms
        //protected override CreateParams CreateParams       
        //{       
        //    get           
        //    {       
        //        CreateParams cp = base.CreateParams;           
        //        cp.ExStyle |= 0x02000000;           
        //        return cp;       
        //    }       
        //}
//=================================================================
// <summary>
		// /Удаление файлов кэша
		// </summary>
		// <param name="dirName">Папка с файлами модулей</param>
		// <returns></returns>
		 //string NotDeletedFiles = "";
		    //NotDeletedFiles = DirClean(string dirName, out string errorMes, bool showMes);    //DeleteCash(sys.PathMain);
			//if (NotDeletedFiles != "") sys.SM("Не удаленные файлы: " + Var.CR + NotDeletedFiles);
			//else sys.SM("Все файлы кэша успешно удалены!");
		/*private string DeleteCash(string dirName)
		{
			var dirInfo = new DirectoryInfo(dirName);
            bool needDelete = false;
            string notDeletedFiles = "";                                  
            foreach (FileInfo file in dirInfo.GetFiles())  
            {                                 
                needDelete = false;
                if (file.Name.IndexOf("Form", StringComparison.OrdinalIgnoreCase) == 0) needDelete = true;                             
                if (needDelete)
                {   try
                    {
                        file.Delete();
                    }
                    catch 
                    {
                        notDeletedFiles += file.Name + Var.CR;
                    }                     
                }            
            }
            return notDeletedFiles;
		}*/
//=================================================================	
      //Копирование выделенной области из FBA.GridFBA в DataTable.
        /*public static System.Data.DataTable SelectedRowsToDataTable(FBA.GridFBA sourceGrid, bool insertFirstColumn)
        {
            System.Data.DataTable DT = ((DevAge.ComponentModel.BoundDataView)sourceGrid.DataSource).DataTable;                        
            if (DT == null) return null;
            System.Data.DataTable DTClone;
            DTClone = DT.Clone();
            int[] rows = sourceGrid.Selection.GetSelectionRegion().GetRowsIndex();
            
            //Копирование выделенных строк в другой DataTable.
            for (int iRow = 0; iRow < rows.Length; iRow++)
            {
                System.Data.DataRow row;
                int N = rows[iRow] - 1;
                if ((N > -1) && (N < DT.Rows.Count))
                {
                    row = DT.Rows[rows[iRow] - 1];
                    DTClone.ImportRow(row);
                }
            }

            int FirstColumn;
            if (insertFirstColumn) FirstColumn = 0; else FirstColumn = -1;
            for (int iCol = DT.Columns.Count - 1; iCol > FirstColumn; iCol--)
            {
                SourceGrid.Position posCell = new SourceGrid.Position(rows[0], iCol);
                if (!sourceGrid.Selection.IsSelectedCell(posCell))
                {
                    DTClone.Columns.RemoveAt(iCol);
                }
            }
            return DTClone;
        }*/
        
//=================================================================	

        //Заменяем кавычки на двойные для того чтобы сохранить содержимое Array 
        //SQL запросом в базе данных.
        //public static void ArrayReplaceQuote(ref string[,] Arr)
        //{                          
        //    int RowCount = Arr.GetLength(0);
        //     int ColCount = Arr.GetLength(1);
        //    for (int i = 0; i < RowCount; i++)
        //         for (int j = 0; j < ColCount; j++)
        //             if (Arr[i,j] != null)
        //                 Arr[i,j] = Arr[i,j].QueryQuote();
        //}
//=================================================================	
  //Следующие методы (ArrayToStr1 и ArrayFromStr1) преобразуют масссив в /из строки такого формата: 2-3:|1;1;Сущность|2;1;ТаблицаСущности 
        //2-3 -Это размер таблицы строк-колонок, в данном случае 2 строки, 3 колонки.
        //1;1;Сущность -Это первая строка, и три значения: 1,1,Сущность.
        //1;ТаблицаСущности -Это сторая строка таблицы.
        //Т.е. строки отделяются друг от друга символом "|", а ячейки внутри строки точкой с запятой. 
        //Двоеточние используется чтобы отделить цифры о размере таблицы с знначениями самой таблицы.         
        //Не используются сейчас.
        //двумерный массив преобразовать в строку.
        /*public static string ArrayToStr1(this string[,] arr)
        {                                                                                                                       
            int MaxY = arr.GetLength(0);
            int MaxX = arr.GetLength(1);           
            string ArrStr = MaxY + "-" + MaxX + ":";
            for (int i = 0; i < MaxY; i++)
            {
                string LineStr = "";
                for (int j = 0; j < MaxX; j++)
                {
                    string Value = arr[i, j];//.ToBase64();
                    if (LineStr != "") LineStr = LineStr + ";";
                    LineStr = LineStr + Value;                  
                }
                if (ArrStr != "") ArrStr = ArrStr + "|";
                ArrStr = ArrStr + LineStr;                
            }
            return ArrStr;       
        }*/
        //Строку преобразовать в двумерный массив.
        /*public static string[,] ArrayFromStr1(this string InputStr)
        {                                                    
            //Определяем размер массива.
            string[] ArrData = InputStr.Split(':');
            if (ArrData.Count() < 2) return null;
            string[] ArrDim = ArrData[0].Split('-');
            var arr = new string[ArrDim[0].ToInt(), ArrDim[1].ToInt()];                                        
            string[] ArrLine = ArrData[1].Split('|');
            for (int i = 1; i < ArrLine.Length; i++) //Первая строка пустая в массиве.
            {
                string LineStr = ArrLine[i];
                string[] ArrValue = LineStr.Split(';'); //1;1;Сущность
                for (int j = 0; j < ArrValue.Length; j++)
                {
                    arr[i-1,j] = ArrValue[j];//.FromBase64();
                }                
            }
            return arr;
        }*/

        //Разбить строку Values на массив. Формат строки Values:
        //value1;value2;value3...
        //value2;value5;value5...
        /*public static string ArrayToStr2(this string[,] arr)
        {                                                                                                                       
            int MaxY = arr.GetLength(0);
            int MaxX = arr.GetLength(1);  
            var ArrStr = new StringBuilder();                        
            for (int i = 0; i < MaxY; i++)
            {
                string LineStr = "";
                for (int j = 0; j < MaxX; j++)
                {
                    string Value = arr[i, j];//.ToBase64();
                    if (LineStr != "") LineStr = LineStr + ";" + Value;  
                    else LineStr = Value;                  
                }           
                ArrStr.Append(LineStr + Var.CR);
            }
            return ArrStr.ToString();
        }*/

        //Собрать строку Values из массива. Формат строки Values:
        //value1;value2;value3...
        //value2;value5;value5...        
        /*public static string[,] ArrayFromStr2(string Values)
        {
            string[,] ResultArr = null;
            if (Values == "") return ResultArr;           
            string[] arr1 = Values.Split('\n');             
            for (int i = 0; i < arr1.Length; i++)
            {
                string[] arr2 = arr1[i].Split(';');
                if (ResultArr == null)
                   ResultArr = new string[arr1.Length, arr2.Length];
               
                for (int j = 0; j < arr2.Length; j++) 
                    ResultArr[i, j] = arr2[j];//.FromBase64();
            }
            return ResultArr;
        }*/
//=================================================================	
  //Установка соединения для доступа к системным таблицам.
        /*public static void SetSystemConnection()
        {
            //Для того чтобы была возможность переключать место хранения таблиц, необходимых для работы данной платформы.
            //Для того чтобы была возможность хранить системные таблицы, как в базе с данными (что правильнее), 
            //так и в базе SQLite сервера приложений. 

            //Если подключение напрямую.
            if (con.ConnectionDirect)
            {
                //Если системные таблицы в базе SQLite, то...
                //conSys.ServerType присваивать не нужно.
                if (sys.SystemSysLocal) Var.conSys = Var.conLite;
                else Var.conSys = Var.con;
            }
            else
            {
                //Если подключение через сервер приложений.        
                Var.conSys = Var.con;
                if (sys.SystemSysLocal) Var.conSys.serverType = Var.con.ServerSys;
            }
        }*/

//=================================================================	
            //new FormDirectory("ДогСтрах", "", true, true, "Filter", "", "", "").Show();
            //Form FormContract = sys.FormShow("FormContract", "FormContractDir", 0);
            //dynamic FormContract = sys.FormShowDynamic("FormContract", "FormContractDir", 0);
//=================================================================	
 //Показ справочника
        /*public static FormFBA ShowDirectory(string entityBrief,
                                            string objectID,
                                            bool multiselect,
                                            bool allowUpdate,
                                            ShowMode showMode,
                                            string formProject,
                                            string formName)
        {
            var Params = new DirectoryParams();
            Params.EntityBrief = entityBrief;
            Params.ObjectID    = objectID;
            Params.Multiselect = multiselect;
            Params.AllowUpdate = allowUpdate;
            Params.showMode    = showMode;
            Params.FormProject = formProject;
            Params.FormName    = formName;
            var FObj           = new FormDirectory(entityBrief, ref Params);
            FObj.Show();
            return FObj;
        }*/
//=================================================================	
    //Не используется сейчас. Показывает формочку с одной кнопкой Test. 
      /*  public static void ShowTestProgram(string codeMainMethod)
        {
            string formFile = FBAPath.PathMain + "temp.exe";
            string codeText = sys.GetDefaultProject().Replace("'", @"""").Replace("//ExampleCode", codeMainMethod);
            sys.SM(codeText);
            string errorMes;
            if (sys.CSharpCodeCompile("EXE", codeText, formFile, "", -1, out errorMes))
                sys.FileRunEXESimple(formFile);
            else sys.SM(errorMes);
        }*/
//=================================================================	
 //Не используется сейчас. Компиляция и выполнение кода C#.

    
/*
        //Не используется сейчас. Компиляция кода C# в файл DLL, CopmilePath - путь выходного DLL, ReferenceList - список ссылок. 
        public static bool CSharpCodeCompile1(string Target, string CSharpCode, string ResultFileName, string ReferenceList, int BeginCodeApp, out string ErrorList)
        {
            string TargetType = @"/target:library";
            if (Target == "exe") TargetType = @"/target:winexe";
            bool Res = false;
            //Настройки компиляции
            var providerOptions = new Dictionary<string, string>
            {{"CompilerVersion", "v4.0"}};

            var provider = new CSharpCodeProvider(providerOptions);
            var compilerParams = new CompilerParameters
            {
                OutputAssembly = ResultFileName,
                GenerateExecutable = true,
                CompilerOptions = TargetType //"/target:library"    //CompilerOptions = "/target:winexe";                                  
            };

            //System.IO.Directory.SetCurrentDirectory(sys.PathMain);
            compilerParams.ReferencedAssemblies.Add(FBAPath.PathMain + "sys.dll"); //Включаем общую библиотеку.

            //Включение сборок в скомпилированный файл    
            string CopmilePath = Path.GetDirectoryName(ResultFileName);
            System.IO.Directory.SetCurrentDirectory(CopmilePath);

            ReferenceList = ReferenceList.Replace(Var.CR, " ");
            foreach (var par in ReferenceList.Split(' '))
            {
                string par1 = par.Trim();
                if (par1.Length > 0)
                {
                    if (par.ToLower().IndexOf(".dll", StringComparison.OrdinalIgnoreCase) == -1) par1 += @".dll";
                    compilerParams.ReferencedAssemblies.Add(par1);
                }
            }

            //Компиляция
            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, CSharpCode); //textCS.Text
            compilerParams = null;
            provider = null;

            //Если есть ошибки компиляции.
            if (results.Errors.Count > 0)
            {
                ErrorList = DateTime.Now.ToLongTimeString() + ": Количество ошибок: " + results.Errors.Count + Var.CR;

                //Выводим инфу об ошибках
                for (int i = 0; i < results.Errors.Count; i++)
                {
                    string ErrorMes = DateTime.Now.ToLongTimeString() + ":" + " Ошибка." + results.Errors[i].ErrorNumber;
                    if ((results.Errors[i].Line > 0) || (results.Errors[i].Column > 0))
                    {
                        if (BeginCodeApp > 0) ErrorMes += " Строка: " + (results.Errors[i].Line - BeginCodeApp) + " В полном тексте: " + results.Errors[i].Line + " Позиция: " + results.Errors[i].Column;
                        if (BeginCodeApp <= 0) ErrorMes += " Строка в полном тексте: " + results.Errors[i].Line + " Позиция: " + results.Errors[i].Column;
                    }
                    if (results.Errors[i].ErrorText != "") ErrorMes += " Описание: " + results.Errors[i].ErrorText;
                    //if (results.Errors[i].FileName != "") ErrorMes += " " + results.Errors[i].FileName;
                    ErrorList += ErrorMes + Var.CR;
                }
            }
            else
            {
                //Ошибок компиляции нет.
                Res = true;
                ErrorList = DateTime.Now.ToLongTimeString() + ": Компиляция успешная: " + results.PathToAssembly + Var.CR;
            }
            return Res;
        }

        //Не используется сейчас. Компиляция кода C# в файл DLL, CopmilePath - путь выходного DLL, ReferenceList - список ссылок. 
        public static bool CSharpCodeCompile(string Target, string CSharpCode, string ResultFileName, string ReferenceList, int BeginCodeApp, out string ErrorList)
        {
            string TargetType = @"/target:library";
            if (Target.ToLower() == "exe") TargetType = @"/target:winexe";
            bool Res = false;
            //Настройки компиляции
            var providerOptions = new Dictionary<string, string>
            {{"CompilerVersion", "v4.0"}};

            var provider = new CSharpCodeProvider(providerOptions);
            var compilerParams = new CompilerParameters
            {
                OutputAssembly = ResultFileName,
                GenerateExecutable = true,
                CompilerOptions = TargetType //"/target:library"    //CompilerOptions = "/target:winexe";                                  
            };

            //System.IO.Directory.SetCurrentDirectory(sys.PathMain);
            compilerParams.ReferencedAssemblies.Add(FBAPath.PathMain + "sys.dll"); //Включаем общую библиотеку.

            //Включение сборок в скомпилированный файл    
            string CopmilePath = Path.GetDirectoryName(ResultFileName);
            System.IO.Directory.SetCurrentDirectory(CopmilePath);

            if (ReferenceList == "") ReferenceList = GetDefaultAssemblies();
            ReferenceList = ReferenceList.Replace(Var.CR, " ");
            foreach (var par in ReferenceList.Split(' '))
            {
                string par1 = par.Trim();
                if (par1.Length > 0)
                {
                    if (par.ToLower().IndexOf(".dll", StringComparison.OrdinalIgnoreCase) == -1) par1 += @".dll";
                    compilerParams.ReferencedAssemblies.Add(par1);
                }
            }

            //Компиляция
            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, CSharpCode); //textCS.Text
            compilerParams = null;
            provider = null;

            //Если есть ошибки компиляции.
            if (results.Errors.Count > 0)
            {
                ErrorList = DateTime.Now.ToLongTimeString() + ": Количество ошибок: " + results.Errors.Count + Var.CR;

                //Выводим инфу об ошибках
                for (int i = 0; i < results.Errors.Count; i++)
                {
                    string ErrorMes = DateTime.Now.ToLongTimeString() + ":" + " Ошибка." + results.Errors[i].ErrorNumber;
                    if ((results.Errors[i].Line > 0) || (results.Errors[i].Column > 0))
                    {
                        if (BeginCodeApp > 0) ErrorMes += " Строка: " + (results.Errors[i].Line - BeginCodeApp) + " В полном тексте: " + results.Errors[i].Line + " Позиция: " + results.Errors[i].Column;
                        if (BeginCodeApp <= 0) ErrorMes += " Строка в полном тексте: " + results.Errors[i].Line + " Позиция: " + results.Errors[i].Column;
                    }
                    if (results.Errors[i].ErrorText != "") ErrorMes += " Описание: " + results.Errors[i].ErrorText;
                    //if (results.Errors[i].FileName != "") ErrorMes += " " + results.Errors[i].FileName;
                    ErrorList += ErrorMes + Var.CR;
                }
            }
            else
            {
                //Ошибок компиляции нет.
                Res = true;
                ErrorList = DateTime.Now.ToLongTimeString() + ": Компиляция успешная: " + results.PathToAssembly + Var.CR;
            }
            return Res;
        }

        //Не используется сейчас. Компиляция и выполнение кода C#. 
        */
//=================================================================	
/*
  //Получение текста INSERT для вставки записей в таблицу в БД из таблицы DT.
        public static string GetTextInsertTable_old(ServerType serverType, string TableName, System.Data.DataTable DT)
        {
            string TextBeginTran = "";
            var InsertText = new StringBuilder("", 10000);
            if (serverType == ServerType.MSSQL) TextBeginTran = "BEGIN TRANSACTION SET IDENTITY_INSERT " + TableName + " ON " + Var.CR;
            if (serverType == ServerType.SQLite) TextBeginTran = "BEGIN TRANSACTION;" + Var.CR;
            if (serverType == ServerType.Postgre) TextBeginTran = "BEGIN TRANSACTION;" + Var.CR;
            InsertText.Append(TextBeginTran);
            var InsertBeg = new StringBuilder("INSERT INTO " + TableName + " (", 1000);
            int iColumnCount = DT.Columns.Count;
            bool Is19 = false; //Для того чтобы конвертировать дату.
            for (int i = 0; i < iColumnCount; i++)
            {
                InsertBeg.Append(DT.Columns[i].ColumnName);
                if (i < iColumnCount - 1) InsertBeg.Append(",");
                if (DT.Rows.Count > 0)
                {
                    Is19 = (DT.Rows[0][i].ToString().Length == 19);
                }
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
                        Value = DT.Rows[i][j].ToString().DateTimeStrToMSSQL().Replace("'", "''");
                        InsertStr.Append("'" + Value + "'");
                        if (j < iColumnCount - 1) InsertStr.Append(",");
                    }
                    InsertText.Append(InsertBegStr + InsertStr.ToString() + ");" + Var.CR);
                }
            }
            else
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    InsertStr.Clear();
                    for (int j = 0; j < iColumnCount - 1; j++)
                    {
                        Value = DT.Rows[i][j].ToString().Replace("'", "''");
                        InsertStr.Append("'" + Value + "',");
                    }
                    Value = DT.Rows[i][iColumnCount - 1].ToString().Replace("'", "''");
                    InsertStr.Append("'" + Value + "'");
                    InsertText.Append(InsertBegStr + InsertStr.ToString() + ");" + Var.CR);
                }
            }
            string TextEndTran = "";
            if (serverType == ServerType.MSSQL)    TextEndTran = "SET IDENTITY_INSERT " + TableName + " OFF " + Var.CR + "COMMIT TRANSACTION; " + Var.CR;
            if (serverType == ServerType.SQLite)   TextEndTran = Var.CR + " COMMIT TRANSACTION; " + Var.CR;
            if (serverType == ServerType.Postgre) TextEndTran = Var.CR + " COMMIT TRANSACTION; " + Var.CR;
            InsertText.Append(TextEndTran);
            return InsertText.ToString();
        }
 
*/    
//=================================================================	
   
/*
//Запись значения настройки таблицы в таблицу настроек fbaFlexList.
        //Настройки может быть глобальной (для всех пользователей одна с именем FlexName) и индивидуальная.
        //Если индивидуальная, то имя FlexName может повторяется для разных пользователей.
        public static bool FlexSave(string Direction, string FlexName, bool Global, string FlexValue, string EntityBrief)
        {                                                                                         
            string GlobalSQL = "";
            string GlobalStr = "";
            if (Global) 
            {
                GlobalSQL = " AND Global = 1";
                GlobalStr = "1";
            } else
            {
               GlobalSQL = " AND Global = 0 AND UserChangeID = " + Var.UserID ;
               GlobalStr = "0";
            }
            string SQL = "SELECT ID FROM fbaFlexList WHERE Name = '" + FlexName + "' AND EntityBrief = '" + EntityBrief + "'" + GlobalSQL;
            string SetName = Var.con.GetValue(SQL);              
             
            
            if (SetName == "")
            {
                SQL = "INSERT INTO fbaParam (EntityID, Name, FormID, Global, Type, Value, DateCreate, UserCreateID, DateChange, UserChangeID) VALUES (" +
                "9000," +                               
                "'" + ParamName + "'," +              
                GetFormID         + ","  +                                        
                GlobalStr         + ","  +               
                "'" + SettingType + "'," +                    
                "'" + SettingValue.ToBase64() + "'," +
                "'" + sys.DateTimeCurrent() + "'," + 
                Var.UserID  + "," +
                "'" + sys.DateTimeCurrent() + "'," + 
               Var.UserID  + ")";
            } else
            {
                SQL = "UPDATE fbaSetting SET " + 
                      "Name       = '" + SettingName  + "'," + 
                      "FormID     = "  + GetFormID    + "," +                  
                      "Global     = "  + GlobalStr    + "," +                 
                      "Type       = '" + SettingType  + "'," +
                      "DateChange = '" + sys.DateTimeCurrent() + "'," +                     
                      "Value      = '" + SettingValue.ToBase64() + "' WHERE Name = '" + SettingName + "' AND Type = '" + SettingType + "'" + GlobalSQL;
            }                 
            return sys.Exec(Direction, SQL);                            
        }
        
        //Чтение пользовательского значения из таблицы настроек fbaSetting.  
        public static bool FlexSaveGlobal(string Direction, string SettingName, string SettingValue)
        {
            const bool Global        = true;
            const string SettingType = "User";
            const string FormID      = "";
            return sys.ParamSave(Direction, SettingName, Global, SettingValue, SettingType, FormID);
        }
        
        //Чтение пользовательского значения из таблицы настроек fbaSetting.  
        public static bool FlexSaveUser(string Direction, string SettingName, string SettingValue)
        {
            const bool Global        = false;
            const string SettingType = "User";
            const string FormID      = "";
            return sys.ParamSave(Direction, SettingName, Global, SettingValue, SettingType, FormID);
        }
                
        //Чтение значения настройки из таблицы настроек fbaSetting.
        public static bool FlexLoad(string Direction, string SettingName, bool Global, string SettingType, out string SettingValue)
        {            
            string GlobalSQL = "";                         
            SettingValue     = "";
            if (Global) 
            {
                GlobalSQL = " AND Global = 1";                 
            } else
            {
               GlobalSQL = " AND Global = 0 AND UserChangeID = " + Var.UserID ;                
            }            
            string SQL = "SELECT Value FROM fbaSetting WHERE Name = '" + SettingName + "' AND Type = '" + SettingType + "'" + GlobalSQL;                                
            System.Data.DataTable DT;
            if (!sys.SelectDT1(Direction, SQL, out DT)) return false;                       
            SettingValue  = sys.DTValue(DT, "Value").FromBase64();
            return true;
        }
        
        //Чтение глобального значения из таблицы настроек fbaSetting.  
        public static string FlexLoadGlobal(string Direction, string SettingName)
        {                             
             const bool Global        = true;             
             string SettingValue      = "";
             const string SettingType = "User";
             if (!sys.ParamLoad(Direction, SettingName, Global, SettingType, out SettingValue)) return "";
             return SettingValue;                                                                  
        }
    
        //Чтение пользовательского значения из таблицы настроек fbaSetting.  
        public static string FlexLoadUser(string Direction, string SettingName)
        {                             
             const bool Global        = false;             
             string SettingValue      = "";
             const string SettingType = "User";
             if (!sys.ParamLoad(Direction, SettingName, Global, SettingType, out SettingValue)) return "";
             return SettingValue;                                                                  
        }
                 
      
        */
//=================================================================	
 // <summary>
        // Переопределение события Paint.
        // </summary>
        // <param name="e"></param>
   /*     protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(e);

            /*if (!StarShow) return;                
            TextFormatFlags flags = TextFormatFlags.NoPadding;             
            Size proposedSize = new Size(int.MaxValue, int.MaxValue);
            Size size = TextRenderer.MeasureText(
                e.Graphics,
                this.Text,
                this.Font, proposedSize, flags);
            int WidthText = size.Width;

            e.Graphics.DrawString(StarText,                   
                 StarFont,            
                 new SolidBrush(StarColor),   
                 //Прямоугольник, куда вписываем строку                      
                 //new Rectangle(WidthText + StarOffsetX, StarOffsetY, this.Width - (WidthText + StarOffsetX), this.Height));
             new Rectangle(WidthText + StarOffsetX + 10, StarOffsetY + 4,  this.Width - (WidthText + StarOffsetX) - 20, 18));
            
        } */
//=================================================================	
   //Сохранение DataGridView в CSV.
    /*    public static bool CopyToCSV(string FileName)
        {         
           const string InitialDirectory = "";
          if (FileName == "")
               if (!SaveFileName("Выбор имени файла для сохранения", "", InitialDirectory, ref FileName)) return false;
           FileName = FileName + ".csv";               
           int ColCount = DG.Columns.Count;
           int RowCount = DG.Rows.Count;
        string[] output;
        
        int SelRows = DG.SelectedRows.Count;
        int N = 1;
        if (SelRows > 1) output = new string[SelRows + 1]; 
        else output = new string[DG.Rows.Count + 1];           
        var headers = DG.Columns.Cast<DataGridViewColumn>();
        output[0] += string.Join(";", headers.Select(e => e.HeaderText).ToArray()); 
        string sep = "";           
        for (int i = 0; i < RowCount; i++)
        {
            if ((SelRows > 1) && (!DG.Rows[i].Selected)) continue;
            for (int j = 0; j < ColCount; j++)
            {
                if (j < (ColCount - 1)) sep = ";"; else sep = "";
                output[N] += DG.Rows[i].Cells[j].Value.ToString().Replace(Var.CR, " ").Replace(";", ",") + sep;                    
            }
            N++;
        }
        System.IO.File.WriteAllLines(FileName, output, System.Text.Encoding.UTF8);
        sys.SM("Таблица сохранена в файл CSV: " + FileName, MessageType.Information);
      
           return true;
        }
        */
//=================================================================	
//Копирование всех данных в другой DataGridView.
        //Если CopyRows = false, то копируется только структура(названия колонок).
        //Если CopyRows = true, то копируются также все строки.         
        //public static void CopyToGridSourceGrid(this SourceGrid.Grid DGSource,
        //                                             SourceGrid.Grid DGDest,
        //                                             bool CopyRows)
        //{
            //DGSource.PerformCopy(
            /*DGDest.Redim(DGSource.Rows.Count, DGSource.Columns.Count);
            for (int i = 0; i < DGSource.Columns.Count; i++) 
            {
                
            }
            
            foreach (DataGridViewColumn Col in DGSource.Columns)
                DGDest.Columns.Add((DataGridViewColumn)Col.Clone());
            
            if (!CopyRows) return;
            foreach (DataGridViewRow Row in DGSource.Rows)
            {      
                DGDest.Rows.Add((DataGridViewRow)Row.Clone());
                    for(int i = 0; i < DGSource.Columns.Count; i++)
                       DGDest.Rows[Row.Index].Cells[i].Value = Row.Cells[i].Value;
            } */
        //}
//=================================================================	

//=================================================================	
     