using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XLookupReportSystem.Controllers;
using XLookupReportSystem.Models;
using OfficeOpenXml;

namespace XLookupReportSystem.Admin
{
    public partial class Projects : System.Web.UI.Page
    {
        public static List<string> checkedItems = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
                checkedItems = new List<string>();
            if (!IsPostBack)
            {
                var userid = UserController.getUserID(Context.User.Identity.Name);
                var Projectlist = ProjectController.GetProjects(userid);
                listViewProjects.DataSource = Projectlist.OrderByDescending(c => c.createdDate);
                listViewProjects.DataBind();
               
            }
           
        }

        
        public static string GetIDFromDatabase(ListViewItem item, string user)
        {
            string idFromDB = "";
            string userId = UserController.getUserID(user);
            List<Project> listProj = ProjectController.GetProjects(userId);
            // Retrieve the data item associated with the ListView item
            int dataItem = item.DataItemIndex;           
            idFromDB = listProj.ElementAt(dataItem).Project_ID;
            
            return idFromDB;
        }

        protected void Combinebtn_Click(object sender, EventArgs e)
        {


            
            foreach (ListViewItem item in listViewProjects.Items)
            {
                
                string idFromDB = GetIDFromDatabase(item, Context.User.Identity.Name); // Replace "ID" with your actual database field name
                string checkBoxID = "chkItem"; // Dynamically generate the CheckBox ID


                CheckBox chkItem = item.FindControl(checkBoxID) as CheckBox;
                
                if (chkItem != null && chkItem.Checked)
                {
                    // The CheckBox is checked; you can retrieve associated data or perform actions here
                    string data = idFromDB;
                    checkedItems.Add(data);
                }
            }


            if (checkedItems.Count > 1 ) {
                Response.Redirect("~/Admin/DownloadOverallProject");
                
            
        }
            else if (checkedItems.Count == 1)
            {
                Label2.Text = "Please select more than 1 project to combine";
            }
            else
            {
                Label2.Text = "Please select projects to combine";
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Create.aspx");
        }
    }
}