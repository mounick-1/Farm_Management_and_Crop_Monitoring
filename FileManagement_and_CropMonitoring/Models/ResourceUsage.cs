using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmManagement_and_CropMonitoring.Models
{
    public class ResourceUsage
    {
        [Key]
        public int UsageId { get; set; }

        [Required]
        public int CropId { get; set; }

        [ForeignKey("CropId")]
        public Crop? Crop { get; set; }

        [Required]
        public int ResourceId { get; set; }

        [ForeignKey("ResourceId")]
        public Resource? Resource { get; set; }

        [Required]
        [Display(Name = "Quantity Used")]
        public decimal QuantityUsed { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateUsed { get; set; } = DateTime.Now;

    }
}