using System;
using ProiectDAW.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    [Authorize(Roles = "Admin,Editor,User")]
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
            ViewBag.Comment = comm;
            return View();
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