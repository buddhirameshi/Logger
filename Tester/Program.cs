using Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{

    /// <summary>
    /// Tester class for custom logger
    /// </summary>
    class Program
    {
        /// <summary>
        /// Tester method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LoggerFactory factory = new LoggerFactory();

            try
            {
                //Testing the text logger
                var oneLogger = factory.GetLogger(LoggerFactory.LoggerMode.TextLogger);
                oneLogger.WiteEventLog("<FilePath>", "<FileName>", "testmessage"); //File path as the source parameter and the file name as the log parameter
                Console.WriteLine("File Logger Succeeded");

            //Testing the DB logger
            var secondLogger = factory.GetLogger(LoggerFactory.LoggerMode.DBLogger);
            secondLogger.WiteEventLog("<Connection>", "<SQL Query>", "testmessage",new object []  {CommandType.StoredProcedure}); //Connection string as the source parameter and the SQL Query as the log parameter and commandtype enum value is in the extra parameters array
            Console.WriteLine("DB Logger Succeeded");

             //Testing the EVent logger
             var thirdLogger = factory.GetLogger(LoggerFactory.LoggerMode.EventLogger);
            thirdLogger.WiteEventLog("<source>", "<eventLog>", "testmessage", new object[] { EventLogEntryType.Error }); //Connection string as the source parameter and the SQL Query as the log parameter and commandtype enum value is in the extra parameters array
                Console.WriteLine("Event Logger Succeeded");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();

        }
    }
}
