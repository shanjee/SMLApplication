using SMLApplication.Data.DAL;
using SMLApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMLApplication.WebServices.Controllers
{
    public class SpecializationController : Controller
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
