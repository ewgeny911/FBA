using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Management;
using System.Runtime.InteropServices;

namespace FBA
{
    /// <summary>
    /// Форма для просмотра текста и скриншота ошибок, котоые возникают у пользователей:
    /// Если установлен параметр - сохранять ошибку на сервере, то при возникновении ошибки на коиенте у пользователя, на сервр отправляется текст ошибки и скриншот экрана.
    /// Хранится все это в табличке fbaError. Данная форма предназначена для полсмотра содержимого этой таблички.
    /// Здесь же есть статическая процедура SendErrorToServer, котоая и посылает текст и скриншот на сервер при возникновении ошибки у пользователя. 
    /// </summary>
    public partial class FormError : FormFBA
    {
        /// <summary>
        /// Конструктор. Установка MdiParent, Icon, обновление таблицы ошибок. 
        /// </summary>
    	public FormError()
        {
            InitializeComponent();
            this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;
            ErrorRefresh();
        }

        private void tbErrorAdd_Click(object sender, EventArgs e)
        {
            Error.SendErrorToServer("ошибка 1", "additionalInfo");
        }
   
        /// <summary>
        /// Обновление таблицы изображений.
        /// </summary>
        private void ErrorRefresh()
        {
            string sql = "SELECT ID, UserID, ErrorTime, ErrorText, ScreenshotFormat FROM fbaError WHERE ErrorTime > " + sys.DateTimeCurrent() + " - 1";
            sys.SelectGV(DirectionQuery.Remote, sql, dgvError);
        }
           
        /// <summary>
        /// Удалить изображение. 
        /// </summary>
        private void ErrorDel()
        {
            string errorID = dgvError.DataGridViewSelected("ID");      
            string sql = "DELETE FROM fbaError WHERE ID = " + errorID;
            if (!sys.Exec(DirectionQuery.Remote, sql)) return;
            ErrorRefresh();
            pictureBox1.Image = global::FBA.Resource.no_foto_1;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            tbID.Text        = "";
            tbImageSize.Text      = "";
            tbFormat.Text    = "";
            tbErrorDate.Text = "";
            tbErrorText.Text = "";
            tbAddInfo.Text   = "";
            tbUserID.Text    = "";
            ShowError();
            sys.SM("Ошибка успешно удалена!", MessageType.Information);
        }   
        
        /// <summary>
        /// Меню, все команды.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbErrorRefresh_Click(object sender, EventArgs e)
        {            
            //Обновить таблицу изображений.
            if (sender == tbErrorRefresh) ErrorRefresh();

            //Удалить изображение. 
            if (sender == tbErrorDel) ErrorDel();

            //Сохранить изображение            
            if (sender == btnSaveImage) ImageSave();
        }

        /// <summary>
        /// Сохранить изображение   
        /// </summary>
        private void ImageSave()
        {
        	if (pictureBox1.Image == null) return;
        	string fileName = "error.jpeg";
            if (!FBAFile.SaveFileName("Сохранение изображения", "jpeg Files|*.jpeg;*.jpg|All Files (*.*)|*.*", "", 0, ref fileName)) return;
            try
            {
                pictureBox1.Image.Save(fileName);
            } catch (Exception ex)
            {
                sys.SM("Ошибка сохранения изображения в файл: " + fileName + Var.CR + ex.Message);
            }            
        }           
        
