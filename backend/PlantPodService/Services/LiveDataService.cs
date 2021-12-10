using PlantPodService.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PlantPodService.Services
{
    public interface ILiveDataService
    {
        public void SetSensorData(SensorData data);

        public IImmutableList<SensorData> GetSensorData();

        public SensorData GetSensorDataById(Guid id);
    }

    public class LiveDataService : ILiveDataService
    {
        private readonly Dictionary<Guid, SensorData> _sensorData = new Dictionary<Guid, SensorData>();

        public LiveDataService(ISensorsService sensorsService)
        {
            foreach (var sensor in sensorsService.GetSensors())
            {
                _sensorData.Add(sensor.Id, new SensorData());
            }
        }

        public IImmutableList<SensorData> GetSensorData()
        {
            return _sensorData.Values.ToImmutableList();
        }

        public SensorData GetSensorDataById(Guid id)
        {
            return _sensorData[id];
        }

        public void SetSensorData(SensorData data)
        {
            if (data.SensorId != null && !_sensorData.ContainsKey((Guid)data.SensorId))
            {
                throw new InvalidOperationException("unknown id");
            }

            _sensorData[(Guid)data.SensorId] = data;
        }
    }
}
