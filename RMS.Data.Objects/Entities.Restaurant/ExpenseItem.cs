using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class ExpenseItem
    {
        [Key]
        public long ExpenseItemId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage="Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public string Quantity { get; set; }

        //FOREGIN KEY
        [Display(Name = "ExpenseCategory")]
        public long? ExpenseCategoryId { get; set; }

        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
}
