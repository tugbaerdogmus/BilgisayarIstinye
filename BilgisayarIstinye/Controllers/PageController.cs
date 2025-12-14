using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgisayarIstinye.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult ServiceDetail(int id)
        {
            return View();
        }
    }
}