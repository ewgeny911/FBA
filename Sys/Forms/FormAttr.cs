/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 14.08.2017
 * Время: 16:08
 */
 
using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
namespace FBA
{
    ///Форма добавления и редактирования атрибута сущности.
	public partial class FormAttr : FormFBA //Здесь нужен FormFBA!  
    {
        #region Region. Переменные и конструтор.
          
        /// <summary>
        /// Результат закрытия формы
        /// </summary>
	    public int StatusClose  = 0; 
		
		 /// <summary>
        /// Операция Operation: NotAssigned, Refresh, Add, AddChild, Edit, Del 
        /// </summary>	    
        public Operation operation;
        
        /// <summary>
        /// ИД сущности
        /// </summary>
        public string EntityID;
        
        /// <summary>
        /// ИД объекта
        /// </summary>
        public string ObjID;  
		       
        
        /// <summary>
        /// Сокращение объекта
        /// </summary>
        public string ObjBrief;
        
        
        /// <summary>
        /// Имя объекта
        /// </summary>
        public string ObjName;
        
        /// <summary>
        /// FBA.ObjectRef
        /// </summary>
        public FBA.ObjectRef Obj;         
        private bool EventDo = true;              
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="operation">Операция Operation: NotAssigned, Refresh, Add, AddChild, Edit, Del</param>
        /// <param name="EntityID">ИД сущности</param>
        /// <param name="ObjID"></param>
        /// <param name="ObjBrief"></param>
        /// <param name="ObjName"></param>
        public FormAttr(Operation operation, string EntityID, string ObjID, string ObjBrief = "", string ObjName = "")
        {
        	InitializeComponent();          
        	if (operation == Operation.Add) ObjID = "0"; 
        	this.operation = operation;  
        	this.EntityID  = EntityID; 
        	this.ObjID     = ObjID;
            this.ObjBrief  = ObjBrief;
            this.ObjName   = ObjName;          
            if (operation == Operation.Del) SetShowOnly();             
            SetTextButtonOk(operation, btnOk);                                          
        	//this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.btnOk.DialogResult     = System.Windows.Forms.DialogResult.OK; 
            //this.MdiParent              = Var.FormMainObj;   
        }
        
        #endregion Region. Переменные и конструтор.
        
        #region Region. Наполнение списков данными.
           
        ///Присвоить tbTable список таблиц для выбора из БД.
        private bool GetListAvalibleTables()
        {             
            if (sys.IsEmptyID(EntityID)) return false;
            string sql = "SELECT Name FROM fbaTable WHERE TableEntityID = " + EntityID;
            var dt = new System.Data.DataTable();
            if (!sys.SelectDT(DirectionQuery.Remote, sql, out dt)) return false;  
            string tempStr = tbTableStr.Text;    
            tbTableStr.SetDataSourse(dt);
            tbTableStr.Text = tempStr;          
            return true;
        }
        
        ///Присвоить tbField1 список полей таблицы TableName.
        private bool GetListAvalibleFields(string tableName)
        {           
            if (sys.IsEmptyID(tableName)) return false;
            System.Data.DataTable dt1;
            sys.GetTableFields(tableName, out dt1);
                
            var dt2 = new System.Data.DataTable();
            if (dt1 == null) return false;
            dt2 = dt1.Copy();
            
            string tempStr = tbField1.Text;         
            tbField1.SetDataSourse(dt1);
            tbField1.Text = tempStr;
                        
            tbField2.SetDataSourse(dt2); 
            tbField2.Text = "";
            return true;
        }
               
        ///Присвоить tbLinkToStr список сущностей для выбора.
        private bool GetListLinkTo()
        {                   
            const string sql = "SELECT DISTINCT Brief FROM fbaEntity";                                
            var dt = new System.Data.DataTable();
            if (!sys.SelectDT(DirectionQuery.Remote, sql, out dt)) return false; 
            string tempStr = tbLinkToStr.Text;            
            tbLinkToStr.SetDataSourse(dt);
            tbLinkToStr.Text = tempStr;
            return true;            
        }
        
        ///Присвоить tbAttrLinkStr список атрибутов для выбора.
        private bool GetListtbAttrLink(string entityBrief)
        {                        
            if (sys.IsEmptyID(entityBrief)) return false;
            string sql = " SELECT Brief FROM fbaAttribute WHERE  [Type]= 2 AND [Kind] = 1 AND AttributeEntityID = (SELECT ID FROM fbaEntity WHERE Brief = '" + entityBrief + "') ";                      
            var dt = new System.Data.DataTable();
            if (!sys.SelectDT(DirectionQuery.Remote, sql, out dt)) return false;
            string tempStr = tbAttrLinkStr.Text;            
            tbAttrLinkStr.SetDataSourse(dt); 
            tbAttrLinkStr.Text = tempStr;
            return true;            
        }
        
        #endregion  Region. Наполнение списков данными.
                
