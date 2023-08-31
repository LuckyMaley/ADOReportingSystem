namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableOneOverall")]
    public class TableOneOverall
    {
        [Key]
        [StringLength(50)]
        public string TableOneOverall_ID { get; set; }

        public int NoOfOverallStudents { get; set; }

        public int NoOfOverallStudentsPassed { get; set; }

        public decimal Overall_Students_Pass_Rate { get; set; }

        public decimal AverageOverall_Students_Pass_Rate { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        public virtual Project Project { get; set; }
    }
}