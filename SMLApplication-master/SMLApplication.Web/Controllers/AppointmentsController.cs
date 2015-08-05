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
            var Appointments = db.Appointments.Include(b => b.Doctor).Include(b => b.Patient);
            return View(Appointments.ToList());
        }

        //
        // GET: /Appointments/Details/5

        public ActionResult Details(int id = 0)
        {
            Appointment Appointment = db.Appointments.Find(id);
            if (Appointment == null)
            {
                return HttpNotFound();
            }
            return View(Appointment);
        }

        //
        // GET: /Appointments/Create

        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name");
            return View();
        }

        //
        // POST: /Appointments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment Appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(Appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", Appointment.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", Appointment.PatientId);
            return View(Appointment);
        }

        //
        // GET: /Appointments/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Appointment Appointment = db.Appointments.Find(id);
            if (Appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", Appointment.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", Appointment.PatientId);
            return View(Appointment);
        }

        //
        // POST: /Appointments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Appointment Appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", Appointment.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", Appointment.PatientId);
            return View(Appointment);
        }

        //
        // GET: /Appointments/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Appointment Appointment = db.Appointments.Find(id);
            if (Appointment == null)
            {
                return HttpNotFound();
            }
            return View(Appointment);
        }

        //
        // POST: /Appointments/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment Appointment = db.Appointments.Find(id);
            db.Appointments.Remove(Appointment);
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