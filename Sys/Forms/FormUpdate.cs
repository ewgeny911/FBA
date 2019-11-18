
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 28.09.2017
 * Время: 18:31
 */
 
using System;  
using System.Linq;        
using System.Windows.Forms.VisualStyles;
using FastColoredTextBoxNS;       
using System.Windows.Forms;
using System.IO;
using System.Data;     
using System.Collections.Generic;   
namespace FBA
{     
	/// <summary>
	/// Форма для обновления программы
	/// </summary>
	public partial class FormUpdate : FormFBA
    {
        System.Data.DataTable dt = new System.Data.DataTable(); 
        
		/// <summary>
		/// Контруктор
		/// </summary>
		public FormUpdate()
        {             
            InitializeComponent();           
            this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;                              
        }
		
		/// <summary>
        /// Показать в таблице все файлы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void TlbNewFilesClick(object sender, EventArgs e)
		{							    
            //Вкладка показа обновления
			//Показывает список доступных обновлений.
	        if (sender == tlbShowUpdate)
	        {
				UpdateListUpdates();
	        	sys.RefreshGrid(DirectionQuery.Remote, dgvFiles, "");
	        }	        
	        if (sender == tlbDeleteUpdate) 
	        {	        	
        		string version = dgvUpdate.Value("Version");
        		DeleteUpdate(version);
	        }
	        if (sender == tlbDeleteFile)
	        {
	        	string version = dt.Value("Version");
	        	string fileName = dt.Value("FileName");
	        	DeleteUpdateFile(version, fileName);
	        };
	        
	        //Вкладка нового обновления
			if (sender == tlbNewFiles) GetNewFiles();
			if (sender == tlbNewUpload) UploadNewUpdate();
			if (sender == tlbCheck)    CheckFiles(true);
			if (sender == tlbUnCheck)  CheckFiles(false);
		}
		        
        /// <summary>
        /// Показывает список доступных обновлений.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
		private bool UpdateListUpdates()
        {                     
            const string sql = "SELECT NumberUpdate, Version, CurrentVersion, Count(ID) as FileCount, (SUM(Size)/ 1024) AS 'FileSize, kb'" +
                         "FROM fbaUpdate group by NumberUpdate, Version, CurrentVersion; ";
            return sys.RefreshGrid(DirectionQuery.Remote, dgvUpdate, sql);                 
        }
           
        /// <summary>
        /// Показывает список файлов выбранного обновления.
        /// </summary>
        /// <returns></returns>
        private bool UpdateListFiles()
        {
        	string numberUpdate = dgvUpdate.Value("NumberUpdate", true); 
        	if (string.IsNullOrEmpty(numberUpdate)) return true;
            //Показывает список файлов обновлений.                      
            string sql = "SELECT NumberFile, NumberUpdate, DateRecord, UserUpdate, " +
                         "ContentType, Operation, Version, CurrentVersion, FullName, " +
                         "Path, Name, Extension, CreationTime, LastWriteTime, LastAccessTime, Size, " +
                         "MD5 FROM fbaUpdate WHERE NumberUpdate = " + numberUpdate + "; ";                               
            return sys.RefreshGrid(DirectionQuery.Remote, dgvFiles, sql);            
        }               
		
        /// <summary>
        /// Клик на гриде слева - выбор обновления.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvUpdateClick(object sender, EventArgs e)
		{
			UpdateListFiles();
		}
        
        /// <summary>
        /// Получить номер последнего обновления
        /// </summary>
        /// <returns></returns>
        private int GetLastUpdate()
        {
        	const string sql = "SELECT MAX(NumberUpdate) AS NumberVersion FROM fbaUpdate; ";
            string NumberUpdateStr = sys.GetValue(DirectionQuery.Remote, sql);
            if (NumberUpdateStr == "") NumberUpdateStr = "0";
            return NumberUpdateStr.ToInt() ; 
        }                  		
        
