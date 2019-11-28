
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 15.09.2017
 * Время: 16:08
 */  
 
using System.Linq;        
using System.Windows.Forms.VisualStyles;
using FastColoredTextBoxNS;       
using System.Windows.Forms;
using System.IO;
using System.Data;     
using System.Collections.Generic; 
using System.Reflection;
using System;
using System.Text;
using System.Drawing;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Net;
using System.Diagnostics;

namespace FBA
{         
	/// <summary>
    /// Форма для работы с формами решения. Собраны Различные функции по управлению формами.
    /// </summary>
    public partial class ProjectService : FormFBA
    {                       
    	/// <summary>
    	/// Форма для управления проектами
    	/// Для загрузки проектов на сервер, на тестовую версию и копирование между тесом и рабочей версией.
    	/// </summary>
    	/// <param name="projectName">Имя проекта</param>
    	public ProjectService(string projectName)
        {              
            InitializeComponent();                 
            tbProjectName.Text = projectName;
            this.MdiParent = Var.FormMainObj;
            RefreshProjectList();
        }  
	
        #region Region. Сохранение формы и проекта.
        
        /// <summary>
        /// Запись формы в БД в кодировке Base64. Всегда записываем как Test, поэтому параметра EnterMode здесь нет.
        /// Записываем перед записью файла в базу HashMD5 в конец файла, 
        /// для того чтобы после сравнивать два файла с одинаковыми именами.    
        /// </summary>
        /// <param name="fileName">Имя файла проекта EXE или DLL</param>
        /// <param name="projectID">ИД проекта в БД</param>
        /// <param name="newProject">Если проект новый и в БД не был ранее записан, то true</param>
        /// <returns>Если запись успешная, то true</returns>
        private static bool ProjectSaveDLL(string fileName, ref string projectID, out bool newProject)
        {              
            string projectName = Path.GetFileNameWithoutExtension(fileName);
            string sql = "";
            newProject = false;
            
            //Получить файл в виде Base64. Если SaveHashToEndFile, то в конец файла будет добавлен MD5 файла (32 байта).
            const bool saveHashToEndFile = true;
            string fileData;
            string hashMD5;
            if (!FBAFile.FileGetBase64WithHashMD5(fileName, saveHashToEndFile, out fileData, out hashMD5)) return false;

            bool needUpdate = false;
            if (sys.IsEmptyID(projectID))            
            {
                ProjectExists(projectName, false, out projectID);
                if (projectID != "") needUpdate = true;
            }
            else needUpdate = true;
            newProject = !needUpdate;         
            if (needUpdate)
            {
                sql = "UPDATE fbaProject SET ProjectDLLTest = '" + fileData + "', HashTest = '" + hashMD5 + "' WHERE id = " + projectID + "; ";
                if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            }
            else
            {
                sql = "INSERT INTO fbaProject (ProjectDLLTest, HashTest) VALUES('" + fileData + "', '" + hashMD5 + "') ";
                string newProjectID;
                if (!sys.Exec(DirectionQuery.Remote, true, sql, out newProjectID)) return false;
            	projectID = newProjectID;
            }                                                               
            return true;
        }                                     
                  
        /// <summary>
        /// Копируем проект в БД.
        /// Архивируется папка проекта в ZIP и записывается в БД в виде Base64.
        /// </summary>
        /// <param name="projectName">Имя проекта - это имя папки с проектом, но без пути</param>
        /// <returns>Если успешно, то true</returns>
        public static bool ProjectWriteToDataBase(string projectName)
        {                   
        	//Установка соединения с локальной базой SQLIte. Без неё не работаем.
            sys.ConnectLocal();
            sys.ConnectRemote();
    
            string fileNameEXE;
            string fileNameDLL;
            bool findEXE;
            bool findDLL;
            if (!FBAFile.GetPathProject(projectName, out fileNameEXE, out fileNameDLL, out findEXE, out findDLL))
            {
                sys.SM("Не найден файл проекта " + projectName);
                return false;
            }

            string fileSourceName = "";
            string fileName = "";

            if (findDLL)
            {
                fileSourceName = fileNameDLL;
                fileName = FBAPath.PathTemp + projectName + ".dll";
            }
            if (findEXE)
            {
                fileSourceName = fileNameEXE;
                fileName = FBAPath.PathTemp + projectName + ".exe";
            }

            string projectType = "App";
            if (projectName.IndexOf("DLL", StringComparison.Ordinal) > -1) projectType = "DLL";
            if (projectName.IndexOf("Main", StringComparison.Ordinal) > -1) projectType = "Main";

            //Копирование файла так как нужно записать в конец файла MD5, а вызов сохранения делал сам файл EXE, 
            //и сам файл себя изменить не может. Поэтому копируем в темповую папку Temp и далее работаем с копией. 
            string errorMes;
            if (!FBAFile.FileCopy(fileSourceName, fileName, FileOverwrite.Overwrite, Var.ShowMes, out errorMes)) return false;
                                                
            bool newProject; // = false;
            string projectID = "";
            //ProjectExists(projectName, false, out projectID);
            //newForm |= (projectID == ""); //if (FormID == "") NewForm = true; 

            if (!ProjectSaveDLL(fileName, ref projectID, out newProject)) return false;
            if (!ProjectdSaveZIP(projectName)) return false;
                        
            string sql = "UPDATE fbaProject SET " +
                  "  Name             = '" + projectName + "'" +
            	  ", EntityID         = " + sys.GetEntityID("Project") +
                  ", DateChangeTest   = " + sys.DateTimeCurrent() + " " +
                  ", UserChangeTestID = " + Var.UserID  +
                  ", Type             = '" + projectType + "'" +           
                  " WHERE ID = " + projectID + "; \r\n";

            if (newProject)
            {
                sql += "UPDATE fbaProject SET DateCreateTest = " + sys.DateTimeCurrent() +
                       ", UserCreateTestID = " + Var.UserID  +
                       ", Type             = '" + projectType + "'" +
                       " WHERE ID = " + projectID + "; \r\n";
            }
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            return true;
        }
          

        /// <summary>
        /// Копируем проект в БД.
        /// Архивируется папка проекта в ZIP и записывается в БД в виде Base64.
        /// </summary>
        /// <param name="projectName">Имя проекта - это имя папки с проектом, но без пути</param>
        /// <returns>Если успешно, то true</returns>
        public static bool ProjectdSaveZIP(string projectName)
        {
            //Проект архивируется в файл ZIP. Далее файл ZIP записывается в БД в виде Base64.
            string projectPath = FBAPath.PathForms + projectName;
            string fileName = FBAPath.PathTemp + projectName + ".zip";
            if (!FBAFile.DirZIP(true, projectPath, fileName)) return false;
            const bool saveHashToEndFile = false;
            string fileData;
            string hashMD5;
            if (!FBAFile.FileGetBase64WithHashMD5(fileName, saveHashToEndFile, out fileData, out hashMD5)) return false;
            string sql = "UPDATE fbaProject SET ProjectZip = '" + fileData + "' WHERE Name = '" + projectName + "'";
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            return true;
        } 
                
