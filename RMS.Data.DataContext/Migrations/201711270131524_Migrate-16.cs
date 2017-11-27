namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate16 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VendorRequest");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VendorRequest",
                c => new
                    {
                        VendoerRequestId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        LGA = c.String(nullable: false, unicode: false),
                        State = c.String(nullable: false, unicode: false),
                        ZipCode = c.String(nullable: false, unicode: false),
                        PhoneNumber = c.String(nullable: false, unicode: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendoerRequestId);
            
        }
    }
}
