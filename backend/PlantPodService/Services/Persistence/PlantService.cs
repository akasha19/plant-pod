using PlantPodService.Model;
using System;

namespace PlantPodService.Services.Persistence
{
    public interface IPlantService
    {
        public PlantEntity[] GetAllPlants();

        public PlantEntity GetPlantById(Guid id);
    }

    public class PlantService : IPlantService
    {
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
