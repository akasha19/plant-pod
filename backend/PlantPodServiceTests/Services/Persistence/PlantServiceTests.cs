using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PlantPodService.Model;
using PlantPodService.Services.Persistence;
using System;

namespace PlantPodServiceTests.Services.Persistence
{
    [TestFixture]
    class PlantServiceTests
    {
        private readonly IPlantService _sut;
        private readonly Guid _plantId = Guid.NewGuid();

        public PlantServiceTests()
        {
            var options = new DbContextOptionsBuilder<PlantPodServiceDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new PlantPodServiceDbContext(options);
            dbContext.Plants.AddRange(Plants());
            dbContext.SaveChanges();
            _sut = new PlantService(dbContext);
        }

        [Test]
        public void GetAllPlants_ReturnsAllPlants()
        {
            var result = _sut.GetAllPlants();

            result.Should().BeSameAs(Plants());
        }

        [Test]
        public void GetPlantById_ReturnsCorrectPlant()
        {
            var result = _sut.GetPlantById(_plantId);

            result.Should().NotBeNull().And.BeSameAs(Plant());
        }

        [Test]
        public void GetPlantById_ReturnsNullOnUnknownId()
        {
            var result = _sut.GetPlantById(Guid.NewGuid());

            result.Should().BeNull();
        }

        private PlantEntity Plant() => new PlantEntity
        {
            Id = _plantId,
            Care = "don't let it dry out",
            Description = "just some random plant",
            Image = "Todo Nika!",
            LongName = "plant long name",
            ShortName = "plant short name",
            MaxHumidity = 30.4m,
            Minph = 6.5m,
            Maxph = 9.1m,
            MaxTemperature = 35.7m,
            MinHumidity = 13.2m,
            MinTemperature = 12.4m,
            Moisture = Moisture.Moist
        };

        private PlantEntity[] Plants() => new[]
        {
            Plant(),
            new PlantEntity
            {
                Id = Guid.NewGuid(),
                Care = "don't make it too wet",
                Description = "another random plant",
                Image = "still a todo",
                LongName = "plant B long name",
                ShortName = "plant B short name",
                MaxHumidity = 29.6m,
                Minph = 3.9m,
                Maxph = 8.4m,
                MaxTemperature = 73.2m,
                MinHumidity = 77.1m,
                MinTemperature = 53.1m,
                Moisture = Moisture.Dry
            }
        };
    }
}
