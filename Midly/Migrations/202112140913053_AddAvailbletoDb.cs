namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailbletoDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailble", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailble");
        }
    }
}
