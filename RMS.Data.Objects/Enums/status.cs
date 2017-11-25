using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Objects.Enums
{
    public enum Status
    {
        [Display(Name = "Pending")]
        Pending,

        [Display(Name = "Approved")]
        Approved,

        [Display(Name = "Declined")]
        Declined,
    }
}
