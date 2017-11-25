namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Email", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Email");
        }
    }
}
