namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingClassMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        RatedProteinId = c.Int(nullable: false),
                        Protein_ProteinId = c.Int(),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Proteins", t => t.Protein_ProteinId)
                .Index(t => t.Protein_ProteinId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "Protein_ProteinId", "dbo.Proteins");
            DropIndex("dbo.Ratings", new[] { "Protein_ProteinId" });
            DropTable("dbo.Ratings");
        }
    }
}
