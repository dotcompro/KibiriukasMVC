namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedCityTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cities");
        }
        
        public override void Down()
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
    }
}
