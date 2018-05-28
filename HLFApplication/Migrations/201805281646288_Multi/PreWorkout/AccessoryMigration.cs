namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiPreWorkoutAccessoryMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfProductsInStock = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        ImageURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoryId);
            
            CreateTable(
                "dbo.Multivitamins",
                c => new
                    {
                        MultivitaminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfProductsInStock = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        ImageURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MultivitaminId);
            
            CreateTable(
                "dbo.PreWorkouts",
                c => new
                    {
                        PreWorkoutId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfProductsInStock = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        ImageURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PreWorkoutId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PreWorkouts");
            DropTable("dbo.Multivitamins");
            DropTable("dbo.Accessories");
        }
    }
}
