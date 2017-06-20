namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0620_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chats", "name", c => c.String());
            DropColumn("dbo.Chats", "picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chats", "picture", c => c.Binary());
            DropColumn("dbo.Chats", "name");
        }
    }
}
