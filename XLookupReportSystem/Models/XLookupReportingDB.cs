namespace XLookupReportSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class XLookupReportingDB : DbContext
    {
        public XLookupReportingDB()
            : base("name=XLookupReportingDB")
        {
        }

        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<ModuleData> ModuleDatas { get; set; }
        public virtual DbSet<Register_Attendance> Register_Attendances { get; set; }
        public virtual DbSet<NegativeTermDecisionsBeginning> NegativeTermDecisionBeginnings { get; set; }
        public virtual DbSet<NegativeTermDecisionsEnd> NegativeTermDecisionEnds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
