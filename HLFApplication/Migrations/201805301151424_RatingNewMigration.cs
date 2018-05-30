namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingNewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "Protein_ProteinId", "dbo.Proteins");
            DropIndex("dbo.Ratings", new[] { "Protein_ProteinId" });
            AddColumn("dbo.Ratings", "ProteinId", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "Protein_ProteinId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Protein_ProteinId", c => c.Int());
            DropColumn("dbo.Ratings", "ProteinId");
            CreateIndex("dbo.Ratings", "Protein_ProteinId");
            AddForeignKey("dbo.Ratings", "Protein_ProteinId", "dbo.Proteins", "ProteinId");
        }
    }
}
