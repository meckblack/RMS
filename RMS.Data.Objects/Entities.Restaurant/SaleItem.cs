using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class SaleItem
    {
        [Key]
        public long SaleItemId { get; set; }

        [Required(ErrorMessage="Title field is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description field is required")]
        public string Description { get; set; }


        //Foreign Keys

        [Display(Name = "")]
        public long? SaleCategoryId { get; set; }

        [ForeignKey("SaleCategoryId")]
        public virtual SaleCategory SaleCategory { get; set; }
    }
}
