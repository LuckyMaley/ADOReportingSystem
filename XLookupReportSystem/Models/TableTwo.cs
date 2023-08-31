namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableTwo")]
    public class TableTwo
    {
        [Key]
        [StringLength(50)]
        public string TableTwo_ID { get; set; }

        
        public int NoOfConsultations { get; set; }

        
        public int NoOfSI_Students { get; set; }

        
        public int NoOfNonSI_Students { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        public virtual Project Project { get; set; }
    }
}