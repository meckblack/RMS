using RMS.Data.Objects.Entities.Restaurant;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Objects.Entities.SystemMangement
{
    public class FoodType
    {
        [Key]
        public long FoodTypeId { get; set; }

        [Required(ErrorMessage="Food type name is required")]
        public string Name { get; set; }

        public IEnumerable<Food> Foods { get; set; }
    }
}
