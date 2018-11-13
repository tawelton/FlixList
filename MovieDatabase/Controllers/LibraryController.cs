using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieDatabase.Controllers
{
    public class LibraryController : Controller
    {
        public static List<UserMovie> userLibrary = new List<UserMovie> {
            new UserMovie( 
                new Movie("Harry Potter", "2:05", "https://images-na.ssl-images-amazon.com/images/I/51cKvT6lcaL.jpg"),
                new string[] { "https://s3.amazonaws.com/freebiesupply/large/2x/hulu-logo-white.png", "http://www.logosvectorfree.com/wp-content/uploads/2017/12/Netflix-Logo-Icons-png.png", "https://mbtskoudsalg.com/images/amazon-instant-video-png.png" } 
                )
        };

        // GET: MyLibrary
        public ActionResult MyLibrary()
        {
            List<Movie> testMovie = new List<Movie> { new Movie("Harry Potter", "2:05", "https://images-na.ssl-images-amazon.com/images/I/51cKvT6lcaL.jpg") };
            string userID = "hpfan2000347@harrypotter.com";

            KeyValuePair<string, List<UserMovie>> selectedLibrary = new KeyValuePair<string, List<UserMovie>>(userID, userLibrary);

            return View(selectedLibrary);
        }

        public ActionResult MyMovieDetails(string movieID)
        {
            int movieIDParsed = int.TryParse(movieID, out movieIDParsed) ? movieIDParsed : -1;

            if (movieIDParsed == -1)
            {
                return RedirectToAction("MyLibrary", new { movieID = movieID });
            }


            if (movieID == null)
            {
                return RedirectToAction("MyLibrary");
            }

            UserMovie selectedUserMovie = userLibrary.Find(userMovie => userMovie.movie.movieID == movieIDParsed);


            if (selectedUserMovie == null)
            {
                return RedirectToAction("MyLibrary");
            }

            return View(selectedUserMovie);
        }
    }
}