
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 25.08.2017
 * Время: 23:28
 */
 
using System;
using System.Windows.Forms;    
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices; 
using System.Diagnostics;
using Ionic.Zip;

namespace FBA
{   
    
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
		
	/// <summary>
    /// Статический класс. Различные функции работы с файлами и папками.
    /// </summary>
    public static class FBAFile
    {       
        /// <summary>
        /// Проверка на то что файл отрыт в другой программе.
        /// Расширение для класса Extension.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static bool IsFileLocked(this Exception exception)
        {
            //private const int ERROR_SHARING_VIOLATION = 32;
            //private const int ERROR_LOCK_VIOLATION = 33;
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == 32 || errorCode == 33;
        }

        #region Получить путь к файлу или папке
     
        /// <summary>
        /// Возвращает полный путь к локальной БД SQLIte.     
        /// </summary>
        /// <param name="fileName">Полный путь к файлу БД SQLIte</param>
        /// <returns>Если файл БД наден, то true</returns>
        public static bool GetPathSQLite(out string fileName)
        {
            string applicationDirectory = System.Windows.Forms.Application.StartupPath;
            fileName = applicationDirectory + @"\local.db3";
            if (!File.Exists(fileName)) fileName = @"..\..\..\sys\bin\Debug\local.db3";
            if (!File.Exists(fileName)) fileName = @"..\..\..\ClientApp\bin\Debug\local.db3";
            if (!File.Exists(fileName))
            {
                sys.SM("File not found local.db3", MessageType.Information, "Entering to system");
                return false;
            }

            //Функция GetFullPath возвращает полный путь относительно текущей папки.
            Directory.SetCurrentDirectory(applicationDirectory);
            fileName = System.IO.Path.GetFullPath(fileName);
            if (!File.Exists(fileName))
            {
                sys.SM("File not found local.db3:" + fileName, MessageType.Information, "Entering to system");
                return false;
            }
            return true;
        }              
        
        /// <summary>
        /// Возвращает полный путь к форме (файлу DLL или EXE).
        /// </summary>
        /// <param name="projectName">Имя проекта</param>
        /// <param name="fileNameEXE">Имя файла проекта EXE</param>
        /// <param name="fileNameDLL">Имя файла проекта EXE</param>
        /// <param name="findEXE">Найден или нет EXE файл проекта</param>
        /// <param name="findDLL">Найден или нет DLL файл проекта</param>
        /// <returns>Если что-то найдено EXE или DLL, то true</returns>
        public static bool GetPathProject(string projectName, out string fileNameEXE, out string fileNameDLL, out bool findEXE, out bool findDLL)
        {            
            //Функция GetFullPath возвращает полный путь относительно текущей папки.            
            //string FileNameFull = System.IO.Path.GetFullPath(FileName); 			
            //Directory.SetCurrentDirectory(FBAPath.PathMain);       
            fileNameEXE = FBAPath.PathApp + projectName + ".exe";
            fileNameDLL = FBAPath.PathApp + projectName + ".dll";
            findEXE = File.Exists(fileNameEXE);
            findDLL     = File.Exists(fileNameDLL);
            
            return (findEXE || findDLL);
        }
       
        /// <summary>
        /// Вернуть путь к темповой папке.
        /// </summary>
        /// <param name="dirName">Имя папки для временных файлов</param>
        /// <returns>Если папка найдена или только что успешно создана, то true</returns>
        public static bool GetPathTemp(out string dirName)
        {
            dirName = FBAPath.PathTemp;
            if (Directory.Exists(FBAPath.PathTemp)) return true;
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(FBAPath.PathTemp);
                return true;
            }
            catch (IOException ex)
            {
                sys.SM(ex.Message);
                return false;
            }
        }
    
        /// <summary>
        /// Возвращает полный путь имени файла без расширения.
        /// GetFileNameFullWithoutEXT(@"E:\Excel работа\ExcelLibrary\ExcelLib.dll")
        /// вернёт E:\Excel работа\ExcelLibrary\ExcelLib
        /// </summary>
        /// <param name="fileNameFull">Полный путь к файлу</param>
        /// <returns>Полный путь имени файла без расширения</returns>
        public static string GetFileNameFullWithoutEXT(string fileNameFull)
        {
            return Path.GetDirectoryName(fileNameFull) + @"\" + Path.GetFileNameWithoutExtension(fileNameFull);
        }
           
        /// <summary>
        /// Получить новое уникальное имя файла.
        /// Проверка на то, что файл уже существует, в этом случае запрашивается у пользователя новое имя.
        /// Если AutoSetNewName, то новое имя выбирается автоматически. Если Отчет пример.xls сущесствует, то:
        /// Отчет пример_1.xls
        /// Отчет пример_2.xls
        /// ...и т.д.
        /// </summary>
        /// <param name="fileNameFull">Полное сходное имя файла</param>
        /// <param name="autoSetNewName">Если true, если файл существует, то появится диалог для ввода нового имени файла</param>
        /// <param name="fileNameFullNew">Новое имя файла. Введённое пользователем или подобранное автоматически</param>
        /// <returns>Если новое имя файла выбрано, то true. false-не удалось подобрать имя</returns>
        public static bool GetNewFileName(string fileNameFull, bool autoSetNewName, out string fileNameFullNew)
        {
            int i = 1;
            fileNameFullNew = "";
            while (File.Exists(fileNameFull))               
            {
                if (!autoSetNewName)
                {
                    if (!sys.InputValue("File already exists: " + fileNameFull, "Enter a new filename:", SizeMode.Small, ValueType.String, ref fileNameFull)) return false;
                }
                else
                {
                    string fileNameWithoutEXT = GetFileNameFullWithoutEXT(fileNameFull);
                    int p = fileNameWithoutEXT.LastIndexOf("_");
                    if (p > 0)
                    {
                        int numstr = fileNameWithoutEXT.Substring(p + 1).ToInt(false);
                        if (numstr > 0)
                        {                            
                            fileNameWithoutEXT = fileNameWithoutEXT.Substring(0, p);
                            i = numstr + 1;
                        }
                    }
                    string ext = System.IO.Path.GetExtension(fileNameFull);
                    fileNameFull = fileNameWithoutEXT + "_" + i.ToString() + ext;
                    i++;
                }
            }
            fileNameFullNew = fileNameFull;
            return true;
        }


