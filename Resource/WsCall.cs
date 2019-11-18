
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.IO;
namespace FBA
{
    public partial class UserDefinedFunctions
    {
        //Setting function characteristics
        [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic=true, DataAccess=DataAccessKind.None)]
        public static SqlString fn_ws_call(SqlString requestUrl, 
                                           SqlString username, 
                                           SqlString password, 
                                           SqlString requestXml)
        {
    
            requestUrl = "http://ws-prod:8080/WebService";
            username   = "DIAFA";
            password   = "Q49XbxxC";
            requestXml = "A19977-0010984";
            return "";
            
            if (requestXml.IsNull) return requestXml;
    
            System.Net.HttpWebRequest wreq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(requestUrl.Value);
            wreq.Method = "POST";
    
            System.Net.CredentialCache credentialCache = new System.Net.CredentialCache();
            credentialCache.Add(
                new System.Uri(requestUrl.Value),
                "Basic",
                new System.Net.NetworkCredential(username.Value, password.Value)
            );
    
            wreq.Credentials = credentialCache;
            wreq.Headers.Add(@"SOAP:Action");
            wreq.ContentType = "text/xml; charset=\"utf-8\"";
            wreq.Accept = "text/xml";
            byte[] _byteVersion = System.Text.Encoding.UTF8.GetBytes(requestXml.Value);
            wreq.ContentLength = _byteVersion.Length;
    
            var soapEnvelopeXml = new System.Xml.XmlDocument();
            soapEnvelopeXml.LoadXml(requestXml.Value);
    
            using (var stream = wreq.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
    
            using (var wr = (System.Net.HttpWebResponse)wreq.GetResponse())
            {
                if (wr.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (var readStream = new StreamReader(wr.GetResponseStream()))
                    {
                        string result = readStream.ReadToEnd();
                        return new SqlString(result);
                    }
                }
                else
                    return new SqlString();
            }
    
        }
    }
};
