
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 06.10.2017
 * Время: 17:16
 */
 
using System;       
using System.Windows.Forms;
using System.Data; 
namespace FBA
{    
	/// <summary>
	/// Компонент выбора атрибута модели данных.   
	/// </summary>
    public partial class CompAttrTreeFBA : UserControl
    {
        System.Data.DataTable DT; 
        
        /// <summary>
        /// Сокращение атрибута
        /// </summary>
        public string AttrBrief   = ""; 

		/// <summary>
        /// Сокращение сущности
        /// </summary>       
        public string EntityBrief = ""; 
        
        /// <summary>
        /// ИД сущности атрибута
        /// </summary>
        public string EntityRefID = "";
                
        /// <summary>
        /// Cобытие выбора атрибута
        /// </summary>
        public event AttrEventHandler SelectedAttr;
    
        /// <summary>
        /// Событие выбора атрибута в дереве.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSelectedAttr(SelectAttrEventArgs e)
        {
            if (SelectedAttr != null) SelectedAttr(this, e);
        }
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        public CompAttrTreeFBA()
        {                           
            InitializeComponent();      
            treeViewAttr.ImageList = imageList1;            
            treeViewAttr.BeforeExpand     += TreeViewAttrBeforeExpand;
            treeViewAttr.AfterExpand      += TreeViewAttrAfterExpand;
            treeViewAttr.MouseDoubleClick += TreeViewAttrDoubleClick;
            treeViewAttr.AfterSelect      += TreeViewAttrAfterSelect;                                 
        }
              
        /// <summary>
        /// Получаем все данные по атрибуту.
        /// </summary>
        /// <param name="attr">Строка с атрибутом</param>
        /// <param name="attrBrief">Сокращение атрибута</param>
        /// <param name="attrName">Наименование атрибута</param>
        /// <param name="attrMask">Маска атрибута</param>
        public static void ParseAttrBrief(string attr, out string attrBrief, out string attrName, out string attrMask)
        {
            string attr_EntityID;
            string attr_Type;
            string attr_Kind;
            string table_Type;
            string ref_EntityID;
            string attr_Name;
            string enBriefName1;
            string attr_Brief;
            string attr_Mask; 
            string table_Name;
            string table_Field;
            string table_IDFieldName;
            CompAttrTreeFBA.ParseAttrTag(attr, 
                   out attr_EntityID,
                   out attr_Type,
                   out attr_Kind,
                   out table_Type,
                   out ref_EntityID,
                   out attr_Name,
                   out enBriefName1,
                   out attr_Brief,
                   out attr_Mask,
                   out table_Name,
                   out table_Field,
                   out table_IDFieldName);
            attrBrief = attr.StrBeforeStr("|");
            attrName  = attr_Name;
            attrMask  = attr_Mask;
        }
        
        ///Разделяем параметр на несколько, по разделютелю точка с запятой.
        public static void ParseAttrTag(string param, 
                              out string attr_EntityID,
                              out string attr_Type,
                              out string attr_Kind,
                              out string table_Type,
                              out string ref_EntityID,
                              out string attr_Name,
                              out string enBriefName1,
                              out string attr_Brief,
                              out string attr_Mask,
                              out string table_Name,
                              out string table_Field,
                              out string table_IDFieldName)
        {
            attr_EntityID     = param.StringBetween("Attr_EntityID=",     ";");
            attr_Type         = param.StringBetween("Attr_Type=",         ";");
            attr_Kind         = param.StringBetween("Attr_Kind=",         ";");
            table_Type        = param.StringBetween("Table_Type=",        ";");
            ref_EntityID      = param.StringBetween("Ref_EntityID=",      ";");
            attr_Name         = param.StringBetween("Attr_Name=",         ";");
            enBriefName1      = param.StringBetween("EnBriefName1=",      ";");
            attr_Brief        = param.StringBetween("Attr_Brief=",        ";");
            attr_Mask         = param.StringBetween("Attr_Mask=",         ";");         
            table_Name        = param.StringBetween("Table_Name=",        ";");
            table_Field       = param.StringBetween("Table_Field=",       ";");
            table_IDFieldName = param.StringBetween("Table_IDFieldName=", ";");
        }
        
