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
    public class FoodController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: /Food/
        public ActionResult Index()
        {
            var food = db.Food.Include(f => f.FoodType);
            return View(food.ToList());
        }

        // GET: /Food/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: /Food/Create
        public ActionResult Create()
        {
            ViewBag.FoodTypeId = new SelectList(db.FoodType, "FoodTypeId", "Name");
            var food = new Food();
            return View("Create", food);
        }

        // POST: /Food/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FoodId,Title,Description,Price,FoodTypeId")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Food.Add(food);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.FoodTypeId = new SelectList(db.FoodType, "FoodTypeId", "Name", food.FoodTypeId);
            return PartialView("Create", food);
        }

        // GET: /Food/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodTypeId = new SelectList(db.FoodType, "FoodTypeId", "Name", food.FoodTypeId);
            return PartialView("Edit", food);
        }

        // POST: /Food/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FoodId,Title,Description,Price,FoodTypeId")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.FoodTypeId = new SelectList(db.FoodType, "FoodTypeId", "Name", food.FoodTypeId);
            return PartialView("Edit", food);
        }

        // GET: /Food/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", food);
        }

        // POST: /Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Food food = db.Food.Find(id);
            db.Food.Remove(food);
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
