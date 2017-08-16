namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0621_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "adjunto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "adjunto");
        }
    }
}
