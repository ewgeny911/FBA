
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 16.08.2017
 * Время: 16:30
 */
 
using System;
using System.Windows.Forms;
 
namespace FBA
{       
    /// <summary>
    /// Форма для просмотра и изменений свойств сущности.
    /// </summary>
    public partial class FormEntity : FormFBA
    {
        /// <summary>
        /// Статус закрытия формы входа.
        /// </summary>
    	public int StatusClose = 0;
    	
    	private Operation operation;
        private string ID;
        private string ParentID;  
        private FBA.ObjectRef Obj;
        private bool DoChecked;
                   
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        /// <param name="operation">Операция с сущностью. NotAssigned, Refresh, Add, AddChild, Edit, Del</param>
        /// <param name="id">ИД сущности</param>
        /// <param name="parentId">ИД родителя сущности</param>
        public FormEntity(Operation operation, string id, string parentId)
        {
            InitializeComponent();                                       
            this.operation    = operation;
            this.ID           = id;
            this.ParentID     = parentId;                                     
            if (operation == Operation.Del) SetShowOnly();             
            SetTextButtonOk(operation, btnOk);                                             
            FillData();            
        }                    
        
        /// <summary>
        /// Заполнение свойств компонентов значениями.
        /// </summary>
        private void FillData()
        {                               
            Obj = new FBA.ObjectRef();            
            Obj.SetQueryTable(this, "Main1", "fbaEntity", ID, "ID", "", DirectionQuery.Remote);           
            Obj.AddAttr("Main1.EntityID", "1");  
            Obj.AddAttr("Main1.Feature");                                         
            if (operation == Operation.AddChild) Obj.AddAttr("Main1.ParentID", ParentID);      
            if ((operation == Operation.Edit) || (operation == Operation.Del)) Obj.Read();
            
            DoChecked = false;
            int val = Obj["Main1.Feature"].ToInt(); //   tbFeature.Text.ToInt();
            cbSystem.Checked   = sys.GetBit(val, 0); 
            cbAccObj.Checked   = sys.GetBit(val, 1);
            cbTree.Checked     = sys.GetBit(val, 2);
            cbDiv.Checked      = sys.GetBit(val, 3);
            cbCounter.Checked  = sys.GetBit(val, 4);
            cbProtocol.Checked = sys.GetBit(val, 5); 
            DoChecked = true;                                 
        }  
             
        /// <summary>
        /// Кнопка Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            StatusClose = 2;
            DialogResult = DialogResult.Cancel;
            Close();
        }
             
        /// <summary>
        /// Кнопка Ok.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, EventArgs e)
        {                      
            if (ErrorIfNullExists()) return;
            bool Result = false;
            if (operation != Operation.Del) SetFeature();
            if (operation == Operation.Del)      Result = OperationDelete();
            if (operation == Operation.Add)      Result = Obj.Write();
            if (operation == Operation.AddChild) Result = Obj.Write();
            if (operation == Operation.Edit)     Result = Obj.Write();
            if (Result)
            {
                DialogResult = DialogResult.OK;
                StatusClose = 1;
            } else           
            {
                DialogResult = DialogResult.Cancel;
                StatusClose = 2;            
            }
            Close();
        }
        
        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <returns>Если true, то сущность удалена успешно.</returns>
        private bool OperationDelete()
        {
            if (!sys.SM("Вы хотите действительно удалить сущность?", MessageType.Question, "Удаление сущности")) return false;            
            string sql = "SELECT Count(*) AS cnt FROM fbaAttribute WHERE AttributeEntityID = " + ID;           
            string attrCount = sys.GetValue(DirectionQuery.Remote, sql);
            if (attrCount != "0") 
            {
                sys.SM("Ошибка. У сущности есть атрибуты. Удаление невозможно.");
                return false;
            }
            return Obj.DeleteObject("Main1");         
        }
                 
        /// <summary>
        ///Изменение галок Feature. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSystem_CheckedChanged(object sender, EventArgs e)
        {               
            SetFeature();
        }
          
        /// <summary>
        /// Установка свойств атрибута.
        /// </summary>
        private void SetFeature()
        {
            if (!DoChecked) return;
            string TwoStr =
                cbProtocol.Checked.ToInt().ToString() +
                cbCounter.Checked.ToInt().ToString() +
                cbDiv.Checked.ToInt().ToString() +     
                cbTree.Checked.ToInt().ToString() +    
                cbAccObj.Checked.ToInt().ToString() +     
                cbSystem.Checked.ToInt().ToString();                            
            Obj["Main1.Feature"] = sys.IntConvertFrom2(TwoStr).ToString();                       
        }
                     
        /// <summary>
        /// Установка фокуса на компонент tbBrief. Если не заполнено, то заполяем из наименования.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbBrief_Enter(object sender, EventArgs e)
        {
           if (tbBrief.Text == "") tbBrief.Text = tbName.Text.NameToBrief();
        }
        
        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            this.OnPaint(e);
        }		                   
    }
}
