using Microsoft.EntityFrameworkCore;

namespace TestEF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public string DbPath { get; }

        public ApplicationContext()
        {
            DbPath = "..\\..\\..\\test_orders.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
