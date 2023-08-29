namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Project", "User_ID", "dbo.Users");
            DropIndex("dbo.Project", new[] { "User_ID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Project", "User_ID");
            AddForeignKey("dbo.Project", "User_ID", "dbo.Users", "User_ID");
        }
    }
}
