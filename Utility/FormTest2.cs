using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;

namespace FBA
{
    public partial class FormTest2 : FormFBA
    {
        public FormTest2()
        {
            InitializeComponent();
            HistRefresh();
        }

        ///Обновить историю входов пользователя в систему.
        private void HistRefresh()
        {
            //string UserID = dgvUser.SelectedRows[0].Cells["ID"].Value.ToString();
            string SQL = "SELECT ID, EntityID, ConnectionName, ComputerName, " +
                         "       ComputerUserName, UserForm, UserID, SystemName, EnterDate " +
                         "FROM fbaEnterHist"; // WHERE UserID = " + UserID;
            var filter = new FilterObj();
            filter.FullQuerySQL = SQL;
            //RefreshGrid2_2("Remote", gridControl1, filter); //, null);
            //sys.RefreshGrid("Remote", gridControl1, filter);


            //System.Data.DataSet dataset = new System.Data.DataSet();
            //dataset = GetDatatableFromSQL("select * from [A_AttrChild]");
            //DevAge.ComponentModel.BoundDataView bd = new DevAge.ComponentModel.BoundDataView(dataset.Tables[0].DefaultView);
            //sgHist2.DataSource = bd;
            //sgHist2.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize;
            //sgHist2.Columns[0].Width = 20;
            //sgHist2.Columns.AutoSizeView();

        }
        //Выполнить запрос
        private System.Data.DataSet GetDatatableFromSQL(string SQL)
        {
            string DbServer = "DbServer";
            string DbName   = "DbName";
            string UserName = "UserName";
            string UserPass = "UserPass";
            var conn = new SqlConnection("Server=" + DbServer + ";User Id=" + UserName + ";Password=" + UserPass + ";Database=" + DbName + ";");
            var DS = new System.Data.DataSet("DS");
            var da = new SqlDataAdapter(SQL, conn);
            da.Fill(DS);
            conn.Close();
            return DS;
        }

      

    }


}
