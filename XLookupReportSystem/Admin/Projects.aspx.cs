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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userid = UserController.getUserID(Context.User.Identity.Name);
                var Projectlist = ProjectController.GetProjects(userid);
                listViewProjects.DataSource = Projectlist;
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


            List<string> checkedItems = new List<string>();
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


           
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Table 1 Overall");

            ws.Cells["A6"].Value = "75-100%";
            ws.Cells["A7"].Value = "70-74%";
            ws.Cells["A8"].Value = "60-69%";
            ws.Cells["A9"].Value = "50-59%";
            ws.Cells["A10"].Value = "< 50%";
            ws.Cells["A6:A10"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["A6:A10"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gold);

            ws.Cells["B1"].Value = "No of SI students";
            ws.Cells["B2"].Value = "No of SI students who passed";
            ws.Cells["B3"].Value = "% Pass rate";
            ws.Cells["B4"].Value = "Average SI students % pass rate";

            ws.Cells["B6"].Value = "As";
            ws.Cells["B7"].Value = "Bs";
            ws.Cells["B8"].Value = "Cs";
            ws.Cells["B9"].Value = "Ds";
            ws.Cells["B10"].Value = "Fs";

            ws.Cells["E1"].Value = "No of Non-SI students";
            ws.Cells["E2"].Value = "No of Non-SI students who passed";
            ws.Cells["E3"].Value = "% Pass rate";
            ws.Cells["E4"].Value = "Average Non-SI students % pass rate";

            ws.Cells["E6"].Value = "As";
            ws.Cells["E7"].Value = "Bs";
            ws.Cells["E8"].Value = "Cs";
            ws.Cells["E9"].Value = "Ds";
            ws.Cells["E10"].Value = "Fs";

            ws.Cells["A16"].Value = "No of overall students";
            ws.Cells["A17"].Value = "No of overall students who passed";
            ws.Cells["A18"].Value = "% Pass rate";
            ws.Cells["A19"].Value = "Average overall % pass rate";
            XLookupReportingDB db = new Models.XLookupReportingDB();

            int NoOfSI_StudentsItem = 0;
            int NoOfSI_Students_PassedItem = 0;
            decimal SI_Students_Pass_RateItem = 0;
            decimal AverageSI_Students_Pass_RateItem = 0;

            int No_SI_Of_A_SymbolsItem = 0;
            int No_SI_Of_B_SymbolsItem = 0;
            int No_SI_Of_C_SymbolsItem = 0;
            int No_SI_Of_D_SymbolsItem = 0;
            int No_SI_Of_F_SymbolsItem = 0;

            int Total_SI_StudentsItem = 0;

            int NoOfNon_SI_StudentsItem = 0;
            int NoOfNon_SI_Students_PassedItem = 0;
            decimal Non_SI_Students_Pass_RateItem = 0;
            decimal AverageNon_SI_Students_Pass_RateItem = 0;

            int No_Non_SI_Of_A_SymbolsItem = 0;
            int No_Non_SI_Of_B_SymbolsItem = 0;
            int No_Non_SI_Of_C_SymbolsItem = 0;
            int No_Non_SI_Of_D_SymbolsItem = 0;
            int No_Non_SI_Of_F_SymbolsItem = 0;

            int Total_Non_SI_StudentsItem = 0;

            foreach (string str in checkedItems)
            {
                string projID = str;
                
                List<TableOne> TableOneList = db.TableOnes.Where(x => x.Project_ID == projID).ToList();


                foreach (var item in TableOneList)
                {
                    NoOfSI_StudentsItem += item.NoOfSI_Students;
                    NoOfSI_Students_PassedItem += item.NoOfSI_Students_Passed;
                    SI_Students_Pass_RateItem += item.SI_Students_Pass_Rate;
                    AverageSI_Students_Pass_RateItem += item.AverageSI_Students_Pass_Rate;

                    No_SI_Of_A_SymbolsItem += item.No_SI_Of_A_Symbols;
                    No_SI_Of_B_SymbolsItem += item.No_SI_Of_B_Symbols;
                    No_SI_Of_C_SymbolsItem += item.No_SI_Of_C_Symbols;
                    No_SI_Of_D_SymbolsItem += item.No_SI_Of_D_Symbols;
                    No_SI_Of_F_SymbolsItem += item.No_SI_Of_F_Symbols;

                    Total_SI_StudentsItem += item.Total_SI_Students;

                    NoOfNon_SI_StudentsItem += item.NoOfNon_SI_Students;
                    NoOfNon_SI_Students_PassedItem += item.NoOfNon_SI_Students_Passed;
                    Non_SI_Students_Pass_RateItem += item.Non_SI_Students_Pass_Rate;
                    AverageNon_SI_Students_Pass_RateItem += item.AverageNon_SI_Students_Pass_Rate;

                    No_Non_SI_Of_A_SymbolsItem += item.No_Non_SI_Of_A_Symbols;
                    No_Non_SI_Of_B_SymbolsItem += item.No_Non_SI_Of_B_Symbols;
                    No_Non_SI_Of_C_SymbolsItem += item.No_Non_SI_Of_C_Symbols;
                    No_Non_SI_Of_D_SymbolsItem += item.No_Non_SI_Of_D_Symbols;
                    No_Non_SI_Of_F_SymbolsItem += item.No_Non_SI_Of_F_Symbols;

                    Total_Non_SI_StudentsItem += item.Total_Non_SI_Students;
                }
            }

            ws.Cells["C1"].Value = NoOfSI_StudentsItem.ToString();
            ws.Cells["C2"].Value = NoOfSI_Students_PassedItem.ToString();
            ws.Cells["C3"].Value = (Math.Round((decimal)NoOfSI_Students_PassedItem / (decimal)NoOfSI_StudentsItem*(decimal)100,2)).ToString();
            ws.Cells["C4"].Value = (AverageSI_Students_Pass_RateItem/checkedItems.Count).ToString();

            ws.Cells["C6"].Value = No_SI_Of_A_SymbolsItem.ToString();
            ws.Cells["C7"].Value = No_SI_Of_B_SymbolsItem.ToString();
            ws.Cells["C8"].Value = No_SI_Of_C_SymbolsItem.ToString();
            ws.Cells["C9"].Value = No_SI_Of_D_SymbolsItem.ToString();
            ws.Cells["C10"].Value = No_SI_Of_F_SymbolsItem.ToString();

            ws.Cells["C12"].Value = Total_SI_StudentsItem.ToString();

            ws.Cells["F1"].Value = NoOfNon_SI_StudentsItem.ToString();
            ws.Cells["F2"].Value = NoOfNon_SI_Students_PassedItem.ToString();
            ws.Cells["F3"].Value = (Math.Round((decimal)NoOfNon_SI_Students_PassedItem/(decimal)NoOfNon_SI_StudentsItem*(decimal)100,2)).ToString();
            ws.Cells["F4"].Value = (AverageNon_SI_Students_Pass_RateItem/checkedItems.Count).ToString();

            ws.Cells["F6"].Value = No_Non_SI_Of_A_SymbolsItem.ToString();
            ws.Cells["F7"].Value = No_Non_SI_Of_B_SymbolsItem.ToString();
            ws.Cells["F8"].Value = No_Non_SI_Of_C_SymbolsItem.ToString();
            ws.Cells["F9"].Value = No_Non_SI_Of_D_SymbolsItem.ToString();
            ws.Cells["F10"].Value = No_Non_SI_Of_F_SymbolsItem.ToString();

            ws.Cells["F12"].Value = Total_Non_SI_StudentsItem.ToString();

            //table one overall
            int NoOfOverallStudentsItem = 0;
            int NoOfOverallStudentsPassedItem = 0;
            decimal Overall_Students_Pass_RateItem = 0;
            decimal AverageOverall_Students_Pass_RateItem = 0;

            foreach (string str in checkedItems)
            {
                string projID = str;
                List<TableOneOverall> overallDataList = db.TableOneOveralls.Where(c => c.Project_ID == projID).ToList();
                foreach (var modData in overallDataList)
                {
                    NoOfOverallStudentsItem += modData.NoOfOverallStudents;
                    NoOfOverallStudentsPassedItem += modData.NoOfOverallStudentsPassed;
                    Overall_Students_Pass_RateItem += modData.Overall_Students_Pass_Rate;
                    AverageOverall_Students_Pass_RateItem += modData.AverageOverall_Students_Pass_Rate;
                }
            }

            ws.Cells["B16"].Value = NoOfOverallStudentsItem.ToString();
            ws.Cells["B17"].Value = NoOfOverallStudentsPassedItem.ToString();
            ws.Cells["B18"].Value = (Math.Round((decimal)NoOfOverallStudentsPassedItem/(decimal)NoOfOverallStudentsItem*(decimal)100,2)).ToString();
            ws.Cells["B19"].Value = ((decimal.Parse(ws.Cells["C4"].Value.ToString()) + decimal.Parse(ws.Cells["F4"].Value.ToString()))/2).ToString();

            //table 2
            ExcelWorksheet wsTableTwo = pck.Workbook.Worksheets.Add("Table 2 Overall");

            

            wsTableTwo.Cells["A1"].Value = "number of consultations:";
            wsTableTwo.Cells["A2"].Value = "number of SI students:";
            wsTableTwo.Cells["A3"].Value = "number of Non-SI students:";

            int NoOfConsultationsItem = 0;
            int NoOfSI_StudentsTabletwoItem = 0;
            int NoOfNonSI_StudentsTabletwoItem = 0;

            foreach (string str in checkedItems)
            {
                string projID = str;
                List<TableTwo> tableTwoList = db.TableTwos.Where(c => c.Project_ID == projID).ToList();
                foreach (var tableTwoIterator in tableTwoList)
                {
                    NoOfConsultationsItem += tableTwoIterator.NoOfConsultations;
                    NoOfSI_StudentsTabletwoItem += tableTwoIterator.NoOfSI_Students;
                    NoOfNonSI_StudentsTabletwoItem += tableTwoIterator.NoOfNonSI_Students;
                }
            }

            wsTableTwo.Cells["B1"].Value = NoOfConsultationsItem.ToString();
            wsTableTwo.Cells["B2"].Value = NoOfSI_StudentsTabletwoItem.ToString();
            wsTableTwo.Cells["B3"].Value = NoOfNonSI_StudentsTabletwoItem.ToString();

            ExcelWorksheet wsTableThree = pck.Workbook.Worksheets.Add("Table 3 Overall");
            

            wsTableThree.Cells["A3"].Value = "No of students at risk seen";
            wsTableThree.Cells["A4"].Value = "No of consulting(risk) ADO back on good academic standing";
            wsTableThree.Cells["A5"].Value = "No of consulting(risk) students who continued to be at risk";
            wsTableThree.Cells["A6"].Value = "No of student who were at risk at the end of semester 1";
            wsTableThree.Cells["A7"].Value = "No of consulting(risk) students who have moved to probation";
            wsTableThree.Cells["A8"].Value = "No of students on probation seen";
            wsTableThree.Cells["A9"].Value = "No of consulting students on probation meeting minimum requirements but continuing on probation";
            wsTableThree.Cells["A10"].Value = "No of consulting probation students who met their minimum requirements and have moved to at risk status";
            wsTableThree.Cells["A11"].Value = "No of consulting probation students who have been excluded";
            wsTableThree.Cells["A12"].Value = "No of consulting students who continued to be on good academic standing at the end of semester";

            wsTableThree.Cells["A1:H15"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            wsTableThree.Cells["A1:H15"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

            int No_of_students_at_risk_seenItem = 0;
            int No_of_risk_students_consulting_ADO_back_on_good_academic_standingItem = 0;
            int No_of_consulting_risk_students_who_continued_to_be_at_riskItem = 0;
            int No_of_student_who_were_at_risk_at_the_end_of_semester_1Item = 0;
            int No_of_consulting_risk_students_who_have_moved_to_probationItem = 0;
            int No_of_students_on_probation_seenItem = 0;
            int No_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probationItem = 0;
            int No_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_statusItem = 0;
            int No_of_consulting_probation_students_who_have_been_excludedItem = 0;
            int No_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semesterItem = 0;

            foreach (string str in checkedItems)
            {
                string projID = str;
                List<TableThree> tableThreeList = db.TableThrees.Where(c => c.Project_ID == projID).ToList();
                foreach (var riskItem in tableThreeList)
                {
                    No_of_students_at_risk_seenItem += riskItem.No_of_students_at_risk_seen;
                    No_of_risk_students_consulting_ADO_back_on_good_academic_standingItem += riskItem.No_of_risk_students_consulting_ADO_back_on_good_academic_standing;
                    No_of_consulting_risk_students_who_continued_to_be_at_riskItem += riskItem.No_of_consulting_risk_students_who_continued_to_be_at_risk;
                    No_of_student_who_were_at_risk_at_the_end_of_semester_1Item += riskItem.No_of_student_who_were_at_risk_at_the_end_of_semester_1;
                    No_of_consulting_risk_students_who_have_moved_to_probationItem += riskItem.No_of_consulting_risk_students_who_have_moved_to_probation;
                    No_of_students_on_probation_seenItem += riskItem.No_of_students_on_probation_seen;
                    No_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probationItem += riskItem.No_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation;
                    No_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_statusItem += riskItem.No_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status;
                    No_of_consulting_probation_students_who_have_been_excludedItem += riskItem.No_of_consulting_probation_students_who_have_been_excluded;
                    No_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semesterItem += riskItem.No_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester;
                }
            }

            wsTableThree.Cells["G3"].Value = No_of_students_at_risk_seenItem.ToString();
            wsTableThree.Cells["G4"].Value = No_of_risk_students_consulting_ADO_back_on_good_academic_standingItem.ToString();
            wsTableThree.Cells["G5"].Value = No_of_consulting_risk_students_who_continued_to_be_at_riskItem.ToString();
            wsTableThree.Cells["G6"].Value = No_of_student_who_were_at_risk_at_the_end_of_semester_1Item.ToString();
            wsTableThree.Cells["G7"].Value = No_of_consulting_risk_students_who_have_moved_to_probationItem.ToString();
            wsTableThree.Cells["G8"].Value = No_of_students_on_probation_seenItem.ToString();
            wsTableThree.Cells["G9"].Value = No_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probationItem.ToString();
            wsTableThree.Cells["G10"].Value = No_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_statusItem.ToString();
            wsTableThree.Cells["G11"].Value = No_of_consulting_probation_students_who_have_been_excludedItem.ToString();
            wsTableThree.Cells["G12"].Value = No_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semesterItem.ToString();

            
            wsTableThree.Cells["A18"].Value = "Beginning of the semester";
            wsTableThree.Cells["A19"].Value = "Green";
            wsTableThree.Cells["A20"].Value = "RISK/RISK2";
            wsTableThree.Cells["A21"].Value = "FPRR/FPMA";
            wsTableThree.Cells["A22"].Value = "PROB";
            wsTableThree.Cells["A23"].Value = "XNFA";

            int GreenBegItem = 0;
            int RISK_OR_RSK2BegItem = 0;
            int FPRR_OR_FPMABegItem = 0;
            int PROBBegItem = 0;
            int XNFABegItem = 0;

            foreach (string str in checkedItems)
            {
                string projID = str;
                List<TermDecisionsBeginning> TermDecisionBegList = db.TermDecisionBeginnings.Where(c => c.Project_ID == projID).ToList();
                foreach (var termsBeg in TermDecisionBegList)
                {
                    GreenBegItem += termsBeg.Green;
                    RISK_OR_RSK2BegItem += termsBeg.RISK_OR_RSK2;
                    FPRR_OR_FPMABegItem += termsBeg.FPRR_OR_FPMA;
                    PROBBegItem += termsBeg.PROB;
                    XNFABegItem += termsBeg.XNFA;
                }

            }

            wsTableThree.Cells["B19"].Value = GreenBegItem.ToString();
            wsTableThree.Cells["B20"].Value = RISK_OR_RSK2BegItem.ToString();
            wsTableThree.Cells["B21"].Value = FPRR_OR_FPMABegItem.ToString();
            wsTableThree.Cells["B22"].Value = PROBBegItem.ToString();
            wsTableThree.Cells["B23"].Value = XNFABegItem.ToString();

            
            wsTableThree.Cells["E18"].Value = "End of the semester";
            wsTableThree.Cells["E19"].Value = "Green";
            wsTableThree.Cells["E20"].Value = "RISK/RISK2";
            wsTableThree.Cells["E21"].Value = "FPRR/FPMA";
            wsTableThree.Cells["E22"].Value = "PROB";
            wsTableThree.Cells["E23"].Value = "XNFA";

            int GreenEndItem = 0;
            int RISK_OR_RSK2EndItem = 0;
            int FPRR_OR_FPMAEndItem = 0;
            int PROBEndItem = 0;
            int XNFAEndItem = 0;

            foreach (string str in checkedItems)
            {
                string projID = str;
                List<TermDecisionsEnd> TermDecisionEndList = db.TermDecisionEnds.Where(c => c.Project_ID == projID).ToList();
                foreach (var termsEnd in TermDecisionEndList)
                {
                    GreenEndItem += termsEnd.Green;
                    RISK_OR_RSK2EndItem += termsEnd.RISK_OR_RSK2;
                    FPRR_OR_FPMAEndItem += termsEnd.FPRR_OR_FPMA;
                    PROBEndItem += termsEnd.PROB;
                    XNFAEndItem += termsEnd.XNFA;
                }
            }

            wsTableThree.Cells["F19"].Value = GreenEndItem.ToString();
            wsTableThree.Cells["F20"].Value = RISK_OR_RSK2EndItem.ToString();
            wsTableThree.Cells["F21"].Value = FPRR_OR_FPMAEndItem.ToString();
            wsTableThree.Cells["F22"].Value = PROBEndItem.ToString();
            wsTableThree.Cells["F23"].Value = XNFAEndItem.ToString();

            //worksheet one
            foreach (var cell in ws.Cells["C1:C2"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            ws.Cells["C1:C2"].Style.Numberformat.Format = "0";

            foreach (var cell in ws.Cells["C3:C4"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            ws.Cells["C3:C4"].Style.Numberformat.Format = "0.00";

            foreach (var cell in ws.Cells["C6:C12"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            ws.Cells["C6:C12"].Style.Numberformat.Format = "0";


            foreach (var cell in ws.Cells["F1:F2"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            ws.Cells["F1:F2"].Style.Numberformat.Format = "0";

            foreach (var cell in ws.Cells["F3:F4"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            ws.Cells["F3:F4"].Style.Numberformat.Format = "0.00";

            foreach (var cell in ws.Cells["F6:F12"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            ws.Cells["F6:F12"].Style.Numberformat.Format = "0";

            foreach (var cell in ws.Cells["B18:B19"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            ws.Cells["B18:B19"].Style.Numberformat.Format = "0.00";

            foreach (var cell in ws.Cells["B16:B17"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            ws.Cells["B16:B17"].Style.Numberformat.Format = "0";

            //worksheet two
            foreach (var cell in wsTableTwo.Cells["B1:B3"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            wsTableTwo.Cells["B1:B3"].Style.Numberformat.Format = "0";

            //worksheet three
            foreach (var cell in wsTableThree.Cells["G3:G12"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            wsTableThree.Cells["G3:G12"].Style.Numberformat.Format = "0";

            foreach (var cell in wsTableThree.Cells["B19:B23"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            wsTableThree.Cells["B19:B23"].Style.Numberformat.Format = "0";

            foreach (var cell in wsTableThree.Cells["F19:F23"])
            {
                cell.Value = Convert.ToDecimal(cell.Value);
            }
            wsTableThree.Cells["F19:F23"].Style.Numberformat.Format = "0";

            //ws.Cells["A:AZ"].AutoFitColumns();
            //wsTableTwo.Cells["A:AZ"].AutoFitColumns();
            //wsTableThree.Cells["A:AZ"].AutoFitColumns();
            Context.Response.Clear();
            Context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Context.Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Context.Response.BinaryWrite(pck.GetAsByteArray());
            Context.Response.End();

        }
    }
}