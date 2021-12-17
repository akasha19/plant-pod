﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantPodService.Model
{
    public class PlantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Care { get; set; }
        public decimal MinTemperature { get; set; }
        public decimal MaxTemperature { get; set; }
        public decimal Minph { get; set; }
        public decimal Maxph { get; set; }
        public decimal MinHumidity { get; set; }
        public decimal MaxHumidity { get; set; }
        public Moisture Moisture { get; set; }
        public string Image { get; set; }
    }
}
