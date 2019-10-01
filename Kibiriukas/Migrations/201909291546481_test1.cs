namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Listings");
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(),
                        ReviewedUserId = c.Int(nullable: false),
                        ReviewerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Users", t => t.ReviewedUserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ReviewerId, cascadeDelete: false)
                .Index(t => t.ReviewedUserId)
                .Index(t => t.ReviewerId);
            
            AlterColumn("dbo.Listings", "ListingId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Listings", "ListingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ReviewerId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "ReviewedUserId", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "ReviewerId" });
            DropIndex("dbo.Reviews", new[] { "ReviewedUserId" });
            DropPrimaryKey("dbo.Listings");
            AlterColumn("dbo.Listings", "ListingId", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Reviews");
            AddPrimaryKey("dbo.Listings", "ListingId");
        }
    }
}
