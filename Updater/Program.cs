/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 28.04.2017
 * Время: 18:10
*/
 
using System;
using System.Windows.Forms;
namespace FBA
{       
    internal sealed class Program
    {      
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormUpdate(args)); //Передаем список аргументов.
        }       
    }
}
