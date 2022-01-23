using PlantPodService.ViewModel;

namespace PlantPodService.Controllers.LiveDataServerSideEvent
{
    public class ServerSideEvent
    {
        public string Name { get; set; }
        public Sensor Data { get; set; }
        public string Id { get; set; }
        public int? Retry { get; set; }
    }
}