		/// <summary>
		/// Чтение формы из БД из кодировки Base64. 
		/// Ситуация: Есть на диске EXE, Есть DLL, то DLL удаляем, а EXE перпеименовываем в DLL. 
        /// Ситуация: Есть на диске EXE, Нет  DLL, то переименовываем EXE в DLL.
        /// Cитуация: Нет  на диске EXE, Есть DLL, то ничего не делаем.           
        /// Ситуация: Нет  на диске EXE, Нет  DLL, то скачиваем проект из базы.      		
        /// Ситуация: Если принудительная загрузка (ForceLoad - true), то загружаем из БД, не обращая внимание ни на MD5, ни на наличие файла.  
        /// Ситуация: Если файл на диске есть, и его MD5 совпадает с тем, что в БД, то не загружаем.
        /// Ситуация: Если в режиме разработки (EnterMode == "Develop"), то если файл есть, то не проверяем версию и из БД не загружаем.
		/// </summary>
		/// <param name="projectName">Имя проекта</param>
		/// <param name="enterMode">Тип входа: Work, Test, Develop</param>
		/// <param name="forceLoad">Если принудительная загрузка (ForceLoad - true), то загружаем из БД, не обращая внимание ни на MD5, ни на наличие файла</param>
		/// <param name="fileName">Имя файла EXE или DLL проекта</param>
		/// <returns>Если успешно, то true</returns>
        public static bool ProjectGetFileName(string projectName, EnterMode enterMode, bool forceLoad, out string fileName)
        {                                
            fileName = "";
 			string fileNameEXE;
            string fileNameDLL; 
            if (forceLoad) enterMode = EnterMode.Work;
			string erroMes = "Ошибка загрузки проекта из базы данных!";            		
            if (enterMode == EnterMode.Develop) 
            {
            	fileNameDLL = FBAPath.PathApp + projectName + ".DLL";
            	fileNameEXE = FBAPath.PathApp + projectName + ".EXE";
            	if (File.Exists(fileNameDLL)) fileName = fileNameDLL;
            	if (File.Exists(fileNameEXE)) fileName = fileNameEXE;
            	if (fileName == "")
            	{
            		erroMes = "Не найден проект на диске: " + projectName;
            		sys.SM(erroMes); 
            		return false; 
            	}
            	return true;
            }
			
            ProjectType projectType;
            string hashMD5;
            bool projectDel;
            if (!CheckProjectExistInDataBase(projectName, enterMode, out projectType, out hashMD5, out projectDel)) return false;

                                   
            if (hashMD5 == "")
            {            	
            	if (enterMode == EnterMode.Work)    erroMes = "Не найден проект в рабочей базе данных: " + projectName;
            	if (enterMode == EnterMode.Test)    erroMes = "Не найден проект в тестовой базе данных: " + projectName;
                sys.SM(erroMes); 
                return false;               
            }
            if (projectDel)
            {            	
            	sys.SM("Проект найден, но недоступен для отображения, так как был помечен на удаление: " + projectName);
                return false;
            }
			bool needLoad = false;
           
            bool findEXE;
            bool findDLL;           
            FBAFile.GetPathProject(projectName, out fileNameEXE, out fileNameDLL, out findEXE, out findDLL);
            
            //1. Ситуация: Есть EXE, Есть DLL, то DLL удаляем, а EXE перпеименовываем в DLL. 
            //2. Ситуация: Есть EXE, Нет  DLL, то переименовываем EXE в DLL.
            //3. Ситуация: Нет  EXE, Есть DLL, то ничего не делаем.           
            //4. Ситуация: Нет  EXE, Нет  DLL, то скачиваем проект из базы.

            if (File.Exists(fileNameEXE))
            {
                const bool showMesIN = true;
                string errorMes;
                if (!FBAFile.FileRename(fileNameEXE, fileNameDLL, FileOverwrite.Overwrite, showMesIN, out errorMes))
                {
                    sys.SM("Ошибка загрузки модуля " + projectName);
                    return false;
                }
            }
             
            //1. Ситуация: Если файла нет, то загружаем.
            //2. Ситуация: Если принудительная загрузка (ForceLoad - true), то загружаем из БД, не обращая внимание ни на MD5, ни на наличие файла.  
            //3. Ситуация: Если файл на диске есть, и его MD5 совпадает с тем, что в БД, то не загружаем.
            //4. Ситуация: Если в режиме разработки (EnterMode == "Dev"), то если файл есть, то не проверяем версию и из БД не загружаем.
            if (File.Exists(fileNameDLL))
            {
                if (enterMode != EnterMode.Develop)
                {
                    string hashmd5BD = Crypto.FileHashMD5Read(fileNameDLL); //Пример HashMD5: 9924E53BC7DC4584954601F15023F40C
                    needLoad = (hashmd5BD != hashMD5);
                }
            }
            else needLoad = true;

            needLoad |= (forceLoad); //if (ForceLoad) NeedLoad = true;  

            if (needLoad)
            {
                //Чтение проекта из БД из кодировки Base64.                          
                string fieldName = "";
                if (enterMode == EnterMode.Work) fieldName = "ProjectDLL";
                else fieldName = "ProjectDLLTest";

                string SQL = "SELECT " + fieldName + " FROM fbaProject WHERE Name = '" + projectName + "' ; ";
                string FileData = sys.GetValue(DirectionQuery.Remote, SQL);

                //Записываем форму на диск. Форма в виде текста в FileData в Base64.          
                const bool showMes = true;
                string errorMes;
                if (!FBAFile.FileWriteFromBase64(FileData, fileNameDLL, out errorMes, showMes)) return false;
            }

            if (!File.Exists(fileNameDLL))
            {
                sys.SM("Ошибка загрузки проекта: " + fileNameDLL);
                return false;
            }
            fileName = fileNameDLL;
            return true;
        }

