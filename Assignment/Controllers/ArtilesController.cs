using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Week8LoginDemo.Models;

namespace Week8LoginDemo.Controllers
{
    [Authorize]
    public class ArtilesController : Controller
    {
        private Entities db = new Entities();

        // GET: Artiles
        public ActionResult Index()
        {
            return View(db.Artiles.ToList());
        }

        // GET: Artiles
        public ActionResult IndexUserNames()
        {
            //return View(db.Artiles.ToList());
            string currentUserId = User.Identity.GetUserId();
            return View(db.Artiles.Where(m=> m.AuthorId == currentUserId).ToList());
        }
        // GET: Artiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artile artile = db.Artiles.Find(id);
            if (artile == null)
            {
                return HttpNotFound();
            }
            return View(artile);
        }

        // GET: Artiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Artiles/Create
        public ActionResult CreateIndividual()
        {
            Artile artile = new Artile();
            string currentUserId = User.Identity.GetUserId();
            artile.AuthorId = currentUserId;
            return View(artile);
        }
        // POST: Artiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIndividual([Bind(Include = "NewsId,AuthorId,ArticleText")] Artile artile)
        {
            if (ModelState.IsValid)
            {
                db.Artiles.Add(artile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artile);
        }



        // POST: Artiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsId,AuthorId,ArticleText")] Artile artile)
        {
            if (ModelState.IsValid)
            {
                db.Artiles.Add(artile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artile);
        }

        // GET: Artiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artile artile = db.Artiles.Find(id);
            if (artile == null)
            {
                return HttpNotFound();
            }
            return View(artile);
        }

        // POST: Artiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,AuthorId,ArticleText")] Artile artile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artile);
        }

        // GET: Artiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artile artile = db.Artiles.Find(id);
            if (artile == null)
            {
                return HttpNotFound();
            }
            return View(artile);
        }

        // POST: Artiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artile artile = db.Artiles.Find(id);
            db.Artiles.Remove(artile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
