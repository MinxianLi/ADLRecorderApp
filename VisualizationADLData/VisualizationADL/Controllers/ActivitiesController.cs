using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoSite.Models;
using System.Data.Entity.Core.Objects;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace ContosoSite.Controllers
{
    public class ActivitiesController : Controller
    {
        private ContosoUniversityDataEntities db = new ContosoUniversityDataEntities();
        private readonly ContosoUniversityDataEntities dbContext;

        // GET: Activities
        public ActionResult Index()
        {
           // return View(db.Activities.Where(a => a.ActivityName.Contains("Sleeping")).ToList());
            return View(db.Activities.ToList());
        }

        public ContosoUniversityDataEntities DbContext
        {
            get
            {
                return dbContext;
            }
        }

        public ActivitiesController()
        {
            dbContext = new ContosoUniversityDataEntities();
        }



        public ActionResult FilterTable(string activityName, string searchString)
        {
            var activityNameLst = new List<string>();

            var activtyNameQry = from d in db.Activities
                                 orderby d.ActivityName
                                 select d.ActivityName;

            activityNameLst.AddRange(activtyNameQry.Distinct());
            ViewBag.activityName = new SelectList(activityNameLst);

            var activities = from a in db.Activities
                             select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    activities = activities.Where(s => s.ActivityName.ToUpper().Contains(searchString.ToUpper())
                                           || s.ActivityDescription.ToUpper().Contains(searchString.ToUpper()));
                }
            }

            if (!string.IsNullOrEmpty(activityName))
            {
                activities = activities.Where(x => x.ActivityName == activityName);
            }

            return View(activities.ToList());
        }

        public JsonResult JsonView()
        {
            var data = db.Activities.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CallAnotherProjectView()
        {
            return Redirect("http://localhost:54107/activitymodels");
        }

        public ActionResult Record1(string activityName, string searchString)
        {
            var activityNameLst = new List<string>();

            var activtyNameQry = from d in db.Record08030822
                                 orderby d.Action
                                 select d.Action;

            activityNameLst.AddRange(activtyNameQry.Distinct());
            ViewBag.activityName = new SelectList(activityNameLst);

            var activities = from a in db.Record08030822
                             select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    activities = activities.Where(s => s.Action.ToUpper().Contains(searchString.ToUpper())
                                           || s.Action.ToUpper().Contains(searchString.ToUpper()));
                }
            }

            if (!string.IsNullOrEmpty(activityName))
            {
                activities = activities.Where(x => x.Action == activityName);
            }

            return View(activities.ToList());
        }




        public ActionResult KendoUIGrid()
        {
            return View();
        }

        public ActionResult Activity_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(Get_Activity().ToDataSourceResult(request));
        }

        private static IEnumerable<Activity> Get_Activity()
        {
            var db = new ContosoUniversityDataEntities();
            return db.Activities.ToList();

        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            return File(fileContents, contentType, fileName);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ActivityViewModel activityViewModel)
        {
            //if (activityViewModel != null && this.ModelState.IsValid)
                if (activityViewModel != null )
            {
                activityViewModel.ActivityID = this.SaveData(activityViewModel);
            }

            return this.Json(new[] { activityViewModel }.ToDataSourceResult(request, ModelState));
        }



        private int SaveData(ActivityViewModel activityViewModel)
        {
            try
            {
               
                Activity activity = this.DbContext.Activities.FirstOrDefault(i => i.ActivityID == activityViewModel.ActivityID);

                if (activity == null)
                {
                    activity = new Activity
                    {
                        ActivityID = activityViewModel.ActivityID,
                        ActivityName = activityViewModel.ActivityName,
                        ActivityTime = activityViewModel.ActivityTime,
                        ActivityDescription = activityViewModel.ActivityDescription,
                        Latitude = activityViewModel.Latitude,
                        Longitude = activityViewModel.Longtitude,
                       
                    };

                    this.DbContext.Activities.Add(activity);
                    //this.DbContext.GetWeekSchedule(Convert.ToDateTime("2016-09-09")).Where(i => i.Tuesday == weekScheduleModel.Tuesday);
                }
                else
                {
                    activity.ActivityID = activityViewModel.ActivityID;
                    activity.ActivityName = activityViewModel.ActivityName;
                    activity.ActivityTime = activityViewModel.ActivityTime;
                    activity.ActivityDescription = activityViewModel.ActivityDescription;
                    activity.Latitude = activityViewModel.Latitude;
                    activity.Longitude = activityViewModel.Longtitude;
                    
                }

                // save change
                this.DbContext.SaveChanges();

                return activity.ActivityID;
            }
            catch (Exception ex)
            {
                //this.Logger.Error(ex);
                throw ex;
            }
        }











        public ActionResult TestTable()

        {
            DateTime datetime = Convert.ToDateTime("08/23/2016");
            if (datetime.TimeOfDay != TimeSpan.Zero)
            {
                return View(db.Activities.Where(a => a.ActivityTime == datetime).ToList());
            }
            else
            {
                DateTime plusOneDateTime = datetime.AddDays(1).Date;
                return View(db.Activities.Where(a => a.ActivityTime >= datetime.Date && a.ActivityTime < plusOneDateTime));
            }

        }

        public ActionResult enterIntInput()
        {
            return View();
        }
        
        public ActionResult getIntInput(int valueGet)
        {
            return RedirectToAction("NullTest", "Activities", new { inputTest = valueGet });
        }


        public ActionResult NullTest(int inputTest)
        {
            //inputTest = 3;
            try
            {
                
                return View(db.Activities.Where(a => a.ActivityID == inputTest).ToList());
            }


            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ShowDateTable(DateTime activityStartTime2, DateTime activityEndTime2)
        {
            //try
            //{
            //    using (var dbShowDate = new ContosoUniversityDataEntities())
            //    {

            //        return View(dbShowDate.Activities.Where(a => a.ActivityTime.Value >= activityStartTime2 & a.ActivityTime <= activityEndTime2).ToList());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Content("this not correct");
            //}


            return View(db.Activities.Where(a => a.ActivityTime >= activityStartTime2 && a.ActivityTime <= activityEndTime2).ToList());
        }

        public ActionResult ShowDateTableInit()
        {
            return View(db.Activities.ToList());
        }

        public ActionResult PickDate()
        {
            return View();
        }

        public ActionResult AmMap()
        {
            return View();
        }

        public ActionResult AmStock()
        {
            return View();
        }

        public ActionResult AmPie()
        {
            ViewBag.ChattingNumber = db.Activities.Where(a => a.ActivityName == "Chatting").Count();
            ViewBag.EatingNumber = db.Activities.Where(a => a.ActivityName == "Eating").Count();
            ViewBag.SleepingNumber = db.Activities.Where(a => a.ActivityName == "Sleeping").Count();
            return View();
        }

        public ActionResult AmBar()
        {
            ViewBag.ChattingNumber = db.Activities.Where(a => a.ActivityName == "Chatting").Count();
            ViewBag.EatingNumber = db.Activities.Where(a => a.ActivityName == "Eating").Count();
            ViewBag.SleepingNumber = db.Activities.Where(a => a.ActivityName == "Sleeping").Count();
            return View();
        }



        public ActionResult KendoUI()
        {
            return View();
        }

        public ActionResult VisitedStates()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult Map2()
        {
            return View();
        }

        public ActionResult Ajax()
        {
            return Content("success");
        }

        public ActionResult AjaxText(string text)
        {
            if (text == "test")
            {
                return Content("test");
            }
            else
            {
                return Content("fail");
            }
        }

        //AJAX Submit date
        public int AjaxDate(DateTime activityStartTime, DateTime activityEndTime)
        {
            try
            {
                using (var dbPickDate = new ContosoUniversityDataEntities())
                {
                  
                    return dbPickDate.Activities.Where(a => a.ActivityTime >= activityStartTime & a.ActivityTime <= activityEndTime).Count();
                }
            }
            catch (Exception ex)
            {
                return 10;
            }
        }


        public int CountActivity(string activityname)
        {
            using (var dbCount = new ContosoUniversityDataEntities())
            {
                return dbCount.Activities.Where(a => a.ActivityName == activityname).Count();
            }
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityID,ActivityName,ActivityTime,ActivityDescription")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityID,ActivityName,ActivityTime,ActivityDescription")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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
