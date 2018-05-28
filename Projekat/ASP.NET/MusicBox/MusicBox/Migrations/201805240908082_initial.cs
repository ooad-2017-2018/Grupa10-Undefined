namespace MusicBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ad",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExpirationDate = c.DateTime(nullable: false),
                        ContentName = c.String(),
                        AdType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location_Longitude = c.Int(nullable: false),
                        Location_Latitude = c.Int(nullable: false),
                        Description = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        VIPUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RegisteredUser", t => t.VIPUser_ID)
                .Index(t => t.VIPUser_ID);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        Description = c.String(),
                        CurrRating = c.Single(nullable: false),
                        Url = c.String(),
                        Playlist_ID = c.Int(),
                        VIPUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Playlist", t => t.Playlist_ID)
                .ForeignKey("dbo.RegisteredUser", t => t.VIPUser_ID)
                .Index(t => t.Playlist_ID)
                .Index(t => t.VIPUser_ID);
            
            CreateTable(
                "dbo.RegisteredUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Banned = c.Boolean(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        CurrSong_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Song", t => t.CurrSong_ID)
                .Index(t => t.CurrSong_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "VIPUser_ID", "dbo.RegisteredUser");
            DropForeignKey("dbo.Event", "VIPUser_ID", "dbo.RegisteredUser");
            DropForeignKey("dbo.RegisteredUser", "CurrSong_ID", "dbo.Song");
            DropForeignKey("dbo.Song", "Playlist_ID", "dbo.Playlist");
            DropIndex("dbo.RegisteredUser", new[] { "CurrSong_ID" });
            DropIndex("dbo.Song", new[] { "VIPUser_ID" });
            DropIndex("dbo.Song", new[] { "Playlist_ID" });
            DropIndex("dbo.Event", new[] { "VIPUser_ID" });
            DropTable("dbo.RegisteredUser");
            DropTable("dbo.Song");
            DropTable("dbo.Playlist");
            DropTable("dbo.Event");
            DropTable("dbo.Ad");
        }
    }
}
