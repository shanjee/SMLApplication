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
using SMLApplication.Web.Models;

namespace SMLApplication.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private SMLDBEntities db = new SMLDBEntities();
        IChannelManager channelManager = new ChannelManager();
        WebServiceConnector<Appointment> service = new WebServiceConnector<Appointment>();

        //
        // GET: /Appointments/

        public ActionResult Index()
        {
            IList<Appointment> model;

            if (User.IsInRole("Patient"))
            {
                model = channelManager.GetAppointmentsByPatientName(User.Identity.Name);
            }
            else if (User.IsInRole("Doctor"))
            {
                model = channelManager.GetAppointmentsByDoctorName(User.Identity.Name);
            }
            else
            {
                model = channelManager.GetAppointments();
            }
            return View(model);
        }

        //
        // GET: /Appointments/Details/5

        public ActionResult Details(int id = 0)
        {
            //Appointment Appointment = db.Appointments.Find(id);
            //if (Appointment == null)
            //{
            //    return HttpNotFound();

            var model = channelManager.GetAppointmentByAppointmentId(id);
            return View(model);
        }

        //
        // GET: /Appointments/Create

        public ActionResult Create()
        {
            ViewBag.Doctors = new SelectList(db.Doctors, "DoctorId", "Name");
            ViewBag.Patients = new SelectList(db.Patients, "PatientId", "Name");
            ViewBag.Specializations = new SelectList(db.Specializations, "SpecializationId", "SpecializationName");
            return View();
        }

        //
        // POST: /Appointments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentsCreateViewModel appointmentsVM)
        {
            Appointment appointment = new Appointment();

            if (User.IsInRole("Doctor"))
            {
                appointmentsVM.doctorAppointment.DoctorId = db.Doctors.Where(r => r.Name == User.Identity.Name).Select(r => r.DoctorId).FirstOrDefault();
                appointment = appointmentsVM.doctorAppointment;
            }

            else if (User.IsInRole("Patient"))
            {
                if (appointmentsVM.currentTab == 1)
                {
                    appointmentsVM.tab1Appointment.PatientId = db.Patients.Where(r => r.Name == User.Identity.Name).Select(r => r.PatientId).FirstOrDefault();
                    appointment = appointmentsVM.tab1Appointment;
                    RemoveModelStateKeyByTab("tab2");
                }
                else if (appointmentsVM.currentTab == 2)
                {
                    appointmentsVM.tab2Appointment.PatientId = db.Patients.Where(r => r.Name == User.Identity.Name).Select(r => r.PatientId).FirstOrDefault();
                    appointment = appointmentsVM.tab2Appointment;
                    RemoveModelStateKeyByTab("tab1");
                }
            }
            else if (User.IsInRole("Admin"))
            {
                if (appointmentsVM.currentTab == 1)
                {
                    appointment = appointmentsVM.tab1Appointment;
                    RemoveModelStateKeyByTab("tab2");
                }
                else if (appointmentsVM.currentTab == 2)
                {
                    appointment = appointmentsVM.tab2Appointment;
                    RemoveModelStateKeyByTab("tab1");
                }
            }

            if (ModelState.IsValid)
            {
                channelManager.CreateAppointment(appointment);
                return RedirectToAction("index");
            }

            ViewBag.tab1Appointment.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", appointmentsVM.tab1Appointment.DoctorId);
            ViewBag.tab1Appointment.PatientId = new SelectList(db.Patients, "PatientId", "Name", appointmentsVM.tab1Appointment.PatientId);
            ViewBag.tab2Appointment.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", appointmentsVM.tab2Appointment.DoctorId);
            ViewBag.tab2Appointment.PatientId = new SelectList(db.Patients, "PatientId", "Name", appointmentsVM.tab2Appointment.PatientId);
            return View(appointmentsVM);
        }

        //
        // GET: /Appointments/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Appointment Appointment = channelManager.GetAppointmentByAppointmentId(id);
            if (Appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", Appointment.DoctorId);
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", Appointment.Doctor.SpecializationId);
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
                service.Resource = "api/appointments";
                service.UpdateResult(Appointment);
                //var result = channelManager.UpdateAppointment(Appointment);
                //db.Entry(Appointment).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", Appointment.DoctorId);
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", 0);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", Appointment.PatientId);
            return View(Appointment);
        }

        //
        // GET: /Appointments/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Appointment Appointment = channelManager.GetAppointmentByAppointmentId(id);
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
            service.Resource = "api/appointments/";
            service.DeleteResult(id);
            //var result = channelManager.DeleteAppointment(id);
            //Appointment Appointment = db.Appointments.Find(id);
            //db.Appointments.Remove(Appointment);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetDoctorsBySpecialization(int id)
        {
            var list = db.Doctors.Where(r => r.SpecializationId == id).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSpecializationByDoctorID(int id)
        {
            List<Specialization> list;
            if (id > 0)
            {
                list = db.Doctors.Where(r => r.DoctorId == id).Select(r => r.Specializations).ToList();
            }
            else
            {
                list = db.Doctors.Select(r => r.Specializations).ToList();
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public void RemoveModelStateKeyByTab(string key)
        {
            List<string> modelStateKeys = new List<string>() { key + "Appointment.DoctorId", key + "Appointment.PatientId", key + "Appointment.AppointmentDate" };

            foreach (var item in modelStateKeys)
            {
                if (ModelState.ContainsKey(item))
                {
                    ModelState[item].Errors.Clear();
                }
            }
           
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}