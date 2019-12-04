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
                  
            string name;
            string brief;
            string fileName;
            string fileNameFull;
            string format;
            string comment;
            string sql = "SELECT ID, Name, Brief, FileName, FileNameFull, Format, Comment " +
                         "FROM fbaReport WHERE ID = " + id;
            if (!sys.GetValue(DirectionQuery.Remote, sql,
                out id,
                out name,
                out brief,
                out fileName,
                out fileNameFull,
                out format,
                out comment
            )) return;
            if (id == "") return;  
            tbName.Text     = name;
            tbBrief.Text    = brief;
            tbFileName.Text = fileNameFull;
            tbFormat.Text   = format;
            tbComment.Text  = comment;
        }
            
        /// <summary>
        /// Есть ещё колонка в которой указано Excel или Word.
        /// </summary>
        /// <param name="Format"></param>
        /// <returns></returns>
        private string GetReportType(string Format)
        {
            if (Format.IndexOf(".XLS", System.StringComparison.OrdinalIgnoreCase) > -1) return "Excel";
            if (Format.IndexOf(".DOC", System.StringComparison.OrdinalIgnoreCase) > -1) return "Word";
            return "";
        }
   
        /// <summary>
        /// Загрузить шаблон отчета в БД.
        /// </summary>
        /// <returns></returns>
        private bool ReportInsert()
        {
            string fileData = "";
            string errorMes = "";
            string reportFileNameFull = tbFileName.Text;
            const bool showMes = true;
            if (reportFileNameFull != "")
            {
            	if (!FBAFile.FileReadToBase64(reportFileNameFull, out fileData, out errorMes, showMes)) return false;  
            }
            string reportName     = tbName.Text;
            string reportBrief    = tbBrief.Text;            
            string reportFileName = Path.GetFileName(reportFileNameFull);
            string format         = tbFormat.Text;
            string comment        = tbComment.Text;
            string reportType     = GetReportType(format);

            string SQL = "INSERT INTO fbaReport (" +
                         "EntityID, DateCreate, UserCreateID, " +
                         "Format, Brief, Name, " +
                         "FileName, FileNameFull, FileData, " +
                         "Comment, ReportType)" +
                         "VALUES (" +
                         "113," + sys.DateTimeCurrent() + "," + Var.UserID  + "," + 
                         "'" + format + "','" + reportBrief + "','" + reportName + "'," +
                         "'," + reportFileName + "','" + reportFileNameFull + "','" + fileData + "'," +
                         "'," + comment + "','" + reportType  + "')";
                         
            if (!sys.Exec(DirectionQuery.Remote, SQL)) return false;
            return true;
        }
   
        /// <summary>
        /// Загрузить шаблон отчета в БД.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        private bool ReportUpdate()
        {
            string fileData = "";
            string errorMes = "";
            string reportFileNameFull = tbFileName.Text;
            const bool showMes = true;
            if (!FBAFile.FileReadToBase64(reportFileNameFull, out fileData, out errorMes, showMes)) return false;
            string reportName     = tbName.Text;
            string reportBrief    = tbBrief.Text;
            string reportFileName = Path.GetFileName(reportFileNameFull);
            string format         = tbFormat.Text;
            string comment        = tbComment.Text;
            string reportType     = GetReportType(format);
            string sql = "UPDATE fbaReport " +
                         "SET " +
                         "DateChange    = " + sys.DateTimeCurrent() +
                         ",UserChangeID = " + Var.UserID  + 
                         ",Format       = '" + format + "'" +
                         ",Brief        = '" + reportBrief + "'" +
                         ",Name         = '" + reportName + "'" +
                         ",FileName     = '" + reportFileName + "'" +
                         ",FileNameFull = '" + reportFileNameFull + "'" +
                         ",FileData     = '" + fileData + "'" +
                         ",Comment      = '" + comment + "'" +
                         ",ReportType   = '" + reportType + "'" +
                         " WHERE ID = " + ID;
            if (!sys.Exec(DirectionQuery.Remote, sql)) return false;
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
            const string title = "Выбор шаблона отчета";
            const string filter = "Office Files|*.XLS;*.XLSX;*.DOC;*.DOCX)|All files|*.*"; //формат загружаемого файла;
            string fileNameFull = "";    
            if (!FBAFile.OpenFileName(title, filter, "", ref fileNameFull)) return;       
            tbFileName.Text = fileNameFull;
            tbFormat.Text = Path.GetExtension(fileNameFull).ToUpper();   
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
