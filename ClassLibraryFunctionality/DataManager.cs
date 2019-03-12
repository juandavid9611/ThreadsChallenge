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
    /// <summary>
    /// Represent an instance of the program reading data and performing different features
    /// </summary>
    public class DataManager
    {
        public static int errors = 0, success = 0, warnings = 0, count = 0;
        public static bool[] features { get; set; }
        /// <summary>
        /// Read csvFile and parallelize the work for the records
        /// </summary>
        public static void readFile()
        {
            using (CsvReader csvR = new CsvReader(
            new StreamReader("\\..\\..\\Files\\ThreadData.csv"), true))
            {
                int fieldCount = csvR.FieldCount;
                string[] headers = csvR.GetFieldHeaders();
                Parallel.ForEach(csvR, processDataItem);
                //Thread thread = Thread.CurrentThread;
                //thread.Join();
                Thread.Sleep(3000);
                if (features[2])
                    LoggersManager.log("success: " + success + " errors: " + errors + " warnings: " + warnings,"program", "info");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Process each data Item depending on the features were selected
        /// </summary>
        /// <param name="csv">Represents a data record from a CSV file</param>
        private static void processDataItem(string[] csv)
        {
            string stringId = csv[0];
            if(features[3])
                LoggersManager.log(stringId + " starts processing...", "person", "info");
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

            if (!int.TryParse(stringId, out int id))
            {
                if (features[3])
                    LoggersManager.log(stringId + " failed to load: Id type", "person", "error");
                if (features[2])
                    LoggersManager.log(id + " presents illegal Type", "program", "error");
                errors++;
                return;
            }
            if (!DateTime.TryParse(stringBirthDate, out DateTime birthDate))
            {
                if (features[3])
                    LoggersManager.log(id + " failed to load: BirthDate type", "person", "error");
                if (features[2])
                    LoggersManager.log(id + " presents illegal Type", "program", "error");
                errors++;
                return;
            }
            if (!int.TryParse(stringHomeOwnerflag, out int homeOwnerflag))
            {
                if (features[3])
                    LoggersManager.log(id + " failed to load: HomeOwnerFlag type", "person", "error");
                if (features[2])
                    LoggersManager.log(id + " presents illegal Type", "program", "error");
                errors++;
                return;
            }
            if (!int.TryParse(stringNumberCarsOwned, out int numberCarsOwned))
            {
                if (features[3])
                    LoggersManager.log(id + " failed to load: NumberCarsOwned type", "person", "error");
                if (features[2])
                    LoggersManager.log(id + " presents illegal Type", "program", "error");
                errors++;
                return;
            }
            if (!int.TryParse(stringNumberChildrenAtHome, out int numberChildrenAtHome))
            {
                if (features[3])
                    LoggersManager.log(id + " failed to load: NumberChildrenAtHome type", "person", "error");
                if (features[2])
                    LoggersManager.log(id + " presents illegal Type", "program", "error");
                errors++;
                return;
            }
            if (!int.TryParse(stringTotalChildren, out int totalChildren))
            {
                if (features[3])
                    LoggersManager.log(id + " failed to load: TotalChildren type", "person", "error");
                if (features[2])
                    LoggersManager.log(id + " presents illegal Type", "program", "error");
                errors++;
                return;
            }
            if (!int.TryParse(stringYearlyIncome, out int yearlyIncome))
            {
                if (features[3])
                    LoggersManager.log(id + " failed to load: YearlyIncome type", "person", "error");
                if (features[2])
                    LoggersManager.log(id + " presents illegal Type", "program", "error");
                errors++;
                return;
            }
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
            executeFunctionalities(person);
            if (features[2])
                LoggersManager.log(++count + " records read from CSV file", "program", "info");

        }
        /// <summary>
        /// Execute each functionality to a person depending user input  
        /// </summary>
        /// <param name="person"></param>
        private static void executeFunctionalities(Person person)
        {
            //Folder
            if (features[0])
            {
                Thread fileThread = new Thread(WriteFileManager.writePersonInformation);
                fileThread.Start(person);
                if (features[3])
                    LoggersManager.log(person.Id + " succesfully created file in People folder", "person", "info");
            }
            //Db
            if (features[1])
            {
                Thread dataBaseThread = new Thread(DataBaseManagement.insertPerson);
                dataBaseThread.Start(person);
            }

            //Console
            if (features[4])
            {
                Thread consoleThread = new Thread(ConsoleDisplay.printIdAge);
                consoleThread.Start(person);
                if (features[3])
                    LoggersManager.log(person.Id + " console print ok", "person", "info");
            }
            if (features[3])
                LoggersManager.log(person.Id + " finished", "person", "info");
        }
    }
}
