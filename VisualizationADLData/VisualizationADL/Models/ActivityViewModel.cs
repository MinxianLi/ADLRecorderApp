using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoSite.Models
{
    public class ActivityViewModel
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set;}
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public DateTime ActivityTime { get; set; }
        public string ActivityDescription { get; set; }
    }
}