namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TermDecisionsBeginning")]
    public class TermDecisionsBeginning
    {
        [Key]
        [StringLength(50)]
        public string TermDecisionsBeginning_ID { get; set; }

        public int Green { get; set; }

        public int RISK_OR_RSK2 { get; set; }

        public int FPRR_OR_FPMA { get; set; }

        public int PROB { get; set; }

        public int XNFA { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        public virtual Project Project { get; set; }
    }
}