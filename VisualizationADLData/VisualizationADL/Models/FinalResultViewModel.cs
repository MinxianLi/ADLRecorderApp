using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoSite.Models
{
    public class FinalResultViewModel
    {
        public double ResultID { get; set; }
        public string ChosedAction { get; set; }
        public string TimeRecord { get; set; }
        public string LabeledAction { get; set; }
    }
}