namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdSubcategoryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subcategories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "Category_CategoryId" });
            AddColumn("dbo.Subcategories", "Category_CategoryId1", c => c.Int());
            AlterColumn("dbo.Subcategories", "Category_CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subcategories", "Category_CategoryId1");
            AddForeignKey("dbo.Subcategories", "Category_CategoryId1", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "Category_CategoryId1", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "Category_CategoryId1" });
            AlterColumn("dbo.Subcategories", "Category_CategoryId", c => c.Int());
            DropColumn("dbo.Subcategories", "Category_CategoryId1");
            CreateIndex("dbo.Subcategories", "Category_CategoryId");
            AddForeignKey("dbo.Subcategories", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
