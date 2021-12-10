using System;
using System.Collections.Generic;

namespace PlantPodService.Services
{
    public class Sensor
    {
        public Guid Id { get; set; }
    }

    public interface ISensorsService
    {
        public IEnumerable<Sensor> GetSensors();

        public Sensor GetSensorById();
    }

    public class SensorsService : ISensorsService
    {
        public Sensor GetSensorById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sensor> GetSensors()
        {
            throw new NotImplementedException();
        }
    }
}
