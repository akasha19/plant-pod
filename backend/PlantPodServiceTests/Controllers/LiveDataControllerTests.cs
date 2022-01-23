using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PlantPodService.Controllers;
using PlantPodService.Services;
using PlantPodService.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PlantPodService.Controllers.LiveDataServerSideEvent;

namespace PlantPodServiceTests.Controllers
{
    [TestFixture]
    public class LiveDataControllerTests
    {
        private readonly LiveDataController _sut;
        private readonly ILiveDataService _liveDataService = A.Fake<ILiveDataService>(options => options.Strict());
        private readonly Guid _validId = Guid.NewGuid();
        private readonly Guid _invalidId = Guid.NewGuid();

        public LiveDataControllerTests()
        {
            A
                .CallTo(() => _liveDataService.GetSensorData())
                .Returns(Sensor);

            A
                .CallTo(() => _liveDataService.GetSensorDataById(_validId))
                .Returns(SingleSensor);

            A
                .CallTo(() => _liveDataService.GetSensorDataById(_invalidId))
                .Returns(null);

                _sut = new LiveDataController(_liveDataService);
        }

        [Test]
        public void GetLiveData_ReturnsStatusCodeOk()
        {
            var result = _sut.GetLiveData();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetLiveData_ReturnsData()
        {
            var result = _sut.GetLiveData();

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new OkObjectResult(Sensor));
        }

        [Test]
        public void GetLiveDataById_ReturnsStatusCodeOk()
        {
            var result = _sut.GetLiveDataById(_validId);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetLiveDataById_ReturnsData()
        {
            var result = _sut.GetLiveDataById(_validId);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new OkObjectResult(SingleSensor));
        }

        [Test]
        public void GetLiveDataById_ReturnsBadRequestOnInvalidId()
        {
            var result = _sut.GetLiveDataById(_invalidId);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new BadRequestResult());
        }


        private ImmutableList<Sensor> Sensor => new List<Sensor>()
        {
            new Sensor()
            {
                Id = Guid.Parse("6077a31f-9d8c-4d47-b4a7-5ad9b3163b8e"),
                Temperature = 13.5m
            },
            new Sensor()
            {
                Id = Guid.Parse("9b901beb-8928-44e9-a5f1-08ef83907673"),
                Temperature = 16.5m
            }
        }.ToImmutableList();

        private Sensor SingleSensor => new Sensor()
        {
            Id = _validId,
            Temperature = 12.8m
        };
    }
}
