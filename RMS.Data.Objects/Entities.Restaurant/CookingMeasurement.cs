using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class CookingMeasurement
    {
        [Key]
        public long CookingMeasurementId { get; set; }

        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }

    }
}
