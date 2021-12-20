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
        private readonly Guid _idOne = Guid.NewGuid();
        private readonly Guid _idTwo = Guid.NewGuid();

        public PlantsControllerTests()
        {
            var config = new MapperConfigurationExpression();
            config.AddProfile(new MappingProfile());
            var mapper = new Mapper(new MapperConfiguration(config));
            
            _sut = new PlantsController(_plantService, mapper);
        }

        [Test]
        public void GetAllPlants_ReturnsOkObjectResult()
        {
            A
                .CallTo(() => _plantService.GetAllPlants())
                .Returns(new []{ PlantFactory.PlantEntity() });

            var result = _sut.GetAllPlants();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetAllPlants_ReturnsAllPlants()
        {
            var plantEntities = new[]
            {
                PlantFactory.PlantEntity(_idOne),
                PlantFactory.PlantEntity(_idTwo)
            };
            var plants = new[]
            {
                PlantFactory.Plant(_idOne),
                PlantFactory.Plant(_idTwo)
            };
            A
                .CallTo(() => _plantService.GetAllPlants())
                .Returns(plantEntities);

            var result = _sut.GetAllPlants();

            var okObject = (OkObjectResult) result;
            okObject?.Value.Should().BeEquivalentTo(plants);
        }

        [Test]
        public void GetPlantById_ReturnsOkObjectResult()
        {
            A
                .CallTo(() => _plantService.GetPlantById(_idOne))
                .Returns(PlantFactory.PlantEntity());

            var result = _sut.GetPlantById(_idOne.ToString());

            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetPlantById_ReturnsCorrectPlant()
        {
            var plantEntity = PlantFactory.PlantEntity(_idOne);
            var plant = PlantFactory.Plant(_idOne);
            A
                .CallTo(() => _plantService.GetPlantById(plantEntity.Id))
                .Returns(plantEntity);

            var result = _sut.GetPlantById(plantEntity.Id.ToString());

            var okObject = (OkObjectResult) result;
            okObject?.Value.Should().BeEquivalentTo(plant);
        }

        [Test]
        public void GetPlantById_ReturnsNotFoundOnUnknownId()
        {
            A
                .CallTo(() => _plantService.GetPlantById(_idOne))
                .Returns(null);

            var result = _sut.GetPlantById(_idOne.ToString());

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
