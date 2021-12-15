using Microsoft.AspNetCore.Mvc;
using PlantPodService.ViewModel;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorsController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceiveSensorData([FromBody] Sensor data)
        {
            return new NoContentResult();
        }
    }
}
