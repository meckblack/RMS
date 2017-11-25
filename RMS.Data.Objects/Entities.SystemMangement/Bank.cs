using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RMS.Data.Objects.Entities.SystemMangement
{
    public class Bank
    {
        public long BankId { get; set; }

        [Required(ErrorMessage="Bank Name is required")]
        public string Name { get; set; }

        public IEnumerable<Employee.Employee> Employees { get; set; }
    }
}
