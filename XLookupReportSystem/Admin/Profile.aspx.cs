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
                username.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname + " " + db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname;
                
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var role = manager.GetRoles(db.Users.SingleOrDefault(c => c.Email == Context.User.Identity.Name).User_ID);
                foreach (var roleUser in role)
                {
                    usertype.Text = roleUser;
                }
                var userRow = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                if (userRow.StaffImg != null)
                {
                    byte[] imageData = userRow.StaffImg;
                    string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                    ProfileImg.ImageUrl = "data:image/png;base64," + img;
                    profileEditImg.ImageUrl = "data:image/png;base64," + img;
                }
                else
                {
                    LinkButtonRemoveImg.Visible = false;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname != null)
                {
                    lbFirstName.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname != null)
                {
                    lbSurname.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Campus != null)
                {
                    lbCampus.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Campus;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname != null)
                {
                    TxtFirstName.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname;
                }
                if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname != null)
                {
                    txtSurname.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname;
                }
                
                XLookupReportingDB dbstaffpic = new XLookupReportingDB();
                var userRow1 = dbstaffpic.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                if (userRow1.Campus != null)
                {
                    for (int i = 0; i < CampusCBTxt.Items.Count; i++)
                    {
                        if (CampusCBTxt.Items[i].Text == userRow1.Campus)
                        {
                            CampusCBTxt.SelectedIndex = i;
                        }
                    }
                }
                
                if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).EmailAddress != null)
                {
                    LbEmailAddress.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).EmailAddress;
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

            StaffController.UpdateStaffDetails(Context.User.Identity.Name, TxtFirstName.Text, txtSurname.Text, CampusCBTxt.Text);
            XLookupReportingDB db = new XLookupReportingDB();
            username.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname + " " + db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var role = manager.GetRoles(db.Users.SingleOrDefault(c => c.Email == Context.User.Identity.Name).User_ID);
            foreach (var roleUser in role)
            {
                usertype.Text = roleUser;
            }
            
            ErrorMessage.InnerText = "Details Updated Successfully";
            ErrorMessage.Visible = true;
            if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname != null)
            {
                lbFirstName.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname;
            }
            if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname != null)
            {
                lbSurname.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname;
            }
            if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Campus != null)
            {
                lbCampus.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Campus;
            }

            if (realFileUpload.HasFile)
            {
                int length = realFileUpload.PostedFile.ContentLength;
                byte[] pic = new byte[length];
                realFileUpload.PostedFile.InputStream.Read(pic, 0, length);
                FileInfo fi = new FileInfo(realFileUpload.PostedFile.FileName);
                StaffController.UpdateStaffImg(Context.User.Identity.Name, pic);

                // Get File Name  
                string justFileName = fi.Name;
                // Get file extension   
                string extn = fi.Extension;
                // File Exists ?  
                bool exists = fi.Exists;
                if (fi.Exists)
                {
                    // Get file size  
                    long size = fi.Length;
                }
            }
            XLookupReportingDB dbstaffpic = new XLookupReportingDB();
            var userRow = dbstaffpic.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
            if (userRow.StaffImg != null)
            {
                byte[] imageData = userRow.StaffImg;
                string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                ProfileImg.ImageUrl = "data:image/png;base64," + img;
                profileEditImg.ImageUrl = "data:image/png;base64," + img;
                LinkButtonRemoveImg.Visible = true;
            }

            // Access the Master Page
            MasterPage master = this.Master as MasterPage;


            if (master != null)
            {
                // Find the control within the Master Page
                Image myControl = Master.FindControl("profileMasterImg") as Image;

                if (myControl != null)
                {
                    // Perform actions with the found control
                   
                    XLookupReportingDB db2 = new XLookupReportingDB();
                  
                    var userRow2 = db2.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                    if (userRow2.StaffImg != null)
                    {
                        byte[] imageData = userRow2.StaffImg;
                        string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                        myControl.ImageUrl = "data:image/png;base64," + img;
                    }
                    
                }
                // Find the LoginView control within the Master Page
                LoginView loginView = master.FindControl("LoginViewAdmin") as LoginView;

                if (loginView != null)
                {

                    Label usernametb = (Label)loginView.FindControl("UsernameLoggedIn");
                    Label userLoggedInLB = (Label)master.FindControl("UserLoggedIn");
                    Label userRoleLB = (Label)loginView.FindControl("UserRolelb");

                    XLookupReportingDB db3 = new XLookupReportingDB();
                    usernametb.Text = db3.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Firstname + " " + db3.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).Surname;
                    userLoggedInLB.Text = usernametb.Text;
                    var manager1 = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var role1 = manager1.GetRoles(db3.Users.SingleOrDefault(c => c.Email == Context.User.Identity.Name).User_ID);
                    foreach (var roleUser in role1)
                    {
                        userRoleLB.Text = roleUser;
                    }
                }
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

        protected void LinkButtonRemoveImg_Click(object sender, EventArgs e)
        {
            string script = "<script>triggerSpecificAnchorClick('" + "EditAnchor" + "');</script>";
            XLookupReportingDB db = new Models.XLookupReportingDB();
            var userRowRemove = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
            if (userRowRemove.StaffImg != null)
            {
                StaffController.RemoveStaffImg(Context.User.Identity.Name);
                XLookupReportingDB dbstaffpic = new XLookupReportingDB();
                var userRow = dbstaffpic.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                if (userRow.StaffImg == null)
                {
                   // byte[] imageData = userRow.StaffImg;
                    //string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                    ProfileImg.ImageUrl = "~/Assets/img/defaultImg.png";
                    profileEditImg.ImageUrl = "~/Assets/img/defaultImg.png";
                    LinkButtonRemoveImg.Visible = false;
                }

                // Access the Master Page
                MasterPage master = this.Master as MasterPage;


                if (master != null)
                {
                    // Find the control within the Master Page
                    Image myControl = Master.FindControl("profileMasterImg") as Image;

                    if (myControl != null)
                    {
                        // Perform actions with the found control

                        XLookupReportingDB db2 = new XLookupReportingDB();

                        var userRow2 = db2.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                        if (userRow2.StaffImg == null)
                        {
                         //   byte[] imageData = userRow2.StaffImg;
                           // string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                            myControl.ImageUrl = "~/Assets/img/defaultImg.png";
                        }

                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
                    //Response.Redirect("~/Admin/Profile.aspx");
                    
                    

                }
                else
                {
                    ErrorMessage.InnerText = "Nothing to remove";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
                }

               
            }
            else
            {
                ErrorMessage.InnerText = "Nothing to remove";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
            }
        }

        protected void customButton_Click(object sender, EventArgs e)
        {
            if (realFileUpload.HasFile)
            {
                int length = realFileUpload.PostedFile.ContentLength;
                byte[] pic = new byte[length];
                realFileUpload.PostedFile.InputStream.Read(pic, 0, length);
                FileInfo fi = new FileInfo(realFileUpload.PostedFile.FileName);
                StaffController.UpdateStaffImg(Context.User.Identity.Name, pic);

                // Get File Name  
                string justFileName = fi.Name;
                // Get file extension   
                string extn = fi.Extension;
                // File Exists ?  
                bool exists = fi.Exists;
                if (fi.Exists)
                {
                    // Get file size  
                    long size = fi.Length;
                }

                XLookupReportingDB dbstaffpic = new XLookupReportingDB();
                var userRow = dbstaffpic.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                if (userRow.StaffImg != null)
                {
                    byte[] imageData = userRow.StaffImg;
                    string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                    ProfileImg.ImageUrl = "data:image/png;base64," + img;
                    profileEditImg.ImageUrl = "data:image/png;base64," + img;
                    LinkButtonRemoveImg.Visible = true;
                }

                // Access the Master Page
                MasterPage master = this.Master as MasterPage;


                if (master != null)
                {
                    // Find the control within the Master Page
                    Image myControl = Master.FindControl("profileMasterImg") as Image;

                    if (myControl != null)
                    {
                        // Perform actions with the found control

                        XLookupReportingDB db2 = new XLookupReportingDB();

                        var userRow2 = db2.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name);
                        if (userRow2.StaffImg != null)
                        {
                            byte[] imageData = userRow2.StaffImg;
                            string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                            myControl.ImageUrl = "data:image/png;base64," + img;
                        }

                    }
                }
            }
            string script = "<script>triggerSpecificAnchorClick('" + "EditAnchor" + "');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);

        }
    }
}