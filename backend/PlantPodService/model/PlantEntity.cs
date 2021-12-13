using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlantPodService.model
{
    public class PlantEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
