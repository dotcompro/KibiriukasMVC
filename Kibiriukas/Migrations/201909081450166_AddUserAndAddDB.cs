namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAndAddDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        IsValidUser = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserAddModels",
                c => new
                    {
                        AddId = c.Int(nullable: false, identity: true),
                        AddTitle = c.String(),
                        AddDescription = c.String(),
                        IsAddActive = c.Boolean(nullable: false),
                        AddPrice = c.Single(nullable: false),
                        UserId = c.Int(nullable: false),
                        AddSubcategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddId)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddModels", "UserId", "dbo.UserModels");
            DropIndex("dbo.UserAddModels", new[] { "UserId" });
            DropTable("dbo.UserAddModels");
            DropTable("dbo.UserModels");
        }
    }
}
