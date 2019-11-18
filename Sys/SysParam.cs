
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 11.11.2017
 * Время: 18:58
 */
 
using System;  
using System.Windows.Forms; 
using System.Linq;    
namespace FBA
{   	
    /// <summary>
    /// Все методы работы с параметрами приложения.
    /// </summary>
    public static class Param
    {            
    	#region Region. Системные параметры. 
  
    	/// <summary>
        /// Получить порт сервера приложений из настроек.
        /// Это такие же параметры как и пользовательские, но проще, и нужны только для работы платформы.
        /// </summary>
        /// <returns>Порт сервера приложений</returns>
        public static string GetSysParam(string ParamName)
        {            
        	return sys.GetValue(DirectionQuery.Remote, "SELECT Value FROM fbaSysParam WHERE Name = '" + ParamName + "'");
        }    	
    	#endregion Region. Параметры параметры.
    	    	    
    	#region Region. Параметры приложения.
         
  		/// <summary>
        /// Запись значения настройки в таблицу настроек fbaParam.
        /// Настройки может быть глобальной (для всех пользователей одна с именем ParamName) и индивидуальная.
        /// Если индивидуальная, то имя ParamName повторяется для разных пользователей.
        /// Если в настройке сохраняются значения компронентов формы, то FormID указывать нужно, в противном случае FormID = ""
        /// </summary>
        /// <param name="direction">Запрос к локальной или удаленнённой базе данных.</param>
        /// <param name="userID">ИД пользователя</param>
        /// <param name="paramName">Имя параметра</param>
        /// <param name="checkGlobal">Глобальный или локальный параметр</param>
        /// <param name="param">Массив параметров</param>
        /// <param name="paramType"></param>
        /// <param name="formName">Имя формы</param>
        /// <param name="comment">Произвольный комментарий к параметру</param>
        /// <returns>Если запись успешная, то true</returns>
        public static bool Save(DirectionQuery direction, 
                                     string userID, 
                                     string paramName, 
                                     bool checkGlobal, 
                                     string param,                                    
                                     string paramType, 
                                     string formName, 
                                     string comment)
        {
        	var listParams = new string[1];
        	listParams[0] = param;
        	return Save(direction, userID,  paramName, checkGlobal, listParams, paramType, formName, comment);
        }
        
        /// <summary>
        /// Запись значения настройки в таблицу настроек fbaParam.
        /// Настройки может быть глобальной (для всех пользователей одна с именем ParamName) и индивидуальная.
        /// Если индивидуальная, то имя ParamName повторяется для разных пользователей.
        /// Если в настройке сохраняются значения компронентов формы, то FormID указывать нужно, в противном случае FormID = ""
        /// </summary>
        /// <param name="direction">Запрос к локальной или удаленнённой базе данных.</param>
        /// <param name="userID">ИД пользователя</param>
        /// <param name="paramName">Имя параметра</param>
        /// <param name="checkGlobal">Глобальный или локальный параметр</param>
        /// <param name="listParams">Массив параметров</param>
        /// <param name="paramType"></param>
        /// <param name="formName">Имя формы</param>
        /// <param name="comment">Произвольный комментарий к параметру</param>
        /// <returns>Если запись успешная, то true</returns>
        public static bool Save(DirectionQuery direction, 
                                     string userID, 
                                     string paramName, 
                                     bool checkGlobal, 
                                     string[] listParams,                                    
                                     string paramType, 
                                     string formName, 
                                     string comment)
        {                                                                                         
            string globalSQL = "";
            string globalStr = "";

            if (listParams.Length > 10)
            {
                sys.SM("Ошибка записи параметра. Количество одновременно записываемых параметров не может быть больше 10!");
                return false;
            }

            var paramValue = new string[10];

            for (int i = 0; i < paramValue.Length; i++) paramValue[i] = "NULL";
            for (int i = 0; i < listParams.Length; i++) paramValue[i] = listParams[i];          

            if (checkGlobal) 
            {
                globalSQL = " AND Global = 1";
                globalStr = "1";
            } else
            {
               globalSQL = " AND Global = 0 AND UserID = " + userID;
               globalStr = "0";
            }
            string sql = "SELECT ID FROM fbaParam WHERE Name = '" + paramName + "' AND Type = '" + paramType + "'" + globalSQL;
            string setName = sys.GetValue(direction, sql);              
            string getFormID = "";
            if (formName == "") getFormID = "NULL";
              else getFormID = " (SELECT ID FROM fbaProject WHERE Name = '" + formName + "')";
            
            if (setName == "")
            {
                sql = "INSERT INTO fbaParam (EntityID, Name, FormID, Global, Type, " +
                      "Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9, Value10," +
                      "Comment, DateCreate, UserID) VALUES (" +
                "9000," +                               
                "'" + paramName + "'," +              
                getFormID         + ","  +                                        
                globalStr         + ","  +               
                "'" + paramType + "'," +                    
                "'" + paramValue[0].QueryQuote() + "'," +
                "'" + paramValue[1].QueryQuote() + "'," +
                "'" + paramValue[2].QueryQuote() + "'," +
                "'" + paramValue[3].QueryQuote() + "'," +
                "'" + paramValue[4].QueryQuote() + "'," +
                "'" + paramValue[5].QueryQuote() + "'," +
                "'" + paramValue[6].QueryQuote() + "'," +
                "'" + paramValue[7].QueryQuote() + "'," +
                "'" + paramValue[8].QueryQuote() + "'," +
                "'" + paramValue[9].QueryQuote() + "'," +      
                "'" + comment + "'," +
                sys.DateTimeCurrent() + "," + 
                userID + ")";
            } else
            {
                sql = "UPDATE fbaParam SET " + 
                      "Name        = '" + paramName  + "'," + 
                      "FormID      = "  + getFormID    + "," +                  
                      "Global      = "  + globalStr    + "," +                 
                      "Type        = '" + paramType  + "'," +
                      "DateChange  = "  + sys.DateTimeCurrent() + "," +                     
                      "Value1      = '" + paramValue[0].QueryQuote() + "'," +
                      "Value2      = '" + paramValue[1].QueryQuote() + "'," +
                      "Value3      = '" + paramValue[2].QueryQuote() + "'," +
                      "Value4      = '" + paramValue[3].QueryQuote() + "'," +
                      "Value5      = '" + paramValue[4].QueryQuote() + "'," +
                      "Value6      = '" + paramValue[5].QueryQuote() + "'," +
                      "Value7      = '" + paramValue[6].QueryQuote() + "'," +
                      "Value8      = '" + paramValue[7].QueryQuote() + "'," +
                      "Value9      = '" + paramValue[8].QueryQuote() + "'," +
                      "Value10     = '" + paramValue[9].QueryQuote() + "'," +                     
                      "Comment     = '" + comment + "'" +
                      " WHERE Name = '" + paramName + "' AND Type = '" + paramType + "'" + globalSQL;
            }                 
            return sys.Exec(direction, sql);                            
        }
              
