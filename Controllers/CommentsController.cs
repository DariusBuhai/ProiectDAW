using System;
using ProiectDAW.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class CommentsController : Controller
    {
        private ProiectDAW.Models.ApplicationDbContext db = new ProiectDAW.Models.ApplicationDbContext();

        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Comment comm = db.Comments.Find(id);
            db.Comments.Remove(comm);
            db.SaveChanges();
            return Redirect("/Products/Show/" + comm.ProductId);
        }

        [HttpPost]
        public ActionResult New(Comment comm)
        {
            comm.Date = DateTime.Now;
            try
            {
                db.Comments.Add(comm);
                db.SaveChanges();
                return Redirect("/Products/Show/" + comm.ProductId);
            }

            catch (Exception e)
            {
                return Redirect("/Products/Show/" + comm.ProductId);
            }

        }

        public ActionResult Edit(int id)
        {
            Comment comm = db.Comments.Find(id);
            return View(comm);
        }

        [HttpPut]
        public ActionResult Edit(int id, Comment requestComment)
        {
            try
            {
                Comment comm = db.Comments.Find(id);
                if (TryUpdateModel(comm))
                {
                    comm.Content = requestComment.Content;
                    comm.Rating = requestComment.Rating;
                    comm.Date = DateTime.Now;
                    db.SaveChanges();
                }
                return Redirect("/Products/Show/" + comm.ProductId);
            }
            catch (Exception e)
            {
                return View();
            }

        }


    }
}