        ///Заполнение свойств компонентов значениями.
        private void FillData()
        { 
            EventDo = false;
            Obj = new FBA.ObjectRef();
            Obj.SetQueryTable(this, "Main1", "fbaAttribute", ObjID, "ID", "", DirectionQuery.Remote);
            Obj.AddAttr("Main1.AttributeEntityID", EntityID); 
            Obj.AddAttr("Main1.Type");
            Obj.AddAttr("Main1.Kind");
            Obj.AddAttr("Main1.RefEntityID");
            Obj.AddAttr("Main1.RefAttributeID");
            Obj.AddAttr("Main1.EntityID", "3");  
            Obj.AddAttr("Main1.TableID");			          
            Obj.Read();
                                                                                               
            int valueType = -1;                           
            if (Obj["Main1.Type"] != "") valueType = Obj["Main1.Type"].ToInt() - 1;
            if (tbTypeStr.Items.Count > valueType) tbTypeStr.SelectedIndex = valueType;
            
            int ValueKind = -1;                           
            if (Obj["Main1.Kind"] != "") ValueKind = Obj["Main1.Kind"].ToInt() - 1;
            if (tbKindStr.Items.Count > ValueKind) tbKindStr.SelectedIndex = ValueKind;
                        
            tbLinkToStr.Text = "";
            string dfd = Obj["Main1.RefEntityID"];
            if (Obj["Main1.RefEntityID"] != "")  tbLinkToStr.Text = sys.GetEntityBrief(dfd);
                                  
            tbAttrLinkStr.Text = "";
            if (Obj["Main1.RefAttributeID"] != "") tbAttrLinkStr.Text = sys.GetAttrBrief(Obj["Main1.RefAttributeID"]);
                               
            tbTableStr.Text = "";
            if (Obj["Main1.TableID"] != "") tbTableStr.Text = sys.GetTableName(Obj["Main1.TableID"]);
                           
            GetListAvalibleTables();
            //GetListAvalibleFields(tbTableStr.Text);
            GetListLinkTo();
            GetListtbAttrLink(tbLinkToStr.Text);
            EnableDisable();
            EventDo = true;
            //Obj.ShowArray("Ent");
            //Obj.ShowArray("Ref");
            //Obj.ShowArray("Tbl");           
        }
        
        ///Перед записью в базу очищаем значения компонентов, чтобы не записать в базу лишнее.
        private void SetValuesBeforeWrite()
        {
            if (!tbTableStr.Enabled)    tbTableStr.Text  = "NULL";           
            if (!tbField1.Enabled)      tbField1.Text    = "NULL";       
            if (!tbField2.Enabled)      tbField2.Text    = "NULL";                             
            if (!tbKindStr.Enabled)     tbKindStr.Text   = "NULL";                   
            if (!tbCode.Enabled)        tbCode.Text      = "NULL";           
            if (!tbMask.Enabled)        tbMask.Text      = "NULL";  
            
            if (!tbLinkToStr.Enabled)
            {
                tbLinkToStr.Text = "";                       
                Obj["Main1.RefEntityID"] = "NULL";
            } else
            {
                Obj["Main1.RefEntityID"]  = sys.GetEntityID(tbLinkToStr.Text);
            }
            
            if (!tbAttrLinkStr.Enabled)
            {
                tbAttrLinkStr.Text = "";              
                Obj["Main1.RefAttributeID"] = "NULL";
            } else
            {
                Obj["Main1.RefAttributeID"] = sys.GetAttrID(EntityID, tbAttrLinkStr.Text);
            }
            
            if (!tbTableStr.Enabled)
            {
                tbTableStr.Text = "";              
                Obj["Main1.ID"] = "NULL";
            } else
            {
                Obj["Main1.TableID"] = sys.GetTableID(tbTableStr.Text);
            }
            Obj["Main1.AttributeEntityID"] = EntityID;
            
        }       
                
        ///Запись в базу изменений.
        private bool ObjectWrite()
        {
            //Очистка полей, чтобы лишего не записать в базу.
            SetValuesBeforeWrite();
            return Obj.Write();   
        }
        
        ///Кнопка Cancel.
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            StatusClose = 2;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        ///Запись объекта.
        private bool AttrObjectWrite()
        {                       
            //Сделано только для MSSQL
            if (Var.con.serverTypeRemote == ServerType.MSSQL) //"MSSQL")
            {
            	string sqlForeignKey = "";
            	ForeignKey(out sqlForeignKey);
            	Obj.AddQuery("Main1", sqlForeignKey, SQLLang.SQL, TimeAction.Before);
            }            
            return ObjectWrite();
        }                        
               
        ///Кнопка Ok.
        private void BtnOkClick(object sender, EventArgs e)
        {
            //Проверка значений компонентов формы перед её закрытием.
            if (ErrorIfNullExists()) return;
            
            if (tbTypeStr.Text     != "") Obj["Main1.Type"] = (tbTypeStr.SelectedIndex + 1).ToString();
            if (tbKindStr.Text     != "") Obj["Main1.Kind"] = (tbKindStr.SelectedIndex + 1).ToString();  
           
            if (tbLinkToStr.Text   != "") Obj["Main1.RefEntityID"]     = sys.GetEntityID(tbLinkToStr.Text);  
            if (tbAttrLinkStr.Text != "") Obj["Main1.RefAttributeID"]  = sys.GetAttrID(Obj["Main1.RefEntityID"], tbAttrLinkStr.Text);  
            if (tbTableStr.Text    != "") Obj["Main1.ID"]         = sys.GetTableID(tbTableStr.Text);  
            
            bool result = false;
            if (operation == Operation.Del)      result = OperationDelete();
            if (operation == Operation.Add)      result = AttrObjectWrite();
            if (operation == Operation.Edit)     result = AttrObjectWrite();
            if (result)
            {
                DialogResult = DialogResult.OK;
                StatusClose = 1;
            } else           
            {
                DialogResult = DialogResult.Cancel;
                StatusClose = 2;            
            }                         
            if (result) Close();
        } 
        
