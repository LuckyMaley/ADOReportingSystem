using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class RegisterController
    {
        public static string AddNewRegister(string projRegID, string studentNumber, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newRegister = new Register()
                {
                    Register_ID = Guid.NewGuid().ToString(),
                    Project_Register_ID = projRegID,
                    StudentNumber = studentNumber,
                    Project_ID = projID,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now
                };
                context.Registers.Add(newRegister);
                context.SaveChanges();
                return newRegister.Register_ID;
            }
        }

        public static string AddNewRegisterList(string projRegID, string studentNumber, string projID, ref List<Register> reg)
        {
            var newRegister = new Register()
            {
                Register_ID = Guid.NewGuid().ToString(),
                Project_Register_ID = projRegID,
                StudentNumber = studentNumber,
                Project_ID = projID,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now
            };
            reg.Add(newRegister);
            return newRegister.Register_ID;
        }
    }
}