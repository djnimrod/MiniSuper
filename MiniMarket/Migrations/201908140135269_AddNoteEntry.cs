namespace MiniMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoteEntry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoteEntryProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteEntryID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NoteEntries", t => t.NoteEntryID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.NoteEntryID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.NoteEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacion = c.String(nullable: false),
                        FechaEntrada = c.DateTime(nullable: false),
                        UserRecibeID = c.Int(nullable: false),
                        UserEntregaID = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameUser = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NoteEntryProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.NoteEntries", "User_Id", "dbo.Users");
            DropForeignKey("dbo.NoteEntryProducts", "NoteEntryID", "dbo.NoteEntries");
            DropIndex("dbo.NoteEntries", new[] { "User_Id" });
            DropIndex("dbo.NoteEntryProducts", new[] { "ProductID" });
            DropIndex("dbo.NoteEntryProducts", new[] { "NoteEntryID" });
            DropTable("dbo.Users");
            DropTable("dbo.NoteEntries");
            DropTable("dbo.NoteEntryProducts");
        }
    }
}
