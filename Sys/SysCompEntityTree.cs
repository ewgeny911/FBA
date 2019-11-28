
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 18.12.2017
 * Время: 18:53
 */
	
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data; 
using System.Linq;

namespace FBA
{
    //Системная                                   = 1 бит 1
    //Объект учета                                = 2 бит 2
    //Древовидная                                 = 3 бит 4
    //Разделена по филиалам                       = 4 бит 8
    //Использовать счетчик универсальных ссылок   = 5 бит 32
    //Содержит протокольную информацию            = 6 бит 64 
        
    /// <summary>
    /// Компонент выбора и редактирвания сущности.  
    /// </summary>
    public partial class CompEntityTreeFBA : UserControl
    {                                      
        System.Data.DataTable dtEnt;  
        
        ///Конструктор.
        public CompEntityTreeFBA()
        {           
            InitializeComponent();
                       
            //treeViewEntity.BeforeExpand     += TreeViewEntity_BeforeExpand;
            //treeViewEntity.AfterExpand      += TreeViewEntity_AfterExpand;
            //treeViewEntity.MouseDoubleClick += TreeViewEntity_DoubleClick;
            //treeViewEntity.AfterSelect      += TreeViewEntity_AfterSelect;                      
            //LoadEntityTree();               
        }       
        
        /// <summary>
        /// ИД сущности
        /// </summary>
        [DisplayName("EntityID"), Description("EntityID"), Category("FBA")]
        public string EntityID { get; set; }
        
        /// <summary>
        /// Имя сущности
        /// </summary>
        [DisplayName("EntityName"), Description("EntityName"), Category("FBA")]
        public string EntityName { get; set; }
        
        /// <summary>
        /// Возможность редактирования дерева сущностей. В контестном меню становятся доступны пункты меню: Add, Edit, Delete.
        /// </summary>
        [DisplayName("Editable"), Description("Available options: Add, Edit, Delete with context menu."), Category("FBA")]
        public bool Editable 
        { 
            get {   return (treeViewEntity.ContextMenuStrip != null); }
            set {                     
                    if (value) treeViewEntity.ContextMenuStrip = cmModel1;
                    else treeViewEntity.ContextMenuStrip = null;
                }
        } 
                            
        /// <summary>
        /// Cобытие выбора сущности.
        /// </summary>
        [DisplayName("SelectedEntity"), Description("SelectedEntity"), Category("FBA")]       
        public event EntityEventHandler SelectedEntity;
        
        /// <summary>
        /// Cобытие выбора сущности.
        /// </summary>     
        [DisplayName("SelectedEntity"), Description("SelectedEntity"), Category("FBA")]               
        protected virtual void OnSelectedEntity(SelectEntityEventArgs e)
        {
            if (SelectedEntity != null) SelectedEntity(this, e);
        }
        
        /// <summary>
        /// Для выбора сущности требуется один щелчок мыши.
        /// </summary>
        [DisplayName("SelectInOneClick"), Description("For choice of entity required a single mouse click."), Category("FBA")]
        public bool SelectInOneClick { get; set; }          
                     
        /// <summary>
        /// Для возможности отключить переисовку дерева при измениии размеров формы, на которой лежит компонент.
        /// </summary>
        public void BeginUpdate()
        { 
            treeViewEntity.BeginUpdate();
        }            
        
        /// <summary>
        /// Для возможности отключить переисовку дерева при измениии размеров формы, на которой лежит компонент.
        /// </summary>
        public void EndUpdate()
        { 
            treeViewEntity.EndUpdate();
        } 
                                           
