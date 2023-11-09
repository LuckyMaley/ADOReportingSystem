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
    }
}