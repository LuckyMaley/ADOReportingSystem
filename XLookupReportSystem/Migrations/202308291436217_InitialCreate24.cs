namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NegativeTermDecisionsBeginning",
                c => new
                    {
                        NegativeTermDecisionsBeg_ID = c.String(nullable: false, maxLength: 50),
                        StudentNumber = c.String(maxLength: 50),
                        RiskCodeBeg = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.NegativeTermDecisionsBeg_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.NegativeTermDecisionsEnd",
                c => new
                    {
                        NegativeTermDecisionsEnd_ID = c.String(nullable: false, maxLength: 50),
                        StudentNumber = c.String(maxLength: 50),
                        RiskCodeEnd = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.NegativeTermDecisionsEnd_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NegativeTermDecisionsEnd", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.NegativeTermDecisionsBeginning", "Project_ID", "dbo.Project");
            DropIndex("dbo.NegativeTermDecisionsEnd", new[] { "Project_ID" });
            DropIndex("dbo.NegativeTermDecisionsBeginning", new[] { "Project_ID" });
            DropTable("dbo.NegativeTermDecisionsEnd");
            DropTable("dbo.NegativeTermDecisionsBeginning");
        }
    }
}
