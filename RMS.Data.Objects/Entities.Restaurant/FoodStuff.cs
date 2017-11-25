using RMS.Data.Objects.Entities.SystemMangement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class FoodStuff
    {
        [Key]
        public long FoodStuffId { get; set; }

        [Required(ErrorMessage="Name filed required")]
        public string Name { get; set; }

        //Foreign Keys
        public long? MeasurementId { get; set; }

        [ForeignKey("MeasurementId")]
        public virtual Measurement Measurement { get; set; }

    }
}
