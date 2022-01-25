using PlantPodService.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PlantPodService.Services.Persistence;

namespace PlantPodService.Services
{
    public interface ILiveDataService
    {
        public void SetSensorData(Sensor data);

        public ImmutableArray<Sensor> GetSensorData();
    }

    public sealed class LiveDataService : ILiveDataService
    {
        private readonly Dictionary<Guid, Sensor> _sensorData = new Dictionary<Guid, Sensor>();

        public LiveDataService(IRoomService roomService)
        {
            foreach (var sensorId in roomService.GetSensorIds())
            {
                _sensorData.Add(sensorId, new Sensor() {Id = sensorId});
            }
        }

        public ImmutableArray<Sensor> GetSensorData()
        {
            return _sensorData.Values.ToImmutableArray();
        }

        public void SetSensorData(Sensor data)
        {
            if (data.Id == null)
            {
                throw new InvalidOperationException("id cannot be null");
            }
            if (!_sensorData.ContainsKey((Guid)data.Id))
            {
                throw new InvalidOperationException("unknown id");
            }

            _sensorData[(Guid)data.Id] = data;
        }
    }
}
