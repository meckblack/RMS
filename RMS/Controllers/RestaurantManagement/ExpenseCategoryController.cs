using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RMS.Data.Objects.Entities.Restaurant;
using RMS.Data.DataContext.DataContext.SystemDataContext;

namespace RMS.Controllers.RestaurantManagement
{
    public class ExpenseCategoryController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: /ExpenseCategory/
        public ActionResult Index()
        {
            return View(db.ExpenseCategory.ToList());
        }

        // GET: /ExpenseCategory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expensecategory = db.ExpenseCategory.Find(id);
            if (expensecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", expensecategory);
        }

        // GET: /ExpenseCategory/Create
        public ActionResult Create()
        {
            var expenseCategory = new ExpenseCategory();
            return PartialView("Create", expenseCategory);
        }

        // POST: /ExpenseCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ExpenseCategoryId,Title,Description")] ExpenseCategory expensecategory)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseCategory.Add(expensecategory);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", expensecategory);
        }

        // GET: /ExpenseCategory/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expensecategory = db.ExpenseCategory.Find(id);
            if (expensecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", expensecategory);
        }

        // POST: /ExpenseCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ExpenseCategoryId,Title,Description")] ExpenseCategory expensecategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expensecategory).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", expensecategory);
        }

        // GET: /ExpenseCategory/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expensecategory = db.ExpenseCategory.Find(id);
            if (expensecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", expensecategory);
        }

        // POST: /ExpenseCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ExpenseCategory expensecategory = db.ExpenseCategory.Find(id);
            db.ExpenseCategory.Remove(expensecategory);
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
