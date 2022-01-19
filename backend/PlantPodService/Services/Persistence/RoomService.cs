using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            throw new NotImplementedException();
        }

        public ImmutableArray<Guid> GetSensorIds()
        {
            //Todo: implement
            return new [] { Guid.Parse("196db225-e5ef-4636-b967-c214a0ddb73f") }.ToImmutableArray();
        }

        public IEnumerable<RoomEntity> GetAllRooms()
        {
            throw new NotImplementedException();
        }
    }
}