        /// <summary>
        /// Показ изображения.
        /// </summary>
        private void SelectError()
        {
            string errorID = dgvError.DataGridViewSelected("ID");
            if (errorID == "") return;
            var arr = new string[11];
            string sql = "SELECT " +
                         "ID, " +               //0
                         "UserID, " +           //1
                         "ErrorTime, " +        //2
                         "ErrorText, " +        //3
                         "ScreenshotData, " +   //4
                         "ScreenshotFormat, " + //5
                         "ScreenshotWidth, " +  //6
                         "ScreenshotHeight, " + //7
                         "ScreenshotSize, " +   //8
                         "CompressRatio, " +    //9
                         "AdditionalInfo " +    //10
                         " from fbaError WHERE ID = " + errorID;

            if (!sys.GetValueArr(DirectionQuery.Remote, sql, ref arr)) return;
            if (arr[0] == "")
            {
                sys.SM("Не найдена ошибка!");
                return;
            }

            tbID.Text            = arr[0];
            tbImageSize.Text     = arr[6] + "x" + arr[7];
            tbFormat.Text        = arr[5];
            tbErrorDate.Text     = arr[2];
            tbErrorText.Text     = arr[3];
            tbAddInfo.Text       = arr[10];
            tbUserID.Text        = arr[1];
            tbCompressRatio.Text = arr[9];
            tbFileSize.Text      = arr[8];
            try
            {
                //Как было ранее:
                //byte[] arrayimg = Convert.FromBase64String(screenshotData);
                //Image image = Image.FromStream(new MemoryStream(arrayimg));
                //pictureBox1.Image = image;

                //Test WebP to pictureBox
                Bitmap bmp6;
                byte[] arrayimg = Convert.FromBase64String(arr[4]);
                WebP.Decode(arrayimg, out bmp6);
                pictureBox1.Image = bmp6;
                ShowError();
            }
            catch (Exception ex)
            {
                sys.SM("Ошибка при открытии изображения: " + ex.Message);
                return;
            }
        }