        /// <summary>
        /// Список новых файлов
        /// </summary>
		private void GetNewFiles()
        {                      	        	 
			if (!GetFilesFBA()) return;
			dgNewFiles.SetDataSource(dt);
			dgNewFiles.Columns[0].Width = 100;
			dgNewFiles.Columns[1].Width = 100;	
			dgNewFiles.Columns[2].Width = 100;	
			dgNewFiles.Columns[3].Width = 100;	
			dgNewFiles.Columns[4].Width = 100;	
		}
		
        /// <summary>
        /// Получить список файлов решения
        /// </summary>   
        /// <returns></returns>
        private bool GetFilesFBA()
        {                      	        	
        	//Последняя версия в таблице обновлений.
            int numberUpdate = GetLastUpdate() + 1; //Новая версия.
            if (dt.Columns.Count == 0)
            {
	            dt.Columns.Add("NumberFile");     //Порядковый номер файла или папки в обновлении
	            dt.Columns.Add("NumberUpdate");   //Порядковый номер обновления.          
	            dt.Columns.Add("Version");        //Версия программы вида 1.0.6335.33362
	            dt.Columns.Add("FullName");       //Полное имя файла с путем.
	            dt.Columns.Add("Path");           //Начальный каталог программы, т.е. sys.PathMain
	            dt.Columns.Add("Name");           //Имя файла/папки
	            dt.Columns.Add("Extension");      //Расширение файла (для папки здесь пусто)
	            dt.Columns.Add("CreationTime");   //Дата создания папки/файла
	            dt.Columns.Add("LastWriteTime"); 
	            dt.Columns.Add("LastAccessTime");
	            dt.Columns.Add("Size");           //размер файла в байтах. Для папки здесь 0.
	            dt.Columns.Add("MD5");            //Хеш MD5                          
	        }
            dt.Rows.Clear();
            string[] contentList = FBAFile.FilesInFolder(FBAPath.PathDebug, "*.*", "", "", true, true, true); ;

            //Для вставки полей в DT.
            string numberFile = "";            
            string dateRecord     = sys.DateTimeToSQLStr(DateTime.Now);           
            string version        = Var.ApplicationVersion;
            string fullName       = "";     
            string filePath       = "";
            string fileName       = "";
            string extension      = ""; 
            string creationTime   = "";
            string lastWriteTime  = "";
            string lastAccessTime = "";
            long SizeFile;
            string hashMD5;
            
            var progress1 = new FormProgress("Обновление", "Получение свойств файлов", contentList.Length);
            progress1.Show();
			
			var fileprop = new string[dt.Columns.Count];
            for (int i = 0; i < contentList.Length; i++)
            {
                try 
				{
	            	fullName = contentList[i];
	            	if (string.IsNullOrEmpty(fullName)) continue;
	            	if (!File.Exists(fullName)) continue;
	                var file       = new FileInfo(fullName);	
	                filePath 	   = file.DirectoryName;
	                fileName       = file.Name;
	                numberFile     = (i + 1).ToString();             
	                extension      = file.Extension;
	                creationTime   = sys.DateTimeToSQLStr(file.CreationTime);
	                lastWriteTime  = sys.DateTimeToSQLStr(file.LastWriteTime);
	                lastAccessTime = sys.DateTimeToSQLStr(file.LastAccessTime);
	                SizeFile       = file.Length;
	                hashMD5        = Crypto.FileHashMD5Calc(fullName);
	             
	                fileprop[0]  = numberFile;
	                fileprop[1]  = numberUpdate.ToString();	
	                fileprop[2]  = version;
	                fileprop[3]  = fullName;
	                fileprop[4]  = filePath;;
	                fileprop[5]  = fileName;
	                fileprop[6] = extension;
	                fileprop[7] = creationTime;
	                fileprop[8] = lastWriteTime;
	                fileprop[9] = lastAccessTime;
	                fileprop[10] = SizeFile.ToString();
	                fileprop[11] = hashMD5;
	
	                DataRow row = dt.NewRow();
	                row.ItemArray = fileprop;
	                dt.Rows.Add(row);
	                progress1.Inc();
                } catch (Exception ex) 
				{
					sys.SM("File Number " + numberFile + Var.CR + "File name: " + fullName + Var.CR + ex.Message);
					continue;
				} 
            }  				           
            const bool ff = true;
            Type tp = ff.GetType();
            dt.Columns.Add("Check", tp);      //Выбрать файл для заливки
            dt.Columns["Check"].SetOrdinal(0);
           
            CheckFiles(false);
            //dt.Columns[0].DataType = tp;
            progress1.Close();
            return true;        
        }
                
