using Microsoft.EntityFrameworkCore;
using PlantPodService.Model;
using System;
using System.Linq;

namespace PlantPodService.Services.Persistence
{
    public interface IPlantService
    {
        public PlantEntity[] GetAllPlants();

        public PlantEntity GetPlantById(Guid id);
    }

    public sealed class PlantService : IPlantService
    {
        private readonly PlantPodServiceDbContext _dbContext;

        public PlantService(PlantPodServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PlantEntity[] GetAllPlants()
        {
            return _dbContext.Plants.ToArray();
        }

        public PlantEntity GetPlantById(Guid id)
        {
            return _dbContext.Plants.FirstOrDefault(e => e.Id == id);
        }
    }
}
