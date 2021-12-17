using Microsoft.EntityFrameworkCore;
using PlantPodService.ViewModel;
using System;

namespace PlantPodService.Services.Persistence
{
    public interface IPlantService
    {
        public Plant[] GetAllPlants();

        public Plant GetPlantById(Guid id);
    }

    public sealed class PlantService : IPlantService
    {
        private readonly DbContext _dbContext;

        public PlantService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Plant[] GetAllPlants()
        {
            throw new NotImplementedException();
        }

        public Plant GetPlantById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
