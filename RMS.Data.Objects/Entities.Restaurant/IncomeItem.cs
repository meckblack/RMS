using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class IncomeItem
    {
        [Key]
        public long IncomeItemId { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }

        //Foreign Keys
        public long? IncomeCategoryId { get; set; }

        [ForeignKey("IncomeCategoryId")]
        public virtual IncomeCategory IncomeCategory { get; set; }
    }
}
