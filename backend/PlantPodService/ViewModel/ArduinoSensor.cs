using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantPodService.ViewModel
{
    public class ArduinoSensor
    {
        public Guid? Id { get; set; }

        public decimal? Humidity { get; set; }

        public decimal? Ph { get; set; }

        public decimal? Temperature { get; set; }

        public decimal? Moisture { get; set; }

        public int? AirQuality { get; set; }
    }
}
