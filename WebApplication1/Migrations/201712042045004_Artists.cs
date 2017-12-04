namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Artists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Izvodac_IzvodacID", "dbo.Izvodacs");
            DropForeignKey("dbo.Albums", "Artist_ArtistID", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Izvodac_IzvodacID" });
            DropIndex("dbo.Albums", new[] { "Artist_ArtistID" });
            RenameColumn(table: "dbo.Albums", name: "Artist_ArtistID", newName: "ArtistID");
            AlterColumn("dbo.Albums", "ArtistID", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "ArtistID");
            AddForeignKey("dbo.Albums", "ArtistID", "dbo.Artists", "ArtistID", cascadeDelete: true);
            DropColumn("dbo.Albums", "Izvodac_IzvodacID");
            DropTable("dbo.Izvodacs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Izvodacs",
                c => new
                    {
                        IzvodacID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.IzvodacID);
            
            AddColumn("dbo.Albums", "Izvodac_IzvodacID", c => c.Int());
            DropForeignKey("dbo.Albums", "ArtistID", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "ArtistID" });
            AlterColumn("dbo.Albums", "ArtistID", c => c.Int());
            RenameColumn(table: "dbo.Albums", name: "ArtistID", newName: "Artist_ArtistID");
            CreateIndex("dbo.Albums", "Artist_ArtistID");
            CreateIndex("dbo.Albums", "Izvodac_IzvodacID");
            AddForeignKey("dbo.Albums", "Artist_ArtistID", "dbo.Artists", "ArtistID");
            AddForeignKey("dbo.Albums", "Izvodac_IzvodacID", "dbo.Izvodacs", "IzvodacID");
        }
    }
}
