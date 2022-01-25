//using FakeItEasy;
//using FluentAssertions;
//using Microsoft.AspNetCore.Mvc;
//using NUnit.Framework;
//using PlantPodService.Controllers;
//using PlantPodService.Services;
//using PlantPodService.ViewModel;
//using System;

//namespace PlantPodServiceTests.Controllers
//{
//    [TestFixture]
//    public sealed class SensorsControllerTests
//    {
//        private readonly SensorsController _sut;
//        private readonly ILiveDataService _liveDataService = A.Fake<ILiveDataService>(options => options.Strict());

//        public SensorsControllerTests()
//        {
//            _sut = new SensorsController(_liveDataService);
//        }

//        [Test]
//        public void ReceiveSensorData_ReturnsOk()
//        {
//            var data = new Sensor();
//            A
//                .CallTo(() => _liveDataService.SetSensorData(data))
//                .DoesNothing();

//            var result = _sut.ReceiveSensorData(data);

//            result.Should().BeOfType<OkResult>();
//        }

//        [Test]
//        public void ReceiveSensorData_ReturnsBadRequestOnInvalidSensorId()
//        {
//            var data = new Sensor();
//            A
//                .CallTo(() => _liveDataService.SetSensorData(data))
//                .Throws(new InvalidOperationException());

//            var result = _sut.ReceiveSensorData(data);

//            result.Should().BeOfType<BadRequestObjectResult>();
//        }
//    }
//}
