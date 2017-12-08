using RMS.Data.Objects.Entities.RMS;
using RMS.Data.Objects.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class Restaurant
    {
        [Key]
        public long RestaurantId { get; set; }

        [Display(Name = "Restaurant Name")]
        [Required(ErrorMessage = "Restaurant name required")]
        [StringLength(35, ErrorMessage = "Please enteer a valid Restaurant Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Restaurant Acronym field is required")]
        [Display(Name = "Acronym")]
        public string Acronym { get; set; }

        [Required(ErrorMessage = "Address field is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "LGA field is required")]
        public string LGA { get; set; }

        [Required(ErrorMessage = "State field is required")]
        public State State { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Postal Code field is required")]
        [StringLength(10, ErrorMessage = "Please enter a valid postal code")]
        public string PostalCode { get; set; }

        [Display(Name = "Bank")]
        [Required(ErrorMessage = "Bank is required")]
        public RMS_Bank Bank { get; set; }

        //public IEnumerable<ExpenseCategory> ExpenseCategories { get; set; }
        public IEnumerable<IncomeCategory> IncomeCategories { get; set; }

        
    }
}
