using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class ModuleDataController
    {
        public static string AddNewModuleData(string studentNumber, string firstName, string surName, decimal mainExamMark, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newModuleData = new ModuleData()
                {
                    ModuleData_ID = Guid.NewGuid().ToString(),
                    StudentNumber = studentNumber,
                    FirstName = firstName,
                    Surname = surName,
                    ITSMainExamfinalMark = mainExamMark,
                    SuppMark = 0,
                    FinalMark = mainExamMark,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Project_ID = projID

                };
                context.ModuleDatas.Add(newModuleData);
                context.SaveChanges();
                return newModuleData.ModuleData_ID;
            }
        }

        public static void AddSuppModuleData(string studentNumber, decimal suppMark, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var data = context.ModuleDatas.SingleOrDefault(c => c.StudentNumber == studentNumber && c.Project_ID == projID);
                if (data != null)
                {
                    data.SuppMark = suppMark;
                    if (data.ITSMainExamfinalMark > data.SuppMark)
                    {
                        data.FinalMark = data.ITSMainExamfinalMark;
                    }
                    else if (data.ITSMainExamfinalMark < data.SuppMark)
                    {
                        data.FinalMark = data.SuppMark;
                    }
                    else if (data.FinalMark == 0 && data.SuppMark == 0)
                    {
                        data.FinalMark = 0;
                    }
                    context.SaveChanges();
                }
                
            }
        }

        public static List<ModuleData> GetModuleData(string id)
        {
            var _db = new XLookupReportingDB();
            var moduledata = _db.ModuleDatas.Where(c => c.Project_ID == id).ToList();
            return moduledata;
        }
    }
}