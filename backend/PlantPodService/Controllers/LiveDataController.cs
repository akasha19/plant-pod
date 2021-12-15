using Microsoft.AspNetCore.Mvc;
using PlantPodService.Services;
using System;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveDataController : ControllerBase
    {
        private readonly ILiveDataService _liveDataService;

        public LiveDataController(ILiveDataService liveDataService)
        {
            _liveDataService = liveDataService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetLiveData()
        {
            return new OkObjectResult(_liveDataService.GetSensorData());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetLiveDataById([FromRoute(Name = "id")] Guid id)
        {
            var data = _liveDataService.GetSensorDataById(id);
            if (data == null)
            {
                return BadRequest($"No sensor with the id {id} found.");
            }
            
            return new OkObjectResult(data);
        }
    }
}