        /// <summary>
        /// Открыть окно выбора файла. Пример Filter: "json Files|*.json|All Files|*.*"
        /// </summary>
        /// <param name="title">Название окна выбора файла</param>
        /// <param name="filter">Фильтр</param>
        /// <param name="initialDirectory">Начальная папка</param>
        /// <param name="fileName">Имя файла, которое вернётся</param>
        /// <returns>Если выбор файла произош, то true</returns>
        public static bool OpenFileName(string title, string filter, string initialDirectory, ref string fileName)
        {
            if (title == "")  title  = "File choise";
            if (filter == "") filter = "All Files|*.*";
            fileName = Path.GetFileName(fileName);         
            var fd = new OpenFileDialog();
            fd.Title    = title;
            fd.FileName = fileName;
            fd.Filter   = filter;
            var par = new string[10];
            if (string.IsNullOrEmpty(initialDirectory))
            {                                
                if (Param.Load(DirectionQuery.Local, Var.UserID , "InitialDirectory", true, "User", out par))
                {
                    fd.InitialDirectory = par[0];
                    if (par[1] != "") fd.FilterIndex = par[1].ToInt();
                }
            }
            else fd.InitialDirectory = initialDirectory;

            if (fd.ShowDialog() != DialogResult.OK) return false;
            fileName = fd.FileName; 
            string dirName = Path.GetDirectoryName(fileName);
            if (initialDirectory != dirName)
            {                
                par[0] = dirName;
                par[1] = fd.FilterIndex.ToString();
                Param.Save(DirectionQuery.Local, Var.UserID , "InitialDirectory", true, par, "User", "", "Path of arbitrary file open dialog");
            }
            return true;
        }
                            		
		/// <summary>
		/// Окно сохранения файла.
        /// InitialDirectory - начальная папка, куда сохранять файл.
		/// Filter - список расширений файлов.
		/// filterIndex - индекс расширения файла по умолчанию. 		
		/// FileName - имя файла по умолчанию.
		/// </summary>
		/// <param name="title">Шапка диалога сохранения файла</param>
		/// <param name="filter">Список расширений файлов</param>
		/// <param name="initialDirectory">Начальная папка, куда сохранять файл.</param>
		/// <param name="filterIndex">Индекс расширения файла по умолчанию</param>
		/// <param name="fileName">имя файла по умолчанию.</param>
		/// <returns>Если файл удалось сохранить, то true</returns>
        public static bool SaveFileName(string title, string filter, string initialDirectory, int filterIndex,  ref string fileName)
        {      
            if (title == "") title = "Saving file";
            if (filter == "") filter = "All Files|*.*";
            var fd = new SaveFileDialog();
            fd.Title = title;
            fd.FileName = fileName;
            fd.Filter = filter;
            var par = new string[10];
            if (string.IsNullOrEmpty(initialDirectory))
            {                           
                if (Param.Load(DirectionQuery.Local, Var.UserID , "InitialDirectory", true, "User", out par)) fd.InitialDirectory = par[0];                                   
            }
            else fd.InitialDirectory = initialDirectory;
            
            if (filterIndex == -1) 
            {
            	if (!string.IsNullOrEmpty(par[1])) fd.FilterIndex = par[1].ToInt();
            	else fd.FilterIndex = 0;
            } else fd.FilterIndex = filterIndex;
           
            if (fd.ShowDialog() != DialogResult.OK) return false;
            fileName = fd.FileName;               
            par[0] = Path.GetDirectoryName(fileName);
            par[1] = fd.FilterIndex.ToString();
            Param.Save(DirectionQuery.Local, Var.UserID , "InitialDirectory", true, par, "User", "", "Path of arbitrary file open dialog");
            return true;
        }                
           
        /// <summary>
        /// Для отладки и тестирования. Запись вызова процедуры в файл.
        /// Запись идет вот таким образом: sourceLineNumber + memberName + sourceFilePath
        /// </summary>
        /// <param name="fileNameDebug">Имя файла, куда записываем</param>
        /// <param name="str">Если нужно записать вместо отладочной информации произвольную строку</param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath">Файл cs с ошибкой</param>
        /// <param name="sourceLineNumber">Номер строки кода</param>
        public static void SaveDebug(string fileNameDebug, string str = "", 
                                [System.Runtime.CompilerServices.CallerMemberName] string memberName       = "",
                                [System.Runtime.CompilerServices.CallerFilePath]   string sourceFilePath   = "",
                                [System.Runtime.CompilerServices.CallerLineNumber] int    sourceLineNumber = 0)
        {  
            if (str == "")
            {
                string strFileCS = Path.GetFileName(sourceFilePath);
                if (str != "") str += ": ";
                str += sourceLineNumber.ToString() + ": " + memberName + " " + strFileCS; 
            }                           
            var myfile = new StreamWriter(fileNameDebug, true);
            myfile.WriteLine(str);
            myfile.Close();                           
        }

        #endregion

