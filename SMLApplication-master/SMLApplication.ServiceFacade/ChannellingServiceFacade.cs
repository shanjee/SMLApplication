using SMLApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLApplication.ServiceFacade
{
    public class ChannellingServiceFacade
    {
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
            var result = service.GetDataById(appointmentId);
            return result;
        }

        public IList<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            //return context.Appointments.Where(r => r.DoctorId == doctorId).ToList();
            return null;
        }

        public IList<Appointment> GetAppointmentsByDoctorName(string doctorName)
        {
            service.Resource = "api/appointments/ByDoctorName/";
            var result = service.GetDataByName(doctorName);
            return result;
        }

        public IList<Appointment> GetAppointmentsByPatientId(int patientId)
        {
           // return context.Appointments.Where(r => r.PatientId == patientId).ToList();
            return null;
        }

        public IList<Appointment> GetAppointmentsByPatientName(string patientName)
        {
            service.Resource = "api/appointments/ByPatientName/";
            var result = service.GetDataByName(patientName);
            return result;
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
