using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class IncomeCategory
    {
        [Key]
        public long IncomeCategoryId { get; set; }

        [Required(ErrorMessage = "Category Title field is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category Description field is required")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<IncomeItem> IncomeItems { get; set; }
    }
}
