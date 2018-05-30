namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discountMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proteins", "OnSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Proteins", "OldPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proteins", "OldPrice");
            DropColumn("dbo.Proteins", "OnSale");
        }
    }
}
