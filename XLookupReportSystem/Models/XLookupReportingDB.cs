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
        public virtual DbSet<Project_Register> Project_Registers { get; set; }
        public virtual DbSet<ModuleData> ModuleDatas { get; set; }
        public virtual DbSet<Register_Attendance> Register_Attendances { get; set; }
        public virtual DbSet<NegativeTermDecisionsBeginning> NegativeTermDecisionBeginnings { get; set; }
        public virtual DbSet<NegativeTermDecisionsEnd> NegativeTermDecisionEnds { get; set; }
        public virtual DbSet<TableTwo> TableTwos { get; set; }
        public virtual DbSet<TableOne> TableOnes { get; set; }
        public virtual DbSet<TableThree> TableThrees { get; set; }
        public virtual DbSet<TableOneOverall> TableOneOveralls { get; set; }
        public virtual DbSet<TermDecisionsBeginning> TermDecisionBeginnings { get; set; }
        public virtual DbSet<TermDecisionsEnd> TermDecisionEnds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
