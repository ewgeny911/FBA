/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 11.11.2017
 * Время: 19:30
 */  
 
using System;
using System.Windows.Forms; 
using System.Linq;

namespace FBA
{         
	/// <summary>
	/// Статический класс для тестирования работы ObjectRef.
	/// </summary>
	public static class TestObjectRef
    { 
		
		/// <summary>
		/// Тестовые методы для проверки работы методов ObjectRef.
		/// </summary>
		public static void TestSaveObject()
		{
			var obj1 = new ObjectRef();
			obj1.SetQueryEntity(null, "Main1", "Contract", "", "", DirectionQuery.Remote);   
			obj1.AddAttr("Main1.Number", "123456789");          
            obj1.Write();
            string id1 = obj1.GetObjectID("Main1");
            var obj2 = new ObjectRef();
            obj2.SetQueryEntity(null, "Main1", "Contract", id1, "", DirectionQuery.Remote);          
            string id2 = obj2.GetValue("Main1.Number");           
            if (id1 != id2) sys.SM("Ошибка ObjectRef!");
            else sys.SM("Ошибка ObjectRef!", MessageType.Information);
            obj2.DeleteObject("Main1");            
            obj1.SetQueryEntity(null, "Main1", "Contract", id2, "", DirectionQuery.Remote);   
            obj1.Read();
            if (!obj1.ObjectFound("Main1")) sys.SM("Ошибка не найден объект!", MessageType.Information);;
            //Text = this.Obj.GetObjectName("Main1");            
		}
	}

    /// <summary>
    /// Класс, в котором реализована возможность присваивать компонентам значения из таблиц в БД. 
    /// </summary>
    /// <remarks>
    /// Это класс для чтения из базы данных и присваивания значений компонентам.
    /// Также при изменении пользователем значения компонента, изменения отправляются в БД с помощью запросов (Insert и Update).
	/// Чтобы показать значения компонентов на форме можно использовать три команды SetQueryTable, SetQueryEntity, SetQueryDirect.       
    /// Если компоненты получают свое значение через команду SetQueryDirect, то обновить данные в базе нельзя.
    /// Если компоненты получают свое значение через команду SetQueryTable или SetQueryEntity, то обновить данные в БД можно.
    /// Есть три таблицы  Ent, Ref, Tbl. В таблице Ent (главная) содержатся все объекты или все привязки к компонентам.
    /// В Ref - содержатся все значения компонентов формы, старые и новые.
    /// В Tbl - содержится список таблиц объекта. Tbl используется только в случае с SetQueryEntity, так как в объекте может быть несколько таблиц. 
    /// В случае с SetQueryDirect Tbl тоже само собой не используется, так как SetQueryDirect - это происзвольный запрос к БД, может содержать много таблиц, вложенных запросов и чего угодно.
    /// Tbl используется только для составления запросов одновления данных в БД.
    /// При SetQueryTable - всегда данные читаются из одной таблицы, поэтому массив также Tbl не используется.  
    /// Возможность показать значение в компоненте на форме:
    /// 1. Из таблицы в БД. (SetQueryTable)
    /// 2. Из атрибута сущности. (SetQueryEntity)
    /// 3. Из результата прямого запроса (MSQL или SQL). (SetQueryDirect)    
    /// Изменить значене в БД можно только в том случае, если значение атрибута выведено из атрибута сущности или из таблицы в БД.  
    /// </remarks>
    public class ObjectRef
    {                                                                        
        /// <summary>
        /// Все запросы к локальной БД. 
        /// </summary>
        public string localSQL   = "";

        /// <summary>
        /// Все запросы к удаленной БД до перевода в SQL. 
        /// </summary>
        public string RemoteMSQL = ""; 
        
        /// <summary>
        /// Все запросы к удаленной БД после перевода в SQL.   
        /// </summary>
        public string remoteSQL  = ""; 
            
        /// <summary>
        /// Это заглушка. Если true, то используется функционал записи объекта в этом модуле, если false, то используется хранимая процедура на сервере.
        /// </summary>
        public bool SaveObjectAtClient = true;
                	 	 
		/// <summary>
        /// Тип записи в Ent.
        /// </summary>	
	 	private enum ObjectRefType
		{
	 		Table, 
	 		Entity, 
	 		Direct
	 	}
	 		 	
        #region Region. Константы для массивов.
    
        //Константы для массива Ref.
        private const int iPos         = 0;  //Порядковый номер строки массива.
        private const int iTypeAction  = 1;  //Код действия (1 - Из таблицы в БД, 2 - из атрибута сущности, 3 - из результата прямого запроса. //не используется.  
        private const int iName        = 2;  //Имя контрола на форме.
        private const int iTypeControl = 3;  //Тип контрола.
        private const int iTag         = 4;  //Значение свойства Tag контрола. //не используется.  
        private const int iQueryName   = 5;  //Имя объекта ObjectRef. (ObjectRef = QueryName, так как у нас их три типа)
        private const int iAttr        = 6;  //Сокращение атрибута или имя поля в таблице.
        private const int iAttrLookup  = 7;  //Сокращение атрибута или имя поля в таблице которое показано буде по ссылке.
        private const int iEnt         = 8;  //Ссылка на запись в массиве Ent, чтобы знать к какому Ent относится тот или иной компонент.
        private const int iEntityBrief = 9;  //Сокращение сущности.
        private const int iEntityID    = 10; //ИД сущности.
        private const int iObjectID    = 11; //ИДОбъекта.
        private const int iStateDate   = 12; //Историчная дата.  
        private const int iTableName   = 13; //Имя таблицы в БД, в которой храниться значение атрибута.
        private const int iTableType   = 14; //Тип таблицы в БД, в которой храниться значение атрибута.
        private const int iFieldName   = 15; //Имя поля в БД, в которой храниться значение атрибута.
        private const int iFieldName2  = 16; //Имя поля в БД, в которой храниться значение атрибута.
        private const int iIDFieldName = 17; //Поле автоинкремента таблицы в БД, в которой храниться значение атрибута.
        private const int iPosLocal    = 18; //Локальная БД. Порядковый номер таблицы (начиная с 0) в конечной выборке из нескольких SELECT. Т.е. номер SELECT.
        private const int iPosRemote   = 19; //Удаленная БД. Порядковый номер таблицы (начиная с 0) в конечной выборке из нескольких SELECT. Т.е. номер SELECT.        
        private const int iSetting     = 20; //Признак что этот компонент нужно сохранять в настройках.
        private const int iValueOld    = 21; //Старое значение атрибута.
        private const int iValueNew    = 22; //Новое значение атрибута. Здесь текст значения компонента. (control.Text).
        private const int iValueNewID  = 23; //Новое значение атрибута но не виде текста, а в виде ID.  Это для лукап EditFBA или SelectedIndex.
        private const int iSaveType    = 24; //Тип записи в БД значения: TEXT, INDEX, LOOKUP.
        private const int iNeedSave    = 25; //Нужно сохранять изменения 1, не нужно 0.
		private const int iNumLevel    = 26; //Уровень вложенности атрибута сущности.
		private const int iValueSave   = 27; //то что записываем в БД. В этом поле будет то, что будет вставялстья в запросы Insert и Update.
        
		//Константы для массива Ent.
        private const int nPos           = 0;  //Порядковый номер строки массива.
        private const int nTypeEnt       = 1;  //Код действия (1 - Из таблицы в БД, 2 - из атрибута сущности, 3 - из результата прямого запроса.
        private const int nDirection     = 2;  //Запрос к локальной БД или удаленной. Local - локальная, Remote - удаленная.
        private const int nEntityBrief   = 3;  //Сокращение сущности.
        private const int nEntityID      = 4;  //Сокращение сущности.
        private const int nQueryName     = 5;  //Имя запроса SELECT.
        private const int nTableName     = 6;  //Имя таблицы из которой будут показываться данные.      
        private const int nIDFieldName   = 7;  //Поле автоинкремента в таблице.
        private const int nLanguage      = 8;  //Язык запроса SQL или MSQL.                                                                   
        private const int nDirect        = 9;  //Признак прямого запроса на SQL или MSQL. Если 1, то прямой, иначе 0.
        private const int nNeedSave      = 10; //Нужно сохранять изменения 1, не нужно 0.
        private const int nObjectID      = 11; //ИД объекта сущности или ID записи в таблице в БД. 
        private const int nStateDate     = 12; //Историчная дата. 
        //private const int nStateDateNew   = 12; //Историчная дата.  
        private const int nPosLocal      = 13; //Локальная БД. Порядковый номер таблицы (начиная с 0) в конечной выборке из нескольких SELECT. Т.е. номер SELECT.
        private const int nPosRemote     = 14; //Удаленная БД. Порядковый номер таблицы (начиная с 0) в конечной выборке из нескольких SELECT. Т.е. номер SELECT. 
        private const int nSelectMSQL    = 15; //Запрос на MSQL для чтения значений атрибутов.
        private const int nSelect        = 16; //SQL запрос. 
        private const int nUpdate        = 17; //SQL запрос. 
        private const int nInsert        = 18; //SQL запрос. 
        private const int nDelete        = 19; //SQL запрос.
		private const int nInsertFirst   = 20; //SQL запрос перового инсерта, для тогог чтобы получить ИД Объекта для последующих инсертов.         
        private const int nNewObject     = 21; //Признак, что объект новый.
        private const int nIDWasFindInDB = 22; //Признак, что объект был найден в базе при чтении. obj.Read();
        private const int nDirty         = 23; //Признак, что объект был изменён. 
             
        //Дополнительные запросы перед действием и после.
		private const int tran_Pos             = 0; //Порядковый номер строки массива.
        private const int tran_QueryName       = 1; //Имя запроса, с которым связаны запросы Before и After.
        private const int tran_SQL             = 2;    
        private const int tran_Before_Or_After = 3; 
        private const int tran_SQL_Or_MSQL     = 4;                
        #endregion Константы для массивов.

        #region Region. Объявления переменных.

        /// <summary>
        /// Максимальное количество компонентов на форме - 1000.
        /// </summary>
        public int RefCount  = 0;  
        
        /// <summary>
        /// /Максимальное количество сущностей, из которых будут получать значения компоненты формы - 100.
        /// </summary>
        public int EntCount  = 0;  
        
        /// <summary>
        /// Счетчик добавленных запросов.
        /// </summary>
		public int TranCount = 0;  
       
		/// <summary>
		/// Массив значений компонентов формы и атрибутов.
		/// </summary>
        public string[,] Ref = new string[1000, iValueSave + 1]; 
           
        /// <summary>
        /// Массив сущностей и/или таблиц, которые используются в свойстве Tag компонентов.
        /// </summary>
        public string[,] Ent = new string[100,  nDirty + 1];            
        
        /// <summary>
        /// В этом массиве будет храниться все запросы которомуые будут выполняться перед запросом записи объекта и после записи объекта
        /// на языках SQL и MSQL.
        /// Этот код будет выполняться в рамках одной транзакции с записью объекта (перед запросом записи объекта или после записи)
        /// MSQL - тоже самое что и SQL, но запрос будет конвертирован в MSQL из SQL.           
        /// </summary>
        public string[,] SQLTransaction = new string[100, tran_SQL_Or_MSQL + 1];
        
        private System.Data.DataSet DSLocal   = new System.Data.DataSet(); //Список таблиц, которые получаются в результате запроса к локальной SQLite.
        private System.Data.DataSet DSRemote  = new System.Data.DataSet(); //Список таблиц, которые получаются в результате запроса к удаленной БД.                             
        private Form form; //Форма для которой будут использоваться методы данного объекта ObjectRef.             
                       
        #endregion Region. Объявления переменных.                   
        
        #region Region. Добавление запросов для выполнения в одной транзакции с записью объекта.
                
		/// <summary>
		/// Признак того что при Obj.Write уже не нужно считывать все компоненты с формы. Онии были прочитаны на Obj.Read.
		/// </summary>		
        public bool formWasRead  = false;                                     
        
        /// <summary>
        /// Добавление запроса SQL. Возвращается порядковый номер запроса.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="query">Запрос на языке Master SQL или SQL</param>
        /// <param name="lang">Язык. SQLLang.MSQL или SQLLang.SQL</param>
        /// <param name="timeAction">Место выполнения запроса. TimeAction.Before или TimeAction.After</param>
        /// <returns>если успешно, то true</returns>     
        public int AddQuery(string queryName, string query, SQLLang lang, TimeAction timeAction)
        {                                                                    
        	if (query == "") return -1;
            string queryAdd = query;
            if (lang == SQLLang.MSQL) queryAdd = sys.Parse(query);                                               
            SQLTransaction[TranCount, tran_Pos]             = TranCount.ToString();
            SQLTransaction[TranCount, tran_QueryName]       = queryName;
            SQLTransaction[TranCount, tran_SQL]             = queryAdd;
            SQLTransaction[TranCount, tran_Before_Or_After] = TimeAction.Before.ToString();
            SQLTransaction[TranCount, tran_SQL_Or_MSQL]     = lang.ToString();
            TranCount++;
            return TranCount;  
        }                   
        
        /// <summary>
        /// Удаление запроса. Возвращается порядковый номер запроса. Остальные запросы номеров не меняют.
        /// </summary>
        /// <param name="numberQuery">Номер запроса</param>
        /// <returns>Если успешно, то true</returns>
        public bool DeleteAddQuery(int numberQuery)
        {    
            if ((numberQuery < 1) || (numberQuery > TranCount)) 
            {
                string ErrorMes = "";
                if (TranCount == 1) ErrorMes = "Неверный номер запроса для удаления. В списке всего один запрос с номером 1";
                if (TranCount > 1) ErrorMes = "Неверный номер запроса для удаления. Должно быть одно из значений: 1.." + TranCount.ToString();
                sys.SM(ErrorMes);
                return false;
            }
            SQLTransaction[numberQuery, tran_SQL]             = "";
            SQLTransaction[numberQuery, tran_Before_Or_After] = "";
            SQLTransaction[numberQuery, tran_SQL_Or_MSQL]     = "";
            return true;
        }             
            
