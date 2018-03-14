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

            var doc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();
            doc.Add(new Paragraph("Dear Mr " + acceptanceLetterVm.LastName + "," +
                    " Congratulations on the acceptance of your son, " + acceptanceLetterVm.ChildFirstName + " into the " + acceptanceLetterVm.Grade + " grade" +
                    " we are excited to have " + acceptanceLetterVm.ChildFirstName + " in our school"));

            writer.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;

            MailMessage mm = new MailMessage("RafiBerger613@gmail.com", acceptanceLetterVm.EmailAdress)
            {
                Subject = " Congratulations on your childs acceptance into school",
                IsBodyHtml = false,
                Body = "Dear Mr " + acceptanceLetterVm.LastName + "," + 
                    " Congratulations on the acceptance of your son, " + acceptanceLetterVm.ChildFirstName + " into the " + acceptanceLetterVm.Grade + " grade" +
                    " we are excited to have " + acceptanceLetterVm.ChildFirstName +  " in our school"
            };

            mm.Attachments.Add(new Attachment(memoryStream, "AcceptanceLetter.pdf"));
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("Rafiberger613@gmail.com", "")

            };

            smtp.Send(mm);


            //MailMessage message = new MailMessage("RafiBerger613@gmail.com", "RafiBerger613@gmail.com");
            //    message.Subject = "EduBrainz Email sender";




            //    message.Body = ;



            //message.IsBodyHtml = false;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.EnableSsl = true;
            //NetworkCredential nc = new NetworkCredential("Rafiberger613@gmail.com", "");
            //smtp.UseDefaultCredentials = true;
            //smtp.Credentials = nc;
            //message.Attachments.Add(new Attachment(output.ToString()));
            //smtp.Send(message);

            //doc.Close();

            return View();
        }
            // If we got this far, something failed, redisplay form

            //    var writer = new PdfWriter(@"C:\Users\Rafib\OneDrive\Documents/hello_world.pdf");
            //var pdf = new PdfDocument(writer);
            //var document = new Document(pdf);
            //document.Add(new Paragraph("Hello World!"));
            //document.Close();

            //ViewBag.Message = "mail Has been sent";


    }
    }
