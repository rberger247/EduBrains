using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using EduBrain.Models;
using EduBrain.ViewModels;
//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Core.Objects;
using Microsoft.AspNet.Identity;
//using iTextSharp.text.pdf;
//using iTextSharp.text;

//using iTextSharp.text.pdf;

namespace EduBrain.Controllers
{
    public class EmailController : Controller
    {

        private EduSmart_dbEntities _db = new EduSmart_dbEntities();
        // GET: Email


        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Apply(ApplicantVm applicantVm)
        {
            if (ModelState.IsValid)
            {
                // do your stuff like: save to database and redirect to required page.

                //check for current user by email


                //Set the output parameters
                ObjectParameter studentId = new ObjectParameter("ApplicantStudentId", typeof(int));
                ObjectParameter personId = new ObjectParameter("ApplicantStudentId", typeof(int));


                ObjectParameter applicantFatherId = new ObjectParameter("ApplicantFatherId", typeof(int));
                ObjectParameter applicantChildId = new ObjectParameter("ApplicantChildId", typeof(int));

                ObjectParameter applicantFamilyId = new ObjectParameter("ApplicantFamilyId", typeof(int));

                var date = DateTime.Today;


                //Execute stored procedure to add Father To person table 
                _db.sp_ApplicantPerson_AddPerson(applicantFatherId, applicantChildId, applicantFamilyId, User.Identity.Name,
                    applicantVm.FatherFirstName, applicantVm.Grade, applicantVm.LastName,
                 applicantVm.ChildFirstName, date);


                //             _db.sp_ApplicantStudent_AddStudent(studentId, CreatedId, applicantVm.ChildFirstName, 1);

                ApplicantParent applicantParent = new ApplicantParent();


            }

            var doc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();
            doc.Add(new Paragraph("Dear Mr " + applicantVm.LastName + "," +
                    " Congratulations on the acceptance of your son, " + applicantVm.ChildFirstName + " into the " + applicantVm.Grade + " grade" +
                    " we are excited to have " + applicantVm.ChildFirstName + " in our school"));

            writer.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;

            MailMessage mm = new MailMessage("RafiBerger613@gmail.com", applicantVm.EmailAdress)
            {
                Subject = " Congratulations on your childs acceptance into school",
                IsBodyHtml = true,
                Body = "Dear Mr " + applicantVm.LastName + "," + " <br/>" +
                    " <b>Congratulations </B> on the acceptance of your son, " + applicantVm.ChildFirstName + " into the " +
                 applicantVm.Grade + " grade." +
                    " We are excited to have " + applicantVm.ChildFirstName + " in our school. Attached below is a letter with important information about the upcoming class"
            };



            mm.Attachments.Add(new Attachment(memoryStream, "AcceptanceLetter.pdf"));
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("Rafiberger613@gmail.com", "Google#400")

            };

            // cc myself
            MailAddress copy = new MailAddress("RafiBerger613@gmail.com");

            mm.Bcc.Add(copy);

            smtp.Send(mm);
            return RedirectToAction("ThankYou", "Application");

        }



    }
}