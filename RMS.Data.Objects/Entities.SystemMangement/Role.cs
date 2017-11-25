using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Objects.Entities.SystemMangement
{
    public class Role
    {
        [Key]
        public long RoleId { get; set; }

        [Required]
        public string Title { get; set; }

        public bool CanManageEmployee { get; set; }
        public bool CanManageFood { get; set; }
        public bool CanManageIncome { get; set; }
    }
}