        ///Проверка возможности удаления атрибута.
        private bool CheckDeleteAttr()
        {                           
            //Проверка на атрибутам.
            string sql = "SELECT * FROM fbaAttribute WHERE RefAttributeID = " + ObjID;
            var dt = new System.Data.DataTable();   
            if (!sys.SelectDT(DirectionQuery.Remote, sql, out dt)) return false;          
            if (dt.Rows.Count != 0) 
            {
                sys.SM("Ошибка. На атрибуты ссылаются другие атрибуты. Удаление невозможно.");
                sys.DataTableView(dt, "Список ссылающихся атрибутов",  "Cсылающиеся атрибуты");
                return false;
            } 
            //Пока полная проверка только для MSSQL.
            if (Var.con.serverTypeRemote != ServerType.MSSQL) return true;
            
            //Проверка по таблицам в базе.
            string tableName = tbTableStr.Text;
            string fieldName = tbField1.Text;                         
            string queryTextStr = string.Join(Var.CR, this.QueryText);
            sql = GetSQLAction("AttrDelete");   //sys.GetSection(QueryTextStr, "AttrDelete");
            sql = sql.Replace("TableNameAttr",  tableName);
            sql = sql.Replace("FieldNameAttr", fieldName);
            sys.SelectDT(DirectionQuery.Remote, sql, out dt);
            if (dt.Rows.Count != 0) 
            {
                sys.SM("Ошибка. На поле таблицы с данным атрибутом есть внешние ключи в других таблицах. Удаление невозможно.");
                sys.DataTableView(dt, "Список таблиц и полей, которые ссылаются на данное поле",  "Cсылающиеся таблицы и поля");
                return false;
            }
            return true;            
        }
               
        ///Удаление атрибута.
        private bool OperationDelete()
        {
            if (!sys.SM("Вы хотите действительно удалить атрибут?", MessageType.Question, "Удаление атрибута")) return false;            
            if (!CheckDeleteAttr()) return false;  
            string sqlForeignKey;
            if (!ForeignKey(out sqlForeignKey)) return false;
            Obj.AddQuery("Main1", sqlForeignKey, SQLLang.SQL, TimeAction.Before);
            return Obj.DeleteObject("Main1");         
        }
        
