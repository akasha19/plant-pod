using System;

namespace backend.model
{
    public sealed class SensorData
    {
        public Guid SensorId { get; set; }

        public decimal Temperature { get; set; }
    }
}
