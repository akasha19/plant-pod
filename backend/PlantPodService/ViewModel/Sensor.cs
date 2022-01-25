using PlantPodService.Model;
using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace PlantPodService.ViewModel
{
    public sealed class Sensor
    {
        public Guid Id { get; set; }

        public decimal? Humidity { get; set; }

        public decimal? Ph { get; set; }

        public decimal? Temperature { get; set; }

        public string Moisture { get; set; }

        public string AirQuality { get; set; }
    }
}
