namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModuleData")]
    public class ModuleData
    {

        [Key]
        [StringLength(50)]
        public string ModuleData_ID { get; set; }

        [StringLength(50)]
        public string StudentNumber { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        
        public decimal ITSMainExamfinalMark { get; set; }

        
        public decimal SuppMark { get; set; }

        
        public decimal FinalMark { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        public virtual Project Project { get; set; }


    }
}