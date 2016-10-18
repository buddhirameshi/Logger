using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{

    /// <summary>
    /// Logger factory will create the required logger based on the inputs for the requested consumer
    /// </summary>
    public class LoggerFactory
    {
        public enum LoggerMode { TextLogger, EventLogger, DBLogger }; //enum with the available loggers
        ILogger logger;


        /// <summary>
        /// This will return the ILogger interface and consumer does not have to know about the actual logger implementation
        /// </summary>
        /// <param name="loggerMode"></param>
        /// <returns></returns>
        public ILogger GetLogger(LoggerMode loggerMode) 
        {
            switch (loggerMode)
            {
                case LoggerMode.EventLogger:
                    {
                        logger = EventLogger.GetLogger();
                        break;
                    }
                default:
                    {
                        logger = TextLogger.GetLogger();
                        break;

                    }
            }
            return logger;
        }
    }
}
