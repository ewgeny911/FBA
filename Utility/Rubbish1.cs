
//https://professorweb.ru/my/csharp/web/level3/3_2.php
//Command=101;GUID=0f8fad5b-d9cb-469f-a165-70867728950e;LocalIP=127.0.0.1;LocalHost=MyCom1234;ComputerName=MyCom1234;ComputerUserName=Petrov; 
            
//tabControl1.TabPages.Remove(tabPage5);
/*public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
       {
           using (MemoryStream ms = new MemoryStream())
           {
               // Convert Image to byte[]
               image.Save(ms, format);
               byte[] imageBytes = ms.ToArray();
               return imageBytes;
           }
       }                        
       public Image ByteToImage(byte[] imageBytes)
       {
           // Convert byte[] to Image
           MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
           ms.Write(imageBytes, 0, imageBytes.Length);
            
           Image image = new Bitmap(ms);
           return image;
       }*/
/*private int S45aveFileToDisk111()
{
    using (FileStream file = new FileStream("file.bin", FileMode.Create, System.IO.FileAccess.Write))
    {
        MemoryStream ms = new MemoryStream(); 
        byte[] bytes = new byte[ms.Length];
        ms.Read(bytes, 0, (int)ms.Length);
        file.Write(bytes, 0, bytes.Length);
        ms.Close();
    }
            
            
    //FileStream fs = null;
   //StreamReader sr = null;
    //Image photo = new Bitmap(@"\Photos\Image20120601_1.jpeg");
    //byte[] pic = ImageToByte(photo, System.Drawing.Imaging.ImageFormat.Jpeg);
    return 1;
}*/
//AppDomain.Unload(domain);
//foreach (Control control in this.Controls)
//control.
//    if (control is TextBox)
//       control.Text = control.Name;
//List<DataTable> MyList;
//MyList = null;
//dataGridViewTest1.DataSource = MyList[0];
//string[] args = new string[5] {"aa", "dd", "hh", "gg", "jj"};
//args[0] = "ff";
//Main11(args);
/*List<DataTable> MyList;
String SQL = "select ID, DateCreate from Func;";	   //иначе обновляются последние ранее существующие
bool ErrorShow = true;  //Для отладки. Показывать ошибки.
String ErrorText = "";    //Для отладки. Текст ошибки.
Connection con1; //Подключение
con1 = new Connection("SQLite", "", "", "", "");
bool flag = con1.GetQueryDataSQLite(SQL, null, out MyList, out ErrorText, ErrorShow);
dataGridViewTest1.DataSource = MyList[0];
//dataGridViewTest2.DataSource = MyList[1];
*/
        //Чтение формы из базы данных.
        //private void btnOpen_Click(object sender, EventArgs e)
        //{
            //IComponent dfg;
            //dfg.Site.
            //host.
            //ReadModule("a1");
            //SampleDesignerLoader designerLoader = new SampleDesignerLoader(@"C:\000_Travin\Projects C#\Проба дизайнер С#\111 - перед откатом\bin\Debug\a1.XML");
            //SampleDesignerLoader designerLoader = new SampleDesignerLoader();           
            //host.LoadDocument(designerLoader);
            //if (loader != null) 
            //{
            //    loader.Dispose();
            //};
            //SampleDesignerLoader designerLoader2 = new SampleDesignerLoader();
            //CreateDesigner(designerLoader2);
            //designerLoader2.Dispose();
        //}
/*
//dataGridViewTest
String SetFile = @"C:\000_Travin\Projects C#\Проба дизайнер С#\111 - перед откатом\bin\Debug\Sys1.db3";
SQLiteConnection con = new SQLiteConnection();
con.ConnectionString = @"Data Source=" + SetFile + ";New=False;Version=3"; // в таком виде всё работает!
try
{
    //con.Open();
    //con.Close();
    //const string databaseName = @"C:\cyber.db";
    //SQLiteConnection connection =
    //new SQLiteConnection(string.Format("Data Source={0};", databaseName));
    //SQLiteCommand command = new SQLiteCommand("select * from Form;", con);
    con.Open();
    //command.ExecuteNonQuery();
    SQLiteDataAdapter Adapter = new SQLiteDataAdapter();
    DataTable DatatableAttr = new DataTable();
    Adapter.SelectCommand = new SQLiteCommand("select * from Form;", con);
    DataTable Datatable1 = new DataTable();
    Adapter.Fill(Datatable1);  //в data результат в виде таблиц   
    dataGridViewTest.DataSource = Datatable1;
    //con.Close();
    //Console.ReadKey(true);
             
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
}
 */
 
 
 
 
  //propertyGrid.Refresh();
  //propertyGrid.Select();
  
  
  
  
  
  /*//Запуск формы. 
            //String PathModule = Application.StartupPath.ToString() + @"\\LibraryForm.dll";
            String PathModule = @"C:\Мусор\LibraryForm.dll";
            //String PathModule = @"C:\000_Travin\Projects C#\Проба дизайнер С#\111\bin\Debug\LibraryForm.dll";
         
            //Запуск в существующем главном домене.   
            if (System.IO.File.Exists(PathModule))
            {
                Assembly assembly = Assembly.LoadFile(PathModule);
                Type type = assembly.GetType("form1Namespace.form1");
                Form form22 = (Form)Activator.CreateInstance(type);
                //form22.MdiParent = this;
                form22.Show();                 
                
                //FFL Form21 = new FFL(); 
                //Form21.Show();//в обычном режиме
                
                
            }
            */
           
            //if (tabControlModule.SelectedTab.Name == "tabPage1") {MessageBox.Show("!!!");}                
            //Следующая строка работает!!!
            //MessageBox.Show((Application.OpenForms[0] as FormMain).tabControlModule.TabIndex.ToString());
            //MessageBox.Show(Application.OpenForms[0].Name);
                
                
                
                
            /*
             using System;
using System.Globalization;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Security;
namespace System
{
	[__DynamicallyInvokable, ClassInterface(ClassInterfaceType.AutoDual), ComVisible(true)]
	[Serializable]
	public class Object
	{
		[__DynamicallyInvokable, ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public Object()
		{
		}
		[__DynamicallyInvokable]
		public virtual string ToString()
		{
			return this.GetType().ToString();
		}
		[__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public virtual bool Equals(object obj)
		{
			return RuntimeHelpers.Equals(this, obj);
		}
		[__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public static bool Equals(object objA, object objB)
		{
			return objA == objB || (objA != null && objB != null && objA.Equals(objB));
		}
		[__DynamicallyInvokable, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public static bool ReferenceEquals(object objA, object objB)
		{
			return objA == objB;
		}
		[__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public virtual int GetHashCode()
		{
			return RuntimeHelpers.GetHashCode(this);
		}
		[__DynamicallyInvokable, SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Type GetType();
		[__DynamicallyInvokable, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		protected virtual void Finalize()
		{
		}
		[__DynamicallyInvokable, SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		protected extern object MemberwiseClone();
		[SecurityCritical]
		private void FieldSetter(string typeName, string fieldName, object val)
		{
			FieldInfo fieldInfo = this.GetFieldInfo(typeName, fieldName);
			if (fieldInfo.IsInitOnly)
			{
				throw new FieldAccessException(Environment.GetResourceString("FieldAccess_InitOnly"));
			}
			Message.CoerceArg(val, fieldInfo.FieldType);
			fieldInfo.SetValue(this, val);
		}
		private void FieldGetter(string typeName, string fieldName, ref object val)
		{
			FieldInfo fieldInfo = this.GetFieldInfo(typeName, fieldName);
			val = fieldInfo.GetValue(this);
		}
		private FieldInfo GetFieldInfo(string typeName, string fieldName)
		{
			Type type = this.GetType();
			while (null != type && !type.FullName.Equals(typeName))
			{
				type = type.BaseType;
			}
			if (null == type)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_BadType"), new object[]
				{
					typeName
				}));
			}
			FieldInfo field = type.GetField(fieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (null == field)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_BadField"), new object[]
				{
					fieldName,
					typeName
				}));
			}
			return field;
		}
	}
}
             * */
                
                
                
    /*        string source11 = @"
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
namespace LibraryForm
{   
    static class Program
    {
        // Главная точка входа для приложения.
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormNew1());
        }
    }
   
    partial class FormNew1
    {
        // Требуется переменная конструктора.
        
        private System.ComponentModel.IContainer components = null;
 
        >
        // Освободить все используемые ресурсы.
        
        // <param name= " + "\"" + "disposing" + "\"" + @" >истинно, если управляемый ресурс должен быть удален; иначе ложно.</param        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
 
        #region Код, автоматически созданный конструктором форм Windows
 
        >
        // Обязательный метод для поддержки конструктора - не изменяйте
        // содержимое данного метода при помощи редактора кода.
        
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 214);
            this.textBox1.Name = " + "\"" + "textBox1" + "\"" + @";
            this.textBox1.Size = new System.Drawing.Size(341, 20);
            this.textBox1.TabIndex = 0;
            //this.textBox1.Text = " + "\"" + "Проверка113" + "\"" + @";
            //this.textBox1.Text = typeof(FormNew1).Assembly.FullName" + @";
            this.textBox1.Text = AppDomain.CurrentDomain.FriendlyName" + @"; 
            
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormNew1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 471);
            this.Controls.Add(this.textBox1);
            this.Name = " + "\"" + "FormNew1" + "\"" + @";
            this.Text = " + "\"" + "FormNew1" + "\"" + @";
            this.ResumeLayout(false);
            this.PerformLayout();
 
        }
 
        #endregion
 
        private System.Windows.Forms.TextBox textBox1;
    }
    public partial class FormNew1 : Form
    {
        public FormNew1()
        {
            InitializeComponent();
        }
    }
}
";*/
                
                
                
                
                
		//List<string> TextBeforeInitializeComponent = new List<string>();
		//List<string> Text2       = new List<string>();
		//List<string> TextAfterInitializeComponent  = new List<string>();
		
		//ArrayList TextBeforeInitializeComponent = new ArrayList();
		
		//ArrayList TextInitializeComponent        = new ArrayList();
		
        //Text1.Add("bbbbbbbbbbbbbbbbbbbb");
        //Text2.Add("aaaaaaaaaaaaaaaaaaaa");
        //Text2.Add("bbbbbbbbbbbbbbbbbbbb"); 
        
        //MF.TextCompil.Lines =
		//TextAfterInitializeComponent.CopyTo(MF.TextCompil.Lines);
	    //List
		//textBox6.Text = array1.Aggregate("", (current, arrElement) => current + arrElement + " ").TrimEnd(' ');
		//MF.TextCompil.Text = Text1.ToArray().ToString();
		//System.ArgumentException: Длина результирующего массива недостаточна. Проверьте значения destIndex и length, а также нижние границы массива.
		//Text1.
		//MF.TextCompil.AppendText("aaaaaaaaaaaaaaaaaaaa" + Var.CR);
		//MF.TextCompil.AppendText("aaaaaaaaaaaaaaaaaaaa" + Var.CR);  
		//MF.TextCompil.AppendText("aaaaaaaaaaaaaaaaaaaa" + Var.CR);  
		//Array ar = new Array();
		//MF.TextCompil.Lines.CopyTo((Text1.), 1);
		    
		    //Length = 10;
		//Text1.CopyTo(MF.TextCompil.Lines);
		
		//StringList List3 = new StringList();
		
		//MF.TextCompil.Text = "";
		//Text2.ForEach(x => MF.TextCompil.Text += x + Var.CR);
		      
		    //MyWriteObjectList2(value);
		    //MF.TextCompil.AppendText(Var.CR + TextBeforeInitializeComponent + Var.CR);   
                
 //TextBeforeInitializeComponent += "this." + component.Site.Name + " = new " +  + "();" + Var.CR;
		       //TextBeforeInitializeComponent.                
                
		    //MF.TextCompil.AppendText("//" + Var.CR);
		    //TextInitializeComponent += "//" + Var.CR;
		     //MF.TextCompil.AppendText("// " + component.Site.Name + Var.CR);	
		        //MF.TextCompil.AppendText("//" + Var.CR);                
                
                
                
                
/*        
        void Button6Click(object sender, EventArgs e)
        {
          // Create a ContextStack.
            //ContextStack stack = new ContextStack();
            // Push ten items on to the stack and output the value of each.
            //for( int number = 0; number < 10; number ++ )
            //{
            //    Console.WriteLine( "Value pushed to stack: "+number.ToString() );
            //    stack.Push( number );
            //}
            // Pop each item off the stack.
            //object item = null;
            //while( (item = stack.Pop()) != null )
            //    TextCompil.AppendText(item.ToString());
                //Console.WriteLine( "Value popped from stack: "+item.ToString() );
                
            //string s;
           //return !IsNull(s)?s: "aaa";  //IsNull(s, s = "aaa"); 
           //MessageBox.Show(s);           
           //===================================================================
           // объект для сериализации
           /* Person person = new Person("Tom", 29);
            Console.WriteLine("Объект создан");
 
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"C:\Мусор\people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
 
                Console.WriteLine("Объект сериализован");
            }
 
            // десериализация из файла people.dat
            using (FileStream fs = new FileStream(@"C:\Мусор\people.dat", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);
 
                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Имя: {0} --- Возраст: {1}", newPerson.Name, newPerson.Age);
            }
 
            Console.ReadLine();*/
           //================
           
           
           /*Person person = new Person("Tom", 29);
            Person person2 = new Person("Bill", 25);
            Person[] people = new Person[] { person, person2 };
 
            // создаем объект SoapFormatter
            SoapFormatter formatter = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"C:\Мусор\people.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
 
                Console.WriteLine("Объект сериализован");
            }
 
            // десериализация
            using (FileStream fs = new FileStream(@"C:\Мусор\people.soap", FileMode.OpenOrCreate))
            {
                Person[] newPeople = (Person[])formatter.Deserialize(fs);
 
                Console.WriteLine("Объект десериализован");
                foreach (Person p in newPeople)
                {
                    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
                }
            }
            Console.ReadLine();
            */
           
           
           //===================
           /*Person person1 = new Person("Tom", 29);
           Person person2 = new Person("Bill", 25);
           Person[] people = new Person[] { person1, person2 };
 
           XmlSerializer formatter = new XmlSerializer(typeof(Person[]));
 
           using (FileStream fs = new FileStream(@"C:\Мусор\people.xml", FileMode.OpenOrCreate))
           {
               formatter.Serialize(fs, people);
           }
 
           using (FileStream fs = new FileStream(@"C:\Мусор\people.xml", FileMode.OpenOrCreate))
           {
               Person[] newpeople = (Person[])formatter.Deserialize(fs);
 
               foreach (Person p in newpeople)
               {
                   Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
               }
           }*/
           //============================
           
           
           /*Person person1 = new Person("Tom", 29, new Company("Microsoft"));
            Person person2 = new Person("Bill", 25, new Company("Apple"));
            Person[] people = new Person[] { person1, person2 };
 
            XmlSerializer formatter = new XmlSerializer(typeof(Person[]));
 
            using (FileStream fs = new FileStream(@"C:\Мусор\people2.xml", FileMode.OpenOrCreate))
            {
               formatter.Serialize(fs, people);
            }
 
            using (FileStream fs = new FileStream(@"C:\Мусор\people2.xml", FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])formatter.Deserialize(fs);
 
                foreach (Person p in newpeople)
                {
                    Console.WriteLine("Имя: {0} --- Возраст: {1} --- Компания: {2}", p.Name, p.Age, p.Company.Name);
                }
            }
            Console.ReadLine(); */
           //==================================           
            // объект для сериализации
            /*
            Person person1 = new Person("Tomm", 29);
            Person person2 = new Person("Bill", 25);
            Person[] people = new Person[] { person1, person2 };
 
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person[]));
 
            using (FileStream fs = new FileStream(@"C:\Мусор\people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, people);
            }
 
            using (FileStream fs = new FileStream(@"C:\Мусор\people.json", FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])jsonFormatter.ReadObject(fs);
 
                foreach (Person p in newpeople)
                {
                    //Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
                    TextCompil.AppendText("Имя:" + p.Name);
                    TextCompil.AppendText("Возраст:" + p.Age);
                }
            }
 
            Console.ReadLine();
            */
            //==============================================================
            //DT - в JSON           
            /*DataTable dt = new DataTable("asdasd");
            dt.Columns.AddRange (new DataColumn[]{new DataColumn ("col1", typeof(int)), new DataColumn("col2", typeof(string))});
            for (int i = 0; i < 100000; i++) 
            {
              dt.Rows.Add (i, "DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(DataTable))"); 
            }
           
            TextCompil.AppendText("Сериализация " + DateTime.Now.ToString() + "  ") ;
            //объект для сериализации
            //Person person1 = new Person("Tomm", 29);
            //Person person2 = new Person("Bill", 25);
            //Person[] people = new Person[] { person1, person2 };
 
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(DataTable));
 
            using (FileStream fs = new FileStream(@"C:\Мусор\people_DT_test1000.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, dt);
            }                             
            TextCompil.AppendText(DateTime.Now.ToString());
            TextCompil.AppendText(Var.CR);
            
            
            TextCompil.AppendText("ДЕ-Сериализация " + DateTime.Now.ToString() + "  ");
            TextCompil.AppendText(Var.CR);
            using (FileStream fs = new FileStream(@"C:\Мусор\people_DT_test1000.json", FileMode.OpenOrCreate))
            {
                DataTable DT2 = new DataTable();
                DT2 = (DataTable)jsonFormatter.ReadObject(fs);
                TextCompil.AppendText(DT2.Rows.Count.ToString());
                TextCompil.AppendText("ДЕ-Сериализация " + DateTime.Now.ToString() + "  ");
                dgvModule.DataSource = DT2;
            }
            */
           
            //======================================================================
            /*
            // объект для сериализации
            // DT в бинарник                       
            NewDT ndt = new NewDT();            
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"C:\Мусор\people_DT_Binary.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ndt);
 
                Console.WriteLine("Объект сериализован");
            } 
            Console.ReadLine();
           
           //===================================================
           
            // объект для сериализации                    
            //Form form1 = new Form(); 
            //Button button1 = new Button(); 
            string str = "";
            string [] linesjson = File.ReadAllLines(@"C:\Мусор\person123.json");
            //{"Age":29,"Name":"Tomm"}               
            str = linesjson[0];
            if (str == "") str = "Bill";
            MessageBox.Show(str);
            //return;
            
            Person person1 = new Person(str, 29);
            //Person person2 = new Person("Bill", 25);            
            //Person[] people = new Person[] { person1, person2 };            
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person)); 
            using (FileStream fs = new FileStream(@"C:\Мусор\person123.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, person1);
            }          
           
           XmlSerializer formatter = new XmlSerializer(typeof(Person)); 
           using (FileStream fs = new FileStream(@"C:\Мусор\person123.xml", FileMode.OpenOrCreate))
           {
               formatter.Serialize(fs, person1);
           }
           
        } //end void Button6Click
        */
         
        //void Button3Click(object sender, EventArgs e)
        //{
                //EventDescriptor sdd;
                //sdd.EventType.
            
            //string s = "CLICK";
          //      if (s.IndexOf("CLICK") > -1)
           //     {  
           //         MessageBox.Show("CLICK есть");
           //     }  
          //object obj = propertyGrid.SelectedObject;
          //MessageBox.Show(obj.ToString());
          //NewForm f1 = new NewForm();
          //f1.form1.Show();
              
        //}
                        
                
                
                
   /*     
        void Button9Click(object sender, EventArgs e)
        {
           //ProjectItem pi;
           //pi = 
           //int i = pi.DTE.Debugger.Breakpoints.Count;     
           // Получаем интерфейс ProjectItem
           //Projectitem pi = (Projectitem)Site.GetService(typeof(Projectitem));
                //ProjectItem pi = (ProjectItem)provider.GetService(typeof(ProjectItem));
                //Project project = pi.ContainingProject;
                //Projectitem pi = this.Site.GetService(typeof(FormMain)); 
                //int i = pi.DTE.Debugger.Breakpoints.Count();
                //this.
                
                Test2 t2 = new Test2();
                t2.NewForm();
                
               
  
   
        }
  */                      
                
                
                
