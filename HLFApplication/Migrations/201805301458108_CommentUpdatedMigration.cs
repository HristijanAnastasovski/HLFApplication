namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentUpdatedMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Comments", "ProteinId");
            AddForeignKey("dbo.Comments", "ProteinId", "dbo.Proteins", "ProteinId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ProteinId", "dbo.Proteins");
            DropIndex("dbo.Comments", new[] { "ProteinId" });
        }
    }
}
