using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{

    /// <summary>
    /// For event logs
    /// </summary>
    public class EventLogger : ILogger
    {
        //private static EventLogger oneLogger;

        ///// <summary>
        ///// private constructor helps to prevents the instantiation of the class
        ///// </summary>
        //private EventLogger()
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
        //        oneLogger = new EventLogger();
        //    }
        //    return oneLogger;
        //}


        /// <summary>
        /// Write the message to the Event log
        /// </summary>
        /// <param name="source"></param>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="extraParams"></param>
        public void WiteLog(string source, string log, string message, object[] extraParams )
        {
            EventLogEntryType entryType = EventLogEntryType.Information; //Set a default value to EventLogEntryType
            try
            {
                if(extraParams!=null &&extraParams.Length>0) //if the extra parameters array contains values
                {
                   if(extraParams.Any(item => item.GetType() == typeof(EventLogEntryType))) //Check for the EventLogEntryType input parameter
                    {
                        entryType = (EventLogEntryType)(extraParams.SingleOrDefault(item => item.GetType() == typeof(EventLogEntryType)));
                    }

                }
                EventLog.WriteEntry(source, message, entryType);
            }
            catch (SecurityException ex)
            {
                throw new SecurityException(ex.Message, ex);
            }
        }
    }
}
