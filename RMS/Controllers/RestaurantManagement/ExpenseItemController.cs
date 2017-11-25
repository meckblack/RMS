using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RMS.Data.DataContext.DataContext.SystemDataContext;
using RMS.Data.Objects.Entities.Restaurant;

namespace RMS.Controllers.RestaurantManagement
{
    public class ExpenseItemController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: ExpenseItem
        [Route("ExpenseItem/Index/{ExpenseCategoryId}")]
        public ActionResult Index(long ExpenseCategoryId)
        {
            var ei = db.ExpenseCategory.Find(ExpenseCategoryId);
            Session["ecID"] = ei.ExpenseCategoryId;
            Session["ecTitle"] = ei.Title;

            var expenseItem = db.ExpenseItem.Where(e => e.ExpenseCategoryId == ExpenseCategoryId);
            return View(expenseItem.ToList());
        }

        // GET: ExpenseItem/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItem.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", expenseItem);
        }

        // GET: ExpenseItem/Create
        public ActionResult Create()
        {
            var expenseItem = new ExpenseItem();
            return PartialView("Create", expenseItem);
        }

        // POST: ExpenseItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseItemId,Title,Description,ExpenseCategoryId")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                var ei = new ExpenseItem
                {
                    ExpenseCategoryId = Convert.ToInt32(Session["ecID"]),
                    Title = expenseItem.Title,
                    Description = expenseItem.Description
                    //Price = expenseItem.Price,
                    //Quantity = expenseItem.Quantity
                };
                db.ExpenseItem.Add(ei);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategory, "ExpenseCategoryId", "Title", expenseItem.ExpenseCategoryId);
            return PartialView("Create", expenseItem);
        }

        // GET: ExpenseItem/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItem.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategory, "ExpenseCategoryId", "Title", expenseItem.ExpenseCategoryId);
            return PartialView("Edit", expenseItem);
        }

        // POST: ExpenseItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseItemId,Title,Description,ExpenseCategoryId")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseItem).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategory, "ExpenseCategoryId", "Title", expenseItem.ExpenseCategoryId);
            return PartialView("Edit", expenseItem);
        }

        // GET: ExpenseItem/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItem.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", expenseItem);
        }

        // POST: ExpenseItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ExpenseItem expenseItem = db.ExpenseItem.Find(id);
            db.ExpenseItem.Remove(expenseItem);
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