/*             
                
[DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        public Person()
        {
        }
        
        public Person(string name, int year)
        {
            Name = name;
            Age = year;
        }                     
    }
                
    [Serializable]
    public class NewDT
    {   
        public NewDT ()
        {
            DT = new DataTable();
            DT.TableName = "sdfdf"; !!! Это нужно.
            DT.Columns.AddRange (new DataColumn[]{new DataColumn ("col1", typeof(int)), new DataColumn("col2", typeof(string))});
            DT.Rows.Add (234, "afsdfdsa");
            DT.Rows.Add (235, "af235a");
            DT.Rows.Add (12, "bbbbbb");
        }
        [DataMember]
        public DataTable DT;
        
                                     
    }
    
    [Serializable]
    public class NewForm
    {   
        
        public NewForm()
        {
            form1 = new Form();
            button1 = new Button();
            //form1.Controls.Add(button1);
        }
        [DataMember]
        public Form form1;
        
        [DataMember]
        public Button button1;
        
                                     
    }
    
    
    
    public class Test1
    {   
        public Form form1;      
        public Button button1;
        public virtual void NewForm()
        {
            form1 = new Form();
            form1.Text = "fdfd";
            button1 = new Button();
            //form1.Controls.Add(button1);
        }                                                         
    } 
    
    
    public class Test2: Test1
    {   
        public void NewForm()
        {
            base.NewForm();
            //form1 = new Form();
            //button1 = new Button();
            form1.Show();
        }
     }    
            
*/    
                
                
                
                
                
                
   
       
        
     
        
      
        
     
       
        //#endregion //Конец. Процедуры работы с формами.
        
       
            /*
             private void handler_button1_Click(object sender, EventArgs e)
            { MessageBox.Show("Привет!!!");} 
             */
            //Запуск в отдельном домене 1.
            /*AppDomain domain;
            richTextBox1.AppendText("Creating new AppDomain.");
            domain = AppDomain.CreateDomain("MyDomain", null);
            Assembly assembly = Assembly.LoadFile(PathModule);
            domain.CreateInstance(assembly.FullName, "form1Namespace.form1");
            Assembly assembly2 = Assembly.Load("LibraryForm444");
            Type type1 = assembly2.GetType("form1Namespace.form1");
            Form form22 = (Form)Activator.CreateInstance(type1);
            //form22.Show();
            AppDomain.Unload(domain);
            */
            
            //Работает! 
            //Запуск в отдельном домене 2. Не работает. После того как этот код отработает, файл LibraryForm444.dll удалить с диска нельзя.
            //AppDomain domain;
            /*AppDomain newD;
            newD = System.AppDomain.CreateDomain("newD");
            newD.CreateInstanceFrom(PathModule, "LibraryForm.FormNew1");
            Assembly assembly2 = (Assembly)newD.GetAssemblies().Where(x => x.FullName == "LibraryForm, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null").FirstOrDefault();
            Type type1 = assembly2.GetType("LibraryForm.FormNew1");
            Form form22 = (Form)Activator.CreateInstance(type1);
            form22.Show();
            form22 = null;
            type1 = null;
            assembly2 = null;
            AppDomain.Unload(newD);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            */
            //Запуск в отдельном домене 3.
            //String PathModule = @"C:\000_Travin\Projects C#\Проба дизайнер С#\111\form1Namespace.dll";
            /*if (System.IO.File.Exists(PathModule))
            {
                AppDomain newD;
                newD = System.AppDomain.CreateDomain("newD");
                newD.CreateInstanceFrom(PathModule, "form1Namespace.form1");
                foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (asm.FullName.Contains("System"))
                        newD.Load(asm.FullName);
                }
                //Directory.SetCurrentDirectory(@"C:\Мусор\");
                var sss = newD.GetAssemblies();
                
                Assembly assembly2 = (Assembly)newD.GetAssemblies().Where(x => x.FullName == "LibraryForm, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null").FirstOrDefault();
                Type type1 = assembly2.GetType("form1Namespace.form1");
                Form form22 = (Form)Activator.CreateInstance(type1);
                form22.Show();
                form22 = null;
                type1 = null;
                assembly2 = null;
                AppDomain.Unload(newD);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }*/
        
      
        
        
        
        /*void Button5Click(object sender, EventArgs e)
        {
            
            #region Рефлексия           
            //Type t = typeof(Button);
            Type t = button1.GetType();
            MethodInfo[] mi = t.GetMethods();
            
            string s = "";
            foreach (MethodInfo item in mi)
            {
                
                if (item.Name.IndexOf("Click") > 0)  
                {
                    //continue;
               
                
                ParameterInfo[] pi = item.GetParameters();
                s = "";
                foreach (ParameterInfo itemPar in pi)
                {                    
                    s = s + itemPar.Name + "(" + itemPar.ParameterType.ToString() + "); ";                   
                }
                rbLog.AppendText("Метод: " + item.Name + " Параметры: " + s + Var.CR); 
                }
            }
            #endregion          
            
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            Type type;     
            string s1,s2,s3,s4,str;
            
            
            
            // находим нужный исследуемый элемент управления на форме
            Control refs = this.button1; //CardControl.Controls.Find("МоиСсылки", true)[0];
            // и получаем его тип
            type = refs.GetType();
            
            EventInfo [] arrev = type.GetEvents();
            foreach (EventInfo ei in arrev) 
            {
                s1 = ei.Name;
                s2 = ei.ToString();
                PropertyInfo [] pi = ei.EventHandlerType.GetProperties();
                s3  = pi.ToString();
                
                rbLog.AppendText(s1 + " " + s2 + " " + s3 + "\n");
                
            }
            //EventInfo ei ;
            //ei = type.GetEvent("Click");
            
            
            
            
            //ArrayList members = new ArrayList();
            //type.
            //str = "";
            
            //MethodInfo mi = typeof(Button).GetMethod("Click");
            //ParameterInfo[] pars = mi.GetParameters();
            //foreach (ParameterInfo p in pars) 
            //{
                
            //    str += p.Name; 
                 //str += p.ParameterType + "\n";
               
            //}
            
            
            
            
            
            // перебираем все члены класса
            //foreach (MemberInfo imember in type.GetMembers())
            //{
            //  MethodInfo imethod = null;
              
              //type.
              // проверка на метод
              //if (imember is MethodInfo)
              //{
                //imethod = (MethodInfo)imember;
                //if (imethod != null)
                //{
                  // методы дополнительно фильтруем
                  //if (imethod.IsAbstract || imethod.IsConstructor || imethod.IsPrivate || imethod.IsVirtual || imethod.IsSpecialName) continue;
                //}
              //}
              // собираем только для одного нужного нам класса, исключая родительские 
              //if (imember.DeclaringType.Name != "ReferenceListView") continue; 
              // соберем все методы, свойства и события в список 
              //members.Add(imember); 
              // собираем информацию по членам класса в строку для дальнейшего вывода 
              //str += imember.Name + " (" + imember.MemberType.ToString() + ")" + "\n"; 
            //  richTextBox1.AppendText(imember.Name + " (" + imember.MemberType.ToString() + ")" + "\n");
            //} 
            
            //MessageBox.Show(str);
            //richTextBox1.AppendText(str);
            //return;
            // Поиск метода. В данном случае указываем дополнительные параметры поиска (типы параметров функции), так как нужный метод имеет две перегрузки (overload). 
             
            //MethodInfo createCard3 = type.GetMethod("CreateCard", new Type[] { typeof(LinksLinkType), typeof(Guid), typeof(KindsCardKind) });
            //!!!MethodInfo createCard3 = type.GetMethod("Show", new Type[] {});
            
            //!!!str = "";
            
            //!!!foreach (ParameterInfo pi in createCard3.GetParameters()) 
            //{!!! 
              // собираем информацию по параметрам метода в строку для дальнейшего вывода 
            //!!!  str += pi.ToString() + "\n"; 
            //!!!} 
            
            
             
             /* Работает!!! Получение параметров делегата
             Type delegateType = typeof(FormMain).GetEvent("ev").EventHandlerType;
             MethodInfo invoke = delegateType.GetMethod("Invoke");                         
             ParameterInfo[] pars = invoke.GetParameters();
             str = "";
             foreach (ParameterInfo p in pars)
             {
                //Console.WriteLine(p.ParameterType);
                str += p.ParameterType + "\n"; 
             }                                       
             MessageBox.Show(str); 
             */
              
             //Type delegateType = typeof(FormMain).GetMethod("Show").MemberType;
             //MethodInfo invoke = delegateType.GetMethod("Invoke");
             //Type t1 = typeof(Button);
             
             
             //richTextBox1.AppendText(imember.Name + " (" + imember.MemberType.ToString() + ")" + "\n");
             
             
             //MessageBox.Show(str); 
            
            // получаем доступные типы ссылок 
            /*PropertyInfo alt_prop = type.GetProperty("AllowedLinkTypes"); 
            MessageBox.Show(alt_prop.ToString()); 
            
            List<LinksLinkType> alts = (List<LinksLinkType>)alt_prop.GetValue(refs, new Object[] {}); 
            
            // берем первый попавшийся тип ссылок 
            LinksLinkType llt = alts[0]; 
            // выбираем GUID 
            //!!!Guid guid = this.CardData.Type.Id; 
            // выбираем вид карточки 
            //!!!KindsCardKind kck = this.CardControl.ObjectContext.GetObject<KindsCardKind>(new Guid("4ECE3759-A547-48FE-A54C-569C590F0BCA")); 
            
            // задаем массив параметров для метода 
            object[] ps = new Object[] { llt, guid, kck }; 
            // вызываем полученный выше метод с параметрами 
            //!!!createCard3.Invoke(refs, ps);    
            
        }
        */
        /*
        void Button2Click(object sender, EventArgs e)
        {
            Type type;
            String str;
            string s = "";
            string s1, s2, s3, s4, s5, s6, s7;
            Control refs = this.button1; //CardControl.Controls.Find("МоиСсылки", true)[0];
            type = refs.GetType();
            //ArrayList members = new ArrayList();
            //type.
            //str = "";
            // перебираем все члены класса
            foreach (MemberInfo imember in type.GetEvents())
            {        
                //ParameterInfo[] pi = imember.GetParameters();
                //s = "";
               // foreach (ParameterInfo itemPar in pi)
                //{                    
                //    s = s + itemPar.Name + "(" + itemPar.ParameterType.ToString() + "); ";                   
                //}
                //s = ;
                
                //s = "Click";                   
                //if (s.IndexOf(imember.MemberType.ToString()) == 0)
                //{  
                //    continue;
                //}
             
                s = imember.MemberType.ToString();
                if (s.IndexOf("Click") == -1)
                {  
                    continue;
                }
                                              
                s1 = imember.Name;
                s2 = imember.MemberType.ToString();
                s3 = imember.Module.ToString();
                s4 = imember.ReflectedType.ToString();
                s5 = imember.MetadataToken.ToString();
                s6 = imember.DeclaringType.ToString();
                rbLog.AppendText(" Name: "          + s1 + 
                                        " MemberType: "    + s2 +                                     
                                        " Module: "        + s3 + 
                                        " ReflectedType: " + s4 +
                                        " MetadataToken: " + s5 +
                                        " DeclaringType: " + s6 +                                      
                                        "\n");
                
            }  
            
               
                
            
        }
       
        
        void PropertyGridControlAdded(object sender, ControlEventArgs e)
        {
            
        }
        // Пока имени компонента и его класса на форме.
        void PropertyGridSelectedObjectsChanged(object sender, EventArgs e)
        {
            object obj = propertyGrid.SelectedObject;
            if (obj == null) 
            {
                return;
            }
            
            
            string s = obj.ToString();
            
            //if (propertyGrid.SelectedObject.GetType() == typeof(Button))
            //{
            //    string s2 = (propertyGrid.SelectedObject as Button).Name;            
            //    MessageBox.Show(s2);
            //}
            
            //checkBox1 [System.Windows.Forms.CheckBox], CheckState: 0
            int i1 = s.IndexOf("[");
            int i2 = s.IndexOf("]");
            string ComponentName  = (propertyGrid.SelectedObject as Control).Name;    //s.Substring(0, i1 - 1);
            string ComponentClass = s.Substring(i1 + 1, i2 - i1 - 1);
            ComponentClass = ComponentClass.Replace("System.Windows.Forms.", "");
            tbComponentName.Text  = ComponentName;
            tbComponentClass.Text = ComponentClass;            
        }
        
        void Panel2Paint(object sender, PaintEventArgs e)
        {
            
        }
        
        void TbComponentNameLeave(object sender, EventArgs e)
        {
        }
        
        void TbComponentNameDoubleClick(object sender, EventArgs e)
        {
            if (propertyGrid.SelectedObject == null) return;                  
            (propertyGrid.SelectedObject as Control).Site.Name = tbComponentName.Text;
            
            //Component cv1;
            //cv1.
            //Control cv2;
            //cv2.Co
            //if(result != null)
            //{
            //    result.Name = tbComponentName.Text; // контрол найден
            //}
            //else
            //{
            //    MessageBox.Show("контрола с таким именем нету");
            //}
            //(obj as Button).Name = "aaa";                      
            //Control result = this.Controls.Find(s, true).FirstOrDefault();
            //string s = (obj as Button).Name = "aaa"; // = tbComponentName.Text;            
            //Control result = this.Controls.Find(s, true).FirstOrDefault();
            //if(result != null) result.Name = "bbb";
            
            
            
            
           /* <Object type="System.Windows.Forms.Button, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" name="button3" children="Controls">
                <Property name="BackColor">Red</Property>
                <Property name="Text">button3</Property>
                <Property name="UseCompatibleTextRendering">True</Property>
                <Property name="UseVisualStyleBackColor">False</Property>
                <Property name="DataBindings">
                <Property name="DefaultDataSourceUpdateMode">OnValidation</Property>
                </Property>
                <Property name="Location">75, 158</Property>
                <Property name="Name">button3</Property>
                <Property name="Size">75, 23</Property>
                <Property name="TabIndex">2</Property>
            </Object>
                
                 this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(75, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseCompatibleTextRendering = true;
            this.button3.UseVisualStyleBackColor = false;
            
                
            
        }
        */                
                
                
                
                
            //switch (e.Index)
            //{
            //    case 0: e.Graphics.FillRectangle(Brushes.SteelBlue, e.Bounds);
            //        break;
            //    case 1: e.Graphics.FillRectangle(Brushes.Gold, e.Bounds);
            //        break;
            //    case 2: e.Graphics.FillRectangle(Brushes.Tomato, e.Bounds);
            //        break;
            //    case 3: e.Graphics.FillRectangle(Brushes.LimeGreen, e.Bounds);
            //        break;
            //}
                
                
                
                
/*private void menuItemNew_Click(object sender, System.EventArgs e)
        {
            if (DestroyDesigner()) // make sure we're clear for a new designer
            {
                // A loader created with no parameters creates a blank document.
                SampleDesignerLoader designerLoader = new SampleDesignerLoader(this);
                CreateDesigner(designerLoader);
            }
        } */               
                
                
                
/*                
private void menuItemOpen_Click(object sender, System.EventArgs e)
        {
            if (DestroyDesigner()) // make sure we're clear for a new designer
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Load up this file (XML is all we support for now).
                    SampleDesignerLoader designerLoader = new SampleDesignerLoader(openFileDialog.FileName, this);
                    CreateDesigner(designerLoader);
                }
            }
        } */
/*
 // The user gets to choose between saving in XML, C#, or VB.
        // Just remember that you can only load XML.
        private void menuItemSave_Click(object sender, System.EventArgs e)
        {
            loader.Save(false); // false == don't force file dialog if file already chosen
        }
        // The user gets to choose between saving in XML, C#, or VB.
        // Just remember that you can only load XML.
        private void menuItemSaveAs_Click(object sender, System.EventArgs e)
        {
            loader.Save(true); // true == force file dialog even if file already chosen
        }
        // Try to close our form. Our OnClosing method will check to make sure our stuff
        // is saved before closing.
        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            if (DestroyDesigner()) this.Close();            
        }
        // The loader also handles building. It keeps a codeCompileUnit that represents
        // the state of the document at any time. The user will be prompted for an executable
        // filename the first time there's a build.
        private void menuItemBuild_Click(object sender, System.EventArgs e)
        {
            loader.Build();
        }
        // This builds to the executable the user has selected and then runs it.
        private void menuItemRun_Click(object sender, System.EventArgs e)
        {
            loader.Run();
        }
        // Another way to kill any running executable.
        private void menuItemStop_Click(object sender, System.EventArgs e)
        {
            loader.Stop();
        }*/                
                
                
                
                
                
