using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class ProjectController
    {
        public static string AddNewProject(string user, string projectName, string projectSemester, string projcampus, string projectYear, string moduleCode)
        {
            using (var context = new XLookupReportingDB())
            {
                var newProject = new Project()
                {
                    Project_ID = Guid.NewGuid().ToString(),
                    ProjectName = projectName,
                    ProjectSemester = projectSemester,
                    ProjectYear = projectYear,
                    ProjectCampus = projcampus,
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

        public static void AddProjectFiles(string id, byte[] excelReg, byte[] excelMainExam, byte[] excelSupp, byte[] excelNegTermBeg, byte[] excelNegTermEnd)
        {
            var _db = new XLookupReportingDB();
            var projects = _db.Projects.Where(c => c.Project_ID == id);
            foreach(var proj in projects)
            {
                proj.ProjectExcelRegister = excelReg;
                proj.ProjectExcelMainExamModuleData = excelMainExam;
                proj.ProjectExcelSuppExamModuleData = excelSupp;
                proj.ProjectExcelNegativeTermDecisionsBeg = excelNegTermBeg;
                proj.ProjectExcelNegativeTermDecisionsEnd = excelNegTermEnd;
            }
            _db.SaveChanges();
        }

        public static List<Project> GetProjects(string id)
        {
            var _db = new XLookupReportingDB();
            var projects = _db.Projects.Where(c => c.User_ID == id).OrderByDescending(c => c.createdDate).ToList();
            return projects;
        }
    }
}