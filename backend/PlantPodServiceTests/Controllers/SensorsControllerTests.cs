using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PlantPodService.Controllers;
using PlantPodService.ViewModel;

namespace PlantPodServiceTests.Controllers
{
    [TestFixture]
    public sealed class SensorsControllerTests
    {
        [Test]
        public void ReceiveSensorData_ReturnsNoContentResult()
        {
            var sut = new SensorsController();
            var data = new Sensor();

            var result = sut.ReceiveSensorData(data);

            result.Should().BeOfType<NoContentResult>();
        }
    }
}
