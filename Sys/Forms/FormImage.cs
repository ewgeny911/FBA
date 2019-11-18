
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 12.11.2017
 * Время: 15:45
 */
 
using System;
using System.Linq;   
using System.Windows.Forms;
using System.IO;

namespace FBA
{         
    ///Запись и чтение изображенгий в/из БД.    
    public partial class FormImage : FormFBA
    {                 
        /// <summary>
    	/// Конструктор. Установка MdiParent, Icon, обновление таблицы изображений.
    	/// </summary>
    	public FormImage()
        {                
            InitializeComponent();                
            this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;  
            ImageRefresh();            
        }
        
        ///Обновление таблицы изображений.
        private void ImageRefresh()
        {
            string sql = "SELECT ID, " +
                    "UserChangeID, " +
                    "UserCreateID, " +
                    "DateChange, " +
                    "DateCreate," +
                    "Name, " +
                    "FileName, " +
                    "FileNameFull, " + 
            	    sys.GetSubString() + "(Image, 1, 50) AS Image, " +
                    "Width, " +
                    "Height, " +
                    "Format " +
                    "FROM fbaImage";            
             sys.SelectGV(DirectionQuery.Remote, sql, dgvImage);   
        }
              
        ///Добавить одно изображение. 
        private void ImageAdd()
        {                      
            const string title = "Выбор изображения";
            const string filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла;
            string fileNameFull = "";
            const string initialDirectory = "";
            if (!FBAFile.OpenFileName(title, filter, initialDirectory, ref fileNameFull)) return;
            if (!ImageAdd(fileNameFull)) return;
            ImageRefresh();
            sys.SM("Изображение успешно загружено!", MessageType.Information);
        }
        
        ///Добавить все изображения из папки.
        private void DirAdd()
        {                  
            const string initialPath = @"C:\";
            string dirName = "";
            if (!FBAFile.DirChoose(initialPath, out dirName)) return;
            const bool subDirectories = false; //Вложенные подпапки не проверяем.
            string[] files = FBAFile.FileFind(dirName, "*.*", subDirectories);
            const string imageFormat = ";.BMP;.JPG;.GIF;.PNG;";
            var progress1 = new FormProgress("Загрузка", "Загрузка изображений в базу данных", files.Count());
            progress1.Show();                                 
            for (int i = 0; i < files.Count(); i++)
            {
                string fileNameFull = files[i];
                string format       = Path.GetExtension(fileNameFull).ToUpper();
                if (imageFormat.IndexOf(format, StringComparison.OrdinalIgnoreCase) < 0) continue;
                if (!ImageAdd(fileNameFull)) return;              
                progress1.Inc();
                //Thread.Sleep(1000);
            }
            progress1.Dispose();
            ImageRefresh();
            sys.SM("Bсе изображения успешно загружены в базу данных!", MessageType.Information);
        }
        
        ///Загрузить картинку в БД.
        private bool ImageAdd(string FileNameFull)
        {
            string FileData     = "";
            string ErrorMes = "";
            string ImageWidth   = "";
            string ImageHeight  = "";                               
            const bool ShowMes = true;
            if (!FBAFile.FileReadToBase64(FileNameFull, out FileData, out ErrorMes, ShowMes)) return false;
            string ImageName     = Path.GetFileNameWithoutExtension(FileNameFull);  
            string ImageFileName = Path.GetFileName(FileNameFull); 
            string Format        = Path.GetExtension(ImageFileName).ToUpper();
            try
            {
                var pictureBoxTemp = new FBA.PictureBoxFBA();
                pictureBoxTemp.PictureBoxLoadFile(FileNameFull);
                ImageWidth  = pictureBoxTemp.Image.Width.ToString();
                ImageHeight = pictureBoxTemp.Image.Height.ToString();              
            } catch (Exception ex)
            {
                sys.SM("Ошибка при открытии изображения: " + FileNameFull + Var.CR + ex.Message);
                return false;
            }
                                      
            string sql = "INSERT INTO fbaImage (" +
                         "UserCreateID, DateCreate, Name, " +
                         "FileName, FileNameFull, Image, " +
                         "Width, Height, Format) " +
                         "VALUES (" + Var.UserID  + ", " + sys.DateTimeCurrent() + ",'" + ImageName + "'," +
                         "'" + ImageFileName + "','" + FileNameFull +"','" + FileData +"'," +
                         "'" + ImageWidth + "','" + ImageHeight + "','" + Format + "')";
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
            return true;
        }
               
