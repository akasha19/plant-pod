using PlantPodService.Model;
using System;
using System.Collections.Generic;

namespace PlantPodService.Services
{
    internal interface ISensorsService
    {
        public IEnumerable<Sensor> GetSensors();

        public Sensor GetSensorById();
    }

    internal sealed class SensorsService : ISensorsService
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
