using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    public class WriteFileManager
    {
        /// <summary>
        /// Write new file with the information of a person in the path C:\\Files\\People. If the path doesn't exist, it will be created
        /// </summary>
        /// <param name="person">Represents the person information</param>
        public static void writePersonInformation(Object person) {         
            Directory.CreateDirectory("\\..\\..\\Files\\People\\");
            File.WriteAllText("\\..\\..\\Files\\People\\" + ((Person)person).Id + ".txt", ((Person)person).ToString());
        }
    }
}
