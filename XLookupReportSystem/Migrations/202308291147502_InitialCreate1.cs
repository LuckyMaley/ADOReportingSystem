namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Project_ID = c.String(nullable: false, maxLength: 50),
                        ProjectName = c.String(maxLength: 50),
                        ProjectSemester = c.String(maxLength: 50),
                        ProjectYear = c.String(maxLength: 50),
                        ModuleCode = c.String(maxLength: 50),
                        ProjectImg = c.Binary(),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                        User_ID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Project_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Register_Attendance",
                c => new
                    {
                        Register_Attendance_ID = c.String(nullable: false, maxLength: 50),
                        Attendance = c.String(maxLength: 50),
                        Register_ID = c.String(maxLength: 50),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Register_Attendance_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .ForeignKey("dbo.Register", t => t.Register_ID)
                .Index(t => t.Register_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.Register",
                c => new
                    {
                        Register_ID = c.String(nullable: false, maxLength: 50),
                        RegisterName = c.String(maxLength: 50),
                        StudentNumber = c.String(maxLength: 50),
                        Project_ID = c.String(maxLength: 50),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Register_ID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Register_Attendance", "Register_ID", "dbo.Register");
            DropForeignKey("dbo.Register", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.Register_Attendance", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.Project", "User_ID", "dbo.Users");
            DropIndex("dbo.Register", new[] { "Project_ID" });
            DropIndex("dbo.Register_Attendance", new[] { "Project_ID" });
            DropIndex("dbo.Register_Attendance", new[] { "Register_ID" });
            DropIndex("dbo.Project", new[] { "User_ID" });
            DropTable("dbo.Register");
            DropTable("dbo.Register_Attendance");
            DropTable("dbo.Project");
        }
    }
}
