
/*
* Создано в SharpDevelop.
* Пользователь: Travin
* Дата: 04.02.2018
* Время: 23:20
*/

using System;
using System.Reflection;

namespace FBA
{
    
	
	public partial class FormContract : FormFBA
    {
        public string ID = "0";
        public ObjectRef Obj;

        public FormContract() 
        {
            InitializeComponent();        
        }
        
        public FormContract(string ID) 
        {
            InitializeComponent();
            this.ID = ID;        
            //this.MdiParent = sys.ProjectMainObj;
            Obj = new FBA.ObjectRef();
            const string StateDate = "";
            
            
            Obj.SetQueryEntity(this, "Main1", "Contract", ID, StateDate, DirectionQuery.Remote);
            Obj.Read();
            Text = Obj.GetObjectName("Main1");
        }
                 

        private void Button1_Click(object sender, EventArgs e)
        {        
            //Obj.ShowArrayAll(); 
            //Пример записи объекта
        	if (this.Obj.Write())
            {                
                ID = this.Obj.GetObjectID("Main1");               
                this.Text = this.Obj.GetObjectName("Main1");
            };
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Obj.ShowArrayAll();
        }      

        private void button1_Click_2(object sender, EventArgs e)
        {
            Obj.ShowArrayAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sys.SM("RemoteM  SQL = " + Obj.RemoteMSQL + Var.CR +
                   "RemoteSQL = " + Obj.remoteSQL);
        }
		void TextBoxFBA5KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
	
		}

 
        
        /*int iTop    = EditFBA2.btnEdit.Top;
            int iLeft   = EditFBA2.btnEdit.Left;
            int iBottom = EditFBA2.btnEdit.Bottom;
            int iRight  = EditFBA2.btnEdit.Right;
            int iWidth  = EditFBA2.btnEdit.Width;
            int iHeight = EditFBA2.btnEdit.Height;

            int jTop    = EditFBA2.btnDelete.Top;
            int jLeft   = EditFBA2.btnDelete.Left;
            int jBottom = EditFBA2.btnDelete.Bottom;
            int jRight  = EditFBA2.btnDelete.Right;
            int jWidth  = EditFBA2.btnDelete.Width;
            int jHeight = EditFBA2.btnDelete.Height;


            int edWidth = EditFBA2.Width;
            int edHeight= EditFBA2.Height;

            sys.SM("iTop="    + iTop.ToString() + Var.CR +
                   "iLeft="   + iLeft.ToString() + Var.CR +
                   "iBottom=" + iBottom.ToString() + Var.CR +
                   "iRight="  + iRight.ToString() + Var.CR +
                   "iWidth="  + iWidth.ToString() + Var.CR +
                   "iHeight=" + iHeight.ToString() + Var.CR + 
                   Var.CR +
                   "jTop="    + jTop.ToString() + Var.CR +
                   "jLeft="   + jLeft.ToString() + Var.CR +
                   "jBottom=" + jBottom.ToString() + Var.CR +
                   "jRight="  + jRight.ToString() + Var.CR +
                   "jWidth="  + jWidth.ToString() + Var.CR +
                   "jHeight=" + jHeight.ToString() + Var.CR +
                   Var.CR +
                   "edWidth=" + edWidth.ToString() + Var.CR +
                   "edHeight = " + edHeight.ToString() + Var.CR 
                   );
                   */
    }
	
	//internal sealed class Program
    //{     
    //    [STAThread]
    //    private static void Main(string[] args)
    //    {                      	
        	//Этот метод не вызывается, если проект подключается как DLL.
        	//Иными словами, если сюда попадаем, то это значит мы запустили как EXE, а значит мы в режиме разработки.
        	//AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve; //ResolveAssemblies; //OnAssemblyResolve;
        	/*Var.IsDesignMode = true;
        	Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);              
            Application.Run(new FormMain());*/
    //    }
	//}
}


   	
	     	//Obj.Ref = sys.SortTwoDimensionalArray(Obj.Ref, "", 0, Obj.RefCount, "", "Column27 DESC");                                 
            //sys.ArrayView("Ref",
            //       "0.iPos;1.TypeAction;2.iName;3.iTypeControl;4.iTag;5.iQueryName;6.iAttr;7.iAttrLookup;8.iEnt;9.iEntityBrief;10.iEntityID;11.iObjectID;" +
            //        "12.iStateDate;13.iTableName;" +
            //        "14.iTableType;15.iFieldName;16.iFieldName2;17.iIDFieldName;18.iPosLocal;19.iPosRemote;20.iSetting;21.iValueOld;22.iValueNew;23.iValueNewID;24.iSaveType;25.iNeedSave;26.iNumLevel;", Obj.Ref); 
		