/*
  // The rest of the MenuItem click events are handled here. Most of these MenuItems
        // require a loaded host to have any applicable use--thus they are disabled
        // if there isn't one.
        private void menuItem_Click(object sender, System.EventArgs e)
        {            
            //return;           
            // The IMenuCommandService makes doing common commands easy.
            // It keeps track of what commands and verbs the designer supports
            // and can invoke them given members of the MenuCommands enum (CommandID's).            
            //В IMenuCommandService делает основные команды простой. Он отслеживает, какие команды и
            //глаголы дизайнер поддерживает и может вызвать их членов MenuCommands перечисление (CommandID)
            IServiceContainer sc = host as IServiceContainer;
            IMenuCommandService mcs = sc.GetService(typeof(IMenuCommandService)) as IMenuCommandService;
            switch ((sender as MenuItem).Text)
            {
                case "Cu&t": mcs.GlobalInvoke(StandardCommands.Cut);
                    break;
                case "&Copy": mcs.GlobalInvoke(StandardCommands.Copy);
                    break;
                case "&Paste": mcs.GlobalInvoke(StandardCommands.Paste);
                    break;
                case "&Delete": mcs.GlobalInvoke(StandardCommands.Delete);
                    break;
                case "Select &All": mcs.GlobalInvoke(StandardCommands.SelectAll);
                    break;
                case "&Service Requests":
                    if (serviceRequests == null)
                    {
                        serviceRequests = new ServiceRequests();
                        serviceRequests.Closed += new EventHandler(OnServiceRequestsClosed);
                        // Our designer host looks for this service to announce the success / failure
                        // of service requests.
                        hostingServiceContainer.AddService(typeof(ServiceRequests), serviceRequests);
                        serviceRequests.Show();
                    }
                    serviceRequests.Activate();
                    break;
                case "&Design": tabControl.SelectedTab = tab1;
                    break;
                //case "&C# Source": tabControl.SelectedTab = tab2;
                 //   break;
                //case "&VB Source": tabControl.SelectedTab = tab3;
                //    break;
                //case "&XML": tabControl.SelectedTab = tab4;
                //    break;
                case "&Properties": mcs.GlobalInvoke(MenuCommands.Properties);
                    break;
                case "Show &Grid":
                    mcs.GlobalInvoke(StandardCommands.ShowGrid);
                    menuItemShowGrid.Checked = !menuItemShowGrid.Checked;
                    break;
                case "S&nap to Grid":
                    mcs.GlobalInvoke(StandardCommands.SnapToGrid);
                    menuItemSnapToGrid.Checked = !menuItemSnapToGrid.Checked;
                    break;
                
                    
                    
                case "&Lefts": mcs.GlobalInvoke(StandardCommands.AlignLeft);
                    break;
                case "&Rights": mcs.GlobalInvoke(StandardCommands.AlignRight);
                    break;
                case "&Tops": mcs.GlobalInvoke(StandardCommands.AlignTop);
                    break;
                case "&Bottoms": mcs.GlobalInvoke(StandardCommands.AlignBottom);
                    break;
                case "&Middles": mcs.GlobalInvoke(StandardCommands.AlignHorizontalCenters);
                    break;
                case "&Centers": mcs.GlobalInvoke(StandardCommands.AlignVerticalCenters);
                    break;
                case "to &Grid": mcs.GlobalInvoke(StandardCommands.AlignToGrid);
                    break;
                
                    
                case "&Horizontally": mcs.GlobalInvoke(StandardCommands.CenterHorizontally);
                    break;
                case "&Vertically": mcs.GlobalInvoke(StandardCommands.CenterVertically);
                    break;
                
                
                case "&Control": mcs.GlobalInvoke(StandardCommands.SizeToControl);
                    break;
                case "Control &Width": mcs.GlobalInvoke(StandardCommands.SizeToControlWidth);
                    break;
                case "Control &Height": mcs.GlobalInvoke(StandardCommands.SizeToControlHeight);
                    break;
                case "&Grid": mcs.GlobalInvoke(StandardCommands.SizeToGrid);
                    break;
                case "&Bring to Front": mcs.GlobalInvoke(StandardCommands.BringToFront);
                    break;
                case "&Send to Back": mcs.GlobalInvoke(StandardCommands.SendToBack);
                    break;
                case "&Tab Order": mcs.GlobalInvoke(StandardCommands.TabOrder);
                    break;
            }
        }
* /                
* 
* 
* 
* 
* 
* 
/*
 * 
 private bool DestroyDesigner()
        {
            if (loader != null)
            {
                //if (loader.PromptDispose())
                //{
                    // Again, bad things happen if there's no host loaded and 
                    // certain buttons are pressed in our TabControl or MainMenu.
                    //
                    //tabControl.Visible   = false;
                    //menuItemSave.Enabled   = false;
                    //menuItemSaveAs.Enabled = false;
                    //menuItemEdit.Enabled   = false;
                    //menuItemView.Enabled   = false;
                    //menuItemLayout.Enabled = false;
                    //menuItemDebug.Enabled  = false;
                    // Get rid of our document window.
                    panelMain.Controls.Clear();
                    // No need to filter for designer-intended keyboard strokes now.
                    Application.RemoveMessageFilter(filter);
                    filter = null;
                    // Get rid of that property grid site so it doesn't ask for
                    // any more services from our soon-to-be-disposed host.
                    //
                    propertyGrid.Site = null;
                    host.Dispose();
                    loader = null;
                    host = null;
                    return true;
                //}
                //return false;
            }
            return true;
        }
* / 
* 
* 
* 
* 
/*
 *  //OwnerDraw for that rainbow look.
        private void tabControl_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            TabControl tcSender = sender as TabControl;
            string text = tcSender.TabPages[e.Index].Text;
            Size textSize = e.Graphics.MeasureString(text, tcSender.Font).ToSize();
            e.Graphics.FillRectangle(Brushes.SteelBlue, e.Bounds);
            Point textLocation = new Point(
                e.Bounds.X + (e.Bounds.Width - textSize.Width) / 2,
                e.Bounds.Y + (e.Bounds.Height - textSize.Height) / 2);
            e.Graphics.DrawString(text, tcSender.Font, Brushes.Gold, textLocation);
        }
    
 * / 
 * 
 * 
 *         //Компиляция и запись формы в БД.  
        //void btnSaveOldClick(object sender, EventArgs e)
        //{
         //   SaveAndCompilModule(tbModuleID.Text, tbModuleType.Text, tbprojectName.Text, "MethodFlushOld");
        //}
              
        //Компиляция и запись формы в БД.           
        //private void BtnModuleSaveClick(object sender, EventArgs e)
        //{
        //    SaveAndCompilModule(tbModuleID.Text, tbModuleType.Text, tbprojectName.Text, "MethodFlush");
        //}
            
            
            
            
/*
 * 
        //ReLoad test
        void Button8Click(object sender, EventArgs e)
        {
            SampleDesignerLoader designerLoader = new SampleDesignerLoader(this);
            host.designerLoader.Dispose();
            host.designerLoader = designerLoader;              
        } 
        void Button4Click(object sender, EventArgs e)
        {
            File.Delete(@"C:\Мусор\ListProc.txt");
        }   
  */          
                
                
        /*
		// Called when we want to build an executable. Returns true if we succeeded.
		internal bool Build()
		{
			if (dirty)
			{
				// Flush any changes made to the buffer.
				Flush();
			}
			// If we haven't already chosen a spot to write the executable to,
			// do so now.
			//
			if (executable == null)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.DefaultExt = "exe";
				dlg.Filter = "Executables|*.exe";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					executable = dlg.FileName;
				}
			}
			if (executable != null)
			{
				// We'll need our type resolution service in order to find out what
				// assemblies we're dealing with.
				//
				SampleTypeResolutionService strs = host.GetService(typeof(ITypeResolutionService)) as SampleTypeResolutionService;
				
				// We need to collect the parameters that our compiler will use.
				CompilerParameters cp = new CompilerParameters();
				// First, we tell our compiler to reference the assemblies which
				// our designers have referenced (the ones which have import statements
				// in our codeCompileUnit).....
				//
				foreach(Assembly assm in strs.RefencedAssemblies)
				{
					cp.ReferencedAssemblies.Add(assm.Location);
					// .....then we have to look at each one of those assemblies,
					// see which assemblies they reference, and make sure our compiler
					// references those too! Phew!
					//
					foreach (AssemblyName refAssmName in assm.GetReferencedAssemblies())
					{
						Assembly refAssm = Assembly.Load(refAssmName);
						cp.ReferencedAssemblies.Add(refAssm.Location);
					}
				}
				cp.GenerateExecutable = true;
				cp.OutputAssembly = executable;
				// Remember our main class is not Form, but Form1 (or whatever the user calls it)!
				cp.MainClass = host.RootComponent.Site.Name + "Namespace." + host.RootComponent.Site.Name;
				ICodeCompiler cc = new CSharpCodeProvider().CreateCompiler();
				CompilerResults cr = cc.CompileAssemblyFromDom(cp, codeCompileUnit);
				if (cr.Errors.HasErrors)
				{
					string errors = "";
					foreach (CompilerError error in cr.Errors)
					{
						errors += error.ErrorText + "\n";
					}
					sys.SM(errors, "Error during compile.");
				}
				return !cr.Errors.HasErrors;
			}
			return false;
			
			
		}*/                
                
                
                
		/*
		// Save the current state of the loader. If the user loaded the file
		// or saved once before, then he doesn't need to select a file again.
		// Unless this is being called as a result of "Save As..." being clicked,
		// in which case forceFilePrompt will be true.
		// Сохранить текущее состояние погрузчика. Если пользователь Загрузил файл или 
		// сохранена однажды, то ему не нужно снова выбрать файл. Если это вызывается в 
		// результате "Сохранить как..." нажал, и в этом случае forceFilePrompt будет правдой.
		internal void Save(bool forceFilePrompt) 
		{
			try
			{
				if (dirty) 
				{
					// Flush any changes to the buffer.
					Flush();
				}
				
				// If the buffer has no name or this is a "Save As...",
				// prompt the user for a file name. The user can save
				// either the C#, VB, or XML (though only the XML can be loaded).
				//
				int filterIndex = 3;
				if ((fileName == null) || forceFilePrompt) 
				{
					SaveFileDialog dlg = new SaveFileDialog();
					dlg.DefaultExt = "xml";
					dlg.Filter = "C# Files|*.cs|Visual Basic Files|*.vb|XML Files|*.xml";
					if (dlg.ShowDialog() == DialogResult.OK) 
					{
						fileName = dlg.FileName;
						filterIndex = dlg.FilterIndex;
					}
				}
				if (fileName != null) 
				{
					switch (filterIndex)
					{
						case 1:
						{
							// Generate C# code from our codeCompileUnit and save it.
							CodeGeneratorOptions o = new CodeGeneratorOptions();
							o.BlankLinesBetweenMembers = true;
							o.BracingStyle = "C";
							o.ElseOnClosing = false;
							o.IndentString = "    ";
							StreamWriter sw = new StreamWriter(fileName);
							CSharpCodeProvider cs = new CSharpCodeProvider();
							cs.CreateGenerator().GenerateCodeFromCompileUnit(codeCompileUnit, sw, o);
							sw.Close();
						} break;
						case 2:
						{
							// Generate VB code from our codeCompileUnit and save it.
							CodeGeneratorOptions o = new CodeGeneratorOptions();
							o.BlankLinesBetweenMembers = true;
							o.BracingStyle = "C";
							o.ElseOnClosing = false;
							o.IndentString = "    ";
							StreamWriter sw = new StreamWriter(fileName);
							VBCodeProvider vb = new VBCodeProvider();
							vb.CreateGenerator().GenerateCodeFromCompileUnit(codeCompileUnit, sw, o);
							sw.Close();
						} break;
						case 3:
						{
							// Write out our xmlDocument to a file.
							StringWriter sw = new StringWriter();
							XmlTextWriter xtw = new XmlTextWriter(sw);
							xtw.Formatting = Formatting.Indented;
							xmlDocument.WriteTo(xtw);
							// Get rid of our artificial super-root before we save out
							// the XML.
							//
							string cleanup = sw.ToString().Replace("<DOCUMENT_ELEMENT>", "");
							cleanup = cleanup.Replace("</DOCUMENT_ELEMENT>", "");
							xtw.Close();
							StreamWriter file = new StreamWriter(fileName);
							file.Write(cleanup);
							file.Close();
						} break;
					}
					unsaved = false;
				}
			}
			catch(Exception ex)
			{
				sys.SM("Error during save: " + ex.Message
			}
		}*/                
                
                
                
		//Получение кода XML для формы и кода CS.
		/*public override void Flush()
		{				
			//Форфмирование кода XML.
		    XmlDocument document = new XmlDocument();
			root = host.RootComponent;
			document.AppendChild(document.CreateElement("DOCUMENT_ELEMENT"));
			string s = root.ToString();
			Hashtable nametable = new Hashtable(host.Container.Components.Count);
			document.DocumentElement.AppendChild(WriteObject(document, nametable, root));            			
			foreach(IComponent comp in host.Container.Components)
			{
				if (comp != root && !nametable.ContainsKey(comp))				
					document.DocumentElement.AppendChild(WriteObject(document, nametable, comp));									
			}					
			StringWriter sw;
			sw = new StringWriter();
			XmlTextWriter xtw = new XmlTextWriter(sw);
			xtw.Formatting = Formatting.Indented;
			//xmlDocument = document;
			document.WriteTo(xtw);
			// Get rid of our artificial super-root before we display the XML.
			// Избавиться от искусственных супер-корень, прежде чем мы отобразим XML-данные.
			string cleanup = sw.ToString().Replace("<DOCUMENT_ELEMENT>", "");
			cleanup = cleanup.Replace("</DOCUMENT_ELEMENT>", "");
			MF.textXML.Text = cleanup;
			sw.Close();
			
			//Формирование исполняемого кода.
			string CodeRun = MyWriteObjectList1(root);			
			MF.textCS.Text = 
			    "namespace FBACode {" + Var.CR + 
			    "using System;               " + Var.CR + 
                "using System.Windows.Forms; " + Var.CR +
			    "using System.Drawing;       " + Var.CR +
			    "public class " + root.Site.Name + " : System.Windows.Forms.Form " + Var.CR + 
			    "{private System.ComponentModel.IContainer components = null; " + "\r\n\r\n" +
			    CodeRun + Var.CR +              //Код InitializeComponent.
                MF.textCode.Text + "\r\n\r\n" + //Прикладной код.		    
			    "protected override void Dispose(bool disposing){ " + Var.CR + 
                "if (disposing && (components != null)){components.Dispose();} " + Var.CR +
                "base.Dispose(disposing); " + Var.CR +
                "Application.Exit();}  }} ";		    
		}*/						
		                
                
                
       /*         
	    // This method is called by the designer host whenever it wants the
		// designer loader to flush any pending changes.  Flushing changes
		// does not mean the same thing as saving to disk.  For example,
		// In Visual Studio, flushing changes causes new code to be generated
		// and inserted into the text editing window.  The user can edit
		// the new code in the editing window, but nothing has been saved
		// to disk.  This sample adheres to this separation between flushing
		// and saving, since a flush occurs whenever the code windows are
		// displayed or there is a build. Neither of those items demands a save. 
		// Этот метод вызывается конструктором хозяина, когда он хочет конструктор погрузчик, чтобы 
		// очистить все ожидающие изменения. Промывка изменения не означает то же самое, что сохранение 
		// на диск. Например, в Visual студии, запись изменений вызывает новый код генерируется и 
		// вставляется в окно редактирования текста. Пользователь может редактировать новый код в окне 
		// редактирования, но ничего не сохраняется на диск. В этом примере придерживается этого 
		// разделения между топить и экономить, так как сброс происходит всякий раз, когда отображается 
		// код окна или построить. Ни один из этих предметов требует сохранить.
		public void FlushOld2()
		{
			// Nothing to flush if nothing has changed.
			// Ничего не смывать, если ничего не изменилось.
			//if (!dirty) 
			//{
			//	return;
			//}
			// We use an XmlDocument to build up the XML for the designer.  Here is a sample XML chunk:
			// Мы используем xmldocument для создания XML для дизайнера. Вот пример фрагмента XML-файле:
			XmlDocument document = new XmlDocument();
			// This element will serve as the undisputed DocumentElement (root)
			// of our document. This allows us to have objects of equal level below,
			// which we need, since component tray items are not children of the form. 
            // Этот элемент будет служить в качестве бесспорного функцию documentelement (корень) 
            // нашего документа. Это позволяет нам иметь объектам равного уровня ниже, который нам 
            // нужен, с комплектующими лоток не детей форме.
			document.AppendChild(document.CreateElement("DOCUMENT_ELEMENT"));
			// We start with the root component and then continue to all the rest of the components.  
            // The nametable object we create keeps track of which objects we have seen.  As we write 
            // out an object's contents, we save it in the nametable, so we don't write out an object
			// twice. 
			// Мы начали с основного компонента, а затем продолжить все остальные компоненты. Объект мы 
			// создаем отслеживает, какие объекты мы видели. Как мы выписываем содержимое объекта, мы 
			//сохранить его в nametable, поэтому мы не выписываем два объекта.
			root = host.RootComponent;
			string s = root.ToString();
			Hashtable nametable = new Hashtable(host.Container.Components.Count);
			document.DocumentElement.AppendChild(WriteObject(document, nametable, root));            			
			foreach(IComponent comp in host.Container.Components)
			{
				if (comp != root && !nametable.ContainsKey(comp))				
					document.DocumentElement.AppendChild(WriteObject(document, nametable, comp));									
			}
			//string CodeRun = MyWriteObjectList1(root);
 
			// Along with the XML, we also represent the designer in a CodeCompileUnit,
			// which we can use to generate C# and VB, and which we can compile from.
			CodeCompileUnit code = new CodeCompileUnit();
			// Our dummy namespace is the name of our main form + "Namespace". Creative, eh?
			CodeNamespace ns = new CodeNamespace(root.Site.Name + "Namespace");
			ns.Imports.Add(new CodeNamespaceImport("System"));
			// We need to look at our type resolution service to find out what references
			// to import.
						
			SampleTypeResolutionService strs = host.GetService(typeof(ITypeResolutionService)) as SampleTypeResolutionService;
			foreach (Assembly assm in strs.RefencedAssemblies)
			{
				ns.Imports.Add(new CodeNamespaceImport(assm.GetName().Name));
			}		
			
			// Autogenerates member declaration and InitializeComponent()
			// in a new CodeTypeDeclaration
			RootDesignerSerializerAttribute a = TypeDescriptor.GetAttributes(root)[typeof(RootDesignerSerializerAttribute)] as RootDesignerSerializerAttribute;
			//MessageBox.Show(a.SerializerTypeName);
			Type t = host.GetType(a.SerializerTypeName);
			CodeDomSerializer cds = Activator.CreateInstance(t) as CodeDomSerializer;
			IDesignerSerializationManager manager = host.GetService(typeof(IDesignerSerializationManager)) as IDesignerSerializationManager;
			CodeTypeDeclaration td = cds.Serialize(manager, root) as CodeTypeDeclaration;
            
			
           //if (MF.FirstTime == 1)
           //{
			//  a = TypeDescriptor.GetAttributes(root)[typeof(RootDesignerSerializerAttribute)] as RootDesignerSerializerAttribute;
			//  //MessageBox.Show(a.SerializerTypeName);
			//  t = host.GetType(a.SerializerTypeName);
			//  cds = Activator.CreateInstance(t) as CodeDomSerializer;
			 // manager = host.GetService(typeof(IDesignerSerializationManager)) as IDesignerSerializationManager;
			//  td = cds.Serialize(manager, root) as CodeTypeDeclaration;
			//  td = cds.Serialize(manager, root) as CodeTypeDeclaration;
			//  MF.FirstTime = 2;
           //}
		   //CodeTypeDeclaration td = cds.Serialize(manager, root) as CodeTypeDeclaration;
           //object codeObject = cds.Serialize(manager, root);
           //string ss2 = codeObject.ToString();
          
           // first, let the default serializer do its work:
           var baseSerializer = (CodeDomSerializer)manager.GetSerializer(
                             typeof(Form).BaseType, typeof(CodeDomSerializer));
           object codeObject = baseSerializer.Serialize(manager, root);
        			
			//We need a constructor that will call the InitializeComponent() that we just generated.
            //Нам нужен конструктор, который будет вызывать метод initializecomponent (), который мы только что создали.			
            CodeConstructor con = new CodeConstructor();
			con.Attributes = MemberAttributes.Public;
			con.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "InitializeComponent")));
			td.Members.Add(con);
			
			// Finally our Main method, where the magic begins.			
			CodeEntryPointMethod main = new CodeEntryPointMethod();
			main.Name = "Main";
			main.Attributes = MemberAttributes.Public | MemberAttributes.Static;
            main.CustomAttributes.Add(new CodeAttributeDeclaration("System.STAThreadAttribute")); //System.STAThreadAttribute
			main.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
				new CodeTypeReferenceExpression(
				typeof(System.Windows.Forms.Application)), "Run"), 
				new CodeExpression[] {
										new CodeObjectCreateExpression(new CodeTypeReference(root.Site.Name))
									 }));			
			td.Members.Add(main); 		
			ns.Types.Add(td);
			//ns.Types.Add(codeObject as CodeTypeDeclaration);			
			
			code.Namespaces.Add(ns);
			// Now we reset our dirty bit and set the member
			// variables.
			//dirty = false;
			xmlDocument = document;
			codeCompileUnit = code;
            			
			//StringWriter sw;
            // The options for our code generation.
			//CodeGeneratorOptions o = new CodeGeneratorOptions();
			//o.BlankLinesBetweenMembers = true;
			//o.BracingStyle = "C";
			//o.ElseOnClosing = false;
			//o.IndentString = "    ";
			
			//sw = new StringWriter();
			//TabControl tc = host.GetService(typeof(TabControl)) as TabControl;
			//TextBox csWindow  = tc.TabPages[1].Controls[0] as TextBox;
			//CSharpCodeProvider cs = new CSharpCodeProvider();
			//cs.CreateGenerator().GenerateCodeFromCompileUnit(codeCompileUnit, sw, o);
			//csWindow.Text = sw.ToString();
			//sw.Close();
			
			
			// Now we update the code windows to show what new stuff we've learned.
			UpdateCodeWindows();					
		}
		// This method writes out the contents of our designer in C#, VB, and XML.
		// For the first two, it generates code from our codeCompileUnit. For the XML,
		// it writes out the contents of xmlDocument.
		private void UpdateCodeWindows()
		{
			// The main form's TabControl was added to the host's lists of services
			// just so we could get at it here. Fortunately for us, each tab page
			// has but one Control--a textbox. 
			
			//TabControl tc = host.GetService(typeof(TabControl)) as TabControl;
            //TextBox csWindow  = tc.TabPages[2].Controls[0] as TextBox;  
            //TextBox vbWindow  = tc.TabPages[3].Controls[0] as TextBox;
            //TextBox xmlWindow = tc.TabPages[4].Controls[0] as TextBox;
            
            //TextBox csWindow = host.textCS;   // tc.TabPages[1].Controls[0] as TextBox;
            //TextBox vbWindow = host.textVB;   // tc.TabPages[2].Controls[0] as TextBox;
            //TextBox xmlWindow = host.textXML; // tc.TabPages[3].Controls[0] as TextBox;
			
			// The string writer we'll generate code to.
			StringWriter sw;
			// The options for our code generation.
			CodeGeneratorOptions o = new CodeGeneratorOptions();
			o.BlankLinesBetweenMembers = true;
			o.BracingStyle = "C";
			o.ElseOnClosing = false;
			o.IndentString = "    ";
			// CSharp Code Generation
			sw = new StringWriter();
			CSharpCodeProvider cs = new CSharpCodeProvider();
			cs.CreateGenerator().GenerateCodeFromCompileUnit(codeCompileUnit, sw, o);		            
            String CodeCS = sw.ToString();                       
			sw.Close();
			// VB Code Generation
			//sw = new StringWriter();
			//VBCodeProvider vb = new VBCodeProvider();
			//vb.CreateGenerator().GenerateCodeFromCompileUnit(codeCompileUnit, sw, o);
			//vbWindow.Text = sw.ToString();
			//MF.textVB.Text = sw.ToString();
			//sw.Close();
			// XML Output
			sw = new StringWriter();
			XmlTextWriter xtw = new XmlTextWriter(sw);
			xtw.Formatting = Formatting.Indented;
			xmlDocument.WriteTo(xtw);
			// Get rid of our artificial super-root before we display the XML.
			// Избавиться от искусственных супер-корень, прежде чем мы отобразим XML-данные.
			string cleanup = sw.ToString().Replace("<DOCUMENT_ELEMENT>", "");
			cleanup = cleanup.Replace("</DOCUMENT_ELEMENT>", "");
			//xmlWindow.Text = cleanup;
			MF.textXML.Text = cleanup;
			sw.Close();
			//csWindow - это окно оконнчательного кода с InitializeComponent и прикладным кодом вместе.
			//CodeCS - код с InitializeComponent, но без прикладного кода.
			//MF.textCode.Text - только прикладной код.
			//Потому грубо говоря нам нужно это: csWindow.Text = CodeCS + MF.textCode.Text;
			String DisposeStr =
            @"      protected override void Dispose(bool disposing)
            {
               if (disposing && (components != null)){
                 components.Dispose();
               }
               base.Dispose(disposing);
               Application.Exit();
           }
           ";
		   //Добавление в тавтоматически сгенирированный текст, содержащий InitializeComponent строку DisposeStr.	
		   CodeCS = AddProcedure(CodeCS, DisposeStr);
           CodeCS = AddVariable(CodeCS, "       private System.ComponentModel.IContainer components = null;");            
           //TextBox tb1 = host.GetService(typeof(TextBox)) as TextBox;
           //CodeCS = AddProcedure(CodeCS, tb1.Text);
            
           //Добавляем прикладной код. 
           CodeCS = AddProcedure(CodeCS, MF.textCode.Text);
           //csWindow.Text = source11; // CodeCS;
           //csWindow.Text = CodeCS; // CodeCS; 
           MF.textCS.Text = CodeCS;    
           //textXML;
           //textVB;            
		}
		
		*/
                
                
                
		
		//=========================================================================================== 
		//===========================================================================================    
		//===========================================================================================  		
		//===========================================================================================		
		//Сборка блока кода InitializeComponent
		/*public string MyWriteObjectList1(object value)
		{
		    MF.TextCompil.Clear();
		    Text0.Clear();
		    Text1.Clear();
		    Text2.Clear();
		    Text3.Clear();
		    Text4.Clear();		   		    
		    MyWriteObjectList2(value);
		    for (int j = 0; j < Text0.Count; j++) MF.TextCompil.AppendText(Text0[j].ToString() + Var.CR);  
		    IComponent component = value as IComponent;  
		    MF.TextCompil.AppendText("public " + component.Site.Name + "(){this.InitializeComponent();}" + Var.CR);  
		    MF.TextCompil.AppendText("private void InitializeComponent(){ " + Var.CR);		   		   		 
		    for (int j = 0; j < Text3.Count; j++) MF.TextCompil.AppendText(Text3[j].ToString() + Var.CR);  
            for (int j = 0; j < Text1.Count; j++) MF.TextCompil.AppendText(Text1[j].ToString() + Var.CR);		
            for (int j = 0; j < Text2.Count; j++) MF.TextCompil.AppendText(Text2[j].ToString() + Var.CR);
            for (int j = 0; j < Text4.Count; j++) MF.TextCompil.AppendText(Text4[j].ToString() + Var.CR);  
            MF.TextCompil.AppendText("this.PerformLayout(); }" + Var.CR);            
            MF.TextCompil.AppendText("[System.STAThreadAttribute()] " + Var.CR +
            "public static void Main() " + Var.CR +
            "{System.Windows.Forms.Application.Run(new " + component.Site.Name + "());} " + Var.CR);                     
            return MF.TextCompil.Text;
		}
		
		//Используется только для MyWriteObjectList1.
		public void MyWriteObjectList2(object value)
		{		 		    		    
			int HasChildren = 0;
		    foreach(Control child in ((Control)value).Controls)
			{
				if (child.Site != null && child.Site.Container == host.Container)
				{												
				    HasChildren += 1;
				    MyWriteObjectList2(child);
				}
			}
		    if (HasChildren > 0) 
		    {		         
			     Text3.Add("this.SuspendLayout();");
			     Text4.Add("this.ResumeLayout(false);");
		    }
		    //MF.TextCompil.AppendText(child.Site.Name);	
		    MyWriteObjectOne2(value);		    
		    
		}
		
		//Используется только для MyWriteObjectList1.
		private void MyWriteObjectOne2(object value)
		{
		    IComponent component = value as IComponent;  
		    //MF.TextCompil.AppendText("Компонент: " + component.Site.Name + Var.CR);	
		    
		    //this.listBox1  = new System.Windows.Forms.ListBox();
            //this.groupBox1 = new System.Windows.Forms.GroupBox();
            //this.button2   = new System.Windows.Forms.Button();
            //this.button1   = new System.Windows.Forms.Button();
            //this.textBox1  = new System.Windows.Forms.TextBox();
		    string TypeStr = component.GetType().ToString();
		    if (TypeStr != "System.Windows.Forms.Form") 
		    {
		        Text0.Add("private " + TypeStr + " " + component.Site.Name + ";" + Var.CR);  //private System.Windows.Forms.Button button1;
		        Text1.Add("this." + component.Site.Name + " = new " + TypeStr + "();");
		    }
		    
		    Text2.Add("//");
		    Text2.Add("// " + component.Site.Name); 
		    Text2.Add("//");  
		    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value, propertyAttributes);
		    MyWriteProperties2(properties, value, "Property", component);
            
		    EventDescriptorCollection events = TypeDescriptor.GetEvents(value, propertyAttributes);
			IEventBindingService bindings = host.GetService(typeof(IEventBindingService)) as IEventBindingService;
			if (bindings != null)
			{
				properties = bindings.GetEventProperties(events);
				//!!!WriteProperties(document, properties, value, node, "Event");
				MyWriteProperties2(properties, value, "Event", component);
			}	
		}
		   
		//Используется только для MyWriteObjectList1.
		private void MyWriteProperties2(PropertyDescriptorCollection properties, object value, string elementName, IComponent component)
		{
            foreach(PropertyDescriptor prop in properties)
			{
				if (prop.ShouldSerializeValue(value))
				{                    
					//XmlNode node = document.CreateElement(elementName);
					//XmlAttribute attr = document.CreateAttribute("name");
					string propName = prop.Name;
					//node.Attributes.Append(attr);
					//Text2.Add("ТИП prop " + prop.GetType().ToString());
				    DesignerSerializationVisibilityAttribute visibility = (DesignerSerializationVisibilityAttribute)prop.Attributes[typeof(DesignerSerializationVisibilityAttribute)];
					switch(visibility.Visibility)
					{
						case DesignerSerializationVisibility.Visible:
					        if (!prop.IsReadOnly) 
					        {   
					            MyWriteValue2(prop.GetValue(value), elementName, propName, component);
					        }
							break;
						case DesignerSerializationVisibility.Content:
							// A "Content" property needs to have its properties stored here, not the actual value.  We 
							// do another special case here to account for collections.  Collections are content properties
							// that implement IList and are read-only.
							// "Содержание" нужна собственность, чтобы ее свойства, которые хранятся здесь, а не фактическое значение. 
							// Мы делаем еще один особый случай в счете для коллекций. Коллекции свойства содержимого, которые 
							// реализуют ilist и доступны только для чтения.
							object propValue = prop.GetValue(value);
							if (typeof(IList).IsAssignableFrom(prop.PropertyType))
							{
								MyWriteCollection2((IList)propValue, elementName, propName, component);
							}
							else
							{
								PropertyDescriptorCollection props = TypeDescriptor.GetProperties(propValue, propertyAttributes);
								//WriteProperties(document, props, propValue, node, elementName);
								MyWriteProperties2(props, propValue, elementName, component);
							}
							break;
						default: 
							break;
					}
				}
			}
		}
		
		//Используется только для MyWriteObjectList1.
		private bool MyWriteValue2 (object value, string elementName, string propName, IComponent component)
		{
		    // For empty values, we just return.  This creates an empty node.
			if (value == null)
			{
				return true;
			}
			string s = "";
			string ValueStr = "";
			string NameComponent = "";
			string TypeStr = component.GetType().ToString();			
			if (TypeStr != "System.Windows.Forms.Form") {NameComponent = "this." + component.Site.Name + "." + propName + " = ";}
			  else NameComponent = "this." + propName + " = ";
			TypeConverter converter = TypeDescriptor.GetConverter(value);
			if (GetConversionSupported(converter, typeof(string)))
			{
				ValueStr = (string)converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(string));	
				if (ValueStr == "True")       {ValueStr = "true";} else
				if (ValueStr == "False")      {ValueStr = "false";} else
				if (propName == "Location")   {ValueStr = "new System.Drawing.Point(" + ValueStr + ")";} else				
				if (propName == "Size")       {ValueStr = "new System.Drawing.Size(" + ValueStr + ")";} else
				if (propName == "ClientSize") {ValueStr = "new System.Drawing.Size(" + ValueStr + ")";} else
				if (propName == "Name")       {ValueStr = "\"" + ValueStr + "\"";} else	 
				if (propName == "Text")       {ValueStr = "\"" + ValueStr + "\"";} else
                if (propName == "DataMember") {ValueStr = "\"" + ValueStr + "\"";} else		
				if (propName == "DefaultDataSourceUpdateMode") return true;
				if (propName == "StartPosition") {ValueStr = "FormStartPosition." + ValueStr + "";};
				
				s = NameComponent + ValueStr + ";";
				Text2.Add(s); //MF.TextCompil.AppendText("проблема1. " + s + ";\r\n");
			}
			else if (GetConversionSupported(converter, typeof(byte[])))
			{
				byte[] data = (byte[])converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(byte[]));
				//parent.AppendChild(WriteBinary(document, data));
				s =  NameComponent + Convert.ToBase64String(data) + ";"; 
				Text2.Add(s);// MF.TextCompil.AppendText("проблема2 " + s + ";\r\n");
				
			}
			else if (GetConversionSupported(converter, typeof(InstanceDescriptor)))
			{
				// InstanceDescriptors are encoded as an InstanceDescriptor element.
				//
				InstanceDescriptor id = (InstanceDescriptor)converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(InstanceDescriptor));
				//parent.AppendChild(WriteInstanceDescriptor(id, value));
				s =  NameComponent + MyWriteInstanceDescriptor2(id, value, elementName, propName, component) + ";";
				Text2.Add(s); //MF.TextCompil.AppendText("проблема3 " + s + ";\r\n");
			}
			else if (value is IComponent && ((IComponent)value).Site != null && ((IComponent)value).Site.Container == host.Container)
			{
				// IComponent.  Treat this as a reference.
				//parent.AppendChild(WriteReference(document, (IComponent)value));
				//MF.TextCompil.AppendText(WriteReference(document, (IComponent)value));
				//string s = (value as IComponent).Site.Name;
				s = NameComponent + "\"" + ((IComponent)value).Site.Name + "\";";
				Text2.Add(s); //MF.TextCompil.AppendText("проблема4 " + s + ";\r\n");
			}
			else if (value.GetType().IsSerializable)
			{
				// Finally, check to see if this object is serializable.  If it is, we serialize it here
				// and then write it as a binary.
				BinaryFormatter formatter = new BinaryFormatter();
				MemoryStream stream = new MemoryStream();
				formatter.Serialize(stream, value);
				s = NameComponent + "\"" + Convert.ToBase64String(stream.ToArray()) + "\";";
				Text2.Add(s); //MF.TextCompil.AppendText("проблема5 " + s + ";\r\n");
				//XmlNode binaryNode = WriteBinary(document, stream.ToArray());
				//parent.AppendChild(binaryNode);
			}
			else
			{
				return false;
			}
			return true;
		    
		}
			
		//Используется только для MyWriteObjectList1.
		private void MyWriteCollection2(IList list, string elementName, string propName, IComponent component)
		{
		    string ValueStr  = "";
		    string ValueStr1 = "";
		    string ValueStr2 = "";
		    string ValueStr3 = "";
		    string TypeStr = component.GetType().ToString();  
		    //this.listBox1.Items.AddRange(new object[] {"111","222","333"});
		    if (propName == "Items")  
		    {		        		        
		        if (TypeStr != "System.Windows.Forms.Form") {ValueStr1 = "this." + component.Site.Name + ".Items.AddRange(new object[] {";}
			      else ValueStr1 = "this." + ".Items.AddRange(new object[] {";
		        	        
		        foreach(object obj in list)
			    {
				    TypeConverter converter = TypeDescriptor.GetConverter(obj);
		            ValueStr2 = (string)converter.ConvertTo(null, CultureInfo.InvariantCulture, obj, typeof(string));		        
				    ValueStr3 = ValueStr3 + "\"" + ValueStr2 + "\"";
			    }
		       ValueStr = ValueStr1 + ValueStr3 + "});" + Var.CR; 		        
		    } else 
		   
		    //this.groupBox1.Controls.Add(this.button2);
		    if (propName == "Controls")  
		    {	
		        int i = list.Count;
		        foreach(object obj in list)
			    {
				    TypeConverter converter = TypeDescriptor.GetConverter(obj);
		            ValueStr2 = (string)converter.ConvertTo(null, CultureInfo.InvariantCulture, obj, typeof(string));		        
				    
		            if (propName == "Controls") 
		            {
		              
		              if (TypeStr != "System.Windows.Forms.Form") {ValueStr3 = ValueStr3 + "this." + component.Site.Name + ".Controls.Add(this." + ValueStr2 + ");";}
			            else ValueStr3 = ValueStr3 + "this.Controls.Add(this." + ValueStr2 + ");";
			          
		                //ValueStr3 = ValueStr3 + "this." + component.Site.Name + ".Controls.Add(this." + ValueStr2 + ");";
		            }
				    
				    if (list.IndexOf(obj) != list.Count-1) {ValueStr3 += Var.CR;}
				   
		        }
		        ValueStr = ValueStr3 + Var.CR;		        
		    } else return;
		    if (list.Count > 0) 
		    {
		        Text2.Add(ValueStr); //MF.TextCompil.AppendText("Collection. " + ValueStr);
		    }
		}			
		
		//Используется только для MyWriteObjectList1.
		private string MyWriteInstanceDescriptor2(InstanceDescriptor desc, object value, string elementName, string propName, IComponent component) //XmlDocument document, 		                                         
		{
			BinaryFormatter formatter = new BinaryFormatter();
			MemoryStream stream = new MemoryStream();
			formatter.Serialize(stream, desc.MemberInfo);
			string memberAttr;
			memberAttr = Convert.ToBase64String(stream.ToArray());
			string Result; 
			Result = memberAttr;
			foreach(object arg in desc.Arguments)
			{
				if (MyWriteValue2(arg, elementName, propName, component))				
					Result = Result + Var.CR + memberAttr;
				
			}
			// Instance descriptors also support "partial" creation, where properties must also be persisted.
			// Экземпляр дескрипторы также поддерживают "частичный" создание, где свойства также должны быть сохранены.
			if (!desc.IsComplete)
			{
				PropertyDescriptorCollection props = TypeDescriptor.GetProperties(value, propertyAttributes);
				MyWriteProperties2(props, value, "Property", component);
			}
			return Result; 
		}
		*/
		                
                
          
                
