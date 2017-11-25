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
    public class IncomeCategoryController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: /IncomeCategory/
        public ActionResult Index()
        {
            return View(db.IncomeCategory.ToList());
        }

        // GET: /IncomeCategory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeCategory incomecategory = db.IncomeCategory.Find(id);
            if (incomecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Create", incomecategory);
        }

        // GET: /IncomeCategory/Create
        public ActionResult Create()
        {
            var incomeCategory = new IncomeCategory();
            return PartialView("Create", incomeCategory);
        }

        // POST: /IncomeCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IncomeCategoryId,Title,Description")] IncomeCategory incomecategory)
        {
            if (ModelState.IsValid)
            {
                db.IncomeCategory.Add(incomecategory);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", incomecategory);
        }

        // GET: /IncomeCategory/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeCategory incomecategory = db.IncomeCategory.Find(id);
            if (incomecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", incomecategory);
        }

        // POST: /IncomeCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IncomeCategoryId,Title,Description")] IncomeCategory incomecategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomecategory).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", incomecategory);
        }

        // GET: /IncomeCategory/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeCategory incomecategory = db.IncomeCategory.Find(id);
            if (incomecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", incomecategory);
        }

        // POST: /IncomeCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            IncomeCategory incomecategory = db.IncomeCategory.Find(id);
            db.IncomeCategory.Remove(incomecategory);
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
