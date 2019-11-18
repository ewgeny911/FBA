
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 28.04.2017
 * Время: 18:10
*/
using System;
using System.Linq; 
using System.Diagnostics;   
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;     
using System.Collections.Generic;                               


namespace FBA
{          
	/// <summary>
	/// Форма для обновления программы.
	/// </summary>
	public partial class FormUpdate : Form
    {
        #region Инициализация и конструктор.
           
        bool UpdateWork     = false;
        const string CR     = "\r\n"; //Перенос строки        
        static string PathMain     = System.Windows.Forms.Application.StartupPath + @"\";
        string PathUpdate   = PathMain + @"Update\";
        string PathRollback = PathMain + @"Rollback\";
        string ParamEXE     = "";
        //string startPath  = System.AppDomain.CurrentDomain.BaseDirectory; 
        //string startPath1 = Directory.GetCurrentDirectory();
        
    	public FormUpdate(string[] args)
        {   
            InitializeComponent();
            //string startPath2 = this.GetType().Module.FullyQualifiedName;
            if (args.Length > 1) ParamEXE = args[1] + ".exe";
            progressBar1.Value = 0;           
            //timer1.Start();
        }
    	
        #endregion
        
    	#region Статические функции
    	
    	/// <summary>
        /// Удаление папки.
        /// </summary>
        /// <param name="dirName">Исходная папка</param>
		/// <param name="errorMes">Сообщение об ошибке</param>
		/// <param name="showMes">Показывать сообщение об ошибке или нет</param>
        /// <returns>Если успешно, то true</returns>
        public static bool DirDelete(string dirName, out string errorMes, bool showMes = true)
        {           
            errorMes = "";
            try
            {        
                Directory.Delete(dirName, true); //true - удаляем все (файлы и папки) что внутри папки.
                return true;
            } 
            catch (DirectoryNotFoundException ex)
            {
                //Папка не найдена - не считаем это ошибкой.
                string err = ex.Message;
            }
            catch (Exception ex)
            {
                errorMes = ex.Message;
                if (showMes) SM("Ошибка удаления папки " + dirName + ": " +  errorMes);
                return false;
            }
            return true;
        }
        
    	/// <summary>
        /// Удаление файла.
        /// </summary>
        /// <param name="fileName">Имя файла, который удаляем</param>       
        /// <param name="errorMes">Текст ошибки, если возникла</param>
        /// <param name="showMes">Показывать или нет сообщение об ошибке</param>
        /// <returns>Если успешно,то true</returns>       
        public static bool FileDelete(string fileName, out string errorMes, bool showMes = true)
        {           
            errorMes = "";
            try
            {
                File.Delete(fileName);
                return true;
            } catch (Exception ex)
            {
                errorMes = ex.Message;
                if (showMes) SM("Ошибка удаления файла " + fileName + ": " +  ex.Message);
                return false;
            }           
        }
                        
		/// <summary>
		/// Удаление из папки всех вложенных папок и файлов. Сама папка DirName не удаляется.  
		/// </summary>
		/// <param name="dirName">Исходная папка</param>
		/// <param name="errorMes">Сообщение об ошибке</param>
		/// <param name="showMes">Показывать сообщение об ошибке или нет</param>
		/// <returns>Если успешно, то true</returns>
        public static bool DirClean(string dirName, out string errorMes, bool showMes)
        {                         
            //Рекурсия не используется. 
            //На самом деле для удаления папки и всех вложенных папок и файлов можно написать Directory.Delete(DirName, true);
            //Но нам нужен список ошибок, и удаление всего что удаляется. Кроме того саму папку DirName удалять не нужно.
            errorMes = "";
            var listError = new List<string>();
            string[] di = Directory.GetDirectories(dirName, "*", SearchOption.AllDirectories);               
            string[] fi = Directory.GetFiles(dirName, "*.*", SearchOption.AllDirectories);                                            
            
            //удаление всех файлов.
            foreach (string fileName in fi)
            {
                errorMes = "";
                if (!FileDelete(fileName, out errorMes, false)) listError.Add(errorMes);
            }                
            //Удаление всех папок.               
            for (int i = di.Length-1; i > -1; i--)
            {
                errorMes = "";
                string dirName2 = di[i];
                if (!DirDelete(dirName2, out errorMes, false)) listError.Add(errorMes);
            }
            
            if (listError.Count > 0)
            {     
                errorMes = string.Join(CR, listError.ToArray());
                if (showMes) SM("При удалении возникли ошибки: " + CR + errorMes);
                return false;
            }
            return true;                           
        }
        
