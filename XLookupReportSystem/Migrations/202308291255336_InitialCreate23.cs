namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModuleData",
                c => new
                    {
                        ModuleData_ID = c.String(nullable: false, maxLength: 50),
                        StudentNumber = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        ITSMainExamfinalMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SuppMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ModuleData_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModuleData", "Project_ID", "dbo.Project");
            DropIndex("dbo.ModuleData", new[] { "Project_ID" });
            DropTable("dbo.ModuleData");
        }
    }
}
