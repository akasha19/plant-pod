using Microsoft.EntityFrameworkCore;
using PlantPodService.Model;
using System;

namespace PlantPodService.Services.Persistence
{
    public interface IPlantService
    {
        public PlantEntity[] GetAllPlants();

        public PlantEntity GetPlantById(Guid id);
    }

    public sealed class PlantService : IPlantService
    {
        private readonly DbContext _dbContext;

        public PlantService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PlantEntity[] GetAllPlants()
        {
            throw new NotImplementedException();
        }

        public PlantEntity GetPlantById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
