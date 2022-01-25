using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace PlantPodService.Model
{
    public class RoomEntityConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.HasOne(e => e.Plant);

            builder
                .Property(e => e.Facilities)
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries));

            var valueComparer = new ValueComparer<string[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())));

            builder
                .Property(e => e.Facilities)
                .Metadata
                .SetValueComparer(valueComparer);

            builder.HasData(Rooms());
        }

        private static RoomEntity[] Rooms() => new[]
        {
            new RoomEntity()
            {
                Id = Guid.Parse("487ac8ee-0d70-4377-b216-0045182b7638"),
                SensorId = Guid.Parse("196db225-e5ef-4636-b967-c214a0ddb73f"),
                PlantId = Guid.Parse("0ef97408-0dac-46cf-aba1-d07235992bdd"),
                Name = "Presentation room",
                Description = "presentation room for 100 people",
                Facilities = new[] {"Airconditioning", "heating", "smartprojector", "smartplants"},
                ImageSource = "assets/img/room_1.jpg"
            },
            new RoomEntity()
            {
                Id = Guid.Parse("177bead7-1b35-46c5-83ad-026faefa2ca1"),
                SensorId = Guid.Parse("3dd86e81-b88c-4b37-b740-a662fa116245"),
                PlantId = Guid.Parse("79924374-44ad-4f9f-938b-6ac89e7ec60c"),
                Name = "Meeting room",
                Description = "meeting room for 8 people",
                Facilities = new[] {"Airconditioning", "heating", "smartboard", "smartplants"},
                ImageSource = "assets/img/room_2.jpg"
            }
        };
    }
}
