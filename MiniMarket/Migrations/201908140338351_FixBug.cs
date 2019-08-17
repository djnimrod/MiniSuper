namespace MiniMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBug : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoteExitProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteExitID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NoteExits", t => t.NoteExitID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.NoteExitID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NoteExitProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.NoteExitProducts", "NoteExitID", "dbo.NoteExits");
            DropIndex("dbo.NoteExitProducts", new[] { "ProductID" });
            DropIndex("dbo.NoteExitProducts", new[] { "NoteExitID" });
            DropTable("dbo.NoteExitProducts");
        }
    }
}
