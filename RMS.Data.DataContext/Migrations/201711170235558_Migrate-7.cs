namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "State", c => c.String(nullable: false, unicode: false));
        }
    }
}
