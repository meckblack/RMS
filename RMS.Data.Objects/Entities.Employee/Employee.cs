using RMS.Data.Objects.Entities.ApplicationManagement;
using RMS.Data.Objects.Entities.SystemMangement;
using RMS.Data.Objects.Entities.Restaurant;
using RMS.Data.Objects.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RMS.Data.Objects.Entities.RMS;

namespace RMS.Data.Objects.Entities.Employee
{
    public class Employee : Checker
    {
        [Key]
        public long EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name field is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name field is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Email Address field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = " Address field is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Employment")]
        [Required(ErrorMessage = "Date Of Employment field is required")]
        public DateTime DateOfEmployment { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date Of Birth field is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone Number field is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = " Gender field is required")]
        public Gender Gender { get; set; }

        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "Account Name field is required")]
        public string AccountName { get; set; }

        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "Account Number field reuired")]
        [StringLength(10, ErrorMessage = "Please enter a valid Account number")]
        public string AccountNumber { get; set; }

        //Foreign Keys

        [DisplayName("Bank")]
        public long? BankId { get; set; }

        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }

        [DisplayName("Department")]
        public long? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [DisplayName("Restaurant")]
        public long? RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual Restaurant.Restaurant Restaurant { get; set; }

       
    }
}
