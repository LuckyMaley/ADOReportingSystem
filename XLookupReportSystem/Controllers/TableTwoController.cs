using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class TableTwoController
    {
        public static void AddNewTableTwo(int consultations, int si_students, int non_si_students, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newTableTwo = new TableTwo()
                {
                    TableTwo_ID = Guid.NewGuid().ToString(),
                    NoOfConsultations = consultations,
                    NoOfSI_Students = si_students,
                    NoOfNonSI_Students = non_si_students,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Project_ID = projID

                };
                context.TableTwos.Add(newTableTwo);
                context.SaveChanges();
            }
        }
    }
}