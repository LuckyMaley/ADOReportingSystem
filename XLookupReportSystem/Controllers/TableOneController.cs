using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class TableOneController
    {
        public static void AddNewTableOne(int noOfSI_Students, int noOfSI_Students_Passed, decimal si_Students_Pass_Rate, decimal averageSI_Students_Pass_Rate, int no_SI_Of_A_Symbols, int no_SI_Of_B_Symbols, int no_SI_Of_C_Symbols, int no_SI_Of_D_Symbols, int no_SI_Of_F_Symbols, int total_SI_Students, int noOfNon_SI_Students,  int noOfNon_SI_Students_Passed, decimal non_si_Students_Pass_Rate, decimal averageNon_SI_Students_Pass_Rate, int no_Non_SI_Of_A_Symbols, int no_Non_SI_Of_B_Symbols, int no_Non_SI_Of_C_Symbols, int no_Non_SI_Of_D_Symbols, int no_Non_SI_Of_F_Symbols, int total_Non_SI_Students, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newTableOne = new TableOne()
                {
                    TableOne_ID = Guid.NewGuid().ToString(),
                    NoOfSI_Students = noOfSI_Students,
                    NoOfSI_Students_Passed = noOfSI_Students_Passed,
                    SI_Students_Pass_Rate = si_Students_Pass_Rate,
                    AverageSI_Students_Pass_Rate = averageSI_Students_Pass_Rate,
                    No_SI_Of_A_Symbols = no_SI_Of_A_Symbols,
                    No_SI_Of_B_Symbols = no_SI_Of_B_Symbols,
                    No_SI_Of_C_Symbols = no_SI_Of_C_Symbols,
                    No_SI_Of_D_Symbols = no_SI_Of_D_Symbols,
                    No_SI_Of_F_Symbols = no_SI_Of_F_Symbols,
                    Total_SI_Students = total_SI_Students,
                    NoOfNon_SI_Students = noOfNon_SI_Students,
                    NoOfNon_SI_Students_Passed = noOfNon_SI_Students_Passed,
                    Non_SI_Students_Pass_Rate = non_si_Students_Pass_Rate,
                    AverageNon_SI_Students_Pass_Rate = averageNon_SI_Students_Pass_Rate,
                    No_Non_SI_Of_A_Symbols = no_Non_SI_Of_A_Symbols,
                    No_Non_SI_Of_B_Symbols = no_Non_SI_Of_B_Symbols,
                    No_Non_SI_Of_C_Symbols = no_Non_SI_Of_C_Symbols,
                    No_Non_SI_Of_D_Symbols = no_Non_SI_Of_D_Symbols,
                    No_Non_SI_Of_F_Symbols = no_Non_SI_Of_F_Symbols,
                    Total_Non_SI_Students = total_Non_SI_Students,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Project_ID = projID

                };
                context.TableOnes.Add(newTableOne);
                context.SaveChanges();
            }
        }
    }
}