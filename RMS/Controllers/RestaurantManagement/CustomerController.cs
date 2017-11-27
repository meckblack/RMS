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
    public class CustomerController : Controller
    {
        private readonly SystemDataContext db;

        #region constructor
        public CustomerController()
        {
            db = new SystemDataContext();
        }
        #endregion

        #region Customer Index
        // GET: /Customer/
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        #endregion

        #region Customer Details
        // GET: /Customer/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return PartialView(customer);
        }
        #endregion

        #region Customer Create
        // GET: /Customer/Create
        public ActionResult Create()
        {
            var customer = new Customer();
            return PartialView("Create", customer);
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CustomerId,FirstName,LastName,MiddleName,Address,Gender,LGA,State,ZipCode,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", customer);
        }

        #endregion

        #region Customer Edit
        // GET: /Customer/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", customer);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CustomerId,FirstName,LastName,MiddleName,Address,Gender,LGA,State,ZipCode,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", customer);
        }
        #endregion

        #region Customer Delete
        // GET: /Customer/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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

        //This action will be called when the user requests to register as a customer
        #region Customer Register
        // GET: /RegisterCustomer/
        public ActionResult Register()
        {
            return View();
        }

        // POST: /CustomerRegister/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                //if (supplier.Name = )
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return RedirectToAction("Home");
        }
        #endregion
    }
}
