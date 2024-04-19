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

        public static void RemoveProject(string projectID)
        {
            XLookupReportingDB db = new Models.XLookupReportingDB();
            foreach (var row in db.Register_Attendances.Where(c => c.Project_ID == projectID)) {
                Register_Attendance regAttendance = db.Register_Attendances.Find(row.Register_Attendance_ID);
                if (regAttendance != null)
                {
                    db.Register_Attendances.Remove(regAttendance); 
                }
            }

            foreach (var regRow in db.Registers.Where(c => c.Project_ID == projectID))
            {
                Register reg = db.Registers.Find(regRow.Register_ID);
                if (reg != null)
                {
                    db.Registers.Remove(reg);
                }
            }

            foreach (var projRegRow in db.Project_Registers.Where(c => c.Project_ID == projectID))
            {
                Project_Register reg = db.Project_Registers.Find(projRegRow.Project_Register_ID);
                if (reg != null)
                {
                    db.Project_Registers.Remove(reg);
                }
            }

            foreach (var row in db.NegativeTermDecisionBeginnings.Where(c => c.Project_ID == projectID))
            {
                NegativeTermDecisionsBeginning reg = db.NegativeTermDecisionBeginnings.Find(row.NegativeTermDecisionsBeg_ID);
                if (reg != null)
                {
                    db.NegativeTermDecisionBeginnings.Remove(reg);
                }
            }

            foreach (var row in db.NegativeTermDecisionEnds.Where(c => c.Project_ID == projectID))
            {
                NegativeTermDecisionsEnd reg = db.NegativeTermDecisionEnds.Find(row.NegativeTermDecisionsEnd_ID);
                if (reg != null)
                {
                    db.NegativeTermDecisionEnds.Remove(reg);
                }
            }

            foreach (var row in db.NegativeTermDecisionEnds.Where(c => c.Project_ID == projectID))
            {
                NegativeTermDecisionsEnd reg = db.NegativeTermDecisionEnds.Find(row.NegativeTermDecisionsEnd_ID);
                if (reg != null)
                {
                    db.NegativeTermDecisionEnds.Remove(reg);
                }
            }

            foreach (var row in db.TableOnes.Where(c => c.Project_ID == projectID))
            {
                TableOne reg = db.TableOnes.Find(row.TableOne_ID);
                if (reg != null)
                {
                    db.TableOnes.Remove(reg);
                }
            }

            foreach (var row in db.TableOneOveralls.Where(c => c.Project_ID == projectID))
            {
                TableOneOverall reg = db.TableOneOveralls.Find(row.TableOneOverall_ID);
                if (reg != null)
                {
                    db.TableOneOveralls.Remove(reg);
                }
            }

            foreach (var row in db.TableTwos.Where(c => c.Project_ID == projectID))
            {
                TableTwo reg = db.TableTwos.Find(row.TableTwo_ID);
                if (reg != null)
                {
                    db.TableTwos.Remove(reg);
                }
            }

            foreach (var row in db.TableThrees.Where(c => c.Project_ID == projectID))
            {
                TableThree reg = db.TableThrees.Find(row.TableThree_ID);
                if (reg != null)
                {
                    db.TableThrees.Remove(reg);
                }
            }

            foreach (var row in db.TermDecisionBeginnings.Where(c => c.Project_ID == projectID))
            {
                TermDecisionsBeginning reg = db.TermDecisionBeginnings.Find(row.TermDecisionsBeginning_ID);
                if (reg != null)
                {
                    db.TermDecisionBeginnings.Remove(reg);
                }
            }

            foreach (var row in db.TermDecisionEnds.Where(c => c.Project_ID == projectID))
            {
                TermDecisionsEnd reg = db.TermDecisionEnds.Find(row.TermDecisionsEnd_ID);
                if (reg != null)
                {
                    db.TermDecisionEnds.Remove(reg);
                }
            }

            foreach (var row in db.ModuleDatas.Where(c => c.Project_ID == projectID))
            {
                ModuleData reg = db.ModuleDatas.Find(row.ModuleData_ID);
                if (reg != null)
                {
                    db.ModuleDatas.Remove(reg);
                }
            }

            foreach (var row in db.Projects.Where(c => c.Project_ID == projectID))
            {
                Project projToRemove = db.Projects.Find(row.Project_ID);
                if (projToRemove != null)
                {
                    db.Projects.Remove(projToRemove);
                }
            }
            db.SaveChanges();
        }
    }
}