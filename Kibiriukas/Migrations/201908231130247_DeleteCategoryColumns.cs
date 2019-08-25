namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoryColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("Categories", "Darzoves");
            DropColumn("Categories", "Vaisiai");
            DropColumn("Categories", "Mesa");
        }
        
        public override void Down()
        {
        }
    }
}
