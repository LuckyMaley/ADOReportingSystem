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
        public string Country { get; set; }

        [Column(TypeName = "text")]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string EmailAdress { get; set; }

        [Column(TypeName = "text")]
        public string About { get; set; }

        [StringLength(50)]
        public string Job { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        public byte[] StaffImg { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }
    }
}