        ///Удалить изображение.  
        private void ImageDel()
        {
            string ImageID   = dgvImage.DataGridViewSelected("ID"); 
            string ImageName = dgvImage.DataGridViewSelected("Name");              
            string SQL = "DELETE FROM fbaImage WHERE ID = " + ImageID;
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return;
            ImageRefresh();
            pictureBox1.Image = global::FBA.Resource.no_foto_1;  
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            tbID.Text           = "";
            tbSize.Text         = "";
            tbFormat.Text       = "";
            tbFileName.Text     = "";
            tbFileNameFull.Text = "";
            ShowImage();
            sys.SM("Изображение успешно удалено!", MessageType.Information);                         
        }
        
        ///Меню, все команды.
        private void tbImageRefresh_Click(object sender, EventArgs e)
        {                                                           
            //Обновить таблицу изображений.
            if (sender == tbImageRefresh) ImageRefresh();
            
            //Добавить изображение.            
            if (sender == tbImageAddFile) ImageAdd();
            
            //Добавить все изображения из папки.            
            if (sender == tbImageAddDir) DirAdd();
            
            //Удалить изображение. 
            if (sender == tbImageDel) ImageDel();
            
            //Показать путь к файлу в темповой папке.
            if (sender == btnImagePath)
            {                
                if (tbFileNameFull.Text == "") return;
                try
                {
                    string FileNamePath = Path.GetDirectoryName(tbFileNameFull.Text);
                    System.Diagnostics.Process.Start(FileNamePath);
               } catch {}
            }                             
        }
        
        ///Показ изображения.
        private void SelectImage()
        {
            string ImageID   = dgvImage.DataGridViewSelected("ID"); 
             
            if (ImageID == "") return;
            string FileData;
            string ImageName;
            string FileName;
            string FileNameFull; 
            string Format;
            string ImageWidth;
            string ImageHeight;
            string SQL = "SELECT Image, Name, FileName, FileNameFull, " +
                         "Format, Width, Height " +
                         "FROM fbaImage WHERE ID = " + ImageID;
            if (!sys.GetValue(DirectionQuery.Remote, SQL, 
                               out FileData, 
                               out ImageName, 
                               out FileName, 
                               out FileNameFull,
                               out Format, 
                               out ImageWidth, 
                               out ImageHeight)) return;
            if (FileData == "") 
            {
                sys.SM("Не найдено изображение в таблице изображений!");
                return;
            }               
            string ErrorMes;                        
            string FileNameTemp = FBAPath.PathTemp + FileName;
               
           
            if (!FBAFile.FileWriteFromBase64(FileData, FileNameTemp, out ErrorMes, true)) return;
            if (!File.Exists(FileNameTemp)) 
            {
                sys.SM("Не найдено изображение на диске. Имя файла: " + FileNameTemp);               
                return;
            }
            tbID.Text           = ImageID;
            tbSize.Text         = ImageWidth + "x" + ImageHeight;
            tbFormat.Text       = Format;
            tbFileName.Text     = FileName;
            tbFileNameFull.Text = FileNameFull;
            
            try
            {                 
                pictureBox1.PictureBoxLoadFile(FileNameTemp);
                ShowImage();
            } catch (Exception ex)
            {
                sys.SM("Ошибка при открытии изображения: " + FileNameTemp + Var.CR + ex.Message);
                return;
            }
        }
        
        private void ShowImage()
        {
           if ((pictureBox1.Image.Width < panelAutoScroll.Width) && (pictureBox1.Image.Height < panelAutoScroll.Height))
           {               
               pictureBox1.Dock = DockStyle.Fill;
               panelAutoScroll.AutoScroll = false;
               pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
           }                
            else 
            {   
                if (checkBoxSize.Checked)
                {
                    pictureBox1.Dock = DockStyle.Fill;
                    panelAutoScroll.AutoScroll = false;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }
                pictureBox1.Dock = DockStyle.None;
                panelAutoScroll.AutoScroll = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }
        
        ///При выборе изображения в таблице показываем его в pictureBox1.          
        private void dgvImage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectImage();
        }
        void checkBoxSize_CheckedChanged(object sender, EventArgs e)
        {
             ShowImage();
        }      
        
    }

}
