namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Albums");
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Izvodac_IzvodacID = c.Int(),
                        Artist_ArtistID = c.Int(),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Izvodacs", t => t.Izvodac_IzvodacID)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistID)
                .Index(t => t.Izvodac_IzvodacID)
                .Index(t => t.Artist_ArtistID);
            
            CreateTable(
                "dbo.Izvodacs",
                c => new
                    {
                        IzvodacID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.IzvodacID);

            DropTable("dbo.Reviews");
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Contents = c.String(),
                        ReviewerEmail = c.String(),
                        AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Albums", t => t.AlbumID, cascadeDelete: true)
                .Index(t => t.AlbumID);

            DropTable("dbo.Artists");
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.Reviews", "AlbumID", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Izvodac_IzvodacID", "dbo.Izvodacs");
            DropIndex("dbo.Reviews", new[] { "AlbumID" });
            DropIndex("dbo.Albums", new[] { "Artist_ArtistID" });
            DropIndex("dbo.Albums", new[] { "Izvodac_IzvodacID" });
            DropTable("dbo.Artists");
            DropTable("dbo.Reviews");
            DropTable("dbo.Izvodacs");
            DropTable("dbo.Albums");
        }
    }
}
