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
    public class ApplicantStudentsController : Controller
    {
        private EduSmart_dbEntities db = new EduSmart_dbEntities();

        // GET: ApplicantStudents
        public ActionResult Index()
        {
            return View(db.ApplicantStudents.ToList());
        }

        // GET: ApplicantStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantStudent applicantStudent = db.ApplicantStudents.Find(id);
            if (applicantStudent == null)
            {
                return HttpNotFound();
            }
            return View(applicantStudent);
        }

        // GET: ApplicantStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicantStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicantStudentId,EnrollmentDate,ApplicantPersonId,GradeEntering")] ApplicantStudent applicantStudent)
        {
            if (ModelState.IsValid)
            {
                db.ApplicantStudents.Add(applicantStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicantStudent);
        }

        // GET: ApplicantStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantStudent applicantStudent = db.ApplicantStudents.Find(id);
            if (applicantStudent == null)
            {
                return HttpNotFound();
            }
            return View(applicantStudent);
        }

        // POST: ApplicantStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicantStudentId,EnrollmentDate,ApplicantPersonId,GradeEntering")] ApplicantStudent applicantStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicantStudent);
        }

        // GET: ApplicantStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantStudent applicantStudent = db.ApplicantStudents.Find(id);
            if (applicantStudent == null)
            {
                return HttpNotFound();
            }
            return View(applicantStudent);
        }

        // POST: ApplicantStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicantStudent applicantStudent = db.ApplicantStudents.Find(id);
            db.ApplicantStudents.Remove(applicantStudent);
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
