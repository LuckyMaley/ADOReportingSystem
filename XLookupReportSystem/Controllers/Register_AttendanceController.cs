using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class Register_AttendanceController
    {
        public static void AddNewRegister_Attendance(string stuAttendance, string regID, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newRegisterAttendance = new Register_Attendance()
                {
                    Register_Attendance_ID = Guid.NewGuid().ToString(),
                    Attendance = stuAttendance,
                    Register_ID = regID,
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