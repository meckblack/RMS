using RMS.Data.DataContext.DataContext.SystemDataContext;
using RMS.Data.Objects.Entities.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers.Landing
{
    public class LandingController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        public ActionResult Home()
        {
            return View();
        }

    }
}