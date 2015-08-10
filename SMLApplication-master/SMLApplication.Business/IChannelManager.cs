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
        Appointment GetAppointmentByAppointmentId(int id);
        IList<Appointment> GetAppointmentsByDoctorId(int doctorId);
        IList<Appointment> GetAppointmentsByPatientId(int patientId);
        bool CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment);
        bool DeleteAppointment(int id);
    }
}
