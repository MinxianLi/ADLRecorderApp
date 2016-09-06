using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class InOneController : Controller
    {                                                                                                       
        // GET: InOne
        //http://localhost:54107/InOne/
        public ActionResult Index()
        {

            return View();
        }

        // GET: InOne/AllInOne
        //http://localhost:54107/InOne/AllInOne
        public ActionResult AllInOne()
        {
            ViewBag.Username = "Phil";
            ViewBag.Date = "2016-08-22";
            ViewBag.Time = "19:59:28";
            ViewBag.Action = "Moving constantly, and then Same place, Sitting,";
            ViewBag.Location = "att740+";
            ViewBag.Longitude = "42.03";
            ViewBag.Latitude = "-93.63";

            return View();
        }

        public string getActionListAjax()
        {
           /*
           StringBuilder myStringBuilder = new StringBuilder("");

            * 
            * string[] actionList = new string[] { "night", "cook", "stand", "p1" };
           foreach (string i in actionList)
           {
               myStringBuilder.Append(i+',');
           }
            return myStringBuilder.ToString();
            */
            return "Moving constantly, and then Same place, Sitting,";
        }
    }
}