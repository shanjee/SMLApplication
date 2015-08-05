using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMLApplication.Data;
using SMLApplication.Data.DAL;
using SMLApplication.Data.Models;

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
            return context.Appointments.ToList();
        }

        [HttpGet]
        public Appointment GetAppointmentByAppointmentId(int id)
        {
            return context.Appointments.Find(id);
        }

        // GET api/Appointments/AppointmentsByDoctorId/5
        [HttpGet]
        [ActionName("AppointmentsByDoctorId")]
        public IList<Appointment> GetAppointmentsByDoctorId(int Id)
        {
            return context.Appointments.Where(r => r.DoctorId == Id).ToList();
        }

        // GET api/Appointments/AppointmentsByPatientId/5
        [HttpGet]
        [ActionName("AppointmentsByPatientId")]
        public IList<Appointment> GetAppointmentsByPatientId(int Id)
        {
            return context.Appointments.Where(r => r.PatientId == Id).ToList();
        }

        // GET api/Appointments/5
        public bool CreateAppointmentByPatientIdAndDoctorId(int patientId, int doctorId)
        {
            // TODO: Add insert logic here
            Appointment appointment = new Appointment();

            //TODO Get the current patient Id  from the session
            appointment.PatientId = patientId;
            appointment.DoctorId = doctorId;

            context.Appointments.Add(appointment);
            context.SaveChanges();
            return true;
        }

        public bool UpdateAppointment(int appointmentId, int patientId, int doctorId)
        {
            Appointment appointment = context.Appointments.Find(appointmentId);
            appointment.PatientId = patientId;
            appointment.DoctorId = doctorId;
            context.SaveChanges();

            return true;
        }

        public bool DeleteAppointment(int appointmentId)
        {
            Appointment appointment = context.Appointments.Find(appointmentId);
            context.Appointments.Remove(appointment);
            context.SaveChanges();

            return true;
        }
    }
}