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
        private WebSocket _webSocket;

        public LiveDataController(ILiveDataService liveDataService)
        {
            _liveDataService = liveDataService;
            _liveDataService.NewLiveDataAvailable += OnNewLiveDataAvailable;
        }

        private async void OnNewLiveDataAvailable(object sender, EventArgs e)
        {
            if (_webSocket != null)
            {
                await SendData();
            }
        }

        [HttpGet("")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                _webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                
                //await SendData(_webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }

        private async Task SendData()
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
                await _webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                
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
