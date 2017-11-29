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

namespace RMS.Controllers.Vendor_Controller
{
    public class VendorController : Controller
    {
        private SystemDataContext db;

        #region Constructor
        public VendorController()
        {
            db = new SystemDataContext();
        }
        #endregion

        #region Vendor Index
        // GET: /Vendor/
        public ActionResult Index()
        {
            return View(db.Vendor.Where(record => record.Status == Data.Objects.Enums.Status.Approved).OrderBy(order => order.Name).ToList());
        }
        #endregion

        #region Vendor Details

        // GET: /Vendor/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendor.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", vendor);
        }
        #endregion

        #region Vendor Create
        // GET: /Vendor/Create
        public ActionResult Create()
        {
            var vendor = new Vendor();
            return PartialView("Create", vendor);
        }

        // POST: /Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber,DateCreated,Status")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                if (db.Vendor.Any(record => record.Name == vendor.Name))
                {
                    ModelState.AddModelError("Name", "Vendor Name is already taken");
                }
                if (db.Vendor.Any(record => record.Email == vendor.Email))
                {
                    ModelState.AddModelError("Email", "Email Address already in use");
                }
                
                else
                { 
                    var req = new Vendor
                    {
                        VendorId = vendor.VendorId,
                        Name = vendor.Name,
                        Email = vendor.Email,
                        Address = vendor.Address,
                        LGA = vendor.LGA,
                        State = vendor.State,
                        ZipCode = vendor.ZipCode,
                        PhoneNumber = vendor.PhoneNumber,
                        DateCreated = DateTime.Now,
                        Status = Data.Objects.Enums.Status.Approved
                    };
                    db.Vendor.Add(req);
                    db.SaveChanges();
                    return Json(new { succuess = true });
                }
            }

            return PartialView("Create", vendor);
        }
        #endregion

        #region Vendor Edit
        // GET: /Vendor/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendor.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", vendor);
        }

        // POST: /Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber,DateCreated,Status")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { succuess = true });
            }
            return PartialView("Edit", vendor);
        }
        #endregion

        #region Vendor Delete

        // GET: /Vendor/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendor.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", vendor);
        }

        // POST: /Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Vendor vendor = db.Vendor.Find(id);
            db.Vendor.Remove(vendor);
            db.SaveChanges();
            return Json(new { succuess = true });
        }

        #endregion

        #region Vendor ManageRequests

        //GET: /Vendor/ManageRequests
        public ActionResult ManageRequests()
        {
            return View(db.Vendor.Where(record => record.Status == Data.Objects.Enums.Status.Pending || record.Status == Data.Objects.Enums.Status.Declined ).ToList());
        }

        #endregion

        #region Vendor ApproveRequest

        // GET: /Vendor/ApproveRequest/5
        public ActionResult ApproveRequest(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendor.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return PartialView("ApproveRequest", vendor);
        }

        // POST: /Vendor/ApproveRequest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveRequest([Bind(Include = "VendorId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber,DateCreated,Status")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { succuess = true });
            }
            return PartialView("ApproveRequest", vendor);
        }

        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion


        //This action is used when a user requests to be a vendor for the restaurant
        #region Vendor Requests
        // GET: /Vendor/Requests
        public ActionResult Requests()
        {
            return View();
        }


        // POST: /Vendor/Request
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Requests([Bind(Include = "VendorId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber,DateCreated")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                if (db.Vendor.Any(record => record.Email == vendor.Email))
                {
                    ModelState.AddModelError("Email", "Email Address already in use");
                }
                else
                {
                    var req = new Vendor
                    {
                        VendorId = vendor.VendorId,
                        Name = vendor.Name,
                        Email = vendor.Email,
                        Address = vendor.Address,
                        LGA = vendor.LGA,
                        State = vendor.State,
                        ZipCode = vendor.ZipCode,
                        PhoneNumber = vendor.PhoneNumber,
                        DateCreated = DateTime.Now,
                        Status = Data.Objects.Enums.Status.Pending
                    };
                    db.Vendor.Add(req);
                    db.SaveChanges();
                    return RedirectToAction("Home", "Landing");
                }
            }

            return RedirectToAction("Home", "Landing");
        }
        #endregion
    }
}
