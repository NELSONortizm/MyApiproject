using Microsoft.EntityFrameworkCore;
using MyApiProject.Entities;

namespace MyApiProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
          
        }

        public DbSet<Product> Products { get; set; }
    }
}
