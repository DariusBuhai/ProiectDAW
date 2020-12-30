using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private ProiectDAW.Models.ApplicationDbContext db = new ProiectDAW.Models.ApplicationDbContext();

        public ActionResult Index(int id)
        {
            var product = db.Products.Find(id);
            ProductsController.CalculateProductFinalRating(product);
            var products = new List<Product>();
            products.Add(product);
            ViewBag.Products = products;
            return View();
        }

    }
}
