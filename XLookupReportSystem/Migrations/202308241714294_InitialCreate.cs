namespace XLookupReportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Staff_ID = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        StaffType = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Address = c.String(unicode: false, storeType: "text"),
                        PhoneNumber = c.String(maxLength: 50),
                        EmailAdress = c.String(maxLength: 50),
                        About = c.String(unicode: false, storeType: "text"),
                        Job = c.String(maxLength: 50),
                        Company = c.String(maxLength: 50),
                        StaffImg = c.Binary(),
                        createdDate = c.DateTime(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Staff_ID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Staff_ID", "dbo.Staff");
            DropIndex("dbo.Users", new[] { "Staff_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Staff");
        }
    }
}
