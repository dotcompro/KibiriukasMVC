namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryTitle = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoryId = c.Short(nullable: false, identity: true),
                        SobcategoryTitle = c.String(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.SubcategoryId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "Category_CategoryId" });
            DropTable("dbo.Subcategories");
            DropTable("dbo.Categories");
        }
    }
}
