namespace MiniMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioRelacionNotaEntrada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NoteEntries", "User1_Id", c => c.Int());
            AddColumn("dbo.NoteEntries", "User2_Id", c => c.Int());
            CreateIndex("dbo.NoteEntries", "User1_Id");
            CreateIndex("dbo.NoteEntries", "User2_Id");
            AddForeignKey("dbo.NoteEntries", "User1_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.NoteEntries", "User2_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NoteEntries", "User2_Id", "dbo.Users");
            DropForeignKey("dbo.NoteEntries", "User1_Id", "dbo.Users");
            DropIndex("dbo.NoteEntries", new[] { "User2_Id" });
            DropIndex("dbo.NoteEntries", new[] { "User1_Id" });
            DropColumn("dbo.NoteEntries", "User2_Id");
            DropColumn("dbo.NoteEntries", "User1_Id");
        }
    }
}
