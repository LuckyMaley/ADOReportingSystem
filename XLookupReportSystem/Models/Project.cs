namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public class Project
    {
        [Key]
        [StringLength(50)]
        public string Project_ID { get; set; }

        [StringLength(50)]
        public string ProjectName { get; set; }

        [StringLength(50)]
        public string ProjectSemester { get; set; }

        [StringLength(50)]
        public string ProjectCampus { get; set; }

        [StringLength(50)]
        public string ProjectYear { get; set; }

        [StringLength(50)]
        public string ModuleCode { get; set; }

        public byte[] ProjectExcelRegister { get; set; }

        public byte[] ProjectExcelMainExamModuleData { get; set; }

        public byte[] ProjectExcelSuppExamModuleData { get; set; }

        public byte[] ProjectExcelNegativeTermDecisionsBeg { get; set; }

        public byte[] ProjectExcelNegativeTermDecisionsEnd { get; set; }

        public byte[] ProjectImg { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        [StringLength(50)]
        public string User_ID { get; set; }

        public virtual User User { get; set; }
    }
}