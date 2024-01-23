using Microsoft.EntityFrameworkCore;

namespace WebDB_Test
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
            new Product { Id = Guid.Parse("e5650031-f46d-4a08-95e3-73bdcfbe0e03"), Name = "Product1", Price = 100 },
            new Product { Id = Guid.Parse("1da615a9-1274-49b1-a5e3-1de9eb4def1e"), Name = "Product2", Price = 540 }
            });
        }
    }
}