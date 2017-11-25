using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RMS.Data.Objects.Entities.SystemMangement;
using RMS.Data.DataContext.DataContext.SystemDataContext;

namespace RMS.Controllers.SystemManagement
{
    public class BankController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: /Bank/
        public ActionResult Index()
        {
            return View(db.Bank.ToList());
        }

        // GET: /Bank/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bank bank = db.Bank.Find(id);
        //    if (bank == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bank);
        //}

        // GET: /Bank/Create
        public ActionResult Create()
        {
            var bank = new Bank();
            return PartialView("Create", bank);
        }

        // POST: /Bank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BankId,Name")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Bank.Add(bank);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return View(bank);
        }

        // GET: /Bank/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Bank.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View("Edit", bank);
        }

        // POST: /Bank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BankId,Name")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return View(bank);
        }

        // GET: /Bank/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Bank.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", bank);
        }

        // POST: /Bank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Bank bank = db.Bank.Find(id);
            db.Bank.Remove(bank);
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
