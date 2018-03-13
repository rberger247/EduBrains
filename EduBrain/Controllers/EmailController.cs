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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
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
    public ActionResult Email(AcceptanceLetterVm acceptanceLetterVm)
    {
            if (ModelState.IsValid)
            {
                // do your stuff like: save to database and redirect to required page.
                Student student = new Student();
                Person person = new Person();

           


            }

            // If we got this far, something failed, redisplay form

            var writer = new PdfWriter(@"C:\Users\Rafib\OneDrive\Documents/hello_world.pdf");
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            document.Add(new Paragraph("Hello World!"));
            document.Close();

            MailMessage mm = new MailMessage("", "");
            mm.Subject = "EduBrainz Email sender";
        


           
            mm.Body = "Dear Mr " + acceptanceLetterVm.LastName + 
                " Congratulations on the acceptance of your  son, " + acceptanceLetterVm.ChildFirstName + " into Grade " + acceptanceLetterVm.Grade;



            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("Rafiberger613@gmail.com", "");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            mm.Attachments.Add(new Attachment(@"C:\Users\Rafib\OneDrive\Documents\hello_world.pdf"));
            smtp.Send(mm);
            ViewBag.Message = "mail Has been sent";


            return View();
    }
    }
}
