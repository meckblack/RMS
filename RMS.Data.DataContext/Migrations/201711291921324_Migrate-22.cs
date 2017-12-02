namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Username", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Customer", "Password", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Customer", "ComfirmPassword", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "ComfirmPassword");
            DropColumn("dbo.Customer", "Password");
            DropColumn("dbo.Customer", "Username");
        }
    }
}
