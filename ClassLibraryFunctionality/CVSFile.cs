using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;

namespace ClassLibraryFunctionality
{
    public class CVSFile
    {  
        public static void readFile()
        {
            int errors = 0, success = 0;
            List<Person> resultList = new List<Person>();
            using (CsvReader csv = new CsvReader(
            new StreamReader("\\..\\..\\Files\\ThreadData.csv"), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    string id = csv[0];
                    PersonLogger.log(id + " starts processing...");
                    string title = csv[1];
                    string firstName = csv[2];
                    string middleName = csv[3];
                    string lastName = csv[4];
                    string suffix = csv[5];
                    string addressLine1 = csv[6];
                    string addressLine2 = csv[7];
                    string city = csv[8];
                    string stateProvinceName = csv[9];
                    string countryRegionName = csv[10];
                    string postalCode = csv[11];
                    string phoneNumber = csv[12];
                    string stringBirthDate = csv[13];
                    string education = csv[14];
                    string occupation = csv[15];
                    string gender = csv[16];
                    string martialStatus = csv[17];
                    string stringHomeOwnerflag = csv[18];
                    string stringNumberCarsOwned = csv[19];
                    string stringNumberChildrenAtHome = csv[20];
                    string stringTotalChildren = csv[21];
                    string stringYearlyIncome = csv[22];

                    if (DateTime.TryParse(stringBirthDate, out DateTime birthDate))
                    {
                        if (int.TryParse(stringHomeOwnerflag, out int homeOwnerflag))
                        {
                            if (int.TryParse(stringNumberCarsOwned, out int numberCarsOwned))
                            {
                                if (int.TryParse(stringNumberChildrenAtHome, out int numberChildrenAtHome))
                                {
                                    if (int.TryParse(stringTotalChildren, out int totalChildren))
                                    {
                                        if (int.TryParse(stringYearlyIncome, out int yearlyIncome))
                                        {
                                            Person person = new Person(id, title, firstName, middleName, lastName, suffix, addressLine1, addressLine2, city, stateProvinceName, countryRegionName, postalCode, phoneNumber, birthDate, education, occupation, gender, martialStatus, homeOwnerflag, numberCarsOwned, numberChildrenAtHome, totalChildren, yearlyIncome);

                                            //Folder
                                            WriteFile.writePersonInformation(person);
                                            PersonLogger.log(id + " succesfully created file in People folder");

                                            //Db

                                            //Console
                                            ConsoleApplication.printIdAge(person);
                                            PersonLogger.log(id + " console print ok");

                                            PersonLogger.log(id + " successfully loaded");
                                            success++;
                                        }
                                        else
                                        {
                                            PersonLogger.log(id + " failed to load: YearlyIncome type");
                                            errors++;
                                        }
                                    }
                                    else
                                    {
                                        PersonLogger.log(id + " failed to load: TotalChildren type");
                                        errors++;
                                    }
                                }
                                else
                                {
                                    PersonLogger.log(id + " failed to load: NumberChildrenAtHome type");
                                    errors++;
                                }
                            }
                            else
                            {
                                PersonLogger.log(id + " failed to load: NumberCarsOwned type");
                                errors++;
                            }
                        }
                        else
                        {
                            PersonLogger.log(id + " failed to load: HomeOwnerFlag type");
                            errors++;
                        }
                    }
                    else
                    {
                        PersonLogger.log(id + " failed to load: BirthDate type");
                        errors++;
                    }
                    PersonLogger.log(id + " finished");
                    ProgramLogger.log("success: " + success + " errors: " + errors);
                }
            }
        }
    }
}