        ///Определяем картинку для узла.
        private int GetImageIndex(string attr_Type, string attr_Kind, string table_Type)
        {           
            /*
            Показывать атрибуты - собственные (EnChildID = EnID)
            Показывать атрибуты - унаследованные (EnChildID != EnID)
            Показывать атрибуты - поля (Attr_Type = 1)
            Показывать атрибуты - ссылки (Attr_Type = 2)
            Показывать атрибуты - универсальные ссылки (Attr_Type = 3)
            Показывать атрибуты - массивы связанных объектов (Attr_Type = 4)
            Показывать атрибуты - из базы данных (Attr_Kind = 1)
            Показывать атрибуты - системные (Attr_Kind = 2)
            Показывать атрибуты - вычисляемые на MSQL (Attr_Kind = 3)
            Показывать атрибуты - неисторичные (Table_Type = 1)
            Показывать атрибуты - историчные (Table_Type = 2)
            Показывать атрибуты - входящие в наименование объекта (Attr_NameOrder <> '')
            Показывать атрибуты - ключевые
            Показывать атрибуты - обязательные
            Показывать атрибуты - запрещенные к выводу в гибких таблицах
             
            Attr_Type = 1 - (Поле)        Поле
            Attr_Type = 2 - (Ссылка)      Ссылка
            Attr_Type = 3 - (УниСсылка)   Универсальная ссылка
            Attr_Type = 4 - (Массив)      Массив
            
            Attr_Kind = 1 - (Простой)     Атрибут из базы данных
            Attr_Kind = 2 - (Системный)   Системный
            Attr_Kind = 3 - (Вычисляемый) Вычисляемый
            */ 
    
            /*Иконки:
            0 - Системный 
            1 - Поле
            2 - Ссылка
            3 - УниСсылка
            4 - Массив
            5 - Вычисляемый
            6 - Вычисляемая ссылка
            7 - Сущность
            8 - Какая-то ошибка.
            */
            if (attr_Kind == "1") 
            {
                if (attr_Type == "1") 
                {
                    if (table_Type == "2") return 9;
                    return 1;
                }
                if (attr_Type == "2") return 2;
                if (attr_Type == "3") return 3;
                if (attr_Type == "4") return 4;
                return 8;                 
             }
             if (attr_Kind == "3") 
             {
                if (attr_Type == "1") return 5;
                if (attr_Type == "2") return 6;              
                return 8;                 
             }
             return 8;
        }
        
        ///Добавление элемента в дерево.
        private void AddSysAttrOne(TreeNode node, string attr, string tagStr)
        {           
            var node1  = new TreeNode();
            node1.Text = attr; 
            node1.Tag  = tagStr;                      
            node1.ImageIndex = 0;
            node1.SelectedImageIndex = node1.ImageIndex;
            node.Nodes.Add(node1);
        }
        
        ///Добавление системных атрибутов в каждую сущность. 
        private void AddSysAttrList(TreeNode node)
        {    //Attr_EntityID=1874;Attr_Type=1;Attr_Kind=1;Ref_EntityID=0;Attr_Name=Дата рождения Застрахованного;EnBriefName1=Бордеро договор;Attr_Brief=ДатаРожденияЗастрахованного;Attr_Mask=@S15;
            AddSysAttrOne(node, "Object ID",    "Attr_EntityID=;Attr_Type=1;AttrKind=2;Ref_EntityID=;Attr_Name=Object ID;EnBriefName1=;Attr_Brief=ObjectID;Attr_Mask=@S10;");
            AddSysAttrOne(node, "Object Name",  "Attr_EntityID=;Attr_Type=1;AttrKind=2;Ref_EntityID=;Attr_Name=Object Name;EnBriefName1=;Attr_Brief=ObjectName;Attr_Mask=@S50;");
            AddSysAttrOne(node, "Entity ID",    "Attr_EntityID=;Attr_Type=1;AttrKind=2;Ref_EntityID=;Attr_Name=Entity ID;EnBriefName1=;Attr_Brief=EntityID;Attr_Mask=@S10;");
            AddSysAttrOne(node, "Entity Brief", "Attr_EntityID=;Attr_Type=1;AttrKind=2;Ref_EntityID=;Attr_Name=Entity Brief;EnBriefName1=;Attr_Brief=EntityBrief;Attr_Mask=@S50;");
            AddSysAttrOne(node, "Entity Name",  "Attr_EntityID=;Attr_Type=1;AttrKind=2;Ref_EntityID=;Attr_Name=Entity Nam;EnBriefName1=;Attr_Brief=EntityName;Attr_Mask=@S50;");                                  
        }               
         
