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
    public class SpecializationsController : Controller
    {
        private SMLDBEntities db = new SMLDBEntities();
        WebServiceConnector<Specialization> service = new WebServiceConnector<Specialization>() { Resource = "api/specialization/" };
        

        //
        // GET: /Specializations/

        public ActionResult Index()
        {
            var model = service.GetResult();
            return View(model);
        }

        //
        // GET: /Specializations/Details/5

        public ActionResult Details(int id = 0)
        {            
            // var patient = service.GetData(id);
            var specialization = service.GetResultById(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        //
        // GET: /Specializations/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Specializations/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                service.CreateResult(specialization);
                return RedirectToAction("Index");
            }

            return View(specialization);
        }

        //
        // GET: /Specializations/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Specialization specialization = service.GetResultById(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        //
        // POST: /Specializations/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                service.UpdateResult(specialization);
                return RedirectToAction("Index");
            }
            return View(specialization);
        }

        //
        // GET: /Specializations/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Specialization specialization = service.GetResultById(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        //
        // POST: /Specializations/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialization specialization = db.Specializations.Find(id);
            db.Specializations.Remove(specialization);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}