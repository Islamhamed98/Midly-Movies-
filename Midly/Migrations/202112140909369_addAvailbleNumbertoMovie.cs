namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAvailbleNumbertoMovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "NumberAvailble");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberAvailble", c => c.Byte(nullable: false));
        }
    }
}
