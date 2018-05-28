namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProteinClass1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proteins", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Proteins", "ImageURL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proteins", "ImageURL", c => c.String());
            AlterColumn("dbo.Proteins", "Description", c => c.String());
        }
    }
}
