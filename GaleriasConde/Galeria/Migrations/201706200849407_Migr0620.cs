namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0620 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chats", "picture", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chats", "picture");
        }
    }
}
