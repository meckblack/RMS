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
    public class FoodStuffController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: /FoodStuff/
        public ActionResult Index()
        {
            var FoodStuff = db.FoodStuff.Include(f => f.Measurement);
            return View(FoodStuff.ToList());
        }

        // GET: /FoodStuff/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodStuff foodstuff = db.FoodStuff.Find(id);
            if (foodstuff == null)
            {
                return HttpNotFound();
            }
            return View(foodstuff);
        }

        // GET: /FoodStuff/Create
        public ActionResult Create()
        {
            var foodStuff = new FoodStuff();
            ViewBag.MeasurementId = new SelectList(db.Measurement, "MeasurementId", "Name");
            return PartialView("Create", foodStuff);
        }

        // POST: /FoodStuff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FoodStuffId,Name,MeasurementId")] FoodStuff foodstuff)
        {
            if (ModelState.IsValid)
            {
                db.FoodStuff.Add(foodstuff);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.MeasurementId = new SelectList(db.Measurement, "MeasurementId", "Name", foodstuff.MeasurementId);
            return PartialView("Create", foodstuff);
        }

        // GET: /FoodStuff/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodStuff foodstuff = db.FoodStuff.Find(id);
            if (foodstuff == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeasurementId = new SelectList(db.Measurement, "MeasurementId", "Name", foodstuff.MeasurementId);
            return PartialView("Edit", foodstuff);
        }

        // POST: /FoodStuff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FoodStuffId,Name,MeasurementId")] FoodStuff foodstuff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodstuff).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.MeasurementId = new SelectList(db.Measurement, "MeasurementId", "Name", foodstuff.MeasurementId);
            return PartialView("Edit", foodstuff);
        }

        // GET: /FoodStuff/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodStuff foodstuff = db.FoodStuff.Find(id);
            if (foodstuff == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", foodstuff);
        }

        // POST: /FoodStuff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FoodStuff foodstuff = db.FoodStuff.Find(id);
            db.FoodStuff.Remove(foodstuff);
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