        /// <summary>
        /// Отметить файлы/снять отметку со всех файлов.
        /// </summary>
        /// <param name="check"></param>
        private void CheckFiles(bool check)
		{
        	for (int i = 0; i < dt.Rows.Count; i++)
            {
            	dt.Rows[i][0] = check;
            }
        }
        
        /// <summary>
        /// Проверить необходимость обновления.
        /// </summary>
        private void UpdateCheck()
        {            
            string version;
            string numberUpdate;
            string resultMessage;         
            const bool showMes = true;
            SysUpdate.UpdateCheck(out version, out numberUpdate, out resultMessage, showMes);
        }                                        
        
        /// <summary>
        /// Удаление обновления.
        /// </summary>
        /// <param name="version">Версия программы</param>
        /// <returns>Если успешно, то true</returns>
        private bool DeleteUpdate(string version)
        {        	        
        	string updateID = sys.GetValue(DirectionQuery.Remote, "SELECT ID FROM fbaUpdate WHERE Version = '" + version + "';");
        	string sql = "DELETE FROM fbaUpdate WHERE ID = " + updateID + ";" + Var.CR +
                         "DELETE FROM fbaUpdateFiles WHERE UpdateID = " + updateID + "; ";
        	return sys.Exec(DirectionQuery.Remote, sql);
        }
        
        /// <summary>
        /// Удаление обновления.
        /// </summary>
        /// <param name="version">Версия программы</param>
        /// <param name="fileName">Имя файла обновления</param>
        /// <returns>Если успешно, то true</returns>
        private bool DeleteUpdateFile(string version, string fileName)
        {        	                	
        	string sql = "DELETE FROM fbaUpdateFiles WHERE FileName = '" + fileName + 
        		        "' AND UpdateID = (SELECT ID FROM fbaUpdate WHERE Version = '" + version + "';";
        	return sys.Exec(DirectionQuery.Remote, sql);
        }
        
		/// <summary>
		/// Загрузка обновления на сервер.
		/// </summary>
		/// <returns></returns>
        private bool UploadNewUpdate()
        {        	        	
        	string version = dt.Value("Version");
        	if (!DeleteUpdate(version)) return false;
            string fileName = "";
            string sql = "";
            var progress1 = new FormProgress("Обновление", "Загрузка файлов обновления на сервер", dt.Rows.Count);
            progress1.Show();
          	
          	for (int i = 0; i < dt.Rows.Count; i++)
            {
            	try 
          		{
	          	 	string fullName =  dt.Value(i, "FullName");
	            	if (!File.Exists(fullName)) continue;            	         
	                string fileData;              
	                string errorMes;
	                const bool showMes = true;
	                bool check   = dt.Value(i, 0).ToBool();
	                if (!check) continue;
	                string numberFile     = progress1.Progress.ToString();
	                string numberUpdate   = dt.Value(i, "NumberUpdate");
	                string dateRecord     = sys.GetDateTimeNow();
	                string userUpdate     = Var.UserID.ToString();
	                const string contentType    = "";
	                const string operation      = "";
	                string path           = dt.Value(i, "Path");
	                fileName              = dt.Value(i, "Name");
	                string extension      = dt.Value(i, "Extension");
	                string creationTime   = dt.Value(i, "CreationTime"); 
	                string lastWriteTime  = dt.Value(i, "LastWriteTime"); 
	                string lastAccessTime = dt.Value(i, "LastAccessTime");
	                string sizeFile       = dt.Value(i, "Size");
	                string hashMD5        = dt.Value(i, "MD5");
	                if (!FBAFile.FileReadToBase64(fullName, out fileData, out errorMes, showMes)) return false;
	                   
	                sql = @"INSERT INTO fbaUpdate (NumberFile, NumberUpdate, DateRecord, UserUpdate, " +
	                           "ContentType, Operation, Version, CurrentVersion, FullName, Path, Name, Extension, " +
	                           "CreationTime, LastWriteTime, LastAccessTime, Size, MD5, " +
	                           "FileData) " +
	                           "VALUES (" +
	                           "'" + numberFile + "','" + numberUpdate + "','" + dateRecord + "','" + userUpdate + "'," +
	                           "'" + contentType + "','" + operation + "','" + version + "','" + version + "','" + fullName + "','" + path + "','" + fileName + "','" + extension + "'," +
	                        "'" + creationTime + "','" + lastWriteTime + "','" + lastAccessTime + "'," + sizeFile.ToString() + ", '" + hashMD5 + "'," +
	                           "'" + fileData + "'); " + Var.CR;
	                    if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
                } catch (Exception ex)
	          	{
	          		sys.SM("Ошибка загрузки файла обновления: " + Var.CR + fileName + Var.CR + ex.Message);
	          		
	          	}    
                progress1.Inc();
            }

            //В конце загрузки файлов на сервер обновляем информцию о текущей версии.          
            sql = @"UPDATE fbaUpdate SET CurrentVersion = '" + version + "'; " + Var.CR;
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;    
          	      		          		             
            progress1.Dispose();
            return true;
        }

