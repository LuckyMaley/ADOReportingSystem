namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [Key]
        [StringLength(50)]
        public string Staff_ID { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string StaffType { get; set; }

        [StringLength(50)]
        public string Discipline { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Column(TypeName = "text")]
        public string Campus { get; set; }

        public byte[] StaffImg { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }
    }
}
