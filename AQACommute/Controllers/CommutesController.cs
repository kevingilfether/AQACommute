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
        
        private AQACommuteDBEntities db = new AQACommuteDBEntities();

        double help = 55;

        // GET: Commutes
        public ActionResult Index()
        {
            

            var commutes = db.Commutes.Include(c => c.TransportMethod);

            //var misplaced = db.Commutes.Include(c => c.CO2GeneratedLbs);

            //var wow = from test in db.Commutes
            //            where test.CommuteID == test.CommuteID
            //            select test.CO2GeneratedLbs;

            //double lala;

            //foreach (var lbs in wow)
            //{
            //    lala = lbs;
            //}

            ViewBag.CuyahogaCounty = VBPopulate(help);
            ViewBag.CuyahogaCounty = "Your C02 footprint is 10.21% of Cuyahoga County's";

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
                //        //vehicle MPG Avg


                //        var myMPG = from test in db.TransportMethods
                //                    where test.TransportMethodID == test.TransportMethodID
                //                    select test.AvgMPG;

                //        //need to set test.TransportMethodID == identity column of TransportMethod or transport.TransportMethodID if possible.

                //        double mpgAvg = 0;

                //        foreach (var mpg in myMPG)
                //        {
                //            mpgAvg = mpg;
                //        }

                //        //C02Footprint calculation

                //        double d2 = 0;

                //        if (commute.TotalMiles.HasValue)
                //        { d2 = (double)commute.TotalMiles; }



                //        commute.CO2GeneratedLbs = (d2 / mpgAvg) * 20;
                //        //test = commute.CO2GeneratedLbs;

                //        //commute.CO2GeneratedLbs = (100 / mpgAvg) * 20;

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


        public double VBPopulate(double seeya)
        {
            //vehicle MPG Avg

            double okay;
            Commute newCommute = new Commute();


            var myMPG = from test in db.Commutes
                        where test.CommuteID == test.CommuteID
                        select test.CO2GeneratedLbs;

            //need to set test.TransportMethodID == identity column of TransportMethod or transport.TransportMethodID if possible.

            double mpgAvg = 0;

            foreach (var mpg in myMPG)
            {
                mpgAvg = mpg;
            }

            ////C02Footprint calculation

            double d2 = 0;

            if (newCommute.TotalMiles.HasValue)
            { d2 = (double)newCommute.TotalMiles; }

            newCommute.CO2GeneratedLbs = (d2 / mpgAvg) * 20;
            okay = newCommute.CO2GeneratedLbs;

            return okay;

       
        }

    }
}
