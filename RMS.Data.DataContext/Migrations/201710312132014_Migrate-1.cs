namespace RMS.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        BankId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.CookingMeasurement",
                c => new
                    {
                        CookingMeasurementId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.CookingMeasurementId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, unicode: false),
                        LastName = c.String(nullable: false, unicode: false),
                        MiddleName = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        Gender = c.Int(nullable: false),
                        LGA = c.String(nullable: false, unicode: false),
                        State = c.String(nullable: false, unicode: false),
                        ZipCode = c.String(nullable: false, unicode: false),
                        PhoneNumber = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, unicode: false),
                        LastName = c.String(nullable: false, unicode: false),
                        MiddleName = c.String(unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        DateOfEmployment = c.DateTime(nullable: false, precision: 0),
                        DateOfBirth = c.DateTime(nullable: false, precision: 0),
                        PhoneNumber = c.String(nullable: false, unicode: false),
                        Gender = c.Int(nullable: false),
                        AccountName = c.String(nullable: false, unicode: false),
                        AccountNumber = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        BankId = c.Long(),
                        DepartmentId = c.Long(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Bank", t => t.BankId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.BankId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodTypeId = c.Long(),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.FoodType", t => t.FoodTypeId)
                .Index(t => t.FoodTypeId);
            
            CreateTable(
                "dbo.FoodType",
                c => new
                    {
                        FoodTypeId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.FoodTypeId);
            
            CreateTable(
                "dbo.FoodStuff",
                c => new
                    {
                        FoodStuffId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        MeasurementId = c.Long(),
                    })
                .PrimaryKey(t => t.FoodStuffId)
                .ForeignKey("dbo.Measurement", t => t.MeasurementId)
                .Index(t => t.MeasurementId);
            
            CreateTable(
                "dbo.Measurement",
                c => new
                    {
                        MeasurementId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.MeasurementId);
            
            CreateTable(
                "dbo.IncomeCategory",
                c => new
                    {
                        IncomeCategoryId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.IncomeCategoryId);
            
            CreateTable(
                "dbo.IncomeItem",
                c => new
                    {
                        IncomeItemId = c.Long(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Price = c.String(unicode: false),
                        IncomeCategoryId = c.Long(),
                    })
                .PrimaryKey(t => t.IncomeItemId)
                .ForeignKey("dbo.IncomeCategory", t => t.IncomeCategoryId)
                .Index(t => t.IncomeCategoryId);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        RestaurantId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 35, storeType: "nvarchar"),
                        Acronym = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        LGA = c.String(nullable: false, unicode: false),
                        State = c.Int(nullable: false),
                        PostalCode = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomeItem", "IncomeCategoryId", "dbo.IncomeCategory");
            DropForeignKey("dbo.FoodStuff", "MeasurementId", "dbo.Measurement");
            DropForeignKey("dbo.Food", "FoodTypeId", "dbo.FoodType");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "BankId", "dbo.Bank");
            DropIndex("dbo.IncomeItem", new[] { "IncomeCategoryId" });
            DropIndex("dbo.FoodStuff", new[] { "MeasurementId" });
            DropIndex("dbo.Food", new[] { "FoodTypeId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "BankId" });
            DropTable("dbo.Restaurant");
            DropTable("dbo.IncomeItem");
            DropTable("dbo.IncomeCategory");
            DropTable("dbo.Measurement");
            DropTable("dbo.FoodStuff");
            DropTable("dbo.FoodType");
            DropTable("dbo.Food");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.Customer");
            DropTable("dbo.CookingMeasurement");
            DropTable("dbo.Bank");
        }
    }
}
