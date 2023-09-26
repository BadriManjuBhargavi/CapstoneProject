using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogTrackerApplication;
using Capstone_project;

namespace Capstone_project.Controllers
{
    public class BlogInfoesController : Controller
    {
        private CapstoneprojectEntities1 db = new CapstoneprojectEntities1();

        // GET: BlogInfoes
        public ActionResult Index()
        {
            var blogInfoes = db.BlogInfoes.Include(b => b.EmpInfo);
            return View(blogInfoes.ToList());
        }

        // GET: BlogInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogInfo blogInfo = db.BlogInfoes.Find(id);
            if (blogInfo == null)
            {
                return HttpNotFound();
            }
            return View(blogInfo);
        }

        // GET: BlogInfoes/Create
        public ActionResult Create()
        {
            ViewBag.EmpEmailId = new SelectList(db.EmpInfoes, "EmailId", "Name");
            return View();
        }

        // POST: BlogInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,Title,Subject,DateOfCreation,BlogUrl,EmpEmailId")] BlogInfo blogInfo)
        {
            if (ModelState.IsValid)
            {
                db.BlogInfoes.Add(blogInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpEmailId = new SelectList(db.EmpInfoes, "EmailId", "Name", blogInfo.EmpEmailId);
            return View(blogInfo);
        }

        // GET: BlogInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogInfo blogInfo = db.BlogInfoes.Find(id);
            if (blogInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpEmailId = new SelectList(db.EmpInfoes, "EmailId", "Name", blogInfo.EmpEmailId);
            return View(blogInfo);
        }

        // POST: BlogInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,Title,Subject,DateOfCreation,BlogUrl,EmpEmailId")] BlogInfo blogInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpEmailId = new SelectList(db.EmpInfoes, "EmailId", "Name", blogInfo.EmpEmailId);
            return View(blogInfo);
        }

        // GET: BlogInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogInfo blogInfo = db.BlogInfoes.Find(id);
            if (blogInfo == null)
            {
                return HttpNotFound();
            }
            return View(blogInfo);
        }

        // POST: BlogInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogInfo blogInfo = db.BlogInfoes.Find(id);
            db.BlogInfoes.Remove(blogInfo);
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