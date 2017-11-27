using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RMS.Data.Objects.Entities.Vendor;
using RMS.Data.DataContext.DataContext.SystemDataContext;
using System.Threading.Tasks;

namespace RMS.Controllers.Vendor_Controller
{
    public class VendorRequestController : Controller
    {
        private SystemDataContext db;

        #region Constructor
        public VendorRequestController()
        {
            db = new SystemDataContext();
        }
        #endregion

        public ActionResult Home()
        {
            return View();
        }

        #region Vendor Request
        // GET: /Vendor/
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
        public ActionResult RequestVendor([Bind(Include = "VendorRequestId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber,DateCreated")] Vendor vendorRequest)
        {
            if (ModelState.IsValid)
            {

                var request = new Vendor
                {
                    VendorId = vendorRequest.VendorId,
                    Name = vendorRequest.Name,
                    Email = vendorRequest.Email,
                    Address = vendorRequest.Address,
                    LGA = vendorRequest.LGA,
                    State = vendorRequest.State,
                    ZipCode = vendorRequest.ZipCode,
                    PhoneNumber = vendorRequest.PhoneNumber,
                    DateCreated = DateTime.Now
                };

                db.Vendor.Add(request);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return RedirectToAction("Home");
        }
        #endregion
    }
}
