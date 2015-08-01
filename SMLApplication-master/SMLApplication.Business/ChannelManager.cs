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
        public IList<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            SMLDBEntities context = new SMLDBEntities();
            return context.Appointments.ToList();
        }
    }
}