        /// <summary>
        /// Чтение значения настройки из таблицы настроек fbaParam.
        /// </summary>
        /// <param name="direction">Запрос к локальной или удаленнённой базе данных.</param>
        /// <param name="userID">>ИД пользователя</param>
        /// <param name="paramName">Имя параметра</param>
        /// <param name="checkGlobal">Глобальный или локальный параметр</param>
        /// <param name="paramType">Тип параметра</param>
        /// <param name="listParams">Массив параметров</param>
        /// <returns>Если загрузка успешная, то true</returns>                          
        public static bool Load(DirectionQuery direction, 
                                     string userID, 
                                     string paramName, 
                                     bool checkGlobal, 
                                     string paramType, 
                                     out string[] listParams)
        {

            string globalSQL = "";                                
            if (direction == DirectionQuery.Remote)
            {
                if (checkGlobal)  globalSQL = " AND Global = 1";
                else globalSQL = " AND Global = 0 AND UserID = " + userID;                
            }           
            string sql = "SELECT Value1, Value2, Value3, Value4, Value5, Value6 ,Value7, Value8, Value9 ,Value10 " +
                         "FROM fbaParam WHERE Name = '" + paramName + "' AND Type = '" + paramType + "'" + globalSQL;                                
            System.Data.DataTable DT;
            listParams = new string[10];
            if (!sys.SelectDT(direction, sql, out DT)) return false;
            for (int i = 0; i < 10; i++) listParams[i] = DT.Value(0, i);           
            return true;
        }      
        
        
        /// <summary>
        /// Чтение значения настройки из таблицы настроек fbaParam.
        /// </summary>
        /// <param name="direction">Запрос к локальной или удаленнённой базе данных.</param>
        /// <param name="userID">>ИД пользователя</param>
        /// <param name="paramName">Имя параметра</param>
        /// <param name="checkGlobal">Глобальный или локальный параметр</param>
        /// <param name="paramType">Тип параметра</param>
        /// <param name="param">Массив параметров</param>
        /// <returns>Если загрузка успешная, то true</returns>                          
        public static bool Load(DirectionQuery direction, 
                                     string userID, 
                                     string paramName, 
                                     bool checkGlobal, 
                                     string paramType, 
                                     out string param)
        {
        	string[] listParams;
        	bool result = Load(direction, userID, paramName, checkGlobal, paramType, out listParams);
        	param = listParams[0];
        	return result;
        }
        	
        #endregion Region. Параметры приложения.
        
        #region Region. Чтение и запись значений копонентов формы или другого компонента-контейнера (Panel, TabControl...)                   
                   
