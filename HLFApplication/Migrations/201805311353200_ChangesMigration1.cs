namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RatingAccessories", "AccessoryId");
            CreateIndex("dbo.RatingMultivitamins", "MultivitaminId");
            AddForeignKey("dbo.RatingAccessories", "AccessoryId", "dbo.Accessories", "AccessoryId", cascadeDelete: true);
            AddForeignKey("dbo.RatingMultivitamins", "MultivitaminId", "dbo.Multivitamins", "MultivitaminId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingMultivitamins", "MultivitaminId", "dbo.Multivitamins");
            DropForeignKey("dbo.RatingAccessories", "AccessoryId", "dbo.Accessories");
            DropIndex("dbo.RatingMultivitamins", new[] { "MultivitaminId" });
            DropIndex("dbo.RatingAccessories", new[] { "AccessoryId" });
        }
    }
}
