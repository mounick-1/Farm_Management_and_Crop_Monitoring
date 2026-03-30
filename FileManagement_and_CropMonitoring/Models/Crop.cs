using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmManagement_and_CropMonitoring.Models
{
    public class Crop
    {
        [Key] // This tells EF that CropId is the Primary Key
        public int CropId { get; set; }

        [Required]
        public string CropName { get; set; } = string.Empty;

        public string? CropType { get; set; }
        public string? Season { get; set; }

        // Foreign Key Setup
        public int FieldId { get; set; }

        [ForeignKey("FieldId")]
        public virtual Field? Field { get; set; }
    }
}