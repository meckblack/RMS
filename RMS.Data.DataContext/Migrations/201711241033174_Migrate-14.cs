namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VendorRequest", "approval", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VendorRequest", "approval");
        }
    }
}
