using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Admin
{
    public partial class Admin_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    XLookupReportingDB db = new XLookupReportingDB();
                    string roleUserStaff = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).StaffType;
                    if (roleUserStaff == "Member")
                    {
                        usersLink.Attributes["style"] = "display:none;";
                    }
                    Label usernametb = (Label)LoginViewAdmin.FindControl("UsernameLoggedIn");
                    Label userRoleLB = (Label)LoginViewAdmin.FindControl("UserRolelb");
                    usernametb.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname + " " + db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname;
                    UserLoggedIn.Text = usernametb.Text;
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var role = manager.GetRoles(db.Users.SingleOrDefault(c => c.Email == Context.User.Identity.Name).User_ID);
                    foreach (var roleUser in role)
                    {
                        userRoleLB.Text = roleUser;
                    }

                    var userRow = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                    if (userRow.StaffImg != null)
                    {
                        byte[] imageData = userRow.StaffImg;
                        string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                        profileMasterImg.ImageUrl = "data:image/png;base64," + img;
                    }
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx", false);
                }
            }
            else
            {
                Label usernametb = (Label)LoginViewAdmin.FindControl("UsernameLoggedIn");
                Label userRoleLB = (Label)LoginViewAdmin.FindControl("UserRolelb");
                XLookupReportingDB db2 = new XLookupReportingDB();
                usernametb.Text = db2.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname + " " + db2.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname;
                UserLoggedIn.Text = usernametb.Text;
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var role = manager.GetRoles(db2.Users.SingleOrDefault(c => c.Email == Context.User.Identity.Name).User_ID);
                foreach (var roleUser in role)
                {
                    userRoleLB.Text = roleUser;
                }
                var userRow = db2.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                if (userRow.StaffImg != null)
                {
                    byte[] imageData = userRow.StaffImg;
                    string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                    profileMasterImg.ImageUrl = "data:image/png;base64," + img;
                }
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}