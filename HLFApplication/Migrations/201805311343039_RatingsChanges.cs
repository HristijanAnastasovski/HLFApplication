namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingsChanges : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Ratings", "ProteinId");
            AddForeignKey("dbo.Ratings", "ProteinId", "dbo.Proteins", "ProteinId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "ProteinId", "dbo.Proteins");
            DropIndex("dbo.Ratings", new[] { "ProteinId" });
        }
    }
}