		/// <summary>
		/// Сохранить все файлы программы на сервере. 
		/// </summary>
		/// <param name="uploadToServer"></param>
		/// <returns></returns>
        private bool UpdateUpload(bool uploadToServer)
        {
            bool doUserUpdate = false;
            if (uploadToServer)
            {
                if (!(sys.SM("Сохранить файлы программы на сервере для обновления?", MessageType.Question, "Загрузка обновления на сервер"))) return false;
                doUserUpdate = sys.SM("Это обновление для пользователей?", MessageType.Question, "Загрузка обновления на сервер");
            }
        
            string[] ContentList = FBAFile.FilesInFolder(FBAPath.PathDebug, "*.*", "", "", true, true, true); ;
            
            System.Data.DataTable DT;
            bool Result = UpdateUploadFiles(out DT, ContentList, doUserUpdate, uploadToServer);
            //dgvUpdate.SetDataSource(DT);
            
            
            
            
            if (uploadToServer) 
                sys.SM("Файлы программы загружены на сервер. Версия " + Var.ApplicationVersion, MessageType.Information, "Загрузка на сервер");
            return Result;           
        }

        
        ///Скачать обновление в папку Update.
        /// 
        
        private void UpdateDownload()
        {       
            string version;
            string numberUpdate;
            string resultMessage;
            bool needUpdate;               
            const bool showMes = true;                        
            if (!SysUpdate.UpdateCheck(out version, out numberUpdate, out resultMessage, showMes)) return;
                       
            if (SysUpdate.UpdateDownload(version, numberUpdate, out resultMessage, out needUpdate, false))                 
            {
                if (resultMessage != "") sys.SM(resultMessage);
                return;
            } 
            sys.SM(resultMessage, MessageType.Information);
        }         
                      
        
        //Показывает список доступных обновлений.
       
     
      
        
        
