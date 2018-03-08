using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EduBrain.Models;

namespace EduBrain.Controllers.Api
{
    [RoutePrefix("api/Lockers")]
    public class LockersController : ApiController
    {
        private EduSmart_dbEntities db = new EduSmart_dbEntities();

        // GET: api/Lockers
        public IQueryable<Locker> GetLockers()
        {
            return db.Lockers;
        }


        [Route("availableLocker")]
        [HttpGet]
        public IQueryable<Locker> GetAvailableLockers()
        {
            return db.Lockers.Where(l => l.StudentId == null ||  l.StudentId == 0);
        }

        // GET: api/Lockers/5
        [ResponseType(typeof(Locker))]
        public IHttpActionResult GetLocker(int id)
        {
            Locker locker = db.Lockers.Find(id);
            if (locker == null)
            {
                return NotFound();
            }

            return Ok(locker);
        }

        // PUT: api/Lockers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocker(int id, Locker locker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locker.LockerId)
            {
                return BadRequest();
            }

            db.Entry(locker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LockerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Lockers
        [ResponseType(typeof(Locker))]
        public IHttpActionResult PostLocker(Locker locker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lockers.Add(locker);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LockerExists(locker.LockerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = locker.LockerId }, locker);
        }

        // DELETE: api/Lockers/5
        [ResponseType(typeof(Locker))]
        public IHttpActionResult DeleteLocker(int id)
        {
            Locker locker = db.Lockers.Find(id);
            if (locker == null)
            {
                return NotFound();
            }

            db.Lockers.Remove(locker);
            db.SaveChanges();

            return Ok(locker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LockerExists(int id)
        {
            return db.Lockers.Count(e => e.LockerId == id) > 0;
        }
    }
}