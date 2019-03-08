using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    public class DataBaseManagement
    {
        public static bool insertPerson(object person)
        {
            bool success = true;
            using (var context = new PeopleEntities())
            {
                context.People.Add((Person)person);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
