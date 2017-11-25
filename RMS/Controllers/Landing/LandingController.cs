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



        // GET: /Landing/RequestVendor
        public ActionResult RequestVendor()
        {
            return View();
        }


        // POST: /Landing/RequestVendor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestVendor([Bind(Include = "VendorRequestId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber,DateCreated")] VendorRequest vendorRequest)
        {
            if (ModelState.IsValid)
            {
                 
                var request = new VendorRequest {
                    VendoerRequestId = vendorRequest.VendoerRequestId,
                    Name = vendorRequest.Name,
                    Email = vendorRequest.Email,
                    Address = vendorRequest.Address,
                    LGA = vendorRequest.LGA,
                    State = vendorRequest.State,
                    ZipCode = vendorRequest.ZipCode,
                    PhoneNumber = vendorRequest.PhoneNumber,
                    DateCreated = DateTime.Now
                };

                db.VendorRequest.Add(request);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return RedirectToAction("Home");
        }

       

        
	}
}