
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 14.11.2017
 * Время: 10:15
 */
 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace FBA
{
    
	/// <summary>
	/// Класс для рассылки писем
	/// </summary>
    public class SysEmail
    {       
        /// <summary>
        /// Тема письма
        /// </summary>
    	public string Subject;
    	
    	/// <summary>
    	/// Содержимое письма
    	/// </summary>
        public string Body;
        
        /// <summary>
        /// Адрес постового сервера SMTP
        /// </summary>
        public string Host;
        
        /// <summary>
        /// Порт. По умолчанию 25.
        /// </summary>
        public int    Port = 25;
        
        /// <summary>
        /// Email от кого.
        /// </summary>
        public string EmailFrom;
        
        /// <summary>
        /// Email кому.
        /// </summary>
        public string EmailTo;
        
        /// <summary>
        /// Пароль от почты с которой шлём
        /// </summary>
        public string Password;
        
        /// <summary>
        /// Включить SSL.
        /// </summary>
        public bool   EnableSsl  = true;
        
        /// <summary>
        /// Содержимое письма в HTML
        /// </summary>
        public bool   IsBodyHtml = false;
        
        /// <summary>
        /// Список имен файлов с полными путями, для вложения.
        /// </summary>
        public string[] Attachments;
                        
        /// <summary>
        /// Послать почтовое сообщение через SMTP.
        /// </summary>
        /// <returns>Если успешно, то true</returns>
        public bool SendEmail()
        {                                                 
            try
            {
                using (MailMessage message = new MailMessage(this.EmailFrom, this.EmailTo))
                {
                    message.Subject    = this.Subject;
                    message.Body       = this.Body;  
                    message.IsBodyHtml = this.IsBodyHtml;                                   
                    for (int i = 0; i < Attachments.Length; i++)
                    {
                       message.Attachments.Add(new Attachment(Attachments[i]));                         
                    }
                    
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = this.EnableSsl,
                        Host      = this.Host,
                        Port      = this.Port,
                        Credentials = new NetworkCredential(this.EmailFrom, this.Password)
                    })
                    {
                        client.Send(message);
                    }
                }
                
            } catch (Exception ex)
            {
                sys.SM("Ошибка при посылке письма!" + Var.CR + ex.Message); 
                return false;
            }
            return true;
        } 
        
        
        /*public void SendEmail1()
        {
            
            //SendEmailAsync().GetAwaiter();
        
            SendEmailAsync(this.Body).Start();
        }
        
        private static async Task SendEmailAsync(string Body)
        {
            MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
            MailAddress to   = new MailAddress("somemail@yandex.ru");
            MailMessage m    = new MailMessage(from, to);
            m.Subject        = "Тест";
            m.IsBodyHtml     = false;
            m.Body           = Body; //"Письмо-тест 2 работы smtp-клиента";
            SmtpClient smtp  = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl   = true;              
            m.Attachments.Add(new Attachment("D://temlog.txt"));
            //Var.con.Exec("");
            await smtp.SendMailAsync(m);
            Console.WriteLine("Письмо отправлено");
        }*/
        
        
    
        
               
        
    }
}
