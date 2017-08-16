namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0621 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtworkTranslations", "dimensions", c => c.String());
            DropColumn("dbo.Artworks", "dimensions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artworks", "dimensions", c => c.String());
            DropColumn("dbo.ArtworkTranslations", "dimensions");
        }
    }
}
