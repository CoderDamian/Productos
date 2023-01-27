using Microsoft.EntityFrameworkCore;
using MyProduct.Domain.Entities;
using MyProduct.Persistence.Mappings;
using Oracle.ManagedDataAccess.Client;

namespace MyProduct.Persistence
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (OracleConfiguration.TnsAdmin is null)
            {
                OracleConfiguration.TnsAdmin = @"C:\Users\Fmla\Documents\OracleWallet\MyERP\";
                OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}