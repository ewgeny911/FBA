
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 17.09.2017
 * Время: 18:01
*/
 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FBA
{       
    
	/// <summary>
	/// Форма фильтра универсальная. Для всех сущностей.
	/// </summary>
	public partial class FormFilter : Form
    {
        //=============================================================================
        #region Region. Переменные формы.
        
        /// <summary>
        /// Количество полосок Custom фильтров которые были добавлены, без учета их удаления.
        /// </summary>
        public int  FilterCustomCount     = 0;  

		/// <summary>
        /// Реальное количество полосок Custom фильтров.
        /// </summary>        
        public int  FilterCustomCountPnl  = 0;     
        
        /// <summary>
        /// Результат закрытия формы.
        /// </summary>
        public int  ResultClose           = 0;     
        
        /// <summary>
        /// Для ускорения работы, чтобы не срабатывали события в процессе создания компонентов полоски фильтра.    
        /// </summary>
        public bool ProcessCompAdd        = false; 

		/// <summary>
        /// Панель Static фильтра на которой содержатся все компоненты.
        /// </summary>      
        public Panel PanelStatic;                  
        
        /// <summary>
        /// Сcылка на форму, которая вызвала этот фильтр.
        /// </summary>
        public Object FormRef;                     
        
        /// <summary>
        /// Ссылка на форму со статическим фильтром.
        /// </summary>
        public Object FormStaticFilter;            
                
        /// <summary>
        /// Ссылка на метод, собирающий Static фильтр.   
        /// </summary>
        public MethodInfo MethodFilterStatic;      

        /// <summary>
        /// Объект аккумулирует все значения фильтра.
        /// </summary>
        public FilterObj filter;                   
        
        /// <summary>
        /// Переменная чтобы отличить программный вызов метода на CheckBoxClick, от клика пользователя.
        /// </summary>
        private bool DoEnableDisable      = true; 
        
        /// <summary>
        /// Признак загрузки Static фильтра на форму.
        /// </summary>
        private bool FilterStaticSet;     
        
        /// <summary>
        /// Признак загрузки Custom  фильтра на форму.
        /// </summary>
        private bool FilterCustomSet;     
        
        /// <summary>
        /// Признак загрузки Universal  фильтра на форму.               
        /// </summary>
        private bool FilterUniversalSet;  

        /// <summary>
        /// /Признак что таблица Attr была загружена из filter и её нужно пересобрать.
        /// </summary>
        private bool AttrWasSet = false;  

        #endregion Region. Переменные формы.
        //=============================================================================
        
        //=============================================================================
        #region Region. Методы общие.
                                              
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormFilter() 
        {                         
            InitializeComponent();                                
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult     = System.Windows.Forms.DialogResult.OK;                                     
            cbFilterCustomCondition.SelectedIndex = 0;
            DoubleBuffered = true;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Font = Var.font1;
            
            //Для ускорения ресайза формы.
            this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };

        }
       
		/// <summary>
		/// Показ фильтра: 
        /// FilterObj filter = new FilterObj();
        /// FormFilter.Filter(this, "ДогСтрах", "FormFilt", ref filter);        
        /// Это главный метод (СТАТИЧЕСКИЙ!), который показывает фильтр.  
		/// </summary>
		/// <param name="formRef">Ссылка на вызывающую этот фильтр форму. Обычно это форма справочника</param>
		/// <param name="entityBrief">Сокращение сущности</param>
		/// <param name="gridLeft">Чтобы высчитать координаты появления формы фильтра на экране относительно грида.</param>
		/// <param name="gridTop">Чтобы высчитать координаты появления формы фильтра на экране относительно грида.</param>
		/// <param name="filter">Объект фильтра. Все настройки фильтра в нём</param>
		/// <param name="outerWHERE">Дополнительное условие WHERE, которые передается вызывающим кодом</param>
		/// <returns>Если фильтр применяется, то true</returns>
        public static bool Filter(Object formRef,
                                  string entityBrief,                                
                                  int gridLeft, 
                                  int gridTop,  
                                  ref FilterObj filter,                           
                                  string outerWHERE        = ""
                                  )
        {           
        	if (sys.IsEmpty(entityBrief))
            {
                sys.SM("Не указана сущность при вызове формы фильтра!");
                return false;
            }
            var f1 = new FormFilter();
            f1.filter = filter;
            f1.filter.OuterWHERE = outerWHERE;
            //F1.Icon = ((FormFBA)FormRef).Icon; не работает.
            filter.EntityBrief = entityBrief;
 
            //Установка местоположения появления формы.   
            Point p1 = new Point(gridLeft, gridTop);
            Point p2 = f1.PointToScreen(p1);
            
            f1.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            f1.Left    = p2.X + 70;
            f1.Top     = p2.Y - 20;                               
            f1.FormRef = formRef;
            f1.cmFilterListN6.Visible = Var.UserIsAdmin;
            f1.cmFilterListN8.Visible = Var.UserIsAdmin;
            f1.cmFilterLine2.Visible  = Var.UserIsAdmin;
            
            f1.dgvAttr.Columns.Add("Name", "Name");
            f1.dgvAttr.Columns.Add("Brief", "Brief");
            f1.dgvAttr.Columns.Add("Mask", "Mask");
            f1.dgvAttr.Columns.Add("Width", "Width");
            f1.dgvAttr.Columns.Add("Sort", "Sort");
            f1.dgvAttr.Columns[0].Width = 100;
            f1.dgvAttr.Columns[1].Width = 100;
            f1.dgvAttr.Columns[2].Width = 100;
            f1.dgvAttr.Columns[3].Width = 100;
            f1.dgvAttr.Columns[4].Width = 50;

            //По умолчанию добавляем сразу один первый столбец - ИДОбъекта.
            f1.AddObjectIDColumn();

            f1.AttrSetString(f1.filter.Attr);

            bool resultLoadFilter = true;
            //if (F1.filter.FilterID == "")
            resultLoadFilter = f1.FilterLoad();
            if (!resultLoadFilter)
            {
                f1.filter.EntityID = sys.GetEntityID(entityBrief);                
                f1.TabSet(0);               
            }
            if (f1.tbFilterName.Text == "") f1.tbFilterName.Text = "Basic"; 
            
            if ((f1.filter.AssemblyName != "") && (f1.filter.FormStaticName != ""))
            {
               //Assembly assembly;

                Assembly assembly = ProjectService.ProjectLoad(f1.filter.AssemblyName, Var.enterMode);
                if (assembly != null) //sys.FindAssembly(F1.filter.AssemblyName, out assembly))
                {
                    Object formStatic = assembly.CreateInstance("FBA." + f1.filter.FormStaticName);
                    if (formStatic == null) return false;
                    Control pnl2 = ((Form)formStatic).Controls.Find(f1.filter.PanelStaticName, true).FirstOrDefault();
                    Type tp = formStatic.GetType();
                    MethodInfo mi = null;
                    if (tp != null) mi = tp.GetMethod(f1.filter.MethodStaticName);
                    f1.PanelStatic = (Panel)pnl2;
                    f1.FormStaticFilter = formStatic;
                    f1.MethodFilterStatic = mi;

                    //Установка Static фильтра.
                    if (pnl2 != null)
                    {
                        pnl2.Parent = f1.panelFilterStatic;
                        f1.btnStaticSet.Enabled = true; //tabControlFilter.DoTabVisible(F1.tabControlFilter.TabPages[0], true);                  
                    }
                    else
                    {
                        f1.btnStaticSet.Enabled = false; //Скрыть вкладку статического фильтра, если его нет (при tp == null).                  
                    }
                    if (!resultLoadFilter) f1.TabSet(4); //Переключение вкладки  
                    else f1.TabSet(0);
                    f1.FilterSet(0);
                }
                else sys.SM("Не найдена форма статического фильтра!");                           
            }
            else
            {
                f1.TabSet(0);
                if (!sys.IsEmpty(filter.Name)) f1.tbFilterName.Text = filter.Name; //Имя фильтра. 
            }

            if (f1.ShowDialog() != DialogResult.OK) return false;
            filter = f1.filter;  
            if (filter == null) return false;             
            return true;                      
        }      
        
        /// <summary>
        /// По умолчанию добавляем сразу один первый столбец - ИДОбъекта.
        /// </summary>
        private void AddObjectIDColumn()
        {           
            var attr = new string[5];
            attr[0] = ParserData.KeyBrief.ObjectID;
            attr[1] = ParserData.KeyBrief.ObjectID;
            attr[2] = "S10";
            attr[3] = "180";
            attr[4] = "No";
            dgvAttr.Rows.Insert(0, attr);
        }  
        
        /// <summary>
        /// Восстановление всего фильтра из БД.
        /// </summary>
        /// <returns>Если фильтр успешно загружен,то true</returns>
        private bool FilterLoad()         
        {                                                                                          
            if (!FormFilter.FilterRead(ref filter, true)) return false;  
            FilterStaticSet    = false;
            FilterCustomSet    = false;
            FilterUniversalSet = false;                          
            AttrSetString(filter.Attr);
            return true;
        }                                             
        
        /// <summary>
        /// Показать форму выбранного фильтра.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvList_DoubleClick(object sender, EventArgs e)
        {
            filter.FilterID = dgvList.DataGridViewSelected("ID");                  
            FilterLoad();
            FilterSet(0);
        }
                                                   
        /// <summary>
        /// Включить-выключить фильтр.
        /// </summary>
        private void EnableOrDisableFilter() 
        {                                     
            DoEnableDisable = false;  
            
            //Включить-выключить весь Static фильтр.
            cbStatic.Checked                = (filter.CheckedStatic == 1);     
            panelFilterStatic.Enabled       = (filter.CheckedStatic == 1);
            btnStaticToUniversal.Enabled    = (filter.CheckedStatic == 1);
            
            //Включить-выключить весь Custom фильтр.
            cbCustom.Checked                = (filter.CheckedCustom == 1);
            panelFilterCustom.Enabled       = (filter.CheckedCustom == 1);
            cbFilterCustomCondition.Enabled = (filter.CheckedCustom == 1);
            btnFilterCustomAdd.Enabled      = (filter.CheckedCustom == 1);
            btnCustomToUniversal.Enabled    = (filter.CheckedCustom == 1);
            
            //Включить-выключить весь Universal фильтр.
            cbUniversal.Checked             = (filter.CheckedUniversal == 1);                  
            cbExample.Enabled               = (filter.CheckedUniversal == 1); 
            
            DoEnableDisable = true; 
        }        
           
        /// <summary>
        /// Это значек, отмечает выбранный фильтра (не выбранную вкладку, а выбранный фильтр)
        /// </summary>
        private void ImageTabSet()
        {
            if (filter.CheckedStatic == 1) 
            {
                btnStaticSet.Image         = global::FBA.Resource.Yes_24;
                btnStaticSet.ImageAlign    = System.Drawing.ContentAlignment.MiddleLeft;
                btnCustomSet.Image         = null;
                btnUniversalSet.Image      = null;
            }
            if (filter.CheckedCustom == 1) 
            {
                btnStaticSet.Image         = null;
                btnCustomSet.Image         = global::FBA.Resource.Yes_24;
                btnCustomSet.ImageAlign    = System.Drawing.ContentAlignment.MiddleLeft;
                btnUniversalSet.Image      = null;
            }
            if (filter.CheckedUniversal == 1) 
            {
                btnStaticSet.Image         = null;
                btnCustomSet.Image         = null;
                btnUniversalSet.Image      = global::FBA.Resource.Yes_24;
                btnUniversalSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            }
        }
          
        /// <summary>
        /// Установка соотвтетсвующей вкладки. Это не установка фильтра, а лишь переключение вкладки для просмотра.  
        /// </summary>
        /// <param name="indexTab">Индекс вкладки</param>
        private void TabSet(int indexTab)
        {                                        
            bool p1 = false;
            bool p2 = false; 
            bool p3 = false;
            bool p4 = false;                                                                  
            if (indexTab == 0) 
            {
                if (filter.CheckedStatic    == 1) indexTab = 1;
                if (filter.CheckedCustom    == 1) indexTab = 2;
                if (filter.CheckedUniversal == 1) indexTab = 3;
            }
            if (indexTab == 0) indexTab = 4;

            if (indexTab == 1) 
            {
                p1 = true;
                panelFilterStatic_Base.Dock    = System.Windows.Forms.DockStyle.Fill;                
            }
            
            if (indexTab == 2) 
            {
                p2 = true;
                panelFilterCustom_Base.Dock    = System.Windows.Forms.DockStyle.Fill;               
            }
            
            if (indexTab == 3) 
            {
                p3 = true;
                panelFilterUniversal_Base.Dock = System.Windows.Forms.DockStyle.Fill;                                 
            }
              
            if (indexTab == 4) 
            {    
                panelFilterView_Base.Dock      = System.Windows.Forms.DockStyle.Fill; 
                
                //Восстановим таблицу атрибутов.                                 
                if (cmtAttrList.treeViewAttr.Nodes.Count == 0) cmtAttrList.LoadAttrTree(filter.EntityID);
                p4 = true;
            }
            
            panelFilterStatic_Base.Visible = p1 && (FormStaticFilter != null);
            panelFilterCustom_Base.Visible      = p2;
            panelFilterUniversal_Base.Visible   = p3; 
            panelFilterView_Base.Visible        = p4; 
            
            btnStaticSet.Checked                = p1;
            btnCustomSet.Checked                = p2;
            btnUniversalSet.Checked             = p3;
            btnViewSet.Checked                  = p4;
            btnStaticSet.Enabled = (FormStaticFilter != null);
        }              
              
        /// <summary>
        /// Заполнение компонентов фильтром.
        /// </summary>
        /// <param name="indexTab">Индекс вкладки</param>
        private void FilterSet(int indexTab)
        {           
            tbFilterName.Text  = filter.Name; //Имя фильтра.                                  
            if (indexTab == 0)
            {
                if (btnStaticSet.Checked)    indexTab = 1;
                if (btnCustomSet.Checked)    indexTab = 2;
                if (btnUniversalSet.Checked) indexTab = 3;
                if (btnViewSet.Checked)      indexTab = 4;
            }
            
            //Нужно ли делать переключение вкладки. 
            //Это будет делаться только первый раз когда фильтр.
            bool needSetTab = (indexTab == 0);
            
            if (indexTab == 0) 
            {
                if (filter.CheckedStatic    == 1) indexTab = 1;
                if (filter.CheckedCustom    == 1) indexTab = 2;
                if (filter.CheckedUniversal == 1) indexTab = 3;
            }
            
            //По умолчанию ставим 4. Если есть хотя бы один фильтр, эта строка не должна сработать.
            if (indexTab == 0) indexTab = 4;
            
            //Static фильтр.              
            if ((indexTab == 1) && (!FilterStaticSet))
            {
                Param.SetComponentValues(filter.FilterStatic, this.Controls);
                FilterStaticSet = true;
            }
            
            //Custom фильтр.            
            if ((indexTab == 2) && (!FilterCustomSet)) 
            {
                FilterCustomRestore(filter.FilterCustom);
                FilterCustomSet = true;
            }
            
            //Universal фильтр.
            if ((indexTab == 3) && (!FilterUniversalSet)) 
            {
                tbTextUniversal.Text = filter.FilterUniversal;
                FilterUniversalSet = true;
            }
                                          
            //Установка колонок.                
            if (indexTab == 4) 
            {
                AttrSetString(filter.Attr);            
            }
            
            //Переключение на нужную вкладку:
            if (needSetTab) TabSet(indexTab);
            
            ImageTabSet();
            EnableOrDisableFilter();
            string globalText = "";
            if (filter.FilterGlobal != 1) globalText = "(User)";
              else globalText = "(Global)";                          
            this.Text = "Filter: " + filter.EntityBrief + " " + globalText + ", ID " + filter.FilterID; 
            lbFilterName.Text = "Filter " + filter.FilterID + ":";
            if (filter.MaxRecords == -1) cbMax.Text = "Unlimited";
            else if (filter.MaxRecords == 0)
            {
                string rowCount;
                sys.GetDefaultRowCount(out rowCount);
                cbMax.Text = rowCount;
            }
            else cbMax.Text = filter.MaxRecords.ToString();
        }                          
         
        /// <summary>
        /// Шаблоны выражений WHERE.
        /// </summary>
        /// <param name="indexExample">Номер запроса для спрвки</param>
        /// <returns></returns>
        private string GetExample(int indexExample)
        {
            if (indexExample == 0) 
                return "ИсходныйДокумент = (SELECT TOP 1 D1.ObjectID FROM ДокНаИсхОплату D1 where СчетЛПУ = 153923)";           
            if (indexExample == 1)
                return "ДогСтрах.Номер = 'BK14565-115' and ВидДок <> 17 and  ДатаНачала <= GetDate() and ТекущийСтатус = 'Проведено'";
            if (indexExample == 2)
                return "Полис.Номер = 'BK14565-115' and ФЛ.Нафа = 'Петров' and ФЛ.Имя = 'Михаил' and ФЛ.ДатаРождения = '01.04.2018'";
            if (indexExample == 3)
                return "ISNULL(Загружен, 0) = 1 AND ПолноеИмяФайла = 'Импорт.csv'";
            if (indexExample == 4)
                return "ПсевдонимСущности.Объект.EntityID = 51879" + Var.CR +
                       "AND ПсевдонимСущности.Объект.ObjectID = 38575" + Var.CR +
                       "AND ПсевдонимСущности.Статус.Сокр = 'Действует'" + Var.CR +
                       "AND ПсевдонимСущности.ДатаИзменения = (SELECT MAX(СО1.ДатаИзменения)" + Var.CR +
                       "                        FROM СтатусОбъекта СО1" + Var.CR +
                       "                        WHERE СО1.Объект.EntityID = 220956" + Var.CR +
                       "                            AND СО1.Объект.ObjectID = 85897" + Var.CR +
                       "                            AND СО1.Статус.Сокр = 'Действует')"; 
            return "";
        }
                      
        /// <summary>
        /// Выбор шаблона выражения WHERE.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbExampleSelectedIndexChanged(object sender, EventArgs e)
        {                   
            string filterstr = GetExample(cbExample.SelectedIndex);
            if (filterstr != "") tbTextUniversal.Text = filterstr;
        }                    
        
        /// <summary>
        /// Галка WordWrap для универсального фильтра.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbUniversalWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            tbTextUniversal.WordWrap = cbUniversalWordWrap.Checked;
        }
        
        /// <summary>
        /// Общее событие для CheckBox включения/отключения фильтров: Static, Custom, Universal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCustomCheckedChanged(object sender, EventArgs e)
        {
            if (!DoEnableDisable) return;           
            int numTab = 0;
            bool check = ((CheckBox)sender).Checked;
            if ((sender == cbStatic) && (check)) numTab = 1;
            if ((sender == cbCustom) && (check)) numTab = 2;
            if ((sender == cbUniversal) && (check)) numTab = 3;
            filter.CheckedStatic = (numTab == 1).ToInt();
            filter.CheckedCustom = (numTab == 2).ToInt();
            filter.CheckedUniversal = (numTab == 3).ToInt();
            ImageTabSet();
            EnableOrDisableFilter();
        }
                     
        /// <summary>
        /// Все кнопки.
        /// Используем MouseDown чтобы чуть быстрее чем Click для пользователя срабатывало событие.
        /// Общее событие для кнопок переключения вкладок. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStaticSet_Click(object sender, MouseEventArgs e)
        {            
            if (sender == btnStaticSet)
            {
                TabSet(1);
                FilterSet(1);
            }
            if (sender == btnCustomSet)
            {
                TabSet(2);
                FilterSet(2);
            }
            if (sender == btnUniversalSet)
            {
                TabSet(3);
                FilterSet(3);
            }
            if (sender == btnViewSet)
            {
                TabSet(4);      //Переключение вкладки
                FilterSet(4);   //Дозагрузка всего.
            }
        }        
        
        /// <summary>
        /// Все кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmFilterListN1_Click(object sender, EventArgs e)
        {           
            string filterID         = dgvList.DataGridViewSelected("ID");
            string filterName       = dgvList.DataGridViewSelected( "Name");
            string filterGlobalStr  = dgvList.DataGridViewSelected("Global");

            int filterGlobal = 1;
            if (filterGlobalStr == "No") filterGlobal = 0;
            //Use
            if (sender == cmFilterListN7)
            {
                DialogResult = DialogResult.OK;
                ResultClose = 1;
                //Так как форма была поднята методом FilterShow то, то при закрытии формы возвращается объект filter.
                Close();
            }

            //Add                
            if (sender == cmFilterListN1) FilterNew();

            //Del
            if (sender == cmFilterListN2) FilterDelete(filterID, filterGlobal);

            //Copy to User
            if (sender == cmFilterListN4) FilterCopy(filterID, filterName, filterGlobal);

            //Refresh
            if (sender == cmFilterListN9) FilterListRefresh(filter.FilterID);

            //Set as Global
            if (sender == cmFilterListN6) FilterGlobalSet(filterID, true);

            //UnSet as Global
            if (sender == cmFilterListN8) FilterGlobalSet(filterID, false);
        }

		
		/// <summary>
		/// Все кнопки.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void BtnOkClick(object sender, EventArgs e)
        {                      
            //Так как форма была поднята методом FilterShow то, то при закрытии формы возвращается объект filter.
            //Применить изменения.
            if (sender == btnOk)
            {
                ResultClose = 1; 
                FilterGetString();
                //FormFilter.FilterSave(ref filter, false);
                Close(); 
            }
            
            //Выход без сохранения и применения изменений.
            if (sender == btnCancel)
            {
                ResultClose = 2;              
                Close(); 
            }
          
            //Сворачивание панели со списком фильтров.
            if (sender == tbFilter1)
            {
                //splitContainerFilter.Panel1Collapsed = !tbFilter1.Checked;
                pnlFilters.Visible = tbFilter1.Checked;
                splitter1.Visible = tbFilter1.Checked;
                if (tbFilter1.Checked) this.tbFilter1.Image = global::FBA.Resource.Prev_24;
                  else this.tbFilter1.Image = global::FBA.Resource.Next_24;  
            }
            
            //Сохранение всего фильтра в БД.
            if (sender == tbFilter2) 
            {
                FilterGetString();
                if (!CheckFilterBeforeSaveFilter()) return;
                FormFilter.FilterSave(ref filter, true);
                FilterListRefresh(filter.FilterID); 
            }
            //Сохранение всего фильтра в БД как нового.
            if (sender == tbFilter3) 
            {                                
                string filterNameNew = filter.Name;
                if (!sys.InputValue("Новое имя фильтра", "Новое имя фильтра", SizeMode.Small, ValueType.String ,ref filterNameNew)) return;
                FilterGetString();
                filter.Name = filterNameNew;
                filter.FilterID = "";
                if (!CheckFilterBeforeSaveFilter()) return;
                FormFilter.FilterSave(ref filter, true);
                //string FilterID = sys.DGSelected(dgvList, "ID");
                FilterListRefresh(filter.FilterID);                                        
            }
                                                                      
            //Добавление новой полоски фильтра.
            if (sender == btnFilterCustomAdd) FilterCustomAdd("true", "", "", "", "");                                  
        
            //Static фильтр в виде строки WHERE сделать универсальным фильтром.
            if (sender == btnStaticToUniversal)
            {
                tbTextUniversal.Text = FilterStaticGetWHERE();   
                TabSet(3);
                cbUniversal.Checked = true;   
            }
            
            //Custom фильтр в виде строки WHERE сделать универсальным фильтром.            
            if (sender == btnCustomToUniversal)
            {
                tbTextUniversal.Text = FilterCustomGetWHERE();              
                TabSet(3);
                cbUniversal.Checked = true;        
            }
        }
        
        #endregion Region. Методы общие.
        //=============================================================================]
        
        //=============================================================================
        #region Region. Методы статического фильтра.
         
        ///Очистка статического фильтра.
        private void FilterStaticClear(Control.ControlCollection controls)
        {
            if (PanelStatic == null) return;
            foreach(Control control in controls)
            {                      
                FilterStaticClear(control.Controls);                                                                
                string compType = control.GetType().ToString();
                compType = sys.TruncateType(compType, true);                  
                if (compType == "TextBox")          ((System.Windows.Forms.TextBox)control).Text        = "";
                else if (compType == "CheckBox")    ((System.Windows.Forms.CheckBox)control).Checked    = false;
                else if (compType == "ComboBox")    ((System.Windows.Forms.ComboBox)control).Text       = "";
                else if (compType == "RadioButton") ((System.Windows.Forms.RadioButton)control).Checked = false;
                else if (compType == "TabControl")  ((System.Windows.Forms.TabControl)control).SelectedIndex = 0;
                else control.Text  = "";                                                                               
            }           
        }
                
        /// <summary>
        /// Вызываем метод, собирающий Static фильтр.
        /// </summary>
        /// <returns>Строка WHERe Static фильтра</returns>
        private string FilterStaticGetWHERE()
        {                                 
            if (FormStaticFilter   == null) return "";
            if (MethodFilterStatic == null) return "";
            Type tp          = FormStaticFilter.GetType();
            var objParams    = new Object[2];
            objParams[0]     = FormRef;
            objParams[1]     = filter;            
            Object ObjResult = MethodFilterStatic.Invoke(FormStaticFilter, objParams); 
            return (string)ObjResult;    
        }
        
        #endregion Region. Методы статического фильтра.
        //=============================================================================
        
        //=============================================================================
        #region Region. Методы Custom фильтра - полоски.                        
  
        /// <summary>
        /// Включить-выключить полоску фильтра.
        /// </summary>
        /// <param name="numLine">Номер строки фильтра Custom. </param>
        /// <param name="check">Включить или отключить полоску Custom фильтра</param>
        private void FilterCustomEnabledLine(string numLine, bool check)
        {                    
            Control control1 = panelFilterCustom.Controls.Find("cb1N" + numLine, true).FirstOrDefault();
            Control control2 = panelFilterCustom.Controls.Find("cb2N" + numLine, true).FirstOrDefault();
            Control control3 = panelFilterCustom.Controls.Find("cb3N" + numLine, true).FirstOrDefault();
            Control control4 = panelFilterCustom.Controls.Find("cb4N" + numLine, true).FirstOrDefault();          
            Control control5 = panelFilterCustom.Controls.Find("cb5N" + numLine, true).FirstOrDefault();          
            Control control6 = panelFilterCustom.Controls.Find("cb6N" + numLine, true).FirstOrDefault();          
            Control control7 = panelFilterCustom.Controls.Find("cb7N" + numLine, true).FirstOrDefault();          
               
            bool check2 = ((System.Windows.Forms.CheckBox)control1).Checked;            
            control2.Enabled = (check && check2);
            control3.Enabled = (check && check2);           
            bool check3 = true;
            string conditionText = ((System.Windows.Forms.ComboBox)control3).Text;                                   
            if ((conditionText == "NULL") || (conditionText == "NOT NULL")) check3 = false;
            if (check && check2 && check3) 
            {
                control4.BackColor = System.Drawing.SystemColors.Info;
                if (control6 != null) control6.BackColor = System.Drawing.SystemColors.Info;              
            }
            else 
            {
                control4.BackColor = System.Drawing.SystemColors.Menu;
                if (control6 != null) control6.BackColor = System.Drawing.SystemColors.Menu;
            }
            if (check && check2) control2.BackColor = System.Drawing.SystemColors.Info;
            else control2.BackColor = System.Drawing.SystemColors.Menu;
            control4.Enabled = (check && check2 && check3);
            if (control5 != null) control5.Enabled = (check && check2 && check3);
            if (control6 != null) control6.Enabled = (check && check2 && check3);
            //control7.Enabled = Check;      
        }               
                     
        /// <summary>
        /// Событие для CheckBox на полоске фильтра. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterCustomEnabled(object sender, EventArgs e)
        {            
            string componentName = ((System.Windows.Forms.CheckBox)sender).Name;
            bool check = ((System.Windows.Forms.CheckBox)sender).Checked;
            string numLine = componentName.Replace("cb1N", ""); //Пример имени: cb1N9 
            FilterCustomEnabledLine(numLine, check);                           
        }                                    
        
        ///Вставка атрибута в полоску Custom фильтра.
        private void FilterCustomInputAttr(object sender, MouseEventArgs e)
        {                               
            string attrBrief;
            if (!sys.InputAttr(filter.EntityID, out attrBrief)) return;
            string attrName;
            string attrMask;
            CompAttrTreeFBA.ParseAttrBrief(attrBrief, out attrBrief, out attrName, out attrMask);           
            ((System.Windows.Forms.TextBox)sender).Text = attrBrief;
        }                    
                                          
        ///Удаление полоски фильтра.
        private void FilterCustomDelete(object sender, EventArgs e)
        {
            string componentName = ((System.Windows.Forms.Button)sender).Name;            
            string num = componentName.Replace("cb7N", ""); //Пример имени: btnN9
            Control control = panelFilterCustom.Controls.Find("LpN" + num, true).FirstOrDefault();
            if (control == null) return;
            control.Dispose();
            FilterCustomCountPnl--;
        }        
               
        ///Собрать Custom фильтр, в MSQL WHERE.
        private string FilterCustomGetWHERE()
        {             
            string filterResult     = "";           
            string filterCustomType = Var.CR + " AND ";
            if (cbFilterCustomCondition.SelectedIndex == 1) filterCustomType = " OR ";
            int filterNum = 0;
            for (int i = 0; i < FilterCustomCount; i++)
            {
                string n = i.ToString();
                Control control = panelFilterCustom.Controls.Find("LpN" + n, true).FirstOrDefault();
                if (control == null) continue;
                Control control1 = panelFilterCustom.Controls.Find("cb1N" + n, true).FirstOrDefault();               
                bool check2 = ((System.Windows.Forms.CheckBox)control1).Checked;
                if (!check2) continue;
                 
                Control control2 = panelFilterCustom.Controls.Find("cb2N" + n, true).FirstOrDefault();
                Control control3 = panelFilterCustom.Controls.Find("cb3N" + n, true).FirstOrDefault();
                Control control4 = panelFilterCustom.Controls.Find("cb4N" + n, true).FirstOrDefault();          
                Control control6 = panelFilterCustom.Controls.Find("cb6N" + n, true).FirstOrDefault();          
                
                string control2Text = ((System.Windows.Forms.TextBox)control2).Text;
                string control3Text = ((FBA.ComboBoxFBA)control3).Text;
                
                string control4Text  = "";
                string control4Text1 = ((FBA.TextBoxFBA)control4).Text;
                string control4Text2 = ((FBA.TextBoxFBA)control4).Text2;
               
                if (control4Text2.IsNullOrEmpty()) control4Text = control4Text1;
                else control4Text = control4Text2;
                control4Text = control4Text.Replace("'", "");
                
                //control4Text = control4Text2.TransformValue();
                
                // if (!control4Text2.IsNullOrEmpty())
                //if (control4Text2.IsNullOrEmpty()) control4Text = control4Text1.TransformValue();
                          
                string control6Text = "";
                if (control6 != null)
                {
                    control6Text = ((FBA.TextBoxFBA)control6).Text;
                    control6Text = control6Text.Replace("'", "");
                }                                        
                
                //Если IN, NOT IN тогда TransformValue.
                //Если BEGIN, END, CONTAIN тогда '%.. ..%'
                //Если NULL, NOT NULL то ничего не делаем.
                //BETWEEN то кавычки не ставим, но проверяем что в значениях нет кавычек.
                //Если знаки =, >,<, >=, <=, <> то проверяем что в значениях нет кавычек.
                
                string filterLine = "";                                             //.TransformValue()
                if (control2Text == "") continue;
                               
                filterNum++;                
                if (control3Text == "IN")            filterLine = control2Text + " IN (" + control4Text.TransformValue() + ") ";               
                else if (control3Text == "NOT IN")   filterLine = control2Text + " NOT IN (" + control4Text.TransformValue() + ") ";              
                else if (control3Text == "BEGIN")    filterLine = control2Text + " LIKE ('" + control4Text + "%') ";               
                else if (control3Text == "END")      filterLine = control2Text + " LIKE ('%" + control4Text + "') ";                
                else if (control3Text == "CONTAIN")  filterLine = control2Text + " LIKE ('%" + control4Text + "%') ";              
                else if (control3Text == "NULL")     filterLine = control2Text + " IS NULL ";
                else if (control3Text == "NOT NULL") filterLine = control2Text + " IS NOT NULL ";
                else if (control3Text == "BETWEEN")  filterLine = control2Text + " BETWEEN '" + control4Text + "' AND '" + control6Text + "' ";                                               
                else filterLine = control2Text + " " + control3Text + " " + "'" + control4Text + "' ";                                                                           
                if (filterNum == 1) filterResult = filterResult + filterLine;
                else filterResult = filterResult + filterCustomType + filterLine;                
            }
            
            if (filterResult == "") return "";
            filterResult = filterResult + Var.CR;
            return "(" + filterResult + ") ";
        }        
              
        ///Добавление нового фильтра.
        private void FilterCustomAdd(string param1, string param2, string param3, string param4, string param5)
        {                      
            //param1 - ChecbBox
            //param2 - Attr
            //param3 - ComboBox Условие: > = < IN ...
            //param4 - Значение 1
            //AND
            //param5 - Значение 2
            //X
                                
            var lp = new System.Windows.Forms.TableLayoutPanel();
            var cb1 = new System.Windows.Forms.CheckBox();  
            var cb2 = new System.Windows.Forms.TextBox();
            var cb3 = new FBA.ComboBoxFBA();
            var cb4 = new FBA.TextBoxFBA();                                        
            var cb7 = new System.Windows.Forms.Button();                        
           
            var anchor1      = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right| System.Windows.Forms.AnchorStyles.Top);
                       
            lp.ColumnCount = 7;           
            lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent,  40F));
            lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent,  30F));
            lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent,  30F));
            lp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
                       
            lp.Controls.Add(cb1, 0, 0); //CheckBox.
            lp.Controls.Add(cb2, 1, 0); //Param.
            lp.Controls.Add(cb3, 2, 0); //Условие.
            lp.Controls.Add(cb4, 3, 0); //Значение 1.
            lp.Controls.Add(cb7, 6, 0); //Кнопка удалить.
                                                                                      
            lp.Name = "LpN" + FilterCustomCount.ToString();
            lp.RowCount = 1;
            lp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            lp.Size = new System.Drawing.Size(panelFilterCustom.Width - 2, 30);             
            //Lp.Dock = System.Windows.Forms.DockStyle.Bottom;
                            
            //cb1     
            cb1.Anchor = anchor1;            
            cb1.Name = "cb1N" + FilterCustomCount.ToString();;              
            cb1.Text = "";              
            cb1.Checked = true;           
            if (param1 != "") cb1.Checked = param1.ToBool();  
            cb1.CheckedChanged += new System.EventHandler(FilterCustomEnabled);
            lp.Parent = panelFilterCustom;
            lp.Dock = System.Windows.Forms.DockStyle.Bottom;
            
            //cb2        
            cb2.Anchor = anchor1;             
            cb2.Name = "cb2N" + FilterCustomCount.ToString();;             
            cb2.BackColor = System.Drawing.SystemColors.Info;
            cb2.MouseDoubleClick += FilterCustomInputAttr;
            if (param2 != "") cb2.Text = param2;
            cb2.Enabled = cb1.Checked;
            
            //cb3
            cb3.Anchor = anchor1;         
            cb3.Name = "cb3N" + FilterCustomCount.ToString();;                       
            cb3.Items.AddRange(new object[] {
            "=", ">", "<",">=", "<=", "<>", "IN", "NOT IN", "BEGIN", "END", "CONTAIN", "NULL", "NOT NULL", "BETWEEN"});
            cb3.SelectedIndex = 0;
            if (param3 != "") cb3.Text = param3;
            cb3.BackColor = System.Drawing.SystemColors.Info;                        
            cb3.TextChanged += CbFilterCustomConditionTextChanged;
            cb3.Enabled = cb1.Checked; 
            
            //cb4         
            cb4.Anchor = anchor1;                        
            cb4.Name = "cb4N" + FilterCustomCount.ToString();             
            //cb4.MouseDoubleClick += FilterCustomInputText;
            cb4.BackColor = System.Drawing.SystemColors.Info;
            if (param4 != "") cb4.Text = param4;
            cb4.Enabled = cb1.Checked;
            
            //cb7          
            cb7.Anchor = anchor1;           
            cb7.Name = "cb7N" + FilterCustomCount.ToString();;         
            cb7.Text = "X";         
            cb7.Click += new System.EventHandler(FilterCustomDelete);
            cb4.Enabled = true;
                      
            if  (!string.IsNullOrEmpty(param5))
            {               
                var cb5 = new LabelFBA()
                {
                    Anchor = anchor1,
                    Text = "AND",
                    Margin = new Padding(3, 6, 3, 3),
                    Name = "cb5N" + FilterCustomCount.ToString(),
                    Enabled = cb1.Checked
                };                
               
                lp.Controls.Add(cb5, 4, 0);                                                        
            
                //cb6
                var cb6 = new TextBoxFBA()
                {
                    Anchor = anchor1,
                    Name = "cb6N" + FilterCustomCount.ToString(),
                    BackColor = System.Drawing.SystemColors.Info,
                    Enabled = cb1.Checked,
                    Text = param5
                };                    

                lp.Controls.Add(cb6, 5, 0);                    
           
            } else lp.SetColumnSpan(cb4, 3);
            FilterCustomCount++;
            FilterCustomCountPnl++;  
        }
                   
        ///Собрать Custom фильтр в строку.
        private string FilterCustomToString()
        {                                                              
            //Весь фильтр собирается в массив, а далее массив преобразуется в строку.
            var arr = new string[FilterCustomCountPnl, 5];
            int countFilter = 0; 
            //Arr[CountFilter, 0] = cbFilterCustomCondition.SelectedIndex.ToString();
            for (int i = 0; i < FilterCustomCount; i++)
            {
                string n = i.ToString();                
                Control control = panelFilterCustom.Controls.Find("LpN" + n, true).FirstOrDefault();
                if (control == null) continue;
                
                Control control1 = panelFilterCustom.Controls.Find("cb1N" + n, true).FirstOrDefault();                                                            
                Control control2 = panelFilterCustom.Controls.Find("cb2N" + n, true).FirstOrDefault();
                Control control3 = panelFilterCustom.Controls.Find("cb3N" + n, true).FirstOrDefault();
                Control control4 = panelFilterCustom.Controls.Find("cb4N" + n, true).FirstOrDefault(); 
                string param5 = "";
                Control control6 = panelFilterCustom.Controls.Find("cb6N" + n, true).FirstOrDefault();                
                if (control6 != null)
                    param5 = ((System.Windows.Forms.TextBox)control6).Text;             
                arr[countFilter, 0] = ((System.Windows.Forms.CheckBox)control1).Checked.ToString();
                arr[countFilter, 1] = ((System.Windows.Forms.TextBox)control2).Text;
                arr[countFilter, 2] = ((System.Windows.Forms.ComboBox)control3).Text;
                arr[countFilter, 3] = ((System.Windows.Forms.TextBox)control4).Text;
                arr[countFilter, 4] = param5;
                countFilter++;                     
            }   
            //sys.ArrayReplaceQuote(ref Arr);
            string block5 = "";
            sys.ArrayToStr(arr, ref block5, countFilter);
            return block5;
        }                               
                             
        ///Восстановить Custom фильтр из строки.
        private void FilterCustomRestore(string customFilter)
        {  
            panelFilterCustom.Controls.Clear();  
            string[,] arr = null;        
            int offset = 0;
            sys.StrToArray(ref arr, ref offset, ref customFilter);                                               
            if (arr == null) return;                      
            //sys.ArrayView("Arr1", "Arr1", Arr);                      
            int maxY = arr.GetLength(0);
            panelFilterCustom.Visible = false;
            FilterCustomCount         = 0;   
            FilterCustomCountPnl      = 0;              
            for (int i = 0; i < maxY; i++)
            {
                FilterCustomAdd(arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4]);
            }           
            panelFilterCustom.Visible = true;                    
        }
                   
        ///Если NULL или NOT NULL, то компонент для ввода значения недоступен.        
        private void CbFilterCustomConditionTextChanged(object sender, EventArgs e)
        {                     
            return;
            /*string ConditionText = ((System.Windows.Forms.ComboBox)sender).Text;
            string NumLine = ((System.Windows.Forms.ComboBox)sender).Name.Replace("cb3N", "");
            Control control1 = panelFilterCustom.Controls.Find("LpN" + NumLine, true).FirstOrDefault();                                 
            Control control4 = panelFilterCustom.Controls.Find("cb4N" + NumLine, true).FirstOrDefault();           
            Control control5 = panelFilterCustom.Controls.Find("cb5N" + NumLine, true).FirstOrDefault();
            Control control6 = panelFilterCustom.Controls.Find("cb6N" + NumLine, true).FirstOrDefault();                                 
            if (control1 == null) return;
            if (ConditionText != "BETWEEN")
            {                   
                if (control5 != null) 
                    control1.Controls.Remove(control5);
                if (control6 != null) 
                    control1.Controls.Remove(control6);               
                ((System.Windows.Forms.TableLayoutPanel)control1).SetColumnSpan(control4, 3);                               
            } else
            {
                var Anchor1 = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right| System.Windows.Forms.AnchorStyles.Top);            
                if (control4 != null) 
                    ((System.Windows.Forms.TableLayoutPanel)control1).SetColumnSpan(control4, 1);
                
                if (control5 == null)
                {
                    //cb5  
                    var cb5 = new FBA.LabelFBA();                    
                    cb5.Anchor = Anchor1;
                    cb5.Text = "AND";
                    cb5.Margin = new Padding(3, 6, 3, 3);    
                    cb5.Name = "cb5N" + NumLine;
                    ((System.Windows.Forms.TableLayoutPanel)control1).Controls.Add(cb5, 4, 0);                                                        
                }
                if (control6 == null)
                {
                    //cb6
                    var cb6 = new System.Windows.Forms.TextBox();                    
                    cb6.Anchor = Anchor1;             
                    cb6.Name = "cb6N" + NumLine;             
                    cb6.BackColor = System.Drawing.SystemColors.Info; 
                    ((System.Windows.Forms.TableLayoutPanel)control1).Controls.Add(cb6, 5, 0);                                  
                }
            }
            FilterCustomEnabledLine(NumLine, true); 
            */
        }

        ///Изменение размеров панели на которой лежат все полоски Custom фильтра.
        private void PanelFilterCustomResize(object sender, EventArgs e)
        {           
            timer1.Enabled = true;
            return;           
        }                             
        
        ///Изменение размеров панели на которой лежат все полоски Custom фильтра.
        private void Timer1_Tick(object sender, EventArgs e)
        {           
            timer1.Enabled = false;
            for (int i = 0; i < FilterCustomCount; i++)
            {
                string n = i.ToString();
                Control control = panelFilterCustom.Controls.Find("LpN" + n, true).FirstOrDefault();
                if (control != null)              
                    control.Size = new System.Drawing.Size(panelFilterCustom.Width - 2, control.Size.Height);
            }
        } 
        
        #endregion Region. Методы Custom фильтра - полоски.   
        //=============================================================================
        
        //=============================================================================
        #region Region. Методы таблицы атрибутов.
        
        ///Сформировать имя атрибута для запроса. Например, если уже есть в списке имен имя 'Номер договора'
        ///то тогда этот метод вернёт "Номер договора_1".
        private string GetAttrName(string attrBrief, string attrName)
        {
            int N = 0;
            for (int i = 0; i < dgvAttr.Rows.Count; i++)
            {
                string attrBriefExist = dgvAttr.RowInt(i, 1);
                if (attrBrief == attrBriefExist) N++;               
            }
            if (N == 0) return attrName;            
            return attrName + "_" + N;  
        }
                    
        ///Добавление атрибута в гибкую таблицу.
        private bool AttrAdd(int rowIndex)
        {                
            AttrAddColumns();   
            string attrBrief;
            string attrName;
            string attrMask;
            CompAttrTreeFBA.ParseAttrBrief(cmtAttrList.AttrBrief, out attrBrief, out attrName, out attrMask);
            if (attrBrief == "") return false;
            if (attrName == "") attrName = attrBrief;           
            attrName = GetAttrName(attrBrief, attrName);           
            var attr  = new string[5];
            attr[0] = attrName;
            attr[1] = attrBrief;
            attr[2] = attrMask;
            attr[3] = "180";
            attr[4] = "No";
            if (rowIndex == -1) rowIndex = 0; else rowIndex++;
            dgvAttr.Rows.Insert(rowIndex, attr);
            dgvAttr.ClearSelection();
            dgvAttr.Rows[rowIndex].Selected = true;
            return true;        
        }  
                           
        ///Свойста атрибута.
        private bool AttrProperties(int rowIndex)
        {               
            if (rowIndex == -1) return false; 
            string attrName  = dgvAttr.RowInt(rowIndex, "Name");
            string attrBrief = dgvAttr.RowInt(rowIndex, "Brief");             
            string attrWidth = dgvAttr.RowInt(rowIndex, "Width"); 
            string attrMask  = dgvAttr.RowInt(rowIndex, "Mask"); 
            string attrSort  = dgvAttr.RowInt(rowIndex, "Sort");              
            var frm = new FormFilterAttr(attrName, attrBrief, attrWidth, attrMask, attrSort);
            if (frm.ShowDialog() != DialogResult.OK) return false;                                   
            dgvAttr.Rows[rowIndex].Cells["Name"].Value  = frm.tbName.Text;
            dgvAttr.Rows[rowIndex].Cells["Brief"].Value = frm.tbBrief.Text;
            dgvAttr.Rows[rowIndex].Cells["Width"].Value = frm.udWidth.Text;
            dgvAttr.Rows[rowIndex].Cells["Mask"].Value  = frm.cbMask.Text;
            dgvAttr.Rows[rowIndex].Cells["Sort"].Value  = frm.cbSort.Text;             
            return true;
        }        
        
        ///Список выбранных атрибутов преобразовать в строку для сохранения в таблицу в БД.  
        private string AttrGetString()
        {            
            string block5 = "";
            sys.DataGridViewToStr(dgvAttr, ref block5);
            return block5;
        }
        
        ///Из строки восстановить строки и столбцы dgvAttr.
        private void AttrSetString(string arrAttrView)
        {
            AttrWasSet = true;
            int offset = 0;
            sys.StrToDataGridView(ref dgvAttr, ref offset, ref arrAttrView);
        }
        
        ///Получить список выбранных атрибутов в виде SELECT...
        private string AttrGetSelect()
        {
            if (dgvAttr.Rows.Count == 0) return "";
            var attrAttr = new StringBuilder();
            //string MaxRecords = "";            
            //if (Var.con.serverTypeRemote == ServerType.MSSQL) 
            //{
            //	if (cbMax.Text != "Unlimited") MaxRecords = "TOP " + cbMax.Text;
            //}            
            //AttrAttr.Append("SELECT " + MaxRecords);                       
            attrAttr.Append(dgvAttr.RowInt(0, 1) + " AS '" + dgvAttr.RowInt(0, 0) + "'");
            //AttrAttr.Append("  " + dgvAttr[0, 1] + " AS '" + dgvAttr[0, 0] + "'");
            for (int i = 1; i < dgvAttr.Rows.Count; i++)             
                attrAttr.Append(", " + dgvAttr.RowInt(i, 1) + " AS '" + dgvAttr.RowInt(i, 0) + "'");
            
            //if ((Var.con.serverTypeRemote == ServerType.SQLite) || (Var.con.serverTypeRemote == ServerType.Postgre))
            //{
            //	 if (cbMax.Text != "Unlimited")  MaxRecords = " LIMIT " + cbMax.Text;
            //	 AttrAttr.Append(MaxRecords);
            //}            	          
            return attrAttr.ToString(); 
        }
        
        ///Получить список выбранных атрибутов в виде SELECT...
        private string AttrGetOrder()
        {
            if (dgvAttr.Rows.Count == 0) return "";
            var attrAttr = new StringBuilder();
            const string orderStr = "";
            for (int i = 0; i < dgvAttr.Rows.Count; i++)  
            {
                if ((dgvAttr.RowInt(i, 3) == "Up") || (dgvAttr.RowInt(i, 3) == "Down"))
                {
                    if (dgvAttr.RowInt(i, 3) == "Up")
                        attrAttr.Append(orderStr.AddRightComma() + dgvAttr.RowInt(i, 3));
                }
            }
            if (attrAttr.Length > 0) return " ORDER BY " + attrAttr.ToString(); 
            return "";
        }
        
        ///Перемещение выбранных атрибутов таблице Вверх-Вниз клавишами курсора и стралками Вверх-Вниз.
        private void DgvAttr_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control) && (e.KeyCode == Keys.Up))
            {
                int RowIndex = dgvAttr.SelectIndex();
                dgvAttr.RowUp(RowIndex);
            }
            if ((e.Control) && (e.KeyCode == Keys.Down))
            {
                int RowIndex = dgvAttr.SelectIndex();
                dgvAttr.RowDown(RowIndex); 
            }
            e.Handled = true;
        }               
    
        ///Двойной клик - свойства атрибута.
        private void DgvAttr_DoubleClick(object sender, EventArgs e)
        {           
            int rowIndex = dgvAttr.SelectIndex();
            AttrProperties(rowIndex); 
        }
        
        //При двойном клике на дереве атрибутов добавляем атрибут в таблицу выбранных атрибутов.
        private void CmtAttrList_SelectedAttr(object sender, SelectAttrEventArgs e)
        {           
            int rowIndex = dgvAttr.SelectIndex();               
            AttrAdd(rowIndex);               
        }
        
        ///Все кнопки таблицы выбранных атрибутов.
        private void BtnAttrAdd_Click(object sender, EventArgs e)
        {                                     
            int rowIndex = dgvAttr.SelectIndex();
          
            if (sender == btnAttrAdd)    AttrAdd(rowIndex);
            if (sender == btnAttrDel)    dgvAttr.SelectedDeleteAll(); //AttrDel(RowIndex);
            if (sender == btnAttrDelAll) dgvAttr.Rows.Clear(); //AttrDelAll();
            if (sender == btnAttrUp)     dgvAttr.RowUp(rowIndex);
            if (sender == btnAttrDown)   dgvAttr.RowDown(rowIndex);
            
            if (sender == btnAttrAdd ||
                sender == btnAttrDel ||
                sender == btnAttrDelAll ||
                sender == btnAttrUp ||
                sender == btnAttrDown) AttrWasSet = true;

            //Контекстное меню.
            if (sender == cmAttrN1)      dgvAttr.RowUp(rowIndex);
            if (sender == cmAttrN2)      dgvAttr.RowDown(rowIndex); 
            if (sender == cmAttrN3)      AttrProperties(rowIndex);
            if (dgvAttr.Rows.Count == 0) AddObjectIDColumn();
            else if (dgvAttr.RowInt(0, 1).ToUpper() != ParserData.KeyBriefUpper.ObjectID.ToUpper()) AddObjectIDColumn();
        }
       
        ///Если произошла ошибка при чтении атрибутов, то столбы удаляются. Поэтому нужно их добавить снова.
        private void AttrAddColumns()
        {
           if (dgvAttr.Columns.Count > 0) return;
            dgvAttr.Columns.Add("Name",  "Name");
            dgvAttr.Columns.Add("Brief", "Brief"); 
            dgvAttr.Columns.Add("Mask",  "Mask");  
            dgvAttr.Columns.Add("Width", "Width");
            dgvAttr.Columns.Add("Sort",  "Sort");            
            dgvAttr.Columns[0].Width = 100;
            dgvAttr.Columns[1].Width = 100;
            dgvAttr.Columns[2].Width = 100;
            dgvAttr.Columns[3].Width = 100;
            dgvAttr.Columns[4].Width = 100;           
        }

        #endregion Region. Методы таблицы атрибутов.                         
        //=============================================================================

        #region Region. Методы сохранения и загрузки настроек.                        
      
        ///Собрать весь фильтр в один запрос. Сборка MSQL.
        private string GetFullQueryMSQL()
        {      
            string whereStr = "";
            if ((filter.CheckedStatic    == 1) && (filter.FilterStaticWHERE != "")) whereStr = whereStr.AddRightAND() + Var.CR + filter.FilterStaticWHERE;
            if ((filter.CheckedCustom    == 1) && (filter.FilterCustomWHERE != "")) whereStr = whereStr.AddRightAND() + Var.CR + filter.FilterCustomWHERE;
            if ((filter.CheckedUniversal == 1) && (filter.FilterUniversal   != "")) whereStr = whereStr.AddRightAND() + Var.CR + filter.FilterUniversal;
            if (!sys.IsEmpty(filter.OuterWHERE)) whereStr = whereStr.AddRightAND() + Var.CR + filter.OuterWHERE;
            if (filter.ListObjectID != null)
            {
                whereStr = whereStr.AddRightAND() + Var.CR + " ObjectID in (" + string.Join(",", filter.ListObjectID) + ")";
                filter.ListObjectID = null;
            }
            if (whereStr != "") whereStr = Var.CR + " WHERE " + whereStr;                       
            string MaxRecords1 = "";
			string MaxRecords2 = "";             
			if (cbMax.Text != "Unlimited")
			{
				if (Var.con.serverTypeRemote == ServerType.MSSQL) 
					MaxRecords1 = " TOP " + cbMax.Text;	          
				if ((Var.con.serverTypeRemote == ServerType.SQLite) || (Var.con.serverTypeRemote == ServerType.Postgre))	             
	            	MaxRecords2 = Var.CR + " LIMIT " + cbMax.Text;	           
			} 
			string sql =  "SELECT " + MaxRecords1 + filter.AttrSelect  + Var.CR + "FROM " + Var.CR + filter.EntityBrief + whereStr + MaxRecords2;        		
			return sql; 
        }
        ///Получить массив ширины колонок.
        private void GetColumnWidth()
        {           
            filter.ColumnWidth = new int[dgvAttr.Rows.Count];
            for (int i = 0; i < dgvAttr.Rows.Count; i++)
            {
                filter.ColumnWidth[i] = dgvAttr.RowInt(i, "Width").ToInt();
            }                      
        }
        
        ///Сохранение всего фильтра в БД.
        private void FilterGetString()
        {                                            
            filter.Name              = tbFilterName.Text;                
            filter.FilterStatic      = Param.GetComponentValues(this.Controls);  //  panelFilterStatic.Controls);                                                     
            filter.FilterCustom      = FilterCustomToString();
            filter.FilterUniversal   = tbTextUniversal.Text;
            if (AttrWasSet) filter.Attr = AttrGetString();
            if (AttrWasSet) filter.AttrSelect = AttrGetSelect();
            if (AttrWasSet) filter.AttrOrder         = AttrGetOrder();
            filter.CheckedStatic     = cbStatic.Checked.ToInt();
            filter.CheckedCustom     = cbCustom.Checked.ToInt();
            filter.CheckedUniversal  = cbUniversal.Checked.ToInt();
                                                                                              
            filter.FilterStaticWHERE = FilterStaticGetWHERE();
            filter.FilterCustomWHERE = FilterCustomGetWHERE();                             
            filter.FullQueryMSQL     = GetFullQueryMSQL();
            filter.FullQuerySQL      = sys.Parse(filter.FullQueryMSQL);           
            if(cbMax.Text == "Unlimited") filter.MaxRecords = -1; else filter.MaxRecords = cbMax.Text.ToInt();                    
            GetColumnWidth();
        }
        
        ///Проверка перед записью фильтра.
        public bool CheckFilterBeforeSaveFilter()
        {
            string errorMes = "";
            if (dgvAttr.Rows.Count == 0) errorMes = "Не выбраны атрибуты для показа на вкладке View!";
            //if (sys.DGRowInt(dgvAttr, 0, 1) != ParserData.KeyBried.ObjectID) ErrorMes = "Первая колонка обязательно должна быть ИДОбъекта!";
            if (errorMes == "") return true;
            sys.SM(errorMes);
            return false;
        }
        
        ///Это СТАТИЧЕСКИЙ! метод для cохранения фильтра. 
        ///Статический он потому, чтобы можно было его вызвать 
        ///не создавая объект-форму фильтра из справочника при закрытии формы справочника.
        public static bool FilterSave(ref FilterObj filterIN, bool showMes)         
        {
            if (filterIN.EntityID == "") filterIN.EntityID = sys.GetEntityID(filterIN.EntityBrief);
            string sql = string.Format("UPDATE fbaFilter SET FilterLast = 0 WHERE EntityRefID = {0} AND UserID = {1}; " + Var.CR, filterIN.EntityID, Var.UserID );
            if (filterIN.FilterID == "")
            {                                                 
                sql = sql + "INSERT INTO fbaFilter (" +
                                    "EntityID, DateCreate, UserCreateID, Name, EntityRefID," + Var.CR +
                                    "UserID, FilterGlobal, FilterStatic, FilterCustom, FilterUniversal," + Var.CR +
                                    "CheckedStatic, CheckedCustom, CheckedUniversal, Attr, FullQueryMSQL, " + Var.CR +
                                    "FullQuerySQL, FilterLast, DateChange, UserChangeID, MaxRecords) VALUES (" + Var.CR +
                                                                     
                                    "225" + "," + sys.DateTimeCurrent() + "," + Var.UserID  + ",'" + filterIN.Name + "'," + filterIN.EntityID + "," + Var.CR +
                                    Var.UserID  + "," + filterIN.FilterGlobal + ",'" + filterIN.FilterStatic + "','" + filterIN.FilterCustom + "','" + filterIN.FilterUniversal.QueryQuote() + "'," + Var.CR +
                                    "'" + filterIN.CheckedStatic + "','" + filterIN.CheckedCustom + "','" + filterIN.CheckedUniversal + "','" + filterIN.Attr + "','" + filterIN.FullQueryMSQL.QueryQuote() + "'," + Var.CR +
                                    "'" + filterIN.FullQuerySQL.QueryQuote() + "','" + "1" + "'," + sys.DateTimeCurrent() + ",'" + Var.UserID  + "','" + filterIN.MaxRecords + "')";
                sys.Exec(DirectionQuery.Remote, true, sql, out filterIN.FilterID);
                
            } else
            {                             
                sql = sql + "UPDATE fbaFilter SET " +
                      " DateChange       = "   + sys.DateTimeCurrent() +
                      ",UserChangeID     = "   + Var.UserID  + 
                      ",Name             = '"  + filterIN.Name  + "'" +       
                      ",EntityRefID      = "   + filterIN.EntityID +
                      ",UserID           = "   + Var.UserID  + 
                      ",FilterGlobal     = "   + filterIN.FilterGlobal +
                      ",FilterStatic     = '"  + filterIN.FilterStatic     + "'" +
                      ",FilterCustom     = '"  + filterIN.FilterCustom     + "'" +
                      ",FilterUniversal  = '"  + filterIN.FilterUniversal.QueryQuote() + "'" +
                      ",CheckedStatic    = '"  + filterIN.CheckedStatic    + "'" +
                      ",CheckedCustom    = '"  + filterIN.CheckedCustom    + "'" +
                      ",CheckedUniversal = '"  + filterIN.CheckedUniversal + "'" +                                      
                      ",Attr             = '"  + filterIN.Attr             + "'" +
                      ",FullQueryMSQL    = '"  + filterIN.FullQueryMSQL.QueryQuote() + "'" +
                      ",FullQuerySQL     = '"  + filterIN.FullQuerySQL.QueryQuote() + "'" +
                      ",MaxRecords       = '"  + filterIN.MaxRecords       + "'" +
                      ",FilterLast = 1 WHERE ID = " + filterIN.FilterID; 
                 sys.Exec(DirectionQuery.Remote, sql);
            }                      
            if (filterIN.FilterID == "") return false;
            if (showMes) sys.SM("Фильтр сохранен!", MessageType.Information);
            return true; 
        }
                        
        ///Это СТАТИЧЕСКИЙ! метод. Статический он потому, чтобы можно было его вызвать не создавая объект-форму фильтра.
        ///Для чтения из БД фильтра.
        public static bool FilterRead(ref FilterObj filterIN, bool showMes)
        {
            string sql = ""; 
            var dt = new System.Data.DataTable();
            if (!string.IsNullOrEmpty(filterIN.FilterID))
            {                             
            	sql =
                "SELECT t1.ID, t1.EntityID, t1.DateCreate, t1.UserCreateID, t1.DateChange, t1.UserChangeID, t1.Name, t1.EntityRefID, t1.UserID, " +
                "     t1.FilterGlobal, t1.FilterStatic, t1.FilterStaticWHERE, t1.FilterCustom, t1.FilterCustomWHERE, t1.FilterUniversal,  " +
                "     t1.CheckedStatic, t1.CheckedCustom, t1.CheckedUniversal, " +
                "     t1.Attr, t1.FilterLast, t1.FullQueryMSQL, t1.FullQuerySQL, t1.MaxRecords, " +
                "     " + sys.GetISNULL(Var.con.serverTypeRemote) + "(t1.AssemblyName,     t2.AssemblyName)     AS AssemblyName, " +
                "     " + sys.GetISNULL(Var.con.serverTypeRemote) + "(t1.FormStaticName,   t2.FormStaticName)   AS FormStaticName, " +
                "     " + sys.GetISNULL(Var.con.serverTypeRemote) + "(t1.MethodStaticName, t2.MethodStaticName) AS MethodStaticName, " +
                "     " + sys.GetISNULL(Var.con.serverTypeRemote) + "(t1.PanelStaticName,  t2.PanelStaticName)  AS PanelStaticName " +
                "FROM fbaFilter t1 " +
                "LEFT JOIN fbaFilter t2 on t1.EntityRefID = t2.EntityRefID AND t2.AssemblyName IS NOT NULL " +
                "WHERE t1.ID = " + filterIN.FilterID;
                sys.SelectDT(DirectionQuery.Remote, sql, out dt);
            } else
            {
                sql = string.Format("SELECT * FROM fbaFilter WHERE (UserID = {0} OR FilterGlobal = 1) AND EntityRefID = (SELECT ID FROM fbaEntity WHERE Brief = '{1}') AND FilterLast = 1 ORDER BY DateChange DESC;", Var.UserID , filterIN.EntityBrief);
                sys.SelectDT(DirectionQuery.Remote, sql, out dt);
                if (dt == null) return false;
                if (dt.Rows.Count == 0) 
                {
                    sql = string.Format("SELECT * FROM fbaFilter WHERE (UserID = {0} OR FilterGlobal = 1) AND EntityRefID = (SELECT ID FROM fbaEntity WHERE Brief = '{1}') ORDER BY DateChange DESC;", Var.UserID , filterIN.EntityBrief);               
                    //if (Var.con.ServerType == "MSSQL") SQL = Var.converLimitToMSSQL(SQL);
                    sys.SelectDT(DirectionQuery.Remote, sql, out dt); 
                    if (dt.Rows.Count == 0) 
                    {
                        if (showMes) sys.SM("Не найдено ни одного фильтра для сущности " + filterIN.EntityBrief);
                        return false;
                    }                                      
                }      
            }                         
            filterIN.FilterID          = dt.Value("ID");
            filterIN.EntityID          = dt.Value("EntityRefID");
            filterIN.Name              = dt.Value("Name");                 
            filterIN.FilterGlobal      = dt.Value("FilterGlobal").ToInt();          
            filterIN.FilterStatic      = dt.Value("FilterStatic");              
            filterIN.FilterCustom      = dt.Value("FilterCustom");
            filterIN.FilterUniversal   = dt.Value("FilterUniversal");                
            filterIN.CheckedStatic     = dt.Value("CheckedStatic").ToInt();
            filterIN.CheckedCustom     = dt.Value("CheckedCustom").ToInt();  
            filterIN.CheckedUniversal  = dt.Value("CheckedUniversal").ToInt();             
            filterIN.Attr              = dt.Value("Attr");
            filterIN.FullQueryMSQL     = dt.Value("FullQueryMSQL");
            filterIN.FullQuerySQL      = dt.Value("FullQuerySQL");
            filterIN.MaxRecords        = dt.Value("MaxRecords").ToInt();
            filterIN.AssemblyName      = dt.Value("AssemblyName");
            filterIN.FormStaticName    = dt.Value("FormStaticName");
            filterIN.MethodStaticName  = dt.Value("MethodStaticName");
            filterIN.PanelStaticName   = dt.Value("PanelStaticName");
            return true;
        }


        #endregion Region. Методы сохранения и загрузки настроек.
        //=============================================================================

        //=============================================================================
        #region Region. Список фильтров.            
        
        ///Создать новый фильтр.
        private void FilterNew()
        {           
            panelFilterCustom.Controls.Clear();
            FilterCustomCount     = 0;    
            FilterCustomCountPnl  = 0;         
            tbTextUniversal.Text = "";
            dgvAttr.Rows.Clear();
            cbUniversalWordWrap.Checked = false;
            cbFilterCustomCondition.SelectedIndex = 0;
            FilterStaticClear(panelFilterStatic.Controls);
            tbFilterName.Text = "New filter";
            filter.FilterID = "";                                     
        }
              
        ///Загрузка списка фильтров.
        private void FilterListRefresh(string filterID)
        {                              
            if (filter.EntityID == "") return;
            string sql = "SELECT ID, Name, (CASE WHEN FilterGlobal = 1 THEN 'Yes' ELSE 'No' END) AS [Global] FROM fbaFilter WHERE EntityRefID = '" + filter.EntityID + "' AND (UserID = " + Var.UserID  + " OR FilterGlobal = 1) ORDER BY FilterGlobal DESC";                          
            System.Data.DataTable  dt;
            sys.SelectDT(DirectionQuery.Remote, sql, out dt);
            dgvList.DataSource = dt;
            sys.DataGridViewSetColumnWidth(dgvList, "30, 100, 70");
            dgvList.SelectFind(filterID, 0, false);            
        }               
               
        ///Установить для фильтра признак Global.
        private bool FilterGlobalSet(string filterID, bool filterGlobal)
        {
            string sql = "UPDATE fbaFilter SET FilterGlobal = " + filterGlobal.ToInt() + " WHERE ID = '" + filterID + "'";
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            FilterListRefresh(filterID);
            return true;                
        }
        
        ///Удалить фильтр.
        private bool FilterDelete(string filterID, int filterGlobal)
        {
            if ((!Var.UserIsAdmin) && (filterGlobal == 1))
            {
                sys.SM("Нет прав на удаление фильтра!");
                return false;
            }            
            string sql = "DELETE FROM fbaFilter WHERE ID = '" + filterID + "'";
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            //Если удалили не текущий, то обновляем только таблицу со списком фильтров и выходим.
            if (filterID != filter.FilterID)
            {
                FilterListRefresh(filter.FilterID);
                return true;
            }
            //Если удалили текущий, то загружаем другой.
            filter.FilterID = "";
            FilterLoad();
            FilterSet(0);
            FilterListRefresh(filter.FilterID);
            return true;
        }
                                
        ///Копировать фильтр другим пользователям.
        private bool FilterCopy(string filterID, string filterName, int filterGlobal)
        {
            if ((filterGlobal == 1) && (!Var.UserIsAdmin))
            {                
                sys.SM("Данный фильтр нельзя копировать!");
                return false;                                
            }
                                      
            const string sql = "SELECT ID, Name FROM fbaUser ORDER BY Name"; 
            string[,] values;
            if (!sys.InputValues(sql, false, false, out values)) return false; 
            int countRow  = values.GetLength(0);
            var progress1 = new FormProgress("Копирование", "Копирование фильтров другим пользователям", countRow);
            progress1.Show();
            for (int i = 0; i < countRow; i++)
            {
                string copyUserID   = values[i, 0];
                string copyUserName = values[i, 1];                 
                if (FilterCopyToUser(filterID, filterName, copyUserName,  copyUserID) == "") 
                {
                    progress1.Dispose(); 
                    return false;
                }
                progress1.Inc();
            }
            progress1.Dispose();           
            sys.SM("Фильтры скопированы!", MessageType.Information);
            return true;
        }
        
        ///Копировать фильтр другому пользователю.
        private string FilterCopyToUser(string filterID, string filterName, string copyUserName, string copyUserID)
        {
            string sql = "SELECT ID FROM fbaFilter WHERE Name = '" + filterName + "' AND UserID = " + copyUserID;             
            if (sys.GetValue(DirectionQuery.Remote, sql) != "")
            {
                sys.SM("У пользователя " + copyUserName + " уже есть фильтр с именем " + filterName + "!");
                return ""; 
            } 
             
            sql = "INSERT INTO fbaFilter " +
                         "(EntityID, DateCreate, UserCreateID, Name, EntityRefID," +
                         "UserID, FilterGlobal, FilterStatic, FilterCustom, " +                           
                         "Attr, " +
                         "DateChange, UserChangeID) SELECT " +
                         "225, " +
                         sys.DateTimeCurrent() + 
                         "," + Var.UserID  + 
                         ",'" + filterName + "'" +
                         ",EntityRefID" + 
                         "," + copyUserID + 
                         ",FilterGlobal" +
                         ",FilterStatic" +
                         ",FilterCustom" +                         
                         ",Attr," +
                         sys.DateTimeCurrent() + 
                         "," + Var.UserID  + 
                         " FROM fbaFilter WHERE ID = " + filterID;
            return sys.GetValue(DirectionQuery.Remote, sql);            
        }                                                
                     
        private void FormFilter_Shown(object sender, EventArgs e)
        {       
            FilterListRefresh(filter.FilterID);
        }
     
        #endregion Region. Список фильтров.
        //=============================================================================
    }
    
    /// <summary>
    /// Класс для передачи всего фильтра в вызывающую форму.
    /// </summary>
    public class FilterObj
    {         
        
    	/// <summary>
    	/// ИД фильтра. Каждый фильтр храниться в базе данных. Это ИД записи в таблице fbaFilter.
    	/// </summary>
    	public string FilterID;
        
    	/// <summary>
    	/// Сокращение сущности, к которой применяется фильтр
    	/// </summary>
        public string EntityBrief;
        
        /// <summary>
        /// ИД сущности, к которой применяется фильтр
        /// </summary>
        public string EntityID;
        
        /// <summary>
        /// Глобальный или пользовательский фильтр
        /// </summary>
        public int    FilterGlobal;  

		/// <summary>
        /// Имя фильтра
        /// </summary>      
        public string Name;  

		/// <summary>
        /// Собранная строка статического фильтра
        /// </summary>         
        public string FilterStatic;
        
        /// <summary>
        /// Строка WHERE статического фильтра
        /// </summary>
        public string FilterStaticWHERE;
        
        /// <summary>
        /// Собранная строка Custom фильтра
        /// </summary>
        public string FilterCustom;
        
        /// <summary>
        /// Строка WHERE Custom фильтра
        /// </summary>
        public string FilterCustomWHERE; 
        
        /// <summary>
        /// Строка Universal фильтра. Where тут нет, так как весь фильтр  Universal - это и есть WHERE.
        /// </summary>
        public string FilterUniversal;  

		/// <summary>
        /// Собранная строка всех атрибутов для показа.
        /// </summary>        
        public string Attr;     

		/// <summary>
        /// Галка отмечающая, что фильтр Static используется по умолчанию.
        /// </summary>         
        public int    CheckedStatic;
        
        /// <summary>
        ///  Галка отмечающая, что фильтр Custom используется по умолчанию.
        /// </summary>
        public int    CheckedCustom;
        
        /// <summary>
        ///  Галка отмечающая, что фильтр Universal  используется по умолчанию.
        /// </summary>
        public int    CheckedUniversal; 

        /// <summary>
        /// Это собранный select из выбранных атрибутов.
        /// </summary>
        public string AttrSelect; 
        
        /// <summary>
        /// Это собранная сортировка из атрибутов.
        /// </summary>
        public string AttrOrder; 
        
        /// <summary>
        /// Весь собраный фильтр MSQL.
        /// </summary>
        public string FullQueryMSQL;
        
        /// <summary>
        /// Весь собраный фильтр SQL.
        /// </summary>
        public string FullQuerySQL;
        
        /// <summary>
        /// Массив всех размеров по ширине колонок. Далее этот массив применяется к гриду.
        /// </summary>
        public int[]  ColumnWidth;
        
        /// <summary>
        /// Максимальное количество строк для отбора запросом. для SQL Server это TOP, напрмиер: SELECT TOP 100 * from...
        /// </summary>
        public int    MaxRecords;
        
        /// <summary>
        /// Внешний фильтр WHERE
        /// </summary>
        public string OuterWHERE;
        
        /// <summary>
        /// Это Assembly в которой находистся Static фильтр.
        /// </summary>
        public string AssemblyName;
        
        /// <summary>
        /// Название формы статического фильтра в AssemblyName 
        /// </summary>
        public string FormStaticName;
        
        /// <summary>
        /// Метод статического фильтра в форме FormStaticName
        /// </summary>
        public string MethodStaticName;
        
        /// <summary>
        /// Панель, на котрой лежат компоненты статического фильтра. При данного показе фильтра эти компоненты будут размещены на вкладке Static. 
        /// </summary>
        public string PanelStaticName;
        
        /// <summary>
        /// Список объектов для показа. Только для запросов на MSQL
        /// </summary>
        public string[] ListObjectID;
    }     
}

//Ввод списка значений при двойном клике на TextBox полоски фильтра.
        //private void FilterCustomInputText(object sender, MouseEventArgs e)
        //{        
            //sys.InputListValues(sender);
        //}