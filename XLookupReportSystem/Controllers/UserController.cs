using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class UserController
    {
        public static void AddUser(string user, string email, string passWord, string staffID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newUser = new User()
                {
                    User_ID = user,
                    Email = email,
                    Password = passWord,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Staff_ID = staffID
                };
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        public static string getUserID(string email)
        {
            XLookupReportingDB db = new Models.XLookupReportingDB();
            return db.Users.SingleOrDefault(c => c.Email == email).User_ID;
        }

        public static void UpdateUserPassword(string user, string pass)
        {
            XLookupReportingDB db = new Models.XLookupReportingDB();
            var dbStaff = db.Users.Where(staffmember => staffmember.Email == user);
            foreach (var row in dbStaff)
            {
                row.Password = pass;
            }
            db.SaveChanges();
        }

        public static void RemoveUser(string userID)
        {
            XLookupReportingDB db = new Models.XLookupReportingDB();

            foreach (var proj in db.Projects.Where(c => c.User_ID == userID))
            {
                string projectID = proj.Project_ID;



                foreach (var row in db.Register_Attendances.Where(c => c.Project_ID == projectID))
                {
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
            }


            User userToRemove = db.Users.Find(userID);
            Staff staffToRemove = db.Staffs.Find(userToRemove.Staff_ID);
            if(userToRemove != null)
            {
                db.Users.Remove(userToRemove);
            }

            
            if(staffToRemove != null)
            {
                db.Staffs.Remove(staffToRemove);
            }

            db.SaveChanges();
        }

    }
}