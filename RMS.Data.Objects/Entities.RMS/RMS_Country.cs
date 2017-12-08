using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Objects.Entities.RMS
{
    class RMS_Country
    {
        [Key]
        public long RMS_CountryId { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage="Country Name is required")]
        public string Name { get; set; }

    }
}
