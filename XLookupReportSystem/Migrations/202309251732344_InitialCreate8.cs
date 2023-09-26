namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "ProjectExcelRegister", c => c.Binary());
            AddColumn("dbo.Project", "ProjectExcelMainExamModuleData", c => c.Binary());
            AddColumn("dbo.Project", "ProjectExcelSuppExamModuleData", c => c.Binary());
            AddColumn("dbo.Project", "ProjectExcelNegativeTermDecisionsBeg", c => c.Binary());
            AddColumn("dbo.Project", "ProjectExcelNegativeTermDecisionsEnd", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "ProjectExcelNegativeTermDecisionsEnd");
            DropColumn("dbo.Project", "ProjectExcelNegativeTermDecisionsBeg");
            DropColumn("dbo.Project", "ProjectExcelSuppExamModuleData");
            DropColumn("dbo.Project", "ProjectExcelMainExamModuleData");
            DropColumn("dbo.Project", "ProjectExcelRegister");
        }
    }
}
