using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class UserMovie
    {
        public Movie movie { get; set; }
        public List<Location> locations { get; set; }

        public UserMovie()
        {
            locations = new List<Location>();
        } 
        public UserMovie (Movie mMovie, List<Location> lLocations)
        {
            movie = mMovie;
            locations = lLocations;
        }
    }
}