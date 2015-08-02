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
    public class BookingsController : Controller
    {
        private SMLDBEntities db = new SMLDBEntities();

        //
        // GET: /Bookings/

        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Doctor).Include(b => b.Patient);
            return View(bookings.ToList());
        }

        //
        // GET: /Bookings/Details/5

        public ActionResult Details(int id = 0)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        //
        // GET: /Bookings/Create

        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name");
            return View();
        }

        //
        // POST: /Bookings/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", booking.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", booking.PatientId);
            return View(booking);
        }

        //
        // GET: /Bookings/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", booking.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", booking.PatientId);
            return View(booking);
        }

        //
        // POST: /Bookings/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", booking.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", booking.PatientId);
            return View(booking);
        }

        //
        // GET: /Bookings/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        //
        // POST: /Bookings/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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