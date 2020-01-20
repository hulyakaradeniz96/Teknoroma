using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.MODEL.Entity;
using Teknoroma.MODEL.Entity.Expenses;
using Teknoroma.MODEL.Map;
using Teknoroma.MODEL.Map.ExpenseMap;

namespace Teknoroma.MODEL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=.;database=TeknoromaDB; Integrated Security=SSPI";
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OtherExpense> OtherExpenses { get; set; }
        public DbSet<PaymentOfEmployee> PaymentOfEmployees { get; set; }
        public DbSet<TechnicalInfrastructure> TechnicalInfrastructures { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new PaymentOfEmployeeMap());
            modelBuilder.Configurations.Add(new TechnicalInfrastructureMap());
            modelBuilder.Configurations.Add(new OtherExpenseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
