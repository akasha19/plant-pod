using System;

namespace PlantPodService.Model
{
    public sealed class Room
    {
        public Guid Id { get; set; }

        public Guid SensorId { get; set; }
    }
}