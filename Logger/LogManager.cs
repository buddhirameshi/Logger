using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
   public class LogManager
    {
        ILogger oneLogger;
        public LogManager(ILogger logger)
        {
            this.oneLogger = logger;
        }

        public void WriteLog(string source,string log,string message,object[] inputParams=null)
        {
            oneLogger.WiteLog(source,log,message,inputParams);
            Console.WriteLine(string.Format("{0} is succeeded.",oneLogger.GetType()));
        }
    }
}
