using FakeItEasy;
using NUnit.Framework;
using PlantPodService.Controllers;
using PlantPodService.Services.Persistence;

namespace PlantPodServiceTests.Controllers
{
    [TestFixture]
    public class PlantsControllerTests
    {
        private readonly PlantsController _sut;
        private readonly IPlantService _plantService = A.Fake<IPlantService>();

        public PlantsControllerTests()
        {
            _sut = new PlantsController(_plantService);
        }

        [Test]
        public void GetAllPlants_ReturnsOkObjectResult()
        {

        }

        [Test]
        public void GetAllPlants_ReturnsAllPlants()
        {

        }

        [Test]
        public void GetPlantById_OkObjectResult()
        {

        }

        [Test]
        public void GetPlantById_ReturnsCorrectPlant()
        {

        }

        [Test]
        public void GetPlantById_ReturnsNotFoundOnUnknownId()
        {

        }

        [Test]
        public void GetPlantById_ReturnsBadRequestOnInvalidId()
        {

        }
    }
}
