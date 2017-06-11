namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0611 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArtworkTranslations", "isDefault");
            DropColumn("dbo.AuthorTranslations", "isDefault");
            DropColumn("dbo.NationalityTranslations", "isDefault");
            DropColumn("dbo.TypeTranslations", "isDefault");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeTranslations", "isDefault", c => c.Boolean(nullable: false));
            AddColumn("dbo.NationalityTranslations", "isDefault", c => c.Boolean(nullable: false));
            AddColumn("dbo.AuthorTranslations", "isDefault", c => c.Boolean(nullable: false));
            AddColumn("dbo.ArtworkTranslations", "isDefault", c => c.Boolean(nullable: false));
        }
    }
}
