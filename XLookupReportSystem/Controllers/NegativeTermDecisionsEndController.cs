using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class NegativeTermDecisionsEndController
    {
        public static void AddNewEndNegTermDecision(string studentNumber, string riskCode, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newEndNegTermDecision = new NegativeTermDecisionsEnd()
                {
                    NegativeTermDecisionsEnd_ID = Guid.NewGuid().ToString(),
                    StudentNumber = studentNumber,
                    RiskCodeEnd = riskCode,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Project_ID = projID

                };
                context.NegativeTermDecisionEnds.Add(newEndNegTermDecision);
                context.SaveChanges();
            }
        }

        public static List<NegativeTermDecisionsEnd> AddNewEndNegTermDecisionList(string studentNumber, string riskCode, string projID, List<NegativeTermDecisionsEnd> NegDecisionsEnd)
        {
            var newEndNegTermDecision = new NegativeTermDecisionsEnd()
            {
                NegativeTermDecisionsEnd_ID = Guid.NewGuid().ToString(),
                StudentNumber = studentNumber,
                RiskCodeEnd = riskCode,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now,
                Project_ID = projID

            };
            NegDecisionsEnd.Add(newEndNegTermDecision);
            return NegDecisionsEnd;
        }
    }
}