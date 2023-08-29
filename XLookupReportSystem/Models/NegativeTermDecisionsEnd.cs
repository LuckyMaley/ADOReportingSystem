﻿namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NegativeTermDecisionsEnd")]
    public class NegativeTermDecisionsEnd
    {
        [Key]
        [StringLength(50)]
        public string NegativeTermDecisionsEnd_ID { get; set; }

        [StringLength(50)]
        public string StudentNumber { get; set; }

        [StringLength(50)]
        public string RiskCodeEnd { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        public virtual Project Project { get; set; }
    }
}