using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XLookupReportSystem.Controllers;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Admin
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                XLookupReportingDB db = new XLookupReportingDB();
                username.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Firstname + " " + db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Surname;
                
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var role = manager.GetRoles(db.Users.SingleOrDefault(c => c.Email == Context.User.Identity.Name).User_ID);
                foreach (var roleUser in role)
                {
                    usertype.Text = roleUser;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Firstname != null)
                {
                    lbFirstName.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Firstname;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Surname != null)
                {
                    lbSurname.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Surname;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Campus != null)
                {
                    lbCampus.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Campus;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Firstname != null)
                {
                    TxtFirstName.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Firstname;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Surname != null)
                {
                    txtSurname.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Surname;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Campus != null)
                {
                    txtCampus.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Campus;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).EmailAdress != null)
                {
                    txtEmail.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).EmailAdress;
                }
                
                string selectedTab = Request.QueryString["tab"];

                
            }
            else
            {
                //if (fileUploadControl.HasFile)
                //{
                //    string fileName = Path.GetFileName(fileUploadControl.FileName);
                //    // Process the uploaded file, e.g., save it to the server or perform other operations.
                //    // You can access the file using fileUploadControl.FileContent, and fileName contains the file name.

                //    string script = "<script>triggerSpecificAnchorClick('" + "EditAnchor" + "');</script>";
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
                //}
                ////else
                //{
                //    string script = "<script>triggerSpecificAnchorClick('" + "EditAnchor" + "');</script>";
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
                //}
            }
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            StaffController.UpdateStaffDetails(Context.User.Identity.Name, TxtFirstName.Text, txtSurname.Text, txtCampus.Text);
            ErrorMessage.InnerText = "Details Updated Successfully";
            ErrorMessage.Visible = true;
            XLookupReportingDB db = new XLookupReportingDB();
            if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Firstname != null)
            {
                lbFirstName.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Firstname;
            }
            if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Surname != null)
            {
                lbSurname.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Surname;
            }
            if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Campus != null)
            {
                lbCampus.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Campus;
            }
            string script = "<script>triggerSpecificAnchorClick('" + "EditAnchor" + "');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
        }

        protected void btnProfileSettings_Click(object sender, EventArgs e)
        {

        }

        protected void ProfileChangePassword_Click(object sender, EventArgs e)
        {
            string script = "<script>triggerSpecificAnchorClick('"+ "ChangePassAnchor" + "');</script>";
            if (txtNewPassword.Text == txtRenewPassword.Text) {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var user = manager.FindByName(Context.User.Identity.Name);
                if (user == null)
                {
                    ErrorMessagePass.InnerText = "No user found";
                    ErrorMessagePass.Visible = true;
                    //Response.Redirect("~/Admin/Profile.aspx#profile-change-password");

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
                    return;
                }
                var result = manager.ChangePassword(user.Id, txtCurrentPassword.Text, txtNewPassword.Text);
                if (result.Succeeded)
                {
                    UserController.UpdateUserPassword(Context.User.Identity.Name, txtNewPassword.Text);
                    ErrorMessagePass.InnerText = "Password Changed Successfully";
                    ErrorMessagePass.Visible = true;
                    // Response.Redirect("~/Admin/Profile.aspx#profile-change-password");

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
                    return;
                }
                ErrorMessagePass.InnerText = result.Errors.FirstOrDefault();
                ErrorMessagePass.Visible = true;
                // Response.Redirect("~/Admin/Profile.aspx#profile-change-password");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
                return;
            }
            else
            {
                ErrorMessagePass.InnerText = "The new and confirmation Passwords do not match";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
            }
        }

        protected void uploadbtn_Click(object sender, EventArgs e)
        {
            //string script = "<script>triggerSpecificAnchorClick('" + "EditAnchor" + "');</script>";

            //if (fileUploadControl.HasFile)
            //{
            //    string fileName = Path.GetFileName(fileUploadControl.FileName);
            //    //string uploadPath = Server.MapPath("~/Uploads/") + fileName;
            //    //fileUploadControl.SaveAs(uploadPath);

            //    // Process the uploaded file, e.g., save it to the server or perform other operations.
            //    // You can access the file using fileUploadControl.FileContent, and fileName contains the file name.

            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
            //}
        }
    }
}