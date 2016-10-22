using ContosoSite.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoSite.Controllers
{
    public class PasteController : Controller
    {
        // GET: Paste
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Activity_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(Get_Activity().ToDataSourceResult(request));
        }

        private static IEnumerable<Paste> Get_Activity()
        {
            var db = new ContosoUniversityDataEntities();
            return db.Pastes.ToList();

        }

        public ActionResult Copy(int Id, float light, float xAcce, float yAcce, float zAcce, float angle, float azimuth, float pitch, float roll, float latitude, float longtitude, float altitude, float hour, float moving, float turning, float lightChanging, float dark, float accel, float status, float screenOn, float earPlug, float sound, string activity)
        {
             var db2 = new ContosoUniversityDataEntities();
            db2.CopyPaste(Id, light, xAcce, yAcce, zAcce, angle, azimuth, pitch, roll, latitude, longtitude, altitude, hour, moving, turning, lightChanging, dark, accel, status, screenOn, earPlug, sound, activity);
            return RedirectToAction("Index", "Paste");
        }
    }
}