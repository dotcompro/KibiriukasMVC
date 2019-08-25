namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotationsToCategAndSub : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryTitle", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Subcategories", "SobcategoryTitle", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subcategories", "SobcategoryTitle", c => c.String());
            AlterColumn("dbo.Categories", "CategoryTitle", c => c.String());
        }
    }
}
