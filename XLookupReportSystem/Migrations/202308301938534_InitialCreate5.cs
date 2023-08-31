namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TableOne",
                c => new
                    {
                        TableOne_ID = c.String(nullable: false, maxLength: 50),
                        NoOfSI_Students = c.Int(nullable: false),
                        NoOfSI_Students_Passed = c.Int(nullable: false),
                        SI_Students_Pass_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageSI_Students_Pass_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        No_SI_Of_A_Symbols = c.Int(nullable: false),
                        No_SI_Of_B_Symbols = c.Int(nullable: false),
                        No_SI_Of_C_Symbols = c.Int(nullable: false),
                        No_SI_Of_D_Symbols = c.Int(nullable: false),
                        No_SI_Of_F_Symbols = c.Int(nullable: false),
                        Total_SI_Students = c.Int(nullable: false),
                        NoOfNon_SI_Students = c.Int(nullable: false),
                        NoOfNon_SI_Students_Passed = c.Int(nullable: false),
                        Non_SI_Students_Pass_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageNon_SI_Students_Pass_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        No_Non_SI_Of_A_Symbols = c.Int(nullable: false),
                        No_Non_SI_Of_B_Symbols = c.Int(nullable: false),
                        No_Non_SI_Of_C_Symbols = c.Int(nullable: false),
                        No_Non_SI_Of_D_Symbols = c.Int(nullable: false),
                        No_Non_SI_Of_F_Symbols = c.Int(nullable: false),
                        Total_Non_SI_Students = c.Int(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TableOne_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.TableThree",
                c => new
                    {
                        TableThree_ID = c.String(nullable: false, maxLength: 50),
                        No_of_students_at_risk_seen = c.Int(nullable: false),
                        No_of_risk_students_consulting_ADO_back_on_good_academic_standing = c.Int(nullable: false),
                        No_of_consulting_risk_students_who_continued_to_be_at_risk = c.Int(nullable: false),
                        No_of_student_who_were_at_risk_at_the_end_of_semester_1 = c.Int(nullable: false),
                        No_of_consulting_risk_students_who_have_moved_to_probation = c.Int(nullable: false),
                        No_of_students_on_probation_seen = c.Int(nullable: false),
                        No_of_consulting_students_on_probation_meeting_minimum_requirements_but_continuing_on_probation = c.Int(nullable: false),
                        No_of_consulting_probation_students_who_met_their_minimum_requirements_and_have_moved_to_at_risk_status = c.Int(nullable: false),
                        No_of_consulting_probation_students_who_have_been_excluded = c.Int(nullable: false),
                        No_of_consulting_students_who_continued_to_be_on_good_academic_standing_at_the_end_of_semester = c.Int(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TableThree_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.TableTwo",
                c => new
                    {
                        TableTwo_ID = c.String(nullable: false, maxLength: 50),
                        NoOfConsultations = c.Int(nullable: false),
                        NoOfSI_Students = c.Int(nullable: false),
                        NoOfNonSI_Students = c.Int(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TableTwo_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            AddColumn("dbo.ModuleData", "NegativeTermDecisionsBeg_ID", c => c.String(maxLength: 50));
            AddColumn("dbo.ModuleData", "Risk_Code_Beg", c => c.String(maxLength: 50));
            AddColumn("dbo.ModuleData", "Code_Beg", c => c.Int(nullable: false));
            AddColumn("dbo.ModuleData", "NegativeTermDecisionsEnd_ID", c => c.String(maxLength: 50));
            AddColumn("dbo.ModuleData", "Risk_Code_End", c => c.String(maxLength: 50));
            AddColumn("dbo.ModuleData", "Code_End", c => c.Int(nullable: false));
            CreateIndex("dbo.ModuleData", "NegativeTermDecisionsBeg_ID");
            CreateIndex("dbo.ModuleData", "NegativeTermDecisionsEnd_ID");
            AddForeignKey("dbo.ModuleData", "NegativeTermDecisionsBeg_ID", "dbo.NegativeTermDecisionsBeginning", "NegativeTermDecisionsBeg_ID");
            AddForeignKey("dbo.ModuleData", "NegativeTermDecisionsEnd_ID", "dbo.NegativeTermDecisionsEnd", "NegativeTermDecisionsEnd_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TableTwo", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.TableThree", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.TableOne", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.ModuleData", "NegativeTermDecisionsEnd_ID", "dbo.NegativeTermDecisionsEnd");
            DropForeignKey("dbo.ModuleData", "NegativeTermDecisionsBeg_ID", "dbo.NegativeTermDecisionsBeginning");
            DropIndex("dbo.TableTwo", new[] { "Project_ID" });
            DropIndex("dbo.TableThree", new[] { "Project_ID" });
            DropIndex("dbo.TableOne", new[] { "Project_ID" });
            DropIndex("dbo.ModuleData", new[] { "NegativeTermDecisionsEnd_ID" });
            DropIndex("dbo.ModuleData", new[] { "NegativeTermDecisionsBeg_ID" });
            DropColumn("dbo.ModuleData", "Code_End");
            DropColumn("dbo.ModuleData", "Risk_Code_End");
            DropColumn("dbo.ModuleData", "NegativeTermDecisionsEnd_ID");
            DropColumn("dbo.ModuleData", "Code_Beg");
            DropColumn("dbo.ModuleData", "Risk_Code_Beg");
            DropColumn("dbo.ModuleData", "NegativeTermDecisionsBeg_ID");
            DropTable("dbo.TableTwo");
            DropTable("dbo.TableThree");
            DropTable("dbo.TableOne");
        }
    }
}
