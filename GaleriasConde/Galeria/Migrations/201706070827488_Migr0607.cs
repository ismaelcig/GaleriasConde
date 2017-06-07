namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0607 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Langs",
                c => new
                    {
                        LangID = c.Int(nullable: false, identity: true),
                        codLang = c.String(),
                        display = c.String(),
                    })
                .PrimaryKey(t => t.LangID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Langs");
        }
    }
}
