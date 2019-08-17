namespace MiniMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioFotoRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Foto", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Foto", c => c.String(nullable: false));
        }
    }
}
