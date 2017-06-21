namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0621 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artworks",
                c => new
                    {
                        ArtworkID = c.Int(nullable: false, identity: true),
                        onStock = c.Boolean(nullable: false),
                        img = c.Binary(),
                        date = c.String(),
                        dimensions = c.String(),
                        money = c.Double(nullable: false),
                        Author_AuthorID = c.Int(),
                        Type_TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ArtworkID)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorID)
                .ForeignKey("dbo.Types", t => t.Type_TypeID)
                .Index(t => t.Author_AuthorID)
                .Index(t => t.Type_TypeID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        realName = c.String(maxLength: 150),
                        artName = c.String(maxLength: 150),
                        Nationality_NationalityID = c.Int(),
                    })
                .PrimaryKey(t => t.AuthorID)
                .ForeignKey("dbo.Nationalities", t => t.Nationality_NationalityID)
                .Index(t => t.Nationality_NationalityID);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.NationalityID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        money = c.Double(nullable: false),
                        comment = c.String(),
                        done = c.Boolean(nullable: false),
                        registeredBy = c.Int(nullable: false),
                        venta = c.Boolean(nullable: false),
                        Artwork_ArtworkID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Artworks", t => t.Artwork_ArtworkID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Artwork_ArtworkID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        surnames = c.String(),
                        nick = c.String(),
                        pass = c.String(),
                        address = c.String(),
                        tlf = c.String(),
                        email = c.String(),
                        picture = c.Binary(),
                        Nationality_NationalityID = c.Int(),
                        Profile_ProfileID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Nationalities", t => t.Nationality_NationalityID)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID)
                .Index(t => t.Nationality_NationalityID)
                .Index(t => t.Profile_ProfileID);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ChatID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false),
                        ChatID = c.Int(nullable: false),
                        text = c.String(),
                        Sender_UserID = c.Int(),
                    })
                .PrimaryKey(t => new { t.MessageID, t.ChatID })
                .ForeignKey("dbo.Chats", t => t.ChatID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Sender_UserID)
                .Index(t => t.ChatID)
                .Index(t => t.Sender_UserID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        codProfile = c.String(),
                    })
                .PrimaryKey(t => t.ProfileID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.ArtworkTranslations",
                c => new
                    {
                        ArtworkID = c.Int(nullable: false),
                        lang = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        info = c.String(),
                    })
                .PrimaryKey(t => new { t.ArtworkID, t.lang })
                .ForeignKey("dbo.Artworks", t => t.ArtworkID, cascadeDelete: true)
                .Index(t => t.ArtworkID);
            
            CreateTable(
                "dbo.AuthorTranslations",
                c => new
                    {
                        AuthorID = c.Int(nullable: false),
                        lang = c.String(nullable: false, maxLength: 128),
                        description = c.String(),
                    })
                .PrimaryKey(t => new { t.AuthorID, t.lang })
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Langs",
                c => new
                    {
                        LangID = c.Int(nullable: false, identity: true),
                        codLang = c.String(),
                        display = c.String(),
                    })
                .PrimaryKey(t => t.LangID);
            
            CreateTable(
                "dbo.NationalityTranslations",
                c => new
                    {
                        NationalityID = c.Int(nullable: false),
                        lang = c.String(nullable: false, maxLength: 128),
                        codNation = c.String(),
                    })
                .PrimaryKey(t => new { t.NationalityID, t.lang })
                .ForeignKey("dbo.Nationalities", t => t.NationalityID, cascadeDelete: true)
                .Index(t => t.NationalityID);
            
            CreateTable(
                "dbo.TypeTranslations",
                c => new
                    {
                        TypeID = c.Int(nullable: false),
                        lang = c.String(nullable: false, maxLength: 128),
                        codType = c.String(),
                    })
                .PrimaryKey(t => new { t.TypeID, t.lang })
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
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
            DropForeignKey("dbo.TypeTranslations", "TypeID", "dbo.Types");
            DropForeignKey("dbo.NationalityTranslations", "NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.AuthorTranslations", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.ArtworkTranslations", "ArtworkID", "dbo.Artworks");
            DropForeignKey("dbo.Artworks", "Type_TypeID", "dbo.Types");
            DropForeignKey("dbo.Transactions", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Users", "Nationality_NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.ChatUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.ChatUsers", "Chat_ChatID", "dbo.Chats");
            DropForeignKey("dbo.Messages", "Sender_UserID", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatID", "dbo.Chats");
            DropForeignKey("dbo.Transactions", "Artwork_ArtworkID", "dbo.Artworks");
            DropForeignKey("dbo.Authors", "Nationality_NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.Artworks", "Author_AuthorID", "dbo.Authors");
            DropIndex("dbo.ChatUsers", new[] { "User_UserID" });
            DropIndex("dbo.ChatUsers", new[] { "Chat_ChatID" });
            DropIndex("dbo.TypeTranslations", new[] { "TypeID" });
            DropIndex("dbo.NationalityTranslations", new[] { "NationalityID" });
            DropIndex("dbo.AuthorTranslations", new[] { "AuthorID" });
            DropIndex("dbo.ArtworkTranslations", new[] { "ArtworkID" });
            DropIndex("dbo.Messages", new[] { "Sender_UserID" });
            DropIndex("dbo.Messages", new[] { "ChatID" });
            DropIndex("dbo.Users", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Users", new[] { "Nationality_NationalityID" });
            DropIndex("dbo.Transactions", new[] { "User_UserID" });
            DropIndex("dbo.Transactions", new[] { "Artwork_ArtworkID" });
            DropIndex("dbo.Authors", new[] { "Nationality_NationalityID" });
            DropIndex("dbo.Artworks", new[] { "Type_TypeID" });
            DropIndex("dbo.Artworks", new[] { "Author_AuthorID" });
            DropTable("dbo.ChatUsers");
            DropTable("dbo.TypeTranslations");
            DropTable("dbo.NationalityTranslations");
            DropTable("dbo.Langs");
            DropTable("dbo.AuthorTranslations");
            DropTable("dbo.ArtworkTranslations");
            DropTable("dbo.Types");
            DropTable("dbo.Profiles");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Authors");
            DropTable("dbo.Artworks");
        }
    }
}
