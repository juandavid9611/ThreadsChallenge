using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;

namespace ClassLibraryFunctionality
{

    public static class CVSFile
    {
        static int errors = 0, success = 0, warnings = 0;
        public static void readFile()
        {
            using (CsvReader csvR = new CsvReader(
            new StreamReader("\\..\\..\\Files\\ThreadData.csv"), true))
            {
                int fieldCount = csvR.FieldCount;
                string[] headers = csvR.GetFieldHeaders();
                Parallel.ForEach(csvR, processDataItem);
            }
        }
        private static void processDataItem(string[] csv)
        {
            string stringId = csv[0];
            Thread thread = new Thread(PersonLogger.log);
            thread.Start(stringId + " starts processing...");
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

            if (int.TryParse(stringId, out int id))
            {
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
                                        var person = new Person
                                        {
                                            Id = id,
                                            Title = title,
                                            FirstName = firstName,
                                            MiddleName = middleName,
                                            LastName = lastName,
                                            Suffix = suffix,
                                            AddressLine1 = addressLine1,
                                            AddressLine2 = addressLine2,
                                            City = city,
                                            StateProvinceName = stateProvinceName,
                                            CountryRegionName = countryRegionName,
                                            PostalCode = postalCode,
                                            PhoneNumber = phoneNumber,
                                            BirthDate = birthDate,
                                            Education = education,
                                            Occupation = occupation,
                                            Gender = gender,
                                            MaritalStatus = martialStatus,
                                            HomeOwnerflag = homeOwnerflag,
                                            NumberCarsOwned = numberCarsOwned,
                                            NumberChildrenAtHome = numberChildrenAtHome,
                                            TotalChildren = totalChildren,
                                            YearlyIncome = yearlyIncome
                                        };

                                        //Folder
                                        WriteFile.writePersonInformation(person);
                                        PersonLogger.log(id + " succesfully created file in People folder");

                                        //Db
                                        DataBaseManagement.insertPerson(person);
                                        PersonLogger.log(id + " succesfully insertion in People Database");
                                        //success++;
                                        if (DataBaseManagement.insertPerson(person))
                                        {
                                            PersonLogger.log(id + " succesfully insertion in People Database");
                                            success++;
                                        }
                                        else
                                        {
                                            warnings++;
                                            PersonLogger.log(id + " failed insertion in People Database");
                                            ProgramLogger.log(id + " duplicate entry");
                                        }

                                        //Console
                                        ConsoleApplication.printIdAge(person);
                                        PersonLogger.log(id + " console print ok");
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
            }
            else
            {
                PersonLogger.log(stringId + " failed to load: Id type");
                errors++;
            }
            PersonLogger.log(stringId + " finished");
            ProgramLogger.log("success: " + success + " errors: " + errors + " warnings: " + warnings);
        }
    }
}
