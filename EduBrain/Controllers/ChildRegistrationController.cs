using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduBrain.Models;

namespace EduBrain.Controllers
{
    public class ChildRegistrationController : Controller
    {

        private EduSmart_dbEntities _db = new EduSmart_dbEntities(); 
        // GET: RegisterChild
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Register()
        {
            var currentUserEmail = User.Identity.Name;
            var  student  = _db.ApplicantStudents.ToList();
            var applicantexists = _db.ApplicantPersons.Where(p => p.EmailAddress == currentUserEmail).
                Select(e => e.EmailAddress).FirstOrDefault();
            //    var applicantexists = _db.applicantpersons.any(u => u.emailaddress == currentuseremail);
            if (!_db.ApplicantPersons.Any(u => u.EmailAddress == currentUserEmail))
            {
                var applicant = new ApplicantPerson { EmailAddress = User.Identity.Name };
                _db.ApplicantPersons.Add(applicant);
                //_db.applicantpersons.attach(applicant);
                //_db.entry(applicant).property(x => x.emailaddress).ismodified = true;
                _db.SaveChanges();
            }

            return View();
        }
      
    }
}