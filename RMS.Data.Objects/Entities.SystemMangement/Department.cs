using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RMS.Data.Objects.Entities.SystemMangement
{
    public class Department
    {
        public long DepartmentId { get; set; }

        [Required(ErrorMessage="Department Name is requried")]
        public string Name { get; set; }

        public IEnumerable<Employee.Employee> Employees { get; set; }
    }
}
