/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 01.11.2017
 * Время: 17:47
 */
 
using System;
using System.Data;
using System.Windows.Forms;

namespace FBA
{       
    /// <summary>
    /// Шаблон формы. Необходим для создания новых прикладных форм в проекте. 
    /// </summary>
    public partial class FormReportSample : FormFBA
    {      
        public FormReportSample()
        {                
            InitializeComponent();    
            this.MdiParent = Var.FormMainObj;              
        }    
           
        private void buttonFBA1_Click(object sender, EventArgs e)
        {
            //Подготовка данных для отчета
        	DataTable dt;
            const string sql = "select * from fbaAttribute";
            sys.SelectDT(DirectionQuery.Remote, sql, out dt);
            
            //Создание отчета
            SysReportXLSX rep = new SysReportXLSX("ОтчетПоАтрибутам", "", "", dt.Rows.Count + 4);
            if (rep.errorCount > 0) return;
                        
            //rep.Test = true;
            
			//Вывод произвольного текста            
            rep.PutTextAtBookmark("Bookmark_TextDate",       DateTime.Now.ToString("dd.mm.yyyy"), "", "Вывод даты");
            rep.PutTextAtBookmark("Bookmark_TextAuthor",     "Травин Евгений Викторович", "", "Вывод автора");            
            rep.PutTextAtBookmark("Bookmark_TextSign",       "Травин Е.В.", "", "Вывод подписи");
            rep.PutTextAtBookmark("Bookmark_TextPosition",   "Специалист", "", "Вывод должности");
			
            //Вывод таблицы
            rep.FormatTableOdd = true;                
            const string format2 = ""; //ID|Фамилия|Имя|Отчество|Дата рождения|Адрес проживания|Телефон|Дата регистрации";
            rep.PutTableAtBookmark("Bookmark_TableAttr", 
                             dt,
                             format2, 
                             true, 
                             "", 
                             true,
                             "Атрибуты");                        
            
            //Сохранение на диск отчкета и его показ.
            rep.SaveToExcel("", true);
            //rep.ExportToPDF("", "", true);
        }
        
        private void buttonFBA2_Click(object sender, EventArgs e)
        {
            Close();
        }		      
    }

    internal sealed class Program
    {         
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new FormReportSample());
        }      
    }
}
