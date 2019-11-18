using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace FBA
{
    /// <summary>
    /// Форма свойств отчета.
    /// </summary>
	public partial class FormReportProperty : FormFBA
    {
        private string ID = "0";
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">ИД отчета</param>
        public FormReportProperty(string id)
        {
            InitializeComponent();
            if (id == "") return;
            this.ID = id;
                  
            string Name;
            string Brief;
            string FileName;
            string FileNameFull;
            string Format;
            string Comment;
            string SQL = "SELECT ID, Name, Brief, FileName, FileNameFull, Format, Comment " +
                         "FROM fbaReport WHERE ID = " + id;
            if (!sys.GetValue(DirectionQuery.Remote, SQL,
                out id,
                out Name,
                out Brief,
                out FileName,
                out FileNameFull,
                out Format,
                out Comment
            )) return;
            if (id == "") return;  
            tbName.Text     = Name;
            tbBrief.Text    = Brief;
            tbFileName.Text = FileNameFull;
            tbFormat.Text   = Format;
            tbComment.Text  = Comment;
        }
            
        /// <summary>
        /// Есть ещё колонка в которой указано Excel или Word.
        /// </summary>
        /// <param name="Format"></param>
        /// <returns></returns>
        private string GetReportType(string Format)
        {
            if (Format.IndexOf(".XLS") > -1) return "Excel";
            if (Format.IndexOf(".DOC") > -1) return "Word";
            return "";
        }
   
        /// <summary>
        /// Загрузить шаблон отчета в БД.
        /// </summary>
        /// <returns></returns>
        private bool ReportInsert()
        {
            string FileData = "";
            string ErrorMes = "";
            string ReportFileNameFull = tbFileName.Text;
            const bool ShowMes = true;
            if (ReportFileNameFull != "")
            {
            	if (!FBAFile.FileReadToBase64(ReportFileNameFull, out FileData, out ErrorMes, ShowMes)) return false;  
            }
            string ReportName     = tbName.Text;
            string ReportBrief    = tbBrief.Text;            
            string ReportFileName = Path.GetFileName(ReportFileNameFull);
            string Format         = tbFormat.Text;
            string Comment        = tbComment.Text;
            string ReportType     = GetReportType(Format);

            string SQL = "INSERT INTO fbaReport (" +
                         "EntityID, DateCreate, UserCreateID, " +
                         "Format, Brief, Name, " +
                         "FileName, FileNameFull, FileData, " +
                         "Comment, ReportType)" +
                         "VALUES (" +
                         "113," + sys.DateTimeCurrent() + "," + Var.UserID  + "," + 
                         "'" + Format + "','" + ReportBrief + "','" + ReportName + "'," +
                         "'," + ReportFileName + "','" + ReportFileNameFull + "','" + FileData + "'," +
                         "'," + Comment + "','" + ReportType  + "')";
                         
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;
            return true;
        }
   
        /// <summary>
        /// Загрузить шаблон отчета в БД.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private bool ReportUpdate()
        {
            string FileData = "";
            string ErrorMes = "";
            string ReportFileNameFull = tbFileName.Text;
            const bool ShowMes = true;
            if (!FBAFile.FileReadToBase64(ReportFileNameFull, out FileData, out ErrorMes, ShowMes)) return false;
            string ReportName     = tbName.Text;
            string ReportBrief    = tbBrief.Text;
            string ReportFileName = Path.GetFileName(ReportFileNameFull);
            string Format         = tbFormat.Text;
            string Comment        = tbComment.Text;
            string ReportType     = GetReportType(Format);
            string SQL = "UPDATE fbaReport " +
                         "SET " +
                         "DateChange    = " + sys.DateTimeCurrent() +
                         ",UserChangeID = " + Var.UserID  + 
                         ",Format       = '" + Format + "'" +
                         ",Brief        = '" + ReportBrief + "'" +
                         ",Name         = '" + ReportName + "'" +
                         ",FileName     = '" + ReportFileName + "'" +
                         ",FileNameFull = '" + ReportFileNameFull + "'" +
                         ",FileData     = '" + FileData + "'" +
                         ",Comment      = '" + Comment + "'" +
                         ",ReportType   = '" + ReportType + "'" +
                         " WHERE ID = " + ID;
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;
            return true;
        }
        
        /// <summary>
        /// Удалить текст имени файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFileName_DeleteClick(object sender, EventArgs e)
        {
            tbFileName.Text = "";
        }
        
        /// <summary>
        /// Выбрать файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFileName_EditClick(object sender, EventArgs e)
        {//"CSV Files|*.csv|All Files|*.*"
            const string Title = "Выбор шаблона отчета";
            const string Filter = "Office Files|*.XLS;*.XLSX;*.DOC;*.DOCX)|All files|*.*"; //формат загружаемого файла;
            string FileNameFull = "";    
            if (!FBAFile.OpenFileName(Title, Filter, "", ref FileNameFull)) return;       
            tbFileName.Text = FileNameFull;
            tbFormat.Text = Path.GetExtension(FileNameFull).ToUpper();   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (sys.IsEmptyID(ID)) ReportInsert();
            else ReportUpdate();
            this.DialogResult = DialogResult.OK;
            Close();       
        }
          
        /// <summary>
        /// Если сокращения нет, то выводим сокращение в поле сокращения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbName_Leave(object sender, EventArgs e)
        {
            if (tbBrief.Text == "") tbBrief.Text = tbName.Text.NameToBrief();
        }
    }
}
