﻿using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class ProductsController : Controller
    {
        private Models.AppContext db = new Models.AppContext();
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products;
            ViewBag.Products = products;
            return View();
        }
        // Get: Product
        public ActionResult View(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        // Get: New
        public ActionResult New()
        {
            Product product = new Product();
            // preluam lista de categorii din metoda GetAllCategories()
            product.AllCategories = GetAllCategories();
            return View(product);
        }
        // Post: New
        [HttpPost]
        public ActionResult New(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                TempData["message"] = "Articolul a fost adaugat!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                db.Products.Remove(db.Products.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
        // Get: Edit
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            product.AllCategories = GetAllCategories();
            return View(product);
        }
        // Put: Edit
        [HttpPut]
        public ActionResult Edit(int id, Product requestProduct)
        {
            try
            {
                Product product = db.Products.Find(id);
                if (TryUpdateModel(product))
                {
                    product = requestProduct;
                    db.SaveChanges();
                    TempData["message"] = "Produsul a fost editat";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public IEnumerable<SelectListItem> GetAllCategories()
        {
            // generam o lista goala
            var selectList = new List<SelectListItem>();
            // extragem toate categoriile din baza de date
            var categories = from cat in db.Categories
                             select cat;
            // iteram prin categorii
            foreach (var category in categories)
            {
                // adaugam in lista elementele necesare pentru dropdown
                selectList.Add(new SelectListItem
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.CategoryName.ToString()
                });
            }
            // returnam lista de categorii
            return selectList;
        }
    }
}