        ///Для ускорения загрузки дерева, отключаем/включаем прорисовку.
        private void TreeViewAttrAfterExpand(object sender, TreeViewEventArgs e)
        {
            treeViewAttr.EndUpdate();
        }              
        
        ///Наполнение узла происходит только в момент раскрытия узла по крестику.
        private void TreeViewAttrBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeViewAttr.BeginUpdate();             
            TreeNode fNode = e.Node.FirstNode;
            if (fNode.Text != "Expanding...") return; 
            fNode.Remove();                
            string nodeTag = e.Node.Tag.ToString();
            string attr_EntityID;
            string attr_Type;
            string attr_Kind;
            string table_Type;
            string ref_EntityID;
            string attr_Name;
            string enBriefName1;
            string attr_Brief;
            string attr_Mask;
            string table_Name;
            string table_Field;
            string table_IDFieldName;
            ParseAttrTag(nodeTag, 
                   out attr_EntityID,
                   out attr_Type,
                   out attr_Kind,
                   out table_Type,
                   out ref_EntityID,
                   out attr_Name,
                   out enBriefName1,
                   out attr_Brief,
                   out attr_Mask,
                   out table_Name,
                   out table_Field,
                   out table_IDFieldName);
              
            if (attr_EntityID == "0") return;
            if ((attr_Type    != "2") && (attr_Type != "4")) return;
            DataRow[] arrdDr = DT.Select("EnChildID = " + ref_EntityID);
            AddSysAttrList(e.Node); 
            foreach (DataRow dr in arrdDr)
            {                                                                              
                attr_EntityID     = dr["Attr_EntityID"].ToString();
                attr_Type         = dr["Attr_Type"].ToString();
                attr_Kind         = dr["Attr_Kind"].ToString();
                table_Type        = dr["Table_Type"].ToString();
                ref_EntityID      = dr["Ref_EntityID"].ToString();
                attr_Name         = dr["Attr_Name"].ToString();
                enBriefName1      = dr["EnBriefName1"].ToString();
                attr_Brief        = dr["Attr_Brief"].ToString();
                attr_Mask         = dr["Attr_Mask"].ToString();
                table_Name        = dr["Table_Name"].ToString();
                table_Field       = dr["Table_Field"].ToString();
                table_IDFieldName = dr["Table_IDFieldName"].ToString();
                nodeTag       = "Attr_EntityID="     + attr_EntityID     + ";" + 
                                "Attr_Type="         + attr_Type         + ";" +
                                "Attr_Kind="         + attr_Kind         + ";" +
                                "Ref_EntityID="      + ref_EntityID      + ";" +
                                "Attr_Name="         + attr_Name         + ";" +
                                "EnBriefName1="      + enBriefName1      + ";" + 
                                "Attr_Brief="        + attr_Brief        + ";" +
                                "Attr_Mask="         + attr_Mask         + ";" +
                                "Table_Name="        + table_Name        + ";" +
                                "Table_Field="       + table_Field       + ";" +
                                "Table_IDFieldName=" + table_IDFieldName + ";";
                var node1  = new TreeNode();
                node1.Text = dr["Attr_Name"].ToString();
                node1.Tag  = nodeTag;
                node1.ImageIndex = GetImageIndex(attr_Type, attr_Kind, table_Type);
                node1.SelectedImageIndex = node1.ImageIndex; 
                e.Node.Nodes.Add(node1);
                
                if ((attr_Type == "2") || (attr_Type == "4"))  //2 - ссылка, 4 - массив.
                {
                    var node2 = new TreeNode();
                    node2.Text = "Expanding...";
                    node2.Tag  = "0";
                    node1.Nodes.Add(node2);
                }                                                               
            }             
        }
    
