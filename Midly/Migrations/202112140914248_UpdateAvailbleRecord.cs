namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAvailbleRecord : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies SET NumberAvailble = NumInStock");
        }
        
        public override void Down()
        {
        }
    }
}
