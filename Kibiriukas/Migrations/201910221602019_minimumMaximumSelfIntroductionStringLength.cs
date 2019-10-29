namespace Kibiriukas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minimumMaximumSelfIntroductionStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "SelfIntroduction", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "SelfIntroduction", c => c.String());
        }
    }
}
