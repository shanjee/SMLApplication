using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLApplication.Data.Models
{
    public class Appointment
    {
        //public int Id { get; set; }
        [Key]
        [Column(Order = 0)]
        public int DoctorId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PatientId { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
