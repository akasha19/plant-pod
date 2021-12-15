using Microsoft.EntityFrameworkCore;

namespace PlantPodService.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PlantEntity> Plants { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
