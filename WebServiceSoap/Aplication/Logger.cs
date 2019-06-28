using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebServiceSoap.Aplication
{
    public static class Logger
    {
        private static string m_exePath = string.Empty;
        private static string Filepath => ConfigurationManager.AppSettings["LogFile"].ToString();       


        public static void LogWrite(string Method,string logMessage)
        {
            if (string.IsNullOrEmpty(Filepath))
            {
                m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "LogCRUDDefault-"+ DateTime.Now.ToString("yyyy-MM-dd") +".txt";
            }
            else
            {
                m_exePath = Filepath+ "\\" + "LogCRUDDefault-" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath))
                {
                    Log(Method,logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void Log(string Method,string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("Method : {0} ---", Method );
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
        
    }
}