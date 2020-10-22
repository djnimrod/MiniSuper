namespace MiniMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldImagenQr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagenQr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImagenQr");
        }
    }
}
