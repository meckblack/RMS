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
        Pending = 0,

        [Display(Name = "Approved")]
        Approved = 1,

        [Display(Name = "Declined")]
        Declined = 2,
    }
}
