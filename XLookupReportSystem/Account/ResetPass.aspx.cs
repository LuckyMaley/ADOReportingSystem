using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XLookupReportSystem.Controllers;

namespace XLookupReportSystem.Account
{
    public partial class ResetPass : System.Web.UI.Page
    {
        protected string StatusMessage
        {
            get;
            private set;
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            if (code != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var user = manager.FindByName(Email.Text);
                if (user == null)
                {
                    FailureText.Text = "No user found";
                    return;
                }
                var result = manager.ResetPassword(user.Id, code, Password.Text);
                if (result.Succeeded)
                {
                    UserController.UpdateUserPassword(Email.Text, Password.Text);
                    Response.Redirect("~/Account/Confirmation");
                    return;
                }
                FailureText.Text = result.Errors.FirstOrDefault();
                return;
            }

            FailureText.Text = "An error has occurred";
        }
    }
}