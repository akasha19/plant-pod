using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PlantPodService.Services;
using PlantPodService.ViewModel;
using System;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ILiveDataService _liveDataService;
        private readonly IHubContext<LiveDataHub> _liveDataHubContext;

        public SensorsController(ILiveDataService liveDataService, IHubContext<LiveDataHub> liveDataHubContext)
        {
            _liveDataService = liveDataService;
            _liveDataHubContext = liveDataHubContext;
        }

        [HttpPost]
        public IActionResult ReceiveSensorData([FromBody] Sensor data)
        {
            try
            {
                _liveDataService.SetSensorData(data);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            SendDataToClientsAsync();

            return Ok();
        }

        private async void SendDataToClientsAsync()
        {
            await _liveDataHubContext.Clients.All.SendAsync("ReceiveMessage", _liveDataService.GetSensorData());
        }
    }
}