//================================
            //Работает
            //NewDT ndt = new NewDT();    
            //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(NewDT)); 
            //using (FileStream fs = new FileStream(@"C:\Мусор\Form1_3.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatter.WriteObject(fs, ndt);
            //}
//=======================================                
//================================
            //Работает
            //NewDT ndt = new NewDT(); 
            //FileStream fs = new FileStream(@"C:\Мусор\Form1_3.json", FileMode.OpenOrCreate);
            //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(NewDT)); 
            //ndt = (NewDT)jsonFormatter.ReadObject(fs);
            //DT2 = ndt.DT;    
//================================                  
                
                
                  //DT.TableName = TableName;
            //DT.ReadXml(
            //DT.WriteXml(filexml);
            /*
            StreamWriter strFile = new StreamWriter(filexml, false, System.Text.Encoding.Default);
            if (exportcolumnsheader)
            {
                string Columns = string.Empty;
                foreach (DataColumn column in DT.Columns) Columns += column.ColumnName + delimited;             
                strFile.WriteLine(Columns.Remove(Columns.Length - 1, 1));
            }
 
            foreach (DataRow datarow in DT.Rows)
            {
                string row = string.Empty;
                foreach (object items in datarow.ItemArray) row += items.ToString() + delimited;             
                strFile.WriteLine(row.Remove(row.Length - 1, 1));
            } 
            strFile.Flush();
            strFile.Close();
            */
//=========================================                
                
                  //Random r = new Random(100000);
            //string ct = "CREATE TABLE TempTable" + r.ToString();
            //List<string> LT = new List<string>();          
            //string typestr1 = "";
            //string typestr2 = "";
            //ID   = DT2.  //dgvModule.SelectedRows[0].Cells["ID"].Value.ToString();
            //string tn = ndt.TableName;
                                              
            //DataTable DT3 = new DataTable();
            //SelectDT(SQL, out DT3);
            //ID = DT2.Rows["ID"].ToString();            
                //DT2.Rows[0][0].ToString();
                
                //foreach (DataColumn col in DT2.Columns)
                //{   
                    
                   //col.ColumnName                        
                   //SQL += col.ColumnName + " = " + col                  
                   //typestr1 = col.DataType.ToString();
                    //if (typestr1 == "int") typestr2 = " int";
                   //LT.Add(col.ColumnName);                
                //}
            //string cols = " (" + string.Join(",", LT.ToArray()) + ")";                             
            //Row.ItemArray
            //ct += cols;
            //sys.SM(ct, MessageType.Information, "CREATE");
            
            
            //foreach (DataRow row in DT.Rows)
            //foreach (DataColumn col in DT.Columns)                 
            //{
                //row.                
            //}
            
            
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
                //connection.Open();
                /*using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection3))
                {
                    foreach (DataColumn c in DT.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
 
                    bulkCopy.DestinationTableName = TableName; //DT.TableName;
                    try
                    {
                        bulkCopy.WriteToServer(DT);
                    }
                    catch (Exception e)
                    {            
                        sys.SM(e.Message //Console.WriteLine(ex.Message);
                    }
                }*/
            //}
            
            
            
            
            /*StreamReader strFile = new StreamReader(filexml, System.Text.Encoding.Default);
            if (importcolumnsheader)
            {
                string[] ColumnsArray = strFile.ReadLine().Split(delimited.ToCharArray());
                foreach (string strCol in ColumnsArray)  DT.Columns.Add(strCol);           
            }
            else
            {  
                int ColumnsCount = strFile.ReadLine().Split(delimited.ToCharArray()).Length;
                for (int iCol = 1; iCol <= ColumnsCount; iCol++) DT.Columns.Add(iCol.ToString());            
                strFile = new StreamReader(filexml, System.Text.Encoding.Default);
            } 
            while (strFile.Peek() > 0) DT.Rows.Add(strFile.ReadLine().Split(delimited.ToCharArray()));       
            strFile.Close();*/
//============================================                
               
               //conLite.ImportDataTableFromFile(out dtRtn2, out TableName, @"C:\Мусор\Form1_8.csv", "ASK");
               //out DataTable DT2, out string TableName, string filexml, string IFRecExists)
               //conLite.ImportDataTableFromFile(out dtRtn2, TableName, ""); 
               //dataGridView1.DataSource = dtRtn2;
               
               //conLite.ImportDataTableFromFile(string file, string delimited, bool importcolumnsheader, DataTable datatable)                                    
               //conLite.ImportDataTableFromFile(@"C:\Мусор\Form1.csv", "@#$%", true, dtRtn2);
               //dgvModule.DataSource = dtRtn2;
               //SQL = "SELECT * FROM fbaProject WHERE ID = " + ModuleID.ToString() + "; ";                     
               //conLite.SelectDT(SQL, out dtRtn1);   
//=============================================
                
                
//host.selectionService.
           
           //List<string> LT = new List<string>();
           //List<int> numbers = new List<int>() { 1, 2, 3, 45 };
           //foreach (DataColumn col in DT.Columns)  
           
                             
           //LT.Add("1a");
           //LT.Add("2a");
           //LT.Add("3d");
           //LT.Add("4g");
           //LT.Add("5h");
                       
            //string cols = string.Join(",", LT.ToArray());
            //SM(cols, MessageType.Information, "пример");
           
//=============================================                
                
 /*System.Type type = dgv1.GetType();
                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    if (field.IsStatic) continue;
                    field.SetValue(fctb1, field.GetValue(textSQL1));
                }
                */
                //var props = type.GetProperties();
                   
                /*string propstr = 
                       propstr1 + 
                       propstr2 + 
                       propstr3 + //Ошибка
                       propstr4 + 
                       propstr5 +
                       propstr6; 
                */ 
                /*
                foreach (var prop in props)
                {                             
                    if (!prop.CanWrite) continue;
                    if  (  prop.Name == "Name"
                        || prop.Name == "Parent"
                        
                        //Это для FastColoredTextBoxNS
                        || prop.Name == "Zoom"
                        || prop.Name == "Padding"
                        || prop.Name == "RightToLeft" 
                        || prop.Name == "Item"                            
                        ) continue;
                 */   
                      //Это для DataGridView
                  //if  (  //prop.Name == "FirstDisplayedScrollingColumnIndex" ||
                  //     prop.Name == "FirstDisplayedScrollingRowIndex" ) continue;                
                                        
                    //if (propstr.IndexOf(";" + prop.Name + ";") == -1) continue;                 
                    //string FileName = @"outputfull6.txt";
		            //StreamWriter myfile = new StreamWriter(FileName, true);
                    //myfile.WriteLine(prop.Name);
                    //myfile.Close();	
                    
                    //if  (prop.GetValue(fctb1, null) != prop.GetValue(textSQL1, null))
                    //  prop.SetValue(fctb1, prop.GetValue(textSQL1, null), null);    
                    
                    
                    //if  (prop.GetValue(dgv1, null) != prop.GetValue(dgvSQL1, null))
                    //  prop.SetValue(dgv1, prop.GetValue(dgvSQL1, null), null);                      
                //}
//================================================                
 /*string sel1 = textBox1.SelectedText;                        
            System.Type type = textSQL1.GetType();
            PropertyInfo[] props = type.GetProperties();               
            try 
            {
                PropertyInfo prop = props.Where(x => x.Name == sel1).First();
                SM(prop.Name);
                prop.SetValue(fastColoredTextBox1, prop.GetValue(textSQL1, null), null);
            } catch 
            {
               return;
            }
            
             */    
//================================================             	
//********************************
       // DataGridView to DataTable    
        /*public static  DataTable ToDataTable(DataGridView dataGridView, string tableName)
        {
              
            DataGridView dgv = dataGridView;
            DataTable table = new DataTable(tableName);
            int iCol = 0;
 
            for (iCol = 0; iCol &lt; dgv.Columns.Count; iCol++)
            {
               table.Columns.Add(dgv.Columns[iCol].Name);
            }
 
            foreach (DataGridViewRow row in dgv.Rows)
            {
 
                DataRow datarw = table.NewRow();
 
                for (iCol = 0; iCol &lt; dgv.Columns.Count; iCol++)
                {
                        datarw[iCol] = row.Cells[iCol].Value;
                }
 
                table.Rows.Add(datarw);
            }
 
            return table;
        } */
//================================================
        
        //public Form FormShow (string FormName)
        //{
        //    string PathModule = MainPath + @"\" + FormName + ".dll"; // ;//LibraryForm.dll; //Application.ExecutablePath + @"\Modules\LibraryForm444.dll";                                                           
        //    Assembly assembly = Assembly.LoadFile(PathModule);
        //    Type type = assembly.GetType("LibraryForm.FormNew1");
        //    Form Form1 = (Form)Activator.CreateInstance(type);
        //    Form1.MdiParent = this;          
        //    Form1.Show();
        //    return Form1; 
        //}
//================================================ 
            	        
        /*public bool SelectDT1(string SQL, ref DataTable DT)
        {           
            string ErrorText = "";
            bool ErrorShow = true;
            List<DataTable> dtRtn1;
            bool flag = SelectDT(SQL, out dtRtn1, ref ErrorText, ErrorShow);
            Grid.DataSource = dtRtn1[0];
            Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.25F, FontStyle.Bold); //ForeColor = Color.Red;           
            Grid.RowsDefaultCellStyle.SelectionBackColor = Color.Blue; 
            Grid.AutoResizeColumns();
            return flag;
        }*/
//================================================
//string UserID = 
			//string s = conLite.GetValue(SQL, out ErrorCode);
			//SM(s,MessageType.Information, "Вход в систему");
			//string hash = MD5(tbLogin.Text + tbPass.Text);
			//if (s != hash)            	
//================================================            	
  //=========================================================================
        // Функция загрузки данных в таблицу в базе данных (через bulkcopy)
        //=========================================================================
        /*public bool InsertQueryData(string TableName, DataTable dt){
            bool ErrorOccured = false;
            try{
                if (!TransactSQLFlag){	
                    var model = BulkCopyFactory.GetModel();
                    PQNativeApi.LoadDLLDirectory(model.MajorVersion);
                    //PQ9xNativeApi.openLocaleConn(model.Connection.Database.AsPointer(), model.Connection.UserName.AsPointer(), model.Connection.Password.AsPointer()); // Для AsPointer() необходимо использовать unsafe
                    //PQ9xNativeApi.setColumns(columnData);
                    //PQ9xNativeApi.setTableName(tableName);
                    //PQ9xNativeApi.setBatchSize(batchSize);
                }
                else{
                    using (SqlBulkCopy bulkCopy =
                        new SqlBulkCopy(connection1)){
                    command1 = new SqlCommand(QueryText);
                    command1.Connection = connection1;
                    SqlDataReader dr = command1.ExecuteReader();	
                    dr.Read();
                    s = dr[0].ToString();
                    dr.Close();
                    }
                }
            } catch{
                ErrorOccured = true;
            }
            return ErrorOccured;
        }*/
//================================================  
            	
			/*SQL = "SELECT" +
                   " t1.ID AS UserID," +
                   " t1.Block," +
                   " t1.Pass," +
                   " t1.RoleID," +
                   " t2.Brief AS RoleBrief" +               
                   " FROM fbaUser t1" +
                   " LEFT JOIN fbaRole t2 ON t2.ID = t1.RoleID" +
                   " WHERE t1.Login = '" + Login + "'" +
                   " LIMIT 1;";
            */
			/*DataTable DT1;
			conLite.SelectDT1(SQL, out DT1);			
			       UserID    = sys.DTValue(DT1, "UserID");
			string Block     = sys.DTValue(DT1, "Block");
			string Pass      = sys.DTValue(DT1, "Pass");	
			string RoleID    = sys.DTValue(DT1, "RoleID");
			string RoleBrief = sys.DTValue(DT1, "RoleBrief");
			
			SQL = "SELECT t3.FormID FROM fbaRelRoleForm t3 " +
				   " LEFT JOIN Form t4 ON t3.FormID = t4.ID " +
				   " WHERE t4.Name = '" + UserForm + "' " +
				   " AND t3.RoleID = '" + RoleID + "' " +
                   " LIMIT 1;";
			DataTable DT2;
			conLite.SelectDT1(SQL, out DT2);
			string FormID    = sys.DTValue(DT2, "FormID");            		
			
            if (ErrorMes == "" && UserID   == "")      ErrorMes = "Пользователь не найден.";
            if (ErrorMes == "" && UserPass != Pass)    ErrorMes = "Пароль неверный.";
            if (ErrorMes == "" && Block    == "1")     ErrorMes = "Пользователь блокирован.";  
            if (ErrorMes == "" && UserForm == "DESIGNER" && RoleBrief != "admin") ErrorMes =  "Нет прав на вход в Дизайнер.";            
            if (ErrorMes == "" && FormID   == "" && UserForm != "DESIGNER") ErrorMes = "Нет прав на вход в прикладную подсистему.";
            if (ErrorMes != "")
            {
				sys.SM(ErrorMes, "Вход в систему");
				return;
			}	*/							
//================================================ 
            	//Если переданных параметров нет, то показываем в полях последние введенные значения. Эти значения бурутся из таблицы LastEnter  			
			/*if (args.Length == 0) 
			{												  
			    SQL = "SELECT UserForm, UserLogin, UserPass FROM Enter WHERE ComputerName = '" + ComputerName + "' AND ComputerUserName = '" + ComputerUserName + "' ORDER BY DateEnter DESC LIMIT 1";				  
			    conLite.GetValue3(SQL, out UserForm, out UserLogin, out UserPass);				
			}  else
			{
				//Иначе ппоказываем из параметров.
				if (args.Length > 1) UserForm  = args[1].ToString();
			    if (args.Length > 2) UserLogin = args[2].ToString();
			    if (args.Length > 3) UserPass  = args[3].ToString();
			}	
			//Устанавливаем на форме
		    SetParam(UserForm, UserLogin, UserPass);	
	        */
//================================================             	
            				//DataRow Row1 = DT.NewRow();
			//Row1["ConnectionName"] = "DESIGNER";		
			//DT.Rows.Add(Row1);  //DT.Rows.InsertAt(Row1, 0);
//================================================              	
            				//string[] Args = new string[args.Length];
			//Args = args;	
//================================================             	
            				//conLite.SelectDT1(SQL, out DT);  
			//tbPass.Text = sys.DTValue(DT, "Pass");
//================================================              	
            	    
	//using SampleDesignerHost;
    //using System.IO;
    //using System.Drawing.Design;
    //using System.ComponentModel.Design.Serialization;    
    //using System.CodeDom;
    //using System.Collections;    
    //using System.Text;    
    //using System.Xml.dll;
    //using System.Xml.Linq.dll;  
    //using System.Text;
    //using System.Threading.Tasks;
    //using ClassLibrary1;  //Статическое подключение DLL
    //using LibraryForm;
    //using System.Diagnostics;
    //using System.Runtime.Serialization;
    //using System.Runtime.Serialization.Formatters;
    //using System.Runtime.Serialization.Formatters.Binary;
    //using System.Runtime.Serialization.Formatters.Soap;
    //using System.Xml.Serialization;
    //using System.Runtime.Serialization.Json;    
    //using EnvDTE;
    //using EnvDTE80;
    //using System.Resources;
    //using System.Drawing.Drawing2D;  
    //using DesignerHost; 
    //using ExcelLibrary.SpreadSheet;
//================================================              	
    
  //Процедура для показа сообщения MessageBox.Show().
        //Если вопрос, то два варианта Yes, No. Результат соответтвенно bool: true, false;
        /*public static bool SM(string Str, string TypeMessage = "Error", string Caption = "")
        {               
            MessageBoxIcon   MBI = MessageBoxIcon.Error;
            MessageBoxButtons MB = MessageBoxButtons.OK;    
            if (TypeMessage == "") TypeMessage = MessageType.Information;           
            if (TypeMessage == MessageType.Information) MBI = MessageBoxIcon.Information;                    
            if (TypeMessage == MessageType.Question) 
            {
                MBI = MessageBoxIcon.Question;
                MB = MessageBoxButtons.YesNo; 
            }
            if (Caption == "") Caption = TypeMessage;
            if (Str.Length > 100)
            {
                FormSM FormSM1 = new FormSM(Str);
                return true;
            }
            else
            {
                var result = MessageBox.Show(Str, Caption, MB, MBI);             
                if (result == DialogResult.No) return false;
                    else return true;
            }
            
            //MessageBoxDefaultButton.Button1, 
            //MessageBoxOptions.DefaultDesktopOnly);          
        }*/
//================================================              	
/*public void AddStringToFile(string str = "",
		     [System.Runtime.CompilerServices.CallerMemberName] string memberName       = "",
             [System.Runtime.CompilerServices.CallerFilePath]   string sourceFilePath   = "",
             [System.Runtime.CompilerServices.CallerLineNumber] int    sourceLineNumber = 0)
		{
            string strFileCS = Path.GetFileName(sourceFilePath);
            if (str != "") str += ": ";
            str += sourceLineNumber.ToString() + ": " + memberName + " " + strFileCS;
            string FileName = @"C:\Мусор\ListProc.txt";
		    StreamWriter myfile = new StreamWriter(FileName, true);
            myfile.WriteLine(str);
            myfile.Close();		    
		}*/  
//================================================ 
//datetime('now', 'localtime') 
// SELECT last_insert_rowid() AS id; ";     
//================================================             	
            	    	//if (args.Length > 1) ConnectionName  = args[1].ToString();
        	//if (args.Length > 1) UserForm  = args[1].ToString();
			//if (args.Length > 2) UserLogin = args[2].ToString();
			//if (args.Length > 3) UserPass  = args[3].ToString();
//================================================ 
      //Установка соединения с SQLite базой.
            //if (conLite == null) conLite = new Connection("SQLite", "", "", "", "");   
            //if (conLite.ActiveConnection = false) 
            //{
            //    sys.SM("Нет соединения локальной БД!", "Ошибка выполнения запроса");
            //    Application.Exit();
            //}
            
            //Установка соединения с удаленной базой.
            
            //SQL = "SELECT * FROM fbaConList WHERE ConnectionName = " + Var.connectionName;
            //Var.conLite.SelectDT1(SQL, out sys.DT);
            //dgvForm.DataSource = sys.DT;
            //if (con == null) con = new Connection("Postgre", "", "", "", "");             
            //Обновить таблицу форм.
            //!!!FormListGridRefresh("Active");   
