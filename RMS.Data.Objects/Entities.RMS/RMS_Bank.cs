using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Objects.Entities.RMS
{
    class RMS_Bank
    {
        [Key]
        public long RMS_Bank { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage="Bank name is required")]
        public string Name { get; set; }
    }
}