        #region Функции работы с файлами и папками.     
        
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
            if (sys.ErrorCheck(!File.Exists(fileName), "File not found: " + fileName)) return false;     
            run = new System.Diagnostics.Process();
            if (paramStr != "") run.StartInfo.Arguments = paramStr;
            run.StartInfo.FileName = fileName;
            try
            {
                run.Start();
                return true;
            }
            catch (Exception ex)
            {
                sys.SM(ex.Message);
                return false;
            }
        }
     
        /// <summary>
        /// Запуск файла в приложении по умолчанию.
        /// </summary>
        /// <param name="fileName">Имя файла, который запускаем</param>
        /// <param name="paramStr">Строка параметров при запуске файла</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileRunSimple(string fileName, string paramStr)
        {
            System.Diagnostics.Process run;
            if (sys.ErrorCheck(!File.Exists(fileName), "File not found: " + fileName)) return false;
            run = new System.Diagnostics.Process();
            if (paramStr != "") run.StartInfo.Arguments = paramStr;
            run.StartInfo.FileName = fileName;
            try
            {
                run.Start();
                return true;
            }
            catch (Exception ex)
            {
                sys.SM(ex.Message);
                return false;
            }
        }
        
        /// <summary>
        /// Запуск EXE файла.
        /// </summary>
        /// <param name="run">Process запущенного файла</param>
        /// <param name="fileName">Имя файла, который запускаем</param>
        /// <param name="paramStr">Строка параметров при запуске файла</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileRunEXE(out System.Diagnostics.Process run, string fileName, string paramStr)
        {
            run = null;
            if (sys.ErrorCheck(Path.GetExtension(fileName) != ".exe", "Launch is possible only for exe files!")) return false;
            return FBAFile.FileRun(out run, fileName, paramStr);
        }
           
        /// <summary>
        /// Простой запуск EXE файла.
        /// </summary>
        /// <param name="fileName">Имя файла, который запускаем</param>
        /// <param name="paramStr">Строка параметров при запуске файла</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileRunEXESimple(string fileName, string paramStr = "")
        {
            System.Diagnostics.Process run;
            return FileRunEXE(out run, fileName, paramStr);
        }
                     
        /// <summary>
        /// /Просмотр файла в блокноте.
        /// </summary>
        /// <param name="fileName">Имя файла, который запускаем в блокноте Windows notepad.exe</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileRunNotebook(string fileName)
        {           
            try
            {
               Process.Start(@"C:\Windows\System32\notepad.exe", fileName);
               return true; 
            } catch (Exception ex)
            {
                sys.SM(ex.Message);
                return false;
            }           
        }
                   
        /// <summary>
        /// Остановка EXE файла.
        /// </summary>
        /// <param name="run">Process запущенного файла</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileStop(System.Diagnostics.Process run)
        {
            try
            {
                if ((run != null) && (!run.HasExited)) run.Kill();
                return true;
            } catch (Exception ex)
            {
                sys.SM("Error when stopping process: " + run.ToString() + Var.CR + ex.Message);
                return false;
            }
            
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
                bool overwrite = true;
                if (fileExists == FileOverwrite.Overwrite) overwrite = true;
                if (fileExists == FileOverwrite.Skip)      overwrite = false;
                if (fileExists == FileOverwrite.Ask)
                {
                	if (File.Exists(fileDestination))
                	{                	                    	    
                	        if (!sys.SM("File already exists: " + fileDestination + Var.CR + "Overwrite?", MessageType.Question, "Copying file")) overwrite = false;
                	}
                		
                }
                File.Copy(fileSource, fileDestination, overwrite);
                return true;
            } catch (Exception ex)
            {
                errorMes = ex.Message;
                if (showMes) sys.SM("Error copying file " + fileSource + " в " + fileDestination + Var.CR + ex.Message);
                return false;
            }           
        }
                
        /// <summary>
        /// Переименование файла. FileExists = (Overwrite, Skip, Ask)
        /// </summary>
        /// <param name="fileSource">Исходный файл</param>
        /// <param name="fileDestination">Новое имя файла</param>
        /// <param name="fileExists">Настройки преименования</param>
        /// <param name="showMes">Если ошибка, то показываем сообщение</param>
        /// <param name="errorMes">Возвращает текст ошибки при переименовании файла, если произошла.</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileRename(string fileSource, string fileDestination, FileOverwrite fileExists, bool showMes, out string errorMes)
        {            
            errorMes = "";
            try
            {        
                if (File.Exists(fileDestination))
                {                                                
                    if (fileExists == FileOverwrite.Skip) return true;
                    if (fileExists == FileOverwrite.Overwrite)
                    {
                        if (!FileDelete(fileDestination, out errorMes, showMes)) return false;
                    }
                    if (fileExists == FileOverwrite.Ask)
                    {
                         if (!sys.SM("File already exists: " + fileDestination + Var.CR + "Overwrite?", MessageType.Question, "Copying file")) return false;
                         if (!FileDelete(fileDestination, out errorMes, showMes)) return false;
                    }                                    
                }
                File.Move(fileSource, fileDestination);
                return true;
            } catch (Exception ex)
            {
                errorMes = ex.Message;
                if (showMes) sys.SM("Error renaming file " + fileSource + " в " + fileDestination + Var.CR + ex.Message);
                return false;
            }           
        }      
               
        /// <summary>
        /// Поиск файла.
        /// </summary>
        /// <param name="dirName">Папка, в которой искать файл</param>
        /// <param name="fileName">Имя файла с расширением, либо без расширения, либо часть имени. По умолчанию *.*</param>
        /// <param name="subDirectories">Искать в подпапках или нет</param>
        /// <returns>Список найденных файлов. Если *.*, то вернёт все файлы в папке (и во всех вложенных папках, если subDirectories = true)</returns>
        public static string[] FileFind(string dirName, string fileName = "*.*", bool subDirectories = true)
        {  
            SearchOption sof;
            if (subDirectories) sof = SearchOption.AllDirectories;
            else sof = SearchOption.TopDirectoryOnly;            
            return Directory.GetFiles(dirName, fileName, sof);
            //foreach (string file in allFoundFiles) listBox1.Items.Add(file);            
        }    
      
        /// <summary>
        /// Загрузка текста в TextBox. Если Newload == false, то загрузка только в том случае, если текст ещё не загружен.
        /// </summary>
        /// <param name="obj">Объект TextBox или FastColoredTextBox или ListBox</param>
        /// <param name="fileName">Имя файла, из которго загрузить список строк</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileReadTextObject(Object obj, string fileName)
        {
            if (!File.Exists(fileName)) return false;          
            Type tp1 = obj.GetType();                                                                   
            if (tp1.Name == "TextBox")            (obj as System.Windows.Forms.TextBox).Text = File.ReadAllText(fileName, System.Text.Encoding.Default);
            if (tp1.Name == "FastColoredTextBox") (obj as FastColoredTextBoxNS.FastColoredTextBox).Text = File.ReadAllText(fileName, System.Text.Encoding.Default);                                                
            if (tp1.Name == "ListBox")
            {                
                //здесь происходит удаление имеющихся записей в listBox
                int index;
                string line;
                var lb = obj as System.Windows.Forms.ListBox;
                if (lb.Items.Count != 0)
                    for (index = lb.Items.Count - 1; index >= 0; index--)
                        lb.Items.RemoveAt(index);
                                
                FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read);
                if (fs != null)
                {
                    var reader = new StreamReader(fs);
                    while ((line = reader.ReadLine()) != null) lb.Items.Add(line);
                    fs.Close();
                }
            }
            return true;           
        }

        /// <summary>
        /// Сохранение текста из TextBox, FastColoredTextBox, ListBox в файл.
        /// </summary>
        /// <param name="obj">Объект TextBox или FastColoredTextBox или ListBox</param>
        /// <param name="fileName">Имя файла, из которго загрузить список строк</param>
        /// <param name="showMes">Показывать ошибки или нет</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileWriteTextObject(Object obj, string fileName, bool showMes = true)  //System.Windows.Forms.TextBox
        {
            try
            {
                Type tp1 = obj.GetType();
                if (tp1.Name == "TextBox")
                    File.WriteAllText(fileName, (obj as System.Windows.Forms.TextBox).Text, System.Text.Encoding.Default); 
                if (tp1.Name == "FastColoredTextBox")
                    File.WriteAllText(fileName, (obj as FastColoredTextBoxNS.FastColoredTextBox).Text, System.Text.Encoding.Default);           
                if (tp1.Name == "ListBox")
                {
                    var sw = new StreamWriter(fileName);
                    foreach (var item in (obj as System.Windows.Forms.ListBox).Items) sw.WriteLine(item);                         
                    sw.Close();
                }                 
                if (showMes) sys.SM("Saved successfully", MessageType.Information);
                return true; 
            } catch(Exception ex)
            {
            	if (showMes) sys.SM("Error saving file: " + ex.Message);
                return false; 
            }            
        }                                   
        
        /// <summary>
        /// Сохранение текста в файл.
        /// </summary>
        /// <param name="text">Текст для сохранения в файл</param>
        /// <param name="fileName">Полное имя файла с путём</param>
        /// <param name="showMes">Показывать сообщение об ошибке или нет</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileWriteText(string text, string fileName, bool showMes = true)  
        {
            try
            {                 
                File.WriteAllText(fileName, text, System.Text.Encoding.Default);            
                if (showMes) sys.SM("Saved successfully", MessageType.Information);
                return true; 
            } catch(Exception ex)
            {
            	sys.SM("Error saving file: " + ex.Message);
                return false; 
            }            
        }           
             
        /// <summary>
        /// Определение кодировки файла. 
        /// </summary>
        /// <param name="fileName">Полное имя файла с путём</param>
        /// <param name="showMes">Показывать сообщение об ошибке или нет</param>
        /// <param name="encoding">Кодировка Encoding</param>
        /// <returns>Если успешно, то true</returns>
        public static bool GetEncodingText(string fileName, bool showMes, out Encoding encoding)
        {
            encoding = Encoding.Default;        	
        	try
            { 
        		var sr = new StreamReader(fileName, true);
		        encoding = sr.CurrentEncoding;
	     		return true;
		    }  catch (Exception ex)
            {
                if (showMes) sys.SM("Error retrieving file encoding " + fileName + Var.CR + ex.Message);
                return false; 
            }            
        }          
        
        /// <summary>
        /// Загрузка текстового файла в ResultText. В LinesCount количество строк в файле. 
        /// </summary>
        /// <param name="fileName">Полное имя файла с путём</param>
        /// <param name="showMes">Показывать сообщение об ошибке или нет</param>
        /// <param name="resultText">Текст из файла</param>
        /// <param name="linesCount">Количество строк в файле</param>
        /// <returns></returns>
        public static bool FileReadText(string fileName, bool showMes, out string resultText, out int linesCount)
        {  
            resultText = "";
            linesCount = -1;
            if (sys.ErrorCheck(!File.Exists(fileName), "File not found: " + fileName)) return false;
            if (!File.Exists(fileName)) 
            {
                if (showMes) sys.SM("File not found: " + fileName);
                return false; 
            }
            try
            {                              
				//Определение кодировки.
            	string encoding = string.Empty;			
				var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);       
				
				//Чтение файла.
		        using (var sr = new StreamReader(fs, true))
		        {
		        	resultText = sr.ReadToEnd();
		        	string[] lines = resultText.Split(new char[] { '\n' });
		        	linesCount = lines.Count();
		        }
				fs.Close();
            	//string[] lines = File.ReadAllLines(FileName, sr.CurrentEncoding);                
                //ResultText = string.Join(Var.CR, lines);                                                
                return true;
            }  catch (Exception ex)
            {
                if (showMes) sys.SM("Error opening file " + fileName + Var.CR + ex.Message);
                return false; 
            }            
        }     
        
        /// <summary>
        /// Загрузка текста в переменную string.
        /// </summary>
        /// <param name="fileName">Полное имя файла с путём</param>
        /// <returns>Текст из файла</returns>
        public static string FileReadTextSimple(string fileName)
        {                          
            int linesCount = 0;
            string outText = "";             
            if (!FileReadText(fileName, Var.ShowMes, out outText, out linesCount)) return "";
            return outText;
        }                       

		/// <summary>
		/// Получить файл в виде Base64. Если SaveHashToEndFile, то в конец файла будет добавлен MD5 файла (32 байта). 
		/// </summary>
		/// <param name="fileName">Исходный произвольный файл</param>
		/// <param name="saveHashToEndFile">Записывать или нет в конец файла хеш MD5</param>
		/// <param name="fileData">Файл в виде строки Base64</param>
		/// <param name="hashMD5">Вычисленный Хеш MD5</param>
		/// <returns>Если успешно,то true</returns>
        public static bool FileGetBase64WithHashMD5(string fileName, bool saveHashToEndFile, out string fileData, out string hashMD5)           
        {   
            fileData = "";
            hashMD5  = "";
            if (saveHashToEndFile)
            {
               hashMD5 = Crypto.FileHashMD5Calc(fileName); //Получить HashMD5 файла. 
               if (hashMD5 == "") return false;  //2A8934426900E51218310E643C4062AB
               if (!Crypto.FileHashMD5Write(fileName, hashMD5)) return false;
            }   
            string errorMes;    
            if (!FileReadToBase64(fileName, out fileData, out errorMes, true)) return false;
            return true;
        }             
                                    
        /// <summary>
        /// Преобразование строки FileData в Base64, затем запись на диск в файл FileName.
        /// </summary>
        /// <param name="fileData">Исходный файл в виде строки Base64</param>
        /// <param name="fileName">Имя файла, куда сохраняем</param>
        /// <param name="errorMes">Текст ошибки, если возникла</param>
        /// <param name="showMes">Показывать или нет сообщение об ошибке</param>
        /// <returns>Если успешно,то true</returns>
        public static bool FileWriteFromBase64(string fileData, string fileName, out string errorMes, bool showMes)
        {
            errorMes = "";
            try
            {            //FileAccess.Read, FileShare.ReadWrite
                var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                byte[] newBytes = Convert.FromBase64String(fileData);
                fs.Write(newBytes, 0, newBytes.Length);                 
                fs.Close();                                
                return true;
            } catch (Exception e)
            {            
                errorMes = "Error writing file to disk: " + fileName + Var.CR + e.Message;
                if (showMes) sys.SM(errorMes);
                return false;            
            }                
        }
                
        /// <summary>
        /// Чтение файла, затем преобразование её в формат Base64. На выходе строка Base64.
        /// </summary>
        /// <param name="fileName">Имя файла, куда сохраняем</param>
        /// <param name="fileData">Файл в виде строки Base64</param>
        /// <param name="errorMes">Текст ошибки, если возникла</param>
        /// <param name="showMes">Показывать или нет сообщение об ошибке</param>
        /// <returns>Если успешно,то true</returns>
        public static bool FileReadToBase64(string fileName, out string fileData, out string errorMes, bool showMes)
        {
            errorMes = "";
            try
            {
                FileStream fs = null;
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);  //открываем файл
                var fileBuffer = new byte[fs.Length];
                fs.Read(fileBuffer, 0, (int)fs.Length); //читаем в бинарный буфер
                fs.Close();                   
                fileData = Convert.ToBase64String(fileBuffer);
                return true;
            } catch (Exception e)
            {            
                fileData = "";
                errorMes = "Error reading file: " + fileName + Var.CR + e.Message;
                if (showMes) sys.SM(errorMes);                
                return false;            
            }
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
            	if (showMes) sys.SM("Error deleting file " + fileName + ": " +  ex.Message);
                return false;
            }           
        }
        
        /// <summary>
        /// Переименовать все файлы, заменив OldInputStr на NewInputStr,
        /// а также заменив внутри файлов содержимое.
        /// </summary>
        /// <param name="dirName">Папка, в которой производим изменения</param>
        /// <param name="oldInputStr">Строка, которую нужно заменить в именах файлов и в их содержимом</param>
        /// <param name="newInputStr">Строка, на которую нужно заменить</param>
        /// <returns>Если успешно, то true</returns>
        public static bool RenameFilesInDir(string dirName, string oldInputStr, string newInputStr)
        {
             string[] listFiles = FileFind(dirName, "*.*", true);
             string errorMes;
             int result = 0;
             for (int i = 0; i < listFiles.Count(); i++)
             {
                 if (!FileReplaceText(listFiles[i], oldInputStr, newInputStr)) result++;
                 string fileNameFull = listFiles[i];
                 string fileName = System.IO.Path.GetFileName(fileNameFull);
                 string filePath = System.IO.Path.GetDirectoryName(fileNameFull);
                 //MessageBox.Show(System.IO.Path.GetFileName(FileNameFull)); //Имя файла
                 //MessageBox.Show(System.IO.Path.GetDirectoryName(FileNameFull)); //Путь до файла               
                 string fileDestination = filePath + @"\" + fileName.Replace(oldInputStr, newInputStr);                              
                 if (!FileRename(listFiles[i], fileDestination, FileOverwrite.Skip, true, out errorMes)) result++;
             }
             return (result == 0);
        }
               
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
        	    if (DirExists(dirName))
                    Directory.Delete(dirName, true); //true - удаляем все (файлы и папки) что внутри папки.
                return true;
            }         	
        	catch (Exception ex)
            {
            	errorMes = ex.Message;
            	if (showMes) sys.SM("Error deleting folder " + dirName + ": " +  errorMes + Var.CR + ex.Message);
                return false;
            } 
        }
               
		/// <summary>
		/// Удаление из папки всех вложенных папок и файлов. Сама папка DirName не удаляется.  
		/// </summary>
		/// <param name="dirName">Исходная папка</param>
		/// <param name="listNotDeleted">Список не удалённых файлов и папок</param>
		/// <param name="showMes">Показывать сообщение об ошибке или нет</param>
		/// <returns>Если успешно, то true</returns>
		public static bool DirClean(string dirName, out string[] listNotDeleted, bool showMes)
        {                    	 
            string errorMes = "";
            listNotDeleted = null;
            if (!DirExists(dirName)) return true;
            //Рекурсия не используется.
        	//На самом деле для удаления папки и всех вложенных папок и файлов можно написать Directory.Delete(DirName, true);
            //Но нам нужен список ошибок, и удаление всего что удаляется. Кроме того саму папку DirName удалять не нужно.        	   
        	var listError = new List<string>();
            string[] di = Directory.GetDirectories(dirName, "*", SearchOption.AllDirectories);              
            string[] fi = Directory.GetFiles(dirName, "*.*", SearchOption.AllDirectories);                                            
            //удаление всех файлов.
            foreach (string fileName in fi)
            {            	
            	if (!FileDelete(fileName, out errorMes, false)) listError.Add("FileName: " + fileName);
            }                
            //Удаление всех папок.               
            for (int i = di.Length-1; i > -1; i--)
            {               
                string dirName2 = di[i];
                if (!DirDelete(dirName2, out errorMes, false)) listError.Add("Folder: " + dirName2);
            }
            
            if (listError.Count > 0)
            {     
            	listNotDeleted = listError.ToArray();
            	string listNotDeletedStr = string.Join(Var.CR, listNotDeleted);
            	if (showMes) sys.SM("Errors occurred while deleting: " + Var.CR + listNotDeletedStr);
            	return false;
            }
            return true;                           
        }         
 		
 		/// <summary>
 		/// Копирование папки вместе с вложенными файлами и папками. 
 		/// </summary>
 		/// <param name="dirSource">Исходная папка</param>
 		/// <param name="dirDestination">Имя новой папки</param>
 		/// <param name="showMess">Показывать ошибки или нет</param>
 		/// <returns>Если успешно, то true</returns>
        public static bool DirCopy(string dirSource, string dirDestination, bool showMess)
        {
            try
            {                           
                Directory.CreateDirectory(dirDestination);
                foreach (string s1 in Directory.GetFiles(dirSource))
                {
                    string s2 = dirDestination + "\\" + Path.GetFileName(s1);
                    File.Copy(s1,s2);
                }
                foreach (string s in Directory.GetDirectories(dirSource))
                {
                    DirCopy(s, dirDestination + "\\" + Path.GetFileName(s), showMess);
                }
            }
            catch (Exception ex)
            {                    
            	if (showMess) sys.SM("Error copying folder: " + dirSource + Var.CR + dirDestination + Var.CR + ex.Message);
            	return false; //throw;
            }
            return true;
        }                      
               
        /// <summary>
        /// Выбор папки.
        /// </summary>
        /// <param name="initialDirectory">Начальная папка выбора папки</param>
        /// <param name="dirName">Путь к выбранной папке</param>
        /// <returns>Если успешно, то true</returns>
        public static bool DirChoose(string initialDirectory, out string dirName)
		{
        	dirName = "";
        	if (initialDirectory == "") initialDirectory = Application.StartupPath;
        	//sys.PathMain;
            var dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            dlg.SelectedPath = initialDirectory; //@"E:\Vetcentric";        	   
        	if (dlg.ShowDialog() == DialogResult.OK)
        	{
        		dirName = dlg.SelectedPath;
        		return true;
        	}		    	
        	return  false;
		}
                                    
        ///Operation = ZIP, UNZIP
        public static bool DirZIP(bool ZIP, string DirSource, string DirDestination)
        {               
            if (ZIP)
            {
                //DotNetZip
                //ZipFile.                
                var zip = new Ionic.Zip.ZipFile();              
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = Encoding.GetEncoding(866);    
                zip.AddDirectory(DirSource); //zip.AddFile("ReadMe.txt");               
                zip.Save(DirDestination);  
            } else                                                   
            {
                Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(DirSource);
                zip.ExtractAll(DirDestination, ExtractExistingFileAction.OverwriteSilently);   
            }
            return true;          
        }


        /// <summary>
        /// Размер файла для вывода пользователю.
        /// </summary>
        /// <param name="sizeByte">Размер файла в байтах</param>
        /// <param name="kbOnly">Выводить размер только в кб. Иначе будут испрользованы Гб, Мгб, Кб.</param>
        /// <param name="AddWords">Если true, то добавляются Кб, Мб, Гб</param>
        /// <returns></returns>
        public static string GetFileSizeStr(long sizeByte, bool kbOnly, bool AddWords)
        {
            string value = "";
            if (kbOnly)
            {
                value = (sizeByte / 1024).ToString();
                if (AddWords) value += " Kb";
                return value;
            }
            const decimal gbdiv = 1073741824; //1024*1024*1024
            const decimal mbdiv = 1048576;    //1024*1024
            decimal gb = (sizeByte / gbdiv);
            decimal mb = (sizeByte / mbdiv);
            long kb = (sizeByte / 1024);
            if (gb > 1)
            {
                value = sys.RoundUp(gb, 2).ToString();
                if (AddWords) value += " Gb";
                return value;
            }

            if (mb > 1)
            {
                value = sys.RoundUp(mb, 2).ToString() + " Mb";
                if (AddWords) value += " Gb";
                return value;
            }

            if (kb > 1)
            {
                value = kb.ToString();
                if (AddWords) value += " Kb";
                return value;
            }

            if (kb > 0)
            {
                value = "1";
                if (AddWords) value += " Kb";
                return value;
            }

            value = "0";
            if (AddWords) value += " Kb";
            return value;
        }
       
        /// <summary>
        /// Проверка существования папки и её создание если её нет.
        /// </summary>
        /// <param name="dirName">Папка, которую проверяем</param>
        /// <param name="createIfNotExists">Создавать папку, елси не найдена</param>
        /// <returns>Если успешно, то true</returns>
        public static bool DirExists(string dirName, bool createIfNotExists = false)
        {                          
            if(!Directory.Exists(dirName))                          
            try
            {
                if (createIfNotExists) Directory.CreateDirectory(dirName);
            } catch (Exception ex)
            {
                sys.SM("Error creating folder: " + dirName + Var.CR + ex.Message);
                return false;
            } 
            return Directory.Exists(dirName);
        }          
               
        /// <summary>
        /// Распаковка или запаковка файла
        /// </summary>
        /// <param name="zip">Если true, то ZIP иначе UNZIP</param>
        /// <param name="fileSource">Исходный файл</param>
        /// <param name="fileDestination">Куда распакоываем или запаковываем</param>
        /// <param name="showMes">Показывать ошибки или нет</param>
        /// <returns>Если успешно, то true</returns>
        public static bool FileZIP(bool zip, string fileSource, string fileDestination, bool showMes)
        {      
            if (zip)
            {
                var zipfile = new Ionic.Zip.ZipFile();                  
                zipfile.AlternateEncodingUsage = ZipOption.Always;
                zipfile.AlternateEncoding = Encoding.GetEncoding(866);    
                zipfile.AddFile(fileSource); //zip.AddFile("ReadMe.txt");               
                zipfile.Save(fileDestination);  
            } else
            {            
               ExtractExistingFileAction t;
               if (!showMes) t = ExtractExistingFileAction.OverwriteSilently;
               else
               {
                   if (File.Exists(fileDestination)) 
                       if (sys.SM("File already exists: " + fileDestination + " Overwrite?", MessageType.Question, "Unpack ZIP archive") == false) return false;
                   t = ExtractExistingFileAction.OverwriteSilently;                
               }
                
                var zipfile = new ZipFile();
                zipfile.ExtractAll(fileDestination, t);                
            }
            return true;              
        }
            
        /// <summary>
        /// Замена текста в файле.
        /// </summary>
        /// <param name="fileName">Имя файла, в котром нужно поменять текст</param>
        /// <param name="oldText">Текст, который меняем</param>
        /// <param name="newText">Текст, на котрый меняем</param>
        /// <returns>Если успешно, то true </returns>
        public static bool FileReplaceText(string fileName, string oldText, string newText)
        {           
            try
            {
                string str = string.Empty;
                using (System.IO.StreamReader reader = System.IO.File.OpenText(fileName))
                {
                    str = reader.ReadToEnd();
                }
                str = str.Replace(oldText, newText);            
              
                using (var file = new System.IO.StreamWriter(fileName))
                {
                    file.Write(str);
                } 
                return true;
            }  catch (Exception ex)
            {
                sys.SM("Error replacing text in file: " + fileName + Var.CR + ex.Message);
                return false;
            }
                
        }
       
        /// <summary>
        /// Cписок имен папок в массив.
        /// </summary>
        /// <param name="dirSource">Папка, в которой искать папки</param>
        /// <returns>Список имен папок</returns>
        public static string[] GetDirs(string dirSource)
        {            
            var s = Directory.EnumerateDirectories(dirSource, "*", SearchOption.AllDirectories);
            var s1 = new string[s.Count()];
            int i = 0;
            foreach (string dir1 in s)
            {
                s1[i] = dir1;
                i++;
            }
            return s1; 
        }

		/// <summary>
		/// Загрузка cписка имен файлов в ListBox.
        /// Пример вызова: ListBox1.LBLoadFiles(@"C:\", "*.txt", "aaa", "bbb", false, true, true); 
        /// В ListBox попадут все файлы с расширением txt, в имени которомуых есть подстрока aaa и нет подстроки bbb.
        /// В списке будут имена файлов без пути и расширения.      
        /// Если нужно несколько разных значений "aaa" или "bbb", то нужно указывать их через точку с запятой.
        /// Сама точка с запятой в логике не участвует, её экранирование пока не сделано.       
		/// </summary>
		/// <param name="lb">Объект ListBox</param>
		/// <param name="dirSource">Исходная папка</param>
		/// <param name="fileSearchPattern">Маска файлов. Несколько масок не поддерживаются. Несколько масок можно указать в StringExists. Пример: ".bmp;.jpg;.jpeg"
        /// Но если в менах файлов будет эти подстроки, то в результат они попадут.</param>
        /// <param name="stringExists">Включать в результат файлы, в именах которых содержится StringExists. Допустимо указывать несколько подстрок через точку с запятой. Пример: StringExists = "dis;not;gffgfg"</param>
        /// <param name="stringNotExists">НЕ включать в результат файлы, в именах которых содержится StringNotExists. Допустимо указывать несколько подстрок через точку с запятой.</param>
        /// <param name="subDirectories">искать в подпапках</param>
        /// <param name="showPath">Добавлять полный путь к файлу</param>
        /// <param name="showExtension">Добавлять расширения файлов</param>       
        public static void ListBoxLoadFiles(ListBox lb, 
                                       string dirSource, 
                                       string fileSearchPattern,
                                       string stringExists,
                                       string stringNotExists,
                                       bool subDirectories, 
                                       bool showPath, 
                                       bool showExtension)
        {           
          
            	
        	//ListBox1.DataSource = Directory.GetFiles(sys.PathSetings, "*.txt", SearchOption.TopDirectoryOnly);
            var dir = new DirectoryInfo(dirSource);
            SearchOption so; 
            if (subDirectories) so = SearchOption.AllDirectories;
              else so = SearchOption.TopDirectoryOnly;
            FileInfo[] files = dir.GetFiles(fileSearchPattern, so);
            foreach (FileInfo fi in files) 
            {
                string fileName = fi.ToString();                                
                string[] StringExists1 = stringExists.Split(';');
                for (int i = 0; i < StringExists1.Count(); i++)
                    if ((!sys.IsEmpty(StringExists1[i])) && (fileName.IndexOfBool(StringExists1[i]))) continue;

                string[] stringNotExists1 = stringNotExists.Split(';');
                for (int i = 0; i < stringNotExists1.Count(); i++)
                    if ((!sys.IsEmpty(stringNotExists1[i])) && (fileName.IndexOfBool(stringNotExists1[i]))) continue;
                if (showPath)      fileName = fi.Directory + @"\" + fileName;
                if (!showExtension) fileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                lb.Items.Add(fileName);
                
            }                     
        }

        /// <summary>
        /// Простая загрузка cписка имен файлов в массив.
        /// Пример вызова:
        /// string[] s = sys.FilesInFolder(@"E:\Мусор\", "*.*", "", "", true, true, true);
        /// sys.ArrayView("", "", s);
        /// </summary>
        /// <param name="dirSource">Папка, в которой искать файлы</param>
        /// <param name="searchPattern">Маска файлов. Несколько масок не поддерживаются. Несколько масок можно указать в StringExists. Пример: ".bmp;.jpg;.jpeg"
        /// Но если в менах файлов будет эти подстроки, то в результат они попадут.</param>
        /// <param name="stringExists">Включать в результат файлы, в именах которых содержится StringExists. Допустимо указывать несколько подстрок через точку с запятой. Пример: StringExists = "dis;not;gffgfg"</param>
        /// <param name="stringNotExists">НЕ включать в результат файлы, в именах которых содержится StringNotExists. Допустимо указывать несколько подстрок через точку с запятой.</param>
        /// <param name="subDirectories">искать в подпапках</param>
        /// <param name="showPath">Добавлять полный путь к файлу</param>
        /// <param name="showExtension">Добавлять расширения файлов</param>
        /// <returns>Список имен файлов</returns>
        public static string[] FilesInFolder(
                                       string dirSource,
                                       string searchPattern,
                                       string stringExists,
                                       string stringNotExists,
                                       bool subDirectories,
                                       bool showPath,
                                       bool showExtension)
        {
            var dir = new DirectoryInfo(dirSource);
            SearchOption so;
            if (subDirectories) so = SearchOption.AllDirectories;
            else so = SearchOption.TopDirectoryOnly;
            FileInfo[] files = dir.GetFiles(searchPattern, so);
            var arrStr = new StringBuilder();
            foreach (FileInfo fi in files)
            {                
                string fileName = fi.ToString();                
                string[] stringExists1 = stringExists.Split(';');
                for (int i = 0; i < stringExists1.Count(); i++)
                    if ((!sys.IsEmpty(stringExists1[i])) && (fileName.IndexOfBool(stringExists1[i]))) continue;

                string[] stringNotExists1 = stringNotExists.Split(';');
                for (int i = 0; i < stringNotExists1.Count(); i++)
                    if ((!sys.IsEmpty(stringNotExists1[i])) && (fileName.IndexOfBool(stringNotExists1[i]))) continue;
                
                if (showPath) fileName = fi.Directory + @"\" + fileName;
                if (!showExtension) fileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                arrStr.Append(fileName + '\n');           
            }        
            return arrStr.ToString().Split('\n');                   
        }

        
        
        /// <summary>
        /// Список всех папок в папке dirSource.
        /// </summary>
        /// <param name="dirSource">Исходная папка, в которой нужно получить список всех папок</param>
        /// <param name="searchPattern">Маска поиска, по умолчанию *</param>
        /// <param name="stringExists">Включать в результат файлы, в именах которых содержится StringExists. Допустимо указывать несколько подстрок через точку с запятой. Пример: StringExists = "dis;not;gffgfg"</param>
        /// <param name="stringNotExists">НЕ включать в результат файлы, в именах которых содержится StringNotExists. Допустимо указывать несколько подстрок через точку с запятой.</param>       
        /// <param name="subDirectories">Искать в подпапках</param>
        /// <param name="showPath">Добавлять полный путь к файлу</param>
        /// <returns>Список всех папок в папке dirSource.</returns>
        public static string[] FoldersInFolder(
                                       string dirSource, 
									   string searchPattern,	                                       
                                       string stringExists,
                                       string stringNotExists,
                                       bool subDirectories,
                                       bool showPath)
        {                	        	        	       
        	var dir = new DirectoryInfo(dirSource);
            SearchOption so;
            if (subDirectories) so = SearchOption.AllDirectories;
            else so = SearchOption.TopDirectoryOnly;
            if (string.IsNullOrEmpty(searchPattern)) searchPattern = "*";
            DirectoryInfo[] dirs = dir.GetDirectories(searchPattern, so);
            var arrStr = new StringBuilder();   
            foreach (DirectoryInfo di in dirs)
            {                
                string dirName = di.ToString();                
                string[] stringExists1 = stringExists.Split(';');
                for (int i = 0; i < stringExists1.Count(); i++)
                    if ((!sys.IsEmpty(stringExists1[i])) && (dirName.IndexOfBool(stringExists1[i]))) continue;
                string[] stringNotExists1 = stringNotExists.Split(';');
                for (int i = 0; i < stringNotExists1.Count(); i++)
                    if ((!sys.IsEmpty(stringNotExists1[i])) && (dirName.IndexOfBool(stringNotExists1[i]))) continue;                
                
                if (showPath) dirName = di.FullName;
                arrStr.Append(dirName + '\n');
            }        
            return arrStr.ToString().Split('\n');                   
        }
       
       

        
        #endregion
                
    }	   
}
