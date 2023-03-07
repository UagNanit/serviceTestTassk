using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace serviceTestTassk.Models
{
    public class Contract
    {
        public int Id { get; set; }
        [Required]
        public int BuildingId { get; set; }
        [JsonIgnore]
        public Building Building { get; set; }
        [Required]
        public int EquipmentId { get; set; }
        [JsonIgnore]
        public Equipment Equipment { get; set; }
        [Range(1, Int32.MaxValue)]
        [Required]
        public int CountEquipment { get; set; }
    }
}