    	/// <summary>
        /// Копирование файла. FileExists = (Overwrite, Skip, Ask)
        /// </summary>
        /// <param name="fileSource">Исходный файл</param>
        /// <param name="fileDestination">Куда копируем - полное имя нового файла</param>
        /// <param name="fileExists">Настройки копирования</param>
        /// <param name="showMes">Если ошибка, то показываем сообщение</param>
        /// <param name="errorMes">Возвращает текст ошибки при копировании, если произошла.</param>
        /// <returns>Если файл успешно скопирован, то true</returns>
        public static bool FileCopy(string fileSource, string fileDestination, FileOverwrite fileExists, bool showMes, out string errorMes)
        {            
            errorMes = "";
            try
            {   
                bool Overwrite = true;
                if (fileExists == FileOverwrite.Overwrite) Overwrite = true;
                if (fileExists == FileOverwrite.Skip)      Overwrite = false;
                if (fileExists == FileOverwrite.Ask)
                {
                	if (File.Exists(fileDestination))
                	{                	                    	    
                	        if (!SM("File already exists: " + fileDestination + CR + "Overwrite?", MessageType.Question, "Copying file")) Overwrite = false;
                	}                		
                }
                File.Copy(fileSource, fileDestination, Overwrite);
                return true;
            } catch (Exception ex)
            {
                errorMes = ex.Message;
                if (showMes) SM("Error copying file " + fileSource + " в " + fileDestination + CR + ex.Message);
                return false;
            }           
        }
                       
		/// <summary>
		/// Процедура для показа сообщения MessageBox.Show().  
		/// </summary>
		/// <param name="str">Сообщение</param>
		/// <param name="typeMessage">Тип сообщения</param>
		/// <param name="caption">Заголовок формы</param>
		/// <returns>Если диалог - это вопрос, то если ответ Да, 
		/// то возвращает true, если тип диалого не вопрос, то всегда true</returns>
        public static bool SM(string str, MessageType typeMessage = MessageType.Error, string caption = "")
        {               
            //Если вопрос, то два варианта Yes, No. Результат соответтвенно bool: true, false;
            if (str == null) str = "";
            MessageBoxIcon   mbi = MessageBoxIcon.Error;
            MessageBoxButtons mb = MessageBoxButtons.OK;                   
            if (typeMessage == MessageType.Information) mbi = MessageBoxIcon.Information;                    
            if (typeMessage == MessageType.Question) 
            {
                mbi = MessageBoxIcon.Question;
                mb = MessageBoxButtons.YesNo; 
            }
            if (caption == "") caption = typeMessage.ToString();
            var result = MessageBox.Show(str, caption, mb, mbi);             
            return (result == DialogResult.Yes);                                     
            //MessageBoxDefaultButton.Button1, 
            //MessageBoxOptions.DefaultDesktopOnly);          
        }
      
        /// <summary>
        /// Для сокращения строк кода. Проверка на условие. Пример: 
        /// if (ErrorCheck(!File.Exists(fileName), "File not found: " + fileName)) return false;
        /// </summary>
        /// <param name="condition">Условие</param>
        /// <param name="errorMes">Сообщение об ошибке</param>
        /// <returns></returns>
        public static bool ErrorCheck(bool condition, string errorMes)
        {            
            if (condition)
            {
                SM(errorMes);
                return true;
            } 
            return false;
        }        
        
        /// <summary>
        /// Запуск файла в приложении по умолчанию.
        /// </summary>
        /// <param name="run">Process запущенного файла</param>
        /// <param name="fileName">Имя файла, который запускаем</param>
        /// <param name="paramStr">Строка параметров при запуске файла</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileRun(out System.Diagnostics.Process run, string fileName, string paramStr)
        {
            run = null;
            if (ErrorCheck(!File.Exists(fileName), "Не найден файл: " + fileName)) return false;
            if (ErrorCheck(Path.GetExtension(fileName.ToLower()) != ".exe", "Запуск возможен только для exe файлов!")) return false;
            run = new System.Diagnostics.Process();
            if (paramStr != "") run.StartInfo.Arguments = paramStr;
            run.StartInfo.FileName = fileName;
            try
            {
                run.Start();                
            }
            catch (Exception ex)
            {
                SM(ex.Message);
                return false;
            } 
			return true;            
        }

