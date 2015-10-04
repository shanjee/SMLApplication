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
    public class SpecializationController : ApiController
    {
        //
        // GET: /Specialization/

        private SMLDBEntities db = new SMLDBEntities();
        // GET: api/Login
        public IEnumerable<Specialization> Get()
        {
            var data = db.Specializations.ToList();
            return data;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public Specialization Get(int id)
        {
            return db.Specializations.Where(x => x.SpecializationId == id).FirstOrDefault();
        }

        // POST: api/Login
        public void Post(Specialization value)
        {

            db.Specializations.Add(value);

            db.SaveChanges();
        }

        // PUT: api/Login/5
        public void Put(Specialization patient)
        {
            db.Entry(patient).State = EntityState.Modified;
            db.SaveChanges();
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
            Specialization patient = db.Specializations.Find(id);
            db.Specializations.Remove(patient);
            db.SaveChanges();
        }

    }
}
