using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLApplication.Data.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Bookingdate { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
