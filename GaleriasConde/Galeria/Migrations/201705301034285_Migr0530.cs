namespace Galeria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr0530 : DbMigration
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
                        Artwork_ArtworkID = c.Int(),
                        User_UserID = c.Int(),
                })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Artworks", t => t.Artwork_ArtworkID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Artwork_ArtworkID)
                .Index(t => t.User_UserID);
            
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
                        isDefault = c.Boolean(nullable: false),
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
                        isDefault = c.Boolean(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => new { t.AuthorID, t.lang })
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.NationalityTranslations",
                c => new
                    {
                        NationalityID = c.Int(nullable: false),
                        lang = c.String(nullable: false, maxLength: 128),
                        isDefault = c.Boolean(nullable: false),
                        codNation = c.String(),
                    })
                .PrimaryKey(t => new { t.NationalityID, t.lang })
                .ForeignKey("dbo.Nationalities", t => t.NationalityID, cascadeDelete: true)
                .Index(t => t.NationalityID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        codProfile = c.String(),
                    })
                .PrimaryKey(t => t.ProfileID);
            
            CreateTable(
                "dbo.TypeTranslations",
                c => new
                    {
                        TypeID = c.Int(nullable: false),
                        lang = c.String(nullable: false, maxLength: 128),
                        isDefault = c.Boolean(nullable: false),
                        codType = c.String(),
                    })
                .PrimaryKey(t => new { t.TypeID, t.lang })
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
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
                        Nationality_NationalityID = c.Int(),
                        Profile_ProfileID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Nationalities", t => t.Nationality_NationalityID)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileID)
                .Index(t => t.Nationality_NationalityID)
                .Index(t => t.Profile_ProfileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Profile_ProfileID", "dbo.Profiles");
            DropForeignKey("dbo.Users", "Nationality_NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.TypeTranslations", "TypeID", "dbo.Types");
            DropForeignKey("dbo.NationalityTranslations", "NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.AuthorTranslations", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.ArtworkTranslations", "ArtworkID", "dbo.Artworks");
            DropForeignKey("dbo.Artworks", "Type_TypeID", "dbo.Types");
            DropForeignKey("dbo.Transactions", "Artwork_ArtworkID", "dbo.Artworks");
            DropForeignKey("dbo.Authors", "Nationality_NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.Artworks", "Author_AuthorID", "dbo.Authors");
            DropIndex("dbo.Users", new[] { "Profile_ProfileID" });
            DropIndex("dbo.Users", new[] { "Nationality_NationalityID" });
            DropIndex("dbo.TypeTranslations", new[] { "TypeID" });
            DropIndex("dbo.NationalityTranslations", new[] { "NationalityID" });
            DropIndex("dbo.AuthorTranslations", new[] { "AuthorID" });
            DropIndex("dbo.ArtworkTranslations", new[] { "ArtworkID" });
            DropIndex("dbo.Transactions", new[] { "Artwork_ArtworkID" });
            DropIndex("dbo.Authors", new[] { "Nationality_NationalityID" });
            DropIndex("dbo.Artworks", new[] { "Type_TypeID" });
            DropIndex("dbo.Artworks", new[] { "Author_AuthorID" });
            DropTable("dbo.Users");
            DropTable("dbo.TypeTranslations");
            DropTable("dbo.Profiles");
            DropTable("dbo.NationalityTranslations");
            DropTable("dbo.AuthorTranslations");
            DropTable("dbo.ArtworkTranslations");
            DropTable("dbo.Types");
            DropTable("dbo.Transactions");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Authors");
            DropTable("dbo.Artworks");
        }
    }
}
