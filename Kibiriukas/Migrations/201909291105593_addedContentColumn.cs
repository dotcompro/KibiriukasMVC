namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedContentColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfilePictures", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfilePictures", "Content");
        }
    }
}
