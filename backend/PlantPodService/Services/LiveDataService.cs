using PlantPodService.Model;
using System;
using System.Collections.Generic;

namespace PlantPodService.Services
{
    public interface ILiveDataService
    {
        public void SetSensorData(SensorData data);

        public IEnumerable<SensorData> GetSensorData();

        public SensorData GetSensorDataById(Guid id);
    }

    public class LiveDataService : ILiveDataService
    {
        public IEnumerable<SensorData> GetSensorData()
        {
            throw new NotImplementedException();
        }

        public SensorData GetSensorDataById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SetSensorData(SensorData data)
        {
            throw new NotImplementedException();
        }
    }
}
