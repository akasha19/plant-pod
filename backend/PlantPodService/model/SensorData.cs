using System;

namespace PlantPodService.Model
{
    public sealed class SensorData
    {
        public Guid? SensorId { get; set; }

        public decimal? Temperature { get; set; }
    }
}
