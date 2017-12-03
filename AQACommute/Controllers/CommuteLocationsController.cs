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
    public class CommuteLocationsController : Controller
    {
        private AQACommuteDBEntities db = new AQACommuteDBEntities();

        // GET: CommuteLocations
        public ActionResult Index()
        {
            var commuteLocations = db.CommuteLocations.Include(c => c.Commute).Include(c => c.Location);
            return View(commuteLocations.ToList());
        }

        // GET: CommuteLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommuteLocation commuteLocation = db.CommuteLocations.Find(id);
            if (commuteLocation == null)
            {
                return HttpNotFound();
            }
            return View(commuteLocation);
        }

        // GET: CommuteLocations/Create
        public ActionResult Create()
        {
            ViewBag.CommuteID = new SelectList(db.Commutes, "CommuteID", "CommuteTime");
            ViewBag.LocationsID = new SelectList(db.Locations, "LocationsID", "LocationName");
            return View();
        }

        // POST: CommuteLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommuteLocationID,LocationsID,CommuteID")] CommuteLocation commuteLocation)
        {
            if (ModelState.IsValid)
            {
                db.CommuteLocations.Add(commuteLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommuteID = new SelectList(db.Commutes, "CommuteID", "CommuteTime", commuteLocation.CommuteID);
            ViewBag.LocationsID = new SelectList(db.Locations, "LocationsID", "LocationName", commuteLocation.LocationsID);
            return View(commuteLocation);
        }

        // GET: CommuteLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommuteLocation commuteLocation = db.CommuteLocations.Find(id);
            if (commuteLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommuteID = new SelectList(db.Commutes, "CommuteID", "CommuteTime", commuteLocation.CommuteID);
            ViewBag.LocationsID = new SelectList(db.Locations, "LocationsID", "LocationName", commuteLocation.LocationsID);
            return View(commuteLocation);
        }

        // POST: CommuteLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommuteLocationID,LocationsID,CommuteID")] CommuteLocation commuteLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commuteLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommuteID = new SelectList(db.Commutes, "CommuteID", "CommuteTime", commuteLocation.CommuteID);
            ViewBag.LocationsID = new SelectList(db.Locations, "LocationsID", "LocationName", commuteLocation.LocationsID);
            return View(commuteLocation);
        }

        // GET: CommuteLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommuteLocation commuteLocation = db.CommuteLocations.Find(id);
            if (commuteLocation == null)
            {
                return HttpNotFound();
            }
            return View(commuteLocation);
        }

        // POST: CommuteLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommuteLocation commuteLocation = db.CommuteLocations.Find(id);
            db.CommuteLocations.Remove(commuteLocation);
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
