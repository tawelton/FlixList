using Microsoft.AspNet.Identity;
using MovieDatabase.DAL;
using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieDatabase.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
        private FlixListContext db = new FlixListContext();

        // GET: MyLibrary
        public ActionResult MyLibrary()
        {
            
            List<Movie> userLibrary = new List<Movie>();

            string userLibraryQuery = "SELECT * FROM(SELECT DISTINCT userID, movie.movieID, movie.title, movie.posterURL FROM UserLibrary INNER JOIN Movie ON UserLibrary.movieID = Movie.movieID) AS Movies WHERE userID = " + User.Identity.GetUserId() + "; ";

            userLibrary = db.Database.SqlQuery<Movie>(userLibraryQuery).ToList();

            return View(userLibrary);
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

            /*
            UserMovie selectedUserMovie = userLibrary.Find(userMovie => userMovie.movie.movieID == movieIDParsed);


            if (selectedUserMovie == null)
            {
                return RedirectToAction("MyLibrary");
            }
            */

            return View();
        }
    }
}