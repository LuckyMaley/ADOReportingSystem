using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string staffid = Request.QueryString["id"];
                if(staffid == null)
                {
                    
                    Response.Redirect("~/Admin/DashBoard.aspx");
                }
                XLookupReportingDB db1 = new XLookupReportingDB();
                string roleUserStaff = db1.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).StaffType;
                if (roleUserStaff == "Member")
                {
                    Response.Redirect("~/Admin/DashBoard.aspx");
                }
                XLookupReportingDB db = new XLookupReportingDB();
                string roleUser = db.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).StaffType;
                for (int i = 0; i < RoleList.Items.Count; i++)
                {
                    if (RoleList.Items[i].Text == roleUser)
                    {
                        RoleList.SelectedIndex = i;
                    }
                }


                if (db.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).Firstname != null)
                {
                    TxtFirstName.Text = db.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).Firstname;
                }
                if (db.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).Surname != null)
                {
                    txtSurname.Text = db.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).Surname;
                }

                XLookupReportingDB dbstaff = new XLookupReportingDB();
                var userRow1 = dbstaff.Staffs.SingleOrDefault(c => c.Staff_ID == staffid);
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

                if (userRow1.Discipline != null)
                {
                    for (int i = 0; i < DisciplineCBTxt.Items.Count; i++)
                    {
                        if (DisciplineCBTxt.Items[i].Text == userRow1.Discipline)
                        {
                            DisciplineCBTxt.SelectedIndex = i;
                        }
                    }
                }

                if (db.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).EmailAddress != null)
                {
                    txtEmail.Text = db.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).EmailAddress;
                }
            }
            }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            string staffid = Request.QueryString["id"];
            XLookupReportingDB db = new XLookupReportingDB();
            StaffController.UpdateStaffDetailsRole(db.Users.SingleOrDefault(c => c.Staff_ID == staffid).Email, TxtFirstName.Text, txtSurname.Text, CampusCBTxt.Text, RoleList.Text,DisciplineCBTxt.Text);

            XLookupReportingDB db1 = new XLookupReportingDB();
            string roleUser = db1.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).StaffType;
                for (int i = 0; i < RoleList.Items.Count; i++)
                {
                    if (RoleList.Items[i].Text == roleUser)
                    {
                        RoleList.SelectedIndex = i;
                    }
                }
            


            if (db1.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).Firstname != null)
            {
                TxtFirstName.Text = db1.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).Firstname;
            }
            if (db1.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).Surname != null)
            {
                txtSurname.Text = db1.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).Surname;
            }

            XLookupReportingDB dbstaffpic = new XLookupReportingDB();
            var userRow1 = dbstaffpic.Staffs.SingleOrDefault(c => c.Staff_ID == staffid);
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

            if (userRow1.Discipline != null)
            {
                for (int i = 0; i < DisciplineCBTxt.Items.Count; i++)
                {
                    if (DisciplineCBTxt.Items[i].Text == userRow1.Discipline)
                    {
                        DisciplineCBTxt.SelectedIndex = i;
                    }
                }
            }

            if (db1.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).EmailAddress != null)
            {
                txtEmail.Text = db1.Staffs.SingleOrDefault(c => c.Staff_ID == staffid).EmailAddress;
            }

            ErrorMessage.InnerText = "Details Updated Successfully";
            ErrorMessage.Visible = true;
        }

        protected void ProfileChangePassword_Click(object sender, EventArgs e)
        {
            string staffid = Request.QueryString["id"];
            string script = "<script>triggerSpecificAnchorClick('" + "profile-tab" + "');</script>";
            if (txtNewPassword.Text == txtRenewPassword.Text)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                XLookupReportingDB dbusers = new XLookupReportingDB();
                var user = manager.FindByName(dbusers.Users.SingleOrDefault(c => c.Staff_ID == staffid).Email);
                if (user == null)
                {
                    ErrorMessagePass.InnerText = "No user found";
                    ErrorMessagePass.Visible = true;
                    //Response.Redirect("~/Admin/Profile.aspx#profile-change-password");

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SpecificAnchorClickScript", script);
                    return;
                }
                
                var result = manager.RemovePassword(user.Id);
                    
                if (result.Succeeded)
                {
                    manager.AddPassword(user.Id, txtNewPassword.Text);
                    UserController.UpdateUserPassword(dbusers.Users.SingleOrDefault(c => c.Staff_ID == staffid).Email, txtNewPassword.Text);
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

        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            string staffid = Request.QueryString["id"];
            XLookupReportingDB db = new Models.XLookupReportingDB();
            string userId = db.Users.SingleOrDefault(c => c.Staff_ID == staffid).User_ID;
            var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            // Find the user and role by their IDs

            var user = userManager.FindById(userId);
            //var role = roleManager.FindById(roleId);

            // Check if the user and role exist
            //if (user != null && role != null)
            if (user != null)
            {
                string staffid1 = db.Users.SingleOrDefault(c => c.User_ID == userId).Staff_ID;
                // Remove the user from the role
                userManager.RemoveFromRole(user.Id, db.Staffs.SingleOrDefault(d => d.Staff_ID == staffid1).StaffType);
                var result = userManager.Delete(user);
            }
            UserController.RemoveUser(userId);
            Response.Redirect("~/Admin/Users.aspx");
        }
    }
}