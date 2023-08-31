namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableThree")]
    public class TableThree
    {
        [Key]
        [StringLength(50)]
        public string TableThree_ID { get; set; }

        public int No_of_students_at_risk_seen { get; set; }

        public int No_of_risk_students_consulting_ADO_back_on_good_academic_standing { get; set; }

        public int No_of_consulting_risk_students_who_continued_to_be_at_risk { get; set; }

        public int No_of_student_who_were_at_risk_at_the_end_of_semester_1 { get; set; }

        public int No_of_consulting_risk_students_who_have_moved_to_probation { get; set; }

        public int No_of_students_on_probation_seen { get; set; }

        public int No_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation { get; set; }

        public int No_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status { get; set; }

        public int No_of_consulting_probation_students_who_have_been_excluded { get; set; }

        public int No_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        public virtual Project Project { get; set; }
    }
}