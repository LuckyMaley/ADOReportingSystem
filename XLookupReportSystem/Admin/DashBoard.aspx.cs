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
                SelectYearCBTxt.Items.Clear();
                Stack<string> DateStack = new Stack<string>();
                int yearVal = int.Parse(DateTime.Now.Year.ToString());
                for (int i = 0; i < 3; i++)
                {
                    DateStack.Push((yearVal - i).ToString());
                }
                while (DateStack.Count != 0)
                {
                    SelectYearCBTxt.Items.Add(DateStack.Peek());
                    DateStack.Pop();
                }
                SelectYearCBTxt.SelectedIndex = SelectYearCBTxt.Items.IndexOf(new ListItem(DateTime.Now.Year.ToString()));

                int year = int.Parse(SelectYearCBTxt.Text);
                SemesterCBTxt.SelectedIndex = 0;
                if (SemesterCBTxt.SelectedIndex == 0)
                {
                    riskbeglb.Text = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + (year - 1).ToString() + " Exams";
                    riskendlb.Text = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
                }
                else
                {
                    riskbeglb.Text = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
                    riskendlb.Text = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + SelectYearCBTxt.Text + " Exams";
                }

                XLookupReportingDB db = new XLookupReportingDB();
                username.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Firstname + " " + db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).Surname;

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var role = manager.GetRoles(db.Users.SingleOrDefault(c => c.Email == Context.User.Identity.Name).User_ID);
                foreach (var roleUser in role)
                {
                    usertype.Text = roleUser;
                }
                var userRow = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name);
                if (userRow.StaffImg != null)
                {
                    byte[] imageData = userRow.StaffImg;
                    string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                    DashboardImg.ImageUrl = "data:image/png;base64," + img;
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
                if (db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).EmailAdress != null)
                {
                    LbEmailAddress.Text = db.Staffs.SingleOrDefault(c => c.EmailAdress == Context.User.Identity.Name).EmailAdress;
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

        protected void Createbtn_Click(object sender, EventArgs e)
        {
            try
            {

                //Createbtn.Enabled = false;
                string ProjID = ProjectController.AddNewProject(UserController.getUserID(Context.User.Identity.Name), ProjectName.Text, SemesterCBTxt.Text, CampusCBTxt.Text, SelectYearCBTxt.Text, SelectModuleTxt.Text);
                List<Project_Register> projRegList = new List<Models.Project_Register>();
                List<Register> regList = new List<Register>();
                byte[] fileBytes = new byte[0];
                byte[] fileBytesModule = new byte[0];
                byte[] fileBytesSupp = new byte[0];
                byte[] fileBytesRiskBeg = new byte[0];
                byte[] fileBytesRiskEnd = new byte[0];
                if (UploadRegister.HasFile == true)
                {
                    //String contenttype = UploadRegister.PostedFile.ContentType;

                    //if (contenttype == "image/jpeg")
                    //{
                    //}

                    //inserting project and Registers 
                    int UploadReglength = UploadRegister.PostedFile.ContentLength;
                    fileBytes = new byte[UploadReglength];
                    var data = UploadRegister.PostedFile.InputStream.Read(fileBytes, 0, Convert.ToInt32(UploadRegister.PostedFile.ContentLength));
                    using (var package = new ExcelPackage(UploadRegister.PostedFile.InputStream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var currentsheet = package.Workbook.Worksheets;
                        foreach (ExcelWorksheet worksheet in currentsheet)
                        {
                            //string projRegID = Project_RegisterController.AddNewProject_Register(worksheet.Name, ProjID);
                            string projRegID = Project_RegisterController.AddNewProject_RegisterList(worksheet.Name, ProjID, ref projRegList);
                            var noOfCol = worksheet.Dimension.End.Column;
                            var noOfRow = worksheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                string studNum = "";
                                for (int colIterator = 1; colIterator <= noOfCol; colIterator++)
                                {
                                    if (worksheet.Cells[1, colIterator].Value.ToString().Contains("STUDENT NUMBER") || worksheet.Cells[1, colIterator].Value.ToString().Contains("Student number") || worksheet.Cells[1, colIterator].Value.ToString().Contains("Student no") || worksheet.Cells[1, colIterator].Value.ToString().Contains("stu no") || worksheet.Cells[1, colIterator].Value.ToString().Contains("stud no") || worksheet.Cells[1, colIterator].Value.ToString().Contains("student no"))
                                    {
                                        studNum = worksheet.Cells[rowIterator, colIterator].Value.ToString();
                                    }
                                }
                                //RegisterController.AddNewRegister(projRegID, worksheet.Cells[rowIterator, 1].Value.ToString(), ProjID);
                                var regID = RegisterController.AddNewRegisterList(projRegID, studNum, ProjID, ref regList);
                            }
                        }
                    }
                }
                //Inserting Module Data and supp data
                if (UploadSuppModuleData.HasFile == true)
                {
                    int UploadModulelength = UploadModuleData.PostedFile.ContentLength;
                    fileBytesModule = new byte[UploadModulelength];
                    var dataModule = UploadModuleData.PostedFile.InputStream.Read(fileBytesModule, 0, Convert.ToInt32(UploadModuleData.PostedFile.ContentLength));

                    int UploadSuppModulelength = UploadSuppModuleData.PostedFile.ContentLength;
                    fileBytesSupp = new byte[UploadSuppModulelength];
                    var dataSupp = UploadSuppModuleData.PostedFile.InputStream.Read(fileBytesSupp, 0, Convert.ToInt32(UploadSuppModuleData.PostedFile.ContentLength));

                    using (var package = new ExcelPackage(UploadModuleData.PostedFile.InputStream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var worksheet = package.Workbook.Worksheets.First();

                        var noOfCol = worksheet.Dimension.End.Column;
                        var noOfRow = worksheet.Dimension.End.Row;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            decimal examMark = 0;
                            if (worksheet.Cells[rowIterator, 4].Value == null || worksheet.Cells[rowIterator, 4].Value.ToString() == "")
                            {
                                examMark = 0;
                            }
                            else
                            {
                                var s = worksheet.Cells[rowIterator, 4].Value;
                                examMark = decimal.Parse(worksheet.Cells[rowIterator, 4].Value.ToString());
                            }
                            string moduledataID = ModuleDataController.AddNewModuleData(worksheet.Cells[rowIterator, 1].Value.ToString(), worksheet.Cells[rowIterator, 2].Value.ToString(), worksheet.Cells[rowIterator, 3].Value.ToString(), examMark, ProjID);
                            using (var packageSupp = new ExcelPackage(UploadSuppModuleData.PostedFile.InputStream))
                            {
                                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                                var currentsheet = packageSupp.Workbook.Worksheets.First();
                                var noOfColumns = currentsheet.Dimension.End.Column;
                                var noOfRows = currentsheet.Dimension.End.Row;
                                for (int rowIterator1 = 2; rowIterator1 <= noOfRows; rowIterator1++)
                                {
                                    decimal suppMark = 0;
                                    if (currentsheet.Cells[rowIterator1, 4].Value == null || currentsheet.Cells[rowIterator1, 4].Value.ToString() == "")
                                    {
                                        suppMark = 0;
                                    }
                                    else
                                    {
                                        suppMark = decimal.Parse(currentsheet.Cells[rowIterator1, 4].Value.ToString());
                                    }
                                    ModuleDataController.AddSuppModuleData(currentsheet.Cells[rowIterator1, 1].Value.ToString(), suppMark, ProjID);
                                }

                            }
                        }

                    }


                }
                else
                {
                    int UploadModulelength = UploadModuleData.PostedFile.ContentLength;
                    fileBytesModule = new byte[UploadModulelength];
                    var dataModule = UploadModuleData.PostedFile.InputStream.Read(fileBytesModule, 0, Convert.ToInt32(UploadModuleData.PostedFile.ContentLength));

                    using (var package = new ExcelPackage(UploadModuleData.PostedFile.InputStream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var worksheet = package.Workbook.Worksheets.First();

                        var noOfCol = worksheet.Dimension.End.Column;
                        var noOfRow = worksheet.Dimension.End.Row;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            decimal examMark = 0;
                            if (worksheet.Cells[rowIterator, 4].Value == null || worksheet.Cells[rowIterator, 4].Value.ToString() == "")
                            {
                                examMark = 0;
                            }
                            else
                            {
                                examMark = decimal.Parse(worksheet.Cells[rowIterator, 4].Value.ToString());
                            }
                            string moduledataID = ModuleDataController.AddNewModuleData(worksheet.Cells[rowIterator, 1].Value.ToString(), worksheet.Cells[rowIterator, 2].Value.ToString(), worksheet.Cells[rowIterator, 3].Value.ToString(), examMark, ProjID);
                        }
                    }
                }
                List<NegativeTermDecisionsBeginning> negDecisionsBeg = new List<NegativeTermDecisionsBeginning>();
                if (UploadRiskCodeBeg.HasFile == true)
                {
                    //String contenttype = UploadRegister.PostedFile.ContentType;

                    //if (contenttype == "image/jpeg")
                    //{
                    //}

                    //inserting risk codes beginning 
                    int UploadRiskBeglength = UploadRiskCodeBeg.PostedFile.ContentLength;
                    fileBytesRiskBeg = new byte[UploadRiskBeglength];
                    var data = UploadRiskCodeBeg.PostedFile.InputStream.Read(fileBytesRiskBeg, 0, Convert.ToInt32(UploadRiskCodeBeg.PostedFile.ContentLength));
                    using (var package = new ExcelPackage(UploadRiskCodeBeg.PostedFile.InputStream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var currentsheet = package.Workbook.Worksheets;
                        foreach (ExcelWorksheet worksheet in currentsheet)
                        {
                            if (worksheet.Name == "Negative Term Decisions")
                            {
                                var noOfCol = worksheet.Dimension.End.Column;
                                var noOfRow = worksheet.Dimension.End.Row;
                                for (int rowIterator = 8; rowIterator <= noOfRow; rowIterator++)
                                {
                                    var studentnum = "";
                                    if (worksheet.Cells[rowIterator, 3].Value == null || worksheet.Cells[rowIterator, 3].Value.ToString() == "")
                                    {
                                        studentnum = worksheet.Cells[rowIterator - 1, 3].Value.ToString();
                                    }
                                    else
                                    {
                                        studentnum = worksheet.Cells[rowIterator, 3].Value.ToString();
                                    }
                                    //NegativeTermDecisionsBegController.AddNewBegNegTermDecision(studentnum, worksheet.Cells[rowIterator, 10].Value.ToString(), ProjID);
                                    negDecisionsBeg = NegativeTermDecisionsBegController.AddNewBegNegTermDecisionList(studentnum, worksheet.Cells[rowIterator, 10].Value.ToString(), ProjID, negDecisionsBeg);
                                }
                            }
                        }
                    }
                }

                List<NegativeTermDecisionsEnd> negDecisionsEnd = new List<NegativeTermDecisionsEnd>();
                if (UploadRiskCodeEnd.HasFile == true)
                {
                    //String contenttype = UploadRegister.PostedFile.ContentType;

                    //if (contenttype == "image/jpeg")
                    //{
                    //}

                    //inserting risk codes beginning 
                    int UploadRiskEndlength = UploadRiskCodeEnd.PostedFile.ContentLength;
                    fileBytesRiskEnd = new byte[UploadRiskEndlength];
                    var data = UploadRiskCodeEnd.PostedFile.InputStream.Read(fileBytesRiskEnd, 0, Convert.ToInt32(UploadRiskCodeEnd.PostedFile.ContentLength));
                    using (var package = new ExcelPackage(UploadRiskCodeEnd.PostedFile.InputStream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var currentsheet = package.Workbook.Worksheets;
                        foreach (ExcelWorksheet worksheet in currentsheet)
                        {
                            if (worksheet.Name == "Negative Term Decisions")
                            {
                                var noOfCol = worksheet.Dimension.End.Column;
                                var noOfRow = worksheet.Dimension.End.Row;
                                for (int rowIterator = 8; rowIterator <= noOfRow; rowIterator++)
                                {
                                    var studentnum = "";
                                    if (worksheet.Cells[rowIterator, 3].Value == null || worksheet.Cells[rowIterator, 3].Value.ToString() == "")
                                    {
                                        studentnum = worksheet.Cells[rowIterator - 1, 3].Value.ToString();
                                    }
                                    else
                                    {
                                        studentnum = worksheet.Cells[rowIterator, 3].Value.ToString();
                                    }
                                    //NegativeTermDecisionsEndController.AddNewEndNegTermDecision(studentnum, worksheet.Cells[rowIterator, 10].Value.ToString(), ProjID);
                                    negDecisionsEnd = NegativeTermDecisionsEndController.AddNewEndNegTermDecisionList(studentnum, worksheet.Cells[rowIterator, 10].Value.ToString(), ProjID, negDecisionsEnd);
                                }
                            }
                        }
                    }
                }

                //Generating the Register Attandance data
                XLookupReportingDB db = new XLookupReportingDB();
                List<Register_Attendance> regAttendanceList = new List<Register_Attendance>();
                foreach (ModuleData md in db.ModuleDatas)
                {
                    var stuID = md.StudentNumber;
                    //foreach (Project_Register projReg in db.Project_Registers)
                    foreach (Project_Register projReg in projRegList)
                    {
                        var ProjRegID = projReg.Project_Register_ID;
                        //int attendanceCount= db.Registers.Where(c => c.StudentNumber == stuID && c.Project_ID == ProjID && c.Project_Register_ID == ProjRegID).Count();
                        int attendanceCount = regList.Where(c => c.StudentNumber == stuID && c.Project_ID == ProjID && c.Project_Register_ID == ProjRegID).Count();
                        //Register_AttendanceController.AddNewRegister_Attendance(md.ModuleData_ID, ProjRegID, attendanceCount, ProjID);
                        regAttendanceList = Register_AttendanceController.AddNewRegister_AttendanceList(md.ModuleData_ID, ProjRegID, attendanceCount, ProjID, regAttendanceList);
                    }
                    //var studentAttendance = db.Register_Attendances.Where(c => c.ModuleData_ID == md.ModuleData_ID && c.Project_ID == ProjID).Sum(c=> c.Attendance);
                    var studentAttendance = regAttendanceList.Where(c => c.ModuleData_ID == md.ModuleData_ID && c.Project_ID == ProjID).Sum(c => c.Attendance);
                    if (studentAttendance > 0)
                    {
                        md.SI_Student = "Yes";

                    }
                    else
                    {
                        md.SI_Student = "No";

                    }

                }
                db.SaveChanges();

                //Generating table 2 data
                var consultationsADD = db.ModuleDatas.Where(c => c.Project_ID == ProjID);
                int attendStud = 0;
                foreach (var cons in consultationsADD)
                {
                    string modID = cons.ModuleData_ID.ToString();
                    //var reg = db.Register_Attendances.Where(c => c.ModuleData_ID == modID && c.Project_ID == ProjID);
                    var reg = regAttendanceList.Where(c => c.ModuleData_ID == modID && c.Project_ID == ProjID);
                    foreach (var regData in reg)
                    {
                        attendStud += regData.Attendance;
                    }
                }
                //var consultations = db.Register_Attendances.Where(c => c.Project_ID == ProjID).Sum(c => c.Attendance);
                var consultations = attendStud;
                var si_student = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes").Count();
                var non_si_student = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No").Count();
                TableTwoController.AddNewTableTwo(consultations, si_student, non_si_student, ProjID);

                //Generating Table 1 data
                int noOfSI_Students = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes").Count();
                int noOfSI_Students_Passed = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.FinalMark >= 50).Count();
                decimal si_Student_Pass_Rate = Math.Round((decimal)noOfSI_Students_Passed / (decimal)noOfSI_Students * (decimal)100, 2) == 0 ? 0 : Math.Round((decimal)noOfSI_Students_Passed / (decimal)noOfSI_Students * (decimal)100, 2);
                decimal averageSI_Students_Pass_Rate = Math.Round(db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes").Average(c => c.FinalMark), 2);
                int no_SI_Of_A_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.FinalMark >= 75).Count();
                int no_SI_Of_B_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.FinalMark >= 70 && c.FinalMark <= 74).Count();
                int no_SI_Of_C_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.FinalMark >= 60 && c.FinalMark <= 69).Count();
                int no_SI_Of_D_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.FinalMark >= 50 && c.FinalMark <= 59).Count();
                int no_SI_Of_F_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.FinalMark < 50).Count();
                int total_SI_Students = no_SI_Of_A_Symbols + no_SI_Of_B_Symbols + no_SI_Of_C_Symbols + no_SI_Of_D_Symbols + no_SI_Of_F_Symbols;
                int noOfNon_SI_Students = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No").Count();
                int noOfNon_SI_Students_Passed = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No" && c.FinalMark >= 50).Count();
                decimal non_si_student_Pass_Rate = Math.Round((decimal)noOfNon_SI_Students_Passed / (decimal)noOfNon_SI_Students * (decimal)100, 2) == 0 ? 0 : Math.Round((decimal)noOfNon_SI_Students_Passed / (decimal)noOfNon_SI_Students * (decimal)100, 2);
                decimal averageNon_SI_Students_Pass_Rate = Math.Round(db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No").Average(c => c.FinalMark), 2);
                int no_Non_SI_Of_A_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No" && c.FinalMark >= 75).Count();
                int no_Non_SI_Of_B_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No" && c.FinalMark >= 70 && c.FinalMark <= 74).Count();
                int no_Non_SI_Of_C_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No" && c.FinalMark >= 60 && c.FinalMark <= 69).Count();
                int no_Non_SI_Of_D_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No" && c.FinalMark >= 50 && c.FinalMark <= 59).Count();
                int no_Non_SI_Of_F_Symbols = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "No" && c.FinalMark <= 49).Count();
                int total_Non_SI_Students = no_Non_SI_Of_A_Symbols + no_Non_SI_Of_B_Symbols + no_Non_SI_Of_C_Symbols + no_Non_SI_Of_D_Symbols + no_Non_SI_Of_F_Symbols;

                //Generating Overall Table 1
                int noOfOverallStudents = noOfSI_Students + noOfNon_SI_Students;
                int noOfOverallStudentsPassed = noOfSI_Students_Passed + noOfNon_SI_Students_Passed;
                decimal overall_Students_Pass_Rate = Math.Round((decimal)noOfOverallStudentsPassed / (decimal)noOfOverallStudents * (decimal)100, 2) == 0 ? 0 : Math.Round((decimal)noOfOverallStudentsPassed / (decimal)noOfOverallStudents * (decimal)100, 2);
                decimal averageOverall_Students_Pass_Rate = Math.Round(db.ModuleDatas.Where(c => c.Project_ID == ProjID).Average(c => c.FinalMark), 2);

                TableOneOverallController.AddNewTableOneOverall(noOfOverallStudents, noOfOverallStudentsPassed, overall_Students_Pass_Rate, averageOverall_Students_Pass_Rate, ProjID);

                TableOneController.AddNewTableOne(noOfSI_Students, noOfSI_Students_Passed, si_Student_Pass_Rate, averageSI_Students_Pass_Rate, no_SI_Of_A_Symbols, no_SI_Of_B_Symbols, no_SI_Of_C_Symbols, no_SI_Of_D_Symbols, no_SI_Of_F_Symbols, total_SI_Students, noOfNon_SI_Students, noOfNon_SI_Students_Passed, non_si_student_Pass_Rate, averageNon_SI_Students_Pass_Rate, no_Non_SI_Of_A_Symbols, no_Non_SI_Of_B_Symbols, no_Non_SI_Of_C_Symbols, no_Non_SI_Of_D_Symbols, no_Non_SI_Of_F_Symbols, total_Non_SI_Students, ProjID);

                //Generating Table 3
                foreach (ModuleData modData in db.ModuleDatas)
                {
                    //Negative Term Decisions Beginning
                    //var dataBeg = db.NegativeTermDecisionBeginnings.SingleOrDefault(c => c.StudentNumber == modData.StudentNumber && c.Project_ID == ProjID);
                    var dataBeg = negDecisionsBeg.SingleOrDefault(c => c.StudentNumber == modData.StudentNumber && c.Project_ID == ProjID);
                    if (dataBeg != null)
                    {
                        //modData.NegativeTermDecisionsBeg_ID = dataBeg.NegativeTermDecisionsBeg_ID;
                        modData.Risk_Code_Beg = dataBeg.RiskCodeBeg;
                        modData.Code_Beg = RiskCode(dataBeg.RiskCodeBeg);
                    }
                    else
                    {
                        modData.Risk_Code_Beg = "Green";
                        modData.Code_Beg = RiskCode("Green");
                    }

                    //Negative Term Decisions End
                    //var dataEnd = db.NegativeTermDecisionEnds.SingleOrDefault(c => c.StudentNumber == modData.StudentNumber && c.Project_ID == ProjID);
                    var dataEnd = negDecisionsEnd.SingleOrDefault(c => c.StudentNumber == modData.StudentNumber && c.Project_ID == ProjID);
                    if (dataEnd != null)
                    {
                        //modData.NegativeTermDecisionsEnd_ID = dataEnd.NegativeTermDecisionsEnd_ID;
                        modData.Risk_Code_End = dataEnd.RiskCodeEnd;
                        modData.Code_End = RiskCode(dataEnd.RiskCodeEnd);
                    }
                    else
                    {
                        modData.Risk_Code_End = "Green";
                        modData.Code_End = RiskCode("Green");
                    }
                }
                db.SaveChanges();


                int no_of_risk_students_consulting_ADO_back_on_good_academic_standing = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 1 && c.Code_End == 0).Count();
                int no_of_consulting_risk_students_who_continued_to_be_at_risk = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 1 && c.Code_End == 1).Count();
                int no_of_student_who_were_at_risk_at_the_end_of_semester_1 = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_End == 1).Count();
                int no_of_consulting_risk_students_who_have_moved_to_probation = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 1 && c.Code_End == 2).Count() + db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 1 && c.Code_End == 3).Count();

                int no_of_students_at_risk_seen = no_of_risk_students_consulting_ADO_back_on_good_academic_standing + no_of_consulting_risk_students_who_continued_to_be_at_risk + no_of_student_who_were_at_risk_at_the_end_of_semester_1 + no_of_consulting_risk_students_who_have_moved_to_probation;

                int no_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 2 && c.Code_End == 2).Count() + db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 3 && c.Code_End == 3).Count();
                int no_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 2 && c.Code_End == 1).Count();
                int no_of_consulting_probation_students_who_have_been_excluded = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 2 && c.Code_End == 4).Count();

                int no_of_students_on_probation_seen = no_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation + no_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status + no_of_consulting_probation_students_who_have_been_excluded;

                int no_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 0 && c.Code_End == 0).Count();
                TableThreeController.AddNewTableThree(no_of_students_at_risk_seen, no_of_risk_students_consulting_ADO_back_on_good_academic_standing, no_of_consulting_risk_students_who_continued_to_be_at_risk, no_of_student_who_were_at_risk_at_the_end_of_semester_1, no_of_consulting_risk_students_who_have_moved_to_probation, no_of_students_on_probation_seen, no_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation, no_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status, no_of_consulting_probation_students_who_have_been_excluded, no_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester, ProjID);

                //Term Decisions Beginning Table SI students
                int greenBeg = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 0).Count();
                int risk_or_rsk2_Beg = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 1).Count();
                int fprr_or_fpma_Beg = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 3).Count();
                int prob_Beg = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 2).Count();
                int xnfa_Beg = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_Beg == 4).Count();
                TermDecisionsBegController.AddNewTermDecisionsBeg(greenBeg, risk_or_rsk2_Beg, fprr_or_fpma_Beg, prob_Beg, xnfa_Beg, ProjID);

                //Term Decisions End Table SI students
                int greenEnd = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_End == 0).Count();
                int risk_or_rsk2_End = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_End == 1).Count();
                int fprr_or_fpma_End = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_End == 3).Count();
                int prob_End = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_End == 2).Count();
                int xnfa_End = db.ModuleDatas.Where(c => c.Project_ID == ProjID && c.SI_Student == "Yes" && c.Code_End == 4).Count();
                TermDecisionsEndController.AddNewTermDecisionsEnd(greenEnd, risk_or_rsk2_End, fprr_or_fpma_End, prob_End, xnfa_End, ProjID);

                negDecisionsBeg.Clear();
                negDecisionsEnd.Clear();
                regAttendanceList.Clear();
                projRegList.Clear();
                regList.Clear();

                ProjectController.AddProjectFiles(ProjID, fileBytes, fileBytesModule, fileBytesSupp, fileBytesRiskBeg, fileBytesRiskEnd);

                Createbtn.Enabled = true;
                //Response.Redirect("~/Controllers/ExportHandler.ashx?projID="+ProjID);
                Response.Redirect("~/Admin/ProjectView.aspx?projID=" + ProjID, false);
            }
            catch
            {

            }

        }

        public int RiskCode(string riskCode)
        {
            int riskCodeNum = 0;
            if(riskCode == "Green")
            {
                riskCodeNum = 0;
            }
            else if(riskCode == "RISK")
            {
                riskCodeNum = 1;
            }
            else if (riskCode == "RSK2")
            {
                riskCodeNum = 1;
            }
            else if (riskCode == "FPRR")
            {
                riskCodeNum = 3;
            }
            else if (riskCode == "FPMA")
            {
                riskCodeNum = 3;
            }
            else if (riskCode == "PROB")
            {
                riskCodeNum = 2;
            }
            else if (riskCode == "XNFA")
            {
                riskCodeNum = 4;
            }
            return riskCodeNum;
        }

        protected void SelectModuleTxt_TextChanged(object sender, EventArgs e)
        {
            Random randomGenerator = new Random();
            randomGenerator.Next(1, DateTime.Now.Year);
            ProjectName.Text = SelectModuleTxt.Text + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()+ DateTime.Now.TimeOfDay.Hours.ToString() + DateTime.Now.TimeOfDay.Minutes.ToString() + DateTime.Now.TimeOfDay.Seconds.ToString() + DateTime.Now.TimeOfDay.Milliseconds.ToString();
        }

        protected void SemesterCBTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(SelectYearCBTxt.Text);
            if (SemesterCBTxt.SelectedIndex == 0)
            {
                riskbeglb.Text = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + (year - 1).ToString() + " Exams";
                riskendlb.Text = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
            }
            else
            {
                riskbeglb.Text = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
                riskendlb.Text = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + SelectYearCBTxt.Text + " Exams";
            }
        }

        protected void CampusCBTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(SelectYearCBTxt.Text);
            if (SemesterCBTxt.SelectedIndex == 0)
            {
                riskbeglb.Text = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + (year - 1).ToString() + " Exams";
                riskendlb.Text = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
            }
            else
            {
                riskbeglb.Text = "Upload Risk Codes for May-Jun " + SemesterCBTxt.Items[0].Text + " of " + SelectYearCBTxt.Text + " Exams";
                riskendlb.Text = "Upload Risk Codes for Nov-Dec " + SemesterCBTxt.Items[1].Text + " of " + SelectYearCBTxt.Text + " Exams";
            }
            
        }
        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Create.aspx");
        }
    }
}