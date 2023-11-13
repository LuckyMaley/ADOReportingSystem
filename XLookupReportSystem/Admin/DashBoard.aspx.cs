using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XLookupReportSystem.Controllers;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Admin
{
    public partial class DashBoard : System.Web.UI.Page
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
                    DashboardImg.ImageUrl = "data:image/png;base64," + img;
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
                if (db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).EmailAddress != null)
                {
                    LbEmailAddress.Text = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).EmailAddress;
                }
                var userid = UserController.getUserID(Context.User.Identity.Name);
                var Projectlist = ProjectController.GetProjects(userid);
                var projOrderedList = Projectlist.OrderByDescending(c => c.createdDate).Take(5);
                listViewProjects.DataSource = projOrderedList;
                listViewProjects.DataBind();
            }
            else
            {
            }
        }
        
        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Create.aspx");
        }
    }
}