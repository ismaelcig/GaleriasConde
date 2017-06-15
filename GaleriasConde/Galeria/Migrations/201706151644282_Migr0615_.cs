namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0615_ : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "registeredBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "registeredBy", c => c.Boolean(nullable: false));
        }
    }
}
