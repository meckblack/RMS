namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VendorRequest", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.VendorRequest", "approval");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VendorRequest", "approval", c => c.Boolean(nullable: false));
            DropColumn("dbo.VendorRequest", "Status");
        }
    }
}
