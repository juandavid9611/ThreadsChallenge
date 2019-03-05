using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    public class Person
    {
        public string id { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string stateProvinceName { get; set; }
        public string countryRegionName { get; set; }
        public string postalCode { get; set; }
        public string phoneNumber { get; set; }
        public DateTime birthDate { get; set; }
        public string education { get; set; }
        public string occupation { get; set; }
        public string gender { get; set; }
        public string martialStatus { get; set; }
        public int homeOwnerflag { get; set; }
        public int numberCarsOwned { get; set; }
        public int numberChildrenAtHome { get; set; }
        public int yearlyIncome { get; set; }

        public Person(string id, string title, string firstName, string middleName, string lastName, string suffix, string addressLine1, string addressLine2, string city, string stateProvinceName, string countryRegionName, string postalCode, string phoneNumber, DateTime birthDate, string education, string occupation, string gender, string martialStatus, int homeOwnerflag, int numberCarsOwned, int numberChildrenAtHome, int yearlyIncome)
        {
            this.id = id;
            this.title = title;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.suffix = suffix;
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.city = city;
            this.stateProvinceName = stateProvinceName;
            this.countryRegionName = countryRegionName;
            this.postalCode = postalCode;
            this.phoneNumber = phoneNumber;
            this.birthDate = birthDate;
            this.education = education;
            this.occupation = occupation;
            this.gender = gender;
            this.martialStatus = martialStatus;
            this.homeOwnerflag = homeOwnerflag;
            this.numberCarsOwned = numberCarsOwned;
            this.numberChildrenAtHome = numberChildrenAtHome;
            this.yearlyIncome = yearlyIncome;
        }
    }
}