//================================================             
                        	
			
			//if (SenderName == "btnDesigner") SystemName = "Designer";
			//if (SenderName == "btnClient")   SystemName = "Client";
			//if (SystemName == "Designer") 
			//{
			//	if (!sys.GetPathDesigner(out PathDesigner)) return;
			//    var run = new System.Diagnostics.Process();             
            //    run.StartInfo.Arguments = ConnectionID;
    		//    run.StartInfo.FileName = PathDesigner;
    		//    run.Start();
    		
    		//Выключаем форму входа. Все проверки на соединение с удаленной БД уже выполнятся в самом дизайнере.
    		//    conLite.CloseConnection();
			//    Application.Exit(); 						
			//}
			
			//if (SystemName ==  "Client") 
			//{
			     				   
		   // }
            	
//================================================              	
            	/*
namespace FBA {
	using System;
	
	
	>
	//   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
	
	// Этот класс создан автоматически классом StronglyTypedResourceBuilder
	// с помощью такого средства, как ResGen или Visual Studio.
	// Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
	// с параметром /str или перестройте свой проект VS.
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	internal class FormMain {
		
		private static global::System.Resources.ResourceManager resourceMan;
		
		private static global::System.Globalization.CultureInfo resourceCulture;
		
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal FormMain() {
		}
		
		>
		//   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
		
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager ResourceManager {
			get {
				if (object.ReferenceEquals(resourceMan, null)) {
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DesignerHost.FormMain", typeof(FormMain).Assembly);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}
		
		>
		//   Перезаписывает свойство CurrentUICulture текущего потока для всех
		//   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
		
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Globalization.CultureInfo Culture {
			get {
				return resourceCulture;
			}
			set {
				resourceCulture = value;
			}
		}
	}
}
*/            
//================================================                 	
            	
            	   //Записываем дату создания только для новых форм.
            /*if ((NewForm) && (Mode == true))
            {
                 SQL = "INSERT INTO fbaProject (Name, EntityID, DateChangeTest, UserChangeTestID, Type, FormXMLTest, FormCodeTest, TextCodeTest, CountRowsTest) \r\n" +
            	  " VALUES (" + 
                  "'" + FormName + "'" + 
                  ",100 " +                  
                  ",current_timestamp " +                 
                  "," + Var.UserID  +
                  ",'" + FormType + "'" +
                  ",'" + FormXML    + "'" +
                  ",'" + FormCode   + "'" +
                  ",'" + TextCode   + "'" +
            	  ",'" + CountRows + "')";
                 
            	  SQL = SQL + "UPDATE fbaProject SET DateCreateTest = current_timestamp" +  
                            ", UserCreateTestID = " + Var.UserID  +
                            " WHERE ID = " + FormID + "; \r\n";
            } else                            
            {  */
//================================================                 	
                                 //Выбор вкладки TabControl формы
        //void TabControlFormListSelecting(object sender, TabControlCancelEventArgs e)
        //{
        //	if (tabControlForm.SelectedIndex == 5) FormHistRefresh();      
        //}
//================================================       
        //Вставка процедуры в конец формы.
        //public String AddProcedure(String CodeStr, String InsertProcStr)
        //{
        //    int Place = CodeStr.Length - 8;
        //    return CodeStr.Insert(Place, InsertProcStr);
        //}
        //Вставка переменной
        //public string AddVariable(String CodeStr, String InsertVarStr)
        //{
        //    String s = ": System.Windows.Forms.Form";
        //    int Place = CodeStr.IndexOf(s);
        //    return CodeStr.Insert(Place + s.Length + 7, InsertVarStr);
        //}  
//================================================ 
            	  
            //var F1 = new FormEnter();
            
            //ShowFormApp(FormEnter1);
            //ConnectionName = ""; //sys.ComboBoxStr(cbConnection);		
			/*conLite.GetParamConnection(ConnectionName,
                                     	 out ConnectionID,
                                     	 out ServerName,
                                     	 out ServerType,  
    								 	 out DatabaseName,
    								 	 out DatabaseLogin,
    								 	 out DatabasePass,
    								 	 out UserForm,
    								 	 out UserLogin,
    								 	 out UserPass);
			Args = args;
			//Установка соединения с удаленной базой.	
			con = new Connection();			
			if (con.SetConnectionRemote(ServerType, ServerName, DatabaseLogin, DatabasePass, DatabaseName, UserForm, UserLogin, UserPass, SystemName, out UserID) == false) return;
				
			    
			//Добавляем в историю входов.
			con.AddEnterHist(ConnectionName, ComputerName, ComputerUserName, UserForm, UserID, SystemName);
			//SQL = "INSERT INTO fbaEnterLast (Name, DateEnter) VALUES ('" + ConnectionName + "', current_timestamp);";
			//conLite.Exec(SQL);
            //sys.ShowFormApp(UserForm);
			//Application.Run(new FormEnter()); 
			
			
		//private void ShowFormApp(FormEnter FormEnter1)
		//{
			//this.ConnectionName = FormEnter1.ConnectionName;
			//sys.SM(ConnectionName);
		//}
				
			*/
//================================================             	
            // перемещаем указатель в конец файла, до конца файла- пять байт
            /*var f1 = new FileInfo(PathFile);          
            FileStream fstream1 = f1.Open(FileMode.Open, FileAccess.Read);
            fstream1.Seek(-3, SeekOrigin.End); // минус 3 символов с конца потока
            // считываем четыре символов с текущей позиции
            byte[] output = new byte[4];
            fstream1.Read(output, 0, output.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(output);
            SM("Текст из файла:" + textFromFile); // worl
            */
           
          
            
             
            //string text = "hello world";
            // преобразуем строку в байты
            //byte[] input = Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
            //fstream.Write(input, 0, input.Length);
            //Console.WriteLine("Текст записан в файл");
 
            
 
              
            //string replaceText = "house";
            /*fstream.Seek(-3, SeekOrigin.End); // минус 5 символов с конца потока
             input = Encoding.Default.GetBytes("abc");
            fstream.Write(input, 0, input.Length);
            
           
            // перемещаем указатель в конец файла, до конца файла- пять байт
            fstream.Seek(-3, SeekOrigin.End); // конец потока - 3 байта.
            var output = new byte[3];
            fstream.Read(output, 0, output.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(output);
            SM("Текст из файла: {0}", textFromFile); // worl
            */
            
 
            // считываем весь файл
            // возвращаем указатель в начало файла
            //fstream.Seek(0, SeekOrigin.Begin);
            //output = new byte[fstream.Length];
            //fstream.Read(output, 0, output.Length);
            // декодируем байты в строку
            //textFromFile = Encoding.Default.GetString(output);
            //Console.WriteLine("Текст из файла: {0}", textFromFile); // hello house
//================================================ 
            			    //System.IO.File.SetCreationTime(@"H:\test.txt", new DateTime(1980, 3, 16));                   
            //System.IO.File.SetLastWriteTime(@"H:\test.txt", new DateTime(1988, 10, 22));
			//Console.WriteLine(" Created at " + File.GetCreationTime(s));
            //Console.WriteLine(" Accessed at " + File.GetLastAccessTime(s));
			//File.W
            
            //var f = new FileInfo(@"C:\Новая папка\test.dat"); 
            //using (FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            //{ 
            //    using (var bw = new BinaryWriter(fs))
            //    {   //f.
                	//bw.
                    //bw.Write(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
 
             //   }
 
            //  }
				
				
				
				
				
			//File.GetCreationTime(s));              
            //File.GetLastAccessTime(s));
//================================================            	
//======================================================================     
//conLite.SelectGV(SQL, dataGridView1);			
//string UserID = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
//SM(UserID.ToString(),MessageType.Information,"Пользователь");
//if (Grid.RowCount == 0)
//	SM("Пользователь не найден", "Вход в систему");
//conLite.SelectGV(SQL, comboBox1);
//conLite.Exec(SQL);
//conLite.SelectDT(SQLLocal, out dtRtn1, ref ErrorText, ErrorShow);
//conLite.SelectGV(SQL, Grid, ref ErrorText, ErrorShow);
//======================================================================     	
			/*SQL += "SELECT " +
                  "t1.ID    AS UserID, " +
                  "t1.Block,  " +
                  "t1.Pass,   " +
                  "t1.RoleID, " +
                  "t2.Brief AS RoleBrief, " +
                  "(SELECT t4.ID FROM fbaRelRoleForm t3 " +
				  "  LEFT JOIN Form t4 ON t3.FormID = t4.ID " +
				  "  AND t4.Name = '" + UserForm + "' " +
				  "  AND t3.RoleID = t2.ID) AS FormID " +
                  "FROM fbaUser t1 " +
                  "LEFT JOIN fbaRole t2 ON t2.ID = t1.RoleID " +
                  "WHERE t1.Login = '" + Login + "' " +
                  "LIMIT 1;";*/
			
			
            
            //Запись данных о последнем входе в систему. Это будет храниться в локальной БД.              
			//if (!cbSavePass.Checked) SavePass = "";
		    //	//Сразу фиксируем попытку входа. Enter - таблица истории входов и попыток входа.
			//SQL = "INSERT INTO Enter (EntityID, UserForm, UserLogin, UserPass, DateEnter, ComputerName, ComputerUserName) VALUES ( " +
            // 	  "105, '" + UserForm + "', '" + Login + "', '" + SavePass + "', current_timestamp, '" + ComputerName + "', '" + ComputerUserName + "'); \r\n ";                         	
			//conLite.Exec(SQL);
			
            //Далее вход в систему.
           
                         	
//======================================================================            	
			/*
			//ShowFormMain(cbFormMain.Text);
			string[] args = Environment.GetCommandLineArgs();
			sys.SM("Всего параметров: " + args.Length.ToString());
			if (args.Length == 0) return;
			string fp0 = "";
			string fp1 = "";
			string fp2 = "";
			string fp3 = "";
			if (args.Length > 0) fp0 = args[0].ToString();
			MessageBox.Show(fp0);
            //sys.SM(fp0);			
            if (args.Length > 1) fp1 = args[1].ToString();
            MessageBox.Show(fp1); 
            if (args.Length > 2) fp2 = args[2].ToString();
            MessageBox.Show(fp2); 
            if (args.Length > 3) fp3 = args[3].ToString();
            MessageBox.Show(fp3); 
            
            //sys.SM(fp1);
            */ 
//======================================================================
		
		//Устанавливаем на форме
		/*void SetParam(string UserForm, string Login, string Pass)
		{
			int index = cbFormMain.FindStringExact(UserForm);
		    if (index > -1) cbFormMain.SelectedIndex = index;
		    //tbLogin.Text = Login;
		    //tbPass.Text  = Pass;
		}
		*/
//======================================================================		
			//Инициализация компонентов формы.
			//Npgsql.NpgsqlConnection connection45 = new Npgsql.NpgsqlConnection("Server=10.77.70.27;User Id=Postgre;Password=asdzxc;Database=MyProject;");
    		//connection45.Open();
//======================================================================  
            /*string ConnectionID  = "17";
    		string Server        = "10.77.70.27";
    		string ServerType    = "Postgre";
    		string DatabaseName  = "MyProject";
    		string Login         = "Postgre";
    		string Pass          = "asdzxc";
    		string FormName      = "FormName";*/
    		/*Connection con85;   		
			con85 = new Connection(ServerType, Server, Login, Pass, DatabaseName);
    		sys.SM("Подключение успешно!" + ConnectionID, MessageType.Information, "Вход в систему");
    		
    		
    		Npgsql.NpgsqlConnection connection46 = new Npgsql.NpgsqlConnection("Server=10.77.70.27;User Id=Postgre;Password=aaaa;Database=MyProject;");
    		connection46.Open();
    		sys.SM("Подключение успешно pg_2!", MessageType.Information, "Вход в систему");
    		
			SqlConnection  connection47 = new SqlConnection("Server=srvtest1;User Id=bbbb;Password=aaaa;Database=dbtest2;");
			connection47.Open(); 
			
			sys.SM("Подключение успешно MSSQL!", MessageType.Information, "Вход в систему");
			
			
    		 ConnectionID  = "17";
    		 Server        = "srv2";
    		 ServerType    = "servertype";
    		 DatabaseName  = "dbname";
    		 Login         = "";
    		 Pass          = "";
    		 FormName      = "FormName";
    		
    		//Connect  con3; 				
    		//con3 = new Connection();
    		//con3.DoConnect(ServerType, Server, Login, Pass, DatabaseName);
    		//return;
*/
//======================================================================
//startInfo.WorkingDirectory = Path.GetDirectoryName(exePath);
				//System.Diagnostics.Process _process = new System.Diagnostics.Process ();				
				//ProcessStartInfo startInfo = new ProcessStartInfo();								
				//startInfo.FileName = executable;
				//startInfo.Arguments = "/p /a /c" ;				
				//_process.StartInfo = startInfo;
				//_process.Start(); 
//======================================================================
                //command3 = new SQLiteCommand(SQL);
                //command3.Connection = connection3;  
                //SQLiteDataReader dr = command3.ExecuteReader();
                //dr.Read();
                //if (!(dr.HasRows)) return false;                
                //string filestr = dr[0].ToString();   
//======================================================================
            					//sys.SM("ParamStr=" + ParamStr);
	//if (Var.Args.Length > 1) sys.SM(Var.Args[1]);
				//if (Var.Args.Length > 2) sys.SM(Var.Args[2]);
				//if (Var.Args.Length > 3) sys.SM(Var.Args[3]);
				//sys.SM("Var.connectionID=" + Var.connectionID);
				//sys.SM("Var.connectionName=" + Var.connectionName);
				//sys.SM("sys.UserForm=" + sys.UserForm);
				//sys.SM("sys.Mode=" + sys.Mode.ToString());
				//sys.SM("Var.connectionName =" + Var.connectionName );
				//sys.SM("1-2");            	
//======================================================================            	
			//sys.SM("!!!-0");
			//Подключение к SQLite при старте формы входа.
			//sys.GetPathSQLite (out sys.PathSQLite);
			
			//sys.Mode = false;
			//Var.connectionName = "";			
			
			
			//InitializeComponent(); //ConnectionID=21 FormName=Form9 Mode=True  
			//if (Var.Args.Length > 1) sys.SM(Var.Args[1]);
			//if (Var.Args.Length > 2) sys.SM(Var.Args[2]);
			//if (Var.Args.Length > 3) sys.SM(Var.Args[3]);
			
		
			
			//Environment.Exit(0);		
            //Параметры, переданные в EXE файл при запуске:
			//Var.Args = Environment.GetCommandLineArgs();
            //Если в аргументах запуска EXE было передано имя подключения, то смотрим его в локальной БД SQLIte.
			//if (Var.Args.Length < 2) 
			//{	            	
//======================================================================               	
//string FileName = @"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C# 2017.01.09-1\DesignerApp\bin\Debug\DesignerApp.exe";
//			string GUID1 = sys.GUIDSave(FileName);
//			sys.SM("GUID1:" + GUID1);
//			string GUID2 = sys.GUIDRead(FileName);
//			sys.SM("GUID2:" + GUID2);  
//====================================================================== 
      
//SQL = GetSQL("kjhkjh", "@asdsd.text", asdsd.text, "@qweqwe.text", qweqwe.text)
//ShowForm("edfsdf");
//Assembly assembly = Assembly.LoadFile(@"C:\000_Travin\Projects C#\Проба динамическая компиляция\Тест1\LibraryForm.dll");
//            Type type = assembly.GetType("LibraryForm.FormNew1");
//            Form form22 = (Form)Activator.CreateInstance(type);
//            form22.MdiParent = this;          
//            form22.Show();
 //======================================================================            	
/*public static void ExportToExcel(DataGridView grid, string TemplatePath)
        {
            var Excel = new ApplicationClass();
            XlReferenceStyle RefStyle = Excel.ReferenceStyle;
            Excel.Visible = true;
            Workbook wb = null;
            try
            {
                wb = Excel.Workbooks.Add(TemplatePath); // !!! 
            }
            catch (System.Exception ex)
            {
                throw new Exception("Не удалось загрузить шаблон для экспорта " + TemplatePath + "\n" + ex.Message);
            }
            var ws = wb.Worksheets.get_Item(1) as Worksheet;
            for (int j = 0; j < grid.Columns.Count; ++j)
            {
                (ws.Cells[1, j + 1] as Range).Value2 = grid.Columns[j].HeaderText;
                for (int i = 0; i < grid.Rows.Count; ++i)
                {
                    object Val = grid.Rows[i].Cells[j].Value;
                    if (Val != null)
                        (ws.Cells[i + 2, j + 1] as Range).Value2 = Val.ToString();
                }
            }
            ws.Columns.EntireColumn.AutoFit();
            Excel.ReferenceStyle = RefStyle;
            //ReleaseExcel(Excel as Object);
            Marshal.ReleaseComObject(Excel);
            GC.GetTotalMemory(true);
        } 
*/
//======================================================================
//string SenderName = "";
            //if (sender.GetType().ToString() == "System.Windows.Forms.ToolStripButton")
            //   SenderName = (sender as ToolStripButton).Name.ToString();
            //if (sender.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem") 
            //   SenderName = (sender as ToolStripMenuItem).Name.ToString();   
            //if (sender.GetType().ToString() == "System.Windows.Forms.ToolStripDropDownButton") 
            //   SenderName = (sender as ToolStripDropDownButton).Name.ToString(); 
//======================================================================
        //private void ExportToExcelToolStripMenuItemClick(object sender, EventArgs e)
        //{             
        	  //sys.ExportToExcel(); 
        	///DataTable DT = new DataTable();
            //DT = (DataTable)dgvSQL1.DataSource;
            //Export2ExcelClass.CreateWorkbook(@"C:\Мусор\DataTableExcel1.xlsx", DT);
       // }// 
//======================================================================            	
//int i1 = textCS.Text.IndexOf("//begin importcode");
            //int i2 = textCS.Text.IndexOf("//end importcode");
            //string ImportBlock = textCS.Text.Substring(i1, i2 - i1);      
            //textCode.Text = textCode.Text.Remove(i1,  i2 - i1);
            //int i2 = InputStr.IndexOf(EndStr, i1);
            
            //string ImportBlock = sys.StringBeweenString(textCS.Text, "//begin importcode", "//end importcode"); 
          
            //for ()
            //CodeAssembly =
//======================================================================              	
/*
System.Core.dll
System.Data.dll
System.Data.DataSetExtensions.dll
System.Deployment.dll
System.Drawing.dll
System.Windows.Forms.dll
System.Xml.dll
System.Xml.Linq.dll
System			
System.ComponentModel
System.ComponentModel.Design
System.ComponentModel.Design.Serialization
System.Collections
System.Diagnostics
System.Globalization
System.IO 
System.Reflection
System.Runtime.Serialization.Formatters.Binary
System.Text
System.Windows.Forms
System.Xml
System.CodeDom.Compiler
System.CodeDom
Microsoft.CSharp
*/
//======================================================================              	
//if (FormFile.IndexOf(".DLL") == -1) FormFile += @".DLL";
//GenerateExecutable = false;
//GenerateInMemory = true;
//CompilerOptions = String.Concat("/target:library /win32icon:\" , iconpath , "\")
//string OptionEXEDLL = "/target:library";             	
 
 /*if (FormID != "0")           
            {
            	if (FormName != Var.conSys.GetValue("SELECT Name FROM fbaProject WHERE ID = '" + FormID + "'; "))
                   NeedRefreshFormGrid = false;             
            }
  */
 //======================================================================
   /*     	return  "System" + Var.CR +			
					"System.ComponentModel" + Var.CR +
					"System.ComponentModel.Design" + Var.CR +
					"System.ComponentModel.Design.Serialization" + Var.CR +
					"System.Collections" + Var.CR +
					"System.Diagnostics" + Var.CR +
					"System.Globalization" + Var.CR +
					"System.IO" + Var.CR + 
					"System.Reflection" + Var.CR +
					"System.Runtime.Serialization.Formatters.Binary" + Var.CR +
					"System.Text" + Var.CR +
					"System.Windows.Forms" + Var.CR +
					"System.Xml" + Var.CR +
					"System.CodeDom.Compiler" + Var.CR +
					"System.CodeDom" + Var.CR +
					"Microsoft.CSharp";*/
//======================================================================
//Type.GetType("System.Windows.Forms.CheckBox"), 
                                                      
 //static Type  t = Assembly.GetExecutingAssembly().GetType("System.Windows.Forms.ColorDialog");
                      //System.Windows.Forms.Ge
                      
                     //static Type t2 = Type.GetType ("System.Windows.Forms.ColorDialog, mscorlib, Version=2.0.0.0, " +
    //"Culture=neutral, PublicKeyToken=b77a5c561934e089");            	
