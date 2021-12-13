using Microsoft.EntityFrameworkCore;
using System;

namespace PlantPodService.model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PlantEntity> Plants { get; set; }

        public string DbPath { get; }

        public DatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            //Todo: store connection string in appsettings.json
            DbPath = System.IO.Path.Join(path, "database.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
