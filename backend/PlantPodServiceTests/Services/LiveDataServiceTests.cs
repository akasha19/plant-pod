using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using PlantPodService.Services;
using System;
using PlantPodService.Model;

namespace PlantPodServiceTests.Services
{
    [TestFixture]
    class LiveDataServiceTests
    {
        protected ILiveDataService Sut;
        protected ISensorsService SensorsService = A.Fake<SensorsService>(options => options.Strict());
        protected Guid ValidSensorId = Guid.NewGuid();
        protected Guid ValidSensorIdTwo = Guid.NewGuid();

        LiveDataServiceTests()
        {
            A.
                CallTo(() => SensorsService.GetSensors())
                .Returns(new [] { new Sensor() { Id = ValidSensorId }, new Sensor() { Id = ValidSensorIdTwo } });
            Sut = new LiveDataService();
        }

        [Test]
        public void SetSensorData_ShouldNotThrowOnValidValues()
        {
            var data = new SensorData() {SensorId = ValidSensorId, Temperature = 25.5m };

            Action act = () => Sut.SetSensorData(data);

            act.Should().NotThrow();
        }

        [Test]
        public void SetSensorData_ShouldThrowWhenReceivingDataFromUnknownSensor()
        {
            var data = new SensorData() { SensorId = Guid.NewGuid(), Temperature = 25.5m };

            Action act = () => Sut.SetSensorData(data);

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void GetSensorData_ShouldReturnSensorData()
        {
            var result = Sut.GetSensorData();

            result.Should().BeOfType<SensorData[]>().And.NotBeEmpty();
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
            var data = new SensorData() { SensorId = ValidSensorId, Temperature = 13.3m };
            var dataTwo = new SensorData() { SensorId = ValidSensorIdTwo, Temperature = 14.3m };
            Sut.SetSensorData(new SensorData { SensorId = ValidSensorId, Temperature = 24.6m });
            Sut.SetSensorData(new SensorData { SensorId = ValidSensorIdTwo, Temperature = 25.6m });
            Sut.SetSensorData(data);
            Sut.SetSensorData(dataTwo);

            var result = Sut.GetSensorData();

            result.Should().BeSameAs(new[] { data, dataTwo });
        }

        [Test]
        public void GetSensorDataById_ShouldReturnSensorData()
        {
            var result = Sut.GetSensorDataById(ValidSensorId);

            result.Should().BeOfType<SensorData>();
        }

        [Test]
        public void GetSensorDataById_ShouldReturnNewestSensorData()
        {
            var data = new SensorData() { SensorId = ValidSensorId, Temperature = 13.3m };
            Sut.SetSensorData(new SensorData { SensorId = ValidSensorId, Temperature = 24.6m });
            Sut.SetSensorData(data);

            var result = Sut.GetSensorDataById(ValidSensorId);

            result.Should().BeSameAs(data);
        }
    }
}
