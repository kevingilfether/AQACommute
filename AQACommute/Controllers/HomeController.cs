using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AQACommute.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThePoint()
        {
            return View();
        }

        public ActionResult LandingPage()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult SendFeedback()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Resources()
        {
            ViewBag.Message = "Your resource page.";

            return View();
        }

        public ActionResult PvPTransit()
        {
            return View();
        }

        public ActionResult ResourcesPage()
        {
            return View();
        }
    }
}