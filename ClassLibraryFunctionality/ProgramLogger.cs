using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    /// <summary>
    /// Represent the program Logger in the system
    /// </summary>
    public class ProgramLogger
    {
        private static readonly ILog _log = LogManager.GetLogger("Program");
        /// <summary>
        /// Allows to log a message in a ProgramLog file
        /// </summary>
        /// <param name="message">Message representing an state of a person reading<</param>
        public static void log(object message, string type)
        {
            XmlConfigurator.Configure();
            if(type == "info")
                _log.Info((String)message);
            if (type == "error")
                _log.Error((String)message);
            if (type == "warn")
                _log.Warn((String)message);
        }
    }
}
