namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "ProjectCampus", c => c.String(maxLength: 50));
            AddColumn("dbo.Staff", "Campus", c => c.String(unicode: false, storeType: "text"));
            DropColumn("dbo.Staff", "Country");
            DropColumn("dbo.Staff", "Address");
            DropColumn("dbo.Staff", "PhoneNumber");
            DropColumn("dbo.Staff", "About");
            DropColumn("dbo.Staff", "Job");
            DropColumn("dbo.Staff", "Company");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staff", "Company", c => c.String(maxLength: 50));
            AddColumn("dbo.Staff", "Job", c => c.String(maxLength: 50));
            AddColumn("dbo.Staff", "About", c => c.String(unicode: false, storeType: "text"));
            AddColumn("dbo.Staff", "PhoneNumber", c => c.String(maxLength: 50));
            AddColumn("dbo.Staff", "Address", c => c.String(unicode: false, storeType: "text"));
            AddColumn("dbo.Staff", "Country", c => c.String(maxLength: 50));
            DropColumn("dbo.Staff", "Campus");
            DropColumn("dbo.Project", "ProjectCampus");
        }
    }
}
