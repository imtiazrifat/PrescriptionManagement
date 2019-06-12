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
    public class DrugCompaniesController : Controller
    {
        private PrescriptionManagementDBEntities db = new PrescriptionManagementDBEntities();

        // GET: /DrugCompanies/
        public ActionResult Index()
        {
            return View(db.Drug_Companies.ToList());
        }

        // GET: /DrugCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Companies drug_companies = db.Drug_Companies.Find(id);
            if (drug_companies == null)
            {
                return HttpNotFound();
            }
            return View(drug_companies);
        }

        // GET: /DrugCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DrugCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CompanyName,CompanyDetails,Note,Extra,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId,CompanyId")] Drug_Companies drug_companies)
        {
            if (ModelState.IsValid)
            {
                db.Drug_Companies.Add(drug_companies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drug_companies);
        }

        // GET: /DrugCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Companies drug_companies = db.Drug_Companies.Find(id);
            if (drug_companies == null)
            {
                return HttpNotFound();
            }
            return View(drug_companies);
        }

        // POST: /DrugCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CompanyName,CompanyDetails,Note,Extra,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId,CompanyId")] Drug_Companies drug_companies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drug_companies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drug_companies);
        }

        // GET: /DrugCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Companies drug_companies = db.Drug_Companies.Find(id);
            if (drug_companies == null)
            {
                return HttpNotFound();
            }
            return View(drug_companies);
        }

        // POST: /DrugCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drug_Companies drug_companies = db.Drug_Companies.Find(id);
            db.Drug_Companies.Remove(drug_companies);
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
