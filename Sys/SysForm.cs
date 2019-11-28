
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 25.08.2017
 * Время: 23:37
*/
using System;
using System.Drawing;
using System.Windows.Forms; 
using System.Linq;
using System.Data;  
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace FBA
{                	             
    /// <summary>
    /// Это класс-потомок для всех форм - и главной MDI Parent и всех дочерних.   
    /// </summary>
    /// <remarks>
    /// Часть функционала здесь для родительской формы, а часть для дочерних.
    /// Часть функционала должна работать когда форма является дочерней формой MDI, 
    /// Часть - когда форма является формой SDI.
    /// Часть - когда форма является главной формой MDIContainer.
    /// При этом функционал общий и для родительской формы. 
    /// Все сделано в одном классе.    
    /// </remarks>   
    public class FormFBA : Form
    {                   
		/// <summary>
		/// Сообщение Windows активации формы.
		/// </summary>
    	public const int WM_MDINEXT = 0x224;
		
    	/// <summary>
    	/// Послать сообщение форме.
    	/// </summary>
    	/// <param name="hWnd">Хендл окна</param>
    	/// <param name="msg">Сообщение</param>
    	/// <param name="wParam">Параметр w</param>
    	/// <param name="lParam">Параметр l</param>
    	/// <returns></returns>
    	[System.Security.SuppressUnmanagedCodeSecurity]
	    [DllImport( "user32.dll", CharSet = CharSet.Auto)]
	    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
	    
    	/// <summary>
    	/// Поиск дочерней формы. Для активации.
    	/// </summary>
    	/// <returns>Контейнер для дочерних форм многодокументного интерфейса (MDI).</returns>
		public MdiClient GetMDIClient()
	    {
	        foreach (Control c in this.Controls)
	        {
	            if (c is MdiClient)
	               return (MdiClient) c;
	        }
	       throw new InvalidOperationException("No MDIClient !!!");
	    }
		   	   
	    /// <summary>
	    /// Активация дочерней формы, чтобы избежать мерцания. 
	    /// Без этого кода форма при активации мерцает и активируется медленнее.
	    /// </summary>
	    /// <param name="childToActivate">Форма, которую нужно активировать.</param>
	    public void ActivateMdiChild(FormFBA childToActivate)
	    {
	        if( this.ActiveMdiChild != childToActivate)
	        {
	            MdiClient mdiClient = GetMDIClient();
	            int count = this.MdiChildren.Length;
	            Control form = null;  // next or previous MDIChild form
	
	            int pos = mdiClient.Controls.IndexOf(childToActivate);
	            if (pos < 0)
	            {
	            	childToActivate.Activate();
	            	//  throw new InvalidOperationException("MDIChild form not found");
	            }
	             
	            if (pos == 0)
	            {
	            	if (mdiClient.Controls.Count > 0) form = mdiClient.Controls[1];  // get next and activate previous
	            	else return;
	            }
	            else
	            {
	            	if (mdiClient.Controls.Count > 1) form = mdiClient.Controls[pos - 1];  // get previous and activate next
	            	else return;
	            }
	               		
	            // flag indicating whether to activate previous or next MDIChild
	            IntPtr direction = new IntPtr(pos == 0 ? 1 : 0);
	            
	            // bada bing, bada boom
	            SendMessage(mdiClient.Handle, WM_MDINEXT, form.Handle, direction);
	        }
	    }		    	  
    	
    	/// <summary>
        /// Действия с вкладкой.
        /// </summary>        
	    private enum ActionName
		{
		    NotAssigned,		
	        Active,
	        Add,
	        Close
		}	
    	    	
    	#region Region. Конструктор, свойства и переменные.
          
	    /// <summary>
        /// Для определения экземпляра формы.   
        /// </summary>
        [DisplayName("FormGUID"), Description("FormGUID"), Category("FBA")]
        public string FormGUID { get; set; }        
              
        /// <summary>
        /// Просто текст. Можно хранить произвольный текст, например текст запросов.
        /// </summary>
        [DisplayName("QueryText"), Description("Query text"), Category("FBA")]
        public string[] QueryText { get; set; }
  
        /// <summary>
        /// Это свойство содержит имя формы-родителя MDIParent.
        /// </summary>
        [DisplayName("FormMDIParent"), Description("The main MDI form"), Category("FBA")]
        public string FormMDIParent { get; set; } 
         
        /// <summary>
        /// Если в прикладном коде будет создаваться несколько одинаковых форм, то здесь можно задавать номер или другой текст, 
        /// чтобы отличить один экземпляр формы от другого.
        /// </summary>
        [DisplayName("FormNumber"), Description("The sequence number of the instance of the form"), Category("FBA")]
        public int FormNumber { get; set; } 
             
        /// <summary>
        /// Включает/отключает дополнительные возможности формы: вкладки.
        /// </summary>
        [DisplayName("FormUsual"), Description("Enable/disable additional abilities"), Category("FBA")]
        public bool FormUsual { get; set; }           
        
        /// <summary>
        /// Включает/отключает дополнительные возможности формы: вкладки.
        /// </summary>
        [DisplayName("FormSavePosition"), Description("Save size and position form for next open"), Category("FBA")]
        public bool FormSavePosition { get; set; }           
               
        //Панель с вкладками, на которой отображаются все открытые (и свернутые) формы MDI.        
        System.Windows.Forms.TabControl tabControlForm;
        
        //Контекстное меню для TabControl, там есть пункт меню "Close" для того чтобы можно было закрыть форму.
        ContextMenuStrip cmFormPanel = new ContextMenuStrip();                                    
                
        /// <summary>
        /// Конструктор. 
        /// </summary>
        public FormFBA()
        {                                              
            if (Var.IsDesignMode) return;
            DoubleBuffered = true;
            //На момент срабатывания конструктора ещё неясно какая это форма ParentMDI или ChildMDI.
            //В событии Load это уже известно. 
            //Присвоение этих событий Activated и Move (FormFBAActivated и FormFBAMove) перенесено в FormFBALoad,
            //потому что на на данном этапе неизвестно ещё форма является MDI или нет.
            this.Load        += FormFBALoad;
            this.Shown       += FormFBAShown;
            this.FormClosing += FormFBAClosing;
         
            //Для ускорения ресайза формы.
            this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            this.ResizeEnd   += (s, e) => { this.ResumeLayout(true); };         
        }       

        #endregion Region. Конструктор, свойства и переменные.

        #region Region. Панель с вкладками для открытых окон в системе.
       
        /// <summary>
        /// Поиск формы по FormGUID.
        /// </summary>
        /// <param name="formGUID">GUID формы создается при создании формы</param>
        /// <param name="form">Ссылка на форму</param>
        /// <returns>Если форма найдена, то true</returns>
        private bool FormListObjFind(string formGUID, out FormFBA form)
        {           
            if (Var.ListForm.ContainsKey(formGUID) == true)
            {      
                form = Var.ListForm[formGUID];
                return true;
                  
            } else 
            {
                form = null;
                return false;
            }              
        }                
        
        ///При клике на кнопке TabControl делаем видимой форму.
        private void TabControlFormClick(object sender, EventArgs e)
        {                          
            if (tabControlForm.SelectedTab == null) return;
            string formGUIDIN = tabControlForm.SelectedTab.Tag.ToString();            
            FormSetAction(formGUIDIN, ActionName.Active);           
        }    
        
        ///Вызов контекстного меню на шапке TabControl.
        private void TabControlFormMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {               
                int tc = tabControlForm.TabCount;
                for (int i = 0; i < tabControlForm.TabCount; ++i)
                {
                    if (tc != tabControlForm.TabCount) return;
                    Rectangle r = tabControlForm.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {                                            
                        var p = new Point(e.Location.X + tabControlForm.Left, e.Location.Y + tabControlForm.Top);                                                
                        //if (cmFormPanel.Tag != null)
                        //{
                        //    if (cmFormPanel.Tag.ToString() != "") return;
                        //}
                        cmFormPanel.Show(this, p);
                        if (tc != tabControlForm.TabCount) return;
                        cmFormPanel.Tag = tabControlForm.TabPages[i].Tag.ToString();                       
                        break;                        
                    }
                }
            }
            base.OnMouseUp(e);            
        }
                                                                  
        ///Действия с вкладками по FormGUID: Active, Add, Del. 
        private void TabSetAction(string formGUIDIN, string FormName, ActionName actionName)
        {
            if (tabControlForm == null) return;
            int Index = -1;
           
            //Получить индекс вкладки по FormGUID.
            for (int i = 0; i <= tabControlForm.TabPages.Count - 1; i++)
            {
                if (tabControlForm.TabPages[i].Tag.ToString() == formGUIDIN) Index = i;                
            }                         
            
            //Сделать активной вкладку по FormGUID.
            if ((actionName == ActionName.Active) && (Index > -1))            
            {                
                tabControlForm.SelectedIndex = Index;
                return;
            }
            
            //Добавить вкладку по FormGUID.
            if (actionName == ActionName.Add)
            {
                if (!tabControlForm.Visible) tabControlForm.Visible = true;                     
                tabControlForm.TabPages.Add(FormName);                   
                //Size size = sys.GetTextLength(FormName);
                //size.Width = size.Width + 10;
                //tabControlForm.ItemSize = size;                 
                //tabControlForm.TabPages.Add(tabpage);
                tabControlForm.TabPages[tabControlForm.TabPages.Count - 1].Tag = formGUIDIN;
                tabControlForm.SelectedIndex = tabControlForm.TabPages.Count - 1; 
            }
            //Удалить вкладку по FormGUID.
            if ((actionName == ActionName.Close) && (Index > -1))
            {                  
                tabControlForm.TabPages.RemoveAt(Index);
                Var.ListForm.Remove(formGUIDIN);
                if (tabControlForm.TabPages.Count == 0) tabControlForm.Visible = false;
            }
        }                              
          
        ///Событие контекстного меню на шапке TabControl. Закрыть выбранную вкладку.
        private void cmMenuCloseForm(object sender, EventArgs e)
        {                            
            string formGUIDIN = cmFormPanel.Tag.ToString();
            cmFormPanel.Tag = "";
            FormSetAction(formGUIDIN, ActionName.Close);
            TabSetAction(formGUIDIN, "", ActionName.Close);             
        }           
        
        ///Событие контекстного меню на шапке TabControl. Закрыть все формы и вкладки.
        private void cmMenuCloseAllForm(object sender, EventArgs e)
        {                            
        	int N = tabControlForm.TabCount - 1;
        	for (int i = N; i > -1; i--)
            {
            	string formGUIDIN = tabControlForm.TabPages[i].Tag.ToString();	          
	            FormSetAction(formGUIDIN, ActionName.Close);
	            TabSetAction(formGUIDIN, "", ActionName.Close);  
            }                      	        	        
        } 
        
        ///Действие с формой по FormGUID: Active, Close, Hide.
        private void FormSetAction(string formGUIDIN, ActionName actionName)
        {                                  
            FormFBA form;
            if (!FormListObjFind(formGUIDIN, out form)) return;
            if (actionName == ActionName.Active)
            {
                this.SuspendLayout();                
                //form.Show();                  
                //form.Visible = true;
                //form.BringToFront();
                
                ActivateMdiChild(form);
                this.ResumeLayout(true);
                return;
            }
            if (actionName == ActionName.Close) form.Close();         
        }           	           
	    
        /// <summary>
        /// Перехват события сворачивания формы.
        /// </summary>
        /// <param name="m">Message windows</param>
        protected override void WndProc(ref Message m)
        {                                                    
            //base.WndProc(ref m);               	        	        	        	             
            //Перехват посылаемого окну сообщения клика. (
            //if (m.Msg == WinAPI.WM_SYSCOMMAND) //&& ((int)m.WParam == MY_MENUITEM_ID1) MenuItemClick((int)m.WParam);                                     
           
            if( m.Msg == WinAPI.WM_SYSCOMMAND) //0x0112 - WM_SYSCOMMAND
            {              
                int WParam = (int)m.WParam;
                if ((WParam > 0) && (WParam < 10)) MenuItemClick((int)m.WParam);
                
                if( m.WParam == new IntPtr(0xF020)) //SC_MINIMIZE
                {                      
                    //Вместо сворачивания скрываем форму.
                    if ((this.IsMdiContainer != true)  &&
                       (Var.FormMainObj      != null)  &&
                       (!this.Modal)                   &&
                       (FormGUID != null)              &&
                       (FormGUID != ""))                    
                    this.Hide();
                }
                m.Result = new IntPtr(0);
            }            
            base.WndProc(ref m);
        }                                    
        
        ///Событие. При показе любой формы проверяем наличие подключения, и если его нет, то устанавливаем.
        private void FormFBALoad(object sender, EventArgs e)
        {                          
            
        	//Событие. Когда форма показывается.        	     
            if (this.FormSavePosition) LoadPosition();
        	
        	if (Var.IsDesignMode) return;
            //if (Var.FormMainObj != null)     this.Icon = Var.FormMainObj.Icon;            
            //else if (this.MdiParent != null) this.Icon = this.MdiParent.Icon; 
            //else if (this.Owner != null)     this.Icon = this.Owner.Icon;
                                               
            if (FormUsual) return;
            
            //Дочерние формы.
            if (!this.IsMdiContainer)                        
            {                
                this.Activated   += FormFBAActivated; //Для того чтобы сделать активной кнопку на tabControlForm.
                this.Move        += FormFBAMove;      //Для того чтобы делать их SDI при перемещении к границе родительской формы.                                
                if (Var.FormMainObj != null)
                if (Var.FormMainObj.tabControlForm != null)
                try
                {
                    Var.FormMainObj.tabControlForm.MouseUp += Var.FormMainObj.TabControlFormMouseUp; 
                } catch
                {
                    return;
                }                   
                          
                string formGUIDIN = Guid.NewGuid().ToString();               
                this.FormGUID = formGUIDIN;                
                this.FormNumber = ProjectService.FormGetNumber(this.Name);
                                                   
                //Добавление формы в колекцию форм.
                Var.ListForm.Add(formGUIDIN, this);

                //Добавление вкладки.
                if ((!this.Modal) && (Var.FormMainObj != null))
                    Var.FormMainObj.TabSetAction(formGUIDIN, this.Text, ActionName.Add);   
            }
             
            //Родительская форма.
            if (this.IsMdiContainer)
            {                                                          
                tabControlForm = new System.Windows.Forms.TabControl();
                tabControlForm.Dock = System.Windows.Forms.DockStyle.Top;
                tabControlForm.Location = new System.Drawing.Point(0, 25);
                tabControlForm.Name = "tabControlForm";
                tabControlForm.SelectedIndex = 0;
                tabControlForm.Size = new System.Drawing.Size(537, 25);                                                            
                tabControlForm.Appearance = System.Windows.Forms.TabAppearance.Normal;
                //tabControlForm.Location = new System.Drawing.Point(0, 30);
                //tabControlForm.Dock = System.Windows.Forms.DockStyle.Top;
                tabControlForm.Font = Var.font1;
                tabControlForm.HotTrack = true;                  
                tabControlForm.Multiline = true;
                //tabControlForm.Name = "tabControlForm";
                //tabControlForm.SelectedIndex = 0;                
                //tabControlForm.Height = 25;
                //tabControlForm.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;                  
                this.Controls.Add(this.tabControlForm);
                //tabControlForm.Visible = true;
                //tabControlForm.Dock = System.Windows.Forms.DockStyle.Top; 
                tabControlForm.Click += new System.EventHandler(this.TabControlFormClick);                                
                tabControlForm.BringToFront();
                tabControlForm.Visible = false;                 
                
                var cmFormPanelN1 = new System.Windows.Forms.ToolStripMenuItem();
                cmFormPanelN1.Text = "Close form";
                cmFormPanelN1.Image = global::FBA.Resource.Del_16;
                cmFormPanelN1.Click += new System.EventHandler(cmMenuCloseForm);
                cmFormPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {cmFormPanelN1});
                
                var cmFormPanelN2 = new System.Windows.Forms.ToolStripMenuItem();
                cmFormPanelN2.Text = "Close all form";
                cmFormPanelN2.Image = global::FBA.Resource.Del_16;
                cmFormPanelN2.Click += new System.EventHandler(cmMenuCloseAllForm);
                cmFormPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {cmFormPanelN2});
                //var cmFormPanelN2 = new System.Windows.Forms.ToolStripMenuItem();
                //cmFormPanelN2.Text = "Form Name";
                //cmFormPanelN2.Image = global::FBA.Resource.Del_16;
                //cmFormPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {cmFormPanelN2});
                //cmFormPanelN2.Click += new System.EventHandler(cmMenuFormName);
                
                //cmFormPanel.MenuItems.Add("Close form");
                //cmFormPanel.MenuItems[0].Click += cmMenuCloseForm;      
            }      
        }

        ///Событие. Когда форма становится активной, выделить кнопку на tabControlForm.
        private void FormFBAActivated(object sender, EventArgs e)
        {           
            if (Var.IsDesignMode) return;
            if (this.IsMdiContainer == true) return;
            if (Var.FormMainObj     == null) return;
            if (FormGUID == null)            return;
            if (FormGUID == "")              return;                                  
            Var.FormMainObj.TabSetAction(FormGUID, "", ActionName.Active);            
        }       

        ///Событие. При закрыти любой формы MDIChild.
        private void FormFBAClosing(object sender, FormClosingEventArgs e)
        {
            if (Var.IsDesignMode) return;
            if (this.FormSavePosition) SavePosition();
            if (this.IsMdiContainer == true) return;
            if (Var.FormMainObj     == null) return;
            if (FormGUID == null)            return;
            if (FormGUID == "")              return;                                       
            Var.FormMainObj.TabSetAction(FormGUID, "", ActionName.Close);
            //Сохраняем положение окна в локальной базе.
            
            //e.Cancel = true;         
        }

        ///Событие. Когда форма задвигается за пределы родительской, то она становится самостоятельной (SDI).
        private void FormFBAMove(object sender, EventArgs e)
        {
            if (Var.IsDesignMode) return;
            if (this.MdiParent == null) return;
            if ((this.MdiParent.Width - this.Left) < 90) this.FormSetSDI();
        }

        ///Событие. Когда форма показывается.
        private void FormFBAShown(object sender, EventArgs e)
        {   
               
                 // 
               
        }

    
        #endregion Region. Панель с вкладками для открытых окон в системе.              

        #region Region. Методы добавления пунктов системного меню.
                      
        /// <summary>
        /// При добавлении пунктов меню править в WndProc(ref Message m) строка WParam меньше 10. Т.е. нужно дробавить 11 и т.д.
        /// При создании формы.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e) 
        {                     
            base.OnHandleCreated(e);
            if (Var.IsDesignMode) return;   
            //const uint MY_MENUITEM_ID1=0x1;
            IntPtr hSysMenu = WinAPI.GetSystemMenu(this.Handle, false);
            MenuAdd(hSysMenu, "MDI Mode ",                  0x1);
            MenuAdd(hSysMenu, "SDI Mode ",                  0x2);           
            MenuAdd(hSysMenu, "MDI Layout - Cascade",       0x3);
            MenuAdd(hSysMenu, "MDI Layout - Horizontal",    0x4);
            MenuAdd(hSysMenu, "MDI Layout - Vertical",      0x5);            
            MenuAdd(hSysMenu, "Form Properties",            0x6);         
            MenuAdd(hSysMenu, "Top = True",   				0x7);
            MenuAdd(hSysMenu, "Top = False",  				0x8);
            MenuAdd(hSysMenu, "SEPARATOR",                  0x9); 
        }
        
        //Добавление пунктов меню.
        private void MenuAdd(IntPtr hSysMenu, string menuName, uint MY_MENUITEM_Index)
        {
            if (menuName == "SEPARATOR")
            {
                WinAPI.InsertMenu(hSysMenu, MY_MENUITEM_Index - 1,
                             WinAPI.MenuFlags.MF_BYPOSITION | WinAPI.MenuFlags.MF_SEPARATOR, MY_MENUITEM_Index, 
                             menuName);
                return;
            }
            WinAPI.InsertMenu(hSysMenu, MY_MENUITEM_Index - 1,
                             WinAPI.MenuFlags.MF_BYPOSITION | WinAPI.MenuFlags.MF_STRING, MY_MENUITEM_Index, 
                             menuName); 
        }   
        
        //Событие пункта системного меню формы.
        private void MenuItemClick(int MY_MENUITEM_ID) 
        {                         
        	
        	/*string[] teams = {"Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона"};
 
			var selectedTeams = from t in teams // определяем каждый объект из teams как t
			                    where t.ToUpper().StartsWith("Б") //фильтрация по критерию
			                    orderby t  // упорядочиваем по возрастанию
			                    select t; // выбираем объект
			 
			foreach (string s in selectedTeams)
			    Console.WriteLine(s);
			    
        	*/
			
			
        	if (Var.IsDesignMode) return;
            if (MY_MENUITEM_ID == 1) FormSetMDI(); 
            if (MY_MENUITEM_ID == 2) FormSetSDI();    
            if (MY_MENUITEM_ID == 3) FormMDILayout(System.Windows.Forms.MdiLayout.Cascade);
            if (MY_MENUITEM_ID == 4) FormMDILayout(System.Windows.Forms.MdiLayout.TileHorizontal);
            if (MY_MENUITEM_ID == 5) FormMDILayout(System.Windows.Forms.MdiLayout.TileVertical);             
            if (MY_MENUITEM_ID == 6) ShowFormProperties();             
            if (MY_MENUITEM_ID == 7) Var.FormMainObj.TopMost = true;         
            if (MY_MENUITEM_ID == 8) Var.FormMainObj.TopMost = false;    
			//if (MY_MENUITEM_ID == 9) separator!            
        }
         
        /// <summary>
        /// Показ свойств формы.
        /// </summary>
        private void ShowFormProperties()
        {
        	 sys.SM("Form Name: " + Name + Var.CR + 
        	        "Form Type: " + GetType().ToString() + Var.CR + 
        	        "Width: "     + Width  + Var.CR + 
        	        "Height: "    + Height  + Var.CR + 
        	        "FormNumber: " + FormNumber + Var.CR + 
        	        "FormMDIParent: " + FormMDIParent + Var.CR + 
        	        "FormGUID: " + FormGUID, MessageType.Information);
        }
        
        ///Сделать форму MDI (внутри главной формы FormMainObj)
        public void FormSetMDI()
        {
            if (Var.FormMainObj == null) return;
            if (this.MdiParent  != null) return;
            if (this.IsMdiContainer)     return;
            const int deltaX = 30;
            const int deltaY = 30;
            //Точно не нужно, примерно
            int mx = this.Left - Var.FormMainObj.Left - 10 - deltaX;
            int my = this.Top - Var.FormMainObj.Top - 56 - deltaY;  
            if (mx < 0) mx = 0;
            if (my < 0) my = 0;   
            this.MdiParent = Var.FormMainObj;
            this.ShowInTaskbar = false;
            this.Left = mx;
            this.Top  = my;  
        }
    
        /// <summary>
        /// Сделать форму свободно плавающей (снаружи главной формы FormMainObj).
        /// </summary>
        public void FormSetSDI()
        {            
            if (Var.FormMainObj == null) return;
            if (this.MdiParent == null)  return;
            if (this.IsMdiContainer)     return;
            const int deltaX = 30;
            const int deltaY = 30;                      
            //Точно не нужно, примерно
            int mx = this.MdiParent.Left + this.Left + 10 + deltaX; 
            int my = this.MdiParent.Top + this.Top + 56 + deltaY;
            if (mx < 0) mx = 0;
            if (my < 0) my = 0;
            this.MdiParent = null;
            this.ShowInTaskbar = true;
            this.Left = mx;
            this.Top  = my; 
        }
                                 
        /// <summary>
        /// Упорядочить окна MDI внутри главной формы.
        /// </summary>
        /// <param name="layout">Способ упорядочивания открытых окон</param>
        public void FormMDILayout(System.Windows.Forms.MdiLayout layout)
        {
            if (Var.FormMainObj == null) return;
            Var.FormMainObj.LayoutMdi(layout);
        }
              
        ///Перехват нажатий кнопок, когда форма в фокусе.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {                                               
            if (Var.IsDesignMode) return false;
            if (this.FormUsual)   return false;
            const int WM_KEYDOWN    = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
              
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                string s = "";
                switch(keyData)
				{
				    case Keys.Control | Keys.D: 
				    	s = "<CTRL> + D"; 
				    	break;                                        
					case Keys.Control | Keys.S: 
				    	s = "<CTRL> + S"; 
				    	break;
				    case Keys.Control | Keys.F6: 
                        s = "<CTRL> + F6"; 
                        break; 
                    case Keys.Control | Keys.F7: 
                        s = "<CTRL> + F7"; 
                        break;
                    case Keys.Control | Keys.F8: 
                        s = "<CTRL> + F8"; 
                        break;
                    case Keys.Control | Keys.F9: 
                        s = "<CTRL> + F9"; 
                        break;
                    case Keys.Control | Keys.F10: 
                        s = "<CTRL> + F10"; 
                        break;
                    case Keys.Control | Keys.F11: 
                        s = "<CTRL> + F11"; 
                        break;
                    case Keys.Control | Keys.F12: 
                        s = "<CTRL> + F12";    
                        break;    
				} 
				//Показ сервисной формы.                
                if (s == "<CTRL> + D") 
                {
                	if (!Var.UserIsAdmin) return true;
                    var formService = new ProjectService(Name);
                	formService.ShowDialog(); 
                }
                //Сохранение формы в БД.
				if (s == "<CTRL> + F12") 
				{
				    if (!Var.UserIsAdmin) return true;
				    if (!ProjectService.ProjectWriteToDataBase(this.Name)) return false;
                    if (!ProjectService.ProjectWriteToDataBase(this.Name)) return false;
                    sys.SM("Форма и проект сохранены в базу данных!", MessageType.Information, "Сохранение формы в БД"); 
				}
				
				if (s == "<CTRL> + F6")  FormSetMDI();
				if (s == "<CTRL> + F7")  FormSetSDI();
				if (s == "<CTRL> + F8")  FormMDILayout(System.Windows.Forms.MdiLayout.ArrangeIcons);
				if (s == "<CTRL> + F9")  FormMDILayout(System.Windows.Forms.MdiLayout.Cascade);
				if (s == "<CTRL> + F10") FormMDILayout(System.Windows.Forms.MdiLayout.TileHorizontal);
				if (s == "<CTRL> + F11") FormMDILayout(System.Windows.Forms.MdiLayout.TileVertical);
            }
            return false;           
        }                 
    
        #endregion Region. Методы добавления пунктов системного меню.   
        
        #region Region. Сохранение и восстановление размеров формы.
                
        ///Сохраняем размеры и положение формы, для того чтобы при повторном открытии восстановить их.
        public bool SavePosition()
        {
            string dateLocal =  sys.DateTimeCurrent(ServerType.SQLite);
            //string TOPMSSQL    = "";
            //string LIMITSQLITE = "";
            //if (Var.con.ServerType == "MSSQL") TOPMSSQL = " TOP 1 ";
            //else LIMITSQLITE = " LIMIT 1 ";            
            string sql =
                string.Format(
                "UPDATE fbaFormPosition SET FormX = {0}, FormY = {1}, FormWidth = {2}, FormHeight = {3}, DateChange = {4} " +
                "WHERE FormName = '{5}' AND UserID = {6};", this.Left, this.Top, this.Width, this.Height, dateLocal, this.Name, Var.UserID ) + Var.CR +                                            
                string.Format("INSERT INTO fbaFormPosition (EntityID, DateCreate, UserID, FormName, FormX, FormY, FormWidth, FormHeight) " +
                    "SELECT 232,{0},{1},'{2}',{3},{4},{5},{6} WHERE NOT EXISTS (SELECT FormName FROM fbaFormPosition WHERE FormName = '{2}' AND UserID = {1} LIMIT 1)", 
                    dateLocal, Var.UserID , this.Name, this.Left, this.Top, this.Width, this.Height);
            return sys.Exec(DirectionQuery.Local, sql);
        }
        
        ///Восстанавлииваем состояние формы. 
        public bool LoadPosition()
        {                       
            string sql = string.Format("SELECT FormX, FormY, FormWidth, FormHeight FROM fbaFormPosition WHERE FormName = '{0}' AND UserID = {1};", this.Name, Var.UserID );
            string formX;
            string formY;
            string formWidth;
            string formHeight;
            if (!sys.GetValue(DirectionQuery.Local, sql, out formX, out formY, out formWidth, out formHeight)) return false;
            try
            {                                  
                int fx = formX.ToInt();
                int fy = formY.ToInt();
                int fw = formWidth.ToInt();
                int fh = formHeight.ToInt();
                if ((fx < 1) || (fy < 1) || (fw < 1) || (fh < 1)) return false;
                if ((fw < 50) || (fh < 50)) return false;  
                this.Left   = fx;
                this.Top    = fy;
                this.Width  = fw;
                this.Height = fh;                              
                return true;
            } catch 
            {
                sql = string.Format("DELETE FROM fbaFormPosition WHERE FormName = '{0}' AND UserID = {1};", this.Name, Var.UserID );
                sys.Exec(DirectionQuery.Local, sql);
                return false;
            }           
        }
        
        #endregion Region. Сохранение и восстановление размеров формы.       
        
        #region Region. Разное.
                      
        /// <summary>
        /// Метод формы - устанавливает в Enabled = false все компоненты выбора на форме.
        /// Используется для того чтобы открыть форму только на просмотр.
        /// </summary>
        /// <param name="exceptControlsName">Список имен компонентов через запятую, которые не должнеы становиться Enabled = false</param>
        public void SetShowOnly(string exceptControlsName = "")
        {
            if (Var.IsDesignMode) return;
            FormFBA.FormSetShowOnly(this.Controls, exceptControlsName);
        }
                            
        /// <summary>
        /// Метод формы - устанавливает в Enabled = false все компоненты выбора на форме.
        /// Используется для того чтобы открыть форму только на просмотр.
        /// Сделать форму только для чтения. Все компоненты выбора на форме 
        /// установить в Enabled = false.
        /// ExceptControlsName: ;btnOK;btnCancel;btnSomething; 
        /// </summary>
        /// <param name="controls">Список имен компонентов через запятую, которые не должнеы становиться Enabled = false</param>
        /// <param name="exceptControlsName">Список имен компонентов через запятую, которые не должнеы становиться Enabled = false</param>       
        public static void FormSetShowOnly(Control.ControlCollection controls, string exceptControlsName = "")
        {                                
            foreach(Control control in controls)
            {                      
                FormSetShowOnly(control.Controls, exceptControlsName);                                         
                string compType = control.GetType().ToString();
                compType = sys.TruncateType(compType, true);
                const string statndartButtons = ";Cancel;Delete;Ok;OK;";       
                if (statndartButtons.IndexOfEx(control.Text) > 0) continue;                               
                if ((compType != "TextBox")       &&
                    (compType != "CheckBox")      &&
                    (compType != "ComboBox")      &&                      
                    (compType != "DataGridView")  &&
                    (compType != "RadioButton")) continue;                                                                   
                if (exceptControlsName == control.Name) continue;                             
                control.Enabled = false;
                                             
                /*control.Enabled = false;
                else
                {
                    if (CompType == "Button") 
                    {
                        bool EnableComp = false;                        
                        if (control.Text == "Cancel") EnableComp = true;
                        if (control.Text == "Delete") EnableComp = true;
                        if (control.Text == "Ok")     EnableComp = true;
                        control.Enabled = EnableComp;                            
                    }                                            
                }*/
            }                    
        }
        
        ///Присвоить текст кнопке Ok в зависимости от действия.
        public static void SetTextButtonOk(Operation operation, Control control)
        {             
            if (operation == Operation.Add)  control.Text = "Add";
            if (operation == Operation.Edit) control.Text = "Update";
            if (operation == Operation.Del)  control.Text = "Delete";
        }          
       
       
		/// <summary>
		/// Проверка комронентов (у которых признак ErrorIfNull != "") 
        /// на то что значение Text этих заполнено. Если Text пустое, то возвращается значение ERRORIFNULL.  
		/// </summary>
		/// <param name="controls">Список контролов</param>
		/// <param name="dtArray"></param>
		/// <returns></returns>
        public static string ErrorIfNull(Control.ControlCollection controls, out System.Data.DataTable dtArray)
        {            
            string errorText = "";
            dtArray = new System.Data.DataTable();
            dtArray.Columns.Add("Name", typeof(string));
            dtArray.Columns.Add("Text", typeof(string));
            ErrorIfNullCollect(controls, ref dtArray, ref errorText);                      
            return errorText;       
        }
            
      
        /// <summary>
        /// Показать ошибки если есть. Если есть ошибки результат true.
        /// </summary>
        /// <returns>Если есть компоненты (у которых установлено свойство EditFBA, TextBoxFBA, ComboBoxFBA, FastColoredTextBoxFBA с незаполненным свойством Text то возникает ошибка.</returns>
        public bool ErrorIfNullExists()
        {
            System.Data.DataTable dtArray;
            string errorMes = ErrorIfNull(this.Controls, out dtArray);
            if (errorMes != "") 
            {
                sys.SM(errorMes);
                return true;
            }
            return false;
        }
        
        ///Сборка текста ошибок, если значение компонентов пустое. Метод только для ErrorIfNull. 
        private static void ErrorIfNullCollect(Control.ControlCollection controls, ref System.Data.DataTable dtArray, ref string errorText)
        {                                
            foreach(Control control in controls)
            {                      
                ErrorIfNullCollect(control.Controls, ref dtArray, ref errorText);                                         
                string compType = control.GetType().ToString();
                compType = sys.TruncateType(compType, false);
                string compName = control.Name;
                string emptyText = "";
                if (compType == "TextBoxFBA")
                {     
                    TextBoxFBA ct = (TextBoxFBA)control;                   
                    if ((ct.Text == "") && (ct.ErrorIfNull != "")) emptyText = ct.ErrorIfNull;                                                             
                }
                 
				if (compType == "EditFBA")
                {     
                    EditFBA ct = (EditFBA)control;                   
                    if ((ct.Text == "") && (ct.ErrorIfNull != "")) emptyText = ct.ErrorIfNull;                                                             
                }
				
                if (compType == "ComboBoxFBA")
                {
                    ComboBoxFBA ct = (ComboBoxFBA)control;                   
                    if ((ct.Text == "") && (ct.ErrorIfNull != "")) emptyText = ct.ErrorIfNull;
                }
                if (compType == "FastColoredTextBoxFBA")
                {
                    FastColoredTextBoxFBA ct = (FastColoredTextBoxFBA)control;                   
                    if ((ct.Text == "") && (ct.ErrorIfNull != "")) emptyText = ct.ErrorIfNull;
                }
                if (!control.Enabled) continue;                
                if (control.BackColor == Color.LightPink) control.BackColor = System.Drawing.SystemColors.Info;
                if (string.IsNullOrEmpty(emptyText)) continue;                                                
                control.BackColor =  Color.FromArgb(255, 236, 239 );   //Color.LightPink;                           
                errorText = errorText + emptyText + Var.CR;
                DataRow row = dtArray.NewRow(); 
                var ErrorRow = new string[2];
                ErrorRow[0] = compName;
                ErrorRow[1] = emptyText;
                row.ItemArray = ErrorRow;                 
            }                    
        }
               
        #endregion Region. Разное.
               
        #region Region. История введенных значений в TextBox или ComboBox.
        
        //Методы сделаны Static, чтобы была возможнсть использовать и на объектах Form.
         
		/// <summary>
		/// Чтение из локальной БД истории всех введенных значений (только для TextBoxFBA и ComboBoxFBA)
        /// и запись истории в свойство ValueArray. 
		/// </summary>
		/// <returns></returns>
        public bool ReadArrayHist()
        {
            return ReadArrayHist(this);
        }
        
        ///Чтение из локальной БД истории всех введенных значений (только для TextBoxFBA и ComboBoxFBA)
        ///и запись истории в свойство ValueArray.
        public static bool ReadArrayHist(Form form)
        {                              
            string formName = form.Name;           
            string sql = string.Format("SELECT t1.CompName, t1.Value, t1.DataValue, t2.CNT " + Var.CR +
                "FROM fbaValueHist t1  " + Var.CR +
                "LEFT JOIN             " + Var.CR +
                "(SELECT CompName, Count(Value) AS CNT FROM fbaValueHist " + Var.CR +
                "  WHERE FormName = '{0}'  GROUP BY CompName " + Var.CR +
                ") t2 ON t1.CompName = t2.CompName           " + Var.CR +
                "WHERE t1.FormName = '{0}'                   " + Var.CR +
                "ORDER BY t1.CompName, t1.DataValue DESC     " + Var.CR, formName);  //AND UserID = '{1}'          
            System.Data.DataTable dt;
            if (!sys.SelectDT(DirectionQuery.Local, sql, out dt)) return false;
            string compNameCurrent = "";
            string[] arr = null;
            int indexRow = 0;                     
            for (int i = 0; i < dt.Rows.Count; i++)
            {              
                string compName  = dt.Value(i, "CompName");
                string value     = dt.Value(i, "Value");
                string dataValue = dt.Value(i, "DataValue");
                string cnt       = dt.Value(i, "CNT");
            
                if (compNameCurrent != compName) 
                {
                    if (compNameCurrent != "")
                    {
                        if (!ReadArrayHistData(form, compNameCurrent, arr)) continue;                        
                    }
                      
                    arr = new string[cnt.ToInt()];
                    compNameCurrent = compName;
                    indexRow = 0;                   
                }
                
                if (arr == null) continue;
                arr[indexRow] = value;
                indexRow++;
                
                if (i == (dt.Rows.Count - 1))
                {
                    if (!ReadArrayHistData(form, compNameCurrent, arr)) continue;                                                                                    
                }                                            
            }   
            return true;
        }              
        
        ///Присваиваем значение массива компоненту. Если это ComboBox, то и свойству Items.
        ///Метод только для ReadArrayHist.
        private static bool ReadArrayHistData(Form form, string CompName, string[] Arr)
        {
            Control control = form.Controls.Find(CompName, true).FirstOrDefault();
            if (control == null) return false;                     
            string compType = control.GetType().ToString();
            compType = sys.TruncateType(compType, false);
            if (compType == "TextBoxFBA")            
            {
                bool saveValueHistory = ((TextBoxFBA)control).SaveValueHistory;
                if (!saveValueHistory) return true;
                ((TextBoxFBA)control).ValueArray = Arr;
            }
            if (compType == "ComboBoxFBA") 
            {
                bool saveValueHistory = ((ComboBoxFBA)control).SaveValueHistory;
                if (!saveValueHistory) return true; 
                ((ComboBoxFBA)control).ValueArray = Arr;
                //Если свойство ValueHistoryInItems = true, 
                //которое указывает на то, что всю историю значений нужно запихать в Items, то запихиваем
                if (((ComboBoxFBA)control).ValueHistoryInItems) 
                {
                    ((ComboBoxFBA)control).Items.Clear();
                    for (int N = 0; N < Arr.Length; N++)
                        ((ComboBoxFBA)control).Items.Add(Arr[N]);                                                                  
                }
            } 
            return true;
        }             
        
        /// <summary>
        /// Запись текущих значений компонентов TextBox и ComboBox в локальную БД.
        /// </summary>
        /// <returns></returns>
        public bool WriteArrayHist()
        {
            return WriteArrayHist(this);
        }
               
        /// <summary>
        /// Запись текущих значений компонентов TextBox и ComboBox в локальную БД.
        /// </summary>
        /// <param name="form">Ссылка на форму System.Windows.Form</param>
        /// <returns></returns>
        public static bool WriteArrayHist(Form form)
        {
            string values = WriteArrayHistData(form.Name, form.Controls);
            if (values == "") return false;
            values = values.Substring(0, values.Length - 12) + ";";           
            string sql = "INSERT INTO fbaValueHist (EntityID, UserID, FormName, CompName, Value, DataValue) " + Var.CR + values;                                    
            return sys.Exec(DirectionQuery.Local, sql);
        }
                   
        //Метод только для WriteArrayHist.      
        private static string WriteArrayHistData(string formName, Control.ControlCollection controls)
        {                             
            if (controls.Count == 0) return ""; 
            string  sql = "";
             
            foreach(Control control in controls)
            {                      
                sql = sql + WriteArrayHistData(formName, control.Controls);                            
                if (control.Tag != null)
                {                                                                           
                    string compType = control.GetType().ToString();
                    string compName = control.Name;
                    compType = sys.TruncateType(compType, false);
                    string value = "";
                    string[] arr;
                    if (compType == "TextBoxFBA")   
                    {
                        if (!((TextBoxFBA)control).SaveValueHistory) continue;
                        arr   = ((TextBoxFBA)control).ValueArray;
                        value = ((TextBoxFBA)control).Text;
                    }
                    else if (compType == "ComboBoxFBA")
                    {
                        if (!((ComboBoxFBA)control).SaveValueHistory) continue;
                        arr = ((ComboBoxFBA)control).ValueArray;
                        value = ((ComboBoxFBA)control).Text;
                    } else continue;
                     
                    if (arr != null)
                    if (Array.IndexOf(arr, value) > -1) continue;
                    if (value.Length > 250) continue;
                    if (value == "") continue;
                    sql = sql + string .Format("SELECT 4, {0},'{1}','{2}','{3}',{4}",  
                                          Var.UserID , formName, compName, value, sys.DateTimeCurrent(ServerType.SQLite))
                                          + " UNION ALL" + Var.CR;
                    
                }               
            }
            return sql;            
        }
              
        /// <summary>
        /// Получить выбранное пользователем значение из истории ввода значений в компонент.
        /// </summary>
        /// <param name="compName">Имя компонента на форме</param>
        public string GetHistoryValue(string compName)
        {
           object control =  this.Controls.Find(compName, true).FirstOrDefault();
           return GetHistoryValue(control);
        }
              
		/// <summary>
		/// Получить выбранное пользователем значение из истории ввода значений в компонент.  
		/// </summary>
		/// <param name="control"></param>
		/// <returns>Значение своства Text</returns>
        public string GetHistoryValue(object control)
        {
            string compType = control.GetType().ToString();
            compType = sys.TruncateType(compType, false);
            string[] ar = null;           
            if ((compType != "TextBoxFBA") && (compType != "ComboBoxFBA")) 
            {
                sys.SM("Для данного типа компонента не поддерживается сохранение истории.", MessageType.Information);
                return "";
            }
            if (compType == "TextBoxFBA")  ar = ((TextBoxFBA)control).ValueArray;  
            if (compType == "ComboBoxFBA") ar = ((ComboBoxFBA)control).ValueArray;  
            if (ar == null) goto Finish;            
            string[,] selectedValues;
            selectedValues = Arr.ArrayView("History of entered values", "Value", ar);
            if (selectedValues == null) goto Finish;
            if (selectedValues.GetLength(0) == 0) goto Finish;
            if (selectedValues.GetLength(1) == 0) goto Finish;
            return selectedValues[0,0];           
            Finish:
            //sys.SM("History empty.", MessageType.Information);
            return "";     
        }

        #endregion Region. История введенных значений в TextBox или ComboBox.        

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormFBA
            // 
            this.ClientSize = new System.Drawing.Size(296, 228);
            this.Name = "FormFBA";
            this.ResumeLayout(false);

        }      
    }

    /// <summary>
    /// Упрощенный вариант формы.
    /// </summary>
    public class FormSim: Form
    {
        //private Color _Color1 = System.Drawing.SystemColors.Control; //Color.Red;
        //private Color _Color2 = Color.Gainsboro; //Color.Black;
        //private float _ColorAngle = 30f;
        
        ///Конструктор.
        public FormSim()
        {          
            DoubleBuffered = true;
            ShowInTaskbar  = false;
            StartPosition  = System.Windows.Forms.FormStartPosition.CenterParent;
            Font = Var.font1;
            //Для ускорения ресайза формы.
            this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };
            //this.SetStyle( ControlStyles.ResizeRedraw, true );           
            //Icon = sys.ico1;
            //return;

            //if (Icon != null) return;
            //if (Var.FormMainObj != null)     this.Icon = Var.FormMainObj.Icon;
            //else if (this.MdiParent != null) this.Icon = this.MdiParent.Icon; 
            //else if (this.Owner != null)     this.Icon = this.Owner.Icon;                 
        }
    
        //Для красоты делаем фон формы градиентным. Работает, но не нужно.
        /*protected override void OnPaintBackground(PaintEventArgs e)
        {         
            Graphics g = e.Graphics;          
            Rectangle rBackground = new Rectangle(0, 0, this.Width, this.Height);            
            System.Drawing.Drawing2D.LinearGradientBrush bBackground 
                = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, _Color1, _Color2, _ColorAngle);                    
            g.FillRectangle(bBackground, rBackground);
            bBackground.Dispose();
        }*/
    }
}
