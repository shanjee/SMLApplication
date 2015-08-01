using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMLApplication.Data.Models;
using SMLApplication.Data.DAL;

namespace SMLApplication.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private SMLDBEntities db = new SMLDBEntities();

        //
        // GET: /Appointments/

        public ActionResult Index()
        {
            return View(db.Appointments.ToList());
        }

        //
        // GET: /Appointments/Details/5

        public ActionResult Details(int id = 0)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        //
        // GET: /Appointments/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Appointments/Create

        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        //
        // GET: /Appointments/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        //
        // POST: /Appointments/Edit/5

        [HttpPost]
        public ActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        //
        // GET: /Appointments/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        //
        // POST: /Appointments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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