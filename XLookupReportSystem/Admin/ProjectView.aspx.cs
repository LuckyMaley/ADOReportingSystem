using OfficeOpenXml;
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
    public partial class ProjectView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string projID = Request.QueryString["projID"];
                XLookupReportingDB db = new Models.XLookupReportingDB();
                
                Label1.Text = db.Projects.SingleOrDefault(c => c.Project_ID == projID).ProjectName;
                var moduleDataList = ModuleDataController.GetModuleData(projID);
                Studentslb.Text = moduleDataList.Count.ToString();
                SIStudentlb.Text = moduleDataList.Where(c => c.SI_Student == "Yes").Count().ToString();
                NonSIStudentlb.Text = moduleDataList.Where(c => c.SI_Student == "No").Count().ToString();
                listViewProjects.DataSource = moduleDataList;
                listViewProjects.DataBind();
                listView1.DataSource = moduleDataList;
                listView1.DataBind();
            }
        }

        protected void Downloadbtn_Click(object sender, EventArgs e)
        {
            string projID = Request.QueryString["projID"];
            Response.Redirect("~/Controllers/ExportHandler.ashx?projID=" + projID);
        }

        protected void CreateProjbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Create.aspx", false);
        }
    }
}