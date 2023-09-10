using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class NegativeTermDecisionsBegController
    {
        public static void AddNewBegNegTermDecision(string studentNumber, string riskCode, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newBegNegTermDecision = new NegativeTermDecisionsBeginning()
                {
                    NegativeTermDecisionsBeg_ID = Guid.NewGuid().ToString(),
                    StudentNumber = studentNumber,
                    RiskCodeBeg = riskCode,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Project_ID = projID

                };
                context.NegativeTermDecisionBeginnings.Add(newBegNegTermDecision);
                context.SaveChanges();
            }
        }

        public static List<NegativeTermDecisionsBeginning> AddNewBegNegTermDecisionList(string studentNumber, string riskCode, string projID, List<NegativeTermDecisionsBeginning> NegDecisionsBeg)
        {
            
            var newBegNegTermDecision = new NegativeTermDecisionsBeginning()
            {
                NegativeTermDecisionsBeg_ID = Guid.NewGuid().ToString(),
                StudentNumber = studentNumber,
                RiskCodeBeg = riskCode,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now,
                Project_ID = projID

            };
            NegDecisionsBeg.Add(newBegNegTermDecision);
            return NegDecisionsBeg;            
        }
    }
}