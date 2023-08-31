using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class TableOneOverallController
    {
        public static void AddNewTableOneOverall(int noOfOverallStudents, int noOfOverallStudentsPassed, decimal overall_Students_Pass_Rate, decimal averageOverall_Students_Pass_Rate, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newTableOneOverall = new TableOneOverall()
                {
                    TableOneOverall_ID = Guid.NewGuid().ToString(),
                    NoOfOverallStudents = noOfOverallStudents,
                    NoOfOverallStudentsPassed = noOfOverallStudentsPassed,
                    Overall_Students_Pass_Rate = overall_Students_Pass_Rate,
                    AverageOverall_Students_Pass_Rate = averageOverall_Students_Pass_Rate,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Project_ID = projID

                };
                context.TableOneOveralls.Add(newTableOneOverall);
                context.SaveChanges();
            }
        }
    }
}