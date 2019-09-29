namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListingModel_editUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ListingId = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                        SubcategoryId = c.Short(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        Amount = c.Int(nullable: false),
                        Bio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListingId)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.UserModels", "Username", c => c.String());
            AddColumn("dbo.UserModels", "StreetName", c => c.String());
            AddColumn("dbo.UserModels", "StreetName2", c => c.String());
            AddColumn("dbo.UserModels", "PostCode", c => c.String());
            AddColumn("dbo.UserModels", "City", c => c.String());
            AddColumn("dbo.UserModels", "Country", c => c.String());
            AddColumn("dbo.UserModels", "HouseNumber", c => c.String());
            DropColumn("dbo.UserModels", "IsValidUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "IsValidUser", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Listings", "UserId", "dbo.UserModels");
            DropIndex("dbo.Listings", new[] { "UserId" });
            DropColumn("dbo.UserModels", "HouseNumber");
            DropColumn("dbo.UserModels", "Country");
            DropColumn("dbo.UserModels", "City");
            DropColumn("dbo.UserModels", "PostCode");
            DropColumn("dbo.UserModels", "StreetName2");
            DropColumn("dbo.UserModels", "StreetName");
            DropColumn("dbo.UserModels", "Username");
            DropTable("dbo.Listings");
        }
    }
}