        /// <summary>
        /// Удаление QueryName. Мало ли... может понадобится. Просто очищаем строки.
        /// </summary>
        /// <param name="queryName">Имя QueryName</param>
        /// <returns>Если успешно, то true</returns>
        public bool DeleteQuery(string queryName)
        {
            for (int i = 0; i < EntCount; i++)
            {            
                if (Ent[i, nQueryName] == queryName) 
                {                                      
                    for (int j = 0; j < nInsert;   j++) Ent[i, j] = "";
                    for (int j = 0; j < iValueNew; j++) Ref[i, j] = ""; 
                    return true;                    
                }
            }
            return false;  
        }   
        
        /// <summary>
        /// Сборка запросов перед выполнением.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="sourceSQL">Сборка всех запросв в один и вставка дополнительных запросов Before или After</param>
        /// <returns>Текст всех запросов</returns>
        private string AddQuery_Bebore_After_In_ResultQuery(string queryName, string sourceSQL)
        {
            string resultQuery = "";
            for (int i = 0; i < TranCount; i++)
            {
                if (SQLTransaction[TranCount, tran_Before_Or_After] != TimeAction.Before.ToString()) continue;
                if (SQLTransaction[TranCount, tran_QueryName] == queryName) resultQuery = resultQuery + SQLTransaction[TranCount, tran_SQL] + Var.CR;
                
            }            
            resultQuery = resultQuery + Var.CR + sourceSQL;            
            for (int i = 0; i < TranCount; i++)
            {
                if (SQLTransaction[TranCount, tran_Before_Or_After] != TimeAction.After.ToString()) continue;
                if (SQLTransaction[TranCount, tran_QueryName] == queryName) resultQuery = resultQuery + SQLTransaction[TranCount, tran_SQL] + Var.CR;;
                
            }
            return resultQuery;
        }
        
        #endregion Region. Добавление запросов для выполнения в одной транзакции с записью объекта.              
        
        #region Region. Установка QueryName. (SetQuery)                                                     
           
        /// <summary>
        /// Возможность показать значение в компонентах формы из таблицы в БД.
        /// Пример вызова: 
        /// Obj = new FBA.ObjectRef();
        /// Obj.SetQueryTable(this, "Main1", "fbaAttr", ObjID, "AttributeID", "", "Remote");
        /// Obj.Read();    
        /// </summary>
        /// <param name="form">Форма Windows.Forms</param>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="tableName">Сокращение сущности</param>
        /// <param name="objectID">ИД объекта</param>
        /// <param name="idFieldName">Поле ключа таблицы</param>
        /// <param name="stateDate">Дата состояния</param>
        /// <param name="direction">Локальная или удаленная база данных</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetQueryTable(Form form, string queryName, string tableName, string objectID, string idFieldName = "", string stateDate = "", DirectionQuery direction = DirectionQuery.Remote)
        {                                  
            if (FindQueryName(queryName, true)) return false;
        	if (idFieldName == "") idFieldName = ParserData.GetIDFieldName(tableName);
            if (idFieldName == "")
            {
                sys.SM("Ошибка. Не найдено поле ID таблицы " + tableName);
                return false;
            }
            if (objectID == "") objectID = "0";
            if (form != null) this.form = form;
            Ent[EntCount, nPos]         = EntCount.ToString();
            Ent[EntCount, nTypeEnt]     = ObjectRefType.Table.ToString();
            Ent[EntCount, nDirection]   = direction.ToString();
            Ent[EntCount, nEntityBrief] = "";
            Ent[EntCount, nEntityID]    = "";
            Ent[EntCount, nQueryName]   = queryName;
            Ent[EntCount, nTableName]   = tableName;            
            Ent[EntCount, nIDFieldName] = idFieldName;
            Ent[EntCount, nLanguage]    = SQLLang.SQL.ToString();
            Ent[EntCount, nDirect]      = "0";
            Ent[EntCount, nNeedSave]    = "1"; 
            Ent[EntCount, nObjectID]    = objectID;
            Ent[EntCount, nStateDate]   = stateDate;           
            Ent[EntCount, nPosLocal]    = "";
            Ent[EntCount, nPosRemote]   = "";
            Ent[EntCount, nSelectMSQL]  = "";
            Ent[EntCount, nSelect]      = "";
            Ent[EntCount, nUpdate]      = ""; 
            Ent[EntCount, nInsert]      = "";
            Ent[EntCount, nDelete]      = "";
            Ent[EntCount, nInsertFirst] = "";
            if (objectID == "0") Ent[EntCount, nNewObject] = "1"; else Ent[EntCount, nNewObject] = "0";
            Ent[EntCount, nIDWasFindInDB] = "";
            Ent[EntCount, nDirty]       = "";            
            EntCount++;   
            return true;
        }           
                                
        /// <summary>
        /// Возможность показать значение в компонентах формы из атрибута сущности.
        /// Пример вызова:
        /// Obj = new FBA.ObjectRef();        
        /// SetQueryEntity(this, "Застрахованный", "23158", "Remote");
        /// Obj.Read();  
        /// </summary>
        /// <param name="form">Форма Windows.Forms</param>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="entityBrief">Сокращение сущности</param>
        /// <param name="objectID">ИД объекта</param>
        /// <param name="stateDate">Дата состояния</param>
        /// <param name="direction">Локальная или удаленная база данных</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetQueryEntity(Form form, string queryName, string entityBrief, string objectID, string stateDate, DirectionQuery direction = DirectionQuery.Remote)
        {                                                     
        	if (FindQueryName(queryName, true)) return false;        	
        	if (form != null) this.form  = form;
            if (objectID == "") objectID = "0";
            Ent[EntCount, nPos]           = EntCount.ToString();
            Ent[EntCount, nTypeEnt]       = ObjectRefType.Entity.ToString();
            Ent[EntCount, nDirection]     = direction.ToString();
            Ent[EntCount, nEntityBrief]   = entityBrief;
            Ent[EntCount, nEntityID]      = sys.GetEntityID(entityBrief);
            Ent[EntCount, nQueryName]     = queryName;
            Ent[EntCount, nTableName]     = "";           
            Ent[EntCount, nIDFieldName]   = "";
            Ent[EntCount, nLanguage]      = SQLLang.MSQL.ToString();
            Ent[EntCount, nDirect]        = "0";
            Ent[EntCount, nNeedSave]      = "1"; 
            Ent[EntCount, nObjectID]      = objectID;
            Ent[EntCount, nStateDate]     = stateDate;             
            Ent[EntCount, nPosLocal]      = "";
            Ent[EntCount, nPosRemote]     = "";
            Ent[EntCount, nSelectMSQL]    = "";
            Ent[EntCount, nSelect]        = "";
            Ent[EntCount, nUpdate]        = "";
            Ent[EntCount, nInsert]        = "";
            Ent[EntCount, nDelete]        = "";
            Ent[EntCount, nInsertFirst]   = "";                     
            if (objectID == "0") Ent[EntCount, nNewObject] = "1"; else Ent[EntCount, nNewObject] = "0";
            Ent[EntCount, nIDWasFindInDB] = "";   
            Ent[EntCount, nDirty]         = "";
            EntCount++;  
            return true;
        }
                		
		/// <summary>
		/// Возможность показать значениев компонентах формы из результата прямого запроса.
        /// Примеры вызовов для SQL и MSQL: 
        /// Obj = new FBA.ObjectRef();  
        /// SetQueryDirect(this", SQLLang.MSQL, "select ДатаНачала from ДогСтрах where ИДОбъекта = 2284621", "Remote");
        /// Obj.Read();   
		/// </summary>
		/// <param name="form">Форма Windows Form. Необязательный параметр.</param>
		/// <param name="queryName">Имя запроса</param>
		/// <param name="lang">Язык. SQLLang.MSQL или SQLLang.SQL</param>
		/// <param name="query">Произвольный запрос на языке Master SQL или SQL</param>
		/// <param name="direction">Запрос к локальной или удалённой базе данных</param>
		/// <returns>Если успешно, то true</returns>
        public bool SetQueryDirect(Form form, string queryName, SQLLang lang, string query, DirectionQuery direction = DirectionQuery.Remote)
        {                                                                  
            if (FindQueryName(queryName, true)) return false;
        	this.form = form;
            Ent[EntCount, nPos]           = EntCount.ToString();
            Ent[EntCount, nTypeEnt]       = ObjectRefType.Direct.ToString();
            Ent[EntCount, nDirection]     = direction.ToString();
            Ent[EntCount, nEntityBrief]   = "";
            Ent[EntCount, nEntityID]      = "";
            Ent[EntCount, nQueryName]     = queryName;
            Ent[EntCount, nTableName]     = "";             
            Ent[EntCount, nIDFieldName]   = "";
            Ent[EntCount, nLanguage]      = lang.ToString();
            Ent[EntCount, nDirect]        = "1";
            Ent[EntCount, nNeedSave]      = "0"; 
            Ent[EntCount, nObjectID]      = "0";
            Ent[EntCount, nStateDate]     = ""; 
            Ent[EntCount, nPosLocal]      = "";
            Ent[EntCount, nPosRemote]     = "";
            if (lang == SQLLang.MSQL) Ent[EntCount, nSelectMSQL] = query; else Ent[EntCount, nSelectMSQL] = "";
            if (lang == SQLLang.SQL)  Ent[EntCount, nSelect]     = query; else Ent[EntCount, nSelect]     = "";
            Ent[EntCount, nSelect]        = query;
            Ent[EntCount, nUpdate]        = "";
            Ent[EntCount, nInsert]        = ""; 
            Ent[EntCount, nDelete]        = "";
            Ent[EntCount, nInsertFirst]   = "";
            Ent[EntCount, nNewObject]     = "2";
            Ent[EntCount, nIDWasFindInDB] = "";
            Ent[EntCount, nDirty]         = "";   
            EntCount++; 
            return true;
        }        
          
