using RMS.Data.Objects.Enums;
using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }

        //GENERAL DETAILS
        [Required(ErrorMessage = "First Name field is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name field is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Middle Name field is required")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Email Address field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage="Please enter a valid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = " Gender field is required")]
        public Gender Gender { get; set; }

        //DELIEVERY DETAILS
        [Required(ErrorMessage = "Address field is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = " LGA field is required")]
        [Display(Name = "LGA")]
        public string LGA { get; set; }

        [Required(ErrorMessage = " State field is required")]
        [Display(Name = "State")]
        public State State { get; set; }

        [Required(ErrorMessage = " Zip Code field is required")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Phone Number field is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //RESTUARANT ACCOUNT DETAILS
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Comfirm Password field is required")]
        [Display(Name = "Comfirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        public string ComfirmPassword { get; set; }
    }
}
