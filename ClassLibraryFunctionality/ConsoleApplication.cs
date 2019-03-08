using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    public class ConsoleApplication
    {
        public static void printIdAge(object person)
        {
            DateTime localDate = DateTime.Now;

            Console.WriteLine("Person Id: " + ((Person)person).Id + " " + CalculateYourAge(((Person)person).BirthDate));
        }

        private static string CalculateYourAge(DateTime dob)
        {
            var now = DateTime.Now;
            var years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
            var pastYearDate = dob.AddYears(years);
            var months = 0;
            for (var i = 1; i <= 12; i++)
            {
                if (pastYearDate.AddMonths(i) == now)
                {
                    months = i;
                    break;
                }

                if (pastYearDate.AddMonths(i) < now)
                    continue;
                months = i - 1;
                break;
            }

            var days = now.Subtract(pastYearDate.AddMonths(months)).Days;
            var hours = now.Subtract(pastYearDate).Hours;
            var seconds = now.Subtract(pastYearDate).Seconds;
            return string.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)", years, months, days, hours, seconds);
        }
    }
}
