namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseItem", "Price", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.ExpenseItem", "Quantity", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenseItem", "Quantity");
            DropColumn("dbo.ExpenseItem", "Price");
        }
    }
}
