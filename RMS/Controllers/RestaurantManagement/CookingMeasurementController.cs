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
    public class CookingMeasurementController : Controller
    {
        private readonly SystemDataContext db;

        #region constructor
        public CookingMeasurementController()
        {
            db = new SystemDataContext();
        }
        #endregion

        #region CookingMeasurement Index
        // GET: /CookingMeasurement/
        public ActionResult Index()
        {
            return View(db.CookingMeasurement.ToList());
        }

        #endregion

        #region CookingMeasurement Details
        // GET: /CookingMeasurement/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookingMeasurement cookingmeasurement = db.CookingMeasurement.Find(id);
            if (cookingmeasurement == null)
            {
                return HttpNotFound();
            }
            return View(cookingmeasurement);
        }

        #endregion

        #region CookingMeasurement Create
        // GET: /CookingMeasurement/Create
        public ActionResult Create()
        {
            var cookingMeasurement = new CookingMeasurement();
            return PartialView("Create", cookingMeasurement);
        }

        // POST: /CookingMeasurement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CookingMeasurementId,Name")] CookingMeasurement cookingmeasurement)
        {
            if (ModelState.IsValid)
            {
                db.CookingMeasurement.Add(cookingmeasurement);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", cookingmeasurement);
        }

        #endregion

        #region CookingMeasurement Edit
        // GET: /CookingMeasurement/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookingMeasurement cookingmeasurement = db.CookingMeasurement.Find(id);
            if (cookingmeasurement == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", cookingmeasurement);
        }

        // POST: /CookingMeasurement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CookingMeasurementId,Name")] CookingMeasurement cookingmeasurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cookingmeasurement).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", cookingmeasurement);
        }

        #endregion

        #region CookingMeasurement Delete
        // GET: /CookingMeasurement/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookingMeasurement cookingmeasurement = db.CookingMeasurement.Find(id);
            if (cookingmeasurement == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", cookingmeasurement);
        }

        // POST: /CookingMeasurement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CookingMeasurement cookingmeasurement = db.CookingMeasurement.Find(id);
            db.CookingMeasurement.Remove(cookingmeasurement);
            db.SaveChanges();
            return Json(new { success = true });
        }

        #endregion

        #region Dispoose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
