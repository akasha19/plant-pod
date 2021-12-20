using Microsoft.AspNetCore.Mvc;
using PlantPodService.Services.Persistence;
using System;
using AutoMapper;
using PlantPodService.ViewModel;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _plantService;
        private readonly IMapper _mapper;

        public PlantsController(IPlantService plantService, IMapper mapper)
        {
            _plantService = plantService;
            _mapper = mapper;
        }

        [Route("")]
        public IActionResult GetAllPlants()
        {
            var plants = _mapper.Map<Plant[]>(_plantService.GetAllPlants());

            return new OkObjectResult(plants);
        }

        [Route("{id}")]
        public IActionResult GetPlantById([FromQuery(Name = "id")] string id)
        {
            if (!Guid.TryParse(id, out var plantId))
            {
                return BadRequest("id is not a valid Guid.");
            }

            var plant = _plantService.GetPlantById(plantId);
            if (plant == null)
            {
                return NotFound($"no plant with id: {id}");
            }

            return Ok(_mapper.Map<Plant>(plant));
        }
    }
}