//======================================================================  
 //((FormCustom)host.RootComponent).TextQuery = "";
            	  
            		
     /*       	//FormCustom gfg = new FormCustom();
            	//gfg.Show();
            		
            	//((FormCustom)host.RootComponent).Show();
            	//((FormCustom)host.RootComponent).TextQuery = "";
            		
        	//button1.Location.X = button1.Location.X + 20;
        	//button1.
        	button1.Location = new System.Drawing.Point(button1.Location.X + 20, button1.Location.Y);
     
        	//button1.Size = new System.Drawing.Size(1022, 26);
        	
        	
        	return;
        	//string  s = "SSSS";
            //s = s.Replace("S", "SS");
            //SM(s, "","");
            string sel1 = TextTest.SelectedText;                        
            System.Type type = textSQL1.GetType();
            PropertyInfo[] props = type.GetProperties(); 
            //PropertyInfo eed = props[1];            
            //var prop = props.Where(x => x.Name == sel1);            
            //PropertyInfo eed = prop.ToArray()[1];                       
            PropertyInfo prop = props.Where(x => x.Name == sel1).First();
            sys.SM(prop.Name);
            prop.SetValue(textSQL1, prop.GetValue(textCode, null), null); 
            
                       
            //IEnumerable<PropertyInfo> props2 = props.Where(x => x.Name == "RightToLeft");
            
            //props2.
                
            //SM(props2.Count().ToString());
            
            //var props3 = props2[1];
             //foreach (var prop in props2)
                    // {
                         
               //         SM(prop.Name);
                        //if (!prop.CanWrite || !prop.CanWrite || prop.Name == "name") continue;
                        //prop.SetValue(dst, prop.GetValue(original, null), null);
                  //   }
             
            
            //PropertyInfo props3 = ((PropertyInfo[])props2)[1];
            
            //PropertyInfo prop = props2[0];  
            //SM(prop.Name);
            //if (!prop.CanWrite)   
            //{
            //    string FileName = @"outputhand.txt";
		    //    StreamWriter myfile = new StreamWriter(FileName, true);
            //    myfile.WriteLine(prop.Name);
            //    myfile.Close();	
            //    prop.SetValue(fctb1, prop.GetValue(textSQL1, null), null);                  
            //} 
*/
//======================================================================            	
//шифрование строки через xor делается примерно так:
//string original = "Hello, World!";
//string encoded = new string(original.Select(c => (char)(c ^ 42)).ToArray());
//string decoded = new string(encoded .Select(c => (char)(c ^ 42)).ToArray()); 
//======================================================================  
//if (Type == "Main") Form1.IsMdiContainer = true;
//======================================================================  
 //Запуск формы прикладного приложения (подсистемы).
		/*public static FormCustom FormShow(string FormName)
		{					
			if (FormName == "")
            {
                sys.SM("Не указана форма для запуска!");            	 
            }
			
			string FileName = "";
			sys.GetPathForm(FormName, sys.Mode, out FileName);
			bool FileExists = File.Exists(FileName);
			bool NeedLoad = !FileExists;			
			string GUIDBD;
			string FormType;
			string TextQuery;
            //string Mes =
            //   	    "FormShow FormName="            + FormName                + Var.CR +
			//		"FormShow Var.connectionID="    + Var.connectionID        + Var.CR +
			//		"FormShow Var.connectionName="  + Var.connectionName      + Var.CR + 
			//		"FormShow sys.UserForm="        + sys.UserForm            + Var.CR + 
            //	    "FormShow sys.Mode="        + sys.Mode.ToString() + Var.CR;
			//sys.SM(Mes);
			//Текст запросов.                   
            //((FormCustom)host.RootComponent).TextQuery = fctbFormSQL.Text;
            
            string SQLLocal = "";
            if (sys.Mode)            
                SQLLocal = "SELECT Type, GUIDTest, QueryTest FROM fbaProject WHERE Name = '" + FormName + "'";            
            else
                SQLLocal = "SELECT Type, GUID, Query FROM fbaProject WHERE Name = '" + FormName + "'";
			
            Var.conSys.GetValue3(SQLLocal, out FormType, out GUIDBD, out TextQuery);
            
            if ((GUIDBD == "") && (sys.Mode == false))
			{
				sys.SM("Форма в базе данных не найдена: " + FormName); 
				return null;
			}
			if (FileExists)
			{
			    string GUIDFile = sys.GUIDRead(FileName);				
				if (GUIDFile != GUIDBD) NeedLoad = true;			
		    }
			if (NeedLoad) 
			{
				//sys.SM("Загрузка формы из БД: " + FormName); 
				if (!Var.conSys.ReadFormFromDataBase64(FileName, FormName, sys.Mode)) return null;
			}
			 
			if (!File.Exists(FileName))
			{
				sys.SM("Форма не найдена: " + FileName);
				return null;
			}
			Assembly assembly = null;
			try
			{ 
				assembly = Assembly.LoadFile(FileName);
			}
			catch (Exception ex)
			{
				sys.SM("Ошибка загрузки формы: " + FileName);
				return null;
			}
						
			if (FormType == "DLL") return null;
	        Type type = assembly.GetType("FBA." + FormName);
	        var Form1 = (FormCustom)Activator.CreateInstance(type);
	        Form1.TextQuery = TextQuery;	        	      
	        return Form1; 	          
		}*/
//======================================================================             	
 //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    //static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); 
            
            	//Использование
            	 //return SendMessage(hWnd, (int)btn, wParam, xyPoint);
//======================================================================
/* //Получить версию сборки, приложения.
        public static void GetAssemblyVersion(Type type, 
                                              out string AName,
                                              out string ApplicationVersion, 
                                              //out string DeploymentVersion, 
                                              out string AssemblyVersion, 
                                              out string VersionCompatibility, 
                                              out string ProcessorArchitecture, 
                                              out string AssemblyFullName)
		{
        	//AName                  = "";
        	ApplicationVersion    = System.Windows.Forms.Application.ProductVersion;
        	//DeploymentVersion     = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			//AssemblyVersion       = ""; 
			//VersionCompatibility  = "";
			ProcessorArchitecture = ""; 
			//AssemblyFullName      = "";				
        	Assembly asm = Assembly.GetAssembly(type);
        	if (asm == null)  return;   
			AssemblyName asmName  = asm.GetName();
			AName                 = asmName.Name;
			AssemblyVersion       = asmName.Version.ToString();
			//VersionCompatibility  = asmName.VersionCompatibility.ToString();
			ProcessorArchitecture = asmName.ProcessorArchitecture.ToString();
			//AssemblyFullName      = asmName.FullName;				
		}
*/            	
//======================================================================            	
/*        //Удаление файла по FileInfo
        public static string DeleteFile(FileInfo fileinfo)
        {
        	try 
			{
				fileinfo.Delete();
				return "";
			}
			catch 
			{
				return fileinfo.Name;
			}	        	
        }
*/            
//====================================================================== 
/*Открывается проводник с открытой указанной папкой. Как сделать, чтоб сразу был выделен тот файл, который нужно в этой папке?            	
Process PrFolder = new Process();
ProcessStartInfo psi = new ProcessStartInfo();
string file = @"C:\sample.txt";  
psi.CreateNoWindow = true;
psi.WindowStyle = ProcessWindowStyle.Normal;
psi.FileName = "explorer";  
psi.Arguments = @"/n, /select, " + file;
PrFolder.StartInfo = psi;
PrFolder.Start();            	
 */           	
//======================================================================
       
        
//[DllImport("sys.dll", CharSet = CharSet.Auto, SetLastError = true)]
//static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); 
//======================================================================            	
            //if (SenderName == "MainMenu_N5_1") if (!MainMenu_N5_1.Checked) tabForm7.Parent = null; else tabForm7.Parent = tabControlForm;
            //if (SenderName == "MainMenu_N5_1") if (!MainMenu_N5_1.Checked) tabControlForm.TabPages.Remove(tabForm7); else tabControlForm.TabPages.Add(tabForm7);
                        	
//======================================================================               	
//Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");            	
            //var dllDirectory = @"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\FormTest";
            //Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);            	
//======================================================================              	
 /*Assembly a = Assembly.Load("dllcsharp");
            Object o = a.CreateInstance("vscode");
            Type t = a.GetType("vscode");
 
            Object[] numbers = new Object[2];
            numbers[0] = 2;
            numbers[1] = 3;
            MethodInfo mi = t.GetMethod("add");
            Console.WriteLine(mi.Invoke(o, numbers));
            mi = t.GetMethod("sub");
            Console.WriteLine(mi.Invoke(o, numbers));
            //чтобы консоль мгновенно не закрылась
            Console.ReadLine();  
//Как вызывать
int a = 0;
object [] obj = new object[] { a };
 
mi.Invoke(null, obj);
Console.WriteLine(obj[0]);          	
*/
//======================================================================                
/*
 using System;
using System.Reflection;
class Module1
{
    public static void Main()
    {
        // This variable holds the amount of indenting that 
        // should be used when displaying each line of information.
        Int32 indent = 0;
        // Display information about the EXE assembly.
        Assembly a = typeof(Module1).Assembly;
        Display(indent, "Assembly identity={0}", a.FullName);
        Display(indent+1, "Codebase={0}", a.CodeBase);
        // Display the set of assemblies our assemblies reference.
        Display(indent, "Referenced assemblies:");
        foreach (AssemblyName an in a.GetReferencedAssemblies() )
        {
             Display(indent + 1, "Name={0}, Version={1}, Culture={2}, PublicKey token={3}", an.Name, an.Version, an.CultureInfo.Name, (BitConverter.ToString (an.GetPublicKeyToken())));
        }
        Display(indent, "");
        // Display information about each assembly loading into this AppDomain.
        foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies())
        {
            Display(indent, "Assembly: {0}", b);
            // Display information about each module of this assembly.
            foreach ( Module m in b.GetModules(true) )
            {
                Display(indent+1, "Module: {0}", m.Name);
            }
            // Display information about each type exported from this assembly.
            indent += 1;
            foreach ( Type t in b.GetExportedTypes() )
            {
                Display(0, "");
                Display(indent, "Type: {0}", t);
                // For each type, show its members & their custom attributes.
                indent += 1;
                foreach (MemberInfo mi in t.GetMembers() )
                {
                    Display(indent, "Member: {0}", mi.Name);
                    DisplayAttributes(indent, mi);
                    // If the member is a method, display information about its parameters.
                    if (mi.MemberType==MemberTypes.Method)
                    {
                        foreach ( ParameterInfo pi in ((MethodInfo) mi).GetParameters() )
                        {
                            Display(indent+1, "Parameter: Type={0}, Name={1}", pi.ParameterType, pi.Name);
                        }
                    }
                    // If the member is a property, display information about the property's accessor methods.
                    if (mi.MemberType==MemberTypes.Property)
                    {
                        foreach ( MethodInfo am in ((PropertyInfo) mi).GetAccessors() )
                        {
                            Display(indent+1, "Accessor method: {0}", am);
                        }
                    }
                }
                indent -= 1;
            }
            indent -= 1;
        }
    }
    // Displays the custom attributes applied to the specified member.
    public static void DisplayAttributes(Int32 indent, MemberInfo mi)
    {
        // Get the set of custom attributes; if none exist, just return.
        object[] attrs = mi.GetCustomAttributes(false);
        if (attrs.Length==0) {return;}
        // Display the custom attributes applied to this member.
        Display(indent+1, "Attributes:");
        foreach ( object o in attrs )
        {
            Display(indent+2, "{0}", o.ToString());
        }
    }
    // Display a formatted string indented by the specified amount.
    public static void Display(Int32 indent, string format, params object[] param) 
    {
        Console.Write(new string(' ', indent*2));
        Console.WriteLine(format, param);
    }
}
//The output shown below is abbreviated.
//
//Assembly identity=ReflectionCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//  Codebase=file://C:/Documents and Settings/test/My Documents/Visual Studio 2005/Projects/Reflection/Reflection/obj/Debug/Reflection.exe
//Referenced assemblies:
//  Name=mscorlib, Version=2.0.0.0, Culture=, PublicKey token=B7-7A-5C-56-19-34-E0-89
//
//Assembly: mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//
//  Type: System.Object
//    Member: GetType
//    Member: ToString
//    Member: Equals
//      Parameter: Type=System.Object, Name=obj
//    Member: Equals
//      Parameter: Type=System.Object, Name=objA
//      Parameter: Type=System.Object, Name=objB
//    Member: ReferenceEquals
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//      Parameter: Type=System.Object, Name=objA
//      Parameter: Type=System.Object, Name=objB
//    Member: GetHashCode
//    Member: .ctor
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//
//  Type: System.ICloneable
//    Member: Clone
//
//  Type: System.Collections.IEnumerable
//    Member: GetEnumerator
//      Attributes:
//        System.Runtime.InteropServices.DispIdAttribute
//
//  Type: System.Collections.ICollection
//    Member: CopyTo
//      Parameter: Type=System.Array, Name=array
//      Parameter: Type=System.Int32, Name=index
//    Member: get_Count
//    Member: get_SyncRoot
//    Member: get_IsSynchronized
//    Member: Count
//      Accessor method: Int32 get_Count()
//    Member: SyncRoot
//      Accessor method: System.Object get_SyncRoot()
//    Member: IsSynchronized
//      Accessor method: Boolean get_IsSynchronized()
//
//  Type: System.Collections.IList
//    Member: get_Item
//      Parameter: Type=System.Int32, Name=index
//    Member: set_Item
//      Parameter: Type=System.Int32, Name=index
//      Parameter: Type=System.Object, Name=value
//    Member: Add
//      Parameter: Type=System.Object, Name=value
//    Member: Contains
//      Parameter: Type=System.Object, Name=value
//    Member: Clear
//    Member: get_IsReadOnly
//    Member: get_IsFixedSize
//    Member: IndexOf
//      Parameter: Type=System.Object, Name=value
//    Member: Insert
//      Parameter: Type=System.Int32, Name=index
//      Parameter: Type=System.Object, Name=value
//    Member: Remove
//      Parameter: Type=System.Object, Name=value
//    Member: RemoveAt
//      Parameter: Type=System.Int32, Name=index
//    Member: Item
//      Accessor method: System.Object get_Item(Int32)
//      Accessor method: Void set_Item(Int32, System.Object)
//    Member: IsReadOnly
//      Accessor method: Boolean get_IsReadOnly()
//    Member: IsFixedSize
//      Accessor method: Boolean get_IsFixedSize()
//
//  Type: System.Array
//    Member: IndexOf
//      Parameter: Type=T[], Name=array
//      Parameter: Type=T, Name=value
//    Member: AsReadOnly
//      Parameter: Type=T[], Name=array
//    Member: Resize
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//      Parameter: Type=T[]&, Name=array
//      Parameter: Type=System.Int32, Name=newSize
//    Member: BinarySearch
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//      Parameter: Type=T[], Name=array
//      Parameter: Type=T, Name=value
//    Member: BinarySearch
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//      Parameter: Type=T[], Name=array
//      Parameter: Type=T, Name=value
//      Parameter: Type=System.Collections.Generic.IComparer`1[T], Name=comparer 
*/            	
//======================================================================              	
   
        //Компиляция и запись формы в БД.
        /*private bool SaveAndCompilForm(string FormID, string FormType, string FormName, bool Compile)
        {        
            if (sys.ErrorCheck(FormName == "", "Нет имени формы!")) return false;
            bool NewForm = (FormID == "");  //Если форма новая.
                                                                              
            //Это получение XML кода формы и CS кода + добавляенный прикладной код.
            //DoFlush = Это признак изменения формы, если true значит внешний вид формы изменился.
            tbFormType.Text  = FormType;                                   
           
            bool DoFlush = false;
            loader.dirty = Compile;
            if (FormType == "DLL") DoFlush = loader.FlushDLL();
              else DoFlush = loader.FlushForm();
            
            int BeginNumLineAppCode = 0;
            textCodeApp.Text = GetCodeApp(FormType, out BeginNumLineAppCode);
            
            //Папка, куда компилируем
            string FormFile = sys.PathTest + FormName + ".dll";
                         
            if (Compile)
            {                                                                 
                //Настройки компиляции
                var providerOptions = new Dictionary<string, string>
                {{"CompilerVersion", "v4.0"}};
                
                var provider = new CSharpCodeProvider(providerOptions);            
                var compilerParams = new CompilerParameters
                {            
                    OutputAssembly     = FormFile, 
                    GenerateExecutable = true,
                    CompilerOptions    = "/target:library"                                      
                };
                
                //Включение сборок в скомпилированный файл    
                //foreach(string assembly in textAssembly.Lines) 
                //    if (assembly != "") compilerParams.ReferencedAssemblies.Add(assembly);
                
                System.IO.Directory.SetCurrentDirectory(sys.PathTest);
                
                //compilerParams.ReferencedAssemblies.Add(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\FormTest\sys.dll"); //Включаем общую библиотеку.        
                //compilerParams.ReferencedAssemblies.Add(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\FormTest\sss.dll"); //Включаем общую библиотеку.        
                
                //compilerParams.ReferencedAssemblies.Add("sys.dll"); //Включаем общую библиотеку.
                                             
                for (int i = 0; i < textAssembly.Lines.Count; i++)
                {      
                    string s1 = textAssembly.Lines[i].Trim();
                    s1 = s1.Replace(" ", "");
                    if (s1 != "") 
                    {
                        if (s1.ToLower().IndexOf(".dll") == -1) s1 += @".dll";
                        compilerParams.ReferencedAssemblies.Add(s1);
                    }
                }
                               
                //Компиляция
                CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, textCodeApp.Text); //textCS.Text
                compilerParams = null;
                provider       = null;
                
                rbLog.Clear();
                //Если есть ошибки компиляции.
                if (results.Errors.Count > 0) //sys.SM("Ошибка!");                                       
                {
                    rbLog.ForeColor = Color.Red;
                    rbLog.AppendText(DateTime.Now.ToLongTimeString() + ": Количество ошибок: " + results.Errors.Count + Var.CR) ;
                    
                    //Выводим инфу об ошибках
                    for (int i = 0; i < results.Errors.Count; i++)
                    {   
                        string ErrorMes = DateTime.Now.ToLongTimeString() + ":" + " Ошибка." + results.Errors[i].ErrorNumber;
                        if ((results.Errors[i].Line > 0) || (results.Errors[i].Column > 0)) ErrorMes += " Строка: " + (results.Errors[i].Line - BeginNumLineAppCode) + " В полном тексте: " + results.Errors[i].Line + " Позиция: " + results.Errors[i].Column;
                        if (results.Errors[i].ErrorText != "") ErrorMes += " Описание: " + results.Errors[i].ErrorText;
                        if (results.Errors[i].FileName != "") ErrorMes += " " + results.Errors[i].FileName;
                        rbLog.AppendText(ErrorMes + Var.CR);  
                    }               
                     
                    tabControlForm.TabIndex = 1;
                    if (!(sys.SM("При компиляции формы обнаружены ошибки! Сохранить с ошибками?", 
                                  MessageType.Question, "Компиляция формы"))) return false;                                    
                } else
                {
                     //Ошибок компиляции нет.
                     rbLog.ForeColor = Color.Green;
                     rbLog.AppendText(DateTime.Now.ToLongTimeString() + ": Компиляция успешная, ошибок нет. Путь: " + results.PathToAssembly + Var.CR);
                }
                
                //Запись файла.Записываем только тестовую версию. Рабочая всегда обновляется из тестовой версии.               
                Var.conSys.SaveFileToDataBase64(FormFile, ref FormID);
                if (sys.ErrorCheck(((FormID == "") || (FormID == null)), "Ошибка записи формы!")) return false;
                tbFormID.Text   = FormID;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();  
            }
           
            string FormXML   = textXML.Text.Replace("'",   "''");
            string FormCode  = textCS.Text.Replace("'",    "''");
            string TextCode  = textCode.Text.Replace("'",  "''");
            string TextQuery = textQuery.Text.QueryQuote();            
            string HashMD5   = Crypto.MD5(textCodeApp.Text);
                          
            SQL = "UPDATE fbaProject SET " +
                  "  Name             = '" + FormName + "'" + 
                  ", EntityID         = 100 " +                  
                  ", DateChangeTest   = current_timestamp " +       
                  ", UserChangeTestID = " + Var.UserID     +
                  ", Type             = '" + FormType     + "'" +
                  ", FormXMLTest      = '" + FormXML      + "'" +
                  ", FormCodeTest     = '" + FormCode     + "'" +
                  ", TextCodeTest     = '" + TextCode     + "'" +
                  ", CountRowsTest    = '" + textCodeApp.LinesCount + "'" +
                  ", HashTest         = '" + HashMD5      + "'" +
                  ", QueryTest        = '" + TextQuery    + "'" +                
                  ", TextAssemblyTest = '" + textAssembly.Text + "'" +
                  ", TextUsingTest    = '" + textUsing.Text    + "'" +
                  " WHERE id = " + FormID + "; \r\n";  
            
            if (NewForm)
            {                        
                  SQL += "UPDATE fbaProject SET DateCreateTest = current_timestamp" +  
                         ", UserCreateTestID = " + Var.UserID  +
                         " WHERE ID = " + FormID + "; \r\n";
            }
            Var.conSys.Exec(SQL);
            FormListGridRefresh();                                     
            return DoFlush;
        }*/            	
//======================================================================             	
 //FormCustom
            //int i = AssemblyApp.Asm.Count();
            //AssemblyApp.Asm[1] = assembly;
            //AssemblyApp.Name[1] = FormName;
           // AssemblyApp.Obj[1] = Form1;
           
              
            /*  int length = 0;
              int [] numbers = new int [5] {1,2,3,4,5};
              length = numbers.Length; //5
              Array.Resizeint>(ref numbers, 7);
              //либо так
              //Array.Resize(ref numbers, numbers.Length + 2);
              length = numbers.Length; //7
              Результат: {1,2,3,4,5,0,0} //- элементы
           
           
              int count = 0;
              List<int> numbers = new List<int>  { 1, 2, 3, 4, 5 };
              count = numbers.Count; //5
              numbers.Add(6);
              numbers.Add(7);
              count = numbers.Count; //7
              //преобразуем список в массив
              int [] numbers2 = numbers.ToArray<int>();
              
              //AssemblyApp[] AsmList = new AssemblyApp[1];
             
             */
         /*  
             public class AssemblyApp
    {
        public  string   Name;     //Имя модуля (Формы или DLL)
        public  Assembly Asm;      //Сборка
        public  Object   Obj1;      //Массив всех созданных модулей (форм и DLL) решения.
        public  string   FileName; //Имя файла модуля
    } 
         //AsmList[1].Asm  =  assembly;
            //AsmList[1].Name = FormName;
            //AsmList[1].Obj1 = Form1;
            
            //AsmList = 
    
         */                     //Name, Assembly Asm, Object Obj, string FileName)            	
            	
//======================================================================
            //foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //    if (assembly.GetName().Name == AssemblyName) return assembly;
            //} 
            //return null;                
//====================================================================== 
//Упорядочение по горизонтали:
//C#
//this.LayoutMdi(MdiLayout.TileHorizontal);
//1
//this.LayoutMdi(MdiLayout.TileHorizontal);                
//======================================================================
            
            /*TextQuery = "";
            FileName  = "";
            string GUIDBD;
            //if (FormName == "") return null;
            
            string SQLLocal = "";
            if (sys.Mode) SQLLocal = "SELECT Type, GUIDTest, QueryTest FROM fbaProject WHERE Name = '" + FormName + "'";            
                else SQLLocal = "SELECT Type, GUID, Query FROM fbaProject WHERE Name = '" + FormName + "'";            
            Var.conSys.GetValue3(SQLLocal, out FormType, out GUIDBD, out TextQuery);
            
            if ((GUIDBD == "") && (sys.Mode == false))
            {
                if ((FormType == "Form") || (FormType == "Main")) sys.SM("Форма в базе данных не найдена: " + FormName);
                if (FormType == "DLL") sys.SM("Модуль DLL в базе данных не найден: " + FormName);
                return null;
            }
            */
            //string TextQuery;
            /*string Mes =
                       "ModuleLoad FormName="            + FormName                + Var.CR +
                    "ModuleLoad Var.connectionID="    + Var.connectionID        + Var.CR +
                    "ModuleLoad Var.connectionName="  + Var.connectionName      + Var.CR + 
                    "ModuleLoad sys.UserForm="        + sys.UserForm            + Var.CR + 
                    "ModuleLoad sys.Mode="        + sys.Mode.ToString() + Var.CR;
            sys.SM(Mes);*/
            //Текст запросов.                   
            //((FormCustom)host.RootComponent).TextQuery = fctbFormSQL.Text;
                            //if ((GUIDBD == "") && (!Mode))
            //{
            //    if ((FormType == "Form") || (FormType == "Main")) sys.SM("Форма в базе данных не найдена: " + FormName);
            //    if (FormType == "DLL") sys.SM("Модуль в базе данных не найден: " + FormName);
            //    return false;
            //} 
             
//======================================================================
//GC.Collect();
//GC.WaitForPendingFinalizers();                  
//====================================================================== 
        //Сохранить без компиляции.
        //private void SaveWithoutCompile()
        //{
        //    //TextTest.AppendText(DateTime.Now.ToLongTimeString());
        //    if (SaveAndCompilForm(tbFormID.Text, tbFormType.Text, tbFormName.Text, false) == true)                              
        //    FormReload();             
        //    //TextTest.AppendText(DateTime.Now.ToLongTimeString());
        //}                
