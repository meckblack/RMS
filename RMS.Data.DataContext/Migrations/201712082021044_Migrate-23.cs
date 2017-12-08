namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RMS_Bank",
                c => new
                    {
                        RMS_BankId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        RMS_CountryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RMS_BankId)
                .ForeignKey("dbo.RMS_Country", t => t.RMS_CountryId, cascadeDelete: true)
                .Index(t => t.RMS_CountryId);
            
            CreateTable(
                "dbo.RMS_Country",
                c => new
                    {
                        RMS_CountryId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.RMS_CountryId);
            
            AddColumn("dbo.Restaurant", "AccountNumber", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Restaurant", "DateCreated", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Restaurant", "Bank_RMS_BankId", c => c.Long(nullable: false));
            AddColumn("dbo.Restaurant", "Country_RMS_CountryId", c => c.Long(nullable: false));
            CreateIndex("dbo.Restaurant", "Bank_RMS_BankId");
            CreateIndex("dbo.Restaurant", "Country_RMS_CountryId");
            AddForeignKey("dbo.Restaurant", "Bank_RMS_BankId", "dbo.RMS_Bank", "RMS_BankId", cascadeDelete: true);
            AddForeignKey("dbo.Restaurant", "Country_RMS_CountryId", "dbo.RMS_Country", "RMS_CountryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurant", "Country_RMS_CountryId", "dbo.RMS_Country");
            DropForeignKey("dbo.Restaurant", "Bank_RMS_BankId", "dbo.RMS_Bank");
            DropForeignKey("dbo.RMS_Bank", "RMS_CountryId", "dbo.RMS_Country");
            DropIndex("dbo.RMS_Bank", new[] { "RMS_CountryId" });
            DropIndex("dbo.Restaurant", new[] { "Country_RMS_CountryId" });
            DropIndex("dbo.Restaurant", new[] { "Bank_RMS_BankId" });
            DropColumn("dbo.Restaurant", "Country_RMS_CountryId");
            DropColumn("dbo.Restaurant", "Bank_RMS_BankId");
            DropColumn("dbo.Restaurant", "DateCreated");
            DropColumn("dbo.Restaurant", "AccountNumber");
            DropTable("dbo.RMS_Country");
            DropTable("dbo.RMS_Bank");
        }
    }
}
