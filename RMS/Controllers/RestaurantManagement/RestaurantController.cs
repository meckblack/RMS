//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using RMS.Data.Objects.Entities.Restaurant;
//using RMS.Data.DataContext.DataContext.SystemDataContext;

//namespace RMS.Controllers.RestaurantManagement
//{
//    public class RestaurantController : Controller
//    {
//        private SystemDataContext db;

//        #region Constructor
//        public RestaurantController()
//        {
//            db = new SystemDataContext();
//        }
//        #endregion

//        #region Restuarant Index
//        // GET: /Restaurant/
//        public ActionResult Index()
//        {
//            return View(db.Restaurant.ToList());
//        }
//        #endregion

//        #region Restuarant Details
//        // GET: /Restaurant/Details/5
//        public ActionResult Details(long? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Restaurant restaurant = db.Restaurant.Find(id);
//            if (restaurant == null)
//            {
//                return HttpNotFound();
//            }
//            return View(restaurant);
//        }
//        #endregion

//        #region Restaurant Create
//        // GET: /Restaurant/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: /Restaurant/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include="RestaurantId,Name,Acronym,Address,LGA,State,PostalCode,AccountNumber,DateCreated")] Restaurant restaurant)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Restaurant.Add(restaurant);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(restaurant);
//        }
//        #endregion

//        #region Resaturant Edit
//        // GET: /Restaurant/Edit/5
//        public ActionResult Edit(long? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Restaurant restaurant = db.Restaurant.Find(id);
//            if (restaurant == null)
//            {
//                return HttpNotFound();
//            }
//            return View(restaurant);
//        }

//        // POST: /Restaurant/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include="RestaurantId,Name,Acronym,Address,LGA,State,PostalCode,AccountNumber,DateCreated")] Restaurant restaurant)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(restaurant).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(restaurant);
//        }
//        #endregion

//        #region Restaurant Delete
//        // GET: /Restaurant/Delete/5
//        public ActionResult Delete(long? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Restaurant restaurant = db.Restaurant.Find(id);
//            if (restaurant == null)
//            {
//                return HttpNotFound();
//            }
//            return View(restaurant);
//        }

//        // POST: /Restaurant/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(long id)
//        {
//            Restaurant restaurant = db.Restaurant.Find(id);
//            db.Restaurant.Remove(restaurant);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        #endregion

//        #region Restaurant Dispose
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//        #endregion
//    }
//}
