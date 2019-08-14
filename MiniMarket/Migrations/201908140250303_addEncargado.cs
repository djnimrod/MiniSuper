namespace MiniMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEncargado : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NoteEntries", "User1_Id", "dbo.Users");
            DropForeignKey("dbo.NoteEntries", "User2_Id", "dbo.Users");
            DropForeignKey("dbo.NoteEntries", "User_Id", "dbo.Users");
            DropIndex("dbo.NoteEntries", new[] { "User_Id" });
            DropIndex("dbo.NoteEntries", new[] { "User1_Id" });
            DropIndex("dbo.NoteEntries", new[] { "User2_Id" });
            RenameColumn(table: "dbo.NoteEntries", name: "User_Id", newName: "UserId");
            AddColumn("dbo.NoteEntries", "Encargado", c => c.String(nullable: false));
            AlterColumn("dbo.NoteEntries", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.NoteEntries", "UserId");
            AddForeignKey("dbo.NoteEntries", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.NoteEntries", "UserRecibeID");
            DropColumn("dbo.NoteEntries", "UserEntregaID");
            DropColumn("dbo.NoteEntries", "User1_Id");
            DropColumn("dbo.NoteEntries", "User2_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NoteEntries", "User2_Id", c => c.Int());
            AddColumn("dbo.NoteEntries", "User1_Id", c => c.Int());
            AddColumn("dbo.NoteEntries", "UserEntregaID", c => c.Int(nullable: false));
            AddColumn("dbo.NoteEntries", "UserRecibeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.NoteEntries", "UserId", "dbo.Users");
            DropIndex("dbo.NoteEntries", new[] { "UserId" });
            AlterColumn("dbo.NoteEntries", "UserId", c => c.Int());
            DropColumn("dbo.NoteEntries", "Encargado");
            RenameColumn(table: "dbo.NoteEntries", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.NoteEntries", "User2_Id");
            CreateIndex("dbo.NoteEntries", "User1_Id");
            CreateIndex("dbo.NoteEntries", "User_Id");
            AddForeignKey("dbo.NoteEntries", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.NoteEntries", "User2_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.NoteEntries", "User1_Id", "dbo.Users", "Id");
        }
    }
}
