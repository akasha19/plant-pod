using PlantPodService.Model;
using PlantPodService.ViewModel;
using System;

namespace PlantPodServiceTests.Factories
{
    static class PlantFactory
    {
        public static PlantEntity PlantEntity() => PlantEntity(Guid.NewGuid());

        public static PlantEntity PlantEntity(Guid id) => new PlantEntity
        {
            Id = id,
            Care = "don't let it dry out",
            Description = "just some random plant",
            Image = "Todo Nika!",
            LongName = "plant long name",
            ShortName = "plant short name",
            MaxHumidity = 30.4m,
            Minph = 6.5m,
            Maxph = 9.1m,
            MaxTemperature = 35.7m,
            MinHumidity = 13.2m,
            MinTemperature = 12.4m,
            Moisture = Moisture.Moist
        };

        public static Plant Plant(Guid id) => new Plant
        {
            Id = id,
            Care = "don't let it dry out",
            Description = "just some random plant",
            Image = "Todo Nika!",
            LongName = "plant long name",
            ShortName = "plant short name",
            MaxHumidity = 30.4m,
            Minph = 6.5m,
            Maxph = 9.1m,
            MaxTemperature = 35.7m,
            MinHumidity = 13.2m,
            MinTemperature = 12.4m,
            Moisture = Moisture.Moist
        };
    }
}
