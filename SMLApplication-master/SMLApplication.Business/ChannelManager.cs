using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SMLApplication.Data;
using SMLApplication.Data.Models;
using SMLApplication.Data.DAL;
using SMLApplication.ServiceFacade;

namespace SMLApplication.Business
{
    public class ChannelManager : IChannelManager
    {
        //private SMLDBEntities context = new SMLDBEntities();
        //WebServiceConnector<Appointment> service = new WebServiceConnector<Appointment>();
        ChannellingServiceFacade channellingServiceFacade;

        public ChannelManager()
        {
            channellingServiceFacade = new ChannellingServiceFacade();
        }

        public IList<Appointment> GetAppointments()
        {
            return channellingServiceFacade.GetAppointments();
        }

        public Appointment GetAppointmentByAppointmentId(int appointmentId)
        {
            return channellingServiceFacade.GetAppointmentByAppointmentId(appointmentId);
        }

        public IList<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return channellingServiceFacade.GetAppointmentsByDoctorId(doctorId);
        }

        public IList<Appointment> GetAppointmentsByDoctorName(string doctorName)
        {
            return channellingServiceFacade.GetAppointmentsByDoctorName(doctorName);
        }

        public IList<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return channellingServiceFacade.GetAppointmentsByPatientId(patientId);
        }

        public IList<Appointment> GetAppointmentsByPatientName(string patientName)
        {
            return channellingServiceFacade.GetAppointmentsByPatientName(patientName);
        }

        public bool CreateAppointment(Appointment appointment)
        {
            return channellingServiceFacade.CreateAppointment(appointment);
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            return channellingServiceFacade.UpdateAppointment(appointment);
        }

        public bool DeleteAppointment(int id)
        {
            return channellingServiceFacade.DeleteAppointment(id);
        }

    }
}