        private string GetSelectedAttrBrief()
        {
            if (treeViewAttr.SelectedNode == null) return "";             
            string selectedTag = "";
            string nodeTag; 
            string attr_EntityID;
            string attr_Type;
            string attr_Kind;
            string table_Type;
            string ref_EntityID;
            string attr_Name;
            string enBriefName1;
            string attr_Brief;  
            string attr_Mask;
            string table_Name;
            string table_Field;
            string table_IDFieldName;
            
            string attrPath = "";  
            TreeNode tn = treeViewAttr.SelectedNode;
            
            while (tn != null)
            {
                nodeTag = tn.Tag.ToString();
                if (selectedTag == "") selectedTag = nodeTag;
                ParseAttrTag(nodeTag,
                   out attr_EntityID,
                   out attr_Type,
                   out attr_Kind,
                   out table_Type,
                   out ref_EntityID,
                   out attr_Name,
                   out enBriefName1,
                   out attr_Brief,
                   out attr_Mask,
                   out table_Name,
                   out table_Field,
                   out table_IDFieldName);
                tn = tn.Parent; 
                if (attr_Brief == "") continue;
                if (attrPath == "") attrPath = attr_Brief;
                    else attrPath = attr_Brief + "." + attrPath;                                                                       
            }                        
            return attrPath + "|" + selectedTag;
        }
               
        ///Двойной клик - выбор элеменат дерева (атрибута) и срабатывание события выбора.
        ///Перед двойным кликом срабатывает одинарный, поэтому AttrBrief уже заполнен.
        private void TreeViewAttrDoubleClick(object sender, EventArgs e)
        {                
            OnSelectedAttr(new SelectAttrEventArgs(AttrBrief));               
        }        
        ///Одинарный клик - выбор элеменат дерева (атрибута)
        private void TreeViewAttrAfterSelect(object sender, EventArgs e)
        {            
            AttrBrief = GetSelectedAttrBrief();
        }
        
        ///Получение фильтра для отображения атрибутов.
        private string GetWHERE()
        {
            /*
            Показывать атрибуты - собственные (EnChildID = EnID)
            Показывать атрибуты - унаследованные (EnChildID != EnID)
            Показывать атрибуты - поля (Attr_Type = 1)
            Показывать атрибуты - ссылки (Attr_Type = 2)
            Показывать атрибуты - универсальные ссылки (Attr_Type = 3)
            Показывать атрибуты - массивы связанных объектов (Attr_Type = 4)
            Показывать атрибуты - из базы данных (Attr_Kind = 1)
            Показывать атрибуты - системные (Attr_Kind = 2)
            Показывать атрибуты - вычисляемые на MSQL (Attr_Kind = 3)
            Показывать атрибуты - неисторичные (Table_Type = 1)
            Показывать атрибуты - историчные (Table_Type = 2)
            Показывать атрибуты - входящие в наименование объекта (Attr_NameOrder <> '')
            Показывать атрибуты - ключевые
            Показывать атрибуты - обязательные
            Показывать атрибуты - запрещенные к выводу в гибких таблицах
            */
           string whereStr = "WHERE 1=1 ";
           if (!tsAttr_N1.Checked)  whereStr = whereStr + "AND NOT (EnChildID = EnID) ";
           if (!tsAttr_N2.Checked)  whereStr = whereStr + "AND NOT (EnChildID <> EnID) ";
           if (!tsAttr_N3.Checked)  whereStr = whereStr + "AND NOT (Attr_Type = 1) ";                   
           if (!tsAttr_N4.Checked)  whereStr = whereStr + "AND NOT (Attr_Type = 2) ";          
           if (!tsAttr_N5.Checked)  whereStr = whereStr + "AND NOT (Attr_Type = 3) ";           
           if (!tsAttr_N6.Checked)  whereStr = whereStr + "AND NOT (Attr_Type = 4) ";          
           if (!tsAttr_N7.Checked)  whereStr = whereStr + "AND NOT (Attr_Kind = 1) ";           
           if (!tsAttr_N8.Checked)  whereStr = whereStr + "AND NOT (Attr_Kind = 2) "; 
           if (!tsAttr_N9.Checked)  whereStr = whereStr + "AND NOT (Attr_Kind = 3) ";           
           if (!tsAttr_N10.Checked) whereStr = whereStr + "AND NOT (Table_Type = 1) ";           
           if (!tsAttr_N11.Checked) whereStr = whereStr + "AND NOT (Table_Type = 2) "; 
           if (!tsAttr_N12.Checked) whereStr = whereStr + "AND NOT (Attr_NameOrder <> '') ";
           return whereStr;
        }
                   