//====================================================================== 
 /*
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel.Design"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel.Design.Serialization"));
            ns.Imports.Add(new CodeNamespaceImport("System.Collections"));
            ns.Imports.Add(new CodeNamespaceImport("System.Diagnostics"));
            ns.Imports.Add(new CodeNamespaceImport("System.Globalization"));
            ns.Imports.Add(new CodeNamespaceImport("System.IO"));
            ns.Imports.Add(new CodeNamespaceImport("System.Reflection"));
            ns.Imports.Add(new CodeNamespaceImport("System.Runtime.Serialization.Formatters.Binary"));
            ns.Imports.Add(new CodeNamespaceImport("System.Text"));
            ns.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));
            ns.Imports.Add(new CodeNamespaceImport("System.Xml"));
            ns.Imports.Add(new CodeNamespaceImport("System.CodeDom.Compiler"));
            ns.Imports.Add(new CodeNamespaceImport("System.CodeDom"));
            ns.Imports.Add(new CodeNamespaceImport("Microsoft.CSharp"));            
            ns.Imports.Add(new CodeNamespaceImport("sys.dll"));*/
            
            /*ns.Imports.Add(new CodeNamespaceImport("System"));
            //ns.Imports.Add(new CodeNamespaceImport("System.Core"));
            ns.Imports.Add(new CodeNamespaceImport("System.Data"));
            ns.Imports.Add(new CodeNamespaceImport("System.Data.DataSetExtensions"));
            ns.Imports.Add(new CodeNamespaceImport("System.Deployment"));
            ns.Imports.Add(new CodeNamespaceImport("System.Drawing"));
            ns.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel.Design"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel.Design.Serialization"));
            ns.Imports.Add(new CodeNamespaceImport("System.Collections"));
            ns.Imports.Add(new CodeNamespaceImport("System.Diagnostics"));
            ns.Imports.Add(new CodeNamespaceImport("System.Globalization"));
            ns.Imports.Add(new CodeNamespaceImport("System.IO"));
            ns.Imports.Add(new CodeNamespaceImport("System.Reflection"));
            ns.Imports.Add(new CodeNamespaceImport("System.Runtime.Serialization.Formatters.Binary"));
            ns.Imports.Add(new CodeNamespaceImport("System.Text"));
            ns.Imports.Add(new CodeNamespaceImport("System.Xml"));
            ns.Imports.Add(new CodeNamespaceImport("System.Xml.Linq"));
            ns.Imports.Add(new CodeNamespaceImport("System.CodeDom.Compiler"));
            ns.Imports.Add(new CodeNamespaceImport("System.CodeDom"));
            ns.Imports.Add(new CodeNamespaceImport("Microsoft.CSharp"));            
            */                
//======================================================================
            
              
            
                //for (int i = textCS.Lines.Count-1; i > 0; i--)
                //{      
                //    string s1 = textCS.Lines[i].Trim();
                //    if (s1.IndexOf("[System.STAThreadAttribute()]") > -1)
                //    {
                //        //BeginNumLineAppCode = i + 5;
                //        break;
                //    }      
               //}
                
               //int i1 = textCS.Text.IndexOf("[System.STAThreadAttribute()]");
               //int i2 = textCS.Text.IndexOf("}", i1);
               //int i1 = 
                   //textCS.   
                //for (int i = textCS.Lines.Count - 1; i > 0; i--)
                //{      
                 //   string s1 = textCS.Lines[i].Trim();
                //    if (s1.IndexOf("{") > -1)
                //    {
                //        //BeginAppCode = i + 1;
                //        break;
                //    }      
                //}
                //int i1 = textCS.Text.IndexOf("{");
                
                
                
//======================================================================
//Запись текста Query в локальную БД.
        /*private static void SaveQueryToDataBase(string FormName, string QueryText, bool Mode)
        {
            string ID = Var.conSys.GetValue("SELECT ID FROM fbaProject WHERE Name = '" + FormName + "'");
            string SQLLocal = "";  
            string FieldQuery;
            //if (Mode) FieldQuery = "Query"; else FieldQuery = "QueryTest";
            if (ID == "") SQLLocal = "INSERT INTO fbaProject (Name) VALUES ('" + FormName + "')";
            if (ID != "") SQLLocal = "UPDATE fbaProject SET " + FieldQuery + " = '" + QueryText + "' WHERE Name = '" + FormName + "'";
            Var.conLite.Exec(SQLLocal);
        }*/
                   //{
                    //string FieldTextQuery;
                    //if (Mode) FieldTextQuery = "QueryTest"; else FieldTextQuery = "Query";
                    //Var.conLite.Exec("UPDATE fbaProject SET " + FieldTextQuery + " = " + TextQuery);
                //} 
               //else 
//======================================================================                              
/*string ID = sys.DGVStr(dgvConnectionList, "ID");
            if (ID  == "") return;
            string SQL;
            string ConnectionName;
            string ServerType;
            string ServerName;
            string DatabaseLogin;
            string DatabasePass;
            string DatabaseName;
            string UserLogin;
            string UserPass;
            string UserForm;
            SQL = "SELECT ConnectionName, ServerType, ServerName, DatabaseLogin, DatabasePass, " + 
                      "DatabaseName, UserLogin, UserPass, UserForm " + 
                      "FROM fbaConList WHERE ID = " + ID;
            Var.conLite.GetValue9(SQL, out ConnectionName,
                                         out ServerType,
                                         out ServerName, 
                                         out DatabaseLogin,
                                         out DatabasePass, 
                                         out DatabaseName, 
                                         out UserLogin,
                                         out UserPass,
                                         out UserForm); 
            
            UserPass = Crypto.EncryptAES(UserPass);
            */
                            
//======================================================================
     //Object[] ObjParams = new Object[1];   
    //ObjParams[0] = "dfdf";
    //Object i = sys.MethodCall(f1, "geti", ObjParams); 
    //string s = i.ToString();               
//====================================================================== 
/*namespace ConsoleApplication
{
    public class Compiler : MarshalByRefObject
    {
        const string SourceCode = @"using System; using System.Linq; namespace        Testing { class Main { public static void Method(){   Console.WriteLine(""Testing.Main.Method""); } } }";
    public void CompileAndRun()
    {
        var providerOptions = new Dictionary<string, string>
        {
            {"CompilerVersion", "v3.5"}
        };
        var provider = new CSharpCodeProvider(providerOptions);
        var compilerParams = new CompilerParameters();
        compilerParams.GenerateExecutable = false;
        compilerParams.GenerateInMemory = true;
        compilerParams.ReferencedAssemblies.Add("System.Core.Dll");
        var compileResults = provider.CompileAssemblyFromSource(compilerParams, SourceCode);
        if (compileResults.Errors.HasErrors)
        {
            foreach (CompilerError err in compileResults.Errors)
            {
                Console.WriteLine("Ошибка: {0}", err.ErrorText);
            }
            return;
        }
        var assembly = compileResults.CompiledAssembly;
        var typeOfMainClass = assembly.GetType("Testing.Main");
        var method = typeOfMainClass.GetMethod("Method");
        method.Invoke(null, null);
    }
}
class Program
{
    static void Main(string[] args)
    {            
        var domain = AppDomain.CreateDomain("TempDomain");
        Compiler comp = (Compiler)domain.
            CreateInstanceAndUnwrap(typeof(Compiler).Assembly.FullName, "ConsoleApplication.Compiler");
        comp.CompileAndRun();
        AppDomain.Unload(domain);
        Console.ReadKey();
    }        
}*/                
//======================================================================  
//E:\000_Travin\Projects C#\Проба динамическая компиляция\CompileMaster\WindowsFormsApplication1\WindowsFormsApplication1                
//====================================================================== 
            //run = new System.Diagnostics.Process();           
            //run.StartInfo.Arguments = @"ConnectionID=" + Var.connectionID + @" FormName=" + FormName + @" Mode=" + Mode.ToString();
            //run.StartInfo.FileName = FileName;
            //run.Start(); //run.WaitForExit();                
//====================================================================== 
//if (WaitForExit) runexe.WaitForExit();
            //else                  
//====================================================================== 
/*return;
               //if (!sys.FileCopy(sys.PathTest + FormName + ".dll", sys.PathMain + FormName + ".dll")) return;
               //string PathM = @"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\FormTest\Form7.dll";
               
               //string str1 =  sys.PathMain + FormName + ".dll";
              // System.AppDomain NewAppDomain = System.AppDomain.CreateDomain("NewApplicationDomain");
               // Load the assembly and call the default entry point:
               //NewAppDomain.ExecuteAssembly(str1);
               /// Create an instance of RemoteObject:
               //NewAppDomain.CreateInstanceFrom(str1, "FBA.Form7");
               
               //return;
               
               
               //Directory.SetCurrentDirectory(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\FormTest\");
               string PathM = FormName + ".dll";
               AppDomain newD;
               newD = System.AppDomain.CreateDomain("newD");
               //newD.As
               //newD.AssemblyResolve += new ResolveEventHandler(LoadFromS1);
               newD.CreateInstanceFrom(PathM, "FBA." + FormName);
                 
               //Assembly assembly1;
               //       assembly1.Lo
               //newD.
                //newD.As
               string sa = "";
               foreach (Assembly assembly in newD.GetAssemblies())
               {
                   sa += "Name:" + assembly.GetName().Name + " FullName: " + assembly.FullName + Var.CR;
                  //if (assembly.GetName().Name == projectName)
                  //{
                  //    asm = assembly;
                  //    return true;
                  //}
               } 
               sys.SM(sa);
               //((Form)f1).Show();
               
               //var assembly2 = (Assembly)newD.GetAssemblies().Where(x => x.FullName == "Form7, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null").FirstOrDefault();
               //var assembly2 = (Assembly)newD.GetAssemblies().Where(x => x.GetName().Name == FormName).FirstOrDefault();
               
               //Type type1 = assembly2.GetType("FBA." + FormName);
               //var form22 = (Form)Activator.CreateInstance(type1);
               //form22.ShowDialog();
               //form22 = null;
               //type1 = null;
               //assembly2 = null;
               AppDomain.Unload(newD); 
                
               
               
               
               
               
               GC.Collect();
               GC.WaitForPendingFinalizers();
               sys.FileDelete(PathM);     */           
//====================================================================== 
        /*private void SetText(string text)
        {
            //InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
            //If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {    
                var d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {        
                //iq++;
                //if (iq > 50) MessageBox.Show("Остановка!");
                this.textBox1.AppendText(text + "\n");
            }
        }*/                
//====================================================================== 
        
        /*static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
        {
            //return null;
            //Здесь подставляется путь, где искать sys.
            string PathDLL = "";
            if (sys.Mode) PathDLL = sys.PathTest;
            if (!sys.Mode) PathDLL = sys.PathWork;
            PathDLL = new AssemblyName(args.Name).Name + ".dll";
            if (!File.Exists(PathDLL)) 
            { 
                PathDLL = sys.PathMain;
                if (!File.Exists(PathDLL)) 
                { 
                    sys.SM("Не найден файл DLL: " + PathDLL);
                    return null;
                }
            }
                        
            Assembly assembly = Assembly.LoadFrom(PathDLL);
            return assembly;
        }*/
                        
        //void BtnTestClick(object sender, EventArgs e)
        //{          
            
            //string FormName = "";
            //sys.GetParamEnter("ConnectionID=21 FormName=Form9 Mode=True", out Var.connectionID, out FormName, out sys.Mode);
            /*string Mes = 
                    "Button1 Var.connectionID="    + Var.connectionID        + Var.CR +
                    "Button1 Var.connectionName="  + Var.connectionName      + Var.CR + 
                    "Button1 sys.UserForm="        + sys.UserForm            + Var.CR + 
                    "Button1 sys.Mode="        + sys.Mode.ToString() + Var.CR + 
                    "Button1 Var.connectionName =" + Var.connectionName      + Var.CR;
            sys.SM(Mes);*/
        //} 
                
//using System.IO;
//using System.Data; 
//using System.Reflection;                                       
//using System.Diagnostics;
//using Microsoft.VisualStudio.Data;//.dll;
//using System.Data.Sql;
//using System.Data.SqlClient;
//using System.Data.SqlTypes;
//using System.Text;
//using System.Security.Cryptography;
                
            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);                
//====================================================================== 
  /*      //Сервер приложений.
        private void MyServer()
        {           
            //Определим 4 потока на каждый процессор
            int MaxThreadsCount = Environment.ProcessorCount * 4;                                    
                           
            //Максимальное и минимальное количество рабочих потоков
            ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);   
            ThreadPool.SetMinThreads(2, 2);                                
            
            //Порт для TcpListener = 9595.
            Int32 port = 9595;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
           
            server = new TcpListener(localAddr, port);
            //Запускаем TcpListener и начинаем слушать клиентов.
            server.Start();                                                
            
            //lbAppStatus2.ForeColor = Color.Green;
            //SetText("Application Server is running");
            //lbAppStatus2.Text = "Running";  
            
            try
            {
                //Принимаем клиентов в бесконечном цикле.
                while (true)
                {                                                                        
                    //При появлении клиента добавляем в очередь потоков его обработку.
                    ThreadPool.QueueUserWorkItem(ServerProcess, server.AcceptTcpClient());                                       
                    //Общее количество запросов серверу приложений.
                    //counter++; 
                    //Action action = () => lbQuery2.Text = counter.ToString();
                    //lbQuery2.Invoke(action);
                }
            }
            catch (Exception ex)
            {
                //В случае ошибки, выводим что это за ошибка, но работу сервера не прерываем.
                SetText("An error occurred while processing messages from the client: " + ex.Message);   
            }
            finally
            {
                // Останавливаем TcpListener.
                server.Stop();
            }            
        }
*/            
//====================================================================== 
/*private void SetText(string text)
        {
            //InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
            //If these threads are different, it returns true.
            if (tbLogServer.InvokeRequired)
            {    
                var d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {        
                tbLogServer.AppendText(text);     // + Var.CR
            }
        } */               
//====================================================================== 
//Запись DataTable. В строку. работает но много текста получается.   
        /*public static bool ExportDataTableToString(System.Data.DataTable DT, string TableName, bool ErrorShow, out string DataTableString)
        {                        
            if (File.Exists(FileName))
            {
                try
                {
                    File.Delete(FileName);
                }            
                catch (Exception e)
                {
                    sys.SM(e.Message);             
                    return false; 
                }
            }
            
            
            
            DataTableString = "";
            try
            {                
                var ndt = new NewDT();
                ndt.DT = DT;
                ndt.TableName = TableName;            
                var jsonFormatter = new DataContractJsonSerializer(typeof(NewDT)); 
                using (var ms = new MemoryStream())
                { 
                    jsonFormatter.WriteObject(ms, ndt);
                    //DataTableString = ms.ToString();
                    //byte[] bytes = ms.ToArray();
                    DataTableString = Encoding.UTF8.GetString(ms.ToArray());
                    if (ms != null) ms.Close();
                    jsonFormatter = null;
                } 
                return true;                
            }
            catch (Exception e)
            {
                if (ErrorShow) sys.SM(e.Message);
                return false;
            }                                
        }*/ 
        //Чтение сохранённого DataTable. Из строки.  
        /*public static bool ImportDataTableFromString(out System.Data.DataTable DT, out string TableName, string DataTableString, bool ErrorShow)
        {                                                                          
            try
            {
                var ndt = new NewDT();
                byte[] newBytes = Encoding.Default.GetBytes(DataTableString);
                //Convert.FromBase64String(DataTableString); //Byte из строки.
                
                var fs = new MemoryStream(newBytes);
                var jsonFormatter = new DataContractJsonSerializer(typeof(NewDT)); 
                ndt = (NewDT)jsonFormatter.ReadObject(fs);
                if (fs != null) fs.Close();
                jsonFormatter = null;                
                DT = ndt.DT; 
                TableName = ndt.TableName;
                return true;
            }
            catch (Exception e)
            {
                var DT1 = new System.Data.DataTable();
                DT = DT1;
                TableName = "";
                if (ErrorShow) sys.SM(e.Message);
                return false;
            }                               
        }*/   
  //Сохранение DataTable в CSV.
        /*public static bool ExportDataTableToCSV(System.Data.DataTable DT, String FileName)
        {             
            using (var sw = new StreamWriter(FileName, false))
            {
                int iColCount = DT.Columns.Count;
                // First we will write the headers.
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(String.Format(@"{0}:{1}", DT.Columns[i], DT.Columns[i].DataType.ToString().Replace(@"System.", "")));
                    if (i < iColCount - 1) sw.Write(";");                    
                }
                sw.Write(sw.NewLine);
                // Now write all the rows.
                foreach (DataRow dr in DT.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i])) sw.Write(dr[i].ToString());                       
                        else sw.Write(@"");
                         
                        if (i < iColCount - 1) sw.Write(";");                        
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }
            return true;
        } */
        
        
        
        
        //Загрузка DataTable из CSV.
        //public static bool ImportDataTableFromCSV(ref System.Data.DataTable DT, String FileName)
        /*public static void ImportDataTableFromString2(out System.Data.DataTable DT, string TableString, bool ErrorShow)
        {                        
            DT = null;
            try
            { 
               string[] csvRows = TableString.Split('\n');
               string[] headers = csvRows[0].Split(';');
               string[] fields = null; 
               var HeaderAndType = new string[2];
               var types         = new string[headers.Length];
               DT = new System.Data.DataTable();
               Type colType;
               int i = 0;
               foreach (string header in headers) 
               {
                   HeaderAndType = header.Split(':');
                   colType = Type.GetType(HeaderAndType[1], false, false);     //HeaderAndType[1]
                   //HeaderAndType[1] = HeaderAndType[1].Replace("\r", "");
                   DT.Columns.Add(HeaderAndType[0], colType); 
                   //DT.Columns.Add(HeaderAndType[0], colType != null ? colType : typeof(string));                   
                   types[i] = HeaderAndType[1];
                   i++;
               }
                 
               for (i = 1; i < csvRows.Length; i++)                     
               {
                  fields = csvRows[i].Split(';');
                  DataRow row = DT.NewRow();
                  row.ItemArray = fields;
                  DT.Rows.Add(row);
               }
            } catch (Exception ex)
            {
               if (ErrorShow) sys.SM("Ошибка при конвертировании строки в DataTable: " + Var.CR + ex.Message);              
            }    
        }
             
        //Загрузка DataTable из CSV.
        //public static bool ImportDataTableFromCSV(ref System.Data.DataTable DT, String FileName)
        public static void ImportDataTableFromCSV2(ref System.Data.DataTable DT, string  FileName)
        {
           string[] csvRows = System.IO.File.ReadAllLines(FileName);
           string[] fields = null; 
           foreach(string csvRow in csvRows)
           {
              fields = csvRow.Split(';');
              DataRow row = DT.NewRow();
              row.ItemArray = fields;
              DT.Rows.Add(row);
           }
        }                            
        
        
        
        
        //Загрузка DataTable из CSV.
        public static bool ImportDataTableFromCSV(ref System.Data.DataTable DT, String FileName)
        {           
            if (!File.Exists(FileName))
            {
                sys.SM("Файл не найден: " + FileName);                  
                return false;
            }
            DT = new System.Data.DataTable();
            var f  = new FileInfo(FileName);
            double readSize = 0;
            using (var sr = new StreamReader(FileName, System.Text.Encoding.ASCII))
            {
                String line;
                bool setColums = false;
                char[] splRow  = new char[] { ';' };
                char[] splCol  = new char[] { ':' };
                Int32 cols     = 0;
                while (sr.Peek() >= 0)
                {
                    try
                    {
                        line = sr.ReadLine();
                        readSize += line.Length;
                        if (string.IsNullOrEmpty(line)) continue;
                        var values = line.Split(splRow, StringSplitOptions.None);
                        if (!setColums)
                        {
                            setColums = true;
                            cols = values.Length;
                            String colName;
                            Type colType;
                            for (int colNum = 0; colNum < cols; colNum++)
                            {
                                if (values[colNum].IndexOfAny(splCol) != -1)
                                {
                                    var v = values[colNum].Split(splCol);
                                    colName = v[0];
                                    colType = Type.GetType(@"System." + v[1], false, false);
                                    DT.Columns.Add(colName, colType != null ? colType : typeof(String));
                                }
                                else DT.Columns.Add(values[colNum]);                               
                            }
                        }
                        else
                        {
                            try
                            {
                                DT.Rows.Add(values);
                            }
                            catch (Exception ex)
                            {                               
                                sys.SM(ex.Message + "\n" + line);
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        sys.SM(ex.Message);
                        return false;
                    }
                }
            }
            return true;
        }
        
          
        
        
        
												  
        //Загрузка DataTable из CSV.
        public static System.Data.DataTable ConvertCSVtoDataTable(string FileName)
        {
            //Пример использования:
            //string filepath = "d://ConvertedFile.csv";
            //DataTable res = ConvertCSVtoDataTable(filepath);
            
            var sr = new StreamReader(FileName);
            string[] headers = sr.ReadLine().Split(';'); 
            var dt = new System.Data.DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }  
        
        //Загрузка DataTable из CSV.
        public static System.Data.DataTable ReadCsvFile(string FileSaveWithPath)  
        {  
  
            var dtCsv = new System.Data.DataTable();  
            string Fulltext;  
            
            //string FileSaveWithPath = Server.MapPath("\\Files\\Import" + System.DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".csv");  
            //FileUpload1.SaveAs(FileSaveWithPath);  
            using(var sr = new StreamReader(FileSaveWithPath))  
            {  
                while (!sr.EndOfStream)  
                {  
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Count() - 1; i++)  
                    {  
                        string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                        {  
                            if (i == 0)  
                            {  
                                for (int j = 0; j < rowValues.Count(); j++)  
                                {  
                                    dtCsv.Columns.Add(rowValues[j]); //add headers  
                                }  
                            }  
                            else  
                            {  
                                DataRow dr = dtCsv.NewRow();  
                                for (int k = 0; k < rowValues.Count(); k++)  
                                {  
                                    dr[k] = rowValues[k].ToString();  
                                }  
                                dtCsv.Rows.Add(dr); //add other rows  
                            }  
                        }  
                    }  
                }  
            }              
            return dtCsv;  
        } 
        //Загрузка DataTable из CSV.
        public static string DataTableToCSV(this System.Data.DataTable datatable, char seperator)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                sb.Append(datatable.Columns[i]);
                if (i < datatable.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
            foreach (DataRow dr in datatable.Rows)
            {
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    sb.Append(dr[i].ToString());
        
                    if (i < datatable.Columns.Count - 1)
                        sb.Append(seperator);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
		*/                
//====================================================================== 
/*
 * //Получение параметров из запроса клиента. 
        private void GetListParams(string ParamStr, out string ClientIP, out string Command)
        {
            ClientIP = "";
            Command  = "";
            
            //Пример строки параметров: FormName=Form9 ConnectionID=21 Mode=True
            foreach(var par in ParamStr.Split(';'))
            {
                //par.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                if (par.Split('=')[0] == "ClientIP") ClientIP     = par.Split('=')[1].Trim();
                if (par.Split('=')[0] == "Command")  Command = par.Split('=')[1].Trim();
            }
        }
 */                 
//====================================================================== 
/*SQL = "select ServerName,    " +
                				 "ServerType,    " +
                				 "DatabaseName,  " +
                				 "DatabaseLogin, " +
               					 "DatabasePass,  " +
                				 "UserForm,      " +
                				 "UserLogin,     " +
               					 "UserPass       " +
                         "from fbaConList where Name = 'serverapp'";
                     */
                    // public static bool ExportDataTableToString(System.Data.DataTable DT, out string TableString, bool ErrorShow)
                    //if (Var.conSys.Getvalue8(SQL, out DT))
                    //{                                                      
                        //if (sys.ExportDataTableToFile(DT, "ConnectionList", "temp.txt", false))
                        // data_OUT = File.ReadAllText("temp.txt");
                           
                           
                    //}                 
//====================================================================== 
		/*private void SetText(string text)
        {
            //InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
            //If these threads are different, it returns true.
            if (tbLogServer.InvokeRequired)
            {    
                var d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {        
                tbLogServer.AppendText(text);     // + Var.CR
            }
        }*/
		
        /*private void SetText(string text)
        {
            //InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
            //If these threads are different, it returns true.
            if (tbLogServer.InvokeRequired)
            {    
                var d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {        
                tbLogServer.AppendText(text + Var.CR);     
            }
        } */                
