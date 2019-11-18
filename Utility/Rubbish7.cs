
﻿//I have fetched data from database as a complete dataset which has only one table in it.
//Made a  DataTableReader  from it and it is working as same as DataReader.
//Simple Example Below.
//DataBase.cs
/*public static class DataBase
{
private static VerticaConnection vConnection = null;
private static VerticaCommand vCommand = null;
private static VerticaDataAdapter vAdapter = null;
string private static void GetConnection()
{
GetAppSettings(); //get connection string from config
vConnection = new VerticaConnection(<connectionstring>);
vCommand = new VerticaCommand();
vAdapter = new VerticaDataAdapter(vCommand);
}
public static System.Data.DataSet getData(string query)
{
try{
GetConnection();
vCommand.CommandText = query;
vCommand.Connection = vConnection;
vAdapter.SelectCommand = vCommand;
System.Data.DataSet ds = new System.Data.DataSet();
vAdapter.Fill(ds);
return ds;
}catch(Exception ex)
{
throw ex;
}
}
}
Programs.cs 
 
class Program
{
    static void Main(string[] args)
    {
        string query = "<Select Query>";
        System.Data.DataSet ds = DataBase.getData(query);
        System.Data. DataTableReader  dr = ds.CreateDataReader();
        Console.Write(dr.FieldCount);
        while (dr.Read())
        {
            if (dr.HasRows)
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr[i].ToString() + "--");
                }
            }
            Console.WriteLine();
        }
        Console.Read();
    }
}
*/
/*using System.IO;
using System.Xml;
using System.Xml.Serialization;
        private void Form1_Load(object sender, EventArgs e)
        {          
            FileInfo f = new FileInfo("1.xml");
            if (f.Exists)
            {
                dataSet1.ReadXml("1.xml", XmlReadMode.ReadSchema);
                dataGridView1.DataSource = dataSet1.DefaultViewManager;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            var xmldoc = new XmlDocument();
            xmldoc.InnerXml = dataSet1.GetXml();
            xmldoc.Save("1.xml");
*/
    /*    //Возвращает полный путь к Дизайнеру DesignerApp.exe.
        public static bool GetPathDesigner(out string FileName)
        {
            string ApplicationDirectory = System.Windows.Forms.Application.StartupPath;
            FileName = ApplicationDirectory + @"\DesignerApp.exe";
            if (!File.Exists(FileName)) FileName = @"..\..\..\DesignerApp\bin\Debug\DesignerApp.exe";                                
            if (!File.Exists(FileName))
            {
                 sys.SM("Не найден файл DesignerApp.exe", "Вход в систему");
                 return false;
            }
            //Функция GetFullPath возвращает полный путь относительно текущей папки.
            Directory.SetCurrentDirectory(ApplicationDirectory);
            string FileNameFull = System.IO.Path.GetFullPath(FileName);
            if (!File.Exists(FileNameFull))
            {
                 sys.SM("Не найден файл DesignerApp.exe:" + FileNameFull, "Вход в систему");
                 return false;
            }
            FileName = FileNameFull;
            return true;          
        }
*/        
        
        
        
        /*
         private DataTable GetNullFilledDataTableForXML(DataTable dtSource)
    {
        // Create a target table with same structure as source and fields as strings
        // We can change the column datatype as long as there is no data loaded
        DataTable dtTarget = dtSource.Clone();
        foreach (DataColumn col in dtTarget.Columns)
            col.DataType = typeof(string);
        // Start importing the source into target by ItemArray copying which 
        // is found to be reasonably fast for nulk operations. VS 2015 is reporting
        // 500-525 milliseconds for loading 100,000 records x 10 columns 
        // after null conversion in every cell which may be usable in many
        // circumstances.
        // Machine config: i5 2nd Gen, 8 GB RAM, Windows 7 64bit, VS 2015 Update 1
        int colCountInTarget = dtTarget.Columns.Count;
        foreach (DataRow sourceRow in dtSource.Rows)
        {
            // Get a new row loaded with data from source row
            DataRow targetRow = dtTarget.NewRow();
            targetRow.ItemArray = sourceRow.ItemArray;
            // Update DBNull.Values to empty string in the new (target) row
            // We can safely assign empty string since the target table columns
            // are all of string type
            for (int ctr = 0; ctr < colCountInTarget; ctr++)
                if (targetRow[ctr] == DBNull.Value)
                    targetRow[ctr] = String.Empty;
            // Now add the null filled row to target datatable
            dtTarget.Rows.Add(targetRow);
        }
        // Return the target datatable
        return dtTarget;
    }
    
   public bool SelectDS(string SQL, out DataSet DS, out string ErrorText, bool ErrorShow)
        {           
            DS = new DataSet("DS");
            ErrorText = "";
            if ((SQL == "") || (SQL == "Empty")) return false;
           
            try
            {              
                if ((ConnectionDirect) && (ServerType == "Postgre"))
                {                      
                    command1 = new NpgsqlCommand(SQL);
                    command1.Connection = connection1;            
                    var da = new NpgsqlDataAdapter(command1);
                    da.Fill(DS);            
                }
                if ((ConnectionDirect) && (ServerType == "MSSQL"))
                {                             
                    //command2 = new SqlCommand(SQL);
                    //command2.Connection = connection2;
                    //var da = new SqlDataAdapter(command2); 
                    //SqlDataAdapter adapter = new SqlDataAdapter(sql, connection); 
                    var da = new SqlDataAdapter(SQL, connection2); 
                    da.Fill(DS);                                   
                }
                if ((ConnectionDirect) && (ServerType == "SQLite"))
                {                      
                    //command3 = new SQLiteCommand(SQL);
                    //command3.Connection = connection3; 
                    //var da = new SQLiteDataAdapter(command3); 
                    var da = new SQLiteDataAdapter(SQL, connection3);                     
                    da.Fill(DS);              
                }
                //((IDataAdapter)da).Fill(DS);
                //if (!ConnectionDirect) 
                //{                    
                    //System.Data.DataTable DT;
                    //string ErrorMes;
                    //if (AppSelect(SQL, out DT, out ErrorMes)) 
                    //{
                    //    dtRtn.Clear();
                    //    dtRtn.Add(DT);
                    //}
                //} 
                                
                return true;               
            }
            catch (Exception e)
            {               
                ErrorText = "Ошибка выполнения запроса:" + ErrorText + Var.CR + e.Message + Var.CR + SQL; 
                if (ErrorShow) sys.SM(ErrorText);                      
                DS = null;
                return false;               
            }
        }          
              
    
    
    
         */ 
        
        
        
        