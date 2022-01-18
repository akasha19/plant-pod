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
    public class PlantsControllerTests
    {
        private readonly PlantsController _sut;
        private readonly IPlantService _plantService = A.Fake<IPlantService>(options => options.Strict());
        private readonly Guid _plantId = Guid.NewGuid();
        private readonly Plant _plant;
        private readonly Plant[] _plants;

        public PlantsControllerTests()
        {
            var config = new MapperConfigurationExpression();
            config.AddProfile(new MappingProfile());
            var mapper = new Mapper(new MapperConfiguration(config));
            
            _sut = new PlantsController(_plantService, mapper);

            var plantEntity = PlantFactory.PlantEntity(_plantId);
            _plant = PlantFactory.Plant(_plantId);
            var plantIdTwo = Guid.NewGuid();
            var plantEntities = new[]
            {
                plantEntity,
                PlantFactory.PlantEntity(plantIdTwo)
            };
            _plants = new[]
            {
                _plant,
                PlantFactory.Plant(plantIdTwo)
            };

            A
                .CallTo(() => _plantService.GetAllPlants())
                .Returns(plantEntities);
            A
                .CallTo(() => _plantService.GetPlantById(_plantId))
                .Returns(PlantFactory.PlantEntity(_plantId));
        }

        [Test]
        public void GetAllPlants_ReturnsOkObjectResult()
        {
            var result = _sut.GetAllPlants();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetAllPlants_ReturnsAllPlants()
        {
            var result = _sut.GetAllPlants();

            var okObject = (OkObjectResult) result;
            okObject?.Value.Should().BeEquivalentTo(_plants);
        }

        [Test]
        public void GetPlantById_ReturnsOkObjectResult()
        {
            var result = _sut.GetPlantById(_plantId.ToString());

            result.Should().BeOfType<OkObjectResult>();
            var okObject = (OkObjectResult)result;
            okObject?.Value.Should().BeEquivalentTo(_plant);
        }

        [Test]
        public void GetPlantById_ReturnsCorrectPlant()
        {
            var result = _sut.GetPlantById(_plantId.ToString());

            result.Should().BeOfType<OkObjectResult>();
            var okObject = (OkObjectResult)result;
            okObject?.Value.Should().BeEquivalentTo(_plant);
        }

        [Test]
        public void GetPlantById_ReturnsNotFoundOnUnknownId()
        {
            A
                .CallTo(() => _plantService.GetPlantById(_plantId))
                .Returns(null).Once();

            var result = _sut.GetPlantById(_plantId.ToString());

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Test]
        public void GetPlantById_ReturnsBadRequestOnInvalidId()
        {
           var result = _sut.GetPlantById("this_is_not_a_valid_guid");
           
           result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
