using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PlantPodService.Controllers.LiveDataWebSocket;
using PlantPodService.Services;
using PlantPodService.ViewModel;
using System;
using System.Threading.Tasks;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ILiveDataService _liveDataService;
        private IHubContext<LiveDataHub> _liveDataHubContext;

        public SensorsController(ILiveDataService liveDataService, IHubContext<LiveDataHub> liveDataHubContext)
        {
            _liveDataService = liveDataService;
            _liveDataHubContext = liveDataHubContext;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveSensorData([FromBody] Sensor data)
        {
            try
            {
                _liveDataService.SetSensorData(data);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            await _liveDataHubContext.Clients.All.SendAsync("ReceiveMessage", _liveDataService.GetSensorData());
            return Ok();

        }
    }
}
