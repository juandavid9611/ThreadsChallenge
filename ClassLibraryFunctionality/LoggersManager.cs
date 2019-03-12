using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    /// <summary>
    /// Represent the person Logger in the system
    /// </summary>
    public class LoggersManager
    {
        private static readonly ILog person_log = LogManager.GetLogger("Person");
        private static readonly ILog program_log = LogManager.GetLogger("Program");

        /// <summary>
        /// Allows to log message in a specific Logger with Log4net
        /// </summary>
        /// <param name="message">Message to display in a log</param>
        /// <param name="target">Specify the specific logger to perform the log</param>
        /// <param name="type">Specify the level of the log</param>
        public static void log(object message, string target, string type)
        {
            XmlConfigurator.Configure();
            if(target == "person")
            {
                if (type == "info")
                    person_log.Info((String)message);
                if (type == "error")
                    person_log.Error((String)message);
                if (type == "warn")
                    person_log.Warn((String)message);
            }
            if (target == "program")
            {
                if (type == "info")
                {
                    program_log.Info((String)message);
                }
                if (type == "error")
                {
                    program_log.Error((String)message);
                }
                if (type == "warn")
                {
                    program_log.Warn((String)message);
                }
            }
        }
    }
}
