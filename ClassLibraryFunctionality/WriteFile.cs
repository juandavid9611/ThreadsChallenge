using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    public class WriteFile
    {
        public static void writePersonInformation(Person person) {         
            Directory.CreateDirectory("\\..\\..\\Files\\People\\");
            File.WriteAllText("\\..\\..\\Files\\People\\" + person.id + ".txt", person.toString());
        }
    }
}
