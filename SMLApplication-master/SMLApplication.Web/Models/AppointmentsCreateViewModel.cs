using SMLApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMLApplication.Web.Models
{
    public class AppointmentsCreateViewModel
    {
        public Appointment tab1Appointment { get; set; }
        public Appointment tab2Appointment { get; set; }
        public Appointment doctorAppointment { get; set; }
        public int currentTab { get; set; }
    }
}