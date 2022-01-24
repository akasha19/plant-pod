using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantPodService.Controllers.LiveDataServerSideEvent.SystemTextJsonSamples;
using PlantPodService.Services;
using PlantPodService.ViewModel;
using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

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

        [HttpGet("")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                
                await SendData(HttpContext, webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }

        private async Task SendData(HttpContext context, WebSocket webSocket)
        {
            var sensor = new Sensor()
            {
                Humidity = 34.8m,
                Id = Guid.NewGuid(),
                Moisture = 23.6m,
                Ph = 7.5m,
                Temperature = 12.4m
            };

            var data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(sensor, new JsonSerializerOptions{ PropertyNamingPolicy = new LowerCaseNamingPolicy() }));
            var buffer = new ArraySegment<byte>(data);

            while (true)
            {
                await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                
                Thread.Sleep(5000);
            }
        }
    }

    namespace SystemTextJsonSamples
    {
        public class LowerCaseNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name) =>
                name.ToLower();
        }
    }
}
