namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserAddModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAddModels", "UserId", "dbo.UserModels");
            DropIndex("dbo.UserAddModels", new[] { "UserId" });
            DropTable("dbo.UserAddModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAddModels",
                c => new
                    {
                        AddId = c.Int(nullable: false, identity: true),
                        AddTitle = c.String(nullable: false),
                        AddDescription = c.String(),
                        IsAddActive = c.Boolean(nullable: false),
                        AddPrice = c.Single(nullable: false),
                        UserId = c.Int(nullable: false),
                        AddSubcategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddId);
            
            CreateIndex("dbo.UserAddModels", "UserId");
            AddForeignKey("dbo.UserAddModels", "UserId", "dbo.UserModels", "UserId", cascadeDelete: true);
        }
    }
}