        /// <summary>
        /// Загрузить дерево сущностей.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public bool LoadEntityTree()
        {             
            if (Var.IsDesignMode) return false;  
            treeViewEntity.ImageList         = imageList1;
            //sys.LoadTreeFromDataTable(treeViewAttr, DTEnt, "ID", "ParentID", "Name", true);
            //TreeNode argentinaNode = new TreeNode { Text = "Аргентина", ImageIndex=0, SelectedImageIndex=0 };
            //treeView1.Nodes.Add(argentinaNode);                                                             
            if (!sys.SelectDT(DirectionQuery.Remote, "SELECT * FROM fbaEntity ", out dtEnt)) return false;  //WHERE ID = 1694
            treeViewEntity.Nodes.Clear();            
            foreach (DataRow dr in dtEnt.Select("ParentID = 0 OR ParentID IS NULL"))            
            {
                var node = new TreeNode(); 				               
                node.Text      = dr["Name"].ToString();
                node.Tag       = dr["ID"];
                string Feature = dr["Feature"].ToString(); 
                
                
                int numberInt;
                int imageIndex = 2;
                if (sys.IsInteger(Feature, out numberInt))
                {
                    if (sys.GetBit(numberInt, 0)) imageIndex = 0;
                    if (sys.GetBit(numberInt, 1)) imageIndex = 1;
                }
                node.ImageIndex = imageIndex;        
                node.SelectedImageIndex = node.ImageIndex;                             
                treeViewEntity.Nodes.Add(node);
                AddNodes(dtEnt, node);
            }
            treeViewEntity.Sort();
            return true;
        }
               
        /// <summary>
        /// Добавление узла дерева сущностей.
        /// </summary>
        /// <param name="dt">System.Data.DataTable</param>
        /// <param name="node">TreeNode</param>
        private void AddNodes(System.Data.DataTable dt, TreeNode node)
        {    
            foreach (DataRow dr in dt.Select("ParentID = " + node.Tag.ToString()))
            {
                var node1 = new TreeNode();
                node1.Text = (string)dr["Name"];              //1- синий, 2 - зеленый, 3 серый
                node1.Tag = dr["ID"];
                string Feature = dr["Feature"].ToString();              
                if      (Feature == "1")  node1.ImageIndex = 0;
                else if (Feature == "5")  node1.ImageIndex = 0;
                else if (Feature == "2")  node1.ImageIndex = 2;
                else if (Feature == "4")  node1.ImageIndex = 2;
                else if (Feature == "34") node1.ImageIndex = 2;
                else node1.ImageIndex = 1;
                node1.SelectedImageIndex = node1.ImageIndex;
                node.Nodes.Add(node1);
                AddNodes(dt, node1);
             }
        } 
  
        /// <summary>
        /// Кнопка фильтр сущностей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnFind_Click(object sender, EventArgs e)
        {                                       
            ActionFind();
        }
  
        /// <summary>
        /// Поиск сущности.
        /// </summary>
        /// <param name="entityName">Имя сущности, которую ищем</param>
        /// <returns>Возвращаетмя сокращение сущности, если не найдено, то возвращается пустая строка</returns>
        public string FindEntityBrief(string entityName)
        {
            DataRow dr = dtEnt.Select("Name = '" + entityName + "'").FirstOrDefault();
            if (dr == null) return "";
            return dr["Brief"].ToString();
        }
               
        /// <summary>
        /// Поиск сущности.
        /// </summary>
        public void ActionFind()
        {            
            if (tbFind.Text == "")
            {
                dgvFind.Visible = false;
                return;
            }
                       
            string sql = string.Format("SELECT Name, Brief FROM fbaEntity WHERE Upper(Name) LIKE Upper('{0}%') OR Upper(Brief) LIKE Upper('{0}%')", tbFind.Text);            
            sys.SelectGV(DirectionQuery.Remote, sql, dgvFind);                   
            if (dgvFind.Rows.Count == 0) 
            {
                dgvFind.Visible = false;
                return;
            }
              
            dgvFind.Visible = true;   
       
            /*TreeNode SelectedNode = sys.SearchNode(tbFind.Text, treeViewEntity.Nodes[0], "Begin", true); //пытаемся найти в поле Text
            if (SelectedNode != null)
            {
                //нашли, выделяем...
                treeViewEntity.SelectedNode = SelectedNode;
                treeViewEntity.SelectedNode.Expand();
                treeViewEntity.Select();
            }*/       
        }             
        
        /// <summary>
        /// Навигация по имени сущности.
        /// </summary>
        /// <param name="entityName">Имя сущности, котроую ещем в дереве</param>
        /// <returns>Если нашли, то true</returns>
        public bool EntityNameNavigate(string entityName)
        {           
            if (entityName == "") return false;
            TreeNode selectedNode = sys.SearchNode(entityName, treeViewEntity.Nodes[0], SearchParam.Begin, true);
            if (selectedNode != null)
            {
                //нашли, выделяем...
                treeViewEntity.SelectedNode = selectedNode;
                treeViewEntity.SelectedNode.Expand();
                treeViewEntity.Select();
                return true;
            }
            return false;            
        }
        
