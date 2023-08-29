using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class RegisterController
    {
        public static string AddNewRegister(string registerName, string studentNumber, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newRegister = new Register()
                {
                    Register_ID = Guid.NewGuid().ToString(),
                    RegisterName = registerName,
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
    }
}