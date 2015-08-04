using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMLApplication.Data;
using SMLApplication.Data.Models;

namespace SMLApplication.Business
{
    public interface IChannelManager
    {
        IList<Appointment> GetAppointments();
        IList<Appointment> GetAppointmentsByDoctorId(int doctorId);
        IList<Appointment> GetAppointmentsByPatientId(int patientId);
        Appointment GetAppointmentByAppointmentId(int id);
        bool CreateAppointmentByPatientIdAndDoctorId(int patientId, int doctorId);
        bool UpdateAppointment(int appointmentId, int patientId, int doctorId);
        bool DeleteAppointment(int appointmentId);
    }
}
