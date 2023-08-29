using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class ProjectController
    {
        public static string AddNewProject(string user, string projectName, string projectSemester, string projectYear, string moduleCode)
        {
            using (var context = new XLookupReportingDB())
            {
                var newProject = new Project()
                {
                    Project_ID = Guid.NewGuid().ToString(),
                    ProjectName = projectName,
                    ProjectSemester = projectSemester,
                    ProjectYear = projectYear,
                    ModuleCode = moduleCode,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    User_ID = user

                };
                context.Projects.Add(newProject);
                context.SaveChanges();
                return newProject.Project_ID;
            }
        }
    }
}