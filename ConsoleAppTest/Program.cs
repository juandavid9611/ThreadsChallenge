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
        /// <summary>
        /// Execution of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool[] features = displayMenu();
            DataManager.features = features;
            LoggersManager.log("Program status: starts", "program", "info");
            DataManager.readFile();
            LoggersManager.log("Program status: ends", "program", "info");
        }
        /// <summary>
        /// Display menu console showing features to select 
        /// </summary>
        /// <returns>Returns a bool[] representing which features were selected</returns>
        private static bool[] displayMenu()
        {
            bool[] features = new bool[5];
            string selection;
            Console.WriteLine("Select features you want typing their numbers separate eachone with a space Ex.(0 1 2 3 4 5 6)");
            Console.WriteLine("0 - Nothing");
            Console.WriteLine("1- Create one file per person with person's information");
            Console.WriteLine("2- Insert person's information in DB");
            Console.WriteLine("3- Log the status of the application");
            Console.WriteLine("4- Log the status of each person processed");
            Console.WriteLine("5- Print id and age of the person in console");
            Console.WriteLine("6- All features");
            selection = Console.ReadLine();
            string[] each = selection.Split(' ');
            foreach(string inp in each)
            {
                if(int.TryParse(inp, out int opt))
                {
                    if (opt == 0)
                        return features;
                    else if (opt == 6)
                        for (int i = 0; i < 5; i++)
                        {
                            features[i] = true;
                        }
                    else
                    {
                        features[opt - 1] = true;
                    }
                }
            }
            return features;
        }
    }
}
