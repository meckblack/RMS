using RMS.Data.Objects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Objects.Entities.Vendor
{
    public class Vendor
    {
        [Key]
        public long VendoerRequestId { get; set; }

        [Required(ErrorMessage = "Company name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address field is requried")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = " LGA field is required")]
        [Display(Name = "LGA")]
        public string LGA { get; set; }

        [Required(ErrorMessage = " State field is required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = " Zip/Postal Code field is required")]
        [Display(Name = "Zip/PostalCode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Phone Number field is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Date Created")]
        public virtual DateTime DateCreated { get; set; }

        public Status Status { get; set; }
    }
}
