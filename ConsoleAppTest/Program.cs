using ClassLibraryFunctionality;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramLogger.log("Program status: starts");
            CVSFile.readFile();
            ProgramLogger.log("Program status: ends");
        }
    }
}
