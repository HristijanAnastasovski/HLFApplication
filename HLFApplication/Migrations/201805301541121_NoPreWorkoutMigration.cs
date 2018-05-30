namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoPreWorkoutMigration : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PreWorkouts");
        }
        
        public override void Down()
        {
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
    }
}
