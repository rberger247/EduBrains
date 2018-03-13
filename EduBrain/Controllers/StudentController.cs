using EduBrain.Models;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduBrain.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report(Student student)
        {
        //    var writer = new PdfWriter("filepath");
        //    var pdf = new PdfDocument(writer);
        //    var document = new Document(pdf);
        //    document.Add(new Paragraph("Hello World!"));
            //document.Close();
       
            return View();
        }
    }
}