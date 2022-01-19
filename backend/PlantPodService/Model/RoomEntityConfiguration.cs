using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace PlantPodService.Model
{
    public class RoomEntityConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.HasData(Rooms());
        }

        private static RoomEntity[] Rooms() => new[]
        {
            new RoomEntity()
            {
                Id = Guid.Parse("487ac8ee-0d70-4377-b216-0045182b7638 "),
                SensorId = Guid.Parse("196db225-e5ef-4636-b967-c214a0ddb73f"),
                Name = "Presentation room",
                Description = "presentation room for 100 people",
                Facilities = new[] {"Airconditioning", "heating", "smartprojector", "smartplants"},
                ImageSource = "assets/img/room_1.jpg"
            },
            new RoomEntity()
            {
                Id = Guid.Parse("177bead7-1b35-46c5-83ad-026faefa2ca1"),
                SensorId = Guid.Parse("3dd86e81-b88c-4b37-b740-a662fa116245"),
                Name = "Meeting room",
                Description = "meeting room for 8 people",
                Facilities = new[] {"Airconditioning", "heating", "smartboard", "smartplants"},
                ImageSource = "assets/img/room_2.jpg"
            }
        };
    }
}
