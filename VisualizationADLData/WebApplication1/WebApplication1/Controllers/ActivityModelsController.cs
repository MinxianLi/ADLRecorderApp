using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ActivityModelsController : Controller
    {
        private ActivityDBContext db = new ActivityDBContext();

        // GET: ActivityModels
        public ActionResult Index()
        {
            return View(db.ActivityModels.OrderByDescending(p => p.Date).ThenByDescending(p => p.Time).ToList());
        }

        // GET: ActivityModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityModels activityModels = db.ActivityModels.Find(id);
            if (activityModels == null)
            {
                return HttpNotFound();
            }
            return View(activityModels);
        }

        // GET: ActivityModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivityModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Username,Longitude,Latitude,Action,ActionPic,Date,Time,WiFi")] ActivityModels activityModels)
        {
            if (ModelState.IsValid)
            {
                db.ActivityModels.Add(activityModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activityModels);
        }

        // GET: ActivityModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityModels activityModels = db.ActivityModels.Find(id);
            if (activityModels == null)
            {
                return HttpNotFound();
            }
            return View(activityModels);
        }

        // POST: ActivityModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Username,Longitude,Latitude,Action,ActionPic,Date,Time,WiFi")] ActivityModels activityModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activityModels);
        }

        // GET: ActivityModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityModels activityModels = db.ActivityModels.Find(id);
            if (activityModels == null)
            {
                return HttpNotFound();
            }
            return View(activityModels);
        }

        // POST: ActivityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ActivityModels activityModels = db.ActivityModels.Find(id);
            db.ActivityModels.Remove(activityModels);
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
