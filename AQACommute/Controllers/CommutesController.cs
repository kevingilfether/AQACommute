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
    public class CommutesController : Controller
    {
        private AQAMvpEntities db = new AQAMvpEntities();

        // GET: Commutes
        public ActionResult Index()
        {
            var commutes = db.Commutes.Include(c => c.Vehicle);

            return View(commutes.ToList());
        }

        // GET: Commutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commute commute = db.Commutes.Find(id);
            if (commute == null)
            {
                return HttpNotFound();
            }
            return View(commute);
        }

        // GET: Commutes/Create
        public ActionResult Create()
        {
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "Make");

            return View();
        }

        // POST: Commutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommuteID,DistanceTraveled,CommuteTimeSpent,CommuteTimeEnd,C02Footprint,VehicleID")] Commute commute)
        {

            //Vehicle vehicle = new Vehicle();

            //vehicle.MPGAvg = (vehicle.MPGCity + vehicle.MPGHwy) / 2;

            //commute.C02Footprint = (commute.DistanceTraveled / vehicle.MPGAvg) * 20;

            if (ModelState.IsValid)
            {
                

                
                

                /*vehicle.MPGAvg*/ 
                var myMPG = from test in db.Vehicles
                            where test.VehicleID == commute.VehicleID
                            //orderby test.MPGAvg ascending
                            select test.MPGAvg;

                double testCalc = 0;

                foreach(var mpg in myMPG)
                {
                    testCalc = mpg;
                }
               

                //vehicle.MPGAvg = myMPG;

                //string see = myMPG.ToString();

                //double moreHope = Convert.ToDouble(see)   try TryParse;

                //double hope = double.Parse(see);

                //Vehicle vehicle = new Models.Vehicle(testCalc);

                commute.C02Footprint = (commute.DistanceTraveled / testCalc) * 20;

                //Try as function instead


                db.Commutes.Add(commute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //in html - make the C02Footprint field invisible or...remove it from the HTML and from the above commute object)

            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "Make", commute.VehicleID);
            return View(commute);
        }

        // GET: Commutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commute commute = db.Commutes.Find(id);
            if (commute == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "Make", commute.VehicleID);
            return View(commute);
        }

        // POST: Commutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommuteID,DistanceTraveled,CommuteTimeSpent,CommuteTimeEnd,C02Footprint,VehicleID")] Commute commute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "Make", commute.VehicleID);
            return View(commute);
        }

        // GET: Commutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commute commute = db.Commutes.Find(id);
            if (commute == null)
            {
                return HttpNotFound();
            }
            return View(commute);
        }

        // POST: Commutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commute commute = db.Commutes.Find(id);
            db.Commutes.Remove(commute);
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

//db.Commutes.Add(commute);
//                db.SaveChanges();
//                return RedirectToAction("Index");