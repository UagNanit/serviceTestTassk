using System.ComponentModel.DataAnnotations;

namespace serviceTestTassk.Models
{
    public class Building
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double MaxArea { get; set; }

    }
}
