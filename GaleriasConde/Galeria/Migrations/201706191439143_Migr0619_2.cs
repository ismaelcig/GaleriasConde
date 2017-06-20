namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0619_2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Messages");
            AlterColumn("dbo.Messages", "MessageID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Messages", new[] { "MessageID", "ChatID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Messages");
            AlterColumn("dbo.Messages", "MessageID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Messages", "MessageID");
        }
    }
}
