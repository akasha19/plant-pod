using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PlantPodService.Controllers;
using PlantPodService.Model;

namespace PlantPodServiceTests.Controllers
{
    [TestFixture]
    public class SensorsControllerTests
    {
        [Test]
        public void ReceiveSensorData_ReturnsNoContentResult()
        {
            var sut = new SensorsController();
            var data = new SensorData();

            var result = sut.ReceiveSensorData(data);

            result.Should().BeOfType<NoContentResult>();
        }
    }
}
