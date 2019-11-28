
﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 17.12.2016
 * Время: 23:38
 */
 
using System;
//using System.Windows.Forms;  
//using System.Drawing;
using System.Windows.Forms;
//using System.ComponentModel;
//using System.ComponentModel.Design;    
//using System.Windows.Forms.Design;
//using System.Reflection;  //Для динам. подключения DLL           
//using System.CodeDom.Compiler;
//using Microsoft.CSharp;
//using System.Collections.Generic;
//using System.Data;
using System.Linq;
using System.Reflection;
using System.IO;
//using FastColoredTextBoxNS; 
//using @"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\sys\bin\Debug\sys.dll";
using System.Security.Permissions;
namespace FBA
{                 
	internal sealed class Program 
	{  
		
		[STAThread]
		//[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
		private static void Main(string[] args)  
		{					    		    		   	                   
		  
			/*<configuration>
       <runtime>
          <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
             <dependentAssembly>
                <assemblyIdentity name="VendorAssembly"  culture="neutral" publicKeyToken="307041694a995978"/>
                <codeBase version="1.1.1.1" href="FILE://D:/ProgramFiles/VendorName/ProductName/Support/API/Bin64/VendorAssembly.dll"/>
             </dependentAssembly>
          </assemblyBinding>
       </runtime>
    </configuration>*/
				
				
			//AppDomain currentDomain = AppDomain.CurrentDomain;
			//AppDomain.AssemblyResolve += OnAssemblyResolve;
			//currentDomain.AssemblyResolve += new ResolveEventHandler(OnAssemblyResolve);
			AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve; //ResolveAssemblies; //OnAssemblyResolve;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			//AppDomain.CurrentDomain.AppendPrivatePath(@"C:\000_Тravin\Дизайнер SD\FBA\Library\");					
			//AppDomainSetup m_Setup;
			//m_Setup = new AppDomainSetup();
			//m_Setup.PrivateBinPathProbe = "";
			//m_Setup.PrivateBinPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
			//m_Setup.LoaderOptimization;
			//Directory.SetCurrentDirectory(@"C:\000_Тravin\Дизайнер SD\FBA\Library\"); // второй backslash перед Алекс
			
			//"System.AppDomain.AppendPrivatePath(string)" является устаревшим: "AppDomain.AppendPrivatePath has been deprecated. Please investigate the use of AppDomainSetup.PrivateBinPath instead. http://go.microsoft.com/fwlink/?linkid=14202" (CS0618) - C:\000_Тravin\Дизайнер SD\FBA\ClientApp\Program.cs:43,4
            Var.SystemName = "ClientApp";            

            //Установка соединения с локальной базой SQLIte. Без неё не работаем.			  
            sys.ConnectLocal();
			//sys.ConnectLocal();
            //sys.ConnectRemote();		
			if (Var.Args.Length < 2) 
			{					
			     sys.ConnectRemote();			                        
			} else
			{
			    sys.ConnectParam();    			    		    		
			}
            //Если соединение с сервером приложений, то получаем локальный порт, и стартуем локальный сервер HTTP.
            if (!Var.con.ConnectionDirect)
            {
                Var.LocalServerPort = sys.GetServerLocalPort();
                ServerWork.ServerStart(Var.FormMainObj);
            }
           
            //Запуск главной формы.
            Var.FormMainObj.ShowInTaskbar = true; //Даже если форма настроена на то чтобы скрываться, все равно показываем.
            System.Windows.Forms.Application.Run(Var.FormMainObj);


            //Остановка локального сервера.
            if (!Var.con.ConnectionDirect)
            {
                sys.SendEventClientClose();
                ServerWork.ServerStop();
            }
        }
					
        /// <summary>
        /// Событие возникет когда при загрузке ClientApp JIT не может найти сборку из References.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">Ненайденная сборка</param>
        /// <returns>Сборка</returns>
		private static Assembly OnAssemblyResolve (object sender, ResolveEventArgs args)
		{						
			string name = new AssemblyName(args.Name).Name;
			//name = name.Replace(".resources", "");			
            //поиск загруженной сборки.
            if (name.IndexOf(".resources", System.StringComparison.OrdinalIgnoreCase) > 0) return null;
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.GetName().Name == name) return assembly;                              
            }
			
            string PathMain = System.Windows.Forms.Application.StartupPath + "\\";    
            string PathDll = Path.GetDirectoryName(Path.GetDirectoryName(PathMain)) + @"\" + name + ".dll";   
            if (!File.Exists(PathDll))  
            {
            	 MessageBox.Show("Не найден файл: " + name, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		         return null;           
            }
            try
            {
            	//return Assembly.LoadFile(PathDll);  
            	 using (Stream io = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
		            {
		                if (io == null)
		                {
		                    //MessageBox.Show("Ошибка при загрузке файла DLL: " + name,  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		                    Environment.Exit(-1);
		                }
		                using (var binaryReader = new BinaryReader(io))
		                {
		                    return Assembly.Load(binaryReader.ReadBytes((int)io.Length));		                   
		                }
		            }
            } catch (Exception ex)
            {
            	 MessageBox.Show("Ошибка при загрузке файла DLL: " + name + " " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		         return null;  
            }
		}						
	}
}