        private void AddLog(string textmessage)
        {
            textBoxUpdate.AppendText(DateTime.Now.ToString("G") + ": " + textmessage + CR);
        }
                
        #endregion
        
        ///Откат обновления при возникновения ошибки.
        private bool RollBackCopy()
        {
            AddLog("Выполняется восстановление из резервной копии.");   
            string[] di = Directory.GetDirectories(PathRollback, "*", SearchOption.AllDirectories);
            string[] fi = Directory.GetFiles(PathRollback, "*.*", SearchOption.AllDirectories);            
            
            //Создание папок.
            if (!CreateDirs(PathMain, di)) return false;
            
            //Копирование файлов.
            AddLog("Копирование файлов обновления");
            for (int i = 1; i < fi.Length; i++)
            {
                string fileName     = fi[i];  
                label1.Text         = "Current file: " + fileName;
                string fileNameMain = fileName.Replace(PathRollback, PathMain);                
                if (!CopyFileUpdate(fileName, fileNameMain)) return false;                                                      
            }
            label1.Text = "Current file: ";
            return true;
        }
              
        /// <summary>
        /// Создание папок, если они указаны в обновлении.
        /// </summary>
        /// <param name="dirCopy"></param>
        /// <param name="di"></param>
        /// <returns></returns>
        private bool CreateDirs(string dirCopy, string[] di)
        {                                          
            //Создание папок.
            for (int i = 0; i < di.Length; i++)
            {
                string dirName         = di[i];
                string dirNameCopy     = dirName.Replace(PathUpdate, dirCopy);
                try
                {      
                    label1.Text = "Current directory: " + dirNameCopy;
                    Directory.CreateDirectory(dirNameCopy);
                } catch (Exception ex)
                {                 
                    AddLog("Ошибка при создании папки: " + dirNameCopy + " " + ex.Message);
                    AddLog("Обновление прервано ");  
                    return false;
                }               
            }
            label1.Text = "";
            return true;
        }
        
        ///Копирование файла обновления.
        private bool CopyFileUpdate(string fileName, string fileNameCopy)
        {
            string errorMes = "";
            if (FileCopy(fileName, fileNameCopy, FileOverwrite.Overwrite, false, out errorMes))
            {
                AddLog("Файл скопирован успешно: " + fileNameCopy);
                return true;
            }               
           
            AddLog("Ошибка копирования файла: " + fileNameCopy + " - " + errorMes);                       
            AddLog("Обновление прервано.");  
            return false;                   
        }              
        
        ///Обновление программы       
        private bool ReplaceFiles()
        {        	        	        	        	               	
        	string errorMes = ""; 
        	string dateTimeNow  = "";
        	
        	//Очищаем папку PathRollback, куда будем складывать файлы, которые будут обновляться. Это старые версии файлов.
        	if (!DirClean(PathRollback, out errorMes, true)) 
        	{
        	    dateTimeNow = DateTime.Now.ToString("G");
        	    AddLog("Ошибка при очистки папки для резервного копирования: " + PathRollback);
        	    AddLog("Обновление прервано.");  
        	    return false;
        	}
        	          	 
        	string[] di = Directory.GetDirectories(PathUpdate, "*", SearchOption.AllDirectories);
        	string[] fi = Directory.GetFiles(PathUpdate, "*.*", SearchOption.AllDirectories);
        	
        	AddLog("Создание резервной копии перед обновлением.");
        	if (!CreateDirs(PathRollback, di)) return false;
    	    
        	AddLog("Создание папок для обновления.");
        	if (!CreateDirs(PathMain, di)) return false;     
        	        	      
            //Копирование файлов.
            AddLog("Копирование файлов обновления");
            progressBar1.Maximum = fi.Length - 1;
            progressBar1.Value   = 0;
            for (int i = 1; i < fi.Length; i++)
            {
                string fileName          = fi[i];  
                if (Path.GetFileNameWithoutExtension(fileName) == "Updater") continue;
                string fileNameRollback  = fileName.Replace(PathUpdate, PathRollback);  
                string fileNameMain      = fileName.Replace(PathUpdate, PathMain);       
                label1.Text = "Current file: " + fileName;                
                if (!CopyFileUpdate(fileName, fileNameRollback)) return false; //Это копирование в папку RollBack.                                
                if (!CopyFileUpdate(fileName, fileNameMain)) //Это уже копирование в боевую папку, поэтому при ошибку откатываем.   
                {                       
                    RollBackCopy();
                    return false;
                }
                progressBar1.Value   = i;
            }
            label1.Text = "Программа обновлена успешно!"; //"The program is updated successfully!";
            SM(label1.Text, MessageType.Information, "Обновление программы");
            
            //Если в параметрах был указан файл, который нужно запустить после проведения обновления, то запускаем.
            if (ParamEXE != "")
            {
                System.Diagnostics.Process prc;
                if (!FileRun(out prc, ParamEXE, "")) return false;
            }
            
            Environment.Exit(0);
            return true;                   	        			                       
        }
  
