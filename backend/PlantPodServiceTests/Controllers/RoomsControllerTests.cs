using AutoMapper;
using AutoMapper.Configuration;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PlantPodService.Controllers;
using PlantPodService.Services.Persistence;
using PlantPodService.ViewModel;
using PlantPodServiceTests.Factories;
using System;

namespace PlantPodServiceTests.Controllers
{
    [TestFixture]
    public class RoomsControllerTests
    {
        private readonly RoomsController _sut;
        private readonly IRoomService _roomService = A.Fake<IRoomService>(options => options.Strict());
        private readonly Guid _roomId = Guid.NewGuid();
        private readonly Room _room;
        private readonly Room[] _rooms;

        public RoomsControllerTests()
        {
            var config = new MapperConfigurationExpression();
            config.AddProfile(new MappingProfile());
            var mapper = new Mapper(new MapperConfiguration(config));

            _sut = new RoomsController(_roomService, mapper);

            var sensorIds = new [] { Guid.NewGuid(), Guid.NewGuid()};
            var roomEntity = RoomFactory.RoomEntity(_roomId, sensorIds[0]);
            _room = RoomFactory.Room(_roomId, sensorIds[0]);
            var roomIdTwo = Guid.NewGuid();
            var roomEntities = new[]
            {
                roomEntity,
                RoomFactory.RoomEntity(roomIdTwo, sensorIds[1])
            };
            _rooms = new[]
            {
                _room,
                RoomFactory.Room(roomIdTwo, sensorIds[1])
            };

            A
                .CallTo(() => _roomService.GetAllRooms())
                .Returns(roomEntities);
            A
                .CallTo(() => _roomService.GetRoomById(_roomId))
                .Returns(RoomFactory.RoomEntity(_roomId, sensorIds[0]));
        }

        [Test]
        public void GetAllRooms_ReturnsOkObjectResult()
        {
            var result = _sut.GetAllRooms();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetAllRooms_ReturnsAllRooms()
        {
            var result = _sut.GetAllRooms();

            var okObject = (OkObjectResult)result;
            okObject?.Value.Should().BeEquivalentTo(_rooms);
        }

        [Test]
        public void GetRoomById_ReturnsOkObjectResult()
        {
            var result = _sut.GetRoomById(_roomId.ToString());

            result.Should().BeOfType<OkObjectResult>();
            var okObject = (OkObjectResult)result;
            okObject?.Value.Should().BeEquivalentTo(_room);
        }

        [Test]
        public void GetRoomById_ReturnsCorrectRoom()
        {
            var result = _sut.GetRoomById(_roomId.ToString());

            result.Should().BeOfType<OkObjectResult>();
            var okObject = (OkObjectResult)result;
            okObject?.Value.Should().BeEquivalentTo(_room);
        }

        [Test]
        public void GetRoomById_ReturnsNotFoundOnUnknownId()
        {
            A
                .CallTo(() => _roomService.GetRoomById(_roomId))
                .Returns(null).Once();

            var result = _sut.GetRoomById(_roomId.ToString());

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Test]
        public void GetRoomById_ReturnsBadRequestOnInvalidId()
        {
            var result = _sut.GetRoomById("this_is_not_a_valid_guid");

            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
