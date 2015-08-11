using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SMLApplication.Data;
using SMLApplication.Data.Models;
using SMLApplication.Data.DAL;

namespace SMLApplication.Business
{
    public class ChannelManager : IChannelManager
    {
        private SMLDBEntities context = new SMLDBEntities();
        WebServiceConnector<Appointment> service = new WebServiceConnector<Appointment>();

        public IList<Appointment> GetAppointments()
        {
            service.Resource = "api/appointments";
            var result = service.GetData();
            return result;
        }

        public Appointment GetAppointmentByAppointmentId(int appointmentId)
        {
            service.Resource = "api/appointments/ByID/";
            var result = service.GetDataById(1);
            return result;
        }
        public IList<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return context.Appointments.Where(r => r.DoctorId == doctorId).ToList();
        }

        public IList<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return context.Appointments.Where(r => r.PatientId == patientId).ToList();
        }

        public bool CreateAppointment(Appointment appointment)
        {
            //service.Resource = "api/appointments/CreateAppointment";
            //service.CreateResult(appointment);
            service.Resource = "api/appointments";
            service.CreateResult(appointment);
            return true;
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            service.Resource = "api/appointments";
            service.UpdateResult(appointment);
            //Appointment appointment = context.Appointments.Find(appointmentId);
            //appointment.PatientId = appointment.PatientId;
            //appointment.DoctorId = appointment.DoctorId;
            //appointment.AppointmentDate = appointment.DoctorId
            //context.SaveChanges();

            return true;
        }

        public bool DeleteAppointment(int id)
        {
            service.Resource = "api/appointments/";
            service.DeleteResult(id);
            //Appointment appointment = context.Appointments.Find(appointmentId);
            //context.Appointments.Remove(appointment);
            //context.SaveChanges();

            return true;
        }

    }
}
