using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantPodService.Model
{
    public class RoomEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public Guid SensorId { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }
        
        public string[] Facilities { get; set; }

        [MaxLength(64)]
        public string ImageSource { get; set; }
    }
}