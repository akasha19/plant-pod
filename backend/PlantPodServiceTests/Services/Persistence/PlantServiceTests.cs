using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PlantPodService.Model;
using PlantPodService.Services.Persistence;
using PlantPodServiceTests.Factories;
using System;
using System.Linq;

namespace PlantPodServiceTests.Services.Persistence
{
    [TestFixture]
    class PlantServiceTests
    {
        private readonly IPlantService _sut;
        private readonly Guid _plantId = Guid.NewGuid();
        private readonly PlantEntity _plant;
        private readonly PlantEntity[] _plants;

        public PlantServiceTests()
        {
            var options = new DbContextOptionsBuilder<PlantPodServiceDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new PlantPodServiceDbContext(options);

            _plants = new[]
            {
                PlantFactory.PlantEntity(_plantId),
                PlantFactory.PlantEntity()
            };
            _plant = _plants.First();

            dbContext.Plants.AddRange(_plants);
            dbContext.SaveChanges();
            _sut = new PlantService(dbContext);
        }

        [Test]
        public void GetAllPlants_ReturnsAllPlants()
        {
            var result = _sut.GetAllPlants();

            result.Should().BeEquivalentTo(_plants);
        }

        [Test]
        public void GetPlantById_ReturnsCorrectPlant()
        {
            var result = _sut.GetPlantById(_plantId);

            result.Should().NotBeNull().And.BeEquivalentTo(_plant);
        }

        [Test]
        public void GetPlantById_ReturnsNullOnUnknownId()
        {
            var result = _sut.GetPlantById(Guid.NewGuid());

            result.Should().BeNull();
        }
    }
}
