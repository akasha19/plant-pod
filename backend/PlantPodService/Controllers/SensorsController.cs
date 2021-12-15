using System;
using Microsoft.AspNetCore.Mvc;
using PlantPodService.Services;
using PlantPodService.ViewModel;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ILiveDataService _liveDataService;

        public SensorsController(ILiveDataService liveDataService)
        {
            _liveDataService = liveDataService;
        }

        [HttpPost]
        public IActionResult ReceiveSensorData([FromBody] Sensor data)
        {
            try
            {
                _liveDataService.SetSensorData(data);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
