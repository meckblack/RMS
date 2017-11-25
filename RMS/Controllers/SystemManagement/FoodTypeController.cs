using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RMS.Data.DataContext.DataContext.SystemDataContext;
using RMS.Data.Objects.Entities.SystemMangement;

namespace RMS.Controllers.SystemManagement
{
    public class FoodTypeController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: FoodType
        public ActionResult Index()
        {
            return View(db.FoodType.ToList());
        }

        // GET: FoodType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType foodType = db.FoodType.Find(id);
            if (foodType == null)
            {
                return HttpNotFound();
            }
            return View(foodType);
        }

        // GET: FoodType/Create
        public ActionResult Create()
        {
            var foodType = new FoodType();
            return PartialView("Create", foodType);
        }

        // POST: FoodType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodTypeId,Name")] FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                db.FoodType.Add(foodType);
                db.SaveChanges();
                return Json( new { success = true } );
            }

            return View(foodType);
        }

        // GET: FoodType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType foodType = db.FoodType.Find(id);
            if (foodType == null)
            {
                return HttpNotFound();
            }
            return View(foodType);
        }

        // POST: FoodType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodTypeId,Name")] FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodType).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return View(foodType);
        }

        // GET: FoodType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType foodType = db.FoodType.Find(id);
            if (foodType == null)
            {
                return HttpNotFound();
            }
            return View(foodType);
        }

        // POST: FoodType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FoodType foodType = db.FoodType.Find(id);
            db.FoodType.Remove(foodType);
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
