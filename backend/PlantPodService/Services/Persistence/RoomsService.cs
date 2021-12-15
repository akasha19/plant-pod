using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PlantPodService.Model;

namespace PlantPodService.Services.Persistence
{
    public interface IRoomsService
    {
        public IEnumerable<Room> GetRooms();

        public Room GetRoomById();

        public ImmutableArray<Guid> GetSensorIds();
    }

    public sealed class RoomsService : IRoomsService
    {
        public Room GetRoomById()
        {
            throw new NotImplementedException();
        }

        public ImmutableArray<Guid> GetSensorIds()
        {
            //Todo: implement
            return new [] { Guid.Parse("196db225-e5ef-4636-b967-c214a0ddb73f") }.ToImmutableArray();
        }

        public IEnumerable<Room> GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
