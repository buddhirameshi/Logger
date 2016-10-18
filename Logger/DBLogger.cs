using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{

    /// <summary>
    /// for DB logs
    /// </summary>
   public class DBLogger :ILogger
    {

        private static DBLogger oneLogger;


        /// <summary>
        /// private constructor helps to prevents the instantiation of the class
        /// </summary>
        private DBLogger()
        {
        }


        /// <summary>
        /// Get Logger method will instantiate an object if there is no extsing instance
        /// </summary>
        /// <returns></returns>
        public static ILogger GetLogger()
        {
            if (oneLogger == null)
            {
                oneLogger = new DBLogger();
            }
            return oneLogger;
        }


        /// <summary>
        /// Write the message to the DB given by source connection string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="extraParams"></param>
        public void WiteEventLog(string source, string log, string message, object [] extraParams)
        {

            CommandType type = CommandType.Text; ////Set a default value to CommandType

            using (SqlConnection conn = new SqlConnection(source))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(log, conn))
                    {
                        if (extraParams != null && extraParams.Length > 0)  //if the extra parameters array contains values
                        {
                            if (extraParams.Any(item => item.GetType() == typeof(CommandType)))//Check for the CommandType input parameter
                            {
                                type = (CommandType)(extraParams.SingleOrDefault(item => item.GetType() == typeof(CommandType)));
                            }
                        }
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (SqlException ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
          
        }
    }
}
