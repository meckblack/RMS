using RMS.Data.Objects.Entities.SystemMangement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class Food
    {
        [Key]
        public long FoodId { get; set; }

        [Required(ErrorMessage = "Food Name required")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Food description required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Food price required")]
        public decimal Price { get; set; }


        //Foreign Keys

        [Display(Name="Food Type")]
        public long? FoodTypeId { get; set; }

        [ForeignKey("FoodTypeId")]
        public virtual FoodType FoodType { get; set; }

    }
}
