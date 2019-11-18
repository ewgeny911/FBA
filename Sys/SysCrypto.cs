
/*
 * Сделано в SharpDevelop.
 * Пользователь: Травин
 * Дата: 26.08.2017
 * Время: 0:00
 */
	
using System;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Management;

namespace FBA
{	     
    /// <summary>
    /// Класс для шифрования
    /// </summary>
    public static class Protector 
    {       
        //Код машины где запущена программа
        /*public static string FullMachineInfo { get; private set; }
        
        //Путь к файлу ключа
        static string keyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Filename.bin");
 
        //Статический конструктор
        static Protector() 
        {
            //Построение строки-кода
            string mcuID = new string(GetProcessor_ID().Select(ch => (char)(ch + 1)).ToArray());
            string mbID  = new string(GetMotherBoard_ID().Select(ch=>(char)(ch+1)).ToArray());
            FullMachineInfo=string.Join("@", mcuID, mbID);
        }
 
        ///Открытый метод проверки наличия и корректности ключа
        public static bool GetRegisterResult() 
        {
            if (!File.Exists(keyFilePath)) return false;           
            if (!Decrypt(keyFilePath))     return false;          
            return true;
        }
 
        ///Метод дешифрования-файла ключа
        static bool Decrypt(string path) 
        {
            //Формирование ключа дешифровки с подгонкой под размер
            List<byte> providerKey = new List<byte>(Encoding.Default.GetBytes(FullMachineInfo));
            if (providerKey.Count < 0x20) 
            {
                providerKey.AddRange(new byte[0x20 - providerKey.Count]);
            }
            else 
            {
                providerKey.RemoveRange(0x20, providerKey.Count - 0x20);
            }
            //Формирование вектора инициализации дешифровки
            byte[] providerIV = Enumerable.Range(0, 0x10).Select(i => (byte)i).ToArray();
 
            //Текущая исполняемая сборка
            Assembly asm = Assembly.GetExecutingAssembly();
 
            //Тело точки входа
            MethodBody mainMethodBody = asm.EntryPoint.GetMethodBody();
 
            //CIL код оригинальной точки входа как массива байт
            byte[] entryPointOriginal = mainMethodBody.GetILAsByteArray();
 
            //Массив байт файла-ключа(зашифрованная точка входа)
            byte[] entryPointEncrypted = File.ReadAllBytes(path);
 
            //Объект-шифровальщик
            using (Aes provider = Aes.Create()) 
            {
                //Ключ и вектор инициализации шифровальщика
                provider.IV = providerIV;
                provider.Key = providerKey.ToArray();
 
                //Дешифратор
                using (ICryptoTransform decryptor = provider.CreateDecryptor()) 
                {
                    //Блок обработки ошибок
                    try 
                    {
                        //Массив расшифрованной точки входа из файла ключа
                        byte[] entryPointDecrypted =
                            decryptor.TransformFinalBlock(entryPointEncrypted, 0, entryPointEncrypted.Length);
                        
                        //Сравнение по размеру
                        if (entryPointOriginal.Length != entryPointDecrypted.Length) 
                        {
                            return false;
                        }
 
                        //Сравнение по значениям
                        for (int i = 0; i < entryPointDecrypted.Length; i++) 
                        {
                            if (entryPointDecrypted[i] != entryPointOriginal[i]) 
                            {
                                return false;
                            }
                        }
                    }
                    catch 
                    {
                        //Возврат false при ошибке расшифровки
                        return false;
                    } 
                }
            }
            return true;
        }
        */
             
        /*
        //Метод получения информации о целевом ПК
        public static void GetUserConfigurationInfo() 
        {
            SelectQuery[] queries = new SelectQuery[3]{
                new SelectQuery("Win32_Processor"),
                new SelectQuery("Win32_BaseBoard"),
                new SelectQuery("Win32_VideoController")
            };
            string[] infoQueries = { "processorId", "SerialNumber", "AdapterRAM" };
            string[] results = new string[3];
            int index = 0;
 
            foreach (SelectQuery query in queries) {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection.ManagementObjectEnumerator enumerator =
                    searcher.Get().GetEnumerator();
                while (enumerator.MoveNext()) {
                    ManagementObject info = (ManagementObject)enumerator.Current;
                    results[index] = info[infoQueries[index]].ToString().Trim();
                }
                index++;
            }
            FullMachineInfo = new string(string.Join("@", results).Select(ch => (char)(ch + 1)).ToArray());
        }
        */ 
                                    
