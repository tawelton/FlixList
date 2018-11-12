using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int movieID { get; set; }
        public string title { get; set; }
        public string duration { get; set; }
        public string posterURL { get; set; }

        public Movie(string title, string duration, string posterURL)
        {
            this.movieID = (title + duration).GetHashCode();
            this.title = title;
            this.duration = duration;
            this.posterURL = posterURL;
        }

    }
}