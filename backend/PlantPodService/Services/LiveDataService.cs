using PlantPodService.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PlantPodService.Services.Persistence;

namespace PlantPodService.Services
{
    public interface ILiveDataService
    {
        public event EventHandler NewLiveDataAvailable;

        public void SetSensorData(Sensor data);

        public IImmutableList<Sensor> GetSensorData();

        public Sensor GetSensorDataById(Guid id);
    }

    public sealed class LiveDataService : ILiveDataService
    {
        public event EventHandler NewLiveDataAvailable;

        private readonly Dictionary<Guid, Sensor> _sensorData = new Dictionary<Guid, Sensor>();

        public LiveDataService(IRoomService roomService)
        {
            foreach (var sensorId in roomService.GetSensorIds())
            {
                _sensorData.Add(sensorId, new Sensor() {Id = sensorId});
            }
        }

        public IImmutableList<Sensor> GetSensorData()
        {
            return _sensorData.Values.ToImmutableList();
        }

        public Sensor GetSensorDataById(Guid id)
        {
            try
            {
                var data = _sensorData[id];
                return data;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
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
            OnNewLiveDataAvailable(EventArgs.Empty);

        }

        private void OnNewLiveDataAvailable(EventArgs e)
        {
            var handler = NewLiveDataAvailable;
            handler?.Invoke(this, e);
        }
    }
}
