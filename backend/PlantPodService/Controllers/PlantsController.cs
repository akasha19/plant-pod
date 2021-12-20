using System;
using Microsoft.AspNetCore.Mvc;
using PlantPodService.Services.Persistence;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantsController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [Route("")]
        public IActionResult GetAllPlants()
        {
            return new OkObjectResult("plants");
        }

        [Route("{id}")]
        public IActionResult GetPlantById([FromQuery(Name = "id")] string id)
        {
            return new OkObjectResult("plant");
        }
    }
}
