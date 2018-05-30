namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AddRatingToItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AddRatingToItems",
                c => new
                    {
                        AddRatingToItemId = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddRatingToItemId);
            
        }
    }
}
