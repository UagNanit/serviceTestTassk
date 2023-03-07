using System.ComponentModel.DataAnnotations;

namespace serviceTestTassk.Models.ViewModels
{
    public class GetContractsViewModel
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string EquipmentName { get; set; }
        public int CountEquipment { get; set; }
    }
}
