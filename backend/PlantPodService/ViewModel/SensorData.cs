using System;

namespace PlantPodService.ViewModel
{
    public sealed class SensorData
    {
        public Guid? SensorId { get; set; }

        public decimal? Temperature { get; set; }
    }
}
