using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RMS.Data.Objects.Entities.SystemMangement;
using RMS.Data.DataContext.DataContext.SystemDataContext;

namespace RMS.Controllers.SystemManagement
{
    public class MeasurementController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: /Measurement/
        public ActionResult Index()
        {
            return View(db.Measurement.ToList());
        }

        // GET: /Measurement/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurement.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", measurement);
        }

        // GET: /Measurement/Create
        public ActionResult Create()
        {
            var measurement = new Measurement();
            return PartialView("Create", measurement);
        }

        // POST: /Measurement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MeasurementId,Name")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Measurement.Add(measurement);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", measurement);
        }

        // GET: /Measurement/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurement.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", measurement);
        }

        // POST: /Measurement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MeasurementId,Name")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measurement).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", measurement);
        }

        // GET: /Measurement/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurement.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", measurement);
        }

        // POST: /Measurement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Measurement measurement = db.Measurement.Find(id);
            db.Measurement.Remove(measurement);
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
