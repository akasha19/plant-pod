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


        public IImmutableList<Sensor> GetSensorData();


        public Sensor GetSensorDataById(Guid id);
    }


    public sealed class LiveDataService : ILiveDataService
    {

        private readonly Dictionary<Guid, Sensor> _sensorData = new Dictionary<Guid, Sensor>();


        public LiveDataService(IRoomsService roomsService)
        {

            foreach (var sensor in roomsService.GetRooms())
            {

                _sensorData.Add(sensor.Id, new Sensor());
            }
        }


        public IImmutableList<Sensor> GetSensorData()
        {
            return _sensorData.Values.ToImmutableList();
        }


        public Sensor GetSensorDataById(Guid id)
        {
            return _sensorData[id];
        }


        public void SetSensorData(Sensor data)
        {

            if (data.Id != null && !_sensorData.ContainsKey((Guid)data.Id))
            {
                throw new InvalidOperationException("unknown id");
            }

            // ReSharper disable once PossibleInvalidOperationException

            _sensorData[(Guid)data.Id] = data;
        }
    }
}
