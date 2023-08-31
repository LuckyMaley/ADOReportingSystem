using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class Project_RegisterController
    {
        public static string AddNewProject_Register(string registerName, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newProject_Register = new Project_Register()
                {
                    Project_Register_ID = Guid.NewGuid().ToString(),
                    RegisterName = registerName,
                    Project_ID = projID,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now
                };
                context.Project_Registers.Add(newProject_Register);
                context.SaveChanges();
                return newProject_Register.Project_Register_ID;
            }
        }
    }
}