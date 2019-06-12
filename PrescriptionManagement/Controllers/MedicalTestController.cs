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
    public class MedicalTestController : Controller
    {
        private PrescriptionManagementDBEntities db = new PrescriptionManagementDBEntities();

        // GET: /MedicalTest/
        public ActionResult Index()
        {
            return View(db.MedicalTests.ToList());
        }

        // GET: /MedicalTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicaltest = db.MedicalTests.Find(id);
            if (medicaltest == null)
            {
                return HttpNotFound();
            }
            return View(medicaltest);
        }
        // GET: /MedicalTest/GetTest
        public JsonResult GetTest(string prefix)
        {
            //var allMed = db.Drug_Details;
            //var medName =
            //     from n in allMed
            //     where n.DrugName.StartsWith(prefix)
            //     select n;
            //var medNameaa = medName.Select(aa=>new{aa.DrugName,aa.Id});

            var medNameaa = db.MedicalTests.Where(p => p.MedicalTestName.StartsWith(prefix)).Select(p => new { p.MedicalTestName, p.Id }).ToList();

            // return Json(new { data = medNameaa }, JsonRequestBehavior.AllowGet);
            return Json(medNameaa, JsonRequestBehavior.AllowGet);
        }


        // GET: /MedicalTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MedicalTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,MedicalTestName,MedicalTestDetails,MedicalTestAdvice,Note,Extra,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId,CompanyId")] MedicalTest medicaltest)
        {
            if (ModelState.IsValid)
            {
                db.MedicalTests.Add(medicaltest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicaltest);
        }

        // GET: /MedicalTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicaltest = db.MedicalTests.Find(id);
            if (medicaltest == null)
            {
                return HttpNotFound();
            }
            return View(medicaltest);
        }

        // POST: /MedicalTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,MedicalTestName,MedicalTestDetails,MedicalTestAdvice,Note,Extra,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId,CompanyId")] MedicalTest medicaltest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicaltest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicaltest);
        }

        // GET: /MedicalTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicaltest = db.MedicalTests.Find(id);
            if (medicaltest == null)
            {
                return HttpNotFound();
            }
            return View(medicaltest);
        }

        // POST: /MedicalTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalTest medicaltest = db.MedicalTests.Find(id);
            db.MedicalTests.Remove(medicaltest);
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
