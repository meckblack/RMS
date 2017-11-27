using RMS.Data.Objects.Entities.Employee;
using RMS.Data.Objects.Entities.Restaurant;
using RMS.Data.Objects.Entities.Vendor;
using RMS.Data.Objects.Entities.SystemMangement;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.DataContext.DataContext.SystemDataContext
{
    public class SystemDataContext : DbContext
    {
        public SystemDataContext ()
            : base("name = RMS")
        {

        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<FoodType> FoodType { get; set; }
        public virtual DbSet<Measurement> Measurement { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<FoodStuff> FoodStuff { get; set; }
        public virtual DbSet<CookingMeasurement> CookingMeasurement { get; set; }
        public virtual DbSet<IncomeCategory> IncomeCategory { get; set; }
        public virtual DbSet<IncomeItem> IncomeItem { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public virtual DbSet<ExpenseItem> ExpenseItem { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
