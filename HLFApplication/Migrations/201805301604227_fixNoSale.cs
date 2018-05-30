namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixNoSale : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Proteins", "OnSale");
            DropColumn("dbo.Proteins", "OldPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proteins", "OldPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Proteins", "OnSale", c => c.Boolean(nullable: false));
        }
    }
}
