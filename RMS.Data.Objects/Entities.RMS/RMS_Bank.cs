using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Objects.Entities.RMS
{
    public class RMS_Bank
    {
        [Key]
        public long RMS_BankId { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage="Bank name is required")]
        public string Name { get; set; }


        //FOREIGN KEYS

        [Display(Name="Country")]
        public long RMS_CountryId { get; set; }

        [ForeignKey("RMS_CountryId")]
        public virtual RMS_Country RMS_Country { get; set; }
    }
}