        /// <summary>
        /// Восстановить проект из БД. Файл читается из БД, далее преобразуется в нормальный вид из Base64 и записывается на диск.
        /// Далее папка с проектом удаляется и восстапнавливается из архива zip.        
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        /// <param name="projectNameNew">Новое имя проекта, под которым его восстановить. Это нужно иногда, чтобы сделать копию проекта</param>
        /// <param name="projectHistID">ИД записи в истории сохранения проектов, чтобы восстановить из истории</param>
        /// <param name="restoreFromHist">Если true то восстанавливаем из истории</param>
        /// <returns>Если успешно, то true</returns>
        public static bool ProjectReadFromDataBase(string projectName,
                                                   string projectNameNew,
                                                   string projectHistID,
                                                   bool restoreFromHist)
        {
            string sql = "";
            if (restoreFromHist)
            {
                sql = "SELECT ProjectZip FROM fbaProjectHist WHERE Name = '" + projectName + "' AND ID = " + projectHistID;
            }
            else
            {
                sql = "SELECT ProjectZip FROM fbaProject WHERE Name = '" + projectName + "'";
            }
            string pathProject = FBAPath.PathForms + projectNameNew;
            string fileData = sys.GetValue(DirectionQuery.Remote, sql);
            if (fileData == "")
            {
                sys.SM("Не найден проект в таблице истории!");
                return false;
            }
            string fileName = FBAPath.PathTemp + projectName + ".zip";
            string errorMes;
            if (!FBAFile.FileWriteFromBase64(fileData, fileName, out errorMes, true)) return false;
            if (!FBAFile.DirDelete(pathProject, out errorMes, true)) return false;
            if (!FBAFile.DirZIP(false, fileName, pathProject)) return false;
            return true;
        }

        #endregion Region. Region. Сохранение формы и проекта.                                                                        

        #region Region. Загрузка модулей.

        /// <summary>
        /// Загрузка DLL прикладного приложения (подсистемы).
        /// </summary>
        /// <param name="projectName">Имя проекта. Это имя файла DLL или EXE</param>
        /// <param name="enterMode">Word, Test, Develop</param>
        /// <returns></returns>
        public static Assembly ProjectLoad(string projectName, EnterMode enterMode) 
        {
            if (!sys.IsUserProjectGrant(projectName)) return null;
            //Возможно сборка уже загружена. Если даже модуль изменился, 
            //мы все равно работаем в одном домене, поэтому замениь уже загруженную DLL нет возможности.
            //Она подменится при пере-открытии Клиента в следующий раз.
            if (projectName == "") return null;
            Assembly assembly;
            if (FindAssembly(projectName, out assembly)) return assembly;
            string fileName;
                                             
            if (!ProjectService.ProjectGetFileName(projectName, enterMode, false, out fileName)) return null;
           
            
            //Если нет, то загружаем.
            if (fileName == "") return null;
            try
            {
                assembly = Assembly.LoadFile(fileName);
            }
            catch (Exception ex)
            {
                sys.SM("Ошибка загрузки сборки " + fileName + " " + ex.Message);
                return null;
            }
            return assembly;
        }
   
        /// <summary>
        /// Проверка наличия модуля в БД. Возвращаем параметры модуля ProjectType, GUIDBD, TextQuery.
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        /// <param name="enterMode">Тип входа: Work, Test, Develop</param>
        /// <param name="projectType">Тип проекта: Main, App, Dll</param>
        /// <param name="hashMD5">MD5</param>
        /// <param name="projectDel">Признак, что проект помечен на удаление</param>
        /// <returns>Если проект найден, то true</returns>
        public static bool CheckProjectExistInDataBase(string projectName, EnterMode enterMode, out ProjectType projectType, out string hashMD5, out bool projectDel)
        {                                        
            projectType = ProjectType.NotAssigned;
            hashMD5 = "";
            projectDel = false;   
            if (projectName == "") return false;
            string sql = "";                   
            if (enterMode == EnterMode.Test)
            	sql = "SELECT Type, HashTest, " + sys.GetISNULL(Var.con.serverTypeRemote) + "(DEL, 0) AS DEL FROM fbaProject WHERE Name = '" + projectName + "'";
            else sql = "SELECT Type, Hash, " + sys.GetISNULL(Var.con.serverTypeRemote) + "(DEL, 0) AS DEL FROM fbaProject WHERE Name = '" + projectName + "'";            
            string del;
            string type;
            bool result = sys.GetValue(DirectionQuery.Remote, sql, out type, out hashMD5, out del);
            if (type == "Main") projectType = ProjectType.Main;
            if (type == "Dll")  projectType = ProjectType.Dll;
            if (type == "App")  projectType = ProjectType.App;
            projectDel = del.ToBool();
            return result;
        }
        