        /// <summary>
        /// Метод для получения ProcessorID
        /// </summary>
        /// <returns>ProcessorID</returns>
        public static string GetProcessor_ID() {
            string processorID = string.Empty;
            var query = new SelectQuery("Win32_processor");
            var searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator();
            while (enumerator.MoveNext()) {
                var info = (ManagementObject)enumerator.Current;
                processorID = info["processorId"].ToString().Trim();
            }
            return processorID;
        }
       
        /// <summary>
        /// Метод для получения MotherBoardID
        /// </summary>
        /// <returns>ИД материнской платы</returns>
        public static string GetMotherBoard_ID() 
        {
            string motherBoardID = string.Empty;
            var query = new SelectQuery("Win32_BaseBoard");
            var searcher = new ManagementObjectSearcher(query);
                     
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator();
            while (enumerator.MoveNext()) 
            {
                var info = (ManagementObject)enumerator.Current;
                motherBoardID = info["SerialNumber"].ToString().Trim();
            }
            return motherBoardID;
        }              
        
        /// <summary>
        /// Метод для получения ИД видеокарты
        /// </summary>
        /// <returns>ИД видеокарты</returns>
        private static string GetVideoAdapter_ID() 
        {
            string motherBoardID = string.Empty;
            var query = new SelectQuery("Win32_VideoController");
            var searcher = new ManagementObjectSearcher(query);  
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator();
            while (enumerator.MoveNext()) 
            {
                var info = (ManagementObject)enumerator.Current;
                motherBoardID = info["AdapterRAM"].ToString().Trim();
            }
            return motherBoardID;
        }             
    }   
         
    /// <summary>
    /// Статический класс. Шифровка/расшифровка. 
    /// </summary>
	public static class Crypto
    {               
		private static readonly byte[] Salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");
        
        ///Получение хеша MD5 строки. Эта функция не связана с EncryptStringAES и DecryptStringAES.
		public static string MD5(this string inputStr)
        {            
			string strHash = string.Empty;
            foreach (byte b in new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(inputStr)))            
                strHash += b.ToString("X2");            
            return strHash;
		}  		
             
