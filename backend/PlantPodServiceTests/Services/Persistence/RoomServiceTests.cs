using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlantPodService.Model;
using PlantPodService.Services.Persistence;
using PlantPodServiceTests.Factories;

namespace PlantPodServiceTests.Services.Persistence
{
    [TestFixture]
    class RoomServiceTests
    {
        private readonly IRoomService _sut;
        private readonly Guid _roomId = Guid.NewGuid();
        private readonly RoomEntity _room;
        private readonly RoomEntity[] _rooms;

        public RoomServiceTests()
        {
            var options = new DbContextOptionsBuilder<PlantPodServiceDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new PlantPodServiceDbContext(options);

            _rooms = new[]
            {
                RoomFactory.RoomEntity(_roomId),
                RoomFactory.RoomEntity()
            };
            _room = _rooms.First();

            dbContext.Rooms.AddRange(_rooms);
            dbContext.SaveChanges();
            _sut = new RoomService(dbContext);
        }

        [Test]
        public void GetAllRooms_ReturnsAllRooms()
        {
            var result = _sut.GetAllRooms();

            result.Should().BeEquivalentTo(_rooms);
        }

        [Test]
        public void GetRoomById_ReturnsCorrectRoom()
        {
            var result = _sut.GetRoomById(_roomId);

            result.Should().NotBeNull().And.BeEquivalentTo(_room);
        }

        [Test]
        public void GetRoomById_ReturnsNullOnUnknownId()
        {
            var result = _sut.GetRoomById(Guid.NewGuid());

            result.Should().BeNull();
        }

        [Test]
        public void GetSensorIds_ReturnsCorrectIds()
        {
            var result = _sut.GetSensorIds();

            result.Should().BeEquivalentTo(_rooms.Select(t => t.SensorId).ToImmutableArray());
        }
    }
}
