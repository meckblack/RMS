using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RMS.Data.Objects.Entities.Restaurant;
using RMS.Data.DataContext.DataContext.SystemDataContext;

namespace RMS.Controllers.RestaurantManagement
{
    public class SupplierController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: /Supplier/
        public ActionResult Index()
        {
            return View(db.Supplier.ToList());
        }

        // GET: /Supplier/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", supplier);
        }

        // GET: /Supplier/Create
        public ActionResult Create()
        {
            var supplier = new Supplier();
            return PartialView("Create", supplier);
        }

        // POST: /Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SupplierId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Supplier.Add(supplier);
                db.SaveChanges();
                return Json(new { success = true } );
            }

            return PartialView("Create", supplier);
        }

        // GET: /Supplier/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", supplier);
        }

        // POST: /Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SupplierId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", supplier);
        }

        // GET: /Supplier/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", supplier);
        }

        // POST: /Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Supplier supplier = db.Supplier.Find(id);
            db.Supplier.Remove(supplier);
            db.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
