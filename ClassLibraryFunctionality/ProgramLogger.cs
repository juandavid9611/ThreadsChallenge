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
    public class ProgramLogger
    {
        private static readonly ILog _log = LogManager.GetLogger("Program");

        public static void log(object message)
        {
            XmlConfigurator.Configure();
            _log.Info((String)message);
        }
    }
}
