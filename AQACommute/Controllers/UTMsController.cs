using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AQACommute.Models;

namespace AQACommute.Controllers
{
    public class UTMsController : Controller
    {
        private AQACommuteDBEntities db = new AQACommuteDBEntities();

        // GET: UTMs
        public ActionResult Index()
        {
            var uTMs = db.UTMs.Include(u => u.TransportMethod).Include(u => u.UTM1).Include(u => u.UTM2).Include(u => u.AspNetUser);
            return View(uTMs.ToList());
        }

        // GET: UTMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTM uTM = db.UTMs.Find(id);
            if (uTM == null)
            {
                return HttpNotFound();
            }
            return View(uTM);
        }

        // GET: UTMs/Create
        public ActionResult Create()
        {
            ViewBag.TransportMethodID = new SelectList(db.TransportMethods, "TransportMethodID", "TransportMode");
            ViewBag.UTMID = new SelectList(db.UTMs, "UTMID", "UserID");
            ViewBag.UTMID = new SelectList(db.UTMs, "UTMID", "UserID");
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: UTMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UTMID,UserID,TransportMethodID")] UTM uTM)
        {
            if (ModelState.IsValid)
            {
                db.UTMs.Add(uTM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportMethodID = new SelectList(db.TransportMethods, "TransportMethodID", "TransportMode", uTM.TransportMethodID);
            ViewBag.UTMID = new SelectList(db.UTMs, "UTMID", "UserID", uTM.UTMID);
            ViewBag.UTMID = new SelectList(db.UTMs, "UTMID", "UserID", uTM.UTMID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", uTM.UserID);
            return View(uTM);
        }

        // GET: UTMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTM uTM = db.UTMs.Find(id);
            if (uTM == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportMethodID = new SelectList(db.TransportMethods, "TransportMethodID", "TransportMode", uTM.TransportMethodID);
            ViewBag.UTMID = new SelectList(db.UTMs, "UTMID", "UserID", uTM.UTMID);
            ViewBag.UTMID = new SelectList(db.UTMs, "UTMID", "UserID", uTM.UTMID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", uTM.UserID);
            return View(uTM);
        }

        // POST: UTMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UTMID,UserID,TransportMethodID")] UTM uTM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uTM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportMethodID = new SelectList(db.TransportMethods, "TransportMethodID", "TransportMode", uTM.TransportMethodID);
            ViewBag.UTMID = new SelectList(db.UTMs, "UTMID", "UserID", uTM.UTMID);
            ViewBag.UTMID = new SelectList(db.UTMs, "UTMID", "UserID", uTM.UTMID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", uTM.UserID);
            return View(uTM);
        }

        // GET: UTMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTM uTM = db.UTMs.Find(id);
            if (uTM == null)
            {
                return HttpNotFound();
            }
            return View(uTM);
        }

        // POST: UTMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UTM uTM = db.UTMs.Find(id);
            db.UTMs.Remove(uTM);
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
