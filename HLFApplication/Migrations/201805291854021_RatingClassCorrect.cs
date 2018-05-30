namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingClassCorrect : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ratings", "RatedProteinId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "RatedProteinId", c => c.Int(nullable: false));
        }
    }
}
