using Microsoft.AspNetCore.Mvc;
using PlantPodService.Services;
using System;

namespace PlantPodService.Controllers
{
    public class LiveDataController : Controller
    {
        private readonly ILiveDataService _liveDataService;

        public LiveDataController(ILiveDataService liveDataService)
        {
            _liveDataService = liveDataService;
        }

        [HttpGet]
        public IActionResult GetLiveData()
        {
            return new OkObjectResult(_liveDataService.GetSensorData());
        }

        [HttpGet]
        public IActionResult GetLiveDataById([FromQuery]Guid id)
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
