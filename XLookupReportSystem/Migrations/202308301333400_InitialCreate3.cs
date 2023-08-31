namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Register_Attendance", "Register_ID", "dbo.Register");
            DropIndex("dbo.Register_Attendance", new[] { "Register_ID" });
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
            
            AddColumn("dbo.ModuleData", "SI_Student", c => c.String(maxLength: 50));
            AddColumn("dbo.Register_Attendance", "ModuleData_ID", c => c.String(maxLength: 50));
            AddColumn("dbo.Register_Attendance", "Project_Register_ID", c => c.String(maxLength: 50));
            AddColumn("dbo.Register", "Project_Register_ID", c => c.String(maxLength: 50));
            AlterColumn("dbo.Register_Attendance", "Attendance", c => c.Int(nullable: false));
            CreateIndex("dbo.Register_Attendance", "ModuleData_ID");
            CreateIndex("dbo.Register_Attendance", "Project_Register_ID");
            CreateIndex("dbo.Register", "Project_Register_ID");
            AddForeignKey("dbo.Register_Attendance", "ModuleData_ID", "dbo.ModuleData", "ModuleData_ID");
            AddForeignKey("dbo.Register_Attendance", "Project_Register_ID", "dbo.Project_Register", "Project_Register_ID");
            AddForeignKey("dbo.Register", "Project_Register_ID", "dbo.Project_Register", "Project_Register_ID");
            DropColumn("dbo.Register_Attendance", "Register_ID");
            DropColumn("dbo.Register", "RegisterName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Register", "RegisterName", c => c.String(maxLength: 50));
            AddColumn("dbo.Register_Attendance", "Register_ID", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Register", "Project_Register_ID", "dbo.Project_Register");
            DropForeignKey("dbo.Register_Attendance", "Project_Register_ID", "dbo.Project_Register");
            DropForeignKey("dbo.Register_Attendance", "ModuleData_ID", "dbo.ModuleData");
            DropForeignKey("dbo.Project_Register", "Project_ID", "dbo.Project");
            DropIndex("dbo.Register", new[] { "Project_Register_ID" });
            DropIndex("dbo.Register_Attendance", new[] { "Project_Register_ID" });
            DropIndex("dbo.Register_Attendance", new[] { "ModuleData_ID" });
            DropIndex("dbo.Project_Register", new[] { "Project_ID" });
            AlterColumn("dbo.Register_Attendance", "Attendance", c => c.String(maxLength: 50));
            DropColumn("dbo.Register", "Project_Register_ID");
            DropColumn("dbo.Register_Attendance", "Project_Register_ID");
            DropColumn("dbo.Register_Attendance", "ModuleData_ID");
            DropColumn("dbo.ModuleData", "SI_Student");
            DropTable("dbo.Project_Register");
            CreateIndex("dbo.Register_Attendance", "Register_ID");
            AddForeignKey("dbo.Register_Attendance", "Register_ID", "dbo.Register", "Register_ID");
        }
    }
}