        /// <summary>
        /// Поиск загруженной сборки.
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        /// <param name="asm">Сборка</param>
        /// <returns>Если сборка уже подключена к проекту, то true</returns>
        public static bool FindAssembly(string projectName, out Assembly asm)
        {
            asm = null;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.GetName().Name == projectName)
                {
                    asm = assembly;
                    return true;
                }
            }
            return false;
        }

		/// <summary>
		/// Поиск формы по названию и по номеру. Номер указать можно 0, в этом случае номер при поиске не учытывается.   
		/// </summary>
		/// <param name="formName">Имя формы</param>
		/// <param name="formNumber">Порядковый номер формы</param>
		/// <param name="obj">Форма</param>
		/// <returns></returns>
        public static bool FindForm(string formName, ref int formNumber, out Object obj)
        {
            obj = null;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != formName) continue;

                int FormNumberLocal = ((FormFBA)form).FormNumber;
                if ((formNumber > 0) && (FormNumberLocal != formNumber)) continue;
                formNumber = FormNumberLocal;
                obj = form;
                return true;
            }
            return false;
        }

        #endregion Region. Загрузка модулей.
          
        #region Region. Способ подгрузки формы через рефлексию.  

        //public static T CreateInstance1<T>(params object[] paramArray)
        //{
        //    return (T)Activator.CreateInstance(typeof(T), args: paramArray);
        //}      
        
        /// <summary>
        /// Загрузка формы прикладного приложения (подсистемы). Tag экземпляр объекта формы. Нумерация с 1.   
        /// </summary>
        /// <param name="projectName">Имя проекта, а котором находится форма</param>
        /// <param name="formName">Имя формы</param>
        /// <param name="formAction">Действие с формой</param>
        /// <param name="formNumber">Порядковый номер формы, если их несколько одинаковых</param>
        /// <param name="paramArray">Параметры контруктора формы</param>
        /// <returns>Объект Form</returns>
        public static Form FormLoad(string projectName, string formName, FormAction formAction, out int formNumber, params object[] paramArray)
        {
            formNumber = 0;
            
            Assembly assembly = ProjectLoad(projectName, Var.enterMode);
            if (assembly == null) return null;
            Object form = null;

            //Object obj;        
            //if (FindForm(FormName, ref FormNumber, out obj)) return obj;
            //Type type = assembly.GetType("FBA." + FormName);
            //var Form1 = (FormCustom)Activator.CreateInstance(type);

            //ConstructorParams
            //form = assembly.CreateInstance("FBA." + FormName, "");
            //form = assembly.CreateInstance("FBA." + FormName, args: paramArray);
            string objectName = "FBA." + formName;
            Type type = assembly.GetType(objectName); 
            if (type == null) 
            {
            	sys.SM("Ошибка создания объекта: " + objectName + Var.CR + "Сборка не найдена.");
            	return null;
            }
            form = Activator.CreateInstance(type, args: paramArray);

            if (form == null) return null;

            //Увеличиваем FormNumber на 1. Это создание следующего объекта формы.
            //ModuleList.Add(new FormApp(FormName, assembly, form, FormNumber + 1));
            int formNumberPrev = 0;
            Object objPrev;
            FindForm(formName, ref formNumberPrev, out objPrev);
            if (form.GetType().GetProperty("FormNumber") != null)
                ((FormFBA)form).FormNumber = formNumberPrev + 1; // FormNumber + 1;

            //Установка Parent-Child для MDI форм.
            string formParent = "";
            if (form.GetType().GetProperty("FormNumber") != null)
                formParent = ((FormFBA)form).FormMDIParent;

            if (!string.IsNullOrEmpty(formParent))
            {
                int formNumberParent = 0;
                Object objParent;
                FindForm(formParent, ref formNumberParent, out objParent);
                if (objParent != null)
                    ((Form)form).MdiParent = (Form)objParent;
            }

            if (formAction == FormAction.None)
            {
                return (Form)form;
            }
            if (formAction == FormAction.Show)
            {
                ((Form)form).Show();
                return (Form)form;
            }
            if (formAction == FormAction.ShowDialog)
            {
                ((Form)form).ShowDialog();
                return (Form)form;
            }
            return null;
        }
  
		/// <summary>
		/// Получить форму. Только объект Form. Показ формы не происходит. 
		/// </summary>
		/// <param name="projectName">Имя проекта, а котором находится форма</param>
		/// <param name="formName">Имя формы</param>
		/// <param name="formNumber">Порядковый номер формы, если их несколько одинаковых</param>
		/// <param name="paramArray">Параметры контруктора формы</param>
		/// <returns>Объект Form</returns>
        public static Form FormGet(string projectName, string formName, out int formNumber, object[] paramArray)
        {
            return FormLoad(projectName, formName, FormAction.None, out formNumber, paramArray);
        }
       
        /// <summary>
        /// Запуск формы прикладного приложения (подсистемы).
        /// </summary>
        /// <param name="projectName">Имя проекта, а котором находится форма</param>
        /// <param name="formName">Имя формы</param>
        /// <param name="formNumber">Порядковый номер формы, если их несколько одинаковых</param>
        /// <param name="paramArray">Параметры контруктора формы</param>
        /// <returns>Объект Form</returns>
        public static Form FormShow(string projectName, string formName, out int formNumber, object[] paramArray)
        {
            return FormLoad(projectName, formName, FormAction.Show, out formNumber, paramArray);
        }
        
        /// <summary>
        /// Запуск формы прикладного приложения (подсистемы).
        /// </summary>
        /// <param name="projectName">Имя проекта, а котором находится форма</param>
        /// <param name="formName">Имя формы</param>
        /// <param name="formNumber">Порядковый номер формы, если их несколько одинаковых</param>
        /// <param name="paramArray">Параметры контруктора формы</param>
        /// <returns>Объект Form</returns>
        public static Form FormDialog(string projectName, string formName, out int formNumber, object[] paramArray)
        {
            return FormLoad(projectName, formName, FormAction.ShowDialog, out formNumber, paramArray);
        }
        
        #endregion Region. Способ подгрузки формы через рефлексию.

        #region Region. Способ подгрузки формы через Dynamic.
              
        /// <summary>
        /// Запуск формы прикладного приложения (подсистемы).
        /// </summary>
        /// <param name="projectName">Имя проекта, а котором находится форма</param>
        /// <param name="formName">Имя формы</param>
        /// <param name="formAction">Действие с формой</param>
        /// <param name="formNumber">Порядковый номер формы, если их несколько одинаковых</param>
        /// <param name="paramArray">Параметры контруктора формы</param>
        /// <returns>Объект Form</returns>
        public static dynamic FormLoadDynamic(string projectName, string formName, FormAction formAction, out int formNumber, object[] paramArray)
        {
            formNumber = 0;
            Assembly assembly = ProjectLoad(projectName, Var.enterMode);
            if (assembly == null) return null;
            dynamic form = null;

            //form = assembly.CreateInstance("FBA." + FormName);
            Type type = assembly.GetType("FBA." + formName);
            form = Activator.CreateInstance(type, args: paramArray);

            if (form == null) return null;

            //Увеличиваем FormNumber на 1. Это создание следующего объекта формы.
            //ModuleList.Add(new FormApp(FormName, assembly, form, FormNumber + 1));
            Object objPrev;
            int formNumberPrev = 0;
            FindForm(formName, ref formNumberPrev, out objPrev);
            if (form.GetType().GetProperty("FormNumber") != null) form.FormNumber = formNumberPrev + 1; // FormNumber + 1;

            //Установка Parent-Child для MDI форм.
            string formParent = "";
            if (form.GetType().GetProperty("FormNumber") != null) formParent = form.FormMDIParent;

            if (!string.IsNullOrEmpty(formParent))
            {
                int formNumberParent = 0;
                Object objParent;
                FindForm(formParent, ref formNumberParent, out objParent);
                if (objParent != null)
                    form.MdiParent = (Form)objParent;
            }

            if (formAction == FormAction.None)
            {
                return form;
            }
            if (formAction == FormAction.Show)
            {
                form.Show();
                return form;
            }
            if (formAction == FormAction.ShowDialog)
            {
                form.ShowDialog();
                return form;
            }
            return null;
        }

		/// <summary>
		/// Получить форму. Форма не показывается. 
		/// </summary>
		/// <param name="projectName">Имя проекта с формой</param>
		/// <param name="formName">Имя формы</param>
		/// <param name="formNumber">Порядковый номер формы</param>
		/// <param name="paramArray">Массив параметров контсруктора формы</param>
		/// <returns></returns>
        public static dynamic FormGetDynamic(string projectName, string formName, out int formNumber, object[] paramArray)
        {
            return FormLoadDynamic(projectName, formName, FormAction.None, out formNumber, paramArray);
        }
         
        /// <summary>
        /// Показ формы прикладного приложения как не модальной.
        /// </summary>
        /// <param name="projectName">Имя проекта с формой</param>
        /// <param name="formName">Имя формы</param>
        /// <param name="formNumber">Порядковый номер формы</param>
        /// <param name="paramArray">Массив параметров контсруктора формы</param>
        /// <returns></returns>
        public static dynamic FormShowDynamic(string projectName, string formName, out int formNumber, object[] paramArray)
        {
            return FormLoadDynamic(projectName, formName, FormAction.Show, out formNumber, paramArray);
        }
        
        /// <summary>
        /// Показ формы прикладного приложения как модальной.
        /// </summary>
        /// <param name="projectName">Имя проекта с формой</param>
        /// <param name="formName">Имя формы</param>
        /// <param name="formNumber">Порядковый номер формы</param>
        /// <param name="paramArray">Массив параметров контсруктора формы</param>
        /// <returns></returns>
        public static dynamic FormDialogDynamic(string projectName, string formName, out int formNumber, object[] paramArray)
        {
            return FormLoadDynamic(projectName, formName, FormAction.ShowDialog, out formNumber, paramArray);
        }

        #endregion Region. Способ подгрузки формы через Dynamic.            
        
        /// <summary>
        /// Проверяем наличие пользовательского проекта в базе.
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        /// <param name="showMes">Показываьт сообщение об ошибках</param>
        /// <param name="projectID">ИД проекта в БД</param>
        /// <returns>Если проект найден, то true</returns>
        public static bool ProjectExists(string projectName, bool showMes, out string projectID)
        {
            projectID = "";
            if (projectName == "") return false;
            string sql = "SELECT ID FROM fbaProject WHERE Name = '" + projectName + "'; ";
            projectID = sys.GetValue(DirectionQuery.Remote, sql);
            if (projectID == "")
            {
                if (showMes) sys.SM("В базе данных не найден проект: " + projectName, MessageType.Error, "Поиск формы");
                return false;
            }
            return true;
        }
               
        /// <summary>
        /// Выясняем сколько открыто экземпляров формы с названием FormName.
        /// Поиск ведется в том числе среди свернутых и скрытых форм (Hide, Visible=false). 
        /// </summary>
        /// <param name="formName">Имя формы</param>
        /// <returns></returns>
        public static int FormGetNumber(string formName)
        {
            int formNumber = 1;
            foreach (KeyValuePair<string, FormFBA> kvp in Var.ListForm)
            {
                if (formName == kvp.Value.Name) formNumber++;
            }
            return formNumber;
        }
        
        /// <summary>
        /// Пометить проект на удаление.
        /// </summary>
        /// <param name="projectID">ИД проекта</param>
        /// <param name="deleted">Флаг true - проект удален</param>
        /// <returns>Если флаг уставновлен успешно, то true</returns>
        public bool ProjectSetDeleted(string projectID, bool deleted)
        {
            if (projectID == "") return false;
            string delStr = (deleted.ToInt()).ToString();
            string sql = "UPDATE fbaProject SET DEL = " + delStr + " WHERE ID = '" + projectID + "'";
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;             
            RefreshProjectList();
            return true;            
        }              
              
        /// <summary>
        /// Удаление формы из базы.
        /// </summary>
        /// <param name="projectID">ИД проекта</param>
        /// <param name="typeDel">Тип удаления: 1-DB; 2-Disk; 3-DB,Disk; 4-DB,Disk,History</param>
        /// <returns>Если форма успешно удалена, то true</returns>
        public bool ProjectDelete(string projectID, int typeDel)
        {                              
            if (projectID == "") return false;            
            string projectName = dgvProject.Value("Name");
             
            if ((typeDel == 1) || (typeDel == 3) || (typeDel == 4))
            {
            	string sql = "DELETE FROM fbaRelRoleProject WHERE ProjectID = " + projectID + ";" + Var.CR +                        
                             "DELETE FROM fbaProject WHERE ID = "  + projectID + ";";
            	 if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            }
            
            if ((typeDel == 2) || (typeDel == 3) || (typeDel == 4))
            {
	            string errorMes;
	            if (sys.SM("Удалить папку с проектом с диска?", MessageType.Question, "Удаление проекта"))
	            	FBAFile.DirDelete(FBAPath.PathForms + projectName, out errorMes, true);
            }
            
            if  (typeDel == 4)
            {
            	string sql = "DELETE FROM fbaProjectHist WHERE ProjectID = "  + projectID + ";" + Var.CR;
            	 if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            }
            
            RefreshProjectList(); 
            return true;             
        }              
              
        /// <summary>
        /// Удалить запись из истории проектов.
        /// </summary>
        /// <param name="projectHistID">ИД записи истории изменения проекта</param>
        /// <returns></returns>
        public bool ProjectHistDelete(string projectHistID)
        {
            if (projectHistID == "") return false;
            return sys.Exec(DirectionQuery.Remote, "DELETE FROM fbaProjectHist WHERE ProjectID = " + projectHistID);
        }                            
        
        /// <summary>
        /// Создание нового проекта
        /// </summary>
        public void ProjectNew()
        {                    
             var projectNew = new ProjectNew();
             projectNew.ShowDialog();               
             int projectStatus = projectNew.StatusClose;                         
             if (projectStatus == 2) return;                             
             string projectName = projectNew.projectName;
             string projectTemplate = projectNew.ProjectTemplate;                                                     
             string fromDir = FBAPath.PathTemplate + projectTemplate;
             string toDir   = FBAPath.PathForms + projectName;
             FBAFile.DirCopy(fromDir, toDir, true);
             string[] listNotDeleted;
             if (Directory.Exists(FBAPath.PathForms + projectName + @"\obj"))
                 FBAFile.DirClean(FBAPath.PathForms + projectName + @"\obj", out listNotDeleted, true);
             FBAFile.RenameFilesInDir(toDir, projectTemplate, projectName);                                    
             sys.SM("Проект создан, теперь его необходимо добавить её в среду разработки: " + Var.CR + toDir, MessageType.Information);                           
        }                                        
       
        /// <summary>
        /// Копирование формы из fbaProject или fbaProjectHist как нового модуля.
        /// </summary>
        /// <param name="projectID">ИД проекта</param>
        /// <param name="projectHistID">ИД истории изменения проета</param>
        /// <returns></returns>
        public bool CopyAsNew(string projectID, string projectHistID)
        {   
            if ((projectID == "") && (projectHistID == ""))
            {
                sys.SM("Не найдена форма для копирования!");
                return false; 
            }
            string projectName = "";
            bool restoreFromHist = false;  
            
            if (projectID != "") 
            {
                GetProjectName(projectID, out projectName);
                restoreFromHist = false;  
            }
            if (projectHistID != "") 
            {
                GetProjectHistName(projectHistID, out projectName);
                restoreFromHist = true;
            }
            if (projectName == "")
            {
                sys.SM("Не найден проект с именем: " + projectName);
                return false;
            }
            string projectNameNew = "";
            if (!sys.InputValue("Новое имя проекта", 
                                "Имя проекта:", 
                                SizeMode.Small,
                                ValueType.String,
                                ref projectNameNew)) return false;
            
            //Скачиваем проект из БД.                    
            if (!ProjectReadFromDataBase(projectName, projectNameNew, projectHistID, restoreFromHist)) return false;
            string[] listNotDeleted;
            FBAFile.DirClean(FBAPath.PathForms + projectNameNew + @"\obj", out listNotDeleted, true);
            FBAFile.RenameFilesInDir(FBAPath.PathForms + projectNameNew, projectName, projectNameNew);
            sys.SM("Прокт скопирован как новый с именем: " + projectNameNew + Var.CR + 
                   "Теперь его можно добавить в среду разработки!", MessageType.Information);
            return true;
        }
      
        /// <summary>
        /// Переименование формы.
        /// </summary>
        /// <param name="projectPath">Путь к папке проекта на диске</param>
        /// <returns></returns>
        public bool ProjectRename(string projectPath)
        {                          
            if (projectPath == "") return false;
            string projectNameOld = Path.GetFileNameWithoutExtension(projectPath);                 
            string projectNameNew = projectNameOld;         
            if (!sys.InputValue("Новое имя проекта", "Введите новое имя проекта", SizeMode.Small, ValueType.String, ref projectNameNew)) return false;                                   
            System.IO.Directory.Move(FBAPath.PathForms + projectNameOld, FBAPath.PathForms + projectNameNew);
            string[] listNotDeleted;
            FBAFile.DirClean(FBAPath.PathForms + projectNameNew + @"\obj", out listNotDeleted, true);
            FBAFile.RenameFilesInDir(FBAPath.PathForms + projectNameNew, projectNameOld, projectNameNew);
            sys.SM("Проект переименован: " + projectNameNew, MessageType.Information);                                  
            return true;
        }
              
        /// <summary>
        /// Установить тип проекта.
        /// </summary>
        /// <param name="projectID">ИД проекта в БД</param>
        /// <param name="projectType">Тип проекта</param>
        /// <returns>Если успешно, то true</returns>
        public bool ProjectSetType(string projectID, ProjectType projectType)
        {
            if (projectID == "") return false;
            string sql = "";
            sql = "UPDATE fbaProject SET Type = '" + projectType.ToString() + "' WHERE ID = " + projectID;
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            RefreshProjectList(); 
            return true;
        } 
                       
        /// <summary>
        /// Получить Имя формы по её ID.
        /// </summary>
        /// <param name="projectID">ИД проекта в БД</param>
        /// <param name="projectName">Имя проекта</param>
        /// <returns>Если проект найден, то true</returns>
        public bool GetProjectName(string projectID, out string projectName)
        {
            projectName = "";
            if (projectID == "") return false;
            string sql = "SELECT Name FROM fbaProject WHERE ID = " + projectID;
            projectName = sys.GetValue(DirectionQuery.Remote, sql);
            return (projectName != "");           
        }
                       
        /// <summary>
        /// Получить ID проекта по его имени.
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        /// <param name="projectID">ИД проекта</param>
        /// <returns>Если проект найден, то true</returns>
        public bool GetProjectID(string projectName, out string projectID)
        {
            projectID = "";
            if (projectName == "") return false;
            string sql = "SELECT ID FROM fbaProject WHERE Name = '" + projectName + "'";
            projectID = sys.GetValue(DirectionQuery.Remote, sql);
            return (projectID != "");           
        }
        
        /// <summary>
        /// Получить Имя проекта по его HistID.
        /// </summary>
        /// <param name="projectHistID">ИД истории изменения проектов</param>
        /// <param name="projectName">Имя проекта</param>
        /// <returns>Если проект найден, то true</returns>
        public bool GetProjectHistName(string projectHistID, out string projectName)
        {
            projectName = "";
            if (projectHistID == "") return false;
            string sql = "SELECT Name FROM fbaProjectHist WHERE ID = " + projectHistID;
            projectName = sys.GetValue(DirectionQuery.Remote, sql);
            return (projectName != "");           
        }                                     
        
        /// <summary>
        /// Скопировать из истории формы на тестовую версию.
        /// </summary>
        /// <param name="projectHistID">ИД проекта из истории изменения проектов</param>
        /// <returns>Если успешно перенесено, true</returns>
        public bool ProjectHistToTest(string projectHistID)
        {
            if (projectHistID == "") return false;
            //Получаем Имя формы по её HistID.
             string projectName;
            if (!GetProjectHistName(projectHistID, out projectName)) return false; 
            
            //Получаем ID формы по её имени.
            string projectID;
            if (!GetProjectID(projectName, out projectID))  return false; 
            
            if (sys.SM("Восстановление проекта из истории." + Var.CR + 
                       "Файлы проекта на диске будут переписаны. Переписать тестовую версию проекта?", MessageType.Question) == false) return false;
            string sql = "";
            
            if (Var.con.serverTypeRemote == ServerType.Postgre)
                sql = "UPDATE fbaProject SET " +
                      "Name = FH.Name, Type = FH.Type, DateChangeTest = datatime('now'), " +
                      "UserChangeTestID = " + Var.UserID  + ", " +                    
                      "ProjectDLLTest = FH.ProjectDLL, CountRowsTest = FH.CountRows " + 
                      "FROM fbaProjectHist FH WHERE fbaProject.ID = " + projectID + " AND FH.ProjectID = " + projectHistID;                    
             
            if (Var.con.serverTypeRemote == ServerType.SQLite)
                sql = "INSERT OR REPLACE INTO fbaProject (ID, Name, Type, DateChangeTest, UserChangeTestID, " +  
            		  "ProjectDLLTest, CountRowsTest)" + Var.CR +
                      "SELECT F.ID, FH.Name, FH.Type, " + sys.DateTimeCurrent() + ", " + Var.UserID  + ", " +
                      "FH.ProjectDLL, FH.CountRows FROM fbaProjectHist FH JOIN fbaProject F ON FH.ProjectID = F.ID " +
                      "AND FH.ProjectID = " + projectID + " AND FH.ID = " + projectHistID;                                
            
            if (Var.con.serverTypeRemote == ServerType.MSSQL)
                 sql = "UPDATE fbaProject SET " +
                      "Name = FH.Name, Type = FH.Type, DateChangeTest = datatime('now'), " +
                      "UserChangeTestID = " + Var.UserID  + ", " +                     
                      "ProjectDLLTest = FH.ProjectDLL, CountRowsTest = FH.CountRows " + 
                      "FROM fbaProjectHist FH WHERE ProjectID = " + projectID + " AND FH.ID = " + projectHistID;  
            
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            
            //Скачиваем проект из БД.
            const bool restoreFromHist = true;           
            if (!ProjectReadFromDataBase(projectName, projectName, projectHistID, restoreFromHist)) return false;
            sys.SM("Проект формы восстановлен из истории!", MessageType.Information);            
            return true;           
        }              
        
        /// <summary>
        /// Копирование формы из тестовой версии в рабочую.
        /// </summary>
        /// <param name="projectID">ИД проекта</param>
        /// <returns>Если успешно скопировано, то true</returns>
        public bool ProjectCopyTestToWork(string projectID)
        {                  
            if (projectID == "") return false;
            string sql = "UPDATE fbaProject SET " +
                  "DateCreate   = (CASE WHEN DateCreate IS NULL THEN " + sys.DateTimeCurrent() + " ELSE DateCreate END), " +
                  "UserCreateID = (CASE WHEN UserCreateID IS NULL THEN " + Var.UserID  + " ELSE UserCreateID END), " +
                  "DateChange   = current_timestamp, UserChangeID = " + Var.UserID  + ", " +                           
                  "CountRows    = CountRowsTest, " +
                  "Hash         = HashTest,      " +                    
                  "ProjectDLL   = ProjectDLLTest " +                             
                  "WHERE ID = " + projectID + ";" + Var.CR +                   
                  "INSERT INTO fbaProjectHist (" +
                  "EntityID, Name, Type, DEL, Block, DateCreate, UserCreateID, " +
                  "ProjectDLL, CountRows, ProjectID, Hash, Comment, ProjectZip) " +
                  "SELECT " + sys.GetEntityID("Project") + ", Name, Type, DEL, Block, " + sys.DateTimeCurrent() + ", " + Var.UserID  + ", " +
                  "ProjectDLL, CountRows, " + projectID + ", Hash, Comment, ProjectZip " + Var.CR + 
                  "FROM fbaProject WHERE ID = " + projectID;
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            sys.SM("Форма скопирована на Work!", MessageType.Information);
            return true;
        }              
                                  
        /// <summary>
        /// Экспорт проекта в файл.
        /// </summary>
        /// <param name="projectID">ИД проекта для экспорта</param>
        /// <returns>Если успешно, то true</returns>
        public bool ProjectExport(string projectID)
        {
            if (projectID == "") return false;
            return sys.RecordSaveToFile(DirectionQuery.Remote, projectID, "Project", "");
        }
            
        /// <summary>
        /// Импорт проекта из файла.
        /// </summary>
        /// <param name="projectID">ИД проекта для экспорта</param>
        /// <returns>Если успешно, то true</returns>
        public bool ProjectImport(string projectID)
        {                           
            if (projectID == "") return false;
            string fileName = "Project." + projectID + ".json";
            const string initialDirectory = "";
            if (!FBAFile.OpenFileName("Import object", "json Files|*.json|All Files|*.*", initialDirectory, ref fileName)) return false;
            string id;
            return sys.RecordLoadFromFile(DirectionQuery.Remote, fileName, true, out id);                             
        }  
                           
		/// <summary>
		/// Событие. Контекстное меню для таблицы форм.  
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void CmFormN14Click(object sender, EventArgs e)
        {                                                
            if (dgvProject.RowCount == 0) return;                            
            
            string projectID   = dgvProject.Value("ID");
            string ProjectPath = dgvProject.Value("ProjectPath");           
            string projectName = Path.GetFileNameWithoutExtension(ProjectPath);            
                                                   
            //New.
            if (sender == cmProjectN24) ProjectNew();
            
            //Rename.
            if (sender == cmProjectN23) ProjectRename(ProjectPath);                         
                      
              
            //Set Type Form                      
            if (sender == cmProjectN21_1) ProjectSetType(projectID, ProjectType.Main);
            if (sender == cmProjectN21_2) ProjectSetType(projectID, ProjectType.App);  
            if (sender == cmProjectN21_3) ProjectSetType(projectID, ProjectType.Dll);
            
            //Delete
            if (sender == cmProjectN20_1) ProjectDelete(projectID, 1);                 
            if (sender == cmProjectN20_2) ProjectDelete(projectID, 2);  
            if (sender == cmProjectN20_3) ProjectDelete(projectID, 3);  
            if (sender == cmProjectN20_4) ProjectDelete(projectID, 4);  
            
            //Export
            if (sender == cmProjectN19) ProjectExport(projectID);
            
            //Import
            if (sender == cmProjectN18) ProjectImport(projectID);   
            
            //Set Active                   
            if (sender == cmProjectN17) ProjectSetDeleted(projectID, false);
            
            //Set Deleted
            if (sender == cmProjectN16) ProjectSetDeleted(projectID, true);

            //================================
            //Copy To Work. Копирование из тестовой версии в рабочую прямо в БД. Локальный проект не затрагивается.
            if (sender == cmProjectN22) ProjectCopyTestToWork(projectID);

            //Copy as New. Копирование формы из fbaProject или fbaProjectHist как нового модуля.
            //Проект копируется из базы данных на диск, и переименовывается.
            if (sender == cmProjectN13) CopyAsNew(projectID, "");           
             
            //Save
            if (sender == cmProjectN27)  SaveProjectAndDLL(projectName);
            
            //Load
            if (sender == cmProjectN28)  LoadProjectAndDLL(projectName);
            //================================

            //Referesh
            if (sender == cmProjectN29) RefreshProjectList();                 
        }         
               
        /// <summary>
        /// Событие. Контекстное меню для таблицы истории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmProjectHistN1Click(object sender, EventArgs e)
        {
            if (dgvHist.Rows.Count == 0) return;                              
                  
            string projectHistID = dgvHist.Value("ID"); //   m.SelectedRows[0].Cells["ID"].Value.ToString();
                        
            //Restore            
            if (sender == cmProjectHistN2) ProjectHistToTest(projectHistID);
            
            //Delete                
            if (sender == cmProjectHistN3) ProjectHistDelete(projectHistID);
            
            //Copy as New
            if (sender == cmProjectHistN4) CopyAsNew("", projectHistID);
        }
             
        /// <summary>
        /// Сохранить все. Это запись в БД всей папки проекта.
        /// </summary>
        /// <param name="projectName"></param>
        private void SaveProjectAndDLL(string projectName)
        {                                        
        	if (!ProjectWriteToDataBase(projectName)) 
        	{
        		sys.SM("Ошибка при сохранении проекта в базу данных!");  
        		return;
        	}
            sys.SM("Форма и проект сохранены в базу данных!", MessageType.Information, "Сохранение в БД");                  
        }        

		/// <summary>
        /// Загрузка проекта.   
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        private void LoadProjectAndDLL(string projectName)
        {                                               
            string fileName;
            ProjectReadFromDataBase(projectName, projectName, "", false); //Это чтение из БД всей папки проекта.   
            const bool forceLoad = true;
            EnterMode enterMode = EnterMode.Work;
            ProjectGetFileName(projectName, enterMode, forceLoad, out fileName); //Это чтение из БД файла exe или dll проекта.
            sys.SM("Проект загружен из базы данных!", MessageType.Information, "Загрузка из БД");
        }
                                               
        /// <summary>
        /// Получить имя текущей выделенного проекта.
        /// </summary>
        /// <returns>Имя проекта</returns>
        private string GetCurrentProjectID()
        {
            string projectID = "0";           
            if (dgvProject.Rows.Count == 0) 
            {             
                GetProjectID(tbProjectName.Text, out projectID);
            } else
            {
                projectID = dgvProject.Value("ID");                                  
            } 
            return projectID;
        }
            
        /// <summary>
        /// Получить имя текущей выделенной формы из истории.
        /// </summary>
        /// <returns></returns>
        private string GetCurrentProjectHistID()
        {                    
            if (dgvHist.Rows.Count == 0) return "0";
            return dgvHist.Value("ID");                                             
        }              
             
        /// <summary>
        /// Показать код выделенной формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl1SelectedIndexChanged(object sender, EventArgs e)
        {                                           
            if (tabControl1.SelectedIndex == 1)
            {
                RefreshProjectHist();
            }                                  
        }  
            
        /// <summary>
        /// Обновить список проектов
        /// </summary>
        private void RefreshProjectList()
        {
            string sql = "SELECT " + Var.CR +
              "  t1.ID   " + Var.CR +
              " ,t1.Name " + Var.CR +
              " , '' as ProjectPath " + Var.CR +
              " ,t1.Type            " + Var.CR +
              " ,(CASE WHEN t1.DEL = 1   THEN 'Yes' ELSE 'No' END) AS Deleted " + Var.CR +
              " ,(CASE WHEN t1.Block = 1 THEN 'Yes' ELSE 'No' END) AS Block " + Var.CR +
              "," + sys.GetSubString() + "(ProjectZip,   1, 50) AS ProjectZip " + Var.CR +
              "," + sys.GetSubString() + "(ProjectDLL,      1, 50) AS ProjectDLL     " + Var.CR +
              "," + sys.GetSubString() + "(ProjectDLLTest,  1, 50) AS ProjectDLLTest    " + Var.CR +           
              " ,t1.Hash                      " + Var.CR +
              " ,t1.HashTest                  " + Var.CR +
              " ,t1.DateCreate                " + Var.CR +
              " ,t1.DateCreateTest            " + Var.CR +
              " ,t1.DateChange                " + Var.CR +
              " ,t1.DateChangeTest            " + Var.CR +
              " ,t2.Name AS UserCreateID      " + Var.CR +
              " ,t4.Name AS UserCreateTestID  " + Var.CR +
              " ,t3.Name AS UserChangeID      " + Var.CR +
              " ,t5.Name AS UserChangeTestID  " + Var.CR +
              " ,t1.CountRows                 " + Var.CR +
              " ,t1.CountRowsTest             " + Var.CR +
              " ,t1.Comment                   " + Var.CR +
              " FROM fbaProject t1               " + Var.CR +
              "   LEFT JOIN fbaUser t2 ON t1.UserCreateID     = t2.ID " + Var.CR +
              "   LEFT JOIN fbaUser t3 ON t1.UserChangeID     = t3.ID " + Var.CR +
              "   LEFT JOIN fbaUser t4 ON t1.UserCreateTestID = t4.ID " + Var.CR +
              "   LEFT JOIN fbaUser t5 ON t1.UserChangeTestID = t5.ID ";         
            System.Data.DataTable DT;
            sys.SelectDT(DirectionQuery.Remote, sql, out DT);
            //DT.Columns.Add("Path", typeof(string));
            
            string[] projects = Directory.GetDirectories(FBAPath.PathForms);
            for (int i = 0; i < projects.Count(); i++)
            {               
                string projectNameDir = Path.GetFileNameWithoutExtension(projects[i]);                   
                bool FindProjectIn = false;
                for (int j = 0; j <  DT.Rows.Count; j++)
                {
                    string projectNameDB = DT.Value(j, "Name");                
                    if (projectNameDir == projectNameDB)
                    {
                        FindProjectIn = true;
                        DT.Rows[j]["ProjectPath"] =  projects[i];
                    }
                }
                if (!FindProjectIn) 
                {
                    var r1 = new string[DT.Columns.Count]; 
                    r1[1] = projectNameDir;
                    r1[2] = projects[i];
                    
                    DT.Rows.Add(r1);
                }                
            }    
            dgvProject.DataSource = DT;
            dgvProject.Columns[1].Width = 200;
            return;           
        }
         
        
        /// <summary>
        /// Обновить таблицу истории формы.
        /// </summary>
        private void RefreshProjectHist()
        {                     
            string projectID = GetCurrentProjectID();  
            if (projectID == "") return;
            string sql = "";                                             
            sql = "SELECT t1.ID, t1.Name, t1.Type, t1.DEL, t1.Block, t1.Hash, " + Var.CR +              
                sys.GetSubString() + "(t1.ProjectDLL,    1, 50) AS ProjectDLL,       " + Var.CR +
                sys.GetSubString() + "(t1.ProjectZip, 1, 50) AS ProjectZip,          " + Var.CR +
                "t1.CountRows,                                                       " + Var.CR +
                "t1.ProjectID,                                                       " + Var.CR +
                "t2.Name AS UserChange,                                              " + Var.CR +
            	"t3.Name AS UserCreate,                                              " + Var.CR +
                "t1.DateCreate                                                       " + Var.CR +                     
                "FROM fbaProjectHist t1                                              " + Var.CR + 
                "LEFT JOIN fbaUser t2 ON  t1.UserChangeID = t2.ID                    " + Var.CR + 
            	"LEFT JOIN fbaUser t3 ON  t1.UserCreateID = t3.ID                    " + Var.CR + 
                "WHERE t1.ProjectID = " + projectID;                   
            System.Data.DataTable dt;
            sys.SelectDT(DirectionQuery.Remote, sql, out dt);
            dgvHist.SetDataSource(dt);
        }
		void DeleteFromHistoryToolStripMenuItemClick(object sender, EventArgs e)
		{
	
		}                
    }
}
