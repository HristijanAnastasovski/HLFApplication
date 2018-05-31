namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultivitaminMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyMultivitamins",
                c => new
                    {
                        BuyMultivitaminId = c.Int(nullable: false, identity: true),
                        MultivitaminId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Country = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreditCardNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BuyMultivitaminId);
            
            CreateTable(
                "dbo.CommentMultivitamins",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Opinion = c.String(nullable: false, maxLength: 50),
                        MultivitaminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Multivitamins", t => t.MultivitaminId, cascadeDelete: true)
                .Index(t => t.MultivitaminId);
            
            CreateTable(
                "dbo.RatingMultivitamins",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        MultivitaminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentMultivitamins", "MultivitaminId", "dbo.Multivitamins");
            DropIndex("dbo.CommentMultivitamins", new[] { "MultivitaminId" });
            DropTable("dbo.RatingMultivitamins");
            DropTable("dbo.CommentMultivitamins");
            DropTable("dbo.BuyMultivitamins");
        }
    }
}
