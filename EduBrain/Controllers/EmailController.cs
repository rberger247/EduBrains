using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace EduBrain.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

    [HttpPost]
    public ActionResult Email(string model)
    {

            MailMessage mm = new MailMessage("RafiBerger613@gmail.com", "aberger@ytehouston.org");
            mm.Subject = "EduBrainz Email sender";
            mm.Body = "This was sent from the eduBrainz app. Who would you like the sender of the email to be (what emailAddress)?";
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("Rafiberger613@gmail.com", "Statistics24790");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "mail Has been sent";


            return View();
    }
    }
}