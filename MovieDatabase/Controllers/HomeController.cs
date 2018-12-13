using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.DAL;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class HomeController : Controller
    {
        private FlixListContext db = new FlixListContext();

        public ActionResult Movies(string search)
        {
            // check if no search criteria
            if (search == null)
            {
                return View(db.Movies.ToList());
            }

            //return list of movies matching search result
            List<Movie> searchResults = db.Movies.Where(movie => movie.title.ToUpper().Contains(search.ToUpper())).ToList();
            return View(searchResults);
        }

        public ActionResult MovieDetails(string movieID)
        {
            // convert the movieID string to an integer
            int movieIDParsed = int.TryParse(movieID, out movieIDParsed) ? movieIDParsed: -1;

            if (movieIDParsed == -1)
            {
                return RedirectToAction("Movies", new { movieID = movieID});
            }
            
            // check if movieID is passed and redirect to movies view if none
            if (movieID == null)
            {
                return RedirectToAction("Movies");
            }

            // check if movie is in list of movies
            List<Movie> selectedMovie = db.Movies.Where(movie => movie.movieID == movieIDParsed).ToList();

            // redirect to movies view if movie not found
            if (selectedMovie.Count() == 0)
            {
                return RedirectToAction("Movies");
            }

            return View(selectedMovie);
        }

        public ActionResult Contact()
        {
            // will use this method in the future
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}