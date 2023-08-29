using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XLookupReportSystem.Controllers;

namespace XLookupReportSystem.Admin
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Createbtn_Click(object sender, EventArgs e)
        {
            string ProjID = ProjectController.AddNewProject(UserController.getUserID(Context.User.Identity.Name), ProjectName.Text, SemesterCBTxt.Text, SelectYearCBTxt.Text, SelectModuleTxt.Text);

            if (UploadRegister.HasFile == true)
            {
                //String contenttype = UploadRegister.PostedFile.ContentType;

                //if (contenttype == "image/jpeg")
                //{
                //}

                //inserting project and Registers 
                int UploadReglength = UploadRegister.PostedFile.ContentLength;
                byte[] fileBytes = new byte[UploadReglength];
                var data = UploadRegister.PostedFile.InputStream.Read(fileBytes, 0, Convert.ToInt32(UploadRegister.PostedFile.ContentLength));
                using (var package = new ExcelPackage(UploadRegister.PostedFile.InputStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var currentsheet = package.Workbook.Worksheets;
                    foreach (ExcelWorksheet worksheet in currentsheet)
                    {
                        var noOfCol = worksheet.Dimension.End.Column;
                        var noOfRow = worksheet.Dimension.End.Row;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            RegisterController.AddNewRegister(worksheet.Name, worksheet.Cells[rowIterator, 1].Value.ToString(), ProjID);
                        }
                    }
                }
            }
            //Inserting Module Data and supp data
            if (UploadSuppModuleData.HasFile == true)
            {
                int UploadModulelength = UploadModuleData.PostedFile.ContentLength;
                byte[] fileBytesModule = new byte[UploadModulelength];
                var dataModule = UploadModuleData.PostedFile.InputStream.Read(fileBytesModule, 0, Convert.ToInt32(UploadModuleData.PostedFile.ContentLength));

                int UploadSuppModulelength = UploadSuppModuleData.PostedFile.ContentLength;
                byte[] fileBytesSupp = new byte[UploadSuppModulelength];
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
                        else {
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
                                if (currentsheet.Cells[rowIterator1, 4].Value == null || currentsheet.Cells[rowIterator1,4].Value.ToString() == "")
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
                byte[] fileBytesModule = new byte[UploadModulelength];
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

            if (UploadRiskCodeBeg.HasFile == true)
            {
                //String contenttype = UploadRegister.PostedFile.ContentType;

                //if (contenttype == "image/jpeg")
                //{
                //}

                //inserting risk codes beginning 
                int UploadRiskBeglength = UploadRiskCodeBeg.PostedFile.ContentLength;
                byte[] fileBytesRiskBeg = new byte[UploadRiskBeglength];
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
                                if ( worksheet.Cells[rowIterator, 3].Value == null || worksheet.Cells[rowIterator, 3].Value.ToString() == "")
                                {
                                    studentnum = worksheet.Cells[rowIterator - 1, 3].Value.ToString();
                                }
                                else
                                {
                                    studentnum = worksheet.Cells[rowIterator, 3].Value.ToString();
                                }
                                NegativeTermDecisionsBegController.AddNewBegNegTermDecision(studentnum, worksheet.Cells[rowIterator, 10].Value.ToString(), ProjID);
                            }
                        }
                    }
                }
            }

            if (UploadRiskCodeEnd.HasFile == true)
            {
                //String contenttype = UploadRegister.PostedFile.ContentType;

                //if (contenttype == "image/jpeg")
                //{
                //}

                //inserting risk codes beginning 
                int UploadRiskEndlength = UploadRiskCodeEnd.PostedFile.ContentLength;
                byte[] fileBytesRiskEnd = new byte[UploadRiskEndlength];
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
                                if (worksheet.Cells[rowIterator, 3].Value == null || worksheet.Cells[rowIterator, 3].Value.ToString()=="")
                                {
                                    studentnum = worksheet.Cells[rowIterator - 1, 3].Value.ToString();
                                }
                                else
                                {
                                    studentnum = worksheet.Cells[rowIterator, 3].Value.ToString();
                                }
                                NegativeTermDecisionsEndController.AddNewEndNegTermDecision(studentnum, worksheet.Cells[rowIterator, 10].Value.ToString(), ProjID);
                            }
                        }
                    }
                }
            }

        }
    }
}