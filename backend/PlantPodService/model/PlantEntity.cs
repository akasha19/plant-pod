using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantPodService.Model
{
    public class PlantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [MaxLength(64)]
        public string LongName { get; set; }
        [MaxLength(64)]
        public string ShortName { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [MaxLength(2048)]
        public string Care { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal MinTemperature { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal MaxTemperature { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal Minph { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal Maxph { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal MinHumidity { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal MaxHumidity { get; set; }
        
        public Moisture Moisture { get; set; }

        [MaxLength(64)]
        public string Image { get; set; }
    }
}
