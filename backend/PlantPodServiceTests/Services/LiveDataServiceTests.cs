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
        protected IRoomsService RoomsService = A.Fake<IRoomsService>(options => options.Strict());
        protected Guid ValidSensorId = Guid.NewGuid();
        protected Guid ValidSensorIdTwo = Guid.NewGuid();

        public LiveDataServiceTests()
        {
            A.
                CallTo(() => RoomsService.GetRooms())
                .Returns(new [] { new PlantPodService.Model.Room() { Id = ValidSensorId }, new PlantPodService.Model.Room() { Id = ValidSensorIdTwo } });
            Sut = new LiveDataService(RoomsService);
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
        public void GetSensorData_ShouldReturnSensorData()
        {
            var result = Sut.GetSensorData();

            result.Should().BeOfType<ImmutableList<Sensor>>().And.NotBeEmpty();
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

        [Test]
        public void GetSensorDataById_ShouldReturnSensorData()
        {
            var result = Sut.GetSensorDataById(ValidSensorId);

            result.Should().BeOfType<Sensor>();
        }

        [Test]
        public void GetSensorDataById_ShouldReturnNewestSensorData()
        {
            var data = new Sensor { Id = ValidSensorId, Temperature = 22.3m, Humidity = 38.7m, Moisture = 58.7m, Ph = 6.8m };
            Sut.SetSensorData(SensorData(null));
            Sut.SetSensorData(data);

            var result = Sut.GetSensorDataById(ValidSensorId);

            result.Should().BeSameAs(data);
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
