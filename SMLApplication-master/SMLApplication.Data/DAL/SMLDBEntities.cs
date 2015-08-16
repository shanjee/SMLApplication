using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SMLApplication.Data.Models;

namespace SMLApplication.Data.DAL
{
    public class SMLDBEntities : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public SMLDBEntities()
            : base("name=SMLDBEntities")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
    }
}
