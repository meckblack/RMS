namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "RestaurantId", c => c.Long());
            CreateIndex("dbo.Employee", "RestaurantId");
            AddForeignKey("dbo.Employee", "RestaurantId", "dbo.Restaurant", "RestaurantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.Employee", new[] { "RestaurantId" });
            DropColumn("dbo.Employee", "RestaurantId");
        }
    }
}
