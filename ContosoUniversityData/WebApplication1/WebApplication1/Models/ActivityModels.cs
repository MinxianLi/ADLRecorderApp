using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ActivityModels
    {
        [Key]
        public string id { get; set; }
        public string Username { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Action { get; set; }
        public string ActionPic { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string WiFi { get; set; }
    }

    public class ActivityDBContext : DbContext
    {
        public DbSet<ActivityModels> ActivityModels { get; set; }
    }

}