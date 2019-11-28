/*
* Создано в SharpDevelop.
* Пользователь: Travin
* Дата: 12.11.2017
* Время: 15:45
*/

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

namespace FBA
{
    ///Запись и чтение шаблонов отчетов в/из БД.    
    public partial class FormReport : FormFBA
    {
        
    	/// <summary>
    	/// Конструктор. Установка MdiParent, Icon, обновление таблицы отчётов.
    	/// </summary>
    	public FormReport()
        {
            InitializeComponent();
            this.MdiParent = Var.FormMainObj;
            this.Icon = this.MdiParent.Icon;
            ReportRefresh();
        }

        ///Обновление таблицы шаблонов отчетов.
        private void ReportRefresh()
        {
            /****** Script for SelectTopNRows command from SSMS  ******/
            string sql = "SELECT" +
                               " ID " +
                               ",EntityID" +
                               ",DateCreate" +
                               ",UserCreateID" +
                               ",DateChange" +
                               ",UserChangeID" +
                               ",Format" +
                               ",Brief" +
                               ",Name" +
                               ",FileName" +
            	"," + sys.GetSubString() + "(FileData, 1, 50) AS FileData" +
                               ",Comment" +
                               ",ReportType" +
                               " FROM fbaReport";  
        sys.SelectGV(DirectionQuery.Remote, sql, dgvReport);
        }

        ///Добавить шаблон отчета.  
        private void ReportAdd()
        {
            FormFBA F = new FormReportProperty("");
            if (F.ShowDialog() == DialogResult.OK) ReportRefresh();
        }

        ///Добавить шаблон отчета.  
        private void ReportEdit()
        {
            string ReportID = dgvReport.Value("ID");
            if (ReportID == "") return;
            FormFBA F = new FormReportProperty(ReportID);
            if (F.ShowDialog() == DialogResult.OK) ReportRefresh();
        }

        ///Удалить шаблон отчета.  
        private void ReportDel()
        {
            if (sys.SM("Вы хотите действительно удалить шаблон отчета?", MessageType.Question, "Удаление шаблона") == false) return;
            string ReportID = dgvReport.Value("ID");
            string ReportName = dgvReport.Value("Name");
            string sql = "DELETE FROM fbaReport WHERE ID = " + ReportID;
            if (!sys.Exec(DirectionQuery.Remote, sql)) return;
            ReportRefresh();                    
            sys.SM("Шаблон отчета успешно удален!", MessageType.Information);
        }             

        /*
         *   //Показать путь к файлу в темповой папке.
            if (SenderName == "btnReportPath")
            {
                if (tbFileNameFull.Text == "") return;
                try
                {
                    string FileNamePath = Path.GetDirectoryName(tbFileNameFull.Text);
                    System.Diagnostics.Process.Start(FileNamePath);
                }
                catch { }
            }*/
        

        ///Показ шаблона отчета.
        private void SelectReport()
        {
            string ReportID = dgvReport.Value("ID");
            if (ReportID == "") return;
            string FileName;
            string FileData;          
            string sql = "SELECT FileName, FileData FROM fbaReport WHERE ID = " + ReportID;
            if (!sys.GetValue(DirectionQuery.Remote, sql,
                               out FileName,
                               out FileData                              
                               )) return;
            if (FileData == "")
            {
                sys.SM("Не найден шаблон отчета!");
                return;
            }
            string ErrorMes;
            string FileNameTemp = FBAPath.PathTemp + FileName;


            if (!FBAFile.FileWriteFromBase64(FileData, FileNameTemp, out ErrorMes, true)) return;
            if (!File.Exists(FileNameTemp))
            {
                sys.SM("Не найден шаблон отчета на диске. Имя файла: " + FileNameTemp);
                return;
            }

            FBAFile.FileRunSimple(FileNameTemp, "");
        }

        private void dgvReport_DoubleClick(object sender, EventArgs e)
        {  
            SelectReport();
        }

        ///Меню, все команды.
        private void tbRefresh_Click_1(object sender, EventArgs e)
        {            
            //Обновить таблицу шаблонов отчетов.
            if (sender == tbRefresh) ReportRefresh();

            //Добавить шаблон отчета.            
            if (sender == tbAdd) ReportAdd();

            //Редактирвоать шаблон отчета.            
            if (sender == tbEdit) ReportEdit();

            //Удалить шаблон отчета. 
            if (sender == tbDel) ReportDel();
        }
    }
}
