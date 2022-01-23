using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlantPodService.Controllers.LiveDataServerSideEvent
{
    public static class ServerSideEventHttpContextExtension
    {
        public static async Task ServerSideEventInitAsync(this HttpContext context)
        {
            context.Response.Headers.Add("Cache-Control", "no-cache");
            context.Response.Headers.Add("Content-Type", "text/event-stream");
            await context.Response.Body.FlushAsync();
        }

        public static async Task ServerSideEventSendEventAsync(this HttpContext context, ServerSideEvent eventData)
        {
            if (string.IsNullOrWhiteSpace(eventData.Id) is false)
                await context.Response.WriteAsync("id: " + eventData.Id + "\n");

            if (eventData.Retry != null)
                await context.Response.WriteAsync("retry: " + eventData.Retry + "\n");

            await context.Response.WriteAsync("event: " + eventData.Name + "\n");

            var data = new [] {JsonSerializer.Serialize(eventData.Data)};

            foreach (var line in data)
            {
                await context.Response.WriteAsync("data: " + line + "\n");
            }

            await context.Response.WriteAsync("\n");
            await context.Response.Body.FlushAsync();
        }
    }
}
