using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EduBrain.Models;

namespace EduBrain.Controllers
{
    public class LockerController : Controller
    {
        private EduSmart_dbEntities db = new EduSmart_dbEntities();

        // GET: Locker
        public ActionResult Index(string searchString, bool availableLocker = true)
        {
            var lockers = from l in db.Students
                           select l;

            
            if (!String.IsNullOrEmpty(searchString))
            {
                lockers = lockers.Where(s => s.StudentId > 0 
                                    );
            }
            return View(db.Lockers.ToList());
        }

        // GET: Locker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locker locker = db.Lockers.Find(id);
            if (locker == null)
            {
                return HttpNotFound();
            }
            return View(locker);
        }

        // GET: Locker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LockerId,LockerNumber,StudentId,DateAssigned,Location,CombinationNumber")] Locker locker)
        {
            if (ModelState.IsValid)
            {
                db.Lockers.Add(locker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locker);
        }

        // GET: Locker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locker locker = db.Lockers.Find(id);
            if (locker == null)
            {
                return HttpNotFound();
            }
            return View(locker);
        }

        // POST: Locker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LockerId,LockerNumber,StudentId,DateAssigned,Location,CombinationNumber")] Locker locker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locker);
        }

        // GET: Locker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locker locker = db.Lockers.Find(id);
            if (locker == null)
            {
                return HttpNotFound();
            }
            return View(locker);
        }

        // POST: Locker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locker locker = db.Lockers.Find(id);
            db.Lockers.Remove(locker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
