using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFunctionality
{
    /// <summary>
    /// AlloWs interaction with a local Database
    /// </summary>
    public class DataBaseManagement
    {
        /// <summary>
        /// Insert person record in a local Database using Entityframework
        /// </summary>
        /// <param name="person">Represents the person information</param>
        public static void insertPerson(object person)
        {
            using (var context = new PeopleEntities())
            {
                context.People.Add((Person)person);
                try
                {
                    context.SaveChanges();
                    LoggersManager.log(((Person)person).Id + " succesfully insertion in People Database", "person", "info");
                    DataManager.success++;
                }
                catch (DbUpdateException ex)
                {
                    DataManager.warnings++;
                    if (DataManager.features[3])
                        LoggersManager.log(((Person)person).Id + " failed insertion in People Database", "person", "error");
                    if (DataManager.features[2])
                        LoggersManager.log(((Person)person).Id + " duplicate entry", "program", "warn");
                }
            }
        }
    }
}
