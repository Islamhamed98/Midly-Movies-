namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMemberShipTbl1 : DbMigration
    {
        public override void Up()
        {
            Sql("Update dbo.MembershipTypes SET Name='Pay as you go' WHERE Id = 1");
            Sql("Update dbo.MembershipTypes SET Name='Monthly' WHERE Id = 2");
            Sql("Update dbo.MembershipTypes SET Name='Quarterly' WHERE Id = 3");
            Sql("Update dbo.MembershipTypes SET Name='Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
