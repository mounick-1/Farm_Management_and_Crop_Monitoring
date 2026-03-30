using System.ComponentModel.DataAnnotations;

namespace FarmManagement_and_CropMonitoring.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        [Required]
        public string ResourceName { get; set; } = string.Empty; 
        public string? Category { get; set; }
        public decimal QuantityInStock { get; set; }

        public string? Unit { get; set; }

        // Relationship to Usage
        public ICollection<ResourceUsage>? ResourceUsages { get; set; }
    }
}