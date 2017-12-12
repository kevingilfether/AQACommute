using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AQACommute.Models;
using Newtonsoft.Json;

namespace AQACommute.Controllers
{
    public class CommutesController : Controller
    {
        public double mpg = 0;

        public double travelDistance = 0;
        public int travelDuration = 0;
        public double co2Calculation = 0;

        //properties for JSON controller
        public string DistanceInfo { get; set; }
        public string DurationInfo { get; set; }
        public double CO2Footprint { get; set; }

        private AQACommuteDBEntities db = new AQACommuteDBEntities();

        // GET: Commutes
        public ActionResult Index()
        {
            var commutes = db.Commutes.Include(c => c.TransportMethod);
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

            var commutes = db.Commutes.Include(c => c.TransportMethod);

            //personal comparisons to ...
            //*100 to make percentages easier

            double globalAvg = (commute.CO2GeneratedLbs / 51.28) * 100;
            double cuyahogaAvg = (commute.CO2GeneratedLbs / 73.98) * 100;
            double twenty30Avg = (commute.CO2GeneratedLbs / 41.3) * 100;

            globalAvg = Math.Round(globalAvg, 2);
            cuyahogaAvg = Math.Round(cuyahogaAvg, 2);
            twenty30Avg = Math.Round(twenty30Avg, 2);

            ViewBag.Global = globalAvg;
            ViewBag.CuyahogaCounty = cuyahogaAvg;
            ViewBag.Twenty30Goal = twenty30Avg;

            if (commute == null)
            {
                return HttpNotFound();
            }
            return View(commute);
        }

        // GET: Commutes/Create
        public ActionResult Create()
        {
            //Getting the dropdown menu to show all the vehicles by year, make, model, option, class
            //Like "2004 Toyota Sienna V6 Minivan"
            var carStrings = db.TransportMethods
                .OrderByDescending(q => q.TransportMethodID)
                .ToDictionary(q => q.TransportMethodID, q => q.Year + " " + q.Make + " " + q.Model + " " + q.TransportClass);
            ViewBag.TransportMethodID = new SelectList(carStrings, "Key", "Value");
            return View();
        }

        // POST: Commutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommuteID,CommuteTime,StartPoint,EndPoint,TotalMiles,CO2GeneratedLbs,TransportMethodID")] Commute commute)
        {
            if (ModelState.IsValid)
            {
                //vehicle MPG Avg
                var myMPG = from test in db.TransportMethods
                            where test.TransportMethodID == commute.TransportMethodID
                            select test.AvgMPG;

                //need to set test.TransportMethodID == identity column of TransportMethod or transport.TransportMethodID if possible.
                double mpgAvg = 0;

                foreach (var m in myMPG)
                {
                    mpgAvg = m;
                }

                //C02Footprint calculation
                if (travelDistance != 0)
                    commute.CO2GeneratedLbs = (travelDistance / mpgAvg) * 20;

                db.Commutes.Add(commute);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = commute.CommuteID });
            }
            var carStrings = db.TransportMethods
                .OrderByDescending(q => q.TransportMethodID)
                .ToDictionary(q => q.TransportMethodID, q => q.Year + " " + q.Make + " " + q.Model + " " + q.TransportClass);
            ViewBag.TransportMethodID = new SelectList(carStrings, "Key", "Value");

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
            var carStrings = db.TransportMethods
                .OrderBy(q => q.Year)
                .ToDictionary(q => q.TransportMethodID, q => q.Year + " " + q.Make + " " + q.Model + " " + q.TransportClass);
            ViewBag.TransportMethodID = new SelectList(carStrings, "Key", "Value");
            return View(commute);
        }

        // POST: Commutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommuteID,CommuteTime,StartPoint,EndPoint,TotalMiles,CO2GeneratedLbs,TransportMethodID")] Commute commute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportMethodID = new SelectList(db.TransportMethods, "TransportMethodID", "TransportMode", commute.TransportMethodID);
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

        //Map Function
        public JsonResult MapInfo(CommutesController distance)
        {
            string errorHandler = "Error with input value somewhere.";
            string tripDistance = distance.DistanceInfo;
            string tripDuration = distance.DurationInfo;
            if (tripDistance != null)
                travelDistance = double.Parse(tripDistance);
            if (tripDuration != null)
                travelDuration = int.Parse(tripDuration);
            //metric to imperial conversion
            travelDistance = travelDistance / 1609.34;

            //seconds to minutes conversion
            travelDuration = travelDuration / 60;

            //vehicle MPG Avg
            var myMPG = from car in db.TransportMethods
                        where car.TransportMethodID == car.TransportMethodID
                        select car.AvgMPG;

            //need to set test.TransportMethodID == identity column of TransportMethod or transport.TransportMethodID if possible.
            double mpgAvg = 0;

            foreach (var mpg in myMPG)
            {
                mpgAvg = mpg;
            }

            //C02Footprint calculation
            co2Calculation = (travelDistance / mpgAvg) * 20;
            return new JsonResult()
            {
                Data = JsonConvert.SerializeObject(co2Calculation),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }

}
