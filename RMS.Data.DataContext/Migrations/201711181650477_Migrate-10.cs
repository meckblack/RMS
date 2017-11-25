namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        CanManageEmployee = c.Boolean(nullable: false),
                        CanManageFood = c.Boolean(nullable: false),
                        CanManageIncome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Role");
        }
    }
}
