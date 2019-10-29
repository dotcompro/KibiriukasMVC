namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CC_FIPS = c.String(),
                        CC_ISO = c.String(),
                        FULL_NAME_ND = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
