namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0615_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "venta", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "venta");
        }
    }
}
