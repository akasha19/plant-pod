using PlantPodService.Model;
using PlantPodService.ViewModel;
using System;

namespace PlantPodServiceTests.Factories
{
    internal static class RoomFactory
    {
        public static RoomEntity RoomEntity() => RoomEntity(Guid.NewGuid(), Guid.NewGuid());
        
        public static RoomEntity RoomEntity(Guid id) => RoomEntity(id, Guid.NewGuid());

        public static RoomEntity RoomEntity(Guid id, Guid sensorId) => new RoomEntity
        {
            Id = id,
            Name = "some Room",
            Description = "Description for some room",
            Facilities = new[] { "a facility", "another facility", "and a third" },
            ImageSource = "some/path/to/image.jpg",
            SensorId = sensorId
        };

        public static Room Room(Guid id, Guid sensorId) => new Room
        {
            Id = id,
            Name = "some Room",
            Description = "Description for some room",
            Facilities = new[] {"a facility", "another facility", "and a third"},
            ImageSource = "some/path/to/image.jpg",
            SensorId = sensorId
        };
    }
}
