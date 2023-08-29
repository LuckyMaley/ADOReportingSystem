namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NegativeTermDecisionsBeginning")]
    public class NegativeTermDecisionsBeginning
    {
        [Key]
        [StringLength(50)]
        public string NegativeTermDecisionsBeg_ID { get; set; }

        [StringLength(50)]
        public string StudentNumber { get; set; }

        [StringLength(50)]
        public string RiskCodeBeg { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        public virtual Project Project { get; set; }
    }
}