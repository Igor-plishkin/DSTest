using Microsoft.EntityFrameworkCore;

namespace DSTest.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<WeatherMeasure> WeatherMeasures { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
