using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class StaffController
    {
        public static void AddStaff(string user, string firstName, string lastName, string staffType, string email, string passWord, string campus)
        {
            using (var context = new XLookupReportingDB())
            {
                var newStaff = new Staff()
                {
                    Staff_ID = user,
                    Firstname = firstName,
                    Surname = lastName,
                    StaffType = staffType,
                    Campus = campus,
                    EmailAdress = email,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now

                };
                context.Staffs.Add(newStaff);
                context.SaveChanges();
            }
        }

        public static string AddNewStaff(string user, string firstName, string lastName, string staffType, string email, string passWord, string campus)
        {
            using (var context = new XLookupReportingDB())
            {
                var newStaff = new Staff()
                {
                    Staff_ID = Guid.NewGuid().ToString(),
                    Firstname = firstName,
                    Surname = lastName,
                    StaffType = staffType,
                    EmailAdress = email,
                    Campus = campus,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now

                };
                context.Staffs.Add(newStaff);
                context.SaveChanges();
                return newStaff.Staff_ID;
            }
        }


        public static void DefaultStaff(ApplicationUserManager manager)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (roleManager.Roles.Count() == 0)
            {
                string usertype = "";

                string userEmail = "ADOLeader@gmail.com";
                var user = new ApplicationUser() { UserName = userEmail, Email = userEmail };

                roleManager.Create(new IdentityRole { Name = "Owner" });
                roleManager.Create(new IdentityRole { Name = "Member" });
                usertype = "Owner";
                string userPass = "Owner@123456";
                IdentityResult result = manager.Create(user, userPass);
                if (result.Succeeded)
                {
                    string staffID = StaffController.AddNewStaff(user.Id.ToString(), "Admin", "Owner", usertype, user.Email, userPass, "Westville");
                    UserController.AddUser(user.Id.ToString(), user.Email, userPass, staffID);
                    var result1 = manager.AddToRole(user.Id, usertype);
                    string code = manager.GenerateEmailConfirmationToken(user.Id);
                    string userId = user.Id;
                    if (code != null && userId != null)
                    {

                        var result2 = manager.ConfirmEmail(userId, code);
                    }
                }
            }
        }

        public static void UpdateStaffDetails(string user, string firstName, string lastName, string campus)
        {
            XLookupReportingDB db = new Models.XLookupReportingDB();
            var dbStaff = db.Staffs.Where(staffmember => staffmember.EmailAdress == user);
            foreach (var member in dbStaff)
            {
                member.Firstname = firstName;
                member.Surname = lastName;
                member.Campus = campus;
                member.modifiedDate = DateTime.Now;
            }
            db.SaveChanges();
        }

        public static void UpdateStaffImg(string user, byte[] imageStaff)
        {
            XLookupReportingDB db = new Models.XLookupReportingDB();
            var dbStaff = db.Staffs.Where(staffmember => staffmember.EmailAdress == user);
            foreach (var row in dbStaff)
            {
                row.StaffImg = imageStaff;
                row.modifiedDate = DateTime.Now;
            }
            db.SaveChanges();
        }

        public static void RemoveStaffImg(string user)
        {
            XLookupReportingDB db = new Models.XLookupReportingDB();
            var dbStaff = db.Staffs.Where(staffmember => staffmember.EmailAdress == user);
            foreach (var row in dbStaff)
            {
                
                row.StaffImg = null;
                row.modifiedDate = DateTime.Now;
            }
            db.SaveChanges();
        }

    }
}