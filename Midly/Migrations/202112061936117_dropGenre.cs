namespace Midly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {

            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.Movies", "Genre_Id");
        }
    }
}
