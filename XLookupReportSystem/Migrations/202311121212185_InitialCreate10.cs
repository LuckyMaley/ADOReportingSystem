namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staff", "EmailAddress", c => c.String(maxLength: 50));
            DropColumn("dbo.Staff", "EmailAdress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staff", "EmailAdress", c => c.String(maxLength: 50));
            DropColumn("dbo.Staff", "EmailAddress");
        }
    }
}
