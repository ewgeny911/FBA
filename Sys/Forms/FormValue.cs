/*
 * Created by SharpDevelop.
 * User: Evgeniy.Travin
 * Date: 02.09.2019
 * Time: 9:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FBA
{	
	/// <summary>
	/// Description of FormValue.
	/// </summary>
	public partial class FormValue : FBA.FormFBA
	{		
		/// <summary>
		/// Количество создаваемых компонентов.
		/// </summary>
		private int countComponent = 0;	

		/// <summary>
		/// Массив компонентов TextBox на форме FormValue. Для доступа извне.
		/// </summary>
		public FBA.TextBoxFBA[]  textBoxArray;
		
		/// <summary>
		/// Массив компонентов ComboBox на форме FormValue. Для доступа извне.
		/// </summary>
		public FBA.ComboBoxFBA[] comboBoxArray;
		
		/// <summary>
		/// Массив компонентов ComboBox на форме FormValue. Для доступа извне.
		/// </summary>
		public FBA.CheckBoxFBA[] checkBoxArray;
		
		private ValueParam[] arrvp;		
		private bool AnchorBottom = false;			
		private const int defaultRightMargin     = 40;
				
		/// <summary>
		/// Если нужно несколько разных компонентов
		/// Вызывать так:
		/// ValueParam[] arrvp = new ValueParam[2];
		/// arrvp[0].type = FBA.TextBoxFBA; 
		/// arrvp[0].value = "Номер договора"; 	
		/// arrvp[1].type = FBA.TextBoxFBA; 
		/// arrvp[1].value = "Серия договора"; 
		/// var frm = new FormValue("Введите номер и серию договора", arrvp);
		/// if (frm.ShowDialog() != DialogResult.OK) return false;
        /// valueText1 = frm.GetValue(0);
        /// valueText2 = frm.GetValue(1);
		/// </summary>
		/// <param name="captionForm">Шапка формы</param>
		/// <param name="arrvp">Массив описателей параметра</param>
		public FormValue(string captionForm, ValueParam[] arrvp)
		{									
			InitializeComponent();		
			if (this.Owner != null) this.Icon = this.Owner.Icon;
			if (captionForm    != null) Text         = captionForm;  			
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.DialogResult     = System.Windows.Forms.DialogResult.OK;   	
			this.arrvp = arrvp;
            
			for (int i = 0; i < arrvp.Length; i++)
            {
				int w = arrvp[i].width;
				if (w > 0) this.Width = w + defaultRightMargin;
            }
			
			checkBoxArray = new FBA.CheckBoxFBA[arrvp.Length];
			textBoxArray  = new FBA.TextBoxFBA[arrvp.Length];
            comboBoxArray = new FBA.ComboBoxFBA[arrvp.Length];
			for (int i = 0; i < arrvp.Length; i++)
            {
				CreateOneText(i);
            }
        }   
			
		/// <summary>
		/// Получение значения с формы.
		/// </summary>
		/// <param name="NumberText"></param>
		/// <returns></returns>
		public string GetValue(int NumberText)		
		{
			if (checkBoxArray[NumberText] != null) return checkBoxArray[NumberText].Text;
			if (textBoxArray[NumberText]  != null) return textBoxArray[NumberText].Text;
			if (comboBoxArray[NumberText] != null) return comboBoxArray[NumberText].Text;					
			return null;
		}
		
		/// <summary>
		/// Создание метки Label и текстового поля TextBox или ComboBox.
		/// </summary>
		private void CreateOneText(int n)
		{					
			const int leftComponent          = 13;
			int widthComponent               = Width - defaultRightMargin;
			const int firstTopLabel          = 11;
		    const int firstTopComboBox       = 32;
		    const int spaceAfterAllComponent = 120;
		    const int defaultHeightComboBox  = 25;
		    const int defaultHeightLabel     = 17;
		    const int defaultHeightCheckBox  = 20;
		    const int spaceBetweenComponent  = 59;
		    
			int addHeight = 0;
			int countSetHeight = 0;
			for (int i = 0; i < n; i++) 
			{
				addHeight = addHeight + arrvp[i].height;
				if (arrvp[i].height > 0) countSetHeight++;
			}
			if (addHeight > 0) addHeight = addHeight - (countSetHeight * defaultHeightComboBox);					
			
			//Для Label	
			int yLabel     = ((countComponent) * spaceBetweenComponent) + firstTopLabel    + addHeight; //11 - начальная позиция по вертикали.  			
					 
			//Для ComboBox или TextBox		
			int yComponent = ((countComponent) * spaceBetweenComponent) + firstTopComboBox + addHeight; //32 - начальная позиция по вертикали.
			
			
			int heightComponent = defaultHeightComboBox;										
			if (arrvp[n].height != 0) heightComponent = arrvp[n].height;

			
			int formheight = yComponent + arrvp[n].height + spaceAfterAllComponent;					
			if (formheight > Var.scrteenWorkingHeight) formheight = Var.scrteenWorkingHeight;
			
			this.Height = formheight;		
			
			//CheckBox
			if (arrvp[n].componentType == ComponentType.CheckBox) 
			{
				CreateCheckBox(n,  leftComponent, yLabel,  widthComponent, defaultHeightCheckBox);
			}
			
			//TextBox			
			if (arrvp[n].componentType == ComponentType.TextBox) 
			{
				CreateLabel(n,   leftComponent, yLabel,     widthComponent, defaultHeightLabel);
				CreateTextBox(n, leftComponent, yComponent, widthComponent, heightComponent);
			}
			
			//ComboBox
			if (arrvp[n].componentType == ComponentType.ComboBox)
			{
			    CreateLabel(n,  leftComponent, yLabel,  widthComponent, defaultHeightLabel);
				ComboBoxFBA fb = CreateComboBox(n, leftComponent, yComponent, widthComponent, heightComponent);
			   
			    //Установка DataSource
			    if (!String.IsNullOrEmpty(arrvp[n].msql)) fb.SetDataSourceMSQL(arrvp[n].msql);
			  	   else if (!String.IsNullOrEmpty(arrvp[n].sql)) fb.SetDataSourceMSQL(arrvp[n].sql);
			}

			if (arrvp[n].componentType != ComponentType.CheckBox) countComponent++;			
		}
				
		/// <summary>
		/// Создание одного Label над текствоым полем.
		/// </summary>
		/// <param name="indexParam">Номер Label</param>
		/// <param name="xLabel">Координата X для Label</param>
		/// <param name="yLabel">Координата Y для Label</param>
		/// <param name="widthLabel">Ширина Label</param>
		/// <param name="heightLabel">Высота Label</param>		
		private void CreateLabel(int indexParam,
			                     int xLabel,
		                         int yLabel, 
		                         int widthLabel, 
		                         int heightLabel)
		{			            			
			var lbCap1 = new FBA.LabelFBA();			
			lbCap1.AutoSize = true;
			lbCap1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			lbCap1.Location = new System.Drawing.Point(xLabel, yLabel);
			lbCap1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lbCap1.Name = "lbCap" + indexParam.ToString();
			lbCap1.Size = new System.Drawing.Size(widthLabel, heightLabel);
			lbCap1.StarColor = System.Drawing.Color.Crimson;
			lbCap1.StarFont = new System.Drawing.Font("Arial", 20F);
			lbCap1.StarOffsetX = 2;
			lbCap1.StarOffsetY = 0;
			lbCap1.StarShow = false;
			lbCap1.StarText = "*";		
			lbCap1.Text = arrvp[indexParam].captionValue;
			
			if (AnchorBottom)
			{
			    lbCap1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Bottom)
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			} else
			{													
				lbCap1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));			
			}					
			Controls.Add(lbCap1);
		}				
		
		
		/// <summary>
		/// Создание одного CheckBox.
		/// </summary>
		/// <param name="indexParam">Номер CheckBox</param>
		/// <param name="xCheckBox">Координата X для CheckBox</param>
		/// <param name="yCheckBox">Координата Y для CheckBox</param>
		/// <param name="widthCheckBox">Ширина CheckBox</param>
		/// <param name="heightCheckBox">Высота CheckBox</param>		
		private CheckBox CreateCheckBox(int indexParam,
			                     int xCheckBox,
		                         int yCheckBox, 
		                         int widthCheckBox, 
		                         int heightCheckBox)
		{			            			
			
			checkBoxArray[indexParam] = new FBA.CheckBoxFBA();	
			checkBoxArray[indexParam].Checked = true;
			checkBoxArray[indexParam].CheckState = System.Windows.Forms.CheckState.Checked;
			checkBoxArray[indexParam].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			checkBoxArray[indexParam].Location = new System.Drawing.Point(xCheckBox, yCheckBox);
			checkBoxArray[indexParam].Name = "checkbox" + indexParam.ToString();	
			checkBoxArray[indexParam].Size = new System.Drawing.Size(widthCheckBox, heightCheckBox);
			checkBoxArray[indexParam].TabIndex = 5;
			checkBoxArray[indexParam].Text = arrvp[indexParam].value;
			checkBoxArray[indexParam].UseVisualStyleBackColor = true;								
			Controls.Add(checkBoxArray[indexParam]);
			checkBoxArray[indexParam].Enabled = !arrvp[indexParam].notEnabled;
		    return checkBoxArray[indexParam];	
		}		
				
		/// <summary>
		/// Создание одного текстового поля TextBox.
		/// </summary>	
		/// <param name="indexParam">Номер TextBox</param> 
		/// <param name="xTextBox">Координата X</param>
		/// <param name="yTextBox">Координата Y</param>
		/// <param name="widthTextBox">Ширина создаваемого компонента</param>
		/// <param name="heightTextBox">Выстота создаваемого компонента</param>	
		private FBA.TextBoxFBA CreateTextBox(int indexParam,
			                       int xTextBox,
		                           int yTextBox, 
		                           int widthTextBox, 
		                           int heightTextBox		                      
		                           )
		{						
		    textBoxArray[indexParam] = new FBA.TextBoxFBA();
			textBoxArray[indexParam].Name = "tb" + indexParam.ToString();	
			textBoxArray[indexParam].Multiline = (arrvp[indexParam].height != 0);		
			textBoxArray[indexParam].Size = new System.Drawing.Size(widthTextBox, heightTextBox);	
			textBoxArray[indexParam].Location = new System.Drawing.Point(xTextBox, yTextBox);					
			textBoxArray[indexParam].ReadOnly = arrvp[indexParam].readOnly;
			textBoxArray[indexParam].WordWrap = arrvp[indexParam].wordwrap;
			textBoxArray[indexParam].Enabled  = !arrvp[indexParam].notEnabled;
						
			if (AnchorBottom)
			{
			    textBoxArray[indexParam].Anchor = ((System.Windows.Forms.AnchorStyles)					                         
				 	 (System.Windows.Forms.AnchorStyles.Left | 
				      System.Windows.Forms.AnchorStyles.Right| 
				      System.Windows.Forms.AnchorStyles.Bottom));					
			} 
			else
			{
				if (textBoxArray[indexParam].Multiline)
				{
				    textBoxArray[indexParam].Anchor = 
				    	((System.Windows.Forms.AnchorStyles)					                         
				 	 (System.Windows.Forms.AnchorStyles.Top  | 
				      System.Windows.Forms.AnchorStyles.Left | 
				      System.Windows.Forms.AnchorStyles.Right 
				      //System.Windows.Forms.AnchorStyles.Bottom
				     ));
				    //AnchorBottom = true;
				} else
				{
					textBoxArray[indexParam].Anchor = ((System.Windows.Forms.AnchorStyles)					                         
				 	 (System.Windows.Forms.AnchorStyles.Top  | 
				      System.Windows.Forms.AnchorStyles.Left | 
				      System.Windows.Forms.AnchorStyles.Right));
				}
			}
			
			textBoxArray[indexParam].Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
			textBoxArray[indexParam].BackColor = System.Drawing.SystemColors.Info;
			textBoxArray[indexParam].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));																				
			textBoxArray[indexParam].SaveParam = false;		
			textBoxArray[indexParam].SaveValueHistory = false;	
			textBoxArray[indexParam].ScrollBars = arrvp[indexParam].scrolls;										
			textBoxArray[indexParam].DefaultTextGray      = arrvp[indexParam].defaultTextGray;
			textBoxArray[indexParam].DefaultTextGrayColor = arrvp[indexParam].defaultTextGrayColor;
											
			if (arrvp[indexParam].value != null)  textBoxArray[indexParam].Text = arrvp[indexParam].value;
			Controls.Add(textBoxArray[indexParam]);	
			return	textBoxArray[indexParam];
		}
		
		/// <summary>
		/// Создание одного текстового поля ComboBox.
		/// </summary>
		/// <param name="indexParam">Номер ComboBox</param>  
		/// <param name="xComboBox">Координата X</param>
		/// <param name="yComboBox">Координата Y</param>
		/// <param name="widthComboBox">Ширина создаваемого компонента</param>
		/// <param name="heightComboBox">Выстота создаваемого компонента</param>
		private FBA.ComboBoxFBA CreateComboBox(int indexParam,
								    int xComboBox,
		                            int yComboBox, 
		                            int widthComboBox, 
		                            int heightComboBox)
		{
						
		    comboBoxArray[indexParam] = new FBA.ComboBoxFBA();		    
			comboBoxArray[indexParam].Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));		
			comboBoxArray[indexParam].BackColor = System.Drawing.SystemColors.Info;
			comboBoxArray[indexParam].ContextMenuEnabled = true;			
			comboBoxArray[indexParam].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));			
			comboBoxArray[indexParam].Location = new System.Drawing.Point(xComboBox, yComboBox);
			comboBoxArray[indexParam].Margin = new System.Windows.Forms.Padding(4, 4, 13, 13);
			comboBoxArray[indexParam].Name = "cb" + indexParam.ToString();			
			comboBoxArray[indexParam].ObjectID = "";				
			comboBoxArray[indexParam].ReadOnly = false;		
			comboBoxArray[indexParam].SaveParam = false;		
			comboBoxArray[indexParam].SaveValueHistory = false;
			comboBoxArray[indexParam].Size = new System.Drawing.Size(widthComboBox, heightComboBox);			    
			comboBoxArray[indexParam].ValueHistoryInItems = false;
			if (arrvp[indexParam].values != null) comboBoxArray[indexParam].Items.AddRange(arrvp[indexParam].values); 
			comboBoxArray[indexParam].Text = arrvp[indexParam].value;
			Controls.Add(comboBoxArray[indexParam]);
			comboBoxArray[indexParam].ReadOnly = arrvp[indexParam].readOnly;
			comboBoxArray[indexParam].Enabled  = !arrvp[indexParam].notEnabled;
			return comboBoxArray[indexParam];					
		}
		
		/// <summary>
		/// Установка WordWrap
		/// </summary>
		/// <param name="controls">form.Controls</param>
		/// <param name="wordWrap">true или false</param>
		private void SetWordWrap(Control.ControlCollection controls, bool wordWrap)
        {    
            foreach(Control control in controls)
            {                      
                SetWordWrap(control.Controls, wordWrap);  
                if (control.GetType().ToString() == "FBA.TextBoxFBA")
                {
                	((FBA.TextBoxFBA)control).WordWrap = wordWrap;
                }
            }                       
		}
		
		/// <summary>
		/// Установка WordWrap
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CbWordWrapCheckedChanged(object sender, EventArgs e)
		{
			SetWordWrap(this.Controls, cbWordWrap.Checked);
		}		
	}
	
	/// <summary>
	/// Класс для описания параметра формы FormValue.
	/// </summary>
	public struct ValueParam
	{			
		/// <summary>
		/// Если компонент должен быть ComboBox-ом, то true.
		/// </summary>
		public ComponentType componentType;
		
		/// <summary>
		///Тип значения
		/// </summary>
		public ValueType valueType;
				
		/// <summary>
		/// Значение ComboBox.Text или textBox.Text
		/// </summary>
		public string value;
		
		/// <summary>
		/// Подпись над компонентом ввода
		/// </summary>
		public string captionValue;
		
		/// <summary>
		/// Список текстовых значений. Только для ComboBox.
		/// </summary>
		public string[] values;		
		
	    /// <summary>
	    /// Высота поля компонента. Только для TextBox.
	    /// </summary>
		public int height;
		
		/// <summary>
	    /// Ширина поля компонента. Только для TextBox.
	    /// </summary>
		public int width;
				
		/// <summary>
		/// Полосы прокрутки. Только для TextBox.
		/// </summary>
		public System.Windows.Forms.ScrollBars scrolls;
		
		/// <summary>
		/// Перенос текста.
		/// </summary>
		public bool wordwrap;
		
		/// <summary>
		/// Текст запроса MSQL, для показа результатов в ComboBox.
		/// </summary>
		public string msql;
		
		/// <summary>
		/// Текст запроса SQL, для показа результатов в ComboBox.
		/// </summary>
		public string sql;
			
		/// <summary>
		/// Текст, который будет выводиться в TextBox светло-серым цветом (подсказка пользователю), когда в компоненте пусто. Например текст "Введите номер договора"
		/// </summary>
		public string defaultTextGray;
		
		/// <summary>
		/// Цвет текст, который будет выводиться в TextBox светло-серым цветом, когда в компоненте пусто. Например текст "Введите номер договора"
		/// По умолчанию он Color.Gray. Но здесь его можно изменить.
		/// </summary>
		public Color defaultTextGrayColor;	
		
		/// <summary>
		/// Свойство Read only для TextBox и ComboBox.
		/// </summary>
		public bool readOnly;	
		
		/// <summary>
		/// Свойство Read only для TextBox и ComboBox.
		/// </summary>
		public bool notEnabled;	
		
		
		/*public ValueParam(bool hh)
		{
			componentType = ComponentType.TextBox;		
		    valueType = ValueType.String;				
		    value = "";		
		    captionValue = "";		
		    values = null;				
	        height = 100;		
		    width = 100;				
		    scrolls = System.Windows.Forms.ScrollBars.Both;		
		    wordwrap = false;		
		    msql = "";		
		    sql = "";			
		    defaultTextGray = "";		
		    defaultTextGrayColor = Color.LightGray;	
		    readOnly = false;			
		    enabled = true;	
			this.enabled = true;
		}*/
		
		
		/// <summary>
		/// Скопировать один параметр в другой. Копирование по значению, а не по ссылке.
		/// </summary>
		/// <param name="vp">Параметр кода копируем значения из данного.</param>
		public void CopyTo(ValueParam vp)
		{
			vp.componentType        = this.componentType;        //ComponentType
			vp.valueType            = this.valueType;            //ValueType
			vp.value                = this.value;                //string
			vp.captionValue         = this.captionValue;         //string
			if (this.values != null)
			{
				vp.values = new string[this.values.Length];
				this.values.CopyTo(vp.values, 0);		             //string[]
			}
		    vp.height               = this.height;               //int
		    vp.width                = this.width;                //int			
		    vp.scrolls              = this.scrolls;              //System.Windows.Forms.ScrollBars		
		    vp.wordwrap             = this.wordwrap;             //bool	
			vp.msql                 = this.msql;                 //string 		    
		    vp.sql                  = this.sql;                  //string 
		    vp.defaultTextGray      = this.defaultTextGray;      //string
		    vp.defaultTextGrayColor = this.defaultTextGrayColor; //Color		
		    vp.readOnly		        = this.readOnly;             //bool	
		}
	}
		
}