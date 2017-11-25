using RMS.Data.DataContext.DataContext.SystemDataContext;
using RMS.Data.Objects.Entities.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers.Landing
{
    public class CustomerRegisterController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        public ActionResult Home()
        {
            return View();
        }

        //
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
	}
}