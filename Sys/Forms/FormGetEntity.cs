
/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.01.2018
 * Время: 13:47
 */
 
using System;
using System.Windows.Forms;
namespace FBA
{ 
	/// <summary>
	/// Форма выбора сущности
	/// </summary>
    public partial class FormGetEntity : FormSim
    {       
        /// <summary>
        /// Сокращение сущности
        /// </summary>
        public string EntityBrief;
        
    	/// <summary>
        /// ИД сущности
        /// </summary>
    	public string EntityID;
    	
    	/// <summary>
        /// Наименование сущности
        /// </summary>
        public string EntityName;
        
		/// <summary>
        /// Конструктор
        /// </summary>		
		/// <param name="selectInOneClick">Если true, то выбор в один клик, иначе двойной клик.</param>
		/// <param name="entityIDIN">ИД сущности</param>
		/// <param name="entityBriefIN">Сокращение сущности</param>
		/// <param name="entityNameIN">Наименование сущности</param>
        public FormGetEntity(bool selectInOneClick,
                             string entityIDIN,
                             string entityBriefIN, 
                             string entityNameIN)
        {            
            InitializeComponent();         
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;                         
            this.EntityBrief = "";  
            CompEntityTreeFBA1.LoadEntityTree();            
            CompEntityTreeFBA1.SelectInOneClick = selectInOneClick;
            if (entityNameIN == "")
            {
                entityNameIN = sys.GetEntityName(entityIDIN, entityBriefIN);  
            }                      
            CompEntityTreeFBA1.EntityNameNavigate(entityNameIN);
        }
        
        private void FormGetEntity_FormClosing(object sender, FormClosingEventArgs e)
        {
            EntityName   = CompEntityTreeFBA1.EntityName;  
            EntityID     = CompEntityTreeFBA1.EntityID; 
            EntityBrief  = sys.GetEntityBrief(EntityID);
        }
        
        private void EntityTree_SelectedEntity(object sender, SelectEntityEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;          
            Close();
        }
    }
}
