using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;

namespace PrescriptionManagement.Controllers
{
    public class DrugDetailsController : Controller
    {
        private PrescriptionManagementDBEntities db = new PrescriptionManagementDBEntities();

        // GET: /DrugDetails/
        public ActionResult Index()
        {
            var drug_details = db.Drug_Details.Include(d => d.Drug_Companies).Include(d => d.Drug_Type);
            return View(drug_details.ToList());
        }

        // GET: /DrugDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Details drug_details = db.Drug_Details.Find(id);
            if (drug_details == null)
            {
                return HttpNotFound();
            }
            return View(drug_details);
        }

        // GET: /DrugDetails/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Drug_Companies, "Id", "CompanyName");
            ViewBag.DrugTypeId = new SelectList(db.Drug_Type, "Id", "DrugTypeName");
            return View();
        }

        // POST: /DrugDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CompanyId,DrugTypeId,DrugName,DrugDescription,GenericName,RetailPrice,DrugAvailableDate,DrugWithdrawDate,Note,Extra,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId")] Drug_Details drug_details)
        {
            if (ModelState.IsValid)
            {
                db.Drug_Details.Add(drug_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Drug_Companies, "Id", "CompanyName", drug_details.CompanyId);
            ViewBag.DrugTypeId = new SelectList(db.Drug_Type, "Id", "DrugTypeName", drug_details.DrugTypeId);
            return View(drug_details);
        }

        // GET: /DrugDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Details drug_details = db.Drug_Details.Find(id);
            if (drug_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Drug_Companies, "Id", "CompanyName", drug_details.CompanyId);
            ViewBag.DrugTypeId = new SelectList(db.Drug_Type, "Id", "DrugTypeName", drug_details.DrugTypeId);
            return View(drug_details);
        }

        // POST: /DrugDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CompanyId,DrugTypeId,DrugName,DrugDescription,GenericName,RetailPrice,DrugAvailableDate,DrugWithdrawDate,Note,Extra,IsActive,IsDeleted,NotDeletable,CreationDate,UpdateDate,UserId")] Drug_Details drug_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drug_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Drug_Companies, "Id", "CompanyName", drug_details.CompanyId);
            ViewBag.DrugTypeId = new SelectList(db.Drug_Type, "Id", "DrugTypeName", drug_details.DrugTypeId);
            return View(drug_details);
        }

        // GET: /DrugDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug_Details drug_details = db.Drug_Details.Find(id);
            if (drug_details == null)
            {
                return HttpNotFound();
            }
            return View(drug_details);
        }

        // POST: /DrugDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drug_Details drug_details = db.Drug_Details.Find(id);
            db.Drug_Details.Remove(drug_details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ///DrugDetails/Getmed
        public JsonResult Getmed(string prefix)
        {
            //var allMed = db.Drug_Details;
            //var medName =
            //     from n in allMed
            //     where n.DrugName.StartsWith(prefix)
            //     select n;
            //var medNameaa = medName.Select(aa=>new{aa.DrugName,aa.Id});

            var medNameaa = db.Drug_Details.Where(p => p.DrugName.StartsWith(prefix)).Select(p => new{p.DrugName,p.Id}).ToList();

           // return Json(new { data = medNameaa }, JsonRequestBehavior.AllowGet);
           return Json(medNameaa, JsonRequestBehavior.AllowGet);
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