		/// <summary>
		/// Поиск QueruName.
		/// </summary>
		/// <param name="queryName">Имя запроса</param>
		/// <param name="showErrorIfExist">Показывать сообщение об ошибке, если найдены ошибки</param>
		/// <returns>Если успешно, то true</returns>
        public bool FindQueryName(string queryName, bool showErrorIfExist)
        {
        	for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nQueryName] != queryName) continue;
        		return true;                
            }
        	if (!showErrorIfExist) sys.SM("Ошибка! Заданный QueryName уже существует.");
        	return false;
        }      
        
        /// <summary>
        /// Удаление QueryName.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Если успешно, то true</returns>
        public bool DeleteQueryName(string queryName)
        {
        	for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nQueryName] != queryName) continue;
        		for (int j = 0; j < nDirty; j++) Ent[i, j] = "";        			               
            }        	
        	for (int i = 0; i < RefCount; i++)
            {
                if (Ref[i, nQueryName] != queryName) continue;
        		for (int j = 0; j < iValueSave; j++) Ref[i, j] = "";        			              
            }        	        
        	return true;
        }                  
        
        /// <summary>
        /// Для ручного добавления атрибута в QueryName
        /// </summary>
        /// <param name="tagStr">Полный путь атрибута с QueryName. Пример: Main1.Договор.Номер</param>
        /// <param name="valueAttr">Значение добавляемого атрибута</param>
        public void AddAttr(string tagStr, string valueAttr = "NULL")
        {
            string errorMes = "";
            tagStr = tagStr.Trim();
            if (tagStr == "") errorMes = "Ошибка. Для добавления выбран пустой атрибут!";  
            string queryName;
            string attr;
            string attrLookup;
            string setting;
            sys.ParseTag(tagStr, out queryName, out attr, out attrLookup, out setting);   
            if (queryName == "") errorMes = "Ошибка. Не определено название запроса!";      
            if (attr      == "") errorMes = "Ошибка. Не определен атрибут в запросе " + queryName;     
            if (errorMes != "")
            {
                sys.SM(errorMes);
                return;
            }
            Ref[RefCount, iPos] = RefCount.ToString();
            Ref[RefCount, iTypeAction]  = "";
            Ref[RefCount, iName]        = "Virtual";                      
            Ref[RefCount, iTypeControl] = "Virtual";
            Ref[RefCount, iTag]         = "Virtual"; 
            Ref[RefCount, iQueryName]   = queryName;
            Ref[RefCount, iAttr]        = attr;
            Ref[RefCount, iAttrLookup]  = attrLookup;
            Ref[RefCount, iEnt]         = "";  
            Ref[RefCount, iEntityBrief] = "";
            Ref[RefCount, iEntityID]    = "";                      
            Ref[RefCount, iObjectID]    = "";
            Ref[RefCount, iStateDate]   = "";                     
            Ref[RefCount, iTableName]   = "";
            Ref[RefCount, iTableType]   = "";                     
            Ref[RefCount, iFieldName]   = "";
			Ref[RefCount, iFieldName2]  = "";             
            Ref[RefCount, iIDFieldName] = "";                             
            Ref[RefCount, iPosLocal]    = "";  
            Ref[RefCount, iPosRemote]   = "";       
            Ref[RefCount, iSetting]     = ""; 
            Ref[RefCount, iValueOld]    = "";
            Ref[RefCount, iValueNew]    = valueAttr;          
            Ref[RefCount, iValueNewID]  = "";
            Ref[RefCount, iSaveType]    = "";
            Ref[RefCount, iNeedSave]    = "1";
            Ref[RefCount, iNumLevel]    = "";
            Ref[RefCount, iValueSave]   = "";
            RefCount++;
        } 
   
        /// <summary>
        /// Для ручного удаления атрибута из QueryName
        /// </summary>
        /// <param name="tagStr">Полный путь атрибута с QueryName. Пример: Main1.Договор.Номер</param>
        public void DeleteAttr(string tagStr)
        {
        	string errorMes = "";
            tagStr = tagStr.Trim();
            if (tagStr == "") errorMes = "Ошибка. Для удаления выбран пустой атрибут!";  
            string queryName;
            string attr;
            string attrLookup;
            string setting;
            sys.ParseTag(tagStr, out queryName, out attr, out attrLookup, out setting);   
            if (queryName == "") errorMes = "Ошибка. Не определено название запроса!";      
            if (attr      == "") errorMes = "Ошибка. Не определен атрибут в запросе " + queryName;     
            if (errorMes != "")
            {
                sys.SM(errorMes);
                return;
            }
        	for (int i = 0; i < RefCount; i++)
        	{
    		    if (Ref[i, iQueryName] == "") continue;              
                if (Ref[i, iAttr]      == "") continue;
                for (int j = 0; j < iValueSave; j++)
                {
                	Ref[i, j] = "";
                }
        	}
        }
                                                
        /// <summary>
        /// Дополнительная возможность писать через индекс. Индексатор для возможности писать так: Obj["Main1.Kind"] = "";
        /// где Main1.Kind - это TagStr.
        /// </summary>
        public string this[string tagStr]
        {
            get
            {                
                return GetValue(tagStr);
            }
            set
            {         
                SetValue(tagStr, value);               
            }
        }
                     
        #endregion Region. Установка ObjectRef. (SetQuery)
        
        #region Region. Тестовые методы. Не участвуют в реальной работе.
     
        /// <summary>
        /// Получить таблицы после выполенения запросов.
        /// </summary>
        /// <param name="direction">Запрос к локальной или удалённой базе данных</param>
        /// <param name="ds">DataSet результата запроса к базе данных. Количество таблиц в DataSet равно количеству QueryName.</param>
        public void GetResultTables(DirectionQuery direction, out System.Data.DataSet ds)
        {            
            if (direction  == DirectionQuery.Remote) ds = DSRemote;
                else ds = DSLocal;
        }
             
        /// <summary>
        /// Получить одну первую таблицу после выполенения запросов.
        /// </summary>
        /// <param name="direction">Запрос к локальной или удалённой базе данных</param>
        /// <param name="dt">DataTable - первая таблица в DataSet результата запроса к базе данных</param>
        public void GetResultTableFirst(DirectionQuery direction, out System.Data.DataTable dt)
        {           
            if (direction == DirectionQuery.Remote) dt = DSRemote.Tables[0];
            	else dt = DSLocal.Tables[0];
        }
              
        /// <summary>
        /// Показ всех созданных массивов. Для отладки.
        /// </summary>
        public void ShowArrayAll()
        { 
            //ShowArray("Ent");
            ShowArray("Ref");
            //ShowArray("Tbl");
        }
              
        /// <summary>
        /// Показ созданного массива. Для отладки. 
        /// </summary>
        /// <param name="arrayName">Имя массива Ent, Ref</param>
        public void ShowArray(string arrayName)
        {
            //Показ массива Ent.
            if (arrayName == "Ent")
            {               
                Arr.ArrayView(arrayName, "0.nPos;1.nTypeAction;2.nDirection;3.nEntityBrief;4.nEntityID;5.nQueryName;6.nTableName;7.nIDFieldName;" + 
                    "8.nLanguage;9.nDirect;10.nNeedSave;11.nObjectID;12.nStateDate;13.nPosLocal;14.nPosRemote;15.nSelectMSQL;" + 
                    "16.nSelect;17.nUpdate;18.nInsert;19.nDelete;20.InsertFirst;21.nNewObject;22.nDirty", Ent);
            }
            
            //Показ массива Ref.
            if (arrayName == "Ref")
            {                  
                //Константы для массива Ref.                                                                     
                Arr.ArrayView(arrayName,          
                    "0.iPos;1.TypeAction;2.iName;3.iTypeControl;4.iTag;5.iQueryName;6.iAttr;7.iAttrLookup;8.iEnt;9.iEntityBrief;10.iEntityID;11.iObjectID;" +
                    "12.iStateDate;13.iTableName;" +
                    "14.iTableType;15.iFieldName;16.iFieldName2;17.iIDFieldName;18.iPosLocal;19.iPosRemote;20.iSetting;21.iValueOld;22.iValueNew;23.iValueNewID;24.iSaveType;25.iNeedSave;26.iNumLevel;27.iValueSave;", Ref); 
            }  		        
        }

        #endregion Region. Тестовые методы. Не участвуют в реальной работе.     
       
        #region Region. Чтение из БД.
      
        /// <summary>
        /// Получить код для запроса, который будет выполняться при раскрытии выпадающего списка на компоненте EditFBA.
        /// </summary>
        /// <param name="dBEdit">Компонент dBEdit</param>
        /// <returns>Текст запроса для наполнения раскрывающегося списка dBEdit</returns>
        public string GetSelectSQLForEditFBA(EditFBA dBEdit)
        {
            string attrBrief = dBEdit.AttrBrief;
            string entityBrief;
            string entityBriefLink;
            string attrLookup;
            if (!GetLinkEntityBrief(attrBrief, out entityBrief, out entityBriefLink, out attrLookup)) return "";
            //Если EntityBriefLink == "" и AttrLookup == ""  значит AttrBrief - это не ссылка.
            //Если не ссылка, то формируем просто вывод значений этого атрибута из сущности, в которой находится этот атрибут.
            if (entityBriefLink == "") return "";          
            if (attrLookup == "") return "";
            string value = dBEdit.Text;
            string maxRecords1 = "";
            string maxRecords2 = "";
            if (dBEdit.ObjectMaxCount > 0)
			{
				if (Var.con.serverTypeRemote == ServerType.MSSQL) 
					maxRecords1 = " TOP " + dBEdit.ObjectMaxCount.ToString();	          
				if ((Var.con.serverTypeRemote == ServerType.SQLite) || (Var.con.serverTypeRemote == ServerType.Postgre))	             
	            	maxRecords2 = Var.CR + " LIMIT " + dBEdit.ObjectMaxCount.ToString();	           
			} 
            string msql = "SELECT " + maxRecords1 + ParserData.KeyBrief.ObjectID + " AS ID, " + attrLookup + " FROM " + entityBriefLink + " WHERE " + attrLookup + " IS NOT NULL ";                                             
            if (!sys.IsEmpty(dBEdit.OuterWHERE)) msql = msql + " AND " + dBEdit.OuterWHERE;            
            msql = msql + maxRecords2;            
            if (!sys.IsEmpty(dBEdit.ObjectOrderBy))  msql = msql + " ORDER BY " + dBEdit.ObjectOrderBy;
            string sql = sys.Parse(msql);
            dBEdit.SQL  = sql;
            dBEdit.MSQL = msql;
            return sql;
        }
        
        /// <summary>
        /// Получить сокращение сущности, на которую ссылается атрибут AttrBrief. 
        /// </summary>
        /// <param name="attrBrief"></param>
        /// <param name="entityBrief">Сущность в котрой находится атрибут AttrBrief</param>
        /// <param name="entityBriefLookup">Сущность, на которую указывает атрибут AttrBrief</param>
        /// <param name="attrLookup">какой атрибут показывать из сущности EntityBriefLookup</param>
        /// <returns>Если сущноссть найдена, то true</returns>
        public bool GetLinkEntityBrief(string attrBrief, out string entityBrief, out string entityBriefLookup, out string attrLookup)
        {       
            entityBrief       = "";
            entityBriefLookup = "";
            string queryName;
            string attr;           
            string setting;
            //Выясняем сущность атрибута по Ent.
            sys.ParseTag(attrBrief, out queryName, out attr, out attrLookup, out setting);
            if (queryName == "") return false;
            if (attr == "") return false;     
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nQueryName] != queryName) continue;
                entityBrief = Ent[i, nEntityBrief];
                break;
            }
            if (entityBrief == "") return false;
            entityBriefLookup = sys.GetEntityBriefLink(entityBrief, attr);

            if (entityBriefLookup == "")
            {
                entityBriefLookup = entityBrief;
                attrLookup = attr;
            }
            return true;
        }
    
		/// <summary>
		/// Чтение значений из БД. Основная процедура чтения. Сдледует вызывать после заполнения QueryName методами SetQueryTable, SetQueryEntity, SetQueryDirect.
		/// </summary>
		/// <returns></returns>
        public bool Read()
        {                                              
            if (form != null) GetControlsText(form.Controls, true); //Перебор всех контролов на форме, и запись в массив Ref.             
            FillRefFromEnt();
            FillTablesFromAttrParent();
            formWasRead = true;
            CreateSelect();             
            //ShowArrayAll(); //Тест   
            if (!SendSelect()) return false;          
            SetControlsValueFromDS();   
            if (form != null) SetControlsText(form.Controls);                
            return true;
        }                                                       
      
		/// <summary>
		/// Определение, был ли успешно найден объект в БД при чтении. 
		/// </summary>
		/// <param name="queryName">Имя запроса</param>
		/// <returns>Если объект был наден в базе данных при чтении, то true.</returns>
        public bool ObjectFound(string queryName)
        {
        	for (int i = 0; i < EntCount; i++) 
        	{
        		if (Ent[i, nQueryName] != queryName) continue;
        		if (Ent[i, nIDWasFindInDB] == "1") return true;
        		return false;        
        	}
        	return false;
        }
               
		/// <summary>
		/// Перебор всех контролов на форме, и запись в массив Ref.
		/// setOldvalue - если true, то присваивается значение Ref[RefCount, iValueOld] = Ref[RefCount, iValueNew]  
		/// </summary>
		/// <param name="controls">Коллекция компонентов формы</param>
		/// <param name="setOldvalue">Устанавливать строе значение для найденного компонента</param>
        private void GetControlsText(Control.ControlCollection controls, bool setOldvalue)
        {    
            foreach(Control control in controls)
            {                      
                GetControlsText(control.Controls, setOldvalue);                                           
                //Пример формата строки в Tag: Main.СтрахПолис.Номер;Save
                //Где Main - это запись в Ent
                //СтрахПолис.Номер - атрибут
                //Save - признак, что этот компонент нужно сохранять/загружать в настройках. Настройки - таблица fbaSetting.
                //Save может отсутствовать, как и знак ; перед ним.                                 
                string attrBrief  = "";                                                   
                string compTypeBasic = control.GetType().ToString();
                string compType = sys.TruncateType(compTypeBasic, false);
                
                if (compType == "TextBoxFBA")                 attrBrief = ((TextBoxFBA)control).AttrBrief;
                if (compType == "EditFBA")
                {
                    attrBrief = ((EditFBA)control).AttrBrief;
                    ((EditFBA)control).ObjRef = this;
                }
                else if (compType == "ComboBoxFBA")           attrBrief = ((ComboBoxFBA)control).AttrBrief;
                else if (compType == "CheckBoxFBA")           attrBrief = ((CheckBoxFBA)control).AttrBrief;
                else if (compType == "RadioButtonFBA")        attrBrief = ((RadioButtonFBA)control).AttrBrief;
                else if (compType == "TabControlFBA")         attrBrief = ((TabControlFBA)control).AttrBrief;
                else if (compType == "FastColoredTextBoxFBA") attrBrief = ((FastColoredTextBoxFBA)control).AttrBrief;
                else if (compType == "DateTimePickerFBA")     attrBrief = ((DateTimePickerFBA)control).AttrBrief;
                if (((sys.IsEmpty(attrBrief))) && (control.Tag != null)) attrBrief = control.Tag.ToString();
                if (attrBrief == "") continue;
                
                string queryName;
                string attr;
                string attrLookup;
                string setting;
                string saveType = "";
                sys.ParseTag(attrBrief, out queryName, out attr, out attrLookup, out setting);
                
                //Попытка распарсить свойство Tag. В нем тоже можно указать AttrBrief.
                if ((queryName == "") || (attr == "")) continue;                                            
                                
                string value   = control.Text;
                //string ValueID = "";
                if (compType == "ComboBoxFBA")
                {
                    saveType = ((ComboBoxFBA)control).SaveType;
                    if (attrLookup != "")    saveType = "LOOKUP";
                    if (sys.IsEmpty(saveType))  saveType = "TEXT";
                    //ValueID = "";
                    //if (SaveType == "INDEX")  ValueID = ""; // ((ComboBoxFBA)control).SelectedIndex.ToString();
                    //if (SaveType == "TEXT")   ValueID = ""; //Если SaveType == "TEXT", то тут всегдп пусто.
                    //if (SaveType == "LOOKUP") ValueID = ""; //Ещё не выполнен запрос на чтение к БД, поэтому тут пока пусто.
                }
                if (compType == "EditFBA")
                {
                    saveType = ((EditFBA)control).SaveType;
                    if (attrLookup != "")    saveType = "LOOKUP";
                    if (sys.IsEmpty(saveType))  saveType = "TEXT";
                    if (saveType == "INDEX")  value   = ((EditFBA)control).Index.ToString();
                    //if (SaveType == "TEXT")   ValueID = ""; //Если SaveType == "TEXT", то тут всегда пусто.
                    //if (SaveType == "LOOKUP") ValueID = ""; //Ещё не выполнен запрос на чтение к БД, поэтому тут пока пусто.
                }
                if (compType == "DateTimePickerFBA")
                {
                    if (((DateTimePickerFBA)control).Value == Var.MinStateDate) value = "";
                    else value = sys.DateTimeToSQLStr(((DateTimePickerFBA)control).Value, false);  
                }
                if (sys.IsEmpty(saveType)) saveType = "TEXT";

                Ref[RefCount, iPos]         = RefCount.ToString();
                Ref[RefCount, iTypeAction]  = "";
                Ref[RefCount, iName]        = control.Name;                      
                Ref[RefCount, iTypeControl] = control.GetType().ToString().Replace("FBA.", "");
                if (control.Tag != null) Ref[RefCount, iTag] = control.Tag.ToString();
                Ref[RefCount, iQueryName]   = queryName;
                Ref[RefCount, iAttr]        = attr;
                Ref[RefCount, iAttrLookup]  = attrLookup;
                Ref[RefCount, iEnt]         = ""; //На этот момент Ent ещё не известен. 
                Ref[RefCount, iEntityBrief] = "";
                Ref[RefCount, iEntityID]    = "";                      
                Ref[RefCount, iObjectID]    = "";
                Ref[RefCount, iStateDate]   = "";                     
                Ref[RefCount, iTableName]   = "";
                Ref[RefCount, iTableType]   = "";                     
                Ref[RefCount, iFieldName]   = ""; 
                Ref[RefCount, iIDFieldName] = "";                             
                Ref[RefCount, iPosLocal]    = ""; //На этот момент PosLocal ещё не известен.  
                Ref[RefCount, iPosRemote]   = ""; //На этот момент PosRemote ещё не известен. 
                Ref[RefCount, iSetting]     = ""; 
                
                //При добавлении нового объекта, нужно чтобы старые значения были пустые.
                if (setOldvalue) Ref[RefCount, iValueOld]    = value;
                
                Ref[RefCount, iValueNew]    = value;               
                Ref[RefCount, iValueNewID]  = ""; //ValueID;
                Ref[RefCount, iSaveType]    = saveType;
                Ref[RefCount, iNeedSave]    = "1";
                Ref[RefCount, iValueSave]   = ""; 
                RefCount++;                              
            }                    
        }
            
		/// <summary>
		/// Перебор всех контролов на форме, и запись в свойство Text значения из массива Ref.    
		/// Если хотя бы значение одного компонента изменилось, то вернёт true. 
		/// </summary>
		/// <param name="controls">Коллекция компонентов формы</param>
		/// <returns>Если успешно, то true</returns>
        private bool SetControlsText(Control.ControlCollection controls)
        {    
        	bool result = false;
        	//Цикл по массиву компонентов.
            foreach(Control control in controls)
            {                      
                SetControlsText(control.Controls);                                                                                                
                for (int i = 0; i < RefCount; i++)
                {
                    if (Ref[i, iQueryName] == "") continue;
                	if (Ref[i, iName] != control.Name) continue;
                    if (Ref[i, iEnt]       == "") continue;                    
                    if (Ref[i, iAttr]      == "") continue;
                    string compType = control.GetType().ToString(); 
                    compType = sys.TruncateType(compType, false);                    
                    if (compType == "ComboBoxFBA")
                    {
                        //if (((ComboBoxFBA)control).SaveType == "INDEX") ((ComboBoxFBA)control).SelectedIndex = Ref[i, iValueOld].ToInt();
                        //else control.Text = Ref[i, iValueOld];  
                        if (Ref[i, iSaveType] == "INDEX") ((ComboBoxFBA)control).SelectedIndex = Ref[i, iValueOld].ToInt();
                        else 
                        {
                        	control.Text = Ref[i, iValueOld];
                        	result = true;
                        }

                    } else
                    if (compType == "EditFBA")
                    {
                        if (Ref[i, iSaveType] == "INDEX") ((EditFBA)control).Index = Ref[i, iValueOld].ToInt();
                        else 
                        {
                        	control.Text = Ref[i, iValueOld];
                        	result = true;
                        }
                    }
                    if (compType == "DateTimePickerFBA")
                    {
                        string DateValue = Ref[i, iValueOld].Replace("'", "");
                        if (!DateValue.IsDate())
                        {
                            //sys.SM("Ошибка чтения из базы атрибута " + Ref[i, iAttr] + Var.CR + 
                            //       "Указанное значение не является датой: " + Ref[i, iValueOld]);
                        }
                        else
                        {
                            const string formatDate = "yyyy-MM-dd HH:mm:ss"; 
                            ((DateTimePickerFBA)control).Value = DateTime.ParseExact(DateValue, formatDate, null);
                        }                                                 
                    }                  
                    else 
                    {
                    	control.Text = Ref[i, iValueOld];
                    	result = true;
                    }
                     
                    //После установки свойства Text присваивем событие.
                    //control.TextChanged += ControlValueChanged;                        
                }                                    
            } 
            return result;
        }  
        
        /// <summary>
        /// Заполяем список таблиц из Ent (для удобства).
        /// </summary>
        private void FillRefFromEnt()
        { 
            int posLocal   = 0;
            int posRemote  = 0;
            for (int i = 0; i < EntCount; i++)
            {                                                                  
            	if (Ent[i, nDirection] == DirectionQuery.Local.ToString())
                {
                    Ent[i, nPosLocal] = posLocal.ToString();
                    posLocal++;
                }
                if (Ent[i, nDirection] == DirectionQuery.Remote.ToString())
                {
                    Ent[i, nPosRemote] = posRemote.ToString();
                    posRemote++;
                }            
                                   
                for (int j = 0; j < RefCount; j++)
                {                     
                    if (Ref[j, iQueryName] != Ent[i, nQueryName]) continue; 
                    Ref[j, iEnt]         = i.ToString();                  
                    Ref[j, iPosLocal]    = Ent[i, nPosLocal];
                    Ref[j, iPosRemote]   = Ent[i, nPosRemote];
                    Ref[j, iEntityBrief] = Ent[i, nEntityBrief];
                    Ref[j, iEntityID]    = Ent[i, nEntityID];
                    Ref[j, iTypeAction]  = Ent[i, nTypeEnt];  
                    Ref[j, iTableName]   = Ent[i, nTableName];                      
                    Ref[j, iIDFieldName] = Ent[i, nIDFieldName]; 
                    Ref[j, iObjectID]    = Ent[i, nObjectID];
                    Ref[j, iStateDate]   = Ent[i, nStateDate];  				               
                }
            }
        }                
           
        /// <summary>
        /// Заполняем список таблиц.
        /// </summary>
        private void FillTablesFromAttrParent()
        {                      
            //Проставляем имя, тип таблицы для каждого атрибута.
            for (int i = 0; i < RefCount; i++)
            {
                
                string entityBrief = Ref[i, iEntityBrief];
                string attr        = Ref[i, iAttr]; 
                string typeAction  = Ref[i, iTypeAction]; 
                if (typeAction != ObjectRefType.Entity.ToString()) continue;
                if (entityBrief == "") continue;
                if (attr        == "") continue;
                
                for (int j = 0; j < ParserData.ArAttrParentY; j++)
                {
                    if (ParserData.ArAttrParent[j, ParserData.aEnBrief2] != entityBrief) continue;
                    if (ParserData.ArAttrParent[j, ParserData.aAttr_Brief]       != attr)        continue;                    
                    Ref[i, iEntityID]    = ParserData.ArAttrParent[j, ParserData.aAttr_EntityID];
                    Ref[i, iTableName]   = ParserData.ArAttrParent[j, ParserData.aTable_Name];
                    Ref[i, iTableType]   = ParserData.ArAttrParent[j, ParserData.aTable_Type];
                    Ref[i, iNumLevel]    = ParserData.ArAttrParent[j, ParserData.aNumLevel];
                    Ref[i, iIDFieldName] = ParserData.ArAttrParent[j, ParserData.aTable_IDFieldName];
                    Ref[i, iFieldName]   = ParserData.ArAttrParent[j, ParserData.aTable_Field];
                    Ref[i, iFieldName2]  = ParserData.ArAttrParent[j, ParserData.aTable_Field2];
				    
                    //Это для того чтобы все значения всех историчных таблиц, записывались в конце. 
                    //Причем неважно к какой сущности относится историчная таблица. К клавной или дочерней. Поэтому ставим 0.
                    //Запись будет идти от большего к меньшему. 0 - обработается в самом конце.
                    //if (Ref[i, iTableType] == "Hist") Ref[i, iNumLevel]    = "0";
                    //else 
                    Ref[i, iNumLevel]    = ParserData.ArAttrParent[j, ParserData.aNumLevel];
                }
            }
        }               
                                           
        /// <summary>
        /// Создаем запросы SELECT для чтения всех значений из БД.
        /// </summary>
        private void CreateSelect()
        {                                                                                                 
            for (int i = 0; i < EntCount; i++)
            {                           
                string typeAction  = Ent[i, nTypeEnt];
                string objectID    = Ent[i, nObjectID];
                string entityBrief = Ent[i, nEntityBrief];                     
                string tableName   = Ent[i, nTableName];
                string idFieldName = Ent[i, nIDFieldName];
                string stateDate   = Ent[i, nStateDate];
                string sql         = "";              
                string attr        = ""; 
                            
                //Если запрос уже есть, то ничего делать больше не нужно.
                if (typeAction == ObjectRefType.Direct.ToString()) 
                {
                	if (Ent[i, nLanguage] == SQLLang.MSQL.ToString())
                    {
                        //if (parser == null) parser = new Parser();                        
                        sql = sys.Parse(Ent[i, nSelect]);  
                        Ent[i, nSelect] = sql;
                    }
                    continue;
                }                                            
                
                if (objectID == "") return;
                if (objectID == "0") return;
                
                //ShowArray("Ref");
                string objectStateDate = ""; //Ищем первый попавшийся историчный атрибут.
                for (int j = 0; j < RefCount; j++)
                {                     
                    if (Ref[j, iEnt] == "") continue;
                    if (Ref[j, iQueryName] != Ent[i, nQueryName]) continue;                                                                 
                    if (attr != "") attr += ", ";                                     
                    attr      += Ref[j, iAttr];  
                    if ((Ref[j, iAttrLookup]) != "") attr += "." + Ref[j, iAttrLookup];     
	 				
                    //FirstHistAttr нужен для того, чтобы установить StateDate, если она не задана прикладным программистом.
	                //как показала практика, то иметь несколько историчных таблиц в сущности неудобно.
	                //Поэтому как правило будет одна историчная таблица. Для таких случаем это будет работать.
	                //Поэтому мы можем вытащить поле StateDate с помощью парсера. 
	                //Для этого нужно добавить в список запрашиваемых атрибутов какой либо истричный атрибут с ДатаСостАтрибута. Или AttrStateDate.
					//Пример SELECT ДатаНачала, ДатаНачала.AttrStateDate FROM Документ.  
					//Если у нас нет ни одного запрашиваемого историчного атрибута, то облом. Автоматически StateDate у объекта мы определить не можем.				
					//if ((Ref[j, iQueryName]) 
					if ((Ref[j, iTableType] == "Hist") && (objectStateDate == "") && (stateDate == ""))
					{
						objectStateDate = Ref[j, iAttr] + ".AttrStateDate";      //Ref[i, iTableName]					
					}                      
                }                  
                
                if (objectStateDate != "")
                {
	                if (attr != "") attr += ", ";     
	                attr += objectStateDate; //Последний атрибут FirstHistAttr - это историчное состояние объекта.
                }
                //Это запрос к простой таблице.
                if ((typeAction == ObjectRefType.Table.ToString()) && (tableName != "") && (idFieldName != "") && (objectID != ""))
                {                                                                            
                    sql = "SELECT " + attr + " FROM " + tableName + " WHERE " + idFieldName + " = " + objectID;
                    if (stateDate != "") sql = sql + " AND StateDate = (SELECT MAX(StateDate) FROM " + tableName + " WHERE " + idFieldName + " = " + objectID + " AND StateDate <= '" + stateDate + "') ";
                    sql += ";";
                }
                
                //Это запрос на MSQL. 
                if ((typeAction == ObjectRefType.Entity.ToString()) && (entityBrief != "") && (attr != "") && (objectID != ""))
                {
                    sql = "SELECT " + attr + " FROM " + entityBrief;
                    if (!sys.IsEmptyID(objectID)) sql = sql + " WHERE " + ParserData.KeyBrief.ObjectID + " = " + objectID;
                      if (stateDate != "") sql = sql + " AND " + ParserData.KeyBrief.ObjectStateDate + " = '" + stateDate + "' ";                                 
                      sql = sys.Parse(sql); //Конвертируем в SQL.
                }                      
                Ent[i, nSelect] += sql;
            } 
        }
                    
        /// <summary>
        /// Сборка всех запросов.
        /// </summary>
        /// <param name="direction">Запрос к локальной или удалённой базе данных для чтения Read()</param>
        /// <returns>На выходе текст всех запросов select</returns>
        private string CollectSelect(DirectionQuery direction)
        {                        
            string sql = "";
            for (int i = 0; i < EntCount; i++)
            {
            	if (Ent[i, nDirection] != direction.ToString()) continue;
                if (Ent[i, nQueryName] == "") continue;
                if (Ent[i, nSelect] == "") continue;   
                sql += "/*" + i + "." + Ent[i, nQueryName] + "*/ " + Var.CR + Ent[i, nSelect] + Var.CR;
            } 
            return sql;
        }  
 
        /// <summary>
        /// Посылка запросов к БД.
        /// </summary>
        /// <returns>Если ошибок нет при выполнениии Select, то true</returns>
        private bool SendSelect()
        {
            localSQL  = CollectSelect(DirectionQuery.Local);
            remoteSQL = CollectSelect(DirectionQuery.Remote); 
            if (localSQL != "")
                if (!sys.SelectDS(DirectionQuery.Local,  localSQL,  out DSLocal)) return false;
            if (remoteSQL != "")
                if (!sys.SelectDS(DirectionQuery.Remote, remoteSQL, out DSRemote)) return false;
            return true;                    
        }       
                                    
        /// <summary>
        /// Заполнение свойств компонентов в массиве Ref значениями из DataTable после выполняния чтения из БД.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private bool SetControlsValueFromDS()
        {
            if (DSRemote.Tables.Count != EntCount)  return false;
            if (DSRemote.Tables.Count == 0)         return false;
            if (DSRemote.Tables[0].Rows.Count == 0) return false;

            //Цикл по таблицам.
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nObjectID] == "0") continue;

                int n = 0;
                //Цикл по массиву компонентов.
                for (int j = 0; j < RefCount; j++)
                {
                    if (Ref[j, iPosRemote] != i.ToString()) continue;
                    if (sys.IsEmpty(Ref[j, iEnt])) continue;
                    if (sys.IsEmpty(Ref[j, iQueryName])) continue;
                    if (sys.IsEmpty(Ref[j, iAttr])) continue;
                    if (Ent[i, nQueryName] != Ref[j, iQueryName]) continue;
                    if (DSRemote.Tables[i].Columns.Count <= n) break;
                    string valueOld = DSRemote.Tables[i].Rows[0][n].ToString();

                    if (Ref[j, iTypeControl] == "DateTimePickerFBA")
                    {
                        if (sys.IsDate(DSRemote.Tables[i].Rows[0][n].ToString()))                           
                        {
                            //System.DateTime dt = (System.DateTime)DSRemote.Tables[i].Rows[0][N];
                            //if (dt != Var.MinStateDate) ValueOld = sys.DateTimeToSQLStr(dt, false);

                            if (DSRemote.Tables[i].Rows[0][n].GetType().ToString() == "System.DateTime")
                            {
                                //System.DateTime dt = (System.DateTime)DSRemote.Tables[i].Rows[0][N];
                                //if (dt != Var.MinStateDate)
                                    valueOld = ((System.DateTime)DSRemote.Tables[i].Rows[0][n]).ToString("yyyy-MM-dd HH:mm:ss");
                            }                            
                        }
                    }
                    Ref[j, iValueOld] = valueOld;
                    Ref[j, iValueNew] = valueOld; 					
                    Ent[i, nIDWasFindInDB] = "1";                   
                    n++;
                    //ValueOld - это то значение которое прочитано в момент поднятия формы свойств объекта.
                    //ValueNew - это значение, которое будет изменено самим пользователем вручную.
                }
                
                if (DSRemote.Tables[i].Columns.Count > n) 
                { 
                	string objectStateDate = "";
                	string stateDate = DSRemote.Tables[i].Rows[0][n].ToString();
                	DateTime dt = sys.StringToDateTime(stateDate);
                	//if (stateDate == null) return false;
                	// StringToDateTime(string value)
                	//if (!stateDate.IsDate(stateDate)) return false;                	
                	objectStateDate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                	//sys.DateTimeConvertStr(ref ObjectStateDate, "dd.mm.yyyy HH:mm:ss", "yyyy-mm-dd HH:mm:ss");
                	SetStateDate(Ent[i, nQueryName], objectStateDate);
                }
                
            }
            return true;
        }
        
        #endregion Region. Чтение из БД.           

        #region Region. Запись в БД.                

        /// <summary>
        /// Запись значений в БД. Возможна запись определенного QueryName или всех. Запись как INSERT так и UPDATE.
        /// Если QueryName не указано, то производится запись всех QueryName. 
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Если запись прошла без ошибок, то true</returns>
        public bool Write(string queryName = "")
        {
        	if (!formWasRead)
        	{
	        	GetControlsText(form.Controls, false); //Перебор всех контролов на форме, и запись в массив Ref.             
	            FillRefFromEnt();
	            FillTablesFromAttrParent();
        	}
            
        	//ShowArray("Ref");            
            SetValueNew(form.Controls);

            if (!IsDirty(queryName)) return false;
            //Запись только определенного QueryName.
            if (queryName != "")
            {
                PrepareQuery(SQLCommand.Auto, queryName);
                bool result = Send_UPDATE_INSERT_DELETE(SQLCommand.Auto, queryName);
                if (result) 
                {
                	SetDirty(queryName, false);                	     
                }                               
                return result;
            }                               
            
            //Запись всех QueryName.      
            int savecount = 0;
        	for (int i = 0; i < EntCount; i++)        
            {
                queryName = Ent[i, nQueryName];
                PrepareQuery(SQLCommand.Auto, queryName);
                bool result = Send_UPDATE_INSERT_DELETE(SQLCommand.Auto, queryName);  
				if (result) 
				{
					SetDirty(queryName, false);
					savecount++;
				}
            }         	
        	return (savecount > 0);
        }
        
		/// <summary>
		/// Перебор всех контролов на форме, и запись в iValueNew или в iValueNewID значения из массива Ref. 
		/// </summary>
		/// <param name="controls">Коллекция компонентов формы</param>
        private void SetValueNew(Control.ControlCollection controls)
        {            
            //Цикл по массиву компонентов.
            foreach (Control control in controls)
            {
                SetValueNew(control.Controls);
                for (int i = 0; i < RefCount; i++)
                {
                    if (Ref[i, iName] == "Virtual")
                    {                       
                    	if (Ref[i, iValueNew] != Ref[i, iValueOld]) SetDirty(Ref[i, iQueryName], true);
                        continue;
                    }
                	
                	if (Ref[i, iName]      != control.Name) continue;
                    if (Ref[i, iEnt]       == "") continue;
                    if (Ref[i, iQueryName] == "") continue;
                    //if (Ref[i, iQueryName] != QueryName) continue;
                    if (Ref[i, iAttr]      == "") continue;
                                                                              
                    string compType = control.GetType().ToString();
                    compType = sys.TruncateType(compType, false);
                    if (compType == "ComboBoxFBA")
                    {
                        //1. TEXT:   Отображение и запись текстового значения из combobox1. Отображаем и записываем текст из combobox1.
                        //1. INDEX:  Оторбажение текстового значения из списка, заранее определенного в свойстве Items. А запись свойства SelectedIndex. В этом случае iValueNewID должно быть заполнено. 
                        //if (((ComboBoxFBA)control).SaveType == "INDEX") Ref[i, iValueNew] = ((ComboBoxFBA)control).SelectedIndex.ToString();                                                  
                        if (Ref[i, iSaveType] == "INDEX")
                        {
                            Ref[i, iValueNewID] = ((ComboBoxFBA)control).SelectedIndex.ToString();
                            if (Ref[i, iValueNewID] != Ref[i, iValueOld]) SetDirty(Ref[i, iQueryName], true);
                        }
                        else
                        {
                            Ref[i, iValueNew] = control.Text;
                            if (Ref[i, iValueNew] != Ref[i, iValueOld]) SetDirty(Ref[i, iQueryName], true);
                        }
                    }
                    else
                    if (compType == "EditFBA")
                    {
                        //Разные режимы работы EditFBA:
                        //1. TEXT:   Отображение и запись текстового значения из combobox1. Отображаем и записываем текст из combobox1.
                        //2. INDEX:  Оторбажение текстового значения из списка, заранее определенного в свойстве Items. А запись свойства SelectedIndex. В этом случае iValueNewID должно быть заполнено. 
                        //3. LOOKUP: Отображение значения атрибута по ссылке. В этом случае iValueNewID должно быть заполнено. Отображаем текст, а записываем, то что в iValueNewID. 
                        if (Ref[i, iSaveType] == "INDEX")
                        {
                            Ref[i, iValueNewID] = ((EditFBA)control).Index.ToString();
                            if (Ref[i, iValueNewID] != Ref[i, iValueOld]) SetDirty(Ref[i, iQueryName], true);
                        }
                        else
                        if (Ref[i, iSaveType] == "LOOKUP")
                        {
                            Ref[i, iValueNewID] = ((EditFBA)control).ObjectID;
                            if (!sys.IsEmpty(Ref[i, iValueNewID])) SetDirty(Ref[i, iQueryName], true);
                        }
                        else
                        if (Ref[i, iSaveType] == "TEXT")
                        {
                            Ref[i, iValueNew] = control.Text;
                            if (Ref[i, iValueNew] != Ref[i, iValueOld]) SetDirty(Ref[i, iQueryName], true);
                        }
                    }
                    else
                    if (compType == "DateTimePickerFBA")
                    {
                        Ref[i, iValueNew] = sys.DateTimeToSQLStr(((DateTimePickerFBA)control).Value, false);
                        if (Ref[i, iValueOld] != Ref[i, iValueNew]) SetDirty(Ref[i, iQueryName], true);
                    }
                    else
                    {
                        Ref[i, iValueNew] = control.Text;
                        if (Ref[i, iValueOld] != Ref[i, iValueNew]) SetDirty(Ref[i, iQueryName], true);
                    }
                    //После установки свойства Text присваивем событие.
                    //control.TextChanged += ControlValueChanged;                        
                }
            }
        }            
               
        /// <summary>
        /// Удаление объекта по QueryName.
        /// </summary>
        /// <param name="queryName"></param>
        /// <returns>Если объект удалён из базы данных, то true</returns>
        public bool DeleteObject(string queryName = "")
        {                   
        	PrepareQuery(SQLCommand.Delete, queryName);
            return Send_UPDATE_INSERT_DELETE(SQLCommand.Delete, queryName);        	       
        }
      
        /// <summary>
        /// Удаление объекта без его чтения по сокращению сущности и ID объекта.
        /// </summary>
        /// <param name="direction">Запрос к локальной или удалённой базе данных</param>
        /// <param name="entityBrief">Сокращение сущности объекта</param>
        /// <param name="objectID">ИД Объекта</param>
        /// <returns>Если успешно, то true</returns>
        public bool DeleteObject(DirectionQuery direction, string entityBrief, string objectID)
        {       
        	string sqlUpdateAll = "";
		    string sqlInsertAll = "";
		    string sqlDeleteAll = "";
		    		  
        	if (SaveObjectAtClient) 
        	{    	    	
        		EntityQuery_UPDATE_INSERT_DELETE_Client2(SQLCommand.Delete, "", entityBrief, "", objectID, 0, out sqlUpdateAll, out sqlInsertAll, out sqlDeleteAll);
        	}
        	else sqlDeleteAll = "EXEC spen_SaveObject 1, 'DELETE', " + objectID + ", '" + entityBrief + "',  '19000101 00:00:00.000'";    	            	        		   	    		  		    
		    return sys.Exec(direction, sqlDeleteAll);             
        }                            
        
        /// <summary>
        /// Удаление нескольких объектов без их чтения по сокращению сущности и ID объекта.
        /// </summary>
        /// <param name="direction">Запрос к локальной или удалённой базе данных</param>
        /// <param name="entityBrief"></param>
        /// <param name="arrID">Массив ИД объектов, котрые нужно удалить</param>
        /// <returns>Если успешно, то true</returns>
        public bool DeleteObject(DirectionQuery direction, string entityBrief, string[] arrID)
        {               	
        	int countDeleted = 0;
            string objectCaption = "";
        	var progress1 = new FormProgress("Deleting", "Deletion of objects." + entityBrief, arrID.Length);            
        	for (int i = 0; i < arrID.Length; i++)
            {
                objectCaption = "'" + entityBrief + "'. Object ID " + arrID[i];     
	        	DeleteObject(direction, entityBrief, arrID[i]);
                countDeleted++;                
                progress1.Inc();
            }
            progress1.Dispose();

            if (countDeleted == arrID.Length)
            {            	
                objectCaption = "Аll objects " + entityBrief + " have been deleted. Total: " + countDeleted;
                sys.SM(objectCaption, MessageType.Information);
            }
            if (countDeleted < arrID.Length)
            {
                objectCaption = "Objects " + entityBrief + " have been deleted. Total: " + countDeleted + " from " + arrID.Length.ToString();
                sys.SM(objectCaption, MessageType.Warning);
            }
            if (countDeleted == 0)
            {
                objectCaption = "Objects " + entityBrief + " were not deleted.";
                sys.SM(objectCaption);
            }   
            return (countDeleted == arrID.Length);
        }            
        
        /// <summary>
        /// Установка вручную свойства одного компонента. Пример использования: SetValue("Main.Полис", "3137294");
        /// </summary>
        /// <param name="tagStr">Полный путь атрибута. Пример: Main1.Договор.Номер</param>
        /// <param name="value">Значние атрибута, которое нужно установить</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetValue(string tagStr, string value)
        {
            //ShowArray("Ref");
            string queryName;
            string attr;
            string attrLookup;
            string setting;
            string errorMes = "Ошибка установки свойства: " + tagStr + " Устанавливаемое значение: " + value;
            sys.ParseTag(tagStr, out queryName, out attr, out attrLookup, out setting);
            for (int i = 0; i < RefCount; i++)
            {            
            	if ((Ref[i, iQueryName] == queryName) && (Ref[i, iAttr] == attr))
                {
                   
                	Control control = form.Controls.Find(Ref[i, iName], true).FirstOrDefault();
                    if (control != null) 
                    {
                        //sys.SM(ErrorMes);
                        //return false; 
						if (Ref[i, iTypeControl] == "EditFBA")
	                    {
	                        //if (Ref[i, iAttrLookup] != "") Ref[i, iValueNewID] = Value;
	                        if ((Ref[i, iSaveType] == "LOOKUP") || (Ref[i, iSaveType] == "INDEX")) Ref[i, iValueNewID] = value;
	                        else Ref[i, iValueNew] = value;
	                    }
	                    else if (Ref[i, iTypeControl] == "ComboBoxFBA")
	                    {
	                        //if (Ref[i, iAttrLookup] != "") Ref[i, iValueNewID] = Value;
	                        if (Ref[i, iSaveType] == "INDEX") Ref[i, iValueNewID] = value;
	                        else Ref[i, iValueNew] = value;
	                    }                        
                    }                   
                    else Ref[i, iValueNew] = value;

                    SetDirty(queryName, true);
                    //ShowArray("Ref");
                    //control.Text и Value:
                    //В control.Text то что в TextBox, а в Value новое значение ID выбранного атрибута.
                    //И в Ref[i, iValueNew] тоже старое значение именно Text, то значения атрибута по ссылке, а не смого атрибута.
                    return true;                                  
                }
            } 
            sys.SM(errorMes);  
            return false;      
        }                      
                    
        /// <summary>
        /// Получить значение атрибута (поля таблицы)на которое указывает QueryName и Attr. Пример: string MyValue = Obj.GetValue("Main1.ContractName");
        /// Если ValueOld = true, то получить старое значение атрибута, до изменения. 
        /// </summary>
        /// <param name="tagStr">Полный путь атрибута. Пример: Main1.Договор.Номер</param>
        /// <param name="valueOld">Старое значение атрибута. Если true, то получить его.</param>
        /// <returns>Значение атрибута</returns>
        public string GetValue(string tagStr, bool valueOld = false)
        {      
            string queryName;
            string attr;
            string attrLookup;
            string setting;
            sys.ParseTag(tagStr, out queryName, out attr, out attrLookup, out setting);
            for (int i = 0; i < RefCount; i++){ 
                if ((Ref[i, iQueryName] == queryName) && (Ref[i, iAttr] == attr)) 
                {
                	if (valueOld) return Ref[i, iValueOld];
                 	return Ref[i, iValueNew];                	
                }
            }
            return "";
        }
           
        /// <summary>
        /// Восстановление всех изменнных атрибутов. Вызывается SetControlsText.
        /// Перебор всех контролов на форме, и запись в свойство Text значения из массива Ref.    
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public bool RestoreValues()
        {
        	if (form == null) return false;
        	return SetControlsText(form.Controls);
        }      
        
        /// <summary>
        /// Принудительная установка признака Dirty для определенного QueryName.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="dirty">Признак, что объект был изменён</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetDirty(string queryName, bool dirty)
        {
        	bool result = false;
        	for (int i = 0; i < EntCount; i++)
            {
            	if (Ent[i, nQueryName] != queryName) continue;
            	Ent[i, nDirty] = dirty.ToString();   
            	result = true;
            }    
        	
        	//Применяем изменения в Ref.	
        	if (!dirty)
        	{
	    		for (int i = 0; i < RefCount; i++)
	            {
	            	if (Ref[i, iQueryName] != queryName) continue;
	            	Ref[i, iValueOld] = Ref[i, iValueNew];
	            	Ref[i, iValueSave] = "";	            	
    			}
        	}
            return result;          
        }
                    
		/// <summary>
		/// Метод IsDirty, определяет, что какие либо открибуты запроса QueryName были изменены.    
		/// </summary>
		/// <param name="queryName">Имя запроса</param>
		/// <returns>Если объект ещё не был записан в базу данных после его изменения, то true</returns>
        public bool IsDirty(string queryName)
        {            
            SetValueNew(form.Controls);
            if (queryName == "")
            {
            	bool dirty = false;
            	for (int i = 0; i < EntCount; i++)
	            {	            
	            	if (Ent[i, nDirty].ToBool()) dirty = true;
	            }
            	return dirty;
            } else
            for (int i = 0; i < EntCount; i++)
            {
            	if (Ent[i, nQueryName] != queryName) continue;
            	return Ent[i, nDirty].ToBool();            
            }
            return false;                     
        }           
        
        /// <summary>
        /// Получение ObjectID для определенного QueryName.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Имя объекта по имени запроса</returns>
        public string GetObjectID(string queryName)
        {
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nQueryName] == queryName) return Ent[i, nObjectID];
            }            
            return "";
        }
      
        /// <summary>
        /// Присвоение свойства ObjectID для определенного QueryName.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="objectID">ИД объекта</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetObjectID(string queryName, string objectID)
        {
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nQueryName] != queryName) continue;
                Ent[i, nObjectID] = objectID;
                return true;
            }
            sys.SM("Запрос не найден: " + queryName);
            return false;
        }
      
        /// <summary>
        /// Проверка на то, что объект новый.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Если объект новый, и ещё не был записан в базу данных, то true</returns>
        public bool ObjectIsNew(string queryName)
        {
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nQueryName] == queryName)
                {
                    if (Ent[i, nNewObject] == "0") return false;
                    if (Ent[i, nNewObject] == "1") return true;                    
                    if (Ent[i, nNewObject] == "2") return false;                   
                }
            }
            sys.SM("Object not found: " + queryName);
            return false;
        }
      
        /// <summary>
        /// Получение сокращения сущности объъекта.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Cокращение сущности объъекта</returns>
        public string GetObjectEntityBrief(string queryName)
        {
            string entityBrief = "";
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nQueryName] == queryName) entityBrief = Ent[i, nEntityBrief];
            }
            return entityBrief;
        }
             
        /// <summary>
        /// Получение имени объекта по имени запроса
        /// </summary>
        /// <param name="queryName"></param>
        /// <returns>Имя объекта</returns>
        public string GetObjectName(string queryName)
        {
            string entityBrief = GetObjectEntityBrief(queryName);
            string objectID    = GetObjectID(queryName);
            if ((entityBrief == "") || (objectID == "")) return "Object not found";

            if (ObjectIsNew(queryName)) return entityBrief + " New";
            else return entityBrief + " ID " + objectID;
        }
             
        /// <summary>
        /// Присвоение свойства StateDate для определенного QueryName.
        /// Для указанного QueryName установить новую дату состояния. Если QueryName не указано, то дата состояния будет установлена для всех QueryName. 
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="stateDate">Дата состояния, на которую нужно записать объект</param>
        /// <returns>Если успешно, то true</returns>
        public bool SetStateDate(string queryName, string stateDate)
        {
        	bool findEnt = false;
        	bool findRef = false;
        	for (int i = 0; i < EntCount; i++)
            {            
            	if ((queryName != "") && (Ent[i, nQueryName] != queryName)) continue;
                Ent[i, nStateDate] = stateDate; 
                findEnt = true;
            } 
        	for (int i = 0; i < RefCount; i++)
            {            
            	if ((queryName != "") && (Ref[i, iQueryName] != queryName)) continue;
                Ref[i, iStateDate] = stateDate; 
                findRef = true;
            } 
        	
        	if ((findEnt) && (findRef))
        	{
            	SetDirty(queryName, true);
            	return true;
            }         	
                  
            sys.SM("Ошибка поиска запроса " + queryName);
            return false;            
        }           
              
        /// <summary>
        /// Для указанного QueryName получить дату состояния объекта. 
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Дата состояния в тестовом виде объекта из массива Ref</returns>
        public string GetStateDateObject(string queryName)
        {        	
        	for (int i = 0; i < EntCount; i++)
            {            
            	if (Ent[i, nQueryName] != queryName) continue;
            	return Ent[i, nStateDate];
            }         	        	                
            sys.SM("Ошибка поиска запроса " + queryName);
            return "";            
        }  
           
        /// <summary>
        /// Для указанного QueryName получить дату состояния атрибута. 
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="attrBrief">Сокращение атрибута</param>
        /// <returns>Дата состояния в тестовом виде объекта из массива Ref</returns>
        public string GetStateDateAttr(string queryName, string attrBrief)
        {        	
        	for (int i = 0; i < RefCount; i++)
            {            
            	if (Ref[i, iQueryName] != queryName) continue;
            	if (Ref[i, iAttr] != attrBrief) continue;
            	return Ref[i, iStateDate];
            }         	        	                
            sys.SM("Ошибка поиска атрибута. Запрос " + queryName + Var.CR + "Атрибут " + attrBrief);
            return "";            
        }                                         
        
        /// <summary>
        /// Подготовка запросов для обновления БД.
        /// </summary>
        /// <param name="command">Команда из списка. Update, Insert, Delete</param>
        /// <param name="queryName">Имя запроса. Если пустое, то подготовка всех запросов</param>
        private void PrepareQuery(SQLCommand command, string queryName = "")
        {           
        	//ShowArray("Ref");
            //FillRefValueNew();
            //Повторная значений в массив Ref в поле Ref[i, iValueNew]. 
            //Для того чтобы определить, что значение компонента изменилось.
            //if (command != SQLCommand.Delete) CheckControlValueChanged(form.Controls);       
                       
            //1. Этот метод только если данные были прочитаны из таблицы с помощью SetQueryTable
            //Если данные были прочитаны с помощью SetQueryEntity или SetQueryDirect, то ничего не произойдет - такие строки будут проигнорированы в Ref.
            TableQuery_UPDATE_INSERT_DELETE(command, queryName);
            
            //2. Этот метод только если данные были прочитаны из таблицы с помощью SetQueryEntity.
            //Если данные были прочитаны с помощью SetQueryTable или SetQueryDirect, то ничего не произойдет - такие строки будут проигнорированы в Ref.
            EntityQuery_UPDATE_INSERT_Prepare(command, queryName);
            
            //ShowArray("Ref");
            if (!SaveObjectAtClient) EntityQuery_UPDATE_INSERT_DELETE_DataBase(command, queryName); //Если процедура записи находится в БД. span_Save_Object. Только для MSSQL.
            else EntityQuery_UPDATE_INSERT_DELETE_Client1(command, queryName); //Если процедуры записи используются на клиенте.
                        
            //ShowArray("Ent");
            //3. Метода записи, если данные были прочитаны с помощью SetQueryDirect нет. 
        }                   
        
        /// <summary>
        /// Посылка всех запросов. command = "Update" или "Insert" или "Delete". Посылаются все запросы за раз.  
        /// Добавить, обновить, удалить все сущности можно за один раз.
        /// </summary>
        /// <param name="command">Команда из списка. Update, Insert, Delete</param>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Если успешно, то true</returns>
        private bool Send_UPDATE_INSERT_DELETE(SQLCommand command, string queryName)
        {            
        	//То есть, если выборка объектов происходит из нескольких сущностей, то обновить, удалить,
            string sql = "";
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nNeedSave] == "0")       continue; //Если не стоит признак обновления, то не обновляем.               
                if (Ent[i, nTypeEnt]  == ObjectRefType.Direct.ToString())  continue; //Если был произвольный SELECT, то не обновляем.
                if (Ent[i, nQueryName] != queryName) continue;
                if ((Ent[i, nUpdate]  == "") && (Ent[i, nInsert] == "") && (Ent[i, nDelete] == "")) continue;
 
                if (command ==  SQLCommand.Auto)
                {
                	if ((Ent[i, nObjectID] == "0") || (Ent[i, nObjectID] == "")) command = SQLCommand.Insert;
                    else command = SQLCommand.Update;
                }

                if (command == SQLCommand.Update) sql = Ent[i, nUpdate] + Var.CR;
                if (command == SQLCommand.Insert) sql = Ent[i, nInsert] + Var.CR;
                if (command == SQLCommand.Delete) sql = Ent[i, nDelete] + Var.CR;               
                
                sql = "/*" + i + ". command " + command.ToString() + " " + Ent[i, nQueryName] + "*/ " + Var.CR + sql;
                
                //Добавляем запросы Before и After.   
                sql = AddQuery_Bebore_After_In_ResultQuery(queryName, sql);                                        
                //System.Data.DataTable DT;
                DirectionQuery direction;
                if (Ent[i, nDirection] == "Remote") direction = DirectionQuery.Remote;
                else direction = DirectionQuery.Local;
                                
                if (command == SQLCommand.Insert) 
                {
                	 string newObjectID;                               
                     if (!sys.Exec(direction, false, sql, out newObjectID)) return false; //if (!sys.Exec(DirectionQuery.Local, SQL, out ID)) return false;
 					 Ent[i, nObjectID] = newObjectID; //sys.DTValue(DT, "ID");                     
                }                
                if ((command == SQLCommand.Update)  || (command == SQLCommand.Delete))
                {                	                    
                     if (!sys.Exec(direction, sql)) return false;            
                }                                             
            }                   
            return true;
        }                            
        
        #endregion Region. Запись в БД.     
        
        #region Region. Сборка запросов. Table - UPDATE_INSERT_DELETE. 
                  
        /// <summary>
        /// Этот метод только если данные были прочитаны из таблицы с помощью SetQueryTable).
        /// </summary>
        /// <param name="command">Команда из списка. Update, Insert, Delete</param>
        /// <param name="queryName">Имя запроса</param>
        private void TableQuery_UPDATE_INSERT_DELETE(SQLCommand command, string queryName)
        {                            
            //ShowArray("Ref");
            for (int i = 0; i < EntCount; i++)
            {                    
                if (Ent[i, nTypeEnt] != ObjectRefType.Table.ToString()) continue;
                if (Ent[i, nNeedSave]    == "0")    continue;
                if ((queryName != "") && (Ent[i, nQueryName] != queryName)) 
                {
                    Ent[i, nUpdate] = "";
                    Ent[i, nInsert] = "";
                    Ent[i, nDelete] = "";
                    continue;
                }
                
                string sql            = "";
                string UpdateValues   = "";
                string InsertFields   = "";
                string InsertValues   = "";
                string StateDate      = Ent[i, nStateDate];
                string QueryNameLocal = Ent[i, nQueryName];
                
                //command = DELETE  
                if (command == SQLCommand.Delete) 
                {
                    sql = "DELETE FROM " + Ent[i, nTableName] + " WHERE " + Ent[i, nIDFieldName] + " = " + Ent[i, nObjectID] + Var.CR;;
                    if (StateDate != "") sql = sql + " AND StateDate = '" + StateDate + "'";
                    sql += Var.CR;
                    Ent[i, nDelete] = sql;   
                    continue;
                }                
                //command = UPDATE, INSERT.                             
                for (int j = 0; j < RefCount; j++)
                {                    
                    if (Ref[j, iQueryName] != QueryNameLocal) continue;
                    if (Ref[j, iAttr]      == Ref[j, iIDFieldName]) continue; //Поле автоинкремента в таблице игнорируем.
                    if (Ref[j, iValueOld]  == Ref[j, iValueNew]) continue;
                    
                    //Для INSERT.
                    if (InsertFields != "") InsertFields += ", ";
                    if (InsertValues != "") InsertValues += ", ";
                    InsertFields = InsertFields + Ref[j, iAttr];
                    if (Ref[j, iValueNew] == "NULL") InsertValues = InsertValues + Ref[j, iValueNew];     
                    else InsertValues = InsertValues + "'" + Ref[j, iValueNew].QueryQuote() + "'";                                                      
                                  
                    //Для UPDATE.                                 
                    if (UpdateValues != "") UpdateValues += ", ";
                    if (Ref[j, iValueNew] == "NULL") UpdateValues = UpdateValues + Ref[j, iAttr] + " = " + Ref[j, iValueNew].QueryQuote();              
                    else UpdateValues = UpdateValues + Ref[j, iAttr] + " = '" + Ref[j, iValueNew] + "'";                                       
                }                         
                
                //UPDATE             
                if (UpdateValues != "")
                {
                    sql = "UPDATE " + Ent[i, nTableName] + " SET " + UpdateValues + " WHERE " + Ent[i, nIDFieldName] + " = " + Ent[i, nObjectID];
                    if (StateDate != "") sql = sql + " AND StateDate = '" + StateDate + "'";
                    sql += Var.CR;  
                }
                if (sql != "") Ent[i, nUpdate] = sql;
                   
                //INSERT
                sql = "";                      
                if (InsertFields != "")
                {
                    if (StateDate != "") InsertFields = "StateDate," + InsertFields;
                    if (StateDate != "") InsertValues = "StateDate," + InsertValues;
                    sql = "INSERT INTO " + Ent[i, nTableName] + " (" + InsertFields + ") VALUES (" + InsertValues + ") " + Var.CR; //SELECT SCOPE_IDENTITY() AS ID " +                                                                               
                }
                if (sql != "") Ent[i, nInsert] = sql;                                                                                                      
            }
        }

        #endregion Region. Сборка запросов. Table - UPDATE_INSERT_DELETE. 

		/// <summary>
		/// Это подготовка данных. Обновляется только поле Ref[j, iValueSave].	
		/// </summary>
		/// <param name="command">Команда из списка. Update, Insert, Delete</param>
		/// <param name="queryName">Имя запроса</param>
		/// <returns>Если успешно, то true</returns>
        private bool EntityQuery_UPDATE_INSERT_Prepare(SQLCommand command, string queryName)
        {                                           
        	if (command == SQLCommand.Delete) return false;
        	//ShowArray("Ref");
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nTypeEnt]    != ObjectRefType.Entity.ToString())  continue;
                if (Ent[i, nQueryName]  != queryName) continue;
                if (Ent[i, nNeedSave]   == "0")       continue;

                string EntityBrief = Ent[i, nEntityBrief];
                string ObjectID = Ent[i, nObjectID];
                string StateDate = Ent[i, nStateDate];
            
                for (int j = 0; j < RefCount; j++)
                {
                    if (Ref[j, iQueryName] != queryName)        continue;
                    if (Ref[j, iEntityBrief] != EntityBrief)    continue;
                    if (Ref[j, iNeedSave] != "1") 				continue;
                    
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

                    if (ValueNew != "") Ref[j, iValueSave] = ValueNew;
                                                          
                }               
            }
            return true;
        }                

		/// <summary>
		/// Способ, если процедура сохранения объекта БД. Это способ, если есть процедура сохранения
		/// объекта в БД в виде хранимой процедуры spen_save_Object.
		/// Процедура spen_save_Object в данный момент сделана только для базы MSSQL.
		/// Поэтому можно вызывать либо EntityQuery_UPDATE_INSERT_DELETE_DataBase, либо EntityQuery_UPDATE_INSERT_DELETE_Client.
		/// </summary>
		/// <param name="command">Команда из списка. Update, Insert, Delete</param>
		/// <param name="queryName">Имя запроса</param>
		/// <returns>Если успешно, то true</returns>
        private bool EntityQuery_UPDATE_INSERT_DELETE_DataBase(SQLCommand command, string queryName)
        {                               	                	
        	//ShowArray("Ref");
            for (int i = 0; i < EntCount; i++)
            {
                if (Ent[i, nTypeEnt]    != ObjectRefType.Entity.ToString()) continue;
                if (Ent[i, nQueryName]  != queryName) continue;
                if (Ent[i, nNeedSave]   == "0")       continue;

                string entityBrief = Ent[i, nEntityBrief];
                string objectID    = Ent[i, nObjectID];
                string stateDate   = Ent[i, nStateDate];
                
                if (command != SQLCommand.Delete)
                {
	                string sql = "";
	                int countAttrDirty = 0;
	                for (int j = 0; j < RefCount; j++)
	                {
	                    if (Ref[j, iQueryName]   != queryName)      continue;
	                    if (Ref[j, iEntityBrief] != entityBrief)    continue;
	                    if (Ref[j, iNeedSave]  != "1") 				continue;
	                    if (Ref[j, iValueSave] == "") 				continue;
	                    
	                    string valueNew = Ref[j, iValueSave];
	                    
	                    if ((valueNew != "") && (Ref[j, iNeedSave] == "1"))
	                    {
	                        sql = sql + ",'" + Ref[j, iAttr] + "'," + valueNew;
	                        countAttrDirty++;
	                    }
	                }	                	               
	                if (countAttrDirty != 0)
	                {
	                	if ((command == SQLCommand.Auto) || (command == SQLCommand.Update)) Ent[i, nUpdate] = "EXEC spen_SaveObject 0, 'UPDATE', " + objectID + ",'" + entityBrief + "','" + stateDate + "'" + sql;
	                    if ((command == SQLCommand.Auto) || (command == SQLCommand.Insert)) Ent[i, nInsert] = "EXEC spen_SaveObject 0, 'INSERT', " + objectID + ",'" + entityBrief + "','" + stateDate + "'" + sql;                    
	                }
                }                
             	if ((command == SQLCommand.Auto) || (command == SQLCommand.Delete)) Ent[i, nDelete] = "EXEC spen_SaveObject 0, 'DELETE', " + objectID + ",'" + entityBrief + "'";                
            }   
            return true;
        }              
        
        /// <summary>
        /// Получение максимального уровня вложенности сущностей, с которого начинать проход по массиву.
        /// </summary>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Уровень вложенности</returns>
        private int EntityQuery_GetMaxLevel(string queryName)
        {                                            
        	int maxLevel = 0;
        	for (int i = 0; i < RefCount; i++)
            {
                if (Ref[i, iQueryName] != queryName) continue;               
                if (Ref[i, iNeedSave]  != "1") 		 continue;
                //if (Ref[i, iValueSave] != "") 		 continue;
                if (Ref[i, iNumLevel] == null) continue;
                int N = Ref[i, iNumLevel].ToInt();
                if (N > maxLevel) maxLevel = N;        
            }
        	return maxLevel;
        }
                           
        /// <summary>
        /// Проверить нужна ли запись в историчую таблицу TableName. Если записывать нечего, то false.
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="queryName">Имя запроса</param>
        /// <returns>Если таблица, должна участвовать в запросах, то true</returns>
        private bool CheckAddHistTable(string tableName, string queryName)
        {			       
            for (int i = 0; i < RefCount; i++)
            {               
                if (Ref[i, iQueryName]  != queryName) continue;
                if (Ref[i, iNeedSave]   != "1")       continue; //Атрибут нельзя сохранять.
                if (Ref[i, iValueSave]  != "")        continue; //Нет значения для сохранения.
                if (Ref[i, iTableName]  != tableName) continue; //Таблица не наша.
                return true;
            }
            return false;
        }                      
          
		/// <summary>
		/// Способ, если процедура сохранения объекта БД. Это способ, если нужно составить запросы не с помощью 
		/// хранимой процедуры spen_save_Object, а на клиенте.
		/// Сюда command = Auto нельзя передавать, только конкретное действие. 
		/// </summary>
		/// <param name="command">Команда из списка. Update, Insert, Delete</param>
		/// <param name="queryName">Имя запроса</param>
		/// <param name="entityBrief">Сокращение сущности</param>
		/// <param name="entityID">ИД сущности</param>
		/// <param name="objectID">ИД объекта</param>
		/// <param name="maxLevel">Максимальный уровень вложенности сущностей, начиная с которого нужно осуществлять запись объекта.</param>
		/// <param name="scriptUpdate">SQL для Update</param>
		/// <param name="scriptInsert">SQL для Insert</param>
		/// <param name="scriptDelete">SQL для Delete</param>
		/// <returns>Если успешно, то true</returns>
        private bool EntityQuery_UPDATE_INSERT_DELETE_Client2(SQLCommand command, 
		                                                      string queryName, 
		                                                      string entityBrief, 
		                                                      string entityID, 
		                                                      string objectID, 		                                                    
															  int maxLevel,		                                                      
		                                                      out string scriptUpdate,
		                                                      out string scriptInsert,
		                                                      out string scriptDelete)
        {                                                                                                     
			scriptUpdate = "";
		    scriptInsert = "";
		    scriptDelete = "";
		    
			string sqlUpdateAll = "";
			string sqlInsertAll = "";
            string sqlDeleteAll = "";
                       
            //Константы для массива Tbl.
	        const int tPos         = 0;
	        //const int tEnt         = 1; //Ссылка на таблицу Ent.
	        //const int tRef         = 2; //Ссылка на таблицу Ref.
	        const int tQueryName   = 3;
	        const int tEntityBrief = 4;
	        const int tEntityID    = 5;
	        const int tTableName   = 6; //Имя таблицы, которая используется в запросах UPDATE и INSERT.
	        const int tTableType   = 7; //Тип таблицы, которая используется в запросах UPDATE и INSERT.
	        const int tIDFieldName = 8; //Ключевое поле таблицы, которая используется в запросах UPDATE и INSERT.         
	        const int tObjectID    = 9; //ИД объекта сущности.
	        //const int tStateDate   = 10; //Историчная дата. 
			const int tNumLevel    = 11; //Уровень вложенности сущности, к котрой относится таблица.   
			//const int tAction      = 11; //Признак что это таблица предка.
	        //const int tNeedSave    = 12; //Нужно сохранять изменения 1, не нужно 0.        
	        //const int tUpdate      = 13; //Собранный запрос для сущности/таблицы.
	        //const int tInsert      = 14; //Собранный запрос для сущности/таблицы.
	        //const int tDelete      = 15; //Собранный запрос для сущности/таблицы.
	        
            //Все дело в сортировке.
            //Сначала из общего массива атрибутов в ParserData.ArAttrParent, собираем в массив все таблицы, 
            //которые так или иначе могут быть задействованы в сохранении объекта сущности.
            //Это для ускорения, для того, чтобы не гонять по большой таблице ParserData.ArAttrParent несколько циклов. Это для ускорения.
            //В результате по большому массиву ParserData.ArAttrParent нужен всего один проход цикла.
            //Создаем массив Tbl1, в котором будут все таблицы.
            //В этом массиве Tbl1 собраны все таблицы, котрые должны участовать в сохранении объекта. Но записи в этой массиве не упорядочены.
            //Поэтому сейчас нужно собрать все таблицы в правильном порядке. С максимального уровня numLevel до минимального, 
            //но историчные таблицы должны идти после записи главной таблицы сущности.
            int tblCount = 0; //Максимальное количество таблиц, которые участвуют в запросах UPDATE и INSERT - 100.
            var tbl1 = new string[100,  tNumLevel  + 1]; //Массив таблиц, которые используются в запросах UPDATE и INSERT. 
            string oldTableName = ""; //добавляем 
            for (int i = 0; i < ParserData.ArAttrParentY; i++)
            {
            	if (oldTableName == ParserData.ArAttrParent[i, ParserData.aTable_Name]) continue;
            	//Получение списка таблиц.
            	if (ParserData.ArAttrParent[i, ParserData.aEnBrief2]   != entityBrief) continue;
            	//Если не запрос удаления, то берём не все таблицы сущности.
            	//Если DELETE, то все.
            	if ((command == SQLCommand.Update) || (command == SQLCommand.Insert))
            	{
            		if (ParserData.ArAttrParent[i, ParserData.aNumLevel].ToInt() > maxLevel) continue;
            	}
            	if (ParserData.ArAttrParent[i, ParserData.aAttr_Type] == "4") continue; //Массивы
                if (ParserData.ArAttrParent[i, ParserData.aTable_Name] == "") continue; //Нет таблицы. Это вычисляемый атрибут.
               
                //Если таблица историчная и у нас нет для значения для записи из этой историчной таблицы, то такую таблицу пропускаем.
                //Иными словами - нам нечего писать в эту историчную таблицу.
                if ((ParserData.ArAttrParent[i, ParserData.aTable_Type] == "2") &&
                    (!CheckAddHistTable(ParserData.ArAttrParent[i, ParserData.aTable_Name], queryName))) continue;
               
				tbl1[tblCount, tPos]         = tblCount.ToString();   
				tbl1[tblCount, tObjectID]    = objectID;				
                tbl1[tblCount, tQueryName]   = queryName;
                tbl1[tblCount, tEntityBrief] = entityBrief;
                tbl1[tblCount, tEntityID]    = ParserData.ArAttrParent[i, ParserData.aAttr_EntityID];
                tbl1[tblCount, tTableName]   = ParserData.ArAttrParent[i, ParserData.aTable_Name];        //Имя таблицы, которая используется в запросах UPDATE и INSERT.
                tbl1[tblCount, tTableType]   = ParserData.ArAttrParent[i, ParserData.aTable_Type];        //Тип таблицы, которая используется в запросах UPDATE и INSERT.
                tbl1[tblCount, tIDFieldName] = ParserData.ArAttrParent[i, ParserData.aTable_IDFieldName]; //Ключевое поле таблицы, которая используется в запросах UPDATE и INSERT.                                       
                tbl1[tblCount, tNumLevel]    = ParserData.ArAttrParent[i, ParserData.aNumLevel];
                tblCount++;
                oldTableName = ParserData.ArAttrParent[i, ParserData.aTable_Name];
            }            
                        
            Arr.ArrayView("tb1", "tb1", tbl1);
            //Сортировка массива таблиц Tbl1. На выходе массив Tbl2.
			//Массив Tbl2 - это тот же самый Tbl1, но только все строки в нём выстроены в определённом порядке для записи в БД.  
			//Количество строк в Tbl1 и Tbl2 всегда должно совпадать.			
            var tbl2 = new string[tblCount,  tNumLevel  + 1]; //Массив таблиц, которые используются в запросах UPDATE и INSERT. 
            int tblCount2 = 0;
            for (int level = maxLevel; level > -1; level--)
            {
            	//hist = 0 - Обычные таблицы сущности.
            	//hist = 1 - Историчные таблицы сущности.
            	for (int hist = 0; hist < 2; hist++)
	            {
		        	//Цикл по всем возможным таблицам. Сначала для каждой сущности берём основную таблиц, затем историчную.
            		for (int j = 0; j < tblCount; j++)
		            {
            			if ((command != SQLCommand.Delete) && (tbl1[j, tNumLevel]  != level.ToString())) continue;
		        		
            			int stype = 0;
		        		if (tbl1[j, tTableType] == "Hist") stype = 1;
		        		if (stype != hist) continue;		        		
		        		tbl2[tblCount2, tPos]         = tblCount2.ToString();
						tbl2[tblCount2, tObjectID]    = tbl1[j, tObjectID];	
		                tbl2[tblCount2, tQueryName]   = tbl1[j, tQueryName];	
		                tbl2[tblCount2, tEntityBrief] = tbl1[j, tEntityBrief];	
		                tbl2[tblCount2, tEntityID]    = tbl1[j, tEntityID];	
		                tbl2[tblCount2, tTableName]   = tbl1[j, tTableName];	
		                tbl2[tblCount2, tTableType]   = tbl1[j, tTableType];	
		                tbl2[tblCount2, tIDFieldName] = tbl1[j, tIDFieldName];								               
		                tbl2[tblCount2, tNumLevel]    = tbl1[j, tNumLevel];	
		                tblCount2++;
		            }
            	}            	
            }
            //Конец сортировки Tbl1.            
             Arr.ArrayView("tb2", "tb2", tbl2);
             
            //Теперь нужно по таблице Tbl2 выстроить запросы. Цикл по Tbl2 сверху вниз.       					
			for (int i = 0; i < tblCount2; i++)
            {
				string sql = "";						
			    string objectID2 = objectID;
			    bool firstInsertID = false;
			    if ((i == 0) && (Var.con.serverType == ServerType.SQLite) && (objectID2 == "0"))
	        	{        			        		
	        		firstInsertID = true;
	        	}
							   			   			   			   		
			    GetQuery_UPDATE_INSERT_SaveObject(command,
			                                      queryName,
                                                  entityBrief, 
                                                  entityID,  
												  tbl2[i, tTableName], 													
												  tbl2[i, tTableType], 															     
												  objectID2, 
												  tbl2[i, tIDFieldName],											
												  firstInsertID,													  
												  out sql);			    			   
			    //Пример вставки объекта на SQLite:
				//PRAGMA temp_store = 2; CREATE TEMP TABLE temptable(ID TEXT); 
				//INSERT INTO Document (EntityID) VALUES (2924); 
				//INSERT INTO temptable (ID) VALUES (last_insert_rowid());
				//INSERT INTO Contract (ID,EntityID, Number) VALUES ((SELECT ID FROM temptable),2924, '6746767'); 
				//INSERT INTO Contract_HIST (ID, EntityID, StateDate) 
				//SELECT (SELECT ID FROM temptable), 2924, '1900-01-01 00:00:00' WHERE NOT EXISTS 
				//(SELECT 1 FROM Contract_HIST WHERE ID = (SELECT ID FROM temptable) AND EntityID = 2924 AND StateDate = '1900-01-01 00:00:00');
				//UPDATE Contract_HIST SET DateEnd = '1900-01-11 00:00:00', DateStart = '1900-01-11 00:00:00' WHERE ID = (SELECT ID FROM temptable) AND StateDate = '1900-01-01 00:00:00';				
				//PRAGMA temp_store = 0;
							   
				if (command == SQLCommand.Update) sqlUpdateAll = sqlUpdateAll + sql;
				if (command == SQLCommand.Insert) sqlInsertAll = sqlInsertAll + sql;										
				if (command == SQLCommand.Delete) sqlDeleteAll = sql + sqlDeleteAll;				
			}
            
			if (Var.con.serverType == ServerType.Postgre) sqlInsertAll = sqlInsertAll + Var.CR + " RETURNING id; ";
		    if (Var.con.serverType == ServerType.MSSQL) sqlInsertAll = sqlInsertAll + Var.CR + " SELECT @@IDENTITY AS id; ";
			if ((Var.con.serverType == ServerType.SQLite) && (objectID == "0") && (command == SQLCommand.Insert))			
				sqlInsertAll = "PRAGMA temp_store = 2; CREATE TEMP TABLE temptable(ID TEXT); " + Var.CR + sqlInsertAll + Var.CR + "PRAGMA temp_store = 0; SELECT ID FROM temptable;";				
									 
			if (command == SQLCommand.Update) scriptUpdate = sqlUpdateAll;
		    if (command == SQLCommand.Insert) scriptInsert = sqlInsertAll;
		    if (command == SQLCommand.Delete) scriptDelete = sqlDeleteAll;
			
            return true;
        }                                                
        /// <summary>
        /// Сбока запросов по имени запроса QueryName, сущности EntityBrief, и уровня вложенности numlevel.	 
        /// </summary>
        /// <param name="command">Команда из списка. Update, Insert, Delete</param>
        /// <param name="queryName">Имя запроса</param>
        /// <param name="entityBrief">Сокращение сущности</param>
        /// <param name="entityID">ИД сущности</param>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="tableType"></param>
        /// <param name="objectID">ИД объекта</param>
        /// <param name="idFieldName">Поле ключа таблицы</param>
        /// <param name="firstInsertID">Если нужно формаировать код для первой вставки объъекта и получения ИД вставленной записи</param>
        /// <param name="sql">Текст SQL запроса записи объекта</param>
        private void GetQuery_UPDATE_INSERT_SaveObject (SQLCommand command,
        	                                            string queryName,
                                                     	string entityBrief, 
                                                     	string entityID,
													    string tableName, 													
													    string tableType, 													     
													    string objectID,
													    string idFieldName,													   
													    bool firstInsertID, //Флаг, который показывает, что это первая таблица. Если операция INSERT, то в неё нужно сделать обязательно INSERT по другим правила, нежели в другие таблицы.
                                                        out string sql)
        {        	        	                	
        	sql = "";
           			           
        	//Небольшая оптимизация. Если только DELETE, то для INSERT и UPDATE не возвращаем.
        	if (command ==  SQLCommand.Delete)
        	{	        	        	                                                           
        		if (objectID != "") sql = "DELETE FROM " + tableName + " WHERE " + idFieldName + " = " + objectID + ";" + Var.CR;
	        	return;
        	}
        	
        	if (objectID == "0") objectID = "(SELECT ID FROM temptable)";
        	//if (Action == "Auto") || (Action == "Auto")
        	//if (serverTypeRemote ==  ServerType.Postgre) return "; RETURNING id; ";
            //if (serverTypeRemote ==  ServerType.MSSQL)    return "; SELECT @@IDENTITY AS id; ";                                          
            //if (serverTypeRemote ==  ServerType.SQLite)   return "; SELECT last_insert_rowid() AS id; ";         	          
            //INSERT INTO temptable (ID) VALUES (last_insert_rowid())
            //if (stateDate == "") stateDate = "1900-01-01 00:00:00";                       			
            string insertFields = "";
            string insertValues = "";
            string updateValues = ""; 
			string stateDate    = "";             
            int fieldCount = 0;
            
            //Если firstInsertID = 0 то поле ID не нужно вставлять в insert, иначе нужно.
            //Это значит, что таблица первая в иерархии таблиц объекта сущности.
            if (command == SQLCommand.Insert)
            {
	            if (firstInsertID) 	          
	        	{
	        		insertFields = "EntityID";
	        	    insertValues = entityID; 
	            	
	        	} else
	        	{
	        		insertFields = idFieldName + ",EntityID" ;
	        		insertValues = objectID + "," + entityID;
	        	}        	  
        	}
            
            //Action = UPDATE, INSERT.                             
            for (int i = 0; i < RefCount; i++)
            {                    
                if (Ref[i, iQueryName]   != queryName)   continue;
                if (Ref[i, iEntityBrief] != entityBrief) continue;              
                if (Ref[i, iTableName]   != tableName)   continue; 
                //if (Ref[j, iAttr]      == Ref[j, iIDFieldName]) continue; //Поле автоинкремента в таблице игнорируем.               
                if (Ref[i, iValueSave]   == "") continue;
                 
                //Для каждого атрибута своя stateDate. Это нужно в случае, если сторичных таблиц несколько.
                stateDate = Ref[i, iStateDate];
                if (stateDate == "") stateDate = "1900-01-01 00:00:00";  
                
                //Для INSERT.
                if (command == SQLCommand.Insert)
                {
	                if (insertFields != "") insertFields += ", ";
	                if (insertValues != "") insertValues += ", ";
	                insertFields = insertFields + Ref[i, iAttr];
	                insertValues = insertValues + Ref[i, iValueSave];                                                      
                }
                //Для UPDATE формируем всегда.   				                             
                if (updateValues != "") updateValues += ", ";
                updateValues = updateValues + Ref[i, iAttr] + " = " + Ref[i, iValueSave];    
 				
                fieldCount++;
            }  
             			          
            //Если нет полей для вставки. Это может быт когда создается объект дочерней сущности.
            if (fieldCount == 0) 
            {            	            
            	//Если данных для INSERT или UPDATE нет, то делается INSERT, но только в случае, если команда INSERT и это первая главная таблица. 
            	if  ((command == SQLCommand.Insert) && (firstInsertID)) //при UDATE не возвращаем INSERT.
            		sql = "INSERT INTO " + tableName + " (" + insertFields + ") VALUES (" + insertValues + "); " + Var.CR;
                                   
            } else
            {
            	 //Если таблица обычная		
            	if (tableType == "Main")
            	{
            		//UPDATE
		            if (command == SQLCommand.Update)
					{				               			           		
						sql= "UPDATE " + tableName + " SET " + updateValues + " WHERE " + idFieldName + " = " + objectID + ";" + Var.CR;	               			               		            	        
						//if ((tableType == "Hist") && (stateDate != ""))	           				        				
						//  sqlUpdate = "UPDATE " + tableName + " SET " + UpdateValues + " WHERE " + IDFieldName + " = " + objectID + " AND StateDate = '" + stateDate + "';" + Var.CR;							            	          
					}
		            
		            //INSERT
		            if (command == SQLCommand.Insert)
		            {
						sql = "INSERT INTO " + tableName + " (" + insertFields + ") VALUES (" + insertValues + "); " + Var.CR; //SELECT SCOPE_IDENTITY() AS ID " +                                                                                           
		            }
            	}
	                              	         
	            if (tableType == "Hist") //Если таблица историчная, то тут всегда один код. Независимо от того операция INSERT или UPDATE.       	                	           	            
            	{	            			            			            
            		 sql =  "INSERT INTO " +  tableName + " (" + idFieldName + ", EntityID, StateDate) " + Var.CR +
    			         "SELECT " + objectID + ", " + entityID + ", '" + stateDate + "' WHERE NOT EXISTS " + Var.CR +
    					 "(SELECT 1 FROM " + tableName + " WHERE " + idFieldName + " = " + objectID + " AND EntityID = " + entityID + " AND StateDate = '" + stateDate + "');" + Var.CR +
            		     "UPDATE " + tableName + " SET " + updateValues + " WHERE " + idFieldName + " = " + objectID + " AND StateDate = '" + stateDate + "';" + Var.CR;	        					
            	}	            			          
            } 
            
            if ((firstInsertID) && (Var.con.serverType == ServerType.SQLite)) 
            	sql = sql + "INSERT INTO temptable (ID) VALUES (last_insert_rowid());" + Var.CR;                                             
     	}      
        	    
		/// <summary>
		/// Способ, если процедура сохранения объекта БД. Это способ, если нужно составить запросы не с помощью 
		///  хранимой процедуры spen_save_Object, а на клиенте.
		/// </summary>
		/// <param name="command">Команда из списка. Update, Insert, Delete</param>
		/// <param name="queryName">Имя запроса</param>
		/// <returns>Подготовка для записи объекта. Сборк всех запроса Update или Insert или Delete</returns>
        private bool EntityQuery_UPDATE_INSERT_DELETE_Client1(SQLCommand command, string queryName = "")
        {                             	        
        	for (int i = 0; i < EntCount; i++)
            {                
                if (Ent[i, nTypeEnt] != ObjectRefType.Entity.ToString()) continue;
                if ((queryName != "") && (Ent[i, nQueryName] != queryName)) continue;
	            string EntityBrief = Ent[i, nEntityBrief];
	        	string EntityID    = Ent[i, nEntityID];
	        	string ObjectID    = Ent[i, nObjectID];                		        	
	        	queryName = Ent[i, nQueryName];
	        	
	        	if (command == SQLCommand.Auto)
	        	{
		        	if ((ObjectID == "") || (ObjectID == "0")) command = SQLCommand.Insert;
	        	    else command = SQLCommand.Update;
	        	}
	        	
				//Получаем максимальный уровень вложенности, начиная с которго нужно создавать объект.
	            int maxLevel = EntityQuery_GetMaxLevel(queryName);  
	              
	            string sqlUpdateAll = "";
			    string sqlInsertAll = "";
			    string sqlDeleteAll = "";
	            if (!EntityQuery_UPDATE_INSERT_DELETE_Client2(command, queryName, EntityBrief, EntityID, ObjectID, maxLevel, out sqlUpdateAll, out sqlInsertAll, out sqlDeleteAll)) return false;            
	            Ent[i, nUpdate]      = sqlUpdateAll;
	            Ent[i, nInsert]      = sqlInsertAll;
	            Ent[i, nDelete]      = sqlDeleteAll;                    
            }    
            return true;
        }              
    }
}
            
            