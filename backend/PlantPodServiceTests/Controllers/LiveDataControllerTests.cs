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

namespace PlantPodServiceTests.Controllers
{
    [TestFixture]
    public sealed class LiveDataControllerTests
    {

    private readonly LiveDataController _sut;
    private readonly ILiveDataService _liveDataService = A.Fake<ILiveDataService>(options => options.Strict());
    private readonly Guid _validSensorId = Guid.NewGuid();
    private readonly Guid _invalidSensorId = Guid.NewGuid();

    public LiveDataControllerTests()
    {
        A
            .CallTo(() => _liveDataService.GetSensorData())
            .Returns(SensorData);

        A
            .CallTo(() => _liveDataService.GetSensorDataById(_validSensorId))
            .Returns(SingleSensorData);

        A
            .CallTo(() => _liveDataService.GetSensorDataById(_invalidSensorId))
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
            result.Should().BeEquivalentTo(new OkObjectResult(SensorData));
        }

        [Test]
        public void GetLiveDataById_ReturnsStatusCodeOk()
        {
            var result = _sut.GetLiveDataById(_validSensorId);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetLiveDataById_ReturnsData()
        {
            var result = _sut.GetLiveDataById(_validSensorId);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new OkObjectResult(SingleSensorData));
        }

        [Test]
        public void GetLiveDataById_ReturnsBadRequestOnInvalidSensorId()
        {
            var result = _sut.GetLiveDataById(_invalidSensorId);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new BadRequestResult());
        }


        private ImmutableList<SensorData> SensorData => new List<SensorData>()
        {
            new SensorData()
            {
                SensorId = Guid.Parse("6077a31f-9d8c-4d47-b4a7-5ad9b3163b8e"),
                Temperature = 13.5m
            },
            new SensorData()
            {
                SensorId = Guid.Parse("9b901beb-8928-44e9-a5f1-08ef83907673"),
                Temperature = 16.5m
            }
        }.ToImmutableList();

        private SensorData SingleSensorData => new SensorData()
        {
            SensorId = _validSensorId,
            Temperature = 12.8m
        };
    }
}
