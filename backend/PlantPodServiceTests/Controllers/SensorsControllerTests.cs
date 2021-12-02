using NUnit.Framework;
using FluentAssertions;
using PlantPodService.Controllers;
using backend.model;
using Microsoft.AspNetCore.Mvc;

namespace PlantPodServiceTests
{
    public class SensorsControllerTests
    {
        [Test]
        public void ReceiveSensorData_ShouldReturnNoContentResult()
        {
            var sut = new SensorsController();
            var data = new SensorData();

            var result = sut.ReceiveSensorData(data);

            result.Should().BeOfType<NoContentResult>();
        }
    }
}