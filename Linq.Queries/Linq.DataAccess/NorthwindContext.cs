using Linq.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Linq.DataAccess
{
    public class NorthwindContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7JMICQT;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        // DbSets

        public DbSet<Shippers>? Shippers { get; set; }

        public DbSet<Orders>? Orders { get; set; }

        public DbSet<Products>? Products { get; set; }

    }
}