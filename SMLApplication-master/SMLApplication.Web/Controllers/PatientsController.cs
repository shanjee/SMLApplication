using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMLApplication.Data.Models;
using SMLApplication.Data.DAL;
using SMLApplication.Business;

namespace SMLApplication.Web.Controllers
{
    public class PatientsController : Controller
    {
        private SMLDBEntities db = new SMLDBEntities();
        WebServiceConnector<Patient> service = new WebServiceConnector<Patient>() { Resource = "api/patient/"};
        //
        // GET: /Patients/

        public ActionResult Index()
        {
            var model = service.GetResult();
            return View(model);
        }

        //
        // GET: /Patients/Details/5

        public ActionResult Details(int id = 0)
        {
           // var patient = service.GetData(id);
            Patient patient = service.GetResultById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // GET: /Patients/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Patients/Create

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                //db.Patients.Add(patient);
                //db.SaveChanges(); 
                service.CreateResult(patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        //
        // GET: /Patients/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Patient patient = service.GetResultById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Patients/Edit/5

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                service.UpdateResult(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        //
        // GET: /Patients/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Patient patient = service.GetResultById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Patients/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteResult(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}