        //Сохранить все файлы программы на сервере.   
    //   //UserUpdate  - обновление доступно пользователям. 
            //Upload      - Загрузить файлы на сервер. 
            //ContentList - Cписок файлов и папок для обновления в определенном формате:
            //              ADDDIR:  CustomDorectoryName
            //              DELDIR:  CustomDorectoryName 
            //              ADDFILE: CustomFileName.txt          
            //              DELFILE: CustomFileName.txt 


            
            
            
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="contentList"></param>
		/// <param name="doUserUpdate"></param>
		/// <param name="uploadToServer"></param>
		/// <returns></returns>
        private bool UpdateUploadFiles(out System.Data.DataTable dt, string[] contentList, bool doUserUpdate, bool uploadToServer)
        {          
            dt = new System.Data.DataTable();
            string sql = "";

            //Для вставки полей в DT.
            string numberFile;
            int numberUpdate;
            string dateRecord = sys.DateTimeToSQLStr(DateTime.Now);        
            string userUpdate  = (!doUserUpdate).ToInt().ToString();
            string contentType = ""; 
            string operation   = ""; 
            string version     = Var.ApplicationVersion;
            string fullName    = "";
            string path        = FBAPath.PathMain;
            string fileName    = ""; 
            string extension   = ""; 
            string creationTime;
            string lastWriteTime;
            string lastAccessTime;
            long SizeFile;
            string hashMD5;
            string fileData = ""; //Данные в Base64.    

           

            //Последняя версия в таблице обновлений.
            sql = "SELECT MAX(NumberUpdate) AS NumberVersion FROM fbaUpdate; ";
            string NumberUpdateStr = sys.GetValue(DirectionQuery.Remote, sql);
            if (NumberUpdateStr == "") NumberUpdateStr = "0";
            numberUpdate = NumberUpdateStr.ToInt() + 1; //Новая варсия.
            bool ff = true;
            Type tp = ff.GetType();
            dt.Columns.Add("Check", tp);      //Выбрать файл для заливки
            dt.Columns.Add("NumberFile");     //Порядковый номер файла или папки в обновлении
            dt.Columns.Add("NumberUpdate");   //Порядковый номер обновления.
            dt.Columns.Add("DateRecord");     //Текущая дата.
            dt.Columns.Add("UserUpdate");     //true-Пользователям нужно обновляться из это обновления. false-не нужно. false-нужно для тестирования, для отложенного обновления и др.              
            dt.Columns.Add("ContentType");    //1-папка, 2-файл 
            dt.Columns.Add("Operation");      //1-создать, 2-удалить. 
            dt.Columns.Add("Version");        //Версия программы вида 1.0.6335.33362
            dt.Columns.Add("FullName");       //Полное имя файла с путем.
            dt.Columns.Add("Path");           //Начальный каталог программы, т.е. sys.PathMain
            dt.Columns.Add("Name");           //Имя файла/папки
            dt.Columns.Add("Extension");      //Расширение файла (для папки здесь пусто)
            dt.Columns.Add("CreationTime");   //Дата создания папки/файла
            dt.Columns.Add("LastWriteTime"); 
            dt.Columns.Add("LastAccessTime");
            dt.Columns.Add("Size");           //размер файла в байтах. Для папки здесь 0.
            dt.Columns.Add("MD5");            //Хеш MD5                          
                                              //DT.Columns.Add("FileData");    //Содержимое файла в кодировке Base64.
            
                                              
            sql = "DELETE FROM fbaUpdate WHERE Version = '" + version + "'; ";
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
          
            
            var fileprop = new string[16];
            var progress1 = new FormProgress("Обновление", "Получение свойств файлов", contentList.Length);
            progress1.Show();
            for (int i = 0; i < contentList.Length; i++)
            {
                fullName = contentList[i];   
                numberFile = (i + 1).ToString();
                                           
                if (!File.Exists(fileName)) continue;
                var file       = new FileInfo(fullName);
                fileName       = file.Name;
                extension      = file.Extension;
                creationTime   = sys.DateTimeToSQLStr(file.CreationTime);
                lastWriteTime  = sys.DateTimeToSQLStr(file.LastWriteTime);
                lastAccessTime = sys.DateTimeToSQLStr(file.LastAccessTime);
                SizeFile       = file.Length;
                hashMD5        = Crypto.FileHashMD5Calc(fullName);
                
                fileprop[0]  = numberFile;
                fileprop[1]  = numberUpdate.ToString();
                fileprop[2]  = dateRecord;
                fileprop[3]  = userUpdate;
                fileprop[4]  = ""; //ContentType.ToString();
                fileprop[5]  = ""; //Operation.ToString();
                fileprop[6]  = version;
                fileprop[7]  = fullName;
                fileprop[8]  = path;
                fileprop[9]  = fileName;
                fileprop[10] = extension;
                fileprop[11] = creationTime;
                fileprop[12] = lastWriteTime;
                fileprop[13] = lastAccessTime;
                fileprop[14] = SizeFile.ToString();
                fileprop[15] = hashMD5;

                DataRow row = dt.NewRow();
                row.ItemArray = fileprop;
                dt.Rows.Add(row);
                if (uploadToServer)
                {
                    fileData = "";              
                    string errorMes;
                    const bool showMes = true;
                    if (!FBAFile.FileReadToBase64(fullName, out fileData, out errorMes, showMes)) return false;
                                   
                    const bool saveHashToEndFile = false;
                    if (!FBAFile.FileGetBase64WithHashMD5(fileName, saveHashToEndFile, out fileData, out hashMD5)) return false;
           
                    sql = @"INSERT INTO fbaUpdate (NumberFile, NumberUpdate, DateRecord, UserUpdate, " +
                           "ContentType, Operation, Version, CurrentVersion, FullName, Path, Name, Extension, " +
                           "CreationTime, LastWriteTime, LastAccessTime, Size, MD5, " +
                           "FileData) " +
                           "VALUES (" +
                           "'" + numberFile + "','" + numberUpdate + "','" + dateRecord + "','" + userUpdate + "'," +
                           "'" + contentType + "','" + operation + "','" + version + "','" + version + "','" + fullName + "','" + path + "','" + fileName + "','" + extension + "'," +
                        "'" + creationTime + "','" + lastWriteTime + "','" + lastAccessTime + "'," + SizeFile.ToString() + ", '" + hashMD5 + "'," +
                           "'" + fileData + "'); " + Var.CR;
                    if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
                }
                progress1.Inc();
            }

            //В конце загрузки файлов на сервер обновляем информцию о текущей версии.
            if (uploadToServer)
            {
                sql = @"UPDATE fbaUpdate SET CurrentVersion = '" + version + "'; " + Var.CR;
                if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            }
            progress1.Dispose();
            return true;
        }
		
		
		
        
        
