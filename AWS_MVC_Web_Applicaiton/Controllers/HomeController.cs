﻿using System.Web.Mvc;

namespace AWS_MVC_Web_Applicaiton.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Links()
        {
            return View();
        }
    }
}