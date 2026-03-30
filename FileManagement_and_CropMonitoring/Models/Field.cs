using System.ComponentModel.DataAnnotations;

namespace FarmManagement_and_CropMonitoring.Models
{
    public class Field
    {
        [Key]
        public int FieldId { get; set; }

        [Required]
        [Display(Name = "Field Name")]
        public string FieldName { get; set; } = string.Empty;

        [Display(Name = "Area (Hectares)")]
        public decimal AreaHectares { get; set; }

        [Display(Name = "Soil Type")]
        public string? SoilType { get; set; }

        public string? Location { get; set; }

        // Navigation property for Crops
        public ICollection<Crop>? Crops { get; set; }
        public virtual ICollection<PlantSchedule>? PlantSchedules { get; set; }
        
    }
}