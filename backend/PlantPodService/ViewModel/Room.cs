using System;

namespace PlantPodService.ViewModel
{
    public class Room
    {
        public Guid Id { get; set; }
        public Guid SensorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Facilities { get; set; }
        public string ImageSource { get; set; }
    }
}
