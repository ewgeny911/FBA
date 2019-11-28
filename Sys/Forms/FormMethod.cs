/*
 * Created by SharpDevelop.
 * User: Evgeniy.Travin
 * Date: 05.07.2019
 * Time: 13:11
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FBA
{
	/// <summary>
	/// Description of FormMethod.
	/// </summary>
	public partial class FormMethod : FormFBA
	{
		/// <summary>
    	/// Конструктор. Установка MdiParent, Icon, обновление таблицы методов.
    	/// </summary>
		public FormMethod()
		{			
			InitializeComponent();			        
            this.MdiParent = Var.FormMainObj; 
            this.Icon = this.MdiParent.Icon;   
			MethodRefresh();             
		}
	                        
        ///Показ методов.
        public bool MethodRefresh()
        {              
        	const string sql =
                    "SELECT t1.ID, " +
        		    "t2.Brief AS Entity," +
					"t1.Action," +         		
                    "t1.Brief, " +                                        
        		    "t1.Value, " +  
					"t1.Comment, " +         		
                    "t1.UserCreateID, " +                            	
                    "t1.DateCreate, " + 
					"t1.UserChangeID, " + 
					"t1.DateChange " +        		
                    "FROM fbaMethod t1 LEFT JOIN fbaEntity t2 ON t1.EntityRef = t2.ID ";            
               if (!sys.SelectGV(DirectionQuery.Remote, sql, dgvMethod)) return false;
               return true;
        }
        
        ///Добавить метод.
        public bool MethodAddOrEdit(Operation operation, string MethodID)
        {           			
			string[] actionList = {"UPDATE", "INSERT", "DELETE", "SELECT"};
			string sql = "SELECT Brief FROM fbaEntity ";
			//sys.SelectComboBox(DirectionQuery.Remote, SQL, frm.tbText1);
			string[] entitlyList = sys.SQLToArray(DirectionQuery.Remote, sql);
			
			string entityBrief = dgvMethod.Value("Entity"); 
			string action      = dgvMethod.Value("Action"); 
			string methodBrief = dgvMethod.Value("Brief"); 
			string methodValue = dgvMethod.Value("Value"); 
			string comment     = dgvMethod.Value("Comment"); 			
			string capForm = operation.ToString() + "entity method";
			
			
			//var frm = new FormValue5(Cap,
			 //                        "Entity", "Action", "Brief", "Value", "Comment", 			                         			                   
			//                         EntityBrief, Action, MethodBrief, MethodValue, Comment,			                         			                        
			//                         entitlyList, action);            		
			//if (frm.ShowDialog() != DialogResult.OK) return false;
			

			var arrvp = new ValueParam[5];  
			arrvp[0].captionValue = "Entity";
        	arrvp[0].componentType = ComponentType.ComboBox;	
        	arrvp[0].values = entitlyList;
        	arrvp[0].value  = entityBrief;
            	
        	arrvp[1].captionValue = "Action";
			arrvp[1].componentType = ComponentType.ComboBox;	
        	arrvp[1].values = actionList;
        	arrvp[1].value  = action;
        	
        	arrvp[2].captionValue = "Brief";
        	arrvp[2].value  = methodBrief;
        	
        	arrvp[3].captionValue = "Value";
        	arrvp[3].value  = methodValue;
        	
        	arrvp[4].captionValue = "Comment";
        	arrvp[4].value  = comment;
        	        		
        	var frm = new FormValue(capForm, arrvp);
            if (frm.ShowDialog() != DialogResult.OK) return false;
            entityBrief = frm.GetValue(0);
            action      = frm.GetValue(1);
            methodBrief = frm.GetValue(2);
            methodValue = frm.GetValue(3);
            comment     = frm.GetValue(4);            
                   		
			//EntityBrief = frm.tbText1.Text;
			//Action      = frm.tbText2.Text;
			//MethodBrief = frm.tbText3.Text; 
			//MethodValue = frm.tbText4.Text;	
			//Comment     = frm.tbText5.Text;
			string EntityID = sys.GetEntityID(entityBrief);
			
			if (operation == Operation.Add)
			{
				sql = "INSERT INTO fbaMethod (" +
                         "UserCreateID, DateCreate, EntityRef, Action, Brief, Value, Comment) VALUES (" + 
                         Var.UserID  + ", " + sys.DateTimeCurrent() + "," + EntityID + ",'" + action + "', '" + methodBrief + "', '" + methodValue + "', '" + comment + "')" ;
            	if (!sys.Exec(DirectionQuery.Remote, sql)) return false; 
            	sys.SM("Метод добавлен!", MessageType.Information);
			}
            if (operation == Operation.Edit)
			{
            	sql = "UPDATE fbaMethod SET " +
            		  "UserCreateID = " + Var.UserID  + 
            		  ",DateCreate  = " + sys.DateTimeCurrent() +
            	      ",EntityRef   = " + EntityID +
            	      ",Action      = '" + action + "'" +
            	      ",Brief       = '" + methodBrief + "'" +
            	      ",Value       = '" + methodValue + "'" +
            	      ",Comment     = '" + comment + "'" +
            		  " WHERE ID = " + MethodID;
            	if (!sys.Exec(DirectionQuery.Remote, sql)) return false; 
            	sys.SM("Метод изменён!", MessageType.Information);
            }
            MethodRefresh();                      
            return true;
        }
        
                 
        ///Удалить метод.
        public bool MethodDel(string MethodID)
        {
            if (MethodID == "") return false;
            string sql = "DELETE FROM fbaMethod WHERE ID = " + MethodID;
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false; 
            MethodRefresh();                               
            sys.SM("Метод удален!", MessageType.Information);
            return true;
        }
          
        
        ///При выборе текста в таблице показываем его. 
		private void DgvMethodDoubleClick(object sender, EventArgs e)
		{
	 		string MethodID   = dgvMethod.Value("ID"); 
			MethodAddOrEdit(Operation.Edit, MethodID);
		}
		
		//Кнопки контекстного меню на таблице методов.
		private void TbRefreshClick(object sender, EventArgs e)
		{	  		
            string MethodID   = dgvMethod.Value("ID"); 
             
 			//Обновить таблицу с методами.
            if (sender == tbRefresh) MethodRefresh();             
           
            //Добавить метод.
            if (sender == tbAdd)  MethodAddOrEdit(Operation.Add, "");
            
            //Редактировать метод.
            if (sender == tbEdit) MethodAddOrEdit(Operation.Edit, MethodID);
            
            //Удалить метод.
            if (sender == tbDelete)  MethodDel(MethodID);                                                  
		}    
	}
}
