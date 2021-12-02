using backend.model;
using Microsoft.AspNetCore.Mvc;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorsController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceiveSensorData([FromBody] SensorData data)
        {
            return new NoContentResult();
        }
    }
}
