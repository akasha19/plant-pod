using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlantPodService.Model
{
    public class PlantEntityConfiguration : IEntityTypeConfiguration<PlantEntity>
    {
        public void Configure(EntityTypeBuilder<PlantEntity> builder)
        {
            builder.HasData(new []
            {
                new PlantEntity { Id = Guid.NewGuid() },
                new PlantEntity { Id = Guid.NewGuid() }
            });
        }
    }
}
