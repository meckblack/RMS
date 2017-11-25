using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class ExpenseCategory
    {
        [Key]
        public long ExpenseCategoryId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage="Description is required")]
        public string Description { get; set; }

        public IEnumerable<ExpenseItem> ExpenseItem { get; set; }


    }
}
