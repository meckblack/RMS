using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Objects.Entities.SystemMangement
{
    public class Measurement
    {
        [Key]
        public long MeasurementId { get; set; }

        [Required(ErrorMessage="Name field is required")]
        public string Name { get; set; }
    }
}
