namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExtendedMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subcategories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.Subcategories", name: "Category_CategoryId", newName: "CategoryId");
            AddColumn("dbo.Subcategories", "SubcategoryTitle", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Subcategories", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subcategories", "CategoryId");
            AddForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Subcategories", "SobcategoryTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subcategories", "SobcategoryTitle", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            AlterColumn("dbo.Subcategories", "CategoryId", c => c.Int());
            DropColumn("dbo.Subcategories", "SubcategoryTitle");
            RenameColumn(table: "dbo.Subcategories", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Subcategories", "Category_CategoryId");
            AddForeignKey("dbo.Subcategories", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
