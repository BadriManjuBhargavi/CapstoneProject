using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogTrackerApplication;

namespace BlogTrackerApplication.Controllers
{
    public class EmpInfoesController : Controller
    {
        private CapstoneprojectEntities1 db = new CapstoneprojectEntities1();

        // GET: EmpInfoes
        public ActionResult Index()
        {
            return View(db.EmpInfoes.ToList());
        }

        // GET: EmpInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpInfo empInfo = db.EmpInfoes.Find(id);
            if (empInfo == null)
            {
                return HttpNotFound();
            }
            return View(empInfo);
        }

        // GET: EmpInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailId,Name,DateOfJoining,PassCode")] EmpInfo empInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmpInfoes.Add(empInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empInfo);
        }

        // GET: EmpInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpInfo empInfo = db.EmpInfoes.Find(id);
            if (empInfo == null)
            {
                return HttpNotFound();
            }
            return View(empInfo);
        }

        // POST: EmpInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailId,Name,DateOfJoining,PassCode")] EmpInfo empInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empInfo);
        }

        // GET: EmpInfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpInfo empInfo = db.EmpInfoes.Find(id);
            if (empInfo == null)
            {
                return HttpNotFound();
            }
            return View(empInfo);
        }

        // POST: EmpInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmpInfo empInfo = db.EmpInfoes.Find(id);
            db.EmpInfoes.Remove(empInfo);
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
