using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using SMLApplication.Data;
using SMLApplication.Data.DAL;
using SMLApplication.Data.Models;
using System.Data;

namespace SMLApplication.WebServices.Controllers
{
    public class AppointmentsController : ApiController
    {
        private SMLDBEntities context = new SMLDBEntities();

        #region Intial Code With Value Controller
        //// GET api/Values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/Channel/5
        //public string Get1(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/Channel/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/Channel/5
        //public void Delete(int id)
        //{
        //}
        
        #endregion
        // GET api/Appointments
        [HttpGet]
        public IList<Appointment> GetAppointments()
        {
            var result = context.Appointments.Include(b => b.Doctor).Include(b => b.Patient).ToList();
            return result;
        }

        [HttpGet]
        [ActionName("ById")]
        public Appointment GetAppointmentByAppointmentId(int id)
        {
            var result = context.Appointments.Include(b => b.Doctor).Include(b => b.Patient).Where(r => r.AppointmentId == id).FirstOrDefault(); ;
           return result;
        }  

        // GET api/Appointments/AppointmentsByDoctorId/5
        [HttpGet]
        [ActionName("ByDoctorId")]
        public IList<Appointment> GetAppointmentsByDoctorId(int id)
        {
            var result = context.Appointments.Include(b => b.Doctor).Include(b => b.Patient).Where(r => r.DoctorId == id).ToList();
            return result;
        }

        [HttpGet]
        [ActionName("ByDoctorName")]
        public IList<Appointment> GetAppointmentsByDoctorName(string id)
        {
            var result = context.Appointments.Include(b => b.Doctor).Include(b => b.Patient).Where(r => r.Doctor.Name == id).ToList();

            return result;
        }

        // GET api/Appointments/AppointmentsByPatientId/5
        [HttpGet]
        [ActionName("ByPatientId")]
        public IList<Appointment> GetAppointmentsByPatientId(int id)
        {
            return context.Appointments.Include(b => b.Doctor).Include(b => b.Patient).Where(r => r.PatientId == id).ToList();
        }

        [HttpGet]
        [ActionName("ByPatientName")]
        public IList<Appointment> GetAppointmentsByPatientName(string id)
        {
            var result = context.Appointments.Include(b => b.Doctor).Include(b => b.Patient).Where(r => r.Patient.Name == id).ToList();

            return result;
        }

        // GET api/Appointments/5
        public void Post(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            context.SaveChanges();
        }

        public bool Put(Appointment appointment)
        {
            context.Entry(appointment).State = EntityState.Modified;
            context.SaveChanges();

            return true;

        }

        public bool Delete(int id)
        {
            Appointment appointment = context.Appointments.Find(id);
            context.Appointments.Remove(appointment);
            context.SaveChanges();

            return true;
        }
    }
}