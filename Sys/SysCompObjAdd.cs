/*
 * Created by SharpDevelop.
 * User: Evgeniy.Travin
 * Date: 20.08.2019
 * Time: 11:23
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Windows.Forms;
using System.Data;

namespace FBA
{
	/// <summary>
	/// Это компонент для выбора из списка доступных значений.
	/// Слева таблица доступных значений, справа - таблица - выбранных значений.
	/// </summary>
	public partial class SysObjAdd : UserControl
	{
		/// <summary>
		/// Левая таблица
		/// </summary>
		public System.Data.DataTable DTObj1;
		
		/// <summary>
		/// Правая таблица
		/// </summary>
		public System.Data.DataTable DTObj2;
		
		/// <summary>
		/// ИД объекта, по которому привязываются записи
		/// </summary>
		public string ObjID1;
		
		/// <summary>
		/// Конструктор.
		/// </summary>
		public SysObjAdd()
		{			
			InitializeComponent();
					
		}
				
		/// <summary>
		/// Добавление одного объекта.
		/// </summary>
		/// <param name="indexRow">Индекс строки</param>
		/// <param name="showMes">Показывать сообщение об ошибке или нет</param>
        private void AddObj(int indexRow, bool showMes)
        {                                      
            if (CheckRowExists(dgvObj1, dgvObj2, indexRow)) 
            {
            	if (showMes) sys.SM("Объект уже добавлен!");
                return;
            }            
            DataRow row1 = DTObj2.NewRow();
            for (int i = 0; i < DTObj2.Columns.Count; i++) 
            {
            	 row1[i] = dgvObj1.Rows[indexRow].Cells[i].Value;
            }  
            DTObj2.Rows.Add(row1); 
        }
                
        /// <summary>
        /// Проверка на то, что объект уже добавлен.
        /// </summary>
        /// <param name="dgv1">Левый грид</param>
        /// <param name="dgv2">Правый грид</param>
        /// <param name="indexRow">Индекс строки</param>
        /// <returns>Если значение уже добавлено, то true</returns>
        private bool CheckRowExists(DataGridView dgv1, DataGridView dgv2, int indexRow)
        {        	
        	if (dgv1.Columns.Count != dgv2.Columns.Count)
        	{
        		sys.SM("Ошибка. Не совпадает количество колонок в таблице источинике и таблице приемнике!");
        		return false;
        	}        	
        	for (int i = 0; i < dgv2.Rows.Count; i++)
            {        		        		
        		int countcol = 0;
        		for (int j = 0; j < dgv2.Columns.Count; j++)
	            {        			        			
        			if (dgv2.Rows[i].Cells[j].Value.ToString() == dgv1.Rows[indexRow].Cells[j].Value.ToString()) countcol++;        			
	            }
        		if (countcol == dgv2.Columns.Count) return true;
        	}
        	return false;
        }
                
        /// <summary>
        /// Добавление/удаление объекта.
        /// </summary>
        /// <param name="sender">Кнопка</param>
        /// <param name="e">EventArgs</param>
		private void BtnObjAddClick(object sender, EventArgs e)
		{
	 		//Добавление одного объекта.
			if (sender == btnObjAdd) AddObj(dgvObj1.SelectedRows[0].Index, true);
                        
            //Добавление всех объектов.
            if (sender == btnObjAddAll)
            {
            	for (int i = 0; i < dgvObj1.Rows.Count; i++) AddObj(i, false);
            }
                
            //Удаление одного объекта.
            if (sender == btnObjDel) dgvObj2.SelectedDeleteFirst();  //sys.DGVDelete(dgvRight2);
            
            //Удаление всех объекта.
            if (sender == btnObjDelAll) dgvObj2.DeleteAll();       
		} 
					
		/// <summary>
		/// Открытие таблиц.
		/// </summary>
		/// <param name="sql1">Для левой таблицы</param>
		/// <param name="sql2">Для правой таблицы</param>
		/// <returns></returns>
		public bool Open(string sql1, string sql2)
		{			       
			if (!sys.SelectDT(DirectionQuery.Remote, sql1, out DTObj1)) return false;
            dgvObj1.DataSource = DTObj1;            
            if (!sys.SelectDT(DirectionQuery.Remote, sql2, out DTObj2)) return false;
            dgvObj2.DataSource = DTObj2; 
            return true;
		}
			
		/// <summary>
		/// Выполнение запросов и показ данных.
		/// </summary>
		/// <param name="tableName">Имя таблицы в которой будет храниться выбранный набор строк. это таблица оношения Obj1 - Obj2</param>	
		/// <param name="fieldObj1">Поле в котром храниться ссылка на объект 1</param>
		/// <param name="fieldObj2">Поле в котром храниться ссылка на объект 2</param>
		/// <param name="objID1">Значение ИД к которому привязывается выбранй список строк</param>
		/// <param name="addFields">Дополнительные поля</param>
		/// <param name="addValues">Дополнительные значения полей. Количество элементов массива addFields должно быть равно количеству элементов массива addValues</param>
		/// <returns>Если успешно, то true</returns>
		public bool SaveChanges(string tableName, 		                          		                        
		                        string fieldObj1,
		                        string fieldObj2,		                        
		                        string objID1,
		                        string[] addFields,
		                        string[] addValues)
		{					
			string sqlInsert = "";			
			string fields = "";
			string values = "";
			if ((addFields != null) && (addValues != null) && (addFields.GetLength(0) == addValues.GetLength(0)))
			for (int i = 0; i < addFields.Length; i++) 
			{				
				fields = fields + "," + addFields[i];
				values = values + "," + addValues[i];
			}
			
			for (int i = 0; i < dgvObj2.Rows.Count; i++)
            {                  
                 string ObjID2 = dgvObj2.ValueByRowIndex(i, "ID");   
                 sqlInsert += "INSERT INTO " + tableName+ " (" + fieldObj1 + "," + fieldObj2 + fields + ") VALUES " +
                     " (" + objID1 + ", " + ObjID2 + values + ");" + Var.CR;                      
            }           
            string SQL = "DELETE FROM " + tableName + " WHERE " + fieldObj1 + " = " + objID1 + ";" + Var.CR + sqlInsert;
            return sys.Exec(DirectionQuery.Remote, SQL);  		
		}		
	}
}
