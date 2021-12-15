using System;
using System.Collections.Generic;
using PlantPodService.Model;

namespace PlantPodService.Services.Persistence
{
    public interface IRoomsService
    {
        public IEnumerable<Room> GetRooms();

        public Room GetRoomById();
    }

    public sealed class RoomsService : IRoomsService
    {
        public Room GetRoomById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
