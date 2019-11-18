
/*
* Создано в SharpDevelop.
* Пользователь: Travin
* Дата: 23.11.2017
* Время: 17:35
*/

using System;
using System.Linq;
using System.Windows.Forms;
namespace FBA
{
    public partial class FormContractFilter : Form
    {
        public Object FormRef;

        public FormContractFilter()
        {
            InitializeComponent();
        }

        void cbID_CheckedChanged(object sender, EventArgs e)
        {
            sys.ControlEnableDisable(PanelFilter);
        }

        //Метод сборки фильтра желательно (но необязательно) должен называться так.         
        public string MethodStaticFilter(Object FormRef, FilterObj filterIN)        //FilterObj filterIN
        {
            this.FormRef = FormRef; //Ссылка на форму, которая вызвала фильтр.
            string WHERE = " (1=1) ";
            if (cbID.Checked) WHERE = WHERE + " AND (ObjectID = '" + tbID.Text + "') ";
            if (cbNumber.Checked) WHERE = WHERE + " AND (Number IN('" + tbNumber.Text + "')) ";
            if (cbType.Checked) WHERE = WHERE + " AND (contracttype = " + tbType.Text + ") ";
            //const string AddCond = ""; //((Form10)FormRef).textBoxParam1.Text;
            //WHERE = WHERE + " AND " + AddCond;
            //sys.SM(WHERE);
            return WHERE;
        }

    }
}
