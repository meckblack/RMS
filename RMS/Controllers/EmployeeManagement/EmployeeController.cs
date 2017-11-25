using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RMS.Data.Objects.Entities.Employee;
using RMS.Data.DataContext.DataContext.SystemDataContext;
using System.Threading.Tasks;

namespace RMS.Controllers.EmployeeManagement
{
    public class EmployeeController : Controller
    {
        private readonly SystemDataContext db;

        #region constructor
        public EmployeeController()
        {
            db = new SystemDataContext();
        }
        #endregion

        #region restaurant employee index
        // GET: /Employee/
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var employee = from e in db.Employee
                           select e;
            return View(employee.OrderBy(order => order.FirstName).Include(e => e.Bank).Include(e => e.Department).ToList());
        }
        #endregion

        #region Email remote validation
        [Authorize]
        public JsonResult IsEmailAvailable(string Email)
        {
            return Json(!db.Employee.Any(employee => employee.Email == Email), JsonRequestBehavior.AllowGet);
        }
        #endregion


        // GET: /Employee/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        #region create restaurant employee
        // GET: /Employee/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.BankId = new SelectList(db.Bank, "BankId", "Name");
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name");
            var employee = new Employee();
            return PartialView("Create", employee);
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmployeeId,FirstName,LastName,MiddleName,Email,Address,DateOfEmployment,DateOfBirth,PhoneNumber,Gender,AccountName,AccountNumber,BankId,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (db.Employee.Any(record => record.Email == employee.Email))
                {
                    ModelState.AddModelError("Email", "Email. is already is use");
                }
                else 
                {
                    var employeeVar = new Employee
                    {
                        FirstName = employee.FirstName,
                        MiddleName = employee.MiddleName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                        Address = employee.Address,
                        DateOfEmployment = employee.DateOfEmployment,
                        DateOfBirth = employee.DateOfBirth,
                        PhoneNumber = employee.PhoneNumber,
                        Gender = employee.Gender,
                        AccountName = employee.AccountName,
                        AccountNumber = employee.AccountNumber,

                        CreatedBy = User.Identity.Name,
                        DateCreated = DateTime.Now,
                        DateLastModified = DateTime.Now,
                        LastModifiedBy = User.Identity.Name
                    };

                    db.Employee.Add(employeeVar);
                    db.SaveChanges();
                    TempData["Success"] = "Restaurant employee was successfully created! ";
                    return Json(new { success = true });
                }
            }

            ViewBag.BankId = new SelectList(db.Bank, "BankId", "Name", employee.BankId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", employee.DepartmentId);
            return PartialView("Create", employee);
        }
        #endregion


        #region edit restaurant employee
        //
        // GET: /Employee/Edit/id
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Edit(long? id)
        {
            Session["id"] = id;
            var employee = await db.Employee.FindAsync(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Bank, "BankId", "Name", employee.BankId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", employee.DepartmentId);
            return PartialView("Edit", employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmployeeId,FirstName,LastName,MiddleName,Email,Address,DateOfEmployment,DateOfBirth,PhoneNumber,Gender,AccountName,AccountNumber,BankId,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.DateLastModified = DateTime.Now;
                employee.LastModifiedBy = User.Identity.Name;

                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Success"] = "Restaurant employee successfully modified! ";
                return Json(new { success = true } );
            }
            ViewBag.BankId = new SelectList(db.Bank, "BankId", "Name", employee.BankId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", employee.DepartmentId);
            return PartialView("Edit", employee);
        }
        #endregion

        #region delete restaurant employee
        //
        // GET: /Employee/Delete/id
        [HttpGet]
        [Authorize]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View("Delete", employee);
        }
        
        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var employee = await db.Employee.FindAsync(id);
            db.Employee.Remove(employee);
            await db.SaveChangesAsync();

            TempData["Success"] = "Restaurant employee successfully deleted!";
            return Json(new { success = true });
        }
        #endregion
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
