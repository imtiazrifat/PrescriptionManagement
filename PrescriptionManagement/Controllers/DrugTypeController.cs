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
    public class DrugTypeController : Controller
    {
        private PrescriptionManagementDBEntities db = new PrescriptionManagementDBEntities();

        // GET: /DrugType/
        public ActionResult Index()
        {
            return View(db.Drug_Type.ToList());
        }

        // GET: /DrugType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Type drug_type = db.Drug_Type.Find(id);
            if (drug_type == null)
            {
                return HttpNotFound();
            }
            return View(drug_type);
        }

        // GET: /DrugType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DrugType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DrugTypeName,DrugTypeCode,Note,Extra,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId,CompanyId")] Drug_Type drug_type)
        {
            if (ModelState.IsValid)
            {
                db.Drug_Type.Add(drug_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drug_type);
        }

        // GET: /DrugType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Type drug_type = db.Drug_Type.Find(id);
            if (drug_type == null)
            {
                return HttpNotFound();
            }
            return View(drug_type);
        }

        // POST: /DrugType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DrugTypeName,DrugTypeCode,Note,Extra,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId,CompanyId")] Drug_Type drug_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drug_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drug_type);
        }

        // GET: /DrugType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Type drug_type = db.Drug_Type.Find(id);
            if (drug_type == null)
            {
                return HttpNotFound();
            }
            return View(drug_type);
        }

        // POST: /DrugType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drug_Type drug_type = db.Drug_Type.Find(id);
            db.Drug_Type.Remove(drug_type);
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
