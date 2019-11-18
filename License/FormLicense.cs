
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 06.11.2017
 * Время: 0:09
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace FBA
{     
    ///Форма генерирования лицензионного ключа.    
    public partial class FormLicense : Form
    {
        ///Конструктор 
        public FormLicense()
        {              
            InitializeComponent();            
        }
        
        ///Разделяем параметр на несколько, по разделютелю точка с запятой.
        private void GetServernfo(string KeyStr, 
                              out string ProcessorID,
                              out string MotherBoardID,                            
                              out string LicenseCount,
                              out string DateCreate,
                              out string DateStart,
                              out string DateEnd,
                              out string LicenseKey)
        {                       
            ProcessorID    = KeyStr.StringBetween("PrID=", ";");
            MotherBoardID  = KeyStr.StringBetween("MBID=", ";");           
            LicenseCount   = KeyStr.StringBetween("LCnt=", ";"); 
            DateCreate     = KeyStr.StringBetween("DCr=",  ";"); 
            DateStart      = KeyStr.StringBetween("DSt=",  ";"); 
            DateEnd        = KeyStr.StringBetween("DEn=",  ";"); 
            LicenseKey     = KeyStr.StringBetween("LK=",   ";");   
        }               
        
        ///Проверка лицензии.
        private void CheckLincense(string License)
        {
            //Расшифровываем ServerInfo
            string ServerInfo;
            try
            {
                ServerInfo = License.Replace("<License>", "").Replace("</License>", "").DecryptAES("ServerInfo");
                
            } catch 
            {
                sys.SM("Ошибка расшифровки ServerInfo");
                return;
            }
            
            string ProcessorID    = "";
            string MotherBoardID  = "";
            string LicenseCount   = "";
            string DateCreate     = "";             
            string DateStart      = "";
            string DateEnd        = "";
            string LicenseKey     = "";
            GetServernfo(ServerInfo, 
                         out ProcessorID,
                         out MotherBoardID,                       
                         out LicenseCount,
                         out DateCreate,
                         out DateStart,
                         out DateEnd,
                         out LicenseKey);
            
            
                       
            if ((ProcessorID == "")   || 
                (MotherBoardID == "") || 
                (DateCreate == ""))
            {
                sys.SM("Ошибка проверки значений ключа: " + Var.CR + 
                      "ProcessorID="   + ProcessorID     + Var.CR + 
                      "MotherBoardID=" + MotherBoardID   + Var.CR + 
                      "LicenseCount="  + LicenseCount    + Var.CR + 
                      "DateCreate="    + DateCreate      + Var.CR +                     
                      "DateStart="     + DateStart       + Var.CR + 
                      "DateEnd="       + DateEnd         + Var.CR + 
                      "LicenseKey="    + LicenseKey);
                return;
            }
            
            dtDateCreate1.Text = DateCreate;
            
            if (LicenseKey == "") 
            {
                tbProcessorID1.Text   = ProcessorID;
                tbMotherBoardID1.Text = MotherBoardID;          
                tbLicenseCount1.Text  = LicenseCount;
                //DateCreate
                dtDateStart1.Text     = DateStart;
                dtDateEnd1.Text       = DateEnd;
                sys.SM("Внимание! Предыдущая лицензия передана пустая!" + Var.CR +
                       "Ранее не было выданных лицензий?", MessageType.Warning);                           
            }
            
            if (LicenseKey != "")
            {           
                string LicenseKeyDecrypt  = LicenseKey.DecryptAES("ServerInfo");
                string ProcessorID_OLD    = "";
                string MotherBoardID_OLD  = "";
                string LicenseCount_OLD   = ""; 
                string DateCreate_OLD     = "";                
                string DateStart_OLD      = "";
                string DateEnd_OLD        = "";
                string LicenseKeyOld_OLD  = "";
                GetServernfo(LicenseKeyDecrypt, 
                             out ProcessorID_OLD,
                             out MotherBoardID_OLD,
                             out LicenseCount_OLD,
                             out DateCreate_OLD,                              
                             out DateStart_OLD,
                             out DateEnd_OLD,
                             out LicenseKeyOld_OLD);
                
                tbProcessorID1.Text   = ProcessorID;
                tbMotherBoardID1.Text = MotherBoardID;          
                tbLicenseCount1.Text  = LicenseCount_OLD;
                //dtDateCreate1.Text    = DateCreate_OLD;
                dtDateStart1.Text     = DateStart_OLD;
                dtDateEnd1.Text       = DateEnd_OLD;
            
                //Проверяем, что в старой лицензии все те же самые Processor_ID и MotherBoard_ID.
                string ChangeComp = "";
                int ChangeCount = 0;
                bool ChangeProcessor = false;
                if (ProcessorID != ProcessorID_OLD)
                {
                    ChangeComp = ChangeComp + "Processor_ID=" + ProcessorID + Var.CR + "ProcessorID_OLD=" + ProcessorID_OLD + Var.CR;
                    ChangeCount++;
                    ChangeProcessor = true;
                }
                
                bool ChangeMotherBoard = false;
                if (MotherBoardID != MotherBoardID_OLD) 
                {
                    ChangeComp = ChangeComp + "MotherBoard_ID=" + MotherBoardID + Var.CR + "MotherBoardID_OLD=" + MotherBoardID_OLD + Var.CR;
                    ChangeCount++;
                    ChangeMotherBoard = true;
                }
                string Mes = "";
                MessageType typeMessage = MessageType.Warning;
                if (ChangeCount > 0)
                {                             
                    Mes = "Внимание! Произошли изменения комплектующих! " + Var.CR;
                    if (ChangeProcessor) Mes = Mes + "ID процессора изменился:" + Var.CR + 
                        "Processor_ID=" + ProcessorID  + Var.CR + 
                        "Processor_ID_OLD=" + ProcessorID_OLD + Var.CR;
                    if (ChangeMotherBoard) Mes = Mes + "ID материнской платы:" + Var.CR + 
                        "MotherBoard_ID=" + ProcessorID  + Var.CR + 
                        "MotherBoard_ID_OLD=" + ProcessorID_OLD + Var.CR;
                      
                    if (ChangeCount > 1) 
                    {
                        typeMessage = MessageType.Error;
                        Mes = Mes + "Изменения допускаются только для одного из комплетующих!" + Var.CR;
                    }                                                              
                }
                if (LicenseCount != LicenseCount_OLD) 
                {
                    Mes = Mes + "Не совпадает количество лицензий:" + Var.CR +
                        "LicenseCount=" + LicenseCount + Var.CR + 
                        "LicenseCount_OLD=" + LicenseCount_OLD+ Var.CR;
                }                
                if (DateCreate != DateCreate_OLD) 
                {
                    Mes = Mes + "Не совпадает Дата начала лицензии:" + Var.CR +
                        "DateStart=" + DateStart + Var.CR + 
                        "DateStart_OLD=" + DateStart_OLD+ Var.CR;
                }
                if (DateCreate != DateCreate_OLD) 
                {
                    Mes = Mes + "Не совпадает Дата окончания лицензии:" + Var.CR +
                        "DateEnd=" + DateEnd + Var.CR + 
                        "DateEnd_OLD=" + DateEnd_OLD+ Var.CR;
                }
                if (Mes != "")
                 sys.SM(Mes, typeMessage);  
                
                if (ChangeCount == 0)
                {
                    sys.SM("Проверка прошла успешно!" + Var.CR + 
                           "ID процессора и материнской платы совпадают с предыдущими значениями!", MessageType.Information);
                }
            }
        }
        
        ///Перенос данных в правую часть, для создания ключа.
        private void BtnTo2Click(object sender, EventArgs e)
        {
            tbProcessorID2.Text   = tbProcessorID1.Text;
            tbMotherBoardID2.Text = tbMotherBoardID1.Text;
            tbLicenseCount2.Text  = tbLicenseCount1.Text;
            dtDateCreate2.Value   = DateTime.Now;
            dtDateStart2.Value    = DateTime.Now;
            dtDateEnd2.Value      = sys.StringToDateTime("2024-01-01 23:59:59.000");
        }
        
        ///Создаем License key.         
        private void BtnLicenseCreateClick(object sender, EventArgs e)
        {                                                      
            string LicenseKeyNew = 
                      "PrID=" + tbProcessorID2.Text   + ";" +
                      "MBID=" + tbMotherBoardID2.Text + ";" +                    
                      "LCnt=" + tbLicenseCount2.Text  + ";" +
                      "DCr="  + dtDateCreate2.Text    + ";" +                
                      "DSt="  + dtDateStart2.Text     + ";" +       
                      "DEn="  + dtDateEnd2.Text       + ";" + 
                      "LK="   + ";";
                
            tbLicense.Text = "<License>" +LicenseKeyNew.EncryptAES("ServerInfo") + "</License>";          
        }
        
        ///Проверка лицензии.
        private void BtnCheckServerInfoClick(object sender, EventArgs e)
        {
            CheckLincense(tbServerInfo.Text);
        }
        
        ///Копирование в буфер обмена сформированной лицензии.
        private void BtnCopyToClipboardClick(object sender, EventArgs e)
        {
            Clipboard.SetText(tbLicense.Text);
        }
        
        //Кнопка помощи.
        private void BtnHelpClick(object sender, EventArgs e)
        {
            const string Mes =
                "Расшифровка кодов ошибок:" + Var.CR +    
                "600. Ошибка расшифровки лицензии." + Var.CR +   
                "601. Общий признак того, что произошла ошибка." + Var.CR +   
                "602. ID процессора не указано." + Var.CR +   
                "603. ID материнской платы не указано." + Var.CR +   
                "604. Указано, что количество лицензий равно 0." + Var.CR +         
                "605. Дата формирования ключа не указана." + Var.CR +   
                "606. Дата начала лицензии не уазана." + Var.CR +   
                "607. Дата окончания лицензии не указана." + Var.CR +   
                "608. Поле с предыдущей лицензией НЕ пустое." + Var.CR +   
                "609. Дата начала действия ключа ещё не наступила." + Var.CR +   
                "610. С момента формирования ключа прошло больше года - ключ устарел." + Var.CR +   
                "611. Изменено более одного компонента, процессор и материнская плата." + Var.CR;
            sys.SM(Mes, MessageType.Information);
        }                           
    }
     
    internal sealed class Program
    {         
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLicense());
        }
        
    }
}