        /// <summary>
        /// Загрузить дерево сущностей.Здесь происходит наполнение только корневого узла дерева.
        /// т.е. список сущностей. Остальные узлы наполняются в TreeViewAttrBeforeExpand.
        /// </summary>
        /// <param name="entityRefID">Ссылка на сущность</param>
        public void LoadAttrTree(string entityRefID)
        {                        
            if (entityRefID == "")
            {
                sys.SM("Ошибка. Не указан ИД сущности!");
                return;
            }
            this.EntityRefID = entityRefID;
            Var.conLite.SelectDT("SELECT DISTINCT " +
                "Attr_EntityID,     " + 
                "Attr_EntityBrief,  " +
                "EnBriefName1,      " +
                "Attr_Brief,        " +
                "Attr_Name,         " +
                "Attr_Type,         " +
                "Attr_Kind,         " +
                "Attr_Mask,         " +
                "Table_Type,        " +
                "Table_Name,        " +
                "Table_Field,       " +
                "Table_IDFieldName, " +
                "Ref_EntityID,      " +
                "Ref_EntityBrief,   " +
                "EnChildID          " +              
                "FROM fbaAttrParent " + GetWHERE() + " ORDER BY Attr_Brief", out DT);
            treeViewAttr.Nodes.Clear();             
            if (DT.Rows.Count == 0) return;           
            DataRow[] ArrdDr = DT.Select("EnChildID = '" + entityRefID + "'");
            if (ArrdDr.Length == 0) return; 
            DataRow dr1 = ArrdDr[0];
            this.EntityBrief = dr1["EnBriefName1"].ToString();              
            var node  = new TreeNode();            
            node.Text = this.EntityBrief;
            node.Tag  = "0";                      
            node.ImageIndex = 7;
            node.SelectedImageIndex = node.ImageIndex;           
            treeViewAttr.Nodes.Add(node);            
            treeViewAttr.BeginUpdate();
            AddSysAttrList(node);
            foreach (DataRow dr in ArrdDr)
            {                   
                string attr_EntityID     = dr["Attr_EntityID"].ToString();
                string attr_Type         = dr["Attr_Type"].ToString();
                string attr_Kind         = dr["Attr_Kind"].ToString();
                string table_Type        = dr["Table_Type"].ToString();
                string ref_EntityID      = dr["Ref_EntityID"].ToString();
                string attr_Name         = dr["Attr_Name"].ToString();
                string enBriefName1      = dr["EnBriefName1"].ToString();
                string attr_Brief        = dr["Attr_Brief"].ToString();
                string attr_Mask         = dr["Attr_Mask"].ToString();
                string table_Name        = dr["Table_Name"].ToString();
                string table_Field       = dr["Table_Field"].ToString();
                string table_IDFieldName = dr["Table_IDFieldName"].ToString();
                string nodeTag = "Attr_EntityID="     + attr_EntityID     + ";" + 
                                 "Attr_Type="         + attr_Type         + ";" +
                                 "Attr_Kind="         + attr_Kind         + ";" +
                                 "Table_Type="        + table_Type        + ";" +
                                 "Ref_EntityID="      + ref_EntityID      + ";" + 
                                 "Attr_Name="         + attr_Name         + ";" +
                                 "EnBriefName1="      + enBriefName1      + ";" + 
                                 "Attr_Brief="        + attr_Brief        + ";" +
                                 "Attr_Mask="         + attr_Mask         + ";" + 
                                 "Table_Name="        + table_Name        + ";" +
                                 "Table_Field="       + table_Field       + ";" +
                                 "Table_IDFieldName=" + table_IDFieldName + ";";
                var node1  = new TreeNode();
                node1.Text           = dr["Attr_Name"].ToString();
                node1.Tag = nodeTag;
                node1.ImageIndex = GetImageIndex(attr_Type, attr_Kind, table_Type);
                node1.SelectedImageIndex = node1.ImageIndex;               
                node.Nodes.Add(node1);
                
                if ((attr_Type == "2") || (attr_Type == "4")) //2 - ссылка, 4 - массив.
                {
                    var node2 = new TreeNode();
                    node2.Text = "Expanding...";
                    node2.Tag  = "0";
                    node1.Nodes.Add(node2);
                }                                              
            }
            node.Expand();
            treeViewAttr.EndUpdate();                       
        }
             
