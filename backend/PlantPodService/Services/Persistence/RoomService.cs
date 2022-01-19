using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using PlantPodService.Model;

namespace PlantPodService.Services.Persistence
{
    public interface IRoomService
    {
        public IEnumerable<RoomEntity> GetAllRooms();

        public RoomEntity GetRoomById(Guid id);

        public ImmutableArray<Guid> GetSensorIds();
    }

    public sealed class RoomService : IRoomService
    {
        private readonly PlantPodServiceDbContext _dbContext;

        public RoomService(PlantPodServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RoomEntity GetRoomById(Guid id)
        {
            return _dbContext.Rooms.FirstOrDefault(e => e.Id == id);
        }

        public ImmutableArray<Guid> GetSensorIds()
        {
            return _dbContext.Rooms.Select(e => e.SensorId).ToImmutableArray();
        }

        public IEnumerable<RoomEntity> GetAllRooms()
        {
            return _dbContext.Rooms;
        }
    }
}