        /*
         ///Сохранить все файлы программы на сервере.    
         private bool UpdateUploadFiles(out System.Data.DataTable DT, string[] ContentList, bool DoUserUpdate, bool UploadToServer)
        {                                                                             
            //UserUpdate  - обновление доступно пользователям. 
            //Upload      - Загрузить файлы на сервер. 
            //ContentList - Cписок файлов и папок для обновления в определенном формате:
            //              ADDDIR:  CustomDorectoryName
            //              DELDIR:  CustomDorectoryName 
            //              ADDFILE: CustomFileName.txt          
            //              DELFILE: CustomFileName.txt 
            DT = new System.Data.DataTable();
            string SQL = "";    
            
            //Для вставки полей в DT.
            string NumberFile;
            int NumberUpdate;
            string DateRecord = sys.DateTimeToSQLStr(DateTime.Now);
            //string UserUpdate = (!DoUserUpdate).ToString();
            string UserUpdate = (!DoUserUpdate).ToInt().ToString();
            string ContentType;
            string Operation;             
            string Version    = Var.ApplicationVersion;
            string FullName;
            string Path = sys.PathMain;
            string FileName;
            string Extension;
            string CreationTime;
            string LastWriteTime;
            string LastAccessTime; 
            long SizeFile; 
            string HashMD5;                 
            string FileData   = ""; //Данные в Base64.    
            
            SQL = "DELETE FROM fbaUpdate WHERE Version = '" + Version + "'; ";
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;             
            Application.DoEvents();    
            
            //Последняя версия в таблице обновлений.
            SQL = "SELECT MAX(NumberUpdate) AS NumberVersion FROM fbaUpdate; ";          
            string NumberUpdateStr = sys.GetValue(DirectionQuery.Remote, SQL);
            if (NumberUpdateStr == "") NumberUpdateStr = "0";             
            NumberUpdate = NumberUpdateStr.ToInt() + 1; //Новая варсия.
                                      
            DT.Columns.Add("NumberFile");     //Порядковый номер файла или папки в обновлении
            DT.Columns.Add("NumberUpdate");   //Порядковый номер обновления.
            DT.Columns.Add("DateRecord");     //Текущая дата.
            DT.Columns.Add("UserUpdate");     //true-Пользователям нужно обновляться из это обновления. false-не нужно. false-нужно для тестирования, для отложенного обновления и др.              
            DT.Columns.Add("ContentType");    //1-папка, 2-файл 
            DT.Columns.Add("Operation");      //1-создать, 2-удалить. 
            DT.Columns.Add("Version");        //Версия программы вида 1.0.6335.33362
            DT.Columns.Add("FullName");       //Полное имя файла с путем.
            DT.Columns.Add("Path");           //Начальный каталог программы, т.е. sys.PathMain
            DT.Columns.Add("Name");           //Имя файла/папки
            DT.Columns.Add("Extension");      //Расширение файла (для папки здесь пусто)
            DT.Columns.Add("CreationTime");   //Дата создания папки/файла
            DT.Columns.Add("LastWriteTime"); 
            DT.Columns.Add("LastAccessTime");      
            DT.Columns.Add("Size");           //размер файла в байтах. Для папки здесь 0.
            DT.Columns.Add("MD5");            //Хеш MD5                          
             //DT.Columns.Add("FileData");    //Содержимое файла в кодировке Base64.
             
            var fileprop = new string[16];                
            var Progress1 = new FormProgress("Обновление", "Получение свойств файлов", ContentList.Length);
            Progress1.Show();                      
            for (int i = 0; i < ContentList.Length; i++)
            {                 
                FullName = ContentList[i];                                 
                if (FullName.IndexOf("DIR:", StringComparison.OrdinalIgnoreCase) > -1) ContentType = "DIR"; else ContentType = "FILE";                 
                Operation = FullName.Left(":"); //в sys этот Left описан.
                FullName = FullName.Replace("ADDDIR:",  "");
                FullName = FullName.Replace("DELDIR:",  "");
                FullName = FullName.Replace("ADDFILE:", "");
                FullName = FullName.Replace("DELFILE:", "");
                FullName = FullName.Trim();
                NumberFile     = (i+1).ToString();
                
                FileName           = "";
                Extension      = "";
                CreationTime   = sys.DateTimeToSQLStr(DateTime.Now);
                LastWriteTime  = sys.DateTimeToSQLStr(DateTime.Now);
                LastAccessTime = sys.DateTimeToSQLStr(DateTime.Now);
                SizeFile       = 0;
                HashMD5         = ""; 
                    
                if (Operation == "ADDFILE")
                {
                    if (!File.Exists(FileName)) continue;
                    var file       = new FileInfo(FullName);
                    FileName       = file.Name;
                    Extension      = file.Extension;
                    CreationTime   = sys.DateTimeToSQLStr(file.CreationTime);
                    LastWriteTime  = sys.DateTimeToSQLStr(file.LastWriteTime);
                    LastAccessTime = sys.DateTimeToSQLStr(file.LastAccessTime);
                    SizeFile       = file.Length;
                    HashMD5        = Crypto.FileHashMD5Calc(FullName);     
                }
                                 
                 fileprop[0]  = NumberFile;                     
                 fileprop[1]  = NumberUpdate.ToString();        
                 fileprop[2]  = DateRecord;                     
                 fileprop[3]  = UserUpdate;                      
                 fileprop[4]  = ContentType.ToString();         
                 fileprop[5]  = Operation.ToString();                                           
                 fileprop[6]  = Version;                       
                 fileprop[7]  = FullName;                        
                 fileprop[8]  = Path;                             
                 fileprop[9]  = FileName;                              
                 fileprop[10] = Extension;                        
                 fileprop[11] = CreationTime;                   
                 fileprop[12] = LastWriteTime;                  
                 fileprop[13] = LastAccessTime;                 
                 fileprop[14] = SizeFile.ToString();
                 fileprop[15] = HashMD5;                            
                                       
                 DataRow row = DT.NewRow();                                        
                row.ItemArray = fileprop;
                DT.Rows.Add(row);  
                if (UploadToServer)
                {                                             
                    FileData = "";
                    if (Operation == "ADDFILE")
                    {        //FileReadToBase64(string FileName, out string FileData, out string ErrorMes, bool ShowMes)
                        string ErrorMes;
                        bool ShowMes = true;
                        if (!sys.FileReadToBase64(FullName, out FileData, out ErrorMes, ShowMes)) return false;
                        //
                        
                        const bool SaveHashToEndFile = false;                           
                        if (!sys.FileGetBase64WithHashMD5(FileName, SaveHashToEndFile, out FileData, out HashMD5)) return false;
                    }
                       
                    SQL = @"INSERT INTO fbaUpdate (NumberFile, NumberUpdate, DateRecord, UserUpdate, " +
                           "ContentType, Operation, Version, CurrentVersion, FullName, Path, Name, Extension, " +
                           "CreationTime, LastWriteTime, LastAccessTime, Size, MD5, " +
                           "FileData) " +
                           "VALUES (" +
                           "'" + NumberFile + "','" + NumberUpdate + "','" + DateRecord + "','" + UserUpdate + "'," +                       
                           "'" + ContentType + "','" + Operation + "','" + Version + "','" + Version + "','" + FullName + "','" + Path + "','" + FileName + "','" + Extension + "'," +
                        "'" + CreationTime + "','" + LastWriteTime + "','" + LastAccessTime + "'," + SizeFile.ToString() + ", '" + HashMD5 + "'," +
                           "'" + FileData + "'); " + Var.CR;                        
                    if (!sys.Exec(DirectionQuery.Remote, SQL)) return false; 
                }
                Progress1.Inc();
            }                                                                                          
            
            //В конце загрузки файлов на сервер.
            if (UploadToServer)
            { 
                SQL = @"UPDATE fbaUpdate SET CurrentVersion = '" + Version + "'; " + Var.CR;
                if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;               
            }
            Progress1.Dispose();
            return true;                 
        } */

