﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Objects.Entities.ApplicationManagement
{
    public class Checker
    {
        [DisplayName("Created By")]
        public virtual string CreatedBy { get; set; }

        [DisplayName("Date Created")]
        public virtual DateTime DateCreated { get; set; }

        [DisplayName("Date Last Modified")]
        public virtual DateTime DateLastModified { get; set; }

        [DisplayName("Last Modified By")]
        public virtual string LastModifiedBy { get; set; }
    }
}
