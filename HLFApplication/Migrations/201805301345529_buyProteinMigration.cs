namespace HLFApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buyProteinMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyProteins",
                c => new
                    {
                        BuyProteinId = c.Int(nullable: false, identity: true),
                        ProteinId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Country = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreditCardNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BuyProteinId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuyProteins");
        }
    }
}
