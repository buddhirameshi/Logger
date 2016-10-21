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
            
            try
            {               
                //Testing the text logger
                var oneLogger = new LogManager(new TextLogger());
                oneLogger.WriteLog("C:\\Users\\buddhirameshi\\Desktop", "Tex.txt", "testmessage"); //File path as the source parameter and the file name as the log parameter

                //Testing the DB logger
                oneLogger = new LogManager(new DBLogger());
                oneLogger.WriteLog("<Connection>", "<SQL Query>", "testmessage",new object []  {CommandType.StoredProcedure}); //Connection string as the source parameter and the SQL Query as the log parameter and commandtype enum value is in the extra parameters array

                //Testing the EVent logger
                oneLogger = new LogManager(new EventLogger());
                oneLogger.WriteLog("<source>", "<eventLog>", "testmessage", new object[] { EventLogEntryType.Error }); //Connection string as the source parameter and the SQL Query as the log parameter and commandtype enum value is in the extra parameters array

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();

        }
    }
}
