using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using PlantPodService.Services;
using PlantPodService.Services.Persistence;
using System;
using System.Collections.Immutable;
using Sensor = PlantPodService.ViewModel.Sensor;

namespace PlantPodServiceTests.Services
{
    [TestFixture]
    public class LiveDataServiceTests
    {
        protected ILiveDataService Sut;
        protected IRoomService RoomService = A.Fake<IRoomService>(options => options.Strict());
        protected Guid ValidSensorId = Guid.NewGuid();
        protected Guid ValidSensorIdTwo = Guid.NewGuid();

        public LiveDataServiceTests()
        {
            A.
                CallTo(() => RoomService.GetSensorIds())
                .Returns(new [] { ValidSensorId, ValidSensorIdTwo }.ToImmutableArray());
            Sut = new LiveDataService(RoomService);
        }

        [Test]
        public void SetSensorData_ShouldNotThrowOnValidValues()
        {
            var data = SensorData(null);

            Action act = () => Sut.SetSensorData(data);

            act.Should().NotThrow();
        }

        [Test]
        public void SetSensorData_ShouldThrowWhenReceivingDataFromUnknownSensor()
        {
            var data = SensorData(Guid.NewGuid());

            Action act = () => Sut.SetSensorData(data);

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void SetSensorData_ShouldThrowWhenSensorIdIsNull()
        {
            var data = new Sensor();

            Action act = () => Sut.SetSensorData(data);

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void GetSensorData_ShouldReturnSensorData()
        {
            var result = Sut.GetSensorData();

            result.Should().BeOfType<ImmutableArray<Sensor>>().And.NotBeEmpty();
        }

        [Test]
        public void GetSensorData_ShouldReturnAllSensorData()
        {
            var result = Sut.GetSensorData();

            result.Should().HaveCount(2);
        }

        [Test]
        public void GetSensorData_ShouldReturnNewestSensorDataForAllSensors()
        {
            var data = new Sensor { Id = ValidSensorId, Temperature = 13.3m, Humidity = 53.4m, Moisture = 49.2m, Ph = 4.3m };
            var dataTwo = new Sensor { Id = ValidSensorIdTwo, Temperature = 23.3m, Humidity = 43.7m, Moisture = 43.7m, Ph = 5.8m };
            Sut.SetSensorData(SensorData(ValidSensorId));
            Sut.SetSensorData(SensorData(ValidSensorIdTwo));
            Sut.SetSensorData(data);
            Sut.SetSensorData(dataTwo);

            var result = Sut.GetSensorData();

            result.Should().BeEquivalentTo(new[] { data, dataTwo });
        }

        private Sensor SensorData(Guid? id) => new Sensor()
        {
            Id = id ?? ValidSensorId,
            Temperature = 25.5m,
            Humidity = 40.3m,
            Moisture = 53.7m,
            Ph = 7.5m
        };
    }
}
