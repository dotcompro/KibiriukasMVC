namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfilePictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfilePictures", "UserId", "dbo.UserModels");
            DropIndex("dbo.ProfilePictures", new[] { "UserId" });
            DropTable("dbo.ProfilePictures");
        }
    }
}
