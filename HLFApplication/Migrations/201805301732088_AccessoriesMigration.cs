namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessoriesMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentAccessories",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Opinion = c.String(nullable: false, maxLength: 50),
                        AccessoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Accessories", t => t.AccessoryId, cascadeDelete: true)
                .Index(t => t.AccessoryId);
            
            CreateTable(
                "dbo.BuyAccessories",
                c => new
                    {
                        BuyProteinId = c.Int(nullable: false, identity: true),
                        AccessoryId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Country = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreditCardNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BuyProteinId);
            
            CreateTable(
                "dbo.RatingAccessories",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        AccessoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentAccessories", "AccessoryId", "dbo.Accessories");
            DropIndex("dbo.CommentAccessories", new[] { "AccessoryId" });
            DropTable("dbo.RatingAccessories");
            DropTable("dbo.BuyAccessories");
            DropTable("dbo.CommentAccessories");
        }
    }
}
