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

        private EduSmart_dbEntities _db = new EduSmart_dbEntities();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Class(int? teacherId)
        {
            var teacher = _db.sp_SelectTeacherClasses(teacherId);
              
            //    var pdf = new PdfDocument(writer);
            //    var document = new Document(pdf);
            //    document.Add(new Paragraph("Hello World!"));
            //document.Close();

            return View();
        }
    }
}