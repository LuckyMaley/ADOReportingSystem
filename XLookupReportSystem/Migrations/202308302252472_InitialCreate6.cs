namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TableOneOverall",
                c => new
                    {
                        TableOneOverall_ID = c.String(nullable: false, maxLength: 50),
                        NoOfOverallStudents = c.Int(nullable: false),
                        NoOfOverallStudentsPassed = c.Int(nullable: false),
                        Overall_Students_Pass_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageOverall_Students_Pass_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TableOneOverall_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.TermDecisionsBeginning",
                c => new
                    {
                        TermDecisionsBeginning_ID = c.String(nullable: false, maxLength: 50),
                        Green = c.Int(nullable: false),
                        RISK_OR_RSK2 = c.Int(nullable: false),
                        FPRR_OR_FPMA = c.Int(nullable: false),
                        PROB = c.Int(nullable: false),
                        XNFA = c.Int(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TermDecisionsBeginning_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.TermDecisionsEnd",
                c => new
                    {
                        TermDecisionsEnd_ID = c.String(nullable: false, maxLength: 50),
                        Green = c.Int(nullable: false),
                        RISK_OR_RSK2 = c.Int(nullable: false),
                        FPRR_OR_FPMA = c.Int(nullable: false),
                        PROB = c.Int(nullable: false),
                        XNFA = c.Int(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TermDecisionsEnd_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermDecisionsEnd", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.TermDecisionsBeginning", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.TableOneOverall", "Project_ID", "dbo.Project");
            DropIndex("dbo.TermDecisionsEnd", new[] { "Project_ID" });
            DropIndex("dbo.TermDecisionsBeginning", new[] { "Project_ID" });
            DropIndex("dbo.TableOneOverall", new[] { "Project_ID" });
            DropTable("dbo.TermDecisionsEnd");
            DropTable("dbo.TermDecisionsBeginning");
            DropTable("dbo.TableOneOverall");
        }
    }
}
