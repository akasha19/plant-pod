using Microsoft.AspNetCore.Mvc;
using PlantPodService.Model;
using PlantPodService.ViewModel;

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
