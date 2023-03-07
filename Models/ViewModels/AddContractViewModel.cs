using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace serviceTestTassk.Models.ViewModels
{
    public class AddContractViewModel
    {
        [Required]
        public string CodeBuilding { get; set; }
      
        [Required]
        public string CodeEquipment { get; set; }
       
        [Range(1, Int32.MaxValue)]
        [Required]
        public int CountEquipment { get; set; }
    }
}
