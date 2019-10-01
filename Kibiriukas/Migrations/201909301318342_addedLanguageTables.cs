namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLanguageTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageString = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.UserLanguages",
                c => new
                    {
                        UserLanguageId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserLanguageId)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LanguageId);
            
            AddColumn("dbo.Users", "SelfIntroduction", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLanguages", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLanguages", "LanguageId", "dbo.Languages");
            DropIndex("dbo.UserLanguages", new[] { "LanguageId" });
            DropIndex("dbo.UserLanguages", new[] { "UserId" });
            DropColumn("dbo.Users", "SelfIntroduction");
            DropTable("dbo.UserLanguages");
            DropTable("dbo.Languages");
        }
    }
}
