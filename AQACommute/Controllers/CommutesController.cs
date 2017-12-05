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
        private AQACommuteDBEntities db = new AQACommuteDBEntities();


        //properties for JSON controller
        public string DistanceInfo { get; set; }
        public string DurationInfo { get; set; }
        public double CO2Footprint { get; set; }

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
            if (commute == null)
            {
                return HttpNotFound();
            }
            return View(commute);
        }

        // GET: Commutes/Create
        public ActionResult Create()
        {
            ViewBag.TransportMethodID = new SelectList(db.TransportMethods, "TransportMethodID", "TransportMode");
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
                            where test.TransportMethodID == test.TransportMethodID
                            select test.AvgMPG;

                //need to set test.TransportMethodID == identity column of TransportMethod or transport.TransportMethodID if possible.

                double mpgAvg = 0;

                foreach(var mpg in myMPG)
                {
                    mpgAvg = mpg;
                }

                //C02Footprint calculation

                double d2 = 0;

                if (commute.TotalMiles.HasValue)
                { d2 = (double)commute.TotalMiles; }

                commute.CO2GeneratedLbs = (d2 / mpgAvg) * 20;

                //commute.CO2GeneratedLbs = (100 / mpgAvg) * 20;

                db.Commutes.Add(commute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportMethodID = new SelectList(db.TransportMethods, "TransportMethodID", "TransportMode", commute.TransportMethodID);
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
            ViewBag.TransportMethodID = new SelectList(db.TransportMethods, "TransportMethodID", "TransportMode", commute.TransportMethodID);
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

        //Calc and map function
        public JsonResult CO2Calc(CommutesController distance)
        {
            string tripDistance = distance.DistanceInfo;
            //string tripDuration = distance.DurationInfo;
            string returnValue = tripDistance;
            if (ModelState.IsValid)
            {

            }
            return new JsonResult()
            {
                Data = JsonConvert.SerializeObject(returnValue),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
