using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return context.Appointments.Where(r => r.DoctorId == doctorId).ToList();
        }

        public Appointment GetAppointmentByAppointmentId(int appointmentId)
        {
            return context.Appointments.Find(appointmentId);
        }

        public bool CreateAppointmentByPatientIdAndDoctorId(int patientId, int doctorId)
        {
            //var result = service.PutData();
            return true;
        }

        public IList<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return context.Appointments.Where(r => r.PatientId == patientId).ToList();
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
