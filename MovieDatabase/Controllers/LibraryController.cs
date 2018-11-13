using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDatabase.Controllers;

namespace MovieDatabase.Controllers
{
    public class LibraryController : Controller
    {
        public static Dictionary<string, Dictionary<int, string[]>> userLibrary = new Dictionary<string, Dictionary<int, string[]>>();

        // GET: MyLibrary
        public ActionResult MyLibrary()
        {
            List<UserMovie> selectedLibrary = new List<UserMovie>();

            if (userLibrary.ContainsKey(User.Identity.Name))
            {

                foreach (KeyValuePair<int, string[]> libraryMovie in userLibrary[User.Identity.Name])
                {
                    UserMovie fetchedMovie = new UserMovie(HomeController.movies.Find(movie => movie.movieID == libraryMovie.Key), userLibrary[User.Identity.Name][libraryMovie.Key]);

                    selectedLibrary.Add(fetchedMovie);
                }
            }

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

            UserMovie selectedUserMovie = new UserMovie(HomeController.movies.Find(movie => movie.movieID == movieIDParsed) , userLibrary[User.Identity.Name][movieIDParsed]);


            if (selectedUserMovie == null)
            {
                return RedirectToAction("MyLibrary");
            }

            return View(selectedUserMovie);
        }
    }
}