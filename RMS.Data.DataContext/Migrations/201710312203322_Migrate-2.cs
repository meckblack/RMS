namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseCategory",
                c => new
                    {
                        ExpenseCategoryId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ExpenseCategoryId);
            
            CreateTable(
                "dbo.ExpenseItem",
                c => new
                    {
                        ExpenseItemId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                        ExpenseCategoryId = c.Long(),
                    })
                .PrimaryKey(t => t.ExpenseItemId)
                .ForeignKey("dbo.ExpenseCategory", t => t.ExpenseCategoryId)
                .Index(t => t.ExpenseCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseItem", "ExpenseCategoryId", "dbo.ExpenseCategory");
            DropIndex("dbo.ExpenseItem", new[] { "ExpenseCategoryId" });
            DropTable("dbo.ExpenseItem");
            DropTable("dbo.ExpenseCategory");
        }
    }
}
