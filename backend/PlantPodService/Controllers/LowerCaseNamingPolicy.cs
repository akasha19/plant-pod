using System.Text.Json;
using Humanizer;

namespace PlantPodService.Controllers
{
    public class LowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) =>
            name.Camelize();
    }
}