using Microsoft.EntityFrameworkCore;

namespace PlantPodService.Model
{
    public class PlantPodServiceDbContext : DbContext
    {
        public DbSet<PlantEntity> Plants { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }

        public PlantPodServiceDbContext(DbContextOptions<PlantPodServiceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PlantEntityConfiguration().Configure(modelBuilder.Entity<PlantEntity>());
            new RoomEntityConfiguration().Configure(modelBuilder.Entity<RoomEntity>());
        }
    }
}
