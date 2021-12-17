using Microsoft.EntityFrameworkCore;

namespace PlantPodService.Model
{
    public class PlantPodServiceDbContext : DbContext
    {
        public DbSet<PlantEntity> Plants { get; set; }

        public PlantPodServiceDbContext(DbContextOptions<PlantPodServiceDbContext> options) : base(options) { }
    }
}
