namespace MiniMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNoteExit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoteExits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacion = c.String(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                        Encargado = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.NoteEntryProducts", "NoteExit_Id", c => c.Int());
            CreateIndex("dbo.NoteEntryProducts", "NoteExit_Id");
            AddForeignKey("dbo.NoteEntryProducts", "NoteExit_Id", "dbo.NoteExits", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NoteExits", "UserId", "dbo.Users");
            DropForeignKey("dbo.NoteEntryProducts", "NoteExit_Id", "dbo.NoteExits");
            DropIndex("dbo.NoteExits", new[] { "UserId" });
            DropIndex("dbo.NoteEntryProducts", new[] { "NoteExit_Id" });
            DropColumn("dbo.NoteEntryProducts", "NoteExit_Id");
            DropTable("dbo.NoteExits");
        }
    }
}
