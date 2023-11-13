namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateDB : DbMigration
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
                        SI_Student = c.String(maxLength: 50),
                        Risk_Code_Beg = c.String(maxLength: 50),
                        Code_Beg = c.Int(nullable: false),
                        Risk_Code_End = c.String(maxLength: 50),
                        Code_End = c.Int(nullable: false),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ModuleData_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Project_ID = c.String(nullable: false, maxLength: 50),
                        ProjectName = c.String(maxLength: 50),
                        ProjectSemester = c.String(maxLength: 50),
                        ProjectCampus = c.String(maxLength: 50),
                        ProjectYear = c.String(maxLength: 50),
                        ModuleCode = c.String(maxLength: 50),
                        ProjectExcelRegister = c.Binary(),
                        ProjectExcelMainExamModuleData = c.Binary(),
                        ProjectExcelSuppExamModuleData = c.Binary(),
                        ProjectExcelNegativeTermDecisionsBeg = c.Binary(),
                        ProjectExcelNegativeTermDecisionsEnd = c.Binary(),
                        ProjectImg = c.Binary(),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                        User_ID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Project_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_ID = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Staff_ID = c.String(nullable: false, maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.User_ID)
                .ForeignKey("dbo.Staff", t => t.Staff_ID, cascadeDelete: true)
                .Index(t => t.Staff_ID);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Staff_ID = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        StaffType = c.String(maxLength: 50),
                        EmailAddress = c.String(maxLength: 50),
                        Campus = c.String(unicode: false, storeType: "text"),
                        StaffImg = c.Binary(),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Staff_ID);
            
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
            
            CreateTable(
                "dbo.Project_Register",
                c => new
                    {
                        Project_Register_ID = c.String(nullable: false, maxLength: 50),
                        RegisterName = c.String(maxLength: 50),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Project_Register_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.Register_Attendance",
                c => new
                    {
                        Register_Attendance_ID = c.String(nullable: false, maxLength: 50),
                        ModuleData_ID = c.String(maxLength: 50),
                        Project_Register_ID = c.String(maxLength: 50),
                        Attendance = c.Int(nullable: false),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Register_Attendance_ID)
                .ForeignKey("dbo.ModuleData", t => t.ModuleData_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .ForeignKey("dbo.Project_Register", t => t.Project_Register_ID)
                .Index(t => t.ModuleData_ID)
                .Index(t => t.Project_Register_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.Register",
                c => new
                    {
                        Register_ID = c.String(nullable: false, maxLength: 50),
                        Project_Register_ID = c.String(maxLength: 50),
                        StudentNumber = c.String(maxLength: 50),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Register_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .ForeignKey("dbo.Project_Register", t => t.Project_Register_ID)
                .Index(t => t.Project_Register_ID)
                .Index(t => t.Project_ID);
            
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
            DropForeignKey("dbo.TableTwo", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.TableThree", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.TableOne", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.TableOneOverall", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.Register", "Project_Register_ID", "dbo.Project_Register");
            DropForeignKey("dbo.Register", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.Register_Attendance", "Project_Register_ID", "dbo.Project_Register");
            DropForeignKey("dbo.Register_Attendance", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.Register_Attendance", "ModuleData_ID", "dbo.ModuleData");
            DropForeignKey("dbo.Project_Register", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.NegativeTermDecisionsEnd", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.NegativeTermDecisionsBeginning", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.ModuleData", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.Project", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Staff_ID", "dbo.Staff");
            DropIndex("dbo.TermDecisionsEnd", new[] { "Project_ID" });
            DropIndex("dbo.TermDecisionsBeginning", new[] { "Project_ID" });
            DropIndex("dbo.TableTwo", new[] { "Project_ID" });
            DropIndex("dbo.TableThree", new[] { "Project_ID" });
            DropIndex("dbo.TableOne", new[] { "Project_ID" });
            DropIndex("dbo.TableOneOverall", new[] { "Project_ID" });
            DropIndex("dbo.Register", new[] { "Project_ID" });
            DropIndex("dbo.Register", new[] { "Project_Register_ID" });
            DropIndex("dbo.Register_Attendance", new[] { "Project_ID" });
            DropIndex("dbo.Register_Attendance", new[] { "Project_Register_ID" });
            DropIndex("dbo.Register_Attendance", new[] { "ModuleData_ID" });
            DropIndex("dbo.Project_Register", new[] { "Project_ID" });
            DropIndex("dbo.NegativeTermDecisionsEnd", new[] { "Project_ID" });
            DropIndex("dbo.NegativeTermDecisionsBeginning", new[] { "Project_ID" });
            DropIndex("dbo.Users", new[] { "Staff_ID" });
            DropIndex("dbo.Project", new[] { "User_ID" });
            DropIndex("dbo.ModuleData", new[] { "Project_ID" });
            DropTable("dbo.TermDecisionsEnd");
            DropTable("dbo.TermDecisionsBeginning");
            DropTable("dbo.TableTwo");
            DropTable("dbo.TableThree");
            DropTable("dbo.TableOne");
            DropTable("dbo.TableOneOverall");
            DropTable("dbo.Register");
            DropTable("dbo.Register_Attendance");
            DropTable("dbo.Project_Register");
            DropTable("dbo.NegativeTermDecisionsEnd");
            DropTable("dbo.NegativeTermDecisionsBeginning");
            DropTable("dbo.Staff");
            DropTable("dbo.Users");
            DropTable("dbo.Project");
            DropTable("dbo.ModuleData");
        }
    }
}
