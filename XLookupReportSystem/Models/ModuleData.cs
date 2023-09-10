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

        [StringLength(50)]
        public string SI_Student { get; set; }


        //[StringLength(50)]
        //public string NegativeTermDecisionsBeginning_ID { get; set; }

        [StringLength(50)]
        public string Risk_Code_Beg { get; set; }
        
        public int Code_Beg { get; set; }

        //[StringLength(50)]
        //public string NegativeTermDecisionsEnd_ID { get; set; }

        [StringLength(50)]
        public string Risk_Code_End { get; set; }

        public int Code_End { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        public virtual Project Project { get; set; }

        //public virtual NegativeTermDecisionsBeginning NegativeTermDecisionsBeginning { get; set; }

        //public virtual NegativeTermDecisionsEnd NegativeTermDecisionsEnd { get; set; }


    }
}