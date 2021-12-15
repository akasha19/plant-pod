using System;

namespace PlantPodService.ViewModel
{
    public sealed class Sensor
    {
        public Guid? Id { get; set; }

        public decimal? Humidity { get; set; }

        public decimal? Ph { get; set; }

        public decimal? Temperature { get; set; }

        public decimal? Moisture { get; set; }
    }
}