        /// <summary>
        /// Шифрование по алгоритму AES.
        /// </summary>
        /// <param name="inputStr">Входная строка, которую нужно зашифровать</param>
        /// <param name="secret">Ключ шифрования</param>
        /// <returns>Зашифрованная строка</returns>
        public static string EncryptAES(this string inputStr, string secret = "")
        {
            //Encrypt the given string using AES.  The string can be decrypted using
        	//DecryptStringAES().  The sharedSecret parameters must match.      
        	//plainText - The text to encrypt.
        	//sharedSecret - A password used to generate a key for encryption.        	     
        	string sharedSecret = "";
            if (secret != "") sharedSecret = secret;
             else sharedSecret = "string.IsNullOrEmpty";
             
        	if (string.IsNullOrEmpty(inputStr))    return ""; //throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret)) return ""; //throw new ArgumentNullException("sharedSecret");
            string outStr;                       //Encrypted string to return
            RijndaelManaged aesAlg = null;       // RijndaelManaged object used to encrypt the data.
            try
            {               
                var key = new Rfc2898DeriveBytes(sharedSecret, Salt); //generate the key from the shared secret and the salt                  
                aesAlg = new RijndaelManaged(); //Create a RijndaelManaged object
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
 
                //Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
 
                //Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    //prepend the IV
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {                           
                            swEncrypt.Write(inputStr); //Write all data to the stream.
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                if (aesAlg != null) aesAlg.Clear();
            }       
            return outStr;
        }
           
        /// <summary>
        /// Расшифровка по алгоритму AES.
        /// </summary>
        /// <param name="inputStr">Входная строка, которую нужно расшифровать</param>
        /// <param name="secret">Ключ шифрования</param>
        /// <returns>Расшифрованная строка</returns>
        public static string DecryptAES(this string inputStr, string secret = "")
        {   
        	//Decrypt the given string.  Assumes the string was encrypted using 
        	//EncryptStringAES(), using an identical sharedSecret.     
        	//cipherText - The text to decrypt.
        	//sharedSecret - A password used to generate a key for decryption.
        	string sharedSecret = "";
        	if (secret != "") sharedSecret = secret;
        	 else sharedSecret = "string.IsNullOrEmpty";
        	
        	if (string.IsNullOrEmpty(inputStr))    return "";
            if (string.IsNullOrEmpty(sharedSecret))  return "";  
            RijndaelManaged aesAlg = null;   
            string plaintext;
            try
            {                
                var key = new Rfc2898DeriveBytes(sharedSecret, Salt); //generate the key from the shared secret and the salt                                 
                byte[] bytes = Convert.FromBase64String(inputStr); //Create the streams used for decryption. 
                using (var msDecrypt = new MemoryStream(bytes))
                {
                    //Create a RijndaelManaged object
                    //with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    
                    //Get the initialization vector from the encrypted stream
                    aesAlg.IV = ReadByteArray(msDecrypt);
                    
                    //Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                            // Read the decrypted bytes from the decrypting stream and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }
            return plaintext;
        }
              
        private static byte[] ReadByteArray(Stream s)
        {                  
        	var rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) == rawLength.Length)
            {
                var buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
                if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
                    throw new SystemException("Did not read byte array properly");                
                return buffer;
            }
            throw new SystemException("Stream did not contain properly formatted byte array");            
        }            
        
        /// <summary>
        /// Записать Hash MD5 в конец файла. MD5 всегда 32 байта. 
        /// Это нужно для того чтобы однозначно отличить один файл от другого. 
        /// Используется для сверки верии подгружаемых проектов
        /// </summary>
        /// <param name="fileName">Имя файла, в конец которго нужно добавить Hash</param>
        /// <param name="hashMD5">MD5</param>
        /// <returns>Если успешно, то true</returns>
	    public static bool FileHashMD5Write(string fileName, string hashMD5)
	    {   	          
	    	try
	    	{                         
	    		var fstream = new FileStream(fileName, FileMode.OpenOrCreate);                                    
                byte[] array = System.Text.Encoding.Default.GetBytes(hashMD5); //преобразуем строку в байты                 
                fstream.Seek(0, SeekOrigin.End);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;                                                         	   
	    	}  catch (Exception ex)
	    	{
	    	    sys.SM("Ошибка записи контрольной суммы в файл: " + fileName + Var.CR + ex.Message);
	    	    return false;
	    	}	    	                               
	    }
	    	  
	    /// <summary>
	    /// Считать Hash MD5, записанный в конец файла. MD5 Всегда 32 байта.
	    /// Если в конце фафла нет MD5 - все равно функция вернёт последние 32 байта.
	    /// </summary>
	    /// <param name="fileName">Произвольный файл</param>
	    /// <returns>Последние 32 байта файла</returns>
		public static string FileHashMD5Read(string fileName)
	    {				   
		    var f1 = new FileInfo(fileName);
            FileStream fstream = f1.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
            var br = new BinaryReader(fstream);
            fstream.Seek(-32, SeekOrigin.End);            
            var output = new byte[32];
            output = br.ReadBytes(32);
			fstream.Close();		  
            return Encoding.Default.GetString(output); 
		}
		
		/// <summary>
		/// Вычислить Hash MD5 файла. MD5 Всегда 32 байта.
		/// </summary>
		/// <param name="fileName">Имя произвольного файла</param>
		/// <returns>MD5 - 32 символа</returns>
		public static string FileHashMD5Calc(string fileName)
        {             			 
		    if (!File.Exists(fileName)) return "";
		    var f1 = new FileInfo(fileName);
            FileStream fstream = f1.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
            var fileData = new byte[fstream.Length];
            fstream.Read(fileData, 0, (int)fstream.Length);           
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(fileData);
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;           
        }        
    }	          
 }
 