        /// <summary>
        /// Контекстное меню на дереве атрибутов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cmMenu_N1_Click(object sender, EventArgs e)
        {                      
            string attr_EntityID;
            string attr_Type;
            string attr_Kind;
            string table_Type;
            string ref_EntityID;
            string attr_Name;
            string enBriefName1;
            string attr_Brief;  
            string attr_Mask;
            string table_Name;
            string table_Field;
            string table_IDFieldName;
            
            string NodeTag = treeViewAttr.SelectedNode.Tag.ToString();                           
            ParseAttrTag(NodeTag,
                out attr_EntityID,
                out attr_Type,
                out attr_Kind,
                out table_Type,
                out ref_EntityID,
                out attr_Name,
                out enBriefName1,
                out attr_Brief,
                out attr_Mask,
                out table_Name,
                out table_Field,
                out table_IDFieldName);
                string AttrInfo = 
                    "Entity ID: "           + attr_EntityID     + Var.CR +
                    "Entity Name: "         + enBriefName1      + Var.CR +                    
                    "Attribute Type: "      + attr_Type         + Var.CR +
                    "Attribute Kind: "      + attr_Kind         + Var.CR +                                    
                    "Attribute Name: "      + attr_Name         + Var.CR +                    
                    "Attribute Brief: "     + attr_Brief        + Var.CR +
                    "Attribute Mask: "      + attr_Mask         + Var.CR +                            
                    "Table Type: "          + table_Type        + Var.CR +
                    "Table Name: "          + table_Name        + Var.CR +
                    "Table Field: "         + table_Field       + Var.CR +
                    "Table FieldID Name: "  + table_IDFieldName + Var.CR + 
                    "Reference Entity ID: " + ref_EntityID      + Var.CR;
                sys.SM(AttrInfo, MessageType.Information);
        }
        
        private void tsAttr_N1_Click(object sender, EventArgs e)
        {
            LoadAttrTree(EntityRefID);
        }
                                                                              
    }
      
    /// <summary>
    /// Для выбора атрибута
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void AttrEventHandler(object sender, SelectAttrEventArgs e);
    
    /// <summary>
    /// Событие выбора атрибута
    /// </summary>
    public class SelectAttrEventArgs : EventArgs
    {
        private string newValue;
        
        /// <summary>
        /// Для выбора атрибута
        /// </summary>
        /// <param name="newValue"></param>
        public SelectAttrEventArgs(string newValue)
        {            
            this.newValue = newValue;
        }
        
        /// <summary>
        /// Выбранный атрибут
        /// </summary>
        public string NewAttr
        {
            get { return newValue; }
        }        
    }
}
