using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Outlook = Microsoft.Office.Interop.Outlook;
using Outlook = NetOffice.OutlookApi;
using XLookupReportSystem.Controllers;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Account
{
    public partial class ForgotPassword1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
               
                // Validate the user's email address
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(Email.Text);
                if (user == null) //|| !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "The user either does not exist or is not confirmed.";
                    ErrorMessage.Visible = true;
                    return;
                }
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send email with the code and the redirect to reset password page
                string code = manager.GeneratePasswordResetToken(user.Id);
                string callbackUrl = IdentityHelper.GetResetPassRedirectUrl(code, Request);
                bool result = EmailController.EmailSendForgot(Email.Text, "Reset Password", "Please reset your password by clicking <a href=\'" + callbackUrl + "\"'here</a>.");
             
                if (result == false)
                {
                    FailureText.Text = "An error occurred";
                    ErrorMessage.Visible = true;
                }
                else
                {
                    loginForm.Visible = false;
                    DisplayEmail.Visible = true;
                }
            }
        }
    }
}