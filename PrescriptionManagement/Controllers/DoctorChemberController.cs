using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;

namespace PrescriptionManagement.Controllers
{
    public class DoctorChemberController : Controller
    {
        private PrescriptionManagementDBEntities db = new PrescriptionManagementDBEntities();

        // GET: /DoctorChember/
        public ActionResult Index()
        {
            var doctorchembers = db.DoctorChembers.Include(d => d.Doctor);
            return View(doctorchembers.ToList());
        }

        // GET: /DoctorChember/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorChember doctorchember = db.DoctorChembers.Find(id);
            if (doctorchember == null)
            {
                return HttpNotFound();
            }
            return View(doctorchember);
        }

        // GET: /DoctorChember/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorName");
            return View();
        }

        // POST: /DoctorChember/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DoctorId,ChemberName,ChembeAddress,ChembeCity,ChembeCountry,ChembeMobileNo,ChembeEmail,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId,CompanyId")] DoctorChember doctorchember)
        {
            if (ModelState.IsValid)
            {
                db.DoctorChembers.Add(doctorchember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorName", doctorchember.DoctorId);
            return View(doctorchember);
        }

        // GET: /DoctorChember/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorChember doctorchember = db.DoctorChembers.Find(id);
            if (doctorchember == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorName", doctorchember.DoctorId);
            return View(doctorchember);
        }

        // POST: /DoctorChember/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DoctorId,ChemberName,ChembeAddress,ChembeCity,ChembeCountry,ChembeMobileNo,ChembeEmail,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId,CompanyId")] DoctorChember doctorchember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorchember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorName", doctorchember.DoctorId);
            return View(doctorchember);
        }

        // GET: /DoctorChember/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorChember doctorchember = db.DoctorChembers.Find(id);
            if (doctorchember == null)
            {
                return HttpNotFound();
            }
            return View(doctorchember);
        }

        // POST: /DoctorChember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorChember doctorchember = db.DoctorChembers.Find(id);
            db.DoctorChembers.Remove(doctorchember);
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
