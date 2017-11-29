namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate21 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Supplier");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        LGA = c.String(nullable: false, unicode: false),
                        State = c.String(nullable: false, unicode: false),
                        ZipCode = c.String(nullable: false, unicode: false),
                        PhoneNumber = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
    }
}
