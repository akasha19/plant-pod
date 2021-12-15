using Microsoft.AspNetCore.Mvc;
using PlantPodService.Model;
using PlantPodService.ViewModel;
using Sensor = PlantPodService.ViewModel.Sensor;

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
