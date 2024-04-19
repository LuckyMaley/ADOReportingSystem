namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staff", "Discipline", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staff", "Discipline");
        }
    }
}
