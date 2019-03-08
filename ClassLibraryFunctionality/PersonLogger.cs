using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    class PersonLogger
    {
        private static readonly ILog _log = LogManager.GetLogger("Person");

        public static void log(object message)
        {
            XmlConfigurator.Configure();
            _log.Info((string)message);
        }
    }
}
