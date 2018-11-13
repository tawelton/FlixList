using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class UserMovie
    {
        public Movie movie { get; set; }
        public string[] locations { get; set; }

        public UserMovie(Movie movie, string[] locations)
        {
            this.movie = movie;
            this.locations = locations;
        }
    }
}