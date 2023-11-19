using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XLookupReportSystem.Controllers;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XLookupReportingDB db1 = new XLookupReportingDB();
            string roleUserStaff = db1.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).StaffType;
            if (roleUserStaff == "Member")
            {
                Response.Redirect("~/Admin/DashBoard.aspx");
            }
        }

        protected void AddUserbtn_Click(object sender, EventArgs e)
        {
            if (TxtFirstName.Text != "" && txtSurname.Text != "" && CampusCBTxt.Text != "" && txtNewPassword.Text != "") {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = txtEmail.Text, Email = txtEmail.Text };
                IdentityResult result = manager.Create(user, txtNewPassword.Text);
                if (result.Succeeded)
                {
                    var result1 = manager.AddToRole(user.Id, RoleList.Text);
                    string staffID = StaffController.AddNewStaff(user.Id, TxtFirstName.Text, txtSurname.Text, RoleList.Text, txtEmail.Text, txtNewPassword.Text, CampusCBTxt.Text, DisciplineCBTxt.Text);
                    UserController.AddUser(user.Id, txtEmail.Text, txtNewPassword.Text, staffID);
                    Response.Redirect("~/Admin/Users.aspx");
                }
                else
                {
                    ErrorMessage.InnerText = result.Errors.FirstOrDefault();
                }
            }
            else
            {
                ErrorMessage.InnerText = "Please make sure that all fields are entered";
            }
        }
    }
}