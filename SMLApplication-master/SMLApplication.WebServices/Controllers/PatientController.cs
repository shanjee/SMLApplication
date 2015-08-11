using SMLApplication.Data.DAL;
using SMLApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class PatientController : ApiController
    {
        private SMLDBEntities db = new SMLDBEntities();
        // GET: api/Login
        public IEnumerable<Patient> Get()
        {
            var data = db.Patients.ToList();
            return data;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public Patient Get(int id)
        {
            return db.Patients.Where(x => x.PatientId == id).FirstOrDefault();
        }

        // POST: api/Login
        public void Post(Patient value)
        {
            
            db.Patients.Add(value);

            db.SaveChanges();
        }

        // PUT: api/Login/5
        public void Put(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
            db.SaveChanges();
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }
    }
}
