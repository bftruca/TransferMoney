using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace MoneyTransfer.Helpers
{
    public static class Logger
    {
        private static string log_file_path = string.Format(@"{0}logs.txt", HostingEnvironment.ApplicationPhysicalPath);

        public static string filePath
        {
            get { return Logger.log_file_path; }
            set { if (value.Length > 0) Logger.log_file_path = value; }
        }

        public static void flush()
        {
            File.WriteAllText(Logger.filePath, string.Empty);
        }

        public static void log(string msg)
        {
            if (msg.Length > 0)
            {
                using (StreamWriter sw = File.AppendText(Logger.filePath))
                {
                    sw.WriteLine("{0} {1}: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), msg);
                    sw.Flush();
                }
            }
        }
    }
}