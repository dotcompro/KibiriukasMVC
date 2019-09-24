namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportingError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAddModels", "AddTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAddModels", "AddTitle", c => c.String());
        }
    }
}
