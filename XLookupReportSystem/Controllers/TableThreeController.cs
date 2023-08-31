using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XLookupReportSystem.Models;

namespace XLookupReportSystem.Controllers
{
    public class TableThreeController
    {
        public static void AddNewTableThree(int no_of_students_at_risk_seen, int no_of_risk_students_consulting_ADO_back_on_good_academic_standing, int no_of_consulting_risk_students_who_continued_to_be_at_risk, int no_of_student_who_were_at_risk_at_the_end_of_semester_1, int no_of_consulting_risk_students_who_have_moved_to_probation, int no_of_students_on_probation_seen, int no_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation, int no_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status, int no_of_consulting_probation_students_who_have_been_excluded, int no_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester, string projID)
        {
            using (var context = new XLookupReportingDB())
            {
                var newTableThree = new TableThree()
                {
                    TableThree_ID = Guid.NewGuid().ToString(),
                    No_of_students_at_risk_seen = no_of_students_at_risk_seen,
                    No_of_risk_students_consulting_ADO_back_on_good_academic_standing = no_of_risk_students_consulting_ADO_back_on_good_academic_standing,
                    No_of_consulting_risk_students_who_continued_to_be_at_risk = no_of_consulting_risk_students_who_continued_to_be_at_risk,
                    No_of_student_who_were_at_risk_at_the_end_of_semester_1 = no_of_student_who_were_at_risk_at_the_end_of_semester_1,
                    No_of_consulting_risk_students_who_have_moved_to_probation = no_of_consulting_risk_students_who_have_moved_to_probation,
                    No_of_students_on_probation_seen = no_of_students_on_probation_seen,
                    No_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation = no_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation,
                    No_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status = no_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status,
                    No_of_consulting_probation_students_who_have_been_excluded = no_of_consulting_probation_students_who_have_been_excluded,
                    No_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester = no_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    Project_ID = projID

                };
                context.TableThrees.Add(newTableThree);
                context.SaveChanges();
            }
        }
    }
}