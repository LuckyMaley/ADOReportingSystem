﻿namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Register_Attendance")]    
    public class Register_Attendance
    {
        [Key]
        [StringLength(50)]
        public string Register_Attendance_ID { get; set; }

        [StringLength(50)]
        public string ModuleData_ID { get; set; }

        [StringLength(50)]
        public string Project_Register_ID { get; set; }

        
        public int Attendance { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        public virtual Project Project { get; set; }

        public virtual Project_Register Project_Register { get; set; }

        public virtual ModuleData ModuleData { get; set; }
    }
}