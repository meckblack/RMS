using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Data.Objects.Entities.Restaurant
{
    public class SaleCategory
    {
        [Key]
        public long SaleCategoryId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Sale { get; set; }

        public IEnumerable<SaleItem> SaleItem { get; set; }
    }
}
