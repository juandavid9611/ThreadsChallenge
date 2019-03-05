using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    public class CVSFile
    {
        public static List<Person> readFile()
        {
            List<Person> resultList = new List<Person>();
            var reader = new StreamReader(File.OpenRead(".\\Files\\ThreadData.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                string id = values[0];
                string title = values[1];
                string firstName = values[2];
                string middleName = values[3];
                string lastName = values[4];
                string suffix = values[5];
                string addressLine1 = values[6];
                string addressLine2 = values[7];
                string city = values[8];
                string stateProvinceName = values[9];
                string countryRegionName = values[10];
                string postalCode = values[11];
                string phoneNumber = values[12];
                string stringBirthDate = values[13];
                string education = values[14];
                string occupation = values[15];
                string gender = values[16];
                string martialStatus = values[17];
                string stringHomeOwnerflag = values[18];
                string stringNumberCarsOwned = values[19];
                string stringNumberChildrenAtHome = values[20];
                string stringYearlyIncome = values[21];

                if (DateTime.TryParse(stringBirthDate, out DateTime birthDate))
                {
                    if (int.TryParse(stringHomeOwnerflag, out int homeOwnerflag))
                    {
                        if (int.TryParse(stringNumberCarsOwned, out int numberCarsOwned))
                        {
                            if (int.TryParse(stringNumberChildrenAtHome, out int numberChildrenAtHome))
                            {
                                if (int.TryParse(stringYearlyIncome, out int yearlyIncome))
                                {
                                    resultList.Add(new Person(id, title, firstName, middleName, lastName, suffix, addressLine1, addressLine2, city, stateProvinceName, countryRegionName, postalCode, phoneNumber, birthDate, education, occupation, gender, martialStatus, homeOwnerflag, numberCarsOwned, numberChildrenAtHome, yearlyIncome));
                                }
                                else
                                {
                                    // LOG YEARLYINCOME FAILED
                                }
                            }
                            else
                            {
                                // LOG NUMBERCHILDRENATHOME FAILED
                            }
                        }
                        else
                        {
                            // LOG NUMBERCARSOWNED FAILED
                        }
                    }
                    else
                    {
                        // LOG HOMEOWNERFLAG FAILED
                    }
                }
                else
                {
                    // LOG DATETIME FAILED
                }
            }
            return resultList;
        }
    }
}