        ///Событие выбора ссылки на сущность. 
        private void TbLinkToStr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EventDo) return;
            GetListtbAttrLink(tbLinkToStr.Text);
        }
        
        ///Событие выбора таблицы.
        private void TbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EventDo) return; 
            //GetListAvalibleFields(tbTableStr.Text);
        }
        
        ///Поле tbField2 доступно только в том случае, если у нас Массив связанных объектов.      
        private void TbTypeStr_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisable();
        }                                
                
        ///Интересно, если повесить FillData на конструктор, то текст (свойство текст) в 
        ///комбобоксах переписывается почему-то.. а на Shown нет.
        private void FormAttr_Shown(object sender, EventArgs e)
        {
             FillData();  
        }
        
        ///Контекстное меню с пунктом Clear.
        private void CmMenuItem_Click(object sender, EventArgs e)
        {            
            string ControlName = sys.GetControlNameByMenuStripItem(sender);            
            if (sender == cmAttr_N1)
            {
                if (ControlName == "tbLinkToStr")   tbLinkToStr.Text   = "";
                if (ControlName == "tbAttrLinkStr") tbAttrLinkStr.Text = "";
                if (ControlName == "tbTable")       tbTableStr.Text       = "";
                if (ControlName == "tbField1")      tbField1.Text      = "";
                if (ControlName == "tbField2")      tbField2.Text      = "";
                if (ControlName == "tbComment")     tbComment.Text     = "";  
            }
            if (sender == cmAttr_N2)
            { 
                ReadArrayHist();
                object control = sys.GetControlByMenuStripItem(sender);
                string Value = GetHistoryValue(control);
                sys.SM(Value, MessageType.Information);                                        
            }
            if (sender == cmAttr_N3)
            { 
                WriteArrayHist();
            } 
            
        }
        
        ///Доступность компонентов.        
        private void EnableDisable()
        {          
            if (operation == Operation.Del) return;
            
            if ((tbKindStr.SelectedIndex == 2) && (tbTypeStr.SelectedIndex == 3))
            {
                sys.SM("Wrong combination of Kind and Type!");
                return;
            }
            
            //Поле + Атрибут из базы данных: Table, Field1, Mask, Comment
            //Поле + Системный: Comment
            //Поле + Вычисляемый: Код, Mask, Comment
            
            //Сcылка + Атрибут из базы данных: LinkTo, Table, Field1, Comment
            //Сcылка + Системный: Comment
            //Сcылка + Вычисляемый: LinkTo, Код, Comment.
            
            //Универсальная ссылка + Атрибут из базы данных:  Table, Field1, Field2, Comment
            //Универсальная ссылка + Системный: Comment 
            //Универсальная ссылка + Вычисляемый: Код, Comment
           
            //Массив + Атрибут из базы данных: LinkTo, LinkAttr, Table, Field1, Comment + Events.
            //Массив + Системный: Comment
            //Массив + Вычисляемый: Ошибка!!!
            
            //Field
			//Link
			//Universal link
			//Array
            
            //Field from the database
			//Systemic
			//Calculated MSQL 
			            
            tbTableStr.Enabled    = (tbKindStr.SelectedIndex == 0); 
            tbField1.Enabled      = (tbKindStr.SelectedIndex == 0);
            tbField2.Enabled      = ((tbKindStr.SelectedIndex == 0) && (tbTypeStr.SelectedIndex == 2));
            
            bool intLink = false;           
            if ((tbKindStr.SelectedIndex == 0) && (tbTypeStr.SelectedIndex == 1)) intLink = true;
            if ((tbKindStr.SelectedIndex == 0) && (tbTypeStr.SelectedIndex == 3)) intLink = true;
            if ((tbKindStr.SelectedIndex == 2) && (tbTypeStr.SelectedIndex == 1)) intLink = true;               
            tbLinkToStr.Enabled   = intLink;
            cbForeignKey.Enabled  = intLink;
            
            tbAttrLinkStr.Enabled = ((tbKindStr.SelectedIndex == 0) && (tbTypeStr.SelectedIndex == 3));
            tbCode.Enabled        = (tbKindStr.SelectedIndex == 2); 
            tbMask.Enabled        = ((tbTypeStr.SelectedIndex == 0) && (((tbKindStr.SelectedIndex == 0)) || ((tbKindStr.SelectedIndex == 2))));
                
            rb1.Enabled = tbAttrLinkStr.Enabled;
            rb2.Enabled = tbAttrLinkStr.Enabled;
            rb3.Enabled = tbAttrLinkStr.Enabled;
            rb4.Enabled = tbAttrLinkStr.Enabled; 
                        
            //tbTypeStr.Text
            //Поле 
            //Ссылка
            //Универсальная ссылка
            //Массив связанных объектов
            
            //tbKindStr.Text
            //Атрибут из базы данных
            //Системные
            //Вычисляемые на MSQL                  
        }
        
        ///Создание внешнего ключа.
        private bool ForeignKey(out string sqlForeignKey)
        { 
        	sqlForeignKey = "";
        	if (Var.con.serverType != ServerType.MSSQL) return true;
        	sqlForeignKey = "";
            string sql = GetSQLAction("AttrChange"); //sys.GetSection(this.QueryText, "AttrChange");
            
            //Старые данные:          
            string oldTableIDFrom      = Obj["Main1.ID"];               //Старая таблица ID, откуда.                 
            string oldFieldNameFrom    = Obj["Main1.FieldName"];             //Старое поле, откуда.                 
            string oldEntityIDTo       = Obj["Main1.RefEntityID"];           //Старая ссылка на указаную сущность ID, куда.                      
            
            //Новые данные:
            string newTableNameFrom    = tbTableStr.Text;                    //Новая таблица имя, откуда.
            string newFieldNameFrom    = tbField1.Text;                      //Новое поле, откуда.
            string newEntityBriefTo    = tbLinkToStr.Text;                   //Новая ссылка на указаную сущность сокращение, куда.               
            if (!tbTableStr.Enabled)   newTableNameFrom = "";
            if (!tbField1.Enabled)     newFieldNameFrom = "";
            if (!tbLinkToStr.Enabled)  newEntityBriefTo = "";
            
            sql = sql.Replace("Param_EntityID",         this.EntityID);
            sql = sql.Replace("Param_OperationAdd",     "Operation" + this.operation.ToString());
            sql = sql.Replace("Param_OldTableIDFrom",   Obj["Main1.ID"]);
            sql = sql.Replace("Param_OldFieldNameFrom", Obj["Main1.FieldName"]); 
            sql = sql.Replace("Param_OldEntityIDTo",    Obj["Main1.RefEntityID"]);             
            sql = sql.Replace("Param_NewTableNameFrom", newTableNameFrom);  
            sql = sql.Replace("Param_NewFieldNameFrom", newFieldNameFrom); 
            sql = sql.Replace("Param_NewEntityBriefTo", newEntityBriefTo);
                
            var dt = new System.Data.DataTable();
            if (!sys.SelectDT(DirectionQuery.Remote, sql, out dt)) return false; 
            string errorMes = dt.Value("ErrorMes"); 
            sqlForeignKey = dt.Value("SQLForeignKey");
            if (errorMes == "") return true;
            sys.SM(errorMes);
            return false;                    
        }
       
        
        ///Если поле пустое, а наименование заполнено, то создаем сокращение.
        private void TbBrief_Enter(object sender, EventArgs e)
        {
            if (tbBrief.Text == "") tbBrief.Text = tbName.Text.NameToBrief();
        }
           
        //Тексты запросов для удаления атрибута и для изменения.
        private string GetSQLAction(string action)
        {        	        	
        	const string attrDelete = "--(SectionBegin AttrDelete)                                                             " + Var.CR +
			"                                                                                                           " + Var.CR + 
			"   SELECT                                                                                                  " + Var.CR + 
			"    --FK.CONSTRAINT_NAME as ForeignKey,                                                                    " + Var.CR + 
			"      --FK.TABLE_CATALOG as FROM_TABLE_CATALOG,                                                            " + Var.CR + 
			"      --FK.TABLE_SCHEMA  as FROM_TABLE_SCHEMA,                                                             " + Var.CR + 
			"      FK.TABLE_NAME    as FROM_TABLE_NAME,                                                                 " + Var.CR + 
			"      FK.COLUMN_NAME   as FROM_COLUMN_NAME,                                                                " + Var.CR + 
			"      --PK.TABLE_CATALOG as TO_TABLE_CATALOG,                                                              " + Var.CR + 
			"      --PK.TABLE_SCHEMA  as TO_TABLE_SCHEMA,                                                               " + Var.CR + 
			"      PK.TABLE_NAME    as TO_TABLE_NAME,                                                                   " + Var.CR + 
			"      PK.COLUMN_NAME   as TO_COLUMN_NAME                                                                   " + Var.CR + 
			"     -- INTO #Tabl1                                                                                        " + Var.CR + 
			"    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE PK                                                            " + Var.CR + 
			"      JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C ON PK.CONSTRAINT_CATALOG=C.UNIQUE_CONSTRAINT_CATALOG " + Var.CR + 
			"           AND PK.CONSTRAINT_SCHEMA=C.UNIQUE_CONSTRAINT_SCHEMA                                             " + Var.CR + 
			"           AND PK.CONSTRAINT_NAME=C.UNIQUE_CONSTRAINT_NAME                                                 " + Var.CR + 
			"      JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE FK ON C.CONSTRAINT_CATALOG=PK.CONSTRAINT_CATALOG            " + Var.CR + 
			"           AND C.CONSTRAINT_SCHEMA=FK.CONSTRAINT_SCHEMA                                                    " + Var.CR + 
			"           AND C.CONSTRAINT_NAME=FK.CONSTRAINT_NAME                                                        " + Var.CR + 
			"           AND PK.ORDINAL_POSITION=FK.ORDINAL_POSITION                                                     " + Var.CR + 
			"    WHERE PK.TABLE_NAME = 'TableNameAttr'                                                                  " + Var.CR + 
			"          AND PK.COLUMN_NAME = 'FieldNameAttr'                                                             " + Var.CR + 
			"    ORDER BY FK.CONSTRAINT_NAME, PK.ORDINAL_POSITION                                                       " + Var.CR + 		                                                                                                     
	    	"--(SectionEnd AttrDelete)      " + Var.CR;
	    		    		    		   
	    	const string attrChange = 
			"--(SectionBegin AttrChange)                                                                                       " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"--Код для создания или удаления внешнего ключа таблицы при добавлянии, удалении, изменении атрибута.              " + Var.CR + 
			"--Код только для MSSQL.                                                                                           " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"-- Алгоритм действий:                                                                                             " + Var.CR + 
			"--1.  Проверить что нет ссылки с старой таблицы и старого поля этого атрибута.                                    " + Var.CR + 
			"--2.  НАЙДЕНА ССЫЛКА:                                                                                             " + Var.CR + 
			"--3.    Если старая таблица = новой таблице и старое поле = новому полю то:                                       " + Var.CR + 
			"--4.      Если создание ключа, то:                                                                                " + Var.CR + 
			"--5.        Если ссылка на новую таблицу, то ничего не делаем.                                                    " + Var.CR + 
			"--6.        Если ссылка на другую таблицу то удаляем ключ.                                                        " + Var.CR + 
			"--7.      Если удаление ключа, то удаляем ключ.                                                                   " + Var.CR + 
			"--8.    Если старая таблица <> новой таблице или старое поле <> новому полю то:                                   " + Var.CR + 
			"--9.      Если создание ключа, то удаляем ключ.                                                                   " + Var.CR + 
			"--10.     Если удаление ключа, то удаляем ключ.                                                                   " + Var.CR + 
			"--11. НЕ НАЙДЕНА ССЫЛКА:                                                                                          " + Var.CR + 
			"--12.    Ничего не делаем.                                                                                        " + Var.CR + 
			"--13. ===Далее если только создание ссылки, если удаление, то выходим.                                            " + Var.CR + 
			"--14. ===Проверить что нет ссылки с новой таблицы и нового поля этого атрибута.                                   " + Var.CR + 
			"--15. НАЙДЕНА ССЫЛКА:                                                                                             " + Var.CR + 
			"--16.   Если ссылка указывает на правильную таблицу, то ничего не делаем.                                         " + Var.CR + 
			"--17.   Если ссылка указывает на другую таблицу, то удаляем ключ.                                                 " + Var.CR + 
			"--18. НЕ НАЙДЕНА ССЫЛКА:                                                                                          " + Var.CR + 
			"--19.   Создаем новый ключ.                                                                                       " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"DECLARE @EntityID            varchar(100) = 'Param_EntityID'         --Сущность на которой меняем атрибут.        " + Var.CR + 
			"DECLARE @Operation           varchar(100) = 'Param_OperationAdd'                 --Операция. Только Add или Del.  " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"--Старые данные:                                                                                                  " + Var.CR + 
			"--Имена старых таблиц нужно определить по ID так как имени нет.                                                   " + Var.CR + 
			"DECLARE @OldTableIDFrom      varchar(100) = 'Param_OldTableIDFrom'    --Старая таблица ID, откуда.                " + Var.CR + 
			"DECLARE @OldTableNameFrom    varchar(100)                             --Старая таблица имя, откуда.  (Определяем)  " + Var.CR + 
			"DECLARE @OldFieldNameFrom    varchar(100) = 'Param_OldFieldNameFrom'  --Старое поле, откуда.                      " + Var.CR + 
			"DECLARE @OldEntityIDTo       varchar(100) = 'Param_OldEntityIDTo'     --Старая ссылка на указаную сущность ID, куда.          " + Var.CR + 
			"DECLARE @OldTableNameTo      varchar(100)                             --Старая таблица, куда.        (Определяем)  " + Var.CR + 
			"DECLARE @OldIDFieldNameTo    varchar(100)                             --Старая поле таблицы, куда.   (Определяем)  " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"--Новые данные:                                                                                                   " + Var.CR + 
			"DECLARE @NewTableNameFrom    varchar(100) = 'Param_NewTableNameFrom'  --Новая таблица имя, откуда.                " + Var.CR + 
			"DECLARE @NewFieldNameFrom    varchar(100) = 'Param_NewFieldNameFrom'  --Новое поле, откуда.                       " + Var.CR + 
			"DECLARE @NewEntityBriefTo    varchar(100) = 'Param_NewEntityBriefTo'  --Новая ссылка на указаную сущность сокращение, куда.               " + Var.CR + 
			"DECLARE @NewTableNameTo      varchar(100)                             --Новая таблица имя, куда.    (Определяем)  " + Var.CR + 
			"DECLARE @NewIDFieldNameTo    varchar(100)                             --Новая таблица поле, куда.   (Определяем)                                   " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"--Вспомогательные переменные                                                                                      " + Var.CR + 
			"DECLARE @ErrorMes            varchar(8000) = ''                                                                   " + Var.CR + 
			"DECLARE @TestError           int = 0                                                                              " + Var.CR + 
			"DECLARE @SQLForeignKey      varchar(8000) = ''                                                                    " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"--Определяем имя таблицы (старой) с которой ссылка.                                                               " + Var.CR + 
			"SELECT @OldTableNameFrom = Name FROM fbaTable WHERE ID = @OldTableIDFrom                                          " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"--Определяем старое имя таблицы и старое имя поле куда ссылка.                                                    " + Var.CR + 
			"SELECT                                                                                                            " + Var.CR + 
			"  @OldTableNameTo   = t1.Name,                                                                                    " + Var.CR + 
			"  @OldIDFieldNameTo = t1.IDFieldName                                                                              " + Var.CR + 
			"FROM fbaTable t1                                                                                                  " + Var.CR + 
			"  INNER JOIN fbaEntity t2 ON t1.TableEntityID = t2.ID                                                             " + Var.CR + 
			"WHERE t1.Type = 1 AND t2.ID = @OldEntityIDTo                                                                      " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"--Определяем новое имя таблицы и новое поле куда ссылка.                                                          " + Var.CR + 
			"SELECT                                                                                                            " + Var.CR + 
			"  @NewTableNameTo   = t1.Name,                                                                                    " + Var.CR + 
			"  @NewIDFieldNameTo = t1.IDFieldName                                                                              " + Var.CR + 
			"FROM fbaTable t1                                                                                                  " + Var.CR + 
			"  INNER JOIN fbaEntity t2 ON t1.TableEntityID = t2.ID                                                             " + Var.CR + 
			"WHERE t1.Type = 1 AND t2.Brief = @NewEntityBriefTo                                                                " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"--Проверка на правильность данных.                                                                                " + Var.CR + 
			"--1. Проверка на то, что старая таблица и старое поле существуют.                                                 " + Var.CR + 
			"--2. Проверка на то, что новая таблица и новое поле существуют.                                                   " + Var.CR + 
			"--3. Проверка на то, что старая таблица принадлежит той же сущности что и новая.                                  " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"SELECT @TestError = 1 from INFORMATION_SCHEMA.COLUMNS                                                             " + Var.CR + 
			"WHERE TABLE_NAME = @OldTableNameFrom AND COLUMN_NAME = @OldFieldNameFrom                                          " + Var.CR + 
			"IF (@TestError = 0)                                                                                               " + Var.CR + 
			"BEGIN                                                                                                             " + Var.CR + 
			"  SET @ErrorMes = 'Ошибка. Не найдена таблица ' + @OldTableNameFrom + ' или поле ' + @OldFieldNameFrom            " + Var.CR + 
			"  SELECT @ErrorMes AS ErrorMes, @SQLForeignKey AS SQLForeignKey                                                   " + Var.CR + 
			"  RETURN                                                                                                          " + Var.CR + 
			"END                                                                                                               " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"SET @TestError = 0                                                                                                " + Var.CR + 
			"SELECT @TestError = 1 from INFORMATION_SCHEMA.COLUMNS                                                             " + Var.CR + 
			"WHERE TABLE_NAME = @NewTableNameFrom AND COLUMN_NAME = @NewFieldNameFrom                                          " + Var.CR + 
			"IF (@TestError = 0)                                                                                               " + Var.CR + 
			"BEGIN                                                                                                             " + Var.CR + 
			"  SET @ErrorMes = 'Ошибка. Не найдена таблица ' + @NewTableNameFrom + ' или поле ' + @NewFieldNameFrom            " + Var.CR + 
			"  SELECT @ErrorMes AS ErrorMes, @SQLForeignKey AS SQLForeignKey                                                   " + Var.CR + 
			"  RETURN                                                                                                          " + Var.CR + 
			"END                                                                                                               " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"SET @TestError = 0                                                                                                " + Var.CR + 
			"SELECT @TestError = 1 FROM                                                                                        " + Var.CR + 
			"(SELECT                                                                                                           " + Var.CR + 
			"  ISNULL((SELECT TableEntityID FROM fbaTable WHERE Name = @OldTableNameFrom), -1) as Old1,                        " + Var.CR + 
			"  ISNULL((SELECT TableEntityID FROM fbaTable WHERE Name = @NewTableNameFrom), -2) as New1                         " + Var.CR + 
			") t1  WHERE (Old1 <> New1) OR (Old1 <> @EntityID) OR (New1 <> @EntityID)                                          " + Var.CR + 
			"IF (@TestError = 1)                                                                                               " + Var.CR + 
			"BEGIN                                                                                                             " + Var.CR + 
			"  SET @ErrorMes = 'Ошибка. Сущности старой и новой таблицы не совпадают'                                          " + Var.CR + 
			"  SELECT @ErrorMes AS ErrorMes, @SQLForeignKey AS SQLForeignKey                                                   " + Var.CR + 
			"  RETURN                                                                                                          " + Var.CR + 
			"END                                                                                                               " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"DECLARE @ForeignKey      varchar(1000) = ''                                                                       " + Var.CR + 
			"DECLARE @TO_TABLE_NAME   varchar(1000) = ''                                                                       " + Var.CR + 
			"SELECT                                                                                                            " + Var.CR + 
			"  @ForeignKey = FK.CONSTRAINT_NAME,                                                                               " + Var.CR + 
			"  @TO_TABLE_NAME = PK.TABLE_NAME                                                                                  " + Var.CR + 
			"FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE PK                                                                       " + Var.CR + 
			"  JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C ON PK.CONSTRAINT_CATALOG=C.UNIQUE_CONSTRAINT_CATALOG          " + Var.CR + 
			"       AND PK.CONSTRAINT_SCHEMA=C.UNIQUE_CONSTRAINT_SCHEMA                                                        " + Var.CR + 
			"       AND PK.CONSTRAINT_NAME=C.UNIQUE_CONSTRAINT_NAME                                                            " + Var.CR + 
			"  JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE FK ON C.CONSTRAINT_CATALOG=PK.CONSTRAINT_CATALOG                       " + Var.CR + 
			"       AND C.CONSTRAINT_SCHEMA=FK.CONSTRAINT_SCHEMA                                                               " + Var.CR + 
			"       AND C.CONSTRAINT_NAME=FK.CONSTRAINT_NAME AND PK.ORDINAL_POSITION=FK.ORDINAL_POSITION                       " + Var.CR + 
			"WHERE                                                                                                             " + Var.CR + 
			"  FK.TABLE_NAME      = @OldTableNameFrom                                                                          " + Var.CR + 
			"  AND FK.COLUMN_NAME = @OldFieldNameFrom                                                                          " + Var.CR + 
			"ORDER BY FK.CONSTRAINT_NAME, PK.ORDINAL_POSITION                                                                  " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"IF (@ForeignKey <> '')                                                                                            " + Var.CR + 
			"BEGIN                                                                                                             " + Var.CR + 
			"  IF ((@Operation = 'OperationDel') OR                                                                            " + Var.CR + 
			"     (@OldTableNameFrom <> @NewTableNameFrom) OR                                                                  " + Var.CR + 
			"     (@OldFieldNameFrom <> @NewFieldNameFrom) OR                                                                  " + Var.CR + 
			"     (@OldTableNameTo   <> @TO_TABLE_NAME))                                                                       " + Var.CR + 
			"  BEGIN                                                                                                           " + Var.CR + 
			"     SET @SQLForeignKey = @SQLForeignKey + 'ALTER TABLE ' + @OldTableNameFrom +                                   " + Var.CR + 
			"                          ' DROP CONSTRAINT ' + @ForeignKey + ';' + CHAR(13) + CHAR(10)                           " + Var.CR + 
			"  END                                                                                                             " + Var.CR + 
			"END                                                                                                               " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"/*SELECT                                                                                                          " + Var.CR + 
			"  @OldTableIDFrom AS OldTableIDFrom,       --Старая таблица ID, откуда.                                           " + Var.CR + 
			"  @OldTableNameFrom    AS OldTableNameFrom, --Старая таблица имя, откуда.  (Определяем)                           " + Var.CR + 
			"  @OldFieldNameFrom    AS OldFieldNameFrom, --Старое поле, откуда.                                                " + Var.CR + 
			"  @OldEntityIDTo       AS OldEntityIDTo,    --Старая ссылка на указаную сущность ID, куда.                        " + Var.CR + 
			"  @OldTableNameTo      AS OldTableNameTo,   --Старая таблица, куда.        (Определяем)                           " + Var.CR + 
			"  @OldIDFieldNameTo    AS OldIDFieldNameTo, --Старая поле таблицы, куда.   (Определяем)                           " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"  @NewTableNameFrom    AS NewTableNameFrom, --Новая таблица имя, откуда.                                          " + Var.CR + 
			"  @NewFieldNameFrom    AS NewFieldNameFrom, --Новое поле, откуда.                                                 " + Var.CR + 
			"  @NewEntityBriefTo    AS NewEntityBriefTo, --Новая ссылка на указаную сущность сокращение, куда.                 " + Var.CR + 
			"  @NewTableNameTo      AS NewTableNameTo,   --Новая таблица имя, куда.    (Определяем)                            " + Var.CR + 
			"  @NewIDFieldNameTo    AS NewIDFieldNameTo, --Новая таблица поле, куда.   (Определяем)                            " + Var.CR + 
			"  @Operation           AS Operation                                                                               " + Var.CR + 
			"--return                                                                                                          " + Var.CR + 
			"*/                                                                                                                " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"IF (@Operation = 'OperationDel')                                                                                  " + Var.CR + 
			"BEGIN                                                                                                             " + Var.CR + 
			"  SELECT @ErrorMes AS ErrorMes, @SQLForeignKey AS SQLForeignKey                                                   " + Var.CR + 
			"  RETURN                                                                                                          " + Var.CR + 
			"END                                                                                                               " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"DECLARE @TO_COLUMN_NAME  varchar(1000)                                                                            " + Var.CR + 
			"SELECT                                                                                                            " + Var.CR + 
			"  @ForeignKey = FK.CONSTRAINT_NAME,                                                                               " + Var.CR + 
			"  @TO_TABLE_NAME = PK.TABLE_NAME,                                                                                 " + Var.CR + 
			"  @TO_COLUMN_NAME = PK.COLUMN_NAME                                                                                " + Var.CR + 
			"FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE PK                                                                       " + Var.CR + 
			"  JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C ON PK.CONSTRAINT_CATALOG=C.UNIQUE_CONSTRAINT_CATALOG          " + Var.CR + 
			"       AND PK.CONSTRAINT_SCHEMA=C.UNIQUE_CONSTRAINT_SCHEMA                                                        " + Var.CR + 
			"       AND PK.CONSTRAINT_NAME=C.UNIQUE_CONSTRAINT_NAME                                                            " + Var.CR + 
			"  JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE FK ON C.CONSTRAINT_CATALOG=PK.CONSTRAINT_CATALOG                       " + Var.CR + 
			"       AND C.CONSTRAINT_SCHEMA=FK.CONSTRAINT_SCHEMA AND C.CONSTRAINT_NAME=FK.CONSTRAINT_NAME                      " + Var.CR + 
			"       AND PK.ORDINAL_POSITION=FK.ORDINAL_POSITION                                                                " + Var.CR + 
			"WHERE                                                                                                             " + Var.CR + 
			"      FK.TABLE_NAME  = @NewTableNameFrom                                                                          " + Var.CR + 
			"  AND FK.COLUMN_NAME = @NewFieldNameFrom                                                                          " + Var.CR + 
			"ORDER BY FK.CONSTRAINT_NAME, PK.ORDINAL_POSITION                                                                  " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"IF (@ForeignKey <> '')                                                                                            " + Var.CR + 
			"BEGIN                                                                                                             " + Var.CR + 
			"   IF ((@NewTableNameTo  <> @TO_TABLE_NAME) OR                                                                    " + Var.CR + 
			"      (@NewIDFieldNameTo <> @TO_COLUMN_NAME))                                                                     " + Var.CR + 
			"  BEGIN                                                                                                           " + Var.CR + 
			"     SET @SQLForeignKey = @SQLForeignKey + 'ALTER TABLE ' + @OldTableNameFrom +                                   " + Var.CR + 
			"                          ' DROP CONSTRAINT ' + @ForeignKey + ';' + CHAR(13) + CHAR(10)                           " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"  END                                                                                                             " + Var.CR + 
			"END                                                                                                               " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"DECLARE @ForeignKeyName varchar(100) = 'FK_' + @NewTableNameFrom + '_' + @NewIDFieldNameTo                        " + Var.CR + 
			"SET @SQLForeignKey = @SQLForeignKey + 'ALTER TABLE ' + @NewTableNameFrom +                                        " + Var.CR + 
			"                     ' ADD CONSTRAINT ' + @ForeignKeyName + ' FOREIGN KEY(' + @NewFieldNameFrom + ') REFERENCES ' + " + Var.CR + 
			"                     @NewTableNameTo + '(' + @NewIDFieldNameTo + ');'                                             " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"SELECT @ErrorMes AS ErrorMes, @SQLForeignKey AS SQLForeignKey                                                     " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
			"                                                                                                                  " + Var.CR + 
	        "--(SectionEnd AttrChange)   ";
	    	
			//Для других серверов, кроме MSSQL код создания внених ключей не написан.
			if (Var.con.serverType == ServerType.MSSQL)
			{
		    	if (action == "AttrDelete") return attrDelete;
		    	if (action == "AttrChange") return attrChange;
			}
	    	return "";        
        }
        
        ///раскрываем список доступных полей при ыраскрытии выпадающего списка.
		private void TbField1DropDown(object sender, EventArgs e)
		{
			GetListAvalibleFields(tbTableStr.Text);
		}        
	}
}


 /*var DT1 = new System.Data.DataTable();
            string SQL = "";
            if (Var.con.ServerType == "SQLite")
            {
                SQL = "pragma table_info('" + TableName + "')";           
                if (!sys.SelectDT("Remote", SQL, out DT1)) return false;
                //sys.DTView(DT, "DT1", "DT1");
                DT1.Columns.RemoveAt(5);
                DT1.Columns.RemoveAt(4);
                DT1.Columns.RemoveAt(3);
                DT1.Columns.RemoveAt(2);
                DT1.Columns.RemoveAt(0);
                //sys.DTView(DT, "DT2", "DT2");
                var dataView = new DataView(DT1);
                dataView.Sort = "Name ASC";
            }
            if (Var.con.ServerType == "MSSQL")
            {
                SQL = "SELECT COLUMN_NAME AS Name FROM information_schema.columns WHERE table_name = '" + TableName + "'";
                if (!sys.SelectDT("Remote", SQL, out DT1)) return false;   
            } 
            
            if (Var.con.ServerType == "Postgre")
            {
                SQL = "SELECT table_name, column_name from information_schema.columns WHERE table_schema = 'public' and table_name = '" + TableName + "'";
                if (!sys.SelectDT("Remote", SQL, out DT1)) return false;                               
            }    
            */