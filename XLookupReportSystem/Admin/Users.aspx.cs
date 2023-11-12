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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XLookupReportingDB db = new XLookupReportingDB();
                string roleUserStaff = db.Staffs.SingleOrDefault(c => c.EmailAddress == Context.User.Identity.Name).StaffType;
                if (roleUserStaff == "Member")
                {
                    Response.Redirect("~/Admin/DashBoard.aspx");
                }
                var staff = StaffController.GetStaff();
                listViewProjects.DataSource = staff;
                listViewProjects.DataBind();
            }
        }

        protected void AddUsersbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AddUser.aspx");
        }
    }
}