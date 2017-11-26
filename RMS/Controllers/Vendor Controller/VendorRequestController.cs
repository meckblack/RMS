using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RMS.Data.Objects.Entities.Vendor;
using RMS.Data.DataContext.DataContext.SystemDataContext;
using System.Threading.Tasks;

namespace RMS.Controllers.Vendor_Controller
{
    public class VendorRequestController : Controller
    {
        private SystemDataContext db = new SystemDataContext();

        // GET: /VendorRequest/
        public ActionResult Index()
        {
            return View(db.VendorRequest.ToList());
        }

        #region VendorRequest Details
        // GET: /VendorRequest/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorRequest vendorrequest = db.VendorRequest.Find(id);
            if (vendorrequest == null)
            {
                return HttpNotFound();
            }
            return View(vendorrequest);
        }
        #endregion

        #region VendorRequest Request
        //GET: /VendorRequest/Request/id
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Request(long? id)
        {
            var vendorrequest = await db.VendorRequest.FindAsync(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (vendorrequest == null)
            {
                return HttpNotFound();
            }
            return PartialView("Request", vendorrequest);
        }

        // POST: /VendorRequest/Request/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendorRequest request)
        {
            if (ModelState.IsValid)
            {
                
            }
            return PartialView("Edit", request);
        }

        #endregion

        #region VendorRequest Create
        // POST: /VendorRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Request()
        {
            return View();
        }

        // GET: /VendorRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VendorRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VendoerRequestId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber,DateCreated")] VendorRequest vendorrequest)
        {
            if (ModelState.IsValid)
            {
                db.VendorRequest.Add(vendorrequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendorrequest);
        }
        #endregion

        // GET: /VendorRequest/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorRequest vendorrequest = db.VendorRequest.Find(id);
            if (vendorrequest == null)
            {
                return HttpNotFound();
            }
            return View(vendorrequest);
        }

        // POST: /VendorRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VendoerRequestId,Name,Email,Address,LGA,State,ZipCode,PhoneNumber,DateCreated")] VendorRequest vendorrequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorrequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendorrequest);
        }

        // GET: /VendorRequest/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorRequest vendorrequest = db.VendorRequest.Find(id);
            if (vendorrequest == null)
            {
                return HttpNotFound();
            }
            return View(vendorrequest);
        }

        // POST: /VendorRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VendorRequest vendorrequest = db.VendorRequest.Find(id);
            db.VendorRequest.Remove(vendorrequest);
            db.SaveChanges();
            return RedirectToAction("Index");
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
