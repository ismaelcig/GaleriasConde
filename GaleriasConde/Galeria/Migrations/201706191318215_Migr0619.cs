namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0619 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ChatID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        ChatID = c.Int(nullable: false),
                        text = c.String(),
                        Sender_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Chats", t => t.ChatID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Sender_UserID)
                .Index(t => t.ChatID)
                .Index(t => t.Sender_UserID);
            
            CreateTable(
                "dbo.ChatUsers",
                c => new
                    {
                        Chat_ChatID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chat_ChatID, t.User_UserID })
                .ForeignKey("dbo.Chats", t => t.Chat_ChatID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Chat_ChatID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChatUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.ChatUsers", "Chat_ChatID", "dbo.Chats");
            DropForeignKey("dbo.Messages", "Sender_UserID", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatID", "dbo.Chats");
            DropIndex("dbo.ChatUsers", new[] { "User_UserID" });
            DropIndex("dbo.ChatUsers", new[] { "Chat_ChatID" });
            DropIndex("dbo.Messages", new[] { "Sender_UserID" });
            DropIndex("dbo.Messages", new[] { "ChatID" });
            DropTable("dbo.ChatUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
        }
    }
}
