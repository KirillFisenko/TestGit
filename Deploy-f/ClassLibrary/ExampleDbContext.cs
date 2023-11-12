using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
        {
            
        }

        public DbSet<SomeEntity> SomeEntity { get; set; }
    }
}