        /// <summary>
        /// Переключение вида просмотра изображения. 
        /// Либо всю картинку в окно вмещаем, либо с прокруткой
        /// </summary>
        private void ShowError()
        {
            if ((pictureBox1.Image.Width < panelAutoScroll.Width) && (pictureBox1.Image.Height < panelAutoScroll.Height))
            {
                pictureBox1.Dock = DockStyle.Fill;
                panelAutoScroll.AutoScroll = false;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {
                if (cbSize.Checked)
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
                    
        /// <summary>
        /// При выборе изображения в таблице показываем его в pictureBox1.
        /// </summary>
        private void dgvError_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectError();
        }
      
        /// <summary>
        /// Переключаем вид изображения. Либо всю картинку в окно вмещаем, либо с прокруткой
        /// </summary>
        private void cbSize_CheckedChanged(object sender, EventArgs e)
        {
            ShowError();
        }
    }

    /// <summary>
    /// Класс для работы с изображениями в формате WEBP. Формат WEBP лучше сжимает чем JPG, поэтому используется он.
    /// </summary>
    public class WebP
    {
        /*  //Использование:

            //Test JPG to WebP
            Bitmap bmp1 = new Bitmap("test.jpg");
            WebP.Save(bmp1, 80, "test.webp");

            //Test WebP to PNG
            Bitmap bmp2; 
            WebP.Load("test.webp", out bmp2);
            bmp2.Save("test.png", ImageFormat.Png);

            //Test JPG to WebP in lossless mode. Using compress in memory
            byte[] webpImageData1;
            Bitmap bmp3 = new Bitmap("test.jpg");
            WebP.EncodeLossless(bmp3, out webpImageData1);
            File.WriteAllBytes("lossless.webp", webpImageData1);

            //Test JPG to WebP in lossly mode. Using encode in memory
            byte[] webpImageData2;
            Bitmap bmp4 = new Bitmap("test.jpg");
            WebP.EncodeLossly(bmp4, 80, out webpImageData2);
            File.WriteAllBytes("lossly.webp", webpImageData2);

            //Test WebP to PNG. Using decode in memory
            Bitmap bmp5;
            byte[] webpImageData3 = File.ReadAllBytes("lossless.webp");
            WebP.Decode(webpImageData3, out bmp5);
            bmp4.Save("test2.png", ImageFormat.Png);

            //Test WebP to pictureBox
            Bitmap bmp6;
            WebP.Load("test.webp", out bmp6);
            pictureBox.Image = bmp6;
        
         */


        /// <summary>Save bitmap to file in WebP format</summary>
        /// <param name="bmp">Bitmap with the WebP image</param>
        /// <param name="quality">Quality. 0 = minumin ... 100 = maximimun quality</param>
        /// <param name="pathFileName">The file to write</param>
        /// <returns>True if success; False otherwise</returns>
        public static bool Save(Bitmap bmp, int quality, string pathFileName)
        {
            byte[] dataWebP;

            try
            {
                //Encode in webP format
                if (!EncodeLossly(bmp, quality, out dataWebP)) return false;

                //Write webP file
                File.WriteAllBytes(pathFileName, dataWebP);

                return true;
            }
            catch { return false; }
        }

        /// <summary>Read a WebP file</summary>
        /// <param name="pathFileName">WebP file to load</param>
        /// <param name="bmp">Bitmap with the WebP image</param>
        /// <returns>True if success; False otherwise</returns>
        public static bool Load(string pathFileName, out Bitmap bmp)
        {
            bool result;
            byte[] dataWebP;
            bmp = null;

            try
            {
                //Read webP file
                dataWebP = File.ReadAllBytes(pathFileName);

                result = Decode(dataWebP, out bmp);

                return result;
            }
            catch { return false; }
        }

        /// <summary>Decode a WebP image</summary>
        /// <param name="webpData">the data to uncompress</param>
        /// <param name="bmp">Bitmap whit the image</param>
        /// <returns>True if success; False otherwise</returns>
        public static bool Decode(byte[] webpData, out Bitmap bmp)
        {
            int imgWidth;
            int imgHeight;
            IntPtr outputBuffer;
            int outputBufferSize;
            bmp = null;

            try
            {
                //Get image width and height
                GCHandle pinnedWebP = GCHandle.Alloc(webpData, GCHandleType.Pinned);
                IntPtr ptrData = pinnedWebP.AddrOfPinnedObject();
                UInt32 dataSize = (uint)webpData.Length;
                if (WebPGetInfo(ptrData, dataSize, out imgWidth, out imgHeight) != 1) return false;

                //Create a BitmapData and Lock all pixels to be written
                bmp = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb);
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

                //Allocate memory for uncompress image
                outputBufferSize = bmpData.Stride * imgHeight;
                outputBuffer = Marshal.AllocHGlobal(outputBufferSize);

                //Uncompress the image
                outputBuffer = WebPDecodeBGRInto(ptrData, dataSize, outputBuffer, outputBufferSize, bmpData.Stride);

                //Write image to bitmap using Marshal
                byte[] buffer = new byte[outputBufferSize];
                Marshal.Copy(outputBuffer, buffer, 0, outputBufferSize);
                Marshal.Copy(buffer, 0, bmpData.Scan0, outputBufferSize);

                //Write image to bitmap using CopyMemory. Faster than Marshall, but only work in windows
                //CopyMemory(bmpData.Scan0, outputBuffer, (uint)outputBufferSize);

                //Unlock the pixels
                bmp.UnlockBits(bmpData);

                //Free memory
                pinnedWebP.Free();
                Marshal.FreeHGlobal(outputBuffer);

                return true;
            }
            catch  { return false; }
        }

        /// <summary>Write a WebP file in minimun size</summary>
        /// <param name="webpData">Bitmap to encode</param>
        /// <param name="quality">Quality. 0 = minumin ... 100 = maximimun quality</param>
        /// <param name="bmp">Bitmap with the image</param>
        /// <returns>True if success; False otherwise</returns>
        public static bool Encode(Bitmap bmp, int quality, out byte[] webpData)
        {
            byte[] lossly;
            byte[] lossless;
            webpData = null;

            try
            {
                //compress in two metods
                if (!EncodeLossly(bmp, quality, out lossly)) return false;
                if (!EncodeLossless(bmp, out lossless)) return false;

                if (lossly.Length >= lossless.Length)
                    webpData = lossless;
                else
                    webpData = lossly;

                return true;
            }
            catch { return false; }
        }

        /// <summary>Lossly encoding image in bitmap</summary>
        /// <param name="bmp">Bitmap with the image</param>
        /// <param name="quality">Quality. 0 = minumin ... 100 = maximimun quality</param>
        /// <param name="webpData">Compress data</param>
        /// <returns>True if success; False otherwise</returns>
        public static bool EncodeLossly(Bitmap bmp, int quality, out byte[] webpData)
        {
            BitmapData bmpData;
            IntPtr unmanagedData;
            int size;
            webpData = null;

            try
            {
                bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                size = WebPEncodeBGR(bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, quality, out unmanagedData);

                //Copy image compress data to output array
                webpData = new byte[size];
                Marshal.Copy(unmanagedData, webpData, 0, size);

                //Unlock the pixels
                bmp.UnlockBits(bmpData);

                //Free memory
                WebPFree(unmanagedData);

                return true;
            }
            catch { return false; }
        }

        /// <summary>Lossless encoding image in bitmap</summary>
        /// <param name="bmp">Bitmap with the image</param>
        /// <param name="webpData">Compress data</param>
        /// <returns>True if success; False otherwise</returns>
        public static bool EncodeLossless(Bitmap bmp, out byte[] webpData)
        {
            BitmapData bmpData;
            IntPtr unmanagedData;
            int size;
            webpData = null;

            try
            {
                //Get bmp data
                bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                //Compress the bmp data
                size = WebPEncodeLosslessBGR(bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, out unmanagedData);

                //Copy image compress data to output array
                webpData = new byte[size];
                Marshal.Copy(unmanagedData, webpData, 0, size);

                //Unlock the pixels
                bmp.UnlockBits(bmpData);

                //Free memory
                WebPFree(unmanagedData);

                return true;
            }
            catch { return false; }
        }

        /// <summary>Validate the WebP image header and retrieve the image height and width. Pointers *width and *height can be passed NULL if deemed irrelevant</summary>
        /// <param name="data">Pointer to WebP image data</param>
        /// <param name="data_size">This is the size of the memory block pointed to by data containing the image data</param>
        /// <param name="width">The range is limited currently from 1 to 16383</param>
        /// <param name="height">The range is limited currently from 1 to 16383</param>
        /// <returns>1 if success, otherwise error code returned in the case of (a) formatting error(s).</returns>
        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int WebPGetInfo(IntPtr data, UInt32 data_size, out int width, out int height);

        /// <summary>Decode a WebP image pointed to by data</summary>
        /// <param name="data">Pointer to WebP image data</param>
        /// <param name="data_size">This is the size of the memory block pointed to by data containing the image data</param>
        /// <param name="width">The range is limited currently from 1 to 16383</param>
        /// <param name="height">The range is limited currently from 1 to 16383</param>
        /// <returns>output_buffer if function succeeds; NULL otherwise</returns>
        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr WebPDecodeBGR(IntPtr data, UInt32 data_size, ref int width, ref int height);

        /// <summary>Decode WEBP image pointed to by *data and returns BGR samples into a pre-allocated buffer</summary>
        /// <param name="data">Pointer to WebP image data</param>
        /// <param name="data_size">This is the size of the memory block pointed to by data containing the image data</param>
        /// <param name="output_buffer">Pointer to decoded WebP image</param>
        /// <param name="output_buffer_size">Size of allocated buffer</param>
        /// <param name="output_stride">Specifies the distance between scanlines</param>
        /// <returns>output_buffer if function succeeds; NULL otherwise</returns>
        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr WebPDecodeBGRInto(IntPtr data, UInt32 data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);

        /// <summary>Lossless encoding images pointed to by *data in WebP format</summary>
        /// <param name="rgb">Pointer to RGB image data</param>
        /// <param name="width">The range is limited currently from 1 to 16383</param>
        /// <param name="height">The range is limited currently from 1 to 16383</param>
        /// <param name="stride">Specifies the distance between scanlines</param>
        /// <param name="quality_factor">Ranges from 0 (lower quality) to 100 (highest quality). Controls the loss and quality during compression</param>
        /// <param name="output">output_buffer with WebP image</param>
        /// <returns>Size of WebP Image</returns>
        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int WebPEncodeBGR(IntPtr rgb, int width, int height, int stride, float quality_factor, out IntPtr output);

        /// <summary>Lossless encoding images pointed to by *data in WebP format</summary>
        /// <param name="rgb">Pointer to RGB image data</param>
        /// <param name="width">The range is limited currently from 1 to 16383</param>
        /// <param name="height">The range is limited currently from 1 to 16383</param>
        /// <param name="stride">Specifies the distance between scanlines</param>       
        /// <param name="output">output_buffer with WebP image</param>
        /// <returns>Size of WebP Image</returns>
        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int WebPEncodeLosslessBGR(IntPtr rgb, int width, int height, int stride, out IntPtr output);

        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int WebPFree(IntPtr p);

        //Faster copy, but only work in windows
        //[DllImport("kernel32.dll", EntryPoint = "CopyMemory")]
        //private static extern void CopyMemory(IntPtr Destination, IntPtr Source, uint Length);
    }
}

