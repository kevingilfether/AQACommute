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
    public class TransportMethodsController : Controller
    {
        private AQACommuteDBEntities db = new AQACommuteDBEntities();

        // GET: TransportMethods
        public ActionResult Index()
        {
            var transportMethods = db.TransportMethods.Include(t => t.Make1).Include(t => t.Model1).Include(t => t.Option).Include(t => t.Year1);
            return View(transportMethods.ToList());
        }

        // GET: TransportMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportMethod transportMethod = db.TransportMethods.Find(id);
            if (transportMethod == null)
            {
                return HttpNotFound();
            }
            return View(transportMethod);
        }

        // GET: TransportMethods/Create
        public ActionResult Create()
        {
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "MakeName");
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "ModelName");
            ViewBag.OptionID = new SelectList(db.Options, "OptionID", "OptionName");
            ViewBag.YearID = new SelectList(db.Years, "YearID", "Year1");
            return View();
        }

        // POST: TransportMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportMethodID,TransportMode,TransportClass,AvgMPG,CityMPG,HwyMPG,CO2Lbs,MakeID,ModelID,YearID,OptionID,Make,Model,Year,Options")] TransportMethod transportMethod)
        {
            if (ModelState.IsValid)
            {
                transportMethod.TransportMode = "Automobile";
                db.TransportMethods.Add(transportMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "MakeName", transportMethod.MakeID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "ModelName", transportMethod.ModelID);
            ViewBag.OptionID = new SelectList(db.Options, "OptionID", "OptionName", transportMethod.OptionID);
            ViewBag.YearID = new SelectList(db.Years, "YearID", "Year1", transportMethod.YearID);
            return View(transportMethod);
        }

        // GET: TransportMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportMethod transportMethod = db.TransportMethods.Find(id);
            if (transportMethod == null)
            {
                return HttpNotFound();
            }
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "MakeName", transportMethod.MakeID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "ModelName", transportMethod.ModelID);
            ViewBag.OptionID = new SelectList(db.Options, "OptionID", "OptionName", transportMethod.OptionID);
            ViewBag.YearID = new SelectList(db.Years, "YearID", "Year1", transportMethod.YearID);
            return View(transportMethod);
        }

        // POST: TransportMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportMethodID,TransportMode,TransportClass,AvgMPG,CityMPG,HwyMPG,CO2Lbs,MakeID,ModelID,YearID,OptionID,Make,Model,Year,Options")] TransportMethod transportMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MakeID = new SelectList(db.Makes, "MakeID", "MakeName", transportMethod.MakeID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "ModelName", transportMethod.ModelID);
            ViewBag.OptionID = new SelectList(db.Options, "OptionID", "OptionName", transportMethod.OptionID);
            ViewBag.YearID = new SelectList(db.Years, "YearID", "Year1", transportMethod.YearID);
            return View(transportMethod);
        }

        // GET: TransportMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportMethod transportMethod = db.TransportMethods.Find(id);
            if (transportMethod == null)
            {
                return HttpNotFound();
            }
            return View(transportMethod);
        }

        // POST: TransportMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportMethod transportMethod = db.TransportMethods.Find(id);
            db.TransportMethods.Remove(transportMethod);
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
