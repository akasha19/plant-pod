using PlantPodService.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PlantPodService.Model;
using PlantPodService.Services.Persistence;

namespace PlantPodService.Services
{
    public interface ILiveDataService
    {
        public void SetSensorData(ArduinoSensor data);

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

        public void SetSensorData(ArduinoSensor data)
        {
            if (data.Id == null)
            {
                throw new InvalidOperationException("id cannot be null");
            }
            if (!_sensorData.ContainsKey((Guid)data.Id))
            {
                throw new InvalidOperationException("unknown id");
            }

            try
            {
                var sensorData = new Sensor()
                {
                    Id = (Guid)data.Id,
                    Humidity = data.Humidity,
                    Ph = data.Ph,
                    Temperature = data.Temperature,
                    AirQuality = MapAirQuality(data.AirQuality),
                    Moisture = MapMoisture(data.Moisture)
                };

                _sensorData[(Guid)data.Id] = sensorData;
            }
            catch (InvalidCastException exception)
            {
                throw new InvalidOperationException(exception.Message);
            }
        }

        private string MapMoisture(decimal? moisture)
        {
            if (moisture != null)
            {
                var maxMoisture = 900;
                var moistureStates = Enum.GetNames(typeof(Moisture)).Length;
                Moisture result;

                switch (moisture)
                {
                    case var n when (n >= 0 && n <= maxMoisture / moistureStates):
                        result = Moisture.Dry;
                        break;

                    case var n when (n > maxMoisture / moistureStates && n <= (maxMoisture / moistureStates) * 2):
                        result = Moisture.Normal;
                        break;

                    case var n when (n > (maxMoisture / moistureStates) * 2 && n <= (maxMoisture / moistureStates) * 3):
                        result = Moisture.Moist;
                        break;

                    case var n when (n > (maxMoisture / moistureStates) * 3 && n <= maxMoisture):
                        result = Moisture.Wet;
                        break;

                    default:
                        throw new InvalidOperationException($"Moisture value {moisture} is out of range");
                }

                return result.ToString();
            }

            throw new InvalidOperationException($"Moisture value may not be null");
        }

        private string MapAirQuality(int? airQuality)
        {
            if (airQuality != null && System.Enum.IsDefined(typeof(AirQuality), airQuality))
            {
                return ((AirQuality)airQuality).ToString();
            }
            throw new InvalidCastException("enum value for AirQuality was out of range");
        }
    }
}