        /// <summary>
        /// Получаем значения компонентов формы (или другого компонента-контейнера Panel, TabControl) в виде строки.
        /// </summary>
        /// <param name="controls">Масив компонентов формы</param>
        /// <returns>Если успешно, то true</returns>
        public static string GetComponentValues(Control.ControlCollection controls)
        {                             
            if (controls.Count == 0) return ""; 
            string  settingText = "";
            foreach(Control control in controls)
            {                      
                settingText = settingText + GetComponentValues(control.Controls);                            
                if (control.Tag != null)
                {                                                       
                    //Пример формата строки в Tag: SAVE                       
                    string compType = control.GetType().ToString();
                    compType = sys.TruncateType(compType, false);                   
                    string setting = control.Tag.ToString().ToUpper();
                    if (setting.IndexOfEx("SAVE") > -1) setting = "SAVE";
                    bool saveParam = false;  
                    if (compType      == "TextBoxFBA")     saveParam = ((TextBoxFBA)control).SaveParam;
                    else if (compType == "ComboBoxFBA")    saveParam = ((ComboBoxFBA)control).SaveParam;
                    else if (compType == "CheckBoxFBA")    saveParam = ((CheckBoxFBA)control).SaveParam;
                    else if (compType == "RadioButtonFBA") saveParam = ((RadioButtonFBA)control).SaveParam;
                    else if (compType == "TabControlFBA")  saveParam = ((RadioButtonFBA)control).SaveParam;                                        
                    if (saveParam) setting = "SAVE";
                                                      
                    if (setting == "SAVE") 
                    {                                  
                        string settingStr = "";
                                                
                        if ((compType == "TextBox") || (compType == "TextBoxFBA"))
                        {
                             settingStr = control.Name + ":" + control.Text.StringToBase64() + Var.CR;
                        } else
                        if ((compType == "CheckBox") || (compType == "CheckBoxFBA"))
                        {
                            settingStr = control.Name + ":" + ((System.Windows.Forms.CheckBox)control).Checked + Var.CR;
                        } else
                        if ((compType == "ComboBox") || (compType == "ComboBoxFBA"))
                        {
                             settingStr = control.Name + ":" + control.Text.StringToBase64() + Var.CR;
                        } else
                        if ((compType == "RadioButton") || (compType == "RadioButtonFBA"))
                        {
                             settingStr = control.Name + ":" + ((System.Windows.Forms.RadioButton)control).Checked + Var.CR;
                        } else    
                        if ((compType == "TabControl") || (compType == "TabControlFBA")) 
                        {
                             settingStr = control.Name + ":" + ((System.Windows.Forms.TabControl)control).SelectedIndex + Var.CR;
                        } else
                        settingStr = control.Name + ":" + control.Text.StringToBase64() + Var.CR;
                        
                        settingText += settingStr;
                    }
                }               
            }
            return settingText;            
        }
        
        /// <summary>
        /// Присваивааем значения компонентам формы (или другого компонента-контейнера Panel, TabControl).
        /// </summary>
        /// <param name="componentValues">Компоненты формы и их значения в виде строки. Так как они записываются в базу данных.</param>
        /// <param name="controls">Масив компонентов формы</param>
        /// <returns></returns>
        public static bool SetComponentValues(string componentValues, Control.ControlCollection controls)
        {
            if (componentValues == "") return false;
            string[] dotArray = componentValues.Split('\n');
            for (int i = 0; i < dotArray.Count(); i++)
            {
                string s = dotArray[i].Trim();
                int n = s.IndexOf(':');
                if (n == -1) continue;
                string controlName  = s.Substring(0, n);               
                string controlValue = s.Substring(n + 1);  
                Control control = controls.Find(controlName, true).FirstOrDefault();
                if (control != null) 
                {
                    string compType = control.GetType().ToString();
                    compType = compType.Replace("System.Windows.Forms.", "");
                    compType = compType.Replace("FBA.", "");
                    compType = compType.Replace("FBA", "");
                        
                    if (compType == "TextBox")
                    {
                        control.Text = controlValue.Base64ToString();
                    } else
                    if (compType == "CheckBox")
                    {
                        ((System.Windows.Forms.CheckBox)control).Checked = controlValue.ToBool();                    
                    } else
                    if (compType == "ComboBox")
                    {
                        control.Text = controlValue.Base64ToString();
                    } else
                    if (compType == "RadioButton")
                    {
                         ((System.Windows.Forms.CheckBox)control).Checked = controlValue.ToBool(); 
                    } else
                    if (compType == "TabControl")
                    {
                        ((System.Windows.Forms.TabControl)control).SelectedIndex = controlValue.ToInt();
                    } else
                   control.Text = controlValue.Base64ToString(); //При этом присвоении вызовется ControlValueChanged автоматически.                                                      
                }
            }   
            return true;
        }                                           
          
        #endregion Region. Чтение и запись значений копонентов формы или другого компонента-контейнера (Panel, TabControl...)           
    }
}

        