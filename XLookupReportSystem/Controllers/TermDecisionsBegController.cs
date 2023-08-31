using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class TermDecisionsBegController
    {
        public static void AddNewTermDecisionsBeg(int green, int risk_or_rsk2, int fprr_or_fpma, int prob, int xnfa, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newTermDecisionsBeg = new TermDecisionsBeginning()
                {
                    TermDecisionsBeginning_ID = Guid.NewGuid().ToString(),
                    Green = green,
                    RISK_OR_RSK2 = risk_or_rsk2,
                    FPRR_OR_FPMA = fprr_or_fpma,
                    PROB = prob,
                    XNFA = xnfa,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Project_ID = projID

                };
                context.TermDecisionBeginnings.Add(newTermDecisionsBeg);
                context.SaveChanges();
            }
        }
    }
}