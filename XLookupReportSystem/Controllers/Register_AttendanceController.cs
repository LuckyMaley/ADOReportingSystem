using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class Register_AttendanceController
    {
        public static void AddNewRegister_Attendance(string moduleDataID, string projRegID, int stuAttendance,  string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newRegisterAttendance = new Register_Attendance()
                {
                    Register_Attendance_ID = Guid.NewGuid().ToString(),
                    ModuleData_ID = moduleDataID,
                    Project_Register_ID = projRegID,
                    Attendance = stuAttendance,
                    Project_ID = projID,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now
                };
                context.Register_Attendances.Add(newRegisterAttendance);
                context.SaveChanges();
                
            }
        }
    }
}