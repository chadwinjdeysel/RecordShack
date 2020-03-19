using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.Controllers
{
    public class HomeController : Controller
    {
        RecordShackCMSEntities context = new RecordShackCMSEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}