namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesToUserModelTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserModels", newName: "Users");
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateOfBirth");
            DropColumn("dbo.Users", "Email");
            RenameTable(name: "dbo.Users", newName: "UserModels");
        }
    }
}
