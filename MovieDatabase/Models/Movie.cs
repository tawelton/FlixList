using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Movie
    {
        [Key]
        public int movieID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string rating { get; set; }
        public string duration { get; set; }
        public string posterURL { get; set; }
        public string imdbURL { get; set; }
    }
}