		/// <summary>
		/// Останавливаем все процессы EXE, которые запущены из папки PathMain. 
		/// </summary>
		/// <returns></returns>
        private int StopExeProcessInPathMain()
        {              
            int findExe = 0;
            Process[] proclist = Process.GetProcesses();
            foreach (Process proc in proclist)
            {
                string processName      = "";
                string processFileName  = ""; 
                string processExtension = "";
                try 
                {
                    processName     = proc.ProcessName;
                    processFileName = proc.MainModule.FileName.Replace("\"", "");
                }                                               
                catch //(Win32Exception)
                {               
                }                       
                
                if (processFileName != "")
                {
                    processExtension = Path.GetExtension(processFileName);
                    if (processFileName.IndexOf(PathMain, StringComparison.OrdinalIgnoreCase) > -1)
                    {                  
                        if (processExtension == ".exe")
                        {
                            if (processName != "Updater")
                            {
                                AddLog("Закрытие процесса: " + processFileName);
                                proc.Kill(); //Себя не останавливаем.
                                findExe += 1;                                   
                            }   
                        }                                         
                    }      
                }                                                       
            }                                                            
            return findExe; 
        }                      
                  
        /// <summary>
        /// Событие. Таймер. Для того чтобы можно было зайти в процедуру ReplaceFiles всего один раз. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1Tick(object sender, EventArgs e)
        {
        	if (UpdateWork == true) 
        	{
        		timer1.Stop();
        		return;
        	}
        	  
            if (StopExeProcessInPathMain() > 0) 
            {                
                return;
            }
        	
            UpdateWork = true;
            ReplaceFiles();
        }          
        
        /// <summary>
        /// Получить список процессов. Для теста.
        /// </summary>
        private void GetListProcess()
        {
            Process[] proclist = Process.GetProcesses();
            foreach (Process proc in proclist)
            {                 
                string processFileName  = ""; 
                try 
                {
                    processFileName = proc.MainModule.FileName;                  
                }
                catch (Win32Exception) {}                    
                AddLog(proc.ProcessName + " : " + processFileName);               
            }         
        }                                                        
    }  
	
	/// <summary>
	/// Все возможные типы сообщений.
	/// </summary>
	public enum MessageType
	{
	    /// <summary>
	    /// Ошибка
	    /// </summary>
		Error,
		
		/// <summary>
		/// Системная ошибка. В этом случае к выводимому сообщению добавляется дополнительная информация.
		/// </summary>
	    SystemError,	
	    
	    /// <summary>
	    /// Ошибка и нужно ответить на вопрос
	    /// </summary>
	    ErrorQuestion,	   

		/// <summary>
	    /// Другой Значок, чем у сообщения Ошибка и системная ошибка
	    /// </summary>	    
	    Stop,
	    
	    /// <summary>
	    /// Выаод информации, не требует от пользователя принятия решения.
	    /// </summary>
	    Information,
	    
	    /// <summary>
	    /// Значок восклицательный знак
	    /// </summary>
	    Warning,
	    
	    /// <summary>
	    /// Вопрос пользователю
	    /// </summary>
	    Question
	} 

	/// <summary>
	/// Настрйоки записи файла.
	/// </summary>
	public enum FileOverwrite
	{		
 		/// <summary>
 		/// Спросить
 		/// </summary>
 		Ask,
 		
 		/// <summary>
 		/// Перезаписать
 		/// </summary>    
        Overwrite,
        
        /// <summary>
        /// Ничего не делать - пропустить.
        /// </summary>
        Skip              
 	}	
}


	