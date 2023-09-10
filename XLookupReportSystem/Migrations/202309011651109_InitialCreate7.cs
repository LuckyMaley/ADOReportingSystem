namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ModuleData", "NegativeTermDecisionsBeg_ID", "dbo.NegativeTermDecisionsBeginning");
            DropForeignKey("dbo.ModuleData", "NegativeTermDecisionsEnd_ID", "dbo.NegativeTermDecisionsEnd");
            DropIndex("dbo.ModuleData", new[] { "NegativeTermDecisionsBeg_ID" });
            DropIndex("dbo.ModuleData", new[] { "NegativeTermDecisionsEnd_ID" });
            DropColumn("dbo.ModuleData", "NegativeTermDecisionsBeg_ID");
            DropColumn("dbo.ModuleData", "NegativeTermDecisionsEnd_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ModuleData", "NegativeTermDecisionsEnd_ID", c => c.String(maxLength: 50));
            AddColumn("dbo.ModuleData", "NegativeTermDecisionsBeg_ID", c => c.String(maxLength: 50));
            CreateIndex("dbo.ModuleData", "NegativeTermDecisionsEnd_ID");
            CreateIndex("dbo.ModuleData", "NegativeTermDecisionsBeg_ID");
            AddForeignKey("dbo.ModuleData", "NegativeTermDecisionsEnd_ID", "dbo.NegativeTermDecisionsEnd", "NegativeTermDecisionsEnd_ID");
            AddForeignKey("dbo.ModuleData", "NegativeTermDecisionsBeg_ID", "dbo.NegativeTermDecisionsBeginning", "NegativeTermDecisionsBeg_ID");
        }
    }
}