        ///Выбор сущности в фильтре сущностей.
        private void dgvFind_CellClick(object sender, DataGridViewCellEventArgs e)
        {                                                                        
            string selName = dgvFind.Value("Name");             
            dgvFind.Visible = false;
            TreeNode selectedNode = sys.SearchNode(selName, treeViewEntity.Nodes[0], SearchParam.Exact, false);//пытаемся найти в поле Text
            if (selectedNode == null) return;                     
            treeViewEntity.SelectedNode = selectedNode;
            treeViewEntity.SelectedNode.Expand();
            treeViewEntity.Select();         
        }
        
        ///Контекстное меню.
        private void cmModel_N1_Click(object sender, EventArgs e)
        {
            if (treeViewEntity.SelectedNode == null) return;
            if (treeViewEntity.SelectedNode.Tag == null) return;           
            string id          = treeViewEntity.SelectedNode.Tag.ToString();   
			string parentId    = "NULL";               
            //string entityName  = treeViewEntity.SelectedNode.Text;
            Operation operation = Operation.NotAssigned;                 
            if (sender == cmModel_N1) operation = Operation.Add; 
			if (sender == cmModel_N2) operation = Operation.AddChild;             
            if (sender == cmModel_N3) operation = Operation.Edit;
            if (sender == cmModel_N4) operation = Operation.Del;            
            if (sender == cmModel_N5) LoadEntityTree();                           
            if (operation == Operation.NotAssigned) return;    	   
			if (operation == Operation.AddChild) parentId = id;
			if ((operation == Operation.Add) || (operation == Operation.AddChild)) id = "";
			if (operation == Operation.Edit) parentId = sys.GetFirstParentID(id, "");				
            var F1 = new FormEntity(operation, id, parentId);
            F1.Icon = Var.FormMainObj.Icon;
            if (F1.ShowDialog() == DialogResult.OK) LoadEntityTree();                                                                              
        }        
        
        //Для ускорения загрузки дерева, отключаем/включаем прорисовку.              
        //private void TreeViewEntity_AfterExpand(object sender, TreeViewEventArgs e)
        //{
        //    treeViewEntity.EndUpdate();
        //}
        
        //Для ускорения загрузки дерева, отключаем/включаем прорисовку.
        //private void TreeViewEntity_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        //{
        //    treeViewEntity.BeginUpdate();  
        //}
        
        ///Двойной клик - выбор сущности. Возникает событие выбора.
        private void TreeViewEntity_DoubleClick(object sender, EventArgs e)
        {
            //Здесь присвоение EntityID не нужно, так как перед двойным кликом всегда есть одинарный который EntityID и устанавливает. 
            if (!SelectInOneClick) OnSelectedEntity(new SelectEntityEventArgs(EntityID));
        }
        
        //Свойство выбранной сущности присваивается, но событие выбора не возникает.
        private void TreeViewEntity_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetSelectedEntityBrief();
            if (SelectInOneClick) OnSelectedEntity(new SelectEntityEventArgs(EntityID));
        }
        
        private void GetSelectedEntityBrief()
        {           
            if (treeViewEntity.SelectedNode == null) 
            {
                EntityName = "";
                EntityID   = "";
                return;
            }
             
            EntityName  = treeViewEntity.SelectedNode.Text;
            EntityID    = treeViewEntity.SelectedNode.Tag.ToString();
            tbFind.Text = FindEntityBrief(EntityName);// + " (ID " + EntityID + ") ";
        }
        
        ///Перехват нажатия Enter.
        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  ActionFind();
            if (e.KeyCode == Keys.Escape) dgvFind.Visible = false;
        }
    }
      
    /// <summary>
    /// Делегат для события
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void EntityEventHandler(object sender, SelectEntityEventArgs e);
    
    /// <summary>
    /// Для выбора сущности в дереве
    /// </summary>
    public class SelectEntityEventArgs : EventArgs
    {
        private string entityIDValue;
        
        /// <summary>
        /// Событие выбора сущности.
        /// </summary>
        /// <param name="entityID">ИД сущности</param>
        public SelectEntityEventArgs(string entityID)
        {            
            this.entityIDValue = entityID;
        }
        
        /// <summary>
        /// ИД выбранной сущности.
        /// </summary>
        public string EntityID
        {
            get { return entityIDValue; }
        }        
    }
}