//====================================================================== 
            /*CheckColumn1 = new DataGridViewCheckBoxColumn();
        	CheckColumn1.HeaderText = "Check user"; //ColumnName.OutOfOffice.ToString();
        	CheckColumn1.Name = "Check"; //ColumnName.OutOfOffice.ToString();
        	CheckColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        	CheckColumn1.FlatStyle  = FlatStyle.Standard;
        	CheckColumn1.ThreeState = true;
        	
        	CheckColumn2 = new DataGridViewCheckBoxColumn();
        	CheckColumn2.HeaderText = "Check user"; //ColumnName.OutOfOffice.ToString();
        	CheckColumn2.Name = "Check"; //ColumnName.OutOfOffice.ToString();
        	CheckColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        	CheckColumn2.FlatStyle  = FlatStyle.Standard;
        	CheckColumn2.ThreeState = true;
        	//checkboxcolumn.CellTemplate = new DataGridViewCheckBoxCell();
        	//checkboxcolumn.CellTemplate.Style.BackColor = Color.Beige;
			*/                
//====================================================================== 
//var myIcon = new System.Drawing.Icon(@"server.ico");             
            //notifyIcon1.Icon = myIcon;
            //this.Icon = myIcon;                
//======================================================================
//101;ConnectionName;LocalIP;LocalHost;ComputerName;ComputerUserName
                //string StrIN = "101;" + Var.LocalIP + ";" + Var.LocalHost + ";" + Var.ComputerName + ";" + Var.ComputerUserName;
                       
                //var client = new TcpClient(ServerApp, sys.ServerAppPort);  
                //NetworkStream stream = client.GetStream();
                
                //Отправляем сообщение нашему серверу. 
                //Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                //stream.Write(data, 0, data.Length);
                  
                //textBox1.AppendText("Sent: {0}" + message);
                 //sys.SM(message);
                 
                //Получаем ответ от сервера.
                //Читаем первый пакет ответа сервера. 
                //Можно читать всё сообщение. Для этого надо организовать чтение в цикле как на сервере.
                //data = new Byte[256];
                //string responseData = String.Empty;
                //Int32 bytes = stream.Read(data, 0, data.Length);
                //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //Console.WriteLine("Received: {0}", responseData);
                
                
 /*
 *   var client = new TcpClient(ServerName, sys.ServerAppPort);
                NetworkStream stream = client.GetStream();
                //Отправляем сообщение нашему серверу. 
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(data_IN);
                stream.Write(data, 0, data.Length);          
                                              
                //return true;
                //Читаем первый пакет ответа сервера. 
                //Можно читать всё сообщение. Для этого надо организовать чтение в цикле как на сервере.
                var bytes = new Byte[256];
                //string responseData = String.Empty;
                Int32 b = stream.Read(bytes, 0, data.Length);
                string StrOUT = System.Text.Encoding.ASCII.GetString(bytes, 0);
                //sys.SM("sfdgdfg");
                 
                //return false;
                //int i;               
                //var bytes = new Byte[256];
                //Принимаем данные от клиента в цикле пока не дойдём до конца.
                //while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                //{
                    //Преобразуем данные в ASCII string.
                //    data_OUT += System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                //}   */               
                
        //Обмен сообщением с сервером приложений. Для получения настроек подключения а базе данных и  для теста сервера приложений.  
        /*public static bool ServerAppMessage(string ServerName, string data_IN, out string data_OUT, string ErrorMes, bool ErrorShow)
        { 
           //Буфер для принимаемых данных.
            var bytes = new Byte[256];
            string data = null;       
            
            //var client = client_obj as TcpClient;
            var client = new TcpClient(ServerName, sys.ServerAppPort);
            
            //Получаем информацию от клиента
            NetworkStream stream = client.GetStream();
            int i;
            //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                //Преобразуем данные в ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                byte[] msg;
                if (data == "close")
                {
                    msg = System.Text.Encoding.ASCII.GetBytes("ClientCloseSuccessfully");              
                    stream.Write(msg, 0, msg.Length);
                    Environment.Exit(0);
                    return true;
                }
                MessageBox.Show(data);                                                              
                //Отправляем ответ обратно серверу приложений.
                msg = System.Text.Encoding.ASCII.GetBytes("MessageBoxSuccessfully");              
                stream.Write(msg, 0, msg.Length); 
                return true;
            }
            //Закрываем соединение.
            client.Close();
            return true;
    }   */                
//======================================================================  
     //Для передачи в асинхронный метод обновления списока клиентов.
    //public class ClientParam
    //{
    //      public string LocalIP;
    //      public string LocalHost;
    //      public string ComputerName;
    //      public string ComputerUserName;
    //}
//====================================================================== 
   //Обработка запроса от клиента HTTP.   //Работает
      /*  private void ServerProcessHTTP(object o)    //string[] prefixes
        {                                     
            // Note: The GetContext method blocks while waiting for a request. 
            //HttpListenerContext context = listener.GetContext();
            var context = o as HttpListenerContext;
            HttpListenerRequest request = context.Request;                                                 
            HttpListenerResponse response = context.Response; 
            string Cntx = context.Request.ContentType;
            
            //string encstr1 = "The encoding method used is: " + context.Request.ContentEncoding;
            //Action action = () => tbLogQuery.AppendText(sys.GetDateTimeNow() + ": " + encstr1 + Var.CR);
            //tbLogServer.Invoke(action);
                    
            //SaveFile(context.Request.ContentEncoding, GetBoundary(context.Request.ContentType), context.Request.InputStream);
            string resultstr = SaveString(context.Request.ContentEncoding, GetBoundary(context.Request.ContentType), context.Request.InputStream);
            
            Action action = () => tbLogQuery.AppendText(sys.GetDateTimeNow() + ": " + resultstr + Var.CR);
            tbLogServer.Invoke(action);
            
            // Construct a response.
            //string responseString = "<HTML><BODY>Hello world!</BODY></HTML>";
            //string responseString = System.IO.File.ReadAllText(@"System.Data.SQLite.dll", Encoding.Default);
            //FileStream fs = null;
            //fs = new FileStream(@"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\test2.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);  //открываем файл
            //var fileBuffer = new byte[fs.Length];
            //fs.Read(fileBuffer, 0, (int)fs.Length);        //читаем в бинарный буфер
            //fs.Close();     
             
            string responseString = "asd123нгшщзхъzxc";//Convert.ToBase64String(fileBuffer);
            
               
            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            byte[] buffer = System.Text.Encoding.Default.GetBytes(responseString);
            //byte[] buffer = System.Text.Encoding.Unicode.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer,0,buffer.Length);
            // You must close the output stream.
            output.Close();
            //listener.Stop();
        }*/
            //Обработка запроса от клиента HTTP.   //Работает
        /*private void ServerProcessHTTP(object o)    //string[] prefixes
        {  
            //HttpListener listener = new HttpListener();
            //listener.Prefixes.Add("http://localhost:8080/ListenerTest/");
            //listener.Start();
      
        
            //HttpListenerContext context = listener.GetContext();
        
            //HttpListenerContext context = listener.GetContext();
            var context = o as HttpListenerContext;
            HttpListenerRequest request = context.Request;
             
            
            
            
            SaveFile(context.Request.ContentEncoding, GetBoundary(context.Request.ContentType), context.Request.InputStream);
        
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/html";
            using (var writer = new StreamWriter(context.Response.OutputStream, Encoding.UTF8))
                writer.WriteLine("File Uploaded");
        
            context.Response.Close();
        
            //listener.Stop();
       }*/ 
        
//======================================================================  
//if (!sys.ExportDataTableToString(DT, out DataOUT, out ErrorMes, false)) 
                        //{
                        //    DataOUT = ErrorMes;
                        //    return false;
                        //}
//UserHostName - "10.77.70.13:9595", UserHostAddress - "10.77.70.13:9595"   RawUrl- "/Upload/File"
            //System.Threading.Thread.Sleep(120000);
            //string ResponseStr = "asd123нгшщзхъzxc";//Convert.ToBase64String(fileBuffer);  
  //SaveFile(context.Request.ContentEncoding, GetBoundary(context.Request.ContentType), context.Request.InputStream);                
//======================================================================  
        //Разделить строку параметров запроса на части.
        /*private void GetParams(string Params, out string par1, 
                                              out string par2, 
                                              out string par3, 
                                              out string par4, 
                                              out string par5,
                                              out string par6)                              
        {                                             
            par1 = "";
            par2 = "";
            par3 = "";
            par4 = "";
            par5 = "";
            par6 = "";            
            string[] fields = Params.Split(';');
            if (fields.Length > -1) par1 = fields[0];            
            if (fields.Length > 0)  par2 = fields[1];
            if (fields.Length > 1)  par3 = fields[2];
            if (fields.Length > 2)  par4 = fields[3];
            if (fields.Length > 3)  par5 = fields[4];
            if (fields.Length > 4)  par5 = fields[5];
            
        } */
        
//======================================================================  
 
        // This example requires the System and System.Net namespaces.
                   //сязалась
        /*public static void SimpleListenerExample()    //string[] prefixes
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine ("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // URI prefixes are required,
            // for example "http://contoso.com:8080/index/".
            //if (prefixes == null || prefixes.Length == 0)
            //  throw new ArgumentException("prefixes");
        
            // Create a listener.
            listener = new HttpListener();
            // Add the prefixes.
            //foreach (string s in prefixes)
            //{
                //listener.Prefixes.Add(@"http://localhost/"); //Работает
                listener.Prefixes.Add(@"http://localhost:9595/");
            //}//
            listener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request. 
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString = "<HTML><BODY>tyutyuварпвапвпщщ Hello world!</BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer,0,buffer.Length);
            // You must close the output stream.
            output.Close();
            //listener.Stop();
        }*/
        
//======================================================================  
    
        //=========================================================
        // другой пример        
        /*void aaa()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:9595/");
            listener.Start();
        
            HttpListenerContext context = listener.GetContext();
            string Cntx = context.Request.ContentType;
            SaveFile(context.Request.ContentEncoding, GetBoundary(context.Request.ContentType), context.Request.InputStream);
        
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/html";
            using (StreamWriter writer = new StreamWriter(context.Response.OutputStream, Encoding.UTF8))
                writer.WriteLine("File Uploaded");
        
            context.Response.Close();
        
            listener.Stop();
        } */
//======================================================================  
/*    //Работает
 * //Получить текст контекста сообщения от клиента.
        private static string SaveString(Encoding enc, string boundary, Stream input)
        { 
            Byte[] boundaryBytes = System.Text.Encoding.UTF8.GetBytes(boundary); //enc.GetBytes(boundary);           
            Int32 boundaryLen = boundaryBytes.Length;
             
            MemoryStream output = new MemoryStream();
            Byte[] buffer = new Byte[1024];
            Int32 len = input.Read(buffer, 0, 1024);
            Int32 startPos = -1;
    
            // Find start boundary
            while (true)
            {
                if (len == 0)
                {
                    //throw new Exception("Start Boundaray Not Found");
                    return "";
                }
    
                startPos = IndexOf(buffer, len, boundaryBytes);
                if (startPos >= 0)
                {
                    break;
                }
                else
                {
                    Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                    len = input.Read(buffer, boundaryLen, 1024 - boundaryLen);
                }
            }
    
            //Skip four lines (Boundary, Content-Disposition, Content-Type, and a blank)
            for (Int32 i = 0; i < 4; i++)
            {
                while (true)
                {
                    if (len == 0)
                    {
                        
                        throw new Exception("Preamble not Found.");
                    }
    
                    //startPos = Array.IndexOf(buffer, enc.GetBytes("\n")[0], startPos);
                    startPos = Array.IndexOf(buffer, System.Text.Encoding.Default.GetBytes("\n")[0], startPos);
                    
                    
                    if (startPos >= 0)
                    {
                        startPos++;
                        break;
                    }
                    else
                    {
                        len = input.Read(buffer, 0, 1024);
                    }
                }
            }
    
            Array.Copy(buffer, startPos, buffer, 0, len - startPos);
            len = len - startPos;
    
            while (true)
            {
                Int32 endPos = IndexOf(buffer, len, boundaryBytes);
                if (endPos >= 0)
                {
                    if (endPos > 0) output.Write(buffer, 0, endPos-2);
                    break;
                }
                else if (len <= boundaryLen)
                {                         
                    throw new Exception("End Boundaray Not Found");
                    
                }
                else
                {
                    output.Write(buffer, 0, len - boundaryLen);
                    Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                    len = input.Read(buffer, boundaryLen, 1024 - boundaryLen) + boundaryLen;
                }
            }
               
            
            //string result = enc.GetString(output.ToArray());
            //string result = Encoding.ASCII.GetString(output.ToArray());
            string result = Encoding.UTF8.GetString(output.ToArray());
            //string result = enc.GetString(output.ToArray());
            return result;
            
        }
 * /
//======================================================================  
/* //Работает
 //Сохранить текст контекста сообщения от клиента в файл.
        private static void SaveFile(Encoding enc, string boundary, Stream input)
        {
            Byte[] boundaryBytes = enc.GetBytes(boundary);
            Int32 boundaryLen = boundaryBytes.Length;
        
            using (FileStream output = new FileStream(@"E:\2.txt", FileMode.Create, FileAccess.Write))
            {
                Byte[] buffer = new Byte[1024];
                Int32 len = input.Read(buffer, 0, 1024);
                Int32 startPos = -1;
        
                //Find start boundary
                while (true)
                {
                    if (len == 0)
                    {
                        throw new Exception("Start Boundaray Not Found");
                    }
        
                    startPos = IndexOf(buffer, len, boundaryBytes);
                    if (startPos >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                        len = input.Read(buffer, boundaryLen, 1024 - boundaryLen);
                    }
                }
        
                //Skip four lines (Boundary, Content-Disposition, Content-Type, and a blank)
                for (Int32 i = 0; i < 4; i++)
                {
                    while (true)
                    {
                        if (len == 0)
                        {
                            throw new Exception("Preamble not Found.");
                        }
        
                        startPos = Array.IndexOf(buffer, enc.GetBytes("\n")[0], startPos);
                        if (startPos >= 0)
                        {
                            startPos++;
                            break;
                        }
                        else
                        {
                            len = input.Read(buffer, 0, 1024);
                        }
                    }
                }
        
                Array.Copy(buffer, startPos, buffer, 0, len - startPos);
                len = len - startPos;
        
                while (true)
                {
                    Int32 endPos = IndexOf(buffer, len, boundaryBytes);
                    if (endPos >= 0)
                    {
                        if (endPos > 0) output.Write(buffer, 0, endPos-2);
                        break;
                    }
                    else if (len <= boundaryLen)
                    {
                        throw new Exception("End Boundaray Not Found");
                    }
                    else
                    {
                        output.Write(buffer, 0, len - boundaryLen);
                        Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                        len = input.Read(buffer, boundaryLen, 1024 - boundaryLen) + boundaryLen;
                    }
                }
            }
        }
 * /
//======================================================================  
//delegate void SetTextCallback(string text);
//======================================================================  
//var threadserverhttp = new Thread(ServerHTTP);
            // threadserverhttp.Start();   
//======================================================================  
 /* Это реализация клиента - работает.
     public void Upload()
        {
            
            string filePath = @"E:\forclient.txt";
            //string filePath = @"E:\1.jpg";
            string uri = @"http://10.77.70.13:9595/Upload/File";
            //string contentType = "image/jpeg";
            string contentType =  "text/html";
            
            
            
            
            string boundary         = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            //byte[] boundaryBytes    = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] boundaryBytes     = System.Text.Encoding.Default.GetBytes("\r\n--" + boundary + "\r\n");
            
            
            string formdataTemplate = "Content-Disposition: form-data; name=file; filename=\"{0}\";\r\nContent-Type: {1}\r\n\r\n";
            string formitem         = string.Format(formdataTemplate, Path.GetFileName(filePath), contentType);
            //byte[] formBytes        = Encoding.UTF8.GetBytes(formitem);
            //byte[] formBytes        = System.Text.Encoding.Unicode.GetBytes(formitem);
            byte[] formBytes          = System.Text.Encoding.Default.GetBytes(formitem);
            
            
            HttpWebRequest request  = (HttpWebRequest) WebRequest.Create(uri);
             
            request.KeepAlive       = true;
            request.Method          = "POST";
            request.ContentType     = "multipart/form-data; boundary=" + boundary;
            request.SendChunked     = true;
            request.Timeout         = 300000; //5 минут.
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                requestStream.Write(formBytes, 0, formBytes.Length);
    
                byte[] buffer = new byte[1024*4];
                int bytesLeft;
    
                while ((bytesLeft = fileStream.Read(buffer, 0, buffer.Length)) > 0) requestStream.Write(buffer, 0, bytesLeft);
    
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            }
    
            //Ответ
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();        
                byte[] buf = new byte[8192];
                StringBuilder sb = new StringBuilder();
                int count = 0;
                do
                {
                    count = resStream.Read(buf, 0, buf.Length);
                    if (count != 0)
                    {                
                        sb.Append(Encoding.Default.GetString(buf, 0, count));
                    }
                }
                while (count > 0);
                textBoxResponse.Text =  sb.ToString();
                
            }
    
            Console.WriteLine ("Success");    
        }
  * /
//======================================================================  
        
        //Обмен сообщением с сервером приложений. Для получения настроек подключения а базе данных и для теста сервера приложений.  
        /*public static bool ServerAppMessage(string ServerName, string data_IN, out string data_OUT, string ErrorMes, bool ErrorShow)
        {  
            data_OUT = "";
            try
            {               
                var client = new TcpClient(ServerName, sys.ServerAppPort);  
                NetworkStream stream = client.GetStream();
                
                //Отправляем сообщение нашему серверу. 
                Byte[] data = System.Text.Encoding.Default.GetBytes(data_IN); //  System.Text.Encoding.ASCII.GetBytes(data_IN);
                stream.Write(data, 0, data.Length);                                 
                //sys.SM(message);                
                //Получаем ответ от сервера.
                //Читаем первый пакет ответа сервера. 
                //Можно читать всё сообщение. Для этого надо организовать чтение в цикле как на сервере.
                
                data = new Byte[214748364]; //256 //214748364
                data_OUT = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                data_OUT = System.Text.Encoding.Default.GetString(data, 0, bytes); //   System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                     
                //sys.SM(data_OUT);                  
                stream.Close();
                client.Close();
                return true;
            } catch (Exception ex)
            {
                ErrorMes = "Ошибка обмена сообщением с сервером приложений: " + ex.Message;
                //if (ErrorShow) 
                sys.SM(ErrorMes);
                return false;               
            }          
        }*/
//======================================================================  
//string uri = @"http://10.77.70.13:9595/101;99FE5A67-CC86-4409-8B1F-9296A985533A;Report.txt";      
//======================================================================  
    //Предок чтобы не обявлять в и в Дизайнере и в Клиенте эти глобальные переменные.
	/*public class FormCustom: Form
	{	
		public string TextQuery;		
		
		//Получить подстроку, ограниченную строками --begin и --end.
		public string GetSQL(string ParamSQL)
		{
			int p1 = TextQuery.IndexOf("--begin " + ParamSQL);
			int p2 = TextQuery.IndexOf("--end " + ParamSQL);
			//return ("p1=" + p1.ToString() + "  p2=" + p2.ToString());
			if ((p1 == -1) || (p2 == -1))  return "";
			return TextQuery.Substring(p1, p2 + ParamSQL.Length + 6 - p1);
		}
	}*/
            	
	//Для поиска прикладных модулей
	/*public class AssemblyApp
	{
	    string   Name;     //Имя модуля (Формы или DLL)
	    Assembly Asm;      //Сборка
	   
	    //Конструктор класса.
	    public AssemblyApp(string Name, Assembly Asm)
        {                                                                                                                               
            this.Name     = Name;
            this.Asm      = Asm;         
	    }
	}*/
	            	
//======================================================================  
        //Функции получения данных для MSSQL, Postgre, SQLite. Результат в DataGridView.
        //Для применения в асинхронных методах async. Функция void.        
        //public void SelectAsyncGV(string SQL, DataGridView Grid)
        //{           
        //    string ErrorText = "";
        //    const bool ErrorShow = true;
        //    SelectGV(SQL, Grid, ref ErrorText, ErrorShow);
        //} 
//======================================================================  
 //string ConnectionGUID = sys.GetNewConnectionGUID();
            //GUID = sys.ServerAppHTTPMessage("101", string GUID, string CommandText, string FileName, int WaitTimeout = 0)
            //string StrOUT = "aaa";
            //string ErrorMes = "";
            //bool ErrorShow = true;
            //ServerAppMessage("localhost", tbTest.Text, out StrOUT, ErrorMes, ErrorShow);
            //sys.SM("StrOUT=" + StrOUT);
//======================================================================  
         
         /*
          *  const string data_OUT = "ssdфывшщNNN";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data_OUT);
            
            sys.SM(System.Text.Encoding.ASCII.CodePage.ToString());
            string data_OUT2 = System.Text.Encoding.ASCII.GetString(msg, 0, msg.Length);
            sys.SM(data_OUT2);
            
            
            
            
            byte[] str1 = Encoding.Default.GetBytes("ssdфывшщNNN");
            string str2 = Encoding.Default.GetString(str1);
            sys.SM(str2);*/
//======================================================================  
//======================================================================  
//======================================================================                  
/*                
1    //Начало!
2    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
3    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
4    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
5    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
6    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
7    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
8    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
9    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
10    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
11    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
12    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
13    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
14    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
15    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
16    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
17    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
18    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
19    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
20    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
21    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
22    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
23    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
24    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
25    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
26    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
27    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
28    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
29    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
30    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
31    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
32    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
33    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
34    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
35    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
36    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
37    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
38    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
39    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
40    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
41    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
42    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
43    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
44    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
45    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
46    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
47    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
48    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
49    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
50    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
51    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
52    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
53    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
54    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
55    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
56    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
57    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
58    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
59    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
60    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
61    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
62    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
63    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
64    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
65    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
66    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
67    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
68    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
69    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
70    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
71    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
72    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
73    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
74    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
75    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
76    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
77    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
78    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
79    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
80    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
81    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
82    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
83    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
84    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
85    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
86    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
87    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
88    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
89    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
90    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
91    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
92    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
93    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
94    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
95    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
96    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
97    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
98    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
99    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
100    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
101    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
102    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
103    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
104    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
105    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
106    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
107    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
108    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
109    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
110    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
111    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
112    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
113    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
114    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
115    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
116    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
117    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
118    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
119    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
120    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
121    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
122    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
123    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
124    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
125    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
126    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
127    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
128    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
129    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
130    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
131    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
132    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
133    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
134    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
135    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
136    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
137    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
138    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
139    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
140    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
141    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
142    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
143    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
144    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
145    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
146    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
147    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
148    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
149    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
150    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
151    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
152    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
153    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
154    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
155    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
156    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
157    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
158    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
159    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
160    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
161    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
162    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
163    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
164    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
165    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
166    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
167    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
168    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
169    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
170    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
171    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
172    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
173    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
174    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
175    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
176    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
177    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
178    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
179    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
180    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
181    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
182    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
183    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
184    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
185    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
186    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
187    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
188    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
189    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
190    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
191    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
192    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
193    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
194    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
195    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца.
196    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
197    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
198    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
199    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
200    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца
201    //Принимаем данные от сервера приложений в цикле пока не дойдём до конца 
202    //Конец!
*/