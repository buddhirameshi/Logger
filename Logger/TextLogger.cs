using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{

    /// <summary>
    /// For text logs
    /// </summary>
    public class TextLogger : ILogger
    {
        //private static TextLogger oneLogger;

        /// <summary>
        /// private constructor helps to prevents the instantiation of the class
        /// </summary>
        //private TextLogger()
        //{

        //}

        ///// <summary>
        ///// Get Logger method will instantiate an object if there is no extsing instance
        ///// </summary>
        ///// <returns></returns>
        //public static ILogger GetLogger()
        //{
        //    if (oneLogger == null)
        //    {
        //        oneLogger = new TextLogger();
        //    }
        //    return oneLogger;
        //}


        /// <summary>
        /// Write the message to text file
        /// </summary>
        /// <param name="source"></param>
        /// <param name="logName"></param>
        /// <param name="message"></param>
        /// <param name="extraParams"></param>
        public  void WiteLog(string source, string logName, string message,object [] extraParams=null)
        {
            string filePath = string.Format("{0}\\{1}", source, logName);
            using (StreamWriter sw = File.AppendText(filePath))
            {
                string logLine = string.Format("{0:G}: {1}.", System.DateTime.Now, message);
                sw.WriteLine(logLine);
            }


        }
    }
}
