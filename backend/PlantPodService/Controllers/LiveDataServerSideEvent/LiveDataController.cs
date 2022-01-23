using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlantPodService.Services;
using PlantPodService.ViewModel;

namespace PlantPodService.Controllers.LiveDataServerSideEvent
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

        //[HttpGet]
        //[Route("")]
        //public IActionResult GetLiveData()
        //{
        //    return new OkObjectResult(_liveDataService.GetSensorData());
        //}

        //[HttpGet]
        //[Route("{id:guid}")]
        //public IActionResult GetLiveDataById([FromRoute(Name = "id")] Guid id)
        //{
        //    var data = _liveDataService.GetSensorDataById(id);
        //    if (data == null)
        //    {
        //        return BadRequest($"No sensor with the id {id} found.");
        //    }
            
        //    return new OkObjectResult(data);
        //}

        [HttpGet("/sse")]
        public async Task ServerSideEvent()
        {
            await HttpContext.ServerSideEventInitAsync();
            Thread.Sleep(500);
            var id = Guid.Parse("196db225-e5ef-4636-b967-c214a0ddb73f");
            await HttpContext.ServerSideEventSendEventAsync(
                new ServerSideEvent()
                {
                    Id = id.ToString(),
                    Name = "event name",
                    Data = new Sensor()
                    {
                        Id = id,
                        Humidity = 35.3m,
                        Moisture = 29.4m,
                        Ph = 7.5m,
                        Temperature = 25.6m
                    },
                    Retry = 10
                }
            );
        }
    }
}
