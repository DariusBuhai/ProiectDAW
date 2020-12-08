using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    [Authorize(Roles = "Admin,User,Editor")]
    public class OrdersController : Controller
    {
        private ProiectDAW.Models.ApplicationDbContext db = new ProiectDAW.Models.ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Basket()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

    }
}
