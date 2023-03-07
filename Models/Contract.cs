using System.Text.Json.Serialization;

namespace serviceTestTassk.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        [JsonIgnore]
        public Building Building { get; set; }
        public int EquipmentId { get; set; }
        [JsonIgnore]
        public Equipment Equipment { get; set; }
        public int CountEquipment { get; set; } = 0;
    }
}
