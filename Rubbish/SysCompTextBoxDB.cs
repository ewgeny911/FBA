/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 27.02.2018
 * Время: 16:28
 */
 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FBA
{        
    public partial class TextBoxDB : UserControl
    {
        public TextBoxDB()
        {       
            InitializeComponent();
            //btnAdd.Click += this.ValueAddMethod;
            textBox1.TextChanged += OnTextChanged;
            //Dock = DockStyle.Fill;
            
        }
              
        [DisplayName("BackColor"), Description("BackColor"), Category("FBA")]  
        public override Color BackColor
        {
            get { return textBox1.BackColor;  }
            set { textBox1.BackColor = value; }
        }
        
        [DisplayName("DockStyle"), Description("DockStyle"), Category("FBA")]  
        public DockStyle DockStyle
        {
            get { return this.Dock;  }
            set { this.Dock = value; }
        }
        
        [DisplayName("Text"), Description("Text"), Category("FBA")]  
        public override string Text
        {
            get { return textBox1.Text;  }
            set { textBox1.Text = value; }
        }             
        
        [DisplayName("BorderStyleTextBox"), Description("BorderStyleTextBox"), Category("FBA")]  
        public System.Windows.Forms.BorderStyle BorderStyleTextBox
        {
            get { return textBox1.BorderStyle;  }
            set { textBox1.BorderStyle = value; }
        }
        
        ///Cобытие до выбора.
        [DisplayName("BeforeValueAdd"), Description("BeforeValueAdd"), Category("FBA")]       
        public event EventHandler BeforeValueAdd;           
        [DisplayName("BeforeValueAdd"), Description("BeforeValueAdd"), Category("FBA")]           
        protected virtual void OnBeforeValueAdd(EventArgs e)
        {            
            if (this.BeforeValueAdd != null) this.BeforeValueAdd(this, e);             
        }       
        
        
        ///Cобытие после выбора.
        [DisplayName("AfterValueAdd"), Description("AfterValueAdd"), Category("FBA")]       
        public event EventHandler AfterValueAdd;                
        [DisplayName("AfterValueAdd"), Description("AfterValueAdd"), Category("FBA")]           
        protected virtual void OnAfterValueAdd(EventArgs e)
        {            
            if (this.AfterValueAdd != null) this.AfterValueAdd(this, e);        
        }                    
        
        //Cобытие изменения текста.
        [DisplayName("TextChanged"), Description("TextChanged"), Category("FBA")]       
        public event EventHandler TextChanged1;      
        [DisplayName("TextChanged"), Description("TextChanged"), Category("FBA")]           
        protected virtual void OnTextChanged(object sender, EventArgs e)
        {            
            if (this.TextChanged1 != null) this.TextChanged1(this, e);        
        }
        
                      
        private void ValueAddMethod(object sender, EventArgs e)
        {           
            this.OnBeforeValueAdd(EventArgs.Empty);
            ShowFormAdd();
            this.OnAfterValueAdd(EventArgs.Empty);
        }
          
        public void ShowFormAdd()
        {
            sys.SM("Add");
        }
        
        
        //Cобытие очистки.
        //[DisplayName("ValueDel"), Description("ValueDel"), Category("FBA")]       
        //public event EventHandler ValueDel;
        
        
        //Cобытие очистки.
        //[DisplayName("ValueProp"), Description("ValueProp"), Category("FBA")]       
        //public event EventHandler ValueProp;
        
        
        //((TextBox)cb2).BorderStyle = System.Windows.Forms.BorderStyle.None;
        
    }
}
