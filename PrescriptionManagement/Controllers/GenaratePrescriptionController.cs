using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;

namespace PrescriptionManagement.Controllers
{
    public class GenaratePrescriptionController : Controller
    {
        private PrescriptionManagementDBEntities db = new PrescriptionManagementDBEntities();
        //
        // GET: /GenaratePrescription/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /GetAllPatient/
        public JsonResult GetAllPatient()
        {
            var data = db.Patients.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        // GET: /GetAPatient/1
        public ActionResult GetAPatient(int id)
        {
            var data = db.Patients.Find( id);

            var list = JsonConvert.SerializeObject(data,
  Formatting.None,
  new JsonSerializerSettings()
  {
      ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
  });

            return Content(list, "application/json");
            // return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

    }
}