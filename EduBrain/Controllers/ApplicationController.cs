using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduBrain.Models;
using EduBrain.ViewModels;

namespace EduBrain.Controllers
{


    public class ApplicationController : Controller
    {
        private EduSmart_dbEntities _db = new EduSmart_dbEntities();

        // GET: Application
        public ActionResult Index()
        {

            return View();
        }

        [Authorize]
        public ActionResult Application()
        {

          var currentUserEmail = User.Identity.Name;
            if (_db.ApplicantPersons.Any(u => u.EmailAddress == currentUserEmail))
            {
                var applicant = new ApplicantPerson { EmailAddress = User.Identity.Name };
                _db.ApplicantPersons.Attach(applicant);
                _db.Entry(applicant).Property(x => x.EmailAddress).IsModified = true;
                _db.SaveChanges();
            }


            var familyMembers =   _db.sp_ApplicantFamily_SelectFamilyMembers(User.Identity.Name).ToList();

       

            List<ApplicantVm> applicantVmList = new List<ApplicantVm>();
            ApplicantVm applicantVm = new ApplicantVm();
            foreach (var child in familyMembers)
            {
                foreach ( var student in applicantVm.studentList)
                {
                    student.FirstName = child.FirstName;
                    
                }
              
            }
   
            return View(applicantVm);
        }
        public ActionResult ThankYou()
        {
            return View();
        }
    }
}