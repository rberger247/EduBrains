using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduBrain.Controllers
{
    public class ChildRegistrationController : Controller
    {
        // GET: RegisterChild
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}