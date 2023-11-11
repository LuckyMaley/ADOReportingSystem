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
    public partial class Create : System.Web.UI.Page
    {
        
            public static string userName;
            public static string projectname;
            public static string projectsemester;
            public static string projcampustxt;
            public static string projectyear;
            public static string moduleCode;
            public static string riskBeglbl;
            public static string riskEndlbl;
        
        public static string riskbeglbl;
        public static string riskendlbl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectYearCBTxt.Items.Clear();
                Stack<string> DateStack = new Stack<string>();
                int yearVal = int.Parse(DateTime.Now.Year.ToString());
                for (int i=0; i < 3; i++)
                {
                   DateStack.Push((yearVal - i).ToString());
                }
                while(DateStack.Count != 0)
                {
                    SelectYearCBTxt.Items.Add(DateStack.Peek());
                    DateStack.Pop();
                }
                SelectYearCBTxt.SelectedIndex = SelectYearCBTxt.Items.IndexOf(new ListItem(DateTime.Now.Year.ToString()));

                int year = int.Parse(SelectYearCBTxt.Text);
                if (DateTime.Now.Month < 8)
                {
                    SemesterCBTxt.SelectedIndex = 0;
                }
                else
                {
                    SemesterCBTxt.SelectedIndex = 1;
                }
                
                if (SemesterCBTxt.SelectedIndex == 0)
                {
                    riskbeglbl = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + (year - 1).ToString() + " Exams";
                    riskendlbl = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
                }
                else
                {
                    riskbeglbl = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
                    riskendlbl = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + SelectYearCBTxt.Text + " Exams";
                }
                XLookupReportingDB dbstaffpic = new XLookupReportingDB();
                var userRow = dbstaffpic.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name);
                if (userRow.Campus != null)
                {
                    for(int i= 0; i < CampusCBTxt.Items.Count; i++)
                    {
                        if (CampusCBTxt.Items[i].Text == userRow.Campus)
                        {
                            CampusCBTxt.SelectedIndex = i;
                        }
                    }
                }
            }
        }

        protected void Createbtn_Click(object sender, EventArgs e)
        {
            if (SelectModuleTxt.Text !="") {
                userName = Context.User.Identity.Name;
                projectname = ProjectName.Text;
                projectsemester = SemesterCBTxt.Text;
                projcampustxt = CampusCBTxt.Text;
                projectyear = SelectYearCBTxt.Text;
                moduleCode = SelectModuleTxt.Text;
                riskBeglbl = riskbeglbl;
                riskEndlbl = riskendlbl;
                Response.Redirect("~/Admin/CreateProject.aspx");
            }
            else
            {
                ErrorMessage.Visible = true;
                FailureText.Text = "Please make sure module code is not empty";
            }

        }

        protected void SelectModuleTxt_TextChanged(object sender, EventArgs e)
        {
            ProjectName.Text = SelectModuleTxt.Text + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.TimeOfDay.Hours.ToString() + DateTime.Now.TimeOfDay.Minutes.ToString() + DateTime.Now.TimeOfDay.Seconds.ToString() + DateTime.Now.TimeOfDay.Milliseconds.ToString();
        }

        protected void SemesterCBTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(SelectYearCBTxt.Text);
            if(SemesterCBTxt.SelectedIndex == 0)
            {
                riskbeglbl = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + (year - 1).ToString() + " Exams";
                riskendlbl = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
            }
            else
            {
                riskbeglbl = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
                riskendlbl = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + SelectYearCBTxt.Text + " Exams";
            }
        }

        protected void SelectYearCBTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(SelectYearCBTxt.Text);
            if (SemesterCBTxt.SelectedIndex == 0)
            {
                riskbeglbl = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + (year - 1).ToString() + " Exams";
                riskendlbl = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
            }
            else
            {
                riskbeglbl = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
                riskendlbl = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + SelectYearCBTxt.Text + " Exams";
            }
        }
    }
}