using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmManagement_and_CropMonitoring.Models
{
    public class PlantSchedule
    {
        [Key]
        public int PlantScheduleId { get; set; }

        // Linking to Crop
        [Required]
        public int CropId { get; set; }
        public virtual Crop? Crop { get; set; }

        // Linking to Field
        [Required]
        public int FieldId { get; set; }
        public virtual Field? Field { get; set; } // This fixes the 'Field' error

        [Required]
        [Display(Name = "Planting Date")]
        public DateTime StartDate { get; set; } // This fixes the 'StartDate' error

        [Required]
        [Display(Name = "Expected Harvest")]
        public DateTime EndDate { get; set; } // This fixes the 'EndDate' error
    }
}