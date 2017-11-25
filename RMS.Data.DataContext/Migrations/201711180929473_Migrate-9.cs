namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "CreatedBy", c => c.String(unicode: false));
            AddColumn("dbo.Employee", "DateCreated", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Employee", "DateLastModified", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Employee", "LastModifiedBy", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "LastModifiedBy");
            DropColumn("dbo.Employee", "DateLastModified");
            DropColumn("dbo.Employee", "DateCreated");
            DropColumn("dbo.Employee", "CreatedBy");
        }
    }
}
