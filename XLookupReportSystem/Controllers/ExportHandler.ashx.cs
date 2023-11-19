using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    /// <summary>
    /// Summary description for ExportHandler
    /// </summary>
    public class ExportHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string projID = context.Request.QueryString["projID"];
            XLookupReportingDB db = new Models.XLookupReportingDB();
            List<TableOne> TableOneList = db.TableOnes.Where(x => x.Project_ID == projID).ToList();
            List<ModuleData> ModuleDataList = db.ModuleDatas.Where(x => x.Project_ID == projID).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet wsClass = pck.Workbook.Worksheets.Add("Classlist");

            wsClass.Cells["A1"].Value = "Student Number";
            wsClass.Cells["B1"].Value = "Firstname";
            wsClass.Cells["C1"].Value = "Surname";
            wsClass.Cells["D1"].Value = "SI Student";
            wsClass.Cells["E1"].Value = "ITS Final Mark";
            wsClass.Cells["F1"].Value = "Supp Mark";
            wsClass.Cells["G1"].Value = "Final Mark";
            wsClass.Cells["H1"].Value = "Term Decision Beginning";
            wsClass.Cells["I1"].Value = "Risk Code Beginning";
            wsClass.Cells["J1"].Value = "Term Decision End";
            wsClass.Cells["K1"].Value = "Risk Code End";
            wsClass.Cells["A1:K1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            wsClass.Cells["A1:K1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkBlue);
            wsClass.Cells["A1:K1"].Style.Font.Color.SetColor(System.Drawing.Color.White);

            for(int i = 0; i< ModuleDataList.Count; i++)
            {
                wsClass.Cells["A"+(2 +i).ToString()].Value = Convert.ToDecimal(ModuleDataList[i].StudentNumber);
                wsClass.Cells["A" + (2 + i).ToString()].Style.Numberformat.Format = "0";
                wsClass.Cells["B" + (2 + i).ToString()].Value = ModuleDataList[i].FirstName;
                wsClass.Cells["C" + (2 + i).ToString()].Value = ModuleDataList[i].Surname;
                wsClass.Cells["D" + (2 + i).ToString()].Value = ModuleDataList[i].SI_Student;
                wsClass.Cells["E" + (2 + i).ToString()].Value = Convert.ToDecimal(ModuleDataList[i].ITSMainExamfinalMark);
                wsClass.Cells["E" + (2 + i).ToString()].Style.Numberformat.Format = "0.00";
                wsClass.Cells["F" + (2 + i).ToString()].Value = Convert.ToDecimal(ModuleDataList[i].SuppMark);
                wsClass.Cells["F" + (2 + i).ToString()].Style.Numberformat.Format = "0.00";
                wsClass.Cells["G" + (2 + i).ToString()].Value = Convert.ToDecimal(ModuleDataList[i].FinalMark);
                wsClass.Cells["G" + (2 + i).ToString()].Style.Numberformat.Format = "0.00";
                wsClass.Cells["H" + (2 + i).ToString()].Value = ModuleDataList[i].Risk_Code_Beg;
                wsClass.Cells["I" + (2 + i).ToString()].Value = Convert.ToDecimal(ModuleDataList[i].Code_Beg);
                wsClass.Cells["I" + (2 + i).ToString()].Style.Numberformat.Format = "0";
                wsClass.Cells["J" + (2 + i).ToString()].Value = ModuleDataList[i].Risk_Code_End;
                wsClass.Cells["K" + (2 + i).ToString()].Value = Convert.ToDecimal(ModuleDataList[i].Code_End);
                wsClass.Cells["K" + (2 + i).ToString()].Style.Numberformat.Format = "0";
            }

            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Table 1");

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

            foreach (var item in TableOneList)
            {
                ws.Cells["C1"].Value = item.NoOfSI_Students.ToString();
                ws.Cells["C2"].Value = item.NoOfSI_Students_Passed.ToString();
                ws.Cells["C3"].Value = item.SI_Students_Pass_Rate.ToString();
                ws.Cells["C4"].Value = item.AverageSI_Students_Pass_Rate.ToString();

                ws.Cells["C6"].Value = item.No_SI_Of_A_Symbols.ToString();
                ws.Cells["C7"].Value = item.No_SI_Of_B_Symbols.ToString();
                ws.Cells["C8"].Value = item.No_SI_Of_C_Symbols.ToString();
                ws.Cells["C9"].Value = item.No_SI_Of_D_Symbols.ToString();
                ws.Cells["C10"].Value = item.No_SI_Of_F_Symbols.ToString();

                ws.Cells["C12"].Value = item.Total_SI_Students.ToString();

                ws.Cells["F1"].Value = item.NoOfNon_SI_Students.ToString();
                ws.Cells["F2"].Value = item.NoOfNon_SI_Students_Passed.ToString();
                ws.Cells["F3"].Value = item.Non_SI_Students_Pass_Rate.ToString();
                ws.Cells["F4"].Value = item.AverageNon_SI_Students_Pass_Rate.ToString();

                ws.Cells["F6"].Value = item.No_Non_SI_Of_A_Symbols.ToString();
                ws.Cells["F7"].Value = item.No_Non_SI_Of_B_Symbols.ToString();
                ws.Cells["F8"].Value = item.No_Non_SI_Of_C_Symbols.ToString();
                ws.Cells["F9"].Value = item.No_Non_SI_Of_D_Symbols.ToString();
                ws.Cells["F10"].Value = item.No_Non_SI_Of_F_Symbols.ToString();

                ws.Cells["F12"].Value = item.Total_Non_SI_Students.ToString();
            }

            List<TableOneOverall> overallDataList = db.TableOneOveralls.Where(c => c.Project_ID == projID).ToList();
            foreach(var modData in overallDataList)
            {
                ws.Cells["B16"].Value = modData.NoOfOverallStudents.ToString();
                ws.Cells["B17"].Value = modData.NoOfOverallStudentsPassed.ToString();
                ws.Cells["B18"].Value = modData.Overall_Students_Pass_Rate.ToString();
                ws.Cells["B19"].Value = modData.AverageOverall_Students_Pass_Rate.ToString();
            }

            ExcelWorksheet wsTableTwo = pck.Workbook.Worksheets.Add("Table 2");
            List<TableTwo> tableTwoList = db.TableTwos.Where(c => c.Project_ID == projID).ToList();

            wsTableTwo.Cells["A1"].Value = "number of consultations:";
            wsTableTwo.Cells["A2"].Value = "number of SI students:";
            wsTableTwo.Cells["A3"].Value = "number of Non-SI students:";

            foreach (var tableTwoIterator in tableTwoList)
            {
                wsTableTwo.Cells["B1"].Value = tableTwoIterator.NoOfConsultations.ToString();
                wsTableTwo.Cells["B2"].Value = tableTwoIterator.NoOfSI_Students.ToString();
                wsTableTwo.Cells["B3"].Value = tableTwoIterator.NoOfNonSI_Students.ToString();
            }


           ExcelWorksheet wsTableThree = pck.Workbook.Worksheets.Add("Table 3");
            List<TableThree> tableThreeList = db.TableThrees.Where(c => c.Project_ID == projID).ToList();

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
            foreach (var riskItem in tableThreeList)
            {
                wsTableThree.Cells["G3"].Value = riskItem.No_of_students_at_risk_seen.ToString();
                wsTableThree.Cells["G4"].Value = riskItem.No_of_risk_students_consulting_ADO_back_on_good_academic_standing.ToString();
                wsTableThree.Cells["G5"].Value = riskItem.No_of_consulting_risk_students_who_continued_to_be_at_risk.ToString();
                wsTableThree.Cells["G6"].Value = riskItem.No_of_student_who_were_at_risk_at_the_end_of_semester_1.ToString();
                wsTableThree.Cells["G7"].Value = riskItem.No_of_consulting_risk_students_who_have_moved_to_probation.ToString();
                wsTableThree.Cells["G8"].Value = riskItem.No_of_students_on_probation_seen.ToString();
                wsTableThree.Cells["G9"].Value = riskItem.No_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation.ToString();
                wsTableThree.Cells["G10"].Value = riskItem.No_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status.ToString();
                wsTableThree.Cells["G11"].Value = riskItem.No_of_consulting_probation_students_who_have_been_excluded.ToString();
                wsTableThree.Cells["G12"].Value = riskItem.No_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester.ToString();
            }

            List<TermDecisionsBeginning> TermDecisionBegList = db.TermDecisionBeginnings.Where(c => c.Project_ID == projID).ToList();
            wsTableThree.Cells["A18"].Value = "Beginning of the semester";
            wsTableThree.Cells["A19"].Value = "Green";
            wsTableThree.Cells["A20"].Value = "RISK/RISK2";
            wsTableThree.Cells["A21"].Value = "FPRR/FPMA";
            wsTableThree.Cells["A22"].Value = "PROB";
            wsTableThree.Cells["A23"].Value = "XNFA";
            
            foreach (var termsBeg in TermDecisionBegList)
            {
                wsTableThree.Cells["B19"].Value = termsBeg.Green.ToString();
                wsTableThree.Cells["B20"].Value = termsBeg.RISK_OR_RSK2.ToString();
                wsTableThree.Cells["B21"].Value = termsBeg.FPRR_OR_FPMA.ToString();
                wsTableThree.Cells["B22"].Value = termsBeg.PROB.ToString();
                wsTableThree.Cells["B23"].Value = termsBeg.XNFA.ToString();
            }

            List<TermDecisionsEnd> TermDecisionEndList = db.TermDecisionEnds.Where(c => c.Project_ID == projID).ToList();
            wsTableThree.Cells["E18"].Value = "End of the semester";
            wsTableThree.Cells["E19"].Value = "Green";
            wsTableThree.Cells["E20"].Value = "RISK/RISK2";
            wsTableThree.Cells["E21"].Value = "FPRR/FPMA";
            wsTableThree.Cells["E22"].Value = "PROB";
            wsTableThree.Cells["E23"].Value = "XNFA";

            foreach (var termsEnd in TermDecisionEndList)
            {
                wsTableThree.Cells["F19"].Value = termsEnd.Green.ToString();
                wsTableThree.Cells["F20"].Value = termsEnd.RISK_OR_RSK2.ToString();
                wsTableThree.Cells["F21"].Value = termsEnd.FPRR_OR_FPMA.ToString();
                wsTableThree.Cells["F22"].Value = termsEnd.PROB.ToString();
                wsTableThree.Cells["F23"].Value = termsEnd.XNFA.ToString();
            }
             

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
            context.Response.Clear();
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            context.Response.AppendHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            context.Response.BinaryWrite(pck.GetAsByteArray());
            context.Response.Flush();
           
            //string htmlResponse = @"<html><head><!-- Optionally, you can include JavaScript to automatically trigger the redirection after a delay --><script>setTimeout(function() {window.location.href = '../Admin/ProjectView.aspx?projID=" + projID + "'; }, 3000); // Delay for 3 seconds (optional)</script></head><body><p>Your download will start shortly. If it doesn't, please <a href='../Admin/ProjectView.aspx?projID=" + projID + "'>click here</a>.</p></body></html>";
            //context.Response.Write(htmlResponse);
            //context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}