        //Событие. Удаление всех записей в таблице обновлений.    
        /*private void UpdateDelete()
        {          
            for (int i = 0; i < dgvUpdate.Rows.Count; i++)                             
            {                             
                string Version   = "";
                string UserCheck = "";  
                if (dgvUpdate.Rows[i].Cells["UserCheck"].Value != null)
                {
                    UserCheck   = sys.DataGridViewRowInt(dgvUpdate, i, "UserCheck");                             
                    Version     = sys.DataGridViewRowInt(dgvUpdate, i, "Version"); 
                }                          
                if ((UserCheck == "True") && (Version != ""))
                {
                     string SQL = @"DELETE FROM fbaUpdate WHERE Version = '" + Version + "';";  
                     sys.Exec(DirectionQuery.Remote, SQL);                      
                }                                                              
            }
            UpdateList();
            sys.SM("Выполнено!", MessageType.Information);  
            
        }
        
        ///Событие. Как только пользователь вносит изменение в запись (ставит галку UserCheck) изменения применяются.
        private void DgvUpdateCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).EndEdit();
        }
        
        //Кнопки комманд обновления.
        private void TbUpdate1Click(object sender, EventArgs e)
        {                       
            //Проверить необходимость обновления.
            if (sender == tbUpdate1) UpdateCheck();           
            
            //Показать лист обновлений.
            if (sender == tbUpdate2) UpdateList();
            
            //Показать файлы обновления.
            if (sender == tbUpdate3) UpdateUpload(false);
            
            //Удалить обновления.
            if (sender == tbUpdate4) UpdateDelete();
            
            //Скачать обновление в папку Update.
            if (sender == tbUpdate5) UpdateDownload();
            
            //Сохранить все файлы программы на сервере.  
            if (sender == tbUpdate6) UpdateUpload(true);
            
            //Запуск копирования файлов обновления, уже после их загрузки.
            if (sender == tbUpdate7) SysUpdate.UpdateRun();
            
            //Показать файлы обновления на сервере.
            if (sender == tbUpdate8) UpdateFiles();
            
        }
          //DataGridViewColumn column = new DataGridViewCheckBoxColumn();
            //column.DataPropertyName = "UserCheck";
            //column.Name = "UserCheck"; 
		    

           // SourceGrid.ColumnInfo g = new SourceGrid.ColumnInfo(dgvUpdate);
          //  g.
          //SourceGrid.ColumnInfo dd;
          //dd.
           //dgvUpdate.Columns.Add(       
       */
    }
}
